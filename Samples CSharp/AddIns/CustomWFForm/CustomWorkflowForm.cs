using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace AddInSamples
{
    public partial class CustomWorkflowForm : Form
    {
        public bool bApproved = false;
        int _nDocNo = 0;

        public CustomWorkflowForm(int nDocNo)
        {
            InitializeComponent();
            _nDocNo = nDocNo;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            bApproved = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            bApproved = false;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            TheServer s = new TheServer();
            s.Connect(TheClientType.CustomApplication);

            TheDocument doc = new TheDocument();
            string strFileName = doc.Retrieve(_nDocNo, "", s);
            doc.View();
        }
    }
}
