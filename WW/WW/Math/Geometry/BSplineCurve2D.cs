// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.BSplineCurve2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;

namespace WW.Math.Geometry
{
  public class BSplineCurve2D
  {
    private LinkedList<double> linkedList_0 = new LinkedList<double>();
    private LinkedList<Point2D> linkedList_1 = new LinkedList<Point2D>();
    private int int_0;

    public BSplineCurve2D()
    {
    }

    public BSplineCurve2D(int degree)
    {
      this.int_0 = degree;
    }

    public int Degree
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

    public LinkedList<double> Knots
    {
      get
      {
        return this.linkedList_0;
      }
      set
      {
        this.linkedList_0 = value;
      }
    }

    public LinkedList<Point2D> ControlPoints
    {
      get
      {
        return this.linkedList_1;
      }
      set
      {
        this.linkedList_1 = value;
      }
    }

    public void InsertKnot(double u)
    {
      LinkedListNode<double> linkedListNode1 = this.linkedList_0.First;
      LinkedListNode<double> linkedListNode2 = this.linkedList_0.Last;
      for (int index = 0; index < this.int_0; ++index)
      {
        linkedListNode1 = linkedListNode1.Next;
        linkedListNode2 = linkedListNode2.Previous;
      }
      LinkedListNode<Point2D> linkedListNode3 = this.linkedList_1.First;
      while (linkedListNode1 != null && (linkedListNode1.Value <= u && linkedListNode1.Value < linkedListNode2.Value))
      {
        linkedListNode1 = linkedListNode1.Next;
        linkedListNode3 = linkedListNode3.Next;
      }
      if (linkedListNode1 == null)
        return;
      LinkedListNode<double> linkedListNode4 = linkedListNode1;
      LinkedListNode<Point2D> previous = linkedListNode3.Previous;
      for (int index = 0; index < this.int_0; ++index)
        linkedListNode4 = linkedListNode4.Previous;
      double num1 = (u - linkedListNode4.Value) / (linkedListNode1.Value - linkedListNode4.Value);
      Vector2D vector2D1 = (1.0 - num1) * (Vector2D) previous.Value;
      LinkedListNode<Point2D> next1 = previous.Next;
      Vector2D vector2D2 = vector2D1 + num1 * (Vector2D) next1.Value;
      this.linkedList_1.AddBefore(next1, (Point2D) vector2D2);
      LinkedListNode<double> next2 = linkedListNode4.Next;
      LinkedListNode<double> next3 = linkedListNode1.Next;
      for (int index = 1; index < this.int_0; ++index)
      {
        double num2 = (u - next2.Value) / (next3.Value - next2.Value);
        Vector2D vector2D3 = (1.0 - num2) * (Vector2D) next1.Value;
        LinkedListNode<Point2D> linkedListNode5 = next1;
        next1 = next1.Next;
        Vector2D vector2D4 = vector2D3 + num2 * (Vector2D) next1.Value;
        linkedListNode5.Value = (Point2D) vector2D4;
        next2 = next2.Next;
        next3 = next3.Next;
      }
      this.linkedList_0.AddBefore(next2, u);
    }

    public void InsertKnot(
      LinkedListNode<double> previousKnot,
      LinkedListNode<Point2D> previousPoint,
      double u)
    {
      LinkedListNode<double> next1 = previousKnot.Next;
      for (int index = 1; index < this.int_0; ++index)
        previousKnot = previousKnot.Previous;
      double num1 = (u - previousKnot.Value) / (next1.Value - previousKnot.Value);
      Vector2D vector2D1 = (1.0 - num1) * (Vector2D) previousPoint.Value;
      previousPoint = previousPoint.Next;
      Vector2D vector2D2 = vector2D1 + num1 * (Vector2D) previousPoint.Value;
      this.linkedList_1.AddBefore(previousPoint, (Point2D) vector2D2);
      previousKnot = previousKnot.Next;
      LinkedListNode<double> next2 = next1.Next;
      for (int index = 1; index < this.int_0; ++index)
      {
        double num2 = (u - previousKnot.Value) / (next2.Value - previousKnot.Value);
        Vector2D vector2D3 = (1.0 - num2) * (Vector2D) previousPoint.Value;
        LinkedListNode<Point2D> linkedListNode = previousPoint;
        previousPoint = previousPoint.Next;
        Vector2D vector2D4 = vector2D3 + num2 * (Vector2D) previousPoint.Value;
        linkedListNode.Value = (Point2D) vector2D4;
        previousKnot = previousKnot.Next;
        next2 = next2.Next;
      }
      this.linkedList_0.AddBefore(previousKnot, u);
    }

