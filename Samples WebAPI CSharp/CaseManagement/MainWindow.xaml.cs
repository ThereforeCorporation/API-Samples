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
using Common;
using System.ServiceModel;
using Therefore.WebAPI.Service.Contract.v0001.Services;
using Therefore.WebAPI.Service.Contract.v0001.Messages;
using Therefore.WebAPI.Service.Contract.v0001.Enums;
using Therefore.WebAPI.Service.Contract.v0001.Data.IndexData.Items;
using Therefore.WebAPI.Service.Contract.v0001.Data.IndexData;
using Therefore.WebAPI.Service.Contract.v0001.Data;
using System.Security.Principal;

namespace CaseManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChannelFactory<IThereforeService> thereforeService;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadCase()
        {
        }

        private void btn_header_fields_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();
                ((IClientChannel)service).Open();

                // 2. Create request parameters
                GetCaseDefinitionParams parameters = new GetCaseDefinitionParams();
                parameters.CaseDefinitionNo = Convert.ToInt32(txt_casedefno.Text);

                // 3. Execute
                GetCaseDefinitionResponse response = service.GetCaseDefinition(parameters);
                
                // 4. Display info
                txt_output.Text = "Case Definition:" + Environment.NewLine;
                txt_output.Text += "Case Definition ID: " + response.CaseDefinition.CaseDefNo + Environment.NewLine;
                txt_output.Text += "Case Name: " + response.CaseDefinition.Name + Environment.NewLine;

                txt_output.Text = "Categories belonging to case definition " + response.CaseDefinition.CaseDefNo + ":" + Environment.NewLine;
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
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                GetCaseDefinitionParams parameters = new GetCaseDefinitionParams();
                parameters.CaseDefinitionNo = Convert.ToInt32(txt_casedefno.Text);

                // 3. Execute
                GetCaseDefinitionResponse response = service.GetCaseDefinition(parameters);
                txt_output.Text = "Categories belonging to case definition " + response.CaseDefinition.CaseDefNo + ":" + Environment.NewLine;
                for (int i = 0; i < response.CaseDefinition.Categories.Count; i++)
                {
                    var category = response.CaseDefinition.Categories[i];
                    txt_output.Text += category.CategoryNo + " - " + category.Name + Environment.NewLine;
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
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                GetCaseParams parameters = new GetCaseParams();
                parameters.CaseNo = Convert.ToInt32(txt_caseno.Text);

                // 3. Execute
                GetCaseResponse response = service.GetCase(parameters);

                //4. Display info
                txt_output.Text += "FieldNo - FieldValue" + Environment.NewLine;
                for (int i = 0; i < response.Case.IndexData.IndexDataItems.Count; i++)
                {
                    var indexData = response.Case.IndexData.IndexDataItems[i];
                    txt_output.Text += indexData.Value.FieldNo + " - " + indexData.Value.ObjDataValue.ToString() + Environment.NewLine;
                }
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
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                GetCaseDocumentsParams parameters = new GetCaseDocumentsParams();
                parameters.CaseNo = Convert.ToInt32(txt_caseno.Text);
                parameters.CategoryNo = Convert.ToInt32(txt_catno.Text);

                // 3. Execute
                GetCaseDocumentsResponse response = service.GetCaseDocuments(parameters);

                //4. Display info
                txt_output.Text = "All documents that belong to case ID: " + parameters.CaseNo + " and category ID: " + parameters.CategoryNo + Environment.NewLine;
                for (int i = 0; i < response.DocumentNos.Count; i++)
                    txt_output.Text += response.DocumentNos[i] + Environment.NewLine;
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
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                GetCaseHistoryParams parameters = new GetCaseHistoryParams();
                parameters.CaseNo = Convert.ToInt32(txt_caseno.Text);

                // 3. Execute
                GetCaseHistoryResponse response = service.GetCaseHistory(parameters);


                //4. Display info
                txt_output.Text = "The History of case ID: " + parameters.CaseNo + Environment.NewLine;
                for (int i = 0; i < response.CaseHistory.Count; i++)
                {
                    txt_output.Text += response.CaseHistory[i].ItemNo + "," + response.CaseHistory[i].Text + Environment.NewLine;
                }
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
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                ExecuteSingleQueryParams parameters = new ExecuteSingleQueryParams();
                parameters.Query = new WSSingleQuery();
                parameters.Query.CaseDefinitionNo = Convert.ToInt32(txt_query_casedefno.Text);
                parameters.Query.Mode = WSQueryMode.CaseQuery;

                // 3. Execute
                ExecuteSingleQueryResponse response = service.ExecuteSingleQuery(parameters);


                //4. Display info
                for (int i = 0; i < response.QueryResult.ResultRows.Count; i++)
                {
                    txt_output.Text += response.QueryResult.ResultRows[i].DocNo.ToString() + Environment.NewLine;
                }
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
                // 1B. Create a channel to the web service endpoint
                IThereforeService service = thereforeService.CreateChannel();

                // 2. Create request parameters
                CreateCaseParams parameters = new CreateCaseParams();
                parameters.CaseDefNo = CategoryIds.ReportsCaseDefinition;
                parameters.IndexDataItems.Add(new WSIndexDataItem(new WSIndexDataInt(CategoryIds.Reports_Num, 3)));
                parameters.IndexDataItems.Add(new WSIndexDataItem(new WSIndexDataString(CategoryIds.Reports_Name, "Third")));

                // 3. Execute
                CreateCaseResponse response = service.CreateCase(parameters);
                txt_output.Text = "Case created. No: " + response.CaseNo;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectionDialog dialog = new SelectionDialog();
                dialog.LoadCategories(thereforeService.CreateChannel());
                bool? dialogResult = dialog.ShowDialog();

                if (dialogResult == true)
                {
                    int nCaseDefNo = dialog.SelectedItemId;
                    txt_casedefno.Text = txt_query_casedefno.Text = nCaseDefNo.ToString();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // 1A. Get user credentials
                if (thereforeService == null)
                    if (null == (thereforeService = ThereforeServiceConnection.CreateChannelFactory()))
                        this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (thereforeService != null)
                thereforeService.Close();
        }
    }
}
