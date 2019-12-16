// Decompiled with JetBrains decompiler
// Type: ns28.Class1047
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.IO;

namespace ns28
{
  internal class Class1047
  {
    public static uint smethod_0(uint value)
    {
      uint num = value;
      if (!BitConverter.IsLittleEndian)
      {
        byte[] bytes = BitConverter.GetBytes(value);
        num = BitConverter.ToUInt32(new byte[4]
        {
          bytes[3],
          bytes[2],
          bytes[1],
          bytes[0]
        }, 0);
      }
      return num;
    }

    public static uint smethod_1(uint value)
    {
      uint num = value;
      if (!BitConverter.IsLittleEndian)
      {
        byte[] bytes = BitConverter.GetBytes(value);
        num = BitConverter.ToUInt32(new byte[4]
        {
          bytes[3],
          bytes[2],
          bytes[1],
          bytes[0]
        }, 0);
      }
      return num;
    }

    public static void Write(Stream stream, ulong value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      if (BitConverter.IsLittleEndian)
      {
        stream.Write(bytes, 0, 8);
      }
      else
      {
        for (int index = 7; index >= 0; --index)
          stream.WriteByte(bytes[index]);
      }
    }

    public static void Write(Stream stream, long value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      if (BitConverter.IsLittleEndian)
      {
        stream.Write(bytes, 0, 8);
      }
      else
      {
        for (int index = 7; index >= 0; --index)
          stream.WriteByte(bytes[index]);
      }
    }

    public static void Write(Stream stream, uint value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      if (BitConverter.IsLittleEndian)
      {
        stream.Write(bytes, 0, 4);
      }
      else
      {
        for (int index = 3; index >= 0; --index)
          stream.WriteByte(bytes[index]);
      }
    }

    public static void Write(Stream stream, int value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      if (BitConverter.IsLittleEndian)
      {
        stream.Write(bytes, 0, 4);
      }
      else
      {
        for (int index = 3; index >= 0; --index)
          stream.WriteByte(bytes[index]);
      }
    }

    public static void Write(Stream stream, ushort value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      if (BitConverter.IsLittleEndian)
      {
        stream.Write(bytes, 0, 2);
      }
      else
      {
        for (int index = 1; index >= 0; --index)
          stream.WriteByte(bytes[index]);
      }
    }

    public static void Write(Stream stream, short value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      if (BitConverter.IsLittleEndian)
      {
        stream.Write(bytes, 0, 2);
      }
      else
      {
        for (int index = 1; index >= 0; --index)
          stream.WriteByte(bytes[index]);
      }
    }

    public static void Write(Stream stream, float value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      if (BitConverter.IsLittleEndian)
      {
        stream.Write(bytes, 0, 4);
      }
      else
      {
        for (int index = 3; index >= 0; --index)
          stream.WriteByte(bytes[index]);
      }
    }

    public static void Write(Stream stream, double value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      if (BitConverter.IsLittleEndian)
      {
        stream.Write(bytes, 0, 8);
      }
      else
      {
        for (int index = 7; index >= 0; --index)
          stream.WriteByte(bytes[index]);
      }
    }
  }
}
