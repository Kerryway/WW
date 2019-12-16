// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.Triangulator2I
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
  public static class Triangulator2I
  {
    public const int MaxInt = 1048575;

    static Triangulator2I()
    {
      Class123.smethod_0(Enum0.const_3);
    }

    public static void Triangulate(
      IList<IList<Point2I>> polygons,
      IList<Triangulator2I.Triangle> triangles,
      IList<Point2I> points)
    {
      if (polygons.Count == 0)
        return;
      Dictionary<Point2I, int> dictionary = new Dictionary<Point2I, int>();
      List<List<int>> intListList = new List<List<int>>(polygons.Count);
      int count1 = points.Count;
      foreach (IList<Point2I> polygon in (IEnumerable<IList<Point2I>>) polygons)
      {
        int count2 = polygon.Count;
        if (polygon.Count > 1 && polygon[count2 - 1] == polygon[0])
          --count2;
        List<int> intList = new List<int>(count2);
        intListList.Add(intList);
        for (int index = 0; index < count2; ++index)
        {
          Point2I key = polygon[index];
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
      Triangulator2I.Triangle triangle = Triangulator2I.smethod_9(points);
      HashSet<Triangulator2I.Triangle> triangles1 = new HashSet<Triangulator2I.Triangle>();
      triangles1.Add(triangle);
      Triangulator2I.Class189 context = new Triangulator2I.Class189(triangles1, points);
      context.method_2(true);
      Triangulator2I.Triangle lastAddedTriangle = triangle;
      for (int index1 = 0; index1 < intListList.Count; ++index1)
      {
        List<int> intList = intListList[index1];
        int num1 = intList[0];
        Triangulator2I.smethod_1(context, num1, ref lastAddedTriangle);
        for (int index2 = 1; index2 < intList.Count; ++index2)
        {
          int num2 = intList[index2];
          Triangulator2I.smethod_1(context, num2, ref lastAddedTriangle);
          Triangulator2I.smethod_7(context, num1, num2, ref lastAddedTriangle);
          num1 = num2;
        }
        int p1 = intList[0];
        Triangulator2I.smethod_7(context, num1, p1, ref lastAddedTriangle);
      }
      Triangulator2I.FilterNormal(points, (ICollection<Triangulator2I.Triangle>) triangles1, triangles);
      points.RemoveAt(points.Count - 1);
      points.RemoveAt(points.Count - 1);
      points.RemoveAt(points.Count - 1);
    }

    public static void Triangulate(
      IList<Point2I> inputPoints,
      IList<IList<int>> polylinePointIndexesList,
      IList<Triangulator2I.Triangle> triangles)
    {
      Triangulator2I.Triangulate(inputPoints, polylinePointIndexesList, triangles, true);
    }

    public static void Triangulate(
      IList<Point2I> inputPoints,
      IList<IList<int>> polylinePointIndexesList,
      IList<Triangulator2I.Triangle> triangles,
      bool removeSuperTriangles)
    {
      if (inputPoints.Count == 0)
        return;
      List<Point2I> point2IList = new List<Point2I>(inputPoints.Count + 3);
      point2IList.AddRange((IEnumerable<Point2I>) inputPoints);
      Triangulator2I.Triangle triangle1 = Triangulator2I.smethod_9((IList<Point2I>) point2IList);
      HashSet<Triangulator2I.Triangle> triangles1 = new HashSet<Triangulator2I.Triangle>();
      triangles1.Add(triangle1);
      List<Triangulator2I.Triangle> sweeplineTriangles = new List<Triangulator2I.Triangle>();
      sweeplineTriangles.Add(triangle1);
      List<Triangulator2I.Class188> class188List = new List<Triangulator2I.Class188>(inputPoints.Count);
      for (int index = 0; index < inputPoints.Count; ++index)
      {
        Triangulator2I.Class188 class188 = new Triangulator2I.Class188(inputPoints[index], index);
        class188List.Add(class188);
      }
      class188List.Sort();
      Triangulator2I.Class189 context = new Triangulator2I.Class189(triangles1, (IList<Point2I>) point2IList);
      for (int index1 = 0; index1 < class188List.Count; ++index1)
      {
        int index2 = class188List[index1].Index;
        int num = Triangulator2I.smethod_2(context, sweeplineTriangles, index2);
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
        Triangulator2I.Triangle lastAddedTriangle = (Triangulator2I.Triangle) null;
        foreach (IList<int> polylinePointIndexes in (IEnumerable<IList<int>>) polylinePointIndexesList)
        {
          int index1 = 0;
          for (int index2 = 1; index2 < polylinePointIndexes.Count; ++index2)
          {
            Triangulator2I.smethod_7(context, polylinePointIndexes[index1], polylinePointIndexes[index2], ref lastAddedTriangle);
            ++index1;
          }
        }
      }
      if (removeSuperTriangles)
      {
        int superTriangleFirstIndex = point2IList.Count - 3;
        foreach (Triangulator2I.Triangle triangle2 in triangles1)
        {
          if (!triangle2.method_33(superTriangleFirstIndex))
            triangles.Add(triangle2);
        }
        point2IList.RemoveRange(point2IList.Count - 3, 3);
      }
      else
      {
        for (int index = point2IList.Count - 3; index < point2IList.Count; ++index)
          inputPoints.Add(point2IList[index]);
        foreach (Triangulator2I.Triangle triangle2 in triangles1)
          triangles.Add(triangle2);
      }
    }

    public static void FilterIgnore(
      IList<Point2I> points,
      ICollection<Triangulator2I.Triangle> unfilteredTriangles,
      IList<Triangulator2I.Triangle> triangles)
    {
      if (unfilteredTriangles.Count == 0)
        return;
      Triangulator2I.Triangle triangle = Triangulator2I.smethod_18(points, unfilteredTriangles);
      Triangulator2I.smethod_0(unfilteredTriangles, points, triangle);
      foreach (Triangulator2I.Triangle unfilteredTriangle in (IEnumerable<Triangulator2I.Triangle>) unfilteredTriangles)
      {
        if (unfilteredTriangle.FilterStatus == (byte) 0)
          triangles.Add(unfilteredTriangle);
      }
    }

    public static void FilterNormal(
      IList<Point2I> points,
      ICollection<Triangulator2I.Triangle> unfilteredTriangles,
      IList<Triangulator2I.Triangle> triangles)
    {
      if (unfilteredTriangles.Count == 0)
        return;
      Triangulator2I.Triangle triangle1 = Triangulator2I.smethod_18(points, unfilteredTriangles);
      Stack<Triangulator2I.Class187> class187Stack = new Stack<Triangulator2I.Class187>();
      class187Stack.Push(new Triangulator2I.Class187(triangle1, false));
      triangle1.FilterStatus = (byte) 1;
      List<Triangulator2I.Triangle> triangleList = new List<Triangulator2I.Triangle>();
      while (class187Stack.Count > 0)
      {
        Triangulator2I.Class187 class187 = class187Stack.Pop();
        Triangulator2I.Triangle triangle2 = class187.Triangle;
        if (triangle2.neighbour0 != null && triangle2.neighbour0.FilterStatus == (byte) 0)
        {
          triangle2.neighbour0.FilterStatus = (byte) 1;
          bool inside;
          if (inside = class187.Inside ^ triangle2.Edge0HasOddFixCount)
            triangles.Add(triangle2.neighbour0);
          else
            triangleList.Add(triangle2.neighbour0);
          class187Stack.Push(new Triangulator2I.Class187(triangle2.neighbour0, inside));
        }
        if (triangle2.neighbour1 != null && triangle2.neighbour1.FilterStatus == (byte) 0)
        {
          triangle2.neighbour1.FilterStatus = (byte) 1;
          bool inside;
          if (inside = class187.Inside ^ triangle2.Edge1HasOddFixCount)
            triangles.Add(triangle2.neighbour1);
          else
            triangleList.Add(triangle2.neighbour1);
          class187Stack.Push(new Triangulator2I.Class187(triangle2.neighbour1, inside));
        }
        if (triangle2.neighbour2 != null && triangle2.neighbour2.FilterStatus == (byte) 0)
        {
          triangle2.neighbour2.FilterStatus = (byte) 1;
          bool inside;
          if (inside = class187.Inside ^ triangle2.Edge2HasOddFixCount)
            triangles.Add(triangle2.neighbour2);
          else
            triangleList.Add(triangle2.neighbour2);
          class187Stack.Push(new Triangulator2I.Class187(triangle2.neighbour2, inside));
        }
      }
      foreach (Triangulator2I.Triangle triangle2 in triangleList)
        triangle2.method_42();
    }

    public static void FilterOuter(
      List<Point2I> points,
      ICollection<Triangulator2I.Triangle> unfilteredTriangles,
      IList<Triangulator2I.Triangle> triangles)
    {
      if (unfilteredTriangles.Count == 0)
        return;
      Triangulator2I.Triangle triangle1 = Triangulator2I.smethod_18((IList<Point2I>) points, unfilteredTriangles);
      Triangulator2I.smethod_0(unfilteredTriangles, (IList<Point2I>) points, triangle1);
      Stack<Triangulator2I.Triangle> triangleStack = new Stack<Triangulator2I.Triangle>();
      triangleStack.Push(triangle1);
      triangle1.FilterStatus = (byte) 2;
      while (triangleStack.Count > 0)
      {
        Triangulator2I.Triangle triangle2 = triangleStack.Pop();
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
      ICollection<Triangulator2I.Triangle> triangles,
      List<Point2I> points)
    {
      List<Polygon2I> polygon2IList = new List<Polygon2I>();
      foreach (Triangulator2I.Triangle triangle in (IEnumerable<Triangulator2I.Triangle>) triangles)
        triangle.FilterStatus = (byte) 0;
      Triangulator2I.Class190[] class190Array = new Triangulator2I.Class190[points.Count];
      for (int index = 0; index < points.Count; ++index)
        class190Array[index] = new Triangulator2I.Class190(points[index]);
      LinkedList<Triangulator2I.Class190> pointChain = new LinkedList<Triangulator2I.Class190>();
      foreach (Triangulator2I.Triangle triangle in (IEnumerable<Triangulator2I.Triangle>) triangles)
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
              int index1 = triangle.method_1((cornerIndex + 1) % 3);
              class190Array[index1].method_0(pointChain);
              int index2 = triangle.method_1(cornerIndex);
              class190Array[index2].method_0(pointChain);
              Triangulator2I.Triangle nextTriangle = triangle;
              while (nextTriangle.method_40(nextEdge, out nextTriangle, out nextEdge))
              {
                int index3 = nextTriangle.method_1(nextEdge);
                Polygon2I polygon2I = class190Array[index3].method_0(pointChain);
                if (polygon2I != null)
                  polygon2IList.Add(polygon2I);
              }
              if (pointChain.Count != 1)
                throw new Exception("Point chain should be empty.");
              pointChain.First.Value.PointNode = (LinkedListNode<Triangulator2I.Class190>) null;
              pointChain.Clear();
            }
          }
        }
      }
      return polygon2IList;
    }

    private static void smethod_0(
      ICollection<Triangulator2I.Triangle> triangles,
      IList<Point2I> points,
      Triangulator2I.Triangle triangle)
    {
      Stack<Triangulator2I.Triangle> triangleStack = new Stack<Triangulator2I.Triangle>();
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
      Triangulator2I.Class189 context,
      int pointIndex,
      ref Triangulator2I.Triangle lastAddedTriangle)
    {
      Point2I point = context.Points[pointIndex];
      int onEdgeFlags;
      Triangulator2I.Triangle t = Triangulator2I.smethod_16(context, lastAddedTriangle, point, out onEdgeFlags);
      return Triangulator2I.smethod_3(context, pointIndex, t, onEdgeFlags, out lastAddedTriangle);
    }

    internal static int smethod_2(
      Triangulator2I.Class189 context,
      List<Triangulator2I.Triangle> sweeplineTriangles,
      int pointIndex)
    {
      Point2I point = context.Points[pointIndex];
      int sweeplineTriangleIndex;
      int onEdgeFlags;
      Triangulator2I.Triangle t = Triangulator2I.smethod_17(context, sweeplineTriangles, point, out sweeplineTriangleIndex, out onEdgeFlags);
      return Triangulator2I.smethod_4(context, sweeplineTriangles, pointIndex, sweeplineTriangleIndex, t, onEdgeFlags);
    }

    private static int smethod_3(
      Triangulator2I.Class189 context,
      int pointIndex,
      Triangulator2I.Triangle t,
      int onEdgeFlags,
      out Triangulator2I.Triangle lastAddedTriangle)
    {
      Point2I point = context.Points[pointIndex];
      int num = pointIndex;
      Stack<Triangulator2I.Triangle> triangleStack = (Stack<Triangulator2I.Triangle>) null;
      switch (onEdgeFlags)
      {
        case 0:
          context.method_1(t);
          triangleStack = new Stack<Triangulator2I.Triangle>();
          t.method_3(pointIndex, context, triangleStack);
          break;
        case 1:
          context.method_1(t);
          context.method_1(t.neighbour0);
          Triangulator2I.Triangle triangle1 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle2 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle3 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle4 = new Triangulator2I.Triangle();
          triangleStack = new Stack<Triangulator2I.Triangle>();
          t.method_5(0, pointIndex, context, triangleStack, triangle1, triangle2, triangle3, triangle4);
          t.neighbour0.method_5(t.neighbour0.method_36(t.I1), pointIndex, context, triangleStack, triangle3, triangle4, triangle1, triangle2);
          break;
        case 2:
          context.method_1(t);
          context.method_1(t.neighbour1);
          Triangulator2I.Triangle triangle5 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle6 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle7 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle8 = new Triangulator2I.Triangle();
          triangleStack = new Stack<Triangulator2I.Triangle>();
          t.method_5(1, pointIndex, context, triangleStack, triangle5, triangle6, triangle7, triangle8);
          t.neighbour1.method_5(t.neighbour1.method_36(t.I2), pointIndex, context, triangleStack, triangle7, triangle8, triangle5, triangle6);
          break;
        case 3:
          num = t.I1;
          break;
        case 4:
          context.method_1(t);
          context.method_1(t.neighbour2);
          Triangulator2I.Triangle triangle9 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle10 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle11 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle12 = new Triangulator2I.Triangle();
          triangleStack = new Stack<Triangulator2I.Triangle>();
          t.method_5(2, pointIndex, context, triangleStack, triangle9, triangle10, triangle11, triangle12);
          t.neighbour2.method_5(t.neighbour2.method_36(t.I0), pointIndex, context, triangleStack, triangle11, triangle12, triangle9, triangle10);
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
        Triangulator2I.smethod_5(context, pointIndex, point, triangleStack);
      }
      return num;
    }

    private static int smethod_4(
      Triangulator2I.Class189 context,
      List<Triangulator2I.Triangle> sweeplineTriangles,
      int pointIndex,
      int sweeplineTriangleIndex,
      Triangulator2I.Triangle t,
      int onEdgeFlags)
    {
      Point2I point = context.Points[pointIndex];
      int num = pointIndex;
      Stack<Triangulator2I.Triangle> triangleStack = new Stack<Triangulator2I.Triangle>();
      switch (onEdgeFlags)
      {
        case 0:
          context.method_1(t);
          t.method_4(pointIndex, context, sweeplineTriangles, sweeplineTriangleIndex, triangleStack);
          break;
        case 1:
          context.method_1(t);
          context.method_1(t.neighbour0);
          Triangulator2I.Triangle triangle1 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle2 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle3 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle4 = new Triangulator2I.Triangle();
          t.method_6(0, pointIndex, context, sweeplineTriangles, sweeplineTriangleIndex, triangleStack, triangle1, triangle2, triangle3, triangle4);
          t.neighbour0.method_6(t.neighbour0.method_36(t.I1), pointIndex, context, sweeplineTriangles, sweeplineTriangleIndex + 1, triangleStack, triangle3, triangle4, triangle1, triangle2);
          break;
        case 2:
          context.method_1(t);
          context.method_1(t.neighbour1);
          Triangulator2I.Triangle triangle5 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle6 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle7 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle8 = new Triangulator2I.Triangle();
          t.method_6(1, pointIndex, context, sweeplineTriangles, sweeplineTriangleIndex, triangleStack, triangle5, triangle6, triangle7, triangle8);
          t.neighbour1.method_6(t.neighbour1.method_36(t.I2), pointIndex, context, (List<Triangulator2I.Triangle>) null, -1, triangleStack, triangle7, triangle8, triangle5, triangle6);
          break;
        case 3:
          num = t.I1;
          break;
        case 4:
          context.method_1(t);
          context.method_1(t.neighbour2);
          Triangulator2I.Triangle triangle9 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle10 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle11 = new Triangulator2I.Triangle();
          Triangulator2I.Triangle triangle12 = new Triangulator2I.Triangle();
          t.method_6(2, pointIndex, context, sweeplineTriangles, sweeplineTriangleIndex, triangleStack, triangle9, triangle10, triangle11, triangle12);
          t.neighbour2.method_6(t.neighbour2.method_36(t.I0), pointIndex, context, sweeplineTriangles, sweeplineTriangleIndex - 1, triangleStack, triangle11, triangle12, triangle9, triangle10);
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
      Triangulator2I.smethod_6(context, pointIndex, point, triangleStack, sweeplineTriangles);
      return num;
    }

    private static void smethod_5(
      Triangulator2I.Class189 context,
      int pointIndex,
      Point2I p,
      Stack<Triangulator2I.Triangle> tmpTriangles)
    {
      while (tmpTriangles.Count > 0)
      {
        Triangulator2I.Triangle t = tmpTriangles.Pop();
        if (!t.method_10(pointIndex))
        {
          Triangulator2I.Triangle oppositeTriangle = t.method_9(pointIndex);
          if (oppositeTriangle != null && oppositeTriangle.method_11(p, context.Points))
          {
            Triangulator2I.smethod_12(t, oppositeTriangle, pointIndex, context);
            tmpTriangles.Push(t);
            tmpTriangles.Push(oppositeTriangle);
          }
        }
      }
    }

    private static void smethod_6(
      Triangulator2I.Class189 context,
      int pointIndex,
      Point2I p,
      Stack<Triangulator2I.Triangle> tmpTriangles,
      List<Triangulator2I.Triangle> sweeplineTriangles)
    {
      while (tmpTriangles.Count > 0)
      {
        Triangulator2I.Triangle t = tmpTriangles.Pop();
        if (!t.method_10(pointIndex))
        {
          Triangulator2I.Triangle oppositeTriangle = t.method_9(pointIndex);
          if (oppositeTriangle != null && oppositeTriangle.method_11(p, context.Points))
          {
            Triangulator2I.smethod_13(context, t, oppositeTriangle, pointIndex, sweeplineTriangles);
            tmpTriangles.Push(t);
            tmpTriangles.Push(oppositeTriangle);
          }
        }
      }
    }

    internal static void smethod_7(
      Triangulator2I.Class189 context,
      int p0,
      int p1,
      ref Triangulator2I.Triangle lastAddedTriangle)
    {
      int p0_1 = Triangulator2I.smethod_8(context, p0, p1, ref lastAddedTriangle);
      while (p0_1 != p1)
        p0_1 = Triangulator2I.smethod_8(context, p0_1, p1, ref lastAddedTriangle);
    }

    private static int smethod_8(
      Triangulator2I.Class189 context,
      int p0,
      int p1,
      ref Triangulator2I.Triangle lastAddedTriangle)
    {
      Triangulator2I.Triangle triangle1;
      if (context.EdgeToTriangle.TryGetValue(new Triangulator2I.Struct11(p0, p1), out triangle1))
      {
        triangle1.method_14(p0);
        return p1;
      }
      Triangulator2I.Triangle triangle2 = (Triangulator2I.Triangle) null;
      HashSet<Triangulator2I.Triangle> triangleSet;
      if (context.PointIndexToTriangles.TryGetValue(p0, out triangleSet) && triangleSet.Count > 0)
      {
        using (IEnumerator<Triangulator2I.Triangle> enumerator = (IEnumerator<Triangulator2I.Triangle>) triangleSet.GetEnumerator())
        {
          enumerator.MoveNext();
          triangle2 = enumerator.Current;
        }
      }
      IList<Point2I> points = context.Points;
      Triangulator2I.Triangle t = triangle2.method_19(p0, p1, points);
      if (t == null)
        throw new Exception("Triangle not found.");
      int num1 = p0;
      Point2I point2I = points[p0];
      Vector2I vector2I1 = points[p1] - point2I;
      int index = t.method_30(p0);
      Vector2I vector2I2 = points[index] - point2I;
      if ((long) vector2I1.X * (long) vector2I2.Y - (long) vector2I1.Y * (long) vector2I2.X == 0L)
      {
        t.method_15(p0);
        return index;
      }
      int p2 = t.method_29(p0);
      Vector2I vector2I3 = points[p2] - point2I;
      if ((long) vector2I1.X * (long) vector2I3.Y - (long) vector2I1.Y * (long) vector2I3.X == 0L)
      {
        t.method_15(p2);
        return p2;
      }
      context.method_1(t);
      List<int> intList1 = new List<int>();
      List<int> intList2 = new List<int>();
      List<Triangulator2I.Triangle> outerNeighbours1 = new List<Triangulator2I.Triangle>();
      List<Triangulator2I.Triangle> outerNeighbours2 = new List<Triangulator2I.Triangle>();
      intList2.Insert(0, t.method_29(p0));
      intList1.Add(t.method_30(p0));
      Triangulator2I.Triangle triangle3 = t.method_31(num1);
      outerNeighbours1.Add(triangle3);
      Triangulator2I.Triangle triangle4 = t.method_32(num1);
      outerNeighbours2.Add(triangle4);
      int num2 = p1;
      while (!t.method_27(num2))
      {
        Triangulator2I.Triangle triangle5 = t.method_9(num1);
        if (triangle5 == null)
          throw new Exception("No opposite triangle.");
        int p3 = triangle5.method_28(t);
        if (p3 != num2)
        {
          Vector2I vector2I4 = points[p3] - point2I;
          long num3 = (long) vector2I1.X * (long) vector2I4.Y - (long) vector2I1.Y * (long) vector2I4.X;
          if (num3 > 0L)
          {
            intList1.Add(p3);
            num1 = triangle5.method_29(p3);
            Triangulator2I.Triangle triangle6 = triangle5.method_31(num1);
            outerNeighbours1.Add(triangle6);
          }
          else if (num3 < 0L)
          {
            intList2.Insert(0, p3);
            num1 = triangle5.method_30(p3);
            Triangulator2I.Triangle triangle6 = triangle5.method_32(num1);
            outerNeighbours2.Insert(0, triangle6);
          }
          else
            num2 = p3;
        }
        t = triangle5;
        context.method_1(t);
      }
      Triangulator2I.Triangle triangle7 = t.method_31(num2);
      outerNeighbours2.Insert(0, triangle7);
      Triangulator2I.Triangle triangle8 = t.method_32(num2);
      outerNeighbours1.Add(triangle8);
      List<Triangulator2I.Triangle> triangleList1 = new List<Triangulator2I.Triangle>();
      Triangulator2I.Triangle triangle9 = Triangulator2I.smethod_11(context, intList1, num2, p0, (Triangulator2I.Triangle) null, points, triangleList1);
      List<Triangulator2I.Triangle> triangleList2 = new List<Triangulator2I.Triangle>();
      Triangulator2I.Triangle triangle10 = Triangulator2I.smethod_11(context, intList2, p0, num2, (Triangulator2I.Triangle) null, points, triangleList2);
      triangle9.method_7(num2, triangle10);
      triangle9.method_15(num2);
      triangle10.method_7(p0, triangle9);
      triangle10.method_15(p0);
      lastAddedTriangle = triangle9;
      intList1.Insert(0, p0);
      intList1.Add(num2);
      Triangulator2I.smethod_10(triangleList1, intList1, outerNeighbours1);
      intList2.Insert(0, num2);
      intList2.Add(p0);
      Triangulator2I.smethod_10(triangleList2, intList2, outerNeighbours2);
      return num2;
    }

    internal static Triangulator2I.Triangle smethod_9(IList<Point2I> points)
    {
      Point2I point2I1 = new Point2I(0, 4194303);
      Point2I point2I2 = new Point2I(4194303, -4194303);
      Point2I point2I3 = new Point2I(-4194303, -4194303);
      int count = points.Count;
      points.Add(point2I2);
      points.Add(point2I3);
      points.Add(point2I1);
      return Triangulator2I.Triangle.CreateAndAssertClockwise(count + 2, count, count + 1, points);
    }

    private static void smethod_10(
      List<Triangulator2I.Triangle> innerTriangles,
      List<int> outerPoints,
      List<Triangulator2I.Triangle> outerNeighbours)
    {
      int num = outerPoints[0];
      for (int index = 0; index < outerNeighbours.Count; ++index)
      {
        Triangulator2I.Triangle outerNeighbour = outerNeighbours[index];
        int outerPoint = outerPoints[index + 1];
        bool flag = false;
        foreach (Triangulator2I.Triangle innerTriangle in innerTriangles)
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

    private static Triangulator2I.Triangle smethod_11(
      Triangulator2I.Class189 context,
      List<int> polygonPoints,
      int p0,
      int p1,
      Triangulator2I.Triangle neighbour,
      IList<Point2I> points,
      List<Triangulator2I.Triangle> newTriangles)
    {
      Triangulator2I.Triangle triangle1 = (Triangulator2I.Triangle) null;
      if (polygonPoints.Count > 0)
      {
        int capacity = 0;
        int index1 = polygonPoints[0];
        if (polygonPoints.Count > 1)
        {
          Point2I point1 = points[p0];
          Point2I point2 = points[p1];
          Point2I point3 = points[index1];
          for (int index2 = 1; index2 < polygonPoints.Count; ++index2)
          {
            int polygonPoint = polygonPoints[index2];
            if (Triangulator2I.Triangle.smethod_0(points[polygonPoint], point1, point2, point3))
            {
              capacity = index2;
              index1 = polygonPoint;
              point3 = points[index1];
            }
          }
          Triangulator2I.Triangle triangle2 = triangle1 = Triangulator2I.Triangle.CreateAndAssertClockwise(p0, p1, index1, points);
          triangle2.neighbour0 = neighbour;
          neighbour?.method_7(p1, triangle2);
          context.method_0(triangle2);
          newTriangles.Add(triangle2);
          List<int> polygonPoints1 = new List<int>(capacity);
          for (int index2 = 0; index2 < capacity; ++index2)
            polygonPoints1.Add(polygonPoints[index2]);
          Triangulator2I.smethod_11(context, polygonPoints1, index1, p1, triangle2, points, newTriangles);
          List<int> polygonPoints2 = new List<int>(polygonPoints.Count - capacity - 1);
          for (int index2 = capacity + 1; index2 < polygonPoints.Count; ++index2)
            polygonPoints2.Add(polygonPoints[index2]);
          Triangulator2I.smethod_11(context, polygonPoints2, p0, index1, triangle2, points, newTriangles);
        }
        else
        {
          Triangulator2I.Triangle triangle2 = triangle1 = Triangulator2I.Triangle.CreateAndAssertClockwise(p0, p1, index1, points);
          triangle2.neighbour0 = neighbour;
          neighbour?.method_7(p1, triangle2);
          context.method_0(triangle2);
          newTriangles.Add(triangle2);
        }
      }
      return triangle1;
    }

    private static void smethod_12(
      Triangulator2I.Triangle t,
      Triangulator2I.Triangle oppositeTriangle,
      int pointIndex,
      Triangulator2I.Class189 context)
    {
      context.method_4(t);
      context.method_4(oppositeTriangle);
      int num = pointIndex;
      byte edge0FixCount;
      Triangulator2I.Triangle neighbour0;
      int p1;
      byte edge1FixCount;
      Triangulator2I.Triangle neighbour1;
      int p2;
      byte edge2FixCount;
      Triangulator2I.Triangle neighbour2;
      int p3;
      byte edge3FixCount;
      Triangulator2I.Triangle neighbour3;
      t.method_12(num, oppositeTriangle, out edge0FixCount, out neighbour0, out p1, out edge1FixCount, out neighbour1, out p2, out edge2FixCount, out neighbour2, out p3, out edge3FixCount, out neighbour3);
      t.Init(num, edge0FixCount, neighbour0, p1, edge1FixCount, neighbour1, p2, (byte) 0, oppositeTriangle, context.Points);
      oppositeTriangle.Init(num, (byte) 0, t, p2, edge2FixCount, neighbour2, p3, edge3FixCount, neighbour3, context.Points);
      neighbour1?.method_7(p2, t);
      neighbour3?.method_7(num, oppositeTriangle);
      context.method_3(t);
      context.method_3(oppositeTriangle);
    }

    private static void smethod_13(
      Triangulator2I.Class189 context,
      Triangulator2I.Triangle t,
      Triangulator2I.Triangle oppositeTriangle,
      int pointIndex,
      List<Triangulator2I.Triangle> sweeplineTriangles)
    {
      context.method_4(t);
      context.method_4(oppositeTriangle);
      IList<Point2I> points = context.Points;
      int num = pointIndex;
      byte edge0FixCount;
      Triangulator2I.Triangle neighbour0;
      int p1;
      byte edge1FixCount;
      Triangulator2I.Triangle neighbour1;
      int p2;
      byte edge2FixCount;
      Triangulator2I.Triangle neighbour2;
      int p3;
      byte edge3FixCount;
      Triangulator2I.Triangle neighbour3;
      t.method_12(num, oppositeTriangle, out edge0FixCount, out neighbour0, out p1, out edge1FixCount, out neighbour1, out p2, out edge2FixCount, out neighbour2, out p3, out edge3FixCount, out neighbour3);
      int sweepTrianglePointIndex = context.Points.Count - 1;
      bool flag1 = t.method_34(sweepTrianglePointIndex);
      Triangulator2I.Triangle from1 = new Triangulator2I.Triangle();
      from1.Init(num, edge0FixCount, neighbour0, p1, edge1FixCount, neighbour1, p2, (byte) 0, oppositeTriangle, points);
      from1.method_39(sweepTrianglePointIndex);
      bool flag2 = from1.method_34(sweepTrianglePointIndex);
      bool flag3 = oppositeTriangle.method_34(sweepTrianglePointIndex);
      Triangulator2I.Triangle from2 = new Triangulator2I.Triangle();
      from2.Init(num, (byte) 0, t, p2, edge2FixCount, neighbour2, p3, edge3FixCount, neighbour3, points);
      from2.method_39(sweepTrianglePointIndex);
      bool flag4 = from2.method_34(sweepTrianglePointIndex);
      if (flag2)
      {
        if (flag4)
        {
          oppositeTriangle.method_41(from2);
          if (!flag3)
            Triangulator2I.smethod_14(sweeplineTriangles, points, oppositeTriangle);
        }
        else
        {
          if (flag3)
            Triangulator2I.smethod_15(sweeplineTriangles, points, oppositeTriangle);
          oppositeTriangle.method_41(from2);
        }
        t.method_41(from1);
        if (!flag1)
          Triangulator2I.smethod_14(sweeplineTriangles, points, t);
      }
      else
      {
        if (flag1)
          Triangulator2I.smethod_15(sweeplineTriangles, points, t);
        t.method_41(from1);
        if (flag4)
        {
          oppositeTriangle.method_41(from2);
          if (!flag3)
            Triangulator2I.smethod_14(sweeplineTriangles, points, oppositeTriangle);
        }
        else
        {
          if (flag3)
            Triangulator2I.smethod_15(sweeplineTriangles, points, oppositeTriangle);
          oppositeTriangle.method_41(from2);
        }
      }
      neighbour1?.method_7(p2, t);
      neighbour3?.method_7(num, oppositeTriangle);
      context.method_3(t);
      context.method_3(oppositeTriangle);
    }

    private static void smethod_14(
      List<Triangulator2I.Triangle> sweeplineTriangles,
      IList<Point2I> points,
      Triangulator2I.Triangle t)
    {
      sweeplineTriangles.Insert(sweeplineTriangles.BinarySearch(t, (IComparer<Triangulator2I.Triangle>) new Triangulator2I.Triangle.Class186(points)), t);
    }

    private static void smethod_15(
      List<Triangulator2I.Triangle> sweeplineTriangles,
      IList<Point2I> points,
      Triangulator2I.Triangle t)
    {
      sweeplineTriangles.RemoveAt(sweeplineTriangles.BinarySearch(t, (IComparer<Triangulator2I.Triangle>) new Triangulator2I.Triangle.Class186(points)));
    }

    private static Triangulator2I.Triangle smethod_16(
      Triangulator2I.Class189 context,
      Triangulator2I.Triangle startTriangle,
      Point2I p,
      out int onEdgeFlags)
    {
      Triangulator2I.Triangle triangle1 = startTriangle;
      int skipEdgeIndex = -1;
      int count = context.Triangles.Count;
      while (--count >= 0)
      {
        int outsideEdgeIndex;
        if (triangle1.method_2(p, context.Points, skipEdgeIndex, out onEdgeFlags, out outsideEdgeIndex))
          return triangle1;
        Triangulator2I.Triangle triangle2 = triangle1;
        triangle1 = triangle1.method_37(outsideEdgeIndex);
        if (triangle1 != null)
          skipEdgeIndex = triangle1.method_36(triangle2.method_38(outsideEdgeIndex));
        else
          break;
      }
      onEdgeFlags = 0;
      return (Triangulator2I.Triangle) null;
    }

    private static Triangulator2I.Triangle smethod_17(
      Triangulator2I.Class189 context,
      List<Triangulator2I.Triangle> sweeplineTriangles,
      Point2I p,
      out int sweeplineTriangleIndex,
      out int onEdgeFlags)
    {
      int index1 = 0;
      int num = sweeplineTriangles.Count - 1;
      while (index1 < num)
      {
        int index2 = index1 + (num - index1 >> 1);
        Triangulator2I.Triangle sweeplineTriangle = sweeplineTriangles[index2];
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
      Triangulator2I.Triangle sweeplineTriangle1 = sweeplineTriangles[index1];
      int outsideEdgeIndex1;
      if (sweeplineTriangle1.method_2(p, context.Points, 1, out onEdgeFlags, out outsideEdgeIndex1))
      {
        sweeplineTriangleIndex = index1;
        return sweeplineTriangle1;
      }
      sweeplineTriangleIndex = -1;
      onEdgeFlags = 0;
      return (Triangulator2I.Triangle) null;
    }

    private static Triangulator2I.Triangle smethod_18(
      IList<Point2I> points,
      ICollection<Triangulator2I.Triangle> unfilteredTriangles)
    {
      int superTriangleFirstIndex = points.Count - 3;
      Triangulator2I.Triangle triangle = (Triangulator2I.Triangle) null;
      foreach (Triangulator2I.Triangle unfilteredTriangle in (IEnumerable<Triangulator2I.Triangle>) unfilteredTriangles)
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
    private static void smethod_19(ICollection<Triangulator2I.Triangle> triangles)
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
      public Triangulator2I.Triangle neighbour0;
      public Triangulator2I.Triangle neighbour1;
      public Triangulator2I.Triangle neighbour2;
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

      public Triangle(int i0, int i1, int i2, IList<Point2I> points)
      {
        Vector2I vector2I1 = points[i1] - points[i0];
        Vector2I vector2I2 = points[i2] - points[i0];
        if ((long) vector2I1.X * (long) vector2I2.Y - (long) vector2I1.Y * (long) vector2I2.X >= 0L)
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

      public static Triangulator2I.Triangle CreateAndAssertClockwise(
        int i0,
        int i1,
        int i2,
        IList<Point2I> points)
      {
        return new Triangulator2I.Triangle(i0, i1, i2);
      }

      public void Init(int i0, int i1, int i2, IList<Point2I> points)
      {
        this.i0 = i0;
        this.i1 = i1;
        this.i2 = i2;
      }

      public void Init(
        int i0,
        byte edge0FixCount,
        Triangulator2I.Triangle neighbour0,
        int i1,
        byte edge1FixCount,
        Triangulator2I.Triangle neighbour1,
        int i2,
        byte edge2FixCount,
        Triangulator2I.Triangle neighbour2,
        IList<Point2I> points)
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

      internal bool method_0(Point2I p, IList<Point2I> points, out int onEdgeFlags)
      {
        return Triangle2I.ContainsPoint(p, points[this.i0], points[this.i1], points[this.i2], out onEdgeFlags);
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
        Point2I p,
        IList<Point2I> points,
        int skipEdgeIndex,
        out int onEdgeFlags,
        out int outsideEdgeIndex)
      {
        return Triangle2I.ContainsPoint(p, points[this.i0], points[this.i1], points[this.i2], skipEdgeIndex, out onEdgeFlags, out outsideEdgeIndex);
      }

      internal void method_3(
        int pointIndex,
        Triangulator2I.Class189 context,
        Stack<Triangulator2I.Triangle> triangleStack)
      {
        this.method_4(pointIndex, context, (List<Triangulator2I.Triangle>) null, -1, triangleStack);
      }

      internal void method_4(
        int pointIndex,
        Triangulator2I.Class189 context,
        List<Triangulator2I.Triangle> sweeplineTriangles,
        int sweeplineTriangleIndex,
        Stack<Triangulator2I.Triangle> triangleStack)
      {
        Triangulator2I.Triangle triangle1 = new Triangulator2I.Triangle();
        Triangulator2I.Triangle triangle2 = new Triangulator2I.Triangle();
        Triangulator2I.Triangle triangle3 = new Triangulator2I.Triangle();
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
        Triangulator2I.Class189 context,
        Stack<Triangulator2I.Triangle> tmpTriangles,
        Triangulator2I.Triangle t1,
        Triangulator2I.Triangle t2,
        Triangulator2I.Triangle t3,
        Triangulator2I.Triangle t4)
      {
        this.method_6(cornerIndex, pointIndex, context, (List<Triangulator2I.Triangle>) null, -1, tmpTriangles, t1, t2, t3, t4);
      }

      internal void method_6(
        int cornerIndex,
        int pointIndex,
        Triangulator2I.Class189 context,
        List<Triangulator2I.Triangle> sweeplineTriangles,
        int sweeplineTriangleIndex,
        Stack<Triangulator2I.Triangle> tmpTriangles,
        Triangulator2I.Triangle t1,
        Triangulator2I.Triangle t2,
        Triangulator2I.Triangle t3,
        Triangulator2I.Triangle t4)
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

      internal void method_7(int edgeFirstPointIndex, Triangulator2I.Triangle triangle)
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

      internal bool method_8(int e0, int e1, Triangulator2I.Triangle triangle)
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

      internal Triangulator2I.Triangle method_9(int pointIndex)
      {
        if (pointIndex == this.i0)
          return this.neighbour1;
        if (pointIndex == this.i1)
          return this.neighbour2;
        if (pointIndex == this.i2)
          return this.neighbour0;
        return (Triangulator2I.Triangle) null;
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

      internal bool method_11(Point2I p, IList<Point2I> points)
      {
        Point2I point1 = points[this.i0];
        Point2I point2 = points[this.i1];
        Point2I point3 = points[this.i2];
        return Triangulator2I.Triangle.smethod_0(p, point1, point2, point3);
      }

      internal static bool smethod_0(Point2I p, Point2I a, Point2I b, Point2I c)
      {
        int num1 = a.X - p.X;
        int num2 = a.Y - p.Y;
        int num3 = b.X - p.X;
        int num4 = b.Y - p.Y;
        int num5 = c.X - p.X;
        int num6 = c.Y - p.Y;
        Decimal num7 = (Decimal) num1;
        Decimal num8 = (Decimal) num2;
        Decimal num9 = (Decimal) ((long) num1 * (long) num1 + (long) num2 * (long) num2);
        Decimal num10 = (Decimal) num3;
        Decimal num11 = (Decimal) num4;
        Decimal num12 = (Decimal) ((long) num3 * (long) num3 + (long) num4 * (long) num4);
        Decimal num13 = (Decimal) num5;
        Decimal num14 = (Decimal) num6;
        Decimal num15 = (Decimal) ((long) num5 * (long) num5 + (long) num6 * (long) num6);
        return num7 * num11 * num15 + num8 * num12 * num13 + num9 * num10 * num14 - num9 * num11 * num13 - num7 * num12 * num14 - num8 * num10 * num15 < new Decimal(0);
      }

      internal void method_12(
        int p,
        Triangulator2I.Triangle opposedTriangle,
        out byte edge0FixCount,
        out Triangulator2I.Triangle neighbour0,
        out int p1,
        out byte edge1FixCount,
        out Triangulator2I.Triangle neighbour1,
        out int p2,
        out byte edge2FixCount,
        out Triangulator2I.Triangle neighbour2,
        out int p3,
        out byte edge3FixCount,
        out Triangulator2I.Triangle neighbour3)
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
        out Triangulator2I.Triangle neighbour0,
        out int p1,
        out byte edge1FixCount,
        out Triangulator2I.Triangle neighbour1)
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

      internal Triangulator2I.Triangle method_19(
        int p0,
        int p1,
        IList<Point2I> points)
      {
        Triangulator2I.Triangle triangle1 = this;
        Point2I point = points[p0];
        Vector2I p01 = points[p1] - point;
        Triangulator2I.Triangle triangle2;
        do
        {
          triangle2 = triangle1;
          int oppositePoint0;
          int oppositePoint1;
          triangle1 = triangle2.method_26(p0, out oppositePoint0, out oppositePoint1);
          if (Triangulator2I.Triangle.smethod_1(point, p01, oppositePoint0, oppositePoint1, points))
            goto label_4;
        }
        while (triangle1 != null && triangle1 != this);
        throw new Exception("Couldn't find triangle containing segment.");
label_4:
        return triangle2;
      }

      internal void method_20(
        Dictionary<Triangulator2I.Struct11, Triangulator2I.Triangle> edgeToTriangle)
      {
        edgeToTriangle.Add(new Triangulator2I.Struct11(this.i0, this.i1), this);
        edgeToTriangle.Add(new Triangulator2I.Struct11(this.i1, this.i2), this);
        edgeToTriangle.Add(new Triangulator2I.Struct11(this.i2, this.i0), this);
      }

      internal void method_21(
        Dictionary<Triangulator2I.Struct11, Triangulator2I.Triangle> edgeToTriangle)
      {
        edgeToTriangle.Remove(new Triangulator2I.Struct11(this.i0, this.i1));
        edgeToTriangle.Remove(new Triangulator2I.Struct11(this.i1, this.i2));
        edgeToTriangle.Remove(new Triangulator2I.Struct11(this.i2, this.i0));
      }

      internal void method_22(
        Dictionary<int, HashSet<Triangulator2I.Triangle>> pointIndexToTriangles)
      {
        this.method_23(this.i0, pointIndexToTriangles);
        this.method_23(this.i1, pointIndexToTriangles);
        this.method_23(this.i2, pointIndexToTriangles);
      }

      private void method_23(
        int i,
        Dictionary<int, HashSet<Triangulator2I.Triangle>> pointIndexToTriangles)
      {
        HashSet<Triangulator2I.Triangle> triangleSet;
        if (!pointIndexToTriangles.TryGetValue(i, out triangleSet))
        {
          triangleSet = new HashSet<Triangulator2I.Triangle>();
          pointIndexToTriangles.Add(i, triangleSet);
        }
        triangleSet.Add(this);
      }

      internal void method_24(
        Dictionary<int, HashSet<Triangulator2I.Triangle>> pointIndexToTriangles)
      {
        this.method_25(this.i0, pointIndexToTriangles);
        this.method_25(this.i1, pointIndexToTriangles);
        this.method_25(this.i2, pointIndexToTriangles);
      }

      private void method_25(
        int i,
        Dictionary<int, HashSet<Triangulator2I.Triangle>> pointIndexToTriangles)
      {
        HashSet<Triangulator2I.Triangle> triangleSet;
        if (!pointIndexToTriangles.TryGetValue(i, out triangleSet))
          return;
        triangleSet.Remove(this);
      }

      private Triangulator2I.Triangle method_26(
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
        Point2I p0,
        Vector2I p01,
        int q0,
        int q1,
        IList<Point2I> points)
      {
        Point2I point1 = points[q0];
        Point2I point2 = points[q1];
        Vector2I vector2I1 = point2 - point1;
        Vector2I u = new Vector2I(vector2I1.Y, -vector2I1.X);
        int num1 = System.Math.Sign(Vector2I.DotProduct(u, p01));
        int num2 = System.Math.Sign(Vector2I.DotProduct(u, p0 - point1));
        if (num2 != -num1 && num2 != 0)
          return false;
        Vector2I vector2I2 = point1 - p0;
        Vector2I vector2I3 = point2 - p0;
        int num3 = System.Math.Sign((long) vector2I2.X * (long) p01.Y - (long) vector2I2.Y * (long) p01.X);
        int num4 = System.Math.Sign((long) vector2I3.X * (long) p01.Y - (long) vector2I3.Y * (long) p01.X);
        if (num3 != -num4 && num3 != 0)
          return num4 == 0;
        return true;
      }

      internal bool method_27(int p1)
      {
        if (p1 != this.i0 && p1 != this.i1)
          return p1 == this.i2;
        return true;
      }

      internal int method_28(Triangulator2I.Triangle t)
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

      internal Triangulator2I.Triangle method_31(int p)
      {
        if (p == this.i0)
          return this.neighbour0;
        if (p == this.i1)
          return this.neighbour1;
        if (p != this.i2)
          throw new InternalException("Given point is not part of this triangle.");
        return this.neighbour2;
      }

      internal Triangulator2I.Triangle method_32(int p)
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

      internal void method_35(int superTriangleFirstIndex, IList<Point2I> points)
      {
        Vector2I vector2I1 = points[this.i1] - points[this.i0];
        Vector2I vector2I2 = points[this.i2] - points[this.i0];
        long num1 = (long) vector2I1.X * (long) vector2I2.Y - (long) vector2I1.Y * (long) vector2I2.X;
        if (num1 == 0L)
          throw new Exception("Triangle is flat.");
        if (num1 > 0L)
          throw new Exception("Triangle is not clockwise.");
        if (this.i0 >= superTriangleFirstIndex && this.i1 >= superTriangleFirstIndex)
        {
          if (this.neighbour0 != null)
            throw new Exception("Neighbour 0 is expected to be null.");
        }
        else
        {
          if (this.neighbour0 == null)
            throw new Exception("Neighbour 0 is expected to be not null.");
          int num2 = this.neighbour0.method_36(this.i0);
          if (num2 < 0)
            throw new Exception("Neighbour doesn't share shared edge point.");
          if (this.neighbour0.method_1((num2 + 2) % 3) != this.i1)
            throw new Exception("Neighbour shared edge point mismatch.");
          if ((int) this.edge0FixCount != (int) this.neighbour0.method_16(this.i1))
            throw new Exception("Edge fix count for edge 0 doesn't match that of the neighboour.");
        }
        if (this.i1 >= superTriangleFirstIndex && this.i2 >= superTriangleFirstIndex)
        {
          if (this.neighbour1 != null)
            throw new Exception("Neighbour 1 is expected to be null.");
        }
        else
        {
          if (this.neighbour1 == null)
            throw new Exception("Neighbour 1 is expected to be not null.");
          int num2 = this.neighbour1.method_36(this.i1);
          if (num2 < 0)
            throw new Exception("Neighbour doesn't share shared edge point.");
          if (this.neighbour1.method_1((num2 + 2) % 3) != this.i2)
            throw new Exception("Neighbour shared edge point mismatch.");
          if ((int) this.edge1FixCount != (int) this.neighbour1.method_16(this.i2))
            throw new Exception("Edge fix count for edge 1 doesn't match that of the neighboour.");
        }
        if (this.i2 >= superTriangleFirstIndex && this.i0 >= superTriangleFirstIndex)
        {
          if (this.neighbour2 != null)
            throw new Exception("Neighbour 2 is expected to be null.");
        }
        else
        {
          if (this.neighbour2 == null)
            throw new Exception("Neighbour 2 is expected to be not null.");
          int num2 = this.neighbour2.method_36(this.i2);
          if (num2 < 0)
            throw new Exception("Neighbour doesn't share shared edge point.");
          if (this.neighbour2.method_1((num2 + 2) % 3) != this.i0)
            throw new Exception("Neighbour shared edge point mismatch.");
          if ((int) this.edge2FixCount != (int) this.neighbour2.method_16(this.i0))
            throw new Exception("Edge fix count for edge 2 doesn't match that of the neighboour.");
        }
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

      internal int method_36(int i)
      {
        if (i == this.i0)
          return 0;
        if (i == this.i1)
          return 1;
        return i == this.i2 ? 2 : -1;
      }

      internal Triangulator2I.Triangle method_37(int neighbourIndex)
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

      internal int method_38(int edgeIndex)
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

      internal void method_39(int sweepTrianglePointIndex)
      {
        if (this.i1 == sweepTrianglePointIndex)
        {
          int i0 = this.i0;
          Triangulator2I.Triangle neighbour0 = this.neighbour0;
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
          Triangulator2I.Triangle neighbour0 = this.neighbour0;
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

      internal bool method_40(int edge, out Triangulator2I.Triangle nextTriangle, out int nextEdge)
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
        Triangulator2I.Triangle triangle1 = this;
        int num2 = this.method_1(edge);
        for (Triangulator2I.Triangle triangle2 = triangle1.method_32(num2); triangle2 != null && triangle2 != this; triangle2 = triangle2.method_32(num2))
        {
          int cornerIndex2 = (triangle2.method_36(num2) + 2) % 3;
          byte num3 = (byte) (1 << cornerIndex2);
          if (((int) triangle2.method_17(cornerIndex2) & 1) != 0 && ((int) triangle2.filterStatus & (int) num3) == 0)
          {
            triangle2.filterStatus |= num3;
            nextTriangle = triangle2;
            nextEdge = cornerIndex2;
            return true;
          }
        }
        nextTriangle = (Triangulator2I.Triangle) null;
        nextEdge = -1;
        return false;
      }

      internal void method_41(Triangulator2I.Triangle from)
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

      internal void method_42()
      {
        if (this.neighbour0 != null)
          this.neighbour0.method_43(this);
        if (this.neighbour1 != null)
          this.neighbour1.method_43(this);
        if (this.neighbour2 == null)
          return;
        this.neighbour2.method_43(this);
      }

      private void method_43(Triangulator2I.Triangle triangle)
      {
        if (this.neighbour0 == triangle)
          this.neighbour0 = (Triangulator2I.Triangle) null;
        else if (this.neighbour1 == triangle)
        {
          this.neighbour1 = (Triangulator2I.Triangle) null;
        }
        else
        {
          if (this.neighbour2 != triangle)
            return;
          this.neighbour2 = (Triangulator2I.Triangle) null;
        }
      }

      internal class Class186 : IComparer<Triangulator2I.Triangle>
      {
        private IList<Point2I> ilist_0;

        public Class186(IList<Point2I> points)
        {
          this.ilist_0 = points;
        }

        public int Compare(Triangulator2I.Triangle a, Triangulator2I.Triangle b)
        {
          if (a == b)
            return 0;
          Point2I point2I1 = this.ilist_0[a.i0];
          Point2I point2I2 = this.ilist_0[a.i1];
          Point2I point2I3 = this.ilist_0[b.i1];
          return Vector2I.CrossProduct(point2I2 - point2I1, point2I3 - point2I1) > 0L ? -1 : 1;
        }
      }
    }

    private class Class187
    {
      private Triangulator2I.Triangle triangle_0;
      private bool bool_0;

      public Class187(Triangulator2I.Triangle triangle, bool inside)
      {
        this.triangle_0 = triangle;
        this.bool_0 = inside;
      }

      public Triangulator2I.Triangle Triangle
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

    private class Class188 : IComparable<Triangulator2I.Class188>
    {
      private Point2I point2I_0;
      private int int_0;

      public Class188(Point2I position, int index)
      {
        this.point2I_0 = position;
        this.int_0 = index;
      }

      public int Index
      {
        get
        {
          return this.int_0;
        }
      }

      public int CompareTo(Triangulator2I.Class188 other)
      {
        if (this.point2I_0.Y < other.point2I_0.Y)
          return -1;
        return this.point2I_0.Y > other.point2I_0.Y ? 1 : 0;
      }
    }

    internal struct Struct11
    {
      public int int_0;
      public int int_1;

      public Struct11(int p0, int p1)
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
        if (obj is Triangulator2I.Struct11)
        {
          Triangulator2I.Struct11 struct11 = (Triangulator2I.Struct11) obj;
          flag = this.int_0 == struct11.int_0 && this.int_1 == struct11.int_1;
        }
        else
          flag = false;
        return flag;
      }
    }

    internal class Class189
    {
      private HashSet<Triangulator2I.Triangle> hashSet_0;
      private IList<Point2I> ilist_0;
      private Dictionary<int, HashSet<Triangulator2I.Triangle>> dictionary_0;
      private Dictionary<Triangulator2I.Struct11, Triangulator2I.Triangle> dictionary_1;

      public Class189(HashSet<Triangulator2I.Triangle> triangles, IList<Point2I> points)
      {
        this.hashSet_0 = triangles;
        this.ilist_0 = points;
      }

      public HashSet<Triangulator2I.Triangle> Triangles
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

      public IList<Point2I> Points
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

      public Dictionary<int, HashSet<Triangulator2I.Triangle>> PointIndexToTriangles
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

      public Dictionary<Triangulator2I.Struct11, Triangulator2I.Triangle> EdgeToTriangle
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

      public void method_0(Triangulator2I.Triangle t)
      {
        this.hashSet_0.Add(t);
        this.method_3(t);
      }

      public void method_1(Triangulator2I.Triangle t)
      {
        this.hashSet_0.Remove(t);
        this.method_4(t);
      }

      internal void method_2(bool initializeFromTriangles)
      {
        this.dictionary_1 = new Dictionary<Triangulator2I.Struct11, Triangulator2I.Triangle>();
        this.dictionary_0 = new Dictionary<int, HashSet<Triangulator2I.Triangle>>();
        foreach (Triangulator2I.Triangle triangle in this.hashSet_0)
        {
          triangle.method_20(this.dictionary_1);
          triangle.method_22(this.dictionary_0);
        }
      }

      internal void method_3(Triangulator2I.Triangle t)
      {
        if (this.dictionary_1 != null)
          t.method_20(this.dictionary_1);
        if (this.dictionary_0 == null)
          return;
        t.method_22(this.dictionary_0);
      }

      internal void method_4(Triangulator2I.Triangle t)
      {
        if (this.dictionary_1 != null)
          t.method_21(this.dictionary_1);
        if (this.dictionary_0 == null)
          return;
        t.method_24(this.dictionary_0);
      }

      internal void method_5()
      {
        int superTriangleFirstIndex = this.ilist_0.Count - 3;
        foreach (Triangulator2I.Triangle triangle in this.hashSet_0)
          triangle.method_35(superTriangleFirstIndex, this.ilist_0);
      }
    }

    internal class Class190
    {
      private Point2I point2I_0;
      private LinkedListNode<Triangulator2I.Class190> linkedListNode_0;

      public Class190(Point2I point)
      {
        this.point2I_0 = point;
      }

      public Point2I Point
      {
        get
        {
          return this.point2I_0;
        }
      }

      public LinkedListNode<Triangulator2I.Class190> PointNode
      {
        get
        {
          return this.linkedListNode_0;
        }
        set
        {
          this.linkedListNode_0 = value;
        }
      }

      public Polygon2I method_0(LinkedList<Triangulator2I.Class190> pointChain)
      {
        if (this.linkedListNode_0 == null)
        {
          this.linkedListNode_0 = pointChain.AddLast(this);
          return (Polygon2I) null;
        }
        Polygon2I polygon2I = new Polygon2I();
        LinkedListNode<Triangulator2I.Class190> linkedListNode0 = this.linkedListNode_0;
        polygon2I.Add(linkedListNode0.Value.point2I_0);
        LinkedListNode<Triangulator2I.Class190> next = linkedListNode0.Next;
        while (next != null)
        {
          polygon2I.Add(next.Value.point2I_0);
          LinkedListNode<Triangulator2I.Class190> node = next;
          next = next.Next;
          pointChain.Remove(node);
          node.Value.linkedListNode_0 = (LinkedListNode<Triangulator2I.Class190>) null;
        }
        return polygon2I;
      }

      public override string ToString()
      {
        return this.point2I_0.ToString();
      }
    }
  }
}
