// Decompiled with JetBrains decompiler
// Type: ns4.Class27
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model.Entities;
using WW.Math;

namespace ns4
{
  internal class Class27 : Class25
  {
    private readonly ShxFile shxFile_0;
    private readonly double double_3;
    private readonly double double_4;
    private readonly Vector2D vector2D_0;
    private readonly Class754.Class755 class755_0;

    public Class27(Class596 settings, ShxFile shxFile)
      : base(settings)
    {
      this.shxFile_0 = shxFile;
      this.double_3 = 1.0 / (shxFile.Above != 0 ? (double) shxFile.Above : (double) shxFile.Height);
      this.double_4 = (double) shxFile.Below * this.double_3;
      this.vector2D_0 = settings.IsVertical ? new Vector2D(shxFile.HorizontalLinefeedAdvance * this.double_3 * this.Ascent, 0.0) : new Vector2D(0.0, shxFile.VerticalLinefeedAdvance * this.double_3 * this.Ascent);
      if (this.vector2D_0 == Vector2D.Zero)
        this.vector2D_0 = settings.IsVertical ? new Vector2D(5.0 / 3.0 * this.Ascent, 0.0) : new Vector2D(0.0, -5.0 / 3.0 * this.Ascent);
      this.class755_0 = Class754.smethod_0(shxFile, this.double_3);
    }

    public ShxFile ShxFile
    {
      get
      {
        return this.shxFile_0;
      }
    }

    public double ToCanonicalScale
    {
      get
      {
        return this.double_3;
      }
    }

    protected override double CanonicalAscent
    {
      get
      {
        return 1.0;
      }
    }

    protected override double CanonicalDescent
    {
      get
      {
        return this.double_4;
      }
    }

    protected override Bounds2D GetBounds(string text, Matrix2D transformation, Enum24 wsh)
    {
      Bounds2D bounds2D = new Bounds2D();
      Vector2D zero = Vector2D.Zero;
      double num1 = this.CharSpacingFactor * transformation.M00;
      double m11 = transformation.M11;
      if ((wsh & Enum24.flag_1) != Enum24.flag_0)
        bounds2D.Update(zero.X, zero.Y);
      for (int index = 0; index < text.Length; ++index)
      {
        Interface35 glyph = this.class755_0.GetGlyph(text[index], this.IsVertical, '?');
        if (glyph.IsValid)
        {
          Bounds2D bounds = glyph.GetBounds();
          if (bounds.Initialized)
          {
            bounds2D.Update(transformation.Transform(new Point2D(bounds.Corner1.X, bounds.Corner2.Y)) + zero);
            bounds2D.Update(transformation.Transform(new Point2D(bounds.Corner2.X, bounds.Corner1.Y)) + zero);
          }
          Vector2D advance = glyph.Advance;
          double num2 = num1 * advance.X;
          zero.X += num2;
          zero.Y += m11 * advance.Y;
        }
      }
      if ((wsh & Enum24.flag_2) != Enum24.flag_0)
        bounds2D.Update(zero.X, zero.Y);
      return bounds2D;
    }

    protected override Vector2D vmethod_0(string text, IList<Vector2D> characterAdvances)
    {
      Point2D zero = Point2D.Zero;
      for (int index = 0; index < text.Length; ++index)
      {
        Interface35 glyph = this.class755_0.GetGlyph(text[index], this.IsVertical, '?');
        if (glyph.IsValid)
        {
          Vector2D advance = glyph.Advance;
          zero.X += advance.X;
          zero.Y += advance.Y;
        }
        characterAdvances?.Add((Vector2D) zero);
      }
      return new Vector2D(this.CharSpacingFactor * zero.X, zero.Y);
    }

    public override Vector2D LineFeedAdvance
    {
      get
      {
        return this.vector2D_0;
      }
    }
  }
}
