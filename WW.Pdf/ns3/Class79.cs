// Decompiled with JetBrains decompiler
// Type: ns3.Class79
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns2;
using System;
using System.Collections.Generic;

namespace ns3
{
  internal class Class79
  {
    private const int int_0 = 12;
    private readonly Class74 class74_0;
    private readonly IDictionary<string, Class0> idictionary_0;

    public Class79(System.IO.Stream stream)
    {
      if (stream == null)
        throw new ArgumentNullException(nameof (stream), "Supplied stream cannot be a null reference");
      if (!stream.CanWrite)
        throw new ArgumentException("The supplied stream is not writable", nameof (stream));
      this.class74_0 = new Class74(stream);
      this.idictionary_0 = (IDictionary<string, Class0>) new Dictionary<string, Class0>();
    }

    public Class74 Stream
    {
      get
      {
        return this.class74_0;
      }
    }

    public void method_0(Class0 table)
    {
      if (this.idictionary_0.ContainsKey(table.Name))
        throw new ArgumentException("Already written table '" + table.Name + "'");
      this.idictionary_0.Add(table.Name, table);
    }

    public void method_1()
    {
      this.method_5();
      this.method_7();
      this.method_3();
      this.method_6();
      this.method_2();
    }

    private void method_2()
    {
      this.class74_0.Position = (long) (this.idictionary_0["head"].Entry.Offset + 8U);
      this.class74_0.method_15(this.method_8());
    }

    private void method_3()
    {
      foreach (Class0 table in (IEnumerable<Class0>) this.idictionary_0.Values)
        this.method_4(table);
    }

    private void method_4(Class0 table)
    {
      long num1 = this.class74_0.method_26();
      table.vmethod_1(this);
      int num2 = this.class74_0.method_22();
      long num3 = this.class74_0.method_27();
      table.Entry.Length = (uint) ((ulong) (num3 - num1) - (ulong) num2);
      table.Entry.Offset = (uint) num1;
      table.Entry.CheckSum = this.method_9((long) table.Entry.Length);
    }

    private void method_5()
    {
      this.class74_0.method_17(65536);
      int count = this.idictionary_0.Count;
      this.class74_0.method_9(count);
      int num1 = Class79.smethod_0(count);
      int num2 = num1 * 16;
      this.class74_0.method_9(num2);
      this.class74_0.method_9((int) Math.Log((double) num1, 2.0));
      this.class74_0.method_9(count * 16 - num2);
    }

    private void method_6()
    {
      this.class74_0.method_26();
      this.class74_0.Position = 0L;
      this.class74_0.method_25(12L);
      foreach (Class0 class0 in (IEnumerable<Class0>) this.idictionary_0.Values)
      {
        this.class74_0.method_15(class0.Tag);
        this.class74_0.method_15(class0.Entry.CheckSum);
        this.class74_0.method_15(class0.Entry.Offset);
        this.class74_0.method_15(class0.Entry.Length);
      }
      this.class74_0.method_27();
    }

    private void method_7()
    {
      this.class74_0.method_25((long) (this.idictionary_0.Count * 16));
    }

    private static int smethod_0(int max)
    {
      int num = 0;
      while (Math.Pow(2.0, (double) num) < (double) max)
        ++num;
      if (num != 0)
        return num - 1;
      return 0;
    }

    private uint method_8()
    {
      long length = this.class74_0.method_26();
      this.class74_0.Position = 0L;
      uint num = 2981146554U - this.method_9(length);
      this.class74_0.method_27();
      return num;
    }

    private uint method_9(long length)
    {
      long num1 = length + length % 4L;
      uint num2 = 0;
      for (long index = 0; index < num1; index += 4L)
        num2 += this.class74_0.method_14();
      return num2;
    }
  }
}
