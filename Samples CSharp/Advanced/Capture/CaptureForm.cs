using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace Capture
{
    public partial class CaptureForm : Form
    {
        public CaptureForm()
        {
            InitializeComponent();
        }

        private uint nDocCounter;
        
        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                //first establish server connection
                TheServer server = new TheServer();
                server.Connect(TheClientType.CaptureClient);
                
                //and load the category
                TheIndexData ixData = new TheIndexData();
                ixData.SetCategory("Files", server);
                //fill the category fields with values
                //these values will be transported to the capture client
                if (this.txtFilename.Text == "")
                    ixData["Filename"] = "Scanned File No. " + this.nDocCounter.ToString();
                else
                    ixData["Filename"] = this.txtFilename.Text;

                if (this.txtFilename.Text == "")
                    ixData["From_Folder"] = "Scanner";
                else
                    ixData["From_Folder"] = this.txtFolder.Text;

                ixData["Creation_Date"] = DateTime.Today;
                ixData["Extension"] = "tiff";

                //create a new TheApplication instance
                TheApplication app = new TheApplication();
                //and call it with the wanted options
                //if you want to change the capture profile go to TheDesigner and look up the profile number
                if (this.ckbInstantArchive.Checked)
                    app.CaptureScan(ixData, 0, TheCaptureScanFlags.CaptureArchive, (int)this.Handle);
                else
                    app.CaptureScan(ixData, 0, TheCaptureScanFlags.CaptureSinglePage, (int)this.Handle);

                //don't forget to disconnect
                server.Disconnect();
                this.nDocCounter++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            try
            {
                //first establish server connection
                TheServer server = new TheServer();
                server.Connect(TheClientType.CaptureClient);

                //the category must be loaded for archiving
                TheIndexData ixData = new TheIndexData();
                ixData.SetCategory("Files", server);
                
                //create a TheApplication instance
                TheApplication app = new TheApplication();
                //and archive the document
                app.CaptureArchive(ixData, TheCaptureArchiveFlags.ArchiveSingleDoc, (int)this.Handle);

                //don't forget to disconnect
                server.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //ERROR HANDLING

        // taken
        const int WM_USER = 0x400;
        const int PM_REMOTE_NOTIFY = WM_USER + 22;
        const uint TWNOTIFY_COMPLETED = 0x80000000;
        const uint TWNOTIFY_DOCARCHIVE = 0x10000000;
        const uint TWERR_NOITEMSEL = 0x3E90001;
        const uint TWERR_NOTONEDOC = 0x3EA0001;
        const uint TWERR_NOTREADYARCH = 0x3EB0001;
        const uint TWERR_ALREADYARC = 0x3EC0001;
        const uint TWERR_ABORT = 0x3ED0001;
        // own
        const uint TW_SCAN_STARTED = 0x20000000;
        const uint TW_SCAN_ABORTED = 0x40000000;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case PM_REMOTE_NOTIFY:	//Therefore Capture Client Notification
                    uint wParam = (uint)m.WParam;
                    uint lParam = (uint)m.LParam;
                    //was archived

                    if (wParam == TW_SCAN_STARTED)
                    {}

                    if (wParam == TWNOTIFY_COMPLETED)
                    {
                        if (lParam == TWERR_NOTONEDOC)
                        {}
                        else if (lParam == TWERR_ALREADYARC)
                        {}
                        else if (lParam == TWERR_NOITEMSEL)
                        {}
                        else if (lParam == TWERR_ABORT)
                        {}
                        else if (lParam == TWERR_NOTREADYARCH)
                        {}
                    }

                    if (wParam == TW_SCAN_ABORTED)
                    {
                        MessageBox.Show("An error occurred during the scanning process.");
                    }

                    if (wParam == TWNOTIFY_DOCARCHIVE)
                    {
                        MessageBox.Show("Document archived.");
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}
