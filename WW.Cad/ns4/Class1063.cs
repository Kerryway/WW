// Decompiled with JetBrains decompiler
// Type: ns4.Class1063
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;
using WW.Math.Geometry;

namespace ns4
{
  internal class Class1063
  {
    private IShape2D ishape2D_0;
    private Matrix3D matrix3D_0;

    public Class1063()
    {
    }

    public Class1063(IShape2D shape, Matrix3D transform)
    {
      this.ishape2D_0 = shape;
      this.matrix3D_0 = transform;
    }

    public IShape2D Shape
    {
      get
      {
        return this.ishape2D_0;
      }
      set
      {
        this.ishape2D_0 = value;
      }
    }

    public Matrix3D Transform
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
  }
}
