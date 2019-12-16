// Decompiled with JetBrains decompiler
// Type: ns0.Class0
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace ns0
{
  internal class Class0 : IPathDrawer
  {
    private readonly DxfEntity dxfEntity_0;
    private readonly DrawContext.Wireframe wireframe_0;
    private readonly IWireframeGraphicsFactory iwireframeGraphicsFactory_0;

    public Class0(
      DxfEntity entity,
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      this.dxfEntity_0 = entity;
      this.wireframe_0 = context;
      this.iwireframeGraphicsFactory_0 = graphicsFactory;
    }

    public void DrawPath(IShape4D shape, Color color, short lineWeight)
    {
      if (shape.IsEmpty)
        return;
      IShape4D shape1 = this.wireframe_0.GetTransformer().Transform(shape);
      if (shape1.IsEmpty)
        return;
      this.iwireframeGraphicsFactory_0.CreateShape(this.dxfEntity_0, this.wireframe_0, this.wireframe_0.GetPlotColor(this.dxfEntity_0, color), false, shape1);
    }

    public void DrawPath(
      IShape2D path,
      Matrix4D transform,
      Color color,
      short lineWeight,
      bool filled,
      bool forText,
      double extrusion)
    {
      if (!path.HasSegments)
        return;
      IClippingTransformer transformer = (IClippingTransformer) this.wireframe_0.GetTransformer().Clone();
      transformer.SetPreTransform(transform);
      IWireframeGraphicsFactory graphicsFactory0 = this.iwireframeGraphicsFactory_0;
      if (extrusion == 0.0)
      {
        IShape4D shape1 = (IShape4D) new FlatShape4D((IShape2D) (path as GeneralShape2D ?? new GeneralShape2D(path, true)), filled);
        IShape4D shape2 = transformer.Transform(shape1);
        if (shape2.IsEmpty)
          return;
        graphicsFactory0.CreateShape(this.dxfEntity_0, this.wireframe_0, this.wireframe_0.GetPlotColor(this.dxfEntity_0, color), forText, shape2);
      }
      else
      {
        IList<Polyline2D> flattened = (IList<Polyline2D>) ShapeTool.GetFlattened(path, this.wireframe_0.Config.ShapeFlattenEpsilon);
        IList<Polyline4D> polylines1 = DxfUtil.smethod_39(flattened, filled, transformer);
        ArgbColor plotColor = this.wireframe_0.GetPlotColor(this.dxfEntity_0, color);
        graphicsFactory0.CreatePathAsOne(this.dxfEntity_0, this.wireframe_0, plotColor, forText, polylines1, false, true);
        transformer.SetPreTransform(Transformation4D.Translation(0.0, 0.0, extrusion));
        IList<Polyline4D> polylines2 = DxfUtil.smethod_39(flattened, filled, transformer);
        graphicsFactory0.CreatePathAsOne(this.dxfEntity_0, this.wireframe_0, plotColor, forText, polylines2, false, true);
        for (int index1 = polylines1.Count - 1; index1 >= 0; --index1)
        {
          Polyline4D polyline4D1 = polylines1[index1];
          Polyline4D polyline4D2 = polylines2[index1];
          for (int index2 = polyline4D1.Count - 1; index2 >= 0; --index2)
            graphicsFactory0.CreateLine(this.dxfEntity_0, this.wireframe_0, plotColor, forText, polyline4D1[index2], polyline4D2[index2]);
        }
      }
    }

    public void DrawCharPath(
      IShape2D path,
      Matrix4D transform,
      Color color,
      short lineWeight,
      bool filled,
      double extrusion)
    {
      this.DrawPath(path, transform, color, lineWeight, filled, true, extrusion);
    }

    public bool IsSeparateCharDrawingPreferred()
    {
      return false;
    }
  }
}
