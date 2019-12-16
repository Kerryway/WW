// Decompiled with JetBrains decompiler
// Type: WW.Collections.Generic.ActiveLookupList`2
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections;
using System.Collections.Generic;

namespace WW.Collections.Generic
{
  public abstract class ActiveLookupList<TKey, TItem> : IEnumerable, IList<TItem>, ICollection<TItem>, IEnumerable<TItem>
    where TItem : IEquatable<TItem>
  {
    private readonly List<TItem> list_0 = new List<TItem>();
    private readonly Dictionary<TKey, List<TItem>> dictionary_0;

    public event ItemSetEventHandler<TItem> Setting;

    public event ItemSetEventHandler<TItem> Set;

    public event ItemEventHandler<TItem> Adding;

    public event ItemEventHandler<TItem> Added;

    public event ItemEventHandler<TItem> Removing;

    public event ItemEventHandler<TItem> Removed;

    protected ActiveLookupList()
    {
      this.dictionary_0 = new Dictionary<TKey, List<TItem>>();
    }

    protected ActiveLookupList(IEqualityComparer<TKey> keyEqualityComparer)
    {
      this.dictionary_0 = new Dictionary<TKey, List<TItem>>(keyEqualityComparer);
    }

    public int IndexOf(TItem item)
    {
      return this.list_0.IndexOf(item);
    }

    public void Insert(int index, TItem item)
    {
      this.OnAdding(index, item);
      this.list_0.Insert(index, item);
      this.method_0(item, index);
      this.OnAdded(index, item);
    }

    public void RemoveAt(int index)
    {
      if (index < 0 || index >= this.list_0.Count)
        throw new ArgumentOutOfRangeException();
      TItem obj = this.list_0[index];
      this.OnRemoving(index, obj);
      this.method_1(obj);
      this.list_0.RemoveAt(index);
      this.OnRemoved(index, obj);
    }

    public TItem this[int index]
    {
      get
      {
        return this.list_0[index];
      }
      set
      {
        TItem oldItem = this.list_0[index];
        this.OnSetting(index, oldItem, value);
        this.method_1(oldItem);
        this.list_0[index] = value;
        this.method_0(value, index);
        this.OnSet(index, oldItem, value);
      }
    }

    public void Add(TItem item)
    {
      int count = this.list_0.Count;
      this.OnAdding(count, item);
      this.list_0.Add(item);
      this.method_0(item, count);
      this.OnAdded(count, item);
    }

    public void Clear()
    {
      for (int index = this.list_0.Count - 1; index >= 0; --index)
        this.RemoveAt(index);
    }

    public bool Contains(TItem item)
    {
      TKey keyForItem = this.GetKeyForItem(item);
      bool flag = false;
      List<TItem> objList;
      if (this.dictionary_0.TryGetValue(keyForItem, out objList))
        flag = objList.Contains(item);
      return flag;
    }

    public void CopyTo(TItem[] array, int arrayIndex)
    {
      this.list_0.CopyTo(array, arrayIndex);
    }

    public int Count
    {
      get
      {
        return this.list_0.Count;
      }
    }

    public bool IsReadOnly
    {
      get
      {
        return false;
      }
    }

    public bool Remove(TItem item)
    {
      int index = this.list_0.IndexOf(item);
      if (index < 0)
        return false;
      this.OnRemoving(index, item);
      bool flag;
      if (flag = this.method_1(item))
        this.list_0.RemoveAt(index);
      this.OnRemoved(index, item);
      return flag;
    }

    public IEnumerator<TItem> GetEnumerator()
    {
      return (IEnumerator<TItem>) this.list_0.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.list_0.GetEnumerator();
    }

    public TItem GetFirst(TKey key)
    {
      TItem obj = default (TItem);
      List<TItem> objList;
      if (this.dictionary_0.TryGetValue(key, out objList))
        obj = objList[0];
      return obj;
    }

    public IList<TItem> this[TKey key]
    {
      get
      {
        List<TItem> objList;
        this.dictionary_0.TryGetValue(key, out objList);
        return (IList<TItem>) objList;
      }
    }

    public bool Contains(TKey key)
    {
      return this.dictionary_0.ContainsKey(key);
    }

    protected abstract TKey GetKeyForItem(TItem item);

    protected virtual void OnSet(int index, TItem oldItem, TItem newItem)
    {
      if (this.Set == null)
        return;
      this.Set((object) this, index, oldItem, newItem);
    }

    protected virtual void OnSetting(int index, TItem oldItem, TItem newItem)
    {
      if (this.Setting == null)
        return;
      this.Setting((object) this, index, oldItem, newItem);
    }

    protected virtual void OnAdded(int index, TItem item)
    {
      if (this.Added == null)
        return;
      this.Added((object) this, index, item);
    }

    protected virtual void OnAdding(int index, TItem item)
    {
      if (this.Adding == null)
        return;
      this.Adding((object) this, index, item);
    }

    protected virtual void OnRemoving(int index, TItem item)
    {
      if (this.Removing == null)
        return;
      this.Removing((object) this, index, item);
    }

    protected virtual void OnRemoved(int index, TItem item)
    {
      if (this.Removed == null)
        return;
      this.Removed((object) this, index, item);
    }

    private void method_0(TItem item, int index)
    {
      TKey keyForItem = this.GetKeyForItem(item);
      List<TItem> objList1;
      if (!this.dictionary_0.TryGetValue(keyForItem, out objList1))
      {
        List<TItem> objList2 = new List<TItem>(3);
        this.dictionary_0.Add(keyForItem, objList2);
        objList2.Add(item);
      }
      else
      {
        int index1 = 0;
        int num1 = objList1.Count - 1;
        while (index1 <= num1)
        {
          int index2 = index1 + (num1 - index1 >> 1);
          int num2 = this.list_0.IndexOf(objList1[index2]);
          if (index < num2)
            num1 = index2 - 1;
          else if (index > num2)
          {
            index1 = index2 + 1;
          }
          else
          {
            index1 = index2;
            break;
          }
        }
        objList1.Insert(index1, item);
      }
    }

    private bool method_1(TItem item)
    {
      TKey keyForItem = this.GetKeyForItem(item);
      bool flag = false;
      List<TItem> objList;
      if (this.dictionary_0.TryGetValue(keyForItem, out objList))
      {
        flag = objList.Remove(item);
        if (objList.Count == 0)
          this.dictionary_0.Remove(keyForItem);
      }
      return flag;
    }
  }
}
