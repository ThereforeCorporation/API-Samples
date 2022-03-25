Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports Therefore.API

Namespace AddInSamples
	<Guid("37C6D4CE-3667-430a-934C-EA8B4DFA7861"), ComVisible(True), ClassInterface(ClassInterfaceType.None)> _
	Public Class QueryAddIn
		Implements ITheAddIn
		Public Sub GetHandledEvents(ByVal client As TheClientType, ByVal eventSet As TheEventSet) Implements ITheAddIn.GetHandledEvents
			If client = TheClientType.NavigatorClient Then
				eventSet.Add(TheEventType.QueryFinished)
			End If
		End Sub

		Public Function HandleEvent(ByVal e As TheEvent) As Integer Implements ITheAddIn.HandleEvent
			' When a query finishes display a message box with query definition and results
			If e.EventType = TheEventType.QueryFinished Then
				MessageBox.Show(e.MultiQuery.ToString() & vbCrLf & e.MultiQueryResult.ToString())
			End If

			Return 0
		End Function
	End Class
End Namespace
