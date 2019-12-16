// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.VattiClipper2I
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using WW.Collections.Generic;

namespace WW.Math.Exact.Geometry
{
  public class VattiClipper2I
  {
    public static void Clip(
      IList<Polygon2I> clip,
      IList<Polygon2I> subject,
      VattiClipper2I.PolygonFillMode fillMode)
    {
      List<VattiClipper2I.Class191> localMinimumList = new List<VattiClipper2I.Class191>();
      foreach (Polygon2I polygon in (IEnumerable<Polygon2I>) clip)
        VattiClipper2I.smethod_0(polygon, (byte) 1, localMinimumList);
      foreach (Polygon2I polygon in (IEnumerable<Polygon2I>) subject)
        VattiClipper2I.smethod_0(polygon, (byte) 2, localMinimumList);
      localMinimumList.Sort();
      VattiClipper2I.Class191 localMinimum = (VattiClipper2I.Class191) null;
      if (localMinimumList.Count > 1)
      {
        VattiClipper2I.Class191 class191_1 = localMinimumList[localMinimumList.Count - 1];
        for (int index = localMinimumList.Count - 2; index >= 0; --index)
        {
          VattiClipper2I.Class191 class191_2 = localMinimumList[index];
          class191_2.Next = class191_1;
          class191_1 = class191_2;
        }
        localMinimum = class191_1;
      }
      VattiClipper2I.Class195 class195 = new VattiClipper2I.Class195();
      if (localMinimum == null)
        return;
      class195.EventQueue.Add(localMinimum);
    }

    internal static void smethod_0(
      Polygon2I polygon,
      byte type,
      List<VattiClipper2I.Class191> localMinimumList)
    {
      if (polygon.Count == 0)
        return;
      Point2I point2I1 = polygon[polygon.Count - 1];
      Point2I p = polygon[0];
      VattiClipper2I.Class199 class199_1 = new VattiClipper2I.Class199(point2I1.X, point2I1.Y, p.X, p.Y) { Type = type };
      VattiClipper2I.Class199 e0 = class199_1;
      int num1 = System.Math.Sign(p.Y - point2I1.Y);
      bool flag1 = false;
      if (num1 == 0)
      {
        flag1 = true;
        for (int index = polygon.Count - 2; index > 0; --index)
        {
          num1 = System.Math.Sign(p.Y - polygon[index].Y);
          if (num1 != 0)
            break;
        }
      }
      class199_1.XBottom = num1 < 0 ? p.X : point2I1.X;
      for (int index = 1; index < polygon.Count; ++index)
      {
        Point2I point2I2 = polygon[index];
        VattiClipper2I.Class199 class199_2 = new VattiClipper2I.Class199(p.X, p.Y, point2I2.X, point2I2.Y) { Type = type };
        int num2 = System.Math.Sign(point2I2.Y - p.Y);
        bool flag2 = false;
        if (num2 == 0)
        {
          flag2 = true;
          num2 = num1;
          if (flag1)
          {
            e0.method_2(class199_2);
            class199_2 = e0;
          }
          else if (num2 > 0)
          {
            e0.Successor = class199_2;
            class199_2.XBottom = p.X;
          }
          else
          {
            class199_2.Successor = e0;
            class199_2.XBottom = point2I2.X;
          }
        }
        else if (num2 == num1)
        {
          if (num2 > 0)
          {
            e0.Successor = class199_2;
            class199_2.XBottom = p.X;
          }
          else
          {
            class199_2.Successor = e0;
            class199_2.XBottom = point2I2.X;
          }
        }
        else if (num2 > 0 && num1 < 0)
          VattiClipper2I.smethod_1(p, localMinimumList, e0, class199_2);
        else if (num2 < 0 && num1 > 0)
          class199_2.XBottom = point2I2.X;
        num1 = num2;
        flag1 = flag2;
        p = point2I2;
        e0 = class199_2;
      }
      Point2I point2I3 = polygon[0];
      VattiClipper2I.Class199 class199_3 = class199_1;
      int num3 = System.Math.Sign(point2I3.Y - p.Y);
      if (num3 == 0)
      {
        int num2 = num1;
        if (flag1)
          e0.method_2(class199_3);
        else if (num2 > 0)
        {
          e0.Successor = class199_3;
          class199_3.XBottom = p.X;
        }
        else
        {
          class199_3.Successor = e0;
          class199_3.XBottom = point2I3.X;
        }
      }
      else if (num3 == num1)
      {
        if (num3 > 0)
        {
          e0.Successor = class199_3;
          class199_3.XBottom = p.X;
        }
        else
        {
          class199_3.Successor = e0;
          class199_3.XBottom = point2I3.X;
        }
      }
      else if (num3 > 0 && num1 < 0)
        VattiClipper2I.smethod_1(p, localMinimumList, e0, class199_3);
      else if (num3 < 0)
        ;
    }

