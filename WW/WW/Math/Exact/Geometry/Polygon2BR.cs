// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.Polygon2BR
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using ns3;
using ns8;
using System;
using System.Collections;
using System.Collections.Generic;
using WW.Collections.Generic;
using WW.Math.Geometry;

namespace WW.Math.Exact.Geometry
{
  [Serializable]
  public class Polygon2BR : List<Point2BR>
  {
    private static readonly BigRational Six = new BigRational(6);

    public static List<Polygon2BR> GetIntersection(
      IList<Polygon2BR> input1,
      IList<Polygon2BR> input2)
    {
      return Polygon2BR.BooleanOperations.GetIntersection(input1, input2);
    }

    public static List<Polygon2BR> GetDifference(
      IList<Polygon2BR> input1,
      IList<Polygon2BR> input2)
    {
      return Polygon2BR.BooleanOperations.GetDifference(input1, input2);
    }

    public static List<Polygon2BR> GetUnion(
      IList<Polygon2BR> input1,
      IList<Polygon2BR> input2)
    {
      return Polygon2BR.BooleanOperations.GetUnion(input1, input2);
    }

    public static List<Polygon2BR> GetExclusiveOr(
      IList<Polygon2BR> region1,
      IList<Polygon2BR> region2)
    {
      return Polygon2BR.BooleanOperations.GetExclusiveOr(region1, region2);
    }

    public Polygon2BR()
    {
    }

    public Polygon2BR(int capacity)
      : base(capacity)
    {
    }

    public Polygon2BR(params Point2BR[] points)
      : base((IEnumerable<Point2BR>) points)
    {
    }

    public Polygon2BR(IEnumerable<Point2BR> points)
      : base(points)
    {
    }

    public Polygon2BR(Polygon2BR polyline)
      : base((IEnumerable<Point2BR>) polyline)
    {
    }

    public Point2BR? GetCentroid()
    {
      return Polygon2BR.GetCentroid((IList<Point2BR>) this);
    }

    public Point2BR? GetCentroid(out BigRational area)
    {
      return Polygon2BR.GetCentroid((IList<Point2BR>) this, out area);
    }

    public bool IsConvex()
    {
      int count = this.Count;
      if (count <= 3)
        return true;
      BigRational bigRational1 = BigRational.Zero;
      Point2BR point2Br1 = this[count - 2];
      Point2BR point2Br2 = this[count - 1];
      Vector2BR u = point2Br2 - point2Br1;
      for (int index = 0; index < count; ++index)
      {
        Point2BR point2Br3 = this[index];
        Vector2BR v = point2Br3 - point2Br2;
        BigRational bigRational2 = Vector2BR.CrossProduct(u, v);
        if (bigRational1.IsZero)
          bigRational1 = bigRational2;
        else if (!bigRational2.IsZero)
        {
          if (bigRational2.IsPositive)
          {
            if (bigRational1.IsNegative)
              return false;
          }
          else if (bigRational1.IsPositive)
            return false;
        }
        u = v;
        point2Br2 = point2Br3;
      }
      return true;
    }

    public bool IsInside(Point2BR p)
    {
      return (Polygon2BR.GetWindingNumber(p.X, p.Y, (IList<Point2BR>) this) & 1) == 1;
    }

    public int GetNoOfIntersections(Ray2BR ray)
    {
      return Polygon2BR.GetNoOfIntersections((IList<Point2BR>) this, ray);
    }

    public bool IsClockwise()
    {
      return Polygon2BR.IsClockwise((IList<Point2BR>) this);
    }

    public BigRational GetArea()
    {
      return Polygon2BR.GetArea((IList<Point2BR>) this);
    }

    public Polygon2BR GetReverse()
    {
      Polygon2BR polygon2Br = new Polygon2BR(this.Count);
      for (int index = this.Count - 1; index >= 0; --index)
        polygon2Br.Add(this[index]);
      return polygon2Br;
    }

    public Polygon2D ToPolygon2D()
    {
      Polygon2D polygon2D = new Polygon2D(this.Count);
      foreach (Point2BR point2Br in (List<Point2BR>) this)
        polygon2D.Add(new Point2D((double) point2Br.X, (double) point2Br.Y));
      return polygon2D;
    }

    public bool HasSegments
    {
      get
      {
        return this.Count > 0;
      }
    }

    public static bool IsInside(Point2BR p, IList<Point2BR> polygon)
    {
      return (Polygon2BR.GetWindingNumber(p.X, p.Y, polygon) & 1) == 1;
    }

    public static bool IsInsidePolygons(Point2BR p, IEnumerator polygonsEnumerator)
    {
      if (polygonsEnumerator == null)
        return false;
      int num = 0;
      polygonsEnumerator.Reset();
      while (polygonsEnumerator.MoveNext())
        num += Polygon2BR.GetWindingNumber(p.X, p.Y, (IList<Point2BR>) polygonsEnumerator.Current);
      return (num & 1) == 1;
    }

    public static bool IsInside(Point2BR p, IEnumerable<IList<Point2BR>> polygons)
    {
      return Polygon2BR.IsInsidePolygons(p, (IEnumerator) polygons.GetEnumerator());
    }

    public static int GetWindingNumber(Point2BR p, IList<Point2BR> polygon)
    {
      return Polygon2BR.GetWindingNumber(p.X, p.Y, polygon);
    }

    public static int GetWindingNumber(BigRational x, BigRational y, IList<Point2BR> polygon)
    {
      int num = 0;
      int count = polygon.Count;
      if (count > 0)
      {
        Point2BR point2Br1 = polygon[count - 1];
        for (int index = 0; index < count; ++index)
        {
          Point2BR point2Br2 = polygon[index];
          if (point2Br1.Y <= y)
          {
            if (point2Br2.Y > y && Polygon2BR.smethod_4(point2Br1.X, point2Br1.Y, point2Br2.X, point2Br2.Y, x, y).IsPositive)
              ++num;
          }
          else if (point2Br2.Y <= y && Polygon2BR.smethod_4(point2Br1.X, point2Br1.Y, point2Br2.X, point2Br2.Y, x, y).IsNegative)
            --num;
          point2Br1 = point2Br2;
        }
      }
      return num;
    }

    public static int GetNoOfIntersections(IList<Point2BR> polygon, Ray2BR ray)
    {
      return Polygon2BR.GetNoOfIntersections(polygon, ray, 0, polygon.Count - 1);
    }

    public static int GetNoOfIntersections(
      IList<Point2BR> points,
      Ray2BR ray,
      int startIndex,
      int endIndex)
    {
      if (endIndex - startIndex < 1)
        return 0;
      int num = 0;
      Point2BR start = points[startIndex];
      Point2BR end = start;
      for (int index = startIndex + 1; index <= endIndex; ++index)
      {
        Point2BR point = points[index];
        Segment2BR b = new Segment2BR(start, point);
        if (Ray2BR.Intersects(ray, b))
          ++num;
        start = point;
      }
      Segment2BR b1 = new Segment2BR(start, end);
      if (Ray2BR.Intersects(ray, b1))
        ++num;
      return num;
    }

    public static bool IsClockwise(IList<Point2BR> polygon)
    {
      return Polygon2BR.smethod_0(polygon).IsNegative;
    }

    public static BigRational GetArea(IList<Point2BR> polygon)
    {
      return Polygon2BR.smethod_0(polygon).DivideByTwo();
    }

    private static BigRational smethod_0(IList<Point2BR> polygon)
    {
      int count = polygon.Count;
      if (count < 3)
        return BigRational.Zero;
      BigRational zero = BigRational.Zero;
      Point2BR point2Br1 = polygon[count - 1];
      for (int index = 0; index < count; ++index)
      {
        Point2BR point2Br2 = polygon[index];
        zero += point2Br1.X * point2Br2.Y - point2Br2.X * point2Br1.Y;
        point2Br1 = point2Br2;
      }
      return zero;
    }

    public static bool IsClockwise(Point2BR p0, Point2BR p1, Point2BR p2, Point2BR p3)
    {
      return Polygon2BR.smethod_1(p0, p1, p2, p3).IsNegative;
    }

