using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Therefore.API;

namespace Therefore.Samples
{
    public class CaseDefFieldViewModel : FieldViewModel
    {
        private TheCaseDefinition _casedef;

        public CaseDefFieldViewModel(TheCaseDefinition cat) : base()
        {
            _casedef = cat;
            UpdateFieldList();
            UpdateLanguages();
        }

        override public void UpdateFieldList()
        {
            List<TheCategoryField> fields = new List<TheCategoryField>();
            for (int i = 0; i < _casedef.FieldCount; i++ )
                fields.Add(_casedef.GetFieldByIndex(i));
            _filteredFields = CollectionViewSource.GetDefaultView(fields);
            _filteredFields.Filter = new Predicate<object>(FieldFilter);
            OnPropertyChanged("VisibleFields");
        }

        override public CultureInfo CurrentLanguage
        {
            get
            {
                if (_languages.ContainsKey(_casedef.GetCurrentLCID())) 
                    return _languages[_casedef.GetCurrentLCID()];
                return _languages.Values[0];
            }

            set
            {
                _casedef.SetCurrentLCID(value.LCID);
            }
        }

        public void UpdateLanguages()
        {
            _languages = new SortedList<int, CultureInfo>();
            TheIntArray lcids = _casedef.GetAvailableLCIDs();
            foreach (int lcid in lcids)
                _languages.Add(lcid, new CultureInfo(lcid));
        }

        public TheCaseDefinition CaseDefinition
        {
            get { return _casedef; }
        }
    }
}