    private static void smethod_1(
      Point2I p,
      List<VattiClipper2I.Class191> localMinimumList,
      VattiClipper2I.Class199 e0,
      VattiClipper2I.Class199 e1)
    {
      VattiClipper2I.Class191 class191 = new VattiClipper2I.Class191() { Y = p.Y };
      localMinimumList.Add(class191);
      VattiClipper2I.Class199 class199_1;
      VattiClipper2I.Class199 class199_2;
      if (Vector2I.CompareAngles(new Vector2I(e0.Dx, e0.Dy), new Vector2I(e1.Dx, e1.Dy)) <= 0)
      {
        class199_1 = e1;
        class199_2 = e0;
      }
      else
      {
        class199_1 = e0;
        class199_2 = e1;
      }
      if (class199_1.Dy == 0)
      {
        class191.Left = class199_1.Successor;
        class199_1.Successor = class199_2;
        class199_1.method_3();
        class191.Right = class199_1;
      }
      else
      {
        class191.Left = class199_1;
        class191.Right = class199_2;
      }
      e1.XBottom = p.X;
    }

    internal class Class191 : IComparable<VattiClipper2I.Class191>
    {
      private int int_0;
      private VattiClipper2I.Class199 class199_0;
      private VattiClipper2I.Class199 class199_1;
      private VattiClipper2I.Class191 class191_0;

      public int Y
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

      public VattiClipper2I.Class199 Left
      {
        get
        {
          return this.class199_0;
        }
        set
        {
          this.class199_0 = value;
        }
      }

      public VattiClipper2I.Class199 Right
      {
        get
        {
          return this.class199_1;
        }
        set
        {
          this.class199_1 = value;
        }
      }

      public VattiClipper2I.Class191 Next
      {
        get
        {
          return this.class191_0;
        }
        set
        {
          this.class191_0 = value;
        }
      }

      public int CompareTo(VattiClipper2I.Class191 other)
      {
        return this.int_0 - other.int_0;
      }
    }

    internal class Class35 : RedBlackTree<VattiClipper2I.Class192>
    {
      public void Add(VattiClipper2I.Class191 localMinimum)
      {
        this.Add((VattiClipper2I.Class192) new VattiClipper2I.Class193(localMinimum));
        while (localMinimum.Next != null && localMinimum.Y == localMinimum.Next.Y)
        {
          localMinimum = localMinimum.Next;
          this.Add((VattiClipper2I.Class192) new VattiClipper2I.Class193(localMinimum));
        }
      }

      public VattiClipper2I.Class192 method_4()
      {
        if (this.Count == 0)
          return (VattiClipper2I.Class192) null;
        RedBlackTree<VattiClipper2I.Class192>.Node leftMost = this.Root.GetLeftMost();
        this.Remove(leftMost);
        return leftMost.Value;
      }
    }

    internal abstract class Class192 : IComparable<VattiClipper2I.Class192>
    {
      private int int_0;

      protected Class192(int y)
      {
        this.int_0 = y;
      }

      public int Y
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

      public int CompareTo(VattiClipper2I.Class192 other)
      {
        if (this.int_0 < other.int_0)
          return -1;
        if (this.int_0 > other.int_0)
          return 1;
        if (this.Order < other.Order)
          return -1;
        return this.Order > other.Order ? 1 : 0;
      }

      public abstract int Order { get; }

      public virtual void vmethod_0(
        VattiClipper2I.Class35 eventQueue,
        VattiClipper2I.Class195 scanBeam)
      {
      }
    }

    internal class Class193 : VattiClipper2I.Class192
    {
      private VattiClipper2I.Class191 class191_0;

