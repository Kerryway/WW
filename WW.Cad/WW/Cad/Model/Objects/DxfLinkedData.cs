// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfLinkedData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.IO;
using WW.Cad.Model.Entities;

namespace WW.Cad.Model.Objects
{
  public class DxfLinkedData : DxfObject
  {
    private string string_0 = string.Empty;
    private string string_1 = string.Empty;

    public string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value ?? string.Empty;
      }
    }

    public string Description
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value ?? string.Empty;
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfLinkedData dxfLinkedData = (DxfLinkedData) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfLinkedData == null)
      {
        dxfLinkedData = new DxfLinkedData();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfLinkedData);
        dxfLinkedData.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfLinkedData;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfLinkedData dxfLinkedData = (DxfLinkedData) from;
      this.string_0 = dxfLinkedData.string_0;
      this.string_1 = dxfLinkedData.string_1;
    }

    public override string ObjectType
    {
      get
      {
        return "";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbLinkedData";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return DxfTable.smethod_2(model);
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.Write(100, (object) "AcDbLinkedData");
      w.Write(1, (object) this.string_0);
      w.Write(300, (object) this.string_1);
    }
  }
}
