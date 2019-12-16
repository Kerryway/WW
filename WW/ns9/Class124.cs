// Decompiled with JetBrains decompiler
// Type: ns9.Class124
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using WW.Collections.Generic;
using WW.Math;
using WW.Math.Geometry;

namespace ns9
{
  internal class Class124
  {
    private static Polygon2D[] polygon2D_0 = new Polygon2D[0];

    public static IList<Polygon2D> smethod_0(
      IList<Polygon2D> clip,
      IList<Polygon2D> subject,
      Class124.Enum5 fillMode)
    {
      List<Class124.Class125> class125List = new List<Class124.Class125>();
      foreach (Polygon2D polygon in (IEnumerable<Polygon2D>) clip)
        Class124.smethod_2(polygon, (byte) 1, class125List);
      foreach (Polygon2D polygon in (IEnumerable<Polygon2D>) subject)
        Class124.smethod_2(polygon, (byte) 2, class125List);
      class125List.Sort();
      Class124.Class125 localMinimum = Class124.smethod_5(class125List);
      Class124.Class130 class130 = new Class124.Class130(fillMode);
      if (localMinimum != null)
        class130.EventQueue.Add(localMinimum);
      class130.method_0();
      if (class130.ResultPolygons.Count == 0)
        return (IList<Polygon2D>) Class124.polygon2D_0;
      List<Polygon2D> polygon2DList = new List<Polygon2D>(class130.ResultPolygons.Count);
      foreach (Class124.Class133 resultPolygon in class130.ResultPolygons)
      {
        if (resultPolygon.Count > 2)
          polygon2DList.Add(resultPolygon.method_0());
      }
      if (polygon2DList.Count == 0)
        return (IList<Polygon2D>) Class124.polygon2D_0;
      return (IList<Polygon2D>) polygon2DList;
    }

    public static IList<Polyline2D> smethod_1(
      IList<Polygon2D> clip,
      Polyline2D subject,
      bool filled,
      Class124.Enum5 fillMode)
    {
      List<Class124.Class125> class125List = new List<Class124.Class125>();
      foreach (Polygon2D polygon in (IEnumerable<Polygon2D>) clip)
        Class124.smethod_2(polygon, (byte) 1, class125List);
      Class124.smethod_3(subject, (byte) 2, class125List);
      class125List.Sort();
      Class124.Class125 localMinimum = Class124.smethod_5(class125List);
      Class124.Class130 class130 = new Class124.Class130(fillMode);
      if (localMinimum != null)
        class130.EventQueue.Add(localMinimum);
      class130.method_0();
      return (IList<Polyline2D>) null;
    }

    internal static void smethod_2(
      Polygon2D polygon,
      byte type,
      List<Class124.Class125> localMinimumList)
    {
      if (polygon.Count == 0)
        return;
      Point2D point2D1 = polygon[polygon.Count - 1];
      Point2D p = polygon[0];
      Class124.Class136 class136 = Class124.Class136.smethod_0(point2D1.X, point2D1.Y, p.X, p.Y);
      Class124.Class136 e0 = class136;
      int num1 = System.Math.Sign(p.Y - point2D1.Y);
      if (num1 == 0)
        num1 = System.Math.Sign(p.X - point2D1.X);
      int num2 = num1;
      for (int index = 1; index < polygon.Count; ++index)
      {
        Point2D point2D2 = polygon[index];
        Class124.Class136 e1 = Class124.Class136.smethod_0(p.X, p.Y, point2D2.X, point2D2.Y);
        int num3 = System.Math.Sign(point2D2.Y - p.Y);
        if (num3 == 0)
          num3 = System.Math.Sign(point2D2.X - p.X);
        if (num3 == num1)
        {
          if (num3 > 0)
            e0.Successor = e1;
          else
            e1.Successor = e0;
        }
        else if (num3 > 0 && num1 < 0)
          Class124.smethod_4(type, true, p, localMinimumList, e0, e1);
        else if (num3 < 0)
          ;
        num1 = num3;
        point2D1 = p;
        p = point2D2;
        e0 = e1;
      }
      Class124.Class136 e1_1 = class136;
      int num4 = num2;
      if (num4 == num1)
      {
        if (num4 > 0)
          e0.Successor = e1_1;
        else
          e1_1.Successor = e0;
      }
      else if (num4 > 0 && num1 < 0)
        Class124.smethod_4(type, true, p, localMinimumList, e0, e1_1);
      else if (num4 < 0)
        ;
    }

    internal static void smethod_3(
      Polyline2D polyline,
      byte type,
      List<Class124.Class125> localMinimumList)
    {
      if (polyline.Count == 0)
        return;
      Point2D point2D1 = polyline[polyline.Closed ? polyline.Count - 1 : 0];
      int index1 = polyline.Closed ? 0 : 1;
      Point2D p = polyline[index1];
      Class124.Class136 class136 = Class124.Class136.smethod_0(point2D1.X, point2D1.Y, p.X, p.Y);
      Class124.Class136 e0 = class136;
      int num1 = System.Math.Sign(p.Y - point2D1.Y);
      if (num1 == 0)
        num1 = System.Math.Sign(p.X - point2D1.X);
      int num2 = num1;
      for (int index2 = index1 + 1; index2 < polyline.Count; ++index2)
      {
        Point2D point2D2 = polyline[index2];
        Class124.Class136 e1 = Class124.Class136.smethod_0(p.X, p.Y, point2D2.X, point2D2.Y);
        int num3 = System.Math.Sign(point2D2.Y - p.Y);
        if (num3 == 0)
          num3 = System.Math.Sign(point2D2.X - p.X);
        if (num3 == num1)
        {
          if (num3 > 0)
            e0.Successor = e1;
          else
            e1.Successor = e0;
        }
        else if (num3 > 0 && num1 < 0)
          Class124.smethod_4(type, false, p, localMinimumList, e0, e1);
        else if (num3 < 0)
          ;
        num1 = num3;
        point2D1 = p;
        p = point2D2;
        e0 = e1;
      }
      if (!polyline.Closed)
        return;
      Class124.Class136 e1_1 = class136;
      int num4 = num2;
      if (num4 == num1)
      {
        if (num4 > 0)
          e0.Successor = e1_1;
        else
          e1_1.Successor = e0;
      }
      else if (num4 > 0 && num1 < 0)
        Class124.smethod_4(type, false, p, localMinimumList, e0, e1_1);
      else if (num4 < 0)
        ;
    }

    private static void smethod_4(
      byte type,
      bool belongsToPolygon,
      Point2D p,
      List<Class124.Class125> localMinimumList,
      Class124.Class136 e0,
      Class124.Class136 e1)
    {
      Class124.Class125 class125 = new Class124.Class125(type, belongsToPolygon) { Y = p.Y };
      localMinimumList.Add(class125);
      if (e0.XTop <= e1.XTop)
      {
        class125.Left = e0;
        class125.Right = e1;
      }
      else
      {
        class125.Left = e1;
        class125.Right = e0;
      }
      e1.XBottom = p.X;
    }

    private static Class124.Class125 smethod_5(List<Class124.Class125> localMinima)
    {
      Class124.Class125 class125_1 = (Class124.Class125) null;
      if (localMinima.Count > 1)
      {
        Class124.Class125 class125_2 = localMinima[localMinima.Count - 1];
        for (int index = localMinima.Count - 2; index >= 0; --index)
        {
          Class124.Class125 class125_3 = localMinima[index];
          class125_3.Next = class125_2;
          class125_2 = class125_3;
        }
        class125_1 = class125_2;
      }
      return class125_1;
    }

    internal class Class125 : IComparable<Class124.Class125>
    {
      private double double_0;
      private byte byte_0;
      private bool bool_0;
      private Class124.Class136 class136_0;
      private Class124.Class136 class136_1;
      private Class124.Class125 class125_0;

