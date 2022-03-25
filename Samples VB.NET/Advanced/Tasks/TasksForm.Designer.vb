Namespace Tasks
	Partial Public Class TasksForm
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
			Me.btn_loadtaskinfo = New System.Windows.Forms.Button()
			Me.txt_taskID = New System.Windows.Forms.TextBox()
			Me.lbl_taskID = New System.Windows.Forms.Label()
			Me.btn_startnew = New System.Windows.Forms.Button()
			Me.btn_update_info = New System.Windows.Forms.Button()
			Me.btn_complete = New System.Windows.Forms.Button()
			Me.btn_view = New System.Windows.Forms.Button()
			Me.lbl_docno = New System.Windows.Forms.Label()
			Me.lbl_mode = New System.Windows.Forms.Label()
			Me.lbl_createdby = New System.Windows.Forms.Label()
			Me.lbl_assignedto = New System.Windows.Forms.Label()
			Me.lbl_lastupdate = New System.Windows.Forms.Label()
			Me.lbl_createdbyuser = New System.Windows.Forms.Label()
			Me.lbl_assignedtouser = New System.Windows.Forms.Label()
			Me.lbl_subject = New System.Windows.Forms.Label()
			Me.lbl_startdate = New System.Windows.Forms.Label()
			Me.lbl_duedate = New System.Windows.Forms.Label()
			Me.lbl_instructions = New System.Windows.Forms.Label()
			Me.lbl_usernoassigned = New System.Windows.Forms.Label()
			Me.txt_docno_info = New System.Windows.Forms.TextBox()
			Me.txt_mode_info = New System.Windows.Forms.TextBox()
			Me.txt_createdby = New System.Windows.Forms.TextBox()
			Me.txt_assignedto = New System.Windows.Forms.TextBox()
			Me.txt_createdbyuser = New System.Windows.Forms.TextBox()
			Me.txt_assignedtouser = New System.Windows.Forms.TextBox()
			Me.txt_subject_info = New System.Windows.Forms.TextBox()
			Me.txt_lastupdate = New System.Windows.Forms.TextBox()
			Me.txt_startdate_info = New System.Windows.Forms.TextBox()
			Me.txt_duedate_info = New System.Windows.Forms.TextBox()
			Me.txt_instructions_info = New System.Windows.Forms.TextBox()
			Me.txt_usernoassigned = New System.Windows.Forms.TextBox()
			Me.txt_comment = New System.Windows.Forms.TextBox()
			Me.lbl_comment = New System.Windows.Forms.Label()
			Me.btn_loadtaskdefinition = New System.Windows.Forms.Button()
			Me.btn_addusers = New System.Windows.Forms.Button()
			Me.txt_instructions_def = New System.Windows.Forms.TextBox()
			Me.txt_duedate_def = New System.Windows.Forms.TextBox()
			Me.txt_startdate_def = New System.Windows.Forms.TextBox()
			Me.txt_subject_def = New System.Windows.Forms.TextBox()
			Me.txt_assignto = New System.Windows.Forms.TextBox()
			Me.txt_userno = New System.Windows.Forms.TextBox()
			Me.txt_mode_def = New System.Windows.Forms.TextBox()
			Me.txt_docno_def = New System.Windows.Forms.TextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.lbl_assignto = New System.Windows.Forms.Label()
			Me.lbl_userno = New System.Windows.Forms.Label()
			Me.label12 = New System.Windows.Forms.Label()
			Me.label13 = New System.Windows.Forms.Label()
			Me.gbx_taskinfo = New System.Windows.Forms.GroupBox()
			Me.txt_decision = New System.Windows.Forms.TextBox()
			Me.lbl_decision = New System.Windows.Forms.Label()
			Me.lbl_status = New System.Windows.Forms.Label()
			Me.txt_status = New System.Windows.Forms.TextBox()
			Me.gbx_taskdefinition = New System.Windows.Forms.GroupBox()
			Me.btn_update_def = New System.Windows.Forms.Button()
			Me.chk_notifyusers = New System.Windows.Forms.CheckBox()
			Me.chk_notifiyonupdate = New System.Windows.Forms.CheckBox()
			Me.gbx_taskinfo.SuspendLayout()
			Me.gbx_taskdefinition.SuspendLayout()
			Me.SuspendLayout()
			' 
			' btn_loadtaskinfo
			' 
			Me.btn_loadtaskinfo.Location = New System.Drawing.Point(198, 12)
			Me.btn_loadtaskinfo.Name = "btn_loadtaskinfo"
			Me.btn_loadtaskinfo.Size = New System.Drawing.Size(94, 23)
			Me.btn_loadtaskinfo.TabIndex = 0
			Me.btn_loadtaskinfo.Text = "Load Task Info"
			Me.btn_loadtaskinfo.UseVisualStyleBackColor = True
