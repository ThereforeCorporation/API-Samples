using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Therefore.API;

namespace CaseManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TheCase _case;
        private TheServer _server;

        public MainWindow()
        {
            _case = null;
            _server = new TheServer();
            _server.Connect();
            InitializeComponent();
        }

        private void LoadCase()
        {
            if (_case == null)
                _case = new TheCase();
            int caseno = Convert.ToInt32(txt_caseno.Text);
            if (_case.CaseNo != caseno)
                _case.Load(caseno, _server);
        }

        private void btn_header_fields_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TheCaseDefinition casedefinition = new TheCaseDefinition();
                casedefinition.Load(Convert.ToInt32(txt_casedefno.Text), _server);
                txt_output.Text = "Case Definition:" + Environment.NewLine;
                txt_output.Text += "Case Definition ID: " + casedefinition.CaseDefinitionNo + Environment.NewLine;
                txt_output.Text += "Case Name: " + casedefinition.Name + Environment.NewLine;
                for (int i = 0; i < casedefinition.FieldCount ; i++)
                {
                    TheCategoryField field = casedefinition.GetFieldByIndex(i);
                    if (field.FieldType == TheCategoryFieldType.LabelField)
                        continue;
                    txt_output.Text += Environment.NewLine;
                    txt_output.Text += "IndexDataFieldName: " + field.IndexDataFieldName + Environment.NewLine;
                    txt_output.Text += "FieldNo: " + field.FieldNo + Environment.NewLine;
                    txt_output.Text += "FieldType: " + field.FieldType.ToString() + Environment.NewLine;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_categories_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TheCaseDefinition casedefinition = new TheCaseDefinition();
                casedefinition.Load(Convert.ToInt32(txt_casedefno.Text), _server);
                txt_output.Text = "Categories belonging to case definition " + casedefinition.CaseDefinitionNo + Environment.NewLine;
                for (int i = 0; i < casedefinition.Categories.Count; i++)
                {
                    TheFolderItem category = casedefinition.Categories[i];
                    txt_output.Text += category.ID + " - " + category.Name + Environment.NewLine;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_header_indexdata_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCase();
                txt_output.Text = _case.IndexData.ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_documents_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCase();
                txt_output.Text = "All documents that belong to case ID: " + _case.CaseNo + Environment.NewLine;
                TheIntArray aDocuments = _case.GetDocuments();
                for (int i = 0; i < aDocuments.Count; i++ )
                    txt_output.Text += aDocuments[i] + Environment.NewLine;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_doc_for_cat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCase();
                txt_output.Text = "All documents that belong to case ID: " + _case.CaseNo + " and category ID: " + Convert.ToInt32(txt_catno.Text) + Environment.NewLine;
                TheIntArray aDocuments = _case.GetDocuments(Convert.ToInt32(txt_catno.Text));
                for (int i = 0; i < aDocuments.Count; i++)
                    txt_output.Text += aDocuments[i] + Environment.NewLine;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_show_history_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCase();
                txt_output.Text = "The History of case ID: " + _case.CaseNo + Environment.NewLine;
                TheCaseHistory history = _case.GetHistory(_server);
                for (int i = 0; i < history.Count ; i++ )
                {
                    txt_output.Text += history[i].Text + Environment.NewLine;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_openviewer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCase();
                _case.View();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_closeviewer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _case.CloseCaseManager();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_query_all_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TheQuery query = new TheQuery();
                TheCaseDefinition casedef = new TheCaseDefinition();
                casedef.Load(Convert.ToInt32(txt_query_casedefno.Text), _server);
                query.CaseDefinition = casedef;
                query.SelectFields.AddAll();
                query.Mode = TheQueryMode.CaseQuery;
                TheQueryResult result = query.Execute(_server);
                txt_output.Text = result.ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TheCase newcase = new TheCase();
                int nCaseDefNo = 0; 
                if(txt_casedefno_create.Text != "")
                {
                    nCaseDefNo = Convert.ToInt32(txt_casedefno_create.Text);
                    newcase.IndexData.SetCaseDefinition(nCaseDefNo, _server);
                }
                newcase.IndexData.EditIxData(_server, "", "",TheObjectType.CaseDefinition);
                int nCaseNo = newcase.Create(_server);
                txt_output.Text = "Case No of new case: " + nCaseNo + Environment.NewLine;
                txt_output.Text += newcase.IndexData.ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_selection_dialog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int nCaseDefNo =_server.ShowCaseDefinitionSelectionDialog();
                txt_casedefno.Text = txt_casedefno_create.Text = txt_query_casedefno.Text = nCaseDefNo.ToString();                 
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_open_dialog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCase();
                _case.IndexData.EditIxData(_server, "", "");
                txt_output.Text = _case.IndexData.ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_closecase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCase();
                _case.CloseCase(_server);
                txt_output.Text = _case.IndexData.ToString() + Environment.NewLine;
                txt_output.Text += Convert.ToString("IsClosed: " + _case.IsClosed);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_reopencase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCase();
                _case.ReopenCase(_server);
                txt_output.Text = _case.IndexData.ToString() + Environment.NewLine;
                txt_output.Text += Convert.ToString("IsClosed: " + _case.IsClosed);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
