// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfDimension
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns1;
using ns2;
using ns28;
using ns36;
using ns49;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WW.Actions;
using WW.Cad.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public abstract class DxfDimension : DxfEntity, IAnnotative
  {
    private DxfObjectReference dxfObjectReference_6 = DxfObjectReference.Null;
    private AttachmentPoint attachmentPoint_0 = AttachmentPoint.MiddleCenter;
    private double double_1 = 1.0;
    private Vector3D vector3D_0 = Vector3D.ZAxis;
    protected Vector3D insertionScaleFactor = new Vector3D(1.0, 1.0, 1.0);
    private byte byte_0;
    private WW.Math.Point3D point3D_0;
    private WW.Math.Point3D point3D_1;
    private bool bool_2;
    private LineSpacingStyle lineSpacingStyle_0;
    private double double_2;
    private string string_0;
    private bool bool_3;
    private double double_3;
    private bool bool_4;
    private double double_4;
    private DxfDimensionStyleOverrides dxfDimensionStyleOverrides_0;
    protected double insertionRotation;
    private bool bool_5;
    private bool bool_6;

    protected DxfDimension(DxfDimensionStyle dimensionStyle)
    {
      if (dimensionStyle == null)
        throw new ArgumentNullException(nameof (dimensionStyle));
      this.dxfDimensionStyleOverrides_0 = new DxfDimensionStyleOverrides(dimensionStyle, dimensionStyle.Model);
    }

    protected internal DxfDimension(DxfModel model)
    {
      this.dxfDimensionStyleOverrides_0 = new DxfDimensionStyleOverrides(model);
    }

    public DxfBlock Block
    {
      get
      {
        if (!this.IsAnnotative)
          return (DxfBlock) this.dxfObjectReference_6.Value;
        DxfDimensionObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfDimensionObjectContextData;
        if (objectContextData != null && objectContextData.Block != null)
          return objectContextData.Block;
        return (DxfBlock) this.dxfObjectReference_6.Value;
      }
      set
      {
        if (!this.IsAnnotative)
        {
          this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        }
        else
        {
          DxfDimensionObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfDimensionObjectContextData;
          if (objectContextData != null)
            objectContextData.Block = value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        }
      }
    }

    public WW.Math.Point3D InsertionPoint
    {
      get
      {
        return this.point3D_0;
      }
      set
      {
        this.point3D_0 = value;
      }
    }

    public WW.Math.Point3D InsertionPointWcs
    {
      get
      {
        return this.TransformFromOcs(this.point3D_0);
      }
      set
      {
        this.point3D_0 = this.TransformToOcs(value);
      }
    }

    public WW.Math.Point3D TextMiddlePoint
    {
      get
      {
        if (!this.IsAnnotative)
          return this.point3D_1;
        DxfDimensionObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfDimensionObjectContextData;
        if (objectContextData != null)
          return new WW.Math.Point3D(objectContextData.TextLocation.X, objectContextData.TextLocation.Y, this.point3D_1.Z);
        return this.point3D_1;
      }
      set
      {
        if (!this.IsAnnotative)
        {
          this.point3D_1 = value;
        }
        else
        {
          DxfDimensionObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfDimensionObjectContextData;
          if (objectContextData != null)
          {
            this.point3D_1.Z = value.Z;
            objectContextData.TextLocation = new WW.Math.Point2D(value.X, value.Y);
          }
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.point3D_1 = value;
        }
      }
    }

    public WW.Math.Point3D TextMiddlePointWcs
    {
      get
      {
        return this.TransformFromOcs(this.point3D_1);
      }
      set
      {
        this.point3D_1 = this.TransformToOcs(value);
      }
    }

    public bool UseTextMiddlePoint
    {
      get
      {
        if (!this.IsAnnotative)
          return this.bool_2;
        DxfDimensionObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfDimensionObjectContextData;
        if (objectContextData != null)
          return !objectContextData.DefaultTextLocation;
        return this.bool_2;
      }
      set
      {
        if (!this.IsAnnotative)
        {
          this.bool_2 = value;
        }
        else
        {
          DxfDimensionObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfDimensionObjectContextData;
          if (objectContextData != null)
            objectContextData.DefaultTextLocation = !value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.bool_2 = value;
        }
      }
    }

    public AttachmentPoint AttachmentPoint
    {
      get
      {
        return this.attachmentPoint_0;
      }
      set
      {
        this.attachmentPoint_0 = value;
      }
    }

    public LineSpacingStyle LineSpacingStyle
    {
      get
      {
        return this.lineSpacingStyle_0;
      }
      set
      {
        this.lineSpacingStyle_0 = value;
      }
    }

    public double LineSpacingFactor
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
      }
    }

    public double Measurement
    {
      get
      {
        return this.double_2;
      }
      set
      {
        this.double_2 = value;
      }
    }

    public string Text
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public bool HasTextRotation
    {
      get
      {
        return this.bool_3;
      }
      set
      {
        this.bool_3 = value;
      }
    }

    public double TextRotation
    {
      get
      {
        if (!this.IsAnnotative)
          return this.double_3;
        DxfDimensionObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfDimensionObjectContextData;
        if (objectContextData != null)
          return objectContextData.TextRotation;
        return this.double_3;
      }
      set
      {
        this.bool_3 = true;
        if (!this.IsAnnotative)
        {
          this.double_3 = value;
        }
        else
        {
          DxfDimensionObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfDimensionObjectContextData;
          if (objectContextData != null)
            objectContextData.TextRotation = value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.double_3 = value;
        }
      }
    }

    public bool HasHorizontalDirection
    {
      get
      {
        return this.bool_4;
      }
      set
      {
        this.bool_4 = value;
      }
    }

    public double HorizontalDirection
    {
      get
      {
        return this.double_4;
      }
      set
      {
        this.double_4 = value;
      }
    }

    public DxfDimensionStyleOverrides DimensionStyleOverrides
    {
      get
      {
        return this.dxfDimensionStyleOverrides_0;
      }
    }

    public DxfDimensionStyle DimensionStyle
    {
      get
      {
        return this.dxfDimensionStyleOverrides_0.BaseDimensionStyle;
      }
      set
      {
        this.dxfDimensionStyleOverrides_0.BaseDimensionStyle = value;
      }
    }

    public Vector3D ZAxis
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        if (value == Vector3D.Zero)
          throw new ArgumentException("Null vector not allowed for ZAxis");
        this.vector3D_0 = value;
      }
    }

    public double InsertionRotation
    {
      get
      {
        return this.insertionRotation;
      }
      set
      {
        this.insertionRotation = value;
      }
    }

    public Vector3D InsertionScaleFactor
    {
      get
      {
        return this.insertionScaleFactor;
      }
      set
      {
        this.insertionScaleFactor = value;
      }
    }

    public override void TransformMe(TransformConfig config, Matrix4D matrix)
    {
      this.TransformMe(config, matrix, (CommandGroup) null);
    }

    public override void TransformMe(
      TransformConfig config,
      Matrix4D matrix,
      CommandGroup undoGroup)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfDimension.Class862 class862 = new DxfDimension.Class862();
      // ISSUE: reference to a compiler-generated field
      class862.dxfDimension_0 = this;
      Matrix4D transform = this.Transform;
      // ISSUE: reference to a compiler-generated field
      class862.point3D_0 = this.point3D_0;
      // ISSUE: reference to a compiler-generated field
      class862.point3D_1 = this.point3D_1;
      // ISSUE: reference to a compiler-generated field
      class862.double_0 = this.double_3;
      // ISSUE: reference to a compiler-generated field
      class862.double_1 = this.double_4;
      // ISSUE: reference to a compiler-generated field
      class862.vector3D_0 = this.vector3D_0;
      this.vector3D_0 = matrix.Transform(this.vector3D_0).GetUnit();
      Matrix4D inverse = DxfUtil.GetToWCSTransform(this.vector3D_0).GetInverse();
      // ISSUE: reference to a compiler-generated field
      Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(class862.vector3D_0);
      this.point3D_0 = (inverse * matrix * toWcsTransform).Transform(this.point3D_0);
      Matrix4D matrix4D = this.Transform.GetInverse() * matrix * transform;
      this.point3D_1 = matrix4D.Transform(this.point3D_1);
      Vector2D vector2D1 = matrix4D.Transform(new Vector2D(System.Math.Cos(this.double_3), System.Math.Sin(this.double_3)));
      this.double_3 = System.Math.Atan2(vector2D1.Y, vector2D1.X);
      Vector2D vector2D2 = matrix4D.Transform(new Vector2D(System.Math.Cos(this.double_4), System.Math.Sin(this.double_4)));
      this.double_4 = System.Math.Atan2(vector2D2.Y, vector2D2.X);
      if (undoGroup != null)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfDimension.Class863()
        {
          class862_0 = class862,
          point3D_0 = this.point3D_0,
          point3D_1 = this.point3D_1,
          double_0 = this.double_3,
          double_1 = this.double_4,
          vector3D_0 = this.vector3D_0
        }.method_0), new System.Action(class862.method_0)));
      }
      this.bool_5 = true;
    }

    protected void AfterTransformMe(CommandGroup undoGroup)
    {
      undoGroup?.UndoStack.Push((ICommand) new Command((object) this, (System.Action) (() => this.GenerateBlock()), Command.EmptyAction));
      this.GenerateBlock();
    }

    public void ChangeZAxis(Vector3D axis)
    {
      Matrix4D ocsToWcsTransform = this.GetOcsToWcsTransform();
      this.ZAxis = axis;
      this.UpdatePositions(this.GetWcsToOcsTransform() * ocsToWcsTransform);
    }

    public virtual void GenerateBlock()
    {
      if (this.Block == null)
      {
        DxfModel model = this.Model;
        if (model == null)
          throw new DxfException("Cannot generate dimension block, dimension is not part of a model.");
        this.Block = new DxfBlock();
        model.method_99(this.Block, (IList<DxfMessage>) null);
        this.Block.Flags = BlockFlags.Anonymous;
        model.AnonymousBlocks.Add(this.Block);
      }
      else
        this.Block.Entities.Clear();
    }

    public DxfDimensionStyleOverrides GetEffectiveDimensionStyle()
    {
      return this.GetEffectiveDimensionStyle(this.Model);
    }

    public string GetText(DxfDimensionStyleOverrides effectiveDimensionStyle)
    {
      if (this.string_0 == " ")
        return (string) null;
      string newValue1 = this.GetLinearMeasurementText(effectiveDimensionStyle);
      if (effectiveDimensionStyle.PostFix.Contains("<>"))
        newValue1 = effectiveDimensionStyle.PostFix.Replace("<>", newValue1);
      else if (!string.IsNullOrEmpty(effectiveDimensionStyle.PostFix))
        newValue1 += effectiveDimensionStyle.PostFix;
      if (effectiveDimensionStyle.AlternateUnitDimensioning)
      {
        string newValue2 = this.GetAlternateMeasurementText(effectiveDimensionStyle);
        if (effectiveDimensionStyle.AlternateDimensioningSuffix.Contains("[]"))
          newValue2 = effectiveDimensionStyle.AlternateDimensioningSuffix.Replace("[]", newValue2);
        else if (!string.IsNullOrEmpty(effectiveDimensionStyle.AlternateDimensioningSuffix))
          newValue2 += effectiveDimensionStyle.AlternateDimensioningSuffix;
        if (!effectiveDimensionStyle.PostFix.EndsWith("\\X"))
          newValue1 += " ";
        newValue1 = newValue1 + "[" + newValue2 + "]";
      }
      if (!string.IsNullOrEmpty(this.string_0))
        return this.string_0.Replace("<>", newValue1);
      return newValue1;
    }

    public virtual string GetLinearMeasurementText(
      DxfDimensionStyleOverrides effectiveDimensionStyle)
    {
      double measurement = this.GetMeasurement();
      return this.MeasurementPrefix + DxfDimension.GetLinearMeasurementText(effectiveDimensionStyle, measurement);
    }

    public static string GetLinearMeasurementText(
      DxfDimensionStyleOverrides dimensionStyle,
      double value)
    {
      return DxfDimension.GetLinearMeasurementText((IDimensionStyle) dimensionStyle, value, new char?());
    }

    public static string GetLinearMeasurementText(
      IDimensionStyle dimensionStyle,
      double value,
      char? thousandsSeparator)
    {
      string str = string.Empty;
      if (dimensionStyle.Rounding != 0.0)
        value = dimensionStyle.Rounding * System.Math.Round(value / dimensionStyle.Rounding);
      switch (dimensionStyle.LinearUnitFormat)
      {
        case LinearUnitFormat.Scientific:
          str = DxfDimension.smethod_2(dimensionStyle, false, value, thousandsSeparator);
          break;
        case LinearUnitFormat.Decimal:
        case LinearUnitFormat.WindowsDesktop:
          str = DxfDimension.smethod_3(dimensionStyle, false, value, thousandsSeparator);
          break;
        case LinearUnitFormat.Engineering:
          str = DxfDimension.smethod_4(dimensionStyle, false, value, thousandsSeparator);
          break;
        case LinearUnitFormat.Architectural:
          str = DxfDimension.smethod_5(dimensionStyle, false, dimensionStyle.FractionFormat, value);
          break;
        case LinearUnitFormat.Fractional:
          str = DxfDimension.smethod_6(dimensionStyle, false, dimensionStyle.FractionFormat, value);
          break;
      }
      return str;
    }

    public virtual string GetAlternateMeasurementText(
      DxfDimensionStyleOverrides effectiveDimensionStyle)
    {
      double alternateMeasurement = this.GetAlternateMeasurement();
      return this.MeasurementPrefix + DxfDimension.GetAlternateMeasurementText(effectiveDimensionStyle, alternateMeasurement);
    }

    public static string GetAlternateMeasurementText(
      DxfDimensionStyleOverrides dimensionStyle,
      double value)
    {
      return DxfDimension.GetAlternateMeasurementText((IDimensionStyle) dimensionStyle, value, new char?());
    }

    public static string GetAlternateMeasurementText(
      IDimensionStyle dimensionStyle,
      double value,
      char? thousandsSeparator)
    {
      string str = string.Empty;
      if (dimensionStyle.AlternateUnitRounding != 0.0)
        value = dimensionStyle.AlternateUnitRounding * System.Math.Round(value / dimensionStyle.AlternateUnitRounding);
      switch (dimensionStyle.AlternateUnitFormat)
      {
        case AlternateUnitFormat.Scientific:
          str = DxfDimension.smethod_2(dimensionStyle, true, value, thousandsSeparator);
          break;
        case AlternateUnitFormat.Decimal:
        case AlternateUnitFormat.WindowsDesktop:
          str = DxfDimension.smethod_3(dimensionStyle, true, value, thousandsSeparator);
          break;
        case AlternateUnitFormat.Engineering:
          str = DxfDimension.smethod_4(dimensionStyle, true, value, thousandsSeparator);
          break;
        case AlternateUnitFormat.ArchitecturalStacked:
          str = DxfDimension.smethod_5(dimensionStyle, true, FractionFormat.HorizontalStacking, value);
          break;
        case AlternateUnitFormat.FractionalStacked:
          str = DxfDimension.smethod_6(dimensionStyle, true, FractionFormat.HorizontalStacking, value);
          break;
        case AlternateUnitFormat.Architectural:
          str = DxfDimension.smethod_5(dimensionStyle, true, FractionFormat.NotStacked, value);
          break;
        case AlternateUnitFormat.Fractional:
          str = DxfDimension.smethod_6(dimensionStyle, true, FractionFormat.NotStacked, value);
          break;
      }
      return str;
    }

    private static string smethod_2(
      IDimensionStyle dimensionStyle,
      bool alternate,
      double value,
      char? thousandsSeparator)
    {
      StringBuilder numberFormatSb = new StringBuilder();
      DxfDimension.smethod_7(dimensionStyle, alternate, numberFormatSb);
      NumberFormatInfo ni = new NumberFormatInfo();
      DxfDimension.smethod_8(dimensionStyle, alternate, thousandsSeparator, ni);
      value = System.Math.Round(value, ni.NumberDecimalDigits);
      numberFormatSb.Append("E+00");
      return value.ToString(numberFormatSb.ToString(), (IFormatProvider) ni);
    }

    private static string smethod_3(
      IDimensionStyle dimensionStyle,
      bool alternate,
      double value,
      char? thousandsSeparator)
    {
      StringBuilder numberFormatSb = new StringBuilder();
      if (thousandsSeparator.HasValue)
      {
        numberFormatSb.Append("#");
        numberFormatSb.Append(thousandsSeparator.Value);
      }
      numberFormatSb.Append("##");
      DxfDimension.smethod_7(dimensionStyle, alternate, numberFormatSb);
      NumberFormatInfo ni = new NumberFormatInfo();
      DxfDimension.smethod_8(dimensionStyle, alternate, thousandsSeparator, ni);
      value = System.Math.Round(value, ni.NumberDecimalDigits);
      return value.ToString(numberFormatSb.ToString(), (IFormatProvider) ni);
    }

    private static string smethod_4(
      IDimensionStyle dimensionStyle,
      bool alternate,
      double value,
      char? thousandsSeparator)
    {
      string str = string.Empty;
      double num1 = value * (1.0 / 12.0);
      int num2 = (int) num1;
      double num3 = (num1 - (double) num2) * 12.0;
      NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
      numberFormatInfo.NumberDecimalSeparator = dimensionStyle.DecimalSeparator.ToString();
      numberFormatInfo.NumberDecimalDigits = alternate ? (int) dimensionStyle.AlternateUnitDecimalPlaces : (int) dimensionStyle.DecimalPlaces;
      if (thousandsSeparator.HasValue)
        numberFormatInfo.NumberGroupSeparator = thousandsSeparator.ToString();
      double num4 = System.Math.Round(num3, numberFormatInfo.NumberDecimalDigits);
      if (num4 == 12.0)
      {
        num4 = 0.0;
        ++num2;
      }
      ZeroHandling zeroHandling = alternate ? dimensionStyle.AlternateUnitZeroHandling : dimensionStyle.ZeroHandling;
      bool flag = num4 != 0.0 || zeroHandling == ZeroHandling.ShowZeroFeetAndInches || zeroHandling == ZeroHandling.SuppressZeroFeetShowZeroInches;
      if (num2 != 0 || zeroHandling == ZeroHandling.ShowZeroFeetAndInches || zeroHandling == ZeroHandling.ShowZeroFeetSuppressZeroInches)
      {
        str = num2.ToString((IFormatProvider) CultureInfo.InvariantCulture) + "'";
        if (flag)
          str += "-";
      }
      if (flag)
      {
        StringBuilder numberFormatSb = new StringBuilder();
        DxfDimension.smethod_7(dimensionStyle, alternate, numberFormatSb);
        str = str + num4.ToString(numberFormatSb.ToString(), (IFormatProvider) numberFormatInfo) + "\"";
      }
      return str;
    }

    private static string smethod_5(
      IDimensionStyle dimensionStyle,
      bool alternate,
      FractionFormat fractionFormat,
      double value)
    {
      string str = string.Empty;
      double num1 = value * (1.0 / 12.0);
      int num2 = (int) num1;
      double num3 = (num1 - (double) num2) * 12.0;
      int num4 = (int) num3;
      double num5 = num3 - (double) num4;
      int num6 = 2 << (alternate ? (int) dimensionStyle.AlternateUnitDecimalPlaces : (int) dimensionStyle.DecimalPlaces) - 1;
      int num7;
      for (num7 = (int) System.Math.Round(num5 * (double) num6); num7 % 2 == 0 && num6 > 1; num7 >>= 1)
        num6 >>= 1;
      if (num7 == num6)
      {
        num7 = 0;
        ++num4;
        if ((double) num4 == 12.0)
        {
          num4 = 0;
          ++num2;
        }
      }
      ZeroHandling zeroHandling = alternate ? dimensionStyle.AlternateUnitZeroHandling : dimensionStyle.ZeroHandling;
      bool flag = num4 != 0 || num7 != 0 || zeroHandling == ZeroHandling.ShowZeroFeetAndInches || zeroHandling == ZeroHandling.SuppressZeroFeetShowZeroInches;
      if (num2 != 0 || zeroHandling == ZeroHandling.ShowZeroFeetAndInches || zeroHandling == ZeroHandling.ShowZeroFeetSuppressZeroInches)
      {
        str = num2.ToString((IFormatProvider) CultureInfo.InvariantCulture) + "'";
        if (flag)
          str += "-";
      }
      if (flag)
      {
        string text = str + num4.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        if (num7 != 0)
          text = DxfDimension.smethod_20(text, num7.ToString((IFormatProvider) CultureInfo.InvariantCulture), num6.ToString((IFormatProvider) CultureInfo.InvariantCulture), fractionFormat);
        str = text + "\"";
      }
      return str;
    }

    private static string smethod_6(
      IDimensionStyle dimensionStyle,
      bool alternate,
      FractionFormat fractionFormat,
      double value)
    {
      string text = string.Empty;
      int num1 = (int) value;
      double num2 = value - (double) num1;
      int num3 = 2 << (alternate ? (int) dimensionStyle.AlternateUnitDecimalPlaces : (int) dimensionStyle.DecimalPlaces) - 1;
      int num4;
      for (num4 = (int) System.Math.Round(num2 * (double) num3); num4 % 2 == 0 && num3 > 1; num4 >>= 1)
        num3 >>= 1;
      bool flag = num4 != 0;
      if (num1 != 0)
        text = num1.ToString();
      if (flag)
        text = DxfDimension.smethod_20(text, num4.ToString((IFormatProvider) CultureInfo.InvariantCulture), num3.ToString((IFormatProvider) CultureInfo.InvariantCulture), fractionFormat);
      return text;
    }

    private static void smethod_7(
      IDimensionStyle dimensionStyle,
      bool alternate,
      StringBuilder numberFormatSb)
    {
      ZeroHandling zeroHandling = alternate ? dimensionStyle.AlternateUnitZeroHandling : dimensionStyle.ZeroHandling;
      short num = alternate ? dimensionStyle.AlternateUnitDecimalPlaces : dimensionStyle.DecimalPlaces;
      if (zeroHandling != ZeroHandling.SuppressDecimalLeadingZeroes && zeroHandling != ZeroHandling.SuppressDecimalLeadingAndTrailingZeroes)
        numberFormatSb.Append("0.");
      else
        numberFormatSb.Append("#.");
      if (zeroHandling != ZeroHandling.SuppressDecimalTrailingZeroes && zeroHandling != ZeroHandling.SuppressDecimalLeadingAndTrailingZeroes)
      {
        for (int index = 0; index < (int) num; ++index)
          numberFormatSb.Append("0");
      }
      else
      {
        for (int index = 0; index < (int) num; ++index)
          numberFormatSb.Append("#");
      }
    }

    private static void smethod_8(
      IDimensionStyle dimensionStyle,
      bool alternate,
      char? thousandsSeparator,
      NumberFormatInfo ni)
    {
      short num = alternate ? dimensionStyle.AlternateUnitDecimalPlaces : dimensionStyle.DecimalPlaces;
      ni.NumberDecimalSeparator = dimensionStyle.DecimalSeparator.ToString();
      ni.NumberDecimalDigits = (int) num;
      if (!thousandsSeparator.HasValue)
        return;
      ni.NumberGroupSeparator = thousandsSeparator.ToString();
    }

    public double GetMeasurement()
    {
      if (this.double_2 != 0.0)
        return this.double_2;
      return this.GetActualMeasurement();
    }

    public double GetAlternateMeasurement()
    {
      if (this.double_2 != 0.0)
        return this.double_2;
      return this.GetActualAlternateMeasurement();
    }

    public abstract double GetActualMeasurement();

    public double GetLinearScaleFactor(DxfDimensionStyleOverrides effectiveDimensionStyle)
    {
      if (effectiveDimensionStyle.LinearScaleFactor >= 0.0)
        return effectiveDimensionStyle.LinearScaleFactor;
      if (this.PaperSpace)
        return -effectiveDimensionStyle.LinearScaleFactor;
      return 1.0;
    }

    public abstract double GetActualAlternateMeasurement();

    public double GetAlternateScaleFactor(DxfDimensionStyleOverrides effectiveDimensionStyle)
    {
      if (effectiveDimensionStyle.AlternateUnitScaleFactor >= 0.0)
        return effectiveDimensionStyle.AlternateUnitScaleFactor;
      if (this.PaperSpace)
        return -effectiveDimensionStyle.AlternateUnitScaleFactor;
      return 1.0;
    }

    public WW.Math.Point3D TransformFromOcs(WW.Math.Point3D point)
    {
      if (!(this.vector3D_0 == Vector3D.ZAxis))
        return DxfUtil.GetToWCSTransform(this.vector3D_0).Transform(point);
      return point;
    }

    public WW.Math.Point3D TransformToOcs(WW.Math.Point3D point)
    {
      if (!(this.vector3D_0 == Vector3D.ZAxis))
        return DxfUtil.GetToWCSTransform(this.vector3D_0).GetTranspose().Transform(point);
      return point;
    }

    public Matrix4D GetOcsToWcsTransform()
    {
      return DxfUtil.GetToWCSTransform(this.vector3D_0);
    }

    public Matrix4D GetWcsToOcsTransform()
    {
      return DxfUtil.GetToWCSTransform(this.vector3D_0).GetTranspose();
    }

    public override DxfEntity.Interactor CreateCreateInteractor(Transaction transaction)
    {
      return (DxfEntity.Interactor) new DxfEntity.DefaultCreateInteractor((DxfEntity) this, (ITransaction) transaction);
    }

    public override DxfEntity.Interactor CreateEditInteractor()
    {
      return (DxfEntity.Interactor) new DxfEntity.DefaultEditInteractor((DxfEntity) this);
    }

    public override string EntityType
    {
      get
      {
        return "DIMENSION";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbDimension";
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      this.method_20();
      DxfBlock block = this.Block;
      if (block != null)
      {
        DxfInsert.Interface46 nterface46 = (DxfInsert.Interface46) new DxfInsert.Class1019((DxfEntity) this, context, graphicsFactory);
        nterface46.imethod_0(0, 0, this.Transform);
        nterface46.Draw(block, false);
      }
      if (!context.Config.ShowDimensionDefinitionPoints)
        return;
      IClippingTransformer clippingTransformer = (IClippingTransformer) context.GetTransformer().Clone();
      clippingTransformer.SetPreTransform(DxfUtil.GetToWCSTransform(this.vector3D_0));
      this.DrawDebugCross(context, graphicsFactory, clippingTransformer.Transform(this.point3D_0), ArgbColors.Green, 2.0);
      this.DrawDebugCross(context, graphicsFactory, clippingTransformer.Transform(this.point3D_1), ArgbColors.Red);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      this.method_20();
      DxfBlock block = this.Block;
      if (block != null)
      {
        DxfInsert.Interface46 nterface46 = (DxfInsert.Interface46) new DxfInsert.Class1020((DxfEntity) this, context, graphicsFactory);
        nterface46.imethod_0(0, 0, this.Transform);
        nterface46.Draw(block, false);
      }
      if (!context.Config.ShowDimensionDefinitionPoints)
        return;
      IClippingTransformer clippingTransformer = (IClippingTransformer) context.GetTransformer().Clone();
      clippingTransformer.SetPreTransform(DxfUtil.GetToWCSTransform(this.vector3D_0));
      this.DrawDebugCross(context, graphicsFactory, clippingTransformer.Transform(this.point3D_0), ArgbColors.Green, 2.0);
      this.DrawDebugCross(context, graphicsFactory, clippingTransformer.Transform(this.point3D_1), ArgbColors.Red);
    }

    protected internal void DrawDebugCross(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory,
      Vector4D position,
      ArgbColor color)
    {
      this.DrawDebugCross(context, graphicsFactory, position, color, 1.0);
    }

    protected internal void DrawDebugCross(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory,
      Vector4D? position,
      ArgbColor color)
    {
      if (!position.HasValue)
        return;
      this.DrawDebugCross(context, graphicsFactory, position.Value, color, 1.0);
    }

    protected internal void DrawDebugCross(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory,
      Vector4D position,
      ArgbColor color,
      double size)
    {
      graphicsFactory.CreateLine((DxfEntity) this, context, color, false, position - Vector4D.XAxis * size * 0.5, position - Vector4D.XAxis * size / 4.0);
      graphicsFactory.CreateLine((DxfEntity) this, context, color, false, position + Vector4D.XAxis * size * 0.5, position + Vector4D.XAxis * size / 4.0);
      graphicsFactory.CreateLine((DxfEntity) this, context, color, false, position - Vector4D.YAxis * size * 0.5, position - Vector4D.YAxis * size / 4.0);
      graphicsFactory.CreateLine((DxfEntity) this, context, color, false, position + Vector4D.YAxis * size * 0.5, position + Vector4D.YAxis * size / 4.0);
    }

    protected internal void DrawDebugCross(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory,
      Vector4D? position,
      ArgbColor color,
      double size)
    {
      if (!position.HasValue)
        return;
      this.DrawDebugCross(context, graphicsFactory, position.Value, color, size);
    }

    protected internal void DrawDebugCross(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory,
      Vector4D position,
      ArgbColor color)
    {
      this.DrawDebugCross(context, graphicsFactory, position, color, 1.0);
    }

    protected internal void DrawDebugCross(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory,
      Vector4D? position,
      ArgbColor color)
    {
      if (!position.HasValue)
        return;
      this.DrawDebugCross(context, graphicsFactory, position.Value, color, 1.0);
    }

    protected internal void DrawDebugCross(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory,
      Vector4D position,
      ArgbColor color,
      double size)
    {
      graphicsFactory.BeginGeometry((DxfEntity) this, context, color, false, false, true, true);
      graphicsFactory.CreateLine((DxfEntity) this, position - Vector4D.XAxis * size * 0.5, position - Vector4D.XAxis * size / 4.0);
      graphicsFactory.CreateLine((DxfEntity) this, position + Vector4D.XAxis * size * 0.5, position + Vector4D.XAxis * size / 4.0);
      graphicsFactory.CreateLine((DxfEntity) this, position - Vector4D.YAxis * size * 0.5, position - Vector4D.YAxis * size / 4.0);
      graphicsFactory.CreateLine((DxfEntity) this, position + Vector4D.YAxis * size * 0.5, position + Vector4D.YAxis * size / 4.0);
      graphicsFactory.EndGeometry();
    }

    private void method_13(DxfBlock block, EntityColor color, WW.Math.Point3D p)
    {
      double num = 0.05;
      Vector3D vector3D1 = new Vector3D(num, num, 0.0);
      block.Entities.Add((DxfEntity) new DxfLine(color, p - vector3D1, p + vector3D1));
      Vector3D vector3D2 = new Vector3D(-0.05, num, 0.0);
      block.Entities.Add((DxfEntity) new DxfLine(color, p - vector3D2, p + vector3D2));
    }

    protected internal void DrawDebugCross(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory,
      Vector4D? position,
      ArgbColor color,
      double size)
    {
      if (!position.HasValue)
        return;
      this.DrawDebugCross(context, graphicsFactory, position.Value, color, size);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      this.method_20();
      if (this.Block != null)
      {
        DxfInsert.Interface46 nterface46 = (DxfInsert.Interface46) new DxfInsert.Class1021((DxfEntity) this, context, graphicsFactory);
        nterface46.imethod_0(0, 0, this.Transform);
        nterface46.Draw(this.Block, false);
      }
      if (!context.Config.ShowDimensionDefinitionPoints)
        return;
      IClippingTransformer clippingTransformer = (IClippingTransformer) context.GetTransformer().Clone();
      clippingTransformer.SetPreTransform(DxfUtil.GetToWCSTransform(this.vector3D_0));
      this.DrawDebugCross(context, graphicsFactory, clippingTransformer.Transform(this.point3D_0), ArgbColors.Green, 2.0);
      this.DrawDebugCross(context, graphicsFactory, clippingTransformer.Transform(this.point3D_1), ArgbColors.Red);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      this.method_20();
      if (this.Block == null)
        return;
      DrawContext.Surface childContext = context.CreateChildContext((DxfEntity) this, Matrix4D.Identity);
      GraphicElementInsert graphicElement;
      if (!graphics.GetGraphicElementInsert(parentGraphicElementBlock, (DxfEntity) this, childContext.Layer, childContext.ByBlockColor, childContext.ByBlockLineType, out graphicElement))
        return;
      DxfInsert.Interface46 nterface46 = (DxfInsert.Interface46) new DxfInsert.Class1022((DxfEntity) this, context, graphics, parentGraphicElementBlock, graphicElement);
      nterface46.imethod_0(0, 0, this.Transform);
      nterface46.Draw(this.Block, false);
    }

    protected internal void DrawDebugCross(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      Vector4D position,
      ArgbColor color)
    {
      this.DrawDebugCross(context, graphicsFactory, position, color, 1.0);
    }

    protected internal void DrawDebugCross(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      Vector4D? position,
      ArgbColor color)
    {
      if (!position.HasValue)
        return;
      this.DrawDebugCross(context, graphicsFactory, position.Value, color, 1.0);
    }

    protected internal void DrawDebugCross(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      Vector4D position,
      ArgbColor color,
      double size)
    {
      graphicsFactory.SetColor(color);
      graphicsFactory.CreateSegment(position - Vector4D.XAxis * size * 0.5, position - Vector4D.XAxis * size / 4.0);
      graphicsFactory.CreateSegment(position + Vector4D.XAxis * size * 0.5, position + Vector4D.XAxis * size / 4.0);
      graphicsFactory.CreateSegment(position - Vector4D.YAxis * size * 0.5, position - Vector4D.YAxis * size / 4.0);
      graphicsFactory.CreateSegment(position + Vector4D.YAxis * size * 0.5, position + Vector4D.YAxis * size / 4.0);
    }

    protected internal void DrawDebugCross(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      Vector4D? position,
      ArgbColor color,
      double size)
    {
      if (!position.HasValue)
        return;
      this.DrawDebugCross(context, graphicsFactory, position.Value, color, size);
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfDimension dxfDimension = (DxfDimension) from;
      this.byte_0 = dxfDimension.byte_0;
      this.Block = Class906.smethod_0(cloneContext, dxfDimension.Block, true);
      this.point3D_0 = dxfDimension.point3D_0;
      this.point3D_1 = dxfDimension.point3D_1;
      this.bool_2 = dxfDimension.bool_2;
      this.attachmentPoint_0 = dxfDimension.attachmentPoint_0;
      this.lineSpacingStyle_0 = dxfDimension.lineSpacingStyle_0;
      this.double_1 = dxfDimension.double_1;
      this.double_2 = dxfDimension.double_2;
      this.string_0 = dxfDimension.string_0;
      this.bool_3 = dxfDimension.bool_3;
      this.double_3 = dxfDimension.double_3;
      this.bool_4 = dxfDimension.bool_4;
      this.double_4 = dxfDimension.double_4;
      if (dxfDimension.dxfDimensionStyleOverrides_0 != null)
        this.dxfDimensionStyleOverrides_0 = dxfDimension.dxfDimensionStyleOverrides_0.Clone(cloneContext);
      this.vector3D_0 = dxfDimension.vector3D_0;
      this.insertionScaleFactor = dxfDimension.insertionScaleFactor;
      this.insertionRotation = dxfDimension.insertionRotation;
    }

    internal override void vmethod_10(DxfModel model)
    {
      base.vmethod_10(model);
      DxfAnnotationScaleObjectContextData.smethod_8((DxfEntity) this);
      this.bool_6 = Class1064.smethod_0((DxfHandledObject) this, model);
    }

    internal override void Repair(DxfModelRepairer repairer)
    {
      base.Repair(repairer);
      if (this.DimensionStyle != null)
        return;
      this.DimensionStyle = repairer.Model.CurrentDimensionStyle;
    }

    internal byte Version
    {
      get
      {
        return this.byte_0;
      }
      set
      {
        this.byte_0 = value;
      }
    }

    internal static void smethod_9(
      DxfMText textEntity,
      AttachmentPoint attachmentPoint,
      DimensionTextHorizontalAlignment textHorizontalAlignment,
      DimensionTextVerticalAlignment textVerticalAlignment,
      bool outsideAboveDimensionLine)
    {
      int num = (int) (attachmentPoint - (short) 1) / 3 * 3;
      switch (textHorizontalAlignment)
      {
        case DimensionTextHorizontalAlignment.Centered:
          textEntity.AttachmentPoint = (AttachmentPoint) (2 + num);
          break;
        case DimensionTextHorizontalAlignment.Left:
          textEntity.AttachmentPoint = (AttachmentPoint) (1 + num);
          break;
        case DimensionTextHorizontalAlignment.Right:
          textEntity.AttachmentPoint = (AttachmentPoint) (3 + num);
          break;
        case DimensionTextHorizontalAlignment.LeftCentered:
          textEntity.AttachmentPoint = AttachmentPoint.MiddleLeft;
          break;
        case DimensionTextHorizontalAlignment.RightCentered:
          textEntity.AttachmentPoint = AttachmentPoint.MiddleRight;
          break;
      }
    }

    internal static void smethod_10(
      DxfText textEntity,
      DimensionTextHorizontalAlignment textHorizontalAlignment,
      DimensionTextVerticalAlignment textVerticalAlignment)
    {
      switch (textVerticalAlignment)
      {
        case DimensionTextVerticalAlignment.Centered:
          textEntity.VerticalAlignment = TextVerticalAlignment.Middle;
          break;
        case DimensionTextVerticalAlignment.Above:
          textEntity.VerticalAlignment = TextVerticalAlignment.Bottom;
          break;
        case DimensionTextVerticalAlignment.Outside:
          textEntity.VerticalAlignment = TextVerticalAlignment.Middle;
          break;
        case DimensionTextVerticalAlignment.ConformJapaneseIndustrialStandards:
          textEntity.VerticalAlignment = TextVerticalAlignment.Middle;
          break;
        case DimensionTextVerticalAlignment.Below:
          textEntity.VerticalAlignment = TextVerticalAlignment.Top;
          break;
      }
      switch (textHorizontalAlignment)
      {
        case DimensionTextHorizontalAlignment.Centered:
          textEntity.HorizontalAlignment = TextHorizontalAlignment.Center;
          textEntity.VerticalAlignment = TextVerticalAlignment.Middle;
          break;
        case DimensionTextHorizontalAlignment.Left:
          textEntity.HorizontalAlignment = TextHorizontalAlignment.Left;
          textEntity.VerticalAlignment = TextVerticalAlignment.Top;
          break;
        case DimensionTextHorizontalAlignment.Right:
          textEntity.HorizontalAlignment = TextHorizontalAlignment.Right;
          textEntity.VerticalAlignment = TextVerticalAlignment.Top;
          break;
        case DimensionTextHorizontalAlignment.LeftCentered:
          textEntity.HorizontalAlignment = TextHorizontalAlignment.Left;
          textEntity.VerticalAlignment = TextVerticalAlignment.Middle;
          break;
        case DimensionTextHorizontalAlignment.RightCentered:
          textEntity.HorizontalAlignment = TextHorizontalAlignment.Right;
          textEntity.VerticalAlignment = TextVerticalAlignment.Middle;
          break;
      }
    }

    internal void method_14(double textRotation)
    {
      this.double_3 = textRotation;
    }

    internal static DxfMText smethod_11(
      DxfModel model,
      string textString,
      WW.Math.Point3D position,
      Vector3D direction,
      AttachmentPoint attachmentPoint,
      DxfDimensionStyleOverrides effectiveDimStyle)
    {
      DxfMText textEntity = DxfDimension.smethod_12(textString, position, effectiveDimStyle);
      DxfDimension.smethod_9(textEntity, attachmentPoint, effectiveDimStyle.TextHorizontalAlignment, effectiveDimStyle.TextVerticalAlignment, true);
      if (!effectiveDimStyle.TextInsideHorizontal)
        textEntity.XAxis = direction;
      return textEntity;
    }

    private static DxfMText smethod_12(
      string textString,
      WW.Math.Point3D position,
      DxfDimensionStyleOverrides effectiveDimStyle)
    {
      DxfMText dxfMtext = new DxfMText(textString, position, DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimStyle));
      dxfMtext.Color = EntityColor.CreateFrom(effectiveDimStyle.TextColor);
      if (effectiveDimStyle.TextStyle != null)
        dxfMtext.Style = effectiveDimStyle.TextStyle;
      if ((effectiveDimStyle.TextBackgroundFillMode & DimensionTextBackgroundFillMode.DimensionTextBackgroundColor) != DimensionTextBackgroundFillMode.NoBackground)
      {
        dxfMtext.BackgroundFillFlags = BackgroundFillFlags.UseBackgroundFillColor;
        dxfMtext.BackgroundFillInfo = new BackgroundFillInfo();
        dxfMtext.BackgroundFillInfo.Color = effectiveDimStyle.TextBackgroundColor;
      }
      return dxfMtext;
    }

    internal static void smethod_13(
      DxfModel model,
      DxfBlock block,
      WW.Math.Point3D leaderEndPoint,
      Vector3D dimensionLineDirection,
      double leaderLength,
      DxfDimensionStyleOverrides effectiveDimStyle,
      double textDx,
      bool textLeft,
      bool arrowsFitInsideExtensionLines,
      bool dontDrawLeaderSecondSegment,
      out WW.Math.Point3D leaderLine2StartPoint)
    {
      double arrowSize = DxfDimension.GetArrowSize(effectiveDimStyle);
      WW.Math.Point3D start = leaderEndPoint;
      if (!arrowsFitInsideExtensionLines)
        start += dimensionLineDirection * arrowSize;
      leaderLine2StartPoint = start + dimensionLineDirection * leaderLength;
      if (block == null)
        return;
      DxfLine line1 = new DxfLine(EntityColor.CreateFrom(effectiveDimStyle.DimensionLineColor), start, leaderLine2StartPoint);
      DxfDimension.smethod_14(line1, effectiveDimStyle);
      block.Entities.Add((DxfEntity) line1);
      if (!effectiveDimStyle.TextOutsideHorizontal || dontDrawLeaderSecondSegment)
        return;
      double num = arrowSize + (effectiveDimStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Above ? textDx : 0.0);
      WW.Math.Point3D end = leaderLine2StartPoint + Vector3D.XAxis * num * (textLeft ? -1.0 : 1.0);
      DxfLine line2 = new DxfLine(EntityColor.CreateFrom(effectiveDimStyle.DimensionLineColor), leaderLine2StartPoint, end);
      DxfDimension.smethod_14(line2, effectiveDimStyle);
      block.Entities.Add((DxfEntity) line2);
    }

    private static void smethod_14(DxfLine line, DxfDimensionStyleOverrides effectiveDimStyle)
    {
      line.LineWeight = effectiveDimStyle.DimensionLineWeight;
      line.LineType = effectiveDimStyle.DimensionLineLineType;
    }

    internal static double GetArrowSize(DxfDimensionStyleOverrides effectiveDimensionStyle)
    {
      if (effectiveDimensionStyle.ArrowSize > 0.0 && effectiveDimensionStyle.TickSize == 0.0)
        return effectiveDimensionStyle.ScaleFactor * effectiveDimensionStyle.ArrowSize;
      return 0.0;
    }

    internal static double smethod_15(DxfDimensionStyleOverrides effectiveDimensionStyle)
    {
      return effectiveDimensionStyle.ScaleFactor * effectiveDimensionStyle.DimensionLineGap;
    }

    internal static DxfEntity smethod_16(
      bool? arrow1,
      WW.Math.Point3D arrowEndPoint,
      Vector3D arrowDirection,
      Vector3D arrowNormal,
      DxfDimensionStyleOverrides effectiveDimensionStyle,
      out double arrowSize)
    {
      DxfBlock block = (DxfBlock) null;
      if (arrow1.HasValue)
      {
        if (arrow1.Value && effectiveDimensionStyle.FirstArrowBlock != null)
          block = effectiveDimensionStyle.FirstArrowBlock;
        else if (!arrow1.Value && effectiveDimensionStyle.SecondArrowBlock != null)
          block = effectiveDimensionStyle.SecondArrowBlock;
      }
      if (block == null && effectiveDimensionStyle.ArrowBlock != null)
        block = effectiveDimensionStyle.ArrowBlock;
      if (block != null)
      {
        DxfInsert dxfInsert = new DxfInsert(block, arrowEndPoint);
        dxfInsert.Rotation = System.Math.Atan2(arrowDirection.Y, arrowDirection.X);
        dxfInsert.Color = EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor);
        arrowSize = effectiveDimensionStyle.ScaleFactor * effectiveDimensionStyle.ArrowSize;
        double num = arrowSize;
        dxfInsert.ScaleFactor = new Vector3D(num, num, num);
        return (DxfEntity) dxfInsert;
      }
      if (effectiveDimensionStyle.ArrowSize > 0.0 && effectiveDimensionStyle.TickSize == 0.0)
      {
        DxfSolid dxfSolid = new DxfSolid();
        arrowSize = effectiveDimensionStyle.ScaleFactor * effectiveDimensionStyle.ArrowSize;
        double num = arrowSize / 6.0;
        dxfSolid.Points.Add(arrowEndPoint);
        dxfSolid.Points.Add(arrowEndPoint - arrowSize * arrowDirection - num * arrowNormal);
        WW.Math.Point3D point3D = arrowEndPoint - arrowSize * arrowDirection + num * arrowNormal;
        dxfSolid.Points.Add(point3D);
        dxfSolid.Points.Add(point3D);
        dxfSolid.Color = EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor);
        return (DxfEntity) dxfSolid;
      }
      if (effectiveDimensionStyle.TickSize != 0.0)
      {
        arrowSize = -effectiveDimensionStyle.DimensionLineExtension * effectiveDimensionStyle.ScaleFactor;
        double num = 1.4142135623731 * effectiveDimensionStyle.TickSize * effectiveDimensionStyle.ScaleFactor;
        Vector3D unit = (arrowDirection + arrowNormal).GetUnit();
        DxfLine line = new DxfLine(EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor), arrowEndPoint - unit * num, arrowEndPoint + unit * num);
        DxfDimension.smethod_14(line, effectiveDimensionStyle);
        return (DxfEntity) line;
      }
      arrowSize = 0.0;
      return (DxfEntity) null;
    }

    internal static void smethod_17(
      DxfBlock block,
      WW.Math.Point3D dimensionLineStart,
      WW.Math.Point3D dimensionLineEnd,
      double dimensionLineExtensionOverrideStart,
      double dimensionLineExtensionOverrideEnd,
      Vector3D dimensionLineDirection,
      Vector3D dimensionLineNormal,
      DxfDimensionStyleOverrides effectiveDimStyle,
      bool drawDimensionLineInsideExtensionLines,
      bool drawArrowsInsideExtensionLines,
      DxfDimension.Class861 texts,
      bool leaderCreated)
    {
      double arrowSize = 0.0;
      if (!drawDimensionLineInsideExtensionLines)
        drawArrowsInsideExtensionLines = false;
      Vector3D arrowDirection1 = drawArrowsInsideExtensionLines ? -dimensionLineDirection : dimensionLineDirection;
      if (!effectiveDimStyle.SuppressFirstDimensionLine)
      {
        DxfEntity dxfEntity = DxfDimension.smethod_16(new bool?(true), dimensionLineStart, arrowDirection1, -dimensionLineNormal, effectiveDimStyle, out arrowSize);
        block.Entities.Add(dxfEntity);
      }
      Vector3D arrowDirection2 = drawArrowsInsideExtensionLines ? dimensionLineDirection : -dimensionLineDirection;
      if (!effectiveDimStyle.SuppressSecondDimensionLine)
      {
        DxfEntity dxfEntity = DxfDimension.smethod_16(new bool?(false), dimensionLineEnd, arrowDirection2, dimensionLineNormal, effectiveDimStyle, out arrowSize);
        block.Entities.Add(dxfEntity);
      }
      double num1 = System.Math.Max(arrowSize, 0.0);
      if (drawDimensionLineInsideExtensionLines)
      {
        double num2 = -num1;
        if (!drawArrowsInsideExtensionLines)
          num2 = 2.0 * num1;
        if (effectiveDimStyle.DimensionLineExtension != 0.0 || effectiveDimStyle.TickSize != 0.0)
          num2 = effectiveDimStyle.DimensionLineExtension * effectiveDimStyle.ScaleFactor;
        Vector3D vector3D = num2 * dimensionLineDirection;
        WW.Math.Point3D point3D1 = dimensionLineStart + (dimensionLineExtensionOverrideStart == 0.0 ? -vector3D : dimensionLineExtensionOverrideStart * dimensionLineDirection);
        WW.Math.Point3D point3D2 = dimensionLineEnd + (dimensionLineExtensionOverrideEnd == 0.0 ? vector3D : dimensionLineExtensionOverrideEnd * dimensionLineDirection);
        double num3 = System.Math.Abs(DxfDimension.smethod_15(effectiveDimStyle));
        if (!effectiveDimStyle.SuppressFirstDimensionLine && !effectiveDimStyle.SuppressSecondDimensionLine)
        {
          if (!texts.method_0() && effectiveDimStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Centered)
          {
            foreach (DxfLine dxfLine in DxfDimension.smethod_18(effectiveDimStyle, point3D1, point3D2, texts.Bounds.Origin, texts.Bounds.Dx, texts.Bounds.Dy))
              block.Entities.Add((DxfEntity) dxfLine);
          }
          else
          {
            DxfLine line = new DxfLine(EntityColor.CreateFrom(effectiveDimStyle.DimensionLineColor), point3D1, point3D2);
            DxfDimension.smethod_14(line, effectiveDimStyle);
            block.Entities.Add((DxfEntity) line);
          }
        }
        else
        {
          if (!effectiveDimStyle.SuppressFirstDimensionLine)
          {
            bool flag = true;
            WW.Math.Point3D end;
            if (effectiveDimStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Above)
            {
              double num4 = texts.Bounds.method_0(point3D1, dimensionLineDirection) + num3;
              if (num4 <= 0.0)
                flag = false;
              end = point3D1 + num4 * dimensionLineDirection;
            }
            else
            {
              double num4 = texts.Bounds.method_0(point3D1, -dimensionLineDirection) + num3;
              if (num4 >= 0.0)
                flag = false;
              end = point3D1 - num4 * dimensionLineDirection;
            }
            if (flag)
            {
              DxfLine line = new DxfLine(EntityColor.CreateFrom(effectiveDimStyle.DimensionLineColor), point3D1, end);
              DxfDimension.smethod_14(line, effectiveDimStyle);
              block.Entities.Add((DxfEntity) line);
            }
          }
          if (effectiveDimStyle.SuppressSecondDimensionLine)
            return;
          bool flag1 = true;
          WW.Math.Point3D start;
          if (effectiveDimStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Above)
          {
            double num4 = texts.Bounds.method_0(point3D1, -dimensionLineDirection) + num3;
            if (num4 >= 0.0)
              flag1 = false;
            start = point3D1 - num4 * dimensionLineDirection;
          }
          else
          {
            double num4 = texts.Bounds.method_0(point3D1, dimensionLineDirection) + num3;
            if (num4 <= 0.0)
              flag1 = false;
            start = point3D1 + num4 * dimensionLineDirection;
          }
          if (!flag1)
            return;
          DxfLine line1 = new DxfLine(EntityColor.CreateFrom(effectiveDimStyle.DimensionLineColor), start, point3D2);
          DxfDimension.smethod_14(line1, effectiveDimStyle);
          block.Entities.Add((DxfEntity) line1);
        }
      }
      else
      {
        if (!leaderCreated)
        {
          DxfLine line = new DxfLine(EntityColor.CreateFrom(effectiveDimStyle.DimensionLineColor), dimensionLineStart - arrowSize * dimensionLineDirection, dimensionLineStart - 2.0 * arrowSize * dimensionLineDirection);
          DxfDimension.smethod_14(line, effectiveDimStyle);
          block.Entities.Add((DxfEntity) line);
        }
        DxfLine line1 = new DxfLine(EntityColor.CreateFrom(effectiveDimStyle.DimensionLineColor), dimensionLineEnd + arrowSize * dimensionLineDirection, dimensionLineEnd + 2.0 * arrowSize * dimensionLineDirection);
        DxfDimension.smethod_14(line1, effectiveDimStyle);
        block.Entities.Add((DxfEntity) line1);
      }
    }

    internal static DxfLine[] smethod_18(
      DxfDimensionStyleOverrides effectiveDimensionStyle,
      WW.Math.Point3D lineStart,
      WW.Math.Point3D lineEnd,
      WW.Math.Point3D textBbOrigin,
      Vector3D textBbDx,
      Vector3D textBbDy)
    {
      Vector3D unit1 = textBbDx.GetUnit();
      Vector3D unit2 = textBbDy.GetUnit();
      Vector3D vector3D = Vector3D.CrossProduct(unit1, unit2);
      Matrix4D matrix4D = new Matrix4D(unit1.X, unit2.X, vector3D.X, textBbOrigin.X, unit1.Y, unit2.Y, vector3D.Y, textBbOrigin.Y, unit1.Z, unit2.Z, vector3D.Z, textBbOrigin.Z, 0.0, 0.0, 0.0, 1.0);
      Matrix4D inverse = matrix4D.GetInverse();
      WW.Math.Point2D point2D1 = inverse.TransformTo2D(lineStart);
      WW.Math.Point2D end1 = inverse.TransformTo2D(lineEnd);
      double num1 = System.Math.Abs(DxfDimension.smethod_15(effectiveDimensionStyle));
      bool flag = effectiveDimensionStyle.DimensionLineGap < 0.0;
      WW.Math.Point2D zero = WW.Math.Point2D.Zero;
      zero.X -= num1;
      WW.Math.Point2D point2D2 = inverse.TransformTo2D(textBbOrigin + textBbDx);
      point2D2.X += num1;
      WW.Math.Point2D point2D3 = inverse.TransformTo2D(textBbOrigin + textBbDx + textBbDy);
      point2D3.X += num1;
      WW.Math.Point2D point2D4 = inverse.TransformTo2D(textBbOrigin + textBbDy);
      point2D4.X -= num1;
      if (!flag)
      {
        zero.Y -= num1;
        point2D2.Y -= num1;
        point2D3.Y += num1;
        point2D4.Y += num1;
      }
      Segment2D a = new Segment2D(point2D1, end1);
      Polygon2D polygon2D = new Polygon2D(new WW.Math.Point2D[4]{ zero, point2D2, point2D3, point2D4 });
      List<double> doubleList = new List<double>(2);
      WW.Math.Point2D start = polygon2D[polygon2D.Count - 1];
      foreach (WW.Math.Point2D end2 in (List<WW.Math.Point2D>) polygon2D)
      {
        Segment2D b = new Segment2D(start, end2);
        double[] pArray;
        double[] qArray;
        if (Segment2D.GetIntersectionParameters(a, b, out pArray, out qArray))
          doubleList.AddRange((IEnumerable<double>) pArray);
        start = end2;
      }
      if (doubleList.Count < 2)
      {
        if (doubleList.Count == 1)
        {
          WW.Math.Point3D point3D = matrix4D.TransformTo3D(a.Start + a.GetDelta() * doubleList[0]);
          if (polygon2D.IsInside(point2D1))
            lineStart = point3D;
          else
            lineEnd = point3D;
        }
        DxfLine line = new DxfLine(EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor), lineStart, lineEnd);
        DxfDimension.smethod_14(line, effectiveDimensionStyle);
        return new DxfLine[1]{ line };
      }
      doubleList.Sort();
      double num2 = doubleList[0];
      WW.Math.Point2D point1 = a.Start + a.GetDelta() * num2;
      DxfLine line1 = new DxfLine(EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor), lineStart, matrix4D.TransformTo3D(point1));
      DxfDimension.smethod_14(line1, effectiveDimensionStyle);
      double num3 = doubleList[doubleList.Count - 1];
      WW.Math.Point2D point2 = a.Start + a.GetDelta() * num3;
      DxfLine line2 = new DxfLine(EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor), matrix4D.TransformTo3D(point2), lineEnd);
      DxfDimension.smethod_14(line2, effectiveDimensionStyle);
      return new DxfLine[2]{ line1, line2 };
    }

    internal bool method_15(
      WW.Math.Point3D angleVertex,
      WW.Math.Point3D dimensionLineArcPoint,
      WW.Math.Point3D extensionLine1StartPoint,
      WW.Math.Point3D extensionLine2StartPoint)
    {
      Vector3D vector3D1 = extensionLine1StartPoint - angleVertex;
      double min = DxfUtil.smethod_55(vector3D1.Y, vector3D1.X);
      Vector3D vector3D2 = extensionLine2StartPoint - angleVertex;
      double max = DxfUtil.smethod_55(vector3D2.Y, vector3D2.X);
      AngleIntervalD angleIntervalD = new AngleIntervalD(min, max);
      Vector3D vector3D3 = dimensionLineArcPoint - angleVertex;
      double num = DxfUtil.smethod_55(vector3D3.Y, vector3D3.X);
      return angleIntervalD.Contains(num);
    }

    internal void method_16(
      DxfModel model,
      DxfBlock block,
      WW.Math.Point3D angleVertex,
      WW.Math.Point3D extensionLine1StartPoint,
      WW.Math.Point3D extensionLine2StartPoint,
      WW.Math.Point3D dimensionLineArcPoint)
    {
      if (dimensionLineArcPoint == angleVertex)
        return;
      dimensionLineArcPoint.Z = 0.0;
      if (!this.method_15(angleVertex, dimensionLineArcPoint, extensionLine1StartPoint, extensionLine2StartPoint))
      {
        WW.Math.Point3D point3D = extensionLine1StartPoint;
        extensionLine1StartPoint = extensionLine2StartPoint;
        extensionLine2StartPoint = point3D;
      }
      DxfDimensionStyleOverrides effectiveDimensionStyle = this.GetEffectiveDimensionStyle(model);
      double length = (dimensionLineArcPoint - angleVertex).GetLength();
      this.method_17(model, block, extensionLine1StartPoint);
      Vector3D u1 = extensionLine1StartPoint - angleVertex;
      WW.Math.Point3D dimensionLineStartPoint = angleVertex;
      if (!Vector3D.AreApproxEqual(u1, Vector3D.Zero))
      {
        u1.Normalize();
        dimensionLineStartPoint += length * u1;
      }
      if (!effectiveDimensionStyle.SuppressFirstExtensionLine)
      {
        Vector3D vector3D1 = effectiveDimensionStyle.ScaleFactor * effectiveDimensionStyle.ExtensionLineOffset * u1;
        Vector3D vector3D2 = effectiveDimensionStyle.ScaleFactor * effectiveDimensionStyle.ExtensionLineExtension * u1;
        DxfLine dxfLine = new DxfLine(EntityColor.CreateFrom(effectiveDimensionStyle.ExtensionLineColor), extensionLine1StartPoint + vector3D1, dimensionLineStartPoint + vector3D2);
        dxfLine.LineWeight = effectiveDimensionStyle.ExtensionLineWeight;
        dxfLine.LineType = effectiveDimensionStyle.FirstExtensionLineLineType;
        block.Entities.Add((DxfEntity) dxfLine);
      }
      this.method_17(model, block, extensionLine2StartPoint);
      Vector3D u2 = extensionLine2StartPoint - angleVertex;
      WW.Math.Point3D dimensionLineEndPoint = angleVertex;
      if (!Vector3D.AreApproxEqual(u2, Vector3D.Zero))
      {
        u2.Normalize();
        dimensionLineEndPoint += length * u2;
      }
      if (!effectiveDimensionStyle.SuppressSecondExtensionLine)
      {
        Vector3D vector3D1 = effectiveDimensionStyle.ScaleFactor * effectiveDimensionStyle.ExtensionLineOffset * u2;
        Vector3D vector3D2 = effectiveDimensionStyle.ScaleFactor * effectiveDimensionStyle.ExtensionLineExtension * u2;
        DxfLine dxfLine = new DxfLine(EntityColor.CreateFrom(effectiveDimensionStyle.ExtensionLineColor), extensionLine2StartPoint + vector3D1, dimensionLineEndPoint + vector3D2);
        dxfLine.LineWeight = effectiveDimensionStyle.ExtensionLineWeight;
        dxfLine.LineType = effectiveDimensionStyle.SecondExtensionLineLineType;
        block.Entities.Add((DxfEntity) dxfLine);
      }
      this.DrawDimensionLineArc(model, block, angleVertex, effectiveDimensionStyle, length, dimensionLineStartPoint, dimensionLineEndPoint);
    }

    protected void DrawDimensionLineArc(
      DxfModel model,
      DxfBlock block,
      WW.Math.Point3D angleVertex,
      DxfDimensionStyleOverrides effectiveDimStyle,
      double radius,
      WW.Math.Point3D dimensionLineStartPoint,
      WW.Math.Point3D dimensionLineEndPoint)
    {
      double arrowSize = DxfDimension.GetArrowSize(effectiveDimStyle);
      double num1 = 2.0 * radius;
      double num2 = arrowSize < num1 ? 2.0 * System.Math.Asin(arrowSize / (2.0 * radius)) : 2.0 * System.Math.PI;
      Vector3D vector3D1 = dimensionLineStartPoint - angleVertex;
      double endAngle = DxfUtil.smethod_55(vector3D1.Y, vector3D1.X);
      Vector3D vector3D2 = dimensionLineEndPoint - angleVertex;
      double num3 = DxfUtil.smethod_55(vector3D2.Y, vector3D2.X);
      if (num3 < endAngle)
        num3 += 2.0 * System.Math.PI;
      bool flag1;
      double num4 = (flag1 = num3 - endAngle > System.Math.Abs(2.02 * num2)) ? num2 : -num2;
      double num5 = endAngle - System.Math.PI / 2.0 + num4 * 0.5;
      Vector3D arrowDirection1 = new Vector3D(System.Math.Cos(num5), System.Math.Sin(num5), 0.0);
      if (!flag1)
        arrowDirection1 *= -1.0;
      block.Entities.Add(DxfDimension.smethod_16(new bool?(true), dimensionLineStartPoint, arrowDirection1, new Vector3D(arrowDirection1.Y, -arrowDirection1.X, 0.0), effectiveDimStyle, out arrowSize));
      double num6 = num3 + System.Math.PI / 2.0 - num4 * 0.5;
      Vector3D arrowDirection2 = new Vector3D(System.Math.Cos(num6), System.Math.Sin(num6), 0.0);
      if (!flag1)
        arrowDirection2 *= -1.0;
      block.Entities.Add(DxfDimension.smethod_16(new bool?(false), dimensionLineEndPoint, arrowDirection2, new Vector3D(arrowDirection2.Y, -arrowDirection2.X, 0.0), effectiveDimStyle, out arrowSize));
      WW.Math.Point3D point3D1 = dimensionLineStartPoint - arrowSize * arrowDirection1;
      Vector3D vector3D3 = point3D1 - angleVertex;
      double num7 = DxfUtil.smethod_55(vector3D3.Y, vector3D3.X);
      if (num7 < 0.0)
        num7 += 2.0 * System.Math.PI;
      WW.Math.Point3D point3D2 = dimensionLineEndPoint - arrowSize * arrowDirection2;
      Vector3D vector3D4 = point3D2 - angleVertex;
      double num8 = DxfUtil.smethod_55(vector3D4.Y, vector3D4.X);
      if (num8 < 0.0)
        num8 += 2.0 * System.Math.PI;
      double num9 = (num7 + (num8 < num7 ? num8 + 2.0 * System.Math.PI : num8)) * 0.5;
      Vector3D vector3D5 = new Vector3D(System.Math.Cos(num9), System.Math.Sin(num9), 0.0);
      WW.Math.Point3D position = !this.UseTextMiddlePoint ? angleVertex + vector3D5 * radius : this.TextMiddlePointWcs;
      if (!flag1)
        position += DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimStyle) * vector3D5;
      Vector3D vector3D6 = Vector3D.Zero;
      Vector3D vector3D7 = Vector3D.Zero;
      WW.Math.Point3D point3D3 = WW.Math.Point3D.Zero;
      string text = this.GetText(effectiveDimStyle);
      bool flag2 = false;
      if (!string.IsNullOrEmpty(text))
      {
        Vector3D xaxis = Vector3D.XAxis;
        DxfMText dxfMtext = DxfDimension.smethod_11(model, text, position, xaxis, this.attachmentPoint_0, effectiveDimStyle);
        block.Entities.Add((DxfEntity) dxfMtext);
        Class976 class976_1 = new Class976(dxfMtext.TextBounds, dxfMtext.Transform);
        Vector3D vector3D8 = point3D2 - point3D1;
        double length = vector3D8.GetLength();
        Vector3D unit1 = vector3D8.GetUnit();
        double num10 = System.Math.Abs(Vector3D.DotProduct(class976_1.Dx + class976_1.Dy, unit1));
        if (!effectiveDimStyle.TextInsideExtensions && !this.UseTextMiddlePoint && (length < num10 || !flag1))
        {
          double num11 = !flag1 ? DxfUtil.smethod_56(num7 - System.Math.PI / 20.0) : DxfUtil.smethod_56(endAngle - System.Math.PI / 20.0);
          bool flag3 = num11 > System.Math.PI;
          WW.Math.Point3D start = angleVertex + radius * new Vector3D(System.Math.Cos(num11), System.Math.Sin(num11), 0.0);
          double num12 = arrowSize + (effectiveDimStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Above ? vector3D6.GetLength() : 0.0);
          WW.Math.Point3D end = start + Vector3D.XAxis * num12 * (flag3 ? -1.0 : 1.0);
          DxfLine line = new DxfLine(EntityColor.CreateFrom(effectiveDimStyle.DimensionLineColor), start, end);
          DxfDimension.smethod_14(line, effectiveDimStyle);
          block.Entities.Add((DxfEntity) line);
          flag2 = true;
          WW.Math.Point3D point3D4 = start + Vector3D.XAxis * arrowSize * (flag3 ? -1.0 : 1.0) + DxfDimension.smethod_15(effectiveDimStyle) * (flag3 ? -1.0 : 1.0) * Vector3D.XAxis;
          dxfMtext.InsertionPoint = point3D4;
          dxfMtext.XAxis = Vector3D.XAxis;
          dxfMtext.AttachmentPoint = flag3 ? AttachmentPoint.MiddleRight : AttachmentPoint.MiddleLeft;
        }
        if (this.bool_3)
          dxfMtext.XAxis = new Vector3D(System.Math.Cos(this.double_3), System.Math.Sin(this.double_3), 0.0);
        Class976 class976_2 = new Class976(dxfMtext.TextBounds, dxfMtext.Transform);
        Vector3D vector3D9 = Vector3D.CrossProduct(class976_2.Dx, class976_2.Dy);
        vector3D6 = class976_2.Dx;
        vector3D7 = class976_2.Dy;
        WW.Math.Point3D origin = class976_2.Origin;
        if (vector3D9.Z < 0.0)
        {
          Vector3D vector3D10 = vector3D6;
          vector3D6 = vector3D7;
          vector3D7 = vector3D10;
        }
        double num13 = System.Math.Abs(DxfDimension.smethod_15(effectiveDimStyle));
        bool flag4 = effectiveDimStyle.DimensionLineGap < 0.0;
        Vector3D unit2 = vector3D6.GetUnit();
        Vector3D unit3 = vector3D7.GetUnit();
        point3D3 = origin - unit2 * num13;
        vector3D6 += 2.0 * num13 * unit2;
        if (!flag4)
        {
          point3D3 -= unit3 * num13;
          vector3D7 += 2.0 * num13 * unit3;
        }
      }
      if (flag1)
      {
        Arc2D arc = new Arc2D(angleVertex.X, angleVertex.Y, radius, num7, num8);
        Arc2D[] arc2DArray;
        if (text == null)
          arc2DArray = new Arc2D[1]{ arc };
        else
          arc2DArray = IntersectionUtil.CutRectangleFromArc(new Vector2D(point3D3.X, point3D3.Y), new Vector2D(vector3D6.X, vector3D6.Y), new Vector2D(vector3D7.X, vector3D7.Y), arc);
        foreach (Arc2D arc2D in arc2DArray)
        {
          DxfArc dxfArc = new DxfArc(angleVertex, radius, arc2D.StartAngle, arc2D.EndAngle);
          dxfArc.Color = EntityColor.CreateFrom(effectiveDimStyle.DimensionLineColor);
          dxfArc.LineWeight = effectiveDimStyle.DimensionLineWeight;
          block.Entities.Add((DxfEntity) dxfArc);
        }
        if (!flag2)
          return;
        DxfArc dxfArc1 = new DxfArc(angleVertex, radius, endAngle - System.Math.PI / 20.0, endAngle);
        dxfArc1.Color = EntityColor.CreateFrom(effectiveDimStyle.DimensionLineColor);
        dxfArc1.LineWeight = effectiveDimStyle.DimensionLineWeight;
        block.Entities.Add((DxfEntity) dxfArc1);
      }
      else
      {
        DxfArc dxfArc1 = new DxfArc(angleVertex, radius, num7 - System.Math.PI / 20.0, num7);
        dxfArc1.Color = EntityColor.CreateFrom(effectiveDimStyle.DimensionLineColor);
        dxfArc1.LineWeight = effectiveDimStyle.DimensionLineWeight;
        block.Entities.Add((DxfEntity) dxfArc1);
        DxfArc dxfArc2 = new DxfArc(angleVertex, radius, num8, num8 + System.Math.PI / 20.0);
        dxfArc2.Color = EntityColor.CreateFrom(effectiveDimStyle.DimensionLineColor);
        dxfArc2.LineWeight = effectiveDimStyle.DimensionLineWeight;
        block.Entities.Add((DxfEntity) dxfArc2);
      }
    }

    private void method_17(DxfModel model, DxfBlock block, WW.Math.Point3D defPoint)
    {
      DxfPoint dxfPoint = new DxfPoint(defPoint);
      dxfPoint.Layer = model.method_14();
      if (this.Color == EntityColor.ByLayer)
      {
        DxfLayer dxfLayer = this.Layer ?? model.ZeroLayer;
        dxfPoint.Color = EntityColor.CreateFrom(dxfLayer.Color);
      }
      else
        dxfPoint.Color = this.Color;
      block.Entities.Add((DxfEntity) dxfPoint);
    }

    internal string method_18(DxfDimensionStyleOverrides effectiveDimensionStyle)
    {
      return DxfDimension.smethod_19(effectiveDimensionStyle, this.GetActualMeasurement());
    }

    internal static string smethod_19(
      DxfDimensionStyleOverrides effectiveDimensionStyle,
      double angleInRadians)
    {
      NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
      numberFormatInfo.NumberDecimalSeparator = effectiveDimensionStyle.DecimalSeparator.ToString();
      numberFormatInfo.NumberDecimalDigits = (int) effectiveDimensionStyle.AngularDimensionDecimalPlaces;
      string str;
      switch (effectiveDimensionStyle.AngularUnit)
      {
        case AngularUnit.DecimalDegrees:
          double num1 = angleInRadians / System.Math.PI * 180.0;
          if (effectiveDimensionStyle.Rounding != 0.0)
            num1 = effectiveDimensionStyle.Rounding * System.Math.Round(num1 / effectiveDimensionStyle.Rounding);
          str = System.Math.Round(num1, numberFormatInfo.NumberDecimalDigits).ToString("N", (IFormatProvider) numberFormatInfo) + "°";
          break;
        case AngularUnit.DegreesMinutesSeconds:
          double num2 = angleInRadians / System.Math.PI * 180.0;
          if (effectiveDimensionStyle.Rounding != 0.0)
            num2 = effectiveDimensionStyle.Rounding * System.Math.Round(num2 / effectiveDimensionStyle.Rounding);
          str = System.Math.Round(num2, numberFormatInfo.NumberDecimalDigits).ToString("N", (IFormatProvider) numberFormatInfo) + "°";
          break;
        case AngularUnit.Gradians:
          double num3 = angleInRadians / System.Math.PI * 200.0;
          if (effectiveDimensionStyle.Rounding != 0.0)
            num3 = effectiveDimensionStyle.Rounding * System.Math.Round(num3 / effectiveDimensionStyle.Rounding);
          str = System.Math.Round(num3, numberFormatInfo.NumberDecimalDigits).ToString("N", (IFormatProvider) numberFormatInfo) + "g";
          break;
        case AngularUnit.SurveyorsUnits:
          double num4 = angleInRadians / System.Math.PI * 180.0;
          if (effectiveDimensionStyle.Rounding != 0.0)
            num4 = effectiveDimensionStyle.Rounding * System.Math.Round(num4 / effectiveDimensionStyle.Rounding);
          str = System.Math.Round(num4, numberFormatInfo.NumberDecimalDigits).ToString("N", (IFormatProvider) numberFormatInfo) + "°";
          break;
        default:
          double num5 = angleInRadians;
          if (effectiveDimensionStyle.Rounding != 0.0)
            num5 = effectiveDimensionStyle.Rounding * System.Math.Round(num5 / effectiveDimensionStyle.Rounding);
          str = System.Math.Round(num5, numberFormatInfo.NumberDecimalDigits).ToString("N", (IFormatProvider) numberFormatInfo) + "r";
          break;
      }
      return str;
    }

    protected internal void DrawCross(
      DxfBlock block,
      WW.Math.Point3D position,
      EntityColor color,
      double size)
    {
      DxfLine dxfLine1 = new DxfLine(color, position - Vector3D.XAxis * size * 0.5, position + Vector3D.XAxis * size * 0.5);
      block.Entities.Add((DxfEntity) dxfLine1);
      DxfLine dxfLine2 = new DxfLine(color, position - Vector3D.YAxis * size * 0.5, position + Vector3D.YAxis * size * 0.5);
      block.Entities.Add((DxfEntity) dxfLine2);
    }

    protected internal void DrawCross(
      DxfBlock block,
      WW.Math.Point3D? position,
      EntityColor color,
      double size)
    {
      if (!position.HasValue)
        return;
      this.DrawCross(block, position.Value, color, size);
    }

    internal virtual string MeasurementPrefix
    {
      get
      {
        return "";
      }
    }

    internal DxfDimension.Class861 method_19(
      DxfDimensionStyleOverrides effectiveDimensionStyle)
    {
      string text = this.GetText(effectiveDimensionStyle);
      DxfDimension.Class861 class861 = new DxfDimension.Class861(this.Model.Header.AcadVersion);
      if (!string.IsNullOrEmpty(text))
      {
        int length = text.IndexOf("\\X");
        if (length >= 0)
        {
          class861.Upper.Text = text.Substring(0, length);
          class861.Lower.Text = text.Substring(length + 2);
        }
        else
          class861.Upper.Text = text;
      }
      return class861;
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      if (this.Block == null)
        this.GenerateBlock();
      if (this.dxfDimensionStyleOverrides_0 == null)
        return;
      this.dxfDimensionStyleOverrides_0.method_0((DxfEntity) this);
    }

    protected virtual void UpdatePositions(Matrix4D transform)
    {
      this.point3D_0 = transform.Transform(this.point3D_0);
      this.point3D_1 = transform.Transform(this.point3D_1);
    }

    protected DxfLine CreateExtensionLine(
      WW.Math.Point3D startPoint,
      WW.Math.Point3D endPoint,
      DxfDimensionStyleOverrides effectiveDimStyle,
      bool first)
    {
      DxfLine dxfLine = new DxfLine(EntityColor.CreateFrom(effectiveDimStyle.ExtensionLineColor), startPoint, endPoint);
      dxfLine.LineWeight = effectiveDimStyle.ExtensionLineWeight;
      dxfLine.LineType = first ? effectiveDimStyle.FirstExtensionLineLineType : effectiveDimStyle.SecondExtensionLineLineType;
      return dxfLine;
    }

    private new Matrix4D Transform
    {
      get
      {
        Matrix4D matrix4D = DxfUtil.GetToWCSTransform(this.vector3D_0) * Transformation4D.Translation((Vector3D) this.point3D_0);
        if (this.insertionScaleFactor.X != 1.0 || this.insertionScaleFactor.Y != 1.0 || this.insertionScaleFactor.Z != 1.0)
          matrix4D *= Transformation4D.Scaling(this.insertionScaleFactor);
        if (this.insertionRotation != 0.0)
          matrix4D *= Transformation4D.RotateZ(this.insertionRotation);
        return matrix4D;
      }
    }

    private void method_20()
    {
      if (this.Block != null && !this.bool_5)
        return;
      this.GenerateBlock();
    }

    private Matrix4D method_21()
    {
      return this.Transform.GetInverse();
    }

    private DxfDimensionStyleOverrides GetEffectiveDimensionStyle(
      DxfModel model)
    {
      DxfDimensionStyleOverrides dimensionStyleOverrides = this.dxfDimensionStyleOverrides_0 ?? model.Header.DimensionStyleOverrides;
      if (this.IsAnnotative)
      {
        CloneContext cloneContext = new CloneContext(model, model, ReferenceResolutionType.IgnoreMissing);
        dimensionStyleOverrides = dimensionStyleOverrides.Clone(cloneContext);
        cloneContext.ResolveReferences();
        DxfAnnotationScaleObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false);
        dimensionStyleOverrides.ScaleFactor = objectContextData != null ? 1.0 / objectContextData.Scale.ScaleFactor : 1.0;
      }
      return dimensionStyleOverrides;
    }

    private static string smethod_20(
      string text,
      string numerator,
      string denominator,
      FractionFormat fractionFormat)
    {
      StringBuilder stringBuilder = new StringBuilder();
      switch (fractionFormat)
      {
        case FractionFormat.HorizontalStacking:
          stringBuilder.Append("\\A1;");
          stringBuilder.Append(text);
          stringBuilder.Append("{\\H1.0x;\\S");
          stringBuilder.Append(numerator);
          stringBuilder.Append('/');
          stringBuilder.Append(denominator);
          stringBuilder.Append(";}");
          break;
        case FractionFormat.DiagonalStacking:
          stringBuilder.Append("\\A1;");
          stringBuilder.Append(text);
          stringBuilder.Append("{\\H1.0x;\\S");
          stringBuilder.Append(numerator);
          stringBuilder.Append('#');
          stringBuilder.Append(denominator);
          stringBuilder.Append(";}");
          break;
        default:
          stringBuilder.Append(text);
          if (text.Length > 0)
            stringBuilder.Append(" ");
          stringBuilder.Append(numerator);
          stringBuilder.Append('/');
          stringBuilder.Append(denominator);
          break;
      }
      return stringBuilder.ToString();
    }

    public bool IsAnnotative
    {
      get
      {
        return this.bool_6;
      }
      set
      {
        this.bool_6 = value;
      }
    }

    public abstract DxfAnnotationScaleObjectContextData CreateContextData(
      DxfScale scale);

    public class Aligned : DxfDimension, IControlPointCollection
    {
      private static readonly IControlPoint[] icontrolPoint_0 = new IControlPoint[3]{ DxfDimension.Aligned.Class825.icontrolPoint_0, DxfDimension.Aligned.Class826.icontrolPoint_0, DxfDimension.Aligned.Class827.icontrolPoint_0 };
      private double double_5 = System.Math.PI / 2.0;
      private WW.Math.Point3D point3D_2;
      private WW.Math.Point3D point3D_3;
      private WW.Math.Point3D point3D_4;

      public Aligned(DxfDimensionStyle dimensionStyle)
        : base(dimensionStyle)
      {
      }

      protected internal Aligned(DxfModel model)
        : base(model)
      {
      }

      public WW.Math.Point3D DimensionLineLocation
      {
        get
        {
          if (!this.IsAnnotative)
            return this.point3D_2;
          DxfDimensionObjectContextData.Aligned aligned = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfDimensionObjectContextData.Aligned;
          if (aligned != null)
            return aligned.DimensionLineLocation;
          return this.point3D_2;
        }
        set
        {
          if (!this.IsAnnotative)
          {
            this.point3D_2 = value;
          }
          else
          {
            DxfDimensionObjectContextData.Aligned aligned = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfDimensionObjectContextData.Aligned;
            if (aligned != null)
              aligned.DimensionLineLocation = value;
            if (aligned != null && !aligned.IsDefault)
              return;
            this.point3D_2 = value;
          }
        }
      }

      public WW.Math.Point3D ExtensionLine1StartPoint
      {
        get
        {
          return this.point3D_3;
        }
        set
        {
          this.point3D_3 = value;
        }
      }

      public WW.Math.Point3D ExtensionLine2StartPoint
      {
        get
        {
          return this.point3D_4;
        }
        set
        {
          this.point3D_4 = value;
        }
      }

      public double ObliqueAngle
      {
        get
        {
          return this.double_5;
        }
        set
        {
          this.double_5 = value;
        }
      }

      public override string AcClass
      {
        get
        {
          return "AcDbAlignedDimension";
        }
      }

      public override void TransformMe(
        TransformConfig config,
        Matrix4D matrix,
        CommandGroup undoGroup)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfDimension.Aligned.Class828 class828 = new DxfDimension.Aligned.Class828();
        // ISSUE: reference to a compiler-generated field
        class828.aligned_0 = this;
        CommandGroup undoGroup1 = (CommandGroup) null;
        if (undoGroup != null)
        {
          undoGroup1 = new CommandGroup((object) this);
          undoGroup.UndoStack.Push((ICommand) undoGroup1);
        }
        base.TransformMe(config, matrix, undoGroup1);
        // ISSUE: reference to a compiler-generated field
        class828.point3D_0 = this.point3D_2;
        // ISSUE: reference to a compiler-generated field
        class828.point3D_1 = this.point3D_3;
        // ISSUE: reference to a compiler-generated field
        class828.point3D_2 = this.point3D_4;
        this.point3D_2 = matrix.Transform(this.point3D_2);
        this.point3D_3 = matrix.Transform(this.point3D_3);
        this.point3D_4 = matrix.Transform(this.point3D_4);
        if (undoGroup1 == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup1.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfDimension.Aligned.Class829()
        {
          class828_0 = class828,
          point3D_0 = this.point3D_2,
          point3D_1 = this.point3D_3,
          point3D_2 = this.point3D_4
        }.method_0), new System.Action(class828.method_0)));
      }

      public override void GenerateBlock()
      {
        base.GenerateBlock();
        DxfModel model = this.Model;
        if (model == null)
          throw new DxfException("Cannot generate dimension block, dimension is not part of a model.");
        Matrix4D wcsToBcs = this.method_21();
        WW.Math.Point3D point3D1 = wcsToBcs.Transform(this.DimensionLineLocation);
        WW.Math.Point3D defPoint1 = wcsToBcs.Transform(this.ExtensionLine1StartPoint);
        WW.Math.Point3D defPoint2 = wcsToBcs.Transform(this.ExtensionLine2StartPoint);
        Vector3D v1 = point3D1 - defPoint2;
        Vector3D v2 = defPoint2 - defPoint1;
        Vector3D u = !(this.ExtensionLine1StartPoint == this.ExtensionLine2StartPoint) ? this.vmethod_14(wcsToBcs) : new Vector3D(System.Math.Cos(-this.HorizontalDirection), System.Math.Sin(-this.HorizontalDirection), 0.0);
        double num1 = (double) System.Math.Sign(Vector3D.DotProduct(u, v2));
        if (num1 == 0.0)
          num1 = 1.0;
        Vector3D vector3D1 = u * num1;
        Vector3D unit1 = Vector3D.CrossProduct(Vector3D.ZAxis, vector3D1).GetUnit();
        Vector3D unit2 = Vector3D.CrossProduct(Vector3D.ZAxis, vector3D1).GetUnit();
        double num2 = this.vmethod_15();
        if (num2 == 0.0)
          num2 = System.Math.PI / 2.0;
        Vector3D vector3D2 = System.Math.Cos(num2) * vector3D1 + System.Math.Sin(num2) * unit1;
        double num3 = Vector3D.DotProduct(unit1, v1) / System.Math.Abs(System.Math.Sin(num2));
        double length = v2.GetLength();
        double num4 = 0.0;
        if (length > 8.88178419700125E-16)
          num4 = v2.GetLength() * Vector3D.DotProduct(v2.GetUnit(), vector3D1);
        WW.Math.Point3D point3D2 = defPoint2 + num3 * vector3D2;
        WW.Math.Point3D point3D3 = point3D2 - vector3D1 * num4;
        double dimensionLineExtensionOverrideStart = 0.0;
        double dimensionLineExtensionOverrideEnd = 0.0;
        DxfDimensionStyleOverrides effectiveDimensionStyle = this.GetEffectiveDimensionStyle(model);
        double num5 = effectiveDimensionStyle.ScaleFactor * effectiveDimensionStyle.ExtensionLineOffset;
        double num6 = effectiveDimensionStyle.ScaleFactor * effectiveDimensionStyle.ExtensionLineExtension;
        this.method_17(model, this.Block, defPoint1);
        this.method_17(model, this.Block, defPoint2);
        this.method_17(model, this.Block, point3D3);
        if (!effectiveDimensionStyle.SuppressFirstExtensionLine)
        {
          Vector3D vector3D3 = point3D3 - defPoint1;
          if (vector3D3 != Vector3D.Zero)
            vector3D3.Normalize();
          WW.Math.Point3D endPoint = point3D3 + num6 * vector3D3;
          this.Block.Entities.Add((DxfEntity) this.CreateExtensionLine(!effectiveDimensionStyle.IsExtensionLineLengthFixed || effectiveDimensionStyle.FixedExtensionLineLength >= (defPoint1 - point3D3).GetLength() ? defPoint1 + num5 * vector3D3 : point3D3 - effectiveDimensionStyle.FixedExtensionLineLength * vector3D3, endPoint, effectiveDimensionStyle, true));
        }
        if (!effectiveDimensionStyle.SuppressSecondExtensionLine)
        {
          Vector3D vector3D3 = point3D2 - defPoint2;
          if (vector3D3 != Vector3D.Zero)
            vector3D3.Normalize();
          WW.Math.Point3D endPoint = point3D2 + num6 * vector3D3;
          this.Block.Entities.Add((DxfEntity) this.CreateExtensionLine(!effectiveDimensionStyle.IsExtensionLineLengthFixed || effectiveDimensionStyle.FixedExtensionLineLength >= (defPoint2 - point3D2).GetLength() ? defPoint2 + num5 * vector3D3 : point3D2 - effectiveDimensionStyle.FixedExtensionLineLength * vector3D3, endPoint, effectiveDimensionStyle, false));
        }
        WW.Math.Point3D position = !this.UseTextMiddlePoint ? (WW.Math.Point3D) (((Vector3D) point3D3 + (Vector3D) point3D2) * 0.5) : this.TextMiddlePoint;
        Vector3D textHeightVector = DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimensionStyle) * unit2;
        if (textHeightVector.Y < 0.0)
          textHeightVector = -textHeightVector;
        double arrowSize = DxfDimension.GetArrowSize(effectiveDimensionStyle);
        double num7 = System.Math.Abs(num4) - 2.0 * arrowSize;
        bool flag;
        bool drawArrowsInsideExtensionLines = flag = System.Math.Abs(num4) > 2.02 * arrowSize;
        DxfDimension.Class861 texts = this.method_19(effectiveDimensionStyle);
        bool leaderCreated = false;
        if (!texts.method_0())
        {
          Vector3D vector = vector3D1;
          if (this.double_4 != 0.0)
            vector = Transformation3D.RotateZ(this.double_4).Transform(vector);
          double num8 = 1.0;
          double num9 = System.Math.Round(System.Math.Atan2(vector.Y, vector.X) * 180.0 / System.Math.PI);
          if (num9 > 90.01 || num9 <= -90.0)
            num8 = -1.0;
          Vector3D vector3D3 = vector3D1 * num8;
          Vector3D vector3D4 = num8 < 0.0 ? -unit2 : unit2;
          bool outsideIsAboveDimLine = Vector3D.DotProduct(point3D1 - defPoint1, vector3D4) >= 0.0;
          texts.method_3(model, (DxfDimension) this, position, vector3D3, vector3D4, effectiveDimensionStyle, this.bool_2, outsideIsAboveDimLine);
          texts.method_1(this.Block.Entities);
          double textDx = texts.method_2(vector3D3) + 2.0 * System.Math.Abs(DxfDimension.smethod_15(effectiveDimensionStyle));
          if (this.UseTextMiddlePoint)
          {
            double num10 = Vector3D.DotProduct(position - point3D3, vector3D1);
            drawArrowsInsideExtensionLines = new IntervalD(0.0, num4).Contains(num10);
            if (effectiveDimensionStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Above)
            {
              WW.Math.Point3D point3D4 = point3D3 + num10 * vector3D1;
              Vector3D dy = texts.Bounds.Dy;
              texts.method_2(vector3D1);
              if (!drawArrowsInsideExtensionLines)
              {
                if (num10 < 0.0)
                  dimensionLineExtensionOverrideStart = -texts.Bounds.method_0(point3D3, -vector3D1);
                else
                  dimensionLineExtensionOverrideEnd = texts.Bounds.method_0(point3D2, vector3D1);
              }
            }
          }
          else if (!effectiveDimensionStyle.TextInsideExtensions && (num7 < textDx || !flag))
          {
            bool textLeft = MathUtil.AreApproxEqual(defPoint1.X, defPoint2.X) && defPoint1.Y > defPoint2.Y || defPoint1.X > defPoint2.X;
            WW.Math.Point3D leaderLine2StartPoint;
            DxfDimension.smethod_13(model, this.Block, point3D2, vector3D1, arrowSize, effectiveDimensionStyle, textDx, textLeft, flag, false, out leaderLine2StartPoint);
            leaderCreated = true;
            WW.Math.Point3D textPosition = !effectiveDimensionStyle.TextOutsideHorizontal ? leaderLine2StartPoint + vector3D1 * (arrowSize + DxfDimension.smethod_15(effectiveDimensionStyle)) : leaderLine2StartPoint + Vector3D.XAxis * arrowSize * (textLeft ? -1.0 : 1.0) + DxfDimension.smethod_15(effectiveDimensionStyle) * (textLeft ? -1.0 : 1.0) * Vector3D.XAxis;
            DxfDimension.Aligned.smethod_21(texts, effectiveDimensionStyle, textPosition, textHeightVector, textLeft, vector3D1);
          }
          if (this.HasTextRotation && this.TextRotation != 0.0)
            texts.method_7(this.TextRotation);
          texts.method_2(vector3D3);
        }
        DxfDimension.smethod_17(this.Block, point3D3, point3D2, dimensionLineExtensionOverrideStart, dimensionLineExtensionOverrideEnd, vector3D1, Vector3D.CrossProduct(Vector3D.ZAxis, vector3D1), effectiveDimensionStyle, flag, drawArrowsInsideExtensionLines, texts, leaderCreated);
      }

      private static void smethod_21(
        DxfDimension.Class861 texts,
        DxfDimensionStyleOverrides effectiveDimStyle,
        WW.Math.Point3D textPosition,
        Vector3D textHeightVector,
        bool textLeft,
        Vector3D dimensionLineDirection)
      {
        if (effectiveDimStyle.TextOutsideHorizontal)
        {
          if (effectiveDimStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Above)
            textPosition += DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimStyle) * Vector3D.YAxis;
          texts.method_5(textPosition, textPosition - 2.0 * textHeightVector, 0.0, textLeft ? TextHorizontalAlignment.Right : TextHorizontalAlignment.Left);
        }
        else
        {
          if (effectiveDimStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Above)
            textPosition += 0.5 * textHeightVector + DxfDimension.smethod_15(effectiveDimStyle) * textHeightVector.GetUnit();
          double num;
          bool flag;
          if (Vector3D.DotProduct(new Vector3D(1.0, 1.0, 0.0), dimensionLineDirection) >= 0.0)
          {
            num = 1.0;
            flag = true;
          }
          else
          {
            num = -1.0;
            flag = false;
          }
          texts.method_6(textPosition, textPosition - 2.0 * textHeightVector, num * dimensionLineDirection, flag ? TextHorizontalAlignment.Left : TextHorizontalAlignment.Right);
        }
      }

      public override void DrawInternal(
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        if (context.Config.ShowDimensionDefinitionPoints)
        {
          IClippingTransformer transformer = context.GetTransformer();
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_2), ArgbColors.Yellow);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_3), ArgbColors.Orange);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_4), ArgbColors.DarkOrange);
        }
        base.DrawInternal(context, graphicsFactory);
      }

      public override void DrawInternal(
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        if (context.Config.ShowDimensionDefinitionPoints)
        {
          IClippingTransformer transformer = context.GetTransformer();
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_2), ArgbColors.Yellow);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_3), ArgbColors.Orange);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_4), ArgbColors.DarkOrange);
        }
        base.DrawInternal(context, graphicsFactory);
      }

      public override double GetActualMeasurement()
      {
        return this.GetLinearScaleFactor(this.GetEffectiveDimensionStyle()) * (this.point3D_4 - this.point3D_3).GetLength();
      }

      public override double GetActualAlternateMeasurement()
      {
        return this.GetAlternateScaleFactor(this.GetEffectiveDimensionStyle()) * (this.point3D_4 - this.point3D_3).GetLength();
      }

      public override IGraphCloneable Clone(CloneContext cloneContext)
      {
        DxfDimension.Aligned aligned = (DxfDimension.Aligned) cloneContext.GetExistingClone((IGraphCloneable) this);
        if (aligned == null)
        {
          aligned = new DxfDimension.Aligned(cloneContext.TargetModel);
          cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) aligned);
          aligned.CopyFrom((DxfHandledObject) this, cloneContext);
        }
        return (IGraphCloneable) aligned;
      }

      public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
      {
        base.CopyFrom(from, cloneContext);
        DxfDimension.Aligned aligned = (DxfDimension.Aligned) from;
        this.point3D_2 = aligned.point3D_2;
        this.point3D_3 = aligned.point3D_3;
        this.point3D_4 = aligned.point3D_4;
        this.double_5 = aligned.double_5;
      }

      public override void Accept(IEntityVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override IControlPointCollection InteractionControlPoints
      {
        get
        {
          return (IControlPointCollection) this;
        }
      }

      internal virtual Vector3D vmethod_14(Matrix4D wcsToBcs)
      {
        return wcsToBcs.Transform((this.point3D_4 - this.point3D_3).GetUnit());
      }

      internal virtual double vmethod_15()
      {
        return this.double_5;
      }

      void IControlPointCollection.Set(int index, WW.Math.Point3D value)
      {
        DxfDimension.Aligned.icontrolPoint_0[index].SetValue((object) this, value);
      }

      WW.Math.Point3D IControlPointCollection.Get(int index)
      {
        return DxfDimension.Aligned.icontrolPoint_0[index].GetValue((object) this);
      }

      string IControlPointCollection.GetDescription(int index)
      {
        return DxfDimension.Aligned.icontrolPoint_0[index].Description;
      }

      PointDisplayType IControlPointCollection.GetDisplayType(
        int index)
      {
        return DxfDimension.Aligned.icontrolPoint_0[index].DisplayType;
      }

      int IControlPointCollection.Count
      {
        get
        {
          return DxfDimension.Aligned.icontrolPoint_0.Length;
        }
      }

      bool IControlPointCollection.IsCountFixed
      {
        get
        {
          return true;
        }
      }

      void IControlPointCollection.Insert(int index)
      {
        throw new NotSupportedException();
      }

      void IControlPointCollection.RemoveAt(int index)
      {
        throw new NotSupportedException();
      }

      internal override short vmethod_6(Class432 w)
      {
        return 22;
      }

      public override DxfAnnotationScaleObjectContextData CreateContextData(
        DxfScale scale)
      {
        return (DxfAnnotationScaleObjectContextData) new DxfDimensionObjectContextData.Aligned(this, scale);
      }

      private class Class825 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Aligned.Class825();

        private Class825()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          ((DxfDimension.Aligned) owner).point3D_3 = value;
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Aligned) owner).point3D_3;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Aligned_ExtensionLine1StartControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }

      private class Class826 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Aligned.Class826();

        private Class826()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          ((DxfDimension.Aligned) owner).point3D_4 = value;
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Aligned) owner).point3D_4;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Aligned_ExtensionLine2StartControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }

      private class Class827 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Aligned.Class827();

        private Class827()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          ((DxfDimension.Aligned) owner).DimensionLineLocation = value;
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Aligned) owner).DimensionLineLocation;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Aligned_DimensionLineLocationControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }
    }

    public class Linear : DxfDimension.Aligned
    {
      private double double_6;

      public Linear(DxfDimensionStyle dimensionStyle)
        : base(dimensionStyle)
      {
      }

      protected internal Linear(DxfModel model)
        : base(model)
      {
      }

      public double Rotation
      {
        get
        {
          return this.double_6;
        }
        set
        {
          this.double_6 = value;
        }
      }

      public override string AcClass
      {
        get
        {
          return "AcDbRotatedDimension";
        }
      }

      public override void TransformMe(
        TransformConfig config,
        Matrix4D matrix,
        CommandGroup undoGroup)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfDimension.Linear.Class830 class830 = new DxfDimension.Linear.Class830();
        // ISSUE: reference to a compiler-generated field
        class830.linear_0 = this;
        CommandGroup undoGroup1 = (CommandGroup) null;
        if (undoGroup != null)
        {
          undoGroup1 = new CommandGroup((object) this);
          undoGroup.UndoStack.Push((ICommand) undoGroup1);
        }
        base.TransformMe(config, matrix, undoGroup1);
        // ISSUE: reference to a compiler-generated field
        class830.double_0 = this.double_6;
        Vector2D vector2D = matrix.Transform(new Vector2D(System.Math.Cos(this.double_6), System.Math.Sin(this.double_6)));
        this.double_6 = System.Math.Atan2(vector2D.Y, vector2D.X);
        if (undoGroup1 == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup1.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfDimension.Linear.Class831()
        {
          class830_0 = class830,
          double_0 = this.double_6
        }.method_0), new System.Action(class830.method_0)));
      }

      public override double GetActualMeasurement()
      {
        return this.method_23(base.GetActualMeasurement());
      }

      public override double GetActualAlternateMeasurement()
      {
        return this.method_23(base.GetActualAlternateMeasurement());
      }

      private double method_23(double baseMeasurement)
      {
        Matrix4D wcsToOcsTransform = this.GetWcsToOcsTransform();
        Vector3D v = this.vmethod_14(wcsToOcsTransform);
        double num = baseMeasurement;
        if (num > 8.88178419700125E-16)
        {
          Vector3D vector3D = wcsToOcsTransform.Transform(this.ExtensionLine2StartPoint - this.ExtensionLine1StartPoint);
          num *= System.Math.Abs(Vector3D.DotProduct(vector3D.GetUnit(), v));
        }
        return num;
      }

      public override IGraphCloneable Clone(CloneContext cloneContext)
      {
        DxfDimension.Linear linear = (DxfDimension.Linear) cloneContext.GetExistingClone((IGraphCloneable) this);
        if (linear == null)
        {
          linear = new DxfDimension.Linear(cloneContext.TargetModel);
          cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) linear);
          linear.CopyFrom((DxfHandledObject) this, cloneContext);
        }
        return (IGraphCloneable) linear;
      }

      public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
      {
        base.CopyFrom(from, cloneContext);
        this.double_6 = ((DxfDimension.Linear) from).double_6;
      }

      internal override Vector3D vmethod_14(Matrix4D wcsToBcs)
      {
        return new Vector3D(System.Math.Cos(this.double_6), System.Math.Sin(this.double_6), 0.0);
      }

      public override void Accept(IEntityVisitor visitor)
      {
        visitor.Visit(this);
      }

      internal override short vmethod_6(Class432 w)
      {
        return 21;
      }
    }

    public class Diametric : DxfDimension, IControlPointCollection
    {
      private static readonly IControlPoint[] icontrolPoint_0 = new IControlPoint[2]{ DxfDimension.Diametric.Class832.icontrolPoint_0, DxfDimension.Diametric.Class833.icontrolPoint_0 };
      private WW.Math.Point3D point3D_2;
      private WW.Math.Point3D point3D_3;
      private double double_5;

      public Diametric(DxfDimensionStyle dimensionStyle)
        : base(dimensionStyle)
      {
      }

      protected internal Diametric(DxfModel model)
        : base(model)
      {
      }

      public WW.Math.Point3D ArcLineIntersectionPoint1
      {
        get
        {
          if (!this.IsAnnotative)
            return this.point3D_2;
          DxfDimensionObjectContextData.Diametric diametric = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfDimensionObjectContextData.Diametric;
          if (diametric != null)
            return diametric.ArcLineIntersectionPoint1;
          return this.point3D_2;
        }
        set
        {
          if (!this.IsAnnotative)
          {
            this.point3D_2 = value;
          }
          else
          {
            DxfDimensionObjectContextData.Diametric diametric = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfDimensionObjectContextData.Diametric;
            if (diametric != null)
              diametric.ArcLineIntersectionPoint1 = value;
            if (diametric != null && !diametric.IsDefault)
              return;
            this.point3D_2 = value;
          }
        }
      }

      public WW.Math.Point3D ArcLineIntersectionPoint2
      {
        get
        {
          if (!this.IsAnnotative)
            return this.point3D_3;
          DxfDimensionObjectContextData.Diametric diametric = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfDimensionObjectContextData.Diametric;
          if (diametric != null)
            return diametric.ArcLineIntersectionPoint2;
          return this.point3D_3;
        }
        set
        {
          if (!this.IsAnnotative)
          {
            this.point3D_3 = value;
          }
          else
          {
            DxfDimensionObjectContextData.Diametric diametric = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfDimensionObjectContextData.Diametric;
            if (diametric != null)
              diametric.ArcLineIntersectionPoint2 = value;
            if (diametric != null && !diametric.IsDefault)
              return;
            this.point3D_3 = value;
          }
        }
      }

      public double LeaderLength
      {
        get
        {
          return this.double_5;
        }
        set
        {
          this.double_5 = value;
        }
      }

      public override string AcClass
      {
        get
        {
          return "AcDbDiametricDimension";
        }
      }

      public override void TransformMe(
        TransformConfig config,
        Matrix4D matrix,
        CommandGroup undoGroup)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfDimension.Diametric.Class834 class834 = new DxfDimension.Diametric.Class834();
        // ISSUE: reference to a compiler-generated field
        class834.diametric_0 = this;
        CommandGroup undoGroup1 = (CommandGroup) null;
        if (undoGroup != null)
        {
          undoGroup1 = new CommandGroup((object) this);
          undoGroup.UndoStack.Push((ICommand) undoGroup1);
        }
        base.TransformMe(config, matrix, undoGroup1);
        // ISSUE: reference to a compiler-generated field
        class834.point3D_0 = this.point3D_2;
        // ISSUE: reference to a compiler-generated field
        class834.point3D_1 = this.point3D_3;
        // ISSUE: reference to a compiler-generated field
        class834.double_0 = this.double_5;
        this.point3D_2 = matrix.Transform(this.point3D_2);
        this.point3D_3 = matrix.Transform(this.point3D_3);
        this.double_5 = matrix.Transform(new Vector2D(this.double_5, 0.0)).GetLength();
        if (undoGroup1 == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup1.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfDimension.Diametric.Class835()
        {
          class834_0 = class834,
          point3D_0 = this.point3D_2,
          point3D_1 = this.point3D_3,
          double_0 = this.double_5
        }.method_0), new System.Action(class834.method_0)));
      }

      public override void GenerateBlock()
      {
        base.GenerateBlock();
        DxfModel model = this.Model;
        if (model == null)
          throw new DxfException("Cannot generate dimension block, dimension is not part of a model.");
        Matrix4D matrix4D = this.method_21();
        WW.Math.Point3D point3D1 = matrix4D.Transform(this.ArcLineIntersectionPoint1);
        WW.Math.Point3D point3D2 = matrix4D.Transform(this.ArcLineIntersectionPoint2);
        WW.Math.Point3D midPoint = WW.Math.Point3D.GetMidPoint(point3D2, point3D1);
        Vector3D vector3D1 = point3D2 - point3D1;
        double length = vector3D1.GetLength();
        DxfDimensionStyleOverrides effectiveDimensionStyle = this.GetEffectiveDimensionStyle(model);
        bool textAlignedWithDimensionLine = false;
        double num1;
        if (this.HasTextRotation)
          num1 = this.TextRotation;
        else if (effectiveDimensionStyle.TextInsideHorizontal)
        {
          num1 = 0.0;
        }
        else
        {
          num1 = System.Math.Atan2(vector3D1.Y, vector3D1.X);
          textAlignedWithDimensionLine = true;
        }
        Vector2D vector2D = new Vector2D(System.Math.Cos(num1), System.Math.Sin(num1));
        if (vector2D.X < 0.0)
          vector2D = -vector2D;
        DxfPoint dxfPoint1 = new DxfPoint(point3D1);
        dxfPoint1.Color = EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor);
        dxfPoint1.Layer = model.method_14();
        this.Block.Entities.Add((DxfEntity) dxfPoint1);
        DxfPoint dxfPoint2 = new DxfPoint(point3D2);
        dxfPoint2.Color = EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor);
        dxfPoint2.Layer = dxfPoint1.Layer;
        this.Block.Entities.Add((DxfEntity) dxfPoint2);
        Vector3D unit = vector3D1.GetUnit();
        Vector3D vector3D2 = Vector3D.CrossProduct(Vector3D.ZAxis, unit);
        WW.Math.Point3D point3D3 = midPoint;
        double arrowSize = DxfDimension.GetArrowSize(effectiveDimensionStyle);
        bool arrowsFitInsideExtensionLines = length > 2.0 * arrowSize && effectiveDimensionStyle.TextOutsideExtensions;
        string text = this.GetText(effectiveDimensionStyle);
        if (text == null)
          return;
        DxfMText textEntity = DxfDimension.smethod_11(model, text, point3D3, (Vector3D) vector2D, this.attachmentPoint_0, effectiveDimensionStyle);
        DxfDimension.Radial.smethod_21(textAlignedWithDimensionLine, effectiveDimensionStyle, textEntity, vector3D2, midPoint, point3D3);
        this.Block.Entities.Add((DxfEntity) textEntity);
        Class976 class976 = new Class976(textEntity.TextBounds, textEntity.Transform);
        double num2 = System.Math.Abs(Vector3D.DotProduct(class976.Dx, unit)) + System.Math.Abs(Vector3D.DotProduct(class976.Dy, unit));
        double num3 = length - 2.0 * arrowSize;
        if (!this.UseTextMiddlePoint && num3 < num2)
        {
          double num4 = this.HasTextRotation ? this.TextRotation : (effectiveDimensionStyle.TextOutsideHorizontal ? 0.0 : System.Math.Atan2(vector3D1.Y, vector3D1.X));
          vector2D = new Vector2D(System.Math.Cos(num4), System.Math.Sin(num4));
          if (vector2D.X < 0.0)
            vector2D = -vector2D;
          bool textLeft = point3D2.X > point3D1.X;
          WW.Math.Point3D leaderLine2StartPoint;
          DxfDimension.smethod_13(model, this.Block, point3D1, -unit, this.double_5 == 0.0 ? arrowSize : this.double_5, effectiveDimensionStyle, class976.Dx.GetLength(), textLeft, arrowsFitInsideExtensionLines, false, out leaderLine2StartPoint);
          WW.Math.Point3D point3D4 = leaderLine2StartPoint + Vector3D.XAxis * arrowSize * (textLeft ? -1.0 : 1.0) + DxfDimension.smethod_15(effectiveDimensionStyle) * (textLeft ? -1.0 : 1.0) * Vector3D.XAxis;
          if (effectiveDimensionStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Above)
            point3D4 += DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimensionStyle) * Vector3D.YAxis;
          textEntity.InsertionPoint = point3D4;
          textEntity.XAxis = (Vector3D) vector2D;
          textEntity.AttachmentPoint = textLeft ? AttachmentPoint.MiddleRight : AttachmentPoint.MiddleLeft;
          this.DrawCross(this.Block, midPoint, EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor), DxfDimension.GetArrowSize(effectiveDimensionStyle));
          this.Block.Entities.Add(DxfDimension.smethod_16(new bool?(), point3D1, unit, vector3D2, effectiveDimensionStyle, out arrowSize));
        }
        else
        {
          this.Block.Entities.Add(DxfDimension.smethod_16(new bool?(), point3D1, -unit, vector3D2, effectiveDimensionStyle, out arrowSize));
          this.Block.Entities.Add(DxfDimension.smethod_16(new bool?(), point3D2, unit, vector3D2, effectiveDimensionStyle, out arrowSize));
          if (!this.bool_3 && !effectiveDimensionStyle.TextInsideHorizontal && effectiveDimensionStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Above)
          {
            DxfLine dxfLine = new DxfLine(EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor), point3D1, point3D2);
            dxfLine.LineWeight = effectiveDimensionStyle.DimensionLineWeight;
            this.Block.Entities.Add((DxfEntity) dxfLine);
          }
          else
          {
            foreach (DxfEntity dxfEntity in DxfDimension.smethod_18(effectiveDimensionStyle, point3D1, point3D2, class976.Origin, class976.Dx, class976.Dy))
              this.Block.Entities.Add(dxfEntity);
          }
        }
      }

      public override void DrawInternal(
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        if (context.Config.ShowDimensionDefinitionPoints)
        {
          IClippingTransformer transformer = context.GetTransformer();
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_2), ArgbColors.Yellow);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_3), ArgbColors.Orange);
        }
        base.DrawInternal(context, graphicsFactory);
      }

      public override void DrawInternal(
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        if (context.Config.ShowDimensionDefinitionPoints)
        {
          IClippingTransformer transformer = context.GetTransformer();
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_2), ArgbColors.Yellow);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_3), ArgbColors.Orange);
        }
        base.DrawInternal(context, graphicsFactory);
      }

      public override double GetActualMeasurement()
      {
        return this.GetLinearScaleFactor(this.GetEffectiveDimensionStyle()) * (this.point3D_3 - this.point3D_2).GetLength();
      }

      public override double GetActualAlternateMeasurement()
      {
        return this.GetAlternateScaleFactor(this.GetEffectiveDimensionStyle()) * (this.point3D_3 - this.point3D_2).GetLength();
      }

      public override IGraphCloneable Clone(CloneContext cloneContext)
      {
        DxfDimension.Diametric diametric = (DxfDimension.Diametric) cloneContext.GetExistingClone((IGraphCloneable) this);
        if (diametric == null)
        {
          diametric = new DxfDimension.Diametric(cloneContext.TargetModel);
          cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) diametric);
          diametric.CopyFrom((DxfHandledObject) this, cloneContext);
        }
        return (IGraphCloneable) diametric;
      }

      public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
      {
        base.CopyFrom(from, cloneContext);
        DxfDimension.Diametric diametric = (DxfDimension.Diametric) from;
        this.point3D_2 = diametric.point3D_2;
        this.point3D_3 = diametric.point3D_3;
        this.double_5 = diametric.double_5;
      }

      public override void Accept(IEntityVisitor visitor)
      {
        visitor.Visit(this);
      }

      internal override string MeasurementPrefix
      {
        get
        {
          return 'Ø'.ToString();
        }
      }

      public override IControlPointCollection InteractionControlPoints
      {
        get
        {
          return (IControlPointCollection) this;
        }
      }

      void IControlPointCollection.Set(int index, WW.Math.Point3D value)
      {
        DxfDimension.Diametric.icontrolPoint_0[index].SetValue((object) this, value);
      }

      WW.Math.Point3D IControlPointCollection.Get(int index)
      {
        return DxfDimension.Diametric.icontrolPoint_0[index].GetValue((object) this);
      }

      string IControlPointCollection.GetDescription(int index)
      {
        return DxfDimension.Diametric.icontrolPoint_0[index].Description;
      }

      PointDisplayType IControlPointCollection.GetDisplayType(
        int index)
      {
        return DxfDimension.Diametric.icontrolPoint_0[index].DisplayType;
      }

      int IControlPointCollection.Count
      {
        get
        {
          return DxfDimension.Diametric.icontrolPoint_0.Length;
        }
      }

      bool IControlPointCollection.IsCountFixed
      {
        get
        {
          return true;
        }
      }

      void IControlPointCollection.Insert(int index)
      {
        throw new NotSupportedException();
      }

      void IControlPointCollection.RemoveAt(int index)
      {
        throw new NotSupportedException();
      }

      internal override short vmethod_6(Class432 w)
      {
        return 26;
      }

      public override DxfAnnotationScaleObjectContextData CreateContextData(
        DxfScale scale)
      {
        return (DxfAnnotationScaleObjectContextData) new DxfDimensionObjectContextData.Diametric(this, scale);
      }

      private class Class832 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Diametric.Class832();

        private Class832()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          ((DxfDimension.Diametric) owner).point3D_2 = value;
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Diametric) owner).point3D_2;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Diametric_ArcLineIntersectionPoint1ControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }

      private class Class833 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Diametric.Class833();

        private Class833()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          ((DxfDimension.Diametric) owner).point3D_3 = value;
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Diametric) owner).point3D_3;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Diametric_ArcLineIntersectionPoint2ControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }
    }

    public class Radial : DxfDimension, IControlPointCollection
    {
      private static readonly IControlPoint[] icontrolPoint_0 = new IControlPoint[2]{ DxfDimension.Radial.Class836.icontrolPoint_0, DxfDimension.Radial.Class837.icontrolPoint_0 };
      private WW.Math.Point3D point3D_2;
      private WW.Math.Point3D point3D_3;
      private double double_5;

      public Radial(DxfDimensionStyle dimensionStyle)
        : base(dimensionStyle)
      {
      }

      protected internal Radial(DxfModel model)
        : base(model)
      {
      }

      public WW.Math.Point3D ArcLineIntersectionPoint
      {
        get
        {
          if (!this.IsAnnotative)
            return this.point3D_3;
          DxfDimensionObjectContextData.Radial radial = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfDimensionObjectContextData.Radial;
          if (radial != null)
            return radial.ArcLineIntersectionPoint;
          return this.point3D_3;
        }
        set
        {
          if (!this.IsAnnotative)
          {
            this.point3D_3 = value;
          }
          else
          {
            DxfDimensionObjectContextData.Radial radial = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfDimensionObjectContextData.Radial;
            if (radial != null)
              radial.ArcLineIntersectionPoint = value;
            if (radial != null && !radial.IsDefault)
              return;
            this.point3D_3 = value;
          }
        }
      }

      public WW.Math.Point3D Center
      {
        get
        {
          return this.point3D_2;
        }
        set
        {
          this.point3D_2 = value;
        }
      }

      public double LeaderLength
      {
        get
        {
          return this.double_5;
        }
        set
        {
          this.double_5 = value;
        }
      }

      public override string AcClass
      {
        get
        {
          return "AcDbRadialDimension";
        }
      }

      public override void TransformMe(
        TransformConfig config,
        Matrix4D matrix,
        CommandGroup undoGroup)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfDimension.Radial.Class839 class839 = new DxfDimension.Radial.Class839();
        // ISSUE: reference to a compiler-generated field
        class839.radial_0 = this;
        CommandGroup undoGroup1 = (CommandGroup) null;
        if (undoGroup != null)
        {
          undoGroup1 = new CommandGroup((object) this);
          undoGroup.UndoStack.Push((ICommand) undoGroup1);
        }
        base.TransformMe(config, matrix, undoGroup1);
        // ISSUE: reference to a compiler-generated field
        class839.point3D_0 = this.point3D_3;
        // ISSUE: reference to a compiler-generated field
        class839.point3D_1 = this.point3D_2;
        // ISSUE: reference to a compiler-generated field
        class839.double_0 = this.double_5;
        this.point3D_3 = matrix.Transform(this.point3D_3);
        this.point3D_2 = matrix.Transform(this.point3D_2);
        this.double_5 = matrix.Transform(new Vector2D(this.double_5, 0.0)).GetLength();
        if (undoGroup1 == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup1.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfDimension.Radial.Class840()
        {
          class839_0 = class839,
          point3D_0 = this.point3D_3,
          point3D_1 = this.point3D_2,
          double_0 = this.double_5
        }.method_0), new System.Action(class839.method_0)));
      }

      public override void DrawInternal(
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        if (context.Config.ShowDimensionDefinitionPoints)
        {
          IClippingTransformer transformer = context.GetTransformer();
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_2), ArgbColors.Yellow);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_3), ArgbColors.Orange);
        }
        base.DrawInternal(context, graphicsFactory);
      }

      public override void DrawInternal(
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        if (context.Config.ShowDimensionDefinitionPoints)
        {
          IClippingTransformer transformer = context.GetTransformer();
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_2), ArgbColors.Yellow);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_3), ArgbColors.Orange);
        }
        base.DrawInternal(context, graphicsFactory);
      }

      public override void GenerateBlock()
      {
        base.GenerateBlock();
        DxfModel model = this.Model;
        if (model == null)
          throw new DxfException("Cannot generate dimension block, dimension is not part of a model.");
        Matrix4D matrix4D = this.method_21();
        WW.Math.Point3D point3D1 = matrix4D.Transform(this.point3D_2);
        WW.Math.Point3D point3D2 = matrix4D.Transform(this.ArcLineIntersectionPoint);
        WW.Math.Point3D point3D3 = WW.Math.Point3D.GetMidPoint(point3D1, point3D2);
        Vector3D vector3D1 = point3D2 - point3D1;
        double length = vector3D1.GetLength();
        Vector3D vector3D2 = vector3D1 == Vector3D.Zero ? Vector3D.XAxis : vector3D1 / length;
        Vector3D vector3D3 = Vector3D.CrossProduct(Vector3D.ZAxis, vector3D2);
        DxfDimensionStyleOverrides effectiveDimensionStyle = this.GetEffectiveDimensionStyle(model);
        bool textAlignedWithDimensionLine = false;
        double num1;
        if (this.HasTextRotation)
          num1 = this.TextRotation;
        else if (effectiveDimensionStyle.TextInsideHorizontal)
        {
          num1 = 0.0;
        }
        else
        {
          num1 = System.Math.Atan2(vector3D1.Y, vector3D1.X);
          textAlignedWithDimensionLine = true;
        }
        Vector2D a1 = new Vector2D(System.Math.Cos(num1), System.Math.Sin(num1));
        if (a1.X < 0.0)
          a1 = -a1;
        bool dontDrawLeaderSecondSegment = false;
        bool useTextMiddlePoint;
        if (useTextMiddlePoint = this.UseTextMiddlePoint)
        {
          point3D3 = this.TextMiddlePoint;
          double num2 = Vector3D.DotProduct(vector3D2, point3D3 - point3D1);
          if (textAlignedWithDimensionLine)
            point3D3 = point3D1 + num2 * vector3D2;
          if ((double) System.Math.Sign(num2) < 0.0)
            vector3D3 = -vector3D3;
          Vector2D b = new Vector2D(vector3D2.X, vector3D2.Y);
          double num3 = System.Math.Abs(Vector2D.GetAngle(a1, b));
          if (num3 < System.Math.PI / 18.0 || num3 > 17.0 * System.Math.PI / 18.0)
            dontDrawLeaderSecondSegment = true;
        }
        string text = this.GetText(effectiveDimensionStyle);
        if (text == null)
          return;
        DxfMText textEntity = DxfDimension.smethod_11(model, text, point3D3, (Vector3D) a1, this.attachmentPoint_0, effectiveDimensionStyle);
        DxfDimension.Radial.smethod_21(textAlignedWithDimensionLine, effectiveDimensionStyle, textEntity, vector3D3, point3D1, point3D3);
        this.Block.Entities.Add((DxfEntity) textEntity);
        double arrowSize = DxfDimension.GetArrowSize(effectiveDimensionStyle);
        Class976 class976 = new Class976(textEntity.TextBounds, textEntity.Transform);
        Vector2D unit = (Vector2D) class976.Dy.GetUnit();
        double num4 = System.Math.Abs(Vector3D.DotProduct(class976.Dx, vector3D2)) + System.Math.Abs(Vector3D.DotProduct(class976.Dy, vector3D2));
        double num5 = length - arrowSize;
        WW.Math.Point2D point2D = effectiveDimensionStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Above ? (WW.Math.Point2D) class976.Center - DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimensionStyle) * unit : (WW.Math.Point2D) class976.Center;
        bool flag1 = Vector2D.DotProduct((Vector2D) class976.Dy, point2D - (WW.Math.Point2D) point3D1) > 8.88178419700125E-16;
        bool flag2 = Vector2D.DotProduct((Vector2D) class976.Dy, (WW.Math.Point2D) point3D2 - (WW.Math.Point2D) point3D1) > 8.88178419700125E-16;
        double num6 = Vector2D.DotProduct(unit, point2D - (WW.Math.Point2D) point3D2);
        double num7 = Vector2D.DotProduct(unit, (Vector2D) vector3D2);
        double num8 = arrowSize;
        if (!textAlignedWithDimensionLine && System.Math.Abs(num7) > 0.2)
        {
          num8 = num6 / num7 - arrowSize;
        }
        else
        {
          dontDrawLeaderSecondSegment = true;
          Line2D a2 = new Line2D((WW.Math.Point2D) point3D1, (Vector2D) vector3D2);
          double num2 = double.MaxValue;
          double num3 = length + arrowSize + effectiveDimensionStyle.DimensionLineGap;
          Line2D b1 = new Line2D((WW.Math.Point2D) class976.Origin, (Vector2D) class976.Dy);
          WW.Math.Point2D? intersection1 = Line2D.GetIntersection(a2, b1);
          if (intersection1.HasValue)
          {
            double num9 = Vector2D.DotProduct(intersection1.Value - (WW.Math.Point2D) point3D1, (Vector2D) vector3D2);
            if (num9 > num3 && num9 < num2)
            {
              num2 = num9;
              num8 = num2 - num3;
            }
          }
          Line2D b2 = new Line2D((WW.Math.Point2D) class976.Origin + (Vector2D) class976.Dx, (Vector2D) class976.Dy);
          WW.Math.Point2D? intersection2 = Line2D.GetIntersection(a2, b2);
          if (intersection2.HasValue)
          {
            double num9 = Vector2D.DotProduct(intersection2.Value - (WW.Math.Point2D) point3D1, (Vector2D) vector3D2);
            if (num9 > num3 && num9 < num2)
              num8 = num9 - num3;
          }
        }
        if (!textAlignedWithDimensionLine && (useTextMiddlePoint && (flag1 == flag2 && num8 > 0.0 || flag1 != flag2) || !useTextMiddlePoint && num5 < num4))
        {
          double num2 = this.HasTextRotation ? this.TextRotation : (effectiveDimensionStyle.TextOutsideHorizontal ? 0.0 : System.Math.Atan2(vector3D1.Y, vector3D1.X));
          a1 = new Vector2D(System.Math.Cos(num2), System.Math.Sin(num2));
          if (!useTextMiddlePoint && a1.X < 0.0)
            a1 = -a1;
          Vector3D vector3D4 = Vector3D.Zero;
          double leaderLength = this.double_5 == 0.0 ? arrowSize : this.double_5;
          bool arrowsFitInsideExtensionLines = length > arrowSize && effectiveDimensionStyle.TextOutsideExtensions;
          bool textLeft = !useTextMiddlePoint && point3D2.X < point3D1.X;
          if (useTextMiddlePoint)
          {
            if (flag1 == flag2)
            {
              leaderLength = num8;
              textLeft = Vector2D.DotProduct((Vector2D) class976.Dx, (WW.Math.Point2D) point3D2 - (WW.Math.Point2D) point3D1) >= Vector2D.DotProduct((Vector2D) class976.Dx, (WW.Math.Point2D) this.TextMiddlePoint - (WW.Math.Point2D) point3D1);
            }
            else
              dontDrawLeaderSecondSegment = true;
          }
          if (!dontDrawLeaderSecondSegment)
            vector3D4 = Vector3D.XAxis * arrowSize * (textLeft ? -1.0 : 1.0);
          WW.Math.Point3D leaderLine2StartPoint;
          DxfDimension.smethod_13(model, this.Block, point3D2, vector3D2, leaderLength, effectiveDimensionStyle, class976.Dx.GetLength(), textLeft, arrowsFitInsideExtensionLines, dontDrawLeaderSecondSegment, out leaderLine2StartPoint);
          if (!useTextMiddlePoint)
          {
            WW.Math.Point3D point3D4 = leaderLine2StartPoint + vector3D4 + DxfDimension.smethod_15(effectiveDimensionStyle) * (textLeft ? -1.0 : 1.0) * Vector3D.XAxis;
            if (effectiveDimensionStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Above)
              point3D4 += (Vector3D) (DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimensionStyle) * unit);
            textEntity.InsertionPoint = point3D4;
            textEntity.XAxis = (Vector3D) a1;
          }
          if (!useTextMiddlePoint)
            textEntity.AttachmentPoint = textLeft ? AttachmentPoint.MiddleRight : AttachmentPoint.MiddleLeft;
          this.DrawCross(this.Block, point3D1, EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor), 2.0 * effectiveDimensionStyle.ScaleFactor * effectiveDimensionStyle.CenterMarkSize);
          this.Block.Entities.Add(DxfDimension.smethod_16(new bool?(), point3D2, -vector3D2, vector3D3, effectiveDimensionStyle, out arrowSize));
        }
        else
        {
          if (useTextMiddlePoint && Vector3D.DotProduct(vector3D2, this.point3D_1 - point3D1) > 0.0)
            vector3D2 = -vector3D2;
          WW.Math.Point3D point3D4 = point3D1;
          WW.Math.Point3D point3D5 = point3D2;
          if (textAlignedWithDimensionLine && !effectiveDimensionStyle.TextInsideExtensions)
          {
            if (effectiveDimensionStyle.TextVerticalAlignment != DimensionTextVerticalAlignment.Centered)
            {
              double num2 = class976.method_0(point3D1, -vector3D2) + DxfDimension.smethod_15(effectiveDimensionStyle);
              point3D5 = point3D1 - num2 * vector3D2;
            }
            else
            {
              double num2 = class976.method_0(point3D1, vector3D2) - DxfDimension.smethod_15(effectiveDimensionStyle);
              point3D5 = point3D1 + num2 * vector3D2;
            }
          }
          this.Block.Entities.Add(DxfDimension.smethod_16(new bool?(), point3D2, vector3D2, vector3D3, effectiveDimensionStyle, out arrowSize));
          if (!this.HasTextRotation && !effectiveDimensionStyle.TextInsideHorizontal && (!textAlignedWithDimensionLine || effectiveDimensionStyle.TextVerticalAlignment != DimensionTextVerticalAlignment.Centered))
          {
            DxfLine dxfLine = new DxfLine(EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor), point3D4, point3D5);
            dxfLine.LineWeight = effectiveDimensionStyle.DimensionLineWeight;
            this.Block.Entities.Add((DxfEntity) dxfLine);
          }
          else
          {
            foreach (DxfEntity dxfEntity in DxfDimension.smethod_18(effectiveDimensionStyle, point3D4, point3D5, class976.Origin, class976.Dx, class976.Dy))
              this.Block.Entities.Add(dxfEntity);
          }
        }
      }

      internal static void smethod_21(
        bool textAlignedWithDimensionLine,
        DxfDimensionStyleOverrides effectiveDimStyle,
        DxfMText textEntity,
        Vector3D dimensionLineNormal,
        WW.Math.Point3D centerOcs,
        WW.Math.Point3D textPosition)
      {
        Vector3D unit = Vector3D.CrossProduct(textEntity.ZAxis, textEntity.XAxis).GetUnit();
        if (textAlignedWithDimensionLine)
        {
          if (effectiveDimStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Above)
          {
            Vector3D vector3D = ((1.0 - DxfDimension.Class859.smethod_0(textEntity)) * DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimStyle) + DxfDimension.smethod_15(effectiveDimStyle)) * unit;
            textPosition += vector3D;
          }
          else if (effectiveDimStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Below)
          {
            Vector3D vector3D = (DxfDimension.Class859.smethod_0(textEntity) * DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimStyle) + DxfDimension.smethod_15(effectiveDimStyle)) * unit;
            textPosition -= vector3D;
          }
          else
          {
            Vector3D vector3D = (0.5 - DxfDimension.Class859.smethod_0(textEntity)) * DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimStyle) * unit;
            textPosition += vector3D;
          }
          textEntity.InsertionPoint = textPosition;
        }
        else
        {
          Vector3D vector3D = (0.5 - DxfDimension.Class859.smethod_0(textEntity)) * DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimStyle) * unit;
          textPosition += vector3D;
          textEntity.InsertionPoint = textPosition;
        }
      }

      public void HandleControlPointChange()
      {
        if (this.Measurement != 0.0)
          this.Measurement = this.GetActualMeasurement();
        if (!this.bool_2)
          return;
        DxfModel model = this.Model;
        if (model == null)
          throw new DxfException("Cannot update TextMiddlePoint, dimension is not part of a model.");
        Matrix4D matrix4D = this.method_21();
        WW.Math.Point3D a = matrix4D.Transform(this.point3D_2);
        WW.Math.Point3D point3D1 = matrix4D.Transform(this.point3D_3);
        WW.Math.Point3D position = WW.Math.Point3D.GetMidPoint(a, point3D1);
        Vector3D direction = point3D1 - a;
        double length = direction.GetLength();
        Vector3D vector3D1 = direction == Vector3D.Zero ? Vector3D.XAxis : direction / length;
        Vector3D vector3D2 = Vector3D.CrossProduct(Vector3D.ZAxis, vector3D1);
        DxfDimensionStyleOverrides effectiveDimensionStyle = this.GetEffectiveDimensionStyle(model);
        double num1 = this.bool_3 ? this.double_3 : (effectiveDimensionStyle.TextInsideHorizontal ? 0.0 : System.Math.Atan2(direction.Y, direction.X));
        Vector2D vector2D = new Vector2D(System.Math.Cos(num1), System.Math.Sin(num1));
        if (vector2D.X < 0.0)
          vector2D = -vector2D;
        bool dontDrawLeaderSecondSegment = false;
        string text = this.GetText(effectiveDimensionStyle);
        if (text == null)
          return;
        DxfMText dxfMtext = DxfDimension.smethod_11(model, text, position, direction, this.attachmentPoint_0, effectiveDimensionStyle);
        if (effectiveDimensionStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Above)
        {
          Vector3D vector3D3 = DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimensionStyle) * vector3D2;
          int num2 = a.X < point3D1.X ? 1 : -1;
          position += vector3D3 * (double) num2;
        }
        dxfMtext.XAxis = (Vector3D) vector2D;
        double arrowSize = DxfDimension.GetArrowSize(effectiveDimensionStyle);
        Class976 class976 = new Class976(dxfMtext.TextBounds, dxfMtext.Transform);
        Vector2D unit = (Vector2D) class976.Dy.GetUnit();
        double num3 = System.Math.Abs(Vector3D.DotProduct(class976.Dx, vector3D1)) + System.Math.Abs(Vector3D.DotProduct(class976.Dy, vector3D1));
        if (length - arrowSize < num3)
        {
          double num2 = this.bool_3 ? this.double_3 : (effectiveDimensionStyle.TextOutsideHorizontal ? 0.0 : System.Math.Atan2(direction.Y, direction.X));
          vector2D = new Vector2D(System.Math.Cos(num2), System.Math.Sin(num2));
          if (vector2D.X < 0.0)
            vector2D = -vector2D;
          Vector3D vector3D3 = Vector3D.Zero;
          bool textLeft = point3D1.X < a.X;
          if (!dontDrawLeaderSecondSegment)
            vector3D3 = Vector3D.XAxis * arrowSize * (textLeft ? -1.0 : 1.0);
          double leaderLength = this.double_5 == 0.0 ? arrowSize : this.double_5;
          bool arrowsFitInsideExtensionLines = length > arrowSize && effectiveDimensionStyle.TextOutsideExtensions;
          WW.Math.Point3D leaderLine2StartPoint;
          DxfDimension.smethod_13(model, (DxfBlock) null, point3D1, vector3D1, leaderLength, effectiveDimensionStyle, class976.Dx.GetLength(), textLeft, arrowsFitInsideExtensionLines, dontDrawLeaderSecondSegment, out leaderLine2StartPoint);
          WW.Math.Point3D point3D2 = leaderLine2StartPoint + vector3D3 + DxfDimension.smethod_15(effectiveDimensionStyle) * (textLeft ? -1.0 : 1.0) * Vector3D.XAxis;
          if (effectiveDimensionStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Above)
            point3D2 += (Vector3D) (DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimensionStyle) * unit);
          position = point3D2 + (textLeft ? -1.0 : 1.0) * 0.5 * class976.Dx;
        }
        this.point3D_1 = position;
      }

      public override double GetActualMeasurement()
      {
        return this.GetLinearScaleFactor(this.GetEffectiveDimensionStyle()) * (this.point3D_3 - this.point3D_2).GetLength();
      }

      public override double GetActualAlternateMeasurement()
      {
        return this.GetAlternateScaleFactor(this.GetEffectiveDimensionStyle()) * (this.point3D_3 - this.point3D_2).GetLength();
      }

      public override IGraphCloneable Clone(CloneContext cloneContext)
      {
        DxfDimension.Radial radial = (DxfDimension.Radial) cloneContext.GetExistingClone((IGraphCloneable) this);
        if (radial == null)
        {
          radial = new DxfDimension.Radial(cloneContext.TargetModel);
          cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) radial);
          radial.CopyFrom((DxfHandledObject) this, cloneContext);
        }
        return (IGraphCloneable) radial;
      }

      public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
      {
        base.CopyFrom(from, cloneContext);
        DxfDimension.Radial radial = (DxfDimension.Radial) from;
        this.point3D_2 = radial.point3D_2;
        this.point3D_3 = radial.point3D_3;
        this.double_5 = radial.double_5;
      }

      public override void Accept(IEntityVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override IControlPointCollection InteractionControlPoints
      {
        get
        {
          return (IControlPointCollection) this;
        }
      }

      internal override string MeasurementPrefix
      {
        get
        {
          return "R";
        }
      }

      public override DxfEntity.Interactor CreateEditInteractor()
      {
        return (DxfEntity.Interactor) new DxfDimension.Radial.Class12(this);
      }

      void IControlPointCollection.Set(int index, WW.Math.Point3D value)
      {
        DxfDimension.Radial.icontrolPoint_0[index].SetValue((object) this, value);
      }

      WW.Math.Point3D IControlPointCollection.Get(int index)
      {
        return DxfDimension.Radial.icontrolPoint_0[index].GetValue((object) this);
      }

      string IControlPointCollection.GetDescription(int index)
      {
        return DxfDimension.Radial.icontrolPoint_0[index].Description;
      }

      PointDisplayType IControlPointCollection.GetDisplayType(
        int index)
      {
        return DxfDimension.Radial.icontrolPoint_0[index].DisplayType;
      }

      int IControlPointCollection.Count
      {
        get
        {
          return DxfDimension.Radial.icontrolPoint_0.Length;
        }
      }

      bool IControlPointCollection.IsCountFixed
      {
        get
        {
          return true;
        }
      }

      void IControlPointCollection.Insert(int index)
      {
        throw new NotSupportedException();
      }

      void IControlPointCollection.RemoveAt(int index)
      {
        throw new NotSupportedException();
      }

      internal override short vmethod_6(Class432 w)
      {
        return 25;
      }

      public override DxfAnnotationScaleObjectContextData CreateContextData(
        DxfScale scale)
      {
        return (DxfAnnotationScaleObjectContextData) new DxfDimensionObjectContextData.Radial(this, scale);
      }

      private class Class836 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Radial.Class836();

        private Class836()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          DxfDimension.Radial radial = (DxfDimension.Radial) owner;
          radial.point3D_2 = value;
          radial.HandleControlPointChange();
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Radial) owner).point3D_2;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Radial_CenterControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }

      private class Class837 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Radial.Class837();

        private Class837()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          DxfDimension.Radial radial = (DxfDimension.Radial) owner;
          radial.point3D_3 = value;
          radial.HandleControlPointChange();
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Radial) owner).point3D_3;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Radial_ArcLineIntersectionPointControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }

      private class Class12 : DxfEntity.DefaultEditInteractor
      {
        private DxfDimension.Radial.Class12.Class838 class838_0;

        public Class12(DxfDimension.Radial dimension)
          : base((DxfEntity) dimension)
        {
          this.class838_0 = new DxfDimension.Radial.Class12.Class838(dimension);
        }

        protected override System.Action CreateUndoAction(
          int controlPointIndex,
          WW.Math.Point3D originalOcsPoint)
        {
          return (System.Action) (() => this.class838_0.method_0());
        }

        private class Class838
        {
          private DxfDimension.Radial radial_0;
          private WW.Math.Point3D point3D_0;
          private WW.Math.Point3D point3D_1;
          private double double_0;
          private WW.Math.Point3D point3D_2;
          private bool bool_0;

          public Class838(DxfDimension.Radial dimension)
          {
            this.radial_0 = dimension;
            this.point3D_0 = dimension.point3D_2;
            this.point3D_1 = dimension.point3D_3;
            this.double_0 = dimension.double_2;
            this.point3D_2 = dimension.point3D_1;
            this.bool_0 = dimension.bool_2;
          }

          public void method_0()
          {
            this.radial_0.point3D_2 = this.point3D_0;
            this.radial_0.point3D_3 = this.point3D_1;
            this.radial_0.double_2 = this.double_0;
            this.radial_0.point3D_1 = this.point3D_2;
            this.radial_0.bool_2 = this.bool_0;
          }
        }
      }
    }

    public class Angular3Point : DxfDimension, IControlPointCollection
    {
      private static readonly IControlPoint[] icontrolPoint_0 = new IControlPoint[4]{ DxfDimension.Angular3Point.Class841.icontrolPoint_0, DxfDimension.Angular3Point.Class842.icontrolPoint_0, DxfDimension.Angular3Point.Class843.icontrolPoint_0, DxfDimension.Angular3Point.Class844.icontrolPoint_0 };
      private WW.Math.Point3D point3D_2;
      private WW.Math.Point3D point3D_3;
      private WW.Math.Point3D point3D_4;
      private WW.Math.Point3D point3D_5;

      public Angular3Point(DxfDimensionStyle dimensionStyle)
        : base(dimensionStyle)
      {
      }

      protected internal Angular3Point(DxfModel model)
        : base(model)
      {
      }

      public WW.Math.Point3D AngleVertex
      {
        get
        {
          return this.point3D_2;
        }
        set
        {
          this.point3D_2 = value;
        }
      }

      public WW.Math.Point3D ExtensionLine1StartPoint
      {
        get
        {
          return this.point3D_3;
        }
        set
        {
          this.point3D_3 = value;
        }
      }

      public WW.Math.Point3D ExtensionLine2StartPoint
      {
        get
        {
          return this.point3D_4;
        }
        set
        {
          this.point3D_4 = value;
        }
      }

      public WW.Math.Point3D DimensionLineArcPoint
      {
        get
        {
          if (!this.IsAnnotative)
            return this.point3D_5;
          DxfDimensionObjectContextData.Angular angular = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfDimensionObjectContextData.Angular;
          if (angular != null)
            return angular.DimensionLineArcPoint;
          return this.point3D_5;
        }
        set
        {
          if (!this.IsAnnotative)
          {
            this.point3D_5 = value;
          }
          else
          {
            DxfDimensionObjectContextData.Angular angular = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfDimensionObjectContextData.Angular;
            if (angular != null)
              angular.DimensionLineArcPoint = value;
            if (angular != null && !angular.IsDefault)
              return;
            this.point3D_5 = value;
          }
        }
      }

      public override string AcClass
      {
        get
        {
          return "AcDb3PointAngularDimension";
        }
      }

      public override void TransformMe(
        TransformConfig config,
        Matrix4D matrix,
        CommandGroup undoGroup)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfDimension.Angular3Point.Class845 class845 = new DxfDimension.Angular3Point.Class845();
        // ISSUE: reference to a compiler-generated field
        class845.angular3Point_0 = this;
        CommandGroup undoGroup1 = (CommandGroup) null;
        if (undoGroup != null)
        {
          undoGroup1 = new CommandGroup((object) this);
          undoGroup.UndoStack.Push((ICommand) undoGroup1);
        }
        base.TransformMe(config, matrix, undoGroup1);
        // ISSUE: reference to a compiler-generated field
        class845.point3D_0 = this.point3D_2;
        // ISSUE: reference to a compiler-generated field
        class845.point3D_1 = this.point3D_3;
        // ISSUE: reference to a compiler-generated field
        class845.point3D_2 = this.point3D_4;
        // ISSUE: reference to a compiler-generated field
        class845.point3D_3 = this.point3D_5;
        this.point3D_2 = matrix.Transform(this.point3D_2);
        this.point3D_3 = matrix.Transform(this.point3D_3);
        this.point3D_4 = matrix.Transform(this.point3D_4);
        this.point3D_5 = matrix.Transform(this.point3D_5);
        if (undoGroup1 == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup1.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfDimension.Angular3Point.Class846()
        {
          class845_0 = class845,
          point3D_0 = this.point3D_2,
          point3D_1 = this.point3D_3,
          point3D_2 = this.point3D_4,
          point3D_3 = this.point3D_5
        }.method_0), new System.Action(class845.method_0)));
      }

      public override void GenerateBlock()
      {
        DxfModel model = this.Model;
        base.GenerateBlock();
        Matrix4D matrix4D = this.method_21();
        WW.Math.Point3D point3D = matrix4D.Transform(this.AngleVertex);
        this.method_17(model, this.Block, point3D);
        this.method_16(model, this.Block, point3D, matrix4D.Transform(this.ExtensionLine1StartPoint), matrix4D.Transform(this.ExtensionLine2StartPoint), matrix4D.Transform(this.DimensionLineArcPoint));
      }

      public override void DrawInternal(
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        if (context.Config.ShowDimensionDefinitionPoints)
        {
          IClippingTransformer transformer = context.GetTransformer();
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_2), ArgbColors.Yellow);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_3), ArgbColors.Orange);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_4), ArgbColors.DarkOrange);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_5), ArgbColors.Purple);
        }
        base.DrawInternal(context, graphicsFactory);
      }

      public override void DrawInternal(
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        if (context.Config.ShowDimensionDefinitionPoints)
        {
          IClippingTransformer transformer = context.GetTransformer();
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_2), ArgbColors.Yellow);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_3), ArgbColors.Orange);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_4), ArgbColors.DarkOrange);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_5), ArgbColors.Purple);
        }
        base.DrawInternal(context, graphicsFactory);
      }

      public override string GetLinearMeasurementText(
        DxfDimensionStyleOverrides effectiveDimensionStyle)
      {
        return this.method_18(effectiveDimensionStyle);
      }

      public override double GetActualMeasurement()
      {
        Vector3D unit1 = (this.point3D_3 - this.point3D_2).GetUnit();
        double num1 = DxfUtil.smethod_55(unit1.Y, unit1.X);
        if (num1 < 0.0)
          num1 += 2.0 * System.Math.PI;
        Vector3D unit2 = (this.point3D_4 - this.point3D_2).GetUnit();
        double num2 = DxfUtil.smethod_55(unit2.Y, unit2.X);
        if (num2 < 0.0)
          num2 += 2.0 * System.Math.PI;
        if (num2 < num1)
          num2 += 2.0 * System.Math.PI;
        double num3 = System.Math.Abs(num2 - num1);
        Matrix4D inverse = this.Transform.GetInverse();
        if (!this.method_15(inverse.Transform(this.point3D_2), inverse.Transform(this.point3D_5), inverse.Transform(this.point3D_3), inverse.Transform(this.point3D_4)))
          num3 = 2.0 * System.Math.PI - num3;
        return num3;
      }

      public override double GetActualAlternateMeasurement()
      {
        return this.GetActualMeasurement();
      }

      public override IGraphCloneable Clone(CloneContext cloneContext)
      {
        DxfDimension.Angular3Point angular3Point = (DxfDimension.Angular3Point) cloneContext.GetExistingClone((IGraphCloneable) this);
        if (angular3Point == null)
        {
          angular3Point = new DxfDimension.Angular3Point(cloneContext.TargetModel);
          cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) angular3Point);
          angular3Point.CopyFrom((DxfHandledObject) this, cloneContext);
        }
        return (IGraphCloneable) angular3Point;
      }

      public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
      {
        base.CopyFrom(from, cloneContext);
        DxfDimension.Angular3Point angular3Point = (DxfDimension.Angular3Point) from;
        this.point3D_2 = angular3Point.point3D_2;
        this.point3D_3 = angular3Point.point3D_3;
        this.point3D_4 = angular3Point.point3D_4;
        this.point3D_5 = angular3Point.point3D_5;
      }

      public override void Accept(IEntityVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override IControlPointCollection InteractionControlPoints
      {
        get
        {
          return (IControlPointCollection) this;
        }
      }

      void IControlPointCollection.Set(int index, WW.Math.Point3D value)
      {
        DxfDimension.Angular3Point.icontrolPoint_0[index].SetValue((object) this, value);
      }

      WW.Math.Point3D IControlPointCollection.Get(int index)
      {
        return DxfDimension.Angular3Point.icontrolPoint_0[index].GetValue((object) this);
      }

      string IControlPointCollection.GetDescription(int index)
      {
        return DxfDimension.Angular3Point.icontrolPoint_0[index].Description;
      }

      PointDisplayType IControlPointCollection.GetDisplayType(
        int index)
      {
        return DxfDimension.Angular3Point.icontrolPoint_0[index].DisplayType;
      }

      int IControlPointCollection.Count
      {
        get
        {
          return DxfDimension.Angular3Point.icontrolPoint_0.Length;
        }
      }

      bool IControlPointCollection.IsCountFixed
      {
        get
        {
          return true;
        }
      }

      void IControlPointCollection.Insert(int index)
      {
        throw new NotSupportedException();
      }

      void IControlPointCollection.RemoveAt(int index)
      {
        throw new NotSupportedException();
      }

      internal override short vmethod_6(Class432 w)
      {
        return 23;
      }

      public override DxfAnnotationScaleObjectContextData CreateContextData(
        DxfScale scale)
      {
        return (DxfAnnotationScaleObjectContextData) new DxfDimensionObjectContextData.Angular(this, scale);
      }

      private class Class841 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Angular3Point.Class841();

        private Class841()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          ((DxfDimension.Angular3Point) owner).point3D_2 = value;
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Angular3Point) owner).point3D_2;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Angular3Point_AngleVertexControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }

      private class Class842 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Angular3Point.Class842();

        private Class842()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          ((DxfDimension.Angular3Point) owner).point3D_3 = value;
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Angular3Point) owner).point3D_3;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Angular3Point_ExtensionLine1StartPointControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }

      private class Class843 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Angular3Point.Class843();

        private Class843()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          ((DxfDimension.Angular3Point) owner).point3D_4 = value;
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Angular3Point) owner).point3D_4;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Angular3Point_ExtensionLine2StartPointControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }

      private class Class844 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Angular3Point.Class844();

        private Class844()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          ((DxfDimension.Angular3Point) owner).point3D_5 = value;
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Angular3Point) owner).point3D_5;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Angular3Point_DimensionLineArcPointControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }
    }

    public class Angular4Point : DxfDimension, IControlPointCollection
    {
      private static readonly IControlPoint[] icontrolPoint_0 = new IControlPoint[5]{ DxfDimension.Angular4Point.Class847.icontrolPoint_0, DxfDimension.Angular4Point.Class848.icontrolPoint_0, DxfDimension.Angular4Point.Class849.icontrolPoint_0, DxfDimension.Angular4Point.Class850.icontrolPoint_0, DxfDimension.Angular4Point.Class851.icontrolPoint_0 };
      private WW.Math.Point3D point3D_2;
      private WW.Math.Point3D point3D_3;
      private WW.Math.Point3D point3D_4;
      private WW.Math.Point3D point3D_5;
      private WW.Math.Point3D point3D_6;

      public Angular4Point(DxfDimensionStyle dimensionStyle)
        : base(dimensionStyle)
      {
      }

      protected internal Angular4Point(DxfModel model)
        : base(model)
      {
      }

      public WW.Math.Point3D ExtensionLine1StartPoint
      {
        get
        {
          return this.point3D_2;
        }
        set
        {
          this.point3D_2 = value;
        }
      }

      public WW.Math.Point3D ExtensionLine2StartPoint
      {
        get
        {
          return this.point3D_3;
        }
        set
        {
          this.point3D_3 = value;
        }
      }

      public WW.Math.Point3D ExtensionLine1EndPoint
      {
        get
        {
          return this.point3D_4;
        }
        set
        {
          this.point3D_4 = value;
        }
      }

      public WW.Math.Point3D ExtensionLine2EndPoint
      {
        get
        {
          return this.point3D_5;
        }
        set
        {
          this.point3D_5 = value;
        }
      }

      public WW.Math.Point3D DimensionLineArcPoint
      {
        get
        {
          if (!this.IsAnnotative)
            return this.point3D_6;
          DxfDimensionObjectContextData.Angular angular = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfDimensionObjectContextData.Angular;
          if (angular != null)
            return angular.DimensionLineArcPoint;
          return this.point3D_6;
        }
        set
        {
          if (!this.IsAnnotative)
          {
            this.point3D_6 = value;
          }
          else
          {
            DxfDimensionObjectContextData.Angular angular = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfDimensionObjectContextData.Angular;
            if (angular != null)
              angular.DimensionLineArcPoint = value;
            if (angular != null && !angular.IsDefault)
              return;
            this.point3D_6 = value;
          }
        }
      }

      public override string AcClass
      {
        get
        {
          return "AcDb2LineAngularDimension";
        }
      }

      public override void TransformMe(
        TransformConfig config,
        Matrix4D matrix,
        CommandGroup undoGroup)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfDimension.Angular4Point.Class852 class852 = new DxfDimension.Angular4Point.Class852();
        // ISSUE: reference to a compiler-generated field
        class852.angular4Point_0 = this;
        CommandGroup undoGroup1 = (CommandGroup) null;
        if (undoGroup != null)
        {
          undoGroup1 = new CommandGroup((object) this);
          undoGroup.UndoStack.Push((ICommand) undoGroup1);
        }
        base.TransformMe(config, matrix, undoGroup1);
        // ISSUE: reference to a compiler-generated field
        class852.point3D_0 = this.point3D_2;
        // ISSUE: reference to a compiler-generated field
        class852.point3D_1 = this.point3D_3;
        // ISSUE: reference to a compiler-generated field
        class852.point3D_2 = this.point3D_4;
        // ISSUE: reference to a compiler-generated field
        class852.point3D_3 = this.point3D_5;
        // ISSUE: reference to a compiler-generated field
        class852.point3D_4 = this.point3D_6;
        this.point3D_2 = matrix.Transform(this.point3D_2);
        this.point3D_3 = matrix.Transform(this.point3D_3);
        this.point3D_4 = matrix.Transform(this.point3D_4);
        this.point3D_5 = matrix.Transform(this.point3D_5);
        this.point3D_6 = matrix.Transform(this.point3D_6);
        if (undoGroup1 == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup1.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfDimension.Angular4Point.Class853()
        {
          class852_0 = class852,
          point3D_0 = this.point3D_2,
          point3D_1 = this.point3D_3,
          point3D_2 = this.point3D_4,
          point3D_3 = this.point3D_5,
          point3D_4 = this.point3D_6
        }.method_0), new System.Action(class852.method_0)));
      }

      public override void GenerateBlock()
      {
        base.GenerateBlock();
        DxfModel model = this.Model;
        if (model == null)
          throw new DxfException("Cannot generate dimension block, dimension is not part of a model.");
        Matrix4D matrix4D = this.method_21();
        WW.Math.Point3D point3D1 = matrix4D.Transform(this.ExtensionLine1StartPoint);
        WW.Math.Point3D point3D2 = matrix4D.Transform(this.ExtensionLine1EndPoint);
        WW.Math.Point3D point3D3 = matrix4D.Transform(this.ExtensionLine2StartPoint);
        WW.Math.Point3D point3D4 = matrix4D.Transform(this.ExtensionLine2EndPoint);
        DxfDimensionStyleOverrides effectiveDimensionStyle = this.GetEffectiveDimensionStyle(model);
        bool flag1 = point3D1 != point3D2;
        this.method_17(model, this.Block, point3D1);
        this.method_17(model, this.Block, point3D2);
        bool flag2 = point3D3 != point3D4;
        this.method_17(model, this.Block, point3D3);
        this.method_17(model, this.Block, point3D4);
        if (!flag1 || !flag2)
          return;
        WW.Math.Point2D? intersection = Line2D.GetIntersection(new Line2D(point3D1.X, point3D1.Y, point3D2.X - point3D1.X, point3D2.Y - point3D1.Y), new Line2D(point3D3.X, point3D3.Y, point3D4.X - point3D3.X, point3D4.Y - point3D3.Y));
        if (!intersection.HasValue)
          return;
        WW.Math.Point3D point3D5 = new WW.Math.Point3D(intersection.Value.X, intersection.Value.Y, point3D1.Z);
        WW.Math.Point3D dimensionLineArcPointBcs = matrix4D.Transform(this.point3D_6);
        double length = (dimensionLineArcPointBcs - point3D5).GetLength();
        WW.Math.Point3D a1 = this.method_23(point3D5, point3D1, point3D2, point3D3, point3D4, dimensionLineArcPointBcs, length, effectiveDimensionStyle, effectiveDimensionStyle.SuppressFirstExtensionLine);
        WW.Math.Point3D b1 = this.method_23(point3D5, point3D3, point3D4, point3D1, point3D2, dimensionLineArcPointBcs, length, effectiveDimensionStyle, effectiveDimensionStyle.SuppressSecondExtensionLine);
        Vector3D vector3D1 = a1 - point3D5;
        double a2 = MathUtil.NormalizeAngleTwoPi(System.Math.Atan2(vector3D1.Y, vector3D1.X));
        Vector3D vector3D2 = b1 - point3D5;
        double b2 = MathUtil.NormalizeAngleTwoPi(System.Math.Atan2(vector3D2.Y, vector3D2.X));
        if (MathUtil.GetAngleDifference(b2, a2) > System.Math.PI)
        {
          MathUtil.Swap(ref a2, ref b2);
          MathUtil.Swap<WW.Math.Point3D>(ref a1, ref b1);
        }
        this.DrawDimensionLineArc(model, this.Block, point3D5, effectiveDimensionStyle, length, a1, b1);
      }

      private WW.Math.Point3D method_23(
        WW.Math.Point3D angleVertexBcs,
        WW.Math.Point3D extensionLine1StartPointBcs,
        WW.Math.Point3D extensionLine1EndPointBcs,
        WW.Math.Point3D extensionLine2StartPointBcs,
        WW.Math.Point3D extensionLine2EndPointBcs,
        WW.Math.Point3D dimensionLineArcPointBcs,
        double radius,
        DxfDimensionStyleOverrides effectiveDimStyle,
        bool suppressExtensionLine)
      {
        Vector3D u1 = extensionLine1EndPointBcs - extensionLine1StartPointBcs;
        Vector3D unit = u1.GetUnit();
        Vector3D u2 = dimensionLineArcPointBcs - angleVertexBcs;
        Vector3D v = Vector3D.CrossProduct(extensionLine2EndPointBcs - extensionLine2StartPointBcs, Vector3D.ZAxis);
        double a = Vector3D.DotProduct(u2, v);
        double num1 = Vector3D.DotProduct(u1, v);
        double num2 = (!MathUtil.AreApproxEqual(a, 0.0) ? (double) System.Math.Sign(a * num1) : 1.0) * radius;
        if (!suppressExtensionLine)
        {
          double val1 = Vector3D.DotProduct(extensionLine1StartPointBcs - angleVertexBcs, unit);
          double val2 = Vector3D.DotProduct(extensionLine1EndPointBcs - angleVertexBcs, unit);
          double num3 = System.Math.Min(val1, val2);
          double num4 = System.Math.Max(val1, val2);
          if (num2 < num3)
          {
            double num5 = effectiveDimStyle.ScaleFactor * effectiveDimStyle.ExtensionLineOffset;
            this.Block.Entities.Add((DxfEntity) this.CreateExtensionLine(angleVertexBcs + num2 * unit, angleVertexBcs + (num2 * num3 > 0.0 ? (num3 - num5) * unit : Vector3D.Zero), effectiveDimStyle, true));
          }
          else if (num2 > num4)
          {
            double num5 = effectiveDimStyle.ScaleFactor * effectiveDimStyle.ExtensionLineOffset;
            this.Block.Entities.Add((DxfEntity) this.CreateExtensionLine(angleVertexBcs + num2 * unit, angleVertexBcs + (num2 * num4 > 0.0 ? (num4 + num5) * unit : Vector3D.Zero), effectiveDimStyle, true));
          }
        }
        return angleVertexBcs + num2 * unit;
      }

      public override void DrawInternal(
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        if (context.Config.ShowDimensionDefinitionPoints)
        {
          IClippingTransformer transformer = context.GetTransformer();
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_2), ArgbColors.Yellow);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_4), ArgbColors.Orange);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_3), ArgbColors.Yellow);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_5), ArgbColors.Orange);
          IClippingTransformer clippingTransformer = (IClippingTransformer) transformer.Clone();
          clippingTransformer.SetPreTransform(DxfUtil.GetToWCSTransform(this.vector3D_0));
          this.DrawDebugCross(context, graphicsFactory, clippingTransformer.Transform(this.point3D_6), ArgbColors.DarkOrange);
        }
        base.DrawInternal(context, graphicsFactory);
      }

      public override void DrawInternal(
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        if (context.Config.ShowDimensionDefinitionPoints)
        {
          IClippingTransformer transformer = context.GetTransformer();
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_2), ArgbColors.Yellow);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_4), ArgbColors.Orange);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_3), ArgbColors.Yellow);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_5), ArgbColors.Orange);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_6), ArgbColors.DarkOrange);
        }
        base.DrawInternal(context, graphicsFactory);
      }

      public override string GetLinearMeasurementText(
        DxfDimensionStyleOverrides effectiveDimensionStyle)
      {
        return this.method_18(effectiveDimensionStyle);
      }

      public override double GetActualMeasurement()
      {
        Matrix4D matrix4D = this.method_21();
        WW.Math.Point3D point3D1 = matrix4D.Transform(this.point3D_2);
        WW.Math.Point3D point3D2 = matrix4D.Transform(this.point3D_4);
        WW.Math.Point3D point3D3 = matrix4D.Transform(this.point3D_3);
        WW.Math.Point3D point3D4 = matrix4D.Transform(this.point3D_5);
        Line2D a = new Line2D(point3D1.X, point3D1.Y, point3D2.X - point3D1.X, point3D2.Y - point3D1.Y);
        Line2D b = new Line2D(point3D3.X, point3D3.Y, point3D4.X - point3D3.X, point3D4.Y - point3D3.Y);
        WW.Math.Point2D? intersection = Line2D.GetIntersection(a, b);
        double num = 0.0;
        if (intersection.HasValue)
        {
          WW.Math.Point3D point3D5 = new WW.Math.Point3D(intersection.Value.X, intersection.Value.Y, 0.0);
          Vector2D v = (WW.Math.Point2D) matrix4D.Transform(this.point3D_6) - intersection.Value;
          Vector2D u1 = new Vector2D(-a.Direction.Y, a.Direction.X);
          Vector2D u2 = new Vector2D(-b.Direction.Y, b.Direction.X);
          num = System.Math.Abs(Vector2D.GetAngle(a.Direction * (double) System.Math.Sign(Vector2D.DotProduct(u2, v) * Vector2D.DotProduct(u2, a.Direction)), b.Direction * (double) System.Math.Sign(Vector2D.DotProduct(u1, v) * Vector2D.DotProduct(u1, b.Direction))));
        }
        return num;
      }

      public override double GetActualAlternateMeasurement()
      {
        return this.GetActualMeasurement();
      }

      public override IGraphCloneable Clone(CloneContext cloneContext)
      {
        DxfDimension.Angular4Point angular4Point = (DxfDimension.Angular4Point) cloneContext.GetExistingClone((IGraphCloneable) this);
        if (angular4Point == null)
        {
          angular4Point = new DxfDimension.Angular4Point(cloneContext.TargetModel);
          cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) angular4Point);
          angular4Point.CopyFrom((DxfHandledObject) this, cloneContext);
        }
        return (IGraphCloneable) angular4Point;
      }

      public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
      {
        base.CopyFrom(from, cloneContext);
        DxfDimension.Angular4Point angular4Point = (DxfDimension.Angular4Point) from;
        this.point3D_2 = angular4Point.point3D_2;
        this.point3D_3 = angular4Point.point3D_3;
        this.point3D_4 = angular4Point.point3D_4;
        this.point3D_5 = angular4Point.point3D_5;
        this.point3D_6 = angular4Point.point3D_6;
      }

      public override void Accept(IEntityVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override IControlPointCollection InteractionControlPoints
      {
        get
        {
          return (IControlPointCollection) this;
        }
      }

      void IControlPointCollection.Set(int index, WW.Math.Point3D value)
      {
        DxfDimension.Angular4Point.icontrolPoint_0[index].SetValue((object) this, value);
      }

      WW.Math.Point3D IControlPointCollection.Get(int index)
      {
        return DxfDimension.Angular4Point.icontrolPoint_0[index].GetValue((object) this);
      }

      string IControlPointCollection.GetDescription(int index)
      {
        return DxfDimension.Angular4Point.icontrolPoint_0[index].Description;
      }

      PointDisplayType IControlPointCollection.GetDisplayType(
        int index)
      {
        return DxfDimension.Angular4Point.icontrolPoint_0[index].DisplayType;
      }

      int IControlPointCollection.Count
      {
        get
        {
          return DxfDimension.Angular4Point.icontrolPoint_0.Length;
        }
      }

      bool IControlPointCollection.IsCountFixed
      {
        get
        {
          return true;
        }
      }

      void IControlPointCollection.Insert(int index)
      {
        throw new NotSupportedException();
      }

      void IControlPointCollection.RemoveAt(int index)
      {
        throw new NotSupportedException();
      }

      internal override short vmethod_6(Class432 w)
      {
        return 24;
      }

      public override DxfAnnotationScaleObjectContextData CreateContextData(
        DxfScale scale)
      {
        return (DxfAnnotationScaleObjectContextData) new DxfDimensionObjectContextData.Angular(this, scale);
      }

      private class Class847 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Angular4Point.Class847();

        private Class847()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          ((DxfDimension.Angular4Point) owner).point3D_2 = value;
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Angular4Point) owner).point3D_2;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Angular4Point_ExtensionLine1StartPointControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }

      private class Class848 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Angular4Point.Class848();

        private Class848()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          ((DxfDimension.Angular4Point) owner).point3D_4 = value;
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Angular4Point) owner).point3D_4;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Angular4Point_ExtensionLine1EndPointControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }

      private class Class849 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Angular4Point.Class849();

        private Class849()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          ((DxfDimension.Angular4Point) owner).point3D_3 = value;
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Angular4Point) owner).point3D_3;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Angular4Point_ExtensionLine2StartPointControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }

      private class Class850 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Angular4Point.Class850();

        private Class850()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          ((DxfDimension.Angular4Point) owner).point3D_5 = value;
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Angular4Point) owner).point3D_5;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Angular4Point_ExtensionLine2EndPointControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }

      private class Class851 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Angular4Point.Class851();

        private Class851()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          ((DxfDimension.Angular4Point) owner).point3D_6 = value;
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Angular4Point) owner).point3D_6;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Angular4Point_DimensionLineArcPointControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }
    }

    public class Ordinate : DxfDimension, IControlPointCollection
    {
      private static readonly IControlPoint[] icontrolPoint_0 = new IControlPoint[2]{ DxfDimension.Ordinate.Class854.icontrolPoint_0, DxfDimension.Ordinate.Class855.icontrolPoint_0 };
      private bool bool_7 = true;
      private WW.Math.Point3D point3D_2;
      private WW.Math.Point3D point3D_3;
      private WW.Math.Point3D point3D_4;

      public Ordinate(DxfDimensionStyle dimensionStyle)
        : base(dimensionStyle)
      {
      }

      protected internal Ordinate(DxfModel model)
        : base(model)
      {
      }

      public WW.Math.Point3D FeaturePosition
      {
        get
        {
          return this.point3D_2;
        }
        set
        {
          this.point3D_2 = value;
        }
      }

      public bool ShowX
      {
        get
        {
          return this.bool_7;
        }
        set
        {
          this.bool_7 = value;
        }
      }

      public WW.Math.Point3D LeaderEndPoint
      {
        get
        {
          if (!this.IsAnnotative)
            return this.point3D_3;
          DxfDimensionObjectContextData.Ordinate ordinate = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfDimensionObjectContextData.Ordinate;
          if (ordinate != null)
            return ordinate.LeaderEndPoint;
          return this.point3D_3;
        }
        set
        {
          if (!this.IsAnnotative)
          {
            this.point3D_3 = value;
          }
          else
          {
            DxfDimensionObjectContextData.Ordinate ordinate = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfDimensionObjectContextData.Ordinate;
            if (ordinate != null)
              ordinate.LeaderEndPoint = value;
            if (ordinate != null && !ordinate.IsDefault)
              return;
            this.point3D_3 = value;
          }
        }
      }

      public WW.Math.Point3D UcsOrigin
      {
        get
        {
          if (!this.IsAnnotative)
            return this.point3D_4;
          DxfDimensionObjectContextData.Ordinate ordinate = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfDimensionObjectContextData.Ordinate;
          if (ordinate != null)
            return ordinate.Origin;
          return this.point3D_4;
        }
        set
        {
          if (!this.IsAnnotative)
          {
            this.point3D_4 = value;
          }
          else
          {
            DxfDimensionObjectContextData.Ordinate ordinate = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfDimensionObjectContextData.Ordinate;
            if (ordinate != null)
              ordinate.Origin = value;
            if (ordinate != null && !ordinate.IsDefault)
              return;
            this.point3D_4 = value;
          }
        }
      }

      public override string AcClass
      {
        get
        {
          return "AcDbOrdinateDimension";
        }
      }

      public override void TransformMe(
        TransformConfig config,
        Matrix4D matrix,
        CommandGroup undoGroup)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfDimension.Ordinate.Class856 class856 = new DxfDimension.Ordinate.Class856();
        // ISSUE: reference to a compiler-generated field
        class856.ordinate_0 = this;
        CommandGroup undoGroup1 = (CommandGroup) null;
        if (undoGroup != null)
        {
          undoGroup1 = new CommandGroup((object) this);
          undoGroup.UndoStack.Push((ICommand) undoGroup1);
        }
        base.TransformMe(config, matrix, undoGroup1);
        // ISSUE: reference to a compiler-generated field
        class856.point3D_0 = this.point3D_2;
        // ISSUE: reference to a compiler-generated field
        class856.point3D_1 = this.point3D_3;
        // ISSUE: reference to a compiler-generated field
        class856.point3D_2 = this.point3D_4;
        this.point3D_2 = matrix.Transform(this.point3D_2);
        this.point3D_3 = matrix.Transform(this.point3D_3);
        this.point3D_4 = matrix.Transform(this.point3D_4);
        if (undoGroup1 == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup1.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfDimension.Ordinate.Class857()
        {
          class856_0 = class856,
          point3D_0 = this.point3D_2,
          point3D_1 = this.point3D_3,
          point3D_2 = this.point3D_4
        }.method_0), new System.Action(class856.method_0)));
      }

      public override void GenerateBlock()
      {
        base.GenerateBlock();
        DxfModel model = this.Model;
        if (model == null)
          throw new DxfException("Cannot generate dimension block, dimension is not part of a model.");
        Matrix4D matrix4D = this.method_21();
        WW.Math.Point3D defPoint = matrix4D.Transform(this.FeaturePosition);
        WW.Math.Point3D point3D1 = matrix4D.Transform(this.LeaderEndPoint);
        DxfDimensionStyleOverrides effectiveDimensionStyle = this.GetEffectiveDimensionStyle(model);
        this.method_17(model, this.Block, defPoint);
        this.method_17(model, this.Block, point3D1);
        double num1 = DxfDimension.smethod_15(effectiveDimensionStyle);
        string text = this.GetText(effectiveDimensionStyle);
        double num2 = effectiveDimensionStyle.ScaleFactor * effectiveDimensionStyle.ExtensionLineOffset;
        if (this.bool_7)
        {
          bool flag;
          double num3 = (flag = point3D1.Y >= defPoint.Y) ? 1.0 : -1.0;
          WW.Math.Point3D start = defPoint + Vector3D.YAxis * num2 * num3;
          if (MathUtil.AreApproxEqual(defPoint.X, point3D1.X))
          {
            DxfLine dxfLine = new DxfLine(EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor), start, point3D1);
            dxfLine.LineWeight = effectiveDimensionStyle.DimensionLineWeight;
            this.Block.Entities.Add((DxfEntity) dxfLine);
          }
          else
          {
            WW.Math.Point3D point3D2 = new WW.Math.Point3D(start.X, (start.Y + point3D1.Y) * 0.5, (start.Z + point3D1.Z) * 0.5);
            WW.Math.Point3D point3D3 = new WW.Math.Point3D(point3D1.X, (start.Y + point3D1.Y) * 0.5, (start.Z + point3D1.Z) * 0.5);
            DxfLine dxfLine1 = new DxfLine(EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor), start, point3D2);
            dxfLine1.LineWeight = effectiveDimensionStyle.DimensionLineWeight;
            this.Block.Entities.Add((DxfEntity) dxfLine1);
            DxfLine dxfLine2 = new DxfLine(EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor), point3D2, point3D3);
            dxfLine2.LineWeight = effectiveDimensionStyle.DimensionLineWeight;
            this.Block.Entities.Add((DxfEntity) dxfLine2);
            DxfLine dxfLine3 = new DxfLine(EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor), point3D3, point3D1);
            dxfLine3.LineWeight = effectiveDimensionStyle.DimensionLineWeight;
            this.Block.Entities.Add((DxfEntity) dxfLine3);
          }
          DxfMText dxfMtext = DxfDimension.smethod_12(text, point3D1 + num1 * num3 * Vector3D.YAxis, effectiveDimensionStyle);
          dxfMtext.AttachmentPoint = flag ? AttachmentPoint.MiddleLeft : AttachmentPoint.MiddleRight;
          dxfMtext.XAxis = Vector3D.YAxis;
          this.Block.Entities.Add((DxfEntity) dxfMtext);
        }
        else
        {
          bool flag;
          double num3 = (flag = point3D1.X >= defPoint.X) ? 1.0 : -1.0;
          WW.Math.Point3D start = defPoint + Vector3D.XAxis * num2 * num3;
          if (MathUtil.AreApproxEqual(defPoint.Y, point3D1.Y))
          {
            DxfLine dxfLine = new DxfLine(EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor), start, point3D1);
            dxfLine.LineWeight = effectiveDimensionStyle.DimensionLineWeight;
            this.Block.Entities.Add((DxfEntity) dxfLine);
          }
          else
          {
            WW.Math.Point3D point3D2 = new WW.Math.Point3D((start.X + point3D1.X) * 0.5, start.Y, (start.Z + point3D1.Z) * 0.5);
            WW.Math.Point3D point3D3 = new WW.Math.Point3D((start.X + point3D1.X) * 0.5, point3D1.Y, (start.Z + point3D1.Z) * 0.5);
            DxfLine dxfLine1 = new DxfLine(EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor), start, point3D2);
            dxfLine1.LineWeight = effectiveDimensionStyle.DimensionLineWeight;
            this.Block.Entities.Add((DxfEntity) dxfLine1);
            DxfLine dxfLine2 = new DxfLine(EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor), point3D2, point3D3);
            dxfLine2.LineWeight = effectiveDimensionStyle.DimensionLineWeight;
            this.Block.Entities.Add((DxfEntity) dxfLine2);
            DxfLine dxfLine3 = new DxfLine(EntityColor.CreateFrom(effectiveDimensionStyle.DimensionLineColor), point3D3, point3D1);
            dxfLine3.LineWeight = effectiveDimensionStyle.DimensionLineWeight;
            this.Block.Entities.Add((DxfEntity) dxfLine3);
          }
          DxfMText dxfMtext = DxfDimension.smethod_12(text, point3D1 + num1 * num3 * Vector3D.XAxis, effectiveDimensionStyle);
          dxfMtext.AttachmentPoint = flag ? AttachmentPoint.MiddleLeft : AttachmentPoint.MiddleRight;
          this.Block.Entities.Add((DxfEntity) dxfMtext);
        }
      }

      public override void DrawInternal(
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory graphicsFactory)
      {
        if (context.Config.ShowDimensionDefinitionPoints)
        {
          IClippingTransformer transformer = context.GetTransformer();
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_2), ArgbColors.Yellow);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_3), ArgbColors.Orange);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_4), ArgbColors.DarkOrange);
        }
        base.DrawInternal(context, graphicsFactory);
      }

      public override void DrawInternal(
        DrawContext.Wireframe context,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        if (context.Config.ShowDimensionDefinitionPoints)
        {
          IClippingTransformer transformer = context.GetTransformer();
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_2), ArgbColors.Yellow);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_3), ArgbColors.Orange);
          this.DrawDebugCross(context, graphicsFactory, transformer.Transform(this.point3D_4), ArgbColors.DarkOrange);
        }
        base.DrawInternal(context, graphicsFactory);
      }

      public override double GetActualMeasurement()
      {
        if (!this.bool_7)
          return this.point3D_2.Y;
        return this.point3D_2.X;
      }

      public override double GetActualAlternateMeasurement()
      {
        return this.GetActualMeasurement();
      }

      public override IGraphCloneable Clone(CloneContext cloneContext)
      {
        DxfDimension.Ordinate ordinate = (DxfDimension.Ordinate) cloneContext.GetExistingClone((IGraphCloneable) this);
        if (ordinate == null)
        {
          ordinate = new DxfDimension.Ordinate(cloneContext.TargetModel);
          cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) ordinate);
          ordinate.CopyFrom((DxfHandledObject) this, cloneContext);
        }
        return (IGraphCloneable) ordinate;
      }

      public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
      {
        base.CopyFrom(from, cloneContext);
        DxfDimension.Ordinate ordinate = (DxfDimension.Ordinate) from;
        this.point3D_2 = ordinate.point3D_2;
        this.bool_7 = ordinate.bool_7;
        this.point3D_3 = ordinate.point3D_3;
        this.point3D_4 = ordinate.point3D_4;
      }

      public override void Accept(IEntityVisitor visitor)
      {
        visitor.Visit(this);
      }

      public override IControlPointCollection InteractionControlPoints
      {
        get
        {
          return (IControlPointCollection) this;
        }
      }

      void IControlPointCollection.Set(int index, WW.Math.Point3D value)
      {
        DxfDimension.Ordinate.icontrolPoint_0[index].SetValue((object) this, value);
      }

      WW.Math.Point3D IControlPointCollection.Get(int index)
      {
        return DxfDimension.Ordinate.icontrolPoint_0[index].GetValue((object) this);
      }

      string IControlPointCollection.GetDescription(int index)
      {
        return DxfDimension.Ordinate.icontrolPoint_0[index].Description;
      }

      PointDisplayType IControlPointCollection.GetDisplayType(
        int index)
      {
        return DxfDimension.Ordinate.icontrolPoint_0[index].DisplayType;
      }

      int IControlPointCollection.Count
      {
        get
        {
          return DxfDimension.Ordinate.icontrolPoint_0.Length;
        }
      }

      bool IControlPointCollection.IsCountFixed
      {
        get
        {
          return true;
        }
      }

      void IControlPointCollection.Insert(int index)
      {
        throw new NotSupportedException();
      }

      void IControlPointCollection.RemoveAt(int index)
      {
        throw new NotSupportedException();
      }

      internal override short vmethod_6(Class432 w)
      {
        return 20;
      }

      public override DxfAnnotationScaleObjectContextData CreateContextData(
        DxfScale scale)
      {
        return (DxfAnnotationScaleObjectContextData) new DxfDimensionObjectContextData.Ordinate(this, scale);
      }

      private class Class854 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Ordinate.Class854();

        private Class854()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          ((DxfDimension.Ordinate) owner).point3D_2 = value;
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Ordinate) owner).point3D_2;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Ordinate_FeaturePositionControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }

      private class Class855 : IControlPoint
      {
        public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfDimension.Ordinate.Class855();

        private Class855()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          ((DxfDimension.Ordinate) owner).point3D_3 = value;
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          return ((DxfDimension.Ordinate) owner).point3D_3;
        }

        public string Description
        {
          get
          {
            return Class881.DxfDimension_Ordinate_LeaderEndPointControlPoint_Name;
          }
        }

        public PointDisplayType DisplayType
        {
          get
          {
            return PointDisplayType.Default;
          }
        }
      }
    }

    internal abstract class Class858
    {
      protected string string_0;
      protected Class976 class976_0;
      protected double double_0;

      public string Text
      {
        get
        {
          return this.string_0;
        }
        set
        {
          this.string_0 = value;
        }
      }

      public abstract DxfEntity TextEntity { get; }

      public Class976 Bounds
      {
        get
        {
          return this.class976_0;
        }
      }

      public static DxfDimension.Class858 Create(DxfVersion version)
      {
        if (version >= DxfVersion.Dxf13)
          return (DxfDimension.Class858) new DxfDimension.Class859();
        return (DxfDimension.Class858) new DxfDimension.Class860();
      }

      public abstract double vmethod_0(Vector3D dimensionLineDirection);

      public abstract void vmethod_1(
        DxfModel model,
        DxfDimension dimension,
        WW.Math.Point3D position,
        Vector3D direction,
        Vector3D upDirection,
        double stackingSide,
        DxfDimensionStyleOverrides effectiveDimStyle,
        bool useTextMiddlePoint,
        bool stacked,
        bool outsideIsAboveDimLine);

      internal void method_0(
        WW.Math.Point3D textPosition,
        double textRotation,
        TextHorizontalAlignment textHorizontalAlignment)
      {
        if (this.TextEntity == null)
          return;
        this.vmethod_3(textPosition, new Vector3D(System.Math.Cos(textRotation), System.Math.Sin(textRotation), 0.0), textHorizontalAlignment);
      }

      internal abstract void vmethod_2(
        WW.Math.Point3D textPosition,
        Vector3D textDirection,
        AttachmentPoint attachmentPoint,
        DimensionTextHorizontalAlignment textHorizontalAlignment,
        DimensionTextVerticalAlignment textVerticalAlignment,
        bool outsideIsAboveDimLine);

      internal abstract void vmethod_3(
        WW.Math.Point3D textPosition,
        Vector3D textDirection,
        TextHorizontalAlignment textHorizontalAlignment);

      internal abstract void vmethod_4(double textRotation);

      internal abstract void vmethod_5(Vector3D direction);
    }

    internal class Class859 : DxfDimension.Class858
    {
      private DxfMText dxfMText_0;

      public override DxfEntity TextEntity
      {
        get
        {
          return (DxfEntity) this.dxfMText_0;
        }
      }

      public override double vmethod_0(Vector3D dimensionLineDirection)
      {
        if (this.dxfMText_0 != null)
        {
          this.class976_0 = new Class976(this.dxfMText_0.TextBounds, this.dxfMText_0.Transform);
          this.double_0 = System.Math.Max(System.Math.Abs(Vector3D.DotProduct(this.class976_0.Dx + this.class976_0.Dy, dimensionLineDirection)), System.Math.Abs(Vector3D.DotProduct(this.class976_0.Dx - this.class976_0.Dy, dimensionLineDirection)));
        }
        return this.double_0;
      }

      public override void vmethod_1(
        DxfModel model,
        DxfDimension dimension,
        WW.Math.Point3D position,
        Vector3D direction,
        Vector3D upDirection,
        double stackingSide,
        DxfDimensionStyleOverrides effectiveDimStyle,
        bool useTextMiddlePoint,
        bool stacked,
        bool outsideIsAboveDimLine)
      {
        if (string.IsNullOrEmpty(this.string_0))
          return;
        this.dxfMText_0 = DxfDimension.smethod_12(this.string_0, position, effectiveDimStyle);
        DxfDimension.smethod_9(this.dxfMText_0, dimension.attachmentPoint_0, effectiveDimStyle.TextHorizontalAlignment, effectiveDimStyle.TextVerticalAlignment, outsideIsAboveDimLine);
        if (effectiveDimStyle.ToleranceAlignment != ToleranceAlignment.Bottom)
        {
          string str = string.Empty;
          switch (effectiveDimStyle.ToleranceAlignment)
          {
            case ToleranceAlignment.Middle:
              str = "\\A1;";
              break;
            case ToleranceAlignment.Top:
              str = "\\A2;";
              break;
          }
          this.dxfMText_0.Text = str + this.dxfMText_0.Text;
        }
        if (!effectiveDimStyle.TextInsideHorizontal)
          this.dxfMText_0.XAxis = direction;
        double num1 = DxfDimension.Class859.smethod_0(this.dxfMText_0);
        if (useTextMiddlePoint)
        {
          if (effectiveDimStyle.TextMovement == TextMovement.FreeTextPosition)
            return;
          double num2 = 0.5;
          switch (effectiveDimStyle.TextVerticalAlignment)
          {
            case DimensionTextVerticalAlignment.Above:
              num2 = 1.0;
              break;
            case DimensionTextVerticalAlignment.ConformJapaneseIndustrialStandards:
            case DimensionTextVerticalAlignment.Below:
              num2 = 0.0;
              break;
          }
          this.dxfMText_0.InsertionPoint += ((num2 - num1) * this.dxfMText_0.BoxHeight + DxfDimension.smethod_15(effectiveDimStyle)) * upDirection;
        }
        else if (stacked)
        {
          if (stackingSide >= 0.0)
            this.dxfMText_0.InsertionPoint += stackingSide * ((1.0 - num1) * DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimStyle) + DxfDimension.smethod_15(effectiveDimStyle)) * upDirection;
          else
            this.dxfMText_0.InsertionPoint += stackingSide * (num1 * DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimStyle) + DxfDimension.smethod_15(effectiveDimStyle)) * upDirection;
        }
        else if (effectiveDimStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Above)
          this.dxfMText_0.InsertionPoint += ((1.0 - num1) * DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimStyle) + DxfDimension.smethod_15(effectiveDimStyle)) * upDirection;
        else if (effectiveDimStyle.TextVerticalAlignment == DimensionTextVerticalAlignment.Centered)
          this.dxfMText_0.InsertionPoint += (0.5 - num1) * DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimStyle) * upDirection;
        else if (effectiveDimStyle.TextVerticalAlignment != DimensionTextVerticalAlignment.Below && effectiveDimStyle.TextVerticalAlignment != DimensionTextVerticalAlignment.ConformJapaneseIndustrialStandards)
        {
          if (effectiveDimStyle.TextVerticalAlignment != DimensionTextVerticalAlignment.Outside)
            return;
          this.dxfMText_0.InsertionPoint += (outsideIsAboveDimLine ? 1.0 - num1 : num1) * (DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimStyle) + DxfDimension.smethod_15(effectiveDimStyle)) * upDirection;
        }
        else
          this.dxfMText_0.InsertionPoint += -(num1 * DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimStyle) + DxfDimension.smethod_15(effectiveDimStyle)) * upDirection;
      }

      public static double smethod_0(DxfMText text)
      {
        double num = 0.0;
        switch (text.AttachmentPoint)
        {
          case AttachmentPoint.MiddleLeft:
          case AttachmentPoint.MiddleCenter:
          case AttachmentPoint.MiddleRight:
            num = 0.5;
            break;
          case AttachmentPoint.BottomLeft:
          case AttachmentPoint.BottomCenter:
          case AttachmentPoint.BottomRight:
            num = 1.0;
            break;
        }
        return num;
      }

      internal override void vmethod_2(
        WW.Math.Point3D textPosition,
        Vector3D textDirection,
        AttachmentPoint attachmentPoint,
        DimensionTextHorizontalAlignment textHorizontalAlignment,
        DimensionTextVerticalAlignment textVerticalAlignment,
        bool outsideIsAboveDimLine)
      {
        if (this.dxfMText_0 == null)
          return;
        this.dxfMText_0.InsertionPoint = textPosition;
        this.dxfMText_0.XAxis = textDirection;
        DxfDimension.smethod_9(this.dxfMText_0, attachmentPoint, textHorizontalAlignment, textVerticalAlignment, outsideIsAboveDimLine);
      }

      internal override void vmethod_3(
        WW.Math.Point3D textPosition,
        Vector3D textDirection,
        TextHorizontalAlignment textHorizontalAlignment)
      {
        if (this.dxfMText_0 == null)
          return;
        this.dxfMText_0.InsertionPoint = textPosition;
        this.dxfMText_0.XAxis = textDirection;
        switch (textHorizontalAlignment)
        {
          case TextHorizontalAlignment.Left:
            this.dxfMText_0.AttachmentPoint = AttachmentPoint.MiddleLeft;
            break;
          case TextHorizontalAlignment.Center:
            this.dxfMText_0.AttachmentPoint = AttachmentPoint.MiddleCenter;
            break;
          case TextHorizontalAlignment.Right:
            this.dxfMText_0.AttachmentPoint = AttachmentPoint.MiddleRight;
            break;
          default:
            this.dxfMText_0.AttachmentPoint = AttachmentPoint.MiddleCenter;
            break;
        }
      }

      internal override void vmethod_4(double textRotation)
      {
        if (this.dxfMText_0 == null)
          return;
        this.dxfMText_0.XAxis = new Vector3D(System.Math.Cos(textRotation), System.Math.Sin(textRotation), 0.0);
      }

      internal override void vmethod_5(Vector3D direction)
      {
        if (this.dxfMText_0 == null)
          return;
        this.dxfMText_0.XAxis = direction;
      }
    }

    internal class Class860 : DxfDimension.Class858
    {
      private DxfText dxfText_0;

      public override DxfEntity TextEntity
      {
        get
        {
          return (DxfEntity) this.dxfText_0;
        }
      }

      public override double vmethod_0(Vector3D dimensionLineDirection)
      {
        if (this.dxfText_0 != null)
        {
          this.class976_0 = new Class976(this.dxfText_0.TextBounds, this.dxfText_0.Transform);
          this.double_0 = System.Math.Max(System.Math.Abs(Vector3D.DotProduct(this.class976_0.Dx + this.class976_0.Dy, dimensionLineDirection)), System.Math.Abs(Vector3D.DotProduct(this.class976_0.Dx - this.class976_0.Dy, dimensionLineDirection)));
        }
        return this.double_0;
      }

      public override void vmethod_1(
        DxfModel model,
        DxfDimension dimension,
        WW.Math.Point3D position,
        Vector3D direction,
        Vector3D upDirection,
        double stackingSide,
        DxfDimensionStyleOverrides effectiveDimStyle,
        bool useTextMiddlePoint,
        bool stacked,
        bool outsideIsAboveDimLine)
      {
        if (string.IsNullOrEmpty(this.string_0))
          return;
        this.dxfText_0 = new DxfText(this.string_0, position, DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) effectiveDimStyle));
        this.dxfText_0.AlignmentPoint2 = new WW.Math.Point3D?(position);
        this.dxfText_0.Color = EntityColor.CreateFrom(effectiveDimStyle.TextColor);
        DxfDimension.smethod_10(this.dxfText_0, effectiveDimStyle.TextHorizontalAlignment, effectiveDimStyle.TextVerticalAlignment);
        if (!effectiveDimStyle.TextInsideHorizontal)
          this.dxfText_0.Rotation = DxfUtil.smethod_55(direction.Y, direction.X);
        if (effectiveDimStyle.TextStyle == null)
          return;
        this.dxfText_0.Style = effectiveDimStyle.TextStyle;
      }

      internal override void vmethod_2(
        WW.Math.Point3D textPosition,
        Vector3D textDirection,
        AttachmentPoint attachmentPoint,
        DimensionTextHorizontalAlignment textHorizontalAlignment,
        DimensionTextVerticalAlignment textVerticalAlignment,
        bool outsideIsAboveDimLine)
      {
        if (this.dxfText_0 == null)
          return;
        this.dxfText_0.AlignmentPoint1 = textPosition;
        this.dxfText_0.AlignmentPoint2 = new WW.Math.Point3D?(textPosition);
        this.vmethod_5(textDirection);
        DxfDimension.smethod_10(this.dxfText_0, textHorizontalAlignment, textVerticalAlignment);
      }

      internal override void vmethod_3(
        WW.Math.Point3D textPosition,
        Vector3D textDirection,
        TextHorizontalAlignment textHorizontalAlignment)
      {
        if (this.dxfText_0 == null)
          return;
        this.dxfText_0.AlignmentPoint1 = textPosition;
        this.dxfText_0.AlignmentPoint2 = new WW.Math.Point3D?(textPosition);
        this.vmethod_5(textDirection);
        this.dxfText_0.HorizontalAlignment = textHorizontalAlignment;
      }

      internal override void vmethod_4(double textRotation)
      {
        if (this.dxfText_0 == null)
          return;
        this.dxfText_0.Rotation = textRotation;
      }

      internal override void vmethod_5(Vector3D direction)
      {
        if (this.dxfText_0 == null)
          return;
        this.dxfText_0.Rotation = System.Math.Atan2(direction.Y, direction.X);
      }
    }

    internal class Class861
    {
      private DxfDimension.Class858 class858_0;
      private DxfDimension.Class858 class858_1;
      private Class976 class976_0;

      public Class861(DxfVersion version)
      {
        this.class858_0 = DxfDimension.Class858.Create(version);
        this.class858_1 = DxfDimension.Class858.Create(version);
      }

      public DxfDimension.Class858 Upper
      {
        get
        {
          return this.class858_0;
        }
      }

      public DxfDimension.Class858 Lower
      {
        get
        {
          return this.class858_1;
        }
      }

      public Class976 Bounds
      {
        get
        {
          return this.class976_0;
        }
      }

      public bool method_0()
      {
        if (string.IsNullOrEmpty(this.class858_0.Text))
          return string.IsNullOrEmpty(this.class858_1.Text);
        return false;
      }

      public void method_1(DxfEntityCollection entities)
      {
        if (this.class858_0.TextEntity != null)
          entities.Add(this.class858_0.TextEntity);
        if (this.class858_1.TextEntity == null)
          return;
        entities.Add(this.class858_1.TextEntity);
      }

      public double method_2(Vector3D dimensionLineDirection)
      {
        double val1_1 = this.class858_0.vmethod_0(dimensionLineDirection);
        double val2_1 = this.class858_1.vmethod_0(dimensionLineDirection);
        if (this.class858_0.Bounds != null)
        {
          if (this.class858_1.Bounds != null)
          {
            this.class976_0 = new Class976();
            Vector3D unit = this.class858_0.Bounds.Dx.GetUnit();
            Vector3D v = new Vector3D(unit.Y, -unit.X, 0.0);
            double val1_2 = Vector3D.DotProduct((Vector3D) this.class858_0.Bounds.Origin, unit);
            double val1_3 = Vector3D.DotProduct((Vector3D) this.class858_0.Bounds.Origin, v);
            double val2_2 = Vector3D.DotProduct((Vector3D) this.class858_1.Bounds.Origin, unit);
            double val2_3 = Vector3D.DotProduct((Vector3D) this.class858_1.Bounds.Origin, v);
            this.class976_0.Origin = (WW.Math.Point3D) (System.Math.Min(val1_2, val2_2) * unit + System.Math.Min(val1_3, val2_3) * v);
            Vector3D u1 = (Vector3D) (this.class858_0.Bounds.Origin + this.class858_0.Bounds.Dx + this.class858_0.Bounds.Dy);
            Vector3D u2 = (Vector3D) (this.class858_1.Bounds.Origin + this.class858_1.Bounds.Dx + this.class858_1.Bounds.Dy);
            double val1_4 = Vector3D.DotProduct(u1, unit);
            double val1_5 = Vector3D.DotProduct(u1, v);
            double val2_4 = Vector3D.DotProduct(u2, unit);
            double val2_5 = Vector3D.DotProduct(u2, v);
            WW.Math.Point3D point3D = (WW.Math.Point3D) (System.Math.Max(val1_4, val2_4) * unit + System.Math.Max(val1_5, val2_5) * v);
            this.class976_0.Dx = Vector3D.DotProduct(point3D - this.class976_0.Origin, unit) * unit;
            this.class976_0.Dy = Vector3D.DotProduct(point3D - this.class976_0.Origin, v) * v;
          }
          else
            this.class976_0 = this.class858_0.Bounds;
        }
        else
          this.class976_0 = this.class858_1.Bounds;
        return System.Math.Max(val1_1, val2_1);
      }

      public void method_3(
        DxfModel model,
        DxfDimension dimension,
        WW.Math.Point3D position,
        Vector3D direction,
        Vector3D aboveDirection,
        DxfDimensionStyleOverrides effectiveDimStyle,
        bool useTextMiddlePoint,
        bool outsideIsAboveDimLine)
      {
        bool stacked = !string.IsNullOrEmpty(this.class858_0.Text) && !string.IsNullOrEmpty(this.class858_1.Text);
        this.class858_0.vmethod_1(model, dimension, position, direction, aboveDirection, 1.0, effectiveDimStyle, useTextMiddlePoint, stacked, outsideIsAboveDimLine);
        this.class858_1.vmethod_1(model, dimension, position, direction, aboveDirection, -1.0, effectiveDimStyle, useTextMiddlePoint, stacked, outsideIsAboveDimLine);
      }

      public void method_4(
        WW.Math.Point3D upperPosition,
        WW.Math.Point3D lowerPosition,
        Vector3D textDirection,
        AttachmentPoint attachmentPoint,
        DimensionTextHorizontalAlignment textHorizontalAlignment,
        DimensionTextVerticalAlignment textVerticalAlignment,
        bool outsideIsAboveDimLine)
      {
        this.class858_0.vmethod_2(upperPosition, textDirection, attachmentPoint, textHorizontalAlignment, textVerticalAlignment, outsideIsAboveDimLine);
        this.class858_1.vmethod_2(lowerPosition, textDirection, attachmentPoint, textHorizontalAlignment, textVerticalAlignment, outsideIsAboveDimLine);
      }

      public void method_5(
        WW.Math.Point3D upperPosition,
        WW.Math.Point3D lowerPosition,
        double textRotation,
        TextHorizontalAlignment textHorizontalAlignment)
      {
        this.class858_0.method_0(upperPosition, textRotation, textHorizontalAlignment);
        this.class858_1.method_0(lowerPosition, textRotation, textHorizontalAlignment);
      }

      public void method_6(
        WW.Math.Point3D upperPosition,
        WW.Math.Point3D lowerPosition,
        Vector3D textDirection,
        TextHorizontalAlignment textHorizontalAlignment)
      {
        this.class858_0.vmethod_3(upperPosition, textDirection, textHorizontalAlignment);
        this.class858_1.vmethod_3(lowerPosition, textDirection, textHorizontalAlignment);
      }

      public void method_7(double textRotation)
      {
        this.class858_0.vmethod_4(textRotation);
        this.class858_1.vmethod_4(textRotation);
      }
    }
  }
}
