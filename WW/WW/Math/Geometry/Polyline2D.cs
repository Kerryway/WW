// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Polyline2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using WW.Collections.Generic;

namespace WW.Math.Geometry
{
  [Serializable]
  public class Polyline2D : Polyline<Point2D>, IShape2D
  {
    public Polyline2D(bool closed)
      : base(closed)
    {
    }

    public Polyline2D(int capacity, bool closed)
      : base(capacity, closed)
    {
    }

    public Polyline2D(bool closed, params Point2D[] polyline)
      : base(closed, polyline)
    {
    }

    public Polyline2D(bool closed, IEnumerable<Point2D> polyline)
      : base(closed, polyline)
    {
    }

    public Polyline2D()
      : this(false)
    {
    }

    public Polyline2D(int capacity)
      : this(capacity, false)
    {
    }

    public Polyline2D(params Point2D[] points)
      : this(false, points)
    {
    }

    public Polyline2D(IEnumerable<Point2D> points)
      : this(false, points)
    {
    }

    public Polyline2D(Polyline2D polyline)
      : this(polyline.Closed, (IEnumerable<Point2D>) polyline)
    {
    }

    public Polyline2D(Polygon2D polygon)
      : this(true, (IEnumerable<Point2D>) polygon)
    {
    }

    public Polyline2D GetReverse()
    {
      Polyline2D polyline2D = new Polyline2D(this.Count, this.Closed);
      for (int index = this.Count - 1; index >= 0; --index)
        polyline2D.Add(this[index]);
      return polyline2D;
    }

    public static void Offset(IList<Point2D> polyline, double distance)
    {
      if (polyline.Count <= 1)
        return;
      if (polyline.Count > 2)
      {
        Point2D start = polyline[0];
        Point2D point2D = polyline[1];
        Segment2D segment2D1 = Polyline2D.smethod_0(new Segment2D(start, point2D), distance);
        Line2D a = new Line2D(segment2D1.Start, segment2D1.GetDelta());
        polyline[0] = segment2D1.Start;
        for (int index = 2; index < polyline.Count; ++index)
        {
          Point2D end = polyline[index];
          Segment2D segment2D2 = Polyline2D.smethod_0(new Segment2D(point2D, end), distance);
          Line2D b = new Line2D(segment2D2.Start, segment2D2.GetDelta());
          Point2D? intersection = Line2D.GetIntersection(a, b);
          polyline[index - 1] = !intersection.HasValue ? segment2D1.End : intersection.Value;
          point2D = end;
          segment2D1 = segment2D2;
          a = b;
        }
        polyline[polyline.Count - 1] = segment2D1.End;
      }
      else
      {
        Vector2D vector2D1 = polyline[1] - polyline[0];
        Vector2D vector2D2 = distance * new Vector2D(vector2D1.Y, -vector2D1.X).GetUnit();
        polyline[0] += vector2D2;
        polyline[1] += vector2D2;
      }
    }

    public Polyline2D GetSubPolyline(int start, int length)
    {
      return Polyline2D.GetSubPolyline((IList<Point2D>) this, start, length);
    }

    public static Polyline2D GetSubPolyline(IList<Point2D> points, int start, int length)
    {
      Polyline2D polyline2D = new Polyline2D(length);
      int num = start + length;
      for (int index = start; index < num; ++index)
        polyline2D.Add(points[index]);
      return polyline2D;
    }

    public double GetLength()
    {
      return Polyline2D.GetLength((IList<Point2D>) this, this.Closed);
    }

    public static double GetLength(IList<Point2D> points, bool closed)
    {
      double num = 0.0;
      if (points.Count > 1)
      {
        Point2D point2D = points[0];
        for (int index = 1; index < points.Count; ++index)
        {
          Point2D point = points[index];
          num += (point - point2D).GetLength();
          point2D = point;
        }
        if (closed)
          num += (points[0] - point2D).GetLength();
      }
      return num;
    }

    public void TransformMe(Matrix3D matrix)
    {
      for (int index = 0; index < this.Count; ++index)
        this[index] = matrix.Transform(this[index]);
    }

    public ISegment2DIterator CreateIterator()
    {
      if (!this.Closed)
        return Polyline2D.Class82.smethod_0(this);
      return Polygon2D.Class21.smethod_0((List<Point2D>) this);
    }

    public void AddToBounds(Bounds2D bounds)
    {
      foreach (Point2D p in (List<Point2D>) this)
        bounds.Update(p);
    }

    public bool HasSegments
    {
      get
      {
        return this.Count > 0;
      }
    }

    public int GetNoOfIntersections(Ray2D ray)
    {
      return Polyline2D.GetNoOfIntersections((IList<Point2D>) this, this.Closed, ray);
    }

    public static int GetNoOfIntersections(IList<Point2D> polyline, bool closed, Ray2D ray)
    {
      int count = polyline.Count;
      if (count < 2)
        return 0;
      int num1 = 0;
      int num2 = count;
      Point2D start = polyline[0];
      for (int index = 1; index < num2; ++index)
      {
        Point2D end = polyline[index];
        Segment2D b = new Segment2D(start, end);
        if (Ray2D.Intersects(ray, b))
          ++num1;
        start = end;
      }
      if (closed)
      {
        Point2D end = polyline[0];
        Segment2D b = new Segment2D(start, end);
        if (Ray2D.Intersects(ray, b))
          ++num1;
      }
      return num1;
    }

    public int GetWindingNumber(Point2D p)
    {
      return this.GetWindingNumber(p.X, p.Y);
    }

    public int GetWindingNumber(double x, double y)
    {
      int num = 0;
      int count = this.Count;
      if (this.Closed && count >= 3)
      {
        Point2D point2D1 = this[count - 1];
        for (int index = 0; index < count; ++index)
        {
          Point2D point2D2 = this[index];
          if (point2D1.Y <= y)
          {
            if (point2D2.Y > y && Polyline2D.smethod_1(point2D1.X, point2D1.Y, point2D2.X, point2D2.Y, x, y) > 0.0)
              ++num;
          }
          else if (point2D2.Y <= y && Polyline2D.smethod_1(point2D1.X, point2D1.Y, point2D2.X, point2D2.Y, x, y) < 0.0)
            --num;
          point2D1 = point2D2;
        }
      }
      return num;
    }

