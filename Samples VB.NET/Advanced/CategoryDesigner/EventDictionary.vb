Imports System.Text

Namespace Therefore.Samples
	Public Class EventDictionary(Of TKey, TValue)
		Inherits Dictionary(Of TKey, TValue)
		Public Event DictionaryItemAdded As DictionaryItemAddedEventHandler
		Public Delegate Sub DictionaryItemAddedEventHandler(ByVal sender As Object, ByVal e As DictionaryAddItemEventArgs(Of TKey, TValue))

		Public Event DictionaryItemRemoved As DictionaryItemRemovedEventHandler
		Public Delegate Sub DictionaryItemRemovedEventHandler(ByVal sender As Object, ByVal e As DictionaryRemoveItemEventArgs(Of TKey))

		Public Event DictionaryCleared As DictionaryClearedEventHandler
		Public Delegate Sub DictionaryClearedEventHandler(ByVal sender As Object, ByVal e As EventArgs)

		Public Shadows Sub Add(ByVal key As TKey, ByVal value As TValue)
			MyBase.Add(key, value)
			RaiseEvent DictionaryItemAdded(Me, New DictionaryAddItemEventArgs(Of TKey, TValue)(key, value))
		End Sub

		Public Shadows Sub Clear()
			MyBase.Clear()
			RaiseEvent DictionaryCleared(Me, New EventArgs())
		End Sub

		Public Shadows Function Remove(ByVal key As TKey) As Boolean
			Dim ret As Boolean = MyBase.Remove(key)
			RaiseEvent DictionaryItemRemoved(Me, New DictionaryRemoveItemEventArgs(Of TKey)(key))
			Return ret
		End Function
	End Class

	Public Class DictionaryAddItemEventArgs(Of TKey, TValue)
		Inherits EventArgs
		Private privateKey As TKey
		Public Property Key() As TKey
			Get
				Return privateKey
			End Get
			Private Set(ByVal value As TKey)
				privateKey = value
			End Set
		End Property
		Private privateValue As TValue
		Public Property Value() As TValue
			Get
				Return privateValue
			End Get
			Private Set(ByVal value As TValue)
				privateValue = value
			End Set
		End Property
		Public Sub New(ByVal key As TKey, ByVal value As TValue)
			Me.Key = key
			Me.Value = value
		End Sub
	End Class

	Public Class DictionaryRemoveItemEventArgs(Of TKey)
		Inherits EventArgs
		Private privateKey As TKey
		Public Property Key() As TKey
			Get
				Return privateKey
			End Get
			Private Set(ByVal value As TKey)
				privateKey = value
			End Set
		End Property
		Public Sub New(ByVal key As TKey)
			Me.Key = key
		End Sub
	End Class
End Namespace
