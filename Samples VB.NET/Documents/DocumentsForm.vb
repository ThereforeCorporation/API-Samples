Imports System.ComponentModel
Imports System.Text
Imports Therefore.API

Namespace Documents
	Partial Public Class DocumentsForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private server As TheServer

        Private Sub btn_archive_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_archive.Click
            ' 2. Create a new Therefore™ Document
            Dim doc As New TheDocument()
            Try
                ' 3. Create temporary File
                Dim filename As String = ""
                doc.Create(filename)

                ' 4. Set Therefore™ Category by Name
                doc.IndexData.SetCategory("Files", server)

                ' 5. Add streams
                doc.AddStream("..\..\..\..\Sample Documents\HR (docx)\Contract of Employment.docx", "", 0)
                doc.AddStream("..\..\..\..\Sample Documents\HR (docx)\Company Policy.docx", "", 0)

                ' 6. Set index data
                Dim indexData As TheIndexData = doc.IndexData
                indexData("Filename") = "Contract of Employment.docx"
                indexData("From_Folder") = "Sample Documents"
                indexData("Extension") = "docx"
                indexData("Creation_Date") = Date.Now

                ' 7. Archive the document
                Dim nDocNo As Integer = doc.Archive(server, 0)

                ' 8A. Print a success message on the console
                'Console.WriteLine("Document successfully archived as " + nDocNo.ToString() + ".");
                ' 8B. Or display message with a MessageBox
                MessageBox.Show("Document successfully archived as " & nDocNo.ToString() & ".")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                doc.Dispose()
            End Try
		End Sub

        Private Sub btn_retrieve_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_retrieve.Click
            ' 2. Declare and initialize a new TheDocument instance.
            Dim doc As New TheDocument()
            Try
                ' 3. Retrieve the document from the server.
                Dim docNo As Integer = 1
                Dim filename As String = doc.Retrieve(docNo, "", server)

                ' 4A. Print a success message on the console.
                'Console.WriteLine("Successfully retrieved " + filename + ".");
                ' 4B. Or display message with a MessageBox
                MessageBox.Show("Successfully retrieved " & filename & ".")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                doc.Dispose()
            End Try
		End Sub

        Private Sub btn_extract_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_extract.Click
            ' 2. Declare and initialize a new Therefore™ document
            Dim doc As New TheDocument()
            Try
                ' 3. Retrieve the document from the server to the inbox
                Dim inbox As String = "C:\temp\"
                Dim docNo As Integer = 1
                Dim filename As String = doc.Retrieve(docNo, inbox, server)

                ' 4. Extract all file streams to the specified directory
                Dim extractDir As String = "C:\temp\"
                Dim output As String = String.Empty
                For i As Integer = 0 To doc.StreamCount - 1
                    Dim extractFile As String = doc.ExtractStream(i, extractDir)
                    output &= "File stream extracted to " & extractFile & vbCrLf
                Next i

                ' 5A. Print a success message on the console.
                'Console.WriteLine(output);
                ' 5B. Or display message with a MessageBox
                MessageBox.Show(output)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                doc.Dispose()
            End Try
		End Sub

		Private Sub btn_view_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_view.Click
			Try
				' 2. Declare and initialize a new Therefore document
				Dim doc As New TheDocument()

				' 3. Retrieve the document from the server to the inbox
				Dim docNo As Integer = 1
				Dim filename As String = doc.Retrieve(docNo, "", server)

                ' 4. Open the document in the Therefore Viewer.
                doc.View()
                'don't delete the document from disk here, the Viewer will do that if no target folder has been specified in doc.Retrieve
            Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub DocumentsForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Try
				' 1. Connect to the Therefore™ Server
				server = New TheServer()
				server.Connect(TheClientType.CustomApplication)
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub DocumentsForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			server.Disconnect()
		End Sub
	End Class
End Namespace
