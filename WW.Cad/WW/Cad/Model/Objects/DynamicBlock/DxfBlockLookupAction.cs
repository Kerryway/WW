// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockLookupAction
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockLookupAction : DxfBlockAction
  {
    private int int_6;
    private int int_7;
    private string[] string_1;
    private bool bool_0;
    private DxfLookupActionInformation[] dxfLookupActionInformation_0;

    public int NumberOfRows
    {
      get
      {
        return this.int_6;
      }
      set
      {
        this.int_6 = value;
      }
    }

    public int NumberOfColumns
    {
      get
      {
        return this.int_7;
      }
      set
      {
        this.int_7 = value;
      }
    }

    public string[] Text
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public bool UnknownFlag
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

    public DxfLookupActionInformation[] Information
    {
      get
      {
        return this.dxfLookupActionInformation_0;
      }
      set
      {
        this.dxfLookupActionInformation_0 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "BLOCKLOOKUPACTION";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockLookupAction";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockLookupAction blockLookupAction = (DxfBlockLookupAction) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (blockLookupAction == null)
      {
        blockLookupAction = new DxfBlockLookupAction();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) blockLookupAction);
        blockLookupAction.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) blockLookupAction;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockLookupAction blockLookupAction = (DxfBlockLookupAction) from;
      this.NumberOfRows = blockLookupAction.NumberOfRows;
      this.NumberOfColumns = blockLookupAction.NumberOfColumns;
      this.UnknownFlag = blockLookupAction.UnknownFlag;
      this.Text = new string[blockLookupAction.Text.Length];
      blockLookupAction.Text.CopyTo((Array) this.Text, 0);
      this.Information = new DxfLookupActionInformation[blockLookupAction.Information.Length];
      for (int index = 0; index < blockLookupAction.Information.Length; ++index)
        this.Information[index] = (DxfLookupActionInformation) blockLookupAction.Information[index].Clone(cloneContext);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_16.ClassNumber;
    }
  }
}
