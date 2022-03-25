using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class LoginDialog : Form
    {
        public LoginDialog()
        {
            InitializeComponent();
        }

        public CrdentialsType GetCrdentialsType()
        {
            if (rbWindowsAuth.Checked)
                return CrdentialsType.Windows;
            else 
                return CrdentialsType.UserName;
        }

        public string GetTenantName()
        {
            return tbTenantName.Text;
        }

        public string GetNodeName()
        {
            return tbNodeName.Text;
        }

        public string GetUserName()
        {
            return tbUserName.Text;
        }

        public string GetPassword()
        {
            return tbPassword.Text;
        }

        private void rbApplicationAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
                label1.Enabled = label2.Enabled = tbUserName.Enabled = tbPassword.Enabled = (sender as RadioButton).Checked;
        }
    }

    public enum CrdentialsType
    {
        Windows,
        UserName
    }
}
