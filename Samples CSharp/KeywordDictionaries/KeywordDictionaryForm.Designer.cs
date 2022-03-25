namespace KeywordDictionaries
{
    partial class KeywordDictionaryForm
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
            this.txt_keydictno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_load = new System.Windows.Forms.Button();
            this.txt_content = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_deactivate_keyword = new System.Windows.Forms.TextBox();
            this.btn_deactivate = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.txt_delete_keyword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.txt_new_keyword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_save_changes = new System.Windows.Forms.Button();
            this.btn_delete_at = new System.Windows.Forms.Button();
            this.txt_delete_at = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_rename = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_rename_from = new System.Windows.Forms.TextBox();
            this.txt_rename_to = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_keydictno
            // 
            this.txt_keydictno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_keydictno.Location = new System.Drawing.Point(150, 12);
            this.txt_keydictno.Name = "txt_keydictno";
            this.txt_keydictno.Size = new System.Drawing.Size(154, 20);
            this.txt_keydictno.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Keyword Dictionary ID:";
            // 
            // btn_load
            // 
            this.btn_load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_load.Location = new System.Drawing.Point(310, 10);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 23);
            this.btn_load.TabIndex = 4;
            this.btn_load.Text = "Load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // txt_content
            // 
            this.txt_content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_content.Location = new System.Drawing.Point(12, 39);
            this.txt_content.Multiline = true;
            this.txt_content.Name = "txt_content";
            this.txt_content.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_content.Size = new System.Drawing.Size(373, 269);
            this.txt_content.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Deactivate Keyword ID:";
            // 
            // txt_deactivate_keyword
            // 
            this.txt_deactivate_keyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_deactivate_keyword.Location = new System.Drawing.Point(150, 316);
            this.txt_deactivate_keyword.Name = "txt_deactivate_keyword";
            this.txt_deactivate_keyword.Size = new System.Drawing.Size(154, 20);
            this.txt_deactivate_keyword.TabIndex = 7;
            // 
            // btn_deactivate
            // 
            this.btn_deactivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_deactivate.Location = new System.Drawing.Point(310, 314);
            this.btn_deactivate.Name = "btn_deactivate";
            this.btn_deactivate.Size = new System.Drawing.Size(75, 23);
            this.btn_deactivate.TabIndex = 8;
            this.btn_deactivate.Text = "(De)Activate";
            this.btn_deactivate.UseVisualStyleBackColor = true;
            this.btn_deactivate.Click += new System.EventHandler(this.btn_deactivate_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_delete.Location = new System.Drawing.Point(310, 342);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 11;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // txt_delete_keyword
            // 
            this.txt_delete_keyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_delete_keyword.Location = new System.Drawing.Point(150, 344);
            this.txt_delete_keyword.Name = "txt_delete_keyword";
            this.txt_delete_keyword.Size = new System.Drawing.Size(154, 20);
            this.txt_delete_keyword.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Delete Keyword ID:";
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.Location = new System.Drawing.Point(310, 398);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 14;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txt_new_keyword
            // 
            this.txt_new_keyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_new_keyword.Location = new System.Drawing.Point(150, 400);
            this.txt_new_keyword.Name = "txt_new_keyword";
            this.txt_new_keyword.Size = new System.Drawing.Size(154, 20);
            this.txt_new_keyword.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 403);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Add New Keyword:";
            // 
            // btn_save_changes
            // 
            this.btn_save_changes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save_changes.Location = new System.Drawing.Point(261, 483);
            this.btn_save_changes.Name = "btn_save_changes";
            this.btn_save_changes.Size = new System.Drawing.Size(124, 23);
            this.btn_save_changes.TabIndex = 15;
            this.btn_save_changes.Text = "Save Changes";
            this.btn_save_changes.UseVisualStyleBackColor = true;
            this.btn_save_changes.Click += new System.EventHandler(this.btn_save_changes_Click);
            // 
            // btn_delete_at
            // 
            this.btn_delete_at.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_delete_at.Location = new System.Drawing.Point(310, 370);
            this.btn_delete_at.Name = "btn_delete_at";
            this.btn_delete_at.Size = new System.Drawing.Size(75, 23);
            this.btn_delete_at.TabIndex = 18;
            this.btn_delete_at.Text = "Delete";
            this.btn_delete_at.UseVisualStyleBackColor = true;
            this.btn_delete_at.Click += new System.EventHandler(this.btn_delete_at_Click);
            // 
            // txt_delete_at
            // 
            this.txt_delete_at.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_delete_at.Location = new System.Drawing.Point(150, 372);
            this.txt_delete_at.Name = "txt_delete_at";
            this.txt_delete_at.Size = new System.Drawing.Size(154, 20);
            this.txt_delete_at.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Delete Keyword at Index:";
            // 
            // btn_rename
            // 
            this.btn_rename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_rename.Location = new System.Drawing.Point(310, 427);
            this.btn_rename.Name = "btn_rename";
            this.btn_rename.Size = new System.Drawing.Size(75, 23);
            this.btn_rename.TabIndex = 19;
            this.btn_rename.Text = "Rename";
            this.btn_rename.UseVisualStyleBackColor = true;
            this.btn_rename.Click += new System.EventHandler(this.btn_rename_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 432);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Change Keyword:";
            // 
            // txt_rename_from
            // 
            this.txt_rename_from.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_rename_from.Location = new System.Drawing.Point(150, 429);
            this.txt_rename_from.Name = "txt_rename_from";
            this.txt_rename_from.Size = new System.Drawing.Size(63, 20);
            this.txt_rename_from.TabIndex = 22;
            // 
            // txt_rename_to
            // 
            this.txt_rename_to.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_rename_to.Location = new System.Drawing.Point(241, 429);
            this.txt_rename_to.Name = "txt_rename_to";
            this.txt_rename_to.Size = new System.Drawing.Size(63, 20);
            this.txt_rename_to.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 432);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "to";
            // 
            // KeywordDictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 518);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_rename_to);
            this.Controls.Add(this.txt_rename_from);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_rename);
            this.Controls.Add(this.btn_delete_at);
            this.Controls.Add(this.txt_delete_at);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_save_changes);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txt_new_keyword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.txt_delete_keyword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_deactivate);
            this.Controls.Add(this.txt_deactivate_keyword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_content);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_keydictno);
            this.Name = "KeywordDictionaryForm";
            this.Text = "Keyword Dictionaries Sample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_keydictno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.TextBox txt_content;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_deactivate_keyword;
        private System.Windows.Forms.Button btn_deactivate;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.TextBox txt_delete_keyword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox txt_new_keyword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_save_changes;
        private System.Windows.Forms.Button btn_delete_at;
        private System.Windows.Forms.TextBox txt_delete_at;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_rename;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_rename_from;
        private System.Windows.Forms.TextBox txt_rename_to;
        private System.Windows.Forms.Label label7;
    }
}

