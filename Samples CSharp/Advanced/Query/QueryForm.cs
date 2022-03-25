using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace Query
{
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                TheServer server = new TheServer();
                server.Connect(TheClientType.CustomApplication);
                //create a query object
                TheQuery q = new TheQuery();
                //load the category you want to search
                q.Category.Load("Files", server);
                //in this sample we want to be able to get all fields
                q.SelectFields.AddAll();

                //add the query strings entered by the user to the conditions
                //do not add an empty value to the conditions. it will the result 
                if (txtExtension.Text != "")
                    q.Conditions.Add("Extension", txtExtension.Text);
                if (txtFileName.Text != "")
                    q.Conditions.Add("Filename", txtFileName.Text);
                if (txtFolder.Text != "")
                    q.Conditions.Add("From_Folder", txtFolder.Text);
                if (maskedTextBoxDate.Text != "" && maskedTextBoxDate.Text.IndexOf(' ') == -1)
                    q.Conditions.Add("Creation_Date",maskedTextBoxDate.Text);

                //execute the query and get result
                TheQueryResult qRes = q.Execute(server);
                MessageBox.Show(qRes.ToString(), "Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}