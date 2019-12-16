// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.ShapeTool
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;

namespace WW.Math.Geometry
{
  public static class ShapeTool
  {
    public static readonly IShape2D NullShape = (IShape2D) ShapeTool.Class42.class42_0;
    public const double DefaultEpsilon = -0.01;
    public const double DefaultEpsilonForBoundsCalculation = -0.05;
    public const double QuadToCubicCorrection = 0.666666666666667;

    public static void AddQuadBezierToBounds(Bounds2D bounds, Point2D p0, Point2D p1, Point2D p2)
    {
      bounds.Update(p0);
      bounds.Update(p2);
      ShapeTool.smethod_4(bounds, p0, p2, p1);
    }

    public static void AddCubicBezierToBounds(
      Bounds2D bounds,
      Point2D p0,
      Point2D p1,
      Point2D p2,
      Point2D p3)
    {
      bounds.Update(p0);
      bounds.Update(p3);
      ShapeTool.smethod_5(bounds, p0, p1, p2, p3);
    }

    public static Point2D GetQuadBezierPoint(double t, Point2D p0, Point2D p1, Point2D p2)
    {
      if (t == 0.0)
        return p0;
      if (t == 1.0)
        return p2;
      Vector2D vector2D1 = p1 - p0;
      Vector2D vector2D2 = p2 - p1;
      Point2D point2D1 = p0 + t * vector2D1;
      Point2D point2D2 = p1 + t * vector2D2;
      Vector2D vector2D3 = point2D1 - point2D2;
      return point2D1 + t * vector2D3;
    }

    public static Point2D GetCubicBezierPoint(
      double t,
      Point2D p0,
      Point2D p1,
      Point2D p2,
      Point2D p3)
    {
      if (t == 0.0)
        return p0;
      if (t == 1.0)
        return p3;
      Vector2D vector2D1 = p1 - p0;
      Vector2D vector2D2 = p2 - p1;
      Vector2D vector2D3 = p3 - p2;
      Point2D p0_1 = p0 + t * vector2D1;
      Point2D p1_1 = p1 + t * vector2D2;
      Point2D p2_1 = p2 + t * vector2D3;
      return ShapeTool.GetQuadBezierPoint(t, p0_1, p1_1, p2_1);
    }

    public static Bounds2D GetBounds(IShape2D shape)
    {
      Bounds2D bounds = new Bounds2D();
      shape.AddToBounds(bounds);
      return bounds;
    }

    public static void AddToBounds(Bounds2D bounds, ISegment2DIterator iterator)
    {
      if (!iterator.MoveNext())
        return;
      Point2D[] points = new Point2D[3];
      Point2D point2D = new Point2D();
      do
      {
        switch (iterator.Current(points, 0))
        {
          case SegmentType.MoveTo:
          case SegmentType.LineTo:
            point2D = points[0];
            bounds.Update(point2D);
            break;
          case SegmentType.QuadTo:
            ShapeTool.smethod_4(bounds, point2D, points[0], points[1]);
            point2D = points[1];
            bounds.Update(point2D);
            break;
          case SegmentType.CubicTo:
            ShapeTool.smethod_5(bounds, point2D, points[0], points[1], points[2]);
            point2D = points[2];
            bounds.Update(point2D);
            break;
        }
      }
      while (iterator.MoveNext());
    }

    public static Bounds2D GetBounds(IShape2D shape, Matrix2D transformation)
    {
      Bounds2D bounds = new Bounds2D();
      ShapeTool.AddToBounds(bounds, shape.CreateIterator(), transformation);
      return bounds;
    }

