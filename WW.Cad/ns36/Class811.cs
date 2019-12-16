// Decompiled with JetBrains decompiler
// Type: ns36.Class811
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections;
using System.Collections.Generic;
using WW;
using WW.Math;
using WW.Math.Geometry;

namespace ns36
{
  internal class Class811
  {
    private static Class811.Class815 class815_0 = new Class811.Class815();
    private static Class811.Class816 class816_0 = new Class811.Class816();
    private static Class811.Class817 class817_0 = new Class811.Class817();

    internal static List<Polyline2D> smethod_0(
      Polyline2D[] borders,
      Point2D reference,
      double angle,
      double distance,
      bool fillInterior)
    {
      return Class811.smethod_1(borders, reference, angle, distance, (double[]) null, fillInterior);
    }

    internal static List<Polyline2D> smethod_1(
      Polyline2D[] borders,
      Point2D reference,
      double angle,
      double distance,
      double[] dashPattern,
      bool fillInterior)
    {
      if (distance == 0.0)
        throw new ArgumentException("Parameter distance must be unequal to 0.");
      double x = System.Math.Cos(angle);
      double y = System.Math.Sin(angle);
      return Class811.smethod_7(borders, reference, new Vector2D(-distance * y, distance * x), new Vector2D(x, y), dashPattern, fillInterior);
    }

    internal static List<Polyline2D> smethod_2(
      Polyline2D[] borders,
      Point2D reference,
      Vector2D offset,
      Vector2D direction,
      bool fillInterior)
    {
      return Class811.smethod_3(borders, reference, offset, direction, (double[]) null, fillInterior);
    }

    internal static List<Polyline2D> smethod_3(
      Polyline2D[] borders,
      Point2D reference,
      Vector2D offset,
      Vector2D direction,
      double[] dashPattern,
      bool fillInterior)
    {
      double length = direction.GetLength();
      if (length == 0.0)
        throw new ArgumentException("Parameter direction must be unequal to the (0, 0) vector.");
      if (offset == Vector2D.Zero)
        throw new ArgumentException("Parameter offset must be unequal to the (0, 0) vector.");
      return Class811.smethod_7(borders, reference, offset, direction / length, dashPattern, fillInterior);
    }

    internal static IList smethod_4(
      Polyline2D[] borders,
      Point2D reference,
      double angle,
      double distance,
      bool fillInterior)
    {
      if (distance == 0.0)
        throw new ArgumentException("Parameter distance must be unequal to 0.");
      double x = System.Math.Cos(angle);
      double y = System.Math.Sin(angle);
      return (IList) Class811.smethod_8(borders, reference, new Vector2D(-distance * y, distance * x), new Vector2D(x, y), (double[]) null, fillInterior);
    }

    internal static IList smethod_5(
      Polyline2D[] borders,
      Point2D reference,
      Vector2D offset,
      Vector2D direction,
      bool fillInterior)
    {
      return Class811.smethod_6(borders, reference, offset, direction, (double[]) null, fillInterior);
    }

    internal static IList smethod_6(
      Polyline2D[] borders,
      Point2D reference,
      Vector2D offset,
      Vector2D direction,
      double[] dashPattern,
      bool fillInterior)
    {
      double length = direction.GetLength();
      if (length == 0.0)
        throw new ArgumentException("Parameter direction must be unequal to the (0, 0) vector.");
      if (offset == Vector2D.Zero)
        throw new ArgumentException("Parameter offset must be unequal to the (0, 0) vector.");
      return (IList) Class811.smethod_8(borders, reference, offset, direction / length, dashPattern, fillInterior);
    }

    private static List<Polyline2D> smethod_7(
      Polyline2D[] borders,
      Point2D reference,
      Vector2D offset,
      Vector2D direction,
      double[] dashPattern,
      bool fillInterior)
    {
      IList<Segment2D[]> segment2DArrayList = (IList<Segment2D[]>) Class811.smethod_8(borders, reference, offset, direction, dashPattern, fillInterior);
      List<Polyline2D> polyline2DList = new List<Polyline2D>();
      foreach (Segment2D[] segment2DArray in (IEnumerable<Segment2D[]>) segment2DArrayList)
      {
        foreach (Segment2D segment2D in segment2DArray)
        {
          Polyline2D polyline2D = new Polyline2D();
          polyline2D.Add(new Point2D(segment2D.Start.X, segment2D.Start.Y));
          if (segment2D.Start != segment2D.End)
            polyline2D.Add(new Point2D(segment2D.End.X, segment2D.End.Y));
          polyline2DList.Add(polyline2D);
        }
      }
      return polyline2DList;
    }

