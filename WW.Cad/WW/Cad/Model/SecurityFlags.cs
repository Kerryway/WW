// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.SecurityFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model
{
  [Flags]
  public enum SecurityFlags
  {
    None = 0,
    EncryptData = 1,
    EncryptProperties = 2,
    SignData = 16, // 0x00000010
    AddTimeStamp = 32, // 0x00000020
  }
}
