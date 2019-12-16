// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockRepresentationData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns28;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockRepresentationData : DxfObject
  {
    private short short_0 = 1;
    private DxfObjectReference dxfObjectReference_3 = DxfObjectReference.Null;

    public short Version
    {
      get
      {
        return this.short_0;
      }
      set
      {
        this.short_0 = value;
      }
    }

    public DxfBlock DynamicBlock
    {
      get
      {
        return (DxfBlock) this.dxfObjectReference_3.Value;
      }
      set
      {
        this.dxfObjectReference_3 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public override string ObjectType
    {
      get
      {
        return "ACDB_BLOCKREPRESENTATION_DATA";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockRepresentationData";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockRepresentationData representationData = (DxfBlockRepresentationData) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (representationData == null)
      {
        representationData = new DxfBlockRepresentationData();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) representationData);
        representationData.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) representationData;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockRepresentationData representationData = (DxfBlockRepresentationData) from;
      this.Version = representationData.Version;
      this.DynamicBlock = Class906.smethod_0(cloneContext, representationData.DynamicBlock, false);
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return this.Model.Header.Dxf13OrHigher;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_22.ClassNumber;
    }
  }
}
