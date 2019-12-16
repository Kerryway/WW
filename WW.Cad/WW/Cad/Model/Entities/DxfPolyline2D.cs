// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfPolyline2D
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

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
  public class DxfPolyline2D : DxfPolyline2DBase
  {
    private readonly DxfVertex2DCollection dxfVertex2DCollection_0 = new DxfVertex2DCollection();

    public DxfPolyline2D()
    {
    }

    public DxfPolyline2D(params DxfVertex2D[] vertices)
    {
      this.dxfVertex2DCollection_0.AddRange((IEnumerable<DxfVertex2D>) vertices);
    }

    public DxfPolyline2D(EntityColor color)
    {
      this.Color = color;
    }

    public DxfPolyline2D(IEnumerable<WW.Math.Point2D> vertices)
    {
      this.dxfVertex2DCollection_0.AddRange(vertices);
    }

    public DxfPolyline2D(EntityColor color, IEnumerable<WW.Math.Point2D> vertices)
      : this(color)
    {
      this.dxfVertex2DCollection_0.AddRange(vertices);
    }

    public DxfPolyline2D(params WW.Math.Point2D[] vertices)
    {
      this.dxfVertex2DCollection_0.AddRange(vertices);
    }

    public DxfPolyline2D(EntityColor color, params WW.Math.Point2D[] vertices)
      : this(color)
    {
      this.dxfVertex2DCollection_0.AddRange(vertices);
    }

    public DxfVertex2DCollection Vertices
    {
      get
      {
        return this.dxfVertex2DCollection_0;
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
      Matrix4D transformationWithOcs;
      this.method_13(matrix, undoGroup1, out transformationWithOcs);
      foreach (DxfVertex2D dxfVertex2D in (DxfHandledObjectCollection<DxfVertex2D>) this.dxfVertex2DCollection_0)
        dxfVertex2D.TransformMeInOcs(transformationWithOcs, undoGroup1);
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
      if (this.Thickness != 0.0)
        graphicElement2.Geometry.Extrusion = this.Thickness * Vector3D.ZAxis;
      Class940.smethod_12((DrawContext) context, (IVertex2DCollection) this.dxfVertex2DCollection_0, this.Closed, this.Transform, this.Thickness, this.DefaultStartWidth, this.DefaultEndWidth, graphicElement2.Geometry);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfPolyline2D dxfPolyline2D = (DxfPolyline2D) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfPolyline2D == null)
      {
        dxfPolyline2D = new DxfPolyline2D();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfPolyline2D);
        dxfPolyline2D.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfPolyline2D;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfVertex2D>) ((DxfPolyline2D) from).dxfVertex2DCollection_0)
        this.dxfVertex2DCollection_0.Add((DxfVertex2D) dxfHandledObject.Clone(cloneContext));
    }

    protected internal override void ExecuteDeepHelper(
      Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfVertex2D>) this.dxfVertex2DCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override void GetPolylines(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<IList<Polyline2D>> polylinesList1,
      out IList<IList<Polyline2D>> polylinesList2,
      out IList<FlatShape4D> shapes,
      out bool fill)
    {
      DxfHeader header = context.Model.Header;
      WW.Cad.Drawing.Polyline2D2WN polyline = new Class639(this.DefaultStartWidth, this.DefaultEndWidth).method_0((IVertex2DCollection) this.dxfVertex2DCollection_0, context.Config, this.Closed);
      polylinesList1 = (IList<IList<Polyline2D>>) new List<IList<Polyline2D>>();
      polylinesList2 = (IList<IList<Polyline2D>>) new List<IList<Polyline2D>>();
      shapes = (IList<FlatShape4D>) null;
      fill = false;
      if (polyline != null)
      {
        IList<Polyline2D> resultPolylines1;
        IList<Polyline2D> resultPolylines2;
        DxfUtil.smethod_25(context.Config, polyline, context.Config.ApplyLineType ? this.GetLineType(context) : (DxfLineType) null, context.TotalLineTypeScale * this.LineTypeScale, lineTypeScaler, this.Plinegen, out resultPolylines1, out resultPolylines2, out shapes, out fill);
        polylinesList1.Add(resultPolylines1);
        polylinesList2.Add(resultPolylines2);
        if (shapes != null && shapes.Count == 0)
          shapes = (IList<FlatShape4D>) null;
      }
      fill &= context.Model.Header.FillMode;
    }

    internal override void GetPolylines(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<IList<WW.Cad.Drawing.Polyline2D2N>> polylinesList1,
      out IList<IList<WW.Cad.Drawing.Polyline2D2N>> polylinesList2,
      out IList<FlatShape4D> shapes,
      out bool fill)
    {
      DxfHeader header = context.Model.Header;
      WW.Cad.Drawing.Polyline2D2WN polyline = new Class639(this.DefaultStartWidth, this.DefaultEndWidth).method_0((IVertex2DCollection) this.dxfVertex2DCollection_0, context.Config, this.Closed);
      polylinesList1 = (IList<IList<WW.Cad.Drawing.Polyline2D2N>>) new List<IList<WW.Cad.Drawing.Polyline2D2N>>();
      polylinesList2 = (IList<IList<WW.Cad.Drawing.Polyline2D2N>>) new List<IList<WW.Cad.Drawing.Polyline2D2N>>();
      shapes = (IList<FlatShape4D>) null;
      fill = false;
      IList<WW.Cad.Drawing.Polyline2D2N> resultPolylines1;
      IList<WW.Cad.Drawing.Polyline2D2N> resultPolylines2;
      if (polyline != null && DxfUtil.smethod_27(context.Config, polyline, context.Config.ApplyLineType ? this.GetLineType(context) : (DxfLineType) null, context.TotalLineTypeScale * this.LineTypeScale, lineTypeScaler, this.Plinegen, out resultPolylines1, out resultPolylines2, out shapes, out fill))
      {
        polylinesList1.Add(resultPolylines1);
        polylinesList2.Add(resultPolylines2);
        if (shapes != null && shapes.Count == 0)
          shapes = (IList<FlatShape4D>) null;
      }
      fill &= context.Model.Header.FillMode;
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      foreach (DxfVertex2D dxfVertex2D in (DxfHandledObjectCollection<DxfVertex2D>) this.dxfVertex2DCollection_0)
      {
        dxfVertex2D.vmethod_2((IDxfHandledObject) this);
        dxfVertex2D.vmethod_1(context);
      }
    }

    public override IList<Polygon2D> GetClipBoundary(GraphicsConfig graphicsConfig)
    {
      WW.Cad.Drawing.Polyline2DE polyline2De = Class639.Class640.smethod_0((IVertex2DCollection) this.dxfVertex2DCollection_0, graphicsConfig, this.Closed);
      Polygon2D polygon2D = new Polygon2D(polyline2De.Count);
      foreach (Point2DE point2De in (List<Point2DE>) polyline2De)
        polygon2D.Add(point2De.Position);
      return (IList<Polygon2D>) new Polygon2D[1]{ polygon2D };
    }
  }
}
