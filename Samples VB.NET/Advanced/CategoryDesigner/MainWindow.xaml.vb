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
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports Therefore.API

Namespace Therefore.Samples
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Private _viewmodel As FieldViewModel

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				cmb_filter_type.ItemsSource = System.Enum.GetValues(GetType(TheCategoryFieldType))
				cmb_filter_type.SelectedItem = TheCategoryFieldType.LabelField
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
				Close()
			End Try
		End Sub

		Private Sub btn_load_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim server As New TheServer()
				server.Connect(TheClientType.CustomApplication, "", "", "", "", True)

				UnlockViewModelObject(server) 'needed when loading a category or case definition when something is already loaded
				If rdb_category.IsChecked = True Then
					Dim catno As Integer = server.ShowCategorySelectionDialog()
					Dim cat As New TheCategory()
					cat.LoadForEdit(catno, server)
					_viewmodel = New CategoryFieldViewModel(cat)
				ElseIf rdb_casedefinition.IsChecked = True Then
					Dim casedefno As Integer = server.ShowCaseDefinitionSelectionDialog()
					Dim casedef As New TheCaseDefinition()
					casedef.LoadForEdit(casedefno, server)
					_viewmodel = New CaseDefFieldViewModel(casedef)
					_viewmodel.CurrentLanguage = CultureInfo.CurrentCulture
				End If

				If cmb_filter_type.SelectedItem IsNot Nothing Then
					_viewmodel.FilterFieldType = CType(cmb_filter_type.SelectedItem, TheCategoryFieldType)
				End If
				If rdb_filter_type_only.IsChecked = True Then
					_viewmodel.FilterTypeFieldType = TheFilterType.FilterOnlyBy
				ElseIf rdb_filter_type_exclude.IsChecked = True Then
					_viewmodel.FilterTypeFieldType = TheFilterType.FilterExclude
				Else
					_viewmodel.FilterTypeFieldType = TheFilterType.FilterNothing
				End If
				dg_categoryfields.DataContext = _viewmodel

				cmb_language.ItemsSource = _viewmodel.Languages
				If _viewmodel.Languages.Contains(_viewmodel.CurrentLanguage) Then
					cmb_language.SelectedItem = _viewmodel.CurrentLanguage
				Else
					cmb_language.SelectedIndex = 0
				End If

				server.Disconnect()
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub cmb_filter_type_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
			If _viewmodel Is Nothing Then
				Return
			End If
			_viewmodel.FilterFieldType = CType(cmb_filter_type.SelectedItem, TheCategoryFieldType)
		End Sub

		Private Sub rdb_filter_type_only_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If _viewmodel Is Nothing Then
				Return
			End If
			_viewmodel.FilterTypeFieldType = TheFilterType.FilterOnlyBy
		End Sub

		Private Sub rdb_filter_type_exclude_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If _viewmodel Is Nothing Then
				Return
			End If
			_viewmodel.FilterTypeFieldType = TheFilterType.FilterExclude
		End Sub

		Private Sub rdb_filter_type_all_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If _viewmodel Is Nothing Then
				Return
			End If
			_viewmodel.FilterTypeFieldType = TheFilterType.FilterNothing
		End Sub

		Private Sub btn_create_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim server As New TheServer()
				server.Connect(TheClientType.CustomApplication, "", "", "", "", True)

				If rdb_category.IsChecked = True Then
					Dim nc As New NewCategoryWindow()
					If nc.ShowDialog() = False Then
						Return
					End If
					Dim cat As New TheCategory()
					cat.Create(nc.CategoryName, nc.CaseDefNo, server)
					_viewmodel = New CategoryFieldViewModel(cat)
				ElseIf rdb_casedefinition.IsChecked = True Then
					Dim nc As New NewCaseDefinitionWindow()
					If nc.ShowDialog() = False Then
						Return
					End If
					Dim casedef As New TheCaseDefinition()
					casedef.Create(nc.CaseDefinitionName, nc.FolderNo)
					_viewmodel = New CaseDefFieldViewModel(casedef)
				End If

				If cmb_filter_type.SelectedItem IsNot Nothing Then
					_viewmodel.FilterFieldType = CType(cmb_filter_type.SelectedItem, TheCategoryFieldType)
				End If
				If rdb_filter_type_only.IsChecked = True Then
					_viewmodel.FilterTypeFieldType = TheFilterType.FilterOnlyBy
				ElseIf rdb_filter_type_exclude.IsChecked = True Then
					_viewmodel.FilterTypeFieldType = TheFilterType.FilterExclude
				Else
					_viewmodel.FilterTypeFieldType = TheFilterType.FilterNothing
				End If
				dg_categoryfields.DataContext = _viewmodel
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_save_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				If _viewmodel Is Nothing Then
					Return
				End If

				Dim server As New TheServer()
				server.Connect(TheClientType.CustomApplication, "", "", "", "", True)

				If TypeOf _viewmodel Is CategoryFieldViewModel Then
					CType(_viewmodel, CategoryFieldViewModel).Category.SaveChanges(server)
				Else
					CType(_viewmodel, CaseDefFieldViewModel).CaseDefinition.SaveChanges(server)
				End If
				_viewmodel.UpdateFieldList()
				UnlockViewModelObject(server)
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_create_field_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim cat As TheCategory = Nothing
				Dim casedef As TheCaseDefinition = Nothing

				Dim nfw As NewFieldWindow = Nothing
				If TypeOf _viewmodel Is CategoryFieldViewModel Then
					cat = CType(_viewmodel, CategoryFieldViewModel).Category
					nfw = New NewFieldWindow(cat)
				Else
					casedef = CType(_viewmodel, CaseDefFieldViewModel).CaseDefinition
					nfw = New NewFieldWindow(casedef)
				End If
				If (Not nfw.ShowDialog()) = True Then
					Return
				End If

				Dim server As New TheServer()
				server.Connect(TheClientType.CustomApplication, "", "", "", "", True)

				If cat IsNot Nothing Then
					cat.CreateField(nfw.TypeNo, nfw.FieldName, nfw.BelongsTo, nfw.BelongsToTable, server)
				Else
					casedef.CreateField(nfw.TypeNo, nfw.FieldName, nfw.BelongsTo, nfw.BelongsToTable, server)
				End If
				_viewmodel.UpdateFieldList()
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_delete_field_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim field As TheCategoryField = CType(dg_categoryfields.SelectedItem, TheCategoryField)
				If field Is Nothing OrElse _viewmodel Is Nothing Then
					Return
				End If
				If TypeOf _viewmodel Is CategoryFieldViewModel Then
					CType(_viewmodel, CategoryFieldViewModel).Category.DeleteField(field)
				Else
					CType(_viewmodel, CaseDefFieldViewModel).CaseDefinition.DeleteField(field)
				End If
				_viewmodel.UpdateFieldList()
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub dg_categoryfields_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			Try
				Dim field As TheCategoryField = CType(dg_categoryfields.SelectedItem, TheCategoryField)
				If field Is Nothing Then
					Return
				End If
				If dg_categoryfields.CurrentCell.Column.Header.ToString() = "DependencyMode" Then
					Dim options As New List(Of String)()
					options.AddRange(System.Enum.GetNames(GetType(TheDependencyMode)))
					Dim lpcw As New ListPropertyChangeWindow("DependencyMode", options)
					lpcw.Value = field.DependencyMode.ToString()
					If lpcw.ShowDialog() = True Then
						field.ChangeDependencyMode(CType(System.Enum.Parse(GetType(TheDependencyMode), lpcw.Value), TheDependencyMode), "")
					End If
					_viewmodel.UpdateFieldList()
				End If
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_test_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim ixdata As New TheIndexData()
				If TypeOf _viewmodel Is CategoryFieldViewModel Then
					Dim cat As TheCategory = CType(_viewmodel, CategoryFieldViewModel).Category
					If cat Is Nothing OrElse cat.CtgryNo < 0 Then
						Return
					End If
					ixdata.SetCategory(cat)
				Else
					Dim casedef As TheCaseDefinition = CType(_viewmodel, CaseDefFieldViewModel).CaseDefinition
					If casedef Is Nothing OrElse casedef.CaseDefinitionNo < 0 Then
						Return
					End If
					ixdata.SetCaseDefinition(casedef)

				End If
				If ixdata Is Nothing Then
					Return
				End If
				Dim server As New TheServer()
				server.Connect(TheClientType.CustomApplication, "", "", "", "", True)
				ixdata.EditIxData(server, "", "")
				server.Disconnect()
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_properties_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				If TypeOf _viewmodel Is CategoryFieldViewModel Then
					Dim cat As TheCategory = CType(_viewmodel, CategoryFieldViewModel).Category
					If cat Is Nothing Then
						Return
					End If
					Dim catprop As New CategoryPropertiesWindow(cat)
					catprop.ShowDialog()
				Else
					Dim casedef As TheCaseDefinition = CType(_viewmodel, CaseDefFieldViewModel).CaseDefinition
					If casedef Is Nothing Then
						Return
					End If
					Dim casedefprop As New CaseDefinitionPropertiesWindow(casedef)
					casedefprop.ShowDialog()
				End If
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_translation_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim translationdlg As Translation = Nothing
				If TypeOf _viewmodel Is CategoryFieldViewModel Then
					translationdlg = New Translation(CType(_viewmodel, CategoryFieldViewModel).Category)
				ElseIf TypeOf _viewmodel Is CaseDefFieldViewModel Then
					translationdlg = New Translation(CType(_viewmodel, CaseDefFieldViewModel).CaseDefinition)
				End If
				translationdlg.ShowDialog()
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub cmb_language_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
			Try
				_viewmodel.CurrentLanguage = CType(cmb_language.SelectedItem, CultureInfo)
				_viewmodel.UpdateFieldList()
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub UnlockViewModelObject(ByVal server As TheServer)
			If _viewmodel Is Nothing Then
				Return
			End If
			If server Is Nothing Then
				server = New TheServer()
			End If
			If Not server.Connected Then
				server.Connect(TheClientType.CustomApplication, "", "", "", "", True)
			End If

			If TypeOf _viewmodel Is CategoryFieldViewModel Then
				If CType(_viewmodel, CategoryFieldViewModel).Category IsNot Nothing Then
					CType(_viewmodel, CategoryFieldViewModel).Category.Unlock(server)
				End If
			ElseIf TypeOf _viewmodel Is CaseDefFieldViewModel Then
				If CType(_viewmodel, CaseDefFieldViewModel).CaseDefinition IsNot Nothing Then
					CType(_viewmodel, CaseDefFieldViewModel).CaseDefinition.Unlock(server)
				End If
			End If
		End Sub
	End Class

	Public Enum TheFilterType
		FilterExclude = 0
		FilterOnlyBy = 1
		FilterNothing = 2
	End Enum
End Namespace
