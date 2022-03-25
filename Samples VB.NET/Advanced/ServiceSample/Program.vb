Imports System.ServiceProcess
Imports System.Text

Namespace ServiceSample
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		Shared Sub Main()
			Dim ServicesToRun() As ServiceBase

			' More than one user Service may run within the same process. To add
			' another service to this process, change the following line to
			' create a second service object. For example,
			'
			'   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
			'
			ServicesToRun = New ServiceBase() { New ServiceSample() }

			ServiceBase.Run(ServicesToRun)
		End Sub
	End Class
End Namespace