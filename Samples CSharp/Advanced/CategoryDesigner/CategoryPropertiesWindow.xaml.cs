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
    public partial class CategoryPropertiesWindow : Window
    {
        private TheCategory _cat;
        public CategoryPropertiesWindow(TheCategory cat)
        {
            _cat = cat;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cmb_checkincommentsmode.ItemsSource = Enum.GetValues(typeof(TheCheckInCommentsMode));
                foreach(Object o in cmb_checkincommentsmode.ItemsSource)
                    if (Convert.ToString(o) == Convert.ToString(_cat.CheckInCommentsMode))
                        cmb_checkincommentsmode.SelectedItem = o;
                
                cmb_fulltextmode.ItemsSource = Enum.GetValues(typeof(TheFullTextMode));
                foreach (Object o in cmb_fulltextmode.ItemsSource)
                    if (Convert.ToString(o) == Convert.ToString(_cat.FullTextMode))
                        cmb_fulltextmode.SelectedItem = o;
                
                this.DataContext = _cat;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            _cat.CheckInCommentsMode = (TheCheckInCommentsMode)cmb_checkincommentsmode.SelectedItem;
            _cat.FullTextMode = (TheFullTextMode)cmb_fulltextmode.SelectedItem;
            this.Close();
        }

        private void btn_change_sub_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PropertyChangeWindow pcw = new PropertyChangeWindow("SubCategoryField");
                if(pcw.ShowDialog() == true)
                    _cat.SetSubCtgryFieldIx(Convert.ToInt32(pcw.Value));
                BindingOperations.GetBindingExpression(txt_subcategoryfield, TextBox.TextProperty).UpdateTarget();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_change_watermark_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PropertyChangeWindow pcw = new PropertyChangeWindow("WatermarkDocNo");
                if (pcw.ShowDialog() == true)
                {
                    TheServer server = new TheServer();
                    server.Connect();
                    _cat.SetWatermarkDocNo(Convert.ToInt32(pcw.Value),server);
                    BindingOperations.GetBindingExpression(txt_watermarkdocno, TextBox.TextProperty).UpdateTarget();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
    /*
    public class EnumEqualConverter : Collection<String>, IValueConverter 
    {

        Type type;

        IDictionary<Object, String> valueToNameMap;

        IDictionary<String, Object> nameToValueMap;

        public Type Type 
        {
            get { return this.type; }
            set
            {
                if (!value.IsEnum)
                    throw new ArgumentException("Type is not an enum.", "value");
                this.type = value;
                Initialize();
            }
        }

        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) 
        {
            return this.valueToNameMap[Enum.Parse(type, System.Convert.ToString(value))];
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) 
        {
            return this.nameToValueMap[(String)value];
        }

        void Initialize() 
        {
            this.valueToNameMap = new Dictionary<Object, String>();
            Array a = Enum.GetValues(type);
            foreach(Object o in a)
                valueToNameMap.Add(o, System.Convert.ToString(o));
            
            this.nameToValueMap = this.valueToNameMap
            .ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
            Clear();
            foreach (String name in this.nameToValueMap.Keys)
            Add(name);
        }

        static Object GetDescription(FieldInfo fieldInfo)
        {
            var descriptionAttribute =
            (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
            return descriptionAttribute != null ? descriptionAttribute.Description : fieldInfo.Name;
        }
    }*/
}