    public static BigRational GetArea(
      Point2BR p0,
      Point2BR p1,
      Point2BR p2,
      Point2BR p3)
    {
      return Polygon2BR.smethod_1(p0, p1, p2, p3).DivideByTwo();
    }

    private static BigRational smethod_1(
      Point2BR p0,
      Point2BR p1,
      Point2BR p2,
      Point2BR p3)
    {
      return BigRational.Zero + (p0.X * p1.Y - p1.X * p0.Y) + (p1.X * p2.Y - p2.X * p1.Y) + (p2.X * p3.Y - p3.X * p2.Y) + (p3.X * p0.Y - p0.X * p3.Y);
    }

    public static Point2BR? GetCentroid(IList<Point2BR> polygon)
    {
      BigRational area;
      return Polygon2BR.GetCentroid(polygon, out area);
    }

    public static Point2BR? GetCentroid(IList<Point2BR> polygon, out BigRational area)
    {
      int count = polygon.Count;
      area = BigRational.Zero;
      if (count < 3)
      {
        switch (count)
        {
          case 0:
            return new Point2BR?();
          case 1:
            return new Point2BR?(polygon[0]);
          case 2:
            return new Point2BR?(Point2BR.GetMidPoint(polygon[0], polygon[0]));
        }
      }
      Point2BR point2Br1 = polygon[count - 1];
      Point2BR zero = Point2BR.Zero;
      for (int index = 0; index < count; ++index)
      {
        Point2BR point2Br2 = polygon[index];
        BigRational bigRational = point2Br1.X * point2Br2.Y - point2Br2.X * point2Br1.Y;
        area += bigRational;
        zero.X += (point2Br1.X + point2Br2.X) * bigRational;
        zero.Y += (point2Br1.Y + point2Br2.Y) * bigRational;
        point2Br1 = point2Br2;
      }
      area = area.DivideByTwo();
      zero.X /= Polygon2BR.Six * area;
      zero.Y /= Polygon2BR.Six * area;
      return new Point2BR?(zero);
    }

    public static void GetSegments(IList<Point2BR> polygon, IList<Segment2BR> segments)
    {
      int count = polygon.Count;
      Point2BR start = polygon[count - 1];
      for (int index = 0; index < count; ++index)
      {
        Point2BR end = polygon[index];
        Segment2BR segment2Br = new Segment2BR(start, end);
        segments.Add(segment2Br);
        start = end;
      }
    }

    public Polygon2BR GetConvexHull()
    {
      return Polygon2BR.GetConvexHull((IList<Point2BR>) this);
    }

    public static Polygon2BR GetConvexHull(IList<Point2BR> polygon)
    {
      LinkedList<Point2BR> linkedList = new LinkedList<Point2BR>();
      int num;
      for (num = 0; num + 2 < polygon.Count; ++num)
      {
        BigRational bigRational = Polygon2BR.smethod_2(polygon[0], polygon[num + 1], polygon[num + 2]);
        if (!bigRational.IsPositive)
        {
          if (bigRational.IsNegative)
          {
            linkedList.AddLast(polygon[num + 2]);
            linkedList.AddLast(polygon[num + 2]);
            LinkedListNode<Point2BR> node = linkedList.AddAfter(linkedList.First, polygon[num + 1]);
            linkedList.AddAfter(node, polygon[0]);
            break;
          }
        }
        else
        {
          linkedList.AddLast(polygon[num + 2]);
          linkedList.AddLast(polygon[num + 2]);
          LinkedListNode<Point2BR> node = linkedList.AddAfter(linkedList.First, polygon[0]);
          linkedList.AddAfter(node, polygon[num + 1]);
          break;
        }
      }
      for (int index = num + 3; index < polygon.Count; ++index)
      {
        Point2BR p2 = polygon[index];
        if (!Polygon2BR.smethod_2(linkedList.First.Value, linkedList.First.Next.Value, p2).IsPositive || !Polygon2BR.smethod_2(linkedList.Last.Previous.Value, linkedList.Last.Value, p2).IsPositive)
        {
          while (linkedList.First.Next != null && !Polygon2BR.smethod_2(linkedList.First.Value, linkedList.First.Next.Value, p2).IsPositive)
            linkedList.RemoveFirst();
          linkedList.AddFirst(p2);
          while (linkedList.Last.Previous != null && !Polygon2BR.smethod_2(linkedList.Last.Previous.Value, linkedList.Last.Value, p2).IsPositive)
            linkedList.RemoveLast();
          linkedList.AddLast(p2);
        }
      }
      Polygon2BR polygon2Br = new Polygon2BR();
      LinkedListNode<Point2BR> linkedListNode = linkedList.First;
      for (int index = 1; index < linkedList.Count; ++index)
      {
        LinkedListNode<Point2BR> next = linkedListNode.Next;
        polygon2Br.Add(linkedListNode.Value);
        linkedListNode = next;
      }
      return polygon2Br;
    }

    private static BigRational smethod_2(Point2BR p0, Point2BR p1, Point2BR p2)
    {
      return (p1.X - p0.X) * (p2.Y - p0.Y) - (p2.X - p0.X) * (p1.Y - p0.Y);
    }

    private static void smethod_3(
      IList<Point2BR> convexPolygon,
      int n,
      Vector2BR direction,
      ref int j,
      ref BigRational projection)
    {
      int num = j;
      j = (j + 1) % n;
      while (j != num)
      {
        BigRational bigRational = Vector2BR.DotProduct(direction, convexPolygon[j] - Point2BR.Zero);
        if (!(bigRational < projection))
        {
          projection = bigRational;
          j = (j + 1) % n;
        }
        else
          break;
      }
      --j;
      if (j >= 0)
        return;
      j = n - 1;
    }

    private static BigRational smethod_4(
      BigRational x1,
      BigRational y1,
      BigRational x2,
      BigRational y2,
      BigRational x3,
      BigRational y3)
    {
      return (x2 - x1) * (y3 - y1) - (y2 - y1) * (x3 - x1);
    }

    public class BooleanOperations
    {
      static BooleanOperations()
      {
        Class123.smethod_0(Enum0.const_3);
      }

            public static List<Polygon2BR> GetUnion(IList<Polygon2BR> input1, IList<Polygon2BR> input2)
            {
                return Polygon2BR.BooleanOperations.GetUnion(input1, input2);
            }


            public static List<Polygon2BR> GetDifference(IList<Polygon2BR> input1, IList<Polygon2BR> input2)
            {
                return Polygon2BR.BooleanOperations.GetDifference(input1, input2);
            }

            public static List<Polygon2BR> GetIntersection(IList<Polygon2BR> input1, IList<Polygon2BR> input2)
            {
                return Polygon2BR.BooleanOperations.GetIntersection(input1, input2);
            }
            public static List<Polygon2BR> GetExclusiveOr(IList<Polygon2BR> region1, IList<Polygon2BR> region2)
            {
                return Polygon2BR.BooleanOperations.GetExclusiveOr(region1, region2);
            }

            private static void smethod_0(
        IList<Polygon2BR> region1,
        bool reverseRegion1,
        IList<Polygon2BR> region2,
        bool reverseRegion2,
        out Polygon2BR.BooleanOperations.Region splitRegion1,
        out Polygon2BR.BooleanOperations.Region splitRegion2,
        out List<Polygon2BR.BooleanOperations.Segment> segments)
      {
        Polygon2BR.BooleanOperations.Context context = new Polygon2BR.BooleanOperations.Context();
        Polygon2BR.BooleanOperations.Region region3 = Polygon2BR.BooleanOperations.smethod_3(region1, context, reverseRegion1);
        Polygon2BR.BooleanOperations.Region region4 = Polygon2BR.BooleanOperations.smethod_3(region2, context, reverseRegion2);
        new Polygon2BR.BooleanOperations.Class117(new Polygon2BR.BooleanOperations.Class29()
        {
          region3,
          region4
        }, context).method_0(true);
        context.method_1();
        splitRegion1 = Polygon2BR.BooleanOperations.smethod_2(region3);
        splitRegion2 = Polygon2BR.BooleanOperations.smethod_2(region4);
        splitRegion1.method_2(splitRegion2);
        splitRegion2.method_2(splitRegion1);
        segments = new List<Polygon2BR.BooleanOperations.Segment>();
        splitRegion1.method_4((IList<Polygon2BR.BooleanOperations.Segment>) segments);
        splitRegion2.method_4((IList<Polygon2BR.BooleanOperations.Segment>) segments);
      }

