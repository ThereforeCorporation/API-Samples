Namespace AccessMask
	Partial Public Class AccessMaskForm
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
			Me.cmb_objtype = New System.Windows.Forms.ComboBox()
			Me.txt_objno = New System.Windows.Forms.TextBox()
			Me.txt_subobjno = New System.Windows.Forms.TextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.btn_load = New System.Windows.Forms.Button()
			Me.txt_output = New System.Windows.Forms.TextBox()
			Me.btn_am2pl = New System.Windows.Forms.Button()
			Me.btn_pl2am = New System.Windows.Forms.Button()
			Me.btn_getobjects = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' cmb_objtype
			' 
			Me.cmb_objtype.FormattingEnabled = True
			Me.cmb_objtype.Location = New System.Drawing.Point(86, 12)
			Me.cmb_objtype.Name = "cmb_objtype"
			Me.cmb_objtype.Size = New System.Drawing.Size(140, 21)
			Me.cmb_objtype.TabIndex = 0
			' 
			' txt_objno
			' 
			Me.txt_objno.Location = New System.Drawing.Point(86, 38)
			Me.txt_objno.Name = "txt_objno"
			Me.txt_objno.Size = New System.Drawing.Size(62, 20)
			Me.txt_objno.TabIndex = 1
			Me.txt_objno.Text = "0"
			' 
			' txt_subobjno
			' 
			Me.txt_subobjno.Location = New System.Drawing.Point(86, 64)
			Me.txt_subobjno.Name = "txt_subobjno"
			Me.txt_subobjno.Size = New System.Drawing.Size(62, 20)
			Me.txt_subobjno.TabIndex = 2
			Me.txt_subobjno.Text = "0"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 15)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(68, 13)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Object Type:"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(12, 41)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(55, 13)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Object ID:"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(12, 67)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(74, 13)
			Me.label3.TabIndex = 5
			Me.label3.Text = "SubObject ID:"
			' 
			' btn_load
			' 
			Me.btn_load.Location = New System.Drawing.Point(11, 100)
			Me.btn_load.Name = "btn_load"
			Me.btn_load.Size = New System.Drawing.Size(95, 35)
			Me.btn_load.TabIndex = 6
			Me.btn_load.Text = "Load AccessMask"
			Me.btn_load.UseVisualStyleBackColor = True
'			Me.btn_load.Click += New System.EventHandler(Me.btn_load_Click)
			' 
			' txt_output
			' 
			Me.txt_output.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txt_output.Location = New System.Drawing.Point(12, 141)
			Me.txt_output.Multiline = True
			Me.txt_output.Name = "txt_output"
			Me.txt_output.ReadOnly = True
			Me.txt_output.ScrollBars = System.Windows.Forms.ScrollBars.Both
			Me.txt_output.Size = New System.Drawing.Size(331, 274)
			Me.txt_output.TabIndex = 7
			' 
			' btn_am2pl
			' 
			Me.btn_am2pl.Location = New System.Drawing.Point(131, 100)
			Me.btn_am2pl.Name = "btn_am2pl"
			Me.btn_am2pl.Size = New System.Drawing.Size(95, 35)
			Me.btn_am2pl.TabIndex = 8
			Me.btn_am2pl.Text = "AccessMask to PermissionList"
			Me.btn_am2pl.UseVisualStyleBackColor = True
'			Me.btn_am2pl.Click += New System.EventHandler(Me.btn_am2pl_Click)
			' 
			' btn_pl2am
			' 
			Me.btn_pl2am.Location = New System.Drawing.Point(248, 100)
			Me.btn_pl2am.Name = "btn_pl2am"
			Me.btn_pl2am.Size = New System.Drawing.Size(95, 35)
			Me.btn_pl2am.TabIndex = 9
			Me.btn_pl2am.Text = "PermissionList to AccessMask"
			Me.btn_pl2am.UseVisualStyleBackColor = True
'			Me.btn_pl2am.Click += New System.EventHandler(Me.btn_pl2am_Click)
			' 
			' btn_getobjects
			' 
			Me.btn_getobjects.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btn_getobjects.Location = New System.Drawing.Point(268, 10)
			Me.btn_getobjects.Name = "btn_getobjects"
			Me.btn_getobjects.Size = New System.Drawing.Size(75, 23)
			Me.btn_getobjects.TabIndex = 10
			Me.btn_getobjects.Text = "GetObjects"
			Me.btn_getobjects.UseVisualStyleBackColor = True
'			Me.btn_getobjects.Click += New System.EventHandler(Me.btn_getobjects_Click)
			' 
			' AccessMaskForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(358, 431)
			Me.Controls.Add(Me.btn_getobjects)
			Me.Controls.Add(Me.btn_pl2am)
			Me.Controls.Add(Me.btn_am2pl)
			Me.Controls.Add(Me.txt_output)
			Me.Controls.Add(Me.btn_load)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.txt_subobjno)
			Me.Controls.Add(Me.txt_objno)
			Me.Controls.Add(Me.cmb_objtype)
			Me.Name = "AccessMaskForm"
			Me.Text = "AccessMask Form"
'			Me.Load += New System.EventHandler(Me.AccesMaskForm_Load)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private cmb_objtype As System.Windows.Forms.ComboBox
		Private txt_objno As System.Windows.Forms.TextBox
		Private txt_subobjno As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents btn_load As System.Windows.Forms.Button
		Private txt_output As System.Windows.Forms.TextBox
		Private WithEvents btn_am2pl As System.Windows.Forms.Button
		Private WithEvents btn_pl2am As System.Windows.Forms.Button
		Private WithEvents btn_getobjects As System.Windows.Forms.Button
	End Class
End Namespace

