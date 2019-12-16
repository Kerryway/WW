// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.NurbsUtilD
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;

namespace WW.Math.Geometry
{
  public static class NurbsUtilD
  {
    private static readonly double[] double_0 = new double[0];

    public static double[,] BSplineToPowerBasis(int degree, int knotSpanIndex, double[] knots)
    {
      int length = degree + 1;
      double[,] numArray = new double[length, length];
      numArray[0, 0] = 1.0;
      int num1 = knotSpanIndex - 1;
      int num2 = knotSpanIndex;
      for (int index1 = 1; index1 < length; ++index1)
      {
        int index2 = num2;
        double knot1 = knots[index2];
        double num3 = knots[index2 + index1] - knot1;
        double num4 = 0.0;
        if (num3 != 0.0)
          num4 = 1.0 / num3;
        if (num4 != 0.0)
        {
          int index3 = index1;
          int index4 = index2 - num1;
          int index5 = index2 - num1 - 1;
          if (index3 > 0)
          {
            numArray[index4, index3] = num4 * numArray[index5, index3 - 1];
            for (int index6 = index3 - 1; index6 > 0; --index6)
              numArray[index4, index6] = num4 * (numArray[index5, index6 - 1] - knot1 * numArray[index5, index6]);
          }
          numArray[index4, 0] = -num4 * knot1 * numArray[index5, 0];
        }
        int index7;
        for (index7 = index2 - 1; index7 > num1; --index7)
        {
          double knot2 = knots[index7];
          double knot3 = knots[index7 + 1];
          double knot4 = knots[index7 + index1];
          double knot5 = knots[index7 + index1 + 1];
          double num5 = knot4 - knot2;
          double num6 = 0.0;
          if (num5 != 0.0)
            num6 = 1.0 / num5;
          double num7 = knot5 - knot3;
          double num8 = 0.0;
          if (num7 != 0.0)
            num8 = 1.0 / num7;
          if (num6 != 0.0 || num8 != 0.0)
          {
            int index3 = index1;
            int index4 = index7 - num1;
            int index5 = index4 - 1;
            if (index3 > 0)
            {
              numArray[index4, index3] = num6 * numArray[index5, index3 - 1] - num8 * numArray[index4, index3 - 1];
              for (int index6 = index3 - 1; index6 > 0; --index6)
                numArray[index4, index6] = num6 * (numArray[index5, index6 - 1] - knot2 * numArray[index5, index6]) + num8 * (-numArray[index4, index6 - 1] + knot5 * numArray[index4, index6]);
            }
            numArray[index4, 0] = -num6 * knot2 * numArray[index5, 0] + num8 * knot5 * numArray[index4, 0];
          }
        }
        double knot6 = knots[index7 + 1];
        double knot7 = knots[index7 + index1 + 1];
        double num9 = knot7 - knot6;
        double num10 = 0.0;
        if (num9 != 0.0)
          num10 = 1.0 / num9;
        if (num10 != 0.0)
        {
          int index3 = index1;
          int index4 = index7 - num1;
          if (index3 > 0)
          {
            numArray[index4, index3] = -num10 * numArray[index4, index3 - 1];
            for (int index5 = index3 - 1; index5 > 0; --index5)
              numArray[index4, index5] = num10 * (-numArray[index4, index5 - 1] + knot7 * numArray[index4, index5]);
          }
          numArray[index4, 0] = num10 * knot7 * numArray[index4, 0];
        }
        --num1;
      }
      return numArray;
    }

