namespace DocumentOperations
{
    partial class DocumentOperationsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mtbDocNo = new System.Windows.Forms.MaskedTextBox();
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExtractPath = new System.Windows.Forms.TextBox();
            this.btnExtractBrowse = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtUpdatePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdateBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter a document number below.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "DocNo:";
            // 
            // mtbDocNo
            // 
            this.mtbDocNo.Location = new System.Drawing.Point(92, 34);
            this.mtbDocNo.Mask = "00000";
            this.mtbDocNo.Name = "mtbDocNo";
            this.mtbDocNo.PromptChar = ' ';
            this.mtbDocNo.Size = new System.Drawing.Size(100, 20);
            this.mtbDocNo.TabIndex = 2;
            this.mtbDocNo.ValidatingType = typeof(int);
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(12, 145);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(75, 23);
            this.btnExtract.TabIndex = 3;
            this.btnExtract.Text = "Extract";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(93, 145);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(255, 145);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Extract To:";
            // 
            // txtExtractPath
            // 
            this.txtExtractPath.Location = new System.Drawing.Point(92, 66);
            this.txtExtractPath.Name = "txtExtractPath";
            this.txtExtractPath.ReadOnly = true;
            this.txtExtractPath.Size = new System.Drawing.Size(244, 20);
            this.txtExtractPath.TabIndex = 7;
            // 
            // btnExtractBrowse
            // 
            this.btnExtractBrowse.Location = new System.Drawing.Point(338, 64);
            this.btnExtractBrowse.Name = "btnExtractBrowse";
            this.btnExtractBrowse.Size = new System.Drawing.Size(40, 23);
            this.btnExtractBrowse.TabIndex = 8;
            this.btnExtractBrowse.Text = "...";
            this.btnExtractBrowse.UseVisualStyleBackColor = true;
            this.btnExtractBrowse.Click += new System.EventHandler(this.btnExtractBrowse_Click);
            // 
            // txtUpdatePath
            // 
            this.txtUpdatePath.Location = new System.Drawing.Point(92, 98);
            this.txtUpdatePath.Name = "txtUpdatePath";
            this.txtUpdatePath.ReadOnly = true;
            this.txtUpdatePath.Size = new System.Drawing.Size(244, 20);
            this.txtUpdatePath.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Update With:";
            // 
            // btnUpdateBrowse
            // 
            this.btnUpdateBrowse.Location = new System.Drawing.Point(338, 96);
            this.btnUpdateBrowse.Name = "btnUpdateBrowse";
            this.btnUpdateBrowse.Size = new System.Drawing.Size(40, 23);
            this.btnUpdateBrowse.TabIndex = 11;
            this.btnUpdateBrowse.Text = "...";
            this.btnUpdateBrowse.UseVisualStyleBackColor = true;
            this.btnUpdateBrowse.Click += new System.EventHandler(this.btnUpdateBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(174, 145);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // DocumentOperationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 180);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnUpdateBrowse);
            this.Controls.Add(this.txtUpdatePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExtractBrowse);
            this.Controls.Add(this.txtExtractPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.mtbDocNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DocumentOperationsForm";
            this.Text = "Document Operations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtbDocNo;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExtractPath;
        private System.Windows.Forms.Button btnExtractBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtUpdatePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdateBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnUpdate;
    }
}

