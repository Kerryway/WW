// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.GeneralShape2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WW.Math.Geometry
{
  public class GeneralShape2D : IShape2D
  {
    internal static readonly int[] int_1 = new int[5]{ 1, 1, 2, 3, 0 };
    private static readonly double double_0 = 4.0 * (System.Math.Sqrt(2.0) - 1.0) / 3.0;
    private const int int_0 = 16;
    private const FillMode fillMode_0 = FillMode.Alternate;
    private Point2D[] point2D_0;
    private int int_2;
    private SegmentType[] segmentType_0;
    private int int_3;
    private FillMode fillMode_1;
    private bool bool_0;
    private int int_4;

    private GeneralShape2D(GeneralShape2D baseShape, int sStart, int sEnd, int pStart, int pEnd)
    {
      this.int_2 = pEnd - pStart;
      this.point2D_0 = new Point2D[this.int_2];
      Array.Copy((Array) baseShape.point2D_0, pStart, (Array) this.point2D_0, 0, this.int_2);
      this.int_3 = sEnd - sStart;
      this.segmentType_0 = new SegmentType[this.int_3];
      Array.Copy((Array) baseShape.segmentType_0, sStart, (Array) this.segmentType_0, 0, this.int_3);
      this.bool_0 = true;
      if (baseShape.int_4 <= 0)
        return;
      foreach (SegmentType segmentType in this.segmentType_0)
      {
        if (segmentType == SegmentType.QuadTo)
          ++this.int_4;
      }
    }

    public GeneralShape2D()
      : this(16, 16, FillMode.Alternate)
    {
    }

    public GeneralShape2D(FillMode fillMode)
      : this(16, 16, fillMode)
    {
    }

    public GeneralShape2D(int segmentCapacity, int pointCapacity)
      : this(segmentCapacity, pointCapacity, FillMode.Alternate)
    {
    }

    public GeneralShape2D(int segmentCapacity, int pointCapacity, FillMode fillMode)
    {
      if (segmentCapacity <= 0)
        segmentCapacity = 16;
      if (pointCapacity <= 0)
        pointCapacity = 16;
      this.point2D_0 = new Point2D[pointCapacity];
      this.segmentType_0 = new SegmentType[segmentCapacity];
      this.fillMode_1 = fillMode;
    }

    public GeneralShape2D(ISegment2DIterator iterator)
    {
      int totalPointCount = iterator.TotalPointCount;
      this.point2D_0 = new Point2D[totalPointCount > 0 ? totalPointCount : 16];
      int totalSegmentCount = iterator.TotalSegmentCount;
      this.segmentType_0 = new SegmentType[totalSegmentCount > 0 ? totalSegmentCount : 16];
      this.Append(iterator, false);
    }

    public GeneralShape2D(ISegment2DIterator iterator, bool fixate)
      : this(iterator)
    {
      if (!fixate)
        return;
      this.Fixate();
    }

    public GeneralShape2D(ISegment2DIterator iterator, Matrix2D transformation, bool fixate)
      : this(iterator)
    {
      this.TransformBy(transformation);
      if (!fixate)
        return;
      this.Fixate();
    }

    public GeneralShape2D(ISegment2DIterator iterator, Matrix2D transformation)
      : this(iterator, transformation, false)
    {
    }

    public GeneralShape2D(ISegment2DIterator iterator, Matrix3D transformation, bool fixate)
      : this(iterator)
    {
      this.TransformBy(transformation);
      if (!fixate)
        return;
      this.Fixate();
    }

    public GeneralShape2D(ISegment2DIterator iterator, Matrix3D transformation)
      : this(iterator, transformation, false)
    {
    }

    public GeneralShape2D(ISegment2DIterator iterator, Matrix4D transformation, bool fixate)
      : this(iterator)
    {
      this.TransformBy(transformation);
      if (!fixate)
        return;
      this.Fixate();
    }

    public GeneralShape2D(ISegment2DIterator iterator, Matrix4D transformation)
      : this(iterator, transformation, false)
    {
    }

    public GeneralShape2D(IShape2D shape)
      : this(shape.CreateIterator())
    {
      this.method_2(shape);
    }

    public GeneralShape2D(IShape2D shape, bool fixate)
      : this(shape.CreateIterator(), fixate)
    {
      this.method_2(shape);
    }

    public GeneralShape2D(IShape2D shape, Matrix2D transformation)
      : this(shape.CreateIterator(), transformation)
    {
      this.method_2(shape);
    }

    public GeneralShape2D(IShape2D shape, Matrix2D transformation, bool fixate)
      : this(shape.CreateIterator(), transformation, fixate)
    {
      this.method_2(shape);
    }

    public GeneralShape2D(IShape2D shape, Matrix3D transformation)
      : this(shape.CreateIterator(), transformation)
    {
      this.method_2(shape);
    }

    public GeneralShape2D(IShape2D shape, Matrix3D transformation, bool fixate)
      : this(shape.CreateIterator(), transformation, fixate)
    {
      this.method_2(shape);
    }

    public GeneralShape2D(IShape2D shape, Matrix4D transformation)
      : this(shape.CreateIterator(), transformation)
    {
      this.method_2(shape);
    }

    public GeneralShape2D(IShape2D shape, Matrix4D transformation, bool fixate)
      : this(shape.CreateIterator(), transformation, fixate)
    {
      this.method_2(shape);
    }

    public void Append(ISegment2DIterator iterator, bool connect)
    {
      this.method_3();
      while (iterator.MoveNext())
      {
        SegmentType segmentType = iterator.CurrentType;
        if (connect)
        {
          connect = false;
          segmentType = SegmentType.LineTo;
        }
        if (segmentType == SegmentType.QuadTo)
          ++this.int_4;
        int pointCount = GeneralShape2D.int_1[(int) segmentType];
        this.method_4(pointCount);
        int num = (int) iterator.Current(this.point2D_0, this.int_2);
        this.segmentType_0[this.int_3++] = segmentType;
        this.int_2 += pointCount;
      }
    }

    public void Append(ISegment2DIterator iterator, bool connect, Matrix2D transform)
    {
      int int2 = this.int_2;
      this.Append(iterator, connect);
      this.method_6(transform, int2, this.int_2);
    }

    public void Append(ISegment2DIterator iterator, bool connect, Matrix3D transform)
    {
      int int2 = this.int_2;
      this.Append(iterator, connect);
      this.method_7(transform, int2, this.int_2);
    }

    public void Append(ISegment2DIterator iterator, bool connect, Matrix4D transform)
    {
      int int2 = this.int_2;
      this.Append(iterator, connect);
      this.method_8(transform, int2, this.int_2);
    }

    public void Append(IShape2D shape, bool connect)
    {
      this.Append(shape.CreateIterator(), connect);
    }

    public void Append(IShape2D shape, bool connect, Matrix2D transform)
    {
      this.Append(shape.CreateIterator(), connect, transform);
    }

    public void Append(IShape2D shape, bool connect, Matrix3D transform)
    {
      this.Append(shape.CreateIterator(), connect, transform);
    }

    public void Append(IShape2D shape, bool connect, Matrix4D transform)
    {
      this.Append(shape.CreateIterator(), connect, transform);
    }

    public void TransformBy(Matrix2D transformation)
    {
      this.method_6(transformation, 0, this.int_2);
    }

    public void TransformBy(Matrix3D transformation)
    {
      this.method_7(transformation, 0, this.int_2);
    }

    public void TransformBy(Matrix4D transformation)
    {
      this.method_8(transformation, 0, this.int_2);
    }

    public void MoveTo(double x, double y)
    {
      this.method_3();
      this.method_4(1);
      this.segmentType_0[this.int_3++] = SegmentType.MoveTo;
      this.point2D_0[this.int_2++] = new Point2D(x, y);
    }

    private void method_0(double x, double y)
    {
      this.method_4(1);
      this.segmentType_0[this.int_3++] = SegmentType.MoveTo;
      this.point2D_0[this.int_2++] = new Point2D(x, y);
    }

    public void MoveTo(Point2D p)
    {
      this.method_3();
      this.method_4(1);
      this.segmentType_0[this.int_3++] = SegmentType.MoveTo;
      this.point2D_0[this.int_2++] = p;
    }

    public void LineTo(double x, double y)
    {
      if (this.int_3 == 0)
        throw new InternalException("LineTo w/o MoveTo!");
      this.method_4(1);
      this.segmentType_0[this.int_3++] = SegmentType.LineTo;
      this.point2D_0[this.int_2++] = new Point2D(x, y);
    }

    public void LineToUnsafe(double x, double y)
    {
      this.method_4(1);
      this.segmentType_0[this.int_3++] = SegmentType.LineTo;
      this.point2D_0[this.int_2++] = new Point2D(x, y);
    }

    public void LineTo(Point2D p)
    {
      if (this.int_3 == 0)
        throw new InternalException("LineTo w/o MoveTo!");
      this.method_4(1);
      this.segmentType_0[this.int_3++] = SegmentType.LineTo;
      this.point2D_0[this.int_2++] = p;
    }

    public void QuadTo(double x1, double y1, double x2, double y2)
    {
      if (this.int_3 == 0)
        throw new InternalException("QuadTo w/o MoveTo!");
      this.method_4(2);
      this.segmentType_0[this.int_3++] = SegmentType.QuadTo;
      this.point2D_0[this.int_2++] = new Point2D(x1, y1);
      this.point2D_0[this.int_2++] = new Point2D(x2, y2);
      ++this.int_4;
    }

    public void QuadTo(Point2D p1, Point2D p2)
    {
      if (this.int_3 == 0)
        throw new InternalException("QuadTo w/o MoveTo!");
      this.method_4(2);
      this.segmentType_0[this.int_3++] = SegmentType.QuadTo;
      this.point2D_0[this.int_2++] = p1;
      this.point2D_0[this.int_2++] = p2;
      ++this.int_4;
    }

    public void CubicTo(double x1, double y1, double x2, double y2, double x3, double y3)
    {
      if (this.int_3 == 0)
        throw new InternalException("CubicTo w/o MoveTo!");
      this.method_4(3);
      this.segmentType_0[this.int_3++] = SegmentType.CubicTo;
      this.point2D_0[this.int_2++] = new Point2D(x1, y1);
      this.point2D_0[this.int_2++] = new Point2D(x2, y2);
      this.point2D_0[this.int_2++] = new Point2D(x3, y3);
    }

    private void method_1(double x1, double y1, double x2, double y2, double x3, double y3)
    {
      this.method_4(3);
      this.segmentType_0[this.int_3++] = SegmentType.CubicTo;
      this.point2D_0[this.int_2++] = new Point2D(x1, y1);
      this.point2D_0[this.int_2++] = new Point2D(x2, y2);
      this.point2D_0[this.int_2++] = new Point2D(x3, y3);
    }

    public void CubicTo(Point2D p1, Point2D p2, Point2D p3)
    {
      if (this.int_3 == 0)
        throw new InternalException("CubicTo w/o MoveTo!");
      this.method_4(3);
      this.segmentType_0[this.int_3++] = SegmentType.CubicTo;
      this.point2D_0[this.int_2++] = p1;
      this.point2D_0[this.int_2++] = p2;
      this.point2D_0[this.int_2++] = p3;
    }

    public void Close()
    {
      if (this.int_3 == 0)
        throw new InternalException("Close w/o MoveTo!");
      this.method_4(0);
      this.segmentType_0[this.int_3++] = SegmentType.Close;
    }

    public void AddPoint(Point2D position)
    {
      this.MoveTo(position);
      this.LineTo(position);
    }

    public void AddCircleApproximation(Point2D center, double radius)
    {
      this.MoveTo(center.X + radius, center.Y);
      double num = GeneralShape2D.double_0 * radius;
      this.CubicTo(center.X + radius, center.Y + num, center.X + num, center.Y + radius, center.X, center.Y + radius);
      this.CubicTo(center.X - num, center.Y + radius, center.X - radius, center.Y + num, center.X - radius, center.Y);
      this.CubicTo(center.X - radius, center.Y - num, center.X - num, center.Y - radius, center.X, center.Y - radius);
      this.CubicTo(center.X + num, center.Y - radius, center.X + radius, center.Y - num, center.X + radius, center.Y);
    }

    public void AddSquare(Point2D center, double halfSize)
    {
      this.MoveTo(center.X + halfSize, center.Y + halfSize);
      this.LineTo(center.X + halfSize, center.Y - halfSize);
      this.LineTo(center.X - halfSize, center.Y - halfSize);
      this.Close();
    }

    public int SegmentCount
    {
      get
      {
        return this.int_3;
      }
    }

    public int PointCount
    {
      get
      {
        return this.int_2;
      }
    }

    public Point2D CurrentPoint
    {
      get
      {
        if (this.int_2 == 0)
          throw new IndexOutOfRangeException();
        return this.point2D_0[this.int_2 - 1];
      }
    }

    public Point2D FirstPoint
    {
      get
      {
        if (this.int_2 == 0)
          throw new IndexOutOfRangeException();
        return this.point2D_0[0];
      }
    }

    public bool IsFixated
    {
      get
      {
        return this.bool_0;
      }
    }

    public Point2D[] Coordinates
    {
      get
      {
        return this.point2D_0;
      }
    }

    public SegmentType[] SegmentTypes
    {
      get
      {
        return this.segmentType_0;
      }
    }

    public FillMode FillMode
    {
      get
      {
        return this.fillMode_1;
      }
      set
      {
        this.fillMode_1 = value;
      }
    }

    public SegmentType GetSegmentTypeAt(int index)
    {
      if (index < 0 || index >= this.int_3)
        throw new IndexOutOfRangeException();
      return this.segmentType_0[index];
    }

    public Point2D GetPointAt(int index)
    {
      if (index < 0 || index >= this.int_2)
        throw new IndexOutOfRangeException();
      return this.point2D_0[index];
    }

    public void Shrink()
    {
      if (this.int_3 < this.segmentType_0.Length)
      {
        SegmentType[] segmentTypeArray = new SegmentType[this.int_3];
        Array.Copy((Array) this.segmentType_0, (Array) segmentTypeArray, this.int_3);
        this.segmentType_0 = segmentTypeArray;
      }
      if (this.int_2 >= this.point2D_0.Length)
        return;
      Point2D[] point2DArray = new Point2D[this.int_2];
      Array.Copy((Array) this.point2D_0, (Array) point2DArray, this.int_2);
      this.point2D_0 = point2DArray;
    }

    public void Fixate()
    {
      this.bool_0 = true;
    }

    public void ShrinkWrap()
    {
      this.Shrink();
      this.Fixate();
    }

    public GeneralShape2D[] GetUnbrokenShapes()
    {
      List<GeneralShape2D> generalShape2DList = new List<GeneralShape2D>();
      int pStart = 0;
      int sStart = 0;
      int pEnd = 0;
      for (int sEnd = 0; sEnd < this.int_3; ++sEnd)
      {
        SegmentType segmentType = this.segmentType_0[sEnd];
        if (segmentType == SegmentType.MoveTo)
        {
          if (sEnd > sStart)
            generalShape2DList.Add(new GeneralShape2D(this, sStart, sEnd, pStart, pEnd));
          pStart = pEnd;
          sStart = sEnd;
        }
        pEnd += GeneralShape2D.int_1[(int) segmentType];
      }
      if (this.int_3 > sStart)
        generalShape2DList.Add(new GeneralShape2D(this, sStart, this.int_3, pStart, pEnd));
      return generalShape2DList.ToArray();
    }

    public ISegment2DIterator CreateIterator()
    {
      return (ISegment2DIterator) new GeneralShape2D.Class93(this);
    }

    public void AddToBounds(Bounds2D bounds)
    {
      ShapeTool.AddToBounds(bounds, this.CreateIterator());
    }

    public bool HasSegments
    {
      get
      {
        return this.int_3 > 0;
      }
    }

    public static explicit operator GraphicsPath(GeneralShape2D shape)
    {
      int length = shape.int_2 + shape.int_4;
      if (length == 0)
        return new GraphicsPath();
      byte[] types = new byte[length];
      PointF[] pts = new PointF[length];
      int int3 = shape.int_3;
      SegmentType[] segmentType0 = shape.segmentType_0;
      Point2D[] point2D0 = shape.point2D_0;
      int index1 = 0;
      int index2 = 0;
      for (int index3 = 0; index3 < int3; ++index3)
      {
        switch (segmentType0[index3])
        {
          case SegmentType.MoveTo:
            types[index1] = (byte) 0;
            pts[index1] = (PointF) point2D0[index2];
            ++index1;
            ++index2;
            break;
          case SegmentType.LineTo:
            types[index1] = (byte) 1;
            pts[index1] = (PointF) point2D0[index2];
            ++index1;
            ++index2;
            break;
          case SegmentType.QuadTo:
            Point2D point2D1 = (Point2D) pts[index1 - 1];
            Point2D[] point2DArray1 = point2D0;
            int index4 = index2;
            int num = index4 + 1;
            Point2D point2D2 = point2DArray1[index4];
            Point2D[] point2DArray2 = point2D0;
            int index5 = num;
            index2 = index5 + 1;
            Point2D point2D3 = point2DArray2[index5];
            types[index1] = (byte) 3;
            pts[index1] = new PointF((float) (1.0 / 3.0 * (2.0 * point2D2.X + point2D1.X)), (float) (1.0 / 3.0 * (2.0 * point2D2.Y + point2D1.Y)));
            int index6 = index1 + 1;
            types[index6] = (byte) 3;
            pts[index6] = new PointF((float) (1.0 / 3.0 * (2.0 * point2D2.X + point2D3.X)), (float) (1.0 / 3.0 * (2.0 * point2D2.Y + point2D3.Y)));
            int index7 = index6 + 1;
            types[index7] = (byte) 3;
            pts[index7] = (PointF) point2D0[index2];
            index1 = index7 + 1;
            break;
          case SegmentType.CubicTo:
            types[index1] = (byte) 3;
            pts[index1] = (PointF) point2D0[index2];
            int index8 = index1 + 1;
            int index9 = index2 + 1;
            types[index8] = (byte) 3;
            pts[index8] = (PointF) point2D0[index9];
            int index10 = index8 + 1;
            int index11 = index9 + 1;
            types[index10] = (byte) 3;
            pts[index10] = (PointF) point2D0[index11];
            index1 = index10 + 1;
            index2 = index11 + 1;
            break;
          case SegmentType.Close:
            types[index1 - 1] |= (byte) 160;
            break;
        }
      }
      System.Drawing.Drawing2D.FillMode fillMode;
      switch (shape.fillMode_1)
      {
        case FillMode.Alternate:
          fillMode = System.Drawing.Drawing2D.FillMode.Alternate;
          break;
        case FillMode.Winding:
          fillMode = System.Drawing.Drawing2D.FillMode.Winding;
          break;
        default:
          throw new Exception("Unsupported fill mode " + (object) shape.fillMode_1 + ".");
      }
      return new GraphicsPath(pts, types, fillMode);
    }

    public GraphicsPath ToGraphicsPath(Matrix4D transform)
    {
      int length = this.int_2 + this.int_4;
      if (length == 0)
        return new GraphicsPath();
      byte[] types = new byte[length];
      PointF[] pts = new PointF[length];
      int int3 = this.int_3;
      int index1 = 0;
      int index2 = 0;
      for (int index3 = 0; index3 < int3; ++index3)
      {
        switch (this.segmentType_0[index3])
        {
          case SegmentType.MoveTo:
            types[index1] = (byte) 0;
            pts[index1] = transform.TransformToPointF(this.point2D_0[index2]);
            ++index1;
            ++index2;
            break;
          case SegmentType.LineTo:
            types[index1] = (byte) 1;
            pts[index1] = transform.TransformToPointF(this.point2D_0[index2]);
            ++index1;
            ++index2;
            break;
          case SegmentType.QuadTo:
            Point2D point2D1 = (Point2D) pts[index1 - 1];
            ref Matrix4D local1 = ref transform;
            Point2D[] point2D0_1 = this.point2D_0;
            int index4 = index2;
            int num = index4 + 1;
            Point2D point1 = point2D0_1[index4];
            Point2D point2D2 = local1.Transform(point1);
            ref Matrix4D local2 = ref transform;
            Point2D[] point2D0_2 = this.point2D_0;
            int index5 = num;
            index2 = index5 + 1;
            Point2D point2 = point2D0_2[index5];
            Point2D point2D3 = local2.Transform(point2);
            types[index1] = (byte) 3;
            pts[index1] = new PointF((float) (1.0 / 3.0 * (2.0 * point2D2.X + point2D1.X)), (float) (1.0 / 3.0 * (2.0 * point2D2.Y + point2D1.Y)));
            int index6 = index1 + 1;
            types[index6] = (byte) 3;
            pts[index6] = new PointF((float) (1.0 / 3.0 * (2.0 * point2D2.X + point2D3.X)), (float) (1.0 / 3.0 * (2.0 * point2D2.Y + point2D3.Y)));
            int index7 = index6 + 1;
            types[index7] = (byte) 3;
            pts[index7] = (PointF) this.point2D_0[index2];
            index1 = index7 + 1;
            break;
          case SegmentType.CubicTo:
            types[index1] = (byte) 3;
            pts[index1] = transform.TransformToPointF(this.point2D_0[index2]);
            int index8 = index1 + 1;
            int index9 = index2 + 1;
            types[index8] = (byte) 3;
            pts[index8] = transform.TransformToPointF(this.point2D_0[index9]);
            int index10 = index8 + 1;
            int index11 = index9 + 1;
            types[index10] = (byte) 3;
            pts[index10] = transform.TransformToPointF(this.point2D_0[index11]);
            index1 = index10 + 1;
            index2 = index11 + 1;
            break;
          case SegmentType.Close:
            types[index1 - 1] |= (byte) 160;
            break;
        }
      }
      System.Drawing.Drawing2D.FillMode fillMode;
      switch (this.fillMode_1)
      {
        case FillMode.Alternate:
          fillMode = System.Drawing.Drawing2D.FillMode.Alternate;
          break;
        case FillMode.Winding:
          fillMode = System.Drawing.Drawing2D.FillMode.Winding;
          break;
        default:
          throw new Exception("Unsupported fill mode " + (object) this.fillMode_1 + ".");
      }
      return new GraphicsPath(pts, types, fillMode);
    }

    public static explicit operator GeneralShape2D(GraphicsPath path)
    {
      if (path.PointCount == 0)
        return new GeneralShape2D();
      PointF[] pathPoints = path.PathPoints;
      byte[] pathTypes = path.PathTypes;
      GeneralShape2D generalShape2D = new GeneralShape2D(pathTypes.Length + 6, pathTypes.Length);
      for (int index1 = 0; index1 < pathTypes.Length; ++index1)
      {
        switch ((int) pathTypes[index1] & 7)
        {
          case 0:
            PointF pointF1 = pathPoints[index1];
            generalShape2D.method_0((double) pointF1.X, (double) pointF1.Y);
            break;
          case 1:
            PointF pointF2 = pathPoints[index1];
            generalShape2D.LineToUnsafe((double) pointF2.X, (double) pointF2.Y);
            break;
          case 3:
            PointF[] pointFArray1 = pathPoints;
            int index2 = index1;
            int num = index2 + 1;
            PointF pointF3 = pointFArray1[index2];
            PointF[] pointFArray2 = pathPoints;
            int index3 = num;
            index1 = index3 + 1;
            PointF pointF4 = pointFArray2[index3];
            PointF pointF5 = pathPoints[index1];
            generalShape2D.method_1((double) pointF3.X, (double) pointF3.Y, (double) pointF4.X, (double) pointF4.Y, (double) pointF5.X, (double) pointF5.Y);
            break;
        }
        if (((int) pathTypes[index1] & 128) != 0)
          generalShape2D.Close();
      }
      switch (path.FillMode)
      {
        case System.Drawing.Drawing2D.FillMode.Alternate:
          generalShape2D.FillMode = FillMode.Alternate;
          break;
        case System.Drawing.Drawing2D.FillMode.Winding:
          generalShape2D.FillMode = FillMode.Winding;
          break;
      }
      generalShape2D.Fixate();
      return generalShape2D;
    }

    public static GeneralShape2D Create(GraphicsPath path, Matrix2D transform)
    {
      if (path.PointCount == 0)
        return new GeneralShape2D();
      PointF[] pathPoints = path.PathPoints;
      byte[] pathTypes = path.PathTypes;
      GeneralShape2D generalShape2D = new GeneralShape2D(pathTypes.Length + 6, pathTypes.Length);
      for (int index = 0; index < pathTypes.Length; ++index)
      {
        switch ((int) pathTypes[index] & 7)
        {
          case 0:
            generalShape2D.MoveTo(transform.Transform((Point2D) pathPoints[index]));
            break;
          case 1:
            generalShape2D.LineTo(transform.Transform((Point2D) pathPoints[index]));
            break;
          case 3:
            generalShape2D.CubicTo(transform.Transform((Point2D) pathPoints[index]), transform.Transform((Point2D) pathPoints[index + 1]), transform.Transform((Point2D) pathPoints[index + 2]));
            index += 2;
            break;
        }
        if (((int) pathTypes[index] & 128) != 0)
          generalShape2D.Close();
      }
      switch (path.FillMode)
      {
        case System.Drawing.Drawing2D.FillMode.Alternate:
          generalShape2D.FillMode = FillMode.Alternate;
          break;
        case System.Drawing.Drawing2D.FillMode.Winding:
          generalShape2D.FillMode = FillMode.Winding;
          break;
      }
      generalShape2D.Fixate();
      return generalShape2D;
    }

    private void method_2(IShape2D shape)
    {
      GeneralShape2D generalShape2D = shape as GeneralShape2D;
      if (generalShape2D == null)
        return;
      this.fillMode_1 = generalShape2D.fillMode_1;
    }

    private void method_3()
    {
      if (this.int_3 <= 0 || this.segmentType_0[this.int_3 - 1] != SegmentType.MoveTo)
        return;
      --this.int_3;
      --this.int_2;
    }

    private void method_4(int pointCount)
    {
      this.method_5(1, pointCount);
    }

    private void method_5(int segmentCount, int pointCount)
    {
      if (this.bool_0)
        throw new InvalidOperationException("No more changes allowed for GeneralShape2D in fixed state!");
      if (segmentCount > 0)
      {
        int num = this.int_3 + segmentCount;
        if (num > this.segmentType_0.Length)
        {
          SegmentType[] segmentTypeArray = new SegmentType[2 * num];
          Array.Copy((Array) this.segmentType_0, (Array) segmentTypeArray, this.int_3);
          this.segmentType_0 = segmentTypeArray;
        }
      }
      if (pointCount <= 0)
        return;
      int num1 = this.int_2 + pointCount;
      if (num1 <= this.point2D_0.Length)
        return;
      Point2D[] point2DArray = new Point2D[2 * num1];
      Array.Copy((Array) this.point2D_0, (Array) point2DArray, this.int_2);
      this.point2D_0 = point2DArray;
    }

    private void method_6(Matrix2D transformation, int start, int end)
    {
      if (this.bool_0)
        throw new InvalidOperationException("No more changes allowed for GeneralShape2D in fixed state!");
      for (int index = start; index < end; ++index)
        this.point2D_0[index] = transformation.Transform(this.point2D_0[index]);
    }

    private void method_7(Matrix3D transformation, int start, int end)
    {
      if (this.bool_0)
        throw new InvalidOperationException("No more changes allowed for GeneralShape2D in fixed state!");
      for (int index = start; index < end; ++index)
        this.point2D_0[index] = transformation.Transform(this.point2D_0[index]);
    }

    private void method_8(Matrix4D transformation, int start, int end)
    {
      if (this.bool_0)
        throw new InvalidOperationException("No more changes allowed for GeneralShape2D in fixed state!");
      for (int index = start; index < end; ++index)
        this.point2D_0[index] = transformation.Transform(this.point2D_0[index]);
    }

    private class Class93 : ISegment2DIterator
    {
      private int int_3 = -1;
      private readonly Point2D[] point2D_0;
      private readonly int int_0;
      private readonly SegmentType[] segmentType_0;
      private readonly int int_1;
      private int int_2;

      public Class93(GeneralShape2D shape)
      {
        this.int_0 = shape.int_2;
        this.int_1 = shape.int_3;
        if (shape.bool_0)
        {
          this.point2D_0 = shape.point2D_0;
          this.segmentType_0 = shape.segmentType_0;
        }
        else
        {
          this.point2D_0 = new Point2D[this.int_0];
          Array.Copy((Array) shape.point2D_0, (Array) this.point2D_0, this.int_0);
          this.segmentType_0 = new SegmentType[this.int_1];
          Array.Copy((Array) shape.segmentType_0, (Array) this.segmentType_0, this.int_1);
        }
      }

      public bool MoveNext()
      {
        if (this.int_3 > this.int_1 - 2)
          return false;
        if (this.int_3 >= 0)
          this.int_2 += GeneralShape2D.int_1[(int) this.segmentType_0[this.int_3]];
        ++this.int_3;
        return true;
      }

      public SegmentType CurrentType
      {
        get
        {
          return this.segmentType_0[this.int_3];
        }
      }

      public SegmentType Current(Point2D[] points, int offset)
      {
        SegmentType segmentType = this.segmentType_0[this.int_3];
        int length = GeneralShape2D.int_1[(int) segmentType];
        Array.Copy((Array) this.point2D_0, this.int_2, (Array) points, offset, length);
        return segmentType;
      }

      public int TotalSegmentCount
      {
        get
        {
          return this.int_1;
        }
      }

      public int TotalPointCount
      {
        get
        {
          return this.int_0;
        }
      }
    }
  }
}
