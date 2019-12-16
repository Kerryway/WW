// Decompiled with JetBrains decompiler
// Type: ns33.Class803
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW;
using WW.Cad.Drawing;
using WW.Math;

namespace ns33
{
  internal class Class803 : ICloneable, Interface41
  {
    private Matrix4D matrix4D_0;
    private Matrix3D matrix3D_0;
    private ILineTypeScaler ilineTypeScaler_0;

    public Class803(Matrix4D transform, Matrix3D matrix3D, ILineTypeScaler lineTypeScaler)
    {
      this.matrix4D_0 = transform;
      this.matrix3D_0 = matrix3D;
      this.ilineTypeScaler_0 = lineTypeScaler;
    }

    public Class803(Matrix4D transform, Matrix3D matrix3D)
    {
      this.matrix4D_0 = transform;
      this.matrix3D_0 = matrix3D;
      this.ilineTypeScaler_0 = Class624.Create(matrix3D);
    }

    public Class803(Matrix4D transform)
      : this(transform, new Matrix3D(transform.M00, transform.M01, transform.M02, transform.M10, transform.M11, transform.M12, transform.M20, transform.M21, transform.M22))
    {
    }

    public Matrix4D Matrix
    {
      get
      {
        return this.matrix4D_0;
      }
      set
      {
        this.matrix4D_0 = value;
      }
    }

    public Matrix3D Matrix3D
    {
      get
      {
        return this.matrix3D_0;
      }
      set
      {
        this.matrix3D_0 = value;
      }
    }

    public ILineTypeScaler LineTypeScaler
    {
      get
      {
        return this.ilineTypeScaler_0;
      }
    }

    public Vector4D Transform(Point2D p)
    {
      return this.matrix4D_0.TransformTo4D(p);
    }

    public Point3D imethod_0(Point2D p)
    {
      return this.matrix4D_0.TransformTo3D(p);
    }

    public Vector4D Transform(Point3D p)
    {
      return this.matrix4D_0.TransformTo4D(p);
    }

    public Point3D imethod_1(Point3D p)
    {
      return this.matrix4D_0.Transform(p);
    }

    public Vector3D Transform(Vector3D v)
    {
      return this.matrix4D_0.Transform(v);
    }

    public void SetPreTransform(Matrix4D preTransform)
    {
      this.matrix4D_0 *= preTransform;
      this.matrix3D_0 *= new Matrix3D(preTransform.M00, preTransform.M01, preTransform.M02, preTransform.M10, preTransform.M11, preTransform.M12, preTransform.M20, preTransform.M21, preTransform.M22);
      this.ilineTypeScaler_0 = Class624.Create(this.matrix3D_0);
    }

    public object Clone()
    {
      return (object) new Class803(this.matrix4D_0, this.matrix3D_0, this.ilineTypeScaler_0);
    }
  }
}
