using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using SharedServiceReference.ServiceRef_Update_it;
using Common;
using SharedServiceReference;

namespace ArchiveDocuments
{
    public partial class ArchiveDocuments : Form
    {
        public ArchiveDocuments()
        {
            InitializeComponent();
        }

        private ThereforeServiceClient thereforeClient;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dialog.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtPath.Text == "")
                MessageBox.Show("Please select a root directory.", "Root not selected.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    // 1B. Create a channel to the web service endpoint
                    //ServiceRef_Update_it_.ThereforeServiceClient client = new ServiceRef_Update_it_.ThereforeServiceClient("");
                    ArchiveAll(txtPath.Text, thereforeClient);

                    MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ArchiveAll(string strDir, ThereforeServiceClient service)
        {
            //we do not only want to save all files in a directory
            //but in the subdirectories as well
            foreach (string strSubDir in Directory.GetDirectories(strDir))
            {
                ArchiveAllFiles(strSubDir, service);
            }
            ArchiveAllFiles(strDir, service);
        }

        private void ArchiveAllFiles(string strSubDir, ThereforeServiceClient service)
        {
            foreach (string strFile in Directory.GetFiles(strSubDir))
            {
                // 2. Create request parameters
                CreateDocumentParams parameters = new CreateDocumentParams();

                string strFileName = Path.GetFileName(strFile);
                string strExt = Path.GetExtension(strFile).Remove(0, 1);//remove dot
                string strFromFolder = Path.GetDirectoryName(strFile);
               
                //add a file to the document
                parameters.Streams = new List<WSStreamInfoWithData>();
                parameters.Streams.Add(new WSStreamInfoWithData { FileData = File.ReadAllBytes(strFile), FileName = strFileName, StreamNo = null });
                //set the category you want to add the document to
                parameters.CategoryNo = CategoryIds.FilesCategory;

                //add the index data to the document
                parameters.IndexDataItems = new List<WSIndexDataItem>();
                parameters.IndexDataItems.Add(new WSIndexDataItem { StringIndexData = new WSIndexDataString { FieldNo = CategoryIds.Files_Filename, DataValue = null } });
                parameters.IndexDataItems.Add(new WSIndexDataItem { StringIndexData = new WSIndexDataString { FieldNo = CategoryIds.Files_From_Folder, DataValue = strFromFolder } });
                parameters.IndexDataItems.Add(new WSIndexDataItem { StringIndexData = new WSIndexDataString { FieldNo = CategoryIds.Files_Extension, DataValue = strExt } });
                parameters.IndexDataItems.Add(new WSIndexDataItem { DateIndexData = new WSIndexDataDate { FieldNo = CategoryIds.Files_Creation_Date, DataValue = DateTime.SpecifyKind(File.GetCreationTime(strFile), DateTimeKind.Unspecified/*to avoid timezone conversion problem*/) } });
                
                //the CreateDocument command sends the document the Therefore server and archives it
                CreateDocumentResponse response = service.CreateDocument(new CreateDocumentRequest { parameters = parameters }).CreateDocumentResult;

                txt_result.Text += "Created document. No: " + response.DocNo + ". File added: " + strFileName + Environment.NewLine;
                txt_result.Update();
            }
        }

        private void btn_StartMulti_Click(object sender, EventArgs e)
        {
            try
            {
                string strDir = txtPath.Text;
                Guid batchId;

                // 2. Start document update batch
                StartCreateDocumentBatchResponse startResponse = thereforeClient.StartCreateDocumentBatch(new StartCreateDocumentBatchRequest { parameters = new StartCreateDocumentBatchParams() }).StartCreateDocumentBatchResult;
                
                // 2.1 Store batch id
                batchId = startResponse.BatchId;

                //we only want to save all files in a directory
                foreach (string strFile in Directory.GetFiles(strDir))
                {
                    // 3. Upload each document to batch separately
                    UploadDocStreamToBatchParams uploadParams = new UploadDocStreamToBatchParams();
                    uploadParams.BatchId = batchId;
                    uploadParams.StreamInfoWithData = new WSStreamInfoWithData { FileData = File.ReadAllBytes(strFile), FileName = Path.GetFileName(strFile), StreamNo = null };
                    thereforeClient.UploadDocStreamToBatch(new UploadDocStreamToBatchRequest { parameters = uploadParams });

                }

                // 4. Submit document update batch
                //    and add the index data to the document
                SubmitCreateDocumentBatchParams submitParameters = new SubmitCreateDocumentBatchParams();
                submitParameters.BatchId = batchId;
                submitParameters.CategoryNo = CategoryIds.FilesCategory;
                submitParameters.IndexDataItems = new List<WSIndexDataItem>();
                submitParameters.IndexDataItems.Add(new WSIndexDataItem { StringIndexData = new WSIndexDataString { FieldNo = CategoryIds.Files_From_Folder, DataValue = strDir } });
                SubmitCreateDocumentBatchResponse response = thereforeClient.SubmitCreateDocumentBatch(new SubmitCreateDocumentBatchRequest { parameters = submitParameters }).SubmitCreateDocumentBatchResult;

                MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txt_result.Text += "New document number " + response.DocNo + Environment.NewLine;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ArchiveDocuments_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Create a client of the web service endpoint.
                if (thereforeClient == null)
                    if (null == (thereforeClient = ClientConnection.CreateClient()))
                        this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ArchiveDocuments_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thereforeClient != null)
                thereforeClient.Close();
        }
    }
}