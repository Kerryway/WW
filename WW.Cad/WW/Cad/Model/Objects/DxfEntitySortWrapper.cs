// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfEntitySortWrapper
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW.Cad.Model.Entities;

namespace WW.Cad.Model.Objects
{
  public class DxfEntitySortWrapper : IComparable<DxfEntitySortWrapper>
  {
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private ulong ulong_0;

    public DxfEntitySortWrapper()
    {
    }

    public DxfEntitySortWrapper(DxfEntity entity, ulong sortHandle)
    {
      this.Entity = entity;
      this.ulong_0 = sortHandle;
    }

    public DxfEntity Entity
    {
      get
      {
        return (DxfEntity) this.dxfObjectReference_0.Value;
      }
      set
      {
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public ulong SortHandle
    {
      get
      {
        return this.ulong_0;
      }
      set
      {
        this.ulong_0 = value;
      }
    }

    public void CopyFrom(CloneContext cloneContext, DxfEntitySortWrapper from)
    {
      this.Entity = cloneContext.SourceModel != cloneContext.TargetModel ? (DxfEntity) cloneContext.Clone((IGraphCloneable) from.Entity) : from.Entity;
      this.ulong_0 = from.ulong_0;
    }

    public override string ToString()
    {
      return this.ulong_0.ToString() + ", " + this.Entity.Handle.ToString() + ", " + this.Entity.ToString();
    }

    public int CompareTo(DxfEntitySortWrapper other)
    {
      if (this.ulong_0 < other.ulong_0)
        return -1;
      if (this.ulong_0 > other.ulong_0)
        return 1;
      bool flag1 = (long) this.ulong_0 != (long) this.Entity.Handle;
      bool flag2 = (long) other.ulong_0 != (long) other.Entity.Handle;
      if (flag1 == flag2)
        return 0;
      return flag2 ? -1 : 1;
    }
  }
}
