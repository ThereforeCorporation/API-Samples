Imports System
Imports System.Collections.Generic
Imports System.Globalization
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
	''' Interaction logic for LanguageSelectionWindow.xaml
	''' </summary>
	Partial Public Class LanguageSelectionWindow
		Inherits Window
		Private _languages As IEnumerable(Of CultureInfo)
		Private privateSelectedLanguage As CultureInfo
		Public Property SelectedLanguage() As CultureInfo
			Get
				Return privateSelectedLanguage
			End Get
			Private Set(ByVal value As CultureInfo)
				privateSelectedLanguage = value
			End Set
		End Property
		Public Sub New(ByVal languages As IEnumerable(Of CultureInfo))
			_languages = languages
			InitializeComponent()
		End Sub

		Private Sub btn_OK_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				Dim selected As CultureInfo = CType(cmb_languages.SelectedItem, CultureInfo)
				If selected Is Nothing Then
					Throw New Exception("No language has been selected.")
				End If
				SelectedLanguage = selected
				Me.DialogResult = True
				Me.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Try
				cmb_languages.ItemsSource = _languages
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub
	End Class


	'these languages are supported by Therefore
	Friend Enum ValidLanguages
		Arabic = 1025
		English = 1033
		Finnish = 1035
		French = 1036
		German = 1031
		Italian = 1040
		Portuguese = 2070
		Spanish = 1034
		Swedish = 1053
		Danish = 1030
		Norwegian = 1044
		Dutch = 1043
		Hungarian = 1038
		Slovenian = 1060
		Croatian = 1050
		Czech = 1029
		Polish = 1045
		Turkish = 1055
		Russian = 1049
		Serbian_Latin = 2074
		Japanese = 1041
		Chinese_Simple = 2052
		Chinese_Traditional = 1028
		Korean = 1042
		Brazilian = 1046
		Bulgarian = 1026
	End Enum
End Namespace
