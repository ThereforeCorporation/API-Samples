Namespace NavigatorFind
	Partial Public Class NavigatorFindForm
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
			Me.btnFind = New Button()
			Me.txtFolder = New TextBox()
			Me.label1 = New Label()
			Me.label2 = New Label()
			Me.cmbExtension = New ComboBox()
			Me.SuspendLayout()
			' 
			' btnFind
			' 
			Me.btnFind.Location = New Point(85, 117)
			Me.btnFind.Name = "btnFind"
			Me.btnFind.Size = New Size(75, 23)
			Me.btnFind.TabIndex = 0
			Me.btnFind.Text = "Find"
			Me.btnFind.UseVisualStyleBackColor = True
'			Me.btnFind.Click += New System.EventHandler(Me.btnFind_Click)
			' 
			' txtFolder
			' 
			Me.txtFolder.Location = New Point(85, 72)
			Me.txtFolder.Name = "txtFolder"
			Me.txtFolder.Size = New Size(100, 20)
			Me.txtFolder.TabIndex = 2
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New Point(12, 33)
			Me.label1.Name = "label1"
			Me.label1.Size = New Size(53, 13)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Extension"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New Point(12, 75)
			Me.label2.Name = "label2"
			Me.label2.Size = New Size(36, 13)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Folder"
			' 
			' cmbExtension
			' 
			Me.cmbExtension.FormattingEnabled = True
			Me.cmbExtension.Items.AddRange(New Object() { "doc", "docx", "ppt", "pptx", "xls", "xlsx", "pdf", "tif", "png", "jpg", "jpeg", "txt"})
			Me.cmbExtension.Location = New Point(85, 33)
			Me.cmbExtension.Name = "cmbExtension"
			Me.cmbExtension.Size = New Size(100, 21)
			Me.cmbExtension.TabIndex = 5
			' 
			' NavigatorFindForm
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.ClientSize = New Size(229, 167)
			Me.Controls.Add(Me.cmbExtension)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.txtFolder)
			Me.Controls.Add(Me.btnFind)
			Me.Name = "NavigatorFindForm"
			Me.Text = "NavigatorFind"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btnFind As Button
		Private txtFolder As TextBox
		Private label1 As Label
		Private label2 As Label
		Private cmbExtension As ComboBox
	End Class
End Namespace

