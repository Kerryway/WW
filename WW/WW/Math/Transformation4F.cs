// Decompiled with JetBrains decompiler
// Type: WW.Math.Transformation4F
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math
{
  public static class Transformation4F
  {
    public static Matrix4F RotationAxis(Vector3F rotationAxis, float angle)
    {
      float num1 = (float) System.Math.Sin((double) angle);
      float num2 = (float) System.Math.Cos((double) angle);
      float num3 = 1f - num2;
      float num4 = rotationAxis.X * rotationAxis.X;
      float num5 = rotationAxis.Y * rotationAxis.Y;
      float num6 = rotationAxis.Z * rotationAxis.Z;
      float num7 = rotationAxis.X * rotationAxis.Y;
      float num8 = rotationAxis.X * rotationAxis.Z;
      float num9 = rotationAxis.Y * rotationAxis.Z;
      return new Matrix4F(num2 + num4 * num3, (float) ((double) num7 * (double) num3 - (double) rotationAxis.Z * (double) num1), (float) ((double) num8 * (double) num3 + (double) rotationAxis.Y * (double) num1), 0.0f, (float) ((double) num7 * (double) num3 + (double) rotationAxis.Z * (double) num1), num2 + num5 * num3, (float) ((double) num9 * (double) num3 - (double) rotationAxis.X * (double) num1), 0.0f, (float) ((double) num8 * (double) num3 - (double) rotationAxis.Y * (double) num1), (float) ((double) num9 * (double) num3 + (double) rotationAxis.X * (double) num1), num2 + num6 * num3, 0.0f, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix4F RotateX(float angle)
    {
      float m21 = (float) System.Math.Sin((double) angle);
      float num = (float) System.Math.Cos((double) angle);
      return new Matrix4F(1f, 0.0f, 0.0f, 0.0f, 0.0f, num, -m21, 0.0f, 0.0f, m21, num, 0.0f, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix4F RotateY(float angle)
    {
      float m02 = (float) System.Math.Sin((double) angle);
      float num = (float) System.Math.Cos((double) angle);
      return new Matrix4F(num, 0.0f, m02, 0.0f, 0.0f, 1f, 0.0f, 0.0f, -m02, 0.0f, num, 0.0f, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix4F RotateZ(float angle)
    {
      float m10 = (float) System.Math.Sin((double) angle);
      float num = (float) System.Math.Cos((double) angle);
      return new Matrix4F(num, -m10, 0.0f, 0.0f, m10, num, 0.0f, 0.0f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix4F Scaling(Vector3F v)
    {
      return new Matrix4F(v.X, 0.0f, 0.0f, 0.0f, 0.0f, v.Y, 0.0f, 0.0f, 0.0f, 0.0f, v.Z, 0.0f, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix4F Scaling(Vector3F v, Point3F origin)
    {
      Vector3F v1 = (Vector3F) origin;
      return Transformation4F.Translation(v1) * Transformation4F.Scaling(v) * Transformation4F.Translation(-v1);
    }

    public static Matrix4F Scaling(float x, float y, float z)
    {
      return new Matrix4F(x, 0.0f, 0.0f, 0.0f, 0.0f, y, 0.0f, 0.0f, 0.0f, 0.0f, z, 0.0f, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix4F Scaling(float s)
    {
      return new Matrix4F(s, 0.0f, 0.0f, 0.0f, 0.0f, s, 0.0f, 0.0f, 0.0f, 0.0f, s, 0.0f, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix4F Scaling(float s, Point3F origin)
    {
      Vector3F v = (Vector3F) origin;
      return Transformation4F.Translation(v) * Transformation4F.Scaling(s) * Transformation4F.Translation(-v);
    }

    public static Matrix4F Translation(float x, float y, float z)
    {
      return new Matrix4F(1f, 0.0f, 0.0f, x, 0.0f, 1f, 0.0f, y, 0.0f, 0.0f, 1f, z, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix4F Translation(Vector3F v)
    {
      return new Matrix4F(1f, 0.0f, 0.0f, v.X, 0.0f, 1f, 0.0f, v.Y, 0.0f, 0.0f, 1f, v.Z, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix4F GetArbitraryCoordSystem(Vector3F zaxis)
    {
      Vector3F xaxis;
      if ((double) System.Math.Abs(zaxis.X) > (double) System.Math.Abs(zaxis.Y))
      {
        float num = 1f / (float) System.Math.Sqrt((double) zaxis.X * (double) zaxis.X + (double) zaxis.Z * (double) zaxis.Z);
        xaxis = new Vector3F(-zaxis.Z * num, 0.0f, zaxis.X * num);
      }
      else
      {
        float num = 1f / (float) System.Math.Sqrt((double) zaxis.Y * (double) zaxis.Y + (double) zaxis.Z * (double) zaxis.Z);
        xaxis = new Vector3F(0.0f, zaxis.Z * num, -zaxis.Y * num);
      }
      return Transformation4F.smethod_0(xaxis, zaxis);
    }

    private static Matrix4F smethod_0(Vector3F xaxis, Vector3F zaxis)
    {
      Vector3F yaxis = Vector3F.CrossProduct(zaxis, xaxis);
      return Transformation4F.GetCoordSystem(xaxis, yaxis, zaxis);
    }

    public static Matrix4F GetCoordSystem(Vector3F xaxis, Vector3F yaxis, Vector3F zaxis)
    {
      return new Matrix4F(xaxis.X, yaxis.X, zaxis.X, 0.0f, xaxis.Y, yaxis.Y, zaxis.Y, 0.0f, xaxis.Z, yaxis.Z, zaxis.Z, 0.0f, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix4F GetCoordSystem(
      Vector3F xaxis,
      Vector3F yaxis,
      Vector3F zaxis,
      Point3F origin)
    {
      return new Matrix4F(xaxis.X, yaxis.X, zaxis.X, origin.X, xaxis.Y, yaxis.Y, zaxis.Y, origin.Y, xaxis.Z, yaxis.Z, zaxis.Z, origin.Z, 0.0f, 0.0f, 0.0f, 1f);
    }

    public static Matrix4F GetPerspectiveProjectionTransform(
      float cotanMu,
      float cotanNu,
      float near,
      float far)
    {
      float num = (float) (1.0 / ((double) near - (double) far));
      return new Matrix4F(cotanMu, 0.0f, 0.0f, 0.0f, 0.0f, cotanNu, 0.0f, 0.0f, 0.0f, 0.0f, (far + near) * num, 2f * far * near * num, 0.0f, 0.0f, -1f, 0.0f);
    }

    public static Matrix4F GetPerspectiveProjectionTransform(
      float left,
      float right,
      float bottom,
      float top,
      float near,
      float far)
    {
      float num1 = (float) (1.0 / ((double) near - (double) far));
      float num2 = (float) (1.0 / ((double) right - (double) left));
      float num3 = (float) (1.0 / ((double) top - (double) bottom));
      float num4 = 2f * near;
      return new Matrix4F(num4 * num2, 0.0f, (right + left) * num2, 0.0f, 0.0f, num4 * num3, (top + bottom) * num3, 0.0f, 0.0f, 0.0f, (far + near) * num1, 2f * far * near * num1, 0.0f, 0.0f, -1f, 0.0f);
    }

    public static Matrix4F GetOrthographicProjectionTransform(
      float left,
      float right,
      float bottom,
      float top,
      float near,
      float far)
    {
      float num1 = (float) (1.0 / ((double) near - (double) far));
      float num2 = (float) (1.0 / ((double) right - (double) left));
      float num3 = (float) (1.0 / ((double) top - (double) bottom));
      return new Matrix4F(2f * num2, 0.0f, 0.0f, (float) -((double) right + (double) left) * num2, 0.0f, 2f * num3, 0.0f, (float) -((double) top + (double) bottom) * num3, 0.0f, 0.0f, 2f * num1, (far + near) * num1, 0.0f, 0.0f, 0.0f, 1f);
    }
  }
}
