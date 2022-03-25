using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Therefore.API;
using System.Windows.Data;
using System.Globalization;

namespace Therefore.Samples
{
    public class CategoryFieldViewModel : FieldViewModel
    {
        private TheCategory _category;

        public CategoryFieldViewModel(TheCategory cat) : base()
        {
            _category = cat;
            UpdateFieldList();
            UpdateLanguages();
            CurrentLanguage = CultureInfo.CurrentCulture;
        }

        override public void UpdateFieldList()
        {
            List<TheCategoryField> fields = new List<TheCategoryField>();
            for (int i = 0; i < _category.FieldCount; i++ )
                fields.Add(_category.GetFieldByIndex(i));
            _filteredFields = CollectionViewSource.GetDefaultView(fields);
            _filteredFields.Filter = new Predicate<object>(FieldFilter);
            OnPropertyChanged("VisibleFields");
        }
        override public CultureInfo CurrentLanguage
        {
            get
            {
                if (_languages.ContainsKey(_category.GetCurrentLCID()))
                    return _languages[_category.GetCurrentLCID()];
                return _languages.Values[0];
            }

            set
            {
                _category.SetCurrentLCID(value.LCID);
            }
        }

        public void UpdateLanguages()
        {
            _languages = new SortedList<int, CultureInfo>();
            TheIntArray lcids = _category.GetAvailableLCIDs();
            foreach(int lcid in lcids)
                _languages.Add(lcid, new CultureInfo(lcid));
        }
        
        public TheCategory Category
        {
            get { return _category; }
        }
    }
}
