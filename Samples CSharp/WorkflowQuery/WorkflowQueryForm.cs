using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace WorkflowQuery
{
    public partial class WorkflowQueryForm : Form
    {
        public WorkflowQueryForm()
        {
            InitializeComponent();
        }

        private TheServer server;

        private void WorkflowQueryForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Connect to the Therefore™ server
                server = new TheServer();
                server.Connect(TheClientType.CustomApplication);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_specific_Click(object sender, EventArgs e)
        {
            try
            {
	            // 2. Create a new query
	            TheQuery wfQuery = new TheQuery();
	
	            // 3. Execute the query on the server
	            TheQueryResult wfResult = wfQuery.ExecuteWorkflowQuery(
	                1, TheWorkflowFlags.AllInstances, server);
	
	            // Optional 4. Display the results in a messageBox
	            MessageBox.Show(wfResult.ToString());
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            try
            {
	            // 2. Create a new query
	            TheQuery wfQuery = new TheQuery();
	
	            // 3. Execute the query on the server
	            TheMultiQueryResult wfResult = wfQuery.GetAllWorkflowInstances(
	                TheWorkflowFlags.AllInstances, server);
	
	            // Optional 4. Display the results in a messageBox
	            MessageBox.Show(wfResult.ToString());
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WorkflowQueryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Disconnect();
        }
    }
}
