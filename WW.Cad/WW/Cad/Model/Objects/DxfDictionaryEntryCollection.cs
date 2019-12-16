// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfDictionaryEntryCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections;
using System.Collections.Generic;
using WW.Collections.Generic;

namespace WW.Cad.Model.Objects
{
  public class DxfDictionaryEntryCollection : ActiveList<IDictionaryEntry>
  {
    private Dictionary<string, List<IDictionaryEntry>> dictionary_0 = new Dictionary<string, List<IDictionaryEntry>>((IEqualityComparer<string>) StringComparer.InvariantCultureIgnoreCase);
    private const bool bool_0 = true;
    private bool bool_1;

    public bool Contains(string entryName)
    {
      return this.dictionary_0.ContainsKey(entryName.ToLowerInvariant());
    }

    public DxfDictionaryEntryCollection GetAll(string entryName)
    {
      DxfDictionaryEntryCollection dictionaryEntryCollection = new DxfDictionaryEntryCollection();
      IList<IDictionaryEntry> dictionaryEntryList = this.method_1(entryName);
      if (dictionaryEntryList != null)
      {
        if (dictionaryEntryList.Count == 1)
        {
          dictionaryEntryCollection.Add(dictionaryEntryList[0]);
        }
        else
        {
          foreach (IDictionaryEntry dictionaryEntry in (ActiveList<IDictionaryEntry>) this)
          {
            if (dictionaryEntry != null && string.Compare(entryName, dictionaryEntry.Name, StringComparison.InvariantCultureIgnoreCase) == 0)
              dictionaryEntryCollection.Add(dictionaryEntry);
          }
        }
      }
      return dictionaryEntryCollection;
    }

    public IDictionaryEntry GetFirst(string entryName)
    {
      IList<IDictionaryEntry> dictionaryEntryList = this.method_1(entryName);
      if (dictionaryEntryList != null)
      {
        if (dictionaryEntryList.Count == 1)
          return dictionaryEntryList[0];
        foreach (IDictionaryEntry dictionaryEntry in (ActiveList<IDictionaryEntry>) this)
        {
          if (dictionaryEntry != null && string.Compare(entryName, dictionaryEntry.Name, StringComparison.InvariantCultureIgnoreCase) == 0)
            return dictionaryEntry;
        }
      }
      return (IDictionaryEntry) null;
    }

    public DxfObject GetFirstValue(string entryName)
    {
      return this.GetFirst(entryName)?.Value;
    }

    public bool RemoveAll(string entryName)
    {
      if (this.method_1(entryName) == null)
        return false;
      for (int index = this.Count - 1; index >= 0; --index)
      {
        IDictionaryEntry dictionaryEntry = this[index];
        if (dictionaryEntry != null && string.Compare(entryName, dictionaryEntry.Name, StringComparison.InvariantCultureIgnoreCase) == 0)
          this.RemoveAt(index);
      }
      return true;
    }

    internal void method_0()
    {
      List<IDictionaryEntry> dictionaryEntryList1 = new List<IDictionaryEntry>((IEnumerable<IDictionaryEntry>) this);
      this.bool_1 = true;
      this.Clear();
      foreach (IDictionaryEntry dictionaryEntry in dictionaryEntryList1)
      {
        if (dictionaryEntry.Value != null)
        {
          this.Add(dictionaryEntry);
        }
        else
        {
          List<IDictionaryEntry> dictionaryEntryList2;
          if (this.dictionary_0.TryGetValue(dictionaryEntry.Name, out dictionaryEntryList2))
            dictionaryEntryList2.Remove(dictionaryEntry);
        }
      }
      this.bool_1 = false;
    }

    protected override void OnSet(int index, IDictionaryEntry oldItem, IDictionaryEntry newItem)
    {
      if (this.bool_1)
        return;
      this.method_3(oldItem);
      this.method_2(newItem);
      base.OnSet(index, oldItem, newItem);
    }

    protected override void OnAdded(int index, IDictionaryEntry item)
    {
      if (this.bool_1)
        return;
      this.method_2(item);
      base.OnAdded(index, item);
    }

    protected override void OnRemoved(int index, IDictionaryEntry item)
    {
      if (this.bool_1)
        return;
      this.method_3(item);
      base.OnRemoved(index, item);
    }

    private IList<IDictionaryEntry> method_1(string name)
    {
      List<IDictionaryEntry> dictionaryEntryList;
      this.dictionary_0.TryGetValue(name, out dictionaryEntryList);
      return (IList<IDictionaryEntry>) dictionaryEntryList;
    }

    private void method_2(IDictionaryEntry entry)
    {
      if (entry == null)
        return;
      string key = entry.Name;
      if (key == "" || key.StartsWith("*"))
      {
        int count = this.Count;
        do
        {
          key = string.Format("*a{0}", (object) count);
          ++count;
        }
        while (this.dictionary_0.ContainsKey(key));
        entry.Name = key;
      }
      List<IDictionaryEntry> dictionaryEntryList;
      if (!this.dictionary_0.TryGetValue(key, out dictionaryEntryList))
      {
        dictionaryEntryList = new List<IDictionaryEntry>(1);
        this.dictionary_0[key] = dictionaryEntryList;
      }
      dictionaryEntryList.Add(entry);
    }

    private void method_3(IDictionaryEntry entry)
    {
      if (entry == null)
        return;
      string name = entry.Name;
      List<IDictionaryEntry> dictionaryEntryList;
      if (!this.dictionary_0.TryGetValue(name, out dictionaryEntryList))
        return;
      dictionaryEntryList.Remove(entry);
      if (dictionaryEntryList.Count != 0)
        return;
      this.dictionary_0.Remove(name);
    }

