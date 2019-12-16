// Decompiled with JetBrains decompiler
// Type: ns4.Class597
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;
using WW.Math;
using WW.Math.Geometry;
using WW.Text;

namespace ns4
{
  internal class Class597 : ICanonicalGlyph, Interface35
  {
    private static readonly Vector2D vector2D_0 = new Vector2D(0.0, -1.0);
    private readonly Interface35 interface35_0;

    public Class597(Interface35 wrappedGlyph)
    {
      this.interface35_0 = wrappedGlyph;
    }

    public char Letter
    {
      get
      {
        return this.interface35_0.Letter;
      }
    }

    public IShape2D Path
    {
      get
      {
        return this.interface35_0.Path;
      }
    }

    public bool Filled
    {
      get
      {
        return this.interface35_0.Filled;
      }
    }

    public Vector2D Advance
    {
      get
      {
        return Class597.vector2D_0;
      }
    }

    public bool IsValid
    {
      get
      {
        return this.interface35_0.IsValid;
      }
    }

    public void Draw(
      IPathDrawer drawer,
      Matrix4D trafo,
      Color color,
      short lineWeight,
      double extent)
    {
      this.interface35_0.Draw(drawer, trafo, color, lineWeight, extent);
    }

    public Bounds2D GetBounds()
    {
      return this.interface35_0.GetBounds();
    }
  }
}
