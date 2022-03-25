using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Therefore.API;
using System.IO;

namespace DocumentOperations
{
    public partial class DocumentOperationsForm : Form
    {
        public DocumentOperationsForm()
        {
            InitializeComponent();
        }

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
                MessageBox.Show("Please enter a DocNo to retrive.", "DocNo missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtExtractPath.Text == "")
                MessageBox.Show("Please enter a Folder to extract file to.", "Folder missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                TheDocument doc = null;
                try
                {
                    TheServer server = new TheServer();
                    server.Connect(TheClientType.CustomApplication);
                    doc = new TheDocument();
                    //first retrieve the document. 
                    //the document will be saved into a temporary file on the hard drive
                    //the full path to the temporary file will be memorized in strTheDoc
                    string strTheDoc = doc.Retrieve(Int32.Parse(mtbDocNo.Text), "", server);
                    //and then extract all files from the document to the desired path
                    for (int i = 0; i < doc.StreamCount; i++)
                        doc.ExtractStream(i, txtExtractPath.Text);

                    //do also not forget to delete the temporary document file on the hard drive
                    File.Delete(strTheDoc);
                    MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (doc != null)
                        doc.Dispose();//cleanup document. Dispose will delete internal temporary files.
                }
            }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (mtbDocNo.Text == "")
                MessageBox.Show("Please enter a DocNo to retrive.", "DocNo missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    TheServer server = new TheServer();
                    server.Connect(TheClientType.CustomApplication);
                    TheDocument doc = new TheDocument();
                    //first retrieve the document. 
                    doc.Retrieve(Int32.Parse(mtbDocNo.Text), "", server);
                    //to open a document in the Viewer just call the View() method after retrieving the document
                    doc.View();// the Viewer will delete the document
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
                TheDocument doc = null;
                try
                {
                    string strUser = "";
                    int nVersionNo = 0;

                    TheServer server = new TheServer();
                    server.Connect(TheClientType.CustomApplication);
                    doc = new TheDocument();
                    //first retrieve the document. 
                    //the document will be saved into a temporary file on the hard drive
                    //the full path to the temporary file will be memorized in strTheDoc
                    string strTheDoc = doc.Retrieve(Int32.Parse(mtbDocNo.Text), "", server);
                    //open the document and do a checkout
                    //you need to do a checkout to update a document
                    doc.Open(strTheDoc, 0);
                    doc.CheckOut(server, 0, out strUser, out nVersionNo);
                    if (strUser != "")
                    {
                        MessageBox.Show("Document is checked out by: " + strUser, "Checked Out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (nVersionNo != 0)
                    {
                        MessageBox.Show("A newer version exists with DocNo = " + nVersionNo.ToString(), "Newer Version", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //you have to set the category so you can use the IndexData properly
                        doc.IndexData.SetCategory("Files", server);
                        //now you can change IndexData...
                        doc.IndexData["Filename"] = doc.IndexData["Filename"].ToString() + " - updated";
                        //... and add a file to the document
                        doc.AddStream(txtUpdatePath.Text, Path.GetFileName(txtUpdatePath.Text), 0);
                        //when the changes are complete, save the document to the system
                        doc.CheckIn(server, "Modified by SDK sample");
                        MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (doc != null)
                        doc.Dispose();//cleanup document. Dispose will delete internal temporary files.
                }
            }
        }
    }
}