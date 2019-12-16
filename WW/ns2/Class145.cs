using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using WW.Collections.Generic;
using WW.Math;
using WW.Math.Geometry;

namespace ns2
{
    internal class Class145
    {
        private static Polygon2D[] polygon2D_0;

        static Class145()
        {
            Class145.polygon2D_0 = new Polygon2D[0];
        }

        public Class145()
        {
        }

        public static IList<Polygon2D> smethod_0(IList<Polygon2D> clip, IList<Polygon2D> subject, Class145.Enum7 fillMode)
        {
            List<Class145.Class148.Class149> class149s = new List<Class145.Class148.Class149>();
            foreach (Polygon2D polygon2D in clip)
            {
                Class145.smethod_1(polygon2D, 1, class149s);
            }
            foreach (Polygon2D polygon2D1 in subject)
            {
                Class145.smethod_1(polygon2D1, 2, class149s);
            }
            class149s.Sort(Class145.Class148.Class154.class154_0);
            Class145.Class148.Class149 class149 = null;
            if (class149s.Count > 1)
            {
                Class145.Class148.Class149 item = class149s[class149s.Count - 1];
                for (int i = class149s.Count - 2; i >= 0; i--)
                {
                    Class145.Class148.Class149 item1 = class149s[i];
                    item1.class149_0 = item;
                    item = item1;
                }
                class149 = item;
            }
            Class145.Class146 class146 = new Class145.Class146();
            if (class149 != null)
            {
                class146.class33_0.Add(class149);
            }
            class146.method_0();
            if (class146.list_0.Count == 0)
            {
                return Class145.polygon2D_0;
            }
            List<Polygon2D> polygon2Ds = new List<Polygon2D>(class146.list_0.Count);
            foreach (Class145.Class158 list0 in class146.list_0)
            {
                if (list0.Count <= 2)
                {
                    continue;
                }
                polygon2Ds.Add(list0.method_0());
            }
            if (polygon2Ds.Count == 0)
            {
                return Class145.polygon2D_0;
            }
            return polygon2Ds;
        }

        internal static void smethod_1(Polygon2D polygon, byte type, List<Class145.Class148.Class149> localMinimumList)
        {
            if (polygon.Count == 0)
            {
                return;
            }
            Point2D item = polygon[0];
            Point2D point2D = item;
            int num = 1;
            int num1 = 0;
            int count = polygon.Count;
            while (true)
            {
                if (num < count)
                {
                    point2D = polygon[num];
                    num1 = Math.Sign(point2D.Y - item.Y);
                    if (num1 == 0)
                    {
                        num1 = Math.Sign(point2D.X - item.X);
                    }
                    if (num1 != 0)
                    {
                        num++;
                        break;
                    }
                    else
                    {
                        num++;
                    }
                }
                else
                {
                    break;
                }
            }
            Class145.Class148 class150 = null;
            Action<Class145.Class148> class1480 = null;
            while (true)
            {
                if (num <= count)
                {
                    Point2D item1 = polygon[num % count];
                    int num2 = Math.Sign(item1.Y - point2D.Y);
                    if (num2 == 0)
                    {
                        num2 = Math.Sign(item1.X - point2D.X);
                    }
                    if (num2 != 0)
                    {
                        if (num2 == num1)
                        {
                            if (num2 <= 0)
                            {
                                Class145.Class148 class148 = new Class145.Class148.Class150(point2D);
                                class1480 = (Class145.Class148 prev) => class148.class148_0 = prev;
                                class150 = class148;
                            }
                            else
                            {
                                Class145.Class148 class1501 = new Class145.Class148.Class150(point2D);
                                class1480 = (Class145.Class148 prev) => prev.class148_0 = class1501;
                                class150 = class1501;
                            }
                        }
                        else if (num2 <= 0 || num1 >= 0)
                        {
                            Class145.Class148.Class151 class151 = new Class145.Class148.Class151(point2D);
                            Class145.Class148.Class152 class152 = new Class145.Class148.Class152(point2D);
                            class1480 = (Class145.Class148 prev) => prev.class148_0 = class152;
                            class150 = class151;
                        }
                        else
                        {
                            Class145.Class148.Class149 class149 = new Class145.Class148.Class149(point2D);
                            class1480 = (Class145.Class148 prev) => class149.class148_1 = prev;
                            class150 = class149;
                            localMinimumList.Add(class149);
                        }
                        num1 = num2;
                        point2D = item1;
                        num++;
                        break;
                    }
                    else
                    {
                        num++;
                    }
                }
                else
                {
                    break;
                }
            }
            int num3 = count + 2;
            while (num < num3)
            {
                Point2D point2D1 = polygon[num % count];
                int num4 = Math.Sign(point2D1.Y - point2D.Y);
                if (num4 == 0)
                {
                    num4 = Math.Sign(point2D1.X - point2D.X);
                }
                if (num4 != 0)
                {
                    if (num4 == num1)
                    {
                        if (num4 <= 0)
                        {
                            class150 = new Class145.Class148.Class150(point2D)
                            {
                                class148_0 = class150
                            };
                        }
                        else
                        {
                            Class145.Class148 class1481 = new Class145.Class148.Class150(point2D);
                            class150.class148_0 = class1481;
                            class150 = class1481;
                        }
                    }
                    else if (num4 <= 0 || num1 >= 0)
                    {
                        Class145.Class148.Class151 class1511 = new Class145.Class148.Class151(point2D);
                        class150.class148_0 = new Class145.Class148.Class152(point2D);
                        class150 = class1511;
                    }
                    else
                    {
                        Class145.Class148.Class149 class1491 = new Class145.Class148.Class149(point2D)
                        {
                            class148_1 = class150
                        };
                        class150 = class1491;
                        localMinimumList.Add(class1491);
                    }
                    num1 = num4;
                    point2D = point2D1;
                }
                num++;
            }
            if (class1480 != null)
            {
                class1480(class150);
            }
        }

