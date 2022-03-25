using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace AsynchronousQuery
{
    public partial class AsynchronousQueryForm : Form
    {
        private int _singlequeryID;
        private int _multiqueryID;
        private TheServer _server;

        public AsynchronousQueryForm()
        {
            _singlequeryID = 0;
            _multiqueryID = 0;
            _server = null;
            InitializeComponent();
        }

        //---------------- MULTI QUERY ----------------//
        private void btn_execute_multi_Click(object sender, EventArgs e)
        {
            try
            {
                //create a multi query
                TheMultiQuery multiquery = new TheMultiQuery();
                TheQuery query1 = new TheQuery();
                query1.Category.Load("Files", Server);
                query1.SelectFields.AddAll();
                multiquery.Add(query1);
                TheQuery query2 = new TheQuery();
                query2.Category.Load("Simple Invoice", Server);
                query2.SelectFields.AddAll();
                multiquery.Add(query2);

                multiquery.RowBlockSize = 5;//for testing set the block size to a small value to better see the difference to synchronous querying
                TheMultiQueryResult multiresult = multiquery.ExecuteAsync(Server);//execute the query
                _multiqueryID = multiquery.QueryID;//store the query id for later
                txt_output.Text = "";
                DisplayMultiQueryResult(multiresult);//executing the query will always return the first batch of results
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_getnext_multi_Click(object sender, EventArgs e)
        {
            try
            {
                if (_multiqueryID == 0)
                {
                    MessageBox.Show("No multi query has been started.");
                    return;
                }
                TheMultiQuery multiquery = new TheMultiQuery();
                TheQuery query1 = new TheQuery();
                query1.Category.Load("Files", Server);
                query1.SelectFields.AddAll();
                multiquery.Add(query1);
                TheQuery query2 = new TheQuery();
                query2.Category.Load("Simple Invoice", Server);
                query2.SelectFields.AddAll();
                multiquery.Add(query2);

                multiquery.RowBlockSize = 5;
                TheMultiQueryResult multiresult = new TheMultiQueryResult();
                //retrieve the next batch of results
                bool end = multiquery.GetNextResultRows(Server, _multiqueryID, out multiresult);
                DisplayMultiQueryResult(multiresult);
                if (end)//when GetNextResultRows returns true, the last batch of results has been returned
                {
                    txt_output.Text += "END OF RESULTS";
                    multiquery.ReleaseQuery(Server, _multiqueryID);//when the end of results have been reached release the query on the server
                    _multiqueryID = 0;//when this is set to 0 it the if above will prevent GetNextResultRows to be called again
                    //if GetNextResultRows is called again after it returned true, an exception will be thrown
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //---------------- DISPLAYING CONTENT ----------------//
        private void DisplayMultiQueryResult(TheMultiQueryResult multiresult)
        {
            txt_output.Text += Environment.NewLine + "Next multi query result batch" + Environment.NewLine;
            for (int i = 0; i < multiresult.Count; i++ )
            {
                //for a multi query display the results one by one. an asynchronous execute will bring the results in order by category
                //but one batch can still contain results from more than one query
                TheQueryResult result = multiresult[i];
                DisplaySingleQueryResult(result);
            }
            txt_output.Text += Environment.NewLine;
        }

        private void DisplaySingleQueryResult(TheQueryResult result)
        {
            txt_output.Text += String.Format("Result for Category {0} - Count {1}" + Environment.NewLine, result.CategoryNo, result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                TheQueryResultRow row = result[i];
                txt_output.Text += String.Format("\tDocNo: {0} - {1}" + Environment.NewLine, row.DocNo, row.ToString());
            }
        }

        //---------------- SINGLE QUERY ----------------//
        private void btn_execute_single_Click(object sender, EventArgs e)
        {
            try
            {
                //create a single a query
                TheQuery singlequery = new TheQuery();
                singlequery.Category.Load("Files", Server);
                singlequery.SelectFields.AddAll();
                singlequery.RowBlockSize = 5;//set the block size to a small value to see the effect
                TheQueryResult singleresult = singlequery.ExecuteAsync(Server);//execute the query
                _singlequeryID = singlequery.QueryID;//store the query id for later
                txt_output.Text = "";
                DisplaySingleQueryResult(singleresult);//executing the query will always return the first batch of results
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_getnext_single_Click(object sender, EventArgs e)
        {
            try
            {
                if (_singlequeryID == 0)
                {
                    MessageBox.Show("No single query has been started.");
                    return;
                }
                TheQuery singlequery = new TheQuery();
                singlequery.Category.Load(54, Server);
                singlequery.SelectFields.AddAll();
                singlequery.RowBlockSize = 5;
                TheQueryResult result = new TheQueryResult();
                //retrieve the next batch of results
                bool end = singlequery.GetNextResultRows(Server, _singlequeryID, out result);
                DisplaySingleQueryResult(result);
                if (end)//when GetNextResultRows returns true, the last batch of results has been returned
                {
                    txt_output.Text += "END OF RESULTS";
                    singlequery.ReleaseQuery(Server, _singlequeryID);//when the end of results have been reached release the query on the server
                    _singlequeryID = 0;//when this is set to 0 it the if above will prevent GetNextResultRows to be called again
                    //if GetNextResultRows is called again after it returned true, an exception will be thrown
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private TheServer Server //using this property will make sure to always have a connected server
        {
            get
            {
                if (_server == null)
                    _server = new TheServer();
                if (!_server.Connected)
                    _server.Connect();
                return _server;
            }
        }

        private void AsynchronousQueryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Server.Disconnect();; //be sure to disconnect from the server
            }
            catch (Exception){}//if there is an exception thrown now there is no need to handle it anymore
        }
    }
}