    public class TypedWrapper<T> : IList<KeyValuePair<string, T>>, ICollection<KeyValuePair<string, T>>, IEnumerable<KeyValuePair<string, T>>, IEnumerable
      where T : DxfObject
    {
      private readonly DxfDictionaryEntryCollection dxfDictionaryEntryCollection_0;

      public TypedWrapper(DxfDictionaryEntryCollection wrappedEntries)
      {
        this.dxfDictionaryEntryCollection_0 = wrappedEntries;
      }

      public T GetFirstValue(string entryName)
      {
        return (T) this.dxfDictionaryEntryCollection_0.GetFirstValue(entryName);
      }

      public void Add(string name, T value)
      {
        this.dxfDictionaryEntryCollection_0.Add((IDictionaryEntry) new DxfDictionaryEntry(name, (DxfObject) value));
      }

      public int IndexOf(KeyValuePair<string, T> item)
      {
        for (int index = 0; index < this.dxfDictionaryEntryCollection_0.Count; ++index)
        {
          IDictionaryEntry dictionaryEntry = this.dxfDictionaryEntryCollection_0[index];
          if (dictionaryEntry.Value == (object) item.Value && string.Compare(dictionaryEntry.Name, item.Key, StringComparison.InvariantCultureIgnoreCase) == 0)
            return index;
        }
        return -1;
      }

      public void Insert(int index, KeyValuePair<string, T> item)
      {
        this.dxfDictionaryEntryCollection_0.Insert(index, (IDictionaryEntry) new DxfDictionaryEntry(item.Key, (DxfObject) item.Value));
      }

      public void RemoveAt(int index)
      {
        this.dxfDictionaryEntryCollection_0.RemoveAt(index);
      }

      public KeyValuePair<string, T> this[int index]
      {
        get
        {
          throw new NotImplementedException();
        }
        set
        {
          throw new NotImplementedException();
        }
      }

      public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
      {
        return (IEnumerator<KeyValuePair<string, T>>) new DxfDictionaryEntryCollection.TypedWrapper<T>.Enumerator(this.dxfDictionaryEntryCollection_0.GetEnumerator());
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
        return (IEnumerator) new DxfDictionaryEntryCollection.TypedWrapper<T>.Enumerator(this.dxfDictionaryEntryCollection_0.GetEnumerator());
      }

      public void Add(KeyValuePair<string, T> item)
      {
        this.dxfDictionaryEntryCollection_0.Add((IDictionaryEntry) new DxfDictionaryEntry(item.Key, (DxfObject) item.Value));
      }

      public void Clear()
      {
        this.dxfDictionaryEntryCollection_0.Clear();
      }

      public bool Contains(KeyValuePair<string, T> item)
      {
        for (int index = 0; index < this.dxfDictionaryEntryCollection_0.Count; ++index)
        {
          IDictionaryEntry dictionaryEntry = this.dxfDictionaryEntryCollection_0[index];
          if (dictionaryEntry.Value == (object) item.Value && string.Compare(dictionaryEntry.Name, item.Key, StringComparison.InvariantCultureIgnoreCase) == 0)
            return true;
        }
        return false;
      }

      public void CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
      {
        for (int index = 0; index < this.dxfDictionaryEntryCollection_0.Count; ++index)
        {
          IDictionaryEntry dictionaryEntry = this.dxfDictionaryEntryCollection_0[index];
          array[arrayIndex++] = new KeyValuePair<string, T>(dictionaryEntry.Name, (T) dictionaryEntry.Value);
        }
      }

      public int Count
      {
        get
        {
          return this.dxfDictionaryEntryCollection_0.Count;
        }
      }

      public bool IsReadOnly
      {
        get
        {
          return this.dxfDictionaryEntryCollection_0.IsReadOnly;
        }
      }

      public bool Remove(KeyValuePair<string, T> item)
      {
        for (int index = 0; index < this.dxfDictionaryEntryCollection_0.Count; ++index)
        {
          IDictionaryEntry dictionaryEntry = this.dxfDictionaryEntryCollection_0[index];
          if (dictionaryEntry.Value == (object) item.Value && string.Compare(dictionaryEntry.Name, item.Key, StringComparison.InvariantCultureIgnoreCase) == 0)
          {
            this.dxfDictionaryEntryCollection_0.RemoveAt(index);
            return true;
          }
        }
        return false;
      }

      public class Enumerator : IDisposable, IEnumerator<KeyValuePair<string, T>>, IEnumerator
      {
        private IEnumerator<IDictionaryEntry> ienumerator_0;

        public Enumerator(IEnumerator<IDictionaryEntry> wrappedEnumerator)
        {
          this.ienumerator_0 = wrappedEnumerator;
        }

        public KeyValuePair<string, T> Current
        {
          get
          {
            return new KeyValuePair<string, T>(this.ienumerator_0.Current.Name, (T) this.ienumerator_0.Current.Value);
          }
        }

        public void Dispose()
        {
          this.ienumerator_0.Dispose();
        }

        object IEnumerator.Current
        {
          get
          {
            return this.ienumerator_0.Current;
          }
        }

        public bool MoveNext()
        {
          return this.ienumerator_0.MoveNext();
        }

        public void Reset()
        {
          this.ienumerator_0.Reset();
        }
      }
    }
  }
}
