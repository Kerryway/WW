// Decompiled with JetBrains decompiler
// Type: WW.Cad.Base.BSplineD
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;

namespace WW.Cad.Base
{
  public class BSplineD
  {
    private int int_0;
    private double[] double_0;
    private int int_1;
    private double[] double_1;
    private double[] double_2;
    private double double_3;
    private double double_4;

    public BSplineD(int power, int controlPointCount, bool closed)
    {
      this.int_0 = power;
      this.KnotValues = BSplineD.CreateDefaultKnotValues(power, controlPointCount, closed);
      this.double_1 = new double[power + 1];
      this.double_2 = new double[power + 1];
      this.double_3 = this.double_0[power];
      this.double_4 = this.double_0[this.double_0.Length - power - 1];
    }

    public BSplineD(int power, double[] knots)
    {
      this.int_0 = power;
      this.KnotValues = knots;
      this.double_3 = this.double_0[power];
      this.double_4 = this.double_0[this.double_0.Length - power - 1];
      this.double_1 = new double[power + 1];
      this.double_2 = new double[power + 1];
    }

    public BSplineD(int power, IList<double> knots)
    {
      this.int_0 = power;
      double[] array = new double[knots.Count];
      knots.CopyTo(array, 0);
      this.KnotValues = array;
      this.double_3 = this.double_0[power];
      this.double_4 = this.double_0[this.double_0.Length - power - 1];
      this.double_1 = new double[power + 1];
      this.double_2 = new double[power + 1];
    }

    public int Power
    {
      get
      {
        return this.int_0;
      }
    }

    public int Degree
    {
      get
      {
        return this.int_0;
      }
    }

    public double MinU
    {
      get
      {
        return this.double_3;
      }
    }

    public double MaxU
    {
      get
      {
        return this.double_4;
      }
    }

