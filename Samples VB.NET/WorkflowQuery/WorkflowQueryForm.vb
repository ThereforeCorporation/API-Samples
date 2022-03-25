Imports System.ComponentModel
Imports System.Text
Imports Therefore.API

Namespace WorkflowQuery
	Partial Public Class WorkflowQueryForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private server As TheServer

		Private Sub WorkflowQueryForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Try
				' 1. Connect to the Therefore™ server
				server = New TheServer()
				server.Connect(TheClientType.CustomApplication)
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_specific_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_specific.Click
			Try
				' 2. Create a new query
				Dim wfQuery As New TheQuery()

				' 3. Execute the query on the server
				Dim wfResult As TheQueryResult = wfQuery.ExecuteWorkflowQuery(1, TheWorkflowFlags.AllInstances, server)

				' Optional 4. Display the results in a messageBox
				MessageBox.Show(CType(wfResult, Object).ToString())
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_all_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_all.Click
			Try
				' 2. Create a new query
				Dim wfQuery As New TheQuery()

				' 3. Execute the query on the server
				Dim wfResult As TheMultiQueryResult = wfQuery.GetAllWorkflowInstances(TheWorkflowFlags.AllInstances, server)

				' Optional 4. Display the results in a messageBox
				MessageBox.Show(CType(wfResult, Object).ToString())
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub WorkflowQueryForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			server.Disconnect()
		End Sub
	End Class
End Namespace