      private static void smethod_1(
        Polygon2BR.BooleanOperations.Segment startSegment,
        Polygon2BR.BooleanOperations.Region resultRegion,
        Func<Polygon2BR.BooleanOperations.Segment, bool> includeSegment,
        ref int n)
      {
        Polygon2BR.BooleanOperations.Segment segment1 = startSegment;
        Polygon2BR.BooleanOperations.Class119 class119 = (Polygon2BR.BooleanOperations.Class119) null;
        Polygon2BR.BooleanOperations.Segment segment2 = (Polygon2BR.BooleanOperations.Segment) null;
        while (n > 0)
        {
          segment1.Processed = true;
          --n;
          if (!includeSegment(segment1))
            break;
          if (segment2 == null)
          {
            segment2 = segment1;
            class119 = new Polygon2BR.BooleanOperations.Class119(resultRegion);
            resultRegion.Add(class119);
          }
          class119.Add(segment1);
          if (segment1.End == segment2.Start)
            break;
          segment1 = segment1.End.method_3(segment1, includeSegment);
        }
      }

      private static Polygon2BR.BooleanOperations.Region smethod_2(
        Polygon2BR.BooleanOperations.Region region)
      {
        Polygon2BR.BooleanOperations.Region region1 = new Polygon2BR.BooleanOperations.Region(region.Reversed);
        foreach (Polygon2BR.BooleanOperations.Class119 class119 in (List<Polygon2BR.BooleanOperations.Class119>) region)
        {
          Polygon2BR.BooleanOperations.Class119 splitPolygon = new Polygon2BR.BooleanOperations.Class119(region1);
          region1.Add(splitPolygon);
          foreach (Polygon2BR.BooleanOperations.Segment segment in (List<Polygon2BR.BooleanOperations.Segment>) class119)
            segment.vmethod_1(splitPolygon);
          Polygon2BR.BooleanOperations.Segment inSegment = splitPolygon[splitPolygon.Count - 1];
          foreach (Polygon2BR.BooleanOperations.Segment outSegment in (List<Polygon2BR.BooleanOperations.Segment>) splitPolygon)
          {
            outSegment.Start.method_0(new Polygon2BR.BooleanOperations.Class112(inSegment, outSegment));
            inSegment = outSegment;
          }
        }
        return region1;
      }

      private static Polygon2BR.BooleanOperations.Region smethod_3(
        IList<Polygon2BR> input,
        Polygon2BR.BooleanOperations.Context context,
        bool reverse)
      {
        Polygon2BR.BooleanOperations.Region region = new Polygon2BR.BooleanOperations.Region(reverse);
        foreach (Polygon2BR inputPolygon in (IEnumerable<Polygon2BR>) input)
        {
          if (inputPolygon.Count > 0)
          {
            Polygon2BR.BooleanOperations.Class119 polygon = new Polygon2BR.BooleanOperations.Class119(region);
            region.Add(polygon);
            if (reverse)
              Polygon2BR.BooleanOperations.smethod_5(inputPolygon, polygon, context);
            else
              Polygon2BR.BooleanOperations.smethod_4(inputPolygon, polygon, context);
          }
        }
        return region;
      }

      private static void smethod_4(
        Polygon2BR inputPolygon,
        Polygon2BR.BooleanOperations.Class119 polygon,
        Polygon2BR.BooleanOperations.Context context)
      {
        Point2BR p1 = inputPolygon[inputPolygon.Count - 1];
        Polygon2BR.BooleanOperations.Class111 start = context.method_0(p1);
        for (int index = 0; index < inputPolygon.Count; ++index)
        {
          Point2BR p2 = inputPolygon[index];
          Polygon2BR.BooleanOperations.Class111 end = context.method_0(p2);
          Polygon2BR.BooleanOperations.Segment segment = (Polygon2BR.BooleanOperations.Segment) new Polygon2BR.BooleanOperations.Class114(polygon, start, end);
          polygon.Add(segment);
          start = end;
        }
      }

      private static void smethod_5(
        Polygon2BR inputPolygon,
        Polygon2BR.BooleanOperations.Class119 polygon,
        Polygon2BR.BooleanOperations.Context context)
      {
        Point2BR p1 = inputPolygon[0];
        Polygon2BR.BooleanOperations.Class111 start = context.method_0(p1);
        for (int index = inputPolygon.Count - 1; index >= 0; --index)
        {
          Point2BR p2 = inputPolygon[index];
          Polygon2BR.BooleanOperations.Class111 end = context.method_0(p2);
          Polygon2BR.BooleanOperations.Segment segment = (Polygon2BR.BooleanOperations.Segment) new Polygon2BR.BooleanOperations.Class114(polygon, start, end);
          polygon.Add(segment);
          start = end;
        }
      }

      internal class Class111
      {
        private List<Polygon2BR.BooleanOperations.Class112> list_0 = new List<Polygon2BR.BooleanOperations.Class112>();
        private Point2BR point2BR_0;

        public Class111()
        {
        }

        public Class111(Point2BR position)
        {
          this.point2BR_0 = position;
        }

        public Point2BR Position
        {
          get
          {
            return this.point2BR_0;
          }
          set
          {
            this.point2BR_0 = value;
          }
        }

        public List<Polygon2BR.BooleanOperations.Class112> Vertices
        {
          get
          {
            return this.list_0;
          }
        }

        public void method_0(Polygon2BR.BooleanOperations.Class112 vertex)
        {
          int index = this.list_0.BinarySearch(vertex, (IComparer<Polygon2BR.BooleanOperations.Class112>) Polygon2BR.BooleanOperations.Class112.Class113.class113_0);
          if (index < 0)
            this.list_0.Insert(~index, vertex);
          else
            this.list_0.Insert(index, vertex);
        }

        public void method_1(Polygon2BR.BooleanOperations.Segment inSegment)
        {
          for (int index = this.list_0.Count - 1; index >= 0; --index)
          {
            if (this.list_0[index].InSegment == inSegment)
              this.list_0.RemoveAt(index);
          }
        }

        public void method_2(Polygon2BR.BooleanOperations.Segment outSegment)
        {
          for (int index = this.list_0.Count - 1; index >= 0; --index)
          {
            if (this.list_0[index].OutSegment == outSegment)
              this.list_0.RemoveAt(index);
          }
        }

        public Polygon2BR.BooleanOperations.Segment method_3(
          Polygon2BR.BooleanOperations.Segment segment,
          Func<Polygon2BR.BooleanOperations.Segment, bool> includeSegment)
        {
          Vector2BR b = -segment.Direction;
          Polygon2BR.BooleanOperations.Segment segment1 = (Polygon2BR.BooleanOperations.Segment) null;
          for (int index = this.list_0.Count - 1; index >= 0; --index)
          {
            Polygon2BR.BooleanOperations.Class112 class112 = this.list_0[index];
            if (!class112.OutSegment.Processed && Vector2BR.CompareAngles(class112.OutSegment.Direction, b) < 0 && includeSegment(class112.OutSegment))
            {
              segment1 = class112.OutSegment;
              break;
            }
          }
          if (segment1 == null)
          {
            for (int index = this.list_0.Count - 1; index >= 0; --index)
            {
              Polygon2BR.BooleanOperations.Class112 class112 = this.list_0[index];
              if (!class112.OutSegment.Processed && includeSegment(class112.OutSegment))
              {
                segment1 = class112.OutSegment;
                break;
              }
            }
            if (segment1 == null)
              throw new Exception("Could not find connecting segment.");
          }
          return segment1;
        }

