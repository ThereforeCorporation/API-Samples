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
	''' Interaction logic for NewCaseDefinitionWindow.xaml
	''' </summary>
	Partial Public Class NewCaseDefinitionWindow
		Inherits Window
		Public Property CaseDefinitionName() As String
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
				CaseDefinitionName = txt_name.Text
				Dim f As Folder = CType(cmb_folder.SelectedItem, Folder)
				FolderNo = f.FolderItem.FolderNo
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
	End Class
End Namespace