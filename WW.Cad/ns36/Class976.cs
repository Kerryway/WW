// Decompiled with JetBrains decompiler
// Type: ns36.Class976
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace ns36
{
  internal class Class976
  {
    private Point3D point3D_0;
    private Vector3D vector3D_0;
    private Vector3D vector3D_1;

    public Class976()
    {
    }

    public Class976(Bounds2D bounds, Matrix4D transform)
    {
      Vector2D delta = bounds.Delta;
      Point3D point = new Point3D(bounds.Corner1, 0.0);
      this.point3D_0 = transform.Transform(point);
      this.vector3D_0 = transform.Transform(point + new Vector3D(delta.X, 0.0, 0.0)) - this.point3D_0;
      this.vector3D_1 = transform.Transform(point + new Vector3D(0.0, delta.Y, 0.0)) - this.point3D_0;
    }

    public Class976(Point3D origin, Vector3D dx, Vector3D dy)
    {
      this.point3D_0 = origin;
      this.vector3D_0 = dx;
      this.vector3D_1 = dy;
    }

    public Point3D Origin
    {
      get
      {
        return this.point3D_0;
      }
      set
      {
        this.point3D_0 = value;
      }
    }

    public Vector3D Dx
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        this.vector3D_0 = value;
      }
    }

    public Vector3D Dy
    {
      get
      {
        return this.vector3D_1;
      }
      set
      {
        this.vector3D_1 = value;
      }
    }

    public Point3D Center
    {
      get
      {
        return this.point3D_0 + 0.5 * (this.vector3D_0 + this.vector3D_1);
      }
    }

    internal double method_0(Point3D referencePoint, Vector3D direction)
    {
      double num1 = Vector3D.DotProduct(this.point3D_0 - referencePoint, direction);
      double num2 = Vector3D.DotProduct(this.vector3D_0, direction);
      if (num2 > 0.0)
        num1 += num2;
      double num3 = Vector3D.DotProduct(this.vector3D_1, direction);
      if (num3 > 0.0)
        num1 += num3;
      return num1;
    }
  }
}
