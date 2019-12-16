// Decompiled with JetBrains decompiler
// Type: WW.WWF.IWoutWareFont
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Text;

namespace WW.WWF
{
  public interface IWoutWareFont
  {
    double Ascent { get; set; }

    double Descent { get; set; }

    ICanonicalGlyph GetGlyph(char letter);

    ICanonicalGlyph GetGlyph(char letter, ICanonicalGlyph fallbackGlyph);
  }
}
