// Decompiled with JetBrains decompiler
// Type: WW.Cad.Base.IntersectionUtil
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Base
{
  public static class IntersectionUtil
  {
    public static double[] GetIntersectionAngles(Segment2D line, Circle2D circle)
    {
      Vector2D delta = line.GetDelta();
      double num1 = delta.X * delta.X + delta.Y * delta.Y;
      Vector2D vector2D = line.Start - circle.Center;
      double num2 = 2.0 * (vector2D.X * delta.X + vector2D.Y * delta.Y);
      double num3 = vector2D.X * vector2D.X + vector2D.Y * vector2D.Y - circle.Radius * circle.Radius;
      double d = num2 * num2 - 4.0 * num1 * num3;
      if (d < 0.0)
        return new double[0];
      double num4 = System.Math.Sqrt(d);
      double num5 = (-num2 - num4) / (2.0 * num1);
      List<double> doubleList = new List<double>(2);
      if (num5 >= 0.0 && num5 <= 1.0)
      {
        double x = vector2D.X + delta.X * num5;
        double num6 = System.Math.Atan2(vector2D.Y + delta.Y * num5, x);
        if (num6 < 0.0)
          num6 += 2.0 * System.Math.PI;
        doubleList.Add(num6);
      }
      if (num4 != 0.0)
      {
        double num6 = (-num2 + num4) / (2.0 * num1);
        if (num6 >= 0.0 && num6 <= 1.0)
        {
          double x = vector2D.X + delta.X * num6;
          double num7 = System.Math.Atan2(vector2D.Y + delta.Y * num6, x);
          if (num7 < 0.0)
            num7 += 2.0 * System.Math.PI;
          doubleList.Add(num7);
        }
      }
      return doubleList.ToArray();
    }

    public static double[] GetIntersectionAngles(Segment2D line, Arc2D arc)
    {
      Vector2D delta = line.GetDelta();
      double num1 = delta.X * delta.X + delta.Y * delta.Y;
      Vector2D vector2D = line.Start - arc.Center;
      double num2 = 2.0 * (vector2D.X * delta.X + vector2D.Y * delta.Y);
      double num3 = vector2D.X * vector2D.X + vector2D.Y * vector2D.Y - arc.Radius * arc.Radius;
      double d = num2 * num2 - 4.0 * num1 * num3;
      if (d < 0.0)
        return new double[0];
      double num4 = System.Math.Sqrt(d);
      double num5 = (-num2 - num4) / (2.0 * num1);
      List<double> doubleList = new List<double>(2);
      AngleIntervalD angleIntervalD = new AngleIntervalD(arc.StartAngle, arc.EndAngle);
      if (num5 >= 0.0 && num5 <= 1.0)
      {
        double x = vector2D.X + delta.X * num5;
        double num6 = System.Math.Atan2(vector2D.Y + delta.Y * num5, x);
        if (num6 < 0.0)
          num6 += 2.0 * System.Math.PI;
        if (angleIntervalD.Contains(num6))
          doubleList.Add(num6);
      }
      if (num4 != 0.0)
      {
        double num6 = (-num2 + num4) / (2.0 * num1);
        if (num6 >= 0.0 && num6 <= 1.0)
        {
          double x = vector2D.X + delta.X * num6;
          double num7 = System.Math.Atan2(vector2D.Y + delta.Y * num6, x);
          if (num7 < 0.0)
            num7 += 2.0 * System.Math.PI;
          if (angleIntervalD.Contains(num7))
            doubleList.Add(num7);
        }
      }
      return doubleList.ToArray();
    }

    public static Arc2D[] CutRectangleFromArc(
      Vector2D rectOrigin,
      Vector2D rectDx,
      Vector2D rectDy,
      Arc2D arc)
    {
      Vector2D vector2D1 = rectOrigin;
      Vector2D vector2D2 = rectOrigin + rectDx;
      Vector2D vector2D3 = rectOrigin + rectDx + rectDy;
      Vector2D vector2D4 = rectOrigin + rectDy;
      Segment2D[] segment2DArray = new Segment2D[4]{ new Segment2D(vector2D1.X, vector2D1.Y, vector2D2.X, vector2D2.Y), new Segment2D(vector2D2.X, vector2D2.Y, vector2D3.X, vector2D3.Y), new Segment2D(vector2D3.X, vector2D3.Y, vector2D4.X, vector2D4.Y), new Segment2D(vector2D4.X, vector2D4.Y, vector2D1.X, vector2D1.Y) };
      List<IntersectionUtil.Struct1> struct1List = new List<IntersectionUtil.Struct1>();
      for (int index = 0; index < segment2DArray.Length; ++index)
      {
        Segment2D line = segment2DArray[index];
        foreach (double intersectionAngle in IntersectionUtil.GetIntersectionAngles(line, arc))
        {
          Vector2D delta = line.GetDelta();
          double num = intersectionAngle + System.Math.PI / 2.0;
          Vector2D vector2D5 = new Vector2D(System.Math.Cos(num), System.Math.Sin(num));
          bool isStartOfCut = delta.X * vector2D5.Y - vector2D5.X * delta.Y > 0.0;
          double angle = intersectionAngle - arc.StartAngle;
          if (angle < 0.0)
            angle += 2.0 * System.Math.PI;
          struct1List.Add(new IntersectionUtil.Struct1(angle, isStartOfCut));
        }
      }
      if (struct1List.Count == 0)
      {
        Vector2D u = (Vector2D) (arc.Center + arc.Radius * new Vector2D(System.Math.Cos(arc.StartAngle), System.Math.Sin(arc.StartAngle))) - rectOrigin;
        double length1 = rectDx.GetLength();
        double num1 = length1 * length1;
        double length2 = rectDy.GetLength();
        double num2 = length2 * length2;
        double num3 = Vector2D.DotProduct(u, rectDx);
        double num4 = Vector2D.DotProduct(u, rectDy);
        if (num3 >= 0.0 && num3 <= num1 && (num4 >= 0.0 && num4 <= num2))
          return new Arc2D[0];
        return new Arc2D[1]{ arc };
      }
      struct1List.Sort();
      IntersectionUtil.Struct1 struct1_1 = struct1List[0];
      IntersectionUtil.Struct1 struct1_2 = struct1List[struct1List.Count - 1];
      if (struct1_1.Angle != 0.0)
        struct1List.Insert(0, new IntersectionUtil.Struct1(0.0, !struct1_1.IsStartOfCut));
      double angle1 = arc.EndAngle - arc.StartAngle;
      if (angle1 < 0.0)
        angle1 += 2.0 * System.Math.PI;
      if (struct1_2.Angle != angle1)
        struct1List.Add(new IntersectionUtil.Struct1(angle1, !struct1_2.IsStartOfCut));
      List<Arc2D> arc2DList = new List<Arc2D>(3);
      for (int index = 0; index < struct1List.Count - 1; ++index)
      {
        IntersectionUtil.Struct1 struct1_3 = struct1List[index];
        IntersectionUtil.Struct1 struct1_4 = struct1List[index + 1];
        if (!struct1_3.IsStartOfCut && struct1_4.IsStartOfCut)
        {
          double startAngle = arc.StartAngle + struct1_3.Angle;
          if (startAngle >= 2.0 * System.Math.PI)
            startAngle -= 2.0 * System.Math.PI;
          double endAngle = arc.StartAngle + struct1_4.Angle;
          if (endAngle >= 2.0 * System.Math.PI)
            endAngle -= 2.0 * System.Math.PI;
          if (startAngle != endAngle)
          {
            Arc2D arc2D = new Arc2D(arc.Center, arc.Radius, startAngle, endAngle);
            arc2DList.Add(arc2D);
          }
        }
      }
      return arc2DList.ToArray();
    }

    private struct Struct1 : IComparable
    {
      private double double_0;
      private bool bool_0;

      public Struct1(double angle, bool isStartOfCut)
      {
        this.double_0 = angle;
        this.bool_0 = isStartOfCut;
      }

      public double Angle
      {
        get
        {
          return this.double_0;
        }
      }

      public bool IsStartOfCut
      {
        get
        {
          return this.bool_0;
        }
      }

      public int CompareTo(object obj)
      {
        return this.double_0.CompareTo(((IntersectionUtil.Struct1) obj).double_0);
      }
    }
  }
}
