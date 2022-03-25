using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.ServiceModel;
using Common;
using SharedServiceReference.ServiceRef_Update_it;
using SharedServiceReference;

namespace DocumentOperations
{
    public partial class DocumentOperationsForm : Form
    {
        public DocumentOperationsForm()
        {
            InitializeComponent();
        }

        private ThereforeServiceClient thereforeClient;

        private void btnExtractBrowse_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialog1.ShowDialog(this))
            {
                txtExtractPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            if (mtbDocNo.Text == "")
                MessageBox.Show("Please enter a DocNo to retrieve.", "DocNo missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtExtractPath.Text == "")
                MessageBox.Show("Please enter a Folder to extract file to.", "Folder missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    // 2. Create request parameters
                    GetDocumentParams parameters = new GetDocumentParams();
                    parameters.DocNo = Int32.Parse(mtbDocNo.Text);
                    parameters.IsStreamsInfoAndDataNeeded = true;
                    
                    // 3. Retrieve the document with all the streams
                    GetDocumentResponse response = thereforeClient.GetDocument(new GetDocumentRequest { parameters = parameters }).GetDocumentResult;

                    // 4. Save all streams from the response to the desired path
                    for (int i = 0; i < response.StreamsInfo.Count; i++)
                        File.WriteAllBytes(Path.Combine(txtExtractPath.Text, response.StreamsInfo[i].FileName), response.StreamsInfo[i].StreamData);

                    MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdateBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowReadOnly = true;
            openFileDialog1.Multiselect = false;

            if (DialogResult.OK == openFileDialog1.ShowDialog(this))
            {
                txtUpdatePath.Text = openFileDialog1.FileName;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (mtbDocNo.Text == "")
                MessageBox.Show("Please enter a DocNo to retrieve.", "DocNo missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtUpdatePath.Text == "")
                MessageBox.Show("Please enter a File to add to existing The Document.", "Folder missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    int docNo = Int32.Parse(mtbDocNo.Text);

                    // 2. Retrieve document before update
                    GetDocumentIndexDataResponse docResponse = thereforeClient.GetDocumentIndexData(new GetDocumentIndexDataRequest { parameters = new GetDocumentIndexDataParams { DocNo = docNo } }).GetDocumentIndexDataResult;
                    DateTime lastChangetime = docResponse.IndexData.LastChangeTime;

                    // 3. Create request parameters
                    UpdateDocumentParams parameters = new UpdateDocumentParams();
                    parameters.DocNo = docNo;

                    // 4. Change IndexData
                    parameters.IndexData = new WSIndexDataToPut { IndexDataItems = new List<WSIndexDataItem>() };
                    parameters.IndexData.LastChangeTime = lastChangetime;
                    parameters.IndexData.IndexDataItems.Add(new WSIndexDataItem { StringIndexData = new WSIndexDataString { FieldNo = CategoryIds.Files_Filename, DataValue = Path.GetFileName(txtUpdatePath.Text) } });
                    // 5. Add a file to the document
                    parameters.StreamsToUpdate = new List<WSStreamInfoWithData>();
                    parameters.StreamsToUpdate.Add(new WSStreamInfoWithData { FileData = File.ReadAllBytes(txtUpdatePath.Text), FileName = Path.GetFileName(txtUpdatePath.Text), StreamNo = null/*null stream number means - new stream to add*/});
                    
                    // 6. When the parameters are complete update the document in the system
                    thereforeClient.UpdateDocument(new UpdateDocumentRequest { parameters = parameters });

                    MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void DocumentOperationsForm_Load(object sender, EventArgs e)
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

        private void DocumentOperationsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thereforeClient != null)
                thereforeClient.Close();
        }
    }
}