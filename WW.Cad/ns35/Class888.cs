// Decompiled with JetBrains decompiler
// Type: ns35.Class888
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System.IO;
using WW;

namespace ns35
{
  internal class Class888
  {
    private ulong ulong_0;
    private ulong ulong_1;
    private ulong ulong_2;
    private ulong ulong_3;
    private ulong ulong_4;

    public ulong NormalCrc
    {
      get
      {
        return this.ulong_0;
      }
    }

    public ulong MirroredCrc
    {
      get
      {
        return this.ulong_1;
      }
    }

    public ulong Random1
    {
      get
      {
        return this.ulong_2;
      }
    }

    public ulong Random2
    {
      get
      {
        return this.ulong_3;
      }
    }

    public ulong EncodedCrcSeed
    {
      get
      {
        return this.ulong_4;
      }
    }

    public void method_0(ulong crcSeed, Class995 encoding)
    {
      this.ulong_2 = encoding.method_1();
      this.ulong_3 = encoding.method_1();
      this.ulong_4 = encoding.method_2((uint) (crcSeed & (ulong) ushort.MaxValue));
      this.method_1();
      this.method_2();
    }

    public void Write(Stream stream)
    {
      stream.Write(LittleEndianBitConverter.GetBytes(this.ulong_0), 0, 8);
      stream.Write(LittleEndianBitConverter.GetBytes(this.ulong_1), 0, 8);
      stream.Write(LittleEndianBitConverter.GetBytes(this.ulong_2), 0, 8);
      stream.Write(LittleEndianBitConverter.GetBytes(this.ulong_3), 0, 8);
      stream.Write(LittleEndianBitConverter.GetBytes(this.ulong_4), 0, 8);
    }

    private void method_1()
    {
      ulong[] numArray = new ulong[8];
      numArray[0] = Class888.smethod_0(this.ulong_2, this.ulong_3);
      numArray[1] = Class888.smethod_0(numArray[0], numArray[0]);
      numArray[2] = Class888.smethod_0(this.ulong_3, numArray[1]);
      numArray[3] = Class888.smethod_0(numArray[2], numArray[2]);
      numArray[4] = Class888.smethod_0(this.ulong_2, numArray[3]);
      numArray[5] = Class888.smethod_0(numArray[4], numArray[4]);
      numArray[6] = Class888.smethod_0(numArray[5], numArray[5]);
      numArray[7] = Class888.smethod_0(numArray[6], numArray[6]);
      MemoryStream memoryStream = new MemoryStream(64);
      for (int index = 0; index < 8; ++index)
        Class1047.Write((Stream) memoryStream, numArray[index]);
      this.ulong_0 = Class656.class656_0.method_0(memoryStream.GetBuffer(), 0U, 64U, ~this.ulong_3);
    }

    private void method_2()
    {
      ulong[] numArray = new ulong[8];
      numArray[0] = Class888.smethod_0(this.ulong_2, this.ulong_3);
      numArray[1] = Class888.smethod_0(this.ulong_0, numArray[0]);
      numArray[2] = Class888.smethod_0(this.ulong_3, numArray[1]);
      numArray[3] = Class888.smethod_0(this.ulong_0, numArray[2]);
      numArray[4] = Class888.smethod_0(this.ulong_2, numArray[3]);
      numArray[5] = Class888.smethod_0(this.ulong_0, numArray[4]);
      numArray[6] = Class888.smethod_0(this.ulong_3, numArray[5]);
      numArray[7] = Class888.smethod_0(numArray[6], numArray[6]);
      MemoryStream memoryStream = new MemoryStream(64);
      for (int index = 0; index < 8; ++index)
        Class1047.Write((Stream) memoryStream, numArray[index]);
      this.ulong_1 = Class656.class656_1.method_0(memoryStream.GetBuffer(), 0U, 64U, ~this.ulong_2);
    }

    public static ulong smethod_0(ulong value, ulong control)
    {
      int num = (int) ((long) control & 31L);
      if (num != 0)
        value = value << num | value >> 64 - num;
      return value;
    }
  }
}