'			Me.btn_loadtaskinfo.Click += New System.EventHandler(Me.btn_loadtaskinfo_Click)
			' 
			' txt_taskID
			' 
			Me.txt_taskID.Location = New System.Drawing.Point(78, 14)
			Me.txt_taskID.Name = "txt_taskID"
			Me.txt_taskID.Size = New System.Drawing.Size(100, 20)
			Me.txt_taskID.TabIndex = 1
			' 
			' lbl_taskID
			' 
			Me.lbl_taskID.AutoSize = True
			Me.lbl_taskID.Location = New System.Drawing.Point(19, 17)
			Me.lbl_taskID.Name = "lbl_taskID"
			Me.lbl_taskID.Size = New System.Drawing.Size(48, 13)
			Me.lbl_taskID.TabIndex = 2
			Me.lbl_taskID.Text = "Task ID:"
			' 
			' btn_startnew
			' 
			Me.btn_startnew.Location = New System.Drawing.Point(6, 306)
			Me.btn_startnew.Name = "btn_startnew"
			Me.btn_startnew.Size = New System.Drawing.Size(75, 23)
			Me.btn_startnew.TabIndex = 3
			Me.btn_startnew.Text = "Start New"
			Me.btn_startnew.UseVisualStyleBackColor = True
'			Me.btn_startnew.Click += New System.EventHandler(Me.btn_startnew_Click)
			' 
			' btn_update_info
			' 
			Me.btn_update_info.Location = New System.Drawing.Point(91, 428)
			Me.btn_update_info.Name = "btn_update_info"
			Me.btn_update_info.Size = New System.Drawing.Size(75, 23)
			Me.btn_update_info.TabIndex = 4
			Me.btn_update_info.Text = "Update"
			Me.btn_update_info.UseVisualStyleBackColor = True
'			Me.btn_update_info.Click += New System.EventHandler(Me.btn_update_info_Click)
			' 
			' btn_complete
			' 
			Me.btn_complete.Location = New System.Drawing.Point(10, 428)
			Me.btn_complete.Name = "btn_complete"
			Me.btn_complete.Size = New System.Drawing.Size(75, 23)
			Me.btn_complete.TabIndex = 6
			Me.btn_complete.Text = "Complete"
			Me.btn_complete.UseVisualStyleBackColor = True
'			Me.btn_complete.Click += New System.EventHandler(Me.btn_complete_Click)
			' 
			' btn_view
			' 
			Me.btn_view.Location = New System.Drawing.Point(298, 12)
			Me.btn_view.Name = "btn_view"
			Me.btn_view.Size = New System.Drawing.Size(75, 23)
			Me.btn_view.TabIndex = 7
			Me.btn_view.Text = "View"
			Me.btn_view.UseVisualStyleBackColor = True
