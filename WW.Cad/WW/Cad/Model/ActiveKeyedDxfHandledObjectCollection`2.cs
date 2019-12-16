// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.ActiveKeyedDxfHandledObjectCollection`2
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Collections.Generic;

namespace WW.Cad.Model
{
  public abstract class ActiveKeyedDxfHandledObjectCollection<TKey, TItem> : KeyedDxfHandledObjectCollection<TKey, TItem>
    where TItem : DxfHandledObject
  {
    public event ItemSetEventHandler<TItem> Set;

    public event ItemEventHandler<TItem> Inserted;

    public event ItemEventHandler<TItem> Removed;

    protected ActiveKeyedDxfHandledObjectCollection()
    {
    }

    protected ActiveKeyedDxfHandledObjectCollection(IEqualityComparer<TKey> comparer)
      : base(comparer)
    {
    }

    protected ActiveKeyedDxfHandledObjectCollection(
      IEqualityComparer<TKey> comparer,
      int dictionaryCreationThreshold)
      : base(comparer, dictionaryCreationThreshold)
    {
    }

    public void AddCopiesFrom(
      ActiveKeyedDxfHandledObjectCollection<TKey, TItem> from,
      CloneContext cloneContext)
    {
      if (cloneContext.ReferenceResolutionType != ReferenceResolutionType.CloneMissing)
        throw new ArgumentException("cloneContext has to have ReferenceResolutionType of CloneMissing!");
      foreach (TItem obj in (KeyedDxfHandledObjectCollection<TKey, TItem>) from)
      {
        if ((object) obj != null && !this.Contains(from.GetKeyForItem(obj)))
          this.Add((TItem) obj.Clone(cloneContext));
      }
    }

    protected override void OnInserted(int index, TItem item)
    {
      if (this.itemEventHandler_0 == null)
        return;
      this.itemEventHandler_0((object) this, index, item);
    }

    protected override void OnSet(int index, TItem oldItem, TItem newItem)
    {
      if (this.itemSetEventHandler_0 == null)
        return;
      this.itemSetEventHandler_0((object) this, index, oldItem, newItem);
    }

    protected override void OnRemoved(int index, TItem item)
    {
      if (this.itemEventHandler_1 == null)
        return;
      this.itemEventHandler_1((object) this, index, item);
    }
  }
}
