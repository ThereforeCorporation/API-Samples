namespace Tasks
{
    partial class TasksForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_loadtaskinfo = new System.Windows.Forms.Button();
            this.txt_taskID = new System.Windows.Forms.TextBox();
            this.lbl_taskID = new System.Windows.Forms.Label();
            this.btn_startnew = new System.Windows.Forms.Button();
            this.btn_update_info = new System.Windows.Forms.Button();
            this.btn_complete = new System.Windows.Forms.Button();
            this.btn_view = new System.Windows.Forms.Button();
            this.lbl_docno = new System.Windows.Forms.Label();
            this.lbl_mode = new System.Windows.Forms.Label();
            this.lbl_createdby = new System.Windows.Forms.Label();
            this.lbl_assignedto = new System.Windows.Forms.Label();
            this.lbl_lastupdate = new System.Windows.Forms.Label();
            this.lbl_createdbyuser = new System.Windows.Forms.Label();
            this.lbl_assignedtouser = new System.Windows.Forms.Label();
            this.lbl_subject = new System.Windows.Forms.Label();
            this.lbl_startdate = new System.Windows.Forms.Label();
            this.lbl_duedate = new System.Windows.Forms.Label();
            this.lbl_instructions = new System.Windows.Forms.Label();
            this.lbl_usernoassigned = new System.Windows.Forms.Label();
            this.txt_docno_info = new System.Windows.Forms.TextBox();
            this.txt_mode_info = new System.Windows.Forms.TextBox();
            this.txt_createdby = new System.Windows.Forms.TextBox();
            this.txt_assignedto = new System.Windows.Forms.TextBox();
            this.txt_createdbyuser = new System.Windows.Forms.TextBox();
            this.txt_assignedtouser = new System.Windows.Forms.TextBox();
            this.txt_subject_info = new System.Windows.Forms.TextBox();
            this.txt_lastupdate = new System.Windows.Forms.TextBox();
            this.txt_startdate_info = new System.Windows.Forms.TextBox();
            this.txt_duedate_info = new System.Windows.Forms.TextBox();
            this.txt_instructions_info = new System.Windows.Forms.TextBox();
            this.txt_usernoassigned = new System.Windows.Forms.TextBox();
            this.txt_comment = new System.Windows.Forms.TextBox();
            this.lbl_comment = new System.Windows.Forms.Label();
            this.btn_loadtaskdefinition = new System.Windows.Forms.Button();
            this.btn_addusers = new System.Windows.Forms.Button();
            this.txt_instructions_def = new System.Windows.Forms.TextBox();
            this.txt_duedate_def = new System.Windows.Forms.TextBox();
            this.txt_startdate_def = new System.Windows.Forms.TextBox();
            this.txt_subject_def = new System.Windows.Forms.TextBox();
            this.txt_assignto = new System.Windows.Forms.TextBox();
            this.txt_userno = new System.Windows.Forms.TextBox();
            this.txt_mode_def = new System.Windows.Forms.TextBox();
            this.txt_docno_def = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_assignto = new System.Windows.Forms.Label();
            this.lbl_userno = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.gbx_taskinfo = new System.Windows.Forms.GroupBox();
            this.txt_decision = new System.Windows.Forms.TextBox();
            this.lbl_decision = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.txt_status = new System.Windows.Forms.TextBox();
            this.gbx_taskdefinition = new System.Windows.Forms.GroupBox();
            this.btn_update_def = new System.Windows.Forms.Button();
            this.chk_notifyusers = new System.Windows.Forms.CheckBox();
            this.chk_notifiyonupdate = new System.Windows.Forms.CheckBox();
            this.gbx_taskinfo.SuspendLayout();
            this.gbx_taskdefinition.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_loadtaskinfo
            // 
            this.btn_loadtaskinfo.Location = new System.Drawing.Point(198, 12);
            this.btn_loadtaskinfo.Name = "btn_loadtaskinfo";
            this.btn_loadtaskinfo.Size = new System.Drawing.Size(94, 23);
            this.btn_loadtaskinfo.TabIndex = 0;
            this.btn_loadtaskinfo.Text = "Load Task Info";
            this.btn_loadtaskinfo.UseVisualStyleBackColor = true;
            this.btn_loadtaskinfo.Click += new System.EventHandler(this.btn_loadtaskinfo_Click);
            // 
            // txt_taskID
            // 
            this.txt_taskID.Location = new System.Drawing.Point(78, 14);
            this.txt_taskID.Name = "txt_taskID";
            this.txt_taskID.Size = new System.Drawing.Size(100, 20);
            this.txt_taskID.TabIndex = 1;
            // 
            // lbl_taskID
            // 
            this.lbl_taskID.AutoSize = true;
            this.lbl_taskID.Location = new System.Drawing.Point(19, 17);
            this.lbl_taskID.Name = "lbl_taskID";
            this.lbl_taskID.Size = new System.Drawing.Size(48, 13);
            this.lbl_taskID.TabIndex = 2;
            this.lbl_taskID.Text = "Task ID:";
            // 
            // btn_startnew
            // 
            this.btn_startnew.Location = new System.Drawing.Point(6, 306);
            this.btn_startnew.Name = "btn_startnew";
            this.btn_startnew.Size = new System.Drawing.Size(75, 23);
            this.btn_startnew.TabIndex = 3;
            this.btn_startnew.Text = "Start New";
            this.btn_startnew.UseVisualStyleBackColor = true;
            this.btn_startnew.Click += new System.EventHandler(this.btn_startnew_Click);
            // 
            // btn_update_info
            // 
            this.btn_update_info.Location = new System.Drawing.Point(91, 428);
            this.btn_update_info.Name = "btn_update_info";
            this.btn_update_info.Size = new System.Drawing.Size(75, 23);
            this.btn_update_info.TabIndex = 4;
            this.btn_update_info.Text = "Update";
            this.btn_update_info.UseVisualStyleBackColor = true;
            this.btn_update_info.Click += new System.EventHandler(this.btn_update_info_Click);
            // 
            // btn_complete
            // 
            this.btn_complete.Location = new System.Drawing.Point(10, 428);
            this.btn_complete.Name = "btn_complete";
            this.btn_complete.Size = new System.Drawing.Size(75, 23);
            this.btn_complete.TabIndex = 6;
            this.btn_complete.Text = "Complete";
            this.btn_complete.UseVisualStyleBackColor = true;
            this.btn_complete.Click += new System.EventHandler(this.btn_complete_Click);
            // 
            // btn_view
            // 
            this.btn_view.Location = new System.Drawing.Point(298, 12);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(75, 23);
            this.btn_view.TabIndex = 7;
            this.btn_view.Text = "View";
            this.btn_view.UseVisualStyleBackColor = true;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // lbl_docno
            // 
            this.lbl_docno.AutoSize = true;
            this.lbl_docno.Location = new System.Drawing.Point(16, 23);
            this.lbl_docno.Name = "lbl_docno";
            this.lbl_docno.Size = new System.Drawing.Size(44, 13);
            this.lbl_docno.TabIndex = 8;
            this.lbl_docno.Text = "DocNo:";
            // 
            // lbl_mode
            // 
            this.lbl_mode.AutoSize = true;
            this.lbl_mode.Location = new System.Drawing.Point(16, 49);
            this.lbl_mode.Name = "lbl_mode";
            this.lbl_mode.Size = new System.Drawing.Size(37, 13);
            this.lbl_mode.TabIndex = 9;
            this.lbl_mode.Text = "Mode:";
            // 
            // lbl_createdby
            // 
            this.lbl_createdby.AutoSize = true;
            this.lbl_createdby.Location = new System.Drawing.Point(16, 75);
            this.lbl_createdby.Name = "lbl_createdby";
            this.lbl_createdby.Size = new System.Drawing.Size(61, 13);
            this.lbl_createdby.TabIndex = 10;
            this.lbl_createdby.Text = "Created by:";
            // 
            // lbl_assignedto
            // 
            this.lbl_assignedto.AutoSize = true;
            this.lbl_assignedto.Location = new System.Drawing.Point(16, 101);
            this.lbl_assignedto.Name = "lbl_assignedto";
            this.lbl_assignedto.Size = new System.Drawing.Size(65, 13);
            this.lbl_assignedto.TabIndex = 11;
            this.lbl_assignedto.Text = "Assigned to:";
            // 
            // lbl_lastupdate
            // 
            this.lbl_lastupdate.AutoSize = true;
            this.lbl_lastupdate.Location = new System.Drawing.Point(16, 127);
            this.lbl_lastupdate.Name = "lbl_lastupdate";
            this.lbl_lastupdate.Size = new System.Drawing.Size(66, 13);
            this.lbl_lastupdate.TabIndex = 12;
            this.lbl_lastupdate.Text = "Last update:";
            // 
            // lbl_createdbyuser
            // 
            this.lbl_createdbyuser.AutoSize = true;
            this.lbl_createdbyuser.Location = new System.Drawing.Point(16, 153);
            this.lbl_createdbyuser.Name = "lbl_createdbyuser";
            this.lbl_createdbyuser.Size = new System.Drawing.Size(84, 13);
            this.lbl_createdbyuser.TabIndex = 13;
            this.lbl_createdbyuser.Text = "Created by user:";
            // 
            // lbl_assignedtouser
            // 
            this.lbl_assignedtouser.AutoSize = true;
            this.lbl_assignedtouser.Location = new System.Drawing.Point(16, 179);
            this.lbl_assignedtouser.Name = "lbl_assignedtouser";
            this.lbl_assignedtouser.Size = new System.Drawing.Size(88, 13);
            this.lbl_assignedtouser.TabIndex = 14;
            this.lbl_assignedtouser.Text = "Assigned to user:";
            // 
            // lbl_subject
            // 
            this.lbl_subject.AutoSize = true;
            this.lbl_subject.Location = new System.Drawing.Point(16, 205);
            this.lbl_subject.Name = "lbl_subject";
            this.lbl_subject.Size = new System.Drawing.Size(46, 13);
            this.lbl_subject.TabIndex = 15;
            this.lbl_subject.Text = "Subject:";
            // 
            // lbl_startdate
            // 
            this.lbl_startdate.AutoSize = true;
            this.lbl_startdate.Location = new System.Drawing.Point(16, 232);
            this.lbl_startdate.Name = "lbl_startdate";
            this.lbl_startdate.Size = new System.Drawing.Size(56, 13);
            this.lbl_startdate.TabIndex = 16;
            this.lbl_startdate.Text = "Start date:";
            // 
            // lbl_duedate
            // 
            this.lbl_duedate.AutoSize = true;
            this.lbl_duedate.Location = new System.Drawing.Point(16, 259);
            this.lbl_duedate.Name = "lbl_duedate";
            this.lbl_duedate.Size = new System.Drawing.Size(54, 13);
            this.lbl_duedate.TabIndex = 17;
            this.lbl_duedate.Text = "Due date:";
            // 
            // lbl_instructions
            // 
            this.lbl_instructions.AutoSize = true;
            this.lbl_instructions.Location = new System.Drawing.Point(16, 311);
            this.lbl_instructions.Name = "lbl_instructions";
            this.lbl_instructions.Size = new System.Drawing.Size(64, 13);
            this.lbl_instructions.TabIndex = 18;
            this.lbl_instructions.Text = "Instructions:";
            // 
            // lbl_usernoassigned
            // 
            this.lbl_usernoassigned.AutoSize = true;
            this.lbl_usernoassigned.Location = new System.Drawing.Point(16, 285);
            this.lbl_usernoassigned.Name = "lbl_usernoassigned";
            this.lbl_usernoassigned.Size = new System.Drawing.Size(91, 13);
            this.lbl_usernoassigned.TabIndex = 19;
            this.lbl_usernoassigned.Text = "UserNo assigned:";
            // 
            // txt_docno_info
            // 
            this.txt_docno_info.Location = new System.Drawing.Point(122, 20);
            this.txt_docno_info.Name = "txt_docno_info";
            this.txt_docno_info.ReadOnly = true;
            this.txt_docno_info.Size = new System.Drawing.Size(120, 20);
            this.txt_docno_info.TabIndex = 20;
            // 
            // txt_mode_info
            // 
            this.txt_mode_info.Location = new System.Drawing.Point(122, 46);
            this.txt_mode_info.Name = "txt_mode_info";
            this.txt_mode_info.ReadOnly = true;
            this.txt_mode_info.Size = new System.Drawing.Size(120, 20);
            this.txt_mode_info.TabIndex = 21;
            // 
            // txt_createdby
            // 
            this.txt_createdby.Location = new System.Drawing.Point(122, 72);
            this.txt_createdby.Name = "txt_createdby";
            this.txt_createdby.ReadOnly = true;
            this.txt_createdby.Size = new System.Drawing.Size(212, 20);
            this.txt_createdby.TabIndex = 22;
            // 
            // txt_assignedto
            // 
            this.txt_assignedto.Location = new System.Drawing.Point(122, 98);
            this.txt_assignedto.Name = "txt_assignedto";
            this.txt_assignedto.ReadOnly = true;
            this.txt_assignedto.Size = new System.Drawing.Size(120, 20);
            this.txt_assignedto.TabIndex = 23;
            // 
            // txt_createdbyuser
            // 
            this.txt_createdbyuser.Location = new System.Drawing.Point(122, 150);
            this.txt_createdbyuser.Name = "txt_createdbyuser";
            this.txt_createdbyuser.ReadOnly = true;
            this.txt_createdbyuser.Size = new System.Drawing.Size(120, 20);
            this.txt_createdbyuser.TabIndex = 24;
            // 
            // txt_assignedtouser
            // 
            this.txt_assignedtouser.Location = new System.Drawing.Point(122, 176);
            this.txt_assignedtouser.Name = "txt_assignedtouser";
            this.txt_assignedtouser.ReadOnly = true;
            this.txt_assignedtouser.Size = new System.Drawing.Size(120, 20);
            this.txt_assignedtouser.TabIndex = 25;
            // 
            // txt_subject_info
            // 
            this.txt_subject_info.Location = new System.Drawing.Point(122, 202);
            this.txt_subject_info.Name = "txt_subject_info";
            this.txt_subject_info.ReadOnly = true;
            this.txt_subject_info.Size = new System.Drawing.Size(212, 20);
            this.txt_subject_info.TabIndex = 26;
            // 
            // txt_lastupdate
            // 
            this.txt_lastupdate.Location = new System.Drawing.Point(122, 124);
            this.txt_lastupdate.Name = "txt_lastupdate";
            this.txt_lastupdate.ReadOnly = true;
            this.txt_lastupdate.Size = new System.Drawing.Size(120, 20);
            this.txt_lastupdate.TabIndex = 27;
            // 
            // txt_startdate_info
            // 
            this.txt_startdate_info.Location = new System.Drawing.Point(122, 229);
            this.txt_startdate_info.Name = "txt_startdate_info";
            this.txt_startdate_info.ReadOnly = true;
            this.txt_startdate_info.Size = new System.Drawing.Size(120, 20);
            this.txt_startdate_info.TabIndex = 28;
            // 
            // txt_duedate_info
            // 
            this.txt_duedate_info.Location = new System.Drawing.Point(122, 256);
            this.txt_duedate_info.Name = "txt_duedate_info";
            this.txt_duedate_info.ReadOnly = true;
            this.txt_duedate_info.Size = new System.Drawing.Size(120, 20);
            this.txt_duedate_info.TabIndex = 29;
            // 
            // txt_instructions_info
            // 
            this.txt_instructions_info.Location = new System.Drawing.Point(122, 308);
            this.txt_instructions_info.Name = "txt_instructions_info";
            this.txt_instructions_info.ReadOnly = true;
            this.txt_instructions_info.Size = new System.Drawing.Size(212, 20);
            this.txt_instructions_info.TabIndex = 30;
            // 
            // txt_usernoassigned
            // 
            this.txt_usernoassigned.Location = new System.Drawing.Point(122, 282);
            this.txt_usernoassigned.Name = "txt_usernoassigned";
            this.txt_usernoassigned.ReadOnly = true;
            this.txt_usernoassigned.Size = new System.Drawing.Size(120, 20);
            this.txt_usernoassigned.TabIndex = 31;
            // 
            // txt_comment
            // 
            this.txt_comment.Location = new System.Drawing.Point(122, 334);
            this.txt_comment.Name = "txt_comment";
            this.txt_comment.Size = new System.Drawing.Size(212, 20);
            this.txt_comment.TabIndex = 32;
            // 
            // lbl_comment
            // 
            this.lbl_comment.AutoSize = true;
            this.lbl_comment.Location = new System.Drawing.Point(16, 337);
            this.lbl_comment.Name = "lbl_comment";
            this.lbl_comment.Size = new System.Drawing.Size(54, 13);
            this.lbl_comment.TabIndex = 34;
            this.lbl_comment.Text = "Comment:";
            // 
            // btn_loadtaskdefinition
            // 
            this.btn_loadtaskdefinition.Location = new System.Drawing.Point(411, 12);
            this.btn_loadtaskdefinition.Name = "btn_loadtaskdefinition";
            this.btn_loadtaskdefinition.Size = new System.Drawing.Size(115, 23);
            this.btn_loadtaskdefinition.TabIndex = 36;
            this.btn_loadtaskdefinition.Text = "Load Task Definition";
            this.btn_loadtaskdefinition.UseVisualStyleBackColor = true;
            this.btn_loadtaskdefinition.Click += new System.EventHandler(this.btn_loadtaskdefinition_Click);
            // 
            // btn_addusers
            // 
            this.btn_addusers.Location = new System.Drawing.Point(289, 96);
            this.btn_addusers.Name = "btn_addusers";
            this.btn_addusers.Size = new System.Drawing.Size(36, 23);
            this.btn_addusers.TabIndex = 63;
            this.btn_addusers.Text = "Add";
            this.btn_addusers.UseVisualStyleBackColor = true;
            this.btn_addusers.Click += new System.EventHandler(this.btn_addusers_Click);
            // 
            // txt_instructions_def
            // 
            this.txt_instructions_def.Location = new System.Drawing.Point(113, 204);
            this.txt_instructions_def.Name = "txt_instructions_def";
            this.txt_instructions_def.Size = new System.Drawing.Size(212, 20);
            this.txt_instructions_def.TabIndex = 59;
            // 
            // txt_duedate_def
            // 
            this.txt_duedate_def.Location = new System.Drawing.Point(113, 178);
            this.txt_duedate_def.Name = "txt_duedate_def";
            this.txt_duedate_def.Size = new System.Drawing.Size(120, 20);
            this.txt_duedate_def.TabIndex = 58;
            // 
            // txt_startdate_def
            // 
            this.txt_startdate_def.Location = new System.Drawing.Point(113, 151);
            this.txt_startdate_def.Name = "txt_startdate_def";
            this.txt_startdate_def.Size = new System.Drawing.Size(120, 20);
            this.txt_startdate_def.TabIndex = 57;
            // 
            // txt_subject_def
            // 
            this.txt_subject_def.Location = new System.Drawing.Point(113, 124);
            this.txt_subject_def.Name = "txt_subject_def";
            this.txt_subject_def.Size = new System.Drawing.Size(212, 20);
            this.txt_subject_def.TabIndex = 55;
            // 
            // txt_assignto
            // 
            this.txt_assignto.Location = new System.Drawing.Point(113, 98);
            this.txt_assignto.Name = "txt_assignto";
            this.txt_assignto.ReadOnly = true;
            this.txt_assignto.Size = new System.Drawing.Size(170, 20);
            this.txt_assignto.TabIndex = 52;
            // 
            // txt_userno
            // 
            this.txt_userno.Location = new System.Drawing.Point(113, 72);
            this.txt_userno.Name = "txt_userno";
            this.txt_userno.Size = new System.Drawing.Size(212, 20);
            this.txt_userno.TabIndex = 51;
            // 
            // txt_mode_def
            // 
            this.txt_mode_def.Location = new System.Drawing.Point(113, 46);
            this.txt_mode_def.Name = "txt_mode_def";
            this.txt_mode_def.Size = new System.Drawing.Size(120, 20);
            this.txt_mode_def.TabIndex = 50;
            // 
            // txt_docno_def
            // 
            this.txt_docno_def.Location = new System.Drawing.Point(113, 20);
            this.txt_docno_def.Name = "txt_docno_def";
            this.txt_docno_def.Size = new System.Drawing.Size(120, 20);
            this.txt_docno_def.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Instructions:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Due date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Start date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Subject:";
            // 
            // lbl_assignto
            // 
            this.lbl_assignto.AutoSize = true;
            this.lbl_assignto.Location = new System.Drawing.Point(7, 101);
            this.lbl_assignto.Name = "lbl_assignto";
            this.lbl_assignto.Size = new System.Drawing.Size(53, 13);
            this.lbl_assignto.TabIndex = 40;
            this.lbl_assignto.Text = "Assign to:";
            // 
            // lbl_userno
            // 
            this.lbl_userno.AutoSize = true;
            this.lbl_userno.Location = new System.Drawing.Point(7, 75);
            this.lbl_userno.Name = "lbl_userno";
            this.lbl_userno.Size = new System.Drawing.Size(46, 13);
            this.lbl_userno.TabIndex = 39;
            this.lbl_userno.Text = "UserNo:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "Mode:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "DocNo:";
            // 
            // gbx_taskinfo
            // 
            this.gbx_taskinfo.Controls.Add(this.txt_decision);
            this.gbx_taskinfo.Controls.Add(this.lbl_decision);
            this.gbx_taskinfo.Controls.Add(this.lbl_status);
            this.gbx_taskinfo.Controls.Add(this.txt_status);
            this.gbx_taskinfo.Controls.Add(this.txt_subject_info);
            this.gbx_taskinfo.Controls.Add(this.lbl_docno);
            this.gbx_taskinfo.Controls.Add(this.lbl_mode);
            this.gbx_taskinfo.Controls.Add(this.lbl_createdby);
            this.gbx_taskinfo.Controls.Add(this.btn_update_info);
            this.gbx_taskinfo.Controls.Add(this.btn_complete);
            this.gbx_taskinfo.Controls.Add(this.lbl_assignedto);
            this.gbx_taskinfo.Controls.Add(this.lbl_lastupdate);
            this.gbx_taskinfo.Controls.Add(this.lbl_createdbyuser);
            this.gbx_taskinfo.Controls.Add(this.lbl_assignedtouser);
            this.gbx_taskinfo.Controls.Add(this.lbl_subject);
            this.gbx_taskinfo.Controls.Add(this.lbl_startdate);
            this.gbx_taskinfo.Controls.Add(this.lbl_duedate);
            this.gbx_taskinfo.Controls.Add(this.lbl_instructions);
            this.gbx_taskinfo.Controls.Add(this.lbl_usernoassigned);
            this.gbx_taskinfo.Controls.Add(this.txt_docno_info);
            this.gbx_taskinfo.Controls.Add(this.txt_mode_info);
            this.gbx_taskinfo.Controls.Add(this.txt_createdby);
            this.gbx_taskinfo.Controls.Add(this.txt_assignedto);
            this.gbx_taskinfo.Controls.Add(this.txt_createdbyuser);
            this.gbx_taskinfo.Controls.Add(this.txt_assignedtouser);
            this.gbx_taskinfo.Controls.Add(this.txt_lastupdate);
            this.gbx_taskinfo.Controls.Add(this.txt_startdate_info);
            this.gbx_taskinfo.Controls.Add(this.txt_duedate_info);
            this.gbx_taskinfo.Controls.Add(this.txt_instructions_info);
            this.gbx_taskinfo.Controls.Add(this.txt_usernoassigned);
            this.gbx_taskinfo.Controls.Add(this.txt_comment);
            this.gbx_taskinfo.Controls.Add(this.lbl_comment);
            this.gbx_taskinfo.Location = new System.Drawing.Point(12, 52);
            this.gbx_taskinfo.Name = "gbx_taskinfo";
            this.gbx_taskinfo.Size = new System.Drawing.Size(361, 472);
            this.gbx_taskinfo.TabIndex = 64;
            this.gbx_taskinfo.TabStop = false;
            this.gbx_taskinfo.Text = "Task Info";
            // 
            // txt_decision
            // 
            this.txt_decision.Location = new System.Drawing.Point(122, 388);
            this.txt_decision.Name = "txt_decision";
            this.txt_decision.Size = new System.Drawing.Size(120, 20);
            this.txt_decision.TabIndex = 39;
            // 
            // lbl_decision
            // 
            this.lbl_decision.AutoSize = true;
            this.lbl_decision.Location = new System.Drawing.Point(16, 388);
            this.lbl_decision.Name = "lbl_decision";
            this.lbl_decision.Size = new System.Drawing.Size(51, 13);
            this.lbl_decision.TabIndex = 38;
            this.lbl_decision.Text = "Decision:";
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(16, 364);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(40, 13);
            this.lbl_status.TabIndex = 36;
            this.lbl_status.Text = "Status:";
            // 
            // txt_status
            // 
            this.txt_status.Location = new System.Drawing.Point(122, 361);
            this.txt_status.Name = "txt_status";
            this.txt_status.Size = new System.Drawing.Size(120, 20);
            this.txt_status.TabIndex = 35;
            // 
            // gbx_taskdefinition
            // 
            this.gbx_taskdefinition.Controls.Add(this.btn_update_def);
            this.gbx_taskdefinition.Controls.Add(this.chk_notifyusers);
            this.gbx_taskdefinition.Controls.Add(this.chk_notifiyonupdate);
            this.gbx_taskdefinition.Controls.Add(this.label13);
            this.gbx_taskdefinition.Controls.Add(this.label12);
            this.gbx_taskdefinition.Controls.Add(this.btn_addusers);
            this.gbx_taskdefinition.Controls.Add(this.lbl_userno);
            this.gbx_taskdefinition.Controls.Add(this.btn_startnew);
            this.gbx_taskdefinition.Controls.Add(this.lbl_assignto);
            this.gbx_taskdefinition.Controls.Add(this.txt_instructions_def);
            this.gbx_taskdefinition.Controls.Add(this.txt_duedate_def);
            this.gbx_taskdefinition.Controls.Add(this.label6);
            this.gbx_taskdefinition.Controls.Add(this.txt_startdate_def);
            this.gbx_taskdefinition.Controls.Add(this.label5);
            this.gbx_taskdefinition.Controls.Add(this.label4);
            this.gbx_taskdefinition.Controls.Add(this.txt_subject_def);
            this.gbx_taskdefinition.Controls.Add(this.label3);
            this.gbx_taskdefinition.Controls.Add(this.txt_docno_def);
            this.gbx_taskdefinition.Controls.Add(this.txt_assignto);
            this.gbx_taskdefinition.Controls.Add(this.txt_mode_def);
            this.gbx_taskdefinition.Controls.Add(this.txt_userno);
            this.gbx_taskdefinition.Location = new System.Drawing.Point(411, 52);
            this.gbx_taskdefinition.Name = "gbx_taskdefinition";
            this.gbx_taskdefinition.Size = new System.Drawing.Size(351, 350);
            this.gbx_taskdefinition.TabIndex = 65;
            this.gbx_taskdefinition.TabStop = false;
            this.gbx_taskdefinition.Text = "Task Definition";
            // 
            // btn_update_def
            // 
            this.btn_update_def.Location = new System.Drawing.Point(87, 306);
            this.btn_update_def.Name = "btn_update_def";
            this.btn_update_def.Size = new System.Drawing.Size(75, 23);
            this.btn_update_def.TabIndex = 66;
            this.btn_update_def.Text = "Update";
            this.btn_update_def.UseVisualStyleBackColor = true;
            this.btn_update_def.Click += new System.EventHandler(this.btn_update_def_Click);
            // 
            // chk_notifyusers
            // 
            this.chk_notifyusers.AutoSize = true;
            this.chk_notifyusers.Location = new System.Drawing.Point(113, 258);
            this.chk_notifyusers.Name = "chk_notifyusers";
            this.chk_notifyusers.Size = new System.Drawing.Size(81, 17);
            this.chk_notifyusers.TabIndex = 65;
            this.chk_notifyusers.Text = "Notify users";
            this.chk_notifyusers.UseVisualStyleBackColor = true;
            // 
            // chk_notifiyonupdate
            // 
            this.chk_notifiyonupdate.AutoSize = true;
            this.chk_notifiyonupdate.Location = new System.Drawing.Point(113, 232);
            this.chk_notifiyonupdate.Name = "chk_notifiyonupdate";
            this.chk_notifiyonupdate.Size = new System.Drawing.Size(106, 17);
            this.chk_notifiyonupdate.TabIndex = 64;
            this.chk_notifiyonupdate.Text = "Notifiy on update";
            this.chk_notifiyonupdate.UseVisualStyleBackColor = true;
            // 
            // TasksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 540);
            this.Controls.Add(this.gbx_taskdefinition);
            this.Controls.Add(this.gbx_taskinfo);
            this.Controls.Add(this.btn_loadtaskdefinition);
            this.Controls.Add(this.btn_view);
            this.Controls.Add(this.lbl_taskID);
            this.Controls.Add(this.txt_taskID);
            this.Controls.Add(this.btn_loadtaskinfo);
            this.MaximizeBox = false;
            this.Name = "TasksForm";
            this.Text = "Therefore Tasks Sample";
            this.gbx_taskinfo.ResumeLayout(false);
            this.gbx_taskinfo.PerformLayout();
            this.gbx_taskdefinition.ResumeLayout(false);
            this.gbx_taskdefinition.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_loadtaskinfo;
        private System.Windows.Forms.TextBox txt_taskID;
        private System.Windows.Forms.Label lbl_taskID;
        private System.Windows.Forms.Button btn_startnew;
        private System.Windows.Forms.Button btn_update_info;
        private System.Windows.Forms.Button btn_complete;
        private System.Windows.Forms.Button btn_view;
        private System.Windows.Forms.Label lbl_docno;
        private System.Windows.Forms.Label lbl_mode;
        private System.Windows.Forms.Label lbl_createdby;
        private System.Windows.Forms.Label lbl_assignedto;
        private System.Windows.Forms.Label lbl_lastupdate;
        private System.Windows.Forms.Label lbl_createdbyuser;
        private System.Windows.Forms.Label lbl_assignedtouser;
        private System.Windows.Forms.Label lbl_subject;
        private System.Windows.Forms.Label lbl_startdate;
        private System.Windows.Forms.Label lbl_duedate;
        private System.Windows.Forms.Label lbl_instructions;
        private System.Windows.Forms.Label lbl_usernoassigned;
        private System.Windows.Forms.TextBox txt_docno_info;
        private System.Windows.Forms.TextBox txt_mode_info;
        private System.Windows.Forms.TextBox txt_createdby;
        private System.Windows.Forms.TextBox txt_assignedto;
        private System.Windows.Forms.TextBox txt_createdbyuser;
        private System.Windows.Forms.TextBox txt_assignedtouser;
        private System.Windows.Forms.TextBox txt_subject_info;
        private System.Windows.Forms.TextBox txt_lastupdate;
        private System.Windows.Forms.TextBox txt_startdate_info;
        private System.Windows.Forms.TextBox txt_duedate_info;
        private System.Windows.Forms.TextBox txt_instructions_info;
        private System.Windows.Forms.TextBox txt_usernoassigned;
        private System.Windows.Forms.TextBox txt_comment;
        private System.Windows.Forms.Label lbl_comment;
        private System.Windows.Forms.Button btn_loadtaskdefinition;
        private System.Windows.Forms.Button btn_addusers;
        private System.Windows.Forms.TextBox txt_instructions_def;
        private System.Windows.Forms.TextBox txt_duedate_def;
        private System.Windows.Forms.TextBox txt_startdate_def;
        private System.Windows.Forms.TextBox txt_subject_def;
        private System.Windows.Forms.TextBox txt_assignto;
        private System.Windows.Forms.TextBox txt_userno;
        private System.Windows.Forms.TextBox txt_mode_def;
        private System.Windows.Forms.TextBox txt_docno_def;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_assignto;
        private System.Windows.Forms.Label lbl_userno;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox gbx_taskinfo;
        private System.Windows.Forms.GroupBox gbx_taskdefinition;
        private System.Windows.Forms.CheckBox chk_notifyusers;
        private System.Windows.Forms.CheckBox chk_notifiyonupdate;
        private System.Windows.Forms.Button btn_update_def;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.TextBox txt_status;
        private System.Windows.Forms.Label lbl_decision;
        private System.Windows.Forms.TextBox txt_decision;
    }
}

