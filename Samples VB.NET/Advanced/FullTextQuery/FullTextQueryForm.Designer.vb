Namespace FullTextQuery
	Partial Public Class FullTextQueryForm
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
			Me.txtQuery = New System.Windows.Forms.TextBox()
			Me.btnExecute = New System.Windows.Forms.Button()
			Me.btnExit = New System.Windows.Forms.Button()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.txt_fuzzysearch = New System.Windows.Forms.TextBox()
			Me.cmb_sortorder = New System.Windows.Forms.ComboBox()
			Me.chk_thesaurus = New System.Windows.Forms.CheckBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(194, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Please enter your FullText Query below."
			' 
			' txtQuery
			' 
			Me.txtQuery.Location = New System.Drawing.Point(15, 37)
			Me.txtQuery.Name = "txtQuery"
			Me.txtQuery.Size = New System.Drawing.Size(241, 20)
			Me.txtQuery.TabIndex = 1
			' 
			' btnExecute
			' 
			Me.btnExecute.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.btnExecute.Location = New System.Drawing.Point(11, 161)
			Me.btnExecute.Name = "btnExecute"
			Me.btnExecute.Size = New System.Drawing.Size(75, 23)
			Me.btnExecute.TabIndex = 2
			Me.btnExecute.Text = "Execute"
			Me.btnExecute.UseVisualStyleBackColor = True
'			Me.btnExecute.Click += New System.EventHandler(Me.btnExecute_Click)
			' 
			' btnExit
			' 
			Me.btnExit.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.btnExit.Location = New System.Drawing.Point(92, 161)
			Me.btnExit.Name = "btnExit"
			Me.btnExit.Size = New System.Drawing.Size(75, 23)
			Me.btnExit.TabIndex = 3
			Me.btnExit.Text = "Exit"
			Me.btnExit.UseVisualStyleBackColor = True
'			Me.btnExit.Click += New System.EventHandler(Me.btnExit_Click)
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(12, 71)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(58, 13)
			Me.label3.TabIndex = 5
			Me.label3.Text = "Sort Order:"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(12, 101)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(127, 13)
			Me.label4.TabIndex = 6
			Me.label4.Text = "Fuzzy Search Level (0-5):"
			' 
			' txt_fuzzysearch
			' 
			Me.txt_fuzzysearch.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txt_fuzzysearch.Location = New System.Drawing.Point(179, 98)
			Me.txt_fuzzysearch.Name = "txt_fuzzysearch"
			Me.txt_fuzzysearch.Size = New System.Drawing.Size(77, 20)
			Me.txt_fuzzysearch.TabIndex = 8
			' 
			' cmb_sortorder
			' 
			Me.cmb_sortorder.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cmb_sortorder.FormattingEnabled = True
			Me.cmb_sortorder.Location = New System.Drawing.Point(140, 68)
			Me.cmb_sortorder.Name = "cmb_sortorder"
			Me.cmb_sortorder.Size = New System.Drawing.Size(116, 21)
			Me.cmb_sortorder.TabIndex = 10
			' 
			' chk_thesaurus
			' 
			Me.chk_thesaurus.AutoSize = True
			Me.chk_thesaurus.Location = New System.Drawing.Point(15, 127)
			Me.chk_thesaurus.Name = "chk_thesaurus"
			Me.chk_thesaurus.Size = New System.Drawing.Size(98, 17)
			Me.chk_thesaurus.TabIndex = 13
			Me.chk_thesaurus.Text = "Use Thesaurus"
			Me.chk_thesaurus.UseVisualStyleBackColor = True
			' 
			' FullTextQueryForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(268, 196)
			Me.Controls.Add(Me.chk_thesaurus)
			Me.Controls.Add(Me.cmb_sortorder)
			Me.Controls.Add(Me.txt_fuzzysearch)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.btnExit)
			Me.Controls.Add(Me.btnExecute)
			Me.Controls.Add(Me.txtQuery)
			Me.Controls.Add(Me.label1)
			Me.Name = "FullTextQueryForm"
			Me.Text = "Full-Text Query"
'			Me.Load += New System.EventHandler(Me.FullTextQueryForm_Load)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private txtQuery As System.Windows.Forms.TextBox
		Private WithEvents btnExecute As System.Windows.Forms.Button
		Private WithEvents btnExit As System.Windows.Forms.Button
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private txt_fuzzysearch As System.Windows.Forms.TextBox
		Private cmb_sortorder As System.Windows.Forms.ComboBox
		Private chk_thesaurus As System.Windows.Forms.CheckBox
	End Class
End Namespace

