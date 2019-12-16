// Decompiled with JetBrains decompiler
// Type: ns6.EventArgs0
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace ns6
{
  internal class EventArgs0 : EventArgs
  {
    private Class49 class49_0;

    public EventArgs0(Class49 fileSegment)
    {
      this.class49_0 = fileSegment;
    }

    public Class49 FileSegment
    {
      get
      {
        return this.class49_0;
      }
    }
  }
}
