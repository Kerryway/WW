// Decompiled with JetBrains decompiler
// Type: ns4.Class26
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns33;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Math;
using WW.Math.Geometry;

namespace ns4
{
  internal class Class26 : Class25
  {
    private static readonly Dictionary<string, Class26.Class1060> dictionary_0 = new Dictionary<string, Class26.Class1060>();
    public const double double_3 = 1.25;
    internal const float float_0 = 144f;
    private readonly Class26.Class1060 class1060_0;

    private static Class26.Class1060 smethod_0(string fontFileName, bool bold, bool italic)
    {
      string key = fontFileName + (object) char.MinValue + (object) bold + (object) char.MinValue + (object) italic;
      Class26.Class1060 class1060;
      lock (Class26.dictionary_0)
      {
        if (!Class26.dictionary_0.TryGetValue(key, out class1060))
        {
          class1060 = new Class26.Class1060(fontFileName, bold, italic);
          if (!Class26.dictionary_0.ContainsKey(key))
            Class26.dictionary_0.Add(key, class1060);
        }
      }
      return class1060;
    }

    public Class26(Class596 settings, bool useBigfont)
      : base(settings)
    {
      this.class1060_0 = Class26.smethod_0(useBigfont ? settings.BigFontFilename : settings.FontFileName, settings.Bold, settings.Italic);
    }

    internal Class26(string fontFileName, bool bold, bool italic)
      : base(1.0)
    {
      this.class1060_0 = Class26.smethod_0(fontFileName, bold, italic);
    }

    internal Class26(string fontFileName, Class596 settings)
      : base(settings)
    {
      this.class1060_0 = Class26.smethod_0(fontFileName, settings.Bold, settings.Italic);
    }

    public Font Font
    {
      get
      {
        return this.class1060_0.Font;
      }
    }

    public double CanonicalScaling
    {
      get
      {
        return this.class1060_0.CanonicalScaling;
      }
    }

    public PointF BaseLineOffset
    {
      get
      {
        return this.class1060_0.BaseLineOffset;
      }
    }

    public bool method_0(char ch)
    {
      return true;
    }

    protected override double SystemFontScaling
    {
      get
      {
        return this.class1060_0.SystemFontScaling;
      }
    }

    protected override double CanonicalAscent
    {
      get
      {
        return this.class1060_0.Ascent;
      }
    }

    protected override double CanonicalDescent
    {
      get
      {
        return this.class1060_0.Descent;
      }
    }

    protected override Bounds2D GetBounds(string text, Matrix2D transformation, Enum24 wsh)
    {
      Bounds2D bounds2D = new Bounds2D();
      using (GraphicsPath graphicsPath = this.method_1(text))
      {
        if (graphicsPath.PointCount > 1)
        {
          RectangleF bounds = graphicsPath.GetBounds((transformation * Transformation2D.Scaling(this.CanonicalScaling)).ToMatrix());
          bounds2D.Update(new Point2D((double) bounds.Left, (double) bounds.Bottom));
          bounds2D.Update(new Point2D((double) bounds.Right, (double) bounds.Top));
        }
      }
      if (text.Length > 0)
      {
        if ((wsh & Enum24.flag_1) != Enum24.flag_0 && char.IsWhiteSpace(text[0]))
          bounds2D.Update(0.0, 0.0);
        if ((wsh & Enum24.flag_2) != Enum24.flag_0 && char.IsWhiteSpace(text[text.Length - 1]))
        {
          Vector2D vector2D = this.imethod_0(text, (IList<Vector2D>) null);
          bounds2D.Update(vector2D.X, vector2D.Y);
        }
      }
      return bounds2D;
    }