    public static List<double[]> BSplineToPowerBasisUnoptimized(
      int degree,
      int knotSpanIndex,
      double[] knots)
    {
      int length = degree + 1;
      int capacity = length + degree;
      List<double[]> numArrayList = new List<double[]>(capacity);
      for (int index = 0; index < capacity; ++index)
        numArrayList.Add(new double[length]);
      numArrayList[degree][0] = 1.0;
      int num1 = knotSpanIndex - degree;
      int num2 = knotSpanIndex + degree;
      for (int index1 = 1; index1 < length; ++index1)
      {
        for (int index2 = num1; index2 < num2; ++index2)
        {
          double knot1 = knots[index2];
          double knot2 = knots[index2 + 1];
          double knot3 = knots[index2 + index1];
          double knot4 = knots[index2 + index1 + 1];
          double num3 = knot3 - knot1;
          double num4 = 0.0;
          if (num3 != 0.0)
            num4 = 1.0 / num3;
          double num5 = knot4 - knot2;
          double num6 = 0.0;
          if (num5 != 0.0)
            num6 = 1.0 / num5;
          if (num4 != 0.0 || num6 != 0.0)
          {
            int index3 = index1;
            int index4 = index2 - num1;
            double[] numArray1 = numArrayList[index4];
            double[] numArray2 = numArrayList[index4 + 1];
            if (index3 > 0)
            {
              numArray1[index3] = num4 * numArray1[index3 - 1] - num6 * numArray2[index3 - 1];
              for (int index5 = index3 - 1; index5 > 0; --index5)
                numArray1[index5] = num4 * (numArray1[index5 - 1] - knot1 * numArray1[index5]) + num6 * (-numArray2[index5 - 1] + knot4 * numArray2[index5]);
            }
            numArray1[0] = -num4 * knot1 * numArray1[0] + num6 * knot4 * numArray2[0];
          }
        }
        --num2;
      }
      int count = numArrayList.Count;
      for (int index = 0; index < degree; ++index)
        numArrayList.RemoveAt(--count);
      return numArrayList;
    }

    public static double[] CalculateBinomialCoefficients(int degree)
    {
      double[] numArray1 = NurbsUtilD.double_0;
      double[] numArray2 = new double[2]{ 1.0, 1.0 };
      if (degree > 1)
      {
        for (short index1 = 2; (int) index1 <= degree; ++index1)
        {
          numArray1 = new double[(int) index1 + 1];
          for (short index2 = 0; (int) index2 <= (int) index1; ++index2)
            numArray1[(int) index2] = (index2 < (short) 1 ? 0.0 : numArray2[(int) index2 - 1]) + ((int) index2 == (int) index1 ? 0.0 : numArray2[(int) index2]);
          numArray2 = numArray1;
        }
      }
      else
        numArray1 = numArray2;
      return numArray1;
    }

    public static int GetKnotSpanIndex(double u, IList<double> knots, int degree)
    {
      int num1 = knots.Count - degree - 2;
      if (u >= knots[num1 + 1])
        return num1;
      int num2 = degree;
      int num3 = num1 + 1;
      int index = num2 + num3 >> 1;
      int num4;
      do
      {
        if (u >= knots[index])
        {
          if (u >= knots[index + 1])
            num2 = index;
          else
            break;
        }
        else
          goto label_6;
label_5:
        num4 = index;
        index = num2 + num3 >> 1;
        continue;
label_6:
        num3 = index;
        goto label_5;
      }
      while (index != num4);
      return index;
    }

    public static int GetKnotIndex(
      double u,
      IList<double> knots,
      int degree,
      out int knotMultiplicity)
    {
      int num1 = knots.Count - degree - 2;
      if (u >= knots[num1 + 1])
      {
        knotMultiplicity = 0;
        for (int index = num1 + 1; index < knots.Count && u == knots[index]; ++index)
          ++knotMultiplicity;
        return num1 + 1;
      }
      int num2 = degree;
      int num3 = num1 + 1;
      int index1 = num2 + num3 >> 1;
      int num4;
      do
      {
        if (u >= knots[index1])
        {
          if (u >= knots[index1 + 1])
            num2 = index1;
          else
            break;
        }
        else
          goto label_9;
label_8:
        num4 = index1;
        index1 = num2 + num3 >> 1;
        continue;
label_9:
        num3 = index1;
        goto label_8;
      }
      while (index1 != num4);
      int index2 = index1;
      knotMultiplicity = 0;
      for (; index2 >= 0 && knots[index2] == u; --index2)
        ++knotMultiplicity;
      return index1;
    }

