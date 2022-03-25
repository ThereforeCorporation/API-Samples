namespace Security
{
    partial class SecurityForm
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
            this.btn_get_rights = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_get_rights
            // 
            this.btn_get_rights.Location = new System.Drawing.Point(12, 12);
            this.btn_get_rights.Name = "btn_get_rights";
            this.btn_get_rights.Size = new System.Drawing.Size(100, 40);
            this.btn_get_rights.TabIndex = 0;
            this.btn_get_rights.Text = "Get Object Rights";
            this.btn_get_rights.UseVisualStyleBackColor = true;
            this.btn_get_rights.Click += new System.EventHandler(this.btn_get_rights_Click);
            // 
            // SecurityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 207);
            this.Controls.Add(this.btn_get_rights);
            this.Name = "SecurityForm";
            this.Text = "Security";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SecurityForm_FormClosing);
            this.Load += new System.EventHandler(this.SecurityForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_get_rights;
    }
}

