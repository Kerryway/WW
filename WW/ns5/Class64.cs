// Decompiled with JetBrains decompiler
// Type: ns5.Class64
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using WW.Math;

namespace ns5
{
  internal class Class64
  {
    private static readonly double double_0 = System.Math.Pow(2.0, -106.0);
    private static readonly ComplexD complexD_0 = ComplexD.One;
    private static readonly ComplexD complexD_1 = ComplexD.One;
    private static readonly ComplexD complexD_2 = new ComplexD(-0.5, 0.5 * System.Math.Sqrt(3.0));
    private static readonly ComplexD complexD_3 = Class64.complexD_2.GetConjugate();
    private static readonly ComplexD complexD_4 = new ComplexD(-0.5, -0.5 * System.Math.Sqrt(3.0));
    private static readonly ComplexD complexD_5 = Class64.complexD_4.GetConjugate();

    public static void smethod_0(IList<double> coefficients, IList<double> roots, double epsilon)
    {
      if (roots == null)
        throw new ArgumentNullException(nameof (roots));
      if (coefficients.Count < 2)
        throw new ArgumentException("Number of coefficients must be 2 or greater.");
      if (coefficients[coefficients.Count - 1] == 0.0)
        throw new ArgumentException("The highest coefficient is expected to be non-zero.");
      if (epsilon == 0.0)
        epsilon = -1E-08;
      if (coefficients.Count == 2)
        roots.Add(-coefficients[0] / coefficients[1]);
      else if (coefficients.Count == 3)
        MathUtil.GetQuadraticPolynomialRoots(coefficients, roots);
      else if (coefficients.Count == 4)
      {
        IList<double> cubicPolynomialRoots = MathUtil.GetCubicPolynomialRoots(coefficients);
        for (int index = 0; index < cubicPolynomialRoots.Count; ++index)
          roots.Add(cubicPolynomialRoots[index]);
      }
      else
      {
        int num1 = 0;
        int n = coefficients.Count - 1;
        double[] numArray1 = new double[coefficients.Count];
        for (int index = n; index >= 0; --index)
          numArray1[index] = coefficients[n - index];
        double[] numArray2 = new double[coefficients.Count - 1];
        while (n > 3)
        {
          for (int index = 0; index < n; ++index)
            numArray2[index] = numArray1[index] * (double) (n - index);
          double num2 = Class64.smethod_3(n, (IList<double>) numArray1);
          ComplexD complexD1 = ComplexD.Zero;
          double num3 = numArray1[n] * numArray1[n];
          double num4 = num3;
          ComplexD complexD2 = (ComplexD) numArray1[n - 1];
          ComplexD complexD3 = (ComplexD) (numArray1[n - 1] == 0.0 ? 1.0 : -numArray1[n] / numArray1[n - 1]);
          complexD3 = (ComplexD) ((double) System.Math.Sign(complexD3.Real) * num2);
          ComplexD dz = complexD3;
          ComplexD complexD4 = Class64.smethod_5(n, (IList<double>) numArray1, complexD3);
          double num5 = complexD4.GetModulusSquared();
          double num6 = 2.5 * num2;
          double modulus = dz.GetModulus();
          double num7 = 4.0 * (double) n * (double) n * num3 * Class64.double_0;
          bool flag1 = true;
          int num8;
          for (num8 = 0; (complexD3.Real + dz.Real != complexD3.Real || complexD3.Imaginary + dz.Imaginary != complexD3.Imaginary) && (num5 > num7 && num8 < 50); ++num8)
          {
            ComplexD complexD5 = Class64.smethod_5(n - 1, (IList<double>) numArray2, complexD3);
            double modulusSquared1 = complexD5.GetModulusSquared();
            if (modulusSquared1 == 0.0)
            {
              dz = Class64.smethod_4(dz, 5.0);
            }
            else
            {
              dz = new ComplexD((complexD4.Real * complexD5.Real + complexD4.Imaginary * complexD5.Imaginary) / modulusSquared1, (complexD4.Imaginary * complexD5.Real - complexD4.Real * complexD5.Imaginary) / modulusSquared1);
              double num9 = (complexD2 - complexD5).GetModulusSquared() / (complexD1 - complexD3).GetModulusSquared();
              flag1 = num5 != num4 || num9 * num5 > 0.25 * modulusSquared1 * modulusSquared1;
              modulus = dz.GetModulus();
              if (modulus > num6)
                dz = Class64.smethod_4(dz, num6 / modulus);
              num6 = modulus * 5.0;
            }
            complexD1 = complexD3;
            double num10 = num5;
            complexD2 = complexD4;
            bool flag2 = true;
            while (flag2)
            {
              flag2 = false;
              complexD3 = complexD1 - dz;
              complexD4 = Class64.smethod_5(n, (IList<double>) numArray1, complexD3);
              num4 = num5 = complexD4.GetModulusSquared();
              if (flag1)
              {
                ComplexD z = complexD3;
                int num9 = 1;
                bool flag3 = num5 > num10;
                for (; num9 <= n; ++num9)
                {
                  if (flag3)
                  {
                    dz *= 0.5;
                    z = complexD1 - dz;
                  }
                  else
                    z -= dz;
                  ComplexD complexD6 = Class64.smethod_5(n, (IList<double>) numArray1, z);
                  double modulusSquared2 = complexD6.GetModulusSquared();
                  if (modulusSquared2 < num5)
                  {
                    num5 = modulusSquared2;
                    complexD4 = complexD6;
                    complexD3 = z;
                    if (flag3 && num9 == 2)
                    {
                      dz = Class64.smethod_4(dz, 0.5);
                      complexD3 = complexD1 - dz;
                      complexD4 = Class64.smethod_5(n, (IList<double>) numArray1, complexD3);
                      num5 = complexD4.GetModulusSquared();
                      break;
                    }
                  }
                  else
                    break;
                }
              }
              else
                num7 = Class64.smethod_6(n, (IList<double>) numArray1, complexD3);
              if (modulus < complexD3.GetModulus() * Class64.double_0 && num5 >= num10)
              {
                complexD3 = complexD1;
                dz = Class64.smethod_4(dz, 0.5);
                if (complexD3 + dz != complexD3)
                  flag2 = true;
              }
            }
          }
          if (num8 >= 50)
            --num1;
          ComplexD real = (ComplexD) complexD3.Real;
          if ((complexD4 = Class64.smethod_5(n, (IList<double>) numArray1, real)).GetModulusSquared() <= num5)
          {
            roots.Add(complexD3.Real);
            n = Class64.smethod_7(n, (IList<double>) numArray1, complexD3.Real);
          }
          else
            n = Class64.smethod_8(n, (IList<double>) numArray1, complexD3);
        }
        if (n == 1)
          roots.Add(-numArray1[1] / numArray1[0]);
        else if (n == 2)
        {
          Class64.smethod_1((IList<double>) numArray1, roots);
        }
        else
        {
          if (n != 3)
            return;
          IList<double> doubleList = Class64.smethod_2((IList<double>) numArray1);
          for (int index = 0; index < doubleList.Count; ++index)
            roots.Add(doubleList[index]);
        }
      }
    }