      public Class193(VattiClipper2I.Class191 localMinimum)
        : base(localMinimum.Y)
      {
        this.class191_0 = localMinimum;
      }

      public VattiClipper2I.Class191 LocalMinimum
      {
        get
        {
          return this.class191_0;
        }
        set
        {
          this.class191_0 = value;
        }
      }

      public override int Order
      {
        get
        {
          return 1;
        }
      }

      public override void vmethod_0(
        VattiClipper2I.Class35 eventQueue,
        VattiClipper2I.Class195 scanBeam)
      {
        scanBeam.method_1(this.class191_0);
        for (VattiClipper2I.Class191 localMinimum = this.class191_0; localMinimum.Next != null; localMinimum = localMinimum.Next)
        {
          if (localMinimum.Y == localMinimum.Next.Y)
          {
            scanBeam.method_1(localMinimum);
          }
          else
          {
            scanBeam.EventQueue.Add(localMinimum.Next);
            break;
          }
        }
        bool flag1 = false;
        bool flag2 = false;
        VattiClipper2I.Class197 outputPolygon = (VattiClipper2I.Class197) null;
        for (int index = 0; index < scanBeam.ActiveEdges.Count; ++index)
        {
          VattiClipper2I.Class200 activeEdge = scanBeam.ActiveEdges[index];
          if (activeEdge.Edge.Type == (byte) 1)
          {
            this.method_0(activeEdge, flag1, flag2, ref outputPolygon);
            flag1 = !flag1;
          }
          else
          {
            this.method_0(activeEdge, flag2, flag1, ref outputPolygon);
            flag2 = !flag2;
          }
        }
      }

      private void method_0(
        VattiClipper2I.Class200 e,
        bool oddEqualTypeEdgeCount,
        bool oddUnequalTypeEdgeCount,
        ref VattiClipper2I.Class197 outputPolygon)
      {
        if (e.Edge.Side == (byte) 0)
        {
          e.Edge.Side = oddEqualTypeEdgeCount ? (byte) 1 : (byte) 2;
          if (!oddUnequalTypeEdgeCount)
            return;
          if (outputPolygon == null)
          {
            outputPolygon = new VattiClipper2I.Class197();
            outputPolygon.AddFirst(new Point2I(e.Edge.XBottom, this.class191_0.Y));
            e.ResultPolygon = outputPolygon;
          }
          else
          {
            if (e.Edge.XBottom != outputPolygon.First.Value.X)
              outputPolygon.AddLast(new Point2I(e.Edge.XBottom, this.class191_0.Y));
            e.ResultPolygon = outputPolygon;
            outputPolygon = (VattiClipper2I.Class197) null;
          }
        }
        else
        {
          if (!oddUnequalTypeEdgeCount)
            return;
          int x = (int) System.Math.Round(e.Edge.method_1(this.class191_0.Y));
          if (outputPolygon == null)
          {
            outputPolygon = new VattiClipper2I.Class197();
            outputPolygon.AddFirst(new Point2I(x, this.class191_0.Y));
          }
          else
          {
            if (x != outputPolygon.First.Value.X)
              outputPolygon.AddLast(new Point2I(x, this.class191_0.Y));
            outputPolygon = (VattiClipper2I.Class197) null;
          }
        }
      }
    }

    internal class Class194 : VattiClipper2I.Class192
    {
      private VattiClipper2I.Class200 class200_0;

      public Class194(VattiClipper2I.Class200 edge)
        : base(edge.Edge.YTop)
      {
        this.class200_0 = edge;
      }

      public VattiClipper2I.Class200 Edge
      {
        get
        {
          return this.class200_0;
        }
        set
        {
          this.class200_0 = value;
        }
      }

      public override int Order
      {
        get
        {
          return 0;
        }
      }

      public override void vmethod_0(
        VattiClipper2I.Class35 eventQueue,
        VattiClipper2I.Class195 scanBeam)
      {
        scanBeam.method_2(this.class200_0);
      }
    }

    internal class Class195
    {
      private VattiClipper2I.Class35 class35_0 = new VattiClipper2I.Class35();
      private List<VattiClipper2I.Class200> list_0 = new List<VattiClipper2I.Class200>();
      private VattiClipper2I.Class195.Class196 class196_0 = new VattiClipper2I.Class195.Class196();
      private int int_0;
      private int int_1;

