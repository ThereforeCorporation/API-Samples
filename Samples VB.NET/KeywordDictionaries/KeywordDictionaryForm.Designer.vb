Namespace KeywordDictionaries
	Partial Public Class KeywordDictionaryForm
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
			Me.txt_keydictno = New System.Windows.Forms.TextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.btn_load = New System.Windows.Forms.Button()
			Me.txt_content = New System.Windows.Forms.TextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.txt_deactivate_keyword = New System.Windows.Forms.TextBox()
			Me.btn_deactivate = New System.Windows.Forms.Button()
			Me.btn_delete = New System.Windows.Forms.Button()
			Me.txt_delete_keyword = New System.Windows.Forms.TextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.btn_add = New System.Windows.Forms.Button()
			Me.txt_new_keyword = New System.Windows.Forms.TextBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.btn_save_changes = New System.Windows.Forms.Button()
			Me.btn_delete_at = New System.Windows.Forms.Button()
			Me.txt_delete_at = New System.Windows.Forms.TextBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.btn_rename = New System.Windows.Forms.Button()
			Me.label6 = New System.Windows.Forms.Label()
			Me.txt_rename_from = New System.Windows.Forms.TextBox()
			Me.txt_rename_to = New System.Windows.Forms.TextBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' txt_keydictno
			' 
			Me.txt_keydictno.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txt_keydictno.Location = New System.Drawing.Point(150, 12)
			Me.txt_keydictno.Name = "txt_keydictno"
			Me.txt_keydictno.Size = New System.Drawing.Size(154, 20)
			Me.txt_keydictno.TabIndex = 0
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 15)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(115, 13)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Keyword Dictionary ID:"
			' 
			' btn_load
			' 
			Me.btn_load.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btn_load.Location = New System.Drawing.Point(310, 10)
			Me.btn_load.Name = "btn_load"
			Me.btn_load.Size = New System.Drawing.Size(75, 23)
			Me.btn_load.TabIndex = 4
			Me.btn_load.Text = "Load"
			Me.btn_load.UseVisualStyleBackColor = True
'			Me.btn_load.Click += New System.EventHandler(Me.btn_load_Click)
			' 
			' txt_content
			' 
			Me.txt_content.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txt_content.Location = New System.Drawing.Point(12, 39)
			Me.txt_content.Multiline = True
			Me.txt_content.Name = "txt_content"
			Me.txt_content.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
			Me.txt_content.Size = New System.Drawing.Size(373, 269)
			Me.txt_content.TabIndex = 5
			' 
			' label2
			' 
			Me.label2.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(12, 319)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(120, 13)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Deactivate Keyword ID:"
			' 
			' txt_deactivate_keyword
			' 
			Me.txt_deactivate_keyword.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txt_deactivate_keyword.Location = New System.Drawing.Point(150, 316)
			Me.txt_deactivate_keyword.Name = "txt_deactivate_keyword"
			Me.txt_deactivate_keyword.Size = New System.Drawing.Size(154, 20)
			Me.txt_deactivate_keyword.TabIndex = 7
			' 
			' btn_deactivate
			' 
			Me.btn_deactivate.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btn_deactivate.Location = New System.Drawing.Point(310, 314)
			Me.btn_deactivate.Name = "btn_deactivate"
			Me.btn_deactivate.Size = New System.Drawing.Size(75, 23)
			Me.btn_deactivate.TabIndex = 8
			Me.btn_deactivate.Text = "(De)Activate"
			Me.btn_deactivate.UseVisualStyleBackColor = True
'			Me.btn_deactivate.Click += New System.EventHandler(Me.btn_deactivate_Click)
			' 
			' btn_delete
			' 
			Me.btn_delete.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btn_delete.Location = New System.Drawing.Point(310, 342)
			Me.btn_delete.Name = "btn_delete"
			Me.btn_delete.Size = New System.Drawing.Size(75, 23)
			Me.btn_delete.TabIndex = 11
			Me.btn_delete.Text = "Delete"
			Me.btn_delete.UseVisualStyleBackColor = True
'			Me.btn_delete.Click += New System.EventHandler(Me.btn_delete_Click)
			' 
			' txt_delete_keyword
			' 
			Me.txt_delete_keyword.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txt_delete_keyword.Location = New System.Drawing.Point(150, 344)
			Me.txt_delete_keyword.Name = "txt_delete_keyword"
			Me.txt_delete_keyword.Size = New System.Drawing.Size(154, 20)
			Me.txt_delete_keyword.TabIndex = 10
			' 
			' label3
			' 
			Me.label3.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(12, 347)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(99, 13)
			Me.label3.TabIndex = 9
			Me.label3.Text = "Delete Keyword ID:"
			' 
			' btn_add
			' 
			Me.btn_add.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btn_add.Location = New System.Drawing.Point(310, 398)
			Me.btn_add.Name = "btn_add"
			Me.btn_add.Size = New System.Drawing.Size(75, 23)
			Me.btn_add.TabIndex = 14
			Me.btn_add.Text = "Add"
			Me.btn_add.UseVisualStyleBackColor = True
