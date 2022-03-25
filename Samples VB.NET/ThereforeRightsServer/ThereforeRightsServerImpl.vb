Imports System.Text
Imports Microsoft.Win32
Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Imports Therefore.API

Namespace Therefore
	<ComVisible(True), Guid("0FE54A12-5FFD-4b69-A287-4F16CA3BD7C5")> _
	Public Class ThereforeRightsServerImpl
		Implements Therefore.AddIn.ITheRightsServer
		Protected objLog As EventLog = Nothing
		Private Shared ReadOnly registryRootServer As String = "SOFTWARE\Therefore\Server"

		Private strDBServer As String = ""
		Private strDBName As String = ""

		Private Shared RIGHT_GRANT As Integer = 1
		Private Shared RIGHT_REVOKE As Integer = 2
		Private Shared RIGHT_DEFAULT As Integer = 9

		Public Sub New()
			objLog = New EventLog("Application", ".", "TheRights")

			Try
				'get the therefore database name from registry
				Dim regMachine As RegistryKey = Registry.LocalMachine
				regMachine = regMachine.OpenSubKey(registryRootServer)
				If regMachine Is Nothing Then
					Throw New Exception("Could not open Registry Key: HKEY_LOCAL_MACHINE\" & registryRootServer)
				End If

				Dim objVal As Object = ReadRegistryValue(regMachine, "DBName", True)
				Dim strDBPath As String = objVal.ToString()
				Dim arrDBVals() As String = strDBPath.Split("/"c)
				If arrDBVals.Length = 0 Then
					Throw New Exception("Invalid Database Configuration String: " & strDBPath)
				End If

				If arrDBVals.Length = 1 Then
					'if the database server is located on the therefore server you can use this
					strDBServer = Environment.MachineName
					strDBName = arrDBVals(0)
				Else
					'otherwise you also have to get the database server name from the registry
					strDBServer = arrDBVals(0)
					strDBName = arrDBVals(1)
				End If
			Catch e As Exception
				HandleError(e, "Constructor failed.")
			End Try
		End Sub

		Protected Function GetCtgryNoFromDoc(ByVal nDocNo As Integer) As Integer
			Dim nCtgryNo As Integer = 0
			Dim nVersionNo As Integer = 0
			Dim dataReader As SqlDataReader = Nothing
			Dim strSQLConnectionString As String = String.Empty

			Try
				'create a connection string with the information gathered from the registry
				If strSQLConnectionString = "" Then
					strSQLConnectionString = "server=" & strDBServer & ";database=" & strDBName & ";Trusted_Connection=yes"
				End If

				'then open a connection
				Using sqlConn As New SqlConnection(strSQLConnectionString)
					sqlConn.Open()
					'and create your SqlCommand
					Dim sqlCommand As New SqlCommand()
					sqlCommand.Connection = sqlConn
					sqlCommand.CommandType = System.Data.CommandType.Text

					'first we need to know which version number is the last/newest one
					sqlCommand.CommandText = "Select VersionNo from TheDocument where DocNo = " & nDocNo.ToString() & " ORDER BY VersionNo DESC"
					'execute the command. if the command is not correct, an exception will be thrown
					dataReader = sqlCommand.ExecuteReader()
					'get the value from the result
					If dataReader.HasRows AndAlso dataReader.Read() Then
						nVersionNo = CInt(Fix(dataReader.GetValue(0)))
					End If
					'you have to close the SqlDataReader to use it again
					dataReader.Close()
					'create another command. this time we will get the category number from the last version
					'of the document
					sqlCommand.CommandText = "Select CtgryNo from TheDocVersion where DocNo = " & nDocNo.ToString() & "AND VersionNo = " & nVersionNo.ToString()
					dataReader = sqlCommand.ExecuteReader()
					If dataReader.HasRows AndAlso dataReader.Read() Then
						'be careful when casting values from the SqlDataReader
						'casting a smallint field in the database to an int will end in an exception
						nCtgryNo = CShort(Fix(dataReader.GetValue(0)))
					End If
				End Using
			Catch e As Exception
				HandleError(e, "GetCtgryNoFromDoc failed! Have you already imported the category?")
			Finally
				'always close the SqlDataReader
				If dataReader IsNot Nothing Then
					dataReader.Close()
				End If
			End Try
			Return nCtgryNo
		End Function

		Protected Function GetCtgryNoFromName(ByVal strCtgryName As String) As Integer
			Dim nCtgryNo As Integer = 0
			Dim dataReader As SqlDataReader = Nothing
			Dim strSQLConnectionString As String = String.Empty

			Try
				'create a connection string with the information gathered from the registry
				If strSQLConnectionString = "" Then
					strSQLConnectionString = "server=" & strDBServer & ";database=" & strDBName & ";Trusted_Connection=yes"
				End If

				'then open a connection
				Using sqlConn As New SqlConnection(strSQLConnectionString)
					sqlConn.Open()
					'and create your SqlCommand
					Dim sqlCommand As New SqlCommand()
					sqlCommand.Connection = sqlConn
					sqlCommand.CommandType = System.Data.CommandType.Text

					'first we need to know which version number is the last/newest one
					sqlCommand.CommandText = "Select CtgryNo from TheCategory where Name = '" & strCtgryName & "'"
					'execute the command. if the command is not correct, an exception will be thrown
					dataReader = sqlCommand.ExecuteReader()
					'get the value from the result
					If dataReader.HasRows AndAlso dataReader.Read() Then
						nCtgryNo = CInt(Fix(dataReader.GetValue(0)))
					End If
				End Using
			Catch e As Exception
				HandleError(e, "GetCtgryNoFromName failed! Have you already imported the category?")
			Finally
				'always close the SqlDataReader
				If dataReader IsNot Nothing Then
					dataReader.Close()
				End If
			End Try
			Return nCtgryNo
		End Function

		Protected Function GetCtgryRight(ByVal nCtgryNo As Integer, ByVal sUser As TheUserStruct) As Integer
			'check the category and user and return the right the user has in this category
			'and he shall only get the permission during office time (between 8:00 and 18:00)
			If nCtgryNo = 4 AndAlso sUser.nUserNo = 9 AndAlso Date.Now.Hour > 7 AndAlso Date.Now.Hour < 18 Then
				Return RIGHT_GRANT
			End If
			Return RIGHT_REVOKE
		End Function

		''' <summary>
		''' Read a Registry Value.
		''' </summary>
		''' <param name="regKey">Open Registry Key</param>
		''' <param name="strValue">Name of the Value</param>
		''' <param name="bMandatory">If true, Exception is thrown if missing, else returns null.</param>
		''' <returns>Value of the RegKey</returns>
		Protected Function ReadRegistryValue(ByVal regKey As RegistryKey, ByVal strValue As String, ByVal bMandatory As Boolean) As Object
			If regKey Is Nothing Then
				Throw New Exception("Invalid Registry Key provided.")
			End If

			Dim objVal As Object = regKey.GetValue(strValue)
			If objVal Is Nothing AndAlso bMandatory Then
				Throw New Exception("Could not read Registry Value: " & regKey.ToString() & "\" & strValue)
			End If

			Return objVal
		End Function

		''' <summary>
		''' Handle an Exception - create good Error Message
		''' </summary>
		''' <param name="e">Exception that was thrown</param>
		''' <param name="strMessage">Message to add to the output</param>
		Protected Sub HandleError(ByVal e As Exception, ByVal strMessage As String)
			Dim strTempMessage As String = FormatMessage(e, strMessage)
			Try
				objLog.WriteEntry(strTempMessage, EventLogEntryType.Error)
			Catch e1 As Exception 'ignore
			End Try
		End Sub

		''' <summary>
		''' Format the Exception for logging 
		''' </summary>
		''' <param name="ex">Exception to format</param>
		''' <param name="strInsertText">Additional Information to add to Error Message</param>
		''' <returns>Formated Output Message</returns>
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


		''' <summary>
		''' Format the chain of Inner Exceptions for display / logging
		''' </summary>
		''' <param name="oChainedException">Inner Exception to start from</param>
		''' <returns></returns>
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

		#Region "IThereforeRightsServer Members"

        Public Function AllowArchive(ByVal vUser As Object, ByVal vIxData As Object, ByVal nOldDocNo As Integer) As Integer Implements Therefore.AddIn.ITheRightsServer.AllowArchive
            Dim nRight As Integer = RIGHT_REVOKE
            Try
                'do not check for new documents
                If nOldDocNo = 0 Then
                    nRight = RIGHT_GRANT
                Else
                    Dim sUser As New TheUserStruct(vUser)
                    Dim nCtgryNo As Integer = GetCtgryNoFromDoc(nOldDocNo)
                    nRight = GetCtgryRight(nCtgryNo, sUser)
                End If
            Catch e As Exception
                HandleError(e, "AllowArchive failed.")
            End Try
            Return nRight
        End Function

        Public Function AllowCheckout(ByVal vUser As Object, ByVal nDocNo As Integer) As Integer Implements Therefore.AddIn.ITheRightsServer.AllowCheckout
            Dim nRight As Integer = RIGHT_REVOKE
            Try
                Dim sUser As New TheUserStruct(vUser)
                Dim nCtgryNo As Integer = GetCtgryNoFromDoc(nDocNo)
                nRight = GetCtgryRight(nCtgryNo, sUser)
            Catch e As Exception
                HandleError(e, "AllowCheckout failed.")
            End Try
            Return nRight
        End Function

        Public Function AllowDelete(ByVal vUser As Object, ByVal nDocNo As Integer) As Integer Implements Therefore.AddIn.ITheRightsServer.AllowDelete
            Throw New NotImplementedException()
        End Function

        Public Function AllowRetrieve(ByVal vUser As Object, ByVal nDocNo As Integer, <System.Runtime.InteropServices.Out()> ByRef pnStatus As Integer) As Integer Implements Therefore.AddIn.ITheRightsServer.AllowRetrieve
            Dim nRight As Integer = RIGHT_REVOKE
            pnStatus = 0
            Try
                Dim sUser As New TheUserStruct(vUser)
                Dim nCtgryNo As Integer = GetCtgryNoFromDoc(nDocNo)
                nRight = GetCtgryRight(nCtgryNo, sUser)
            Catch e As Exception
                HandleError(e, "AllowRetrieve failed.")
            End Try
            Return nRight
        End Function

        Public Sub GetDocRights(ByVal vUser As Object, ByVal nDocNo As Integer, <System.Runtime.InteropServices.Out()> ByRef pnRightsSrvMask As Integer, <System.Runtime.InteropServices.Out()> ByRef pnThereforeDBMask As Integer, <System.Runtime.InteropServices.Out()> ByRef pnDocStatus As Integer, <System.Runtime.InteropServices.Out()> ByRef pnCheckoutUserNo As Integer, <System.Runtime.InteropServices.Out()> ByRef pnCurDocNo As Integer) Implements Therefore.AddIn.ITheRightsServer.GetDocRights
            Throw New NotImplementedException()
        End Sub

        Public Function GetObjList(ByVal vUser As Object, ByVal nObjType As Integer, ByVal nAccessMask As Integer, <System.Runtime.InteropServices.Out()> ByRef pvaList As Object) As Integer Implements Therefore.AddIn.ITheRightsServer.GetObjList
            Throw New NotImplementedException()
        End Function

        Public Sub GetObjRights(ByVal vUser As Object, ByVal nObjType As Integer, ByVal nObjNo As Integer, ByVal nSubObjNo As Integer, <System.Runtime.InteropServices.Out()> ByRef pnRightsSrvMask As Integer, <System.Runtime.InteropServices.Out()> ByRef pnThereforeDBMask As Integer) Implements Therefore.AddIn.ITheRightsServer.GetObjRights
            Throw New NotImplementedException()
        End Sub

        Public Function GetObjRightsMap(ByVal vUser As Object, ByVal nObjType As Integer, <System.Runtime.InteropServices.Out()> ByRef pvaList As Object) As Integer Implements Therefore.AddIn.ITheRightsServer.GetObjRightsMap
            Throw New NotImplementedException()
        End Function

        Public Function HasPermission(ByVal vUser As Object, ByVal nObjType As Integer, ByVal nObjNo As Integer, ByVal nSubObjNo As Integer, ByVal nAccessMask As Integer) As Integer Implements Therefore.AddIn.ITheRightsServer.HasPermission
            Throw New NotImplementedException()
        End Function

        Public Function QueryValidation(ByVal vUser As Object, ByRef pvQueryDef As Object) As Integer Implements Therefore.AddIn.ITheRightsServer.QueryValidation
            Throw New NotImplementedException()
        End Function

		#End Region
	End Class
End Namespace
