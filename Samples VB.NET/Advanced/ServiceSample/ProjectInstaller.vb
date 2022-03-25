Imports System.ComponentModel
Imports System.Configuration.Install

Namespace ServiceSample
	<RunInstaller(True)> _
	Partial Public Class ProjectInstaller
		Inherits Installer
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class
End Namespace