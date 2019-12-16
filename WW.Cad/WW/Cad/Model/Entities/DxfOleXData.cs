// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfOleXData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Entities
{
  public class DxfOleXData
  {
    private bool bool_0 = true;
    private short short_0 = 1;
    private FontMappingData fontMappingData_0 = new FontMappingData();
    private FontMappingData fontMappingData_1 = new FontMappingData();
    private DxfOle dxfOle_0;
    private double double_0;
    private double double_1;
    private double double_2;
    private short short_1;

    private DxfOleXData()
    {
    }

    public DxfOleXData(DxfOle ole)
    {
      this.dxfOle_0 = ole;
    }

    private void method_0()
    {
      this.bool_0 = true;
      this.short_0 = (short) 1;
      this.double_0 = 0.0;
      this.double_1 = (this.dxfOle_0.UpperRight - this.dxfOle_0.UpperLeft).GetLength();
      this.double_2 = (this.dxfOle_0.UpperRight - this.dxfOle_0.LowerRight).GetLength();
      this.short_1 = (short) 0;
      this.fontMappingData_0 = new FontMappingData();
      this.fontMappingData_1 = new FontMappingData();
    }

    private int method_1(DxfExtendedData.ValueCollection values)
    {
      for (int index = 0; index < values.Count; ++index)
      {
        DxfExtendedData.String @string = values[index] as DxfExtendedData.String;
        if (@string != null && @string.Value == "OLEBEGIN")
          return index;
      }
      return -1;
    }

    private void method_2()
    {
      DxfExtendedDataCollection extendedDataCollection = this.dxfOle_0.ExtendedDataCollection;
      DxfExtendedData extendedData;
      extendedDataCollection.TryGetValue(this.dxfOle_0.Model.AppIds["ACAD"], out extendedData);
      if (extendedData == null)
      {
        extendedData = new DxfExtendedData(this.dxfOle_0.Model.AppIds["ACAD"]);
        extendedDataCollection.Add(extendedData);
      }
      int num = this.method_1(extendedData.Values);
      if (num == -1)
      {
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.String("OLEBEGIN"));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) 70));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int16(this.bool_0 ? (short) 1 : (short) 0));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) 71));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int16(this.short_0));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) 40));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Double(this.double_0));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) 41));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Double(this.double_1));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) 42));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Double(this.double_2));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) 72));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int16(this.short_1));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) 3));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.String(this.fontMappingData_0.Font));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) 90));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int32(this.fontMappingData_0.PointSize));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) 43));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Double(this.fontMappingData_0.TextHeight));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) 4));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.String(this.fontMappingData_1.Font));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) 91));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int32(this.fontMappingData_1.PointSize));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) 44));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.Double(this.fontMappingData_1.TextHeight));
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.String("OLEEND"));
      }
      else
      {
        int index1 = num + 2;
        extendedData.Values[index1] = (IExtendedDataValue) new DxfExtendedData.Int16(this.bool_0 ? (short) 1 : (short) 0);
        int index2 = index1 + 2;
        extendedData.Values[index2] = (IExtendedDataValue) new DxfExtendedData.Int16(this.short_0);
        int index3 = index2 + 2;
        extendedData.Values[index3] = (IExtendedDataValue) new DxfExtendedData.Double(this.double_0);
        int index4 = index3 + 2;
        extendedData.Values[index4] = (IExtendedDataValue) new DxfExtendedData.Double(this.double_1);
        int index5 = index4 + 2;
        extendedData.Values[index5] = (IExtendedDataValue) new DxfExtendedData.Double(this.double_2);
        int index6 = index5 + 2;
        extendedData.Values[index6] = (IExtendedDataValue) new DxfExtendedData.Int16(this.short_1);
        int index7 = index6 + 2;
        extendedData.Values[index7] = (IExtendedDataValue) new DxfExtendedData.String(this.fontMappingData_0.Font);
        int index8 = index7 + 2;
        extendedData.Values[index8] = (IExtendedDataValue) new DxfExtendedData.Int32(this.fontMappingData_0.PointSize);
        int index9 = index8 + 2;
        extendedData.Values[index9] = (IExtendedDataValue) new DxfExtendedData.Double(this.fontMappingData_0.TextHeight);
        int index10 = index9 + 2;
        extendedData.Values[index10] = (IExtendedDataValue) new DxfExtendedData.String(this.fontMappingData_1.Font);
        int index11 = index10 + 2;
        extendedData.Values[index11] = (IExtendedDataValue) new DxfExtendedData.Int32(this.fontMappingData_1.PointSize);
        int index12 = index11 + 2;
        extendedData.Values[index12] = (IExtendedDataValue) new DxfExtendedData.Double(this.fontMappingData_1.TextHeight);
      }
    }

    private void method_3(IExtendedDataValue value, string testValue)
    {
      DxfExtendedData.String @string = value as DxfExtendedData.String;
      if (@string == null || @string.Value != testValue)
        throw new Exception("Invalid format of OLE xData.");
    }

    private string method_4(IExtendedDataValue value)
    {
      DxfExtendedData.String @string = value as DxfExtendedData.String;
      if (@string == null)
        throw new Exception("Invalid format of OLE xData.");
      return @string.Value;
    }

    private void method_5(IExtendedDataValue value, short testValue)
    {
      DxfExtendedData.Int16 int16 = value as DxfExtendedData.Int16;
      if (int16 == null || (int) int16.Value != (int) testValue)
        throw new Exception("Invalid format of OLE xData.");
    }

    private short method_6(IExtendedDataValue value)
    {
      DxfExtendedData.Int16 int16 = value as DxfExtendedData.Int16;
      if (int16 == null)
        throw new Exception("Invalid format of OLE xData.");
      return int16.Value;
    }

    private int method_7(IExtendedDataValue value)
    {
      DxfExtendedData.Int32 int32 = value as DxfExtendedData.Int32;
      if (int32 == null)
        throw new Exception("Invalid format of OLE xData.");
      return int32.Value;
    }

    private double method_8(IExtendedDataValue value)
    {
      DxfExtendedData.Double @double = value as DxfExtendedData.Double;
      if (@double == null)
        throw new Exception("Invalid format of OLE xData.");
      return @double.Value;
    }

    private void method_9()
    {
      DxfExtendedData extendedData;
      this.dxfOle_0.ExtendedDataCollection.TryGetValue(this.dxfOle_0.Model.AppIds["ACAD"], out extendedData);
      if (extendedData == null)
      {
        this.method_0();
      }
      else
      {
        int num1 = this.method_1(extendedData.Values);
        if (num1 == -1)
        {
          this.method_0();
        }
        else
        {
          DxfExtendedData.ValueCollection values1 = extendedData.Values;
          int index1 = num1;
          int num2 = index1 + 1;
          this.method_3(values1[index1], "OLEBEGIN");
          DxfExtendedData.ValueCollection values2 = extendedData.Values;
          int index2 = num2;
          int num3 = index2 + 1;
          this.method_5(values2[index2], (short) 70);
          DxfExtendedData.ValueCollection values3 = extendedData.Values;
          int index3 = num3;
          int num4 = index3 + 1;
          this.bool_0 = this.method_6(values3[index3]) == (short) 1;
          DxfExtendedData.ValueCollection values4 = extendedData.Values;
          int index4 = num4;
          int num5 = index4 + 1;
          this.method_5(values4[index4], (short) 71);
          DxfExtendedData.ValueCollection values5 = extendedData.Values;
          int index5 = num5;
          int num6 = index5 + 1;
          this.short_0 = this.method_6(values5[index5]);
          DxfExtendedData.ValueCollection values6 = extendedData.Values;
          int index6 = num6;
          int num7 = index6 + 1;
          this.method_5(values6[index6], (short) 40);
          DxfExtendedData.ValueCollection values7 = extendedData.Values;
          int index7 = num7;
          int num8 = index7 + 1;
          this.double_0 = this.method_8(values7[index7]);
          DxfExtendedData.ValueCollection values8 = extendedData.Values;
          int index8 = num8;
          int num9 = index8 + 1;
          this.method_5(values8[index8], (short) 41);
          DxfExtendedData.ValueCollection values9 = extendedData.Values;
          int index9 = num9;
          int num10 = index9 + 1;
          this.double_1 = this.method_8(values9[index9]);
          DxfExtendedData.ValueCollection values10 = extendedData.Values;
          int index10 = num10;
          int num11 = index10 + 1;
          this.method_5(values10[index10], (short) 42);
          DxfExtendedData.ValueCollection values11 = extendedData.Values;
          int index11 = num11;
          int num12 = index11 + 1;
          this.double_2 = this.method_8(values11[index11]);
          DxfExtendedData.ValueCollection values12 = extendedData.Values;
          int index12 = num12;
          int num13 = index12 + 1;
          this.method_5(values12[index12], (short) 72);
          DxfExtendedData.ValueCollection values13 = extendedData.Values;
          int index13 = num13;
          int num14 = index13 + 1;
          this.short_1 = this.method_6(values13[index13]);
          DxfExtendedData.ValueCollection values14 = extendedData.Values;
          int index14 = num14;
          int num15 = index14 + 1;
          this.method_5(values14[index14], (short) 3);
          FontMappingData fontMappingData0_1 = this.fontMappingData_0;
          DxfExtendedData.ValueCollection values15 = extendedData.Values;
          int index15 = num15;
          int num16 = index15 + 1;
          string str1 = this.method_4(values15[index15]);
          fontMappingData0_1.Font = str1;
          DxfExtendedData.ValueCollection values16 = extendedData.Values;
          int index16 = num16;
          int num17 = index16 + 1;
          this.method_5(values16[index16], (short) 90);
          FontMappingData fontMappingData0_2 = this.fontMappingData_0;
          DxfExtendedData.ValueCollection values17 = extendedData.Values;
          int index17 = num17;
          int num18 = index17 + 1;
          int num19 = this.method_7(values17[index17]);
          fontMappingData0_2.PointSize = num19;
          DxfExtendedData.ValueCollection values18 = extendedData.Values;
          int index18 = num18;
          int num20 = index18 + 1;
          this.method_5(values18[index18], (short) 43);
          FontMappingData fontMappingData0_3 = this.fontMappingData_0;
          DxfExtendedData.ValueCollection values19 = extendedData.Values;
          int index19 = num20;
          int num21 = index19 + 1;
          double num22 = this.method_8(values19[index19]);
          fontMappingData0_3.TextHeight = num22;
          DxfExtendedData.ValueCollection values20 = extendedData.Values;
          int index20 = num21;
          int num23 = index20 + 1;
          this.method_5(values20[index20], (short) 4);
          FontMappingData fontMappingData1_1 = this.fontMappingData_1;
          DxfExtendedData.ValueCollection values21 = extendedData.Values;
          int index21 = num23;
          int num24 = index21 + 1;
          string str2 = this.method_4(values21[index21]);
          fontMappingData1_1.Font = str2;
          DxfExtendedData.ValueCollection values22 = extendedData.Values;
          int index22 = num24;
          int num25 = index22 + 1;
          this.method_5(values22[index22], (short) 91);
          FontMappingData fontMappingData1_2 = this.fontMappingData_1;
          DxfExtendedData.ValueCollection values23 = extendedData.Values;
          int index23 = num25;
          int num26 = index23 + 1;
          int num27 = this.method_7(values23[index23]);
          fontMappingData1_2.PointSize = num27;
          DxfExtendedData.ValueCollection values24 = extendedData.Values;
          int index24 = num26;
          int num28 = index24 + 1;
          this.method_5(values24[index24], (short) 44);
          FontMappingData fontMappingData1_3 = this.fontMappingData_1;
          DxfExtendedData.ValueCollection values25 = extendedData.Values;
          int index25 = num28;
          int index26 = index25 + 1;
          double num29 = this.method_8(values25[index25]);
          fontMappingData1_3.TextHeight = num29;
          this.method_3(extendedData.Values[index26], "OLEEND");
        }
      }
    }

    public bool AutoQuality
    {
      get
      {
        this.method_9();
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
        this.method_2();
      }
    }

    public short LockAspect
    {
      get
      {
        this.method_9();
        return this.short_0;
      }
      set
      {
        this.short_0 = value;
        this.method_2();
      }
    }

    public double Rotation
    {
      get
      {
        this.method_9();
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
        this.method_2();
      }
    }

    public double InitialWidth
    {
      get
      {
        this.method_9();
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
        this.method_2();
      }
    }

    public double InitialHeight
    {
      get
      {
        this.method_9();
        return this.double_2;
      }
      set
      {
        this.double_2 = value;
        this.method_2();
      }
    }

    public short Unknown
    {
      get
      {
        this.method_9();
        return this.short_1;
      }
      set
      {
        this.short_1 = value;
        this.method_2();
      }
    }

    public FontMappingData ActiveFontMapping
    {
      get
      {
        this.method_9();
        return this.fontMappingData_0;
      }
      set
      {
        this.fontMappingData_0 = value;
        this.method_2();
      }
    }

    public FontMappingData InitialFontMapping
    {
      get
      {
        this.method_9();
        return this.fontMappingData_1;
      }
      set
      {
        this.fontMappingData_1 = value;
        this.method_2();
      }
    }
  }
}
