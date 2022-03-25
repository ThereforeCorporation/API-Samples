Namespace ArchiveDocuments
	Partial Friend Class ArchiveDocuments
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
			Me.txtPath = New System.Windows.Forms.TextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.btnBrowse = New System.Windows.Forms.Button()
			Me.btnStart = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
			Me.label2 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' txtPath
			' 
			Me.txtPath.Location = New System.Drawing.Point(12, 48)
			Me.txtPath.Name = "txtPath"
			Me.txtPath.ReadOnly = True
			Me.txtPath.Size = New System.Drawing.Size(317, 20)
			Me.txtPath.TabIndex = 0
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(9, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(216, 13)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Please select the root directory for archiving."
			' 
			' btnBrowse
			' 
			Me.btnBrowse.Location = New System.Drawing.Point(329, 47)
			Me.btnBrowse.Name = "btnBrowse"
			Me.btnBrowse.Size = New System.Drawing.Size(38, 23)
			Me.btnBrowse.TabIndex = 2
			Me.btnBrowse.Text = "..."
			Me.btnBrowse.UseVisualStyleBackColor = True
'			Me.btnBrowse.Click += New System.EventHandler(Me.btnBrowse_Click)
			' 
			' btnStart
			' 
			Me.btnStart.Location = New System.Drawing.Point(12, 92)
			Me.btnStart.Name = "btnStart"
			Me.btnStart.Size = New System.Drawing.Size(75, 23)
			Me.btnStart.TabIndex = 3
			Me.btnStart.Text = "Start"
			Me.btnStart.UseVisualStyleBackColor = True
'			Me.btnStart.Click += New System.EventHandler(Me.btnStart_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.Location = New System.Drawing.Point(93, 92)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 4
			Me.btnCancel.Text = "Cancel"
			Me.btnCancel.UseVisualStyleBackColor = True
'			Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click)
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(9, 25)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(225, 13)
			Me.label2.TabIndex = 5
			Me.label2.Text = "All documents in this directory will be archived."
			' 
			' ArchiveDocuments
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(381, 127)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnStart)
			Me.Controls.Add(Me.btnBrowse)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.txtPath)
			Me.Name = "ArchiveDocuments"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Archive Documents"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private txtPath As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents btnBrowse As System.Windows.Forms.Button
		Private WithEvents btnStart As System.Windows.Forms.Button
		Private WithEvents btnCancel As System.Windows.Forms.Button
		Private folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
		Private label2 As System.Windows.Forms.Label
	End Class
End Namespace

