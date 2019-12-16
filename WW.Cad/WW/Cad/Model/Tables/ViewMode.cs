// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.ViewMode
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Tables
{
  [Flags]
  public enum ViewMode : short
  {
    None = 0,
    PerspectiveMode = 1,
    ClipFront = 2,
    ClipBack = 4,
    FollowUCS = 8,
    ClipFrontNotAtEye = 16, // 0x0010
  }
}
