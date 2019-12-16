// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.Triangulator2LR
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using ns3;
using ns8;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WW.Math.Exact.Geometry
{
  public static class Triangulator2LR
  {
    private static readonly LongRational longRational_0 = new LongRational(1L, 3L, false);
    private static readonly LongRational longRational_1 = new LongRational(3L, 2L, false);
    private static readonly LongRational longRational_2 = new LongRational(-3L, 2L, false);

    static Triangulator2LR()
    {
      Class123.smethod_0(Enum0.const_3);
    }

    public static void Triangulate(
      IList<IList<Point2LR>> polygons,
      IList<Triangulator2LR.Triangle> triangles,
      IList<Point2LR> points)
    {
      if (polygons.Count == 0)
        return;
      Dictionary<Point2LR, int> dictionary = new Dictionary<Point2LR, int>();
      List<List<int>> intListList = new List<List<int>>(polygons.Count);
      int count1 = points.Count;
      foreach (IList<Point2LR> polygon in (IEnumerable<IList<Point2LR>>) polygons)
      {
        int count2 = polygon.Count;
        if (polygon.Count > 1 && polygon[count2 - 1] == polygon[0])
          --count2;
        List<int> intList = new List<int>(count2);
        intListList.Add(intList);
        for (int index = 0; index < count2; ++index)
        {
          Point2LR key = polygon[index];
          int num;
          if (!dictionary.TryGetValue(key, out num))
          {
            num = count1;
            dictionary.Add(key, num);
            points.Add(key);
            ++count1;
          }
          intList.Add(num);
        }
      }
      if (dictionary.Count == 0)
        return;
      Triangulator2LR.Triangle triangle = Triangulator2LR.smethod_9(points);
      HashSet<Triangulator2LR.Triangle> triangles1 = new HashSet<Triangulator2LR.Triangle>();
      triangles1.Add(triangle);
      Triangulator2LR.Class41 context = new Triangulator2LR.Class41(triangles1, points);
      context.method_2(true);
      Triangulator2LR.Triangle lastAddedTriangle = triangle;
      for (int index1 = 0; index1 < intListList.Count; ++index1)
      {
        List<int> intList = intListList[index1];
        int num1 = intList[0];
        Triangulator2LR.smethod_1(context, num1, ref lastAddedTriangle);
        for (int index2 = 1; index2 < intList.Count; ++index2)
        {
          int num2 = intList[index2];
          Triangulator2LR.smethod_1(context, num2, ref lastAddedTriangle);
          Triangulator2LR.smethod_7(context, num1, num2, ref lastAddedTriangle);
          num1 = num2;
        }
        int p1 = intList[0];
        Triangulator2LR.smethod_7(context, num1, p1, ref lastAddedTriangle);
      }
      Triangulator2LR.FilterNormal(points, (ICollection<Triangulator2LR.Triangle>) triangles1, triangles);
      points.RemoveAt(points.Count - 1);
      points.RemoveAt(points.Count - 1);
      points.RemoveAt(points.Count - 1);
    }

    public static void Triangulate(
      IList<Point2LR> inputPoints,
      IList<IList<int>> polylinePointIndexesList,
      IList<Triangulator2LR.Triangle> triangles)
    {
      Triangulator2LR.Triangulate(inputPoints, polylinePointIndexesList, triangles, true);
    }

    public static void Triangulate(
      IList<Point2LR> inputPoints,
      IList<IList<int>> polylinePointIndexesList,
      IList<Triangulator2LR.Triangle> triangles,
      bool removeSuperTriangles)
    {
      if (inputPoints.Count == 0)
        return;
      List<Point2LR> point2LrList = new List<Point2LR>(inputPoints.Count + 3);
      point2LrList.AddRange((IEnumerable<Point2LR>) inputPoints);
      Triangulator2LR.Triangle triangle1 = Triangulator2LR.smethod_9((IList<Point2LR>) point2LrList);
      HashSet<Triangulator2LR.Triangle> triangles1 = new HashSet<Triangulator2LR.Triangle>();
      triangles1.Add(triangle1);
      List<Triangulator2LR.Triangle> sweeplineTriangles = new List<Triangulator2LR.Triangle>();
      sweeplineTriangles.Add(triangle1);
      List<Triangulator2LR.Class40> class40List = new List<Triangulator2LR.Class40>(inputPoints.Count);
      for (int index = 0; index < inputPoints.Count; ++index)
      {
        Triangulator2LR.Class40 class40 = new Triangulator2LR.Class40(inputPoints[index], index);
        class40List.Add(class40);
      }
      class40List.Sort();
      Triangulator2LR.Class41 context = new Triangulator2LR.Class41(triangles1, (IList<Point2LR>) point2LrList);
      for (int index1 = 0; index1 < class40List.Count; ++index1)
      {
        int index2 = class40List[index1].Index;
        int num = Triangulator2LR.smethod_2(context, sweeplineTriangles, index2);
        if (num != index2)
        {
          foreach (IList<int> polylinePointIndexes in (IEnumerable<IList<int>>) polylinePointIndexesList)
          {
            for (int index3 = 0; index3 < polylinePointIndexes.Count; ++index3)
            {
              if (polylinePointIndexes[index3] == index2)
                polylinePointIndexes[index3] = num;
            }
          }
        }
      }
      if (polylinePointIndexesList != null && polylinePointIndexesList.Count > 0)
      {
        context.method_2(true);
        Triangulator2LR.Triangle lastAddedTriangle = (Triangulator2LR.Triangle) null;
        foreach (IList<int> polylinePointIndexes in (IEnumerable<IList<int>>) polylinePointIndexesList)
        {
          int index1 = 0;
          for (int index2 = 1; index2 < polylinePointIndexes.Count; ++index2)
          {
            Triangulator2LR.smethod_7(context, polylinePointIndexes[index1], polylinePointIndexes[index2], ref lastAddedTriangle);
            ++index1;
          }
        }
      }
      if (removeSuperTriangles)
      {
        int superTriangleFirstIndex = point2LrList.Count - 3;
        foreach (Triangulator2LR.Triangle triangle2 in triangles1)
        {
          if (!triangle2.method_33(superTriangleFirstIndex))
            triangles.Add(triangle2);
        }
        point2LrList.RemoveRange(point2LrList.Count - 3, 3);
      }
      else
      {
        for (int index = point2LrList.Count - 3; index < point2LrList.Count; ++index)
          inputPoints.Add(point2LrList[index]);
        foreach (Triangulator2LR.Triangle triangle2 in triangles1)
          triangles.Add(triangle2);
      }
    }

    public static void FilterIgnore(
      IList<Point2LR> points,
      ICollection<Triangulator2LR.Triangle> unfilteredTriangles,
      IList<Triangulator2LR.Triangle> triangles)
    {
      if (unfilteredTriangles.Count == 0)
        return;
      Triangulator2LR.Triangle triangle = Triangulator2LR.smethod_18(points, unfilteredTriangles);
      Triangulator2LR.smethod_0(unfilteredTriangles, points, triangle);
      foreach (Triangulator2LR.Triangle unfilteredTriangle in (IEnumerable<Triangulator2LR.Triangle>) unfilteredTriangles)
      {
        if (unfilteredTriangle.FilterStatus == (byte) 0)
          triangles.Add(unfilteredTriangle);
      }
    }

    public static void FilterNormal(
      IList<Point2LR> points,
      ICollection<Triangulator2LR.Triangle> unfilteredTriangles,
      IList<Triangulator2LR.Triangle> triangles)
    {
      if (unfilteredTriangles.Count == 0)
        return;
      Triangulator2LR.Triangle triangle1 = Triangulator2LR.smethod_18(points, unfilteredTriangles);
      Stack<Triangulator2LR.Class39> class39Stack = new Stack<Triangulator2LR.Class39>();
      class39Stack.Push(new Triangulator2LR.Class39(triangle1, false));
      triangle1.FilterStatus = (byte) 1;
      while (class39Stack.Count > 0)
      {
        Triangulator2LR.Class39 class39 = class39Stack.Pop();
        Triangulator2LR.Triangle triangle2 = class39.Triangle;
        if (triangle2.neighbour0 != null && triangle2.neighbour0.FilterStatus == (byte) 0)
        {
          triangle2.neighbour0.FilterStatus = (byte) 1;
          bool inside;
          if (inside = class39.Inside ^ triangle2.Edge0HasOddFixCount)
            triangles.Add(triangle2.neighbour0);
          class39Stack.Push(new Triangulator2LR.Class39(triangle2.neighbour0, inside));
        }
        if (triangle2.neighbour1 != null && triangle2.neighbour1.FilterStatus == (byte) 0)
        {
          triangle2.neighbour1.FilterStatus = (byte) 1;
          bool inside;
          if (inside = class39.Inside ^ triangle2.Edge1HasOddFixCount)
            triangles.Add(triangle2.neighbour1);
          class39Stack.Push(new Triangulator2LR.Class39(triangle2.neighbour1, inside));
        }
        if (triangle2.neighbour2 != null && triangle2.neighbour2.FilterStatus == (byte) 0)
        {
          triangle2.neighbour2.FilterStatus = (byte) 1;
          bool inside;
          if (inside = class39.Inside ^ triangle2.Edge2HasOddFixCount)
            triangles.Add(triangle2.neighbour2);
          class39Stack.Push(new Triangulator2LR.Class39(triangle2.neighbour2, inside));
        }
      }
    }

    public static void FilterOuter(
      List<Point2LR> points,
      ICollection<Triangulator2LR.Triangle> unfilteredTriangles,
      IList<Triangulator2LR.Triangle> triangles)
    {
      if (unfilteredTriangles.Count == 0)
        return;
      Triangulator2LR.Triangle triangle1 = Triangulator2LR.smethod_18((IList<Point2LR>) points, unfilteredTriangles);
      Triangulator2LR.smethod_0(unfilteredTriangles, (IList<Point2LR>) points, triangle1);
      Stack<Triangulator2LR.Triangle> triangleStack = new Stack<Triangulator2LR.Triangle>();
      triangleStack.Push(triangle1);
      triangle1.FilterStatus = (byte) 2;
      while (triangleStack.Count > 0)
      {
        Triangulator2LR.Triangle triangle2 = triangleStack.Pop();
        if (triangle2.neighbour0 != null && triangle2.neighbour0.FilterStatus < (byte) 2)
        {
          if (triangle2.neighbour0.FilterStatus == (byte) 0)
          {
            if (triangle2.FilterStatus > (byte) 2 ^ triangle2.Edge0HasOddFixCount)
            {
              triangles.Add(triangle2.neighbour0);
              triangleStack.Push(triangle2.neighbour0);
            }
            triangle2.neighbour0.FilterStatus = (byte) 3;
          }
          else
          {
            triangleStack.Push(triangle2.neighbour0);
            triangle2.neighbour0.FilterStatus = (byte) 2;
          }
        }
        if (triangle2.neighbour1 != null && triangle2.neighbour1.FilterStatus < (byte) 2)
        {
          if (triangle2.neighbour1.FilterStatus == (byte) 0)
          {
            if (triangle2.FilterStatus > (byte) 2 ^ triangle2.Edge1HasOddFixCount)
            {
              triangles.Add(triangle2.neighbour1);
              triangleStack.Push(triangle2.neighbour1);
            }
            triangle2.neighbour1.FilterStatus = (byte) 3;
          }
          else
          {
            triangleStack.Push(triangle2.neighbour1);
            triangle2.neighbour1.FilterStatus = (byte) 2;
          }
        }
        if (triangle2.neighbour2 != null && triangle2.neighbour2.FilterStatus < (byte) 2)
        {
          if (triangle2.neighbour2.FilterStatus == (byte) 0)
          {
            if (triangle2.FilterStatus > (byte) 2 ^ triangle2.Edge2HasOddFixCount)
            {
              triangles.Add(triangle2.neighbour2);
              triangleStack.Push(triangle2.neighbour2);
            }
            triangle2.neighbour2.FilterStatus = (byte) 3;
          }
          else
          {
            triangleStack.Push(triangle2.neighbour2);
            triangle2.neighbour2.FilterStatus = (byte) 2;
          }
        }
      }
    }

    public static List<Polygon2LR> GetPolygons(
      ICollection<Triangulator2LR.Triangle> triangles,
      List<Point2LR> points)
    {
      List<Polygon2LR> polygon2LrList = new List<Polygon2LR>();
      foreach (Triangulator2LR.Triangle triangle in (IEnumerable<Triangulator2LR.Triangle>) triangles)
        triangle.FilterStatus = (byte) 0;
      foreach (Triangulator2LR.Triangle triangle in (IEnumerable<Triangulator2LR.Triangle>) triangles)
      {
        for (int cornerIndex = 0; cornerIndex < 3; ++cornerIndex)
        {
          int nextEdge = cornerIndex;
          if (((int) triangle.method_17(nextEdge) & 1) != 0)
          {
            byte num = (byte) (1 << nextEdge);
            if (((int) triangle.FilterStatus & (int) num) == 0)
            {
              triangle.FilterStatus |= num;
              Polygon2LR polygon2Lr = new Polygon2LR();
              int index1 = triangle.method_1((cornerIndex + 1) % 3);
              Point2LR point1 = points[index1];
              polygon2Lr.Add(point1);
              int index2 = triangle.method_1(cornerIndex);
              Point2LR point2 = points[index2];
              polygon2Lr.Add(point2);
              Triangulator2LR.Triangle nextTriangle = triangle;
              while (nextTriangle.method_39(nextEdge, out nextTriangle, out nextEdge))
              {
                int index3 = nextTriangle.method_1(nextEdge);
                if (index3 != index1)
                {
                  polygon2Lr.Add(points[index3]);
                }
                else
                {
                  polygon2LrList.Add(polygon2Lr);
                  break;
                }
              }
            }
          }
        }
      }
      return polygon2LrList;
    }

    private static void smethod_0(
      ICollection<Triangulator2LR.Triangle> triangles,
      IList<Point2LR> points,
      Triangulator2LR.Triangle triangle)
    {
      Stack<Triangulator2LR.Triangle> triangleStack = new Stack<Triangulator2LR.Triangle>();
      triangleStack.Push(triangle);
      while (triangleStack.Count > 0)
      {
        triangle = triangleStack.Pop();
        triangle.FilterStatus = (byte) 1;
        if (!triangle.Edge0HasOddFixCount && triangle.neighbour0 != null && triangle.neighbour0.FilterStatus == (byte) 0)
          triangleStack.Push(triangle.neighbour0);
        if (!triangle.Edge1HasOddFixCount && triangle.neighbour1 != null && triangle.neighbour1.FilterStatus == (byte) 0)
          triangleStack.Push(triangle.neighbour1);
        if (!triangle.Edge2HasOddFixCount && triangle.neighbour2 != null && triangle.neighbour2.FilterStatus == (byte) 0)
          triangleStack.Push(triangle.neighbour2);
      }
    }

    internal static int smethod_1(
      Triangulator2LR.Class41 context,
      int pointIndex,
      ref Triangulator2LR.Triangle lastAddedTriangle)
    {
      Point2LR point = context.Points[pointIndex];
      int onEdgeFlags;
      Triangulator2LR.Triangle t = Triangulator2LR.smethod_16(context, lastAddedTriangle, point, out onEdgeFlags);
      return Triangulator2LR.smethod_3(context, pointIndex, t, onEdgeFlags, out lastAddedTriangle);
    }

    internal static int smethod_2(
      Triangulator2LR.Class41 context,
      List<Triangulator2LR.Triangle> sweeplineTriangles,
      int pointIndex)
    {
      Point2LR point = context.Points[pointIndex];
      int sweeplineTriangleIndex;
      int onEdgeFlags;
      Triangulator2LR.Triangle t = Triangulator2LR.smethod_17(context, sweeplineTriangles, point, out sweeplineTriangleIndex, out onEdgeFlags);
      return Triangulator2LR.smethod_4(context, sweeplineTriangles, pointIndex, sweeplineTriangleIndex, t, onEdgeFlags);
    }

    private static int smethod_3(
      Triangulator2LR.Class41 context,
      int pointIndex,
      Triangulator2LR.Triangle t,
      int onEdgeFlags,
      out Triangulator2LR.Triangle lastAddedTriangle)
    {
      Point2LR point = context.Points[pointIndex];
      int num = pointIndex;
      Stack<Triangulator2LR.Triangle> triangleStack = new Stack<Triangulator2LR.Triangle>();
      switch (onEdgeFlags)
      {
        case 0:
          context.method_1(t);
          triangleStack = new Stack<Triangulator2LR.Triangle>();
          t.method_3(pointIndex, context, triangleStack);
          break;
        case 1:
          context.method_1(t);
          context.method_1(t.neighbour0);
          Triangulator2LR.Triangle triangle1 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle2 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle3 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle4 = new Triangulator2LR.Triangle();
          triangleStack = new Stack<Triangulator2LR.Triangle>();
          t.method_5(0, pointIndex, context, triangleStack, triangle1, triangle2, triangle3, triangle4);
          t.neighbour0.method_5(t.neighbour0.method_35(t.I1), pointIndex, context, triangleStack, triangle3, triangle4, triangle1, triangle2);
          break;
        case 2:
          context.method_1(t);
          context.method_1(t.neighbour1);
          Triangulator2LR.Triangle triangle5 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle6 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle7 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle8 = new Triangulator2LR.Triangle();
          triangleStack = new Stack<Triangulator2LR.Triangle>();
          t.method_5(1, pointIndex, context, triangleStack, triangle5, triangle6, triangle7, triangle8);
          t.neighbour1.method_5(t.neighbour1.method_35(t.I2), pointIndex, context, triangleStack, triangle7, triangle8, triangle5, triangle6);
          break;
        case 3:
          num = t.I1;
          break;
        case 4:
          context.method_1(t);
          context.method_1(t.neighbour2);
          Triangulator2LR.Triangle triangle9 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle10 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle11 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle12 = new Triangulator2LR.Triangle();
          triangleStack = new Stack<Triangulator2LR.Triangle>();
          t.method_5(2, pointIndex, context, triangleStack, triangle9, triangle10, triangle11, triangle12);
          t.neighbour2.method_5(t.neighbour2.method_35(t.I0), pointIndex, context, triangleStack, triangle11, triangle12, triangle9, triangle10);
          break;
        case 5:
          num = t.I0;
          break;
        case 6:
          num = t.I2;
          break;
        default:
          num = t.I0;
          break;
      }
      if (triangleStack == null)
      {
        lastAddedTriangle = t;
      }
      else
      {
        lastAddedTriangle = triangleStack.Peek();
        Triangulator2LR.smethod_5(context, pointIndex, point, triangleStack);
      }
      return num;
    }

    private static int smethod_4(
      Triangulator2LR.Class41 context,
      List<Triangulator2LR.Triangle> sweeplineTriangles,
      int pointIndex,
      int sweeplineTriangleIndex,
      Triangulator2LR.Triangle t,
      int onEdgeFlags)
    {
      Point2LR point = context.Points[pointIndex];
      int num = pointIndex;
      Stack<Triangulator2LR.Triangle> triangleStack = new Stack<Triangulator2LR.Triangle>();
      switch (onEdgeFlags)
      {
        case 0:
          context.method_1(t);
          t.method_4(pointIndex, context, sweeplineTriangles, sweeplineTriangleIndex, triangleStack);
          break;
        case 1:
          context.method_1(t);
          context.method_1(t.neighbour0);
          Triangulator2LR.Triangle triangle1 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle2 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle3 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle4 = new Triangulator2LR.Triangle();
          t.method_6(0, pointIndex, context, sweeplineTriangles, sweeplineTriangleIndex, triangleStack, triangle1, triangle2, triangle3, triangle4);
          t.neighbour0.method_6(t.neighbour0.method_35(t.I1), pointIndex, context, sweeplineTriangles, sweeplineTriangleIndex + 1, triangleStack, triangle3, triangle4, triangle1, triangle2);
          break;
        case 2:
          context.method_1(t);
          context.method_1(t.neighbour1);
          Triangulator2LR.Triangle triangle5 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle6 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle7 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle8 = new Triangulator2LR.Triangle();
          t.method_6(1, pointIndex, context, sweeplineTriangles, sweeplineTriangleIndex, triangleStack, triangle5, triangle6, triangle7, triangle8);
          t.neighbour1.method_6(t.neighbour1.method_35(t.I2), pointIndex, context, (List<Triangulator2LR.Triangle>) null, -1, triangleStack, triangle7, triangle8, triangle5, triangle6);
          break;
        case 3:
          num = t.I1;
          break;
        case 4:
          context.method_1(t);
          context.method_1(t.neighbour2);
          Triangulator2LR.Triangle triangle9 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle10 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle11 = new Triangulator2LR.Triangle();
          Triangulator2LR.Triangle triangle12 = new Triangulator2LR.Triangle();
          t.method_6(2, pointIndex, context, sweeplineTriangles, sweeplineTriangleIndex, triangleStack, triangle9, triangle10, triangle11, triangle12);
          t.neighbour2.method_6(t.neighbour2.method_35(t.I0), pointIndex, context, sweeplineTriangles, sweeplineTriangleIndex - 1, triangleStack, triangle11, triangle12, triangle9, triangle10);
          break;
        case 5:
          num = t.I0;
          break;
        case 6:
          num = t.I2;
          break;
        default:
          num = t.I0;
          break;
      }
      Triangulator2LR.smethod_6(context, pointIndex, point, triangleStack, sweeplineTriangles);
      return num;
    }

    private static void smethod_5(
      Triangulator2LR.Class41 context,
      int pointIndex,
      Point2LR p,
      Stack<Triangulator2LR.Triangle> tmpTriangles)
    {
      while (tmpTriangles.Count > 0)
      {
        Triangulator2LR.Triangle t = tmpTriangles.Pop();
        if (!t.method_10(pointIndex))
        {
          Triangulator2LR.Triangle oppositeTriangle = t.method_9(pointIndex);
          if (oppositeTriangle != null && oppositeTriangle.method_11(p, context.Points))
          {
            Triangulator2LR.smethod_12(t, oppositeTriangle, pointIndex, context);
            tmpTriangles.Push(t);
            tmpTriangles.Push(oppositeTriangle);
          }
        }
      }
    }

    private static void smethod_6(
      Triangulator2LR.Class41 context,
      int pointIndex,
      Point2LR p,
      Stack<Triangulator2LR.Triangle> tmpTriangles,
      List<Triangulator2LR.Triangle> sweeplineTriangles)
    {
      while (tmpTriangles.Count > 0)
      {
        Triangulator2LR.Triangle t = tmpTriangles.Pop();
        if (!t.method_10(pointIndex))
        {
          Triangulator2LR.Triangle oppositeTriangle = t.method_9(pointIndex);
          if (oppositeTriangle != null && oppositeTriangle.method_11(p, context.Points))
          {
            Triangulator2LR.smethod_13(context, t, oppositeTriangle, pointIndex, sweeplineTriangles);
            tmpTriangles.Push(t);
            tmpTriangles.Push(oppositeTriangle);
          }
        }
      }
    }

    internal static void smethod_7(
      Triangulator2LR.Class41 context,
      int p0,
      int p1,
      ref Triangulator2LR.Triangle lastAddedTriangle)
    {
      int p0_1 = Triangulator2LR.smethod_8(context, p0, p1, ref lastAddedTriangle);
      while (p0_1 != p1)
        p0_1 = Triangulator2LR.smethod_8(context, p0_1, p1, ref lastAddedTriangle);
    }

    private static int smethod_8(
      Triangulator2LR.Class41 context,
      int p0,
      int p1,
      ref Triangulator2LR.Triangle lastAddedTriangle)
    {
      Triangulator2LR.Triangle triangle1;
      if (context.EdgeToTriangle.TryGetValue(new Triangulator2LR.Struct1(p0, p1), out triangle1))
      {
        triangle1.method_14(p0);
        return p1;
      }
      Triangulator2LR.Triangle triangle2 = (Triangulator2LR.Triangle) null;
      HashSet<Triangulator2LR.Triangle> triangleSet;
      if (context.PointIndexToTriangles.TryGetValue(p0, out triangleSet) && triangleSet.Count > 0)
      {
        using (IEnumerator<Triangulator2LR.Triangle> enumerator = (IEnumerator<Triangulator2LR.Triangle>) triangleSet.GetEnumerator())
        {
          enumerator.MoveNext();
          triangle2 = enumerator.Current;
        }
      }
      IList<Point2LR> points = context.Points;
      Triangulator2LR.Triangle t = triangle2.method_19(p0, p1, points);
      if (t == null)
        throw new Exception("Triangle not found.");
      int num1 = p0;
      Point2LR point2Lr = points[p0];
      Vector2LR vector2Lr1 = points[p1] - point2Lr;
      int index = t.method_30(p0);
      Vector2LR vector2Lr2 = points[index] - point2Lr;
      if ((vector2Lr1.X * vector2Lr2.Y - vector2Lr1.Y * vector2Lr2.X).IsZero)
      {
        t.method_15(p0);
        return index;
      }
      int p2 = t.method_29(p0);
      Vector2LR vector2Lr3 = points[p2] - point2Lr;
      if ((vector2Lr1.X * vector2Lr3.Y - vector2Lr1.Y * vector2Lr3.X).IsZero)
      {
        t.method_15(p2);
        return p2;
      }
      context.method_1(t);
      List<int> intList1 = new List<int>();
      List<int> intList2 = new List<int>();
      List<Triangulator2LR.Triangle> outerNeighbours1 = new List<Triangulator2LR.Triangle>();
      List<Triangulator2LR.Triangle> outerNeighbours2 = new List<Triangulator2LR.Triangle>();
      intList2.Insert(0, t.method_29(p0));
      intList1.Add(t.method_30(p0));
      Triangulator2LR.Triangle triangle3 = t.method_31(num1);
      outerNeighbours1.Add(triangle3);
      Triangulator2LR.Triangle triangle4 = t.method_32(num1);
      outerNeighbours2.Add(triangle4);
      int num2 = p1;
      while (!t.method_27(num2))
      {
        Triangulator2LR.Triangle triangle5 = t.method_9(num1);
        if (triangle5 == null)
          throw new Exception("No opposite triangle.");
        int p3 = triangle5.method_28(t);
        if (p3 != num2)
        {
          Vector2LR vector2Lr4 = points[p3] - point2Lr;
          LongRational longRational = vector2Lr1.X * vector2Lr4.Y - vector2Lr1.Y * vector2Lr4.X;
          if (longRational.IsPositive)
          {
            intList1.Add(p3);
            num1 = triangle5.method_29(p3);
            Triangulator2LR.Triangle triangle6 = triangle5.method_31(num1);
            outerNeighbours1.Add(triangle6);
          }
          else if (longRational.IsNegative)
          {
            intList2.Insert(0, p3);
            num1 = triangle5.method_30(p3);
            Triangulator2LR.Triangle triangle6 = triangle5.method_32(num1);
            outerNeighbours2.Insert(0, triangle6);
          }
          else
            num2 = p3;
        }
        t = triangle5;
        context.method_1(t);
      }
      Triangulator2LR.Triangle triangle7 = t.method_31(num2);
      outerNeighbours2.Insert(0, triangle7);
      Triangulator2LR.Triangle triangle8 = t.method_32(num2);
      outerNeighbours1.Add(triangle8);
      List<Triangulator2LR.Triangle> triangleList1 = new List<Triangulator2LR.Triangle>();
      Triangulator2LR.Triangle triangle9 = Triangulator2LR.smethod_11(context, intList1, num2, p0, (Triangulator2LR.Triangle) null, points, triangleList1);
      List<Triangulator2LR.Triangle> triangleList2 = new List<Triangulator2LR.Triangle>();
      Triangulator2LR.Triangle triangle10 = Triangulator2LR.smethod_11(context, intList2, p0, num2, (Triangulator2LR.Triangle) null, points, triangleList2);
      triangle9.method_7(num2, triangle10);
      triangle9.method_15(num2);
      triangle10.method_7(p0, triangle9);
      triangle10.method_15(p0);
      lastAddedTriangle = triangle9;
      intList1.Insert(0, p0);
      intList1.Add(num2);
      Triangulator2LR.smethod_10(triangleList1, intList1, outerNeighbours1);
      intList2.Insert(0, num2);
      intList2.Add(p0);
      Triangulator2LR.smethod_10(triangleList2, intList2, outerNeighbours2);
      return num2;
    }

    internal static Triangulator2LR.Triangle smethod_9(IList<Point2LR> points)
    {
      Bounds2LR bounds2Lr = new Bounds2LR();
      bounds2Lr.Update(points);
      LongRational longRational = LongRational.Max(bounds2Lr.Delta.X, bounds2Lr.Delta.Y);
      Point2LR center = bounds2Lr.Center;
      Point2LR point2Lr1 = center + new Vector2LR(LongRational.Zero, Triangulator2LR.longRational_1 * longRational);
      Point2LR point2Lr2 = center + new Vector2LR(LongRational.Two * longRational, Triangulator2LR.longRational_2 * longRational);
      Point2LR point2Lr3 = center + new Vector2LR(LongRational.MinusTwo * longRational, Triangulator2LR.longRational_2 * longRational);
      int count = points.Count;
      points.Add(point2Lr2);
      points.Add(point2Lr3);
      points.Add(point2Lr1);
      return Triangulator2LR.Triangle.CreateAndAssertClockwise(count + 2, count, count + 1, points);
    }

    private static void smethod_10(
      List<Triangulator2LR.Triangle> innerTriangles,
      List<int> outerPoints,
      List<Triangulator2LR.Triangle> outerNeighbours)
    {
      int num = outerPoints[0];
      for (int index = 0; index < outerNeighbours.Count; ++index)
      {
        Triangulator2LR.Triangle outerNeighbour = outerNeighbours[index];
        int outerPoint = outerPoints[index + 1];
        bool flag = false;
        foreach (Triangulator2LR.Triangle innerTriangle in innerTriangles)
        {
          if (innerTriangle.method_8(num, outerPoint, outerNeighbour))
          {
            if (outerNeighbour != null)
            {
              outerNeighbour.method_7(outerPoint, innerTriangle);
              innerTriangle.method_18(num, outerNeighbour.method_16(outerPoint));
            }
            flag = true;
            break;
          }
        }
        if (!flag)
          throw new Exception("Couldn't find inner triangle to match outer triangle.");
        num = outerPoint;
      }
    }

    private static Triangulator2LR.Triangle smethod_11(
      Triangulator2LR.Class41 context,
      List<int> polygonPoints,
      int p0,
      int p1,
      Triangulator2LR.Triangle neighbour,
      IList<Point2LR> points,
      List<Triangulator2LR.Triangle> newTriangles)
    {
      Triangulator2LR.Triangle triangle1 = (Triangulator2LR.Triangle) null;
      if (polygonPoints.Count > 0)
      {
        int capacity = 0;
        int index1 = polygonPoints[0];
        if (polygonPoints.Count > 1)
        {
          Point2LR point1 = points[p0];
          Point2LR point2 = points[p1];
          Point2LR point3 = points[index1];
          for (int index2 = 1; index2 < polygonPoints.Count; ++index2)
          {
            int polygonPoint = polygonPoints[index2];
            if (Triangulator2LR.Triangle.smethod_0(points[polygonPoint], point1, point2, point3))
            {
              capacity = index2;
              index1 = polygonPoint;
              point3 = points[index1];
            }
          }
          Triangulator2LR.Triangle triangle2 = triangle1 = Triangulator2LR.Triangle.CreateAndAssertClockwise(p0, p1, index1, points);
          triangle2.neighbour0 = neighbour;
          neighbour?.method_7(p1, triangle2);
          context.method_0(triangle2);
          newTriangles.Add(triangle2);
          List<int> polygonPoints1 = new List<int>(capacity);
          for (int index2 = 0; index2 < capacity; ++index2)
            polygonPoints1.Add(polygonPoints[index2]);
          Triangulator2LR.smethod_11(context, polygonPoints1, index1, p1, triangle2, points, newTriangles);
          List<int> polygonPoints2 = new List<int>(polygonPoints.Count - capacity - 1);
          for (int index2 = capacity + 1; index2 < polygonPoints.Count; ++index2)
            polygonPoints2.Add(polygonPoints[index2]);
          Triangulator2LR.smethod_11(context, polygonPoints2, p0, index1, triangle2, points, newTriangles);
        }
        else
        {
          Triangulator2LR.Triangle triangle2 = triangle1 = Triangulator2LR.Triangle.CreateAndAssertClockwise(p0, p1, index1, points);
          triangle2.neighbour0 = neighbour;
          neighbour?.method_7(p1, triangle2);
          context.method_0(triangle2);
          newTriangles.Add(triangle2);
        }
      }
      return triangle1;
    }

    private static void smethod_12(
      Triangulator2LR.Triangle t,
      Triangulator2LR.Triangle oppositeTriangle,
      int pointIndex,
      Triangulator2LR.Class41 context)
    {
      context.method_4(t);
      context.method_4(oppositeTriangle);
      int num = pointIndex;
      byte edge0FixCount;
      Triangulator2LR.Triangle neighbour0;
      int p1;
      byte edge1FixCount;
      Triangulator2LR.Triangle neighbour1;
      int p2;
      byte edge2FixCount;
      Triangulator2LR.Triangle neighbour2;
      int p3;
      byte edge3FixCount;
      Triangulator2LR.Triangle neighbour3;
      t.method_12(num, oppositeTriangle, out edge0FixCount, out neighbour0, out p1, out edge1FixCount, out neighbour1, out p2, out edge2FixCount, out neighbour2, out p3, out edge3FixCount, out neighbour3);
      t.Init(num, edge0FixCount, neighbour0, p1, edge1FixCount, neighbour1, p2, (byte) 0, oppositeTriangle, context.Points);
      oppositeTriangle.Init(num, (byte) 0, t, p2, edge2FixCount, neighbour2, p3, edge3FixCount, neighbour3, context.Points);
      neighbour1?.method_7(p2, t);
      neighbour3?.method_7(num, oppositeTriangle);
      context.method_3(t);
      context.method_3(oppositeTriangle);
    }

    private static void smethod_13(
      Triangulator2LR.Class41 context,
      Triangulator2LR.Triangle t,
      Triangulator2LR.Triangle oppositeTriangle,
      int pointIndex,
      List<Triangulator2LR.Triangle> sweeplineTriangles)
    {
      context.method_4(t);
      context.method_4(oppositeTriangle);
      IList<Point2LR> points = context.Points;
      int num = pointIndex;
      byte edge0FixCount;
      Triangulator2LR.Triangle neighbour0;
      int p1;
      byte edge1FixCount;
      Triangulator2LR.Triangle neighbour1;
      int p2;
      byte edge2FixCount;
      Triangulator2LR.Triangle neighbour2;
      int p3;
      byte edge3FixCount;
      Triangulator2LR.Triangle neighbour3;
      t.method_12(num, oppositeTriangle, out edge0FixCount, out neighbour0, out p1, out edge1FixCount, out neighbour1, out p2, out edge2FixCount, out neighbour2, out p3, out edge3FixCount, out neighbour3);
      int sweepTrianglePointIndex = context.Points.Count - 1;
      bool flag1 = t.method_34(sweepTrianglePointIndex);
      Triangulator2LR.Triangle from1 = new Triangulator2LR.Triangle();
      from1.Init(num, edge0FixCount, neighbour0, p1, edge1FixCount, neighbour1, p2, (byte) 0, oppositeTriangle, points);
      from1.method_38(sweepTrianglePointIndex);
      bool flag2 = from1.method_34(sweepTrianglePointIndex);
      bool flag3 = oppositeTriangle.method_34(sweepTrianglePointIndex);
      Triangulator2LR.Triangle from2 = new Triangulator2LR.Triangle();
      from2.Init(num, (byte) 0, t, p2, edge2FixCount, neighbour2, p3, edge3FixCount, neighbour3, points);
      from2.method_38(sweepTrianglePointIndex);
      bool flag4 = from2.method_34(sweepTrianglePointIndex);
      if (flag2)
      {
        if (flag4)
        {
          oppositeTriangle.method_40(from2);
          if (!flag3)
            Triangulator2LR.smethod_14(sweeplineTriangles, points, oppositeTriangle);
        }
        else
        {
          if (flag3)
            Triangulator2LR.smethod_15(sweeplineTriangles, points, oppositeTriangle);
          oppositeTriangle.method_40(from2);
        }
        t.method_40(from1);
        if (!flag1)
          Triangulator2LR.smethod_14(sweeplineTriangles, points, t);
      }
      else
      {
        if (flag1)
          Triangulator2LR.smethod_15(sweeplineTriangles, points, t);
        t.method_40(from1);
        if (flag4)
        {
          oppositeTriangle.method_40(from2);
          if (!flag3)
            Triangulator2LR.smethod_14(sweeplineTriangles, points, oppositeTriangle);
        }
        else
        {
          if (flag3)
            Triangulator2LR.smethod_15(sweeplineTriangles, points, oppositeTriangle);
          oppositeTriangle.method_40(from2);
        }
      }
      neighbour1?.method_7(p2, t);
      neighbour3?.method_7(num, oppositeTriangle);
      context.method_3(t);
      context.method_3(oppositeTriangle);
    }

    private static void smethod_14(
      List<Triangulator2LR.Triangle> sweeplineTriangles,
      IList<Point2LR> points,
      Triangulator2LR.Triangle t)
    {
      sweeplineTriangles.Insert(sweeplineTriangles.BinarySearch(t, (IComparer<Triangulator2LR.Triangle>) new Triangulator2LR.Triangle.Class38(points)), t);
    }

    private static void smethod_15(
      List<Triangulator2LR.Triangle> sweeplineTriangles,
      IList<Point2LR> points,
      Triangulator2LR.Triangle t)
    {
      sweeplineTriangles.RemoveAt(sweeplineTriangles.BinarySearch(t, (IComparer<Triangulator2LR.Triangle>) new Triangulator2LR.Triangle.Class38(points)));
    }

    private static Triangulator2LR.Triangle smethod_16(
      Triangulator2LR.Class41 context,
      Triangulator2LR.Triangle startTriangle,
      Point2LR p,
      out int onEdgeFlags)
    {
      Triangulator2LR.Triangle triangle1 = startTriangle;
      int skipEdgeIndex = -1;
      int count = context.Triangles.Count;
      while (--count >= 0)
      {
        int outsideEdgeIndex;
        if (triangle1.method_2(p, context.Points, skipEdgeIndex, out onEdgeFlags, out outsideEdgeIndex))
          return triangle1;
        Triangulator2LR.Triangle triangle2 = triangle1;
        triangle1 = triangle1.method_36(outsideEdgeIndex);
        if (triangle1 != null)
          skipEdgeIndex = triangle1.method_35(triangle2.method_37(outsideEdgeIndex));
        else
          break;
      }
      onEdgeFlags = 0;
      return (Triangulator2LR.Triangle) null;
    }

    private static Triangulator2LR.Triangle smethod_17(
      Triangulator2LR.Class41 context,
      List<Triangulator2LR.Triangle> sweeplineTriangles,
      Point2LR p,
      out int sweeplineTriangleIndex,
      out int onEdgeFlags)
    {
      int index1 = 0;
      int num = sweeplineTriangles.Count - 1;
      while (index1 < num)
      {
        int index2 = index1 + (num - index1 >> 1);
        Triangulator2LR.Triangle sweeplineTriangle = sweeplineTriangles[index2];
        int outsideEdgeIndex;
        if (!sweeplineTriangle.method_2(p, context.Points, -1, out onEdgeFlags, out outsideEdgeIndex))
        {
          if (outsideEdgeIndex == 0)
            index1 = index2 + 1;
          else
            num = index2 - 1;
        }
        else
        {
          sweeplineTriangleIndex = index2;
          return sweeplineTriangle;
        }
      }
      Triangulator2LR.Triangle sweeplineTriangle1 = sweeplineTriangles[index1];
      int outsideEdgeIndex1;
      if (sweeplineTriangle1.method_2(p, context.Points, 1, out onEdgeFlags, out outsideEdgeIndex1))
      {
        sweeplineTriangleIndex = index1;
        return sweeplineTriangle1;
      }
      sweeplineTriangleIndex = -1;
      onEdgeFlags = 0;
      return (Triangulator2LR.Triangle) null;
    }

    private static Triangulator2LR.Triangle smethod_18(
      IList<Point2LR> points,
      ICollection<Triangulator2LR.Triangle> unfilteredTriangles)
    {
      int superTriangleFirstIndex = points.Count - 3;
      Triangulator2LR.Triangle triangle = (Triangulator2LR.Triangle) null;
      foreach (Triangulator2LR.Triangle unfilteredTriangle in (IEnumerable<Triangulator2LR.Triangle>) unfilteredTriangles)
      {
        if (unfilteredTriangle.method_33(superTriangleFirstIndex))
        {
          triangle = unfilteredTriangle;
          break;
        }
      }
      if (triangle == null)
        throw new ArgumentException("No super triangle was found.");
      return triangle;
    }

    [Conditional("DEBUG")]
    private static void smethod_19(ICollection<Triangulator2LR.Triangle> triangles)
    {
    }

    [Serializable]
    public class Triangle
    {
      private int i0;
      private int i1;
      private int i2;
      private byte edge0FixCount;
      private byte edge1FixCount;
      private byte edge2FixCount;
      public Triangulator2LR.Triangle neighbour0;
      public Triangulator2LR.Triangle neighbour1;
      public Triangulator2LR.Triangle neighbour2;
      private byte filterStatus;

      public Triangle()
      {
      }

      private Triangle(int i0, int i1, int i2)
      {
        this.i0 = i0;
        this.i1 = i1;
        this.i2 = i2;
      }

      public Triangle(int i0, int i1, int i2, IList<Point2LR> points)
      {
        Vector2LR vector2Lr1 = points[i1] - points[i0];
        Vector2LR vector2Lr2 = points[i2] - points[i0];
        if (!(vector2Lr1.X * vector2Lr2.Y - vector2Lr1.Y * vector2Lr2.X).IsNegative)
        {
          this.i0 = i0;
          this.i1 = i2;
          this.i2 = i1;
        }
        else
        {
          this.i0 = i0;
          this.i1 = i1;
          this.i2 = i2;
        }
      }

      public static Triangulator2LR.Triangle CreateAndAssertClockwise(
        int i0,
        int i1,
        int i2,
        IList<Point2LR> points)
      {
        return new Triangulator2LR.Triangle(i0, i1, i2);
      }

      public void Init(int i0, int i1, int i2, IList<Point2LR> points)
      {
        this.i0 = i0;
        this.i1 = i1;
        this.i2 = i2;
      }

      public void Init(
        int i0,
        byte edge0FixCount,
        Triangulator2LR.Triangle neighbour0,
        int i1,
        byte edge1FixCount,
        Triangulator2LR.Triangle neighbour1,
        int i2,
        byte edge2FixCount,
        Triangulator2LR.Triangle neighbour2,
        IList<Point2LR> points)
      {
        this.i0 = i0;
        this.edge0FixCount = edge0FixCount;
        this.neighbour0 = neighbour0;
        this.i1 = i1;
        this.edge1FixCount = edge1FixCount;
        this.neighbour1 = neighbour1;
        this.i2 = i2;
        this.edge2FixCount = edge2FixCount;
        this.neighbour2 = neighbour2;
      }

      public int I0
      {
        get
        {
          return this.i0;
        }
        set
        {
          this.i0 = value;
        }
      }

      public int I1
      {
        get
        {
          return this.i1;
        }
        set
        {
          this.i1 = value;
        }
      }

      public int I2
      {
        get
        {
          return this.i2;
        }
        set
        {
          this.i2 = value;
        }
      }

      public byte Edge0FixCount
      {
        get
        {
          return this.edge0FixCount;
        }
      }

      public byte Edge1FixCount
      {
        get
        {
          return this.edge1FixCount;
        }
      }

      public byte Edge2FixCount
      {
        get
        {
          return this.edge2FixCount;
        }
      }

      public bool Edge0HasOddFixCount
      {
        get
        {
          return ((int) this.edge0FixCount & 1) != 0;
        }
      }

      public bool Edge1HasOddFixCount
      {
        get
        {
          return ((int) this.edge1FixCount & 1) != 0;
        }
      }

      public bool Edge2HasOddFixCount
      {
        get
        {
          return ((int) this.edge2FixCount & 1) != 0;
        }
      }

      internal byte FilterStatus
      {
        get
        {
          return this.filterStatus;
        }
        set
        {
          this.filterStatus = value;
        }
      }

      internal bool method_0(Point2LR p, IList<Point2LR> points, out int onEdgeFlags)
      {
        return Triangle2LR.ContainsPoint(p, points[this.i0], points[this.i1], points[this.i2], out onEdgeFlags);
      }

      internal int method_1(int cornerIndex)
      {
        switch (cornerIndex)
        {
          case 0:
            return this.i0;
          case 1:
            return this.i1;
          case 2:
            return this.i2;
          default:
            throw new Exception("Illegal corner index");
        }
      }

      internal bool method_2(
        Point2LR p,
        IList<Point2LR> points,
        int skipEdgeIndex,
        out int onEdgeFlags,
        out int outsideEdgeIndex)
      {
        return Triangle2LR.ContainsPoint(p, points[this.i0], points[this.i1], points[this.i2], skipEdgeIndex, out onEdgeFlags, out outsideEdgeIndex);
      }

      internal void method_3(
        int pointIndex,
        Triangulator2LR.Class41 context,
        Stack<Triangulator2LR.Triangle> triangleStack)
      {
        this.method_4(pointIndex, context, (List<Triangulator2LR.Triangle>) null, -1, triangleStack);
      }

      internal void method_4(
        int pointIndex,
        Triangulator2LR.Class41 context,
        List<Triangulator2LR.Triangle> sweeplineTriangles,
        int sweeplineTriangleIndex,
        Stack<Triangulator2LR.Triangle> triangleStack)
      {
        Triangulator2LR.Triangle triangle1 = new Triangulator2LR.Triangle();
        Triangulator2LR.Triangle triangle2 = new Triangulator2LR.Triangle();
        Triangulator2LR.Triangle triangle3 = new Triangulator2LR.Triangle();
        triangle1.Init(this.i0, this.edge0FixCount, this.neighbour0, this.i1, (byte) 0, triangle3, pointIndex, (byte) 0, triangle2, context.Points);
        triangle2.Init(this.i0, (byte) 0, triangle1, pointIndex, (byte) 0, triangle3, this.i2, this.edge2FixCount, this.neighbour2, context.Points);
        triangle3.Init(this.i1, this.edge1FixCount, this.neighbour1, this.i2, (byte) 0, triangle2, pointIndex, (byte) 0, triangle1, context.Points);
        if (this.neighbour0 != null)
          this.neighbour0.method_7(this.i1, triangle1);
        if (this.neighbour1 != null)
          this.neighbour1.method_7(this.i2, triangle3);
        if (this.neighbour2 != null)
          this.neighbour2.method_7(this.i0, triangle2);
        context.method_0(triangle1);
        context.method_0(triangle2);
        context.method_0(triangle3);
        if (sweeplineTriangles != null)
        {
          sweeplineTriangles[sweeplineTriangleIndex] = triangle1;
          sweeplineTriangles.Insert(sweeplineTriangleIndex, triangle2);
        }
        triangleStack.Push(triangle1);
        triangleStack.Push(triangle3);
        triangleStack.Push(triangle2);
      }

      internal void method_5(
        int cornerIndex,
        int pointIndex,
        Triangulator2LR.Class41 context,
        Stack<Triangulator2LR.Triangle> tmpTriangles,
        Triangulator2LR.Triangle t1,
        Triangulator2LR.Triangle t2,
        Triangulator2LR.Triangle t3,
        Triangulator2LR.Triangle t4)
      {
        this.method_6(cornerIndex, pointIndex, context, (List<Triangulator2LR.Triangle>) null, -1, tmpTriangles, t1, t2, t3, t4);
      }

      internal void method_6(
        int cornerIndex,
        int pointIndex,
        Triangulator2LR.Class41 context,
        List<Triangulator2LR.Triangle> sweeplineTriangles,
        int sweeplineTriangleIndex,
        Stack<Triangulator2LR.Triangle> tmpTriangles,
        Triangulator2LR.Triangle t1,
        Triangulator2LR.Triangle t2,
        Triangulator2LR.Triangle t3,
        Triangulator2LR.Triangle t4)
      {
        switch (cornerIndex)
        {
          case 0:
            t1.Init(this.i0, pointIndex, this.i2, context.Points);
            t1.neighbour0 = t4;
            t1.neighbour1 = t2;
            t1.neighbour2 = this.neighbour2;
            t1.edge0FixCount = this.edge0FixCount;
            t1.edge2FixCount = this.edge2FixCount;
            if (this.neighbour2 != null)
              this.neighbour2.method_7(this.i0, t1);
            context.method_0(t1);
            tmpTriangles.Push(t1);
            if (sweeplineTriangles != null)
              sweeplineTriangles[sweeplineTriangleIndex] = t1;
            t2.Init(pointIndex, this.i1, this.i2, context.Points);
            t2.neighbour0 = t3;
            t2.neighbour1 = this.neighbour1;
            t2.neighbour2 = t1;
            t2.edge0FixCount = this.edge0FixCount;
            t2.edge1FixCount = this.edge1FixCount;
            if (this.neighbour1 != null)
              this.neighbour1.method_7(this.i2, t2);
            context.method_0(t2);
            tmpTriangles.Push(t2);
            break;
          case 1:
            t1.Init(this.i0, this.i1, pointIndex, context.Points);
            t1.neighbour0 = this.neighbour0;
            t1.neighbour1 = t4;
            t1.neighbour2 = t2;
            t1.edge0FixCount = this.edge0FixCount;
            t1.edge1FixCount = this.edge1FixCount;
            if (this.neighbour0 != null)
              this.neighbour0.method_7(this.i1, t1);
            context.method_0(t1);
            tmpTriangles.Push(t1);
            if (sweeplineTriangles != null)
              sweeplineTriangles[sweeplineTriangleIndex] = t1;
            t2.Init(this.i0, pointIndex, this.i2, context.Points);
            t2.neighbour0 = t1;
            t2.neighbour1 = t3;
            t2.neighbour2 = this.neighbour2;
            t2.edge1FixCount = this.edge1FixCount;
            t2.edge2FixCount = this.edge2FixCount;
            if (this.neighbour2 != null)
              this.neighbour2.method_7(this.i0, t2);
            context.method_0(t2);
            tmpTriangles.Push(t2);
            sweeplineTriangles?.Insert(sweeplineTriangleIndex, t2);
            break;
          case 2:
            t1.Init(pointIndex, this.i1, this.i2, context.Points);
            t1.neighbour0 = t2;
            t1.neighbour1 = this.neighbour1;
            t1.neighbour2 = t4;
            t1.edge1FixCount = this.edge1FixCount;
            t1.edge2FixCount = this.edge2FixCount;
            if (this.neighbour1 != null)
              this.neighbour1.method_7(this.i2, t1);
            context.method_0(t1);
            tmpTriangles.Push(t1);
            t2.Init(this.i0, this.i1, pointIndex, context.Points);
            t2.neighbour0 = this.neighbour0;
            t2.neighbour1 = t1;
            t2.neighbour2 = t3;
            t2.edge0FixCount = this.edge0FixCount;
            t2.edge2FixCount = this.edge2FixCount;
            if (this.neighbour0 != null)
              this.neighbour0.method_7(this.i1, t2);
            context.method_0(t2);
            tmpTriangles.Push(t2);
            if (sweeplineTriangles == null)
              break;
            sweeplineTriangles[sweeplineTriangleIndex] = t2;
            break;
          default:
            throw new Exception("Unexpected corner index value " + (object) cornerIndex + ".");
        }
      }

      internal void method_7(int edgeFirstPointIndex, Triangulator2LR.Triangle triangle)
      {
        if (triangle == null)
          throw new InternalException("Can't set neighbour to null.");
        if (edgeFirstPointIndex == this.i0)
          this.neighbour0 = triangle;
        else if (edgeFirstPointIndex == this.i1)
        {
          this.neighbour1 = triangle;
        }
        else
        {
          if (edgeFirstPointIndex != this.i2)
            throw new InternalException("Given point is not part of this triangle.");
          this.neighbour2 = triangle;
        }
      }

      internal bool method_8(int e0, int e1, Triangulator2LR.Triangle triangle)
      {
        if (e0 == this.i0)
        {
          if (e1 != this.i1)
            return false;
          this.neighbour0 = triangle;
          return true;
        }
        if (e0 == this.i1)
        {
          if (e1 != this.i2)
            return false;
          this.neighbour1 = triangle;
          return true;
        }
        if (e0 != this.i2 || e1 != this.i0)
          return false;
        this.neighbour2 = triangle;
        return true;
      }

      internal Triangulator2LR.Triangle method_9(int pointIndex)
      {
        if (pointIndex == this.i0)
          return this.neighbour1;
        if (pointIndex == this.i1)
          return this.neighbour2;
        if (pointIndex == this.i2)
          return this.neighbour0;
        return (Triangulator2LR.Triangle) null;
      }

      internal bool method_10(int pointIndex)
      {
        if (pointIndex == this.i0)
          return ((int) this.edge1FixCount & 1) != 0;
        if (pointIndex == this.i1)
          return ((int) this.edge2FixCount & 1) != 0;
        if (pointIndex == this.i2)
          return ((int) this.edge0FixCount & 1) != 0;
        return false;
      }

      internal bool method_11(Point2LR p, IList<Point2LR> points)
      {
        Point2LR point1 = points[this.i0];
        Point2LR point2 = points[this.i1];
        Point2LR point3 = points[this.i2];
        return Triangulator2LR.Triangle.smethod_0(p, point1, point2, point3);
      }

      internal static bool smethod_0(Point2LR p, Point2LR a, Point2LR b, Point2LR c)
      {
        LongRational m00 = a.X - p.X;
        LongRational m01 = a.Y - p.Y;
        LongRational m10 = b.X - p.X;
        LongRational m11 = b.Y - p.Y;
        LongRational m20 = c.X - p.X;
        LongRational m21 = c.Y - p.Y;
        return new Matrix3LR(m00, m01, m00 * m00 + m01 * m01, m10, m11, m10 * m10 + m11 * m11, m20, m21, m20 * m20 + m21 * m21).GetDeterminant().IsNegative;
      }

      internal void method_12(
        int p,
        Triangulator2LR.Triangle opposedTriangle,
        out byte edge0FixCount,
        out Triangulator2LR.Triangle neighbour0,
        out int p1,
        out byte edge1FixCount,
        out Triangulator2LR.Triangle neighbour1,
        out int p2,
        out byte edge2FixCount,
        out Triangulator2LR.Triangle neighbour2,
        out int p3,
        out byte edge3FixCount,
        out Triangulator2LR.Triangle neighbour3)
      {
        if (p == this.i0)
        {
          neighbour0 = this.neighbour0;
          edge0FixCount = this.edge0FixCount;
          p1 = this.i1;
          opposedTriangle.method_13(p1, out edge1FixCount, out neighbour1, out p2, out edge2FixCount, out neighbour2);
          p3 = this.i2;
          neighbour3 = this.neighbour2;
          edge3FixCount = this.edge2FixCount;
        }
        else if (p == this.i1)
        {
          neighbour0 = this.neighbour1;
          edge0FixCount = this.edge1FixCount;
          p1 = this.i2;
          opposedTriangle.method_13(p1, out edge1FixCount, out neighbour1, out p2, out edge2FixCount, out neighbour2);
          p3 = this.i0;
          neighbour3 = this.neighbour0;
          edge3FixCount = this.edge0FixCount;
        }
        else
        {
          neighbour0 = this.neighbour2;
          edge0FixCount = this.edge2FixCount;
          p1 = this.i0;
          opposedTriangle.method_13(p1, out edge1FixCount, out neighbour1, out p2, out edge2FixCount, out neighbour2);
          p3 = this.i1;
          neighbour3 = this.neighbour1;
          edge3FixCount = this.edge1FixCount;
        }
      }

      private void method_13(
        int p0,
        out byte edge0FixCount,
        out Triangulator2LR.Triangle neighbour0,
        out int p1,
        out byte edge1FixCount,
        out Triangulator2LR.Triangle neighbour1)
      {
        if (p0 == this.i0)
        {
          neighbour0 = this.neighbour0;
          edge0FixCount = this.edge0FixCount;
          p1 = this.i1;
          neighbour1 = this.neighbour1;
          edge1FixCount = this.edge1FixCount;
        }
        else if (p0 == this.i1)
        {
          neighbour0 = this.neighbour1;
          edge0FixCount = this.edge1FixCount;
          p1 = this.i2;
          neighbour1 = this.neighbour2;
          edge1FixCount = this.edge2FixCount;
        }
        else
        {
          neighbour0 = this.neighbour2;
          edge0FixCount = this.edge2FixCount;
          p1 = this.i0;
          neighbour1 = this.neighbour0;
          edge1FixCount = this.edge0FixCount;
        }
      }

      internal void method_14(int p)
      {
        if (p == this.i0)
        {
          ++this.edge0FixCount;
          if (this.neighbour0 == null)
            return;
          this.neighbour0.method_15(this.i1);
        }
        else if (p == this.i1)
        {
          ++this.edge1FixCount;
          if (this.neighbour1 == null)
            return;
          this.neighbour1.method_15(this.i2);
        }
        else
        {
          if (p != this.i2)
            throw new InternalException("Edge not part of triangle.");
          ++this.edge2FixCount;
          if (this.neighbour2 == null)
            return;
          this.neighbour2.method_15(this.i0);
        }
      }

      internal void method_15(int p)
      {
        if (p == this.i0)
          ++this.edge0FixCount;
        else if (p == this.i1)
        {
          ++this.edge1FixCount;
        }
        else
        {
          if (p != this.i2)
            throw new InternalException("Edge not part of triangle.");
          ++this.edge2FixCount;
        }
      }

      internal byte method_16(int p)
      {
        if (p == this.i0)
          return this.edge0FixCount;
        if (p == this.i1)
          return this.edge1FixCount;
        if (p != this.i2)
          throw new InternalException("Edge not part of triangle.");
        return this.edge2FixCount;
      }

      internal byte method_17(int cornerIndex)
      {
        switch (cornerIndex)
        {
          case 0:
            return this.edge0FixCount;
          case 1:
            return this.edge1FixCount;
          case 2:
            return this.edge2FixCount;
          default:
            throw new InternalException("Illegal corner index.");
        }
      }

      internal void method_18(int p, byte fixCount)
      {
        if (p == this.i0)
          this.edge0FixCount = fixCount;
        else if (p == this.i1)
        {
          this.edge1FixCount = fixCount;
        }
        else
        {
          if (p != this.i2)
            throw new InternalException("Edge not part of triangle.");
          this.edge2FixCount = fixCount;
        }
      }

      internal Triangulator2LR.Triangle method_19(
        int p0,
        int p1,
        IList<Point2LR> points)
      {
        Triangulator2LR.Triangle triangle1 = this;
        Point2LR point = points[p0];
        Vector2LR p01 = points[p1] - point;
        Triangulator2LR.Triangle triangle2;
        do
        {
          triangle2 = triangle1;
          int oppositePoint0;
          int oppositePoint1;
          triangle1 = triangle2.method_26(p0, out oppositePoint0, out oppositePoint1);
          if (Triangulator2LR.Triangle.smethod_1(point, p01, oppositePoint0, oppositePoint1, points))
            goto label_4;
        }
        while (triangle1 != null && triangle1 != this);
        throw new Exception("Couldn't find triangle containing segment.");
label_4:
        return triangle2;
      }

      internal void method_20(
        Dictionary<Triangulator2LR.Struct1, Triangulator2LR.Triangle> edgeToTriangle)
      {
        edgeToTriangle.Add(new Triangulator2LR.Struct1(this.i0, this.i1), this);
        edgeToTriangle.Add(new Triangulator2LR.Struct1(this.i1, this.i2), this);
        edgeToTriangle.Add(new Triangulator2LR.Struct1(this.i2, this.i0), this);
      }

      internal void method_21(
        Dictionary<Triangulator2LR.Struct1, Triangulator2LR.Triangle> edgeToTriangle)
      {
        edgeToTriangle.Remove(new Triangulator2LR.Struct1(this.i0, this.i1));
        edgeToTriangle.Remove(new Triangulator2LR.Struct1(this.i1, this.i2));
        edgeToTriangle.Remove(new Triangulator2LR.Struct1(this.i2, this.i0));
      }

      internal void method_22(
        Dictionary<int, HashSet<Triangulator2LR.Triangle>> pointIndexToTriangles)
      {
        this.method_23(this.i0, pointIndexToTriangles);
        this.method_23(this.i1, pointIndexToTriangles);
        this.method_23(this.i2, pointIndexToTriangles);
      }

      private void method_23(
        int i,
        Dictionary<int, HashSet<Triangulator2LR.Triangle>> pointIndexToTriangles)
      {
        HashSet<Triangulator2LR.Triangle> triangleSet;
        if (!pointIndexToTriangles.TryGetValue(i, out triangleSet))
        {
          triangleSet = new HashSet<Triangulator2LR.Triangle>();
          pointIndexToTriangles.Add(i, triangleSet);
        }
        triangleSet.Add(this);
      }

      internal void method_24(
        Dictionary<int, HashSet<Triangulator2LR.Triangle>> pointIndexToTriangles)
      {
        this.method_25(this.i0, pointIndexToTriangles);
        this.method_25(this.i1, pointIndexToTriangles);
        this.method_25(this.i2, pointIndexToTriangles);
      }

      private void method_25(
        int i,
        Dictionary<int, HashSet<Triangulator2LR.Triangle>> pointIndexToTriangles)
      {
        HashSet<Triangulator2LR.Triangle> triangleSet;
        if (!pointIndexToTriangles.TryGetValue(i, out triangleSet))
          return;
        triangleSet.Remove(this);
      }

      private Triangulator2LR.Triangle method_26(
        int p0,
        out int oppositePoint0,
        out int oppositePoint1)
      {
        if (p0 == this.i0)
        {
          oppositePoint0 = this.i1;
          oppositePoint1 = this.i2;
          return this.neighbour0;
        }
        if (p0 == this.i1)
        {
          oppositePoint0 = this.i2;
          oppositePoint1 = this.i0;
          return this.neighbour1;
        }
        if (p0 != this.i2)
          throw new InternalException("Point not in this triangle.");
        oppositePoint0 = this.i0;
        oppositePoint1 = this.i1;
        return this.neighbour2;
      }

      private static bool smethod_1(
        Point2LR p0,
        Vector2LR p01,
        int q0,
        int q1,
        IList<Point2LR> points)
      {
        Point2LR point1 = points[q0];
        Point2LR point2 = points[q1];
        Vector2LR vector2Lr1 = point2 - point1;
        Vector2LR u = new Vector2LR(vector2Lr1.Y, -vector2Lr1.X);
        int sign1 = Vector2LR.DotProduct(u, p01).Sign;
        int sign2 = Vector2LR.DotProduct(u, p0 - point1).Sign;
        if (sign2 != -sign1 && sign2 != 0)
          return false;
        Vector2LR vector2Lr2 = point1 - p0;
        Vector2LR vector2Lr3 = point2 - p0;
        int sign3 = (vector2Lr2.X * p01.Y - vector2Lr2.Y * p01.X).Sign;
        int sign4 = (vector2Lr3.X * p01.Y - vector2Lr3.Y * p01.X).Sign;
        if (sign3 != -sign4 && sign3 != 0)
          return sign4 == 0;
        return true;
      }

      internal bool method_27(int p1)
      {
        if (p1 != this.i0 && p1 != this.i1)
          return p1 == this.i2;
        return true;
      }

      internal int method_28(Triangulator2LR.Triangle t)
      {
        if (t == this.neighbour0)
          return this.i2;
        if (t == this.neighbour1)
          return this.i0;
        if (t != this.neighbour2)
          throw new InternalException("Given triangle is not a neighbour.");
        return this.i1;
      }

      internal int method_29(int p)
      {
        if (p == this.i0)
          return this.i2;
        if (p == this.i1)
          return this.i0;
        if (p != this.i2)
          throw new InternalException("Given point is not part of this triangle.");
        return this.i1;
      }

      internal int method_30(int p)
      {
        if (p == this.i0)
          return this.i1;
        if (p == this.i1)
          return this.i2;
        if (p != this.i2)
          throw new InternalException("Given point is not part of this triangle.");
        return this.i0;
      }

      internal Triangulator2LR.Triangle method_31(int p)
      {
        if (p == this.i0)
          return this.neighbour0;
        if (p == this.i1)
          return this.neighbour1;
        if (p != this.i2)
          throw new InternalException("Given point is not part of this triangle.");
        return this.neighbour2;
      }

      internal Triangulator2LR.Triangle method_32(int p)
      {
        if (p == this.i0)
          return this.neighbour2;
        if (p == this.i1)
          return this.neighbour0;
        if (p != this.i2)
          throw new InternalException("Given point is not part of this triangle.");
        return this.neighbour1;
      }

      internal bool method_33(int superTriangleFirstIndex)
      {
        if (this.i0 < superTriangleFirstIndex && this.i1 < superTriangleFirstIndex)
          return this.i2 >= superTriangleFirstIndex;
        return true;
      }

      internal bool method_34(int sweepTrianglePointIndex)
      {
        return this.i0 == sweepTrianglePointIndex;
      }

      public override string ToString()
      {
        StringBuilder stringBuilder = new StringBuilder();
        int num = 0;
        if (this.neighbour0 != null)
          ++num;
        if (this.neighbour1 != null)
          ++num;
        if (this.neighbour2 != null)
          ++num;
        stringBuilder.Append("n: " + num.ToString() + ", ");
        stringBuilder.Append(this.i0.ToString());
        if (this.edge0FixCount > (byte) 0)
        {
          stringBuilder.Append(" (fixed");
          stringBuilder.Append(this.edge0FixCount.ToString());
          stringBuilder.Append(")");
        }
        stringBuilder.Append(", ");
        stringBuilder.Append(this.i1.ToString());
        if (this.edge1FixCount > (byte) 0)
        {
          stringBuilder.Append(" (fixed");
          stringBuilder.Append(this.edge1FixCount.ToString());
          stringBuilder.Append(")");
        }
        stringBuilder.Append(", ");
        stringBuilder.Append(this.i2.ToString());
        if (this.edge2FixCount > (byte) 0)
        {
          stringBuilder.Append(" (fixed");
          stringBuilder.Append(this.edge2FixCount.ToString());
          stringBuilder.Append(")");
        }
        return stringBuilder.ToString();
      }

      internal int method_35(int i)
      {
        if (i == this.i0)
          return 0;
        if (i == this.i1)
          return 1;
        return i == this.i2 ? 2 : -1;
      }

      internal Triangulator2LR.Triangle method_36(int neighbourIndex)
      {
        switch (neighbourIndex)
        {
          case 0:
            return this.neighbour0;
          case 1:
            return this.neighbour1;
          case 2:
            return this.neighbour2;
          default:
            throw new ArgumentException();
        }
      }

      internal int method_37(int edgeIndex)
      {
        switch (edgeIndex)
        {
          case 0:
            return this.i1;
          case 1:
            return this.i2;
          case 2:
            return this.i0;
          default:
            throw new ArgumentException();
        }
      }

      internal void method_38(int sweepTrianglePointIndex)
      {
        if (this.i1 == sweepTrianglePointIndex)
        {
          int i0 = this.i0;
          Triangulator2LR.Triangle neighbour0 = this.neighbour0;
          byte edge0FixCount = this.edge0FixCount;
          this.i0 = this.i1;
          this.neighbour0 = this.neighbour1;
          this.edge0FixCount = this.edge1FixCount;
          this.i1 = this.i2;
          this.neighbour1 = this.neighbour2;
          this.edge1FixCount = this.edge2FixCount;
          this.i2 = i0;
          this.neighbour2 = neighbour0;
          this.edge2FixCount = edge0FixCount;
        }
        else
        {
          if (this.i2 != sweepTrianglePointIndex)
            return;
          int i0 = this.i0;
          Triangulator2LR.Triangle neighbour0 = this.neighbour0;
          byte edge0FixCount = this.edge0FixCount;
          this.i0 = this.i2;
          this.neighbour0 = this.neighbour2;
          this.edge0FixCount = this.edge2FixCount;
          this.i2 = this.i1;
          this.neighbour2 = this.neighbour1;
          this.edge2FixCount = this.edge1FixCount;
          this.i1 = i0;
          this.neighbour1 = neighbour0;
          this.edge1FixCount = edge0FixCount;
        }
      }

      internal bool method_39(
        int edge,
        out Triangulator2LR.Triangle nextTriangle,
        out int nextEdge)
      {
        int cornerIndex1 = (edge + 2) % 3;
        byte num1 = (byte) (1 << cornerIndex1);
        if (((int) this.method_17(cornerIndex1) & 1) != 0 && ((int) this.filterStatus & (int) num1) == 0)
        {
          this.filterStatus |= num1;
          nextTriangle = this;
          nextEdge = cornerIndex1;
          return true;
        }
        Triangulator2LR.Triangle triangle1 = this;
        int num2 = this.method_1(edge);
        for (Triangulator2LR.Triangle triangle2 = triangle1.method_32(num2); triangle2 != null && triangle2 != this; triangle2 = triangle2.method_32(num2))
        {
          int cornerIndex2 = (triangle2.method_35(num2) + 2) % 3;
          byte num3 = (byte) (1 << cornerIndex2);
          if (((int) triangle2.method_17(cornerIndex2) & 1) != 0 && ((int) triangle2.filterStatus & (int) num3) == 0)
          {
            triangle2.filterStatus |= num3;
            nextTriangle = triangle2;
            nextEdge = cornerIndex2;
            return true;
          }
        }
        nextTriangle = (Triangulator2LR.Triangle) null;
        nextEdge = -1;
        return false;
      }

      internal void method_40(Triangulator2LR.Triangle from)
      {
        this.i0 = from.i0;
        this.i1 = from.i1;
        this.i2 = from.i2;
        this.neighbour0 = from.neighbour0;
        this.neighbour1 = from.neighbour1;
        this.neighbour2 = from.neighbour2;
        this.edge0FixCount = from.edge0FixCount;
        this.edge1FixCount = from.edge1FixCount;
        this.edge2FixCount = from.edge2FixCount;
      }

      internal class Class38 : IComparer<Triangulator2LR.Triangle>
      {
        private IList<Point2LR> ilist_0;

        public Class38(IList<Point2LR> points)
        {
          this.ilist_0 = points;
        }

        public int Compare(Triangulator2LR.Triangle a, Triangulator2LR.Triangle b)
        {
          if (a == b)
            return 0;
          Point2LR point2Lr1 = this.ilist_0[a.i0];
          Point2LR point2Lr2 = this.ilist_0[a.i1];
          Point2LR point2Lr3 = this.ilist_0[b.i1];
          return Vector2LR.CrossProduct(point2Lr2 - point2Lr1, point2Lr3 - point2Lr1).IsPositive ? -1 : 1;
        }
      }
    }

    private class Class39
    {
      private Triangulator2LR.Triangle triangle_0;
      private bool bool_0;

      public Class39(Triangulator2LR.Triangle triangle, bool inside)
      {
        this.triangle_0 = triangle;
        this.bool_0 = inside;
      }

      public Triangulator2LR.Triangle Triangle
      {
        get
        {
          return this.triangle_0;
        }
        set
        {
          this.triangle_0 = value;
        }
      }

      public bool Inside
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

    private class Class40 : IComparable<Triangulator2LR.Class40>
    {
      private Point2LR point2LR_0;
      private int int_0;

      public Class40(Point2LR position, int index)
      {
        this.point2LR_0 = position;
        this.int_0 = index;
      }

      public int Index
      {
        get
        {
          return this.int_0;
        }
      }

      public int CompareTo(Triangulator2LR.Class40 other)
      {
        if (this.point2LR_0.Y < other.point2LR_0.Y)
          return -1;
        return this.point2LR_0.Y > other.point2LR_0.Y ? 1 : 0;
      }
    }

    internal struct Struct1
    {
      public int int_0;
      public int int_1;

      public Struct1(int p0, int p1)
      {
        this.int_0 = p0;
        this.int_1 = p1;
      }

      public override int GetHashCode()
      {
        return this.int_0 ^ this.int_1 << 16;
      }

      public override bool Equals(object obj)
      {
        bool flag;
        if (obj is Triangulator2LR.Struct1)
        {
          Triangulator2LR.Struct1 struct1 = (Triangulator2LR.Struct1) obj;
          flag = this.int_0 == struct1.int_0 && this.int_1 == struct1.int_1;
        }
        else
          flag = false;
        return flag;
      }
    }

    internal class Class41
    {
      private HashSet<Triangulator2LR.Triangle> hashSet_0;
      private IList<Point2LR> ilist_0;
      private Dictionary<int, HashSet<Triangulator2LR.Triangle>> dictionary_0;
      private Dictionary<Triangulator2LR.Struct1, Triangulator2LR.Triangle> dictionary_1;

      public Class41(HashSet<Triangulator2LR.Triangle> triangles, IList<Point2LR> points)
      {
        this.hashSet_0 = triangles;
        this.ilist_0 = points;
      }

      public HashSet<Triangulator2LR.Triangle> Triangles
      {
        get
        {
          return this.hashSet_0;
        }
        set
        {
          this.hashSet_0 = value;
        }
      }

      public IList<Point2LR> Points
      {
        get
        {
          return this.ilist_0;
        }
        set
        {
          this.ilist_0 = value;
        }
      }

      public Dictionary<int, HashSet<Triangulator2LR.Triangle>> PointIndexToTriangles
      {
        get
        {
          return this.dictionary_0;
        }
        set
        {
          this.dictionary_0 = value;
        }
      }

      public Dictionary<Triangulator2LR.Struct1, Triangulator2LR.Triangle> EdgeToTriangle
      {
        get
        {
          return this.dictionary_1;
        }
        set
        {
          this.dictionary_1 = value;
        }
      }

      public void method_0(Triangulator2LR.Triangle t)
      {
        this.hashSet_0.Add(t);
        this.method_3(t);
      }

      public void method_1(Triangulator2LR.Triangle t)
      {
        this.hashSet_0.Remove(t);
        this.method_4(t);
      }

      internal void method_2(bool initializeFromTriangles)
      {
        this.dictionary_1 = new Dictionary<Triangulator2LR.Struct1, Triangulator2LR.Triangle>();
        this.dictionary_0 = new Dictionary<int, HashSet<Triangulator2LR.Triangle>>();
        foreach (Triangulator2LR.Triangle triangle in this.hashSet_0)
        {
          triangle.method_20(this.dictionary_1);
          triangle.method_22(this.dictionary_0);
        }
      }

      internal void method_3(Triangulator2LR.Triangle t)
      {
        if (this.dictionary_1 != null)
          t.method_20(this.dictionary_1);
        if (this.dictionary_0 == null)
          return;
        t.method_22(this.dictionary_0);
      }

      internal void method_4(Triangulator2LR.Triangle t)
      {
        if (this.dictionary_1 != null)
          t.method_21(this.dictionary_1);
        if (this.dictionary_0 == null)
          return;
        t.method_24(this.dictionary_0);
      }
    }
  }
}
