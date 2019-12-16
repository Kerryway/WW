// Decompiled with JetBrains decompiler
// Type: ns35.Class955
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.IO;

namespace ns35
{
  internal class Class955
  {
    private unsafe byte*[] pByte_0 = new byte*[524288];
    private byte[] byte_0;
    private Stream stream_0;
    private unsafe byte* pByte_1;
    private unsafe byte* pByte_2;
    private unsafe byte* pByte_3;
    private bool bool_0;
    private byte byte_1;

    public void method_0(byte[] sourceData, Stream targetStream)
    {
      this.method_1(sourceData, 0, sourceData.Length, targetStream);
    }

    public unsafe void method_1(byte[] sourceData, int index, int length, Stream targetStream)
    {
      this.byte_0 = sourceData;
      this.stream_0 = targetStream;
      this.bool_0 = true;
      fixed (byte* numPtr = sourceData)
      {
        this.pByte_1 = numPtr + index;
        this.pByte_3 = this.pByte_1 + length;
        this.pByte_2 = this.pByte_1;
        this.pByte_0[(IntPtr) Class955.smethod_0(this.pByte_2)] = this.pByte_2;
        uint num1 = 1;
        ++this.pByte_2;
        while (this.pByte_2 <= this.pByte_3 - 3)
        {
          long matchOffset;
          long matchLength;
          if (!this.FindMatch(out matchOffset, out matchLength))
          {
            ++this.pByte_2;
            ++num1;
          }
          else
          {
            if (num1 > 0U)
            {
              this.method_2(num1);
              this.method_4(this.pByte_2 - (int) num1, num1);
            }
            this.method_3((uint) matchOffset, (uint) matchLength, num1);
            this.pByte_2 += matchLength;
            num1 = 0U;
          }
        }
        uint num2 = num1 + (uint) (this.pByte_3 - this.pByte_2);
        if (num2 > 0U)
        {
          this.method_2(num2);
          this.method_4(this.pByte_3 - (int) num2, num2);
        }
        this.method_38();
      }
    }

    private unsafe bool FindMatch(out long matchOffset, out long matchLength)
    {
      matchOffset = 0L;
      matchLength = 0L;
      uint num1 = Class955.smethod_0(this.pByte_2);
      int num2;
      for (num2 = 0; num2 < 4; ++num2)
      {
        byte* matchPtr = this.pByte_0[(long) num1 + (long) num2];
        if ((IntPtr) matchPtr == IntPtr.Zero || this.IsMatch(matchPtr, ref matchOffset, ref matchLength))
          break;
      }
      if (matchLength == 0L && num2 < 4)
      {
        this.pByte_0[(long) num1 + (long) num2] = this.pByte_2;
      }
      else
      {
        this.pByte_0[(IntPtr) (num1 + 3U)] = this.pByte_0[(IntPtr) (num1 + 2U)];
        this.pByte_0[(IntPtr) (num1 + 2U)] = this.pByte_0[(IntPtr) (num1 + 1U)];
        this.pByte_0[(IntPtr) (num1 + 1U)] = this.pByte_0[(IntPtr) num1];
        this.pByte_0[(IntPtr) num1] = this.pByte_2;
      }
      return matchLength != 0L;
    }

    private unsafe bool IsMatch(byte* matchPtr, ref long matchOffset, ref long matchLength)
    {
      bool flag = false;
      if ((int) matchPtr[2] == (int) this.pByte_2[2] && (int) *matchPtr == (int) *this.pByte_2 && (int) matchPtr[1] == (int) this.pByte_2[1])
      {
        long num1 = this.pByte_2 - matchPtr;
        if (num1 <= (long) ushort.MaxValue && (num1 <= 8192L || this.pByte_2 + 3 < this.pByte_3 && (int) matchPtr[3] == (int) this.pByte_2[3]))
        {
          byte* numPtr1 = this.pByte_2 + 3;
          byte* numPtr2 = numPtr1 + 65791;
          if (numPtr2 > this.pByte_3)
            numPtr2 = this.pByte_3;
          while (numPtr1 < numPtr2 && (int) *numPtr1 == (int) *(numPtr1 - num1))
            ++numPtr1;
          long num2 = numPtr1 - this.pByte_2;
          if (num2 > matchLength)
          {
            matchLength = num2;
            matchOffset = num1;
            if (matchLength > 15L)
              flag = true;
          }
        }
      }
      return flag;
    }

