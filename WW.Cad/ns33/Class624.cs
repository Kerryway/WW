// Decompiled with JetBrains decompiler
// Type: ns33.Class624
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace ns33
{
  internal static class Class624
  {
    public static ILineTypeScaler Create(Matrix3D matrix)
    {
      Vector3D u = new Vector3D(matrix.M00, matrix.M10, matrix.M20);
      Vector3D v1 = new Vector3D(matrix.M01, matrix.M11, matrix.M21);
      Vector3D v2 = new Vector3D(matrix.M02, matrix.M12, matrix.M22);
      double lengthSquared1 = u.GetLengthSquared();
      double lengthSquared2 = v1.GetLengthSquared();
      double lengthSquared3 = v2.GetLengthSquared();
      return (!MathUtil.AreApproxEqual(Vector3D.DotProduct(u, v1), 0.0) ? 0 : (MathUtil.AreApproxEqual(Vector3D.DotProduct(u, v2), 0.0) ? 1 : 0)) == 0 ? (!MathUtil.AreApproxEqual(lengthSquared1, lengthSquared2) || !MathUtil.AreApproxEqual(lengthSquared1, lengthSquared3) ? (ILineTypeScaler) new Class624.Class630(new Vector3D(System.Math.Sqrt(lengthSquared1), System.Math.Sqrt(lengthSquared2), System.Math.Sqrt(lengthSquared3)), new Vector3D(lengthSquared1, lengthSquared2, lengthSquared3), matrix) : (ILineTypeScaler) new Class624.Class629(lengthSquared1, matrix)) : (!MathUtil.AreApproxEqual(lengthSquared1, lengthSquared2) || !MathUtil.AreApproxEqual(lengthSquared1, lengthSquared3) ? (ILineTypeScaler) new Class624.Class631(new Vector3D(System.Math.Sqrt(lengthSquared1), System.Math.Sqrt(lengthSquared2), System.Math.Sqrt(lengthSquared3)), new Vector3D(lengthSquared1, lengthSquared2, lengthSquared3)) : (lengthSquared1 != 0.0 ? (!MathUtil.AreApproxEqual(1.0, lengthSquared1) ? (ILineTypeScaler) new Class624.Class627(System.Math.Sqrt(lengthSquared1)) : (ILineTypeScaler) Class624.Class626.class626_0) : (ILineTypeScaler) Class624.Class625.class625_0));
    }

    public static double GetLength(Polyline2D polyline, ILineTypeScaler lineTypeScaler)
    {
      double num = 0.0;
      if (polyline.Count > 1)
      {
        Point2D point2D1 = polyline[0];
        for (int index = 1; index < polyline.Count; ++index)
        {
          Point2D point2D2 = polyline[index];
          num += lineTypeScaler.GetScaledLength(point2D2 - point2D1);
          point2D1 = point2D2;
        }
        if (polyline.Closed)
          num += lineTypeScaler.GetScaledLength(polyline[0] - point2D1);
      }
      return num;
    }

    public static double GetLength(Polyline3D polyline, ILineTypeScaler lineTypeScaler)
    {
      double num = 0.0;
      if (polyline.Count > 1)
      {
        Point3D point3D1 = polyline[0];
        for (int index = 1; index < polyline.Count; ++index)
        {
          Point3D point3D2 = polyline[index];
          num += lineTypeScaler.GetScaledLength(point3D2 - point3D1);
          point3D1 = point3D2;
        }
        if (polyline.Closed)
          num += lineTypeScaler.GetScaledLength(polyline[0] - point3D1);
      }
      return num;
    }

    public static double GetLength(Polyline3DT polyline, ILineTypeScaler lineTypeScaler)
    {
      double num = 0.0;
      if (polyline.Count > 1)
      {
        Point3D point3D = polyline[0].Position;
        for (int index = 1; index < polyline.Count; ++index)
        {
          Point3D position = polyline[index].Position;
          num += lineTypeScaler.GetScaledLength(position - point3D);
          point3D = position;
        }
        if (polyline.Closed)
          num += lineTypeScaler.GetScaledLength(polyline[0].Position - point3D);
      }
      return num;
    }

    public static double GetLength(Polyline2D2N polyline, ILineTypeScaler lineTypeScaler)
    {
      double num = 0.0;
      if (polyline.Count > 1)
      {
        Point2D2N point2D2N1 = polyline[0];
        for (int index = 1; index < polyline.Count; ++index)
        {
          Point2D2N point2D2N2 = polyline[index];
          num += lineTypeScaler.GetScaledLength(point2D2N2.Position - point2D2N1.Position);
          point2D2N1 = point2D2N2;
        }
        if (polyline.Closed)
          num += lineTypeScaler.GetScaledLength(polyline[0].Position - point2D2N1.Position);
      }
      return num;
    }

    public static double GetLength(Polyline2D2WN polyline, ILineTypeScaler lineTypeScaler)
    {
      double num = 0.0;
      if (polyline.Count > 1)
      {
        Point2D2WN point2D2Wn1 = polyline[0];
        for (int index = 1; index < polyline.Count; ++index)
        {
          Point2D2WN point2D2Wn2 = polyline[index];
          num += lineTypeScaler.GetScaledLength(point2D2Wn2.Position - point2D2Wn1.Position);
          point2D2Wn1 = point2D2Wn2;
        }
        if (polyline.Closed)
          num += lineTypeScaler.GetScaledLength(polyline[0].Position - point2D2Wn1.Position);
      }
      return num;
    }

    internal class Class625 : ILineTypeScaler
    {
      public static readonly Class624.Class625 class625_0 = new Class624.Class625();

      private Class625()
      {
      }

      public double GetScaledLength(Vector2D v)
      {
        return 0.0;
      }

      public double GetScaledLength(Vector3D v)
      {
        return 0.0;
      }

      public void GetLengths(Vector2D v, out double length, out double scaledLength)
      {
        length = v.GetLength();
        scaledLength = 0.0;
      }

      public Matrix3D ApplyWcsToOcsCorrection(Matrix3D m)
      {
        return Matrix3D.Zero;
      }
    }

    internal class Class626 : ILineTypeScaler
    {
      public static readonly Class624.Class626 class626_0 = new Class624.Class626();

      private Class626()
      {
      }

      public double GetScaledLength(Vector2D v)
      {
        return v.GetLength();
      }

      public double GetScaledLength(Vector3D v)
      {
        return v.GetLength();
      }

      public void GetLengths(Vector2D v, out double length, out double scaledLength)
      {
        length = v.GetLength();
        scaledLength = length;
      }

      public Matrix3D ApplyWcsToOcsCorrection(Matrix3D m)
      {
        return m;
      }
    }

    internal class Class627 : ILineTypeScaler
    {
      private readonly double double_0;
      private readonly double double_1;

      public Class627(double scaleFactor)
      {
        this.double_0 = scaleFactor;
        this.double_1 = 1.0 / scaleFactor;
      }

      public double GetScaledLength(Vector2D v)
      {
        return this.double_0 * v.GetLength();
      }

      public double GetScaledLength(Vector3D v)
      {
        return this.double_0 * v.GetLength();
      }

      public void GetLengths(Vector2D v, out double length, out double scaledLength)
      {
        length = v.GetLength();
        scaledLength = this.double_0 * length;
      }

      public Matrix3D ApplyWcsToOcsCorrection(Matrix3D m)
      {
        return new Matrix3D(m.M00 * this.double_1, m.M01 * this.double_1, m.M02 * this.double_1, m.M10 * this.double_1, m.M11 * this.double_1, m.M12 * this.double_1, m.M20 * this.double_1, m.M21 * this.double_1, m.M22 * this.double_1);
      }
    }

    internal abstract class Class628
    {
      protected Matrix3D matrix3D_0;
      protected Matrix3D matrix3D_1;

      public Class628(Matrix3D scaleMatrix)
      {
        this.matrix3D_0 = scaleMatrix;
        this.matrix3D_1 = scaleMatrix.GetInverse();
      }

      public Matrix3D ApplyWcsToOcsCorrection(Matrix3D m)
      {
        Vector3D vector3D1 = new Vector3D(m.M00, m.M10, m.M20);
        Vector3D v1 = this.matrix3D_0.Transform(vector3D1);
        double m00 = System.Math.Sqrt(vector3D1.GetLengthSquared() / v1.GetLengthSquared());
        Vector3D vector3D2 = new Vector3D(m.M02, m.M12, m.M22);
        Vector3D u = this.matrix3D_1.Transform(Vector3D.CrossProduct(this.matrix3D_0.Transform(vector3D2), v1).GetUnit());
        Vector3D v2 = new Vector3D(m.M01, m.M11, m.M21);
        Vector3D vector3D3 = new Vector3D(Vector3D.DotProduct(u, vector3D1), Vector3D.DotProduct(u, v2), Vector3D.DotProduct(u, vector3D2));
        Matrix3D matrix3D = new Matrix3D(m00, vector3D3.X, 0.0, 0.0, vector3D3.Y, 1.0, 0.0, vector3D3.Z, 1.0);
        return m * matrix3D;
      }
    }

    internal class Class629 : Class624.Class628, ILineTypeScaler
    {
      private readonly double double_0;

      public Class629(double scaleFactor, Matrix3D scaleMatrix)
        : base(scaleMatrix)
      {
        this.double_0 = scaleFactor;
      }

      public double GetScaledLength(Vector2D v)
      {
        return this.double_0 * v.GetLength();
      }

      public double GetScaledLength(Vector3D v)
      {
        return this.double_0 * v.GetLength();
      }

      public void GetLengths(Vector2D v, out double length, out double scaledLength)
      {
        length = v.GetLength();
        scaledLength = this.double_0 * length;
      }
    }

    internal class Class631 : ILineTypeScaler
    {
      private readonly Vector3D vector3D_0;
      private readonly Vector3D vector3D_1;
      private readonly Vector3D vector3D_2;

      public Class631(Vector3D scaling, Vector3D scalingSquared)
      {
        this.vector3D_0 = scaling;
        this.vector3D_1 = scalingSquared;
        this.vector3D_2 = new Vector3D(1.0 / scaling.X, 1.0 / scaling.Y, 1.0 / scaling.Z);
      }

      public double GetScaledLength(Vector2D v)
      {
        double num1 = v.X * this.vector3D_0.X;
        double num2 = v.Y * this.vector3D_0.Y;
        return System.Math.Sqrt(num1 * num1 + num2 * num2);
      }

      public double GetScaledLength(Vector3D v)
      {
        double num1 = v.X * this.vector3D_0.X;
        double num2 = v.Y * this.vector3D_0.Y;
        double num3 = v.Z * this.vector3D_0.Z;
        return System.Math.Sqrt(num1 * num1 + num2 * num2 + num3 * num3);
      }

      public void GetLengths(Vector2D v, out double length, out double scaledLength)
      {
        double x = v.X;
        double y = v.Y;
        double num1 = x * x;
        double num2 = y * y;
        length = System.Math.Sqrt(num1 + num2);
        scaledLength = System.Math.Sqrt(num1 * this.vector3D_1.X + num2 * this.vector3D_1.Y);
      }

      public Matrix3D ApplyWcsToOcsCorrection(Matrix3D m)
      {
        Vector3D u1 = new Vector3D(m.M00, m.M10, m.M20);
        Vector3D v1 = new Vector3D(this.vector3D_0.X * u1.X, this.vector3D_0.Y * u1.Y, this.vector3D_0.Z * u1.Z);
        double m00 = System.Math.Sqrt(u1.GetLengthSquared() / v1.GetLengthSquared());
        Vector3D u2 = new Vector3D(m.M02, m.M12, m.M22);
        Vector3D unit = Vector3D.CrossProduct(new Vector3D(this.vector3D_0.X * u2.X, this.vector3D_0.Y * u2.Y, this.vector3D_0.Z * u2.Z), v1).GetUnit();
        Vector3D v2 = new Vector3D(this.vector3D_2.X * unit.X, this.vector3D_2.Y * unit.Y, this.vector3D_2.Z * unit.Z);
        Vector3D u3 = new Vector3D(m.M01, m.M11, m.M21);
        Vector3D vector3D = new Vector3D(Vector3D.DotProduct(u1, v2), Vector3D.DotProduct(u3, v2), Vector3D.DotProduct(u2, v2));
        Matrix3D matrix3D = new Matrix3D(m00, vector3D.X, 0.0, 0.0, vector3D.Y, 1.0, 0.0, vector3D.Z, 1.0);
        return m * matrix3D;
      }
    }

    internal class Class630 : Class624.Class628, ILineTypeScaler
    {
      private readonly Vector3D vector3D_0;
      private readonly Vector3D vector3D_1;

      public Class630(Vector3D scaling, Vector3D scalingSquared, Matrix3D scaleMatrix)
        : base(scaleMatrix)
      {
        this.vector3D_0 = scaling;
        this.vector3D_1 = scalingSquared;
      }

      public double GetScaledLength(Vector2D v)
      {
        double num1 = v.X * this.vector3D_0.X;
        double num2 = v.Y * this.vector3D_0.Y;
        return System.Math.Sqrt(num1 * num1 + num2 * num2);
      }

      public double GetScaledLength(Vector3D v)
      {
        double num1 = v.X * this.vector3D_0.X;
        double num2 = v.Y * this.vector3D_0.Y;
        double num3 = v.Z * this.vector3D_0.Z;
        return System.Math.Sqrt(num1 * num1 + num2 * num2 + num3 * num3);
      }

      public void GetLengths(Vector2D v, out double length, out double scaledLength)
      {
        double x = v.X;
        double y = v.Y;
        double num1 = x * x;
        double num2 = y * y;
        length = System.Math.Sqrt(num1 + num2);
        scaledLength = System.Math.Sqrt(num1 * this.vector3D_1.X + num2 * this.vector3D_1.Y);
      }
    }
  }
}
