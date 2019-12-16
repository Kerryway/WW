// Decompiled with JetBrains decompiler
// Type: ns4.Class596
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW.Cad.Model;
using WW.Cad.Model.Entities;

namespace ns4
{
  internal class Class596
  {
    private double double_4 = 1.0;
    private double double_5 = 1.0;
    public const string string_0 = "simplex.shx";
    public const double double_0 = 5.0;
    public const double double_1 = 0.2;
    private readonly DxfModel dxfModel_0;
    private Color color_0;
    private string string_1;
    private string string_2;
    private Interface14 interface14_0;
    private Interface14 interface14_1;
    private bool bool_0;
    private bool bool_1;
    private double double_2;
    private double double_3;
    private bool bool_2;
    private bool bool_3;
    private Enum46 enum46_0;
    private bool bool_4;
    private bool bool_5;

    internal Class596(DxfModel model)
    {
      if (model == null)
        throw new ArgumentNullException();
      this.dxfModel_0 = model;
    }

    internal Class596(Class596 from)
    {
      this.dxfModel_0 = from.dxfModel_0;
      this.color_0 = from.color_0;
      this.string_1 = from.string_1;
      this.string_2 = from.string_2;
      this.interface14_0 = from.Font;
      this.bool_0 = from.bool_0;
      this.bool_1 = from.bool_1;
      this.double_2 = from.double_2;
      this.double_3 = from.double_3;
      this.bool_2 = from.bool_2;
      this.bool_3 = from.bool_3;
      this.enum46_0 = from.enum46_0;
      this.double_4 = from.double_4;
      this.double_5 = from.double_5;
      this.bool_4 = from.bool_4;
      this.bool_5 = from.bool_5;
    }

    internal Color Color
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
      }
    }

    internal string FontFileName
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
        this.interface14_0 = (Interface14) null;
      }
    }

    public string BigFontFilename
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value;
        this.interface14_1 = (Interface14) null;
      }
    }

    internal Interface14 NormalFont
    {
      get
      {
        if (this.interface14_0 == null)
        {
          ShxFile shxFile1 = this.dxfModel_0.GetShxFile(this.FontFileName);
          if (shxFile1 == null)
          {
            Class593 class593 = new Class593(new Class26(this, false));
            if (class593.IsFallback)
            {
              string fallbackShxFont = DxfModel.FallbackShxFont;
              ShxFile shxFile2 = fallbackShxFont == null ? (ShxFile) null : this.dxfModel_0.GetShxFile(fallbackShxFont);
              if (shxFile2 == null)
              {
                string fallbackTrueTypeFont = DxfModel.FallbackTrueTypeFont;
                this.interface14_0 = fallbackTrueTypeFont == null ? (Interface14) class593 : (Interface14) new Class593(new Class26(fallbackTrueTypeFont, this));
              }
              else
                this.interface14_0 = (Interface14) new Class754(new Class27(this, shxFile2), this.bool_5);
            }
            else
              this.interface14_0 = (Interface14) class593;
          }
          else
            this.interface14_0 = (Interface14) new Class754(new Class27(this, shxFile1), this.bool_5);
        }
        return this.interface14_0;
      }
    }

    internal Interface14 BigFont
    {
      get
      {
        if (!string.IsNullOrEmpty(this.string_2) && this.interface14_1 == null)
        {
          ShxFile shxFile = this.dxfModel_0.GetShxFile(this.string_2);
          this.interface14_1 = shxFile != null ? (Interface14) new Class754(new Class27(this, shxFile), this.bool_5) : (Interface14) new Class593(new Class26(this, true));
        }
        return this.interface14_1;
      }
    }

    internal Interface14 Font
    {
      get
      {
        if (!this.bool_4)
          return this.NormalFont;
        return this.BigFont;
      }
    }

    internal bool UseBigFont
    {
      get
      {
        return this.bool_4;
      }
      set
      {
        if (string.IsNullOrEmpty(this.string_2))
          return;
        this.bool_4 = value;
      }
    }

    internal bool Bold
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
        this.interface14_0 = (Interface14) null;
      }
    }

    internal bool Italic
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
        this.interface14_0 = (Interface14) null;
      }
    }

    internal double Height
    {
      get
      {
        return this.double_2;
      }
      set
      {
        this.double_2 = value;
        this.interface14_0 = (Interface14) null;
      }
    }

    internal double ObliqueAngle
    {
      get
      {
        return this.double_3;
      }
      set
      {
        this.double_3 = value;
        this.interface14_0 = (Interface14) null;
      }
    }

    internal bool Overline
    {
      get
      {
        return this.bool_3;
      }
      set
      {
        this.bool_3 = value;
      }
    }

    internal bool Underline
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
      }
    }

    internal Enum46 VerticalAlignment
    {
      get
      {
        return this.enum46_0;
      }
      set
      {
        this.enum46_0 = value;
      }
    }

    internal bool IsVertical
    {
      get
      {
        return this.bool_5;
      }
      set
      {
        this.bool_5 = value;
      }
    }

    internal double LetterDistance
    {
      get
      {
        return this.double_4;
      }
      set
      {
        this.double_4 = value;
        this.interface14_0 = (Interface14) null;
      }
    }

    internal double LetterWidth
    {
      get
      {
        return this.double_5;
      }
      set
      {
        if (value < 0.2 || value > 5.0)
          return;
        this.double_5 = value;
        this.interface14_0 = (Interface14) null;
      }
    }

    internal bool method_0(char ch)
    {
      if (this.BigFont == null)
        return false;
      if (this.BigFont.imethod_0(ch))
        return !this.bool_4;
      if (this.NormalFont.imethod_0(ch))
        return this.bool_4;
      return this.bool_4;
    }
  }
}