    private static Segment2D smethod_0(Segment2D segment, double distance)
    {
      Vector2D delta = segment.GetDelta();
      Vector2D vector2D = distance * new Vector2D(delta.Y, -delta.X).GetUnit();
      segment.Start += vector2D;
      segment.End += vector2D;
      return segment;
    }

    private static double smethod_1(
      double x1,
      double y1,
      double x2,
      double y2,
      double x3,
      double y3)
    {
      return (x2 - x1) * (y3 - y1) - (y2 - y1) * (x3 - x1);
    }

    private class Class82 : ISegment2DIterator
    {
      private int int_0 = -1;
      private readonly List<Point2D> list_0;

      private Class82(Polyline2D polyline)
      {
        this.list_0 = new List<Point2D>((IEnumerable<Point2D>) polyline);
        if (polyline.Count != 1)
          return;
        this.list_0.AddRange((IEnumerable<Point2D>) polyline);
      }

      public static ISegment2DIterator smethod_0(Polyline2D polyline)
      {
        if (polyline.Count == 0)
          return (ISegment2DIterator) NullSegment2DIterator.Instance;
        return (ISegment2DIterator) new Polyline2D.Class82(polyline);
      }

      public bool MoveNext()
      {
        if (this.int_0 > this.list_0.Count - 2)
          return false;
        ++this.int_0;
        return true;
      }

      public SegmentType CurrentType
      {
        get
        {
          return this.int_0 != 0 ? SegmentType.LineTo : SegmentType.MoveTo;
        }
      }

      public SegmentType Current(Point2D[] points, int offset)
      {
        points[offset] = this.list_0[this.int_0];
        return this.int_0 != 0 ? SegmentType.LineTo : SegmentType.MoveTo;
      }

      public int TotalSegmentCount
      {
        get
        {
          return this.list_0.Count;
        }
      }

      public int TotalPointCount
      {
        get
        {
          return this.list_0.Count;
        }
      }
    }

    public class Subdivide2
    {
      public static IList<Polyline2D.Subdivide2.PolylineWithIntersections> CalculateIntersections(
        IList<Polyline2D> polylines)
      {
        return Polyline2D.Subdivide2.CalculateIntersections(polylines, 8.88178419700125E-16);
      }

      public static IList<Polyline2D.Subdivide2.PolylineWithIntersections> CalculateIntersections(
        IList<Polyline2D> polylines,
        double precision)
      {
        if (polylines == null)
          return (IList<Polyline2D.Subdivide2.PolylineWithIntersections>) new Polyline2D.Subdivide2.PolylineWithIntersections[0];
        List<Polyline2D.Subdivide2.Class87> class87List = new List<Polyline2D.Subdivide2.Class87>();
        foreach (Polyline2D polyline in (IEnumerable<Polyline2D>) polylines)
        {
          Polyline2D.Subdivide2.Class87 class87_1 = new Polyline2D.Subdivide2.Class87(polyline);
          foreach (Polyline2D.Subdivide2.Class87 class87_2 in class87List)
          {
            if (class87_1.Bounds.Overlaps(class87_2.Bounds))
            {
              class87_1.BoundsOverlap = true;
              class87_2.BoundsOverlap = true;
            }
          }
          class87List.Add(class87_1);
        }
        Polyline2D.Subdivide2.Class26 eventQueue1 = new Polyline2D.Subdivide2.Class26();
        int segmentId = 0;
        List<Polyline2D.Subdivide2.PolylineWithIntersections> withIntersectionsList1 = new List<Polyline2D.Subdivide2.PolylineWithIntersections>();
        List<Polyline2D.Subdivide2.PolylineWithIntersections> withIntersectionsList2 = new List<Polyline2D.Subdivide2.PolylineWithIntersections>();
        foreach (Polyline2D.Subdivide2.Class87 class87 in class87List)
        {
          Polyline2D.Subdivide2.PolylineWithIntersections polylineWithIntersections = new Polyline2D.Subdivide2.PolylineWithIntersections();
          if (class87.BoundsOverlap)
          {
            withIntersectionsList2.Add(polylineWithIntersections);
            eventQueue1.method_4(class87.Polyline, polylineWithIntersections, precision, ref segmentId);
          }
          else
          {
            Polyline2D.Subdivide2.Class26 eventQueue2 = new Polyline2D.Subdivide2.Class26();
            eventQueue2.method_4(class87.Polyline, polylineWithIntersections, precision, ref segmentId);
            new Polyline2D.Subdivide2.Class86(eventQueue2, precision).method_0();
          }
          withIntersectionsList1.Add(polylineWithIntersections);
        }
        new Polyline2D.Subdivide2.Class86(eventQueue1, precision).method_0();
        return (IList<Polyline2D.Subdivide2.PolylineWithIntersections>) withIntersectionsList1;
      }

      public class PolylineWithIntersections : List<Polyline2D.Subdivide2.SegmentWithIntersections>
      {
        private bool bool_0;

        public bool Closed
        {
          get
          {
            return this.bool_0;
          }
          set
          {
            this.bool_0 = value;
          }
        }
      }

      private class Class83
      {
        private Polyline2D.Subdivide2.PolylineWithIntersections polylineWithIntersections_0;
        private Polyline2D.Subdivide2.SegmentWithIntersections segmentWithIntersections_0;
        private int int_0;
        private Polyline2D.Subdivide2.Class83 class83_0;
        private Vector2D vector2D_0;
        private Point2D point2D_0;
        private double double_0;
        private List<Polyline2D.Subdivide2.Class83> list_0;
        private RedBlackTree<Polyline2D.Subdivide2.Class83>.Node node_0;

