Imports System.Text
Imports Therefore.API
Imports System.Runtime.InteropServices

Namespace AddInSamples
	<Guid("02F95848-1E91-4061-AF7D-EC5727A86611"), ComVisible(True)> _
	Public Class CustomWorkflowDialog
		Implements ITheAddIn
		Public Sub GetHandledEvents(ByVal nClient As TheClientType, ByVal pEventSet As TheEventSet) Implements ITheAddIn.GetHandledEvents
			'the OpenWorkflowInstance Event will be triggered when the workflow dialog 
			'is opened in TheNavigator
			pEventSet.Add(TheEventType.OpenWorkflowInstance)
		End Sub

		Public Function HandleEvent(ByVal pEvent As TheEvent) As Integer Implements ITheAddIn.HandleEvent
			'the ObjectID is the workflow Instance no. that can be seen in the Navigator
			Dim nInstanceNo As Integer = pEvent.ObjectID
			Dim nTokenNo As Integer = pEvent.WFTokenNo

			'connect to the server
			Dim s As New TheServer()
			s.Connect(TheClientType.CustomApplication)

			'and load the workflow instance
			Dim wfInst As New TheWFInstance()
			wfInst.Load(s, nInstanceNo, nTokenNo)

			'check if the workflow instance belongs to a certain category
			'this can also be achieved by using the ProcessNo property
			'also check the current task of the workflow instance
			If wfInst.ProcessName = "Files" AndAlso wfInst.CurrTaskName = "Test" Then
				'create a workflow form and call it
				Dim nDocNo As Integer = wfInst.GetLinkedDocAt(0).DocNo
				Dim f As New CustomWorkflowForm(nDocNo)
				If f.ShowDialog() = DialogResult.OK Then
					If f.bApproved Then
						'choose which task will be next
						'each task can have multiple successors
						'here you can decide which one will be called next
						Dim wfTask As TheWFTask = wfInst.GetNextTaskAt(0)
						wfInst.ClaimInstance(s)
						wfInst.FinishCurrentTask(s, wfTask.TaskNo, "")
						Return 1
					Else
						Dim wfTask As TheWFTask = wfInst.GetNextTaskAt(1)
						wfInst.ClaimInstance(s)
						wfInst.FinishCurrentTask(s, wfTask.TaskNo, "")
						Return 1
					End If
				Else
					Return 2
				End If
			End If
			Return 0
		End Function
	End Class
End Namespace
