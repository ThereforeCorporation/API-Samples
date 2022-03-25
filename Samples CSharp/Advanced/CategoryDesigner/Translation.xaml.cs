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
using Therefore.API;

namespace Therefore.Samples
{
    /// <summary>
    /// Interaction logic for Translation.xaml
    /// </summary>
    public partial class Translation : Window
    {
        private TranslationViewModel _translationviewmodel;
        private TheCategory _cat;
        private TheCaseDefinition _casedef;
        public Translation(TheCategory cat)
        {
            _cat = cat;
            _casedef = null;
            InitializeComponent();
        }
        public Translation(TheCaseDefinition casedef)
        {
            _cat = null;
            _casedef = casedef;
            InitializeComponent();
        }

        private void InitializeCategory(TheCategory cat)
        {
            List<TranslationItem> translations = new List<TranslationItem>();
            EventDictionary<int, CultureInfo> languages = new EventDictionary<int, CultureInfo>();
            TheIntArray lcids = cat.GetAvailableLCIDs();
            foreach (int lcid in lcids)
                languages.Add(lcid, new CultureInfo(lcid));
            AddColumns(languages);
            translations.Add(new CategoryNameTranslationItem(cat));
            translations.Add(new CategoryDescriptionTranslationItem(cat));
            for (int i = 0; i < cat.FieldCount; i++)
            {
                TheCategoryField field = cat.GetFieldByIndex(i);
                if(!field.IsSingleKeyword)//keyword id fields are not translated
                    translations.Add(InitializeField(field, lcids));
                if (field.FieldType == TheCategoryFieldType.TabControlField)
                    foreach (TheTabInfo tab in field.Tabs)
                        translations.Add(InitializeTab(tab, field.FieldNo, lcids));
            }
            _translationviewmodel.SetTranslation(translations, languages);
        }

        private void InitializeCaseDefinition(TheCaseDefinition casedef)
        {
            List<TranslationItem> translations = new List<TranslationItem>();
            EventDictionary<int, CultureInfo> languages = new EventDictionary<int, CultureInfo>();
            TheIntArray lcids = casedef.GetAvailableLCIDs();
            foreach (int lcid in lcids)
                languages.Add(lcid, new CultureInfo(lcid));
            AddColumns(languages);
            translations.Add(new CaseDefinitionNameTranslationItem(casedef));
            translations.Add(new CaseDefinitionDescriptionTranslationItem(casedef));
            for(int i = 0; i < casedef.FieldCount; i++)
            {
                TheCategoryField field = casedef.GetFieldByIndex(i);
                if (!field.IsSingleKeyword)//keyword id fields are not translated
                    translations.Add(InitializeField(field, lcids));
                if (field.FieldType == TheCategoryFieldType.TabControlField)
                    foreach (TheTabInfo tab in field.Tabs)
                        translations.Add(InitializeTab(tab, field.FieldNo, lcids));
            }
            _translationviewmodel.SetTranslation(translations, languages);
        }

        private TranslationItem InitializeField(TheCategoryField field, TheIntArray lcids)
        {
            CategoryFieldTranslationItem fielditem = new CategoryFieldTranslationItem(field);
            
            int originalLCID = field.GetCurrentLCID();
            foreach (int lcid in lcids)
            {
                field.SetCurrentLCID(lcid);
                if (field.GetCurrentLCID() != lcid)//field caption is not present in this language
                    continue;
                fielditem.Translations.Add(lcid, field.GetCaption(lcid));
            }
            field.SetCurrentLCID(originalLCID);
            return fielditem;
        }

        private TranslationItem InitializeTab(TheTabInfo tab, int fieldno, TheIntArray lcids)
        {
            TabInfoTranslationItem fielditem = new TabInfoTranslationItem(tab, fieldno);
            int originalLCID = tab.GetCurrentLCID();
            foreach (int lcid in lcids)
            {
                tab.SetCurrentLCID(lcid);
                if (tab.GetCurrentLCID() != lcid)//tab caption is not present in this language
                    continue;
                fielditem.Translations.Add(lcid, tab.GetCaption(lcid));
            }
            tab.SetCurrentLCID(originalLCID);
            return fielditem;
        }

