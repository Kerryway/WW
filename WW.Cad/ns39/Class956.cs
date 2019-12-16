// Decompiled with JetBrains decompiler
// Type: ns39.Class956
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;

namespace ns39
{
  internal class Class956
  {
    public static Stream smethod_0(Stream compressedStream, long decompressedSize)
    {
      MemoryStream memoryStream = new MemoryStream(new byte[decompressedSize]);
      Class956.smethod_2(compressedStream, (Stream) memoryStream);
      memoryStream.Position = 0L;
      return (Stream) memoryStream;
    }

    public static long smethod_1(
      Stream compressedStream,
      Stream decompressedStream,
      long startIndex)
    {
      long num1 = startIndex;
label_31:
      byte num2 = (byte) compressedStream.ReadByte();
      if (num2 != (byte) 17)
      {
        int num3;
        int num4;
        int num5;
        if (num2 <= (byte) 15)
        {
          num3 = 0;
          num4 = 0;
          if (num2 == (byte) 0)
          {
            int num6 = 18;
            byte num7;
            for (num7 = (byte) compressedStream.ReadByte(); num7 == (byte) 0; num7 = (byte) compressedStream.ReadByte())
              num6 += (int) byte.MaxValue;
            num5 = num6 + (int) num7;
          }
          else
            num5 = (int) num2 + 3;
        }
        else if (num2 <= (byte) 31)
        {
          if (num2 == (byte) 16)
          {
            int num6 = 9;
            byte num7;
            for (num7 = (byte) compressedStream.ReadByte(); num7 == (byte) 0; num7 = (byte) compressedStream.ReadByte())
              num6 += (int) byte.MaxValue;
            num4 = num6 + (int) num7;
          }
          else
            num4 = ((int) num2 & 15) + 2;
          num3 = compressedStream.ReadByte() + compressedStream.ReadByte() * 256 + 65536 - 4;
          num5 = num3 & 3;
        }
        else if (num2 <= (byte) 63)
        {
          if (num2 == (byte) 32)
          {
            int num6 = 33;
            byte num7;
            for (num7 = (byte) compressedStream.ReadByte(); num7 == (byte) 0; num7 = (byte) compressedStream.ReadByte())
              num6 += (int) byte.MaxValue;
            num4 = num6 + (int) num7;
          }
          else
            num4 = ((int) num2 & 31) + 2;
          num3 = compressedStream.ReadByte() + compressedStream.ReadByte() * 256;
          num5 = num3 & 3;
        }
        else
        {
          num4 = ((int) num2 >> 4) - 1;
          num3 = (compressedStream.ReadByte() << 4) + ((int) num2 & 15);
          num5 = num3 & 3;
        }
        int num8 = (num3 >> 2) + 1;
        long num9 = num1 - (long) num8;
        for (int index = 0; index < num4; ++index)
        {
          decompressedStream.Position = num9++;
          byte num6 = (byte) decompressedStream.ReadByte();
          decompressedStream.Position = num1++;
          decompressedStream.WriteByte(num6);
        }
        for (int index = 0; index < num5; ++index)
        {
          decompressedStream.WriteByte((byte) compressedStream.ReadByte());
          ++num1;
        }
        goto label_31;
      }
      else
      {
        compressedStream.ReadByte();
        compressedStream.ReadByte();
        return num1;
      }
    }

    public static void smethod_2(Stream inputStream, Stream decompressedStream)
    {
      int opcode1 = (int) (byte) inputStream.ReadByte();
      if ((opcode1 & 240) == 0)
        opcode1 = (int) Class956.smethod_3(Class956.smethod_4(opcode1, inputStream) + 3, inputStream, decompressedStream);
      while (opcode1 != 17)
      {
        int offset = 0;
        int num1 = 0;
        if (opcode1 >= 16 && opcode1 < 64)
        {
          if (opcode1 < 32)
          {
            num1 = Class956.smethod_5(opcode1, 7, inputStream);
            offset = (opcode1 & 8) << 11;
            opcode1 = Class956.smethod_6(ref offset, 16384, inputStream);
          }
          else if (opcode1 >= 32)
          {
            num1 = Class956.smethod_5(opcode1, 31, inputStream);
            opcode1 = Class956.smethod_6(ref offset, 1, inputStream);
          }
        }
        else
        {
          int num2 = (int) (byte) inputStream.ReadByte();
          offset = (opcode1 >> 2 & 3 | num2 << 2) + 1;
          num1 = (opcode1 >> 4) - 1;
        }
        long position = decompressedStream.Position;
        for (long index = (long) num1 + position; position < index; ++position)
        {
          decompressedStream.Position = position - (long) offset;
          byte num2 = (byte) decompressedStream.ReadByte();
          decompressedStream.Position = position;
          decompressedStream.WriteByte(num2);
        }
        int litLength = opcode1 & 3;
        if (litLength == 0)
        {
          opcode1 = (int) (byte) inputStream.ReadByte();
          if ((opcode1 & 240) == 0)
            litLength = Class956.smethod_4(opcode1, inputStream) + 3;
        }
        if (litLength != 0)
          opcode1 = (int) Class956.smethod_3(litLength, inputStream, decompressedStream);
      }
      inputStream.ReadByte();
      inputStream.ReadByte();
    }

    private static byte smethod_3(int litLength, Stream inputStream, Stream decompressedStream)
    {
      for (int index = 0; index < litLength; ++index)
      {
        byte num = (byte) inputStream.ReadByte();
        decompressedStream.WriteByte(num);
      }
      return (byte) inputStream.ReadByte();
    }

    private static int smethod_4(int opcode1, Stream inputStream)
    {
      int num1 = opcode1 & 15;
      if (num1 == 0)
      {
        byte num2;
        for (num2 = (byte) inputStream.ReadByte(); num2 == (byte) 0; num2 = (byte) inputStream.ReadByte())
          num1 += (int) byte.MaxValue;
        num1 += 15 + (int) num2;
      }
      return num1;
    }

    private static int smethod_5(int opcode1, int mask, Stream inputStream)
    {
      int num1 = opcode1 & mask;
      if (num1 == 0)
      {
        byte num2;
        for (num2 = (byte) inputStream.ReadByte(); num2 == (byte) 0; num2 = (byte) inputStream.ReadByte())
          num1 += (int) byte.MaxValue;
        num1 += (int) num2 + mask;
      }
      return num1 + 2;
    }

    private static int smethod_6(ref int offset, int add, Stream inputStream)
    {
      int num1 = inputStream.ReadByte();
      int num2 = inputStream.ReadByte();
      offset |= num1 >> 2;
      offset |= num2 << 6;
      offset += add;
      return num1;
    }
  }
}
