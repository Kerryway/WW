// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.IDimensionStyle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Tables
{
  public interface IDimensionStyle
  {
    string AlternateDimensioningSuffix { get; set; }

    short AlternateUnitDecimalPlaces { get; set; }

    bool AlternateUnitDimensioning { get; set; }

    AlternateUnitFormat AlternateUnitFormat { get; set; }

    double AlternateUnitScaleFactor { get; set; }

    short AlternateUnitToleranceDecimalPlaces { get; set; }

    ZeroHandling AlternateUnitToleranceZeroHandling { get; set; }

    ZeroHandling AlternateUnitZeroHandling { get; set; }

    double AlternateUnitRounding { get; set; }

    short AngularDimensionDecimalPlaces { get; set; }

    AngularUnit AngularUnit { get; set; }

    ZeroHandling AngularZeroHandling { get; set; }

    DxfBlock ArrowBlock { get; set; }

    double ArrowSize { get; set; }

    ArrowsTextFitType ArrowsTextFit { get; set; }

    double CenterMarkSize { get; set; }

    CursorUpdate CursorUpdate { get; set; }

    short DecimalPlaces { get; set; }

    char DecimalSeparator { get; set; }

    Color ExtensionLineColor { get; set; }

    double ExtensionLineExtension { get; set; }

    double ExtensionLineOffset { get; set; }

    short ExtensionLineWeight { get; set; }

    DxfBlock FirstArrowBlock { get; set; }

    bool GenerateTolerances { get; set; }

    DxfBlock LeaderArrowBlock { get; set; }

    bool LimitsGeneration { get; set; }

    double LinearScaleFactor { get; set; }

    LinearUnitFormat LinearUnitFormat { get; set; }

    FractionFormat FractionFormat { get; set; }

    Color DimensionLineColor { get; set; }

    double DimensionLineExtension { get; set; }

    double DimensionLineGap { get; set; }

    double DimensionLineIncrement { get; set; }

    short DimensionLineWeight { get; set; }

    double MinusTolerance { get; set; }

    double PlusTolerance { get; set; }

    string PostFix { get; set; }

    double Rounding { get; set; }

    double ScaleFactor { get; set; }

    DxfBlock SecondArrowBlock { get; set; }

    bool SeparateArrowBlocks { get; set; }

    bool SuppressFirstDimensionLine { get; set; }

    bool SuppressFirstExtensionLine { get; set; }

    bool SuppressOutsideExtensions { get; set; }

    bool SuppressSecondDimensionLine { get; set; }

    bool SuppressSecondExtensionLine { get; set; }

    [Obsolete("Replace with TextVerticalAlignment")]
    bool TextAboveDimensionLine { get; }

    DimensionTextVerticalAlignment TextVerticalAlignment { get; set; }

    DimensionTextHorizontalAlignment TextHorizontalAlignment { get; set; }

    Color TextColor { get; set; }

    double TextHeight { get; set; }

    bool TextInsideExtensions { get; set; }

    bool TextInsideHorizontal { get; set; }

    TextMovement TextMovement { get; set; }

    bool TextOutsideExtensions { get; set; }

    bool TextOutsideHorizontal { get; set; }

    DxfTextStyle TextStyle { get; set; }

    double TextVerticalPosition { get; set; }

    double TickSize { get; set; }

    ToleranceAlignment ToleranceAlignment { get; set; }

    short ToleranceDecimalPlaces { get; set; }

    double ToleranceScaleFactor { get; set; }

    ZeroHandling ToleranceZeroHandling { get; set; }

    ZeroHandling ZeroHandling { get; set; }

    double FixedExtensionLineLength { get; set; }

    bool IsExtensionLineLengthFixed { get; set; }

    double JoggedRadiusDimensionTransverseSegmentAngle { get; set; }

    DimensionTextBackgroundFillMode TextBackgroundFillMode { get; set; }

    Color TextBackgroundColor { get; set; }

    ArcLengthSymbolPosition ArcLengthSymbolPosition { get; set; }

    DxfLineType DimensionLineLineType { get; set; }

    DxfLineType FirstExtensionLineLineType { get; set; }

    DxfLineType SecondExtensionLineLineType { get; set; }
  }
}
