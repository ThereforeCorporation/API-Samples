namespace AccessMask
{
    partial class AccessMaskForm
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
            this.cmb_objtype = new System.Windows.Forms.ComboBox();
            this.txt_objno = new System.Windows.Forms.TextBox();
            this.txt_subobjno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_load = new System.Windows.Forms.Button();
            this.txt_output = new System.Windows.Forms.TextBox();
            this.btn_am2pl = new System.Windows.Forms.Button();
            this.btn_pl2am = new System.Windows.Forms.Button();
            this.btn_getobjects = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmb_objtype
            // 
            this.cmb_objtype.FormattingEnabled = true;
            this.cmb_objtype.Location = new System.Drawing.Point(86, 12);
            this.cmb_objtype.Name = "cmb_objtype";
            this.cmb_objtype.Size = new System.Drawing.Size(140, 21);
            this.cmb_objtype.TabIndex = 0;
            // 
            // txt_objno
            // 
            this.txt_objno.Location = new System.Drawing.Point(86, 38);
            this.txt_objno.Name = "txt_objno";
            this.txt_objno.Size = new System.Drawing.Size(62, 20);
            this.txt_objno.TabIndex = 1;
            this.txt_objno.Text = "0";
            // 
            // txt_subobjno
            // 
            this.txt_subobjno.Location = new System.Drawing.Point(86, 64);
            this.txt_subobjno.Name = "txt_subobjno";
            this.txt_subobjno.Size = new System.Drawing.Size(62, 20);
            this.txt_subobjno.TabIndex = 2;
            this.txt_subobjno.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Object Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Object ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "SubObject ID:";
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(11, 100);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(95, 35);
            this.btn_load.TabIndex = 6;
            this.btn_load.Text = "Load AccessMask";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // txt_output
            // 
            this.txt_output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_output.Location = new System.Drawing.Point(12, 141);
            this.txt_output.Multiline = true;
            this.txt_output.Name = "txt_output";
            this.txt_output.ReadOnly = true;
            this.txt_output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_output.Size = new System.Drawing.Size(331, 274);
            this.txt_output.TabIndex = 7;
            // 
            // btn_am2pl
            // 
            this.btn_am2pl.Location = new System.Drawing.Point(131, 100);
            this.btn_am2pl.Name = "btn_am2pl";
            this.btn_am2pl.Size = new System.Drawing.Size(95, 35);
            this.btn_am2pl.TabIndex = 8;
            this.btn_am2pl.Text = "AccessMask to PermissionList";
            this.btn_am2pl.UseVisualStyleBackColor = true;
            this.btn_am2pl.Click += new System.EventHandler(this.btn_am2pl_Click);
            // 
            // btn_pl2am
            // 
            this.btn_pl2am.Location = new System.Drawing.Point(248, 100);
            this.btn_pl2am.Name = "btn_pl2am";
            this.btn_pl2am.Size = new System.Drawing.Size(95, 35);
            this.btn_pl2am.TabIndex = 9;
            this.btn_pl2am.Text = "PermissionList to AccessMask";
            this.btn_pl2am.UseVisualStyleBackColor = true;
            this.btn_pl2am.Click += new System.EventHandler(this.btn_pl2am_Click);
            // 
            // btn_getobjects
            // 
            this.btn_getobjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_getobjects.Location = new System.Drawing.Point(268, 10);
            this.btn_getobjects.Name = "btn_getobjects";
            this.btn_getobjects.Size = new System.Drawing.Size(75, 23);
            this.btn_getobjects.TabIndex = 10;
            this.btn_getobjects.Text = "GetObjects";
            this.btn_getobjects.UseVisualStyleBackColor = true;
            this.btn_getobjects.Click += new System.EventHandler(this.btn_getobjects_Click);
            // 
            // AccessMaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 431);
            this.Controls.Add(this.btn_getobjects);
            this.Controls.Add(this.btn_pl2am);
            this.Controls.Add(this.btn_am2pl);
            this.Controls.Add(this.txt_output);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_subobjno);
            this.Controls.Add(this.txt_objno);
            this.Controls.Add(this.cmb_objtype);
            this.Name = "AccessMaskForm";
            this.Text = "AccessMask Form";
            this.Load += new System.EventHandler(this.AccesMaskForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_objtype;
        private System.Windows.Forms.TextBox txt_objno;
        private System.Windows.Forms.TextBox txt_subobjno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.TextBox txt_output;
        private System.Windows.Forms.Button btn_am2pl;
        private System.Windows.Forms.Button btn_pl2am;
        private System.Windows.Forms.Button btn_getobjects;
    }
}

