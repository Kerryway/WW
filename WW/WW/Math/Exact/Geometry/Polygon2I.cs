// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.Polygon2I
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using WW.Collections.Generic;
using WW.Math.Geometry;

namespace WW.Math.Exact.Geometry
{
    [Serializable]
    public class Polygon2I : List<Point2I>
    {
        public Polygon2I()
        {
        }

        public Polygon2I(int capacity)
          : base(capacity)
        {
        }

        public Polygon2I(params Point2I[] points)
          : base((IEnumerable<Point2I>)points)
        {
        }

        public Polygon2I(IEnumerable<Point2I> points)
          : base(points)
        {
        }

        public Polygon2I(Polygon2I polyline)
          : base((IEnumerable<Point2I>)polyline)
        {
        }

        public Polygon2I(Matrix4D transform, ICollection<Point2D> points)
          : this(points.Count)
        {
            foreach (Point2D point in (IEnumerable<Point2D>)points)
            {
                Point2D point2D = transform.Transform(point);
                this.Add(new Point2I((int)System.Math.Floor(point2D.X), (int)System.Math.Floor(point2D.Y)));
            }
        }

        public bool IsConvex()
        {
            int count = this.Count;
            if (count <= 3)
                return true;
            long num1 = 0;
            Point2I point2I1 = this[count - 2];
            Point2I point2I2 = this[count - 1];
            Vector2I u = point2I2 - point2I1;
            for (int index = 0; index < count; ++index)
            {
                Point2I point2I3 = this[index];
                Vector2I v = point2I3 - point2I2;
                long num2 = Vector2I.CrossProduct(u, v);
                if (num1 == 0L)
                    num1 = num2;
                else if (num2 != 0L)
                {
                    if (num2 < 0L)
                    {
                        if (num1 < 0L)
                            return false;
                    }
                    else if (num1 > 0L)
                        return false;
                }
                u = v;
                point2I2 = point2I3;
            }
            return true;
        }

        public bool IsInside(Point2I p)
        {
            return (Polygon2I.GetWindingNumber((long)p.X, (long)p.Y, (IList<Point2I>)this) & 1) == 1;
        }

        public bool IsClockwise()
        {
            return Polygon2I.IsClockwise((IList<Point2I>)this);
        }

        public Polygon2I GetReverse()
        {
            Polygon2I polygon2I = new Polygon2I(this.Count);
            for (int index = this.Count - 1; index >= 0; --index)
                polygon2I.Add(this[index]);
            return polygon2I;
        }

        public static Polygon2I Create(IList<Point2D> polygon, Matrix3D transform)
        {
            Polygon2I polygon2I = new Polygon2I(polygon.Count);
            for (int index = 0; index < polygon.Count; ++index)
                polygon2I.Add(new Point2I(transform.Transform(polygon[index])));
            return polygon2I;
        }

        public Polygon2D ToPolygon2D()
        {
            Polygon2D polygon2D = new Polygon2D(this.Count);
            foreach (Point2I point2I in (List<Point2I>)this)
                polygon2D.Add(new Point2D((double)point2I.X, (double)point2I.Y));
            return polygon2D;
        }

        public Polygon2D ToPolygon2D(Matrix3D transform)
        {
            Polygon2D polygon2D = new Polygon2D(this.Count);
            foreach (Point2I point2I in (List<Point2I>)this)
                polygon2D.Add(transform.Transform(new Point2D((double)point2I.X, (double)point2I.Y)));
            return polygon2D;
        }

        public Polygon2D ToPolygon2D(Matrix4D transform)
        {
            Polygon2D polygon2D = new Polygon2D(this.Count);
            foreach (Point2I point2I in (List<Point2I>)this)
                polygon2D.Add(transform.Transform(new Point2D((double)point2I.X, (double)point2I.Y)));
            return polygon2D;
        }

        public bool HasSegments
        {
            get
            {
                return this.Count > 0;
            }
        }

        public static bool IsInside(Point2I p, IList<Point2I> polygon)
        {
            return (Polygon2I.GetWindingNumber((long)p.X, (long)p.Y, polygon) & 1) == 1;
        }

        public static bool IsInsidePolygons(Point2I p, IEnumerator polygonsEnumerator)
        {
            if (polygonsEnumerator == null)
                return false;
            int num = 0;
            polygonsEnumerator.Reset();
            while (polygonsEnumerator.MoveNext())
                num += Polygon2I.GetWindingNumber((long)p.X, (long)p.Y, (IList<Point2I>)polygonsEnumerator.Current);
            return (num & 1) == 1;
        }

        public static bool IsInside(Point2I p, IEnumerable<IList<Point2I>> polygons)
        {
            return Polygon2I.IsInsidePolygons(p, (IEnumerator)polygons.GetEnumerator());
        }

        public static int GetWindingNumber(Point2I p, IList<Point2I> polygon)
        {
            return Polygon2I.GetWindingNumber((long)p.X, (long)p.Y, polygon);
        }

        public static int GetWindingNumber(long x, long y, IList<Point2I> polygon)
        {
            int num = 0;
            int count = polygon.Count;
            if (count > 0)
            {
                Point2I point2I1 = polygon[count - 1];
                for (int index = 0; index < count; ++index)
                {
                    Point2I point2I2 = polygon[index];
                    if ((long)point2I1.Y <= y)
                    {
                        if ((long)point2I2.Y > y && Polygon2I.smethod_4((long)point2I1.X, (long)point2I1.Y, (long)point2I2.X, (long)point2I2.Y, x, y) > 0L)
                            ++num;
                    }
                    else if ((long)point2I2.Y <= y && Polygon2I.smethod_4((long)point2I1.X, (long)point2I1.Y, (long)point2I2.X, (long)point2I2.Y, x, y) < 0L)
                        --num;
                    point2I1 = point2I2;
                }
            }
            return num;
        }

        public static bool IsClockwise(IList<Point2I> polygon)
        {
            return Polygon2I.smethod_0(polygon) < 0L;
        }

        private static long smethod_0(IList<Point2I> polygon)
        {
            int count = polygon.Count;
            if (count < 3)
                return 0;
            long num = 0;
            Point2I point2I1 = polygon[count - 1];
            for (int index = 0; index < count; ++index)
            {
                Point2I point2I2 = polygon[index];
                num += (long)(point2I1.X * point2I2.Y - point2I2.X * point2I1.Y);
                point2I1 = point2I2;
            }
            return num;
        }

        public static bool IsClockwise(Point2I p0, Point2I p1, Point2I p2, Point2I p3)
        {
            return Polygon2I.smethod_1(p0, p1, p2, p3) < 0L;
        }

        private static long smethod_1(Point2I p0, Point2I p1, Point2I p2, Point2I p3)
        {
            return 0L + (long)(p0.X * p1.Y - p1.X * p0.Y) + (long)(p1.X * p2.Y - p2.X * p1.Y) + (long)(p2.X * p3.Y - p3.X * p2.Y) + (long)(p3.X * p0.Y - p0.X * p3.Y);
        }

        public static void GetSegments(IList<Point2I> polygon, IList<Segment2I> segments)
        {
            int count = polygon.Count;
            Point2I start = polygon[count - 1];
            for (int index = 0; index < count; ++index)
            {
                Point2I end = polygon[index];
                Segment2I segment2I = new Segment2I(start, end);
                segments.Add(segment2I);
                start = end;
            }
        }

        public Polygon2I GetConvexHull()
        {
            return Polygon2I.GetConvexHull((IList<Point2I>)this);
        }

        public static Polygon2I GetConvexHull(IList<Point2I> polygon)
        {
            LinkedList<Point2I> linkedList = new LinkedList<Point2I>();
            int num1;
            for (num1 = 0; num1 + 2 < polygon.Count; ++num1)
            {
                long num2 = Polygon2I.smethod_2(polygon[0], polygon[num1 + 1], polygon[num1 + 2]);
                if (num2 <= 0L)
                {
                    if (num2 < 0L)
                    {
                        linkedList.AddLast(polygon[num1 + 2]);
                        linkedList.AddLast(polygon[num1 + 2]);
                        LinkedListNode<Point2I> node = linkedList.AddAfter(linkedList.First, polygon[num1 + 1]);
                        linkedList.AddAfter(node, polygon[0]);
                        break;
                    }
                }
                else
                {
                    linkedList.AddLast(polygon[num1 + 2]);
                    linkedList.AddLast(polygon[num1 + 2]);
                    LinkedListNode<Point2I> node = linkedList.AddAfter(linkedList.First, polygon[0]);
                    linkedList.AddAfter(node, polygon[num1 + 1]);
                    break;
                }
            }
            for (int index = num1 + 3; index < polygon.Count; ++index)
            {
                Point2I p2 = polygon[index];
                if (Polygon2I.smethod_2(linkedList.First.Value, linkedList.First.Next.Value, p2) <= 0L || Polygon2I.smethod_2(linkedList.Last.Previous.Value, linkedList.Last.Value, p2) <= 0L)
                {
                    while (linkedList.First.Next != null && Polygon2I.smethod_2(linkedList.First.Value, linkedList.First.Next.Value, p2) <= 0L)
                        linkedList.RemoveFirst();
                    linkedList.AddFirst(p2);
                    while (linkedList.Last.Previous != null && Polygon2I.smethod_2(linkedList.Last.Previous.Value, linkedList.Last.Value, p2) <= 0L)
                        linkedList.RemoveLast();
                    linkedList.AddLast(p2);
                }
            }
            Polygon2I polygon2I = new Polygon2I();
            LinkedListNode<Point2I> linkedListNode = linkedList.First;
            for (int index = 1; index < linkedList.Count; ++index)
            {
                LinkedListNode<Point2I> next = linkedListNode.Next;
                polygon2I.Add(linkedListNode.Value);
                linkedListNode = next;
            }
            return polygon2I;
        }

        private static long smethod_2(Point2I p0, Point2I p1, Point2I p2)
        {
            return (long)((p1.X - p0.X) * (p2.Y - p0.Y) - (p2.X - p0.X) * (p1.Y - p0.Y));
        }

