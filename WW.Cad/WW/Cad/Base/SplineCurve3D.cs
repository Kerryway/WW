// Decompiled with JetBrains decompiler
// Type: WW.Cad.Base.SplineCurve3D
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW.Math;

namespace WW.Cad.Base
{
  public class SplineCurve3D
  {
    private readonly BSplineD bsplineD_0;
    private readonly Point3D[] point3D_0;
    private readonly double[] double_0;

    public SplineCurve3D(int degree, double[] knots, Point3D[] controlPoints)
      : this(degree, knots, controlPoints, (double[]) null)
    {
    }

    public SplineCurve3D(int degree, double[] knots, Point3D[] controlPoints, double[] weights)
    {
      this.bsplineD_0 = new BSplineD(degree, knots);
      this.point3D_0 = controlPoints;
      if (weights != null)
      {
        bool flag = false;
        foreach (double weight in weights)
        {
          if (weight != 1.0)
          {
            flag = true;
            break;
          }
        }
        if (flag)
        {
          this.double_0 = weights;
          return;
        }
      }
      this.double_0 = weights;
    }

    public SplineCurve3D(int degree, double[] knots, Vector4D[] controlPoints)
    {
      this.bsplineD_0 = new BSplineD(degree, knots);
      this.point3D_0 = new Point3D[controlPoints.Length];
      this.double_0 = new double[controlPoints.Length];
      bool flag = false;
      for (int index = controlPoints.Length - 1; index >= 0; --index)
      {
        Vector4D controlPoint = controlPoints[index];
        this.point3D_0[index] = new Point3D(controlPoint.X, controlPoint.Y, controlPoint.Z);
        double w = controlPoint.W;
        this.double_0[index] = w;
        flag = flag || w != 1.0;
      }
      if (flag)
        return;
      this.double_0 = (double[]) null;
    }

    public Point3D[] ControlPoints
    {
      get
      {
        return this.point3D_0;
      }
    }

    public double[] Weights
    {
      get
      {
        return this.double_0;
      }
    }

    public bool IsValid
    {
      get
      {
        return this.bsplineD_0.IsValid(this.point3D_0.Length);
      }
    }

    public Bounds3D ControlPolygonBounds
    {
      get
      {
        Bounds3D bounds3D = new Bounds3D();
        bounds3D.Update(this.point3D_0);
        return bounds3D;
      }
    }

    public BSplineD KnotInfo
    {
      get
      {
        return this.bsplineD_0;
      }
    }

    public Point3D[] CreateFitPoints(double fitTolerance, double knotTolerance)
    {
      if (fitTolerance <= 0.0)
        throw new ArgumentException("fitTolerance must be greater than 0!");
      if (knotTolerance <= 0.0)
        throw new ArgumentException("knotTolerance must be greater than 0!");
      if (!this.IsValid)
        return (Point3D[]) null;
      int degree = this.KnotInfo.Degree;
      double[] knotValues = this.KnotInfo.KnotValues;
      double[] N = new double[this.KnotInfo.Degree + 1];
      SplineCurve3D.Class943 class943_1 = new SplineCurve3D.Class943(knotValues[degree], this.method_1(knotValues[degree], N));
      SplineCurve3D.Class943 class943_2 = class943_1;
      for (int index = degree + 1; index < knotValues.Length - degree; ++index)
      {
        if (knotValues[index] > knotValues[index - 1])
        {
          double num = (knotValues[index] + knotValues[index - 1]) / 2.0;
          SplineCurve3D.Class943 lp1 = new SplineCurve3D.Class943(num, this.method_1(num, N));
          class943_2.method_0(lp1);
          SplineCurve3D.Class943 class943_3 = lp1;
          SplineCurve3D.Class943 lp2 = new SplineCurve3D.Class943(knotValues[index], this.method_1(knotValues[index], N));
          class943_3.method_0(lp2);
          class943_2 = lp2;
        }
      }
      double tolerance2 = fitTolerance * fitTolerance;
      for (SplineCurve3D.Class943 lp = class943_1; lp.Next != null; lp = lp.Next)
      {
        int knotSpanIndex = this.bsplineD_0.GetKnotSpanIndex(lp.double_0);
        this.method_0(tolerance2, knotTolerance, knotSpanIndex, lp, N);
      }
      return class943_1.Points;
    }

    private void method_0(
      double tolerance2,
      double knotTolerance,
      int span,
      SplineCurve3D.Class943 lp,
      double[] N)
    {
      SplineCurve3D.Class943 next = lp.Next;
      Vector3D vector3D = next.point3D_0 - lp.point3D_0;
      if (vector3D.GetLengthSquared() < tolerance2)
        return;
      double num = (next.double_0 + lp.double_0) / 2.0;
      Point3D point = this.method_2(span, num, N);
      Point3D point3D = lp.point3D_0 + 0.5 * vector3D;
      double lengthSquared = (point - point3D).GetLengthSquared();
      SplineCurve3D.Class943 lp1 = (SplineCurve3D.Class943) null;
      if (lengthSquared > 0.0)
      {
        lp1 = new SplineCurve3D.Class943(num, point);
        lp.method_0(lp1);
        if (lp1.double_0 - lp.double_0 <= knotTolerance)
          return;
      }
      if (lengthSquared < tolerance2)
        return;
      this.method_0(tolerance2, knotTolerance, span, lp, N);
      this.method_0(tolerance2, knotTolerance, span, lp1, N);
    }

    private Point3D method_1(double u, double[] N)
    {
      return this.method_2(this.bsplineD_0.GetKnotSpanIndex(u), u, N);
    }

    private Point3D method_2(int span, double u, double[] N)
    {
      if (this.double_0 != null)
        this.bsplineD_0.EvaluateRationalBasisFunctions(span, u, this.double_0, N);
      else
        this.bsplineD_0.EvaluateBasisFunctions(span, u, N);
      Point3D point3D = new Point3D();
      int degree = this.bsplineD_0.Degree;
      for (int index = 0; index <= degree; ++index)
        point3D += N[index] * (Vector3D) this.point3D_0[span - degree + index];
      return point3D;
    }

    private class Class943
    {
      private SplineCurve3D.Class943 class943_0;
      internal readonly Point3D point3D_0;
      internal readonly double double_0;

      public Class943(double uValue, Point3D point)
      {
        this.double_0 = uValue;
        this.point3D_0 = point;
      }

      public void method_0(SplineCurve3D.Class943 lp)
      {
        lp.class943_0 = this.class943_0;
        this.class943_0 = lp;
      }

      public SplineCurve3D.Class943 Next
      {
        get
        {
          return this.class943_0;
        }
      }

      public Point3D[] Points
      {
        get
        {
          int length = 0;
          for (SplineCurve3D.Class943 class943 = this; class943 != null; class943 = class943.Next)
            ++length;
          Point3D[] point3DArray = new Point3D[length];
          int num = 0;
          for (SplineCurve3D.Class943 class943 = this; class943 != null; class943 = class943.Next)
            point3DArray[num++] = class943.point3D_0;
          return point3DArray;
        }
      }
    }
  }
}