        public Class83(
          int id,
          Polyline2D.Subdivide2.PolylineWithIntersections polyline,
          Segment2D segment,
          double precision)
        {
          this.int_0 = id;
          this.polylineWithIntersections_0 = polyline;
          this.segmentWithIntersections_0 = new Polyline2D.Subdivide2.SegmentWithIntersections(polyline, segment);
          this.vector2D_0 = segment.GetDelta().GetUnit();
          if (MathUtil.AreApproxEqual(segment.Start.X, segment.End.X, precision))
          {
            this.double_0 = double.PositiveInfinity;
            this.point2D_0 = segment.Start.Y < segment.End.Y ? segment.Start : segment.End;
          }
          else
          {
            this.double_0 = this.vector2D_0.Y / this.vector2D_0.X;
            this.point2D_0 = segment.Start;
          }
        }

        public Polyline2D.Subdivide2.PolylineWithIntersections Polyline
        {
          get
          {
            return this.polylineWithIntersections_0;
          }
        }

        public int Id
        {
          get
          {
            return this.int_0;
          }
        }

        public Polyline2D.Subdivide2.SegmentWithIntersections SegmentWithIntersections
        {
          get
          {
            return this.segmentWithIntersections_0;
          }
        }

        public Segment2D Segment
        {
          get
          {
            return this.segmentWithIntersections_0.Segment;
          }
        }

        public Polyline2D.Subdivide2.Class83 PreviousSegment
        {
          get
          {
            return this.class83_0;
          }
          set
          {
            this.class83_0 = value;
          }
        }

        public Vector2D Direction
        {
          get
          {
            return this.vector2D_0;
          }
        }

        public Point2D SweepLineIntersection
        {
          get
          {
            return this.point2D_0;
          }
          set
          {
            this.point2D_0 = value;
          }
        }

        public double Slope
        {
          get
          {
            return this.double_0;
          }
        }

        public RedBlackTree<Polyline2D.Subdivide2.Class83>.Node Node
        {
          get
          {
            return this.node_0;
          }
          set
          {
            this.node_0 = value;
          }
        }

        public void method_0(Polyline2D.Subdivide2.Class83 segmentHelper)
        {
          if (this.list_0 == null)
            this.list_0 = new List<Polyline2D.Subdivide2.Class83>();
          this.list_0.Add(segmentHelper);
        }

        public bool method_1(Polyline2D.Subdivide2.Class83 segmentHelper)
        {
          if (this.list_0 == null)
            return false;
          return this.list_0.Contains(segmentHelper);
        }

        public void method_2(double x)
        {
          if (this.point2D_0.X == x)
            return;
          double y = !double.IsPositiveInfinity(this.double_0) ? this.Segment.Start.Y + (x - this.Segment.Start.X) * this.double_0 : System.Math.Min(this.Segment.Start.Y, this.Segment.End.Y);
          this.point2D_0 = new Point2D(x, y);
        }

        public bool method_3(Polyline2D.Subdivide2.Class83 other)
        {
          if (this.class83_0 != other)
            return other.class83_0 == this;
          return true;
        }

        public void method_4(
          Polyline2D.Subdivide2.Class83 intersectingSegment,
          double parameter,
          Point2D position)
        {
          this.segmentWithIntersections_0.AddIntersection(intersectingSegment.segmentWithIntersections_0, parameter, position);
          this.method_0(intersectingSegment);
        }

        public void method_5(Polyline2D.Subdivide2.Class83 intersectingSegment, Point2D position)
        {
          this.segmentWithIntersections_0.AddIntersection(intersectingSegment.segmentWithIntersections_0, position);
          this.method_0(intersectingSegment);
        }

        public override string ToString()
        {
          return string.Format("Segment: {0}, sweepline intersection: {1}", (object) this.Segment, (object) this.point2D_0);
        }
      }

      public class SegmentWithIntersections
      {
        private Polyline2D.Subdivide2.PolylineWithIntersections polylineWithIntersections_0;
        private Segment2D segment2D_0;
        private List<Polyline2D.Subdivide2.SegmentIntersection> list_0;

        public SegmentWithIntersections(
          Polyline2D.Subdivide2.PolylineWithIntersections polyline,
          Segment2D segment)
        {
          this.polylineWithIntersections_0 = polyline;
          this.segment2D_0 = segment;
        }

        public Polyline2D.Subdivide2.PolylineWithIntersections Polyline
        {
          get
          {
            return this.polylineWithIntersections_0;
          }
        }

        public Segment2D Segment
        {
          get
          {
            return this.segment2D_0;
          }
        }

        public List<Polyline2D.Subdivide2.SegmentIntersection> Intersections
        {
          get
          {
            return this.list_0;
          }
        }

        public void AddIntersection(
          Polyline2D.Subdivide2.SegmentIntersection intersection)
        {
          if (this.list_0 == null)
            this.list_0 = new List<Polyline2D.Subdivide2.SegmentIntersection>();
          this.list_0.Add(intersection);
        }

        public void AddIntersection(
          Polyline2D.Subdivide2.SegmentWithIntersections intersectingSegment,
          Point2D position)
        {
          Vector2D delta = this.segment2D_0.GetDelta();
          double parameter = !Vector2D.AreApproxEqual(Vector2D.Zero, delta) ? Vector2D.DotProduct(position - this.segment2D_0.Start, delta) / delta.GetLengthSquared() : 0.0;
          this.AddIntersection(intersectingSegment, parameter, position);
        }

        public void AddIntersection(
          Polyline2D.Subdivide2.SegmentWithIntersections intersectingSegment,
          double parameter,
          Point2D position)
        {
          if (this.list_0 == null)
            this.list_0 = new List<Polyline2D.Subdivide2.SegmentIntersection>();
          this.list_0.Add(new Polyline2D.Subdivide2.SegmentIntersection(intersectingSegment, parameter, position));
        }

        public override string ToString()
        {
          return string.Format("Segment: {0}", (object) this.segment2D_0);
        }
      }

      public class SegmentIntersection : IComparable<Polyline2D.Subdivide2.SegmentIntersection>
      {
        private List<Polyline2D.Subdivide2.SegmentWithIntersections> list_0 = new List<Polyline2D.Subdivide2.SegmentWithIntersections>();
        private double double_0;
        private Point2D point2D_0;

