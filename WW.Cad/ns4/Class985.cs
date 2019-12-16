// Decompiled with JetBrains decompiler
// Type: ns4.Class985
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace ns4
{
  internal class Class985
  {
    private Bounds2D bounds2D_0 = new Bounds2D();
    private Enum36 enum36_0;
    private Bounds2D bounds2D_1;
    private double double_0;
    private Bounds2D bounds2D_2;
    private double double_1;
    private double double_2;

    public Enum36 BoundsCalculationFlags
    {
      get
      {
        return this.enum36_0;
      }
      set
      {
        this.enum36_0 = value;
      }
    }

    public Bounds2D Bounds
    {
      get
      {
        return this.bounds2D_0;
      }
    }

    public Bounds2D FirstLineBounds
    {
      get
      {
        return this.bounds2D_1;
      }
      set
      {
        this.bounds2D_1 = value;
      }
    }

    public double FirstLineDescent
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

    public Bounds2D LastLineBounds
    {
      get
      {
        return this.bounds2D_2;
      }
      set
      {
        this.bounds2D_2 = value;
      }
    }

    public double LastLineDescent
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
      }
    }

    public double TextBlockDescent
    {
      get
      {
        return this.double_2;
      }
      set
      {
        this.double_2 = value;
      }
    }
  }
}