    public GraphicsPath method_1(string text)
    {
      GraphicsPath graphicsPath = new GraphicsPath();
      StringFormat format = new StringFormat(StringFormat.GenericTypographic);
      format.FormatFlags |= StringFormatFlags.NoWrap;
      if (this.CharSpacingFactor == 1.0)
      {
        graphicsPath.AddString(text, this.Font.FontFamily, (int) this.Font.Style, 144f, this.class1060_0.BaseLineOffset, format);
      }
      else
      {
        double charSpacingFactor = this.CharSpacingFactor;
        format.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
        PointF baseLineOffset = this.class1060_0.BaseLineOffset;
        foreach (char ch in text)
        {
          string str = ch.ToString();
          graphicsPath.AddString(str, this.Font.FontFamily, (int) this.Font.Style, 144f, baseLineOffset, format);
          Vector2D vector2D = this.method_3(str, (IList<Vector2D>) null);
          double num = vector2D.X * charSpacingFactor;
          baseLineOffset.X += (float) num;
          baseLineOffset.Y += (float) vector2D.Y;
        }
      }
      format.Dispose();
      return graphicsPath;
    }

    public Class866 method_2(char c)
    {
      return this.class1060_0.method_0(c);
    }

    private Vector2D method_3(string text, IList<Vector2D> characterAdvances)
    {
      if (string.IsNullOrEmpty(text))
        return Vector2D.Zero;
      Vector2D vector2D = Vector2D.Zero;
      Graphics measureGraphics = Class940.MeasureGraphics;
      if (characterAdvances != null)
      {
        CharacterRange[] ranges = new CharacterRange[text.Length];
        for (int First = 0; First < text.Length; ++First)
          ranges[First] = new CharacterRange(First, 1);
        StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
        stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoWrap;
        stringFormat.SetMeasurableCharacterRanges(ranges);
        System.Drawing.Region[] regionArray = measureGraphics.MeasureCharacterRanges(text, this.class1060_0.Font, (RectangleF) Rectangle.Empty, stringFormat);
        if (regionArray.Length > 0)
        {
          for (int index = 0; index < regionArray.Length; ++index)
          {
            System.Drawing.Region region = regionArray[index];
            RectangleF bounds = region.GetBounds(measureGraphics);
            region.Dispose();
            vector2D = new Vector2D((double) bounds.Right, 0.0);
            characterAdvances.Add(vector2D);
          }
        }
        stringFormat.Dispose();
      }
      else
      {
        CharacterRange[] ranges = new CharacterRange[1]{ new CharacterRange(0, text.Length) };
        StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
        stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoWrap;
        stringFormat.SetMeasurableCharacterRanges(ranges);
        System.Drawing.Region[] regionArray = measureGraphics.MeasureCharacterRanges(text, this.class1060_0.Font, (RectangleF) Rectangle.Empty, stringFormat);
        if (regionArray.Length > 0)
        {
          System.Drawing.Region region = regionArray[regionArray.Length - 1];
          RectangleF bounds = region.GetBounds(measureGraphics);
          region.Dispose();
          vector2D = new Vector2D((double) bounds.Right, 0.0);
        }
        stringFormat.Dispose();
      }
      return vector2D;
    }

    protected override Vector2D vmethod_0(string text, IList<Vector2D> characterAdvances)
    {
      if (string.IsNullOrEmpty(text))
        return Vector2D.Zero;
      Vector2D vector2D = this.class1060_0.CanonicalScaling * this.method_3(text, characterAdvances);
      if (characterAdvances != null)
      {
        for (int index = 0; index < characterAdvances.Count; ++index)
          characterAdvances[index] = this.class1060_0.CanonicalScaling * characterAdvances[index];
      }
      return vector2D;
    }

    public bool IsFallback
    {
      get
      {
        return this.class1060_0.IsFallback;
      }
    }

    private class Class1060
    {
      private readonly Dictionary<char, Class866> dictionary_0 = new Dictionary<char, Class866>();
      private readonly Font font_0;
      private readonly double double_0;
      private readonly double double_1;
      private readonly double double_2;
      private readonly PointF pointF_0;
      private readonly bool bool_0;

