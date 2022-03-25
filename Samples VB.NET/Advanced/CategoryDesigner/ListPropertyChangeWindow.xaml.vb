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

Namespace Therefore.Samples
	''' <summary>
	''' Interaction logic for ListPropertyChangeWindow.xaml
	''' </summary>
	Partial Public Class ListPropertyChangeWindow
		Inherits Window
		Public Property Value() As String
		Private _propertyname As String

		Public Sub New(ByVal propertyname As String, ByVal options As List(Of String))
			_propertyname = propertyname
			InitializeComponent()
			If options.Count = 0 Then
				Me.Close()
			End If
			cmb_options.ItemsSource = options
			cmb_options.SelectedIndex = 0
		End Sub

		Private Sub btn_OK_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Value = CStr(cmb_options.SelectedItem)
			Me.DialogResult = True
			Me.Close()
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			cmb_options.SelectedItem = Value
			Title = "Change Property " & _propertyname
		End Sub
	End Class
End Namespace
