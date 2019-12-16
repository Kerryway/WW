// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfIndexedColorSet
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW.Cad.Base;
using WW.Cad.Model.Entities;
using WW.Drawing;

namespace WW.Cad.Model
{
  public class DxfIndexedColorSet : DxfIndexedColor
  {
    [Obsolete]
    public static readonly DxfIndexedColorSet CadlibClassicIndexedColors = new DxfIndexedColorSet(DxfIndexedColor.Color);
    public static readonly DxfIndexedColorSet AcadClassicIndexedColors = new DxfIndexedColorSet(DxfIndexedColor.argbColor_0);
    public static readonly DxfIndexedColorSet AcadBlackBackgroundIndexedColors = DxfIndexedColorSet.AcadClassicIndexedColors;
    public static readonly DxfIndexedColorSet AcadWhiteBackgroundIndexedColors = DxfIndexedColorSet.GetAcadIndexedColorSet(ArgbColors.White);
    internal static readonly DxfIndexedColor.Struct14 struct14_5 = new DxfIndexedColor.Struct14(DxfIndexedColor.Enum37.const_0, DxfIndexedColor.Enum38.const_0, DxfIndexedColor.Enum39.const_0);
    internal static readonly DxfIndexedColor.Struct14 struct14_6 = new DxfIndexedColor.Struct14(DxfIndexedColor.Enum37.const_0, DxfIndexedColor.Enum38.const_0, DxfIndexedColor.Enum39.const_1);
    internal static readonly DxfIndexedColor.Struct14 struct14_7 = new DxfIndexedColor.Struct14(DxfIndexedColor.Enum37.const_0, DxfIndexedColor.Enum38.const_1, DxfIndexedColor.Enum39.const_1);
    internal static readonly DxfIndexedColor.Struct14 struct14_8 = new DxfIndexedColor.Struct14(DxfIndexedColor.Enum37.const_1, DxfIndexedColor.Enum38.const_1, DxfIndexedColor.Enum39.const_1);
    internal static readonly DxfIndexedColor.Struct14 struct14_9 = new DxfIndexedColor.Struct14(DxfIndexedColor.Enum37.const_1, DxfIndexedColor.Enum38.const_1, DxfIndexedColor.Enum39.const_2);
    internal const short short_11 = 0;
    internal const short short_12 = 256;
    internal const short short_13 = 257;
    internal const short short_14 = 1;
    internal const short short_15 = 9;
    internal const short short_16 = 10;
    internal const short short_17 = 249;
    internal const short short_18 = 250;
    internal const short short_19 = 255;
    internal const byte byte_11 = 0;
    internal const byte byte_12 = 29;
    internal const byte byte_13 = 30;
    internal const byte byte_14 = 31;
    internal const byte byte_15 = 32;
    internal const byte byte_16 = 128;
    internal const byte byte_17 = 129;
    internal const byte byte_18 = 255;
    internal const byte byte_19 = 251;
    internal const byte byte_20 = 255;
    internal const byte byte_21 = 29;
    internal const int int_5 = 50;

    protected DxfIndexedColorSet(ArgbColor[] indexedColors)
      : base(indexedColors)
    {
    }

    public static DxfIndexedColorSet GetAcadIndexedColorSet(
      ArgbColor backgroundColor)
    {
      ArgbColor[] argbColorArray = (ArgbColor[]) DxfIndexedColorSet.smethod_16(backgroundColor).Clone();
      DxfIndexedColor.ApplyAcadCorrection(argbColorArray, backgroundColor);
      return new DxfIndexedColorSet(argbColorArray);
    }

    [Obsolete]
    internal static DxfIndexedColorSet smethod_13(ArgbColor backgroundColor)
    {
      backgroundColor.A = byte.MaxValue;
      ArgbColor[] indexedColors = (ArgbColor[]) DxfIndexedColor.Color.Clone();
      ArgbColor argbColor = ArgbColor.IsBrightColor(backgroundColor) ? ArgbColors.Black : ArgbColors.White;
      for (int index = 1; index < 256; ++index)
      {
        if (indexedColors[index] == backgroundColor)
          indexedColors[index] = argbColor;
      }
      return new DxfIndexedColorSet(indexedColors);
    }

    [Obsolete("Use GetColorIndex(DxfIndexedColor, ArgbColor) instead.")]
    public new static short GetColorIndex(ArgbColor color)
    {
      int colorDifference;
      return DxfIndexedColorSet.GetColorIndex(color, out colorDifference);
    }

