// Decompiled with JetBrains decompiler
// Type: ns0.Class484
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace ns0
{
  internal static class Class484
  {
    public const double double_0 = 42.0;

    public static double smethod_0(Size2D size, double lensLength, double viewHeight)
    {
      double num = 42.0 * (size.Y / System.Math.Sqrt(size.X * size.X + size.Y * size.Y));
      return lensLength * viewHeight / num;
    }
  }
}
