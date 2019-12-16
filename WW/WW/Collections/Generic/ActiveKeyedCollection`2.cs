// Decompiled with JetBrains decompiler
// Type: WW.Collections.Generic.ActiveKeyedCollection`2
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;

namespace WW.Collections.Generic
{
  [Serializable]
  public abstract class ActiveKeyedCollection<TKey, TItem> : KeyedCollection<TKey, TItem>
  {
    public event ItemSetEventHandler<TItem> Set;

    public event ItemEventHandler<TItem> Inserted;

    public event ItemEventHandler<TItem> Removed;

    public ActiveKeyedCollection()
    {
    }

    public ActiveKeyedCollection(IEqualityComparer<TKey> comparer)
      : base(comparer)
    {
    }

    public ActiveKeyedCollection(IEqualityComparer<TKey> comparer, int dictionaryCreationThreshold)
      : base(comparer, dictionaryCreationThreshold)
    {
    }

    protected override void InsertItem(int index, TItem item)
    {
      try
      {
        base.InsertItem(index, item);
      }
      catch (ArgumentException ex)
      {
        throw new ArgumentException("An item of type " + (object) typeof (TItem) + " with the same key " + (object) this.GetKeyForItem(item) + " has already been added.");
      }
      this.OnInserted(index, item);
    }

    protected override void SetItem(int index, TItem item)
    {
      TItem oldItem = this[index];
      base.SetItem(index, item);
      this.OnSet(index, oldItem, item);
    }

    protected override void RemoveItem(int index)
    {
      TItem obj = this[index];
      base.RemoveItem(index);
      this.OnRemoved(index, obj);
    }

    protected override void ClearItems()
    {
      for (int index = this.Count - 1; index >= 0; --index)
        this.RemoveItem(index);
    }

    protected virtual void OnInserted(int index, TItem item)
    {
      if (this.Inserted == null)
        return;
      this.Inserted((object) this, index, item);
    }

    protected virtual void OnSet(int index, TItem oldItem, TItem newItem)
    {
      if (this.Set == null)
        return;
      this.Set((object) this, index, oldItem, newItem);
    }

    protected virtual void OnRemoved(int index, TItem item)
    {
      if (this.Removed == null)
        return;
      this.Removed((object) this, index, item);
    }
  }
}
