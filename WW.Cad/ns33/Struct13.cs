// Decompiled with JetBrains decompiler
// Type: ns33.Struct13
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math.Geometry;

namespace ns33
{
  internal struct Struct13
  {
    private IShape2D ishape2D_0;
    private double double_0;

    internal Struct13(IShape2D shape, double shapeFlattenEpsilon)
    {
      this.ishape2D_0 = shape;
      this.double_0 = shapeFlattenEpsilon;
    }

    public override int GetHashCode()
    {
      return this.ishape2D_0.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      Struct13 struct13 = (Struct13) obj;
      if (this.ishape2D_0 == struct13.ishape2D_0)
        return this.double_0 == struct13.double_0;
      return false;
    }
  }
}
