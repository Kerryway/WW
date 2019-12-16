// Decompiled with JetBrains decompiler
// Type: WW.Cad.Base.LogEventArgs
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Base
{
  public class LogEventArgs : EventArgs
  {
    private LogMessage logMessage_0;

    public LogEventArgs(LogMessage message)
    {
      this.logMessage_0 = message;
    }

    public LogMessage Message
    {
      get
      {
        return this.logMessage_0;
      }
    }
  }
}
