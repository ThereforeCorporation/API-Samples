Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.Text

Namespace Therefore.Samples
	Public Class DataGridColumnsBehavior
		Public Shared ReadOnly BindableColumnsProperty As DependencyProperty = DependencyProperty.RegisterAttached("BindableColumns", GetType(ObservableCollection(Of DataGridColumn)), GetType(DataGridColumnsBehavior), New UIPropertyMetadata(Nothing, AddressOf BindableColumnsPropertyChanged))
		Private Shared Sub BindableColumnsPropertyChanged(ByVal source As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim dataGrid As DataGrid = TryCast(source, DataGrid)
			Dim columns As ObservableCollection(Of DataGridColumn) = TryCast(e.NewValue, ObservableCollection(Of DataGridColumn))
			dataGrid.Columns.Clear()
			If columns Is Nothing Then
				Return
			End If
			For Each column As DataGridColumn In columns
				dataGrid.Columns.Add(column)
			Next column
			AddHandler columns.CollectionChanged, Sub(sender, e2)
				Dim ne As NotifyCollectionChangedEventArgs = TryCast(e2, NotifyCollectionChangedEventArgs)
				If ne.Action = NotifyCollectionChangedAction.Reset Then
					dataGrid.Columns.Clear()
					For Each column As DataGridColumn In ne.NewItems
						dataGrid.Columns.Add(column)
					Next column
				ElseIf ne.Action = NotifyCollectionChangedAction.Add Then
					For Each column As DataGridColumn In ne.NewItems
						dataGrid.Columns.Add(column)
					Next column
				ElseIf ne.Action = NotifyCollectionChangedAction.Move Then
					dataGrid.Columns.Move(ne.OldStartingIndex, ne.NewStartingIndex)
				ElseIf ne.Action = NotifyCollectionChangedAction.Remove Then
					For Each column As DataGridColumn In ne.OldItems
						dataGrid.Columns.Remove(column)
					Next column
				ElseIf ne.Action = NotifyCollectionChangedAction.Replace Then
					dataGrid.Columns(ne.NewStartingIndex) = TryCast(ne.NewItems(0), DataGridColumn)
				End If
			End Sub
		End Sub
		Public Shared Sub SetBindableColumns(ByVal element As DependencyObject, ByVal value As ObservableCollection(Of DataGridColumn))
			element.SetValue(BindableColumnsProperty, value)
		End Sub
		Public Shared Function GetBindableColumns(ByVal element As DependencyObject) As ObservableCollection(Of DataGridColumn)
			Return CType(element.GetValue(BindableColumnsProperty), ObservableCollection(Of DataGridColumn))
		End Function
	End Class
End Namespace
