// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfImage
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Entities
{
  public class DxfImage : DxfRasterImage
  {
    public override string EntityType
    {
      get
      {
        return "IMAGE";
      }
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfRasterImage dxfRasterImage = (DxfRasterImage) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfRasterImage == null)
      {
        dxfRasterImage = (DxfRasterImage) new DxfImage();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfRasterImage);
        dxfRasterImage.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfRasterImage;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.short_2;
    }
  }
}