        public SegmentIntersection(
          Polyline2D.Subdivide2.SegmentWithIntersections intersectingSegment,
          double parameter,
          Point2D position)
        {
          this.list_0.Add(intersectingSegment);
          this.double_0 = parameter;
          this.point2D_0 = position;
        }

        public double Parameter
        {
          get
          {
            return this.double_0;
          }
        }

        public Point2D Position
        {
          get
          {
            return this.point2D_0;
          }
        }

        public List<Polyline2D.Subdivide2.SegmentWithIntersections> IntersectingSegments
        {
          get
          {
            return this.list_0;
          }
        }

        public override string ToString()
        {
          return this.point2D_0.ToString();
        }

        public int CompareTo(Polyline2D.Subdivide2.SegmentIntersection other)
        {
          return this.double_0 >= other.double_0 ? (this.double_0 <= other.double_0 ? 0 : 1) : -1;
        }
      }

      private class Class26 : RedBlackTree<Polyline2D.Subdivide2.Class84>
      {
        public void method_4(
          Polyline2D polyline,
          Polyline2D.Subdivide2.PolylineWithIntersections polylineWithIntersections,
          double precision,
          ref int segmentId)
        {
          Polyline2D.Subdivide2.Class84.Class85 class85 = new Polyline2D.Subdivide2.Class84.Class85();
          Point2D point2D1 = polyline.Closed ? polyline[polyline.Count - 1] : polyline[0];
          Polyline2D.Subdivide2.Class83 class83_1 = (Polyline2D.Subdivide2.Class83) null;
          Polyline2D.Subdivide2.Class83 class83_2 = (Polyline2D.Subdivide2.Class83) null;
          double num = precision + precision;
          for (int index = polyline.Closed ? 0 : 1; index < polyline.Count; ++index)
          {
            Point2D point2D2 = polyline[index];
            Point2D a = point2D1;
            Point2D b = point2D2;
            if (a.X > b.X || a.X == b.X && a.Y > b.Y)
              MathUtil.Swap<Point2D>(ref a, ref b);
            Polyline2D.Subdivide2.Class83 class83_3 = new Polyline2D.Subdivide2.Class83(segmentId++, polylineWithIntersections, new Segment2D(a, b), precision);
            polylineWithIntersections.Add(class83_3.SegmentWithIntersections);
            class83_3.PreviousSegment = class83_1;
            if (class83_2 == null)
              class83_2 = class83_3;
            bool flag = a.X > b.X - num;
            Point2D position1 = new Point2D(flag ? a.X : a.X + precision, a.Y);
            Point2D position2 = new Point2D(flag ? b.X : b.X - precision, b.Y);
            class85.Position = position1;
            Polyline2D.Subdivide2.Class84 class84_1 = this.Find((IComparable<Polyline2D.Subdivide2.Class84>) class85);
            if (class84_1 == null)
            {
              class84_1 = new Polyline2D.Subdivide2.Class84(position1);
              this.Add(class84_1);
            }
            class84_1.EntrySegmentsNotNull.Add(class83_3);
            class85.Position = position2;
            Polyline2D.Subdivide2.Class84 class84_2 = this.Find((IComparable<Polyline2D.Subdivide2.Class84>) class85);
            if (class84_2 == null)
            {
              class84_2 = new Polyline2D.Subdivide2.Class84(position2);
              this.Add(class84_2);
            }
            class84_2.ExitSegmentsNotNull.Add(class83_3);
            point2D1 = point2D2;
            class83_1 = class83_3;
          }
          if (!polyline.Closed || class83_2 == null)
            return;
          class83_2.PreviousSegment = class83_1;
        }
      }

      private class Class84 : IComparable<Polyline2D.Subdivide2.Class84>
      {
        private Point2D point2D_0;
        private List<Polyline2D.Subdivide2.Class83> list_0;
        private List<Polyline2D.Subdivide2.Class83> list_1;
        private List<Polyline2D.Subdivide2.Class83> list_2;

        public Class84(Point2D position)
        {
          this.point2D_0 = position;
        }

        public Point2D Position
        {
          get
          {
            return this.point2D_0;
          }
          set
          {
            this.point2D_0 = value;
          }
        }

        public List<Polyline2D.Subdivide2.Class83> EntrySegments
        {
          get
          {
            return this.list_0;
          }
        }

        public List<Polyline2D.Subdivide2.Class83> ExitSegments
        {
          get
          {
            return this.list_1;
          }
        }

        public List<Polyline2D.Subdivide2.Class83> ReorderSegments
        {
          get
          {
            return this.list_2;
          }
        }

        public List<Polyline2D.Subdivide2.Class83> EntrySegmentsNotNull
        {
          get
          {
            if (this.list_0 == null)
              this.list_0 = new List<Polyline2D.Subdivide2.Class83>();
            return this.list_0;
          }
        }

        public List<Polyline2D.Subdivide2.Class83> ExitSegmentsNotNull
        {
          get
          {
            if (this.list_1 == null)
              this.list_1 = new List<Polyline2D.Subdivide2.Class83>();
            return this.list_1;
          }
        }

        public List<Polyline2D.Subdivide2.Class83> ReorderSegmentsNotNull
        {
          get
          {
            if (this.list_2 == null)
              this.list_2 = new List<Polyline2D.Subdivide2.Class83>();
            return this.list_2;
          }
        }

        public override string ToString()
        {
          return this.point2D_0.ToString();
        }

        public int CompareTo(Polyline2D.Subdivide2.Class84 other)
        {
          if (this.point2D_0.X < other.point2D_0.X)
            return -1;
          return this.point2D_0.X > other.point2D_0.X ? 1 : 0;
        }

        internal class Class85 : IComparable<Polyline2D.Subdivide2.Class84>
        {
          private Point2D point2D_0;

          public Point2D Position
          {
            get
            {
              return this.point2D_0;
            }
            set
            {
              this.point2D_0 = value;
            }
          }

          public int CompareTo(Polyline2D.Subdivide2.Class84 other)
          {
            if (this.point2D_0.X < other.point2D_0.X)
              return -1;
            return this.point2D_0.X > other.point2D_0.X ? 1 : 0;
          }
        }
      }

