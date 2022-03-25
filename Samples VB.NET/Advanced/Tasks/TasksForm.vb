Imports System.ComponentModel
Imports System.Text
Imports Therefore.API

Namespace Tasks
	Partial Public Class TasksForm
		Inherits Form
'INSTANT VB NOTE: The variable server was renamed since Visual Basic does not allow class members with the same name:
		Private server_Renamed As TheServer
		Private taskInfo As TheTaskInfo
		Private task As TheTask

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btn_loadtaskinfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_loadtaskinfo.Click
			Try
				taskInfo = New TheTaskInfo()
				taskInfo.Load(Server, Convert.ToInt32(txt_taskID.Text))

				txt_docno_info.Text = taskInfo.DocNo.ToString()
				txt_mode_info.Text = CInt(taskInfo.Mode).ToString()
				txt_createdby.Text = taskInfo.CreatedBy.ToString()
				txt_assignedto.Text = taskInfo.AssignedTo.ToString()
				txt_lastupdate.Text = taskInfo.LastUpdate.ToString()
				txt_createdbyuser.Text = taskInfo.CreatedByUser.ToString()
				txt_assignedtouser.Text = taskInfo.AssignedToUser.ToString()
				txt_subject_info.Text = taskInfo.Subject
				txt_startdate_info.Text = taskInfo.StartDate.ToString()
				txt_duedate_info.Text = taskInfo.DueDate.ToString()
				txt_usernoassigned.Text = taskInfo.UserNoAssigned.ToString()
				txt_instructions_info.Text = taskInfo.Instructions
				txt_comment.Text = taskInfo.Comment
				txt_status.Text = CInt(taskInfo.Status).ToString()
				txt_decision.Text = ""
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_startnew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_startnew.Click
			Try
				If task Is Nothing Then
					task = New TheTask()
				End If

				task.DocNo = Convert.ToInt32(txt_docno_def.Text)
				task.Mode = CType(Convert.ToInt32(txt_mode_def.Text), TheTaskMode)
				task.UserNo = Convert.ToInt32(txt_userno.Text)
				task.Subject = txt_subject_def.Text
				task.StartDate = Convert.ToDateTime(txt_startdate_def.Text)
				task.DueDate = Convert.ToDateTime(txt_duedate_def.Text)
				task.Instructions = txt_instructions_def.Text
				task.Start(Server)
				MessageBox.Show("A new task has been started.")
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_complete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_complete.Click
			Try
				If taskInfo Is Nothing Then
					MessageBox.Show("A task info object has to be loaded for this operation.")
					Return
				End If

				taskInfo.Comment = txt_comment.Text
				taskInfo.SetStatus(CType(Convert.ToInt32(txt_status.Text), TheTaskStatus))
				taskInfo.Complete(Server, CType(Convert.ToInt32(txt_decision.Text), TheTaskDecision))
				MessageBox.Show("Task completed.")
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_update_info_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_update_info.Click
			Try
				If taskInfo Is Nothing Then
					MessageBox.Show("A task info object has to be loaded for this operation.")
					Return
				End If

				taskInfo.Comment = txt_comment.Text
				taskInfo.SetStatus(CType(Convert.ToInt32(txt_status.Text), TheTaskStatus))
				taskInfo.SaveChanges(Server)
				MessageBox.Show("The task info has been updated.")
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_view_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_view.Click
			Try
				If taskInfo IsNot Nothing Then
					taskInfo.View(Server)
				Else
					MessageBox.Show("A task info object has to be loaded in order to view a task.")
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_loadtaskdefinition_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_loadtaskdefinition.Click
			Try
				task = New TheTask()
				task.Load(Server, Convert.ToInt32(txt_taskID.Text))

				txt_docno_def.Text = task.DocNo.ToString()
				txt_mode_def.Text = CInt(task.Mode).ToString()
				txt_userno.Text = task.UserNo.ToString()
				putAssignTo(task.AssignTo)
				txt_subject_def.Text = task.Subject
				txt_startdate_def.Text = task.StartDate.ToString()
				txt_duedate_def.Text = task.DueDate.ToString()
				txt_instructions_def.Text = task.Instructions
				chk_notifiyonupdate.Checked = task.NotifyOnUpdate
				chk_notifyusers.Checked = task.NotifyUsers
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_addusers_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_addusers.Click
			Try
				If task Is Nothing Then
					task = New TheTask()
				End If
				Dim userlist As TheUserList = task.AssignTo
				Server.ShowUserSelectionDialog(userlist, TheUserQueryFlags.FindAllUsers)
				task.AssignTo = userlist
				putAssignTo(userlist)
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_update_def_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_update_def.Click
			Try
				If task Is Nothing Then
					MessageBox.Show("A task definition object has to be loaded for this operation.")
					Return
				End If

				task.DocNo = Convert.ToInt32(txt_docno_def.Text)
				task.Mode = CType(Convert.ToInt32(txt_mode_def.Text), TheTaskMode)
				task.UserNo = Convert.ToInt32(txt_userno.Text)
				task.Subject = txt_subject_def.Text
				task.StartDate = Convert.ToDateTime(txt_startdate_def.Text)
				task.DueDate = Convert.ToDateTime(txt_duedate_def.Text)
				task.Instructions = txt_instructions_def.Text
				task.SaveChanges(Server)
				MessageBox.Show("The task definition has been updated.")
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub putAssignTo(ByVal userlist As TheUserList)
			If userlist Is Nothing Then
				Return
			End If
			For i As Integer = 0 To userlist.Count - 1
				Dim user As TheUser = userlist(i)
				If i>0 Then
					txt_assignto.Text &= ", "
				End If
				txt_assignto.Text &= user.DisplayName
			Next i
		End Sub

		Private ReadOnly Property Server() As TheServer
			Get
				If server_Renamed Is Nothing Then
					server_Renamed = New TheServer()
				End If
				If Not server_Renamed.Connected Then
					server_Renamed.Connect()
				End If
				Return server_Renamed
			End Get
		End Property
	End Class
End Namespace
