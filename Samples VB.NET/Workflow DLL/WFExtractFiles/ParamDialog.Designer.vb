Namespace WFExtractFiles
	Partial Public Class ParamDialog
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
			Me.btn_browse = New System.Windows.Forms.Button()
			Me.btn_cancel = New System.Windows.Forms.Button()
			Me.btn_ok = New System.Windows.Forms.Button()
			Me.txt_path = New System.Windows.Forms.TextBox()
			Me.lbl_path = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' btn_browse
			' 
			Me.btn_browse.Location = New System.Drawing.Point(308, 15)
			Me.btn_browse.Name = "btn_browse"
			Me.btn_browse.Size = New System.Drawing.Size(27, 23)
			Me.btn_browse.TabIndex = 0
			Me.btn_browse.Text = "..."
			Me.btn_browse.UseVisualStyleBackColor = True
'			Me.btn_browse.Click += New System.EventHandler(Me.btn_browse_Click)
			' 
			' btn_cancel
			' 
			Me.btn_cancel.Location = New System.Drawing.Point(260, 50)
			Me.btn_cancel.Name = "btn_cancel"
			Me.btn_cancel.Size = New System.Drawing.Size(75, 23)
			Me.btn_cancel.TabIndex = 1
			Me.btn_cancel.Text = "Cancel"
			Me.btn_cancel.UseVisualStyleBackColor = True
'			Me.btn_cancel.Click += New System.EventHandler(Me.btn_cancel_Click)
			' 
			' btn_ok
			' 
			Me.btn_ok.Location = New System.Drawing.Point(179, 50)
			Me.btn_ok.Name = "btn_ok"
			Me.btn_ok.Size = New System.Drawing.Size(75, 23)
			Me.btn_ok.TabIndex = 2
			Me.btn_ok.Text = "OK"
			Me.btn_ok.UseVisualStyleBackColor = True
'			Me.btn_ok.Click += New System.EventHandler(Me.btn_ok_Click)
			' 
			' txt_path
			' 
			Me.txt_path.Location = New System.Drawing.Point(50, 17)
			Me.txt_path.Name = "txt_path"
			Me.txt_path.Size = New System.Drawing.Size(252, 20)
			Me.txt_path.TabIndex = 3
			' 
			' lbl_path
			' 
			Me.lbl_path.AutoSize = True
			Me.lbl_path.Location = New System.Drawing.Point(12, 20)
			Me.lbl_path.Name = "lbl_path"
			Me.lbl_path.Size = New System.Drawing.Size(32, 13)
			Me.lbl_path.TabIndex = 4
			Me.lbl_path.Text = "Path:"
			' 
			' ParamDialog
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(347, 85)
			Me.Controls.Add(Me.lbl_path)
			Me.Controls.Add(Me.txt_path)
			Me.Controls.Add(Me.btn_ok)
			Me.Controls.Add(Me.btn_cancel)
			Me.Controls.Add(Me.btn_browse)
			Me.Name = "ParamDialog"
			Me.Text = "ParamDialog"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btn_browse As System.Windows.Forms.Button
		Private WithEvents btn_cancel As System.Windows.Forms.Button
		Private WithEvents btn_ok As System.Windows.Forms.Button
		Private txt_path As System.Windows.Forms.TextBox
		Private lbl_path As System.Windows.Forms.Label
	End Class
End Namespace