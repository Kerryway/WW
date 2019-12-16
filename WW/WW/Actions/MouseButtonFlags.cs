// Decompiled with JetBrains decompiler
// Type: WW.Actions.MouseButtonFlags
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Actions
{
  [Flags]
  public enum MouseButtonFlags : byte
  {
    None = 0,
    Left = 1,
    Middle = 2,
    Right = 4,
    XButton1 = 8,
    XButton2 = 16, // 0x10
  }
}