      private class Class86 : IComparer<Polyline2D.Subdivide2.Class83>
      {
        private Polyline2D.Subdivide2.Class26 class26_0;
        private RedBlackTree<Polyline2D.Subdivide2.Class84>.ForwardEnumerator forwardEnumerator_0;
        private double double_0;
        private RedBlackTree<Polyline2D.Subdivide2.Class83> redBlackTree_0;
        private Polyline2D.Subdivide2.Class84 class84_0;
        private RedBlackTree<Polyline2D.Subdivide2.Class83>.ForwardEnumerator forwardEnumerator_1;
        private Polyline2D.Subdivide2.Class84.Class85 class85_0;

        public Class86(Polyline2D.Subdivide2.Class26 eventQueue, double precision)
        {
          this.class26_0 = eventQueue;
          this.double_0 = precision;
          this.forwardEnumerator_0 = (RedBlackTree<Polyline2D.Subdivide2.Class84>.ForwardEnumerator) eventQueue.GetEnumerator();
          this.redBlackTree_0 = new RedBlackTree<Polyline2D.Subdivide2.Class83>((IComparer<Polyline2D.Subdivide2.Class83>) this);
          this.forwardEnumerator_1 = new RedBlackTree<Polyline2D.Subdivide2.Class83>.ForwardEnumerator(this.redBlackTree_0);
          this.class85_0 = new Polyline2D.Subdivide2.Class84.Class85();
        }

        public void method_0()
        {
          while (this.forwardEnumerator_0.MoveNext())
          {
            this.class84_0 = this.forwardEnumerator_0.Current;
            if (this.class84_0.EntrySegments != null)
            {
              foreach (Polyline2D.Subdivide2.Class83 entrySegment in this.class84_0.EntrySegments)
                this.method_2(entrySegment);
            }
            if (this.class84_0.ExitSegments != null)
            {
              foreach (Polyline2D.Subdivide2.Class83 exitSegment in this.class84_0.ExitSegments)
                this.method_1(exitSegment);
            }
            if (this.class84_0.ReorderSegments != null)
            {
              foreach (Polyline2D.Subdivide2.Class83 reorderSegment in this.class84_0.ReorderSegments)
                this.method_1(reorderSegment);
              foreach (Polyline2D.Subdivide2.Class83 reorderSegment in this.class84_0.ReorderSegments)
                this.method_2(reorderSegment);
            }
          }
        }

        private void method_1(Polyline2D.Subdivide2.Class83 segment)
        {
          this.redBlackTree_0.Remove(segment.Node);
          segment.Node = (RedBlackTree<Polyline2D.Subdivide2.Class83>.Node) null;
        }

        private void method_2(Polyline2D.Subdivide2.Class83 segment)
        {
          RedBlackTree<Polyline2D.Subdivide2.Class83>.Node node = this.redBlackTree_0.TryAdd(segment);
          segment.Node = node;
          this.forwardEnumerator_1.CurrentNode = node;
          if (this.forwardEnumerator_1.MovePrevious())
          {
            RedBlackTree<Polyline2D.Subdivide2.Class83>.Node currentNode = this.forwardEnumerator_1.CurrentNode;
            if (!this.method_3(segment, currentNode))
            {
              while (this.forwardEnumerator_1.MovePrevious() && !this.method_3(segment, currentNode))
                ;
            }
          }
          this.forwardEnumerator_1.CurrentNode = node;
          if (!this.forwardEnumerator_1.MoveNext())
            return;
          RedBlackTree<Polyline2D.Subdivide2.Class83>.Node currentNode1 = this.forwardEnumerator_1.CurrentNode;
          if (this.method_3(segment, currentNode1))
            return;
          do
            ;
          while (this.forwardEnumerator_1.MoveNext() && !this.method_3(segment, currentNode1));
        }

        private bool method_3(
          Polyline2D.Subdivide2.Class83 segment,
          RedBlackTree<Polyline2D.Subdivide2.Class83>.Node initialNode)
        {
          this.forwardEnumerator_1.CurrentNode.Value.method_2(this.class84_0.Position.X);
          if (double.IsInfinity(segment.Slope))
          {
            if (double.IsInfinity(this.forwardEnumerator_1.CurrentNode.Value.Slope))
              return false;
            Point2D lineIntersection = this.forwardEnumerator_1.CurrentNode.Value.SweepLineIntersection;
            if (segment.Segment.Start.Y >= lineIntersection.Y - this.double_0 || segment.Segment.End.Y <= lineIntersection.Y + this.double_0)
              return true;
            if (!Point2D.AreApproxEqual(this.forwardEnumerator_1.CurrentNode.Value.Segment.End, lineIntersection, this.double_0))
            {
              segment.method_5(this.forwardEnumerator_1.Current, lineIntersection);
              this.forwardEnumerator_1.CurrentNode.Value.method_5(segment, lineIntersection);
            }
          }
          else
          {
            if (this.forwardEnumerator_1.CurrentNode != initialNode && !MathUtil.AreApproxEqual(initialNode.Value.SweepLineIntersection.Y, this.forwardEnumerator_1.Current.SweepLineIntersection.Y, this.double_0))
              return true;
            this.method_4(segment, initialNode.Value);
          }
          return false;
        }