    public static void AddToBounds(
      Bounds2D bounds,
      ISegment2DIterator iterator,
      Matrix2D transformation)
    {
      if (!iterator.MoveNext())
        return;
      Point2D[] points = new Point2D[3];
      Point2D point2D = new Point2D();
      do
      {
        switch (iterator.Current(points, 0))
        {
          case SegmentType.MoveTo:
          case SegmentType.LineTo:
            point2D = transformation.Transform(points[0]);
            bounds.Update(point2D);
            break;
          case SegmentType.QuadTo:
            Point2D p1 = transformation.Transform(points[1]);
            ShapeTool.smethod_4(bounds, point2D, transformation.Transform(points[0]), p1);
            point2D = p1;
            bounds.Update(point2D);
            break;
          case SegmentType.CubicTo:
            Point2D p3 = transformation.Transform(points[2]);
            ShapeTool.smethod_5(bounds, point2D, transformation.Transform(points[0]), transformation.Transform(points[1]), p3);
            point2D = p3;
            bounds.Update(point2D);
            break;
        }
      }
      while (iterator.MoveNext());
    }

    public static Bounds2D GetBounds(IShape2D shape, Matrix3D transformation)
    {
      Bounds2D bounds = new Bounds2D();
      ShapeTool.AddToBounds(bounds, shape.CreateIterator(), transformation);
      return bounds;
    }

    public static void AddToBounds(
      Bounds2D bounds,
      ISegment2DIterator iterator,
      Matrix3D transformation)
    {
      if (!iterator.MoveNext())
        return;
      Point2D[] points = new Point2D[3];
      Point2D point2D = new Point2D();
      do
      {
        switch (iterator.Current(points, 0))
        {
          case SegmentType.MoveTo:
          case SegmentType.LineTo:
            point2D = transformation.Transform(points[0]);
            bounds.Update(point2D);
            break;
          case SegmentType.QuadTo:
            Point2D p1 = transformation.Transform(points[1]);
            ShapeTool.smethod_4(bounds, point2D, transformation.Transform(points[0]), p1);
            point2D = p1;
            bounds.Update(point2D);
            break;
          case SegmentType.CubicTo:
            Point2D p3 = transformation.Transform(points[2]);
            ShapeTool.smethod_5(bounds, point2D, transformation.Transform(points[0]), transformation.Transform(points[1]), p3);
            point2D = p3;
            bounds.Update(point2D);
            break;
        }
      }
      while (iterator.MoveNext());
    }

    public static bool AreEqual(IShape2D shape1, IShape2D shape2)
    {
      if (shape1 == shape2)
        return true;
      return ShapeTool.smethod_1(shape1.CreateIterator(), shape2.CreateIterator());
    }

    public static IShape2D[] SplitIntoUnbroken(IShape2D shape)
    {
      return (IShape2D[]) (shape as GeneralShape2D ?? new GeneralShape2D(shape, true)).GetUnbrokenShapes();
    }

    public static Matrix3D? GetTransformation(
      IShape2D shape1,
      IShape2D shape2,
      double accuracy)
    {
      if (!shape1.HasSegments || !shape2.HasSegments)
        return new Matrix3D?();
      ISegment2DIterator iterator1 = shape1.CreateIterator();
      ISegment2DIterator iterator2 = shape2.CreateIterator();
      if (iterator1.TotalPointCount != iterator2.TotalPointCount || iterator1.TotalSegmentCount != iterator2.TotalSegmentCount)
        return new Matrix3D?();
      if (iterator1.MoveNext() && iterator2.MoveNext())
      {
        Point2D[] point2DArray1 = new Point2D[iterator1.TotalPointCount];
        Point2D[] point2DArray2 = new Point2D[iterator2.TotalPointCount];
        double num1 = accuracy * accuracy;
        if (iterator1.Current(point2DArray1, 0) == iterator2.Current(point2DArray2, 0))
        {
          Matrix3D? nullable = new Matrix3D?();
          int offset = 1;
          if (!iterator1.MoveNext() || !iterator2.MoveNext())
            return new Matrix3D?(Transformation3D.Translation(point2DArray2[0] - point2DArray1[0]));
          do
          {
            int num2 = offset;
            SegmentType segmentType1 = iterator1.Current(point2DArray1, offset);
            SegmentType segmentType2 = iterator2.Current(point2DArray2, offset);
            if (segmentType1 == segmentType2)
            {
              offset += GeneralShape2D.int_1[(int) segmentType1];
              if (!nullable.HasValue && offset >= 3)
              {
                nullable = ShapeTool.smethod_0(point2DArray1, point2DArray2);
                num2 = 3;
              }
              if (nullable.HasValue)
              {
                int index = num2;
                while (true)
                {
                  if (index < offset)
                  {
                    if ((nullable.Value.Transform(point2DArray1[index]) - point2DArray2[index]).GetLengthSquared() <= num1)
                      ++index;
                    else
                      goto label_15;
                  }
                  else
                    break;
                }
              }
            }
            else
              goto label_14;
          }
          while (iterator1.MoveNext() && iterator2.MoveNext());
          goto label_16;
label_14:
          return new Matrix3D?();
label_15:
          return new Matrix3D?();
label_16:
          return nullable;
        }
      }
      return new Matrix3D?();
    }