        public Polygon2BR.BooleanOperations.Segment method_4(
          Polygon2BR.BooleanOperations.Segment segment,
          Polygon2BR.BooleanOperations.Segment segmentSource,
          Func<Polygon2BR.BooleanOperations.Segment, bool> includeSegment,
          out Polygon2BR.BooleanOperations.Segment resultSource)
        {
          Vector2BR b1 = -segment.Direction;
          resultSource = (Polygon2BR.BooleanOperations.Segment) null;
          Polygon2BR.BooleanOperations.Segment segment1 = (Polygon2BR.BooleanOperations.Segment) null;
          Vector2BR b2 = Vector2BR.Zero;
          for (int index = this.list_0.Count - 1; index >= 0; --index)
          {
            Polygon2BR.BooleanOperations.Class112 class112 = this.list_0[index];
            if (!class112.OutSegment.Processed && class112.OutSegment != segmentSource && (Vector2BR.CompareAngles(class112.OutSegment.Direction, b1) < 0 && includeSegment(class112.OutSegment)) && (segment1 == null || Vector2BR.CompareAngles(class112.OutSegment.Direction, b2) > 0))
            {
              resultSource = class112.OutSegment;
              segment1 = class112.OutSegment;
              b2 = class112.OutSegment.Direction;
            }
            if (!class112.InSegment.Processed && class112.InSegment != segmentSource && (Vector2BR.CompareAngles(-class112.InSegment.Direction, b1) < 0 && includeSegment(class112.InSegment)) && (segment1 == null || Vector2BR.CompareAngles(-class112.InSegment.Direction, b2) > 0))
            {
              resultSource = class112.InSegment;
              segment1 = class112.InSegment.vmethod_4(segmentSource.Polygon);
              b2 = -class112.InSegment.Direction;
            }
          }
          if (segment1 == null)
          {
            for (int index = this.list_0.Count - 1; index >= 0; --index)
            {
              Polygon2BR.BooleanOperations.Class112 class112 = this.list_0[index];
              if (!class112.OutSegment.Processed && class112.OutSegment != segmentSource && includeSegment(class112.OutSegment) && (segment1 == null || Vector2BR.CompareAngles(class112.OutSegment.Direction, b2) > 0))
              {
                resultSource = class112.OutSegment;
                segment1 = class112.OutSegment;
                b2 = class112.OutSegment.Direction;
              }
              if (!class112.InSegment.Processed && class112.InSegment != segmentSource && includeSegment(class112.InSegment) && (segment1 == null || Vector2BR.CompareAngles(-class112.InSegment.Direction, b2) > 0))
              {
                resultSource = class112.InSegment;
                segment1 = class112.InSegment.vmethod_4(segmentSource.Polygon);
                b2 = -class112.InSegment.Direction;
              }
            }
          }
          if (segment1 == null)
          {
            for (int index = this.list_0.Count - 1; index >= 0; --index)
            {
              Polygon2BR.BooleanOperations.Class112 class112 = this.list_0[index];
              Vector2BR vector2Br;
              if (!class112.OutSegment.Processed && class112.OutSegment != segmentSource && (class112.OutSegment.method_10(segmentSource) && includeSegment(class112.OutSegment)) && segment1 == null)
              {
                resultSource = class112.OutSegment;
                segment1 = class112.OutSegment;
                vector2Br = class112.OutSegment.Direction;
              }
              if (!class112.InSegment.Processed && class112.InSegment != segmentSource && (class112.InSegment.method_10(segmentSource) && includeSegment(class112.InSegment)) && segment1 == null)
              {
                resultSource = class112.InSegment;
                segment1 = class112.InSegment.vmethod_4(segmentSource.Polygon);
                vector2Br = -class112.InSegment.Direction;
              }
            }
          }
          if (resultSource != null)
            resultSource.Processed = true;
          return segment1;
        }

        public override string ToString()
        {
          return string.Format("Position: {0}, vertices: {1}", (object) this.point2BR_0, (object) this.list_0.Count);
        }
      }

      internal class Class112
      {
        private Polygon2BR.BooleanOperations.Segment segment_0;
        private Polygon2BR.BooleanOperations.Segment segment_1;

        public Class112(
          Polygon2BR.BooleanOperations.Segment inSegment,
          Polygon2BR.BooleanOperations.Segment outSegment)
        {
          this.segment_0 = inSegment;
          this.segment_1 = outSegment;
        }

        public Polygon2BR.BooleanOperations.Segment InSegment
        {
          get
          {
            return this.segment_0;
          }
          set
          {
            this.segment_0 = value;
          }
        }

        public Polygon2BR.BooleanOperations.Segment OutSegment
        {
          get
          {
            return this.segment_1;
          }
          set
          {
            this.segment_1 = value;
          }
        }

        public Polygon2BR.BooleanOperations.Class111 Point
        {
          get
          {
            return this.segment_0.End;
          }
        }

        public Polygon2BR.BooleanOperations.Region Region
        {
          get
          {
            return this.segment_0.Region;
          }
        }

        public bool method_0(Polygon2BR.BooleanOperations.Segment segment)
        {
          if (segment.Start != this.segment_0.End)
            throw new ArgumentException();
          Vector2BR vector2Br = -this.segment_0.Direction;
          Vector2BR direction1 = this.segment_1.Direction;
          Vector2BR direction2 = segment.Direction;
          int num1 = Vector2BR.CompareAngles(vector2Br, direction1);
          int num2 = Vector2BR.CompareAngles(direction2, vector2Br);
          int num3 = Vector2BR.CompareAngles(direction2, direction1);
          return num1 < 0 ? num2 <= 0 || num3 >= 0 : num2 <= 0 && num3 >= 0;
        }

        public override string ToString()
        {
          return string.Format("Position: {0}, vertices: {1}", (object) this.Point.Position, (object) this.Point.Vertices.Count);
        }

        public class Class113 : IComparer<Polygon2BR.BooleanOperations.Class112>
        {
          public static readonly Polygon2BR.BooleanOperations.Class112.Class113 class113_0 = new Polygon2BR.BooleanOperations.Class112.Class113();

          private Class113()
          {
          }

          public int Compare(
            Polygon2BR.BooleanOperations.Class112 x,
            Polygon2BR.BooleanOperations.Class112 y)
          {
            return Vector2BR.CompareAngles(x.segment_1.Direction, y.segment_1.Direction);
          }
        }
      }

      internal class Segment
      {
        private Polygon2BR.BooleanOperations.Class119 class119_0;
        private Polygon2BR.BooleanOperations.Class111 class111_0;
        private Polygon2BR.BooleanOperations.Class111 class111_1;
        private Polygon2BR.BooleanOperations.Enum3 enum3_0;
        private bool bool_0;
        private Vector2BR vector2BR_0;

        public Segment()
        {
        }

        public Segment(
          Polygon2BR.BooleanOperations.Class119 polygon,
          Polygon2BR.BooleanOperations.Class111 start,
          Polygon2BR.BooleanOperations.Class111 end)
        {
          if (start == end)
            throw new ArgumentException("Start and end point may not be the same.");
          this.class119_0 = polygon;
          this.class111_0 = start;
          this.class111_1 = end;
        }

        public Polygon2BR.BooleanOperations.Class119 Polygon
        {
          get
          {
            return this.class119_0;
          }
          set
          {
            this.class119_0 = value;
          }
        }

        public Polygon2BR.BooleanOperations.Class111 Start
        {
          get
          {
            return this.class111_0;
          }
          set
          {
            this.class111_0 = value;
          }
        }

        public Polygon2BR.BooleanOperations.Class111 End
        {
          get
          {
            return this.class111_1;
          }
          set
          {
            this.class111_1 = value;
          }
        }

        public Polygon2BR.BooleanOperations.Enum3 Status
        {
          get
          {
            return this.enum3_0;
          }
          set
          {
            this.enum3_0 = value;
          }
        }

        public bool Processed
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

        public Vector2BR Direction
        {
          get
          {
            return this.vector2BR_0;
          }
          internal set
          {
            this.vector2BR_0 = value;
          }
        }