        private void method_4(
          Polyline2D.Subdivide2.Class83 segment,
          Polyline2D.Subdivide2.Class83 otherSegment)
        {
          double[] pArray;
          double[] qArray;
          if (segment.method_1(otherSegment) || segment.method_3(otherSegment) || !Segment2D.GetIntersectionParameters(segment.Segment, otherSegment.Segment, out pArray, out qArray, this.double_0))
            return;
          for (int index = 0; index < pArray.Length; ++index)
          {
            double parameter1 = pArray[index];
            double parameter2 = qArray[index];
            if (parameter1 != 0.0 && parameter1 != 1.0)
            {
              Point2D point2D = segment.Segment.Start + parameter1 * segment.Segment.GetDelta();
              if (!Point2D.AreApproxEqual(point2D, segment.Segment.Start) && !Point2D.AreApproxEqual(point2D, segment.Segment.End))
              {
                if (Point2D.AreApproxEqual(point2D, otherSegment.Segment.Start))
                  segment.method_4(otherSegment, parameter1, otherSegment.Segment.Start);
                else if (Point2D.AreApproxEqual(point2D, otherSegment.Segment.End))
                  segment.method_4(otherSegment, parameter1, otherSegment.Segment.End);
                else
                  segment.method_4(otherSegment, parameter1, point2D);
              }
            }
            if (parameter2 != 0.0 && parameter2 != 1.0)
            {
              Point2D point2D = otherSegment.Segment.Start + parameter2 * otherSegment.Segment.GetDelta();
              if (!Point2D.AreApproxEqual(point2D, otherSegment.Segment.Start) && !Point2D.AreApproxEqual(point2D, otherSegment.Segment.End))
              {
                if (Point2D.AreApproxEqual(point2D, segment.Segment.Start))
                  otherSegment.method_4(segment, parameter2, segment.Segment.Start);
                else if (Point2D.AreApproxEqual(point2D, segment.Segment.End))
                  otherSegment.method_4(segment, parameter2, segment.Segment.End);
                else
                  otherSegment.method_4(segment, parameter2, point2D);
              }
            }
          }
          if (pArray.Length != 1)
            return;
          for (int index = 0; index < pArray.Length; ++index)
          {
            Point2D position = segment.Segment.Start + pArray[index] * segment.Segment.GetDelta();
            this.class85_0.Position = position;
            Polyline2D.Subdivide2.Class84 class84 = this.class26_0.Find((IComparable<Polyline2D.Subdivide2.Class84>) this.class85_0);
            if (class84 == null)
            {
              class84 = new Polyline2D.Subdivide2.Class84(position);
              this.class26_0.Add(class84);
            }
            if (!double.IsInfinity(segment.Slope) && !double.IsInfinity(otherSegment.Slope))
            {
              if (!class84.ReorderSegmentsNotNull.Contains(segment) && class84.Position.X != segment.Segment.End.X)
                class84.ReorderSegments.Add(segment);
              if (!class84.ReorderSegments.Contains(otherSegment) && class84.Position.X != otherSegment.Segment.End.X)
                class84.ReorderSegments.Add(otherSegment);
            }
          }
        }

        public int Compare(Polyline2D.Subdivide2.Class83 x, Polyline2D.Subdivide2.Class83 y)
        {
          x.method_2(this.class84_0.Position.X);
          y.method_2(this.class84_0.Position.X);
          return x.SweepLineIntersection.Y >= y.SweepLineIntersection.Y ? (x.SweepLineIntersection.Y <= y.SweepLineIntersection.Y ? (x.Direction.Y >= y.Direction.Y ? (x.Direction.Y <= y.Direction.Y ? (x.Id >= y.Id ? (x.Id <= y.Id ? 0 : 1) : -1) : 1) : -1) : 1) : -1;
        }
      }

      private class Class87
      {
        private Bounds2D bounds2D_0 = new Bounds2D();
        private Polyline2D polyline2D_0;
        private bool bool_0;

        public Class87(Polyline2D polyline)
        {
          this.polyline2D_0 = polyline;
          this.bounds2D_0.Update((IList<Point2D>) polyline);
        }

        public Polyline2D Polyline
        {
          get
          {
            return this.polyline2D_0;
          }
        }

        public Bounds2D Bounds
        {
          get
          {
            return this.bounds2D_0;
          }
        }

        public bool BoundsOverlap
        {
          get
          {
            return this.bool_0;
          }
          set
          {
            this.bool_0 = value;
          }
        }
      }
    }

    public static class Subdivide1
    {
      public static void Subdivide(
        IList<Polyline2D> polylines,
        out List<Point2D> points,
        out IList<IList<int>> polylinePointIndexesList)
      {
        Polyline2D.Subdivide1.Subdivide(polylines, 8.88178419700125E-16, out points, out polylinePointIndexesList);
      }

      public static void Subdivide(
        IList<Polyline2D> polylines,
        double precision,
        out List<Point2D> points,
        out IList<IList<int>> polylinePointIndexesList)
      {
        List<Polyline2D.Subdivide1.Class88> polylinesWithIntersections = new List<Polyline2D.Subdivide1.Class88>();
        Polyline2D.Subdivide1.Class91[] class91Array = Polyline2D.Subdivide1.smethod_0(polylines, precision, polylinesWithIntersections);
        HashSet<Polyline2D.Subdivide1.Class89> class89Set = new HashSet<Polyline2D.Subdivide1.Class89>();
        for (int index1 = 0; index1 < class91Array.Length; ++index1)
        {
          Polyline2D.Subdivide1.Class91 class91 = class91Array[index1];
          if (class91.EntrySegments != null)
          {
            foreach (Polyline2D.Subdivide1.Class89 entrySegment in class91.EntrySegments)
            {
              foreach (Polyline2D.Subdivide1.Class89 segment in class89Set)
              {
                double[] pArray;
                double[] qArray;
                if (!entrySegment.method_0(segment) && Segment2D.GetIntersectionParameters(entrySegment.Segment, segment.Segment, out pArray, out qArray))
                {
                  for (int index2 = 0; index2 < pArray.Length; ++index2)
                  {
                    double parameter1 = pArray[index2];
                    double parameter2 = qArray[index2];
                    if (parameter1 != 0.0 && parameter1 != 1.0)
                    {
                      Point2D point2D = entrySegment.Segment.Start + parameter1 * entrySegment.Segment.GetDelta();
                      if (!Point2D.AreApproxEqual(point2D, entrySegment.Segment.Start) && !Point2D.AreApproxEqual(point2D, entrySegment.Segment.End))
                      {
                        if (Point2D.AreApproxEqual(point2D, segment.Segment.Start))
                          entrySegment.method_1(parameter1, segment.Segment.Start);
                        else if (Point2D.AreApproxEqual(point2D, segment.Segment.End))
                          entrySegment.method_1(parameter1, segment.Segment.End);
                        else
                          entrySegment.method_1(parameter1, point2D);
                      }
                    }
                    if (parameter2 != 0.0 && parameter2 != 1.0)
                    {
                      Point2D point2D = segment.Segment.Start + parameter2 * segment.Segment.GetDelta();
                      if (!Point2D.AreApproxEqual(point2D, segment.Segment.Start) && !Point2D.AreApproxEqual(point2D, segment.Segment.End))
                      {
                        if (Point2D.AreApproxEqual(point2D, entrySegment.Segment.Start))
                          segment.method_1(parameter2, entrySegment.Segment.Start);
                        else if (Point2D.AreApproxEqual(point2D, entrySegment.Segment.End))
                          segment.method_1(parameter2, entrySegment.Segment.End);
                        else
                          segment.method_1(parameter2, point2D);
                      }
                    }
                  }
                }
              }
              class89Set.Add(entrySegment);
            }
          }
          if (class91.ExitSegments != null)
          {
            foreach (Polyline2D.Subdivide1.Class89 exitSegment in class91.ExitSegments)
              class89Set.Remove(exitSegment);
          }
        }
        points = new List<Point2D>();
        polylinePointIndexesList = (IList<IList<int>>) new List<IList<int>>();
        Dictionary<Point2D, int> pointToIndex = new Dictionary<Point2D, int>();
        foreach (Polyline2D.Subdivide1.Class88 class88 in polylinesWithIntersections)
        {
          if (class88.Count > 0)
          {
            List<int> polylinePointIndexes = new List<int>();
            polylinePointIndexesList.Add((IList<int>) polylinePointIndexes);
            foreach (Polyline2D.Subdivide1.Class89 class89 in (List<Polyline2D.Subdivide1.Class89>) class88)
              class89.method_2(points, polylinePointIndexes, pointToIndex);
            if (class88.Closed)
              class88[0].method_3(points, polylinePointIndexes, pointToIndex);
          }
        }
      }

