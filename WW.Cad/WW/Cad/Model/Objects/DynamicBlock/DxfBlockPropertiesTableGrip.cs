// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockPropertiesTableGrip
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockPropertiesTableGrip : DxfBlockGrip
  {
    public override string ObjectType
    {
      get
      {
        return "BLOCKPROPERTIESTABLEGRIP";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockPropertiesTableGrip";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockPropertiesTableGrip propertiesTableGrip = (DxfBlockPropertiesTableGrip) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (propertiesTableGrip == null)
      {
        propertiesTableGrip = new DxfBlockPropertiesTableGrip();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) propertiesTableGrip);
        propertiesTableGrip.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) propertiesTableGrip;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_27.ClassNumber;
    }
  }
}
