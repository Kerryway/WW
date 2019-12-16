// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfPlaceHolder
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects
{
  public class DxfPlaceHolder : DxfObject
  {
    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.short_8;
    }

    public override string ObjectType
    {
      get
      {
        return "ACDBPLACEHOLDER";
      }
    }

    public override string AcClass
    {
      get
      {
        return (string) null;
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfPlaceHolder dxfPlaceHolder = (DxfPlaceHolder) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfPlaceHolder == null)
      {
        dxfPlaceHolder = new DxfPlaceHolder();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfPlaceHolder);
        dxfPlaceHolder.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfPlaceHolder;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      if (from.Handle != 15UL)
        return;
      this.SetHandle(from.Handle);
    }

    internal static DxfPlaceHolder smethod_2(bool useFixedHandles)
    {
      DxfPlaceHolder dxfPlaceHolder = new DxfPlaceHolder();
      if (useFixedHandles)
        dxfPlaceHolder.SetHandle(15UL);
      return dxfPlaceHolder;
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf15OrHigher;
    }
  }
}
