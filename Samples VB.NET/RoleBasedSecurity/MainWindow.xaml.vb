Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports Therefore.API

Namespace RoleBasedSecurity
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Implements INotifyPropertyChanged
		Private _server As TheServer = Nothing
		Private _roles As TheFolderItemList = Nothing

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		Private _assignments As TheRoleAssignments = Nothing
		Public Property RoleAssignments() As ObservableCollection(Of TheRoleAssignment)

		Public Sub New()
			InitializeComponent()
			RoleAssignments = New ObservableCollection(Of TheRoleAssignment)()
			DataContext = Me
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				_server = New TheServer()
				_server.Connect()

				Dim folders As New TheFolderList()
				_roles = New TheFolderItemList()
				_server.GetObjects(TheObjectType.RoleObject, New TheAccessMask(), TheGetObjectFlags.GetNoFolders, _roles, folders)

				cmb_role.ItemsSource = _roles
			Catch ex As Exception
				MessageBox.Show(ex.Message)
				Close()
			End Try
		End Sub
		Private Sub Window_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
			If _server IsNot Nothing AndAlso _server.Connected Then
				_server.Disconnect()
			End If
		End Sub

		Private Sub btn_load_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim categoryNo As Integer = Convert.ToInt32(txt_categoryno.Text)
				_assignments = New TheRoleAssignments()
				_assignments.Load(TheObjectType.CategoryObject, categoryNo, 0, _server)
				ckb_inheritance.IsChecked = _assignments.Inherit
				UpdateRoleAssignments()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_showdialog_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				CheckRoleAssignments()

				'the dialog loads all role assignments from the server and saves all changes directly on the server when clicking OK.
				'data in object will be reloaded.
				_assignments.ShowDialog(_server)
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_add_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				CheckRoleAssignments()

				Dim role As TheFolderItem = CType(cmb_role.SelectedItem, TheFolderItem)
				If role Is Nothing Then
					Throw New Exception("No role has been selected.")
				End If
				Dim userNo As Integer = Convert.ToInt32(txt_userno.Text)

				_assignments.Add(userNo, role.ID, txt_condition.Text, _server)
				UpdateRoleAssignments()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub CheckRoleAssignments()
			If _assignments Is Nothing Then
				Throw New Exception("Role assignments have to be loaded first.")
			End If
		End Sub

		Private Sub btn_remove_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				CheckRoleAssignments()

				Dim assignment As TheRoleAssignment = CType(dg_roleassignments.SelectedItem, TheRoleAssignment)
				If assignment Is Nothing Then 'nothing is selected
					Return
				End If

				Dim a As TheRoleAssignment = _assignments.Get(assignment.UserNo, assignment.RoleNo)
				_assignments.Remove(assignment.UserNo, assignment.RoleNo)
				UpdateRoleAssignments()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_condition_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				CheckRoleAssignments()

				Dim assignment As TheRoleAssignment = CType(dg_roleassignments.SelectedItem, TheRoleAssignment)
				If assignment Is Nothing Then 'nothing is selected
					Return
				End If

				Dim [error] As Boolean = False
				Dim tempCondition As String = assignment.Condition
				Do
					Dim dlg As New ChangeConditionWindow(tempCondition)
					dlg.Owner = Me
					If Not dlg.ShowDialog().Equals(True) Then
						Exit Do
					End If
					tempCondition = dlg.Condition
					Try
						assignment.SetCondition(dlg.Condition, _server)
					Catch ex As Exception
						MessageBox.Show(ex.Message)
						[error] = True
					End Try
				Loop While [error]
				dg_roleassignments.DataContext = Nothing
				dg_roleassignments.DataContext = Me
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub UpdateRoleAssignments()
			RoleAssignments.Clear()
			For Each a As TheRoleAssignment In _assignments
				RoleAssignments.Add(a)
			Next a
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("RoleAssignments"))
		End Sub

		Private Sub btn_save_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				CheckRoleAssignments()
				_assignments.SaveChanges(_server)
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub ckb_inheritance_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				CheckRoleAssignments()

				_assignments.EnableInheritance(_server)
				UpdateRoleAssignments()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub ckb_inheritance_Unchecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				CheckRoleAssignments()

				_assignments.DisableInheritance(True)
				UpdateRoleAssignments()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub
	End Class
End Namespace
