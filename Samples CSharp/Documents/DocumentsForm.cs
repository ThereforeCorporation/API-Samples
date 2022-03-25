using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace Documents
{
    public partial class DocumentsForm : Form
    {
        public DocumentsForm()
        {
            InitializeComponent();
        }

        private TheServer server;

        private void btn_archive_Click(object sender, EventArgs e)
        {
            TheDocument doc = null;
            try
            {
                // 2. Create a new Therefore™ Document
                doc = new TheDocument();

                // 3. Create temporary File
                string filename = "";
                doc.Create(ref filename);

                // 4. Set Therefore™ Category by Name
                doc.IndexData.SetCategory("Files", server);

                // 5. Add streams
                doc.AddStream("..\\..\\..\\..\\Sample Documents\\HR (docx)\\Contract of Employment.docx", "", 0);
                doc.AddStream("..\\..\\..\\..\\Sample Documents\\HR (docx)\\Company Policy.docx", "", 0);

                // 6. Set index data
                TheIndexData indexData = doc.IndexData;
                indexData["Filename"] = "Contract of Employment.docx";
                indexData["From_Folder"] = "Sample Documents";
                indexData["Extension"] = "docx";
                indexData["Creation_Date"] = DateTime.Now;

                // 7. Archive the document
                int nDocNo = doc.Archive(server, 0);
                
                // 8A. Print a success message on the console
                //Console.WriteLine("Document successfully archived as " + nDocNo.ToString() + ".");
                // 8B. Or display message with a MessageBox
                MessageBox.Show("Document successfully archived as " + nDocNo.ToString() + ".");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (doc != null)
                    doc.Dispose();//cleanup document. Dispose will delete internal temporary files.
            }
        }

        private void btn_retrieve_Click(object sender, EventArgs e)
        {
            TheDocument doc = null;
            try
            {
                // 2. Declare and initialize a new TheDocument instance.
                doc = new TheDocument();

                // 3. Retrieve the document from the server.
                int docNo = 1;
                string filename = doc.Retrieve(docNo, "", server);

                // 4A. Print a success message on the console.
                //Console.WriteLine("Successfully retrieved " + filename + ".");
                // 4B. Or display message with a MessageBox
                MessageBox.Show("Successfully retrieved " + filename + ".");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (doc != null)
                    doc.Dispose();//cleanup document. Dispose will delete internal temporary files.
            }
        }

        private void btn_extract_Click(object sender, EventArgs e)
        {
            TheDocument doc = null;
            try
            {
                // 2. Declare and initialize a new Therefore™ document
                doc = new TheDocument();

                // 3. Retrieve the document from the server to the inbox
                string inbox = "C:\\temp\\";
                int docNo = 1;
                string filename = doc.Retrieve(docNo, inbox, server);

                // 4. Extract all file streams to the specified directory
                string extractDir = "C:\\temp\\";
                string output = string.Empty;
                for (int i = 0; i < doc.StreamCount; i++)
                {
                    string extractFile = doc.ExtractStream(i, extractDir);
                    output += "File stream extracted to " + extractFile + "\r\n";
                }

                // 5A. Print a success message on the console.
                //Console.WriteLine(output);
                // 5B. Or display message with a MessageBox
                MessageBox.Show(output);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (doc != null)
                    doc.Dispose();//cleanup document. Dispose will delete internal temporary files.
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                // 2. Declare and initialize a new Therefore document
                TheDocument doc = new TheDocument();
	
                // 3. Retrieve the document from the server to the inbox
                int docNo = 1;
                string filename = doc.Retrieve(docNo, "", server);
	
                // 4. Open the document in the Therefore Viewer.
                doc.View();
                //don't delete the document from disk here, the Viewer will do that if no target folder has been specified in doc.Retrieve
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DocumentsForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Connect to the Therefore™ Server
                server = new TheServer();
                server.Connect(TheClientType.CustomApplication);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DocumentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Disconnect();
        }
    }
}
