Namespace IndexData
	Partial Public Class IndexDataForm
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
			Me.btn_read = New Button()
			Me.btn_save = New Button()
			Me.txt_output = New TextBox()
			Me.SuspendLayout()
			' 
			' btn_read
			' 
			Me.btn_read.Location = New Point(12, 12)
			Me.btn_read.Name = "btn_read"
			Me.btn_read.Size = New Size(90, 40)
			Me.btn_read.TabIndex = 0
			Me.btn_read.Text = "Read"
			Me.btn_read.UseVisualStyleBackColor = True
'			Me.btn_read.Click += New System.EventHandler(Me.btn_read_Click)
			' 
			' btn_save
			' 
			Me.btn_save.Location = New Point(182, 12)
			Me.btn_save.Name = "btn_save"
			Me.btn_save.Size = New Size(90, 40)
			Me.btn_save.TabIndex = 1
			Me.btn_save.Text = "Save"
			Me.btn_save.UseVisualStyleBackColor = True
'			Me.btn_save.Click += New System.EventHandler(Me.btn_save_Click)
			' 
			' txt_output
			' 
			Me.txt_output.Location = New Point(12, 81)
			Me.txt_output.Multiline = True
			Me.txt_output.Name = "txt_output"
			Me.txt_output.ReadOnly = True
			Me.txt_output.Size = New Size(260, 169)
			Me.txt_output.TabIndex = 2
			' 
			' IndexDataForm
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.ClientSize = New Size(284, 262)
			Me.Controls.Add(Me.txt_output)
			Me.Controls.Add(Me.btn_save)
			Me.Controls.Add(Me.btn_read)
			Me.Name = "IndexDataForm"
			Me.Text = "Index Data"
'			Me.Load += New System.EventHandler(Me.IndexDataForm_Load)
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.IndexDataForm_FormClosing)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btn_read As Button
		Private WithEvents btn_save As Button
		Private txt_output As TextBox
	End Class
End Namespace

