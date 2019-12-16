// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.VattiClipper2DV3
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using WW.Collections.Generic;

namespace WW.Math.Geometry
{
  public class VattiClipper2DV3
  {
    private static Polygon2D[] polygon2D_0 = new Polygon2D[0];

    public static IList<Polygon2D> Clip(
      IList<Polygon2D> clip,
      IList<Polygon2D> subject,
      VattiClipper2DV3.PolygonFillMode fillMode)
    {
      List<VattiClipper2DV3.Class102.Class103> localMinimumList = new List<VattiClipper2DV3.Class102.Class103>();
      foreach (Polygon2D polygon in (IEnumerable<Polygon2D>) clip)
        VattiClipper2DV3.smethod_0(polygon, (byte) 1, localMinimumList);
      foreach (Polygon2D polygon in (IEnumerable<Polygon2D>) subject)
        VattiClipper2DV3.smethod_0(polygon, (byte) 2, localMinimumList);
      localMinimumList.Sort((IComparer<VattiClipper2DV3.Class102.Class103>) VattiClipper2DV3.Class102.Class105.class105_0);
      VattiClipper2DV3.Class102.Class103 class103_1 = (VattiClipper2DV3.Class102.Class103) null;
      if (localMinimumList.Count > 1)
      {
        VattiClipper2DV3.Class102.Class103 class103_2 = localMinimumList[localMinimumList.Count - 1];
        for (int index = localMinimumList.Count - 2; index >= 0; --index)
        {
          VattiClipper2DV3.Class102.Class103 class103_3 = localMinimumList[index];
          class103_3.class103_0 = class103_2;
          class103_2 = class103_3;
        }
        class103_1 = class103_2;
      }
      VattiClipper2DV3.Class99 class99 = new VattiClipper2DV3.Class99();
      class99.class103_0 = class103_1;
      if (class103_1 != null)
        class99.class28_0.Add(class103_1.point2D_0.Y);
      class99.method_0();
      if (class99.list_0.Count == 0)
        return (IList<Polygon2D>) VattiClipper2DV3.polygon2D_0;
      List<Polygon2D> polygon2DList = new List<Polygon2D>(class99.list_0.Count);
      foreach (VattiClipper2DV3.Class106 class106 in class99.list_0)
      {
        if (class106.Count > 2)
          polygon2DList.Add(class106.method_0());
      }
      if (polygon2DList.Count == 0)
        return (IList<Polygon2D>) VattiClipper2DV3.polygon2D_0;
      return (IList<Polygon2D>) polygon2DList;
    }

