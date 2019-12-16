// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockParametersValueSet
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockParametersValueSet : IGraphCloneable
  {
    private byte byte_0;
    private double double_0;
    private double double_1;
    private double double_2;
    private double[] double_3;
    private bool bool_0;
    private bool bool_1;

    public byte ValueSetFlags
    {
      get
      {
        return this.byte_0;
      }
      set
      {
        this.byte_0 = value;
      }
    }

    public double BoundedBelow
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

    public double BoundedAbove
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

    public double Increment
    {
      get
      {
        return this.double_2;
      }
      set
      {
        this.double_2 = value;
      }
    }

    public double[] List
    {
      get
      {
        return this.double_3;
      }
      set
      {
        this.double_3 = value;
      }
    }

    public bool AngularFlag
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public bool AngularDirection
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockParametersValueSet parametersValueSet = (DxfBlockParametersValueSet) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (parametersValueSet == null)
      {
        parametersValueSet = new DxfBlockParametersValueSet();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) parametersValueSet);
        parametersValueSet.CopyFrom(cloneContext, this);
      }
      return (IGraphCloneable) parametersValueSet;
    }

    protected virtual void CopyFrom(CloneContext cloneContext, DxfBlockParametersValueSet from)
    {
      this.byte_0 = from.byte_0;
      this.double_0 = from.double_0;
      this.double_1 = from.double_1;
      this.double_2 = from.double_2;
      this.bool_0 = from.bool_0;
      this.bool_1 = from.bool_1;
      if (from.List == null)
      {
        this.List = (double[]) null;
      }
      else
      {
        this.List = new double[from.List.Length];
        from.List.CopyTo((Array) this.List, 0);
      }
    }

    internal void Write(Interface29 objectWriter)
    {
      objectWriter.imethod_33((int) this.byte_0);
      objectWriter.imethod_16(this.double_0);
      objectWriter.imethod_16(this.double_1);
      objectWriter.imethod_16(this.double_2);
      if (this.double_3 != null)
      {
        objectWriter.imethod_33(this.double_3.Length);
        foreach (double num in this.double_3)
          objectWriter.imethod_16(num);
      }
      else
        objectWriter.imethod_33(0);
    }

    public enum ValueSetType
    {
      BoundedBelow = 1,
      BoundedAbove = 2,
      Increment = 4,
      List = 8,
    }
  }
}
