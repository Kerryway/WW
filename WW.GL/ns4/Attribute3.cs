// Decompiled with JetBrains decompiler
// Type: ns4.Attribute3
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System;

namespace ns4
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
  internal class Attribute3 : Attribute
  {
    private string string_0;

    public Attribute3(string Name)
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
