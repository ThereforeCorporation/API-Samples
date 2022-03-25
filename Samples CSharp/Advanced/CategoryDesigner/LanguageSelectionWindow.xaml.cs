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
using System.Windows.Shapes;

namespace Therefore.Samples
{
    /// <summary>
    /// Interaction logic for LanguageSelectionWindow.xaml
    /// </summary>
    public partial class LanguageSelectionWindow : Window
    {
        private IEnumerable<CultureInfo> _languages;
        public CultureInfo SelectedLanguage { get; private set; }
        public LanguageSelectionWindow(IEnumerable<CultureInfo> languages)
        {
            _languages = languages;
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CultureInfo selected = (CultureInfo)cmb_languages.SelectedItem;
                if (selected == null)
                    throw new Exception("No language has been selected.");
                SelectedLanguage = selected;
                this.DialogResult = true;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cmb_languages.ItemsSource = _languages;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }


    //these languages are supported by Therefore
    enum ValidLanguages
    {
        Arabic = 1025,
        English = 1033,
        Finnish = 1035,
        French = 1036,
        German = 1031,
        Italian = 1040,
        Portuguese = 2070,
        Spanish = 1034,
        Swedish = 1053,
        Danish = 1030,
        Norwegian = 1044,
        Dutch = 1043,
        Hungarian = 1038,
        Slovenian = 1060,
        Croatian = 1050,
        Czech = 1029,
        Polish = 1045,
        Turkish = 1055,
        Russian = 1049,
        Serbian_Latin = 2074,
        Japanese = 1041,
        Chinese_Simple = 2052,
        Chinese_Traditional = 1028,
        Korean = 1042,
        Brazilian = 1046,
        Bulgarian = 1026,
    }
}
