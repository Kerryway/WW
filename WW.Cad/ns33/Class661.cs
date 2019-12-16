// Decompiled with JetBrains decompiler
// Type: ns33.Class661
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace ns33
{
  internal static class Class661
  {
    internal class Class662 : Interface38
    {
      private double double_0;

      public Class662()
      {
      }

      public Class662(double scale)
      {
        this.double_0 = scale;
      }

      public double Scale
      {
        get
        {
          return this.double_0;
        }
        set
        {
          this.double_0 = value;
        }
      }

      public double imethod_0(short lineWeight)
      {
        return this.double_0 * (double) lineWeight;
      }
    }

    internal class Class663 : Interface38
    {
      private double double_0;

      public Class663()
      {
      }

      public Class663(double fixedLineWidth)
      {
        this.double_0 = fixedLineWidth;
      }

      public double FixedLineWidth
      {
        get
        {
          return this.double_0;
        }
        set
        {
          this.double_0 = value;
        }
      }

      public double imethod_0(short lineWeight)
      {
        return this.double_0;
      }
    }
  }
}