    private static void smethod_1(IList<double> coefficients, IList<double> roots)
    {
      double coefficient1 = coefficients[0];
      double coefficient2 = coefficients[1];
      double coefficient3 = coefficients[2];
      double d = coefficient2 * coefficient2 - 4.0 * coefficient1 * coefficient3;
      if (d < 0.0)
        return;
      if (d == 0.0)
      {
        roots.Add(-coefficient2 / 2.0 * coefficient1);
      }
      else
      {
        double num1 = System.Math.Sqrt(d);
        double num2 = 2.0 * coefficient1;
        roots.Add((-coefficient2 - num1) / num2);
        roots.Add((-coefficient2 + num1) / num2);
      }
    }

    private static IList<double> smethod_2(IList<double> coefficients)
    {
      double coefficient1 = coefficients[0];
      if (coefficient1 == 0.0)
        throw new ArgumentException("Coefficient a is zero.");
      double coefficient2 = coefficients[1];
      double coefficient3 = coefficients[2];
      double coefficient4 = coefficients[3];
      double num1 = coefficient2 * coefficient2;
      double num2 = coefficient1 * coefficient3;
      double num3 = coefficient1 * coefficient4;
      double a = num1 - 3.0 * num2;
      double num4 = coefficient2 * (2.0 * num1 - 9.0 * num2) + 27.0 * coefficient1 * num3;
      double d = num4 * num4 - 4.0 * a * a * a;
      double[] numArray;
      if (d < -8.88178419700125E-16)
      {
        double num5 = System.Math.Sqrt(-d);
        ComplexD complexD = new ComplexD(0.5 * num4, 0.5 * num5);
        ComplexD v = ComplexD.FromModulusAndArgument(System.Math.Pow(complexD.GetModulusSquared(), 1.0 / 6.0), 1.0 / 3.0 * complexD.GetArgument());
        ComplexD conjugate = v.GetConjugate();
        double num6 = -1.0 / (3.0 * coefficient1);
        numArray = new double[3]
        {
          num6 * (coefficient2 + v.Real + conjugate.Real),
          num6 * (coefficient2 + ComplexD.MultiplyAndGetReal(Class64.complexD_2, v) + ComplexD.MultiplyAndGetReal(Class64.complexD_3, conjugate)),
          num6 * (coefficient2 + ComplexD.MultiplyAndGetReal(Class64.complexD_4, v) + ComplexD.MultiplyAndGetReal(Class64.complexD_5, conjugate))
        };
      }
      else if (d > 8.88178419700125E-16)
      {
        double num5 = System.Math.Sqrt(d);
        double x1 = 0.5 * (num4 + num5);
        double x2 = 0.5 * (num4 - num5);
        double num6 = x1 >= 0.0 ? System.Math.Pow(x1, 1.0 / 3.0) : -System.Math.Pow(-x1, 1.0 / 3.0);
        double num7 = x2 >= 0.0 ? System.Math.Pow(x2, 1.0 / 3.0) : -System.Math.Pow(-x2, 1.0 / 3.0);
        numArray = new double[1]
        {
          -(coefficient2 + num6 + num7) / (3.0 * coefficient1)
        };
      }
      else if (MathUtil.AreApproxEqual(a, 0.0, 8.88178419700125E-16))
        numArray = new double[1]
        {
          -coefficient2 / (3.0 * coefficient1)
        };
      else
        numArray = new double[2]
        {
          (9.0 * num3 - coefficient2 * coefficient3) / (2.0 * a),
          (4.0 * coefficient2 * num2 - 9.0 * coefficient1 * num3 - coefficient2 * num1) / (coefficient1 * a)
        };
      return (IList<double>) numArray;
    }

