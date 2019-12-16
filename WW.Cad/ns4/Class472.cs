// Decompiled with JetBrains decompiler
// Type: ns4.Class472
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;
using WW.Math;
using WW.Math.Geometry;
using WW.Text;

namespace ns4
{
  internal class Class472 : Interface34
  {
    private readonly string string_0;
    private readonly Interface14 interface14_0;
    private readonly Color color_0;
    private readonly short short_0;
    private readonly GeneralShape2D generalShape2D_0;
    private readonly Interface35[] interface35_0;
    private readonly double double_0;
    private readonly Vector2D vector2D_0;
    private readonly Matrix2D matrix2D_0;

    public Class472(
      string text,
      Interface14 font,
      Color color,
      short lineWeight,
      Interface35[] glyphs,
      Matrix2D basicTrafo,
      double charSpacingFactor)
    {
      this.string_0 = text;
      this.interface14_0 = font;
      this.color_0 = color;
      this.short_0 = lineWeight;
      this.interface35_0 = glyphs;
      this.double_0 = charSpacingFactor;
      this.matrix2D_0 = basicTrafo;
      foreach (ICanonicalGlyph glyph in glyphs)
        this.vector2D_0 += glyph.Advance;
      if (charSpacingFactor != 1.0)
        this.vector2D_0.X *= charSpacingFactor;
      this.generalShape2D_0 = new GeneralShape2D();
      Vector2D zero = Vector2D.Zero;
      foreach (Interface35 glyph in glyphs)
      {
        this.generalShape2D_0.Append(glyph.Path, false, Transformation3D.Translation(zero.X, zero.Y));
        zero += glyph.Advance * charSpacingFactor;
      }
    }

    public string Text
    {
      get
      {
        return this.string_0;
      }
    }

    public Interface14 Font
    {
      get
      {
        return this.interface14_0;
      }
    }

    public Color Color
    {
      get
      {
        return this.color_0;
      }
    }

    public short LineWeight
    {
      get
      {
        return this.short_0;
      }
    }

    public Vector3D Draw(IPathDrawer drawer, Matrix4D transformation, double extrusion)
    {
      Matrix4D matrix4D = Matrix4D.Multiply(transformation, this.matrix2D_0);
      Vector2D zero = Vector2D.Zero;
      Matrix4D transform = matrix4D;
      foreach (Interface35 nterface35 in this.interface35_0)
      {
        drawer.DrawPath(nterface35.Path, transform, this.color_0, this.short_0, this.Filled, true, extrusion);
        zero += nterface35.Advance;
        transform = matrix4D * Transformation4D.Translation(new Vector3D(zero.X * this.double_0, zero.Y, 0.0));
      }
      return (Vector3D) transform.TransformTo3D((WW.Math.Point2D) this.vector2D_0);
    }

    public IShape2D CanonicalPath
    {
      get
      {
        return (IShape2D) this.generalShape2D_0;
      }
    }

    public IShape2D TransformedPath
    {
      get
      {
        return (IShape2D) new GeneralShape2D((IShape2D) this.generalShape2D_0, this.matrix2D_0, true);
      }
    }

    public Matrix2D BasicTransformation
    {
      get
      {
        return this.matrix2D_0;
      }
    }

    public bool Filled
    {
      get
      {
        return this.interface14_0.Filled;
      }
    }

    public Vector2D CanonicalAdvance
    {
      get
      {
        return this.vector2D_0;
      }
    }

    public Vector2D Advance
    {
      get
      {
        return this.matrix2D_0.Transform(this.vector2D_0);
      }
    }

    public override string ToString()
    {
      return this.string_0;
    }
  }
}