    private static Matrix3D? smethod_0(Point2D[] p1, Point2D[] p2)
    {
      Matrix3D matrix3D1 = Transformation3D.Translation(-p1[0].X, -p1[0].Y);
      Matrix3D matrix3D2 = Transformation3D.Translation(-p2[0].X, -p2[0].Y);
      Point2D point2D1 = matrix3D1.Transform(p1[1]);
      Point2D point2D2 = matrix3D2.Transform(p2[1]);
      Matrix3D matrix3D3 = Transformation3D.Rotate(-System.Math.Atan2(point2D1.Y, point2D1.X));
      Matrix3D matrix3D4 = Transformation3D.Rotate(-System.Math.Atan2(point2D2.Y, point2D2.X));
      Point2D point2D3 = matrix3D3.Transform(matrix3D1.Transform(p1[2]));
      Point2D point2D4 = matrix3D4.Transform(matrix3D2.Transform(p2[2]));
      double num = ((Vector2D) point2D2).GetLength() / ((Vector2D) point2D1).GetLength();
      Matrix3D matrix3D5;
      if (point2D3.Y != 0.0)
      {
        double m01 = (point2D4.X - num * point2D3.X) / point2D3.Y;
        matrix3D5 = new Matrix3D(num, m01, 0.0, 0.0, point2D4.Y / point2D3.Y, 0.0, 0.0, 0.0, 1.0);
      }
      else
      {
        if (point2D3.X == 0.0)
          return new Matrix3D?();
        double m10 = (point2D4.Y - num * point2D3.Y) / point2D3.X;
        matrix3D5 = new Matrix3D(num, 0.0, 0.0, m10, num, 0.0, 0.0, 0.0, 1.0);
      }
      Matrix3D matrix3D6 = Transformation3D.Translation(p2[0].X, p2[0].Y) * Transformation3D.Rotate(System.Math.Atan2(point2D2.Y, point2D2.X)) * matrix3D5 * matrix3D3 * matrix3D1;
      if ((matrix3D6.Transform(p1[2]) - p2[2]).GetLength() / num < 0.0001)
        return new Matrix3D?(matrix3D6);
      return new Matrix3D?();
    }

    private static bool smethod_1(ISegment2DIterator it1, ISegment2DIterator it2)
    {
      int totalPointCount1 = it1.TotalPointCount;
      int totalPointCount2 = it2.TotalPointCount;
      if ((totalPointCount1 < 0 ? 1 : (totalPointCount2 < 0 ? 1 : 0)) == 0 && totalPointCount1 != totalPointCount2)
        return false;
      int totalSegmentCount1 = it1.TotalSegmentCount;
      int totalSegmentCount2 = it2.TotalSegmentCount;
      if ((totalSegmentCount1 < 0 ? 1 : (totalSegmentCount2 < 0 ? 1 : 0)) == 0 && totalSegmentCount1 != totalSegmentCount2)
        return false;
      bool flag1;
      bool flag2;
      if ((flag1 = it1.MoveNext()) & (flag2 = it2.MoveNext()))
      {
        Point2D[] points = new Point2D[6];
        do
        {
          SegmentType segmentType1 = it1.Current(points, 0);
          SegmentType segmentType2 = it2.Current(points, 3);
          if (segmentType1 == segmentType2)
          {
            for (int index = GeneralShape2D.int_1[(int) segmentType1] - 1; index >= 0; --index)
            {
              if (points[index] != points[index + 3])
                return false;
            }
          }
          else
            goto label_12;
        }
        while ((flag1 = it1.MoveNext()) & (flag2 = it2.MoveNext()));
        goto label_14;
label_12:
        return false;
      }
label_14:
      return flag1 == flag2;
    }

