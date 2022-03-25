Imports System.Text
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports Therefore.API
Imports System.Globalization

Namespace Therefore.Samples
	Public Class CategoryFieldViewModel
		Inherits FieldViewModel
		Private _category As TheCategory

		Public Sub New(ByVal cat As TheCategory)
			MyBase.New()
			_category = cat
			UpdateFieldList()
			UpdateLanguages()
			CurrentLanguage = CultureInfo.CurrentCulture
		End Sub

		Public Overrides Sub UpdateFieldList()
			Dim fields As New List(Of TheCategoryField)()
			For i As Integer = 0 To _category.FieldCount - 1
				fields.Add(_category.GetFieldByIndex(i))
			Next i
			_filteredFields = CollectionViewSource.GetDefaultView(fields)
			_filteredFields.Filter = New Predicate(Of Object)(AddressOf FieldFilter)
			OnPropertyChanged("VisibleFields")
		End Sub
		Public Overrides Property CurrentLanguage() As CultureInfo
			Get
				If _languages.ContainsKey(_category.GetCurrentLCID()) Then
					Return _languages(_category.GetCurrentLCID())
				End If
				Return _languages.Values(0)
			End Get

			Set(ByVal value As CultureInfo)
				_category.SetCurrentLCID(value.LCID)
			End Set
		End Property

		Public Sub UpdateLanguages()
			_languages = New SortedList(Of Integer, CultureInfo)()
			Dim lcids As TheIntArray = _category.GetAvailableLCIDs()
			For Each lcid As Integer In lcids
				_languages.Add(lcid, New CultureInfo(lcid))
			Next lcid
		End Sub

		Public ReadOnly Property Category() As TheCategory
			Get
				Return _category
			End Get
		End Property
	End Class
End Namespace
