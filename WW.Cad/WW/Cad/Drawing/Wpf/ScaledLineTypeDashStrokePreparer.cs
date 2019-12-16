// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Wpf.ScaledLineTypeDashStrokePreparer
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Shapes;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace WW.Cad.Drawing.Wpf
{
  public class ScaledLineTypeDashStrokePreparer
  {
    private readonly IDictionary<DxfLineType, DoubleCollection> idictionary_0 = (IDictionary<DxfLineType, DoubleCollection>) new Dictionary<DxfLineType, DoubleCollection>();
    private readonly double double_0;
    private readonly double double_1;
    private readonly bool bool_0;

    public ScaledLineTypeDashStrokePreparer(double dashPatternLength, bool roundUp)
      : this(1.0, dashPatternLength, roundUp)
    {
    }

    public ScaledLineTypeDashStrokePreparer(
      double dotLength,
      double dashPatternLength,
      bool roundUp)
    {
      if (dotLength >= dashPatternLength)
        throw new ArgumentException("dotLength has to be less than dashPatternLength!");
      this.double_0 = dotLength;
      this.double_1 = dashPatternLength;
      this.bool_0 = roundUp;
    }

    public void PrepareStroke(Path path, DxfEntity entity, DrawContext context, bool forText)
    {
      if (forText)
        return;
      DoubleCollection dashArray = this.GetDashArray(entity.GetLineType(context));
      if (dashArray == null)
        return;
      path.StrokeDashArray = dashArray;
    }

    protected DoubleCollection GetDashArray(DxfLineType lineType)
    {
      if (lineType == null || lineType.Elements.Count <= 0)
        return (DoubleCollection) null;
      DoubleCollection dashArray;
      if (!this.idictionary_0.TryGetValue(lineType, out dashArray))
      {
        dashArray = this.CreateDashArray(lineType);
        this.idictionary_0.Add(lineType, dashArray);
      }
      return dashArray;
    }

    protected virtual DoubleCollection CreateDashArray(DxfLineType lineType)
    {
      double length = lineType.GetLength();
      if (length <= 0.0)
        return (DoubleCollection) null;
      double num1 = this.double_1 / length;
      List<double> doubleList1 = new List<double>(lineType.Elements.Count);
      foreach (DxfLineType.Element element in (List<DxfLineType.Element>) lineType.Elements)
        doubleList1.Add(num1 * element.Length);
      for (int index1 = 0; index1 < doubleList1.Count; ++index1)
      {
        if (doubleList1[index1] < 0.0)
        {
          int index2 = (index1 + 1) % doubleList1.Count;
          if (doubleList1[index2] < 0.0)
          {
            List<double> doubleList2;
            int index3;
            (doubleList2 = doubleList1)[index3 = index1] = doubleList2[index3] + doubleList1[index2];
            doubleList1.RemoveAt(index2);
            --index1;
          }
        }
        else
        {
          int index2 = (index1 + 1) % doubleList1.Count;
          if (doubleList1[index2] >= 0.0)
          {
            List<double> doubleList2;
            int index3;
            (doubleList2 = doubleList1)[index3 = index1] = doubleList2[index3] + doubleList1[index2];
            doubleList1.RemoveAt(index2);
            --index1;
          }
        }
      }
      if (doubleList1.Count <= 1)
        return (DoubleCollection) null;
      int num2 = 0;
      foreach (double num3 in doubleList1)
      {
        if (num3 == 0.0)
          ++num2;
      }
      double num4 = (this.double_1 - (double) num2 * this.double_0) / this.double_1;
      if (num4 <= 0.0)
        return (DoubleCollection) null;
      DoubleCollection doubleCollection = new DoubleCollection(doubleList1.Count);
      double num5 = this.bool_0 ? Math.Ceiling(this.double_0) : this.double_0;
      foreach (double num3 in doubleList1)
      {
        if (num3 == 0.0)
        {
          doubleCollection.Add(num5);
        }
        else
        {
          double a = num4 * Math.Abs(num3);
          if (this.bool_0)
            a = Math.Ceiling(a);
          doubleCollection.Add(a);
        }
      }
      return doubleCollection;
    }
  }
}
