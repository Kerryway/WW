// Decompiled with JetBrains decompiler
// Type: ns4.Class754
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using WW.Cad.Model.Entities;
using WW.Math;
using WW.Math.Geometry;
using WW.Text;

namespace ns4
{
  internal class Class754 : Interface14
  {
    private static readonly Dictionary<string, Class754.Class755> dictionary_0 = new Dictionary<string, Class754.Class755>();
    private readonly Class27 class27_0;
    private readonly Class754.Class755 class755_0;

    internal static Class754.Class755 smethod_0(ShxFile file, double scale)
    {
      Class754.Class755 class755;
      lock (Class754.dictionary_0)
      {
        if (!Class754.dictionary_0.TryGetValue(file.FileName, out class755))
        {
          class755 = new Class754.Class755(file, scale);
          Class754.dictionary_0.Add(file.FileName, class755);
        }
      }
      return class755;
    }

    public Class754(Class27 textMetrics, bool vertical)
    {
      this.class27_0 = textMetrics;
      this.class755_0 = Class754.smethod_0(textMetrics.ShxFile, textMetrics.ToCanonicalScale);
    }

    internal ShxFile ShxFile
    {
      get
      {
        return this.class755_0.ShxFile;
      }
    }

    public Interface34 GetText(
      string text,
      WW.Cad.Model.Color color,
      short lineWeight,
      bool vertical)
    {
      Interface35[] glyphs = new Interface35[text.Length];
      int length = 0;
      foreach (char c in text)
      {
        Interface35 glyph = this.class755_0.GetGlyph(c, vertical, '?');
        if (glyph.IsValid)
          glyphs[length++] = glyph;
      }
      if (length < glyphs.Length)
      {
        Interface35[] nterface35Array = new Interface35[length];
        Array.Copy((Array) glyphs, (Array) nterface35Array, length);
        glyphs = nterface35Array;
      }
      return (Interface34) new Class472(text, (Interface14) this, color, lineWeight, glyphs, this.class27_0.CharTransformation, this.class27_0.CharSpacingFactor);
    }

    public bool Filled
    {
      get
      {
        return false;
      }
    }

    public Interface0 Metrics
    {
      get
      {
        return (Interface0) this.class27_0;
      }
    }

    public Font SystemFont
    {
      get
      {
        return (Font) null;
      }
    }

    public bool imethod_0(char ch)
    {
      return this.class755_0.method_0(ch);
    }

    public ICanonicalGlyph imethod_1(char c, bool vertical)
    {
      return (ICanonicalGlyph) this.class755_0.GetGlyph(c, vertical, '?');
    }

    internal class Class755
    {
      private readonly ShxFile shxFile_0;
      private readonly Dictionary<int, Interface35> dictionary_0;
      private readonly Matrix2D matrix2D_0;

      public Class755(ShxFile shxFile, double scale)
      {
        this.shxFile_0 = shxFile;
        this.dictionary_0 = new Dictionary<int, Interface35>();
        this.matrix2D_0 = new Matrix2D(scale, 0.0, 0.0, -scale);
      }

      internal ShxFile ShxFile
      {
        get
        {
          return this.shxFile_0;
        }
      }

      internal bool method_0(char c)
      {
        return this.shxFile_0.GetShape(c) != null;
      }

      internal Interface35 GetGlyph(char c, bool vertical, char fallback)
      {
        int key = vertical ? (int) -c : (int) c;
        lock (this.dictionary_0)
        {
          Interface35 nterface35;
          this.dictionary_0.TryGetValue(key, out nterface35);
          if (nterface35 == null)
          {
            ShxShape shxShape = this.shxFile_0.GetShape(c) ?? this.shxFile_0.GetShape(fallback);
            if (shxShape == null)
            {
              nterface35 = (Interface35) new Class866(c);
            }
            else
            {
              WW.Math.Point2D endPoint;
              GeneralShape2D generalShape2D = new GeneralShape2D(shxShape.GetGlyphShape(vertical, out endPoint), this.matrix2D_0, true);
              double m00 = this.matrix2D_0.M00;
              endPoint.X *= m00;
              endPoint.Y *= -m00;
              nterface35 = (Interface35) new Class866(c, (IShape2D) generalShape2D, new Vector2D(endPoint.X, endPoint.Y), false);
            }
            this.dictionary_0.Add(key, nterface35);
          }
          return nterface35;
        }
      }
    }
  }
}
