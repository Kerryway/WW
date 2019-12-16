// Decompiled with JetBrains decompiler
// Type: ns33.Class940
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace ns33
{
  internal static class Class940
  {
    [ThreadStatic]
    private static System.Drawing.Graphics graphics_0;
    [ThreadStatic]
    private static Image image_0;

    public static System.Drawing.Graphics MeasureGraphics
    {
      get
      {
        if (Class940.graphics_0 == null)
        {
          Class940.image_0 = (Image) new Bitmap(1, 1);
          Class940.graphics_0 = Class940.smethod_0(Class940.image_0);
        }
        return Class940.graphics_0;
      }
    }

    public static System.Drawing.Graphics smethod_0(Image image)
    {
      System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(image);
      graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      return graphics;
    }

    public static void DisposeThreadStaticObjects()
    {
      if (Class940.graphics_0 != null)
      {
        Class940.graphics_0.Dispose();
        Class940.graphics_0 = (System.Drawing.Graphics) null;
      }
      if (Class940.image_0 == null)
        return;
      Class940.image_0.Dispose();
      Class940.image_0 = (Image) null;
    }

    public static void smethod_1(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      IWireframeGraphicsFactory2 graphicsFactory,
      ArgbColor color,
      bool forText,
      bool fill,
      bool stroke,
      Polyline4D polyline)
    {
      graphicsFactory.BeginGeometry(entity, drawContext, color, false, fill, stroke, true);
      graphicsFactory.CreatePolyline(entity, polyline);
      graphicsFactory.EndGeometry();
    }

    public static void smethod_2(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      IWireframeGraphicsFactory2 graphicsFactory,
      ArgbColor color,
      bool forText,
      bool fill,
      bool stroke,
      IList<Polyline4D> polylines)
    {
      int count = polylines.Count;
      for (int index = 0; index < count; ++index)
      {
        graphicsFactory.BeginGeometry(entity, drawContext, color, false, fill, stroke, true);
        graphicsFactory.CreatePolyline(entity, polylines[index]);
        graphicsFactory.EndGeometry();
      }
    }

    public static void smethod_3(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      IWireframeGraphicsFactory2 graphicsFactory,
      ArgbColor color,
      bool forText,
      bool fill,
      bool stroke,
      IList<Polyline4D> polylines)
    {
      graphicsFactory.BeginGeometry(entity, drawContext, color, false, fill, stroke, true);
      int count = polylines.Count;
      for (int index = 0; index < count; ++index)
        graphicsFactory.CreatePolyline(entity, polylines[index]);
      graphicsFactory.EndGeometry();
    }

    public static void smethod_4(
      DxfEntity entity,
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory,
      IList<Polyline4D> polylines)
    {
      int count = polylines.Count;
      for (int index = 0; index < count; ++index)
        graphicsFactory.CreatePolyline(entity, polylines[index]);
    }

    internal static void Extrude(
      DxfEntity entity,
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      IList<WW.Math.Geometry.Polyline3D> polylines,
      bool areSurfaces,
      Vector3D extrusion)
    {
      foreach (WW.Math.Geometry.Polyline3D polyline in (IEnumerable<WW.Math.Geometry.Polyline3D>) polylines)
        Class940.Extrude(entity, context, graphicsFactory, polyline, areSurfaces, extrusion);
    }

    internal static void Extrude(
      DxfEntity entity,
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      WW.Math.Geometry.Polyline3D polyline,
      bool isSurface,
      Vector3D extrusion)
    {
      Interface41 transformer = context.GetTransformer();
      if (polyline.Count == 1)
      {
        WW.Math.Point3D start = polyline[0];
        Segment4D segment4D = DxfUtil.smethod_50(new Segment3D(start, start + extrusion), transformer);
        graphicsFactory.CreateSegment(segment4D.Start, segment4D.End);
      }
      else if (polyline.Count == 2)
      {
        WW.Math.Point3D point3D1 = polyline[0];
        WW.Math.Point3D point3D2 = polyline[1];
        Polyline4D boundary = DxfUtil.smethod_46(new WW.Math.Geometry.Polyline3D(true, new WW.Math.Point3D[4]{ point3D1, point3D2, point3D2 + extrusion, point3D1 + extrusion }), transformer);
        Class940.smethod_20(entity, context, graphicsFactory, boundary, (List<bool>) null);
      }
      else if (isSurface)
      {
        Polyline4D boundary1 = DxfUtil.smethod_46(polyline, transformer);
        Class940.smethod_20(entity, context, graphicsFactory, boundary1, (List<bool>) null);
        WW.Math.Point3D point3D1 = polyline[polyline.Count - 1];
        WW.Math.Point3D point3D2 = point3D1 + extrusion;
        WW.Math.Geometry.Polyline3D polyline1 = new WW.Math.Geometry.Polyline3D(polyline.Count, polyline.Closed);
        for (int index = 0; index < polyline.Count; ++index)
        {
          WW.Math.Point3D point3D3 = polyline[index];
          WW.Math.Point3D point3D4 = point3D3 + extrusion;
          polyline1.Add(point3D4);
          Polyline4D boundary2 = DxfUtil.smethod_46(new WW.Math.Geometry.Polyline3D(true, new WW.Math.Point3D[4]{ point3D3, point3D1, point3D2, point3D4 }), transformer);
          Class940.smethod_20(entity, context, graphicsFactory, boundary2, (List<bool>) null);
          point3D1 = point3D3;
          point3D2 = point3D4;
        }
        Polyline4D boundary3 = DxfUtil.smethod_46(polyline1, transformer);
        Class940.smethod_20(entity, context, graphicsFactory, boundary3, (List<bool>) null);
      }
      else
      {
        WW.Math.Point3D point3D1 = polyline[polyline.Count - 1];
        WW.Math.Point3D point3D2 = point3D1 + extrusion;
        WW.Math.Geometry.Polyline3D polyline3D = new WW.Math.Geometry.Polyline3D(polyline.Count, polyline.Closed);
        for (int index = 0; index < polyline.Count; ++index)
        {
          WW.Math.Point3D point3D3 = polyline[index];
          WW.Math.Point3D point3D4 = point3D3 + extrusion;
          polyline3D.Add(point3D4);
          Polyline4D boundary = DxfUtil.smethod_46(new WW.Math.Geometry.Polyline3D(true, new WW.Math.Point3D[4]{ point3D3, point3D1, point3D2, point3D4 }), transformer);
          Class940.smethod_20(entity, context, graphicsFactory, boundary, (List<bool>) null);
          point3D1 = point3D3;
          point3D2 = point3D4;
        }
      }
    }

    internal static void smethod_5(
      DxfEntity entity,
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      IList<WW.Cad.Drawing.Polyline2D2N> polylines,
      bool areSurfaces,
      Matrix4D transform,
      Vector3D normal,
      double extrusion)
    {
      int count = polylines.Count;
      for (int index = 0; index < count; ++index)
      {
        WW.Cad.Drawing.Polyline2D2N polyline = polylines[index];
        Class940.smethod_6(entity, context, graphicsFactory, polyline, areSurfaces, transform, normal, extrusion);
      }
    }

    internal static void smethod_6(
      DxfEntity entity,
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      WW.Cad.Drawing.Polyline2D2N polyline,
      bool isSurface,
      Matrix4D transform,
      Vector3D normal,
      double extrusion)
    {
      Interface41 transformer = (Interface41) context.GetTransformer().Clone();
      transformer.SetPreTransform(transform);
      Vector3D vector3D = transformer.Transform(new Vector3D(0.0, 0.0, extrusion));
      Vector4D vector4D1 = (Vector4D) vector3D;
      if (polyline.Count == 1)
      {
        Point2D2N point2D2N = polyline[0];
        Vector4D start = transformer.Transform(point2D2N.Position);
        graphicsFactory.CreateSegment(start, start + vector4D1);
      }
      else if (polyline.Count == 2)
      {
        Point2D2N point2D2N1 = polyline[0];
        Point2D2N point2D2N2 = polyline[1];
        Vector4D vector4D2 = transformer.Transform(point2D2N1.Position);
        Vector4D vector4D3 = transformer.Transform(point2D2N2.Position);
        Vector4D vector4D4 = vector4D2 + vector4D1;
        Vector4D vector4D5 = vector4D3 + vector4D1;
        if (isSurface)
          graphicsFactory.CreateQuadStrip((IList<Vector4D>) new Vector4D[2]
          {
            vector4D2,
            vector4D3
          }, (IList<Vector4D>) new Vector4D[2]
          {
            vector4D4,
            vector4D5
          }, (IList<Vector3D>) new Vector3D[2]
          {
            transformer.Transform(new Vector3D(point2D2N1.StartNormal, 0.0)),
            transformer.Transform(new Vector3D(point2D2N1.EndNormal, 0.0))
          }, 0, 1);
        else
          graphicsFactory.CreatePolyline((IList<Vector4D>) new Vector4D[4]
          {
            vector4D2,
            vector4D3,
            vector4D5,
            vector4D4
          }, true);
      }
      else
      {
        int count = polyline.Count;
        bool closed = polyline.Closed;
        Polyline4D polyline4DBottom = DxfUtil.smethod_47(polyline, transformer);
        Polyline4D polyline4DTop = new Polyline4D(count, closed);
        for (int index = 0; index < count; ++index)
          polyline4DTop.Add(polyline4DBottom[index] + vector3D);
        if (isSurface)
        {
          Class940.smethod_9(entity, graphicsFactory, polyline, transformer, polyline4DBottom, polyline4DTop);
        }
        else
        {
          for (int index = 0; index < count; ++index)
          {
            Vector4D start = polyline4DBottom[index];
            Vector4D end = polyline4DTop[index];
            graphicsFactory.CreateSegment(start, end);
          }
          graphicsFactory.CreatePolyline((IList<Vector4D>) polyline4DBottom, closed);
          graphicsFactory.CreatePolyline((IList<Vector4D>) polyline4DTop, closed);
        }
      }
    }

    internal static void smethod_7(
      DxfEntity entity,
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      IList<WW.Cad.Drawing.Polyline2D2N> polylinesA,
      IList<WW.Cad.Drawing.Polyline2D2N> polylinesB,
      bool areSurfaces,
      Matrix4D transform,
      Vector3D normal,
      double extrusion)
    {
      int count = polylinesA.Count;
      for (int index = 0; index < count; ++index)
      {
        WW.Cad.Drawing.Polyline2D2N polylineA = polylinesA[index];
        WW.Cad.Drawing.Polyline2D2N polylineB = polylinesB[index];
        Class940.smethod_8(entity, context, graphicsFactory, polylineA, polylineB, areSurfaces, transform, normal, extrusion);
      }
    }

    internal static void smethod_8(
      DxfEntity entity,
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      WW.Cad.Drawing.Polyline2D2N polylineA,
      WW.Cad.Drawing.Polyline2D2N polylineB,
      bool isSurface,
      Matrix4D transform,
      Vector3D normal,
      double extrusion)
    {
      Interface41 transformer = (Interface41) context.GetTransformer().Clone();
      transformer.SetPreTransform(transform);
      Vector3D vector3D = transformer.Transform(new Vector3D(0.0, 0.0, extrusion));
      Vector4D vector4D1 = (Vector4D) vector3D;
      if (polylineA.Count == 1)
      {
        Point2D2N point2D2N1 = polylineA[0];
        Point2D2N point2D2N2 = polylineB[0];
        if (point2D2N1.Position == point2D2N2.Position)
        {
          Vector4D start = transformer.Transform((WW.Math.Point3D) point2D2N1.Position);
          graphicsFactory.CreateSegment(start, start + vector4D1);
        }
        else
        {
          Vector4D vector4D2 = transformer.Transform(point2D2N1.Position);
          Vector4D vector4D3 = transformer.Transform(point2D2N2.Position);
          Vector4D[] vector4DArray = new Vector4D[4]{ vector4D2, vector4D3, vector4D3 + vector4D1, vector4D2 + vector4D1 };
          if (isSurface)
            graphicsFactory.CreateQuad((IList<Vector4D>) vector4DArray, (IList<bool>) null);
          else
            graphicsFactory.CreatePolyline((IList<Vector4D>) vector4DArray, true);
        }
      }
      else if (polylineA.Count == 2)
      {
        Point2D2N point2D2N1 = polylineA[0];
        Point2D2N point2D2N2 = polylineA[1];
        Point2D2N point2D2N3 = polylineB[0];
        Point2D2N point2D2N4 = polylineB[1];
        Vector4D vector4D2 = transformer.Transform(new WW.Math.Point3D(point2D2N1.Position, 0.0));
        Vector4D vector4D3 = transformer.Transform(new WW.Math.Point3D(point2D2N2.Position, 0.0));
        Vector4D vector4D4 = transformer.Transform(new WW.Math.Point3D(point2D2N3.Position, 0.0));
        Vector4D vector4D5 = transformer.Transform(new WW.Math.Point3D(point2D2N4.Position, 0.0));
        Vector4D vector4D6 = vector4D2 + vector4D1;
        Vector4D vector4D7 = vector4D3 + vector4D1;
        Vector4D vector4D8 = vector4D4 + vector4D1;
        Vector4D vector4D9 = vector4D5 + vector4D1;
        Vector4D[] vector4DArray1 = new Vector4D[4]{ vector4D2, vector4D3, vector4D5, vector4D4 };
        Vector4D[] vector4DArray2 = new Vector4D[4]{ vector4D6, vector4D7, vector4D9, vector4D8 };
        if (isSurface)
        {
          graphicsFactory.CreateQuad((IList<Vector4D>) vector4DArray1, (IList<bool>) null);
          graphicsFactory.CreateQuad((IList<Vector4D>) vector4DArray2, (IList<bool>) null);
          graphicsFactory.CreateQuad((IList<Vector4D>) new Vector4D[4]
          {
            vector4D2,
            vector4D4,
            vector4D8,
            vector4D6
          }, (IList<bool>) null);
          graphicsFactory.CreateQuad((IList<Vector4D>) new Vector4D[4]
          {
            vector4D3,
            vector4D5,
            vector4D9,
            vector4D7
          }, (IList<bool>) null);
          graphicsFactory.CreateQuadStrip((IList<Vector4D>) new Vector4D[2]
          {
            vector4D2,
            vector4D3
          }, (IList<Vector4D>) new Vector4D[2]
          {
            vector4D6,
            vector4D7
          }, (IList<Vector3D>) new Vector3D[2]
          {
            transformer.Transform(new Vector3D(point2D2N1.StartNormal, 0.0)),
            transformer.Transform(new Vector3D(point2D2N1.EndNormal, 0.0))
          }, 0, 1);
          graphicsFactory.CreateQuadStrip((IList<Vector4D>) new Vector4D[2]
          {
            vector4D8,
            vector4D9
          }, (IList<Vector4D>) new Vector4D[2]
          {
            vector4D4,
            vector4D5
          }, (IList<Vector3D>) new Vector3D[2]
          {
            transformer.Transform(new Vector3D(point2D2N3.StartNormal, 0.0)),
            transformer.Transform(new Vector3D(point2D2N3.EndNormal, 0.0))
          }, 0, 1);
        }
        else
        {
          graphicsFactory.CreatePolyline((IList<Vector4D>) vector4DArray1, true);
          graphicsFactory.CreatePolyline((IList<Vector4D>) vector4DArray2, true);
          for (int index = 0; index < 4; ++index)
            graphicsFactory.CreateSegment(vector4DArray1[index], vector4DArray2[index]);
        }
      }
      else
      {
        int count = polylineA.Count;
        int index1 = count - 1;
        bool closed = polylineA.Closed;
        Polyline4D polyline4DBottom1 = DxfUtil.smethod_47(polylineA, transformer);
        Polyline4D polyline4DTop1 = DxfUtil.smethod_47(polylineB, transformer);
        Polyline4D polyline4DTop2 = new Polyline4D(count, closed);
        Polyline4D polyline4DBottom2 = new Polyline4D(count, closed);
        for (int index2 = 0; index2 < count; ++index2)
        {
          polyline4DTop2.Add(polyline4DBottom1[index2] + vector3D);
          polyline4DBottom2.Add(polyline4DTop1[index2] + vector3D);
        }
        if (isSurface)
        {
          graphicsFactory.CreateQuadStrip((IList<Vector4D>) polyline4DBottom1, (IList<Vector4D>) polyline4DTop1, normal, closed);
          graphicsFactory.CreateQuadStrip((IList<Vector4D>) polyline4DTop2, (IList<Vector4D>) polyline4DBottom2, normal, closed);
          if (!closed)
          {
            graphicsFactory.CreateQuad((IList<Vector4D>) new Vector4D[4]
            {
              polyline4DBottom1[0],
              polyline4DTop2[0],
              polyline4DBottom2[0],
              polyline4DTop1[0]
            }, (IList<bool>) null);
            graphicsFactory.CreateQuad((IList<Vector4D>) new Vector4D[4]
            {
              polyline4DBottom1[index1],
              polyline4DTop2[index1],
              polyline4DBottom2[index1],
              polyline4DTop1[index1]
            }, (IList<bool>) null);
          }
          Class940.smethod_9(entity, graphicsFactory, polylineA, transformer, polyline4DBottom1, polyline4DTop2);
          Class940.smethod_9(entity, graphicsFactory, polylineB, transformer, polyline4DBottom2, polyline4DTop1);
          if (closed)
            return;
          Vector4D vector4D2 = polyline4DBottom1[0];
          Vector4D vector4D3 = polyline4DTop1[0];
          Vector4D vector4D4 = polyline4DTop2[0];
          Vector4D vector4D5 = polyline4DBottom2[0];
          graphicsFactory.CreateQuad((IList<Vector4D>) new Vector4D[4]
          {
            vector4D2,
            vector4D3,
            vector4D5,
            vector4D4
          }, (IList<bool>) null);
          int index2 = count - 1;
          Vector4D vector4D6 = polyline4DBottom1[index2];
          Vector4D vector4D7 = polyline4DTop1[index2];
          Vector4D vector4D8 = polyline4DTop2[index2];
          Vector4D vector4D9 = polyline4DBottom2[index2];
          graphicsFactory.CreateQuad((IList<Vector4D>) new Vector4D[4]
          {
            vector4D6,
            vector4D7,
            vector4D9,
            vector4D8
          }, (IList<bool>) null);
        }
        else
        {
          int index2 = 0;
          int num = 1;
          if (closed)
          {
            index2 = count - 1;
            num = 0;
          }
          Vector4D start = polyline4DBottom1[index2];
          Vector4D vector4D2 = polyline4DTop1[index2];
          Vector4D vector4D3 = polyline4DTop2[index2];
          Vector4D end = polyline4DBottom2[index2];
          for (int index3 = num; index3 < count; ++index3)
          {
            Vector4D vector4D4 = polyline4DBottom1[index3];
            Vector4D vector4D5 = polyline4DTop1[index3];
            Vector4D vector4D6 = polyline4DTop2[index3];
            Vector4D vector4D7 = polyline4DBottom2[index3];
            graphicsFactory.CreateSegment(start, vector4D2);
            graphicsFactory.CreateSegment(vector4D3, end);
            graphicsFactory.CreateSegment(start, vector4D3);
            graphicsFactory.CreateSegment(vector4D2, end);
            start = vector4D4;
            vector4D2 = vector4D5;
            vector4D3 = vector4D6;
            end = vector4D7;
          }
          graphicsFactory.CreatePolyline((IList<Vector4D>) polyline4DBottom1, closed);
          graphicsFactory.CreatePolyline((IList<Vector4D>) polyline4DTop1, closed);
          graphicsFactory.CreatePolyline((IList<Vector4D>) polyline4DTop2, closed);
          graphicsFactory.CreatePolyline((IList<Vector4D>) polyline4DBottom2, closed);
        }
      }
    }

    private static void smethod_9(
      DxfEntity entity,
      ISurfaceGraphicsFactory graphicsFactory,
      WW.Cad.Drawing.Polyline2D2N polyline2D,
      Interface41 transformer,
      Polyline4D polyline4DBottom,
      Polyline4D polyline4DTop)
    {
      int count = polyline2D.Count;
      int startVertexIndex = polyline2D.Closed ? count - 1 : 0;
      for (int endVertexIndex = polyline2D.Closed ? 0 : 1; endVertexIndex < count; ++endVertexIndex)
      {
        Point2D2N point2D2N1 = polyline2D[startVertexIndex];
        Point2D2N point2D2N2 = point2D2N1;
        int num1 = endVertexIndex;
        while (endVertexIndex < count)
        {
          Point2D2N point2D2N3 = polyline2D[endVertexIndex];
          if (!(point2D2N1.EndNormal != point2D2N3.StartNormal))
          {
            ++endVertexIndex;
            point2D2N1 = point2D2N3;
          }
          else
            break;
        }
        if (endVertexIndex == count)
          endVertexIndex = count - 1;
        Vector3D[] vector3DArray = new Vector3D[endVertexIndex - num1 + 2];
        vector3DArray[0] = transformer.Transform((Vector3D) point2D2N2.StartNormal);
        vector3DArray[1] = transformer.Transform((Vector3D) point2D2N2.EndNormal);
        int num2 = num1;
        int index1 = 2;
        while (num2 < endVertexIndex)
        {
          int index2 = num2 >= count ? 0 : num2;
          vector3DArray[index1] = transformer.Transform((Vector3D) polyline2D[index2].EndNormal);
          ++num2;
          ++index1;
        }
        graphicsFactory.CreateQuadStrip((IList<Vector4D>) polyline4DBottom, (IList<Vector4D>) polyline4DTop, (IList<Vector3D>) vector3DArray, startVertexIndex, endVertexIndex);
        startVertexIndex = endVertexIndex;
      }
    }

    internal static void smethod_10(
      DxfEntity entity,
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      IList<WW.Cad.Drawing.Polyline2D2N> polylinesA,
      IList<WW.Cad.Drawing.Polyline2D2N> polylinesB,
      Matrix4D transform,
      Vector3D normal,
      bool areSurfaces)
    {
      int count = polylinesA.Count;
      for (int index = 0; index < count; ++index)
      {
        WW.Cad.Drawing.Polyline2D2N polylineA = polylinesA[index];
        WW.Cad.Drawing.Polyline2D2N polylineB = polylinesB[index];
        Class940.smethod_11(entity, context, graphicsFactory, polylineA, polylineB, transform, normal, areSurfaces);
      }
    }

    internal static void smethod_11(
      DxfEntity entity,
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      WW.Cad.Drawing.Polyline2D2N polylineA,
      WW.Cad.Drawing.Polyline2D2N polylineB,
      Matrix4D transform,
      Vector3D normal,
      bool isSurface)
    {
      Interface41 transformer = (Interface41) context.GetTransformer().Clone();
      transformer.SetPreTransform(transform);
      if (polylineA.Count == 1)
      {
        Point2D2N point2D2N1 = polylineA[0];
        Point2D2N point2D2N2 = polylineB[0];
        if (point2D2N1.Position == point2D2N2.Position)
          graphicsFactory.CreatePoint(transformer.Transform(point2D2N1.Position));
        else
          graphicsFactory.CreateSegment(transformer.Transform(point2D2N1.Position), transformer.Transform(point2D2N2.Position));
      }
      else if (polylineA.Count == 2)
      {
        Point2D2N point2D2N1 = polylineA[0];
        Point2D2N point2D2N2 = polylineA[1];
        Point2D2N point2D2N3 = polylineB[0];
        Point2D2N point2D2N4 = polylineB[1];
        Vector4D[] vector4DArray = new Vector4D[4]{ transformer.Transform(point2D2N1.Position), transformer.Transform(point2D2N2.Position), transformer.Transform(point2D2N4.Position), transformer.Transform(point2D2N3.Position) };
        if (isSurface)
          graphicsFactory.CreateQuad((IList<Vector4D>) vector4DArray, (IList<bool>) null);
        else
          graphicsFactory.CreatePolyline((IList<Vector4D>) vector4DArray, true);
      }
      else
      {
        int count = polylineA.Count;
        bool closed = polylineA.Closed;
        Polyline4D polyline4D1 = DxfUtil.smethod_47(polylineA, transformer);
        Polyline4D polyline4D2 = DxfUtil.smethod_47(polylineB, transformer);
        if (isSurface)
        {
          graphicsFactory.CreateQuadStrip((IList<Vector4D>) polyline4D1, (IList<Vector4D>) polyline4D2, normal, closed);
        }
        else
        {
          int index1 = 0;
          int num = 1;
          if (closed)
          {
            index1 = count - 1;
            num = 0;
          }
          Vector4D start = polyline4D1[index1];
          Vector4D end = polyline4D2[index1];
          for (int index2 = num; index2 < count; ++index2)
          {
            Vector4D vector4D1 = polyline4D1[index2];
            Vector4D vector4D2 = polyline4D2[index2];
            graphicsFactory.CreateSegment(start, end);
            start = vector4D1;
            end = vector4D2;
          }
          graphicsFactory.CreatePolyline((IList<Vector4D>) polyline4D1, closed);
          graphicsFactory.CreatePolyline((IList<Vector4D>) polyline4D2, closed);
        }
      }
    }

    internal static void smethod_12(
      DrawContext context,
      IVertex2DCollection vertices,
      bool closed,
      Matrix4D transform,
      double thickness,
      double defaultStartWidth,
      double defaultEndWidth,
      WW.Cad.Drawing.Surface.Geometry geometry)
    {
      bool flag;
      if (flag = defaultStartWidth == 0.0 && defaultEndWidth == 0.0)
      {
        int num = closed ? vertices.Count : vertices.Count - 1;
        for (int index = 0; index < num; ++index)
        {
          IVertex2D ivertex2D = vertices.GetIVertex2D(index);
          if (ivertex2D.StartWidth != 0.0 || ivertex2D.EndWidth != 0.0)
          {
            flag = false;
            break;
          }
        }
      }
      if (flag)
      {
        if (thickness == 0.0)
          geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Polyline2DE(Class639.Class640.smethod_0(vertices, context.Config, closed), transform));
        else
          geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Polyline2D2N(Class639.Class641.smethod_0(vertices, context.Config, closed), transform));
      }
      else if (thickness == 0.0)
      {
        WW.Cad.Drawing.Polyline2D2WN wrappee = new Class639(defaultStartWidth, defaultEndWidth).method_0(vertices, context.Config, closed);
        if (wrappee == null || wrappee.Count <= 0)
          return;
        geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Polyline2D2WN(wrappee, context.Model.Header.FillMode, transform));
      }
      else
      {
        WW.Cad.Drawing.Polyline2D2WN wrappee = new Class639(defaultStartWidth, defaultEndWidth).method_0(vertices, context.Config, closed);
        if (wrappee == null || wrappee.Count <= 0)
          return;
        geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Polyline2D2WN(wrappee, context.Model.Header.FillMode, transform));
      }
    }

    internal static void smethod_13(
      DxfEntity entity,
      DrawContext.Surface context,
      WW.Cad.Drawing.Surface.Geometry geometry,
      IList<Polyline2D> polylinesA,
      IList<Polyline2D> polylinesB,
      Matrix4D transform,
      Vector3D normal,
      bool areSurfaces)
    {
      int count = polylinesA.Count;
      for (int index = 0; index < count; ++index)
      {
        Polyline2D polylineA = polylinesA[index];
        Polyline2D polylineB = polylinesB[index];
        Class940.smethod_14(entity, context, geometry, polylineA, polylineB, transform, normal, areSurfaces);
      }
    }

    internal static void smethod_14(
      DxfEntity entity,
      DrawContext.Surface context,
      WW.Cad.Drawing.Surface.Geometry geometry,
      Polyline2D polylineA,
      Polyline2D polylineB,
      Matrix4D transform,
      Vector3D normal,
      bool isSurface)
    {
      if (polylineA.Count == 1)
      {
        WW.Math.Point2D point1 = polylineA[0];
        WW.Math.Point2D point2 = polylineB[0];
        if (point1 == point2)
          geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Point(transform.TransformTo3D(point1)));
        else
          geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Segment(transform.TransformTo3D(point1), transform.TransformTo3D(point2)));
      }
      else if (polylineA.Count == 2)
      {
        WW.Math.Point2D point1 = polylineA[0];
        WW.Math.Point2D point2 = polylineA[1];
        WW.Math.Point2D point3 = polylineB[0];
        WW.Math.Point2D point4 = polylineB[1];
        if (isSurface)
          geometry.Add((IPrimitive) new Quad(transform.TransformTo3D(point1), transform.TransformTo3D(point2), transform.TransformTo3D(point4), transform.TransformTo3D(point3)));
        else
          geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive((IList<WW.Math.Point3D>) new WW.Math.Point3D[4]
          {
            transform.TransformTo3D(point1),
            transform.TransformTo3D(point2),
            transform.TransformTo3D(point4),
            transform.TransformTo3D(point3)
          }, true));
      }
      else
      {
        int count = polylineA.Count;
        bool closed = polylineA.Closed;
        WW.Math.Geometry.Polyline3D polyline3D1 = DxfUtil.smethod_42(polylineA, transform);
        WW.Math.Geometry.Polyline3D polyline3D2 = DxfUtil.smethod_42(polylineB, transform);
        if (isSurface)
        {
          geometry.Add((IPrimitive) new QuadStrip1((IList<WW.Math.Point3D>) polyline3D1, (IList<WW.Math.Point3D>) polyline3D2, normal, closed));
        }
        else
        {
          int index1 = 0;
          int num = 1;
          if (closed)
          {
            index1 = count - 1;
            num = 0;
          }
          WW.Math.Point3D start = polyline3D1[index1];
          WW.Math.Point3D end = polyline3D2[index1];
          for (int index2 = num; index2 < count; ++index2)
          {
            WW.Math.Point3D point3D1 = polyline3D1[index2];
            WW.Math.Point3D point3D2 = polyline3D2[index2];
            geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Segment(start, end));
            start = point3D1;
            end = point3D2;
          }
          geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive((IList<WW.Math.Point3D>) polyline3D1, closed));
          geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive((IList<WW.Math.Point3D>) polyline3D2, closed));
        }
      }
    }

    public static void smethod_15(
      DxfEntity entity,
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      IList<WW.Math.Geometry.Polyline3D> polylines)
    {
      Interface41 transformer = context.GetTransformer();
      foreach (WW.Math.Geometry.Polyline3D polyline in (IEnumerable<WW.Math.Geometry.Polyline3D>) polylines)
      {
        Polyline4D polyline4D = DxfUtil.smethod_46(polyline, transformer);
        graphicsFactory.CreatePolyline((IList<Vector4D>) polyline4D, polyline.Closed);
      }
    }

    public static void smethod_16(
      DxfEntity entity,
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      IList<WW.Math.Geometry.Polyline3D> polylines,
      bool areSurfaces)
    {
      foreach (WW.Math.Geometry.Polyline3D polyline in (IEnumerable<WW.Math.Geometry.Polyline3D>) polylines)
        Class940.smethod_17(entity, context, graphicsFactory, polyline, areSurfaces);
    }

    public static void smethod_17(
      DxfEntity entity,
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      WW.Math.Geometry.Polyline3D polyline,
      bool isSurface)
    {
      Interface41 transformer = context.GetTransformer();
      Polyline4D boundary = DxfUtil.smethod_46(polyline, transformer);
      if (isSurface)
        Class940.smethod_20(entity, context, graphicsFactory, boundary, (List<bool>) null);
      else
        graphicsFactory.CreatePolyline((IList<Vector4D>) boundary, polyline.Closed);
    }

    public static void smethod_18(
      DxfEntity entity,
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      WW.Math.Geometry.Polyline3D boundary,
      List<bool> edgeVisibleList)
    {
      Interface41 transformer = context.GetTransformer();
      Polyline4D boundary1 = DxfUtil.smethod_46(boundary, transformer);
      Class940.smethod_20(entity, context, graphicsFactory, boundary1, edgeVisibleList);
    }

    public static void smethod_19(
      DxfEntity entity,
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      List<WW.Math.Point3D> boundary,
      List<bool> edgeVisibleList)
    {
      Interface41 transformer = context.GetTransformer();
      Polyline4D boundary1 = DxfUtil.smethod_46(new WW.Math.Geometry.Polyline3D((IList<WW.Math.Point3D>) boundary), transformer);
      Class940.smethod_20(entity, context, graphicsFactory, boundary1, edgeVisibleList);
    }

    public static void smethod_20(
      DxfEntity entity,
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      Polyline4D boundary,
      List<bool> edgeVisibleList)
    {
      if (boundary.Count == 0)
        return;
      if (boundary.Count == 1)
        graphicsFactory.CreatePoint(boundary[0]);
      else if (boundary.Count == 2)
      {
        bool flag = true;
        if (edgeVisibleList.Count != 0 && !edgeVisibleList[0])
          flag = false;
        if (!flag)
          return;
        graphicsFactory.CreateSegment(boundary[0], boundary[1]);
      }
      else if (boundary.Count == 3)
      {
        bool[] flagArray = (bool[]) null;
        if (edgeVisibleList != null)
          flagArray = edgeVisibleList.ToArray();
        graphicsFactory.CreateTriangle(boundary[0], boundary[1], boundary[2], (IList<bool>) flagArray);
      }
      else if (boundary.Count == 4)
      {
        bool[] flagArray = (bool[]) null;
        if (edgeVisibleList != null)
          flagArray = edgeVisibleList.ToArray();
        graphicsFactory.CreateQuad((IList<Vector4D>) boundary.ToArray(), (IList<bool>) flagArray);
      }
      else
      {
        int count = boundary.Count;
        Polygon3D polygon3D = new Polygon3D(count);
        for (int index = 0; index < count; ++index)
          polygon3D.Add((WW.Math.Point3D) boundary[index]);
        Plane3D? plane = polygon3D.GetPlane();
        if (!plane.HasValue)
          return;
        Matrix4D matrix4D = Transformation4D.Translation(plane.Value.Distance * plane.Value.Normal) * Transformation4D.GetArbitraryCoordSystem(plane.Value.Normal);
        Matrix4D inverse = matrix4D.GetInverse();
        Polygon2D projection2D = polygon3D.GetProjection2D(inverse);
        List<Triangulator2D.Triangle> triangleList = new List<Triangulator2D.Triangle>();
        List<WW.Math.Point2D> point2DList = new List<WW.Math.Point2D>();
        Triangulator2D.Triangulate((IList<IList<WW.Math.Point2D>>) new Polygon2D[1]
        {
          projection2D
        }, (IList<Triangulator2D.Triangle>) triangleList, (IList<WW.Math.Point2D>) point2DList);
        foreach (Triangulator2D.Triangle triangle in triangleList)
          graphicsFactory.CreateTriangle(matrix4D.TransformTo4D(point2DList[triangle.I0]), matrix4D.TransformTo4D(point2DList[triangle.I1]), matrix4D.TransformTo4D(point2DList[triangle.I2]), (IList<bool>) null);
      }
    }

    internal static void Extrude(
      WW.Cad.Drawing.Surface.Geometry geometry,
      IList<WW.Math.Geometry.Polyline3D> polylines,
      bool areSurfaces,
      Vector3D extrusion)
    {
      foreach (WW.Math.Geometry.Polyline3D polyline in (IEnumerable<WW.Math.Geometry.Polyline3D>) polylines)
        Class940.Extrude(geometry, polyline, areSurfaces, extrusion);
    }

    internal static void Extrude(
      WW.Cad.Drawing.Surface.Geometry geometry,
      WW.Math.Geometry.Polyline3D polyline,
      bool isSurface,
      Vector3D extrusion)
    {
      if (polyline.Count == 1)
      {
        WW.Math.Point3D start = polyline[0];
        geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Segment(start, start + extrusion));
      }
      else if (polyline.Count == 2)
      {
        WW.Math.Point3D v0 = polyline[0];
        WW.Math.Point3D v1 = polyline[1];
        geometry.Add((IPrimitive) new Quad(v0, v1, v1 + extrusion, v0 + extrusion));
      }
      else if (isSurface)
      {
        Class940.smethod_22(geometry, (IList<WW.Math.Point3D>) polyline);
        WW.Math.Point3D v1 = polyline[polyline.Count - 1];
        WW.Math.Point3D v2 = v1 + extrusion;
        WW.Math.Geometry.Polyline3D polyline3D = new WW.Math.Geometry.Polyline3D(polyline.Count, polyline.Closed);
        for (int index = 0; index < polyline.Count; ++index)
        {
          WW.Math.Point3D v0 = polyline[index];
          WW.Math.Point3D v3 = v0 + extrusion;
          polyline3D.Add(v3);
          geometry.Add((IPrimitive) new Quad(v0, v1, v2, v3));
          v1 = v0;
          v2 = v3;
        }
        Class940.smethod_22(geometry, (IList<WW.Math.Point3D>) polyline3D);
      }
      else
      {
        WW.Math.Point3D v1 = polyline[polyline.Count - 1];
        WW.Math.Point3D v2 = v1 + extrusion;
        WW.Math.Geometry.Polyline3D polyline3D = new WW.Math.Geometry.Polyline3D(polyline.Count, polyline.Closed);
        for (int index = 0; index < polyline.Count; ++index)
        {
          WW.Math.Point3D v0 = polyline[index];
          WW.Math.Point3D v3 = v0 + extrusion;
          polyline3D.Add(v3);
          geometry.Add((IPrimitive) new Quad(v0, v1, v2, v3));
          v1 = v0;
          v2 = v3;
        }
      }
    }

    public static void smethod_21(
      DxfEntity entity,
      DrawContext.Surface context,
      WW.Cad.Drawing.Surface.Geometry geometry,
      WW.Math.Geometry.Polyline3D polyline,
      bool isSurface)
    {
      if (isSurface)
        Class940.smethod_22(geometry, (IList<WW.Math.Point3D>) polyline);
      else
        geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive(polyline));
    }

    public static void smethod_22(WW.Cad.Drawing.Surface.Geometry geometry, IList<WW.Math.Point3D> boundary)
    {
      if (boundary.Count == 0)
        return;
      if (boundary.Count == 1)
        geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Point(boundary[0]));
      else if (boundary.Count == 2)
        geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Segment(boundary[0], boundary[1]));
      else if (boundary.Count == 3)
        geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Triangle(boundary[0], boundary[1], boundary[2]));
      else if (boundary.Count == 4)
      {
        geometry.Add((IPrimitive) new Quad(boundary[0], boundary[1], boundary[2], boundary[3]));
      }
      else
      {
        int count = boundary.Count;
        Polygon3D polygon3D = new Polygon3D(count);
        for (int index = 0; index < count; ++index)
          polygon3D.Add(boundary[index]);
        Plane3D? plane = polygon3D.GetPlane();
        if (!plane.HasValue)
          return;
        Matrix4D matrix4D = Transformation4D.Translation(plane.Value.Distance * plane.Value.Normal) * Transformation4D.GetArbitraryCoordSystem(plane.Value.Normal);
        Matrix4D inverse = matrix4D.GetInverse();
        Polygon2D projection2D = polygon3D.GetProjection2D(inverse);
        List<Triangulator2D.Triangle> triangleList = new List<Triangulator2D.Triangle>();
        List<WW.Math.Point2D> point2DList = new List<WW.Math.Point2D>();
        Triangulator2D.Triangulate((IList<IList<WW.Math.Point2D>>) new Polygon2D[1]
        {
          projection2D
        }, (IList<Triangulator2D.Triangle>) triangleList, (IList<WW.Math.Point2D>) point2DList);
        foreach (Triangulator2D.Triangle triangle in triangleList)
          geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Triangle(matrix4D.TransformTo3D(point2DList[triangle.I0]), matrix4D.TransformTo3D(point2DList[triangle.I1]), matrix4D.TransformTo3D(point2DList[triangle.I2])));
      }
    }

    internal static void smethod_23(
      IPathDrawer pathDrawer,
      IEnumerable<IShape4D> shapes,
      WW.Cad.Model.Color color,
      short lineWeight)
    {
      foreach (IShape4D shape in shapes)
        pathDrawer.DrawPath(shape, color, lineWeight);
    }

    internal static void smethod_24(
      IPathDrawer pathDrawer,
      IEnumerable<FlatShape4D> shapes,
      WW.Cad.Model.Color color,
      short lineWeight,
      double extrusion)
    {
      foreach (FlatShape4D shape in shapes)
        pathDrawer.DrawPath(shape.FlatShape, shape.Transformation, color, lineWeight, shape.IsFilled, false, extrusion);
    }
  }
}
