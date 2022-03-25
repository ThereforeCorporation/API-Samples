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
using Therefore.WebAPI.Service.Contract.v0001.Data.IndexData;
using Therefore.WebAPI.Service.Contract.v0001.Data.IndexData.Items;
using Common;

namespace IndexData
{
    public partial class IndexDataForm : Form
    {
        private DateTime? lastChangeTime = null;
        public IndexDataForm()
        {
            InitializeComponent();
        }

        private ChannelFactory<IThereforeService> thereforeService;

        private void btn_read_Click(object sender, EventArgs e)
        {
            try
            {
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                GetDocumentIndexDataParams parameters = new GetDocumentIndexDataParams();
                parameters.DocNo = Int32.Parse(tbDocNo.Text);

                // 3. Retrieve the document from the server.
                GetDocumentIndexDataResponse response = service.GetDocumentIndexData(parameters);
                lastChangeTime = response.IndexData.LastChangeTime;

                string docInfo = String.Format("Successfully retrieved index data{0}Document No: {1}", Environment.NewLine, response.DocNo);

                foreach (var indexDataItem in response.IndexData.IndexDataItems)
                    docInfo += String.Format("{0}Index data field no: {1}, value: {2}", Environment.NewLine, indexDataItem.Value.FieldNo, indexDataItem.Value.ObjDataValue);

                // 4. Display information
                this.txt_output.Text += docInfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (lastChangeTime.HasValue)
                {
                    // 1B. Create a channel to the web service endpoint
                    IThereforeService service = thereforeService.CreateChannel();

                    // 2. Create request to modify index data values
                    SaveDocumentIndexDataParams parameters = new SaveDocumentIndexDataParams();
                    parameters.DocNo = Int32.Parse(tbDocNo.Text);
                    parameters.IndexData = new WSIndexDataToPut();
                    parameters.IndexData.LastChangeTime = lastChangeTime.Value;

                    parameters.IndexData.IndexDataItems = new List<WSIndexDataItem>();
                    parameters.IndexData.IndexDataItems.Add(new WSIndexDataItem { Value = new WSIndexDataString(CategoryIds.Files_Extension, "JPG") });
                    parameters.IndexData.IndexDataItems.Add(new WSIndexDataItem { Value = new WSIndexDataString(CategoryIds.Files_From_Folder, ".\\") });
                    parameters.IndexData.IndexDataItems.Add(new WSIndexDataItem { Value = new WSIndexDataDate(CategoryIds.Files_Creation_Date, DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified)) });
                    // use line below to set the field value to null
                    //parameters.IndexDataItemsToSave.Add(new WSIndexDataItem { Value = new WSIndexDataDate(CategoryIds.Files_Creation_Date, null) });

                    // 6. Save the changes to the server
                    SaveDocumentIndexDataResponse response = service.SaveDocumentIndexData(parameters);

                    // 7. Display confirmation
                    lastChangeTime = response.LastChangeTime;
                    this.txt_output.Text += String.Format("{1}Index Data changed. New LastChangeTime='{0}'", response.LastChangeTime, Environment.NewLine);
                    
                }
                else
                    MessageBox.Show("Read document before to get LastChangeTime value. It's needed to update the document. See documentation for more details");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IndexDataForm_Load(object sender, EventArgs e)
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

        private void IndexDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thereforeService != null)
                thereforeService.Close();
        }
    }
}
