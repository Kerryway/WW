// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockLookUpParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockLookUpParameter : DxfBlockSinglePointParameter
  {
    private string string_1;
    private string string_2;
    private DxfEvalGraph.GraphNodeId graphNodeId_2;

    public string LabelText
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

    public string Description
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value;
      }
    }

    public DxfEvalGraph.GraphNodeId ActionId
    {
      get
      {
        return this.graphNodeId_2;
      }
      set
      {
        this.graphNodeId_2 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "BLOCKLOOKUPPARAMETER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockLookupParameter";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockLookUpParameter blockLookUpParameter = (DxfBlockLookUpParameter) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (blockLookUpParameter == null)
      {
        blockLookUpParameter = new DxfBlockLookUpParameter();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) blockLookUpParameter);
        blockLookUpParameter.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) blockLookUpParameter;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockLookUpParameter blockLookUpParameter = (DxfBlockLookUpParameter) from;
      this.LabelText = blockLookUpParameter.LabelText;
      this.Description = blockLookUpParameter.Description;
      this.ActionId = (DxfEvalGraph.GraphNodeId) cloneContext.Clone((IGraphCloneable) blockLookUpParameter.ActionId);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_3.ClassNumber;
    }
  }
}
