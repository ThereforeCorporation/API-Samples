Imports System.Text
Imports System.IO
Imports System.Runtime.InteropServices
Imports Therefore.API

Namespace AddInSamples
	<Guid("781D8934-FCDC-4594-9696-A3ED28B32849"), ComVisible(True), ClassInterface(ClassInterfaceType.None)> _
	Public Class EventLogAddIn
		Implements ITheAddIn
		Private eventLog As String

		Public Sub GetHandledEvents(ByVal client As TheClientType, ByVal eventSet As TheEventSet) Implements ITheAddIn.GetHandledEvents
			' Register for all events
			eventSet.AddAll()
		End Sub

		Public Function HandleEvent(ByVal e As TheEvent) As Integer Implements ITheAddIn.HandleEvent
			' Append the current event to a string
			eventLog &= Date.Now.ToString() & " ... " & CType(e, Object).ToString() & vbCrLf

			' Write the event log to a file when the application exits
			If e.EventType = TheEventType.ExitApplication Then
				'this file can be found in the Therefore install directory
				Dim writer As New StreamWriter("eventLog.txt")
				writer.WriteLine(eventLog)
				writer.Flush()
				writer.Close()
			End If

			Return 0
		End Function
	End Class
End Namespace
