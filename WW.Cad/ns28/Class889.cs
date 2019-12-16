// Decompiled with JetBrains decompiler
// Type: ns28.Class889
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns35;
using ns43;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WW;
using WW.Cad.Model;

namespace ns28
{
  internal class Class889
  {
    private Stream stream_0;
    private Encoding encoding_0;

    protected Class889(Stream stream, Encoding encoding)
    {
      this.stream_0 = stream;
      this.encoding_0 = encoding;
    }

    public static Class889 Create(Stream stream, DxfVersion version, Encoding encoding)
    {
      return version < DxfVersion.Dxf21 ? new Class889(stream, encoding) : (Class889) new Class890(stream, encoding);
    }

    public Stream Stream
    {
      get
      {
        return this.stream_0;
      }
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

    public virtual byte vmethod_0()
    {
      return (byte) this.stream_0.ReadByte();
    }

    public virtual void vmethod_1(byte value)
    {
      this.stream_0.WriteByte(value);
    }

    public virtual void vmethod_2(byte[] value, int offset, int length)
    {
      this.stream_0.Write(value, offset, length);
    }

    public virtual byte[] vmethod_3(int count)
    {
      byte[] buffer = new byte[count];
      if (this.stream_0.Read(buffer, 0, count) < count)
        throw new EndOfStreamException();
      return buffer;
    }

    public virtual short vmethod_4()
    {
      byte[] numArray = new byte[2];
      this.stream_0.Read(numArray, 0, 2);
      return LittleEndianBitConverter.ToInt16(numArray);
    }

    public virtual void vmethod_5(short value)
    {
      this.stream_0.Write(LittleEndianBitConverter.GetBytes(value), 0, 2);
    }

    public virtual ushort vmethod_6()
    {
      byte[] numArray = new byte[2];
      this.stream_0.Read(numArray, 0, 2);
      return LittleEndianBitConverter.ToUInt16(numArray);
    }

    public virtual void vmethod_7(ushort value)
    {
      this.stream_0.Write(LittleEndianBitConverter.GetBytes(value), 0, 2);
    }

    public virtual int vmethod_8()
    {
      byte[] numArray = new byte[4];
      this.stream_0.Read(numArray, 0, 4);
      return LittleEndianBitConverter.ToInt32(numArray);
    }

    public virtual void vmethod_9(int value)
    {
      this.stream_0.Write(LittleEndianBitConverter.GetBytes(value), 0, 4);
    }

    public virtual uint vmethod_10()
    {
      byte[] numArray = new byte[4];
      this.stream_0.Read(numArray, 0, 4);
      return LittleEndianBitConverter.ToUInt32(numArray);
    }

    public virtual void vmethod_11(uint value)
    {
      this.stream_0.Write(LittleEndianBitConverter.GetBytes(value), 0, 4);
    }

    public virtual long vmethod_12()
    {
      byte[] numArray = new byte[8];
      this.stream_0.Read(numArray, 0, 8);
      return LittleEndianBitConverter.ToInt64(numArray);
    }

    public virtual void vmethod_13(long value)
    {
      this.stream_0.Write(LittleEndianBitConverter.GetBytes(value), 0, 8);
    }

    public virtual ulong vmethod_14()
    {
      byte[] numArray = new byte[8];
      this.stream_0.Read(numArray, 0, 8);
      return LittleEndianBitConverter.ToUInt64(numArray);
    }

    public virtual void vmethod_15(ulong value)
    {
      this.stream_0.Write(LittleEndianBitConverter.GetBytes(value), 0, 8);
    }

    public virtual string vmethod_16()
    {
      int count = (int) this.vmethod_4();
      if (count == 0)
        return string.Empty;
      byte[] numArray = new byte[count];
      this.stream_0.Read(numArray, 0, count);
      return Class1045.encoding_0.GetString(numArray, 0, count - 1);
    }

    public virtual string vmethod_17(int lengthInBytes)
    {
      if (lengthInBytes == 0)
        return string.Empty;
      byte[] numArray = new byte[lengthInBytes];
      this.stream_0.Read(numArray, 0, lengthInBytes);
      return Class1045.encoding_0.GetString(numArray, 0, lengthInBytes - 1);
    }

    public virtual string vmethod_18()
    {
      List<byte> byteList = new List<byte>((int) byte.MaxValue);
      while (true)
      {
        byte num = this.vmethod_0();
        if (num != (byte) 0)
          byteList.Add(num);
        else
          break;
      }
      return Class1045.encoding_0.GetString(byteList.ToArray(), 0, byteList.Count);
    }

    public virtual void vmethod_19(string value)
    {
      byte[] bytes = Class1045.encoding_0.GetBytes(value);
      this.vmethod_5((short) (bytes.Length + 1));
      this.stream_0.Write(bytes, 0, bytes.Length);
      this.stream_0.WriteByte((byte) 0);
    }

    public virtual void vmethod_20(string value)
    {
      byte[] bytes = Class1045.encoding_0.GetBytes(value);
      this.stream_0.Write(bytes, 0, bytes.Length);
      this.stream_0.WriteByte((byte) 0);
    }

    public virtual string vmethod_21()
    {
      int count = this.vmethod_8();
      if (count == 0)
        return string.Empty;
      byte[] numArray = new byte[count];
      this.stream_0.Read(numArray, 0, count);
      return Class1045.encoding_0.GetString(numArray, 0, count);
    }

    public virtual void vmethod_22(string value)
    {
      byte[] bytes = Class1045.encoding_0.GetBytes(value);
      this.vmethod_9(bytes.Length);
      this.stream_0.Write(bytes, 0, bytes.Length);
    }

    public virtual string vmethod_23(Encoding encoding, int byteCount)
    {
      if (byteCount == 0)
        return string.Empty;
      byte[] numArray = new byte[byteCount];
      this.stream_0.Read(numArray, 0, byteCount);
      StringBuilder stringBuilder = new StringBuilder(byteCount);
      int count = 0;
      while (count < byteCount && numArray[count] != (byte) 0)
        ++count;
      return count <= 0 ? string.Empty : encoding.GetString(numArray, 0, count);
    }

    public virtual DxfTimeSpan vmethod_24()
    {
      return new DxfTimeSpan(this.vmethod_8(), this.vmethod_8());
    }

    public virtual void vmethod_25(DxfTimeSpan value)
    {
      this.vmethod_9(value.Days);
      this.vmethod_9(value.Milliseconds);
    }

    public virtual DateTime vmethod_26()
    {
      int julianDayNumber = this.vmethod_8();
      int num = this.vmethod_8();
      DateTime dateTime = Class644.smethod_5(julianDayNumber);
      if (dateTime == DateTime.MaxValue)
        return dateTime;
      return dateTime.AddMilliseconds((double) num);
    }

    public virtual void vmethod_27(DateTime value)
    {
      int days;
      int milliseconds;
      Class644.smethod_1(value, out days, out milliseconds);
      this.vmethod_9(days);
      this.vmethod_9(milliseconds);
    }
  }
}
