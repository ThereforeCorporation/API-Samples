Imports System.Text
Imports System.Threading.Tasks
Imports Therefore.API

Namespace RoleBasedSecurity
	''' <summary>
	''' Interaction logic for ChangeConditionWindow.xaml
	''' </summary>
	Partial Public Class ChangeConditionWindow
		Inherits Window
		Private privateCondition As String
		Public Property Condition() As String
			Get
				Return privateCondition
			End Get
			Private Set(ByVal value As String)
				privateCondition = value
			End Set
		End Property

		Public Sub New(ByVal condition As String)
			InitializeComponent()
			Me.Condition = condition
			txt_condition.Text = Me.Condition
		End Sub

		Private Sub btn_ok_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Condition = txt_condition.Text
			DialogResult = True
			Close()
		End Sub
	End Class
End Namespace
