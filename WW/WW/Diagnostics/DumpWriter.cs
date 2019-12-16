// Decompiled with JetBrains decompiler
// Type: WW.Diagnostics.DumpWriter
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;

namespace WW.Diagnostics
{
  public class DumpWriter
  {
    private int int_1 = 2;
    private StringBuilder stringBuilder_0 = new StringBuilder();
    private const string string_0 = ",";
    private TextWriter textWriter_0;
    private int int_0;
    private string string_1;

    public DumpWriter(TextWriter textWriter)
    {
      this.textWriter_0 = textWriter;
    }

    public TextWriter W
    {
      get
      {
        return this.textWriter_0;
      }
    }

    public int Indentation
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    public void OpenObject(string objectName)
    {
      this.WriteLine(string.Format("{0} {{", (object) objectName));
      ++this.int_0;
    }

    public void CloseObject()
    {
      this.CloseObject(true);
    }

    public void CloseObject(bool writeNewLine)
    {
      if (this.int_0 <= 0)
        throw new Exception("There was no object opened.");
      --this.int_0;
      this.Write("}");
      if (!writeNewLine)
        return;
      this.WriteLine();
    }

    public void Write(string s)
    {
      this.stringBuilder_0.Append(s);
    }

    public void WriteLine(string s)
    {
      this.stringBuilder_0.Append(s);
      this.WriteLine();
    }

    public void Write(string format, params object[] args)
    {
      this.stringBuilder_0.Append(string.Format(format, args));
    }

    public void WriteLine(string format, params object[] args)
    {
      this.stringBuilder_0.Append(string.Format(format, args));
      this.WriteLine();
    }

    public void WriteLine()
    {
      if (this.stringBuilder_0.Length > 0)
      {
        for (int index1 = 0; index1 < this.int_0; ++index1)
        {
          for (int index2 = 0; index2 < this.int_1; ++index2)
            this.textWriter_0.Write(' ');
        }
      }
      this.textWriter_0.WriteLine(this.stringBuilder_0.ToString());
      this.stringBuilder_0.Clear();
    }

    public void Write(byte[] value)
    {
      if (value.Length <= 0)
        return;
      this.Write(value[0].ToString("x2"));
      for (int index = 1; index < value.Length; ++index)
      {
        this.Write(", ");
        this.Write(value[index].ToString("x2"));
      }
    }

    public void WriteField(string name, byte[] value)
    {
      this.WriteField(name, value, true);
    }

    public void WriteField(string name, byte[] value, bool writeNewLine)
    {
      this.Write("{0}: {{", (object) name);
      if (value.Length > 0)
      {
        this.Write(value[0].ToString("x2"));
        for (int index = 1; index < value.Length; ++index)
        {
          this.Write(", ");
          this.Write(value[index].ToString("x2"));
        }
      }
      this.Write("}");
      if (!writeNewLine)
        return;
      this.WriteLine();
    }

    public void Write(Stream value)
    {
      if (value.Length <= 0L)
        return;
      long position = value.Position;
      value.Position = 0L;
      this.Write(value.ReadByte().ToString("x2"));
      for (int index = 1; (long) index < value.Length; ++index)
      {
        this.Write(", ");
        this.Write(value.ReadByte().ToString("x2"));
      }
      value.Position = position;
    }

    public void WriteField(string name, Stream value)
    {
      this.Write("{0}: {{", (object) name);
      if (value.Length > 0L)
      {
        long position = value.Position;
        value.Position = 0L;
        this.Write(value.ReadByte().ToString("x2"));
        for (int index = 1; (long) index < value.Length; ++index)
        {
          this.Write(", ");
          this.Write(value.ReadByte().ToString("x2"));
        }
        value.Position = position;
      }
      this.WriteLine("}");
    }

    public void WriteField(string name, Stream value, int offset, int length)
    {
      this.Write("{0}: {{", (object) name);
      if (value.Length > 0L)
      {
        long position = value.Position;
        value.Position = (long) offset;
        this.Write(value.ReadByte().ToString("x2"));
        for (int index = 1; index < length; ++index)
        {
          this.Write(", ");
          this.Write(value.ReadByte().ToString("x2"));
        }
        value.Position = position;
      }
      this.WriteLine("}");
    }

    public void WriteField(string name, string value)
    {
      this.WriteField(name, value, true);
    }

    public void WriteField(string name, string value, bool writeNewLine)
    {
      this.method_0(name, string.Format("\"{0}\"", (object) value), writeNewLine);
    }

