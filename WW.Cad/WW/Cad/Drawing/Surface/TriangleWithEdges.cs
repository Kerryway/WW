// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.TriangleWithEdges
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class TriangleWithEdges : IPrimitive
  {
    private Point3D point3D_0;
    private Point3D point3D_1;
    private Point3D point3D_2;
    private bool bool_0;
    private bool bool_1;
    private bool bool_2;

    public TriangleWithEdges()
    {
    }

    public TriangleWithEdges(
      Point3D v0,
      Point3D v1,
      Point3D v2,
      bool edge0Visible,
      bool edge1Visible,
      bool edge2Visible)
    {
      this.point3D_0 = v0;
      this.point3D_1 = v1;
      this.point3D_2 = v2;
      this.bool_0 = edge0Visible;
      this.bool_1 = edge1Visible;
      this.bool_2 = edge2Visible;
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

    public bool Edge0Visible
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public bool Edge1Visible
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public bool Edge2Visible
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
      }
    }

    public void Accept(IPrimitiveVisitor visitor)
    {
      visitor.Visit(this);
    }
  }
}
