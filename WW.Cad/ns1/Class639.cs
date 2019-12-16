// Decompiled with JetBrains decompiler
// Type: ns1.Class639
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Drawing;
using WW.Cad.Model.Entities;
using WW.Math;

namespace ns1
{
  internal class Class639
  {
    private double double_0;
    private double double_1;

    public Class639(double defaultStartWidth, double defaultEndWidth)
    {
      this.double_0 = defaultStartWidth;
      this.double_1 = defaultEndWidth;
    }

    internal Polyline2D2WN method_0(
      IVertex2DCollection vertices,
      GraphicsConfig config,
      bool closed)
    {
      int count = vertices.Count;
      if (count == 0)
        return new Polyline2D2WN(0);
      IVertex2D vertex = vertices.GetIVertex2D(0);
      Polyline2D2WN polyline = new Polyline2D2WN(count, closed);
      for (int index = 1; index < count; ++index)
      {
        IVertex2D ivertex2D = vertices.GetIVertex2D(index);
        this.method_1(config, polyline, vertex, ivertex2D);
        vertex = ivertex2D;
      }
      if (closed)
      {
        this.method_1(config, polyline, vertex, vertices.GetIVertex2D(0));
      }
      else
      {
        double startWidth = vertex.StartWidth == 0.0 ? this.double_0 : vertex.StartWidth;
        double endWidth = vertex.EndWidth == 0.0 ? this.double_1 : vertex.EndWidth;
        Point2D2WN point2D2Wn = new Point2D2WN(vertex.Position, startWidth, endWidth);
        polyline.Add(point2D2Wn);
      }
      return polyline;
    }

    private void method_1(
      GraphicsConfig config,
      Polyline2D2WN polyline,
      IVertex2D vertex,
      IVertex2D nextVertex)
    {
      if (!(vertex.Position != nextVertex.Position))
        return;
      if (vertex.Bulge == 0.0)
        this.method_2(polyline, vertex, nextVertex);
      else
        this.method_3(config, polyline, vertex, nextVertex);
    }

    private void method_2(Polyline2D2WN polyline, IVertex2D vertex, IVertex2D nextVertex)
    {
      double startWidth = vertex.StartWidth == 0.0 ? this.double_0 : vertex.StartWidth;
      double endWidth = vertex.EndWidth == 0.0 ? this.double_1 : vertex.EndWidth;
      Vector2D vector2D = nextVertex.Position - vertex.Position;
      Point2D2WN point2D2Wn = new Point2D2WN(vertex.Position, startWidth, endWidth) { StartNormal = new Vector2D(-vector2D.Y, vector2D.X).GetUnit() };
      point2D2Wn.EndNormal = point2D2Wn.StartNormal;
      polyline.Add(point2D2Wn);
    }

    private void method_3(
      GraphicsConfig config,
      Polyline2D2WN polyline,
      IVertex2D vertex,
      IVertex2D nextVertex)
    {
      double num1 = vertex.StartWidth == 0.0 ? this.double_0 : vertex.StartWidth;
      double val1 = vertex.EndWidth == 0.0 ? this.double_1 : vertex.EndWidth;
      Vector2D vector2D1 = nextVertex.Position - vertex.Position;
      double length = vector2D1.GetLength();
      double num2 = 4.0 * System.Math.Atan(vertex.Bulge);
      double num3 = length / (2.0 * System.Math.Abs(System.Math.Sin(num2 * 0.5)));
      Vector2D vector2D2 = vector2D1;
      vector2D2.Normalize();
      double num4 = (double) System.Math.Sign(vertex.Bulge);
      Vector2D vector2D3 = new Vector2D(-vector2D2.Y, vector2D2.X) * num4;
      Point2D point2D = (Point2D) (((Vector2D) nextVertex.Position + (Vector2D) vertex.Position) * 0.5) + vector2D3 * System.Math.Cos(num2 * 0.5) * num3;
      Vector2D vector2D4 = vertex.Position - point2D;
      double num5 = System.Math.Atan2(vector2D4.Y, vector2D4.X);
      Vector2D vector2D5 = nextVertex.Position - point2D;
      double num6 = System.Math.Atan2(vector2D5.Y, vector2D5.X);
      double num7 = num5;
      double num8 = num4 * (2.0 * System.Math.PI) / (double) config.NoOfArcLineSegments;
      while (num6 < num5)
        num6 += 2.0 * System.Math.PI;
      double num9 = vertex.Bulge >= 0.0 ? num6 - num5 : 2.0 * System.Math.PI - (num6 - num5);
      double a = System.Math.Abs(num9 / num8);
      if (a < (double) config.NoOfArcLineSegmentsMinimum)
      {
        a = (double) config.NoOfArcLineSegmentsMinimum;
        num8 = num4 * System.Math.Abs(num9 / (double) config.NoOfArcLineSegmentsMinimum);
      }
      if (a < 2.0)
      {
        this.method_2(polyline, vertex, nextVertex);
      }
      else
      {
        double startWidth1 = num1;
        double num10 = (val1 - num1) / a;
        int num11 = (int) System.Math.Ceiling(a);
        double endWidth1 = System.Math.Min(val1, startWidth1 + num10);
        double x1 = System.Math.Cos(num7);
        double y1 = System.Math.Sin(num7);
        Point2D2WN point2D2Wn1 = new Point2D2WN(point2D + new Vector2D(x1 * num3, y1 * num3), startWidth1, endWidth1);
        point2D2Wn1.StartNormal = -num4 * new Vector2D(x1, y1);
        polyline.Add(point2D2Wn1);
        double startWidth2 = endWidth1;
        double num12 = num7 + num8;
        for (int index = 1; index < num11; ++index)
        {
          double x2 = System.Math.Cos(num12);
          double y2 = System.Math.Sin(num12);
          Vector2D vector2D6 = -num4 * new Vector2D(x2, y2);
          point2D2Wn1.EndNormal = vector2D6;
          Point2D position = point2D + new Vector2D(x2 * num3, y2 * num3);
          double endWidth2 = System.Math.Min(val1, startWidth2 + num10);
          Point2D2WN point2D2Wn2 = new Point2D2WN(position, startWidth2, endWidth2);
          point2D2Wn2.IsInterpolatedPoint = true;
          point2D2Wn2.StartNormal = vector2D6;
          polyline.Add(point2D2Wn2);
          startWidth2 = endWidth2;
          num12 += num8;
          point2D2Wn1 = point2D2Wn2;
        }
        point2D2Wn1.EndNormal = -num4 * new Vector2D(System.Math.Cos(num6), System.Math.Sin(num6));
      }
    }