    public void WriteField(string name, byte value)
    {
      this.WriteField(name, value, true);
    }

    public void WriteField(string name, byte value, bool writeNewLine)
    {
      this.method_0(name, value.ToString((IFormatProvider) CultureInfo.InvariantCulture), writeNewLine);
    }

    public void WriteField(string name, ushort value)
    {
      this.WriteField(name, value, true);
    }

    public void WriteField(string name, ushort value, bool writeNewLine)
    {
      this.method_0(name, value.ToString((IFormatProvider) CultureInfo.InvariantCulture), writeNewLine);
    }

    public void WriteField(string name, short value)
    {
      this.WriteField(name, value, true);
    }

    public void WriteField(string name, short value, bool writeNewLine)
    {
      this.method_0(name, value.ToString((IFormatProvider) CultureInfo.InvariantCulture), writeNewLine);
    }

    public void WriteField(string name, uint value)
    {
      this.WriteField(name, value, true);
    }

    public void WriteField(string name, uint value, bool writeNewLine)
    {
      this.method_0(name, value.ToString((IFormatProvider) CultureInfo.InvariantCulture), writeNewLine);
    }

    public void WriteField(string name, int value)
    {
      this.WriteField(name, value, true);
    }

    public void WriteField(string name, int value, bool writeNewLine)
    {
      this.method_0(name, value.ToString((IFormatProvider) CultureInfo.InvariantCulture), writeNewLine);
    }

    public void WriteField(string name, ulong value)
    {
      this.WriteField(name, value, true);
    }

    public void WriteField(string name, ulong value, bool writeNewLine)
    {
      this.method_0(name, value.ToString((IFormatProvider) CultureInfo.InvariantCulture), writeNewLine);
    }

    public void WriteField(string name, long value)
    {
      this.WriteField(name, value, true);
    }

    public void WriteField(string name, long value, bool writeNewLine)
    {
      this.method_0(name, value.ToString((IFormatProvider) CultureInfo.InvariantCulture), writeNewLine);
    }

    public void WriteField(string name, float value)
    {
      this.WriteField(name, value, true);
    }

    public void WriteField(string name, float value, bool writeNewLine)
    {
      this.method_0(name, value.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture), writeNewLine);
    }

    public void WriteField(string name, double value)
    {
      this.WriteField(name, value, true);
    }

    public void WriteField(string name, double value, bool writeNewLine)
    {
      this.method_0(name, value.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture), writeNewLine);
    }

    public void WriteField(string name, DateTime value)
    {
      this.WriteField(name, value, true);
    }

    public void WriteField(string name, DateTime value, bool writeNewLine)
    {
      this.method_0(name, value.ToString((IFormatProvider) CultureInfo.InvariantCulture), writeNewLine);
    }

    public void WriteField(string name, IDumpable value)
    {
      this.WriteField(name, value, true);
    }

    public void WriteField(string name, IDumpable value, bool writeNewLine)
    {
      this.OpenObject(name);
      value.Dump(this);
      this.CloseObject(writeNewLine);
    }

    public void WriteField(string name, ICollection value)
    {
      this.OpenObject(name);
      foreach (object obj in (IEnumerable) value)
      {
        IDumpable dumpable = obj as IDumpable;
        if (dumpable != null)
          this.WriteField("item", dumpable, false);
        else if (obj is byte[])
          this.WriteField("item", (byte[]) obj, false);
        else if (obj is byte)
          this.WriteField("item", (byte) obj, false);
        else if (obj is ushort)
          this.WriteField("item", (ushort) obj, false);
        else if (obj is short)
          this.WriteField("item", (short) obj, false);
        else if (obj is uint)
          this.WriteField("item", (uint) obj, false);
        else if (obj is int)
          this.WriteField("item", (int) obj, false);
        else if (obj is ulong)
          this.WriteField("item", (ulong) obj, false);
        else if (obj is long)
          this.WriteField("item", (long) obj, false);
        else if (obj is float)
          this.WriteField("item", (float) obj, false);
        else if (obj is double)
        {
          this.WriteField("item", (double) obj, false);
        }
        else
        {
          if (!(obj is string))
            throw new ArgumentException();
          this.WriteField("item", (string) obj, false);
        }
        this.WriteLine(",");
      }
      this.CloseObject();
    }

    private void method_0(string name, string value, bool writeNewLine)
    {
      this.Write("{0}: {1}", (object) name, (object) value);
      if (!writeNewLine)
        return;
      this.WriteLine();
    }
  }
}
