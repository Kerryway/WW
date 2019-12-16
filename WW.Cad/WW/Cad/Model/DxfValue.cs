// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfValue
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Cad.IO;
using WW.Cad.Model.Objects;

namespace WW.Cad.Model
{
  public class DxfValue
  {
    private DxfValueFormat dxfValueFormat_0 = DxfValueFormat.GeneralInstance;
    private string string_0 = string.Empty;
    private object object_0;
    private int int_0;

    public DxfValueFormat Format
    {
      get
      {
        return this.dxfValueFormat_0;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        this.dxfValueFormat_0 = value;
        this.string_0 = (string) null;
      }
    }

    public object Value
    {
      get
      {
        DxfObjectReference object0 = this.object_0 as DxfObjectReference;
        if (object0 == null)
          return this.object_0;
        return (object) object0.Value;
      }
    }

    public string GetValueString(DxfValueFormat defaultValueFormat)
    {
      if (this.string_0 == null)
        this.string_0 = this.Value != null ? ((this.dxfValueFormat_0 == null || this.dxfValueFormat_0 is DxfValueFormat.None ? defaultValueFormat : this.dxfValueFormat_0) ?? DxfValueFormat.NoneInstance).GetValueString(this.Value) : string.Empty;
      return this.string_0;
    }

    public bool IsEmpty
    {
      get
      {
        return (this.int_0 & 1) != 0;
      }
      set
      {
        if (value)
          this.int_0 |= 1;
        else
          this.int_0 &= -2;
      }
    }

    public void SetValue(int value)
    {
      this.object_0 = (object) value;
      this.string_0 = (string) null;
    }

    public void SetValue(double value)
    {
      this.object_0 = (object) value;
      this.string_0 = (string) null;
    }

    public void SetValue(WW.Math.Point2D value)
    {
      this.object_0 = (object) value;
      this.string_0 = (string) null;
    }

    public void SetValue(WW.Math.Point3D value)
    {
      this.object_0 = (object) value;
      this.string_0 = (string) null;
    }

    public void SetValue(string value)
    {
      this.object_0 = (object) value;
      this.string_0 = (string) null;
    }

    public void SetValue(DateTime value)
    {
      this.object_0 = (object) value;
      this.string_0 = (string) null;
    }

    public void SetValue(DxfHandledObject value)
    {
      this.object_0 = (object) DxfObjectReference.GetReference((IDxfHandledObject) value);
      this.string_0 = (string) null;
    }

    public DxfValue Clone(CloneContext cloneContext)
    {
      DxfValue dxfValue = new DxfValue();
      DxfObjectReference object0 = this.object_0 as DxfObjectReference;
      dxfValue.object_0 = object0 == null ? this.object_0 : (object) ((DxfHandledObject) ((DxfHandledObject) object0.Value).Clone(cloneContext)).Reference;
      dxfValue.string_0 = this.string_0;
      dxfValue.dxfValueFormat_0 = this.dxfValueFormat_0 == null ? (DxfValueFormat) null : this.dxfValueFormat_0.Clone();
      dxfValue.int_0 = this.int_0;
      return dxfValue;
    }

    public void CopyFromShallow(DxfValue from)
    {
      this.dxfValueFormat_0 = from.dxfValueFormat_0;
      this.object_0 = from.object_0;
      this.string_0 = from.string_0;
      this.int_0 = from.int_0;
    }

    public override string ToString()
    {
      return (this.object_0 ?? (object) string.Empty).ToString();
    }

    internal int Flags
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

    internal void method_0(DxfValueFormat format)
    {
      this.dxfValueFormat_0 = format;
    }

    internal void method_1(object value)
    {
      DxfHandledObject dxfHandledObject = value as DxfHandledObject;
      if (dxfHandledObject != null)
        this.object_0 = (object) dxfHandledObject.Reference;
      else
        this.object_0 = value;
    }

    internal void method_2(string valueString)
    {
      this.string_0 = valueString;
    }