    private static double smethod_3(int n, IList<double> a)
    {
      double num1 = System.Math.Log(System.Math.Abs(a[n]));
      double num2 = System.Math.Exp((num1 - System.Math.Log(System.Math.Abs(a[0]))) / (double) n);
      for (int index = 1; index < n; ++index)
      {
        if (a[index] != 0.0)
        {
          double num3 = System.Math.Exp((num1 - System.Math.Log(System.Math.Abs(a[index]))) / (double) (n - index));
          if (num3 < num2)
            num2 = num3;
        }
      }
      return 0.5 * num2;
    }

    private static ComplexD smethod_4(ComplexD dz, double scaleFactor)
    {
      return new ComplexD((dz.Real * 0.6 - dz.Imaginary * 0.8) * scaleFactor, (dz.Real * 0.8 + dz.Imaginary * 0.6) * scaleFactor);
    }

    private static ComplexD smethod_5(int n, IList<double> a, ComplexD z)
    {
      double num1 = -2.0 * z.Real;
      double modulusSquared = z.GetModulusSquared();
      double num2 = 0.0;
      double num3 = a[0];
      for (int index = 1; index < n; ++index)
      {
        double num4 = a[index] - num1 * num3 - modulusSquared * num2;
        num2 = num3;
        num3 = num4;
      }
      return new ComplexD(a[n] + z.Real * num3 - modulusSquared * num2, z.Imaginary * num3);
    }

    private static double smethod_6(int n, IList<double> a, ComplexD z)
    {
      double num1 = -2.0 * z.Real;
      double modulusSquared = z.GetModulusSquared();
      double num2 = System.Math.Sqrt(modulusSquared);
      double num3 = 0.0;
      double num4 = a[0];
      double num5 = System.Math.Abs(num4) * (7.0 / 9.0);
      for (int index = 1; index < n; ++index)
      {
        double num6 = a[index] - num1 * num4 - modulusSquared * num3;
        num3 = num4;
        num4 = num6;
        num5 = num2 * num5 + System.Math.Abs(num6);
      }
      double num7 = a[n] + z.Real * num4 - modulusSquared * num3;
      double num8 = (9.0 * (num2 * num5 + System.Math.Abs(num7)) - 7.0 * (System.Math.Abs(num7) + System.Math.Abs(num4) * num2) + System.Math.Abs(z.Real) * System.Math.Abs(num4) * 2.0) * Class64.double_0;
      return num8 * num8;
    }

    private static int smethod_7(int n, IList<double> a, double root)
    {
      double num = 0.0;
      for (int index = 0; index < n; ++index)
      {
        num = num * root + a[index];
        a[index] = num;
      }
      return n - 1;
    }

    private static int smethod_8(int n, IList<double> a, ComplexD root)
    {
      double num = -2.0 * root.Real;
      double modulusSquared = root.GetModulusSquared();
      IList<double> doubleList;
      (doubleList = a)[1] = doubleList[1] - num * a[0];
      for (int index = 2; index < n - 1; ++index)
        a[index] = a[index] - num * a[index - 1] - modulusSquared * a[index - 2];
      return n - 2;
    }
  }
}