        internal static void smethod_0(Polygon2D polygon, byte type, List<VattiClipper2DV3.Class102.Class103> localMinimumList)
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
                    num1 = System.Math.Sign(point2D.Y - item.Y);
                    if (num1 == 0)
                    {
                        num1 = System.Math.Sign(point2D.X - item.X);
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
            VattiClipper2DV3.Class102 class102 = null;
            Action<VattiClipper2DV3.Class102> class1020 = null;
            while (true)
            {
                if (num <= count)
                {
                    Point2D item1 = polygon[num % count];
                    int num2 = System.Math.Sign(item1.Y - point2D.Y);
                    if (num2 == 0)
                    {
                        num2 = System.Math.Sign(item1.X - point2D.X);
                    }
                    if (num2 != 0)
                    {
                        if (num2 == num1)
                        {
                            if (num2 <= 0)
                            {
                                VattiClipper2DV3.Class102 class1021 = new VattiClipper2DV3.Class102(point2D);
                                class1020 = (VattiClipper2DV3.Class102 prev) => class1021.class102_0 = prev;
                                class102 = class1021;
                            }
                            else
                            {
                                VattiClipper2DV3.Class102 class1022 = new VattiClipper2DV3.Class102(point2D);
                                class1020 = (VattiClipper2DV3.Class102 prev) => prev.class102_0 = class1022;
                                class102 = class1022;
                            }
                        }
                        else if (num2 <= 0 || num1 >= 0)
                        {
                            VattiClipper2DV3.Class102 class1023 = new VattiClipper2DV3.Class102(point2D);
                            class1020 = (VattiClipper2DV3.Class102 prev) => prev.class102_0 = class1023;
                            class102 = class1023;
                        }
                        else
                        {
                            VattiClipper2DV3.Class102.Class103 class103 = new VattiClipper2DV3.Class102.Class103(point2D);
                            class1020 = (VattiClipper2DV3.Class102 prev) => class103.class102_1 = prev;
                            class102 = class103;
                            localMinimumList.Add(class103);
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
                int num4 = System.Math.Sign(point2D1.Y - point2D.Y);
                if (num4 == 0)
                {
                    num4 = System.Math.Sign(point2D1.X - point2D.X);
                }
                if (num4 != 0)
                {
                    if (num4 == num1)
                    {
                        if (num4 <= 0)
                        {
                            class102 = new VattiClipper2DV3.Class102(point2D)
                            {
                                class102_0 = class102
                            };
                        }
                        else
                        {
                            VattiClipper2DV3.Class102 class1024 = new VattiClipper2DV3.Class102(point2D);
                            class102.class102_0 = class1024;
                            class102 = class1024;
                        }
                    }
                    else if (num4 <= 0 || num1 >= 0)
                    {
                        VattiClipper2DV3.Class102 class1025 = new VattiClipper2DV3.Class102(point2D);
                        class102.class102_0 = class1025;
                        class102 = class1025;
                    }
                    else
                    {
                        VattiClipper2DV3.Class102.Class103 class1031 = new VattiClipper2DV3.Class102.Class103(point2D)
                        {
                            class102_1 = class102
                        };
                        class102 = class1031;
                        localMinimumList.Add(class1031);
                    }
                    num1 = num4;
                    point2D = point2D1;
                }
                num++;
            }
            if (class1020 != null)
            {
                class1020(class102);
            }
        }

        internal class Class99
    {
      public readonly VattiClipper2DV3.Class28 class28_0 = new VattiClipper2DV3.Class28();
      public readonly List<VattiClipper2DV3.Class106> list_0 = new List<VattiClipper2DV3.Class106>();
      public List<VattiClipper2DV3.Class100> list_1 = new List<VattiClipper2DV3.Class100>();
      public readonly List<VattiClipper2DV3.Class100> list_2 = new List<VattiClipper2DV3.Class100>();
      public List<VattiClipper2DV3.Class100> list_3 = new List<VattiClipper2DV3.Class100>();
      public int int_1 = 1;
      private int int_0;
      public double double_0;
      public double double_1;
      public VattiClipper2DV3.Class102.Class103 class103_0;

      public void method_0()
      {
        for (double? nullable = this.class28_0.method_4(); nullable.HasValue; nullable = this.class28_0.method_4())
        {
          this.double_1 = nullable.Value;
          bool flag = false;
          while (this.class103_0 != null && this.class103_0.point2D_0.Y == this.double_1)
          {
            VattiClipper2DV3.Class100 edge1 = new VattiClipper2DV3.Class100((VattiClipper2DV3.Class102) this.class103_0, this.class103_0.class102_0);
            edge1.double_2 = edge1.point2D_0.X;
            VattiClipper2DV3.Class100 edge2 = new VattiClipper2DV3.Class100((VattiClipper2DV3.Class102) this.class103_0, this.class103_0.class102_1);
            int index = this.list_1.BinarySearch(edge1, (IComparer<VattiClipper2DV3.Class100>) VattiClipper2DV3.Class100.Class101.class101_0);
            if (index < 0)
              index = ~index;
            this.list_1.Insert(index, edge1);
            this.list_1.Insert(index + 1, edge2);
            this.method_1(edge1);
            this.method_1(edge2);
            this.class103_0 = this.class103_0.class103_0;
            flag = true;
          }
          if (flag && this.class103_0 != null)
            this.class28_0.TryAdd(this.class103_0.point2D_0.Y);
          this.list_3.Clear();
          this.double_0 = double.NegativeInfinity;
          for (this.int_0 = 0; this.int_0 < this.list_1.Count; ++this.int_0)
          {
            VattiClipper2DV3.Class100 edge = this.list_1[this.int_0];
            if (edge.double_2 != this.double_0 && !double.IsNegativeInfinity(this.double_0))
              this.method_3();
            this.double_0 = edge.double_2;
            if (edge.point2D_0.Y == this.double_1)
              this.method_2(edge);
            else if (edge.point2D_1.Y == this.double_1)
            {
              if (edge.class102_1.class102_0 != null)
                this.method_2(new VattiClipper2DV3.Class100(edge.class102_1, edge.class102_1.class102_0));
            }
            else
              this.method_5(edge);
          }
          this.method_3();
          List<VattiClipper2DV3.Class100> list1 = this.list_1;
          this.list_1 = this.list_3;
          this.list_3 = list1;
        }
      }

      private void method_1(VattiClipper2DV3.Class100 edge)
      {
        while (edge.IsHorizontal && edge.class102_1.class102_0 != null)
        {
          edge = new VattiClipper2DV3.Class100(edge.class102_1, edge.class102_1.class102_0);
          edge.double_2 = edge.point2D_0.X;
          int index = this.list_1.BinarySearch(edge, (IComparer<VattiClipper2DV3.Class100>) VattiClipper2DV3.Class100.Class101.class101_0);
          if (index < 0)
            index = ~index;
          this.list_1.Insert(index, edge);
        }
      }

      private void method_2(VattiClipper2DV3.Class100 edge)
      {
        if (edge.IsHorizontal)
        {
          this.list_2.Add(edge);
        }
        else
        {
          edge.method_0();
          edge.double_2 = edge.point2D_0.X;
          this.method_5(edge);
          this.class28_0.TryAdd(edge.point2D_1.Y);
        }
      }

      private void method_3()
      {
        this.method_4();
      }

      private void method_4()
      {
        for (int index = this.list_2.Count - 1; index >= 0; --index)
        {
          if (this.list_2[index].point2D_1.X <= this.double_0)
            this.list_2.RemoveAt(index);
        }
      }

      internal void method_5(VattiClipper2DV3.Class100 edge)
      {
        bool flag = false;
        for (int index = this.list_3.Count - 1; index >= 0; --index)
        {
          if (edge.double_2 >= this.list_3[index].double_2)
          {
            this.list_3.Insert(index + 1, edge);
            flag = true;
            break;
          }
        }
        if (flag)
          return;
        this.list_3.Insert(0, edge);
      }
    }

    internal class Class27<T> : RedBlackTree<T>
    {
      public Class27()
      {
      }

      public Class27(IComparer<T> comparer)
        : base(comparer)
      {
      }
    }

    internal class Class28 : VattiClipper2DV3.Class27<double>
    {
      public double? method_4()
      {
        if (this.Count == 0)
          return new double?();
        RedBlackTree<double>.Node leftMost = this.Root.GetLeftMost();
        this.Remove(leftMost);
        return new double?(leftMost.Value);
      }
    }

    internal class Class100
    {
      public Point2D point2D_0;
      public Point2D point2D_1;
      private double double_0;
      private double double_1;
      public VattiClipper2DV3.Class102 class102_0;
      public VattiClipper2DV3.Class102 class102_1;
      public double double_2;

      public Class100(VattiClipper2DV3.Class102 startVertex, VattiClipper2DV3.Class102 endVertex)
      {
        this.point2D_0 = startVertex.point2D_0;
        this.point2D_1 = endVertex.point2D_0;
        this.class102_0 = startVertex;
        this.class102_1 = endVertex;
      }

      public bool IsHorizontal
      {
        get
        {
          return this.point2D_0.Y == this.point2D_1.Y;
        }
      }

      public void method_0()
      {
        this.double_0 = (this.point2D_1.X - this.point2D_0.X) / (this.point2D_1.Y - this.point2D_0.Y);
        this.double_1 = this.point2D_0.X - this.point2D_0.Y * this.double_0;
      }

      public void method_1(double y)
      {
        this.double_2 = this.double_0 * y + this.double_1;
      }

      public override string ToString()
      {
        return string.Format("{0} - {1}", (object) this.point2D_0, (object) this.point2D_1);
      }

      internal class Class101 : IComparer<VattiClipper2DV3.Class100>
      {
        public static readonly VattiClipper2DV3.Class100.Class101 class101_0 = new VattiClipper2DV3.Class100.Class101();

        public int Compare(VattiClipper2DV3.Class100 x, VattiClipper2DV3.Class100 y)
        {
          return MathUtil.Compare(x.double_2, y.double_2);
        }
      }
    }

    internal class Class102
    {
      public Point2D point2D_0;
      public VattiClipper2DV3.Class102 class102_0;

      public override string ToString()
      {
        return string.Format("({0}): {1}", (object) this.point2D_0, (object) this.GetType().Name);
      }

      public Class102()
      {
      }

      public Class102(Point2D position)
      {
        this.point2D_0 = position;
      }

      internal class Class103 : VattiClipper2DV3.Class102
      {
        public VattiClipper2DV3.Class102 class102_1;
        public VattiClipper2DV3.Class102.Class103 class103_0;

        public Class103(Point2D position)
          : base(position)
        {
        }
      }

      internal class Class104 : IComparer<VattiClipper2DV3.Class102>
      {
        public static readonly VattiClipper2DV3.Class102.Class104 class104_0 = new VattiClipper2DV3.Class102.Class104();

        public int Compare(VattiClipper2DV3.Class102 x, VattiClipper2DV3.Class102 y)
        {
          return MathUtil.Compare(x.point2D_0.X, y.point2D_0.X);
        }
      }

      internal class Class105 : IComparer<VattiClipper2DV3.Class102>
      {
        public static readonly VattiClipper2DV3.Class102.Class105 class105_0 = new VattiClipper2DV3.Class102.Class105();

        public int Compare(VattiClipper2DV3.Class102 x, VattiClipper2DV3.Class102 y)
        {
          if (x.point2D_0.Y < y.point2D_0.Y)
            return -1;
          if (x.point2D_0.Y > y.point2D_0.Y)
            return 1;
          if (x.point2D_0.X < y.point2D_0.X)
            return -1;
          return x.point2D_0.X > y.point2D_0.X ? 1 : 0;
        }
      }
    }

    internal class Class106 : LinkedList<Point2D>
    {
      public Polygon2D method_0()
      {
        return new Polygon2D((IEnumerable<Point2D>) this);
      }
    }

    public enum PolygonFillMode
    {
      EvenOdd,
      NonZero,
    }
  }
}
