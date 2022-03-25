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
using System.ServiceModel;
using Common;

namespace WorkflowQuery
{
    public partial class WorkflowQueryForm : Form
    {
        public WorkflowQueryForm()
        {
            InitializeComponent();
        }

        private ChannelFactory<IThereforeService> thereforeService;

        private void btn_specific_Click(object sender, EventArgs e)
        {
            try
            {
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                ExecuteWorkflowQueryForProcessParams parameters = new ExecuteWorkflowQueryForProcessParams();
                parameters.ProcessNo = 1;
                parameters.WorkflowFlags = Therefore.WebAPI.Service.Contract.v0001.Enums.WSWorkflowFlags.AllInstances;

                // 3. Execute the query on the server
                ExecuteWorkflowQueryForProcessResponse response = service.ExecuteWorkflowQueryForProcess(parameters);

                // Optional 4. Display the results in a messageBox
                MessageBox.Show("Number of rows returned: " + response.WorkflowQueryResult.ResultRows.Count);
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
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                ExecuteWorkflowQueryForAllParams parameters = new ExecuteWorkflowQueryForAllParams();
                parameters.WorkflowFlags = Therefore.WebAPI.Service.Contract.v0001.Enums.WSWorkflowFlags.AllInstances;

                // 3. Execute the query on the server
                ExecuteWorkflowQueryForAllResponse response = service.ExecuteWorkflowQueryForAll(parameters);

                // Optional 4. Display the results in a messageBox
                MessageBox.Show("Number of rows returned: " + response.WorkflowQueryResultList.Count);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WorkflowQueryForm_Load(object sender, EventArgs e)
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

        private void WorkflowQueryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thereforeService != null)
                thereforeService.Close();
        }

        private void btnStartWF_Click(object sender, EventArgs e)
        {
            try
            {
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                StartWorkflowInstanceParams parameters = new StartWorkflowInstanceParams();
                parameters.DocNo = Int32.Parse(tbDocNo.Text);
                parameters.ProcessNo = Int32.Parse(tbProcsNo.Text);

                // 3. Execute the query on the server
                StartWorkflowInstanceResponse response = service.StartWorkflowInstance(parameters);

                // Optional 4. Display the results in a messageBox
                MessageBox.Show("Process started. Workflow Instance No: " + response.WorkflowInstanceNo);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
