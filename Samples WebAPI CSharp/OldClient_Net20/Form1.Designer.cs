namespace OldClient_Net20
{
    partial class Form1
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
            this.btnExecte = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTenantName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnExecte
            // 
            this.btnExecte.Location = new System.Drawing.Point(244, 12);
            this.btnExecte.Name = "btnExecte";
            this.btnExecte.Size = new System.Drawing.Size(161, 57);
            this.btnExecte.TabIndex = 0;
            this.btnExecte.Text = "Execute web opertation";
            this.btnExecte.UseVisualStyleBackColor = true;
            this.btnExecte.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tenant Name:";
            // 
            // tbTenantName
            // 
            this.tbTenantName.Location = new System.Drawing.Point(102, 31);
            this.tbTenantName.Name = "tbTenantName";
            this.tbTenantName.Size = new System.Drawing.Size(104, 20);
            this.tbTenantName.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 223);
            this.Controls.Add(this.tbTenantName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExecte);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExecte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTenantName;
    }
}