    public static class Class640
    {
      internal static Polyline2DE smethod_0(
        IVertex2DCollection vertices,
        GraphicsConfig config,
        bool closed)
      {
        int count = vertices.Count;
        if (count == 0)
          return new Polyline2DE(0);
        IVertex2D vertex = vertices.GetIVertex2D(0);
        Polyline2DE polyline = new Polyline2DE(count, closed);
        for (int index = 1; index < count; ++index)
        {
          IVertex2D ivertex2D = vertices.GetIVertex2D(index);
          Class639.Class640.smethod_1(config, polyline, vertex, ivertex2D);
          vertex = ivertex2D;
        }
        if (closed)
          Class639.Class640.smethod_1(config, polyline, vertex, vertices.GetIVertex2D(0));
        else
          polyline.Add(new Point2DE(vertex.Position));
        return polyline;
      }

      private static void smethod_1(
        GraphicsConfig config,
        Polyline2DE polyline,
        IVertex2D vertex,
        IVertex2D nextVertex)
      {
        if (!(vertex.Position != nextVertex.Position))
          return;
        if (vertex.Bulge == 0.0)
          Class639.Class640.smethod_2(polyline, vertex, nextVertex);
        else
          Class639.Class640.smethod_3(config, polyline, vertex, nextVertex);
      }

      private static void smethod_2(Polyline2DE polyline, IVertex2D vertex, IVertex2D nextVertex)
      {
        polyline.Add(new Point2DE(vertex.Position));
      }

      private static void smethod_3(
        GraphicsConfig config,
        Polyline2DE polyline,
        IVertex2D vertex,
        IVertex2D nextVertex)
      {
        Vector2D vector2D1 = nextVertex.Position - vertex.Position;
        double length = vector2D1.GetLength();
        double num1 = 4.0 * System.Math.Atan(vertex.Bulge);
        double num2 = length / (2.0 * System.Math.Abs(System.Math.Sin(num1 * 0.5)));
        Vector2D vector2D2 = vector2D1;
        vector2D2.Normalize();
        double num3 = (double) System.Math.Sign(vertex.Bulge);
        Vector2D vector2D3 = new Vector2D(-vector2D2.Y, vector2D2.X) * num3;
        Point2D point2D = (Point2D) (((Vector2D) nextVertex.Position + (Vector2D) vertex.Position) * 0.5) + vector2D3 * System.Math.Cos(num1 * 0.5) * num2;
        Vector2D vector2D4 = vertex.Position - point2D;
        double num4 = System.Math.Atan2(vector2D4.Y, vector2D4.X);
        Vector2D vector2D5 = nextVertex.Position - point2D;
        double num5 = System.Math.Atan2(vector2D5.Y, vector2D5.X);
        double num6 = num4;
        double num7 = num3 * (2.0 * System.Math.PI) / (double) config.NoOfArcLineSegments;
        while (num5 < num4)
          num5 += 2.0 * System.Math.PI;
        int num8 = (int) System.Math.Ceiling(vertex.Bulge >= 0.0 ? System.Math.Abs(num5 - num4) / num7 : System.Math.Abs((2.0 * System.Math.PI - (num5 - num4)) / num7));
        double num9 = System.Math.Cos(num6);
        double num10 = System.Math.Sin(num6);
        Point2D position1 = point2D + new Vector2D(num9 * num2, num10 * num2);
        polyline.Add(new Point2DE(position1));
        double num11 = num6 + num7;
        for (int index = 1; index < num8; ++index)
        {
          double num12 = System.Math.Cos(num11);
          double num13 = System.Math.Sin(num11);
          Point2D position2 = point2D + new Vector2D(num12 * num2, num13 * num2);
          polyline.Add(new Point2DE(position2)
          {
            IsInterpolatedPoint = true
          });
          num11 += num7;
        }
      }
    }

