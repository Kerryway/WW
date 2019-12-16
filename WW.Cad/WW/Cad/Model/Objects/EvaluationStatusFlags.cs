// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.EvaluationStatusFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects
{
  [Flags]
  public enum EvaluationStatusFlags
  {
    NotEvaluated = 1,
    Success = 2,
    EvaluatorNotFound = 4,
    SyntaxError = 8,
    InvalidCode = 16, // 0x00000010
    InvalidContext = 32, // 0x00000020
    OtherError = 64, // 0x00000040
  }
}
