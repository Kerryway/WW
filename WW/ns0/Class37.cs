// Decompiled with JetBrains decompiler
// Type: ns0.Class37
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace ns0
{
  internal class Class37
  {
    public static double smethod_0(double[] a, int n, double u)
    {
      double num = a[n];
      for (int index = n - 1; index >= 0; --index)
        num = num * u + a[index];
      return num;
    }
  }
}
