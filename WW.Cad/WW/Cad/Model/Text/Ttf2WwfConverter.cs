// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Text.Ttf2WwfConverter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns4;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Media;
using WW.Math;
using WW.Math.Geometry;
using WW.WWF;

namespace WW.Cad.Model.Text
{
  public static class Ttf2WwfConverter
  {
    public static WoutWareFont CreateWWF(
      string fontFileName,
      char startCharacter,
      char endCharacter)
    {
      return Ttf2WwfConverter.CreateWWF(fontFileName, (IEnumerable<char>) new Ttf2WwfConverter.Class645(startCharacter, endCharacter));
    }

    public static WoutWareFont CreateWWF(
      string fontFileName,
      IEnumerable<char> characters)
    {
      ns4.Class26 textMetrics = new ns4.Class26(fontFileName, false, false);
      if (textMetrics.IsFallback)
        throw new Exception("Font with filename " + fontFileName + " could not be found or read, a fall back font was used, and therefore the font conversion is aborted.");
      Class593 class593 = new Class593(textMetrics);
      ICollection<Typeface> typefaces = new FontFamily(class593.SystemFont.FontFamily.Name).GetTypefaces();
      WoutWareFont woutWareFont = new WoutWareFont();
      woutWareFont.Ascent = textMetrics.Ascent;
      woutWareFont.Descent = textMetrics.Descent;
      Matrix2D transformation = new Matrix2D(1.0, 0.0, 0.0, -1.0);
      foreach (char character in characters)
      {
        bool flag = false;
        int uint16 = (int) Convert.ToUInt16(character);
        foreach (Typeface typeface in (IEnumerable<Typeface>) typefaces)
        {
          GlyphTypeface glyphTypeface;
          ushort num;
          if (typeface.TryGetGlyphTypeface(out glyphTypeface) && glyphTypeface != null && glyphTypeface.CharacterToGlyphMap.TryGetValue(uint16, out num))
          {
            flag = true;
            break;
          }
        }
        if (flag)
        {
          Interface34 text = class593.GetText(character.ToString(), WW.Cad.Model.Colors.White, (short) 0, false);
          if (text.Advance != Vector2D.Zero)
          {
            IShape2D outline = (IShape2D) new GeneralShape2D(text.TransformedPath, transformation, true);
            WoutWareGlyph glyph = new WoutWareGlyph(character, outline, text.CanonicalAdvance);
            woutWareFont.AddGlyph(glyph);
          }
        }
      }
      return woutWareFont;
    }

    public static WoutWareFont CreateWWF(string fontFileName, char endCharacter)
    {
      return Ttf2WwfConverter.CreateWWF(fontFileName, (IEnumerable<char>) new Ttf2WwfConverter.Class645(char.MinValue, endCharacter));
    }

    public static WoutWareFont CreateWWF(string fontFileName)
    {
      return Ttf2WwfConverter.CreateWWF(fontFileName, (IEnumerable<char>) new Ttf2WwfConverter.Class645(char.MinValue, char.MaxValue));
    }

    private class Class645 : IEnumerable, IEnumerable<char>
    {
      private readonly char char_0;
      private readonly char char_1;

      public Class645(char start, char end)
      {
        this.char_0 = start;
        this.char_1 = end;
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
        return (IEnumerator) this.GetEnumerator();
      }

      public IEnumerator<char> GetEnumerator()
      {
        return (IEnumerator<char>) new Ttf2WwfConverter.Class645.Class646(this);
      }

      private class Class646 : IDisposable, IEnumerator, IEnumerator<char>
      {
        private readonly Ttf2WwfConverter.Class645 class645_0;
        private int int_0;

        public Class646(Ttf2WwfConverter.Class645 range)
        {
          this.class645_0 = range;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
          ++this.int_0;
          return this.int_0 <= (int) this.class645_0.char_1;
        }

        public void Reset()
        {
          this.int_0 = (int) this.class645_0.char_0 - 1;
        }

        object IEnumerator.Current
        {
          get
          {
            return (object) this.Current;
          }
        }

        public char Current
        {
          get
          {
            if (this.int_0 < (int) this.class645_0.char_0 || this.int_0 > (int) this.class645_0.char_1)
              throw new InvalidOperationException("Enumeration out of bounds!");
            return (char) this.int_0;
          }
        }
      }
    }
  }
}
