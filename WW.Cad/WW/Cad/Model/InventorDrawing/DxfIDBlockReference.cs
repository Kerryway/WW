// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.InventorDrawing.DxfIDBlockReference
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model.Entities;

namespace WW.Cad.Model.InventorDrawing
{
  public class DxfIDBlockReference : DxfInsert
  {
    private DxfObjectReference dxfObjectReference_8 = DxfObjectReference.Null;

    public DxfHandledObject Viewport
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_8.Value;
      }
      set
      {
        this.dxfObjectReference_8 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      if (!this.method_17((DrawContext) context))
        return;
      base.DrawInternal(context, graphicsFactory);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      if (!this.method_17((DrawContext) context))
        return;
      base.DrawInternal(context, graphicsFactory);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      if (!this.method_17((DrawContext) context))
        return;
      base.DrawInternal(context, graphicsFactory);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      if (!this.method_17((DrawContext) context))
        return;
      base.DrawInternal(context, graphics, parentGraphicElementBlock);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfIDBlockReference idBlockReference = (DxfIDBlockReference) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (idBlockReference == null)
      {
        idBlockReference = new DxfIDBlockReference();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) idBlockReference);
        idBlockReference.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) idBlockReference;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.short_6;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfIDBlockReference idBlockReference = (DxfIDBlockReference) from;
      if (idBlockReference.Viewport == null)
        this.Viewport = (DxfHandledObject) null;
      else if (cloneContext.SourceModel == cloneContext.TargetModel)
        this.Viewport = idBlockReference.Viewport;
      else
        this.Viewport = (DxfHandledObject) idBlockReference.Viewport.Clone(cloneContext);
    }

    private bool method_17(DrawContext context)
    {
      DrawContext rootContext = context.RootContext;
      if (rootContext is DrawContext.Wireframe.ModelToPaperSpace)
        return (rootContext as DrawContext.Wireframe.ModelToPaperSpace).Viewport == this.Viewport;
      return rootContext is DrawContext.Wireframe.PaperToPaperSpace || !(rootContext is DrawContext.Wireframe.ModelSpace);
    }
  }
}
