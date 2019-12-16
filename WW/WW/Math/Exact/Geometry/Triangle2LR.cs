// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.Triangle2LR
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math.Exact.Geometry
{
  public static class Triangle2LR
  {
    public static bool ContainsPoint(Point2LR p, Point2LR p0, Point2LR p1, Point2LR p2)
    {
      Vector2LR vector2Lr1 = Point2LR.Subtract(p1, p0);
      if ((vector2Lr1.Y * (p.X - p0.X) - vector2Lr1.X * (p.Y - p0.Y)).IsNegative)
        return false;
      Vector2LR vector2Lr2 = Point2LR.Subtract(p2, p1);
      if ((vector2Lr2.Y * (p.X - p1.X) - vector2Lr2.X * (p.Y - p1.Y)).IsNegative)
        return false;
      Vector2LR vector2Lr3 = Point2LR.Subtract(p0, p2);
      return !(vector2Lr3.Y * (p.X - p2.X) - vector2Lr3.X * (p.Y - p2.Y)).IsNegative;
    }

    public static bool ContainsPoint(
      Point2LR p,
      Point2LR p0,
      Point2LR p1,
      Point2LR p2,
      out int onEdgeFlags)
    {
      onEdgeFlags = 0;
      Vector2LR vector2Lr1 = new Vector2LR(p1.X - p0.X, p1.Y - p0.Y);
      Vector2LR vector2Lr2 = new Vector2LR(p.X - p0.X, p.Y - p0.Y);
      LongRational longRational1 = vector2Lr1.Y * vector2Lr2.X - vector2Lr1.X * vector2Lr2.Y;
      if (longRational1.IsNegative)
        return false;
      if (longRational1.IsZero)
        onEdgeFlags |= 1;
      Vector2LR vector2Lr3 = new Vector2LR(p2.X - p1.X, p2.Y - p1.Y);
      Vector2LR vector2Lr4 = new Vector2LR(p.X - p1.X, p.Y - p1.Y);
      LongRational longRational2 = vector2Lr3.Y * vector2Lr4.X - vector2Lr3.X * vector2Lr4.Y;
      if (longRational2.IsNegative)
        return false;
      if (longRational2.IsZero)
        onEdgeFlags |= 2;
      Vector2LR vector2Lr5 = new Vector2LR(p0.X - p2.X, p0.Y - p2.Y);
      Vector2LR vector2Lr6 = new Vector2LR(p.X - p2.X, p.Y - p2.Y);
      LongRational longRational3 = vector2Lr5.Y * vector2Lr6.X - vector2Lr5.X * vector2Lr6.Y;
      if (longRational3.IsNegative)
        return false;
      if (longRational3.IsZero)
        onEdgeFlags |= 4;
      return true;
    }

    public static bool ContainsPoint(
      Point2LR p,
      Point2LR p0,
      Point2LR p1,
      Point2LR p2,
      int skipEdgeIndex,
      out int onEdgeFlags,
      out int outsideEdgeIndex)
    {
      onEdgeFlags = 0;
      outsideEdgeIndex = -1;
      if (skipEdgeIndex != 0)
      {
        Vector2LR vector2Lr1 = new Vector2LR(p1.X - p0.X, p1.Y - p0.Y);
        Vector2LR vector2Lr2 = new Vector2LR(p.X - p0.X, p.Y - p0.Y);
        LongRational longRational = vector2Lr1.Y * vector2Lr2.X - vector2Lr1.X * vector2Lr2.Y;
        if (longRational.IsNegative)
        {
          outsideEdgeIndex = 0;
          return false;
        }
        if (longRational.IsZero)
          onEdgeFlags |= 1;
      }
      if (skipEdgeIndex != 1)
      {
        Vector2LR vector2Lr1 = new Vector2LR(p2.X - p1.X, p2.Y - p1.Y);
        Vector2LR vector2Lr2 = new Vector2LR(p.X - p1.X, p.Y - p1.Y);
        LongRational longRational = vector2Lr1.Y * vector2Lr2.X - vector2Lr1.X * vector2Lr2.Y;
        if (longRational.IsNegative)
        {
          outsideEdgeIndex = 1;
          return false;
        }
        if (longRational.IsZero)
          onEdgeFlags |= 2;
      }
      if (skipEdgeIndex != 2)
      {
        Vector2LR vector2Lr1 = new Vector2LR(p0.X - p2.X, p0.Y - p2.Y);
        Vector2LR vector2Lr2 = new Vector2LR(p.X - p2.X, p.Y - p2.Y);
        LongRational longRational = vector2Lr1.Y * vector2Lr2.X - vector2Lr1.X * vector2Lr2.Y;
        if (longRational.IsNegative)
        {
          outsideEdgeIndex = 2;
          return false;
        }
        if (longRational.IsZero)
          onEdgeFlags |= 4;
      }
      return true;
    }
  }
}
