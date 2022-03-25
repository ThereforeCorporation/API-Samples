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

namespace Therefore.Samples
{
    /// <summary>
    /// Interaction logic for ListPropertyChangeWindow.xaml
    /// </summary>
    public partial class ListPropertyChangeWindow : Window
    {
        public String Value { get; set; }
        private String _propertyname;

        public ListPropertyChangeWindow(String propertyname, List<String> options)
        {
            _propertyname = propertyname;
            InitializeComponent();
            if (options.Count == 0)
                this.Close();
            cmb_options.ItemsSource = options;
            cmb_options.SelectedIndex = 0;
        }

        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            Value = (String)cmb_options.SelectedItem;
            this.DialogResult = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmb_options.SelectedItem = Value;
            Title = "Change Property " + _propertyname;
        }
    }
}
