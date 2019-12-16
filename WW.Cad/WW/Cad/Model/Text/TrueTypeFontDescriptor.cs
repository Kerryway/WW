// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Text.TrueTypeFontDescriptor
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Text
{
  public class TrueTypeFontDescriptor : ICloneable
  {
    private string string_0 = string.Empty;
    private string string_1 = string.Empty;
    private TrueTypeFontFlags trueTypeFontFlags_0;

    public string FontFilename
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value ?? string.Empty;
      }
    }

    public string TypeFace
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public TrueTypeFontFlags Flags
    {
      get
      {
        return this.trueTypeFontFlags_0;
      }
      set
      {
        this.trueTypeFontFlags_0 = value;
      }
    }

    public bool IsBold
    {
      get
      {
        return (this.trueTypeFontFlags_0 & TrueTypeFontFlags.Bold) != TrueTypeFontFlags.None;
      }
      set
      {
        if (value)
          this.trueTypeFontFlags_0 |= TrueTypeFontFlags.Bold;
        else
          this.trueTypeFontFlags_0 &= ~TrueTypeFontFlags.Bold;
      }
    }

    public bool IsItalic
    {
      get
      {
        return (this.trueTypeFontFlags_0 & TrueTypeFontFlags.Italic) != TrueTypeFontFlags.None;
      }
      set
      {
        if (value)
          this.trueTypeFontFlags_0 |= TrueTypeFontFlags.Italic;
        else
          this.trueTypeFontFlags_0 &= ~TrueTypeFontFlags.Italic;
      }
    }

    public byte CharSet
    {
      get
      {
        return (byte) ((uint) (this.trueTypeFontFlags_0 & TrueTypeFontFlags.CharacterSetBitMask) >> 8);
      }
      set
      {
        this.trueTypeFontFlags_0 &= ~TrueTypeFontFlags.CharacterSetBitMask;
        this.trueTypeFontFlags_0 |= (TrueTypeFontFlags) ((int) value << 8);
      }
    }

    public byte PitchAndFamily
    {
      get
      {
        return (byte) (this.trueTypeFontFlags_0 & (TrueTypeFontFlags) 255);
      }
      set
      {
        this.trueTypeFontFlags_0 &= ~TrueTypeFontFlags.PitchAndFamilyBitMask;
        this.trueTypeFontFlags_0 |= (TrueTypeFontFlags) value;
      }
    }

    public object Clone()
    {
      TrueTypeFontDescriptor typeFontDescriptor = new TrueTypeFontDescriptor();
      typeFontDescriptor.CopyFrom(this);
      return (object) typeFontDescriptor;
    }

    public void CopyFrom(TrueTypeFontDescriptor from)
    {
      this.string_0 = from.string_0;
      this.trueTypeFontFlags_0 = from.trueTypeFontFlags_0;
    }
  }
}
