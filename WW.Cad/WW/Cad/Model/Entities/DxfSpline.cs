// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfSpline
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns1;
using ns28;
using ns33;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using WW.Actions;
using WW.Cad.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfSpline : DxfEntity, IClipBoundaryProvider, IControlPointCollection
  {
    private Vector3D vector3D_0 = Vector3D.ZAxis;
    private double double_1 = 1E-07;
    private double double_2 = 1E-07;
    private double double_3 = 1E-10;
    private readonly List<double> list_0 = new List<double>();
    private readonly List<double> list_1 = new List<double>();
    private readonly List<WW.Math.Point3D> list_2 = new List<WW.Math.Point3D>();
    private readonly List<WW.Math.Point3D> list_3 = new List<WW.Math.Point3D>();
    public const double DefaultKnotTolerance = 1E-07;
    public const double DefaultControlPointTolerance = 1E-07;
    public const double DefaultFitTolerance = 1E-10;
    private SplineFlags splineFlags_0;
    private int int_0;
    private Vector3D vector3D_1;
    private Vector3D vector3D_2;
    private SplineFlags1 splineFlags1_0;
    private KnotParameterization knotParameterization_0;
    private Pair<IList<double>, IList<WW.Math.Point3D>> pair_0;

    public DxfSpline()
      : this(3)
    {
    }

    public DxfSpline(int degree)
    {
      this.int_0 = degree;
    }

    [System.ComponentModel.TypeConverter(typeof (CollectionConverter))]
    public List<WW.Math.Point3D> ControlPoints
    {
      get
      {
        return this.list_2;
      }
    }

    public double ControlPointTolerance
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

    public int Degree
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public Vector3D EndTangent
    {
      get
      {
        return this.vector3D_2;
      }
      set
      {
        this.vector3D_2 = value;
      }
    }

    [System.ComponentModel.TypeConverter(typeof (CollectionConverter))]
    public List<WW.Math.Point3D> FitPoints
    {
      get
      {
        return this.list_3;
      }
    }

    public SplineFlags1 Flags1
    {
      get
      {
        return this.splineFlags1_0;
      }
      set
      {
        this.splineFlags1_0 = value;
      }
    }

    public KnotParameterization KnotParameterization
    {
      get
      {
        return this.knotParameterization_0;
      }
      set
      {
        this.knotParameterization_0 = value;
      }
    }

    public double FitTolerance
    {
      get
      {
        return this.double_3;
      }
      set
      {
        this.double_3 = value;
      }
    }

    public SplineFlags Flags
    {
      get
      {
        return this.splineFlags_0;
      }
      set
      {
        this.splineFlags_0 = value;
      }
    }

    public bool Closed
    {
      get
      {
        return (this.splineFlags_0 & SplineFlags.Closed) != SplineFlags.None;
      }
      set
      {
        if (value)
          this.splineFlags_0 |= SplineFlags.Closed;
        else
          this.splineFlags_0 &= ~SplineFlags.Closed;
      }
    }

    public bool Rational
    {
      get
      {
        return (this.splineFlags_0 & SplineFlags.Rational) != SplineFlags.None;
      }
      set
      {
        if (value)
          this.splineFlags_0 |= SplineFlags.Rational;
        else
          this.splineFlags_0 &= ~SplineFlags.Rational;
      }
    }

    public bool IsPeriodic
    {
      get
      {
        return (this.splineFlags_0 & SplineFlags.Periodic) != SplineFlags.None;
      }
      set
      {
        if (value)
          this.splineFlags_0 |= SplineFlags.Periodic;
        else
          this.splineFlags_0 &= ~SplineFlags.Periodic;
      }
    }

    public bool IsPlanar
    {
      get
      {
        return (this.splineFlags_0 & SplineFlags.Planar) != SplineFlags.None;
      }
      set
      {
        if (value)
          this.splineFlags_0 |= SplineFlags.Planar;
        else
          this.splineFlags_0 &= ~SplineFlags.Planar;
      }
    }

    public bool IsLinear
    {
      get
      {
        return (this.splineFlags_0 & SplineFlags.Linear) != SplineFlags.None;
      }
      set
      {
        if (value)
          this.splineFlags_0 |= SplineFlags.Linear;
        else
          this.splineFlags_0 &= ~SplineFlags.Linear;
      }
    }

    [System.ComponentModel.TypeConverter(typeof (CollectionConverter))]
    public List<double> Knots
    {
      get
      {
        return this.list_0;
      }
    }

    public double KnotTolerance
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

    public Vector3D StartTangent
    {
      get
      {
        return this.vector3D_1;
      }
      set
      {
        this.vector3D_1 = value;
      }
    }

    [System.ComponentModel.TypeConverter(typeof (CollectionConverter))]
    public List<double> Weights
    {
      get
      {
        return this.list_1;
      }
    }

    public Vector3D ZAxis
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        this.vector3D_0 = value;
      }
    }

    public int ExpectedKnotCount
    {
      get
      {
        int expectedKnotCount = BSplineD.GetExpectedKnotCount(this.list_2.Count, this.int_0, this.Closed && this.IsPeriodic);
        if (this.Closed && this.IsPeriodic)
          expectedKnotCount -= this.int_0 << 1;
        return expectedKnotCount;
      }
    }

    public bool KnotsValid
    {
      get
      {
        return this.list_0.Count == this.ExpectedKnotCount;
      }
    }

    public bool WeightsValid
    {
      get
      {
        if (this.Rational)
          return this.list_1.Count == this.list_2.Count;
        if (this.list_1.Count != this.list_2.Count)
          return this.list_1.Count == 0;
        return true;
      }
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      bool flag = true;
      if (this.list_3.Count == 0 && !this.KnotsValid)
        messages.Add(new DxfMessage(DxfStatus.InvalidSplineKnots, Severity.Warning)
        {
          Parameters = {
            {
              "Target",
              (object) this
            },
            {
              "Knots",
              (object) this.list_0
            }
          }
        });
      if (this.list_3.Count == 0 && !this.WeightsValid)
      {
        messages.Add(new DxfMessage(DxfStatus.InvalidSplineWeights, Severity.Error)
        {
          Parameters = {
            {
              "Target",
              (object) this
            },
            {
              "Weights",
              (object) this.list_1
            }
          }
        });
        flag = false;
      }
      return flag;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfSpline dxfSpline = (DxfSpline) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfSpline == null)
      {
        dxfSpline = new DxfSpline();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfSpline);
        dxfSpline.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfSpline;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfSpline dxfSpline = (DxfSpline) from;
      this.splineFlags_0 = dxfSpline.splineFlags_0;
      this.vector3D_0 = dxfSpline.vector3D_0;
      this.int_0 = dxfSpline.int_0;
      this.double_1 = dxfSpline.double_1;
      this.double_2 = dxfSpline.double_2;
      this.double_3 = dxfSpline.double_3;
      this.vector3D_1 = dxfSpline.vector3D_1;
      this.vector3D_2 = dxfSpline.vector3D_2;
      this.list_0.AddRange((IEnumerable<double>) dxfSpline.list_0);
      this.list_1.AddRange((IEnumerable<double>) dxfSpline.list_1);
      this.list_2.AddRange((IEnumerable<WW.Math.Point3D>) dxfSpline.list_2);
      this.list_3.AddRange((IEnumerable<WW.Math.Point3D>) dxfSpline.list_3);
      this.splineFlags1_0 = dxfSpline.splineFlags1_0;
      this.knotParameterization_0 = dxfSpline.knotParameterization_0;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public bool UpdateSplineFromFitPoints()
    {
      if ((!(this.vector3D_1 != Vector3D.Zero) || !(this.vector3D_2 != Vector3D.Zero) ? (this.list_3.Count >= 3 ? 1 : 0) : (this.list_3.Count >= 2 ? 1 : 0)) == 0 || this.knotParameterization_0 == KnotParameterization.Custom || this.int_0 != 3)
        return false;
      Pair<IList<double>, IList<WW.Math.Point3D>> pair = this.method_14();
      this.list_0.Clear();
      this.list_0.AddRange((IEnumerable<double>) pair.First);
      this.list_2.Clear();
      this.list_2.AddRange((IEnumerable<WW.Math.Point3D>) pair.Second);
      return true;
    }

    private Pair<IList<double>, IList<WW.Math.Point3D>> method_13()
    {
      if (this.pair_0 == null)
        this.pair_0 = this.method_14();
      return this.pair_0;
    }

    private Pair<IList<double>, IList<WW.Math.Point3D>> method_14()
    {
      Pair<IList<double>, IList<WW.Math.Point3D>> pair;
      if (!(this.vector3D_1 == Vector3D.Zero) && !(this.vector3D_2 == Vector3D.Zero))
      {
        pair = DxfSpline.smethod_5(this.knotParameterization_0, (IList<WW.Math.Point3D>) this.list_3, this.vector3D_1, this.vector3D_2);
      }
      else
      {
        switch (this.list_3.Count)
        {
          case 2:
            pair = DxfSpline.smethod_2(this.knotParameterization_0, (IList<WW.Math.Point3D>) this.list_3);
            break;
          case 3:
            pair = DxfSpline.smethod_3(this.knotParameterization_0, (IList<WW.Math.Point3D>) this.list_3);
            break;
          default:
            pair = DxfSpline.smethod_4(this.knotParameterization_0, (IList<WW.Math.Point3D>) this.list_3);
            break;
        }
      }
      return pair;
    }

    internal static Pair<IList<double>, IList<WW.Math.Point3D>> smethod_2(
      KnotParameterization parameterization,
      IList<WW.Math.Point3D> points)
    {
      IList<double> first = DxfSpline.smethod_7(DxfSpline.smethod_8(parameterization, points));
      Vector3D vector3D = (points[1] - points[0]) / 3.0;
      IList<WW.Math.Point3D> second = (IList<WW.Math.Point3D>) new List<WW.Math.Point3D>() { points[0], points[0] + vector3D, points[1] - vector3D, points[1] };
      return new Pair<IList<double>, IList<WW.Math.Point3D>>(first, second);
    }

    internal static Pair<IList<double>, IList<WW.Math.Point3D>> smethod_3(
      KnotParameterization parameterization,
      IList<WW.Math.Point3D> points)
    {
      IList<double> uBar = DxfSpline.smethod_8(parameterization, points);
      IList<double> doubleList = DxfSpline.smethod_7(uBar);
      BSplineD bsplineD = new BSplineD(3, doubleList);
      double[] result = new double[4];
      bsplineD.EvaluateBasisFunctions(4, doubleList[4], result);
      double num1 = uBar[1] - uBar[0];
      double num2 = uBar[2] - uBar[1];
      Vector3D point1 = (Vector3D) points[0];
      Vector3D point2 = (Vector3D) points[1];
      Vector3D point3 = (Vector3D) points[2];
      Vector3D vector3D1 = (point2 - point1 * (result[0] * (num1 + num2) / (2.0 * num1 + num2)) - point3 * (result[2] * (num1 + num2) / (num1 + 2.0 * num2))) / (result[0] * num1 / (2.0 * num1 + num2) + result[1] + result[2] * num2 / (num1 + 2.0 * num2));
      Vector3D vector3D2 = vector3D1 - point1;
      Vector3D vector3D3 = vector3D1 - point3;
      IList<WW.Math.Point3D> second = (IList<WW.Math.Point3D>) new List<WW.Math.Point3D>() { points[0], (WW.Math.Point3D) point1 + vector3D2 * (num1 / (2.0 * num1 + num2)), (WW.Math.Point3D) vector3D1, (WW.Math.Point3D) point3 + vector3D3 * (num2 / (num1 + 2.0 * num2)), points[2] };
      return new Pair<IList<double>, IList<WW.Math.Point3D>>(doubleList, second);
    }

    internal static Pair<IList<double>, IList<WW.Math.Point3D>> smethod_4(
      KnotParameterization parameterization,
      IList<WW.Math.Point3D> points)
    {
      if (points.Count < 4)
        throw new ArgumentException("Not enough fit points, need at least 4!");
      IList<double> uBar = DxfSpline.smethod_8(parameterization, points);
      int index = uBar.Count - 1;
      IList<double> doubleList = DxfSpline.smethod_7(uBar);
      double num1 = 3.0 / (uBar[1] - uBar[0]);
      Vector3D start = num1 * (1.0 * (points[1] - points[0]) - 0.5 * (points[2] - points[1]));
      double num2 = 3.0 / (uBar[index] - uBar[index - 1]);
      Vector3D end = num2 * (1.0 * (points[index] - points[index - 1]) - 0.5 * (points[index - 1] - points[index - 2]));
      double num3 = 1.0 / start.GetLengthSquared();
      double num4 = 1.0 / end.GetLengthSquared();
      double num5 = (uBar[1] + uBar[2] - 2.0 * uBar[0]) / (uBar[1] - uBar[0]);
      double num6 = (2.0 * uBar[index] - uBar[index - 1] - uBar[index - 2]) / (uBar[index] - uBar[index - 1]);
      double num7 = 8.98846567431158E+307;
      double num8 = 8.98846567431158E+307;
      int num9 = 1024;
      IList<WW.Math.Point3D> second = (IList<WW.Math.Point3D>) null;
      while (num7 + num8 > 1E-19)
      {
        Vector3D vector3D1 = start;
        Vector3D vector3D2 = end;
        second = DxfSpline.smethod_9(doubleList, points, start, end);
        WW.Math.Point3D point3D1 = second[0];
        WW.Math.Point3D point3D2 = second[1];
        WW.Math.Point3D point3D3 = second[2];
        start = 0.5 * (point3D2 - point3D1 + (point3D3 - point3D1) / num5) * num1;
        num7 = num3 * (start - vector3D1).GetLengthSquared();
        WW.Math.Point3D point3D4 = second[second.Count - 1];
        WW.Math.Point3D point3D5 = second[second.Count - 2];
        WW.Math.Point3D point3D6 = second[second.Count - 3];
        end = 0.5 * (point3D4 - point3D5 + (point3D4 - point3D6) / num6) * num2;
        num8 = num4 * (end - vector3D2).GetLengthSquared();
        if (--num9 <= 0)
          throw new Exception("Cannot determine spline interpolation!");
      }
      return new Pair<IList<double>, IList<WW.Math.Point3D>>(doubleList, second);
    }

    internal static Pair<IList<double>, IList<WW.Math.Point3D>> smethod_5(
      KnotParameterization parameterization,
      IList<WW.Math.Point3D> points,
      Vector3D start,
      Vector3D end)
    {
      if (points.Count < 2)
        throw new ArgumentException("Not enough fit points, need at least 2!");
      IList<double> doubleList = DxfSpline.smethod_6(parameterization, points);
      return new Pair<IList<double>, IList<WW.Math.Point3D>>(doubleList, DxfSpline.smethod_9(doubleList, points, start, end));
    }

    private static IList<double> smethod_6(
      KnotParameterization parameterization,
      IList<WW.Math.Point3D> points)
    {
      return DxfSpline.smethod_7(DxfSpline.smethod_8(parameterization, points));
    }

    private static IList<double> smethod_7(IList<double> uBar)
    {
      IList<double> doubleList = (IList<double>) new List<double>(uBar.Count + 6);
      for (int index = 0; index < 3; ++index)
        doubleList.Add(uBar[0]);
      foreach (double num in (IEnumerable<double>) uBar)
        doubleList.Add(num);
      double num1 = doubleList[doubleList.Count - 1];
      for (int index = 0; index < 3; ++index)
        doubleList.Add(num1);
      return doubleList;
    }

    private static IList<double> smethod_8(
      KnotParameterization parameterization,
      IList<WW.Math.Point3D> points)
    {
      IList<double> doubleList;
      switch (parameterization)
      {
        case KnotParameterization.Chord:
          doubleList = DxfSpline.smethod_10(points);
          break;
        case KnotParameterization.SquareRoot:
          doubleList = DxfSpline.smethod_11(points);
          break;
        case KnotParameterization.Uniform:
          doubleList = DxfSpline.smethod_12(points.Count);
          break;
        default:
          throw new ArgumentException("Unsupported knot parametrization: " + (object) parameterization);
      }
      return doubleList;
    }

    private static IList<WW.Math.Point3D> smethod_9(
      IList<double> u,
      IList<WW.Math.Point3D> points,
      Vector3D start,
      Vector3D end)
    {
      int index1 = points.Count - 1;
      WW.Math.Point3D[] point3DArray = new WW.Math.Point3D[index1 + 3];
      BSplineD bsplineD = new BSplineD(3, u);
      point3DArray[0] = points[0];
      point3DArray[1] = points[0] + start * ((u[4] - u[3]) / 3.0);
      point3DArray[index1 + 2] = points[index1];
      point3DArray[index1 + 1] = points[index1] - end * ((u[index1 + 3] - u[index1 + 2]) / 3.0);
      if (index1 > 1)
      {
        double[] result = new double[4];
        double[] numArray = new double[index1 + 1];
        bsplineD.EvaluateBasisFunctions(4, u[4], result);
        double num1 = result[1];
        Vector3D vector3D1 = ((Vector3D) points[1] - result[0] * (Vector3D) point3DArray[1]) * (1.0 / num1);
        point3DArray[2] = (WW.Math.Point3D) vector3D1;
        for (int index2 = 3; index2 < index1; ++index2)
        {
          numArray[index2] = result[2] / num1;
          bsplineD.EvaluateBasisFunctions(index2 + 2, u[index2 + 2], result);
          num1 = result[1] - result[0] * numArray[index2];
          Vector3D vector3D2 = ((Vector3D) points[index2 - 1] - result[0] * (Vector3D) point3DArray[index2 - 1]) * (1.0 / num1);
          point3DArray[index2] = (WW.Math.Point3D) vector3D2;
        }
        numArray[index1] = result[2] / num1;
        bsplineD.EvaluateBasisFunctions(index1 + 2, u[index1 + 2], result);
        double num2 = result[1] - result[0] * numArray[index1];
        Vector3D vector3D3 = ((Vector3D) points[index1 - 1] - result[2] * (Vector3D) point3DArray[index1 + 1] - result[0] * (Vector3D) point3DArray[index1 - 1]) * (1.0 / num2);
        point3DArray[index1] = (WW.Math.Point3D) vector3D3;
        if (index1 > 2)
        {
          for (int index2 = index1 - 1; index2 >= 2; --index2)
            point3DArray[index2] -= numArray[index2 + 1] * (Vector3D) point3DArray[index2 + 1];
        }
        else
          point3DArray[index1] = (WW.Math.Point3D) (0.75 * (Vector3D) point3DArray[index1]);
      }
      return (IList<WW.Math.Point3D>) point3DArray;
    }

    private static IList<double> smethod_10(IList<WW.Math.Point3D> points)
    {
      List<double> doubleList = new List<double>(points.Count);
      double num = 0.0;
      WW.Math.Point3D? nullable = new WW.Math.Point3D?();
      foreach (WW.Math.Point3D point in (IEnumerable<WW.Math.Point3D>) points)
      {
        if (nullable.HasValue)
          num += (point - nullable.Value).GetLength();
        doubleList.Add(num);
        nullable = new WW.Math.Point3D?(point);
      }
      return (IList<double>) doubleList;
    }

    private static IList<double> smethod_11(IList<WW.Math.Point3D> points)
    {
      List<double> doubleList = new List<double>(points.Count);
      double num = 0.0;
      WW.Math.Point3D? nullable = new WW.Math.Point3D?();
      foreach (WW.Math.Point3D point in (IEnumerable<WW.Math.Point3D>) points)
      {
        if (nullable.HasValue)
          num += System.Math.Sqrt((point - nullable.Value).GetLength());
        doubleList.Add(num);
        nullable = new WW.Math.Point3D?(point);
      }
      return (IList<double>) doubleList;
    }

    private static IList<double> smethod_12(int numPoints)
    {
      List<double> doubleList = new List<double>(numPoints);
      for (int index = 0; index < numPoints; ++index)
        doubleList.Add((double) index);
      return (IList<double>) doubleList;
    }

    internal WW.Math.Geometry.Polyline3D method_15(int nrOfSplineLineParts)
    {
      return this.method_16(nrOfSplineLineParts);
    }

    internal WW.Math.Geometry.Polyline3D method_16(int noOfSplineLineParts)
    {
      bool closed;
      WW.Math.Geometry.Polyline3D polyline = new WW.Math.Geometry.Polyline3D(closed = this.Closed);
      IList<double> knots = (IList<double>) new List<double>((IEnumerable<double>) this.list_0);
      IList<WW.Math.Point3D> point3DList = (IList<WW.Math.Point3D>) this.list_2;
      bool flag = this.KnotsValid;
      if (knots.Count == 0 && point3DList.Count == 0 && (this.list_1.Count == 0 && this.knotParameterization_0 != KnotParameterization.Custom) && (this.int_0 == 3 && this.list_3.Count >= 2))
      {
        Pair<IList<double>, IList<WW.Math.Point3D>> pair = this.method_13();
        if (pair != null)
        {
          knots = pair.First;
          point3DList = pair.Second;
          flag = true;
        }
      }
      if (point3DList.Count < this.int_0 + 1)
        return new WW.Math.Geometry.Polyline3D(closed, (IList<WW.Math.Point3D>) this.list_3);
      BSplineD spline;
      if (knots.Count != 0 && flag)
      {
        if (this.Closed && this.IsPeriodic)
        {
          double num1 = knots[0];
          int count = knots.Count;
          double num2 = knots[count - 1];
          for (int index = 1; index <= this.int_0 << 1; ++index)
            knots.Add(num2 + knots[index] - num1);
        }
        spline = new BSplineD(this.int_0, knots);
      }
      else
        spline = new BSplineD(this.int_0, point3DList.Count, this.Closed & this.IsPeriodic);
      double[] result = new double[this.int_0 + 1];
      double[] weights;
      if (this.list_1.Count != 0 && this.Rational)
      {
        weights = this.list_1.ToArray();
      }
      else
      {
        weights = new double[point3DList.Count];
        for (int index = 0; index < point3DList.Count; ++index)
          weights[index] = 1.0;
      }
      WW.Math.Point3D[] normalizedControlPoints = new WW.Math.Point3D[point3DList.Count];
      Bounds3D bounds3D = new Bounds3D();
      for (int index = 0; index < normalizedControlPoints.Length; ++index)
      {
        WW.Math.Point3D p = point3DList[index];
        normalizedControlPoints[index] = p;
        bounds3D.Update(p);
      }
      Vector3D vector3D = 0.5 * bounds3D.Delta;
      if (closed)
      {
        vector3D.X = vector3D.Y = vector3D.Z = System.Math.Max(vector3D.X, System.Math.Max(vector3D.Y, vector3D.Z));
        if (vector3D.X == 0.0)
        {
          ref Vector3D local1 = ref vector3D;
          ref Vector3D local2 = ref vector3D;
          ref Vector3D local3 = ref vector3D;
          double num1 = 1.0;
          local3.Z = 1.0;
          double num2 = num1;
          double num3 = 1.0;
          local2.Y = num2;
          double num4 = num3;
          local1.X = num4;
        }
      }
      else
      {
        if (vector3D.X == 0.0)
          vector3D.X = 1.0;
        if (vector3D.Y == 0.0)
          vector3D.Y = 1.0;
        if (vector3D.Z == 0.0)
          vector3D.Z = 1.0;
      }
      Matrix4D matrix4D1 = Transformation4D.Scaling(1.0 / vector3D.X, 1.0 / vector3D.Y, 1.0 / vector3D.Z) * Transformation4D.Translation(-(Vector3D) bounds3D.Center);
      Matrix4D matrix4D2 = Transformation4D.Translation((Vector3D) bounds3D.Center) * Transformation4D.Scaling(vector3D.X, vector3D.Y, vector3D.Z);
      for (int index = normalizedControlPoints.Length - 1; index >= 0; --index)
        normalizedControlPoints[index] = matrix4D1.Transform4x3(normalizedControlPoints[index]);
      double minU = spline.MinU;
      double maxU = spline.MaxU;
      int num5 = normalizedControlPoints.Length * noOfSplineLineParts + 1;
      double num6 = (maxU - minU) / (double) (num5 - 1);
      int num7 = 0;
      double u = minU;
      while (num7 < num5)
      {
        if (num7 == num5 - 1)
          u = maxU;
        int knotSpanIndex = spline.GetKnotSpanIndex(u);
        spline.EvaluateRationalBasisFunctions(knotSpanIndex, u, weights, result);
        WW.Math.Point3D zero = WW.Math.Point3D.Zero;
        int index = 0;
        int num1 = knotSpanIndex - this.int_0;
        while (index < this.int_0 + 1)
        {
          WW.Math.Point3D point3D = normalizedControlPoints[num1 % normalizedControlPoints.Length];
          double num2 = result[index];
          zero.Add(num2 * point3D.X, num2 * point3D.Y, num2 * point3D.Z);
          ++index;
          ++num1;
        }
        polyline.Add(zero);
        ++num7;
        u += num6;
      }
      if (this.Closed && !this.IsPeriodic)
        this.method_18(polyline, spline, noOfSplineLineParts, normalizedControlPoints);
      for (int index = polyline.Count - 1; index >= 0; --index)
        polyline[index] = matrix4D2.Transform4x3(polyline[index]);
      return polyline;
    }

    public override void TransformMe(TransformConfig config, Matrix4D matrix)
    {
      this.TransformMe(config, matrix, (CommandGroup) null);
    }

    public override void TransformMe(
      TransformConfig config,
      Matrix4D matrix,
      CommandGroup undoGroup)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfSpline.Class900 class900 = new DxfSpline.Class900();
      // ISSUE: reference to a compiler-generated field
      class900.dxfSpline_0 = this;
      // ISSUE: reference to a compiler-generated field
      class900.vector3D_0 = this.vector3D_1;
      // ISSUE: reference to a compiler-generated field
      class900.vector3D_1 = this.vector3D_2;
      // ISSUE: reference to a compiler-generated field
      class900.point3D_0 = this.list_2.ToArray();
      // ISSUE: reference to a compiler-generated field
      class900.point3D_1 = this.list_3.ToArray();
      // ISSUE: reference to a compiler-generated field
      class900.vector3D_2 = this.vector3D_0;
      this.vector3D_0 = matrix.Transform(this.vector3D_0);
      this.vector3D_0.Normalize();
      this.vector3D_1 = matrix.Transform(this.vector3D_1);
      this.vector3D_2 = matrix.Transform(this.vector3D_2);
      for (int index = this.list_2.Count - 1; index >= 0; --index)
        this.list_2[index] = matrix.Transform(this.list_2[index]);
      for (int index = this.list_3.Count - 1; index >= 0; --index)
        this.list_3[index] = matrix.Transform(this.list_3[index]);
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfSpline.Class901()
      {
        class900_0 = class900,
        vector3D_0 = this.vector3D_1,
        vector3D_1 = this.vector3D_2,
        point3D_0 = this.list_2.ToArray(),
        point3D_1 = this.list_3.ToArray(),
        vector3D_2 = this.vector3D_0
      }.method_0), new System.Action(class900.method_0)));
    }

    public override string EntityType
    {
      get
      {
        return "SPLINE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbSpline";
      }
    }

    public override IControlPointCollection InteractionControlPoints
    {
      get
      {
        return (IControlPointCollection) this;
      }
    }

    public override DxfEntity.Interactor CreateCreateInteractor(Transaction transaction)
    {
      return (DxfEntity.Interactor) new DxfSpline.Class15((DxfEntity) this, (ITransaction) transaction);
    }

    public override DxfEntity.Interactor CreateEditInteractor()
    {
      return (DxfEntity.Interactor) new DxfEntity.DefaultEditInteractor((DxfEntity) this);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      IList<WW.Math.Geometry.Polyline3D> polylines1;
      List<FlatShape4D> flatShapes;
      this.method_17((DrawContext) context, context.GetTransformer().LineTypeScaler, out polylines1, out flatShapes);
      IClippingTransformer transformer = context.GetTransformer();
      IList<Polyline4D> polylines2 = DxfUtil.smethod_36(polylines1, false, transformer);
      if (polylines2.Count > 0)
        graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, polylines2, false, true);
      if (flatShapes != null)
        Class940.smethod_23((IPathDrawer) new ns0.Class0((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) flatShapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
      if (!context.Config.ShowSplineControlPoints)
        return;
      WW.Math.Geometry.Polyline3D polyline = new WW.Math.Geometry.Polyline3D(this.Closed, (IList<WW.Math.Point3D>) this.list_2);
      IList<Polyline4D> polylines3 = transformer.Transform(polyline, false);
      if (polylines3.Count <= 0)
        return;
      graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, polylines3, false, true);
    }

    private void method_17(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<WW.Math.Geometry.Polyline3D> polylines,
      out List<FlatShape4D> flatShapes)
    {
      WW.Math.Geometry.Polyline3D polyline = this.method_16((int) context.Config.NoOfSplineLineSegments);
      polylines = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>();
      if (context.Config.ApplyLineType)
      {
        flatShapes = new List<FlatShape4D>();
        DxfUtil.smethod_4(context.Config, polylines, (IList<FlatShape4D>) flatShapes, polyline, this.GetLineType(context), this.ZAxis, context.TotalLineTypeScale * this.LineTypeScale, lineTypeScaler);
        if (flatShapes.Count != 0)
          return;
        flatShapes = (List<FlatShape4D>) null;
      }
      else
      {
        polylines.Add(polyline);
        flatShapes = (List<FlatShape4D>) null;
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      IClippingTransformer transformer = context.GetTransformer();
      IList<WW.Math.Geometry.Polyline3D> polylines1;
      List<FlatShape4D> flatShapes;
      this.method_17((DrawContext) context, context.GetTransformer().LineTypeScaler, out polylines1, out flatShapes);
      IList<Polyline4D> polylines2 = DxfUtil.smethod_36(polylines1, false, transformer);
      if (polylines2.Count > 0)
        Class940.smethod_3((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, false, true, polylines2);
      if (flatShapes != null)
        Class940.smethod_23((IPathDrawer) new Class396((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) flatShapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
      if (!context.Config.ShowSplineControlPoints)
        return;
      WW.Math.Geometry.Polyline3D polyline1 = new WW.Math.Geometry.Polyline3D(this.Closed, (IList<WW.Math.Point3D>) this.list_2);
      foreach (Polyline4D polyline2 in (IEnumerable<Polyline4D>) transformer.Transform(polyline1, false))
        Class940.smethod_1((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, false, true, polyline2);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      graphicsFactory.SetColor(context.GetPlotColor((DxfEntity) this));
      IList<WW.Math.Geometry.Polyline3D> polylines;
      List<FlatShape4D> flatShapes;
      this.method_17((DrawContext) context, context.GetTransformer().LineTypeScaler, out polylines, out flatShapes);
      Class940.smethod_16((DxfEntity) this, context, graphicsFactory, polylines, false);
      if (flatShapes != null)
      {
        IPathDrawer pathDrawer = (IPathDrawer) new Class473((DxfEntity) this, context, graphicsFactory);
        foreach (FlatShape4D flatShape4D in flatShapes)
          pathDrawer.DrawPath(flatShape4D.FlatShape, flatShape4D.Transformation, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this), flatShape4D.IsFilled, false, 0.0);
      }
      if (!context.Config.ShowSplineControlPoints)
        return;
      WW.Math.Geometry.Polyline3D polyline = new WW.Math.Geometry.Polyline3D(this.Closed, (IList<WW.Math.Point3D>) this.list_2);
      if (polyline.Count <= 0)
        return;
      Class940.smethod_17((DxfEntity) this, context, graphicsFactory, polyline, false);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      if (!graphics.AddExistingGraphicElement1(parentGraphicElementBlock, (DxfEntity) this, plotColor))
        return;
      GraphicElement1 graphicElement = new GraphicElement1(plotColor);
      graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, graphicElement);
      WW.Math.Geometry.Polyline3D polyline1 = this.method_16((int) context.Config.NoOfSplineLineSegments);
      if (polyline1.Count > 0)
        graphicElement.Geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive(polyline1));
      if (!context.Config.ShowSplineControlPoints)
        return;
      WW.Math.Geometry.Polyline3D polyline2 = new WW.Math.Geometry.Polyline3D(this.Closed, (IList<WW.Math.Point3D>) this.list_2);
      if (polyline2.Count <= 0)
        return;
      graphicElement.Geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive(polyline2));
    }

    internal override short vmethod_6(Class432 w)
    {
      return 36;
    }

    public IList<Polygon2D> GetClipBoundary(GraphicsConfig graphicsConfig)
    {
      WW.Math.Geometry.Polyline3D polyline3D = this.method_16((int) graphicsConfig.NoOfSplineLineSegments);
      Polygon2D polygon2D = new Polygon2D(polyline3D.Count);
      foreach (WW.Math.Point3D point3D in (List<WW.Math.Point3D>) polyline3D)
        polygon2D.Add((WW.Math.Point2D) point3D);
      return (IList<Polygon2D>) new Polygon2D[1]{ polygon2D };
    }

    private void method_18(
      WW.Math.Geometry.Polyline3D polyline,
      BSplineD spline,
      int noOfSplineLineParts,
      WW.Math.Point3D[] normalizedControlPoints)
    {
      if (normalizedControlPoints.Length == 0 || this.list_0.Count == 0)
        return;
      BSplineD bsplineD = new BSplineD(3, 4, false);
      double[] result = new double[4];
      double minU = bsplineD.MinU;
      double maxU = bsplineD.MaxU;
      int num1 = 4 * noOfSplineLineParts + 1;
      double num2 = (maxU - minU) / (double) (num1 - 1);
      IList<WW.Math.Point3D> point3DList = (IList<WW.Math.Point3D>) new List<WW.Math.Point3D>();
      WW.Math.Point3D p1 = polyline[polyline.Count - 1];
      WW.Math.Point3D p2 = polyline[0];
      if ((p1 - p2).GetLength() <= this.double_2)
        return;
      Vector3D vector3D1 = this.method_19(spline, spline.GetKnotSpanIndex(spline.MinU), 1, spline.MinU, (IList<WW.Math.Point3D>) normalizedControlPoints);
      Vector3D direction1 = this.method_19(spline, spline.GetKnotSpanIndex(spline.MaxU), 1, spline.MaxU, (IList<WW.Math.Point3D>) normalizedControlPoints);
      bool parallel;
      WW.Math.Point3D[] point3DArray = DxfUtil.smethod_60(p1, direction1, p2, -vector3D1, out parallel);
      WW.Math.Point3D point3D1;
      WW.Math.Point3D point3D2;
      if (parallel)
      {
        point3D1 = p1;
        point3D2 = p2;
      }
      else if (point3DArray == null)
      {
        point3D2 = p2 - vector3D1 * 4.0;
        point3D1 = p1 + direction1 * 4.0;
      }
      else
      {
        double length1 = direction1.GetLength();
        double length2 = vector3D1.GetLength();
        double num3 = System.Math.Max(length1, length2);
        Vector3D vector3D2 = point3DArray[0] - p1;
        Vector3D vector3D3 = point3DArray[1] - p2;
        double length3 = vector3D2.GetLength();
        double length4 = vector3D3.GetLength();
        point3D1 = p1 + length1 / num3 * (length1 >= length2 ? 1.0 : length4 / length3) * vector3D2 * 0.64;
        point3D2 = p2 + length2 / num3 * (length2 >= length1 ? 1.0 : length3 / length4) * vector3D3 * 0.64;
      }
      if (parallel)
        return;
      point3DList.Add(p1);
      point3DList.Add(point3D1);
      point3DList.Add(point3D2);
      point3DList.Add(p2);
      int num4 = 0;
      double u = minU + num2;
      while (num4 < num1 - 2)
      {
        int knotSpanIndex = bsplineD.GetKnotSpanIndex(u);
        bsplineD.EvaluateBasisFunctions(knotSpanIndex, u, result);
        WW.Math.Point3D zero = WW.Math.Point3D.Zero;
        for (int index = 0; index < 4; ++index)
        {
          WW.Math.Point3D point3D3 = point3DList[(knotSpanIndex - 3 + index) % 4];
          zero += result[index] * (Vector3D) point3D3;
        }
        polyline.Add(zero);
        ++num4;
        u += num2;
      }
    }

    private Vector3D method_19(
      BSplineD spline,
      int knotSpan,
      int derivative,
      double u,
      IList<WW.Math.Point3D> points)
    {
      double[,] derivatives = new double[derivative + 1, this.int_0 + 1];
      spline.GetDerivativesBasisFunctions(knotSpan, u, derivative, derivatives);
      Vector3D zero = Vector3D.Zero;
      for (int index = 0; index <= this.int_0; ++index)
        zero += (Vector3D) points[knotSpan - this.int_0 + index] * derivatives[derivative, index];
      return zero;
    }

    void IControlPointCollection.Set(int index, WW.Math.Point3D value)
    {
      this.list_2[index] = value;
    }

    WW.Math.Point3D IControlPointCollection.Get(int index)
    {
      return this.list_2[index];
    }

    string IControlPointCollection.GetDescription(int index)
    {
      return Class881.DxfSpline_ControlPoint_Name;
    }

    PointDisplayType IControlPointCollection.GetDisplayType(
      int index)
    {
      return PointDisplayType.Default;
    }

    int IControlPointCollection.Count
    {
      get
      {
        return this.list_2.Count;
      }
    }

    bool IControlPointCollection.IsCountFixed
    {
      get
      {
        return false;
      }
    }

    void IControlPointCollection.Insert(int index)
    {
      this.list_2.Insert(index, WW.Math.Point3D.Zero);
      this.method_20();
    }

    void IControlPointCollection.RemoveAt(int index)
    {
      this.list_2.RemoveAt(index);
      this.method_20();
    }

    private void method_20()
    {
      this.list_0.Clear();
      this.list_0.AddRange((IEnumerable<double>) BSplineD.CreateDefaultKnotValues(this.int_0, this.list_2.Count, this.Closed));
    }

    private class Class15 : DxfEntity.DefaultCreateInteractor
    {
      public Class15(DxfEntity entity, ITransaction transaction)
        : base(entity, transaction)
      {
      }

      public override IControlPoint ControlPointTemplate
      {
        get
        {
          return (IControlPoint) DxfSpline.Class15.Class899.class899_0;
        }
      }

      private class Class899 : IControlPoint
      {
        public static readonly DxfSpline.Class15.Class899 class899_0 = new DxfSpline.Class15.Class899();

        private Class899()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          throw new NotImplementedException();
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          throw new NotImplementedException();
        }

        public string Description
        {
          get
          {
            return Class881.DxfSpline_ControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }
    }
  }
}
