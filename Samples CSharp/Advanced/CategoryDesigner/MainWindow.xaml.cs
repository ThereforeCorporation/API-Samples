using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Therefore.Samples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FieldViewModel _viewmodel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cmb_filter_type.ItemsSource = Enum.GetValues(typeof(TheCategoryFieldType));
                cmb_filter_type.SelectedItem = TheCategoryFieldType.LabelField;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Close();
            }
        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TheServer server = new TheServer();
                server.Connect(TheClientType.CustomApplication, "", "", "", "", true);

                UnlockViewModelObject(server);//needed when loading a category or case definition when something is already loaded
                if (rdb_category.IsChecked == true)
                {
                    int catno = server.ShowCategorySelectionDialog();
                    TheCategory cat = new TheCategory();
                    cat.LoadForEdit(catno, server);
                    _viewmodel = new CategoryFieldViewModel(cat);
                }
                else if (rdb_casedefinition.IsChecked == true)
                {
                    int casedefno = server.ShowCaseDefinitionSelectionDialog();
                    TheCaseDefinition casedef = new TheCaseDefinition();
                    casedef.LoadForEdit(casedefno, server);
                    _viewmodel = new CaseDefFieldViewModel(casedef);
                    _viewmodel.CurrentLanguage = CultureInfo.CurrentCulture;
                }
                
                if(cmb_filter_type.SelectedItem != null)
                    _viewmodel.FilterFieldType = (TheCategoryFieldType)cmb_filter_type.SelectedItem;
                if(rdb_filter_type_only.IsChecked == true)
                    _viewmodel.FilterTypeFieldType = TheFilterType.FilterOnlyBy;
                else if (rdb_filter_type_exclude.IsChecked == true)
                    _viewmodel.FilterTypeFieldType = TheFilterType.FilterExclude;
                else
                    _viewmodel.FilterTypeFieldType = TheFilterType.FilterNothing;
                dg_categoryfields.DataContext = _viewmodel;

                cmb_language.ItemsSource = _viewmodel.Languages;
                if (_viewmodel.Languages.Contains(_viewmodel.CurrentLanguage))
                    cmb_language.SelectedItem = _viewmodel.CurrentLanguage;
                else
                    cmb_language.SelectedIndex = 0;

                server.Disconnect();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmb_filter_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(_viewmodel == null)
                return;
            _viewmodel.FilterFieldType = (TheCategoryFieldType)cmb_filter_type.SelectedItem;
        }

        private void rdb_filter_type_only_Checked(object sender, RoutedEventArgs e)
        {
            if (_viewmodel == null)
                return;
            _viewmodel.FilterTypeFieldType = TheFilterType.FilterOnlyBy;
        }

        private void rdb_filter_type_exclude_Checked(object sender, RoutedEventArgs e)
        {
            if (_viewmodel == null)
                return;
            _viewmodel.FilterTypeFieldType = TheFilterType.FilterExclude;
        }

        private void rdb_filter_type_all_Checked(object sender, RoutedEventArgs e)
        {
            if (_viewmodel == null)
                return;
            _viewmodel.FilterTypeFieldType = TheFilterType.FilterNothing;
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TheServer server = new TheServer();
                server.Connect(TheClientType.CustomApplication, "", "", "", "", true);
                
                if (rdb_category.IsChecked == true)
                {
                    NewCategoryWindow nc = new NewCategoryWindow();
                    if (nc.ShowDialog() == false)
                        return;
                    TheCategory cat = new TheCategory();
                    cat.Create(nc.CategoryName, nc.CaseDefNo, server);
                    _viewmodel = new CategoryFieldViewModel(cat);
                }
                else if (rdb_casedefinition.IsChecked == true)
                {
                    NewCaseDefinitionWindow nc = new NewCaseDefinitionWindow();
                    if (nc.ShowDialog() == false)
                        return;
                    TheCaseDefinition casedef = new TheCaseDefinition();
                    casedef.Create(nc.CaseDefinitionName, nc.FolderNo);
                    _viewmodel = new CaseDefFieldViewModel(casedef);                
                }                
                
                if (cmb_filter_type.SelectedItem != null)
                    _viewmodel.FilterFieldType = (TheCategoryFieldType)cmb_filter_type.SelectedItem;
                if (rdb_filter_type_only.IsChecked == true)
                    _viewmodel.FilterTypeFieldType = TheFilterType.FilterOnlyBy;
                else if(rdb_filter_type_exclude.IsChecked == true)
                    _viewmodel.FilterTypeFieldType = TheFilterType.FilterExclude;
                else
                    _viewmodel.FilterTypeFieldType = TheFilterType.FilterNothing;
                dg_categoryfields.DataContext = _viewmodel;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(_viewmodel == null)
                    return;

                TheServer server = new TheServer();
                server.Connect(TheClientType.CustomApplication, "", "", "", "", true);

                if(_viewmodel is CategoryFieldViewModel)
                    ((CategoryFieldViewModel)_viewmodel).Category.SaveChanges(server);
                else
                    ((CaseDefFieldViewModel)_viewmodel).CaseDefinition.SaveChanges(server);
                _viewmodel.UpdateFieldList();
                UnlockViewModelObject(server);                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_create_field_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TheCategory cat = null;
                TheCaseDefinition casedef = null;

                NewFieldWindow nfw = null;
                if (_viewmodel is CategoryFieldViewModel)
                {
                    cat = ((CategoryFieldViewModel)_viewmodel).Category;
                    nfw = new NewFieldWindow(cat);
                }
                else
                {
                    casedef = ((CaseDefFieldViewModel)_viewmodel).CaseDefinition;
                    nfw = new NewFieldWindow(casedef);
                }
                if (!nfw.ShowDialog() == true)
                    return;

                TheServer server = new TheServer();
                server.Connect(TheClientType.CustomApplication, "", "", "", "", true);

                if (cat != null)
                    cat.CreateField(nfw.TypeNo, nfw.FieldName, nfw.BelongsTo, nfw.BelongsToTable, server);
                else
                    casedef.CreateField(nfw.TypeNo, nfw.FieldName, nfw.BelongsTo, nfw.BelongsToTable, server);
                _viewmodel.UpdateFieldList();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_delete_field_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TheCategoryField field = (TheCategoryField)dg_categoryfields.SelectedItem;
                if (field == null || _viewmodel == null)
                    return;
                if(_viewmodel is CategoryFieldViewModel)
                    ((CategoryFieldViewModel)_viewmodel).Category.DeleteField(field);
                else
                    ((CaseDefFieldViewModel)_viewmodel).CaseDefinition.DeleteField(field);
                _viewmodel.UpdateFieldList();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dg_categoryfields_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                TheCategoryField field = (TheCategoryField)dg_categoryfields.SelectedItem;
                if (field == null)
                    return;
                if (dg_categoryfields.CurrentCell.Column.Header.ToString() == "DependencyMode")
                {
                    List<String> options = new List<String>();
                    options.AddRange(Enum.GetNames(typeof(TheDependencyMode)));
                    ListPropertyChangeWindow lpcw = new ListPropertyChangeWindow("DependencyMode", options);
                    lpcw.Value = field.DependencyMode.ToString();
                    if (lpcw.ShowDialog() == true)
                        field.ChangeDependencyMode((TheDependencyMode)Enum.Parse(typeof(TheDependencyMode), lpcw.Value), "");
                    _viewmodel.UpdateFieldList();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_test_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TheIndexData ixdata = new TheIndexData();
                if (_viewmodel is CategoryFieldViewModel)
                {
                    TheCategory cat = ((CategoryFieldViewModel)_viewmodel).Category;
                    if (cat == null || cat.CtgryNo < 0)
                        return;
                    ixdata.SetCategory(cat);                    
                }
                else
                {
                    TheCaseDefinition casedef = ((CaseDefFieldViewModel)_viewmodel).CaseDefinition;
                    if (casedef == null || casedef.CaseDefinitionNo < 0)
                        return;
                    ixdata.SetCaseDefinition(casedef);
                    
                }
                if (ixdata == null)
                    return;
                TheServer server = new TheServer();
                server.Connect(TheClientType.CustomApplication, "", "", "", "", true);
                ixdata.EditIxData(server, "", "");
                server.Disconnect();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_properties_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_viewmodel is CategoryFieldViewModel)
                {
                    TheCategory cat = ((CategoryFieldViewModel)_viewmodel).Category;
                    if (cat == null)
                        return;
                    CategoryPropertiesWindow catprop = new CategoryPropertiesWindow(cat);
                    catprop.ShowDialog();
                }
                else
                {
                    TheCaseDefinition casedef = ((CaseDefFieldViewModel)_viewmodel).CaseDefinition;
                    if (casedef == null)
                        return;
                    CaseDefinitionPropertiesWindow casedefprop = new CaseDefinitionPropertiesWindow(casedef);
                    casedefprop.ShowDialog();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_translation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Translation translationdlg = null;
                if (_viewmodel is CategoryFieldViewModel)
                    translationdlg = new Translation(((CategoryFieldViewModel)_viewmodel).Category);
                else if (_viewmodel is CaseDefFieldViewModel)
                    translationdlg = new Translation(((CaseDefFieldViewModel)_viewmodel).CaseDefinition);
                translationdlg.ShowDialog();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmb_language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _viewmodel.CurrentLanguage = (CultureInfo)cmb_language.SelectedItem;
                _viewmodel.UpdateFieldList();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UnlockViewModelObject(TheServer server)
        {
            if (_viewmodel == null)
                return;
            if (server == null)
                server = new TheServer();
            if (!server.Connected)
                server.Connect(TheClientType.CustomApplication, "", "", "", "", true);

            if (_viewmodel is CategoryFieldViewModel)
            {
                if (((CategoryFieldViewModel)_viewmodel).Category != null)
                    ((CategoryFieldViewModel)_viewmodel).Category.Unlock(server);
            }
            else if (_viewmodel is CaseDefFieldViewModel)
                if (((CaseDefFieldViewModel)_viewmodel).CaseDefinition != null)
                    ((CaseDefFieldViewModel)_viewmodel).CaseDefinition.Unlock(server);
        }
    }

    public enum TheFilterType
    {
        FilterExclude = 0,
        FilterOnlyBy = 1,
        FilterNothing = 2
    }
}
