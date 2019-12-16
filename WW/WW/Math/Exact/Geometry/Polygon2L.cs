// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.Polygon2L
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WW.Collections.Generic;
using WW.Math.Geometry;

namespace WW.Math.Exact.Geometry
{
    [Serializable]
    public class Polygon2L : List<Point2L>
    {
        public Polygon2L()
        {
        }

        public Polygon2L(int capacity)
          : base(capacity)
        {
        }

        public Polygon2L(params Point2L[] points)
          : base((IEnumerable<Point2L>)points)
        {
        }

        public Polygon2L(IEnumerable<Point2L> points)
          : base(points)
        {
        }

        public Polygon2L(Polygon2L polyline)
          : base((IEnumerable<Point2L>)polyline)
        {
        }

        public Polygon2L(Matrix4D transform, ICollection<Point2D> points)
          : this(points.Count)
        {
            foreach (Point2D point in (IEnumerable<Point2D>)points)
            {
                Point2D point2D = transform.Transform(point);
                this.Add(new Point2L((long)(int)System.Math.Floor(point2D.X), (long)(int)System.Math.Floor(point2D.Y)));
            }
        }

        public bool IsConvex()
        {
            int count = this.Count;
            if (count <= 3)
                return true;
            long num1 = 0;
            Point2L point2L1 = this[count - 2];
            Point2L point2L2 = this[count - 1];
            Vector2L u = point2L2 - point2L1;
            for (int index = 0; index < count; ++index)
            {
                Point2L point2L3 = this[index];
                Vector2L v = point2L3 - point2L2;
                long num2 = Vector2L.CrossProduct(u, v);
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
                point2L2 = point2L3;
            }
            return true;
        }

        public bool IsInside(Point2L p)
        {
            return (Polygon2L.GetWindingNumber(p.X, p.Y, (IList<Point2L>)this) & 1) == 1;
        }

        public bool IsClockwise()
        {
            return Polygon2L.IsClockwise((IList<Point2L>)this);
        }

        public Polygon2L GetReverse()
        {
            Polygon2L polygon2L = new Polygon2L(this.Count);
            for (int index = this.Count - 1; index >= 0; --index)
                polygon2L.Add(this[index]);
            return polygon2L;
        }

        public static Polygon2L Create(IList<Point2D> polygon, Matrix3D transform)
        {
            Polygon2L polygon2L = new Polygon2L(polygon.Count);
            for (int index = 0; index < polygon.Count; ++index)
                polygon2L.Add(new Point2L(transform.Transform(polygon[index])));
            return polygon2L;
        }

        public Polygon2D ToPolygon2D()
        {
            Polygon2D polygon2D = new Polygon2D(this.Count);
            foreach (Point2L point2L in (List<Point2L>)this)
                polygon2D.Add(new Point2D((double)point2L.X, (double)point2L.Y));
            return polygon2D;
        }

        public Polygon2D ToPolygon2D(Matrix3D transform)
        {
            Polygon2D polygon2D = new Polygon2D(this.Count);
            foreach (Point2L point2L in (List<Point2L>)this)
                polygon2D.Add(transform.Transform(new Point2D((double)point2L.X, (double)point2L.Y)));
            return polygon2D;
        }

        public bool HasSegments
        {
            get
            {
                return this.Count > 0;
            }
        }

        public static bool IsInside(Point2L p, IList<Point2L> polygon)
        {
            return (Polygon2L.GetWindingNumber(p.X, p.Y, polygon) & 1) == 1;
        }

        public static bool IsInsidePolygons(Point2L p, IEnumerator polygonsEnumerator)
        {
            if (polygonsEnumerator == null)
                return false;
            int num = 0;
            polygonsEnumerator.Reset();
            while (polygonsEnumerator.MoveNext())
                num += Polygon2L.GetWindingNumber(p.X, p.Y, (IList<Point2L>)polygonsEnumerator.Current);
            return (num & 1) == 1;
        }

        public static bool IsInside(Point2L p, IEnumerable<IList<Point2L>> polygons)
        {
            return Polygon2L.IsInsidePolygons(p, (IEnumerator)polygons.GetEnumerator());
        }

        public static int GetWindingNumber(Point2L p, IList<Point2L> polygon)
        {
            return Polygon2L.GetWindingNumber(p.X, p.Y, polygon);
        }

        public static int GetWindingNumber(long x, long y, IList<Point2L> polygon)
        {
            int num = 0;
            int count = polygon.Count;
            if (count > 0)
            {
                Point2L point2L1 = polygon[count - 1];
                for (int index = 0; index < count; ++index)
                {
                    Point2L point2L2 = polygon[index];
                    if (point2L1.Y <= y)
                    {
                        if (point2L2.Y > y && Polygon2L.smethod_4(point2L1.X, point2L1.Y, point2L2.X, point2L2.Y, x, y) > 0L)
                            ++num;
                    }
                    else if (point2L2.Y <= y && Polygon2L.smethod_4(point2L1.X, point2L1.Y, point2L2.X, point2L2.Y, x, y) < 0L)
                        --num;
                    point2L1 = point2L2;
                }
            }
            return num;
        }

        public static bool IsClockwise(IList<Point2L> polygon)
        {
            return Polygon2L.smethod_0(polygon) < 0L;
        }

        private static long smethod_0(IList<Point2L> polygon)
        {
            int count = polygon.Count;
            if (count < 3)
                return 0;
            long num = 0;
            Point2L point2L1 = polygon[count - 1];
            for (int index = 0; index < count; ++index)
            {
                Point2L point2L2 = polygon[index];
                num += point2L1.X * point2L2.Y - point2L2.X * point2L1.Y;
                point2L1 = point2L2;
            }
            return num;
        }

        public static bool IsClockwise(Point2L p0, Point2L p1, Point2L p2, Point2L p3)
        {
            return Polygon2L.smethod_1(p0, p1, p2, p3) < 0L;
        }

        private static long smethod_1(Point2L p0, Point2L p1, Point2L p2, Point2L p3)
        {
            return 0L + (p0.X * p1.Y - p1.X * p0.Y) + (p1.X * p2.Y - p2.X * p1.Y) + (p2.X * p3.Y - p3.X * p2.Y) + (p3.X * p0.Y - p0.X * p3.Y);
        }

        public static void GetSegments(IList<Point2L> polygon, IList<Segment2L> segments)
        {
            int count = polygon.Count;
            Point2L start = polygon[count - 1];
            for (int index = 0; index < count; ++index)
            {
                Point2L end = polygon[index];
                Segment2L segment2L = new Segment2L(start, end);
                segments.Add(segment2L);
                start = end;
            }
        }

        public Polygon2L GetConvexHull()
        {
            return Polygon2L.GetConvexHull((IList<Point2L>)this);
        }

        public static Polygon2L GetConvexHull(IList<Point2L> polygon)
        {
            LinkedList<Point2L> linkedList = new LinkedList<Point2L>();
            int num1;
            for (num1 = 0; num1 + 2 < polygon.Count; ++num1)
            {
                long num2 = Polygon2L.smethod_2(polygon[0], polygon[num1 + 1], polygon[num1 + 2]);
                if (num2 <= 0L)
                {
                    if (num2 < 0L)
                    {
                        linkedList.AddLast(polygon[num1 + 2]);
                        linkedList.AddLast(polygon[num1 + 2]);
                        LinkedListNode<Point2L> node = linkedList.AddAfter(linkedList.First, polygon[num1 + 1]);
                        linkedList.AddAfter(node, polygon[0]);
                        break;
                    }
                }
                else
                {
                    linkedList.AddLast(polygon[num1 + 2]);
                    linkedList.AddLast(polygon[num1 + 2]);
                    LinkedListNode<Point2L> node = linkedList.AddAfter(linkedList.First, polygon[0]);
                    linkedList.AddAfter(node, polygon[num1 + 1]);
                    break;
                }
            }
            for (int index = num1 + 3; index < polygon.Count; ++index)
            {
                Point2L p2 = polygon[index];
                if (Polygon2L.smethod_2(linkedList.First.Value, linkedList.First.Next.Value, p2) <= 0L || Polygon2L.smethod_2(linkedList.Last.Previous.Value, linkedList.Last.Value, p2) <= 0L)
                {
                    while (linkedList.First.Next != null && Polygon2L.smethod_2(linkedList.First.Value, linkedList.First.Next.Value, p2) <= 0L)
                        linkedList.RemoveFirst();
                    linkedList.AddFirst(p2);
                    while (linkedList.Last.Previous != null && Polygon2L.smethod_2(linkedList.Last.Previous.Value, linkedList.Last.Value, p2) <= 0L)
                        linkedList.RemoveLast();
                    linkedList.AddLast(p2);
                }
            }
            Polygon2L polygon2L = new Polygon2L();
            LinkedListNode<Point2L> linkedListNode = linkedList.First;
            for (int index = 1; index < linkedList.Count; ++index)
            {
                LinkedListNode<Point2L> next = linkedListNode.Next;
                polygon2L.Add(linkedListNode.Value);
                linkedListNode = next;
            }
            return polygon2L;
        }

        private static long smethod_2(Point2L p0, Point2L p1, Point2L p2)
        {
            return (p1.X - p0.X) * (p2.Y - p0.Y) - (p2.X - p0.X) * (p1.Y - p0.Y);
        }

