// Decompiled with JetBrains decompiler
// Type: WW.Math.Transformation2F
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math
{
  public static class Transformation2F
  {
    public static Matrix2F Rotate(float angle)
    {
      float m10 = (float) System.Math.Sin((double) angle);
      float num = (float) System.Math.Cos((double) angle);
      return new Matrix2F(num, -m10, m10, num);
    }

    public static Matrix2F Scaling(Vector2F v)
    {
      return new Matrix2F(v.X, 0.0f, 0.0f, v.Y);
    }

    public static Matrix2F Scaling(float x, float y)
    {
      return new Matrix2F(x, 0.0f, 0.0f, y);
    }

    public static Matrix2F Scaling(float s)
    {
      return new Matrix2F(s, 0.0f, 0.0f, s);
    }

    public static Matrix2F GetCoordSystem(Vector2F xaxis, Vector2F yaxis)
    {
      return new Matrix2F(xaxis.X, yaxis.X, xaxis.Y, yaxis.Y);
    }
  }
}
