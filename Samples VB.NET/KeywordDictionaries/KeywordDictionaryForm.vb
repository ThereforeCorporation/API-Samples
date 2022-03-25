Imports System.ComponentModel
Imports System.Text
Imports Therefore.API

Namespace KeywordDictionaries
	Partial Public Class KeywordDictionaryForm
		Inherits Form
		Private _dictionary As TheKeywordDictionary

		Public Sub New()
			_dictionary = Nothing
			InitializeComponent()
		End Sub

		Private Sub btn_load_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_load.Click
			Try
				'load the keyword dictionary and display its content
				Dim server As New TheServer()
				server.Connect()
				_dictionary = New TheKeywordDictionary()
				txt_content.Text = _dictionary.ToString()
				_dictionary.LoadByID(Convert.ToInt32(txt_keydictno.Text), server)
				'_dictionary.LoadByTypeNo(Convert.ToInt32(txt_keydictno.Text), server);
				'with LoadByTypeNo() the keyword dictionary can be loaded with the value from TheCategoryField.TypeNo
				'this will only work when either TheCategoryField.SingleKeyword or TheCategoryField.MultiKeyword is true
				server.Disconnect()
				txt_content.Text = _dictionary.ToString()
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_deactivate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_deactivate.Click
			Try
				'this will deactivate the keyword with the specified ID
				Dim keyword As TheKeyword = Nothing
				Dim keywordID As Integer = Convert.ToInt32(txt_deactivate_keyword.Text)
				keyword = _dictionary.GetKeyword(keywordID)
				'switch deactivated property to opposite value
				keyword.Deactivated = Not keyword.Deactivated

				txt_content.Text = _dictionary.ToString()
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_delete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_delete.Click
			Try
				'this will delete the keyword with the specified ID from the dictionary
				Dim keywordID As Integer = Convert.ToInt32(txt_delete_keyword.Text)
				_dictionary.Remove(keywordID)
				txt_content.Text = _dictionary.ToString()
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_add_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_add.Click
			Try
				'this will add a new keyword
				Dim keyword As New TheKeyword()
				keyword.Name = txt_new_keyword.Text
				_dictionary.Add(keyword)
				txt_content.Text = _dictionary.ToString()
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_save_changes_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_save_changes.Click
			Try
				'changes made on the keyword dictionary will not be saved until SaveChanges() is called
				Dim server As New TheServer()
				server.Connect()
				_dictionary.SaveChanges(server)
				server.Disconnect()
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_delete_at_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_delete_at.Click
			Try
				'this will delete the keyword with the specified ID from the dictionary
				Dim index As Integer = Convert.ToInt32(txt_delete_at.Text)
				_dictionary.RemoveAt(index)
				txt_content.Text = _dictionary.ToString()
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_rename_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_rename.Click
			Try
				Dim keyword As TheKeyword = _dictionary.GetKeyword(txt_rename_from.Text)
				keyword.Name = txt_rename_to.Text
				txt_content.Text = _dictionary.ToString()
			Catch ex As System.Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub
	End Class
End Namespace
