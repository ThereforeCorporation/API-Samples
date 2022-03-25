Imports System.Collections
Imports System.Text
Imports System.IO
Imports Therefore.API
Imports System.Runtime.InteropServices

Namespace WFExtractFiles
	<Guid("E9D3A6F3-2FF0-4357-B7CD-78A1FA99207B"), ComVisible(True)> _
	Public Class WFExtractFiles
		Implements Therefore.AddIn.ITheWorkflowAutomaticTask
		#Region "ITheWorkflowAutomaticTask Members"

		Protected objLog As EventLog = Nothing


		Public Sub New()
			objLog = New EventLog("Application", ".", "Therefore-WF")
		End Sub

		Public Function ShowSettingsDlg(ByVal nObjectID As Integer, ByVal nObjectType As Integer, ByVal bstrTenant As String, ByVal strParams As String) As String Implements Therefore.AddIn.ITheWorkflowAutomaticTask.ShowSettingsDlg
			'look into the API manual for TheObjectType enumeration for further reference to nObjectType
			Dim paramDialog As New ParamDialog()
			paramDialog.Path = strParams
			paramDialog.ShowDialog()
			If paramDialog.DialogResult = DialogResult.OK Then
				Return paramDialog.Path
			End If
			Return strParams
		End Function

		Public Sub ProcAutomaticInst(ByVal nInstanceNo As Integer, ByVal nTokenNo As Integer, ByVal bstrTenant As String, ByVal strParams As String) Implements Therefore.AddIn.ITheWorkflowAutomaticTask.ProcAutomaticInst
            Dim theDoc As TheDocument = Nothing
            Dim fileStream As FileStream = Nothing
            Dim streamWriter As StreamWriter = Nothing
            Try
                Dim server As New TheServer()
                server.Connect(TheClientType.CustomApplication)

                'create a TheWFInstance object and load the workflow item by using the instance number
                Dim wfInstance As New TheWFInstance()
                wfInstance.Load(server, nInstanceNo)

                'the GetLinkedDocAt method gives back the document number 
                'of the document this workflow item belongs to
                Dim wfDoc As TheWFDocument = wfInstance.GetLinkedDocAt(0)

                'with the document number you can retrieve the document
                theDoc = New TheDocument()
                Dim strTheDoc As String = theDoc.Retrieve(wfDoc.DocNo, "", server)

                'extract the files to the configured path
                Dim extractPath As String = strParams
                For i As Integer = 0 To theDoc.StreamCount - 1
                    theDoc.ExtractStream(i, extractPath)
                Next i

                'write Index Data to textfile
                fileStream = New FileStream(extractPath & theDoc.IndexData.CtgryName & theDoc.IndexData.DocNo & ".txt", FileMode.Create)
                streamWriter = New StreamWriter(fileStream)

                Dim names As New List(Of String)()
                Dim values As New List(Of String)()

                For Each name As String In theDoc.IndexData.FieldNames
                    names.Add(name)
                Next name

                For Each value As Object In theDoc.IndexData.Values
                    values.Add(Convert.ToString(value))
                Next value

                For i As Integer = 0 To names.Count - 1
                    streamWriter.WriteLine(names(i) & ": " & values(i))
                Next i
                streamWriter.Flush()
                'get the next task in the workflow and finish the current task
                Dim wfTask As TheWFTask = wfInstance.GetNextTaskAt(0)
                wfInstance.ClaimInstance(server)
                wfInstance.FinishCurrentTask(server, wfTask.TaskNo, "")
            Catch ex As System.Exception
                HandleError(ex, "")
                Throw ex 'throwing an unhandled exception here will result in the error being listed in the Navigator
                'if everything is handled here, the error will not be listed as error in the Navigator
            Finally
                If theDoc IsNot Nothing Then
                    theDoc.Dispose() ' Dispose will delete internal temporary files.
                End If
                If streamWriter IsNot Nothing Then
                    streamWriter.Close()
                End If
                If fileStream IsNot Nothing Then
                    fileStream.Close()
                End If
            End Try
        End Sub

		Protected Sub HandleError(ByVal e As Exception, ByVal strMessage As String)
			Dim strTempMessage As String = FormatMessage(e, strMessage)
			Try
				objLog.WriteEntry(strTempMessage, EventLogEntryType.Error)
			Catch e1 As Exception 'ignore
			End Try
		End Sub

		Private Function FormatMessage(ByVal ex As Exception, ByVal strInsertText As String) As String
			Dim sNewMessage As New StringBuilder()
			Dim sErrorStack As String = Nothing

			' get the error stack, if InnerException is null,
			' sErrorStack will be "exception was not chained" and
			' should never be null
			sErrorStack = BuildErrorStack(ex.InnerException)

			sNewMessage.AppendLine(ex.Message)
			sNewMessage.AppendLine("Exception: " & ex.GetType().ToString())
			sNewMessage.AppendLine("Application: " & Process.GetCurrentProcess().ProcessName.Replace(".vshost", ""))
			sNewMessage.AppendLine("Source: " & ex.Source)
			sNewMessage.AppendLine("User name: " & System.Security.Principal.WindowsIdentity.GetCurrent().Name)
			If strInsertText IsNot Nothing AndAlso strInsertText <> "" Then
				sNewMessage.AppendLine()
				sNewMessage.AppendLine("Additional Information: ")
				sNewMessage.AppendLine("   " & strInsertText)
			End If
			sNewMessage.AppendLine()
			sNewMessage.AppendLine("Stack Trace:")
			sNewMessage.AppendLine(ex.StackTrace)

			If sErrorStack <> "" Then
				sNewMessage.AppendLine(sErrorStack)
			End If

			Return sNewMessage.ToString().Trim()
		End Function

		Private Function BuildErrorStack(ByVal oChainedException As Exception) As String
			Dim sErrorStack As String = Nothing
			Dim sbErrorStack As New StringBuilder()
			Dim nErrStackNum As Integer = 1
			Dim oInnerException As System.Exception = Nothing

			If oChainedException IsNot Nothing Then
				sbErrorStack.Append(vbLf & "Additional Error Information:" & vbLf & vbLf & "Error Stack: " & vbLf)

				oInnerException = oChainedException
				Do While oInnerException IsNot Nothing
					sbErrorStack.Append(nErrStackNum).Append(") ").Append(oInnerException.Message).Append(vbLf)

					oInnerException = oInnerException.InnerException

					nErrStackNum += 1
				Loop
				sbErrorStack.Append(vbLf & "Stack Trace:" & vbLf).Append(oChainedException.StackTrace)

				sErrorStack = sbErrorStack.ToString()
			Else
				sErrorStack = ""
			End If
			Return sErrorStack
		End Function
		#End Region
	End Class
End Namespace
