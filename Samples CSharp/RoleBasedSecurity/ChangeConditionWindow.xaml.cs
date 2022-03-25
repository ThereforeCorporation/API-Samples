using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Therefore.API;

namespace RoleBasedSecurity
{
    /// <summary>
    /// Interaction logic for ChangeConditionWindow.xaml
    /// </summary>
    public partial class ChangeConditionWindow : Window
    {
        public string Condition { get; private set; }

        public ChangeConditionWindow(string condition)
        {
            InitializeComponent();
            Condition = condition;
            txt_condition.Text = Condition;
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            Condition = txt_condition.Text;
            DialogResult = true;
            Close();
        }
    }
}
