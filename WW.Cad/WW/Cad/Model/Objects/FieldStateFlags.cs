// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.FieldStateFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects
{
  [Flags]
  public enum FieldStateFlags
  {
    Unknown = 0,
    Initialized = 1,
    Compiled = 2,
    Modified = 4,
    Evaluated = 8,
    Cached = 16, // 0x00000010
  }
}
