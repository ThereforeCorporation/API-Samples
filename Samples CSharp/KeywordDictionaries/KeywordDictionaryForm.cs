using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Therefore.API;

namespace KeywordDictionaries
{
    public partial class KeywordDictionaryForm : Form
    {
        private TheKeywordDictionary _dictionary;

        public KeywordDictionaryForm()
        {
            _dictionary = null;
            InitializeComponent();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            try
            {
                //load the keyword dictionary and display its content
                TheServer server = new TheServer();
                server.Connect();
                _dictionary = new TheKeywordDictionary();
                txt_content.Text = _dictionary.ToString();
                _dictionary.LoadByID(Convert.ToInt32(txt_keydictno.Text), server);
                //_dictionary.LoadByTypeNo(Convert.ToInt32(txt_keydictno.Text), server);
                //with LoadByTypeNo() the keyword dictionary can be loaded with the value from TheCategoryField.TypeNo
                //this will only work when either TheCategoryField.SingleKeyword or TheCategoryField.MultiKeyword is true
                server.Disconnect();
                txt_content.Text = _dictionary.ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());	
            }
        }

        private void btn_deactivate_Click(object sender, EventArgs e)
        {
            try
            {
                //this will deactivate the keyword with the specified ID
                TheKeyword keyword = null;
                int keywordID = Convert.ToInt32(txt_deactivate_keyword.Text);
                keyword = _dictionary.GetKeyword(keywordID);
                //switch deactivated property to opposite value
                keyword.Deactivated = !keyword.Deactivated;
                        
                txt_content.Text = _dictionary.ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                //this will delete the keyword with the specified ID from the dictionary
                int keywordID = Convert.ToInt32(txt_delete_keyword.Text);
                _dictionary.Remove(keywordID);
                txt_content.Text = _dictionary.ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                //this will add a new keyword
                TheKeyword keyword = new TheKeyword();
                keyword.Name = txt_new_keyword.Text;
                _dictionary.Add(keyword);
                txt_content.Text = _dictionary.ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_save_changes_Click(object sender, EventArgs e)
        {
            try
            {
                //changes made on the keyword dictionary will not be saved until SaveChanges() is called
                TheServer server = new TheServer();
                server.Connect();
                _dictionary.SaveChanges(server);
                server.Disconnect();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_delete_at_Click(object sender, EventArgs e)
        {
            try
            {
                //this will delete the keyword with the specified ID from the dictionary
                int index = Convert.ToInt32(txt_delete_at.Text);
                _dictionary.RemoveAt(index);
                txt_content.Text = _dictionary.ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_rename_Click(object sender, EventArgs e)
        {
            try
            {
                TheKeyword keyword = _dictionary.GetKeyword(txt_rename_from.Text);
                keyword.Name = txt_rename_to.Text;
                txt_content.Text = _dictionary.ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