    private void method_2(uint literalLength)
    {
      if (literalLength <= 0U)
        throw new ArgumentException();
      if (literalLength <= 7U)
      {
        if (this.stream_0.Length == 0L)
        {
          this.method_37((byte) 32);
          this.method_37((byte) 0);
          this.method_37((byte) 0);
          this.method_37((byte) 0);
        }
        this.byte_1 |= (byte) literalLength;
      }
      else if (literalLength <= 22U)
        this.method_37((byte) (literalLength - 8U));
      else if (literalLength < 278U)
      {
        this.method_37((byte) 15);
        this.method_37((byte) (literalLength - 23U));
      }
      else
      {
        this.method_37((byte) 15);
        this.method_37(byte.MaxValue);
        uint num;
        for (num = (uint) ((int) literalLength - (int) byte.MaxValue - 23); num >= (uint) ushort.MaxValue; num -= (uint) ushort.MaxValue)
        {
          this.method_37(byte.MaxValue);
          this.method_37(byte.MaxValue);
        }
        this.method_37((byte) (num & (uint) byte.MaxValue));
        this.method_37((byte) (num >> 8 & (uint) byte.MaxValue));
      }
    }

    private void method_3(uint matchOffset, uint matchLength, uint literalLength)
    {
      if ((matchLength < 15U || matchLength == 15U && literalLength > 0U) && matchOffset < 513U)
      {
        this.method_37((byte) ((int) matchLength << 4 | (int) matchOffset - 1 & 15));
        this.method_37((byte) (matchOffset - 1U >> 1 & 248U));
      }
      else if (matchLength <= 18U && matchOffset < 8193U)
      {
        this.method_37((byte) ((int) matchLength - 3 | 16));
        this.method_37((byte) ((int) matchOffset - 1 & (int) byte.MaxValue));
        this.method_37((byte) (matchOffset - 1U >> 5 & 248U));
      }
      else if (matchLength <= 50U && matchOffset < 4097U)
      {
        if (literalLength == 0U)
          this.method_37((byte) ((int) matchLength - 3 | 240));
        else
          this.method_37((byte) ((int) matchLength - 3 & 15));
        this.method_37((byte) ((int) matchOffset - 1 & (int) byte.MaxValue));
        this.method_37((byte) ((int) matchLength + 13 << 3 & 128 | (int) (matchOffset - 1U >> 5) & 120));
      }
      else if (matchLength <= (uint) byte.MaxValue)
      {
        this.method_37((byte) ((int) matchLength & 7 | 32));
        this.method_37((byte) (matchOffset & (uint) byte.MaxValue));
        this.method_37((byte) (matchOffset >> 8 & (uint) byte.MaxValue));
        this.method_37((byte) (matchLength & 248U));
      }
      else
      {
        this.method_37((byte) ((int) matchLength & 7 | 40));
        this.method_37((byte) ((int) matchOffset - 1 & (int) byte.MaxValue));
        this.method_37((byte) (matchOffset - 1U >> 8 & (uint) byte.MaxValue));
        this.method_37((byte) (matchLength - 256U >> 3));
        this.method_37((byte) (matchLength - 256U >> 8 & 248U));
      }
    }

    private static unsafe uint smethod_0(byte* ptr)
    {
      return (uint) ((((int) *ptr | (int) ptr[1] << 8 | (int) ptr[2] << 16) & 131071) << 2);
    }

