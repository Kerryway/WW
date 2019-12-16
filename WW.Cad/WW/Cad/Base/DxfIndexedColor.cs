// Decompiled with JetBrains decompiler
// Type: WW.Cad.Base.DxfIndexedColor
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Drawing;

namespace WW.Cad.Base
{
  [Obsolete("Moved to WW.Cad.Model.DxfIndexedColorSet")]
  public class DxfIndexedColor
  {
    internal static readonly DxfIndexedColor.Struct14 struct14_0 = new DxfIndexedColor.Struct14(DxfIndexedColor.Enum37.const_0, DxfIndexedColor.Enum38.const_0, DxfIndexedColor.Enum39.const_0);
    internal static readonly DxfIndexedColor.Struct14 struct14_1 = new DxfIndexedColor.Struct14(DxfIndexedColor.Enum37.const_0, DxfIndexedColor.Enum38.const_0, DxfIndexedColor.Enum39.const_1);
    internal static readonly DxfIndexedColor.Struct14 struct14_2 = new DxfIndexedColor.Struct14(DxfIndexedColor.Enum37.const_0, DxfIndexedColor.Enum38.const_1, DxfIndexedColor.Enum39.const_1);
    internal static readonly DxfIndexedColor.Struct14 struct14_3 = new DxfIndexedColor.Struct14(DxfIndexedColor.Enum37.const_1, DxfIndexedColor.Enum38.const_1, DxfIndexedColor.Enum39.const_1);
    internal static readonly DxfIndexedColor.Struct14 struct14_4 = new DxfIndexedColor.Struct14(DxfIndexedColor.Enum37.const_1, DxfIndexedColor.Enum38.const_1, DxfIndexedColor.Enum39.const_2);
    private static readonly double[] double_0 = new double[24]{ 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.25, 0.5, 0.75, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.75, 0.5, 0.25 };
    private static readonly int[] int_4 = new int[3]{ 16, 8, 0 };
    [Obsolete]
    public static readonly ArgbColor[] Color = new ArgbColor[257]{ DxfIndexedColor.GetColor(0, 0, 0), DxfIndexedColor.GetColor((int) byte.MaxValue, 0, 0), DxfIndexedColor.GetColor((int) byte.MaxValue, (int) byte.MaxValue, 0), DxfIndexedColor.GetColor(0, (int) byte.MaxValue, 0), DxfIndexedColor.GetColor(0, (int) byte.MaxValue, (int) byte.MaxValue), DxfIndexedColor.GetColor(0, 0, (int) byte.MaxValue), DxfIndexedColor.GetColor((int) byte.MaxValue, 0, (int) byte.MaxValue), DxfIndexedColor.GetColor((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), DxfIndexedColor.GetColor(65, 65, 65), DxfIndexedColor.GetColor(128, 128, 128), DxfIndexedColor.GetColor((int) byte.MaxValue, 0, 0), DxfIndexedColor.GetColor((int) byte.MaxValue, 170, 170), DxfIndexedColor.GetColor(189, 0, 0), DxfIndexedColor.GetColor(189, 126, 126), DxfIndexedColor.GetColor(129, 0, 0), DxfIndexedColor.GetColor(129, 86, 86), DxfIndexedColor.GetColor(104, 0, 0), DxfIndexedColor.GetColor(104, 69, 69), DxfIndexedColor.GetColor(79, 0, 0), DxfIndexedColor.GetColor(79, 53, 53), DxfIndexedColor.GetColor((int) byte.MaxValue, 63, 0), DxfIndexedColor.GetColor((int) byte.MaxValue, 191, 170), DxfIndexedColor.GetColor(189, 46, 0), DxfIndexedColor.GetColor(189, 141, 126), DxfIndexedColor.GetColor(129, 31, 0), DxfIndexedColor.GetColor(129, 96, 86), DxfIndexedColor.GetColor(104, 25, 0), DxfIndexedColor.GetColor(104, 78, 69), DxfIndexedColor.GetColor(79, 19, 0), DxfIndexedColor.GetColor(79, 59, 53), DxfIndexedColor.GetColor((int) byte.MaxValue, (int) sbyte.MaxValue, 0), DxfIndexedColor.GetColor((int) byte.MaxValue, 212, 170), DxfIndexedColor.GetColor(189, 94, 0), DxfIndexedColor.GetColor(189, 157, 126), DxfIndexedColor.GetColor(129, 64, 0), DxfIndexedColor.GetColor(129, 107, 86), DxfIndexedColor.GetColor(104, 52, 0), DxfIndexedColor.GetColor(104, 86, 69), DxfIndexedColor.GetColor(79, 39, 0), DxfIndexedColor.GetColor(79, 66, 53), DxfIndexedColor.GetColor((int) byte.MaxValue, 191, 0), DxfIndexedColor.GetColor((int) byte.MaxValue, 234, 170), DxfIndexedColor.GetColor(189, 141, 0), DxfIndexedColor.GetColor(189, 173, 126), DxfIndexedColor.GetColor(129, 96, 0), DxfIndexedColor.GetColor(129, 118, 86), DxfIndexedColor.GetColor(104, 78, 0), DxfIndexedColor.GetColor(104, 95, 69), DxfIndexedColor.GetColor(79, 59, 0), DxfIndexedColor.GetColor(79, 73, 53), DxfIndexedColor.GetColor((int) byte.MaxValue, (int) byte.MaxValue, 0), DxfIndexedColor.GetColor((int) byte.MaxValue, (int) byte.MaxValue, 170), DxfIndexedColor.GetColor(189, 189, 0), DxfIndexedColor.GetColor(189, 189, 126), DxfIndexedColor.GetColor(129, 129, 0), DxfIndexedColor.GetColor(129, 129, 86), DxfIndexedColor.GetColor(104, 104, 0), DxfIndexedColor.GetColor(104, 104, 69), DxfIndexedColor.GetColor(79, 79, 0), DxfIndexedColor.GetColor(79, 79, 53), DxfIndexedColor.GetColor(191, (int) byte.MaxValue, 0), DxfIndexedColor.GetColor(234, (int) byte.MaxValue, 170), DxfIndexedColor.GetColor(141, 189, 0), DxfIndexedColor.GetColor(173, 189, 126), DxfIndexedColor.GetColor(96, 129, 0), DxfIndexedColor.GetColor(118, 129, 86), DxfIndexedColor.GetColor(78, 104, 0), DxfIndexedColor.GetColor(95, 104, 69), DxfIndexedColor.GetColor(59, 79, 0), DxfIndexedColor.GetColor(73, 79, 53), DxfIndexedColor.GetColor((int) sbyte.MaxValue, (int) byte.MaxValue, 0), DxfIndexedColor.GetColor(212, (int) byte.MaxValue, 170), DxfIndexedColor.GetColor(94, 189, 0), DxfIndexedColor.GetColor(157, 189, 126), DxfIndexedColor.GetColor(64, 129, 0), DxfIndexedColor.GetColor(107, 129, 86), DxfIndexedColor.GetColor(52, 104, 0), DxfIndexedColor.GetColor(86, 104, 69), DxfIndexedColor.GetColor(39, 79, 0), DxfIndexedColor.GetColor(66, 79, 53), DxfIndexedColor.GetColor(63, (int) byte.MaxValue, 0), DxfIndexedColor.GetColor(191, (int) byte.MaxValue, 170), DxfIndexedColor.GetColor(46, 189, 0), DxfIndexedColor.GetColor(141, 189, 126), DxfIndexedColor.GetColor(31, 129, 0), DxfIndexedColor.GetColor(96, 129, 86), DxfIndexedColor.GetColor(25, 104, 0), DxfIndexedColor.GetColor(78, 104, 69), DxfIndexedColor.GetColor(19, 79, 0), DxfIndexedColor.GetColor(59, 79, 53), DxfIndexedColor.GetColor(0, (int) byte.MaxValue, 0), DxfIndexedColor.GetColor(170, (int) byte.MaxValue, 170), DxfIndexedColor.GetColor(0, 189, 0), DxfIndexedColor.GetColor(126, 189, 126), DxfIndexedColor.GetColor(0, 129, 0), DxfIndexedColor.GetColor(86, 129, 86), DxfIndexedColor.GetColor(0, 104, 0), DxfIndexedColor.GetColor(69, 104, 69), DxfIndexedColor.GetColor(0, 79, 0), DxfIndexedColor.GetColor(53, 79, 53), DxfIndexedColor.GetColor(0, (int) byte.MaxValue, 63), DxfIndexedColor.GetColor(170, (int) byte.MaxValue, 191), DxfIndexedColor.GetColor(0, 189, 46), DxfIndexedColor.GetColor(126, 189, 141), DxfIndexedColor.GetColor(0, 129, 31), DxfIndexedColor.GetColor(86, 129, 96), DxfIndexedColor.GetColor(0, 104, 25), DxfIndexedColor.GetColor(69, 104, 78), DxfIndexedColor.GetColor(0, 79, 19), DxfIndexedColor.GetColor(53, 79, 59), DxfIndexedColor.GetColor(0, (int) byte.MaxValue, (int) sbyte.MaxValue), DxfIndexedColor.GetColor(170, (int) byte.MaxValue, 212), DxfIndexedColor.GetColor(0, 189, 94), DxfIndexedColor.GetColor(126, 189, 157), DxfIndexedColor.GetColor(0, 129, 64), DxfIndexedColor.GetColor(86, 129, 107), DxfIndexedColor.GetColor(0, 104, 52), DxfIndexedColor.GetColor(69, 104, 86), DxfIndexedColor.GetColor(0, 79, 39), DxfIndexedColor.GetColor(53, 79, 66), DxfIndexedColor.GetColor(0, (int) byte.MaxValue, 191), DxfIndexedColor.GetColor(170, (int) byte.MaxValue, 234), DxfIndexedColor.GetColor(0, 189, 141), DxfIndexedColor.GetColor(126, 189, 173), DxfIndexedColor.GetColor(0, 129, 96), DxfIndexedColor.GetColor(86, 129, 118), DxfIndexedColor.GetColor(0, 104, 78), DxfIndexedColor.GetColor(69, 104, 95), DxfIndexedColor.GetColor(0, 79, 59), DxfIndexedColor.GetColor(53, 79, 73), DxfIndexedColor.GetColor(0, (int) byte.MaxValue, (int) byte.MaxValue), DxfIndexedColor.GetColor(170, (int) byte.MaxValue, (int) byte.MaxValue), DxfIndexedColor.GetColor(0, 189, 189), DxfIndexedColor.GetColor(126, 189, 189), DxfIndexedColor.GetColor(0, 129, 129), DxfIndexedColor.GetColor(86, 129, 129), DxfIndexedColor.GetColor(0, 104, 104), DxfIndexedColor.GetColor(69, 104, 104), DxfIndexedColor.GetColor(0, 79, 79), DxfIndexedColor.GetColor(53, 79, 79), DxfIndexedColor.GetColor(0, 191, (int) byte.MaxValue), DxfIndexedColor.GetColor(170, 234, (int) byte.MaxValue), DxfIndexedColor.GetColor(0, 141, 189), DxfIndexedColor.GetColor(126, 173, 189), DxfIndexedColor.GetColor(0, 96, 129), DxfIndexedColor.GetColor(86, 118, 129), DxfIndexedColor.GetColor(0, 78, 104), DxfIndexedColor.GetColor(69, 95, 104), DxfIndexedColor.GetColor(0, 59, 79), DxfIndexedColor.GetColor(53, 73, 79), DxfIndexedColor.GetColor(0, (int) sbyte.MaxValue, (int) byte.MaxValue), DxfIndexedColor.GetColor(170, 212, (int) byte.MaxValue), DxfIndexedColor.GetColor(0, 94, 189), DxfIndexedColor.GetColor(126, 157, 189), DxfIndexedColor.GetColor(0, 64, 129), DxfIndexedColor.GetColor(86, 107, 129), DxfIndexedColor.GetColor(0, 52, 104), DxfIndexedColor.GetColor(69, 86, 104), DxfIndexedColor.GetColor(0, 39, 79), DxfIndexedColor.GetColor(53, 66, 79), DxfIndexedColor.GetColor(0, 63, (int) byte.MaxValue), DxfIndexedColor.GetColor(170, 191, (int) byte.MaxValue), DxfIndexedColor.GetColor(0, 46, 189), DxfIndexedColor.GetColor(126, 141, 189), DxfIndexedColor.GetColor(0, 31, 129), DxfIndexedColor.GetColor(86, 96, 129), DxfIndexedColor.GetColor(0, 25, 104), DxfIndexedColor.GetColor(69, 78, 104), DxfIndexedColor.GetColor(0, 19, 79), DxfIndexedColor.GetColor(53, 59, 79), DxfIndexedColor.GetColor(0, 0, (int) byte.MaxValue), DxfIndexedColor.GetColor(170, 170, (int) byte.MaxValue), DxfIndexedColor.GetColor(0, 0, 189), DxfIndexedColor.GetColor(126, 126, 189), DxfIndexedColor.GetColor(0, 0, 129), DxfIndexedColor.GetColor(86, 86, 129), DxfIndexedColor.GetColor(0, 0, 104), DxfIndexedColor.GetColor(69, 69, 104), DxfIndexedColor.GetColor(0, 0, 79), DxfIndexedColor.GetColor(53, 53, 79), DxfIndexedColor.GetColor(63, 0, (int) byte.MaxValue), DxfIndexedColor.GetColor(191, 170, (int) byte.MaxValue), DxfIndexedColor.GetColor(46, 0, 189), DxfIndexedColor.GetColor(141, 126, 189), DxfIndexedColor.GetColor(31, 0, 129), DxfIndexedColor.GetColor(96, 86, 129), DxfIndexedColor.GetColor(25, 0, 104), DxfIndexedColor.GetColor(78, 69, 104), DxfIndexedColor.GetColor(19, 0, 79), DxfIndexedColor.GetColor(59, 53, 79), DxfIndexedColor.GetColor((int) sbyte.MaxValue, 0, (int) byte.MaxValue), DxfIndexedColor.GetColor(212, 170, (int) byte.MaxValue), DxfIndexedColor.GetColor(94, 0, 189), DxfIndexedColor.GetColor(157, 126, 189), DxfIndexedColor.GetColor(64, 0, 129), DxfIndexedColor.GetColor(107, 86, 129), DxfIndexedColor.GetColor(52, 0, 104), DxfIndexedColor.GetColor(86, 69, 104), DxfIndexedColor.GetColor(39, 0, 79), DxfIndexedColor.GetColor(66, 53, 79), DxfIndexedColor.GetColor(191, 0, (int) byte.MaxValue), DxfIndexedColor.GetColor(234, 170, (int) byte.MaxValue), DxfIndexedColor.GetColor(141, 0, 189), DxfIndexedColor.GetColor(173, 126, 189), DxfIndexedColor.GetColor(96, 0, 129), DxfIndexedColor.GetColor(118, 86, 129), DxfIndexedColor.GetColor(78, 0, 104), DxfIndexedColor.GetColor(95, 69, 104), DxfIndexedColor.GetColor(59, 0, 79), DxfIndexedColor.GetColor(73, 53, 79), DxfIndexedColor.GetColor((int) byte.MaxValue, 0, (int) byte.MaxValue), DxfIndexedColor.GetColor((int) byte.MaxValue, 170, (int) byte.MaxValue), DxfIndexedColor.GetColor(189, 0, 189), DxfIndexedColor.GetColor(189, 126, 189), DxfIndexedColor.GetColor(129, 0, 129), DxfIndexedColor.GetColor(129, 86, 129), DxfIndexedColor.GetColor(104, 0, 104), DxfIndexedColor.GetColor(104, 69, 104), DxfIndexedColor.GetColor(79, 0, 79), DxfIndexedColor.GetColor(79, 53, 79), DxfIndexedColor.GetColor((int) byte.MaxValue, 0, 191), DxfIndexedColor.GetColor((int) byte.MaxValue, 170, 234), DxfIndexedColor.GetColor(189, 0, 141), DxfIndexedColor.GetColor(189, 126, 173), DxfIndexedColor.GetColor(129, 0, 96), DxfIndexedColor.GetColor(129, 86, 118), DxfIndexedColor.GetColor(104, 0, 78), DxfIndexedColor.GetColor(104, 69, 95), DxfIndexedColor.GetColor(79, 0, 59), DxfIndexedColor.GetColor(79, 53, 73), DxfIndexedColor.GetColor((int) byte.MaxValue, 0, (int) sbyte.MaxValue), DxfIndexedColor.GetColor((int) byte.MaxValue, 170, 212), DxfIndexedColor.GetColor(189, 0, 94), DxfIndexedColor.GetColor(189, 126, 157), DxfIndexedColor.GetColor(129, 0, 64), DxfIndexedColor.GetColor(129, 86, 107), DxfIndexedColor.GetColor(104, 0, 52), DxfIndexedColor.GetColor(104, 69, 86), DxfIndexedColor.GetColor(79, 0, 39), DxfIndexedColor.GetColor(79, 53, 66), DxfIndexedColor.GetColor((int) byte.MaxValue, 0, 63), DxfIndexedColor.GetColor((int) byte.MaxValue, 170, 191), DxfIndexedColor.GetColor(189, 0, 46), DxfIndexedColor.GetColor(189, 126, 141), DxfIndexedColor.GetColor(129, 0, 31), DxfIndexedColor.GetColor(129, 86, 96), DxfIndexedColor.GetColor(104, 0, 25), DxfIndexedColor.GetColor(104, 69, 78), DxfIndexedColor.GetColor(79, 0, 19), DxfIndexedColor.GetColor(79, 53, 59), DxfIndexedColor.GetColor(51, 51, 51), DxfIndexedColor.GetColor(80, 80, 80), DxfIndexedColor.GetColor(105, 105, 105), DxfIndexedColor.GetColor(130, 130, 130), DxfIndexedColor.GetColor(190, 190, 190), DxfIndexedColor.GetColor((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), DxfIndexedColor.GetColor(0, 0, 0) };
    [Obsolete]
    public static readonly ArgbColor DefaultColor = DxfIndexedColor.Color[7];
    internal static readonly ArgbColor[] argbColor_0 = DxfIndexedColor.smethod_6(DxfIndexedColor.struct14_0);
    internal static readonly ArgbColor[] argbColor_1 = DxfIndexedColor.smethod_6(DxfIndexedColor.struct14_1);
    internal static readonly ArgbColor[] argbColor_2 = DxfIndexedColor.smethod_6(DxfIndexedColor.struct14_2);
    internal static readonly ArgbColor[] argbColor_3 = DxfIndexedColor.smethod_6(DxfIndexedColor.struct14_3);
    internal static readonly ArgbColor[] argbColor_4 = DxfIndexedColor.smethod_6(DxfIndexedColor.struct14_4);
    [Obsolete]
    public static readonly DxfIndexedColor CadlibClassicIndexedColors = new DxfIndexedColor(DxfIndexedColor.Color);
    public static readonly DxfIndexedColor AcadClassicIndexedColors = new DxfIndexedColor(DxfIndexedColor.argbColor_0);
    public static readonly DxfIndexedColor AcadBlackBackgroundIndexedColors = DxfIndexedColor.AcadClassicIndexedColors;
    public static readonly DxfIndexedColor AcadWhiteBackgroundIndexedColors = DxfIndexedColor.GetAcadIndexedColorSet(ArgbColors.White);
    public const short DefaultColorIndex = 7;
    public const int MinimalColorIndex = 1;
    public const int MaximalColorIndex = 255;
    internal const short short_0 = 0;
    internal const short short_1 = 256;
    internal const short short_2 = 257;
    internal const short short_3 = 1;
    internal const short short_4 = 9;
    internal const short short_5 = 10;
    internal const short short_6 = 249;
    internal const short short_7 = 5;
    internal const short short_8 = 24;
    internal const short short_9 = 250;
    internal const short short_10 = 255;
    internal const byte byte_0 = 0;
    internal const byte byte_1 = 29;
    internal const byte byte_2 = 30;
    internal const byte byte_3 = 31;
    internal const byte byte_4 = 32;
    internal const byte byte_5 = 128;
    internal const byte byte_6 = 129;
    internal const byte byte_7 = 255;
    internal const byte byte_8 = 251;
    internal const byte byte_9 = 255;
    internal const byte byte_10 = 29;
    internal const int int_0 = 50;
    private const int int_1 = 16;
    private const int int_2 = 8;
    private const int int_3 = 0;
    protected readonly ArgbColor[] colors;

    protected DxfIndexedColor(ArgbColor[] indexedColors)
    {
      this.colors = indexedColors;
    }

    public ArgbColor this[int aci]
    {
      get
      {
        if (aci > (int) byte.MaxValue)
          return ArgbColor.Empty;
        return this.colors[aci];
      }
    }

    private static ArgbColor GetColor(int r, int g, int b)
    {
      return new ArgbColor(r, g, b);
    }

    public short GetBestMatchingIndex(ArgbColor color)
    {
      int colorDifference;
      return DxfIndexedColor.GetColorIndex(this.colors, color, out colorDifference);
    }

    [Obsolete("Use GetColorIndex(DxfIndexedColor, ArgbColor) instead.")]
    public static short GetColorIndex(ArgbColor color)
    {
      int colorDifference;
      return DxfIndexedColor.GetColorIndex(color, out colorDifference);
    }

    public static short GetColorIndex(DxfIndexedColor indexedColors, ArgbColor color)
    {
      int colorDifference;
      return DxfIndexedColor.GetColorIndex(indexedColors, color, out colorDifference);
    }

    [Obsolete]
    internal static short GetColorIndex(ArgbColor color, out int colorDifference)
    {
      return DxfIndexedColor.GetColorIndex(DxfIndexedColor.AcadClassicIndexedColors.colors, color, out colorDifference);
    }

    public static short GetColorIndex(
      DxfIndexedColor indexedColors,
      ArgbColor color,
      out int colorDifference)
    {
      return DxfIndexedColor.GetColorIndex(indexedColors.colors, color, out colorDifference);
    }

    internal static short GetColorIndex(
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

    internal static short smethod_0(WW.Cad.Model.Color color)
    {
      switch (color.ColorType)
      {
        case ColorType.ByLayer:
          return 256;
        case ColorType.ByBlock:
          return 0;
        case ColorType.None:
          return 0;
        default:
          return DxfIndexedColor.GetColorIndex(color.ToArgbColor(DxfIndexedColorSet.AcadClassicIndexedColors));
      }
    }

    internal static WW.Cad.Model.Color smethod_1(short colorNumber)
    {
      WW.Cad.Model.Color color;
      switch (colorNumber)
      {
        case 0:
          color = WW.Cad.Model.Color.ByBlock;
          break;
        case 256:
          color = WW.Cad.Model.Color.ByLayer;
          break;
        case 257:
          color = WW.Cad.Model.Color.None;
          break;
        default:
          color = WW.Cad.Model.Color.CreateFromColorIndex(colorNumber);
          break;
      }
      return color;
    }

    public static EntityColor GetEntityColor(short colorNumber)
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

    public static DxfIndexedColor GetAcadIndexedColorSet(ArgbColor backgroundColor)
    {
      return (DxfIndexedColor) DxfIndexedColorSet.GetAcadIndexedColorSet(backgroundColor);
    }

    [Obsolete]
    internal static DxfIndexedColor smethod_2(ArgbColor backgroundColor)
    {
      return (DxfIndexedColor) DxfIndexedColorSet.smethod_13(backgroundColor);
    }

    internal static ArgbColor[] smethod_3(ArgbColor backgroundColor)
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

    internal static DxfIndexedColor.Struct14 smethod_4(ArgbColor backgroundColor)
    {
      byte rgbColorComponent = backgroundColor.MaxRgbColorComponent;
      if (rgbColorComponent <= (byte) 29)
        return DxfIndexedColor.struct14_0;
      if (rgbColorComponent <= (byte) 31)
        return DxfIndexedColor.struct14_1;
      if (rgbColorComponent <= (byte) 128)
        return DxfIndexedColor.struct14_2;
      if (backgroundColor.MinRgbColorComponent < (byte) 251)
        return DxfIndexedColor.struct14_3;
      return DxfIndexedColor.struct14_4;
    }

    internal static ArgbColor[] smethod_5(ArgbColor backgroundColor)
    {
      return DxfIndexedColor.smethod_6(DxfIndexedColor.smethod_4(backgroundColor));
    }

    internal static ArgbColor[] smethod_6(DxfIndexedColor.Struct14 colorSetType)
    {
      ArgbColor[] argbColorArray = new ArgbColor[257];
      argbColorArray[0] = argbColorArray[256] = ArgbColor.Empty;
      double[][] numArray1 = new double[24][];
      double[][] numArray2 = new double[24][];
      for (int index1 = 0; index1 < 24; ++index1)
      {
        int index2 = (16 + index1) % 24;
        int index3 = (8 + index1) % 24;
        int index4 = index1 % 24;
        numArray1[index1] = new double[3]
        {
          DxfIndexedColor.double_0[index2],
          DxfIndexedColor.double_0[index3],
          DxfIndexedColor.double_0[index4]
        };
        numArray2[index1] = new double[3]
        {
          0.5 * (DxfIndexedColor.double_0[index2] + 1.0),
          0.5 * (DxfIndexedColor.double_0[index3] + 1.0),
          0.5 * (DxfIndexedColor.double_0[index4] + 1.0)
        };
      }
      double[] numArray3;
      switch (colorSetType.enum38_0)
      {
        case DxfIndexedColor.Enum38.const_0:
          numArray3 = new double[5]
          {
            1.0,
            0.8,
            0.6,
            0.5,
            0.3
          };
          break;
        default:
          numArray3 = new double[5]
          {
            1.0,
            0.65,
            0.5,
            0.3,
            0.15
          };
          break;
      }
      int num1;
      int num2;
      switch (colorSetType.enum39_0)
      {
        case DxfIndexedColor.Enum39.const_0:
          num1 = 51;
          num2 = (int) byte.MaxValue;
          break;
        case DxfIndexedColor.Enum39.const_2:
          num1 = 0;
          num2 = 229;
          break;
        default:
          num1 = 0;
          num2 = (int) byte.MaxValue;
          break;
      }
      argbColorArray[1] = ArgbColors.Red;
      argbColorArray[2] = ArgbColors.Yellow;
      argbColorArray[3] = ArgbColor.FromRgb(0, (int) byte.MaxValue, 0);
      argbColorArray[4] = ArgbColors.Cyan;
      argbColorArray[5] = ArgbColors.Blue;
      argbColorArray[6] = ArgbColors.Magenta;
      argbColorArray[7] = colorSetType.enum37_0 != DxfIndexedColor.Enum37.const_0 ? ArgbColors.Black : ArgbColors.White;
      argbColorArray[8] = ArgbColor.FromGray(128);
      argbColorArray[9] = ArgbColor.FromGray(192);
      for (int index1 = 10; index1 < 250; ++index1)
      {
        int index2 = index1 / 10 - 1;
        double[][] numArray4 = index1 % 2 == 0 ? numArray1 : numArray2;
        int index3 = index1 % 10 / 2;
        double[] numArray5 = numArray4[index2];
        argbColorArray[index1] = ArgbColor.FromRgb(DxfIndexedColor.smethod_9(numArray3[index3] * numArray5[0] * (double) byte.MaxValue), DxfIndexedColor.smethod_9(numArray3[index3] * numArray5[1] * (double) byte.MaxValue), DxfIndexedColor.smethod_9(numArray3[index3] * numArray5[2] * (double) byte.MaxValue));
      }
      for (int index = 0; index < 6; ++index)
        argbColorArray[250 + index] = ArgbColor.FromGray(num1 + index * (num2 - num1) / 5);
      return argbColorArray;
    }

    protected static void ApplyAcadCorrection(ArgbColor[] colors, ArgbColor backgroundColor)
    {
      int mask = DxfIndexedColor.smethod_12(backgroundColor);
      int rgb1 = backgroundColor.Rgb;
      for (int index = 1; index <= (int) byte.MaxValue; ++index)
      {
        int rgb2 = colors[index].Rgb;
        if (DxfIndexedColor.smethod_11(rgb2 & mask, rgb1 & mask) < 29)
          colors[index] = DxfIndexedColor.smethod_7(rgb2, rgb1, mask);
      }
    }

    private static ArgbColor smethod_7(int rgb, int backgroundRgb, int mask)
    {
      int num1 = 0;
      int val2 = 0;
      if (mask == 16777215)
      {
        foreach (int num2 in DxfIndexedColor.int_4)
        {
          int num3 = (int) byte.MaxValue << num2;
          int num4 = (int) ((long) (rgb >> num2) & (long) byte.MaxValue) - (int) ((long) (backgroundRgb >> num2) & (long) byte.MaxValue);
          if (num4 >= 0 && num4 <= 29)
          {
            int val1 = DxfIndexedColor.smethod_8((int) ((long) (rgb >> num2) & (long) byte.MaxValue));
            if (Math.Abs(val1 - val2) < 6)
            {
              num1 |= num3;
              val2 = Math.Max(val1, val2);
            }
            else if (val1 > val2)
            {
              val2 = val1;
              num1 = num3;
            }
          }
        }
      }
      else
      {
        if (DxfIndexedColor.smethod_12(ArgbColor.FromArgb(rgb, false)) == 16777215)
          return ArgbColor.FromArgb(rgb, false);
        foreach (int num2 in DxfIndexedColor.int_4)
        {
          int num3 = (int) byte.MaxValue << num2;
          if ((num3 & mask) != 0 && (int) ((long) (rgb >> num2) & (long) byte.MaxValue) - (int) ((long) (backgroundRgb >> num2) & (long) byte.MaxValue) >= 0)
          {
            num1 |= num3;
            val2 = Math.Max(DxfIndexedColor.smethod_8((int) ((long) (rgb >> num2) & (long) byte.MaxValue)), val2);
          }
        }
      }
      if (num1 == 0)
      {
        int num2 = 256;
        foreach (int num3 in DxfIndexedColor.int_4)
        {
          int num4 = (int) byte.MaxValue << num3;
          if ((num4 & mask) != 0)
          {
            int num5 = Math.Abs((int) (((long) (rgb >> num3) & (long) byte.MaxValue) - ((long) (backgroundRgb >> num3) & (long) byte.MaxValue)));
            if (num5 <= num2 + 6)
            {
              num2 = num5;
              int val1 = DxfIndexedColor.smethod_8((int) ((long) (rgb >> num3) & (long) byte.MaxValue));
              if (Math.Abs(val1 - val2) < 6)
              {
                num1 |= num4;
                val2 = Math.Max(val1, val2);
              }
              else
              {
                val2 = val1;
                num1 = num4;
              }
            }
          }
        }
      }
      int argb = 0;
      foreach (int num2 in DxfIndexedColor.int_4)
      {
        int num3 = (int) byte.MaxValue << num2;
        if ((num3 & mask) != 0 && (num3 & num1) != 0)
          argb |= val2 << num2;
        else
          argb |= rgb & num3;
      }
      if (argb == 16711422)
        argb = 16053492;
      return ArgbColor.FromArgb(argb, false);
    }

    private static int smethod_8(int c)
    {
      if (c <= 205)
        return c + 50;
      return c - 50;
    }

    private static int smethod_9(double v)
    {
      return (int) Math.Floor(v);
    }

    private static int smethod_10(ArgbColor color1, ArgbColor color2)
    {
      return Math.Max(Math.Abs(color1.Red - color2.Red), Math.Max(Math.Abs(color1.Green - color2.Green), Math.Abs(color1.Blue - color2.Blue)));
    }

    private static int smethod_11(int rgb1, int rgb2)
    {
      return DxfIndexedColor.smethod_10(ArgbColor.FromArgb(rgb1, false), ArgbColor.FromArgb(rgb2, false));
    }

    private static int smethod_12(ArgbColor color)
    {
      byte rgbColorComponent = color.MaxRgbColorComponent;
      int num = 0;
      if ((int) color.R == (int) rgbColorComponent)
        num |= 16711680;
      if ((int) color.G == (int) rgbColorComponent)
        num |= 65280;
      if ((int) color.B == (int) rgbColorComponent)
        num |= (int) byte.MaxValue;
      return num;
    }

    internal enum Enum37
    {
      const_0,
      const_1,
    }

    internal enum Enum38
    {
      const_0,
      const_1,
    }

    internal enum Enum39
    {
      const_0,
      const_1,
      const_2,
    }

    internal struct Struct14
    {
      public readonly DxfIndexedColor.Enum37 enum37_0;
      public readonly DxfIndexedColor.Enum38 enum38_0;
      public readonly DxfIndexedColor.Enum39 enum39_0;

      public Struct14(
        DxfIndexedColor.Enum37 standardColorType,
        DxfIndexedColor.Enum38 circleColorType,
        DxfIndexedColor.Enum39 grayColorType)
      {
        this.enum37_0 = standardColorType;
        this.enum38_0 = circleColorType;
        this.enum39_0 = grayColorType;
      }
    }
  }
}