        public Polygon2BR.BooleanOperations.Region Region
        {
          get
          {
            return this.class119_0.Region;
          }
        }

        public virtual void vmethod_0(Polygon2BR.BooleanOperations.Class118 intersection)
        {
          throw new NotImplementedException();
        }

        public virtual void vmethod_1(Polygon2BR.BooleanOperations.Class119 splitPolygon)
        {
          throw new NotImplementedException();
        }

        public virtual void vmethod_2(Polygon2BR.BooleanOperations.Class119 splitPolygon)
        {
          throw new NotImplementedException();
        }

        public void method_0(Polygon2BR.BooleanOperations.Region otherRegion)
        {
          if (this.enum3_0 != Polygon2BR.BooleanOperations.Enum3.const_0)
            return;
          this.method_3(otherRegion);
          if (this.enum3_0 != Polygon2BR.BooleanOperations.Enum3.const_0)
            return;
          if (this.method_1(otherRegion) == 0)
          {
            if (otherRegion.method_0(this.class111_0.Position))
              this.enum3_0 = Polygon2BR.BooleanOperations.Enum3.const_1;
            else
              this.enum3_0 = Polygon2BR.BooleanOperations.Enum3.const_2;
          }
          else
            this.method_4(otherRegion);
        }

        private int method_1(Polygon2BR.BooleanOperations.Region region)
        {
          int num = 0;
          foreach (Polygon2BR.BooleanOperations.Class112 vertex in this.class111_0.Vertices)
          {
            if (vertex.Region == region)
              ++num;
          }
          return num;
        }

        public void method_2(
          Polygon2BR.BooleanOperations.Segment previousSegment,
          Polygon2BR.BooleanOperations.Region otherRegion)
        {
          if (this.enum3_0 != Polygon2BR.BooleanOperations.Enum3.const_0)
            return;
          if (this.method_1(otherRegion) == 0)
          {
            this.enum3_0 = previousSegment.enum3_0;
          }
          else
          {
            this.method_3(otherRegion);
            if (this.enum3_0 != Polygon2BR.BooleanOperations.Enum3.const_0)
              return;
            this.method_4(otherRegion);
          }
        }

        private void method_3(Polygon2BR.BooleanOperations.Region otherRegion)
        {
          foreach (Polygon2BR.BooleanOperations.Class112 vertex in this.class111_0.Vertices)
          {
            if (vertex.Region == otherRegion)
            {
              if (vertex.InSegment.class111_0 != this.class111_1)
              {
                if (vertex.OutSegment.class111_1 == this.class111_1)
                {
                  this.enum3_0 = Polygon2BR.BooleanOperations.Enum3.const_3;
                  break;
                }
              }
              else
              {
                this.enum3_0 = Polygon2BR.BooleanOperations.Enum3.const_4;
                break;
              }
            }
          }
        }

        private void method_4(Polygon2BR.BooleanOperations.Region otherRegion)
        {
          this.enum3_0 = Polygon2BR.BooleanOperations.Enum3.const_2;
          foreach (Polygon2BR.BooleanOperations.Class112 vertex in this.class111_0.Vertices)
          {
            if (vertex.Region == otherRegion && vertex.method_0(this))
            {
              this.enum3_0 = Polygon2BR.BooleanOperations.Enum3.const_1;
              break;
            }
          }
        }

        public void method_5()
        {
          this.vector2BR_0 = this.class111_1.Position - this.class111_0.Position;
        }

        public void method_6()
        {
          this.class111_0.method_2(this);
          Polygon2BR.BooleanOperations.Class111 class1110 = this.class111_0;
          this.class111_0 = this.class111_1;
          this.class111_1 = class1110;
          this.method_5();
          this.class111_0.method_0(new Polygon2BR.BooleanOperations.Class112((Polygon2BR.BooleanOperations.Segment) null, this));
        }

        public Segment2BR method_7()
        {
          return new Segment2BR(this.class111_0.Position, this.class111_1.Position);
        }

        public override string ToString()
        {
          return string.Format("Start: {0}, End: {1}, Status: {2}", (object) this.class111_0, (object) this.class111_1, (object) this.enum3_0);
        }

        internal virtual Polygon2BR.BooleanOperations.Segment vmethod_3(
          Polygon2BR.BooleanOperations.Class119 result)
        {
          return new Polygon2BR.BooleanOperations.Segment(result, this.class111_0, this.class111_1) { vector2BR_0 = this.vector2BR_0 };
        }

        internal virtual Polygon2BR.BooleanOperations.Segment vmethod_4(
          Polygon2BR.BooleanOperations.Class119 result)
        {
          return new Polygon2BR.BooleanOperations.Segment(result, this.class111_1, this.class111_0) { vector2BR_0 = -this.vector2BR_0 };
        }

        internal bool method_8(Point2BR position)
        {
          if ((!(position.X >= this.Start.Position.X) || !(position.X <= this.End.Position.X)) && (!(position.X >= this.End.Position.X) || !(position.X <= this.Start.Position.X)))
            return false;
          if (position.Y >= this.Start.Position.Y && position.Y <= this.End.Position.Y)
            return true;
          if (position.Y >= this.End.Position.Y)
            return position.Y <= this.Start.Position.Y;
          return false;
        }

        internal bool method_9(Polygon2BR.BooleanOperations.Segment otherSegment)
        {
          if (this.class111_0 != otherSegment.class111_0 && this.class111_0 != otherSegment.class111_1 && this.class111_1 != otherSegment.class111_0)
            return this.class111_1 == otherSegment.class111_1;
          return true;
        }

        internal bool method_10(Polygon2BR.BooleanOperations.Segment other)
        {
          if (this.class111_0 == other.class111_0 && this.class111_1 == other.class111_1)
            return true;
          if (this.class111_0 == other.class111_1)
            return this.class111_1 == other.class111_0;
          return false;
        }
      }

      private class Class29 : RedBlackTree<Polygon2BR.BooleanOperations.Class115>
      {
        public void Add(Polygon2BR.BooleanOperations.Region region)
        {
          Polygon2BR.BooleanOperations.Class115.Class116 class116 = new Polygon2BR.BooleanOperations.Class115.Class116();
          foreach (List<Polygon2BR.BooleanOperations.Segment> segmentList in (List<Polygon2BR.BooleanOperations.Class119>) region)
          {
            foreach (Polygon2BR.BooleanOperations.Segment segment in segmentList)
            {
              Point2BR position1 = segment.Start.Position;
              Point2BR position2 = segment.End.Position;
              if (position1.X > position2.X || position1.X == position2.X && position1.Y > position2.Y)
                MathUtil.Swap<Point2BR>(ref position1, ref position2);
              class116.Position = position1;
              Polygon2BR.BooleanOperations.Class115 class115_1 = this.Find((IComparable<Polygon2BR.BooleanOperations.Class115>) class116);
              if (class115_1 == null)
              {
                class115_1 = new Polygon2BR.BooleanOperations.Class115(position1);
                this.Add(class115_1);
              }
              class115_1.EntrySegmentsNotNull.Add(segment);
              class116.Position = position2;
              Polygon2BR.BooleanOperations.Class115 class115_2 = this.Find((IComparable<Polygon2BR.BooleanOperations.Class115>) class116);
              if (class115_2 == null)
              {
                class115_2 = new Polygon2BR.BooleanOperations.Class115(position2);
                this.Add(class115_2);
              }
              class115_2.ExitSegmentsNotNull.Add(segment);
            }
          }
        }
      }

      private class Class115 : IComparable<Polygon2BR.BooleanOperations.Class115>
      {
        private Point2BR point2BR_0;
        private List<Polygon2BR.BooleanOperations.Segment> list_0;
        private List<Polygon2BR.BooleanOperations.Segment> list_1;

        public Class115(Point2BR position)
        {
          this.point2BR_0 = position;
        }

        public Point2BR Position
        {
          get
          {
            return this.point2BR_0;
          }
          set
          {
            this.point2BR_0 = value;
          }
        }

        public List<Polygon2BR.BooleanOperations.Segment> EntrySegments
        {
          get
          {
            return this.list_0;
          }
        }

