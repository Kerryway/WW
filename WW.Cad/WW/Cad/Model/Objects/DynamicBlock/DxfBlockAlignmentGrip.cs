// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockAlignmentGrip
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockAlignmentGrip : DxfBlockGrip
  {
    private WW.Math.Vector3D vector3D_0;

    public WW.Math.Vector3D Alignment
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        this.vector3D_0 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "BLOCKALIGNMENTGRIP";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockAlignmentGrip";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockAlignmentGrip blockAlignmentGrip = (DxfBlockAlignmentGrip) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (blockAlignmentGrip == null)
      {
        blockAlignmentGrip = new DxfBlockAlignmentGrip();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) blockAlignmentGrip);
        blockAlignmentGrip.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) blockAlignmentGrip;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      this.Alignment = ((DxfBlockAlignmentGrip) from).Alignment;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_20.ClassNumber;
    }
  }
}