    public static class Class641
    {
      internal static Polyline2D2N smethod_0(
        IVertex2DCollection vertices,
        GraphicsConfig config,
        bool closed)
      {
        int count = vertices.Count;
        if (count == 0)
          return new Polyline2D2N(0);
        IVertex2D vertex = vertices.GetIVertex2D(0);
        Polyline2D2N polyline = new Polyline2D2N(count, closed);
        for (int index = 1; index < count; ++index)
        {
          IVertex2D ivertex2D = vertices.GetIVertex2D(index);
          Class639.Class641.smethod_1(config, polyline, vertex, ivertex2D);
          vertex = ivertex2D;
        }
        if (closed)
        {
          Class639.Class641.smethod_1(config, polyline, vertex, vertices.GetIVertex2D(0));
        }
        else
        {
          Point2D2N point2D2N = new Point2D2N(vertex.Position);
          polyline.Add(point2D2N);
        }
        return polyline;
      }

      private static void smethod_1(
        GraphicsConfig config,
        Polyline2D2N polyline,
        IVertex2D vertex,
        IVertex2D nextVertex)
      {
        if (!(vertex.Position != nextVertex.Position))
          return;
        if (vertex.Bulge == 0.0)
          Class639.Class641.smethod_2(polyline, vertex, nextVertex);
        else
          Class639.Class641.smethod_3(config, polyline, vertex, nextVertex);
      }

      private static void smethod_2(Polyline2D2N polyline, IVertex2D vertex, IVertex2D nextVertex)
      {
        Vector2D vector2D = nextVertex.Position - vertex.Position;
        Point2D2N point2D2N = new Point2D2N(vertex.Position) { StartNormal = new Vector2D(-vector2D.Y, vector2D.X).GetUnit() };
        point2D2N.EndNormal = point2D2N.StartNormal;
        polyline.Add(point2D2N);
      }

      private static Vector2D smethod_3(
        GraphicsConfig config,
        Polyline2D2N polyline,
        IVertex2D vertex,
        IVertex2D nextVertex)
      {
        Vector2D vector2D1 = nextVertex.Position - vertex.Position;
        double length = vector2D1.GetLength();
        double num1 = 4.0 * System.Math.Atan(vertex.Bulge);
        double num2 = length / (2.0 * System.Math.Abs(System.Math.Sin(num1 * 0.5)));
        Vector2D vector2D2 = vector2D1;
        vector2D2.Normalize();
        double num3 = (double) System.Math.Sign(vertex.Bulge);
        Vector2D vector2D3 = new Vector2D(-vector2D2.Y, vector2D2.X) * num3;
        Point2D point2D = (Point2D) (((Vector2D) nextVertex.Position + (Vector2D) vertex.Position) * 0.5) + vector2D3 * System.Math.Cos(num1 * 0.5) * num2;
        Vector2D vector2D4 = vertex.Position - point2D;
        double num4 = System.Math.Atan2(vector2D4.Y, vector2D4.X);
        Vector2D vector2D5 = nextVertex.Position - point2D;
        double num5 = System.Math.Atan2(vector2D5.Y, vector2D5.X);
        double num6 = num4;
        double num7 = num3 * (2.0 * System.Math.PI) / (double) config.NoOfArcLineSegments;
        while (num5 < num4)
          num5 += 2.0 * System.Math.PI;
        int num8 = (int) System.Math.Ceiling(vertex.Bulge >= 0.0 ? System.Math.Abs(num5 - num4) / num7 : System.Math.Abs((2.0 * System.Math.PI - (num5 - num4)) / num7));
        double x1 = System.Math.Cos(num6);
        double y1 = System.Math.Sin(num6);
        Point2D2N point2D2N1 = new Point2D2N(point2D + new Vector2D(x1 * num2, y1 * num2));
        point2D2N1.StartNormal = -num3 * new Vector2D(x1, y1);
        polyline.Add(point2D2N1);
        double num9 = num6 + num7;
        for (int index = 1; index < num8; ++index)
        {
          double x2 = System.Math.Cos(num9);
          double y2 = System.Math.Sin(num9);
          Vector2D vector2D6 = -num3 * new Vector2D(x2, y2);
          point2D2N1.EndNormal = vector2D6;
          Point2D2N point2D2N2 = new Point2D2N(point2D + new Vector2D(x2 * num2, y2 * num2));
          point2D2N2.IsInterpolatedPoint = true;
          point2D2N2.StartNormal = vector2D6;
          polyline.Add(point2D2N2);
          num9 += num7;
          point2D2N1 = point2D2N2;
        }
        point2D2N1.EndNormal = -num3 * new Vector2D(System.Math.Cos(num5), System.Math.Sin(num5));
        return vector2D1;
      }
    }
  }
}