        public List<Polygon2BR.BooleanOperations.Segment> ExitSegments
        {
          get
          {
            return this.list_1;
          }
        }

        public List<Polygon2BR.BooleanOperations.Segment> EntrySegmentsNotNull
        {
          get
          {
            if (this.list_0 == null)
              this.list_0 = new List<Polygon2BR.BooleanOperations.Segment>();
            return this.list_0;
          }
        }

        public List<Polygon2BR.BooleanOperations.Segment> ExitSegmentsNotNull
        {
          get
          {
            if (this.list_1 == null)
              this.list_1 = new List<Polygon2BR.BooleanOperations.Segment>();
            return this.list_1;
          }
        }

        public override string ToString()
        {
          return this.point2BR_0.ToString();
        }

        public int CompareTo(Polygon2BR.BooleanOperations.Class115 other)
        {
          if (this.point2BR_0.X < other.point2BR_0.X)
            return -1;
          if (this.point2BR_0.X > other.point2BR_0.X)
            return 1;
          if (this.point2BR_0.Y < other.point2BR_0.Y)
            return -1;
          return this.point2BR_0.Y > other.point2BR_0.Y ? 1 : 0;
        }

        public class Class116 : IComparable<Polygon2BR.BooleanOperations.Class115>
        {
          private Point2BR point2BR_0;

          public Point2BR Position
          {
            get
            {
              return this.point2BR_0;
            }
            set
            {
              this.point2BR_0 = value;
            }
          }

          public int CompareTo(Polygon2BR.BooleanOperations.Class115 other)
          {
            if (this.point2BR_0.X < other.point2BR_0.X)
              return -1;
            if (this.point2BR_0.X > other.point2BR_0.X)
              return 1;
            if (this.point2BR_0.Y < other.point2BR_0.Y)
              return -1;
            return this.point2BR_0.Y > other.point2BR_0.Y ? 1 : 0;
          }
        }
      }

      private class Class117
      {
        private List<Polygon2BR.BooleanOperations.Segment> list_0 = new List<Polygon2BR.BooleanOperations.Segment>();
        private Polygon2BR.BooleanOperations.Class29 class29_0;
        private RedBlackTree<Polygon2BR.BooleanOperations.Class115>.ForwardEnumerator forwardEnumerator_0;
        private Polygon2BR.BooleanOperations.Context context_0;

        public Class117(
          Polygon2BR.BooleanOperations.Class29 eventQueue,
          Polygon2BR.BooleanOperations.Context context)
        {
          this.class29_0 = eventQueue;
          this.context_0 = context;
          this.forwardEnumerator_0 = (RedBlackTree<Polygon2BR.BooleanOperations.Class115>.ForwardEnumerator) eventQueue.GetEnumerator();
        }

        public void method_0(bool ignoreIntraRegionIntersections)
        {
          while (this.forwardEnumerator_0.MoveNext())
          {
            Polygon2BR.BooleanOperations.Class115 current = this.forwardEnumerator_0.Current;
            if (current.EntrySegments != null)
            {
              foreach (Polygon2BR.BooleanOperations.Segment entrySegment in current.EntrySegments)
              {
                foreach (Polygon2BR.BooleanOperations.Segment otherSegment in this.list_0)
                {
                  if (ignoreIntraRegionIntersections)
                  {
                    if (entrySegment.Region == otherSegment.Region)
                      continue;
                  }
                  else if (entrySegment.method_9(otherSegment))
                    continue;
                  BigRational[] pArray;
                  BigRational[] qArray;
                  if (Segment2BR.GetIntersectionParameters(entrySegment.method_7(), otherSegment.method_7(), out pArray, out qArray))
                  {
                    for (int index = 0; index < pArray.Length; ++index)
                    {
                      BigRational parameter1 = pArray[index];
                      BigRational parameter2 = qArray[index];
                      Polygon2BR.BooleanOperations.Class111 point = (Polygon2BR.BooleanOperations.Class111) null;
                      bool flag1 = true;
                      if (parameter1.IsZero)
                      {
                        flag1 = false;
                        point = entrySegment.Start;
                      }
                      else if (parameter1 == BigRational.One)
                      {
                        flag1 = false;
                        point = entrySegment.End;
                      }
                      bool flag2 = true;
                      if (point == null)
                      {
                        if (parameter2.IsZero)
                        {
                          flag2 = false;
                          point = otherSegment.Start;
                        }
                        else if (parameter2 == BigRational.One)
                        {
                          flag2 = false;
                          point = otherSegment.End;
                        }
                      }
                      if (point == null)
                        point = this.context_0.method_0(entrySegment.Start.Position + parameter1 * (entrySegment.End.Position - entrySegment.Start.Position));
                      if (flag1)
                      {
                        Polygon2BR.BooleanOperations.Class118 intersection = new Polygon2BR.BooleanOperations.Class118(parameter1, point);
                        entrySegment.vmethod_0(intersection);
                      }
                      if (flag2)
                      {
                        Polygon2BR.BooleanOperations.Class118 intersection = new Polygon2BR.BooleanOperations.Class118(parameter2, point);
                        otherSegment.vmethod_0(intersection);
                      }
                    }
                  }
                }
                this.list_0.Add(entrySegment);
              }
            }
            if (current.ExitSegments != null)
            {
              foreach (Polygon2BR.BooleanOperations.Segment exitSegment in current.ExitSegments)
                this.list_0.Remove(exitSegment);
            }
          }
        }
      }

      internal enum Enum3 : byte
      {
        const_0,
        const_1,
        const_2,
        const_3,
        const_4,
      }

      private class Class114 : Polygon2BR.BooleanOperations.Segment
      {
        private SortedList<Polygon2BR.BooleanOperations.Class118> sortedList_0 = new SortedList<Polygon2BR.BooleanOperations.Class118>();

        public Class114()
        {
        }

        public Class114(
          Polygon2BR.BooleanOperations.Class119 polygon,
          Polygon2BR.BooleanOperations.Class111 start,
          Polygon2BR.BooleanOperations.Class111 end)
          : base(polygon, start, end)
        {
        }

        public override void vmethod_0(Polygon2BR.BooleanOperations.Class118 intersection)
        {
          if (intersection.Point == this.Start || intersection.Point == this.End)
            return;
          Polygon2BR.BooleanOperations.Class118 class118_1 = (Polygon2BR.BooleanOperations.Class118) null;
          for (int index = 0; index < this.sortedList_0.Count; ++index)
          {
            Polygon2BR.BooleanOperations.Class118 class118_2 = this.sortedList_0[index];
            if (class118_2.Parameter == intersection.Parameter || class118_2.Point == intersection.Point)
            {
              class118_1 = class118_2;
              break;
            }
          }
          if (class118_1 != null)
            return;
          this.sortedList_0.Add(intersection);
        }

        public override void vmethod_1(Polygon2BR.BooleanOperations.Class119 splitPolygon)
        {
          if (this.sortedList_0.Count == 0)
          {
            this.method_11(splitPolygon, this.Start, this.End);
          }
          else
          {
            Polygon2BR.BooleanOperations.Class111 p0 = this.Start;
            foreach (Polygon2BR.BooleanOperations.Class118 class118 in this.sortedList_0)
            {
              Polygon2BR.BooleanOperations.Class111 point = class118.Point;
              this.method_11(splitPolygon, p0, point);
              p0 = point;
            }
            this.method_11(splitPolygon, p0, this.End);
          }
        }

        private void method_11(
          Polygon2BR.BooleanOperations.Class119 splitPolygon,
          Polygon2BR.BooleanOperations.Class111 p0,
          Polygon2BR.BooleanOperations.Class111 p1)
        {
          Polygon2BR.BooleanOperations.Segment segment = new Polygon2BR.BooleanOperations.Segment(splitPolygon, p0, p1);
          segment.method_5();
          splitPolygon.Add(segment);
        }

