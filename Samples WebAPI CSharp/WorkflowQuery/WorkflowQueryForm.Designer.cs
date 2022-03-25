namespace WorkflowQuery
{
    partial class WorkflowQueryForm
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
            this.btn_specific = new System.Windows.Forms.Button();
            this.btn_all = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDocNo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStartWF = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbProcsNo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_specific
            // 
            this.btn_specific.Location = new System.Drawing.Point(29, 12);
            this.btn_specific.Name = "btn_specific";
            this.btn_specific.Size = new System.Drawing.Size(90, 40);
            this.btn_specific.TabIndex = 0;
            this.btn_specific.Text = "Find in Specific Process";
            this.btn_specific.UseVisualStyleBackColor = true;
            this.btn_specific.Click += new System.EventHandler(this.btn_specific_Click);
            // 
            // btn_all
            // 
            this.btn_all.Location = new System.Drawing.Point(141, 12);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(90, 40);
            this.btn_all.TabIndex = 1;
            this.btn_all.Text = "Find All";
            this.btn_all.UseVisualStyleBackColor = true;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Document No:";
            // 
            // tbDocNo
            // 
            this.tbDocNo.Location = new System.Drawing.Point(128, 17);
            this.tbDocNo.Name = "tbDocNo";
            this.tbDocNo.Size = new System.Drawing.Size(90, 20);
            this.tbDocNo.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbProcsNo);
            this.panel1.Controls.Add(this.btnStartWF);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbDocNo);
            this.panel1.Location = new System.Drawing.Point(12, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 100);
            this.panel1.TabIndex = 4;
            // 
            // btnStartWF
            // 
            this.btnStartWF.Location = new System.Drawing.Point(241, 17);
            this.btnStartWF.Name = "btnStartWF";
            this.btnStartWF.Size = new System.Drawing.Size(90, 46);
            this.btnStartWF.TabIndex = 4;
            this.btnStartWF.Text = "Start Workflow";
            this.btnStartWF.UseVisualStyleBackColor = true;
            this.btnStartWF.Click += new System.EventHandler(this.btnStartWF_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Process No:";
            // 
            // tbProcsNo
            // 
            this.tbProcsNo.Location = new System.Drawing.Point(128, 43);
            this.tbProcsNo.Name = "tbProcsNo";
            this.tbProcsNo.Size = new System.Drawing.Size(90, 20);
            this.tbProcsNo.TabIndex = 6;
            // 
            // WorkflowQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 226);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_all);
            this.Controls.Add(this.btn_specific);
            this.Name = "WorkflowQueryForm";
            this.Text = "Workflow Query";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkflowQueryForm_FormClosing);
            this.Load += new System.EventHandler(this.WorkflowQueryForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_specific;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDocNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbProcsNo;
        private System.Windows.Forms.Button btnStartWF;
    }
}

