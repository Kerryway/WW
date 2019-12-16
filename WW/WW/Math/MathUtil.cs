// Decompiled with JetBrains decompiler
// Type: WW.Math.MathUtil
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;

namespace WW.Math
{
  public static class MathUtil
  {
    private static readonly double[] double_0 = new double[0];
    private static readonly ComplexD complexD_0 = ComplexD.One;
    private static readonly ComplexD complexD_1 = ComplexD.One;
    private static readonly ComplexD complexD_2 = new ComplexD(-0.5, 0.5 * System.Math.Sqrt(3.0));
    private static readonly ComplexD complexD_3 = MathUtil.complexD_2.GetConjugate();
    private static readonly ComplexD complexD_4 = new ComplexD(-0.5, -0.5 * System.Math.Sqrt(3.0));
    private static readonly ComplexD complexD_5 = MathUtil.complexD_4.GetConjugate();

    public static void Swap<T>(ref T a, ref T b)
    {
      T obj = a;
      a = b;
      b = obj;
    }

    public static void Swap(ref double a, ref double b)
    {
      double num = a;
      a = b;
      b = num;
    }

    public static void Swap(ref float a, ref float b)
    {
      float num = a;
      a = b;
      b = num;
    }

    public static bool AreApproxEqual(double a, double b)
    {
      return System.Math.Abs(a - b) <= 8.88178419700125E-16;
    }

    public static bool AreApproxEqual(double a, double b, double tolerance)
    {
      return System.Math.Abs(a - b) <= tolerance;
    }

    public static bool AreApproxEqual(float a, float b)
    {
      return (double) System.Math.Abs(a - b) <= 4.76837158203125E-07;
    }

    public static bool AreApproxEqual(float a, float b, float tolerance)
    {
      return (double) System.Math.Abs(a - b) <= (double) tolerance;
    }

    public static int Compare(double a, double b)
    {
      return a >= b ? (a <= b ? 0 : 1) : -1;
    }

    public static int Compare(float a, float b)
    {
      return (double) a >= (double) b ? ((double) a <= (double) b ? 0 : 1) : -1;
    }

    public static int Compare(short a, short b)
    {
      return (int) a >= (int) b ? ((int) a <= (int) b ? 0 : 1) : -1;
    }

    public static int Compare(ushort a, ushort b)
    {
      return (int) a >= (int) b ? ((int) a <= (int) b ? 0 : 1) : -1;
    }

    public static int Compare(int a, int b)
    {
      return a >= b ? (a <= b ? 0 : 1) : -1;
    }

    public static int Compare(uint a, uint b)
    {
      return a >= b ? (a <= b ? 0 : 1) : -1;
    }

    public static int Compare(long a, long b)
    {
      return a >= b ? (a <= b ? 0 : 1) : -1;
    }

    public static int Compare(ulong a, ulong b)
    {
      return a >= b ? (a <= b ? 0 : 1) : -1;
    }

    public static double NormalizeAnglePi(double angle)
    {
      double num = angle;
      if (num < -1.0 * System.Math.PI)
        num -= 2.0 * System.Math.PI * System.Math.Floor((num + System.Math.PI) / (2.0 * System.Math.PI));
      else if (num > System.Math.PI)
        num -= 2.0 * System.Math.PI * System.Math.Ceiling((num - System.Math.PI) / (2.0 * System.Math.PI));
      return num;
    }

    public static double NormalizeAngleTwoPi(double angle)
    {
      double num = angle;
      if (num < 0.0)
        num -= 2.0 * System.Math.PI * System.Math.Floor(num / (2.0 * System.Math.PI));
      else if (num > 2.0 * System.Math.PI)
        num -= 2.0 * System.Math.PI * System.Math.Floor(num / (2.0 * System.Math.PI));
      return num;
    }

    public static double GetAngleDifference(double angle, double referenceAngle)
    {
      if (angle < 0.0 || angle > 2.0 * System.Math.PI)
        throw new ArgumentException("Angle must be in the 0 to 2π range.");
      if (referenceAngle < 0.0 || referenceAngle > 2.0 * System.Math.PI)
        throw new ArgumentException("Angle must be in the 0 to 2π range.");
      double num = angle - referenceAngle;
      if (num < 0.0)
        num += 2.0 * System.Math.PI;
      return num;
    }

