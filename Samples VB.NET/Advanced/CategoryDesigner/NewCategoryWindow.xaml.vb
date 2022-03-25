Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports Therefore.API

Namespace Therefore.Samples
	''' <summary>
	''' Interaction logic for NewCategoryWindow.xaml
	''' </summary>
	Partial Public Class NewCategoryWindow
		Inherits Window
		Public Property CaseDefNo() As Integer
		Public Property CategoryName() As String
		Public Property FolderNo() As Integer

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim server As New TheServer()
				If Not server.Connected Then
					server.Connect(TheClientType.CustomApplication, "", "", "", "", True)
				End If
				Dim itemlist As New TheFolderItemList()
				Dim folderlist As New TheFolderList()
				server.GetObjects(TheObjectType.CategoryObject, New TheAccessMask(), TheGetObjectFlags.GetAllFolders, itemlist, folderlist)
				Dim folder As New List(Of Folder)()
				For i As Integer = 0 To folderlist.Count - 1
					Dim f As TheFolder = folderlist(i)
					folder.Add(New Folder(f))
				Next i
				cmb_folder.ItemsSource = folder
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_create_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				CategoryName = txt_name.Text
				CaseDefNo = Convert.ToInt32(txt_case.Text)
				Dim f As Folder = CType(cmb_folder.SelectedItem, Folder)
				If CaseDefNo = 0 Then
					FolderNo = 0
				ElseIf f IsNot Nothing Then
					FolderNo = f.FolderItem.FolderNo
				End If
				DialogResult = True
				Close()
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_cancel_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				DialogResult = False
				Close()
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_browse_casedef_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim server As New TheServer()
				If Not server.Connected Then
					server.Connect(TheClientType.CustomApplication, "", "", "", "", True)
				End If
'INSTANT VB NOTE: The variable casedefno was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim casedefno_Renamed As Integer = server.ShowCaseDefinitionSelectionDialog()
				If casedefno_Renamed <= 0 Then
					Return
				End If
				txt_case.Text = casedefno_Renamed.ToString()
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub
	End Class

	Public Class Folder
		Private _folder As TheFolder

		Public Sub New(ByVal folder As TheFolder)
			_folder = folder
		End Sub

		Public ReadOnly Property DisplayName() As String
			Get
				Return _folder.FolderNo & " - " & _folder.Name
			End Get
		End Property

		Public ReadOnly Property FolderItem() As TheFolder
			Get
				Return _folder
			End Get
		End Property
	End Class
End Namespace