Imports System.Configuration
Imports System.Collections
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Therefore.API
Imports System.IO

Namespace TheAPIWeb
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub btnView_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim nResult As Integer = 0
            If txtDocNo.Text = "" Then
                Response.Write("Please enter a valid DocNo.")
            ElseIf Not Int32.TryParse(txtDocNo.Text, nResult) Then
                Response.Write("Please enter a valid DocNo.")
            Else
                Dim doc As New TheDocument()
                Try
                    Dim server As New TheServer()
                    server.Connect(TheClientType.CustomApplication)
                    'first retrieve the document. 
                    'the document will be saved into a temporary file on the hard drive
                    'the full path to the temporary file will be memorized in strTheFile
                    Dim strTheFile As String = doc.Retrieve(Int32.Parse(txtDocNo.Text), "", server)
                    Dim strDoc As String = ""
                    'and then extract all files from the document to the Temp folder
                    For i As Integer = 0 To doc.StreamCount - 1
                        'memorize path and file name of the last file in the document
                        strDoc = doc.ExtractStream(i, Path.GetTempPath())
                    Next i

                    Dim downloadFile As New FileInfo(strDoc)

                    'build the response to the client
                    Response.Expires = -1
                    Response.ContentType = "application/octet-stream"
                    Response.AddHeader("Content-Disposition", "attachment; filename = " & downloadFile.Name)
                    Response.AddHeader("Content-Length", downloadFile.Length.ToString())
                    Response.Flush()
                    'and deliver the file
                    Response.WriteFile(strDoc)
                Catch ex As Exception
                    Response.Write(ex.ToString())
                Finally
                    doc.Dispose()
                End Try
			End If
		End Sub
	End Class
End Namespace