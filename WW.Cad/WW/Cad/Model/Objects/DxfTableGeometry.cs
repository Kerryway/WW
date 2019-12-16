// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfTableGeometry
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns37;
using System.Collections.Generic;

namespace WW.Cad.Model.Objects
{
  public class DxfTableGeometry : DxfObject
  {
    private List<Class474> list_0 = new List<Class474>();
    private int int_0;

    public int ColumnCount
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

    internal List<Class474> RowGeometries
    {
      get
      {
        return this.list_0;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "TABLEGEOMETRY";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbTableGeometry";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf21OrHigher;
    }
  }
}