      public VattiClipper2I.Class35 EventQueue
      {
        get
        {
          return this.class35_0;
        }
        set
        {
          this.class35_0 = value;
        }
      }

      public int Bottom
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

      public int Top
      {
        get
        {
          return this.int_1;
        }
        set
        {
          this.int_1 = value;
        }
      }

      public List<VattiClipper2I.Class200> ActiveEdges
      {
        get
        {
          return this.list_0;
        }
      }

      public void method_0()
      {
        VattiClipper2I.Class192 class192_1 = this.class35_0.method_4();
        while (class192_1 != null)
        {
          this.int_0 = class192_1.Y;
          VattiClipper2I.Class192 class192_2 = this.class35_0.method_4();
          if (class192_2 != null)
            this.int_1 = class192_2.Y;
          class192_1.vmethod_0(this.class35_0, this);
          class192_1 = class192_2;
          if (class192_1 == null || this.int_0 != class192_1.Y)
            this.method_3();
        }
      }

      public void method_1(VattiClipper2I.Class191 localMinimum)
      {
        this.class196_0.Y = this.int_0;
        VattiClipper2I.Class200 edge1 = new VattiClipper2I.Class200() { Edge = localMinimum.Left };
        this.list_0.Insert(this.list_0.BinarySearch(edge1, (IComparer<VattiClipper2I.Class200>) this.class196_0), edge1);
        VattiClipper2I.Class199 class199 = localMinimum.Right;
        while (class199.Dy == 0)
          class199 = class199.Successor;
        VattiClipper2I.Class200 edge2 = (VattiClipper2I.Class200) null;
        if (class199 != null)
        {
          edge2 = new VattiClipper2I.Class200()
          {
            Edge = class199
          };
          this.list_0.Insert(this.list_0.BinarySearch(edge2, (IComparer<VattiClipper2I.Class200>) this.class196_0), edge2);
        }
        this.class35_0.Add((VattiClipper2I.Class192) new VattiClipper2I.Class194(edge1));
        if (edge2 == null)
          return;
        this.class35_0.Add((VattiClipper2I.Class192) new VattiClipper2I.Class194(edge2));
      }

      public void method_2(VattiClipper2I.Class200 activeEdge)
      {
        if (activeEdge.Edge.Successor == null)
        {
          this.list_0.Remove(activeEdge);
        }
        else
        {
          VattiClipper2I.Class199 successor = activeEdge.Edge.Successor;
          while (successor != null && successor.Dy == 0)
            successor = activeEdge.Edge.Successor;
          if (successor == null)
          {
            this.list_0.Remove(activeEdge);
          }
          else
          {
            activeEdge.Edge = activeEdge.Edge.Successor;
            this.class35_0.Add((VattiClipper2I.Class192) new VattiClipper2I.Class194(activeEdge));
          }
        }
      }

      private void method_3()
      {
        VattiClipper2I.Class200 left = (VattiClipper2I.Class200) null;
        for (int index = 0; index < this.list_0.Count; ++index)
        {
          VattiClipper2I.Class200 right = this.list_0[index];
          if (right.Edge.YTop - right.Edge.Dy == this.int_0)
          {
            if (left == null)
            {
              if (right.Edge.Side == (byte) 1)
                left = right;
            }
            else if (right.Edge.Side == (byte) 2)
            {
              int xbottom = left.XBottom;
              if (left.Edge.Dy == 0)
                System.Math.Min(xbottom, xbottom + left.Edge.Dx);
              int num = right.XBottom;
              if (right.Edge.Dy == 0)
                num = System.Math.Min(num, num + right.Edge.Dx);
              this.method_4(left, right, new Point2I(num, this.int_0));
              left = (VattiClipper2I.Class200) null;
            }
          }
        }
      }

      public VattiClipper2I.Class197 method_4(
        VattiClipper2I.Class200 left,
        VattiClipper2I.Class200 right,
        Point2I p)
      {
        VattiClipper2I.Class198 class198 = new VattiClipper2I.Class198() { Position = p };
        VattiClipper2I.Class197 class197 = new VattiClipper2I.Class197() { Left = class198, Right = class198 };
        class197.AddLast(p);
        left.ResultPolygon = class197;
        right.ResultPolygon = class197;
        return class197;
      }

