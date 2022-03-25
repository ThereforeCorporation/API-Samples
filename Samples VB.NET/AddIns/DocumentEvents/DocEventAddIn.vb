Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports Therefore.API

Namespace AddInSamples
	<Guid("9DDC5D67-A86F-4b57-A862-C75F7F51B124"), ComVisible(True), ClassInterface(ClassInterfaceType.None)> _
	Public Class DocEventAddIn
		Implements ITheAddIn
		Public Sub GetHandledEvents(ByVal client As TheClientType, ByVal eventSet As TheEventSet) Implements ITheAddIn.GetHandledEvents
			eventSet.Add(TheEventType.CheckOut)
			eventSet.Add(TheEventType.CheckIn)
		End Sub

		Public Function HandleEvent(ByVal e As TheEvent) As Integer Implements ITheAddIn.HandleEvent
			' Ask before checkout
			If e.EventType = TheEventType.CheckOut Then
				Dim result As DialogResult = MessageBox.Show("Do you really want to check out the document from Therefore™?", "Check out Document", MessageBoxButtons.YesNo)
				If result = DialogResult.Yes Then
					Return 0
				ElseIf result = DialogResult.No Then
					Return 1
				End If
			' check in notification
			ElseIf e.EventType = TheEventType.CheckIn Then
				MessageBox.Show("Document has been changed. Checking document in.")
			End If
			Return 0
		End Function
	End Class
End Namespace
