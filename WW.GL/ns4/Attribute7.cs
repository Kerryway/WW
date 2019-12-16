// Decompiled with JetBrains decompiler
// Type: ns4.Attribute7
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System;

namespace ns4
{
  [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
  internal class Attribute7 : Attribute
  {
    private string string_0 = string.Empty;

    public Attribute7(string pattern)
    {
      this.string_0 = pattern;
    }

    public string Pattern
    {
      get
      {
        return this.string_0;
      }
    }
  }
}
