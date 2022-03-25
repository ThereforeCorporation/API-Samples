Imports System.ComponentModel
Imports System.Text
Imports Therefore.API

Namespace Capture
	Partial Public Class CaptureForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private nDocCounter As UInteger

		Private Sub btnScan_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnScan.Click
			Try
				'first establish server connection
				Dim server As New TheServer()
				server.Connect(TheClientType.CaptureClient)

				'and load the category
				Dim ixData As New TheIndexData()
				ixData.SetCategory("Files", server)
				'fill the category fields with values
				'these values will be transported to the capture client
				If Me.txtFilename.Text = "" Then
					ixData("Filename") = "Scanned File No. " & Me.nDocCounter.ToString()
				Else
					ixData("Filename") = Me.txtFilename.Text
				End If

				If Me.txtFilename.Text = "" Then
					ixData("From_Folder") = "Scanner"
				Else
					ixData("From_Folder") = Me.txtFolder.Text
				End If

				ixData("Creation_Date") = Date.Today
				ixData("Extension") = "tiff"

				'create a new TheApplication instance
				Dim app As New TheApplication()
				'and call it with the wanted options
				'if you want to change the capture profile go to TheDesigner and look up the profile number
				If Me.ckbInstantArchive.Checked Then
					app.CaptureScan(ixData, 0, TheCaptureScanFlags.CaptureArchive, CInt(Me.Handle))
				Else
					app.CaptureScan(ixData, 0, TheCaptureScanFlags.CaptureSinglePage, CInt(Me.Handle))
				End If

				'don't forget to disconnect
				server.Disconnect()
				Me.nDocCounter += 1
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btnArchive_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnArchive.Click
			Try
				'first establish server connection
				Dim server As New TheServer()
				server.Connect(TheClientType.CaptureClient)

				'the category must be loaded for archiving
				Dim ixData As New TheIndexData()
				ixData.SetCategory("Files", server)

				'create a TheApplication instance
				Dim app As New TheApplication()
				'and archive the document
				app.CaptureArchive(ixData, TheCaptureArchiveFlags.ArchiveSingleDoc, CInt(Me.Handle))

				'don't forget to disconnect
				server.Disconnect()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		'ERROR HANDLING

		' taken
		Private Const WM_USER As Integer = &H400
		Private Const PM_REMOTE_NOTIFY As Integer = WM_USER + 22
		Private Const TWNOTIFY_COMPLETED As UInteger = &H80000000L
		Private Const TWNOTIFY_DOCARCHIVE As UInteger = &H10000000
		Private Const TWERR_NOITEMSEL As UInteger = &H103E9
		Private Const TWERR_NOTONEDOC As UInteger = &H103EA
		Private Const TWERR_NOTREADYARCH As UInteger = &H103EB
		Private Const TWERR_ALREADYARC As UInteger = &H103EC
		Private Const TWERR_ABORT As UInteger = &H103ED
		' own
		Private Const TW_SCAN_STARTED As UInteger = &H20000000
		Private Const TW_SCAN_ABORTED As UInteger = &H40000000

		Protected Overrides Sub WndProc(ByRef m As Message)
			Select Case m.Msg
				Case PM_REMOTE_NOTIFY 'Therefore Capture Client Notification
					Dim wParam As UInteger = CUInt(m.WParam)
					Dim lParam As UInteger = CUInt(m.LParam)
					'was archived

					If wParam = TW_SCAN_STARTED Then
					End If

					If wParam = TWNOTIFY_COMPLETED Then
						If lParam = TWERR_NOTONEDOC Then
						ElseIf lParam = TWERR_ALREADYARC Then
						ElseIf lParam = TWERR_NOITEMSEL Then
						ElseIf lParam = TWERR_ABORT Then
						ElseIf lParam = TWERR_NOTREADYARCH Then
						End If
					End If

					If wParam = TW_SCAN_ABORTED Then
						MessageBox.Show("An error occurred during the scanning process.")
					End If

					If wParam = TWNOTIFY_DOCARCHIVE Then
						MessageBox.Show("Document archived.")
					End If
				Case Else
					MyBase.WndProc(m)
			End Select
		End Sub
	End Class
End Namespace
