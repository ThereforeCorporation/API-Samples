Namespace Capture
	Partial Public Class CaptureForm
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
			Me.btnScan = New Button()
			Me.btnArchive = New Button()
			Me.txtFilename = New TextBox()
			Me.txtFolder = New TextBox()
			Me.label1 = New Label()
			Me.label2 = New Label()
			Me.label3 = New Label()
			Me.ckbInstantArchive = New CheckBox()
			Me.SuspendLayout()
			' 
			' btnScan
			' 
			Me.btnScan.Location = New Point(12, 156)
			Me.btnScan.Name = "btnScan"
			Me.btnScan.Size = New Size(100, 40)
			Me.btnScan.TabIndex = 0
			Me.btnScan.Text = "Scan"
			Me.btnScan.UseVisualStyleBackColor = True
'			Me.btnScan.Click += New System.EventHandler(Me.btnScan_Click)
			' 
			' btnArchive
			' 
			Me.btnArchive.Location = New Point(172, 156)
			Me.btnArchive.Name = "btnArchive"
			Me.btnArchive.Size = New Size(100, 40)
			Me.btnArchive.TabIndex = 1
			Me.btnArchive.Text = "Archive"
			Me.btnArchive.UseVisualStyleBackColor = True
'			Me.btnArchive.Click += New System.EventHandler(Me.btnArchive_Click)
			' 
			' txtFilename
			' 
			Me.txtFilename.Location = New Point(80, 61)
			Me.txtFilename.MaxLength = 100
			Me.txtFilename.Name = "txtFilename"
			Me.txtFilename.Size = New Size(192, 20)
			Me.txtFilename.TabIndex = 2
			' 
			' txtFolder
			' 
			Me.txtFolder.Location = New Point(80, 91)
			Me.txtFolder.MaxLength = 200
			Me.txtFolder.Name = "txtFolder"
			Me.txtFolder.Size = New Size(192, 20)
			Me.txtFolder.TabIndex = 3
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New Point(12, 64)
			Me.label1.Name = "label1"
			Me.label1.Size = New Size(49, 13)
			Me.label1.TabIndex = 5
			Me.label1.Text = "Filename"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New Point(12, 94)
			Me.label2.Name = "label2"
			Me.label2.Size = New Size(62, 13)
			Me.label2.TabIndex = 6
			Me.label2.Text = "From Folder"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New Point(12, 9)
			Me.label3.Name = "label3"
			Me.label3.Size = New Size(264, 39)
			Me.label3.TabIndex = 7
			Me.label3.Text = "This Example will use the ""Files"" Category. Enter Index" & vbCrLf & " Data below. Index Data " & "fields Extension and Creation" & vbCrLf & " Date will be set automatically."
			' 
			' ckbInstantArchive
			' 
			Me.ckbInstantArchive.AutoSize = True
			Me.ckbInstantArchive.Location = New Point(12, 126)
			Me.ckbInstantArchive.Name = "ckbInstantArchive"
			Me.ckbInstantArchive.Size = New Size(244, 17)
			Me.ckbInstantArchive.TabIndex = 8
			Me.ckbInstantArchive.Text = "Archive Document immediately after scanning."
			Me.ckbInstantArchive.UseVisualStyleBackColor = True
			' 
			' CaptureForm
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.ClientSize = New Size(284, 208)
			Me.Controls.Add(Me.ckbInstantArchive)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.txtFolder)
			Me.Controls.Add(Me.txtFilename)
			Me.Controls.Add(Me.btnArchive)
			Me.Controls.Add(Me.btnScan)
			Me.Name = "CaptureForm"
			Me.Text = "CaptureScan & Archive"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btnScan As Button
		Private WithEvents btnArchive As Button
		Private txtFilename As TextBox
		Private txtFolder As TextBox
		Private label1 As Label
		Private label2 As Label
		Private label3 As Label
		Private ckbInstantArchive As CheckBox
	End Class
End Namespace

