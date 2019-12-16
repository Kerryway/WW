// Decompiled with JetBrains decompiler
// Type: WW.Collections.Generic.ActiveList`1
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
  public class ActiveList<T> : ICollection<T>, IEnumerable<T>, IEnumerable, ICollection, IList, IList<T>
  {
    private List<T> list;

    public event ItemSetEventHandler<T> Setting;

    public event ItemSetEventHandler<T> Set;

    public event ItemEventHandler<T> Adding;

    public event ItemEventHandler<T> Added;

    public event ItemEventHandler<T> Removing;

    public event ItemEventHandler<T> Removed;

    public ActiveList()
    {
      this.list = new List<T>();
    }

    public ActiveList(IEnumerable<T> collection)
    {
      this.list = new List<T>(collection);
    }

    public ActiveList(int capacity)
    {
      this.list = new List<T>(capacity);
    }

    public T this[int index]
    {
      get
      {
        return this.list[index];
      }
      set
      {
        T oldItem = this.list[index];
        this.OnSetting(index, oldItem, value);
        this.list[index] = value;
        this.OnSet(index, oldItem, value);
      }
    }

    public int IndexOf(T item)
    {
      return this.list.IndexOf(item);
    }

    public void Insert(int index, T item)
    {
      this.OnAdding(index, item);
      this.list.Insert(index, item);
      this.OnAdded(index, item);
    }

    public void RemoveAt(int index)
    {
      T obj = this.list[index];
      this.OnRemoving(index, obj);
      this.list.RemoveAt(index);
      this.OnRemoved(index, obj);
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
        return ((ICollection<T>) this.list).IsReadOnly;
      }
    }

    public void Add(T item)
    {
      int count = this.list.Count;
      this.OnAdding(count, item);
      this.list.Add(item);
      this.OnAdded(count, item);
    }

    public void Clear()
    {
      for (int index = this.list.Count - 1; index >= 0; --index)
        this.RemoveAt(index);
    }

    public bool Contains(T item)
    {
      return this.list.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
      this.list.CopyTo(array, arrayIndex);
    }

    public bool Remove(T item)
    {
      int index = this.list.IndexOf(item);
      if (index < 0)
        return false;
      this.OnRemoving(index, item);
      this.list.RemoveAt(index);
      this.OnRemoved(index, item);
      return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
      return (IEnumerator<T>) this.list.GetEnumerator();
    }

    object IList.this[int index]
    {
      get
      {
        return (object) this.list[index];
      }
      set
      {
        T oldItem = this.list[index];
        T newItem = (T) value;
        this.OnSetting(index, oldItem, newItem);
        this.list[index] = newItem;
        this.OnSet(index, oldItem, newItem);
      }
    }

    bool IList.IsReadOnly
    {
      get
      {
        return ((IList) this.list).IsReadOnly;
      }
    }

    bool IList.IsFixedSize
    {
      get
      {
        return ((IList) this.list).IsFixedSize;
      }
    }

    int IList.Add(object value)
    {
      T obj = (T) value;
      int count = this.list.Count;
      this.OnAdding(count, obj);
      int num = ((IList) this.list).Add((object) obj);
      this.OnAdded(count, obj);
      return num;
    }

    void IList.Remove(object value)
    {
      T obj = (T) value;
      int index = this.list.IndexOf(obj);
      if (index < 0)
        return;
      this.OnRemoving(index, obj);
      this.list.RemoveAt(index);
      this.OnRemoved(index, obj);
    }

    bool IList.Contains(object value)
    {
      return this.list.Contains((T) value);
    }

    int IList.IndexOf(object value)
    {
      return this.list.IndexOf((T) value);
    }

    void IList.Insert(int index, object value)
    {
      T obj = (T) value;
      this.OnAdding(index, obj);
      this.list.Insert(index, obj);
      this.OnAdded(index, obj);
    }

    object ICollection.SyncRoot
    {
      get
      {
        return ((ICollection) this.list).SyncRoot;
      }
    }

    bool ICollection.IsSynchronized
    {
      get
      {
        return ((ICollection) this.list).IsSynchronized;
      }
    }

    void ICollection.CopyTo(Array array, int index)
    {
      ((ICollection) this.list).CopyTo(array, index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return ((IEnumerable) this.list).GetEnumerator();
    }

    public void AddRange(IEnumerable<T> collection)
    {
      foreach (T obj in collection)
        this.Add(obj);
    }

    public T[] ToArray()
    {
      return this.list.ToArray();
    }

    public void Sort()
    {
      this.list.Sort();
    }

    public void Sort(Comparer<T> comparison)
    {
      this.list.Sort((IComparer<T>) comparison);
    }

    public void Sort(IComparer<T> comparer)
    {
      this.list.Sort(comparer);
    }

    public void Sort(int index, int count, IComparer<T> comparer)
    {
      this.list.Sort(index, count, comparer);
    }

    public List<T> FindAll(Predicate<T> match)
    {
      return this.list.FindAll(match);
    }

    public T Find(Predicate<T> match)
    {
      return this.list.Find(match);
    }

    public int FindIndex(Predicate<T> match)
    {
      return this.list.FindIndex(match);
    }

    public int FindIndex(int startIndex, Predicate<T> match)
    {
      return this.list.FindIndex(startIndex, match);
    }

    public int FindIndex(int startIndex, int count, Predicate<T> match)
    {
      return this.list.FindIndex(startIndex, count, match);
    }

    public T FindLast(Predicate<T> match)
    {
      return this.list.FindLast(match);
    }

    public int FindLastIndex(Predicate<T> match)
    {
      return this.list.FindLastIndex(match);
    }

    public int FindLastIndex(int startIndex, Predicate<T> match)
    {
      return this.list.FindLastIndex(startIndex, match);
    }

    public int FindLastIndex(int startIndex, int count, Predicate<T> match)
    {
      return this.list.FindLastIndex(startIndex, count, match);
    }

    protected virtual void OnSet(int index, T oldItem, T newItem)
    {
      if (this.Set == null)
        return;
      this.Set((object) this, index, oldItem, newItem);
    }

    protected virtual void OnSetting(int index, T oldItem, T newItem)
    {
      if (this.Setting == null)
        return;
      this.Setting((object) this, index, oldItem, newItem);
    }

    protected virtual void OnAdded(int index, T item)
    {
      if (this.Added == null)
        return;
      this.Added((object) this, index, item);
    }

    protected virtual void OnAdding(int index, T item)
    {
      if (this.Adding == null)
        return;
      this.Adding((object) this, index, item);
    }

    protected virtual void OnRemoving(int index, T item)
    {
      if (this.Removing== null)
        return;
      this.Removing((object) this, index, item);
    }

    protected virtual void OnRemoved(int index, T item)
    {
      if (this.Removed == null)
        return;
      this.Removed((object) this, index, item);
    }
  }
}
