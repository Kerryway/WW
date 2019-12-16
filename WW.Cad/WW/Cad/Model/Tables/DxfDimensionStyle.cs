// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.DxfDimensionStyle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.ComponentModel;

namespace WW.Cad.Model.Tables
{
  [System.ComponentModel.TypeConverter(typeof (SortedPropertiesTypeConverter))]
  public class DxfDimensionStyle : DxfTableRecord, IDimensionStyle
  {
    private StandardFlags standardFlags_0 = StandardFlags.IsReferenced;
    private string string_1 = string.Empty;
    private string string_2 = string.Empty;
    private string string_3 = string.Empty;
    private DxfObjectReference dxfObjectReference_3 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_4 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_5 = DxfObjectReference.Null;
    private double double_0 = 1.0;
    private double double_1 = 0.18;
    private double double_2 = 1.0 / 16.0;
    private double double_3 = 0.38;
    private double double_4 = 0.18;
    private double double_9 = 0.18;
    private double double_10 = 0.09;
    private double double_12 = 1.0;
    private double double_13 = 1.0;
    private double double_15 = 1.0;
    private double double_16 = 0.09;
    private bool bool_2 = true;
    private bool bool_3 = true;
    private short short_0 = 2;
    private Color color_0 = Color.ByBlock;
    private Color color_1 = Color.ByBlock;
    private Color color_2 = Color.ByBlock;
    private short short_2 = 4;
    private AlternateUnitFormat alternateUnitFormat_0 = AlternateUnitFormat.Decimal;
    private LinearUnitFormat linearUnitFormat_0 = LinearUnitFormat.Decimal;
    private char char_0 = '.';
    private ToleranceAlignment toleranceAlignment_0 = ToleranceAlignment.Middle;
    private short short_4 = 4;
    private DxfObjectReference dxfObjectReference_6 = DxfObjectReference.Null;
    private short short_5 = -2;
    private short short_6 = -2;
    private DxfObjectReference dxfObjectReference_7 = DxfObjectReference.Null;
    private double double_18 = 1.0;
    private double double_19 = Math.PI / 4.0;
    private Color color_3 = Color.ByBlock;
    private ArcLengthSymbolPosition arcLengthSymbolPosition_0 = ArcLengthSymbolPosition.AboveDimensionText;
    private DxfObjectReference dxfObjectReference_8 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_9 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_10 = DxfObjectReference.Null;
    private double double_20 = 100.0;
    private string string_4 = string.Empty;
    private double double_21 = 100.0;
    private string string_5 = string.Empty;
    public const double JoggedRadiusDimensionTransverseSegmentAngleDefault = 0.785398163397448;
    public const string DefaultDimensionStyleName = "Standard";
    internal const string string_0 = "DSTYLE";
    private DxfModel dxfModel_0;
    private double double_5;
    private double double_6;
    private double double_7;
    private double double_8;
    private double double_11;
    private double double_14;
    private double double_17;
    private bool bool_0;
    private bool bool_1;
    private bool bool_4;
    private bool bool_5;
    private DimensionTextVerticalAlignment dimensionTextVerticalAlignment_0;
    private ZeroHandling zeroHandling_0;
    private ZeroHandling zeroHandling_1;
    private bool bool_6;
    private bool bool_7;
    private bool bool_8;
    private bool bool_9;
    private bool bool_10;
    private short short_1;
    private short short_3;
    private AngularUnit angularUnit_0;
    private FractionFormat fractionFormat_0;
    private TextMovement textMovement_0;
    private DimensionTextHorizontalAlignment dimensionTextHorizontalAlignment_0;
    private bool bool_11;
    private bool bool_12;
    private ZeroHandling zeroHandling_2;
    private ZeroHandling zeroHandling_3;
    private ZeroHandling zeroHandling_4;
    private CursorUpdate cursorUpdate_0;
    private ArrowsTextFitType arrowsTextFitType_0;
    private bool bool_13;
    private DimensionTextBackgroundFillMode dimensionTextBackgroundFillMode_0;
    private TextDirection textDirection_0;

    public DxfDimensionStyle(DxfModel model)
    {
      this.dxfModel_0 = model;
      if (model == null)
        return;
      this.DimensionLineLineType = model.ByBlockLineType;
      this.FirstExtensionLineLineType = model.ByBlockLineType;
      this.SecondExtensionLineLineType = model.ByBlockLineType;
    }

