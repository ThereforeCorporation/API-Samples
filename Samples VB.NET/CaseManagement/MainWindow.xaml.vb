Imports System.Text
Imports Therefore.API

Namespace CaseManagement
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Private _case As TheCase
		Private _server As TheServer

		Public Sub New()
			_case = Nothing
			_server = New TheServer()
			_server.Connect()
			InitializeComponent()
		End Sub

		Private Sub LoadCase()
			If _case Is Nothing Then
				_case = New TheCase()
			End If
			Dim caseno As Integer = Convert.ToInt32(txt_caseno.Text)
			If _case.CaseNo <> caseno Then
				_case.Load(caseno, _server)
			End If
		End Sub

		Private Sub btn_header_fields_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim casedefinition As New TheCaseDefinition()
				casedefinition.Load(Convert.ToInt32(txt_casedefno.Text), _server)
				txt_output.Text = "Case Definition:" & Environment.NewLine
				txt_output.Text &= "Case Definition ID: " & casedefinition.CaseDefinitionNo & Environment.NewLine
				txt_output.Text &= "Case Name: " & casedefinition.Name & Environment.NewLine
				For i As Integer = 0 To casedefinition.FieldCount - 1
					Dim field As TheCategoryField = casedefinition.GetFieldByIndex(i)
					If field.FieldType = TheCategoryFieldType.LabelField Then
						Continue For
					End If
					txt_output.Text += Environment.NewLine
					txt_output.Text &= "IndexDataFieldName: " & field.IndexDataFieldName & Environment.NewLine
					txt_output.Text &= "FieldNo: " & field.FieldNo & Environment.NewLine
					txt_output.Text &= "FieldType: " & field.FieldType.ToString() & Environment.NewLine
				Next i
			Catch ex As System.Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_categories_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim casedefinition As New TheCaseDefinition()
				casedefinition.Load(Convert.ToInt32(txt_casedefno.Text), _server)
				txt_output.Text = "Categories belonging to case definition " & casedefinition.CaseDefinitionNo & Environment.NewLine
				For i As Integer = 0 To casedefinition.Categories.Count - 1
					Dim category As TheFolderItem = casedefinition.Categories(i)
					txt_output.Text += category.ID & " - " & category.Name & Environment.NewLine
				Next i
			Catch ex As System.Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_header_indexdata_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				LoadCase()
				txt_output.Text = _case.IndexData.ToString()
			Catch ex As System.Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_documents_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				LoadCase()
				txt_output.Text = "All documents that belong to case ID: " & _case.CaseNo & Environment.NewLine
				Dim aDocuments As TheIntArray = _case.GetDocuments()
				For i As Integer = 0 To aDocuments.Count - 1
					txt_output.Text += aDocuments(i) & Environment.NewLine
				Next i
			Catch ex As System.Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_doc_for_cat_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				LoadCase()
				txt_output.Text = "All documents that belong to case ID: " & _case.CaseNo & " and category ID: " & Convert.ToInt32(txt_catno.Text) & Environment.NewLine
				Dim aDocuments As TheIntArray = _case.GetDocuments(Convert.ToInt32(txt_catno.Text))
				For i As Integer = 0 To aDocuments.Count - 1
					txt_output.Text += aDocuments(i) & Environment.NewLine
				Next i
			Catch ex As System.Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_show_history_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				LoadCase()
				txt_output.Text = "The History of case ID: " & _case.CaseNo & Environment.NewLine
				Dim history As TheCaseHistory = _case.GetHistory(_server)
				For i As Integer = 0 To history.Count - 1
					txt_output.Text += history(i).Text & Environment.NewLine
				Next i
			Catch ex As System.Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_openviewer_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				LoadCase()
				_case.View()
			Catch ex As System.Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_closeviewer_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				_case.CloseCaseManager()
			Catch ex As System.Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_query_all_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim query As New TheQuery()
				Dim casedef As New TheCaseDefinition()
				casedef.Load(Convert.ToInt32(txt_query_casedefno.Text), _server)
				query.CaseDefinition = casedef
				query.SelectFields.AddAll()
				query.Mode = TheQueryMode.CaseQuery
				Dim result As TheQueryResult = query.Execute(_server)
				txt_output.Text = result.ToString()
			Catch ex As System.Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_create_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim newcase As New TheCase()
				Dim nCaseDefNo As Integer = 0
				If txt_casedefno_create.Text <> "" Then
					nCaseDefNo = Convert.ToInt32(txt_casedefno_create.Text)
					newcase.IndexData.SetCaseDefinition(nCaseDefNo, _server)
				End If
				newcase.IndexData.EditIxData(_server, "", "",TheObjectType.CaseDefinition)
				Dim nCaseNo As Integer = newcase.Create(_server)
				txt_output.Text = "Case No of new case: " & nCaseNo & Environment.NewLine
				txt_output.Text += newcase.IndexData.ToString()
			Catch ex As System.Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_selection_dialog_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim nCaseDefNo As Integer =_server.ShowCaseDefinitionSelectionDialog()
				txt_query_casedefno.Text = nCaseDefNo.ToString()
				txt_casedefno_create.Text = txt_query_casedefno.Text
				txt_casedefno.Text = txt_casedefno_create.Text
			Catch ex As System.Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_open_dialog_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				LoadCase()
				_case.IndexData.EditIxData(_server, "", "")
				txt_output.Text = _case.IndexData.ToString()
			Catch ex As System.Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_closecase_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				LoadCase()
				_case.CloseCase(_server)
				txt_output.Text = _case.IndexData.ToString() & Environment.NewLine
				txt_output.Text += Convert.ToString("IsClosed: " & _case.IsClosed)
			Catch ex As System.Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub btn_reopencase_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				LoadCase()
				_case.ReopenCase(_server)
				txt_output.Text = _case.IndexData.ToString() & Environment.NewLine
				txt_output.Text += Convert.ToString("IsClosed: " & _case.IsClosed)
			Catch ex As System.Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub
	End Class
End Namespace
