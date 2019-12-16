// Decompiled with JetBrains decompiler
// Type: ns7.Class794
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System;
using System.Collections.Generic;
using System.IO;
using WW.Math;
using WW.Math.Geometry;

namespace ns7
{
  internal static class Class794
  {
    private const int int_0 = 100;

    public static int smethod_0(int major, int minor)
    {
      return 100 * major + minor;
    }

    public static int smethod_1(int version)
    {
      return version / 100;
    }

    public static int smethod_2(int version)
    {
      return version % 100;
    }

    public static Interface8 smethod_3(
      Interface6 resolver,
      Interface7 subResolver,
      string content)
    {
      Class251.Class254 marker = new Class251.Class254(content);
      string str = marker.method_2();
      if (str == null)
        throw new Exception1();
      try
      {
        int int32 = Convert.ToInt32(str);
        if (int32 < Class250.int_7)
          return (Interface8) new Class251(resolver, subResolver, int32, marker);
        if (int32 < Class250.int_63)
          return (Interface8) new Class252(resolver, subResolver, int32, marker);
        return (Interface8) new Class253(resolver, subResolver, int32, marker);
      }
      catch (FormatException ex)
      {
        throw new Exception0("Failed to read SAT version number!", (Exception) ex);
      }
    }

    public static Interface8 smethod_4(
      Interface6 resolver,
      Interface7 subResolver,
      MemoryStream content)
    {
      try
      {
        int version = Class1045.smethod_7((Stream) content);
        return (Interface8) new Class951(resolver, subResolver, version, content);
      }
      catch (FormatException ex)
      {
        throw new Exception0("Failed to read SAT version number!", (Exception) ex);
      }
    }

    public static Interface9 smethod_5(
      Interface6 resolver,
      Interface7 subResolver,
      int version)
    {
      try
      {
        return (Interface9) new Class255(resolver, subResolver, version);
      }
      catch (FormatException ex)
      {
        throw new Exception0("Failed to write SAT!", (Exception) ex);
      }
    }

    public static Interface9 smethod_6(
      Interface6 resolver,
      Interface7 subResolver,
      MemoryStream content,
      int version)
    {
      try
      {
        Class1045.smethod_9((Stream) content, version);
        return (Interface9) new Class950(resolver, subResolver, version, content);
      }
      catch (FormatException ex)
      {
        throw new Exception0("Failed to write SAT version number!", (Exception) ex);
      }
    }

    public static double smethod_7(Interface28 interval, double value)
    {
      if (interval.IsPeriodic)
      {
        if (!double.IsInfinity(value))
        {
          double num = System.Math.Floor(value / interval.PeriodicLength);
          if (num < 0.0 || num >= 1.0)
            value -= num * interval.PeriodicLength;
        }
        else
          value = 0.0;
      }
      return value;
    }

    public static Point2D smethod_8(
      Interface28 xInterval,
      Interface28 yInterval,
      Point2D point)
    {
      double x = Class794.smethod_7(xInterval, point.X);
      double y = Class794.smethod_7(yInterval, point.Y);
      if (x == point.X && y == point.Y)
        return point;
      return new Point2D(x, y);
    }

    public static Polygon2D[] smethod_9(
      Interface28 xInterval,
      Interface28 yInterval,
      Polygon2D[] outer,
      Polygon2D[] holes,
      bool right,
      double epsilon)
    {
      if (xInterval.IsUnbound || yInterval.IsUnbound)
      {
        Bounds2D bounds2D = new Bounds2D();
        foreach (Polygon2D polygon2D in outer)
          bounds2D.Update((IList<Point2D>) polygon2D);
        if (!bounds2D.Initialized)
          return (Polygon2D[]) null;
        if (xInterval.IsUnbound)
          xInterval = (Interface28) new Class438(xInterval.HasUnboundStart ? bounds2D.Min.X : xInterval.Start, xInterval.HasUnboundEnd ? bounds2D.Max.X : xInterval.End, xInterval.PeriodicLength);
        if (yInterval.IsUnbound)
          yInterval = (Interface28) new Class438(yInterval.HasUnboundStart ? bounds2D.Min.Y : yInterval.Start, yInterval.HasUnboundEnd ? bounds2D.Max.Y : yInterval.End, yInterval.PeriodicLength);
      }
      List<Polygon2D> polygon2DList = new List<Polygon2D>();
      Polygon2D[] polygon2DArray1 = Class794.smethod_10(outer, right, true, xInterval, yInterval, epsilon);
      polygon2DList.AddRange((IEnumerable<Polygon2D>) polygon2DArray1);
      Polygon2D[] polygon2DArray2 = Class794.smethod_10(holes, right, false, xInterval, yInterval, epsilon);
      polygon2DList.AddRange((IEnumerable<Polygon2D>) polygon2DArray2);
      return polygon2DList.ToArray();
    }