    public DxfDimensionStyle(DxfModel model, string name)
      : this(model)
    {
      this.string_1 = name;
    }

    protected internal DxfDimensionStyle()
    {
    }

    public string AlternateDimensioningSuffix
    {
      get
      {
        return this.string_3;
      }
      set
      {
        this.string_3 = value ?? string.Empty;
      }
    }

    public short AlternateUnitDecimalPlaces
    {
      get
      {
        return this.short_0;
      }
      set
      {
        this.short_0 = value;
      }
    }

    public bool AlternateUnitDimensioning
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

    public AlternateUnitFormat AlternateUnitFormat
    {
      get
      {
        return this.alternateUnitFormat_0;
      }
      set
      {
        this.alternateUnitFormat_0 = value;
      }
    }

    public double AlternateUnitScaleFactor
    {
      get
      {
        return this.double_12;
      }
      set
      {
        this.double_12 = value;
      }
    }

    public short AlternateUnitToleranceDecimalPlaces
    {
      get
      {
        return this.short_3;
      }
      set
      {
        this.short_3 = value;
      }
    }

    public ZeroHandling AlternateUnitToleranceZeroHandling
    {
      get
      {
        return this.zeroHandling_4;
      }
      set
      {
        this.zeroHandling_4 = value;
      }
    }

    public ZeroHandling AlternateUnitZeroHandling
    {
      get
      {
        return this.zeroHandling_3;
      }
      set
      {
        this.zeroHandling_3 = value;
      }
    }

    public double AlternateUnitRounding
    {
      get
      {
        return this.double_17;
      }
      set
      {
        this.double_17 = value;
      }
    }

    public short AngularDimensionDecimalPlaces
    {
      get
      {
        return this.short_1;
      }
      set
      {
        this.short_1 = value;
      }
    }

    public AngularUnit AngularUnit
    {
      get
      {
        return this.angularUnit_0;
      }
      set
      {
        this.angularUnit_0 = value;
      }
    }

    public ZeroHandling AngularZeroHandling
    {
      get
      {
        return this.zeroHandling_1;
      }
      set
      {
        this.zeroHandling_1 = value;
      }
    }