    public double[] KnotValues
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
        this.int_1 = this.double_0.Length - this.int_0 - 2;
      }
    }

    public int KnotCount
    {
      get
      {
        return this.double_0.Length;
      }
    }

    public bool IsValid(int controlPointCount)
    {
      if (controlPointCount < this.int_0 + 1 || this.KnotCount != controlPointCount + this.int_0 + 1)
        return false;
      int num = 1;
      for (int index = 1; index < this.double_0.Length; ++index)
      {
        if (this.double_0[index] < this.double_0[index - 1])
          return false;
        if (this.double_0[index] == this.double_0[index - 1])
        {
          ++num;
          if (num > this.int_0 && (num > this.int_0 + 1 || index != this.int_0 && index != this.double_0.Length - 1))
            return false;
        }
        else
          num = 1;
      }
      return true;
    }

    public int GetKnotSpanIndex(double u)
    {
      if (u >= this.double_0[this.int_1 + 1])
        return this.int_1;
      int num1 = this.int_0;
      int num2 = this.int_1 + 1;
      int index = num1 + num2 >> 1;
      int num3;
      do
      {
        if (u >= this.double_0[index])
        {
          if (u >= this.double_0[index + 1])
            num1 = index;
          else
            break;
        }
        else
          goto label_6;
label_5:
        num3 = index;
        index = num1 + num2 >> 1;
        continue;
label_6:
        num2 = index;
        goto label_5;
      }
      while (index != num3);
      return index;
    }

    public void EvaluateBasisFunctions(int knotIndex, double u, double[] result)
    {
      result[0] = 1.0;
      for (int index1 = 0; index1 < this.int_0; ++index1)
      {
        this.double_1[index1] = u - this.double_0[knotIndex - index1];
        this.double_2[index1] = this.double_0[knotIndex + index1 + 1] - u;
        double num1 = 0.0;
        for (int index2 = 0; index2 <= index1; ++index2)
        {
          double num2 = result[index2] / (this.double_2[index2] + this.double_1[index1 - index2]);
          result[index2] = num1 + this.double_2[index2] * num2;
          num1 = this.double_1[index1 - index2] * num2;
        }
        result[index1 + 1] = num1;
      }
    }

    public void EvaluateRationalBasisFunctions(
      int knotIndex,
      double u,
      double[] weights,
      double[] result)
    {
      this.EvaluateBasisFunctions(knotIndex, u, result);
      double num1 = 0.0;
      int num2 = knotIndex - this.int_0;
      for (int index = 0; index < result.Length; ++index)
      {
        result[index] *= weights[(num2 + index) % weights.Length];
        num1 += result[index];
      }
      double num3 = 1.0 / num1;
      for (int index = 0; index < result.Length; ++index)
        result[index] *= num3;
    }

    public void GetDerivativesBasisFunctions(
      int knotIndex,
      double u,
      int maxDerivative,
      double[,] derivatives)
    {
      double[,] numArray1 = new double[this.int_0 + 1, this.int_0 + 1];
      double[,] numArray2 = new double[2, this.int_0 + 1];
      numArray1[0, 0] = 1.0;
      for (int index1 = 1; index1 <= this.int_0; ++index1)
      {
        this.double_1[index1 - 1] = u - this.double_0[knotIndex + 1 - index1];
        this.double_2[index1 - 1] = this.double_0[knotIndex + index1] - u;
        double num1 = 0.0;
        for (int index2 = 0; index2 < index1; ++index2)
        {
          numArray1[index1, index2] = this.double_2[index2] + this.double_1[index1 - 1 - index2];
          double num2 = numArray1[index2, index1 - 1] / numArray1[index1, index2];
          numArray1[index2, index1] = num1 + this.double_2[index2] * num2;
          num1 = this.double_1[index1 - 1 - index2] * num2;
        }
        numArray1[index1, index1] = num1;
      }
      for (int index = 0; index <= this.int_0; ++index)
        derivatives[0, index] = numArray1[index, this.int_0];
      for (int index1 = 0; index1 <= this.int_0; ++index1)
      {
        int index2 = 0;
        int index3 = 1;
        numArray2[0, 0] = 1.0;
        for (int index4 = 1; index4 <= maxDerivative; ++index4)
        {
          double num1 = 0.0;
          int index5 = index1 - index4;
          int index6 = this.int_0 - index4;
          if (index1 >= index4)
          {
            numArray2[index3, 0] = numArray2[index2, 0] / numArray1[index6 + 1, index5];
            num1 = numArray2[index3, 0] * numArray1[index5, index6];
          }
          int num2 = index5 >= -1 ? 1 : -index5;
          int num3 = index1 - 1 <= index6 ? index4 - 1 : this.int_0 - index1;
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
      int int0 = this.int_0;
      for (int index1 = 1; index1 <= maxDerivative; ++index1)
      {
        for (int index2 = 0; index2 <= this.int_0; ++index2)
          derivatives[index1, index2] *= (double) int0;
        int0 *= this.int_0 - index1;
      }
    }

    public static double[] CreateDefaultKnotValues(int power, int controlPointCount, bool closed)
    {
      double[] numArray;
      if (closed)
      {
        numArray = new double[controlPointCount + (power << 1) + 1];
        for (int index = 0; index < controlPointCount + (power << 1) + 1; ++index)
          numArray[index] = (double) (index - power);
      }
      else
      {
        numArray = new double[controlPointCount + power + 1];
        for (int index = 0; index < power + 1; ++index)
          numArray[index] = 0.0;
        int num = 1;
        int index1 = power + 1;
        while (index1 < controlPointCount)
        {
          numArray[index1] = (double) num;
          ++index1;
          ++num;
        }
        for (int index2 = controlPointCount; index2 < controlPointCount + power + 1; ++index2)
          numArray[index2] = (double) num;
      }
      return numArray;
    }

    public static int GetExpectedKnotCount(int controlPointCount, int power)
    {
      return controlPointCount + power + 1;
    }

    public static int GetExpectedKnotCount(int controlPointCount, int power, bool closed)
    {
      return controlPointCount + power + 1 + (closed ? power : 0);
    }
  }
}
