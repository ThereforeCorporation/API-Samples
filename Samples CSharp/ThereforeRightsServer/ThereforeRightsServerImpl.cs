using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using Therefore.API;

namespace Therefore
{
    [ComVisible(true), Guid("0FE54A12-5FFD-4b69-A287-4F16CA3BD7C5")]
    public class ThereforeRightsServerImpl : Therefore.AddIn.ITheRightsServer
    {
        protected EventLog objLog = null;
        private static readonly string registryRootServer = @"SOFTWARE\Therefore\Server";

        private string strDBServer = "";
        private string strDBName = "";

        private static int RIGHT_GRANT = 1;
        private static int RIGHT_REVOKE = 2;
        private static int RIGHT_DEFAULT = 9;

        public ThereforeRightsServerImpl()
        {
            objLog = new EventLog("Application", ".", "TheRights");

            try
            {
                //get the therefore database name from registry
                RegistryKey regMachine = Registry.LocalMachine;
                regMachine = regMachine.OpenSubKey(registryRootServer);
                if (regMachine == null)
                    throw new Exception("Could not open Registry Key: HKEY_LOCAL_MACHINE\\" + registryRootServer);

                object objVal = ReadRegistryValue(regMachine, "DBName", true);
                string strDBPath = objVal.ToString();
                string[] arrDBVals = strDBPath.Split('/');
                if (arrDBVals.Length == 0)
                    throw new Exception("Invalid Database Configuration String: " + strDBPath);

                if (arrDBVals.Length == 1)
                {
                    //if the database server is located on the therefore server you can use this
                    strDBServer = Environment.MachineName;
                    strDBName = arrDBVals[0];
                }
                else
                {
                    //otherwise you also have to get the database server name from the registry
                    strDBServer = arrDBVals[0];
                    strDBName = arrDBVals[1];
                }
            }
            catch (Exception e)
            {
                HandleError(e, "Constructor failed.");
            }
        }

        protected int GetCtgryNoFromDoc(int nDocNo)
        {
            int nCtgryNo = 0;
            int nVersionNo = 0;
            SqlDataReader dataReader = null;
            string strSQLConnectionString = string.Empty;

            try
            {
                //create a connection string with the information gathered from the registry
                if (strSQLConnectionString == "")
                    strSQLConnectionString = "server=" + strDBServer + ";database=" + strDBName + ";Trusted_Connection=yes";

                //then open a connection
                using (SqlConnection sqlConn = new SqlConnection(strSQLConnectionString))
                {
                    sqlConn.Open();
                    //and create your SqlCommand
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConn;
                    sqlCommand.CommandType = System.Data.CommandType.Text;

                    //first we need to know which version number is the last/newest one
                    sqlCommand.CommandText = "Select VersionNo from TheDocument where DocNo = " + nDocNo.ToString() 
                                                + " ORDER BY VersionNo DESC";
                    //execute the command. if the command is not correct, an exception will be thrown
                    dataReader = sqlCommand.ExecuteReader();
                    //get the value from the result
                    if (dataReader.HasRows && dataReader.Read())
                        nVersionNo = (int)(dataReader.GetValue(0));
                    //you have to close the SqlDataReader to use it again
                    dataReader.Close();
                    //create another command. this time we will get the category number from the last version
                    //of the document
                    sqlCommand.CommandText = "Select CtgryNo from TheDocVersion where DocNo = " + nDocNo.ToString()
                                             + "AND VersionNo = " + nVersionNo.ToString();
                    dataReader = sqlCommand.ExecuteReader();
                    if (dataReader.HasRows && dataReader.Read())
                        //be careful when casting values from the SqlDataReader
                        //casting a smallint field in the database to an int will end in an exception
                        nCtgryNo = (short)(dataReader.GetValue(0));
                }
            }
            catch (Exception e)
            {
                HandleError(e, "GetCtgryNoFromDoc failed! Have you already imported the category?");
            }
            finally
            {
                //always close the SqlDataReader
                if (dataReader != null)
                    dataReader.Close();
            }
            return nCtgryNo;
        }

        protected int GetCtgryNoFromName(string strCtgryName)
        {
            int nCtgryNo = 0;
            SqlDataReader dataReader = null;
            string strSQLConnectionString = string.Empty;

            try
            {
                //create a connection string with the information gathered from the registry
                if (strSQLConnectionString == "")
                    strSQLConnectionString = "server=" + strDBServer + ";database=" + strDBName + ";Trusted_Connection=yes";

                //then open a connection
                using (SqlConnection sqlConn = new SqlConnection(strSQLConnectionString))
                {
                    sqlConn.Open();
                    //and create your SqlCommand
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConn;
                    sqlCommand.CommandType = System.Data.CommandType.Text;

                    //first we need to know which version number is the last/newest one
                    sqlCommand.CommandText = "Select CtgryNo from TheCategory where Name = '" + strCtgryName + "'";
                    //execute the command. if the command is not correct, an exception will be thrown
                    dataReader = sqlCommand.ExecuteReader();
                    //get the value from the result
                    if (dataReader.HasRows && dataReader.Read())
                        nCtgryNo = (int)(dataReader.GetValue(0));                  
                }
            }
            catch (Exception e)
            {
                HandleError(e, "GetCtgryNoFromName failed! Have you already imported the category?");
            }
            finally
            {
                //always close the SqlDataReader
                if (dataReader != null)
                    dataReader.Close();
            }
            return nCtgryNo;
        }

