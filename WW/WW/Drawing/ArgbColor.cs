// Decompiled with JetBrains decompiler
// Type: WW.Drawing.ArgbColor
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.ComponentModel;
using System.Drawing;

namespace WW.Drawing
{
  [TypeConverter(typeof (ArgbColorTypeConverter))]
  public struct ArgbColor : IEquatable<ArgbColor>
  {
    public static readonly ArgbColor Empty = new ArgbColor(0);
    private const float float_0 = 0.3f;
    private const float float_1 = 0.53f;
    private const float float_2 = 0.17f;
    public const int AlphaShift = 24;
    public const int RedShift = 16;
    public const int GreenShift = 8;
    public const int BlueShift = 0;
    public const uint ComponentMask = 255;
    public const uint AlphaMask = 4278190080;
    public const uint RedMask = 16711680;
    public const uint GreenMask = 65280;
    public const uint BlueMask = 255;
    public const uint RgbMask = 16777215;
    private uint uint_0;

    public ArgbColor(int a, int r, int g, int b)
    {
      this.uint_0 = (uint) ((a & (int) byte.MaxValue) << 24 | (r & (int) byte.MaxValue) << 16 | (g & (int) byte.MaxValue) << 8 | b & (int) byte.MaxValue);
    }

    public ArgbColor(int r, int g, int b)
    {
      this = new ArgbColor((int) byte.MaxValue, r, g, b);
    }

    public ArgbColor(uint argb)
    {
      this.uint_0 = argb;
    }

    public ArgbColor(int argb)
    {
      this.uint_0 = (uint) argb;
    }

    public int Alpha
    {
      get
      {
        return (int) (this.uint_0 >> 24) & (int) byte.MaxValue;
      }
      set
      {
        this.uint_0 |= (uint) ((value & (int) byte.MaxValue) << 24);
      }
    }

    public int Red
    {
      get
      {
        return (int) (this.uint_0 >> 16) & (int) byte.MaxValue;
      }
      set
      {
        this.uint_0 |= (uint) ((value & (int) byte.MaxValue) << 16);
      }
    }

    public int Green
    {
      get
      {
        return (int) (this.uint_0 >> 8) & (int) byte.MaxValue;
      }
      set
      {
        this.uint_0 |= (uint) ((value & (int) byte.MaxValue) << 8);
      }
    }

    public int Blue
    {
      get
      {
        return (int) this.uint_0 & (int) byte.MaxValue;
      }
      set
      {
        this.uint_0 |= (uint) (value & (int) byte.MaxValue);
      }
    }

    public byte A
    {
      get
      {
        return (byte) (this.uint_0 >> 24 & (uint) byte.MaxValue);
      }
      set
      {
        this.uint_0 |= (uint) (((int) value & (int) byte.MaxValue) << 24);
      }
    }

    public byte R
    {
      get
      {
        return (byte) (this.uint_0 >> 16 & (uint) byte.MaxValue);
      }
      set
      {
        this.uint_0 |= (uint) (((int) value & (int) byte.MaxValue) << 16);
      }
    }

    public byte G
    {
      get
      {
        return (byte) (this.uint_0 >> 8 & (uint) byte.MaxValue);
      }
      set
      {
        this.uint_0 |= (uint) (((int) value & (int) byte.MaxValue) << 8);
      }
    }

    public byte B
    {
      get
      {
        return (byte) (this.uint_0 & (uint) byte.MaxValue);
      }
      set
      {
        this.uint_0 |= (uint) value & (uint) byte.MaxValue;
      }
    }

    public int Argb
    {
      get
      {
        return (int) this.uint_0;
      }
      set
      {
        this.uint_0 = (uint) value;
      }
    }

    public uint ArgbUInt32
    {
      get
      {
        return this.uint_0;
      }
      set
      {
        this.uint_0 = value;
      }
    }

    public int Rgb
    {
      get
      {
        return (int) this.uint_0 & 16777215;
      }
      set
      {
        this.uint_0 = (uint) (value | -16777216);
      }
    }

    public byte MaxRgbColorComponent
    {
      get
      {
        return System.Math.Max(this.R, System.Math.Max(this.G, this.B));
      }
    }

    public byte MinRgbColorComponent
    {
      get
      {
        return System.Math.Min(this.R, System.Math.Min(this.G, this.B));
      }
    }

    public override bool Equals(object obj)
    {
      if (obj is ArgbColor)
        return (int) this.uint_0 == (int) ((ArgbColor) obj).uint_0;
      return false;
    }

    public override int GetHashCode()
    {
      return (int) this.uint_0;
    }

    public override string ToString()
    {
      return "#" + this.uint_0.ToString("X8");
    }

    public static ArgbColor FromArgb(int alpha, ArgbColor baseColor)
    {
      return new ArgbColor((uint) (alpha << 24 | (int) baseColor.uint_0 & 16777215));
    }

    public static ArgbColor FromArgb(int argb, bool withAlpha)
    {
      if (!withAlpha)
        return new ArgbColor((uint) (-16777216 | argb));
      return new ArgbColor(argb);
    }

    public static ArgbColor FromRgb(int rgb)
    {
      return new ArgbColor((uint) (-16777216 | rgb));
    }

    public static ArgbColor FromRgb(int r, int g, int b)
    {
      return new ArgbColor((int) byte.MaxValue, r, g, b);
    }

    public static ArgbColor FromGray(int brightness)
    {
      return new ArgbColor((int) byte.MaxValue, brightness, brightness, brightness);
    }

    public static bool IsBrightColor(ArgbColor color)
    {
      return (double) color.R * 0.300000011920929 + (double) color.G * 0.529999971389771 + (double) color.B * 0.170000016689301 >= 128.0;
    }

    public bool Equals(ArgbColor other)
    {
      return (int) other.uint_0 == (int) this.uint_0;
    }

    public static implicit operator Color(ArgbColor color)
    {
      return Color.FromArgb(color.Argb);
    }

    public static implicit operator ArgbColor(Color color)
    {
      return new ArgbColor(color.ToArgb());
    }

    public static bool operator ==(ArgbColor a, ArgbColor b)
    {
      return a.Equals(b);
    }

    public static bool operator !=(ArgbColor a, ArgbColor b)
    {
      return !(a == b);
    }
  }
}
