// Decompiled with JetBrains decompiler
// Type: WW.Strings
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Globalization;
using System.Reflection;
using System.Resources;

namespace WW
{
  public static class Strings
  {
    private static readonly ResourceManager resourceManager_0 = new ResourceManager("WW.Strings", Assembly.GetExecutingAssembly());

    public static ResourceManager ResourceManager
    {
      get
      {
        return Strings.resourceManager_0;
      }
    }

    public static string GetString(string key)
    {
      return Strings.resourceManager_0.GetString(key);
    }

    public static string GetString(string key, CultureInfo cultureInfo)
    {
      return Strings.resourceManager_0.GetString(key, cultureInfo);
    }
  }
}
