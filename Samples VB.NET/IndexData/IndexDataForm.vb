Imports System.ComponentModel
Imports System.Text
Imports Therefore.API

Namespace IndexData
	Partial Public Class IndexDataForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private server As TheServer

		Private Sub IndexDataForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Try
				' 1. Connect to the Therefore™ server            
				server = New TheServer()
				server.Connect(TheClientType.CustomApplication)
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try

		End Sub

		Private Sub btn_read_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_read.Click
			Try
                ' 2. Declare and initialize a new Therefore document
                Dim indexData As New TheIndexData()

                ' 3. load index data from the server to the inbox
                Dim docNo As Integer = 1
                indexData.Load(docNo, 0, server) 'categoryNo parameter is obsolete and can always be set to 0

                Me.txt_output.Text = ""
                ' 4A. Iterate index data pairs in a for-each loop
                For Each pair As ThePair In indexData
					Me.txt_output.Text += CType(pair, Object).ToString() & vbCrLf
				Next pair

                ' 4B. Iterate index data field names only
                ' foreach (string fieldName in indexData.FieldNames)
                '     this.txt_output.Text += pair.ToString() + "\r\n";

                ' 4C. Iterate index data field names only
                ' foreach (object value in indexData.Values)
                '     this.txt_output.Text += pair.ToString() + "\r\n";
            Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_save_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_save.Click
			Try
                ' 2. Declare and initialize a new Therefore document
                Dim indexData As New TheIndexData()

                ' 3. Retrieve the document from the server to the inbox
                Dim docNo As Integer = 1
                indexData.Load(docNo, 0, server) 'categoryNo parameter is obsolete and can always be set to 0

                ' 4. Modify index data values
                indexData("Extension") = "JPG"
				indexData("From_Folder") = ".\"

                ' 5. Save the changes to the server
                indexData.SaveChanges(server)

                ' 6. Display confirmation
                Me.txt_output.Text = "Index Data changed."
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub IndexDataForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			server.Disconnect()
		End Sub
	End Class
End Namespace