      public void method_5(VattiClipper2I.Class200 edge1, VattiClipper2I.Class200 edge2)
      {
        VattiClipper2I.Class197 resultPolygon1 = edge1.ResultPolygon;
        VattiClipper2I.Class197 resultPolygon2 = edge2.ResultPolygon;
        int num;
        for (num = Vector2I.CompareAngles(new Vector2I(edge1.Edge.Dx, edge1.Edge.Dy), new Vector2I(edge2.Edge.Dx, edge2.Edge.Dy)); num == 0 && (edge1.Previous != null && edge2.Previous != null); num = Vector2I.CompareAngles(new Vector2I(edge1.Edge.Dx, edge1.Edge.Dy), new Vector2I(edge2.Edge.Dx, edge2.Edge.Dy)))
        {
          Point2I endPoint = new Point2I(edge1.XBottom + edge1.Edge.Dx, edge1.Edge.YTop);
          Point2I startPoint1 = new Point2I(edge1.XBottom, edge1.Edge.YTop - edge1.Edge.Dy);
          VattiClipper2I.Class195.smethod_0(resultPolygon1, startPoint1, endPoint);
          Point2I startPoint2 = new Point2I(edge2.XBottom, edge2.Edge.YTop - edge2.Edge.Dy);
          VattiClipper2I.Class195.smethod_0(resultPolygon2, startPoint2, endPoint);
          edge1 = edge1.Previous;
          edge2 = edge2.Previous;
        }
        if (num < 0)
        {
          for (LinkedListNode<Point2I> linkedListNode = resultPolygon1.Last; linkedListNode != null; linkedListNode = linkedListNode.Previous)
            resultPolygon2.AddFirst(linkedListNode.Value);
        }
        else if (num >= 0)
        {
          foreach (Point2I point2I in (LinkedList<Point2I>) resultPolygon1)
            resultPolygon2.AddLast(point2I);
        }
        edge1.Previous.ResultPolygon = resultPolygon2;
      }

      private static void smethod_0(
        VattiClipper2I.Class197 p,
        Point2I startPoint,
        Point2I endPoint)
      {
        if (p.Last.Value == endPoint && p.Last.Previous != null && p.Last.Previous.Value == startPoint)
          p.RemoveLast();
        else
          p.RemoveFirst();
      }

      public void method_6(
        VattiClipper2I.Class200 edge,
        VattiClipper2I.Class200 nextEdge,
        Point2I p)
      {
        if (edge.Edge.Side == (byte) 1)
          edge.method_0(p);
        else if (edge.Edge.Side == (byte) 2)
          edge.method_1(p);
        if (edge.ResultPolygon == null || nextEdge.ResultPolygon == null || edge.ResultPolygon == nextEdge.ResultPolygon)
          return;
        this.method_5(edge, nextEdge);
      }

      internal class Class196 : IComparer<VattiClipper2I.Class200>
      {
        private int int_0;

        public int Y
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

        public int Compare(VattiClipper2I.Class200 a, VattiClipper2I.Class200 b)
        {
          double num1 = a.Edge.method_1(this.int_0);
          double num2 = b.Edge.method_1(this.int_0);
          if (num1 < num2)
            return -1;
          if (num1 > num2)
            return 1;
          return Vector2I.CompareAngles(new Vector2I(a.Edge.Dx, a.Edge.Dy), new Vector2I(b.Edge.Dx, b.Edge.Dy));
        }
      }
    }

    internal class Class197 : LinkedList<Point2I>
    {
      private VattiClipper2I.Class198 class198_0;
      private VattiClipper2I.Class198 class198_1;

      [Obsolete("TODO: Is this really needed?")]
      public VattiClipper2I.Class198 Left
      {
        get
        {
          return this.class198_0;
        }
        set
        {
          this.class198_0 = value;
        }
      }

      [Obsolete("TODO: Is this really needed?")]
      public VattiClipper2I.Class198 Right
      {
        get
        {
          return this.class198_1;
        }
        set
        {
          this.class198_1 = value;
        }
      }
    }

    internal class Class198
    {
      private Point2I point2I_0;
      private VattiClipper2I.Class198 class198_0;

