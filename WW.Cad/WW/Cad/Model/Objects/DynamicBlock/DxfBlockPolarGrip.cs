// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockPolarGrip
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockPolarGrip : DxfBlockGrip
  {
    public override string ObjectType
    {
      get
      {
        return "BLOCKPOLARGRIP";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockPolarGrip";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockPolarGrip dxfBlockPolarGrip = (DxfBlockPolarGrip) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfBlockPolarGrip == null)
      {
        dxfBlockPolarGrip = new DxfBlockPolarGrip();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfBlockPolarGrip);
        dxfBlockPolarGrip.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfBlockPolarGrip;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_26.ClassNumber;
    }
  }
}
