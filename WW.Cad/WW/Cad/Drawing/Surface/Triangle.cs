// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.Triangle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class Triangle : IPrimitive
  {
    private Point3D point3D_0;
    private Point3D point3D_1;
    private Point3D point3D_2;

    public Triangle()
    {
    }

    public Triangle(Point3D v0, Point3D v1, Point3D v2)
    {
      this.point3D_0 = v0;
      this.point3D_1 = v1;
      this.point3D_2 = v2;
    }

    public Point3D V0
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

    public Point3D V1
    {
      get
      {
        return this.point3D_1;
      }
      set
      {
        this.point3D_1 = value;
      }
    }

    public Point3D V2
    {
      get
      {
        return this.point3D_2;
      }
      set
      {
        this.point3D_2 = value;
      }
    }

    public void Accept(IPrimitiveVisitor visitor)
    {
      visitor.Visit(this);
    }
  }
}
