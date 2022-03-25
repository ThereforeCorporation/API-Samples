namespace FileAndFullTextQuery
{
    partial class FileAndFullTextQueryForm
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
            this.btn_full_text = new System.Windows.Forms.Button();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_full_text
            // 
            this.btn_full_text.Location = new System.Drawing.Point(108, 12);
            this.btn_full_text.Name = "btn_full_text";
            this.btn_full_text.Size = new System.Drawing.Size(90, 40);
            this.btn_full_text.TabIndex = 1;
            this.btn_full_text.Text = "Full Text Query";
            this.btn_full_text.UseVisualStyleBackColor = true;
            this.btn_full_text.Click += new System.EventHandler(this.btn_full_text_Click);
            // 
            // txt_result
            // 
            this.txt_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_result.Location = new System.Drawing.Point(12, 77);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ReadOnly = true;
            this.txt_result.Size = new System.Drawing.Size(405, 381);
            this.txt_result.TabIndex = 4;
            // 
            // FileAndFullTextQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 470);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.btn_full_text);
            this.Name = "FileAndFullTextQueryForm";
            this.Text = "File and Full Text Query";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileAndFullTextQueryForm_FormClosing);
            this.Load += new System.EventHandler(this.FileAndFullTextQueryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_full_text;
        private System.Windows.Forms.TextBox txt_result;
    }
}

