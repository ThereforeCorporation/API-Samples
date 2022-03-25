Namespace AsynchronousQuery
	Partial Public Class AsynchronousQueryForm
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
			Me.btn_execute_multi = New System.Windows.Forms.Button()
			Me.btn_execute_single = New System.Windows.Forms.Button()
			Me.btn_getnext_multi = New System.Windows.Forms.Button()
			Me.btn_getnext_single = New System.Windows.Forms.Button()
			Me.txt_output = New System.Windows.Forms.TextBox()
			Me.SuspendLayout()
			' 
			' btn_execute_multi
			' 
			Me.btn_execute_multi.Location = New System.Drawing.Point(12, 12)
			Me.btn_execute_multi.Name = "btn_execute_multi"
			Me.btn_execute_multi.Size = New System.Drawing.Size(106, 43)
			Me.btn_execute_multi.TabIndex = 0
			Me.btn_execute_multi.Text = "Execute Multi Query"
			Me.btn_execute_multi.UseVisualStyleBackColor = True
'			Me.btn_execute_multi.Click += New System.EventHandler(Me.btn_execute_multi_Click)
			' 
			' btn_execute_single
			' 
			Me.btn_execute_single.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btn_execute_single.Location = New System.Drawing.Point(201, 12)
			Me.btn_execute_single.Name = "btn_execute_single"
			Me.btn_execute_single.Size = New System.Drawing.Size(106, 43)
			Me.btn_execute_single.TabIndex = 1
			Me.btn_execute_single.Text = "Execute Single Query"
			Me.btn_execute_single.UseVisualStyleBackColor = True
'			Me.btn_execute_single.Click += New System.EventHandler(Me.btn_execute_single_Click)
			' 
			' btn_getnext_multi
			' 
			Me.btn_getnext_multi.Location = New System.Drawing.Point(12, 61)
			Me.btn_getnext_multi.Name = "btn_getnext_multi"
			Me.btn_getnext_multi.Size = New System.Drawing.Size(106, 43)
			Me.btn_getnext_multi.TabIndex = 2
			Me.btn_getnext_multi.Text = "Get Next Rows Multi Query"
			Me.btn_getnext_multi.UseVisualStyleBackColor = True
'			Me.btn_getnext_multi.Click += New System.EventHandler(Me.btn_getnext_multi_Click)
			' 
			' btn_getnext_single
			' 
			Me.btn_getnext_single.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btn_getnext_single.Location = New System.Drawing.Point(201, 61)
			Me.btn_getnext_single.Name = "btn_getnext_single"
			Me.btn_getnext_single.Size = New System.Drawing.Size(106, 43)
			Me.btn_getnext_single.TabIndex = 3
			Me.btn_getnext_single.Text = "Get Next Rows Single Query"
			Me.btn_getnext_single.UseVisualStyleBackColor = True
'			Me.btn_getnext_single.Click += New System.EventHandler(Me.btn_getnext_single_Click)
			' 
			' txt_output
			' 
			Me.txt_output.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txt_output.Location = New System.Drawing.Point(12, 110)
			Me.txt_output.Multiline = True
			Me.txt_output.Name = "txt_output"
			Me.txt_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
			Me.txt_output.Size = New System.Drawing.Size(295, 454)
			Me.txt_output.TabIndex = 4
			' 
			' AsynchronousQueryForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(319, 576)
			Me.Controls.Add(Me.txt_output)
			Me.Controls.Add(Me.btn_getnext_single)
			Me.Controls.Add(Me.btn_getnext_multi)
			Me.Controls.Add(Me.btn_execute_single)
			Me.Controls.Add(Me.btn_execute_multi)
			Me.Name = "AsynchronousQueryForm"
			Me.Text = "Asynchronous Query Sample"
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.AsynchronousQueryForm_FormClosing)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btn_execute_multi As System.Windows.Forms.Button
		Private WithEvents btn_execute_single As System.Windows.Forms.Button
		Private WithEvents btn_getnext_multi As System.Windows.Forms.Button
		Private WithEvents btn_getnext_single As System.Windows.Forms.Button
		Private txt_output As System.Windows.Forms.TextBox
	End Class
End Namespace