    public static double RoundHalfUp(double d)
    {
      return System.Math.Floor(d + 0.5);
    }

    public static double[] DoGaussianElimination(IList<double[]> augmentedCoefficientMatrix)
    {
      return MathUtil.DoGaussianElimination(augmentedCoefficientMatrix, 8.88178419700125E-16);
    }

    public static double[] DoGaussianElimination(
      IList<double[]> augmentedCoefficientMatrix,
      double precision)
    {
      int count = augmentedCoefficientMatrix.Count;
      if (count == 0)
        return (double[]) null;
      if (augmentedCoefficientMatrix[0].Length != count + 1)
        throw new ArgumentException("Number of columns must be number of rows + 1.");
      for (int index1 = 0; index1 < count - 1; ++index1)
      {
        int index2 = index1;
        while (index2 < count && MathUtil.AreApproxEqual(0.0, augmentedCoefficientMatrix[index2][index1], precision))
          ++index2;
        if (index2 == count)
          return (double[]) null;
        if (index2 > index1)
        {
          double[] numArray = augmentedCoefficientMatrix[index1];
          augmentedCoefficientMatrix[index1] = augmentedCoefficientMatrix[index2];
          augmentedCoefficientMatrix[index2] = numArray;
        }
        int index3 = index1 + 1;
        double num1 = augmentedCoefficientMatrix[index1][index1];
        for (; index3 < count; ++index3)
        {
          double num2 = augmentedCoefficientMatrix[index3][index1] / num1;
          for (int index4 = index1 + 1; index4 <= count; ++index4)
            augmentedCoefficientMatrix[index3][index4] -= num2 * augmentedCoefficientMatrix[index1][index4];
        }
      }
      if (MathUtil.AreApproxEqual(0.0, augmentedCoefficientMatrix[count - 1][count - 1], precision))
        return (double[]) null;
      double[] numArray1 = new double[count];
      for (int index1 = count - 1; index1 >= 0; --index1)
      {
        double num = 0.0;
        for (int index2 = index1 + 1; index2 < count; ++index2)
          num += augmentedCoefficientMatrix[index1][index2] * numArray1[index2];
        numArray1[index1] = 1.0 / augmentedCoefficientMatrix[index1][index1] * (augmentedCoefficientMatrix[index1][count] - num);
      }
      return numArray1;
    }

