// Decompiled with JetBrains decompiler
// Type: ns26.Class244
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns22;
using ns7;
using ns9;
using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Math;

namespace ns26
{
  internal class Class244 : Class242
  {
    private Class883.Enum34 enum34_0;
    private SplineCurve3D splineCurve3D_0;
    private double[] double_0;
    private int[] int_0;

    public override string imethod_2(int version)
    {
      return "";
    }

    public override void vmethod_0(Interface8 reader)
    {
      Class647.Enum23 enum23 = Class647.smethod_0(reader);
      if (enum23 == Class647.Enum23.const_2)
        return;
      int degree = reader.imethod_5();
      this.enum34_0 = Class883.smethod_0(reader);
      int length1 = reader.imethod_5();
      this.double_0 = new double[length1];
      this.int_0 = new int[length1];
      double[] knots = new double[length1 * degree + 2];
      int length2 = 0;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        double num1 = reader.imethod_8();
        this.double_0[index1] = num1;
        int num2 = reader.imethod_5();
        this.int_0[index1] = num2;
        if (index1 == 0 || index1 == length1 - 1)
          ++num2;
        for (int index2 = 0; index2 < num2; ++index2)
          knots[length2++] = num1;
      }
      if (length2 < knots.Length)
      {
        double[] numArray = new double[length2];
        Array.Copy((Array) knots, 0, (Array) numArray, 0, length2);
        knots = numArray;
      }
      Point3D[] controlPoints = new Point3D[length2 - degree - 1];
      double[] weights = new double[length2 - degree - 1];
      for (int index = 0; index < controlPoints.Length; ++index)
      {
        controlPoints[index] = Class794.smethod_15(reader);
        if (enum23 == Class647.Enum23.const_1)
          weights[index] = reader.imethod_8();
      }
      if (enum23 == Class647.Enum23.const_1)
        this.splineCurve3D_0 = new SplineCurve3D(degree, knots, controlPoints, weights);
      else
        this.splineCurve3D_0 = new SplineCurve3D(degree, knots, controlPoints);
    }

    public override void vmethod_1(Interface9 writer)
    {
      if (this.splineCurve3D_0 == null)
      {
        Class647.smethod_1(writer, Class647.Enum23.const_2);
      }
      else
      {
        if (this.splineCurve3D_0.Weights == null)
          Class647.smethod_1(writer, Class647.Enum23.const_0);
        else
          Class647.smethod_1(writer, Class647.Enum23.const_1);
        int degree = this.splineCurve3D_0.KnotInfo.Degree;
        writer.imethod_4(degree);
        Class883.smethod_1(writer, this.enum34_0);
        int length = this.double_0.Length;
        writer.imethod_4(length);
        writer.imethod_15();
        for (int index = 0; index < length; ++index)
        {
          writer.imethod_7(this.double_0[index]);
          writer.imethod_4(this.int_0[index]);
          if ((index + 1) % 5 == 0)
            writer.imethod_15();
        }
        if (length % 5 == 0)
          writer.imethod_15();
        for (int index = 0; index < this.splineCurve3D_0.ControlPoints.Length; ++index)
        {
          writer.imethod_7(this.splineCurve3D_0.ControlPoints[index].X);
          writer.imethod_7(this.splineCurve3D_0.ControlPoints[index].Y);
          writer.imethod_7(this.splineCurve3D_0.ControlPoints[index].Z);
          if (this.splineCurve3D_0.Weights != null)
            writer.imethod_7(this.splineCurve3D_0.Weights[index]);
          writer.imethod_15();
        }
      }
    }

    public override void imethod_3(
      Class95 loop,
      Class88 curve,
      Class107 coedge,
      Class917 approximation,
      Class258 accuracy)
    {
      double fitTolerance;
      if (!accuracy.Absolute)
      {
        Bounds3D controlPolygonBounds = this.splineCurve3D_0.ControlPolygonBounds;
        fitTolerance = accuracy.method_0(controlPolygonBounds.Delta.GetLength());
      }
      else
        fitTolerance = accuracy.Epsilon;
      Point3D[] fitPoints = this.splineCurve3D_0.CreateFitPoints(fitTolerance, 0.01);
      approximation.method_5((IEnumerable<Point3D>) fitPoints, curve.Reversed ^ coedge.DirectionReversed);
    }
  }
}
