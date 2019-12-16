// Decompiled with JetBrains decompiler
// Type: ns8.Class62
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns2;
using ns5;
using ns9;
using System;
using System.IO;
using System.Security;

namespace ns8
{
  [SecuritySafeCritical]
  internal class Class62
  {
    private const int int_0 = 11;
    private readonly ns4.Class53 class53_0;
    private readonly MemoryStream memoryStream_0;
    private readonly Class74 class74_0;
    private int int_1;

    public Class62(ns4.Class53 dc)
    {
      this.class53_0 = dc;
      this.memoryStream_0 = new MemoryStream();
      this.class74_0 = new Class74((Stream) this.memoryStream_0);
    }

    public byte[] method_0()
    {
      byte[] numArray1 = this.method_2("head");
      byte[] numArray2 = this.method_2("maxp");
      byte[] numArray3 = this.method_2("hhea");
      byte[] numArray4 = this.method_2("hmtx");
      byte[] numArray5 = this.method_2("cvt ");
      byte[] numArray6 = this.method_2("prep");
      byte[] numArray7 = this.method_2("fpgm");
      byte[] numArray8 = this.method_2("glyf");
      byte[] numArray9 = this.method_2("loca");
      byte[] numArray10 = this.method_2("OS/2");
      byte[] numArray11 = this.method_2("post");
      this.class74_0.method_17(65536);
      this.class74_0.method_9(11);
      this.class74_0.method_9(0);
      this.class74_0.method_9(0);
      this.class74_0.method_9(0);
      this.int_1 = (int) this.class74_0.Position + 176;
      this.method_1("head", numArray1);
      this.method_1("maxp", numArray2);
      this.method_1("hhea", numArray3);
      this.method_1("hmtx", numArray4);
      this.method_1("cvt ", numArray5);
      this.method_1("prep", numArray6);
      this.method_1("fpgm", numArray7);
      this.method_1("glyf", numArray8);
      this.method_1("loca", numArray9);
      this.method_1("OS/2", numArray10);
      this.method_1("post", numArray11);
      this.class74_0.method_23(numArray1, 0, numArray1.Length);
      this.class74_0.method_23(numArray2, 0, numArray2.Length);
      this.class74_0.method_23(numArray3, 0, numArray3.Length);
      this.class74_0.method_23(numArray4, 0, numArray4.Length);
      this.class74_0.method_23(numArray5, 0, numArray5.Length);
      this.class74_0.method_23(numArray6, 0, numArray6.Length);
      this.class74_0.method_23(numArray7, 0, numArray7.Length);
      this.class74_0.method_23(numArray8, 0, numArray8.Length);
      this.class74_0.method_23(numArray9, 0, numArray9.Length);
      this.class74_0.method_23(numArray10, 0, numArray10.Length);
      this.class74_0.method_23(numArray11, 0, numArray11.Length);
      return this.memoryStream_0.ToArray();
    }

    private void method_1(string tableName, byte[] data)
    {
      this.class74_0.method_1((byte) tableName[0]);
      this.class74_0.method_1((byte) tableName[1]);
      this.class74_0.method_1((byte) tableName[2]);
      this.class74_0.method_1((byte) tableName[3]);
      this.class74_0.method_15(0U);
      this.class74_0.method_15((uint) this.int_1);
      this.class74_0.method_15((uint) data.Length);
      this.int_1 += data.Length;
    }

    private byte[] method_2(string tableName)
    {
      uint dwTable = Class46.smethod_0(tableName);
      byte[] lpvBuffer = new byte[Class61.GetFontData(this.class53_0.Handle, dwTable, 0U, (byte[]) null, 0U)];
      if (Class61.GetFontData(this.class53_0.Handle, dwTable, 0U, lpvBuffer, (uint) lpvBuffer.Length) == uint.MaxValue)
        throw new Exception("Failed to retrieve table " + tableName);
      return lpvBuffer;
    }
  }
}
