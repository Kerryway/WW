// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Point2IConverter
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace WW.Math.Exact
{
  public class Point2IConverter : ExpandableObjectConverter
  {
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof (string))
        return true;
      return base.CanConvertFrom(context, sourceType);
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof (string))
        return true;
      return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value,
      Type destinationType)
    {
      if (destinationType == typeof (string) && value is Point2I)
        return (object) ((Point2I) value).ToString();
      return base.ConvertTo(context, culture, value, destinationType);
    }

    public override object ConvertFrom(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value)
    {
      if (value.GetType() == typeof (string))
        return (object) Point2I.Parse((string) value);
      return base.ConvertFrom(context, culture, value);
    }

    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
    {
      return true;
    }

    public override TypeConverter.StandardValuesCollection GetStandardValues(
      ITypeDescriptorContext context)
    {
      return new TypeConverter.StandardValuesCollection((ICollection) new object[1]{ (object) Point2I.Zero });
    }
  }
}