    public static Bounds2D GetBounds(IShape2D shape, Matrix4D transformation)
    {
      Bounds2D bounds = new Bounds2D();
      ShapeTool.AddToBounds(bounds, shape.CreateIterator(), transformation);
      return bounds;
    }

    public static void AddToBounds(
      Bounds2D bounds,
      ISegment2DIterator iterator,
      Matrix4D transformation)
    {
      if (!iterator.MoveNext())
        return;
      Point2D[] points = new Point2D[3];
      Point2D point2D = new Point2D();
      do
      {
        switch (iterator.Current(points, 0))
        {
          case SegmentType.MoveTo:
          case SegmentType.LineTo:
            point2D = transformation.Transform(points[0]);
            bounds.Update(point2D);
            break;
          case SegmentType.QuadTo:
            Point2D p1 = transformation.Transform(points[1]);
            ShapeTool.smethod_4(bounds, point2D, transformation.Transform(points[0]), p1);
            point2D = p1;
            bounds.Update(point2D);
            break;
          case SegmentType.CubicTo:
            Point2D p3 = transformation.Transform(points[2]);
            ShapeTool.smethod_5(bounds, point2D, transformation.Transform(points[0]), transformation.Transform(points[1]), p3);
            point2D = p3;
            bounds.Update(point2D);
            break;
        }
      }
      while (iterator.MoveNext());
    }

    public static Polyline2DCollection GetFlattened(
      IShape2D shape,
      double epsilon)
    {
      if (epsilon == 0.0)
        epsilon = -0.01;
      Polyline2DCollection polyline2Dcollection = new Polyline2DCollection();
      if (epsilon < 0.0)
      {
        Bounds2D bounds = ShapeTool.GetBounds(shape);
        if (!bounds.Initialized)
          return polyline2Dcollection;
        epsilon *= -System.Math.Max(bounds.Delta.X, bounds.Delta.Y);
      }
      epsilon *= epsilon;
      ISegment2DIterator iterator = shape.CreateIterator();
      if (iterator.MoveNext())
      {
        Point2D[] points = new Point2D[3];
        Polyline2D polyline = (Polyline2D) null;
        do
        {
          switch (iterator.Current(points, 0))
          {
            case SegmentType.MoveTo:
              polyline = new Polyline2D();
              polyline2Dcollection.Add(polyline);
              polyline.Add(points[0]);
              break;
            case SegmentType.LineTo:
              polyline.Add(points[0]);
              break;
            case SegmentType.QuadTo:
              ShapeTool.smethod_7(polyline, polyline[polyline.Count - 1], points[0], points[1], epsilon);
              break;
            case SegmentType.CubicTo:
              ShapeTool.smethod_11(polyline, polyline[polyline.Count - 1], points[0], points[1], points[2], epsilon);
              break;
            case SegmentType.Close:
              polyline.Closed = true;
              if (polyline.Count > 1 && polyline[polyline.Count - 1] == polyline[0])
              {
                polyline.RemoveAt(polyline.Count - 1);
                break;
              }
              break;
          }
        }
        while (iterator.MoveNext());
      }
      return polyline2Dcollection;
    }

