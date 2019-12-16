// Decompiled with JetBrains decompiler
// Type: ns4.Class25
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math;

namespace ns4
{
  internal abstract class Class25 : Interface0
  {
    public const double double_0 = 1.66666666666667;
    private readonly Matrix2D matrix2D_0;
    private readonly double double_1;
    private readonly double double_2;
    private readonly bool bool_0;

    protected Class25(Class596 settings)
    {
      this.double_2 = settings.Height;
      double m00 = this.double_2 * settings.LetterWidth;
      double m01 = m00 * System.Math.Tan(-settings.ObliqueAngle);
      this.matrix2D_0 = new Matrix2D(m00, m01, 0.0, -this.double_2);
      this.double_1 = settings.LetterDistance;
      this.bool_0 = settings.IsVertical;
    }

    protected Class25(double height)
    {
      this.double_2 = height;
      this.matrix2D_0 = new Matrix2D(this.double_2, 0.0, 0.0, -this.double_2);
      this.double_1 = 1.0;
    }

    protected virtual double SystemFontScaling
    {
      get
      {
        return 1.0;
      }
    }

    public double FontHeight
    {
      get
      {
        return this.double_2;
      }
    }

    public double SystemFontHeight
    {
      get
      {
        return this.FontHeight * this.SystemFontScaling;
      }
    }

    public double Ascent
    {
      get
      {
        return this.double_2 * this.CanonicalAscent;
      }
    }

    public double Descent
    {
      get
      {
        return this.double_2 * this.CanonicalDescent;
      }
    }

    protected abstract double CanonicalAscent { get; }

    protected abstract double CanonicalDescent { get; }

    public Bounds2D GetBounds(string text)
    {
      return this.GetBounds(text, this.matrix2D_0, Enum24.flag_0);
    }

    public Bounds2D GetBounds(string text, Enum24 whiteSpaceHandling)
    {
      return this.GetBounds(text, this.matrix2D_0, whiteSpaceHandling);
    }

    protected abstract Bounds2D GetBounds(string text, Matrix2D transformation, Enum24 wsh);

    public virtual Vector2D imethod_0(string text, IList<Vector2D> characterAdvances)
    {
      Vector2D vector = this.vmethod_0(text, characterAdvances);
      if (characterAdvances != null)
      {
        for (int index = 0; index < characterAdvances.Count; ++index)
          characterAdvances[index] = this.matrix2D_0.Transform(characterAdvances[index]);
      }
      return this.matrix2D_0.Transform(vector);
    }

    public virtual Vector2D LineFeedAdvance
    {
      get
      {
        return new Vector2D(0.0, -5.0 / 3.0 * this.double_2);
      }
    }

    protected abstract Vector2D vmethod_0(string text, IList<Vector2D> characterAdvances);

    public virtual Matrix2D CharTransformation
    {
      get
      {
        return this.matrix2D_0;
      }
    }

    public virtual double CharSpacingFactor
    {
      get
      {
        return this.double_1;
      }
    }

    public bool IsVertical
    {
      get
      {
        return this.bool_0;
      }
    }
  }
}
