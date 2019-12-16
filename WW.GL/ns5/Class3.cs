// Decompiled with JetBrains decompiler
// Type: ns5.Class3
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System.Diagnostics;
using System.Threading;

namespace ns5
{
  internal static class Class3
  {
    private const string string_0 = "WW.OpenGL";
    private static EventLog eventLog_0;

    static Class3()
    {
      if (!EventLog.SourceExists("WW.OpenGL"))
        EventLog.CreateEventSource("WW.OpenGL", "WW.OpenGL");
      Class3.eventLog_0 = new EventLog();
      Class3.eventLog_0.Source = "WW.OpenGL";
    }

    public static void smethod_0(string s)
    {
      string message = Thread.CurrentThread.ManagedThreadId.ToString() + ": " + s;
      Class3.eventLog_0.WriteEntry(message);
    }
  }
}