    public static void GetQuadraticPolynomialRoots(IList<double> coefficients, IList<double> roots)
    {
      double coefficient1 = coefficients[2];
      double coefficient2 = coefficients[1];
      double coefficient3 = coefficients[0];
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

    public static IList<double> GetCubicPolynomialRoots(IList<double> coefficients)
    {
      if (coefficients == null)
        throw new ArgumentNullException(nameof (coefficients));
      if (coefficients.Count < 4)
        throw new ArgumentException("The coefficients should at least have length 4.");
      double coefficient1 = coefficients[3];
      if (coefficient1 == 0.0)
        throw new ArgumentException("Coefficient a is zero.");
      double coefficient2 = coefficients[2];
      double coefficient3 = coefficients[1];
      double coefficient4 = coefficients[0];
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
          num6 * (coefficient2 + ComplexD.MultiplyAndGetReal(MathUtil.complexD_2, v) + ComplexD.MultiplyAndGetReal(MathUtil.complexD_3, conjugate)),
          num6 * (coefficient2 + ComplexD.MultiplyAndGetReal(MathUtil.complexD_4, v) + ComplexD.MultiplyAndGetReal(MathUtil.complexD_5, conjugate))
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

    public static double GetDividedDifference(IList<Point2D> points, int offset, int count)
    {
      if (count < 1)
        throw new ArgumentException("Parameter count should be 2 or greater.");
      if (count != 2)
        return (MathUtil.GetDividedDifference(points, offset, count - 1) - MathUtil.GetDividedDifference(points, offset + 1, count - 1)) / (points[offset].X - points[offset + count - 1].X);
      Vector2D vector2D = points[offset] - points[offset + 1];
      return vector2D.Y / vector2D.X;
    }

    public static ComplexD GetDividedDifference(
      IList<Pair<ComplexD>> points,
      int offset,
      int count)
    {
      if (count < 1)
        throw new ArgumentException("Parameter count should be 2 or greater.");
      if (count != 2)
        return (MathUtil.GetDividedDifference(points, offset, count - 1) - MathUtil.GetDividedDifference(points, offset + 1, count - 1)) / (points[offset].First - points[offset + count - 1].First);
      Pair<ComplexD> point1 = points[offset];
      Pair<ComplexD> point2 = points[offset + 1];
      return (point1.Second - point2.Second) / (point1.First - point2.First);
    }

    public static void GetPolynomialRoots(
      IList<double> coefficients,
      IList<double> roots,
      double epsilon)
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
        double rootBoundsRadius = MathUtil.GetPolynomialSingleRootBoundsRadius(coefficients);
        Pair<ComplexD> pair1 = new Pair<ComplexD>((ComplexD) (-rootBoundsRadius), (ComplexD) MathUtil.EvaluatePolynomial(coefficients, -rootBoundsRadius));
        Pair<ComplexD> pair2 = new Pair<ComplexD>((ComplexD) 0.0, (ComplexD) MathUtil.EvaluatePolynomial(coefficients, 0.0));
        Pair<ComplexD> pair3 = new Pair<ComplexD>((ComplexD) rootBoundsRadius, (ComplexD) double.NaN);
        double num1 = epsilon > 0.0 ? epsilon : -epsilon * rootBoundsRadius;
        double num2 = num1 * num1;
        int num3;
        ComplexD first1;
        for (num3 = 50; (pair3.First - pair2.First).GetModulusSquared() > num2 && num3 > 0; pair3 = new Pair<ComplexD>(first1, new ComplexD(double.NaN)))
        {
          --num3;
          Pair<ComplexD> pair4 = new Pair<ComplexD>(pair3.First, MathUtil.EvaluatePolynomial(coefficients, pair3.First));
          ComplexD dividedDifference = MathUtil.GetDividedDifference((IList<Pair<ComplexD>>) new Pair<ComplexD>[3]{ pair1, pair2, pair4 }, 0, 3);
          ComplexD complexD1 = MathUtil.GetDividedDifference((IList<Pair<ComplexD>>) new Pair<ComplexD>[2]{ pair2, pair4 }, 0, 2) + dividedDifference * (pair4.First - pair2.First);
          ComplexD second = pair4.Second;
          ComplexD complexD2 = complexD1 * complexD1 - 4.0 * dividedDifference * second;
          first1 = new ComplexD(double.NaN);
          if (complexD2.Imaginary == 0.0)
          {
            if (complexD2.Real >= 0.0)
            {
              first1 = second.Imaginary != 0.0 || complexD1.Imaginary != 0.0 ? pair4.First - 2.0 * second / (complexD1 + (ComplexD) ((double) System.Math.Sign(complexD1.Real) * System.Math.Sqrt(complexD2.Real))) : pair4.First - (ComplexD) (2.0 * second.Real / (complexD1.Real + (double) System.Math.Sign(complexD1.Real) * System.Math.Sqrt(complexD2.Real)));
            }
            else
            {
              ComplexD complexD3 = ComplexD.Sqrt(complexD2.Real);
              ComplexD complexD4 = complexD1 + complexD3;
              ComplexD complexD5 = complexD1 - complexD3;
              ComplexD complexD6 = complexD4.GetModulusSquared() >= complexD5.GetModulusSquared() ? complexD4 : complexD5;
              first1 = pair4.First - 2.0 * second / complexD6;
            }
          }
          else
          {
            ComplexD sqrt = complexD2.GetSqrt();
            ComplexD complexD3 = complexD1 + sqrt;
            ComplexD complexD4 = complexD1 - sqrt;
            ComplexD complexD5 = complexD3.GetModulusSquared() >= complexD4.GetModulusSquared() ? complexD3 : complexD4;
            first1 = pair4.First - 2.0 * second / complexD5;
          }
          pair1 = pair2;
          pair2 = pair4;
        }
        if (num3 <= 0)
          return;
        if (MathUtil.AreApproxEqual(pair3.First.Imaginary, 0.0, num1))
        {
          double real = pair3.First.Real;
          roots.Add(real);
          IList<double> coefficients1 = MathUtil.DeflatePolynomial(coefficients, real);
          if (epsilon > 0.0)
          {
            while (coefficients1.Count > 1 && MathUtil.AreApproxEqual(MathUtil.EvaluatePolynomial(coefficients1, real), 0.0, epsilon))
              coefficients1 = MathUtil.DeflatePolynomial(coefficients1, real);
          }
          else
          {
            double largestTerm;
            while (coefficients1.Count > 1 && MathUtil.AreApproxEqual(MathUtil.EvaluatePolynomial(coefficients1, real, out largestTerm), 0.0, -epsilon * largestTerm))
              coefficients1 = MathUtil.DeflatePolynomial(coefficients1, real);
          }
          MathUtil.GetPolynomialRoots(coefficients1, roots, num1);
        }
        else
        {
          ComplexD first2 = pair3.First;
          double real = first2.Real;
          double imaginary = first2.Imaginary;
          double a1 = -2.0 * real;
          double a0 = real * real + imaginary * imaginary;
          MathUtil.GetPolynomialRoots(MathUtil.DeflatePolynomial(coefficients, a0, a1), roots, num1);
        }
      }
    }

