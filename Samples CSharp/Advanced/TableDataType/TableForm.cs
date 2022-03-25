using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace TableDataType
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_docno.Text == "")
                {
                    MessageBox.Show("Please enter a valid document number.");
                    return;
                }
                TheServer server = new TheServer();
                server.Connect();
                int docNo = Convert.ToInt32(txt_docno.Text);
                //retrieve the document
                TheDocument doc = new TheDocument();
                doc.Retrieve(docNo, "", server);
                TheCategoryField tableField = null;
                //find the first table data type
                for (int i = 0; i < doc.IndexData.Category.FieldCount; i++)
                {
                    TheCategoryField field = doc.IndexData.Category.GetFieldByIndex(i);
                    if (field.FieldType == TheCategoryFieldType.TableField)
                    {
                        tableField = field;
                        break;
                    }
                }

                if (tableField == null)//stop if there is not table data type in this category
                {
                    MessageBox.Show("No table field found in this category.");
                    return;
                }

                //clear the datagridview from previous entries
                dgv_table_data.Rows.Clear();
                dgv_table_data.Columns.Clear();

                //next create the columns in the datagridview
                TheObjectList fieldlist = doc.IndexData.Category.GetTableFields(tableField.FieldNo);
                for (int i = 0; i < fieldlist.Count; i++)
                {
                    TheCategoryField tablefield = doc.IndexData.Category.GetFieldByFieldNo((int)fieldlist[i]);
                    //create a new column in the datagridview
                    dgv_table_data.Columns.Add(tablefield.IndexDataFieldName, tablefield.IndexDataFieldName);
                }
                
                //load the table data into the dedicated class
                TheTableDataType table = doc.IndexData.GetTableValue(tableField.FieldNo);
                
                //write the table data into the datagridview
                for (int i = 0; i < table.RowCount; i++)
                {
                    int rowID = dgv_table_data.Rows.Add();
                    for (int j = 0; j < fieldlist.Count; j++)
                    {
                        dgv_table_data.Rows[rowID].Cells[j].Value = Convert.ToString(table.GetValue((int)fieldlist[j], i));
                    }
                }
                doc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (dgv_table_data.Columns.Count <= 0)
            {
                MessageBox.Show("A document needs to be loaded first.");
                return;
            }

            try
            {
                //get the document again
                if (txt_docno.Text == "")
                {
                    MessageBox.Show("Please enter a valid document number.");
                    return;
                }
                TheServer server = new TheServer();
                server.Connect();
                int docNo = Convert.ToInt32(txt_docno.Text);
                //retrieve the document
                TheDocument doc = new TheDocument();
                doc.Retrieve(docNo, "", server);
                TheCategoryField tableField = null;
                //find the first table data type
                for (int i = 0; i < doc.IndexData.Category.FieldCount; i++)
                {
                    TheCategoryField field = doc.IndexData.Category.GetFieldByIndex(i);
                    if (field.FieldType == TheCategoryFieldType.TableField)
                    {
                        tableField = field;
                        break;
                    }
                }

                if (tableField == null)//stop if there is not table data type in this category
                {
                    MessageBox.Show("No table field found in this category.");
                    return;
                }
                //get the table object
                TheTableDataType table = doc.IndexData.GetTableValue(tableField.FieldNo);
                //run through all rows in the datagridview
                for (int row = 0; row < dgv_table_data.Rows.Count; row++)
                {
                    //and all the columns
                    for(int col = 0; col < dgv_table_data.Columns.Count; col++)
                    {
                        //then simply set the value. new rows will be added to the table automatically
                        table.SetValue(dgv_table_data.Columns[col].HeaderText, row, dgv_table_data.Rows[row].Cells[col].Value);
                    }
                }

                //delete all rows that don't exist anymore
                if (table.RowCount > dgv_table_data.Rows.Count-1)// -1 because of the empty line that is displayed for creating new rows
                    table.RemoveAt(dgv_table_data.Rows.Count - 1, table.RowCount - (dgv_table_data.Rows.Count - 1));
                
                //set the value table. if you don't do this the changes will not be saved
                doc.IndexData.SetTableValue(tableField.FieldNo, table);
                //save the changes
                doc.IndexData.SaveChanges(server);
                //and close the document
                doc.Close();

                MessageBox.Show("The values have been saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
