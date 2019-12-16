// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.DxfDimensionStyleOverrides
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using System;
using WW.Cad.Model.Entities;
using WW.ComponentModel;

namespace WW.Cad.Model.Tables
{
  [System.ComponentModel.TypeConverter(typeof (SortedPropertiesTypeConverter))]
  public class DxfDimensionStyleOverrides : IDimensionStyle
  {
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_1 = DxfObjectReference.Null;
    private bool bool_0;
    private bool bool_1;
    private bool bool_2;
    private bool bool_3;
    private bool bool_4;
    private bool bool_5;
    private bool bool_6;
    private bool bool_7;
    private bool bool_8;
    private bool bool_9;
    private bool bool_10;
    private bool bool_11;
    private bool bool_12;
    private bool bool_13;
    private bool bool_14;
    private bool bool_15;
    private bool bool_16;
    private bool bool_17;
    private bool bool_18;
    private bool bool_19;
    private bool bool_20;
    private bool bool_21;
    private bool bool_22;
    private bool bool_23;
    private bool bool_24;
    private bool bool_25;
    private bool bool_26;
    private bool bool_27;
    private bool bool_28;
    private bool bool_29;
    private bool bool_30;
    private bool bool_31;
    private bool bool_32;
    private bool bool_33;
    private bool bool_34;
    private bool bool_35;
    private bool bool_36;
    private bool bool_37;
    private bool bool_38;
    private bool bool_39;
    private bool bool_40;
    private bool bool_41;
    private bool bool_42;
    private bool bool_43;
    private bool bool_44;
    private bool bool_45;
    private bool bool_46;
    private bool bool_47;
    private bool bool_48;
    private bool bool_49;
    private bool bool_50;
    private bool bool_51;
    private bool bool_52;
    private bool bool_53;
    private bool bool_54;
    private bool bool_55;
    private bool bool_56;
    private bool bool_57;
    private bool bool_58;
    private bool bool_59;
    private bool bool_60;
    private bool bool_61;
    private bool bool_62;
    private bool bool_63;
    private bool bool_64;
    private bool bool_65;
    private bool bool_66;
    private bool bool_67;
    private bool bool_68;
    private bool bool_69;
    private bool bool_70;
    private bool bool_71;
    private bool bool_72;
    private bool bool_73;
    private bool bool_74;
    private bool bool_75;
    private bool bool_76;
    private bool bool_77;

    public DxfDimensionStyleOverrides(DxfDimensionStyle baseDimensionStyle, DxfModel model)
      : this(model)
    {
      this.BaseDimensionStyle = baseDimensionStyle;
    }

    internal DxfDimensionStyleOverrides(DxfModel model)
    {
      this.OverrideDimensionStyle = new DxfDimensionStyle(model);
    }

