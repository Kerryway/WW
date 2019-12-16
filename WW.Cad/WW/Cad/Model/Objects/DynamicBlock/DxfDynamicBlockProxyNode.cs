// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfDynamicBlockProxyNode
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfDynamicBlockProxyNode : DxfEvalGraphExpression
  {
    public override string ObjectType
    {
      get
      {
        return "ACDB_DYNAMICBLOCKPROXYNODE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbDynamicBlockProxyNode";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfDynamicBlockProxyNode dynamicBlockProxyNode = (DxfDynamicBlockProxyNode) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dynamicBlockProxyNode == null)
      {
        dynamicBlockProxyNode = new DxfDynamicBlockProxyNode();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dynamicBlockProxyNode);
        dynamicBlockProxyNode.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dynamicBlockProxyNode;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_32.ClassNumber;
    }
  }
}
