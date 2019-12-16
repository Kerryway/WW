// Decompiled with JetBrains decompiler
// Type: WW.Collections.Generic.BinaryHeap`1
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;

namespace WW.Collections.Generic
{
  public abstract class BinaryHeap<T>
  {
    public const int DefaultCapacity = 8;
    protected T[] heap;
    private int int_0;
    private int int_1;
    private IComparer<T> icomparer_0;

    public BinaryHeap()
      : this((IComparer<T>) System.Collections.Generic.Comparer<T>.Default)
    {
    }

    public BinaryHeap(int initialCapacity)
      : this(initialCapacity, (IComparer<T>) System.Collections.Generic.Comparer<T>.Default)
    {
    }

    public BinaryHeap(IComparer<T> comparer)
      : this(8, comparer)
    {
    }

    public BinaryHeap(int initialCapacity, IComparer<T> comparer)
    {
      if (initialCapacity <= 0)
        throw new ArgumentException("initialCapacity must be greater than zero.", nameof (initialCapacity));
      this.int_0 = initialCapacity;
      this.icomparer_0 = comparer;
    }

    public BinaryHeap(ICollection<T> values)
      : this(values, (IComparer<T>) System.Collections.Generic.Comparer<T>.Default)
    {
    }

    public BinaryHeap(ICollection<T> values, IComparer<T> comparer)
    {
      this.int_0 = 8;
      this.icomparer_0 = comparer;
      this.Build(values);
    }

    public IComparer<T> Comparer
    {
      get
      {
        return this.icomparer_0;
      }
    }

    public int Count
    {
      get
      {
        return this.int_1;
      }
    }

    public int Capacity
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public void Build(ICollection<T> values)
    {
      if (this.int_0 < values.Count)
      {
        while (this.int_0 < values.Count && this.int_0 > 0)
          this.int_0 <<= 1;
        if (this.int_0 < values.Count)
          this.int_0 = values.Count;
        this.method_5();
      }
      if (this.heap == null)
        this.heap = new T[this.int_0];
      int int1 = this.int_1;
      foreach (T obj in (IEnumerable<T>) values)
        this.heap[int1++] = obj;
      this.int_1 = int1;
      for (int i = this.int_1 >> 1; i >= 0; --i)
        this.method_1(i);
    }

    public void SetupHeap(int capacity)
    {
      this.int_0 = capacity;
      this.method_5();
    }

    public void EnqueueWithoutReorder(T value)
    {
      this.heap[this.int_1++] = value;
    }

    public void Reorder()
    {
      for (int i = this.int_1 >> 1; i >= 0; --i)
        this.method_1(i);
    }

    public void Enqueue(T value)
    {
      if (this.heap == null)
        this.heap = new T[this.int_0];
      else if (this.heap.Length == this.int_1)
        this.method_4();
      if (this.int_1 == 0)
      {
        this.heap[0] = value;
      }
      else
      {
        this.heap[this.int_1] = value;
        this.method_0(this.int_1);
      }
      ++this.int_1;
    }

    private void method_0(int i)
    {
      do
      {
        int num = i - 1 >> 1;
        if (this.LessThan(i, num))
        {
          this.method_3(i, num);
          i = num;
        }
        else
          goto label_2;
      }
      while (i > 0);
      goto label_3;
label_2:
      return;
label_3:;
    }

    public bool Dequeue(out T value)
    {
      if (this.int_1 == 0)
      {
        value = default (T);
        return false;
      }
      value = this.heap[0];
      --this.int_1;
      if (this.int_1 > 0)
      {
        this.heap[0] = this.heap[this.int_1];
        this.method_2(0);
      }
      this.heap[this.int_1] = default (T);
      return true;
    }

    public bool Peek(out T value)
    {
      if (this.int_1 == 0)
      {
        value = default (T);
        return false;
      }
      value = this.heap[0];
      return true;
    }

    public void Clear()
    {
      for (int index = 0; index < this.int_1; ++index)
        this.heap[index] = default (T);
      this.int_1 = 0;
    }

    private void method_1(int i)
    {
      for (int j = (i << 1) + 1; j < this.int_1; j = (i << 1) + 1)
      {
        int i1 = j + 1;
        int num = j;
        if (i1 < this.int_1 && this.LessThan(i1, j))
          num = i1;
        if (!this.LessThan(num, i))
          break;
        this.method_3(i, num);
        i = num;
      }
    }

    private void method_2(int i)
    {
      for (int j = (i << 1) + 1; j < this.int_1; j = (i << 1) + 1)
      {
        int i1 = j + 1;
        int b = j;
        if (i1 < this.int_1 && this.LessThan(i1, j))
          b = i1;
        this.method_3(i, b);
        i = b;
      }
      if (i <= 0)
        return;
      this.method_0(i);
    }

    protected abstract bool LessThan(int i, int j);

    private void method_3(int a, int b)
    {
      T obj = this.heap[a];
      this.heap[a] = this.heap[b];
      this.heap[b] = obj;
    }

    private void method_4()
    {
      if (this.int_0 < 1)
        this.int_0 = 8;
      this.int_0 <<= 1;
      this.method_5();
    }

    private void method_5()
    {
      T[] heap = this.heap;
      this.heap = new T[this.int_0];
      if (heap == null)
        return;
      Array.Copy((Array) heap, (Array) this.heap, heap.Length);
    }
  }
}