    public static List<Polyline4D> GetFlattened(
      ITransformer4D transformation,
      IShape2D shape,
      double epsilon)
    {
      if (epsilon == 0.0)
        epsilon = -0.01;
      List<Polyline4D> polyline4DList = new List<Polyline4D>();
      if (epsilon < 0.0)
      {
        Bounds2D bounds = ShapeTool.GetBounds(shape);
        if (!bounds.Initialized)
          return polyline4DList;
        epsilon *= -System.Math.Max(bounds.Delta.X, bounds.Delta.Y);
      }
      epsilon *= epsilon;
      ISegment2DIterator iterator = shape.CreateIterator();
      if (iterator.MoveNext())
      {
        Point2D[] points = new Point2D[3];
        Polyline4D polyline = (Polyline4D) null;
        Point2D p0 = new Point2D();
        do
        {
          switch (iterator.Current(points, 0))
          {
            case SegmentType.MoveTo:
              polyline = new Polyline4D();
              polyline4DList.Add(polyline);
              polyline.Add(transformation.TransformTo4D(points[0]));
              p0 = points[0];
              break;
            case SegmentType.LineTo:
              polyline.Add(transformation.TransformTo4D(points[0]));
              p0 = points[0];
              break;
            case SegmentType.QuadTo:
              ShapeTool.smethod_8(polyline, transformation, p0, points[0], points[1], epsilon);
              p0 = points[1];
              break;
            case SegmentType.CubicTo:
              ShapeTool.smethod_12(polyline, transformation, p0, points[0], points[1], points[2], epsilon);
              p0 = points[2];
              break;
            case SegmentType.Close:
              polyline.Closed = true;
              if (polyline.Count > 1 && polyline[polyline.Count - 1] == polyline[0])
              {
                polyline.RemoveAt(polyline.Count - 1);
                break;
              }
              break;
          }
        }
        while (iterator.MoveNext());
      }
      return polyline4DList;
    }

    public static Pair<Point2D, Point2D> QuadToCubicBezier(
      Point2D p0,
      Point2D p1,
      Point2D p2)
    {
      return new Pair<Point2D, Point2D>(p0 + 2.0 / 3.0 * (p1 - p0), p2 + 2.0 / 3.0 * (p1 - p2));
    }

    public static void AddShapeToGraphicsPath(GraphicsPath path, IShape2D shape, bool connect)
    {
      using (GraphicsPath graphicsPath = ShapeTool.ToGraphicsPath(shape))
        path.AddPath(graphicsPath, connect);
    }

    public static void AddShapeToGraphicsPath(
      GraphicsPath path,
      ISegment2DIterator iterator,
      bool connect)
    {
      GeneralShape2D generalShape2D = new GeneralShape2D(iterator, true);
      path.AddPath((GraphicsPath) generalShape2D, connect);
    }

    public static GraphicsPath ToGraphicsPath(IShape2D shape)
    {
      return (GraphicsPath) (shape as GeneralShape2D ?? new GeneralShape2D(shape, true));
    }

    public static GraphicsPath ToGraphicsPath(IShape2D shape, Matrix3D transform)
    {
      return (GraphicsPath) new GeneralShape2D(shape, transform, true);
    }

    internal static string smethod_2(IShape2D shape)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("GeneralShape2D path = new GeneralShape2D();\n");
      Point2D[] points = new Point2D[3];
      ISegment2DIterator iterator = shape.CreateIterator();
      while (iterator.MoveNext())
      {
        switch (iterator.Current(points, 0))
        {
          case SegmentType.MoveTo:
            stringBuilder.Append("path.MoveTo(").Append(ShapeTool.smethod_3(points[0].X)).Append(",").Append(ShapeTool.smethod_3(points[0].Y)).Append(");\n");
            continue;
          case SegmentType.LineTo:
            stringBuilder.Append("path.LineTo(").Append(ShapeTool.smethod_3(points[0].X)).Append(",").Append(ShapeTool.smethod_3(points[0].Y)).Append(");\n");
            continue;
          case SegmentType.QuadTo:
            stringBuilder.Append("path.QuadTo(").Append(ShapeTool.smethod_3(points[0].X)).Append(",").Append(ShapeTool.smethod_3(points[0].Y)).Append(",").Append(ShapeTool.smethod_3(points[1].X)).Append(",").Append(ShapeTool.smethod_3(points[1].Y)).Append(");\n");
            continue;
          case SegmentType.CubicTo:
            stringBuilder.Append("path.CubicTo(").Append(ShapeTool.smethod_3(points[0].X)).Append(",").Append(ShapeTool.smethod_3(points[0].Y)).Append(",").Append(ShapeTool.smethod_3(points[1].X)).Append(",").Append(ShapeTool.smethod_3(points[1].Y)).Append(",").Append(ShapeTool.smethod_3(points[2].X)).Append(",").Append(ShapeTool.smethod_3(points[2].Y)).Append(");\n");
            continue;
          case SegmentType.Close:
            stringBuilder.Append("path.Close();\n");
            continue;
          default:
            continue;
        }
      }
      return stringBuilder.ToString();
    }