        private void dg_translation_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _translationviewmodel = new TranslationViewModel();
                if (_cat != null)
                    InitializeCategory(_cat);
                else if (_casedef != null)
                    InitializeCaseDefinition(_casedef);
                else
                    throw new Exception("Invalid category or case definition.");
                dg_translation.DataContext = _translationviewmodel;
                _translationviewmodel.Languages.DictionaryItemAdded += OnNewLanguage;
                _translationviewmodel.Languages.DictionaryItemRemoved += OnLanguageRemoved; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddColumns(Dictionary<int, CultureInfo> newColumns)
        {
            foreach (int lcid in newColumns.Keys)
                AddColumn(newColumns[lcid]);            
        }

        private void AddColumn(CultureInfo newColumn)
        {
            dg_translation.Columns.Add(new DataGridTextColumn
            {
                // bind to a dictionary property
                Binding = new Binding("Translations[" + newColumn.LCID + "]"),
                Header = newColumn.Name
            });
        }

        private void RemoveColumn(int lcid)
        {
            CultureInfo lang = CultureInfo.GetCultureInfo(lcid);
            DataGridColumn toremove = null;
            foreach(DataGridColumn col in dg_translation.Columns)
            {
                if(lang.Name == (String)col.Header)
                {
                    toremove = col;
                    break;
                }
            }
            if (toremove != null)
                dg_translation.Columns.Remove(toremove);
            else
                MessageBox.Show("Language column not found in data grid.");
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                TheIntArray removelanguages = null;
                if (_cat != null)
                    removelanguages = _cat.GetAvailableLCIDs();
                else if (_casedef != null)
                    removelanguages = _casedef.GetAvailableLCIDs();
                else
                    throw new Exception("Invalid category or case definition.");
                //search for all languages not in the viewmodel
                for (int i = 0; i < removelanguages.Count; i++)
                {
                    if (_translationviewmodel.Languages.ContainsKey(removelanguages[i]))
                    {
                        removelanguages.Remove(i);
                        i--;
                    }
                }
                //and delete all languages that are not in the viewmodel
                foreach(int lcid in removelanguages)
                {
                    if (_cat != null)
                        _cat.DeleteTranslation(lcid);
                    else if (_casedef != null)
                        _casedef.DeleteTranslation(lcid);
                }

                foreach (TranslationItem item in _translationviewmodel.Translations)
                    item.SetTranslatedValues();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_addlang_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<int> validlcids = Enum.GetValues(typeof(ValidLanguages)).Cast<int>().ToList();
                foreach (int lcid in _translationviewmodel.Languages.Keys)
                    validlcids.Remove(lcid);
                List<CultureInfo> languages = new List<CultureInfo>();
                foreach (int lcid in validlcids)
                    languages.Add(new CultureInfo(lcid));
                
                LanguageSelectionWindow addlangdlg = new LanguageSelectionWindow(languages);
                if (addlangdlg.ShowDialog() == true)
                    _translationviewmodel.Languages.Add(addlangdlg.SelectedLanguage.LCID, addlangdlg.SelectedLanguage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_deletelang_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LanguageSelectionWindow removelangdlg = new LanguageSelectionWindow(_translationviewmodel.Languages.Values);
                if (removelangdlg.ShowDialog() == true)
                { 
                    _translationviewmodel.Languages.Remove(removelangdlg.SelectedLanguage.LCID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnNewLanguage(object sender, DictionaryAddItemEventArgs<int, CultureInfo> e)
        {
            AddColumn(e.Value);
            _translationviewmodel.UpdatedLanguages();
        }

        public void OnLanguageRemoved(object sender, DictionaryRemoveItemEventArgs<int> e)
        {
            RemoveColumn(e.Key);
            _translationviewmodel.UpdatedLanguages();
        }
    }
}