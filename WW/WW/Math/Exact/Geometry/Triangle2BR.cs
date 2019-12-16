// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.Triangle2BR
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math.Exact.Geometry
{
  public static class Triangle2BR
  {
    public static bool ContainsPoint(Point2BR p, Point2BR p0, Point2BR p1, Point2BR p2)
    {
      Vector2BR vector2Br1 = Point2BR.Subtract(p1, p0);
      if ((vector2Br1.Y * (p.X - p0.X) - vector2Br1.X * (p.Y - p0.Y)).IsNegative)
        return false;
      Vector2BR vector2Br2 = Point2BR.Subtract(p2, p1);
      if ((vector2Br2.Y * (p.X - p1.X) - vector2Br2.X * (p.Y - p1.Y)).IsNegative)
        return false;
      Vector2BR vector2Br3 = Point2BR.Subtract(p0, p2);
      return !(vector2Br3.Y * (p.X - p2.X) - vector2Br3.X * (p.Y - p2.Y)).IsNegative;
    }

    public static bool ContainsPoint(
      Point2BR p,
      Point2BR p0,
      Point2BR p1,
      Point2BR p2,
      out int onEdgeFlags)
    {
      onEdgeFlags = 0;
      Vector2BR vector2Br1 = new Vector2BR(p1.X - p0.X, p1.Y - p0.Y);
      Vector2BR vector2Br2 = new Vector2BR(p.X - p0.X, p.Y - p0.Y);
      BigRational bigRational1 = vector2Br1.Y * vector2Br2.X - vector2Br1.X * vector2Br2.Y;
      if (bigRational1.IsNegative)
        return false;
      if (bigRational1.IsZero)
        onEdgeFlags |= 1;
      Vector2BR vector2Br3 = new Vector2BR(p2.X - p1.X, p2.Y - p1.Y);
      Vector2BR vector2Br4 = new Vector2BR(p.X - p1.X, p.Y - p1.Y);
      BigRational bigRational2 = vector2Br3.Y * vector2Br4.X - vector2Br3.X * vector2Br4.Y;
      if (bigRational2.IsNegative)
        return false;
      if (bigRational2.IsZero)
        onEdgeFlags |= 2;
      Vector2BR vector2Br5 = new Vector2BR(p0.X - p2.X, p0.Y - p2.Y);
      Vector2BR vector2Br6 = new Vector2BR(p.X - p2.X, p.Y - p2.Y);
      BigRational bigRational3 = vector2Br5.Y * vector2Br6.X - vector2Br5.X * vector2Br6.Y;
      if (bigRational3.IsNegative)
        return false;
      if (bigRational3.IsZero)
        onEdgeFlags |= 4;
      return true;
    }

    public static bool ContainsPoint(
      Point2BR p,
      Point2BR p0,
      Point2BR p1,
      Point2BR p2,
      int skipEdgeIndex,
      out int onEdgeFlags,
      out int outsideEdgeIndex)
    {
      onEdgeFlags = 0;
      outsideEdgeIndex = -1;
      if (skipEdgeIndex != 0)
      {
        Vector2BR vector2Br1 = new Vector2BR(p1.X - p0.X, p1.Y - p0.Y);
        Vector2BR vector2Br2 = new Vector2BR(p.X - p0.X, p.Y - p0.Y);
        BigRational bigRational = vector2Br1.Y * vector2Br2.X - vector2Br1.X * vector2Br2.Y;
        if (bigRational.IsNegative)
        {
          outsideEdgeIndex = 0;
          return false;
        }
        if (bigRational.IsZero)
          onEdgeFlags |= 1;
      }
      if (skipEdgeIndex != 1)
      {
        Vector2BR vector2Br1 = new Vector2BR(p2.X - p1.X, p2.Y - p1.Y);
        Vector2BR vector2Br2 = new Vector2BR(p.X - p1.X, p.Y - p1.Y);
        BigRational bigRational = vector2Br1.Y * vector2Br2.X - vector2Br1.X * vector2Br2.Y;
        if (bigRational.IsNegative)
        {
          outsideEdgeIndex = 1;
          return false;
        }
        if (bigRational.IsZero)
          onEdgeFlags |= 2;
      }
      if (skipEdgeIndex != 2)
      {
        Vector2BR vector2Br1 = new Vector2BR(p0.X - p2.X, p0.Y - p2.Y);
        Vector2BR vector2Br2 = new Vector2BR(p.X - p2.X, p.Y - p2.Y);
        BigRational bigRational = vector2Br1.Y * vector2Br2.X - vector2Br1.X * vector2Br2.Y;
        if (bigRational.IsNegative)
        {
          outsideEdgeIndex = 2;
          return false;
        }
        if (bigRational.IsZero)
          onEdgeFlags |= 4;
      }
      return true;
    }
  }
}
