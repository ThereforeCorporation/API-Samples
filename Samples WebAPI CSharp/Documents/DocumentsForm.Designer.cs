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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDocNo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_archive
            // 
            this.btn_archive.Location = new System.Drawing.Point(19, 12);
            this.btn_archive.Name = "btn_archive";
            this.btn_archive.Size = new System.Drawing.Size(90, 40);
            this.btn_archive.TabIndex = 0;
            this.btn_archive.Text = "Archive Document";
            this.btn_archive.UseVisualStyleBackColor = true;
            this.btn_archive.Click += new System.EventHandler(this.btn_archive_Click);
            // 
            // btn_retrieve
            // 
            this.btn_retrieve.Location = new System.Drawing.Point(102, 61);
            this.btn_retrieve.Name = "btn_retrieve";
            this.btn_retrieve.Size = new System.Drawing.Size(90, 40);
            this.btn_retrieve.TabIndex = 1;
            this.btn_retrieve.Text = "Retrieve Document";
            this.btn_retrieve.UseVisualStyleBackColor = true;
            this.btn_retrieve.Click += new System.EventHandler(this.btn_retrieve_Click);
            // 
            // btn_extract
            // 
            this.btn_extract.Location = new System.Drawing.Point(6, 61);
            this.btn_extract.Name = "btn_extract";
            this.btn_extract.Size = new System.Drawing.Size(90, 40);
            this.btn_extract.TabIndex = 2;
            this.btn_extract.Text = "Extract Files from Document";
            this.btn_extract.UseVisualStyleBackColor = true;
            this.btn_extract.Click += new System.EventHandler(this.btn_extract_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDocNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_extract);
            this.groupBox1.Controls.Add(this.btn_retrieve);
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 111);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Document Number:";
            // 
            // tbDocNo
            // 
            this.tbDocNo.Location = new System.Drawing.Point(7, 35);
            this.tbDocNo.Name = "tbDocNo";
            this.tbDocNo.Size = new System.Drawing.Size(185, 20);
            this.tbDocNo.TabIndex = 5;
            this.tbDocNo.Text = "1";
            this.tbDocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DocumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 181);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_archive);
            this.Name = "DocumentsForm";
            this.Text = "Documents";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocumentsForm_FormClosing);
            this.Load += new System.EventHandler(this.DocumentsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_archive;
        private System.Windows.Forms.Button btn_retrieve;
        private System.Windows.Forms.Button btn_extract;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDocNo;
    }
}

