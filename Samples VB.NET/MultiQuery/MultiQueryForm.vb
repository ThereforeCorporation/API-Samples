Imports System.ComponentModel
Imports System.Text
Imports Therefore.API

Namespace MultiQuery
	Partial Public Class MultiQueryForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private server As TheServer
		Private multiResult As TheMultiQueryResult

		Private Sub MultiQueryForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Try
				' 1. Connect to the Therefore server
				server = New TheServer()
				server.Connect(TheClientType.CustomApplication)
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_execute_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_execute.Click
			Try
				' 2. Create a new multi-query
				Dim multiQuery As New TheMultiQuery()

				' 3. Create and add two or more queries
				Dim query As New TheQuery()
				query.Category.Load("Files", server)
				query.SelectFields.AddAll()
				query.Conditions.Add("Filename", "*Moya*") ' using the column
				query.OrderByFields.Add("Creation_Date")
				multiQuery.Add(query)

				Dim query2 As New TheQuery()
				query2.Category.Load("Simple Invoice", server)
				query2.SelectFields.AddAll()
				multiQuery.Add(query2)

				' 4. Execute the multi-query
				multiResult = multiQuery.Execute(server)

				' Optional 5. Display multi-query definition and results in MessageBox
				MessageBox.Show(CType(multiQuery, Object).ToString() & vbCrLf & "---------------------------------------------------" & vbCrLf & vbCrLf & CType(multiResult, Object).ToString())
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_process_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_process.Click
			Try
				txt_result.Text = ""
				' Iterate through search results using nested for-loops
				For i As Integer = 0 To multiResult.Count - 1
					For j As Integer = 0 To multiResult(i).Count - 1
						For k As Integer = 0 To multiResult(i)(j).Count - 1
							' Access the k-th field in the j-th row of the i-th query
							If Me.multiResult(i)(j)(k) IsNot Nothing Then
								txt_result.Text += multiResult(i)(j)(k).ToString() & vbCrLf
							End If
						Next k
					Next j
				Next i

				' Iterate through search results using the nested for-each constructs
				For Each QueryResult As TheQueryResult In multiResult
					For Each row As TheQueryResultRow In QueryResult
						For Each obj As Object In row
							If TypeOf obj Is DBNull Then
								txt_result.Text &= "null" & vbCrLf
							Else
								txt_result.Text += obj.ToString() & vbCrLf
							End If
						Next obj
					Next row
				Next QueryResult
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub
	End Class
End Namespace
