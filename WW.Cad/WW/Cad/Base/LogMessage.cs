// Decompiled with JetBrains decompiler
// Type: WW.Cad.Base.LogMessage
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Base
{
  public class LogMessage
  {
    private string string_0;
    private DateTime dateTime_0;
    private Severity severity_0;

    public LogMessage(string message, Severity severity)
    {
      this.string_0 = message;
      this.severity_0 = severity;
      this.dateTime_0 = DateTime.Now;
    }

    public DateTime DateTime
    {
      get
      {
        return this.dateTime_0;
      }
    }

    public string Message
    {
      get
      {
        return this.string_0;
      }
    }

    public Severity Severity
    {
      get
      {
        return this.severity_0;
      }
    }

    public override string ToString()
    {
      return this.dateTime_0.ToString() + " " + this.severity_0.ToString() + ": " + this.string_0;
    }
  }
}
