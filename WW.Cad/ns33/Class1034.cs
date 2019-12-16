// Decompiled with JetBrains decompiler
// Type: ns33.Class1034
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace ns33
{
  internal class Class1034
  {
    private readonly Vector2D vector2D_0;
    private readonly Class521 class521_0;

    public Class1034(Vector2D position, Class521 polylines)
    {
      this.vector2D_0 = position;
      this.class521_0 = polylines;
    }

    internal Vector2D Position
    {
      get
      {
        return this.vector2D_0;
      }
    }

    public Class521 Polylines
    {
      get
      {
        return this.class521_0;
      }
    }
  }
}
