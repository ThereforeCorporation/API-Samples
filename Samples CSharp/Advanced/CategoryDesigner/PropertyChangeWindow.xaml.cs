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
    /// Interaction logic for PropertyChangeWindow.xaml
    /// </summary>
    public partial class PropertyChangeWindow : Window
    {
        public String Value { get; set; }
        private String _propertyname;

        public PropertyChangeWindow(String propertyname)
        {
            _propertyname = propertyname;
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            Value = txt_value.Text;
            this.DialogResult = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_value.Text = Value;
            Title = "Change Property " + _propertyname;
        }
    }
}
