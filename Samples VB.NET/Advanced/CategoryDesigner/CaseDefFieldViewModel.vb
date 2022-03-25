Imports System.Globalization
Imports System.Text
Imports Therefore.API

Namespace Therefore.Samples
	Public Class CaseDefFieldViewModel
		Inherits FieldViewModel
		Private _casedef As TheCaseDefinition

		Public Sub New(ByVal cat As TheCaseDefinition)
			MyBase.New()
			_casedef = cat
			UpdateFieldList()
			UpdateLanguages()
		End Sub

		Public Overrides Sub UpdateFieldList()
			Dim fields As New List(Of TheCategoryField)()
			For i As Integer = 0 To _casedef.FieldCount - 1
				fields.Add(_casedef.GetFieldByIndex(i))
			Next i
			_filteredFields = CollectionViewSource.GetDefaultView(fields)
			_filteredFields.Filter = New Predicate(Of Object)(AddressOf FieldFilter)
			OnPropertyChanged("VisibleFields")
		End Sub

		Public Overrides Property CurrentLanguage() As CultureInfo
			Get
				If _languages.ContainsKey(_casedef.GetCurrentLCID()) Then
					Return _languages(_casedef.GetCurrentLCID())
				End If
				Return _languages.Values(0)
			End Get

			Set(ByVal value As CultureInfo)
				_casedef.SetCurrentLCID(value.LCID)
			End Set
		End Property

		Public Sub UpdateLanguages()
			_languages = New SortedList(Of Integer, CultureInfo)()
			Dim lcids As TheIntArray = _casedef.GetAvailableLCIDs()
			For Each lcid As Integer In lcids
				_languages.Add(lcid, New CultureInfo(lcid))
			Next lcid
		End Sub

		Public ReadOnly Property CaseDefinition() As TheCaseDefinition
			Get
				Return _casedef
			End Get
		End Property
	End Class
End Namespace
