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
            this.SuspendLayout();
            // 
            // btn_specific
            // 
            this.btn_specific.Location = new System.Drawing.Point(12, 12);
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
            // WorkflowQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 80);
            this.Controls.Add(this.btn_all);
            this.Controls.Add(this.btn_specific);
            this.Name = "WorkflowQueryForm";
            this.Text = "Workflow Query";
            this.Load += new System.EventHandler(this.WorkflowQueryForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkflowQueryForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_specific;
        private System.Windows.Forms.Button btn_all;
    }
}