'			Me.btn_view.Click += New System.EventHandler(Me.btn_view_Click)
			' 
			' lbl_docno
			' 
			Me.lbl_docno.AutoSize = True
			Me.lbl_docno.Location = New System.Drawing.Point(16, 23)
			Me.lbl_docno.Name = "lbl_docno"
			Me.lbl_docno.Size = New System.Drawing.Size(44, 13)
			Me.lbl_docno.TabIndex = 8
			Me.lbl_docno.Text = "DocNo:"
			' 
			' lbl_mode
			' 
			Me.lbl_mode.AutoSize = True
			Me.lbl_mode.Location = New System.Drawing.Point(16, 49)
			Me.lbl_mode.Name = "lbl_mode"
			Me.lbl_mode.Size = New System.Drawing.Size(37, 13)
			Me.lbl_mode.TabIndex = 9
			Me.lbl_mode.Text = "Mode:"
			' 
			' lbl_createdby
			' 
			Me.lbl_createdby.AutoSize = True
			Me.lbl_createdby.Location = New System.Drawing.Point(16, 75)
			Me.lbl_createdby.Name = "lbl_createdby"
			Me.lbl_createdby.Size = New System.Drawing.Size(61, 13)
			Me.lbl_createdby.TabIndex = 10
			Me.lbl_createdby.Text = "Created by:"
			' 
			' lbl_assignedto
			' 
			Me.lbl_assignedto.AutoSize = True
			Me.lbl_assignedto.Location = New System.Drawing.Point(16, 101)
			Me.lbl_assignedto.Name = "lbl_assignedto"
			Me.lbl_assignedto.Size = New System.Drawing.Size(65, 13)
			Me.lbl_assignedto.TabIndex = 11
			Me.lbl_assignedto.Text = "Assigned to:"
			' 
			' lbl_lastupdate
			' 
			Me.lbl_lastupdate.AutoSize = True
			Me.lbl_lastupdate.Location = New System.Drawing.Point(16, 127)
			Me.lbl_lastupdate.Name = "lbl_lastupdate"
			Me.lbl_lastupdate.Size = New System.Drawing.Size(66, 13)
			Me.lbl_lastupdate.TabIndex = 12
			Me.lbl_lastupdate.Text = "Last update:"
			' 
			' lbl_createdbyuser
			' 
			Me.lbl_createdbyuser.AutoSize = True
			Me.lbl_createdbyuser.Location = New System.Drawing.Point(16, 153)
			Me.lbl_createdbyuser.Name = "lbl_createdbyuser"
			Me.lbl_createdbyuser.Size = New System.Drawing.Size(84, 13)
			Me.lbl_createdbyuser.TabIndex = 13
			Me.lbl_createdbyuser.Text = "Created by user:"
			' 
			' lbl_assignedtouser
			' 
			Me.lbl_assignedtouser.AutoSize = True
			Me.lbl_assignedtouser.Location = New System.Drawing.Point(16, 179)
			Me.lbl_assignedtouser.Name = "lbl_assignedtouser"
			Me.lbl_assignedtouser.Size = New System.Drawing.Size(88, 13)
			Me.lbl_assignedtouser.TabIndex = 14
			Me.lbl_assignedtouser.Text = "Assigned to user:"
			' 
			' lbl_subject
			' 
			Me.lbl_subject.AutoSize = True
			Me.lbl_subject.Location = New System.Drawing.Point(16, 205)
			Me.lbl_subject.Name = "lbl_subject"
			Me.lbl_subject.Size = New System.Drawing.Size(46, 13)
			Me.lbl_subject.TabIndex = 15
			Me.lbl_subject.Text = "Subject:"
			' 
			' lbl_startdate
			' 
			Me.lbl_startdate.AutoSize = True
			Me.lbl_startdate.Location = New System.Drawing.Point(16, 232)
			Me.lbl_startdate.Name = "lbl_startdate"
			Me.lbl_startdate.Size = New System.Drawing.Size(56, 13)
			Me.lbl_startdate.TabIndex = 16
			Me.lbl_startdate.Text = "Start date:"
			' 
			' lbl_duedate
			' 
			Me.lbl_duedate.AutoSize = True
			Me.lbl_duedate.Location = New System.Drawing.Point(16, 259)
			Me.lbl_duedate.Name = "lbl_duedate"
			Me.lbl_duedate.Size = New System.Drawing.Size(54, 13)
			Me.lbl_duedate.TabIndex = 17
			Me.lbl_duedate.Text = "Due date:"
			' 
			' lbl_instructions
			' 
			Me.lbl_instructions.AutoSize = True
			Me.lbl_instructions.Location = New System.Drawing.Point(16, 311)
			Me.lbl_instructions.Name = "lbl_instructions"
			Me.lbl_instructions.Size = New System.Drawing.Size(64, 13)
			Me.lbl_instructions.TabIndex = 18
			Me.lbl_instructions.Text = "Instructions:"
			' 
			' lbl_usernoassigned
			' 
			Me.lbl_usernoassigned.AutoSize = True
			Me.lbl_usernoassigned.Location = New System.Drawing.Point(16, 285)
			Me.lbl_usernoassigned.Name = "lbl_usernoassigned"
			Me.lbl_usernoassigned.Size = New System.Drawing.Size(91, 13)
			Me.lbl_usernoassigned.TabIndex = 19
			Me.lbl_usernoassigned.Text = "UserNo assigned:"
			' 
			' txt_docno_info
			' 
			Me.txt_docno_info.Location = New System.Drawing.Point(122, 20)
			Me.txt_docno_info.Name = "txt_docno_info"
			Me.txt_docno_info.ReadOnly = True
			Me.txt_docno_info.Size = New System.Drawing.Size(120, 20)
			Me.txt_docno_info.TabIndex = 20
			' 
			' txt_mode_info
			' 
			Me.txt_mode_info.Location = New System.Drawing.Point(122, 46)
			Me.txt_mode_info.Name = "txt_mode_info"
			Me.txt_mode_info.ReadOnly = True
			Me.txt_mode_info.Size = New System.Drawing.Size(120, 20)
			Me.txt_mode_info.TabIndex = 21
			' 
			' txt_createdby
			' 
			Me.txt_createdby.Location = New System.Drawing.Point(122, 72)
			Me.txt_createdby.Name = "txt_createdby"
			Me.txt_createdby.ReadOnly = True
			Me.txt_createdby.Size = New System.Drawing.Size(212, 20)
			Me.txt_createdby.TabIndex = 22
			' 
			' txt_assignedto
			' 
			Me.txt_assignedto.Location = New System.Drawing.Point(122, 98)
			Me.txt_assignedto.Name = "txt_assignedto"
			Me.txt_assignedto.ReadOnly = True
			Me.txt_assignedto.Size = New System.Drawing.Size(120, 20)
			Me.txt_assignedto.TabIndex = 23
			' 
			' txt_createdbyuser
			' 
			Me.txt_createdbyuser.Location = New System.Drawing.Point(122, 150)
			Me.txt_createdbyuser.Name = "txt_createdbyuser"
			Me.txt_createdbyuser.ReadOnly = True
			Me.txt_createdbyuser.Size = New System.Drawing.Size(120, 20)
			Me.txt_createdbyuser.TabIndex = 24
			' 
			' txt_assignedtouser
			' 
			Me.txt_assignedtouser.Location = New System.Drawing.Point(122, 176)
			Me.txt_assignedtouser.Name = "txt_assignedtouser"
			Me.txt_assignedtouser.ReadOnly = True
			Me.txt_assignedtouser.Size = New System.Drawing.Size(120, 20)
			Me.txt_assignedtouser.TabIndex = 25
			' 
			' txt_subject_info
			' 
			Me.txt_subject_info.Location = New System.Drawing.Point(122, 202)
			Me.txt_subject_info.Name = "txt_subject_info"
			Me.txt_subject_info.ReadOnly = True
			Me.txt_subject_info.Size = New System.Drawing.Size(212, 20)
			Me.txt_subject_info.TabIndex = 26
			' 
			' txt_lastupdate
			' 
			Me.txt_lastupdate.Location = New System.Drawing.Point(122, 124)
			Me.txt_lastupdate.Name = "txt_lastupdate"
			Me.txt_lastupdate.ReadOnly = True
			Me.txt_lastupdate.Size = New System.Drawing.Size(120, 20)
			Me.txt_lastupdate.TabIndex = 27
			' 
			' txt_startdate_info
			' 
			Me.txt_startdate_info.Location = New System.Drawing.Point(122, 229)
			Me.txt_startdate_info.Name = "txt_startdate_info"
			Me.txt_startdate_info.ReadOnly = True
			Me.txt_startdate_info.Size = New System.Drawing.Size(120, 20)
			Me.txt_startdate_info.TabIndex = 28
			' 
			' txt_duedate_info
			' 
			Me.txt_duedate_info.Location = New System.Drawing.Point(122, 256)
			Me.txt_duedate_info.Name = "txt_duedate_info"
			Me.txt_duedate_info.ReadOnly = True
			Me.txt_duedate_info.Size = New System.Drawing.Size(120, 20)
			Me.txt_duedate_info.TabIndex = 29
			' 
			' txt_instructions_info
			' 
			Me.txt_instructions_info.Location = New System.Drawing.Point(122, 308)
			Me.txt_instructions_info.Name = "txt_instructions_info"
			Me.txt_instructions_info.ReadOnly = True
			Me.txt_instructions_info.Size = New System.Drawing.Size(212, 20)
			Me.txt_instructions_info.TabIndex = 30
			' 
			' txt_usernoassigned
			' 
			Me.txt_usernoassigned.Location = New System.Drawing.Point(122, 282)
			Me.txt_usernoassigned.Name = "txt_usernoassigned"
			Me.txt_usernoassigned.ReadOnly = True
			Me.txt_usernoassigned.Size = New System.Drawing.Size(120, 20)
			Me.txt_usernoassigned.TabIndex = 31
			' 
			' txt_comment
			' 
			Me.txt_comment.Location = New System.Drawing.Point(122, 334)
			Me.txt_comment.Name = "txt_comment"
			Me.txt_comment.Size = New System.Drawing.Size(212, 20)
			Me.txt_comment.TabIndex = 32
			' 
			' lbl_comment
			' 
			Me.lbl_comment.AutoSize = True
			Me.lbl_comment.Location = New System.Drawing.Point(16, 337)
			Me.lbl_comment.Name = "lbl_comment"
			Me.lbl_comment.Size = New System.Drawing.Size(54, 13)
			Me.lbl_comment.TabIndex = 34
			Me.lbl_comment.Text = "Comment:"
			' 
			' btn_loadtaskdefinition
			' 
			Me.btn_loadtaskdefinition.Location = New System.Drawing.Point(411, 12)
			Me.btn_loadtaskdefinition.Name = "btn_loadtaskdefinition"
			Me.btn_loadtaskdefinition.Size = New System.Drawing.Size(115, 23)
			Me.btn_loadtaskdefinition.TabIndex = 36
			Me.btn_loadtaskdefinition.Text = "Load Task Definition"
			Me.btn_loadtaskdefinition.UseVisualStyleBackColor = True
