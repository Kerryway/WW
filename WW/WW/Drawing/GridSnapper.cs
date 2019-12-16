// Decompiled with JetBrains decompiler
// Type: WW.Drawing.GridSnapper
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using WW.Math;

namespace WW.Drawing
{
  public class GridSnapper
  {
    private double double_0 = 20.0;
    private double double_1 = 5.0;
    private IList<double> ilist_0 = (IList<double>) new double[3]{ 2.0, 5.0, 10.0 };

    public double MinGridDistanceDcs
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

    public double ProximityLimitDcs
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

    public IList<double> GridDistanceMultipliers
    {
      get
      {
        return this.ilist_0;
      }
      set
      {
        this.ilist_0 = value;
      }
    }

    public virtual double? Snap(double wcsValue, double wcsToDcsScaleFactor)
    {
      double gridDistanceWcs = this.GetGridDistanceWcs(wcsToDcsScaleFactor);
      double proximityLimitWcs = this.double_1 / wcsToDcsScaleFactor;
      double num = wcsValue % gridDistanceWcs;
      double? nullable = new double?();
      if (this.method_0(num, gridDistanceWcs, proximityLimitWcs))
        nullable = new double?(System.Math.Round(wcsValue / gridDistanceWcs) * gridDistanceWcs);
      return nullable;
    }

    public virtual Point2D? Snap(Point2D wcsValue, double wcsToDcsScaleFactor)
    {
      double gridDistanceWcs = this.GetGridDistanceWcs(wcsToDcsScaleFactor);
      double proximityLimitWcs = this.double_1 / wcsToDcsScaleFactor;
      Point2D point2D = new Point2D(wcsValue.X % gridDistanceWcs, wcsValue.Y % gridDistanceWcs);
      Point2D? nullable = new Point2D?();
      if (this.method_0(point2D.X, gridDistanceWcs, proximityLimitWcs) && this.method_0(point2D.Y, gridDistanceWcs, proximityLimitWcs))
        nullable = new Point2D?(new Point2D(System.Math.Round(wcsValue.X / gridDistanceWcs) * gridDistanceWcs, System.Math.Round(wcsValue.Y / gridDistanceWcs) * gridDistanceWcs));
      return nullable;
    }

    public virtual double GetGridDistanceWcs(double wcsToDcsScaleFactor)
    {
      if (wcsToDcsScaleFactor == 0.0)
        throw new ArgumentException("wcsToDcsScaleFactor may not be zero.");
      double num1 = System.Math.Pow(10.0, System.Math.Floor(System.Math.Log10(this.double_0 / wcsToDcsScaleFactor)));
      while (num1 * wcsToDcsScaleFactor < this.double_0)
      {
        double num2 = num1;
        foreach (double num3 in (IEnumerable<double>) this.ilist_0)
        {
          num1 = num2 * num3;
          if (num1 * wcsToDcsScaleFactor >= this.double_0)
            break;
        }
      }
      return num1;
    }

    private bool method_0(double value, double gridDistanceWcs, double proximityLimitWcs)
    {
      if (!MathUtil.AreApproxEqual(-gridDistanceWcs, value, proximityLimitWcs) && !MathUtil.AreApproxEqual(0.0, value, proximityLimitWcs))
        return MathUtil.AreApproxEqual(gridDistanceWcs, value, proximityLimitWcs);
      return true;
    }
  }
}