    private static List<Segment2D[]> smethod_8(
      Polyline2D[] borders,
      Point2D reference,
      Vector2D offset,
      Vector2D direction,
      double[] dashes,
      bool fillInterior)
    {
      double angle = System.Math.Atan2(direction.Y, direction.X);
      Matrix3D matrix3D1 = Transformation3D.Rotate(-angle) * Transformation3D.Translation(-reference.X, -reference.Y);
      Matrix3D matrix3D2 = Transformation3D.Translation(reference.X, reference.Y) * Transformation3D.Rotate(angle);
      Vector2D vector2D = matrix3D1.Transform(offset);
      if (vector2D.Y == 0.0)
        return new List<Segment2D[]>();
      if (vector2D.Y < 0.0)
        vector2D = -vector2D;
      List<Class811.Class818> class818List1 = new List<Class811.Class818>();
      double dashPatternLength = 0.0;
      if (dashes != null)
      {
        foreach (double dash in dashes)
          dashPatternLength += System.Math.Abs(dash);
      }
      int num1 = 0;
      int num2 = -1;
      foreach (Polyline2D border in borders)
      {
        int borderId = border.Closed ? num1++ : num2--;
        for (int index = border.Count - 1; index > 0; --index)
          class818List1.Add(new Class811.Class818(borderId, matrix3D1.Transform(border[index]), matrix3D1.Transform(border[index - 1])));
        if (border.Closed && border.Count >= 3)
          class818List1.Add(new Class811.Class818(borderId, matrix3D1.Transform(border[0]), matrix3D1.Transform(border[border.Count - 1])));
      }
      if (class818List1.Count == 0)
        return new List<Segment2D[]>();
      class818List1.Sort((IComparer<Class811.Class818>) Class811.class816_0);
      List<Class811.Class818> class818List2 = new List<Class811.Class818>();
      double y1 = class818List1[0].point2D_0.Y;
      double num3 = double.NegativeInfinity;
      foreach (Class811.Class818 class818 in class818List1)
      {
        if (class818.point2D_1.Y > num3)
          num3 = class818.point2D_1.Y;
      }
      double num4 = System.Math.Ceiling(y1 / vector2D.Y);
      double x = vector2D.X * num4;
      double y2 = vector2D.Y * num4;
      List<Segment2D[]> segment2DArrayList = new List<Segment2D[]>();
      for (; y2 <= num3; y2 += vector2D.Y)
      {
        while (class818List1.Count > 0 && class818List1[0].point2D_0.Y <= y2)
        {
          Class811.Class818 class818 = class818List1[0];
          class818List1.RemoveAt(0);
          if (class818.point2D_1.Y > y2)
            class818List2.Add(class818);
        }
        List<Class811.Class819> intersections = new List<Class811.Class819>();
        for (int index = class818List2.Count - 1; index >= 0; --index)
        {
          Class811.Class818 class818 = class818List2[index];
          if (class818.point2D_1.Y <= y2)
            class818List2.RemoveAt(index);
          else
            intersections.Add(class818.method_0(y2));
        }
        if (intersections.Count >= 2)
        {
          intersections.Sort();
          if (intersections.Count % 2 != 0)
            Class811.smethod_10(intersections);
          for (int index = intersections.Count - 1; index > 0; --index)
          {
            if (intersections[index].double_0 == intersections[index - 1].double_0)
            {
              intersections.RemoveAt(index);
              intersections.RemoveAt(--index);
            }
          }
          if (intersections.Count > 0)
          {
            if (dashPatternLength > 0.0)
            {
              List<Pair<double>> mappedDashes = new List<Pair<double>>();
              int num5 = intersections.Count / 2;
              for (int index = 0; index < num5; ++index)
              {
                Class811.Class819 class819_1 = intersections[2 * index];
                Class811.Class819 class819_2 = intersections[2 * index + 1];
                Class811.smethod_9(mappedDashes, x, class819_1.double_0, class819_2.double_0, dashes, dashPatternLength);
              }
              if (mappedDashes.Count > 0)
              {
                Segment2D[] segment2DArray = new Segment2D[mappedDashes.Count];
                for (int index = 0; index < mappedDashes.Count; ++index)
                {
                  Point2D point1 = new Point2D(mappedDashes[index].First, y2);
                  Point2D point2 = new Point2D(mappedDashes[index].Second, y2);
                  segment2DArray[index] = new Segment2D(matrix3D2.Transform(point1), matrix3D2.Transform(point2));
                }
                segment2DArrayList.Add(segment2DArray);
              }
            }
            else
            {
              Segment2D[] segment2DArray = new Segment2D[intersections.Count / 2];
              for (int index = 0; index < intersections.Count; index += 2)
              {
                Point2D point1 = new Point2D(intersections[index].double_0, y2);
                Point2D point2 = new Point2D(intersections[index + 1].double_0, y2);
                segment2DArray[index / 2] = new Segment2D(matrix3D2.Transform(point1), matrix3D2.Transform(point2));
              }
              segment2DArrayList.Add(segment2DArray);
            }
          }
        }
        x += vector2D.X;
      }
      return segment2DArrayList;
    }

