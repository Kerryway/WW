// Decompiled with JetBrains decompiler
// Type: ns2.Class1045
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;
using System.Text;
using WW;
using WW.IO;
using WW.Text;

namespace ns2
{
  internal static class Class1045
  {
    public static readonly Encoding encoding_0 = Encodings.GetEncoding(1252);

    public static PagedMemoryStream smethod_0(PagedMemoryStream source)
    {
      return new PagedMemoryStream(source);
    }

    public static PagedMemoryStream smethod_1(
      Stream source,
      long length,
      MemoryPageCache memoryPageCache)
    {
      long position = source.Position;
      MemoryStream source1 = source as MemoryStream;
      PagedMemoryStream pagedMemoryStream = source1 == null ? new PagedMemoryStream(source, length, memoryPageCache.PageSize, (IMemoryPageCache) memoryPageCache) : new PagedMemoryStream(source1, length);
      source.Position = position;
      return pagedMemoryStream;
    }

    public static byte smethod_2(Stream stream)
    {
      int num = stream.ReadByte();
      if (num < 0)
        throw new EndOfStreamException();
      return (byte) num;
    }

    public static short smethod_3(Stream stream)
    {
      byte[] numArray = new byte[2];
      stream.Read(numArray, 0, 2);
      return LittleEndianBitConverter.ToInt16(numArray, 0);
    }

    public static void smethod_4(Stream stream, short value)
    {
      byte[] bytes = LittleEndianBitConverter.GetBytes(value);
      stream.Write(bytes, 0, 2);
    }

    public static ushort smethod_5(Stream stream)
    {
      byte[] numArray = new byte[2];
      stream.Read(numArray, 0, 2);
      return LittleEndianBitConverter.ToUInt16(numArray, 0);
    }

    public static void smethod_6(Stream stream, ushort value)
    {
      byte[] bytes = LittleEndianBitConverter.GetBytes(value);
      stream.Write(bytes, 0, 2);
    }

    public static int smethod_7(Stream stream)
    {
      byte[] numArray = new byte[4];
      stream.Read(numArray, 0, 4);
      return LittleEndianBitConverter.ToInt32(numArray, 0);
    }

    public static double smethod_8(Stream stream)
    {
      byte[] numArray = new byte[8];
      stream.Read(numArray, 0, 8);
      return LittleEndianBitConverter.ToDouble(numArray, 0);
    }

    public static void smethod_9(Stream stream, int value)
    {
      byte[] bytes = LittleEndianBitConverter.GetBytes(value);
      stream.Write(bytes, 0, 4);
    }

    public static uint smethod_10(Stream stream)
    {
      byte[] numArray = new byte[4];
      stream.Read(numArray, 0, 4);
      return LittleEndianBitConverter.ToUInt32(numArray, 0);
    }

    public static void smethod_11(Stream stream, uint value)
    {
      byte[] bytes = LittleEndianBitConverter.GetBytes(value);
      stream.Write(bytes, 0, 4);
    }

    public static long smethod_12(Stream stream)
    {
      byte[] numArray = new byte[8];
      stream.Read(numArray, 0, 8);
      return LittleEndianBitConverter.ToInt64(numArray, 0);
    }

    public static void smethod_13(Stream stream, long value)
    {
      byte[] bytes = LittleEndianBitConverter.GetBytes(value);
      stream.Write(bytes, 0, 8);
    }

    public static ulong smethod_14(Stream stream)
    {
      byte[] numArray = new byte[8];
      stream.Read(numArray, 0, 8);
      return LittleEndianBitConverter.ToUInt64(numArray, 0);
    }

    public static void smethod_15(Stream stream, ulong value)
    {
      byte[] bytes = LittleEndianBitConverter.GetBytes(value);
      stream.Write(bytes, 0, 8);
    }

    public static void smethod_16(Stream stream, double value)
    {
      byte[] bytes = LittleEndianBitConverter.GetBytes(value);
      stream.Write(bytes, 0, 8);
    }
  }
}
