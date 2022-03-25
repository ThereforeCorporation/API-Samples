using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Therefore.API;

namespace Therefore.Samples
{
    public abstract class TranslationItem
    {
        public Dictionary<int, String> Translations
        {
            get;set;
        }

        public virtual String ItemType
        {
            get;
        }

        public abstract void SetTranslatedValues();
    }

    public class CategoryNameTranslationItem : TranslationItem
    {
        private TheCategory _category;

        public CategoryNameTranslationItem(TheCategory cat)
        {
            Translations = new Dictionary<int, string>();
            _category = cat;
            TheIntArray lcids = cat.GetAvailableLCIDs();
            foreach (int lcid in lcids)
                Translations.Add(lcid, cat.GetName(lcid));
        }

        public override String ItemType { get { return "Category Name"; } }

        public override void SetTranslatedValues()
        {
            foreach (int lcid in Translations.Keys)
            {
                if (Translations[lcid] == null)
                    throw new Exception(String.Format("Invalid category name for language {0}", CultureInfo.GetCultureInfo(lcid).Name));
                _category.SetName(lcid, Translations[lcid]);
            }
        }
    }

    public class CategoryDescriptionTranslationItem : TranslationItem
    {
        private TheCategory _category;

        public CategoryDescriptionTranslationItem(TheCategory cat)
        {
            Translations = new Dictionary<int, string>();
            _category = cat;
            TheIntArray lcids = cat.GetAvailableLCIDs();
            foreach (int lcid in lcids)
                Translations.Add(lcid, cat.GetDescription(lcid));
        }

        public override String ItemType { get { return "Category Description"; } }

        public override void SetTranslatedValues()
        {
            foreach (int lcid in Translations.Keys)
            {
                String description = "";
                if (Translations[lcid] != null)
                    description = Translations[lcid];
                _category.SetDescription(lcid, description);
            }
        }
    }

    public class CaseDefinitionNameTranslationItem : TranslationItem
    {
        private TheCaseDefinition _casedef;

        public CaseDefinitionNameTranslationItem(TheCaseDefinition casedef)
        {
            Translations = new Dictionary<int, string>();
            _casedef = casedef;
            TheIntArray lcids = casedef.GetAvailableLCIDs();
            foreach (int lcid in lcids)
                Translations.Add(lcid, casedef.GetName(lcid));
        }

        public override String ItemType { get { return "Case Definition Name"; } }

        public override void SetTranslatedValues()
        {
            foreach (int lcid in Translations.Keys)
            {
                if (Translations[lcid] == null)
                    throw new Exception(String.Format("Invalid case definition name for language {0}", CultureInfo.GetCultureInfo(lcid).Name));
                _casedef.SetName(lcid, Translations[lcid]);
            }
        }
    }

    public class CaseDefinitionDescriptionTranslationItem : TranslationItem
    {
        private TheCaseDefinition _casedef;

        public CaseDefinitionDescriptionTranslationItem(TheCaseDefinition casedef)
        {
            Translations = new Dictionary<int, string>();
            _casedef = casedef;
            TheIntArray lcids = casedef.GetAvailableLCIDs();
            foreach (int lcid in lcids)
                Translations.Add(lcid, casedef.GetDescription(lcid));
        }

        public override String ItemType { get { return "Case Definition Description"; } }

        public override void SetTranslatedValues()
        {
            foreach (int lcid in Translations.Keys)
            {
                String description = "";
                if (Translations[lcid] != null)
                    description = Translations[lcid];
                _casedef.SetDescription(lcid, description);
            }
        }
    }

    public class CategoryFieldTranslationItem : TranslationItem
    {
        private TheCategoryField _field;

        public CategoryFieldTranslationItem(TheCategoryField field)
        {
            Translations = new Dictionary<int, string>();
            _field = field;
        }
        
        public override String ItemType { get { return _field.FieldType.ToString() + " (" + _field.FieldNo.ToString() + ")"; } }

        public override void SetTranslatedValues()
        {
            foreach (int lcid in Translations.Keys)
            {
                if (Translations[lcid] == null)
                    throw new Exception(String.Format("Invalid caption for field {0} language {1}", _field.FieldNo, CultureInfo.GetCultureInfo(lcid).Name));
                _field.SetCaption(lcid, Translations[lcid]);
            }
        }
    }

    public class TabInfoTranslationItem : TranslationItem
    {
        private TheTabInfo _tabinfo;
        private int _fieldno;

        public TabInfoTranslationItem(TheTabInfo tabinfo, int fieldno)
        {
            Translations = new Dictionary<int, string>();
            _tabinfo = tabinfo;
            _fieldno = fieldno;
        }

        public override String ItemType { get { return "TabControlField " + _fieldno + " Tab " + _tabinfo.TabNo.ToString(); } }

        public override void SetTranslatedValues()
        {
            foreach (int lcid in Translations.Keys)
            {
                if (Translations[lcid] == null)
                    throw new Exception(String.Format("Invalid caption for tab {0} of field {1} language {2}", _tabinfo.TabNo, _fieldno, CultureInfo.GetCultureInfo(lcid).Name));
                _tabinfo.SetCaption(lcid, Translations[lcid]);
            }
        }
    }
}
