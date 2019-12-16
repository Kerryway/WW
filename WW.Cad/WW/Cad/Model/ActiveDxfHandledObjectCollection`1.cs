// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.ActiveDxfHandledObjectCollection`1
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Collections.Generic;

namespace WW.Cad.Model
{
  public class ActiveDxfHandledObjectCollection<T> : DxfHandledObjectCollection<T>
    where T : DxfHandledObject
  {
    public event ItemSetEventHandler<T> Setting;

    public event ItemSetEventHandler<T> Set;

    public event ItemEventHandler<T> Adding;

    public event ItemEventHandler<T> Added;

    public event ItemEventHandler<T> Removing;

    public event ItemEventHandler<T> Removed;

    public ActiveDxfHandledObjectCollection()
    {
    }

    public ActiveDxfHandledObjectCollection(IEnumerable<T> collection)
      : base(collection)
    {
    }

    public ActiveDxfHandledObjectCollection(int capacity)
      : base(capacity)
    {
    }

    public override DxfHandledObjectCollection<T> Clone(
      CloneContext cloneContext)
    {
      ActiveDxfHandledObjectCollection<T> objectCollection = new ActiveDxfHandledObjectCollection<T>(this.Count);
      foreach (T obj in (DxfHandledObjectCollection<T>) this)
        objectCollection.Add((T) obj.Clone(cloneContext));
      return (DxfHandledObjectCollection<T>) objectCollection;
    }

    protected override void OnSet(int index, T oldItem, T newItem)
    {
      if (this.itemSetEventHandler_1 == null)
        return;
      this.itemSetEventHandler_1((object) this, index, oldItem, newItem);
    }

    protected override void OnSetting(int index, T oldItem, T newItem)
    {
      if (this.itemSetEventHandler_0 == null)
        return;
      this.itemSetEventHandler_0((object) this, index, oldItem, newItem);
    }

    protected override void OnAdded(int index, T item)
    {
      if (this.itemEventHandler_1 == null)
        return;
      this.itemEventHandler_1((object) this, index, item);
    }

    protected override void OnAdding(int index, T item)
    {
      if (this.itemEventHandler_0 == null)
        return;
      this.itemEventHandler_0((object) this, index, item);
    }

    protected override void OnRemoving(int index, T item)
    {
      if (this.itemEventHandler_2 == null)
        return;
      this.itemEventHandler_2((object) this, index, item);
    }

    protected override void OnRemoved(int index, T item)
    {
      if (this.itemEventHandler_3 == null)
        return;
      this.itemEventHandler_3((object) this, index, item);
    }
  }
}
