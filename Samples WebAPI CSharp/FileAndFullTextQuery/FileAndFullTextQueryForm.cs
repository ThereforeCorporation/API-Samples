using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using Therefore.WebAPI.Service.Contract.v0001.Services;
using Therefore.WebAPI.Service.Contract.v0001.Messages;
using Common;
using Therefore.WebAPI.Service.Contract.v0001.Data;
using Therefore.WebAPI.Service.Contract.v0001.Enums;
using Therefore.WebAPI.Service.Contract.v0001.Lists;

namespace FileAndFullTextQuery
{
    public partial class FileAndFullTextQueryForm : Form
    {
        public FileAndFullTextQueryForm()
        {
            InitializeComponent();
        }

        private ChannelFactory<IThereforeService> thereforeService;

        private void btn_full_text_Click(object sender, EventArgs e)
        {
           try
           {
               // 1B. Create a channel to the web service endpoint
               IThereforeService service = thereforeService.CreateChannel();

               // 2. Create request parameters
               ExecuteFullTextQueryParams parameters = new ExecuteFullTextQueryParams();
               
               // 3. Define a query looking for "Therefore" in categories
               parameters.FullTextQuery = new WSFullTextQuery { Categories = new CategoryList() };
               parameters.FullTextQuery.Search = "Therefore";
               parameters.FullTextQuery.Categories.Add(CategoryIds.FilesCategory);
               //query.Categories.Add(x);//add more categories here

               // 4. Execute the query
               ExecuteFullTextQueryResponse response = service.ExecuteFullTextQuery(parameters);

               // Optional 5. Navigate through the document list
               MessageBox.Show("Found documents: " + response.Results.Count);

               string info = String.Empty;
               foreach (WSFullTextQueryResultRow row in response.Results)
               {
                   info += String.Format("Ctgry: {0}, Doc: {1}, Rank: {2}, Title: {3}{4}", row.CategoryNo, row.DocNo, row.Rank, row.Title, Environment.NewLine);
               }

               txt_result.Text = info;
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }  
        }

        private void FileAndFullTextQueryForm_Load(object sender, EventArgs e)
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

        private void FileAndFullTextQueryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thereforeService != null)
                thereforeService.Close();
        }
    }
}
