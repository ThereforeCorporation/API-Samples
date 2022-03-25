Imports System.ComponentModel
Imports System.Text
Imports Therefore.API

Namespace NavigatorFind
	Partial Public Class NavigatorFindForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btnFind_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFind.Click
			Try
				Dim server As New TheServer()
				server.Connect(TheClientType.NavigatorClient)

				Dim ixData As New TheIndexData()
				ixData.SetCategory("Files", server)
				ixData("Extension") = Me.cmbExtension.SelectedItem.ToString()
				ixData("From_Folder") = Me.txtFolder.Text

				Dim app As New TheApplication()
				app.NavigatorFind(ixData, TheNavigatorFindFlags.ExecuteQuery, 1)

				server.Disconnect()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub
	End Class
End Namespace
