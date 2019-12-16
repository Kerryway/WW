// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.Point
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class Point : IPrimitive
  {
    private Point3D point3D_0;

    public Point()
    {
    }

    public Point(Point3D position)
    {
      this.point3D_0 = position;
    }

    public Point3D Position
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

    public void Accept(IPrimitiveVisitor visitor)
    {
      visitor.Visit(this);
    }
  }
}