    private static string smethod_3(double v)
    {
      return v.ToString((IFormatProvider) CultureInfo.InvariantCulture);
    }

    private static void smethod_4(Bounds2D bounds, Point2D p0, Point2D p2, Point2D p1)
    {
      double num1 = p0.X - 2.0 * p1.X + p2.X;
      if (num1 != 0.0)
      {
        double t = (p0.X - p1.X) / num1;
        if (t > 0.0 && t < 1.0)
        {
          Point2D quadBezierPoint = ShapeTool.GetQuadBezierPoint(t, p0, p1, p2);
          bounds.Update(quadBezierPoint);
        }
      }
      double num2 = p0.Y - 2.0 * p1.Y + p2.Y;
      if (num2 == 0.0)
        return;
      double t1 = (p0.Y - p1.Y) / num2;
      if (t1 <= 0.0 || t1 >= 1.0)
        return;
      Point2D quadBezierPoint1 = ShapeTool.GetQuadBezierPoint(t1, p0, p1, p2);
      bounds.Update(quadBezierPoint1);
    }

    private static void smethod_5(
      Bounds2D bounds,
      Point2D p0,
      Point2D p1,
      Point2D p2,
      Point2D p3)
    {
      double num1 = -p0.X + 3.0 * p1.X - 3.0 * p2.X + p3.X;
      if (num1 != 0.0)
      {
        double num2 = -0.5 * (3.0 * p0.X - 6.0 * p1.X + 3.0 * p2.X) / num1;
        double num3 = (3.0 * p0.X - 3.0 * p1.X) / num1;
        double d = num2 * num2 + num3;
        if (d >= 0.0)
        {
          double num4 = System.Math.Sqrt(d);
          double t1 = num2 + num4;
          if (t1 > 0.0 && t1 < 1.0)
          {
            Point2D cubicBezierPoint = ShapeTool.GetCubicBezierPoint(t1, p0, p1, p2, p3);
            bounds.Update(cubicBezierPoint);
          }
          double t2 = num2 - num4;
          if (t2 > 0.0 && t2 < 1.0)
          {
            Point2D cubicBezierPoint = ShapeTool.GetCubicBezierPoint(t2, p0, p1, p2, p3);
            bounds.Update(cubicBezierPoint);
          }
        }
      }
      else
      {
        double num2 = 2.0 * (3.0 * p0.X - 6.0 * p1.X + 3.0 * p2.X);
        if (num2 != 0.0)
        {
          double t = 3.0 * (p0.X - p1.X) / num2;
          if (t > 0.0 && t < 1.0)
          {
            Point2D cubicBezierPoint = ShapeTool.GetCubicBezierPoint(t, p0, p1, p2, p3);
            bounds.Update(cubicBezierPoint);
          }
        }
      }
      double num5 = -p0.Y + 3.0 * p1.Y - 3.0 * p2.Y + p3.Y;
      if (num5 != 0.0)
      {
        double num2 = -0.5 * (3.0 * p0.Y - 6.0 * p1.Y + 3.0 * p2.Y) / num5;
        double num3 = (3.0 * p0.Y - 3.0 * p1.Y) / num5;
        double d = num2 * num2 + num3;
        if (d < 0.0)
          return;
        double num4 = System.Math.Sqrt(d);
        double t1 = num2 + num4;
        if (t1 > 0.0 && t1 < 1.0)
        {
          Point2D cubicBezierPoint = ShapeTool.GetCubicBezierPoint(t1, p0, p1, p2, p3);
          bounds.Update(cubicBezierPoint);
        }
        double t2 = num2 - num4;
        if (t2 <= 0.0 || t2 >= 1.0)
          return;
        Point2D cubicBezierPoint1 = ShapeTool.GetCubicBezierPoint(t2, p0, p1, p2, p3);
        bounds.Update(cubicBezierPoint1);
      }
      else
      {
        double num2 = 2.0 * (3.0 * p0.Y - 6.0 * p1.Y + 3.0 * p2.Y);
        if (num2 == 0.0)
          return;
        double t = 3.0 * (p0.Y - p1.Y) / num2;
        if (t <= 0.0 || t >= 1.0)
          return;
        Point2D cubicBezierPoint = ShapeTool.GetCubicBezierPoint(t, p0, p1, p2, p3);
        bounds.Update(cubicBezierPoint);
      }
    }

