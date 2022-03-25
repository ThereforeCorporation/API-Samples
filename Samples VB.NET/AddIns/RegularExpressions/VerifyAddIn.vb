Imports System.Text
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Runtime.InteropServices
Imports Therefore.API

Namespace AddInSamples
	<Guid("CC500130-1236-4a6b-A98E-F5375506F5A4"), ComVisible(True), ClassInterface(ClassInterfaceType.None)> _
	Public Class VerifyAddIn
		Implements ITheAddIn
		Private Const regexNonDigits As String = "[^0-9]"
		Private Const regexEmailAddress As String = "^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"

		Private validInvoiceNo As Boolean = True
		Private validInvDate As Boolean = True
		Private validInfo As Boolean = True

		Public Sub GetHandledEvents(ByVal clientType As TheClientType, ByVal eventSet As TheEventSet) Implements ITheAddIn.GetHandledEvents
			' Register to receive the CategoryFieldChanged event
			eventSet.Add(TheEventType.CategoryFieldChanged)
		End Sub

		Public Function HandleEvent(ByVal e As TheEvent) As Integer Implements ITheAddIn.HandleEvent
			' Extract necessary info from the event (for convenience only)
			Dim dlg As TheCategoryDialog = e.CategoryDialog
			Dim fieldNo As Integer = e.ObjectID
			Dim fieldName As String = e.ObjectName
			Dim val As Object = e.IndexData.GetValueByFieldNo(fieldNo)

			If fieldName = "InvoiceNo" Then ' InvoiceNo field has changed
				' The InvoiceNo must be empty or contain only digits
				validInvoiceNo = (val Is Nothing OrElse Not(TypeOf val Is String) OrElse Regex.Match(CStr(val), regexNonDigits).Length = 0)

				' update the background color of the field, set/reset the tool tip and enable/disable the "Execute" button
				MarkValid(dlg, fieldNo, validInvoiceNo, "InvoiceNo can only contain digits (0-9)")
			ElseIf fieldName = "InvDate" Then ' Date field has changed
				' The Date field must not contain a date in the future
				validInvDate = (val Is Nothing OrElse Not(TypeOf val Is Date) OrElse CDate(val) <= Date.Now)

				' update the background color of the field, set/reset the tool tip and enable/disable the "Execute" button
				MarkValid(dlg, fieldNo, validInvDate, "Date must not be in the future")
			ElseIf fieldName = "Info" Then ' Info field has changed
				' The Info field must be empty or contain a valid email address
				validInfo = (val Is Nothing OrElse Not(TypeOf val Is String) OrElse Regex.Match(CStr(val), regexEmailAddress).Length > 0)

				' update the background color of the field, set/reset the tool tip and enable/disable the "Execute" button
				MarkValid(dlg, fieldNo, validInfo, "Info must be empty or contain a valid email address")
			End If

			Return 0
		End Function

		Private Sub MarkValid(ByVal dlg As TheCategoryDialog, ByVal fieldNo As Integer, ByVal valid As Boolean, ByVal errMsg As String)
			If valid Then ' Field is valid
				' Remove the red marks from all fields (if any)
				dlg.ResetBackgroundColor(fieldNo)

				' Remove the error tool tip (if any)
				dlg.ResetToolTip(fieldNo)
			Else ' Field is invalid
				' Mark the field red
				dlg.SetBackgroundColor(fieldNo, 255, 0, 0)

				' Set the tool tip for the field (to explain why it is invalid)
				dlg.SetToolTip(fieldNo, errMsg)
			End If

			' Enable the "Execute" button if (and only if) all checked fields are valid
			dlg.EnableButton(TheButtonID.ExecuteButton, (validInvDate AndAlso validInvoiceNo AndAlso validInfo))
		End Sub
	End Class
End Namespace
