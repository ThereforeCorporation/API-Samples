using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Therefore.WebAPI.Service.Contract.v0001.Services;
using Therefore.WebAPI.Service.Contract.v0001.Messages;
using Common;
using Therefore.WebAPI.Service.Contract.v0001.Data;
using System.ServiceModel;

namespace SingleQuery
{
    public partial class SingleQueryForm : Form
    {
        public SingleQueryForm()
        {
            InitializeComponent();
        }

        private ChannelFactory<IThereforeService> thereforeService;
        private WSQueryResult result;

        private void btn_simple_Click(object sender, EventArgs e)
        {
            try
            {
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                ExecuteSimpleQueryParams parameters = new ExecuteSimpleQueryParams();
                parameters.CategoryNo = CategoryIds.FilesCategory;
                parameters.FieldNo = CategoryIds.Files_Extension;
                parameters.Condition = "d*";
                parameters.OrderByFieldNo = CategoryIds.Files_Extension;

                // 2. Call the ExecuteSimple of a service
                // Finds index data in category "ctgryno" where field "fieldno" starts with a "d"
                // and sorts the results by the value of field "fieldno".
                ExecuteSimpleQueryResponse response = service.ExecuteSimpleQuery(parameters);

                // Optional 3. Display a message box with the results.
                string info = "Rows found: " + response.QueryResult.ResultRows.Count + Environment.NewLine;
                response.QueryResult.ResultRows.ForEach( r => info += String.Format("Found document No: {0}, IndexValues count: {1}{2}", r.DocNo, r.IndexValues.Count, Environment.NewLine));
                txt_result.Text = info;

                result = response.QueryResult;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_execute_Click(object sender, EventArgs e)
        {
            try
            {
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                ExecuteSingleQueryParams parameters = new ExecuteSingleQueryParams();

                // 3. Set a category
                parameters.Query.CategoryNo = CategoryIds.FilesCategory;

                // 4. Add all visible fields except "Extension"
                parameters.Query.SelectedFieldsNoOrNames.Add(CategoryIds.Files_Creation_Date.ToString());
                parameters.Query.SelectedFieldsNoOrNames.Add(CategoryIds.Files_Filename.ToString());
                parameters.Query.SelectedFieldsNoOrNames.Add(CategoryIds.Files_From_Folder.ToString());

                // 5. Define query conditions
                parameters.Query.Conditions.Add(new WSCondition { FieldNoOrName = CategoryIds.Files_Extension.ToString(), Condition = "d* or t*" }); // using the column number
                parameters.Query.Conditions.Add(new WSCondition { FieldNoOrName = "Filename", Condition = "*Contr*" }); // using the column name
                
                // 6. Sort results by InvoiceNo
                parameters.Query.OrderByFieldsNoOrNames.Add(CategoryIds.Files_Creation_Date.ToString());

                // 8. Execute the query
                ExecuteSingleQueryResponse response = service.ExecuteSingleQuery(parameters);

                // Optional 9. Display Query definition and results in a MessageBox
                string info = "Rows found: " + response.QueryResult.ResultRows.Count + Environment.NewLine;
                response.QueryResult.ResultRows.ForEach(r => info += String.Format("Found document No: {0}, IndexValues count: {1}{2}", r.DocNo, r.IndexValues.Count, Environment.NewLine));
                txt_result.Text = info;

                result = response.QueryResult;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_process_Click(object sender, EventArgs e)
        {
            try
            {
                txt_result.Text = String.Empty;

                if (result.ResultRows.Count == 0)
                    txt_result.Text = "No data found";

                // Iterate through search result using the for-each constructs
                foreach (WSQueryResultRow row in result.ResultRows)
                {
                    txt_result.Text += "Doc number: " + row.DocNo + Environment.NewLine;
                    foreach (string val in row.IndexValues)
                    {
                        if (val == null)
                            txt_result.Text += "null" + Environment.NewLine;
                        else
                            txt_result.Text += val + Environment.NewLine;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Specification_Click(object sender, EventArgs e)
        {
            // 1B. Create a channel to the web service endpoint
            IThereforeService service = thereforeService.CreateChannel();

            // 8. Execute the request
            QuerySpecificationResponse response = service.GetQuerySpecification(new QuerySpecificationParams());

            // Optional 5. Get the list of valid condition operators
            txt_result.Text = String.Format(
                "Date Format: {1}{0}NumberDecimalSeparator: {2}{0}Condition operators: {0}{3}", 
                Environment.NewLine, response.DateFormat, response.NumberDecimalSeparator, response.ValidQueryOperators.Description);
        }

        private void SingleQueryForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1A. Get user credentials
                if (thereforeService == null)
                    if (null == (thereforeService = ThereforeServiceConnection.CreateChannelFactory()))
                        this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SingleQueryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thereforeService != null)
                thereforeService.Close();
        }
    }
}
