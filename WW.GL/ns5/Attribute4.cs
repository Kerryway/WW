// Decompiled with JetBrains decompiler
// Type: ns5.Attribute4
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System;

namespace ns5
{
  internal class Attribute4 : Attribute
  {
    private string string_0;

    public Attribute4(string Name)
    {
      this.string_0 = Name;
    }

    public string Name
    {
      get
      {
        return this.string_0;
      }
    }
  }
}
