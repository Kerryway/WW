// Decompiled with JetBrains decompiler
// Type: ns6.Class65
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using WW.Collections.Generic;
using WW.Math;
using WW.Math.Geometry;

namespace ns6
{
    internal class Class65
    {
        private static Polygon2D[] polygon2D_0 = new Polygon2D[0];

        public static IList<Polygon2D> smethod_0(
          IList<Polygon2D> clip,
          IList<Polygon2D> subject,
          Class65.Enum1 fillMode)
        {
            List<Class65.Class66> localMinimumList = new List<Class65.Class66>();
            foreach (Polygon2D polygon in (IEnumerable<Polygon2D>)clip)
                Class65.smethod_1(polygon, (byte)1, localMinimumList);
            foreach (Polygon2D polygon in (IEnumerable<Polygon2D>)subject)
                Class65.smethod_1(polygon, (byte)2, localMinimumList);
            localMinimumList.Sort();
            Class65.Class66 localMinimum = (Class65.Class66)null;
            if (localMinimumList.Count > 1)
            {
                Class65.Class66 class66_1 = localMinimumList[localMinimumList.Count - 1];
                for (int index = localMinimumList.Count - 2; index >= 0; --index)
                {
                    Class65.Class66 class66_2 = localMinimumList[index];
                    class66_2.Next = class66_1;
                    class66_1 = class66_2;
                }
                localMinimum = class66_1;
            }
            Class65.Class70 class70 = new Class65.Class70();
            if (localMinimum != null)
                class70.EventQueue.Add(localMinimum);
            class70.method_0();
            if (class70.ResultPolygons.Count == 0)
                return (IList<Polygon2D>)Class65.polygon2D_0;
            List<Polygon2D> polygon2DList = new List<Polygon2D>(class70.ResultPolygons.Count);
            foreach (Class65.Class72 resultPolygon in class70.ResultPolygons)
            {
                if (resultPolygon.Count > 2)
                    polygon2DList.Add(resultPolygon.method_0());
            }
            if (polygon2DList.Count == 0)
                return (IList<Polygon2D>)Class65.polygon2D_0;
            return (IList<Polygon2D>)polygon2DList;
        }

        internal static void smethod_1(
          Polygon2D polygon,
          byte type,
          List<Class65.Class66> localMinimumList)
        {
            if (polygon.Count == 0)
                return;
            Point2D point2D1 = polygon[polygon.Count - 1];
            Point2D p = polygon[0];
            Class65.Class75 class75 = Class65.Class75.smethod_0(point2D1.X, point2D1.Y, p.X, p.Y);
            Class65.Class75 e0 = class75;
            int num1 = System.Math.Sign(p.Y - point2D1.Y);
            if (num1 == 0)
                num1 = 1;
            int num2 = num1;
            for (int index = 1; index < polygon.Count; ++index)
            {
                Point2D point2D2 = polygon[index];
                Class65.Class75 e1 = Class65.Class75.smethod_0(p.X, p.Y, point2D2.X, point2D2.Y);
                int num3 = System.Math.Sign(point2D2.Y - p.Y);
                if (num3 == 0)
                    num3 = 1;
                if (num3 == num1)
                {
                    if (num3 > 0)
                        e0.Successor = e1;
                    else
                        e1.Successor = e0;
                }
                else if (num3 > 0 && num1 < 0)
                    Class65.smethod_2(type, p, localMinimumList, e0, e1);
                else if (num3 < 0)
                    ;
                num1 = num3;
                p = point2D2;
                e0 = e1;
            }
            Class65.Class75 e1_1 = class75;
            int num4 = num2;
            if (num4 == num1)
            {
                if (num4 > 0)
                    e0.Successor = e1_1;
                else
                    e1_1.Successor = e0;
            }
            else if (num4 > 0 && num1 < 0)
                Class65.smethod_2(type, p, localMinimumList, e0, e1_1);
            else if (num4 < 0)
                ;
        }

        private static void smethod_2(
          byte type,
          Point2D p,
          List<Class65.Class66> localMinimumList,
          Class65.Class75 e0,
          Class65.Class75 e1)
        {
            Class65.Class66 class66 = new Class65.Class66(type) { Y = p.Y };
            localMinimumList.Add(class66);
            class66.Edge1 = e0;
            class66.Edge2 = e1;
            e1.XBottom = p.X;
        }

        internal class Class66 : IComparable<Class65.Class66>
        {
            private double double_0;
            private byte byte_0;
            private Class65.Class75 class75_0;
            private Class65.Class75 class75_1;
            private Class65.Class66 class66_0;

            public Class66(byte type)
            {
                this.byte_0 = type;
            }

            public double Y
            {
                get
                {
                    return this.double_0;
                }
                set
                {
                    this.double_0 = value;
                }
            }

            public byte Type
            {
                get
                {
                    return this.byte_0;
                }
                set
                {
                    this.byte_0 = value;
                }
            }

