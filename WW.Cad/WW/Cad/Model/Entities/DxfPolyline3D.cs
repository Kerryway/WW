// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfPolyline3D
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns1;
using ns2;
using ns33;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfPolyline3D : DxfPolyline3DBase
  {
    private readonly DxfVertex3DCollection dxfVertex3DCollection_0 = new DxfVertex3DCollection();

    public DxfPolyline3D()
    {
    }

    public DxfPolyline3D(EntityColor color)
    {
      this.Color = color;
    }

    public DxfPolyline3D(params DxfVertex3D[] vertices)
    {
      this.dxfVertex3DCollection_0.AddRange((IEnumerable<DxfVertex3D>) vertices);
    }

    public DxfPolyline3D(EntityColor color, params DxfVertex3D[] vertices)
    {
      this.Color = color;
      this.dxfVertex3DCollection_0.AddRange((IEnumerable<DxfVertex3D>) vertices);
    }

    public DxfPolyline3D(params WW.Math.Point3D[] vertices)
    {
      this.dxfVertex3DCollection_0.AddRange(vertices);
    }

    public DxfPolyline3D(EntityColor color, params WW.Math.Point3D[] vertices)
    {
      this.Color = color;
      this.dxfVertex3DCollection_0.AddRange(vertices);
    }

    public DxfPolyline3D(IEnumerable<WW.Math.Point3D> vertices)
    {
      this.dxfVertex3DCollection_0.AddRange(vertices);
    }

    public DxfPolyline3D(EntityColor color, IEnumerable<WW.Math.Point3D> vertices)
    {
      this.Color = color;
      this.dxfVertex3DCollection_0.AddRange(vertices);
    }

    public DxfVertex3DCollection Vertices
    {
      get
      {
        return this.dxfVertex3DCollection_0;
      }
    }

    public bool Plinegen
    {
      get
      {
        return (this.Flags & Enum21.flag_8) != Enum21.flag_0;
      }
      set
      {
        if (value)
          this.Flags |= Enum21.flag_8;
        else
          this.Flags &= ~Enum21.flag_8;
      }
    }

    public override void TransformMe(
      TransformConfig config,
      Matrix4D matrix,
      CommandGroup undoGroup)
    {
      CommandGroup undoGroup1 = (CommandGroup) null;
      if (undoGroup != null)
      {
        undoGroup1 = new CommandGroup((object) this);
        undoGroup.UndoStack.Push((ICommand) undoGroup1);
      }
      foreach (DxfEntity dxfEntity in (DxfHandledObjectCollection<DxfVertex3D>) this.dxfVertex3DCollection_0)
        dxfEntity.TransformMe(config, matrix, undoGroup1);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      IList<Polyline4D> polylines4D;
      IList<IShape4D> shapes;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), out polylines4D, out shapes);
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      if (polylines4D.Count > 0)
        graphicsFactory.CreatePath((DxfEntity) this, context, plotColor, false, polylines4D, false, true);
      if (shapes == null)
        return;
      Class940.smethod_23((IPathDrawer) new ns0.Class0((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      IList<Polyline4D> polylines4D;
      IList<IShape4D> shapes;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), out polylines4D, out shapes);
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      if (polylines4D.Count > 0)
        Class940.smethod_3((DxfEntity) this, context, graphicsFactory, plotColor, false, false, true, polylines4D);
      if (shapes == null)
        return;
      Class940.smethod_23((IPathDrawer) new Class396((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      graphicsFactory.SetColor(context.GetPlotColor((DxfEntity) this));
      IList<WW.Math.Geometry.Polyline3D> polylines;
      IList<FlatShape4D> shapes;
      this.GetPolylines((DrawContext) context, context.GetTransformer().LineTypeScaler, out polylines, out shapes);
      Interface41 transformer = (Interface41) context.GetTransformer().Clone();
      transformer.SetPreTransform(this.Transform);
      IList<Polyline4D> polyline4DList = DxfUtil.smethod_51(polylines, transformer);
      if (polyline4DList.Count > 0)
      {
        foreach (Polyline4D polyline4D in (IEnumerable<Polyline4D>) polyline4DList)
          graphicsFactory.CreatePolyline((IList<Vector4D>) polyline4D, polyline4D.Closed);
      }
      if (shapes == null)
        return;
      Class940.smethod_24((IPathDrawer) new Class473((DxfEntity) this, context, graphicsFactory), (IEnumerable<FlatShape4D>) shapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this), 0.0);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      DxfLineType lineType = this.GetLineType((DrawContext) context);
      bool plinegen = (this.Flags & Enum21.flag_8) != Enum21.flag_0;
      double lineTypeScale = context.TotalLineTypeScale * this.LineTypeScale;
      if (!graphics.AddExistingGraphicElement2(parentGraphicElementBlock, (DxfEntity) this, plotColor, lineType, lineTypeScale, plinegen))
        return;
      GraphicElement2 graphicElement2 = new GraphicElement2(plotColor, lineType, lineTypeScale, plinegen);
      graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, (GraphicElement1) graphicElement2);
      WW.Math.Geometry.Polyline3D polyline = this.method_13();
      graphicElement2.Geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive(polyline));
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfPolyline3D dxfPolyline3D = (DxfPolyline3D) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfPolyline3D == null)
      {
        dxfPolyline3D = new DxfPolyline3D();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfPolyline3D);
        dxfPolyline3D.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfPolyline3D;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfVertex3D>) ((DxfPolyline3D) from).dxfVertex3DCollection_0)
        this.dxfVertex3DCollection_0.Add((DxfVertex3D) dxfHandledObject.Clone(cloneContext));
    }

    protected internal override void ExecuteDeepHelper(
      Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfVertex3D>) this.dxfVertex3DCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IList<Polygon2D> GetClipBoundary(GraphicsConfig graphicsConfig)
    {
      WW.Math.Geometry.Polyline3D polyline3D = this.method_13();
      Polygon2D polygon2D = new Polygon2D(polyline3D.Count);
      foreach (WW.Math.Point3D point3D in (List<WW.Math.Point3D>) polyline3D)
        polygon2D.Add((WW.Math.Point2D) point3D);
      return (IList<Polygon2D>) new Polygon2D[1]{ polygon2D };
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      foreach (DxfVertex3D dxfVertex3D in (DxfHandledObjectCollection<DxfVertex3D>) this.dxfVertex3DCollection_0)
      {
        dxfVertex3D.vmethod_2((IDxfHandledObject) this);
        dxfVertex3D.vmethod_1(context);
      }
    }

    private void GetPolylines4D(
      DrawContext context,
      IClippingTransformer transformer,
      out IList<Polyline4D> polylines4D,
      out IList<IShape4D> shapes)
    {
      IList<WW.Math.Geometry.Polyline3D> polylines;
      IList<FlatShape4D> shapes1;
      this.GetPolylines(context, transformer.LineTypeScaler, out polylines, out shapes1);
      IClippingTransformer transformer1 = (IClippingTransformer) transformer.Clone();
      transformer1.SetPreTransform(this.Transform);
      polylines4D = DxfUtil.smethod_36(polylines, false, transformer1);
      shapes = DxfUtil.smethod_37((ICollection<FlatShape4D>) shapes1, transformer1);
    }

    private void GetPolylines(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<WW.Math.Geometry.Polyline3D> polylines,
      out IList<FlatShape4D> shapes)
    {
      WW.Math.Geometry.Polyline3D polyline3D = this.method_13();
      polylines = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>();
      shapes = (IList<FlatShape4D>) null;
      if (polyline3D == null || polyline3D.Count <= 0)
        return;
      DxfHeader header = context.Model.Header;
      GraphicsConfig config = context.Config;
      polylines.Add(polyline3D);
    }

    private WW.Math.Geometry.Polyline3D method_13()
    {
      WW.Math.Geometry.Polyline3D polyline3D = new WW.Math.Geometry.Polyline3D(this.Closed);
      foreach (DxfVertex3D dxfVertex3D in (DxfHandledObjectCollection<DxfVertex3D>) this.dxfVertex3DCollection_0)
        polyline3D.Add(dxfVertex3D.Position);
      return polyline3D;
    }
  }
}
