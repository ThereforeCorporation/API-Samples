Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Globalization
Imports System.Reflection
Imports System.Text
Imports Therefore.API

Namespace Therefore.Samples
	''' <summary>
	''' Interaction logic for CategoryPropertiesWindow.xaml
	''' </summary>
	Partial Public Class CaseDefinitionPropertiesWindow
		Inherits Window
		Private _casedef As TheCaseDefinition
		Public Sub New(ByVal casedef As TheCaseDefinition)
			_casedef = casedef
			InitializeComponent()
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Me.DataContext = _casedef
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
				Me.Close()
			End Try
		End Sub

		Private Sub btn_close_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Me.Close()
		End Sub

		Private Sub btn_change_subcase_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim pcw As New PropertyChangeWindow("SubCaseField")
				If pcw.ShowDialog() = True Then
					_casedef.SetSubCaseFieldIx(Convert.ToInt32(pcw.Value))
				End If
				BindingOperations.GetBindingExpression(txt_subcasefield, TextBox.TextProperty).UpdateTarget()
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
				Me.Close()
			End Try
		End Sub
	End Class
End Namespace
