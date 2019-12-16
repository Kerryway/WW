// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Polygon2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using ns3;
using ns8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using WW.Collections.Generic;

namespace WW.Math.Geometry
{
    [Serializable]
    public class Polygon2D : List<Point2D>, IShape2D
    {
        public const double DefaultBooleanOperationPrecision = 1E-08;

        public static List<Polygon2D> GetIntersection(
          IList<Polygon2D> input1,
          IList<Polygon2D> input2)
        {
            return Polygon2D.BooleanOperations.GetIntersection(input1, input2, 1E-08);
        }

        public static List<Polygon2D> GetIntersection(
          IList<Polygon2D> input1,
          IList<Polygon2D> input2,
          double precision)
        {
            if (precision <= 0.0)
                throw new ArgumentException("precision must not be zero or negative", nameof(precision));
            return Polygon2D.BooleanOperations.GetIntersection(input1, input2, precision);
        }

        public static List<Polygon2D> GetDifference(
          IList<Polygon2D> input1,
          IList<Polygon2D> input2)
        {
            return Polygon2D.BooleanOperations.GetDifference(input1, input2, 1E-08);
        }

        public static List<Polygon2D> GetDifference(
          IList<Polygon2D> input1,
          IList<Polygon2D> input2,
          double precision)
        {
            if (precision <= 0.0)
                throw new ArgumentException("precision must not be zero or negative", nameof(precision));
            return Polygon2D.BooleanOperations.GetDifference(input1, input2, precision);
        }

        public static List<Polygon2D> GetUnion(
          IList<Polygon2D> input1,
          IList<Polygon2D> input2)
        {
            return Polygon2D.BooleanOperations.GetUnion(input1, input2, 1E-08);
        }

        public static List<Polygon2D> GetUnion(
          IList<Polygon2D> input1,
          IList<Polygon2D> input2,
          double precision)
        {
            if (precision <= 0.0)
                throw new ArgumentException("precision must not be zero or negative", nameof(precision));
            return Polygon2D.BooleanOperations.GetUnion(input1, input2, precision);
        }

        public static List<Polygon2D> GetExclusiveOr(
          IList<Polygon2D> region1,
          IList<Polygon2D> region2)
        {
            return Polygon2D.BooleanOperations.GetExclusiveOr(region1, region2, 1E-08);
        }

        public static List<Polygon2D> GetExclusiveOr(
          IList<Polygon2D> region1,
          IList<Polygon2D> region2,
          double precision)
        {
            if (precision <= 0.0)
                throw new ArgumentException("precision must not be zero or negative", nameof(precision));
            return Polygon2D.BooleanOperations.GetExclusiveOr(region1, region2, precision);
        }

        public Polygon2D()
        {
        }

        public Polygon2D(int capacity)
          : base(capacity)
        {
        }

        public Polygon2D(params Point2D[] points)
          : base((IEnumerable<Point2D>)points)
        {
        }

        public Polygon2D(IEnumerable<Point2D> points)
          : base(points)
        {
        }

        public Polygon2D(Polygon2D polyline)
          : base((IEnumerable<Point2D>)polyline)
        {
        }

        public Bounds2D GetBounds()
        {
            Bounds2D bounds2D = new Bounds2D();
            foreach (Point2D p in (List<Point2D>)this)
                bounds2D.Update(p);
            return bounds2D;
        }

        public Point2D? GetCentroid()
        {
            return Polygon2D.GetCentroid((IList<Point2D>)this);
        }

        public Point2D? GetCentroid(out double area)
        {
            return Polygon2D.GetCentroid((IList<Point2D>)this, out area);
        }

        public bool IsConvex()
        {
            int count = this.Count;
            if (count <= 3)
                return true;
            double num1 = 0.0;
            Point2D point2D1 = this[count - 2];
            Point2D point2D2 = this[count - 1];
            Vector2D u = point2D2 - point2D1;
            for (int index = 0; index < count; ++index)
            {
                Point2D point2D3 = this[index];
                Vector2D v = point2D3 - point2D2;
                double num2 = Vector2D.CrossProduct(u, v);
                if (num1 == 0.0)
                    num1 = num2;
                else if (num2 != 0.0)
                {
                    if (num2 > 0.0)
                    {
                        if (num1 < 0.0)
                            return false;
                    }
                    else if (num1 > 0.0)
                        return false;
                }
                u = v;
                point2D2 = point2D3;
            }
            return true;
        }

        public bool IsInside(Point2D p)
        {
            return (Polygon2D.GetWindingNumber(p.X, p.Y, (IList<Point2D>)this) & 1) == 1;
        }

        public int GetNoOfIntersections(Ray2D ray)
        {
            return Polygon2D.GetNoOfIntersections((IList<Point2D>)this, ray);
        }

        public bool IsClockwise()
        {
            return Polygon2D.IsClockwise((IList<Point2D>)this);
        }

        public double GetArea()
        {
            return Polygon2D.GetArea((IList<Point2D>)this);
        }

        public void Outset(double distance)
        {
            Polygon2D.Outset((IList<Point2D>)this, distance);
        }

        public void RightSet(double distance)
        {
            Polygon2D.RightSet((IList<Point2D>)this, distance);
        }

        public Polygon2D GetReverse()
        {
            Polygon2D polygon2D = new Polygon2D(this.Count);
            for (int index = this.Count - 1; index >= 0; --index)
                polygon2D.Add(this[index]);
            return polygon2D;
        }

        public static bool Overlap(ICollection<IList<Point2D>> polygons)
        {
            return Polygon2D.Class14.smethod_0(polygons, 8.88178419700125E-16);
        }

        public static bool Overlap(ICollection<IList<Point2D>> polygons, double precision)
        {
            return Polygon2D.Class14.smethod_0(polygons, precision);
        }

        public void TransformMe(Matrix3D matrix)
        {
            for (int index = 0; index < this.Count; ++index)
                this[index] = matrix.Transform(this[index]);
        }

        public ISegment2DIterator CreateIterator()
        {
            return Polygon2D.Class21.smethod_0((List<Point2D>)this);
        }

        public void AddToBounds(Bounds2D bounds)
        {
            foreach (Point2D p in (List<Point2D>)this)
                bounds.Update(p);
        }

        public bool HasSegments
        {
            get
            {
                return this.Count > 0;
            }
        }

        public static bool IsInside(Point2D p, IList<Point2D> polygon)
        {
            return (Polygon2D.GetWindingNumber(p.X, p.Y, polygon) & 1) == 1;
        }

        public static bool IsInsidePolygons(Point2D p, IEnumerator polygonsEnumerator)
        {
            if (polygonsEnumerator == null)
                return false;
            int num = 0;
            polygonsEnumerator.Reset();
            while (polygonsEnumerator.MoveNext())
                num += Polygon2D.GetWindingNumber(p.X, p.Y, (IList<Point2D>)polygonsEnumerator.Current);
            return (num & 1) == 1;
        }

        public static bool IsInside(Point2D p, IEnumerable<IList<Point2D>> polygons)
        {
            return Polygon2D.IsInsidePolygons(p, (IEnumerator)polygons.GetEnumerator());
        }

        public static int GetWindingNumber(Point2D p, IEnumerable<IList<Point2D>> polygons)
        {
            return Polygon2D.GetWindingNumber(p.X, p.Y, polygons);
        }

        public static int GetWindingNumber(double x, double y, IEnumerable<IList<Point2D>> polygons)
        {
            int num = 0;
            foreach (IList<Point2D> polygon in polygons)
                num += Polygon2D.GetWindingNumber(x, y, polygon);
            return num;
        }

        public static int GetWindingNumber(Point2D p, IList<Point2D> polygon)
        {
            return Polygon2D.GetWindingNumber(p.X, p.Y, polygon);
        }

        public static int GetWindingNumber(double x, double y, IList<Point2D> polygon)
        {
            int num = 0;
            int count = polygon.Count;
            if (count > 0)
            {
                Point2D point2D1 = polygon[count - 1];
                for (int index = 0; index < count; ++index)
                {
                    Point2D point2D2 = polygon[index];
                    if (point2D1.Y <= y)
                    {
                        if (point2D2.Y > y && Polygon2D.smethod_4(point2D1.X, point2D1.Y, point2D2.X, point2D2.Y, x, y) > 0.0)
                            ++num;
                    }
                    else if (point2D2.Y <= y && Polygon2D.smethod_4(point2D1.X, point2D1.Y, point2D2.X, point2D2.Y, x, y) < 0.0)
                        --num;
                    point2D1 = point2D2;
                }
            }
            return num;
        }

        public static int GetNoOfIntersections(IList<Point2D> polygon, Ray2D ray)
        {
            return Polygon2D.GetNoOfIntersections(polygon, ray, 0, polygon.Count - 1);
        }

        public static int GetNoOfIntersections(
          IList<Point2D> points,
          Ray2D ray,
          int startIndex,
          int endIndex)
        {
            if (endIndex - startIndex < 1)
                return 0;
            int num = 0;
            Point2D start = points[startIndex];
            Point2D end = start;
            for (int index = startIndex + 1; index <= endIndex; ++index)
            {
                Point2D point = points[index];
                Segment2D b = new Segment2D(start, point);
                if (Ray2D.Intersects(ray, b))
                    ++num;
                start = point;
            }
            Segment2D b1 = new Segment2D(start, end);
            if (Ray2D.Intersects(ray, b1))
                ++num;
            return num;
        }

        public static bool IsClockwise(IList<Point2D> polygon)
        {
            return Polygon2D.smethod_0(polygon) < 0.0;
        }

        public static double GetArea(IList<Point2D> polygon)
        {
            return 0.5 * Polygon2D.smethod_0(polygon);
        }

        private static double smethod_0(IList<Point2D> polygon)
        {
            int count = polygon.Count;
            if (count < 3)
                return 0.0;
            double num = 0.0;
            Point2D point2D1 = polygon[count - 1];
            for (int index = 0; index < count; ++index)
            {
                Point2D point2D2 = polygon[index];
                num += point2D1.X * point2D2.Y - point2D2.X * point2D1.Y;
                point2D1 = point2D2;
            }
            return num;
        }

        public static bool IsClockwise(Point2D p0, Point2D p1, Point2D p2, Point2D p3)
        {
            return Polygon2D.smethod_1(p0, p1, p2, p3) < 0.0;
        }

        public static double GetArea(Point2D p0, Point2D p1, Point2D p2, Point2D p3)
        {
            return 0.5 * Polygon2D.smethod_1(p0, p1, p2, p3);
        }

        private static double smethod_1(Point2D p0, Point2D p1, Point2D p2, Point2D p3)
        {
            return 0.0 + (p0.X * p1.Y - p1.X * p0.Y) + (p1.X * p2.Y - p2.X * p1.Y) + (p2.X * p3.Y - p3.X * p2.Y) + (p3.X * p0.Y - p0.X * p3.Y);
        }

        public static Point2D? GetCentroid(IList<Point2D> polygon)
        {
            double area;
            return Polygon2D.GetCentroid(polygon, out area);
        }

        public static Point2D? GetCentroid(IList<Point2D> polygon, out double area)
        {
            int count = polygon.Count;
            area = 0.0;
            if (count < 3)
            {
                switch (count)
                {
                    case 0:
                        return new Point2D?();
                    case 1:
                        return new Point2D?(polygon[0]);
                    case 2:
                        Point2D point2D1 = polygon[0];
                        Point2D point2D2 = polygon[0];
                        return new Point2D?(new Point2D(0.5 * (point2D1.X + point2D2.X), 0.5 * (point2D1.Y + point2D2.Y)));
                }
            }
            Point2D point2D3 = polygon[count - 1];
            Point2D zero = Point2D.Zero;
            for (int index = 0; index < count; ++index)
            {
                Point2D point2D4 = polygon[index];
                double num = point2D3.X * point2D4.Y - point2D4.X * point2D3.Y;
                area += num;
                zero.X += (point2D3.X + point2D4.X) * num;
                zero.Y += (point2D3.Y + point2D4.Y) * num;
                point2D3 = point2D4;
            }
            area /= 2.0;
            zero.X /= 6.0 * area;
            zero.Y /= 6.0 * area;
            return new Point2D?(zero);
        }

        public static void Outset(IList<Point2D> polygon, double distance)
        {
            if (Polygon2D.IsClockwise(polygon))
                distance = -distance;
            Polygon2D.RightSet(polygon, distance);
        }

        public static void RightSet(IList<Point2D> polygon, double distance)
        {
            if (polygon.Count < 2)
                return;
            int count = polygon.Count;
            Point2D point2D1 = polygon[0];
            Point2D point2D2 = polygon[1];
            Vector2D unit = (point2D2 - point2D1).GetUnit();
            Vector2D vector2D1 = new Vector2D(unit.Y, -unit.X);
            Vector2D vector2D2 = vector2D1 * distance;
            Line2D a1 = new Line2D(point2D1 + vector2D2, unit);
            Line2D? nullable = new Line2D?(a1);
            Point2D point2D3 = point2D2;
            Point2D? intersection;
            for (int index = 2; index <= count; ++index)
            {
                Point2D point2D4 = polygon[index % count];
                unit = (point2D4 - point2D3).GetUnit();
                vector2D1 = new Vector2D(unit.Y, -unit.X);
                Vector2D vector2D3 = vector2D1 * distance;
                Line2D a2 = new Line2D(point2D3 + vector2D3, unit);
                if (nullable.HasValue)
                {
                    intersection = Line2D.GetIntersection(a2, nullable.Value);
                    if (intersection.HasValue)
                        polygon[index - 1] = intersection.Value;
                }
                nullable = new Line2D?(a2);
                point2D3 = point2D4;
            }
            intersection = Line2D.GetIntersection(a1, nullable.Value);
            if (!intersection.HasValue)
                return;
            polygon[0] = intersection.Value;
        }

        public static void GetSegments(IList<Point2D> polygon, IList<Segment2D> segments)
        {
            int count = polygon.Count;
            Point2D start = polygon[count - 1];
            for (int index = 0; index < count; ++index)
            {
                Point2D end = polygon[index];
                Segment2D segment2D = new Segment2D(start, end);
                segments.Add(segment2D);
                start = end;
            }
        }

        public Polygon2D GetConvexHull()
        {
            return Polygon2D.GetConvexHull((IList<Point2D>)this);
        }

        public Polygon2D GetConvexHull(double precision)
        {
            return Polygon2D.GetConvexHull((IList<Point2D>)this, precision);
        }

        public static Polygon2D GetConvexHull(IList<Point2D> polygon)
        {
            return Polygon2D.GetConvexHull(polygon, 8.88178419700125E-16);
        }

        public static Polygon2D GetConvexHull(IList<Point2D> polygon, double precision)
        {
            double num1 = precision * precision;
            LinkedList<Point2D> linkedList = new LinkedList<Point2D>();
            int num2;
            for (num2 = 0; num2 + 2 < polygon.Count; ++num2)
            {
                double num3 = Polygon2D.smethod_2(polygon[0], polygon[num2 + 1], polygon[num2 + 2]);
                if (num3 <= num1)
                {
                    if (num3 < -num1)
                    {
                        linkedList.AddLast(polygon[num2 + 2]);
                        linkedList.AddLast(polygon[num2 + 2]);
                        LinkedListNode<Point2D> node = linkedList.AddAfter(linkedList.First, polygon[num2 + 1]);
                        linkedList.AddAfter(node, polygon[0]);
                        break;
                    }
                }
                else
                {
                    linkedList.AddLast(polygon[num2 + 2]);
                    linkedList.AddLast(polygon[num2 + 2]);
                    LinkedListNode<Point2D> node = linkedList.AddAfter(linkedList.First, polygon[0]);
                    linkedList.AddAfter(node, polygon[num2 + 1]);
                    break;
                }
            }
            for (int index = num2 + 3; index < polygon.Count; ++index)
            {
                Point2D p2 = polygon[index];
                if (Polygon2D.smethod_2(linkedList.First.Value, linkedList.First.Next.Value, p2) <= num1 || Polygon2D.smethod_2(linkedList.Last.Previous.Value, linkedList.Last.Value, p2) <= num1)
                {
                    while (linkedList.First.Next != null && Polygon2D.smethod_2(linkedList.First.Value, linkedList.First.Next.Value, p2) < num1)
                        linkedList.RemoveFirst();
                    linkedList.AddFirst(p2);
                    while (linkedList.Last.Previous != null && Polygon2D.smethod_2(linkedList.Last.Previous.Value, linkedList.Last.Value, p2) < num1)
                        linkedList.RemoveLast();
                    linkedList.AddLast(p2);
                }
            }
            Polygon2D polygon2D = new Polygon2D();
            LinkedListNode<Point2D> linkedListNode = linkedList.First;
            for (int index = 1; index < linkedList.Count; ++index)
            {
                LinkedListNode<Point2D> next = linkedListNode.Next;
                polygon2D.Add(linkedListNode.Value);
                linkedListNode = next;
            }
            return polygon2D;
        }

        private static double smethod_2(Point2D p0, Point2D p1, Point2D p2)
        {
            return (p1.X - p0.X) * (p2.Y - p0.Y) - (p2.X - p0.X) * (p1.Y - p0.Y);
        }