      public Point2I Position
      {
        get
        {
          return this.point2I_0;
        }
        set
        {
          this.point2I_0 = value;
        }
      }

      public VattiClipper2I.Class198 Next
      {
        get
        {
          return this.class198_0;
        }
        set
        {
          this.class198_0 = value;
        }
      }
    }

    internal class Class199
    {
      private int int_0;
      private int int_1;
      private int int_2;
      private int int_3;
      private byte byte_0;
      private byte byte_1;
      private VattiClipper2I.Class199 class199_0;

      public Class199(int x0, int y0, int x1, int y1)
      {
        if (y0 <= y1)
        {
          this.int_0 = x0;
          this.int_1 = y1;
          this.int_2 = x1 - x0;
          this.int_3 = y1 - y0;
        }
        else
        {
          this.int_0 = x1;
          this.int_1 = y0;
          this.int_2 = x0 - x1;
          this.int_3 = y0 - y1;
        }
      }

      public int XBottom
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

      public int YTop
      {
        get
        {
          return this.int_1;
        }
        set
        {
          this.int_1 = value;
        }
      }

      public int Dx
      {
        get
        {
          return this.int_2;
        }
        set
        {
          this.int_2 = value;
        }
      }

      public int Dy
      {
        get
        {
          return this.int_3;
        }
        set
        {
          this.int_3 = value;
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

      public VattiClipper2I.Class199 Successor
      {
        get
        {
          return this.class199_0;
        }
        set
        {
          this.class199_0 = value;
        }
      }

      public VattiClipper2I.Class199 method_0()
      {
        return VattiClipper2I.Class199.smethod_0(this);
      }

      public static VattiClipper2I.Class199 smethod_0(VattiClipper2I.Class199 e)
      {
        while (e != null && e.Successor != null)
          e = e.Successor;
        return e;
      }

      public double method_1(int y)
      {
        double int0 = (double) this.int_0;
        if (this.int_3 == 0)
          return int0;
        return int0 + (double) ((y - (this.int_1 - this.int_3)) * this.int_2) / (double) this.int_3;
      }

      internal void method_2(VattiClipper2I.Class199 e)
      {
        this.int_2 += e.int_2;
      }

      internal void method_3()
      {
        this.int_0 += this.int_2;
        this.int_2 = -this.int_2;
      }

      public override string ToString()
      {
        return string.Format("type = {0}, xBottom = {1}, yTop = {2}, dx/dy = {3}/{4}, side = {5}", (object) this.byte_0, (object) this.int_0, (object) this.int_1, (object) this.int_2, (object) this.int_3, (object) this.byte_1);
      }
    }

    internal class Class200
    {
      private VattiClipper2I.Class199 class199_0;
      private int int_0;
      private VattiClipper2I.Class200 class200_0;
      private VattiClipper2I.Class200 class200_1;
      private VattiClipper2I.Class197 class197_0;

      public VattiClipper2I.Class199 Edge
      {
        get
        {
          return this.class199_0;
        }
        set
        {
          this.class199_0 = value;
        }
      }

      public int XBottom
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

      public VattiClipper2I.Class200 Previous
      {
        get
        {
          return this.class200_0;
        }
        set
        {
          this.class200_0 = value;
        }
      }

      public VattiClipper2I.Class200 Next
      {
        get
        {
          return this.class200_1;
        }
        set
        {
          this.class200_1 = value;
        }
      }

      public VattiClipper2I.Class197 ResultPolygon
      {
        get
        {
          return this.class197_0;
        }
        set
        {
          this.class197_0 = value;
        }
      }

      public void method_0(Point2I p)
      {
        VattiClipper2I.Class198 class198 = new VattiClipper2I.Class198() { Position = p };
        this.class197_0.Left.Next = class198;
        this.class197_0.Left = class198;
        this.class197_0.AddFirst(p);
      }

      public void method_1(Point2I p)
      {
        VattiClipper2I.Class198 class198 = new VattiClipper2I.Class198() { Position = p };
        this.class197_0.Right.Next = class198;
        this.class197_0.Right = class198;
        this.class197_0.AddLast(p);
      }
    }

    public enum PolygonFillMode
    {
      EvenOdd,
      NonZero,
    }
  }
}