    private static void smethod_9(
      List<Pair<double>> mappedDashes,
      double x,
      double x1,
      double x2,
      double[] dashes,
      double dashPatternLength)
    {
      double num = System.Math.Floor((x1 - x) / dashPatternLength);
      x += num * dashPatternLength;
      int index = 0;
      while (x <= x2)
      {
        double dash = dashes[index];
        if (x >= x1)
        {
          if (dash >= 0.0)
            mappedDashes.Add(new Pair<double>(x, System.Math.Min(x + dash, x2)));
        }
        else if (dash >= 0.0 && x + dash >= x1)
          mappedDashes.Add(new Pair<double>(x1, System.Math.Min(x + dash, x2)));
        x += System.Math.Abs(dash);
        index = (index + 1) % dashes.Length;
      }
    }

    private static void smethod_10(List<Class811.Class819> intersections)
    {
      for (int index = 0; index < intersections.Count; ++index)
      {
        if (!intersections[index].class818_0.Closed)
        {
          intersections.RemoveAt(index);
          return;
        }
      }
      intersections.RemoveAt(0);
    }

    private static List<Segment2D[]> smethod_11(
      Polyline2D[] borders,
      Point2D reference,
      Vector2D offset,
      Vector2D direction,
      double[] dashes,
      bool fillInterior)
    {
      Bounds2D bounds2D = new Bounds2D();
      foreach (Polyline2D border in borders)
        bounds2D.Update((IList<Point2D>) border);
      int num1 = int.MaxValue;
      int num2 = int.MinValue;
      Point2D[] point2DArray = new Point2D[4]{ new Point2D(bounds2D.Corner1.X, bounds2D.Corner1.Y), new Point2D(bounds2D.Corner2.X, bounds2D.Corner1.Y), new Point2D(bounds2D.Corner2.X, bounds2D.Corner2.Y), new Point2D(bounds2D.Corner1.X, bounds2D.Corner2.Y) };
      double num3 = 1.0 / (-direction.Y * offset.X + direction.X * offset.Y);
      for (int index = 0; index < point2DArray.Length; ++index)
      {
        double num4 = point2DArray[index].X - reference.X;
        double num5 = point2DArray[index].Y - reference.Y;
        double num6 = (-direction.Y * num4 + direction.X * num5) * num3;
        if (num6 < (double) num1)
          num1 = (int) System.Math.Floor(num6);
        if (num6 > (double) num2)
          num2 = (int) System.Math.Ceiling(num6);
      }
      int capacity = num2 - num1;
      Point2D start = reference + (double) num1 * offset;
      double dashPatternLength = 0.0;
      if (dashes != null)
      {
        foreach (double dash in dashes)
          dashPatternLength += System.Math.Abs(dash);
      }
      List<Segment2D[]> segment2DArrayList = new List<Segment2D[]>(capacity);
      for (int index = 0; index < capacity; ++index)
      {
        double[] parameters = Class811.smethod_13(borders, start, direction, fillInterior);
        if (parameters != null && parameters.Length != 0)
          segment2DArrayList.Add(Class811.smethod_12(start, direction, parameters, dashes, dashPatternLength));
        start += offset;
      }
      return segment2DArrayList;
    }

