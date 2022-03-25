Imports System.ComponentModel
Imports System.Text
Imports Therefore.API

Namespace AddInSamples
	Partial Public Class CustomWorkflowForm
		Inherits Form
		Public bApproved As Boolean = False
		Private _nDocNo As Integer = 0

		Public Sub New(ByVal nDocNo As Integer)
			InitializeComponent()
			_nDocNo = nDocNo
		End Sub

		Private Sub btnApprove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnApprove.Click
			bApproved = True
			DialogResult = System.Windows.Forms.DialogResult.OK
			Close()
		End Sub

		Private Sub btnReject_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReject.Click
			bApproved = False
			DialogResult = System.Windows.Forms.DialogResult.OK
			Close()
		End Sub

		Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
			DialogResult = System.Windows.Forms.DialogResult.Cancel
			Close()
		End Sub

		Private Sub btnView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnView.Click
			Dim s As New TheServer()
			s.Connect(TheClientType.CustomApplication)

			Dim doc As New TheDocument()
			Dim strFileName As String = doc.Retrieve(_nDocNo, "", s)
			doc.View()
		End Sub
	End Class
End Namespace
