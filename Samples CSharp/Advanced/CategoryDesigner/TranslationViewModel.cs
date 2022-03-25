using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Therefore.Samples
{
    public class TranslationViewModel : INotifyPropertyChanged
    {
        private EventDictionary<int, CultureInfo> _languages;
        private ObservableCollection<TranslationItem> _translationlist;

        public ObservableCollection<TranslationItem> Translations
        {
            get { return _translationlist; }
            set
            {
                if(_translationlist != value)
                {
                    _translationlist = value;
                    OnPropertyChanged("Translations");
                }
            }
        }
        
        public EventDictionary<int, CultureInfo> Languages
        {
            get
            {
                return _languages;
            }
        }

        public void UpdatedLanguages()
        {
            OnPropertyChanged("Languages");
        }
        
        public void SetTranslation(List<TranslationItem> translations, EventDictionary<int, CultureInfo> languages)
        {
            _translationlist = new ObservableCollection<TranslationItem>(translations);
            _languages = languages;
            _languages.DictionaryItemRemoved += OnLanguageRemoved;
        }

        private void OnLanguageRemoved(object sender, DictionaryRemoveItemEventArgs<int> e)
        {
            //this needs to be done to not recreate a deleted translation when saving the changes
            foreach (TranslationItem item in _translationlist)
                item.Translations.Remove(e.Key);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}