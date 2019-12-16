// Decompiled with JetBrains decompiler
// Type: WW.Collections.Generic.SortedList`1
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace WW.Collections.Generic
{
  [TypeConverter(typeof (CollectionConverter))]
  [Serializable]
  public class SortedList<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>
  {
    private readonly List<T> list = new List<T>();
    private readonly IComparer<T> comparer;

    public SortedList(IComparer<T> comparer)
    {
      this.comparer = comparer;
    }

    public SortedList()
      : this((IComparer<T>) Comparer<T>.Default)
    {
    }

    public int IndexOf(T item)
    {
      int index1 = this.list.BinarySearch(item, this.comparer);
      if (index1 < 0 || item.Equals((object) this.list[index1]))
        return index1;
      T obj1;
      for (int index2 = index1 - 1; index2 >= 0 && this.comparer.Compare(item, obj1 = this.list[index2]) == 0; --index2)
      {
        if (item.Equals((object) obj1))
          return index2;
      }
      T obj2;
      for (int index2 = index1 + 1; index2 < this.list.Count && this.comparer.Compare(item, obj2 = this.list[index2]) == 0; ++index2)
      {
        if (item.Equals((object) obj2))
          return index2;
      }
      return ~index1;
    }

    public void Insert(int index, T item)
    {
      throw new NotSupportedException();
    }

    public void RemoveAt(int index)
    {
      this.list.RemoveAt(index);
    }

    public T this[int index]
    {
      get
      {
        return this.list[index];
      }
      set
      {
        throw new NotSupportedException();
      }
    }

    public void Add(T item)
    {
      int num = this.list.BinarySearch(item);
      if (num < 0)
      {
        this.list.Insert(~num, item);
      }
      else
      {
        int index = num + 1;
        while (index < this.list.Count && this.comparer.Compare(item, this.list[index]) == 0)
          ++index;
        this.list.Insert(index, item);
      }
    }

    public void Clear()
    {
      this.list.Clear();
    }

    public bool Contains(T item)
    {
      return this.IndexOf(item) >= 0;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
      this.list.CopyTo(array, arrayIndex);
    }

    public int Count
    {
      get
      {
        return this.list.Count;
      }
    }

    public bool IsReadOnly
    {
      get
      {
        return false;
      }
    }

    public bool Remove(T item)
    {
      int index = this.IndexOf(item);
      if (index < 0)
        return false;
      this.list.RemoveAt(index);
      return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
      return (IEnumerator<T>) this.list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.list.GetEnumerator();
    }
  }
}