        public OrientedRectangle2D GetMinimumAreaRectangle()
        {
            return Polygon2D.GetMinimumAreaRectangle((IList<Point2D>)this);
        }

        public static OrientedRectangle2D GetMinimumAreaRectangle(
          IList<Point2D> convexPolygon)
        {
            int j1 = 0;
            int count = convexPolygon.Count;
            Vector2D unit1 = new Segment2D(convexPolygon[count - 1], convexPolygon[0]).GetDelta().GetUnit();
            Vector2D vector2D1 = new Vector2D(-unit1.Y, unit1.X);
            Vector2D v = convexPolygon[0] - Point2D.Zero;
            double num1 = Vector2D.DotProduct(-vector2D1, v);
            double projection1 = Vector2D.DotProduct(unit1, v);
            Polygon2D.smethod_3(convexPolygon, count, unit1, ref j1, ref projection1);
            int j2 = j1;
            double projection2 = Vector2D.DotProduct(vector2D1, convexPolygon[j2] - Point2D.Zero);
            Polygon2D.smethod_3(convexPolygon, count, vector2D1, ref j2, ref projection2);
            int j3 = j2;
            double projection3 = Vector2D.DotProduct(-unit1, convexPolygon[j3] - Point2D.Zero);
            Polygon2D.smethod_3(convexPolygon, count, -unit1, ref j3, ref projection3);
            double num2 = System.Math.Abs((projection1 + projection3) * (num1 + projection2));
            Point2D origin1 = Point2D.Zero - projection3 * unit1 - num1 * vector2D1;
            OrientedRectangle2D orientedRectangle2D = new OrientedRectangle2D(origin1, Point2D.Zero + projection1 * unit1 - num1 * vector2D1 - origin1, Point2D.Zero - projection3 * unit1 + projection2 * vector2D1 - origin1);
            for (int index = 1; index < count; ++index)
            {
                Vector2D unit2 = new Segment2D(convexPolygon[index - 1], convexPolygon[index]).GetDelta().GetUnit();
                Vector2D vector2D2 = new Vector2D(-unit2.Y, unit2.X);
                double num3 = Vector2D.DotProduct(-vector2D2, convexPolygon[index] - Point2D.Zero);
                double projection4 = Vector2D.DotProduct(unit2, convexPolygon[j1] - Point2D.Zero);
                double projection5 = Vector2D.DotProduct(vector2D2, convexPolygon[j2] - Point2D.Zero);
                double projection6 = Vector2D.DotProduct(-unit2, convexPolygon[j3] - Point2D.Zero);
                Polygon2D.smethod_3(convexPolygon, count, unit2, ref j1, ref projection4);
                Polygon2D.smethod_3(convexPolygon, count, vector2D2, ref j2, ref projection5);
                Polygon2D.smethod_3(convexPolygon, count, -unit2, ref j3, ref projection6);
                double num4 = System.Math.Abs((projection4 + projection6) * (num3 + projection5));
                if (num4 < num2)
                {
                    num2 = num4;
                    Point2D origin2 = Point2D.Zero - projection6 * unit2 - num3 * vector2D2;
                    orientedRectangle2D = new OrientedRectangle2D(origin2, Point2D.Zero + projection4 * unit2 - num3 * vector2D2 - origin2, Point2D.Zero - projection6 * unit2 + projection5 * vector2D2 - origin2);
                }
            }
            return orientedRectangle2D;
        }

