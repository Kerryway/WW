// Decompiled with JetBrains decompiler
// Type: ns1.Attribute0
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Globalization;

namespace ns1
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