    public static void EvaluateBasisFunctions(
      int knotIndex,
      double u,
      int degree,
      IList<double> knots,
      double[] result)
    {
      result[0] = 1.0;
      double[] numArray1 = new double[degree + 1];
      double[] numArray2 = new double[degree + 1];
      for (int index1 = 0; index1 < degree; ++index1)
      {
        numArray1[index1] = u - knots[knotIndex - index1];
        numArray2[index1] = knots[knotIndex + index1 + 1] - u;
        double num1 = 0.0;
        for (int index2 = 0; index2 <= index1; ++index2)
        {
          double num2 = result[index2] / (numArray2[index2] + numArray1[index1 - index2]);
          result[index2] = num1 + numArray2[index2] * num2;
          num1 = numArray1[index1 - index2] * num2;
        }
        result[index1 + 1] = num1;
      }
    }

    public static void EvaluateRationalBasisFunctions(
      int knotIndex,
      double u,
      int degree,
      double[] knots,
      double[] weights,
      double[] result)
    {
      NurbsUtilD.EvaluateBasisFunctions(knotIndex, u, degree, (IList<double>) knots, result);
      double num1 = 0.0;
      int num2 = knotIndex - degree;
      for (int index = 0; index < result.Length; ++index)
      {
        result[index] *= weights[(num2 + index) % weights.Length];
        num1 += result[index];
      }
      double num3 = 1.0 / num1;
      for (int index = 0; index < result.Length; ++index)
        result[index] *= num3;
    }

    public static void GetDerivativesBasisFunctions(
      int knotIndex,
      double u,
      int degree,
      double[] knots,
      double[,] derivatives)
    {
      double[,] numArray1 = new double[degree + 1, degree + 1];
      double[,] numArray2 = new double[2, degree + 1];
      numArray1[0, 0] = 1.0;
      double[] numArray3 = new double[degree + 1];
      double[] numArray4 = new double[degree + 1];
      for (int index1 = 1; index1 <= degree; ++index1)
      {
        numArray3[index1 - 1] = u - knots[knotIndex + 1 - index1];
        numArray4[index1 - 1] = knots[knotIndex + index1] - u;
        double num1 = 0.0;
        for (int index2 = 0; index2 < index1; ++index2)
        {
          numArray1[index1, index2] = numArray4[index2] + numArray3[index1 - 1 - index2];
          double num2 = numArray1[index2, index1 - 1] / numArray1[index1, index2];
          numArray1[index2, index1] = num1 + numArray4[index2] * num2;
          num1 = numArray3[index1 - 1 - index2] * num2;
        }
        numArray1[index1, index1] = num1;
      }
      for (int index = 0; index <= degree; ++index)
        derivatives[0, index] = numArray1[index, degree];
      for (int index1 = 0; index1 <= degree; ++index1)
      {
        int index2 = 0;
        int index3 = 1;
        numArray2[0, 0] = 1.0;
        for (int index4 = 1; index4 <= knots.Length - 1; ++index4)
        {
          double num1 = 0.0;
          int index5 = index1 - index4;
          int index6 = degree - index4;
          if (index1 >= index4)
          {
            numArray2[index3, 0] = numArray2[index2, 0] / numArray1[index6 + 1, index5];
            num1 = numArray2[index3, 0] * numArray1[index5, index6];
          }
          int num2 = index5 >= -1 ? 1 : -index5;
          int num3 = index1 - 1 <= index6 ? index4 - 1 : degree - index1;
          for (int index7 = num2; index7 <= num3; ++index7)
          {
            numArray2[index3, index7] = (numArray2[index2, index7] - numArray2[index2, index7 - 1]) / numArray1[index6 + 1, index5 + index7];
            num1 += numArray2[index3, index7] * numArray1[index5 + index7, index6];
          }
          if (index1 <= index6)
          {
            numArray2[index3, index4] = -numArray2[index2, index4 - 1] / numArray1[index6 + 1, index1];
            num1 += numArray2[index3, index4] * numArray1[index1, index6];
          }
          derivatives[index4, index1] = num1;
          index2 = 1 - index2;
          index3 = 1 - index3;
        }
      }
      int num = degree;
      for (int index1 = 1; index1 <= knots.Length - 1; ++index1)
      {
        for (int index2 = 0; index2 <= degree; ++index2)
          derivatives[index1, index2] *= (double) num;
        num *= degree - index1;
      }
    }

    public static Point2D H(Vector3D v)
    {
      return new Point2D(v.X / v.Z, v.Y / v.Z);
    }
  }
}
