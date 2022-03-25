using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Therefore.API;
using System.IO;

namespace TheAPIWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            int nResult = 0;
            if (txtDocNo.Text == "")
                Response.Write("Please enter a valid DocNo.");
            else if (!Int32.TryParse(txtDocNo.Text, out nResult))
                Response.Write("Please enter a valid DocNo.");
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
                    //the full path to the temporary file will be memorized in strTheFile
                    string strTheFile = doc.Retrieve(Int32.Parse(txtDocNo.Text), "", server);
                    string strDoc = "";
                    //and then extract all files from the document to the Temp folder
                    for (int i = 0; i < doc.StreamCount; i++)
                        //memorize path and file name of the last file in the document
                        strDoc = doc.ExtractStream(i, Path.GetTempPath());
                       
                    FileInfo downloadFile = new FileInfo(strDoc);

                    //build the response to the client
                    Response.Expires = -1;
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment; filename = " + downloadFile.Name);
                    Response.AddHeader("Content-Length", downloadFile.Length.ToString());
                    Response.Flush();
                    //and deliver the file
                    Response.WriteFile(strDoc);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
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