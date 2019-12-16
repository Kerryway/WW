// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.Triangulator2BR
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
  public static class Triangulator2BR
  {
    private static readonly BigRational bigRational_0 = new BigRational(BigInteger.One, BigInteger.Three, false);
    private static readonly BigRational bigRational_1 = new BigRational(BigInteger.Three, BigInteger.Two, false);
    private static readonly BigRational bigRational_2 = new BigRational(BigInteger.MinusThree, BigInteger.Two, false);

    static Triangulator2BR()
    {
      Class123.smethod_0(Enum0.const_3);
    }

    public static void Triangulate(
      IList<IList<Point2BR>> polygons,
      IList<Triangulator2BR.Triangle> triangles,
      IList<Point2BR> points)
    {
      if (polygons.Count == 0)
        return;
      Dictionary<Point2BR, int> dictionary = new Dictionary<Point2BR, int>();
      List<List<int>> intListList = new List<List<int>>(polygons.Count);
      int count1 = points.Count;
      foreach (IList<Point2BR> polygon in (IEnumerable<IList<Point2BR>>) polygons)
      {
        int count2 = polygon.Count;
        if (polygon.Count > 1 && polygon[count2 - 1] == polygon[0])
          --count2;
        List<int> intList = new List<int>(count2);
        intListList.Add(intList);
        for (int index = 0; index < count2; ++index)
        {
          Point2BR key = polygon[index];
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
      Triangulator2BR.Triangle triangle = Triangulator2BR.smethod_9(points);
      HashSet<Triangulator2BR.Triangle> triangles1 = new HashSet<Triangulator2BR.Triangle>();
      triangles1.Add(triangle);
      Triangulator2BR.Class97 context = new Triangulator2BR.Class97(triangles1, points);
      context.method_2(true);
      Triangulator2BR.Triangle lastAddedTriangle = triangle;
      for (int index1 = 0; index1 < intListList.Count; ++index1)
      {
        List<int> intList = intListList[index1];
        int num1 = intList[0];
        Triangulator2BR.smethod_1(context, num1, ref lastAddedTriangle);
        for (int index2 = 1; index2 < intList.Count; ++index2)
        {
          int num2 = intList[index2];
          Triangulator2BR.smethod_1(context, num2, ref lastAddedTriangle);
          Triangulator2BR.smethod_7(context, num1, num2, ref lastAddedTriangle);
          num1 = num2;
        }
        int p1 = intList[0];
        Triangulator2BR.smethod_7(context, num1, p1, ref lastAddedTriangle);
      }
      Triangulator2BR.FilterNormal(points, (ICollection<Triangulator2BR.Triangle>) triangles1, triangles);
      points.RemoveAt(points.Count - 1);
      points.RemoveAt(points.Count - 1);
      points.RemoveAt(points.Count - 1);
    }

    public static void Triangulate(
      IList<Point2BR> inputPoints,
      IList<IList<int>> polylinePointIndexesList,
      IList<Triangulator2BR.Triangle> triangles)
    {
      Triangulator2BR.Triangulate(inputPoints, polylinePointIndexesList, triangles, true);
    }

    public static void Triangulate(
      IList<Point2BR> inputPoints,
      IList<IList<int>> polylinePointIndexesList,
      IList<Triangulator2BR.Triangle> triangles,
      bool removeSuperTriangles)
    {
      if (inputPoints.Count == 0)
        return;
      List<Point2BR> point2BrList = new List<Point2BR>(inputPoints.Count + 3);
      point2BrList.AddRange((IEnumerable<Point2BR>) inputPoints);
      Triangulator2BR.Triangle triangle1 = Triangulator2BR.smethod_9((IList<Point2BR>) point2BrList);
      HashSet<Triangulator2BR.Triangle> triangles1 = new HashSet<Triangulator2BR.Triangle>();
      triangles1.Add(triangle1);
      List<Triangulator2BR.Triangle> sweeplineTriangles = new List<Triangulator2BR.Triangle>();
      sweeplineTriangles.Add(triangle1);
      List<Triangulator2BR.Class96> class96List = new List<Triangulator2BR.Class96>(inputPoints.Count);
      for (int index = 0; index < inputPoints.Count; ++index)
      {
        Triangulator2BR.Class96 class96 = new Triangulator2BR.Class96(inputPoints[index], index);
        class96List.Add(class96);
      }
      class96List.Sort();
      Triangulator2BR.Class97 context = new Triangulator2BR.Class97(triangles1, (IList<Point2BR>) point2BrList);
      for (int index1 = 0; index1 < class96List.Count; ++index1)
      {
        int index2 = class96List[index1].Index;
        int num = Triangulator2BR.smethod_2(context, sweeplineTriangles, index2);
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
        Triangulator2BR.Triangle lastAddedTriangle = (Triangulator2BR.Triangle) null;
        foreach (IList<int> polylinePointIndexes in (IEnumerable<IList<int>>) polylinePointIndexesList)
        {
          int index1 = 0;
          for (int index2 = 1; index2 < polylinePointIndexes.Count; ++index2)
          {
            Triangulator2BR.smethod_7(context, polylinePointIndexes[index1], polylinePointIndexes[index2], ref lastAddedTriangle);
            ++index1;
          }
        }
      }
      if (removeSuperTriangles)
      {
        int superTriangleFirstIndex = point2BrList.Count - 3;
        foreach (Triangulator2BR.Triangle triangle2 in triangles1)
        {
          if (!triangle2.method_33(superTriangleFirstIndex))
            triangles.Add(triangle2);
        }
        point2BrList.RemoveRange(point2BrList.Count - 3, 3);
      }
      else
      {
        for (int index = point2BrList.Count - 3; index < point2BrList.Count; ++index)
          inputPoints.Add(point2BrList[index]);
        foreach (Triangulator2BR.Triangle triangle2 in triangles1)
          triangles.Add(triangle2);
      }
    }

    public static void FilterIgnore(
      IList<Point2BR> points,
      ICollection<Triangulator2BR.Triangle> unfilteredTriangles,
      IList<Triangulator2BR.Triangle> triangles)
    {
      if (unfilteredTriangles.Count == 0)
        return;
      Triangulator2BR.Triangle triangle = Triangulator2BR.smethod_18(points, unfilteredTriangles);
      Triangulator2BR.smethod_0(unfilteredTriangles, points, triangle);
      foreach (Triangulator2BR.Triangle unfilteredTriangle in (IEnumerable<Triangulator2BR.Triangle>) unfilteredTriangles)
      {
        if (unfilteredTriangle.FilterStatus == (byte) 0)
          triangles.Add(unfilteredTriangle);
      }
    }

    public static void FilterNormal(
      IList<Point2BR> points,
      ICollection<Triangulator2BR.Triangle> unfilteredTriangles,
      IList<Triangulator2BR.Triangle> triangles)
    {
      if (unfilteredTriangles.Count == 0)
        return;
      Triangulator2BR.Triangle triangle1 = Triangulator2BR.smethod_18(points, unfilteredTriangles);
      Stack<Triangulator2BR.Class95> class95Stack = new Stack<Triangulator2BR.Class95>();
      class95Stack.Push(new Triangulator2BR.Class95(triangle1, false));
      triangle1.FilterStatus = (byte) 1;
      while (class95Stack.Count > 0)
      {
        Triangulator2BR.Class95 class95 = class95Stack.Pop();
        Triangulator2BR.Triangle triangle2 = class95.Triangle;
        if (triangle2.neighbour0 != null && triangle2.neighbour0.FilterStatus == (byte) 0)
        {
          triangle2.neighbour0.FilterStatus = (byte) 1;
          bool inside;
          if (inside = class95.Inside ^ triangle2.Edge0HasOddFixCount)
            triangles.Add(triangle2.neighbour0);
          class95Stack.Push(new Triangulator2BR.Class95(triangle2.neighbour0, inside));
        }
        if (triangle2.neighbour1 != null && triangle2.neighbour1.FilterStatus == (byte) 0)
        {
          triangle2.neighbour1.FilterStatus = (byte) 1;
          bool inside;
          if (inside = class95.Inside ^ triangle2.Edge1HasOddFixCount)
            triangles.Add(triangle2.neighbour1);
          class95Stack.Push(new Triangulator2BR.Class95(triangle2.neighbour1, inside));
        }
        if (triangle2.neighbour2 != null && triangle2.neighbour2.FilterStatus == (byte) 0)
        {
          triangle2.neighbour2.FilterStatus = (byte) 1;
          bool inside;
          if (inside = class95.Inside ^ triangle2.Edge2HasOddFixCount)
            triangles.Add(triangle2.neighbour2);
          class95Stack.Push(new Triangulator2BR.Class95(triangle2.neighbour2, inside));
        }
      }
    }

    public static void FilterOuter(
      List<Point2BR> points,
      ICollection<Triangulator2BR.Triangle> unfilteredTriangles,
      IList<Triangulator2BR.Triangle> triangles)
    {
      if (unfilteredTriangles.Count == 0)
        return;
      Triangulator2BR.Triangle triangle1 = Triangulator2BR.smethod_18((IList<Point2BR>) points, unfilteredTriangles);
      Triangulator2BR.smethod_0(unfilteredTriangles, (IList<Point2BR>) points, triangle1);
      Stack<Triangulator2BR.Triangle> triangleStack = new Stack<Triangulator2BR.Triangle>();
      triangleStack.Push(triangle1);
      triangle1.FilterStatus = (byte) 2;
      while (triangleStack.Count > 0)
      {
        Triangulator2BR.Triangle triangle2 = triangleStack.Pop();
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

    public static List<Polygon2I> GetPolygons(
      ICollection<Triangulator2BR.Triangle> triangles,
      List<Point2I> points)
    {
      List<Polygon2I> polygon2IList = new List<Polygon2I>();
      foreach (Triangulator2BR.Triangle triangle in (IEnumerable<Triangulator2BR.Triangle>) triangles)
        triangle.FilterStatus = (byte) 0;
      foreach (Triangulator2BR.Triangle triangle in (IEnumerable<Triangulator2BR.Triangle>) triangles)
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
              Polygon2I polygon2I = new Polygon2I();
              int index1 = triangle.method_1((cornerIndex + 1) % 3);
              Point2I point1 = points[index1];
              polygon2I.Add(point1);
              int index2 = triangle.method_1(cornerIndex);
              Point2I point2 = points[index2];
              polygon2I.Add(point2);
              Triangulator2BR.Triangle nextTriangle = triangle;
              while (nextTriangle.method_39(nextEdge, out nextTriangle, out nextEdge))
              {
                int index3 = nextTriangle.method_1(nextEdge);
                if (index3 != index1)
                {
                  polygon2I.Add(points[index3]);
                }
                else
                {
                  polygon2IList.Add(polygon2I);
                  break;
                }
              }
            }
          }
        }
      }
      return polygon2IList;
    }

    private static void smethod_0(
      ICollection<Triangulator2BR.Triangle> triangles,
      IList<Point2BR> points,
      Triangulator2BR.Triangle triangle)
    {
      Stack<Triangulator2BR.Triangle> triangleStack = new Stack<Triangulator2BR.Triangle>();
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
      Triangulator2BR.Class97 context,
      int pointIndex,
      ref Triangulator2BR.Triangle lastAddedTriangle)
    {
      Point2BR point = context.Points[pointIndex];
      int onEdgeFlags;
      Triangulator2BR.Triangle t = Triangulator2BR.smethod_16(context, lastAddedTriangle, point, out onEdgeFlags);
      return Triangulator2BR.smethod_3(context, pointIndex, t, onEdgeFlags, out lastAddedTriangle);
    }

    internal static int smethod_2(
      Triangulator2BR.Class97 context,
      List<Triangulator2BR.Triangle> sweeplineTriangles,
      int pointIndex)
    {
      Point2BR point = context.Points[pointIndex];
      int sweeplineTriangleIndex;
      int onEdgeFlags;
      Triangulator2BR.Triangle t = Triangulator2BR.smethod_17(context, sweeplineTriangles, point, out sweeplineTriangleIndex, out onEdgeFlags);
      return Triangulator2BR.smethod_4(context, sweeplineTriangles, pointIndex, sweeplineTriangleIndex, t, onEdgeFlags);
    }

    private static int smethod_3(
      Triangulator2BR.Class97 context,
      int pointIndex,
      Triangulator2BR.Triangle t,
      int onEdgeFlags,
      out Triangulator2BR.Triangle lastAddedTriangle)
    {
      Point2BR point = context.Points[pointIndex];
      int num = pointIndex;
      Stack<Triangulator2BR.Triangle> triangleStack = new Stack<Triangulator2BR.Triangle>();
      switch (onEdgeFlags)
      {
        case 0:
          context.method_1(t);
          triangleStack = new Stack<Triangulator2BR.Triangle>();
          t.method_3(pointIndex, context, triangleStack);
          break;
        case 1:
          context.method_1(t);
          context.method_1(t.neighbour0);
          Triangulator2BR.Triangle triangle1 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle2 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle3 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle4 = new Triangulator2BR.Triangle();
          triangleStack = new Stack<Triangulator2BR.Triangle>();
          t.method_5(0, pointIndex, context, triangleStack, triangle1, triangle2, triangle3, triangle4);
          t.neighbour0.method_5(t.neighbour0.method_35(t.I1), pointIndex, context, triangleStack, triangle3, triangle4, triangle1, triangle2);
          break;
        case 2:
          context.method_1(t);
          context.method_1(t.neighbour1);
          Triangulator2BR.Triangle triangle5 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle6 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle7 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle8 = new Triangulator2BR.Triangle();
          triangleStack = new Stack<Triangulator2BR.Triangle>();
          t.method_5(1, pointIndex, context, triangleStack, triangle5, triangle6, triangle7, triangle8);
          t.neighbour1.method_5(t.neighbour1.method_35(t.I2), pointIndex, context, triangleStack, triangle7, triangle8, triangle5, triangle6);
          break;
        case 3:
          num = t.I1;
          break;
        case 4:
          context.method_1(t);
          context.method_1(t.neighbour2);
          Triangulator2BR.Triangle triangle9 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle10 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle11 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle12 = new Triangulator2BR.Triangle();
          triangleStack = new Stack<Triangulator2BR.Triangle>();
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
        Triangulator2BR.smethod_5(context, pointIndex, point, triangleStack);
      }
      return num;
    }

    private static int smethod_4(
      Triangulator2BR.Class97 context,
      List<Triangulator2BR.Triangle> sweeplineTriangles,
      int pointIndex,
      int sweeplineTriangleIndex,
      Triangulator2BR.Triangle t,
      int onEdgeFlags)
    {
      Point2BR point = context.Points[pointIndex];
      int num = pointIndex;
      Stack<Triangulator2BR.Triangle> triangleStack = new Stack<Triangulator2BR.Triangle>();
      switch (onEdgeFlags)
      {
        case 0:
          context.method_1(t);
          t.method_4(pointIndex, context, sweeplineTriangles, sweeplineTriangleIndex, triangleStack);
          break;
        case 1:
          context.method_1(t);
          context.method_1(t.neighbour0);
          Triangulator2BR.Triangle triangle1 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle2 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle3 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle4 = new Triangulator2BR.Triangle();
          t.method_6(0, pointIndex, context, sweeplineTriangles, sweeplineTriangleIndex, triangleStack, triangle1, triangle2, triangle3, triangle4);
          t.neighbour0.method_6(t.neighbour0.method_35(t.I1), pointIndex, context, sweeplineTriangles, sweeplineTriangleIndex + 1, triangleStack, triangle3, triangle4, triangle1, triangle2);
          break;
        case 2:
          context.method_1(t);
          context.method_1(t.neighbour1);
          Triangulator2BR.Triangle triangle5 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle6 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle7 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle8 = new Triangulator2BR.Triangle();
          t.method_6(1, pointIndex, context, sweeplineTriangles, sweeplineTriangleIndex, triangleStack, triangle5, triangle6, triangle7, triangle8);
          t.neighbour1.method_6(t.neighbour1.method_35(t.I2), pointIndex, context, (List<Triangulator2BR.Triangle>) null, -1, triangleStack, triangle7, triangle8, triangle5, triangle6);
          break;
        case 3:
          num = t.I1;
          break;
        case 4:
          context.method_1(t);
          context.method_1(t.neighbour2);
          Triangulator2BR.Triangle triangle9 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle10 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle11 = new Triangulator2BR.Triangle();
          Triangulator2BR.Triangle triangle12 = new Triangulator2BR.Triangle();
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
      Triangulator2BR.smethod_6(context, pointIndex, point, triangleStack, sweeplineTriangles);
      return num;
    }

    private static void smethod_5(
      Triangulator2BR.Class97 context,
      int pointIndex,
      Point2BR p,
      Stack<Triangulator2BR.Triangle> tmpTriangles)
    {
      while (tmpTriangles.Count > 0)
      {
        Triangulator2BR.Triangle t = tmpTriangles.Pop();
        if (!t.method_10(pointIndex))
        {
          Triangulator2BR.Triangle oppositeTriangle = t.method_9(pointIndex);
          if (oppositeTriangle != null && oppositeTriangle.method_11(p, context.Points))
          {
            Triangulator2BR.smethod_12(t, oppositeTriangle, pointIndex, context);
            tmpTriangles.Push(t);
            tmpTriangles.Push(oppositeTriangle);
          }
        }
      }
    }

    private static void smethod_6(
      Triangulator2BR.Class97 context,
      int pointIndex,
      Point2BR p,
      Stack<Triangulator2BR.Triangle> tmpTriangles,
      List<Triangulator2BR.Triangle> sweeplineTriangles)
    {
      while (tmpTriangles.Count > 0)
      {
        Triangulator2BR.Triangle t = tmpTriangles.Pop();
        if (!t.method_10(pointIndex))
        {
          Triangulator2BR.Triangle oppositeTriangle = t.method_9(pointIndex);
          if (oppositeTriangle != null && oppositeTriangle.method_11(p, context.Points))
          {
            Triangulator2BR.smethod_13(context, t, oppositeTriangle, pointIndex, sweeplineTriangles);
            tmpTriangles.Push(t);
            tmpTriangles.Push(oppositeTriangle);
          }
        }
      }
    }

    internal static void smethod_7(
      Triangulator2BR.Class97 context,
      int p0,
      int p1,
      ref Triangulator2BR.Triangle lastAddedTriangle)
    {
      int p0_1 = Triangulator2BR.smethod_8(context, p0, p1, ref lastAddedTriangle);
      while (p0_1 != p1)
        p0_1 = Triangulator2BR.smethod_8(context, p0_1, p1, ref lastAddedTriangle);
    }

    private static int smethod_8(
      Triangulator2BR.Class97 context,
      int p0,
      int p1,
      ref Triangulator2BR.Triangle lastAddedTriangle)
    {
      Triangulator2BR.Triangle triangle1;
      if (context.EdgeToTriangle.TryGetValue(new Triangulator2BR.Struct8(p0, p1), out triangle1))
      {
        triangle1.method_14(p0);
        return p1;
      }
      Triangulator2BR.Triangle triangle2 = (Triangulator2BR.Triangle) null;
      HashSet<Triangulator2BR.Triangle> triangleSet;
      if (context.PointIndexToTriangles.TryGetValue(p0, out triangleSet) && triangleSet.Count > 0)
      {
        using (IEnumerator<Triangulator2BR.Triangle> enumerator = (IEnumerator<Triangulator2BR.Triangle>) triangleSet.GetEnumerator())
        {
          enumerator.MoveNext();
          triangle2 = enumerator.Current;
        }
      }
      IList<Point2BR> points = context.Points;
      Triangulator2BR.Triangle t = triangle2.method_19(p0, p1, points);
      if (t == null)
        throw new Exception("Triangle not found.");
      int num1 = p0;
      Point2BR point2Br = points[p0];
      Vector2BR vector2Br1 = points[p1] - point2Br;
      int index = t.method_30(p0);
      Vector2BR vector2Br2 = points[index] - point2Br;
      if ((vector2Br1.X * vector2Br2.Y - vector2Br1.Y * vector2Br2.X).IsZero)
      {
        t.method_15(p0);
        return index;
      }
      int p2 = t.method_29(p0);
      Vector2BR vector2Br3 = points[p2] - point2Br;
      if ((vector2Br1.X * vector2Br3.Y - vector2Br1.Y * vector2Br3.X).IsZero)
      {
        t.method_15(p2);
        return p2;
      }
      context.method_1(t);
      List<int> intList1 = new List<int>();
      List<int> intList2 = new List<int>();
      List<Triangulator2BR.Triangle> outerNeighbours1 = new List<Triangulator2BR.Triangle>();
      List<Triangulator2BR.Triangle> outerNeighbours2 = new List<Triangulator2BR.Triangle>();
      intList2.Insert(0, t.method_29(p0));
      intList1.Add(t.method_30(p0));
      Triangulator2BR.Triangle triangle3 = t.method_31(num1);
      outerNeighbours1.Add(triangle3);
      Triangulator2BR.Triangle triangle4 = t.method_32(num1);
      outerNeighbours2.Add(triangle4);
      int num2 = p1;
      while (!t.method_27(num2))
      {
        Triangulator2BR.Triangle triangle5 = t.method_9(num1);
        if (triangle5 == null)
          throw new Exception("No opposite triangle.");
        int p3 = triangle5.method_28(t);
        if (p3 != num2)
        {
          Vector2BR vector2Br4 = points[p3] - point2Br;
          BigRational bigRational = vector2Br1.X * vector2Br4.Y - vector2Br1.Y * vector2Br4.X;
          if (bigRational.IsPositive)
          {
            intList1.Add(p3);
            num1 = triangle5.method_29(p3);
            Triangulator2BR.Triangle triangle6 = triangle5.method_31(num1);
            outerNeighbours1.Add(triangle6);
          }
          else if (bigRational.IsNegative)
          {
            intList2.Insert(0, p3);
            num1 = triangle5.method_30(p3);
            Triangulator2BR.Triangle triangle6 = triangle5.method_32(num1);
            outerNeighbours2.Insert(0, triangle6);
          }
          else
            num2 = p3;
        }
        t = triangle5;
        context.method_1(t);
      }
      Triangulator2BR.Triangle triangle7 = t.method_31(num2);
      outerNeighbours2.Insert(0, triangle7);
      Triangulator2BR.Triangle triangle8 = t.method_32(num2);
      outerNeighbours1.Add(triangle8);
      List<Triangulator2BR.Triangle> triangleList1 = new List<Triangulator2BR.Triangle>();
      Triangulator2BR.Triangle triangle9 = Triangulator2BR.smethod_11(context, intList1, num2, p0, (Triangulator2BR.Triangle) null, points, triangleList1);
      List<Triangulator2BR.Triangle> triangleList2 = new List<Triangulator2BR.Triangle>();
      Triangulator2BR.Triangle triangle10 = Triangulator2BR.smethod_11(context, intList2, p0, num2, (Triangulator2BR.Triangle) null, points, triangleList2);
      triangle9.method_7(num2, triangle10);
      triangle9.method_15(num2);
      triangle10.method_7(p0, triangle9);
      triangle10.method_15(p0);
      lastAddedTriangle = triangle9;
      intList1.Insert(0, p0);
      intList1.Add(num2);
      Triangulator2BR.smethod_10(triangleList1, intList1, outerNeighbours1);
      intList2.Insert(0, num2);
      intList2.Add(p0);
      Triangulator2BR.smethod_10(triangleList2, intList2, outerNeighbours2);
      return num2;
    }

    internal static Triangulator2BR.Triangle smethod_9(IList<Point2BR> points)
    {
      Bounds2BR bounds2Br = new Bounds2BR();
      bounds2Br.Update(points);
      BigRational bigRational = BigMath.Max(bounds2Br.Delta.X, bounds2Br.Delta.Y);
      Point2BR center = bounds2Br.Center;
      Point2BR point2Br1 = center + new Vector2BR(BigRational.Zero, Triangulator2BR.bigRational_1 * bigRational);
      Point2BR point2Br2 = center + new Vector2BR(BigRational.Two * bigRational, Triangulator2BR.bigRational_2 * bigRational);
      Point2BR point2Br3 = center + new Vector2BR(BigRational.MinusTwo * bigRational, Triangulator2BR.bigRational_2 * bigRational);
      int count = points.Count;
      points.Add(point2Br2);
      points.Add(point2Br3);
      points.Add(point2Br1);
      return Triangulator2BR.Triangle.CreateAndAssertClockwise(count + 2, count, count + 1, points);
    }

    private static void smethod_10(
      List<Triangulator2BR.Triangle> innerTriangles,
      List<int> outerPoints,
      List<Triangulator2BR.Triangle> outerNeighbours)
    {
      int num = outerPoints[0];
      for (int index = 0; index < outerNeighbours.Count; ++index)
      {
        Triangulator2BR.Triangle outerNeighbour = outerNeighbours[index];
        int outerPoint = outerPoints[index + 1];
        bool flag = false;
        foreach (Triangulator2BR.Triangle innerTriangle in innerTriangles)
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

    private static Triangulator2BR.Triangle smethod_11(
      Triangulator2BR.Class97 context,
      List<int> polygonPoints,
      int p0,
      int p1,
      Triangulator2BR.Triangle neighbour,
      IList<Point2BR> points,
      List<Triangulator2BR.Triangle> newTriangles)
    {
      Triangulator2BR.Triangle triangle1 = (Triangulator2BR.Triangle) null;
      if (polygonPoints.Count > 0)
      {
        int capacity = 0;
        int index1 = polygonPoints[0];
        if (polygonPoints.Count > 1)
        {
          Point2BR point1 = points[p0];
          Point2BR point2 = points[p1];
          Point2BR point3 = points[index1];
          for (int index2 = 1; index2 < polygonPoints.Count; ++index2)
          {
            int polygonPoint = polygonPoints[index2];
            if (Triangulator2BR.Triangle.smethod_0(points[polygonPoint], point1, point2, point3))
            {
              capacity = index2;
              index1 = polygonPoint;
              point3 = points[index1];
            }
          }
          Triangulator2BR.Triangle triangle2 = triangle1 = Triangulator2BR.Triangle.CreateAndAssertClockwise(p0, p1, index1, points);
          triangle2.neighbour0 = neighbour;
          neighbour?.method_7(p1, triangle2);
          context.method_0(triangle2);
          newTriangles.Add(triangle2);
          List<int> polygonPoints1 = new List<int>(capacity);
          for (int index2 = 0; index2 < capacity; ++index2)
            polygonPoints1.Add(polygonPoints[index2]);
          Triangulator2BR.smethod_11(context, polygonPoints1, index1, p1, triangle2, points, newTriangles);
          List<int> polygonPoints2 = new List<int>(polygonPoints.Count - capacity - 1);
          for (int index2 = capacity + 1; index2 < polygonPoints.Count; ++index2)
            polygonPoints2.Add(polygonPoints[index2]);
          Triangulator2BR.smethod_11(context, polygonPoints2, p0, index1, triangle2, points, newTriangles);
        }
        else
        {
          Triangulator2BR.Triangle triangle2 = triangle1 = Triangulator2BR.Triangle.CreateAndAssertClockwise(p0, p1, index1, points);
          triangle2.neighbour0 = neighbour;
          neighbour?.method_7(p1, triangle2);
          context.method_0(triangle2);
          newTriangles.Add(triangle2);
        }
      }
      return triangle1;
    }

    private static void smethod_12(
      Triangulator2BR.Triangle t,
      Triangulator2BR.Triangle oppositeTriangle,
      int pointIndex,
      Triangulator2BR.Class97 context)
    {
      context.method_4(t);
      context.method_4(oppositeTriangle);
      int num = pointIndex;
      byte edge0FixCount;
      Triangulator2BR.Triangle neighbour0;
      int p1;
      byte edge1FixCount;
      Triangulator2BR.Triangle neighbour1;
      int p2;
      byte edge2FixCount;
      Triangulator2BR.Triangle neighbour2;
      int p3;
      byte edge3FixCount;
      Triangulator2BR.Triangle neighbour3;
      t.method_12(num, oppositeTriangle, out edge0FixCount, out neighbour0, out p1, out edge1FixCount, out neighbour1, out p2, out edge2FixCount, out neighbour2, out p3, out edge3FixCount, out neighbour3);
      t.Init(num, edge0FixCount, neighbour0, p1, edge1FixCount, neighbour1, p2, (byte) 0, oppositeTriangle, context.Points);
      oppositeTriangle.Init(num, (byte) 0, t, p2, edge2FixCount, neighbour2, p3, edge3FixCount, neighbour3, context.Points);
      neighbour1?.method_7(p2, t);
      neighbour3?.method_7(num, oppositeTriangle);
      context.method_3(t);
      context.method_3(oppositeTriangle);
    }

    private static void smethod_13(
      Triangulator2BR.Class97 context,
      Triangulator2BR.Triangle t,
      Triangulator2BR.Triangle oppositeTriangle,
      int pointIndex,
      List<Triangulator2BR.Triangle> sweeplineTriangles)
    {
      context.method_4(t);
      context.method_4(oppositeTriangle);
      IList<Point2BR> points = context.Points;
      int num = pointIndex;
      byte edge0FixCount;
      Triangulator2BR.Triangle neighbour0;
      int p1;
      byte edge1FixCount;
      Triangulator2BR.Triangle neighbour1;
      int p2;
      byte edge2FixCount;
      Triangulator2BR.Triangle neighbour2;
      int p3;
      byte edge3FixCount;
      Triangulator2BR.Triangle neighbour3;
      t.method_12(num, oppositeTriangle, out edge0FixCount, out neighbour0, out p1, out edge1FixCount, out neighbour1, out p2, out edge2FixCount, out neighbour2, out p3, out edge3FixCount, out neighbour3);
      int sweepTrianglePointIndex = context.Points.Count - 1;
      bool flag1 = t.method_34(sweepTrianglePointIndex);
      Triangulator2BR.Triangle from1 = new Triangulator2BR.Triangle();
      from1.Init(num, edge0FixCount, neighbour0, p1, edge1FixCount, neighbour1, p2, (byte) 0, oppositeTriangle, points);
      from1.method_38(sweepTrianglePointIndex);
      bool flag2 = from1.method_34(sweepTrianglePointIndex);
      bool flag3 = oppositeTriangle.method_34(sweepTrianglePointIndex);
      Triangulator2BR.Triangle from2 = new Triangulator2BR.Triangle();
      from2.Init(num, (byte) 0, t, p2, edge2FixCount, neighbour2, p3, edge3FixCount, neighbour3, points);
      from2.method_38(sweepTrianglePointIndex);
      bool flag4 = from2.method_34(sweepTrianglePointIndex);
      if (flag2)
      {
        if (flag4)
        {
          oppositeTriangle.method_40(from2);
          if (!flag3)
            Triangulator2BR.smethod_14(sweeplineTriangles, points, oppositeTriangle);
        }
        else
        {
          if (flag3)
            Triangulator2BR.smethod_15(sweeplineTriangles, points, oppositeTriangle);
          oppositeTriangle.method_40(from2);
        }
        t.method_40(from1);
        if (!flag1)
          Triangulator2BR.smethod_14(sweeplineTriangles, points, t);
      }
      else
      {
        if (flag1)
          Triangulator2BR.smethod_15(sweeplineTriangles, points, t);
        t.method_40(from1);
        if (flag4)
        {
          oppositeTriangle.method_40(from2);
          if (!flag3)
            Triangulator2BR.smethod_14(sweeplineTriangles, points, oppositeTriangle);
        }
        else
        {
          if (flag3)
            Triangulator2BR.smethod_15(sweeplineTriangles, points, oppositeTriangle);
          oppositeTriangle.method_40(from2);
        }
      }
      neighbour1?.method_7(p2, t);
      neighbour3?.method_7(num, oppositeTriangle);
      context.method_3(t);
      context.method_3(oppositeTriangle);
    }

    private static void smethod_14(
      List<Triangulator2BR.Triangle> sweeplineTriangles,
      IList<Point2BR> points,
      Triangulator2BR.Triangle t)
    {
      sweeplineTriangles.Insert(sweeplineTriangles.BinarySearch(t, (IComparer<Triangulator2BR.Triangle>) new Triangulator2BR.Triangle.Class94(points)), t);
    }

    private static void smethod_15(
      List<Triangulator2BR.Triangle> sweeplineTriangles,
      IList<Point2BR> points,
      Triangulator2BR.Triangle t)
    {
      sweeplineTriangles.RemoveAt(sweeplineTriangles.BinarySearch(t, (IComparer<Triangulator2BR.Triangle>) new Triangulator2BR.Triangle.Class94(points)));
    }

    private static Triangulator2BR.Triangle smethod_16(
      Triangulator2BR.Class97 context,
      Triangulator2BR.Triangle startTriangle,
      Point2BR p,
      out int onEdgeFlags)
    {
      Triangulator2BR.Triangle triangle1 = startTriangle;
      int skipEdgeIndex = -1;
      int count = context.Triangles.Count;
      while (--count >= 0)
      {
        int outsideEdgeIndex;
        if (triangle1.method_2(p, context.Points, skipEdgeIndex, out onEdgeFlags, out outsideEdgeIndex))
          return triangle1;
        Triangulator2BR.Triangle triangle2 = triangle1;
        triangle1 = triangle1.method_36(outsideEdgeIndex);
        if (triangle1 != null)
          skipEdgeIndex = triangle1.method_35(triangle2.method_37(outsideEdgeIndex));
        else
          break;
      }
      onEdgeFlags = 0;
      return (Triangulator2BR.Triangle) null;
    }

    private static Triangulator2BR.Triangle smethod_17(
      Triangulator2BR.Class97 context,
      List<Triangulator2BR.Triangle> sweeplineTriangles,
      Point2BR p,
      out int sweeplineTriangleIndex,
      out int onEdgeFlags)
    {
      int index1 = 0;
      int num = sweeplineTriangles.Count - 1;
      while (index1 < num)
      {
        int index2 = index1 + (num - index1 >> 1);
        Triangulator2BR.Triangle sweeplineTriangle = sweeplineTriangles[index2];
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
      Triangulator2BR.Triangle sweeplineTriangle1 = sweeplineTriangles[index1];
      int outsideEdgeIndex1;
      if (sweeplineTriangle1.method_2(p, context.Points, 1, out onEdgeFlags, out outsideEdgeIndex1))
      {
        sweeplineTriangleIndex = index1;
        return sweeplineTriangle1;
      }
      sweeplineTriangleIndex = -1;
      onEdgeFlags = 0;
      return (Triangulator2BR.Triangle) null;
    }

    private static Triangulator2BR.Triangle smethod_18(
      IList<Point2BR> points,
      ICollection<Triangulator2BR.Triangle> unfilteredTriangles)
    {
      int superTriangleFirstIndex = points.Count - 3;
      Triangulator2BR.Triangle triangle = (Triangulator2BR.Triangle) null;
      foreach (Triangulator2BR.Triangle unfilteredTriangle in (IEnumerable<Triangulator2BR.Triangle>) unfilteredTriangles)
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
    private static void smethod_19(ICollection<Triangulator2BR.Triangle> triangles)
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
      public Triangulator2BR.Triangle neighbour0;
      public Triangulator2BR.Triangle neighbour1;
      public Triangulator2BR.Triangle neighbour2;
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

      public Triangle(int i0, int i1, int i2, IList<Point2BR> points)
      {
        Vector2BR vector2Br1 = points[i1] - points[i0];
        Vector2BR vector2Br2 = points[i2] - points[i0];
        if (!(vector2Br1.X * vector2Br2.Y - vector2Br1.Y * vector2Br2.X).IsNegative)
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

      public static Triangulator2BR.Triangle CreateAndAssertClockwise(
        int i0,
        int i1,
        int i2,
        IList<Point2BR> points)
      {
        return new Triangulator2BR.Triangle(i0, i1, i2);
      }

      public void Init(int i0, int i1, int i2, IList<Point2BR> points)
      {
        this.i0 = i0;
        this.i1 = i1;
        this.i2 = i2;
      }

      public void Init(
        int i0,
        byte edge0FixCount,
        Triangulator2BR.Triangle neighbour0,
        int i1,
        byte edge1FixCount,
        Triangulator2BR.Triangle neighbour1,
        int i2,
        byte edge2FixCount,
        Triangulator2BR.Triangle neighbour2,
        IList<Point2BR> points)
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

      internal bool method_0(Point2BR p, IList<Point2BR> points, out int onEdgeFlags)
      {
        return Triangle2BR.ContainsPoint(p, points[this.i0], points[this.i1], points[this.i2], out onEdgeFlags);
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
        Point2BR p,
        IList<Point2BR> points,
        int skipEdgeIndex,
        out int onEdgeFlags,
        out int outsideEdgeIndex)
      {
        return Triangle2BR.ContainsPoint(p, points[this.i0], points[this.i1], points[this.i2], skipEdgeIndex, out onEdgeFlags, out outsideEdgeIndex);
      }

      internal void method_3(
        int pointIndex,
        Triangulator2BR.Class97 context,
        Stack<Triangulator2BR.Triangle> triangleStack)
      {
        this.method_4(pointIndex, context, (List<Triangulator2BR.Triangle>) null, -1, triangleStack);
      }

      internal void method_4(
        int pointIndex,
        Triangulator2BR.Class97 context,
        List<Triangulator2BR.Triangle> sweeplineTriangles,
        int sweeplineTriangleIndex,
        Stack<Triangulator2BR.Triangle> triangleStack)
      {
        Triangulator2BR.Triangle triangle1 = new Triangulator2BR.Triangle();
        Triangulator2BR.Triangle triangle2 = new Triangulator2BR.Triangle();
        Triangulator2BR.Triangle triangle3 = new Triangulator2BR.Triangle();
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
        Triangulator2BR.Class97 context,
        Stack<Triangulator2BR.Triangle> tmpTriangles,
        Triangulator2BR.Triangle t1,
        Triangulator2BR.Triangle t2,
        Triangulator2BR.Triangle t3,
        Triangulator2BR.Triangle t4)
      {
        this.method_6(cornerIndex, pointIndex, context, (List<Triangulator2BR.Triangle>) null, -1, tmpTriangles, t1, t2, t3, t4);
      }

      internal void method_6(
        int cornerIndex,
        int pointIndex,
        Triangulator2BR.Class97 context,
        List<Triangulator2BR.Triangle> sweeplineTriangles,
        int sweeplineTriangleIndex,
        Stack<Triangulator2BR.Triangle> tmpTriangles,
        Triangulator2BR.Triangle t1,
        Triangulator2BR.Triangle t2,
        Triangulator2BR.Triangle t3,
        Triangulator2BR.Triangle t4)
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

      internal void method_7(int edgeFirstPointIndex, Triangulator2BR.Triangle triangle)
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

      internal bool method_8(int e0, int e1, Triangulator2BR.Triangle triangle)
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

      internal Triangulator2BR.Triangle method_9(int pointIndex)
      {
        if (pointIndex == this.i0)
          return this.neighbour1;
        if (pointIndex == this.i1)
          return this.neighbour2;
        if (pointIndex == this.i2)
          return this.neighbour0;
        return (Triangulator2BR.Triangle) null;
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

      internal bool method_11(Point2BR p, IList<Point2BR> points)
      {
        Point2BR point1 = points[this.i0];
        Point2BR point2 = points[this.i1];
        Point2BR point3 = points[this.i2];
        return Triangulator2BR.Triangle.smethod_0(p, point1, point2, point3);
      }

      internal static bool smethod_0(Point2BR p, Point2BR a, Point2BR b, Point2BR c)
      {
        BigRational m00 = a.X - p.X;
        BigRational m01 = a.Y - p.Y;
        BigRational m10 = b.X - p.X;
        BigRational m11 = b.Y - p.Y;
        BigRational m20 = c.X - p.X;
        BigRational m21 = c.Y - p.Y;
        return new Matrix3BR(m00, m01, m00 * m00 + m01 * m01, m10, m11, m10 * m10 + m11 * m11, m20, m21, m20 * m20 + m21 * m21).GetDeterminant().IsNegative;
      }

      internal void method_12(
        int p,
        Triangulator2BR.Triangle opposedTriangle,
        out byte edge0FixCount,
        out Triangulator2BR.Triangle neighbour0,
        out int p1,
        out byte edge1FixCount,
        out Triangulator2BR.Triangle neighbour1,
        out int p2,
        out byte edge2FixCount,
        out Triangulator2BR.Triangle neighbour2,
        out int p3,
        out byte edge3FixCount,
        out Triangulator2BR.Triangle neighbour3)
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
        out Triangulator2BR.Triangle neighbour0,
        out int p1,
        out byte edge1FixCount,
        out Triangulator2BR.Triangle neighbour1)
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

      internal Triangulator2BR.Triangle method_19(
        int p0,
        int p1,
        IList<Point2BR> points)
      {
        Triangulator2BR.Triangle triangle1 = this;
        Point2BR point = points[p0];
        Vector2BR p01 = points[p1] - point;
        Triangulator2BR.Triangle triangle2;
        do
        {
          triangle2 = triangle1;
          int oppositePoint0;
          int oppositePoint1;
          triangle1 = triangle2.method_26(p0, out oppositePoint0, out oppositePoint1);
          if (Triangulator2BR.Triangle.smethod_1(point, p01, oppositePoint0, oppositePoint1, points))
            goto label_4;
        }
        while (triangle1 != null && triangle1 != this);
        throw new Exception("Couldn't find triangle containing segment.");
label_4:
        return triangle2;
      }

      internal void method_20(
        Dictionary<Triangulator2BR.Struct8, Triangulator2BR.Triangle> edgeToTriangle)
      {
        edgeToTriangle.Add(new Triangulator2BR.Struct8(this.i0, this.i1), this);
        edgeToTriangle.Add(new Triangulator2BR.Struct8(this.i1, this.i2), this);
        edgeToTriangle.Add(new Triangulator2BR.Struct8(this.i2, this.i0), this);
      }

      internal void method_21(
        Dictionary<Triangulator2BR.Struct8, Triangulator2BR.Triangle> edgeToTriangle)
      {
        edgeToTriangle.Remove(new Triangulator2BR.Struct8(this.i0, this.i1));
        edgeToTriangle.Remove(new Triangulator2BR.Struct8(this.i1, this.i2));
        edgeToTriangle.Remove(new Triangulator2BR.Struct8(this.i2, this.i0));
      }

      internal void method_22(
        Dictionary<int, HashSet<Triangulator2BR.Triangle>> pointIndexToTriangles)
      {
        this.method_23(this.i0, pointIndexToTriangles);
        this.method_23(this.i1, pointIndexToTriangles);
        this.method_23(this.i2, pointIndexToTriangles);
      }

      private void method_23(
        int i,
        Dictionary<int, HashSet<Triangulator2BR.Triangle>> pointIndexToTriangles)
      {
        HashSet<Triangulator2BR.Triangle> triangleSet;
        if (!pointIndexToTriangles.TryGetValue(i, out triangleSet))
        {
          triangleSet = new HashSet<Triangulator2BR.Triangle>();
          pointIndexToTriangles.Add(i, triangleSet);
        }
        triangleSet.Add(this);
      }

      internal void method_24(
        Dictionary<int, HashSet<Triangulator2BR.Triangle>> pointIndexToTriangles)
      {
        this.method_25(this.i0, pointIndexToTriangles);
        this.method_25(this.i1, pointIndexToTriangles);
        this.method_25(this.i2, pointIndexToTriangles);
      }

      private void method_25(
        int i,
        Dictionary<int, HashSet<Triangulator2BR.Triangle>> pointIndexToTriangles)
      {
        HashSet<Triangulator2BR.Triangle> triangleSet;
        if (!pointIndexToTriangles.TryGetValue(i, out triangleSet))
          return;
        triangleSet.Remove(this);
      }

      private Triangulator2BR.Triangle method_26(
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
        Point2BR p0,
        Vector2BR p01,
        int q0,
        int q1,
        IList<Point2BR> points)
      {
        Point2BR point1 = points[q0];
        Point2BR point2 = points[q1];
        Vector2BR vector2Br1 = point2 - point1;
        Vector2BR u = new Vector2BR(vector2Br1.Y, -vector2Br1.X);
        int sign1 = Vector2BR.DotProduct(u, p01).Sign;
        int sign2 = Vector2BR.DotProduct(u, p0 - point1).Sign;
        if (sign2 != -sign1 && sign2 != 0)
          return false;
        Vector2BR vector2Br2 = point1 - p0;
        Vector2BR vector2Br3 = point2 - p0;
        int sign3 = (vector2Br2.X * p01.Y - vector2Br2.Y * p01.X).Sign;
        int sign4 = (vector2Br3.X * p01.Y - vector2Br3.Y * p01.X).Sign;
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

      internal int method_28(Triangulator2BR.Triangle t)
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

      internal Triangulator2BR.Triangle method_31(int p)
      {
        if (p == this.i0)
          return this.neighbour0;
        if (p == this.i1)
          return this.neighbour1;
        if (p != this.i2)
          throw new InternalException("Given point is not part of this triangle.");
        return this.neighbour2;
      }

      internal Triangulator2BR.Triangle method_32(int p)
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

      internal Triangulator2BR.Triangle method_36(int neighbourIndex)
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
          Triangulator2BR.Triangle neighbour0 = this.neighbour0;
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
          Triangulator2BR.Triangle neighbour0 = this.neighbour0;
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
        out Triangulator2BR.Triangle nextTriangle,
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
        Triangulator2BR.Triangle triangle1 = this;
        int num2 = this.method_1(edge);
        for (Triangulator2BR.Triangle triangle2 = triangle1.method_32(num2); triangle2 != null && triangle2 != this; triangle2 = triangle2.method_32(num2))
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
        nextTriangle = (Triangulator2BR.Triangle) null;
        nextEdge = -1;
        return false;
      }

      internal void method_40(Triangulator2BR.Triangle from)
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

      internal class Class94 : IComparer<Triangulator2BR.Triangle>
      {
        private IList<Point2BR> ilist_0;

        public Class94(IList<Point2BR> points)
        {
          this.ilist_0 = points;
        }

        public int Compare(Triangulator2BR.Triangle a, Triangulator2BR.Triangle b)
        {
          if (a == b)
            return 0;
          Point2BR point2Br1 = this.ilist_0[a.i0];
          Point2BR point2Br2 = this.ilist_0[a.i1];
          Point2BR point2Br3 = this.ilist_0[b.i1];
          return Vector2BR.CrossProduct(point2Br2 - point2Br1, point2Br3 - point2Br1).IsPositive ? -1 : 1;
        }
      }
    }

    private class Class95
    {
      private Triangulator2BR.Triangle triangle_0;
      private bool bool_0;

      public Class95(Triangulator2BR.Triangle triangle, bool inside)
      {
        this.triangle_0 = triangle;
        this.bool_0 = inside;
      }

      public Triangulator2BR.Triangle Triangle
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

    private class Class96 : IComparable<Triangulator2BR.Class96>
    {
      private Point2BR point2BR_0;
      private int int_0;

      public Class96(Point2BR position, int index)
      {
        this.point2BR_0 = position;
        this.int_0 = index;
      }

      public int Index
      {
        get
        {
          return this.int_0;
        }
      }

      public int CompareTo(Triangulator2BR.Class96 other)
      {
        if (this.point2BR_0.Y < other.point2BR_0.Y)
          return -1;
        return this.point2BR_0.Y > other.point2BR_0.Y ? 1 : 0;
      }
    }

    internal struct Struct8
    {
      public int int_0;
      public int int_1;

      public Struct8(int p0, int p1)
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
        if (obj is Triangulator2BR.Struct8)
        {
          Triangulator2BR.Struct8 struct8 = (Triangulator2BR.Struct8) obj;
          flag = this.int_0 == struct8.int_0 && this.int_1 == struct8.int_1;
        }
        else
          flag = false;
        return flag;
      }
    }

    internal class Class97
    {
      private HashSet<Triangulator2BR.Triangle> hashSet_0;
      private IList<Point2BR> ilist_0;
      private Dictionary<int, HashSet<Triangulator2BR.Triangle>> dictionary_0;
      private Dictionary<Triangulator2BR.Struct8, Triangulator2BR.Triangle> dictionary_1;

      public Class97(HashSet<Triangulator2BR.Triangle> triangles, IList<Point2BR> points)
      {
        this.hashSet_0 = triangles;
        this.ilist_0 = points;
      }

      public HashSet<Triangulator2BR.Triangle> Triangles
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

      public IList<Point2BR> Points
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

      public Dictionary<int, HashSet<Triangulator2BR.Triangle>> PointIndexToTriangles
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

      public Dictionary<Triangulator2BR.Struct8, Triangulator2BR.Triangle> EdgeToTriangle
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

      public void method_0(Triangulator2BR.Triangle t)
      {
        this.hashSet_0.Add(t);
        this.method_3(t);
      }

      public void method_1(Triangulator2BR.Triangle t)
      {
        this.hashSet_0.Remove(t);
        this.method_4(t);
      }

      internal void method_2(bool initializeFromTriangles)
      {
        this.dictionary_1 = new Dictionary<Triangulator2BR.Struct8, Triangulator2BR.Triangle>();
        this.dictionary_0 = new Dictionary<int, HashSet<Triangulator2BR.Triangle>>();
        foreach (Triangulator2BR.Triangle triangle in this.hashSet_0)
        {
          triangle.method_20(this.dictionary_1);
          triangle.method_22(this.dictionary_0);
        }
      }

      internal void method_3(Triangulator2BR.Triangle t)
      {
        if (this.dictionary_1 != null)
          t.method_20(this.dictionary_1);
        if (this.dictionary_0 == null)
          return;
        t.method_22(this.dictionary_0);
      }

      internal void method_4(Triangulator2BR.Triangle t)
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
