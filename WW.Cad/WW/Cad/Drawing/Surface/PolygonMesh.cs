// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.PolygonMesh
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class PolygonMesh : IPrimitive
  {
    private Point3D[,] point3D_0;
    private bool bool_0;
    private bool bool_1;

    public PolygonMesh(Point3D[,] mesh, bool closedInMDirection, bool closedInNDirection)
    {
      this.point3D_0 = mesh;
      this.bool_0 = closedInMDirection;
      this.bool_1 = closedInNDirection;
    }

    public Point3D[,] Mesh
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

    public bool ClosedInMDirection
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

    public bool ClosedInNDirection
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

    public void Accept(IPrimitiveVisitor visitor)
    {
      visitor.Visit(this);
    }
  }
}
