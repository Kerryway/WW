// Decompiled with JetBrains decompiler
// Type: WW.Collections.Generic.LookupList`2
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections;
using System.Collections.Generic;

namespace WW.Collections.Generic
{
  public abstract class LookupList<TKey, TItem> : IEnumerable, IList<TItem>, ICollection<TItem>, IEnumerable<TItem>
  {
    private readonly List<TItem> list_0 = new List<TItem>();
    private readonly Dictionary<TKey, List<TItem>> dictionary_0;

    protected LookupList()
    {
      this.dictionary_0 = new Dictionary<TKey, List<TItem>>();
    }

    protected LookupList(IEqualityComparer<TKey> keyEqualityComparer)
    {
      this.dictionary_0 = new Dictionary<TKey, List<TItem>>(keyEqualityComparer);
    }

    public int IndexOf(TItem item)
    {
      return this.list_0.IndexOf(item);
    }

    public void Insert(int index, TItem item)
    {
      this.list_0.Insert(index, item);
      this.method_0(item, index);
    }

    public void RemoveAt(int index)
    {
      if (index < 0 || index >= this.list_0.Count)
        throw new ArgumentOutOfRangeException();
      this.method_1(this.list_0[index]);
      this.list_0.RemoveAt(index);
    }

    public TItem this[int index]
    {
      get
      {
        return this.list_0[index];
      }
      set
      {
        this.method_1(this.list_0[index]);
        this.list_0[index] = value;
        this.method_0(value, index);
      }
    }

    public void Add(TItem item)
    {
      int count = this.list_0.Count;
      this.list_0.Add(item);
      this.method_0(item, count);
    }

    public void Clear()
    {
      this.list_0.Clear();
      this.dictionary_0.Clear();
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
      bool flag;
      if (flag = this.method_1(item))
        this.list_0.Remove(item);
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
