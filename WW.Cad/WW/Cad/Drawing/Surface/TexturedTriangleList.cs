// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.TexturedTriangleList
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing.Surface
{
  public class TexturedTriangleList : IPrimitive
  {
    private byte[] byte_0;
    private int int_0;
    private int int_1;
    private Vector3D vector3D_0;
    private IList<Triangulator2D.Triangle> ilist_0;
    private IList<Point2D> ilist_1;
    private IList<Point3D> ilist_2;

    public byte[] RgbaBytes
    {
      get
      {
        return this.byte_0;
      }
      set
      {
        this.byte_0 = value;
      }
    }

    public int Width
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public int Height
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    public Vector3D Normal
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

    public IList<Triangulator2D.Triangle> Triangles
    {
      get
      {
        return this.ilist_0;
      }
      set
      {
        this.ilist_0 = value;
      }
    }

    public IList<Point2D> TextureCoordinates
    {
      get
      {
        return this.ilist_1;
      }
      set
      {
        this.ilist_1 = value;
      }
    }

    public IList<Point3D> Points
    {
      get
      {
        return this.ilist_2;
      }
      set
      {
        this.ilist_2 = value;
      }
    }

    public void Accept(IPrimitiveVisitor visitor)
    {
      visitor.Visit(this);
    }
  }
}
