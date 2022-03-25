using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Therefore.Samples
{
    public class EventDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public event DictionaryItemAddedEventHandler DictionaryItemAdded;
        public delegate void DictionaryItemAddedEventHandler(object sender, DictionaryAddItemEventArgs<TKey, TValue> e);

        public event DictionaryItemRemovedEventHandler DictionaryItemRemoved;
        public delegate void DictionaryItemRemovedEventHandler(object sender, DictionaryRemoveItemEventArgs<TKey> e);

        public event DictionaryClearedEventHandler DictionaryCleared;
        public delegate void DictionaryClearedEventHandler(object sender, EventArgs e);

        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            if (this.DictionaryItemAdded != null)
                this.DictionaryItemAdded(this, new DictionaryAddItemEventArgs<TKey, TValue>(key, value));
        }

        public new void Clear()
        {
            base.Clear();
            if (this.DictionaryCleared != null)
                this.DictionaryCleared(this, new EventArgs());
        }

        public new bool Remove(TKey key)
        {
            bool ret = base.Remove(key);
            if (this.DictionaryItemRemoved != null)
                this.DictionaryItemRemoved(this, new DictionaryRemoveItemEventArgs<TKey>(key));
            return ret;
        }
    }

    public class DictionaryAddItemEventArgs<TKey, TValue> : EventArgs
    {
        public TKey Key { get; private set; }
        public TValue Value { get; private set; }
        public DictionaryAddItemEventArgs(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

    public class DictionaryRemoveItemEventArgs<TKey> : EventArgs
    {
        public TKey Key { get; private set; }
        public DictionaryRemoveItemEventArgs(TKey key)
        {
            Key = key;
        }
    }
}
