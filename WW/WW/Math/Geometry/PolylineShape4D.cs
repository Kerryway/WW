// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.PolylineShape4D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WW.Math.Geometry
{
  public class PolylineShape4D : IShape4D
  {
    private const double double_0 = 0.015625;
    private IList<Polyline4D> ilist_0;
    private readonly bool bool_0;

    public PolylineShape4D(IList<Polyline4D> polylines, bool filled)
    {
      this.ilist_0 = polylines;
      this.bool_0 = filled;
    }

    public bool IsFilled
    {
      get
      {
        return this.bool_0;
      }
    }

    public bool IsEmpty
    {
      get
      {
        if (this.ilist_0 != null)
          return this.ilist_0.Count == 0;
        return true;
      }
    }

    public InsideTestResult CheckClipping(IInsideTester4D region)
    {
      return !this.IsEmpty ? InsideTestResult.BothSides : InsideTestResult.Outside;
    }

    public void Transform(Matrix4D matrix)
    {
      foreach (Polyline4D polyline4D in (IEnumerable<Polyline4D>) this.ilist_0)
      {
        for (int index = polyline4D.Count - 1; index >= 0; --index)
          polyline4D[index] = matrix.Transform(polyline4D[index]);
      }
    }

    public void UpdateBounds(Bounds3D bounds, Matrix4D modelTransform)
    {
      foreach (Polyline4D polyline4D in (IEnumerable<Polyline4D>) this.ilist_0)
      {
        for (int index = polyline4D.Count - 1; index >= 0; --index)
          bounds.Update(modelTransform.Transform(polyline4D[index]));
      }
    }

    public IList<Polyline4D> ToPolylines4D(double shapeFlattenEpsilon)
    {
      IList<Polyline4D> polyline4DList = (IList<Polyline4D>) new List<Polyline4D>(this.ilist_0.Count);
      foreach (Polyline4D polyline4D1 in (IEnumerable<Polyline4D>) this.ilist_0)
      {
        Polyline4D polyline4D2 = new Polyline4D(polyline4D1.Count, polyline4D1.Closed);
        foreach (Vector4D vector4D in (List<Vector4D>) polyline4D1)
          polyline4D2.Add(vector4D);
        polyline4DList.Add(polyline4D2);
      }
      return polyline4DList;
    }

    public IShape2D ToShape2D(Matrix4D matrix)
    {
      Polyline2DCollection polyline2Dcollection = new Polyline2DCollection(this.ilist_0.Count);
      foreach (Polyline4D polyline4D in (IEnumerable<Polyline4D>) this.ilist_0)
      {
        Polyline2D polyline2D = new Polyline2D(polyline4D.Count, polyline4D.Closed);
        foreach (Vector4D vector in (List<Vector4D>) polyline4D)
          polyline2D.Add(matrix.TransformToPoint2D(vector));
        polyline2Dcollection.Add(polyline2D);
      }
      return (IShape2D) polyline2Dcollection;
    }

    public GraphicsPath ToGraphicsPath(Matrix4D transform)
    {
      if (this.ilist_0 == null || this.ilist_0.Count == 0)
        return NullShape4D.graphicsPath_0;
      GraphicsPath graphicsPath = new GraphicsPath();
      foreach (Polyline4D polyline4D in (IEnumerable<Polyline4D>) this.ilist_0)
      {
        PointF[] points = new PointF[polyline4D.Count];
        for (int index = 0; index < polyline4D.Count; ++index)
          points[index] = transform.TransformToPointF(polyline4D[index]);
        if (polyline4D.Closed)
        {
          graphicsPath.StartFigure();
          graphicsPath.AddPolygon(points);
        }
        else
        {
          graphicsPath.StartFigure();
          graphicsPath.AddLines(points);
        }
      }
      return graphicsPath;
    }

    public ISegment2DIterator CreateIterator(Matrix4D transform)
    {
      return (ISegment2DIterator) new PolylineShape4D.Class178(this, transform);
    }

    public IShape4D GetFlattened(ITransformer4D transformer, double shapeFlattenEpsilon)
    {
      IList<Polyline4D> polylines = (IList<Polyline4D>) new List<Polyline4D>(this.ilist_0.Count);
      for (int index1 = 0; index1 < this.ilist_0.Count; ++index1)
      {
        Polyline4D polyline4D1 = this.ilist_0[index1];
        Polyline4D polyline4D2 = new Polyline4D(polyline4D1.Count, polyline4D1.Closed);
        for (int index2 = 0; index2 < polyline4D1.Count; ++index2)
          polyline4D2.Add(transformer.Transform(polyline4D1[index2]));
        polylines.Add(polyline4D2);
      }
      return (IShape4D) new PolylineShape4D(polylines, this.bool_0);
    }

    public FlatShape4D ToFlatShape()
    {
      IList<Point3D> points1 = (IList<Point3D>) new List<Point3D>();
      foreach (List<Vector4D> vector4DList in (IEnumerable<Polyline4D>) this.ilist_0)
      {
        foreach (Vector4D vector4D in vector4DList)
        {
          points1.Add(vector4D.ToPoint3D());
          Matrix4D? nullable = PolylineShape4D.smethod_0(points1);
          if (nullable.HasValue)
          {
            Matrix4D transpose = nullable.Value.GetTranspose();
            Point3D point3D = points1[0];
            return this.method_0(Transformation4D.Translation((Vector3D) point3D) * nullable.Value, transpose * Transformation4D.Translation(-point3D.X, -point3D.Y, -point3D.Z));
          }
        }
      }
      if (points1.Count == 0)
        return new FlatShape4D(ShapeTool.NullShape, this.IsFilled);
      HashSet<Point3D> point3DSet = new HashSet<Point3D>((IEnumerable<Point3D>) points1);
      if (point3DSet.Count == 1)
      {
        Point3D point3D = points1[0];
        return this.method_0(Transformation4D.Translation((Vector3D) point3D), Transformation4D.Translation(-point3D.X, -point3D.Y, -point3D.Z));
      }
      IList<Point3D> points2 = (IList<Point3D>) new List<Point3D>((IEnumerable<Point3D>) point3DSet);
      Vector3D v = points2[1] - points2[0];
      v.Normalize();
      if (Vector3D.DotProduct(Vector3D.ZAxis, v) != 0.0)
      {
        Point3D point3D1 = points2[0];
        Point3D point3D2 = points2[0];
        if (point3D1.X != point3D2.X)
        {
          points2.Add(new Point3D(point3D2.X, point3D2.Y, point3D1.Z));
        }
        else
        {
          if (point3D1.Y == point3D2.Y)
            return this.method_0(Transformation4D.Translation((Vector3D) point3D1) * Transformation4D.RotateX(System.Math.PI / 2.0), Transformation4D.RotateX(-1.0 * System.Math.PI / 2.0) * Transformation4D.Translation(-point3D1.X, -point3D1.Y, -point3D1.Z));
          points2.Add(new Point3D(point3D2.X, point3D2.Y, point3D1.Z));
        }
        Matrix4D? nullable = PolylineShape4D.smethod_0(points2);
        if (!nullable.HasValue)
          return new FlatShape4D(ShapeTool.NullShape, this.IsFilled);
        Matrix4D transpose = nullable.Value.GetTranspose();
        Point3D point3D3 = points2[0];
        return this.method_0(Transformation4D.Translation((Vector3D) point3D3) * nullable.Value, transpose * Transformation4D.Translation(-point3D3.X, -point3D3.Y, -point3D3.Z));
      }
      Point3D point3D4 = points2[0];
      return this.method_0(Transformation4D.Translation((Vector3D) point3D4), Transformation4D.Translation(-point3D4.X, -point3D4.Y, -point3D4.Z));
    }

    private FlatShape4D method_0(Matrix4D transform, Matrix4D inverse)
    {
      GeneralShape2D generalShape2D = new GeneralShape2D();
      foreach (Polyline4D polyline4D in (IEnumerable<Polyline4D>) this.ilist_0)
      {
        Polyline2D polyline2D = new Polyline2D(polyline4D.Closed);
        foreach (Vector4D point in (List<Vector4D>) polyline4D)
          polyline2D.Add(inverse.TransformTo2D(point));
        generalShape2D.Append((IShape2D) polyline2D, false);
      }
      return new FlatShape4D((IShape2D) generalShape2D, transform, this.IsFilled);
    }

    private static Matrix4D? smethod_0(IList<Point3D> points)
    {
      if (points.Count < 3)
        return new Matrix4D?();
      Point3D point = points[0];
      Vector3D[] vector3DArray = new Vector3D[2];
      int num = 0;
      for (int index = 1; index < points.Count; ++index)
      {
        Vector3D v = points[index] - point;
        if (v.GetLengthSquared() > 0.0)
        {
          if (num == 0)
          {
            vector3DArray[0] = v;
            ++num;
          }
          else
          {
            Vector3D zaxis = Vector3D.CrossProduct(vector3DArray[0], v);
            double length = zaxis.GetLength();
            if (length > 0.0)
            {
              zaxis /= length;
              return new Matrix4D?(PolylineShape4D.smethod_1(zaxis));
            }
          }
        }
      }
      return new Matrix4D?();
    }

    private static Matrix4D smethod_1(Vector3D zaxis)
    {
      if (zaxis == Vector3D.ZAxis)
        return Matrix4D.Identity;
      zaxis.Normalize();
      Vector3D xaxis = System.Math.Abs(zaxis.X) >= 1.0 / 64.0 || System.Math.Abs(zaxis.Y) >= 1.0 / 64.0 ? Vector3D.CrossProduct(Vector3D.ZAxis, zaxis) : Vector3D.CrossProduct(Vector3D.YAxis, zaxis);
      xaxis.Normalize();
      return PolylineShape4D.smethod_2(xaxis, zaxis);
    }

    private static Matrix4D smethod_2(Vector3D xaxis, Vector3D zaxis)
    {
      Vector3D vector3D = Vector3D.CrossProduct(zaxis, xaxis);
      return new Matrix4D(xaxis.X, vector3D.X, zaxis.X, 0.0, xaxis.Y, vector3D.Y, zaxis.Y, 0.0, xaxis.Z, vector3D.Z, zaxis.Z, 0.0, 0.0, 0.0, 0.0, 1.0);
    }

    public void Dispose()
    {
      this.ilist_0 = (IList<Polyline4D>) null;
    }

    internal class Class178 : ISegment2DIterator
    {
      private int int_1 = -1;
      private int int_2 = -1;
      private int int_3 = -1;
      private IList<Polyline4D> ilist_0;
      private Matrix4D matrix4D_0;
      private int int_0;

      public Class178(PolylineShape4D shape, Matrix4D transform)
      {
        this.matrix4D_0 = transform;
        for (this.ilist_0 = shape.ilist_0; this.int_0 < this.ilist_0.Count; ++this.int_0)
        {
          int count = this.ilist_0[this.int_0].Count;
          if (count > 0)
          {
            if (count != 1)
              break;
            this.ilist_0[this.int_0].Add(this.ilist_0[this.int_0][0]);
            break;
          }
        }
      }

      public bool MoveNext()
      {
        if (this.int_0 >= this.ilist_0.Count)
          return false;
        ++this.int_1;
        Polyline4D polyline4D = this.ilist_0[this.int_0];
        if ((polyline4D.Closed ? (this.int_1 > polyline4D.Count ? 1 : 0) : (this.int_1 >= polyline4D.Count ? 1 : 0)) != 0)
        {
          this.int_1 = 0;
          while (++this.int_0 < this.ilist_0.Count)
          {
            int count = this.ilist_0[this.int_0].Count;
            if (count > 0)
            {
              if (count == 1)
              {
                this.ilist_0[this.int_0].Add(this.ilist_0[this.int_0][0]);
                break;
              }
              break;
            }
          }
          if (this.int_0 >= this.ilist_0.Count)
            return false;
        }
        return true;
      }

      public SegmentType CurrentType
      {
        get
        {
          if (this.int_1 == this.ilist_0[this.int_0].Count)
            return SegmentType.Close;
          return this.int_1 != 0 ? SegmentType.LineTo : SegmentType.MoveTo;
        }
      }

      public SegmentType Current(Point2D[] points, int offset)
      {
        if (this.int_1 == this.ilist_0[this.int_0].Count)
          return SegmentType.Close;
        points[offset] = this.matrix4D_0.TransformToPoint2D(this.ilist_0[this.int_0][this.int_1]);
        return this.int_1 != 0 ? SegmentType.LineTo : SegmentType.MoveTo;
      }

      public int TotalSegmentCount
      {
        get
        {
          if (this.int_3 == -1)
            this.method_0();
          return this.int_3;
        }
      }

      public int TotalPointCount
      {
        get
        {
          if (this.int_2 == -1)
            this.method_0();
          return this.int_2;
        }
      }

      private void method_0()
      {
        this.int_3 = 0;
        this.int_2 = 0;
        foreach (Polyline4D polyline4D in (IEnumerable<Polyline4D>) this.ilist_0)
        {
          this.int_2 += polyline4D.Count;
          this.int_3 += polyline4D.Count;
          if (polyline4D.Closed)
            ++this.int_3;
        }
      }
    }
  }
}
