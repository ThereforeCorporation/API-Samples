using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using System.ServiceModel;
using SharedServiceReference;
using SharedServiceReference.ServiceRef_Update_it;

namespace FullTextQuery
{
    public partial class FullTextQueryForm : Form
    {
        public FullTextQueryForm()
        {
            InitializeComponent();
        }

        private ThereforeServiceClient thereforeClient;

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (txtQuery.Text == "")
                MessageBox.Show("Please enter a query.", "Query Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    // 2. Create request parameters
                    ExecuteFullTextQueryParams parameters = new ExecuteFullTextQueryParams();
                    
                    // 3. Add all categories you want to search
                    parameters.FullTextQuery = new WSFullTextQuery();
                    parameters.FullTextQuery.Categories = new CategoryList();
                    parameters.FullTextQuery.Categories.Add(CategoryIds.FilesCategory);
                    parameters.FullTextQuery.ContextMode = WSFullTextContext.FTContextOff;
                    parameters.FullTextQuery.Search = txtQuery.Text;
                    //execute the query
                    ExecuteFullTextQueryResponse response = thereforeClient.ExecuteFullTextQuery(new ExecuteFullTextQueryRequest { parameters = parameters }).ExecuteFullTextQueryResult;

                    MessageBox.Show("Rows found: " + response.Results.Count, "Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FullTextQueryForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Create a client of the web service endpoint.
                if (thereforeClient == null)
                    if (null == (thereforeClient = ClientConnection.CreateClient()))
                        this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FullTextQueryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thereforeClient != null)
                thereforeClient.Close();
        }
    }
}