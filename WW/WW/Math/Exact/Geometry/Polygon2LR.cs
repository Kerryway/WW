// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.Polygon2LR
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
    public class Polygon2LR : List<Point2LR>
    {
        private static readonly LongRational Six = new LongRational(6);

        public Polygon2LR()
        {
        }

        public Polygon2LR(int capacity)
          : base(capacity)
        {
        }

        public Polygon2LR(params Point2LR[] points)
          : base((IEnumerable<Point2LR>)points)
        {
        }

        public Polygon2LR(IEnumerable<Point2LR> points)
          : base(points)
        {
        }

        public Polygon2LR(Polygon2LR polyline)
          : base((IEnumerable<Point2LR>)polyline)
        {
        }

        public Polygon2LR(Matrix4D transform, ICollection<Point2D> points)
          : this(points.Count)
        {
            foreach (Point2D point in (IEnumerable<Point2D>)points)
            {
                Point2D point2D = transform.Transform(point);
                this.Add(new Point2LR((int)point2D.X, (int)point2D.Y));
            }
        }

        public Point2LR? GetCentroid()
        {
            return Polygon2LR.GetCentroid((IList<Point2LR>)this);
        }

        public Point2LR? GetCentroid(out LongRational area)
        {
            return Polygon2LR.GetCentroid((IList<Point2LR>)this, out area);
        }

        public bool IsConvex()
        {
            int count = this.Count;
            if (count <= 3)
                return true;
            LongRational longRational1 = LongRational.Zero;
            Point2LR point2Lr1 = this[count - 2];
            Point2LR point2Lr2 = this[count - 1];
            Vector2LR u = point2Lr2 - point2Lr1;
            for (int index = 0; index < count; ++index)
            {
                Point2LR point2Lr3 = this[index];
                Vector2LR v = point2Lr3 - point2Lr2;
                LongRational longRational2 = Vector2LR.CrossProduct(u, v);
                if (longRational1.IsZero)
                    longRational1 = longRational2;
                else if (!longRational2.IsZero)
                {
                    if (longRational2.IsPositive)
                    {
                        if (longRational1.IsNegative)
                            return false;
                    }
                    else if (longRational1.IsPositive)
                        return false;
                }
                u = v;
                point2Lr2 = point2Lr3;
            }
            return true;
        }

        public bool IsInside(Point2LR p)
        {
            return (Polygon2LR.GetWindingNumber(p.X, p.Y, (IList<Point2LR>)this) & 1) == 1;
        }

        public int GetNoOfIntersections(Ray2LR ray)
        {
            return Polygon2LR.GetNoOfIntersections((IList<Point2LR>)this, ray);
        }

        public bool IsClockwise()
        {
            return Polygon2LR.IsClockwise((IList<Point2LR>)this);
        }

        public LongRational GetArea()
        {
            return Polygon2LR.GetArea((IList<Point2LR>)this);
        }

        public Polygon2LR GetReverse()
        {
            Polygon2LR polygon2Lr = new Polygon2LR(this.Count);
            for (int index = this.Count - 1; index >= 0; --index)
                polygon2Lr.Add(this[index]);
            return polygon2Lr;
        }

        public Polygon2D ToPolygon2D()
        {
            Polygon2D polygon2D = new Polygon2D(this.Count);
            foreach (Point2LR point2Lr in (List<Point2LR>)this)
                polygon2D.Add(new Point2D((double)point2Lr.X, (double)point2Lr.Y));
            return polygon2D;
        }

        public bool HasSegments
        {
            get
            {
                return this.Count > 0;
            }
        }

        public static bool IsInside(Point2LR p, IList<Point2LR> polygon)
        {
            return (Polygon2LR.GetWindingNumber(p.X, p.Y, polygon) & 1) == 1;
        }

        public static bool IsInsidePolygons(Point2LR p, IEnumerator polygonsEnumerator)
        {
            if (polygonsEnumerator == null)
                return false;
            int num = 0;
            polygonsEnumerator.Reset();
            while (polygonsEnumerator.MoveNext())
                num += Polygon2LR.GetWindingNumber(p.X, p.Y, (IList<Point2LR>)polygonsEnumerator.Current);
            return (num & 1) == 1;
        }

        public static bool IsInside(Point2LR p, IEnumerable<IList<Point2LR>> polygons)
        {
            return Polygon2LR.IsInsidePolygons(p, (IEnumerator)polygons.GetEnumerator());
        }

        public static int GetWindingNumber(Point2LR p, IList<Point2LR> polygon)
        {
            return Polygon2LR.GetWindingNumber(p.X, p.Y, polygon);
        }

        public static int GetWindingNumber(LongRational x, LongRational y, IList<Point2LR> polygon)
        {
            int num = 0;
            int count = polygon.Count;
            if (count > 0)
            {
                Point2LR point2Lr1 = polygon[count - 1];
                for (int index = 0; index < count; ++index)
                {
                    Point2LR point2Lr2 = polygon[index];
                    if (point2Lr1.Y <= y)
                    {
                        if (point2Lr2.Y > y && Polygon2LR.smethod_4(point2Lr1.X, point2Lr1.Y, point2Lr2.X, point2Lr2.Y, x, y).IsPositive)
                            ++num;
                    }
                    else if (point2Lr2.Y <= y && Polygon2LR.smethod_4(point2Lr1.X, point2Lr1.Y, point2Lr2.X, point2Lr2.Y, x, y).IsNegative)
                        --num;
                    point2Lr1 = point2Lr2;
                }
            }
            return num;
        }

        public static int GetNoOfIntersections(IList<Point2LR> polygon, Ray2LR ray)
        {
            return Polygon2LR.GetNoOfIntersections(polygon, ray, 0, polygon.Count - 1);
        }

        public static int GetNoOfIntersections(
          IList<Point2LR> points,
          Ray2LR ray,
          int startIndex,
          int endIndex)
        {
            if (endIndex - startIndex < 1)
                return 0;
            int num = 0;
            Point2LR start = points[startIndex];
            Point2LR end = start;
            for (int index = startIndex + 1; index <= endIndex; ++index)
            {
                Point2LR point = points[index];
                Segment2LR b = new Segment2LR(start, point);
                if (Ray2LR.Intersects(ray, b))
                    ++num;
                start = point;
            }
            Segment2LR b1 = new Segment2LR(start, end);
            if (Ray2LR.Intersects(ray, b1))
                ++num;
            return num;
        }

        public static bool IsClockwise(IList<Point2LR> polygon)
        {
            return Polygon2LR.smethod_0(polygon).IsNegative;
        }

        public static LongRational GetArea(IList<Point2LR> polygon)
        {
            return Polygon2LR.smethod_0(polygon).DivideByTwo();
        }

        private static LongRational smethod_0(IList<Point2LR> polygon)
        {
            int count = polygon.Count;
            if (count < 3)
                return LongRational.Zero;
            LongRational zero = LongRational.Zero;
            Point2LR point2Lr1 = polygon[count - 1];
            for (int index = 0; index < count; ++index)
            {
                Point2LR point2Lr2 = polygon[index];
                zero += point2Lr1.X * point2Lr2.Y - point2Lr2.X * point2Lr1.Y;
                point2Lr1 = point2Lr2;
            }
            return zero;
        }

        public static bool IsClockwise(Point2LR p0, Point2LR p1, Point2LR p2, Point2LR p3)
        {
            return Polygon2LR.smethod_1(p0, p1, p2, p3).IsNegative;
        }

        public static LongRational GetArea(
          Point2LR p0,
          Point2LR p1,
          Point2LR p2,
          Point2LR p3)
        {
            return Polygon2LR.smethod_1(p0, p1, p2, p3).DivideByTwo();
        }

        private static LongRational smethod_1(
          Point2LR p0,
          Point2LR p1,
          Point2LR p2,
          Point2LR p3)
        {
            return LongRational.Zero + (p0.X * p1.Y - p1.X * p0.Y) + (p1.X * p2.Y - p2.X * p1.Y) + (p2.X * p3.Y - p3.X * p2.Y) + (p3.X * p0.Y - p0.X * p3.Y);
        }

        public static Point2LR? GetCentroid(IList<Point2LR> polygon)
        {
            LongRational area;
            return Polygon2LR.GetCentroid(polygon, out area);
        }

        public static Point2LR? GetCentroid(IList<Point2LR> polygon, out LongRational area)
        {
            int count = polygon.Count;
            area = LongRational.Zero;
            if (count < 3)
            {
                switch (count)
                {
                    case 0:
                        return new Point2LR?();
                    case 1:
                        return new Point2LR?(polygon[0]);
                    case 2:
                        return new Point2LR?(Point2LR.GetMidPoint(polygon[0], polygon[0]));
                }
            }
            Point2LR point2Lr1 = polygon[count - 1];
            Point2LR zero = Point2LR.Zero;
            for (int index = 0; index < count; ++index)
            {
                Point2LR point2Lr2 = polygon[index];
                LongRational longRational = point2Lr1.X * point2Lr2.Y - point2Lr2.X * point2Lr1.Y;
                area += longRational;
                zero.X += (point2Lr1.X + point2Lr2.X) * longRational;
                zero.Y += (point2Lr1.Y + point2Lr2.Y) * longRational;
                point2Lr1 = point2Lr2;
            }
            area = area.DivideByTwo();
            zero.X /= Polygon2LR.Six * area;
            zero.Y /= Polygon2LR.Six * area;
            return new Point2LR?(zero);
        }

        public static void GetSegments(IList<Point2LR> polygon, IList<Segment2LR> segments)
        {
            int count = polygon.Count;
            Point2LR start = polygon[count - 1];
            for (int index = 0; index < count; ++index)
            {
                Point2LR end = polygon[index];
                Segment2LR segment2Lr = new Segment2LR(start, end);
                segments.Add(segment2Lr);
                start = end;
            }
        }

        public Polygon2LR GetConvexHull()
        {
            return Polygon2LR.GetConvexHull((IList<Point2LR>)this);
        }

        public static Polygon2LR GetConvexHull(IList<Point2LR> polygon)
        {
            LinkedList<Point2LR> linkedList = new LinkedList<Point2LR>();
            int num;
            for (num = 0; num + 2 < polygon.Count; ++num)
            {
                LongRational longRational = Polygon2LR.smethod_2(polygon[0], polygon[num + 1], polygon[num + 2]);
                if (!longRational.IsPositive)
                {
                    if (longRational.IsNegative)
                    {
                        linkedList.AddLast(polygon[num + 2]);
                        linkedList.AddLast(polygon[num + 2]);
                        LinkedListNode<Point2LR> node = linkedList.AddAfter(linkedList.First, polygon[num + 1]);
                        linkedList.AddAfter(node, polygon[0]);
                        break;
                    }
                }
                else
                {
                    linkedList.AddLast(polygon[num + 2]);
                    linkedList.AddLast(polygon[num + 2]);
                    LinkedListNode<Point2LR> node = linkedList.AddAfter(linkedList.First, polygon[0]);
                    linkedList.AddAfter(node, polygon[num + 1]);
                    break;
                }
            }
            for (int index = num + 3; index < polygon.Count; ++index)
            {
                Point2LR p2 = polygon[index];
                if (!Polygon2LR.smethod_2(linkedList.First.Value, linkedList.First.Next.Value, p2).IsPositive || !Polygon2LR.smethod_2(linkedList.Last.Previous.Value, linkedList.Last.Value, p2).IsPositive)
                {
                    while (linkedList.First.Next != null && !Polygon2LR.smethod_2(linkedList.First.Value, linkedList.First.Next.Value, p2).IsPositive)
                        linkedList.RemoveFirst();
                    linkedList.AddFirst(p2);
                    while (linkedList.Last.Previous != null && !Polygon2LR.smethod_2(linkedList.Last.Previous.Value, linkedList.Last.Value, p2).IsPositive)
                        linkedList.RemoveLast();
                    linkedList.AddLast(p2);
                }
            }
            Polygon2LR polygon2Lr = new Polygon2LR();
            LinkedListNode<Point2LR> linkedListNode = linkedList.First;
            for (int index = 1; index < linkedList.Count; ++index)
            {
                LinkedListNode<Point2LR> next = linkedListNode.Next;
                polygon2Lr.Add(linkedListNode.Value);
                linkedListNode = next;
            }
            return polygon2Lr;
        }

        private static LongRational smethod_2(Point2LR p0, Point2LR p1, Point2LR p2)
        {
            return (p1.X - p0.X) * (p2.Y - p0.Y) - (p2.X - p0.X) * (p1.Y - p0.Y);
        }

        private static void smethod_3(
          IList<Point2LR> convexPolygon,
          int n,
          Vector2LR direction,
          ref int j,
          ref LongRational projection)
        {
            int num = j;
            j = (j + 1) % n;
            while (j != num)
            {
                LongRational longRational = Vector2LR.DotProduct(direction, convexPolygon[j] - Point2LR.Zero);
                if (!(longRational < projection))
                {
                    projection = longRational;
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

        private static LongRational smethod_4(
          LongRational x1,
          LongRational y1,
          LongRational x2,
          LongRational y2,
          LongRational x3,
          LongRational y3)
        {
            return (x2 - x1) * (y3 - y1) - (y2 - y1) * (x3 - x1);
        }

        private static BigRational smethod_5(
          BigRational x1,
          BigRational y1,
          BigRational x2,
          BigRational y2,
          BigRational x3,
          BigRational y3)
        {
            return (x2 - x1) * (y3 - y1) - (y2 - y1) * (x3 - x1);
        }

        private static bool smethod_6(
          LongRational x1,
          LongRational y1,
          LongRational x2,
          LongRational y2,
          LongRational x3,
          LongRational y3)
        {
            if (x1.Denominator == 1L && x2.Denominator == 1L && (x3.Denominator == 1L && y1.Denominator == 1L) && (y2.Denominator == 1L && y3.Denominator == 1L && (x1.Numerator >= -1073741824L && x1.Numerator <= 1073741823L)) && (x2.Numerator >= -1073741824L && x2.Numerator <= 1073741823L && (x3.Numerator >= -1073741824L && x3.Numerator <= 1073741823L) && (y1.Numerator >= -1073741824L && y1.Numerator <= 1073741823L && (y2.Numerator >= -1073741824L && y2.Numerator <= 1073741823L))) && (y3.Numerator >= -1073741824L && y3.Numerator <= 1073741823L))
                return Polygon2LR.smethod_4(x1, y1, x2, y2, x3, y3).IsPositive;
            BigRational x1_1 = new BigRational(new BigInteger(x1.Numerator), new BigInteger(x1.Denominator));
            BigRational x2_1 = new BigRational(new BigInteger(x2.Numerator), new BigInteger(x2.Denominator));
            BigRational x3_1 = new BigRational(new BigInteger(x3.Numerator), new BigInteger(x3.Denominator));
            BigRational y1_1 = new BigRational(new BigInteger(y1.Numerator), new BigInteger(y1.Denominator));
            BigRational y2_1 = new BigRational(new BigInteger(y2.Numerator), new BigInteger(y2.Denominator));
            BigRational y3_1 = new BigRational(new BigInteger(y3.Numerator), new BigInteger(y3.Denominator));
            return Polygon2LR.smethod_5(x1_1, y1_1, x2_1, y2_1, x3_1, y3_1).IsPositive;
        }

        private static bool smethod_7(
          LongRational x1,
          LongRational y1,
          LongRational x2,
          LongRational y2,
          LongRational x3,
          LongRational y3)
        {
            if (x1.Denominator == 1L && x2.Denominator == 1L && (x3.Denominator == 1L && y1.Denominator == 1L) && (y2.Denominator == 1L && y3.Denominator == 1L && (x1.Numerator >= -1073741824L && x1.Numerator <= 1073741823L)) && (x2.Numerator >= -1073741824L && x2.Numerator <= 1073741823L && (x3.Numerator >= -1073741824L && x3.Numerator <= 1073741823L) && (y1.Numerator >= -1073741824L && y1.Numerator <= 1073741823L && (y2.Numerator >= -1073741824L && y2.Numerator <= 1073741823L))) && (y3.Numerator >= -1073741824L && y3.Numerator <= 1073741823L))
                return Polygon2LR.smethod_4(x1, y1, x2, y2, x3, y3).IsNegative;
            BigRational x1_1 = new BigRational(new BigInteger(x1.Numerator), new BigInteger(x1.Denominator));
            BigRational x2_1 = new BigRational(new BigInteger(x2.Numerator), new BigInteger(x2.Denominator));
            BigRational x3_1 = new BigRational(new BigInteger(x3.Numerator), new BigInteger(x3.Denominator));
            BigRational y1_1 = new BigRational(new BigInteger(y1.Numerator), new BigInteger(y1.Denominator));
            BigRational y2_1 = new BigRational(new BigInteger(y2.Numerator), new BigInteger(y2.Denominator));
            BigRational y3_1 = new BigRational(new BigInteger(y3.Numerator), new BigInteger(y3.Denominator));
            return Polygon2LR.smethod_5(x1_1, y1_1, x2_1, y2_1, x3_1, y3_1).IsNegative;
        }

        public static List<Polygon2LR> GetIntersection(
          IList<Polygon2LR> input1,
          IList<Polygon2LR> input2)
        {
            return Polygon2LR.BooleanOperations.GetIntersection(input1, input2);
        }

        public static List<Polygon2LR> GetDifference(
          IList<Polygon2LR> input1,
          IList<Polygon2LR> input2)
        {
            return Polygon2LR.BooleanOperations.GetDifference(input1, input2);
        }

        public static List<Polygon2LR> GetUnion(
          IList<Polygon2LR> input1,
          IList<Polygon2LR> input2)
        {
            return Polygon2LR.BooleanOperations.GetUnion(input1, input2);
        }

        public static List<Polygon2LR> GetExclusiveOr(
          IList<Polygon2LR> region1,
          IList<Polygon2LR> region2)
        {
            return Polygon2LR.BooleanOperations.GetExclusiveOr(region1, region2);
        }

        public class BooleanOperations
        {
            private const int int_0 = 12;
            public const int MinInt = -524288;
            public const int MaxInt = 524287;

            static BooleanOperations()
            {
                Class123.smethod_0(Enum0.const_3);
            }

            public static List<Polygon2LR> GetUnion(
              IList<Polygon2LR> region1,
              IList<Polygon2LR> region2)
            {
                Polygon2LR.BooleanOperations.Region splitRegion1;
                Polygon2LR.BooleanOperations.Region splitRegion2;
                List<Polygon2LR.BooleanOperations.Segment> segments;
                Polygon2LR.BooleanOperations.smethod_5(region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                return Polygon2LR.BooleanOperations.smethod_0(splitRegion1, splitRegion2, segments).ToPolygon2LRList();
            }

            public static Polygon2LR.BooleanOperations.Region GetUnion(
              Polygon2LR.BooleanOperations.Context context,
              Polygon2LR.BooleanOperations.Region region1,
              Polygon2LR.BooleanOperations.Region region2)
            {
                Polygon2LR.BooleanOperations.Region splitRegion1;
                Polygon2LR.BooleanOperations.Region splitRegion2;
                List<Polygon2LR.BooleanOperations.Segment> segments;
                Polygon2LR.BooleanOperations.smethod_6(context, region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                return Polygon2LR.BooleanOperations.smethod_0(splitRegion1, splitRegion2, segments);
            }

            private static Polygon2LR.BooleanOperations.Region smethod_0(Polygon2LR.BooleanOperations.Region region1, Polygon2LR.BooleanOperations.Region region2, List<Polygon2LR.BooleanOperations.Segment> segments)
            {
                Polygon2LR.BooleanOperations.Region region = new Polygon2LR.BooleanOperations.Region(false);
                int count = segments.Count;
                foreach (Polygon2LR.BooleanOperations.Segment segment in segments)
                {
                    if (segment.Processed)
                    {
                        continue;
                    }
                    Polygon2LR.BooleanOperations.smethod_9(region1, region2, segments, segment, region, (Polygon2LR.BooleanOperations.Segment s) => (s.Region != region1 ? s.Status == Polygon2LR.BooleanOperations.SegmentStatus.Outside : (s.Status == Polygon2LR.BooleanOperations.SegmentStatus.Outside ? true : s.Status == Polygon2LR.BooleanOperations.SegmentStatus.Shared)), ref count);
                }
                return region;
            }

            public static List<Polygon2LR> GetDifference(
        IList<Polygon2LR> region1,
        IList<Polygon2LR> region2)
            {
                Polygon2LR.BooleanOperations.Region splitRegion1;
                Polygon2LR.BooleanOperations.Region splitRegion2;
                List<Polygon2LR.BooleanOperations.Segment> segments;
                Polygon2LR.BooleanOperations.smethod_5(region1, false, region2, true, out splitRegion1, out splitRegion2, out segments);
                return Polygon2LR.BooleanOperations.smethod_1(splitRegion1, splitRegion2, segments).ToPolygon2LRList();
            }

            public static Polygon2LR.BooleanOperations.Region GetDifference(
              Polygon2LR.BooleanOperations.Context context,
              Polygon2LR.BooleanOperations.Region region1,
              Polygon2LR.BooleanOperations.Region region2)
            {
                Polygon2LR.BooleanOperations.Region splitRegion1;
                Polygon2LR.BooleanOperations.Region splitRegion2;
                List<Polygon2LR.BooleanOperations.Segment> segments;
                Polygon2LR.BooleanOperations.smethod_6(context, region1, false, region2, true, out splitRegion1, out splitRegion2, out segments);
                return Polygon2LR.BooleanOperations.smethod_1(splitRegion1, splitRegion2, segments);
            }

            private static Polygon2LR.BooleanOperations.Region smethod_1(Polygon2LR.BooleanOperations.Region region1, Polygon2LR.BooleanOperations.Region region2, List<Polygon2LR.BooleanOperations.Segment> segments)
            {
                Polygon2LR.BooleanOperations.Region region = new Polygon2LR.BooleanOperations.Region(false);
                int count = segments.Count;
                foreach (Polygon2LR.BooleanOperations.Segment segment in segments)
                {
                    if (segment.Processed)
                    {
                        continue;
                    }
                    Polygon2LR.BooleanOperations.smethod_9(region1, region2, segments, segment, region, (Polygon2LR.BooleanOperations.Segment s) => (s.Region != region1 ? s.Status == Polygon2LR.BooleanOperations.SegmentStatus.Inside : (s.Status == Polygon2LR.BooleanOperations.SegmentStatus.Inside ? true : s.Status == Polygon2LR.BooleanOperations.SegmentStatus.Shared)), ref count);
                }
                return region;
            }

            public static List<Polygon2LR> GetIntersection(
              IList<Polygon2LR> region1,
              IList<Polygon2LR> region2)
            {
                Polygon2LR.BooleanOperations.Region splitRegion1;
                Polygon2LR.BooleanOperations.Region splitRegion2;
                List<Polygon2LR.BooleanOperations.Segment> segments;
                Polygon2LR.BooleanOperations.smethod_5(region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                return Polygon2LR.BooleanOperations.smethod_2(splitRegion1, splitRegion2, segments).ToPolygon2LRList();
            }

            public static Polygon2LR.BooleanOperations.Region GetIntersection(
              Polygon2LR.BooleanOperations.Context context,
              Polygon2LR.BooleanOperations.Region region1,
              Polygon2LR.BooleanOperations.Region region2)
            {
                Polygon2LR.BooleanOperations.Region splitRegion1;
                Polygon2LR.BooleanOperations.Region splitRegion2;
                List<Polygon2LR.BooleanOperations.Segment> segments;
                Polygon2LR.BooleanOperations.smethod_6(context, region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                return Polygon2LR.BooleanOperations.smethod_2(splitRegion1, splitRegion2, segments);
            }

            private static Polygon2LR.BooleanOperations.Region smethod_2(Polygon2LR.BooleanOperations.Region region1, Polygon2LR.BooleanOperations.Region region2, List<Polygon2LR.BooleanOperations.Segment> segments)
            {
                Polygon2LR.BooleanOperations.Region region = new Polygon2LR.BooleanOperations.Region(false);
                int count = segments.Count;
                foreach (Polygon2LR.BooleanOperations.Segment segment in segments)
                {
                    if (segment.Processed)
                    {
                        continue;
                    }
                    Polygon2LR.BooleanOperations.smethod_9(region1, region2, segments, segment, region, (Polygon2LR.BooleanOperations.Segment s) => (s.Region != region1 ? s.Status == Polygon2LR.BooleanOperations.SegmentStatus.Inside : (s.Status == Polygon2LR.BooleanOperations.SegmentStatus.Inside ? true : s.Status == Polygon2LR.BooleanOperations.SegmentStatus.Shared)), ref count);
                }
                return region;
            }

            public static List<Polygon2LR> GetExclusiveOr(
              IList<Polygon2LR> region1,
              IList<Polygon2LR> region2)
            {
                Polygon2LR.BooleanOperations.Region splitRegion1;
                Polygon2LR.BooleanOperations.Region splitRegion2;
                List<Polygon2LR.BooleanOperations.Segment> segments;
                Polygon2LR.BooleanOperations.smethod_5(region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                Polygon2LR.BooleanOperations.smethod_3(segments);
                return Polygon2LR.BooleanOperations.smethod_4(splitRegion1, splitRegion2, segments).ToPolygon2LRList();
            }

            public static Polygon2LR.BooleanOperations.Region GetExclusiveOr(
              Polygon2LR.BooleanOperations.Context context,
              Polygon2LR.BooleanOperations.Region region1,
              Polygon2LR.BooleanOperations.Region region2)
            {
                Polygon2LR.BooleanOperations.Region splitRegion1;
                Polygon2LR.BooleanOperations.Region splitRegion2;
                List<Polygon2LR.BooleanOperations.Segment> segments;
                Polygon2LR.BooleanOperations.smethod_6(context, region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                Polygon2LR.BooleanOperations.smethod_3(segments);
                return Polygon2LR.BooleanOperations.smethod_4(splitRegion1, splitRegion2, segments);
            }

            private static void smethod_3(
              List<Polygon2LR.BooleanOperations.Segment> segments)
            {
                foreach (Polygon2LR.BooleanOperations.Segment segment in segments)
                {
                    if (segment.Status == Polygon2LR.BooleanOperations.SegmentStatus.Inside)
                        segment.Reverse();
                }
            }

            private static Polygon2LR.BooleanOperations.Region smethod_4(
              Polygon2LR.BooleanOperations.Region region1,
              Polygon2LR.BooleanOperations.Region region2,
              List<Polygon2LR.BooleanOperations.Segment> segments)
            {
                Polygon2LR.BooleanOperations.Region resultRegion = new Polygon2LR.BooleanOperations.Region(false);
                int count = segments.Count;
                foreach (Polygon2LR.BooleanOperations.Segment segment in segments)
                {
                    if (!segment.Processed)
                        Polygon2LR.BooleanOperations.smethod_9(region1, region2, segments, segment, resultRegion, (Func<Polygon2LR.BooleanOperations.Segment, bool>)(s =>
                       {
                           if (s.Status != Polygon2LR.BooleanOperations.SegmentStatus.Outside)
                               return s.Status == Polygon2LR.BooleanOperations.SegmentStatus.Inside;
                           return true;
                       }), ref count);
                }
                return resultRegion;
            }

            private static void smethod_5(
              IList<Polygon2LR> region1,
              bool reverseRegion1,
              IList<Polygon2LR> region2,
              bool reverseRegion2,
              out Polygon2LR.BooleanOperations.Region splitRegion1,
              out Polygon2LR.BooleanOperations.Region splitRegion2,
              out List<Polygon2LR.BooleanOperations.Segment> segments)
            {
                Polygon2LR.BooleanOperations.Context context = new Polygon2LR.BooleanOperations.Context();
                Polygon2LR.BooleanOperations.Region region3 = Polygon2LR.BooleanOperations.GetRegion(region1, context, reverseRegion1);
                Polygon2LR.BooleanOperations.Region region4 = Polygon2LR.BooleanOperations.GetRegion(region2, context, reverseRegion2);
                Polygon2LR.BooleanOperations.smethod_7(context, region3, region4, out splitRegion1, out splitRegion2, out segments);
            }

            private static void smethod_6(
              Polygon2LR.BooleanOperations.Context context,
              Polygon2LR.BooleanOperations.Region region1,
              bool reverseRegion1,
              Polygon2LR.BooleanOperations.Region region2,
              bool reverseRegion2,
              out Polygon2LR.BooleanOperations.Region splitRegion1,
              out Polygon2LR.BooleanOperations.Region splitRegion2,
              out List<Polygon2LR.BooleanOperations.Segment> segments)
            {
                Polygon2LR.BooleanOperations.Region tmpRegion1 = Polygon2LR.BooleanOperations.smethod_11(region1, reverseRegion1);
                Polygon2LR.BooleanOperations.Region tmpRegion2 = Polygon2LR.BooleanOperations.smethod_11(region2, reverseRegion2);
                Polygon2LR.BooleanOperations.smethod_7(context, tmpRegion1, tmpRegion2, out splitRegion1, out splitRegion2, out segments);
            }

            private static void smethod_7(
              Polygon2LR.BooleanOperations.Context context,
              Polygon2LR.BooleanOperations.Region tmpRegion1,
              Polygon2LR.BooleanOperations.Region tmpRegion2,
              out Polygon2LR.BooleanOperations.Region splitRegion1,
              out Polygon2LR.BooleanOperations.Region splitRegion2,
              out List<Polygon2LR.BooleanOperations.Segment> segments)
            {
                new Polygon2LR.BooleanOperations.Class56(new Polygon2LR.BooleanOperations.Class24()
        {
          tmpRegion1,
          tmpRegion2
        }, context).method_0(true);
                context.method_1();
                splitRegion1 = Polygon2LR.BooleanOperations.smethod_10(tmpRegion1);
                splitRegion2 = Polygon2LR.BooleanOperations.smethod_10(tmpRegion2);
                segments = new List<Polygon2LR.BooleanOperations.Segment>();
                splitRegion1.GetSegments((IList<Polygon2LR.BooleanOperations.Segment>)segments);
                splitRegion2.GetSegments((IList<Polygon2LR.BooleanOperations.Segment>)segments);
                splitRegion1.CalculateSegmentStatus(splitRegion2);
                splitRegion2.CalculateSegmentStatus(splitRegion1);
            }

            private static void smethod_8(Polygon2LR.BooleanOperations.Region region)
            {
                foreach (List<Polygon2LR.BooleanOperations.Segment> segmentList in (List<Polygon2LR.BooleanOperations.Polygon>)region)
                {
                    foreach (Polygon2LR.BooleanOperations.Segment segment in segmentList)
                    {
                        bool flag = false;
                        foreach (Polygon2LR.BooleanOperations.Vertex vertex in segment.Start.Vertices)
                        {
                            if (vertex.InSegment != segment && vertex.InSegment.Status != Polygon2LR.BooleanOperations.SegmentStatus.SelfOverlap && vertex.InSegment.Start == segment.End)
                            {
                                segment.Status = Polygon2LR.BooleanOperations.SegmentStatus.SelfOverlap;
                                vertex.InSegment.Status = Polygon2LR.BooleanOperations.SegmentStatus.SelfOverlap;
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                            break;
                    }
                }
                foreach (Polygon2LR.BooleanOperations.Polygon polygon in (List<Polygon2LR.BooleanOperations.Polygon>)region)
                {
                    for (int index = polygon.Count - 1; index >= 0; --index)
                    {
                        if (polygon[index].Status == Polygon2LR.BooleanOperations.SegmentStatus.SelfOverlap)
                            polygon.RemoveAt(index);
                    }
                }
            }

            private static void smethod_9(
              Polygon2LR.BooleanOperations.Region region1,
              Polygon2LR.BooleanOperations.Region region2,
              List<Polygon2LR.BooleanOperations.Segment> segments,
              Polygon2LR.BooleanOperations.Segment startSegment,
              Polygon2LR.BooleanOperations.Region resultRegion,
              Func<Polygon2LR.BooleanOperations.Segment, bool> includeSegment,
              ref int n)
            {
                Polygon2LR.BooleanOperations.Segment segment1 = startSegment;
                Polygon2LR.BooleanOperations.Polygon polygon = (Polygon2LR.BooleanOperations.Polygon)null;
                Polygon2LR.BooleanOperations.Segment segment2 = (Polygon2LR.BooleanOperations.Segment)null;
                while (n > 0)
                {
                    segment1.Processed = true;
                    --n;
                    if (!includeSegment(segment1))
                        break;
                    if (segment2 == null)
                    {
                        segment2 = segment1;
                        polygon = new Polygon2LR.BooleanOperations.Polygon(resultRegion);
                        resultRegion.Add(polygon);
                    }
                    segment1.Polygon = polygon;
                    polygon.Add(segment1);
                    if (segment1.End == segment2.Start)
                        break;
                    segment1 = segment1.End.GetNextUnprocessedSegment(segment1, includeSegment);
                }
            }

            private static Polygon2LR.BooleanOperations.Region smethod_10(
              Polygon2LR.BooleanOperations.Region region)
            {
                Polygon2LR.BooleanOperations.Region region1 = new Polygon2LR.BooleanOperations.Region(region.Reversed);
                foreach (Polygon2LR.BooleanOperations.Polygon polygon in (List<Polygon2LR.BooleanOperations.Polygon>)region)
                {
                    Polygon2LR.BooleanOperations.Polygon splitPolygon = new Polygon2LR.BooleanOperations.Polygon(region1);
                    region1.Add(splitPolygon);
                    foreach (Polygon2LR.BooleanOperations.Segment segment in (List<Polygon2LR.BooleanOperations.Segment>)polygon)
                        segment.AddSegments(splitPolygon);
                    Polygon2LR.BooleanOperations.Segment inSegment = splitPolygon[splitPolygon.Count - 1];
                    foreach (Polygon2LR.BooleanOperations.Segment outSegment in (List<Polygon2LR.BooleanOperations.Segment>)splitPolygon)
                    {
                        outSegment.Start.AddVertexSorted(new Polygon2LR.BooleanOperations.Vertex(inSegment, outSegment));
                        inSegment = outSegment;
                    }
                }
                return region1;
            }

            public static Polygon2LR.BooleanOperations.Region GetRegion(
              IList<Polygon2LR> input,
              Polygon2LR.BooleanOperations.Context context)
            {
                return Polygon2LR.BooleanOperations.GetRegion(input, context, false);
            }

            public static Polygon2LR.BooleanOperations.Region GetRegion(
              IList<Polygon2LR> input,
              Polygon2LR.BooleanOperations.Context context,
              bool reverse)
            {
                Polygon2LR.BooleanOperations.Region region = new Polygon2LR.BooleanOperations.Region(reverse);
                foreach (Polygon2LR inputPolygon in (IEnumerable<Polygon2LR>)input)
                {
                    if (inputPolygon.Count > 0)
                    {
                        Polygon2LR.BooleanOperations.Polygon polygon = new Polygon2LR.BooleanOperations.Polygon(region);
                        region.Add(polygon);
                        if (reverse)
                            Polygon2LR.BooleanOperations.smethod_13(inputPolygon, polygon, context);
                        else
                            Polygon2LR.BooleanOperations.smethod_12(inputPolygon, polygon, context);
                    }
                }
                return region;
            }

            private static Polygon2LR.BooleanOperations.Region smethod_11(
              Polygon2LR.BooleanOperations.Region input,
              bool reverse)
            {
                Polygon2LR.BooleanOperations.Region region = input;
                if (reverse)
                    region = input.GetReverse();
                region.method_0();
                return region;
            }

            private static void smethod_12(
              Polygon2LR inputPolygon,
              Polygon2LR.BooleanOperations.Polygon polygon,
              Polygon2LR.BooleanOperations.Context positionToPoint)
            {
                Point2LR p1 = inputPolygon[inputPolygon.Count - 1];
                Polygon2LR.BooleanOperations.Point start = positionToPoint.method_0(p1);
                for (int index = 0; index < inputPolygon.Count; ++index)
                {
                    Point2LR p2 = inputPolygon[index];
                    Polygon2LR.BooleanOperations.Point end = positionToPoint.method_0(p2);
                    if (start.Position != end.Position)
                    {
                        Polygon2LR.BooleanOperations.Segment segment = (Polygon2LR.BooleanOperations.Segment)new Polygon2LR.BooleanOperations.SegmentWithIntersections(polygon, new Segment2LR(start.Position, end.Position), start, end);
                        polygon.Add(segment);
                    }
                    start = end;
                }
            }

            private static void smethod_13(
              Polygon2LR inputPolygon,
              Polygon2LR.BooleanOperations.Polygon polygon,
              Polygon2LR.BooleanOperations.Context positionToPoint)
            {
                Point2LR p1 = inputPolygon[0];
                Polygon2LR.BooleanOperations.Point start = positionToPoint.method_0(p1);
                for (int index = inputPolygon.Count - 1; index >= 0; --index)
                {
                    Point2LR p2 = inputPolygon[index];
                    Polygon2LR.BooleanOperations.Point end = positionToPoint.method_0(p2);
                    if (start.Position != end.Position)
                    {
                        Polygon2LR.BooleanOperations.Segment segment = (Polygon2LR.BooleanOperations.Segment)new Polygon2LR.BooleanOperations.SegmentWithIntersections(polygon, new Segment2LR(start.Position, end.Position), start, end);
                        polygon.Add(segment);
                    }
                    start = end;
                }
            }

            [Serializable]
            public class Point
            {
                private List<Polygon2LR.BooleanOperations.Vertex> vertices = new List<Polygon2LR.BooleanOperations.Vertex>();
                private Point2LR position;

                public Point()
                {
                }

                public Point(Point2LR position)
                {
                    this.position = position;
                }

                public Point2LR Position
                {
                    get
                    {
                        return this.position;
                    }
                }

                public List<Polygon2LR.BooleanOperations.Vertex> Vertices
                {
                    get
                    {
                        return this.vertices;
                    }
                }

                public void AddVertexSorted(Polygon2LR.BooleanOperations.Vertex vertex)
                {
                    int index = this.vertices.BinarySearch(vertex, (IComparer<Polygon2LR.BooleanOperations.Vertex>)Polygon2LR.BooleanOperations.Vertex.OutSegmentDirectionComparer.Instance);
                    if (index < 0)
                        this.vertices.Insert(~index, vertex);
                    else
                        this.vertices.Insert(index, vertex);
                }

                public void RemoveVerticesWithInSegment(Polygon2LR.BooleanOperations.Segment inSegment)
                {
                    for (int index = this.vertices.Count - 1; index >= 0; --index)
                    {
                        if (this.vertices[index].InSegment == inSegment)
                            this.vertices.RemoveAt(index);
                    }
                }

                public void RemoveVerticesWithOutSegment(Polygon2LR.BooleanOperations.Segment outSegment)
                {
                    for (int index = this.vertices.Count - 1; index >= 0; --index)
                    {
                        if (this.vertices[index].OutSegment == outSegment)
                            this.vertices.RemoveAt(index);
                    }
                }

                public Polygon2LR.BooleanOperations.Segment GetNextUnprocessedSegment(
                  Polygon2LR.BooleanOperations.Segment segment,
                  Func<Polygon2LR.BooleanOperations.Segment, bool> includeSegment)
                {
                    Vector2LR b = -segment.Direction;
                    Polygon2LR.BooleanOperations.Segment segment1 = (Polygon2LR.BooleanOperations.Segment)null;
                    for (int index = this.vertices.Count - 1; index >= 0; --index)
                    {
                        Polygon2LR.BooleanOperations.Vertex vertex = this.vertices[index];
                        if (!vertex.OutSegment.Processed && Vector2LR.CompareAngles(vertex.OutSegment.Direction, b) < 0 && includeSegment(vertex.OutSegment))
                        {
                            segment1 = vertex.OutSegment;
                            break;
                        }
                    }
                    if (segment1 == null)
                    {
                        for (int index = this.vertices.Count - 1; index >= 0; --index)
                        {
                            Polygon2LR.BooleanOperations.Vertex vertex = this.vertices[index];
                            if (!vertex.OutSegment.Processed && includeSegment(vertex.OutSegment))
                            {
                                segment1 = vertex.OutSegment;
                                break;
                            }
                        }
                        if (segment1 == null)
                            throw new Exception("Could not find connecting segment.");
                    }
                    return segment1;
                }

                public Polygon2LR.BooleanOperations.Segment GetNextUnprocessedSegmentBiDirectional(
                  Polygon2LR.BooleanOperations.Segment segment,
                  Polygon2LR.BooleanOperations.Segment segmentSource,
                  Func<Polygon2LR.BooleanOperations.Segment, bool> includeSegment,
                  out Polygon2LR.BooleanOperations.Segment resultSource)
                {
                    Vector2LR b1 = -segment.Direction;
                    resultSource = (Polygon2LR.BooleanOperations.Segment)null;
                    Polygon2LR.BooleanOperations.Segment segment1 = (Polygon2LR.BooleanOperations.Segment)null;
                    Vector2LR b2 = Vector2LR.Zero;
                    for (int index = this.vertices.Count - 1; index >= 0; --index)
                    {
                        Polygon2LR.BooleanOperations.Vertex vertex = this.vertices[index];
                        if (!vertex.OutSegment.Processed && vertex.OutSegment != segmentSource && (Vector2LR.CompareAngles(vertex.OutSegment.Direction, b1) < 0 && includeSegment(vertex.OutSegment)) && (segment1 == null || Vector2LR.CompareAngles(vertex.OutSegment.Direction, b2) > 0))
                        {
                            resultSource = vertex.OutSegment;
                            segment1 = vertex.OutSegment;
                            b2 = vertex.OutSegment.Direction;
                        }
                        if (!vertex.InSegment.Processed && vertex.InSegment != segmentSource && (Vector2LR.CompareAngles(-vertex.InSegment.Direction, b1) < 0 && includeSegment(vertex.InSegment)) && (segment1 == null || Vector2LR.CompareAngles(-vertex.InSegment.Direction, b2) > 0))
                        {
                            resultSource = vertex.InSegment;
                            segment1 = vertex.InSegment.vmethod_1(segmentSource.Polygon);
                            b2 = -vertex.InSegment.Direction;
                        }
                    }
                    if (segment1 == null)
                    {
                        for (int index = this.vertices.Count - 1; index >= 0; --index)
                        {
                            Polygon2LR.BooleanOperations.Vertex vertex = this.vertices[index];
                            if (!vertex.OutSegment.Processed && vertex.OutSegment != segmentSource && includeSegment(vertex.OutSegment) && (segment1 == null || Vector2LR.CompareAngles(vertex.OutSegment.Direction, b2) > 0))
                            {
                                resultSource = vertex.OutSegment;
                                segment1 = vertex.OutSegment;
                                b2 = vertex.OutSegment.Direction;
                            }
                            if (!vertex.InSegment.Processed && vertex.InSegment != segmentSource && includeSegment(vertex.InSegment) && (segment1 == null || Vector2LR.CompareAngles(-vertex.InSegment.Direction, b2) > 0))
                            {
                                resultSource = vertex.InSegment;
                                segment1 = vertex.InSegment.vmethod_1(segmentSource.Polygon);
                                b2 = -vertex.InSegment.Direction;
                            }
                        }
                    }
                    if (segment1 == null)
                    {
                        for (int index = this.vertices.Count - 1; index >= 0; --index)
                        {
                            Polygon2LR.BooleanOperations.Vertex vertex = this.vertices[index];
                            Vector2LR vector2Lr;
                            if (!vertex.OutSegment.Processed && vertex.OutSegment != segmentSource && (vertex.OutSegment.method_5(segmentSource) && includeSegment(vertex.OutSegment)) && segment1 == null)
                            {
                                resultSource = vertex.OutSegment;
                                segment1 = vertex.OutSegment;
                                vector2Lr = vertex.OutSegment.Direction;
                            }
                            if (!vertex.InSegment.Processed && vertex.InSegment != segmentSource && (vertex.InSegment.method_5(segmentSource) && includeSegment(vertex.InSegment)) && segment1 == null)
                            {
                                resultSource = vertex.InSegment;
                                segment1 = vertex.InSegment.vmethod_1(segmentSource.Polygon);
                                vector2Lr = -vertex.InSegment.Direction;
                            }
                        }
                    }
                    if (resultSource != null)
                        resultSource.Processed = true;
                    return segment1;
                }

                public override string ToString()
                {
                    return string.Format("Position: {0}, vertices: {1}", (object)this.position, (object)this.vertices.Count);
                }
            }

            [Serializable]
            public class Vertex
            {
                private Polygon2LR.BooleanOperations.Segment inSegment;
                private Polygon2LR.BooleanOperations.Segment outSegment;

                public Vertex(
                  Polygon2LR.BooleanOperations.Segment inSegment,
                  Polygon2LR.BooleanOperations.Segment outSegment)
                {
                    if (inSegment != null && inSegment.End.Position != outSegment.Start.Position)
                        throw new ArgumentException();
                    this.inSegment = inSegment;
                    this.outSegment = outSegment;
                }

                public Polygon2LR.BooleanOperations.Segment InSegment
                {
                    get
                    {
                        return this.inSegment;
                    }
                    set
                    {
                        this.inSegment = value;
                    }
                }

                public Polygon2LR.BooleanOperations.Segment OutSegment
                {
                    get
                    {
                        return this.outSegment;
                    }
                    set
                    {
                        this.outSegment = value;
                    }
                }

                public Polygon2LR.BooleanOperations.Point Point
                {
                    get
                    {
                        return this.inSegment.End;
                    }
                }

                public Polygon2LR.BooleanOperations.Region Region
                {
                    get
                    {
                        return this.inSegment.Region;
                    }
                }

                public bool IsInside(Polygon2LR.BooleanOperations.Segment segment)
                {
                    if (segment.Start != this.inSegment.End)
                        throw new ArgumentException();
                    Vector2LR vector2Lr = -this.inSegment.Direction;
                    Vector2LR direction1 = this.outSegment.Direction;
                    Vector2LR direction2 = segment.Direction;
                    int num1 = Vector2LR.CompareAngles(vector2Lr, direction1);
                    int num2 = Vector2LR.CompareAngles(direction2, vector2Lr);
                    int num3 = Vector2LR.CompareAngles(direction2, direction1);
                    return num1 < 0 ? num2 <= 0 || num3 >= 0 : num2 <= 0 && num3 >= 0;
                }

                public override string ToString()
                {
                    return string.Format("Position: {0}, vertices: {1}", (object)this.Point.Position, (object)this.Point.Vertices.Count);
                }

                public class OutSegmentDirectionComparer : IComparer<Polygon2LR.BooleanOperations.Vertex>
                {
                    public static readonly Polygon2LR.BooleanOperations.Vertex.OutSegmentDirectionComparer Instance = new Polygon2LR.BooleanOperations.Vertex.OutSegmentDirectionComparer();

                    private OutSegmentDirectionComparer()
                    {
                    }

                    public int Compare(
                      Polygon2LR.BooleanOperations.Vertex x,
                      Polygon2LR.BooleanOperations.Vertex y)
                    {
                        return Vector2LR.CompareAngles(x.outSegment.Direction, y.outSegment.Direction);
                    }
                }
            }

            [Serializable]
            public class Segment
            {
                private Polygon2LR.BooleanOperations.Polygon polygon;
                private Segment2LR unsplitSegment;
                private Polygon2LR.BooleanOperations.Point start;
                private Polygon2LR.BooleanOperations.Point end;
                private Polygon2LR.BooleanOperations.SegmentStatus status;
                private bool processed;
                private Vector2LR direction;

                public Segment()
                {
                }

                public Segment(
                  Polygon2LR.BooleanOperations.Polygon polygon,
                  Segment2LR unsplitSegment,
                  Polygon2LR.BooleanOperations.Point start,
                  Polygon2LR.BooleanOperations.Point end)
                {
                    if (start.Position == end.Position)
                        throw new ArgumentException("Start and end point may not be the same.");
                    this.polygon = polygon;
                    this.unsplitSegment = unsplitSegment;
                    this.start = start;
                    this.end = end;
                    this.direction = unsplitSegment.End - unsplitSegment.Start;
                }

                public Polygon2LR.BooleanOperations.Polygon Polygon
                {
                    get
                    {
                        return this.polygon;
                    }
                    set
                    {
                        this.polygon = value;
                    }
                }

                public Segment2LR UnsplitSegment
                {
                    get
                    {
                        return this.unsplitSegment;
                    }
                }

                public Polygon2LR.BooleanOperations.Point Start
                {
                    get
                    {
                        return this.start;
                    }
                    set
                    {
                        this.start = value;
                    }
                }

                public Polygon2LR.BooleanOperations.Point End
                {
                    get
                    {
                        return this.end;
                    }
                    set
                    {
                        this.end = value;
                    }
                }

                internal Polygon2LR.BooleanOperations.SegmentStatus Status
                {
                    get
                    {
                        return this.status;
                    }
                    set
                    {
                        this.status = value;
                    }
                }

                public bool Processed
                {
                    get
                    {
                        return this.processed;
                    }
                    set
                    {
                        this.processed = value;
                    }
                }

                public Vector2LR Direction
                {
                    get
                    {
                        return this.direction;
                    }
                    internal set
                    {
                        this.direction = value;
                    }
                }

                public Polygon2LR.BooleanOperations.Region Region
                {
                    get
                    {
                        return this.polygon.Region;
                    }
                }

                public virtual void AddIntersection(
                  Polygon2LR.BooleanOperations.Intersection intersection)
                {
                    throw new NotImplementedException();
                }

                public virtual void AddSegments(Polygon2LR.BooleanOperations.Polygon splitPolygon)
                {
                    throw new NotImplementedException();
                }

                public virtual void AddSegmentsReversed(Polygon2LR.BooleanOperations.Polygon splitPolygon)
                {
                    throw new NotImplementedException();
                }

                public void CalculateStatusFirstSegment(Polygon2LR.BooleanOperations.Region otherRegion)
                {
                    if (this.status != Polygon2LR.BooleanOperations.SegmentStatus.Unknown)
                        return;
                    this.method_1(otherRegion);
                    if (this.status != Polygon2LR.BooleanOperations.SegmentStatus.Unknown)
                        return;
                    if (this.method_0(otherRegion) == 0)
                    {
                        if (otherRegion.IsInside(this.start.Position))
                            this.status = Polygon2LR.BooleanOperations.SegmentStatus.Inside;
                        else
                            this.status = Polygon2LR.BooleanOperations.SegmentStatus.Outside;
                    }
                    else
                        this.method_2(otherRegion);
                }

                private int method_0(Polygon2LR.BooleanOperations.Region region)
                {
                    int num = 0;
                    foreach (Polygon2LR.BooleanOperations.Vertex vertex in this.start.Vertices)
                    {
                        if (vertex.Region == region)
                            ++num;
                    }
                    return num;
                }

                public void CalculateStatus(
                  Polygon2LR.BooleanOperations.Segment previousSegment,
                  Polygon2LR.BooleanOperations.Region otherRegion)
                {
                    if (this.status != Polygon2LR.BooleanOperations.SegmentStatus.Unknown)
                        return;
                    if (this.method_0(otherRegion) == 0)
                    {
                        this.status = previousSegment.status;
                    }
                    else
                    {
                        this.method_1(otherRegion);
                        if (this.status != Polygon2LR.BooleanOperations.SegmentStatus.Unknown)
                            return;
                        this.method_2(otherRegion);
                    }
                }

                private void method_1(Polygon2LR.BooleanOperations.Region otherRegion)
                {
                    foreach (Polygon2LR.BooleanOperations.Vertex vertex in this.start.Vertices)
                    {
                        if (vertex.Region == otherRegion)
                        {
                            if (vertex.InSegment.start != this.end)
                            {
                                if (vertex.OutSegment.end == this.end)
                                {
                                    this.status = Polygon2LR.BooleanOperations.SegmentStatus.Shared;
                                    break;
                                }
                            }
                            else
                            {
                                this.status = Polygon2LR.BooleanOperations.SegmentStatus.SharedOpposite;
                                break;
                            }
                        }
                    }
                }

                private void method_2(Polygon2LR.BooleanOperations.Region otherRegion)
                {
                    this.status = Polygon2LR.BooleanOperations.SegmentStatus.Outside;
                    foreach (Polygon2LR.BooleanOperations.Vertex vertex in this.start.Vertices)
                    {
                        if (vertex.Region == otherRegion && vertex.IsInside(this))
                        {
                            this.status = Polygon2LR.BooleanOperations.SegmentStatus.Inside;
                            break;
                        }
                    }
                }

                public void Reverse()
                {
                    this.start.RemoveVerticesWithOutSegment(this);
                    Polygon2LR.BooleanOperations.Point start = this.start;
                    this.start = this.end;
                    this.end = start;
                    this.unsplitSegment = new Segment2LR(this.unsplitSegment.End, this.unsplitSegment.Start);
                    this.direction = -this.direction;
                    this.start.AddVertexSorted(new Polygon2LR.BooleanOperations.Vertex((Polygon2LR.BooleanOperations.Segment)null, this));
                }

                public Segment2LR ToSegment2LR()
                {
                    return new Segment2LR(this.start.Position, this.end.Position);
                }

                public override string ToString()
                {
                    return string.Format("Start: {0}, End: {1}, Status: {2}", (object)this.start, (object)this.end, (object)this.status);
                }

                internal virtual Polygon2LR.BooleanOperations.Segment vmethod_0(
                  Polygon2LR.BooleanOperations.Polygon result)
                {
                    return new Polygon2LR.BooleanOperations.Segment(result, this.unsplitSegment, this.start, this.end);
                }

                internal virtual Polygon2LR.BooleanOperations.Segment vmethod_1(
                  Polygon2LR.BooleanOperations.Polygon result)
                {
                    return new Polygon2LR.BooleanOperations.Segment(result, new Segment2LR(this.unsplitSegment.End, this.unsplitSegment.Start), this.end, this.start);
                }

                internal bool method_3(Point2LR position)
                {
                    if ((!(position.X >= this.Start.Position.X) || !(position.X <= this.End.Position.X)) && (!(position.X >= this.End.Position.X) || !(position.X <= this.Start.Position.X)))
                        return false;
                    if (position.Y >= this.Start.Position.Y && position.Y <= this.End.Position.Y)
                        return true;
                    if (position.Y >= this.End.Position.Y)
                        return position.Y <= this.Start.Position.Y;
                    return false;
                }

                internal bool method_4(Polygon2LR.BooleanOperations.Segment otherSegment)
                {
                    if (this.start != otherSegment.start && this.start != otherSegment.end && this.end != otherSegment.start)
                        return this.end == otherSegment.end;
                    return true;
                }

                internal bool method_5(Polygon2LR.BooleanOperations.Segment other)
                {
                    if (this.start == other.start && this.end == other.end)
                        return true;
                    if (this.start == other.end)
                        return this.end == other.start;
                    return false;
                }
            }

            private class Class24 : RedBlackTree<Polygon2LR.BooleanOperations.Class54>
            {
                public void Add(Polygon2LR.BooleanOperations.Region region)
                {
                    Polygon2LR.BooleanOperations.Class54.Class55 class55 = new Polygon2LR.BooleanOperations.Class54.Class55();
                    foreach (List<Polygon2LR.BooleanOperations.Segment> segmentList in (List<Polygon2LR.BooleanOperations.Polygon>)region)
                    {
                        foreach (Polygon2LR.BooleanOperations.Segment segment in segmentList)
                        {
                            Point2LR position1 = segment.Start.Position;
                            Point2LR position2 = segment.End.Position;
                            if (position1.X > position2.X || position1.X == position2.X && position1.Y > position2.Y)
                                MathUtil.Swap<Point2LR>(ref position1, ref position2);
                            class55.Position = position1;
                            Polygon2LR.BooleanOperations.Class54 class54_1 = this.Find((IComparable<Polygon2LR.BooleanOperations.Class54>)class55);
                            if (class54_1 == null)
                            {
                                class54_1 = new Polygon2LR.BooleanOperations.Class54(position1);
                                this.Add(class54_1);
                            }
                            class54_1.EntrySegmentsNotNull.Add(segment);
                            class55.Position = position2;
                            Polygon2LR.BooleanOperations.Class54 class54_2 = this.Find((IComparable<Polygon2LR.BooleanOperations.Class54>)class55);
                            if (class54_2 == null)
                            {
                                class54_2 = new Polygon2LR.BooleanOperations.Class54(position2);
                                this.Add(class54_2);
                            }
                            class54_2.ExitSegmentsNotNull.Add(segment);
                        }
                    }
                }
            }

            private class Class54 : IComparable<Polygon2LR.BooleanOperations.Class54>
            {
                private Point2LR point2LR_0;
                private List<Polygon2LR.BooleanOperations.Segment> list_0;
                private List<Polygon2LR.BooleanOperations.Segment> list_1;

                public Class54(Point2LR position)
                {
                    this.point2LR_0 = position;
                }

                public Point2LR Position
                {
                    get
                    {
                        return this.point2LR_0;
                    }
                    set
                    {
                        this.point2LR_0 = value;
                    }
                }

                public List<Polygon2LR.BooleanOperations.Segment> EntrySegments
                {
                    get
                    {
                        return this.list_0;
                    }
                }

                public List<Polygon2LR.BooleanOperations.Segment> ExitSegments
                {
                    get
                    {
                        return this.list_1;
                    }
                }

                public List<Polygon2LR.BooleanOperations.Segment> EntrySegmentsNotNull
                {
                    get
                    {
                        if (this.list_0 == null)
                            this.list_0 = new List<Polygon2LR.BooleanOperations.Segment>();
                        return this.list_0;
                    }
                }

                public List<Polygon2LR.BooleanOperations.Segment> ExitSegmentsNotNull
                {
                    get
                    {
                        if (this.list_1 == null)
                            this.list_1 = new List<Polygon2LR.BooleanOperations.Segment>();
                        return this.list_1;
                    }
                }

                public override string ToString()
                {
                    return this.point2LR_0.ToString();
                }

                public int CompareTo(Polygon2LR.BooleanOperations.Class54 other)
                {
                    if (this.point2LR_0.X < other.point2LR_0.X)
                        return -1;
                    if (this.point2LR_0.X > other.point2LR_0.X)
                        return 1;
                    if (this.point2LR_0.Y < other.point2LR_0.Y)
                        return -1;
                    return this.point2LR_0.Y > other.point2LR_0.Y ? 1 : 0;
                }

                public class Class55 : IComparable<Polygon2LR.BooleanOperations.Class54>
                {
                    private Point2LR point2LR_0;

                    public Point2LR Position
                    {
                        get
                        {
                            return this.point2LR_0;
                        }
                        set
                        {
                            this.point2LR_0 = value;
                        }
                    }

                    public int CompareTo(Polygon2LR.BooleanOperations.Class54 other)
                    {
                        if (this.point2LR_0.X < other.point2LR_0.X)
                            return -1;
                        if (this.point2LR_0.X > other.point2LR_0.X)
                            return 1;
                        if (this.point2LR_0.Y < other.point2LR_0.Y)
                            return -1;
                        return this.point2LR_0.Y > other.point2LR_0.Y ? 1 : 0;
                    }
                }
            }

            private class Class56
            {
                private List<Polygon2LR.BooleanOperations.Segment> list_0 = new List<Polygon2LR.BooleanOperations.Segment>();
                private Polygon2LR.BooleanOperations.Class24 class24_0;
                private RedBlackTree<Polygon2LR.BooleanOperations.Class54>.ForwardEnumerator forwardEnumerator_0;
                private Polygon2LR.BooleanOperations.Context context_0;

                public Class56(
                  Polygon2LR.BooleanOperations.Class24 eventQueue,
                  Polygon2LR.BooleanOperations.Context context)
                {
                    this.class24_0 = eventQueue;
                    this.context_0 = context;
                    this.forwardEnumerator_0 = (RedBlackTree<Polygon2LR.BooleanOperations.Class54>.ForwardEnumerator)eventQueue.GetEnumerator();
                }

                public void method_0(bool ignoreIntraRegionIntersections)
                {
                    while (this.forwardEnumerator_0.MoveNext())
                    {
                        Polygon2LR.BooleanOperations.Class54 current = this.forwardEnumerator_0.Current;
                        if (current.EntrySegments != null)
                        {
                            foreach (Polygon2LR.BooleanOperations.Segment entrySegment in current.EntrySegments)
                            {
                                foreach (Polygon2LR.BooleanOperations.Segment otherSegment in this.list_0)
                                {
                                    if (ignoreIntraRegionIntersections)
                                    {
                                        if (entrySegment.Region == otherSegment.Region)
                                            continue;
                                    }
                                    else if (entrySegment.method_4(otherSegment))
                                        continue;
                                    LongRational[] pArray;
                                    LongRational[] qArray;
                                    if (Segment2LR.GetIntersectionParameters(entrySegment.UnsplitSegment, otherSegment.UnsplitSegment, out pArray, out qArray))
                                    {
                                        for (int index = 0; index < pArray.Length; ++index)
                                        {
                                            LongRational parameter1 = pArray[index];
                                            LongRational parameter2 = qArray[index];
                                            Point2LR point2Lr = entrySegment.UnsplitSegment.Start + parameter1 * (entrySegment.UnsplitSegment.End - entrySegment.UnsplitSegment.Start);
                                            if (entrySegment.method_3(point2Lr) && otherSegment.method_3(point2Lr))
                                            {
                                                Polygon2LR.BooleanOperations.Point point = this.context_0.method_0(point2Lr);
                                                entrySegment.AddIntersection(new Polygon2LR.BooleanOperations.Intersection(parameter1, point));
                                                otherSegment.AddIntersection(new Polygon2LR.BooleanOperations.Intersection(parameter2, point));
                                            }
                                        }
                                    }
                                }
                                this.list_0.Add(entrySegment);
                            }
                        }
                        if (current.ExitSegments != null)
                        {
                            foreach (Polygon2LR.BooleanOperations.Segment exitSegment in current.ExitSegments)
                                this.list_0.Remove(exitSegment);
                        }
                    }
                }
            }

            internal enum SegmentStatus : byte
            {
                Unknown,
                Inside,
                Outside,
                Shared,
                SharedOpposite,
                SelfOverlap,
            }

            [Serializable]
            private class SegmentWithIntersections : Polygon2LR.BooleanOperations.Segment
            {
                private SortedList<Polygon2LR.BooleanOperations.Intersection> intersections = new SortedList<Polygon2LR.BooleanOperations.Intersection>();

                public SegmentWithIntersections()
                {
                }

                public SegmentWithIntersections(
                  Polygon2LR.BooleanOperations.Polygon polygon,
                  Segment2LR unsplitSegment,
                  Polygon2LR.BooleanOperations.Point start,
                  Polygon2LR.BooleanOperations.Point end)
                  : base(polygon, unsplitSegment, start, end)
                {
                }

                public override void AddIntersection(
                  Polygon2LR.BooleanOperations.Intersection intersection)
                {
                    if (intersection.Point == this.Start || intersection.Point == this.End)
                        return;
                    Polygon2LR.BooleanOperations.Intersection intersection1 = (Polygon2LR.BooleanOperations.Intersection)null;
                    for (int index = 0; index < this.intersections.Count; ++index)
                    {
                        Polygon2LR.BooleanOperations.Intersection intersection2 = this.intersections[index];
                        if (intersection2.Parameter == intersection.Parameter || intersection2.Point == intersection.Point)
                        {
                            intersection1 = intersection2;
                            break;
                        }
                    }
                    if (intersection1 != null)
                        return;
                    this.intersections.Add(intersection);
                }

                public override void AddSegments(Polygon2LR.BooleanOperations.Polygon splitPolygon)
                {
                    if (this.intersections.Count == 0)
                    {
                        this.method_6(splitPolygon, this.Start, this.End);
                    }
                    else
                    {
                        Polygon2LR.BooleanOperations.Point p0 = this.Start;
                        foreach (Polygon2LR.BooleanOperations.Intersection intersection in this.intersections)
                        {
                            Polygon2LR.BooleanOperations.Point point = intersection.Point;
                            this.method_6(splitPolygon, p0, point);
                            p0 = point;
                        }
                        this.method_6(splitPolygon, p0, this.End);
                    }
                }

                private void method_6(
                  Polygon2LR.BooleanOperations.Polygon splitPolygon,
                  Polygon2LR.BooleanOperations.Point p0,
                  Polygon2LR.BooleanOperations.Point p1)
                {
                    Polygon2LR.BooleanOperations.Segment segment = (Polygon2LR.BooleanOperations.Segment)new Polygon2LR.BooleanOperations.SegmentWithIntersections(splitPolygon, this.UnsplitSegment, p0, p1);
                    splitPolygon.Add(segment);
                }

                internal override Polygon2LR.BooleanOperations.Segment vmethod_0(
                  Polygon2LR.BooleanOperations.Polygon result)
                {
                    return (Polygon2LR.BooleanOperations.Segment)new Polygon2LR.BooleanOperations.SegmentWithIntersections(result, this.UnsplitSegment, this.Start, this.End);
                }

                internal override Polygon2LR.BooleanOperations.Segment vmethod_1(
                  Polygon2LR.BooleanOperations.Polygon result)
                {
                    return (Polygon2LR.BooleanOperations.Segment)new Polygon2LR.BooleanOperations.SegmentWithIntersections(result, new Segment2LR(this.UnsplitSegment.End, this.UnsplitSegment.Start), this.End, this.Start);
                }
            }

            [Serializable]
            public class Intersection : IComparable<Polygon2LR.BooleanOperations.Intersection>
            {
                private LongRational parameter;
                private Polygon2LR.BooleanOperations.Point point;

                public Intersection(LongRational parameter, Polygon2LR.BooleanOperations.Point point)
                {
                    this.parameter = parameter;
                    this.point = point;
                }

                public LongRational Parameter
                {
                    get
                    {
                        return this.parameter;
                    }
                }

                public Polygon2LR.BooleanOperations.Point Point
                {
                    get
                    {
                        return this.point;
                    }
                }

                public override string ToString()
                {
                    return string.Format("Parameter: {0}, position: {1}", (object)this.parameter, (object)this.point);
                }

                public int CompareTo(Polygon2LR.BooleanOperations.Intersection other)
                {
                    if (this.parameter < other.parameter)
                        return -1;
                    return this.parameter > other.parameter ? 1 : 0;
                }
            }

            [Serializable]
            public class Region : List<Polygon2LR.BooleanOperations.Polygon>
            {
                private bool reversed;
                private int insideMinWindingNumber;

                public Region(bool reversed)
                {
                    this.reversed = reversed;
                    if (!reversed)
                        return;
                    this.insideMinWindingNumber = -1;
                }

                public bool Reversed
                {
                    get
                    {
                        return this.reversed;
                    }
                }

                public bool IsInside(Point2LR p)
                {
                    return this.GetWindingNumber(p) > this.insideMinWindingNumber;
                }

                public int GetWindingNumber(Point2LR p)
                {
                    int num = 0;
                    foreach (Polygon2LR.BooleanOperations.Polygon polygon in (List<Polygon2LR.BooleanOperations.Polygon>)this)
                        num += Polygon2LR.BooleanOperations.Polygon.GetWindingNumber(p.X, p.Y, polygon);
                    return num;
                }

                public void CalculateSegmentStatus(Polygon2LR.BooleanOperations.Region otherRegion)
                {
                    foreach (Polygon2LR.BooleanOperations.Polygon polygon in (List<Polygon2LR.BooleanOperations.Polygon>)this)
                        polygon.CalculateSegmentStatus(otherRegion);
                }

                public List<Polygon2LR> ToPolygon2LRList()
                {
                    List<Polygon2LR> polygon2LrList = new List<Polygon2LR>(this.Count);
                    foreach (Polygon2LR.BooleanOperations.Polygon polygon in (List<Polygon2LR.BooleanOperations.Polygon>)this)
                    {
                        Polygon2LR polygon2Lr = new Polygon2LR(polygon.Count);
                        foreach (Polygon2LR.BooleanOperations.Segment segment in (List<Polygon2LR.BooleanOperations.Segment>)polygon)
                            polygon2Lr.Add(segment.Start.Position);
                        polygon2LrList.Add(polygon2Lr);
                    }
                    return polygon2LrList;
                }

                public List<IList<Point2LR>> ToPoint2LRListList()
                {
                    List<IList<Point2LR>> point2LrListList = new List<IList<Point2LR>>(this.Count);
                    foreach (Polygon2LR.BooleanOperations.Polygon polygon in (List<Polygon2LR.BooleanOperations.Polygon>)this)
                    {
                        Polygon2LR polygon2Lr = new Polygon2LR(polygon.Count);
                        foreach (Polygon2LR.BooleanOperations.Segment segment in (List<Polygon2LR.BooleanOperations.Segment>)polygon)
                            polygon2Lr.Add(segment.Start.Position);
                        point2LrListList.Add((IList<Point2LR>)polygon2Lr);
                    }
                    return point2LrListList;
                }

                public void GetSegments(
                  IList<Polygon2LR.BooleanOperations.Segment> segments)
                {
                    foreach (List<Polygon2LR.BooleanOperations.Segment> segmentList in (List<Polygon2LR.BooleanOperations.Polygon>)this)
                    {
                        foreach (Polygon2LR.BooleanOperations.Segment segment in segmentList)
                            segments.Add(segment);
                    }
                }

                public Polygon2LR.BooleanOperations.Region GetReverse()
                {
                    Polygon2LR.BooleanOperations.Region targetRegion = new Polygon2LR.BooleanOperations.Region(!this.reversed);
                    for (int index = this.Count - 1; index >= 0; --index)
                        targetRegion.Add(this[index].GetReversedPolygon(targetRegion));
                    return targetRegion;
                }

                public List<Polygon2LR> ToPolygon2LRListDebug()
                {
                    List<Polygon2LR> polygon2LrList = new List<Polygon2LR>(this.Count);
                    foreach (Polygon2LR.BooleanOperations.Polygon polygon in (List<Polygon2LR.BooleanOperations.Polygon>)this)
                    {
                        Polygon2LR polygon2Lr = polygon.method_0();
                        polygon2LrList.Add(polygon2Lr);
                    }
                    return polygon2LrList;
                }

                public Polygon2LR.BooleanOperations.Region Subdivide(
                  Polygon2LR.BooleanOperations.Context context)
                {
                    new Polygon2LR.BooleanOperations.Class56(new Polygon2LR.BooleanOperations.Class24()
          {
            this
          }, context).method_0(false);
                    context.method_1();
                    Polygon2LR.BooleanOperations.Region region1 = Polygon2LR.BooleanOperations.smethod_10(this);
                    List<Polygon2LR.BooleanOperations.Segment> segmentList1 = new List<Polygon2LR.BooleanOperations.Segment>();
                    foreach (Polygon2LR.BooleanOperations.Polygon polygon in (List<Polygon2LR.BooleanOperations.Polygon>)region1)
                        segmentList1.AddRange((IEnumerable<Polygon2LR.BooleanOperations.Segment>)polygon);
                    foreach (Polygon2LR.BooleanOperations.Segment segment in segmentList1)
                        segment.Status = Polygon2LR.BooleanOperations.SegmentStatus.Unknown;
                    List<Polygon2LR.BooleanOperations.Segment> segmentList2 = new List<Polygon2LR.BooleanOperations.Segment>();
                    foreach (Polygon2LR.BooleanOperations.Segment other in segmentList1)
                    {
                        if (other.Status != Polygon2LR.BooleanOperations.SegmentStatus.Shared && other.End.Vertices.Count > 1)
                        {
                            foreach (Polygon2LR.BooleanOperations.Vertex vertex in other.End.Vertices)
                            {
                                if (vertex.InSegment != other && vertex.InSegment.method_5(other))
                                    segmentList2.Add(vertex.InSegment);
                                if (vertex.OutSegment != other && vertex.OutSegment.method_5(other))
                                    segmentList2.Add(vertex.OutSegment);
                            }
                            if (segmentList2.Count > 0)
                            {
                                if ((segmentList2.Count & 1) != 0)
                                    other.Status = Polygon2LR.BooleanOperations.SegmentStatus.Shared;
                                foreach (Polygon2LR.BooleanOperations.Segment segment in segmentList2)
                                    segment.Status = Polygon2LR.BooleanOperations.SegmentStatus.Shared;
                                segmentList2.Clear();
                            }
                        }
                    }
                    Polygon2LR.BooleanOperations.Region region2 = new Polygon2LR.BooleanOperations.Region(this.reversed);
                    int num1 = segmentList1.Count;
                    foreach (Polygon2LR.BooleanOperations.Segment segment1 in segmentList1)
                    {
                        if (!segment1.Processed && segment1.Status != Polygon2LR.BooleanOperations.SegmentStatus.Shared)
                        {
                            Polygon2LR.BooleanOperations.Polygon result = new Polygon2LR.BooleanOperations.Polygon(region2);
                            List<Polygon2LR.BooleanOperations.Segment> segmentList3 = new List<Polygon2LR.BooleanOperations.Segment>();
                            segment1.Processed = true;
                            result.Add(segment1);
                            --num1;
                            Polygon2LR.BooleanOperations.Segment segment2 = segment1;
                            Polygon2LR.BooleanOperations.Segment resultSource1 = segment1;
                            while (num1 > 0)
                            {
                                segment2 = segment2.End.GetNextUnprocessedSegmentBiDirectional(segment2, resultSource1, (Func<Polygon2LR.BooleanOperations.Segment, bool>)(s => s.Status != Polygon2LR.BooleanOperations.SegmentStatus.Shared), out resultSource1);
                                if (segment2 != null)
                                {
                                    result.Add(segment2);
                                    segmentList3.Add(resultSource1);
                                    --num1;
                                    if (segment2.End == segment1.Start)
                                        break;
                                }
                                else
                                    break;
                            }
                            if (result.IsClockwise())
                            {
                                int num2 = num1 + result.Count;
                                foreach (Polygon2LR.BooleanOperations.Segment segment3 in segmentList3)
                                    segment3.Processed = false;
                                result.Clear();
                                Polygon2LR.BooleanOperations.Segment resultSource2 = segment1;
                                Polygon2LR.BooleanOperations.Segment segment4 = segment1.vmethod_1(result);
                                result.Add(segment4);
                                num1 = num2 - 1;
                                while (num1 > 0)
                                {
                                    segment4 = segment4.End.GetNextUnprocessedSegmentBiDirectional(segment4, resultSource2, (Func<Polygon2LR.BooleanOperations.Segment, bool>)(s => s.Status != Polygon2LR.BooleanOperations.SegmentStatus.Shared), out resultSource2);
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
                        Polygon2LR.BooleanOperations.Polygon polygon = region2[index];
                        if (polygon.Count < 3 || polygon[0].Start != polygon[polygon.Count - 1].End)
                            region2.RemoveAt(index);
                    }
                    return region2;
                }

                internal void method_0()
                {
                    foreach (Polygon2LR.BooleanOperations.Polygon polygon in (List<Polygon2LR.BooleanOperations.Polygon>)this)
                        polygon.method_1();
                }
            }

            [Serializable]
            public class Polygon : List<Polygon2LR.BooleanOperations.Segment>
            {
                private Polygon2LR.BooleanOperations.Region region;

                public Polygon(Polygon2LR.BooleanOperations.Region region)
                {
                    this.region = region;
                }

                public Polygon2LR.BooleanOperations.Region Region
                {
                    get
                    {
                        return this.region;
                    }
                }

                public static int GetWindingNumber(Point2LR p, Polygon2LR.BooleanOperations.Polygon polygon)
                {
                    return Polygon2LR.BooleanOperations.Polygon.GetWindingNumber(p.X, p.Y, polygon);
                }

                public static int GetWindingNumber(
                  LongRational x,
                  LongRational y,
                  Polygon2LR.BooleanOperations.Polygon polygon)
                {
                    int num = 0;
                    int count = polygon.Count;
                    if (count > 0)
                    {
                        Polygon2LR.BooleanOperations.Segment segment = polygon[count - 1];
                        Point2LR point2Lr = segment.Start.Position;
                        for (int index = 0; index < count; ++index)
                        {
                            Segment2LR unsplitSegment = segment.UnsplitSegment;
                            Point2LR position = segment.End.Position;
                            if (point2Lr.Y <= y)
                            {
                                if (position.Y > y && Polygon2LR.smethod_6(unsplitSegment.Start.X, unsplitSegment.Start.Y, unsplitSegment.End.X, unsplitSegment.End.Y, x, y))
                                    ++num;
                            }
                            else if (position.Y <= y && Polygon2LR.smethod_7(unsplitSegment.Start.X, unsplitSegment.Start.Y, unsplitSegment.End.X, unsplitSegment.End.Y, x, y))
                                --num;
                            segment = polygon[index];
                            point2Lr = position;
                        }
                    }
                    return num;
                }

                public void CalculateSegmentStatus(Polygon2LR.BooleanOperations.Region otherRegion)
                {
                    if (this.Count <= 0)
                        return;
                    Polygon2LR.BooleanOperations.Segment previousSegment = this[0];
                    previousSegment.CalculateStatusFirstSegment(otherRegion);
                    for (int index = 1; index < this.Count; ++index)
                    {
                        Polygon2LR.BooleanOperations.Segment segment = this[index];
                        segment.CalculateStatus(previousSegment, otherRegion);
                        previousSegment = segment;
                    }
                }

                public Polygon2LR.BooleanOperations.Polygon GetReversedPolygon(
                  Polygon2LR.BooleanOperations.Region targetRegion)
                {
                    Polygon2LR.BooleanOperations.Polygon result = new Polygon2LR.BooleanOperations.Polygon(targetRegion);
                    for (int index = this.Count - 1; index >= 0; --index)
                        result.Add(this[index].vmethod_1(result));
                    return result;
                }

                public LongRational GetDoubleArea()
                {
                    int count = this.Count;
                    if (count < 3)
                        return LongRational.Zero;
                    LongRational zero = LongRational.Zero;
                    Point2LR point2Lr = this[count - 1].Start.Position;
                    for (int index = 0; index < count; ++index)
                    {
                        Point2LR position = this[index].Start.Position;
                        zero += point2Lr.X * position.Y - position.X * point2Lr.Y;
                        point2Lr = position;
                    }
                    return zero;
                }

                public bool IsClockwise()
                {
                    if (this.Count < 3)
                        return false;
                    int index1 = this.Count - 1;
                    Polygon2LR.BooleanOperations.Segment segment1 = this[index1];
                    int index2 = 0;
                    Polygon2LR.BooleanOperations.Segment segment2 = this[0];
                    Polygon2LR.BooleanOperations.Segment segment3 = segment2;
                    int num1 = 0;
                    for (int index3 = 1; index3 < this.Count; ++index3)
                    {
                        Polygon2LR.BooleanOperations.Segment segment4 = this[index3];
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
                    return Vector2LR.CrossProduct(segment1.UnsplitSegment.GetDelta(), segment2.UnsplitSegment.GetDelta()).IsNegative;
                }

                internal Polygon2LR method_0()
                {
                    Polygon2LR polygon2Lr = new Polygon2LR(this.Count + 1);
                    if (this.Count > 0)
                    {
                        foreach (Polygon2LR.BooleanOperations.Segment segment in (List<Polygon2LR.BooleanOperations.Segment>)this)
                            polygon2Lr.Add(segment.Start.Position);
                        if (this[this.Count - 1].End != this[0].Start)
                            polygon2Lr.Add(this[this.Count - 1].End.Position);
                    }
                    return polygon2Lr;
                }

                internal void method_1()
                {
                    foreach (Polygon2LR.BooleanOperations.Segment segment in (List<Polygon2LR.BooleanOperations.Segment>)this)
                        segment.Status = Polygon2LR.BooleanOperations.SegmentStatus.Unknown;
                }
            }

            public class Context
            {
                private Dictionary<Point2LR, Polygon2LR.BooleanOperations.Point> dictionary_0 = new Dictionary<Point2LR, Polygon2LR.BooleanOperations.Point>();

                internal Polygon2LR.BooleanOperations.Point method_0(Point2LR p)
                {
                    Polygon2LR.BooleanOperations.Point point;
                    if (!this.dictionary_0.TryGetValue(p, out point))
                    {
                        point = new Polygon2LR.BooleanOperations.Point(p);
                        this.dictionary_0.Add(p, point);
                    }
                    return point;
                }

                internal void method_1()
                {
                    foreach (KeyValuePair<Point2LR, Polygon2LR.BooleanOperations.Point> keyValuePair in this.dictionary_0)
                        keyValuePair.Value.Vertices.Clear();
                }
            }

            [Serializable]
            internal class DebugInfo
            {
                private Polygon2LR.BooleanOperations.Region region1;
                private Polygon2LR.BooleanOperations.Region region2;
                private Polygon2LR.BooleanOperations.Region resultRegion;
                private List<Polygon2LR.BooleanOperations.Segment> segments;
                private Polygon2LR.BooleanOperations.Segment highlightSegment;

                public Polygon2LR.BooleanOperations.Region Region1
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

                public Polygon2LR.BooleanOperations.Region Region2
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

                public Polygon2LR.BooleanOperations.Region ResultRegion
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

                public List<Polygon2LR.BooleanOperations.Segment> Segments
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

                public Polygon2LR.BooleanOperations.Segment HighlightSegment
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
