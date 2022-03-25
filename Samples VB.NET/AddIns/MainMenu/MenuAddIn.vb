Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Text
Imports Therefore.API

Namespace AddInSamples
	<Guid("EC1DB05D-D4CA-4e60-B12A-BF4A6289EA12"), ComVisible(True), ClassInterface(ClassInterfaceType.None)> _
	Public Class MenuAddIn
		Implements ITheAddIn
		Public Sub GetHandledEvents(ByVal clientType As TheClientType, ByVal eventSet As TheEventSet) Implements ITheAddIn.GetHandledEvents
			' Sign up for the InitMenu and MenuClick events
			eventSet.Add(TheEventType.InitMenu)
			eventSet.Add(TheEventType.MenuClick)
		End Sub

		Public Function HandleEvent(ByVal e As TheEvent) As Integer Implements ITheAddIn.HandleEvent
			Dim titles() As String = {"Canon &Europe", "Canon &Deutschland", "Canon &Italia", "Canon &United Kingdom"}
			Dim urls() As String = {"http://www.canon-europe.com/", "http://www.canon.de/", "http://www.canon.it/", "http://www.canon.co.uk/"}
			Const offset As Integer = 1
			Select Case e.EventType
				Case TheEventType.InitMenu
					' Insert a new entry into the help menu
					e.Menu.Add("On the Web", 50)
					Dim helpMenu As TheMenu = e.Menu.Find("On the Web")
					For i As Integer = 0 To titles.Length - 1
						 helpMenu.Add(titles(i), offset + i)
					Next i
					Return 0

				Case TheEventType.MenuClick
					If e.Menu.ID >= offset AndAlso e.Menu.ID < offset + urls.Length Then
						System.Diagnostics.Process.Start(urls(e.Menu.ID - offset)) 'executing a URL starts the default browser
					End If
					Return 0
			End Select
			Return -1 ' This should never happen. Returning -1 unregisters the incoming event type
		End Function
	End Class
End Namespace
