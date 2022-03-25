namespace FullTextQuery
{
    partial class FullTextQueryForm
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
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_fuzzysearch = new System.Windows.Forms.TextBox();
            this.cmb_sortorder = new System.Windows.Forms.ComboBox();
            this.chk_thesaurus = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter your FullText Query below.";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(15, 37);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(241, 20);
            this.txtQuery.TabIndex = 1;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExecute.Location = new System.Drawing.Point(11, 161);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(92, 161);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sort Order:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fuzzy Search Level (0-5):";
            // 
            // txt_fuzzysearch
            // 
            this.txt_fuzzysearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_fuzzysearch.Location = new System.Drawing.Point(179, 98);
            this.txt_fuzzysearch.Name = "txt_fuzzysearch";
            this.txt_fuzzysearch.Size = new System.Drawing.Size(77, 20);
            this.txt_fuzzysearch.TabIndex = 8;
            // 
            // cmb_sortorder
            // 
            this.cmb_sortorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_sortorder.FormattingEnabled = true;
            this.cmb_sortorder.Location = new System.Drawing.Point(140, 68);
            this.cmb_sortorder.Name = "cmb_sortorder";
            this.cmb_sortorder.Size = new System.Drawing.Size(116, 21);
            this.cmb_sortorder.TabIndex = 10;
            // 
            // chk_thesaurus
            // 
            this.chk_thesaurus.AutoSize = true;
            this.chk_thesaurus.Location = new System.Drawing.Point(15, 127);
            this.chk_thesaurus.Name = "chk_thesaurus";
            this.chk_thesaurus.Size = new System.Drawing.Size(98, 17);
            this.chk_thesaurus.TabIndex = 13;
            this.chk_thesaurus.Text = "Use Thesaurus";
            this.chk_thesaurus.UseVisualStyleBackColor = true;
            // 
            // FullTextQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 196);
            this.Controls.Add(this.chk_thesaurus);
            this.Controls.Add(this.cmb_sortorder);
            this.Controls.Add(this.txt_fuzzysearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.label1);
            this.Name = "FullTextQueryForm";
            this.Text = "Full-Text Query";
            this.Load += new System.EventHandler(this.FullTextQueryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_fuzzysearch;
        private System.Windows.Forms.ComboBox cmb_sortorder;
        private System.Windows.Forms.CheckBox chk_thesaurus;
    }
}

