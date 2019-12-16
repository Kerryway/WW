// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.Polyline2D2WN
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class Polyline2D2WN : IPrimitive
  {
    private WW.Cad.Drawing.Polyline2D2WN polyline2D2WN_0;
    private bool bool_0;
    private Matrix4D matrix4D_0;

    public Polyline2D2WN(WW.Cad.Drawing.Polyline2D2WN wrappee, bool fill, Matrix4D transform)
    {
      this.polyline2D2WN_0 = wrappee;
      this.bool_0 = fill;
      this.matrix4D_0 = transform;
    }

    public WW.Cad.Drawing.Polyline2D2WN Wrappee
    {
      get
      {
        return this.polyline2D2WN_0;
      }
      set
      {
        this.polyline2D2WN_0 = value;
      }
    }

    public bool Fill
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

    public Matrix4D Transform
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

    public void Accept(IPrimitiveVisitor visitor)
    {
      visitor.Visit(this);
    }
  }
}
