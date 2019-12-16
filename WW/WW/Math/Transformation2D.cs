// Decompiled with JetBrains decompiler
// Type: WW.Math.Transformation2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math
{
  public static class Transformation2D
  {
    public static Matrix2D Rotate(double angle)
    {
      double m10 = System.Math.Sin(angle);
      double num = System.Math.Cos(angle);
      return new Matrix2D(num, -m10, m10, num);
    }

    public static Matrix2D Scaling(Vector2D v)
    {
      return new Matrix2D(v.X, 0.0, 0.0, v.Y);
    }

    public static Matrix2D Scaling(double x, double y)
    {
      return new Matrix2D(x, 0.0, 0.0, y);
    }

    public static Matrix2D Scaling(double s)
    {
      return new Matrix2D(s, 0.0, 0.0, s);
    }

    public static Matrix2D GetCoordSystem(Vector2D xaxis, Vector2D yaxis)
    {
      return new Matrix2D(xaxis.X, yaxis.X, xaxis.Y, yaxis.Y);
    }
  }
}