    private static double smethod_6(double value)
    {
      return value * value;
    }

    private static void smethod_7(
      Polyline2D polyline,
      Point2D p0,
      Point2D p1,
      Point2D p2,
      double epsilonSquared)
    {
      Vector2D dp02 = p2 - p0;
      Vector2D dp01 = p1 - p0;
      Vector2D dp12 = p2 - p1;
      if (ShapeTool.smethod_9(dp01, dp12, dp02, epsilonSquared))
      {
        polyline.Add(p1);
        polyline.Add(p2);
      }
      else
      {
        Point2D p1_1 = p0 + 0.5 * dp01;
        Point2D p1_2 = p1 + 0.5 * dp12;
        Vector2D vector2D = p1_2 - p1_1;
        Point2D point2D = p1_1 + 0.5 * vector2D;
        ShapeTool.smethod_7(polyline, p0, p1_1, point2D, epsilonSquared);
        ShapeTool.smethod_7(polyline, point2D, p1_2, p2, epsilonSquared);
      }
    }

    private static void smethod_8(
      Polyline4D polyline,
      ITransformer4D transformation,
      Point2D p0,
      Point2D p1,
      Point2D p2,
      double epsilonSquared)
    {
      Vector2D dp02 = p2 - p0;
      Vector2D dp01 = p1 - p0;
      Vector2D dp12 = p2 - p1;
      if (ShapeTool.smethod_9(dp01, dp12, dp02, epsilonSquared))
      {
        polyline.Add(transformation.TransformTo4D(p1));
        polyline.Add(transformation.TransformTo4D(p2));
      }
      else
      {
        Point2D p1_1 = p0 + 0.5 * dp01;
        Point2D p1_2 = p1 + 0.5 * dp12;
        Vector2D vector2D = p1_2 - p1_1;
        Point2D point2D = p1_1 + 0.5 * vector2D;
        ShapeTool.smethod_8(polyline, transformation, p0, p1_1, point2D, epsilonSquared);
        ShapeTool.smethod_8(polyline, transformation, point2D, p1_2, p2, epsilonSquared);
      }
    }

    private static bool smethod_9(
      Vector2D dp01,
      Vector2D dp12,
      Vector2D dp02,
      double epsilonSquared)
    {
      double lengthSquared = dp02.GetLengthSquared();
      if (0.25 * lengthSquared <= epsilonSquared)
      {
        if (dp01.GetLengthSquared() <= epsilonSquared)
          return dp12.GetLengthSquared() <= epsilonSquared;
        return false;
      }
      double num = epsilonSquared * lengthSquared;
      return ShapeTool.smethod_6(Vector2D.CrossProduct(dp01, dp02)) <= num;
    }

