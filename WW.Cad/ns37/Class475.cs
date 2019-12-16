// Decompiled with JetBrains decompiler
// Type: ns37.Class475
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model;

namespace ns37
{
  internal class Class475
  {
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private List<Class550> list_0 = new List<Class550>();
    private int int_0;
    private double double_0;
    private double double_1;

    public int Flags
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

    public double WidthWithGap
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
      }
    }

    public double HeightWithGap
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
      }
    }

    public DxfHandledObject Obj
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_0.Value;
      }
      set
      {
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public IList<Class550> CellGeometryDataCollection
    {
      get
      {
        return (IList<Class550>) this.list_0;
      }
    }

    public Class475 Clone(CloneContext cloneContext)
    {
      Class475 class475 = new Class475();
      class475.CopyFrom(cloneContext, this);
      return class475;
    }

    public void CopyFrom(CloneContext cloneContext, Class475 from)
    {
      this.int_0 = from.int_0;
      this.double_0 = from.double_0;
      this.double_1 = from.double_1;
      this.Obj = cloneContext.SourceModel != cloneContext.TargetModel ? (DxfHandledObject) cloneContext.Clone((IGraphCloneable) from.Obj) : from.Obj;
      foreach (Class550 class550 in from.list_0)
        this.list_0.Add(class550.Clone());
    }
  }
}
