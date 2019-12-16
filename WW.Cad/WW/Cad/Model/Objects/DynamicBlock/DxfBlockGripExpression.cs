// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockGripExpression
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockGripExpression : DxfEvalGraphExpression
  {
    private DxfConnectionPoint dxfConnectionPoint_0 = new DxfConnectionPoint();

    public DxfConnectionPoint ActionConnection
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

    public override string ObjectType
    {
      get
      {
        return "BLOCKGRIPLOCATIONCOMPONENT";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockGripExpr";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockGripExpression blockGripExpression = (DxfBlockGripExpression) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (blockGripExpression == null)
      {
        blockGripExpression = new DxfBlockGripExpression();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) blockGripExpression);
        blockGripExpression.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) blockGripExpression;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockGripExpression blockGripExpression = (DxfBlockGripExpression) from;
      this.ActionConnection = (DxfConnectionPoint) cloneContext.Clone((IGraphCloneable) blockGripExpression.ActionConnection);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_31.ClassNumber;
    }
  }
}
