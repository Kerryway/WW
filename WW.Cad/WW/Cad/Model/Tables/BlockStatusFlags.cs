// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.BlockStatusFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Tables
{
  [Flags]
  public enum BlockStatusFlags : short
  {
    None = 0,
    ExternalReferenceUnresolved = 1,
    ExternalReferenceUnloaded = 2,
    CorrectionNeeded = 4,
    DrawReentered = 8,
    ExternalReferenceFileNotFound = 22, // 0x0016
  }
}
