Imports System.ComponentModel
Imports System.Text

Namespace WFExtractFiles
	Partial Public Class ParamDialog
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

'INSTANT VB NOTE: The variable path was renamed since Visual Basic does not allow class members with the same name:
		Private path_Renamed As String

		Private Sub btn_browse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_browse.Click
			Dim folderbrowser As New FolderBrowserDialog()
			If folderbrowser.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				txt_path.Text = folderbrowser.SelectedPath
			End If
		End Sub

		Private Sub btn_cancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancel.Click
			Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.Close()
		End Sub

		Private Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
			Me.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.path_Renamed = txt_path.Text
			Me.Close()
		End Sub

		Public Property Path() As String
			Get
				Return path_Renamed
			End Get
			Set(ByVal value As String)
				path_Renamed = value
				txt_path.Text = path_Renamed
			End Set
		End Property
	End Class
End Namespace
