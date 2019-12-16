// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockPurgePreventer
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockPurgePreventer : DxfBlockRepresentationData
  {
    public override string ObjectType
    {
      get
      {
        return "ACDB_DYNAMICBLOCKPURGEPREVENTER_VERSION";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbDynamicBlockPurgePreventer";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockPurgePreventer blockPurgePreventer = (DxfBlockPurgePreventer) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (blockPurgePreventer == null)
      {
        blockPurgePreventer = new DxfBlockPurgePreventer();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) blockPurgePreventer);
        blockPurgePreventer.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) blockPurgePreventer;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_23.ClassNumber;
    }
  }
}
