// Decompiled with JetBrains decompiler
// Type: ns28.Class887
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System;
using System.Collections.Generic;
using System.IO;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace ns28
{
  internal class Class887
  {
    private List<IDisposable> list_0 = new List<IDisposable>();
    private DwgReader dwgReader_0;
    private Interface30 interface30_0;
    private Interface30 interface30_1;
    private Interface30 interface30_2;
    private Interface30 interface30_3;
    private Class374 class374_0;

    public Class887(DwgReader dwgReader, Interface30 bitStream, Class374 builder)
    {
      this.dwgReader_0 = dwgReader;
      this.interface30_0 = bitStream;
      this.interface30_1 = bitStream;
      this.interface30_2 = bitStream;
      this.interface30_3 = bitStream;
      this.class374_0 = builder;
    }

    public void method_0()
    {
      DxfHeader header = this.class374_0.Model.Header;
      DxfVersion version = this.class374_0.Version;
      this.interface30_0.imethod_19(16);
      this.interface30_0.imethod_3();
      int num1 = this.interface30_0.imethod_43();
      if (version > DxfVersion.Dxf21 && this.class374_0.Model.Header.AcadMaintenanceVersion > 3 || version > DxfVersion.Dxf27)
        this.interface30_0.imethod_43();
      long num2 = this.interface30_0.imethod_3();
      if (version >= DxfVersion.Dxf21)
      {
        int num3 = this.interface30_0.imethod_43();
        long stringStreamEndBitPosition = num2 + (long) num3 - 1L;
        this.interface30_2 = Class444.Create(version, this.dwgReader_0, (Stream) Class1045.smethod_1(this.interface30_0.Stream, this.interface30_0.Stream.Length, this.dwgReader_0.MemoryPageCache), false);
        this.interface30_2.imethod_5(stringStreamEndBitPosition);
        this.list_0.Add((IDisposable) this.interface30_2.Stream);
        this.interface30_3 = Class444.Create(version, this.dwgReader_0, (Stream) Class1045.smethod_1(this.interface30_0.Stream, this.interface30_0.Stream.Length, this.dwgReader_0.MemoryPageCache), false);
        this.interface30_3.imethod_4(stringStreamEndBitPosition + 1L);
        this.list_0.Add((IDisposable) this.interface30_3.Stream);
        this.interface30_0 = (Interface30) new Class1048(this.interface30_0, this.interface30_2, this.interface30_3);
      }
      if (version > DxfVersion.Dxf24)
        header.RequiredVersions = this.interface30_0.imethod_12();
      this.interface30_0.imethod_8();
      this.interface30_0.imethod_8();
      this.interface30_0.imethod_8();
      this.interface30_0.imethod_8();
      this.interface30_0.ReadString();
      this.interface30_0.ReadString();
      this.interface30_0.ReadString();
      this.interface30_0.ReadString();
      this.interface30_0.imethod_11();
      this.interface30_0.imethod_11();
      if (this.class374_0.IsVersion13Or14)
      {
        int num4 = (int) this.interface30_0.imethod_14();
      }
      if (version < DxfVersion.Dxf18)
        this.class374_0.CurrentViewportHandle = this.interface30_0.imethod_32(false);
      header.AssociatedDimensions = this.interface30_0.imethod_6();
      header.UpdateDimensionsWhileDragging = this.interface30_0.imethod_6();
      if (this.class374_0.IsVersion13Or14)
        header.DimSav = this.interface30_0.imethod_6();
      header.PolylineLineTypeGeneration = (PolylineLineTypeGeneration) this.interface30_0.imethod_7();
      header.OrthoMode = this.interface30_0.imethod_6();
      header.RegenerationMode = this.interface30_0.imethod_6();
      header.FillMode = this.interface30_0.imethod_6();
      header.QuickTextMode = this.interface30_0.imethod_6();
      header.PaperSpaceLineTypeScaling = (PaperSpaceLineTypeScaling) this.interface30_0.imethod_7();
      header.LimitCheckingOn = this.interface30_0.imethod_6();
      if (this.class374_0.IsVersion13Or14)
        this.interface30_0.imethod_6();
      if (version >= DxfVersion.Dxf18)
        this.interface30_0.imethod_6();
      header.UserTimer = this.interface30_0.imethod_6();
      header.SketchPolylines = this.interface30_0.imethod_6();
      header.AngularDirection = (AngularDirection) this.interface30_0.imethod_7();
      header.ShowSplineControlPoints = this.interface30_0.imethod_6();
      if (this.class374_0.IsVersion13Or14)
      {
        this.interface30_0.imethod_6();
        this.interface30_0.imethod_6();
      }
      header.MirrorText = this.interface30_0.imethod_6();
      header.WorldView = this.interface30_0.imethod_6();
      if (this.class374_0.IsVersion13Or14)
        this.interface30_0.imethod_6();
      header.ShowModelSpace = this.interface30_0.imethod_6();
      header.PaperSpaceLimitsChecking = this.interface30_0.imethod_6();
      header.RetainXRefDependentVisibilitySettings = this.interface30_0.imethod_6();
      if (this.class374_0.IsVersion13Or14)
        this.interface30_0.imethod_6();
      header.DisplaySilhouetteCurves = this.interface30_0.imethod_6();
      header.CreateEllipseAsPolyline = this.interface30_0.imethod_6();
      header.ProxyGraphics = this.interface30_0.imethod_15();
      if (this.class374_0.IsVersion13Or14)
      {
        int num5 = (int) this.interface30_0.imethod_14();
      }
      header.SpatialIndexMaxTreeDepth = this.interface30_0.imethod_14();
      header.LinearUnitFormat = (LinearUnitFormat) this.interface30_0.imethod_14();
      header.LinearUnitPrecision = this.interface30_0.imethod_14();
      header.AngularUnit = (AngularUnit) this.interface30_0.imethod_14();
      header.AngularUnitPrecision = this.interface30_0.imethod_14();
      if (this.class374_0.IsVersion13Or14)
        header.ObjectSnapMode = (ObjectSnapMode) this.interface30_0.imethod_14();
      header.AttributeVisibility = (AttributeVisibility) this.interface30_0.imethod_14();
      if (this.class374_0.IsVersion13Or14)
      {
        int num6 = (int) this.interface30_0.imethod_14();
      }
      header.PointDisplayMode = (PointDisplayMode) this.interface30_0.imethod_14();
      if (this.class374_0.IsVersion13Or14)
      {
        int num7 = (int) this.interface30_0.imethod_14();
      }
      if (version >= DxfVersion.Dxf18)
      {
        this.interface30_0.imethod_11();
        this.interface30_0.imethod_11();
        this.interface30_0.imethod_11();
      }
      header.UserShort1 = this.interface30_0.imethod_14();
      header.UserShort2 = this.interface30_0.imethod_14();
      header.UserShort3 = this.interface30_0.imethod_14();
      header.UserShort4 = this.interface30_0.imethod_14();
      header.UserShort5 = this.interface30_0.imethod_14();
      header.NumberOfSplineSegments = this.interface30_0.imethod_14();
      header.SurfaceDensityU = this.interface30_0.imethod_14();
      header.SurfaceDensityV = this.interface30_0.imethod_14();
      header.SurfaceType = this.interface30_0.imethod_14();
      header.SurfaceMeshTabulationCount1 = this.interface30_0.imethod_14();
      header.SurfaceMeshTabulationCount2 = this.interface30_0.imethod_14();
      header.SplineType = (SplineType) this.interface30_0.imethod_14();
      header.ShadeEdge = (ShadeEdge) this.interface30_0.imethod_14();
      header.ShadeDiffuseToAmbientPercentage = this.interface30_0.imethod_14();
      header.UnitMode = this.interface30_0.imethod_14();
      header.MaxViewportCount = this.interface30_0.imethod_14();
      header.SurfaceIsolineCount = this.interface30_0.imethod_14();
      header.CurrentMultilineJustification = (VerticalAlignment) this.interface30_0.imethod_14();
      header.TextQuality = this.interface30_0.imethod_14();
      header.LineTypeScale = this.interface30_0.imethod_8();
      header.TextHeightDefault = this.interface30_0.imethod_8();
      header.TraceWidthDefault = this.interface30_0.imethod_8();
      header.SketchIncrement = this.interface30_0.imethod_8();
      header.FilletRadius = this.interface30_0.imethod_8();
      header.ThicknessDefault = this.interface30_0.imethod_8();
      header.AngleBase = this.interface30_0.imethod_8();
      header.PointDisplaySize = this.interface30_0.imethod_8();
      header.PolylineWidthDefault = this.interface30_0.imethod_8();
      header.UserDouble1 = this.interface30_0.imethod_8();
      header.UserDouble2 = this.interface30_0.imethod_8();
      header.UserDouble3 = this.interface30_0.imethod_8();
      header.UserDouble4 = this.interface30_0.imethod_8();
      header.UserDouble5 = this.interface30_0.imethod_8();
      header.ChamferDistance1 = this.interface30_0.imethod_8();
      header.ChamferDistance2 = this.interface30_0.imethod_8();
      header.ChamferLength = this.interface30_0.imethod_8();
      header.ChamferAngle = this.interface30_0.imethod_8();
      header.FacetResolution = this.interface30_0.imethod_8();
      header.CurrentMultilineScale = this.interface30_0.imethod_8();
      header.CurrentEntityLinetypeScale = this.interface30_0.imethod_8();
      if (!this.class374_0.IsVersion21OrLater)
        header.MenuFileName = this.interface30_0.ReadString();
      header.CreateDateTime = this.interface30_0.imethod_28();
      header.UpdateDateTime = this.interface30_0.imethod_28();
      if (version >= DxfVersion.Dxf18)
      {
        this.interface30_0.imethod_11();
        this.interface30_0.imethod_11();
        this.interface30_0.imethod_11();
      }
      this.class374_0.Model.SummaryInfo.TotalEditingTime = this.interface30_0.imethod_48();
      header.UserElapsedTimeSpan = this.interface30_0.imethod_48();
      header.CurrentEntityColor = this.interface30_0.imethod_22();
      header.HandleSeed = this.interface30_1.imethod_32(false);
      this.class374_0.CurrentLayerHandle = this.interface30_0.imethod_32(false);
      this.class374_0.TextStyleHandle = this.interface30_0.imethod_32(false);
      this.class374_0.CurrentEntityLineTypeHandle = this.interface30_0.imethod_32(false);
      if (version >= DxfVersion.Dxf21)
      {
        long num8 = (long) this.interface30_0.imethod_32(false);
      }
      this.class374_0.CurrentDimensionStyleHandle = this.interface30_0.imethod_32(false);
      this.class374_0.CurrentMultilineStyleHandle = this.interface30_0.imethod_32(false);
      if (this.class374_0.IsVersion15OrLater)
        header.ViewportDefaultViewScaleFactor = this.interface30_0.imethod_8();
      header.PaperSpaceInsertionBase = this.interface30_0.imethod_39();
      header.PaperSpaceExtMin = this.interface30_0.imethod_39();
      header.PaperSpaceExtMax = this.interface30_0.imethod_39();
      header.PaperSpaceLimitsMin = this.interface30_0.imethod_38();
      header.PaperSpaceLimitsMax = this.interface30_0.imethod_38();
      header.PaperSpaceElevation = this.interface30_0.imethod_8();
      header.PaperSpaceUcs.Origin = this.interface30_0.imethod_39();
      header.PaperSpaceUcs.XAxis = this.interface30_0.imethod_51();
      header.PaperSpaceUcs.YAxis = this.interface30_0.imethod_51();
      if (!this.class374_0.IsVersion21OrLater)
        this.class374_0.PaperSpaceUcsHandle = this.interface30_0.imethod_32(false);
      if (this.class374_0.IsVersion15OrLater)
      {
        if (!this.class374_0.IsVersion21OrLater)
        {
          long num3 = (long) this.interface30_0.imethod_32(false);
        }
        int num9 = (int) this.interface30_0.imethod_14();
        if (!this.class374_0.IsVersion21OrLater)
        {
          long num10 = (long) this.interface30_0.imethod_32(false);
        }
        header.PaperSpaceUcs.OrthographicTopDOrigin = this.interface30_0.imethod_51();
        header.PaperSpaceUcs.OrthographicBottomDOrigin = this.interface30_0.imethod_51();
        header.PaperSpaceUcs.OrthographicLeftDOrigin = this.interface30_0.imethod_51();
        header.PaperSpaceUcs.OrthographicRightDOrigin = this.interface30_0.imethod_51();
        header.PaperSpaceUcs.OrthographicFrontDOrigin = this.interface30_0.imethod_51();
        header.PaperSpaceUcs.OrthographicBackDOrigin = this.interface30_0.imethod_51();
      }
      header.InsertionBase = this.interface30_0.imethod_39();
      header.ExtMin = this.interface30_0.imethod_39();
      header.ExtMax = this.interface30_0.imethod_39();
      header.LimitsMin = this.interface30_0.imethod_38();
      header.LimitsMax = this.interface30_0.imethod_38();
      header.Elevation = this.interface30_0.imethod_8();
      header.Ucs.Origin = this.interface30_0.imethod_39();
      header.Ucs.XAxis = this.interface30_0.imethod_51();
      header.Ucs.YAxis = this.interface30_0.imethod_51();
      if (!this.class374_0.IsVersion21OrLater)
        this.class374_0.UcsHandle = this.interface30_0.imethod_32(false);
      if (this.class374_0.IsVersion15OrLater)
      {
        if (!this.class374_0.IsVersion21OrLater)
        {
          long num3 = (long) this.interface30_0.imethod_32(false);
        }
        int num9 = (int) this.interface30_0.imethod_14();
        if (!this.class374_0.IsVersion21OrLater)
        {
          long num10 = (long) this.interface30_0.imethod_32(false);
        }
        header.Ucs.OrthographicTopDOrigin = this.interface30_0.imethod_51();
        header.Ucs.OrthographicBottomDOrigin = this.interface30_0.imethod_51();
        header.Ucs.OrthographicLeftDOrigin = this.interface30_0.imethod_51();
        header.Ucs.OrthographicRightDOrigin = this.interface30_0.imethod_51();
        header.Ucs.OrthographicFrontDOrigin = this.interface30_0.imethod_51();
        header.Ucs.OrthographicBackDOrigin = this.interface30_0.imethod_51();
        if (!this.class374_0.IsVersion21OrLater)
        {
          header.DimensionStyleOverrides.PostFix = this.interface30_0.ReadString();
          header.DimensionStyleOverrides.AlternateDimensioningSuffix = this.interface30_0.ReadString();
        }
      }
      if (this.class374_0.IsVersion13Or14)
      {
        header.DimensionStyleOverrides.GenerateTolerances = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.LimitsGeneration = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.TextInsideHorizontal = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.TextOutsideHorizontal = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.SuppressFirstDimensionLine = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.SuppressSecondDimensionLine = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.AlternateUnitDimensioning = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.TextOutsideExtensions = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.SeparateArrowBlocks = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.TextInsideExtensions = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.SuppressOutsideExtensions = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.AlternateUnitDecimalPlaces = (short) this.interface30_0.imethod_18();
        header.DimensionStyleOverrides.ZeroHandling = (ZeroHandling) this.interface30_0.imethod_18();
        header.DimensionStyleOverrides.SuppressFirstDimensionLine = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.SuppressSecondDimensionLine = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.ToleranceAlignment = (ToleranceAlignment) this.interface30_0.imethod_18();
        header.DimensionStyleOverrides.TextHorizontalAlignment = (DimensionTextHorizontalAlignment) this.interface30_0.imethod_18();
        int num3 = (int) this.interface30_0.imethod_18();
        header.DimensionStyleOverrides.CursorUpdate = (CursorUpdate) this.interface30_0.imethod_7();
        header.DimensionStyleOverrides.ToleranceZeroHandling = (ZeroHandling) this.interface30_0.imethod_18();
        header.DimensionStyleOverrides.AlternateUnitZeroHandling = (ZeroHandling) this.interface30_0.imethod_18();
        header.DimensionStyleOverrides.AlternateUnitToleranceZeroHandling = (ZeroHandling) this.interface30_0.imethod_18();
        header.DimensionStyleOverrides.TextVerticalAlignment = (DimensionTextVerticalAlignment) this.interface30_0.imethod_18();
        int num9 = (int) this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.AngularDimensionDecimalPlaces = this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.DecimalPlaces = this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.ToleranceDecimalPlaces = this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.AlternateUnitFormat = (AlternateUnitFormat) this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.AlternateUnitToleranceDecimalPlaces = this.interface30_0.imethod_14();
        this.class374_0.DimensionStyleTextStyleHandle = this.interface30_0.imethod_32(false);
      }
      header.DimensionStyleOverrides.ScaleFactor = this.interface30_0.imethod_8();
      header.DimensionStyleOverrides.ArrowSize = this.interface30_0.imethod_8();
      header.DimensionStyleOverrides.ExtensionLineOffset = this.interface30_0.imethod_8();
      header.DimensionStyleOverrides.DimensionLineIncrement = this.interface30_0.imethod_8();
      header.DimensionStyleOverrides.ExtensionLineExtension = this.interface30_0.imethod_8();
      header.DimensionStyleOverrides.Rounding = this.interface30_0.imethod_8();
      header.DimensionStyleOverrides.DimensionLineExtension = this.interface30_0.imethod_8();
      header.DimensionStyleOverrides.PlusTolerance = this.interface30_0.imethod_8();
      header.DimensionStyleOverrides.MinusTolerance = this.interface30_0.imethod_8();
      if (version >= DxfVersion.Dxf21)
      {
        header.DimensionStyleOverrides.FixedExtensionLineLength = this.interface30_0.imethod_8();
        header.DimensionStyleOverrides.JoggedRadiusDimensionTransverseSegmentAngle = this.interface30_0.imethod_8();
        header.DimensionStyleOverrides.TextBackgroundFillMode = (DimensionTextBackgroundFillMode) this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.TextBackgroundColor = this.interface30_0.imethod_22();
      }
      if (this.class374_0.IsVersion15OrLater)
      {
        header.DimensionStyleOverrides.GenerateTolerances = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.LimitsGeneration = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.TextInsideHorizontal = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.TextOutsideHorizontal = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.SuppressFirstExtensionLine = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.SuppressSecondExtensionLine = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.TextVerticalAlignment = (DimensionTextVerticalAlignment) this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.ZeroHandling = (ZeroHandling) this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.AngularZeroHandling = (ZeroHandling) this.interface30_0.imethod_14();
      }
      if (version >= DxfVersion.Dxf21)
        header.DimensionStyleOverrides.ArcLengthSymbolPosition = (ArcLengthSymbolPosition) this.interface30_0.imethod_14();
      header.DimensionStyleOverrides.TextHeight = this.interface30_0.imethod_8();
      header.DimensionStyleOverrides.CenterMarkSize = this.interface30_0.imethod_8();
      header.DimensionStyleOverrides.TickSize = this.interface30_0.imethod_8();
      header.DimensionStyleOverrides.AlternateUnitScaleFactor = this.interface30_0.imethod_8();
      header.DimensionStyleOverrides.LinearScaleFactor = this.interface30_0.imethod_8();
      header.DimensionStyleOverrides.TextVerticalPosition = this.interface30_0.imethod_8();
      header.DimensionStyleOverrides.ToleranceScaleFactor = this.interface30_0.imethod_8();
      header.DimensionStyleOverrides.DimensionLineGap = this.interface30_0.imethod_8();
      if (this.class374_0.IsVersion13Or14)
      {
        header.DimensionStyleOverrides.PostFix = this.interface30_0.ReadString();
        header.DimensionStyleOverrides.AlternateDimensioningSuffix = this.interface30_0.ReadString();
        this.class374_0.DimensionStyleArrowBlockName = this.interface30_0.ReadString();
        this.class374_0.DimensionStyleFirstArrowBlockName = this.interface30_0.ReadString();
        this.class374_0.DimensionStyleSecondArrowBlockName = this.interface30_0.ReadString();
      }
      if (this.class374_0.IsVersion15OrLater)
      {
        header.DimensionStyleOverrides.AlternateUnitRounding = this.interface30_0.imethod_8();
        header.DimensionStyleOverrides.AlternateUnitDimensioning = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.AlternateUnitDecimalPlaces = this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.TextOutsideExtensions = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.SeparateArrowBlocks = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.TextInsideExtensions = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.SuppressOutsideExtensions = this.interface30_0.imethod_6();
      }
      header.DimensionStyleOverrides.DimensionLineColor = this.interface30_0.imethod_22();
      header.DimensionStyleOverrides.ExtensionLineColor = this.interface30_0.imethod_22();
      header.DimensionStyleOverrides.TextColor = this.interface30_0.imethod_22();
      if (this.class374_0.IsVersion15OrLater)
      {
        header.DimensionStyleOverrides.AngularDimensionDecimalPlaces = this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.DecimalPlaces = this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.ToleranceDecimalPlaces = this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.AlternateUnitFormat = (AlternateUnitFormat) this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.AlternateUnitToleranceDecimalPlaces = this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.AngularDimensionDecimalPlaces = this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.FractionFormat = (FractionFormat) this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.LinearUnitFormat = (LinearUnitFormat) this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.DecimalSeparator = (char) this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.TextMovement = (TextMovement) this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.TextHorizontalAlignment = (DimensionTextHorizontalAlignment) this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.SuppressFirstDimensionLine = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.SuppressSecondDimensionLine = this.interface30_0.imethod_6();
        header.DimensionStyleOverrides.ToleranceAlignment = (ToleranceAlignment) this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.ToleranceZeroHandling = (ZeroHandling) this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.AlternateUnitZeroHandling = (ZeroHandling) this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.AlternateUnitToleranceZeroHandling = (ZeroHandling) this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.CursorUpdate = (CursorUpdate) this.interface30_0.imethod_7();
        int num3 = (int) this.interface30_0.imethod_14();
      }
      if (version >= DxfVersion.Dxf21)
        header.DimensionStyleOverrides.IsExtensionLineLengthFixed = this.interface30_0.imethod_6();
      if (version >= DxfVersion.Dxf24)
      {
        header.DimensionStyleOverrides.TextDirection = this.interface30_0.imethod_6() ? TextDirection.RightToLeft : TextDirection.LeftToRight;
        header.DimensionStyleOverrides.AltMzf = this.interface30_0.imethod_8();
        header.DimensionStyleOverrides.Mzf = this.interface30_0.imethod_8();
      }
      if (this.class374_0.Version >= DxfVersion.Dxf15 && this.class374_0.Version <= DxfVersion.Dxf18)
      {
        this.class374_0.DimensionStyleTextStyleHandle = this.interface30_0.imethod_32(false);
        this.class374_0.DimensionStyleLeaderArrowBlockHandle = this.interface30_0.imethod_32(false);
        this.class374_0.DimensionStyleArrowBlockHandle = this.interface30_0.imethod_32(false);
        this.class374_0.DimensionStyleFirstArrowBlockHandle = this.interface30_0.imethod_32(false);
        this.class374_0.DimensionStyleSecondArrowBlockHandle = this.interface30_0.imethod_32(false);
      }
      if (this.class374_0.IsVersion15OrLater)
      {
        header.DimensionStyleOverrides.DimensionLineWeight = this.interface30_0.imethod_14();
        header.DimensionStyleOverrides.ExtensionLineWeight = this.interface30_0.imethod_14();
      }
      if (!this.class374_0.IsVersion21OrLater)
      {
        long num3 = (long) this.method_1();
        long num9 = (long) this.method_1();
        long num10 = (long) this.method_1();
        long num11 = (long) this.method_1();
        long num12 = (long) this.method_1();
        long num13 = (long) this.method_1();
        long num14 = (long) this.method_1();
        long num15 = (long) this.method_1();
        long num16 = (long) this.method_1();
        if (version >= DxfVersion.Dxf13 && version <= DxfVersion.Dxf15)
        {
          long num17 = (long) this.method_1();
        }
        long num18 = (long) this.interface30_0.imethod_32(false);
        long num19 = (long) this.interface30_0.imethod_32(false);
        long num20 = (long) this.method_1();
      }
      if (this.class374_0.IsVersion15OrLater)
      {
        header.StackedTextAlignment = (VerticalAlignment) (2 - (int) this.interface30_0.imethod_14());
        header.StackedTextSizePercentage = this.interface30_0.imethod_14();
        if (!this.class374_0.IsVersion21OrLater)
        {
          this.class374_0.Model.SummaryInfo.HyperLinkBase = this.interface30_0.ReadString();
          this.interface30_0.ReadString();
          this.class374_0.LayoutsDictionaryHandle = this.interface30_0.imethod_32(false);
          long num3 = (long) this.interface30_0.imethod_32(false);
          long num9 = (long) this.interface30_0.imethod_32(false);
        }
      }
      if (!this.class374_0.IsVersion21OrLater)
      {
        if (version > DxfVersion.Dxf15)
        {
          long num3 = (long) this.interface30_0.imethod_32(false);
          long num9 = (long) this.interface30_0.imethod_32(false);
        }
        if (version > DxfVersion.Dxf18)
        {
          long num10 = (long) this.interface30_0.imethod_32(false);
        }
      }
      if (this.class374_0.IsVersion15OrLater)
      {
        int num3 = this.interface30_0.imethod_11();
        header.CurrentEntityLineWeight = (short) (num3 & 31);
        header.EndCaps = (EndCaps) ((num3 & 96) >> 5);
        header.JoinStyle = (JoinStyle) ((num3 & 384) >> 7);
        header.DisplayLineWeight = (num3 & 512) == 0;
        header.XEdit = (num3 & 1024) == 0;
        header.ExtendedNames = (num3 & 2048) == 2048;
        header.PlotStyleMode = (num3 & 8192) == 8192 ? PlotStyleMode.ColorDependent : PlotStyleMode.Named;
        header.InsUnits = (DrawingUnits) this.interface30_0.imethod_14();
        header.CurrentEntityPlotStyleType = (PlotStyleType) this.interface30_0.imethod_14();
        if (!this.class374_0.IsVersion21OrLater)
        {
          if (header.CurrentEntityPlotStyleType == PlotStyleType.ByObjectId)
          {
            long num9 = (long) this.interface30_0.imethod_32(false);
          }
          header.FingerPrintGuid = this.interface30_0.ReadString();
          header.VersionGuid = this.interface30_0.ReadString();
        }
      }
      if (version >= DxfVersion.Dxf18)
      {
        header.EntitySortingFlags = (ObjectSortingFlags) this.interface30_0.imethod_18();
        header.IndexCreationFlags = (IndexCreationFlags) this.interface30_0.imethod_18();
        int num3 = (int) this.interface30_0.imethod_18();
        header.ExternalReferenceClippingBoundaryType = (SimpleLineType) this.interface30_0.imethod_18();
        header.DimensionAssociativity = (DimensionAssociativity) this.interface30_0.imethod_18();
        header.HaloGapPercentage = this.interface30_0.imethod_18();
        short colorIndex1 = this.interface30_0.imethod_14();
        header.ObscuredColor = Color.CreateFromColorIndex(colorIndex1);
        short colorIndex2 = this.interface30_0.imethod_14();
        header.InterfereColor = Color.CreateFromColorIndex(colorIndex2);
        int num9 = (int) this.interface30_0.imethod_18();
        header.IntersectionDisplay = this.interface30_0.imethod_18() != (byte) 0;
        if (!this.class374_0.IsVersion21OrLater)
          header.ProjectName = this.interface30_0.ReadString();
      }
      if (!this.class374_0.IsVersion21OrLater)
      {
        this.class374_0.PaperSpaceBlockRecordHandle = this.interface30_0.imethod_32(false);
        this.class374_0.ModelSpaceBlockRecordHandle = this.interface30_0.imethod_32(false);
        this.class374_0.ByLayerLineTypeHandle = this.interface30_0.imethod_32(false);
        this.class374_0.ByBlockLineTypeHandle = this.interface30_0.imethod_32(false);
        this.class374_0.ContinuousLineTypeHandle = this.interface30_0.imethod_32(false);
      }
      if (version >= DxfVersion.Dxf21)
      {
        this.interface30_0.imethod_6();
        this.interface30_0.imethod_11();
        this.interface30_0.imethod_11();
        this.interface30_0.imethod_8();
        this.interface30_0.imethod_8();
        this.interface30_0.imethod_8();
        this.interface30_0.imethod_8();
        this.interface30_0.imethod_8();
        this.interface30_0.imethod_8();
        int num3 = (int) this.interface30_0.imethod_18();
        int num9 = (int) this.interface30_0.imethod_18();
        this.interface30_0.imethod_8();
        this.interface30_0.imethod_8();
        this.interface30_0.imethod_8();
        this.interface30_0.imethod_8();
        this.interface30_0.imethod_8();
        this.interface30_0.imethod_8();
        int num10 = (int) this.interface30_0.imethod_14();
        int num11 = (int) this.interface30_0.imethod_18();
        this.interface30_0.imethod_8();
        this.interface30_0.imethod_8();
        this.interface30_0.imethod_8();
        this.interface30_0.imethod_11();
        int num12 = (int) this.interface30_0.imethod_18();
        int num13 = (int) this.interface30_0.imethod_18();
        int num14 = (int) this.interface30_0.imethod_18();
        int num15 = (int) this.interface30_0.imethod_18();
        this.interface30_0.imethod_6();
        header.InterfereColor = this.interface30_0.imethod_22();
        if (!this.class374_0.IsVersion21OrLater)
        {
          long num16 = (long) this.interface30_0.imethod_32(false);
          long num17 = (long) this.interface30_0.imethod_32(false);
          long num18 = (long) this.interface30_0.imethod_32(false);
        }
        header.ShadowMode = (ShadowMode) this.interface30_0.imethod_18();
        header.ShadowPlaneLocation = this.interface30_0.imethod_8();
      }
      if (this.class374_0.IsVersion21OrLater)
      {
        header.MenuFileName = this.interface30_0.ReadString();
        header.DimensionStyleOverrides.PostFix = this.interface30_0.ReadString();
        header.DimensionStyleOverrides.AlternateDimensioningSuffix = this.interface30_0.ReadString();
        if (this.class374_0.Version > DxfVersion.Dxf21)
        {
          header.DimensionStyleOverrides.AltMzs = this.interface30_0.ReadString();
          header.DimensionStyleOverrides.Mzs = this.interface30_0.ReadString();
        }
        this.class374_0.Model.SummaryInfo.HyperLinkBase = this.interface30_0.ReadString();
        this.interface30_0.ReadString();
        header.FingerPrintGuid = this.interface30_0.ReadString();
        header.VersionGuid = this.interface30_0.ReadString();
        this.interface30_0.ReadString();
        this.class374_0.PaperSpaceUcsHandle = this.interface30_0.imethod_32(false);
        long num3 = (long) this.interface30_0.imethod_32(false);
        long num9 = (long) this.interface30_0.imethod_32(false);
        this.class374_0.UcsHandle = this.interface30_0.imethod_32(false);
        long num10 = (long) this.interface30_0.imethod_32(false);
        long num11 = (long) this.interface30_0.imethod_32(false);
        this.class374_0.DimensionStyleTextStyleHandle = this.interface30_0.imethod_32(false);
        this.class374_0.DimensionStyleLeaderArrowBlockHandle = this.interface30_0.imethod_32(false);
        this.class374_0.DimensionStyleArrowBlockHandle = this.interface30_0.imethod_32(false);
        this.class374_0.DimensionStyleFirstArrowBlockHandle = this.interface30_0.imethod_32(false);
        this.class374_0.DimensionStyleSecondArrowBlockHandle = this.interface30_0.imethod_32(false);
        this.class374_0.DimStyleDimensionLineLineTypeHandle = this.interface30_0.imethod_32(false);
        this.class374_0.DimStyleFirstExtensionLineLineTypeHandle = this.interface30_0.imethod_32(false);
        this.class374_0.DimStyleSecondExtensionLineLineTypeHandle = this.interface30_0.imethod_32(false);
        long num12 = (long) this.method_1();
        long num13 = (long) this.method_1();
        long num14 = (long) this.method_1();
        long num15 = (long) this.method_1();
        long num16 = (long) this.method_1();
        long num17 = (long) this.method_1();
        long num18 = (long) this.method_1();
        long num19 = (long) this.method_1();
        long num20 = (long) this.method_1();
        long num21 = (long) this.interface30_0.imethod_32(false);
        long num22 = (long) this.interface30_0.imethod_32(false);
        long num23 = (long) this.method_1();
        this.class374_0.LayoutsDictionaryHandle = this.interface30_0.imethod_32(false);
        long num24 = (long) this.interface30_0.imethod_32(false);
        long num25 = (long) this.interface30_0.imethod_32(false);
        long num26 = (long) this.interface30_0.imethod_32(false);
        long num27 = (long) this.interface30_0.imethod_32(false);
        long num28 = (long) this.interface30_0.imethod_32(false);
        if (version > DxfVersion.Dxf24)
        {
          long num29 = (long) this.interface30_0.imethod_32(false);
        }
        if (header.CurrentEntityPlotStyleType == PlotStyleType.ByObjectId)
        {
          long num30 = (long) this.interface30_0.imethod_32(false);
        }
        this.class374_0.PaperSpaceBlockRecordHandle = this.interface30_0.imethod_32(false);
        this.class374_0.ModelSpaceBlockRecordHandle = this.interface30_0.imethod_32(false);
        this.class374_0.ByLayerLineTypeHandle = this.interface30_0.imethod_32(false);
        this.class374_0.ByBlockLineTypeHandle = this.interface30_0.imethod_32(false);
        this.class374_0.ContinuousLineTypeHandle = this.interface30_0.imethod_32(false);
        long num31 = (long) this.interface30_0.imethod_32(false);
        long num32 = (long) this.interface30_0.imethod_32(false);
        long num33 = (long) this.interface30_0.imethod_32(false);
      }
      this.interface30_0 = this.interface30_3;
      if (header.AcadVersion >= DxfVersion.Dxf14)
      {
        try
        {
          int num3 = (int) this.interface30_0.imethod_14();
          int num9 = (int) this.interface30_0.imethod_14();
          int num10 = (int) this.interface30_0.imethod_14();
          int num11 = (int) this.interface30_0.imethod_14();
          if (header.AcadVersion >= DxfVersion.Dxf18)
          {
            this.interface30_0.imethod_11();
            this.interface30_0.imethod_11();
            this.interface30_0.imethod_6();
          }
        }
        catch (DxfException ex)
        {
        }
      }
      if (this.interface30_0.BitIndex > 0)
      {
        for (int bitIndex = this.interface30_0.BitIndex; bitIndex < 8; ++bitIndex)
          this.interface30_0.imethod_6();
      }
      this.interface30_0.imethod_3();
      this.interface30_0.imethod_4(num2 + (long) (num1 * 8));
      int num34 = (int) this.interface30_0.imethod_27();
      this.interface30_0.imethod_52(16);
      foreach (IDisposable disposable in this.list_0)
        disposable.Dispose();
    }

    private ulong method_1()
    {
      return this.interface30_0.imethod_32(true);
    }
  }
}
