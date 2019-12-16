// Decompiled with JetBrains decompiler
// Type: WW.Drawing.ArgbColorTypeConverter
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace WW.Drawing
{
  public class ArgbColorTypeConverter : TypeConverter
  {
    private static readonly ColorConverter colorConverter_0 = new ColorConverter();

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (!(sourceType == typeof (Color)))
        return ArgbColorTypeConverter.colorConverter_0.CanConvertFrom(context, sourceType);
      return true;
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      if (!(destinationType == typeof (Color)))
        return ArgbColorTypeConverter.colorConverter_0.CanConvertTo(context, destinationType);
      return true;
    }

    public override object ConvertFrom(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value)
    {
      Color color;
      try
      {
        color = (Color) value;
      }
      catch (InvalidCastException ex)
      {
        color = (Color) ArgbColorTypeConverter.colorConverter_0.ConvertFrom(context, culture, value);
      }
      return (object) (ArgbColor) color;
    }

    public override object ConvertTo(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value,
      Type destinationType)
    {
      Color color = (Color) ((ArgbColor) value);
      if (destinationType == typeof (Color))
        return (object) color;
      return ArgbColorTypeConverter.colorConverter_0.ConvertTo(context, culture, (object) color, destinationType);
    }

    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
    {
      return true;
    }

    public override TypeConverter.StandardValuesCollection GetStandardValues(
      ITypeDescriptorContext context)
    {
      return new TypeConverter.StandardValuesCollection((ICollection) new object[9]{ (object) ArgbColors.Black, (object) ArgbColors.White, (object) ArgbColors.Gray, (object) ArgbColors.Red, (object) ArgbColors.Green, (object) ArgbColors.Blue, (object) ArgbColors.Yellow, (object) ArgbColors.Magenta, (object) ArgbColors.Turquoise });
    }
  }
}