    public DxfDimensionStyle BaseDimensionStyle
    {
      get
      {
        return (DxfDimensionStyle) this.dxfObjectReference_0.Value;
      }
      set
      {
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    private DxfDimensionStyle OverrideDimensionStyle
    {
      get
      {
        return (DxfDimensionStyle) this.dxfObjectReference_1.Value;
      }
      set
      {
        this.dxfObjectReference_1 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public bool HasOverrides
    {
      get
      {
        if (!this.bool_0 && !this.bool_1 && (!this.bool_2 && !this.bool_3) && (!this.bool_4 && !this.bool_5 && (!this.bool_6 && !this.bool_7)) && (!this.bool_8 && !this.bool_9 && (!this.bool_10 && !this.bool_11) && (!this.bool_12 && !this.bool_13 && (!this.bool_14 && !this.bool_15))) && (!this.bool_16 && !this.bool_17 && (!this.bool_18 && !this.bool_19) && (!this.bool_20 && !this.bool_21 && (!this.bool_22 && !this.bool_23)) && (!this.bool_24 && !this.bool_25 && (!this.bool_26 && !this.bool_27) && (!this.bool_28 && !this.bool_29 && (!this.bool_30 && !this.bool_31)))) && (!this.bool_32 && !this.bool_33 && (!this.bool_34 && !this.bool_35) && (!this.bool_36 && !this.bool_37 && (!this.bool_38 && !this.bool_39)) && (!this.bool_40 && !this.bool_41 && (!this.bool_42 && !this.bool_43) && (!this.bool_44 && !this.bool_45 && (!this.bool_46 && !this.bool_47))) && (!this.bool_48 && !this.bool_49 && (!this.bool_50 && !this.bool_51) && (!this.bool_52 && !this.bool_53 && (!this.bool_54 && !this.bool_55)) && (!this.bool_56 && !this.bool_57 && (!this.bool_58 && !this.bool_59) && (!this.bool_60 && !this.bool_61 && (!this.bool_62 && !this.bool_63))))) && (!this.bool_64 && !this.bool_65 && (!this.bool_66 && !this.bool_67) && (!this.bool_68 && !this.bool_69 && (!this.bool_70 && !this.bool_71)) && (!this.bool_72 && !this.bool_73 && (!this.bool_74 && !this.bool_75) && !this.bool_76)))
          return this.bool_77;
        return true;
      }
    }

    public string AlternateDimensioningSuffix
    {
      get
      {
        if (!this.bool_1)
          return this.BaseDimensionStyle.AlternateDimensioningSuffix;
        return this.OverrideDimensionStyle.AlternateDimensioningSuffix;
      }
      set
      {
        this.OverrideDimensionStyle.AlternateDimensioningSuffix = value;
        this.bool_1 = true;
      }
    }

    public short AlternateUnitDecimalPlaces
    {
      get
      {
        if (!this.bool_33)
          return this.BaseDimensionStyle.AlternateUnitDecimalPlaces;
        return this.OverrideDimensionStyle.AlternateUnitDecimalPlaces;
      }
      set
      {
        this.OverrideDimensionStyle.AlternateUnitDecimalPlaces = value;
        this.bool_33 = true;
      }
    }

    public bool AlternateUnitDimensioning
    {
      get
      {
        if (!this.bool_32)
          return this.BaseDimensionStyle.AlternateUnitDimensioning;
        return this.OverrideDimensionStyle.AlternateUnitDimensioning;
      }
      set
      {
        this.OverrideDimensionStyle.AlternateUnitDimensioning = value;
        this.bool_32 = true;
      }
    }

    public AlternateUnitFormat AlternateUnitFormat
    {
      get
      {
        if (!this.bool_43)
          return this.BaseDimensionStyle.AlternateUnitFormat;
        return this.OverrideDimensionStyle.AlternateUnitFormat;
      }
      set
      {
        this.OverrideDimensionStyle.AlternateUnitFormat = value;
        this.bool_43 = true;
      }
    }

    public double AlternateUnitScaleFactor
    {
      get
      {
        if (!this.bool_17)
          return this.BaseDimensionStyle.AlternateUnitScaleFactor;
        return this.OverrideDimensionStyle.AlternateUnitScaleFactor;
      }
      set
      {
        this.OverrideDimensionStyle.AlternateUnitScaleFactor = value;
        this.bool_17 = true;
      }
    }

    public short AlternateUnitToleranceDecimalPlaces
    {
      get
      {
        if (!this.bool_44)
          return this.BaseDimensionStyle.AlternateUnitToleranceDecimalPlaces;
        return this.OverrideDimensionStyle.AlternateUnitToleranceDecimalPlaces;
      }
      set
      {
        this.OverrideDimensionStyle.AlternateUnitToleranceDecimalPlaces = value;
        this.bool_44 = true;
      }
    }

    public ZeroHandling AlternateUnitToleranceZeroHandling
    {
      get
      {
        if (!this.bool_57)
          return this.BaseDimensionStyle.AlternateUnitToleranceZeroHandling;
        return this.OverrideDimensionStyle.AlternateUnitToleranceZeroHandling;
      }
      set
      {
        this.OverrideDimensionStyle.AlternateUnitToleranceZeroHandling = value;
        this.bool_57 = true;
      }
    }

    public ZeroHandling AlternateUnitZeroHandling
    {
      get
      {
        if (!this.bool_56)
          return this.BaseDimensionStyle.AlternateUnitZeroHandling;
        return this.OverrideDimensionStyle.AlternateUnitZeroHandling;
      }
      set
      {
        this.OverrideDimensionStyle.AlternateUnitZeroHandling = value;
        this.bool_56 = true;
      }
    }

    public double AlternateUnitRounding
    {
      get
      {
        if (!this.bool_22)
          return this.BaseDimensionStyle.AlternateUnitRounding;
        return this.OverrideDimensionStyle.AlternateUnitRounding;
      }
      set
      {
        this.OverrideDimensionStyle.AlternateUnitRounding = value;
        this.bool_22 = true;
      }
    }

    public short AngularDimensionDecimalPlaces
    {
      get
      {
        if (!this.bool_41)
          return this.BaseDimensionStyle.AngularDimensionDecimalPlaces;
        return this.OverrideDimensionStyle.AngularDimensionDecimalPlaces;
      }
      set
      {
        this.OverrideDimensionStyle.AngularDimensionDecimalPlaces = value;
        this.bool_41 = true;
      }
    }

    public AngularUnit AngularUnit
    {
      get
      {
        if (!this.bool_45)
          return this.BaseDimensionStyle.AngularUnit;
        return this.OverrideDimensionStyle.AngularUnit;
      }
      set
      {
        this.OverrideDimensionStyle.AngularUnit = value;
        this.bool_45 = true;
      }
    }

    public ZeroHandling AngularZeroHandling
    {
      get
      {
        if (!this.bool_31)
          return this.BaseDimensionStyle.AngularZeroHandling;
        return this.OverrideDimensionStyle.AngularZeroHandling;
      }
      set
      {
        this.OverrideDimensionStyle.AngularZeroHandling = value;
        this.bool_31 = true;
      }
    }

    public DxfBlock ArrowBlock
    {
      get
      {
        if (!this.bool_2)
          return this.BaseDimensionStyle.ArrowBlock;
        return this.OverrideDimensionStyle.ArrowBlock;
      }
      set
      {
        this.OverrideDimensionStyle.ArrowBlock = value;
        this.bool_2 = true;
      }
    }

    public double ArrowSize
    {
      get
      {
        if (!this.bool_6)
          return this.BaseDimensionStyle.ArrowSize;
        return this.OverrideDimensionStyle.ArrowSize;
      }
      set
      {
        this.OverrideDimensionStyle.ArrowSize = value;
        this.bool_6 = true;
      }
    }

    public ArrowsTextFitType ArrowsTextFit
    {
      get
      {
        if (!this.bool_63)
          return this.BaseDimensionStyle.ArrowsTextFit;
        return this.OverrideDimensionStyle.ArrowsTextFit;
      }
      set
      {
        this.OverrideDimensionStyle.ArrowsTextFit = value;
        this.bool_63 = true;
      }
    }

    public double FixedExtensionLineLength
    {
      get
      {
        if (!this.bool_64)
          return this.BaseDimensionStyle.FixedExtensionLineLength;
        return this.OverrideDimensionStyle.FixedExtensionLineLength;
      }
      set
      {
        this.OverrideDimensionStyle.FixedExtensionLineLength = value;
        this.bool_64 = true;
      }
    }

    public bool IsExtensionLineLengthFixed
    {
      get
      {
        if (!this.bool_65)
          return this.BaseDimensionStyle.IsExtensionLineLengthFixed;
        return this.OverrideDimensionStyle.IsExtensionLineLengthFixed;
      }
      set
      {
        this.OverrideDimensionStyle.IsExtensionLineLengthFixed = value;
        this.bool_65 = true;
      }
    }

    public double JoggedRadiusDimensionTransverseSegmentAngle
    {
      get
      {
        if (!this.bool_66)
          return this.BaseDimensionStyle.JoggedRadiusDimensionTransverseSegmentAngle;
        return this.OverrideDimensionStyle.JoggedRadiusDimensionTransverseSegmentAngle;
      }
      set
      {
        this.OverrideDimensionStyle.JoggedRadiusDimensionTransverseSegmentAngle = value;
        this.bool_66 = true;
      }
    }

    public DimensionTextBackgroundFillMode TextBackgroundFillMode
    {
      get
      {
        if (!this.bool_67)
          return this.BaseDimensionStyle.TextBackgroundFillMode;
        return this.OverrideDimensionStyle.TextBackgroundFillMode;
      }
      set
      {
        this.OverrideDimensionStyle.TextBackgroundFillMode = value;
        this.bool_67 = true;
      }
    }

    public Color TextBackgroundColor
    {
      get
      {
        if (!this.bool_68)
          return this.BaseDimensionStyle.TextBackgroundColor;
        return this.OverrideDimensionStyle.TextBackgroundColor;
      }
      set
      {
        this.OverrideDimensionStyle.TextBackgroundColor = value;
        this.bool_68 = true;
      }
    }

    public ArcLengthSymbolPosition ArcLengthSymbolPosition
    {
      get
      {
        if (!this.bool_69)
          return this.BaseDimensionStyle.ArcLengthSymbolPosition;
        return this.OverrideDimensionStyle.ArcLengthSymbolPosition;
      }
      set
      {
        this.OverrideDimensionStyle.ArcLengthSymbolPosition = value;
        this.bool_69 = true;
      }
    }

    public DxfLineType DimensionLineLineType
    {
      get
      {
        if (!this.bool_70)
          return this.BaseDimensionStyle.DimensionLineLineType;
        return this.OverrideDimensionStyle.DimensionLineLineType;
      }
      set
      {
        this.OverrideDimensionStyle.DimensionLineLineType = value;
        this.bool_70 = true;
      }
    }

    public DxfLineType FirstExtensionLineLineType
    {
      get
      {
        if (!this.bool_71)
          return this.BaseDimensionStyle.FirstExtensionLineLineType;
        return this.OverrideDimensionStyle.FirstExtensionLineLineType;
      }
      set
      {
        this.OverrideDimensionStyle.FirstExtensionLineLineType = value;
        this.bool_71 = true;
      }
    }

    public DxfLineType SecondExtensionLineLineType
    {
      get
      {
        if (!this.bool_72)
          return this.BaseDimensionStyle.SecondExtensionLineLineType;
        return this.OverrideDimensionStyle.SecondExtensionLineLineType;
      }
      set
      {
        this.OverrideDimensionStyle.SecondExtensionLineLineType = value;
        this.bool_72 = true;
      }
    }

    public TextDirection TextDirection
    {
      get
      {
        if (!this.bool_73)
          return this.BaseDimensionStyle.TextDirection;
        return this.OverrideDimensionStyle.TextDirection;
      }
      set
      {
        this.OverrideDimensionStyle.TextDirection = value;
        this.bool_73 = true;
      }
    }

    public double Mzf
    {
      get
      {
        if (!this.bool_74)
          return this.BaseDimensionStyle.Mzf;
        return this.OverrideDimensionStyle.Mzf;
      }
      set
      {
        this.OverrideDimensionStyle.Mzf = value;
        this.bool_74 = true;
      }
    }

    public string Mzs
    {
      get
      {
        if (!this.bool_75)
          return this.BaseDimensionStyle.Mzs;
        return this.OverrideDimensionStyle.Mzs;
      }
      set
      {
        this.OverrideDimensionStyle.Mzs = value;
        this.bool_75 = true;
      }
    }

    public double AltMzf
    {
      get
      {
        if (!this.bool_76)
          return this.BaseDimensionStyle.AltMzf;
        return this.OverrideDimensionStyle.AltMzf;
      }
      set
      {
        this.OverrideDimensionStyle.AltMzf = value;
        this.bool_76 = true;
      }
    }

    public string AltMzs
    {
      get
      {
        if (!this.bool_77)
          return this.BaseDimensionStyle.AltMzs;
        return this.OverrideDimensionStyle.AltMzs;
      }
      set
      {
        this.OverrideDimensionStyle.AltMzs = value;
        this.bool_77 = true;
      }
    }

    public double CenterMarkSize
    {
      get
      {
        if (!this.bool_15)
          return this.BaseDimensionStyle.CenterMarkSize;
        return this.OverrideDimensionStyle.CenterMarkSize;
      }
      set
      {
        this.OverrideDimensionStyle.CenterMarkSize = value;
        this.bool_15 = true;
      }
    }

    public CursorUpdate CursorUpdate
    {
      get
      {
        if (!this.bool_58)
          return this.BaseDimensionStyle.CursorUpdate;
        return this.OverrideDimensionStyle.CursorUpdate;
      }
      set
      {
        this.OverrideDimensionStyle.CursorUpdate = value;
        this.bool_58 = true;
      }
    }

    public short DecimalPlaces
    {
      get
      {
        if (!this.bool_42)
          return this.BaseDimensionStyle.DecimalPlaces;
        return this.OverrideDimensionStyle.DecimalPlaces;
      }
      set
      {
        this.OverrideDimensionStyle.DecimalPlaces = value;
        this.bool_42 = true;
      }
    }

    public char DecimalSeparator
    {
      get
      {
        if (!this.bool_48)
          return this.BaseDimensionStyle.DecimalSeparator;
        return this.OverrideDimensionStyle.DecimalSeparator;
      }
      set
      {
        this.OverrideDimensionStyle.DecimalSeparator = value;
        this.bool_48 = true;
      }
    }

    public Color ExtensionLineColor
    {
      get
      {
        if (!this.bool_39)
          return this.BaseDimensionStyle.ExtensionLineColor;
        return this.OverrideDimensionStyle.ExtensionLineColor;
      }
      set
      {
        this.OverrideDimensionStyle.ExtensionLineColor = value;
        this.bool_39 = true;
      }
    }

    public double ExtensionLineExtension
    {
      get
      {
        if (!this.bool_9)
          return this.BaseDimensionStyle.ExtensionLineExtension;
        return this.OverrideDimensionStyle.ExtensionLineExtension;
      }
      set
      {
        this.OverrideDimensionStyle.ExtensionLineExtension = value;
        this.bool_9 = true;
      }
    }

    public double ExtensionLineOffset
    {
      get
      {
        if (!this.bool_7)
          return this.BaseDimensionStyle.ExtensionLineOffset;
        return this.OverrideDimensionStyle.ExtensionLineOffset;
      }
      set
      {
        this.OverrideDimensionStyle.ExtensionLineOffset = value;
        this.bool_7 = true;
      }
    }

    public short ExtensionLineWeight
    {
      get
      {
        if (!this.bool_61)
          return this.BaseDimensionStyle.ExtensionLineWeight;
        return this.OverrideDimensionStyle.ExtensionLineWeight;
      }
      set
      {
        this.OverrideDimensionStyle.ExtensionLineWeight = value;
        this.bool_61 = true;
      }
    }

    public DxfBlock FirstArrowBlock
    {
      get
      {
        if (!this.bool_3)
          return this.BaseDimensionStyle.FirstArrowBlock;
        return this.OverrideDimensionStyle.FirstArrowBlock;
      }
      set
      {
        this.OverrideDimensionStyle.FirstArrowBlock = value;
        this.bool_3 = true;
      }
    }

    public bool GenerateTolerances
    {
      get
      {
        if (!this.bool_23)
          return this.BaseDimensionStyle.GenerateTolerances;
        return this.OverrideDimensionStyle.GenerateTolerances;
      }
      set
      {
        this.OverrideDimensionStyle.GenerateTolerances = value;
        this.bool_23 = true;
      }
    }

    public DxfBlock LeaderArrowBlock
    {
      get
      {
        if (!this.bool_59)
          return this.BaseDimensionStyle.LeaderArrowBlock;
        return this.OverrideDimensionStyle.LeaderArrowBlock;
      }
      set
      {
        this.OverrideDimensionStyle.LeaderArrowBlock = value;
        this.bool_59 = true;
      }
    }

    public bool LimitsGeneration
    {
      get
      {
        if (!this.bool_24)
          return this.BaseDimensionStyle.LimitsGeneration;
        return this.OverrideDimensionStyle.LimitsGeneration;
      }
      set
      {
        this.OverrideDimensionStyle.LimitsGeneration = value;
        this.bool_24 = true;
      }
    }

    public double LinearScaleFactor
    {
      get
      {
        if (!this.bool_18)
          return this.BaseDimensionStyle.LinearScaleFactor;
        return this.OverrideDimensionStyle.LinearScaleFactor;
      }
      set
      {
        this.OverrideDimensionStyle.LinearScaleFactor = value;
        this.bool_18 = true;
      }
    }

    public LinearUnitFormat LinearUnitFormat
    {
      get
      {
        if (!this.bool_46)
          return this.BaseDimensionStyle.LinearUnitFormat;
        return this.OverrideDimensionStyle.LinearUnitFormat;
      }
      set
      {
        this.OverrideDimensionStyle.LinearUnitFormat = value;
        this.bool_46 = true;
      }
    }

    public FractionFormat FractionFormat
    {
      get
      {
        if (!this.bool_47)
          return this.BaseDimensionStyle.FractionFormat;
        return this.OverrideDimensionStyle.FractionFormat;
      }
      set
      {
        this.OverrideDimensionStyle.FractionFormat = value;
        this.bool_47 = true;
      }
    }

    public Color DimensionLineColor
    {
      get
      {
        if (!this.bool_38)
          return this.BaseDimensionStyle.DimensionLineColor;
        return this.OverrideDimensionStyle.DimensionLineColor;
      }
      set
      {
        this.OverrideDimensionStyle.DimensionLineColor = value;
        this.bool_38 = true;
      }
    }

    public double DimensionLineExtension
    {
      get
      {
        if (!this.bool_11)
          return this.BaseDimensionStyle.DimensionLineExtension;
        return this.OverrideDimensionStyle.DimensionLineExtension;
      }
      set
      {
        this.OverrideDimensionStyle.DimensionLineExtension = value;
        this.bool_11 = true;
      }
    }

    public double DimensionLineGap
    {
      get
      {
        if (!this.bool_21)
          return this.BaseDimensionStyle.DimensionLineGap;
        return this.OverrideDimensionStyle.DimensionLineGap;
      }
      set
      {
        this.OverrideDimensionStyle.DimensionLineGap = value;
        this.bool_21 = true;
      }
    }

    public double DimensionLineIncrement
    {
      get
      {
        if (!this.bool_8)
          return this.BaseDimensionStyle.DimensionLineIncrement;
        return this.OverrideDimensionStyle.DimensionLineIncrement;
      }
      set
      {
        this.OverrideDimensionStyle.DimensionLineIncrement = value;
        this.bool_8 = true;
      }
    }

    public short DimensionLineWeight
    {
      get
      {
        if (!this.bool_60)
          return this.BaseDimensionStyle.DimensionLineWeight;
        return this.OverrideDimensionStyle.DimensionLineWeight;
      }
      set
      {
        this.OverrideDimensionStyle.DimensionLineWeight = value;
        this.bool_60 = true;
      }
    }

    public double MinusTolerance
    {
      get
      {
        if (!this.bool_13)
          return this.BaseDimensionStyle.MinusTolerance;
        return this.OverrideDimensionStyle.MinusTolerance;
      }
      set
      {
        this.OverrideDimensionStyle.MinusTolerance = value;
        this.bool_13 = true;
      }
    }

    public double PlusTolerance
    {
      get
      {
        if (!this.bool_12)
          return this.BaseDimensionStyle.PlusTolerance;
        return this.OverrideDimensionStyle.PlusTolerance;
      }
      set
      {
        this.OverrideDimensionStyle.PlusTolerance = value;
        this.bool_12 = true;
      }
    }

    public string PostFix
    {
      get
      {
        if (!this.bool_0)
          return this.BaseDimensionStyle.PostFix;
        return this.OverrideDimensionStyle.PostFix;
      }
      set
      {
        this.OverrideDimensionStyle.PostFix = value;
        this.bool_0 = true;
      }
    }

    public double Rounding
    {
      get
      {
        if (!this.bool_10)
          return this.BaseDimensionStyle.Rounding;
        return this.OverrideDimensionStyle.Rounding;
      }
      set
      {
        this.OverrideDimensionStyle.Rounding = value;
        this.bool_10 = true;
      }
    }

    public double ScaleFactor
    {
      get
      {
        if (!this.bool_5)
          return this.BaseDimensionStyle.ScaleFactor;
        return this.OverrideDimensionStyle.ScaleFactor;
      }
      set
      {
        this.OverrideDimensionStyle.ScaleFactor = value;
        this.bool_5 = true;
      }
    }

    public DxfBlock SecondArrowBlock
    {
      get
      {
        if (!this.bool_4)
          return this.BaseDimensionStyle.SecondArrowBlock;
        return this.OverrideDimensionStyle.SecondArrowBlock;
      }
      set
      {
        this.OverrideDimensionStyle.SecondArrowBlock = value;
        this.bool_4 = true;
      }
    }

    public bool SeparateArrowBlocks
    {
      get
      {
        if (!this.bool_35)
          return this.BaseDimensionStyle.SeparateArrowBlocks;
        return this.OverrideDimensionStyle.SeparateArrowBlocks;
      }
      set
      {
        this.OverrideDimensionStyle.SeparateArrowBlocks = value;
        this.bool_35 = true;
      }
    }

    public bool SuppressFirstDimensionLine
    {
      get
      {
        if (!this.bool_51)
          return this.BaseDimensionStyle.SuppressFirstDimensionLine;
        return this.OverrideDimensionStyle.SuppressFirstDimensionLine;
      }
      set
      {
        this.OverrideDimensionStyle.SuppressFirstDimensionLine = value;
        this.bool_51 = true;
      }
    }

    public bool SuppressFirstExtensionLine
    {
      get
      {
        if (!this.bool_27)
          return this.BaseDimensionStyle.SuppressFirstExtensionLine;
        return this.OverrideDimensionStyle.SuppressFirstExtensionLine;
      }
      set
      {
        this.OverrideDimensionStyle.SuppressFirstExtensionLine = value;
        this.bool_27 = true;
      }
    }

    public bool SuppressOutsideExtensions
    {
      get
      {
        if (!this.bool_37)
          return this.BaseDimensionStyle.SuppressOutsideExtensions;
        return this.OverrideDimensionStyle.SuppressOutsideExtensions;
      }
      set
      {
        this.OverrideDimensionStyle.SuppressOutsideExtensions = value;
        this.bool_37 = true;
      }
    }

    public bool SuppressSecondDimensionLine
    {
      get
      {
        if (!this.bool_52)
          return this.BaseDimensionStyle.SuppressSecondDimensionLine;
        return this.OverrideDimensionStyle.SuppressSecondDimensionLine;
      }
      set
      {
        this.OverrideDimensionStyle.SuppressSecondDimensionLine = value;
        this.bool_52 = true;
      }
    }

    public bool SuppressSecondExtensionLine
    {
      get
      {
        if (!this.bool_28)
          return this.BaseDimensionStyle.SuppressSecondExtensionLine;
        return this.OverrideDimensionStyle.SuppressSecondExtensionLine;
      }
      set
      {
        this.OverrideDimensionStyle.SuppressSecondExtensionLine = value;
        this.bool_28 = true;
      }
    }

    [Obsolete("Replace with property TextVerticalAlignment.")]
    public bool TextAboveDimensionLine
    {
      get
      {
        return this.TextVerticalAlignment == DimensionTextVerticalAlignment.Above;
      }
    }

    public DimensionTextVerticalAlignment TextVerticalAlignment
    {
      get
      {
        if (!this.bool_29)
          return this.BaseDimensionStyle.TextVerticalAlignment;
        return this.OverrideDimensionStyle.TextVerticalAlignment;
      }
      set
      {
        this.OverrideDimensionStyle.TextVerticalAlignment = value;
        this.bool_29 = true;
      }
    }

    public DimensionTextHorizontalAlignment TextHorizontalAlignment
    {
      get
      {
        if (!this.bool_50)
          return this.BaseDimensionStyle.TextHorizontalAlignment;
        return this.OverrideDimensionStyle.TextHorizontalAlignment;
      }
      set
      {
        this.OverrideDimensionStyle.TextHorizontalAlignment = value;
        this.bool_50 = true;
      }
    }

    public Color TextColor
    {
      get
      {
        if (!this.bool_40)
          return this.BaseDimensionStyle.TextColor;
        return this.OverrideDimensionStyle.TextColor;
      }
      set
      {
        this.OverrideDimensionStyle.TextColor = value;
        this.bool_40 = true;
      }
    }

    public double TextHeight
    {
      get
      {
        if (!this.bool_14)
          return this.BaseDimensionStyle.TextHeight;
        return this.OverrideDimensionStyle.TextHeight;
      }
      set
      {
        this.OverrideDimensionStyle.TextHeight = value;
        this.bool_14 = true;
      }
    }

    public bool TextInsideExtensions
    {
      get
      {
        if (!this.bool_36)
          return this.BaseDimensionStyle.TextInsideExtensions;
        return this.OverrideDimensionStyle.TextInsideExtensions;
      }
      set
      {
        this.OverrideDimensionStyle.TextInsideExtensions = value;
        this.bool_36 = true;
      }
    }

    public bool TextInsideHorizontal
    {
      get
      {
        if (!this.bool_25)
          return this.BaseDimensionStyle.TextInsideHorizontal;
        return this.OverrideDimensionStyle.TextInsideHorizontal;
      }
      set
      {
        this.OverrideDimensionStyle.TextInsideHorizontal = value;
        this.bool_25 = true;
      }
    }

    public TextMovement TextMovement
    {
      get
      {
        if (!this.bool_49)
          return this.BaseDimensionStyle.TextMovement;
        return this.OverrideDimensionStyle.TextMovement;
      }
      set
      {
        this.OverrideDimensionStyle.TextMovement = value;
        this.bool_49 = true;
      }
    }

    public bool TextOutsideExtensions
    {
      get
      {
        if (!this.bool_34)
          return this.BaseDimensionStyle.TextOutsideExtensions;
        return this.OverrideDimensionStyle.TextOutsideExtensions;
      }
      set
      {
        this.OverrideDimensionStyle.TextOutsideExtensions = value;
        this.bool_34 = true;
      }
    }

    public bool TextOutsideHorizontal
    {
      get
      {
        if (!this.bool_26)
          return this.BaseDimensionStyle.TextOutsideHorizontal;
        return this.OverrideDimensionStyle.TextOutsideHorizontal;
      }
      set
      {
        this.OverrideDimensionStyle.TextOutsideHorizontal = value;
        this.bool_26 = true;
      }
    }

    public DxfTextStyle TextStyle
    {
      get
      {
        if (!this.bool_62)
          return this.BaseDimensionStyle.TextStyle;
        return this.OverrideDimensionStyle.TextStyle;
      }
      set
      {
        this.OverrideDimensionStyle.TextStyle = value;
        this.bool_62 = true;
      }
    }

    public double TextVerticalPosition
    {
      get
      {
        if (!this.bool_19)
          return this.BaseDimensionStyle.TextVerticalPosition;
        return this.OverrideDimensionStyle.TextVerticalPosition;
      }
      set
      {
        this.OverrideDimensionStyle.TextVerticalPosition = value;
        this.bool_19 = true;
      }
    }

    public double TickSize
    {
      get
      {
        if (!this.bool_16)
          return this.BaseDimensionStyle.TickSize;
        return this.OverrideDimensionStyle.TickSize;
      }
      set
      {
        this.OverrideDimensionStyle.TickSize = value;
        this.bool_16 = true;
      }
    }

    public ToleranceAlignment ToleranceAlignment
    {
      get
      {
        if (!this.bool_53)
          return this.BaseDimensionStyle.ToleranceAlignment;
        return this.OverrideDimensionStyle.ToleranceAlignment;
      }
      set
      {
        this.OverrideDimensionStyle.ToleranceAlignment = value;
        this.bool_53 = true;
      }
    }

    public short ToleranceDecimalPlaces
    {
      get
      {
        if (!this.bool_55)
          return this.BaseDimensionStyle.ToleranceDecimalPlaces;
        return this.OverrideDimensionStyle.ToleranceDecimalPlaces;
      }
      set
      {
        this.OverrideDimensionStyle.ToleranceDecimalPlaces = value;
        this.bool_55 = true;
      }
    }

    public double ToleranceScaleFactor
    {
      get
      {
        if (!this.bool_20)
          return this.BaseDimensionStyle.ToleranceScaleFactor;
        return this.OverrideDimensionStyle.ToleranceScaleFactor;
      }
      set
      {
        this.OverrideDimensionStyle.ToleranceScaleFactor = value;
        this.bool_20 = true;
      }
    }

    public ZeroHandling ToleranceZeroHandling
    {
      get
      {
        if (!this.bool_54)
          return this.BaseDimensionStyle.ToleranceZeroHandling;
        return this.OverrideDimensionStyle.ToleranceZeroHandling;
      }
      set
      {
        this.OverrideDimensionStyle.ToleranceZeroHandling = value;
        this.bool_54 = true;
      }
    }

    public ZeroHandling ZeroHandling
    {
      get
      {
        if (!this.bool_30)
          return this.BaseDimensionStyle.ZeroHandling;
        return this.OverrideDimensionStyle.ZeroHandling;
      }
      set
      {
        this.OverrideDimensionStyle.ZeroHandling = value;
        this.bool_30 = true;
      }
    }

    public DxfDimensionStyleOverrides Clone(CloneContext cloneContext)
    {
      DxfDimensionStyleOverrides dimensionStyleOverrides = new DxfDimensionStyleOverrides(cloneContext.TargetModel);
      dimensionStyleOverrides.CopyFrom(this, cloneContext);
      return dimensionStyleOverrides;
    }

    public void CopyFrom(DxfDimensionStyleOverrides from)
    {
      this.BaseDimensionStyle = from.BaseDimensionStyle;
      if (from.OverrideDimensionStyle != null)
        this.OverrideDimensionStyle = from.OverrideDimensionStyle.Clone();
      this.UpdateOverrideFlags();
    }

    public void UpdateOverrideFlags()
    {
      if (this.BaseDimensionStyle == null || this.OverrideDimensionStyle == null)
        return;
      this.bool_0 = this.bool_0 && this.OverrideDimensionStyle.PostFix != this.BaseDimensionStyle.PostFix;
      this.bool_1 = this.bool_1 && this.OverrideDimensionStyle.AlternateDimensioningSuffix != this.BaseDimensionStyle.AlternateDimensioningSuffix;
      this.bool_2 = this.bool_2 && this.OverrideDimensionStyle.ArrowBlock != this.BaseDimensionStyle.ArrowBlock;
      this.bool_3 = this.bool_3 && this.OverrideDimensionStyle.FirstArrowBlock != this.BaseDimensionStyle.FirstArrowBlock;
      this.bool_4 = this.bool_4 && this.OverrideDimensionStyle.SecondArrowBlock != this.BaseDimensionStyle.SecondArrowBlock;
      this.bool_5 = this.bool_5 && this.OverrideDimensionStyle.ScaleFactor != this.BaseDimensionStyle.ScaleFactor;
      this.bool_6 = this.bool_6 && this.OverrideDimensionStyle.ArrowSize != this.BaseDimensionStyle.ArrowSize;
      this.bool_7 = this.bool_7 && this.OverrideDimensionStyle.ExtensionLineOffset != this.BaseDimensionStyle.ExtensionLineOffset;
      this.bool_8 = this.bool_8 && this.OverrideDimensionStyle.DimensionLineIncrement != this.BaseDimensionStyle.DimensionLineIncrement;
      this.bool_9 = this.bool_9 && this.OverrideDimensionStyle.ExtensionLineExtension != this.BaseDimensionStyle.ExtensionLineExtension;
      this.bool_10 = this.bool_10 && this.OverrideDimensionStyle.Rounding != this.BaseDimensionStyle.Rounding;
      this.bool_11 = this.bool_11 && this.OverrideDimensionStyle.DimensionLineExtension != this.BaseDimensionStyle.DimensionLineExtension;
      this.bool_12 = this.bool_12 && this.OverrideDimensionStyle.PlusTolerance != this.BaseDimensionStyle.PlusTolerance;
      this.bool_13 = this.bool_13 && this.OverrideDimensionStyle.MinusTolerance != this.BaseDimensionStyle.MinusTolerance;
      this.bool_14 = this.bool_14 && this.OverrideDimensionStyle.TextHeight != this.BaseDimensionStyle.TextHeight;
      this.bool_15 = this.bool_15 && this.OverrideDimensionStyle.CenterMarkSize != this.BaseDimensionStyle.CenterMarkSize;
      this.bool_16 = this.bool_16 && this.OverrideDimensionStyle.TickSize != this.BaseDimensionStyle.TickSize;
      this.bool_17 = this.bool_17 && this.OverrideDimensionStyle.AlternateUnitScaleFactor != this.BaseDimensionStyle.AlternateUnitScaleFactor;
      this.bool_18 = this.bool_18 && this.OverrideDimensionStyle.LinearScaleFactor != this.BaseDimensionStyle.LinearScaleFactor;
      this.bool_19 = this.bool_19 && this.OverrideDimensionStyle.TextVerticalPosition != this.BaseDimensionStyle.TextVerticalPosition;
      this.bool_20 = this.bool_20 && this.OverrideDimensionStyle.ToleranceScaleFactor != this.BaseDimensionStyle.ToleranceScaleFactor;
      this.bool_21 = this.bool_21 && this.OverrideDimensionStyle.DimensionLineGap != this.BaseDimensionStyle.DimensionLineGap;
      this.bool_22 = this.bool_22 && this.OverrideDimensionStyle.AlternateUnitRounding != this.BaseDimensionStyle.AlternateUnitRounding;
      this.bool_23 = this.bool_23 && this.OverrideDimensionStyle.GenerateTolerances != this.BaseDimensionStyle.GenerateTolerances;
      this.bool_24 = this.bool_24 && this.OverrideDimensionStyle.LimitsGeneration != this.BaseDimensionStyle.LimitsGeneration;
      this.bool_25 = this.bool_25 && this.OverrideDimensionStyle.TextInsideHorizontal != this.BaseDimensionStyle.TextInsideHorizontal;
      this.bool_26 = this.bool_26 && this.OverrideDimensionStyle.TextOutsideHorizontal != this.BaseDimensionStyle.TextOutsideHorizontal;
      this.bool_27 = this.bool_27 && this.OverrideDimensionStyle.SuppressFirstExtensionLine != this.BaseDimensionStyle.SuppressFirstExtensionLine;
      this.bool_28 = this.bool_28 && this.OverrideDimensionStyle.SuppressSecondExtensionLine != this.BaseDimensionStyle.SuppressSecondExtensionLine;
      this.bool_29 = this.bool_29 && this.OverrideDimensionStyle.TextVerticalAlignment != this.BaseDimensionStyle.TextVerticalAlignment;
      this.bool_30 = this.bool_30 && this.OverrideDimensionStyle.ZeroHandling != this.BaseDimensionStyle.ZeroHandling;
      this.bool_31 = this.bool_31 && this.OverrideDimensionStyle.AngularZeroHandling != this.BaseDimensionStyle.AngularZeroHandling;
      this.bool_32 = this.bool_32 && this.OverrideDimensionStyle.AlternateUnitDimensioning != this.BaseDimensionStyle.AlternateUnitDimensioning;
      this.bool_33 = this.bool_33 && (int) this.OverrideDimensionStyle.AlternateUnitDecimalPlaces != (int) this.BaseDimensionStyle.AlternateUnitDecimalPlaces;
      this.bool_34 = this.bool_34 && this.OverrideDimensionStyle.TextOutsideExtensions != this.BaseDimensionStyle.TextOutsideExtensions;
      this.bool_35 = this.bool_35 && this.OverrideDimensionStyle.SeparateArrowBlocks != this.BaseDimensionStyle.SeparateArrowBlocks;
      this.bool_36 = this.bool_36 && this.OverrideDimensionStyle.TextInsideExtensions != this.BaseDimensionStyle.TextInsideExtensions;
      this.bool_37 = this.bool_37 && this.OverrideDimensionStyle.SuppressOutsideExtensions != this.BaseDimensionStyle.SuppressOutsideExtensions;
      this.bool_38 = this.bool_38 && this.OverrideDimensionStyle.DimensionLineColor != this.BaseDimensionStyle.DimensionLineColor;
      this.bool_39 = this.bool_39 && this.OverrideDimensionStyle.ExtensionLineColor != this.BaseDimensionStyle.ExtensionLineColor;
      this.bool_40 = this.bool_40 && this.OverrideDimensionStyle.TextColor != this.BaseDimensionStyle.TextColor;
      this.bool_41 = this.bool_41 && (int) this.OverrideDimensionStyle.AngularDimensionDecimalPlaces != (int) this.BaseDimensionStyle.AngularDimensionDecimalPlaces;
      this.bool_42 = this.bool_42 && (int) this.OverrideDimensionStyle.DecimalPlaces != (int) this.BaseDimensionStyle.DecimalPlaces;
      this.bool_43 = this.bool_43 && this.OverrideDimensionStyle.AlternateUnitFormat != this.BaseDimensionStyle.AlternateUnitFormat;
      this.bool_44 = this.bool_44 && (int) this.OverrideDimensionStyle.AlternateUnitToleranceDecimalPlaces != (int) this.BaseDimensionStyle.AlternateUnitToleranceDecimalPlaces;
      this.bool_45 = this.bool_45 && this.OverrideDimensionStyle.AngularUnit != this.BaseDimensionStyle.AngularUnit;
      this.bool_46 = this.bool_46 && this.OverrideDimensionStyle.LinearUnitFormat != this.BaseDimensionStyle.LinearUnitFormat;
      this.bool_47 = this.bool_47 && this.OverrideDimensionStyle.FractionFormat != this.BaseDimensionStyle.FractionFormat;
      this.bool_48 = this.bool_48 && (int) this.OverrideDimensionStyle.DecimalSeparator != (int) this.BaseDimensionStyle.DecimalSeparator;
      this.bool_49 = this.bool_49 && this.OverrideDimensionStyle.TextMovement != this.BaseDimensionStyle.TextMovement;
      this.bool_50 = this.bool_50 && this.OverrideDimensionStyle.TextHorizontalAlignment != this.BaseDimensionStyle.TextHorizontalAlignment;
      this.bool_51 = this.bool_51 && this.OverrideDimensionStyle.SuppressFirstDimensionLine != this.BaseDimensionStyle.SuppressFirstDimensionLine;
      this.bool_52 = this.bool_52 && this.OverrideDimensionStyle.SuppressSecondDimensionLine != this.BaseDimensionStyle.SuppressSecondDimensionLine;
      this.bool_53 = this.bool_53 && this.OverrideDimensionStyle.ToleranceAlignment != this.BaseDimensionStyle.ToleranceAlignment;
      this.bool_54 = this.bool_54 && this.OverrideDimensionStyle.ToleranceZeroHandling != this.BaseDimensionStyle.ToleranceZeroHandling;
      this.bool_55 = this.bool_55 && (int) this.OverrideDimensionStyle.ToleranceDecimalPlaces != (int) this.BaseDimensionStyle.ToleranceDecimalPlaces;
      this.bool_56 = this.bool_56 && this.OverrideDimensionStyle.AlternateUnitZeroHandling != this.BaseDimensionStyle.AlternateUnitZeroHandling;
      this.bool_57 = this.bool_57 && this.OverrideDimensionStyle.AlternateUnitToleranceZeroHandling != this.BaseDimensionStyle.AlternateUnitToleranceZeroHandling;
      this.bool_58 = this.bool_58 && this.OverrideDimensionStyle.CursorUpdate != this.BaseDimensionStyle.CursorUpdate;
      this.bool_59 = this.bool_59 && this.OverrideDimensionStyle.LeaderArrowBlock != this.BaseDimensionStyle.LeaderArrowBlock;
      this.bool_60 = this.bool_60 && (int) this.OverrideDimensionStyle.DimensionLineWeight != (int) this.BaseDimensionStyle.DimensionLineWeight;
      this.bool_61 = this.bool_61 && (int) this.OverrideDimensionStyle.ExtensionLineWeight != (int) this.BaseDimensionStyle.ExtensionLineWeight;
      this.bool_62 = this.bool_62 && this.OverrideDimensionStyle.TextStyle != this.BaseDimensionStyle.TextStyle;
      this.bool_63 = this.bool_63 && this.OverrideDimensionStyle.ArrowsTextFit != this.BaseDimensionStyle.ArrowsTextFit;
      this.bool_64 = this.bool_64 && this.OverrideDimensionStyle.FixedExtensionLineLength != this.BaseDimensionStyle.FixedExtensionLineLength;
      this.bool_65 = this.bool_65 && this.OverrideDimensionStyle.IsExtensionLineLengthFixed != this.BaseDimensionStyle.IsExtensionLineLengthFixed;
      this.bool_66 &= this.OverrideDimensionStyle.JoggedRadiusDimensionTransverseSegmentAngle != this.BaseDimensionStyle.JoggedRadiusDimensionTransverseSegmentAngle;
      this.bool_67 &= this.OverrideDimensionStyle.TextBackgroundFillMode != this.BaseDimensionStyle.TextBackgroundFillMode;
      this.bool_68 &= this.OverrideDimensionStyle.TextBackgroundColor != this.BaseDimensionStyle.TextBackgroundColor;
      this.bool_69 &= this.OverrideDimensionStyle.ArcLengthSymbolPosition != this.BaseDimensionStyle.ArcLengthSymbolPosition;
      this.bool_70 &= this.OverrideDimensionStyle.DimensionLineLineType != this.BaseDimensionStyle.DimensionLineLineType;
      this.bool_71 &= this.OverrideDimensionStyle.FirstExtensionLineLineType != this.BaseDimensionStyle.FirstExtensionLineLineType;
      this.bool_72 &= this.OverrideDimensionStyle.SecondExtensionLineLineType != this.BaseDimensionStyle.SecondExtensionLineLineType;
      this.bool_73 = this.bool_73 && this.OverrideDimensionStyle.TextDirection != this.BaseDimensionStyle.TextDirection;
      this.bool_74 = this.bool_74 && this.OverrideDimensionStyle.Mzf != this.BaseDimensionStyle.Mzf;
      this.bool_75 = this.bool_75 && this.OverrideDimensionStyle.Mzs != this.BaseDimensionStyle.Mzs;
      this.bool_76 = this.bool_76 && this.OverrideDimensionStyle.AltMzf != this.BaseDimensionStyle.AltMzf;
      this.bool_77 = this.bool_77 && this.OverrideDimensionStyle.AltMzs != this.BaseDimensionStyle.AltMzs;
    }

    public void CopyFrom(DxfDimensionStyleOverrides from, CloneContext cloneContext)
    {
      if (from.BaseDimensionStyle != null)
        this.BaseDimensionStyle = Class906.smethod_5(cloneContext, from.BaseDimensionStyle);
      if (from.OverrideDimensionStyle != null)
        this.OverrideDimensionStyle = (DxfDimensionStyle) from.OverrideDimensionStyle.Clone(cloneContext);
      this.bool_0 = from.bool_0;
      this.bool_1 = from.bool_1;
      this.bool_2 = from.bool_2;
      this.bool_3 = from.bool_3;
      this.bool_4 = from.bool_4;
      this.bool_5 = from.bool_5;
      this.bool_6 = from.bool_6;
      this.bool_7 = from.bool_7;
      this.bool_8 = from.bool_8;
      this.bool_9 = from.bool_9;
      this.bool_10 = from.bool_10;
      this.bool_11 = from.bool_11;
      this.bool_12 = from.bool_12;
      this.bool_13 = from.bool_13;
      this.bool_14 = from.bool_14;
      this.bool_15 = from.bool_15;
      this.bool_16 = from.bool_16;
      this.bool_17 = from.bool_17;
      this.bool_18 = from.bool_18;
      this.bool_19 = from.bool_19;
      this.bool_20 = from.bool_20;
      this.bool_21 = from.bool_21;
      this.bool_22 = from.bool_22;
      this.bool_23 = from.bool_23;
      this.bool_24 = from.bool_24;
      this.bool_25 = from.bool_25;
      this.bool_26 = from.bool_26;
      this.bool_27 = from.bool_27;
      this.bool_28 = from.bool_28;
      this.bool_29 = from.bool_29;
      this.bool_30 = from.bool_30;
      this.bool_31 = from.bool_31;
      this.bool_32 = from.bool_32;
      this.bool_33 = from.bool_33;
      this.bool_34 = from.bool_34;
      this.bool_35 = from.bool_35;
      this.bool_36 = from.bool_36;
      this.bool_37 = from.bool_37;
      this.bool_38 = from.bool_38;
      this.bool_39 = from.bool_39;
      this.bool_40 = from.bool_40;
      this.bool_41 = from.bool_41;
      this.bool_42 = from.bool_42;
      this.bool_43 = from.bool_43;
      this.bool_44 = from.bool_44;
      this.bool_45 = from.bool_45;
      this.bool_46 = from.bool_46;
      this.bool_47 = from.bool_47;
      this.bool_48 = from.bool_48;
      this.bool_49 = from.bool_49;
      this.bool_50 = from.bool_50;
      this.bool_51 = from.bool_51;
      this.bool_52 = from.bool_52;
      this.bool_53 = from.bool_53;
      this.bool_54 = from.bool_54;
      this.bool_55 = from.bool_55;
      this.bool_56 = from.bool_56;
      this.bool_57 = from.bool_57;
      this.bool_58 = from.bool_58;
      this.bool_59 = from.bool_59;
      this.bool_60 = from.bool_60;
      this.bool_61 = from.bool_61;
      this.bool_62 = from.bool_62;
      this.bool_63 = from.bool_63;
      this.bool_64 = from.bool_64;
      this.bool_65 = from.bool_65;
      this.bool_66 = from.bool_66;
      this.bool_67 = from.bool_67;
      this.bool_68 = from.bool_68;
      this.bool_69 = from.bool_69;
      this.bool_70 = from.bool_70;
      this.bool_71 = from.bool_71;
      this.bool_72 = from.bool_72;
      this.bool_73 = from.bool_73;
      this.bool_74 = from.bool_74;
      this.bool_75 = from.bool_75;
      this.bool_76 = from.bool_76;
      this.bool_77 = from.bool_77;
    }

    public bool OverrideAlternateDimensioningSuffix
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

    public bool OverrideAlternateUnitDecimalPlaces
    {
      get
      {
        return this.bool_33;
      }
      set
      {
        this.bool_33 = value;
      }
    }

    public bool OverrideAlternateUnitDimension
    {
      get
      {
        return this.bool_32;
      }
      set
      {
        this.bool_32 = value;
      }
    }

    public bool OverrideAlternateUnitFormat
    {
      get
      {
        return this.bool_43;
      }
      set
      {
        this.bool_43 = value;
      }
    }

    public bool OverrideAlternateUnitRounding
    {
      get
      {
        return this.bool_22;
      }
      set
      {
        this.bool_22 = value;
      }
    }

    public bool OverrideAlternateUnitScaleFactor
    {
      get
      {
        return this.bool_17;
      }
      set
      {
        this.bool_17 = value;
      }
    }

    public bool OverrideAlternateUnitToleranceDecimalPlaces
    {
      get
      {
        return this.bool_44;
      }
      set
      {
        this.bool_44 = value;
      }
    }

    public bool OverrideAlternateUnitToleranceZeroHandling
    {
      get
      {
        return this.bool_57;
      }
      set
      {
        this.bool_57 = value;
      }
    }

    public bool OverrideAlternateUnitZeroHandling
    {
      get
      {
        return this.bool_56;
      }
      set
      {
        this.bool_56 = value;
      }
    }

    public bool OverrideAngularDimensionDecimalPlaces
    {
      get
      {
        return this.bool_41;
      }
      set
      {
        this.bool_41 = value;
      }
    }

    public bool OverrideAngularUnit
    {
      get
      {
        return this.bool_45;
      }
      set
      {
        this.bool_45 = value;
      }
    }

    public bool OverrideAngularZeroHandling
    {
      get
      {
        return this.bool_31;
      }
      set
      {
        this.bool_31 = value;
      }
    }

    public bool OverrideAlternateUnitDimensioning
    {
      get
      {
        return this.bool_32;
      }
      set
      {
        this.bool_32 = value;
      }
    }

    public bool OverrideArrowBlock
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

    public bool OverrideArrowSize
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

    public bool OverrideArrowsTextFit
    {
      get
      {
        return this.bool_63;
      }
      set
      {
        this.bool_63 = value;
      }
    }

    public bool OverrideFixedExtensionLineLength
    {
      get
      {
        return this.bool_64;
      }
      set
      {
        this.bool_64 = value;
      }
    }

    public bool OverrideIsExtensionLineLengthFixed
    {
      get
      {
        return this.bool_65;
      }
      set
      {
        this.bool_65 = value;
      }
    }

    public bool OverrideJoggedRadiusDimensionTransverseSegmentAngle
    {
      get
      {
        return this.bool_66;
      }
      set
      {
        this.bool_66 = value;
      }
    }

    public bool OverrideTextBackgroundFillMode
    {
      get
      {
        return this.bool_67;
      }
      set
      {
        this.bool_67 = value;
      }
    }

    public bool OverrideTextBackgroundColor
    {
      get
      {
        return this.bool_68;
      }
      set
      {
        this.bool_68 = value;
      }
    }

    public bool OverrideArcLengthSymbolPosition
    {
      get
      {
        return this.bool_69;
      }
      set
      {
        this.bool_69 = value;
      }
    }

    public bool OverrideDimensionLineLineType
    {
      get
      {
        return this.bool_70;
      }
      set
      {
        this.bool_70 = value;
      }
    }

    public bool OverrideFirstExtensionLineLineType
    {
      get
      {
        return this.bool_71;
      }
      set
      {
        this.bool_71 = value;
      }
    }

    public bool OverrideSecondExtensionLineLineType
    {
      get
      {
        return this.bool_72;
      }
      set
      {
        this.bool_72 = value;
      }
    }

    public bool OverrideTextDirection
    {
      get
      {
        return this.bool_73;
      }
      set
      {
        this.bool_73 = value;
      }
    }

    public bool OverrideMzf
    {
      get
      {
        return this.bool_74;
      }
      set
      {
        this.bool_74 = value;
      }
    }

    public bool OverrideMzs
    {
      get
      {
        return this.bool_75;
      }
      set
      {
        this.bool_75 = value;
      }
    }

    public bool OverrideAltMzf
    {
      get
      {
        return this.bool_76;
      }
      set
      {
        this.bool_76 = value;
      }
    }

    public bool OverrideAltMzs
    {
      get
      {
        return this.bool_77;
      }
      set
      {
        this.bool_77 = value;
      }
    }

    public bool OverrideCenterMarkSize
    {
      get
      {
        return this.bool_15;
      }
      set
      {
        this.bool_15 = value;
      }
    }

    public bool OverrideCursorUpdate
    {
      get
      {
        return this.bool_58;
      }
      set
      {
        this.bool_58 = value;
      }
    }

    public bool OverrideDecimalPlaces
    {
      get
      {
        return this.bool_42;
      }
      set
      {
        this.bool_42 = value;
      }
    }

    public bool OverrideDecimalSeparator
    {
      get
      {
        return this.bool_48;
      }
      set
      {
        this.bool_48 = value;
      }
    }

    public bool OverrideExtensionLineColor
    {
      get
      {
        return this.bool_39;
      }
      set
      {
        this.bool_39 = value;
      }
    }

    public bool OverrideExtensionLineExtension
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

    public bool OverrideExtensionLineOffset
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

    public bool OverrideExtensionLineWeight
    {
      get
      {
        return this.bool_61;
      }
      set
      {
        this.bool_61 = value;
      }
    }

    public bool OverrideFirstArrowBlock
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

    public bool OverrideGenerateTolerances
    {
      get
      {
        return this.bool_23;
      }
      set
      {
        this.bool_23 = value;
      }
    }

    public bool OverrideLeaderArrowBlock
    {
      get
      {
        return this.bool_59;
      }
      set
      {
        this.bool_59 = value;
      }
    }

    public bool OverrideLimitsGeneration
    {
      get
      {
        return this.bool_24;
      }
      set
      {
        this.bool_24 = value;
      }
    }

    public bool OverrideLinearScaleFactor
    {
      get
      {
        return this.bool_18;
      }
      set
      {
        this.bool_18 = value;
      }
    }

    public bool OverrideLinearUnitFormat
    {
      get
      {
        return this.bool_46;
      }
      set
      {
        this.bool_46 = value;
      }
    }

    public bool OverrideFractionFormat
    {
      get
      {
        return this.bool_47;
      }
      set
      {
        this.bool_47 = value;
      }
    }

    public bool OverrideDimensionLineColor
    {
      get
      {
        return this.bool_38;
      }
      set
      {
        this.bool_38 = value;
      }
    }

    public bool OverrideDimensionLineExtension
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

    public bool OverrideDimensionLineGap
    {
      get
      {
        return this.bool_21;
      }
      set
      {
        this.bool_21 = value;
      }
    }

    public bool OverrideDimensionLineIncrement
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

    public bool OverrideDimensionLineWeight
    {
      get
      {
        return this.bool_60;
      }
      set
      {
        this.bool_60 = value;
      }
    }

    public bool OverrideMinusTolerance
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

    public bool OverridePlusTolerance
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

    public bool OverridePostFix
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

    public bool OverrideRounding
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

    public bool OverrideScaleFactor
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

    public bool OverrideSecondArrowBlock
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

    public bool OverrideSeparateArrowBlocks
    {
      get
      {
        return this.bool_35;
      }
      set
      {
        this.bool_35 = value;
      }
    }

    public bool OverrideSuppressFirstDimensionLine
    {
      get
      {
        return this.bool_51;
      }
      set
      {
        this.bool_51 = value;
      }
    }

    public bool OverrideSuppressFirstExtensionLine
    {
      get
      {
        return this.bool_27;
      }
      set
      {
        this.bool_27 = value;
      }
    }

    public bool OverrideSuppressOutsideExtensions
    {
      get
      {
        return this.bool_37;
      }
      set
      {
        this.bool_37 = value;
      }
    }

    public bool OverrideSuppressSecondDimensionLine
    {
      get
      {
        return this.bool_52;
      }
      set
      {
        this.bool_52 = value;
      }
    }

    public bool OverrideSuppressSecondExtensionLine
    {
      get
      {
        return this.bool_28;
      }
      set
      {
        this.bool_28 = value;
      }
    }

    public bool OverrideTextVerticalAlignment
    {
      get
      {
        return this.bool_29;
      }
      set
      {
        this.bool_29 = value;
      }
    }

    public bool OverrideTextHorizontalAlignment
    {
      get
      {
        return this.bool_50;
      }
      set
      {
        this.bool_50 = value;
      }
    }

    public bool OverrideTextColor
    {
      get
      {
        return this.bool_40;
      }
      set
      {
        this.bool_40 = value;
      }
    }

    public bool OverrideTextHeight
    {
      get
      {
        return this.bool_14;
      }
      set
      {
        this.bool_14 = value;
      }
    }

    public bool OverrideTextInsideExtensions
    {
      get
      {
        return this.bool_36;
      }
      set
      {
        this.bool_36 = value;
      }
    }

    public bool OverrideTextInsideHorizontal
    {
      get
      {
        return this.bool_25;
      }
      set
      {
        this.bool_25 = value;
      }
    }

    public bool OverrideTextMovement
    {
      get
      {
        return this.bool_49;
      }
      set
      {
        this.bool_49 = value;
      }
    }

    public bool OverrideTextOutsideExtensions
    {
      get
      {
        return this.bool_34;
      }
      set
      {
        this.bool_34 = value;
      }
    }

    public bool OverrideTextOutsideHorizontal
    {
      get
      {
        return this.bool_26;
      }
      set
      {
        this.bool_26 = value;
      }
    }

    public bool OverrideTextStyle
    {
      get
      {
        return this.bool_62;
      }
      set
      {
        this.bool_62 = value;
      }
    }

    public bool OverrideTextVerticalPosition
    {
      get
      {
        return this.bool_19;
      }
      set
      {
        this.bool_19 = value;
      }
    }

    public bool OverrideTickSize
    {
      get
      {
        return this.bool_16;
      }
      set
      {
        this.bool_16 = value;
      }
    }

    public bool OverrideToleranceAlignment
    {
      get
      {
        return this.bool_53;
      }
      set
      {
        this.bool_53 = value;
      }
    }

    public bool OverrideToleranceDecimalPlaces
    {
      get
      {
        return this.bool_55;
      }
      set
      {
        this.bool_55 = value;
      }
    }

    public bool OverrideToleranceScaleFactor
    {
      get
      {
        return this.bool_20;
      }
      set
      {
        this.bool_20 = value;
      }
    }

    public bool OverrideToleranceZeroHandling
    {
      get
      {
        return this.bool_54;
      }
      set
      {
        this.bool_54 = value;
      }
    }

    public bool OverrideZeroHandling
    {
      get
      {
        return this.bool_30;
      }
      set
      {
        this.bool_30 = value;
      }
    }

    internal void method_0(DxfEntity entity)
    {
      if (!this.HasOverrides)
        return;
      DxfModel model = entity.Model;
      DxfExtendedData extendedData;
      if (!entity.ExtendedDataCollection.TryGetValue(model.AppIdAcad, out extendedData))
      {
        extendedData = new DxfExtendedData(model.AppIdAcad);
        entity.ExtendedDataCollection.Add(extendedData);
        if (!model.AppIds.Contains("ACAD"))
          model.AppIds.Add(DxfAppId.smethod_2(true));
      }
      DxfExtendedData.ValueCollection dimStyleValues = (DxfExtendedData.ValueCollection) null;
      for (int index1 = 0; index1 < extendedData.Values.Count; ++index1)
      {
        DxfExtendedData.String @string = extendedData.Values[index1] as DxfExtendedData.String;
        if (@string != null && @string.Value == "DSTYLE")
        {
          int index2 = index1 + 1;
          if (index2 < extendedData.Values.Count)
          {
            dimStyleValues = extendedData.Values[index2] as DxfExtendedData.ValueCollection;
            dimStyleValues.Clear();
            break;
          }
          break;
        }
      }
      if (dimStyleValues == null)
      {
        dimStyleValues = new DxfExtendedData.ValueCollection();
        extendedData.Values.Add((IExtendedDataValue) new DxfExtendedData.String("DSTYLE"));
        extendedData.Values.Add((IExtendedDataValue) dimStyleValues);
      }
      if (this.OverridePostFix)
        DxfDimensionStyleOverrides.smethod_1(dimStyleValues, (short) 3, this.PostFix);
      if (this.OverrideAlternateDimensioningSuffix)
        DxfDimensionStyleOverrides.smethod_1(dimStyleValues, (short) 4, this.AlternateDimensioningSuffix);
      if (!model.Header.Dxf15OrHigher && this.OverrideArrowBlock)
        DxfDimensionStyleOverrides.smethod_1(dimStyleValues, (short) 5, this.ArrowBlock.Name);
      if (!model.Header.Dxf15OrHigher && this.OverrideFirstArrowBlock)
        DxfDimensionStyleOverrides.smethod_1(dimStyleValues, (short) 6, this.FirstArrowBlock.Name);
      if (!model.Header.Dxf15OrHigher && this.OverrideSecondArrowBlock)
        DxfDimensionStyleOverrides.smethod_1(dimStyleValues, (short) 7, this.SecondArrowBlock.Name);
      if (this.OverrideScaleFactor)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 40, this.ScaleFactor);
      if (this.OverrideArrowSize)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 41, this.ArrowSize);
      if (this.OverrideExtensionLineOffset)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 42, this.ExtensionLineOffset);
      if (this.OverrideDimensionLineIncrement)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 43, this.DimensionLineIncrement);
      if (this.OverrideExtensionLineExtension)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 44, this.ExtensionLineExtension);
      if (this.OverrideRounding)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 45, this.Rounding);
      if (this.OverrideDimensionLineExtension)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 46, this.DimensionLineExtension);
      if (this.OverridePlusTolerance)
        DxfDimensionStyleOverrides.smethod_6(dimStyleValues, (short) 47, this.PlusTolerance);
      if (this.OverrideMinusTolerance)
        DxfDimensionStyleOverrides.smethod_6(dimStyleValues, (short) 48, this.MinusTolerance);
      if (this.OverrideTextHeight)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 140, this.TextHeight);
      if (this.OverrideCenterMarkSize)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 141, this.CenterMarkSize);
      if (this.OverrideTickSize)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 142, this.TickSize);
      if (this.OverrideAlternateUnitScaleFactor)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 143, this.AlternateUnitScaleFactor);
      if (this.OverrideLinearScaleFactor)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 144, this.LinearScaleFactor);
      if (this.OverrideTextVerticalPosition)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 145, this.TextVerticalPosition);
      if (this.OverrideToleranceScaleFactor)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 146, this.ToleranceScaleFactor);
      if (this.OverrideDimensionLineGap)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 147, this.DimensionLineGap);
      if (model.Header.Dxf15OrHigher && this.OverrideAlternateUnitRounding)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 148, this.AlternateUnitRounding);
      if (this.OverrideGenerateTolerances)
        DxfDimensionStyleOverrides.smethod_4(dimStyleValues, (short) 71, this.GenerateTolerances);
      if (this.OverrideLimitsGeneration)
        DxfDimensionStyleOverrides.smethod_4(dimStyleValues, (short) 72, this.LimitsGeneration);
      if (this.OverrideTextInsideHorizontal)
        DxfDimensionStyleOverrides.smethod_4(dimStyleValues, (short) 73, this.TextInsideHorizontal);
      if (this.OverrideTextOutsideHorizontal)
        DxfDimensionStyleOverrides.smethod_4(dimStyleValues, (short) 74, this.TextOutsideHorizontal);
      if (this.OverrideSuppressFirstExtensionLine)
        DxfDimensionStyleOverrides.smethod_4(dimStyleValues, (short) 75, this.SuppressFirstExtensionLine);
      if (this.OverrideSuppressSecondExtensionLine)
        DxfDimensionStyleOverrides.smethod_4(dimStyleValues, (short) 76, this.SuppressSecondExtensionLine);
      if (this.OverrideTextVerticalAlignment)
        DxfDimensionStyleOverrides.smethod_3(dimStyleValues, (short) 77, (ushort) this.TextVerticalAlignment);
      if (this.OverrideZeroHandling)
        DxfDimensionStyleOverrides.smethod_3(dimStyleValues, (short) 78, (ushort) this.ZeroHandling);
      if (model.Header.Dxf15OrHigher && this.OverrideAngularZeroHandling)
        DxfDimensionStyleOverrides.smethod_3(dimStyleValues, (short) 79, (ushort) this.AngularZeroHandling);
      if (this.OverrideAlternateUnitDimension)
        DxfDimensionStyleOverrides.smethod_4(dimStyleValues, (short) 170, this.AlternateUnitDimensioning);
      if (this.OverrideAlternateUnitDecimalPlaces)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 171, this.AlternateUnitDecimalPlaces);
      if (this.OverrideTextOutsideExtensions)
        DxfDimensionStyleOverrides.smethod_4(dimStyleValues, (short) 172, this.TextOutsideExtensions);
      if (this.OverrideSeparateArrowBlocks)
        DxfDimensionStyleOverrides.smethod_4(dimStyleValues, (short) 173, this.SeparateArrowBlocks);
      if (this.OverrideTextInsideExtensions)
        DxfDimensionStyleOverrides.smethod_4(dimStyleValues, (short) 174, this.TextInsideExtensions);
      if (this.OverrideSuppressOutsideExtensions)
        DxfDimensionStyleOverrides.smethod_4(dimStyleValues, (short) 175, this.SuppressOutsideExtensions);
      if (this.OverrideDimensionLineColor)
        DxfDimensionStyleOverrides.smethod_7(dimStyleValues, (short) 176, this.DimensionLineColor);
      if (this.OverrideExtensionLineColor)
        DxfDimensionStyleOverrides.smethod_7(dimStyleValues, (short) 177, this.ExtensionLineColor);
      if (this.OverrideTextColor)
        DxfDimensionStyleOverrides.smethod_7(dimStyleValues, (short) 178, this.TextColor);
      if (model.Header.Dxf15OrHigher && this.OverrideAngularDimensionDecimalPlaces)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 179, this.AngularDimensionDecimalPlaces);
      if (model.Header.Dxf13OrHigher && !model.Header.Dxf15OrHigher && this.bool_46)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 270, (short) this.LinearUnitFormat);
      if (model.Header.Dxf13OrHigher && this.OverrideDecimalPlaces)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 271, this.DecimalPlaces);
      if (model.Header.Dxf13OrHigher && this.OverrideToleranceDecimalPlaces)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 272, this.ToleranceDecimalPlaces);
      if (model.Header.Dxf13OrHigher && this.OverrideAlternateUnitFormat)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 273, (short) this.AlternateUnitFormat);
      if (model.Header.Dxf13OrHigher && this.OverrideAlternateUnitToleranceDecimalPlaces)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 274, this.AlternateUnitToleranceDecimalPlaces);
      if (model.Header.Dxf13OrHigher && this.OverrideAngularUnit)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 275, (short) this.AngularUnit);
      if (model.Header.Dxf15OrHigher && this.OverrideFractionFormat)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 276, (short) this.FractionFormat);
      if (model.Header.Dxf15OrHigher && this.OverrideLinearUnitFormat)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 277, (short) this.LinearUnitFormat);
      if (model.Header.Dxf15OrHigher && this.OverrideDecimalSeparator)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 278, (short) this.DecimalSeparator);
      if (model.Header.Dxf15OrHigher && this.OverrideTextMovement)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 279, (short) this.TextMovement);
      if (model.Header.Dxf13OrHigher && this.OverrideTextHorizontalAlignment)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 280, (short) this.TextHorizontalAlignment);
      if (model.Header.Dxf13OrHigher && this.OverrideSuppressFirstDimensionLine)
        DxfDimensionStyleOverrides.smethod_4(dimStyleValues, (short) 281, this.SuppressFirstDimensionLine);
      if (model.Header.Dxf13OrHigher && this.OverrideSuppressSecondDimensionLine)
        DxfDimensionStyleOverrides.smethod_4(dimStyleValues, (short) 282, this.SuppressSecondDimensionLine);
      if (model.Header.Dxf13OrHigher && this.OverrideToleranceAlignment)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 283, (short) this.ToleranceAlignment);
      if (model.Header.Dxf13OrHigher && this.OverrideToleranceZeroHandling)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 284, (short) this.ToleranceZeroHandling);
      if (model.Header.Dxf13OrHigher && this.OverrideAlternateUnitZeroHandling)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 285, (short) this.AlternateUnitZeroHandling);
      if (model.Header.Dxf13OrHigher && this.OverrideAlternateUnitToleranceZeroHandling)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 286, (short) this.AlternateUnitToleranceZeroHandling);
      if (model.Header.Dxf13OrHigher && !model.Header.Dxf15OrHigher && this.OverrideArrowsTextFit)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 287, (short) this.ArrowsTextFit);
      if (model.Header.Dxf13OrHigher && this.OverrideCursorUpdate)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 288, (short) this.CursorUpdate);
      if (model.Header.Dxf24OrHigher && this.OverrideArrowsTextFit)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 289, (short) this.ArrowsTextFit);
      if (model.Header.Dxf13OrHigher && this.OverrideTextStyle)
        DxfDimensionStyleOverrides.smethod_0(dimStyleValues, (short) 340, (DxfHandledObject) this.TextStyle);
      if (model.Header.Dxf15OrHigher && this.OverrideLeaderArrowBlock && this.LeaderArrowBlock != null)
        DxfDimensionStyleOverrides.smethod_0(dimStyleValues, (short) 341, (DxfHandledObject) this.LeaderArrowBlock);
      if (model.Header.Dxf15OrHigher && this.OverrideArrowBlock && this.ArrowBlock != null)
        DxfDimensionStyleOverrides.smethod_0(dimStyleValues, (short) 342, (DxfHandledObject) this.ArrowBlock);
      if (model.Header.Dxf15OrHigher && this.OverrideFirstArrowBlock && this.FirstArrowBlock != null)
        DxfDimensionStyleOverrides.smethod_0(dimStyleValues, (short) 343, (DxfHandledObject) this.FirstArrowBlock);
      if (model.Header.Dxf15OrHigher && this.OverrideSecondArrowBlock && this.SecondArrowBlock != null)
        DxfDimensionStyleOverrides.smethod_0(dimStyleValues, (short) 344, (DxfHandledObject) this.SecondArrowBlock);
      if (model.Header.Dxf15OrHigher && this.OverrideDimensionLineWeight)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 371, this.DimensionLineWeight);
      if (model.Header.Dxf15OrHigher && this.OverrideExtensionLineWeight)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 372, this.ExtensionLineWeight);
      if (model.Header.Dxf21OrHigher && this.OverrideFixedExtensionLineLength)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 49, this.FixedExtensionLineLength);
      if (model.Header.Dxf21OrHigher && this.OverrideIsExtensionLineLengthFixed)
        DxfDimensionStyleOverrides.smethod_4(dimStyleValues, (short) 290, this.IsExtensionLineLengthFixed);
      if (model.Header.Dxf21OrHigher && this.OverrideJoggedRadiusDimensionTransverseSegmentAngle)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 50, this.JoggedRadiusDimensionTransverseSegmentAngle);
      if (model.Header.Dxf21OrHigher && this.OverrideTextBackgroundColor)
        DxfDimensionStyleOverrides.smethod_7(dimStyleValues, (short) 70, this.TextBackgroundColor);
      if (model.Header.Dxf21OrHigher && this.OverrideTextBackgroundFillMode)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 69, (short) this.TextBackgroundFillMode);
      if (model.Header.Dxf21OrHigher && this.OverrideArcLengthSymbolPosition)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, (short) 90, (short) this.ArcLengthSymbolPosition);
      if (model.Header.Dxf21OrHigher && this.OverrideDimensionLineLineType && this.DimensionLineLineType != null)
        DxfDimensionStyleOverrides.smethod_0(dimStyleValues, (short) 345, (DxfHandledObject) this.DimensionLineLineType);
      if (model.Header.Dxf21OrHigher && this.OverrideFirstExtensionLineLineType && this.FirstExtensionLineLineType != null)
        DxfDimensionStyleOverrides.smethod_0(dimStyleValues, (short) 346, (DxfHandledObject) this.FirstExtensionLineLineType);
      if (model.Header.Dxf21OrHigher && this.OverrideSecondExtensionLineLineType && this.SecondExtensionLineLineType != null)
        DxfDimensionStyleOverrides.smethod_0(dimStyleValues, (short) 347, (DxfHandledObject) this.SecondExtensionLineLineType);
      if (model.Header.Dxf24OrHigher && this.OverrideTextDirection)
        DxfDimensionStyleOverrides.smethod_4(dimStyleValues, (short) 295, this.TextDirection == TextDirection.RightToLeft);
      if (model.Header.Dxf24OrHigher && this.OverrideMzf)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 149, this.Mzf);
      if (model.Header.Dxf24OrHigher && this.OverrideMzs)
        DxfDimensionStyleOverrides.smethod_1(dimStyleValues, (short) 8, this.Mzs);
      if (model.Header.Dxf24OrHigher && this.OverrideAltMzf)
        DxfDimensionStyleOverrides.smethod_5(dimStyleValues, (short) 150, this.AltMzf);
      if (!model.Header.Dxf24OrHigher || !this.OverrideAltMzs)
        return;
      DxfDimensionStyleOverrides.smethod_1(dimStyleValues, (short) 9, this.AltMzs);
    }

    private static void smethod_0(
      DxfExtendedData.ValueCollection dimStyleValues,
      short code,
      DxfHandledObject o)
    {
      dimStyleValues.Add((IExtendedDataValue) new DxfExtendedData.Int16(code));
      dimStyleValues.Add((IExtendedDataValue) new DxfExtendedData.DatabaseHandle(o));
    }

    private static void smethod_1(
      DxfExtendedData.ValueCollection dimStyleValues,
      short code,
      string s)
    {
      dimStyleValues.Add((IExtendedDataValue) new DxfExtendedData.Int16(code));
      dimStyleValues.Add((IExtendedDataValue) new DxfExtendedData.String(s));
    }

    private static void smethod_2(
      DxfExtendedData.ValueCollection dimStyleValues,
      short code,
      short i)
    {
      dimStyleValues.Add((IExtendedDataValue) new DxfExtendedData.Int16(code));
      dimStyleValues.Add((IExtendedDataValue) new DxfExtendedData.Int16(i));
    }

    private static void smethod_3(
      DxfExtendedData.ValueCollection dimStyleValues,
      short code,
      ushort i)
    {
      dimStyleValues.Add((IExtendedDataValue) new DxfExtendedData.Int16(code));
      dimStyleValues.Add((IExtendedDataValue) new DxfExtendedData.Int16((short) i));
    }

    private static void smethod_4(
      DxfExtendedData.ValueCollection dimStyleValues,
      short code,
      bool b)
    {
      DxfDimensionStyleOverrides.smethod_2(dimStyleValues, code, b ? (short) 1 : (short) 0);
    }

    private static void smethod_5(
      DxfExtendedData.ValueCollection dimStyleValues,
      short code,
      double d)
    {
      dimStyleValues.Add((IExtendedDataValue) new DxfExtendedData.Int16(code));
      dimStyleValues.Add((IExtendedDataValue) new DxfExtendedData.Double(d));
    }

    private static void smethod_6(
      DxfExtendedData.ValueCollection dimStyleValues,
      short code,
      double d)
    {
      dimStyleValues.Add((IExtendedDataValue) new DxfExtendedData.Int16(code));
      dimStyleValues.Add((IExtendedDataValue) new DxfExtendedData.Distance(d));
    }

    private static void smethod_7(
      DxfExtendedData.ValueCollection dimStyleValues,
      short code,
      Color color)
    {
      if (color == Color.ByLayer)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, code, (short) 256);
      else if (color == Color.ByBlock)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, code, (short) 0);
      else if (color.ColorType == ColorType.ByColorIndex)
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, code, color.ColorIndex);
      else
        DxfDimensionStyleOverrides.smethod_2(dimStyleValues, code, DxfIndexedColorSet.GetColorIndex(color.ToArgbColor(DxfIndexedColorSet.AcadClassicIndexedColors)));
    }
  }
}
