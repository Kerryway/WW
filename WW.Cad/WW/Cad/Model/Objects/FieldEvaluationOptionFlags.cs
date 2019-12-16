// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.FieldEvaluationOptionFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects
{
  [Flags]
  public enum FieldEvaluationOptionFlags
  {
    Never = 0,
    OnOpen = 1,
    OnSave = 2,
    OnPlot = 4,
    OnETransmit = 8,
    OnRegen = 16, // 0x00000010
    OnDemand = 32, // 0x00000020
  }
}