        private static void smethod_3(
          IList<Point2I> convexPolygon,
          int n,
          Vector2I direction,
          ref int j,
          ref long projection)
        {
            int num1 = j;
            j = (j + 1) % n;
            while (j != num1)
            {
                long num2 = Vector2I.DotProduct(direction, convexPolygon[j] - Point2I.Zero);
                if (num2 >= projection)
                {
                    projection = num2;
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

        private static long smethod_4(long x1, long y1, long x2, long y2, long x3, long y3)
        {
            return (x2 - x1) * (y3 - y1) - (y2 - y1) * (x3 - x1);
        }

        private static bool smethod_5(long x1, long y1, long x2, long y2, long x3, long y3)
        {
            return Polygon2I.smethod_4(x1, y1, x2, y2, x3, y3) > 0L;
        }

        private static bool smethod_6(long x1, long y1, long x2, long y2, long x3, long y3)
        {
            return Polygon2I.smethod_4(x1, y1, x2, y2, x3, y3) < 0L;
        }

        public class BooleanOperations20Bits
        {
            public const int MaxInt = 741455;
            internal const int int_0 = 43;
            internal const double double_0 = 8796093022208.0;
            internal const long long_0 = 4398046511104;
            internal const long long_1 = 8796093022208;
            internal const long long_2 = -8796093022208;

            public static void GetScaleToIntegralTransforms(
              Bounds2D bounds,
              out Matrix4D scaleTransform,
              out Matrix4D inverseScaleTransform)
            {
                Transformation4D.GetScaleToIntegralTransforms(bounds, 741455L, out scaleTransform, out inverseScaleTransform);
            }

            public static List<Polygon2I> GetUnion(
              IList<Polygon2I> region1,
              IList<Polygon2I> region2)
            {
                Polygon2I.BooleanOperations20Bits.Region splitRegion1;
                Polygon2I.BooleanOperations20Bits.Region splitRegion2;
                List<Polygon2I.BooleanOperations20Bits.Segment> segments;
                Polygon2I.BooleanOperations20Bits.smethod_5(region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                return Polygon2I.BooleanOperations20Bits.smethod_0(splitRegion1, splitRegion2, segments).ToPolygon2IList();
            }

            public static Polygon2I.BooleanOperations20Bits.Region GetUnion(
              Polygon2I.BooleanOperations20Bits.Context context,
              Polygon2I.BooleanOperations20Bits.Region region1,
              Polygon2I.BooleanOperations20Bits.Region region2)
            {
                Polygon2I.BooleanOperations20Bits.Region splitRegion1;
                Polygon2I.BooleanOperations20Bits.Region splitRegion2;
                List<Polygon2I.BooleanOperations20Bits.Segment> segments;
                Polygon2I.BooleanOperations20Bits.smethod_6(context, region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                return Polygon2I.BooleanOperations20Bits.smethod_0(splitRegion1, splitRegion2, segments);
            }

            private static Polygon2I.BooleanOperations20Bits.Region smethod_0(Polygon2I.BooleanOperations20Bits.Region region1, Polygon2I.BooleanOperations20Bits.Region region2, List<Polygon2I.BooleanOperations20Bits.Segment> segments)
            {
                Polygon2I.BooleanOperations20Bits.Region region = new Polygon2I.BooleanOperations20Bits.Region(false);
                int count = segments.Count;
                foreach (Polygon2I.BooleanOperations20Bits.Segment segment in segments)
                {
                    if (segment.Processed)
                    {
                        continue;
                    }
                    Polygon2I.BooleanOperations20Bits.smethod_10(region1, region2, segments, segment, region, (Polygon2I.BooleanOperations20Bits.Segment s) => (s.Region != region1 ? s.Status == Polygon2I.BooleanOperations20Bits.SegmentStatus.Outside : (s.Status == Polygon2I.BooleanOperations20Bits.SegmentStatus.Outside ? true : s.Status == Polygon2I.BooleanOperations20Bits.SegmentStatus.Shared)), ref count);
                }
                return region;
            }

            public static List<Polygon2I> GetDifference(
        IList<Polygon2I> region1,
        IList<Polygon2I> region2)
            {
                Polygon2I.BooleanOperations20Bits.Region splitRegion1;
                Polygon2I.BooleanOperations20Bits.Region splitRegion2;
                List<Polygon2I.BooleanOperations20Bits.Segment> segments;
                Polygon2I.BooleanOperations20Bits.smethod_5(region1, false, region2, true, out splitRegion1, out splitRegion2, out segments);
                return Polygon2I.BooleanOperations20Bits.smethod_1(splitRegion1, splitRegion2, segments).ToPolygon2IList();
            }

            public static Polygon2I.BooleanOperations20Bits.Region GetDifference(
              Polygon2I.BooleanOperations20Bits.Context context,
              Polygon2I.BooleanOperations20Bits.Region region1,
              Polygon2I.BooleanOperations20Bits.Region region2)
            {
                Polygon2I.BooleanOperations20Bits.Region splitRegion1;
                Polygon2I.BooleanOperations20Bits.Region splitRegion2;
                List<Polygon2I.BooleanOperations20Bits.Segment> segments;
                Polygon2I.BooleanOperations20Bits.smethod_6(context, region1, false, region2, true, out splitRegion1, out splitRegion2, out segments);
                return Polygon2I.BooleanOperations20Bits.smethod_1(splitRegion1, splitRegion2, segments);
            }

            private static Polygon2I.BooleanOperations20Bits.Region smethod_1(Polygon2I.BooleanOperations20Bits.Region region1, Polygon2I.BooleanOperations20Bits.Region region2, List<Polygon2I.BooleanOperations20Bits.Segment> segments)
            {
                Polygon2I.BooleanOperations20Bits.Region region = new Polygon2I.BooleanOperations20Bits.Region(false);
                int count = segments.Count;
                foreach (Polygon2I.BooleanOperations20Bits.Segment segment in segments)
                {
                    if (segment.Processed)
                    {
                        continue;
                    }
                    Polygon2I.BooleanOperations20Bits.smethod_10(region1, region2, segments, segment, region, (Polygon2I.BooleanOperations20Bits.Segment s) => (s.Region != region1 ? s.Status == Polygon2I.BooleanOperations20Bits.SegmentStatus.Inside : (s.Status == Polygon2I.BooleanOperations20Bits.SegmentStatus.Inside ? true : s.Status == Polygon2I.BooleanOperations20Bits.SegmentStatus.Shared)), ref count);
                }
                return region;
            }

            public static List<Polygon2I> GetIntersection(
              IList<Polygon2I> region1,
              IList<Polygon2I> region2)
            {
                Polygon2I.BooleanOperations20Bits.Region splitRegion1;
                Polygon2I.BooleanOperations20Bits.Region splitRegion2;
                List<Polygon2I.BooleanOperations20Bits.Segment> segments;
                Polygon2I.BooleanOperations20Bits.smethod_5(region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                return Polygon2I.BooleanOperations20Bits.smethod_2(splitRegion1, splitRegion2, segments).ToPolygon2IList();
            }

            public static Polygon2I.BooleanOperations20Bits.Region GetIntersection(
              Polygon2I.BooleanOperations20Bits.Context context,
              Polygon2I.BooleanOperations20Bits.Region region1,
              Polygon2I.BooleanOperations20Bits.Region region2)
            {
                Polygon2I.BooleanOperations20Bits.Region splitRegion1;
                Polygon2I.BooleanOperations20Bits.Region splitRegion2;
                List<Polygon2I.BooleanOperations20Bits.Segment> segments;
                Polygon2I.BooleanOperations20Bits.smethod_6(context, region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                return Polygon2I.BooleanOperations20Bits.smethod_2(splitRegion1, splitRegion2, segments);
            }

            private static Polygon2I.BooleanOperations20Bits.Region smethod_2(Polygon2I.BooleanOperations20Bits.Region region1, Polygon2I.BooleanOperations20Bits.Region region2, List<Polygon2I.BooleanOperations20Bits.Segment> segments)
            {
                Polygon2I.BooleanOperations20Bits.Region region = new Polygon2I.BooleanOperations20Bits.Region(false);
                int count = segments.Count;
                foreach (Polygon2I.BooleanOperations20Bits.Segment segment in segments)
                {
                    if (segment.Processed)
                    {
                        continue;
                    }
                    Polygon2I.BooleanOperations20Bits.smethod_10(region1, region2, segments, segment, region, (Polygon2I.BooleanOperations20Bits.Segment s) => (s.Region != region1 ? s.Status == Polygon2I.BooleanOperations20Bits.SegmentStatus.Inside : (s.Status == Polygon2I.BooleanOperations20Bits.SegmentStatus.Inside ? true : s.Status == Polygon2I.BooleanOperations20Bits.SegmentStatus.Shared)), ref count);
                }
                return region;
            }

            public static List<Polygon2I> GetExclusiveOr(
              IList<Polygon2I> region1,
              IList<Polygon2I> region2)
            {
                Polygon2I.BooleanOperations20Bits.Region splitRegion1;
                Polygon2I.BooleanOperations20Bits.Region splitRegion2;
                List<Polygon2I.BooleanOperations20Bits.Segment> segments;
                Polygon2I.BooleanOperations20Bits.smethod_5(region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                Polygon2I.BooleanOperations20Bits.smethod_3(segments);
                return Polygon2I.BooleanOperations20Bits.smethod_4(splitRegion1, splitRegion2, segments).ToPolygon2IList();
            }

            public static Polygon2I.BooleanOperations20Bits.Region GetExclusiveOr(
              Polygon2I.BooleanOperations20Bits.Context context,
              Polygon2I.BooleanOperations20Bits.Region region1,
              Polygon2I.BooleanOperations20Bits.Region region2)
            {
                Polygon2I.BooleanOperations20Bits.Region splitRegion1;
                Polygon2I.BooleanOperations20Bits.Region splitRegion2;
                List<Polygon2I.BooleanOperations20Bits.Segment> segments;
                Polygon2I.BooleanOperations20Bits.smethod_6(context, region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                Polygon2I.BooleanOperations20Bits.smethod_3(segments);
                return Polygon2I.BooleanOperations20Bits.smethod_4(splitRegion1, splitRegion2, segments);
            }

            private static void smethod_3(
              List<Polygon2I.BooleanOperations20Bits.Segment> segments)
            {
                foreach (Polygon2I.BooleanOperations20Bits.Segment segment in segments)
                {
                    if (segment.Status == Polygon2I.BooleanOperations20Bits.SegmentStatus.Inside)
                        segment.Reverse();
                }
            }

            private static Polygon2I.BooleanOperations20Bits.Region smethod_4(
              Polygon2I.BooleanOperations20Bits.Region region1,
              Polygon2I.BooleanOperations20Bits.Region region2,
              List<Polygon2I.BooleanOperations20Bits.Segment> segments)
            {
                Polygon2I.BooleanOperations20Bits.Region resultRegion = new Polygon2I.BooleanOperations20Bits.Region(false);
                int count = segments.Count;
                foreach (Polygon2I.BooleanOperations20Bits.Segment segment in segments)
                {
                    if (!segment.Processed)
                        Polygon2I.BooleanOperations20Bits.smethod_10(region1, region2, segments, segment, resultRegion, (Func<Polygon2I.BooleanOperations20Bits.Segment, bool>)(s =>
                       {
                           if (s.Status != Polygon2I.BooleanOperations20Bits.SegmentStatus.Outside)
                               return s.Status == Polygon2I.BooleanOperations20Bits.SegmentStatus.Inside;
                           return true;
                       }), ref count);
                }
                return resultRegion;
            }

            public static Polygon2I.BooleanOperations20Bits.Region Subdivide(
              Polygon2I.BooleanOperations20Bits.Context context,
              Polygon2I.BooleanOperations20Bits.Region region)
            {
                return region.Subdivide(context);
            }

            private static void smethod_5(
              IList<Polygon2I> region1,
              bool reverseRegion1,
              IList<Polygon2I> region2,
              bool reverseRegion2,
              out Polygon2I.BooleanOperations20Bits.Region splitRegion1,
              out Polygon2I.BooleanOperations20Bits.Region splitRegion2,
              out List<Polygon2I.BooleanOperations20Bits.Segment> segments)
            {
                Polygon2I.BooleanOperations20Bits.Context context = new Polygon2I.BooleanOperations20Bits.Context();
                splitRegion1 = Polygon2I.BooleanOperations20Bits.GetRegion(region1, context, reverseRegion1);
                splitRegion2 = Polygon2I.BooleanOperations20Bits.GetRegion(region2, context, reverseRegion2);
                Polygon2I.BooleanOperations20Bits.smethod_7(context, splitRegion1, splitRegion2, out segments);
            }

            private static void smethod_6(
              Polygon2I.BooleanOperations20Bits.Context context,
              Polygon2I.BooleanOperations20Bits.Region region1,
              bool reverseRegion1,
              Polygon2I.BooleanOperations20Bits.Region region2,
              bool reverseRegion2,
              out Polygon2I.BooleanOperations20Bits.Region splitRegion1,
              out Polygon2I.BooleanOperations20Bits.Region splitRegion2,
              out List<Polygon2I.BooleanOperations20Bits.Segment> segments)
            {
                splitRegion1 = Polygon2I.BooleanOperations20Bits.smethod_13(context, region1, reverseRegion1);
                splitRegion2 = Polygon2I.BooleanOperations20Bits.smethod_13(context, region2, reverseRegion2);
                Polygon2I.BooleanOperations20Bits.smethod_7(context, splitRegion1, splitRegion2, out segments);
            }

            private static void smethod_7(
              Polygon2I.BooleanOperations20Bits.Context context,
              Polygon2I.BooleanOperations20Bits.Region region1,
              Polygon2I.BooleanOperations20Bits.Region region2,
              out List<Polygon2I.BooleanOperations20Bits.Segment> segments)
            {
                Polygon2I.BooleanOperations20Bits.IEventQueue eventQueue = Polygon2I.BooleanOperations20Bits.Class43.smethod_0(Polygon2I.BooleanOperations20Bits.Class43.smethod_1(region1, region2) << 1);
                eventQueue.imethod_0(context, region1, region2);
                new Polygon2I.BooleanOperations20Bits.SweepLine(eventQueue, context, true).method_0();
                Polygon2I.BooleanOperations20Bits.smethod_11(context, region1);
                Polygon2I.BooleanOperations20Bits.smethod_11(context, region2);
                Polygon2I.BooleanOperations20Bits.smethod_8(region1);
                Polygon2I.BooleanOperations20Bits.smethod_8(region2);
                segments = new List<Polygon2I.BooleanOperations20Bits.Segment>();
                region1.GetSegments((IList<Polygon2I.BooleanOperations20Bits.Segment>)segments);
                region2.GetSegments((IList<Polygon2I.BooleanOperations20Bits.Segment>)segments);
                region1.CalculateSegmentStatus(region2);
                region2.CalculateSegmentStatus(region1);
            }


            private static void smethod_8(Polygon2I.BooleanOperations20Bits.Region region)
            {
                LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> polygonSegmentNode;
                LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> linkedListNode;
                for (int i = region.Count - 1; i >= 0; i--)
                {
                    Polygon2I.BooleanOperations20Bits.Polygon item = region[i];
                    bool flag = false;
                    foreach (Polygon2I.BooleanOperations20Bits.Segment segment in item)
                    {
                        if (segment.Start.Vertices.Count <= 1)
                        {
                            continue;
                        }
                        List<Polygon2I.BooleanOperations20Bits.Vertex>.Enumerator enumerator = segment.Start.Vertices.GetEnumerator();
                        try
                        {
                            while (true)
                            {
                                if (enumerator.MoveNext())
                                {
                                    Polygon2I.BooleanOperations20Bits.Vertex current = enumerator.Current;
                                    if (current.InSegment != segment && current.InSegment.Polygon == item && current.InSegment.Status != Polygon2I.BooleanOperations20Bits.SegmentStatus.SelfOverlap && current.InSegment.Start == segment.End)
                                    {
                                        segment.Status = Polygon2I.BooleanOperations20Bits.SegmentStatus.SelfOverlap;
                                        current.InSegment.Status = Polygon2I.BooleanOperations20Bits.SegmentStatus.SelfOverlap;
                                        flag = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        finally
                        {
                            ((IDisposable)enumerator).Dispose();
                        }
                    }
                    if (flag)
                    {
                        region.RemoveAt(i);
                        bool flag1 = item.IsClockwise();
                        while (item.Count > 0)
                        {
                            LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> first = item.First;
                            Polygon2I.BooleanOperations20Bits.Segment value = first.Value;
                            if (value.Status != Polygon2I.BooleanOperations20Bits.SegmentStatus.SelfOverlap)
                            {
                                Polygon2I.BooleanOperations20Bits.Polygon polygon = new Polygon2I.BooleanOperations20Bits.Polygon(region);
                                region.Add(polygon);
                                value.PolygonSegmentNode = polygon.AddLast(value);
                                Polygon2I.BooleanOperations20Bits.Point start = value.Start;
                                if (!flag1)
                                {
                                    do
                                    {
                                        item.Remove(first);
                                        Polygon2I.BooleanOperations20Bits.Segment nextUnprocessedSegmentCcw = value.End.GetNextUnprocessedSegmentCcw(value, (Polygon2I.BooleanOperations20Bits.Segment s) => s.Polygon == item);
                                        Polygon2I.BooleanOperations20Bits.smethod_9(value);
                                        if (nextUnprocessedSegmentCcw == null)
                                        {
                                            polygonSegmentNode = null;
                                        }
                                        else
                                        {
                                            polygonSegmentNode = nextUnprocessedSegmentCcw.PolygonSegmentNode;
                                        }
                                        LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> linkedListNode1 = polygonSegmentNode;
                                        nextUnprocessedSegmentCcw.PolygonSegmentNode = polygon.AddLast(nextUnprocessedSegmentCcw);
                                        first = linkedListNode1;
                                        value = first.Value;
                                    }
                                    while (value.End != start);
                                }
                                else
                                {
                                    do
                                    {
                                        item.Remove(first);
                                        Polygon2I.BooleanOperations20Bits.Segment nextUnprocessedSegmentCw = value.End.GetNextUnprocessedSegmentCw(value, (Polygon2I.BooleanOperations20Bits.Segment s) => s.Polygon == item);
                                        Polygon2I.BooleanOperations20Bits.smethod_9(value);
                                        if (nextUnprocessedSegmentCw == null)
                                        {
                                            linkedListNode = null;
                                        }
                                        else
                                        {
                                            linkedListNode = nextUnprocessedSegmentCw.PolygonSegmentNode;
                                        }
                                        LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> linkedListNode2 = linkedListNode;
                                        nextUnprocessedSegmentCw.PolygonSegmentNode = polygon.AddLast(nextUnprocessedSegmentCw);
                                        first = linkedListNode2;
                                        value = first.Value;
                                    }
                                    while (value.End != start);
                                }
                                if (first != null && first.List != null)
                                {
                                    item.Remove(first);
                                    Polygon2I.BooleanOperations20Bits.smethod_9(value);
                                }
                                polygon.method_4();
                            }
                            else
                            {
                                item.Remove(first);
                                Polygon2I.BooleanOperations20Bits.smethod_9(value);
                                value.PolygonSegmentNode = null;
                            }
                        }
                    }
                }
            }


            private static void smethod_9(Polygon2I.BooleanOperations20Bits.Segment segment)
            {
                for (int index = segment.Start.Vertices.Count - 1; index >= 0; --index)
                {
                    if (segment.Start.Vertices[index].OutSegment == segment)
                    {
                        segment.Start.Vertices.RemoveAt(index);
                        break;
                    }
                }
                for (int index = segment.End.Vertices.Count - 1; index >= 0; --index)
                {
                    if (segment.End.Vertices[index].InSegment == segment)
                    {
                        segment.End.Vertices.RemoveAt(index);
                        break;
                    }
                }
            }

            private static void smethod_10(
              Polygon2I.BooleanOperations20Bits.Region region1,
              Polygon2I.BooleanOperations20Bits.Region region2,
              List<Polygon2I.BooleanOperations20Bits.Segment> segments,
              Polygon2I.BooleanOperations20Bits.Segment startSegment,
              Polygon2I.BooleanOperations20Bits.Region resultRegion,
              Func<Polygon2I.BooleanOperations20Bits.Segment, bool> includeSegment,
              ref int n)
            {
                Polygon2I.BooleanOperations20Bits.Segment segment1 = startSegment;
                Polygon2I.BooleanOperations20Bits.Polygon polygon = (Polygon2I.BooleanOperations20Bits.Polygon)null;
                Polygon2I.BooleanOperations20Bits.Segment segment2 = (Polygon2I.BooleanOperations20Bits.Segment)null;
                while (n > 0)
                {
                    segment1.Processed = true;
                    --n;
                    if (!includeSegment(segment1))
                        break;
                    if (segment2 == null)
                    {
                        segment2 = segment1;
                        polygon = new Polygon2I.BooleanOperations20Bits.Polygon(resultRegion);
                        resultRegion.Add(polygon);
                    }
                    segment1.PolygonSegmentNode = polygon.AddLast(segment1);
                    if (segment1.End == segment2.Start)
                        break;
                    segment1 = segment1.End.GetNextUnprocessedSegmentCcw(segment1, includeSegment);
                }
            }

            private static Polygon2I.BooleanOperations20Bits.Region smethod_11(
              Polygon2I.BooleanOperations20Bits.Context context,
              Polygon2I.BooleanOperations20Bits.Region region)
            {
                foreach (Polygon2I.BooleanOperations20Bits.Polygon polygon in (List<Polygon2I.BooleanOperations20Bits.Polygon>)region)
                    polygon.method_4();
                return region;
            }

            private static Polygon2I.BooleanOperations20Bits.Region smethod_12(
              Polygon2I.BooleanOperations20Bits.Context context,
              Polygon2I.BooleanOperations20Bits.Region region)
            {
                Polygon2I.BooleanOperations20Bits.Region region1 = new Polygon2I.BooleanOperations20Bits.Region(region.Reversed);
                foreach (Polygon2I.BooleanOperations20Bits.Polygon polygon in (List<Polygon2I.BooleanOperations20Bits.Polygon>)region)
                {
                    Polygon2I.BooleanOperations20Bits.Polygon splitPolygon = new Polygon2I.BooleanOperations20Bits.Polygon(region1);
                    region1.Add(splitPolygon);
                    foreach (Polygon2I.BooleanOperations20Bits.Segment segment in (LinkedList<Polygon2I.BooleanOperations20Bits.Segment>)polygon)
                        segment.AddSegments(context, splitPolygon);
                }
                return region1;
            }

            public static Polygon2I.BooleanOperations20Bits.Region GetRegion(
              IList<Polygon2I> input,
              Polygon2I.BooleanOperations20Bits.Context context)
            {
                return Polygon2I.BooleanOperations20Bits.GetRegion(input, context, false);
            }

            public static Polygon2I.BooleanOperations20Bits.Region GetRegion(
              IList<Polygon2I> input,
              Polygon2I.BooleanOperations20Bits.Context context,
              bool reverse)
            {
                Polygon2I.BooleanOperations20Bits.Region region = new Polygon2I.BooleanOperations20Bits.Region(reverse);
                foreach (Polygon2I inputPolygon in (IEnumerable<Polygon2I>)input)
                {
                    if (inputPolygon.Count > 0)
                    {
                        Polygon2I.BooleanOperations20Bits.Polygon polygon = new Polygon2I.BooleanOperations20Bits.Polygon(region);
                        region.Add(polygon);
                        if (reverse)
                            polygon.method_3(inputPolygon, context);
                        else
                            polygon.method_2(inputPolygon, context);
                    }
                }
                return region;
            }

            private static Polygon2I.BooleanOperations20Bits.Region smethod_13(
              Polygon2I.BooleanOperations20Bits.Context context,
              Polygon2I.BooleanOperations20Bits.Region input,
              bool reverse)
            {
                Polygon2I.BooleanOperations20Bits.Region region = input;
                if (reverse)
                    region = input.GetReverse(context);
                region.method_0();
                return region;
            }

            private static Point2L smethod_14(Point2I point)
            {
                return new Point2L((long)point.X << 43, (long)point.Y << 43);
            }

            private static long smethod_15(int i)
            {
                return (long)i << 43;
            }

            private static double smethod_16(double d)
            {
                return d * 8796093022208.0;
            }

            private static double smethod_17(long l)
            {
                return (double)l / 8796093022208.0;
            }

            private static Point2D smethod_18(Point2L p)
            {
                return new Point2D((double)p.X / 8796093022208.0, (double)p.Y / 8796093022208.0);
            }

            private static Point2I smethod_19(Point2L p)
            {
                return new Point2I((int)(p.X + 4398046511104L >> 43), (int)(p.Y + 4398046511104L >> 43));
            }

            private static long smethod_20(long l)
            {
                return l + 4398046511104L & -8796093022208L;
            }

            private static Point2L smethod_21(Point2L p)
            {
                return new Point2L(Polygon2I.BooleanOperations20Bits.smethod_20(p.X), Polygon2I.BooleanOperations20Bits.smethod_20(p.Y));
            }

            [Serializable]
            public class Point
            {
                private List<Polygon2I.BooleanOperations20Bits.Vertex> vertices = new List<Polygon2I.BooleanOperations20Bits.Vertex>();
                internal Point2I position;

                public Point(Point2I position)
                {
                    this.position = position;
                }

                public Point2I Position
                {
                    get
                    {
                        return this.position;
                    }
                }

                public List<Polygon2I.BooleanOperations20Bits.Vertex> Vertices
                {
                    get
                    {
                        return this.vertices;
                    }
                }

                public void AddVertexSorted(Polygon2I.BooleanOperations20Bits.Vertex vertex)
                {
                    int index = this.vertices.BinarySearch(vertex, (IComparer<Polygon2I.BooleanOperations20Bits.Vertex>)Polygon2I.BooleanOperations20Bits.Vertex.OutSegmentDirectionComparer.Instance);
                    if (index < 0)
                        this.vertices.Insert(~index, vertex);
                    else
                        this.vertices.Insert(index, vertex);
                }

                public void RemoveVerticesWithInSegment(
                  Polygon2I.BooleanOperations20Bits.Segment inSegment)
                {
                    for (int index = this.vertices.Count - 1; index >= 0; --index)
                    {
                        if (this.vertices[index].InSegment == inSegment)
                            this.vertices.RemoveAt(index);
                    }
                }

                public void RemoveVerticesWithOutSegment(
                  Polygon2I.BooleanOperations20Bits.Segment outSegment)
                {
                    for (int index = this.vertices.Count - 1; index >= 0; --index)
                    {
                        if (this.vertices[index].OutSegment == outSegment)
                            this.vertices.RemoveAt(index);
                    }
                }

                public Polygon2I.BooleanOperations20Bits.Segment GetNextUnprocessedSegmentCw(
                  Polygon2I.BooleanOperations20Bits.Segment segment,
                  Func<Polygon2I.BooleanOperations20Bits.Segment, bool> includeSegment)
                {
                    if (this.vertices.Count == 1)
                    {
                        Polygon2I.BooleanOperations20Bits.Segment outSegment = this.vertices[0].OutSegment;
                        if (!includeSegment(outSegment))
                            return (Polygon2I.BooleanOperations20Bits.Segment)null;
                        return outSegment;
                    }
                    Vector2I b = -segment.Direction;
                    Polygon2I.BooleanOperations20Bits.Segment segment1 = (Polygon2I.BooleanOperations20Bits.Segment)null;
                    for (int index = 0; index < this.vertices.Count; ++index)
                    {
                        Polygon2I.BooleanOperations20Bits.Vertex vertex = this.vertices[index];
                        if (!vertex.OutSegment.Processed && Vector2I.CompareAngles(vertex.OutSegment.Direction, b) > 0 && includeSegment(vertex.OutSegment))
                        {
                            segment1 = vertex.OutSegment;
                            break;
                        }
                    }
                    if (segment1 == null)
                    {
                        for (int index = 0; index < this.vertices.Count; ++index)
                        {
                            Polygon2I.BooleanOperations20Bits.Vertex vertex = this.vertices[index];
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

                public Polygon2I.BooleanOperations20Bits.Segment GetNextUnprocessedSegmentCcw(
                  Polygon2I.BooleanOperations20Bits.Segment segment,
                  Func<Polygon2I.BooleanOperations20Bits.Segment, bool> includeSegment)
                {
                    if (this.vertices.Count == 1)
                    {
                        Polygon2I.BooleanOperations20Bits.Segment outSegment = this.vertices[0].OutSegment;
                        if (!includeSegment(outSegment))
                            return (Polygon2I.BooleanOperations20Bits.Segment)null;
                        return outSegment;
                    }
                    Vector2I b = -segment.Direction;
                    Polygon2I.BooleanOperations20Bits.Segment segment1 = (Polygon2I.BooleanOperations20Bits.Segment)null;
                    for (int index = this.vertices.Count - 1; index >= 0; --index)
                    {
                        Polygon2I.BooleanOperations20Bits.Vertex vertex = this.vertices[index];
                        if (!vertex.OutSegment.Processed && Vector2I.CompareAngles(vertex.OutSegment.Direction, b) < 0 && includeSegment(vertex.OutSegment))
                        {
                            segment1 = vertex.OutSegment;
                            break;
                        }
                    }
                    if (segment1 == null)
                    {
                        for (int index = this.vertices.Count - 1; index >= 0; --index)
                        {
                            Polygon2I.BooleanOperations20Bits.Vertex vertex = this.vertices[index];
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

                public Polygon2I.BooleanOperations20Bits.Segment GetNextUnprocessedSegmentBiDirectionalCcw(
                  Polygon2I.BooleanOperations20Bits.Context context,
                  Polygon2I.BooleanOperations20Bits.Segment segment,
                  Polygon2I.BooleanOperations20Bits.Segment segmentSource,
                  Func<Polygon2I.BooleanOperations20Bits.Segment, bool> includeSegment,
                  out Polygon2I.BooleanOperations20Bits.Segment resultSource)
                {
                    Vector2I b1 = -segment.Direction;
                    resultSource = (Polygon2I.BooleanOperations20Bits.Segment)null;
                    Polygon2I.BooleanOperations20Bits.Segment segment1 = (Polygon2I.BooleanOperations20Bits.Segment)null;
                    Vector2I b2 = Vector2I.Zero;
                    for (int index = this.vertices.Count - 1; index >= 0; --index)
                    {
                        Polygon2I.BooleanOperations20Bits.Vertex vertex = this.vertices[index];
                        if (!vertex.OutSegment.Processed && vertex.OutSegment != segmentSource && (Vector2I.CompareAngles(vertex.OutSegment.Direction, b1) < 0 && includeSegment(vertex.OutSegment)) && (segment1 == null || Vector2I.CompareAngles(vertex.OutSegment.Direction, b2) > 0))
                        {
                            resultSource = vertex.OutSegment;
                            segment1 = vertex.OutSegment;
                            b2 = vertex.OutSegment.Direction;
                        }
                        if (!vertex.InSegment.Processed && vertex.InSegment != segmentSource && (Vector2I.CompareAngles(-vertex.InSegment.Direction, b1) < 0 && includeSegment(vertex.InSegment)) && (segment1 == null || Vector2I.CompareAngles(-vertex.InSegment.Direction, b2) > 0))
                        {
                            resultSource = vertex.InSegment;
                            segment1 = vertex.InSegment.vmethod_1(context);
                            b2 = -vertex.InSegment.Direction;
                        }
                    }
                    if (segment1 == null)
                    {
                        for (int index = this.vertices.Count - 1; index >= 0; --index)
                        {
                            Polygon2I.BooleanOperations20Bits.Vertex vertex = this.vertices[index];
                            if (!vertex.OutSegment.Processed && vertex.OutSegment != segmentSource && includeSegment(vertex.OutSegment) && (segment1 == null || Vector2I.CompareAngles(vertex.OutSegment.Direction, b2) > 0))
                            {
                                resultSource = vertex.OutSegment;
                                segment1 = vertex.OutSegment;
                                b2 = vertex.OutSegment.Direction;
                            }
                            if (!vertex.InSegment.Processed && vertex.InSegment != segmentSource && includeSegment(vertex.InSegment) && (segment1 == null || Vector2I.CompareAngles(-vertex.InSegment.Direction, b2) > 0))
                            {
                                resultSource = vertex.InSegment;
                                segment1 = vertex.InSegment.vmethod_1(context);
                                b2 = -vertex.InSegment.Direction;
                            }
                        }
                    }
                    if (segment1 == null)
                    {
                        for (int index = this.vertices.Count - 1; index >= 0; --index)
                        {
                            Polygon2I.BooleanOperations20Bits.Vertex vertex = this.vertices[index];
                            Vector2I vector2I;
                            if (!vertex.OutSegment.Processed && vertex.OutSegment != segmentSource && (vertex.OutSegment.method_4(segmentSource) && includeSegment(vertex.OutSegment)) && segment1 == null)
                            {
                                resultSource = vertex.OutSegment;
                                segment1 = vertex.OutSegment;
                                vector2I = vertex.OutSegment.Direction;
                            }
                            if (!vertex.InSegment.Processed && vertex.InSegment != segmentSource && (vertex.InSegment.method_4(segmentSource) && includeSegment(vertex.InSegment)) && segment1 == null)
                            {
                                resultSource = vertex.InSegment;
                                segment1 = vertex.InSegment.vmethod_1(context);
                                vector2I = -vertex.InSegment.Direction;
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
                private Polygon2I.BooleanOperations20Bits.Segment inSegment;
                private Polygon2I.BooleanOperations20Bits.Segment outSegment;

                public Vertex(
                  Polygon2I.BooleanOperations20Bits.Segment inSegment,
                  Polygon2I.BooleanOperations20Bits.Segment outSegment)
                {
                    if (inSegment != null && inSegment.End != outSegment.Start)
                        throw new ArgumentException();
                    this.inSegment = inSegment;
                    this.outSegment = outSegment;
                }

                public Polygon2I.BooleanOperations20Bits.Segment InSegment
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

                public Polygon2I.BooleanOperations20Bits.Segment OutSegment
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

                public Polygon2I.BooleanOperations20Bits.Point Point
                {
                    get
                    {
                        return this.inSegment.End;
                    }
                }

                public Polygon2I.BooleanOperations20Bits.Region Region
                {
                    get
                    {
                        return this.inSegment.Region;
                    }
                }

                public bool IsInside(Polygon2I.BooleanOperations20Bits.Segment segment)
                {
                    if (segment.Start != this.inSegment.End)
                        throw new ArgumentException();
                    Vector2I vector2I = -this.inSegment.Direction;
                    Vector2I direction1 = this.outSegment.Direction;
                    Vector2I direction2 = segment.Direction;
                    int num1 = Vector2I.CompareAngles(vector2I, direction1);
                    int num2 = Vector2I.CompareAngles(direction2, vector2I);
                    int num3 = Vector2I.CompareAngles(direction2, direction1);
                    return num1 < 0 ? num2 <= 0 || num3 >= 0 : num2 <= 0 && num3 >= 0;
                }

                public override string ToString()
                {
                    return string.Format("Position: {0}, vertices: {1}", (object)this.Point.Position, (object)this.Point.Vertices.Count);
                }

                public class OutSegmentDirectionComparer : IComparer<Polygon2I.BooleanOperations20Bits.Vertex>
                {
                    public static readonly Polygon2I.BooleanOperations20Bits.Vertex.OutSegmentDirectionComparer Instance = new Polygon2I.BooleanOperations20Bits.Vertex.OutSegmentDirectionComparer();

                    private OutSegmentDirectionComparer()
                    {
                    }

                    public int Compare(
                      Polygon2I.BooleanOperations20Bits.Vertex x,
                      Polygon2I.BooleanOperations20Bits.Vertex y)
                    {
                        return Vector2I.CompareAngles(x.outSegment.Direction, y.outSegment.Direction);
                    }
                }
            }

            [Serializable]
            public class Segment
            {
                private int id;
                private Polygon2I.BooleanOperations20Bits.Point start;
                private Polygon2I.BooleanOperations20Bits.Point end;
                private Point2I left;
                private Point2I right;
                private Polygon2I.BooleanOperations20Bits.SegmentStatus status;
                private bool processed;
                private Vector2I direction;
                private bool isForward;
                private bool slopeIsPositive;
                private bool slopeIsNegative;
                [NonSerialized]
                private LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> linkedListNode_0;
                [NonSerialized]
                private RedBlackTree<Polygon2I.BooleanOperations20Bits.Segment>.Node node_0;
                [NonSerialized]
                private LinkedListNode<Polygon2I.BooleanOperations20Bits.SNActiveSegment> linkedListNode_1;

                public Segment(Polygon2I.BooleanOperations20Bits.Context context)
                {
                    this.id = context.GetNextSegmentId();
                }

                public Segment(
                  Polygon2I.BooleanOperations20Bits.Context context,
                  Polygon2I.BooleanOperations20Bits.Point start,
                  Polygon2I.BooleanOperations20Bits.Point end)
                {
                    Point2I position1 = start.position;
                    Point2I position2 = end.position;
                    if (position1 == position2)
                        throw new ArgumentException("Start and end point may not be the same.");
                    this.id = context.GetNextSegmentId();
                    this.start = start;
                    this.end = end;
                    this.direction = position2 - position1;
                    this.isForward = this.direction.X > 0 || this.direction.X == 0 && this.direction.Y > 0;
                    if (this.isForward)
                    {
                        this.left = start.position;
                        this.right = end.position;
                        this.slopeIsPositive = position2.Y > position1.Y;
                        this.slopeIsNegative = position2.Y < position1.Y;
                    }
                    else
                    {
                        this.left = end.position;
                        this.right = start.position;
                        this.slopeIsPositive = position1.Y > position2.Y;
                        this.slopeIsNegative = position1.Y < position2.Y;
                    }
                }

                public Segment(
                  Polygon2I.BooleanOperations20Bits.Point start,
                  Polygon2I.BooleanOperations20Bits.Point end,
                  Vector2I direction)
                {
                    this.start = start;
                    this.end = end;
                    this.direction = direction;
                }

                public int Id
                {
                    get
                    {
                        return this.id;
                    }
                }

                public Polygon2I.BooleanOperations20Bits.Polygon Polygon
                {
                    get
                    {
                        if (this.linkedListNode_0 != null)
                            return (Polygon2I.BooleanOperations20Bits.Polygon)this.linkedListNode_0.List;
                        return (Polygon2I.BooleanOperations20Bits.Polygon)null;
                    }
                }

                public Polygon2I.BooleanOperations20Bits.Point Start
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

                public Polygon2I.BooleanOperations20Bits.Point End
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

                public Point2I Left
                {
                    get
                    {
                        return this.left;
                    }
                }

                public Point2I Right
                {
                    get
                    {
                        return this.right;
                    }
                }

                internal Polygon2I.BooleanOperations20Bits.SegmentStatus Status
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

                public Vector2I Direction
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

                public Vector2I OrderedDirection
                {
                    get
                    {
                        return this.right - this.left;
                    }
                }

                public bool IsForward
                {
                    get
                    {
                        return this.isForward;
                    }
                }

                public bool SlopeIsPositive
                {
                    get
                    {
                        return this.slopeIsPositive;
                    }
                }

                public bool SlopeIsNegative
                {
                    get
                    {
                        return this.slopeIsNegative;
                    }
                }

                public Polygon2I.BooleanOperations20Bits.Region Region
                {
                    get
                    {
                        return ((Polygon2I.BooleanOperations20Bits.Polygon)this.linkedListNode_0.List).Region;
                    }
                }

                public LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> PolygonSegmentNode
                {
                    get
                    {
                        return this.linkedListNode_0;
                    }
                    set
                    {
                        this.linkedListNode_0 = value;
                    }
                }

                public RedBlackTree<Polygon2I.BooleanOperations20Bits.Segment>.Node ActiveSegmentNode
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

                internal LinkedListNode<Polygon2I.BooleanOperations20Bits.SNActiveSegment> SnActiveSegmentNode
                {
                    get
                    {
                        return this.linkedListNode_1;
                    }
                    set
                    {
                        this.linkedListNode_1 = value;
                    }
                }

                public void AddSegments(
                  Polygon2I.BooleanOperations20Bits.Polygon splitPolygon)
                {
                    Polygon2I.BooleanOperations20Bits.Segment segment = new Polygon2I.BooleanOperations20Bits.Segment(this.start, this.end, this.direction);
                    segment.linkedListNode_0 = splitPolygon.AddLast(segment);
                }

                public void AddSegments(
                  Polygon2I.BooleanOperations20Bits.Context context,
                  Polygon2I.BooleanOperations20Bits.Polygon splitPolygon)
                {
                    Polygon2I.BooleanOperations20Bits.Segment segment = new Polygon2I.BooleanOperations20Bits.Segment(context, this.start, this.end);
                    segment.linkedListNode_0 = splitPolygon.AddLast(segment);
                }

                public void CalculateStatusFirstSegment(
                  Polygon2I.BooleanOperations20Bits.Region otherRegion)
                {
                    if (this.status != Polygon2I.BooleanOperations20Bits.SegmentStatus.Unknown)
                        return;
                    this.method_1(otherRegion);
                    if (this.status != Polygon2I.BooleanOperations20Bits.SegmentStatus.Unknown)
                        return;
                    if (this.method_0(otherRegion) == 0)
                    {
                        if (otherRegion.IsInside(this.start.Position))
                            this.status = Polygon2I.BooleanOperations20Bits.SegmentStatus.Inside;
                        else
                            this.status = Polygon2I.BooleanOperations20Bits.SegmentStatus.Outside;
                    }
                    else
                        this.method_2(otherRegion);
                }

                internal static bool smethod_0(
                  Polygon2I.BooleanOperations20Bits.Segment a,
                  Polygon2I.BooleanOperations20Bits.Segment b,
                  out Point2I intersection,
                  out int dxSign,
                  out int dySign)
                {
                    Vector2L direction1 = (Vector2L)a.Direction;
                    Vector2L direction2 = (Vector2L)b.Direction;
                    Point2I position1 = a.start.position;
                    Point2I position2 = b.start.position;
                    long denominator = direction1.X * direction2.Y - direction1.Y * direction2.X;
                    if (denominator == 0L)
                    {
                        intersection = Point2I.Zero;
                        dxSign = 0;
                        dySign = 0;
                        return false;
                    }
                    long num1 = (long)(position2.X - position1.X) * direction2.Y - (long)(position2.Y - position1.Y) * direction2.X;
                    if (denominator > 0L)
                    {
                        if (num1 <= 0L || num1 >= denominator)
                        {
                            intersection = Point2I.Zero;
                            dxSign = 0;
                            dySign = 0;
                            return false;
                        }
                    }
                    else if (num1 >= 0L || num1 <= denominator)
                    {
                        intersection = Point2I.Zero;
                        dxSign = 0;
                        dySign = 0;
                        return false;
                    }
                    long num2 = (long)(position2.X - position1.X) * direction1.Y - (long)(position2.Y - position1.Y) * direction1.X;
                    long numerator1;
                    long numerator2;
                    if (denominator > 0L)
                    {
                        if (num2 > 0L && num2 < denominator)
                        {
                            numerator1 = num1 * direction1.X;
                            numerator2 = num1 * direction1.Y;
                        }
                        else
                        {
                            intersection = Point2I.Zero;
                            dxSign = 0;
                            dySign = 0;
                            return false;
                        }
                    }
                    else if (num2 < 0L && num2 > denominator)
                    {
                        denominator = -denominator;
                        numerator1 = -num1 * direction1.X;
                        numerator2 = -num1 * direction1.Y;
                    }
                    else
                    {
                        intersection = Point2I.Zero;
                        dxSign = 0;
                        dySign = 0;
                        return false;
                    }
                    int dx1;
                    Polygon2I.BooleanOperations20Bits.Segment.smethod_1(numerator1, denominator, out dx1, out dxSign);
                    int dx2;
                    Polygon2I.BooleanOperations20Bits.Segment.smethod_1(numerator2, denominator, out dx2, out dySign);
                    intersection = new Point2I(position1.X + dx1, position1.Y + dx2);
                    return true;
                }

                internal static void smethod_1(
                  long numerator,
                  long denominator,
                  out int dx,
                  out int dxSign)
                {
                    dx = (int)(numerator / denominator);
                    long num = numerator % denominator;
                    if (numerator >= 0L)
                    {
                        if (2L * num >= denominator)
                        {
                            ++dx;
                            dxSign = -1;
                        }
                        else if (num == 0L)
                            dxSign = 0;
                        else
                            dxSign = 1;
                    }
                    else if (-2L * num > denominator)
                    {
                        --dx;
                        dxSign = 1;
                    }
                    else if (num == 0L)
                        dxSign = 0;
                    else
                        dxSign = -1;
                }

                public double GetIntersectionYCoordinate(double x)
                {
                    double x1 = (double)this.direction.X;
                    if (x1 == 0.0)
                        return (double)this.left.Y;
                    Point2I position = this.start.Position;
                    return (x - (double)position.X) * (double)this.direction.Y / x1 + (double)position.Y;
                }

                private int method_0(Polygon2I.BooleanOperations20Bits.Region region)
                {
                    int num = 0;
                    foreach (Polygon2I.BooleanOperations20Bits.Vertex vertex in this.start.Vertices)
                    {
                        if (vertex.Region == region)
                            ++num;
                    }
                    return num;
                }

                public void CalculateStatus(
                  Polygon2I.BooleanOperations20Bits.Segment previousSegment,
                  Polygon2I.BooleanOperations20Bits.Region otherRegion)
                {
                    if (this.status != Polygon2I.BooleanOperations20Bits.SegmentStatus.Unknown)
                        return;
                    if (this.method_0(otherRegion) == 0)
                    {
                        this.status = previousSegment.status;
                    }
                    else
                    {
                        this.method_1(otherRegion);
                        if (this.status != Polygon2I.BooleanOperations20Bits.SegmentStatus.Unknown)
                            return;
                        this.method_2(otherRegion);
                    }
                }

                private void method_1(
                  Polygon2I.BooleanOperations20Bits.Region otherRegion)
                {
                    foreach (Polygon2I.BooleanOperations20Bits.Vertex vertex in this.start.Vertices)
                    {
                        if (vertex.Region == otherRegion)
                        {
                            if (vertex.InSegment.start != this.end)
                            {
                                if (vertex.OutSegment.end == this.end)
                                {
                                    this.status = Polygon2I.BooleanOperations20Bits.SegmentStatus.Shared;
                                    break;
                                }
                            }
                            else
                            {
                                this.status = Polygon2I.BooleanOperations20Bits.SegmentStatus.SharedOpposite;
                                break;
                            }
                        }
                    }
                }

                private void method_2(
                  Polygon2I.BooleanOperations20Bits.Region otherRegion)
                {
                    this.status = Polygon2I.BooleanOperations20Bits.SegmentStatus.Outside;
                    foreach (Polygon2I.BooleanOperations20Bits.Vertex vertex in this.start.Vertices)
                    {
                        if (vertex.Region == otherRegion && vertex.IsInside(this))
                        {
                            this.status = Polygon2I.BooleanOperations20Bits.SegmentStatus.Inside;
                            break;
                        }
                    }
                }

                public void Reverse()
                {
                    this.start.RemoveVerticesWithOutSegment(this);
                    Polygon2I.BooleanOperations20Bits.Point start = this.start;
                    this.start = this.end;
                    this.end = start;
                    this.direction = -this.direction;
                    this.start.AddVertexSorted(new Polygon2I.BooleanOperations20Bits.Vertex((Polygon2I.BooleanOperations20Bits.Segment)null, this));
                }

                public Segment2I ToSegment2I()
                {
                    return new Segment2I(this.start.Position, this.end.Position);
                }

                public override string ToString()
                {
                    return string.Format("Start: {0}, End: {1}, Status: {2}", (object)this.start, (object)this.end, (object)this.status);
                }

                internal virtual Polygon2I.BooleanOperations20Bits.Segment vmethod_0(
                  Polygon2I.BooleanOperations20Bits.Context context)
                {
                    return new Polygon2I.BooleanOperations20Bits.Segment(context, this.start, this.end);
                }

                internal virtual Polygon2I.BooleanOperations20Bits.Segment vmethod_1(
                  Polygon2I.BooleanOperations20Bits.Context context)
                {
                    return new Polygon2I.BooleanOperations20Bits.Segment(context, this.end, this.start);
                }

                internal bool method_3(
                  Polygon2I.BooleanOperations20Bits.Segment otherSegment)
                {
                    if (this.start != otherSegment.start && this.start != otherSegment.end && this.end != otherSegment.start)
                        return this.end == otherSegment.end;
                    return true;
                }

                internal bool method_4(Polygon2I.BooleanOperations20Bits.Segment other)
                {
                    if (this.start == other.start && this.end == other.end)
                        return true;
                    if (this.start == other.end)
                        return this.end == other.start;
                    return false;
                }

                internal bool method_5(Point2I position)
                {
                    if (!(position == this.start.position))
                        return position == this.end.position;
                    return true;
                }
            }

            [Serializable]
            public class Polygon : LinkedList<Polygon2I.BooleanOperations20Bits.Segment>
            {
                private Polygon2I.BooleanOperations20Bits.Region region;

                public Polygon()
                {
                }

                protected Polygon(SerializationInfo info, StreamingContext context)
                  : base(info, context)
                {
                }

                public Polygon(Polygon2I.BooleanOperations20Bits.Region region)
                {
                    this.region = region;
                }

                public Polygon(
                  Polygon2I.BooleanOperations20Bits.Context context,
                  Polygon2I.BooleanOperations20Bits.Region region,
                  Polygon2I inputPolygon)
                {
                    this.region = region;
                    if (region.Reversed)
                        this.method_3(inputPolygon, context);
                    else
                        this.method_2(inputPolygon, context);
                }

                public Polygon2I.BooleanOperations20Bits.Region Region
                {
                    get
                    {
                        return this.region;
                    }
                }

                public static int GetWindingNumber(
                  Point2I p,
                  Polygon2I.BooleanOperations20Bits.Polygon polygon)
                {
                    return Polygon2I.BooleanOperations20Bits.Polygon.GetWindingNumber((long)p.X, (long)p.Y, polygon);
                }

                public static int GetWindingNumber(
                  long x,
                  long y,
                  Polygon2I.BooleanOperations20Bits.Polygon polygon)
                {
                    int num = 0;
                    int count = polygon.Count;
                    if (count > 0)
                    {
                        LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> linkedListNode = polygon.First;
                        Polygon2I.BooleanOperations20Bits.Segment segment = linkedListNode.Value;
                        Point2I point2I = segment.Start.Position;
                        for (int index = 0; index < count; ++index)
                        {
                            Segment2I segment2I = segment.ToSegment2I();
                            Point2I position = segment.End.Position;
                            if ((long)point2I.Y <= y)
                            {
                                if ((long)position.Y > y && Polygon2I.smethod_5((long)segment2I.Start.X, (long)segment2I.Start.Y, (long)segment2I.End.X, (long)segment2I.End.Y, x, y))
                                    ++num;
                            }
                            else if ((long)position.Y <= y && Polygon2I.smethod_6((long)segment2I.Start.X, (long)segment2I.Start.Y, (long)segment2I.End.X, (long)segment2I.End.Y, x, y))
                                --num;
                            linkedListNode = linkedListNode.Next;
                            segment = linkedListNode == null ? (Polygon2I.BooleanOperations20Bits.Segment)null : linkedListNode.Value;
                            point2I = position;
                        }
                    }
                    return num;
                }

                public void CalculateSegmentStatus(
                  Polygon2I.BooleanOperations20Bits.Region otherRegion)
                {
                    if (this.Count <= 0)
                        return;
                    Polygon2I.BooleanOperations20Bits.Segment previousSegment = this.Last.Value;
                    LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> linkedListNode = this.First;
                    previousSegment.CalculateStatusFirstSegment(otherRegion);
                    for (int index = 1; index < this.Count; ++index)
                    {
                        Polygon2I.BooleanOperations20Bits.Segment segment = linkedListNode.Value;
                        segment.CalculateStatus(previousSegment, otherRegion);
                        previousSegment = segment;
                        linkedListNode = linkedListNode.Next;
                    }
                }

                public Polygon2I.BooleanOperations20Bits.Polygon GetReversedPolygon(
                  Polygon2I.BooleanOperations20Bits.Context context,
                  Polygon2I.BooleanOperations20Bits.Region targetRegion)
                {
                    Polygon2I.BooleanOperations20Bits.Polygon polygon = new Polygon2I.BooleanOperations20Bits.Polygon(targetRegion);
                    if (this.Count > 0)
                    {
                        LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> linkedListNode = this.Last;
                        for (int index = this.Count - 1; index >= 0; --index)
                        {
                            Polygon2I.BooleanOperations20Bits.Segment segment = linkedListNode.Value.vmethod_1(context);
                            segment.PolygonSegmentNode = polygon.AddLast(segment);
                            linkedListNode = linkedListNode.Previous;
                        }
                    }
                    return polygon;
                }

                public long GetDoubleArea()
                {
                    int count = this.Count;
                    if (count < 3)
                        return 0;
                    long num = 0;
                    Point2I point2I = this.Last.Value.Start.Position;
                    LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> linkedListNode = this.First;
                    for (int index = 0; index < count; ++index)
                    {
                        Point2I position = linkedListNode.Value.Start.Position;
                        num += (long)(point2I.X * position.Y - position.X * point2I.Y);
                        point2I = position;
                        linkedListNode = linkedListNode.Next;
                    }
                    return num;
                }

                public bool IsClockwise()
                {
                    if (this.Count < 3)
                        return false;
                    LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> linkedListNode1 = this.Last;
                    LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> linkedListNode2 = this.First;
                    LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> linkedListNode3 = this.First;
                    LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> next = linkedListNode3.Next;
                    for (int index = 1; index < this.Count; ++index)
                    {
                        Polygon2I.BooleanOperations20Bits.Segment segment = next.Value;
                        if (segment.Start.Position.X < linkedListNode2.Value.Start.Position.X || segment.Start.Position.X == linkedListNode2.Value.Start.Position.X && segment.Start.Position.Y < linkedListNode2.Value.Start.Position.Y)
                        {
                            linkedListNode1 = linkedListNode3;
                            linkedListNode2 = next;
                        }
                        linkedListNode3 = next;
                        next = next.Next;
                    }
                    int num;
                    for (num = this.Count - 2; num > 0 && linkedListNode1.Value.Start == linkedListNode2.Value.End; num -= 2)
                    {
                        linkedListNode1 = linkedListNode1.Previous ?? this.First;
                        linkedListNode2 = linkedListNode2.Next ?? this.Last;
                    }
                    if (num <= 0)
                        return false;
                    return Vector2I.CrossProduct(linkedListNode1.Value.ToSegment2I().GetDelta(), linkedListNode2.Value.ToSegment2I().GetDelta()) < 0L;
                }

                internal Polygon2I method_0()
                {
                    Polygon2I polygon2I = new Polygon2I(this.Count + 1);
                    if (this.Count > 0)
                    {
                        foreach (Polygon2I.BooleanOperations20Bits.Segment segment in (LinkedList<Polygon2I.BooleanOperations20Bits.Segment>)this)
                            polygon2I.Add(segment.Start.Position);
                        if (this.Last.Value.End != this.First.Value.Start)
                            polygon2I.Add(this.Last.Value.End.Position);
                    }
                    return polygon2I;
                }

                public Polygon2D ToPolygon2D(Matrix4D transform)
                {
                    Polygon2D polygon2D = new Polygon2D(this.Count + 1);
                    if (this.Count > 0)
                    {
                        foreach (Polygon2I.BooleanOperations20Bits.Segment segment in (LinkedList<Polygon2I.BooleanOperations20Bits.Segment>)this)
                            polygon2D.Add(transform.Transform((Point2D)segment.Start.Position));
                        if (this.Last.Value.End != this.First.Value.Start)
                            polygon2D.Add(transform.Transform((Point2D)this.Last.Value.End.Position));
                    }
                    return polygon2D;
                }

                internal void method_1()
                {
                    foreach (Polygon2I.BooleanOperations20Bits.Segment segment in (LinkedList<Polygon2I.BooleanOperations20Bits.Segment>)this)
                        segment.Status = Polygon2I.BooleanOperations20Bits.SegmentStatus.Unknown;
                }

                internal void method_2(
                  Polygon2I inputPolygon,
                  Polygon2I.BooleanOperations20Bits.Context context)
                {
                    Point2I p1 = inputPolygon[inputPolygon.Count - 1];
                    Polygon2I.BooleanOperations20Bits.Point start = context.method_0(p1);
                    for (int index = 0; index < inputPolygon.Count; ++index)
                    {
                        Point2I p2 = inputPolygon[index];
                        Polygon2I.BooleanOperations20Bits.Point end = context.method_0(p2);
                        if (start.Position != end.Position)
                        {
                            Polygon2I.BooleanOperations20Bits.Segment segment = new Polygon2I.BooleanOperations20Bits.Segment(context, start, end);
                            segment.PolygonSegmentNode = this.AddLast(segment);
                        }
                        start = end;
                    }
                }

                internal void method_3(
                  Polygon2I inputPolygon,
                  Polygon2I.BooleanOperations20Bits.Context context)
                {
                    Point2I p1 = inputPolygon[0];
                    Polygon2I.BooleanOperations20Bits.Point start = context.method_0(p1);
                    for (int index = inputPolygon.Count - 1; index >= 0; --index)
                    {
                        Point2I p2 = inputPolygon[index];
                        Polygon2I.BooleanOperations20Bits.Point end = context.method_0(p2);
                        if (start.Position != end.Position)
                        {
                            Polygon2I.BooleanOperations20Bits.Segment segment = new Polygon2I.BooleanOperations20Bits.Segment(context, start, end);
                            segment.PolygonSegmentNode = this.AddLast(segment);
                        }
                        start = end;
                    }
                }

                internal void method_4()
                {
                    Polygon2I.BooleanOperations20Bits.Segment inSegment = this.Last.Value;
                    foreach (Polygon2I.BooleanOperations20Bits.Segment outSegment in (LinkedList<Polygon2I.BooleanOperations20Bits.Segment>)this)
                    {
                        outSegment.Start.AddVertexSorted(new Polygon2I.BooleanOperations20Bits.Vertex(inSegment, outSegment));
                        inSegment = outSegment;
                    }
                }
            }

            [Serializable]
            public class Region : List<Polygon2I.BooleanOperations20Bits.Polygon>
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

                public bool IsInside(Point2I p)
                {
                    return this.GetWindingNumber(p) > this.insideMinWindingNumber;
                }

                public int GetWindingNumber(Point2I p)
                {
                    int num = 0;
                    foreach (Polygon2I.BooleanOperations20Bits.Polygon polygon in (List<Polygon2I.BooleanOperations20Bits.Polygon>)this)
                        num += Polygon2I.BooleanOperations20Bits.Polygon.GetWindingNumber((long)p.X, (long)p.Y, polygon);
                    return num;
                }

                public void CalculateSegmentStatus(
                  Polygon2I.BooleanOperations20Bits.Region otherRegion)
                {
                    foreach (Polygon2I.BooleanOperations20Bits.Polygon polygon in (List<Polygon2I.BooleanOperations20Bits.Polygon>)this)
                        polygon.CalculateSegmentStatus(otherRegion);
                }

                public List<Polygon2I> ToPolygon2IList()
                {
                    List<Polygon2I> polygon2IList = new List<Polygon2I>(this.Count);
                    foreach (Polygon2I.BooleanOperations20Bits.Polygon polygon in (List<Polygon2I.BooleanOperations20Bits.Polygon>)this)
                    {
                        Polygon2I polygon2I = new Polygon2I(polygon.Count);
                        foreach (Polygon2I.BooleanOperations20Bits.Segment segment in (LinkedList<Polygon2I.BooleanOperations20Bits.Segment>)polygon)
                            polygon2I.Add(segment.Start.Position);
                        polygon2IList.Add(polygon2I);
                    }
                    return polygon2IList;
                }

                [DebuggerStepThrough]
                public List<IList<Point2I>> ToPoint2IListList()
                {
                    List<IList<Point2I>> point2IListList = new List<IList<Point2I>>(this.Count);
                    foreach (Polygon2I.BooleanOperations20Bits.Polygon polygon in (List<Polygon2I.BooleanOperations20Bits.Polygon>)this)
                    {
                        Polygon2I polygon2I = new Polygon2I(polygon.Count);
                        foreach (Polygon2I.BooleanOperations20Bits.Segment segment in (LinkedList<Polygon2I.BooleanOperations20Bits.Segment>)polygon)
                            polygon2I.Add(segment.Start.Position);
                        point2IListList.Add((IList<Point2I>)polygon2I);
                    }
                    return point2IListList;
                }

                public Polygon2DCollection ToPolygon2DCollection()
                {
                    Polygon2DCollection polygon2Dcollection = new Polygon2DCollection(this.Count);
                    foreach (Polygon2I.BooleanOperations20Bits.Polygon polygon in (List<Polygon2I.BooleanOperations20Bits.Polygon>)this)
                    {
                        Polygon2D polygon2D = new Polygon2D(polygon.Count);
                        foreach (Polygon2I.BooleanOperations20Bits.Segment segment in (LinkedList<Polygon2I.BooleanOperations20Bits.Segment>)polygon)
                            polygon2D.Add(segment.Start.Position.ToPoint2D());
                        polygon2Dcollection.Add(polygon2D);
                    }
                    return polygon2Dcollection;
                }

                public void GetSegments(
                  IList<Polygon2I.BooleanOperations20Bits.Segment> segments)
                {
                    foreach (LinkedList<Polygon2I.BooleanOperations20Bits.Segment> linkedList in (List<Polygon2I.BooleanOperations20Bits.Polygon>)this)
                    {
                        foreach (Polygon2I.BooleanOperations20Bits.Segment segment in linkedList)
                            segments.Add(segment);
                    }
                }

                public Polygon2I.BooleanOperations20Bits.Region GetReverse(
                  Polygon2I.BooleanOperations20Bits.Context context)
                {
                    Polygon2I.BooleanOperations20Bits.Region targetRegion = new Polygon2I.BooleanOperations20Bits.Region(!this.reversed);
                    for (int index = this.Count - 1; index >= 0; --index)
                        targetRegion.Add(this[index].GetReversedPolygon(context, targetRegion));
                    return targetRegion;
                }

                public List<Polygon2I> ToPolygon2IListDebug()
                {
                    List<Polygon2I> polygon2IList = new List<Polygon2I>(this.Count);
                    foreach (Polygon2I.BooleanOperations20Bits.Polygon polygon in (List<Polygon2I.BooleanOperations20Bits.Polygon>)this)
                    {
                        Polygon2I polygon2I = polygon.method_0();
                        polygon2IList.Add(polygon2I);
                    }
                    return polygon2IList;
                }

                public Polygon2I.BooleanOperations20Bits.Region Subdivide(
                  Polygon2I.BooleanOperations20Bits.Context context)
                {
                    Polygon2I.BooleanOperations20Bits.Region region = Polygon2I.BooleanOperations20Bits.smethod_12(context, this);
                    Polygon2I.BooleanOperations20Bits.IEventQueue eventQueue = Polygon2I.BooleanOperations20Bits.Class43.smethod_0(Polygon2I.BooleanOperations20Bits.Class43.smethod_2(region) << 1);
                    eventQueue.imethod_1(context, region);
                    new Polygon2I.BooleanOperations20Bits.SweepLine(eventQueue, context, false).method_0();
                    return region;
                }

                internal void method_0()
                {
                    foreach (Polygon2I.BooleanOperations20Bits.Polygon polygon in (List<Polygon2I.BooleanOperations20Bits.Polygon>)this)
                        polygon.method_1();
                }
            }

            internal interface IEventQueue
            {
                int Count { get; }

                void imethod_0(
                  Polygon2I.BooleanOperations20Bits.Context context,
                  Polygon2I.BooleanOperations20Bits.Region a,
                  Polygon2I.BooleanOperations20Bits.Region b);

                void imethod_1(
                  Polygon2I.BooleanOperations20Bits.Context context,
                  Polygon2I.BooleanOperations20Bits.Region region);

                void imethod_2(Polygon2I.BooleanOperations20Bits.Event e);

                Polygon2I.BooleanOperations20Bits.Event imethod_3();
            }

            internal static class Class43
            {
                public static Polygon2I.BooleanOperations20Bits.IEventQueue smethod_0(
                  int eventCount)
                {
                    if (eventCount > 400000)
                        return (Polygon2I.BooleanOperations20Bits.IEventQueue)new Polygon2I.BooleanOperations20Bits.TreeEventQueue();
                    return (Polygon2I.BooleanOperations20Bits.IEventQueue)new Polygon2I.BooleanOperations20Bits.ListEventQueue(eventCount << 1);
                }

                public static int smethod_1(
                  Polygon2I.BooleanOperations20Bits.Region region1,
                  Polygon2I.BooleanOperations20Bits.Region region2)
                {
                    return 0 + Polygon2I.BooleanOperations20Bits.Class43.smethod_2(region1) + Polygon2I.BooleanOperations20Bits.Class43.smethod_2(region2);
                }

                public static int smethod_2(Polygon2I.BooleanOperations20Bits.Region region)
                {
                    int num = 0;
                    foreach (Polygon2I.BooleanOperations20Bits.Polygon polygon in (List<Polygon2I.BooleanOperations20Bits.Polygon>)region)
                        num += polygon.Count;
                    return num;
                }
            }

            [Serializable]
            internal class ListEventQueue : List<Polygon2I.BooleanOperations20Bits.Event>, Polygon2I.BooleanOperations20Bits.IEventQueue
            {
                public ListEventQueue()
                {
                }

                public ListEventQueue(int capacity)
                  : base(capacity)
                {
                }

                public void imethod_0(
                  Polygon2I.BooleanOperations20Bits.Context context,
                  Polygon2I.BooleanOperations20Bits.Region a,
                  Polygon2I.BooleanOperations20Bits.Region b)
                {
                    this.method_0(context, a);
                    this.method_0(context, b);
                    this.Sort((IComparer<Polygon2I.BooleanOperations20Bits.Event>)Polygon2I.BooleanOperations20Bits.Event.Class46.class46_0);
                }

                public void imethod_1(
                  Polygon2I.BooleanOperations20Bits.Context context,
                  Polygon2I.BooleanOperations20Bits.Region region)
                {
                    this.method_0(context, region);
                    this.Sort((IComparer<Polygon2I.BooleanOperations20Bits.Event>)Polygon2I.BooleanOperations20Bits.Event.Class46.class46_0);
                }

                private void method_0(
                  Polygon2I.BooleanOperations20Bits.Context context,
                  Polygon2I.BooleanOperations20Bits.Region region)
                {
                    foreach (Polygon2I.BooleanOperations20Bits.Polygon polygon in (List<Polygon2I.BooleanOperations20Bits.Polygon>)region)
                    {
                        if (polygon.Count > 0)
                        {
                            LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> linkedListNode = polygon.First;
                            for (int count = polygon.Count; count > 0; --count)
                            {
                                Polygon2I.BooleanOperations20Bits.Segment segment = linkedListNode.Value;
                                Point2I left = segment.Left;
                                Point2I right = segment.Right;
                                if (segment.Direction.X == 0)
                                {
                                    this.Add((Polygon2I.BooleanOperations20Bits.Event)new Polygon2I.BooleanOperations20Bits.VerticalEntryEvent(context.GetNextEventId(), left, segment));
                                    this.Add((Polygon2I.BooleanOperations20Bits.Event)new Polygon2I.BooleanOperations20Bits.VerticalExitEvent(context.GetNextEventId(), right, segment));
                                }
                                else
                                {
                                    this.Add((Polygon2I.BooleanOperations20Bits.Event)new Polygon2I.BooleanOperations20Bits.EntryEvent(context.GetNextEventId(), left, segment));
                                    this.Add((Polygon2I.BooleanOperations20Bits.Event)new Polygon2I.BooleanOperations20Bits.ExitEvent(context.GetNextEventId(), right, segment));
                                }
                                linkedListNode = linkedListNode.Next;
                            }
                        }
                    }
                }

                public void imethod_2(Polygon2I.BooleanOperations20Bits.Event e)
                {
                    int index1 = 0;
                    int num1 = this.Count;
                    int num2 = -1;
                    while (index1 < num1)
                    {
                        int index2 = index1 + num1 >> 1;
                        num2 = e.CompareTo(this[index2]);
                        if (num2 < 0)
                            index1 = index2 + 1;
                        else
                            num1 = index2;
                    }
                    if (num2 == 0)
                        return;
                    this.Insert(index1, e);
                }

                public Polygon2I.BooleanOperations20Bits.Event imethod_3()
                {
                    Polygon2I.BooleanOperations20Bits.Event @event = (Polygon2I.BooleanOperations20Bits.Event)null;
                    if (this.Count > 0)
                    {
                        @event = this[this.Count - 1];
                        this.RemoveAt(this.Count - 1);
                    }
                    return @event;
                }
            }

            [Serializable]
            internal class TreeEventQueue : RedBlackTreeWhereItemComparable<Polygon2I.BooleanOperations20Bits.Event>, Polygon2I.BooleanOperations20Bits.IEventQueue
            {
                public void imethod_0(
                  Polygon2I.BooleanOperations20Bits.Context context,
                  Polygon2I.BooleanOperations20Bits.Region a,
                  Polygon2I.BooleanOperations20Bits.Region b)
                {
                    this.method_4(context, a);
                    this.method_4(context, b);
                }

                public void imethod_1(
                  Polygon2I.BooleanOperations20Bits.Context context,
                  Polygon2I.BooleanOperations20Bits.Region region)
                {
                    this.method_4(context, region);
                }

                private void method_4(
                  Polygon2I.BooleanOperations20Bits.Context context,
                  Polygon2I.BooleanOperations20Bits.Region region)
                {
                    foreach (Polygon2I.BooleanOperations20Bits.Polygon polygon in (List<Polygon2I.BooleanOperations20Bits.Polygon>)region)
                    {
                        if (polygon.Count > 0)
                        {
                            LinkedListNode<Polygon2I.BooleanOperations20Bits.Segment> linkedListNode = polygon.First;
                            for (int count = polygon.Count; count > 0; --count)
                            {
                                Polygon2I.BooleanOperations20Bits.Segment segment = linkedListNode.Value;
                                Point2I position1 = segment.Start.Position;
                                Point2I position2 = segment.End.Position;
                                if (position1.X > position2.X || position1.X == position2.X && position1.Y > position2.Y)
                                    MathUtil.Swap<Point2I>(ref position1, ref position2);
                                if (segment.Direction.X == 0)
                                {
                                    this.Add((Polygon2I.BooleanOperations20Bits.Event)new Polygon2I.BooleanOperations20Bits.VerticalEntryEvent(context.GetNextEventId(), position1, segment));
                                    this.Add((Polygon2I.BooleanOperations20Bits.Event)new Polygon2I.BooleanOperations20Bits.VerticalExitEvent(context.GetNextEventId(), position2, segment));
                                }
                                else
                                {
                                    this.Add((Polygon2I.BooleanOperations20Bits.Event)new Polygon2I.BooleanOperations20Bits.EntryEvent(context.GetNextEventId(), position1, segment));
                                    this.Add((Polygon2I.BooleanOperations20Bits.Event)new Polygon2I.BooleanOperations20Bits.ExitEvent(context.GetNextEventId(), position2, segment));
                                }
                                linkedListNode = linkedListNode.Next;
                            }
                        }
                    }
                }

                public void imethod_2(Polygon2I.BooleanOperations20Bits.Event e)
                {
                    this.TryAdd(e);
                }

                public Polygon2I.BooleanOperations20Bits.Event imethod_3()
                {
                    Polygon2I.BooleanOperations20Bits.Event @event = (Polygon2I.BooleanOperations20Bits.Event)null;
                    if (this.Count > 0)
                    {
                        RedBlackTreeWhereItemComparable<Polygon2I.BooleanOperations20Bits.Event>.Node leftMost = this.Root.GetLeftMost();
                        @event = leftMost.Value;
                        this.Remove(leftMost);
                    }
                    return @event;
                }
            }

            [Serializable]
            internal abstract class Event : IComparable<Polygon2I.BooleanOperations20Bits.Event>
            {
                private const int OrderShift = 0;
                private const int OrderSize = 2;
                private const int DyShift = 2;
                private const int DxSize = 2;
                private const int YShift = 4;
                private const int XSize = 21;
                private const int DxShift = 25;
                private const int XShift = 27;
                private const int PositiveCoordOffset = 2965821;
                private readonly int id;
                private readonly Point2I position;
                private readonly ulong sortField;

                public Event(int id, Point2I position, byte order)
                {
                    this.id = id;
                    this.position = position;
                    this.sortField = (ulong)((long)order + ((long)((position.Y << 2) + 2965821) << 2) + ((long)((position.X << 2) + 2965821) << 25));
                }

                protected Event(int id, Point2I position, int dxSign, int dySign, byte order)
                {
                    this.id = id;
                    this.position = position;
                    this.sortField = (ulong)((long)order + ((long)((position.Y << 2) + dySign + 2965821) << 2) + ((long)((position.X << 2) + dxSign + 2965821) << 25));
                }

                public Point2I Position
                {
                    get
                    {
                        return this.position;
                    }
                }

                public virtual int Order
                {
                    get
                    {
                        throw new NotImplementedException("Should be abstract in future.");
                    }
                }

                public virtual Polygon2I.BooleanOperations20Bits.SNEvent vmethod_0(
                  Polygon2I.BooleanOperations20Bits.SweepLine sweepLine)
                {
                    throw new NotImplementedException("Should be abstract in future.");
                }

                public override string ToString()
                {
                    return string.Format("pos: {0}", (object)this.position);
                }

                public int CompareTo(Polygon2I.BooleanOperations20Bits.Event other)
                {
                    if (this.sortField < other.sortField)
                        return -1;
                    if (this.sortField > other.sortField)
                        return 1;
                    return this.id - other.id;
                }

                public class Class46 : IComparer<Polygon2I.BooleanOperations20Bits.Event>
                {
                    public static Polygon2I.BooleanOperations20Bits.Event.Class46 class46_0 = new Polygon2I.BooleanOperations20Bits.Event.Class46();

                    private Class46()
                    {
                    }

                    public int Compare(
                      Polygon2I.BooleanOperations20Bits.Event x,
                      Polygon2I.BooleanOperations20Bits.Event y)
                    {
                        return y.CompareTo(x);
                    }
                }
            }

            [Serializable]
            internal class EntryEvent : Polygon2I.BooleanOperations20Bits.Event
            {
                private Polygon2I.BooleanOperations20Bits.Segment segment;

                public EntryEvent(
                  int id,
                  Point2I position,
                  Polygon2I.BooleanOperations20Bits.Segment segment)
                  : base(id, position, (byte)3)
                {
                    this.segment = segment;
                }

                public Polygon2I.BooleanOperations20Bits.Segment Segment
                {
                    get
                    {
                        return this.segment;
                    }
                }

                public override int Order
                {
                    get
                    {
                        return 3;
                    }
                }

                public override Polygon2I.BooleanOperations20Bits.SNEvent vmethod_0(
                  Polygon2I.BooleanOperations20Bits.SweepLine sweepLine)
                {
                    sweepLine.method_1(this.Position, this.segment);
                    RedBlackTree<Polygon2I.BooleanOperations20Bits.Segment>.Node node = sweepLine.ActiveSegments.TryAdd(this.segment);
                    this.segment.ActiveSegmentNode = node;
                    RedBlackTree<Polygon2I.BooleanOperations20Bits.Segment>.Node previous = node.GetPrevious();
                    if (previous != null)
                        sweepLine.method_2(previous.Value, node.Value);
                    RedBlackTree<Polygon2I.BooleanOperations20Bits.Segment>.Node next = node.GetNext();
                    if (next != null)
                        sweepLine.method_2(node.Value, next.Value);
                    return (Polygon2I.BooleanOperations20Bits.SNEvent)new Polygon2I.BooleanOperations20Bits.SNEntryEvent(this.Position, this.segment, previous == null ? (Polygon2I.BooleanOperations20Bits.Segment)null : previous.Value);
                }

                public override string ToString()
                {
                    return string.Format("Entry: {0}, segment: {1}", (object)base.ToString(), (object)this.segment);
                }
            }

            [Serializable]
            internal class VerticalEntryEvent : Polygon2I.BooleanOperations20Bits.EntryEvent
            {
                public VerticalEntryEvent(
                  int id,
                  Point2I position,
                  Polygon2I.BooleanOperations20Bits.Segment segment)
                  : base(id, position, segment)
                {
                }

                public override Polygon2I.BooleanOperations20Bits.SNEvent vmethod_0(
                  Polygon2I.BooleanOperations20Bits.SweepLine sweepLine)
                {
                    sweepLine.method_1(this.Position, this.Segment);
                    RedBlackTree<Polygon2I.BooleanOperations20Bits.Segment>.Node node = sweepLine.ActiveSegments.TryAdd(this.Segment);
                    this.Segment.ActiveSegmentNode = node;
                    int y = this.Segment.Right.Y;
                    RedBlackTree<Polygon2I.BooleanOperations20Bits.Segment>.Node next = node.GetNext();
                    while (next != null && sweepLine.method_3(this.Segment, next.Value, this.Position.X, this.Position.Y, y))
                        next = next.GetNext();
                    RedBlackTree<Polygon2I.BooleanOperations20Bits.Segment>.Node previous = node.GetPrevious();
                    sweepLine.ActiveSegments.Remove(node);
                    return (Polygon2I.BooleanOperations20Bits.SNEvent)new Polygon2I.BooleanOperations20Bits.SNVerticalEntryEvent(this.Position, this.Segment, previous == null ? (Polygon2I.BooleanOperations20Bits.Segment)null : previous.Value);
                }
            }

            [Serializable]
            internal class ExitEvent : Polygon2I.BooleanOperations20Bits.Event
            {
                private Polygon2I.BooleanOperations20Bits.Segment segment;

                public ExitEvent(
                  int id,
                  Point2I position,
                  Polygon2I.BooleanOperations20Bits.Segment segment)
                  : base(id, position, (byte)1)
                {
                    this.segment = segment;
                }

                public Polygon2I.BooleanOperations20Bits.Segment Segment
                {
                    get
                    {
                        return this.segment;
                    }
                }

                public override int Order
                {
                    get
                    {
                        return 1;
                    }
                }

                public override Polygon2I.BooleanOperations20Bits.SNEvent vmethod_0(
                  Polygon2I.BooleanOperations20Bits.SweepLine sweepLine)
                {
                    RedBlackTree<Polygon2I.BooleanOperations20Bits.Segment>.Node previous = this.segment.ActiveSegmentNode.GetPrevious();
                    RedBlackTree<Polygon2I.BooleanOperations20Bits.Segment>.Node next = this.segment.ActiveSegmentNode.GetNext();
                    sweepLine.ActiveSegments.Remove(this.segment.ActiveSegmentNode);
                    this.segment.ActiveSegmentNode = (RedBlackTree<Polygon2I.BooleanOperations20Bits.Segment>.Node)null;
                    if (previous != null && next != null)
                        sweepLine.method_2(previous.Value, next.Value);
                    return (Polygon2I.BooleanOperations20Bits.SNEvent)new Polygon2I.BooleanOperations20Bits.SNExitEvent(this.Position, this.segment);
                }

                public override string ToString()
                {
                    return string.Format("Exit: {0}, segment: {1}", (object)base.ToString(), (object)this.segment);
                }
            }

            [Serializable]
            internal class VerticalExitEvent : Polygon2I.BooleanOperations20Bits.ExitEvent
            {
                public VerticalExitEvent(
                  int id,
                  Point2I position,
                  Polygon2I.BooleanOperations20Bits.Segment segment)
                  : base(id, position, segment)
                {
                }

                public override Polygon2I.BooleanOperations20Bits.SNEvent vmethod_0(
                  Polygon2I.BooleanOperations20Bits.SweepLine sweepLine)
                {
                    return (Polygon2I.BooleanOperations20Bits.SNEvent)new Polygon2I.BooleanOperations20Bits.SNVerticalExitEvent(this.Position, this.Segment);
                }
            }

            private class Class44 : Polygon2I.BooleanOperations20Bits.Event
            {
                protected Polygon2I.BooleanOperations20Bits.Segment segment_0;
                protected Polygon2I.BooleanOperations20Bits.Segment segment_1;
                private readonly int int_0;

                public Class44(
                  int id,
                  Point2I position,
                  int dxSign,
                  int dySign,
                  Polygon2I.BooleanOperations20Bits.Segment low,
                  Polygon2I.BooleanOperations20Bits.Segment high)
                  : base(id, position, dxSign, dySign, (byte)2)
                {
                    this.segment_0 = low;
                    this.segment_1 = high;
                    this.int_0 = dxSign;
                }

                public override int Order
                {
                    get
                    {
                        return 2;
                    }
                }

                public override Polygon2I.BooleanOperations20Bits.SNEvent vmethod_0(
                  Polygon2I.BooleanOperations20Bits.SweepLine sweepLine)
                {
                    Polygon2I.BooleanOperations20Bits.SNEvent snEvent = (Polygon2I.BooleanOperations20Bits.SNEvent)null;
                    if (this.segment_0.ActiveSegmentNode.GetNext() == this.segment_1.ActiveSegmentNode)
                    {
                        sweepLine.ActiveSegments.ReverseNodes(this.segment_0.ActiveSegmentNode, this.segment_1.ActiveSegmentNode);
                        RedBlackTree<Polygon2I.BooleanOperations20Bits.Segment>.Node previous = this.segment_1.ActiveSegmentNode.GetPrevious();
                        if (previous != null)
                            sweepLine.method_2(previous.Value, this.segment_1);
                        RedBlackTree<Polygon2I.BooleanOperations20Bits.Segment>.Node next = this.segment_0.ActiveSegmentNode.GetNext();
                        if (next != null)
                            sweepLine.method_2(this.segment_0, next.Value);
                        snEvent = (Polygon2I.BooleanOperations20Bits.SNEvent)new Polygon2I.BooleanOperations20Bits.SNIntersectionEvent(this.Position, this.int_0, this.segment_0, this.segment_1);
                    }
                    else if (this.segment_1.ActiveSegmentNode == null)
                        snEvent = (Polygon2I.BooleanOperations20Bits.SNEvent)new Polygon2I.BooleanOperations20Bits.SNSingleSegmentIntersectionEvent(this.Position, this.segment_0);
                    else if (this.segment_0.ActiveSegmentNode == null)
                        throw new Exception("Low segment not on active segment list.");
                    return snEvent;
                }

                public override string ToString()
                {
                    return string.Format("Intersection: {0}, low: {1}, high: {2}", (object)base.ToString(), (object)this.segment_0, (object)this.segment_1);
                }
            }

            private class Class45 : Polygon2I.BooleanOperations20Bits.Class44
            {
                public Class45(
                  int id,
                  Point2I position,
                  int dxSign,
                  int dySign,
                  Polygon2I.BooleanOperations20Bits.Segment low,
                  Polygon2I.BooleanOperations20Bits.Segment high)
                  : base(id, position, dxSign, dySign, low, high)
                {
                }

                public override Polygon2I.BooleanOperations20Bits.SNEvent vmethod_0(
                  Polygon2I.BooleanOperations20Bits.SweepLine sweepLine)
                {
                    return (Polygon2I.BooleanOperations20Bits.SNEvent)new Polygon2I.BooleanOperations20Bits.SNVerticalIntersectionEvent(this.Position, this.segment_0, this.segment_1);
                }
            }

            [Serializable]
            internal class SweepLine
            {
                private Polygon2I.BooleanOperations20Bits.SweepLine.SegmentComparer segmentComparer = new Polygon2I.BooleanOperations20Bits.SweepLine.SegmentComparer();
                private Polygon2I.BooleanOperations20Bits.IEventQueue eventQueue;
                private Polygon2I.BooleanOperations20Bits.Context context;
                private RedBlackTree<Polygon2I.BooleanOperations20Bits.Segment> activeSegments;
                private bool ignoreIntraRegionIntersections;

                public SweepLine(
                  Polygon2I.BooleanOperations20Bits.IEventQueue eventQueue,
                  Polygon2I.BooleanOperations20Bits.Context context,
                  bool ignoreIntraRegionIntersections)
                {
                    this.eventQueue = eventQueue;
                    this.context = context;
                    this.activeSegments = new RedBlackTree<Polygon2I.BooleanOperations20Bits.Segment>((IComparer<Polygon2I.BooleanOperations20Bits.Segment>)this.segmentComparer);
                    this.ignoreIntraRegionIntersections = ignoreIntraRegionIntersections;
                }

                public RedBlackTree<Polygon2I.BooleanOperations20Bits.Segment> ActiveSegments
                {
                    get
                    {
                        return this.activeSegments;
                    }
                }

                public void method_0()
                {
                    List<Polygon2I.BooleanOperations20Bits.SNEvent> events = new List<Polygon2I.BooleanOperations20Bits.SNEvent>(this.eventQueue.Count);
                    for (Polygon2I.BooleanOperations20Bits.Event @event = this.eventQueue.imethod_3(); @event != null; @event = this.eventQueue.imethod_3())
                    {
                        Polygon2I.BooleanOperations20Bits.SNEvent snEvent = @event.vmethod_0(this);
                        if (snEvent != null)
                            events.Add(snEvent);
                    }
                    new Polygon2I.BooleanOperations20Bits.SNSweepLine(this.context, events).method_0();
                }

                public void method_1(
                  Point2I eventPosition,
                  Polygon2I.BooleanOperations20Bits.Segment segment)
                {
                    this.segmentComparer.method_0(eventPosition, segment);
                }

                public bool method_2(
                  Polygon2I.BooleanOperations20Bits.Segment lowSegment,
                  Polygon2I.BooleanOperations20Bits.Segment highSegment)
                {
                    if (this.ignoreIntraRegionIntersections)
                    {
                        if (lowSegment.Region == highSegment.Region)
                            return false;
                    }
                    else if (lowSegment.method_3(highSegment))
                        return false;
                    Vector2I orderedDirection1 = lowSegment.OrderedDirection;
                    Vector2I orderedDirection2 = highSegment.OrderedDirection;
                    if (orderedDirection1.X != 0 && orderedDirection2.X != 0 && Vector2I.CrossProduct(orderedDirection1, orderedDirection2) > 0L)
                        return false;
                    bool flag = false;
                    Point2I intersection;
                    int dxSign;
                    int dySign;
                    if (Polygon2I.BooleanOperations20Bits.Segment.smethod_0(lowSegment, highSegment, out intersection, out dxSign, out dySign))
                    {
                        this.eventQueue.imethod_2((Polygon2I.BooleanOperations20Bits.Event)new Polygon2I.BooleanOperations20Bits.Class44(this.context.GetNextEventId(), intersection, dxSign, dySign, lowSegment, highSegment));
                        flag = true;
                    }
                    return flag;
                }

                public bool method_3(
                  Polygon2I.BooleanOperations20Bits.Segment verticalSegment,
                  Polygon2I.BooleanOperations20Bits.Segment highSegment,
                  int x,
                  int minY,
                  int maxY)
                {
                    double intersectionYcoordinate = highSegment.GetIntersectionYCoordinate((double)x);
                    if (intersectionYcoordinate >= (double)maxY)
                        return false;
                    if (this.ignoreIntraRegionIntersections && verticalSegment.Region == highSegment.Region || intersectionYcoordinate <= (double)minY)
                        return true;
                    Point2I position = new Point2I(x, (int)MathUtil.RoundHalfUp(intersectionYcoordinate));
                    this.eventQueue.imethod_2((Polygon2I.BooleanOperations20Bits.Event)new Polygon2I.BooleanOperations20Bits.Class45(this.context.GetNextEventId(), position, 0, System.Math.Sign(intersectionYcoordinate - (double)position.Y), verticalSegment, highSegment));
                    return true;
                }

                private class SegmentComparer : IComparer<Polygon2I.BooleanOperations20Bits.Segment>
                {
                    private long long_0;
                    private Polygon2I.BooleanOperations20Bits.Segment segment_0;
                    private Vector2I vector2I_0;
                    private double double_0;

                    public void method_0(Point2I eventPosition, Polygon2I.BooleanOperations20Bits.Segment a)
                    {
                        this.long_0 = (long)eventPosition.X;
                        this.double_0 = (double)eventPosition.Y;
                        this.segment_0 = a;
                        this.vector2I_0 = a.OrderedDirection;
                    }

                    public int Compare(
                      Polygon2I.BooleanOperations20Bits.Segment a,
                      Polygon2I.BooleanOperations20Bits.Segment b)
                    {
                        double intersectionYcoordinate = b.GetIntersectionYCoordinate((double)this.long_0);
                        if (this.double_0 != intersectionYcoordinate)
                            return System.Math.Sign(this.double_0 - intersectionYcoordinate);
                        int num = this.method_1(this.vector2I_0, b.OrderedDirection);
                        if (num != 0)
                            return num;
                        return MathUtil.Compare(a.Id, b.Id);
                    }

                    private int method_1(Vector2I a, Vector2I b)
                    {
                        long num = Vector2I.CrossProduct(a, b);
                        if (num < 0L)
                            return 1;
                        return num > 0L ? -1 : 0;
                    }
                }
            }

            [Serializable]
            internal abstract class SNEvent
            {
                private Point2I position;

                protected SNEvent(Point2I position)
                {
                    this.position = position;
                }

                public Point2I Position
                {
                    get
                    {
                        return this.position;
                    }
                }

                public virtual int DxSign
                {
                    get
                    {
                        return 0;
                    }
                }

                public virtual void vmethod_0(Polygon2I.BooleanOperations20Bits.SNEdge edge)
                {
                }

                public abstract void vmethod_1(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x);

                public abstract void vmethod_2(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x);

                public abstract void vmethod_3(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x);

                public abstract Polygon2I.BooleanOperations20Bits.Segment vmethod_4(double x);

                public void method_0(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  double x,
                  Polygon2I.BooleanOperations20Bits.SNEdge edge,
                  ref Polygon2I.BooleanOperations20Bits.SNActiveSegment lastConnectedSegment)
                {
                    edge.LowerSegment = (Polygon2I.BooleanOperations20Bits.SNActiveSegment)null;
                    Polygon2I.BooleanOperations20Bits.Segment segment = this.vmethod_4(x);
                    double y = edge.Y;
                    if (segment == null)
                    {
                        LinkedListNode<Polygon2I.BooleanOperations20Bits.SNActiveSegment> linkedListNode1 = lastConnectedSegment == null ? sweepLine.ActiveSegments.First : lastConnectedSegment.Segment.SnActiveSegmentNode.Next;
                        LinkedListNode<Polygon2I.BooleanOperations20Bits.SNActiveSegment> linkedListNode2 = (LinkedListNode<Polygon2I.BooleanOperations20Bits.SNActiveSegment>)null;
                        for (; linkedListNode1 != null && linkedListNode1.Value.Segment.GetIntersectionYCoordinate(x) < y; linkedListNode1 = linkedListNode1.Next)
                            linkedListNode2 = linkedListNode1;
                        if (linkedListNode2 == null)
                            return;
                        linkedListNode2.Value.method_0(edge);
                        lastConnectedSegment = linkedListNode2.Value;
                    }
                    else
                    {
                        LinkedListNode<Polygon2I.BooleanOperations20Bits.SNActiveSegment> activeSegmentNode = segment.SnActiveSegmentNode;
                        double intersectionYcoordinate = activeSegmentNode.Value.Segment.GetIntersectionYCoordinate(x);
                        if (intersectionYcoordinate >= y)
                        {
                            for (LinkedListNode<Polygon2I.BooleanOperations20Bits.SNActiveSegment> previous = activeSegmentNode.Previous; previous != null; previous = previous.Previous)
                            {
                                if (previous.Value.Segment.GetIntersectionYCoordinate(x) < y)
                                {
                                    if (previous.Value.UpperEdge != null)
                                        break;
                                    previous.Value.method_0(edge);
                                    lastConnectedSegment = previous.Value;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (lastConnectedSegment != null && lastConnectedSegment.Segment.GetIntersectionYCoordinate(x) > intersectionYcoordinate)
                                activeSegmentNode = lastConnectedSegment.Segment.SnActiveSegmentNode;
                            LinkedListNode<Polygon2I.BooleanOperations20Bits.SNActiveSegment> linkedListNode = activeSegmentNode;
                            for (LinkedListNode<Polygon2I.BooleanOperations20Bits.SNActiveSegment> next = activeSegmentNode.Next; next != null && next.Value.Segment.GetIntersectionYCoordinate(x) < y; next = next.Next)
                                linkedListNode = next;
                            if (linkedListNode.Value.UpperEdge != null)
                                return;
                            linkedListNode.Value.method_0(edge);
                            lastConnectedSegment = linkedListNode.Value;
                        }
                    }
                }

                internal abstract void vmethod_5(Polygon2I.BooleanOperations20Bits.SNEdge sNEdge);
            }

            [Serializable]
            internal class SNEntryEvent : Polygon2I.BooleanOperations20Bits.SNEvent
            {
                protected Polygon2I.BooleanOperations20Bits.SNEdge topEdge;
                protected Polygon2I.BooleanOperations20Bits.Segment segment;
                protected Polygon2I.BooleanOperations20Bits.Segment previous;

                public SNEntryEvent(
                  Point2I position,
                  Polygon2I.BooleanOperations20Bits.Segment segment,
                  Polygon2I.BooleanOperations20Bits.Segment previous)
                  : base(position)
                {
                    this.segment = segment;
                    this.previous = previous;
                }

                public override void vmethod_0(Polygon2I.BooleanOperations20Bits.SNEdge edge)
                {
                    this.topEdge = edge;
                }

                public override void vmethod_1(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                    throw new Exception();
                }

                public override void vmethod_2(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                    this.segment.SnActiveSegmentNode = this.previous != null ? sweepLine.ActiveSegments.AddAfter(this.previous.SnActiveSegmentNode, new Polygon2I.BooleanOperations20Bits.SNActiveSegment(this.segment)) : sweepLine.ActiveSegments.AddFirst(new Polygon2I.BooleanOperations20Bits.SNActiveSegment(this.segment));
                    if (this.topEdge.LowerSegment == null)
                    {
                        this.segment.SnActiveSegmentNode.Value.method_0(this.topEdge);
                    }
                    else
                    {
                        if (this.previous != this.topEdge.LowerSegment.Segment)
                            return;
                        this.previous.SnActiveSegmentNode.Value.UpperEdge = (Polygon2I.BooleanOperations20Bits.SNEdge)null;
                        this.segment.SnActiveSegmentNode.Value.method_0(this.topEdge);
                    }
                }

                public override void vmethod_3(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                    throw new Exception();
                }

                public override Polygon2I.BooleanOperations20Bits.Segment vmethod_4(double x)
                {
                    if (this.previous != null && this.previous.SnActiveSegmentNode != null)
                        return this.previous;
                    return (Polygon2I.BooleanOperations20Bits.Segment)null;
                }

                internal override void vmethod_5(Polygon2I.BooleanOperations20Bits.SNEdge edge)
                {
                    edge.SourceEntryExitSegment = this.segment;
                }

                public override string ToString()
                {
                    return string.Format("Entry: pos: {0}, segment: {1}", (object)this.Position, (object)this.segment);
                }
            }

            [Serializable]
            internal class SNVerticalEntryEvent : Polygon2I.BooleanOperations20Bits.SNEntryEvent
            {
                public SNVerticalEntryEvent(
                  Point2I position,
                  Polygon2I.BooleanOperations20Bits.Segment segment,
                  Polygon2I.BooleanOperations20Bits.Segment previous)
                  : base(position, segment, previous)
                {
                }

                public override void vmethod_1(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                    throw new Exception();
                }

                public override void vmethod_2(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                    long y = (long)this.segment.Right.Y;
                    Polygon2I.BooleanOperations20Bits.SNActiveSegment snActiveSegment = (Polygon2I.BooleanOperations20Bits.SNActiveSegment)null;
                    for (int index = this.topEdge.IsTop ? this.topEdge.Index + 1 : this.topEdge.Index; index < edgeList.Count; index += 2)
                    {
                        Polygon2I.BooleanOperations20Bits.SNEdge edge = edgeList[index];
                        if (edge.Y >= (double)y)
                            break;
                        if (edge.SourceEntryExitSegment != this.segment)
                        {
                            if (snActiveSegment == null)
                                snActiveSegment = new Polygon2I.BooleanOperations20Bits.SNActiveSegment(this.segment);
                            snActiveSegment.method_1(sweepLine.Context, sweepLine.Context.method_0(edge.ToleranceSquareCenter));
                        }
                    }
                }
            }

            [Serializable]
            internal class SNExitEvent : Polygon2I.BooleanOperations20Bits.SNEvent
            {
                protected Polygon2I.BooleanOperations20Bits.Segment segment;

                public SNExitEvent(Point2I position, Polygon2I.BooleanOperations20Bits.Segment segment)
                  : base(position)
                {
                    this.segment = segment;
                }

                public override void vmethod_1(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                    throw new Exception();
                }

                public override void vmethod_2(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                    Polygon2I.BooleanOperations20Bits.SNEdge upperEdge = this.segment.SnActiveSegmentNode.Value.UpperEdge;
                    if (upperEdge != null)
                    {
                        LinkedListNode<Polygon2I.BooleanOperations20Bits.SNActiveSegment> previous = this.segment.SnActiveSegmentNode.Previous;
                        if (previous == null)
                            upperEdge.LowerSegment = (Polygon2I.BooleanOperations20Bits.SNActiveSegment)null;
                        else if (previous.Value.UpperEdge == null)
                            previous.Value.method_0(upperEdge);
                        else
                            upperEdge.LowerSegment = (Polygon2I.BooleanOperations20Bits.SNActiveSegment)null;
                        this.segment.SnActiveSegmentNode.Value.UpperEdge = (Polygon2I.BooleanOperations20Bits.SNEdge)null;
                    }
                    sweepLine.ActiveSegments.Remove(this.segment.SnActiveSegmentNode);
                    this.segment.SnActiveSegmentNode = (LinkedListNode<Polygon2I.BooleanOperations20Bits.SNActiveSegment>)null;
                }

                public override void vmethod_3(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                    throw new Exception();
                }

                public override Polygon2I.BooleanOperations20Bits.Segment vmethod_4(double x)
                {
                    if (this.segment.SnActiveSegmentNode == null)
                        return (Polygon2I.BooleanOperations20Bits.Segment)null;
                    return this.segment;
                }

                internal override void vmethod_5(Polygon2I.BooleanOperations20Bits.SNEdge edge)
                {
                    edge.SourceEntryExitSegment = this.segment;
                }

                public override string ToString()
                {
                    return string.Format("Exit: pos: {0}, segment: {1}", (object)this.Position, (object)this.segment);
                }
            }

            [Serializable]
            internal class SNVerticalExitEvent : Polygon2I.BooleanOperations20Bits.SNExitEvent
            {
                public SNVerticalExitEvent(
                  Point2I position,
                  Polygon2I.BooleanOperations20Bits.Segment segment)
                  : base(position, segment)
                {
                }

                public override void vmethod_2(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                }
            }

            [Serializable]
            internal class SNIntersectionEvent : Polygon2I.BooleanOperations20Bits.SNEvent
            {
                private Polygon2I.BooleanOperations20Bits.Segment low;
                private Polygon2I.BooleanOperations20Bits.Segment high;
                private int dxSign;

                public SNIntersectionEvent(
                  Point2I position,
                  int dxSign,
                  Polygon2I.BooleanOperations20Bits.Segment low,
                  Polygon2I.BooleanOperations20Bits.Segment high)
                  : base(position)
                {
                    this.low = low;
                    this.high = high;
                    this.dxSign = dxSign;
                }

                public override int DxSign
                {
                    get
                    {
                        return this.dxSign;
                    }
                }

                public override void vmethod_1(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                    this.method_1(sweepLine, edgeList);
                }

                public override void vmethod_2(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                    this.method_1(sweepLine, edgeList);
                }

                public override void vmethod_3(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                    this.method_1(sweepLine, edgeList);
                }

                private void method_1(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList)
                {
                    Polygon2I.BooleanOperations20Bits.Context context = sweepLine.Context;
                    Polygon2I.BooleanOperations20Bits.SNActiveSegment snActiveSegment1 = this.low.SnActiveSegmentNode.Value;
                    if (snActiveSegment1.UpperEdge != null)
                    {
                        int index1 = snActiveSegment1.UpperEdge.Index;
                        int index2 = index1 + 1;
                        if (this.low.SlopeIsPositive)
                        {
                            Polygon2I.BooleanOperations20Bits.SNEdge upperEdge = snActiveSegment1.UpperEdge;
                            if (upperEdge.Y <= (double)this.Position.Y)
                            {
                                snActiveSegment1.UpperEdge = (Polygon2I.BooleanOperations20Bits.SNEdge)null;
                                if (this.low.SnActiveSegmentNode.Previous == null)
                                {
                                    upperEdge.LowerSegment = (Polygon2I.BooleanOperations20Bits.SNActiveSegment)null;
                                }
                                else
                                {
                                    Polygon2I.BooleanOperations20Bits.SNActiveSegment snActiveSegment2 = this.low.SnActiveSegmentNode.Previous.Value;
                                    if (snActiveSegment2.UpperEdge == null)
                                        snActiveSegment2.method_0(upperEdge);
                                    else
                                        upperEdge.LowerSegment = (Polygon2I.BooleanOperations20Bits.SNActiveSegment)null;
                                }
                                if (upperEdge.IsBottom)
                                    snActiveSegment1.method_1(context, context.method_0(upperEdge.ToleranceSquareCenter));
                                for (; index2 < edgeList.Count; ++index2)
                                {
                                    Polygon2I.BooleanOperations20Bits.SNEdge edge = edgeList[index2];
                                    if (edge.Y <= (double)this.Position.Y && edge.LowerSegment == null)
                                    {
                                        if (edge.SourceEntryExitSegment != snActiveSegment1.Segment && edge.IsBottom)
                                            snActiveSegment1.method_1(context, context.method_0(edge.ToleranceSquareCenter));
                                    }
                                    else
                                        break;
                                }
                            }
                        }
                        Polygon2I.BooleanOperations20Bits.SNActiveSegment snActiveSegment3 = this.high.SnActiveSegmentNode.Value;
                        if (this.high.SlopeIsNegative)
                        {
                            Polygon2I.BooleanOperations20Bits.SNEdge upperEdge = snActiveSegment3.UpperEdge;
                            snActiveSegment3.method_0((Polygon2I.BooleanOperations20Bits.SNEdge)null);
                            int index3;
                            if (upperEdge == null)
                            {
                                while (index2 < edgeList.Count && edgeList[index2].LowerSegment == null)
                                    ++index2;
                                index3 = index2 - 1;
                            }
                            else
                                index3 = upperEdge.Index - 1;
                            for (; index3 >= index1; --index3)
                            {
                                upperEdge = edgeList[index3];
                                if (upperEdge.Y >= (double)this.Position.Y)
                                {
                                    if (upperEdge.SourceEntryExitSegment != snActiveSegment3.Segment && upperEdge.IsTop)
                                        snActiveSegment3.method_1(context, context.method_0(upperEdge.ToleranceSquareCenter));
                                }
                                else
                                    break;
                            }
                            if (index3 < index1)
                                index3 = index1;
                            while (index3 < edgeList.Count && (upperEdge = edgeList[index3]).Y <= (double)this.Position.Y)
                                ++index3;
                            if (upperEdge.Y > (double)this.Position.Y)
                            {
                                if (snActiveSegment1.UpperEdge != upperEdge)
                                    snActiveSegment1.method_0(upperEdge);
                            }
                            else
                                snActiveSegment1.method_0((Polygon2I.BooleanOperations20Bits.SNEdge)null);
                        }
                        else if (snActiveSegment3.UpperEdge == null)
                        {
                            snActiveSegment1.UpperEdge = (Polygon2I.BooleanOperations20Bits.SNEdge)null;
                        }
                        else
                        {
                            snActiveSegment1.method_0(snActiveSegment3.UpperEdge);
                            this.high.SnActiveSegmentNode.Value.UpperEdge = (Polygon2I.BooleanOperations20Bits.SNEdge)null;
                        }
                    }
                    else if (this.high.SnActiveSegmentNode.Value.UpperEdge != null)
                    {
                        snActiveSegment1.method_0(this.high.SnActiveSegmentNode.Value.UpperEdge);
                        this.high.SnActiveSegmentNode.Value.UpperEdge = (Polygon2I.BooleanOperations20Bits.SNEdge)null;
                    }
                    sweepLine.ActiveSegments.Remove(this.low.SnActiveSegmentNode);
                    this.low.SnActiveSegmentNode = sweepLine.ActiveSegments.AddAfter(this.high.SnActiveSegmentNode, snActiveSegment1);
                }

                public override Polygon2I.BooleanOperations20Bits.Segment vmethod_4(double x)
                {
                    Polygon2I.BooleanOperations20Bits.Segment segment = (double)this.Position.X <= x ? this.high : this.low;
                    if (segment.SnActiveSegmentNode == null)
                        segment = (Polygon2I.BooleanOperations20Bits.Segment)null;
                    return segment;
                }

                internal override void vmethod_5(Polygon2I.BooleanOperations20Bits.SNEdge edge)
                {
                    edge.SourceEntryExitSegment = (Polygon2I.BooleanOperations20Bits.Segment)null;
                }

                public override string ToString()
                {
                    return string.Format("Intersection: pos: {0}, low: {1}, high: {2}", (object)this.Position, (object)this.low, (object)this.high);
                }
            }

            [Serializable]
            internal class SNVerticalIntersectionEvent : Polygon2I.BooleanOperations20Bits.SNEvent
            {
                private Polygon2I.BooleanOperations20Bits.Segment verticalSegment;
                private Polygon2I.BooleanOperations20Bits.Segment otherSegment;

                public SNVerticalIntersectionEvent(
                  Point2I position,
                  Polygon2I.BooleanOperations20Bits.Segment verticalSegment,
                  Polygon2I.BooleanOperations20Bits.Segment otherSegment)
                  : base(position)
                {
                    this.verticalSegment = verticalSegment;
                    this.otherSegment = otherSegment;
                }

                public override void vmethod_1(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                    throw new Exception();
                }

                public override void vmethod_2(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                }

                public override void vmethod_3(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                    throw new Exception();
                }

                public override Polygon2I.BooleanOperations20Bits.Segment vmethod_4(double x)
                {
                    Polygon2I.BooleanOperations20Bits.Segment segment = this.otherSegment;
                    if (segment.SnActiveSegmentNode == null)
                        segment = (Polygon2I.BooleanOperations20Bits.Segment)null;
                    return segment;
                }

                internal override void vmethod_5(Polygon2I.BooleanOperations20Bits.SNEdge edge)
                {
                    edge.SourceEntryExitSegment = (Polygon2I.BooleanOperations20Bits.Segment)null;
                }

                public override string ToString()
                {
                    return string.Format("Intersection: pos: {0}, vertical: {1}, other: {2}", (object)this.Position, (object)this.verticalSegment, (object)this.otherSegment);
                }
            }

            [Serializable]
            internal class SNSingleSegmentIntersectionEvent : Polygon2I.BooleanOperations20Bits.SNEvent
            {
                private Polygon2I.BooleanOperations20Bits.Segment low;

                public SNSingleSegmentIntersectionEvent(
                  Point2I position,
                  Polygon2I.BooleanOperations20Bits.Segment low)
                  : base(position)
                {
                    this.low = low;
                }

                public override void vmethod_1(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                }

                public override void vmethod_2(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                }

                public override void vmethod_3(
                  Polygon2I.BooleanOperations20Bits.SNSweepLine sweepLine,
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  int x)
                {
                }

                public override Polygon2I.BooleanOperations20Bits.Segment vmethod_4(double x)
                {
                    Polygon2I.BooleanOperations20Bits.Segment segment = this.low;
                    if (segment.SnActiveSegmentNode == null)
                        segment = (Polygon2I.BooleanOperations20Bits.Segment)null;
                    return segment;
                }

                internal override void vmethod_5(Polygon2I.BooleanOperations20Bits.SNEdge edge)
                {
                    edge.SourceEntryExitSegment = (Polygon2I.BooleanOperations20Bits.Segment)null;
                }

                public override string ToString()
                {
                    return string.Format("SingleSegmentIntersection: pos: {0}, low: {1}", (object)this.Position, (object)this.low);
                }
            }

            [Serializable]
            internal class SNActiveSegment
            {
                private Polygon2I.BooleanOperations20Bits.Segment segment;
                private Polygon2I.BooleanOperations20Bits.Segment remainderSubSegment;
                public Polygon2I.BooleanOperations20Bits.SNEdge UpperEdge;

                public SNActiveSegment(Polygon2I.BooleanOperations20Bits.Segment segment)
                {
                    this.segment = segment;
                }

                public Polygon2I.BooleanOperations20Bits.Segment Segment
                {
                    get
                    {
                        return this.segment;
                    }
                    set
                    {
                        this.segment = value;
                    }
                }

                public Polygon2I.BooleanOperations20Bits.Segment RemainderSubSegment
                {
                    get
                    {
                        if (this.remainderSubSegment == null)
                            this.remainderSubSegment = this.segment;
                        return this.remainderSubSegment;
                    }
                }

                public void method_0(Polygon2I.BooleanOperations20Bits.SNEdge upperEdge)
                {
                    if (this.UpperEdge != null)
                        this.UpperEdge.LowerSegment = (Polygon2I.BooleanOperations20Bits.SNActiveSegment)null;
                    this.UpperEdge = upperEdge;
                    if (this.UpperEdge == null)
                        return;
                    this.UpperEdge.LowerSegment = this;
                }

                public void method_1(
                  Polygon2I.BooleanOperations20Bits.Context context,
                  Polygon2I.BooleanOperations20Bits.Point intersection)
                {
                    if (this.remainderSubSegment == null)
                        this.remainderSubSegment = this.segment;
                    if (intersection == this.remainderSubSegment.Start || intersection == this.remainderSubSegment.End)
                        return;
                    Polygon2I.BooleanOperations20Bits.Polygon polygon = this.remainderSubSegment.Polygon;
                    if (this.remainderSubSegment == this.segment)
                    {
                        this.remainderSubSegment = new Polygon2I.BooleanOperations20Bits.Segment(context, this.segment.Start, this.segment.End);
                        this.remainderSubSegment.PolygonSegmentNode = polygon.AddAfter(this.segment.PolygonSegmentNode, this.remainderSubSegment);
                        polygon.Remove(this.segment.PolygonSegmentNode);
                    }
                    Polygon2I.BooleanOperations20Bits.Segment segment = new Polygon2I.BooleanOperations20Bits.Segment(context, intersection, this.remainderSubSegment.End);
                    segment.PolygonSegmentNode = polygon.AddAfter(this.remainderSubSegment.PolygonSegmentNode, segment);
                    this.remainderSubSegment.End = intersection;
                    this.remainderSubSegment.Direction = this.remainderSubSegment.End.Position - this.remainderSubSegment.Start.Position;
                    this.remainderSubSegment = this.segment.IsForward ? segment : this.remainderSubSegment;
                }

                public override string ToString()
                {
                    return this.segment.ToString();
                }
            }

            [Serializable]
            internal abstract class SNEdge : IComparable<Polygon2I.BooleanOperations20Bits.SNEdge>
            {
                private int index = -1;
                private Polygon2I.BooleanOperations20Bits.SNEvent sourceEvent;
                public Polygon2I.BooleanOperations20Bits.Segment SourceEntryExitSegment;
                private double y;
                public Polygon2I.BooleanOperations20Bits.SNActiveSegment LowerSegment;

                protected SNEdge()
                {
                }

                public SNEdge(
                  Polygon2I.BooleanOperations20Bits.SNEvent sourceEvent,
                  double y)
                {
                    this.sourceEvent = sourceEvent;
                    this.y = y;
                }

                public void method_0(
                  Polygon2I.BooleanOperations20Bits.SNEvent sourceEvent,
                  double y)
                {
                    this.sourceEvent = sourceEvent;
                    this.y = y;
                    this.LowerSegment = (Polygon2I.BooleanOperations20Bits.SNActiveSegment)null;
                    sourceEvent.vmethod_5(this);
                }

                public Polygon2I.BooleanOperations20Bits.SNEvent SourceEvent
                {
                    get
                    {
                        return this.sourceEvent;
                    }
                }

                public int Index
                {
                    get
                    {
                        return this.index;
                    }
                    set
                    {
                        this.index = value;
                    }
                }

                public double Y
                {
                    get
                    {
                        return this.y;
                    }
                }

                public Point2I ToleranceSquareCenter
                {
                    get
                    {
                        return this.sourceEvent.Position;
                    }
                }

                public abstract bool IsTop { get; }

                public abstract bool IsBottom { get; }

                public int CompareTo(Polygon2I.BooleanOperations20Bits.SNEdge other)
                {
                    return this.y >= other.y ? (this.y <= other.y ? 0 : 1) : -1;
                }

                public override string ToString()
                {
                    return string.Format("y: {0}, lowerSegment: {1}", (object)this.y, (object)this.LowerSegment);
                }
            }

            [Serializable]
            internal class SNTopEdge : Polygon2I.BooleanOperations20Bits.SNEdge
            {
                public SNTopEdge()
                {
                }

                public SNTopEdge(
                  Polygon2I.BooleanOperations20Bits.SNEvent sourceEvent,
                  double y)
                  : base(sourceEvent, y)
                {
                }

                public override bool IsTop
                {
                    get
                    {
                        return true;
                    }
                }

                public override bool IsBottom
                {
                    get
                    {
                        return false;
                    }
                }
            }

            [Serializable]
            internal class SNBottomEdge : Polygon2I.BooleanOperations20Bits.SNEdge
            {
                public SNBottomEdge()
                {
                }

                public SNBottomEdge(
                  Polygon2I.BooleanOperations20Bits.SNEvent sourceEvent,
                  double y)
                  : base(sourceEvent, y)
                {
                }

                public override bool IsTop
                {
                    get
                    {
                        return false;
                    }
                }

                public override bool IsBottom
                {
                    get
                    {
                        return true;
                    }
                }
            }

            [Serializable]
            internal class SNSweepLine
            {
                private LinkedList<Polygon2I.BooleanOperations20Bits.SNActiveSegment> activeSegments = new LinkedList<Polygon2I.BooleanOperations20Bits.SNActiveSegment>();
                private SortedDictionary<int, Polygon2I.BooleanOperations20Bits.SNTopEdge> topEdgeSet = new SortedDictionary<int, Polygon2I.BooleanOperations20Bits.SNTopEdge>();
                private List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList = new List<Polygon2I.BooleanOperations20Bits.SNEdge>();
                private List<Polygon2I.BooleanOperations20Bits.SNTopEdge> topEdgePool = new List<Polygon2I.BooleanOperations20Bits.SNTopEdge>();
                private List<Polygon2I.BooleanOperations20Bits.SNBottomEdge> bottomEdgePool = new List<Polygon2I.BooleanOperations20Bits.SNBottomEdge>();
                private List<Polygon2I.BooleanOperations20Bits.SNEvent> events;
                private Polygon2I.BooleanOperations20Bits.Context context;
                private double sweepLineRoundedPosition;
                private double sweepLinePosition;

                public SNSweepLine(
                  Polygon2I.BooleanOperations20Bits.Context context,
                  List<Polygon2I.BooleanOperations20Bits.SNEvent> events)
                {
                    this.context = context;
                    this.events = events;
                }

                public LinkedList<Polygon2I.BooleanOperations20Bits.SNActiveSegment> ActiveSegments
                {
                    get
                    {
                        return this.activeSegments;
                    }
                }

                public Polygon2I.BooleanOperations20Bits.Context Context
                {
                    get
                    {
                        return this.context;
                    }
                }

                public double SweepLineRoundedPosition
                {
                    get
                    {
                        return this.sweepLineRoundedPosition;
                    }
                    set
                    {
                        this.sweepLineRoundedPosition = value;
                    }
                }

                public double SweepLinePosition
                {
                    get
                    {
                        return this.sweepLinePosition;
                    }
                    set
                    {
                        this.sweepLinePosition = value;
                    }
                }

                public void method_0()
                {
                    if (this.events.Count == 0)
                        return;
                    int x = this.events[0].Position.X;
                    List<Polygon2I.BooleanOperations20Bits.SNEvent> eventBatch = new List<Polygon2I.BooleanOperations20Bits.SNEvent>();
                    eventBatch.Add(this.events[0]);
                    for (int index = 1; index < this.events.Count; ++index)
                    {
                        Polygon2I.BooleanOperations20Bits.SNEvent snEvent = this.events[index];
                        if (snEvent.Position.X > x)
                        {
                            this.method_1(x, eventBatch);
                            eventBatch.Clear();
                            x = snEvent.Position.X;
                        }
                        eventBatch.Add(snEvent);
                    }
                    if (eventBatch.Count <= 0)
                        return;
                    this.method_1(x, eventBatch);
                }

                private void method_1(
                  int xBatch,
                  List<Polygon2I.BooleanOperations20Bits.SNEvent> eventBatch)
                {
                    this.sweepLineRoundedPosition = (double)xBatch;
                    this.sweepLinePosition = (double)xBatch - 0.5;
                    List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList = this.method_2((long)xBatch, eventBatch);
                    int num = xBatch;
                    this.sweepLinePosition = (double)num;
                    int index;
                    for (index = 0; index < eventBatch.Count; ++index)
                    {
                        Polygon2I.BooleanOperations20Bits.SNEvent snEvent = eventBatch[index];
                        if (snEvent.DxSign < 0)
                            snEvent.vmethod_1(this, edgeList, xBatch);
                        else
                            break;
                    }
                    this.method_4(edgeList, (double)num, true);
                    double x = (double)xBatch + 0.5;
                    this.sweepLinePosition = x;
                    for (; index < eventBatch.Count; ++index)
                    {
                        Polygon2I.BooleanOperations20Bits.SNEvent snEvent = eventBatch[index];
                        if (snEvent.DxSign <= 0)
                            snEvent.vmethod_2(this, edgeList, xBatch);
                        else
                            break;
                    }
                    for (; index < eventBatch.Count; ++index)
                        eventBatch[index].vmethod_3(this, edgeList, xBatch);
                    this.method_4(edgeList, x, false);
                }

                private List<Polygon2I.BooleanOperations20Bits.SNEdge> method_2(
                  long xBatch,
                  List<Polygon2I.BooleanOperations20Bits.SNEvent> eventBatch)
                {
                    this.topEdgeSet.Clear();
                    int num1 = 0;
                    foreach (Polygon2I.BooleanOperations20Bits.SNEvent sourceEvent in eventBatch)
                    {
                        int y = sourceEvent.Position.Y;
                        Polygon2I.BooleanOperations20Bits.SNTopEdge snTopEdge;
                        if (!this.topEdgeSet.TryGetValue(y, out snTopEdge))
                        {
                            if (num1 >= this.topEdgePool.Count)
                                this.method_3();
                            snTopEdge = this.topEdgePool[num1++];
                            snTopEdge.method_0(sourceEvent, (double)y + 0.5);
                            this.topEdgeSet.Add(y, snTopEdge);
                        }
                        sourceEvent.vmethod_0((Polygon2I.BooleanOperations20Bits.SNEdge)snTopEdge);
                    }
                    this.edgeList.Clear();
                    int index1 = 0;
                    int num2 = 0;
                    foreach (KeyValuePair<int, Polygon2I.BooleanOperations20Bits.SNTopEdge> topEdge in this.topEdgeSet)
                    {
                        Polygon2I.BooleanOperations20Bits.SNTopEdge snTopEdge1 = topEdge.Value;
                        Polygon2I.BooleanOperations20Bits.SNBottomEdge snBottomEdge1 = this.bottomEdgePool[index1];
                        snBottomEdge1.method_0(snTopEdge1.SourceEvent, snTopEdge1.Y - 1.0);
                        Polygon2I.BooleanOperations20Bits.SNBottomEdge snBottomEdge2 = snBottomEdge1;
                        int num3 = num2;
                        int num4 = num3 + 1;
                        snBottomEdge2.Index = num3;
                        this.edgeList.Add((Polygon2I.BooleanOperations20Bits.SNEdge)snBottomEdge1);
                        Polygon2I.BooleanOperations20Bits.SNTopEdge snTopEdge2 = snTopEdge1;
                        int num5 = num4;
                        num2 = num5 + 1;
                        snTopEdge2.Index = num5;
                        this.edgeList.Add((Polygon2I.BooleanOperations20Bits.SNEdge)snTopEdge1);
                        ++index1;
                    }
                    double x = (double)xBatch - 0.5;
                    this.method_5(this.edgeList, x);
                    for (int index2 = 1; index2 < this.edgeList.Count; index2 += 2)
                    {
                        Polygon2I.BooleanOperations20Bits.SNEdge edge = this.edgeList[index2];
                        Polygon2I.BooleanOperations20Bits.Point intersection = (Polygon2I.BooleanOperations20Bits.Point)null;
                        if (edge.LowerSegment != null)
                        {
                            LinkedListNode<Polygon2I.BooleanOperations20Bits.SNActiveSegment> linkedListNode = edge.LowerSegment.Segment.SnActiveSegmentNode;
                            for (double num3 = edge.Y - 1.0; linkedListNode != null && linkedListNode.Value.Segment.GetIntersectionYCoordinate(x) >= num3; linkedListNode = linkedListNode.Previous)
                            {
                                if (edge.SourceEntryExitSegment != linkedListNode.Value.Segment)
                                {
                                    if (intersection == null)
                                        intersection = this.context.method_0(edge.ToleranceSquareCenter);
                                    linkedListNode.Value.method_1(this.context, intersection);
                                }
                            }
                        }
                    }
                    return this.edgeList;
                }

                private void method_3()
                {
                    int num = this.topEdgePool.Count * 2;
                    if (num == 0)
                        num = 20;
                    this.topEdgePool.Clear();
                    this.topEdgePool.Capacity = num;
                    this.bottomEdgePool.Clear();
                    this.bottomEdgePool.Capacity = num;
                    for (int index = 0; index < num; ++index)
                    {
                        this.topEdgePool.Add(new Polygon2I.BooleanOperations20Bits.SNTopEdge());
                        this.bottomEdgePool.Add(new Polygon2I.BooleanOperations20Bits.SNBottomEdge());
                    }
                }

                private void method_4(
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList,
                  double x,
                  bool updateSegmentToEdgeReferences)
                {
                    if (this.activeSegments.Count == 0)
                        return;
                    Polygon2I.BooleanOperations20Bits.SNSweepLine.smethod_0(edgeList);
                    Polygon2I.BooleanOperations20Bits.SNActiveSegment snActiveSegment1 = (Polygon2I.BooleanOperations20Bits.SNActiveSegment)null;
                    LinkedListNode<Polygon2I.BooleanOperations20Bits.SNActiveSegment> previous;
                    for (int index = 0; index < edgeList.Count; ++index)
                    {
                        for (Polygon2I.BooleanOperations20Bits.SNEdge edge1 = edgeList[index]; edge1.LowerSegment != null; edge1.LowerSegment = previous.Value)
                        {
                            if (edge1.LowerSegment.Segment.SlopeIsPositive)
                            {
                                if (edge1.LowerSegment.Segment.GetIntersectionYCoordinate(x) >= edge1.Y)
                                {
                                    if (edge1.SourceEntryExitSegment != edge1.LowerSegment.Segment && edge1.IsBottom)
                                        edge1.LowerSegment.method_1(this.context, this.context.method_0(edge1.ToleranceSquareCenter));
                                    if (edge1.Index < edgeList.Count - 1)
                                    {
                                        Polygon2I.BooleanOperations20Bits.SNEdge edge2 = edgeList[edge1.Index + 1];
                                        if (edge2.LowerSegment == null)
                                            edge2.LowerSegment = edge1.LowerSegment;
                                    }
                                    previous = edge1.LowerSegment.Segment.SnActiveSegmentNode.Previous;
                                    if (previous == null || previous.Value == snActiveSegment1)
                                    {
                                        edge1.LowerSegment = (Polygon2I.BooleanOperations20Bits.SNActiveSegment)null;
                                        break;
                                    }
                                }
                                else
                                {
                                    snActiveSegment1 = edge1.LowerSegment;
                                    break;
                                }
                            }
                            else
                            {
                                snActiveSegment1 = edge1.LowerSegment;
                                break;
                            }
                        }
                    }
                    Polygon2I.BooleanOperations20Bits.SNActiveSegment snActiveSegment2 = (Polygon2I.BooleanOperations20Bits.SNActiveSegment)null;
                    int index1 = edgeList.Count - 1;
                    for (int index2 = index1; index2 >= 0; --index2)
                    {
                        Polygon2I.BooleanOperations20Bits.SNEdge snEdge;
                        for (snEdge = edgeList[index2]; snEdge.LowerSegment == null; snEdge = edgeList[index2])
                        {
                            if (index2 != 0)
                            {
                                --index2;
                            }
                            else
                            {
                                snEdge = (Polygon2I.BooleanOperations20Bits.SNEdge)null;
                                break;
                            }
                        }
                        LinkedListNode<Polygon2I.BooleanOperations20Bits.SNActiveSegment> linkedListNode1 = snEdge == null ? this.activeSegments.First : snEdge.LowerSegment.Segment.SnActiveSegmentNode.Next;
                        for (; index1 >= index2; --index1)
                        {
                            Polygon2I.BooleanOperations20Bits.SNEdge edge1 = edgeList[index1];
                            for (LinkedListNode<Polygon2I.BooleanOperations20Bits.SNActiveSegment> linkedListNode2 = linkedListNode1; linkedListNode2 != null && linkedListNode2.Value != snActiveSegment2; linkedListNode2 = linkedListNode2.Next)
                            {
                                if (linkedListNode2.Value.Segment.SlopeIsNegative)
                                {
                                    if (linkedListNode2.Value.Segment.GetIntersectionYCoordinate(x) < edge1.Y)
                                    {
                                        if (edge1.SourceEntryExitSegment != linkedListNode2.Value.Segment && edge1.IsTop)
                                            linkedListNode2.Value.method_1(this.context, this.context.method_0(edge1.ToleranceSquareCenter));
                                        if (edge1.Index < edgeList.Count - 1)
                                        {
                                            Polygon2I.BooleanOperations20Bits.SNEdge edge2 = edgeList[edge1.Index + 1];
                                            if (edge2.LowerSegment == linkedListNode2.Value)
                                                edge2.LowerSegment = (Polygon2I.BooleanOperations20Bits.SNActiveSegment)null;
                                        }
                                        edge1.LowerSegment = linkedListNode2.Value;
                                    }
                                    else
                                    {
                                        snActiveSegment2 = linkedListNode2.Value;
                                        break;
                                    }
                                }
                                else
                                {
                                    snActiveSegment2 = linkedListNode2.Value;
                                    break;
                                }
                            }
                        }
                    }
                    if (!updateSegmentToEdgeReferences)
                        return;
                    for (int index2 = edgeList.Count - 1; index2 >= 0; --index2)
                    {
                        Polygon2I.BooleanOperations20Bits.SNEdge edge = edgeList[index2];
                        if (edge.LowerSegment != null)
                            edge.LowerSegment.UpperEdge = edge;
                    }
                }

                private static void smethod_0(
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList)
                {
                    for (int index = edgeList.Count - 1; index >= 0; --index)
                    {
                        Polygon2I.BooleanOperations20Bits.SNEdge edge = edgeList[index];
                        if (edge.LowerSegment != null)
                            edge.LowerSegment.UpperEdge = (Polygon2I.BooleanOperations20Bits.SNEdge)null;
                    }
                }

                private void method_5(
                  List<Polygon2I.BooleanOperations20Bits.SNEdge> edges,
                  double x)
                {
                    Polygon2I.BooleanOperations20Bits.SNEdge snEdge = (Polygon2I.BooleanOperations20Bits.SNEdge)null;
                    Polygon2I.BooleanOperations20Bits.SNActiveSegment lastConnectedSegment = (Polygon2I.BooleanOperations20Bits.SNActiveSegment)null;
                    int count = edges.Count;
                    for (int index = 0; index < count; ++index)
                    {
                        Polygon2I.BooleanOperations20Bits.SNEdge edge = edges[index];
                        if (snEdge == null || edge.Y != snEdge.Y)
                        {
                            edge.SourceEvent.method_0(this, x, edge, ref lastConnectedSegment);
                            snEdge = edge;
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
            internal class Intersection : IComparable<Polygon2I.BooleanOperations20Bits.Intersection>
            {
                private LongRational parameter;
                private Polygon2I.BooleanOperations20Bits.Point point;

                public Intersection(LongRational parameter, Polygon2I.BooleanOperations20Bits.Point point)
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

                public Polygon2I.BooleanOperations20Bits.Point Point
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

                public int CompareTo(
                  Polygon2I.BooleanOperations20Bits.Intersection other)
                {
                    if (this.parameter < other.parameter)
                        return -1;
                    return this.parameter > other.parameter ? 1 : 0;
                }
            }

            [Serializable]
            public class Context
            {
                private Dictionary<Point2I, Polygon2I.BooleanOperations20Bits.Point> pointDictionary = new Dictionary<Point2I, Polygon2I.BooleanOperations20Bits.Point>();
                private int currentSegmentId = 1;
                private int currentEventId = 1;

                internal Polygon2I.BooleanOperations20Bits.Point method_0(Point2I p)
                {
                    Polygon2I.BooleanOperations20Bits.Point point;
                    if (!this.pointDictionary.TryGetValue(p, out point))
                    {
                        point = new Polygon2I.BooleanOperations20Bits.Point(p);
                        this.pointDictionary.Add(p, point);
                    }
                    return point;
                }

                public int GetNextSegmentId()
                {
                    return this.currentSegmentId++;
                }

                public int GetNextEventId()
                {
                    return this.currentEventId++;
                }

                public void Reset()
                {
                    this.pointDictionary.Clear();
                    this.currentSegmentId = 1;
                    this.currentEventId = 1;
                }
            }

            [Serializable]
            internal class DebugInfo
            {
                private Polygon2I.BooleanOperations20Bits.Region region1;
                private Polygon2I.BooleanOperations20Bits.Region region2;
                private Polygon2I.BooleanOperations20Bits.Region resultRegion;
                private List<Polygon2I.BooleanOperations20Bits.Segment> segments;
                private Polygon2I.BooleanOperations20Bits.Segment highlightSegment;
                private Polygon2I.BooleanOperations20Bits.SNSweepLine snSweepLine;
                private List<Polygon2I.BooleanOperations20Bits.SNEdge> edgeList;

                public Polygon2I.BooleanOperations20Bits.Region Region1
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

                public Polygon2I.BooleanOperations20Bits.Region Region2
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

                public Polygon2I.BooleanOperations20Bits.Region ResultRegion
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

                public List<Polygon2I.BooleanOperations20Bits.Segment> Segments
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

                public Polygon2I.BooleanOperations20Bits.Segment HighlightSegment
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

                public Polygon2I.BooleanOperations20Bits.SNSweepLine SnSweepLine
                {
                    get
                    {
                        return this.snSweepLine;
                    }
                    set
                    {
                        this.snSweepLine = value;
                    }
                }

                public List<Polygon2I.BooleanOperations20Bits.SNEdge> EdgeList
                {
                    get
                    {
                        return this.edgeList;
                    }
                    set
                    {
                        this.edgeList = value;
                    }
                }
            }
        }
    }
}
