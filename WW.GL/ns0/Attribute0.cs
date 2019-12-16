// Decompiled with JetBrains decompiler
// Type: ns0.Attribute0
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System;
using System.Globalization;

namespace ns0
{
  [AttributeUsage(AttributeTargets.Assembly)]
  internal class Attribute0 : Attribute
  {
    private string string_0;
    private string string_1;
    private DateTime dateTime_0;

    public Attribute0(string productName, string registryKey, string releaseDateString)
    {
      this.string_0 = productName;
      this.string_1 = registryKey;
      this.dateTime_0 = DateTime.Parse(releaseDateString, (IFormatProvider) CultureInfo.InvariantCulture);
    }

    public string ProductName
    {
      get
      {
        return this.string_0;
      }
    }

    public string RegistryKey
    {
      get
      {
        return this.string_1;
      }
    }

    public DateTime ReleaseDate
    {
      get
      {
        return this.dateTime_0;
      }
    }
  }
}
