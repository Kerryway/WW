// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.TableCellStateFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Entities
{
  [Flags]
  public enum TableCellStateFlags
  {
    None = 0,
    ContentLocked = 1,
    ContentReadOnly = 2,
    Linked = 4,
    ContentModifiedAfterUpdate = 8,
    FormatLocked = 16, // 0x00000010
    FormatReadOnly = 32, // 0x00000020
    FormatModifiedAfterUpdate = 64, // 0x00000040
    All = FormatModifiedAfterUpdate | FormatReadOnly | FormatLocked | ContentModifiedAfterUpdate | Linked | ContentReadOnly | ContentLocked, // 0x0000007F
  }
}
