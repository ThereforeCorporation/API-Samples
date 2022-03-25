using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace FullTextQuery
{
    public partial class FullTextQueryForm : Form
    {
        public FullTextQueryForm()
        {
            InitializeComponent();
        }

        private void FullTextQueryForm_Load(object sender, EventArgs e)
        {
            try
            {
                String[] types = Enum.GetNames(typeof(TheFullTextSortOrder));
                cmb_sortorder.Items.AddRange(types);
                cmb_sortorder.SelectedValue = Enum.GetName(typeof(TheFullTextSortOrder), TheFullTextSortOrder.ByRelevance);//by relevance is default
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

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
                    TheFullTextSortOrder sortorder = (TheFullTextSortOrder)Enum.Parse(typeof(TheFullTextSortOrder), (String)cmb_sortorder.SelectedValue);

                    TheServer server = new TheServer();
                    server.Connect(TheClientType.CustomApplication);
                    //create a TheFullTextQuery object
                    TheFullTextQuery q = new TheFullTextQuery();
                    //add all categories you want to search
                    q.Categories.Add(getCtgryNoFromName("Files",server));
                    q.SetSearchScope(false, true);//search file content only but not in index data
                    q.ContextMode = TheFullTextContext.FTContextOff;//the context is the snippet of text displayed in the full-text result list in Navigator                     
                    q.Search = txtQuery.Text;
                    q.SortOrder = sortorder;
                    q.UseThesaurus = chk_thesaurus.Checked;
                    q.FuzzySearchLevel = Convert.ToInt32(txt_fuzzysearch.Text);
                    //execute the query
                    TheFullTextQueryResult qRes = q.Execute(server);
                    MessageBox.Show(qRes.ToString(), "Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int getCtgryNoFromName(string strCtgryNo, TheServer server)
        {
            TheCategoryClass cat = new TheCategoryClass();
            cat.Load(strCtgryNo, server);
            return cat.CtgryNo;
        }
    }
}