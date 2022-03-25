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
using System.Windows.Shapes;
using Therefore.API;

namespace Therefore.Samples
{
    /// <summary>
    /// Interaction logic for NewFieldWindow.xaml
    /// </summary>
    public partial class NewFieldWindow : Window
    {
        private TheCategory _cat;
        private TheCaseDefinition _casedef;
        
        public NewFieldWindow(TheCategory cat)
        {
            _cat = cat;
            _casedef = null;
            InitializeComponent();
        }

        public NewFieldWindow(TheCaseDefinition casedef)
        {
            _cat = null;
            _casedef = casedef;
            InitializeComponent();
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public int TypeNo
        {
            get { return Convert.ToInt32(txt_typeno.Text); }
        }

        public String FieldName
        {
            get { return txt_name.Text; }
        }

        public int BelongsTo
        {
            get { return Convert.ToInt32(txt_belongsto.Text); }
        }

        public int BelongsToTable
        {
            get { return Convert.ToInt32(txt_belongstotable.Text); }
        }

        public bool IsCaseHeaderField
        {
            get { return ckb_iscasefield.IsChecked == true; }
        }

        private void dg_datatypes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                TheFolderItem item = (TheFolderItem)dg_datatypes.SelectedItem;
                if (item == null)
                    return;
                txt_typeno.Text = item.ID.ToString();
                txt_name.Text = item.Name + " ID";
                if (_cat != null)
                {
                    if (_cat.BelongsToCaseDefinition == 0)
                        return;
                    TheCaseDefinition casedef = new TheCaseDefinition();
                    TheServer server = new TheServer();
                    server.Connect(TheClientType.CustomApplication, "", "", "", "", true);
                    casedef.Load(_cat.BelongsToCaseDefinition, server);
                    if (item.ID == casedef.TypeNo)
                        ckb_iscasefield.IsChecked = true;
                    else
                        ckb_iscasefield.IsChecked = false;
                }
                else
                    ckb_iscasefield.IsChecked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                TheServer server = new TheServer();
                if (!server.Connected)
                    server.Connect(TheClientType.CustomApplication, "", "", "", "", true);
                TheFolderItemList itemlist = new TheFolderItemList();
                TheFolderList folderlist = new TheFolderList();
                server.GetObjects(TheObjectType.DataTypeObject, new TheAccessMask(), TheGetObjectFlags.GetNoFolders, out itemlist, out folderlist);
                TheFolderItemList dictionarylist = new TheFolderItemList();
                server.GetObjects(TheObjectType.KeyDictObject, new TheAccessMask(), TheGetObjectFlags.GetNoFolders, out dictionarylist, out folderlist);
                foreach(TheFolderItem item in dictionarylist)
                {
                    item.Data = (int)TheTypeGroup.KeywordTypeGroup;
                    TheKeywordDictionary dict = new TheKeywordDictionary();
                    dict.LoadByID(item.ID, server);
                    item.ID = dict.SingleTypeNo;
                    itemlist.Add(item);
                }
                dg_datatypes.ItemsSource = itemlist;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Close();
            }
        }

        private void dg_datatypes_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            try
            {
                TheFolderItem item = (TheFolderItem)dg_datatypes.SelectedItem;
                if (item == null)
                {
                    cmn_columns.Visibility = Visibility.Hidden;
                    return;
                }
                if (item.Data == (int)TheTypeGroup.KeywordTypeGroup || item.Data == (int)TheTypeGroup.StandardTypeGroup)
                {
                    cmn_columns.Visibility = Visibility.Hidden;
                    return;
                }
                TheReferencedTable rt = new TheReferencedTable();
                TheServer server = new TheServer();
                if (!server.Connected)
                    server.Connect(TheClientType.CustomApplication, "", "", "", "", true);
                rt.Load(item.ID, server);
                //List<TheReferencedTableColumn> columns = new List<TheReferencedTableColumn>();
                cmn_columns.Items.Clear();
                for (int i = 0; i < rt.ColumnCount; i++)
                {
                    TheReferencedTableColumn col = rt.GetColumn(i);
                    if (col.Name == rt.IndexColumn)
                        continue;
                    MenuItem mitem = new MenuItem();
                    mitem.DataContext = col;
                    mitem.Header = col.Name;
                    mitem.Click += new RoutedEventHandler(OnMenuItemClick);
                    cmn_columns.Items.Add(mitem);
                    //columns.Add(rt.GetColumn(i));
                }
                //cmn_columns.ItemsSource = columns;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OnMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (sender == null)
                    return;
                TheReferencedTableColumn col = (TheReferencedTableColumn)((MenuItem)sender).DataContext;
                TheFolderItem item = (TheFolderItem)dg_datatypes.SelectedItem;
                TheCategoryField primaryfield = null;//first get the primary field
                int count = 0;
                if (_cat != null)
                    count = _cat.FieldCount;
                else
                    count = _casedef.FieldCount;

                for (int i = 0; i < count; i++)
                {
                    TheCategoryField field = null;
                    if (_cat != null)
                        field = _cat.GetFieldByIndex(i);
                    else
                        field = _casedef.GetFieldByIndex(i);
                    if (field.TypeNo == item.ID)
                    {
                        primaryfield = field;
                        break;
                    }
                }
                
                if (primaryfield == null)
                    throw new Exception("Primary field not added to category.");

                txt_typeno.Text = col.type.ToString();
                txt_name.Text = col.Name;
                txt_belongsto.Text = primaryfield.FieldNo.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
