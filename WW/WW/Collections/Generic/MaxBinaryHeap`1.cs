// Decompiled with JetBrains decompiler
// Type: WW.Collections.Generic.MaxBinaryHeap`1
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;

namespace WW.Collections.Generic
{
  public class MaxBinaryHeap<T> : BinaryHeap<T>
  {
    public MaxBinaryHeap()
    {
    }

    public MaxBinaryHeap(int initialCapacity)
      : base(initialCapacity)
    {
    }

    public MaxBinaryHeap(IComparer<T> comparer)
      : base(comparer)
    {
    }

    public MaxBinaryHeap(int initialCapacity, IComparer<T> comparer)
      : base(initialCapacity, comparer)
    {
    }

    public MaxBinaryHeap(ICollection<T> values)
      : base(values)
    {
    }

    public MaxBinaryHeap(ICollection<T> values, IComparer<T> comparer)
      : base(values, comparer)
    {
    }

    protected override bool LessThan(int i, int j)
    {
      return this.Comparer.Compare(this.heap[i], this.heap[j]) > 0;
    }
  }
}
