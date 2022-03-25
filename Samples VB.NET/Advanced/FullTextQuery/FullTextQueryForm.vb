Imports System.ComponentModel
Imports System.Text
Imports Therefore.API

Namespace FullTextQuery
	Partial Public Class FullTextQueryForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub FullTextQueryForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Try
				Dim types() As String = System.Enum.GetNames(GetType(TheFullTextSortOrder))
				cmb_sortorder.Items.AddRange(types)
				cmb_sortorder.SelectedValue = System.Enum.GetName(GetType(TheFullTextSortOrder), TheFullTextSortOrder.ByRelevance) 'by relevance is default
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Environment.Exit(0)
			End Try
		End Sub

		Private Sub btnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExit.Click
			Application.Exit()
		End Sub

		Private Sub btnExecute_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExecute.Click
			If txtQuery.Text = "" Then
				MessageBox.Show("Please enter a query.", "Query Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Else
				Try
					Dim sortorder As TheFullTextSortOrder = CType(System.Enum.Parse(GetType(TheFullTextSortOrder), CStr(cmb_sortorder.SelectedValue)), TheFullTextSortOrder)

					Dim server As New TheServer()
					server.Connect(TheClientType.CustomApplication)
					'create a TheFullTextQuery object
					Dim q As New TheFullTextQuery()
                    'add all categories you want to search
                    q.Categories.Add(getCtgryNoFromName("Files", server))
                    q.SetSearchScope(False, True) 'search file content only but Not In index data                    
                    q.ContextMode = TheFullTextContext.FTContextOff 'the context is the snippet of text displayed in the full-text result list in Navigator
                    q.Search = txtQuery.Text
					q.SortOrder = sortorder
					q.UseThesaurus = chk_thesaurus.Checked
					q.FuzzySearchLevel = Convert.ToInt32(txt_fuzzysearch.Text)
					'execute the query
					Dim qRes As TheFullTextQueryResult = q.Execute(server)
					MessageBox.Show(CType(qRes, Object).ToString(), "Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
				End Try
			End If
		End Sub

		Private Function getCtgryNoFromName(ByVal strCtgryNo As String, ByVal server As TheServer) As Integer
			Dim cat As New TheCategoryClass()
			cat.Load(strCtgryNo, server)
			Return cat.CtgryNo
		End Function
	End Class
End Namespace