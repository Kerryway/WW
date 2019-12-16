// Decompiled with JetBrains decompiler
// Type: ns0.Class473
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns33;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Math;
using WW.Math.Geometry;

namespace ns0
{
  internal class Class473 : IPathDrawer
  {
    private readonly DxfEntity dxfEntity_0;
    private readonly DrawContext.Surface surface_0;
    private readonly ISurfaceGraphicsFactory isurfaceGraphicsFactory_0;

    public Class473(
      DxfEntity entity,
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      this.dxfEntity_0 = entity;
      this.surface_0 = context;
      this.isurfaceGraphicsFactory_0 = graphicsFactory;
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
      ISurfaceGraphicsFactory graphicsFactory0 = this.isurfaceGraphicsFactory_0;
      IList<Polyline2D> flattened = (IList<Polyline2D>) ShapeTool.GetFlattened(path, this.surface_0.Config.ShapeFlattenEpsilon);
      this.isurfaceGraphicsFactory_0.SetColor(this.surface_0.GetPlotColor(this.dxfEntity_0, color));
      Interface41 transformer = (Interface41) this.surface_0.GetTransformer().Clone();
      transformer.SetPreTransform(transform);
      if (!filled)
      {
        IList<Polyline4D> polyline4DList1 = DxfUtil.smethod_48(flattened, transformer);
        foreach (Polyline4D polyline4D in (IEnumerable<Polyline4D>) polyline4DList1)
          graphicsFactory0.CreatePolyline((IList<Vector4D>) polyline4D, polyline4D.Closed);
        if (extrusion == 0.0)
          return;
        transformer.SetPreTransform(Transformation4D.Translation(0.0, 0.0, extrusion));
        IList<Polyline4D> polyline4DList2 = DxfUtil.smethod_48(flattened, transformer);
        foreach (Polyline4D polyline4D in (IEnumerable<Polyline4D>) polyline4DList2)
          graphicsFactory0.CreatePolyline((IList<Vector4D>) polyline4D, polyline4D.Closed);
        Polyline4D polyline4D1 = new Polyline4D(2);
        polyline4D1.Add(Vector4D.Zero);
        polyline4D1.Add(Vector4D.Zero);
        for (int index1 = polyline4DList1.Count - 1; index1 >= 0; --index1)
        {
          Polyline4D polyline4D2 = polyline4DList1[index1];
          Polyline4D polyline4D3 = polyline4DList2[index1];
          for (int index2 = polyline4D2.Count - 1; index2 >= 0; --index2)
          {
            polyline4D1[0] = polyline4D2[index2];
            polyline4D1[1] = polyline4D3[index2];
            graphicsFactory0.CreatePolyline((IList<Vector4D>) polyline4D1, false);
          }
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
        Polyline4D polyline4D1 = DxfUtil.smethod_49(polyline, transformer);
        if (extrusion == 0.0)
        {
          for (int index = 0; index < triangleList.Count; ++index)
          {
            Triangulator2D.Triangle triangle = triangleList[index];
            this.isurfaceGraphicsFactory_0.CreateTriangle(polyline4D1[triangle.I0], polyline4D1[triangle.I1], polyline4D1[triangle.I2], (IList<bool>) null);
          }
        }
        else
        {
          if (extrusion == 0.0)
            return;
          IList<Polyline4D> polyline4DList1 = DxfUtil.smethod_48(flattened, transformer);
          transformer.SetPreTransform(Transformation4D.Translation(0.0, 0.0, extrusion));
          Polyline4D polyline4D2 = DxfUtil.smethod_49(polyline, transformer);
          IList<Polyline4D> polyline4DList2 = DxfUtil.smethod_48(flattened, transformer);
          if (extrusion > 0.0)
          {
            for (int index = 0; index < triangleList.Count; ++index)
            {
              Triangulator2D.Triangle triangle = triangleList[index];
              this.isurfaceGraphicsFactory_0.CreateTriangle(polyline4D1[triangle.I0], polyline4D1[triangle.I2], polyline4D1[triangle.I1], (IList<bool>) null);
            }
            for (int index = 0; index < triangleList.Count; ++index)
            {
              Triangulator2D.Triangle triangle = triangleList[index];
              this.isurfaceGraphicsFactory_0.CreateTriangle(polyline4D2[triangle.I0], polyline4D2[triangle.I1], polyline4D2[triangle.I2], (IList<bool>) null);
            }
          }
          else
          {
            for (int index = 0; index < triangleList.Count; ++index)
            {
              Triangulator2D.Triangle triangle = triangleList[index];
              this.isurfaceGraphicsFactory_0.CreateTriangle(polyline4D1[triangle.I0], polyline4D1[triangle.I1], polyline4D1[triangle.I2], (IList<bool>) null);
            }
            for (int index = 0; index < triangleList.Count; ++index)
            {
              Triangulator2D.Triangle triangle = triangleList[index];
              this.isurfaceGraphicsFactory_0.CreateTriangle(polyline4D2[triangle.I0], polyline4D2[triangle.I2], polyline4D2[triangle.I1], (IList<bool>) null);
            }
          }
          for (int index1 = polyline4DList1.Count - 1; index1 >= 0; --index1)
          {
            Polyline4D polyline4D3 = polyline4DList1[index1];
            Polyline4D polyline4D4 = polyline4DList2[index1];
            Polyline2D polyline2D = flattened[index1];
            IList<Vector3D> normals = (IList<Vector3D>) new List<Vector3D>(polyline4D3.Count + 1);
            for (int index2 = 0; index2 < polyline4D3.Count; ++index2)
            {
              int index3 = (index2 + 1) % polyline4D3.Count;
              Vector2D vector2D = polyline2D[index3] - polyline2D[index2];
              normals.Add(transformer.Transform(new Vector3D(vector2D.Y, -vector2D.X, 0.0)));
            }
            normals.Add(normals[0]);
            this.isurfaceGraphicsFactory_0.CreateQuadStrip((IList<Vector4D>) polyline4D3, (IList<Vector4D>) polyline4D4, normals, 0, 0);
          }
        }
      }
    }
  }
}
