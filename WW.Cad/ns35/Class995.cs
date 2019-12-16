// Decompiled with JetBrains decompiler
// Type: ns35.Class995
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System;
using System.IO;
using WW;

namespace ns35
{
  internal class Class995
  {
    private ulong ulong_0;
    private uint uint_0;
    private uint[] uint_1;
    private byte[] byte_0;

    public Class995()
    {
      Random random = new Random();
      byte[] numArray = new byte[8];
      random.NextBytes(numArray);
      this.method_0(LittleEndianBitConverter.ToUInt64(numArray));
    }

    public Class995(ulong seed)
    {
      this.method_0(seed);
    }

    public ulong Seed
    {
      get
      {
        return this.ulong_0;
      }
    }

    public byte[] Padding
    {
      get
      {
        return this.byte_0;
      }
    }

    public void method_0(ulong seed)
    {
      this.uint_1 = new uint[624];
      this.ulong_0 = seed;
      this.uint_0 = 0U;
      this.uint_1[0] = (uint) ((int) (uint) seed * 214013 + 2531011);
      this.uint_1[1] = (uint) ((int) (uint) (seed >> 32) * 214013 + 2531011);
      uint num = this.uint_1[1];
      this.uint_1[0] = Class1047.smethod_0(this.uint_1[0]);
      this.uint_1[1] = Class1047.smethod_0(this.uint_1[1]);
      for (uint index = 2; index < 624U; ++index)
      {
        num = (uint) (((int) (num >> 30) ^ (int) num) * 1812433253) + index;
        this.uint_1[(IntPtr) index] = Class1047.smethod_0(num);
      }
      this.method_4();
    }

    public ulong method_1()
    {
      this.uint_0 += 2U;
      this.method_5();
      return (ulong) Class1047.smethod_1(this.uint_1[(IntPtr) this.uint_0]) | (ulong) Class1047.smethod_1(this.uint_1[(IntPtr) (this.uint_0 + 1U)]) << 32;
    }

    public ulong method_2(uint value)
    {
      ulong num1 = this.method_1();
      uint num2 = (uint) (num1 & 3749574623UL);
      uint num3 = (uint) (num1 >> 32 & 4158619127UL);
      if (((int) value & 512) != 0)
        num2 |= 32U;
      if (((int) value & 256) != 0)
        num2 |= 2048U;
      if (((int) value & 128) != 0)
        num2 |= 131072U;
      if (((int) value & 64) != 0)
        num2 |= 8388608U;
      if (((int) value & 32) != 0)
        num2 |= 536870912U;
      if (((int) value & 16) != 0)
        num3 |= 8U;
      if (((int) value & 8) != 0)
        num3 |= 512U;
      if (((int) value & 4) != 0)
        num3 |= 32768U;
      if (((int) value & 2) != 0)
        num3 |= 2097152U;
      if (((int) value & 1) != 0)
        num3 |= 134217728U;
      return (ulong) num2 | (ulong) num3 << 32;
    }

    public uint method_3(ulong value)
    {
      uint num1 = 0;
      uint num2 = (uint) (value >> 32);
      if (((int) num2 & 134217728) != 0)
        num1 |= 1U;
      if (((int) num2 & 2097152) != 0)
        num1 |= 2U;
      if (((int) num2 & 32768) != 0)
        num1 |= 4U;
      if (((int) num2 & 512) != 0)
        num1 |= 8U;
      if (((int) num2 & 8) != 0)
        num1 |= 16U;
      uint num3 = (uint) value;
      if (((int) num3 & 536870912) != 0)
        num1 |= 32U;
      if (((int) num3 & 8388608) != 0)
        num1 |= 64U;
      if (((int) num3 & 131072) != 0)
        num1 |= 128U;
      if (((int) num3 & 2048) != 0)
        num1 |= 256U;
      if (((int) num3 & 32) != 0)
        num1 |= 512U;
      return num1;
    }

    private void method_4()
    {
      this.byte_0 = new byte[512];
      using (MemoryStream memoryStream = new MemoryStream(this.byte_0, true))
      {
        for (int index = 0; index < 128; ++index)
        {
          this.method_5();
          Class1047.Write((Stream) memoryStream, this.uint_1[(IntPtr) this.uint_0]);
          ++this.uint_0;
        }
      }
    }

    private void method_5()
    {
      if (this.uint_0 < 624U)
        return;
      this.uint_0 = 0U;
    }
  }
}
