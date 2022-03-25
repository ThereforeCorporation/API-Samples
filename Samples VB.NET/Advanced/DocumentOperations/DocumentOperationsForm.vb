Imports System.ComponentModel
Imports System.Text
Imports Therefore.API
Imports System.IO

Namespace DocumentOperations
	Partial Public Class DocumentOperationsForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btnExtractBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExtractBrowse.Click
			If System.Windows.Forms.DialogResult.OK = folderBrowserDialog1.ShowDialog(Me) Then
				txtExtractPath.Text = folderBrowserDialog1.SelectedPath
			End If
		End Sub

		Private Sub btnExtract_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExtract.Click
            If mtbDocNo.Text = "" Then
                MessageBox.Show("Please enter a DocNo to retrive.", "DocNo missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf txtExtractPath.Text = "" Then
                MessageBox.Show("Please enter a Folder to extract file to.", "Folder missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim doc = New TheDocument()
                Try
                    Dim server As New TheServer()
                    server.Connect(TheClientType.CustomApplication)
                    'first retrieve the document. 
                    'the document will be saved into a temporary file on the hard drive
                    'the full path to the temporary file will be memorized in strTheDoc
                    Dim strTheDoc As String = doc.Retrieve(Int32.Parse(mtbDocNo.Text), "", server)
                    'and then extract all files from the document to the desired path
                    For i As Integer = 0 To doc.StreamCount - 1
                        doc.ExtractStream(i, txtExtractPath.Text)
                    Next i

                    'do also not forget to delete the temporary document file on the hard drive
                    File.Delete(strTheDoc)
                    MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    doc.Dispose() 'cleanup document. Dispose will delete internal temporary files.
                End Try

            End If

		End Sub

		Private Sub btnView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnView.Click
			If mtbDocNo.Text = "" Then
				MessageBox.Show("Please enter a DocNo to retrive.", "DocNo missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Else
				Try
					Dim server As New TheServer()
					server.Connect(TheClientType.CustomApplication)
					Dim doc As New TheDocument()
					'first retrieve the document. 
					doc.Retrieve(Int32.Parse(mtbDocNo.Text), "", server)
                    'to open a document in the Viewer just call the View() method after retrieving the document
                    doc.View() 'the Viewer will delete the document
                Catch ex As Exception
					MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
				End Try
			End If
		End Sub

		Private Sub btnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExit.Click
			Application.Exit()
		End Sub

		Private Sub btnUpdateBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdateBrowse.Click
			openFileDialog1.ShowReadOnly = True
			openFileDialog1.Multiselect = False

			If System.Windows.Forms.DialogResult.OK = openFileDialog1.ShowDialog(Me) Then
				txtUpdatePath.Text = openFileDialog1.FileName
			End If
		End Sub

		Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
            If mtbDocNo.Text = "" Then
                MessageBox.Show("Please enter a DocNo to retrieve.", "DocNo missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf txtUpdatePath.Text = "" Then
                MessageBox.Show("Please enter a File to add to existing The Document.", "Folder missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim doc As New TheDocument()
                Try
                    Dim strUser As String = ""
                    Dim nVersionNo As Integer = 0

                    Dim server As New TheServer()
                    server.Connect(TheClientType.CustomApplication)
                    'first retrieve the document. 
                    'the document will be saved into a temporary file on the hard drive
                    'the full path to the temporary file will be memorized in strTheDoc
                    Dim strTheDoc As String = doc.Retrieve(Int32.Parse(mtbDocNo.Text), "", server)
                    'open the document and do a checkout
                    'you need to do a checkout to update a document
                    doc.Open(strTheDoc, 0)
                    doc.CheckOut(server, 0, strUser, nVersionNo)
                    If strUser <> "" Then
                        MessageBox.Show("Document is checked out by: " & strUser, "Checked Out", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ElseIf nVersionNo <> 0 Then
                        MessageBox.Show("A newer version exists with DocNo = " & nVersionNo.ToString(), "Newer Version", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        'you have to set the category so you can use the IndexData properly
                        doc.IndexData.SetCategory("Files", server)
                        'now you can change IndexData...
                        doc.IndexData("Filename") = doc.IndexData("Filename").ToString() & " - updated"
                        '... and add a file to the document
                        doc.AddStream(txtUpdatePath.Text, Path.GetFileName(txtUpdatePath.Text), 0)
                        'when the changes are complete archive the document to the system
                        doc.CheckIn(server, "Modified by SDK sample")
                        MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    doc.Dispose() 'cleanup document. Dispose will delete internal temporary files.
                End Try
			End If
		End Sub
	End Class
End Namespace