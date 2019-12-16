// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfHandledObjectCollection`1
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections;
using System.Collections.Generic;

namespace WW.Cad.Model
{
  public class DxfHandledObjectCollection<T> : IList<T>, ICollection<T>, IEnumerable<T>, ICollection, IEnumerable, IList
    where T : DxfHandledObject
  {
    private List<DxfObjectReference> list_0;

    public DxfHandledObjectCollection()
    {
      this.list_0 = new List<DxfObjectReference>();
    }

    public DxfHandledObjectCollection(IEnumerable<T> collection)
    {
      this.list_0 = new List<DxfObjectReference>();
      foreach (T obj in collection)
        this.list_0.Add(obj.Reference);
    }

    public DxfHandledObjectCollection(int capacity)
    {
      this.list_0 = new List<DxfObjectReference>(capacity);
    }

    public T this[int index]
    {
      get
      {
        return (T) this.list_0[index].Value;
      }
      set
      {
        T oldItem = (T) this.list_0[index].Value;
        this.OnSetting(index, oldItem, value);
        this.list_0[index] = DxfObjectReference.GetReference((IDxfHandledObject) value);
        this.OnSet(index, oldItem, value);
      }
    }

    public int IndexOf(T item)
    {
      return this.list_0.IndexOf(item.Reference);
    }

    public void Insert(int index, T item)
    {
      this.OnAdding(index, item);
      this.list_0.Insert(index, (object) item == null ? DxfObjectReference.Null : item.Reference);
      this.OnAdded(index, item);
    }

    public void RemoveAt(int index)
    {
      T obj = (T) this.list_0[index].Value;
      this.OnRemoving(index, obj);
      this.list_0.RemoveAt(index);
      this.OnRemoved(index, obj);
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
        return ((ICollection<T>) this.list_0).IsReadOnly;
      }
    }

    public void Add(T item)
    {
      int count = this.list_0.Count;
      this.OnAdding(count, item);
      this.list_0.Add((object) item == null ? DxfObjectReference.Null : item.Reference);
      this.OnAdded(count, item);
    }

    public void Clear()
    {
      for (int index = this.list_0.Count - 1; index >= 0; --index)
        this.RemoveAt(index);
    }

    public bool Contains(T item)
    {
      return this.list_0.Contains(item.Reference);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
      for (int index = 0; index < this.list_0.Count; ++index)
        array[index] = (T) this.list_0[index].Value;
    }

    public bool Remove(T item)
    {
      int index = this.list_0.IndexOf(item.Reference);
      if (index < 0)
        return false;
      this.OnRemoving(index, item);
      this.list_0.RemoveAt(index);
      this.OnRemoved(index, item);
      return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
      return (IEnumerator<T>) new DxfHandledObjectCollection<T>.Class29<T>((IEnumerator<DxfObjectReference>) this.list_0.GetEnumerator());
    }

    object IList.this[int index]
    {
      get
      {
        return (object) this.list_0[index].Value;
      }
      set
      {
        T oldItem = (T) this.list_0[index].Value;
        T newItem = (T) value;
        this.OnSetting(index, oldItem, newItem);
        this.list_0[index] = newItem.Reference;
        this.OnSet(index, oldItem, newItem);
      }
    }

    bool IList.IsReadOnly
    {
      get
      {
        return ((IList) this.list_0).IsReadOnly;
      }
    }

    bool IList.IsFixedSize
    {
      get
      {
        return ((IList) this.list_0).IsFixedSize;
      }
    }

    int IList.Add(object value)
    {
      T obj = (T) value;
      int count = this.list_0.Count;
      this.OnAdding(count, obj);
      int num = ((IList) this.list_0).Add((object) obj.Reference);
      this.OnAdded(count, obj);
      return num;
    }

    void IList.Remove(object value)
    {
      T obj = (T) value;
      int index = this.list_0.IndexOf(obj.Reference);
      if (index < 0)
        return;
      this.OnRemoving(index, obj);
      this.list_0.RemoveAt(index);
      this.OnRemoved(index, obj);
    }

    bool IList.Contains(object value)
    {
      return this.list_0.Contains(((T) value).Reference);
    }

    int IList.IndexOf(object value)
    {
      return this.list_0.IndexOf(((T) value).Reference);
    }

    void IList.Insert(int index, object value)
    {
      T obj = (T) value;
      this.OnAdding(index, obj);
      this.list_0.Insert(index, obj.Reference);
      this.OnAdded(index, obj);
    }

    object ICollection.SyncRoot
    {
      get
      {
        return ((ICollection) this.list_0).SyncRoot;
      }
    }

    bool ICollection.IsSynchronized
    {
      get
      {
        return ((ICollection) this.list_0).IsSynchronized;
      }
    }

