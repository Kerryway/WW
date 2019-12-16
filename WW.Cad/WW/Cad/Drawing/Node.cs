// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Node
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace WW.Cad.Drawing
{
  public class Node
  {
    private Point3D point3D_0;
    private bool bool_0;

    public Node()
    {
    }

    public Node(Point3D position)
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

    public bool HighLighted
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
  }
}
