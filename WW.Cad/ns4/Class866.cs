// Decompiled with JetBrains decompiler
// Type: ns4.Class866
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Globalization;
using WW.Cad.Model;
using WW.Math;
using WW.Math.Geometry;
using WW.Text;

namespace ns4
{
  internal class Class866 : ICanonicalGlyph, Interface35
  {
    private char char_0;
    private IShape2D ishape2D_0;
    private bool bool_0;
    private readonly Vector2D vector2D_0;
    private Bounds2D bounds2D_0;

    public Class866(char letter, IShape2D path, Vector2D advance, bool filled)
    {
      this.vector2D_0 = advance;
      this.char_0 = letter;
      this.ishape2D_0 = path ?? ShapeTool.NullShape;
      this.bool_0 = filled;
    }

    public Class866(char letter)
    {
      this.char_0 = letter;
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
        return this.bool_0;
      }
    }

    public bool IsValid
    {
      get
      {
        return this.ishape2D_0 != null;
      }
    }

    public void Draw(
      IPathDrawer drawer,
      Matrix4D trafo,
      Color color,
      short lineWeight,
      double extent)
    {
      drawer.DrawPath(this.ishape2D_0, trafo, color, lineWeight, this.bool_0, true, extent);
    }

    public Vector2D Advance
    {
      get
      {
        return this.vector2D_0;
      }
    }

    public Bounds2D GetBounds()
    {
      if (this.bounds2D_0 == null)
      {
        lock (this)
        {
          if (this.bounds2D_0 == null)
          {
            this.bounds2D_0 = new Bounds2D();
            this.ishape2D_0.AddToBounds(this.bounds2D_0);
          }
        }
      }
      return this.bounds2D_0;
    }

    public override string ToString()
    {
      return this.char_0.ToString((IFormatProvider) CultureInfo.InvariantCulture);
    }
  }
}
