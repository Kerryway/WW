// Decompiled with JetBrains decompiler
// Type: ns4.Enum24
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace ns4
{
  [Flags]
  internal enum Enum24 : byte
  {
    flag_0 = 0,
    flag_1 = 1,
    flag_2 = 2,
    flag_3 = flag_2 | flag_1, // 0x03
  }
}
