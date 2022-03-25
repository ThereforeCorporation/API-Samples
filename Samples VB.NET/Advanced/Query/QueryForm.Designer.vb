Namespace Query
	Partial Public Class QueryForm
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
			Me.label1 = New Label()
			Me.label2 = New Label()
			Me.label3 = New Label()
			Me.label4 = New Label()
			Me.txtFileName = New TextBox()
			Me.txtExtension = New TextBox()
			Me.txtFolder = New TextBox()
			Me.maskedTextBoxDate = New MaskedTextBox()
			Me.btnSearch = New Button()
			Me.btnExit = New Button()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New Point(12, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New Size(51, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "FileName"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New Point(12, 37)
			Me.label2.Name = "label2"
			Me.label2.Size = New Size(53, 13)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Extension"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New Point(12, 63)
			Me.label3.Name = "label3"
			Me.label3.Size = New Size(36, 13)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Folder"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New Point(13, 89)
			Me.label4.Name = "label4"
			Me.label4.Size = New Size(30, 13)
			Me.label4.TabIndex = 3
			Me.label4.Text = "Date"
			' 
			' txtFileName
			' 
			Me.txtFileName.Location = New Point(85, 6)
			Me.txtFileName.Name = "txtFileName"
			Me.txtFileName.Size = New Size(160, 20)
			Me.txtFileName.TabIndex = 4
			' 
			' txtExtension
			' 
			Me.txtExtension.Location = New Point(85, 33)
			Me.txtExtension.Name = "txtExtension"
			Me.txtExtension.Size = New Size(52, 20)
			Me.txtExtension.TabIndex = 5
			' 
			' txtFolder
			' 
			Me.txtFolder.Location = New Point(85, 59)
			Me.txtFolder.Name = "txtFolder"
			Me.txtFolder.Size = New Size(160, 20)
			Me.txtFolder.TabIndex = 6
			' 
			' maskedTextBoxDate
			' 
			Me.maskedTextBoxDate.Location = New Point(85, 87)
			Me.maskedTextBoxDate.Mask = "00/00/0000"
			Me.maskedTextBoxDate.Name = "maskedTextBoxDate"
			Me.maskedTextBoxDate.Size = New Size(83, 20)
			Me.maskedTextBoxDate.TabIndex = 7
			Me.maskedTextBoxDate.ValidatingType = GetType(Date)
			' 
			' btnSearch
			' 
			Me.btnSearch.Location = New Point(12, 128)
			Me.btnSearch.Name = "btnSearch"
			Me.btnSearch.Size = New Size(75, 23)
			Me.btnSearch.TabIndex = 8
			Me.btnSearch.Text = "Search"
			Me.btnSearch.UseVisualStyleBackColor = True
'			Me.btnSearch.Click += New System.EventHandler(Me.btnSearch_Click)
			' 
			' btnExit
			' 
			Me.btnExit.Location = New Point(93, 128)
			Me.btnExit.Name = "btnExit"
			Me.btnExit.Size = New Size(75, 23)
			Me.btnExit.TabIndex = 9
			Me.btnExit.Text = "Exit"
			Me.btnExit.UseVisualStyleBackColor = True
'			Me.btnExit.Click += New System.EventHandler(Me.btnExit_Click)
			' 
			' QueryForm
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.ClientSize = New Size(383, 163)
			Me.Controls.Add(Me.btnExit)
			Me.Controls.Add(Me.btnSearch)
			Me.Controls.Add(Me.maskedTextBoxDate)
			Me.Controls.Add(Me.txtFolder)
			Me.Controls.Add(Me.txtExtension)
			Me.Controls.Add(Me.txtFileName)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "QueryForm"
			Me.Text = "Exercise 3"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As Label
		Private label2 As Label
		Private label3 As Label
		Private label4 As Label
		Private txtFileName As TextBox
		Private txtExtension As TextBox
		Private txtFolder As TextBox
		Private maskedTextBoxDate As MaskedTextBox
		Private WithEvents btnSearch As Button
		Private WithEvents btnExit As Button
	End Class
End Namespace