    private unsafe void method_4(byte* sourcePtr, uint length)
    {
      while (length >= 32U)
      {
        this.method_36(sourcePtr);
        length -= 32U;
        sourcePtr += 32;
      }
      switch (length)
      {
        case 1:
          this.method_5(sourcePtr);
          break;
        case 2:
          this.method_6(sourcePtr);
          break;
        case 3:
          this.method_7(sourcePtr);
          break;
        case 4:
          this.method_8(sourcePtr);
          break;
        case 5:
          this.method_9(sourcePtr);
          break;
        case 6:
          this.method_10(sourcePtr);
          break;
        case 7:
          this.method_11(sourcePtr);
          break;
        case 8:
          this.method_12(sourcePtr);
          break;
        case 9:
          this.method_13(sourcePtr);
          break;
        case 10:
          this.method_14(sourcePtr);
          break;
        case 11:
          this.method_15(sourcePtr);
          break;
        case 12:
          this.method_16(sourcePtr);
          break;
        case 13:
          this.method_17(sourcePtr);
          break;
        case 14:
          this.method_18(sourcePtr);
          break;
        case 15:
          this.method_19(sourcePtr);
          break;
        case 16:
          this.method_20(sourcePtr);
          break;
        case 17:
          this.method_21(sourcePtr);
          break;
        case 18:
          this.method_22(sourcePtr);
          break;
        case 19:
          this.method_23(sourcePtr);
          break;
        case 20:
          this.method_24(sourcePtr);
          break;
        case 21:
          this.method_25(sourcePtr);
          break;
        case 22:
          this.method_26(sourcePtr);
          break;
        case 23:
          this.method_27(sourcePtr);
          break;
        case 24:
          this.method_28(sourcePtr);
          break;
        case 25:
          this.method_29(sourcePtr);
          break;
        case 26:
          this.method_30(sourcePtr);
          break;
        case 27:
          this.method_31(sourcePtr);
          break;
        case 28:
          this.method_32(sourcePtr);
          break;
        case 29:
          this.method_33(sourcePtr);
          break;
        case 30:
          this.method_34(sourcePtr);
          break;
        case 31:
          this.method_35(sourcePtr);
          break;
      }
    }

    private unsafe void method_5(byte* sourcePtr)
    {
      this.method_37(*sourcePtr);
    }

    private unsafe void method_6(byte* sourcePtr)
    {
      this.method_37(sourcePtr[1]);
      this.method_37(*sourcePtr);
    }

    private unsafe void method_7(byte* sourcePtr)
    {
      this.method_37(sourcePtr[2]);
      this.method_37(sourcePtr[1]);
      this.method_37(*sourcePtr);
    }

    private unsafe void method_8(byte* sourcePtr)
    {
      this.method_37(*sourcePtr);
      this.method_37(sourcePtr[1]);
      this.method_37(sourcePtr[2]);
      this.method_37(sourcePtr[3]);
    }

    private unsafe void method_9(byte* sourcePtr)
    {
      this.method_8(sourcePtr + 1);
      this.method_5(sourcePtr);
    }

    private unsafe void method_10(byte* sourcePtr)
    {
      this.method_5(sourcePtr + 5);
      this.method_8(sourcePtr + 1);
      this.method_5(sourcePtr);
    }

    private unsafe void method_11(byte* sourcePtr)
    {
      this.method_5(sourcePtr + 6);
      this.method_8(sourcePtr + 2);
      this.method_6(sourcePtr);
    }

    private unsafe void method_12(byte* sourcePtr)
    {
      this.method_8(sourcePtr);
      this.method_8(sourcePtr + 4);
    }

    private unsafe void method_13(byte* sourcePtr)
    {
      this.method_12(sourcePtr + 1);
      this.method_5(sourcePtr);
    }

    private unsafe void method_14(byte* sourcePtr)
    {
      this.method_5(sourcePtr + 9);
      this.method_12(sourcePtr + 1);
      this.method_5(sourcePtr);
    }

    private unsafe void method_15(byte* sourcePtr)
    {
      this.method_5(sourcePtr + 10);
      this.method_12(sourcePtr + 2);
      this.method_6(sourcePtr);
    }

    private unsafe void method_16(byte* sourcePtr)
    {
      this.method_12(sourcePtr + 4);
      this.method_8(sourcePtr);
    }

    private unsafe void method_17(byte* sourcePtr)
    {
      this.method_12(sourcePtr + 5);
      this.method_8(sourcePtr + 1);
      this.method_5(sourcePtr);
    }

    private unsafe void method_18(byte* sourcePtr)
    {
      this.method_5(sourcePtr + 13);
      this.method_12(sourcePtr + 5);
      this.method_8(sourcePtr + 1);
      this.method_5(sourcePtr);
    }

    private unsafe void method_19(byte* sourcePtr)
    {
      this.method_5(sourcePtr + 14);
      this.method_12(sourcePtr + 6);
      this.method_8(sourcePtr + 2);
      this.method_6(sourcePtr);
    }

    private unsafe void method_20(byte* sourcePtr)
    {
      this.method_12(sourcePtr + 8);
      this.method_12(sourcePtr);
    }

