// Decompiled with JetBrains decompiler
// Type: ns10.Class66
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace ns10
{
  internal class Class66
  {
    private readonly int int_0;

    public Class66(int emSquare)
    {
      this.int_0 = emSquare;
    }

    public int method_0(int value)
    {
      if (this.int_0 == 0)
        return value;
      if (value >= 0)
        return value / this.int_0 * 1000 + value % this.int_0 * 1000 / this.int_0;
      long num1 = (long) (value % this.int_0);
      long num2 = 1000L * num1;
      long num3 = num1 / num2;
      return -(-1000 * value / this.int_0 - (int) num3);
    }
  }
}
