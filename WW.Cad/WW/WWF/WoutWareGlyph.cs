// Decompiled with JetBrains decompiler
// Type: WW.WWF.WoutWareGlyph
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;
using WW.Math.Geometry;
using WW.Text;

namespace WW.WWF
{
  public class WoutWareGlyph : ICanonicalGlyph
  {
    private readonly char char_0;
    private readonly IShape2D ishape2D_0;
    private readonly Vector2D vector2D_0;

    public WoutWareGlyph(char letter, IShape2D outline, Vector2D advance)
    {
      this.char_0 = letter;
      this.ishape2D_0 = outline ?? ShapeTool.NullShape;
      this.vector2D_0 = advance;
    }

    public char Letter
    {
      get
      {
        return this.char_0;
      }
    }

    public IShape2D Path
    {
      get
      {
        return this.ishape2D_0;
      }
    }

    public bool Filled
    {
      get
      {
        return true;
      }
    }

    public Vector2D Advance
    {
      get
      {
        return this.vector2D_0;
      }
    }
  }
}
