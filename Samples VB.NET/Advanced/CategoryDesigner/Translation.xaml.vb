Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports Therefore.API

Namespace Therefore.Samples
	''' <summary>
	''' Interaction logic for Translation.xaml
	''' </summary>
	Partial Public Class Translation
		Inherits Window
		Private _translationviewmodel As TranslationViewModel
		Private _cat As TheCategory
		Private _casedef As TheCaseDefinition
		Public Sub New(ByVal cat As TheCategory)
			_cat = cat
			_casedef = Nothing
			InitializeComponent()
		End Sub
		Public Sub New(ByVal casedef As TheCaseDefinition)
			_cat = Nothing
			_casedef = casedef
			InitializeComponent()
		End Sub

		Private Sub InitializeCategory(ByVal cat As TheCategory)
			Dim translations As New List(Of TranslationItem)()
			Dim languages As New EventDictionary(Of Integer, CultureInfo)()
			Dim lcids As TheIntArray = cat.GetAvailableLCIDs()
			For Each lcid As Integer In lcids
				languages.Add(lcid, New CultureInfo(lcid))
			Next lcid
			AddColumns(languages)
			translations.Add(New CategoryNameTranslationItem(cat))
			translations.Add(New CategoryDescriptionTranslationItem(cat))
			For i As Integer = 0 To cat.FieldCount - 1
				Dim field As TheCategoryField = cat.GetFieldByIndex(i)
				If Not field.IsSingleKeyword Then 'keyword id fields are not translated
					translations.Add(InitializeField(field, lcids))
				End If
				If field.FieldType = TheCategoryFieldType.TabControlField Then
					For Each tab As TheTabInfo In field.Tabs
						translations.Add(InitializeTab(tab, field.FieldNo, lcids))
					Next tab
				End If
			Next i
			_translationviewmodel.SetTranslation(translations, languages)
		End Sub

		Private Sub InitializeCaseDefinition(ByVal casedef As TheCaseDefinition)
			Dim translations As New List(Of TranslationItem)()
			Dim languages As New EventDictionary(Of Integer, CultureInfo)()
			Dim lcids As TheIntArray = casedef.GetAvailableLCIDs()
			For Each lcid As Integer In lcids
				languages.Add(lcid, New CultureInfo(lcid))
			Next lcid
			AddColumns(languages)
			translations.Add(New CaseDefinitionNameTranslationItem(casedef))
			translations.Add(New CaseDefinitionDescriptionTranslationItem(casedef))
			For i As Integer = 0 To casedef.FieldCount - 1
				Dim field As TheCategoryField = casedef.GetFieldByIndex(i)
				If Not field.IsSingleKeyword Then 'keyword id fields are not translated
					translations.Add(InitializeField(field, lcids))
				End If
				If field.FieldType = TheCategoryFieldType.TabControlField Then
					For Each tab As TheTabInfo In field.Tabs
						translations.Add(InitializeTab(tab, field.FieldNo, lcids))
					Next tab
				End If
			Next i
			_translationviewmodel.SetTranslation(translations, languages)
		End Sub

		Private Function InitializeField(ByVal field As TheCategoryField, ByVal lcids As TheIntArray) As TranslationItem
			Dim fielditem As New CategoryFieldTranslationItem(field)

			Dim originalLCID As Integer = field.GetCurrentLCID()
			For Each lcid As Integer In lcids
				field.SetCurrentLCID(lcid)
				If field.GetCurrentLCID() <> lcid Then 'field caption is not present in this language
					Continue For
				End If
				fielditem.Translations.Add(lcid, field.GetCaption(lcid))
			Next lcid
			field.SetCurrentLCID(originalLCID)
			Return fielditem
		End Function

		Private Function InitializeTab(ByVal tab As TheTabInfo, ByVal fieldno As Integer, ByVal lcids As TheIntArray) As TranslationItem
			Dim fielditem As New TabInfoTranslationItem(tab, fieldno)
			Dim originalLCID As Integer = tab.GetCurrentLCID()
			For Each lcid As Integer In lcids
				tab.SetCurrentLCID(lcid)
				If tab.GetCurrentLCID() <> lcid Then 'tab caption is not present in this language
					Continue For
				End If
				fielditem.Translations.Add(lcid, tab.GetCaption(lcid))
			Next lcid
			tab.SetCurrentLCID(originalLCID)
			Return fielditem
		End Function

		Private Sub dg_translation_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				_translationviewmodel = New TranslationViewModel()
				If _cat IsNot Nothing Then
					InitializeCategory(_cat)
				ElseIf _casedef IsNot Nothing Then
					InitializeCaseDefinition(_casedef)
				Else
					Throw New Exception("Invalid category or case definition.")
				End If
				dg_translation.DataContext = _translationviewmodel
				AddHandler _translationviewmodel.Languages.DictionaryItemAdded, AddressOf OnNewLanguage
				AddHandler _translationviewmodel.Languages.DictionaryItemRemoved, AddressOf OnLanguageRemoved
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub AddColumns(ByVal newColumns As Dictionary(Of Integer, CultureInfo))
			For Each lcid As Integer In newColumns.Keys
				AddColumn(newColumns(lcid))
			Next lcid
		End Sub

		Private Sub AddColumn(ByVal newColumn As CultureInfo)
			dg_translation.Columns.Add(New DataGridTextColumn With {.Binding = New Binding("Translations[" & newColumn.LCID & "]"), .Header = newColumn.Name})
				' bind to a dictionary property
		End Sub

		Private Sub RemoveColumn(ByVal lcid As Integer)
			Dim lang As CultureInfo = CultureInfo.GetCultureInfo(lcid)
			Dim toremove As DataGridColumn = Nothing
			For Each col As DataGridColumn In dg_translation.Columns
				If lang.Name = CStr(col.Header) Then
					toremove = col
					Exit For
				End If
			Next col
			If toremove IsNot Nothing Then
				dg_translation.Columns.Remove(toremove)
			Else
				MessageBox.Show("Language column not found in data grid.")
			End If
		End Sub

		Private Sub btn_save_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try

				Dim removelanguages As TheIntArray = Nothing
				If _cat IsNot Nothing Then
					removelanguages = _cat.GetAvailableLCIDs()
				ElseIf _casedef IsNot Nothing Then
					removelanguages = _casedef.GetAvailableLCIDs()
				Else
					Throw New Exception("Invalid category or case definition.")
				End If
				'search for all languages not in the viewmodel
				Dim i As Integer = 0
				Do While i < removelanguages.Count
					If _translationviewmodel.Languages.ContainsKey(removelanguages(i)) Then
						removelanguages.Remove(i)
						i -= 1
					End If
					i += 1
				Loop
				'and delete all languages that are not in the viewmodel
				For Each lcid As Integer In removelanguages
					If _cat IsNot Nothing Then
						_cat.DeleteTranslation(lcid)
					ElseIf _casedef IsNot Nothing Then
						_casedef.DeleteTranslation(lcid)
					End If
				Next lcid

				For Each item As TranslationItem In _translationviewmodel.Translations
					item.SetTranslatedValues()
				Next item
				Me.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_addlang_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim validlcids As List(Of Integer) = System.Enum.GetValues(GetType(ValidLanguages)).Cast(Of Integer)().ToList()
				For Each lcid As Integer In _translationviewmodel.Languages.Keys
					validlcids.Remove(lcid)
				Next lcid
				Dim languages As New List(Of CultureInfo)()
				For Each lcid As Integer In validlcids
					languages.Add(New CultureInfo(lcid))
				Next lcid

				Dim addlangdlg As New LanguageSelectionWindow(languages)
				If addlangdlg.ShowDialog() = True Then
					_translationviewmodel.Languages.Add(addlangdlg.SelectedLanguage.LCID, addlangdlg.SelectedLanguage)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub
		Private Sub btn_deletelang_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim removelangdlg As New LanguageSelectionWindow(_translationviewmodel.Languages.Values)
				If removelangdlg.ShowDialog() = True Then
					_translationviewmodel.Languages.Remove(removelangdlg.SelectedLanguage.LCID)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Public Sub OnNewLanguage(ByVal sender As Object, ByVal e As DictionaryAddItemEventArgs(Of Integer, CultureInfo))
			AddColumn(e.Value)
			_translationviewmodel.UpdatedLanguages()
		End Sub

		Public Sub OnLanguageRemoved(ByVal sender As Object, ByVal e As DictionaryRemoveItemEventArgs(Of Integer))
			RemoveColumn(e.Key)
			_translationviewmodel.UpdatedLanguages()
		End Sub
	End Class
End Namespace