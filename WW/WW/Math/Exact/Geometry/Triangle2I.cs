// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.Triangle2I
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math.Exact.Geometry
{
  public static class Triangle2I
  {
    public static bool ContainsPoint(Point2I p, Point2I p0, Point2I p1, Point2I p2)
    {
      Vector2I vector2I1 = Point2I.Subtract(p1, p0);
      if ((long) vector2I1.Y * (long) (p.X - p0.X) - (long) vector2I1.X * (long) (p.Y - p0.Y) < 0L)
        return false;
      Vector2I vector2I2 = Point2I.Subtract(p2, p1);
      if ((long) vector2I2.Y * (long) (p.X - p1.X) - (long) vector2I2.X * (long) (p.Y - p1.Y) < 0L)
        return false;
      Vector2I vector2I3 = Point2I.Subtract(p0, p2);
      return (long) vector2I3.Y * (long) (p.X - p2.X) - (long) vector2I3.X * (long) (p.Y - p2.Y) >= 0L;
    }

    public static bool ContainsPoint(
      Point2I p,
      Point2I p0,
      Point2I p1,
      Point2I p2,
      out int onEdgeFlags)
    {
      onEdgeFlags = 0;
      Vector2I vector2I1 = new Vector2I(p1.X - p0.X, p1.Y - p0.Y);
      Vector2I vector2I2 = new Vector2I(p.X - p0.X, p.Y - p0.Y);
      long num1 = (long) vector2I1.Y * (long) vector2I2.X - (long) vector2I1.X * (long) vector2I2.Y;
      if (num1 < 0L)
        return false;
      if (num1 == 0L)
        onEdgeFlags |= 1;
      Vector2I vector2I3 = new Vector2I(p2.X - p1.X, p2.Y - p1.Y);
      Vector2I vector2I4 = new Vector2I(p.X - p1.X, p.Y - p1.Y);
      long num2 = (long) vector2I3.Y * (long) vector2I4.X - (long) vector2I3.X * (long) vector2I4.Y;
      if (num2 < 0L)
        return false;
      if (num2 == 0L)
        onEdgeFlags |= 2;
      Vector2I vector2I5 = new Vector2I(p0.X - p2.X, p0.Y - p2.Y);
      Vector2I vector2I6 = new Vector2I(p.X - p2.X, p.Y - p2.Y);
      long num3 = (long) vector2I5.Y * (long) vector2I6.X - (long) vector2I5.X * (long) vector2I6.Y;
      if (num3 < 0L)
        return false;
      if (num3 == 0L)
        onEdgeFlags |= 4;
      return true;
    }

    public static bool ContainsPoint(
      Point2I p,
      Point2I p0,
      Point2I p1,
      Point2I p2,
      int skipEdgeIndex,
      out int onEdgeFlags,
      out int outsideEdgeIndex)
    {
      onEdgeFlags = 0;
      outsideEdgeIndex = -1;
      if (skipEdgeIndex != 0)
      {
        Vector2I vector2I1 = new Vector2I(p1.X - p0.X, p1.Y - p0.Y);
        Vector2I vector2I2 = new Vector2I(p.X - p0.X, p.Y - p0.Y);
        long num = (long) vector2I1.Y * (long) vector2I2.X - (long) vector2I1.X * (long) vector2I2.Y;
        if (num < 0L)
        {
          outsideEdgeIndex = 0;
          return false;
        }
        if (num == 0L)
          onEdgeFlags |= 1;
      }
      if (skipEdgeIndex != 1)
      {
        Vector2I vector2I1 = new Vector2I(p2.X - p1.X, p2.Y - p1.Y);
        Vector2I vector2I2 = new Vector2I(p.X - p1.X, p.Y - p1.Y);
        long num = (long) vector2I1.Y * (long) vector2I2.X - (long) vector2I1.X * (long) vector2I2.Y;
        if (num < 0L)
        {
          outsideEdgeIndex = 1;
          return false;
        }
        if (num == 0L)
          onEdgeFlags |= 2;
      }
      if (skipEdgeIndex != 2)
      {
        Vector2I vector2I1 = new Vector2I(p0.X - p2.X, p0.Y - p2.Y);
        Vector2I vector2I2 = new Vector2I(p.X - p2.X, p.Y - p2.Y);
        long num = (long) vector2I1.Y * (long) vector2I2.X - (long) vector2I1.X * (long) vector2I2.Y;
        if (num < 0L)
        {
          outsideEdgeIndex = 2;
          return false;
        }
        if (num == 0L)
          onEdgeFlags |= 4;
      }
      return true;
    }
  }
}