        protected int GetCtgryRight( int nCtgryNo, TheUserStruct sUser)
        {
            //check the category and user and return the right the user has in this category
            //and he shall only get the permission during office time (between 8:00 and 18:00)
            if (nCtgryNo == 4 && sUser.nUserNo == 9 && DateTime.Now.Hour > 7 && DateTime.Now.Hour < 18)
                return RIGHT_GRANT;
            return RIGHT_REVOKE;
        }

        /// <summary>
        /// Read a Registry Value.
        /// </summary>
        /// <param name="regKey">Open Registry Key</param>
        /// <param name="strValue">Name of the Value</param>
        /// <param name="bMandatory">If true, Exception is thrown if missing, else returns null.</param>
        /// <returns>Value of the RegKey</returns>
        protected object ReadRegistryValue(RegistryKey regKey, String strValue, bool bMandatory)
        {
            if (regKey == null)
                throw new Exception("Invalid Registry Key provided.");

            object objVal = regKey.GetValue(strValue);
            if (objVal == null && bMandatory)
                throw new Exception("Could not read Registry Value: " + regKey.ToString() + "\\" + strValue);

            return objVal;
        }
        
        /// <summary>
        /// Handle an Exception - create good Error Message
        /// </summary>
        /// <param name="e">Exception that was thrown</param>
        /// <param name="strMessage">Message to add to the output</param>
        protected void HandleError(Exception e, string strMessage)
        {
            string strTempMessage = FormatMessage(e, strMessage);
            try
            {
                objLog.WriteEntry(strTempMessage, EventLogEntryType.Error);
            }
            catch (Exception) {/*ignore*/}
        }

        /// <summary>
        /// Format the Exception for logging 
        /// </summary>
        /// <param name="ex">Exception to format</param>
        /// <param name="strInsertText">Additional Information to add to Error Message</param>
        /// <returns>Formated Output Message</returns>
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


        /// <summary>
        /// Format the chain of Inner Exceptions for display / logging
        /// </summary>
        /// <param name="oChainedException">Inner Exception to start from</param>
        /// <returns></returns>
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

        #region IThereforeRightsServer Members

        public int AllowArchive(object vUser, object vIxData, int nOldDocNo)
        {
            int nRight = RIGHT_REVOKE;
            try
            {
                //do not check for new documents
                if (nOldDocNo == 0)
                    nRight = RIGHT_GRANT;
                else
                {
                    TheUserStruct sUser = new TheUserStruct(vUser);
                    int nCtgryNo = GetCtgryNoFromDoc(nOldDocNo);
                    nRight = GetCtgryRight( nCtgryNo, sUser);
                }
            }
            catch (Exception e)
            {
                HandleError(e, "AllowArchive failed.");
            }
            return nRight;
        }

        public int AllowCheckout(object vUser, int nDocNo)
        {
            int nRight = RIGHT_REVOKE;
            try
            {
                TheUserStruct sUser = new TheUserStruct(vUser);
                int nCtgryNo = GetCtgryNoFromDoc(nDocNo);
                nRight = GetCtgryRight(nCtgryNo, sUser);
            }
            catch (Exception e)
            {
                HandleError(e, "AllowCheckout failed.");
            }
            return nRight;
        }

        public int AllowDelete(object vUser, int nDocNo)
        {
            throw new NotImplementedException();
        }

        public int AllowRetrieve(object vUser, int nDocNo, out int pnStatus)
        {
            int nRight = RIGHT_REVOKE;
            pnStatus = 0;
            try
            {
                TheUserStruct sUser = new TheUserStruct(vUser);
                int nCtgryNo = GetCtgryNoFromDoc(nDocNo);
                nRight = GetCtgryRight(nCtgryNo, sUser);
            }
            catch (Exception e)
            {
                HandleError(e, "AllowRetrieve failed.");
            }
            return nRight;
        }

        public void GetDocRights(object vUser, int nDocNo, out int pnRightsSrvMask, out int pnThereforeDBMask, out int pnDocStatus, out int pnCheckoutUserNo, out int pnCurDocNo)
        {
            throw new NotImplementedException();
        }

        public int GetObjList(object vUser, int nObjType, int nAccessMask, out object pvaList)
        {
            throw new NotImplementedException();
        }

        public void GetObjRights(object vUser, int nObjType, int nObjNo, int nSubObjNo, out int pnRightsSrvMask, out int pnThereforeDBMask)
        {
            throw new NotImplementedException();
        }

        public int GetObjRightsMap(object vUser, int nObjType, out object pvaList)
        {
            throw new NotImplementedException();
        }

        public int HasPermission(object vUser, int nObjType, int nObjNo, int nSubObjNo, int nAccessMask)
        {
            throw new NotImplementedException();
        }

        public int QueryValidation(object vUser, ref object pvQueryDef)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
