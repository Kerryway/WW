// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockElement
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockElement : DxfEvalGraphConnectable
  {
    private int int_3 = 29;
    private int int_4 = 6;
    private string string_0;
    private int int_5;

    public string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public new int VersionMajor
    {
      get
      {
        return this.int_3;
      }
      set
      {
        this.int_3 = value;
      }
    }

    public new int VersionMinor
    {
      get
      {
        return this.int_4;
      }
      set
      {
        this.int_4 = value;
      }
    }

    public new int UnknownField
    {
      get
      {
        return this.int_5;
      }
      set
      {
        this.int_5 = value;
      }
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
        return "AcDbBlockElement";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      throw new Exception("This method shouldn't be called.");
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      throw new Exception("The class is base. Clone shouldn't be used.");
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockElement dxfBlockElement = (DxfBlockElement) from;
      this.Name = dxfBlockElement.Name;
      this.VersionMajor = dxfBlockElement.VersionMajor;
      this.VersionMinor = dxfBlockElement.VersionMinor;
      this.UnknownField = dxfBlockElement.UnknownField;
    }
  }
}
