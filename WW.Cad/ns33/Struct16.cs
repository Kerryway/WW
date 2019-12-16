// Decompiled with JetBrains decompiler
// Type: ns33.Struct16
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace ns33
{
  internal struct Struct16
  {
    private Vector2D vector2D_0;
    private Class454 class454_0;

    internal Struct16(Vector2D position, Class454 charTriangulation)
    {
      this.vector2D_0 = position;
      this.class454_0 = charTriangulation;
    }

    internal Vector2D Position
    {
      get
      {
        return this.vector2D_0;
      }
    }

    internal Class454 CharTriangulation
    {
      get
      {
        return this.class454_0;
      }
    }
  }
}