    private static bool smethod_10(
      Vector2D dp01,
      Vector2D dp12,
      Vector2D dp23,
      Vector2D dp03,
      double epsilonSquared)
    {
      double lengthSquared = dp03.GetLengthSquared();
      if (1.0 / 9.0 * lengthSquared <= epsilonSquared)
      {
        if (dp01.GetLengthSquared() <= epsilonSquared && dp12.GetLengthSquared() <= epsilonSquared)
          return dp23.GetLengthSquared() <= epsilonSquared;
        return false;
      }
      double num = epsilonSquared * lengthSquared;
      if (ShapeTool.smethod_6(Vector2D.CrossProduct(dp01, dp03)) <= num)
        return ShapeTool.smethod_6(Vector2D.CrossProduct(dp23, dp03)) <= num;
      return false;
    }

    private static void smethod_11(
      Polyline2D polyline,
      Point2D p0,
      Point2D p1,
      Point2D p2,
      Point2D p3,
      double epsilonSquared)
    {
      Vector2D dp01 = p1 - p0;
      Vector2D dp12 = p2 - p1;
      Vector2D dp23 = p3 - p2;
      if (ShapeTool.smethod_10(dp01, dp12, dp23, p3 - p0, epsilonSquared))
      {
        polyline.Add(p1);
        polyline.Add(p2);
        polyline.Add(p3);
      }
      else
      {
        Point2D p1_1 = p0 + 0.5 * dp01;
        Point2D point2D1 = p1 + 0.5 * dp12;
        Point2D p2_1 = p2 + 0.5 * dp23;
        Vector2D vector2D1 = point2D1 - p1_1;
        Vector2D vector2D2 = p2_1 - point2D1;
        Point2D p2_2 = p1_1 + 0.5 * vector2D1;
        Point2D p1_2 = point2D1 + 0.5 * vector2D2;
        Vector2D vector2D3 = p1_2 - p2_2;
        Point2D point2D2 = p2_2 + 0.5 * vector2D3;
        ShapeTool.smethod_11(polyline, p0, p1_1, p2_2, point2D2, epsilonSquared);
        ShapeTool.smethod_11(polyline, point2D2, p1_2, p2_1, p3, epsilonSquared);
      }
    }

    private static void smethod_12(
      Polyline4D polyline,
      ITransformer4D transformation,
      Point2D p0,
      Point2D p1,
      Point2D p2,
      Point2D p3,
      double epsilonSquared)
    {
      Vector2D dp01 = p1 - p0;
      Vector2D dp12 = p2 - p1;
      Vector2D dp23 = p3 - p2;
      if (ShapeTool.smethod_10(dp01, dp12, dp23, p3 - p0, epsilonSquared))
      {
        polyline.Add(transformation.TransformTo4D(p1));
        polyline.Add(transformation.TransformTo4D(p2));
        polyline.Add(transformation.TransformTo4D(p3));
      }
      else
      {
        Point2D p1_1 = p0 + 0.5 * dp01;
        Point2D point2D1 = p1 + 0.5 * dp12;
        Point2D p2_1 = p2 + 0.5 * dp23;
        Vector2D vector2D1 = point2D1 - p1_1;
        Vector2D vector2D2 = p2_1 - point2D1;
        Point2D p2_2 = p1_1 + 0.5 * vector2D1;
        Point2D p1_2 = point2D1 + 0.5 * vector2D2;
        Vector2D vector2D3 = p1_2 - p2_2;
        Point2D point2D2 = p2_2 + 0.5 * vector2D3;
        ShapeTool.smethod_12(polyline, transformation, p0, p1_1, p2_2, point2D2, epsilonSquared);
        ShapeTool.smethod_12(polyline, transformation, point2D2, p1_2, p2_1, p3, epsilonSquared);
      }
    }

    private class Class42 : IShape2D
    {
      public static readonly ShapeTool.Class42 class42_0 = new ShapeTool.Class42();

      private Class42()
      {
      }

      public ISegment2DIterator CreateIterator()
      {
        return (ISegment2DIterator) NullSegment2DIterator.Instance;
      }

      public void AddToBounds(Bounds2D bounds)
      {
      }

      public bool HasSegments
      {
        get
        {
          return false;
        }
      }
    }
  }
}
