Imports System.ComponentModel
Imports System.Text
Imports Therefore.API

Namespace TableDataType
	Partial Public Class TableForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btn_load_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_load.Click
			Try
				If txt_docno.Text = "" Then
					MessageBox.Show("Please enter a valid document number.")
					Return
				End If
				Dim server As New TheServer()
				server.Connect()
				Dim docNo As Integer = Convert.ToInt32(txt_docno.Text)
				'retrieve the document
				Dim doc As New TheDocument()
				doc.Retrieve(docNo, "", server)
				Dim tableField As TheCategoryField = Nothing
				'find the first table data type
				For i As Integer = 0 To doc.IndexData.Category.FieldCount - 1
					Dim field As TheCategoryField = doc.IndexData.Category.GetFieldByIndex(i)
					If field.FieldType = TheCategoryFieldType.TableField Then
						tableField = field
						Exit For
					End If
				Next i

				If tableField Is Nothing Then 'stop if there is not table data type in this category
					MessageBox.Show("No table field found in this category.")
					Return
				End If

				'clear the datagridview from previous entries
				dgv_table_data.Rows.Clear()
				dgv_table_data.Columns.Clear()

				'next create the columns in the datagridview
				Dim fieldlist As TheObjectList = doc.IndexData.Category.GetTableFields(tableField.FieldNo)
				For i As Integer = 0 To fieldlist.Count - 1
'INSTANT VB NOTE: The variable tablefield was renamed since Visual Basic will not allow local variables with the same name as parameters or other local variables:
					Dim tablefield_Renamed As TheCategoryField = doc.IndexData.Category.GetFieldByFieldNo(CInt(Fix(fieldlist(i))))
					'create a new column in the datagridview
					dgv_table_data.Columns.Add(tablefield_Renamed.IndexDataFieldName, tablefield_Renamed.IndexDataFieldName)
				Next i

				'load the table data into the dedicated class
				Dim table As TheTableDataType = doc.IndexData.GetTableValue(tableField.FieldNo)

				'write the table data into the datagridview
				For i As Integer = 0 To table.RowCount - 1
					Dim rowID As Integer = dgv_table_data.Rows.Add()
					For j As Integer = 0 To fieldlist.Count - 1
						dgv_table_data.Rows(rowID).Cells(j).Value = Convert.ToString(table.GetValue(CInt(Fix(fieldlist(j))), i))
					Next j
				Next i
				doc.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_save_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_save.Click
			If dgv_table_data.Columns.Count <= 0 Then
				MessageBox.Show("A document needs to be loaded first.")
				Return
			End If

			Try
				'get the document again
				If txt_docno.Text = "" Then
					MessageBox.Show("Please enter a valid document number.")
					Return
				End If
				Dim server As New TheServer()
				server.Connect()
				Dim docNo As Integer = Convert.ToInt32(txt_docno.Text)
				'retrieve the document
				Dim doc As New TheDocument()
				doc.Retrieve(docNo, "", server)
				Dim tableField As TheCategoryField = Nothing
				'find the first table data type
				For i As Integer = 0 To doc.IndexData.Category.FieldCount - 1
					Dim field As TheCategoryField = doc.IndexData.Category.GetFieldByIndex(i)
					If field.FieldType = TheCategoryFieldType.TableField Then
						tableField = field
						Exit For
					End If
				Next i

				If tableField Is Nothing Then 'stop if there is not table data type in this category
					MessageBox.Show("No table field found in this category.")
					Return
				End If
				'get the table object
				Dim table As TheTableDataType = doc.IndexData.GetTableValue(tableField.FieldNo)
				'run through all rows in the datagridview
				For row As Integer = 0 To dgv_table_data.Rows.Count - 1
					'and all the columns
					For col As Integer = 0 To dgv_table_data.Columns.Count - 1
						'then simply set the value. new rows will be added to the table automatically
						table.SetValue(dgv_table_data.Columns(col).HeaderText, row, dgv_table_data.Rows(row).Cells(col).Value)
					Next col
				Next row

				'delete all rows that don't exist anymore
				If table.RowCount > dgv_table_data.Rows.Count-1 Then ' -1 because of the empty line that is displayed for creating new rows
					table.RemoveAt(dgv_table_data.Rows.Count - 1, table.RowCount - (dgv_table_data.Rows.Count - 1))
				End If

				'set the value table. if you don't do this the changes will not be saved
				doc.IndexData.SetTableValue(tableField.FieldNo, table)
				'save the changes
				doc.IndexData.SaveChanges(server)
				'and close the document
				doc.Close()

				MessageBox.Show("The values have been saved")
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub
	End Class
End Namespace