    public new static short GetColorIndex(DxfIndexedColor indexedColors, ArgbColor color)
    {
      int colorDifference;
      return DxfIndexedColor.GetColorIndex(indexedColors, color, out colorDifference);
    }

    [Obsolete]
    internal new static short GetColorIndex(ArgbColor color, out int colorDifference)
    {
      return DxfIndexedColorSet.GetColorIndex(DxfIndexedColorSet.AcadClassicIndexedColors.colors, color, out colorDifference);
    }

    public static short GetColorIndex(
      DxfIndexedColorSet indexedColors,
      ArgbColor color,
      out int colorDifference)
    {
      return DxfIndexedColorSet.GetColorIndex(indexedColors.colors, color, out colorDifference);
    }

    internal new static short GetColorIndex(
      ArgbColor[] indexedColors,
      ArgbColor color,
      out int colorDifference)
    {
      colorDifference = int.MaxValue;
      int red = color.Red;
      int green = color.Green;
      int blue = color.Blue;
      short num1 = 0;
      for (short index = 1; index <= (short) byte.MaxValue; ++index)
      {
        ArgbColor indexedColor = indexedColors[(int) index];
        int num2 = red - indexedColor.Red;
        int num3 = green - indexedColor.Green;
        int num4 = blue - indexedColor.Blue;
        int num5 = num2 * num2 + num3 * num3 + num4 * num4;
        if (num5 < colorDifference)
        {
          num1 = index;
          colorDifference = num5;
        }
      }
      return num1;
    }

    internal static short smethod_14(Color color)
    {
      switch (color.ColorType)
      {
        case ColorType.ByLayer:
          return 256;
        case ColorType.ByBlock:
          return 0;
        case ColorType.None:
          return 257;
        default:
          return DxfIndexedColorSet.GetColorIndex(color.ToArgbColor(DxfIndexedColorSet.AcadClassicIndexedColors));
      }
    }

    internal static Color smethod_15(short colorNumber)
    {
      Color color;
      switch (colorNumber)
      {
        case 0:
          color = Color.ByBlock;
          break;
        case 256:
          color = Color.ByLayer;
          break;
        case 257:
          color = Color.None;
          break;
        default:
          color = Color.CreateFromColorIndex(colorNumber);
          break;
      }
      return color;
    }

    public new static EntityColor GetEntityColor(short colorNumber)
    {
      EntityColor entityColor;
      switch (colorNumber)
      {
        case 0:
          entityColor = EntityColor.ByBlock;
          break;
        case 256:
          entityColor = EntityColor.ByLayer;
          break;
        case 257:
          entityColor = EntityColor.None;
          break;
        default:
          entityColor = EntityColor.CreateFromColorIndex(colorNumber);
          break;
      }
      return entityColor;
    }

    internal static ArgbColor[] smethod_16(ArgbColor backgroundColor)
    {
      byte rgbColorComponent = backgroundColor.MaxRgbColorComponent;
      if (rgbColorComponent <= (byte) 29)
        return DxfIndexedColor.argbColor_0;
      if (rgbColorComponent <= (byte) 31)
        return DxfIndexedColor.argbColor_1;
      if (rgbColorComponent <= (byte) 128)
        return DxfIndexedColor.argbColor_2;
      if (backgroundColor.MinRgbColorComponent < (byte) 251)
        return DxfIndexedColor.argbColor_3;
      return DxfIndexedColor.argbColor_4;
    }

    internal static DxfIndexedColor.Struct14 smethod_17(ArgbColor backgroundColor)
    {
      byte rgbColorComponent = backgroundColor.MaxRgbColorComponent;
      if (rgbColorComponent <= (byte) 29)
        return DxfIndexedColorSet.struct14_5;
      if (rgbColorComponent <= (byte) 31)
        return DxfIndexedColorSet.struct14_6;
      if (rgbColorComponent <= (byte) 128)
        return DxfIndexedColorSet.struct14_7;
      if (backgroundColor.MinRgbColorComponent < (byte) 251)
        return DxfIndexedColorSet.struct14_8;
      return DxfIndexedColorSet.struct14_9;
    }

    internal static ArgbColor[] smethod_18(ArgbColor backgroundColor)
    {
      return DxfIndexedColor.smethod_6(DxfIndexedColorSet.smethod_17(backgroundColor));
    }
  }
}
