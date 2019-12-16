// Decompiled with JetBrains decompiler
// Type: WW.Collections.Generic.KeyedCollection`2
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WW.Collections.Generic
{
  [Serializable]
  public abstract class KeyedCollection<TKey, TItem> : System.Collections.ObjectModel.KeyedCollection<TKey, TItem>
  {
    public KeyedCollection()
    {
    }

    public KeyedCollection(IEqualityComparer<TKey> comparer)
      : base(comparer)
    {
    }

    public KeyedCollection(IEqualityComparer<TKey> comparer, int dictionaryCreationThreshold)
      : base(comparer, dictionaryCreationThreshold)
    {
    }

    public bool TryGetValue(TKey key, out TItem value)
    {
      if (this.Dictionary != null)
        return this.Dictionary.TryGetValue(key, out value);
      value = default (TItem);
      return false;
    }

    public ICollection<TKey> Keys
    {
      get
      {
        return this.Dictionary.Keys;
      }
    }
  }
}
