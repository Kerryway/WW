// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfValueFormat
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Globalization;
using System.Text;
using WW.Cad.IO;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Math;
using WW.Text;

namespace WW.Cad.Model
{
  public abstract class DxfValueFormat
  {
    public static readonly DxfValueFormat NoneInstance = (DxfValueFormat) new DxfValueFormat.None();
    public static readonly DxfValueFormat GeneralInstance = (DxfValueFormat) new DxfValueFormat.General();
    private ValueDataType valueDataType_0;
    private ValueUnitType valueUnitType_0;
    private string string_0;

    public event EventHandler Changed;

    protected DxfValueFormat(ValueDataType dataType, ValueUnitType unitType)
    {
      this.valueDataType_0 = dataType;
      this.valueUnitType_0 = unitType;
    }

    protected DxfValueFormat(ValueDataType dataType)
    {
      this.valueDataType_0 = dataType;
      this.valueUnitType_0 = ValueUnitType.None;
    }

    public static DxfValueFormat Create(
      ValueDataType dataType,
      ValueUnitType unitType)
    {
      return DxfValueFormat.Create(dataType, unitType, (string) null);
    }

    public abstract DxfValueFormat Clone();

    internal string _FormatString
    {
      get
      {
        if (this.string_0 == null)
          this.method_1();
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
        this.method_0();
      }
    }

    public ValueDataType DataType
    {
      get
      {
        return this.valueDataType_0;
      }
    }

    public ValueUnitType UnitType
    {
      get
      {
        return this.valueUnitType_0;
      }
    }

    internal static DxfValueFormat Create(
      ValueDataType dataType,
      ValueUnitType unitType,
      string formatString)
    {
      DxfValueFormat dxfValueFormat = (DxfValueFormat) null;
      switch (dataType)
      {
        case ValueDataType.None:
          dxfValueFormat = (DxfValueFormat) new DxfValueFormat.None(dataType, unitType);
          break;
        case ValueDataType.Int:
          dxfValueFormat = (DxfValueFormat) new DxfValueFormat.WholeNumber(dataType, unitType);
          break;
        case ValueDataType.Double:
          switch (unitType)
          {
            case ValueUnitType.None:
              dxfValueFormat = (DxfValueFormat) new DxfValueFormat.DecimalNumber(dataType, unitType);
              break;
            case ValueUnitType.Angle:
              dxfValueFormat = (DxfValueFormat) new DxfValueFormat.Angle(dataType, unitType);
              break;
            case ValueUnitType.Currency:
              dxfValueFormat = (DxfValueFormat) new DxfValueFormat.Currency(dataType, unitType);
              break;
            case ValueUnitType.Percentage:
              dxfValueFormat = (DxfValueFormat) new DxfValueFormat.Percentage(dataType, unitType);
              break;
          }
        case ValueDataType.String:
          dxfValueFormat = (DxfValueFormat) new DxfValueFormat.String(dataType, unitType);
          break;
        case ValueDataType.Date:
          dxfValueFormat = (DxfValueFormat) new DxfValueFormat.Date(dataType, unitType);
          break;
        case ValueDataType.Point2D:
          dxfValueFormat = (DxfValueFormat) new DxfValueFormat.Point2D(dataType, unitType);
          break;
        case ValueDataType.Point3D:
          dxfValueFormat = (DxfValueFormat) new DxfValueFormat.Point3D(dataType, unitType);
          break;
        case ValueDataType.ObjectHandle:
          dxfValueFormat = (DxfValueFormat) new DxfValueFormat.ObjectHandle(dataType, unitType);
          break;
        case ValueDataType.Buffer:
          throw new NotImplementedException("Not yet implemented: value data type 'Buffer'!");
        case ValueDataType.ResultBuffer:
          throw new NotImplementedException("Not yet implemented: value data type 'ResultBuffer'!");
        case ValueDataType.General:
          dxfValueFormat = (DxfValueFormat) new DxfValueFormat.General(dataType, unitType);
          break;
      }
      if (dxfValueFormat == null)
        dxfValueFormat = (DxfValueFormat) new DxfValueFormat.General(dataType, unitType);
      dxfValueFormat.string_0 = formatString;
      return dxfValueFormat;
    }

    internal static DxfValueFormat Create(
      ValueDataType? dataType,
      ValueUnitType? unitType,
      string formatString)
    {
      return !dataType.HasValue ? DxfValueFormat.Create(ValueDataType.General, ValueUnitType.None, formatString) : (!unitType.HasValue ? DxfValueFormat.Create(dataType.Value, ValueUnitType.None, formatString) : DxfValueFormat.Create(dataType.Value, unitType.Value, formatString));
    }

    internal void method_0()
    {
      if (string.IsNullOrEmpty(this.string_0))
        return;
      for (int char0Index = 0; char0Index < this.string_0.Length; ++char0Index)
      {
        if (this.string_0[char0Index] == '%')
        {
          ++char0Index;
          this.ParseFormatElement(ref char0Index);
        }
      }
    }

    protected internal virtual void ParseFormatElement(ref int char0Index)
    {
    }

    protected internal bool GetSquareBracketedString(ref int char0Index, out string s)
    {
      bool flag = false;
      s = (string) null;
      if (this._FormatString.Length > char0Index && this._FormatString[char0Index] == '[')
      {
        StringBuilder stringBuilder = new StringBuilder(10);
        for (int index = char0Index + 1; index < this._FormatString.Length; ++index)
        {
          char ch = this._FormatString[index];
          if (ch != ']')
          {
            stringBuilder.Append(ch);
          }
          else
          {
            char0Index = index;
            flag = true;
            break;
          }
        }
        s = stringBuilder.ToString();
      }
      return flag;
    }

    protected internal bool GetInt(ref int charIndex, out int i)
    {
      bool flag = false;
      i = -1;
      StringBuilder stringBuilder = new StringBuilder(3);
      while (charIndex < this._FormatString.Length)
      {
        char c = this._FormatString[charIndex];
        if (char.IsDigit(c))
        {
          stringBuilder.Append(c);
          ++charIndex;
        }
        else
          break;
      }
      string s = stringBuilder.ToString();
      if (!string.IsNullOrEmpty(s))
      {
        flag = true;
        i = int.Parse(s);
      }
      return flag;
    }

    internal void method_1()
    {
      StringBuilder sb = new StringBuilder(32);
      this.AppendToFormatString(sb);
      this.string_0 = sb.ToString();
    }

    protected internal virtual void AppendToFormatString(StringBuilder sb)
    {
    }

    internal abstract string GetValueString(object value);

    protected internal virtual void OnChanged(EventArgs e)
    {
      this.string_0 = (string) null;
      if (this.eventHandler_0 == null)
        return;
      this.eventHandler_0((object) this, e);
    }

    internal void Write(DxfWriter w)
    {
      w.Write(92, (object) (int) this.valueDataType_0);
      w.Write(93, (object) (int) this.valueUnitType_0);
      w.Write(300, (object) this.string_0);
    }

