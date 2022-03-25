using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using Therefore.API;
using System.IO;
using System.Timers;

namespace ServiceSample
{
    public partial class ServiceSample : ServiceBase
    {
        Timer timer = new Timer();

        public ServiceSample()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ProcessHotFolder();
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Interval = 6000;
            timer.Enabled = true;
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ProcessHotFolder();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }

        private void ProcessHotFolder()
        {
            string strDir = "d:\\HotFolder";
            try
            {
                //create a log entry for information purpose
                EventLog.WriteEntry(ServiceName, "ProcessHotFolder called.", EventLogEntryType.Information);
                ArchiveAll(strDir);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ServiceName, ex.ToString(), EventLogEntryType.Error);
            }
        }

        private void ArchiveAll(string strDir)
        {
            TheServer server = new TheServer();
            server.Connect(TheClientType.CustomApplication, "Administrator", "The");
            
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
            TheDocument doc = null;
            try
            {
                foreach (string strFile in Directory.GetFiles(strSubDir))
                {
                    string strFileName = Path.GetFileName(strFile);
                    string strExt = Path.GetExtension(strFile);
                    string strFromFolder = Path.GetDirectoryName(strFile);
                    string strTheFile = "";
                    //in this file the Therefore document data will be stored temporarily

                    doc = new TheDocument();
                    //create the temporary Therefore file
                    doc.Create(ref strTheFile);
                    //add a file to the document
                    doc.AddStream(strFile, strFileName, 0);
                    doc.IndexData.SetCategory("Files", server);

                    //set the category you want to add the document to
                    doc.IndexData.SetCategory("Files", server);

                    //add the index data to the document
                    doc.IndexData["Filename"] = strFileName;
                    doc.IndexData["From_Folder"] = strFromFolder;
                    doc.IndexData["Extension"] = strExt;
                    doc.IndexData["Creation_Date"] = File.GetCreationTime(strFile);
                    //the archive command sends the document the Therefore server and archives it
                    //doesn't allow to display a dialog if necessary (will result in exception instead)
                    //doesn't reload the document. By default Archive reloads the document but deleting it right afterwards from disk makes this unnecessary
                    doc.Archive(server, 0, "", false, false);
                    doc.Dispose(); //deletes the internal temporary files
                    doc = null;//set to null. otherwise Dispose will be called in the finally block again causing an error
                    File.Delete(strFile);
                }
            }
            catch(Exception ex)
            {
                // add some exception handling code like logging to event log
            }
            finally
            {
                if(doc != null)
                    doc.Dispose();
            }
        }
    }
}
