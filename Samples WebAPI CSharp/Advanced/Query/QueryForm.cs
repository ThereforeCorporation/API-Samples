using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using Common;
using SharedServiceReference.ServiceRef_Update_it;
using SharedServiceReference;

namespace Query
{
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
        }

        private ThereforeServiceClient thereforeClient;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // 2. Create request parameters
                ExecuteSingleQueryParams parameters = new ExecuteSingleQueryParams();
                parameters.Query = new QueryObject();

                // 3. set the category number you want to search
                parameters.Query.CategoryNo = CategoryIds.FilesCategory;

                // 4. in this sample we want to be able to get in result list all below fields..
                parameters.Query.SelectedFieldsNoOrNames = new FieldNoOrNameList();
                parameters.Query.SelectedFieldsNoOrNames.Add(CategoryIds.Files_Extension.ToString());
                parameters.Query.SelectedFieldsNoOrNames.Add(CategoryIds.Files_Filename.ToString());
                parameters.Query.SelectedFieldsNoOrNames.Add(CategoryIds.Files_From_Folder.ToString());
                parameters.Query.SelectedFieldsNoOrNames.Add(CategoryIds.Files_Creation_Date.ToString());
                // 4.1. ..add addition INTERNAL field 'Created By'
                parameters.Query.SelectedFieldsNoOrNames.Add(((int)InternalQueryField.CreatedBy).ToString());

                // 5. add the query strings entered by the user to the conditions
                //do not add an empty value to the conditions. it will the result 
                parameters.Query.Conditions = new List<WSCondition>();
                if (txtExtension.Text != "")
                    parameters.Query.Conditions.Add(new WSCondition{FieldNoOrName = "Extension", Condition = txtExtension.Text});
                if (txtFileName.Text != "")
                    parameters.Query.Conditions.Add(new WSCondition{FieldNoOrName = "Filename", Condition = txtFileName.Text});
                if (txtFolder.Text != "")
                    parameters.Query.Conditions.Add(new WSCondition{FieldNoOrName = CategoryIds.Files_From_Folder.ToString(), Condition = txtFolder.Text});
                if (maskedTextBoxDate.Text != "" && maskedTextBoxDate.Text.IndexOf(' ') == -1)
                    parameters.Query.Conditions.Add(new WSCondition { FieldNoOrName = "Creation_Date", Condition = maskedTextBoxDate.Text });
                // 5.1. add filter by INTERNAL field 'Created By'
                parameters.Query.Conditions.Add(new WSCondition { FieldNoOrName = ((int)InternalQueryField.DocSize).ToString(), Condition = "> 1" });

                //execute the query and get result
                ExecuteSingleQueryResponse response = thereforeClient.ExecuteSingleQuery(new ExecuteSingleQueryRequest { parameters = parameters }).ExecuteSingleQueryResult;
                txt_result.Text += "Rows found: " + response.QueryResult.ResultRows.Count + Environment.NewLine;
                foreach (var row in response.QueryResult.ResultRows)
                {
                    txt_result.Text += "Result row values: ";

                    foreach (var cell in row.IndexValues)
                    {
                        txt_result.Text += cell + ",";
                    }

                    txt_result.Text += Environment.NewLine;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void QueryForm_Load(object sender, EventArgs e)
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

        private void QueryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thereforeClient != null)
                thereforeClient.Close();
        }
    }
}