    private static Segment2D[] smethod_12(
      Point2D start,
      Vector2D direction,
      double[] parameters,
      double[] dashPattern,
      double dashPatternLength)
    {
      if (dashPattern != null && dashPattern.Length > 1)
      {
        List<Segment2D> segment2DList = new List<Segment2D>();
        int num1 = parameters.Length >> 1;
        double num2 = 1.0 / dashPatternLength;
        for (int index1 = 0; index1 < num1; ++index1)
        {
          int index2 = 2 * index1;
          int index3 = index2 + 1;
          double parameter1 = parameters[index2];
          double parameter2 = parameters[index3];
          double num3 = (parameter1 * num2 - System.Math.Floor(parameter1 * num2)) * dashPatternLength;
          double num4 = 0.0;
          int num5 = 0;
          while (num4 < num3)
            num4 += System.Math.Abs(dashPattern[num5++]);
          double num6 = num4 - num3;
          double val1 = parameter1 + num6;
          if (num6 > 0.0 && dashPattern[num5 - 1] > 0.0)
          {
            double num7 = System.Math.Min(val1, parameter2);
            segment2DList.Add(new Segment2D(start + parameter1 * direction, start + num7 * direction));
          }
          int index4;
          for (index4 = num5 % dashPattern.Length; val1 + System.Math.Abs(dashPattern[index4]) <= parameter2; index4 = (index4 + 1) % dashPattern.Length)
          {
            double num7 = dashPattern[index4];
            if (num7 < 0.0)
            {
              val1 += -num7;
            }
            else
            {
              segment2DList.Add(new Segment2D(start + val1 * direction, start + (val1 + num7) * direction));
              val1 += num7;
            }
          }
          if (val1 < parameter2 && dashPattern[index4] > 0.0)
            segment2DList.Add(new Segment2D(start + val1 * direction, start + parameter2 * direction));
        }
        return segment2DList.ToArray();
      }
      Segment2D[] segment2DArray = new Segment2D[parameters.Length >> 1];
      for (int index1 = 0; index1 < segment2DArray.Length; ++index1)
      {
        int index2 = index1 << 1;
        int index3 = index2 + 1;
        segment2DArray[index1] = new Segment2D(start + parameters[index2] * direction, start + parameters[index3] * direction);
      }
      return segment2DArray;
    }