        private static void smethod_3(
          IList<Point2D> convexPolygon,
          int n,
          Vector2D direction,
          ref int j,
          ref double projection)
        {
            int num1 = j;
            j = (j + 1) % n;
            while (j != num1)
            {
                double num2 = Vector2D.DotProduct(direction, convexPolygon[j] - Point2D.Zero);
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

        internal bool method_0(Point2D p)
        {
            return (0 + this.GetNoOfIntersections(new Ray2D(p, Vector2D.XAxis))) % 2 == 1;
        }

        private static double smethod_4(
          double x1,
          double y1,
          double x2,
          double y2,
          double x3,
          double y3)
        {
            return (x2 - x1) * (y3 - y1) - (y2 - y1) * (x3 - x1);
        }

        public class BooleanOperations
        {
            static BooleanOperations()
            {
                Class123.smethod_0(Enum0.const_2);
            }

            public static List<Polygon2D> GetUnion(IList<Polygon2D> input1, IList<Polygon2D> input2)
            {
                return Polygon2D.BooleanOperations.GetUnion(input1, input2, 1E-08);
            }

            public static List<Polygon2D> GetUnion(IList<Polygon2D> input1, IList<Polygon2D> input2, double precision)
            {
                if (precision <= 0)
                {
                    throw new ArgumentException("precision must not be zero or negative", "precision");
                }
                return Polygon2D.BooleanOperations.GetUnion(input1, input2, precision);
            }

            public static List<Polygon2D> GetDifference(IList<Polygon2D> region1, IList<Polygon2D> region2)
            {
                return Polygon2D.BooleanOperations.GetDifference(region1, region2, 1E-08);
            }

            public static List<Polygon2D> GetDifference(IList<Polygon2D> region1, IList<Polygon2D> region2, double precision)
            {
                Polygon2D.BooleanOperations.Region region;
                List<Polygon2D.BooleanOperations.Segment> segments;
                Polygon2D.BooleanOperations.Region region3;
                Polygon2D.BooleanOperations.smethod_0(region1, false, region2, true, precision, out region3, out region, out segments);
                Polygon2D.BooleanOperations.Region region4 = new Polygon2D.BooleanOperations.Region(false);
                int count = segments.Count;
                foreach (Polygon2D.BooleanOperations.Segment segment in segments)
                {
                    if (segment.Processed)
                    {
                        continue;
                    }
                    Polygon2D.BooleanOperations.smethod_4(segment, region4, (Polygon2D.BooleanOperations.Segment s) => (s.Region != region3 ? s.Status == Polygon2D.BooleanOperations.SegmentStatus.Inside : (s.Status == Polygon2D.BooleanOperations.SegmentStatus.Inside ? true : s.Status == Polygon2D.BooleanOperations.SegmentStatus.Shared)), ref count);
                }
                return region4.ToPolygon2DList();
            }

            public static List<Polygon2D> GetIntersection(IList<Polygon2D> region1, IList<Polygon2D> region2)
            {
                return Polygon2D.BooleanOperations.GetIntersection(region1, region2, 1E-08);
            }

            public static List<Polygon2D> GetIntersection(IList<Polygon2D> region1, IList<Polygon2D> region2, double precision)
            {
                Polygon2D.BooleanOperations.Region region;
                List<Polygon2D.BooleanOperations.Segment> segments;
                Polygon2D.BooleanOperations.Region region3;
                Polygon2D.BooleanOperations.smethod_0(region1, false, region2, false, precision, out region3, out region, out segments);
                Polygon2D.BooleanOperations.Region region4 = new Polygon2D.BooleanOperations.Region(false);
                int count = segments.Count;
                foreach (Polygon2D.BooleanOperations.Segment segment in segments)
                {
                    if (segment.Processed)
                    {
                        continue;
                    }
                    Polygon2D.BooleanOperations.smethod_4(segment, region4, (Polygon2D.BooleanOperations.Segment s) => (s.Region != region3 ? s.Status == Polygon2D.BooleanOperations.SegmentStatus.Inside : (s.Status == Polygon2D.BooleanOperations.SegmentStatus.Inside ? true : s.Status == Polygon2D.BooleanOperations.SegmentStatus.Shared)), ref count);
                }
                return region4.ToPolygon2DList();
            }

            public static List<Polygon2D> GetExclusiveOr(
        IList<Polygon2D> region1,
        IList<Polygon2D> region2)
            {
                return Polygon2D.BooleanOperations.GetExclusiveOr(region1, region2, 1E-08);
            }

            public static List<Polygon2D> GetExclusiveOr(
              IList<Polygon2D> region1,
              IList<Polygon2D> region2,
              double precision)
            {
                Polygon2D.BooleanOperations.Region splitRegion1;
                Polygon2D.BooleanOperations.Region splitRegion2;
                List<Polygon2D.BooleanOperations.Segment> segments;
                Polygon2D.BooleanOperations.smethod_0(region1, false, region2, false, precision, out splitRegion1, out splitRegion2, out segments);
                foreach (Polygon2D.BooleanOperations.Segment segment in segments)
                {
                    if (segment.Status == Polygon2D.BooleanOperations.SegmentStatus.Inside)
                        segment.Reverse();
                }
                Polygon2D.BooleanOperations.Region resultRegion = new Polygon2D.BooleanOperations.Region(false);
                int count = segments.Count;
                foreach (Polygon2D.BooleanOperations.Segment startSegment in segments)
                {
                    if (!startSegment.Processed)
                        Polygon2D.BooleanOperations.smethod_4(startSegment, resultRegion, (Func<Polygon2D.BooleanOperations.Segment, bool>)(s =>
                       {
                           if (s.Status != Polygon2D.BooleanOperations.SegmentStatus.Outside)
                               return s.Status == Polygon2D.BooleanOperations.SegmentStatus.Inside;
                           return true;
                       }), ref count);
                }
                return resultRegion.ToPolygon2DList();
            }

            private static void smethod_0(
              IList<Polygon2D> region1,
              bool reverseRegion1,
              IList<Polygon2D> region2,
              bool reverseRegion2,
              double precision,
              out Polygon2D.BooleanOperations.Region splitRegion1,
              out Polygon2D.BooleanOperations.Region splitRegion2,
              out List<Polygon2D.BooleanOperations.Segment> segments)
            {
                Polygon2D.BooleanOperations.Class5 pointMerger = new Polygon2D.BooleanOperations.Class5(precision);
                Polygon2D.BooleanOperations.Class9 mergedRegion1 = Polygon2D.BooleanOperations.smethod_1(region1, pointMerger);
                Polygon2D.BooleanOperations.Class9 mergedRegion2 = Polygon2D.BooleanOperations.smethod_1(region2, pointMerger);
                region1 = Polygon2D.BooleanOperations.smethod_2(mergedRegion1);
                region2 = Polygon2D.BooleanOperations.smethod_2(mergedRegion2);
                Polygon2D.BooleanOperations.Context context = new Polygon2D.BooleanOperations.Context();
                Polygon2D.BooleanOperations.Region region3 = Polygon2D.BooleanOperations.smethod_7(region1, context, reverseRegion1);
                Polygon2D.BooleanOperations.Region region4 = Polygon2D.BooleanOperations.smethod_7(region2, context, reverseRegion2);
                Polygon2D.BooleanOperations.Class22 eventQueue = new Polygon2D.BooleanOperations.Class22();
                eventQueue.method_4(region3, precision);
                eventQueue.method_4(region4, precision);
                new Polygon2D.BooleanOperations.Class3(eventQueue, context, precision).method_0();
                context.method_1();
                splitRegion1 = Polygon2D.BooleanOperations.smethod_5(region3);
                splitRegion2 = Polygon2D.BooleanOperations.smethod_5(region4);
                segments = new List<Polygon2D.BooleanOperations.Segment>();
                splitRegion1.GetSegments((IList<Polygon2D.BooleanOperations.Segment>)segments);
                splitRegion2.GetSegments((IList<Polygon2D.BooleanOperations.Segment>)segments);
                Polygon2D.BooleanOperations.smethod_3(splitRegion1);
                Polygon2D.BooleanOperations.smethod_3(splitRegion2);
                splitRegion1.CalculateSegmentStatus(splitRegion2);
                splitRegion2.CalculateSegmentStatus(splitRegion1);
            }

            private static Polygon2D.BooleanOperations.Class9 smethod_1(
              IList<Polygon2D> region,
              Polygon2D.BooleanOperations.Class5 pointMerger)
            {
                Polygon2D.BooleanOperations.Class9 class9 = new Polygon2D.BooleanOperations.Class9();
                foreach (Polygon2D polygon2D in (IEnumerable<Polygon2D>)region)
                {
                    Polygon2D.BooleanOperations.Class8 class8 = new Polygon2D.BooleanOperations.Class8();
                    class9.Add(class8);
                    foreach (Point2D p in (List<Point2D>)polygon2D)
                    {
                        Polygon2D.BooleanOperations.Class6 class6 = pointMerger.method_0(p);
                        class8.Add(class6);
                    }
                }
                return class9;
            }

            private static IList<Polygon2D> smethod_2(
              Polygon2D.BooleanOperations.Class9 mergedRegion)
            {
                IList<Polygon2D> polygon2DList = (IList<Polygon2D>)new List<Polygon2D>(mergedRegion.Count);
                for (int index1 = 0; index1 < mergedRegion.Count; ++index1)
                {
                    Polygon2D.BooleanOperations.Class8 class8 = mergedRegion[index1];
                    if (class8.Count > 2)
                    {
                        Polygon2D polygon2D = new Polygon2D(class8.Count);
                        Point2D point2D1 = class8[class8.Count - 1].method_2();
                        for (int index2 = 0; index2 < class8.Count; ++index2)
                        {
                            Point2D point2D2 = class8[index2].method_2();
                            if (point2D2 != point2D1)
                                polygon2D.Add(point2D2);
                            point2D1 = point2D2;
                        }
                        if (polygon2D.Count > 2)
                            polygon2DList.Add(polygon2D);
                    }
                }
                return polygon2DList;
            }

            private static void smethod_3(Polygon2D.BooleanOperations.Region region)
            {
                foreach (List<Polygon2D.BooleanOperations.Segment> segmentList in (List<Polygon2D.BooleanOperations.Polygon>)region)
                {
                    foreach (Polygon2D.BooleanOperations.Segment segment in segmentList)
                    {
                        bool flag = false;
                        foreach (Polygon2D.BooleanOperations.Vertex vertex in segment.Start.Vertices)
                        {
                            if (vertex.InSegment != segment && vertex.InSegment.Status != Polygon2D.BooleanOperations.SegmentStatus.SelfOverlap && vertex.InSegment.Start == segment.End)
                            {
                                segment.Status = Polygon2D.BooleanOperations.SegmentStatus.SelfOverlap;
                                vertex.InSegment.Status = Polygon2D.BooleanOperations.SegmentStatus.SelfOverlap;
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                            break;
                    }
                }
                foreach (Polygon2D.BooleanOperations.Polygon polygon in (List<Polygon2D.BooleanOperations.Polygon>)region)
                {
                    for (int index = polygon.Count - 1; index >= 0; --index)
                    {
                        if (polygon[index].Status == Polygon2D.BooleanOperations.SegmentStatus.SelfOverlap)
                            polygon.RemoveAt(index);
                    }
                }
            }

            private static void smethod_4(
              Polygon2D.BooleanOperations.Segment startSegment,
              Polygon2D.BooleanOperations.Region resultRegion,
              Func<Polygon2D.BooleanOperations.Segment, bool> includeSegment,
              ref int n)
            {
                Polygon2D.BooleanOperations.Segment segment1 = startSegment;
                Polygon2D.BooleanOperations.Polygon polygon = (Polygon2D.BooleanOperations.Polygon)null;
                Polygon2D.BooleanOperations.Segment segment2 = (Polygon2D.BooleanOperations.Segment)null;
                while (n > 0)
                {
                    segment1.Processed = true;
                    --n;
                    if (!includeSegment(segment1))
                        break;
                    if (segment2 == null)
                    {
                        segment2 = segment1;
                        polygon = new Polygon2D.BooleanOperations.Polygon(resultRegion);
                        resultRegion.Add(polygon);
                    }
                    polygon.Add(segment1);
                    if (segment1.End == segment2.Start)
                        break;
                    segment1 = segment1.End.GetNextUnprocessedSegment(segment1, includeSegment);
                }
            }

            private static Polygon2D.BooleanOperations.Region smethod_5(
              Polygon2D.BooleanOperations.Region region)
            {
                Polygon2D.BooleanOperations.Region region1 = new Polygon2D.BooleanOperations.Region(region.Reversed);
                foreach (Polygon2D.BooleanOperations.Polygon polygon in (List<Polygon2D.BooleanOperations.Polygon>)region)
                {
                    Polygon2D.BooleanOperations.Polygon splitPolygon = new Polygon2D.BooleanOperations.Polygon(region1);
                    region1.Add(splitPolygon);
                    foreach (Polygon2D.BooleanOperations.Segment segment in (List<Polygon2D.BooleanOperations.Segment>)polygon)
                        segment.AddSegments(splitPolygon);
                    Polygon2D.BooleanOperations.Segment inSegment = splitPolygon[splitPolygon.Count - 1];
                    foreach (Polygon2D.BooleanOperations.Segment outSegment in (List<Polygon2D.BooleanOperations.Segment>)splitPolygon)
                    {
                        outSegment.Start.AddVertexSorted(new Polygon2D.BooleanOperations.Vertex(inSegment, outSegment));
                        inSegment = outSegment;
                    }
                }
                return region1;
            }

            private static void smethod_6(
              Polygon2D.BooleanOperations.Context context,
              Polygon2D.BooleanOperations.Point oldPoint,
              Polygon2D.BooleanOperations.Point newPoint)
            {
                foreach (Polygon2D.BooleanOperations.Vertex vertex in oldPoint.Vertices)
                {
                    if (vertex.InSegment.End == oldPoint)
                    {
                        vertex.InSegment.End = newPoint;
                        vertex.OutSegment.Start = newPoint;
                    }
                    newPoint.AddVertex(vertex);
                }
                context.method_2(oldPoint.Position);
            }

            private static Polygon2D.BooleanOperations.Region smethod_7(
              IList<Polygon2D> input,
              Polygon2D.BooleanOperations.Context context,
              bool reverse)
            {
                Polygon2D.BooleanOperations.Region region = new Polygon2D.BooleanOperations.Region(reverse);
                foreach (Polygon2D inputPolygon in (IEnumerable<Polygon2D>)input)
                {
                    if (inputPolygon.Count > 0)
                    {
                        Polygon2D.BooleanOperations.Polygon polygon = new Polygon2D.BooleanOperations.Polygon(region);
                        region.Add(polygon);
                        if (reverse)
                            Polygon2D.BooleanOperations.smethod_9(inputPolygon, polygon, context);
                        else
                            Polygon2D.BooleanOperations.smethod_8(inputPolygon, polygon, context);
                        Polygon2D.BooleanOperations.Segment inSegment = polygon[polygon.Count - 1];
                        foreach (Polygon2D.BooleanOperations.Segment outSegment in (List<Polygon2D.BooleanOperations.Segment>)polygon)
                        {
                            outSegment.Start.AddVertex(new Polygon2D.BooleanOperations.Vertex(inSegment, outSegment));
                            inSegment = outSegment;
                        }
                    }
                }
                return region;
            }

            private static void smethod_8(
              Polygon2D inputPolygon,
              Polygon2D.BooleanOperations.Polygon polygon,
              Polygon2D.BooleanOperations.Context context)
            {
                polygon.Add(context, (IList<Point2D>)inputPolygon);
            }

            private static void smethod_9(
              Polygon2D inputPolygon,
              Polygon2D.BooleanOperations.Polygon polygon,
              Polygon2D.BooleanOperations.Context context)
            {
                Point2D p1 = inputPolygon[0];
                Polygon2D.BooleanOperations.Point start = context.method_0(p1);
                for (int index = inputPolygon.Count - 1; index >= 0; --index)
                {
                    Point2D p2 = inputPolygon[index];
                    Polygon2D.BooleanOperations.Point end = context.method_0(p2);
                    Polygon2D.BooleanOperations.Segment segment = (Polygon2D.BooleanOperations.Segment)new Polygon2D.BooleanOperations.SegmentWithIntersections(polygon, start, end);
                    polygon.Add(segment);
                    start = end;
                }
            }

            [Serializable]
            public class Point
            {
                private List<Polygon2D.BooleanOperations.Vertex> vertices = new List<Polygon2D.BooleanOperations.Vertex>();
                private Point2D position;

                public Point()
                {
                }

                public Point(Point2D position)
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

                public List<Polygon2D.BooleanOperations.Vertex> Vertices
                {
                    get
                    {
                        return this.vertices;
                    }
                }

                public void AddVertex(Polygon2D.BooleanOperations.Vertex vertex)
                {
                    this.vertices.Add(vertex);
                }

                public void AddVertexSorted(Polygon2D.BooleanOperations.Vertex vertex)
                {
                    int index = this.vertices.BinarySearch(vertex, (IComparer<Polygon2D.BooleanOperations.Vertex>)Polygon2D.BooleanOperations.Vertex.OutSegmentAngleComparer.Instance);
                    if (index < 0)
                        this.vertices.Insert(~index, vertex);
                    else
                        this.vertices.Insert(index, vertex);
                }

                public void RemoveVerticesWithInSegment(Polygon2D.BooleanOperations.Segment inSegment)
                {
                    for (int index = this.vertices.Count - 1; index >= 0; --index)
                    {
                        if (this.vertices[index].InSegment == inSegment)
                            this.vertices.RemoveAt(index);
                    }
                }

                public void RemoveVerticesWithOutSegment(Polygon2D.BooleanOperations.Segment outSegment)
                {
                    for (int index = this.vertices.Count - 1; index >= 0; --index)
                    {
                        if (this.vertices[index].OutSegment == outSegment)
                            this.vertices.RemoveAt(index);
                    }
                }

                public Polygon2D.BooleanOperations.Segment GetNextUnprocessedSegment(
                  Polygon2D.BooleanOperations.Segment segment,
                  Func<Polygon2D.BooleanOperations.Segment, bool> includeSegment)
                {
                    double num = segment.Angle + System.Math.PI;
                    if (num > System.Math.PI)
                        num -= 2.0 * System.Math.PI;
                    Polygon2D.BooleanOperations.Segment segment1 = (Polygon2D.BooleanOperations.Segment)null;
                    for (int index = this.vertices.Count - 1; index >= 0; --index)
                    {
                        Polygon2D.BooleanOperations.Vertex vertex = this.vertices[index];
                        if (!vertex.OutSegment.Processed && vertex.OutSegment.Angle < num && includeSegment(vertex.OutSegment))
                        {
                            segment1 = vertex.OutSegment;
                            break;
                        }
                    }
                    if (segment1 == null)
                    {
                        for (int index = this.vertices.Count - 1; index >= 0; --index)
                        {
                            Polygon2D.BooleanOperations.Vertex vertex = this.vertices[index];
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

                public Polygon2D.BooleanOperations.Segment GetNextUnprocessedSegmentBiDirectional(
                  Polygon2D.BooleanOperations.Segment segment,
                  Polygon2D.BooleanOperations.Segment segmentSource,
                  Func<Polygon2D.BooleanOperations.Segment, bool> includeSegment,
                  out Polygon2D.BooleanOperations.Segment resultSource)
                {
                    Vector2D b1 = -segment.Direction;
                    resultSource = (Polygon2D.BooleanOperations.Segment)null;
                    Polygon2D.BooleanOperations.Segment segment1 = (Polygon2D.BooleanOperations.Segment)null;
                    Vector2D b2 = Vector2D.Zero;
                    for (int index = this.vertices.Count - 1; index >= 0; --index)
                    {
                        Polygon2D.BooleanOperations.Vertex vertex = this.vertices[index];
                        if (!vertex.OutSegment.Processed && vertex.OutSegment != segmentSource && (Vector2D.CompareAngles(vertex.OutSegment.Direction, b1) < 0 && includeSegment(vertex.OutSegment)) && (segment1 == null || Vector2D.CompareAngles(vertex.OutSegment.Direction, b2) > 0))
                        {
                            resultSource = vertex.OutSegment;
                            segment1 = vertex.OutSegment;
                            b2 = vertex.OutSegment.Direction;
                        }
                        if (!vertex.InSegment.Processed && vertex.InSegment != segmentSource && (Vector2D.CompareAngles(-vertex.InSegment.Direction, b1) < 0 && includeSegment(vertex.InSegment)) && (segment1 == null || Vector2D.CompareAngles(-vertex.InSegment.Direction, b2) > 0))
                        {
                            resultSource = vertex.InSegment;
                            segment1 = vertex.InSegment.vmethod_0(segmentSource.Polygon);
                            b2 = -vertex.InSegment.Direction;
                        }
                    }
                    if (segment1 == null)
                    {
                        for (int index = this.vertices.Count - 1; index >= 0; --index)
                        {
                            Polygon2D.BooleanOperations.Vertex vertex = this.vertices[index];
                            if (!vertex.OutSegment.Processed && vertex.OutSegment != segmentSource && includeSegment(vertex.OutSegment) && (segment1 == null || Vector2D.CompareAngles(vertex.OutSegment.Direction, b2) > 0))
                            {
                                resultSource = vertex.OutSegment;
                                segment1 = vertex.OutSegment;
                                b2 = vertex.OutSegment.Direction;
                            }
                            if (!vertex.InSegment.Processed && vertex.InSegment != segmentSource && includeSegment(vertex.InSegment) && (segment1 == null || Vector2D.CompareAngles(-vertex.InSegment.Direction, b2) > 0))
                            {
                                resultSource = vertex.InSegment;
                                segment1 = vertex.InSegment.vmethod_0(segmentSource.Polygon);
                                b2 = -vertex.InSegment.Direction;
                            }
                        }
                    }
                    if (segment1 == null)
                    {
                        for (int index = this.vertices.Count - 1; index >= 0; --index)
                        {
                            Polygon2D.BooleanOperations.Vertex vertex = this.vertices[index];
                            Vector2D vector2D;
                            if (!vertex.OutSegment.Processed && vertex.OutSegment != segmentSource && (vertex.OutSegment.method_3(segmentSource) && includeSegment(vertex.OutSegment)) && segment1 == null)
                            {
                                resultSource = vertex.OutSegment;
                                segment1 = vertex.OutSegment;
                                vector2D = vertex.OutSegment.Direction;
                            }
                            if (!vertex.InSegment.Processed && vertex.InSegment != segmentSource && (vertex.InSegment.method_3(segmentSource) && includeSegment(vertex.InSegment)) && segment1 == null)
                            {
                                resultSource = vertex.InSegment;
                                segment1 = vertex.InSegment.vmethod_0(segmentSource.Polygon);
                                vector2D = -vertex.InSegment.Direction;
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
                private Polygon2D.BooleanOperations.Segment inSegment;
                private Polygon2D.BooleanOperations.Segment outSegment;

                public Vertex(
                  Polygon2D.BooleanOperations.Segment inSegment,
                  Polygon2D.BooleanOperations.Segment outSegment)
                {
                    this.inSegment = inSegment;
                    this.outSegment = outSegment;
                }

                public Polygon2D.BooleanOperations.Segment InSegment
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

                public Polygon2D.BooleanOperations.Segment OutSegment
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

                public Polygon2D.BooleanOperations.Point Point
                {
                    get
                    {
                        return this.inSegment.End;
                    }
                }

                public Polygon2D.BooleanOperations.Region Region
                {
                    get
                    {
                        return this.inSegment.Region;
                    }
                }

                public bool IsInside(Polygon2D.BooleanOperations.Segment segment)
                {
                    if (segment.Start != this.inSegment.End)
                        throw new ArgumentException();
                    double num1 = MathUtil.NormalizeAngleTwoPi(this.inSegment.Angle + System.Math.PI);
                    double num2 = MathUtil.NormalizeAngleTwoPi(this.outSegment.Angle);
                    double num3 = MathUtil.NormalizeAngleTwoPi(segment.Angle);
                    return num2 > num1 ? num3 <= num1 || num3 >= num2 : num3 <= num1 && num3 >= num2;
                }

                public override string ToString()
                {
                    return string.Format("Position: {0}, vertices: {1}", (object)this.Point.Position, (object)this.Point.Vertices.Count);
                }

                public class OutSegmentAngleComparer : IComparer<Polygon2D.BooleanOperations.Vertex>
                {
                    public static readonly Polygon2D.BooleanOperations.Vertex.OutSegmentAngleComparer Instance = new Polygon2D.BooleanOperations.Vertex.OutSegmentAngleComparer();

                    private OutSegmentAngleComparer()
                    {
                    }

                    public int Compare(
                      Polygon2D.BooleanOperations.Vertex x,
                      Polygon2D.BooleanOperations.Vertex y)
                    {
                        double angle1 = x.outSegment.Angle;
                        double angle2 = y.outSegment.Angle;
                        if (angle1 < angle2)
                            return -1;
                        return angle1 > angle2 ? 1 : 0;
                    }
                }
            }

            [Serializable]
            public class Segment
            {
                private Polygon2D.BooleanOperations.Polygon polygon;
                private Polygon2D.BooleanOperations.Point start;
                private Polygon2D.BooleanOperations.Point end;
                private Polygon2D.BooleanOperations.SegmentStatus status;
                private bool processed;
                private double angle;

                public Segment()
                {
                }

                public Segment(
                  Polygon2D.BooleanOperations.Polygon polygon,
                  Polygon2D.BooleanOperations.Point start,
                  Polygon2D.BooleanOperations.Point end)
                {
                    if (start == end)
                        throw new ArgumentException("Start and end point may not be the same.");
                    this.polygon = polygon;
                    this.start = start;
                    this.end = end;
                }

                public Polygon2D.BooleanOperations.Polygon Polygon
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

                public Polygon2D.BooleanOperations.Point Start
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

                public Polygon2D.BooleanOperations.Point End
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

                internal Polygon2D.BooleanOperations.SegmentStatus Status
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

                public Vector2D Direction
                {
                    get
                    {
                        return this.end.Position - this.start.Position;
                    }
                }

                public double Angle
                {
                    get
                    {
                        return this.angle;
                    }
                }

                public Polygon2D.BooleanOperations.Region Region
                {
                    get
                    {
                        return this.polygon.Region;
                    }
                }

                public virtual Polygon2D.BooleanOperations.Intersection AddIntersection(
                  Polygon2D.BooleanOperations.Intersection intersection)
                {
                    throw new NotImplementedException();
                }

                public virtual void AddSegments(Polygon2D.BooleanOperations.Polygon splitPolygon)
                {
                    throw new NotImplementedException();
                }

                public virtual void AddSegmentsReversed(Polygon2D.BooleanOperations.Polygon splitPolygon)
                {
                    throw new NotImplementedException();
                }

                public void CalculateStatusFirstSegment(Polygon2D.BooleanOperations.Region otherRegion)
                {
                    if (this.status != Polygon2D.BooleanOperations.SegmentStatus.Unknown)
                        return;
                    this.method_1(otherRegion);
                    if (this.status != Polygon2D.BooleanOperations.SegmentStatus.Unknown)
                        return;
                    if (this.method_0(otherRegion) == 0)
                    {
                        if (otherRegion.IsInside(this.start.Position))
                            this.status = Polygon2D.BooleanOperations.SegmentStatus.Inside;
                        else
                            this.status = Polygon2D.BooleanOperations.SegmentStatus.Outside;
                    }
                    else
                        this.method_2(otherRegion);
                }

                private int method_0(Polygon2D.BooleanOperations.Region region)
                {
                    int num = 0;
                    foreach (Polygon2D.BooleanOperations.Vertex vertex in this.start.Vertices)
                    {
                        if (vertex.Region == region)
                            ++num;
                    }
                    return num;
                }

                public void CalculateStatus(
                  Polygon2D.BooleanOperations.Segment previousSegment,
                  Polygon2D.BooleanOperations.Region otherRegion)
                {
                    if (this.status != Polygon2D.BooleanOperations.SegmentStatus.Unknown)
                        return;
                    if (this.method_0(otherRegion) == 0)
                    {
                        this.status = previousSegment.status;
                    }
                    else
                    {
                        this.method_1(otherRegion);
                        if (this.status != Polygon2D.BooleanOperations.SegmentStatus.Unknown)
                            return;
                        this.method_2(otherRegion);
                    }
                }

                private void method_1(Polygon2D.BooleanOperations.Region otherRegion)
                {
                    foreach (Polygon2D.BooleanOperations.Vertex vertex in this.start.Vertices)
                    {
                        if (vertex.Region == otherRegion)
                        {
                            if (vertex.InSegment.start != this.end)
                            {
                                if (vertex.OutSegment.end == this.end)
                                {
                                    this.status = Polygon2D.BooleanOperations.SegmentStatus.Shared;
                                    break;
                                }
                            }
                            else
                            {
                                this.status = Polygon2D.BooleanOperations.SegmentStatus.SharedOpposite;
                                break;
                            }
                        }
                    }
                }

                private void method_2(Polygon2D.BooleanOperations.Region otherRegion)
                {
                    this.status = Polygon2D.BooleanOperations.SegmentStatus.Outside;
                    foreach (Polygon2D.BooleanOperations.Vertex vertex in this.start.Vertices)
                    {
                        if (vertex.Region == otherRegion && vertex.IsInside(this))
                        {
                            this.status = Polygon2D.BooleanOperations.SegmentStatus.Inside;
                            break;
                        }
                    }
                }

                public void CalculateAngle()
                {
                    this.angle = System.Math.Atan2(this.end.Position.Y - this.start.Position.Y, this.end.Position.X - this.start.Position.X);
                }

                public void Reverse()
                {
                    this.start.RemoveVerticesWithOutSegment(this);
                    Polygon2D.BooleanOperations.Point start = this.start;
                    this.start = this.end;
                    this.end = start;
                    this.CalculateAngle();
                    this.start.AddVertexSorted(new Polygon2D.BooleanOperations.Vertex((Polygon2D.BooleanOperations.Segment)null, this));
                }

                public Segment2D ToSegment2D()
                {
                    return new Segment2D(this.start.Position, this.end.Position);
                }

                public override string ToString()
                {
                    return string.Format("Start: {0}, End: {1}, Status: {2}", (object)this.start, (object)this.end, (object)this.status);
                }

                internal virtual Polygon2D.BooleanOperations.Segment vmethod_0(
                  Polygon2D.BooleanOperations.Polygon result)
                {
                    return new Polygon2D.BooleanOperations.Segment(result, this.end, this.start);
                }

                internal bool method_3(Polygon2D.BooleanOperations.Segment other)
                {
                    if (this.start == other.start && this.end == other.end)
                        return true;
                    if (this.start == other.end)
                        return this.end == other.start;
                    return false;
                }
            }

            private class Class22 : RedBlackTree<Polygon2D.BooleanOperations.Class1>
            {
                public void method_4(Polygon2D.BooleanOperations.Region region, double precision)
                {
                    Polygon2D.BooleanOperations.Class1.Class2 class2 = new Polygon2D.BooleanOperations.Class1.Class2();
                    foreach (List<Polygon2D.BooleanOperations.Segment> segmentList in (List<Polygon2D.BooleanOperations.Polygon>)region)
                    {
                        foreach (Polygon2D.BooleanOperations.Segment segment in segmentList)
                        {
                            Point2D position1 = segment.Start.Position;
                            Point2D position2 = segment.End.Position;
                            if (position1.X > position2.X || position1.X == position2.X && position1.Y > position2.Y)
                                MathUtil.Swap<Point2D>(ref position1, ref position2);
                            Point2D position3 = new Point2D(position1.X - precision, position1.Y - precision);
                            class2.Position = position3;
                            Polygon2D.BooleanOperations.Class1 class1_1 = this.Find((IComparable<Polygon2D.BooleanOperations.Class1>)class2);
                            if (class1_1 == null)
                            {
                                class1_1 = new Polygon2D.BooleanOperations.Class1(position3);
                                this.Add(class1_1);
                            }
                            class1_1.EntrySegmentsNotNull.Add(segment);
                            Point2D position4 = new Point2D(position2.X + precision, position2.Y + precision);
                            class2.Position = position4;
                            Polygon2D.BooleanOperations.Class1 class1_2 = this.Find((IComparable<Polygon2D.BooleanOperations.Class1>)class2);
                            if (class1_2 == null)
                            {
                                class1_2 = new Polygon2D.BooleanOperations.Class1(position4);
                                this.Add(class1_2);
                            }
                            class1_2.ExitSegmentsNotNull.Add(segment);
                        }
                    }
                }
            }

            private class Class1 : IComparable<Polygon2D.BooleanOperations.Class1>
            {
                private Point2D point2D_0;
                private List<Polygon2D.BooleanOperations.Segment> list_0;
                private List<Polygon2D.BooleanOperations.Segment> list_1;

                public Class1(Point2D position)
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

                public List<Polygon2D.BooleanOperations.Segment> EntrySegments
                {
                    get
                    {
                        return this.list_0;
                    }
                }

                public List<Polygon2D.BooleanOperations.Segment> ExitSegments
                {
                    get
                    {
                        return this.list_1;
                    }
                }

                public List<Polygon2D.BooleanOperations.Segment> EntrySegmentsNotNull
                {
                    get
                    {
                        if (this.list_0 == null)
                            this.list_0 = new List<Polygon2D.BooleanOperations.Segment>();
                        return this.list_0;
                    }
                }

                public List<Polygon2D.BooleanOperations.Segment> ExitSegmentsNotNull
                {
                    get
                    {
                        if (this.list_1 == null)
                            this.list_1 = new List<Polygon2D.BooleanOperations.Segment>();
                        return this.list_1;
                    }
                }

                public override string ToString()
                {
                    return this.point2D_0.ToString();
                }

                public int CompareTo(Polygon2D.BooleanOperations.Class1 other)
                {
                    if (this.point2D_0.X < other.point2D_0.X)
                        return -1;
                    if (this.point2D_0.X > other.point2D_0.X)
                        return 1;
                    if (this.point2D_0.Y < other.point2D_0.Y)
                        return -1;
                    return this.point2D_0.Y > other.point2D_0.Y ? 1 : 0;
                }

                public class Class2 : IComparable<Polygon2D.BooleanOperations.Class1>
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

                    public int CompareTo(Polygon2D.BooleanOperations.Class1 other)
                    {
                        if (this.point2D_0.X < other.point2D_0.X)
                            return -1;
                        if (this.point2D_0.X > other.point2D_0.X)
                            return 1;
                        if (this.point2D_0.Y < other.point2D_0.Y)
                            return -1;
                        return this.point2D_0.Y > other.point2D_0.Y ? 1 : 0;
                    }
                }
            }

            private class Class3
            {
                private List<Polygon2D.BooleanOperations.Segment> list_0 = new List<Polygon2D.BooleanOperations.Segment>();
                private Polygon2D.BooleanOperations.Class22 class22_0;
                private RedBlackTree<Polygon2D.BooleanOperations.Class1>.ForwardEnumerator forwardEnumerator_0;
                private Polygon2D.BooleanOperations.Context context_0;
                private double double_0;

                public Class3(
                  Polygon2D.BooleanOperations.Class22 eventQueue,
                  Polygon2D.BooleanOperations.Context context,
                  double precision)
                {
                    this.class22_0 = eventQueue;
                    this.context_0 = context;
                    this.double_0 = precision;
                    this.forwardEnumerator_0 = (RedBlackTree<Polygon2D.BooleanOperations.Class1>.ForwardEnumerator)eventQueue.GetEnumerator();
                }

                public void method_0()
                {
                    while (this.forwardEnumerator_0.MoveNext())
                    {
                        Polygon2D.BooleanOperations.Class1 current = this.forwardEnumerator_0.Current;
                        if (current.EntrySegments != null)
                        {
                            foreach (Polygon2D.BooleanOperations.Segment entrySegment in current.EntrySegments)
                            {
                                foreach (Polygon2D.BooleanOperations.Segment segment in this.list_0)
                                {
                                    double[] pArray;
                                    double[] qArray;
                                    if ((entrySegment.Region != segment.Region || entrySegment.Start != segment.End && entrySegment.End != segment.Start) && Segment2D.GetIntersectionParameters(entrySegment.ToSegment2D(), segment.ToSegment2D(), out pArray, out qArray, this.double_0))
                                    {
                                        for (int index = 0; index < pArray.Length; ++index)
                                        {
                                            double parameter1 = pArray[index];
                                            double parameter2 = qArray[index];
                                            Polygon2D.BooleanOperations.Point point1 = (Polygon2D.BooleanOperations.Point)null;
                                            bool flag1 = true;
                                            if (parameter1 <= 0.0)
                                            {
                                                flag1 = false;
                                                point1 = entrySegment.Start;
                                            }
                                            else if (parameter1 >= 1.0)
                                            {
                                                flag1 = false;
                                                point1 = entrySegment.End;
                                            }
                                            bool flag2 = true;
                                            if (point1 == null)
                                            {
                                                if (parameter2 <= 0.0)
                                                {
                                                    flag2 = false;
                                                    point1 = segment.Start;
                                                }
                                                else if (parameter2 >= 1.0)
                                                {
                                                    flag2 = false;
                                                    point1 = segment.End;
                                                }
                                            }
                                            if (point1 == null)
                                            {
                                                Point2D point2D = entrySegment.Start.Position + parameter1 * (entrySegment.End.Position - entrySegment.Start.Position);
                                                if (Point2D.AreApproxEqual(entrySegment.Start.Position, point2D, this.double_0))
                                                {
                                                    point1 = entrySegment.Start;
                                                    flag1 = false;
                                                }
                                                else if (Point2D.AreApproxEqual(entrySegment.End.Position, point2D, this.double_0))
                                                {
                                                    point1 = entrySegment.End;
                                                    flag1 = false;
                                                }
                                                else if (Point2D.AreApproxEqual(segment.Start.Position, point2D, this.double_0))
                                                {
                                                    point1 = segment.Start;
                                                    flag2 = false;
                                                }
                                                else if (Point2D.AreApproxEqual(segment.End.Position, point2D, this.double_0))
                                                {
                                                    point1 = segment.End;
                                                    flag2 = false;
                                                }
                                                else
                                                    point1 = this.context_0.method_0(point2D);
                                            }
                                            if (flag1)
                                            {
                                                Polygon2D.BooleanOperations.Intersection intersection1 = new Polygon2D.BooleanOperations.Intersection(parameter1, point1);
                                                Polygon2D.BooleanOperations.Intersection intersection2 = entrySegment.AddIntersection(intersection1);
                                                if (intersection2 != null && intersection2.Point != intersection1.Point)
                                                {
                                                    Polygon2D.BooleanOperations.smethod_6(this.context_0, intersection1.Point, intersection2.Point);
                                                    point1 = intersection2.Point;
                                                }
                                            }
                                            if (flag2)
                                            {
                                                Polygon2D.BooleanOperations.Intersection intersection1 = new Polygon2D.BooleanOperations.Intersection(parameter2, point1);
                                                Polygon2D.BooleanOperations.Intersection intersection2 = segment.AddIntersection(intersection1);
                                                if (intersection2 != null && intersection2.Point != intersection1.Point)
                                                {
                                                    Polygon2D.BooleanOperations.smethod_6(this.context_0, intersection1.Point, intersection2.Point);
                                                    Polygon2D.BooleanOperations.Point point2 = intersection2.Point;
                                                }
                                            }
                                        }
                                    }
                                }
                                this.list_0.Add(entrySegment);
                            }
                        }
                        if (current.ExitSegments != null)
                        {
                            foreach (Polygon2D.BooleanOperations.Segment exitSegment in current.ExitSegments)
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
            private class SegmentWithIntersections : Polygon2D.BooleanOperations.Segment
            {
                private SortedList<Polygon2D.BooleanOperations.Intersection> intersections = new SortedList<Polygon2D.BooleanOperations.Intersection>();

                public SegmentWithIntersections()
                {
                }

                public SegmentWithIntersections(
                  Polygon2D.BooleanOperations.Polygon polygon,
                  Polygon2D.BooleanOperations.Point start,
                  Polygon2D.BooleanOperations.Point end)
                  : base(polygon, start, end)
                {
                }

                public override Polygon2D.BooleanOperations.Intersection AddIntersection(
                  Polygon2D.BooleanOperations.Intersection intersection)
                {
                    if (intersection.Point == this.Start || intersection.Point == this.End)
                        return (Polygon2D.BooleanOperations.Intersection)null;
                    Polygon2D.BooleanOperations.Intersection intersection1 = (Polygon2D.BooleanOperations.Intersection)null;
                    for (int index = 0; index < this.intersections.Count; ++index)
                    {
                        Polygon2D.BooleanOperations.Intersection intersection2 = this.intersections[index];
                        if (intersection2.Parameter == intersection.Parameter || intersection2.Point == intersection.Point)
                        {
                            intersection1 = intersection2;
                            break;
                        }
                    }
                    if (intersection1 == null)
                    {
                        intersection1 = intersection;
                        this.intersections.Add(intersection);
                    }
                    return intersection1;
                }

                public override void AddSegments(Polygon2D.BooleanOperations.Polygon splitPolygon)
                {
                    if (this.intersections.Count == 0)
                    {
                        this.method_4(splitPolygon, this.Start, this.End);
                    }
                    else
                    {
                        Polygon2D.BooleanOperations.Point p0 = this.Start;
                        foreach (Polygon2D.BooleanOperations.Intersection intersection in this.intersections)
                        {
                            Polygon2D.BooleanOperations.Point point = intersection.Point;
                            this.method_4(splitPolygon, p0, point);
                            p0 = point;
                        }
                        this.method_4(splitPolygon, p0, this.End);
                    }
                }

                private void method_4(
                  Polygon2D.BooleanOperations.Polygon splitPolygon,
                  Polygon2D.BooleanOperations.Point p0,
                  Polygon2D.BooleanOperations.Point p1)
                {
                    Polygon2D.BooleanOperations.Segment segment = new Polygon2D.BooleanOperations.Segment(splitPolygon, p0, p1);
                    segment.CalculateAngle();
                    splitPolygon.Add(segment);
                }
            }

            [Serializable]
            public class Intersection : IComparable<Polygon2D.BooleanOperations.Intersection>
            {
                private double parameter;
                private Polygon2D.BooleanOperations.Point point;

                public Intersection(double parameter, Polygon2D.BooleanOperations.Point point)
                {
                    this.parameter = parameter;
                    this.point = point;
                }

                public double Parameter
                {
                    get
                    {
                        return this.parameter;
                    }
                }

                public Polygon2D.BooleanOperations.Point Point
                {
                    get
                    {
                        return this.point;
                    }
                }

                public int CompareTo(Polygon2D.BooleanOperations.Intersection other)
                {
                    if (this.parameter < other.parameter)
                        return -1;
                    return this.parameter > other.parameter ? 1 : 0;
                }
            }

            [Serializable]
            public class Region : List<Polygon2D.BooleanOperations.Polygon>
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

                public bool IsInside(Point2D p)
                {
                    return this.GetWindingNumber(p) > this.insideMinWindingNumber;
                }

                public int GetWindingNumber(Point2D p)
                {
                    int num = 0;
                    foreach (Polygon2D.BooleanOperations.Polygon polygon in (List<Polygon2D.BooleanOperations.Polygon>)this)
                        num += Polygon2D.BooleanOperations.Polygon.GetWindingNumber(p.X, p.Y, polygon);
                    return num;
                }

                public void CalculateSegmentStatus(Polygon2D.BooleanOperations.Region otherRegion)
                {
                    foreach (Polygon2D.BooleanOperations.Polygon polygon in (List<Polygon2D.BooleanOperations.Polygon>)this)
                        polygon.CalculateSegmentStatus(otherRegion);
                }

                public List<Polygon2D> ToPolygon2DList()
                {
                    List<Polygon2D> polygon2DList = new List<Polygon2D>(this.Count);
                    foreach (Polygon2D.BooleanOperations.Polygon polygon in (List<Polygon2D.BooleanOperations.Polygon>)this)
                    {
                        Polygon2D polygon2D = new Polygon2D(polygon.Count);
                        foreach (Polygon2D.BooleanOperations.Segment segment in (List<Polygon2D.BooleanOperations.Segment>)polygon)
                            polygon2D.Add(segment.Start.Position);
                        polygon2DList.Add(polygon2D);
                    }
                    return polygon2DList;
                }

                public List<IList<Point2D>> ToPoint2DListList()
                {
                    List<IList<Point2D>> point2DListList = new List<IList<Point2D>>(this.Count);
                    foreach (Polygon2D.BooleanOperations.Polygon polygon in (List<Polygon2D.BooleanOperations.Polygon>)this)
                    {
                        Polygon2D polygon2D = new Polygon2D(polygon.Count);
                        foreach (Polygon2D.BooleanOperations.Segment segment in (List<Polygon2D.BooleanOperations.Segment>)polygon)
                            polygon2D.Add(segment.Start.Position);
                        point2DListList.Add((IList<Point2D>)polygon2D);
                    }
                    return point2DListList;
                }

                public void GetSegments(
                  IList<Polygon2D.BooleanOperations.Segment> segments)
                {
                    foreach (List<Polygon2D.BooleanOperations.Segment> segmentList in (List<Polygon2D.BooleanOperations.Polygon>)this)
                    {
                        foreach (Polygon2D.BooleanOperations.Segment segment in segmentList)
                            segments.Add(segment);
                    }
                }

                public Polygon2D.BooleanOperations.Region Subdivide(
                  Polygon2D.BooleanOperations.Context context,
                  double precision)
                {
                    Polygon2D.BooleanOperations.Class22 eventQueue = new Polygon2D.BooleanOperations.Class22();
                    eventQueue.method_4(this, precision);
                    new Polygon2D.BooleanOperations.Class3(eventQueue, context, precision).method_0();
                    context.method_1();
                    return Polygon2D.BooleanOperations.smethod_5(this);
                }

                internal void method_0()
                {
                    foreach (Polygon2D.BooleanOperations.Polygon polygon in (List<Polygon2D.BooleanOperations.Polygon>)this)
                        polygon.method_0();
                }
            }

            [Serializable]
            public class Polygon : List<Polygon2D.BooleanOperations.Segment>
            {
                private Polygon2D.BooleanOperations.Region region;

                public Polygon(Polygon2D.BooleanOperations.Region region)
                {
                    this.region = region;
                }

                public Polygon2D.BooleanOperations.Region Region
                {
                    get
                    {
                        return this.region;
                    }
                }

                public void Add(Polygon2D.BooleanOperations.Context context, IList<Point2D> polygon)
                {
                    Point2D p1 = polygon[polygon.Count - 1];
                    Polygon2D.BooleanOperations.Point start = context.method_0(p1);
                    for (int index = 0; index < polygon.Count; ++index)
                    {
                        Point2D p2 = polygon[index];
                        Polygon2D.BooleanOperations.Point end = context.method_0(p2);
                        this.Add((Polygon2D.BooleanOperations.Segment)new Polygon2D.BooleanOperations.SegmentWithIntersections(this, start, end));
                        start = end;
                    }
                }

                public static int GetWindingNumber(Point2D p, Polygon2D.BooleanOperations.Polygon polygon)
                {
                    return Polygon2D.BooleanOperations.Polygon.GetWindingNumber(p.X, p.Y, polygon);
                }

                public static int GetWindingNumber(
                  double x,
                  double y,
                  Polygon2D.BooleanOperations.Polygon polygon)
                {
                    int num = 0;
                    int count = polygon.Count;
                    if (count > 0)
                    {
                        Point2D point2D = polygon[count - 1].Start.Position;
                        for (int index = 0; index < count; ++index)
                        {
                            Point2D position = polygon[index].Start.Position;
                            if (point2D.Y <= y)
                            {
                                if (position.Y > y && Polygon2D.smethod_4(point2D.X, point2D.Y, position.X, position.Y, x, y) > 0.0)
                                    ++num;
                            }
                            else if (position.Y <= y && Polygon2D.smethod_4(point2D.X, point2D.Y, position.X, position.Y, x, y) < 0.0)
                                --num;
                            point2D = position;
                        }
                    }
                    return num;
                }

                public void CalculateSegmentStatus(Polygon2D.BooleanOperations.Region otherRegion)
                {
                    if (this.Count <= 0)
                        return;
                    Polygon2D.BooleanOperations.Segment previousSegment = this[0];
                    previousSegment.CalculateStatusFirstSegment(otherRegion);
                    for (int index = 1; index < this.Count; ++index)
                    {
                        Polygon2D.BooleanOperations.Segment segment = this[index];
                        segment.CalculateStatus(previousSegment, otherRegion);
                        previousSegment = segment;
                    }
                }

                public bool IsClockwise()
                {
                    if (this.Count < 3)
                        return false;
                    int index1 = this.Count - 1;
                    Polygon2D.BooleanOperations.Segment segment1 = this[index1];
                    int index2 = 0;
                    Polygon2D.BooleanOperations.Segment segment2 = this[0];
                    Polygon2D.BooleanOperations.Segment segment3 = segment2;
                    int num1 = 0;
                    for (int index3 = 1; index3 < this.Count; ++index3)
                    {
                        Polygon2D.BooleanOperations.Segment segment4 = this[index3];
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
                    return Vector2D.CrossProduct(segment1.End.Position - segment1.Start.Position, segment2.End.Position - segment2.Start.Position) < 0.0;
                }

                public Polygon2D ToPolygon2D()
                {
                    Polygon2D polygon2D = new Polygon2D(this.Count + 1);
                    if (this.Count > 0)
                    {
                        foreach (Polygon2D.BooleanOperations.Segment segment in (List<Polygon2D.BooleanOperations.Segment>)this)
                            polygon2D.Add(segment.Start.Position);
                        if (this[this.Count - 1].End != this[0].Start)
                            polygon2D.Add(this[this.Count - 1].End.Position);
                    }
                    return polygon2D;
                }

                internal void method_0()
                {
                    foreach (Polygon2D.BooleanOperations.Segment segment in (List<Polygon2D.BooleanOperations.Segment>)this)
                        segment.Status = Polygon2D.BooleanOperations.SegmentStatus.Unknown;
                }
            }

            public class Context
            {
                private Dictionary<Point2D, Polygon2D.BooleanOperations.Point> dictionary_0 = new Dictionary<Point2D, Polygon2D.BooleanOperations.Point>();

                internal Polygon2D.BooleanOperations.Point method_0(Point2D p)
                {
                    Polygon2D.BooleanOperations.Point point;
                    if (!this.dictionary_0.TryGetValue(p, out point))
                    {
                        point = new Polygon2D.BooleanOperations.Point(p);
                        this.dictionary_0.Add(p, point);
                    }
                    return point;
                }

                internal void method_1()
                {
                    foreach (KeyValuePair<Point2D, Polygon2D.BooleanOperations.Point> keyValuePair in this.dictionary_0)
                        keyValuePair.Value.Vertices.Clear();
                }

                internal void method_2(Point2D p)
                {
                    this.dictionary_0.Remove(p);
                }
            }

            private class Class4 : IComparable<Polygon2D.BooleanOperations.Class4>
            {
                private Point2D point2D_0;
                private Polygon2D.BooleanOperations.Class6 class6_0;

                public Class4(Point2D position)
                {
                    this.point2D_0 = position;
                }

                public Point2D Position
                {
                    get
                    {
                        return this.point2D_0;
                    }
                }

                public Polygon2D.BooleanOperations.Class6 MergedPoint
                {
                    get
                    {
                        return this.class6_0;
                    }
                    set
                    {
                        this.class6_0 = value;
                    }
                }

                public int CompareTo(Polygon2D.BooleanOperations.Class4 other)
                {
                    if (this.point2D_0.X < other.point2D_0.X)
                        return -1;
                    if (this.point2D_0.X > other.point2D_0.X)
                        return 1;
                    if (this.point2D_0.Y < other.point2D_0.Y)
                        return -1;
                    return this.point2D_0.Y > other.point2D_0.Y ? 1 : 0;
                }

                public override string ToString()
                {
                    return this.point2D_0.ToString();
                }
            }

            private class Class5
            {
                private RedBlackTree<Polygon2D.BooleanOperations.Class4> redBlackTree_0 = new RedBlackTree<Polygon2D.BooleanOperations.Class4>();
                private RedBlackTree<Polygon2D.BooleanOperations.Class4>.ForwardEnumerator forwardEnumerator_0;
                private RedBlackTree<Polygon2D.BooleanOperations.Class4>.ForwardEnumerator forwardEnumerator_1;
                private double double_0;

                public Class5(double precision)
                {
                    this.double_0 = precision;
                    this.forwardEnumerator_0 = new RedBlackTree<Polygon2D.BooleanOperations.Class4>.ForwardEnumerator(this.redBlackTree_0);
                    this.forwardEnumerator_1 = new RedBlackTree<Polygon2D.BooleanOperations.Class4>.ForwardEnumerator(this.redBlackTree_0);
                }

                public Polygon2D.BooleanOperations.Class6 method_0(Point2D p)
                {
                    Polygon2D.BooleanOperations.Class4 p1 = new Polygon2D.BooleanOperations.Class4(p);
                    Polygon2D.BooleanOperations.Class4 class4 = new Polygon2D.BooleanOperations.Class4(new Point2D(p.X - this.double_0, double.MinValue));
                    double num1 = p.X + this.double_0;
                    double y = p.Y - this.double_0;
                    double num2 = p.Y + this.double_0;
                    if (this.forwardEnumerator_0.Search(class4))
                    {
                        while (this.forwardEnumerator_0.Current.Position.X <= num1)
                        {
                            if (this.forwardEnumerator_1.Search(new Polygon2D.BooleanOperations.Class4(new Point2D(this.forwardEnumerator_0.Current.Position.X, y))))
                            {
                                while (this.forwardEnumerator_1.Current.Position.X == this.forwardEnumerator_0.Current.Position.X && this.forwardEnumerator_1.Current.Position.Y <= num2)
                                {
                                    if (p1.MergedPoint == null)
                                    {
                                        p1.MergedPoint = this.forwardEnumerator_1.Current.MergedPoint;
                                        p1.MergedPoint.method_1(p1);
                                    }
                                    else if (p1.MergedPoint != this.forwardEnumerator_1.Current.MergedPoint)
                                        p1.MergedPoint.method_0(this.forwardEnumerator_1.Current.MergedPoint);
                                    if (!this.forwardEnumerator_1.MoveNext())
                                        break;
                                }
                            }
                            if (!this.forwardEnumerator_0.MoveNext())
                                break;
                        }
                    }
                    if (p1.MergedPoint == null)
                    {
                        p1.MergedPoint = new Polygon2D.BooleanOperations.Class6();
                        p1.MergedPoint.method_1(p1);
                    }
                    this.redBlackTree_0.TryAdd(p1);
                    return p1.MergedPoint;
                }
            }

            private class Class6
            {
                private Point2D point2D_0;
                private int int_0;
                private Polygon2D.BooleanOperations.Class6.Class7 class7_0;

                public void method_0(Polygon2D.BooleanOperations.Class6 other)
                {
                    this.point2D_0.X += other.point2D_0.X;
                    this.point2D_0.Y += other.point2D_0.Y;
                    this.int_0 += other.int_0;
                    Polygon2D.BooleanOperations.Class6.Class7 class7_1 = other.class7_0;
                    Polygon2D.BooleanOperations.Class6.Class7 class7_2 = class7_1;
                    for (; class7_1 != null; class7_1 = class7_1.Next)
                    {
                        class7_1.Value.MergedPoint = this;
                        class7_2 = class7_1;
                    }
                    class7_2.Next = this.class7_0;
                    this.class7_0 = other.class7_0;
                }

                public void method_1(Polygon2D.BooleanOperations.Class4 p)
                {
                    this.point2D_0.X += p.Position.X;
                    this.point2D_0.Y += p.Position.Y;
                    ++this.int_0;
                    if (this.class7_0 == null)
                        this.class7_0 = new Polygon2D.BooleanOperations.Class6.Class7(p);
                    else
                        this.class7_0 = new Polygon2D.BooleanOperations.Class6.Class7(p, this.class7_0);
                }

                public Point2D method_2()
                {
                    double num = 1.0 / (double)this.int_0;
                    return new Point2D(num * this.point2D_0.X, num * this.point2D_0.Y);
                }

                public class Class7
                {
                    private Polygon2D.BooleanOperations.Class4 class4_0;
                    private Polygon2D.BooleanOperations.Class6.Class7 class7_0;

                    public Class7(Polygon2D.BooleanOperations.Class4 value)
                    {
                        this.class4_0 = value;
                    }

                    public Class7(
                      Polygon2D.BooleanOperations.Class4 value,
                      Polygon2D.BooleanOperations.Class6.Class7 next)
                    {
                        this.class4_0 = value;
                        this.class7_0 = next;
                    }

                    public Polygon2D.BooleanOperations.Class4 Value
                    {
                        get
                        {
                            return this.class4_0;
                        }
                    }

                    public Polygon2D.BooleanOperations.Class6.Class7 Next
                    {
                        get
                        {
                            return this.class7_0;
                        }
                        set
                        {
                            this.class7_0 = value;
                        }
                    }
                }
            }

            private class Class8 : List<Polygon2D.BooleanOperations.Class6>
            {
            }

            private class Class9 : List<Polygon2D.BooleanOperations.Class8>
            {
            }

            [Serializable]
            internal class DebugInfo
            {
                private Polygon2D.BooleanOperations.Region region1;
                private Polygon2D.BooleanOperations.Region region2;
                private Polygon2D.BooleanOperations.Region resultRegion;
                private List<Polygon2D.BooleanOperations.Segment> segments;
                private Polygon2D.BooleanOperations.Segment highlightSegment;

                public Polygon2D.BooleanOperations.Region Region1
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

                public Polygon2D.BooleanOperations.Region Region2
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

                public Polygon2D.BooleanOperations.Region ResultRegion
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

                public List<Polygon2D.BooleanOperations.Segment> Segments
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

                public Polygon2D.BooleanOperations.Segment HighlightSegment
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

        [Obsolete]
        public static class BooleanOperationsObsolete
        {
            static BooleanOperationsObsolete()
            {
                Class123.smethod_0(Enum0.const_2);
            }

            public static List<Polygon2D> GetIntersection(
              IList<Polygon2D> input1,
              IList<Polygon2D> input2,
              double precision)
            {
                Polygon2D[] input1Array = Polygon2D.BooleanOperationsObsolete.smethod_0(input1);
                Polygon2D[] input2Array = Polygon2D.BooleanOperationsObsolete.smethod_0(input2);
                Polygon2D.BooleanOperationsObsolete.smethod_7(input1Array, input2Array, precision);
                Vector2D vector2D = Polygon2D.BooleanOperationsObsolete.smethod_1((IList<Polygon2D>)input1Array, (IList<Polygon2D>)input2Array);
                List<Polygon2D.BooleanOperationsObsolete.Simplex> output1;
                List<Polygon2D.BooleanOperationsObsolete.Simplex> output2;
                Polygon2D.BooleanOperationsObsolete.smethod_8((IList<Polygon2D>)input1Array, (IList<Polygon2D>)input2Array, out output1, out output2, precision);
                List<Polygon2D.BooleanOperationsObsolete.Simplex> s3 = new List<Polygon2D.BooleanOperationsObsolete.Simplex>();
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex simplex in output1)
                {
                    if (simplex.EdgeCharacteristic == 2)
                        s3.Add(simplex);
                }
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex simplex in output2)
                {
                    if (simplex.EdgeCharacteristic == 2)
                        s3.Add(simplex);
                }
                List<Polygon2D> polygon2DList = Polygon2D.BooleanOperationsObsolete.smethod_2(s3);
                Polygon2D.BooleanOperationsObsolete.smethod_5((IList<Polygon2D>)polygon2DList, -vector2D);
                return polygon2DList;
            }

            public static List<Polygon2D> GetDifference(
              IList<Polygon2D> input1,
              IList<Polygon2D> input2,
              double precision)
            {
                Polygon2D[] input1Array = Polygon2D.BooleanOperationsObsolete.smethod_0(input1);
                Polygon2D[] input2Array = Polygon2D.BooleanOperationsObsolete.smethod_0(input2);
                Polygon2D.BooleanOperationsObsolete.smethod_7(input1Array, input2Array, precision);
                Vector2D vector2D = Polygon2D.BooleanOperationsObsolete.smethod_1((IList<Polygon2D>)input1Array, (IList<Polygon2D>)input2Array);
                List<Polygon2D.BooleanOperationsObsolete.Simplex> output1;
                List<Polygon2D.BooleanOperationsObsolete.Simplex> output2;
                Polygon2D.BooleanOperationsObsolete.smethod_10((IList<Polygon2D>)input1Array, (IList<Polygon2D>)input2Array, out output1, out output2, precision);
                List<Polygon2D.BooleanOperationsObsolete.Simplex> s3 = new List<Polygon2D.BooleanOperationsObsolete.Simplex>();
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex simplex in output1)
                {
                    if (simplex.EdgeCharacteristic == 2)
                        s3.Add(simplex);
                }
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex s in output2)
                {
                    if (s.EdgeCharacteristic == 2)
                        s3.Add(Polygon2D.BooleanOperationsObsolete.Simplex.smethod_0(s));
                }
                List<Polygon2D> polygon2DList = Polygon2D.BooleanOperationsObsolete.smethod_2(s3);
                Polygon2D.BooleanOperationsObsolete.smethod_5((IList<Polygon2D>)polygon2DList, -vector2D);
                return polygon2DList;
            }

            public static List<Polygon2D> GetUnion(
              IList<Polygon2D> input1,
              IList<Polygon2D> input2,
              double precision)
            {
                Polygon2D[] input1Array = Polygon2D.BooleanOperationsObsolete.smethod_0(input1);
                Polygon2D[] input2Array = Polygon2D.BooleanOperationsObsolete.smethod_0(input2);
                Polygon2D.BooleanOperationsObsolete.smethod_7(input1Array, input2Array, precision);
                Vector2D vector2D = Polygon2D.BooleanOperationsObsolete.smethod_1((IList<Polygon2D>)input1Array, (IList<Polygon2D>)input2Array);
                List<Polygon2D.BooleanOperationsObsolete.Simplex> output1;
                List<Polygon2D.BooleanOperationsObsolete.Simplex> output2;
                Polygon2D.BooleanOperationsObsolete.smethod_9((IList<Polygon2D>)input1Array, (IList<Polygon2D>)input2Array, out output1, out output2, precision);
                List<Polygon2D.BooleanOperationsObsolete.Simplex> s3 = new List<Polygon2D.BooleanOperationsObsolete.Simplex>();
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex simplex in output1)
                {
                    if (simplex.EdgeCharacteristic == 2)
                        s3.Add(simplex);
                }
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex simplex in output2)
                {
                    if (simplex.EdgeCharacteristic == 2)
                        s3.Add(simplex);
                }
                List<Polygon2D> polygon2DList = Polygon2D.BooleanOperationsObsolete.smethod_2(s3);
                Polygon2D.BooleanOperationsObsolete.smethod_5((IList<Polygon2D>)polygon2DList, -vector2D);
                return polygon2DList;
            }

            public static List<Polygon2D> GetExclusiveOr(
              IList<Polygon2D> input1,
              IList<Polygon2D> input2,
              double precision)
            {
                Polygon2D[] input1Array = Polygon2D.BooleanOperationsObsolete.smethod_0(input1);
                Polygon2D[] input2Array = Polygon2D.BooleanOperationsObsolete.smethod_0(input2);
                Polygon2D.BooleanOperationsObsolete.smethod_7(input1Array, input2Array, precision);
                Vector2D vector2D = Polygon2D.BooleanOperationsObsolete.smethod_1((IList<Polygon2D>)input1Array, (IList<Polygon2D>)input2Array);
                List<Polygon2D.BooleanOperationsObsolete.Simplex> output1;
                List<Polygon2D.BooleanOperationsObsolete.Simplex> output2;
                Polygon2D.BooleanOperationsObsolete.smethod_11((IList<Polygon2D>)input1Array, (IList<Polygon2D>)input2Array, out output1, out output2, precision);
                List<Polygon2D.BooleanOperationsObsolete.Simplex> s3 = new List<Polygon2D.BooleanOperationsObsolete.Simplex>();
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex s in output1)
                {
                    if (s.EdgeCharacteristic == 1)
                        s3.Add(Polygon2D.BooleanOperationsObsolete.Simplex.smethod_0(s));
                    else if (s.EdgeCharacteristic == -1)
                        s3.Add(s);
                }
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex s in output2)
                {
                    if (s.EdgeCharacteristic == 1)
                        s3.Add(Polygon2D.BooleanOperationsObsolete.Simplex.smethod_0(s));
                    else if (s.EdgeCharacteristic == -1)
                        s3.Add(s);
                }
                List<Polygon2D> polygon2DList = Polygon2D.BooleanOperationsObsolete.smethod_2(s3);
                Polygon2D.BooleanOperationsObsolete.smethod_5((IList<Polygon2D>)polygon2DList, -vector2D);
                return polygon2DList;
            }

            private static Polygon2D[] smethod_0(IList<Polygon2D> input1)
            {
                Polygon2D[] polygon2DArray = new Polygon2D[input1.Count];
                for (int index = 0; index < polygon2DArray.Length; ++index)
                    polygon2DArray[index] = new Polygon2D(input1[index]);
                return polygon2DArray;
            }

            private static Vector2D smethod_1(IList<Polygon2D> input1, IList<Polygon2D> input2)
            {
                Point2D zero = Point2D.Zero;
                Point2D bottomLeft = Polygon2D.BooleanOperationsObsolete.smethod_6(input1, zero);
                Vector2D translation = -(Vector2D)Polygon2D.BooleanOperationsObsolete.smethod_6(input2, bottomLeft) + new Vector2D(1.0, 1.0);
                Polygon2D.BooleanOperationsObsolete.smethod_5(input1, translation);
                Polygon2D.BooleanOperationsObsolete.smethod_5(input2, translation);
                return translation;
            }

            private static List<Polygon2D> smethod_2(
              List<Polygon2D.BooleanOperationsObsolete.Simplex> s3)
            {
                List<Polygon2D> polygon2DList = new List<Polygon2D>();
                Dictionary<Point2D, List<Polygon2D.BooleanOperationsObsolete.Simplex>> startPointToSimplexList = new Dictionary<Point2D, List<Polygon2D.BooleanOperationsObsolete.Simplex>>();
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex s in s3)
                    Polygon2D.BooleanOperationsObsolete.smethod_3(startPointToSimplexList, s);
                while (startPointToSimplexList.Count > 0)
                {
                    Dictionary<Point2D, List<Polygon2D.BooleanOperationsObsolete.Simplex>>.KeyCollection.Enumerator enumerator = startPointToSimplexList.Keys.GetEnumerator();
                    enumerator.MoveNext();
                    Point2D current = enumerator.Current;
                    Polygon2D.BooleanOperationsObsolete.Simplex s1 = startPointToSimplexList[current][0];
                    Polygon2D.BooleanOperationsObsolete.Simplex simplex1 = s1;
                    Polygon2D polygon2D = new Polygon2D();
                    polygon2D.Add(simplex1.Segment.Start);
                    polygon2DList.Add(polygon2D);
                    List<Polygon2D.BooleanOperationsObsolete.Simplex> simplexList1 = new List<Polygon2D.BooleanOperationsObsolete.Simplex>();
                    simplexList1.Add(s1);
                    Polygon2D.BooleanOperationsObsolete.smethod_4(startPointToSimplexList, s1);
                    bool flag1 = false;
                    bool flag2 = true;
                    while (s1 != null)
                    {
                        if (s1.Segment.End == simplex1.Segment.Start)
                        {
                            if (flag1 && flag2 && polygon2D.IsClockwise())
                            {
                                flag2 = false;
                                s1 = simplex1;
                                polygon2D.Clear();
                                polygon2D.Add(simplex1.Segment.Start);
                                foreach (Polygon2D.BooleanOperationsObsolete.Simplex s2 in simplexList1)
                                    Polygon2D.BooleanOperationsObsolete.smethod_3(startPointToSimplexList, s2);
                                simplexList1.Clear();
                                simplexList1.Add(s1);
                                Polygon2D.BooleanOperationsObsolete.smethod_4(startPointToSimplexList, s1);
                            }
                            else
                                s1 = (Polygon2D.BooleanOperationsObsolete.Simplex)null;
                        }
                        else
                        {
                            List<Polygon2D.BooleanOperationsObsolete.Simplex> simplexList2 = startPointToSimplexList[s1.Segment.End];
                            if (simplexList2 == null || simplexList2.Count == 0)
                                throw new InternalException("Could not construct resulting segment chain.");
                            if (simplexList2.Count == 1)
                            {
                                s1 = simplexList2[0];
                                simplexList1.Add(s1);
                                polygon2D.Add(s1.Segment.Start);
                                startPointToSimplexList.Remove(s1.Segment.Start);
                            }
                            else
                            {
                                flag1 = true;
                                double num1 = flag2 ? 0.0 : 2.0 * System.Math.PI;
                                Polygon2D.BooleanOperationsObsolete.Simplex simplex2 = (Polygon2D.BooleanOperationsObsolete.Simplex)null;
                                Vector2D delta1 = s1.Segment.GetDelta();
                                foreach (Polygon2D.BooleanOperationsObsolete.Simplex simplex3 in simplexList2)
                                {
                                    Vector2D delta2 = simplex3.Segment.GetDelta();
                                    double num2 = Vector2D.GetAngle(delta1, delta2) + System.Math.PI;
                                    if (flag2 && num2 >= num1 || !flag2 && num2 <= num1)
                                    {
                                        num1 = num2;
                                        simplex2 = simplex3;
                                    }
                                }
                                s1 = simplex2;
                                simplexList1.Add(s1);
                                polygon2D.Add(s1.Segment.Start);
                                Polygon2D.BooleanOperationsObsolete.smethod_4(startPointToSimplexList, s1);
                            }
                        }
                    }
                }
                return polygon2DList;
            }

            private static void smethod_3(
              Dictionary<Point2D, List<Polygon2D.BooleanOperationsObsolete.Simplex>> startPointToSimplexList,
              Polygon2D.BooleanOperationsObsolete.Simplex s)
            {
                Point2D start = s.Segment.Start;
                List<Polygon2D.BooleanOperationsObsolete.Simplex> simplexList;
                if (!startPointToSimplexList.TryGetValue(start, out simplexList))
                {
                    simplexList = new List<Polygon2D.BooleanOperationsObsolete.Simplex>();
                    startPointToSimplexList.Add(start, simplexList);
                }
                simplexList.Add(s);
            }

            private static void smethod_4(
              Dictionary<Point2D, List<Polygon2D.BooleanOperationsObsolete.Simplex>> startPointToSimplexList,
              Polygon2D.BooleanOperationsObsolete.Simplex s)
            {
                List<Polygon2D.BooleanOperationsObsolete.Simplex> startPointToSimplex = startPointToSimplexList[s.Segment.Start];
                startPointToSimplex.Remove(s);
                if (startPointToSimplex.Count != 0)
                    return;
                startPointToSimplexList.Remove(s.Segment.Start);
            }

            private static void smethod_5(IList<Polygon2D> polygon, Vector2D translation)
            {
                foreach (Polygon2D polygon2D in (IEnumerable<Polygon2D>)polygon)
                {
                    for (int index = 0; index < polygon2D.Count; ++index)
                    {
                        Point2D point2D = polygon2D[index];
                        polygon2D[index] = point2D + translation;
                    }
                }
            }

            private static Point2D smethod_6(IList<Polygon2D> polygon, Point2D bottomLeft)
            {
                foreach (List<Point2D> point2DList in (IEnumerable<Polygon2D>)polygon)
                {
                    foreach (Point2D point2D in point2DList)
                    {
                        if (point2D.X < bottomLeft.X)
                            bottomLeft.X = point2D.X;
                        if (point2D.Y < bottomLeft.Y)
                            bottomLeft.Y = point2D.Y;
                    }
                }
                return bottomLeft;
            }

            private static void smethod_7(
              Polygon2D[] input1Array,
              Polygon2D[] input2Array,
              double precision)
            {
                for (int index1 = 0; index1 < input2Array.Length; ++index1)
                {
                    Polygon2D input2 = input2Array[index1];
                    for (int index2 = 0; index2 < input1Array.Length; ++index2)
                    {
                        Polygon2D input1 = input1Array[index2];
                        for (int index3 = 0; index3 < input2.Count; ++index3)
                        {
                            Point2D a = input2[index3];
                            for (int index4 = 0; index4 < input1.Count; ++index4)
                            {
                                if (Point2D.AreApproxEqual(a, input1[index4], precision))
                                {
                                    input2[index3] = input1[index4];
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            internal static void smethod_8(
              IList<Polygon2D> input1,
              IList<Polygon2D> input2,
              out List<Polygon2D.BooleanOperationsObsolete.Simplex> output1,
              out List<Polygon2D.BooleanOperationsObsolete.Simplex> output2,
              double precision)
            {
                List<Polygon2D.BooleanOperationsObsolete.Simplex> p2_1 = Polygon2D.BooleanOperationsObsolete.smethod_13(input1);
                List<Polygon2D.BooleanOperationsObsolete.Simplex> p2_2 = Polygon2D.BooleanOperationsObsolete.smethod_13(input2);
                List<Polygon2D> output1_1;
                List<Polygon2D> output2_1;
                Polygon2D.BooleanOperationsObsolete.smethod_12(input1, input2, out output1_1, out output2_1, precision);
                output1 = Polygon2D.BooleanOperationsObsolete.smethod_13((IList<Polygon2D>)output1_1);
                output2 = Polygon2D.BooleanOperationsObsolete.smethod_13((IList<Polygon2D>)output2_1);
                Polygon2D.BooleanOperationsObsolete.smethod_15(output1, output2);
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex simplex in output1)
                    simplex.method_0(p2_2, precision);
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex simplex in output2)
                    simplex.method_1(p2_1, precision);
            }

            internal static void smethod_9(
              IList<Polygon2D> input1,
              IList<Polygon2D> input2,
              out List<Polygon2D.BooleanOperationsObsolete.Simplex> output1,
              out List<Polygon2D.BooleanOperationsObsolete.Simplex> output2,
              double precision)
            {
                List<Polygon2D.BooleanOperationsObsolete.Simplex> p2_1 = Polygon2D.BooleanOperationsObsolete.smethod_13(input1);
                List<Polygon2D.BooleanOperationsObsolete.Simplex> p2_2 = Polygon2D.BooleanOperationsObsolete.smethod_13(input2);
                List<Polygon2D> output1_1;
                List<Polygon2D> output2_1;
                Polygon2D.BooleanOperationsObsolete.smethod_12(input1, input2, out output1_1, out output2_1, precision);
                output1 = Polygon2D.BooleanOperationsObsolete.smethod_13((IList<Polygon2D>)output1_1);
                output2 = Polygon2D.BooleanOperationsObsolete.smethod_13((IList<Polygon2D>)output2_1);
                Polygon2D.BooleanOperationsObsolete.smethod_15(output1, output2);
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex simplex in output1)
                    simplex.method_2(p2_2, precision);
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex simplex in output2)
                    simplex.method_3(p2_1, precision);
            }

            internal static void smethod_10(
              IList<Polygon2D> input1,
              IList<Polygon2D> input2,
              out List<Polygon2D.BooleanOperationsObsolete.Simplex> output1,
              out List<Polygon2D.BooleanOperationsObsolete.Simplex> output2,
              double precision)
            {
                List<Polygon2D.BooleanOperationsObsolete.Simplex> p2_1 = Polygon2D.BooleanOperationsObsolete.smethod_13(input1);
                List<Polygon2D.BooleanOperationsObsolete.Simplex> p2_2 = Polygon2D.BooleanOperationsObsolete.smethod_13(input2);
                List<Polygon2D> output1_1;
                List<Polygon2D> output2_1;
                Polygon2D.BooleanOperationsObsolete.smethod_12(input1, input2, out output1_1, out output2_1, precision);
                output1 = Polygon2D.BooleanOperationsObsolete.smethod_13((IList<Polygon2D>)output1_1);
                output2 = Polygon2D.BooleanOperationsObsolete.smethod_13((IList<Polygon2D>)output2_1);
                Polygon2D.BooleanOperationsObsolete.smethod_15(output1, output2);
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex simplex in output1)
                    simplex.method_4(p2_2, precision);
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex simplex in output2)
                    simplex.method_5(p2_1, precision);
            }

            internal static void smethod_11(
              IList<Polygon2D> input1,
              IList<Polygon2D> input2,
              out List<Polygon2D.BooleanOperationsObsolete.Simplex> output1,
              out List<Polygon2D.BooleanOperationsObsolete.Simplex> output2,
              double precision)
            {
                List<Polygon2D.BooleanOperationsObsolete.Simplex> p2_1 = Polygon2D.BooleanOperationsObsolete.smethod_13(input1);
                List<Polygon2D.BooleanOperationsObsolete.Simplex> p2_2 = Polygon2D.BooleanOperationsObsolete.smethod_13(input2);
                List<Polygon2D> output1_1;
                List<Polygon2D> output2_1;
                Polygon2D.BooleanOperationsObsolete.smethod_12(input1, input2, out output1_1, out output2_1, precision);
                output1 = Polygon2D.BooleanOperationsObsolete.smethod_13((IList<Polygon2D>)output1_1);
                output2 = Polygon2D.BooleanOperationsObsolete.smethod_13((IList<Polygon2D>)output2_1);
                Polygon2D.BooleanOperationsObsolete.smethod_15(output1, output2);
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex simplex in output1)
                    simplex.method_6(p2_2, precision);
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex simplex in output2)
                    simplex.method_7(p2_1, precision);
            }

            internal static void smethod_12(
              IList<Polygon2D> input1,
              IList<Polygon2D> input2,
              out List<Polygon2D> output1,
              out List<Polygon2D> output2,
              double precision)
            {
                List<List<Polygon2D.BooleanOperationsObsolete.Class13>> class13ListList1 = new List<List<Polygon2D.BooleanOperationsObsolete.Class13>>(input1.Count);
                foreach (IList<Point2D> polygon in (IEnumerable<Polygon2D>)input1)
                {
                    List<Polygon2D.BooleanOperationsObsolete.Class13> class13List = new List<Polygon2D.BooleanOperationsObsolete.Class13>();
                    Polygon2D.BooleanOperationsObsolete.smethod_14(polygon, (IList<Polygon2D.BooleanOperationsObsolete.Class13>)class13List);
                    class13ListList1.Add(class13List);
                }
                List<List<Polygon2D.BooleanOperationsObsolete.Class13>> class13ListList2 = new List<List<Polygon2D.BooleanOperationsObsolete.Class13>>(input2.Count);
                foreach (IList<Point2D> polygon in (IEnumerable<Polygon2D>)input2)
                {
                    List<Polygon2D.BooleanOperationsObsolete.Class13> class13List = new List<Polygon2D.BooleanOperationsObsolete.Class13>();
                    Polygon2D.BooleanOperationsObsolete.smethod_14(polygon, (IList<Polygon2D.BooleanOperationsObsolete.Class13>)class13List);
                    class13ListList2.Add(class13List);
                }
                foreach (List<Polygon2D.BooleanOperationsObsolete.Class13> class13List1 in class13ListList1)
                {
                    foreach (Polygon2D.BooleanOperationsObsolete.Class13 class13_1 in class13List1)
                    {
                        Segment2D segment1 = class13_1.Segment;
                        foreach (List<Polygon2D.BooleanOperationsObsolete.Class13> class13List2 in class13ListList2)
                        {
                            foreach (Polygon2D.BooleanOperationsObsolete.Class13 class13_2 in class13List2)
                            {
                                Segment2D segment2 = class13_2.Segment;
                                double[] pArray;
                                double[] qArray;
                                if (Segment2D.GetIntersectionParameters(segment1, segment2, out pArray, out qArray, precision))
                                {
                                    Vector2D delta = segment1.GetDelta();
                                    for (int index = 0; index < pArray.Length; ++index)
                                    {
                                        double num1 = pArray[index];
                                        double num2 = qArray[index];
                                        bool flag = false;
                                        Point2D position = Point2D.Zero;
                                        if (MathUtil.AreApproxEqual(num1, 0.0, precision))
                                        {
                                            num1 = 0.0;
                                            position = segment1.Start;
                                            flag = true;
                                        }
                                        else if (MathUtil.AreApproxEqual(num1, 1.0, precision))
                                        {
                                            num1 = 1.0;
                                            position = segment1.End;
                                            flag = true;
                                        }
                                        if (MathUtil.AreApproxEqual(num2, 0.0, precision))
                                        {
                                            num2 = 0.0;
                                            position = segment2.Start;
                                            flag = true;
                                        }
                                        else if (MathUtil.AreApproxEqual(num2, 1.0, precision))
                                        {
                                            num2 = 1.0;
                                            position = segment2.End;
                                            flag = true;
                                        }
                                        if (!flag)
                                            position = segment1.Start + delta * pArray[0];
                                        class13_1.method_0(num1, position);
                                        class13_2.method_0(num2, position);
                                    }
                                }
                            }
                        }
                    }
                }
                output1 = new List<Polygon2D>();
                foreach (List<Polygon2D.BooleanOperationsObsolete.Class13> class13List in class13ListList1)
                {
                    Polygon2D polygon = new Polygon2D();
                    output1.Add(polygon);
                    foreach (Polygon2D.BooleanOperationsObsolete.Class13 class13 in class13List)
                        class13.method_1(polygon);
                    if (polygon[0] == polygon[polygon.Count - 1] && polygon.Count > 1)
                        polygon.RemoveAt(polygon.Count - 1);
                }
                output2 = new List<Polygon2D>();
                foreach (List<Polygon2D.BooleanOperationsObsolete.Class13> class13List in class13ListList2)
                {
                    Polygon2D polygon = new Polygon2D();
                    output2.Add(polygon);
                    foreach (Polygon2D.BooleanOperationsObsolete.Class13 class13 in class13List)
                        class13.method_1(polygon);
                    if (polygon[0] == polygon[polygon.Count - 1] && polygon.Count > 1)
                        polygon.RemoveAt(polygon.Count - 1);
                }
            }

            internal static List<Polygon2D.BooleanOperationsObsolete.Simplex> smethod_13(
              IList<Polygon2D> polygon)
            {
                List<Polygon2D.BooleanOperationsObsolete.Simplex> simplexList = new List<Polygon2D.BooleanOperationsObsolete.Simplex>();
                foreach (Polygon2D polygon2D in (IEnumerable<Polygon2D>)polygon)
                {
                    int count = polygon2D.Count;
                    Point2D p1 = polygon2D[count - 1];
                    for (int index = 0; index < count; ++index)
                    {
                        Point2D p2 = polygon2D[index];
                        Polygon2D.BooleanOperationsObsolete.Simplex simplex = new Polygon2D.BooleanOperationsObsolete.Simplex(p1, p2);
                        simplexList.Add(simplex);
                        p1 = p2;
                    }
                }
                return simplexList;
            }

            internal static void smethod_14(
              IList<Point2D> polygon,
              IList<Polygon2D.BooleanOperationsObsolete.Class13> segments)
            {
                int count = polygon.Count;
                Point2D start = polygon[count - 1];
                for (int index = 0; index < count; ++index)
                {
                    Point2D end = polygon[index];
                    Segment2D segment = new Segment2D(start, end);
                    segments.Add(new Polygon2D.BooleanOperationsObsolete.Class13(segment));
                    start = end;
                }
            }

            internal static void smethod_15(
              List<Polygon2D.BooleanOperationsObsolete.Simplex> sList,
              List<Polygon2D.BooleanOperationsObsolete.Simplex> uList)
            {
                foreach (Polygon2D.BooleanOperationsObsolete.Simplex s in sList)
                {
                    foreach (Polygon2D.BooleanOperationsObsolete.Simplex u in uList)
                    {
                        if (s.Segment.Start == u.Segment.Start && s.Segment.End == u.Segment.End)
                        {
                            s.DirectedEdgeOfP2 = true;
                            u.DirectedEdgeOfP2 = true;
                        }
                        else if (s.Segment.Start == u.Segment.End && s.Segment.End == u.Segment.Start)
                        {
                            s.NegativeDirectedEdgeOfP2 = true;
                            u.NegativeDirectedEdgeOfP2 = true;
                        }
                    }
                }
            }

            internal struct Struct0 : IComparable<Polygon2D.BooleanOperationsObsolete.Struct0>
            {
                private double double_0;
                private Point2D point2D_0;

                internal Struct0(double u, Point2D position)
                {
                    this.double_0 = u;
                    this.point2D_0 = position;
                }

                internal double U
                {
                    get
                    {
                        return this.double_0;
                    }
                }

                internal Point2D Position
                {
                    get
                    {
                        return this.point2D_0;
                    }
                }

                public int CompareTo(Polygon2D.BooleanOperationsObsolete.Struct0 other)
                {
                    if (this.double_0 < other.double_0)
                        return -1;
                    return this.double_0 > other.double_0 ? 1 : 0;
                }
            }

            internal class Class13
            {
                private Segment2D segment2D_0;
                private List<Polygon2D.BooleanOperationsObsolete.Struct0> list_0;

                internal Class13(Segment2D segment)
                {
                    this.segment2D_0 = segment;
                }

                internal void method_0(double u, Point2D position)
                {
                    if (this.list_0 == null)
                        this.list_0 = new List<Polygon2D.BooleanOperationsObsolete.Struct0>(2);
                    this.list_0.Add(new Polygon2D.BooleanOperationsObsolete.Struct0(u, position));
                }

                internal Segment2D Segment
                {
                    get
                    {
                        return this.segment2D_0;
                    }
                }

                internal void method_1(Polygon2D polygon)
                {
                    if (polygon.Count == 0 || polygon[polygon.Count - 1] != this.segment2D_0.Start)
                        polygon.Add(this.segment2D_0.Start);
                    if (this.list_0 == null)
                        return;
                    this.list_0.Sort();
                    foreach (Polygon2D.BooleanOperationsObsolete.Struct0 struct0 in this.list_0)
                    {
                        if (polygon[polygon.Count - 1] != struct0.Position)
                            polygon.Add(struct0.Position);
                    }
                }
            }

            [Serializable]
            internal class Simplex
            {
                private Segment2D segment;
                private int alpha;
                private bool directedEdgeOfP2;
                private bool negativeDirectedEdgeOfP2;
                private int edgeCharacteristic;

                internal Simplex(Point2D p1, Point2D p2)
                  : this(new Segment2D(p1, p2))
                {
                }

                internal Simplex(Segment2D segment)
                {
                    this.segment = segment;
                    double area = Polygon2D.GetArea((IList<Point2D>)new Point2D[3] { segment.Start, segment.End, Point2D.Zero });
                    if (area < 0.0)
                        this.alpha = -2;
                    else if (area > 0.0)
                        this.alpha = 2;
                    else
                        this.alpha = 0;
                }

                internal Simplex(Segment2D segment, int alpha)
                {
                    this.segment = segment;
                    this.alpha = alpha;
                }

                internal Segment2D Segment
                {
                    get
                    {
                        return this.segment;
                    }
                }

                internal int Alpha
                {
                    get
                    {
                        return this.alpha;
                    }
                }

                internal int EdgeCharacteristic
                {
                    get
                    {
                        return this.edgeCharacteristic;
                    }
                    set
                    {
                        this.edgeCharacteristic = value;
                    }
                }

                internal bool DirectedEdgeOfP2
                {
                    get
                    {
                        return this.directedEdgeOfP2;
                    }
                    set
                    {
                        this.directedEdgeOfP2 = value;
                    }
                }

                internal bool NegativeDirectedEdgeOfP2
                {
                    get
                    {
                        return this.negativeDirectedEdgeOfP2;
                    }
                    set
                    {
                        this.negativeDirectedEdgeOfP2 = value;
                    }
                }

                internal void method_0(
                  List<Polygon2D.BooleanOperationsObsolete.Simplex> p2,
                  double precision)
                {
                    if (this.directedEdgeOfP2)
                        this.edgeCharacteristic = 2;
                    else if (this.negativeDirectedEdgeOfP2)
                        this.edgeCharacteristic = 0;
                    else
                        this.edgeCharacteristic = this.method_8(p2, precision);
                }

                internal void method_1(
                  List<Polygon2D.BooleanOperationsObsolete.Simplex> p2,
                  double precision)
                {
                    if (this.directedEdgeOfP2)
                        this.edgeCharacteristic = 0;
                    else if (this.negativeDirectedEdgeOfP2)
                        this.edgeCharacteristic = 0;
                    else
                        this.edgeCharacteristic = this.method_8(p2, precision);
                }

                internal void method_2(
                  List<Polygon2D.BooleanOperationsObsolete.Simplex> p2,
                  double precision)
                {
                    if (this.directedEdgeOfP2)
                        this.edgeCharacteristic = 2;
                    else if (this.negativeDirectedEdgeOfP2)
                        this.edgeCharacteristic = 0;
                    else
                        this.edgeCharacteristic = 2 - this.method_8(p2, precision);
                }

                internal void method_3(
                  List<Polygon2D.BooleanOperationsObsolete.Simplex> p2,
                  double precision)
                {
                    if (this.directedEdgeOfP2)
                        this.edgeCharacteristic = 0;
                    else if (this.negativeDirectedEdgeOfP2)
                        this.edgeCharacteristic = 0;
                    else
                        this.edgeCharacteristic = 2 - this.method_8(p2, precision);
                }

                internal void method_4(
                  List<Polygon2D.BooleanOperationsObsolete.Simplex> p2,
                  double precision)
                {
                    if (this.directedEdgeOfP2)
                        this.edgeCharacteristic = 0;
                    else if (this.negativeDirectedEdgeOfP2)
                        this.edgeCharacteristic = 2;
                    else
                        this.edgeCharacteristic = 2 - this.method_8(p2, precision);
                }

                internal void method_5(
                  List<Polygon2D.BooleanOperationsObsolete.Simplex> p2,
                  double precision)
                {
                    if (this.directedEdgeOfP2)
                        this.edgeCharacteristic = 0;
                    else if (this.negativeDirectedEdgeOfP2)
                        this.edgeCharacteristic = 0;
                    else
                        this.edgeCharacteristic = this.method_8(p2, precision);
                }

                internal void method_6(
                  List<Polygon2D.BooleanOperationsObsolete.Simplex> p2,
                  double precision)
                {
                    if (this.directedEdgeOfP2)
                        this.edgeCharacteristic = 0;
                    else if (this.negativeDirectedEdgeOfP2)
                        this.edgeCharacteristic = 0;
                    else
                        this.edgeCharacteristic = this.method_8(p2, precision) - 1;
                }

                internal void method_7(
                  List<Polygon2D.BooleanOperationsObsolete.Simplex> p2,
                  double precision)
                {
                    if (this.directedEdgeOfP2)
                        this.edgeCharacteristic = 0;
                    else if (this.negativeDirectedEdgeOfP2)
                        this.edgeCharacteristic = 0;
                    else
                        this.edgeCharacteristic = this.method_8(p2, precision) - 1;
                }

                private int method_8(
                  List<Polygon2D.BooleanOperationsObsolete.Simplex> p2,
                  double precision)
                {
                    int num = 0;
                    Point2D center = this.segment.GetCenter();
                    foreach (Polygon2D.BooleanOperationsObsolete.Simplex simplex in p2)
                    {
                        if (!new Segment2D(Point2D.Zero, simplex.segment.Start).Contains(center, precision) && !new Segment2D(Point2D.Zero, simplex.segment.End).Contains(center, precision))
                        {
                            if (simplex.alpha > 0)
                            {
                                if (Triangle2D.ContainsPoint(center, simplex.segment.End, simplex.segment.Start, Point2D.Zero, precision))
                                    num += simplex.alpha;
                            }
                            else if (simplex.alpha < 0 && Triangle2D.ContainsPoint(center, simplex.segment.Start, simplex.segment.End, Point2D.Zero, precision))
                                num += simplex.alpha;
                        }
                        else
                            num += simplex.alpha >> 1;
                    }
                    return num;
                }

                [SpecialName]
                public static Polygon2D.BooleanOperationsObsolete.Simplex smethod_0(
                  Polygon2D.BooleanOperationsObsolete.Simplex s)
                {
                    return new Polygon2D.BooleanOperationsObsolete.Simplex(new Segment2D(s.segment.End, s.segment.Start), -s.alpha);
                }

                public override string ToString()
                {
                    return this.segment.ToString() + ", " + this.alpha.ToString() + ", " + this.directedEdgeOfP2.ToString() + ", " + this.negativeDirectedEdgeOfP2.ToString() + ", " + this.edgeCharacteristic.ToString();
                }
            }

            [Serializable]
            internal class DebugInfo
            {
                private IList<Polygon2D> polygons1;
                private IList<Polygon2D> polygons2;
                private IList<Polygon2D.BooleanOperationsObsolete.Simplex> simplices1;
                private IList<Polygon2D.BooleanOperationsObsolete.Simplex> simplices2;
                private IList<Polygon2D.BooleanOperationsObsolete.Simplex> simplices;

                public IList<Polygon2D> Polygons1
                {
                    get
                    {
                        return this.polygons1;
                    }
                    set
                    {
                        this.polygons1 = value;
                    }
                }

                public IList<Polygon2D> Polygons2
                {
                    get
                    {
                        return this.polygons2;
                    }
                    set
                    {
                        this.polygons2 = value;
                    }
                }

                public IList<Polygon2D.BooleanOperationsObsolete.Simplex> Simplices1
                {
                    get
                    {
                        return this.simplices1;
                    }
                    set
                    {
                        this.simplices1 = value;
                    }
                }

                public IList<Polygon2D.BooleanOperationsObsolete.Simplex> Simplices2
                {
                    get
                    {
                        return this.simplices2;
                    }
                    set
                    {
                        this.simplices2 = value;
                    }
                }

                public IList<Polygon2D.BooleanOperationsObsolete.Simplex> Simplices
                {
                    get
                    {
                        return this.simplices;
                    }
                    set
                    {
                        this.simplices = value;
                    }
                }
            }
        }

        private static class Class14
        {
            public static bool smethod_0(ICollection<IList<Point2D>> polygons, double precision)
            {
                if (polygons == null || polygons.Count < 2)
                    return false;
                bool flag = false;
                List<Polygon2D.Class14.Class20> class20List = new List<Polygon2D.Class14.Class20>();
                foreach (IList<Point2D> polygon in (IEnumerable<IList<Point2D>>)polygons)
                {
                    Polygon2D.Class14.Class20 class20_1 = new Polygon2D.Class14.Class20(polygon);
                    foreach (Polygon2D.Class14.Class20 class20_2 in class20List)
                    {
                        if (class20_1.Bounds.Overlaps(class20_2.Bounds))
                        {
                            class20_1.BoundsOverlap = true;
                            class20_2.BoundsOverlap = true;
                            flag = true;
                        }
                    }
                    class20List.Add(class20_1);
                }
                if (!flag)
                    return false;
                Polygon2D.Class14.Class23 eventQueue = new Polygon2D.Class14.Class23();
                int segmentId = 0;
                List<Polygon2D.Class14.Class15> class15List = new List<Polygon2D.Class14.Class15>();
                foreach (Polygon2D.Class14.Class20 class20 in class20List)
                {
                    if (class20.BoundsOverlap)
                    {
                        Polygon2D.Class14.Class15 polygonHelper = new Polygon2D.Class14.Class15(class20.Polygon);
                        class15List.Add(polygonHelper);
                        eventQueue.method_4(polygonHelper, precision, ref segmentId);
                    }
                }
                if (class15List.Count < 2)
                    return false;
                Polygon2D.Class14.Class19 class19 = new Polygon2D.Class14.Class19((IList<Polygon2D.Class14.Class15>)class15List, eventQueue, precision);
                class19.method_0();
                return class19.Overlaps;
            }

            private class Class15
            {
                private readonly IList<Point2D> ilist_0;
                private IntervalD intervalD_0;
                private int int_0;

                public Class15(IList<Point2D> polygon)
                {
                    this.ilist_0 = polygon;
                }

                public IList<Point2D> Polygon
                {
                    get
                    {
                        return this.ilist_0;
                    }
                }

                public IntervalD SweepLineInterval
                {
                    get
                    {
                        return this.intervalD_0;
                    }
                    set
                    {
                        this.intervalD_0 = value;
                    }
                }

                public int SweepLineIntersectionCount
                {
                    get
                    {
                        return this.int_0;
                    }
                    set
                    {
                        this.int_0 = value;
                    }
                }

                public void method_0()
                {
                    this.intervalD_0 = (IntervalD)null;
                    this.int_0 = 0;
                }
            }

            private class Class16
            {
                private int int_0;
                private Polygon2D.Class14.Class15 class15_0;
                private Polygon2D.Class14.Class16 class16_0;
                private Segment2D segment2D_0;
                private Vector2D vector2D_0;
                private Point2D point2D_0;
                private double double_0;
                private List<Polygon2D.Class14.Class16> list_0;
                private RedBlackTree<Polygon2D.Class14.Class16>.Node node_0;

                public Class16(
                  int id,
                  Polygon2D.Class14.Class15 polygon,
                  Segment2D segment,
                  double precision)
                {
                    this.int_0 = id;
                    this.class15_0 = polygon;
                    this.segment2D_0 = segment;
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

                public int Id
                {
                    get
                    {
                        return this.int_0;
                    }
                }

                public Polygon2D.Class14.Class15 Polygon
                {
                    get
                    {
                        return this.class15_0;
                    }
                }

                public Polygon2D.Class14.Class16 PreviousSegment
                {
                    get
                    {
                        return this.class16_0;
                    }
                    set
                    {
                        this.class16_0 = value;
                    }
                }

                public Segment2D Segment
                {
                    get
                    {
                        return this.segment2D_0;
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

                public RedBlackTree<Polygon2D.Class14.Class16>.Node Node
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

                public void method_0(Polygon2D.Class14.Class16 segmentHelper)
                {
                    if (this.list_0 == null)
                        this.list_0 = new List<Polygon2D.Class14.Class16>();
                    this.list_0.Add(segmentHelper);
                }

                public bool method_1(Polygon2D.Class14.Class16 segmentHelper)
                {
                    if (this.list_0 == null)
                        return false;
                    return this.list_0.Contains(segmentHelper);
                }

                public void method_2(double x)
                {
                    if (this.point2D_0.X == x)
                        return;
                    double y = !double.IsPositiveInfinity(this.double_0) ? this.segment2D_0.Start.Y + (x - this.segment2D_0.Start.X) * this.double_0 : System.Math.Min(this.segment2D_0.Start.Y, this.segment2D_0.End.Y);
                    this.point2D_0 = new Point2D(x, y);
                }

                public bool method_3(Polygon2D.Class14.Class16 other)
                {
                    if (this.class16_0 != other)
                        return other.class16_0 == this;
                    return true;
                }

                public override string ToString()
                {
                    return string.Format("Segment: {0}, sweepline intersection: {1}", (object)this.segment2D_0, (object)this.point2D_0);
                }
            }

            private class Class23 : RedBlackTree<Polygon2D.Class14.Class17>
            {
                public void method_4(
                  Polygon2D.Class14.Class15 polygonHelper,
                  double precision,
                  ref int segmentId)
                {
                    IList<Point2D> polygon = polygonHelper.Polygon;
                    Polygon2D.Class14.Class17.Class18 class18 = new Polygon2D.Class14.Class17.Class18();
                    Point2D point2D1 = polygon[polygon.Count - 1];
                    Polygon2D.Class14.Class16 class16_1 = (Polygon2D.Class14.Class16)null;
                    Polygon2D.Class14.Class16 class16_2 = (Polygon2D.Class14.Class16)null;
                    foreach (Point2D point2D2 in (IEnumerable<Point2D>)polygon)
                    {
                        Point2D a = point2D1;
                        Point2D b = point2D2;
                        if (!Point2D.AreApproxEqual(a, b, precision))
                        {
                            if (a.X > b.X || a.X == b.X && a.Y > b.Y)
                                MathUtil.Swap<Point2D>(ref a, ref b);
                            Polygon2D.Class14.Class16 class16_3 = new Polygon2D.Class14.Class16(segmentId++, polygonHelper, new Segment2D(a, b), precision);
                            class16_3.PreviousSegment = class16_1;
                            if (class16_2 == null)
                                class16_2 = class16_3;
                            double num1 = a.X + precision;
                            double num2 = b.X - precision;
                            bool flag = num1 >= num2;
                            Point2D position1 = new Point2D(flag ? a.X : num1, a.Y);
                            Point2D position2 = new Point2D(flag ? b.X : num2, b.Y);
                            class18.Position = position1;
                            Polygon2D.Class14.Class17 class17_1 = this.Find((IComparable<Polygon2D.Class14.Class17>)class18);
                            if (class17_1 == null)
                            {
                                class17_1 = new Polygon2D.Class14.Class17(position1);
                                this.Add(class17_1);
                            }
                            class17_1.EntrySegmentsNotNull.Add(class16_3);
                            class18.Position = position2;
                            Polygon2D.Class14.Class17 class17_2 = this.Find((IComparable<Polygon2D.Class14.Class17>)class18);
                            if (class17_2 == null)
                            {
                                class17_2 = new Polygon2D.Class14.Class17(position2);
                                this.Add(class17_2);
                            }
                            class17_2.ExitSegmentsNotNull.Add(class16_3);
                            class16_1 = class16_3;
                            point2D1 = point2D2;
                        }
                    }
                    if (class16_2 == null)
                        return;
                    class16_2.PreviousSegment = class16_1;
                }
            }

            private class Class17 : IComparable<Polygon2D.Class14.Class17>
            {
                private Point2D point2D_0;
                private List<Polygon2D.Class14.Class16> list_0;
                private List<Polygon2D.Class14.Class16> list_1;
                private List<Polygon2D.Class14.Class16> list_2;

                public Class17(Point2D position)
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

                public List<Polygon2D.Class14.Class16> EntrySegments
                {
                    get
                    {
                        return this.list_0;
                    }
                }

                public List<Polygon2D.Class14.Class16> ExitSegments
                {
                    get
                    {
                        return this.list_1;
                    }
                }

                public List<Polygon2D.Class14.Class16> ReorderSegments
                {
                    get
                    {
                        return this.list_2;
                    }
                }

                public List<Polygon2D.Class14.Class16> EntrySegmentsNotNull
                {
                    get
                    {
                        if (this.list_0 == null)
                            this.list_0 = new List<Polygon2D.Class14.Class16>();
                        return this.list_0;
                    }
                }

                public List<Polygon2D.Class14.Class16> ExitSegmentsNotNull
                {
                    get
                    {
                        if (this.list_1 == null)
                            this.list_1 = new List<Polygon2D.Class14.Class16>();
                        return this.list_1;
                    }
                }

                public List<Polygon2D.Class14.Class16> ReorderSegmentsNotNull
                {
                    get
                    {
                        if (this.list_2 == null)
                            this.list_2 = new List<Polygon2D.Class14.Class16>();
                        return this.list_2;
                    }
                }

                public override string ToString()
                {
                    return this.point2D_0.ToString();
                }

                public int CompareTo(Polygon2D.Class14.Class17 other)
                {
                    if (this.point2D_0.X < other.point2D_0.X)
                        return -1;
                    return this.point2D_0.X > other.point2D_0.X ? 1 : 0;
                }

                public class Class18 : IComparable<Polygon2D.Class14.Class17>
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

                    public int CompareTo(Polygon2D.Class14.Class17 other)
                    {
                        if (this.point2D_0.X < other.point2D_0.X)
                            return -1;
                        return this.point2D_0.X > other.point2D_0.X ? 1 : 0;
                    }
                }
            }

            private class Class19 : IComparer<Polygon2D.Class14.Class16>
            {
                private IList<Polygon2D.Class14.Class15> ilist_0;
                private Polygon2D.Class14.Class23 class23_0;
                private RedBlackTree<Polygon2D.Class14.Class17>.ForwardEnumerator forwardEnumerator_0;
                private double double_0;
                private RedBlackTree<Polygon2D.Class14.Class16> redBlackTree_0;
                private bool bool_0;
                private Polygon2D.Class14.Class17 class17_0;
                private RedBlackTree<Polygon2D.Class14.Class16>.ForwardEnumerator forwardEnumerator_1;
                private Polygon2D.Class14.Class17.Class18 class18_0;

                public Class19(
                  IList<Polygon2D.Class14.Class15> polygons,
                  Polygon2D.Class14.Class23 eventQueue,
                  double precision)
                {
                    this.ilist_0 = polygons;
                    this.class23_0 = eventQueue;
                    this.double_0 = precision;
                    this.forwardEnumerator_0 = (RedBlackTree<Polygon2D.Class14.Class17>.ForwardEnumerator)eventQueue.GetEnumerator();
                    this.redBlackTree_0 = new RedBlackTree<Polygon2D.Class14.Class16>((IComparer<Polygon2D.Class14.Class16>)this);
                    this.forwardEnumerator_1 = new RedBlackTree<Polygon2D.Class14.Class16>.ForwardEnumerator(this.redBlackTree_0);
                    this.class18_0 = new Polygon2D.Class14.Class17.Class18();
                }

                public bool Overlaps
                {
                    get
                    {
                        return this.bool_0;
                    }
                }

                public void method_0()
                {
                    this.bool_0 = false;
                    while (this.forwardEnumerator_0.MoveNext())
                    {
                        this.class17_0 = this.forwardEnumerator_0.Current;
                        if (this.class17_0.EntrySegments != null)
                        {
                            foreach (Polygon2D.Class14.Class16 entrySegment in this.class17_0.EntrySegments)
                            {
                                if (this.method_2(entrySegment))
                                    return;
                            }
                        }
                        if (this.class17_0.ExitSegments != null)
                        {
                            foreach (Polygon2D.Class14.Class16 exitSegment in this.class17_0.ExitSegments)
                                this.method_1(exitSegment);
                        }
                        if (this.class17_0.ReorderSegments != null)
                        {
                            foreach (Polygon2D.Class14.Class16 reorderSegment in this.class17_0.ReorderSegments)
                                this.method_1(reorderSegment);
                            foreach (Polygon2D.Class14.Class16 reorderSegment in this.class17_0.ReorderSegments)
                            {
                                if (this.method_2(reorderSegment))
                                    return;
                            }
                        }
                        if (this.redBlackTree_0.Count > 2)
                        {
                            foreach (Polygon2D.Class14.Class15 class15 in (IEnumerable<Polygon2D.Class14.Class15>)this.ilist_0)
                                class15.method_0();
                            Queue<Polygon2D.Class14.Class15> class15Queue = new Queue<Polygon2D.Class14.Class15>();
                            foreach (Polygon2D.Class14.Class16 class16 in this.redBlackTree_0)
                            {
                                if (!double.IsPositiveInfinity(class16.Slope))
                                {
                                    class16.method_2(this.class17_0.Position.X);
                                    if (class16.Polygon.SweepLineIntersectionCount % 2 == 0)
                                    {
                                        if (class16.Polygon.SweepLineInterval == null)
                                        {
                                            class16.Polygon.SweepLineInterval = new IntervalD(class16.SweepLineIntersection.Y, false, class16.SweepLineIntersection.Y, false);
                                        }
                                        else
                                        {
                                            class16.Polygon.SweepLineInterval.Min = class16.SweepLineIntersection.Y;
                                            class16.Polygon.SweepLineInterval.Max = class16.SweepLineIntersection.Y;
                                        }
                                    }
                                    else
                                    {
                                        class16.Polygon.SweepLineInterval.Max = class16.SweepLineIntersection.Y;
                                        if (!class15Queue.Contains(class16.Polygon))
                                            class15Queue.Enqueue(class16.Polygon);
                                    }
                                    ++class16.Polygon.SweepLineIntersectionCount;
                                    foreach (Polygon2D.Class14.Class15 class15 in class15Queue)
                                    {
                                        if (class15 != class16.Polygon && class15.SweepLineInterval.Overlaps(class16.Polygon.SweepLineInterval, this.double_0))
                                        {
                                            this.bool_0 = true;
                                            return;
                                        }
                                    }
                                    if (class15Queue.Count > 1)
                                        class15Queue.Dequeue();
                                }
                            }
                        }
                    }
                }

                private void method_1(Polygon2D.Class14.Class16 segment)
                {
                    this.redBlackTree_0.Remove(segment.Node);
                    segment.Node = (RedBlackTree<Polygon2D.Class14.Class16>.Node)null;
                }

                private bool method_2(Polygon2D.Class14.Class16 segment)
                {
                    RedBlackTree<Polygon2D.Class14.Class16>.Node node = this.redBlackTree_0.TryAdd(segment);
                    segment.Node = node;
                    this.forwardEnumerator_1.CurrentNode = node;
                    if (this.forwardEnumerator_1.MovePrevious())
                    {
                        RedBlackTree<Polygon2D.Class14.Class16>.Node currentNode = this.forwardEnumerator_1.CurrentNode;
                        currentNode.Value.method_2(this.class17_0.Position.X);
                        if (this.method_3(segment, currentNode.Value, this.class17_0.Position))
                            return true;
                        while (this.forwardEnumerator_1.MovePrevious())
                        {
                            this.forwardEnumerator_1.CurrentNode.Value.method_2(this.class17_0.Position.X);
                            if (MathUtil.AreApproxEqual(currentNode.Value.SweepLineIntersection.Y, this.forwardEnumerator_1.Current.SweepLineIntersection.Y, this.double_0))
                            {
                                if (this.method_3(segment, currentNode.Value, this.class17_0.Position))
                                    return true;
                            }
                            else
                                break;
                        }
                    }
                    this.forwardEnumerator_1.CurrentNode = node;
                    if (this.forwardEnumerator_1.MoveNext())
                    {
                        RedBlackTree<Polygon2D.Class14.Class16>.Node currentNode = this.forwardEnumerator_1.CurrentNode;
                        currentNode.Value.method_2(this.class17_0.Position.X);
                        if (this.method_3(segment, currentNode.Value, this.class17_0.Position))
                            return true;
                        while (this.forwardEnumerator_1.MovePrevious())
                        {
                            this.forwardEnumerator_1.CurrentNode.Value.method_2(this.class17_0.Position.X);
                            if (MathUtil.AreApproxEqual(currentNode.Value.SweepLineIntersection.Y, this.forwardEnumerator_1.Current.SweepLineIntersection.Y, this.double_0))
                            {
                                if (this.method_3(segment, currentNode.Value, this.class17_0.Position))
                                    return true;
                            }
                            else
                                break;
                        }
                    }
                    return false;
                }

                private bool method_3(
                  Polygon2D.Class14.Class16 segment,
                  Polygon2D.Class14.Class16 otherSegment,
                  Point2D minPosition)
                {
                    double num = minPosition.Y + this.double_0;
                    if (!segment.method_1(otherSegment))
                    {
                        if (segment.Polygon == otherSegment.Polygon)
                        {
                            double[] pArray;
                            double[] qArray;
                            if (!segment.method_3(otherSegment) && Segment2D.GetIntersectionParameters(segment.Segment, otherSegment.Segment, out pArray, out qArray, this.double_0) && pArray.Length == 1)
                            {
                                for (int index = 0; index < pArray.Length; ++index)
                                {
                                    Point2D position = segment.Segment.Start + pArray[index] * segment.Segment.GetDelta();
                                    if (position.X >= minPosition.X && (position.X != minPosition.X || position.Y > num))
                                    {
                                        this.class18_0.Position = position;
                                        Polygon2D.Class14.Class17 class17 = this.class23_0.Find((IComparable<Polygon2D.Class14.Class17>)this.class18_0);
                                        if (class17 == null)
                                        {
                                            class17 = new Polygon2D.Class14.Class17(position);
                                            this.class23_0.Add(class17);
                                        }
                                        if (!double.IsInfinity(segment.Slope) && !double.IsInfinity(otherSegment.Slope))
                                        {
                                            if (!class17.ReorderSegmentsNotNull.Contains(segment) && !MathUtil.AreApproxEqual(class17.Position.X, segment.Segment.Start.X, this.double_0) && (!MathUtil.AreApproxEqual(class17.Position.X, segment.Segment.End.X, this.double_0) && (class17.ExitSegments == null || !class17.ExitSegments.Contains(segment))))
                                                class17.ReorderSegments.Add(segment);
                                            if (!class17.ReorderSegments.Contains(otherSegment) && !MathUtil.AreApproxEqual(class17.Position.X, otherSegment.Segment.Start.X, this.double_0) && (!MathUtil.AreApproxEqual(class17.Position.X, otherSegment.Segment.End.X, this.double_0) && (class17.ExitSegments == null || !class17.ExitSegments.Contains(segment))))
                                                class17.ReorderSegments.Add(otherSegment);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            bool areOverlapping;
                            if (Segment2D.Intersects(segment.Segment, otherSegment.Segment, out areOverlapping) && !areOverlapping)
                            {
                                this.bool_0 = true;
                                return true;
                            }
                        }
                        segment.method_0(otherSegment);
                        otherSegment.method_0(segment);
                    }
                    return false;
                }

                public int Compare(Polygon2D.Class14.Class16 x, Polygon2D.Class14.Class16 y)
                {
                    x.method_2(this.class17_0.Position.X);
                    y.method_2(this.class17_0.Position.X);
                    return x.SweepLineIntersection.Y >= y.SweepLineIntersection.Y ? (x.SweepLineIntersection.Y <= y.SweepLineIntersection.Y ? (x.Direction.Y >= y.Direction.Y ? (x.Direction.Y <= y.Direction.Y ? (x.Id >= y.Id ? (x.Id <= y.Id ? 0 : 1) : -1) : 1) : -1) : 1) : -1;
                }
            }

            private class Class20
            {
                private Bounds2D bounds2D_0 = new Bounds2D();
                private IList<Point2D> ilist_0;
                private bool bool_0;

                public Class20(IList<Point2D> polygon)
                {
                    this.ilist_0 = polygon;
                    this.bounds2D_0.Update(polygon);
                }

                public IList<Point2D> Polygon
                {
                    get
                    {
                        return this.ilist_0;
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

        internal class Class21 : ISegment2DIterator
        {
            private int int_0 = -1;
            private readonly List<Point2D> list_0;

            private Class21(List<Point2D> polygon)
            {
                this.list_0 = new List<Point2D>((IEnumerable<Point2D>)polygon);
                if (polygon.Count != 1)
                    return;
                this.list_0.AddRange((IEnumerable<Point2D>)polygon);
            }

            public static ISegment2DIterator smethod_0(List<Point2D> polygon)
            {
                if (polygon.Count == 0)
                    return (ISegment2DIterator)NullSegment2DIterator.Instance;
                return (ISegment2DIterator)new Polygon2D.Class21(polygon);
            }

            public bool MoveNext()
            {
                if (this.int_0 >= this.list_0.Count)
                    return false;
                ++this.int_0;
                return true;
            }

            public SegmentType CurrentType
            {
                get
                {
                    if (this.int_0 == this.list_0.Count)
                        return SegmentType.Close;
                    return this.int_0 != 0 ? SegmentType.LineTo : SegmentType.MoveTo;
                }
            }

            public SegmentType Current(Point2D[] points, int offset)
            {
                if (this.int_0 == this.list_0.Count)
                    return SegmentType.Close;
                points[offset] = this.list_0[this.int_0];
                return this.int_0 != 0 ? SegmentType.LineTo : SegmentType.MoveTo;
            }

            public int TotalSegmentCount
            {
                get
                {
                    return this.list_0.Count + 1;
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
    }
}