            public Class65.Class75 Edge1
            {
                get
                {
                    return this.class75_0;
                }
                set
                {
                    this.class75_0 = value;
                }
            }

            public Class65.Class75 Edge2
            {
                get
                {
                    return this.class75_1;
                }
                set
                {
                    this.class75_1 = value;
                }
            }

            public Class65.Class66 Next
            {
                get
                {
                    return this.class66_0;
                }
                set
                {
                    this.class66_0 = value;
                }
            }

            public int CompareTo(Class65.Class66 other)
            {
                return MathUtil.Compare(this.double_0, other.double_0);
            }

            public override string ToString()
            {
                return string.Format("type = {0}, y = {1}, next y = {2}, left = {3}, right = {4}", (object)this.byte_0, (object)this.double_0, this.class66_0 == null ? (object)"null" : (object)this.class66_0.double_0.ToString(), (object)this.class75_0, (object)this.class75_1);
            }
        }

        internal class Class25 : RedBlackTree<Class65.Class67>
        {
            private int int_1 = 1;

            public void Add(Class65.Class66 localMinimum)
            {
                this.Add((Class65.Class67)new Class65.Class68(this, localMinimum));
            }

            public Class65.Class67 method_4()
            {
                if (this.Count == 0)
                    return (Class65.Class67)null;
                RedBlackTree<Class65.Class67>.Node leftMost = this.Root.GetLeftMost();
                this.Remove(leftMost);
                return leftMost.Value;
            }

            public int method_5()
            {
                return this.int_1++;
            }
        }

        internal abstract class Class67 : IComparable<Class65.Class67>
        {
            private double double_0;
            private int int_0;

            protected Class67(Class65.Class25 eventQueue, double y)
            {
                this.double_0 = y;
                this.int_0 = eventQueue.method_5();
            }

            public double Y
            {
                get
                {
                    return this.double_0;
                }
                set
                {
                    this.double_0 = value;
                }
            }

            public int CompareTo(Class65.Class67 other)
            {
                if (this.double_0 < other.double_0)
                    return -1;
                if (this.double_0 > other.double_0)
                    return 1;
                return MathUtil.Compare(this.int_0, other.int_0);
            }

            public virtual void vmethod_0(Class65.Class25 eventQueue, Class65.Class70 scanBeam)
            {
            }

            public override string ToString()
            {
                return string.Format("y {0}", (object)this.double_0);
            }
        }

        internal class Class68 : Class65.Class67
        {
            private Class65.Class66 class66_0;

            public Class68(Class65.Class25 eventQueue, Class65.Class66 localMinimum)
              : base(eventQueue, localMinimum.Y)
            {
                this.class66_0 = localMinimum;
            }

            public Class65.Class66 LocalMinimum
            {
                get
                {
                    return this.class66_0;
                }
                set
                {
                    this.class66_0 = value;
                }
            }

            public override void vmethod_0(Class65.Class25 eventQueue, Class65.Class70 scanBeam)
            {
                scanBeam.method_8(this.class66_0);
                for (Class65.Class66 class66 = this.class66_0; class66.Next != null; class66 = class66.Next)
                {
                    if (class66.Y == class66.Next.Y)
                    {
                        scanBeam.method_8(class66.Next);
                    }
                    else
                    {
                        scanBeam.EventQueue.Add(class66.Next);
                        break;
                    }
                }
                bool flag1 = false;
                bool flag2 = false;
                Class65.Class73 outputPolygonRef = (Class65.Class73)null;
                for (int index = 0; index < scanBeam.ActiveEdges.Count; ++index)
                {
                    Class65.Class78 activeEdge = scanBeam.ActiveEdges[index];
                    if (activeEdge.Type == (byte)1)
                    {
                        this.method_0(activeEdge, flag1, flag2, ref outputPolygonRef);
                        if (!activeEdge.Edge.IsHorizontal)
                            flag1 = !flag1;
                    }
                    else
                    {
                        this.method_0(activeEdge, flag2, flag1, ref outputPolygonRef);
                        if (!activeEdge.Edge.IsHorizontal)
                            flag2 = !flag2;
                    }
                }
            }

