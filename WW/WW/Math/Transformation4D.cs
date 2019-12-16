// Decompiled with JetBrains decompiler
// Type: WW.Math.Transformation4D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math
{
  public static class Transformation4D
  {
    public static readonly ITransformer4D IdentityTransform = (ITransformer4D) new Transformation4D.Class0();

    public static Matrix4D RotationAxis(Vector3D rotationAxis, double angle)
    {
      double num1 = System.Math.Sin(angle);
      double num2 = System.Math.Cos(angle);
      double num3 = 1.0 - num2;
      double num4 = rotationAxis.X * rotationAxis.X;
      double num5 = rotationAxis.Y * rotationAxis.Y;
      double num6 = rotationAxis.Z * rotationAxis.Z;
      double num7 = rotationAxis.X * rotationAxis.Y;
      double num8 = rotationAxis.X * rotationAxis.Z;
      double num9 = rotationAxis.Y * rotationAxis.Z;
      return new Matrix4D(num2 + num4 * num3, num7 * num3 - rotationAxis.Z * num1, num8 * num3 + rotationAxis.Y * num1, 0.0, num7 * num3 + rotationAxis.Z * num1, num2 + num5 * num3, num9 * num3 - rotationAxis.X * num1, 0.0, num8 * num3 - rotationAxis.Y * num1, num9 * num3 + rotationAxis.X * num1, num2 + num6 * num3, 0.0, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix4D RotateX(double angle)
    {
      double m21 = System.Math.Sin(angle);
      double num = System.Math.Cos(angle);
      return new Matrix4D(1.0, 0.0, 0.0, 0.0, 0.0, num, -m21, 0.0, 0.0, m21, num, 0.0, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix4D RotateY(double angle)
    {
      double m02 = System.Math.Sin(angle);
      double num = System.Math.Cos(angle);
      return new Matrix4D(num, 0.0, m02, 0.0, 0.0, 1.0, 0.0, 0.0, -m02, 0.0, num, 0.0, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix4D RotateZ(double angle)
    {
      double m10 = System.Math.Sin(angle);
      double num = System.Math.Cos(angle);
      return new Matrix4D(num, -m10, 0.0, 0.0, m10, num, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix4D Scaling(Vector3D v)
    {
      return new Matrix4D(v.X, 0.0, 0.0, 0.0, 0.0, v.Y, 0.0, 0.0, 0.0, 0.0, v.Z, 0.0, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix4D Scaling(Vector3D v, Point3D origin)
    {
      Vector3D v1 = (Vector3D) origin;
      return Transformation4D.Translation(v1) * Transformation4D.Scaling(v) * Transformation4D.Translation(-v1);
    }

    public static Matrix4D Scaling(double x, double y, double z)
    {
      return new Matrix4D(x, 0.0, 0.0, 0.0, 0.0, y, 0.0, 0.0, 0.0, 0.0, z, 0.0, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix4D Scaling(double s)
    {
      return new Matrix4D(s, 0.0, 0.0, 0.0, 0.0, s, 0.0, 0.0, 0.0, 0.0, s, 0.0, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix4D Scaling(double s, Point3D origin)
    {
      Vector3D v = (Vector3D) origin;
      return Transformation4D.Translation(v) * Transformation4D.Scaling(s) * Transformation4D.Translation(-v);
    }

    public static Matrix4D Translation(double x, double y, double z)
    {
      return new Matrix4D(1.0, 0.0, 0.0, x, 0.0, 1.0, 0.0, y, 0.0, 0.0, 1.0, z, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix4D Translation(Vector3D v)
    {
      return new Matrix4D(1.0, 0.0, 0.0, v.X, 0.0, 1.0, 0.0, v.Y, 0.0, 0.0, 1.0, v.Z, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix4D GetArbitraryCoordSystem(Vector3D zaxis)
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
      return Transformation4D.smethod_0(xaxis, zaxis);
    }

    private static Matrix4D smethod_0(Vector3D xaxis, Vector3D zaxis)
    {
      Vector3D yaxis = Vector3D.CrossProduct(zaxis, xaxis);
      return Transformation4D.GetCoordSystem(xaxis, yaxis, zaxis);
    }

    public static Matrix4D GetCoordSystem(Vector3D xaxis, Vector3D yaxis, Vector3D zaxis)
    {
      return new Matrix4D(xaxis.X, yaxis.X, zaxis.X, 0.0, xaxis.Y, yaxis.Y, zaxis.Y, 0.0, xaxis.Z, yaxis.Z, zaxis.Z, 0.0, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix4D GetCoordSystem(
      Vector3D xaxis,
      Vector3D yaxis,
      Vector3D zaxis,
      Point3D origin)
    {
      return new Matrix4D(xaxis.X, yaxis.X, zaxis.X, origin.X, xaxis.Y, yaxis.Y, zaxis.Y, origin.Y, xaxis.Z, yaxis.Z, zaxis.Z, origin.Z, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix4D GetPerspectiveProjectionTransform(
      double cotanMu,
      double cotanNu,
      double near,
      double far)
    {
      double num = 1.0 / (near - far);
      return new Matrix4D(cotanMu, 0.0, 0.0, 0.0, 0.0, cotanNu, 0.0, 0.0, 0.0, 0.0, (far + near) * num, 2.0 * far * near * num, 0.0, 0.0, -1.0, 0.0);
    }

    public static Matrix4D GetPerspectiveProjectionTransform(
      double left,
      double right,
      double bottom,
      double top,
      double near,
      double far)
    {
      double num1 = 1.0 / (near - far);
      double num2 = 1.0 / (right - left);
      double num3 = 1.0 / (top - bottom);
      double num4 = 2.0 * near;
      return new Matrix4D(num4 * num2, 0.0, (right + left) * num2, 0.0, 0.0, num4 * num3, (top + bottom) * num3, 0.0, 0.0, 0.0, (far + near) * num1, 2.0 * far * near * num1, 0.0, 0.0, -1.0, 0.0);
    }

    public static Matrix4D GetOrthographicProjectionTransform(
      double left,
      double right,
      double bottom,
      double top,
      double near,
      double far)
    {
      double num1 = 1.0 / (near - far);
      double num2 = 1.0 / (right - left);
      double num3 = 1.0 / (top - bottom);
      return new Matrix4D(2.0 * num2, 0.0, 0.0, -(right + left) * num2, 0.0, 2.0 * num3, 0.0, -(top + bottom) * num3, 0.0, 0.0, 2.0 * num1, (far + near) * num1, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix4D GetScaleAndTranslateTransform(
      Point2D fromP1,
      Point2D fromP2,
      Point2D toP1,
      Point2D toP2)
    {
      double x = (toP2.X - toP1.X) / (fromP2.X - fromP1.X);
      double y = (toP2.Y - toP1.Y) / (fromP2.Y - fromP1.Y);
      Point2D midPoint1 = Point2D.GetMidPoint(toP1, toP2);
      Point2D midPoint2 = Point2D.GetMidPoint(fromP1, fromP2);
      return Transformation4D.Translation(midPoint1.X, midPoint1.Y, 0.0) * Transformation4D.Scaling(x, y, 1.0) * Transformation4D.Translation(-midPoint2.X, -midPoint2.Y, 0.0);
    }

    public static Matrix4D GetScaleTransform(
      Point3D fromPoint1,
      Point3D fromPoint2,
      Point3D fromReferencePoint,
      Point3D toPoint1,
      Point3D toPoint2,
      Point3D toReferencePoint)
    {
      double scaling;
      return Transformation4D.GetScaleTransform(fromPoint1, fromPoint2, fromReferencePoint, toPoint1, toPoint2, toReferencePoint, out scaling);
    }

    public static Matrix4D GetScaleTransform(
      Point3D fromPoint1,
      Point3D fromPoint2,
      Point3D fromReferencePoint,
      Point3D toPoint1,
      Point3D toPoint2,
      Point3D toReferencePoint,
      out double scaling)
    {
      Vector3D vector3D1 = toPoint2 - toPoint1;
      Vector3D vector3D2 = fromPoint2 - fromPoint1;
      double num1 = vector3D1.X / vector3D2.X;
      double num2 = vector3D1.Y / vector3D2.Y;
      scaling = System.Math.Abs(num1) <= System.Math.Abs(num2) ? num1 : num2;
      scaling = System.Math.Abs(scaling);
      Matrix4D matrix4D = Transformation4D.Translation(0.0, 0.0, toPoint1.Z) * Transformation4D.Scaling(scaling * (double) System.Math.Sign(num1), scaling * (double) System.Math.Sign(num2), scaling) * Transformation4D.Translation(0.0, 0.0, -fromPoint1.Z);
      Point3D point3D = matrix4D.Transform(fromReferencePoint);
      return Transformation4D.Translation(toReferencePoint - point3D) * matrix4D;
    }

    public static void GetScaleToIntegralTransforms(
      Bounds2D bounds,
      long maxTargetCoordinate,
      out Matrix4D scaleTransform,
      out Matrix4D inverseScaleTransform)
    {
      scaleTransform = Transformation4D.GetScaleAndTranslateTransform(bounds.Min, bounds.Max, new Point2D((double) -maxTargetCoordinate + 0.5, (double) -maxTargetCoordinate + 0.5), new Point2D((double) maxTargetCoordinate + 0.5, (double) maxTargetCoordinate + 0.5));
      inverseScaleTransform = Transformation4D.GetScaleAndTranslateTransform(new Point2D((double) -maxTargetCoordinate, (double) -maxTargetCoordinate), new Point2D((double) maxTargetCoordinate, (double) maxTargetCoordinate), bounds.Min, bounds.Max);
    }

    public static Matrix4D GetBoundsToScreenTransform(
      Bounds3D bounds,
      int width,
      int height)
    {
      return Transformation4D.GetBoundsToScreenTransform(bounds, width, height, 0);
    }

    public static Matrix4D GetBoundsToScreenTransform(
      Bounds3D bounds,
      int width,
      int height,
      int margin)
    {
      if (!bounds.Initialized)
        return Matrix4D.Identity;
      return Transformation4D.GetBoundsToScreenTransform(bounds.Min, bounds.Max, width, height, margin);
    }

    public static Matrix4D GetBoundsToScreenTransform(
      Bounds2D bounds,
      int width,
      int height)
    {
      return Transformation4D.GetBoundsToScreenTransform(bounds, width, height, 0);
    }

    public static Matrix4D GetBoundsToScreenTransform(
      Bounds2D bounds,
      int width,
      int height,
      int margin)
    {
      if (!bounds.Initialized)
        return Matrix4D.Identity;
      return Transformation4D.GetBoundsToScreenTransform(bounds.Min, bounds.Max, width, height, margin);
    }

    public static Matrix4D GetBoundsToScreenTransform(
      Point3D min,
      Point3D max,
      int width,
      int height)
    {
      return Transformation4D.GetBoundsToScreenTransform(min, max, width, height, 0);
    }

    public static Matrix4D GetBoundsToScreenTransform(
      Point3D min,
      Point3D max,
      int width,
      int height,
      int margin)
    {
      return Transformation4D.GetBoundsToScreenTransform(min.X, min.Y, max.X, max.Y, width, height, margin);
    }

    public static Matrix4D GetBoundsToScreenTransform(
      Point2D min,
      Point2D max,
      int width,
      int height)
    {
      return Transformation4D.GetBoundsToScreenTransform(min, max, width, height, 0);
    }

    public static Matrix4D GetBoundsToScreenTransform(
      Point2D min,
      Point2D max,
      int width,
      int height,
      int margin)
    {
      return Transformation4D.GetBoundsToScreenTransform(min.X, min.Y, max.X, max.Y, width, height, margin);
    }

    public static Matrix4D GetBoundsToScreenTransform(
      double minX,
      double minY,
      double maxX,
      double maxY,
      int width,
      int height)
    {
      return Transformation4D.GetBoundsToScreenTransform(minX, minY, maxX, maxY, width, height, 0);
    }

    public static Matrix4D GetBoundsToScreenTransform(
      double minX,
      double minY,
      double maxX,
      double maxY,
      int width,
      int height,
      int margin)
    {
      return Transformation4D.GetScaleTransform(new Point3D(minX, minY, 0.0), new Point3D(maxX, maxY, 0.0), new Point3D(0.5 * (minX + maxX), 0.5 * (minY + maxY), 0.0), new Point3D((double) margin, (double) (height - 1 - margin), 0.0), new Point3D((double) (width - 1 - margin), (double) margin, 0.0), new Point3D(0.5 * (double) (width - 1), 0.5 * (double) (height - 1), 0.0));
    }

    public static bool IsSane(Matrix4D transform)
    {
      double determinant = transform.GetDeterminant();
      if (!double.IsNaN(determinant))
        return !double.IsInfinity(determinant);
      return false;
    }

    private class Class0 : ITransformer4D
    {
      public Vector4D Transform(Vector4D p)
      {
        return p;
      }

      public Point2D TransformToPoint2D(Vector4D p)
      {
        return (Point2D) p;
      }

      public Point3D TransformToPoint3D(Vector4D p)
      {
        return (Point3D) p;
      }

      public Vector4D TransformTo4D(Point2D p)
      {
        return new Vector4D(p.X, p.Y, 0.0, 1.0);
      }
    }
  }
}
