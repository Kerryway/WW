// Decompiled with JetBrains decompiler
// Type: ns38.Attribute0
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Globalization;

namespace ns38
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
