// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfRegion
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns33;
using ns7;
using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfRegion : DxfModelerGeometry, IClipBoundaryProvider
  {
    public override string EntityType
    {
      get
      {
        return "REGION";
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      IList<Polyline4D> polylines4D = this.GetPolylines4D(context.GetTransformer());
      if (polylines4D.Count <= 0)
        return;
      graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, polylines4D, false, true);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      IList<Polyline4D> polylines4D = this.GetPolylines4D(context.GetTransformer());
      if (polylines4D.Count <= 0)
        return;
      Class940.smethod_3((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, false, true, polylines4D);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      graphicsFactory.SetColor(context.GetPlotColor((DxfEntity) this));
      IList<Polyline3D> polylines = this.GetPolylines();
      Class940.smethod_16((DxfEntity) this, context, graphicsFactory, polylines, false);
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfRegion dxfRegion = (DxfRegion) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfRegion == null)
      {
        dxfRegion = new DxfRegion();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfRegion);
        dxfRegion.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfRegion;
    }

    private IList<Polyline4D> GetPolylines4D(IClippingTransformer transformer)
    {
      return DxfUtil.smethod_36(this.GetPolylines(), false, transformer);
    }

    private IList<Polyline3D> GetPolylines()
    {
      IList<Polyline3D> polyline3DList = (IList<Polyline3D>) new List<Polyline3D>();
      try
      {
        Class608 class608 = this.method_14(Class795.Enum30.const_0).method_3(new Class258(0.01, false));
        WW.Math.Point3D[] points = class608.Points;
        foreach (Class608.Interface36 wire in class608.Wires)
        {
          int[] indexes = wire.Indexes;
          bool closed = indexes.Length > 0 && indexes[0] == indexes[indexes.Length - 1];
          Polyline3D polyline3D = new Polyline3D(indexes.Length, closed);
          foreach (int index in indexes)
            polyline3D.Add(points[index]);
          polyline3DList.Add(polyline3D);
        }
      }
      catch (Exception0 ex)
      {
        Console.Error.WriteLine((object) ex);
      }
      catch (Exception ex)
      {
        Console.Error.WriteLine((object) ex);
      }
      return polyline3DList;
    }

    internal override short vmethod_6(Class432 w)
    {
      return 37;
    }

    public IList<Polygon2D> GetClipBoundary(GraphicsConfig graphicsConfig)
    {
      return (IList<Polygon2D>) new Polygon2D[0];
    }
  }
}
