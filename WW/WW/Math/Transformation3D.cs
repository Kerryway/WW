// Decompiled with JetBrains decompiler
// Type: WW.Math.Transformation3D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math
{
  public static class Transformation3D
  {
    public static Matrix3D Rotate(double angle)
    {
      double m10 = System.Math.Sin(angle);
      double num = System.Math.Cos(angle);
      return new Matrix3D(num, -m10, 0.0, m10, num, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix3D RotateX(double angle)
    {
      double m21 = System.Math.Sin(angle);
      double num = System.Math.Cos(angle);
      return new Matrix3D(1.0, 0.0, 0.0, 0.0, num, -m21, 0.0, m21, num);
    }

    public static Matrix3D RotateY(double angle)
    {
      double m02 = System.Math.Sin(angle);
      double num = System.Math.Cos(angle);
      return new Matrix3D(num, 0.0, m02, 0.0, 1.0, 0.0, -m02, 0.0, num);
    }

    public static Matrix3D RotateZ(double angle)
    {
      double m10 = System.Math.Sin(angle);
      double num = System.Math.Cos(angle);
      return new Matrix3D(num, -m10, 0.0, m10, num, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix3D Scaling(Vector2D v)
    {
      return new Matrix3D(v.X, 0.0, 0.0, 0.0, v.Y, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix3D Scaling(double x, double y)
    {
      return new Matrix3D(x, 0.0, 0.0, 0.0, y, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix3D Scaling(Vector3D v)
    {
      return new Matrix3D(v.X, 0.0, 0.0, 0.0, v.Y, 0.0, 0.0, 0.0, v.Z);
    }

    public static Matrix3D Scaling(double x, double y, double z)
    {
      return new Matrix3D(x, 0.0, 0.0, 0.0, y, 0.0, 0.0, 0.0, z);
    }

    public static Matrix3D Scaling2D(double s)
    {
      return new Matrix3D(s, 0.0, 0.0, 0.0, s, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix3D Scaling(double s)
    {
      return new Matrix3D(s, 0.0, 0.0, 0.0, s, 0.0, 0.0, 0.0, s);
    }

    public static Matrix3D Translation(double x, double y)
    {
      return new Matrix3D(1.0, 0.0, x, 0.0, 1.0, y, 0.0, 0.0, 1.0);
    }

    public static Matrix3D Translation(Vector2D v)
    {
      return new Matrix3D(1.0, 0.0, v.X, 0.0, 1.0, v.Y, 0.0, 0.0, 1.0);
    }

    public static Matrix3D GetCoordSystem(Vector2D xaxis)
    {
      Vector2D yaxis = new Vector2D(xaxis.Y, -xaxis.X);
      return Transformation3D.GetCoordSystem(xaxis, yaxis);
    }

    public static Matrix3D GetCoordSystem(Vector2D xaxis, Vector2D yaxis)
    {
      return new Matrix3D(xaxis.X, yaxis.X, 0.0, xaxis.Y, yaxis.Y, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix3D GetCoordSystem(Vector2D xaxis, Vector2D yaxis, Point2D origin)
    {
      return new Matrix3D(xaxis.X, yaxis.X, origin.X, xaxis.Y, yaxis.Y, origin.Y, 0.0, 0.0, 1.0);
    }

    public static Matrix3D GetArbitraryCoordSystem(Vector3D zaxis)
    {
      Vector3D xaxis;
      if (System.Math.Abs(zaxis.X) > System.Math.Abs(zaxis.Y))
      {
        double num = 1.0 / System.Math.Sqrt(zaxis.X * zaxis.X + zaxis.Z * zaxis.Z);
        xaxis = new Vector3D(-zaxis.Z * num, 0.0, zaxis.X * num);
      }
      else
      {
        double num = 1.0 / System.Math.Sqrt(zaxis.Y * zaxis.Y + zaxis.Z * zaxis.Z);
        xaxis = new Vector3D(0.0, zaxis.Z * num, -zaxis.Y * num);
      }
      return Transformation3D.smethod_0(xaxis, zaxis);
    }

    private static Matrix3D smethod_0(Vector3D xaxis, Vector3D zaxis)
    {
      Vector3D yaxis = Vector3D.CrossProduct(zaxis, xaxis);
      return Transformation3D.GetCoordSystem(xaxis, yaxis, zaxis);
    }

    public static Matrix3D GetCoordSystem(Vector3D xaxis, Vector3D yaxis, Vector3D zaxis)
    {
      return new Matrix3D(xaxis.X, yaxis.X, zaxis.X, xaxis.Y, yaxis.Y, zaxis.Y, xaxis.Z, yaxis.Z, zaxis.Z);
    }

    public static Matrix3D From(Matrix4D transform)
    {
      return new Matrix3D(transform.M00, transform.M01, transform.M03, transform.M10, transform.M11, transform.M13, transform.M30, transform.M31, transform.M33);
    }
  }
}