        private static void smethod_3(
          IList<Point2L> convexPolygon,
          int n,
          Vector2L direction,
          ref int j,
          ref long projection)
        {
            int num1 = j;
            j = (j + 1) % n;
            while (j != num1)
            {
                long num2 = Vector2L.DotProduct(direction, convexPolygon[j] - Point2L.Zero);
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
            return Polygon2L.smethod_4(x1, y1, x2, y2, x3, y3) > 0L;
        }

        private static bool smethod_6(long x1, long y1, long x2, long y2, long x3, long y3)
        {
            return Polygon2L.smethod_4(x1, y1, x2, y2, x3, y3) < 0L;
        }

        public class BooleanOperations
        {
            internal const long long_0 = 65535;

            public static List<Polygon2L> GetUnion(
              IList<Polygon2L> region1,
              IList<Polygon2L> region2)
            {
                Polygon2L.BooleanOperations.Region splitRegion1;
                Polygon2L.BooleanOperations.Region splitRegion2;
                List<Polygon2L.BooleanOperations.Segment> segments;
                Polygon2L.BooleanOperations.smethod_5(region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                return Polygon2L.BooleanOperations.smethod_0(splitRegion1, splitRegion2, segments).ToPolygon2LList();
            }

            public static Polygon2L.BooleanOperations.Region GetUnion(
              Polygon2L.BooleanOperations.Context context,
              Polygon2L.BooleanOperations.Region region1,
              Polygon2L.BooleanOperations.Region region2)
            {
                Polygon2L.BooleanOperations.Region splitRegion1;
                Polygon2L.BooleanOperations.Region splitRegion2;
                List<Polygon2L.BooleanOperations.Segment> segments;
                Polygon2L.BooleanOperations.smethod_6(context, region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                return Polygon2L.BooleanOperations.smethod_0(splitRegion1, splitRegion2, segments);
            }


            private static Polygon2L.BooleanOperations.Region smethod_0(Polygon2L.BooleanOperations.Region region1, Polygon2L.BooleanOperations.Region region2, List<Polygon2L.BooleanOperations.Segment> segments)
            {
                Polygon2L.BooleanOperations.Region region = new Polygon2L.BooleanOperations.Region(false);
                int count = segments.Count;
                foreach (Polygon2L.BooleanOperations.Segment segment in segments)
                {
                    if (segment.Processed)
                    {
                        continue;
                    }
                    Polygon2L.BooleanOperations.smethod_9(region1, region2, segments, segment, region, (Polygon2L.BooleanOperations.Segment s) => (s.Region != region1 ? s.Status == Polygon2L.BooleanOperations.SegmentStatus.Outside : (s.Status == Polygon2L.BooleanOperations.SegmentStatus.Outside ? true : s.Status == Polygon2L.BooleanOperations.SegmentStatus.Shared)), ref count);
                }
                return region;
            }

            public static List<Polygon2L> GetDifference(
        IList<Polygon2L> region1,
        IList<Polygon2L> region2)
            {
                Polygon2L.BooleanOperations.Region splitRegion1;
                Polygon2L.BooleanOperations.Region splitRegion2;
                List<Polygon2L.BooleanOperations.Segment> segments;
                Polygon2L.BooleanOperations.smethod_5(region1, false, region2, true, out splitRegion1, out splitRegion2, out segments);
                return Polygon2L.BooleanOperations.smethod_1(splitRegion1, splitRegion2, segments).ToPolygon2LList();
            }

            public static Polygon2L.BooleanOperations.Region GetDifference(
              Polygon2L.BooleanOperations.Context context,
              Polygon2L.BooleanOperations.Region region1,
              Polygon2L.BooleanOperations.Region region2)
            {
                Polygon2L.BooleanOperations.Region splitRegion1;
                Polygon2L.BooleanOperations.Region splitRegion2;
                List<Polygon2L.BooleanOperations.Segment> segments;
                Polygon2L.BooleanOperations.smethod_6(context, region1, false, region2, true, out splitRegion1, out splitRegion2, out segments);
                return Polygon2L.BooleanOperations.smethod_1(splitRegion1, splitRegion2, segments);
            }

            private static Polygon2L.BooleanOperations.Region smethod_1(Polygon2L.BooleanOperations.Region region1, Polygon2L.BooleanOperations.Region region2, List<Polygon2L.BooleanOperations.Segment> segments)
            {
                Polygon2L.BooleanOperations.Region region = new Polygon2L.BooleanOperations.Region(false);
                int count = segments.Count;
                foreach (Polygon2L.BooleanOperations.Segment segment in segments)
                {
                    if (segment.Processed)
                    {
                        continue;
                    }
                    Polygon2L.BooleanOperations.smethod_9(region1, region2, segments, segment, region, (Polygon2L.BooleanOperations.Segment s) => (s.Region != region1 ? s.Status == Polygon2L.BooleanOperations.SegmentStatus.Inside : (s.Status == Polygon2L.BooleanOperations.SegmentStatus.Inside ? true : s.Status == Polygon2L.BooleanOperations.SegmentStatus.Shared)), ref count);
                }
                return region;
            }

            public static List<Polygon2L> GetIntersection(
              IList<Polygon2L> region1,
              IList<Polygon2L> region2)
            {
                Polygon2L.BooleanOperations.Region splitRegion1;
                Polygon2L.BooleanOperations.Region splitRegion2;
                List<Polygon2L.BooleanOperations.Segment> segments;
                Polygon2L.BooleanOperations.smethod_5(region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                return Polygon2L.BooleanOperations.smethod_2(splitRegion1, splitRegion2, segments).ToPolygon2LList();
            }

            public static Polygon2L.BooleanOperations.Region GetIntersection(
              Polygon2L.BooleanOperations.Context context,
              Polygon2L.BooleanOperations.Region region1,
              Polygon2L.BooleanOperations.Region region2)
            {
                Polygon2L.BooleanOperations.Region splitRegion1;
                Polygon2L.BooleanOperations.Region splitRegion2;
                List<Polygon2L.BooleanOperations.Segment> segments;
                Polygon2L.BooleanOperations.smethod_6(context, region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                return Polygon2L.BooleanOperations.smethod_2(splitRegion1, splitRegion2, segments);
            }

            private static Polygon2L.BooleanOperations.Region smethod_2(Polygon2L.BooleanOperations.Region region1, Polygon2L.BooleanOperations.Region region2, List<Polygon2L.BooleanOperations.Segment> segments)
            {
                Polygon2L.BooleanOperations.Region region = new Polygon2L.BooleanOperations.Region(false);
                int count = segments.Count;
                foreach (Polygon2L.BooleanOperations.Segment segment in segments)
                {
                    if (segment.Processed)
                    {
                        continue;
                    }
                    Polygon2L.BooleanOperations.smethod_9(region1, region2, segments, segment, region, (Polygon2L.BooleanOperations.Segment s) => (s.Region != region1 ? s.Status == Polygon2L.BooleanOperations.SegmentStatus.Inside : (s.Status == Polygon2L.BooleanOperations.SegmentStatus.Inside ? true : s.Status == Polygon2L.BooleanOperations.SegmentStatus.Shared)), ref count);
                }
                return region;
            }

            public static List<Polygon2L> GetExclusiveOr(
              IList<Polygon2L> region1,
              IList<Polygon2L> region2)
            {
                Polygon2L.BooleanOperations.Region splitRegion1;
                Polygon2L.BooleanOperations.Region splitRegion2;
                List<Polygon2L.BooleanOperations.Segment> segments;
                Polygon2L.BooleanOperations.smethod_5(region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                Polygon2L.BooleanOperations.smethod_3(segments);
                return Polygon2L.BooleanOperations.smethod_4(splitRegion1, splitRegion2, segments).ToPolygon2LList();
            }

            public static Polygon2L.BooleanOperations.Region GetExclusiveOr(
              Polygon2L.BooleanOperations.Context context,
              Polygon2L.BooleanOperations.Region region1,
              Polygon2L.BooleanOperations.Region region2)
            {
                Polygon2L.BooleanOperations.Region splitRegion1;
                Polygon2L.BooleanOperations.Region splitRegion2;
                List<Polygon2L.BooleanOperations.Segment> segments;
                Polygon2L.BooleanOperations.smethod_6(context, region1, false, region2, false, out splitRegion1, out splitRegion2, out segments);
                Polygon2L.BooleanOperations.smethod_3(segments);
                return Polygon2L.BooleanOperations.smethod_4(splitRegion1, splitRegion2, segments);
            }

            private static void smethod_3(List<Polygon2L.BooleanOperations.Segment> segments)
            {
                foreach (Polygon2L.BooleanOperations.Segment segment in segments)
                {
                    if (segment.Status == Polygon2L.BooleanOperations.SegmentStatus.Inside)
                        segment.Reverse();
                }
            }

            private static Polygon2L.BooleanOperations.Region smethod_4(
              Polygon2L.BooleanOperations.Region region1,
              Polygon2L.BooleanOperations.Region region2,
              List<Polygon2L.BooleanOperations.Segment> segments)
            {
                Polygon2L.BooleanOperations.Region resultRegion = new Polygon2L.BooleanOperations.Region(false);
                int count = segments.Count;
                foreach (Polygon2L.BooleanOperations.Segment segment in segments)
                {
                    if (!segment.Processed)
                        Polygon2L.BooleanOperations.smethod_9(region1, region2, segments, segment, resultRegion, (Func<Polygon2L.BooleanOperations.Segment, bool>)(s =>
                       {
                           if (s.Status != Polygon2L.BooleanOperations.SegmentStatus.Outside)
                               return s.Status == Polygon2L.BooleanOperations.SegmentStatus.Inside;
                           return true;
                       }), ref count);
                }
                return resultRegion;
            }

            public static Polygon2L.BooleanOperations.Region Subdivide(
              Polygon2L.BooleanOperations.Context context,
              Polygon2L.BooleanOperations.Region region)
            {
                return region.Subdivide(context);
            }

            private static void smethod_5(
              IList<Polygon2L> region1,
              bool reverseRegion1,
              IList<Polygon2L> region2,
              bool reverseRegion2,
              out Polygon2L.BooleanOperations.Region splitRegion1,
              out Polygon2L.BooleanOperations.Region splitRegion2,
              out List<Polygon2L.BooleanOperations.Segment> segments)
            {
                Polygon2L.BooleanOperations.Context context = new Polygon2L.BooleanOperations.Context();
                Polygon2L.BooleanOperations.Region region3 = Polygon2L.BooleanOperations.GetRegion(region1, context, reverseRegion1);
                Polygon2L.BooleanOperations.Region region4 = Polygon2L.BooleanOperations.GetRegion(region2, context, reverseRegion2);
                Polygon2L.BooleanOperations.smethod_7(context, region3, region4, out splitRegion1, out splitRegion2, out segments);
            }

            private static void smethod_6(
              Polygon2L.BooleanOperations.Context context,
              Polygon2L.BooleanOperations.Region region1,
              bool reverseRegion1,
              Polygon2L.BooleanOperations.Region region2,
              bool reverseRegion2,
              out Polygon2L.BooleanOperations.Region splitRegion1,
              out Polygon2L.BooleanOperations.Region splitRegion2,
              out List<Polygon2L.BooleanOperations.Segment> segments)
            {
                Polygon2L.BooleanOperations.Region tmpRegion1 = Polygon2L.BooleanOperations.smethod_13(context, region1, reverseRegion1);
                Polygon2L.BooleanOperations.Region tmpRegion2 = Polygon2L.BooleanOperations.smethod_13(context, region2, reverseRegion2);
                Polygon2L.BooleanOperations.smethod_7(context, tmpRegion1, tmpRegion2, out splitRegion1, out splitRegion2, out segments);
            }

            private static void smethod_7(
              Polygon2L.BooleanOperations.Context context,
              Polygon2L.BooleanOperations.Region tmpRegion1,
              Polygon2L.BooleanOperations.Region tmpRegion2,
              out Polygon2L.BooleanOperations.Region splitRegion1,
              out Polygon2L.BooleanOperations.Region splitRegion2,
              out List<Polygon2L.BooleanOperations.Segment> segments)
            {
                new Polygon2L.BooleanOperations.SweepLine(new Polygon2L.BooleanOperations.EventQueue()
        {
          tmpRegion1,
          tmpRegion2
        }, context, true).method_0();
                context.method_1();
                splitRegion1 = Polygon2L.BooleanOperations.smethod_10(context, tmpRegion1);
                splitRegion2 = Polygon2L.BooleanOperations.smethod_10(context, tmpRegion2);
                segments = new List<Polygon2L.BooleanOperations.Segment>();
                splitRegion1.GetSegments((IList<Polygon2L.BooleanOperations.Segment>)segments);
                splitRegion2.GetSegments((IList<Polygon2L.BooleanOperations.Segment>)segments);
                splitRegion1.CalculateSegmentStatus(splitRegion2);
                splitRegion2.CalculateSegmentStatus(splitRegion1);
            }

            private static void smethod_8(Polygon2L.BooleanOperations.Region region)
            {
                foreach (LinkedList<Polygon2L.BooleanOperations.Segment> linkedList in (List<Polygon2L.BooleanOperations.Polygon>)region)
                {
                    foreach (Polygon2L.BooleanOperations.Segment segment in linkedList)
                    {
                        bool flag = false;
                        foreach (Polygon2L.BooleanOperations.Vertex vertex in segment.Start.Vertices)
                        {
                            if (vertex.InSegment != segment && vertex.InSegment.Status != Polygon2L.BooleanOperations.SegmentStatus.SelfOverlap && vertex.InSegment.Start == segment.End)
                            {
                                segment.Status = Polygon2L.BooleanOperations.SegmentStatus.SelfOverlap;
                                vertex.InSegment.Status = Polygon2L.BooleanOperations.SegmentStatus.SelfOverlap;
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                            break;
                    }
                }
                foreach (Polygon2L.BooleanOperations.Polygon polygon in (List<Polygon2L.BooleanOperations.Polygon>)region)
                {
                    LinkedListNode<Polygon2L.BooleanOperations.Segment> node = polygon.First;
                    for (int index = polygon.Count - 1; index >= 0; --index)
                    {
                        Polygon2L.BooleanOperations.Segment segment = node.Value;
                        LinkedListNode<Polygon2L.BooleanOperations.Segment> next = node.Next;
                        if (segment.Status == Polygon2L.BooleanOperations.SegmentStatus.SelfOverlap)
                            polygon.Remove(node);
                        node = next;
                    }
                }
            }

            private static void smethod_9(
              Polygon2L.BooleanOperations.Region region1,
              Polygon2L.BooleanOperations.Region region2,
              List<Polygon2L.BooleanOperations.Segment> segments,
              Polygon2L.BooleanOperations.Segment startSegment,
              Polygon2L.BooleanOperations.Region resultRegion,
              Func<Polygon2L.BooleanOperations.Segment, bool> includeSegment,
              ref int n)
            {
                Polygon2L.BooleanOperations.Segment segment1 = startSegment;
                Polygon2L.BooleanOperations.Polygon polygon = (Polygon2L.BooleanOperations.Polygon)null;
                Polygon2L.BooleanOperations.Segment segment2 = (Polygon2L.BooleanOperations.Segment)null;
                while (n > 0)
                {
                    segment1.Processed = true;
                    --n;
                    if (!includeSegment(segment1))
                        break;
                    if (segment2 == null)
                    {
                        segment2 = segment1;
                        polygon = new Polygon2L.BooleanOperations.Polygon(resultRegion);
                        resultRegion.Add(polygon);
                    }
                    segment1.PolygonSegmentNode = polygon.AddLast(segment1);
                    if (segment1.End == segment2.Start)
                        break;
                    segment1 = segment1.End.GetNextUnprocessedSegment(segment1, includeSegment);
                }
            }

            private static Polygon2L.BooleanOperations.Region smethod_10(
              Polygon2L.BooleanOperations.Context context,
              Polygon2L.BooleanOperations.Region region)
            {
                Polygon2L.BooleanOperations.Region region1 = new Polygon2L.BooleanOperations.Region(region.Reversed);
                foreach (Polygon2L.BooleanOperations.Polygon polygon in (List<Polygon2L.BooleanOperations.Polygon>)region)
                {
                    Polygon2L.BooleanOperations.Polygon splitPolygon = new Polygon2L.BooleanOperations.Polygon(region1);
                    region1.Add(splitPolygon);
                    foreach (Polygon2L.BooleanOperations.Segment segment in (LinkedList<Polygon2L.BooleanOperations.Segment>)polygon)
                        segment.AddSegments(context, splitPolygon);
                    Polygon2L.BooleanOperations.Segment inSegment = splitPolygon.Last.Value;
                    foreach (Polygon2L.BooleanOperations.Segment outSegment in (LinkedList<Polygon2L.BooleanOperations.Segment>)splitPolygon)
                    {
                        outSegment.Start.AddVertexSorted(new Polygon2L.BooleanOperations.Vertex(inSegment, outSegment));
                        inSegment = outSegment;
                    }
                }
                return region1;
            }

            private static Polygon2L.BooleanOperations.Region smethod_11(
              Polygon2L.BooleanOperations.Context context,
              Polygon2L.BooleanOperations.Region region)
            {
                Polygon2L.BooleanOperations.Region region1 = new Polygon2L.BooleanOperations.Region(region.Reversed);
                foreach (Polygon2L.BooleanOperations.Polygon polygon in (List<Polygon2L.BooleanOperations.Polygon>)region)
                {
                    Polygon2L.BooleanOperations.Polygon splitPolygon = new Polygon2L.BooleanOperations.Polygon(region1);
                    region1.Add(splitPolygon);
                    foreach (Polygon2L.BooleanOperations.Segment segment in (LinkedList<Polygon2L.BooleanOperations.Segment>)polygon)
                        segment.AddSegments(context, splitPolygon);
                }
                return region1;
            }

            private static void smethod_12(Polygon2L.BooleanOperations.Region region)
            {
                foreach (Polygon2L.BooleanOperations.Polygon polygon in (List<Polygon2L.BooleanOperations.Polygon>)region)
                {
                    Polygon2L.BooleanOperations.Segment inSegment = polygon.Last.Value;
                    foreach (Polygon2L.BooleanOperations.Segment outSegment in (LinkedList<Polygon2L.BooleanOperations.Segment>)polygon)
                    {
                        outSegment.Start.AddVertexSorted(new Polygon2L.BooleanOperations.Vertex(inSegment, outSegment));
                        inSegment = outSegment;
                    }
                }
            }

            public static Polygon2L.BooleanOperations.Region GetRegion(
              IList<Polygon2L> input,
              Polygon2L.BooleanOperations.Context context)
            {
                return Polygon2L.BooleanOperations.GetRegion(input, context, false);
            }

            public static Polygon2L.BooleanOperations.Region GetRegion(
              IList<Polygon2L> input,
              Polygon2L.BooleanOperations.Context context,
              bool reverse)
            {
                Polygon2L.BooleanOperations.Region region = new Polygon2L.BooleanOperations.Region(reverse);
                foreach (Polygon2L inputPolygon in (IEnumerable<Polygon2L>)input)
                {
                    if (inputPolygon.Count > 0)
                    {
                        Polygon2L.BooleanOperations.Polygon polygon = new Polygon2L.BooleanOperations.Polygon(region);
                        region.Add(polygon);
                        if (reverse)
                            Polygon2L.BooleanOperations.smethod_15(inputPolygon, polygon, context);
                        else
                            Polygon2L.BooleanOperations.smethod_14(inputPolygon, polygon, context);
                    }
                }
                return region;
            }

            private static Polygon2L.BooleanOperations.Region smethod_13(
              Polygon2L.BooleanOperations.Context context,
              Polygon2L.BooleanOperations.Region input,
              bool reverse)
            {
                Polygon2L.BooleanOperations.Region region = input;
                if (reverse)
                    region = input.GetReverse(context);
                region.method_0();
                return region;
            }

            private static void smethod_14(
              Polygon2L inputPolygon,
              Polygon2L.BooleanOperations.Polygon polygon,
              Polygon2L.BooleanOperations.Context context)
            {
                Point2L p1 = inputPolygon[inputPolygon.Count - 1];
                Polygon2L.BooleanOperations.Point start = context.method_0(p1);
                for (int index = 0; index < inputPolygon.Count; ++index)
                {
                    Point2L p2 = inputPolygon[index];
                    Polygon2L.BooleanOperations.Point end = context.method_0(p2);
                    if (start.Position != end.Position)
                    {
                        Polygon2L.BooleanOperations.Segment segment = new Polygon2L.BooleanOperations.Segment(context, start, end);
                        segment.PolygonSegmentNode = polygon.AddLast(segment);
                    }
                    start = end;
                }
            }

            private static void smethod_15(
              Polygon2L inputPolygon,
              Polygon2L.BooleanOperations.Polygon polygon,
              Polygon2L.BooleanOperations.Context context)
            {
                Point2L p1 = inputPolygon[0];
                Polygon2L.BooleanOperations.Point start = context.method_0(p1);
                for (int index = inputPolygon.Count - 1; index >= 0; --index)
                {
                    Point2L p2 = inputPolygon[index];
                    Polygon2L.BooleanOperations.Point end = context.method_0(p2);
                    if (start.Position != end.Position)
                    {
                        Polygon2L.BooleanOperations.Segment segment = new Polygon2L.BooleanOperations.Segment(context, start, end);
                        segment.PolygonSegmentNode = polygon.AddLast(segment);
                    }
                    start = end;
                }
            }

            [Serializable]
            public class Point
            {
                private List<Polygon2L.BooleanOperations.Vertex> vertices = new List<Polygon2L.BooleanOperations.Vertex>();
                private Point2L position;

                public Point(Point2L position)
                {
                    this.position = position;
                }

                public Point2L Position
                {
                    get
                    {
                        return this.position;
                    }
                }

                public List<Polygon2L.BooleanOperations.Vertex> Vertices
                {
                    get
                    {
                        return this.vertices;
                    }
                }

                public void AddVertexSorted(Polygon2L.BooleanOperations.Vertex vertex)
                {
                    int index = this.vertices.BinarySearch(vertex, (IComparer<Polygon2L.BooleanOperations.Vertex>)Polygon2L.BooleanOperations.Vertex.OutSegmentDirectionComparer.Instance);
                    if (index < 0)
                        this.vertices.Insert(~index, vertex);
                    else
                        this.vertices.Insert(index, vertex);
                }

                public void RemoveVerticesWithInSegment(Polygon2L.BooleanOperations.Segment inSegment)
                {
                    for (int index = this.vertices.Count - 1; index >= 0; --index)
                    {
                        if (this.vertices[index].InSegment == inSegment)
                            this.vertices.RemoveAt(index);
                    }
                }

                public void RemoveVerticesWithOutSegment(Polygon2L.BooleanOperations.Segment outSegment)
                {
                    for (int index = this.vertices.Count - 1; index >= 0; --index)
                    {
                        if (this.vertices[index].OutSegment == outSegment)
                            this.vertices.RemoveAt(index);
                    }
                }

                public Polygon2L.BooleanOperations.Segment GetNextUnprocessedSegment(
                  Polygon2L.BooleanOperations.Segment segment,
                  Func<Polygon2L.BooleanOperations.Segment, bool> includeSegment)
                {
                    Vector2L b = -segment.Direction;
                    Polygon2L.BooleanOperations.Segment segment1 = (Polygon2L.BooleanOperations.Segment)null;
                    for (int index = this.vertices.Count - 1; index >= 0; --index)
                    {
                        Polygon2L.BooleanOperations.Vertex vertex = this.vertices[index];
                        if (!vertex.OutSegment.Processed && Vector2L.CompareAngles(vertex.OutSegment.Direction, b) < 0 && includeSegment(vertex.OutSegment))
                        {
                            segment1 = vertex.OutSegment;
                            break;
                        }
                    }
                    if (segment1 == null)
                    {
                        for (int index = this.vertices.Count - 1; index >= 0; --index)
                        {
                            Polygon2L.BooleanOperations.Vertex vertex = this.vertices[index];
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

                public Polygon2L.BooleanOperations.Segment GetNextUnprocessedSegmentBiDirectional(
                  Polygon2L.BooleanOperations.Context context,
                  Polygon2L.BooleanOperations.Segment segment,
                  Polygon2L.BooleanOperations.Segment segmentSource,
                  Func<Polygon2L.BooleanOperations.Segment, bool> includeSegment,
                  out Polygon2L.BooleanOperations.Segment resultSource)
                {
                    Vector2L b1 = -segment.Direction;
                    resultSource = (Polygon2L.BooleanOperations.Segment)null;
                    Polygon2L.BooleanOperations.Segment segment1 = (Polygon2L.BooleanOperations.Segment)null;
                    Vector2L b2 = Vector2L.Zero;
                    for (int index = this.vertices.Count - 1; index >= 0; --index)
                    {
                        Polygon2L.BooleanOperations.Vertex vertex = this.vertices[index];
                        if (!vertex.OutSegment.Processed && vertex.OutSegment != segmentSource && (Vector2L.CompareAngles(vertex.OutSegment.Direction, b1) < 0 && includeSegment(vertex.OutSegment)) && (segment1 == null || Vector2L.CompareAngles(vertex.OutSegment.Direction, b2) > 0))
                        {
                            resultSource = vertex.OutSegment;
                            segment1 = vertex.OutSegment;
                            b2 = vertex.OutSegment.Direction;
                        }
                        if (!vertex.InSegment.Processed && vertex.InSegment != segmentSource && (Vector2L.CompareAngles(-vertex.InSegment.Direction, b1) < 0 && includeSegment(vertex.InSegment)) && (segment1 == null || Vector2L.CompareAngles(-vertex.InSegment.Direction, b2) > 0))
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
                            Polygon2L.BooleanOperations.Vertex vertex = this.vertices[index];
                            if (!vertex.OutSegment.Processed && vertex.OutSegment != segmentSource && includeSegment(vertex.OutSegment) && (segment1 == null || Vector2L.CompareAngles(vertex.OutSegment.Direction, b2) > 0))
                            {
                                resultSource = vertex.OutSegment;
                                segment1 = vertex.OutSegment;
                                b2 = vertex.OutSegment.Direction;
                            }
                            if (!vertex.InSegment.Processed && vertex.InSegment != segmentSource && includeSegment(vertex.InSegment) && (segment1 == null || Vector2L.CompareAngles(-vertex.InSegment.Direction, b2) > 0))
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
                            Polygon2L.BooleanOperations.Vertex vertex = this.vertices[index];
                            Vector2L vector2L;
                            if (!vertex.OutSegment.Processed && vertex.OutSegment != segmentSource && (vertex.OutSegment.method_5(segmentSource) && includeSegment(vertex.OutSegment)) && segment1 == null)
                            {
                                resultSource = vertex.OutSegment;
                                segment1 = vertex.OutSegment;
                                vector2L = vertex.OutSegment.Direction;
                            }
                            if (!vertex.InSegment.Processed && vertex.InSegment != segmentSource && (vertex.InSegment.method_5(segmentSource) && includeSegment(vertex.InSegment)) && segment1 == null)
                            {
                                resultSource = vertex.InSegment;
                                segment1 = vertex.InSegment.vmethod_1(context);
                                vector2L = -vertex.InSegment.Direction;
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
                private Polygon2L.BooleanOperations.Segment inSegment;
                private Polygon2L.BooleanOperations.Segment outSegment;

                public Vertex(
                  Polygon2L.BooleanOperations.Segment inSegment,
                  Polygon2L.BooleanOperations.Segment outSegment)
                {
                    if (inSegment != null && inSegment.End.Position != outSegment.Start.Position)
                        throw new ArgumentException();
                    this.inSegment = inSegment;
                    this.outSegment = outSegment;
                }

                public Polygon2L.BooleanOperations.Segment InSegment
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

                public Polygon2L.BooleanOperations.Segment OutSegment
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

                public Polygon2L.BooleanOperations.Point Point
                {
                    get
                    {
                        return this.inSegment.End;
                    }
                }

                public Polygon2L.BooleanOperations.Region Region
                {
                    get
                    {
                        return this.inSegment.Region;
                    }
                }

                public bool IsInside(Polygon2L.BooleanOperations.Segment segment)
                {
                    if (segment.Start != this.inSegment.End)
                        throw new ArgumentException();
                    Vector2L vector2L = -this.inSegment.Direction;
                    Vector2L direction1 = this.outSegment.Direction;
                    Vector2L direction2 = segment.Direction;
                    int num1 = Vector2L.CompareAngles(vector2L, direction1);
                    int num2 = Vector2L.CompareAngles(direction2, vector2L);
                    int num3 = Vector2L.CompareAngles(direction2, direction1);
                    return num1 < 0 ? num2 <= 0 || num3 >= 0 : num2 <= 0 && num3 >= 0;
                }

                public override string ToString()
                {
                    return string.Format("Position: {0}, vertices: {1}", (object)this.Point.Position, (object)this.Point.Vertices.Count);
                }

                public class OutSegmentDirectionComparer : IComparer<Polygon2L.BooleanOperations.Vertex>
                {
                    public static readonly Polygon2L.BooleanOperations.Vertex.OutSegmentDirectionComparer Instance = new Polygon2L.BooleanOperations.Vertex.OutSegmentDirectionComparer();

                    private OutSegmentDirectionComparer()
                    {
                    }

                    public int Compare(
                      Polygon2L.BooleanOperations.Vertex x,
                      Polygon2L.BooleanOperations.Vertex y)
                    {
                        return Vector2L.CompareAngles(x.outSegment.Direction, y.outSegment.Direction);
                    }
                }
            }

            [Serializable]
            public class Segment
            {
                private int id;
                private Polygon2L.BooleanOperations.Point start;
                private Polygon2L.BooleanOperations.Point end;
                private Polygon2L.BooleanOperations.Point left;
                private Polygon2L.BooleanOperations.Point right;
                private Polygon2L.BooleanOperations.SegmentStatus status;
                private bool processed;
                private Vector2L direction;
                private bool isForward;
                private bool slopeIsPositive;
                private bool slopeIsNegative;
                [NonSerialized]
                private LinkedListNode<Polygon2L.BooleanOperations.Segment> linkedListNode_0;
                [NonSerialized]
                private RedBlackTree<Polygon2L.BooleanOperations.Segment>.Node node_0;
                [NonSerialized]
                private LinkedListNode<Polygon2L.BooleanOperations.SNActiveSegment> linkedListNode_1;

                public Segment(Polygon2L.BooleanOperations.Context context)
                {
                    this.id = context.GetNextSegmentId();
                }

                public Segment(
                  Polygon2L.BooleanOperations.Context context,
                  Polygon2L.BooleanOperations.Point start,
                  Polygon2L.BooleanOperations.Point end)
                {
                    if (start.Position == end.Position)
                        throw new ArgumentException("Start and end point may not be the same.");
                    this.id = context.GetNextSegmentId();
                    this.start = start;
                    this.end = end;
                    this.direction = end.Position - start.Position;
                    this.isForward = this.direction.X > 0L || this.direction.X == 0L && this.direction.Y > 0L;
                    if (this.isForward)
                    {
                        this.left = start;
                        this.right = end;
                        this.slopeIsPositive = end.Position.Y > start.Position.Y;
                        this.slopeIsNegative = end.Position.Y < start.Position.Y;
                    }
                    else
                    {
                        this.left = end;
                        this.right = start;
                        this.slopeIsPositive = start.Position.Y > end.Position.Y;
                        this.slopeIsNegative = start.Position.Y < end.Position.Y;
                    }
                }

                public int Id
                {
                    get
                    {
                        return this.id;
                    }
                }

                public Polygon2L.BooleanOperations.Polygon Polygon
                {
                    get
                    {
                        if (this.linkedListNode_0 != null)
                            return (Polygon2L.BooleanOperations.Polygon)this.linkedListNode_0.List;
                        return (Polygon2L.BooleanOperations.Polygon)null;
                    }
                }

                public Polygon2L.BooleanOperations.Point Start
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

                public Polygon2L.BooleanOperations.Point End
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

                public Polygon2L.BooleanOperations.Point Left
                {
                    get
                    {
                        return this.left;
                    }
                }

                public Polygon2L.BooleanOperations.Point Right
                {
                    get
                    {
                        return this.right;
                    }
                }

                internal Polygon2L.BooleanOperations.SegmentStatus Status
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

                public Vector2L Direction
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

                public Vector2L OrderedDirection
                {
                    get
                    {
                        Point2L position1 = this.start.Position;
                        Point2L position2 = this.end.Position;
                        if (position1.X < position2.X)
                            return this.direction;
                        if (position1.X > position2.X)
                            return -this.direction;
                        if (position1.Y > position2.Y)
                            return -this.direction;
                        return this.direction;
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

                public Polygon2L.BooleanOperations.Region Region
                {
                    get
                    {
                        return this.Polygon.Region;
                    }
                }

                public LinkedListNode<Polygon2L.BooleanOperations.Segment> PolygonSegmentNode
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

                public RedBlackTree<Polygon2L.BooleanOperations.Segment>.Node ActiveSegmentNode
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

                internal LinkedListNode<Polygon2L.BooleanOperations.SNActiveSegment> SnActiveSegmentNode
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
                  Polygon2L.BooleanOperations.Context context,
                  Polygon2L.BooleanOperations.Polygon splitPolygon)
                {
                    Polygon2L.BooleanOperations.Segment segment = new Polygon2L.BooleanOperations.Segment(context, this.start, this.end);
                    segment.linkedListNode_0 = splitPolygon.AddLast(segment);
                }

                public void AddSegmentsReversed(
                  Polygon2L.BooleanOperations.Context context,
                  Polygon2L.BooleanOperations.Polygon splitPolygon)
                {
                    Polygon2L.BooleanOperations.Segment segment = new Polygon2L.BooleanOperations.Segment(context, this.end, this.start);
                    segment.linkedListNode_0 = splitPolygon.AddLast(segment);
                }

                public void CalculateStatusFirstSegment(Polygon2L.BooleanOperations.Region otherRegion)
                {
                    if (this.status != Polygon2L.BooleanOperations.SegmentStatus.Unknown)
                        return;
                    this.method_1(otherRegion);
                    if (this.status != Polygon2L.BooleanOperations.SegmentStatus.Unknown)
                        return;
                    if (this.method_0(otherRegion) == 0)
                    {
                        if (otherRegion.IsInside(this.start.Position))
                            this.status = Polygon2L.BooleanOperations.SegmentStatus.Inside;
                        else
                            this.status = Polygon2L.BooleanOperations.SegmentStatus.Outside;
                    }
                    else
                        this.method_2(otherRegion);
                }

                public double GetIntersectionYCoordinate(double x)
                {
                    double x1 = (double)this.direction.X;
                    if (x1 == 0.0)
                        return (double)this.left.Position.Y;
                    return (x - (double)this.start.Position.X) * (double)this.direction.Y / x1 + (double)this.start.Position.Y;
                }

                private int method_0(Polygon2L.BooleanOperations.Region region)
                {
                    int num = 0;
                    foreach (Polygon2L.BooleanOperations.Vertex vertex in this.start.Vertices)
                    {
                        if (vertex.Region == region)
                            ++num;
                    }
                    return num;
                }

                public void CalculateStatus(
                  Polygon2L.BooleanOperations.Segment previousSegment,
                  Polygon2L.BooleanOperations.Region otherRegion)
                {
                    if (this.status != Polygon2L.BooleanOperations.SegmentStatus.Unknown)
                        return;
                    if (this.method_0(otherRegion) == 0)
                    {
                        this.status = previousSegment.status;
                    }
                    else
                    {
                        this.method_1(otherRegion);
                        if (this.status != Polygon2L.BooleanOperations.SegmentStatus.Unknown)
                            return;
                        this.method_2(otherRegion);
                    }
                }

                private void method_1(Polygon2L.BooleanOperations.Region otherRegion)
                {
                    foreach (Polygon2L.BooleanOperations.Vertex vertex in this.start.Vertices)
                    {
                        if (vertex.Region == otherRegion)
                        {
                            if (vertex.InSegment.start != this.end)
                            {
                                if (vertex.OutSegment.end == this.end)
                                {
                                    this.status = Polygon2L.BooleanOperations.SegmentStatus.Shared;
                                    break;
                                }
                            }
                            else
                            {
                                this.status = Polygon2L.BooleanOperations.SegmentStatus.SharedOpposite;
                                break;
                            }
                        }
                    }
                }

                private void method_2(Polygon2L.BooleanOperations.Region otherRegion)
                {
                    this.status = Polygon2L.BooleanOperations.SegmentStatus.Outside;
                    foreach (Polygon2L.BooleanOperations.Vertex vertex in this.start.Vertices)
                    {
                        if (vertex.Region == otherRegion && vertex.IsInside(this))
                        {
                            this.status = Polygon2L.BooleanOperations.SegmentStatus.Inside;
                            break;
                        }
                    }
                }

                public void Reverse()
                {
                    this.start.RemoveVerticesWithOutSegment(this);
                    Polygon2L.BooleanOperations.Point start = this.start;
                    this.start = this.end;
                    this.end = start;
                    this.direction = -this.direction;
                    this.start.AddVertexSorted(new Polygon2L.BooleanOperations.Vertex((Polygon2L.BooleanOperations.Segment)null, this));
                }

                public Segment2L ToSegment2L()
                {
                    return new Segment2L(this.start.Position, this.end.Position);
                }

                public override string ToString()
                {
                    return string.Format("Start: {0}, End: {1}, Status: {2}", (object)this.start, (object)this.end, (object)this.status);
                }

                internal virtual Polygon2L.BooleanOperations.Segment vmethod_0(
                  Polygon2L.BooleanOperations.Context context)
                {
                    return new Polygon2L.BooleanOperations.Segment(context, this.start, this.end);
                }

                internal virtual Polygon2L.BooleanOperations.Segment vmethod_1(
                  Polygon2L.BooleanOperations.Context context)
                {
                    return new Polygon2L.BooleanOperations.Segment(context, this.end, this.start);
                }

                internal bool method_3(Point2L position)
                {
                    if ((position.X < this.Start.Position.X || position.X > this.End.Position.X) && (position.X < this.End.Position.X || position.X > this.Start.Position.X))
                        return false;
                    if (position.Y >= this.Start.Position.Y && position.Y <= this.End.Position.Y)
                        return true;
                    if (position.Y >= this.End.Position.Y)
                        return position.Y <= this.Start.Position.Y;
                    return false;
                }

                internal bool method_4(Polygon2L.BooleanOperations.Segment otherSegment)
                {
                    if (this.start != otherSegment.start && this.start != otherSegment.end && this.end != otherSegment.start)
                        return this.end == otherSegment.end;
                    return true;
                }

                internal bool method_5(Polygon2L.BooleanOperations.Segment other)
                {
                    if (this.start == other.start && this.end == other.end)
                        return true;
                    if (this.start == other.end)
                        return this.end == other.start;
                    return false;
                }

                internal bool method_6(Point2D position)
                {
                    if (position.X == (double)this.start.Position.X && position.Y == (double)this.start.Position.Y)
                        return true;
                    if (position.X == (double)this.end.Position.X)
                        return position.Y == (double)this.end.Position.Y;
                    return false;
                }
            }

            [Serializable]
            public class Polygon : LinkedList<Polygon2L.BooleanOperations.Segment>
            {
                private Polygon2L.BooleanOperations.Region region;

                public Polygon()
                {
                }

                protected Polygon(SerializationInfo info, StreamingContext context)
                  : base(info, context)
                {
                }

                public Polygon(Polygon2L.BooleanOperations.Region region)
                {
                    this.region = region;
                }

                public Polygon2L.BooleanOperations.Region Region
                {
                    get
                    {
                        return this.region;
                    }
                }

                public static int GetWindingNumber(Point2L p, Polygon2L.BooleanOperations.Polygon polygon)
                {
                    return Polygon2L.BooleanOperations.Polygon.GetWindingNumber(p.X, p.Y, polygon);
                }

                public static int GetWindingNumber(
                  long x,
                  long y,
                  Polygon2L.BooleanOperations.Polygon polygon)
                {
                    int num = 0;
                    int count = polygon.Count;
                    if (count > 0)
                    {
                        LinkedListNode<Polygon2L.BooleanOperations.Segment> linkedListNode = polygon.First;
                        Polygon2L.BooleanOperations.Segment segment = linkedListNode.Value;
                        Point2L point2L = segment.Start.Position;
                        for (int index = 0; index < count; ++index)
                        {
                            Segment2L segment2L = segment.ToSegment2L();
                            Point2L position = segment.End.Position;
                            if (point2L.Y <= y)
                            {
                                if (position.Y > y && Polygon2L.smethod_5(segment2L.Start.X, segment2L.Start.Y, segment2L.End.X, segment2L.End.Y, x, y))
                                    ++num;
                            }
                            else if (position.Y <= y && Polygon2L.smethod_6(segment2L.Start.X, segment2L.Start.Y, segment2L.End.X, segment2L.End.Y, x, y))
                                --num;
                            linkedListNode = linkedListNode.Next;
                            segment = linkedListNode == null ? (Polygon2L.BooleanOperations.Segment)null : linkedListNode.Value;
                            point2L = position;
                        }
                    }
                    return num;
                }

                public void CalculateSegmentStatus(Polygon2L.BooleanOperations.Region otherRegion)
                {
                    if (this.Count <= 0)
                        return;
                    Polygon2L.BooleanOperations.Segment previousSegment = this.Last.Value;
                    LinkedListNode<Polygon2L.BooleanOperations.Segment> linkedListNode = this.First;
                    previousSegment.CalculateStatusFirstSegment(otherRegion);
                    for (int index = 1; index < this.Count; ++index)
                    {
                        Polygon2L.BooleanOperations.Segment segment = linkedListNode.Value;
                        segment.CalculateStatus(previousSegment, otherRegion);
                        previousSegment = segment;
                        linkedListNode = linkedListNode.Next;
                    }
                }

                public Polygon2L.BooleanOperations.Polygon GetReversedPolygon(
                  Polygon2L.BooleanOperations.Context context,
                  Polygon2L.BooleanOperations.Region targetRegion)
                {
                    Polygon2L.BooleanOperations.Polygon polygon = new Polygon2L.BooleanOperations.Polygon(targetRegion);
                    if (this.Count > 0)
                    {
                        LinkedListNode<Polygon2L.BooleanOperations.Segment> linkedListNode = this.Last;
                        for (int index = this.Count - 1; index >= 0; --index)
                        {
                            Polygon2L.BooleanOperations.Segment segment = linkedListNode.Value.vmethod_1(context);
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
                    Point2L point2L = this.Last.Value.Start.Position;
                    LinkedListNode<Polygon2L.BooleanOperations.Segment> linkedListNode = this.First;
                    for (int index = 0; index < count; ++index)
                    {
                        Point2L position = linkedListNode.Value.Start.Position;
                        num += point2L.X * position.Y - position.X * point2L.Y;
                        point2L = position;
                        linkedListNode = linkedListNode.Next;
                    }
                    return num;
                }

                public bool IsClockwise()
                {
                    if (this.Count < 3)
                        return false;
                    LinkedListNode<Polygon2L.BooleanOperations.Segment> linkedListNode1 = this.Last;
                    LinkedListNode<Polygon2L.BooleanOperations.Segment> linkedListNode2 = this.First;
                    LinkedListNode<Polygon2L.BooleanOperations.Segment> linkedListNode3 = this.First;
                    LinkedListNode<Polygon2L.BooleanOperations.Segment> next = linkedListNode3.Next;
                    for (int index = 1; index < this.Count; ++index)
                    {
                        Polygon2L.BooleanOperations.Segment segment = next.Value;
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
                    return Vector2L.CrossProduct(linkedListNode1.Value.ToSegment2L().GetDelta(), linkedListNode2.Value.ToSegment2L().GetDelta()) < 0L;
                }

                internal Polygon2L method_0()
                {
                    Polygon2L polygon2L = new Polygon2L(this.Count + 1);
                    if (this.Count > 0)
                    {
                        foreach (Polygon2L.BooleanOperations.Segment segment in (LinkedList<Polygon2L.BooleanOperations.Segment>)this)
                            polygon2L.Add(segment.Start.Position);
                        if (this.Last.Value.End != this.First.Value.Start)
                            polygon2L.Add(this.Last.Value.End.Position);
                    }
                    return polygon2L;
                }

                internal void method_1()
                {
                    foreach (Polygon2L.BooleanOperations.Segment segment in (LinkedList<Polygon2L.BooleanOperations.Segment>)this)
                        segment.Status = Polygon2L.BooleanOperations.SegmentStatus.Unknown;
                }
            }

            [Serializable]
            public class Region : List<Polygon2L.BooleanOperations.Polygon>
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

                public bool IsInside(Point2L p)
                {
                    return this.GetWindingNumber(p) > this.insideMinWindingNumber;
                }

                public int GetWindingNumber(Point2L p)
                {
                    int num = 0;
                    foreach (Polygon2L.BooleanOperations.Polygon polygon in (List<Polygon2L.BooleanOperations.Polygon>)this)
                        num += Polygon2L.BooleanOperations.Polygon.GetWindingNumber(p.X, p.Y, polygon);
                    return num;
                }

                public void CalculateSegmentStatus(Polygon2L.BooleanOperations.Region otherRegion)
                {
                    foreach (Polygon2L.BooleanOperations.Polygon polygon in (List<Polygon2L.BooleanOperations.Polygon>)this)
                        polygon.CalculateSegmentStatus(otherRegion);
                }

                public List<Polygon2L> ToPolygon2LList()
                {
                    List<Polygon2L> polygon2LList = new List<Polygon2L>(this.Count);
                    foreach (Polygon2L.BooleanOperations.Polygon polygon in (List<Polygon2L.BooleanOperations.Polygon>)this)
                    {
                        Polygon2L polygon2L = new Polygon2L(polygon.Count);
                        foreach (Polygon2L.BooleanOperations.Segment segment in (LinkedList<Polygon2L.BooleanOperations.Segment>)polygon)
                            polygon2L.Add(segment.Start.Position);
                        polygon2LList.Add(polygon2L);
                    }
                    return polygon2LList;
                }

                public void GetSegments(
                  IList<Polygon2L.BooleanOperations.Segment> segments)
                {
                    foreach (LinkedList<Polygon2L.BooleanOperations.Segment> linkedList in (List<Polygon2L.BooleanOperations.Polygon>)this)
                    {
                        foreach (Polygon2L.BooleanOperations.Segment segment in linkedList)
                            segments.Add(segment);
                    }
                }

                public Polygon2L.BooleanOperations.Region GetReverse(
                  Polygon2L.BooleanOperations.Context context)
                {
                    Polygon2L.BooleanOperations.Region targetRegion = new Polygon2L.BooleanOperations.Region(!this.reversed);
                    for (int index = this.Count - 1; index >= 0; --index)
                        targetRegion.Add(this[index].GetReversedPolygon(context, targetRegion));
                    return targetRegion;
                }

                public List<Polygon2L> ToPolygon2LListDebug()
                {
                    List<Polygon2L> polygon2LList = new List<Polygon2L>(this.Count);
                    foreach (Polygon2L.BooleanOperations.Polygon polygon in (List<Polygon2L.BooleanOperations.Polygon>)this)
                    {
                        Polygon2L polygon2L = polygon.method_0();
                        polygon2LList.Add(polygon2L);
                    }
                    return polygon2LList;
                }

                public Polygon2L.BooleanOperations.Region Subdivide(
                  Polygon2L.BooleanOperations.Context context)
                {
                    Polygon2L.BooleanOperations.Region region = Polygon2L.BooleanOperations.smethod_11(context, this);
                    new Polygon2L.BooleanOperations.SweepLine(new Polygon2L.BooleanOperations.EventQueue()
          {
            region
          }, context, false).method_0();
                    return region;
                }

                internal void method_0()
                {
                    foreach (Polygon2L.BooleanOperations.Polygon polygon in (List<Polygon2L.BooleanOperations.Polygon>)this)
                        polygon.method_1();
                }
            }

            [Serializable]
            internal class EventQueue : RedBlackTree<Polygon2L.BooleanOperations.Event>
            {
                public void Add(Polygon2L.BooleanOperations.Region region)
                {
                    foreach (Polygon2L.BooleanOperations.Polygon polygon in (List<Polygon2L.BooleanOperations.Polygon>)region)
                    {
                        if (polygon.Count > 0)
                        {
                            LinkedListNode<Polygon2L.BooleanOperations.Segment> linkedListNode = polygon.First;
                            for (int count = polygon.Count; count > 0; --count)
                            {
                                Polygon2L.BooleanOperations.Segment segment = linkedListNode.Value;
                                Point2D position1 = (Point2D)segment.Start.Position;
                                Point2D position2 = (Point2D)segment.End.Position;
                                if (position1.X > position2.X || position1.X == position2.X && position1.Y > position2.Y)
                                    MathUtil.Swap<Point2D>(ref position1, ref position2);
                                this.Add((Polygon2L.BooleanOperations.Event)new Polygon2L.BooleanOperations.EntryEvent(position1, segment));
                                this.Add((Polygon2L.BooleanOperations.Event)new Polygon2L.BooleanOperations.ExitEvent(position2, segment));
                                linkedListNode = linkedListNode.Next;
                            }
                        }
                    }
                }

                public Polygon2L.BooleanOperations.Event method_4()
                {
                    Polygon2L.BooleanOperations.Event @event = (Polygon2L.BooleanOperations.Event)null;
                    if (this.Count > 0)
                    {
                        RedBlackTree<Polygon2L.BooleanOperations.Event>.Node leftMost = this.Root.GetLeftMost();
                        @event = leftMost.Value;
                        this.Remove(leftMost);
                    }
                    return @event;
                }
            }

            [Serializable]
            internal class Event : IComparable<Polygon2L.BooleanOperations.Event>
            {
                private Point2D position;

                public Event(Point2D position)
                {
                    this.position = position;
                }

                public Point2D Position
                {
                    get
                    {
                        return this.position;
                    }
                    set
                    {
                        this.position = value;
                    }
                }

                public virtual int Order
                {
                    get
                    {
                        throw new NotImplementedException("Should be abstract in future.");
                    }
                }

                public virtual Polygon2L.BooleanOperations.SNEvent vmethod_0(
                  Polygon2L.BooleanOperations.SweepLine sweepLine)
                {
                    throw new NotImplementedException("Should be abstract in future.");
                }

                public override string ToString()
                {
                    return this.position.ToString();
                }

                public int CompareTo(Polygon2L.BooleanOperations.Event other)
                {
                    if (this.position.X < other.position.X)
                        return -1;
                    if (this.position.X > other.position.X)
                        return 1;
                    if (this.position.Y < other.position.Y)
                        return -1;
                    if (this.position.Y > other.position.Y)
                        return 1;
                    if (this.Order < other.Order)
                        return -1;
                    if (this.Order > other.Order)
                        return 1;
                    return this.vmethod_1(other);
                }

                public virtual int vmethod_1(Polygon2L.BooleanOperations.Event other)
                {
                    throw new NotImplementedException();
                }
            }

            [Serializable]
            internal class EntryEvent : Polygon2L.BooleanOperations.Event
            {
                private Polygon2L.BooleanOperations.Segment segment;

                public EntryEvent(Point2D position, Polygon2L.BooleanOperations.Segment segment)
                  : base(position)
                {
                    this.segment = segment;
                }

                public Polygon2L.BooleanOperations.Segment Segment
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

                public override Polygon2L.BooleanOperations.SNEvent vmethod_0(
                  Polygon2L.BooleanOperations.SweepLine sweepLine)
                {
                    sweepLine.method_1(this.Position, this.segment);
                    RedBlackTree<Polygon2L.BooleanOperations.Segment>.Node node = sweepLine.ActiveSegments.TryAdd(this.segment);
                    this.segment.ActiveSegmentNode = node;
                    RedBlackTree<Polygon2L.BooleanOperations.Segment>.Node previous = node.GetPrevious();
                    if (previous != null)
                        sweepLine.method_2(previous.Value, node.Value);
                    RedBlackTree<Polygon2L.BooleanOperations.Segment>.Node next = node.GetNext();
                    if (next != null)
                        sweepLine.method_2(node.Value, next.Value);
                    while (previous != null && previous.Value.Start.Position.X == previous.Value.End.Position.X)
                        previous = previous.GetPrevious();
                    return (Polygon2L.BooleanOperations.SNEvent)new Polygon2L.BooleanOperations.SNEntryEvent(this.Position, this.segment, previous == null ? (Polygon2L.BooleanOperations.Segment)null : previous.Value);
                }

                public override int vmethod_1(Polygon2L.BooleanOperations.Event other)
                {
                    return MathUtil.Compare(this.segment.Id, ((Polygon2L.BooleanOperations.EntryEvent)other).Segment.Id);
                }

                public override string ToString()
                {
                    return string.Format("Entry: {0}", (object)this.segment);
                }
            }

            [Serializable]
            internal class ExitEvent : Polygon2L.BooleanOperations.Event
            {
                private Polygon2L.BooleanOperations.Segment segment;

                public ExitEvent(Point2D position, Polygon2L.BooleanOperations.Segment segment)
                  : base(position)
                {
                    this.segment = segment;
                }

                public Polygon2L.BooleanOperations.Segment Segment
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

                public override Polygon2L.BooleanOperations.SNEvent vmethod_0(
                  Polygon2L.BooleanOperations.SweepLine sweepLine)
                {
                    RedBlackTree<Polygon2L.BooleanOperations.Segment>.Node previous = this.segment.ActiveSegmentNode.GetPrevious();
                    RedBlackTree<Polygon2L.BooleanOperations.Segment>.Node next = this.segment.ActiveSegmentNode.GetNext();
                    sweepLine.ActiveSegments.Remove(this.segment.ActiveSegmentNode);
                    this.segment.ActiveSegmentNode = (RedBlackTree<Polygon2L.BooleanOperations.Segment>.Node)null;
                    if (previous != null && next != null)
                        sweepLine.method_2(previous.Value, next.Value);
                    return (Polygon2L.BooleanOperations.SNEvent)new Polygon2L.BooleanOperations.SNExitEvent(this.Position, this.segment);
                }

                public override int vmethod_1(Polygon2L.BooleanOperations.Event other)
                {
                    return MathUtil.Compare(this.segment.Id, ((Polygon2L.BooleanOperations.ExitEvent)other).Segment.Id);
                }

                public override string ToString()
                {
                    return string.Format("Exit: {0}", (object)this.segment);
                }
            }

            private class Class179 : Polygon2L.BooleanOperations.Event
            {
                private Polygon2L.BooleanOperations.Segment segment_0;
                private Polygon2L.BooleanOperations.Segment segment_1;

                public Class179(
                  Point2D position,
                  Polygon2L.BooleanOperations.Segment low,
                  Polygon2L.BooleanOperations.Segment high)
                  : base(position)
                {
                    this.segment_0 = low;
                    this.segment_1 = high;
                }

                public override int Order
                {
                    get
                    {
                        return 2;
                    }
                }

                public override Polygon2L.BooleanOperations.SNEvent vmethod_0(
                  Polygon2L.BooleanOperations.SweepLine sweepLine)
                {
                    Polygon2L.BooleanOperations.SNEvent snEvent = (Polygon2L.BooleanOperations.SNEvent)null;
                    if (this.segment_0.ActiveSegmentNode.GetNext() == this.segment_1.ActiveSegmentNode)
                    {
                        sweepLine.ActiveSegments.ReverseNodes(this.segment_0.ActiveSegmentNode, this.segment_1.ActiveSegmentNode);
                        RedBlackTree<Polygon2L.BooleanOperations.Segment>.Node previous = this.segment_1.ActiveSegmentNode.GetPrevious();
                        if (previous != null)
                            sweepLine.method_2(previous.Value, this.segment_1);
                        RedBlackTree<Polygon2L.BooleanOperations.Segment>.Node next = this.segment_0.ActiveSegmentNode.GetNext();
                        if (next != null)
                            sweepLine.method_2(this.segment_0, next.Value);
                        snEvent = (Polygon2L.BooleanOperations.SNEvent)new Polygon2L.BooleanOperations.SNIntersectionEvent(this.Position, this.segment_0, this.segment_1);
                    }
                    return snEvent;
                }

                public override int vmethod_1(Polygon2L.BooleanOperations.Event other)
                {
                    Polygon2L.BooleanOperations.Class179 class179 = (Polygon2L.BooleanOperations.Class179)other;
                    if (this.Position == class179.Position && (this.segment_0 == class179.segment_0 && this.segment_1 == class179.segment_1 || this.segment_0 == class179.segment_1 && this.segment_1 == class179.segment_0))
                        return 0;
                    int num = MathUtil.Compare(this.segment_0.Id, class179.segment_0.Id);
                    if (num == 0)
                        num = MathUtil.Compare(this.segment_1.Id, class179.segment_1.Id);
                    return num;
                }

                public override string ToString()
                {
                    return string.Format("Intersection: low: {0}, high: {1}", (object)this.segment_0, (object)this.segment_1);
                }
            }

            [Serializable]
            internal class SweepLine
            {
                private Polygon2L.BooleanOperations.SweepLine.SegmentComparer segmentComparer = new Polygon2L.BooleanOperations.SweepLine.SegmentComparer();
                private Polygon2L.BooleanOperations.EventQueue eventQueue;
                private Polygon2L.BooleanOperations.Context context;
                private RedBlackTree<Polygon2L.BooleanOperations.Segment> activeSegments;
                private bool ignoreIntraRegionIntersections;

                public SweepLine(
                  Polygon2L.BooleanOperations.EventQueue eventQueue,
                  Polygon2L.BooleanOperations.Context context,
                  bool ignoreIntraRegionIntersections)
                {
                    this.eventQueue = eventQueue;
                    this.context = context;
                    this.activeSegments = new RedBlackTree<Polygon2L.BooleanOperations.Segment>((IComparer<Polygon2L.BooleanOperations.Segment>)this.segmentComparer);
                    this.ignoreIntraRegionIntersections = ignoreIntraRegionIntersections;
                }

                public RedBlackTree<Polygon2L.BooleanOperations.Segment> ActiveSegments
                {
                    get
                    {
                        return this.activeSegments;
                    }
                }

                public void method_0()
                {
                    List<Polygon2L.BooleanOperations.SNEvent> events = new List<Polygon2L.BooleanOperations.SNEvent>();
                    List<Polygon2L.BooleanOperations.Event> eventList = new List<Polygon2L.BooleanOperations.Event>();
                    for (Polygon2L.BooleanOperations.Event event1 = this.eventQueue.method_4(); event1 != null; event1 = this.eventQueue.method_4())
                    {
                        Polygon2L.BooleanOperations.SNEvent snEvent = event1.vmethod_0(this);
                        if (snEvent != null)
                        {
                            events.Add(snEvent);
                            if (eventList.Count > 0)
                            {
                                foreach (Polygon2L.BooleanOperations.Event event2 in eventList)
                                    this.eventQueue.Add(event2);
                                eventList.Clear();
                            }
                        }
                        else
                            eventList.Add(event1);
                    }
                    new Polygon2L.BooleanOperations.SNSweepLine(this.context, events).method_0();
                }

                public void method_1(Point2D eventPosition, Polygon2L.BooleanOperations.Segment segment)
                {
                    this.segmentComparer.method_0(eventPosition.X, segment);
                }

                public bool method_2(
                  Polygon2L.BooleanOperations.Segment lowSegment,
                  Polygon2L.BooleanOperations.Segment highSegment)
                {
                    if (this.ignoreIntraRegionIntersections)
                    {
                        if (lowSegment.Region == highSegment.Region)
                            return false;
                    }
                    else if (lowSegment.method_4(highSegment))
                        return false;
                    Vector2L orderedDirection1 = lowSegment.OrderedDirection;
                    Vector2L orderedDirection2 = highSegment.OrderedDirection;
                    if (orderedDirection1.X != 0L && orderedDirection2.X != 0L && Vector2L.CrossProduct(orderedDirection1, orderedDirection2) > 0L)
                        return false;
                    bool flag = false;
                    Point2D intersection1;
                    Point2D intersection2;
                    int intersections;
                    if ((intersections = Segment2L.GetIntersections(lowSegment.ToSegment2L(), highSegment.ToSegment2L(), out intersection1, out intersection2)) > 0)
                    {
                        for (int index = 0; index < intersections; ++index)
                        {
                            Point2D position = index == 0 ? intersection1 : intersection2;
                            if (!lowSegment.method_6(position) && !highSegment.method_6(position))
                                this.eventQueue.TryAdd((Polygon2L.BooleanOperations.Event)new Polygon2L.BooleanOperations.Class179(position, lowSegment, highSegment));
                        }
                        flag = true;
                    }
                    return flag;
                }

                private class SegmentComparer : IComparer<Polygon2L.BooleanOperations.Segment>
                {
                    private double double_0;
                    private Polygon2L.BooleanOperations.Segment segment_0;
                    private Vector2L vector2L_0;
                    private double double_1;

                    public void method_0(double sweepLineX, Polygon2L.BooleanOperations.Segment a)
                    {
                        this.double_0 = sweepLineX;
                        this.segment_0 = a;
                        if (sweepLineX == (double)a.Start.Position.X)
                        {
                            this.double_1 = (double)a.Start.Position.Y;
                        }
                        else
                        {
                            if (sweepLineX != (double)a.End.Position.X)
                                throw new Exception("Sweepline x-coordinate is unequal to segment's start or end position x-coordinate.");
                            this.double_1 = (double)a.End.Position.Y;
                        }
                        this.vector2L_0 = a.OrderedDirection;
                    }

                    public int Compare(
                      Polygon2L.BooleanOperations.Segment a,
                      Polygon2L.BooleanOperations.Segment b)
                    {
                        double intersectionYcoordinate = b.GetIntersectionYCoordinate(this.double_0);
                        if (this.double_1 < intersectionYcoordinate)
                            return -1;
                        if (this.double_1 > intersectionYcoordinate)
                            return 1;
                        int num = this.method_1(this.vector2L_0, b.OrderedDirection);
                        if (num != 0)
                            return num;
                        return MathUtil.Compare(a.Id, b.Id);
                    }

                    private int method_1(Vector2L a, Vector2L b)
                    {
                        long num = Vector2L.CrossProduct(a, b);
                        if (num < 0L)
                            return 1;
                        return num > 0L ? -1 : 0;
                    }
                }
            }

            [Serializable]
            internal abstract class SNEvent
            {
                private Point2D position;
                private Point2L roundedPosition;

                protected SNEvent(Point2D position)
                {
                    this.position = position;
                    this.roundedPosition = new Point2L(position);
                }

                public Point2D Position
                {
                    get
                    {
                        return this.position;
                    }
                }

                public Point2L RoundedPosition
                {
                    get
                    {
                        return this.roundedPosition;
                    }
                }

                public virtual void vmethod_0(Polygon2L.BooleanOperations.SNEdge edge)
                {
                }

                public abstract void vmethod_1(
                  Polygon2L.BooleanOperations.SNSweepLine sweepLine,
                  List<Polygon2L.BooleanOperations.SNEdge> edgeList,
                  int x);

                public abstract void vmethod_2(
                  Polygon2L.BooleanOperations.SNSweepLine sweepLine,
                  List<Polygon2L.BooleanOperations.SNEdge> edgeList,
                  int x);

                public abstract void vmethod_3(
                  Polygon2L.BooleanOperations.SNSweepLine sweepLine,
                  List<Polygon2L.BooleanOperations.SNEdge> edgeList,
                  int x);

                public abstract Polygon2L.BooleanOperations.Segment vmethod_4(double x);

                public void method_0(
                  Polygon2L.BooleanOperations.SNSweepLine sweepLine,
                  double x,
                  Polygon2L.BooleanOperations.SNEdge edge,
                  ref Polygon2L.BooleanOperations.SNActiveSegment lastConnectedSegment)
                {
                    edge.LowerSegment = (Polygon2L.BooleanOperations.SNActiveSegment)null;
                    Polygon2L.BooleanOperations.Segment segment = this.vmethod_4(x);
                    double y = edge.Y;
                    if (segment == null)
                    {
                        LinkedListNode<Polygon2L.BooleanOperations.SNActiveSegment> linkedListNode1 = lastConnectedSegment == null ? sweepLine.ActiveSegments.First : lastConnectedSegment.Segment.SnActiveSegmentNode.Next;
                        LinkedListNode<Polygon2L.BooleanOperations.SNActiveSegment> linkedListNode2 = (LinkedListNode<Polygon2L.BooleanOperations.SNActiveSegment>)null;
                        for (; linkedListNode1 != null && linkedListNode1.Value.Segment.GetIntersectionYCoordinate(x) < y; linkedListNode1 = linkedListNode1.Next)
                            linkedListNode2 = linkedListNode1;
                        if (linkedListNode2 == null)
                            return;
                        linkedListNode2.Value.method_0(edge);
                        lastConnectedSegment = linkedListNode2.Value;
                    }
                    else
                    {
                        LinkedListNode<Polygon2L.BooleanOperations.SNActiveSegment> activeSegmentNode = segment.SnActiveSegmentNode;
                        double intersectionYcoordinate = activeSegmentNode.Value.Segment.GetIntersectionYCoordinate(x);
                        if (intersectionYcoordinate >= y)
                        {
                            for (LinkedListNode<Polygon2L.BooleanOperations.SNActiveSegment> previous = activeSegmentNode.Previous; previous != null; previous = previous.Previous)
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
                            LinkedListNode<Polygon2L.BooleanOperations.SNActiveSegment> linkedListNode = activeSegmentNode;
                            for (LinkedListNode<Polygon2L.BooleanOperations.SNActiveSegment> next = activeSegmentNode.Next; next != null && next.Value.Segment.GetIntersectionYCoordinate(x) < y; next = next.Next)
                                linkedListNode = next;
                            if (linkedListNode.Value.UpperEdge != null)
                                return;
                            linkedListNode.Value.method_0(edge);
                            lastConnectedSegment = linkedListNode.Value;
                        }
                    }
                }
            }

            [Serializable]
            internal class SNEntryEvent : Polygon2L.BooleanOperations.SNEvent
            {
                private Polygon2L.BooleanOperations.SNEdge topEdge;
                private Polygon2L.BooleanOperations.Segment segment;
                private Polygon2L.BooleanOperations.Segment previous;

                public SNEntryEvent(
                  Point2D position,
                  Polygon2L.BooleanOperations.Segment segment,
                  Polygon2L.BooleanOperations.Segment previous)
                  : base(position)
                {
                    this.segment = segment;
                    this.previous = previous;
                }

                public override void vmethod_0(Polygon2L.BooleanOperations.SNEdge edge)
                {
                    this.topEdge = edge;
                }

                public override void vmethod_1(
                  Polygon2L.BooleanOperations.SNSweepLine sweepLine,
                  List<Polygon2L.BooleanOperations.SNEdge> edgeList,
                  int x)
                {
                }

                public override void vmethod_2(
                  Polygon2L.BooleanOperations.SNSweepLine sweepLine,
                  List<Polygon2L.BooleanOperations.SNEdge> edgeList,
                  int x)
                {
                    if (this.segment.Start.Position.X == this.segment.End.Position.X)
                    {
                        long y = this.segment.Right.Position.Y;
                        Polygon2L.BooleanOperations.SNActiveSegment snActiveSegment = (Polygon2L.BooleanOperations.SNActiveSegment)null;
                        for (int index = this.topEdge.Index; index < edgeList.Count; ++index)
                        {
                            Polygon2L.BooleanOperations.SNEdge edge = edgeList[index];
                            if (!edge.IsTop)
                            {
                                if (edge.Y >= (double)y)
                                    break;
                                if (snActiveSegment == null)
                                    snActiveSegment = new Polygon2L.BooleanOperations.SNActiveSegment(this.segment);
                                snActiveSegment.method_1(sweepLine.Context, sweepLine.Context.method_0(edge.ToleranceSquareCenter));
                            }
                        }
                    }
                    else
                    {
                        this.segment.SnActiveSegmentNode = this.previous != null ? sweepLine.ActiveSegments.AddAfter(this.previous.SnActiveSegmentNode, new Polygon2L.BooleanOperations.SNActiveSegment(this.segment)) : sweepLine.ActiveSegments.AddFirst(new Polygon2L.BooleanOperations.SNActiveSegment(this.segment));
                        if (this.topEdge.LowerSegment == null)
                        {
                            this.segment.SnActiveSegmentNode.Value.method_0(this.topEdge);
                        }
                        else
                        {
                            if (this.previous != this.topEdge.LowerSegment.Segment)
                                return;
                            this.previous.SnActiveSegmentNode.Value.UpperEdge = (Polygon2L.BooleanOperations.SNEdge)null;
                            this.segment.SnActiveSegmentNode.Value.method_0(this.topEdge);
                        }
                    }
                }

                public override void vmethod_3(
                  Polygon2L.BooleanOperations.SNSweepLine sweepLine,
                  List<Polygon2L.BooleanOperations.SNEdge> edgeList,
                  int x)
                {
                }

                public override Polygon2L.BooleanOperations.Segment vmethod_4(double x)
                {
                    if (this.previous != null && this.previous.SnActiveSegmentNode != null)
                        return this.previous;
                    return (Polygon2L.BooleanOperations.Segment)null;
                }

                public override string ToString()
                {
                    return string.Format("Entry: {0}", (object)this.segment);
                }
            }

            [Serializable]
            internal class SNExitEvent : Polygon2L.BooleanOperations.SNEvent
            {
                private Polygon2L.BooleanOperations.Segment segment;

                public SNExitEvent(Point2D position, Polygon2L.BooleanOperations.Segment segment)
                  : base(position)
                {
                    this.segment = segment;
                }

                public override void vmethod_1(
                  Polygon2L.BooleanOperations.SNSweepLine sweepLine,
                  List<Polygon2L.BooleanOperations.SNEdge> edgeList,
                  int x)
                {
                }

                public override void vmethod_2(
                  Polygon2L.BooleanOperations.SNSweepLine sweepLine,
                  List<Polygon2L.BooleanOperations.SNEdge> edgeList,
                  int x)
                {
                    if (this.segment.SnActiveSegmentNode == null)
                        return;
                    Polygon2L.BooleanOperations.SNEdge upperEdge = this.segment.SnActiveSegmentNode.Value.UpperEdge;
                    if (upperEdge != null)
                    {
                        LinkedListNode<Polygon2L.BooleanOperations.SNActiveSegment> previous = this.segment.SnActiveSegmentNode.Previous;
                        if (previous == null)
                            upperEdge.LowerSegment = (Polygon2L.BooleanOperations.SNActiveSegment)null;
                        else if (previous.Value.UpperEdge == null)
                            previous.Value.method_0(upperEdge);
                        else
                            upperEdge.LowerSegment = (Polygon2L.BooleanOperations.SNActiveSegment)null;
                        this.segment.SnActiveSegmentNode.Value.UpperEdge = (Polygon2L.BooleanOperations.SNEdge)null;
                    }
                    sweepLine.ActiveSegments.Remove(this.segment.SnActiveSegmentNode);
                    this.segment.SnActiveSegmentNode = (LinkedListNode<Polygon2L.BooleanOperations.SNActiveSegment>)null;
                }

                public override void vmethod_3(
                  Polygon2L.BooleanOperations.SNSweepLine sweepLine,
                  List<Polygon2L.BooleanOperations.SNEdge> edgeList,
                  int x)
                {
                }

                public override Polygon2L.BooleanOperations.Segment vmethod_4(double x)
                {
                    if (this.segment.SnActiveSegmentNode == null)
                        return (Polygon2L.BooleanOperations.Segment)null;
                    return this.segment;
                }

                public override string ToString()
                {
                    return string.Format("Exit: {0}", (object)this.segment);
                }
            }

            [Serializable]
            internal class SNIntersectionEvent : Polygon2L.BooleanOperations.SNEvent
            {
                private Polygon2L.BooleanOperations.Segment low;
                private Polygon2L.BooleanOperations.Segment high;

                public SNIntersectionEvent(
                  Point2D position,
                  Polygon2L.BooleanOperations.Segment low,
                  Polygon2L.BooleanOperations.Segment high)
                  : base(position)
                {
                    this.low = low;
                    this.high = high;
                }

                public override void vmethod_1(
                  Polygon2L.BooleanOperations.SNSweepLine sweepLine,
                  List<Polygon2L.BooleanOperations.SNEdge> edgeList,
                  int x)
                {
                    this.method_1(sweepLine, edgeList, x);
                }

                public override void vmethod_2(
                  Polygon2L.BooleanOperations.SNSweepLine sweepLine,
                  List<Polygon2L.BooleanOperations.SNEdge> edgeList,
                  int x)
                {
                    if (this.low.SnActiveSegmentNode == null || this.high.SnActiveSegmentNode == null)
                        return;
                    this.method_1(sweepLine, edgeList, x);
                }

                public override void vmethod_3(
                  Polygon2L.BooleanOperations.SNSweepLine sweepLine,
                  List<Polygon2L.BooleanOperations.SNEdge> edgeList,
                  int x)
                {
                    this.method_1(sweepLine, edgeList, x);
                }

                private void method_1(
                  Polygon2L.BooleanOperations.SNSweepLine sweepLine,
                  List<Polygon2L.BooleanOperations.SNEdge> edgeList,
                  int x)
                {
                    Polygon2L.BooleanOperations.Context context = sweepLine.Context;
                    Polygon2L.BooleanOperations.SNActiveSegment snActiveSegment1 = this.low.SnActiveSegmentNode.Value;
                    if (snActiveSegment1.UpperEdge != null)
                    {
                        int index1 = snActiveSegment1.UpperEdge.Index;
                        int index2 = index1 + 1;
                        if (snActiveSegment1.Segment.SlopeIsPositive)
                        {
                            Polygon2L.BooleanOperations.SNEdge upperEdge = snActiveSegment1.UpperEdge;
                            if (upperEdge.Y <= this.Position.Y)
                            {
                                snActiveSegment1.UpperEdge = (Polygon2L.BooleanOperations.SNEdge)null;
                                if (this.low.SnActiveSegmentNode.Previous == null)
                                {
                                    upperEdge.LowerSegment = (Polygon2L.BooleanOperations.SNActiveSegment)null;
                                }
                                else
                                {
                                    Polygon2L.BooleanOperations.SNActiveSegment snActiveSegment2 = this.low.SnActiveSegmentNode.Previous.Value;
                                    if (snActiveSegment2.UpperEdge == null)
                                        snActiveSegment2.method_0(upperEdge);
                                    else
                                        upperEdge.LowerSegment = (Polygon2L.BooleanOperations.SNActiveSegment)null;
                                }
                                if (!upperEdge.IsTop)
                                    snActiveSegment1.method_1(context, context.method_0(upperEdge.ToleranceSquareCenter));
                                for (; index2 < edgeList.Count; ++index2)
                                {
                                    Polygon2L.BooleanOperations.SNEdge edge = edgeList[index2];
                                    if (edge.Y <= this.Position.Y && edge.LowerSegment == null)
                                    {
                                        if (!edge.IsTop)
                                            snActiveSegment1.method_1(context, context.method_0(edge.ToleranceSquareCenter));
                                    }
                                    else
                                        break;
                                }
                            }
                        }
                        Polygon2L.BooleanOperations.SNActiveSegment snActiveSegment3 = this.high.SnActiveSegmentNode.Value;
                        if (snActiveSegment3.Segment.SlopeIsNegative)
                        {
                            Polygon2L.BooleanOperations.SNEdge upperEdge = snActiveSegment3.UpperEdge;
                            if (upperEdge != null)
                                snActiveSegment1.method_0(upperEdge);
                            snActiveSegment3.UpperEdge = (Polygon2L.BooleanOperations.SNEdge)null;
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
                                Polygon2L.BooleanOperations.SNEdge edge = edgeList[index3];
                                if (edge.Y >= this.Position.Y)
                                {
                                    if (edge.IsTop)
                                        snActiveSegment3.method_1(context, context.method_0(edge.ToleranceSquareCenter));
                                }
                                else
                                    break;
                            }
                        }
                        else if (snActiveSegment3.Segment.SlopeIsPositive)
                        {
                            if (snActiveSegment3.UpperEdge == null)
                                snActiveSegment1.UpperEdge = (Polygon2L.BooleanOperations.SNEdge)null;
                            else
                                snActiveSegment1.method_0(snActiveSegment3.UpperEdge);
                        }
                    }
                    else if (this.high.SnActiveSegmentNode.Value.UpperEdge != null)
                    {
                        snActiveSegment1.method_0(this.high.SnActiveSegmentNode.Value.UpperEdge);
                        this.high.SnActiveSegmentNode.Value.UpperEdge = (Polygon2L.BooleanOperations.SNEdge)null;
                    }
                    sweepLine.ActiveSegments.Remove(this.low.SnActiveSegmentNode);
                    this.low.SnActiveSegmentNode = sweepLine.ActiveSegments.AddAfter(this.high.SnActiveSegmentNode, snActiveSegment1);
                }

                public override Polygon2L.BooleanOperations.Segment vmethod_4(double x)
                {
                    Polygon2L.BooleanOperations.Segment segment = this.Position.X <= x ? this.low : this.high;
                    if (segment.SnActiveSegmentNode == null)
                        segment = (Polygon2L.BooleanOperations.Segment)null;
                    return segment;
                }

                public override string ToString()
                {
                    return string.Format("Intersection: low: {0}, high: {1}", (object)this.low, (object)this.high);
                }
            }

            [Serializable]
            internal class SNActiveSegment
            {
                private Polygon2L.BooleanOperations.Segment segment;
                private Polygon2L.BooleanOperations.Segment remainderSubSegment;
                private Polygon2L.BooleanOperations.SNEdge upperEdge;

                public SNActiveSegment(Polygon2L.BooleanOperations.Segment segment)
                {
                    this.segment = segment;
                }

                public Polygon2L.BooleanOperations.Segment Segment
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

                public Polygon2L.BooleanOperations.Segment RemainderSubSegment
                {
                    get
                    {
                        if (this.remainderSubSegment == null)
                            this.remainderSubSegment = this.segment;
                        return this.remainderSubSegment;
                    }
                }

                public Polygon2L.BooleanOperations.SNEdge UpperEdge
                {
                    get
                    {
                        return this.upperEdge;
                    }
                    set
                    {
                        this.upperEdge = value;
                    }
                }

                public void method_0(Polygon2L.BooleanOperations.SNEdge upperEdge)
                {
                    if (this.upperEdge != null)
                        this.upperEdge.LowerSegment = (Polygon2L.BooleanOperations.SNActiveSegment)null;
                    this.upperEdge = upperEdge;
                    if (this.upperEdge == null)
                        return;
                    this.upperEdge.LowerSegment = this;
                }

                public void method_1(
                  Polygon2L.BooleanOperations.Context context,
                  Polygon2L.BooleanOperations.Point intersection)
                {
                    if (this.remainderSubSegment == null)
                        this.remainderSubSegment = this.segment;
                    if (intersection == this.remainderSubSegment.Start || intersection == this.remainderSubSegment.End)
                        return;
                    Polygon2L.BooleanOperations.Polygon polygon = this.remainderSubSegment.Polygon;
                    Polygon2L.BooleanOperations.Segment segment1 = new Polygon2L.BooleanOperations.Segment(context, this.remainderSubSegment.Start, intersection);
                    Polygon2L.BooleanOperations.Segment segment2 = new Polygon2L.BooleanOperations.Segment(context, intersection, this.remainderSubSegment.End);
                    segment2.PolygonSegmentNode = polygon.AddAfter(this.remainderSubSegment.PolygonSegmentNode, segment2);
                    segment1.PolygonSegmentNode = polygon.AddAfter(this.remainderSubSegment.PolygonSegmentNode, segment1);
                    polygon.Remove(this.remainderSubSegment);
                    this.remainderSubSegment = this.segment.IsForward ? segment2 : segment1;
                }

                public override string ToString()
                {
                    return this.segment.ToString();
                }
            }

            [Serializable]
            internal abstract class SNEdge : IComparable<Polygon2L.BooleanOperations.SNEdge>
            {
                private int index = -1;
                private Polygon2L.BooleanOperations.SNEvent sourceEvent;
                private double y;
                private Polygon2L.BooleanOperations.SNActiveSegment lowerSegment;

                public SNEdge(Polygon2L.BooleanOperations.SNEvent sourceEvent, double y)
                {
                    this.sourceEvent = sourceEvent;
                    this.y = y;
                }

                public Polygon2L.BooleanOperations.SNEvent SourceEvent
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

                public Point2L ToleranceSquareCenter
                {
                    get
                    {
                        return this.sourceEvent.RoundedPosition;
                    }
                }

                public Polygon2L.BooleanOperations.SNActiveSegment LowerSegment
                {
                    get
                    {
                        return this.lowerSegment;
                    }
                    set
                    {
                        this.lowerSegment = value;
                    }
                }

                public abstract bool IsTop { get; }

                public int CompareTo(Polygon2L.BooleanOperations.SNEdge other)
                {
                    return this.y >= other.y ? (this.y <= other.y ? (!this.IsTop || other.IsTop ? (this.IsTop || !other.IsTop ? 0 : 1) : -1) : 1) : -1;
                }

                public override string ToString()
                {
                    return string.Format("y: {0}, lowerSegment: {1}", (object)this.y, (object)this.lowerSegment);
                }
            }

            [Serializable]
            internal class SNTopEdge : Polygon2L.BooleanOperations.SNEdge
            {
                public SNTopEdge(Polygon2L.BooleanOperations.SNEvent sourceEvent, double y)
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
            }

            [Serializable]
            internal class SNBottomEdge : Polygon2L.BooleanOperations.SNEdge
            {
                public SNBottomEdge(Polygon2L.BooleanOperations.SNEvent sourceEvent, double y)
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
            }

            [Serializable]
            internal class SNSweepLine
            {
                private LinkedList<Polygon2L.BooleanOperations.SNActiveSegment> activeSegments = new LinkedList<Polygon2L.BooleanOperations.SNActiveSegment>();
                private List<Polygon2L.BooleanOperations.SNEvent> events;
                private Polygon2L.BooleanOperations.Context context;
                private double sweepLineRoundedPosition;
                private double sweepLinePosition;

                public SNSweepLine(
                  Polygon2L.BooleanOperations.Context context,
                  List<Polygon2L.BooleanOperations.SNEvent> events)
                {
                    this.context = context;
                    this.events = events;
                }

                public LinkedList<Polygon2L.BooleanOperations.SNActiveSegment> ActiveSegments
                {
                    get
                    {
                        return this.activeSegments;
                    }
                }

                public Polygon2L.BooleanOperations.Context Context
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
                    int xBatch = (int)MathUtil.RoundHalfUp(this.events[0].Position.X);
                    double num = (double)xBatch + 0.5;
                    List<Polygon2L.BooleanOperations.SNEvent> eventBatch = new List<Polygon2L.BooleanOperations.SNEvent>();
                    eventBatch.Add(this.events[0]);
                    for (int index = 1; index < this.events.Count; ++index)
                    {
                        Polygon2L.BooleanOperations.SNEvent snEvent = this.events[index];
                        if (snEvent.Position.X >= num)
                        {
                            this.method_1(xBatch, eventBatch);
                            eventBatch.Clear();
                            xBatch = (int)MathUtil.RoundHalfUp(snEvent.Position.X);
                            num = (double)xBatch + 0.5;
                        }
                        eventBatch.Add(snEvent);
                    }
                    if (eventBatch.Count <= 0)
                        return;
                    this.method_1(xBatch, eventBatch);
                }

                private void method_1(
                  int xBatch,
                  List<Polygon2L.BooleanOperations.SNEvent> eventBatch)
                {
                    this.sweepLineRoundedPosition = (double)xBatch;
                    this.sweepLinePosition = (double)xBatch - 0.5;
                    List<Polygon2L.BooleanOperations.SNEdge> edgeList = this.method_2(xBatch, eventBatch);
                    double x1 = (double)xBatch;
                    this.sweepLinePosition = x1;
                    int index;
                    for (index = 0; index < eventBatch.Count; ++index)
                    {
                        Polygon2L.BooleanOperations.SNEvent snEvent = eventBatch[index];
                        if (snEvent.Position.X < x1)
                            snEvent.vmethod_1(this, edgeList, xBatch);
                        else
                            break;
                    }
                    this.method_3(edgeList, x1, true);
                    double x2 = (double)xBatch + 0.5;
                    this.sweepLinePosition = x2;
                    for (; index < eventBatch.Count; ++index)
                    {
                        Polygon2L.BooleanOperations.SNEvent snEvent = eventBatch[index];
                        if (snEvent.Position.X <= x1)
                            snEvent.vmethod_2(this, edgeList, xBatch);
                        else
                            break;
                    }
                    for (; index < eventBatch.Count; ++index)
                        eventBatch[index].vmethod_3(this, edgeList, xBatch);
                    this.method_3(edgeList, x2, false);
                }

                private List<Polygon2L.BooleanOperations.SNEdge> method_2(
                  int xBatch,
                  List<Polygon2L.BooleanOperations.SNEvent> eventBatch)
                {
                    SortedDictionary<Polygon2L.BooleanOperations.SNEdge, Polygon2L.BooleanOperations.SNEdge> sortedDictionary = new SortedDictionary<Polygon2L.BooleanOperations.SNEdge, Polygon2L.BooleanOperations.SNEdge>();
                    foreach (Polygon2L.BooleanOperations.SNEvent sourceEvent in eventBatch)
                    {
                        int num = (int)MathUtil.RoundHalfUp(sourceEvent.Position.Y);
                        Polygon2L.BooleanOperations.SNEdge snEdge = (Polygon2L.BooleanOperations.SNEdge)new Polygon2L.BooleanOperations.SNTopEdge(sourceEvent, (double)num + 0.5);
                        Polygon2L.BooleanOperations.SNEdge edge;
                        if (sortedDictionary.TryGetValue(snEdge, out edge))
                        {
                            sourceEvent.vmethod_0(edge);
                        }
                        else
                        {
                            sourceEvent.vmethod_0(snEdge);
                            sortedDictionary.Add(snEdge, snEdge);
                            Polygon2L.BooleanOperations.SNEdge key = (Polygon2L.BooleanOperations.SNEdge)new Polygon2L.BooleanOperations.SNBottomEdge(sourceEvent, (double)num - 0.5);
                            sortedDictionary.Add(key, key);
                        }
                    }
                    List<Polygon2L.BooleanOperations.SNEdge> edges = new List<Polygon2L.BooleanOperations.SNEdge>(sortedDictionary.Count);
                    int num1 = 0;
                    foreach (KeyValuePair<Polygon2L.BooleanOperations.SNEdge, Polygon2L.BooleanOperations.SNEdge> keyValuePair in sortedDictionary)
                    {
                        Polygon2L.BooleanOperations.SNEdge snEdge = keyValuePair.Value;
                        snEdge.Index = num1++;
                        edges.Add(snEdge);
                    }
                    double x = (double)xBatch - 0.5;
                    this.method_4(edges, x);
                    using (List<Polygon2L.BooleanOperations.SNEdge>.Enumerator enumerator = edges.GetEnumerator())
                    {
                    label_21:
                        while (enumerator.MoveNext())
                        {
                            Polygon2L.BooleanOperations.SNEdge current = enumerator.Current;
                            if (current.IsTop)
                            {
                                Polygon2L.BooleanOperations.Point intersection = (Polygon2L.BooleanOperations.Point)null;
                                if (current.LowerSegment != null)
                                {
                                    LinkedListNode<Polygon2L.BooleanOperations.SNActiveSegment> linkedListNode = current.LowerSegment.Segment.SnActiveSegmentNode;
                                    double num2 = current.Y - 1.0;
                                    while (true)
                                    {
                                        if (linkedListNode != null && linkedListNode.Value.Segment.GetIntersectionYCoordinate(x) >= num2)
                                        {
                                            if (intersection == null)
                                                intersection = this.context.method_0(current.ToleranceSquareCenter);
                                            linkedListNode.Value.method_1(this.context, intersection);
                                            linkedListNode = linkedListNode.Previous;
                                        }
                                        else
                                            goto label_21;
                                    }
                                }
                            }
                        }
                    }
                    return edges;
                }

                private void method_3(
                  List<Polygon2L.BooleanOperations.SNEdge> edgeList,
                  double x,
                  bool updateSegmentToEdgeReferences)
                {
                    if (this.activeSegments.Count == 0)
                        return;
                    Polygon2L.BooleanOperations.SNSweepLine.smethod_0(edgeList);
                    Polygon2L.BooleanOperations.SNActiveSegment snActiveSegment1 = (Polygon2L.BooleanOperations.SNActiveSegment)null;
                    LinkedListNode<Polygon2L.BooleanOperations.SNActiveSegment> previous;
                    foreach (Polygon2L.BooleanOperations.SNEdge edge1 in edgeList)
                    {
                        for (; edge1.LowerSegment != null; edge1.LowerSegment = previous.Value)
                        {
                            if (edge1.LowerSegment.Segment.SlopeIsPositive)
                            {
                                if (edge1.LowerSegment.Segment.GetIntersectionYCoordinate(x) >= edge1.Y)
                                {
                                    if (!edge1.IsTop)
                                        edge1.LowerSegment.method_1(this.context, this.context.method_0(edge1.ToleranceSquareCenter));
                                    if (edge1.Index < edgeList.Count - 1)
                                    {
                                        Polygon2L.BooleanOperations.SNEdge edge2 = edgeList[edge1.Index + 1];
                                        if (edge2.LowerSegment == null)
                                            edge2.LowerSegment = edge1.LowerSegment;
                                    }
                                    previous = edge1.LowerSegment.Segment.SnActiveSegmentNode.Previous;
                                    if (previous == null || previous.Value == snActiveSegment1)
                                    {
                                        edge1.LowerSegment = (Polygon2L.BooleanOperations.SNActiveSegment)null;
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
                    Polygon2L.BooleanOperations.SNActiveSegment snActiveSegment2 = (Polygon2L.BooleanOperations.SNActiveSegment)null;
                    int index1 = edgeList.Count - 1;
                    for (int index2 = index1; index2 >= 0; --index2)
                    {
                        Polygon2L.BooleanOperations.SNEdge snEdge;
                        for (snEdge = edgeList[index2]; snEdge.LowerSegment == null; snEdge = edgeList[index2])
                        {
                            if (index2 != 0)
                            {
                                --index2;
                            }
                            else
                            {
                                snEdge = (Polygon2L.BooleanOperations.SNEdge)null;
                                break;
                            }
                        }
                        LinkedListNode<Polygon2L.BooleanOperations.SNActiveSegment> linkedListNode1 = snEdge == null ? this.activeSegments.First : snEdge.LowerSegment.Segment.SnActiveSegmentNode.Next;
                        for (; index1 >= index2; --index1)
                        {
                            Polygon2L.BooleanOperations.SNEdge edge1 = edgeList[index1];
                            for (LinkedListNode<Polygon2L.BooleanOperations.SNActiveSegment> linkedListNode2 = linkedListNode1; linkedListNode2 != null && linkedListNode2.Value != snActiveSegment2; linkedListNode2 = linkedListNode2.Next)
                            {
                                if (linkedListNode2.Value.Segment.SlopeIsNegative)
                                {
                                    if (linkedListNode2.Value.Segment.GetIntersectionYCoordinate(x) < edge1.Y)
                                    {
                                        if (edge1.IsTop && linkedListNode2.Value.Segment.SlopeIsNegative)
                                            linkedListNode2.Value.method_1(this.context, this.context.method_0(edge1.ToleranceSquareCenter));
                                        if (edge1.Index < edgeList.Count - 1)
                                        {
                                            Polygon2L.BooleanOperations.SNEdge edge2 = edgeList[edge1.Index + 1];
                                            if (edge2.LowerSegment == linkedListNode2.Value)
                                                edge2.LowerSegment = (Polygon2L.BooleanOperations.SNActiveSegment)null;
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
                    foreach (Polygon2L.BooleanOperations.SNEdge edge in edgeList)
                    {
                        if (edge.LowerSegment != null)
                            edge.LowerSegment.UpperEdge = edge;
                    }
                }

                private static void smethod_0(List<Polygon2L.BooleanOperations.SNEdge> edgeList)
                {
                    foreach (Polygon2L.BooleanOperations.SNEdge edge in edgeList)
                    {
                        if (edge.LowerSegment != null)
                            edge.LowerSegment.UpperEdge = (Polygon2L.BooleanOperations.SNEdge)null;
                    }
                }

                private void method_4(List<Polygon2L.BooleanOperations.SNEdge> edges, double x)
                {
                    Polygon2L.BooleanOperations.SNEdge snEdge = (Polygon2L.BooleanOperations.SNEdge)null;
                    Polygon2L.BooleanOperations.SNActiveSegment lastConnectedSegment = (Polygon2L.BooleanOperations.SNActiveSegment)null;
                    foreach (Polygon2L.BooleanOperations.SNEdge edge in edges)
                    {
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
            internal class Intersection : IComparable<Polygon2L.BooleanOperations.Intersection>
            {
                private LongRational parameter;
                private Polygon2L.BooleanOperations.Point point;

                public Intersection(LongRational parameter, Polygon2L.BooleanOperations.Point point)
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

                public Polygon2L.BooleanOperations.Point Point
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

                public int CompareTo(Polygon2L.BooleanOperations.Intersection other)
                {
                    if (this.parameter < other.parameter)
                        return -1;
                    return this.parameter > other.parameter ? 1 : 0;
                }
            }

            [Serializable]
            public class Context
            {
                private Dictionary<Point2L, Polygon2L.BooleanOperations.Point> pointDictionary = new Dictionary<Point2L, Polygon2L.BooleanOperations.Point>();
                private int currentSegmentId = 1;

                internal Polygon2L.BooleanOperations.Point method_0(Point2L p)
                {
                    Polygon2L.BooleanOperations.Point point;
                    if (!this.pointDictionary.TryGetValue(p, out point))
                    {
                        point = new Polygon2L.BooleanOperations.Point(p);
                        this.pointDictionary.Add(p, point);
                    }
                    return point;
                }

                public int GetNextSegmentId()
                {
                    return this.currentSegmentId++;
                }

                internal void method_1()
                {
                    foreach (KeyValuePair<Point2L, Polygon2L.BooleanOperations.Point> point in this.pointDictionary)
                        point.Value.Vertices.Clear();
                }
            }

            [Serializable]
            internal class DebugInfo
            {
                private Polygon2L.BooleanOperations.Region region1;
                private Polygon2L.BooleanOperations.Region region2;
                private Polygon2L.BooleanOperations.Region resultRegion;
                private List<Polygon2L.BooleanOperations.Segment> segments;
                private Polygon2L.BooleanOperations.Segment highlightSegment;
                private Polygon2L.BooleanOperations.SNSweepLine snSweepLine;
                private List<Polygon2L.BooleanOperations.SNEdge> edgeList;

                public Polygon2L.BooleanOperations.Region Region1
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

                public Polygon2L.BooleanOperations.Region Region2
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

                public Polygon2L.BooleanOperations.Region ResultRegion
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

                public List<Polygon2L.BooleanOperations.Segment> Segments
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

                public Polygon2L.BooleanOperations.Segment HighlightSegment
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

                public Polygon2L.BooleanOperations.SNSweepLine SnSweepLine
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

                public List<Polygon2L.BooleanOperations.SNEdge> EdgeList
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