'			Me.btn_loadtaskdefinition.Click += New System.EventHandler(Me.btn_loadtaskdefinition_Click)
			' 
			' btn_addusers
			' 
			Me.btn_addusers.Location = New System.Drawing.Point(289, 96)
			Me.btn_addusers.Name = "btn_addusers"
			Me.btn_addusers.Size = New System.Drawing.Size(36, 23)
			Me.btn_addusers.TabIndex = 63
			Me.btn_addusers.Text = "Add"
			Me.btn_addusers.UseVisualStyleBackColor = True
'			Me.btn_addusers.Click += New System.EventHandler(Me.btn_addusers_Click)
			' 
			' txt_instructions_def
			' 
			Me.txt_instructions_def.Location = New System.Drawing.Point(113, 204)
			Me.txt_instructions_def.Name = "txt_instructions_def"
			Me.txt_instructions_def.Size = New System.Drawing.Size(212, 20)
			Me.txt_instructions_def.TabIndex = 59
			' 
			' txt_duedate_def
			' 
			Me.txt_duedate_def.Location = New System.Drawing.Point(113, 178)
			Me.txt_duedate_def.Name = "txt_duedate_def"
			Me.txt_duedate_def.Size = New System.Drawing.Size(120, 20)
			Me.txt_duedate_def.TabIndex = 58
			' 
			' txt_startdate_def
			' 
			Me.txt_startdate_def.Location = New System.Drawing.Point(113, 151)
			Me.txt_startdate_def.Name = "txt_startdate_def"
			Me.txt_startdate_def.Size = New System.Drawing.Size(120, 20)
			Me.txt_startdate_def.TabIndex = 57
			' 
			' txt_subject_def
			' 
			Me.txt_subject_def.Location = New System.Drawing.Point(113, 124)
			Me.txt_subject_def.Name = "txt_subject_def"
			Me.txt_subject_def.Size = New System.Drawing.Size(212, 20)
			Me.txt_subject_def.TabIndex = 55
			' 
			' txt_assignto
			' 
			Me.txt_assignto.Location = New System.Drawing.Point(113, 98)
			Me.txt_assignto.Name = "txt_assignto"
			Me.txt_assignto.ReadOnly = True
			Me.txt_assignto.Size = New System.Drawing.Size(170, 20)
			Me.txt_assignto.TabIndex = 52
			' 
			' txt_userno
			' 
			Me.txt_userno.Location = New System.Drawing.Point(113, 72)
			Me.txt_userno.Name = "txt_userno"
			Me.txt_userno.Size = New System.Drawing.Size(212, 20)
			Me.txt_userno.TabIndex = 51
			' 
			' txt_mode_def
			' 
			Me.txt_mode_def.Location = New System.Drawing.Point(113, 46)
			Me.txt_mode_def.Name = "txt_mode_def"
			Me.txt_mode_def.Size = New System.Drawing.Size(120, 20)
			Me.txt_mode_def.TabIndex = 50
			' 
			' txt_docno_def
			' 
			Me.txt_docno_def.Location = New System.Drawing.Point(113, 20)
			Me.txt_docno_def.Name = "txt_docno_def"
			Me.txt_docno_def.Size = New System.Drawing.Size(120, 20)
			Me.txt_docno_def.TabIndex = 49
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(7, 207)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(64, 13)
			Me.label3.TabIndex = 47
			Me.label3.Text = "Instructions:"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(7, 181)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(54, 13)
			Me.label4.TabIndex = 46
			Me.label4.Text = "Due date:"
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(7, 154)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(56, 13)
			Me.label5.TabIndex = 45
			Me.label5.Text = "Start date:"
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(7, 127)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(46, 13)
			Me.label6.TabIndex = 44
			Me.label6.Text = "Subject:"
			' 
			' lbl_assignto
			' 
			Me.lbl_assignto.AutoSize = True
			Me.lbl_assignto.Location = New System.Drawing.Point(7, 101)
			Me.lbl_assignto.Name = "lbl_assignto"
			Me.lbl_assignto.Size = New System.Drawing.Size(53, 13)
			Me.lbl_assignto.TabIndex = 40
			Me.lbl_assignto.Text = "Assign to:"
			' 
			' lbl_userno
			' 
			Me.lbl_userno.AutoSize = True
			Me.lbl_userno.Location = New System.Drawing.Point(7, 75)
			Me.lbl_userno.Name = "lbl_userno"
			Me.lbl_userno.Size = New System.Drawing.Size(46, 13)
			Me.lbl_userno.TabIndex = 39
			Me.lbl_userno.Text = "UserNo:"
			' 
			' label12
			' 
			Me.label12.AutoSize = True
			Me.label12.Location = New System.Drawing.Point(7, 49)
			Me.label12.Name = "label12"
			Me.label12.Size = New System.Drawing.Size(37, 13)
			Me.label12.TabIndex = 38
			Me.label12.Text = "Mode:"
			' 
			' label13
			' 
			Me.label13.AutoSize = True
			Me.label13.Location = New System.Drawing.Point(7, 23)
			Me.label13.Name = "label13"
			Me.label13.Size = New System.Drawing.Size(44, 13)
			Me.label13.TabIndex = 37
			Me.label13.Text = "DocNo:"
			' 
			' gbx_taskinfo
			' 
			Me.gbx_taskinfo.Controls.Add(Me.txt_decision)
			Me.gbx_taskinfo.Controls.Add(Me.lbl_decision)
			Me.gbx_taskinfo.Controls.Add(Me.lbl_status)
			Me.gbx_taskinfo.Controls.Add(Me.txt_status)
			Me.gbx_taskinfo.Controls.Add(Me.txt_subject_info)
			Me.gbx_taskinfo.Controls.Add(Me.lbl_docno)
			Me.gbx_taskinfo.Controls.Add(Me.lbl_mode)
			Me.gbx_taskinfo.Controls.Add(Me.lbl_createdby)
			Me.gbx_taskinfo.Controls.Add(Me.btn_update_info)
			Me.gbx_taskinfo.Controls.Add(Me.btn_complete)
			Me.gbx_taskinfo.Controls.Add(Me.lbl_assignedto)
			Me.gbx_taskinfo.Controls.Add(Me.lbl_lastupdate)
			Me.gbx_taskinfo.Controls.Add(Me.lbl_createdbyuser)
			Me.gbx_taskinfo.Controls.Add(Me.lbl_assignedtouser)
			Me.gbx_taskinfo.Controls.Add(Me.lbl_subject)
			Me.gbx_taskinfo.Controls.Add(Me.lbl_startdate)
			Me.gbx_taskinfo.Controls.Add(Me.lbl_duedate)
			Me.gbx_taskinfo.Controls.Add(Me.lbl_instructions)
			Me.gbx_taskinfo.Controls.Add(Me.lbl_usernoassigned)
			Me.gbx_taskinfo.Controls.Add(Me.txt_docno_info)
			Me.gbx_taskinfo.Controls.Add(Me.txt_mode_info)
			Me.gbx_taskinfo.Controls.Add(Me.txt_createdby)
			Me.gbx_taskinfo.Controls.Add(Me.txt_assignedto)
			Me.gbx_taskinfo.Controls.Add(Me.txt_createdbyuser)
			Me.gbx_taskinfo.Controls.Add(Me.txt_assignedtouser)
			Me.gbx_taskinfo.Controls.Add(Me.txt_lastupdate)
			Me.gbx_taskinfo.Controls.Add(Me.txt_startdate_info)
			Me.gbx_taskinfo.Controls.Add(Me.txt_duedate_info)
			Me.gbx_taskinfo.Controls.Add(Me.txt_instructions_info)
			Me.gbx_taskinfo.Controls.Add(Me.txt_usernoassigned)
			Me.gbx_taskinfo.Controls.Add(Me.txt_comment)
			Me.gbx_taskinfo.Controls.Add(Me.lbl_comment)
			Me.gbx_taskinfo.Location = New System.Drawing.Point(12, 52)
			Me.gbx_taskinfo.Name = "gbx_taskinfo"
			Me.gbx_taskinfo.Size = New System.Drawing.Size(361, 472)
			Me.gbx_taskinfo.TabIndex = 64
			Me.gbx_taskinfo.TabStop = False
			Me.gbx_taskinfo.Text = "Task Info"
			' 
			' txt_decision
			' 
			Me.txt_decision.Location = New System.Drawing.Point(122, 388)
			Me.txt_decision.Name = "txt_decision"
			Me.txt_decision.Size = New System.Drawing.Size(120, 20)
			Me.txt_decision.TabIndex = 39
			' 
			' lbl_decision
			' 
			Me.lbl_decision.AutoSize = True
			Me.lbl_decision.Location = New System.Drawing.Point(16, 388)
			Me.lbl_decision.Name = "lbl_decision"
			Me.lbl_decision.Size = New System.Drawing.Size(51, 13)
			Me.lbl_decision.TabIndex = 38
			Me.lbl_decision.Text = "Decision:"
			' 
			' lbl_status
			' 
			Me.lbl_status.AutoSize = True
			Me.lbl_status.Location = New System.Drawing.Point(16, 364)
			Me.lbl_status.Name = "lbl_status"
			Me.lbl_status.Size = New System.Drawing.Size(40, 13)
			Me.lbl_status.TabIndex = 36
			Me.lbl_status.Text = "Status:"
			' 
			' txt_status
			' 
			Me.txt_status.Location = New System.Drawing.Point(122, 361)
			Me.txt_status.Name = "txt_status"
			Me.txt_status.Size = New System.Drawing.Size(120, 20)
			Me.txt_status.TabIndex = 35
			' 
			' gbx_taskdefinition
			' 
			Me.gbx_taskdefinition.Controls.Add(Me.btn_update_def)
			Me.gbx_taskdefinition.Controls.Add(Me.chk_notifyusers)
			Me.gbx_taskdefinition.Controls.Add(Me.chk_notifiyonupdate)
			Me.gbx_taskdefinition.Controls.Add(Me.label13)
			Me.gbx_taskdefinition.Controls.Add(Me.label12)
			Me.gbx_taskdefinition.Controls.Add(Me.btn_addusers)
			Me.gbx_taskdefinition.Controls.Add(Me.lbl_userno)
			Me.gbx_taskdefinition.Controls.Add(Me.btn_startnew)
			Me.gbx_taskdefinition.Controls.Add(Me.lbl_assignto)
			Me.gbx_taskdefinition.Controls.Add(Me.txt_instructions_def)
			Me.gbx_taskdefinition.Controls.Add(Me.txt_duedate_def)
			Me.gbx_taskdefinition.Controls.Add(Me.label6)
			Me.gbx_taskdefinition.Controls.Add(Me.txt_startdate_def)
			Me.gbx_taskdefinition.Controls.Add(Me.label5)
			Me.gbx_taskdefinition.Controls.Add(Me.label4)
			Me.gbx_taskdefinition.Controls.Add(Me.txt_subject_def)
			Me.gbx_taskdefinition.Controls.Add(Me.label3)
			Me.gbx_taskdefinition.Controls.Add(Me.txt_docno_def)
			Me.gbx_taskdefinition.Controls.Add(Me.txt_assignto)
			Me.gbx_taskdefinition.Controls.Add(Me.txt_mode_def)
			Me.gbx_taskdefinition.Controls.Add(Me.txt_userno)
			Me.gbx_taskdefinition.Location = New System.Drawing.Point(411, 52)
			Me.gbx_taskdefinition.Name = "gbx_taskdefinition"
			Me.gbx_taskdefinition.Size = New System.Drawing.Size(351, 350)
			Me.gbx_taskdefinition.TabIndex = 65
			Me.gbx_taskdefinition.TabStop = False
			Me.gbx_taskdefinition.Text = "Task Definition"
			' 
			' btn_update_def
			' 
			Me.btn_update_def.Location = New System.Drawing.Point(87, 306)
			Me.btn_update_def.Name = "btn_update_def"
			Me.btn_update_def.Size = New System.Drawing.Size(75, 23)
			Me.btn_update_def.TabIndex = 66
			Me.btn_update_def.Text = "Update"
			Me.btn_update_def.UseVisualStyleBackColor = True
