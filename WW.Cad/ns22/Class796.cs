// Decompiled with JetBrains decompiler
// Type: ns22.Class796
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns22
{
  internal class Class796
  {
    private double[][] double_0 = new double[3][];

    private Class796()
    {
    }

    public Class796(Interface8 reader)
    {
      this.method_0(reader);
    }

    private void method_0(Interface8 reader)
    {
      for (int index1 = 0; index1 < 3; ++index1)
      {
        int length = reader.imethod_5();
        this.double_0[index1] = new double[length];
        for (int index2 = 0; index2 < length; ++index2)
          this.double_0[index1][index2] = reader.imethod_8();
      }
    }

    public void method_1(Interface9 writer)
    {
      for (int index1 = 0; index1 < 3; ++index1)
      {
        int length = this.double_0[index1].Length;
        writer.imethod_4(length);
        for (int index2 = 0; index2 < length; ++index2)
          writer.imethod_7(this.double_0[index1][index2]);
        writer.imethod_15();
      }
    }
  }
}
