// Decompiled with JetBrains decompiler
// Type: ns7.Class608
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns9;
using System;
using System.Collections.Generic;
using WW.Math;

namespace ns7
{
  internal class Class608
  {
    private readonly List<Point3D> list_0 = new List<Point3D>();
    private readonly IDictionary<Point3D, int> idictionary_0 = (IDictionary<Point3D, int>) new Dictionary<Point3D, int>();
    private readonly Dictionary<Class608.Class609, Class608.Class609> dictionary_0 = new Dictionary<Class608.Class609, Class608.Class609>();
    private readonly List<Class608.Class610> list_1 = new List<Class608.Class610>();
    private Matrix4D matrix4D_0 = Matrix4D.Identity;
    private readonly Class258 class258_0;

    public Class608(Class258 accuracy)
    {
      this.class258_0 = accuracy;
    }

    private int method_0(Point3D p)
    {
      int count;
      if (!this.idictionary_0.TryGetValue(p, out count))
      {
        count = this.list_0.Count;
        this.idictionary_0[p] = count;
        this.list_0.Add(p);
      }
      return count;
    }

    public int method_1(Point3D point)
    {
      return this.method_0(this.matrix4D_0.Transform(point));
    }

    public int method_2(Class105 point)
    {
      return this.method_0(point.method_4(this.matrix4D_0));
    }

    public void method_3(Matrix4D trafo)
    {
      if (this.matrix4D_0 != Matrix4D.Identity)
        throw new NotSupportedException("Only one transform allowed");
      this.matrix4D_0 = trafo;
    }

    public void method_4()
    {
      this.matrix4D_0 = Matrix4D.Identity;
    }

    public Class258 Accuracy
    {
      get
      {
        return this.class258_0;
      }
    }

    public void method_5(int startIndex, int endIndex)
    {
      Class608.Class609 index = new Class608.Class609(startIndex, endIndex);
      this.dictionary_0[index] = index;
    }

    public void method_6(Class105 startPoint, Class105 endPoint)
    {
      this.method_5(this.method_2(startPoint), this.method_2(endPoint));
    }

    public void method_7(Point3D startPoint, Point3D endPoint)
    {
      this.method_5(this.method_1(startPoint), this.method_1(endPoint));
    }

    public void method_8(int[] indexes, bool closed)
    {
      this.list_1.Add(new Class608.Class610(indexes, closed));
    }

    public void method_9(ICollection<Point3D> loopPoints, bool closed)
    {
      int[] indexes = new int[loopPoints.Count];
      int num = 0;
      foreach (Point3D loopPoint in (IEnumerable<Point3D>) loopPoints)
        indexes[num++] = this.method_1(loopPoint);
      this.method_8(indexes, closed);
    }

    public Point3D[] Points
    {
      get
      {
        return this.list_0.ToArray();
      }
    }

    public Class608.Interface36[] Wires
    {
      get
      {
        Class608.Interface36[] nterface36Array = new Class608.Interface36[this.dictionary_0.Count + this.list_1.Count];
        int num = 0;
        foreach (Class608.Class609 class609 in this.dictionary_0.Values)
          nterface36Array[num++] = (Class608.Interface36) class609;
        foreach (Class608.Class610 class610 in this.list_1)
          nterface36Array[num++] = (Class608.Interface36) class610;
        return nterface36Array;
      }
    }

    public int method_10(Bounds3D bounds, Matrix4D transformation)
    {
      foreach (Point3D point in this.list_0)
        bounds.Update(transformation.Transform(point));
      return this.dictionary_0.Count + this.list_1.Count;
    }

    internal interface Interface36
    {
      int[] Indexes { get; }

      Point3D[] imethod_0(Point3D[] pointSet);

      int NumberPoints { get; }
    }

    private class Class609 : Class608.Interface36
    {
      private readonly int int_0;
      private readonly int int_1;

      public Class609(int startIndex, int endIndex)
      {
        if (startIndex < endIndex)
        {
          this.int_0 = startIndex;
          this.int_1 = endIndex;
        }
        else
        {
          this.int_0 = endIndex;
          this.int_1 = startIndex;
        }
      }

      private Point3D method_0(Point3D[] points)
      {
        return points[this.int_0];
      }

      private Point3D GetEndPoint(Point3D[] points)
      {
        return points[this.int_1];
      }

      public int[] Indexes
      {
        get
        {
          if (this.int_0 != this.int_1)
            return new int[2]{ this.int_0, this.int_1 };
          return new int[1]{ this.int_0 };
        }
      }

      public Point3D[] imethod_0(Point3D[] pointSet)
      {
        if (this.int_0 != this.int_1)
          return new Point3D[2]{ this.method_0(pointSet), this.GetEndPoint(pointSet) };
        return new Point3D[1]{ this.method_0(pointSet) };
      }

      public int NumberPoints
      {
        get
        {
          return this.int_0 != this.int_1 ? 2 : 1;
        }
      }

      public override bool Equals(object o)
      {
        if (this == o)
          return true;
        Class608.Class609 class609 = (Class608.Class609) o;
        return this.int_1 == class609.int_1 && this.int_0 == class609.int_0;
      }

      public override int GetHashCode()
      {
        return 31 * this.int_0 + this.int_1;
      }
    }

    private class Class610 : Class608.Interface36
    {
      private readonly int[] int_0;
      private readonly bool bool_0;

      internal Class610(int[] indexes, bool closed)
      {
        this.int_0 = indexes;
        this.bool_0 = closed;
      }

      public int[] Indexes
      {
        get
        {
          int[] numArray = new int[this.bool_0 ? this.int_0.Length + 1 : this.int_0.Length];
          Array.Copy((Array) this.int_0, (Array) numArray, this.int_0.Length);
          if (this.bool_0)
            numArray[this.int_0.Length] = numArray[0];
          return numArray;
        }
      }

      public Point3D[] imethod_0(Point3D[] pointSet)
      {
        Point3D[] point3DArray = new Point3D[this.bool_0 ? this.int_0.Length + 1 : this.int_0.Length];
        for (int index = this.int_0.Length - 1; index >= 0; --index)
          point3DArray[index] = pointSet[this.int_0[index]];
        if (this.bool_0)
          point3DArray[this.int_0.Length] = point3DArray[0];
        return point3DArray;
      }

      public int NumberPoints
      {
        get
        {
          if (!this.bool_0)
            return this.int_0.Length;
          return this.int_0.Length + 1;
        }
      }
    }
  }
}
