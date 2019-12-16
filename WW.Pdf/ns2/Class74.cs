// Decompiled with JetBrains decompiler
// Type: ns2.Class74
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System;
using System.Collections.Generic;
using System.IO;

namespace ns2
{
  internal class Class74
  {
    private readonly Stack<long> stack_0 = new Stack<long>();
    private readonly Stream stream_0;

    public Class74(byte[] data)
    {
      if (data == null)
        throw new ArgumentNullException(nameof (data), "data array cannot be null.");
      if (data.Length == 0)
        throw new ArgumentException("data array is empty.", nameof (data));
      this.stream_0 = (Stream) new MemoryStream(data);
    }

    public Class74(Stream stream)
    {
      if (stream == null)
        throw new ArgumentNullException(nameof (stream), "stream parameter cannot be null");
      this.stream_0 = stream;
    }

    public byte method_0()
    {
      return (byte) this.stream_0.ReadByte();
    }

    public void method_1(byte value)
    {
      this.stream_0.WriteByte(value);
    }

    public sbyte method_2()
    {
      return (sbyte) this.stream_0.ReadByte();
    }

    public void method_3(sbyte value)
    {
      this.stream_0.WriteByte((byte) ((uint) value & (uint) byte.MaxValue));
    }

    public short method_4()
    {
      return (short) (((int) this.method_0() << 8) + (int) this.method_0());
    }

    public void method_5(int value)
    {
      this.stream_0.WriteByte((byte) (value >> 8 & (int) byte.MaxValue));
      this.stream_0.WriteByte((byte) (value & (int) byte.MaxValue));
    }

    public short method_6()
    {
      return this.method_4();
    }

    public void method_7(int value)
    {
      this.method_5(value);
    }

    public ushort method_8()
    {
      return (ushort) (((uint) this.method_0() << 8) + (uint) this.method_0());
    }

    public void method_9(int value)
    {
      this.stream_0.WriteByte((byte) (value >> 8 & (int) byte.MaxValue));
      this.stream_0.WriteByte((byte) (value & (int) byte.MaxValue));
    }

    public ushort method_10()
    {
      return this.method_8();
    }

    public void method_11(int value)
    {
      this.method_9(value);
    }

    public int method_12()
    {
      return ((((int) this.method_0() << 8) + (int) this.method_0() << 8) + (int) this.method_0() << 8) + (int) this.method_0();
    }

    public void method_13(int value)
    {
      this.stream_0.WriteByte((byte) (value >> 24 & (int) byte.MaxValue));
      this.stream_0.WriteByte((byte) (value >> 16 & (int) byte.MaxValue));
      this.stream_0.WriteByte((byte) (value >> 8 & (int) byte.MaxValue));
      this.stream_0.WriteByte((byte) (value & (int) byte.MaxValue));
    }

    public uint method_14()
    {
      return ((((uint) this.method_0() << 8) + (uint) this.method_0() << 8) + (uint) this.method_0() << 8) + (uint) this.method_0();
    }

    public void method_15(uint value)
    {
      this.stream_0.WriteByte((byte) (value >> 24 & (uint) byte.MaxValue));
      this.stream_0.WriteByte((byte) (value >> 16 & (uint) byte.MaxValue));
      this.stream_0.WriteByte((byte) (value >> 8 & (uint) byte.MaxValue));
      this.stream_0.WriteByte((byte) (value & (uint) byte.MaxValue));
    }

    public int method_16()
    {
      return this.method_12();
    }

    public void method_17(int value)
    {
      this.method_13(value);
    }

    public long method_18()
    {
      return ((((((((long) this.method_0() << 8) + (long) this.method_0() << 8) + (long) this.method_0() << 8) + (long) this.method_0() << 8) + (long) this.method_0() << 8) + (long) this.method_0() << 8) + (long) this.method_0() << 8) + (long) this.method_0();
    }

    public void method_19(long value)
    {
      this.stream_0.WriteByte((byte) (value >> 56 & (long) byte.MaxValue));
      this.stream_0.WriteByte((byte) (value >> 48 & (long) byte.MaxValue));
      this.stream_0.WriteByte((byte) (value >> 40 & (long) byte.MaxValue));
      this.stream_0.WriteByte((byte) (value >> 32 & (long) byte.MaxValue));
      this.stream_0.WriteByte((byte) (value >> 24 & (long) byte.MaxValue));
      this.stream_0.WriteByte((byte) (value >> 16 & (long) byte.MaxValue));
      this.stream_0.WriteByte((byte) (value >> 8 & (long) byte.MaxValue));
      this.stream_0.WriteByte((byte) ((uint) (int) value & (uint) byte.MaxValue));
    }

    public byte[] method_20()
    {
      return new byte[4]{ this.method_0(), this.method_0(), this.method_0(), this.method_0() };
    }

    public void method_21(byte[] value)
    {
      this.stream_0.WriteByte(value[0]);
      this.stream_0.WriteByte(value[1]);
      this.stream_0.WriteByte(value[2]);
      this.stream_0.WriteByte(value[3]);
    }

    public int method_22()
    {
      int num = (int) (this.stream_0.Position % 4L);
      for (int index = 0; index < num; ++index)
        this.stream_0.WriteByte((byte) 0);
      return num;
    }

    public void method_23(byte[] buffer, int offset, int count)
    {
      this.stream_0.Write(buffer, offset, count);
    }

    public int method_24(byte[] buffer, int offset, int count)
    {
      return this.stream_0.Read(buffer, offset, count);
    }

    public long Position
    {
      get
      {
        return this.stream_0.Position;
      }
      set
      {
        this.stream_0.Position = value;
      }
    }

    public long Length
    {
      get
      {
        return this.stream_0.Length;
      }
    }

    public void method_25(long offset)
    {
      this.stream_0.Seek(offset, SeekOrigin.Current);
    }

    public long method_26()
    {
      this.stack_0.Push(this.Position);
      return this.Position;
    }

    public long method_27()
    {
      if (this.stack_0.Count == 0)
        throw new InvalidOperationException("There are no stream markers.");
      long position = this.Position;
      this.Position = Convert.ToInt64(this.stack_0.Pop());
      return position;
    }
  }
}
