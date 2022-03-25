Namespace Documents
	Partial Public Class DocumentsForm
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
			Me.btn_archive = New Button()
			Me.btn_retrieve = New Button()
			Me.btn_extract = New Button()
			Me.btn_view = New Button()
			Me.SuspendLayout()
			' 
			' btn_archive
			' 
			Me.btn_archive.Location = New Point(22, 23)
			Me.btn_archive.Name = "btn_archive"
			Me.btn_archive.Size = New Size(90, 40)
			Me.btn_archive.TabIndex = 0
			Me.btn_archive.Text = "Archive Document"
			Me.btn_archive.UseVisualStyleBackColor = True
'			Me.btn_archive.Click += New System.EventHandler(Me.btn_archive_Click)
			' 
			' btn_retrieve
			' 
			Me.btn_retrieve.Location = New Point(151, 22)
			Me.btn_retrieve.Name = "btn_retrieve"
			Me.btn_retrieve.Size = New Size(90, 40)
			Me.btn_retrieve.TabIndex = 1
			Me.btn_retrieve.Text = "Retrieve Document"
			Me.btn_retrieve.UseVisualStyleBackColor = True
'			Me.btn_retrieve.Click += New System.EventHandler(Me.btn_retrieve_Click)
			' 
			' btn_extract
			' 
			Me.btn_extract.Location = New Point(22, 92)
			Me.btn_extract.Name = "btn_extract"
			Me.btn_extract.Size = New Size(90, 40)
			Me.btn_extract.TabIndex = 2
			Me.btn_extract.Text = "Extract Files from Document"
			Me.btn_extract.UseVisualStyleBackColor = True
'			Me.btn_extract.Click += New System.EventHandler(Me.btn_extract_Click)
			' 
			' btn_view
			' 
			Me.btn_view.Location = New Point(151, 92)
			Me.btn_view.Name = "btn_view"
			Me.btn_view.Size = New Size(90, 40)
			Me.btn_view.TabIndex = 3
			Me.btn_view.Text = "View Document"
			Me.btn_view.UseVisualStyleBackColor = True
'			Me.btn_view.Click += New System.EventHandler(Me.btn_view_Click)
			' 
			' DocumentsForm
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.ClientSize = New Size(282, 175)
			Me.Controls.Add(Me.btn_view)
			Me.Controls.Add(Me.btn_extract)
			Me.Controls.Add(Me.btn_retrieve)
			Me.Controls.Add(Me.btn_archive)
			Me.Name = "DocumentsForm"
			Me.Text = "Documents"
'			Me.Load += New System.EventHandler(Me.DocumentsForm_Load)
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.DocumentsForm_FormClosing)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents btn_archive As Button
		Private WithEvents btn_retrieve As Button
		Private WithEvents btn_extract As Button
		Private WithEvents btn_view As Button
	End Class
End Namespace

