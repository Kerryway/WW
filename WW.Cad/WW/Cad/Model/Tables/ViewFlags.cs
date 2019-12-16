// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.ViewFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Tables
{
  [Flags]
  public enum ViewFlags : short
  {
    None = 0,
    PaperSpace = 1,
    IsExternallyDependent = 16, // 0x0010
    IsResolvedExternalRef = 32, // 0x0020
    IsReferenced = 64, // 0x0040
  }
}