    private unsafe void method_21(byte* sourcePtr)
    {
      this.method_12(sourcePtr + 9);
      this.method_5(sourcePtr + 8);
      this.method_12(sourcePtr);
    }

    private unsafe void method_22(byte* sourcePtr)
    {
      this.method_5(sourcePtr + 17);
      this.method_20(sourcePtr + 1);
      this.method_5(sourcePtr);
    }

    private unsafe void method_23(byte* sourcePtr)
    {
      this.method_20(sourcePtr + 3);
      this.method_7(sourcePtr);
    }

    private unsafe void method_24(byte* sourcePtr)
    {
      this.method_12(sourcePtr + 12);
      this.method_12(sourcePtr + 4);
      this.method_8(sourcePtr);
    }

    private unsafe void method_25(byte* sourcePtr)
    {
      this.method_12(sourcePtr + 13);
      this.method_12(sourcePtr + 5);
      this.method_8(sourcePtr + 1);
      this.method_5(sourcePtr);
    }

    private unsafe void method_26(byte* sourcePtr)
    {
      this.method_12(sourcePtr + 14);
      this.method_12(sourcePtr + 6);
      this.method_8(sourcePtr + 2);
      this.method_6(sourcePtr);
    }

    private unsafe void method_27(byte* sourcePtr)
    {
      this.method_12(sourcePtr + 15);
      this.method_12(sourcePtr + 7);
      this.method_8(sourcePtr + 3);
      this.method_7(sourcePtr);
    }

    private unsafe void method_28(byte* sourcePtr)
    {
      this.method_20(sourcePtr + 8);
      this.method_12(sourcePtr);
    }

    private unsafe void method_29(byte* sourcePtr)
    {
      this.method_20(sourcePtr + 9);
      this.method_5(sourcePtr + 8);
      this.method_12(sourcePtr);
    }

    private unsafe void method_30(byte* sourcePtr)
    {
      this.method_20(sourcePtr + 10);
      this.method_5(sourcePtr + 9);
      this.method_12(sourcePtr + 1);
      this.method_5(sourcePtr);
    }

    private unsafe void method_31(byte* sourcePtr)
    {
      this.method_20(sourcePtr + 11);
      this.method_5(sourcePtr + 10);
      this.method_12(sourcePtr + 2);
      this.method_6(sourcePtr);
    }

    private unsafe void method_32(byte* sourcePtr)
    {
      this.method_12(sourcePtr + 20);
      this.method_12(sourcePtr + 12);
      this.method_12(sourcePtr + 4);
      this.method_8(sourcePtr);
    }

    private unsafe void method_33(byte* sourcePtr)
    {
      this.method_12(sourcePtr + 21);
      this.method_12(sourcePtr + 13);
      this.method_12(sourcePtr + 5);
      this.method_8(sourcePtr + 1);
      this.method_5(sourcePtr);
    }

    private unsafe void method_34(byte* sourcePtr)
    {
      this.method_12(sourcePtr + 22);
      this.method_12(sourcePtr + 14);
      this.method_12(sourcePtr + 6);
      this.method_8(sourcePtr + 2);
      this.method_6(sourcePtr);
    }

    private unsafe void method_35(byte* sourcePtr)
    {
      this.method_6(sourcePtr + 29);
      this.method_12(sourcePtr + 21);
      this.method_12(sourcePtr + 13);
      this.method_12(sourcePtr + 5);
      this.method_8(sourcePtr + 1);
      this.method_5(sourcePtr);
    }

    private unsafe void method_36(byte* sourcePtr)
    {
      this.method_8(sourcePtr + 24);
      this.method_8(sourcePtr + 28);
      this.method_8(sourcePtr + 16);
      this.method_8(sourcePtr + 20);
      this.method_8(sourcePtr + 8);
      this.method_8(sourcePtr + 12);
      this.method_8(sourcePtr);
      this.method_8(sourcePtr + 4);
    }

    private void method_37(byte value)
    {
      if (this.bool_0)
        this.bool_0 = false;
      else
        this.stream_0.WriteByte(this.byte_1);
      this.byte_1 = value;
    }

    private void method_38()
    {
      this.stream_0.WriteByte(this.byte_1);
      this.bool_0 = true;
    }
  }
}
