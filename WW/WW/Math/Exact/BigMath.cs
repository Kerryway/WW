// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.BigMath
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math.Exact
{
  public static class BigMath
  {
    public static BigRational Max(BigRational a, BigRational b)
    {
      if (a > b)
        return a;
      return b;
    }

    public static BigRational Min(BigRational a, BigRational b)
    {
      if (a < b)
        return a;
      return b;
    }

    public static BigInteger Max(BigInteger a, BigInteger b)
    {
      if (a > b)
        return a;
      return b;
    }

    public static BigInteger Min(BigInteger a, BigInteger b)
    {
      if (a < b)
        return a;
      return b;
    }

    internal static char smethod_0(BigInteger digit)
    {
      if (digit.IsZero)
        return '0';
      return (char) (48U + digit.Digits[0]);
    }
  }
}
