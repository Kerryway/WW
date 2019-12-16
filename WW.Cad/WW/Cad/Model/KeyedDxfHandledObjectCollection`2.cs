namespace WW.Cad.Model
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public abstract class KeyedDxfHandledObjectCollection<TKey, TItem> : 
        IList<TItem>, 
        ICollection<TItem>, 
        IEnumerable<TItem>, 
        ICollection, 
        IEnumerable 
        where TItem : DxfHandledObject
    {
        private KeyedDxfHandledObjectCollection<TKey, TItem> Collections;

        protected KeyedDxfHandledObjectCollection()
        {
            this.class21_0 = new Class21<TKey, TItem>((KeyedDxfHandledObjectCollection<TKey, TItem>)this);
        }

        protected KeyedDxfHandledObjectCollection(IEqualityComparer<TKey> comparer)
        {
            this.class21_0 = new Class21<TKey, TItem>(comparer, (KeyedDxfHandledObjectCollection<TKey, TItem>)this);
        }

        protected KeyedDxfHandledObjectCollection(IEqualityComparer<TKey> comparer, int dictionaryCreationThreshold)
        {
            this.class21_0 = new Class21<TKey, TItem>(comparer, dictionaryCreationThreshold, (KeyedDxfHandledObjectCollection<TKey, TItem>)this);
        }

        public void Add(TItem item)
        {
            this.class21_0.Add((item == null) ? DxfObjectReference.Null : item.Reference);
        }

        public void Clear()
        {
            this.class21_0.Clear();
        }

        public bool Contains(TItem item) =>
            this.class21_0.Contains(item.Reference);

        public bool Contains(TKey key) =>
            this.class21_0.Contains(key);

        public void CopyTo(TItem[] array, int arrayIndex)
        {
            int count = this.class21_0.Count;
            int num2 = 0;
            while (num2 < count)
            {
                array[arrayIndex] = (TItem)this.class21_0[num2].Value;
                num2++;
                arrayIndex++;
            }
        }

        public IEnumerator<TItem> GetEnumerator() =>
            new Class22<TKey, TItem>(this.class21_0.GetEnumerator());

        protected abstract TKey GetKeyForItem(TItem item);
        public int IndexOf(TItem item) =>
            this.class21_0.IndexOf(item.Reference);

        public void Insert(int index, TItem item)
        {
            this.class21_0.Insert(index, (item == null) ? DxfObjectReference.Null : item.Reference);
        }

        protected virtual void OnInserted(int index, TItem item)
        {
        }

        protected virtual void OnRemoved(int index, TItem item)
        {
        }

        protected virtual void OnSet(int index, TItem oldItem, TItem newItem)
        {
        }

        public bool Remove(TItem item) =>
            this.class21_0.Remove(item.Reference);

        public bool Remove(TKey key) =>
            this.class21_0.Remove(key);

        public void RemoveAt(int index)
        {
            this.class21_0.RemoveAt(index);
        }

        void ICollection.CopyTo(Array array, int index)
        {
            for (int i = 0; i < this.class21_0.Count; i++)
            {
                array.SetValue(this.class21_0[i].Value, index);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            new Class22<TKey, TItem>(this.class21_0.GetEnumerator());

        public bool TryGetValue(TKey key, out TItem item)
        {
            if (!this.Contains(key))
            {
                item = default(TItem);
                return false;
            }
            item = (TItem)this.class21_0[key].Value;
            return true;
        }

        public TItem this[int index]
        {
            get =>
                ((TItem)this.class21_0[index].Value);
            set =>
                (this.class21_0[index] = DxfObjectReference.GetReference(value));
        }

        public TItem this[TKey key] =>
            ((TItem)this.class21_0[key].Value);

        public ICollection<TKey> Keys =>
            this.class21_0.Keys;

        public int Count =>
            this.class21_0.Count;

        public bool IsReadOnly =>
            false;

        int ICollection.Count =>
            this.class21_0.Count;

        bool ICollection.IsSynchronized =>
            this.class21_0.IsSynchronized;

        object ICollection.SyncRoot =>
            this.class21_0.SyncRoot;

        private class Class21 : KeyedCollection<T, DxfObjectReference>
        {
            private KeyedDxfHandledObjectCollection<T, U> keyedDxfHandledObjectCollection_0;

            public Class21(KeyedDxfHandledObjectCollection<T, U> collectionWrapper)
            {
                this.keyedDxfHandledObjectCollection_0 = collectionWrapper;
            }

            public Class21(IEqualityComparer<T> comparer, KeyedDxfHandledObjectCollection<T, U> collectionWrapper) : base(comparer)
            {
                this.keyedDxfHandledObjectCollection_0 = collectionWrapper;
            }

            public Class21(IEqualityComparer<T> comparer, int dictionaryCreationThreshold, KeyedDxfHandledObjectCollection<T, U> collectionWrapper) : base(comparer, dictionaryCreationThreshold)
            {
                this.keyedDxfHandledObjectCollection_0 = collectionWrapper;
            }

            protected override void ClearItems()
            {
                for (int i = base.Count - 1; i >= 0; i--)
                {
                    this.RemoveItem(i);
                }
            }
            -
            +\
keyedDxfHandledObjectCollection.0-+            \\
                try
                {
                    base.InsertItem(index, item);
                }
                catch (ArgumentException)
                {
                    object[] objArray = new object[] { "An item of type ", typeof(U), " with the same key ", this.GetKeyForItem(item), " has already been added." };
                    throw new ArgumentException(string.Concat(objArray));
                }
                this.keyedDxfHandledObjectCollection_0.OnInserted(index, (U)item.Value);
            }

            protected override void RemoveItem(int index)
            {
                DxfObjectReference reference = base[index];
                base.RemoveItem(index);
                this.keyedDxfHandledObjectCollection_0.OnRemoved(index, (U)reference.Value);
            }

            protected override void SetItem(int index, DxfObjectReference item)
            {
                DxfObjectReference reference = base[index];
                base.SetItem(index, item);
                this.keyedDxfHandledObjectCollection_0.OnSet(index, (U)reference.Value, (U)item.Value);
            }

            public ICollection<T> Keys =>
                base.Dictionary.Keys;
        }+



















        private class Class22 : IEnumerator<U>, IDisposable, IEnumerator
        {
            private IEnumerator<DxfObjectReference> ienumerator_0;

            public Class22(IEnumerator<DxfObjectReference> enumerator)
            {
                this.ienumerator_0 = enumerator;
            }

            public void Dispose()
            {
                this.ienumerator_0.Dispose();
            }

            public bool MoveNext() =>
                this.ienumerator_0.MoveNext();

            public void Reset()
            {
                this.ienumerator_0.Reset();
            }

            public U Current =>
                ((U)this.ienumerator_0.Current.Value);

            object IEnumerator.Current =>
                this.ienumerator_0.Current.Value;
        }
    }
}
