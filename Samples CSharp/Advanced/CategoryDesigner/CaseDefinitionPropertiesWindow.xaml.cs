using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for CategoryPropertiesWindow.xaml
    /// </summary>
    public partial class CaseDefinitionPropertiesWindow : Window
    {
        private TheCaseDefinition _casedef;
        public CaseDefinitionPropertiesWindow(TheCaseDefinition casedef)
        {
            _casedef = casedef;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.DataContext = _casedef;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_change_subcase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PropertyChangeWindow pcw = new PropertyChangeWindow("SubCaseField");
                if (pcw.ShowDialog() == true)
                    _casedef.SetSubCaseFieldIx(Convert.ToInt32(pcw.Value));
                BindingOperations.GetBindingExpression(txt_subcasefield, TextBox.TextProperty).UpdateTarget();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
        }
    }
}
