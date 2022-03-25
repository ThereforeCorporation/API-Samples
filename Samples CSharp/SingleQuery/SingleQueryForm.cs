using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace SingleQuery
{
    public partial class SingleQueryForm : Form
    {
        public SingleQueryForm()
        {
            InitializeComponent();
        }

        private TheServer server;
        private TheQueryResult result;

        private void SingleQueryForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Connect to the Therefore™ server
                server = new TheServer();
                server.Connect(TheClientType.CustomApplication);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_simple_Click(object sender, EventArgs e)
        {
            try
            {
                int ctgryno = getCtgryNoFromName("Files");
                int fieldno = getFieldNoFromName("Files", "Extension");


                // 2. Call the ExecuteSimple of a temporary TheQuery instance
                // Finds index data in category "ctgryno" where field "fieldno" starts with a "d"
                // and sorts the results by the value of field "fieldno".
                result = new TheQuery().ExecuteSimple(ctgryno, fieldno, "d*", fieldno, server);

                // Optional 3. Display a message box with the results.
                MessageBox.Show(result.ToString());
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_execute_Click(object sender, EventArgs e)
        {
            try
            {
                int fieldno = getFieldNoFromName("Files", "Extension");
                // 2. Declare and initialize a new TheQuery
                TheQuery query = new TheQuery();

                // 3. Set a category
                query.Category.Load("Files", server);

                // 4. Add all visible fields except "Extension"
                query.SelectFields.AddAll();
                query.SelectFields.Remove("Extension");

                // Optional 5. Get the list of valid condition operators
                ITheReadOnlyStringList operators = query.ValidOperators;
                txt_result.Text = (operators.ToString());

                // 6. Define query conditions
                query.Conditions.Add(fieldno, "d* or t*"); // using the field number
                query.Conditions.Add("Filename", "*Moya*"); // using the column name

                // 7. Sort results by InvoiceNo
                query.OrderByFields.Add("Creation_Date");

                // 8. Execute the query
                result = query.Execute(server);

                // Optional 9. Display Query definition and results in a MessageBox
                MessageBox.Show(query.ToString() + "\r\n" + result.ToString());
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_process_Click(object sender, EventArgs e)
        {
            try
            {
                // Iterate through search result using nested for-loops
                for (int i = 0; i < result.Count; i++)
                {
                    txt_result.Text = (result[i].ToString());
                    for (int j = 0; j < result[i].Count; j++)
                    {
                        // Access the j-th field in the i-th row
                        if (result[i][j] != null)
                            txt_result.Text = (result[i][j].ToString());
                    }
                }

                // Iterate through search result using the for-each constructs
                // Type-specific handling of field values
                foreach (TheQueryResultRow row in result)
                {
                    txt_result.Text = (row.ToString());
                    foreach (object obj in row)
                    {
                        if (obj is DBNull)
                        {
                            txt_result.Text += "null";
                        }
                        else if (obj is int)
                        {
                            int i = (int)obj;
                            txt_result.Text += i + " * " + i + " = " + (i * i);
                        }
                        else if (obj is double)
                        {
                            double d = (double)obj;
                            txt_result.Text += d + " / 2 = " + (d / 2);
                        }
                        else if (obj is string)
                        {
                            string s = (string)obj;
                            txt_result.Text += "\"" + s + "\" is a string";
                        }
                        else if (obj is DateTime)
                        {
                            DateTime dt = (DateTime)obj;
                            TimeSpan ts = DateTime.Now - dt;
                            txt_result.Text += ts.TotalDays + "days ago.";
                        }
                        else
                        {
                            txt_result.Text += "A " + obj.GetType().ToString();
                        }
                        txt_result.Text += "\r\n";
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int getCtgryNoFromName(string strCtgryName)
        {
            TheCategoryClass cat = new TheCategoryClass();
            cat.Load(strCtgryName, server);
            return cat.CtgryNo;
        }

        private int getFieldNoFromName(string strCtgryName, string strFieldName)
        {
            TheCategoryClass cat = new TheCategoryClass();
            cat.Load(strCtgryName, server);
            TheCategoryField field = cat.GetFieldByColName(strFieldName);
            return field.FieldNo;
        }
    }
}
