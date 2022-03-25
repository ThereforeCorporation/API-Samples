Namespace WorkflowQuery
	Partial Public Class WorkflowQueryForm
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
			Me.btn_specific = New Button()
			Me.btn_all = New Button()
			Me.SuspendLayout()
			' 
			' btn_specific
			' 
			Me.btn_specific.Location = New Point(12, 12)
			Me.btn_specific.Name = "btn_specific"
			Me.btn_specific.Size = New Size(90, 40)
			Me.btn_specific.TabIndex = 0
			Me.btn_specific.Text = "Find in Specific Process"
			Me.btn_specific.UseVisualStyleBackColor = True
'			Me.btn_specific.Click += New System.EventHandler(Me.btn_specific_Click)
			' 
			' btn_all
			' 
			Me.btn_all.Location = New Point(141, 12)
			Me.btn_all.Name = "btn_all"
			Me.btn_all.Size = New Size(90, 40)
			Me.btn_all.TabIndex = 1
			Me.btn_all.Text = "Find All"
			Me.btn_all.UseVisualStyleBackColor = True
'			Me.btn_all.Click += New System.EventHandler(Me.btn_all_Click)
			' 
			' WorkflowQueryForm
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.ClientSize = New Size(243, 80)
			Me.Controls.Add(Me.btn_all)
			Me.Controls.Add(Me.btn_specific)
			Me.Name = "WorkflowQueryForm"
			Me.Text = "Workflow Query"
'			Me.Load += New System.EventHandler(Me.WorkflowQueryForm_Load)
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.WorkflowQueryForm_FormClosing)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents btn_specific As Button
		Private WithEvents btn_all As Button
	End Class
End Namespace

