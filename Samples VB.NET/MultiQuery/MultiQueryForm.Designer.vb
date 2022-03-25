Namespace MultiQuery
	Partial Public Class MultiQueryForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.btn_execute = New Button()
			Me.btn_process = New Button()
			Me.txt_result = New TextBox()
			Me.SuspendLayout()
			' 
			' btn_execute
			' 
			Me.btn_execute.Location = New Point(12, 12)
			Me.btn_execute.Name = "btn_execute"
			Me.btn_execute.Size = New Size(90, 40)
			Me.btn_execute.TabIndex = 0
			Me.btn_execute.Text = "Execute Query"
			Me.btn_execute.UseVisualStyleBackColor = True
'			Me.btn_execute.Click += New System.EventHandler(Me.btn_execute_Click)
			' 
			' btn_process
			' 
			Me.btn_process.Location = New Point(191, 12)
			Me.btn_process.Name = "btn_process"
			Me.btn_process.Size = New Size(90, 40)
			Me.btn_process.TabIndex = 1
			Me.btn_process.Text = "Process Query"
			Me.btn_process.UseVisualStyleBackColor = True
'			Me.btn_process.Click += New System.EventHandler(Me.btn_process_Click)
			' 
			' txt_result
			' 
			Me.txt_result.Location = New Point(12, 70)
			Me.txt_result.Multiline = True
			Me.txt_result.Name = "txt_result"
			Me.txt_result.ReadOnly = True
			Me.txt_result.Size = New Size(269, 218)
			Me.txt_result.TabIndex = 2
			' 
			' MultiQueryForm
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.ClientSize = New Size(293, 300)
			Me.Controls.Add(Me.txt_result)
			Me.Controls.Add(Me.btn_process)
			Me.Controls.Add(Me.btn_execute)
			Me.Name = "MultiQueryForm"
			Me.Text = "Multi Query"
'			Me.Load += New System.EventHandler(Me.MultiQueryForm_Load)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btn_execute As Button
		Private WithEvents btn_process As Button
		Private txt_result As TextBox
	End Class
End Namespace

