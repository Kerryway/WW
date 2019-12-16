// Decompiled with JetBrains decompiler
// Type: WW.Cad.Base.ProgressEventArgs
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Base
{
  public class ProgressEventArgs : EventArgs
  {
    private float float_0;
    private bool bool_0;

    public ProgressEventArgs(float progress)
    {
      this.float_0 = progress;
    }

    public float Progress
    {
      get
      {
        return this.float_0;
      }
    }

    public bool Cancelled
    {
      get
      {
        return this.bool_0;
      }
    }

    public void Cancel()
    {
      this.bool_0 = true;
    }
  }
}
