// Decompiled with JetBrains decompiler
// Type: WW.Cad.IO.ReadEventArgs
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW.Cad.Model;

namespace WW.Cad.IO
{
  public class ReadEventArgs : EventArgs
  {
    private DxfModel dxfModel_0;

    public ReadEventArgs(DxfModel model)
    {
      this.dxfModel_0 = model;
    }

    public DxfModel Model
    {
      get
      {
        return this.dxfModel_0;
      }
    }
  }
}