    private static double[] smethod_13(
      Polyline2D[] borders,
      Point2D start,
      Vector2D direction,
      bool fillInterior)
    {
      Point2D point2D1 = new Point2D();
      double num1 = start.X * (start.Y + direction.Y) - start.Y * (start.X + direction.X);
      List<Class811.Class812> class812List1 = new List<Class811.Class812>();
      bool flag1 = false;
      foreach (Polyline2D border in borders)
      {
        bool flag2 = false;
        bool flag3 = false;
        Point2D? nullable1 = new Point2D?();
        bool flag4 = false;
        bool flag5 = false;
        Point2D? nullable2 = new Point2D?();
        bool flag6 = false;
        Point2D? nullable3 = new Point2D?();
        if (border.Count > 0)
        {
          Point2D point2D2 = border[0];
        }
        IList<Point2D> point2DList;
        if (border.Closed && border.Count > 2)
        {
          point2DList = (IList<Point2D>) new List<Point2D>((IEnumerable<Point2D>) border);
          point2DList.Add(border[0]);
        }
        else
          point2DList = (IList<Point2D>) border;
        foreach (Point2D location2 in (IEnumerable<Point2D>) point2DList)
        {
          if (nullable3.HasValue)
          {
            if (nullable3.Value == location2)
              continue;
          }
          else
            nullable3 = new Point2D?(Point2D.Zero);
          double num2 = num1 - location2.X * direction.Y + location2.Y * direction.X;
          if (num2 == 0.0)
          {
            flag3 = true;
            if (flag2)
            {
              if (!nullable1.HasValue)
              {
                nullable1 = new Point2D?(location2);
                flag4 = flag6;
              }
            }
            else
              nullable2 = nullable2.HasValue ? new Point2D?(location2) : new Point2D?(location2);
          }
          else
          {
            bool flag7 = num2 > 0.0;
            if (flag2)
            {
              if (flag3)
              {
                if (flag7 ^ flag4)
                {
                  Point2D? nullable4 = nullable1;
                  Point2D? nullable5 = nullable3;
                  if ((nullable4.HasValue != nullable5.HasValue ? 1 : (!nullable4.HasValue ? 0 : (nullable4.GetValueOrDefault() != nullable5.GetValueOrDefault() ? 1 : 0))) != 0)
                  {
                    Class811.Class813 class813 = new Class811.Class813(Class811.smethod_16(nullable1.Value, start, direction), Class811.smethod_16(nullable3.Value, start, direction));
                    Point2D v = start + class813.LowerCut * direction;
                    if (!fillInterior || !Class811.smethod_14(v, borders, border))
                    {
                      class812List1.Add((Class811.Class812) class813);
                      flag1 = true;
                    }
                  }
                  else
                  {
                    Class811.Class812 class812 = (Class811.Class812) new Class811.Class814(Class811.smethod_16(nullable3.Value, start, direction));
                    Point2D v = start + class812.LowerCut * direction;
                    if (!fillInterior || !Class811.smethod_14(v, borders, border))
                      class812List1.Add(class812);
                  }
                }
              }
              else if (flag7 ^ flag6)
              {
                Class811.Class812 class812 = (Class811.Class812) new Class811.Class814(Class811.smethod_15(nullable3.Value, location2, start, direction));
                Point2D v = start + class812.LowerCut * direction;
                if (!fillInterior || !Class811.smethod_14(v, borders, border))
                  class812List1.Add(class812);
              }
            }
            else
            {
              flag5 = flag7;
              flag2 = true;
            }
            flag3 = false;
            flag6 = flag7;
            nullable1 = new Point2D?();
          }
          nullable3 = new Point2D?(location2);
        }
        if (flag2 && flag3 && flag4 ^ flag5)
        {
          Point2D? nullable4 = nullable1;
          Point2D? nullable5 = nullable2;
          if ((nullable4.HasValue != nullable5.HasValue ? 1 : (!nullable4.HasValue ? 0 : (nullable4.GetValueOrDefault() != nullable5.GetValueOrDefault() ? 1 : 0))) != 0)
          {
            Class811.Class813 class813 = new Class811.Class813(Class811.smethod_16(nullable1.Value, start, direction), Class811.smethod_16(nullable2.Value, start, direction));
            Point2D v = start + class813.LowerCut * direction;
            if (!fillInterior || !Class811.smethod_14(v, borders, border))
            {
              class812List1.Add((Class811.Class812) class813);
              flag1 = true;
            }
          }
          else
          {
            Class811.Class812 class812 = (Class811.Class812) new Class811.Class814(Class811.smethod_16(nullable2.Value, start, direction));
            Point2D v = start + class812.LowerCut * direction;
            if (!fillInterior || !Class811.smethod_14(v, borders, border))
              class812List1.Add(class812);
          }
        }
      }
      if (class812List1.Count <= 0)
        return (double[]) null;
      class812List1.Sort();
      if (flag1)
      {
        List<Class811.Class812> class812List2 = new List<Class811.Class812>(class812List1.Count);
        bool flag2 = false;
        bool flag3 = false;
        double cut1 = 0.0;
        foreach (Class811.Class812 class812 in class812List1)
        {
          if (flag2)
          {
            if (class812.LowerCut > cut1)
            {
              if (flag3)
                class812List2.Add((Class811.Class812) new Class811.Class814(cut1));
              flag2 = false;
            }
            else
            {
              flag3 = !flag3;
              if (class812.UpperCut > cut1)
              {
                cut1 = class812.UpperCut;
                continue;
              }
              continue;
            }
          }
          if (class812.IsInterval)
          {
            flag2 = true;
            cut1 = class812.UpperCut;
            if (class812List2.Count % 2 == 1)
            {
              class812List2.Add(class812);
              flag3 = false;
            }
            else
              flag3 = true;
          }
          else
            class812List2.Add(class812);
        }
        class812List1 = class812List2;
      }
      Class811.Class812 class812_1 = (Class811.Class812) null;
      List<Class811.Class812> class812List3 = new List<Class811.Class812>();
      foreach (Class811.Class812 class812_2 in class812List1)
      {
        if (class812_2.Equals((object) class812_1))
        {
          class812_1 = (Class811.Class812) null;
          class812List3.RemoveAt(class812List3.Count - 1);
        }
        else
        {
          class812List3.Add(class812_2);
          class812_1 = class812_2;
        }
      }
      if (class812List3.Count % 2 != 0)
        Console.Error.WriteLine("Error");
      List<Class811.Class812> class812List4 = class812List3;
      double[] numArray = new double[class812List4.Count];
      int num3 = 0;
      foreach (Class811.Class812 class812_2 in class812List4)
        numArray[num3++] = class812_2.LowerCut;
      return numArray;
    }

    private static bool smethod_14(Point2D v, Polyline2D[] borders, Polyline2D exclude)
    {
      foreach (Polyline2D border in borders)
      {
        if (border != exclude && Class749.IsInside(v, border))
          return true;
      }
      return false;
    }

    private static double smethod_15(
      Point2D location1,
      Point2D location2,
      Point2D start,
      Vector2D direction)
    {
      double p;
      double q;
      Line2D.GetIntersectionCoefficients(new Line2D(start, direction), new Line2D(location1, location2 - location1), out p, out q);
      return p;
    }

