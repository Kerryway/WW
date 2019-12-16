// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Triangle2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math.Geometry
{
  public static class Triangle2D
  {
    public static bool ContainsPoint(Point2D p, Point2D p0, Point2D p1, Point2D p2)
    {
      Vector2D vector2D1 = Point2D.Subtract(p1, p0);
      if (vector2D1.Y * (p.X - p0.X) - vector2D1.X * (p.Y - p0.Y) < 0.0)
        return false;
      Vector2D vector2D2 = Point2D.Subtract(p2, p1);
      if (vector2D2.Y * (p.X - p1.X) - vector2D2.X * (p.Y - p1.Y) < 0.0)
        return false;
      Vector2D vector2D3 = Point2D.Subtract(p0, p2);
      return vector2D3.Y * (p.X - p2.X) - vector2D3.X * (p.Y - p2.Y) >= 0.0;
    }

    public static bool ContainsPoint(
      Point2D p,
      Point2D p0,
      Point2D p1,
      Point2D p2,
      double precision,
      out int onEdgeFlags)
    {
      double num1 = precision * precision;
      onEdgeFlags = 0;
      Vector2D vector2D1 = new Vector2D(p1.X - p0.X, p1.Y - p0.Y);
      Vector2D vector2D2 = new Vector2D(p.X - p0.X, p.Y - p0.Y);
      double num2 = vector2D1.Y * vector2D2.X - vector2D1.X * vector2D2.Y;
      if (num2 < 0.0)
      {
        if (num2 * num2 > num1 * vector2D1.GetLengthSquared())
          return false;
        onEdgeFlags |= 1;
      }
      else if (num2 * num2 <= num1 * vector2D1.GetLengthSquared())
        onEdgeFlags |= 1;
      Vector2D vector2D3 = new Vector2D(p2.X - p1.X, p2.Y - p1.Y);
      Vector2D vector2D4 = new Vector2D(p.X - p1.X, p.Y - p1.Y);
      double num3 = vector2D3.Y * vector2D4.X - vector2D3.X * vector2D4.Y;
      if (num3 < 0.0)
      {
        if (num3 * num3 > num1 * vector2D3.GetLengthSquared())
          return false;
        onEdgeFlags |= 2;
      }
      else if (num3 * num3 <= num1 * vector2D3.GetLengthSquared())
        onEdgeFlags |= 2;
      Vector2D vector2D5 = new Vector2D(p0.X - p2.X, p0.Y - p2.Y);
      Vector2D vector2D6 = new Vector2D(p.X - p2.X, p.Y - p2.Y);
      double num4 = vector2D5.Y * vector2D6.X - vector2D5.X * vector2D6.Y;
      if (num4 < 0.0)
      {
        if (num4 * num4 > num1 * vector2D5.GetLengthSquared())
          return false;
        onEdgeFlags |= 4;
      }
      else if (num4 * num4 <= num1 * vector2D5.GetLengthSquared())
        onEdgeFlags |= 4;
      return true;
    }

    public static bool ContainsPoint(
      Point2D p,
      Point2D p0,
      Point2D p1,
      Point2D p2,
      int skipEdgeIndex,
      double precision,
      out int onEdgeFlags,
      out int outsideEdgeIndex)
    {
      double num1 = precision * precision;
      onEdgeFlags = 0;
      outsideEdgeIndex = -1;
      if (skipEdgeIndex != 0)
      {
        Vector2D vector2D1 = new Vector2D(p1.X - p0.X, p1.Y - p0.Y);
        Vector2D vector2D2 = new Vector2D(p.X - p0.X, p.Y - p0.Y);
        double num2 = vector2D1.Y * vector2D2.X - vector2D1.X * vector2D2.Y;
        if (num2 < 0.0)
        {
          if (num2 * num2 > num1 * vector2D1.GetLengthSquared())
          {
            outsideEdgeIndex = 0;
            return false;
          }
          onEdgeFlags |= 1;
        }
        else if (num2 * num2 <= num1 * vector2D1.GetLengthSquared())
          onEdgeFlags |= 1;
      }
      if (skipEdgeIndex != 1)
      {
        Vector2D vector2D1 = new Vector2D(p2.X - p1.X, p2.Y - p1.Y);
        Vector2D vector2D2 = new Vector2D(p.X - p1.X, p.Y - p1.Y);
        double num2 = vector2D1.Y * vector2D2.X - vector2D1.X * vector2D2.Y;
        if (num2 < 0.0)
        {
          if (num2 * num2 > num1 * vector2D1.GetLengthSquared())
          {
            outsideEdgeIndex = 1;
            return false;
          }
          onEdgeFlags |= 2;
        }
        else if (num2 * num2 <= num1 * vector2D1.GetLengthSquared())
          onEdgeFlags |= 2;
      }
      if (skipEdgeIndex != 2)
      {
        Vector2D vector2D1 = new Vector2D(p0.X - p2.X, p0.Y - p2.Y);
        Vector2D vector2D2 = new Vector2D(p.X - p2.X, p.Y - p2.Y);
        double num2 = vector2D1.Y * vector2D2.X - vector2D1.X * vector2D2.Y;
        if (num2 < 0.0)
        {
          if (num2 * num2 > num1 * vector2D1.GetLengthSquared())
          {
            outsideEdgeIndex = 2;
            return false;
          }
          onEdgeFlags |= 4;
        }
        else if (num2 * num2 <= num1 * vector2D1.GetLengthSquared())
          onEdgeFlags |= 4;
      }
      return true;
    }

    public static bool ContainsPoint(
      Point2D p,
      Point2D p0,
      Point2D p1,
      Point2D p2,
      double precision)
    {
      double num1 = precision * precision;
      Vector2D vector2D1 = new Vector2D(p1.X - p0.X, p1.Y - p0.Y);
      Vector2D vector2D2 = new Vector2D(p.X - p0.X, p.Y - p0.Y);
      double num2 = vector2D1.Y * vector2D2.X - vector2D1.X * vector2D2.Y;
      if (num2 < 0.0 && num2 * num2 > num1 * vector2D1.GetLengthSquared())
        return false;
      Vector2D vector2D3 = new Vector2D(p2.X - p1.X, p2.Y - p1.Y);
      Vector2D vector2D4 = new Vector2D(p.X - p1.X, p.Y - p1.Y);
      double num3 = vector2D3.Y * vector2D4.X - vector2D3.X * vector2D4.Y;
      if (num3 < 0.0 && num3 * num3 > num1 * vector2D3.GetLengthSquared())
        return false;
      Vector2D vector2D5 = new Vector2D(p0.X - p2.X, p0.Y - p2.Y);
      Vector2D vector2D6 = new Vector2D(p.X - p2.X, p.Y - p2.Y);
      double num4 = vector2D5.Y * vector2D6.X - vector2D5.X * vector2D6.Y;
      return num4 >= 0.0 || num4 * num4 <= num1 * vector2D5.GetLengthSquared();
    }
  }
}
