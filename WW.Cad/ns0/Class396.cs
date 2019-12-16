// Decompiled with JetBrains decompiler
// Type: ns0.Class396
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns33;
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
  internal class Class396 : IPathDrawer
  {
    private readonly DxfEntity dxfEntity_0;
    private readonly DrawContext.Wireframe wireframe_0;
    private readonly IWireframeGraphicsFactory2 iwireframeGraphicsFactory2_0;

    public Class396(
      DxfEntity entity,
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      this.dxfEntity_0 = entity;
      this.wireframe_0 = context;
      this.iwireframeGraphicsFactory2_0 = graphicsFactory;
    }

    public void DrawPath(IShape4D path, Color color, short lineWeight)
    {
      FlatShape4D flatShape = path.ToFlatShape();
      this.DrawPath(flatShape.FlatShape, flatShape.Transformation, color, lineWeight, flatShape.IsFilled, false, 0.0);
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
      if (extrusion == 0.0)
      {
        IShape4D shape1 = (IShape4D) new FlatShape4D(path, filled);
        IShape4D shape2 = transformer.Transform(shape1);
        if (shape2.IsEmpty)
          return;
        this.iwireframeGraphicsFactory2_0.BeginGeometry(this.dxfEntity_0, this.wireframe_0, this.wireframe_0.GetPlotColor(this.dxfEntity_0, color), false, filled, !filled, true);
        this.iwireframeGraphicsFactory2_0.CreateShape(this.dxfEntity_0, shape2);
        this.iwireframeGraphicsFactory2_0.EndGeometry();
      }
      else
      {
        IList<Polyline2D> flattened = (IList<Polyline2D>) ShapeTool.GetFlattened(path, this.wireframe_0.Config.ShapeFlattenEpsilon);
        IList<Polyline4D> polylines1 = DxfUtil.smethod_39(flattened, filled, transformer);
        ArgbColor plotColor = this.wireframe_0.GetPlotColor(this.dxfEntity_0, color);
        Class940.smethod_3(this.dxfEntity_0, this.wireframe_0, this.iwireframeGraphicsFactory2_0, plotColor, forText, false, true, polylines1);
        transformer.SetPreTransform(Transformation4D.Translation(0.0, 0.0, extrusion));
        IList<Polyline4D> polylines2 = DxfUtil.smethod_39(flattened, filled, transformer);
        Class940.smethod_3(this.dxfEntity_0, this.wireframe_0, this.iwireframeGraphicsFactory2_0, plotColor, forText, false, true, polylines2);
        Polyline4D polyline4D1 = new Polyline4D(2);
        polyline4D1.Add(Vector4D.Zero);
        polyline4D1.Add(Vector4D.Zero);
        IList<Polyline4D> polylines3 = (IList<Polyline4D>) new List<Polyline4D>(1);
        polylines3.Add(polyline4D1);
        for (int index1 = polylines1.Count - 1; index1 >= 0; --index1)
        {
          Polyline4D polyline4D2 = polylines1[index1];
          Polyline4D polyline4D3 = polylines2[index1];
          for (int index2 = polyline4D2.Count - 1; index2 >= 0; --index2)
          {
            polyline4D1[0] = polyline4D2[index2];
            polyline4D1[1] = polyline4D3[index2];
            Class940.smethod_2(this.dxfEntity_0, this.wireframe_0, this.iwireframeGraphicsFactory2_0, plotColor, forText, false, true, polylines3);
          }
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