      public Class1060(string fontFileName, bool bold, bool italic)
      {
        FontFamily fontFamily;
        FontStyle fontStyle;
        this.bool_0 = !Class594.smethod_1(fontFileName, bold, italic, out fontFamily, out fontStyle);
        if (bold)
          fontStyle |= FontStyle.Bold;
        if (italic)
          fontStyle |= FontStyle.Italic;
        this.font_0 = new Font(fontFamily, 144f, fontStyle, GraphicsUnit.World);
        using (GraphicsPath graphicsPath = new GraphicsPath())
        {
          using (StringFormat format = new StringFormat(StringFormat.GenericTypographic))
          {
            format.FormatFlags |= StringFormatFlags.NoWrap;
            graphicsPath.AddString("M", this.Font.FontFamily, (int) this.Font.Style, 144f, new PointF(0.0f, 0.0f), format);
          }
          if (graphicsPath.PointCount > 1)
          {
            RectangleF bounds = graphicsPath.GetBounds();
            double num = 1.0 / (double) bounds.Height;
            double cellAscent = (double) fontFamily.GetCellAscent(fontStyle);
            double cellDescent = (double) fontFamily.GetCellDescent(fontStyle);
            double lineSpacing = (double) fontFamily.GetLineSpacing(fontStyle);
            this.double_1 = 1.0;
            this.double_2 = cellDescent / cellAscent;
            this.pointF_0 = new PointF(0.0f, -bounds.Bottom);
            this.double_0 = num;
          }
          else
          {
            double emHeight = (double) fontFamily.GetEmHeight(fontStyle);
            double cellAscent = (double) fontFamily.GetCellAscent(fontStyle);
            double cellDescent = (double) fontFamily.GetCellDescent(fontStyle);
            double num = 144.0 * emHeight / cellAscent * 1.25 / emHeight;
            this.double_1 = 1.0;
            this.double_2 = cellDescent / cellAscent;
            this.pointF_0 = new PointF(0.0f, (float) (-cellAscent * num / 1.25));
            this.double_0 = 5.0 / 576.0;
          }
        }
      }

      public Font Font
      {
        get
        {
          return this.font_0;
        }
      }

      public double Ascent
      {
        get
        {
          return this.double_1;
        }
      }

      public double Descent
      {
        get
        {
          return this.double_2;
        }
      }

      public PointF BaseLineOffset
      {
        get
        {
          return this.pointF_0;
        }
      }

      public bool IsFallback
      {
        get
        {
          return this.bool_0;
        }
      }

      public double CanonicalScaling
      {
        get
        {
          return this.double_0;
        }
      }

      public double SystemFontScaling
      {
        get
        {
          return 144.0 * this.double_0;
        }
      }

      public Class866 method_0(char c)
      {
        Class866 class866;
        lock (this.dictionary_0)
        {
          if (!this.dictionary_0.TryGetValue(c, out class866))
          {
            using (GraphicsPath path1 = new GraphicsPath())
            {
              StringFormat format = new StringFormat(StringFormat.GenericTypographic);
              format.FormatFlags |= StringFormatFlags.NoWrap;
              format.FormatFlags &= ~StringFormatFlags.NoFontFallback;
              path1.AddString(c.ToString(), this.Font.FontFamily, (int) this.Font.Style, 144f, this.pointF_0, format);
              IShape2D wrappedShape = (IShape2D) GeneralShape2D.Create(path1, Transformation2D.Scaling(this.double_0));
              IShape2D path2 = wrappedShape.HasSegments ? (IShape2D) new CachedBoundsShape2D(wrappedShape) : (IShape2D) NullShape2D.Instance;
              class866 = new Class866(c, path2, Vector2D.Zero, true);
              format.Dispose();
            }
            this.dictionary_0.Add(c, class866);
          }
        }
        return class866;
      }
    }
  }
}