    public static double EvaluatePolynomial(IList<double> coefficients, double x)
    {
      int num1 = coefficients.Count - 1;
      IList<double> doubleList = coefficients;
      int index1 = num1;
      int index2 = index1 - 1;
      double num2 = doubleList[index1];
      for (; index2 >= 0; --index2)
        num2 = x * num2 + coefficients[index2];
      return num2;
    }

    public static double EvaluatePolynomial(
      IList<double> coefficients,
      double x,
      out double largestTerm)
    {
      int num1 = coefficients.Count - 1;
      IList<double> doubleList = coefficients;
      int index1 = num1;
      int index2 = index1 - 1;
      double num2 = doubleList[index1];
      largestTerm = 0.0;
      for (; index2 >= 0; --index2)
      {
        double num3 = x * num2;
        largestTerm = System.Math.Max(System.Math.Abs(num3), largestTerm);
        num2 = num3 + coefficients[index2];
      }
      largestTerm = System.Math.Max(System.Math.Abs(coefficients[0]), largestTerm);
      return num2;
    }

    public static ComplexD EvaluatePolynomial(IList<double> coefficients, ComplexD x)
    {
      int num = coefficients.Count - 1;
      IList<double> doubleList = coefficients;
      int index1 = num;
      int index2 = index1 - 1;
      ComplexD complexD = (ComplexD) doubleList[index1];
      for (; index2 >= 0; --index2)
        complexD = x * complexD + (ComplexD) coefficients[index2];
      return complexD;
    }

    public static double EvaluatePolynomialAndFirstDerivative(
      IList<double> coefficients,
      double x,
      out double firstDerivative)
    {
      int index1 = coefficients.Count - 1;
      double coefficient1 = coefficients[index1];
      firstDerivative = coefficient1 * (double) index1;
      double num = coefficient1;
      int index2;
      for (index2 = index1 - 1; index2 > 0; --index2)
      {
        double coefficient2 = coefficients[index2];
        firstDerivative = x * firstDerivative + coefficient2 * (double) index2;
        num = x * num + coefficient2;
      }
      if (index2 == 0)
      {
        double coefficient2 = coefficients[index2];
        num = x * num + coefficient2;
      }
      return num;
    }

