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
	''' Interaction logic for NewFieldWindow.xaml
	''' </summary>
	Partial Public Class NewFieldWindow
		Inherits Window
		Private _cat As TheCategory
		Private _casedef As TheCaseDefinition

		Public Sub New(ByVal cat As TheCategory)
			_cat = cat
			_casedef = Nothing
			InitializeComponent()
		End Sub

		Public Sub New(ByVal casedef As TheCaseDefinition)
			_cat = Nothing
			_casedef = casedef
			InitializeComponent()
		End Sub

		Private Sub btn_create_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			DialogResult = True
		End Sub

		Public ReadOnly Property TypeNo() As Integer
			Get
				Return Convert.ToInt32(txt_typeno.Text)
			End Get
		End Property

		Public ReadOnly Property FieldName() As String
			Get
				Return txt_name.Text
			End Get
		End Property

		Public ReadOnly Property BelongsTo() As Integer
			Get
				Return Convert.ToInt32(txt_belongsto.Text)
			End Get
		End Property

		Public ReadOnly Property BelongsToTable() As Integer
			Get
				Return Convert.ToInt32(txt_belongstotable.Text)
			End Get
		End Property

		Public ReadOnly Property IsCaseHeaderField() As Boolean
			Get
				Return ckb_iscasefield.IsChecked = True
			End Get
		End Property

		Private Sub dg_datatypes_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			Try
				Dim item As TheFolderItem = CType(dg_datatypes.SelectedItem, TheFolderItem)
				If item Is Nothing Then
					Return
				End If
				txt_typeno.Text = item.ID.ToString()
				txt_name.Text = item.Name & " ID"
				If _cat IsNot Nothing Then
					If _cat.BelongsToCaseDefinition = 0 Then
						Return
					End If
					Dim casedef As New TheCaseDefinition()
					Dim server As New TheServer()
					server.Connect(TheClientType.CustomApplication, "", "", "", "", True)
					casedef.Load(_cat.BelongsToCaseDefinition, server)
					If item.ID = casedef.TypeNo Then
						ckb_iscasefield.IsChecked = True
					Else
						ckb_iscasefield.IsChecked = False
					End If
				Else
					ckb_iscasefield.IsChecked = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim server As New TheServer()
				If Not server.Connected Then
					server.Connect(TheClientType.CustomApplication, "", "", "", "", True)
				End If
				Dim itemlist As New TheFolderItemList()
				Dim folderlist As New TheFolderList()
				server.GetObjects(TheObjectType.DataTypeObject, New TheAccessMask(), TheGetObjectFlags.GetNoFolders, itemlist, folderlist)
				Dim dictionarylist As New TheFolderItemList()
				server.GetObjects(TheObjectType.KeyDictObject, New TheAccessMask(), TheGetObjectFlags.GetNoFolders, dictionarylist, folderlist)
				For Each item As TheFolderItem In dictionarylist
					item.Data = CInt(Fix(TheTypeGroup.KeywordTypeGroup))
					Dim dict As New TheKeywordDictionary()
					dict.LoadByID(item.ID, server)
					item.ID = dict.SingleTypeNo
					itemlist.Add(item)
				Next item
				dg_datatypes.ItemsSource = itemlist
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
				Close()
			End Try
		End Sub

		Private Sub dg_datatypes_ContextMenuOpening(ByVal sender As Object, ByVal e As ContextMenuEventArgs)
			Try
				Dim item As TheFolderItem = CType(dg_datatypes.SelectedItem, TheFolderItem)
				If item Is Nothing Then
					cmn_columns.Visibility = Visibility.Hidden
					Return
				End If
				If item.Data = CInt(Fix(TheTypeGroup.KeywordTypeGroup)) OrElse item.Data = CInt(Fix(TheTypeGroup.StandardTypeGroup)) Then
					cmn_columns.Visibility = Visibility.Hidden
					Return
				End If
				Dim rt As New TheReferencedTable()
				Dim server As New TheServer()
				If Not server.Connected Then
					server.Connect(TheClientType.CustomApplication, "", "", "", "", True)
				End If
				rt.Load(item.ID, server)
				'List<TheReferencedTableColumn> columns = new List<TheReferencedTableColumn>();
				cmn_columns.Items.Clear()
				For i As Integer = 0 To rt.ColumnCount - 1
					Dim col As TheReferencedTableColumn = rt.GetColumn(i)
					If col.Name = rt.IndexColumn Then
						Continue For
					End If
					Dim mitem As New MenuItem()
					mitem.DataContext = col
					mitem.Header = col.Name
					AddHandler mitem.Click, AddressOf OnMenuItemClick
					cmn_columns.Items.Add(mitem)
					'columns.Add(rt.GetColumn(i));
				Next i
				'cmn_columns.ItemsSource = columns;
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub OnMenuItemClick(ByVal sender As Object, ByVal e As EventArgs)
			Try
				If sender Is Nothing Then
					Return
				End If
				Dim col As TheReferencedTableColumn = CType(CType(sender, MenuItem).DataContext, TheReferencedTableColumn)
				Dim item As TheFolderItem = CType(dg_datatypes.SelectedItem, TheFolderItem)
				Dim primaryfield As TheCategoryField = Nothing 'first get the primary field
				Dim count As Integer = 0
				If _cat IsNot Nothing Then
					count = _cat.FieldCount
				Else
					count = _casedef.FieldCount
				End If

				For i As Integer = 0 To count - 1
					Dim field As TheCategoryField = Nothing
					If _cat IsNot Nothing Then
						field = _cat.GetFieldByIndex(i)
					Else
						field = _casedef.GetFieldByIndex(i)
					End If
					If field.TypeNo = item.ID Then
						primaryfield = field
						Exit For
					End If
				Next i

				If primaryfield Is Nothing Then
					Throw New Exception("Primary field not added to category.")
				End If

				txt_typeno.Text = col.type.ToString()
				txt_name.Text = col.Name
				txt_belongsto.Text = primaryfield.FieldNo.ToString()
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub
	End Class
End Namespace