      public Class125(byte type, bool belongsToPolygon)
      {
        this.byte_0 = type;
        this.bool_0 = belongsToPolygon;
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

      public bool BelongsToPolygon
      {
        get
        {
          return this.bool_0;
        }
      }

      public Class124.Class136 Left
      {
        get
        {
          return this.class136_0;
        }
        set
        {
          this.class136_0 = value;
        }
      }

      public Class124.Class136 Right
      {
        get
        {
          return this.class136_1;
        }
        set
        {
          this.class136_1 = value;
        }
      }

      public Class124.Class125 Next
      {
        get
        {
          return this.class125_0;
        }
        set
        {
          this.class125_0 = value;
        }
      }

      public int CompareTo(Class124.Class125 other)
      {
        return MathUtil.Compare(this.double_0, other.double_0);
      }

      public override string ToString()
      {
        return string.Format("type = {0}, y = {1}, next y = {2}, left = {3}, right = {4}", (object) this.byte_0, (object) this.double_0, this.class125_0 == null ? (object) "null" : (object) this.class125_0.double_0.ToString(), (object) this.class136_0, (object) this.class136_1);
      }
    }

    internal class Class30 : RedBlackTree<Class124.Class126>
    {
      private int int_1 = 1;

      public void Add(Class124.Class125 localMinimum)
      {
        this.Add((Class124.Class126) new Class124.Class127(this, localMinimum));
      }

      public Class124.Class126 method_4()
      {
        if (this.Count == 0)
          return (Class124.Class126) null;
        RedBlackTree<Class124.Class126>.Node leftMost = this.Root.GetLeftMost();
        this.Remove(leftMost);
        return leftMost.Value;
      }

      public int method_5()
      {
        return this.int_1++;
      }
    }

    internal abstract class Class126 : IComparable<Class124.Class126>
    {
      private double double_0;
      private int int_0;

      protected Class126(double y, int id)
      {
        this.double_0 = y;
        this.int_0 = id;
      }

      protected Class126(Class124.Class30 eventQueue, double y)
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

      public abstract int Order { get; }

      public int CompareTo(Class124.Class126 other)
      {
        if (this.double_0 < other.double_0)
          return -1;
        if (this.double_0 > other.double_0)
          return 1;
        if (this.Order < other.Order)
          return -1;
        if (this.Order > other.Order)
          return 1;
        return MathUtil.Compare(this.int_0, other.int_0);
      }

      public virtual void vmethod_0(Class124.Class30 eventQueue, Class124.Class130 scanBeam)
      {
      }

      public override string ToString()
      {
        return string.Format("y {0}", (object) this.double_0);
      }
    }

    internal class Class127 : Class124.Class126
    {
      private Class124.Class125 class125_0;

      public Class127(Class124.Class30 eventQueue, Class124.Class125 localMinimum)
        : base(localMinimum.Y, 0)
      {
        this.class125_0 = localMinimum;
      }

      public override int Order
      {
        get
        {
          return 0;
        }
      }

      public Class124.Class125 LocalMinimum
      {
        get
        {
          return this.class125_0;
        }
        set
        {
          this.class125_0 = value;
        }
      }

      public override void vmethod_0(Class124.Class30 eventQueue, Class124.Class130 scanBeam)
      {
      }

      public void method_0(Class124.Class30 eventQueue, Class124.Class130 scanBeam)
      {
        scanBeam.method_24(this.class125_0);
        Class124.Class125 class125 = this.class125_0;
        bool flag = false;
        for (; class125.Next != null; class125 = class125.Next)
        {
          if (class125.Y == class125.Next.Y)
          {
            if (scanBeam.method_24(class125.Next))
              flag = true;
          }
          else
          {
            scanBeam.EventQueue.Add(class125.Next);
            break;
          }
        }
        if (!flag)
          return;
        scanBeam.HasHorizontalEdges = true;
      }
    }

    internal class Class128 : Class124.Class126
    {
      private Class124.Class139 class139_0;

      public Class128(Class124.Class30 eventQueue, Class124.Class139 edge)
        : base(eventQueue, edge.Edge.YTop)
      {
        this.class139_0 = edge;
      }

      public Class124.Class139 Edge
      {
        get
        {
          return this.class139_0;
        }
        set
        {
          this.class139_0 = value;
        }
      }

      public override int Order
      {
        get
        {
          return 1;
        }
      }

      public override void vmethod_0(Class124.Class30 eventQueue, Class124.Class130 scanBeam)
      {
        scanBeam.method_27(this);
      }
    }

    internal class Class129 : Class124.Class126
    {
      private Class124.Class137 class137_0;
      private Class124.Class137 class137_1;

      public Class129(double y, int id)
        : base(y, id)
      {
      }

      public Class129(Class124.Class30 eventQueue, double y)
        : base(eventQueue, y)
      {
      }

      public Class124.Class137 Edge1
      {
        get
        {
          return this.class137_0;
        }
        set
        {
          this.class137_0 = value;
        }
      }

      public Class124.Class137 Edge2
      {
        get
        {
          return this.class137_1;
        }
        set
        {
          this.class137_1 = value;
        }
      }

      public override int Order
      {
        get
        {
          return 2;
        }
      }
    }

    internal class Class130
    {
      private Class124.Class30 class30_0 = new Class124.Class30();
      private Class124.Class31 class31_0 = new Class124.Class31();
      private List<Class124.Class139> list_0 = new List<Class124.Class139>();
      private Class124.Class130.Class131 class131_0 = new Class124.Class130.Class131();
      private Class124.Class130.Class132 class132_0 = new Class124.Class130.Class132();
      private List<Class124.Class139> list_1 = new List<Class124.Class139>();
      private List<Class124.Class140> list_2 = new List<Class124.Class140>();
      private List<Class124.Class133> list_3 = new List<Class124.Class133>();
      private List<Class124.Class139> list_4 = new List<Class124.Class139>();
      private Class124.Enum5 enum5_0;
      private double double_0;
      private double double_1;
      private bool bool_0;
      private bool bool_1;
      private bool bool_2;
      private bool bool_3;
      private bool bool_4;

      public Class130(Class124.Enum5 fillMode)
      {
        this.enum5_0 = fillMode;
      }

      public Class124.Enum5 FillMode
      {
        get
        {
          return this.enum5_0;
        }
        set
        {
          this.enum5_0 = value;
        }
      }

