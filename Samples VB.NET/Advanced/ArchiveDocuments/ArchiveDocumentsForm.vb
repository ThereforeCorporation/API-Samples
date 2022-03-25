Imports System.ComponentModel
Imports System.Text
Imports Therefore.API
Imports System.IO

Namespace ArchiveDocuments
    Partial Class ArchiveDocuments
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBrowse.Click
            Dim dialog As New FolderBrowserDialog()
            dialog.RootFolder = Environment.SpecialFolder.Desktop
            If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                txtPath.Text = dialog.SelectedPath
            End If
        End Sub

        Private Sub btnStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStart.Click
            If txtPath.Text = "" Then
                MessageBox.Show("Please select a root directory.", "Root not selected.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Try
                    ArchiveAll(txtPath.Text)
                    MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Application.Exit()
        End Sub

        Private Sub ArchiveAll(ByVal strDir As String)
            Dim server As New TheServer()
            server.Connect(TheClientType.CustomApplication)

            'we do not only want to save all files in a directory
            'but in the subdirectories as well
            For Each strSubDir As String In Directory.GetDirectories(strDir)
                ArchiveAllFiles(strSubDir, server)
            Next strSubDir
            ArchiveAllFiles(strDir, server)
            server.Disconnect(True)
        End Sub

        Private Sub ArchiveAllFiles(ByVal strSubDir As String, ByVal server As TheServer)
            For Each strFile As String In Directory.GetFiles(strSubDir)
                Dim strFileName As String = Path.GetFileName(strFile)
                Dim strExt As String = Path.GetExtension(strFile).Remove(0, 1) 'remove dot
                Dim strFromFolder As String = Path.GetDirectoryName(strFile)
                Dim strThereforeFile As String = ""
                'in this file the Therefore document data will be stored temporarily

                Dim doc As New TheDocument()
                'create the temporary Therefore file
                doc.Create(strThereforeFile)
                'add a file to the document
                doc.AddStream(strFile, strFileName, 0)
                'set the category you want to add the document to
                doc.IndexData.SetCategory("Files", server)

                'add the index data to the document
                doc.IndexData("Filename") = strFileName
                doc.IndexData("From_Folder") = strFromFolder
                doc.IndexData("Extension") = strExt
                doc.IndexData("Creation_Date") = File.GetCreationTime(strFile)
                'the archive command sends the document the Therefore server and archives it
                doc.Archive(server, 0)
                doc.Dispose() ' Dispose will delete internal temporary files.
            Next strFile
        End Sub
    End Class
End Namespace