'			Me.btn_add.Click += New System.EventHandler(Me.btn_add_Click)
			' 
			' txt_new_keyword
			' 
			Me.txt_new_keyword.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txt_new_keyword.Location = New System.Drawing.Point(150, 400)
			Me.txt_new_keyword.Name = "txt_new_keyword"
			Me.txt_new_keyword.Size = New System.Drawing.Size(154, 20)
			Me.txt_new_keyword.TabIndex = 13
			' 
			' label4
			' 
			Me.label4.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(12, 403)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(98, 13)
			Me.label4.TabIndex = 12
			Me.label4.Text = "Add New Keyword:"
			' 
			' btn_save_changes
			' 
			Me.btn_save_changes.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btn_save_changes.Location = New System.Drawing.Point(261, 483)
			Me.btn_save_changes.Name = "btn_save_changes"
			Me.btn_save_changes.Size = New System.Drawing.Size(124, 23)
			Me.btn_save_changes.TabIndex = 15
			Me.btn_save_changes.Text = "Save Changes"
			Me.btn_save_changes.UseVisualStyleBackColor = True
'			Me.btn_save_changes.Click += New System.EventHandler(Me.btn_save_changes_Click)
			' 
			' btn_delete_at
			' 
			Me.btn_delete_at.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btn_delete_at.Location = New System.Drawing.Point(310, 370)
			Me.btn_delete_at.Name = "btn_delete_at"
			Me.btn_delete_at.Size = New System.Drawing.Size(75, 23)
			Me.btn_delete_at.TabIndex = 18
			Me.btn_delete_at.Text = "Delete"
			Me.btn_delete_at.UseVisualStyleBackColor = True
'			Me.btn_delete_at.Click += New System.EventHandler(Me.btn_delete_at_Click)
			' 
			' txt_delete_at
			' 
			Me.txt_delete_at.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txt_delete_at.Location = New System.Drawing.Point(150, 372)
			Me.txt_delete_at.Name = "txt_delete_at"
			Me.txt_delete_at.Size = New System.Drawing.Size(154, 20)
			Me.txt_delete_at.TabIndex = 17
			' 
			' label5
			' 
			Me.label5.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(12, 375)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(126, 13)
			Me.label5.TabIndex = 16
			Me.label5.Text = "Delete Keyword at Index:"
			' 
			' btn_rename
			' 
			Me.btn_rename.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btn_rename.Location = New System.Drawing.Point(310, 427)
			Me.btn_rename.Name = "btn_rename"
			Me.btn_rename.Size = New System.Drawing.Size(75, 23)
			Me.btn_rename.TabIndex = 19
			Me.btn_rename.Text = "Rename"
			Me.btn_rename.UseVisualStyleBackColor = True
'			Me.btn_rename.Click += New System.EventHandler(Me.btn_rename_Click)
			' 
			' label6
			' 
			Me.label6.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(12, 432)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(91, 13)
			Me.label6.TabIndex = 20
			Me.label6.Text = "Change Keyword:"
			' 
			' txt_rename_from
			' 
			Me.txt_rename_from.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txt_rename_from.Location = New System.Drawing.Point(150, 429)
			Me.txt_rename_from.Name = "txt_rename_from"
			Me.txt_rename_from.Size = New System.Drawing.Size(63, 20)
			Me.txt_rename_from.TabIndex = 22
			' 
			' txt_rename_to
			' 
			Me.txt_rename_to.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txt_rename_to.Location = New System.Drawing.Point(241, 429)
			Me.txt_rename_to.Name = "txt_rename_to"
			Me.txt_rename_to.Size = New System.Drawing.Size(63, 20)
			Me.txt_rename_to.TabIndex = 23
			' 
			' label7
			' 
			Me.label7.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(219, 432)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(16, 13)
			Me.label7.TabIndex = 24
			Me.label7.Text = "to"
			' 
			' KeywordDictionaryForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(403, 518)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.txt_rename_to)
			Me.Controls.Add(Me.txt_rename_from)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.btn_rename)
			Me.Controls.Add(Me.btn_delete_at)
			Me.Controls.Add(Me.txt_delete_at)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.btn_save_changes)
			Me.Controls.Add(Me.btn_add)
			Me.Controls.Add(Me.txt_new_keyword)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.btn_delete)
			Me.Controls.Add(Me.txt_delete_keyword)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.btn_deactivate)
			Me.Controls.Add(Me.txt_deactivate_keyword)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.txt_content)
			Me.Controls.Add(Me.btn_load)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.txt_keydictno)
			Me.Name = "KeywordDictionaryForm"
			Me.Text = "Keyword Dictionaries Sample"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private txt_keydictno As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents btn_load As System.Windows.Forms.Button
		Private txt_content As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private txt_deactivate_keyword As System.Windows.Forms.TextBox
		Private WithEvents btn_deactivate As System.Windows.Forms.Button
		Private WithEvents btn_delete As System.Windows.Forms.Button
		Private txt_delete_keyword As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents btn_add As System.Windows.Forms.Button
		Private txt_new_keyword As System.Windows.Forms.TextBox
		Private label4 As System.Windows.Forms.Label
		Private WithEvents btn_save_changes As System.Windows.Forms.Button
		Private WithEvents btn_delete_at As System.Windows.Forms.Button
		Private txt_delete_at As System.Windows.Forms.TextBox
		Private label5 As System.Windows.Forms.Label
		Private WithEvents btn_rename As System.Windows.Forms.Button
		Private label6 As System.Windows.Forms.Label
		Private txt_rename_from As System.Windows.Forms.TextBox
		Private txt_rename_to As System.Windows.Forms.TextBox
		Private label7 As System.Windows.Forms.Label
	End Class
End Namespace

