// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfBlockBegin
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using WW.Cad.Drawing;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model.Entities
{
  public class DxfBlockBegin : DxfEntity
  {
    public override string EntityType
    {
      get
      {
        return "BLOCK";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockBegin";
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
    }

    public override void Accept(IEntityVisitor visitor)
    {
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockBegin dxfBlockBegin = (DxfBlockBegin) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfBlockBegin == null)
      {
        dxfBlockBegin = new DxfBlockBegin();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfBlockBegin);
        dxfBlockBegin.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfBlockBegin;
    }

    internal void method_13(DxfModel model)
    {
      if (this.Layer != null)
        return;
      this.Layer = model.ZeroLayer;
    }

    internal DxfBlock Block
    {
      get
      {
        return (DxfBlock) this.OwnerObjectSoftReference;
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return 4;
    }

    internal override bool vmethod_13(bool blockContextIsPaperSpace)
    {
      return this.PaperSpace;
    }
  }
}
