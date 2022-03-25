using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace MultiQuery
{
    public partial class MultiQueryForm : Form
    {
        public MultiQueryForm()
        {
            InitializeComponent();
        }

        private TheServer server;
        private TheMultiQueryResult multiResult;

        private void MultiQueryForm_Load(object sender, EventArgs e)
        {
            try
            {
	            // 1. Connect to the Therefore server
	            server = new TheServer();
	            server.Connect(TheClientType.CustomApplication);
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
	            // 2. Create a new multi-query
	            TheMultiQuery multiQuery = new TheMultiQuery();
	
	            // 3. Create and add two or more queries
	            TheQuery query = new TheQuery();
	            query.Category.Load("Files", server);
	            query.SelectFields.AddAll();
	            query.Conditions.Add("Filename", "*Moya*"); // using the column 
	            query.OrderByFields.Add("Creation_Date");
	            multiQuery.Add(query);
	
	            TheQuery query2 = new TheQuery();
	            query2.Category.Load("Simple Invoice", server);
	            query2.SelectFields.AddAll();
	            multiQuery.Add(query2);
	
	            // 4. Execute the multi-query
	            multiResult = multiQuery.Execute(server);
	
	            // Optional 5. Display multi-query definition and results in MessageBox
	            System.Windows.Forms.MessageBox.Show(multiQuery.ToString()
	                + "\r\n---------------------------------------------------\r\n\r\n"
	                + multiResult.ToString());
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
	            // Iterate through search results using nested for-loops
	            for (int i = 0; i < multiResult.Count; i++)
	            {
	                for (int j = 0; j < multiResult[i].Count; j++)
	                {
	                    for (int k = 0; k < multiResult[i][j].Count; k++)
	                    {
	                        // Access the k-th field in the j-th row of the i-th query
	                        if (this.multiResult[i][j][k] != null)
	                            txt_result.Text += multiResult[i][j][k].ToString() + "\r\n";
	                    }
	                }
	            }
	         
	            // Iterate through search results using the nested for-each constructs
	            foreach (TheQueryResult QueryResult in multiResult)
	            {
	                foreach (TheQueryResultRow row in QueryResult)
	                {
	                    foreach (object obj in row)
	                    {
	                        if (obj is DBNull)
	                            txt_result.Text += "null\r\n";
	                        else
	                            txt_result.Text += obj.ToString()+ "\r\n";
	                    }
	                }
	            }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
