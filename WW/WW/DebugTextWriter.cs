// Decompiled with JetBrains decompiler
// Type: WW.DebugTextWriter
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.IO;
using System.Text;
using WW.Text;

namespace WW
{
  public class DebugTextWriter : TextWriter
  {
    public static readonly DebugTextWriter Instance = new DebugTextWriter();

    private DebugTextWriter()
    {
    }

    public override Encoding Encoding
    {
      get
      {
        return Encodings.Default;
      }
    }

    public override void Close()
    {
      base.Close();
    }

    public override void Flush()
    {
      base.Flush();
    }

    public override void Write(bool value)
    {
    }

    public override void Write(char value)
    {
    }

    public override void Write(char[] buffer)
    {
    }

    public override void Write(Decimal value)
    {
    }

    public override void Write(double value)
    {
    }

    public override void Write(float value)
    {
    }

    public override void Write(int value)
    {
    }

    public override void Write(long value)
    {
    }

    public override void Write(object value)
    {
    }

    public override void Write(string value)
    {
    }

    public override void Write(uint value)
    {
    }

    public override void Write(ulong value)
    {
    }

    public override void Write(string format, object arg0)
    {
    }

    public override void Write(string format, params object[] arg)
    {
    }

    public override void Write(char[] buffer, int index, int count)
    {
      string str = new string(buffer, index, count);
    }

    public override void Write(string format, object arg0, object arg1)
    {
    }

    public override void Write(string format, object arg0, object arg1, object arg2)
    {
    }

    public override void WriteLine()
    {
    }

    public override void WriteLine(bool value)
    {
    }

    public override void WriteLine(char value)
    {
    }

    public override void WriteLine(char[] buffer)
    {
    }

    public override void WriteLine(Decimal value)
    {
    }

    public override void WriteLine(double value)
    {
    }

    public override void WriteLine(float value)
    {
    }

    public override void WriteLine(int value)
    {
    }

    public override void WriteLine(long value)
    {
    }

    public override void WriteLine(object value)
    {
    }

    public override void WriteLine(string value)
    {
    }

    public override void WriteLine(uint value)
    {
    }

    public override void WriteLine(ulong value)
    {
    }

    public override void WriteLine(string format, object arg0)
    {
    }

    public override void WriteLine(string format, params object[] arg)
    {
    }

    public override void WriteLine(char[] buffer, int index, int count)
    {
      string str = new string(buffer, index, count);
    }

    public override void WriteLine(string format, object arg0, object arg1)
    {
    }

    public override void WriteLine(string format, object arg0, object arg1, object arg2)
    {
    }
  }
}
