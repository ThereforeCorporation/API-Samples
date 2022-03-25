using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Therefore.API;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace WFExtractFiles
{
    [Guid("E9D3A6F3-2FF0-4357-B7CD-78A1FA99207B"), ComVisible(true)]
    public class WFExtractFiles :  Therefore.AddIn.ITheWorkflowAutomaticTask
    {
        #region ITheWorkflowAutomaticTask Members

        protected EventLog objLog = null;


        public WFExtractFiles()
        {
            objLog = new EventLog("Application", ".", "Therefore-WF");
        }

        public string ShowSettingsDlg(int nObjectID, int nObjectType, string bstrTenant, string strParams)
        {
            //look into the API manual for TheObjectType enumeration for further reference to nObjectType
            ParamDialog paramDialog = new ParamDialog();
            paramDialog.Path = strParams;
            paramDialog.ShowDialog();
            if (paramDialog.DialogResult == DialogResult.OK)
            {
                return paramDialog.Path;
            }
            return strParams;
        }

        public void ProcAutomaticInst(int nInstanceNo, int nTokenNo, string bstrTenant, string strParams)
        {
            TheDocument theDoc = null;
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            try
            {
                TheServer server = new TheServer();
                server.Connect(TheClientType.CustomApplication);

                //create a TheWFInstance object and load the workflow item by using the instance number
                TheWFInstance wfInstance = new TheWFInstance();
                wfInstance.Load(server, nInstanceNo);

                //the GetLinkedDocAt method gives back the document number 
                //of the document this workflow item belongs to
                TheWFDocument wfDoc = wfInstance.GetLinkedDocAt(0);

                //with the document number you can retrieve the document
                theDoc = new TheDocument();
                string strTheDoc = theDoc.Retrieve(wfDoc.DocNo, "", server);

                //extract the files to the configured path
                string extractPath = strParams;
                for (int i = 0; i < theDoc.StreamCount; i++)
                    theDoc.ExtractStream(i, extractPath);

                //write Index Data to textfile
                fileStream = new FileStream(extractPath + theDoc.IndexData.CtgryName
                    +theDoc.IndexData.DocNo+".txt",FileMode.Create);
                streamWriter = new StreamWriter(fileStream);

                List<String> names = new List<String>();
                List<String> values = new List<String>();

                foreach (string name in theDoc.IndexData.FieldNames)
                    names.Add(name);

                foreach (object value in theDoc.IndexData.Values)
                    values.Add(Convert.ToString(value));

                for (int i = 0; i < names.Count; i++ )
                {
                    streamWriter.WriteLine(names[i] + ": " + values[i]);
                }
                streamWriter.Flush();
                //get the next task in the workflow and finish the current task
                TheWFTask wfTask = wfInstance.GetNextTaskAt(0);
                wfInstance.ClaimInstance(server);
                wfInstance.FinishCurrentTask(server, wfTask.TaskNo, "");
            }
            catch (System.Exception ex)
            {
                HandleError(ex, "");
                throw ex; //throwing an unhandled exception here will result in the error being listed in the Navigator
                //if everything is handled here, the error will not be listed as error in the Navigator
            }       
            finally
            {
                if(theDoc != null)
                    theDoc.Dispose();// Dispose will delete internal temporary files.
                if(streamWriter != null)
                    streamWriter.Close();
                if(fileStream != null)
                    fileStream.Close();
            }
        }

        protected void HandleError(Exception e, string strMessage)
        {
            string strTempMessage = FormatMessage(e, strMessage);
            try
            {
                objLog.WriteEntry(strTempMessage, EventLogEntryType.Error);
            }
            catch (Exception) {/*ignore*/}
        }

        private string FormatMessage(Exception ex, string strInsertText)
        {
            StringBuilder sNewMessage = new StringBuilder();
            string sErrorStack = null;

            // get the error stack, if InnerException is null,
            // sErrorStack will be "exception was not chained" and
            // should never be null
            sErrorStack = BuildErrorStack(ex.InnerException);

            sNewMessage.AppendLine(ex.Message);
            sNewMessage.AppendLine("Exception: " + ex.GetType().ToString());
            sNewMessage.AppendLine("Application: " + Process.GetCurrentProcess().ProcessName.Replace(".vshost", ""));
            sNewMessage.AppendLine("Source: " + ex.Source);
            sNewMessage.AppendLine("User name: " + System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            if (strInsertText != null && strInsertText != "")
            {
                sNewMessage.AppendLine();
                sNewMessage.AppendLine("Additional Information: ");
                sNewMessage.AppendLine("   " + strInsertText);
            }
            sNewMessage.AppendLine();
            sNewMessage.AppendLine("Stack Trace:");
            sNewMessage.AppendLine(ex.StackTrace);

            if (sErrorStack != "")
                sNewMessage.AppendLine(sErrorStack);

            return sNewMessage.ToString().Trim();
        }

        private string BuildErrorStack(Exception oChainedException)
        {
            string sErrorStack = null;
            StringBuilder sbErrorStack = new StringBuilder();
            int nErrStackNum = 1;
            System.Exception oInnerException = null;

            if (oChainedException != null)
            {
                sbErrorStack.Append("\nAdditional Error Information:\n\nError Stack: \n");

                oInnerException = oChainedException;
                while (oInnerException != null)
                {
                    sbErrorStack.Append(nErrStackNum)
                                .Append(") ")
                     .Append(oInnerException.Message)
                                .Append("\n");

                    oInnerException =
                          oInnerException.InnerException;

                    nErrStackNum++;
                }
                sbErrorStack.Append("\nStack Trace:\n")
                  .Append(oChainedException.StackTrace);

                sErrorStack = sbErrorStack.ToString();
            }
            else
            {
                sErrorStack = "";
            }
            return sErrorStack;
        }
        #endregion
    }
}
