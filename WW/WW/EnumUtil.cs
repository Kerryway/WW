// Decompiled with JetBrains decompiler
// Type: WW.EnumUtil
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW
{
  public static class EnumUtil
  {
    public static bool TryParse<TEnum>(string s, bool ignoreCase, out TEnum result) where TEnum : struct, IConvertible
    {
      return Enum.TryParse<TEnum>(s, ignoreCase, out result);
    }
  }
}
