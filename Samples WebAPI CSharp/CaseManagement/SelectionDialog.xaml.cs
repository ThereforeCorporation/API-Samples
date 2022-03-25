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
using Therefore.WebAPI.Service.Contract.v0001.Services;
using Therefore.WebAPI.Service.Contract.v0001.Data;
using Therefore.WebAPI.Service.Contract.v0001.Enums;
using Common;
using System.ServiceModel;
using System.ComponentModel;
using Therefore.WebAPI.Service.Contract.v0001.Messages;

namespace CaseManagement
{
    /// <summary>
    /// Interaction logic for SelectionDialog.xaml
    /// </summary>
    public partial class SelectionDialog : Window, INotifyPropertyChanged
    {
        public SelectionDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        public List<WSCategoryTreeItem> CategoryTreeItems { get; set; }
        public int SelectedItemId { get; set; }

        private WSCategoryTreeItem selectedItem;

        public void LoadCategories(IThereforeService channel)
        {
            try
            {
                var categoryTreeData = channel.GetCategoriesTree(new GetCategoriesTreeParams());

                WSCategoryTreeItem rootItem = new WSCategoryTreeItem();
                rootItem.ItemType = WSCategoryTreeItemType.Root;
                rootItem.Name = "Category Folder";
                rootItem.ChildItems.AddRange(categoryTreeData.TreeItems);

                CategoryTreeItems = new List<WSCategoryTreeItem>();
                CategoryTreeItems.Add(rootItem);

                OnPropertyChanged("CategoryTreeItems");
            }
            catch (FaultException e)
            {
                MessageBox.Show(e.Message, "Load Categories Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (CommunicationException e)
            {
                MessageBox.Show(e.Message, "Load Categories Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (TimeoutException e)
            {
                MessageBox.Show(e.Message, "Load Categories Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Load Categories Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            SelectedItemId = selectedItem.ItemNo;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void tv_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            selectedItem = (WSCategoryTreeItem)(sender as TreeView).SelectedItem;
            button1.IsEnabled = (selectedItem.ItemType == WSCategoryTreeItemType.CaseDefinition);
        }
    }
}