      public Class124.Class30 EventQueue
      {
        get
        {
          return this.class30_0;
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

      public Class124.Class31 HorizontalEventQueue
      {
        get
        {
          return this.class31_0;
        }
      }

      public List<Class124.Class139> ActiveEdges
      {
        get
        {
          return this.list_0;
        }
      }

      public bool HasHorizontalEdges
      {
        get
        {
          return this.bool_4;
        }
        set
        {
          this.bool_4 = value;
        }
      }

      public List<Class124.Class133> ResultPolygons
      {
        get
        {
          return this.list_3;
        }
      }

      public List<Class124.Class139> ActiveHorizontalEdges
      {
        get
        {
          return this.list_4;
        }
      }

      public void method_0()
      {
        Class124.Class126 class126_1 = this.class30_0.method_4();
        this.double_0 = this.double_1 = class126_1.Y;
        this.method_9((Class124.Class127) class126_1);
        Class124.Class126 class126_2;
        for (; class126_1 != null; class126_1 = class126_2)
        {
          this.double_0 = class126_1.Y;
          class126_1.vmethod_0(this.class30_0, this);
          for (class126_2 = this.class30_0.method_4(); class126_2 != null && (this.double_1 = class126_2.Y) == this.double_0; class126_2 = this.class30_0.method_4())
            class126_2.vmethod_0(this.class30_0, this);
          this.method_2();
          this.method_9(class126_2 as Class124.Class127);
        }
      }

      private void method_1()
      {
        if (!this.bool_4)
          return;
        for (int index = this.list_0.Count - 1; index >= 0; --index)
        {
          if (this.list_0[index].Edge.IsHorizontal)
            this.list_0.RemoveAt(index);
        }
        this.bool_4 = false;
      }

      private void method_2()
      {
        if (this.list_0.Count == 0)
          return;
        this.method_3();
        this.method_8();
      }

      private void method_3()
      {
        this.list_1.Clear();
        this.list_2.Clear();
        Class124.Class139 class139 = this.list_0[0];
        class139.method_8(this.double_1);
        this.list_1.Add(class139);
        for (int index1 = 1; index1 < this.list_0.Count; ++index1)
        {
          Class124.Class139 edge0 = this.list_0[index1];
          edge0.method_8(this.double_1);
          bool flag = false;
          for (int index2 = this.list_1.Count - 1; index2 >= 0; --index2)
          {
            Class124.Class139 edge1 = this.list_1[index2];
            if (edge0.XScanbeamTopIntersection < edge1.XScanbeamTopIntersection)
            {
              Segment2D a = edge0.Edge.method_1();
              Segment2D b = edge1.Edge.method_1();
              double[] pArray;
              double[] qArray;
              if (Segment2D.GetIntersectionParameters(a, b, out pArray, out qArray) && pArray.Length == 1)
              {
                Point2D position = a.Start + pArray[0] * a.GetDelta();
                this.list_2.Add(new Class124.Class140(edge0, edge1, position));
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
        this.method_4();
      }

      private void method_4()
      {
        List<Class124.Class139> list0 = this.list_0;
        this.list_0 = this.list_1;
        this.list_1 = list0;
      }

      private bool method_5()
      {
        bool flag1 = false;
        this.list_1.Clear();
        Class124.Class139 class139_1 = this.list_0[0];
        class139_1.method_9(this.double_1);
        class139_1.IntersectsWithHorizontalEdge = false;
        this.list_1.Add(class139_1);
        for (int index1 = 1; index1 < this.list_0.Count; ++index1)
        {
          Class124.Class139 class139_2 = this.list_0[index1];
          class139_2.method_9(this.double_1);
          class139_2.IntersectsWithHorizontalEdge = false;
          bool flag2 = false;
          for (int index2 = this.list_1.Count - 1; index2 >= 0; --index2)
          {
            Class124.Class139 class139_3 = this.list_1[index2];
            if (class139_2.XScanbeamTopIntersection2 < class139_3.XScanbeamTopIntersection2)
            {
              class139_2.IntersectsWithHorizontalEdge = true;
              class139_3.IntersectsWithHorizontalEdge = true;
              flag1 = true;
            }
            else
            {
              this.list_1.Insert(index2 + 1, class139_2);
              flag2 = true;
              if ((class139_2.XScanbeamTopIntersection != class139_2.XScanbeamTopIntersection2 || class139_3.XScanbeamTopIntersection != class139_3.XScanbeamTopIntersection2) && class139_2.XScanbeamTopIntersection2 == class139_3.XScanbeamTopIntersection2)
              {
                class139_2.IntersectsWithHorizontalEdge = true;
                class139_3.IntersectsWithHorizontalEdge = true;
                for (int index3 = index2 - 1; index3 >= 0; --index3)
                {
                  Class124.Class139 class139_4 = this.list_1[index3];
                  if (class139_2.XScanbeamTopIntersection2 == class139_4.XScanbeamTopIntersection2)
                    class139_4.IntersectsWithHorizontalEdge = true;
                  else
                    break;
                }
                break;
              }
              break;
            }
          }
          if (!flag2)
            this.list_1.Insert(0, class139_2);
        }
        return flag1;
      }

      private void method_6()
      {
        if (this.list_0.Count == 0)
          return;
        this.list_1.Clear();
        for (int index1 = 0; index1 < this.list_0.Count; ++index1)
        {
          Class124.Class139 a = this.list_0[index1];
          if (a.Edge.YTop == this.double_1)
          {
            if (a.Edge.Successor != null)
            {
              a.Edge = a.Successor;
              while (a.Edge != null && a.Edge.IsHorizontal)
                a.Edge = a.Successor;
              if (a.Edge != null)
                a.XScanbeamBottomIntersection = a.Edge.XBottom;
              else
                continue;
            }
            else
              continue;
          }
          else
            a.XScanbeamBottomIntersection = a.XScanbeamTopIntersection;
          bool flag = false;
          for (int index2 = this.list_1.Count - 1; index2 >= 0; --index2)
          {
            Class124.Class139 b = this.list_1[index2];
            if (this.class131_0.Compare(a, b) >= 0)
            {
              this.list_1.Insert(index2 + 1, a);
              flag = true;
              break;
            }
          }
          if (!flag)
            this.list_1.Insert(0, a);
        }
        this.method_4();
      }

      private void method_7()
      {
        if (this.list_0.Count == 0)
          return;
        this.list_1.Clear();
        this.list_1.Add(this.list_0[0]);
        for (int index1 = 1; index1 < this.list_0.Count; ++index1)
        {
          Class124.Class139 class139_1 = this.list_0[index1];
          bool flag = false;
          for (int index2 = this.list_1.Count - 1; index2 >= 0; --index2)
          {
            Class124.Class139 class139_2 = this.list_1[index2];
            if (class139_1.XScanbeamBottomIntersection >= class139_2.XScanbeamBottomIntersection)
            {
              this.list_1.Insert(index2 + 1, class139_1);
              flag = true;
              break;
            }
          }
          if (!flag)
            this.list_1.Insert(0, class139_1);
        }
        this.method_4();
      }

      private void method_8()
      {
        if (this.list_2.Count == 0)
          return;
        foreach (Class124.Class140 intersection in this.list_2)
        {
          if (!intersection.Edge0.BelongsToPolygon)
          {
            if (intersection.Edge1.BelongsToPolygon)
              Class124.Class130.smethod_1(intersection, intersection.Edge0);
          }
          else if (!intersection.Edge1.BelongsToPolygon)
          {
            if (intersection.Edge0.BelongsToPolygon)
              Class124.Class130.smethod_1(intersection, intersection.Edge1);
          }
          else
          {
            switch (intersection.method_0())
            {
              case Class124.Enum6.const_1:
                intersection.Edge0.method_1(intersection.Position);
                break;
              case Class124.Enum6.const_2:
                intersection.Edge1.method_3(intersection.Position);
                break;
              case Class124.Enum6.const_3:
                Class124.Class130.smethod_0(intersection);
                break;
              case Class124.Enum6.const_4:
                this.method_33(intersection.Edge1, intersection.Edge0, intersection.Position);
                break;
              case Class124.Enum6.const_5:
                this.method_28(intersection.Edge1, intersection.Edge0, intersection.Position);
                break;
            }
          }
          Class124.Class134 resultPolygonRef = intersection.Edge0.ResultPolygonRef;
          intersection.Edge0.ResultPolygonRef = intersection.Edge1.ResultPolygonRef;
          intersection.Edge1.ResultPolygonRef = resultPolygonRef;
        }
      }

      private static void smethod_0(Class124.Class140 intersection)
      {
        if (intersection.Edge1.ResultPolygon != null)
        {
          intersection.Edge1.method_1(intersection.Position);
          intersection.Edge0.method_3(intersection.Position);
        }
        intersection.Edge0.method_5(intersection.Edge1);
      }

      private static void smethod_1(Class124.Class140 intersection, Class124.Class139 polylineEdge)
      {
        if (polylineEdge.ResultPolygon == null)
        {
          polylineEdge.ResultPolygon = new Class124.Class133();
          polylineEdge.ResultPolygon.AddLast(intersection.Position);
        }
        else
        {
          polylineEdge.ResultPolygon.AddLast(intersection.Position);
          polylineEdge.ResultPolygon = (Class124.Class133) null;
        }
      }

      private void method_9(Class124.Class127 addLocalMinimumEvent)
      {
        this.list_1.Clear();
        this.bool_4 = false;
        this.method_10();
        this.method_12(addLocalMinimumEvent);
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (this.bool_4)
        {
          for (int index1 = 0; index1 < this.list_0.Count; ++index1)
          {
            Class124.Class139 class139_1 = this.list_0[index1];
            if (class139_1.Edge.IsHorizontal)
              ++num1;
            else if (this.enum5_0 == Class124.Enum5.const_0)
            {
              if (class139_1.Type == (byte) 1)
                this.bool_2 = !this.bool_2;
              else
                this.bool_3 = !this.bool_3;
            }
            else if (this.enum5_0 == Class124.Enum5.const_1)
            {
              if (class139_1.Type == (byte) 1)
              {
                if (class139_1.SideBelow == (byte) 1)
                  ++num2;
                else if (class139_1.SideBelow == (byte) 2)
                  --num2;
                this.bool_2 = (num2 & 1) == 1;
              }
              else
              {
                if (class139_1.SideBelow == (byte) 1)
                  ++num3;
                else if (class139_1.SideBelow == (byte) 2)
                  --num3;
                this.bool_3 = (num3 & 1) != 0;
              }
            }
            if (class139_1.Edge.YTop == this.double_1)
            {
              if (class139_1.XScanbeamTopIntersection == class139_1.Edge.XTop && class139_1.Successor != null && !class139_1.Successor.IsHorizontal)
              {
                Class124.Class139 class139_2 = class139_1.method_10(class139_1.Successor);
                this.method_11(class139_2);
                this.method_27(new Class124.Class128(this.class30_0, class139_2));
              }
            }
            else
            {
              class139_1.method_7(this.double_1);
              this.method_11(class139_1);
            }
            if (class139_1.Edge.IsHorizontal)
            {
              Class124.Class139 right = index1 + 1 < this.list_0.Count ? this.list_0[index1 + 1] : (Class124.Class139) null;
              if (right != null && right.Edge.IsHorizontal && (class139_1.ResultPolygon == null && right.ResultPolygon == null) && (int) class139_1.Type == (int) right.Type && (num1 > 0 || class139_1.Type == (byte) 1 && this.bool_3 || class139_1.Type == (byte) 2 && this.bool_2) && (class139_1.Edge.Successor == right.Edge || right.Edge.Successor == class139_1.Edge))
                this.method_28(class139_1, right, new Point2D(class139_1.XScanbeamTopIntersection, this.double_1));
            }
            else if (class139_1.Edge.YTop <= this.double_1)
            {
              if (class139_1.Successor == null)
              {
                if (class139_1.ResultPolygon != null)
                {
                  int index2 = index1 - 1;
                  if (index2 >= 0)
                  {
                    Class124.Class139 edge = this.list_0[index2];
                    if (edge != null && edge.ResultPolygon != null && (edge.Edge.YTop == this.double_1 && edge.Edge.XTop == class139_1.Edge.XTop))
                    {
                      this.method_33(edge, class139_1, class139_1.Edge.Top);
                      this.list_0[index1] = (Class124.Class139) null;
                      this.list_0[index2] = (Class124.Class139) null;
                    }
                  }
                }
              }
              else if (class139_1.SideBelow == (byte) 1)
              {
                if (class139_1.ResultPolygon != null)
                  class139_1.method_0(class139_1.Edge.Top);
                class139_1.Edge = class139_1.Successor;
                class139_1.XScanbeamBottomIntersection = class139_1.Edge.XBottom;
              }
              else if (class139_1.SideBelow == (byte) 2)
              {
                if (class139_1.ResultPolygon != null)
                  class139_1.method_2(class139_1.Edge.Top);
                class139_1.Edge = class139_1.Successor;
                class139_1.XScanbeamBottomIntersection = class139_1.Edge.XBottom;
              }
            }
            else
            {
              int index2 = index1;
              for (Class124.Class139 class139_2 = index2 > 0 ? this.list_0[index2 - 1] : (Class124.Class139) null; class139_2 != null && class139_2.Edge.IsHorizontal; class139_2 = index2 > 0 ? this.list_0[index2 - 1] : (Class124.Class139) null)
              {
                if (class139_2.Edge.XTop <= class139_1.XScanbeamTopIntersection)
                {
                  if (class139_2.Edge.Successor == null && class139_2.ResultPolygon != null)
                  {
                    for (int index3 = index2 - 1 - 1; index3 >= 0; --index3)
                    {
                      Class124.Class139 edge = this.list_0[index3];
                      if (edge != null)
                      {
                        if (edge.Edge.IsHorizontal)
                        {
                          if (edge.Edge.Successor == null && edge.Edge.XTop == class139_2.Edge.XTop && edge.ResultPolygon != null)
                          {
                            this.method_33(edge, class139_2, new Point2D(class139_2.Edge.XTop, this.double_1));
                            this.list_0[index3] = (Class124.Class139) null;
                            break;
                          }
                        }
                        else
                          break;
                      }
                    }
                  }
                  --index2;
                  this.list_0[index2] = (Class124.Class139) null;
                  --num1;
                }
                else
                {
                  this.list_0[index2] = class139_2;
                  --index2;
                  this.list_0[index2] = class139_1;
                  class139_2.XScanbeamTopIntersection = class139_1.XScanbeamTopIntersection;
                  if (class139_1.BelongsToPolygon && class139_2.BelongsToPolygon)
                  {
                    Class124.Class140 intersection = new Class124.Class140(class139_1, class139_2, new Point2D(class139_1.XScanbeamTopIntersection, this.double_1));
                    switch (intersection.method_0())
                    {
                      case Class124.Enum6.const_1:
                        intersection.Edge0.method_1(intersection.Position);
                        break;
                      case Class124.Enum6.const_2:
                        intersection.Edge1.method_3(intersection.Position);
                        break;
                      case Class124.Enum6.const_3:
                        Class124.Class130.smethod_0(intersection);
                        break;
                      case Class124.Enum6.const_4:
                        this.method_33(intersection.Edge1, intersection.Edge0, intersection.Position);
                        break;
                      case Class124.Enum6.const_5:
                        this.method_28(intersection.Edge1, intersection.Edge0, intersection.Position);
                        break;
                    }
                    Class124.Class134 resultPolygonRef = intersection.Edge0.ResultPolygonRef;
                    intersection.Edge0.ResultPolygonRef = intersection.Edge1.ResultPolygonRef;
                    intersection.Edge1.ResultPolygonRef = resultPolygonRef;
                  }
                }
              }
            }
          }
        }
        else
        {
          for (int index1 = 0; index1 < this.list_0.Count; ++index1)
          {
            Class124.Class139 class139 = this.list_0[index1];
            if (class139.BelongsToPolygon)
            {
              if (class139.Edge.YTop == this.double_1)
              {
                if (class139.Edge.Successor == null)
                {
                  for (int index2 = index1 + 1; index2 < this.list_0.Count; ++index2)
                  {
                    Class124.Class139 nextEdge = this.list_0[index2];
                    if (nextEdge.BelongsToPolygon)
                    {
                      this.method_33(class139, nextEdge, new Point2D(class139.Edge.XTop, this.double_1));
                      this.list_0.RemoveAt(index2);
                      this.list_0.RemoveAt(index1);
                      --index1;
                      break;
                    }
                  }
                }
                else
                {
                  class139.Edge = class139.Edge.Successor;
                  class139.XScanbeamBottomIntersection = class139.XScanbeamTopIntersection;
                  if (class139.ResultPolygon != null)
                    class139.method_4(new Point2D(class139.Edge.XTop, this.double_1));
                  while (class139.Edge != null && class139.Edge.IsHorizontal)
                    class139.Edge = class139.Edge.Successor;
                  if (class139.Edge != null)
                  {
                    this.method_11(class139);
                    this.method_27(new Class124.Class128(this.class30_0, class139));
                  }
                }
              }
              else
              {
                class139.method_7(this.double_1);
                this.method_11(class139);
              }
            }
          }
        }
        if (num1 > 0)
        {
          int count = this.list_0.Count;
          Class124.Class139 nextEdge = count > 0 ? this.list_0[count - 1] : (Class124.Class139) null;
          while (nextEdge != null && nextEdge.Edge.IsHorizontal)
          {
            if (nextEdge.Edge.Successor == null && nextEdge.ResultPolygon != null)
            {
              for (int index = count - 1 - 1; index >= 0; --index)
              {
                Class124.Class139 edge = this.list_0[index];
                if (edge != null)
                {
                  if (edge.Edge.IsHorizontal)
                  {
                    if (edge.Edge.Successor == null && edge.Edge.XTop == nextEdge.Edge.XTop && edge.ResultPolygon != null)
                    {
                      this.method_33(edge, nextEdge, new Point2D(nextEdge.Edge.XTop, this.double_1));
                      this.list_0[index] = (Class124.Class139) null;
                      break;
                    }
                  }
                  else
                    break;
                }
              }
            }
            --count;
            this.list_0[count] = (Class124.Class139) null;
            --num1;
          }
        }
        this.method_4();
      }

      private void method_10()
      {
        for (int index1 = 0; index1 < this.list_0.Count; ++index1)
        {
          Class124.Class139 class139_1 = this.list_0[index1];
          if (class139_1.Edge.YTop == this.double_1)
          {
            Class124.Class136 successor = class139_1.Edge.Successor;
            int index2 = index1;
            for (; successor != null && successor.IsHorizontal; successor = successor.Successor)
            {
              Class124.Class139 class139_2 = class139_1.method_10(successor);
              this.bool_4 = true;
              if (class139_2.Edge.XTop <= class139_2.Edge.XBottom)
              {
                double xtop = class139_2.Edge.XTop;
                class139_2.XScanbeamTopIntersection = xtop;
                bool flag = false;
                for (--index2; index2 >= 0; --index2)
                {
                  if (this.list_0[index2].XScanbeamTopIntersection < xtop)
                  {
                    ++index2;
                    flag = true;
                    break;
                  }
                }
                if (!flag)
                  index2 = 0;
              }
              else
              {
                class139_2.XScanbeamTopIntersection = class139_2.Edge.XBottom;
                ++index2;
              }
              ++index1;
              this.list_0.Insert(index2, class139_2);
              class139_1 = class139_2;
            }
          }
        }
      }

      private void method_11(Class124.Class139 e)
      {
        bool flag = false;
        for (int index = this.list_1.Count - 1; index >= 0; --index)
        {
          Class124.Class139 b = this.list_1[index];
          if (this.class131_0.Compare(e, b) >= 0)
          {
            this.list_1.Insert(index + 1, e);
            flag = true;
            break;
          }
        }
        if (flag)
          return;
        this.list_1.Insert(0, e);
      }

      private void method_12(Class124.Class127 addLocalMinimumEvent)
      {
        if (addLocalMinimumEvent == null)
          return;
        Class124.Class125 localMinimum;
        for (localMinimum = addLocalMinimumEvent.LocalMinimum; localMinimum != null && localMinimum.Y <= this.double_1; localMinimum = localMinimum.Next)
        {
          this.method_13(localMinimum, localMinimum.Left);
          this.method_13(localMinimum, localMinimum.Right);
        }
        if (localMinimum == null)
          return;
        this.class30_0.Add((Class124.Class126) new Class124.Class127(this.class30_0, localMinimum));
      }

      private void method_13(Class124.Class125 localMinimum, Class124.Class136 edge)
      {
        if (edge.IsHorizontal)
        {
          Class124.Class139 predecessor = (Class124.Class139) null;
          while (edge != null)
          {
            predecessor = this.method_26(localMinimum, edge, predecessor);
            edge = edge.Successor;
            this.bool_4 = true;
          }
        }
        else
        {
          double xbottom = localMinimum.Left.XBottom;
          Class124.Class138 class138 = new Class124.Class138(xbottom, this.double_1, xbottom);
          class138.Successor = edge;
          this.method_26(localMinimum, (Class124.Class136) class138, (Class124.Class139) null);
        }
      }

      public void method_14(Class124.Class139 predecessor, Class124.Class139 horizontalEdge)
      {
        this.list_4.Add(horizontalEdge);
        horizontalEdge.SideBelow = predecessor.SideBelow;
        if ((horizontalEdge.Type != (byte) 1 || !this.bool_1 && !this.bool_3) && (horizontalEdge.Type != (byte) 2 || !this.bool_0 && !this.bool_2))
          return;
        if (predecessor.ResultPolygon != null)
          horizontalEdge.ResultPolygonRef = predecessor.ResultPolygonRef;
        else
          horizontalEdge.ResultPolygon = new Class124.Class133();
        horizontalEdge.method_4(new Point2D(horizontalEdge.XScanbeamBottomIntersection, this.double_1));
      }

      public void method_15(Class124.Class139 successor, Class124.Class139 horizontalEdge)
      {
        this.list_4.Add(horizontalEdge);
        horizontalEdge.SideBelow = successor.SideAbove;
        if ((horizontalEdge.Type != (byte) 1 || !this.bool_1 && !this.bool_3) && (horizontalEdge.Type != (byte) 2 || !this.bool_0 && !this.bool_2))
          return;
        horizontalEdge.ResultPolygon = new Class124.Class133();
        if (horizontalEdge.Type == (byte) 1 && this.bool_1 || horizontalEdge.Type == (byte) 2 && this.bool_0)
          successor.ResultPolygonRef = horizontalEdge.ResultPolygonRef;
        horizontalEdge.method_4(new Point2D(horizontalEdge.XScanbeamBottomIntersection, this.double_1));
      }

      public void method_16(Class124.Class139 predecessor, Class124.Class139 horizontalEdge)
      {
        if (!this.list_4.Remove(horizontalEdge))
          throw new Exception("horizontal edge not found");
        if (predecessor.ResultPolygon == null || horizontalEdge.ResultPolygon == null)
          return;
        this.method_30(predecessor, horizontalEdge);
      }

      public void method_17(Class124.Class139 successor, Class124.Class139 horizontalEdge)
      {
        if (!this.list_4.Remove(horizontalEdge))
          throw new Exception("horizontal edge not found");
        if (horizontalEdge.ResultPolygon == null || (successor.Type != (byte) 1 || !this.bool_1) && (successor.Type != (byte) 2 || !this.bool_0))
          return;
        successor.ResultPolygonRef = horizontalEdge.ResultPolygonRef;
        successor.linkedListNode_0 = horizontalEdge.linkedListNode_0;
      }

      public void method_18(
        Class124.Class139 horizontalReplacement,
        Class124.Class139 horizontalEdge)
      {
        bool flag = false;
        for (int index = 0; index < this.list_4.Count; ++index)
        {
          if (this.list_4[index] == horizontalEdge)
          {
            this.list_4[index] = horizontalReplacement;
            flag = true;
            break;
          }
        }
        if (!flag)
          throw new Exception("horizontal edge not found");
        if (horizontalEdge.ResultPolygonRef == null)
          return;
        horizontalReplacement.ResultPolygonRef = horizontalEdge.ResultPolygonRef;
        horizontalReplacement.linkedListNode_0 = horizontalEdge.linkedListNode_0;
        horizontalReplacement.SideBelow = horizontalEdge.SideBelow;
      }

      public void method_19(Class124.Class139 e1, Class124.Class139 e2)
      {
        this.list_4.Add(e1);
        this.list_4.Add(e2);
        e1.SideBelow = (byte) 1;
        e2.SideBelow = (byte) 2;
        e2.ResultPolygonRef = e1.ResultPolygonRef;
        if ((e1.Type != (byte) 1 || !this.bool_1 && !this.bool_3) && (e1.Type != (byte) 2 || !this.bool_0 && !this.bool_2))
          return;
        e1.ResultPolygon = new Class124.Class133();
        e1.linkedListNode_0 = e1.ResultPolygon.AddLast(new Point2D(e2.Edge.XBottom, this.double_0));
        e2.linkedListNode_0 = e1.linkedListNode_0;
      }

      public void method_20(Class124.Class139 e1, Class124.Class139 e2)
      {
        this.list_4.Remove(e1);
        this.list_4.Remove(e2);
        if (e1.ResultPolygon == null || e2.ResultPolygon == null || e1.ResultPolygon == e2.ResultPolygon)
          return;
        this.method_30(e1, e2);
      }

      private void method_21(Class124.Class139 e)
      {
        bool flag = false;
        for (int index = this.list_1.Count - 1; index >= 0; --index)
        {
          Class124.Class139 class139 = this.list_1[index];
          if (this.class131_0.Compare(e, class139) < 0)
          {
            if (!class139.Edge.IsHorizontal && (int) e.Type == (int) class139.Type)
              e.method_6(class139);
          }
          else
          {
            this.list_1.Insert(index + 1, e);
            flag = true;
            break;
          }
        }
        if (flag)
          return;
        this.list_1.Insert(0, e);
      }

      private void method_22(
        Class124.Class139 e,
        bool equalTypeOddEdgeCount,
        bool unequalTypeOddEdgeCount,
        ref Class124.Class134 outputPolygonRef)
      {
        if (e.SideAbove == (byte) 0 && e.BelongsToPolygon)
          e.SideAbove = equalTypeOddEdgeCount ? (byte) 2 : (byte) 1;
        if (e.BelongsToPolygon)
        {
          if (!unequalTypeOddEdgeCount)
            return;
          double xbottom = e.Edge.XBottom;
          if (outputPolygonRef == null)
          {
            outputPolygonRef = new Class124.Class134()
            {
              class133_0 = new Class124.Class133()
            };
            outputPolygonRef.class133_0.AddFirst(new Point2D(xbottom, this.double_0));
            e.ResultPolygonRef = outputPolygonRef;
          }
          else
          {
            if (xbottom != outputPolygonRef.class133_0.First.Value.X)
            {
              Point2D point2D = new Point2D(xbottom, this.double_0);
              e.linkedListNode_0 = outputPolygonRef.class133_0.AddFirst(point2D);
            }
            e.ResultPolygonRef = outputPolygonRef;
          }
        }
        else
        {
          if (!unequalTypeOddEdgeCount)
            return;
          double xbottom = e.Edge.XBottom;
          if (e.ResultPolygon == null)
            e.ResultPolygonRef = new Class124.Class134()
            {
              class133_0 = new Class124.Class133()
            };
          e.linkedListNode_0 = e.ResultPolygon.AddLast(new Point2D(xbottom, this.double_0));
        }
      }

      private void method_23()
      {
        if (this.list_0.Count == 0)
          return;
        bool flag = this.method_5();
        for (int index1 = 0; index1 < this.list_0.Count; ++index1)
        {
          Class124.Class139 class139_1 = this.list_0[index1];
          if (class139_1.Edge.YTop == this.double_1)
          {
            if (class139_1.Successor == null)
            {
              int index2 = index1;
              int index3 = index1 + 1;
              if (class139_1.ResultPolygon != null && index3 < this.list_0.Count)
              {
                Class124.Class139 nextEdge = this.list_0[index3];
                this.method_34(class139_1, nextEdge, class139_1.Edge.Top, new Point2D(nextEdge.XScanbeamTopIntersection, this.double_1));
                if (nextEdge.Edge.YTop == this.double_1)
                {
                  this.list_0.RemoveAt(index3);
                  nextEdge.Edge = (Class124.Class136) null;
                }
                else
                  ++index1;
              }
              this.list_0.RemoveAt(index2);
              class139_1.Edge = (Class124.Class136) null;
              --index1;
            }
            else if (class139_1.SideBelow == (byte) 1)
            {
              if (class139_1.ResultPolygon != null)
              {
                class139_1.method_0(class139_1.Edge.Top);
                if (class139_1.Edge.XTop != class139_1.Successor.XBottom)
                  class139_1.method_0(class139_1.Successor.Bottom);
              }
              class139_1.Edge = class139_1.Successor;
              class139_1.XScanbeamBottomIntersection = class139_1.Edge.XBottom;
            }
            else if (class139_1.SideBelow == (byte) 2)
            {
              if (class139_1.ResultPolygon != null)
              {
                class139_1.method_2(class139_1.Edge.Top);
                if (class139_1.Edge.XTop != class139_1.Successor.XBottom)
                  class139_1.method_2(class139_1.Successor.Bottom);
              }
              class139_1.Edge = class139_1.Successor;
              class139_1.XScanbeamBottomIntersection = class139_1.Edge.XBottom;
            }
          }
          else if (class139_1.IntersectsWithHorizontalEdge)
          {
            int index2 = index1 + 1;
            if (index2 < this.list_0.Count)
            {
              Class124.Class139 class139_2 = this.list_0[index2];
              if (class139_1.ResultPolygon == null)
              {
                this.method_29(class139_1, class139_2, class139_1.Edge.Bottom, class139_2.Edge.Bottom);
                ++index1;
              }
              else
              {
                this.method_34(class139_1, class139_2, new Point2D(class139_1.XScanbeamTopIntersection, this.double_1), new Point2D(class139_2.XScanbeamTopIntersection, this.double_1));
                if (class139_2.Edge.YTop == this.double_1)
                {
                  this.list_0.RemoveAt(index2);
                  class139_2.Edge = (Class124.Class136) null;
                }
                else
                  ++index1;
              }
            }
          }
          else
            class139_1.XScanbeamBottomIntersection = class139_1.XScanbeamTopIntersection;
        }
        if (!flag)
          return;
        this.method_7();
      }

      public bool method_24(Class124.Class125 localMinimum)
      {
        bool horizontalEdgesAdded = false;
        Class124.Class139 edge1 = this.method_25(localMinimum, localMinimum.Left, ref horizontalEdgesAdded);
        Class124.Class139 edge2 = this.method_25(localMinimum, localMinimum.Right, ref horizontalEdgesAdded);
        if (localMinimum.BelongsToPolygon)
        {
          if (this.enum5_0 == Class124.Enum5.const_1)
          {
            edge1.SideBelow = (byte) 1;
            edge2.SideBelow = (byte) 2;
          }
        }
        else
        {
          edge1.SideBelow = (byte) 3;
          edge2.SideBelow = (byte) 3;
        }
        this.class30_0.Add((Class124.Class126) new Class124.Class128(this.class30_0, edge1));
        if (edge2 != null)
          this.class30_0.Add((Class124.Class126) new Class124.Class128(this.class30_0, edge2));
        return horizontalEdgesAdded;
      }

      private Class124.Class139 method_25(
        Class124.Class125 localMinimum,
        Class124.Class136 edge,
        ref bool horizontalEdgesAdded)
      {
        Class124.Class139 class139 = (Class124.Class139) null;
        Class124.Class139 predecessor = (Class124.Class139) null;
        for (; edge.IsHorizontal; edge = edge.Successor)
        {
          if (localMinimum.Type == (byte) 2)
          {
            predecessor = this.method_26(localMinimum, edge, predecessor);
            horizontalEdgesAdded = true;
          }
        }
        if (edge != null)
        {
          class139 = new Class124.Class139(localMinimum)
          {
            Edge = edge
          };
          class139.method_7(this.double_0);
          int index = this.list_0.BinarySearch(class139, (IComparer<Class124.Class139>) this.class131_0);
          if (index < 0)
            index = ~index;
          this.list_0.Insert(index, class139);
        }
        return class139;
      }

      private Class124.Class139 method_26(
        Class124.Class125 localMinimum,
        Class124.Class136 edge,
        Class124.Class139 predecessor)
      {
        Class124.Class139 class139 = new Class124.Class139(localMinimum) { Edge = edge };
        class139.XScanbeamTopIntersection = System.Math.Min(edge.XTop, edge.XBottom);
        int index = this.list_0.BinarySearch(class139, (IComparer<Class124.Class139>) this.class132_0);
        if (index < 0)
          index = ~index;
        this.list_0.Insert(index, class139);
        if (predecessor != null)
          predecessor.ActiveSuccessor = class139;
        return class139;
      }

      public void method_27(Class124.Class128 successorEvent)
      {
        Class124.Class136 edge = successorEvent.Edge.Edge;
        if (edge == null)
          return;
        successorEvent.Y = edge.YTop;
        this.class30_0.Add((Class124.Class126) successorEvent);
      }

      public Class124.Class133 method_28(
        Class124.Class139 left,
        Class124.Class139 right,
        Point2D p)
      {
        Class124.Class133 class133 = new Class124.Class133();
        Class124.Class134 class134 = new Class124.Class134() { class133_0 = class133 };
        class133.AddLast(p);
        left.ResultPolygonRef = class134;
        right.ResultPolygonRef = class134;
        return class133;
      }

      public Class124.Class133 method_29(
        Class124.Class139 left,
        Class124.Class139 right,
        Point2D pLeft,
        Point2D pRight)
      {
        Class124.Class133 class133 = new Class124.Class133();
        Class124.Class134 class134 = new Class124.Class134() { class133_0 = class133 };
        class133.AddLast(pLeft);
        if (pLeft.X != pRight.X)
          class133.AddLast(pRight);
        left.ResultPolygonRef = class134;
        right.ResultPolygonRef = class134;
        return class133;
      }

      public void method_30(Class124.Class139 edge1, Class124.Class139 edge2)
      {
        if (edge1.SideBelow == (byte) 1)
        {
          if (edge2.SideBelow == (byte) 1)
          {
            foreach (Point2D p in (LinkedList<Point2D>) edge2.ResultPolygon)
              edge1.method_0(p);
          }
          else
          {
            for (LinkedListNode<Point2D> linkedListNode = edge2.ResultPolygon.Last; linkedListNode != null; linkedListNode = linkedListNode.Previous)
              edge1.method_0(linkedListNode.Value);
          }
        }
        else if (edge2.SideBelow == (byte) 1)
        {
          foreach (Point2D p in (LinkedList<Point2D>) edge2.ResultPolygon)
            edge1.method_2(p);
        }
        else
        {
          for (LinkedListNode<Point2D> linkedListNode = edge2.ResultPolygon.Last; linkedListNode != null; linkedListNode = linkedListNode.Previous)
            edge1.method_2(linkedListNode.Value);
        }
        this.method_31(edge2, edge1.ResultPolygonRef, edge1.linkedListNode_0);
      }

      private void method_31(
        Class124.Class139 edge,
        Class124.Class134 polygonRef,
        LinkedListNode<Point2D> currentPolygonNode)
      {
        Class124.Class134 resultPolygonRef = edge.ResultPolygonRef;
        edge.ResultPolygonRef = polygonRef;
        Class124.Class139 activeSuccessor = edge.ActiveSuccessor;
        Class124.Class139 class139 = (Class124.Class139) null;
        for (; activeSuccessor != null; activeSuccessor = activeSuccessor.ActiveSuccessor)
        {
          if (activeSuccessor.ResultPolygonRef == resultPolygonRef)
            class139 = activeSuccessor;
          else
            break;
        }
        if (class139 == null)
          return;
        class139.ResultPolygonRef = polygonRef;
        class139.linkedListNode_0 = currentPolygonNode;
      }

      public void method_32(Class124.Class139 edge1, Class124.Class139 edge2)
      {
        Class124.Class133 resultPolygon = edge1.ResultPolygon;
        for (LinkedListNode<Point2D> linkedListNode = edge2.ResultPolygon.Last; linkedListNode != null; linkedListNode = linkedListNode.Previous)
          resultPolygon.AddFirst(linkedListNode.Value);
        edge2.ResultPolygon = resultPolygon;
      }

      private static void smethod_2(Class124.Class133 p, Point2D startPoint, Point2D endPoint)
      {
        if (p.Last.Value == endPoint && p.Last.Previous != null && p.Last.Previous.Value == startPoint)
          p.RemoveLast();
        else
          p.RemoveFirst();
      }

      public void method_33(Class124.Class139 edge, Class124.Class139 nextEdge, Point2D p)
      {
        edge.method_0(p);
        this.method_35(edge, nextEdge);
      }

      public void method_34(
        Class124.Class139 edge,
        Class124.Class139 nextEdge,
        Point2D left,
        Point2D right)
      {
        edge.method_0(left);
        if (right.X != left.X)
          nextEdge.method_2(right);
        this.method_35(edge, nextEdge);
      }

      private void method_35(Class124.Class139 edge, Class124.Class139 nextEdge)
      {
        if (edge.ResultPolygon != null && nextEdge.ResultPolygon != null)
        {
          if (edge.ResultPolygon != nextEdge.ResultPolygon)
            this.method_32(edge, nextEdge);
          else
            this.list_3.Add(edge.ResultPolygon);
        }
        edge.ResultPolygonRef = new Class124.Class134();
        nextEdge.ResultPolygonRef = new Class124.Class134();
      }

      internal class Class131 : IComparer<Class124.Class139>
      {
        public int Compare(Class124.Class139 a, Class124.Class139 b)
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

      internal class Class132 : IComparer<Class124.Class139>
      {
        public int Compare(Class124.Class139 a, Class124.Class139 b)
        {
          double xscanbeamTopIntersection1 = a.XScanbeamTopIntersection;
          double xscanbeamTopIntersection2 = b.XScanbeamTopIntersection;
          if (xscanbeamTopIntersection1 < xscanbeamTopIntersection2)
            return -1;
          if (xscanbeamTopIntersection1 > xscanbeamTopIntersection2)
            return 1;
          return Vector2D.CompareAngles(b.Edge.NegativeSlopeVector, a.Edge.NegativeSlopeVector);
        }
      }
    }

    internal class Class133 : LinkedList<Point2D>
    {
      public Polygon2D method_0()
      {
        return new Polygon2D((IEnumerable<Point2D>) this);
      }
    }

    internal class Class134
    {
      public Class124.Class133 class133_0;
    }

    internal class Class135
    {
      private Point2D point2D_0;
      private Class124.Class135 class135_0;

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

      public Class124.Class135 Next
      {
        get
        {
          return this.class135_0;
        }
        set
        {
          this.class135_0 = value;
        }
      }
    }

    internal abstract class Class136
    {
      protected double double_0;
      protected double double_1;
      protected Class124.Class136 class136_0;

      public static Class124.Class136 smethod_0(
        double x0,
        double y0,
        double x1,
        double y1)
      {
        if (y0 == y1)
          return (Class124.Class136) new Class124.Class138(x0, y0, x1);
        return (Class124.Class136) new Class124.Class137(x0, y0, x1, y1);
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

      public bool IsXDirNonNegative
      {
        get
        {
          return this.double_1 >= this.double_0;
        }
      }

      public abstract double YTop { get; }

      public abstract double YBottom { get; }

      public abstract bool IsHorizontal { get; }

      public abstract Point2D Bottom { get; }

      public abstract Point2D Top { get; }

      public abstract Vector2D SlopeVector { get; }

      public abstract Vector2D NegativeSlopeVector { get; }

      public Class124.Class136 Successor
      {
        get
        {
          return this.class136_0;
        }
        set
        {
          this.class136_0 = value;
        }
      }

      public Class124.Class136 method_0()
      {
        return Class124.Class136.smethod_1(this);
      }

      public static Class124.Class136 smethod_1(Class124.Class136 e)
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

    internal class Class137 : Class124.Class136
    {
      private double double_2;
      protected double double_3;
      protected double double_4;

      public Class137(double x0, double y0, double x1, double y1)
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

      public override Vector2D NegativeSlopeVector
      {
        get
        {
          return new Vector2D(-this.double_2, -1.0);
        }
      }

      public override string ToString()
      {
        return string.Format("xBottom = {0}, yTop = {1}, dx (slope) = {2}", (object) this.double_0, (object) this.double_4, (object) this.double_2);
      }
    }

    internal class Class138 : Class124.Class136
    {
      private double double_2;
      private double double_3;

      public Class138(double x0, double y0, double x1)
      {
        if (x0 <= x1)
        {
          this.double_0 = x0;
          this.double_1 = x1;
        }
        else
        {
          this.double_0 = x1;
          this.double_1 = x0;
        }
        this.double_3 = y0;
        this.double_2 = this.double_1 - this.double_0;
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

      public override Vector2D NegativeSlopeVector
      {
        get
        {
          return Vector2D.XAxis;
        }
      }

      internal void method_2(Class124.Class138 e)
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
        return string.Format("xBottom = {0}, yTop = {1}, dx = {2}", (object) this.double_0, (object) this.double_3, (object) this.double_2);
      }
    }

    internal class Class139
    {
      private Class124.Class134 class134_0 = new Class124.Class134();
      private Class124.Class136 class136_0;
      protected byte byte_0;
      private bool bool_0;
      protected byte byte_1;
      protected byte byte_2;
      private double double_0;
      private double double_1;
      private double double_2;
      private double double_3;
      private Class124.Class139 class139_0;
      private Class124.Class139 class139_1;
      private bool bool_1;
      private Class124.Class136 class136_1;
      public LinkedListNode<Point2D> linkedListNode_0;
      private Class124.Class139 class139_2;

      public Class139(Class124.Class125 localMinimum)
      {
        this.byte_0 = localMinimum.Type;
        this.bool_0 = localMinimum.BelongsToPolygon;
      }

      private Class139(Class124.Class136 edge)
      {
        this.class136_0 = edge;
      }

      public Class124.Class136 Edge
      {
        get
        {
          return this.class136_0;
        }
        set
        {
          this.class136_0 = value;
          if (this.class136_0 == null)
          {
            this.class136_1 = (Class124.Class136) null;
            this.double_3 = double.NaN;
          }
          else
          {
            this.double_3 = this.class136_0.XTop;
            for (this.class136_1 = this.class136_0.Successor; this.class136_1 != null && this.class136_1.IsHorizontal; this.class136_1 = this.class136_1.Successor)
              this.double_3 = this.class136_1.XTop;
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

      public bool BelongsToPolygon
      {
        get
        {
          return this.bool_0;
        }
      }

      public byte SideBelow
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

      public byte SideAbove
      {
        get
        {
          return this.byte_2;
        }
        set
        {
          this.byte_2 = value;
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

      public Class124.Class139 Previous
      {
        get
        {
          return this.class139_0;
        }
        set
        {
          this.class139_0 = value;
        }
      }

      public Class124.Class139 Next
      {
        get
        {
          return this.class139_1;
        }
        set
        {
          this.class139_1 = value;
        }
      }

      public bool IntersectsWithHorizontalEdge
      {
        get
        {
          return this.bool_1;
        }
        set
        {
          this.bool_1 = value;
        }
      }

      public Class124.Class139 ActiveSuccessor
      {
        get
        {
          return this.class139_2;
        }
        set
        {
          this.class139_2 = value;
        }
      }

      public Class124.Class136 Successor
      {
        get
        {
          return this.class136_1;
        }
      }

      public Class124.Class133 ResultPolygon
      {
        get
        {
          return this.class134_0.class133_0;
        }
        set
        {
          this.class134_0.class133_0 = value;
        }
      }

      public Class124.Class134 ResultPolygonRef
      {
        get
        {
          return this.class134_0;
        }
        set
        {
          this.class134_0 = value;
        }
      }

      public void method_0(Point2D p)
      {
        this.linkedListNode_0 = this.ResultPolygon.AddBefore(this.linkedListNode_0, p);
      }

      public void method_1(Point2D p)
      {
        if (this.ResultPolygon.Count != 0 && !(this.ResultPolygon.First.Value != p))
          return;
        this.method_0(p);
      }

      public void method_2(Point2D p)
      {
        this.linkedListNode_0 = this.ResultPolygon.AddAfter(this.linkedListNode_0, p);
      }

      public void method_3(Point2D p)
      {
        if (this.ResultPolygon.Count != 0 && !(this.ResultPolygon.Last.Value != p))
          return;
        this.ResultPolygon.AddLast(p);
      }

      public void method_4(Point2D p)
      {
        if (this.byte_1 == (byte) 1)
          this.method_0(p);
        else
          this.method_2(p);
      }

      public void method_5(Class124.Class139 edge)
      {
        byte byte1 = edge.byte_1;
        edge.byte_1 = this.byte_1;
        this.byte_1 = byte1;
      }

      public void method_6(Class124.Class139 edge)
      {
        byte byte2 = edge.byte_2;
        edge.byte_2 = this.byte_2;
        this.byte_2 = byte2;
      }

      public void method_7(double y)
      {
        this.double_0 = this.class136_0.vmethod_0(y);
      }

      public void method_8(double y)
      {
        this.double_1 = this.class136_0.vmethod_0(y);
      }

      public void method_9(double yTop)
      {
        this.double_2 = this.class136_0.YTop == yTop ? this.double_3 : this.double_1;
      }

      public Class124.Class139 method_10(Class124.Class136 successor)
      {
        Class124.Class139 class139 = new Class124.Class139(successor) { bool_0 = this.bool_0, byte_0 = this.byte_0, byte_2 = this.byte_2, byte_1 = this.byte_1 };
        this.class139_2 = class139;
        return class139;
      }

      public override string ToString()
      {
        return string.Format("xBottomIntersect {0} xTopIntersect {1} side {2} edge {3}", (object) this.double_0, (object) this.double_1, (object) this.byte_1, (object) this.class136_0);
      }
    }

    internal class Class140 : IComparable<Class124.Class140>
    {
      private Point2D point2D_0;
      private Class124.Class139 class139_0;
      private Class124.Class139 class139_1;

      public Class140(Class124.Class139 edge0, Class124.Class139 edge1, Point2D position)
      {
        this.class139_0 = edge0;
        this.class139_1 = edge1;
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

      public Class124.Class139 Edge0
      {
        get
        {
          return this.class139_0;
        }
        set
        {
          this.class139_0 = value;
        }
      }

      public Class124.Class139 Edge1
      {
        get
        {
          return this.class139_1;
        }
        set
        {
          this.class139_1 = value;
        }
      }

      public Class124.Enum6 method_0()
      {
        Class124.Enum6 enum6;
        if ((int) this.class139_0.Type == (int) this.class139_1.Type)
        {
          if ((int) this.class139_0.SideBelow == (int) this.class139_1.SideBelow)
            throw new Exception("Invalid intersection.");
          enum6 = Class124.Enum6.const_3;
        }
        else
          enum6 = (int) this.class139_0.SideBelow != (int) this.class139_1.SideBelow ? (this.class139_1.SideBelow != (byte) 1 ? Class124.Enum6.const_5 : Class124.Enum6.const_4) : (this.class139_1.SideBelow != (byte) 1 ? Class124.Enum6.const_2 : Class124.Enum6.const_1);
        return enum6;
      }

      public int CompareTo(Class124.Class140 other)
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
        return string.Format("pos: {0} edge0: {1}, edge1: {2}", (object) this.point2D_0, (object) this.class139_0, (object) this.class139_1);
      }
    }

    internal class Class31 : RedBlackTree<Class124.Class141>
    {
    }

    internal class Class141 : IComparable<Class124.Class141>
    {
      private double double_0;
      private Class124.Class139 class139_0;
      private Class124.Class139 class139_1;
      private Class124.Class141 class141_0;

      public int CompareTo(Class124.Class141 other)
      {
        return MathUtil.Compare(this.double_0, other.double_0);
      }

      internal class Class142 : Class124.Class141
      {
      }

      internal class Class143 : Class124.Class141
      {
      }

      internal class Class144 : Class124.Class141
      {
      }
    }

    public enum Enum5
    {
      const_0,
      const_1,
    }

    public enum Enum6
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
