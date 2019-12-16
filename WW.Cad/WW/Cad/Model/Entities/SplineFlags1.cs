// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.SplineFlags1
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Entities
{
  [Flags]
  public enum SplineFlags1 : uint
  {
    None = 0,
    MethodFitPoints = 1,
    CVFrameShow = 2,
    IsClosed = 4,
    UseKnotParameter = 8,
  }
}