    void ICollection.CopyTo(Array array, int index)
    {
      int count = this.list_0.Count;
      for (int index1 = 0; index1 < count; ++index1)
        array.SetValue((object) this.list_0[index1].Value, index++);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) new DxfHandledObjectCollection<T>.Class29<T>((IEnumerator<DxfObjectReference>) this.list_0.GetEnumerator());
    }

    public int Capacity
    {
      get
      {
        return this.list_0.Capacity;
      }
      set
      {
        this.list_0.Capacity = value;
      }
    }

    public void AddRange(IEnumerable<T> collection)
    {
      foreach (T obj in collection)
        this.Add(obj);
    }

    public T[] ToArray()
    {
      T[] objArray = new T[this.list_0.Count];
      int count = this.list_0.Count;
      for (int index = 0; index < count; ++index)
        objArray[index] = (T) this.list_0[index].Value;
      return objArray;
    }

    public void Sort()
    {
      this.list_0.Sort();
    }

    public void Sort(Comparison<T> comparison)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      this.list_0.Sort(new Comparison<DxfObjectReference>(new DxfHandledObjectCollection<T>.Class31()
      {
        comparison_0 = comparison
      }.method_0));
    }

    public void Sort(IComparer<T> comparer)
    {
      this.list_0.Sort((IComparer<DxfObjectReference>) new DxfHandledObjectCollection<T>.Class30<T>(comparer));
    }

    public void Sort(int index, int count, IComparer<T> comparer)
    {
      this.list_0.Sort(index, count, (IComparer<DxfObjectReference>) new DxfHandledObjectCollection<T>.Class30<T>(comparer));
    }

    public List<T> FindAll(Predicate<T> match)
    {
      List<T> objList = new List<T>();
      foreach (T obj in this)
      {
        if (match(obj))
          objList.Add(obj);
      }
      return objList;
    }

    public T Find(Predicate<T> match)
    {
      foreach (T obj in this)
      {
        if (match(obj))
          return obj;
      }
      return default (T);
    }

    public int FindIndex(Predicate<T> match)
    {
      for (int index = 0; index < this.Count; ++index)
      {
        if (match(this[index]))
          return index;
      }
      return -1;
    }

    public int FindIndex(int startIndex, Predicate<T> match)
    {
      for (int index = startIndex; index < this.Count; ++index)
      {
        if (match(this[index]))
          return index;
      }
      return -1;
    }

    public int FindIndex(int startIndex, int count, Predicate<T> match)
    {
      for (int index = 0; index < count; ++index)
      {
        if (match(this[index]))
          return index;
      }
      return -1;
    }

    public T FindLast(Predicate<T> match)
    {
      for (int index = this.Count - 1; index >= 0; --index)
      {
        if (match(this[index]))
          return this[index];
      }
      return default (T);
    }

    public int FindLastIndex(Predicate<T> match)
    {
      for (int index = this.Count - 1; index >= 0; --index)
      {
        if (match(this[index]))
          return index;
      }
      return -1;
    }

    public int FindLastIndex(int startIndex, Predicate<T> match)
    {
      for (int index = this.Count - 1; index >= startIndex; --index)
      {
        if (match(this[index]))
          return index;
      }
      return -1;
    }

    public int FindLastIndex(int startIndex, int count, Predicate<T> match)
    {
      for (int index = count - 1; index >= startIndex; --index)
      {
        if (match(this[index]))
          return index;
      }
      return -1;
    }

    public virtual DxfHandledObjectCollection<T> Clone(
      CloneContext cloneContext)
    {
      DxfHandledObjectCollection<T> objectCollection = new DxfHandledObjectCollection<T>(this.Count);
      foreach (T obj in this)
        objectCollection.Add((T) obj.Clone(cloneContext));
      return objectCollection;
    }

    protected virtual void OnSet(int index, T oldItem, T newItem)
    {
    }

    protected virtual void OnSetting(int index, T oldItem, T newItem)
    {
    }

    protected virtual void OnAdded(int index, T item)
    {
    }

    protected virtual void OnAdding(int index, T item)
    {
    }

    protected virtual void OnRemoving(int index, T item)
    {
    }

    protected virtual void OnRemoved(int index, T item)
    {
    }

    private class Class29<U> : IEnumerator<U>, IDisposable, IEnumerator
      where U : DxfHandledObject
    {
      private IEnumerator<DxfObjectReference> ienumerator_0;

      public Class29(IEnumerator<DxfObjectReference> enumerator)
      {
        this.ienumerator_0 = enumerator;
      }

      public U Current
      {
        get
        {
          return (U) this.ienumerator_0.Current.Value;
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
          return (object) this.ienumerator_0.Current.Value;
        }
      }

      public bool MoveNext()
      {
        return this.ienumerator_0.MoveNext();
      }

      public void Reset()
      {
        this.ienumerator_0.MoveNext();
      }
    }

    private class Class30<U> : IComparer<DxfObjectReference> where U : DxfHandledObject
    {
      private IComparer<U> icomparer_0;

      public Class30(IComparer<U> comparer)
      {
        this.icomparer_0 = comparer;
      }

      public int Compare(DxfObjectReference x, DxfObjectReference y)
      {
        return this.icomparer_0.Compare((U) x.Value, (U) y.Value);
      }
    }
  }
}