    private static double smethod_16(Point2D location, Point2D start, Vector2D direction)
    {
      if (System.Math.Abs(direction.X) >= System.Math.Abs(direction.Y))
        return (location.X - start.X) / direction.X;
      return (location.Y - start.Y) / direction.Y;
    }

    private abstract class Class812 : IComparable
    {
      internal abstract bool IsInterval { get; }

      internal abstract double LowerCut { get; }

      internal abstract double UpperCut { get; }

      public int CompareTo(object other)
      {
        double num = this.LowerCut - (other as Class811.Class812).LowerCut;
        if (num > 0.0)
          return 1;
        return num < 0.0 ? -1 : 0;
      }
    }

    private class Class813 : Class811.Class812
    {
      private double double_0;
      private double double_1;

      internal Class813(double cut1, double cut2)
      {
        if (cut1 < cut2)
        {
          this.double_0 = cut1;
          this.double_1 = cut2;
        }
        else
        {
          this.double_0 = cut2;
          this.double_1 = cut1;
        }
      }

      internal override bool IsInterval
      {
        get
        {
          return true;
        }
      }

      internal override double LowerCut
      {
        get
        {
          return this.double_0;
        }
      }

      internal override double UpperCut
      {
        get
        {
          return this.double_1;
        }
      }

      public override bool Equals(object other)
      {
        if (this == other)
          return true;
        Class811.Class813 class813 = other as Class811.Class813;
        if (class813 == null || this.double_0 != class813.double_0)
          return false;
        return this.double_1 == class813.double_1;
      }

      public override int GetHashCode()
      {
        return this.double_0.GetHashCode() ^ this.double_1.GetHashCode();
      }
    }

    private class Class814 : Class811.Class812
    {
      private double double_0;

      internal Class814(double cut1)
      {
        this.double_0 = cut1;
      }

      internal override bool IsInterval
      {
        get
        {
          return false;
        }
      }

      internal override double LowerCut
      {
        get
        {
          return this.double_0;
        }
      }

      internal override double UpperCut
      {
        get
        {
          return this.double_0;
        }
      }

      public override bool Equals(object other)
      {
        if (this == other)
          return true;
        Class811.Class814 class814 = other as Class811.Class814;
        if (class814 == null)
          return false;
        return this.double_0 == class814.double_0;
      }

      public override int GetHashCode()
      {
        return this.double_0.GetHashCode();
      }
    }

    private class Class815 : IComparer<Point2D>
    {
      public int Compare(Point2D p1, Point2D p2)
      {
        int num = p1.Y.CompareTo(p2.Y);
        if (num == 0)
          return p1.X.CompareTo(p2.X);
        return num;
      }
    }

    private class Class816 : IComparer<Class811.Class818>
    {
      public int Compare(Class811.Class818 s1, Class811.Class818 s2)
      {
        return Class811.class815_0.Compare(s1.point2D_0, s2.point2D_0);
      }
    }

    private class Class817 : IComparer<Class811.Class818>
    {
      public int Compare(Class811.Class818 s1, Class811.Class818 s2)
      {
        return Class811.class815_0.Compare(s1.point2D_1, s2.point2D_1);
      }
    }

    private class Class818
    {
      internal readonly int int_0;
      internal readonly Point2D point2D_0;
      internal readonly Point2D point2D_1;

      public Class818(int borderId, Point2D start, Point2D end)
      {
        this.int_0 = borderId;
        if (Class811.class815_0.Compare(start, end) <= 0)
        {
          this.point2D_0 = start;
          this.point2D_1 = end;
        }
        else
        {
          this.point2D_0 = end;
          this.point2D_1 = start;
        }
      }

      public bool Closed
      {
        get
        {
          return this.int_0 >= 0;
        }
      }

      public Class811.Class819 method_0(double y)
      {
        return new Class811.Class819(this, this.point2D_0.X + (y - this.point2D_0.Y) * (this.point2D_1.X - this.point2D_0.X) / (this.point2D_1.Y - this.point2D_0.Y));
      }
    }

    private class Class819 : IComparable<Class811.Class819>
    {
      internal readonly Class811.Class818 class818_0;
      internal readonly double double_0;

      public Class819(Class811.Class818 segment, double x)
      {
        this.class818_0 = segment;
        this.double_0 = x;
      }

      public int CompareTo(Class811.Class819 other)
      {
        return this.double_0.CompareTo(other.double_0);
      }
    }
  }
}
