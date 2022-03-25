Imports System.ComponentModel
Imports System.Text
Imports Therefore.API

Namespace AccessMask
	Partial Public Class AccessMaskForm
		Inherits Form
		Private _server As TheServer

		Public Sub New()
			InitializeComponent()
			_server = New TheServer()
			_server.Connect()
		End Sub

		Protected Overrides Sub Finalize()
			If _server.Connected Then
				_server.Disconnect()
			End If
		End Sub

		Private Sub AccesMaskForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Try
				Dim types() As String = System.Enum.GetNames(GetType(TheObjectType))
				cmb_objtype.Items.AddRange(types)
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_load_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_load.Click
			Try
				'load an object and perform 
				Dim type As TheObjectType = CType(System.Enum.Parse(GetType(TheObjectType), CStr(cmb_objtype.SelectedItem)), TheObjectType)
				Dim id As Integer = Convert.ToInt32(txt_objno.Text)
				Dim subid As Integer = Convert.ToInt32(txt_subobjno.Text)

				Dim mask As New TheAccessMask()
				mask = _server.GetObjectRightsEx(type, id, subid)

				txt_output.Text = mask.ToString() & vbCrLf
				txt_output.Text &= "Has Manage Link permission: " & mask.ContainsPermission(mask.PermissionConstants.DocumentManageLink).ToString() & vbCrLf
				mask.AddPermission(mask.PermissionConstants.DocumentManageLink)
				mask.RemovePermission(mask.PermissionConstants.DocumentPrint)
				txt_output.Text &= mask.ToString() & vbCrLf
				txt_output.Text &= "Has Manage Link permission: " & mask.ContainsPermission(mask.PermissionConstants.DocumentManageLink).ToString() & vbCrLf
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_am2pl_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_am2pl.Click
			Try
				Dim type As TheObjectType = CType(System.Enum.Parse(GetType(TheObjectType), CStr(cmb_objtype.SelectedItem)), TheObjectType)
				Dim id As Integer = Convert.ToInt32(txt_objno.Text)
				Dim subid As Integer = Convert.ToInt32(txt_subobjno.Text)

				Dim mask As New TheAccessMask()
				mask = _server.GetObjectRightsEx(type, id, subid)
				Dim permlist As IThePermissionList = New ThePermissionList()
				permlist.AddAccessMask(mask, True, False)

				txt_output.Text = CType(permlist, Object).ToString()
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_pl2am_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pl2am.Click
			Try
				Dim type As TheObjectType = CType(System.Enum.Parse(GetType(TheObjectType), CStr(cmb_objtype.SelectedItem)), TheObjectType)
				Dim id As Integer = Convert.ToInt32(txt_objno.Text)
				Dim subid As Integer = Convert.ToInt32(txt_subobjno.Text)

				Dim sec As New TheSecurity()
				sec.LoadObject(type, id, subid, _server)
				Dim user As TheUser = _server.GetConnectedUser(False)
				Dim permlist As ThePermissionList = sec.GetPermissions(user)
				If permlist Is Nothing Then
					txt_output.Text = "No permission list for logged in user."
					Return
				End If
				txt_output.Text = permlist.ToString() & vbCrLf & vbCrLf

				Dim allowmask As TheAccessMask = permlist.GetAsAccessMask(True, False)
				Dim denymask As TheAccessMask = permlist.GetAsAccessMask(False, True)
				Dim combinedmask As TheAccessMask = permlist.GetAsAccessMask(True, True)
				txt_output.Text &= "Allow " & allowmask.ToString() & vbCrLf
				txt_output.Text &= "Deny " & denymask.ToString() & vbCrLf
				txt_output.Text &= "Combined " & combinedmask.ToString() & vbCrLf
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_getobjects_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_getobjects.Click
			Try
				Dim type As TheObjectType = CType(System.Enum.Parse(GetType(TheObjectType), CStr(cmb_objtype.SelectedItem)), TheObjectType)
				Dim id As Integer = Convert.ToInt32(txt_objno.Text)
				Dim subid As Integer = Convert.ToInt32(txt_subobjno.Text)
				Dim itemlist As New TheFolderItemList()
				Dim folderlist As New TheFolderList()
				Dim mask As New TheAccessMask()
				mask.AddPermission(mask.PermissionConstants.DocumentManageLink)
				_server.GetObjects(type, mask, TheGetObjectFlags.GetNoFolders, itemlist, folderlist)

				txt_output.Text = itemlist.ToString()
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub
	End Class
End Namespace
