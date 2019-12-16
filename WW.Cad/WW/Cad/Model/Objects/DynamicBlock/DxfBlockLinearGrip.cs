// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockLinearGrip
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockLinearGrip : DxfBlockGrip
  {
    private WW.Math.Vector3D vector3D_0;

    public WW.Math.Vector3D Distance
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
        return "BLOCKLINEARGRIP";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockLinearGrip";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockLinearGrip dxfBlockLinearGrip = (DxfBlockLinearGrip) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfBlockLinearGrip == null)
      {
        dxfBlockLinearGrip = new DxfBlockLinearGrip();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfBlockLinearGrip);
        dxfBlockLinearGrip.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfBlockLinearGrip;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      this.Distance = ((DxfBlockLinearGrip) from).Distance;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_24.ClassNumber;
    }
  }
}