        internal class Class146
        {
            public readonly Class145.Class33 class33_0 = new Class145.Class33();

            public readonly Class145.Class34 class34_0 = new Class145.Class34();

            public readonly List<Class145.Class158> list_0 = new List<Class145.Class158>();

            public List<Class145.Class147> list_1 = new List<Class145.Class147>();

            public readonly List<Class145.Class147> list_2 = new List<Class145.Class147>();

            public List<Class145.Class147> list_3 = new List<Class145.Class147>();

            public double double_0;

            public double double_1;

            private Class145.Class148 class148_0;

            public int int_0 = 1;

            private Class145.Class155.Class157 class157_0 = new Class145.Class155.Class157();

            private Class145.Class155.Class156 class156_0 = new Class145.Class155.Class156();

            public Class146()
            {
            }

            public void method_0()
            {
                this.class148_0 = this.method_3();
                while (this.class148_0 != null)
                {
                    this.list_3.Clear();
                    this.double_1 = this.class148_0.point2D_0.Y;
                    Class145.Class155.Class156 class1560 = this.class156_0;
                    Class145.Class148 class1480 = this.class148_0;
                    Class145.Class146 class146 = this;
                    int int0 = class146.int_0;
                    int num = int0;
                    class146.int_0 = int0 + 1;
                    class1560.method_0(class1480, num);
                    this.class34_0.Add(this.class156_0);
                    int num1 = 0;
                    while (true)
                    {
                        if (num1 < this.list_1.Count)
                        {
                            Class145.Class147 item = this.list_1[num1];
                            if (item.point2D_1.Y > this.double_1)
                            {
                                Class145.Class155.Class157 class1570 = this.class157_0;
                                Class145.Class146 class1461 = this;
                                int int01 = class1461.int_0;
                                int num2 = int01;
                                class1461.int_0 = int01 + 1;
                                class1570.method_0(item, num1, num2);
                                this.class34_0.Add(this.class157_0);
                                break;
                            }
                            else
                            {
                                num1++;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    Class145.Class155 class155 = this.class34_0.method_4();
                    this.double_0 = class155.double_0;
                    while (true)
                    {
                        class155.vmethod_1(this);
                        class155.vmethod_0(this);
                        class155 = this.class34_0.method_4();
                        if (class155 == null)
                        {
                            break;
                        }
                        if (class155.double_0 != this.double_0)
                        {
                            this.method_1();
                            this.double_0 = class155.double_0;
                        }
                    }
                    this.method_1();
                    List<Class145.Class147> list1 = this.list_1;
                    this.list_1 = this.list_3;
                    this.list_3 = list1;
                }
            }

            private void method_1()
            {
                this.method_2();
            }

            private void method_2()
            {
                for (int i = this.list_2.Count - 1; i >= 0; i--)
                {
                    if (this.list_2[i].point2D_1.X <= this.double_0)
                    {
                        this.list_2.RemoveAt(i);
                    }
                }
            }

            public Class145.Class148 method_3()
            {
                this.class148_0 = this.class33_0.method_4();
                if (this.class148_0 != null)
                {
                    this.class148_0.vmethod_0(this.class33_0);
                }
                return this.class148_0;
            }

            internal void method_4(Class145.Class147 edge)
            {
                bool flag = false;
                int count = this.list_3.Count - 1;
                while (true)
                {
                    if (count < 0)
                    {
                        break;
                    }
                    else if (edge.double_1 >= this.list_3[count].double_1)
                    {
                        this.list_3.Insert(count + 1, edge);
                        flag = true;
                        break;
                    }
                    else
                    {
                        count--;
                    }
                }
                if (!flag)
                {
                    this.list_3.Insert(0, edge);
                }
            }
        }

        internal class Class147
        {
            public Point2D point2D_0;

            public Point2D point2D_1;

            public double double_0;

            public double double_1;

            private double double_2;

            private double double_3;

            public Class147(Point2D start, Point2D end)
            {
                this.point2D_0 = start;
                this.point2D_1 = end;
            }

            public void method_0()
            {
                this.double_2 = (this.point2D_1.X - this.point2D_0.X) / (this.point2D_1.Y - this.point2D_0.Y);
                this.double_3 = this.point2D_0.X - this.point2D_0.Y * this.double_2;
            }

            public void method_1(double y)
            {
                this.double_1 = this.double_2 * y + this.double_3;
            }

            public override string ToString()
            {
                return string.Format("{0} - {1}", this.point2D_0, this.point2D_1);
            }
        }

        internal class Class148
        {
            public Point2D point2D_0;

            public Class145.Class148 class148_0;

            public Class148()
            {
            }

            public Class148(Point2D position)
            {
                this.point2D_0 = position;
            }

            private void method_0(Class145.Class146 scanBeam, Class145.Class147 edge)
            {
                if (edge.point2D_0.Y == edge.point2D_1.Y)
                {
                    scanBeam.list_2.Add(edge);
                    return;
                }
                edge.method_0();
                edge.double_1 = edge.point2D_0.X;
                scanBeam.method_4(edge);
            }

            public override string ToString()
            {
                return string.Format("({0}): {1}", this.point2D_0, this.GetType().Name);
            }

            public virtual void vmethod_0(Class145.Class33 eventQueue)
            {
                if (this.class148_0 != null)
                {
                    this.class148_0.vmethod_1(eventQueue);
                }
            }

            public virtual void vmethod_1(Class145.Class33 eventQueue)
            {
                eventQueue.Add(this);
            }

            public virtual void vmethod_2(Class145.Class146 scanBeam)
            {
            }

            internal class Class149 : Class145.Class148
            {
                public Class145.Class148 class148_1;

                public Class145.Class148.Class149 class149_0;

                public Class149(Point2D position) : base(position)
                {
                }

                public override void vmethod_0(Class145.Class33 eventQueue)
                {
                    base.vmethod_0(eventQueue);
                    if (this.class148_1 != null)
                    {
                        this.class148_1.vmethod_1(eventQueue);
                    }
                    if (this.class149_0 != null)
                    {
                        this.class149_0.vmethod_1(eventQueue);
                    }
                }

                public override void vmethod_2(Class145.Class146 scanBeam)
                {
                    base.method_0(scanBeam, new Class145.Class147(this.point2D_0, this.class148_0.point2D_0));
                    base.method_0(scanBeam, new Class145.Class147(this.point2D_0, this.class148_1.point2D_0));
                }
            }

            internal class Class150 : Class145.Class148
            {
                public Class150(Point2D position) : base(position)
                {
                }

                public override void vmethod_2(Class145.Class146 scanBeam)
                {
                    base.method_0(scanBeam, new Class145.Class147(this.point2D_0, this.class148_0.point2D_0));
                }
            }

            internal class Class151 : Class145.Class148
            {
                public Class151(Point2D position) : base(position)
                {
                }

                public override void vmethod_0(Class145.Class33 eventQueue)
                {
                }

                public override void vmethod_2(Class145.Class146 scanBeam)
                {
                }
            }

            internal class Class152 : Class145.Class148
            {
                public Class152(Point2D position) : base(position)
                {
                }

                public override void vmethod_0(Class145.Class33 eventQueue)
                {
                }

                public override void vmethod_1(Class145.Class33 eventQueue)
                {
                }

                public override void vmethod_2(Class145.Class146 scanBeam)
                {
                }
            }

            internal class Class153 : IComparer<Class145.Class148>
            {
                public readonly static Class145.Class148.Class153 class153_0;

                static Class153()
                {
                    Class145.Class148.Class153.class153_0 = new Class145.Class148.Class153();
                }

                public Class153()
                {
                }

                public int Compare(Class145.Class148 x, Class145.Class148 y)
                {
                    return MathUtil.Compare(x.point2D_0.X, y.point2D_0.X);
                }
            }

            internal class Class154 : IComparer<Class145.Class148>
            {
                public readonly static Class145.Class148.Class154 class154_0;

                static Class154()
                {
                    Class145.Class148.Class154.class154_0 = new Class145.Class148.Class154();
                }

                public Class154()
                {
                }

                public int Compare(Class145.Class148 x, Class145.Class148 y)
                {
                    if (x.point2D_0.Y < y.point2D_0.Y)
                    {
                        return -1;
                    }
                    if (x.point2D_0.Y > y.point2D_0.Y)
                    {
                        return 1;
                    }
                    if (x.point2D_0.X < y.point2D_0.X)
                    {
                        return -1;
                    }
                    if (x.point2D_0.X > y.point2D_0.X)
                    {
                        return 1;
                    }
                    return 0;
                }
            }
        }

        internal abstract class Class155 : IComparable<Class145.Class155>
        {
            public double double_0;

            public int int_0;

            protected Class155()
            {
            }

            public int CompareTo(Class145.Class155 other)
            {
                if (this.double_0 < other.double_0)
                {
                    return -1;
                }
                if (this.double_0 > other.double_0)
                {
                    return 1;
                }
                if (this.int_0 < other.int_0)
                {
                    return -1;
                }
                if (this.int_0 > other.int_0)
                {
                    return 1;
                }
                return 0;
            }

            public abstract void vmethod_0(Class145.Class146 scanBeam);

            public abstract void vmethod_1(Class145.Class146 scanBeam);

            internal class Class156 : Class145.Class155
            {
                public Class145.Class148 class148_0;

                public Class156()
                {
                }

                public void method_0(Class145.Class148 v, int id)
                {
                    this.class148_0 = v;
                    this.double_0 = v.point2D_0.X;
                    this.int_0 = id;
                }

                public override string ToString()
                {
                    if (this.class148_0 == null)
                    {
                        return "null";
                    }
                    return this.class148_0.ToString();
                }

                public override void vmethod_0(Class145.Class146 scanBeam)
                {
                    this.class148_0 = scanBeam.method_3();
                    if (this.class148_0 != null && this.class148_0.point2D_0.Y == scanBeam.double_1)
                    {
                        this.double_0 = this.class148_0.point2D_0.X;
                        Class145.Class146 class146 = scanBeam;
                        int int0 = class146.int_0;
                        int num = int0;
                        class146.int_0 = int0 + 1;
                        this.int_0 = num;
                        scanBeam.class34_0.Add(this);
                    }
                }

                public override void vmethod_1(Class145.Class146 scanBeam)
                {
                    this.class148_0.vmethod_2(scanBeam);
                }
            }

            internal class Class157 : Class145.Class155
            {
                public Class145.Class147 class147_0;

                public int int_1;

                public Class157()
                {
                }

                public void method_0(Class145.Class147 edge, int i, int id)
                {
                    this.class147_0 = edge;
                    this.double_0 = edge.double_1;
                    this.int_1 = i;
                    this.int_0 = id;
                }

                public override string ToString()
                {
                    if (this.class147_0 == null)
                    {
                        return "null";
                    }
                    return this.class147_0.ToString();
                }

                public override void vmethod_0(Class145.Class146 scanBeam)
                {
                    this.int_1++;
                    while (this.int_1 < scanBeam.list_1.Count)
                    {
                        this.class147_0 = scanBeam.list_1[this.int_1];
                        if (this.class147_0.point2D_1.Y > scanBeam.double_1)
                        {
                            this.double_0 = this.class147_0.double_1;
                            Class145.Class146 class146 = scanBeam;
                            int int0 = class146.int_0;
                            int num = int0;
                            class146.int_0 = int0 + 1;
                            this.int_0 = num;
                            scanBeam.class34_0.Add(this);
                            return;
                        }
                        this.int_1++;
                    }
                }

                public override void vmethod_1(Class145.Class146 scanBeam)
                {
                    this.class147_0.method_1(scanBeam.double_1);
                    scanBeam.method_4(this.class147_0);
                }
            }
        }

        internal class Class158 : LinkedList<Point2D>
        {
            public Class158()
            {
            }

            public Polygon2D method_0()
            {
                return new Polygon2D(this);
            }
        }

        internal class Class32<T> : RedBlackTree<T>
        {
            public Class32()
            {
            }

            public Class32(IComparer<T> comparer) : base(comparer)
            {
            }

            public T method_4()
            {
                if (base.Count == 0)
                {
                    return default(T);
                }
                RedBlackTree<T>.Node leftMost = base.Root.GetLeftMost();
                base.Remove(leftMost);
                return leftMost.Value;
            }
        }

        internal class Class33 : Class145.Class32<Class145.Class148>
        {
            public Class33() : base(Class145.Class148.Class154.class154_0)
            {
            }
        }

        internal class Class34 : Class145.Class32<Class145.Class155>
        {
            public Class34()
            {
            }
        }

        public enum Enum7
        {
            const_0,
            const_1
        }
    }
}