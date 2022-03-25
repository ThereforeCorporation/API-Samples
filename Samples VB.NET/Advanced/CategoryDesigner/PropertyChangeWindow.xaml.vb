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
	''' Interaction logic for PropertyChangeWindow.xaml
	''' </summary>
	Partial Public Class PropertyChangeWindow
		Inherits Window
		Public Property Value() As String
		Private _propertyname As String

		Public Sub New(ByVal propertyname As String)
			_propertyname = propertyname
			InitializeComponent()
		End Sub

		Private Sub btn_OK_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Value = txt_value.Text
			Me.DialogResult = True
			Me.Close()
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			txt_value.Text = Value
			Title = "Change Property " & _propertyname
		End Sub
	End Class
End Namespace
