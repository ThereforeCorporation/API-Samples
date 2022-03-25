Imports System.ComponentModel
Imports System.ServiceProcess
Imports System.Text
Imports Therefore.API
Imports System.IO
Imports System.Timers

Namespace ServiceSample
    Partial Friend Class ServiceSample
        Inherits ServiceBase
        Private timer As New Timer()

        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overrides Sub OnStart(ByVal args() As String)
            ProcessHotFolder()
            AddHandler timer.Elapsed, AddressOf timer_Elapsed
            timer.Interval = 6000
            timer.Enabled = True
        End Sub

        Private Sub timer_Elapsed(ByVal sender As Object, ByVal e As ElapsedEventArgs)
            ProcessHotFolder()
        End Sub

        Protected Overrides Sub OnStop()
            ' TODO: Add code here to perform any tear-down necessary to stop your service.
        End Sub

        Private Sub ProcessHotFolder()
            Dim strDir As String = "d:\HotFolder"
            Try
                'create a log entry for information purpose
                EventLog.WriteEntry(ServiceName, "ProcessHotFolder called.", EventLogEntryType.Information)
                ArchiveAll(strDir)
            Catch ex As Exception
                EventLog.WriteEntry(ServiceName, ex.ToString(), EventLogEntryType.Error)
            End Try
        End Sub

        Private Sub ArchiveAll(ByVal strDir As String)
            Dim server As New TheServer()
            server.Connect(TheClientType.CustomApplication, "Administrator", "The")

            'we do not only want to save all files in a directory
            'but in the subdirectories as well
            For Each strSubDir As String In Directory.GetDirectories(strDir)
                ArchiveAllFiles(strSubDir, server)
            Next strSubDir
            ArchiveAllFiles(strDir, server)
            server.Disconnect(True)
        End Sub

        Private Sub ArchiveAllFiles(ByVal strSubDir As String, ByVal server As TheServer)

            Dim doc As New TheDocument()
            Try
                For Each strFile As String In Directory.GetFiles(strSubDir)
                    Dim strFileName As String = Path.GetFileName(strFile)
                    Dim strExt As String = Path.GetExtension(strFile)
                    Dim strFromFolder As String = Path.GetDirectoryName(strFile)
                    Dim strTheFile As String = ""
                    'in this file the Therefore document data will be stored temporarily
                    doc = New TheDocument()
                    'create the temporary Therefore file
                    doc.Create(strTheFile)
                    'add a file to the document
                    doc.AddStream(strFile, strFileName, 0)
                    doc.IndexData.SetCategory("Files", server)

                    'set the category you want to add the document to
                    doc.IndexData.SetCategory("Files", server)

                    'add the index data to the document
                    doc.IndexData("Filename") = strFileName
                    doc.IndexData("From_Folder") = strFromFolder
                    doc.IndexData("Extension") = strExt
                    doc.IndexData("Creation_Date") = File.GetCreationTime(strFile)
                    'the archive command sends the document the Therefore server and archives it
                    'doesn't allow to display a dialog if necessary (will result in exception instead)
                    'doesn't reload the document. By default Archive reloads the document but deleting it right afterwards from disk makes this unnecessary
                    doc.Archive(server, 0, "", False, False)
                    doc.Dispose()
                    doc = Nothing 'set to nothing. otherwise Dispose will be called in the finally block again causing an error

                    'when the document has been archived delete the temporary file
                    File.Delete(strFile)
                Next strFile
            Catch
                'add some exception handling code like logging to event log
            Finally
                If doc Is Nothing Then
                    doc.Dispose()
                End If
            End Try
        End Sub
    End Class
End Namespace