            private void method_0(
              Class65.Class78 e,
              bool oddEqualTypeEdgeCount,
              bool oddUnequalTypeEdgeCount,
              ref Class65.Class73 outputPolygonRef)
            {
                if (e.Side == (byte)0)
                {
                    e.Side = oddEqualTypeEdgeCount ? (byte)2 : (byte)1;
                    if (!oddUnequalTypeEdgeCount)
                        return;
                    double xbottom = e.Edge.XBottom;
                    if (outputPolygonRef == null)
                    {
                        outputPolygonRef = new Class65.Class73()
                        {
                            class72_0 = new Class65.Class72()
                        };
                        outputPolygonRef.class72_0.AddFirst(new Point2D(xbottom, this.class66_0.Y));
                        e.ResultPolygonRef = outputPolygonRef;
                    }
                    else
                    {
                        if (xbottom != outputPolygonRef.class72_0.First.Value.X)
                            outputPolygonRef.class72_0.AddLast(new Point2D(xbottom, this.class66_0.Y));
                        e.ResultPolygonRef = outputPolygonRef;
                        outputPolygonRef = (Class65.Class73)null;
                    }
                }
                else
                {
                    if (!oddUnequalTypeEdgeCount || e.ResultPolygon != null)
                        return;
                    double bottomIntersection = e.XScanbeamBottomIntersection;
                    if (outputPolygonRef == null)
                    {
                        outputPolygonRef = new Class65.Class73()
                        {
                            class72_0 = new Class65.Class72()
                        };
                        outputPolygonRef.class72_0.AddFirst(new Point2D(bottomIntersection, this.class66_0.Y));
                        e.ResultPolygonRef = outputPolygonRef;
                    }
                    else
                    {
                        Point2D point2D = new Point2D(bottomIntersection, this.class66_0.Y);
                        if (point2D != outputPolygonRef.class72_0.Last.Value)
                            outputPolygonRef.class72_0.AddLast(point2D);
                        e.ResultPolygonRef = outputPolygonRef;
                        outputPolygonRef = (Class65.Class73)null;
                    }
                }
            }
        }

        internal class Class69 : Class65.Class67
        {
            private Class65.Class78 class78_0;

            public Class69(Class65.Class25 eventQueue, Class65.Class78 edge)
              : base(eventQueue, edge.Edge.YTop)
            {
                this.class78_0 = edge;
            }

            public Class65.Class78 Edge
            {
                get
                {
                    return this.class78_0;
                }
                set
                {
                    this.class78_0 = value;
                }
            }

            public override void vmethod_0(Class65.Class25 eventQueue, Class65.Class70 scanBeam)
            {
                scanBeam.method_9(this);
            }
        }

        internal class Class70
        {
            private Class65.Class25 class25_0 = new Class65.Class25();
            private List<Class65.Class78> list_0 = new List<Class65.Class78>();
            private Class65.Class70.Class71 class71_0 = new Class65.Class70.Class71();
            private List<Class65.Class78> list_1 = new List<Class65.Class78>();
            private List<Class65.Class79> list_2 = new List<Class65.Class79>();
            private List<Class65.Class72> list_3 = new List<Class65.Class72>();
            private double double_0;
            private double double_1;

            public Class65.Class25 EventQueue
            {
                get
                {
                    return this.class25_0;
                }
                set
                {
                    this.class25_0 = value;
                }
            }

            public double YBottom
            {
                get
                {
                    return this.double_0;
                }
                set
                {
                    this.double_0 = value;
                }
            }

            public double YTop
            {
                get
                {
                    return this.double_1;
                }
                set
                {
                    this.double_1 = value;
                }
            }

            public List<Class65.Class78> ActiveEdges
            {
                get
                {
                    return this.list_0;
                }
            }

            public List<Class65.Class72> ResultPolygons
            {
                get
                {
                    return this.list_3;
                }
            }

            public void method_0()
            {
                Class65.Class67 class67_1;
                for (Class65.Class67 class67_2 = this.class25_0.method_4(); class67_2 != null; class67_2 = class67_1)
                {
                    this.double_0 = class67_2.Y;
                    class67_2.vmethod_0(this.class25_0, this);
                    for (class67_1 = this.class25_0.method_4(); class67_1 != null && (this.double_1 = class67_1.Y) == this.double_0; class67_1 = this.class25_0.method_4())
                        class67_1.vmethod_0(this.class25_0, this);
                    this.method_1();
                    this.method_7();
                }
            }

            private void method_1()
            {
                if (this.list_0.Count == 0)
                    return;
                this.method_2();
                this.method_6();
            }

