// Decompiled with JetBrains decompiler
// Type: ns7.Class44
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace ns7
{
  internal class Class44
  {
    private readonly byte[] byte_0 = new byte[256];
    private int int_0;
    private int int_1;

    internal Class44()
    {
    }

    internal Class44(byte[] key)
    {
      this.method_0(key);
    }

    internal Class44(byte[] key, int offset, int length)
    {
      byte[] key1 = new byte[length];
      for (int index = 0; index < length; ++index)
        key1[index] = key[offset + index];
      this.method_0(key1);
    }

    internal void method_0(byte[] key)
    {
      for (int index = 0; index < 256; ++index)
        this.byte_0[index] = (byte) index;
      int index1 = 0;
      int index2 = 0;
      for (; index1 < 256; ++index1)
      {
        index2 = (index2 + (int) this.byte_0[index1] + (int) key[index1 % key.Length]) % 256;
        byte num = this.byte_0[index1];
        this.byte_0[index1] = this.byte_0[index2];
        this.byte_0[index2] = num;
      }
      this.int_0 = 0;
      this.int_1 = 0;
    }

    internal void method_1(byte[] dataIn, byte[] dataOut)
    {
      for (int index = 0; index < dataIn.Length; ++index)
        dataOut[index] = (byte) ((uint) dataIn[index] ^ (uint) this.method_2());
    }

    private byte method_2()
    {
      this.int_0 = (this.int_0 + 1) % 256;
      this.int_1 = (this.int_1 + (int) this.byte_0[this.int_0]) % 256;
      byte num = this.byte_0[this.int_0];
      this.byte_0[this.int_0] = this.byte_0[this.int_1];
      this.byte_0[this.int_1] = num;
      return this.byte_0[((int) this.byte_0[this.int_0] + (int) this.byte_0[this.int_1]) % 256];
    }
  }
}
