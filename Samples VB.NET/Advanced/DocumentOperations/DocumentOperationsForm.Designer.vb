Namespace DocumentOperations
	Partial Public Class DocumentOperationsForm
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
			Me.label2 = New System.Windows.Forms.Label()
			Me.mtbDocNo = New System.Windows.Forms.MaskedTextBox()
			Me.btnExtract = New System.Windows.Forms.Button()
			Me.btnView = New System.Windows.Forms.Button()
			Me.btnExit = New System.Windows.Forms.Button()
			Me.label3 = New System.Windows.Forms.Label()
			Me.txtExtractPath = New System.Windows.Forms.TextBox()
			Me.btnExtractBrowse = New System.Windows.Forms.Button()
			Me.folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
			Me.txtUpdatePath = New System.Windows.Forms.TextBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.btnUpdateBrowse = New System.Windows.Forms.Button()
			Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
			Me.btnUpdate = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(197, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Please enter a document number below."
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(12, 37)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(44, 13)
			Me.label2.TabIndex = 1
			Me.label2.Text = "DocNo:"
			' 
			' mtbDocNo
			' 
			Me.mtbDocNo.Location = New System.Drawing.Point(92, 34)
			Me.mtbDocNo.Mask = "00000"
			Me.mtbDocNo.Name = "mtbDocNo"
			Me.mtbDocNo.PromptChar = " "c
			Me.mtbDocNo.Size = New System.Drawing.Size(100, 20)
			Me.mtbDocNo.TabIndex = 2
			Me.mtbDocNo.ValidatingType = GetType(Integer)
			' 
			' btnExtract
			' 
			Me.btnExtract.Location = New System.Drawing.Point(12, 145)
			Me.btnExtract.Name = "btnExtract"
			Me.btnExtract.Size = New System.Drawing.Size(75, 23)
			Me.btnExtract.TabIndex = 3
			Me.btnExtract.Text = "Extract"
			Me.btnExtract.UseVisualStyleBackColor = True
'			Me.btnExtract.Click += New System.EventHandler(Me.btnExtract_Click)
			' 
			' btnView
			' 
			Me.btnView.Location = New System.Drawing.Point(93, 145)
			Me.btnView.Name = "btnView"
			Me.btnView.Size = New System.Drawing.Size(75, 23)
			Me.btnView.TabIndex = 4
			Me.btnView.Text = "View"
			Me.btnView.UseVisualStyleBackColor = True
'			Me.btnView.Click += New System.EventHandler(Me.btnView_Click)
			' 
			' btnExit
			' 
			Me.btnExit.Location = New System.Drawing.Point(255, 145)
			Me.btnExit.Name = "btnExit"
			Me.btnExit.Size = New System.Drawing.Size(75, 23)
			Me.btnExit.TabIndex = 5
			Me.btnExit.Text = "Exit"
			Me.btnExit.UseVisualStyleBackColor = True
'			Me.btnExit.Click += New System.EventHandler(Me.btnExit_Click)
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(12, 69)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(59, 13)
			Me.label3.TabIndex = 6
			Me.label3.Text = "Extract To:"
			' 
			' txtExtractPath
			' 
			Me.txtExtractPath.Location = New System.Drawing.Point(92, 66)
			Me.txtExtractPath.Name = "txtExtractPath"
			Me.txtExtractPath.ReadOnly = True
			Me.txtExtractPath.Size = New System.Drawing.Size(244, 20)
			Me.txtExtractPath.TabIndex = 7
			' 
			' btnExtractBrowse
			' 
			Me.btnExtractBrowse.Location = New System.Drawing.Point(338, 64)
			Me.btnExtractBrowse.Name = "btnExtractBrowse"
			Me.btnExtractBrowse.Size = New System.Drawing.Size(40, 23)
			Me.btnExtractBrowse.TabIndex = 8
			Me.btnExtractBrowse.Text = "..."
			Me.btnExtractBrowse.UseVisualStyleBackColor = True
'			Me.btnExtractBrowse.Click += New System.EventHandler(Me.btnExtractBrowse_Click)
			' 
			' txtUpdatePath
			' 
			Me.txtUpdatePath.Location = New System.Drawing.Point(92, 98)
			Me.txtUpdatePath.Name = "txtUpdatePath"
			Me.txtUpdatePath.ReadOnly = True
			Me.txtUpdatePath.Size = New System.Drawing.Size(244, 20)
			Me.txtUpdatePath.TabIndex = 10
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(12, 101)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(70, 13)
			Me.label4.TabIndex = 9
			Me.label4.Text = "Update With:"
			' 
			' btnUpdateBrowse
			' 
			Me.btnUpdateBrowse.Location = New System.Drawing.Point(338, 96)
			Me.btnUpdateBrowse.Name = "btnUpdateBrowse"
			Me.btnUpdateBrowse.Size = New System.Drawing.Size(40, 23)
			Me.btnUpdateBrowse.TabIndex = 11
			Me.btnUpdateBrowse.Text = "..."
			Me.btnUpdateBrowse.UseVisualStyleBackColor = True
'			Me.btnUpdateBrowse.Click += New System.EventHandler(Me.btnUpdateBrowse_Click)
			' 
			' openFileDialog1
			' 
			Me.openFileDialog1.FileName = "openFileDialog1"
			' 
			' btnUpdate
			' 
			Me.btnUpdate.Location = New System.Drawing.Point(174, 145)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
			Me.btnUpdate.TabIndex = 12
			Me.btnUpdate.Text = "Update"
			Me.btnUpdate.UseVisualStyleBackColor = True
'			Me.btnUpdate.Click += New System.EventHandler(Me.btnUpdate_Click)
			' 
			' DocumentOperationsForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(390, 180)
			Me.Controls.Add(Me.btnUpdate)
			Me.Controls.Add(Me.btnUpdateBrowse)
			Me.Controls.Add(Me.txtUpdatePath)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.btnExtractBrowse)
			Me.Controls.Add(Me.txtExtractPath)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.btnExit)
			Me.Controls.Add(Me.btnView)
			Me.Controls.Add(Me.btnExtract)
			Me.Controls.Add(Me.mtbDocNo)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "DocumentOperationsForm"
			Me.Text = "Document Operations"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private mtbDocNo As System.Windows.Forms.MaskedTextBox
		Private WithEvents btnExtract As System.Windows.Forms.Button
		Private WithEvents btnView As System.Windows.Forms.Button
		Private WithEvents btnExit As System.Windows.Forms.Button
		Private label3 As System.Windows.Forms.Label
		Private txtExtractPath As System.Windows.Forms.TextBox
		Private WithEvents btnExtractBrowse As System.Windows.Forms.Button
		Private folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
		Private txtUpdatePath As System.Windows.Forms.TextBox
		Private label4 As System.Windows.Forms.Label
		Private WithEvents btnUpdateBrowse As System.Windows.Forms.Button
		Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
		Private WithEvents btnUpdate As System.Windows.Forms.Button
	End Class
End Namespace

