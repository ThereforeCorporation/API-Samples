Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Globalization
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls

Namespace Therefore.Samples
	Public Class TranslationViewModel
		Implements INotifyPropertyChanged
		Private _languages As EventDictionary(Of Integer, CultureInfo)
		Private _translationlist As ObservableCollection(Of TranslationItem)

		Public Property Translations() As ObservableCollection(Of TranslationItem)
			Get
				Return _translationlist
			End Get
			Set(ByVal value As ObservableCollection(Of TranslationItem))
				If _translationlist IsNot value Then
					_translationlist = value
					OnPropertyChanged("Translations")
				End If
			End Set
		End Property

		Public ReadOnly Property Languages() As EventDictionary(Of Integer, CultureInfo)
			Get
				Return _languages
			End Get
		End Property

		Public Sub UpdatedLanguages()
			OnPropertyChanged("Languages")
		End Sub

		Public Sub SetTranslation(ByVal translations As List(Of TranslationItem), ByVal languages As EventDictionary(Of Integer, CultureInfo))
			_translationlist = New ObservableCollection(Of TranslationItem)(translations)
			_languages = languages
			AddHandler _languages.DictionaryItemRemoved, AddressOf OnLanguageRemoved
		End Sub

		Private Sub OnLanguageRemoved(ByVal sender As Object, ByVal e As DictionaryRemoveItemEventArgs(Of Integer))
			'this needs to be done to not recreate a deleted translation when saving the changes
			For Each item As TranslationItem In _translationlist
				item.Translations.Remove(e.Key)
			Next item
		End Sub

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
		Protected Overridable Sub OnPropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
	End Class
End Namespace