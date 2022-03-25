Namespace AddInSamples
	Partial Public Class CustomWorkflowForm
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.btnApprove = New System.Windows.Forms.Button()
			Me.btnReject = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.btnView = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(262, 26)
			Me.label1.TabIndex = 0
			Me.label1.Text = "This is my custom Workflow Form, which replaces the " & vbCrLf & "default workflow Form for t" & "his Task."
			' 
			' btnApprove
			' 
			Me.btnApprove.Location = New System.Drawing.Point(15, 95)
			Me.btnApprove.Name = "btnApprove"
			Me.btnApprove.Size = New System.Drawing.Size(75, 23)
			Me.btnApprove.TabIndex = 1
			Me.btnApprove.Text = "Approve"
			Me.btnApprove.UseVisualStyleBackColor = True
'			Me.btnApprove.Click += New System.EventHandler(Me.btnApprove_Click)
			' 
			' btnReject
			' 
			Me.btnReject.Location = New System.Drawing.Point(96, 95)
			Me.btnReject.Name = "btnReject"
			Me.btnReject.Size = New System.Drawing.Size(75, 23)
			Me.btnReject.TabIndex = 2
			Me.btnReject.Text = "Reject"
			Me.btnReject.UseVisualStyleBackColor = True
'			Me.btnReject.Click += New System.EventHandler(Me.btnReject_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.Location = New System.Drawing.Point(177, 95)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 3
			Me.btnCancel.Text = "Cancel"
			Me.btnCancel.UseVisualStyleBackColor = True
'			Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click)
			' 
			' btnView
			' 
			Me.btnView.Location = New System.Drawing.Point(96, 48)
			Me.btnView.Name = "btnView"
			Me.btnView.Size = New System.Drawing.Size(75, 23)
			Me.btnView.TabIndex = 4
			Me.btnView.Text = "View Doc"
			Me.btnView.UseVisualStyleBackColor = True
'			Me.btnView.Click += New System.EventHandler(Me.btnView_Click)
			' 
			' CustomWorkflowForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(284, 139)
			Me.Controls.Add(Me.btnView)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnReject)
			Me.Controls.Add(Me.btnApprove)
			Me.Controls.Add(Me.label1)
			Me.Name = "CustomWorkflowForm"
			Me.Text = "CustomWorkflowForm"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private WithEvents btnApprove As System.Windows.Forms.Button
		Private WithEvents btnReject As System.Windows.Forms.Button
		Private WithEvents btnCancel As System.Windows.Forms.Button
		Private WithEvents btnView As System.Windows.Forms.Button
	End Class
End Namespace