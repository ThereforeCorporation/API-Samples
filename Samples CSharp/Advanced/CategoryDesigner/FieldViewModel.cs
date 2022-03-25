using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using Therefore.API;

namespace Therefore.Samples
{
    public class FieldViewModel : INotifyPropertyChanged
    {
        protected ICollectionView _filteredFields;
        protected TheCategoryFieldType _fieldType;
        protected TheFilterType _fieldType_filterType;
        protected SortedList<int, CultureInfo> _languages;

        protected FieldViewModel()
        {
            _languages = null;
        }

        virtual public void UpdateFieldList() { throw new NotImplementedException(); }
        public List<CultureInfo> Languages
        {
            get { return _languages.Values.ToList(); }
        }

        virtual public CultureInfo CurrentLanguage { get; set; }

        public ICollectionView VisibleFields
        {
            get
            {
                return _filteredFields;
            }
        }

        public TheCategoryFieldType FilterFieldType
        {
            set
            {
                _fieldType = value;
                _filteredFields.Refresh();
            }
            get { return _fieldType; }
        }

        public TheFilterType FilterTypeFieldType
        {
            set
            {
                _fieldType_filterType = value;
                _filteredFields.Refresh();
            }
            get { return _fieldType_filterType; }
        }

        protected bool FieldFilter(object item)
        {
            TheCategoryField field = (TheCategoryField)item;
            if (_fieldType == 0)
                return true;
            if (_fieldType_filterType == TheFilterType.FilterNothing)
                return true;
            if (_fieldType_filterType == TheFilterType.FilterOnlyBy && field.FieldType == _fieldType)
                return true;
            if (_fieldType_filterType == TheFilterType.FilterExclude && field.FieldType != _fieldType)
                return true;
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