        internal override Polygon2BR.BooleanOperations.Segment vmethod_3(
          Polygon2BR.BooleanOperations.Class119 result)
        {
          Polygon2BR.BooleanOperations.Class114 class114 = new Polygon2BR.BooleanOperations.Class114(result, this.Start, this.End);
          class114.Direction = this.Direction;
          return (Polygon2BR.BooleanOperations.Segment) class114;
        }

        internal override Polygon2BR.BooleanOperations.Segment vmethod_4(
          Polygon2BR.BooleanOperations.Class119 result)
        {
          Polygon2BR.BooleanOperations.Class114 class114 = new Polygon2BR.BooleanOperations.Class114(result, this.End, this.Start);
          class114.Direction = -this.Direction;
          return (Polygon2BR.BooleanOperations.Segment) class114;
        }
      }

      internal class Class118 : IComparable<Polygon2BR.BooleanOperations.Class118>
      {
        private BigRational bigRational_0;
        private Polygon2BR.BooleanOperations.Class111 class111_0;

        public Class118(BigRational parameter, Polygon2BR.BooleanOperations.Class111 point)
        {
          this.bigRational_0 = parameter;
          this.class111_0 = point;
        }

        public BigRational Parameter
        {
          get
          {
            return this.bigRational_0;
          }
        }

        public Polygon2BR.BooleanOperations.Class111 Point
        {
          get
          {
            return this.class111_0;
          }
        }

        public override string ToString()
        {
          return string.Format("Parameter: {0}, position: {1}", (object) this.bigRational_0, (object) this.class111_0);
        }

        public int CompareTo(Polygon2BR.BooleanOperations.Class118 other)
        {
          if (this.bigRational_0 < other.bigRational_0)
            return -1;
          return this.bigRational_0 > other.bigRational_0 ? 1 : 0;
        }
      }

      internal class Region : List<Polygon2BR.BooleanOperations.Class119>
      {
        private bool bool_0;
        private int int_0;

        public Region(bool reversed)
        {
          this.bool_0 = reversed;
          if (!reversed)
            return;
          this.int_0 = -1;
        }

        public bool Reversed
        {
          get
          {
            return this.bool_0;
          }
        }

        public bool method_0(Point2BR p)
        {
          return this.method_1(p) > this.int_0;
        }

        public int method_1(Point2BR p)
        {
          int num = 0;
          foreach (Polygon2BR.BooleanOperations.Class119 polygon in (List<Polygon2BR.BooleanOperations.Class119>) this)
            num += Polygon2BR.BooleanOperations.Class119.smethod_1(p.X, p.Y, polygon);
          return num;
        }

        public void method_2(Polygon2BR.BooleanOperations.Region otherRegion)
        {
          foreach (Polygon2BR.BooleanOperations.Class119 class119 in (List<Polygon2BR.BooleanOperations.Class119>) this)
            class119.method_0(otherRegion);
        }

        public List<Polygon2BR> method_3()
        {
          List<Polygon2BR> polygon2BrList = new List<Polygon2BR>(this.Count);
          foreach (Polygon2BR.BooleanOperations.Class119 class119 in (List<Polygon2BR.BooleanOperations.Class119>) this)
          {
            Polygon2BR polygon2Br = new Polygon2BR(class119.Count);
            foreach (Polygon2BR.BooleanOperations.Segment segment in (List<Polygon2BR.BooleanOperations.Segment>) class119)
              polygon2Br.Add(segment.Start.Position);
            polygon2BrList.Add(polygon2Br);
          }
          return polygon2BrList;
        }

        public void method_4(
          IList<Polygon2BR.BooleanOperations.Segment> segments)
        {
          foreach (List<Polygon2BR.BooleanOperations.Segment> segmentList in (List<Polygon2BR.BooleanOperations.Class119>) this)
          {
            foreach (Polygon2BR.BooleanOperations.Segment segment in segmentList)
              segments.Add(segment);
          }
        }

        public Polygon2BR.BooleanOperations.Region method_5()
        {
          Polygon2BR.BooleanOperations.Region targetRegion = new Polygon2BR.BooleanOperations.Region(!this.bool_0);
          for (int index = this.Count - 1; index >= 0; --index)
            targetRegion.Add(this[index].method_1(targetRegion));
          return targetRegion;
        }

        public List<Polygon2BR> method_6()
        {
          List<Polygon2BR> polygon2BrList = new List<Polygon2BR>(this.Count);
          foreach (Polygon2BR.BooleanOperations.Class119 class119 in (List<Polygon2BR.BooleanOperations.Class119>) this)
          {
            Polygon2BR polygon2Br = class119.method_4();
            polygon2BrList.Add(polygon2Br);
          }
          return polygon2BrList;
        }

        public Polygon2BR.BooleanOperations.Region method_7(
          Polygon2BR.BooleanOperations.Context context)
        {
          new Polygon2BR.BooleanOperations.Class117(new Polygon2BR.BooleanOperations.Class29()
          {
            this
          }, context).method_0(false);
          context.method_1();
          Polygon2BR.BooleanOperations.Region region1 = Polygon2BR.BooleanOperations.smethod_2(this);
          List<Polygon2BR.BooleanOperations.Segment> segmentList1 = new List<Polygon2BR.BooleanOperations.Segment>();
          foreach (Polygon2BR.BooleanOperations.Class119 class119 in (List<Polygon2BR.BooleanOperations.Class119>) region1)
            segmentList1.AddRange((IEnumerable<Polygon2BR.BooleanOperations.Segment>) class119);
          foreach (Polygon2BR.BooleanOperations.Segment segment in segmentList1)
            segment.Status = Polygon2BR.BooleanOperations.Enum3.const_0;
          foreach (Polygon2BR.BooleanOperations.Segment other in segmentList1)
          {
            if (other.End.Vertices.Count > 1)
            {
              foreach (Polygon2BR.BooleanOperations.Class112 vertex in other.End.Vertices)
              {
                if (vertex.InSegment != other && vertex.InSegment.method_10(other))
                {
                  other.Status = Polygon2BR.BooleanOperations.Enum3.const_3;
                  vertex.InSegment.Status = Polygon2BR.BooleanOperations.Enum3.const_3;
                }
                if (vertex.OutSegment != other && vertex.OutSegment.method_10(other))
                {
                  other.Status = Polygon2BR.BooleanOperations.Enum3.const_3;
                  vertex.OutSegment.Status = Polygon2BR.BooleanOperations.Enum3.const_3;
                }
              }
            }
          }
          Polygon2BR.BooleanOperations.Region region2 = new Polygon2BR.BooleanOperations.Region(this.bool_0);
          int num1 = segmentList1.Count;
          foreach (Polygon2BR.BooleanOperations.Segment segment1 in segmentList1)
          {
            if (!segment1.Processed && segment1.Status != Polygon2BR.BooleanOperations.Enum3.const_3)
            {
              Polygon2BR.BooleanOperations.Class119 result = new Polygon2BR.BooleanOperations.Class119(region2);
              List<Polygon2BR.BooleanOperations.Segment> segmentList2 = new List<Polygon2BR.BooleanOperations.Segment>();
              segment1.Processed = true;
              result.Add(segment1);
              --num1;
              Polygon2BR.BooleanOperations.Segment segment2 = segment1;
              Polygon2BR.BooleanOperations.Segment resultSource1 = segment1;
              while (num1 > 0)
              {
                segment2 = segment2.End.method_4(segment2, resultSource1, (Func<Polygon2BR.BooleanOperations.Segment, bool>) (s => s.Status != Polygon2BR.BooleanOperations.Enum3.const_3), out resultSource1);
                if (segment2 != null)
                {
                  result.Add(segment2);
                  segmentList2.Add(resultSource1);
                  --num1;
                  if (segment2.End == segment1.Start)
                    break;
                }
                else
                  break;
              }
              if (result.method_3())
              {
                int num2 = num1 + result.Count;
                foreach (Polygon2BR.BooleanOperations.Segment segment3 in segmentList2)
                  segment3.Processed = false;
                result.Clear();
                Polygon2BR.BooleanOperations.Segment resultSource2 = segment1;
                Polygon2BR.BooleanOperations.Segment segment4 = segment1.vmethod_4(result);
                result.Add(segment4);
                num1 = num2 - 1;
                while (num1 > 0)
                {
                  segment4 = segment4.End.method_4(segment4, resultSource2, (Func<Polygon2BR.BooleanOperations.Segment, bool>) (s => s.Status != Polygon2BR.BooleanOperations.Enum3.const_3), out resultSource2);
                  if (segment4 != null)
                  {
                    result.Add(segment4);
                    --num1;
                    if (segment4.End == segment1.End)
                      break;
                  }
                  else
                    break;
                }
              }
              region2.Add(result);
            }
          }
          for (int index = region2.Count - 1; index >= 0; --index)
          {
            Polygon2BR.BooleanOperations.Class119 class119 = region2[index];
            if (class119.Count < 3 || class119[0].Start != class119[class119.Count - 1].End)
              region2.RemoveAt(index);
          }
          return region2;
        }