            private void method_2()
            {
                this.list_1.Clear();
                this.list_2.Clear();
                Class65.Class78 class78 = this.list_0[0];
                class78.method_7(this.double_1);
                this.list_1.Add(class78);
                for (int index1 = 1; index1 < this.list_0.Count; ++index1)
                {
                    Class65.Class78 edge0 = this.list_0[index1];
                    edge0.method_7(this.double_1);
                    bool flag = false;
                    for (int index2 = this.list_1.Count - 1; index2 >= 0; --index2)
                    {
                        Class65.Class78 edge1 = this.list_1[index2];
                        if (edge0.XScanbeamTopIntersection < edge1.XScanbeamTopIntersection)
                        {
                            Segment2D a = edge0.Edge.method_1();
                            Segment2D b = edge1.Edge.method_1();
                            double[] pArray;
                            double[] qArray;
                            if (Segment2D.GetIntersectionParameters(a, b, out pArray, out qArray) && pArray.Length == 1)
                            {
                                Point2D position = a.Start + pArray[0] * a.GetDelta();
                                this.list_2.Add(new Class65.Class79(edge0, edge1, position));
                            }
                        }
                        else
                        {
                            this.list_1.Insert(index2 + 1, edge0);
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                        this.list_1.Insert(0, edge0);
                }
                this.list_2.Sort();
                this.method_3();
            }

            private void method_3()
            {
                List<Class65.Class78> list0 = this.list_0;
                this.list_0 = this.list_1;
                this.list_1 = list0;
            }

            private bool method_4()
            {
                bool flag1 = false;
                this.list_1.Clear();
                Class65.Class78 class78_1 = this.list_0[0];
                class78_1.method_8(this.double_1);
                class78_1.IntersectsWithHorizontalEdge = false;
                this.list_1.Add(class78_1);
                for (int index1 = 1; index1 < this.list_0.Count; ++index1)
                {
                    Class65.Class78 class78_2 = this.list_0[index1];
                    class78_2.method_8(this.double_1);
                    class78_2.IntersectsWithHorizontalEdge = false;
                    bool flag2 = false;
                    for (int index2 = this.list_1.Count - 1; index2 >= 0; --index2)
                    {
                        Class65.Class78 class78_3 = this.list_1[index2];
                        if (class78_2.XScanbeamTopIntersection2 < class78_3.XScanbeamTopIntersection2)
                        {
                            class78_2.IntersectsWithHorizontalEdge = true;
                            class78_3.IntersectsWithHorizontalEdge = true;
                            flag1 = true;
                        }
                        else
                        {
                            this.list_1.Insert(index2 + 1, class78_2);
                            flag2 = true;
                            if ((class78_2.XScanbeamTopIntersection != class78_2.XScanbeamTopIntersection2 || class78_3.XScanbeamTopIntersection != class78_3.XScanbeamTopIntersection2) && class78_2.XScanbeamTopIntersection2 == class78_3.XScanbeamTopIntersection2)
                            {
                                class78_2.IntersectsWithHorizontalEdge = true;
                                class78_3.IntersectsWithHorizontalEdge = true;
                                for (int index3 = index2 - 1; index3 >= 0; --index3)
                                {
                                    Class65.Class78 class78_4 = this.list_1[index3];
                                    if (class78_2.XScanbeamTopIntersection2 == class78_4.XScanbeamTopIntersection2)
                                        class78_4.IntersectsWithHorizontalEdge = true;
                                    else
                                        break;
                                }
                                break;
                            }
                            break;
                        }
                    }
                    if (!flag2)
                        this.list_1.Insert(0, class78_2);
                }
                return flag1;
            }

            private void method_5()
            {
                if (this.list_0.Count == 0)
                    return;
                this.list_1.Clear();
                this.list_1.Add(this.list_0[0]);
                for (int index1 = 1; index1 < this.list_0.Count; ++index1)
                {
                    Class65.Class78 class78_1 = this.list_0[index1];
                    bool flag = false;
                    for (int index2 = this.list_1.Count - 1; index2 >= 0; --index2)
                    {
                        Class65.Class78 class78_2 = this.list_1[index2];
                        if (class78_1.XScanbeamBottomIntersection >= class78_2.XScanbeamBottomIntersection)
                        {
                            this.list_1.Insert(index2 + 1, class78_1);
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                        this.list_1.Insert(0, class78_1);
                }
                this.method_3();
            }

            private void method_6()
            {
                if (this.list_2.Count == 0)
                    return;
                foreach (Class65.Class79 class79 in this.list_2)
                {
                    switch (class79.method_0())
                    {
                        case Class65.Enum2.const_1:
                            class79.Edge0.method_1(class79.Position);
                            break;
                        case Class65.Enum2.const_2:
                            class79.Edge1.method_3(class79.Position);
                            break;
                        case Class65.Enum2.const_3:
                            if (class79.Edge1.ResultPolygon != null)
                            {
                                class79.Edge1.method_1(class79.Position);
                                class79.Edge0.method_3(class79.Position);
                            }
                            class79.Edge0.method_5(class79.Edge1);
                            break;
                        case Class65.Enum2.const_4:
                            this.method_13(class79.Edge1, class79.Edge0, class79.Position);
                            break;
                        case Class65.Enum2.const_5:
                            this.method_10(class79.Edge1, class79.Edge0, class79.Position);
                            break;
                    }
                    Class65.Class73 resultPolygonRef = class79.Edge0.ResultPolygonRef;
                    class79.Edge0.ResultPolygonRef = class79.Edge1.ResultPolygonRef;
                    class79.Edge1.ResultPolygonRef = resultPolygonRef;
                }
            }

            private void method_7()
            {
                if (this.list_0.Count == 0)
                    return;
                bool flag = this.method_4();
                for (int index1 = 0; index1 < this.list_0.Count; ++index1)
                {
                    Class65.Class78 class78_1 = this.list_0[index1];
                    if (class78_1.Edge.YTop == this.double_1)
                    {
                        if (class78_1.Successor == null)
                        {
                            int index2 = index1;
                            int index3 = index1 + 1;
                            if (class78_1.ResultPolygon != null && index3 < this.list_0.Count)
                            {
                                Class65.Class78 nextEdge = this.list_0[index3];
                                this.method_14(class78_1, nextEdge, class78_1.Edge.Top, new Point2D(nextEdge.XScanbeamTopIntersection, this.double_1));
                                if (nextEdge.Edge.YTop == this.double_1)
                                {
                                    this.list_0.RemoveAt(index3);
                                    nextEdge.Edge = (Class65.Class75)null;
                                }
                                else
                                    ++index1;
                            }
                            this.list_0.RemoveAt(index2);
                            class78_1.Edge = (Class65.Class75)null;
                            --index1;
                        }
                        else if (class78_1.Side == (byte)1)
                        {
                            if (class78_1.ResultPolygon != null)
                            {
                                class78_1.method_0(class78_1.Edge.Top);
                                if (class78_1.Edge.XTop != class78_1.Successor.XBottom)
                                    class78_1.method_0(class78_1.Successor.Bottom);
                            }
                            class78_1.Edge = class78_1.Successor;
                            class78_1.XScanbeamBottomIntersection = class78_1.Edge.XBottom;
                        }
                        else if (class78_1.Side == (byte)2)
                        {
                            if (class78_1.ResultPolygon != null)
                            {
                                class78_1.method_2(class78_1.Edge.Top);
                                if (class78_1.Edge.XTop != class78_1.Successor.XBottom)
                                    class78_1.method_2(class78_1.Successor.Bottom);
                            }
                            class78_1.Edge = class78_1.Successor;
                            class78_1.XScanbeamBottomIntersection = class78_1.Edge.XBottom;
                        }
                    }
                    else if (class78_1.IntersectsWithHorizontalEdge)
                    {
                        int index2 = index1 + 1;
                        if (index2 < this.list_0.Count)
                        {
                            Class65.Class78 class78_2 = this.list_0[index2];
                            if (class78_1.ResultPolygon == null)
                            {
                                this.method_11(class78_1, class78_2, class78_1.Edge.Bottom, class78_2.Edge.Bottom);
                                ++index1;
                            }
                            else
                            {
                                this.method_14(class78_1, class78_2, new Point2D(class78_1.XScanbeamTopIntersection, this.double_1), new Point2D(class78_2.XScanbeamTopIntersection, this.double_1));
                                if (class78_2.Edge.YTop == this.double_1)
                                {
                                    this.list_0.RemoveAt(index2);
                                    class78_2.Edge = (Class65.Class75)null;
                                }
                                else
                                    ++index1;
                            }
                        }
                    }
                    else
                        class78_1.XScanbeamBottomIntersection = class78_1.XScanbeamTopIntersection;
                }
                if (!flag)
                    return;
                this.method_5();
            }

            public void method_8(Class65.Class66 localMinimum)
            {
                Class65.Class78 edge1 = new Class65.Class78(localMinimum.Type) { Edge = localMinimum.Edge1 };
                edge1.method_6(this.double_0);
                int index1 = this.list_0.BinarySearch(edge1, (IComparer<Class65.Class78>)this.class71_0);
                if (index1 < 0)
                    index1 = ~index1;
                this.list_0.Insert(index1, edge1);
                Class65.Class75 class75 = localMinimum.Edge2;
                while (class75.IsHorizontal)
                    class75 = class75.Successor;
                Class65.Class78 edge2 = (Class65.Class78)null;
                if (class75 != null)
                {
                    edge2 = new Class65.Class78(localMinimum.Type)
                    {
                        Edge = class75
                    };
                    edge2.method_6(this.double_0);
                    int index2 = this.list_0.BinarySearch(edge2, (IComparer<Class65.Class78>)this.class71_0);
                    if (index2 < 0)
                        index2 = ~index2;
                    this.list_0.Insert(index2, edge2);
                }
                this.class25_0.Add((Class65.Class67)new Class65.Class69(this.class25_0, edge1));
                if (edge2 == null)
                    return;
                this.class25_0.Add((Class65.Class67)new Class65.Class69(this.class25_0, edge2));
            }

            public void method_9(Class65.Class69 successorEvent)
            {
                Class65.Class75 edge = successorEvent.Edge.Edge;
                if (edge == null)
                    return;
                successorEvent.Y = edge.YTop;
                this.class25_0.Add((Class65.Class67)successorEvent);
            }

            public Class65.Class72 method_10(
              Class65.Class78 left,
              Class65.Class78 right,
              Point2D p)
            {
                Class65.Class72 class72 = new Class65.Class72();
                Class65.Class73 class73 = new Class65.Class73() { class72_0 = class72 };
                class72.AddLast(p);
                left.ResultPolygonRef = class73;
                right.ResultPolygonRef = class73;
                return class72;
            }

            public Class65.Class72 method_11(
              Class65.Class78 left,
              Class65.Class78 right,
              Point2D pLeft,
              Point2D pRight)
            {
                Class65.Class72 class72 = new Class65.Class72();
                Class65.Class73 class73 = new Class65.Class73() { class72_0 = class72 };
                class72.AddLast(pLeft);
                if (pLeft.X != pRight.X)
                    class72.AddLast(pRight);
                left.ResultPolygonRef = class73;
                right.ResultPolygonRef = class73;
                return class72;
            }

            public void method_12(Class65.Class78 edge1, Class65.Class78 edge2)
            {
                Class65.Class72 resultPolygon = edge1.ResultPolygon;
                for (LinkedListNode<Point2D> linkedListNode = edge2.ResultPolygon.Last; linkedListNode != null; linkedListNode = linkedListNode.Previous)
                    resultPolygon.AddFirst(linkedListNode.Value);
                edge2.ResultPolygon = resultPolygon;
            }

            private static void smethod_0(Class65.Class72 p, Point2D startPoint, Point2D endPoint)
            {
                if (p.Last.Value == endPoint && p.Last.Previous != null && p.Last.Previous.Value == startPoint)
                    p.RemoveLast();
                else
                    p.RemoveFirst();
            }

            public void method_13(Class65.Class78 edge, Class65.Class78 nextEdge, Point2D p)
            {
                edge.method_0(p);
                this.method_15(edge, nextEdge);
            }

            public void method_14(
              Class65.Class78 edge,
              Class65.Class78 nextEdge,
              Point2D left,
              Point2D right)
            {
                edge.method_0(left);
                if (right.X != left.X)
                    nextEdge.method_2(right);
                this.method_15(edge, nextEdge);
            }

            private void method_15(Class65.Class78 edge, Class65.Class78 nextEdge)
            {
                if (edge.ResultPolygon != null && nextEdge.ResultPolygon != null)
                {
                    if (edge.ResultPolygon != nextEdge.ResultPolygon)
                        this.method_12(edge, nextEdge);
                    else
                        this.list_3.Add(edge.ResultPolygon);
                }
                edge.ResultPolygonRef = new Class65.Class73();
                nextEdge.ResultPolygonRef = new Class65.Class73();
            }

            internal class Class71 : IComparer<Class65.Class78>
            {
                public int Compare(Class65.Class78 a, Class65.Class78 b)
                {
                    double bottomIntersection1 = a.XScanbeamBottomIntersection;
                    double bottomIntersection2 = b.XScanbeamBottomIntersection;
                    if (bottomIntersection1 < bottomIntersection2)
                        return -1;
                    if (bottomIntersection1 > bottomIntersection2)
                        return 1;
                    return Vector2D.CompareAngles(b.Edge.SlopeVector, a.Edge.SlopeVector);
                }
            }
        }

        internal class Class72 : LinkedList<Point2D>
        {
            public Polygon2D method_0()
            {
                return new Polygon2D((IEnumerable<Point2D>)this);
            }
        }

        internal class Class73
        {
            public Class65.Class72 class72_0;
        }

        internal class Class74
        {
            private Point2D point2D_0;
            private Class65.Class74 class74_0;

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

            public Class65.Class74 Next
            {
                get
                {
                    return this.class74_0;
                }
                set
                {
                    this.class74_0 = value;
                }
            }
        }

        internal abstract class Class75
        {
            protected double double_0;
            protected double double_1;
            protected Class65.Class75 class75_0;

            public static Class65.Class75 smethod_0(double x0, double y0, double x1, double y1)
            {
                if (y0 == y1)
                    return (Class65.Class75)new Class65.Class77(x0, y0, x1);
                return (Class65.Class75)new Class65.Class76(x0, y0, x1, y1);
            }

            public double XBottom
            {
                get
                {
                    return this.double_0;
                }
                set
                {
                    this.double_0 = value;
                }
            }

            public double XTop
            {
                get
                {
                    return this.double_1;
                }
                set
                {
                    this.double_1 = value;
                }
            }

            public abstract double YTop { get; }

            public abstract double YBottom { get; }

            public abstract bool IsHorizontal { get; }

            public abstract Point2D Bottom { get; }

            public abstract Point2D Top { get; }

            public abstract Vector2D SlopeVector { get; }

            public Class65.Class75 Successor
            {
                get
                {
                    return this.class75_0;
                }
                set
                {
                    this.class75_0 = value;
                }
            }

            public Class65.Class75 method_0()
            {
                return Class65.Class75.smethod_1(this);
            }

            public static Class65.Class75 smethod_1(Class65.Class75 e)
            {
                while (e != null && e.Successor != null)
                    e = e.Successor;
                return e;
            }

            public abstract double vmethod_0(double y);

            public Segment2D method_1()
            {
                return new Segment2D(this.Bottom, this.Top);
            }
        }

        internal class Class76 : Class65.Class75
        {
            private double double_2;
            protected double double_3;
            protected double double_4;

            public Class76(double x0, double y0, double x1, double y1)
            {
                if (y0 <= y1)
                {
                    this.double_0 = x0;
                    this.double_3 = y0;
                    this.double_1 = x1;
                    this.double_4 = y1;
                }
                else
                {
                    this.double_0 = x1;
                    this.double_3 = y1;
                    this.double_1 = x0;
                    this.double_4 = y0;
                }
                this.double_2 = (x1 - x0) / (y1 - y0);
            }

            public override double vmethod_0(double y)
            {
                return this.double_0 + (y - this.double_3) * this.double_2;
            }

            public override Point2D Bottom
            {
                get
                {
                    return new Point2D(this.double_0, this.double_3);
                }
            }

            public override Point2D Top
            {
                get
                {
                    return new Point2D(this.double_1, this.double_4);
                }
            }

            public override double YTop
            {
                get
                {
                    return this.double_4;
                }
            }

            public override double YBottom
            {
                get
                {
                    return this.double_3;
                }
            }

            public override bool IsHorizontal
            {
                get
                {
                    return false;
                }
            }

            public override Vector2D SlopeVector
            {
                get
                {
                    return new Vector2D(this.double_2, 1.0);
                }
            }

            public override string ToString()
            {
                return string.Format("xBottom = {0}, yTop = {1}, dx (slope) = {2}", (object)this.double_0, (object)this.double_4, (object)this.double_2);
            }
        }

        internal class Class77 : Class65.Class75
        {
            private double double_2;
            private double double_3;

            public Class77(double x0, double y0, double x1)
            {
                this.double_0 = x0;
                this.double_1 = x1;
                this.double_3 = y0;
                this.double_2 = x1 - x0;
            }

            public override double vmethod_0(double y)
            {
                return this.double_0;
            }

            public override Point2D Bottom
            {
                get
                {
                    return new Point2D(this.double_0, this.double_3);
                }
            }

            public override Point2D Top
            {
                get
                {
                    return new Point2D(this.double_1, this.double_3);
                }
            }

            public override double YTop
            {
                get
                {
                    return this.double_3;
                }
            }

            public override double YBottom
            {
                get
                {
                    return this.double_3;
                }
            }

            public override bool IsHorizontal
            {
                get
                {
                    return true;
                }
            }

            public override Vector2D SlopeVector
            {
                get
                {
                    return new Vector2D(this.double_2, 0.0);
                }
            }

            internal void method_2(Class65.Class77 e)
            {
                this.double_2 += e.double_2;
                if (this.double_2 > 0.0)
                {
                    this.double_0 = System.Math.Min(this.double_0, e.double_0);
                    this.double_1 = System.Math.Max(this.double_1, e.double_1);
                }
                else
                {
                    this.double_0 = System.Math.Max(this.double_0, e.double_0);
                    this.double_1 = System.Math.Min(this.double_1, e.double_1);
                }
            }

            internal void method_3()
            {
                this.double_0 += this.double_2;
                this.double_1 -= this.double_2;
                this.double_2 = -this.double_2;
            }

            public override string ToString()
            {
                return string.Format("xBottom = {0}, yTop = {1}, dx = {2}", (object)this.double_0, (object)this.double_3, (object)this.double_2);
            }
        }

        internal class Class78
        {
            private Class65.Class73 class73_0 = new Class65.Class73();
            private Class65.Class75 class75_0;
            protected byte byte_0;
            protected byte byte_1;
            private double double_0;
            private double double_1;
            private double double_2;
            private double double_3;
            private Class65.Class78 class78_0;
            private Class65.Class78 class78_1;
            private bool bool_0;
            private Class65.Class75 class75_1;

            public Class78(byte type)
            {
                this.byte_0 = type;
            }

            public Class65.Class75 Edge
            {
                get
                {
                    return this.class75_0;
                }
                set
                {
                    this.class75_0 = value;
                    if (this.class75_0 == null)
                    {
                        this.class75_1 = (Class65.Class75)null;
                        this.double_3 = double.NaN;
                    }
                    else
                    {
                        this.double_3 = this.class75_0.XTop;
                        for (this.class75_1 = this.class75_0.Successor; this.class75_1 != null && this.class75_1.IsHorizontal; this.class75_1 = this.class75_1.Successor)
                            this.double_3 = this.class75_1.XTop;
                    }
                }
            }

            public byte Type
            {
                get
                {
                    return this.byte_0;
                }
                set
                {
                    this.byte_0 = value;
                }
            }

            public byte Side
            {
                get
                {
                    return this.byte_1;
                }
                set
                {
                    this.byte_1 = value;
                }
            }

            public double XScanbeamBottomIntersection
            {
                get
                {
                    return this.double_0;
                }
                set
                {
                    this.double_0 = value;
                }
            }

            public double XScanbeamTopIntersection
            {
                get
                {
                    return this.double_1;
                }
                set
                {
                    this.double_1 = value;
                }
            }

            public double XScanbeamTopIntersection2
            {
                get
                {
                    return this.double_2;
                }
            }

            public Class65.Class78 Previous
            {
                get
                {
                    return this.class78_0;
                }
                set
                {
                    this.class78_0 = value;
                }
            }

            public Class65.Class78 Next
            {
                get
                {
                    return this.class78_1;
                }
                set
                {
                    this.class78_1 = value;
                }
            }

            public bool IntersectsWithHorizontalEdge
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

            public Class65.Class75 Successor
            {
                get
                {
                    return this.class75_1;
                }
            }

            public Class65.Class72 ResultPolygon
            {
                get
                {
                    return this.class73_0.class72_0;
                }
                set
                {
                    this.class73_0.class72_0 = value;
                }
            }

            public Class65.Class73 ResultPolygonRef
            {
                get
                {
                    return this.class73_0;
                }
                set
                {
                    this.class73_0 = value;
                }
            }

            public void method_0(Point2D p)
            {
                this.ResultPolygon.AddFirst(p);
            }

            public void method_1(Point2D p)
            {
                if (this.ResultPolygon.Count != 0 && !(this.ResultPolygon.First.Value != p))
                    return;
                this.ResultPolygon.AddFirst(p);
            }

            public void method_2(Point2D p)
            {
                this.ResultPolygon.AddLast(p);
            }

            public void method_3(Point2D p)
            {
                if (this.ResultPolygon.Count != 0 && !(this.ResultPolygon.Last.Value != p))
                    return;
                this.ResultPolygon.AddLast(p);
            }

            public void method_4(Point2D p)
            {
                if (this.byte_1 == (byte)1)
                    this.method_0(p);
                else
                    this.method_2(p);
            }

            public void method_5(Class65.Class78 edge)
            {
                byte byte1 = edge.byte_1;
                edge.byte_1 = this.byte_1;
                this.byte_1 = byte1;
            }

            public void method_6(double y)
            {
                this.double_0 = this.class75_0.vmethod_0(y);
            }

            public void method_7(double y)
            {
                this.double_1 = this.class75_0.vmethod_0(y);
            }

            public void method_8(double yTop)
            {
                this.double_2 = this.class75_0.YTop == yTop ? this.double_3 : this.double_1;
            }

            public override string ToString()
            {
                return string.Format("xBottomIntersect {0} xTopIntersect {1} side {2} edge {3}", (object)this.double_0, (object)this.double_1, (object)this.byte_1, (object)this.class75_0);
            }
        }

        internal class Class79 : IComparable<Class65.Class79>
        {
            private Point2D point2D_0;
            private Class65.Class78 class78_0;
            private Class65.Class78 class78_1;

            public Class79(Class65.Class78 edge0, Class65.Class78 edge1, Point2D position)
            {
                this.class78_0 = edge0;
                this.class78_1 = edge1;
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

            public Class65.Class78 Edge0
            {
                get
                {
                    return this.class78_0;
                }
                set
                {
                    this.class78_0 = value;
                }
            }

            public Class65.Class78 Edge1
            {
                get
                {
                    return this.class78_1;
                }
                set
                {
                    this.class78_1 = value;
                }
            }

            public Class65.Enum2 method_0()
            {
                Class65.Enum2 enum2;
                if ((int)this.class78_0.Type == (int)this.class78_1.Type)
                {
                    if ((int)this.class78_0.Side == (int)this.class78_1.Side)
                        throw new Exception("Invalid intersection.");
                    enum2 = Class65.Enum2.const_3;
                }
                else
                    enum2 = (int)this.class78_0.Side != (int)this.class78_1.Side ? (this.class78_1.Side != (byte)1 ? Class65.Enum2.const_5 : Class65.Enum2.const_4) : (this.class78_1.Side != (byte)1 ? Class65.Enum2.const_2 : Class65.Enum2.const_1);
                return enum2;
            }

            public int CompareTo(Class65.Class79 other)
            {
                if (this.point2D_0.Y < other.point2D_0.Y)
                    return -1;
                if (this.point2D_0.Y > other.point2D_0.Y)
                    return 1;
                if (this.point2D_0.X < other.point2D_0.X)
                    return -1;
                return this.point2D_0.X > other.point2D_0.X ? 1 : 0;
            }

            public override string ToString()
            {
                return string.Format("pos: {0} edge0: {1}, edge1: {2}", (object)this.point2D_0, (object)this.class78_0, (object)this.class78_1);
            }
        }

        public enum Enum1
        {
            const_0,
            const_1,
        }

        public enum Enum2
        {
            const_0,
            const_1,
            const_2,
            const_3,
            const_4,
            const_5,
        }
    }
}
