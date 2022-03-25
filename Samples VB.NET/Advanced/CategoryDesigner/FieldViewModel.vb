Imports System.ComponentModel
Imports System.Globalization
Imports System.Text
Imports Therefore.API

Namespace Therefore.Samples
	Public Class FieldViewModel
		Implements INotifyPropertyChanged
		Protected _filteredFields As ICollectionView
		Protected _fieldType As TheCategoryFieldType
		Protected _fieldType_filterType As TheFilterType
		Protected _languages As SortedList(Of Integer, CultureInfo)

		Protected Sub New()
			_languages = Nothing
		End Sub

		Public Overridable Sub UpdateFieldList()
			Throw New NotImplementedException()
		End Sub
		Public ReadOnly Property Languages() As List(Of CultureInfo)
			Get
				Return _languages.Values.ToList()
			End Get
		End Property

		Public Overridable Property CurrentLanguage() As CultureInfo

		Public ReadOnly Property VisibleFields() As ICollectionView
			Get
				Return _filteredFields
			End Get
		End Property

		Public Property FilterFieldType() As TheCategoryFieldType
			Set(ByVal value As TheCategoryFieldType)
				_fieldType = value
				_filteredFields.Refresh()
			End Set
			Get
				Return _fieldType
			End Get
		End Property

		Public Property FilterTypeFieldType() As TheFilterType
			Set(ByVal value As TheFilterType)
				_fieldType_filterType = value
				_filteredFields.Refresh()
			End Set
			Get
				Return _fieldType_filterType
			End Get
		End Property

		Protected Function FieldFilter(ByVal item As Object) As Boolean
			Dim field As TheCategoryField = CType(item, TheCategoryField)
			If _fieldType = 0 Then
				Return True
			End If
            If _fieldType_filterType = TheFilterType.FilterNothing Then
                Return True
            End If
            If _fieldType_filterType = TheFilterType.FilterOnlyBy AndAlso field.FieldType <> _fieldType Then
                Return True
            End If
            If _fieldType_filterType = TheFilterType.FilterExclude AndAlso field.FieldType <> _fieldType Then
                Return True
            End If
            Return False
		End Function

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		Protected Overridable Sub OnPropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
	End Class
End Namespace