        internal void method_8()
        {
          foreach (Polygon2BR.BooleanOperations.Class119 class119 in (List<Polygon2BR.BooleanOperations.Class119>) this)
            class119.method_5();
        }
      }

      internal class Class119 : List<Polygon2BR.BooleanOperations.Segment>
      {
        private Polygon2BR.BooleanOperations.Region region_0;

        public Class119(Polygon2BR.BooleanOperations.Region region)
        {
          this.region_0 = region;
        }

        public Polygon2BR.BooleanOperations.Region Region
        {
          get
          {
            return this.region_0;
          }
        }

        public static int smethod_0(Point2BR p, Polygon2BR.BooleanOperations.Class119 polygon)
        {
          return Polygon2BR.BooleanOperations.Class119.smethod_1(p.X, p.Y, polygon);
        }

        public static int smethod_1(
          BigRational x,
          BigRational y,
          Polygon2BR.BooleanOperations.Class119 polygon)
        {
          int num = 0;
          int count = polygon.Count;
          if (count > 0)
          {
            Point2BR point2Br = polygon[count - 1].Start.Position;
            for (int index = 0; index < count; ++index)
            {
              Point2BR position = polygon[index].Start.Position;
              if (point2Br.Y <= y)
              {
                if (position.Y > y && Polygon2BR.smethod_4(point2Br.X, point2Br.Y, position.X, position.Y, x, y).IsPositive)
                  ++num;
              }
              else if (position.Y <= y && Polygon2BR.smethod_4(point2Br.X, point2Br.Y, position.X, position.Y, x, y).IsNegative)
                --num;
              point2Br = position;
            }
          }
          return num;
        }

        public void method_0(Polygon2BR.BooleanOperations.Region otherRegion)
        {
          if (this.Count <= 0)
            return;
          Polygon2BR.BooleanOperations.Segment previousSegment = this[0];
          previousSegment.method_0(otherRegion);
          for (int index = 1; index < this.Count; ++index)
          {
            Polygon2BR.BooleanOperations.Segment segment = this[index];
            segment.method_2(previousSegment, otherRegion);
            previousSegment = segment;
          }
        }

        public Polygon2BR.BooleanOperations.Class119 method_1(
          Polygon2BR.BooleanOperations.Region targetRegion)
        {
          Polygon2BR.BooleanOperations.Class119 result = new Polygon2BR.BooleanOperations.Class119(targetRegion);
          for (int index = this.Count - 1; index >= 0; --index)
            result.Add(this[index].vmethod_4(result));
          return result;
        }

        public BigRational method_2()
        {
          int count = this.Count;
          if (count < 3)
            return BigRational.Zero;
          BigRational zero = BigRational.Zero;
          Point2BR point2Br = this[count - 1].Start.Position;
          for (int index = 0; index < count; ++index)
          {
            Point2BR position = this[index].Start.Position;
            zero += point2Br.X * position.Y - position.X * point2Br.Y;
            point2Br = position;
          }
          return zero;
        }

        public bool method_3()
        {
          if (this.Count < 3)
            return false;
          int index1 = this.Count - 1;
          Polygon2BR.BooleanOperations.Segment segment1 = this[index1];
          int index2 = 0;
          Polygon2BR.BooleanOperations.Segment segment2 = this[0];
          Polygon2BR.BooleanOperations.Segment segment3 = segment2;
          int num1 = 0;
          for (int index3 = 1; index3 < this.Count; ++index3)
          {
            Polygon2BR.BooleanOperations.Segment segment4 = this[index3];
            if (segment4.Start.Position.X < segment2.Start.Position.X || segment4.Start.Position.X == segment2.Start.Position.X && segment4.Start.Position.Y < segment2.Start.Position.Y)
            {
              index1 = num1;
              segment1 = segment3;
              index2 = index3;
              segment2 = segment4;
            }
            segment3 = segment4;
            num1 = index3;
          }
          int num2;
          for (num2 = this.Count - 2; num2 > 0 && segment1.Start == segment2.End; num2 -= 2)
          {
            index1 = (index1 + this.Count - 1) % this.Count;
            segment1 = this[index1];
            index2 = (index2 + 1) % this.Count;
            segment2 = this[index2];
          }
          if (num2 <= 0)
            return false;
          return Vector2BR.CrossProduct(segment1.Direction, segment2.Direction).IsNegative;
        }

        internal Polygon2BR method_4()
        {
          Polygon2BR polygon2Br = new Polygon2BR(this.Count + 1);
          if (this.Count > 0)
          {
            foreach (Polygon2BR.BooleanOperations.Segment segment in (List<Polygon2BR.BooleanOperations.Segment>) this)
              polygon2Br.Add(segment.Start.Position);
            if (this[this.Count - 1].End != this[0].Start)
              polygon2Br.Add(this[this.Count - 1].End.Position);
          }
          return polygon2Br;
        }

        internal void method_5()
        {
          foreach (Polygon2BR.BooleanOperations.Segment segment in (List<Polygon2BR.BooleanOperations.Segment>) this)
            segment.Status = Polygon2BR.BooleanOperations.Enum3.const_0;
        }
      }

      public class Context
      {
        private Dictionary<Point2BR, Polygon2BR.BooleanOperations.Class111> dictionary_0 = new Dictionary<Point2BR, Polygon2BR.BooleanOperations.Class111>();

        internal Polygon2BR.BooleanOperations.Class111 method_0(Point2BR p)
        {
          Polygon2BR.BooleanOperations.Class111 class111;
          if (!this.dictionary_0.TryGetValue(p, out class111))
          {
            class111 = new Polygon2BR.BooleanOperations.Class111(p);
            this.dictionary_0.Add(p, class111);
          }
          return class111;
        }

        internal void method_1()
        {
          foreach (KeyValuePair<Point2BR, Polygon2BR.BooleanOperations.Class111> keyValuePair in this.dictionary_0)
            keyValuePair.Value.Vertices.Clear();
        }
      }

      [Serializable]
      internal class DebugInfo
      {
        private Polygon2BR.BooleanOperations.Region region1;
        private Polygon2BR.BooleanOperations.Region region2;
        private Polygon2BR.BooleanOperations.Region resultRegion;
        private List<Polygon2BR.BooleanOperations.Segment> segments;
        private Polygon2BR.BooleanOperations.Segment highlightSegment;

        public Polygon2BR.BooleanOperations.Region Region1
        {
          get
          {
            return this.region1;
          }
          set
          {
            this.region1 = value;
          }
        }

        public Polygon2BR.BooleanOperations.Region Region2
        {
          get
          {
            return this.region2;
          }
          set
          {
            this.region2 = value;
          }
        }

        public Polygon2BR.BooleanOperations.Region ResultRegion
        {
          get
          {
            return this.resultRegion;
          }
          set
          {
            this.resultRegion = value;
          }
        }

        public List<Polygon2BR.BooleanOperations.Segment> Segments
        {
          get
          {
            return this.segments;
          }
          set
          {
            this.segments = value;
          }
        }

        public Polygon2BR.BooleanOperations.Segment HighlightSegment
        {
          get
          {
            return this.highlightSegment;
          }
          set
          {
            this.highlightSegment = value;
          }
        }
      }
    }
  }
}
