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
	Partial Public Class CategoryPropertiesWindow
		Inherits Window
		Private _cat As TheCategory
		Public Sub New(ByVal cat As TheCategory)
			_cat = cat
			InitializeComponent()
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				cmb_checkincommentsmode.ItemsSource = System.Enum.GetValues(GetType(TheCheckInCommentsMode))
				For Each o As Object In cmb_checkincommentsmode.ItemsSource
					If Convert.ToString(o) = Convert.ToString(_cat.CheckInCommentsMode) Then
						cmb_checkincommentsmode.SelectedItem = o
					End If
				Next o

				cmb_fulltextmode.ItemsSource = System.Enum.GetValues(GetType(TheFullTextMode))
				For Each o As Object In cmb_fulltextmode.ItemsSource
					If Convert.ToString(o) = Convert.ToString(_cat.FullTextMode) Then
						cmb_fulltextmode.SelectedItem = o
					End If
				Next o

				Me.DataContext = _cat
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
				Me.Close()
			End Try
		End Sub

		Private Sub btn_close_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			_cat.CheckInCommentsMode = CType(cmb_checkincommentsmode.SelectedItem, TheCheckInCommentsMode)
			_cat.FullTextMode = CType(cmb_fulltextmode.SelectedItem, TheFullTextMode)
			Me.Close()
		End Sub

		Private Sub btn_change_sub_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim pcw As New PropertyChangeWindow("SubCategoryField")
				If pcw.ShowDialog() = True Then
					_cat.SetSubCtgryFieldIx(Convert.ToInt32(pcw.Value))
				End If
				BindingOperations.GetBindingExpression(txt_subcategoryfield, TextBox.TextProperty).UpdateTarget()
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		Private Sub btn_change_watermark_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim pcw As New PropertyChangeWindow("WatermarkDocNo")
				If pcw.ShowDialog() = True Then
					Dim server As New TheServer()
					server.Connect()
					_cat.SetWatermarkDocNo(Convert.ToInt32(pcw.Value),server)
					BindingOperations.GetBindingExpression(txt_watermarkdocno, TextBox.TextProperty).UpdateTarget()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub
	End Class
End Namespace