    internal void Write(DxfWriter w)
    {
      DxfModel model = w.Model;
      if (model.Header.Dxf19OrHigher)
        w.Write(93, (object) this.int_0);
      w.Write(90, (object) (int) this.Format.DataType);
      switch (this.Format.DataType)
      {
        case ValueDataType.None:
          if (!model.Header.Dxf19OrHigher)
          {
            w.Write(91, (object) 0);
            break;
          }
          break;
        case ValueDataType.Int:
          w.Write(91, (object) Convert.ToInt32(this.object_0));
          break;
        case ValueDataType.Double:
          w.Write(140, (object) Convert.ToDouble(this.object_0));
          break;
        case ValueDataType.String:
          w.method_142(1, 2, (string) this.object_0, true);
          break;
        case ValueDataType.Date:
          w.Write(92, (object) 16);
          DateTime object0_1 = (DateTime) this.object_0;
          byte[] numArray = DxfValue.smethod_0(w.Model.Header.AcadVersion, object0_1);
          w.Write(310, (object) numArray);
          break;
        case ValueDataType.Point2D:
        case ValueDataType.Point3D:
          WW.Math.Point3D object0_2 = (WW.Math.Point3D) this.object_0;
          w.Write(11, object0_2);
          break;
        case ValueDataType.ObjectHandle:
          DxfHandledObject dxfHandledObject = (DxfHandledObject) this.Value;
          if (dxfHandledObject != null)
          {
            w.method_218(330, dxfHandledObject);
            break;
          }
          break;
        case ValueDataType.Buffer:
          throw new NotImplementedException("Not yet implemented: Export of value data type 'Buffer'!");
        case ValueDataType.ResultBuffer:
          throw new NotImplementedException("Not yet implemented: Export of value data type 'ResultBuffer'!");
        case ValueDataType.General:
          w.method_142(1, 2, (string) this.object_0, true);
          break;
      }
      if (!model.Header.Dxf19OrHigher)
        return;
      w.Write(94, (object) (int) this.Format.UnitType);
      w.Write(300, (object) this.Format._FormatString);
      w.method_142(302, 303, this.GetValueString(this.Format), true);
      w.Write(304, (object) "ACVALUE_END");
    }

    internal void Read(DxfXRecord xrecord)
    {
      ValueDataType? nullable1 = new ValueDataType?();
      ValueUnitType? nullable2 = new ValueUnitType?();
      string formatString = (string) null;
      foreach (DxfXRecordValue dxfXrecordValue in (List<DxfXRecordValue>) xrecord.Values)
      {
        switch (dxfXrecordValue.Code)
        {
          case 1:
          case 11:
          case 91:
          case 140:
          case 330:
            this.method_1(dxfXrecordValue.Value);
            continue;
          case 90:
            nullable1 = new ValueDataType?((ValueDataType) dxfXrecordValue.Value);
            continue;
          case 93:
            this.int_0 = (int) dxfXrecordValue.Value;
            continue;
          case 94:
            nullable2 = new ValueUnitType?((ValueUnitType) dxfXrecordValue.Value);
            continue;
          case 300:
            formatString = (string) dxfXrecordValue.Value;
            continue;
          case 310:
            this.object_0 = (object) DxfValue.smethod_3((byte[]) dxfXrecordValue.Value);
            continue;
          default:
            continue;
        }
      }
      if (!nullable1.HasValue || !nullable2.HasValue)
        return;
      this.dxfValueFormat_0 = DxfValueFormat.Create(nullable1.Value, nullable2.Value, formatString);
    }

