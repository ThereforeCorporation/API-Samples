namespace MultiQuery
{
    partial class MultiQueryForm
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
            this.btn_execute = new System.Windows.Forms.Button();
            this.btn_process = new System.Windows.Forms.Button();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_execute
            // 
            this.btn_execute.Location = new System.Drawing.Point(12, 12);
            this.btn_execute.Name = "btn_execute";
            this.btn_execute.Size = new System.Drawing.Size(90, 40);
            this.btn_execute.TabIndex = 0;
            this.btn_execute.Text = "Execute Query";
            this.btn_execute.UseVisualStyleBackColor = true;
            this.btn_execute.Click += new System.EventHandler(this.btn_execute_Click);
            // 
            // btn_process
            // 
            this.btn_process.Location = new System.Drawing.Point(191, 12);
            this.btn_process.Name = "btn_process";
            this.btn_process.Size = new System.Drawing.Size(90, 40);
            this.btn_process.TabIndex = 1;
            this.btn_process.Text = "Process Query";
            this.btn_process.UseVisualStyleBackColor = true;
            this.btn_process.Click += new System.EventHandler(this.btn_process_Click);
            // 
            // txt_result
            // 
            this.txt_result.Location = new System.Drawing.Point(12, 70);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ReadOnly = true;
            this.txt_result.Size = new System.Drawing.Size(269, 218);
            this.txt_result.TabIndex = 2;
            // 
            // MultiQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 300);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.btn_process);
            this.Controls.Add(this.btn_execute);
            this.Name = "MultiQueryForm";
            this.Text = "Multi Query";
            this.Load += new System.EventHandler(this.MultiQueryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_execute;
        private System.Windows.Forms.Button btn_process;
        private System.Windows.Forms.TextBox txt_result;
    }
}