      public static bool HasIntersections(
        Polyline2D polyline1,
        Polyline2D polyline2,
        bool includeSegmentEndPoints)
      {
        return Polyline2D.Subdivide1.HasIntersections((IList<Polyline2D>) new List<Polyline2D>(2) { polyline1, polyline2 }, includeSegmentEndPoints);
      }

      public static bool HasIntersections(IList<Polyline2D> polylines, bool includeSegmentEndPoints)
      {
        return Polyline2D.Subdivide1.HasIntersections(polylines, includeSegmentEndPoints, 8.88178419700125E-16);
      }

      public static bool HasIntersections(
        IList<Polyline2D> polylines,
        bool includeSegmentEndPoints,
        double precision)
      {
        Polyline2D.Subdivide1.Class91[] class91Array = Polyline2D.Subdivide1.smethod_0(polylines, precision, (List<Polyline2D.Subdivide1.Class88>) null);
        HashSet<Polyline2D.Subdivide1.Class89> class89Set = new HashSet<Polyline2D.Subdivide1.Class89>();
        for (int index = 0; index < class91Array.Length; ++index)
        {
          Polyline2D.Subdivide1.Class91 class91 = class91Array[index];
          if (class91.EntrySegments != null)
          {
            foreach (Polyline2D.Subdivide1.Class89 entrySegment in class91.EntrySegments)
            {
              foreach (Polyline2D.Subdivide1.Class89 segment in class89Set)
              {
                if (!entrySegment.method_0(segment))
                {
                  if (includeSegmentEndPoints)
                  {
                    if (Segment2D.IntersectsInclusive(entrySegment.Segment, segment.Segment))
                      return true;
                  }
                  else if (Segment2D.Intersects(entrySegment.Segment, segment.Segment))
                    return true;
                }
              }
              class89Set.Add(entrySegment);
            }
          }
          if (class91.ExitSegments != null)
          {
            foreach (Polyline2D.Subdivide1.Class89 exitSegment in class91.ExitSegments)
              class89Set.Remove(exitSegment);
          }
        }
        return false;
      }

      private static Polyline2D.Subdivide1.Class91[] smethod_0(
        IList<Polyline2D> polylines,
        double precision,
        List<Polyline2D.Subdivide1.Class88> polylinesWithIntersections)
      {
        Dictionary<double, Polyline2D.Subdivide1.Class91> dictionary = new Dictionary<double, Polyline2D.Subdivide1.Class91>();
        foreach (Polyline2D polyline in (IEnumerable<Polyline2D>) polylines)
        {
          Polyline2D.Subdivide1.Class88 class88 = (Polyline2D.Subdivide1.Class88) null;
          if (polylinesWithIntersections != null)
          {
            class88 = new Polyline2D.Subdivide1.Class88();
            class88.Closed = polyline.Closed;
          }
          if (polyline.Count > 1)
          {
            bool flag = polyline.Closed && !Point2D.AreApproxEqual(polyline[0], polyline[polyline.Count - 1], precision);
            Point2D point2D1 = polyline[flag ? polyline.Count - 1 : 0];
            Polyline2D.Subdivide1.Class89 class89_1 = (Polyline2D.Subdivide1.Class89) null;
            Polyline2D.Subdivide1.Class89 class89_2 = (Polyline2D.Subdivide1.Class89) null;
            for (int index = flag ? 0 : 1; index < polyline.Count; ++index)
            {
              Point2D point2D2 = polyline[index];
              if (!Point2D.AreApproxEqual(point2D1, point2D2, precision))
              {
                Polyline2D.Subdivide1.Class89 class89_3 = new Polyline2D.Subdivide1.Class89(new Segment2D(point2D1, point2D2));
                if (polylinesWithIntersections != null)
                  class88.Add(class89_3);
                double num1 = System.Math.Min(point2D1.X, point2D2.X);
                double num2 = System.Math.Max(point2D1.X, point2D2.X);
                Polyline2D.Subdivide1.Class91 class91_1;
                if (!dictionary.TryGetValue(num1, out class91_1))
                {
                  class91_1 = new Polyline2D.Subdivide1.Class91(num1);
                  dictionary.Add(num1, class91_1);
                }
                Polyline2D.Subdivide1.Class91 class91_2;
                if (point2D1.X == point2D2.X)
                  class91_2 = class91_1;
                else if (!dictionary.TryGetValue(num2, out class91_2))
                {
                  class91_2 = new Polyline2D.Subdivide1.Class91(num2);
                  dictionary.Add(num2, class91_2);
                }
                class91_1.EntrySegmentsNotNull.Add(class89_3);
                class91_2.ExitSegmentsNotNull.Add(class89_3);
                point2D1 = point2D2;
                if (class89_1 != null)
                  class89_1.Next = class89_3;
                if (class89_2 == null)
                  class89_2 = class89_3;
                class89_1 = class89_3;
              }
              if (flag)
                class89_1.Next = class89_2;
            }
          }
          polylinesWithIntersections?.Add(class88);
        }
        Polyline2D.Subdivide1.Class91[] array = new Polyline2D.Subdivide1.Class91[dictionary.Count];
        int num = 0;
        foreach (KeyValuePair<double, Polyline2D.Subdivide1.Class91> keyValuePair in dictionary)
          array[num++] = keyValuePair.Value;
        Array.Sort<Polyline2D.Subdivide1.Class91>(array);
        return array;
      }