'			Me.btn_update_def.Click += New System.EventHandler(Me.btn_update_def_Click)
			' 
			' chk_notifyusers
			' 
			Me.chk_notifyusers.AutoSize = True
			Me.chk_notifyusers.Location = New System.Drawing.Point(113, 258)
			Me.chk_notifyusers.Name = "chk_notifyusers"
			Me.chk_notifyusers.Size = New System.Drawing.Size(81, 17)
			Me.chk_notifyusers.TabIndex = 65
			Me.chk_notifyusers.Text = "Notify users"
			Me.chk_notifyusers.UseVisualStyleBackColor = True
			' 
			' chk_notifiyonupdate
			' 
			Me.chk_notifiyonupdate.AutoSize = True
			Me.chk_notifiyonupdate.Location = New System.Drawing.Point(113, 232)
			Me.chk_notifiyonupdate.Name = "chk_notifiyonupdate"
			Me.chk_notifiyonupdate.Size = New System.Drawing.Size(106, 17)
			Me.chk_notifiyonupdate.TabIndex = 64
			Me.chk_notifiyonupdate.Text = "Notifiy on update"
			Me.chk_notifiyonupdate.UseVisualStyleBackColor = True
			' 
			' TasksForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(776, 540)
			Me.Controls.Add(Me.gbx_taskdefinition)
			Me.Controls.Add(Me.gbx_taskinfo)
			Me.Controls.Add(Me.btn_loadtaskdefinition)
			Me.Controls.Add(Me.btn_view)
			Me.Controls.Add(Me.lbl_taskID)
			Me.Controls.Add(Me.txt_taskID)
			Me.Controls.Add(Me.btn_loadtaskinfo)
			Me.MaximizeBox = False
			Me.Name = "TasksForm"
			Me.Text = "Therefore Tasks Sample"
			Me.gbx_taskinfo.ResumeLayout(False)
			Me.gbx_taskinfo.PerformLayout()
			Me.gbx_taskdefinition.ResumeLayout(False)
			Me.gbx_taskdefinition.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btn_loadtaskinfo As System.Windows.Forms.Button
		Private txt_taskID As System.Windows.Forms.TextBox
		Private lbl_taskID As System.Windows.Forms.Label
		Private WithEvents btn_startnew As System.Windows.Forms.Button
		Private WithEvents btn_update_info As System.Windows.Forms.Button
		Private WithEvents btn_complete As System.Windows.Forms.Button
		Private WithEvents btn_view As System.Windows.Forms.Button
		Private lbl_docno As System.Windows.Forms.Label
		Private lbl_mode As System.Windows.Forms.Label
		Private lbl_createdby As System.Windows.Forms.Label
		Private lbl_assignedto As System.Windows.Forms.Label
		Private lbl_lastupdate As System.Windows.Forms.Label
		Private lbl_createdbyuser As System.Windows.Forms.Label
		Private lbl_assignedtouser As System.Windows.Forms.Label
		Private lbl_subject As System.Windows.Forms.Label
		Private lbl_startdate As System.Windows.Forms.Label
		Private lbl_duedate As System.Windows.Forms.Label
		Private lbl_instructions As System.Windows.Forms.Label
		Private lbl_usernoassigned As System.Windows.Forms.Label
		Private txt_docno_info As System.Windows.Forms.TextBox
		Private txt_mode_info As System.Windows.Forms.TextBox
		Private txt_createdby As System.Windows.Forms.TextBox
		Private txt_assignedto As System.Windows.Forms.TextBox
		Private txt_createdbyuser As System.Windows.Forms.TextBox
		Private txt_assignedtouser As System.Windows.Forms.TextBox
		Private txt_subject_info As System.Windows.Forms.TextBox
		Private txt_lastupdate As System.Windows.Forms.TextBox
		Private txt_startdate_info As System.Windows.Forms.TextBox
		Private txt_duedate_info As System.Windows.Forms.TextBox
		Private txt_instructions_info As System.Windows.Forms.TextBox
		Private txt_usernoassigned As System.Windows.Forms.TextBox
		Private txt_comment As System.Windows.Forms.TextBox
		Private lbl_comment As System.Windows.Forms.Label
		Private WithEvents btn_loadtaskdefinition As System.Windows.Forms.Button
		Private WithEvents btn_addusers As System.Windows.Forms.Button
		Private txt_instructions_def As System.Windows.Forms.TextBox
		Private txt_duedate_def As System.Windows.Forms.TextBox
		Private txt_startdate_def As System.Windows.Forms.TextBox
		Private txt_subject_def As System.Windows.Forms.TextBox
		Private txt_assignto As System.Windows.Forms.TextBox
		Private txt_userno As System.Windows.Forms.TextBox
		Private txt_mode_def As System.Windows.Forms.TextBox
		Private txt_docno_def As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private lbl_assignto As System.Windows.Forms.Label
		Private lbl_userno As System.Windows.Forms.Label
		Private label12 As System.Windows.Forms.Label
		Private label13 As System.Windows.Forms.Label
		Private gbx_taskinfo As System.Windows.Forms.GroupBox
		Private gbx_taskdefinition As System.Windows.Forms.GroupBox
		Private chk_notifyusers As System.Windows.Forms.CheckBox
		Private chk_notifiyonupdate As System.Windows.Forms.CheckBox
		Private WithEvents btn_update_def As System.Windows.Forms.Button
		Private lbl_status As System.Windows.Forms.Label
		Private txt_status As System.Windows.Forms.TextBox
		Private lbl_decision As System.Windows.Forms.Label
		Private txt_decision As System.Windows.Forms.TextBox
	End Class
End Namespace

