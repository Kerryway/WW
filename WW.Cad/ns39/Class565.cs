// Decompiled with JetBrains decompiler
// Type: ns39.Class565
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.IO;

namespace ns39
{
  internal class Class565
  {
    private unsafe byte*[] pByte_0 = new byte*[32768];
    private byte[] byte_0;
    private Stream stream_0;
    private unsafe byte* pByte_1;
    private unsafe byte* pByte_2;
    private unsafe byte* pByte_3;
    private unsafe byte* pByte_4;

    public void method_0(byte[] sourceData, Stream targetStream)
    {
      this.method_1(sourceData, 0, sourceData.Length, targetStream);
    }

    public unsafe void method_1(byte[] sourceData, int index, int length, Stream targetStream)
    {
      this.byte_0 = sourceData;
      this.stream_0 = targetStream;
      fixed (byte* numPtr = sourceData)
      {
        this.pByte_1 = numPtr + index;
        this.pByte_4 = this.pByte_1 + length;
        this.pByte_3 = this.pByte_1;
        this.pByte_2 = this.pByte_1 + 4;
        int length1 = 0;
        int offset = 0;
        int matchLength = 0;
        int matchOffset = 0;
        while (this.pByte_2 < this.pByte_4 - 19)
        {
          if (!this.FindMatch(ref matchLength, ref matchOffset))
          {
            ++this.pByte_2;
          }
          else
          {
            int litLength = (int) (this.pByte_2 - this.pByte_3);
            if (length1 != 0)
              this.method_5(offset, length1, litLength);
            this.method_4(litLength);
            this.pByte_2 += matchLength;
            this.pByte_3 = this.pByte_2;
            length1 = matchLength;
            offset = matchOffset;
          }
        }
        int litLength1 = (int) (this.pByte_4 - this.pByte_3);
        if (length1 != 0)
          this.method_5(offset, length1, litLength1);
        this.method_4(litLength1);
        targetStream.WriteByte((byte) 17);
        targetStream.WriteByte((byte) 0);
        targetStream.WriteByte((byte) 0);
      }
    }

    private static int smethod_0(byte val0, byte val1, byte val2, byte val3)
    {
      int num = (((int) val3 << 6 ^ (int) val2) << 5 ^ (int) val1) << 5 ^ (int) val0;
      return num + (num >> 5) & (int) short.MaxValue;
    }

    private void method_2(int val)
    {
      if (val <= 0)
        throw new ArgumentException(nameof (val));
      while (val > (int) byte.MaxValue)
      {
        val -= (int) byte.MaxValue;
        this.stream_0.WriteByte((byte) 0);
      }
      this.stream_0.WriteByte((byte) val);
    }

    private void method_3(int opcode, int length, int threshold)
    {
      if (length <= 0)
        throw new ArgumentException(nameof (length));
      if (threshold <= 0)
        throw new ArgumentException(nameof (threshold));
      if (length <= threshold)
      {
        opcode |= length - 2;
        this.stream_0.WriteByte((byte) opcode);
      }
      else
      {
        this.stream_0.WriteByte((byte) opcode);
        this.method_2(length - threshold);
      }
    }

    private unsafe void method_4(int litLength)
    {
      if (litLength <= 0)
        return;
      if (litLength > 3)
        this.method_3(0, litLength - 1, 17);
      byte* pByte3 = this.pByte_3;
      for (int index = 0; index < litLength; ++index)
      {
        this.stream_0.WriteByte(*pByte3);
        ++pByte3;
      }
    }

    private void method_5(int offset, int length, int litLength)
    {
      int num1;
      int num2;
      if (length < 15 && offset <= 1024)
      {
        --offset;
        num1 = length + 1 << 4 | (offset & 3) << 2;
        num2 = offset >> 2;
      }
      else
      {
        if (offset <= 16384)
        {
          --offset;
          this.method_3(32, length, 33);
        }
        else
        {
          offset -= 16384;
          this.method_3(16 | offset >> 11 & 8, length, 9);
        }
        num1 = (offset & (int) byte.MaxValue) << 2;
        num2 = offset >> 6;
      }
      if (litLength < 4)
        num1 |= litLength;
      this.stream_0.WriteByte((byte) num1);
      this.stream_0.WriteByte((byte) num2);
    }

    private unsafe bool FindMatch(ref int matchLength, ref int matchOffset)
    {
      matchLength = 0;
      byte val0 = *this.pByte_2;
      byte val1 = this.pByte_2[1];
      byte val2 = this.pByte_2[2];
      byte val3 = this.pByte_2[3];
      int index = Class565.smethod_0(val0, val1, val2, val3);
      byte* numPtr1 = this.pByte_0[index];
      matchOffset = (int) (this.pByte_2 - numPtr1);
      if (numPtr1 >= this.pByte_1 && matchOffset <= 49151)
      {
        if (matchOffset > 1024 && (int) val3 != (int) numPtr1[3])
        {
          index = index & 2047 ^ 16415;
          numPtr1 = this.pByte_0[index];
          matchOffset = (int) (this.pByte_2 - numPtr1);
          if (numPtr1 < this.pByte_1 || matchOffset > 49151 || matchOffset > 1024 && (int) val3 != (int) numPtr1[3])
          {
            this.pByte_0[index] = this.pByte_2;
            return false;
          }
        }
        if ((int) val0 == (int) *numPtr1 && (int) val1 == (int) numPtr1[1] && (int) val2 == (int) numPtr1[2])
        {
          matchLength = 3;
          byte* numPtr2 = numPtr1 + 3;
          byte* numPtr3 = this.pByte_2 + 3;
          while (numPtr3 < this.pByte_4 && (int) *numPtr2++ == (int) *numPtr3++)
            ++matchLength;
        }
      }
      this.pByte_0[index] = this.pByte_2;
      return matchLength >= 3;
    }
  }
}
