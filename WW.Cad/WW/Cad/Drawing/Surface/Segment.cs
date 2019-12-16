// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.Segment
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class Segment : IPrimitive
  {
    private Point3D point3D_0;
    private Point3D point3D_1;

    public Segment()
    {
    }

    public Segment(Point3D start, Point3D end)
    {
      this.point3D_0 = start;
      this.point3D_1 = end;
    }

    public Point3D Start
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

    public Point3D End
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

    public void Accept(IPrimitiveVisitor visitor)
    {
      visitor.Visit(this);
    }
  }
}