    public DxfBlock ArrowBlock
    {
      get
      {
        return (DxfBlock) this.dxfObjectReference_3.Value;
      }
      set
      {
        this.dxfObjectReference_3 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public double ArrowSize
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

    public ArrowsTextFitType ArrowsTextFit
    {
      get
      {
        return this.arrowsTextFitType_0;
      }
      set
      {
        this.arrowsTextFitType_0 = value;
      }
    }

    public double FixedExtensionLineLength
    {
      get
      {
        return this.double_18;
      }
      set
      {
        this.double_18 = value;
      }
    }

    public bool IsExtensionLineLengthFixed
    {
      get
      {
        return this.bool_13;
      }
      set
      {
        this.bool_13 = value;
      }
    }

    public double JoggedRadiusDimensionTransverseSegmentAngle
    {
      get
      {
        return this.double_19;
      }
      set
      {
        this.double_19 = value;
      }
    }

    public DimensionTextBackgroundFillMode TextBackgroundFillMode
    {
      get
      {
        return this.dimensionTextBackgroundFillMode_0;
      }
      set
      {
        this.dimensionTextBackgroundFillMode_0 = value;
      }
    }

    public Color TextBackgroundColor
    {
      get
      {
        return this.color_3;
      }
      set
      {
        this.color_3 = value;
      }
    }

    public ArcLengthSymbolPosition ArcLengthSymbolPosition
    {
      get
      {
        return this.arcLengthSymbolPosition_0;
      }
      set
      {
        this.arcLengthSymbolPosition_0 = value;
      }
    }

    public DxfLineType DimensionLineLineType
    {
      get
      {
        return (DxfLineType) this.dxfObjectReference_8.Value;
      }
      set
      {
        this.dxfObjectReference_8 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfLineType FirstExtensionLineLineType
    {
      get
      {
        return (DxfLineType) this.dxfObjectReference_9.Value;
      }
      set
      {
        this.dxfObjectReference_9 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfLineType SecondExtensionLineLineType
    {
      get
      {
        return (DxfLineType) this.dxfObjectReference_10.Value;
      }
      set
      {
        this.dxfObjectReference_10 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public TextDirection TextDirection
    {
      get
      {
        return this.textDirection_0;
      }
      set
      {
        this.textDirection_0 = value;
      }
    }

    public double Mzf
    {
      get
      {
        return this.double_20;
      }
      set
      {
        this.double_20 = value;
      }
    }

    public string Mzs
    {
      get
      {
        return this.string_4;
      }
      set
      {
        this.string_4 = value;
      }
    }

    public double AltMzf
    {
      get
      {
        return this.double_21;
      }
      set
      {
        this.double_21 = value;
      }
    }

    public string AltMzs
    {
      get
      {
        return this.string_5;
      }
      set
      {
        this.string_5 = value;
      }
    }

    public double CenterMarkSize
    {
      get
      {
        return this.double_10;
      }
      set
      {
        this.double_10 = value;
      }
    }

    public CursorUpdate CursorUpdate
    {
      get
      {
        return this.cursorUpdate_0;
      }
      set
      {
        this.cursorUpdate_0 = value;
      }
    }

    public short DecimalPlaces
    {
      get
      {
        return this.short_2;
      }
      set
      {
        this.short_2 = value;
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
      }
    }

    public Color ExtensionLineColor
    {
      get
      {
        return this.color_1;
      }
      set
      {
        this.color_1 = value;
      }
    }

    public double ExtensionLineExtension
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

    public double ExtensionLineOffset
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

    public short ExtensionLineWeight
    {
      get
      {
        return this.short_6;
      }
      set
      {
        this.short_6 = value;
      }
    }

    public DxfBlock FirstArrowBlock
    {
      get
      {
        return (DxfBlock) this.dxfObjectReference_4.Value;
      }
      set
      {
        this.dxfObjectReference_4 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public StandardFlags Flags
    {
      get
      {
        return this.standardFlags_0;
      }
      set
      {
        this.standardFlags_0 = value;
      }
    }

    public override bool IsExternallyDependent
    {
      get
      {
        return (this.standardFlags_0 & StandardFlags.IsExternallyDependent) != StandardFlags.None;
      }
      set
      {
        if (value)
          this.standardFlags_0 |= StandardFlags.IsExternallyDependent;
        else
          this.standardFlags_0 &= ~StandardFlags.IsExternallyDependent;
      }
    }

    public override bool IsResolvedExternalRef
    {
      get
      {
        return (this.standardFlags_0 & StandardFlags.IsResolvedExternalRef) != StandardFlags.None;
      }
      set
      {
        if (value)
          this.standardFlags_0 |= StandardFlags.IsResolvedExternalRef;
        else
          this.standardFlags_0 &= ~StandardFlags.IsResolvedExternalRef;
      }
    }

    public override bool IsReferenced
    {
      get
      {
        return (this.standardFlags_0 & StandardFlags.IsReferenced) != StandardFlags.None;
      }
      set
      {
        if (value)
          this.standardFlags_0 |= StandardFlags.IsReferenced;
        else
          this.standardFlags_0 &= ~StandardFlags.IsReferenced;
      }
    }

    public bool GenerateTolerances
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public DxfBlock LeaderArrowBlock
    {
      get
      {
        return (DxfBlock) this.dxfObjectReference_6.Value;
      }
      set
      {
        this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public bool LimitsGeneration
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public double LinearScaleFactor
    {
      get
      {
        return this.double_13;
      }
      set
      {
        this.double_13 = value;
      }
    }

    public LinearUnitFormat LinearUnitFormat
    {
      get
      {
        return this.linearUnitFormat_0;
      }
      set
      {
        this.linearUnitFormat_0 = value;
      }
    }

    public FractionFormat FractionFormat
    {
      get
      {
        return this.fractionFormat_0;
      }
      set
      {
        this.fractionFormat_0 = value;
      }
    }

    public Color DimensionLineColor
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
      }
    }

    public double DimensionLineExtension
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

    public double DimensionLineGap
    {
      get
      {
        return this.double_16;
      }
      set
      {
        this.double_16 = value;
      }
    }

    public double DimensionLineIncrement
    {
      get
      {
        return this.double_3;
      }
      set
      {
        this.double_3 = value;
      }
    }

    public short DimensionLineWeight
    {
      get
      {
        return this.short_5;
      }
      set
      {
        this.short_5 = value;
      }
    }

    public double MinusTolerance
    {
      get
      {
        return this.double_8;
      }
      set
      {
        this.double_8 = value;
      }
    }

    public override string Name
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value ?? string.Empty;
      }
    }

    public double PlusTolerance
    {
      get
      {
        return this.double_7;
      }
      set
      {
        this.double_7 = value;
      }
    }

    public string PostFix
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value ?? string.Empty;
      }
    }

    public double Rounding
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

    public double ScaleFactor
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
      }
    }

    public DxfBlock SecondArrowBlock
    {
      get
      {
        return (DxfBlock) this.dxfObjectReference_5.Value;
      }
      set
      {
        this.dxfObjectReference_5 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public bool SeparateArrowBlocks
    {
      get
      {
        return this.bool_8;
      }
      set
      {
        this.bool_8 = value;
      }
    }

    public bool SuppressFirstDimensionLine
    {
      get
      {
        return this.bool_11;
      }
      set
      {
        this.bool_11 = value;
      }
    }

    public bool SuppressFirstExtensionLine
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

    public bool SuppressOutsideExtensions
    {
      get
      {
        return this.bool_10;
      }
      set
      {
        this.bool_10 = value;
      }
    }

    public bool SuppressSecondDimensionLine
    {
      get
      {
        return this.bool_12;
      }
      set
      {
        this.bool_12 = value;
      }
    }

    public bool SuppressSecondExtensionLine
    {
      get
      {
        return this.bool_5;
      }
      set
      {
        this.bool_5 = value;
      }
    }

    [Obsolete("Replace with TextVerticalAlignment")]
    public bool TextAboveDimensionLine
    {
      get
      {
        return this.dimensionTextVerticalAlignment_0 == DimensionTextVerticalAlignment.Above;
      }
    }

    public DimensionTextVerticalAlignment TextVerticalAlignment
    {
      get
      {
        return this.dimensionTextVerticalAlignment_0;
      }
      set
      {
        this.dimensionTextVerticalAlignment_0 = value;
      }
    }

    public DimensionTextHorizontalAlignment TextHorizontalAlignment
    {
      get
      {
        return this.dimensionTextHorizontalAlignment_0;
      }
      set
      {
        this.dimensionTextHorizontalAlignment_0 = value;
      }
    }

    public Color TextColor
    {
      get
      {
        return this.color_2;
      }
      set
      {
        this.color_2 = value;
      }
    }

    public double TextHeight
    {
      get
      {
        return this.double_9;
      }
      set
      {
        this.double_9 = value;
      }
    }

    public bool TextInsideExtensions
    {
      get
      {
        return this.bool_9;
      }
      set
      {
        this.bool_9 = value;
      }
    }

    public bool TextInsideHorizontal
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
      }
    }

    public TextMovement TextMovement
    {
      get
      {
        return this.textMovement_0;
      }
      set
      {
        this.textMovement_0 = value;
      }
    }

    public bool TextOutsideExtensions
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

    public bool TextOutsideHorizontal
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

    public DxfTextStyle TextStyle
    {
      get
      {
        if (this.dxfObjectReference_7 == DxfObjectReference.Null)
          this.TextStyle = this.dxfModel_0.GetTextStyleWithName("Standard");
        return (DxfTextStyle) this.dxfObjectReference_7.Value;
      }
      set
      {
        this.dxfObjectReference_7 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfTextStyle TextStyleInternal
    {
      get
      {
        return (DxfTextStyle) this.dxfObjectReference_7.Value;
      }
    }

    public double TextVerticalPosition
    {
      get
      {
        return this.double_14;
      }
      set
      {
        this.double_14 = value;
      }
    }

    public double TickSize
    {
      get
      {
        return this.double_11;
      }
      set
      {
        this.double_11 = value;
      }
    }

    public ToleranceAlignment ToleranceAlignment
    {
      get
      {
        return this.toleranceAlignment_0;
      }
      set
      {
        this.toleranceAlignment_0 = value;
      }
    }

    public short ToleranceDecimalPlaces
    {
      get
      {
        return this.short_4;
      }
      set
      {
        this.short_4 = value;
      }
    }

    public double ToleranceScaleFactor
    {
      get
      {
        return this.double_15;
      }
      set
      {
        this.double_15 = value;
      }
    }

    public ZeroHandling ToleranceZeroHandling
    {
      get
      {
        return this.zeroHandling_2;
      }
      set
      {
        this.zeroHandling_2 = value;
      }
    }

    public ZeroHandling ZeroHandling
    {
      get
      {
        return this.zeroHandling_0;
      }
      set
      {
        this.zeroHandling_0 = value;
      }
    }

    public override void Accept(ITableRecordVisitor visitor)
    {
      visitor.Visit(this);
    }

    public double GetEffectiveTextHeight()
    {
      return DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) this);
    }

    public static double GetEffectiveTextHeight(IDimensionStyle dimensionStyle)
    {
      return DxfDimensionStyle.GetEffectiveTextHeight(dimensionStyle, dimensionStyle.ScaleFactor);
    }

    public static double GetEffectiveTextHeight(IDimensionStyle dimensionStyle, double scale)
    {
      DxfTextStyle textStyle = dimensionStyle.TextStyle;
      if (textStyle != null && textStyle.FixedHeight != 0.0)
        return textStyle.FixedHeight;
      return dimensionStyle.TextHeight * scale;
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      return ValidateUtil.ValidateName((object) this, this.string_1, model, messages);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfDimensionStyle to = (DxfDimensionStyle) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (to == null)
      {
        to = new DxfDimensionStyle(cloneContext.TargetModel);
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) to);
        to.CopyFrom((DxfHandledObject) this, cloneContext);
        cloneContext.CloneBuilders.Add((ICloneBuilder) new DxfDimensionStyle.Class400(this, to));
      }
      return (IGraphCloneable) to;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfDimensionStyle dxfDimensionStyle = (DxfDimensionStyle) from;
      this.standardFlags_0 = dxfDimensionStyle.standardFlags_0;
      this.string_1 = dxfDimensionStyle.string_1;
      this.string_2 = dxfDimensionStyle.string_2;
      this.string_3 = dxfDimensionStyle.string_3;
      this.double_0 = dxfDimensionStyle.double_0;
      this.double_1 = dxfDimensionStyle.double_1;
      this.double_2 = dxfDimensionStyle.double_2;
      this.double_3 = dxfDimensionStyle.double_3;
      this.double_4 = dxfDimensionStyle.double_4;
      this.double_5 = dxfDimensionStyle.double_5;
      this.double_6 = dxfDimensionStyle.double_6;
      this.double_7 = dxfDimensionStyle.double_7;
      this.double_8 = dxfDimensionStyle.double_8;
      this.double_9 = dxfDimensionStyle.double_9;
      this.double_10 = dxfDimensionStyle.double_10;
      this.double_11 = dxfDimensionStyle.double_11;
      this.double_12 = dxfDimensionStyle.double_12;
      this.double_13 = dxfDimensionStyle.double_13;
      this.double_14 = dxfDimensionStyle.double_14;
      this.double_15 = dxfDimensionStyle.double_15;
      this.double_16 = dxfDimensionStyle.double_16;
      this.double_17 = dxfDimensionStyle.double_17;
      this.bool_0 = dxfDimensionStyle.bool_0;
      this.bool_1 = dxfDimensionStyle.bool_1;
      this.bool_2 = dxfDimensionStyle.bool_2;
      this.bool_3 = dxfDimensionStyle.bool_3;
      this.bool_4 = dxfDimensionStyle.bool_4;
      this.bool_5 = dxfDimensionStyle.bool_5;
      this.dimensionTextVerticalAlignment_0 = dxfDimensionStyle.dimensionTextVerticalAlignment_0;
      this.zeroHandling_0 = dxfDimensionStyle.zeroHandling_0;
      this.zeroHandling_1 = dxfDimensionStyle.zeroHandling_1;
      this.bool_6 = dxfDimensionStyle.bool_6;
      this.short_0 = dxfDimensionStyle.short_0;
      this.bool_7 = dxfDimensionStyle.bool_7;
      this.bool_8 = dxfDimensionStyle.bool_8;
      this.bool_9 = dxfDimensionStyle.bool_9;
      this.bool_10 = dxfDimensionStyle.bool_10;
      this.color_0 = dxfDimensionStyle.color_0;
      this.color_1 = dxfDimensionStyle.color_1;
      this.color_2 = dxfDimensionStyle.color_2;
      this.short_1 = dxfDimensionStyle.short_1;
      this.short_2 = dxfDimensionStyle.short_2;
      this.alternateUnitFormat_0 = dxfDimensionStyle.alternateUnitFormat_0;
      this.short_3 = dxfDimensionStyle.short_3;
      this.angularUnit_0 = dxfDimensionStyle.angularUnit_0;
      this.linearUnitFormat_0 = dxfDimensionStyle.linearUnitFormat_0;
      this.fractionFormat_0 = dxfDimensionStyle.fractionFormat_0;
      this.char_0 = dxfDimensionStyle.char_0;
      this.textMovement_0 = dxfDimensionStyle.textMovement_0;
      this.dimensionTextHorizontalAlignment_0 = dxfDimensionStyle.dimensionTextHorizontalAlignment_0;
      this.bool_11 = dxfDimensionStyle.bool_11;
      this.bool_12 = dxfDimensionStyle.bool_12;
      this.toleranceAlignment_0 = dxfDimensionStyle.toleranceAlignment_0;
      this.zeroHandling_2 = dxfDimensionStyle.zeroHandling_2;
      this.short_4 = dxfDimensionStyle.short_4;
      this.zeroHandling_3 = dxfDimensionStyle.zeroHandling_3;
      this.zeroHandling_4 = dxfDimensionStyle.zeroHandling_4;
      this.cursorUpdate_0 = dxfDimensionStyle.cursorUpdate_0;
      this.short_5 = dxfDimensionStyle.short_5;
      this.short_6 = dxfDimensionStyle.short_6;
      this.arrowsTextFitType_0 = dxfDimensionStyle.arrowsTextFitType_0;
      this.double_18 = dxfDimensionStyle.double_18;
      this.bool_13 = dxfDimensionStyle.bool_13;
      this.double_19 = dxfDimensionStyle.double_19;
      this.dimensionTextBackgroundFillMode_0 = dxfDimensionStyle.dimensionTextBackgroundFillMode_0;
      this.color_3 = dxfDimensionStyle.color_3;
      this.arcLengthSymbolPosition_0 = dxfDimensionStyle.arcLengthSymbolPosition_0;
      this.textDirection_0 = dxfDimensionStyle.textDirection_0;
      this.double_20 = dxfDimensionStyle.double_20;
      this.string_4 = dxfDimensionStyle.string_4;
      this.double_21 = dxfDimensionStyle.double_21;
      this.string_5 = dxfDimensionStyle.string_5;
    }

    public DxfDimensionStyle Clone()
    {
      return (DxfDimensionStyle) this.MemberwiseClone();
    }

    public override string ToString()
    {
      return this.Name;
    }

    internal override void vmethod_3(DxfModel modelContext)
    {
      base.vmethod_3(modelContext);
      this.vmethod_2((IDxfHandledObject) modelContext.DimStyleTable);
    }

    internal override void vmethod_4(DxfModel modelContext)
    {
      base.vmethod_4(modelContext);
      this.vmethod_2((IDxfHandledObject) null);
    }

    internal class Class400 : ICloneBuilder
    {
      private DxfDimensionStyle dxfDimensionStyle_0;
      private DxfDimensionStyle dxfDimensionStyle_1;

      public Class400(DxfDimensionStyle from, DxfDimensionStyle to)
      {
        this.dxfDimensionStyle_0 = from;
        this.dxfDimensionStyle_1 = to;
      }

      public void ResolveReferences(CloneContext context)
      {
        this.dxfDimensionStyle_1.ArrowBlock = Class906.smethod_0(context, this.dxfDimensionStyle_0.ArrowBlock, false);
        this.dxfDimensionStyle_1.FirstArrowBlock = Class906.smethod_0(context, this.dxfDimensionStyle_0.FirstArrowBlock, false);
        this.dxfDimensionStyle_1.SecondArrowBlock = Class906.smethod_0(context, this.dxfDimensionStyle_0.SecondArrowBlock, false);
        this.dxfDimensionStyle_1.LeaderArrowBlock = Class906.smethod_0(context, this.dxfDimensionStyle_0.LeaderArrowBlock, false);
        this.dxfDimensionStyle_1.TextStyle = Class906.GetTextStyle(context, this.dxfDimensionStyle_0.TextStyleInternal);
        this.dxfDimensionStyle_1.DimensionLineLineType = Class906.GetLineType(context, this.dxfDimensionStyle_0.DimensionLineLineType);
        this.dxfDimensionStyle_1.FirstExtensionLineLineType = Class906.GetLineType(context, this.dxfDimensionStyle_0.FirstExtensionLineLineType);
        this.dxfDimensionStyle_1.SecondExtensionLineLineType = Class906.GetLineType(context, this.dxfDimensionStyle_0.SecondExtensionLineLineType);
      }
    }
  }
}
