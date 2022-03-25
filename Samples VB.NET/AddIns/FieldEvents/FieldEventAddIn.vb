Imports System.Text
Imports System.Runtime.InteropServices
Imports Therefore.API

Namespace AddInSamples
	<Guid("0EC3AD9D-2B17-4583-81A7-8255A4CF0863"), ComVisible(True), ClassInterface(ClassInterfaceType.None)> _
	Public Class FieldEventAddIn
		Implements ITheAddIn

		Public Sub GetHandledEvents(ByVal nClient As TheClientType, ByVal pEventSet As TheEventSet) Implements ITheAddIn.GetHandledEvents
			pEventSet.AddAll()
			MessageBox.Show("FieldEventsAddIn successfully registered.")
		End Sub

		Public Function HandleEvent(ByVal pEvent As TheEvent) As Integer Implements ITheAddIn.HandleEvent
			MessageBox.Show("FieldEventsAddIn handles event." & vbCrLf & CType(pEvent, Object).ToString())
			Return 0
		End Function
	End Class
End Namespace
