namespace AsynchronousQuery
{
    partial class AsynchronousQueryForm
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
            this.btn_execute_multi = new System.Windows.Forms.Button();
            this.btn_execute_single = new System.Windows.Forms.Button();
            this.btn_getnext_multi = new System.Windows.Forms.Button();
            this.btn_getnext_single = new System.Windows.Forms.Button();
            this.txt_output = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_execute_multi
            // 
            this.btn_execute_multi.Location = new System.Drawing.Point(12, 12);
            this.btn_execute_multi.Name = "btn_execute_multi";
            this.btn_execute_multi.Size = new System.Drawing.Size(106, 43);
            this.btn_execute_multi.TabIndex = 0;
            this.btn_execute_multi.Text = "Execute Multi Query";
            this.btn_execute_multi.UseVisualStyleBackColor = true;
            this.btn_execute_multi.Click += new System.EventHandler(this.btn_execute_multi_Click);
            // 
            // btn_execute_single
            // 
            this.btn_execute_single.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_execute_single.Location = new System.Drawing.Point(201, 12);
            this.btn_execute_single.Name = "btn_execute_single";
            this.btn_execute_single.Size = new System.Drawing.Size(106, 43);
            this.btn_execute_single.TabIndex = 1;
            this.btn_execute_single.Text = "Execute Single Query";
            this.btn_execute_single.UseVisualStyleBackColor = true;
            this.btn_execute_single.Click += new System.EventHandler(this.btn_execute_single_Click);
            // 
            // btn_getnext_multi
            // 
            this.btn_getnext_multi.Location = new System.Drawing.Point(12, 61);
            this.btn_getnext_multi.Name = "btn_getnext_multi";
            this.btn_getnext_multi.Size = new System.Drawing.Size(106, 43);
            this.btn_getnext_multi.TabIndex = 2;
            this.btn_getnext_multi.Text = "Get Next Rows Multi Query";
            this.btn_getnext_multi.UseVisualStyleBackColor = true;
            this.btn_getnext_multi.Click += new System.EventHandler(this.btn_getnext_multi_Click);
            // 
            // btn_getnext_single
            // 
            this.btn_getnext_single.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_getnext_single.Location = new System.Drawing.Point(201, 61);
            this.btn_getnext_single.Name = "btn_getnext_single";
            this.btn_getnext_single.Size = new System.Drawing.Size(106, 43);
            this.btn_getnext_single.TabIndex = 3;
            this.btn_getnext_single.Text = "Get Next Rows Single Query";
            this.btn_getnext_single.UseVisualStyleBackColor = true;
            this.btn_getnext_single.Click += new System.EventHandler(this.btn_getnext_single_Click);
            // 
            // txt_output
            // 
            this.txt_output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_output.Location = new System.Drawing.Point(12, 110);
            this.txt_output.Multiline = true;
            this.txt_output.Name = "txt_output";
            this.txt_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_output.Size = new System.Drawing.Size(295, 454);
            this.txt_output.TabIndex = 4;
            // 
            // AsynchronousQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 576);
            this.Controls.Add(this.txt_output);
            this.Controls.Add(this.btn_getnext_single);
            this.Controls.Add(this.btn_getnext_multi);
            this.Controls.Add(this.btn_execute_single);
            this.Controls.Add(this.btn_execute_multi);
            this.Name = "AsynchronousQueryForm";
            this.Text = "Asynchronous Query Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AsynchronousQueryForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_execute_multi;
        private System.Windows.Forms.Button btn_execute_single;
        private System.Windows.Forms.Button btn_getnext_multi;
        private System.Windows.Forms.Button btn_getnext_single;
        private System.Windows.Forms.TextBox txt_output;
    }
}

