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
    /// Interaction logic for NewCaseDefinitionWindow.xaml
    /// </summary>
    public partial class NewCaseDefinitionWindow : Window
    {
        public String CaseDefinitionName { get; set; }
        public int FolderNo { get; set; }

        public NewCaseDefinitionWindow()
        {
            InitializeComponent();
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
                server.GetObjects(TheObjectType.CategoryObject, new TheAccessMask(), TheGetObjectFlags.GetAllFolders, out itemlist, out folderlist);
                List<Folder> folder = new List<Folder>();
                for(int i = 0; i < folderlist.Count; i++)
                {
                    TheFolder f = folderlist[i];
                    folder.Add(new Folder(f));
                }
                cmb_folder.ItemsSource = folder;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CaseDefinitionName = txt_name.Text;
                Folder f = (Folder)cmb_folder.SelectedItem;
                FolderNo = f.FolderItem.FolderNo;
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DialogResult = false;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }    
    }
}