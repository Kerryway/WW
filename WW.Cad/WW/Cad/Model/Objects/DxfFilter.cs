// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfFilter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Objects
{
  public abstract class DxfFilter : DxfObject
  {
    public const string DictKeyFilter = "ACAD_FILTER";

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf13OrHigher;
    }

    public override string ObjectType
    {
      get
      {
        return "MLINESTYLE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbMlineStyle";
      }
    }
  }
}
