Imports System.ComponentModel
Imports System.Text
Imports Therefore.API

Namespace SingleQuery
	Partial Public Class SingleQueryForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private server As TheServer
		Private result As TheQueryResult

		Private Sub SingleQueryForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Try
				' 1. Connect to the Therefore™ server
				server = New TheServer()
				server.Connect(TheClientType.CustomApplication)
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_simple_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_simple.Click
			Try
				Dim ctgryno As Integer = getCtgryNoFromName("Files")
				Dim fieldno As Integer = getFieldNoFromName("Files", "Extension")


				' 2. Call the ExecuteSimple of a temporary TheQuery instance
				' Finds index data in category "ctgryno" where field "fieldno" starts with a "d"
				' and sorts the results by the value of field "fieldno".
				result = New TheQuery().ExecuteSimple(ctgryno, fieldno, "d*", fieldno, server)

				' Optional 3. Display a message box with the results.
				MessageBox.Show(CType(result, Object).ToString())
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_execute_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_execute.Click
			Try
				Dim fieldno As Integer = getFieldNoFromName("Files", "Extension")
				' 2. Declare and initialize a new TheQuery
				Dim query As New TheQuery()

				' 3. Set a category
				query.Category.Load("Files", server)

                ' 4. Add all visible fields except "Extension"
                query.SelectFields.AddAll()
				query.SelectFields.Remove("Extension")

				' Optional 5. Get the list of valid condition operators
				Dim operators As ITheReadOnlyStringList = query.ValidOperators
				txt_result.Text = (CType(operators, Object).ToString())

				' 6. Define query conditions
				query.Conditions.Add(fieldno, "d* or t*") ' using the field number
				query.Conditions.Add("Filename", "*Moya*") ' using the column name

				' 7. Sort results by InvoiceNo
				query.OrderByFields.Add("Creation_Date")

				' 8. Execute the query
				result = query.Execute(server)

				' Optional 9. Display Query definition and results in a MessageBox
				MessageBox.Show(CType(query, Object).ToString() & vbCrLf & CType(result, Object).ToString())
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_process_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_process.Click
			Try
				' Iterate through search result using nested for-loops
				For i As Integer = 0 To result.Count - 1
					txt_result.Text = (result(i).ToString())
					For j As Integer = 0 To result(i).Count - 1
						' Access the j-th field in the i-th row
						If result(i)(j) IsNot Nothing Then
							txt_result.Text = (result(i)(j).ToString())
						End If
					Next j
				Next i

				' Iterate through search result using the for-each constructs
				' Type-specific handling of field values
				For Each row As TheQueryResultRow In result
					txt_result.Text = (CType(row, Object).ToString())
					For Each obj As Object In row
						If TypeOf obj Is DBNull Then
							txt_result.Text &= "null"
						ElseIf TypeOf obj Is Integer Then
							Dim i As Integer = CInt(Fix(obj))
							txt_result.Text += i & " * " & i & " = " & (i * i)
						ElseIf TypeOf obj Is Double Then
							Dim d As Double = CDbl(obj)
							txt_result.Text += d & " / 2 = " & (d / 2)
						ElseIf TypeOf obj Is String Then
							Dim s As String = CStr(obj)
							txt_result.Text &= """" & s & """ is a string"
						ElseIf TypeOf obj Is Date Then
							Dim dt As Date = CDate(obj)
							Dim ts As TimeSpan = Date.Now.Subtract(dt)
							txt_result.Text += ts.TotalDays & "days ago."
						Else
							txt_result.Text &= "A " & obj.GetType().ToString()
						End If
						txt_result.Text += vbCrLf
					Next obj
				Next row
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Function getCtgryNoFromName(ByVal strCtgryName As String) As Integer
			Dim cat As New TheCategoryClass()
			cat.Load(strCtgryName, server)
			Return cat.CtgryNo
		End Function

		Private Function getFieldNoFromName(ByVal strCtgryName As String, ByVal strFieldName As String) As Integer
			Dim cat As New TheCategoryClass()
			cat.Load(strCtgryName, server)
			Dim field As TheCategoryField = cat.GetFieldByColName(strFieldName)
			Return field.FieldNo
		End Function
	End Class
End Namespace
