// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockLookupGrip
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockLookupGrip : DxfBlockGrip
  {
    public override string ObjectType
    {
      get
      {
        return "BLOCKLOOKUPGRIP";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockLookupGrip";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockLookupGrip dxfBlockLookupGrip = (DxfBlockLookupGrip) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfBlockLookupGrip == null)
      {
        dxfBlockLookupGrip = new DxfBlockLookupGrip();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfBlockLookupGrip);
        dxfBlockLookupGrip.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfBlockLookupGrip;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_25.ClassNumber;
    }
  }
}