    private static Polygon2D[] smethod_10(
      Polygon2D[] polies,
      bool right,
      bool outer,
      Interface28 xInterval,
      Interface28 yInterval,
      double epsilon)
    {
      bool isPeriodic1 = xInterval.IsPeriodic;
      bool isPeriodic2 = yInterval.IsPeriodic;
      if (!isPeriodic1 && !isPeriodic2)
        return polies;
      List<Polygon2D> polygon2DList = new List<Polygon2D>();
      double periodicLength1 = xInterval.PeriodicLength;
      double periodicLength2 = yInterval.PeriodicLength;
      Polygon2D polygon2D1 = new Polygon2D();
      foreach (Polygon2D poly in polies)
      {
        int count = poly.Count;
        if (count > 0)
        {
          Point2D p1 = Class794.smethod_8(xInterval, yInterval, poly[0]);
          for (int index = 1; index <= count; ++index)
          {
            Point2D p2 = Class794.smethod_8(xInterval, yInterval, poly[index % count]);
            bool flag1 = isPeriodic1 && 2.0 * System.Math.Abs(p2.X - p1.X) > periodicLength1;
            bool flag2 = isPeriodic2 && 2.0 * System.Math.Abs(p2.Y - p1.Y) > periodicLength2;
            if (flag1 || flag2)
            {
              if (flag1 && flag2)
                throw new NotSupportedException("Double interval crossing not yet supported!");
              Class794.Struct7 struct7 = flag1 ? Class794.smethod_11(xInterval, p1.X, p2.X) : Class794.smethod_11(yInterval, p1.Y, p2.Y);
              Point2D point2D = Class794.smethod_12(p1, p2, struct7.double_0);
              if (flag1)
              {
                point2D = new Point2D(struct7.bool_0 ? xInterval.End : xInterval.Start, point2D.Y);
                p2 = new Point2D(struct7.bool_0 ? xInterval.Start : xInterval.End, point2D.Y);
              }
              else
              {
                point2D = new Point2D(point2D.X, struct7.bool_0 ? yInterval.End : yInterval.Start);
                p2 = new Point2D(point2D.X, struct7.bool_0 ? yInterval.Start : yInterval.End);
              }
              polygon2D1.Add(point2D);
              polygon2DList.Add(polygon2D1);
              polygon2D1 = new Polygon2D();
            }
            polygon2D1.Add(p2);
            p1 = p2;
          }
        }
      }
      if (polygon2D1.Count > 0)
      {
        if (polygon2DList.Count == 0)
          polygon2DList.Add(polygon2D1);
        else
          polygon2DList.Add(polygon2D1);
      }
      foreach (Polygon2D polygon2D2 in polygon2DList)
        ;
      return polygon2DList.ToArray();
    }

    private static Class794.Struct7 smethod_11(Interface28 interval, double t1, double t2)
    {
      double periodicLength = interval.PeriodicLength;
      bool highLow;
      if (t1 < interval.Start + 0.5 * periodicLength)
      {
        t2 -= periodicLength;
        highLow = false;
      }
      else
      {
        t1 -= periodicLength;
        highLow = true;
      }
      return new Class794.Struct7(t1 == t2 ? 0.0 : t1 / (t1 - t2), highLow);
    }

    private static Point2D smethod_12(Point2D p1, Point2D p2, double p)
    {
      double num1 = p2.X - p1.X;
      double num2 = p2.Y - p1.Y;
      return new Point2D(p1.X + p * num1, p1.Y + p * num2);
    }

    private static double smethod_13(
      Point2D p,
      Interface28 xInterval,
      Interface28 yInterval,
      double epsilon)
    {
      if (System.Math.Abs(xInterval.Start - p.X) <= epsilon)
        return 3.0 + (p.Y - yInterval.End) / (yInterval.Start - yInterval.End);
      if (System.Math.Abs(yInterval.Start - p.Y) <= epsilon)
        return (p.X - xInterval.Start) / (xInterval.End - xInterval.Start);
      if (System.Math.Abs(xInterval.End - p.X) <= epsilon)
        return 1.0 + (p.Y - yInterval.Start) / (yInterval.End - yInterval.Start);
      if (System.Math.Abs(yInterval.End - p.Y) <= epsilon)
        return 2.0 + (p.X - xInterval.End) / (xInterval.Start - xInterval.End);
      return double.NegativeInfinity;
    }

    private static Point2D smethod_14(
      double param,
      Interface28 xInterval,
      Interface28 yInterval)
    {
      int num1 = (int) System.Math.Floor(param);
      double num2 = param - (double) num1;
      switch (num1 & 3)
      {
        case 0:
          return new Point2D(xInterval.Start + num2 * (xInterval.End - xInterval.Start), yInterval.Start);
        case 1:
          return new Point2D(xInterval.End, yInterval.Start + num2 * (yInterval.End - yInterval.Start));
        case 2:
          return new Point2D(xInterval.End + num2 * (xInterval.Start - xInterval.End), yInterval.End);
        case 3:
          return new Point2D(xInterval.Start, yInterval.End + num2 * (yInterval.Start - yInterval.End));
        default:
          throw new ArgumentException("Invalid parameter: " + (object) param);
      }
    }

    public static Point3D smethod_15(Interface8 reader)
    {
      return new Point3D(reader.imethod_8(), reader.imethod_8(), reader.imethod_8());
    }

    private struct Struct7
    {
      internal readonly double double_0;
      internal readonly bool bool_0;

      public Struct7(double param, bool highLow)
      {
        this.double_0 = param;
        this.bool_0 = highLow;
      }
    }
  }
}