    internal void Write(DxfXRecord xrecord)
    {
      xrecord.Values.Add((short) 93, (object) this.int_0);
      xrecord.Values.Add((short) 90, (object) (int) this.Format.DataType);
      switch (this.Format.DataType)
      {
        case ValueDataType.None:
          xrecord.Values.Add((short) 91, (object) 0);
          break;
        case ValueDataType.Int:
          xrecord.Values.Add((short) 91, (object) Convert.ToInt32(this.Value));
          break;
        case ValueDataType.Double:
          xrecord.Values.Add((short) 140, (object) Convert.ToDouble(this.Value));
          break;
        case ValueDataType.String:
          xrecord.Values.Add((short) 1, (object) (string) this.Value);
          break;
        case ValueDataType.Date:
          xrecord.Values.Add((short) 92, (object) 16);
          byte[] numArray = DxfValue.smethod_2((DateTime) this.Value);
          xrecord.Values.Add((short) 310, (object) numArray);
          break;
        case ValueDataType.Point2D:
        case ValueDataType.Point3D:
          WW.Math.Point3D point3D = (WW.Math.Point3D) this.Value;
          xrecord.Values.Add((short) 11, (object) point3D);
          break;
        case ValueDataType.ObjectHandle:
          DxfHandledObject dxfHandledObject = (DxfHandledObject) this.Value;
          if (dxfHandledObject != null)
          {
            xrecord.Values.Add((short) 330, (object) dxfHandledObject);
            break;
          }
          break;
        case ValueDataType.Buffer:
          throw new NotImplementedException("Not yet implemented: Export of value data type 'Buffer'!");
        case ValueDataType.ResultBuffer:
          throw new NotImplementedException("Not yet implemented: Export of value data type 'ResultBuffer'!");
        case ValueDataType.General:
          xrecord.Values.Add((short) 1, this.Value == null ? (object) string.Empty : (object) (string) this.Value);
          break;
      }
      xrecord.Values.Add((short) 94, (object) (int) this.Format.UnitType);
      xrecord.Values.Add((short) 300, (object) this.Format._FormatString);
      xrecord.Values.Add((short) 302, (object) this.GetValueString(this.Format));
    }

    internal static byte[] smethod_0(DxfVersion version, DateTime dateTime)
    {
      byte[] bytes;
      if (version >= DxfVersion.Dxf21)
      {
        bytes = new byte[16];
        DxfValue.smethod_4(bytes, 0, dateTime.Year);
        DxfValue.smethod_4(bytes, 2, dateTime.Month);
        DxfValue.smethod_4(bytes, 4, (int) dateTime.DayOfWeek);
        DxfValue.smethod_4(bytes, 6, dateTime.Day);
        DxfValue.smethod_4(bytes, 8, dateTime.Hour);
        DxfValue.smethod_4(bytes, 10, dateTime.Minute);
        DxfValue.smethod_4(bytes, 12, dateTime.Second);
        DxfValue.smethod_4(bytes, 14, dateTime.Millisecond);
      }
      else
        bytes = DxfValue.smethod_2(dateTime);
      return bytes;
    }

    internal static DateTime? smethod_1(DxfVersion version, byte[] dateBytes)
    {
      DateTime? nullable = new DateTime?();
      try
      {
        if (dateBytes.Length == 16)
          nullable = new DateTime?(new DateTime((int) dateBytes[0] + ((int) dateBytes[1] << 8), (int) dateBytes[2] + ((int) dateBytes[3] << 8), (int) dateBytes[6] + ((int) dateBytes[7] << 8), (int) dateBytes[8] + ((int) dateBytes[9] << 8), (int) dateBytes[10] + ((int) dateBytes[11] << 8), (int) dateBytes[12] + ((int) dateBytes[13] << 8), (int) dateBytes[14] + ((int) dateBytes[15] << 8)));
        else if (dateBytes.Length == 8)
          nullable = new DateTime?(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds((double) (((int) dateBytes[0] << 24) + ((int) dateBytes[1] << 16) + ((int) dateBytes[2] << 8) + (int) dateBytes[3] + ((int) dateBytes[4] << 24) + ((int) dateBytes[5] << 16) + ((int) dateBytes[6] << 8) + (int) dateBytes[7])));
      }
      catch (Exception ex)
      {
      }
      return nullable;
    }

    internal static byte[] smethod_2(DateTime dateTime)
    {
      ulong uint64 = Convert.ToUInt64((dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
      byte[] numArray = new byte[8];
      for (int index = 7; index >= 0; --index)
      {
        numArray[index] = (byte) (uint64 & (ulong) byte.MaxValue);
        uint64 >>= 8;
      }
      return numArray;
    }

    internal static DateTime smethod_3(byte[] dateBytes)
    {
      return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds((double) (((int) dateBytes[0] << 24) + ((int) dateBytes[1] << 16) + ((int) dateBytes[2] << 8) + (int) dateBytes[3] + ((int) dateBytes[4] << 24) + ((int) dateBytes[5] << 16) + ((int) dateBytes[6] << 8) + (int) dateBytes[7]));
    }

    internal static void smethod_4(byte[] bytes, int index, int value)
    {
      bytes[index++] = (byte) (value & (int) byte.MaxValue);
      bytes[index] = (byte) ((value & 65280) >> 8);
    }
  }
}
