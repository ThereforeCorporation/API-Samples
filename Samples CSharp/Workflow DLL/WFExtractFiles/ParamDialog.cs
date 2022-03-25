using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFExtractFiles
{
    public partial class ParamDialog : Form
    {
        public ParamDialog()
        {
            InitializeComponent();
        }

        private String path;

        private void btn_browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderbrowser = new FolderBrowserDialog();
            if (folderbrowser.ShowDialog() == DialogResult.OK)
                txt_path.Text = folderbrowser.SelectedPath;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.path = txt_path.Text;
            this.Close();
        }

        public String Path
        {
            get { return path; }
            set
            {
                txt_path.Text = path = value;
            }
        }
    }
}
