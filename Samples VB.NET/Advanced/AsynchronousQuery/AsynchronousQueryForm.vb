Imports System.ComponentModel
Imports System.Text
Imports Therefore.API

Namespace AsynchronousQuery
	Partial Public Class AsynchronousQueryForm
		Inherits Form
		Private _singlequeryID As Integer
		Private _multiqueryID As Integer
		Private _server As TheServer

		Public Sub New()
			_singlequeryID = 0
			_multiqueryID = 0
			_server = Nothing
			InitializeComponent()
		End Sub

		'---------------- MULTI QUERY ----------------//
		Private Sub btn_execute_multi_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_execute_multi.Click
			Try
				'create a multi query
				Dim multiquery As New TheMultiQuery()
				Dim query1 As New TheQuery()
				query1.Category.Load("Files", Server)
				query1.SelectFields.AddAll()
				multiquery.Add(query1)
				Dim query2 As New TheQuery()
				query2.Category.Load("Simple Invoice", Server)
				query2.SelectFields.AddAll()
				multiquery.Add(query2)

				multiquery.RowBlockSize = 5 'for testing set the block size to a small value to better see the difference to synchronous querying
				Dim multiresult As TheMultiQueryResult = multiquery.ExecuteAsync(Server) 'execute the query
				_multiqueryID = multiquery.QueryID 'store the query id for later
				txt_output.Text = ""
				DisplayMultiQueryResult(multiresult) 'executing the query will always return the first batch of results
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_getnext_multi_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_getnext_multi.Click
			Try
				If _multiqueryID = 0 Then
					MessageBox.Show("No multi query has been started.")
					Return
				End If
				Dim multiquery As New TheMultiQuery()
				Dim query1 As New TheQuery()
				query1.Category.Load("Files", Server)
				query1.SelectFields.AddAll()
				multiquery.Add(query1)
				Dim query2 As New TheQuery()
				query2.Category.Load("Simple Invoice", Server)
				query2.SelectFields.AddAll()
				multiquery.Add(query2)

				multiquery.RowBlockSize = 5
				Dim multiresult As New TheMultiQueryResult()
				'retrieve the next batch of results
				Dim [end] As Boolean = multiquery.GetNextResultRows(Server, _multiqueryID, multiresult)
				DisplayMultiQueryResult(multiresult)
				If [end] Then 'when GetNextResultRows returns true, the last batch of results has been returned
					txt_output.Text &= "END OF RESULTS"
					multiquery.ReleaseQuery(Server, _multiqueryID) 'when the end of results have been reached release the query on the server
					_multiqueryID = 0 'when this is set to 0 it the if above will prevent GetNextResultRows to be called again
					'if GetNextResultRows is called again after it returned true, an exception will be thrown
				End If
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		'---------------- DISPLAYING CONTENT ----------------//
		Private Sub DisplayMultiQueryResult(ByVal multiresult As TheMultiQueryResult)
			txt_output.Text &= Environment.NewLine & "Next multi query result batch" & Environment.NewLine
			For i As Integer = 0 To multiresult.Count - 1
				'for a multi query display the results one by one. an asynchronous execute will bring the results in order by category
				'but one batch can still contain results from more than one query
				Dim result As TheQueryResult = multiresult(i)
				DisplaySingleQueryResult(result)
			Next i
			txt_output.Text &= Environment.NewLine
		End Sub

		Private Sub DisplaySingleQueryResult(ByVal result As TheQueryResult)
			txt_output.Text &= String.Format("Result for Category {0} - Count {1}" & Environment.NewLine, result.CategoryNo, result.Count)
			For i As Integer = 0 To result.Count - 1
				Dim row As TheQueryResultRow = result(i)
				txt_output.Text &= String.Format(vbTab & "DocNo: {0} - {1}" & Environment.NewLine, row.DocNo, row.ToString())
			Next i
		End Sub

		'---------------- SINGLE QUERY ----------------//
		Private Sub btn_execute_single_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_execute_single.Click
			Try
				'create a single a query
				Dim singlequery As New TheQuery()
				singlequery.Category.Load("Files", Server)
				singlequery.SelectFields.AddAll()
				singlequery.RowBlockSize = 5 'set the block size to a small value to see the effect
				Dim singleresult As TheQueryResult = singlequery.ExecuteAsync(Server) 'execute the query
				_singlequeryID = singlequery.QueryID 'store the query id for later
				txt_output.Text = ""
				DisplaySingleQueryResult(singleresult) 'executing the query will always return the first batch of results
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_getnext_single_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_getnext_single.Click
			Try
				If _singlequeryID = 0 Then
					MessageBox.Show("No single query has been started.")
					Return
				End If
				Dim singlequery As New TheQuery()
				singlequery.Category.Load(54, Server)
				singlequery.SelectFields.AddAll()
				singlequery.RowBlockSize = 5
				Dim result As New TheQueryResult()
				'retrieve the next batch of results
				Dim [end] As Boolean = singlequery.GetNextResultRows(Server, _singlequeryID, result)
				DisplaySingleQueryResult(result)
				If [end] Then 'when GetNextResultRows returns true, the last batch of results has been returned
					txt_output.Text &= "END OF RESULTS"
					singlequery.ReleaseQuery(Server, _singlequeryID) 'when the end of results have been reached release the query on the server
					_singlequeryID = 0 'when this is set to 0 it the if above will prevent GetNextResultRows to be called again
					'if GetNextResultRows is called again after it returned true, an exception will be thrown
				End If
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private ReadOnly Property Server() As TheServer 'using this property will make sure to always have a connected server
			Get
				If _server Is Nothing Then
					_server = New TheServer()
				End If
				If Not _server.Connected Then
					_server.Connect()
				End If
				Return _server
			End Get
		End Property

		Private Sub AsynchronousQueryForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			Try
				Server.Disconnect() 'be sure to disconnect from the server

			Catch e1 As Exception 'if there is an exception thrown now there is no need to handle it anymore
			End Try
		End Sub
	End Class
End Namespace