      private class Class88 : List<Polyline2D.Subdivide1.Class89>
      {
        private bool bool_0;

        public bool Closed
        {
          get
          {
            return this.bool_0;
          }
          set
          {
            this.bool_0 = value;
          }
        }
      }

      private class Class89
      {
        private Segment2D segment2D_0;
        private List<Polyline2D.Subdivide1.Class90> list_0;
        private Polyline2D.Subdivide1.Class89 class89_0;

        public Class89(Segment2D segment)
        {
          this.segment2D_0 = segment;
        }

        public Segment2D Segment
        {
          get
          {
            return this.segment2D_0;
          }
        }

        public Polyline2D.Subdivide1.Class89 Next
        {
          get
          {
            return this.class89_0;
          }
          set
          {
            this.class89_0 = value;
          }
        }

        public bool method_0(Polyline2D.Subdivide1.Class89 segment)
        {
          if (segment != this.class89_0)
            return segment.class89_0 == this;
          return true;
        }

        public void method_1(double parameter, Point2D position)
        {
          if (this.list_0 == null)
            this.list_0 = new List<Polyline2D.Subdivide1.Class90>();
          this.list_0.Add(new Polyline2D.Subdivide1.Class90(parameter, position));
        }

        public void method_2(
          List<Point2D> points,
          List<int> polylinePointIndexes,
          Dictionary<Point2D, int> pointToIndex)
        {
          this.method_4(this.segment2D_0.Start, points, polylinePointIndexes, pointToIndex);
          if (this.list_0 == null)
            return;
          this.list_0.Sort();
          for (int index = 0; index < this.list_0.Count; ++index)
            this.method_4(this.list_0[index].Position, points, polylinePointIndexes, pointToIndex);
        }

        public void method_3(
          List<Point2D> points,
          List<int> polylinePointIndexes,
          Dictionary<Point2D, int> pointToIndex)
        {
          this.method_4(this.segment2D_0.Start, points, polylinePointIndexes, pointToIndex);
        }

        private void method_4(
          Point2D p,
          List<Point2D> points,
          List<int> polylinePointIndexes,
          Dictionary<Point2D, int> pointToIndex)
        {
          int count1;
          if (!pointToIndex.TryGetValue(p, out count1))
          {
            count1 = points.Count;
            points.Add(p);
            pointToIndex.Add(p, count1);
          }
          int count2 = polylinePointIndexes.Count;
          if (count2 > 0)
          {
            if (polylinePointIndexes[count2 - 1] == count1)
              return;
            polylinePointIndexes.Add(count1);
          }
          else
            polylinePointIndexes.Add(count1);
        }

        public override string ToString()
        {
          return string.Format("{0}, intersections: {1}", (object) this.segment2D_0, (object) (this.list_0 == null ? 0 : this.list_0.Count));
        }
      }

      private class Class90 : IComparable<Polyline2D.Subdivide1.Class90>
      {
        private double double_0;
        private Point2D point2D_0;

        public Class90(double parameter, Point2D position)
        {
          this.double_0 = parameter;
          this.point2D_0 = position;
        }

        public Point2D Position
        {
          get
          {
            return this.point2D_0;
          }
        }

        public int CompareTo(Polyline2D.Subdivide1.Class90 other)
        {
          return this.double_0 >= other.double_0 ? (this.double_0 <= other.double_0 ? 0 : 1) : -1;
        }
      }

      private class Class91 : IComparable<Polyline2D.Subdivide1.Class91>
      {
        private double double_0;
        private List<Polyline2D.Subdivide1.Class89> list_0;
        private List<Polyline2D.Subdivide1.Class89> list_1;

        public Class91(double x)
        {
          this.double_0 = x;
        }

        public List<Polyline2D.Subdivide1.Class89> EntrySegments
        {
          get
          {
            return this.list_0;
          }
        }

        public List<Polyline2D.Subdivide1.Class89> ExitSegments
        {
          get
          {
            return this.list_1;
          }
        }

        public List<Polyline2D.Subdivide1.Class89> EntrySegmentsNotNull
        {
          get
          {
            if (this.list_0 == null)
              this.list_0 = new List<Polyline2D.Subdivide1.Class89>();
            return this.list_0;
          }
        }

        public List<Polyline2D.Subdivide1.Class89> ExitSegmentsNotNull
        {
          get
          {
            if (this.list_1 == null)
              this.list_1 = new List<Polyline2D.Subdivide1.Class89>();
            return this.list_1;
          }
        }

        public override string ToString()
        {
          return string.Format("{0}, entry segments: {1}, exit segments: {2}", (object) this.double_0, (object) (this.list_0 == null ? 0 : this.list_0.Count), (object) (this.list_1 == null ? 0 : this.list_1.Count));
        }

        public int CompareTo(Polyline2D.Subdivide1.Class91 other)
        {
          if (this.double_0 < other.double_0)
            return -1;
          return this.double_0 > other.double_0 ? 1 : 0;
        }
      }
    }
  }
}