    public class None : DxfValueFormat
    {
      internal None(ValueDataType dataType, ValueUnitType unitType)
        : base(dataType, unitType)
      {
      }

      public None()
        : base(ValueDataType.None)
      {
      }

      public override DxfValueFormat Clone()
      {
        DxfValueFormat.None none = new DxfValueFormat.None();
        none._FormatString = this._FormatString;
        return (DxfValueFormat) none;
      }

      internal override string GetValueString(object value)
      {
        return Convert.ToString(value, (IFormatProvider) CultureInfo.InvariantCulture);
      }
    }

    public class General : DxfValueFormat
    {
      public General()
        : base(ValueDataType.General)
      {
      }

      internal General(ValueDataType dataType, ValueUnitType unitType)
        : base(dataType, unitType)
      {
      }

      public override DxfValueFormat Clone()
      {
        DxfValueFormat.General general = new DxfValueFormat.General();
        general._FormatString = this._FormatString;
        return (DxfValueFormat) general;
      }

      internal override string GetValueString(object value)
      {
        return Convert.ToString(value, (IFormatProvider) CultureInfo.InvariantCulture);
      }
    }

    public class String : DxfValueFormat
    {
      private CellStringFormat cellStringFormat_0;

      public new ValueDataType DataType
      {
        get
        {
          return this.valueDataType_0;
        }
        set
        {
          this.valueDataType_0 = value;
        }
      }

      public new ValueUnitType UnitType
      {
        get
        {
          return this.valueUnitType_0;
        }
        set
        {
          this.valueUnitType_0 = value;
        }
      }

      internal String(ValueDataType dataType, ValueUnitType unitType)
        : base(dataType, unitType)
      {
      }

      public String()
        : base(ValueDataType.String)
      {
      }

      public String(CellStringFormat cellStringFormat)
        : base(ValueDataType.String)
      {
        this.cellStringFormat_0 = cellStringFormat;
      }

      public CellStringFormat CellStringFormat
      {
        get
        {
          return this.cellStringFormat_0;
        }
        set
        {
          this.cellStringFormat_0 = value;
        }
      }

      public override DxfValueFormat Clone()
      {
        DxfValueFormat.String @string = new DxfValueFormat.String();
        @string._FormatString = this._FormatString;
        return (DxfValueFormat) @string;
      }

      protected internal override void ParseFormatElement(ref int char0Index)
      {
        bool flag = false;
        int index1 = char0Index + 1;
        int index2 = char0Index + 2;
        if (this._FormatString.Length > index2 && this._FormatString[char0Index] == 't' && this._FormatString[index1] == 'c')
        {
          switch (this._FormatString[index2])
          {
            case '1':
              flag = true;
              this.cellStringFormat_0 = CellStringFormat.UpperCase;
              break;
            case '2':
              flag = true;
              this.cellStringFormat_0 = CellStringFormat.LowerCase;
              break;
            case '3':
              flag = true;
              this.cellStringFormat_0 = CellStringFormat.FirstCapital;
              break;
            case '4':
              flag = true;
              this.cellStringFormat_0 = CellStringFormat.TitleCase;
              break;
          }
          if (flag)
            char0Index = index2;
        }
        if (flag)
          return;
        base.ParseFormatElement(ref char0Index);
      }

      protected internal override void AppendToFormatString(StringBuilder sb)
      {
        base.AppendToFormatString(sb);
        switch (this.cellStringFormat_0)
        {
          case CellStringFormat.UpperCase:
            sb.Append("%tc1");
            break;
          case CellStringFormat.LowerCase:
            sb.Append("%tc2");
            break;
          case CellStringFormat.FirstCapital:
            sb.Append("%tc3");
            break;
          case CellStringFormat.TitleCase:
            sb.Append("%tc4");
            break;
        }
      }

      internal override string GetValueString(object value)
      {
        string str1 = string.Empty;
        switch (this.cellStringFormat_0)
        {
          case CellStringFormat.None:
            str1 = (string) value;
            break;
          case CellStringFormat.UpperCase:
            str1 = ((string) value).ToUpperInvariant();
            break;
          case CellStringFormat.LowerCase:
            str1 = ((string) value).ToLowerInvariant();
            break;
          case CellStringFormat.FirstCapital:
            string str2 = (string) value;
            if (str2.Length > 0)
            {
              str1 = str2.Substring(0, 1).ToUpperInvariant();
              if (str2.Length > 1)
              {
                str1 += str2.Substring(1);
                break;
              }
              break;
            }
            break;
          case CellStringFormat.TitleCase:
            string str3 = (string) value;
            StringBuilder stringBuilder = new StringBuilder(str3.Length);
            bool flag = true;
            for (int index = 0; index < str3.Length; ++index)
            {
              char c = str3[index];
              if (flag)
              {
                if (char.IsLetterOrDigit(c))
                {
                  c = char.ToUpperInvariant(c);
                  flag = false;
                }
              }
              else
              {
                c = char.ToLowerInvariant(c);
                flag = !char.IsLetterOrDigit(c);
              }
              stringBuilder.Append(c);
            }
            str1 = stringBuilder.ToString();
            break;
        }
        return str1;
      }
    }

    public abstract class Numeric : DxfValueFormat
    {
      public const char DefaultThousandsSeparator = ',';
      private string string_1;
      private string string_2;

      protected Numeric(ValueDataType dataType, ValueUnitType unitType)
        : base(dataType, unitType)
      {
      }

      protected Numeric(ValueDataType dataType)
        : base(dataType)
      {
      }

