using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Therefore.API;
using System.IO;

namespace ArchiveDocuments
{
    public partial class ArchiveDocuments : Form
    {
        public ArchiveDocuments()
        {
            InitializeComponent();
        }

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
                    ArchiveAll(txtPath.Text);
                    MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ArchiveAll(string strDir)
        {
            TheServer server = new TheServer();
            server.Connect(TheClientType.CustomApplication);

            //we do not only want to save all files in a directory
            //but in the subdirectories as well
            foreach (string strSubDir in Directory.GetDirectories(strDir))
            {
                ArchiveAllFiles(strSubDir, server);
            }
            ArchiveAllFiles(strDir, server);
            server.Disconnect(true);
        }

        private void ArchiveAllFiles(string strSubDir, TheServer server)
        {
            foreach (string strFile in Directory.GetFiles(strSubDir))
            {
                string strFileName = Path.GetFileName(strFile);
                string strExt = Path.GetExtension(strFile).Remove(0, 1);//remove dot
                string strFromFolder = Path.GetDirectoryName(strFile);
                string strThereforeFile = "";
                //in this file the Therefore document data will be stored temporarily
               
                TheDocument doc = new TheDocument();
                //create the temporary Therefore file
                doc.Create(ref strThereforeFile);
                //add a file to the document
                doc.AddStream(strFile, strFileName, 0);
                //set the category you want to add the document to
                doc.IndexData.SetCategory("Files", server);

                //add the index data to the document
                doc.IndexData["Filename"] = strFileName;
                doc.IndexData["From_Folder"] = strFromFolder;
                doc.IndexData["Extension"] = strExt;
                doc.IndexData["Creation_Date"] = File.GetCreationTime(strFile);
                //the archive command sends the document the Therefore server and archives it
                doc.Archive(server, 0);
                doc.Dispose(); // Dispose will delete internal temporary files.
            }
        }
    }
}