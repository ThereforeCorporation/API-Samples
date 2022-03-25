using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace IndexData
{
    public partial class IndexDataForm : Form
    {
        public IndexDataForm()
        {
            InitializeComponent();
        }

        private TheServer server;

        private void IndexDataForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Connect to the Therefore™ server            
                server = new TheServer();
                server.Connect(TheClientType.CustomApplication);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            try
            {
                // 2. Declare and initialize a new index data object
                TheIndexData indexData = new TheIndexData();

                // 3. load index data from the server
                int docNo = 1;
                indexData.Load(docNo, 0, server); //categoryNo parameter is obsolete and can always be set to 0

                this.txt_output.Text = "";
                // 4A. Iterate index data pairs in a for-each loop
                foreach (ThePair pair in indexData)
                    this.txt_output.Text += pair.ToString() + "\r\n";
	
	            // 4B. Iterate index data field names only
	            // foreach (string fieldName in indexData.FieldNames)
                //     this.txt_output.Text += pair.ToString() + "\r\n";
	
	            // 4C. Iterate index data field names only
	            // foreach (object value in indexData.Values)
                //     this.txt_output.Text += pair.ToString() + "\r\n";
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
                // 2. Declare and initialize a new index data object
                TheIndexData indexData = new TheIndexData();

                // 3. load index data from the server
                int docNo = 1;
                indexData.Load(docNo, 0, server); //categoryNo parameter is obsolete and can always be set to 0

                // 4. Modify index data values
                indexData["Extension"] = "JPG";
                indexData["From_Folder"] = ".\\";
	
                // 5. Save the changes to the server
                indexData.SaveChanges(server);

                // 6. Display confirmation
                this.txt_output.Text = "Index Data changed.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IndexDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Disconnect();
        }
    }
}
