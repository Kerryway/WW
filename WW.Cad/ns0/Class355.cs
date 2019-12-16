// Decompiled with JetBrains decompiler
// Type: ns0.Class355
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns33;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace ns0
{
  internal class Class355 : IPathDrawer
  {
    private readonly DxfEntity dxfEntity_0;
    private readonly DrawContext.Surface surface_0;
    private readonly Graphics graphics_0;
    private readonly IGraphicElementBlock igraphicElementBlock_0;
    private GraphicElement1Node graphicElement1Node_0;

    public Class355(
      DxfEntity entity,
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      this.dxfEntity_0 = entity;
      this.surface_0 = context;
      this.graphics_0 = graphics;
      this.igraphicElementBlock_0 = parentGraphicElementBlock;
    }

    public void DrawPath(IShape4D path, Color color, short lineWeight)
    {
      FlatShape4D flatShape = path.ToFlatShape();
      this.method_0(flatShape.FlatShape, color, flatShape.Transformation, flatShape.IsFilled, 0.0, false);
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
      this.method_0(path, color, transform, filled, extrusion, false);
    }

    public void DrawCharPath(
      IShape2D path,
      Matrix4D transform,
      Color color,
      short lineWeight,
      bool filled,
      double extrusion)
    {
      this.method_0(path, color, transform, filled, extrusion, true);
    }

    public bool IsSeparateCharDrawingPreferred()
    {
      return true;
    }

    private void method_0(
      IShape2D path,
      Color color,
      Matrix4D transform,
      bool filled,
      double extrusion,
      bool isChar)
    {
      if (!path.HasSegments)
        return;
      ArgbColor plotColor = this.surface_0.GetPlotColor(this.dxfEntity_0, color);
      if (this.graphicElement1Node_0 == null)
      {
        this.graphicElement1Node_0 = new GraphicElement1Node(plotColor);
        this.graphics_0.AddNewGraphicElement(this.dxfEntity_0, this.igraphicElementBlock_0, (GraphicElement1) this.graphicElement1Node_0);
      }
      else if (this.graphicElement1Node_0.Color != plotColor)
      {
        this.graphicElement1Node_0.Next = new GraphicElement1Node(plotColor);
        this.graphicElement1Node_0 = this.graphicElement1Node_0.Next;
      }
      IList<Polyline2D> flattened = (IList<Polyline2D>) ShapeTool.GetFlattened(path, this.surface_0.Config.ShapeFlattenEpsilon);
      if (!filled)
      {
        IList<WW.Math.Geometry.Polyline3D> polyline3DList1 = DxfUtil.smethod_41(flattened, transform);
        foreach (WW.Math.Geometry.Polyline3D polyline in (IEnumerable<WW.Math.Geometry.Polyline3D>) polyline3DList1)
          this.graphicElement1Node_0.Geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive(polyline));
        if (extrusion == 0.0)
          return;
        IList<WW.Math.Geometry.Polyline3D> polyline3DList2 = DxfUtil.smethod_41(flattened, transform * Transformation4D.Translation(0.0, 0.0, extrusion));
        foreach (WW.Math.Geometry.Polyline3D polyline in (IEnumerable<WW.Math.Geometry.Polyline3D>) polyline3DList2)
          this.graphicElement1Node_0.Geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive(polyline));
        for (int index1 = polyline3DList1.Count - 1; index1 >= 0; --index1)
        {
          WW.Math.Geometry.Polyline3D polyline3D1 = polyline3DList1[index1];
          WW.Math.Geometry.Polyline3D polyline3D2 = polyline3DList2[index1];
          for (int index2 = polyline3D1.Count - 1; index2 >= 0; --index2)
            this.graphicElement1Node_0.Geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Segment(polyline3D1[index2], polyline3D2[index2]));
        }
      }
      else
      {
        List<Triangulator2D.Triangle> triangleList;
        List<WW.Math.Point2D> point2DList;
        if (isChar)
        {
          Class454 class454 = this.surface_0.CharTriangulationCache.method_0(path, this.surface_0.Config);
          triangleList = class454.Triangles;
          point2DList = class454.Points;
        }
        else
        {
          triangleList = new List<Triangulator2D.Triangle>();
          point2DList = new List<WW.Math.Point2D>();
          IList<IList<WW.Math.Point2D>> polygons = (IList<IList<WW.Math.Point2D>>) new List<IList<WW.Math.Point2D>>();
          foreach (Polyline2D polyline2D in (IEnumerable<Polyline2D>) flattened)
            polygons.Add((IList<WW.Math.Point2D>) polyline2D);
          Triangulator2D.Triangulate(polygons, (IList<Triangulator2D.Triangle>) triangleList, (IList<WW.Math.Point2D>) point2DList);
        }
        Polyline2D polyline = new Polyline2D((IEnumerable<WW.Math.Point2D>) point2DList);
        WW.Math.Geometry.Polyline3D polyline3D1 = DxfUtil.smethod_42(polyline, transform);
        if (extrusion == 0.0)
        {
          for (int index = 0; index < triangleList.Count; ++index)
          {
            Triangulator2D.Triangle triangle = triangleList[index];
            this.graphicElement1Node_0.Geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Triangle(polyline3D1[triangle.I0], polyline3D1[triangle.I1], polyline3D1[triangle.I2]));
          }
        }
        else
        {
          if (extrusion == 0.0)
            return;
          IList<WW.Math.Geometry.Polyline3D> polyline3DList1 = DxfUtil.smethod_41(flattened, transform);
          Matrix4D transform1 = transform * Transformation4D.Translation(0.0, 0.0, extrusion);
          WW.Math.Geometry.Polyline3D polyline3D2 = DxfUtil.smethod_42(polyline, transform1);
          IList<WW.Math.Geometry.Polyline3D> polyline3DList2 = DxfUtil.smethod_41(flattened, transform1);
          if (extrusion > 0.0)
          {
            for (int index = 0; index < triangleList.Count; ++index)
            {
              Triangulator2D.Triangle triangle = triangleList[index];
              this.graphicElement1Node_0.Geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Triangle(polyline3D1[triangle.I0], polyline3D1[triangle.I2], polyline3D1[triangle.I1]));
            }
            for (int index = 0; index < triangleList.Count; ++index)
            {
              Triangulator2D.Triangle triangle = triangleList[index];
              this.graphicElement1Node_0.Geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Triangle(polyline3D2[triangle.I0], polyline3D2[triangle.I1], polyline3D2[triangle.I2]));
            }
          }
          else
          {
            for (int index = 0; index < triangleList.Count; ++index)
            {
              Triangulator2D.Triangle triangle = triangleList[index];
              this.graphicElement1Node_0.Geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Triangle(polyline3D1[triangle.I0], polyline3D1[triangle.I1], polyline3D1[triangle.I2]));
            }
            for (int index = 0; index < triangleList.Count; ++index)
            {
              Triangulator2D.Triangle triangle = triangleList[index];
              this.graphicElement1Node_0.Geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Triangle(polyline3D2[triangle.I0], polyline3D2[triangle.I2], polyline3D2[triangle.I1]));
            }
          }
          for (int index1 = polyline3DList1.Count - 1; index1 >= 0; --index1)
          {
            WW.Math.Geometry.Polyline3D polyline3D3 = polyline3DList1[index1];
            WW.Math.Geometry.Polyline3D polyline3D4 = polyline3DList2[index1];
            Polyline2D polyline2D = flattened[index1];
            IList<Vector3D> normals = (IList<Vector3D>) new List<Vector3D>(polyline3D3.Count + 1);
            for (int index2 = 0; index2 < polyline3D3.Count; ++index2)
            {
              int index3 = (index2 + 1) % polyline3D3.Count;
              Vector2D vector2D = polyline2D[index3] - polyline2D[index2];
              normals.Add(transform.Transform(new Vector3D(vector2D.Y, -vector2D.X, 0.0)));
            }
            normals.Add(normals[0]);
            this.graphicElement1Node_0.Geometry.Add((IPrimitive) new QuadStrip2((IList<WW.Math.Point3D>) polyline3D3, (IList<WW.Math.Point3D>) polyline3D4, normals, 0, 0));
          }
        }
      }
    }
  }
}
