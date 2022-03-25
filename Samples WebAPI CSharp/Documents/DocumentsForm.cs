using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Therefore.WebAPI.Service.Contract.v0001.Services;
using Common;
using System.ServiceModel;
using Therefore.WebAPI.Service.Contract.v0001.Messages;
using Therefore.WebAPI.Service.Contract.v0001.Data;
using System.IO;
using Therefore.WebAPI.Service.Contract.v0001.Data.IndexData;
using Therefore.WebAPI.Service.Contract.v0001.Data.IndexData.Items;

namespace Documents
{
    public partial class DocumentsForm : Form
    {
        public DocumentsForm()
        {
            InitializeComponent();
        }

        private ChannelFactory<IThereforeService> thereforeService;

        private void btn_archive_Click(object sender, EventArgs e)
        {
            try
            {
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                CreateDocumentParams parameters = new CreateDocumentParams();

                // 3. Set Therefore™ Category by Number
                parameters.CategoryNo = CategoryIds.FilesCategory;

                // 4. Add streams
                parameters.Streams = new List<WSStreamInfoWithData>();
                string fileName1 = "..\\..\\..\\..\\Sample Documents\\HR (docx)\\Contract of Employment.docx";
                parameters.Streams.Add(new WSStreamInfoWithData(File.ReadAllBytes(fileName1), Path.GetFileName(fileName1), null));

                string fileName2 = "..\\..\\..\\..\\Sample Documents\\HR (docx)\\Company Policy.docx";
                parameters.Streams.Add(new WSStreamInfoWithData(File.ReadAllBytes(fileName2), Path.GetFileName(fileName2), null));

                // 5. Set index data
                parameters.IndexDataItems = new List<WSIndexDataItem>();
                parameters.IndexDataItems.Add(new WSIndexDataItem(new WSIndexDataString(CategoryIds.Files_Filename, "Contract of Employment.docx")));
                parameters.IndexDataItems.Add(new WSIndexDataItem(new WSIndexDataString(CategoryIds.Files_From_Folder, "Sample Documents")));
                parameters.IndexDataItems.Add(new WSIndexDataItem(new WSIndexDataString(CategoryIds.Files_Extension, "docx")));
                parameters.IndexDataItems.Add(new WSIndexDataItem(new WSIndexDataDate(CategoryIds.Files_Creation_Date, DateTime.SpecifyKind(DateTime.Today, DateTimeKind.Unspecified))));

                parameters.CheckInComments = "comment";

                // 7. Archive the document
                int nDocNo = service.CreateDocument(parameters).DocNo;
                tbDocNo.Text = nDocNo.ToString();

                // 8. Display message with a MessageBox
                MessageBox.Show("Document successfully archived as " + nDocNo.ToString() + ".");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_retrieve_Click(object sender, EventArgs e)
        {
            try
            {
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                GetDocumentParams parameters = new GetDocumentParams();
                parameters.DocNo = Int32.Parse(tbDocNo.Text);
                parameters.IsStreamsInfoNeeded = true;
                parameters.IsIndexDataValuesNeeded = true;

                // 3. Retrieve the document from the server.
                GetDocumentResponse response = service.GetDocument(parameters);

                string docInfo = String.Format("Successfully retrieved {0}Document No: {1}", Environment.NewLine, response.DocNo);

                foreach (var streamInfo in response.StreamsInfo)
                    docInfo += String.Format("{0}Stream No: {1}, File name: {2}", Environment.NewLine, streamInfo.StreamNo, streamInfo.FileName);

                foreach (var indexDataItem in response.IndexData.IndexDataItems)
                    docInfo += String.Format("{0}Index data field no: {1}, value: {2}", Environment.NewLine, indexDataItem.Value.FieldNo, indexDataItem.Value.ObjDataValue);

                // 4. Display message with a MessageBox
                MessageBox.Show(docInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_extract_Click(object sender, EventArgs e)
        {
            try
            {
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                GetDocumentParams parameters = new GetDocumentParams();
                parameters.DocNo = Int32.Parse(tbDocNo.Text);
                parameters.IsStreamsInfoAndDataNeeded = true;

                // 3. Retrieve the document from the server
                GetDocumentResponse response = service.GetDocument(parameters);

                // 4. Extract all file streams to the specified directory
                string extractDir = "C:\\temp\\";
                string output = string.Empty;
                foreach (var streamInfo in response.StreamsInfo)
                {
                    string extractFileName = Path.Combine(extractDir, streamInfo.FileName);
                    File.WriteAllBytes(extractFileName, streamInfo.StreamData);
                    output += String.Format("Document stream extracted to {0}{1}", extractFileName, Environment.NewLine);
                }

                // 5. Display message with a MessageBox
                MessageBox.Show(output);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DocumentsForm_Load(object sender, EventArgs e)
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

        private void DocumentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thereforeService != null)
                thereforeService.Close();
        }
    }
}
