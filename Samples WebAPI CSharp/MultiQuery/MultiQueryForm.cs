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
using Therefore.WebAPI.Service.Contract.v0001.Data;
using System.ServiceModel;
using Common;

namespace MultiQuery
{
    public partial class MultiQueryForm : Form
    {
        public MultiQueryForm()
        {
            InitializeComponent();
        }

        private ChannelFactory<IThereforeService> thereforeService;
        private List<WSQueryResult> multiResult;

        private void btn_execute_Click(object sender, EventArgs e)
        {
            try
            {
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                ExecuteMultiQueryParams parameters = new ExecuteMultiQueryParams();

	            // 3. Create and add two or more queries
	            WSSingleQuery query = new WSSingleQuery();
	            query.CategoryNo = CategoryIds.FilesCategory;
                //!. left query.SelectFields empty to get all the fields
	            query.Conditions.Add(new WSCondition{FieldNoOrName = "Filename", Condition = "*Contract*"}); // using the column 
                query.OrderByFieldsNoOrNames.Add(CategoryIds.Files_Creation_Date.ToString());
	            parameters.Queries.Add(query);
	
	            WSSingleQuery query2 = new WSSingleQuery();
                query2.CategoryNo = CategoryIds.SimpleInvoiceCategory;
	            //!. left query.SelectFields empty to get all the fields
                query2.OrderByFieldsNoOrNames.Add(CategoryIds.SimpleInvoice_Customer_No.ToString());
	            parameters.Queries.Add(query2);
	
	            // 4. Execute the multi-query
	            ExecuteMultiQueryResponse response = service.ExecuteMultiQuery(parameters);
	
	            // Optional 5. Display multi-query definition and results in MessageBox
                string info = String.Empty;
                response.QueryResults.ForEach(res => info += String.Format("Category No: {0}. Number of documents in result: {1}{2}", res.CategoryNo, res.ResultRows.Count, Environment.NewLine));
	            System.Windows.Forms.MessageBox.Show(info);

                multiResult = response.QueryResults;
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
	            txt_result.Text = "";
	         
	            // Iterate through search results using the nested for-each constructs
	            foreach (WSQueryResult queryResult in multiResult)
	            {
                    txt_result.Text += "===== Category No: " + queryResult.CategoryNo + "=====" + Environment.NewLine;
                    // Iterate through search result using the for-each constructs
                    foreach (WSQueryResultRow row in queryResult.ResultRows)
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
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MultiQueryForm_Load(object sender, EventArgs e)
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

        private void MultiQueryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thereforeService != null)
                thereforeService.Close();
        }
    }
}
