namespace Documents
{
    partial class DocumentsForm
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
            this.btn_archive = new System.Windows.Forms.Button();
            this.btn_retrieve = new System.Windows.Forms.Button();
            this.btn_extract = new System.Windows.Forms.Button();
            this.btn_view = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_archive
            // 
            this.btn_archive.Location = new System.Drawing.Point(22, 23);
            this.btn_archive.Name = "btn_archive";
            this.btn_archive.Size = new System.Drawing.Size(90, 40);
            this.btn_archive.TabIndex = 0;
            this.btn_archive.Text = "Archive Document";
            this.btn_archive.UseVisualStyleBackColor = true;
            this.btn_archive.Click += new System.EventHandler(this.btn_archive_Click);
            // 
            // btn_retrieve
            // 
            this.btn_retrieve.Location = new System.Drawing.Point(151, 22);
            this.btn_retrieve.Name = "btn_retrieve";
            this.btn_retrieve.Size = new System.Drawing.Size(90, 40);
            this.btn_retrieve.TabIndex = 1;
            this.btn_retrieve.Text = "Retrieve Document";
            this.btn_retrieve.UseVisualStyleBackColor = true;
            this.btn_retrieve.Click += new System.EventHandler(this.btn_retrieve_Click);
            // 
            // btn_extract
            // 
            this.btn_extract.Location = new System.Drawing.Point(22, 92);
            this.btn_extract.Name = "btn_extract";
            this.btn_extract.Size = new System.Drawing.Size(90, 40);
            this.btn_extract.TabIndex = 2;
            this.btn_extract.Text = "Extract Files from Document";
            this.btn_extract.UseVisualStyleBackColor = true;
            this.btn_extract.Click += new System.EventHandler(this.btn_extract_Click);
            // 
            // btn_view
            // 
            this.btn_view.Location = new System.Drawing.Point(151, 92);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(90, 40);
            this.btn_view.TabIndex = 3;
            this.btn_view.Text = "View Document";
            this.btn_view.UseVisualStyleBackColor = true;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // DocumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 175);
            this.Controls.Add(this.btn_view);
            this.Controls.Add(this.btn_extract);
            this.Controls.Add(this.btn_retrieve);
            this.Controls.Add(this.btn_archive);
            this.Name = "DocumentsForm";
            this.Text = "Documents";
            this.Load += new System.EventHandler(this.DocumentsForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocumentsForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_archive;
        private System.Windows.Forms.Button btn_retrieve;
        private System.Windows.Forms.Button btn_extract;
        private System.Windows.Forms.Button btn_view;
    }
}