    public void RefineKnots(double epsilon, int maxInsertsPerKnotSpan)
    {
      LinkedListNode<double> linkedListNode1 = this.linkedList_0.First;
      LinkedListNode<double> linkedListNode2 = this.linkedList_0.Last;
      for (int index = 0; index < this.int_0; ++index)
      {
        linkedListNode1 = linkedListNode1.Next;
        linkedListNode2 = linkedListNode2.Previous;
      }
      LinkedListNode<Point2D> segmentFirstPoint = this.linkedList_1.First;
      while (linkedListNode1.Value < linkedListNode2.Value)
      {
        while (linkedListNode1.Value == linkedListNode1.Next.Value)
        {
          linkedListNode1 = linkedListNode1.Next;
          segmentFirstPoint = segmentFirstPoint.Next;
        }
        LinkedListNode<Point2D> linkedListNode3 = segmentFirstPoint;
        for (int index = 0; index < this.int_0; ++index)
          linkedListNode3 = linkedListNode3.Next;
        Point2D segmentFirstPoint2D = segmentFirstPoint.Value;
        Point2D segmentLastPoint2D1 = linkedListNode3.Value;
        bool flag = this.method_0(epsilon, segmentLastPoint2D1, segmentFirstPoint2D, segmentFirstPoint);
        Point2D segmentLastPoint2D2;
        for (int index1 = 0; !flag && index1 < maxInsertsPerKnotSpan; flag = this.method_0(epsilon, segmentLastPoint2D2, segmentFirstPoint2D, segmentFirstPoint))
        {
          LinkedListNode<double> previousKnot = linkedListNode1;
          LinkedListNode<Point2D> previousPoint = segmentFirstPoint;
          for (int index2 = 0; index2 < this.int_0 && (previousKnot.Next.Value < linkedListNode2.Value && previousKnot.Next.Value - previousKnot.Value < previousKnot.Next.Next.Value - previousKnot.Next.Value); ++index2)
          {
            previousKnot = previousKnot.Next;
            previousPoint = previousPoint.Next;
          }
          this.InsertKnot(previousKnot, previousPoint, 0.5 * (previousKnot.Value + previousKnot.Next.Value));
          ++index1;
          linkedListNode3 = linkedListNode3.Previous;
          segmentLastPoint2D2 = linkedListNode3.Value;
        }
        linkedListNode1 = linkedListNode1.Next;
        segmentFirstPoint = segmentFirstPoint.Next;
      }
    }

    private bool method_0(
      double epsilon,
      Point2D segmentLastPoint2D,
      Point2D segmentFirstPoint2D,
      LinkedListNode<Point2D> segmentFirstPoint)
    {
      if (MathUtil.AreApproxEqual(segmentLastPoint2D.X, segmentFirstPoint2D.X) && MathUtil.AreApproxEqual(segmentLastPoint2D.Y, segmentFirstPoint2D.Y))
      {
        double num = epsilon * epsilon;
        LinkedListNode<Point2D> linkedListNode = segmentFirstPoint;
        bool flag = true;
        for (int index = 1; index < this.int_0; ++index)
        {
          linkedListNode = linkedListNode.Next;
          Point2D point2D = linkedListNode.Value;
          if (new Vector2D(point2D.X - segmentFirstPoint2D.X, point2D.Y - segmentFirstPoint2D.Y).GetLengthSquared() > num)
          {
            flag = false;
            break;
          }
        }
        return flag;
      }
      Vector2D u = new Vector2D(segmentLastPoint2D.X - segmentFirstPoint2D.X, segmentLastPoint2D.Y - segmentFirstPoint2D.Y);
      double length = u.GetLength();
      double num1 = epsilon * length;
      LinkedListNode<Point2D> linkedListNode1 = segmentFirstPoint;
      bool flag1 = true;
      for (int index = 1; index < this.int_0; ++index)
      {
        linkedListNode1 = linkedListNode1.Next;
        Point2D point2D = linkedListNode1.Value;
        Vector2D v = new Vector2D(point2D.X - segmentFirstPoint2D.X, point2D.Y - segmentFirstPoint2D.Y);
        if (System.Math.Abs(Vector2D.CrossProduct(u, v)) > num1)
        {
          flag1 = false;
          break;
        }
      }
      return flag1;
    }

    public Vector2D Evaluate(double u)
    {
      Vector2D zero = Vector2D.Zero;
      List<double> doubleList = new List<double>((IEnumerable<double>) this.linkedList_0);
      int knotSpanIndex = NurbsUtilD.GetKnotSpanIndex(u, (IList<double>) doubleList, this.int_0);
      double[] result = new double[this.int_0 + 1];
      NurbsUtilD.EvaluateBasisFunctions(knotSpanIndex, u, this.int_0, (IList<double>) doubleList, result);
      List<Point2D> point2DList = new List<Point2D>((IEnumerable<Point2D>) this.linkedList_1);
      int index1 = knotSpanIndex - this.int_0;
      for (int index2 = 0; index2 <= this.int_0; ++index2)
      {
        double num = result[index2];
        Point2D point2D = point2DList[index1];
        zero.X += num * point2D.X;
        zero.Y += num * point2D.Y;
        ++index1;
      }
      return zero;
    }

    public void AddKnots(double[] knots)
    {
      foreach (double knot in knots)
        this.linkedList_0.AddLast(knot);
    }
  }
}
