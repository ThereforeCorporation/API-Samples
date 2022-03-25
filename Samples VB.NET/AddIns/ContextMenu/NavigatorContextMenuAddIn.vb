Imports System.Text
Imports System.IO
Imports System.Runtime.InteropServices
Imports Therefore.API

Namespace AddInSamples
	<Guid("BC93DF7C-0E7A-4240-AA19-5858687409BB"), ComVisible(True), ClassInterface(ClassInterfaceType.None)> _
	Public Class NavigatorContextMenuAddIn
		Implements ITheAddIn
		Public Sub GetHandledEvents(ByVal clientType As TheClientType, ByVal eventSet As TheEventSet) Implements ITheAddIn.GetHandledEvents
			If clientType = TheClientType.NavigatorClient Then
				eventSet.Add(TheEventType.InitContextMenu)
				eventSet.Add(TheEventType.ContextMenuClick)
			End If
		End Sub

		Public Function HandleEvent(ByVal e As TheEvent) As Integer Implements ITheAddIn.HandleEvent
			Select Case e.EventType
				Case TheEventType.InitContextMenu
					' Insert a new entry into the help menu
					e.Menu.AddSeparator()
					e.Menu.Add("&Show index data message box", 1)
					Return 0

				Case TheEventType.ContextMenuClick
					If e.Menu.ID = 1 Then ' If our menu item was clicked
						For Each ix As TheIndexData In e.IndexDataList
							MessageBox.Show(CType(ix, Object).ToString())
						Next ix
					End If
					Return 0
			End Select

			Return -1 ' This should never happen; returning -1 unregisters the incoming event type
		End Function
	End Class
End Namespace
