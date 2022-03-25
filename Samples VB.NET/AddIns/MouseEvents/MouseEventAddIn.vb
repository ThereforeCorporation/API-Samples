Imports System.Text
Imports System.IO
Imports System.Runtime.InteropServices
Imports Therefore.API

Namespace AddInSamples
	<Guid("A6E16D8F-F4CA-471f-A350-0589967A10F5"), ComVisible(True), ClassInterface(ClassInterfaceType.None)> _
	Public Class MouseEventAddIn
		Implements ITheAddIn
		Public Sub GetHandledEvents(ByVal client As TheClientType, ByVal eventSet As TheEventSet) Implements ITheAddIn.GetHandledEvents
			' Register for all events
			eventSet.Add(TheEventType.CategoryFieldLeftMouseDown)
			eventSet.Add(TheEventType.CategoryFieldLeftMouseUp)
			eventSet.Add(TheEventType.CategoryFieldLeftDoubleClick)
			eventSet.Add(TheEventType.CategoryFieldRightMouseDown)
			eventSet.Add(TheEventType.CategoryFieldRightMouseUp)
			eventSet.Add(TheEventType.CategoryFieldRightDoubleClick)
			eventSet.Add(TheEventType.CategoryFieldMiddleMouseDown)
			eventSet.Add(TheEventType.CategoryFieldMiddleMouseUp)
			eventSet.Add(TheEventType.CategoryFieldMiddleDoubleClick)
		End Sub

		Public Function HandleEvent(ByVal e As TheEvent) As Integer Implements ITheAddIn.HandleEvent
			If e.ObjectName = "From Folder" Then
				e.CategoryDialog.IndexData.SetValueByFieldNo(e.ObjectID, e.EventType.ToString())
				e.CategoryDialog.Update()
			End If

			Return 0
		End Function
	End Class
End Namespace
