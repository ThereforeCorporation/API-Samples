Namespace TableDataType
	Partial Public Class TableForm
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
			Me.dgv_table_data = New System.Windows.Forms.DataGridView()
			Me.txt_docno = New System.Windows.Forms.TextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.btn_load = New System.Windows.Forms.Button()
			Me.btn_save = New System.Windows.Forms.Button()
			CType(Me.dgv_table_data, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' dgv_table_data
			' 
			Me.dgv_table_data.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.dgv_table_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgv_table_data.Location = New System.Drawing.Point(13, 42)
			Me.dgv_table_data.Name = "dgv_table_data"
			Me.dgv_table_data.Size = New System.Drawing.Size(422, 249)
			Me.dgv_table_data.TabIndex = 0
			' 
			' txt_docno
			' 
			Me.txt_docno.Location = New System.Drawing.Point(69, 13)
			Me.txt_docno.Name = "txt_docno"
			Me.txt_docno.Size = New System.Drawing.Size(100, 20)
			Me.txt_docno.TabIndex = 1
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(44, 13)
			Me.label1.TabIndex = 2
			Me.label1.Text = "DocNo:"
			' 
			' btn_load
			' 
			Me.btn_load.Location = New System.Drawing.Point(175, 13)
			Me.btn_load.Name = "btn_load"
			Me.btn_load.Size = New System.Drawing.Size(75, 23)
			Me.btn_load.TabIndex = 3
			Me.btn_load.Text = "Load"
			Me.btn_load.UseVisualStyleBackColor = True
'			Me.btn_load.Click += New System.EventHandler(Me.btn_load_Click)
			' 
			' btn_save
			' 
			Me.btn_save.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btn_save.Location = New System.Drawing.Point(360, 12)
			Me.btn_save.Name = "btn_save"
			Me.btn_save.Size = New System.Drawing.Size(75, 23)
			Me.btn_save.TabIndex = 4
			Me.btn_save.Text = "Save"
			Me.btn_save.UseVisualStyleBackColor = True
'			Me.btn_save.Click += New System.EventHandler(Me.btn_save_Click)
			' 
			' TableForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(447, 303)
			Me.Controls.Add(Me.btn_save)
			Me.Controls.Add(Me.btn_load)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.txt_docno)
			Me.Controls.Add(Me.dgv_table_data)
			Me.Name = "TableForm"
			Me.Text = "Table Data Type"
			CType(Me.dgv_table_data, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private dgv_table_data As System.Windows.Forms.DataGridView
		Private txt_docno As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents btn_load As System.Windows.Forms.Button
		Private WithEvents btn_save As System.Windows.Forms.Button
	End Class
End Namespace

