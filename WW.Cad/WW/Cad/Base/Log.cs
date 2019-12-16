// Decompiled with JetBrains decompiler
// Type: WW.Cad.Base.Log
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;

namespace WW.Cad.Base
{
  public class Log
  {
    private List<LogMessage> list_0;

    public event LogEventHandler MessageAdded;

    public Log()
    {
      this.list_0 = new List<LogMessage>();
    }

    public LogMessage[] Messages
    {
      get
      {
        return this.list_0.ToArray();
      }
    }

    public void LogMessage(LogMessage message)
    {
      this.list_0.Add(message);
      this.OnMessageAdded(message);
    }

    public void LogDebug(string message)
    {
      LogMessage message1 = new LogMessage(message, Severity.Debug);
      this.list_0.Add(message1);
      this.OnMessageAdded(message1);
    }

    public void LogInfo(string message)
    {
      LogMessage message1 = new LogMessage(message, Severity.Info);
      this.list_0.Add(message1);
      this.OnMessageAdded(message1);
    }

    public void LogWarning(string message)
    {
      LogMessage message1 = new LogMessage(message, Severity.Warning);
      this.list_0.Add(message1);
      this.OnMessageAdded(message1);
    }

    public void LogError(string message)
    {
      LogMessage message1 = new LogMessage(message, Severity.Error);
      this.list_0.Add(message1);
      this.OnMessageAdded(message1);
    }

    public LogStatistics GetStatistics()
    {
      int count = this.list_0.Count;
      int warningCount = 0;
      int errorCount = 0;
      int debugCount = 0;
      foreach (LogMessage logMessage in this.list_0)
      {
        switch (logMessage.Severity)
        {
          case Severity.Debug:
            ++debugCount;
            continue;
          case Severity.Warning:
            ++warningCount;
            continue;
          case Severity.Error:
            ++errorCount;
            continue;
          default:
            continue;
        }
      }
      return new LogStatistics(count, debugCount, warningCount, errorCount);
    }

    protected virtual void OnMessageAdded(LogMessage message)
    {
      if (this.logEventHandler_0 == null)
        return;
      this.logEventHandler_0((object) this, new LogEventArgs(message));
    }
  }
}