    public static ComplexD EvaluatePolynomialAndFirstDerivative(
      IList<double> coefficients,
      ComplexD x,
      out ComplexD firstDerivative)
    {
      int index1 = coefficients.Count - 1;
      double coefficient1 = coefficients[index1];
      firstDerivative = (ComplexD) (coefficient1 * (double) index1);
      ComplexD complexD = (ComplexD) coefficient1;
      int index2;
      for (index2 = index1 - 1; index2 > 0; --index2)
      {
        double coefficient2 = coefficients[index2];
        firstDerivative = x * firstDerivative + (ComplexD) (coefficient2 * (double) index2);
        complexD = x * complexD + (ComplexD) coefficient2;
      }
      if (index2 == 0)
      {
        double coefficient2 = coefficients[index2];
        complexD = x * complexD + (ComplexD) coefficient2;
      }
      return complexD;
    }

    public static double GetPolynomialSingleRootBoundsRadius(IList<double> coefficients)
    {
      int index = coefficients.Count - 1;
      double val1 = System.Math.Pow(System.Math.Abs(coefficients[0] / coefficients[index]), 1.0 / (double) index);
      if (coefficients[1] != 0.0)
        val1 = System.Math.Min(val1, (double) index * System.Math.Abs(coefficients[0] / coefficients[1]));
      return val1;
    }

    public static IList<double> DeflatePolynomial(IList<double> coefficients, double root)
    {
      int length = coefficients.Count - 1;
      double[] numArray = new double[length];
      IList<double> doubleList = coefficients;
      int index1 = length;
      int index2 = index1 - 1;
      double num = doubleList[index1];
      numArray[index2] = num;
      while (index2 > 0)
      {
        num = root * num + coefficients[index2--];
        numArray[index2] = num;
      }
      return (IList<double>) numArray;
    }

    public static IList<double> DeflatePolynomial(
      IList<double> coefficients,
      double a0,
      double a1)
    {
      a0 = -a0;
      a1 = -a1;
      int num1 = coefficients.Count - 1;
      int num2 = num1 - 2;
      double[] numArray1 = new double[num1 - 1];
      IList<double> doubleList = coefficients;
      int index1 = num1;
      int num3 = index1 - 1;
      double num4 = doubleList[index1];
      double num5 = 0.0;
      double[] numArray2 = numArray1;
      int index2 = num2;
      int num6 = index2 - 1;
      double num7 = num4;
      numArray2[index2] = num7;
      while (num3 > 1)
      {
        double num8 = a0 * num5 + a1 * num4 + coefficients[num3--];
        numArray1[num6--] = num8;
        num5 = num4;
        num4 = num8;
      }
      return (IList<double>) numArray1;
    }

    public static double GetPolynomialAllRootBoundsRadius(IList<double> coefficients)
    {
      double num1 = 0.0;
      for (int index = coefficients.Count - 2; index >= 0; --index)
      {
        double num2 = System.Math.Abs(coefficients[index]);
        if (num2 > num1)
          num1 = num2;
      }
      return 1.0 + System.Math.Abs(num1 / coefficients[coefficients.Count - 1]);
    }

    public static IList<double> GetPolynomialCoefficientsFromNegatedRoots(
      IList<double> negatedRoots)
    {
      double[] numArray = new double[negatedRoots.Count + 1];
      numArray[negatedRoots.Count] = 1.0;
      numArray[0] = negatedRoots[0];
      for (int index1 = 1; index1 < negatedRoots.Count; ++index1)
      {
        numArray[index1] = 1.0;
        double negatedRoot = negatedRoots[index1];
        for (int index2 = index1; index2 > 0; --index2)
          numArray[index2] = numArray[index2] * negatedRoot + numArray[index2 - 1];
        numArray[0] = numArray[0] * negatedRoot;
      }
      return (IList<double>) numArray;
    }

    public static IList<double> GetPolynomialCoefficientsFromNegatedRoots(
      IList<double> negatedRoots,
      double multiplier)
    {
      IList<double> fromNegatedRoots = MathUtil.GetPolynomialCoefficientsFromNegatedRoots(negatedRoots);
      for (int index1 = 0; index1 < fromNegatedRoots.Count; ++index1)
      {
        IList<double> doubleList;
        int index2;
        (doubleList = fromNegatedRoots)[index2 = index1] = doubleList[index2] * multiplier;
      }
      return fromNegatedRoots;
    }
  }
}
