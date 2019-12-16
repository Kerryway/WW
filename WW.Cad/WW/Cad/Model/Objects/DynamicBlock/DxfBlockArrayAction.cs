// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockArrayAction
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockArrayAction : DxfBlockAction
  {
    private DxfConnectionPoint[] dxfConnectionPoint_0 = new DxfConnectionPoint[4];
    private double double_0;
    private double double_1;

    public DxfConnectionPoint[] ActionConnections
    {
      get
      {
        return this.dxfConnectionPoint_0;
      }
      set
      {
        this.dxfConnectionPoint_0 = value;
      }
    }

    public double ColumnOffset
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

    public double RowOffset
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

    public override string ObjectType
    {
      get
      {
        return "BLOCKARRAYACTION";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockArrayAction";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockArrayAction blockArrayAction = (DxfBlockArrayAction) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (blockArrayAction == null)
      {
        blockArrayAction = new DxfBlockArrayAction();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) blockArrayAction);
        blockArrayAction.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) blockArrayAction;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockArrayAction blockArrayAction = (DxfBlockArrayAction) from;
      this.ActionConnections = DxfConnectionPoint.Clone(cloneContext, blockArrayAction.ActionConnections);
      this.ColumnOffset = blockArrayAction.ColumnOffset;
      this.RowOffset = blockArrayAction.RowOffset;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_14.ClassNumber;
    }
  }
}
