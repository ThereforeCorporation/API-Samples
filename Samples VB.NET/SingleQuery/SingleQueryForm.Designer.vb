Namespace SingleQuery
	Partial Public Class SingleQueryForm
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
			Me.btn_simple = New Button()
			Me.btn_execute = New Button()
			Me.btn_process = New Button()
			Me.txt_result = New TextBox()
			Me.SuspendLayout()
			' 
			' btn_simple
			' 
			Me.btn_simple.Location = New Point(13, 13)
			Me.btn_simple.Name = "btn_simple"
			Me.btn_simple.Size = New Size(90, 40)
			Me.btn_simple.TabIndex = 0
			Me.btn_simple.Text = "Execute Simple Query"
			Me.btn_simple.UseVisualStyleBackColor = True
'			Me.btn_simple.Click += New System.EventHandler(Me.btn_simple_Click)
			' 
			' btn_execute
			' 
			Me.btn_execute.Location = New Point(13, 81)
			Me.btn_execute.Name = "btn_execute"
			Me.btn_execute.Size = New Size(90, 40)
			Me.btn_execute.TabIndex = 1
			Me.btn_execute.Text = "Execute Query"
			Me.btn_execute.UseVisualStyleBackColor = True
'			Me.btn_execute.Click += New System.EventHandler(Me.btn_execute_Click)
			' 
			' btn_process
			' 
			Me.btn_process.Location = New Point(13, 149)
			Me.btn_process.Name = "btn_process"
			Me.btn_process.Size = New Size(90, 40)
			Me.btn_process.TabIndex = 2
			Me.btn_process.Text = "Process Query"
			Me.btn_process.UseVisualStyleBackColor = True
'			Me.btn_process.Click += New System.EventHandler(Me.btn_process_Click)
			' 
			' txt_result
			' 
			Me.txt_result.Location = New Point(124, 13)
			Me.txt_result.Multiline = True
			Me.txt_result.Name = "txt_result"
			Me.txt_result.ReadOnly = True
			Me.txt_result.Size = New Size(292, 175)
			Me.txt_result.TabIndex = 3
			' 
			' SingleQueryForm
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.ClientSize = New Size(428, 206)
			Me.Controls.Add(Me.txt_result)
			Me.Controls.Add(Me.btn_process)
			Me.Controls.Add(Me.btn_execute)
			Me.Controls.Add(Me.btn_simple)
			Me.Name = "SingleQueryForm"
			Me.Text = "Single Query"
'			Me.Load += New System.EventHandler(Me.SingleQueryForm_Load)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btn_simple As Button
		Private WithEvents btn_execute As Button
		Private WithEvents btn_process As Button
		Private txt_result As TextBox
	End Class
End Namespace

