using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OldClient_Net20.ServiceRef_Update_it_;
using System.Net;

namespace OldClient_Net20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //TODO: First of all please update 'Web References' for available Therefore service.

            //TODO: comment/uncomment for testing (!!! only one method should be used: UseUserNamePassAuthMethod or UseWindowsAuthMethod)
            //ExecuteUserNamePassAuthOperation();
            ExecuteWindowsAuthOperation();
        }

        private void ExecuteUserNamePassAuthOperation()
        {
            //basic
            OldClient_Net20.ServiceRef_Update_it_.ThereforeWS0001_SoapUserPassword service;

            if (!String.IsNullOrEmpty(tbTenantName.Text))
                service = new ThereforeWS0001_SoapUserPasswordHttpsWithTenantSupport(tbTenantName.Text);
            else
                service = new OldClient_Net20.ServiceRef_Update_it_.ThereforeWS0001_SoapUserPassword();
            
            NetworkCredential netCredential = new NetworkCredential("username", "userpassword"); //TODO: update with correct name/password
            Uri uri = new Uri(service.Url);
            ICredentials credentials = netCredential.GetCredential(uri, "Basic");
            service.Credentials = credentials;
            service.PreAuthenticate = true;

            GetCategoriesTreeResponse response = service.GetCategoriesTree(new GetCategoriesTreeParams());
            MessageBox.Show("Found :" + response.TreeItems.Length.ToString());
        }

        private void ExecuteWindowsAuthOperation()
        {
            //win
            OldClient_Net20.ServiceRef_Update_it_.ThereforeWS0001_SoapWinCredentials service;

            if (!String.IsNullOrEmpty(tbTenantName.Text))
                service = new ThereforeWS0001__SoapWinCredentialsHttpsWithTenantSupport(tbTenantName.Text);
            else
                service = new OldClient_Net20.ServiceRef_Update_it_.ThereforeWS0001_SoapWinCredentials();

            service.UseDefaultCredentials = true;

            GetCategoriesTreeResponse response = service.GetCategoriesTree(new GetCategoriesTreeParams());
            MessageBox.Show("Found :" + response.TreeItems.Length.ToString());
        }
    }

    public class ThereforeWS0001_SoapUserPasswordHttpsWithTenantSupport : OldClient_Net20.ServiceRef_Update_it_.ThereforeWS0001_SoapUserPassword
    {
        private string tenantName;

        public ThereforeWS0001_SoapUserPasswordHttpsWithTenantSupport(string tenantName)
        {
            this.tenantName = tenantName;
        }

        protected override System.Net.WebRequest GetWebRequest(Uri uri)
        {
            var request = base.GetWebRequest(uri);
            request.Headers.Add("TenantName", tenantName);
            return request;
        }
    }

    public class ThereforeWS0001__SoapWinCredentialsHttpsWithTenantSupport : OldClient_Net20.ServiceRef_Update_it_.ThereforeWS0001_SoapWinCredentials
    {
        private string tenantName;

        public ThereforeWS0001__SoapWinCredentialsHttpsWithTenantSupport(string tenantName)
        {
            this.tenantName = tenantName;
        }
        protected override System.Net.WebRequest GetWebRequest(Uri uri)
        {
            var request = base.GetWebRequest(uri);
            request.Headers.Add("TenantName", tenantName);
            return request;
        }
    }
}