      public string Prefix
      {
        get
        {
          return this.string_1;
        }
        set
        {
          this.string_1 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      public string Postfix
      {
        get
        {
          return this.string_2;
        }
        set
        {
          this.string_2 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      protected internal override void ParseFormatElement(ref int char0Index)
      {
        bool flag = false;
        int index = char0Index + 1;
        if (this._FormatString.Length > index && this._FormatString[char0Index] == 'p' && this._FormatString[index] == 's')
        {
          int char0Index1 = char0Index + 2;
          string s;
          if (this.GetSquareBracketedString(ref char0Index1, out s))
          {
            flag = true;
            char0Index = char0Index1;
            string[] strArray = s.Split(',');
            if (strArray.Length > 0)
              this.string_1 = strArray[0];
            if (strArray.Length > 1)
              this.string_1 = strArray[1];
          }
        }
        if (flag)
          return;
        base.ParseFormatElement(ref char0Index);
      }

      protected internal override void AppendToFormatString(StringBuilder sb)
      {
        base.AppendToFormatString(sb);
        if (string.IsNullOrEmpty(this.string_1) && string.IsNullOrEmpty(this.string_2))
          return;
        sb.Append("%ps[");
        if (!string.IsNullOrEmpty(this.string_1))
          sb.Append(this.string_1);
        sb.Append(",");
        if (!string.IsNullOrEmpty(this.string_2))
          sb.Append(this.string_2);
        sb.Append("]");
      }
    }

    public abstract class Numeric2 : DxfValueFormat.Numeric
    {
      private double double_0 = 1.0;
      private char char_0 = ',';

      protected Numeric2(ValueDataType dataType, ValueUnitType unitType)
        : base(dataType, unitType)
      {
      }

      protected Numeric2(ValueDataType dataType)
        : base(dataType)
      {
      }

      public double ConversionFactor
      {
        get
        {
          return this.double_0;
        }
        set
        {
          this.double_0 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      public char ThousandsSeparator
      {
        get
        {
          return this.char_0;
        }
        set
        {
          this.char_0 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      protected internal override void ParseFormatElement(ref int char0Index)
      {
        bool flag = false;
        int index1 = char0Index + 1;
        if (index1 < this._FormatString.Length)
        {
          if (this._FormatString[char0Index] == 'c' && this._FormatString[index1] == 't')
          {
            int index2 = char0Index + 2;
            if (this._FormatString.Length > index2 && this._FormatString[index2] == '8')
            {
              int char0Index1 = char0Index + 3;
              string s;
              if (this.GetSquareBracketedString(ref char0Index1, out s))
              {
                char0Index = char0Index1;
                flag = true;
                this.double_0 = double.Parse(s, (IFormatProvider) CultureInfo.InvariantCulture);
              }
            }
          }
          else if (this._FormatString[char0Index] == 't' && this._FormatString[index1] == 'h')
          {
            int charIndex = char0Index + 2;
            int i;
            if (this.GetInt(ref charIndex, out i))
            {
              flag = true;
              char0Index = charIndex - 1;
              this.char_0 = (char) i;
            }
          }
        }
        if (flag)
          return;
        base.ParseFormatElement(ref char0Index);
      }

      protected internal override void AppendToFormatString(StringBuilder sb)
      {
        base.AppendToFormatString(sb);
        if (!MathUtil.AreApproxEqual(this.double_0, 1.0))
        {
          sb.Append("%ct");
          sb.Append(this.double_0.ToString((IFormatProvider) CultureInfo.InvariantCulture));
        }
        if (this.char_0 == ',')
          return;
        byte[] bytes = Encodings.Ascii.GetBytes(new char[1]{ this.char_0 });
        if (bytes.Length <= 0)
          return;
        sb.Append("%th");
        sb.Append(bytes[0].ToString());
      }
    }

    public abstract class Numeric3 : DxfValueFormat.Numeric2
    {
      private int int_0 = 4;
      private char char_1 = '.';

      protected Numeric3(ValueDataType dataType, ValueUnitType unitType)
        : base(dataType, unitType)
      {
      }

      protected Numeric3(ValueDataType dataType)
        : base(dataType)
      {
      }

      internal int _Precision
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

      public char DecimalSeparator
      {
        get
        {
          return this.char_1;
        }
        set
        {
          this.char_1 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      protected internal override void ParseFormatElement(ref int char0Index)
      {
        bool flag = false;
        int index1 = char0Index + 1;
        int index2 = char0Index + 2;
        if (index2 < this._FormatString.Length)
        {
          char ch1 = this._FormatString[char0Index];
          char ch2 = this._FormatString[index1];
          if (ch1 == 'p' && ch2 == 'r')
          {
            flag = true;
            this.int_0 = int.Parse(this._FormatString[index2].ToString());
          }
          else if (ch1 == 'd' && ch2 == 's')
          {
            int charIndex = char0Index + 2;
            int i;
            if (this.GetInt(ref charIndex, out i))
            {
              flag = true;
              char0Index = charIndex - 1;
              this.char_1 = (char) i;
            }
          }
        }
        if (flag)
          return;
        base.ParseFormatElement(ref char0Index);
      }

      protected internal override void AppendToFormatString(StringBuilder sb)
      {
        base.AppendToFormatString(sb);
        if (this.char_1 == '.')
          return;
        byte[] bytes = Encodings.Ascii.GetBytes(new char[1]{ this.char_1 });
        if (bytes.Length <= 0)
          return;
        sb.Append("%ds");
        sb.Append(bytes[0].ToString());
      }

      internal void method_2(StringBuilder sb)
      {
        sb.Append("%pr");
        sb.Append(this.int_0.ToString());
      }
    }

    public class DecimalNumber : DxfValueFormat.Numeric3
    {
      private LinearUnitFormat? nullable_0 = new LinearUnitFormat?();
      private ZeroSuppressionFlags zeroSuppressionFlags_0;

      public DecimalNumber()
        : base(ValueDataType.Double, ValueUnitType.None)
      {
        this.Precision = 4;
      }

      public DecimalNumber(LinearUnitFormat? linearUnitFormat)
        : this()
      {
        this.nullable_0 = linearUnitFormat;
      }

      internal DecimalNumber(ValueDataType dataType, ValueUnitType unitType)
        : base(dataType, unitType)
      {
      }

      internal DecimalNumber(ValueDataType dataType)
        : base(dataType)
      {
      }

      public LinearUnitFormat? LinearUnitFormat
      {
        get
        {
          return this.nullable_0;
        }
        set
        {
          this.nullable_0 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      public int Precision
      {
        get
        {
          return this._Precision;
        }
        set
        {
          this._Precision = value;
        }
      }

      public bool SuppressZeroFeet
      {
        get
        {
          return (this.zeroSuppressionFlags_0 & ZeroSuppressionFlags.SuppressZeroFeet) != ZeroSuppressionFlags.None;
        }
        set
        {
          if (value)
            this.zeroSuppressionFlags_0 |= ZeroSuppressionFlags.SuppressZeroFeet;
          else
            this.zeroSuppressionFlags_0 &= ~ZeroSuppressionFlags.SuppressZeroFeet;
        }
      }

      public bool SuppressZeroInches
      {
        get
        {
          return (this.zeroSuppressionFlags_0 & ZeroSuppressionFlags.SuppressZeroInches) != ZeroSuppressionFlags.None;
        }
        set
        {
          if (value)
            this.zeroSuppressionFlags_0 |= ZeroSuppressionFlags.SuppressZeroInches;
          else
            this.zeroSuppressionFlags_0 &= ~ZeroSuppressionFlags.SuppressZeroInches;
        }
      }

      public bool SuppressLeadingZeros
      {
        get
        {
          return (this.zeroSuppressionFlags_0 & ZeroSuppressionFlags.SuppressLeadingZeros) != ZeroSuppressionFlags.None;
        }
        set
        {
          if (value)
            this.zeroSuppressionFlags_0 |= ZeroSuppressionFlags.SuppressLeadingZeros;
          else
            this.zeroSuppressionFlags_0 &= ~ZeroSuppressionFlags.SuppressLeadingZeros;
        }
      }

      public bool SuppressTrailingZeros
      {
        get
        {
          return (this.zeroSuppressionFlags_0 & ZeroSuppressionFlags.SuppressTrailingZeros) != ZeroSuppressionFlags.None;
        }
        set
        {
          if (value)
            this.zeroSuppressionFlags_0 |= ZeroSuppressionFlags.SuppressTrailingZeros;
          else
            this.zeroSuppressionFlags_0 &= ~ZeroSuppressionFlags.SuppressTrailingZeros;
        }
      }

      public ZeroSuppressionFlags ZeroSuppressionFlags
      {
        get
        {
          return this.zeroSuppressionFlags_0;
        }
        set
        {
          this.zeroSuppressionFlags_0 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      public override DxfValueFormat Clone()
      {
        DxfValueFormat.DecimalNumber decimalNumber = new DxfValueFormat.DecimalNumber();
        decimalNumber._FormatString = this._FormatString;
        return (DxfValueFormat) decimalNumber;
      }

      protected internal override void ParseFormatElement(ref int char0Index)
      {
        bool flag = false;
        int index1 = char0Index + 1;
        int index2 = char0Index + 2;
        if (index2 < this._FormatString.Length)
        {
          char ch1 = this._FormatString[char0Index];
          char ch2 = this._FormatString[index1];
          if (ch1 == 'z' && ch2 == 's')
          {
            flag = true;
            this.zeroSuppressionFlags_0 = (ZeroSuppressionFlags) int.Parse(this._FormatString[index2].ToString());
          }
          else if (ch1 == 'l' && ch2 == 'u')
          {
            switch (this._FormatString[index2])
            {
              case '1':
                flag = true;
                this.nullable_0 = new LinearUnitFormat?(LinearUnitFormat.Scientific);
                break;
              case '2':
                flag = true;
                this.nullable_0 = new LinearUnitFormat?(LinearUnitFormat.Decimal);
                break;
              case '3':
                flag = true;
                this.nullable_0 = new LinearUnitFormat?(LinearUnitFormat.Engineering);
                break;
              case '4':
                flag = true;
                this.nullable_0 = new LinearUnitFormat?(LinearUnitFormat.Architectural);
                break;
              case '5':
                flag = true;
                this.nullable_0 = new LinearUnitFormat?(LinearUnitFormat.Fractional);
                break;
              case '6':
                flag = true;
                this.nullable_0 = new LinearUnitFormat?(LinearUnitFormat.WindowsDesktop);
                break;
            }
            if (flag)
              char0Index = index2;
          }
        }
        if (flag)
          return;
        base.ParseFormatElement(ref char0Index);
      }

      protected internal override void AppendToFormatString(StringBuilder sb)
      {
        base.AppendToFormatString(sb);
        bool flag = false;
        if (this.nullable_0.HasValue)
        {
          switch (this.nullable_0.Value)
          {
            case LinearUnitFormat.Scientific:
              sb.Append("%lu1");
              flag = true;
              break;
            case LinearUnitFormat.Decimal:
              sb.Append("%lu2");
              flag = true;
              break;
            case LinearUnitFormat.Engineering:
              sb.Append("%lu3");
              flag = true;
              break;
            case LinearUnitFormat.Architectural:
              sb.Append("%lu4");
              flag = true;
              break;
            case LinearUnitFormat.Fractional:
              sb.Append("%lu5");
              flag = true;
              break;
            case LinearUnitFormat.WindowsDesktop:
              sb.Append("%lu6");
              break;
          }
        }
        if (flag)
          this.method_2(sb);
        if (this.zeroSuppressionFlags_0 == ZeroSuppressionFlags.None)
          return;
        sb.Append("%zs");
        sb.Append(((int) this.zeroSuppressionFlags_0).ToString());
      }

      internal override string GetValueString(object value)
      {
        string empty = string.Empty;
        double num = Convert.ToDouble(value) * this.ConversionFactor;
        string str;
        if (this.nullable_0.HasValue)
          str = DxfDimension.GetLinearMeasurementText((IDimensionStyle) new DxfDimensionStyle()
          {
            LinearUnitFormat = this.nullable_0.Value,
            DecimalPlaces = (short) this.Precision,
            DecimalSeparator = this.DecimalSeparator,
            ZeroHandling = DxfValueFormat.DecimalNumber.smethod_0(this.zeroSuppressionFlags_0)
          }, num, new char?(this.ThousandsSeparator));
        else
          str = Convert.ToString(num, (IFormatProvider) CultureInfo.InvariantCulture);
        if (!string.IsNullOrEmpty(this.Prefix))
          str = this.Prefix + str;
        if (!string.IsNullOrEmpty(this.Postfix))
          str += this.Postfix;
        return str;
      }

      internal static ZeroHandling smethod_0(ZeroSuppressionFlags zeroSuppressionFlags)
      {
        return (zeroSuppressionFlags & (ZeroSuppressionFlags.SuppressZeroFeet | ZeroSuppressionFlags.SuppressZeroInches)) == ZeroSuppressionFlags.None ? ((zeroSuppressionFlags & ZeroSuppressionFlags.SuppressLeadingZeros) == ZeroSuppressionFlags.None ? ((zeroSuppressionFlags & ZeroSuppressionFlags.SuppressTrailingZeros) == ZeroSuppressionFlags.None ? ZeroHandling.ShowZeroFeetAndInches : ZeroHandling.SuppressDecimalTrailingZeroes) : ((zeroSuppressionFlags & ZeroSuppressionFlags.SuppressTrailingZeros) == ZeroSuppressionFlags.None ? ZeroHandling.SuppressDecimalLeadingZeroes : ZeroHandling.SuppressDecimalLeadingAndTrailingZeroes)) : ((zeroSuppressionFlags & ZeroSuppressionFlags.SuppressZeroFeet) == ZeroSuppressionFlags.None ? ((zeroSuppressionFlags & ZeroSuppressionFlags.SuppressZeroInches) == ZeroSuppressionFlags.None ? ZeroHandling.ShowZeroFeetAndInches : ZeroHandling.ShowZeroFeetSuppressZeroInches) : ((zeroSuppressionFlags & ZeroSuppressionFlags.SuppressZeroInches) == ZeroSuppressionFlags.None ? ZeroHandling.SuppressZeroFeetShowZeroInches : ZeroHandling.SuppressZeroFeetAndInches));
      }
    }

    public class Percentage : DxfValueFormat.Numeric3
    {
      private ZeroSuppressionFlags zeroSuppressionFlags_0;

      public Percentage()
        : base(ValueDataType.Double, ValueUnitType.Percentage)
      {
        this.Postfix = "%";
        this.Precision = 2;
      }

      internal Percentage(ValueDataType dataType, ValueUnitType unitType)
        : base(dataType, unitType)
      {
      }

      public int Precision
      {
        get
        {
          return this._Precision;
        }
        set
        {
          this._Precision = value;
          this.OnChanged((EventArgs) null);
        }
      }

      public bool SuppressZeroFeet
      {
        get
        {
          return (this.zeroSuppressionFlags_0 & ZeroSuppressionFlags.SuppressZeroFeet) != ZeroSuppressionFlags.None;
        }
        set
        {
          if (value)
            this.zeroSuppressionFlags_0 |= ZeroSuppressionFlags.SuppressZeroFeet;
          else
            this.zeroSuppressionFlags_0 &= ~ZeroSuppressionFlags.SuppressZeroFeet;
        }
      }

      public bool SuppressZeroInches
      {
        get
        {
          return (this.zeroSuppressionFlags_0 & ZeroSuppressionFlags.SuppressZeroInches) != ZeroSuppressionFlags.None;
        }
        set
        {
          if (value)
            this.zeroSuppressionFlags_0 |= ZeroSuppressionFlags.SuppressZeroInches;
          else
            this.zeroSuppressionFlags_0 &= ~ZeroSuppressionFlags.SuppressZeroInches;
        }
      }

      public bool SuppressLeadingZeros
      {
        get
        {
          return (this.zeroSuppressionFlags_0 & ZeroSuppressionFlags.SuppressLeadingZeros) != ZeroSuppressionFlags.None;
        }
        set
        {
          if (value)
            this.zeroSuppressionFlags_0 |= ZeroSuppressionFlags.SuppressLeadingZeros;
          else
            this.zeroSuppressionFlags_0 &= ~ZeroSuppressionFlags.SuppressLeadingZeros;
        }
      }

      public bool SuppressTrailingZeros
      {
        get
        {
          return (this.zeroSuppressionFlags_0 & ZeroSuppressionFlags.SuppressTrailingZeros) != ZeroSuppressionFlags.None;
        }
        set
        {
          if (value)
            this.zeroSuppressionFlags_0 |= ZeroSuppressionFlags.SuppressTrailingZeros;
          else
            this.zeroSuppressionFlags_0 &= ~ZeroSuppressionFlags.SuppressTrailingZeros;
        }
      }

      public ZeroSuppressionFlags ZeroSuppressionFlags
      {
        get
        {
          return this.zeroSuppressionFlags_0;
        }
        set
        {
          this.zeroSuppressionFlags_0 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      public override DxfValueFormat Clone()
      {
        DxfValueFormat.Percentage percentage = new DxfValueFormat.Percentage();
        percentage._FormatString = this._FormatString;
        return (DxfValueFormat) percentage;
      }

      protected internal override void ParseFormatElement(ref int char0Index)
      {
        bool flag = false;
        int index1 = char0Index + 1;
        int index2 = char0Index + 2;
        if (index2 < this._FormatString.Length)
        {
          char ch1 = this._FormatString[char0Index];
          char ch2 = this._FormatString[index1];
          if (ch1 == 'z' && ch2 == 's')
          {
            flag = true;
            this.zeroSuppressionFlags_0 = (ZeroSuppressionFlags) int.Parse(this._FormatString[index2].ToString());
          }
        }
        if (flag)
          return;
        base.ParseFormatElement(ref char0Index);
      }

      protected internal override void AppendToFormatString(StringBuilder sb)
      {
        base.AppendToFormatString(sb);
        this.method_2(sb);
        if (this.zeroSuppressionFlags_0 == ZeroSuppressionFlags.None)
          return;
        sb.Append("%zs");
        sb.Append(((int) this.zeroSuppressionFlags_0).ToString());
      }

      internal override string GetValueString(object value)
      {
        string empty = string.Empty;
        string str = DxfDimension.GetLinearMeasurementText((IDimensionStyle) new DxfDimensionStyle() { LinearUnitFormat = LinearUnitFormat.Decimal, DecimalPlaces = (short) this.Precision, DecimalSeparator = this.DecimalSeparator, ZeroHandling = DxfValueFormat.DecimalNumber.smethod_0(this.zeroSuppressionFlags_0) }, Convert.ToDouble(value) * this.ConversionFactor, new char?(this.ThousandsSeparator));
        if (!string.IsNullOrEmpty(this.Prefix))
          str = this.Prefix + str;
        if (!string.IsNullOrEmpty(this.Postfix))
          str += this.Postfix;
        return str;
      }
    }

    public class Point2D : DxfValueFormat.DecimalNumber
    {
      private char char_2 = ',';
      private bool bool_0 = true;
      private bool bool_1 = true;
      public const char DefaultCoordinateSeparator = ',';

      public Point2D()
        : base(ValueDataType.Point2D, ValueUnitType.None)
      {
      }

      internal Point2D(ValueDataType dataType, ValueUnitType unitType)
        : base(dataType, unitType)
      {
      }

      public char CoordinateSeparator
      {
        get
        {
          return this.char_2;
        }
        set
        {
          this.char_2 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      public bool DisplayX
      {
        get
        {
          return this.bool_0;
        }
        set
        {
          this.bool_0 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      public bool DisplayY
      {
        get
        {
          return this.bool_1;
        }
        set
        {
          this.bool_1 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      public override DxfValueFormat Clone()
      {
        DxfValueFormat.Point2D point2D = new DxfValueFormat.Point2D();
        point2D._FormatString = this._FormatString;
        return (DxfValueFormat) point2D;
      }

      protected internal override void ParseFormatElement(ref int char0Index)
      {
        bool flag = false;
        int index1 = char0Index + 1;
        int index2 = char0Index + 2;
        if (index2 < this._FormatString.Length)
        {
          char ch1 = this._FormatString[char0Index];
          char ch2 = this._FormatString[index1];
          if (ch1 == 'l' && ch2 == 's')
          {
            int charIndex = char0Index + 2;
            int i;
            if (this.GetInt(ref charIndex, out i))
            {
              flag = true;
              char0Index = charIndex - 1;
              this.char_2 = (char) i;
            }
          }
          else if (ch1 == 'p' && ch2 == 't')
          {
            flag = true;
            int num = int.Parse(this._FormatString[index2].ToString());
            this.bool_0 = (num & 1) != 0;
            this.bool_1 = (num & 2) != 0;
          }
        }
        if (flag)
          return;
        base.ParseFormatElement(ref char0Index);
      }

      protected internal override void AppendToFormatString(StringBuilder sb)
      {
        base.AppendToFormatString(sb);
        if (this.char_2 != ',')
        {
          byte[] bytes = Encodings.Ascii.GetBytes(new char[1]{ this.char_2 });
          if (bytes.Length > 0)
          {
            sb.Append("%ls");
            sb.Append(bytes[0].ToString());
          }
        }
        if (this.bool_0 && this.bool_1)
          return;
        int num = (this.bool_0 ? 1 : 0) | (this.bool_1 ? 2 : 0);
        sb.Append("%pt");
        sb.Append(num.ToString());
      }

      internal override string GetValueString(object value)
      {
        WW.Math.Point3D point3D1 = (WW.Math.Point3D) value;
        string str = string.Empty;
        WW.Math.Point3D point3D2 = new WW.Math.Point3D(point3D1.X * this.ConversionFactor, point3D1.Y * this.ConversionFactor, point3D1.Z * this.ConversionFactor);
        if (this.LinearUnitFormat.HasValue)
        {
          DxfDimensionStyle dxfDimensionStyle = new DxfDimensionStyle();
          dxfDimensionStyle.LinearUnitFormat = this.LinearUnitFormat.Value;
          dxfDimensionStyle.DecimalPlaces = (short) this.Precision;
          dxfDimensionStyle.DecimalSeparator = this.DecimalSeparator;
          dxfDimensionStyle.ZeroHandling = DxfValueFormat.DecimalNumber.smethod_0(this.ZeroSuppressionFlags);
          if (this.bool_0)
            str += DxfDimension.GetLinearMeasurementText((IDimensionStyle) dxfDimensionStyle, point3D2.X, new char?(this.ThousandsSeparator));
          if (this.bool_1)
          {
            if (this.bool_0)
              str = str + (object) this.char_2 + " ";
            str += DxfDimension.GetLinearMeasurementText((IDimensionStyle) dxfDimensionStyle, point3D2.Y, new char?(this.ThousandsSeparator));
          }
        }
        else
          str = Convert.ToString((object) point3D2, (IFormatProvider) CultureInfo.InvariantCulture);
        if (!string.IsNullOrEmpty(this.Prefix))
          str = this.Prefix + str;
        if (!string.IsNullOrEmpty(this.Postfix))
          str += this.Postfix;
        return str;
      }
    }

    public class Point3D : DxfValueFormat.DecimalNumber
    {
      private char char_2 = ',';
      private bool bool_0 = true;
      private bool bool_1 = true;
      private bool bool_2 = true;
      public const char DefaultCoordinateSeparator = ',';

      public Point3D()
        : base(ValueDataType.Point3D)
      {
      }

      internal Point3D(ValueDataType dataType, ValueUnitType unitType)
        : base(dataType, unitType)
      {
      }

      public char CoordinateSeparator
      {
        get
        {
          return this.char_2;
        }
        set
        {
          this.char_2 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      public bool DisplayX
      {
        get
        {
          return this.bool_0;
        }
        set
        {
          this.bool_0 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      public bool DisplayY
      {
        get
        {
          return this.bool_1;
        }
        set
        {
          this.bool_1 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      public bool DisplayZ
      {
        get
        {
          return this.bool_2;
        }
        set
        {
          this.bool_2 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      public override DxfValueFormat Clone()
      {
        DxfValueFormat.Point3D point3D = new DxfValueFormat.Point3D();
        point3D._FormatString = this._FormatString;
        return (DxfValueFormat) point3D;
      }

      protected internal override void ParseFormatElement(ref int char0Index)
      {
        bool flag = false;
        int index1 = char0Index + 1;
        int index2 = char0Index + 2;
        if (index2 < this._FormatString.Length)
        {
          char ch1 = this._FormatString[char0Index];
          char ch2 = this._FormatString[index1];
          if (ch1 == 'l' && ch2 == 's')
          {
            int charIndex = char0Index + 2;
            int i;
            if (this.GetInt(ref charIndex, out i))
            {
              flag = true;
              char0Index = charIndex - 1;
              this.char_2 = (char) i;
            }
          }
          else if (ch1 == 'p' && ch2 == 't')
          {
            flag = true;
            int num = int.Parse(this._FormatString[index2].ToString());
            this.bool_0 = (num & 1) != 0;
            this.bool_1 = (num & 2) != 0;
            this.bool_2 = (num & 4) != 0;
          }
        }
        if (flag)
          return;
        base.ParseFormatElement(ref char0Index);
      }

      protected internal override void AppendToFormatString(StringBuilder sb)
      {
        base.AppendToFormatString(sb);
        if (this.char_2 != ',')
        {
          byte[] bytes = Encodings.Ascii.GetBytes(new char[1]{ this.char_2 });
          if (bytes.Length > 0)
          {
            sb.Append("%ls");
            sb.Append(bytes[0].ToString());
          }
        }
        if (this.bool_0 && this.bool_1 && this.bool_2)
          return;
        int num = (this.bool_0 ? 1 : 0) | (this.bool_1 ? 2 : 0) | (this.bool_2 ? 4 : 0);
        sb.Append("%pt");
        sb.Append(num.ToString());
      }

      internal override string GetValueString(object value)
      {
        WW.Math.Point3D point3D1 = (WW.Math.Point3D) value;
        string str = string.Empty;
        WW.Math.Point3D point3D2 = new WW.Math.Point3D(point3D1.X * this.ConversionFactor, point3D1.Y * this.ConversionFactor, point3D1.Z * this.ConversionFactor);
        if (this.LinearUnitFormat.HasValue)
        {
          DxfDimensionStyle dxfDimensionStyle = new DxfDimensionStyle();
          dxfDimensionStyle.LinearUnitFormat = this.LinearUnitFormat.Value;
          dxfDimensionStyle.DecimalPlaces = (short) this.Precision;
          dxfDimensionStyle.DecimalSeparator = this.DecimalSeparator;
          dxfDimensionStyle.ZeroHandling = DxfValueFormat.DecimalNumber.smethod_0(this.ZeroSuppressionFlags);
          if (this.bool_0)
            str += DxfDimension.GetLinearMeasurementText((IDimensionStyle) dxfDimensionStyle, point3D2.X, new char?(this.ThousandsSeparator));
          if (this.bool_1)
          {
            if (this.bool_0)
              str = str + (object) this.char_2 + " ";
            str += DxfDimension.GetLinearMeasurementText((IDimensionStyle) dxfDimensionStyle, point3D2.Y, new char?(this.ThousandsSeparator));
          }
          if (this.bool_2)
          {
            if (this.bool_0 || this.bool_1)
              str = str + (object) this.char_2 + " ";
            str += DxfDimension.GetLinearMeasurementText((IDimensionStyle) dxfDimensionStyle, point3D2.Z, new char?(this.ThousandsSeparator));
          }
        }
        else
          str = Convert.ToString((object) point3D2, (IFormatProvider) CultureInfo.InvariantCulture);
        if (!string.IsNullOrEmpty(this.Prefix))
          str = this.Prefix + str;
        if (!string.IsNullOrEmpty(this.Postfix))
          str += this.Postfix;
        return str;
      }
    }

    public class Angle : DxfValueFormat.Numeric
    {
      private char char_0 = '.';
      private CellAngleFormat cellAngleFormat_0;
      private int int_0;

      internal Angle(ValueDataType dataType, ValueUnitType unitType)
        : base(dataType, unitType)
      {
      }

      public Angle()
        : base(ValueDataType.Double, ValueUnitType.Angle)
      {
      }

      public CellAngleFormat CellAngleFormat
      {
        get
        {
          return this.cellAngleFormat_0;
        }
        set
        {
          this.cellAngleFormat_0 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      public char DecimalSeparator
      {
        get
        {
          return this.char_0;
        }
        set
        {
          this.char_0 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      public int Precision
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

      public override DxfValueFormat Clone()
      {
        DxfValueFormat.Angle angle = new DxfValueFormat.Angle();
        angle._FormatString = this._FormatString;
        return (DxfValueFormat) angle;
      }

      protected internal override void ParseFormatElement(ref int char0Index)
      {
        bool flag = false;
        int index1 = char0Index + 1;
        int index2 = char0Index + 2;
        if (index2 < this._FormatString.Length)
        {
          char ch1 = this._FormatString[char0Index];
          char ch2 = this._FormatString[index1];
          char ch3 = this._FormatString[index2];
          if (ch1 == 'p' && ch2 == 'r')
          {
            flag = true;
            this.int_0 = int.Parse(this._FormatString[index2].ToString());
          }
          else if (ch1 == 'd' && ch2 == 's')
          {
            int charIndex = char0Index + 2;
            int i;
            if (this.GetInt(ref charIndex, out i))
            {
              flag = true;
              char0Index = charIndex - 1;
              this.char_0 = (char) i;
            }
          }
          else if (ch1 == 'a' && ch2 == 'u')
          {
            switch (ch3)
            {
              case '0':
                flag = true;
                this.cellAngleFormat_0 = CellAngleFormat.DecimalDegrees;
                break;
              case '1':
                flag = true;
                this.cellAngleFormat_0 = CellAngleFormat.DegreesMinutesSeconds;
                break;
              case '2':
                flag = true;
                this.cellAngleFormat_0 = CellAngleFormat.Gradians;
                break;
              case '3':
                flag = true;
                this.cellAngleFormat_0 = CellAngleFormat.Radians;
                break;
              case '4':
                flag = true;
                this.cellAngleFormat_0 = CellAngleFormat.SurveyorsUnits;
                break;
              case '5':
                flag = true;
                this.cellAngleFormat_0 = CellAngleFormat.CurrentUnits;
                break;
            }
          }
          if (flag)
            char0Index = index2;
        }
        if (flag)
          return;
        base.ParseFormatElement(ref char0Index);
      }

      protected internal override void AppendToFormatString(StringBuilder sb)
      {
        base.AppendToFormatString(sb);
        switch (this.cellAngleFormat_0)
        {
          case CellAngleFormat.DecimalDegrees:
            sb.Append("%au0");
            break;
          case CellAngleFormat.DegreesMinutesSeconds:
            sb.Append("%au1");
            break;
          case CellAngleFormat.Gradians:
            sb.Append("%au2");
            break;
          case CellAngleFormat.Radians:
            sb.Append("%au3");
            break;
          case CellAngleFormat.SurveyorsUnits:
            sb.Append("%au4");
            break;
          case CellAngleFormat.CurrentUnits:
            sb.Append("%au5");
            break;
        }
        if (this.char_0 != '.')
        {
          byte[] bytes = Encodings.Ascii.GetBytes(new char[1]{ this.char_0 });
          if (bytes.Length > 0)
          {
            sb.Append("%ds");
            sb.Append(bytes[0].ToString());
          }
        }
        sb.Append("%pr");
        sb.Append(this.int_0.ToString());
      }

      internal override string GetValueString(object value)
      {
        string empty = string.Empty;
        double num = System.Math.PI * Convert.ToDouble(value) / 180.0;
        NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
        numberFormatInfo.NumberDecimalSeparator = this.char_0.ToString();
        numberFormatInfo.NumberDecimalDigits = 0;
        string str;
        switch (this.cellAngleFormat_0)
        {
          case CellAngleFormat.None:
          case CellAngleFormat.DecimalDegrees:
          case CellAngleFormat.CurrentUnits:
            str = System.Math.Round(num / System.Math.PI * 180.0, numberFormatInfo.NumberDecimalDigits).ToString("N", (IFormatProvider) numberFormatInfo);
            break;
          case CellAngleFormat.DegreesMinutesSeconds:
            str = System.Math.Round(num / System.Math.PI * 180.0, numberFormatInfo.NumberDecimalDigits).ToString("N", (IFormatProvider) numberFormatInfo) + "°";
            break;
          case CellAngleFormat.Gradians:
            str = System.Math.Round(num / System.Math.PI * 200.0, numberFormatInfo.NumberDecimalDigits).ToString("N", (IFormatProvider) numberFormatInfo) + "g";
            break;
          case CellAngleFormat.SurveyorsUnits:
            str = System.Math.Round(num / System.Math.PI * 180.0, numberFormatInfo.NumberDecimalDigits).ToString("N", (IFormatProvider) numberFormatInfo) + "°";
            break;
          default:
            str = System.Math.Round(num, numberFormatInfo.NumberDecimalDigits).ToString("N", (IFormatProvider) numberFormatInfo) + "r";
            break;
        }
        if (!string.IsNullOrEmpty(this.Prefix))
          str = this.Prefix + str;
        if (!string.IsNullOrEmpty(this.Postfix))
          str += this.Postfix;
        return str;
      }
    }

    public class Currency : DxfValueFormat.Numeric3
    {
      private bool bool_0;

      public Currency()
        : this("$")
      {
      }

      public Currency(string prefix)
        : base(ValueDataType.Double, ValueUnitType.Currency)
      {
        this.Precision = 2;
        this.Prefix = prefix;
      }

      internal Currency(ValueDataType dataType, ValueUnitType unitType)
        : base(dataType, unitType)
      {
      }

      public int Precision
      {
        get
        {
          return this._Precision;
        }
        set
        {
          this._Precision = value;
        }
      }

      public bool UseBracketsForNegativeNumbers
      {
        get
        {
          return this.bool_0;
        }
        set
        {
          this.bool_0 = value;
          this.OnChanged((EventArgs) null);
        }
      }

      public override DxfValueFormat Clone()
      {
        DxfValueFormat.Currency currency = new DxfValueFormat.Currency();
        currency._FormatString = this._FormatString;
        return (DxfValueFormat) currency;
      }

      protected internal override void ParseFormatElement(ref int char0Index)
      {
        bool flag = false;
        int index1 = char0Index + 1;
        if (this._FormatString.Length > index1)
        {
          int index2 = char0Index + 2;
          if (this._FormatString.Length > index2 && this._FormatString[char0Index] == 'n' && (this._FormatString[index1] == 'n' && this._FormatString[index2] == '1'))
          {
            char0Index = index2;
            flag = true;
            this.bool_0 = true;
          }
        }
        if (flag)
          return;
        base.ParseFormatElement(ref char0Index);
      }

      protected internal override void AppendToFormatString(StringBuilder sb)
      {
        base.AppendToFormatString(sb);
        if (!this.bool_0)
          return;
        sb.Append("%nn1");
      }

      internal override string GetValueString(object value)
      {
        string str = Convert.ToDecimal(value).ToString("N", (IFormatProvider) new NumberFormatInfo() { NumberDecimalSeparator = this.DecimalSeparator.ToString(), NumberGroupSeparator = this.ThousandsSeparator.ToString(), NumberDecimalDigits = this.Precision });
        if (!string.IsNullOrEmpty(this.Prefix))
          str = this.Prefix + str;
        if (!string.IsNullOrEmpty(this.Postfix))
          str += this.Postfix;
        return str;
      }
    }

    public class WholeNumber : DxfValueFormat.Numeric2
    {
      public WholeNumber()
        : base(ValueDataType.Int)
      {
      }

      internal WholeNumber(ValueDataType dataType, ValueUnitType unitType)
        : base(dataType, unitType)
      {
      }

      public override DxfValueFormat Clone()
      {
        DxfValueFormat.WholeNumber wholeNumber = new DxfValueFormat.WholeNumber();
        wholeNumber._FormatString = this._FormatString;
        return (DxfValueFormat) wholeNumber;
      }

      internal override string GetValueString(object value)
      {
        string str = Convert.ToInt32(value).ToString((IFormatProvider) new NumberFormatInfo() { NumberGroupSeparator = this.ThousandsSeparator.ToString() });
        if (!string.IsNullOrEmpty(this.Prefix))
          str = this.Prefix + str;
        if (!string.IsNullOrEmpty(this.Postfix))
          str += this.Postfix;
        return str;
      }
    }

    public class Date : DxfValueFormat
    {
      public Date()
        : base(ValueDataType.Date)
      {
      }

      public Date(string formatString)
        : this()
      {
        this._FormatString = formatString;
      }

      internal Date(ValueDataType dataType, ValueUnitType unitType)
        : base(dataType, unitType)
      {
      }

      public Date(ValueDataType dataType)
        : base(dataType)
      {
      }

      public string FormatString
      {
        get
        {
          return this._FormatString;
        }
        set
        {
          this._FormatString = value;
        }
      }

      public override DxfValueFormat Clone()
      {
        DxfValueFormat.Date date = new DxfValueFormat.Date();
        date._FormatString = this._FormatString;
        return (DxfValueFormat) date;
      }

      public static DxfValueFormat.Date CreateRegionalLongDate()
      {
        return new DxfValueFormat.Date("%#x");
      }

      public static DxfValueFormat.Date CreateRegionalLongDateTime()
      {
        return new DxfValueFormat.Date("%#c");
      }

      public static DxfValueFormat.Date CreateRegionalShortDate()
      {
        return new DxfValueFormat.Date("%x");
      }

      public static DxfValueFormat.Date CreateRegionalShortDateTime()
      {
        return new DxfValueFormat.Date("%c");
      }

      public static DxfValueFormat.Date CreateRegionalTime()
      {
        return new DxfValueFormat.Date("%X");
      }

      internal override string GetValueString(object value)
      {
        StringBuilder stringBuilder = new StringBuilder();
        DateTime dateTime = (DateTime) value;
        string formatString = this._FormatString;
        for (int i = 0; i < formatString.Length; ++i)
        {
          char ch = formatString[i];
          switch (ch)
          {
            case '%':
              int index1 = i + 1;
              if (index1 < formatString.Length)
              {
                switch (formatString[index1])
                {
                  case '#':
                    int index2 = i + 2;
                    if (index2 < formatString.Length)
                    {
                      switch (formatString[index2])
                      {
                        case 'c':
                          stringBuilder.Append(dateTime.ToString("F"));
                          i += 2;
                          continue;
                        case 'x':
                          stringBuilder.Append(dateTime.ToString("D"));
                          i += 2;
                          continue;
                        default:
                          stringBuilder.Append(ch);
                          continue;
                      }
                    }
                    else
                      continue;
                  case 'X':
                    stringBuilder.Append(dateTime.ToString("T"));
                    ++i;
                    continue;
                  case 'c':
                    stringBuilder.Append(dateTime.ToString("g"));
                    ++i;
                    continue;
                  case 'x':
                    stringBuilder.Append(dateTime.ToString("d"));
                    ++i;
                    continue;
                  default:
                    stringBuilder.Append(ch);
                    continue;
                }
              }
              else
                break;
            case 'M':
              int num1 = DxfValueFormat.Date.smethod_0(formatString, i, 'M');
              if (num1 == 1)
                stringBuilder.Append(dateTime.Month.ToString("D"));
              else if (num1 == 2)
                stringBuilder.Append(dateTime.Month.ToString("D2"));
              else if (num1 == 3)
                stringBuilder.Append(dateTime.ToString("MMM"));
              else if (num1 == 3)
                stringBuilder.Append(dateTime.ToString("MMMM"));
              i += num1 - 1;
              break;
            case 'd':
              int num2 = DxfValueFormat.Date.smethod_0(formatString, i, 'd');
              if (num2 == 1)
                stringBuilder.Append(dateTime.Day.ToString("D"));
              else if (num2 == 2)
                stringBuilder.Append(dateTime.Day.ToString("D2"));
              else if (num2 == 3)
                stringBuilder.Append(dateTime.ToString("DDD"));
              else if (num2 == 3)
                stringBuilder.Append(dateTime.ToString("DDDD"));
              i += num2 - 1;
              break;
            case 'h':
              int num3 = DxfValueFormat.Date.smethod_0(formatString, i, 'h');
              stringBuilder.Append((dateTime.Hour % 12).ToString("D" + num3.ToString()));
              i += num3 - 1;
              break;
            case 'm':
              int num4 = DxfValueFormat.Date.smethod_0(formatString, i, 'm');
              stringBuilder.Append(dateTime.Minute.ToString("D" + num4.ToString()));
              i += num4 - 1;
              break;
            case 's':
              int num5 = DxfValueFormat.Date.smethod_0(formatString, i, 's');
              stringBuilder.Append(dateTime.Second.ToString("D" + num5.ToString()));
              i += num5 - 1;
              break;
            case 't':
              if (DxfValueFormat.Date.smethod_0(formatString, i, 't') >= 2)
              {
                stringBuilder.Append(dateTime.ToString("tt"));
                ++i;
                break;
              }
              stringBuilder.Append(ch);
              break;
            case 'y':
              int num6 = DxfValueFormat.Date.smethod_0(formatString, i, 'y');
              if (num6 >= 4)
              {
                stringBuilder.Append(dateTime.ToString("yyyy"));
                i += 3;
                break;
              }
              if (num6 >= 2)
              {
                stringBuilder.Append(dateTime.ToString("yy"));
                ++i;
                break;
              }
              stringBuilder.Append(ch);
              break;
            default:
              stringBuilder.Append(ch);
              break;
          }
        }
        return stringBuilder.ToString();
      }

      private static int smethod_0(string s, int i, char c)
      {
        int num = 1;
        for (int index = i + 1; index < s.Length && (int) s[index] == (int) c; ++index)
          ++num;
        return num;
      }
    }

    public class ObjectHandle : DxfValueFormat
    {
      internal ObjectHandle(ValueDataType dataType, ValueUnitType unitType)
        : base(dataType, unitType)
      {
      }

      public ObjectHandle()
        : base(ValueDataType.ObjectHandle)
      {
      }

      public override DxfValueFormat Clone()
      {
        return (DxfValueFormat) new DxfValueFormat.ObjectHandle();
      }

      internal override string GetValueString(object value)
      {
        DxfHandledObject dxfHandledObject = value as DxfHandledObject;
        if (dxfHandledObject == null)
          return "";
        return dxfHandledObject.HandleString;
      }
    }
  }
}
