Imports System.ComponentModel
Imports System.Text
Imports Therefore.API

Namespace Query
	Partial Public Class QueryForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
			Try
				Dim server As New TheServer()
				server.Connect(TheClientType.CustomApplication)
				'create a query object
				Dim q As New TheQuery()
				'load the category you want to search
				q.Category.Load("Files", server)
                'in this sample we want to be able to get all fields
                q.SelectFields.AddAll()

				'add the query strings entered by the user to the conditions
				'do not add an empty value to the conditions. it will the result 
				If txtExtension.Text <> "" Then
					q.Conditions.Add("Extension", txtExtension.Text)
				End If
				If txtFileName.Text <> "" Then
					q.Conditions.Add("Filename", txtFileName.Text)
				End If
				If txtFolder.Text <> "" Then
					q.Conditions.Add("From_Folder", txtFolder.Text)
				End If
				If maskedTextBoxDate.Text <> "" AndAlso maskedTextBoxDate.Text.IndexOf(" "c) = -1 Then
					q.Conditions.Add("Creation_Date",maskedTextBoxDate.Text)
				End If

				'execute the query and get result
				Dim qRes As TheQueryResult = q.Execute(server)
				MessageBox.Show(CType(qRes, Object).ToString(), "Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		Private Sub btnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExit.Click
			Application.Exit()
		End Sub
	End Class
End Namespace