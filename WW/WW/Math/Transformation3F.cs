// Decompiled with JetBrains decompiler
// Type: WW.Math.Transformation3F
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math
{
  public static class Transformation3F
  {
    public static Matrix3F Rotate(double angle)
    {
      float m10 = (float) System.Math.Sin(angle);
      float num = (float) System.Math.Cos(angle);
      return new Matrix3F(num, -m10, 0.0f, m10, num, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix3F RotateX(double angle)
    {
      float m21 = (float) System.Math.Sin(angle);
      float num = (float) System.Math.Cos(angle);
      return new Matrix3F(1f, 0.0f, 0.0f, 0.0f, num, -m21, 0.0f, m21, num);
    }

    public static Matrix3F RotateY(double angle)
    {
      float m02 = (float) System.Math.Sin(angle);
      float num = (float) System.Math.Cos(angle);
      return new Matrix3F(num, 0.0f, m02, 0.0f, 1f, 0.0f, -m02, 0.0f, num);
    }

    public static Matrix3F RotateZ(double angle)
    {
      float m10 = (float) System.Math.Sin(angle);
      float num = (float) System.Math.Cos(angle);
      return new Matrix3F(num, -m10, 0.0f, m10, num, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix3F Scaling(Vector2F v)
    {
      return new Matrix3F(v.X, 0.0f, 0.0f, 0.0f, v.Y, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix3F Scaling(float x, float y)
    {
      return new Matrix3F(x, 0.0f, 0.0f, 0.0f, y, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix3F Scaling(Vector3F v)
    {
      return new Matrix3F(v.X, 0.0f, 0.0f, 0.0f, v.Y, 0.0f, 0.0f, 0.0f, v.Z);
    }

    public static Matrix3F Scaling(float x, float y, float z)
    {
      return new Matrix3F(x, 0.0f, 0.0f, 0.0f, y, 0.0f, 0.0f, 0.0f, z);
    }

    public static Matrix3F Scaling2D(float s)
    {
      return new Matrix3F(s, 0.0f, 0.0f, 0.0f, s, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix3F Scaling(float s)
    {
      return new Matrix3F(s, 0.0f, 0.0f, 0.0f, s, 0.0f, 0.0f, 0.0f, s);
    }

    public static Matrix3F Translation(float x, float y)
    {
      return new Matrix3F(1f, 0.0f, x, 0.0f, 1f, y, 0.0f, 0.0f, 1f);
    }

    public static Matrix3F Translation(Vector2F v)
    {
      return new Matrix3F(1f, 0.0f, v.X, 0.0f, 1f, v.Y, 0.0f, 0.0f, 1f);
    }

    public static Matrix3F GetCoordSystem(Vector2F xaxis)
    {
      Vector2F yaxis = new Vector2F(xaxis.Y, -xaxis.X);
      return Transformation3F.GetCoordSystem(xaxis, yaxis);
    }

    public static Matrix3F GetCoordSystem(Vector2F xaxis, Vector2F yaxis)
    {
      return new Matrix3F(xaxis.X, yaxis.X, 0.0f, xaxis.Y, yaxis.Y, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix3F GetCoordSystem(Vector2F xaxis, Vector2F yaxis, Point2F origin)
    {
      return new Matrix3F(xaxis.X, yaxis.X, origin.X, xaxis.Y, yaxis.Y, origin.Y, 0.0f, 0.0f, 1f);
    }

    public static Matrix3F GetArbitraryCoordSystem(Vector3F zaxis)
    {
      Vector3F xaxis;
      if ((double) System.Math.Abs(zaxis.X) > (double) System.Math.Abs(zaxis.Y))
      {
        double num = 1.0 / System.Math.Sqrt((double) zaxis.X * (double) zaxis.X + (double) zaxis.Z * (double) zaxis.Z);
        xaxis = new Vector3F((float) (-(double) zaxis.Z * num), 0.0f, zaxis.X * (float) num);
      }
      else
      {
        double num = 1.0 / System.Math.Sqrt((double) zaxis.Y * (double) zaxis.Y + (double) zaxis.Z * (double) zaxis.Z);
        xaxis = new Vector3F(0.0f, zaxis.Z * (float) num, (float) (-(double) zaxis.Y * num));
      }
      return Transformation3F.smethod_0(xaxis, zaxis);
    }

    private static Matrix3F smethod_0(Vector3F xaxis, Vector3F zaxis)
    {
      Vector3F yaxis = Vector3F.CrossProduct(zaxis, xaxis);
      return Transformation3F.GetCoordSystem(xaxis, yaxis, zaxis);
    }

    public static Matrix3F GetCoordSystem(Vector3F xaxis, Vector3F yaxis, Vector3F zaxis)
    {
      return new Matrix3F(xaxis.X, yaxis.X, zaxis.X, xaxis.Y, yaxis.Y, zaxis.Y, xaxis.Z, yaxis.Z, zaxis.Z);
    }
  }
}
