// Decompiled with JetBrains decompiler
// Type: ns35.Class746
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace ns35
{
  internal class Class746
  {
    public static readonly byte[] byte_1 = new byte[8]{ (byte) 1, (byte) 0, (byte) 0, (byte) 1, (byte) 0, (byte) 1, (byte) 1, (byte) 0 };
    public static readonly byte[] byte_2 = new byte[8]{ (byte) 1, (byte) 0, (byte) 1, (byte) 1, (byte) 1, (byte) 0, (byte) 0, (byte) 0 };
    public static readonly Class746 class746_0 = new Class746(Class746.byte_1, 8U, 8U);
    public static readonly Class746 class746_1 = new Class746(Class746.byte_2, 8U, 2U);
    private uint uint_3 = 8;
    private uint uint_0;
    private uint uint_1;
    private uint uint_2;
    private byte[] byte_0;
    private uint[] uint_4;
    private uint[] uint_5;
    private uint[] uint_6;

    public Class746(byte[] primitivePolynomialCoefficients, uint m, uint t)
    {
      this.byte_0 = primitivePolynomialCoefficients;
      this.uint_3 = m;
      this.uint_0 = (uint) ((1 << (int) m) - 1);
      this.uint_2 = t;
      this.uint_1 = this.uint_0 - 2U * this.uint_2;
      this.uint_4 = new uint[(IntPtr) (this.uint_0 + 1U)];
      this.uint_5 = new uint[(IntPtr) (this.uint_0 + 1U)];
      this.uint_6 = new uint[(IntPtr) (uint) ((int) this.uint_0 - (int) this.uint_1 + 1)];
      this.method_3();
      this.method_4();
    }

    public uint N
    {
      get
      {
        return this.uint_0;
      }
    }

    public uint K
    {
      get
      {
        return this.uint_1;
      }
    }

    public unsafe byte[] method_0(byte[] data, int offset)
    {
      byte[] numArray = new byte[(IntPtr) (this.uint_0 - this.uint_1)];
      fixed (byte* parityBytesPtr = numArray)
        fixed (byte* numPtr = data)
          this.method_1(numPtr + offset, parityBytesPtr);
      return numArray;
    }

    public unsafe void method_1(byte* dataPtr, byte* parityBytesPtr)
    {
      dataPtr += (int) this.uint_1 - 1;
      int num1 = (int) this.uint_1 - 1;
      while (num1 >= 0)
      {
        uint num2 = this.uint_5[(int) *dataPtr ^ (int) parityBytesPtr[(int) this.uint_0 - (int) this.uint_1 - 1]];
        if (num2 != uint.MaxValue)
        {
          for (int index = (int) this.uint_0 - (int) this.uint_1 - 1; index > 0; --index)
            parityBytesPtr[index] = (byte) ((uint) parityBytesPtr[index - 1] ^ this.uint_4[(IntPtr) ((this.uint_6[index] + num2) % this.uint_0)]);
          *parityBytesPtr = (byte) this.uint_4[(IntPtr) ((this.uint_6[0] + num2) % this.uint_0)];
        }
        else
        {
          for (int index = (int) this.uint_0 - (int) this.uint_1 - 1; index > 0; --index)
            parityBytesPtr[index] = parityBytesPtr[index - 1];
          *parityBytesPtr = (byte) 0;
        }
        --num1;
        --dataPtr;
      }
    }

    public void method_2(byte[] bytes)
    {
      uint[] numArray1 = new uint[bytes.Length];
      for (int index = 0; (long) index < (long) this.uint_0; ++index)
        numArray1[index] = this.uint_5[(int) bytes[index]];
      int[,] numArray2 = new int[(int) (IntPtr) (uint) ((int) this.uint_0 - (int) this.uint_1 + 2), (int) (IntPtr) (this.uint_0 - this.uint_1)];
      int[] numArray3 = new int[(IntPtr) (uint) ((int) this.uint_0 - (int) this.uint_1 + 2)];
      int[] numArray4 = new int[(IntPtr) (uint) ((int) this.uint_0 - (int) this.uint_1 + 2)];
      int[] numArray5 = new int[(IntPtr) (uint) ((int) this.uint_0 - (int) this.uint_1 + 2)];
      int[] numArray6 = new int[(IntPtr) (uint) ((int) this.uint_0 - (int) this.uint_1 + 1)];
      bool flag = false;
      int[] numArray7 = new int[(IntPtr) this.uint_2];
      int[] numArray8 = new int[(IntPtr) this.uint_2];
      int[] numArray9 = new int[(IntPtr) (this.uint_2 + 1U)];
      int[] numArray10 = new int[(IntPtr) this.uint_0];
      int[] numArray11 = new int[(IntPtr) (this.uint_2 + 1U)];
      for (int index1 = 1; (long) index1 <= (long) (this.uint_0 - this.uint_1); ++index1)
      {
        numArray6[index1] = 0;
        for (int index2 = 0; (long) index2 < (long) this.uint_0; ++index2)
        {
          if (numArray1[index2] != uint.MaxValue)
            numArray6[index1] ^= (int) this.uint_4[((long) numArray1[index2] + (long) (index1 * index2)) % (long) this.uint_0];
        }
        if (numArray6[index1] != 0)
          flag = true;
        numArray6[index1] = (int) this.uint_5[numArray6[index1]];
      }
      if (flag)
      {
        numArray3[0] = 0;
        numArray3[1] = numArray6[1];
        numArray2[0, 0] = 0;
        numArray2[1, 0] = 1;
        for (int index = 1; (long) index < (long) (this.uint_0 - this.uint_1); ++index)
        {
          numArray2[0, index] = -1;
          numArray2[1, index] = 0;
        }
        numArray4[0] = 0;
        numArray4[1] = 0;
        numArray5[0] = -1;
        numArray5[1] = 0;
        int index1 = 0;
        do
        {
          ++index1;
          if (numArray3[index1] != -1)
          {
            int index2 = index1 - 1;
            while (numArray3[index2] == -1 && index2 > 0)
              --index2;
            if (index2 > 0)
            {
              int index3 = index2;
              do
              {
                --index3;
                if (numArray3[index3] != -1 && numArray5[index2] < numArray5[index3])
                  goto label_24;
label_23:
                continue;
label_24:
                index2 = index3;
                goto label_23;
              }
              while (index3 > 0);
            }
            numArray4[index1 + 1] = numArray4[index1] <= numArray4[index2] + index1 - index2 ? numArray4[index2] + index1 - index2 : numArray4[index1];
            for (int index3 = 0; (long) index3 < (long) (this.uint_0 - this.uint_1); ++index3)
              numArray2[index1 + 1, index3] = 0;
            for (int index3 = 0; index3 <= numArray4[index2]; ++index3)
            {
              if (numArray2[index2, index3] != -1)
                numArray2[index1 + 1, index3 + index1 - index2] = (int) this.uint_4[((long) numArray3[index1] + (long) this.uint_0 - (long) numArray3[index2] + (long) numArray2[index2, index3]) % (long) this.uint_0];
            }
            for (int index3 = 0; index3 <= numArray4[index1]; ++index3)
            {
              numArray2[index1 + 1, index3] ^= numArray2[index1, index3];
              numArray2[index1, index3] = (int) this.uint_5[numArray2[index1, index3]];
            }
          }
          else
            goto label_45;
label_37:
          numArray5[index1 + 1] = index1 - numArray4[index1 + 1];
          if ((long) index1 < (long) (this.uint_0 - this.uint_1))
          {
            numArray3[index1 + 1] = numArray6[index1 + 1] == -1 ? 0 : (int) this.uint_4[numArray6[index1 + 1]];
            for (int index2 = 1; index2 <= numArray4[index1 + 1]; ++index2)
            {
              if (numArray6[index1 + 1 - index2] != -1 && numArray2[index1 + 1, index2] != 0)
                numArray3[index1 + 1] ^= (int) this.uint_4[((long) numArray6[index1 + 1 - index2] + (long) this.uint_5[numArray2[index1 + 1, index2]]) % (long) this.uint_0];
            }
            numArray3[index1 + 1] = (int) this.uint_5[numArray3[index1 + 1]];
          }
          continue;
label_45:
          numArray4[index1 + 1] = numArray4[index1];
          for (int index2 = 0; index2 <= numArray4[index1]; ++index2)
          {
            numArray2[index1 + 1, index2] = numArray2[index1, index2];
            numArray2[index1, index2] = (int) this.uint_5[numArray2[index1, index2]];
          }
          goto label_37;
        }
        while ((long) index1 < (long) (this.uint_0 - this.uint_1) && (long) numArray4[index1 + 1] <= (long) this.uint_2);
        int index4 = index1 + 1;
        if ((long) numArray4[index4] <= (long) this.uint_2)
        {
          for (int index2 = 0; index2 <= numArray4[index4]; ++index2)
            numArray2[index4, index2] = (int) this.uint_5[numArray2[index4, index2]];
          for (int index2 = 1; index2 <= numArray4[index4]; ++index2)
            numArray11[index2] = numArray2[index4, index2];
          int index3 = 0;
          for (int index2 = 1; (long) index2 <= (long) this.uint_0; ++index2)
          {
            int num = 1;
            for (int index5 = 1; index5 <= numArray4[index4]; ++index5)
            {
              if (numArray11[index5] != -1)
              {
                numArray11[index5] = (int) ((long) (numArray11[index5] + index5) % (long) this.uint_0);
                num ^= (int) this.uint_4[numArray11[index5]];
              }
            }
            if (num == 0)
            {
              numArray7[index3] = index2;
              numArray8[index3] = (int) ((long) this.uint_0 - (long) index2);
              ++index3;
            }
          }
          if (index3 == numArray4[index4])
          {
            for (int index2 = 1; index2 <= numArray4[index4]; ++index2)
            {
              numArray9[index2] = numArray6[index2] == -1 || numArray2[index4, index2] == -1 ? (numArray6[index2] == -1 || numArray2[index4, index2] != -1 ? (numArray6[index2] != -1 || numArray2[index4, index2] == -1 ? 0 : (int) this.uint_4[numArray2[index4, index2]]) : (int) this.uint_4[numArray6[index2]]) : (int) this.uint_4[numArray6[index2]] ^ (int) this.uint_4[numArray2[index4, index2]];
              for (int index5 = 1; index5 < index2; ++index5)
              {
                if (numArray6[index5] != -1 && numArray2[index4, index2 - index5] != -1)
                  numArray9[index2] ^= (int) this.uint_4[(long) (numArray2[index4, index2 - index5] + numArray6[index5]) % (long) this.uint_0];
              }
              numArray9[index2] = (int) this.uint_5[numArray9[index2]];
            }
            for (int index2 = 0; (long) index2 < (long) this.uint_0; ++index2)
            {
              numArray10[index2] = 0;
              numArray1[index2] = numArray1[index2] == uint.MaxValue ? 0U : (uint) (byte) this.uint_4[(IntPtr) numArray1[index2]];
            }
            for (int index2 = 0; index2 < numArray4[index4]; ++index2)
            {
              numArray10[numArray8[index2]] = 1;
              for (int index5 = 1; index5 <= numArray4[index4]; ++index5)
              {
                if (numArray9[index5] != -1)
                  numArray10[numArray8[index2]] ^= (int) this.uint_4[(long) (numArray9[index5] + index5 * numArray7[index2]) % (long) this.uint_0];
              }
              if (numArray10[numArray8[index2]] != 0)
              {
                numArray10[numArray8[index2]] = (int) this.uint_5[numArray10[numArray8[index2]]];
                int num1 = 0;
                for (int index5 = 0; index5 < numArray4[index4]; ++index5)
                {
                  if (index5 != index2)
                    num1 += (int) this.uint_5[(IntPtr) (1U ^ this.uint_4[(long) (numArray8[index5] + numArray7[index2]) % (long) this.uint_0])];
                }
                int num2 = num1 % (int) this.uint_0;
                numArray10[numArray8[index2]] = (int) this.uint_4[((long) (numArray10[numArray8[index2]] - num2) + (long) this.uint_0) % (long) this.uint_0];
                numArray1[numArray8[index2]] ^= (uint) (byte) numArray10[numArray8[index2]];
              }
            }
          }
          else
          {
            for (int index2 = 0; (long) index2 < (long) this.uint_0; ++index2)
              numArray1[index2] = numArray1[index2] == uint.MaxValue ? 0U : (uint) (byte) this.uint_4[(IntPtr) numArray1[index2]];
          }
        }
        else
        {
          for (int index2 = 0; (long) index2 < (long) this.uint_0; ++index2)
            numArray1[index2] = numArray1[index2] == uint.MaxValue ? 0U : (uint) (byte) this.uint_4[(IntPtr) numArray1[index2]];
        }
      }
      else
      {
        for (int index = 0; (long) index < (long) this.uint_0; ++index)
          numArray1[index] = numArray1[index] == uint.MaxValue ? 0U : (uint) (byte) this.uint_4[(IntPtr) numArray1[index]];
      }
      for (int index = 0; (long) index < (long) this.uint_0; ++index)
        bytes[index] = (byte) numArray1[index];
    }

    private void method_3()
    {
      uint num1 = 1;
      this.uint_4[(IntPtr) this.uint_3] = 0U;
      for (uint index = 0; index < this.uint_3; ++index)
      {
        this.uint_4[(IntPtr) index] = num1;
        this.uint_5[(IntPtr) num1] = index;
        if (this.byte_0[(IntPtr) index] != (byte) 0)
          this.uint_4[(IntPtr) this.uint_3] ^= num1;
        num1 <<= 1;
      }
      this.uint_5[(IntPtr) this.uint_4[(IntPtr) this.uint_3]] = this.uint_3;
      uint num2 = num1 >> 1;
      for (uint index = this.uint_3 + 1U; index < this.uint_0; ++index)
      {
        uint num3 = this.uint_4[(IntPtr) (index - 1U)];
        uint num4;
        if (num3 >= num2)
        {
          num4 = this.uint_4[(IntPtr) this.uint_3] ^ (uint) (((int) num3 ^ (int) num2) << 1);
          this.uint_4[(IntPtr) index] = num4;
        }
        else
        {
          num4 = num3 << 1;
          this.uint_4[(IntPtr) index] = num4;
        }
        this.uint_5[(IntPtr) num4] = index;
      }
      this.uint_5[0] = uint.MaxValue;
    }

    private void method_4()
    {
      this.uint_6[0] = 2U;
      this.uint_6[1] = 1U;
      for (uint index1 = 2; index1 <= this.uint_0 - this.uint_1; ++index1)
      {
        this.uint_6[(IntPtr) index1] = 1U;
        for (uint index2 = index1 - 1U; index2 > 0U; --index2)
          this.uint_6[(IntPtr) index2] = this.uint_6[(IntPtr) index2] == 0U ? this.uint_6[(IntPtr) (index2 - 1U)] : this.uint_6[(IntPtr) (index2 - 1U)] ^ this.uint_4[(IntPtr) ((this.uint_5[(IntPtr) this.uint_6[(IntPtr) index2]] + index1) % this.uint_0)];
        this.uint_6[0] = this.uint_4[(IntPtr) ((this.uint_5[(IntPtr) this.uint_6[0]] + index1) % this.uint_0)];
      }
      for (uint index = 0; index <= this.uint_0 - this.uint_1; ++index)
        this.uint_6[(IntPtr) index] = this.uint_5[(IntPtr) this.uint_6[(IntPtr) index]];
    }
  }
}
