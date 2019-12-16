// Decompiled with JetBrains decompiler
// Type: ns28.Class886
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.IO;
using WW.Cad.Model;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;
using WW.Text;

namespace ns28
{
  internal class Class886
  {
    private static readonly byte[] byte_0 = new byte[16]{ (byte) 207, (byte) 123, (byte) 31, (byte) 35, (byte) 253, (byte) 222, (byte) 56, (byte) 169, (byte) 95, (byte) 124, (byte) 104, (byte) 184, (byte) 78, (byte) 109, (byte) 51, (byte) 95 };
    private static readonly byte[] byte_1 = new byte[16]{ (byte) 48, (byte) 132, (byte) 224, (byte) 220, (byte) 2, (byte) 33, (byte) 199, (byte) 86, (byte) 160, (byte) 131, (byte) 151, (byte) 71, (byte) 177, (byte) 146, (byte) 204, (byte) 160 };
    private Stream stream_0;
    private DxfModel dxfModel_0;
    private DxfHeader dxfHeader_0;
    private MemoryStream memoryStream_0;
    private Interface29 interface29_0;

    public Class886(Stream stream, DxfModel model)
    {
      this.stream_0 = stream;
      this.dxfModel_0 = model;
      this.dxfHeader_0 = model.Header;
      this.memoryStream_0 = new MemoryStream(5000);
      this.interface29_0 = Class724.Create(model.Header.AcadVersion, (Stream) this.memoryStream_0, Encodings.GetEncoding((int) model.Header.DrawingCodePage));
    }

    public void Write()
    {
      this.method_0();
      this.stream_0.Write(Class886.byte_0, 0, Class886.byte_0.Length);
      Stream1 stream1 = new Stream1(this.stream_0, (ushort) 49345);
      Class1045.smethod_9((Stream) stream1, (int) this.memoryStream_0.Length);
      if (this.dxfHeader_0.AcadVersion > DxfVersion.Dxf21 && this.dxfHeader_0.AcadMaintenanceVersion > 3 || this.dxfHeader_0.AcadVersion > DxfVersion.Dxf27)
        Class1045.smethod_9((Stream) stream1, 0);
      stream1.Write(this.memoryStream_0.GetBuffer(), 0, (int) this.memoryStream_0.Length);
      Class1045.smethod_6(this.stream_0, stream1.Crc);
      this.stream_0.Write(Class886.byte_1, 0, Class886.byte_1.Length);
    }

    private void method_0()
    {
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf21)
        this.interface29_0.imethod_0();
      if (this.dxfHeader_0.AcadVersion > DxfVersion.Dxf24)
        this.interface29_0.imethod_34(this.dxfHeader_0.RequiredVersions);
      this.interface29_0.imethod_16(412148564080.0);
      this.interface29_0.imethod_16(1.0);
      this.interface29_0.imethod_16(1.0);
      this.interface29_0.imethod_16(1.0);
      this.interface29_0.imethod_4("m");
      this.interface29_0.imethod_4(string.Empty);
      this.interface29_0.imethod_4(string.Empty);
      this.interface29_0.imethod_4(string.Empty);
      this.interface29_0.imethod_33(0);
      this.interface29_0.imethod_33(0);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf13 && this.dxfHeader_0.AcadVersion <= DxfVersion.Dxf14)
        this.interface29_0.imethod_32((short) 0);
      if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf18)
      {
        DxfLayout dxfLayout = this.dxfModel_0.method_15();
        if (dxfLayout != null && dxfLayout.Viewports.Count > 0)
          this.interface29_0.imethod_41((DxfHandledObject) dxfLayout.Viewports[0].ViewportEntityHeader);
        else
          this.interface29_0.imethod_41((DxfHandledObject) null);
      }
      this.interface29_0.imethod_14(this.dxfHeader_0.AssociatedDimensions);
      this.interface29_0.imethod_14(this.dxfHeader_0.UpdateDimensionsWhileDragging);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf13 && this.dxfHeader_0.AcadVersion <= DxfVersion.Dxf14)
        this.interface29_0.imethod_14(this.dxfHeader_0.DimSav);
      this.interface29_0.imethod_14(this.dxfHeader_0.PolylineLineTypeGeneration == PolylineLineTypeGeneration.Continuous);
      this.interface29_0.imethod_14(this.dxfHeader_0.OrthoMode);
      this.interface29_0.imethod_14(this.dxfHeader_0.RegenerationMode);
      this.interface29_0.imethod_14(this.dxfHeader_0.FillMode);
      this.interface29_0.imethod_14(this.dxfHeader_0.QuickTextMode);
      this.interface29_0.imethod_14(this.dxfHeader_0.PaperSpaceLineTypeScaling != PaperSpaceLineTypeScaling.Viewport);
      this.interface29_0.imethod_14(this.dxfHeader_0.LimitCheckingOn);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf13 && this.dxfHeader_0.AcadVersion <= DxfVersion.Dxf14)
        this.interface29_0.imethod_14(false);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf18)
        this.interface29_0.imethod_14(false);
      this.interface29_0.imethod_14(this.dxfHeader_0.UserTimer);
      this.interface29_0.imethod_14(this.dxfHeader_0.SketchPolylines);
      this.interface29_0.imethod_14(this.dxfHeader_0.AngularDirection != AngularDirection.CounterClockWise);
      this.interface29_0.imethod_14(this.dxfHeader_0.ShowSplineControlPoints);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf13 && this.dxfHeader_0.AcadVersion <= DxfVersion.Dxf14)
      {
        this.interface29_0.imethod_14(false);
        this.interface29_0.imethod_14(false);
      }
      this.interface29_0.imethod_14(this.dxfHeader_0.MirrorText);
      this.interface29_0.imethod_14(this.dxfHeader_0.WorldView);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf13 && this.dxfHeader_0.AcadVersion <= DxfVersion.Dxf14)
        this.interface29_0.imethod_14(false);
      this.interface29_0.imethod_14(this.dxfHeader_0.ShowModelSpace);
      this.interface29_0.imethod_14(this.dxfHeader_0.PaperSpaceLimitsChecking);
      this.interface29_0.imethod_14(this.dxfHeader_0.RetainXRefDependentVisibilitySettings);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf13 && this.dxfHeader_0.AcadVersion <= DxfVersion.Dxf14)
        this.interface29_0.imethod_14(false);
      this.interface29_0.imethod_14(this.dxfHeader_0.DisplaySilhouetteCurves);
      this.interface29_0.imethod_14(this.dxfHeader_0.CreateEllipseAsPolyline);
      this.interface29_0.imethod_32(this.dxfHeader_0.ProxyGraphics ? (short) 1 : (short) 0);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf13 && this.dxfHeader_0.AcadVersion <= DxfVersion.Dxf14)
        this.interface29_0.imethod_32((short) 0);
      this.interface29_0.imethod_32(this.dxfHeader_0.SpatialIndexMaxTreeDepth);
      this.interface29_0.imethod_32((short) this.dxfHeader_0.LinearUnitFormat);
      this.interface29_0.imethod_32(this.dxfHeader_0.LinearUnitPrecision);
      this.interface29_0.imethod_32((short) this.dxfHeader_0.AngularUnit);
      this.interface29_0.imethod_32(this.dxfHeader_0.AngularUnitPrecision);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf13 && this.dxfHeader_0.AcadVersion <= DxfVersion.Dxf14)
        this.interface29_0.imethod_32((short) this.dxfHeader_0.ObjectSnapMode);
      this.interface29_0.imethod_32((short) this.dxfHeader_0.AttributeVisibility);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf13 && this.dxfHeader_0.AcadVersion <= DxfVersion.Dxf14)
        this.interface29_0.imethod_32((short) 0);
      this.interface29_0.imethod_32((short) this.dxfHeader_0.PointDisplayMode);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf13 && this.dxfHeader_0.AcadVersion <= DxfVersion.Dxf14)
        this.interface29_0.imethod_32((short) 0);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf18)
      {
        this.interface29_0.imethod_33(0);
        this.interface29_0.imethod_33(0);
        this.interface29_0.imethod_33(0);
      }
      this.interface29_0.imethod_32(this.dxfHeader_0.UserShort1);
      this.interface29_0.imethod_32(this.dxfHeader_0.UserShort2);
      this.interface29_0.imethod_32(this.dxfHeader_0.UserShort3);
      this.interface29_0.imethod_32(this.dxfHeader_0.UserShort4);
      this.interface29_0.imethod_32(this.dxfHeader_0.UserShort5);
      this.interface29_0.imethod_32(this.dxfHeader_0.NumberOfSplineSegments);
      this.interface29_0.imethod_32(this.dxfHeader_0.SurfaceDensityU);
      this.interface29_0.imethod_32(this.dxfHeader_0.SurfaceDensityV);
      this.interface29_0.imethod_32(this.dxfHeader_0.SurfaceType);
      this.interface29_0.imethod_32(this.dxfHeader_0.SurfaceMeshTabulationCount1);
      this.interface29_0.imethod_32(this.dxfHeader_0.SurfaceMeshTabulationCount2);
      this.interface29_0.imethod_32((short) this.dxfHeader_0.SplineType);
      this.interface29_0.imethod_32((short) this.dxfHeader_0.ShadeEdge);
      this.interface29_0.imethod_32(this.dxfHeader_0.ShadeDiffuseToAmbientPercentage);
      this.interface29_0.imethod_32(this.dxfHeader_0.UnitMode);
      this.interface29_0.imethod_32(this.dxfHeader_0.MaxViewportCount);
      this.interface29_0.imethod_32(this.dxfHeader_0.SurfaceIsolineCount);
      this.interface29_0.imethod_32((short) this.dxfHeader_0.CurrentMultilineJustification);
      this.interface29_0.imethod_32(this.dxfHeader_0.TextQuality);
      this.interface29_0.imethod_16(this.dxfHeader_0.LineTypeScale);
      this.interface29_0.imethod_16(this.dxfHeader_0.TextHeightDefault);
      this.interface29_0.imethod_16(this.dxfHeader_0.TraceWidthDefault);
      this.interface29_0.imethod_16(this.dxfHeader_0.SketchIncrement);
      this.interface29_0.imethod_16(this.dxfHeader_0.FilletRadius);
      this.interface29_0.imethod_16(this.dxfHeader_0.ThicknessDefault);
      this.interface29_0.imethod_16(this.dxfHeader_0.AngleBase);
      this.interface29_0.imethod_16(this.dxfHeader_0.PointDisplaySize);
      this.interface29_0.imethod_16(this.dxfHeader_0.PolylineWidthDefault);
      this.interface29_0.imethod_16(this.dxfHeader_0.UserDouble1);
      this.interface29_0.imethod_16(this.dxfHeader_0.UserDouble2);
      this.interface29_0.imethod_16(this.dxfHeader_0.UserDouble3);
      this.interface29_0.imethod_16(this.dxfHeader_0.UserDouble4);
      this.interface29_0.imethod_16(this.dxfHeader_0.UserDouble5);
      this.interface29_0.imethod_16(this.dxfHeader_0.ChamferDistance1);
      this.interface29_0.imethod_16(this.dxfHeader_0.ChamferDistance2);
      this.interface29_0.imethod_16(this.dxfHeader_0.ChamferLength);
      this.interface29_0.imethod_16(this.dxfHeader_0.ChamferAngle);
      this.interface29_0.imethod_16(this.dxfHeader_0.FacetResolution);
      this.interface29_0.imethod_16(this.dxfHeader_0.CurrentMultilineScale);
      this.interface29_0.imethod_16(this.dxfHeader_0.CurrentEntityLinetypeScale);
      if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(this.dxfHeader_0.MenuFileName);
      this.interface29_0.imethod_44(this.dxfHeader_0.CreateDateTime);
      this.interface29_0.imethod_44(this.dxfHeader_0.UpdateDateTime);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf18)
      {
        this.interface29_0.imethod_33(0);
        this.interface29_0.imethod_33(0);
        this.interface29_0.imethod_33(0);
      }
      this.interface29_0.imethod_45(this.dxfModel_0.SummaryInfo.TotalEditingTime);
      this.interface29_0.imethod_45(this.dxfHeader_0.UserElapsedTimeSpan);
      this.interface29_0.imethod_6(this.dxfHeader_0.CurrentEntityColor);
      this.interface29_0.imethod_35(new ReferenceType?(), this.dxfHeader_0.HandleSeed);
      if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.CurrentLayer);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.CurrentTextStyle);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.CurrentEntityLineType);
        if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf21)
          this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.DimensionStyle);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.CurrentMultilineStyle);
      }
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf15)
        this.interface29_0.imethod_16(this.dxfHeader_0.ViewportDefaultViewScaleFactor);
      this.interface29_0.imethod_24(this.dxfHeader_0.PaperSpaceInsertionBase);
      this.interface29_0.imethod_24(this.dxfHeader_0.PaperSpaceExtMin);
      this.interface29_0.imethod_24(this.dxfHeader_0.PaperSpaceExtMax);
      this.interface29_0.imethod_25(this.dxfHeader_0.PaperSpaceLimitsMin);
      this.interface29_0.imethod_25(this.dxfHeader_0.PaperSpaceLimitsMax);
      this.interface29_0.imethod_16(this.dxfHeader_0.PaperSpaceElevation);
      this.interface29_0.imethod_24(this.dxfHeader_0.PaperSpaceUcs.Origin);
      this.interface29_0.imethod_29(this.dxfHeader_0.PaperSpaceUcs.XAxis);
      this.interface29_0.imethod_29(this.dxfHeader_0.PaperSpaceUcs.YAxis);
      if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.PaperSpaceUcs);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf15)
      {
        if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
          this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_32((short) 0);
        if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
          this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_29(this.dxfHeader_0.PaperSpaceUcs.OrthographicTopDOrigin);
        this.interface29_0.imethod_29(this.dxfHeader_0.PaperSpaceUcs.OrthographicBottomDOrigin);
        this.interface29_0.imethod_29(this.dxfHeader_0.PaperSpaceUcs.OrthographicLeftDOrigin);
        this.interface29_0.imethod_29(this.dxfHeader_0.PaperSpaceUcs.OrthographicRightDOrigin);
        this.interface29_0.imethod_29(this.dxfHeader_0.PaperSpaceUcs.OrthographicFrontDOrigin);
        this.interface29_0.imethod_29(this.dxfHeader_0.PaperSpaceUcs.OrthographicBackDOrigin);
      }
      this.interface29_0.imethod_24(this.dxfHeader_0.InsertionBase);
      this.interface29_0.imethod_24(this.dxfHeader_0.ExtMin);
      this.interface29_0.imethod_24(this.dxfHeader_0.ExtMax);
      this.interface29_0.imethod_25(this.dxfHeader_0.LimitsMin);
      this.interface29_0.imethod_25(this.dxfHeader_0.LimitsMax);
      this.interface29_0.imethod_16(this.dxfHeader_0.Elevation);
      this.interface29_0.imethod_24(this.dxfHeader_0.Ucs.Origin);
      this.interface29_0.imethod_29(this.dxfHeader_0.Ucs.XAxis);
      this.interface29_0.imethod_29(this.dxfHeader_0.Ucs.YAxis);
      if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.Ucs);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf15)
      {
        if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
          this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_32((short) 0);
        if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
          this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_29(this.dxfHeader_0.Ucs.OrthographicTopDOrigin);
        this.interface29_0.imethod_29(this.dxfHeader_0.Ucs.OrthographicBottomDOrigin);
        this.interface29_0.imethod_29(this.dxfHeader_0.Ucs.OrthographicLeftDOrigin);
        this.interface29_0.imethod_29(this.dxfHeader_0.Ucs.OrthographicRightDOrigin);
        this.interface29_0.imethod_29(this.dxfHeader_0.Ucs.OrthographicFrontDOrigin);
        this.interface29_0.imethod_29(this.dxfHeader_0.Ucs.OrthographicBackDOrigin);
        if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
        {
          this.interface29_0.imethod_4(this.dxfHeader_0.DimensionStyleOverrides.PostFix);
          this.interface29_0.imethod_4(this.dxfHeader_0.DimensionStyleOverrides.AlternateDimensioningSuffix);
        }
      }
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf13 && this.dxfHeader_0.AcadVersion <= DxfVersion.Dxf14)
      {
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.GenerateTolerances);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.LimitsGeneration);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.TextInsideHorizontal);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.TextOutsideHorizontal);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.SuppressFirstDimensionLine);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.SuppressSecondDimensionLine);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.AlternateUnitDimensioning);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.TextOutsideExtensions);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.SeparateArrowBlocks);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.TextInsideExtensions);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.SuppressOutsideExtensions);
        this.interface29_0.imethod_11((byte) this.dxfHeader_0.DimensionStyleOverrides.AlternateUnitDecimalPlaces);
        this.interface29_0.imethod_11((byte) this.dxfHeader_0.DimensionStyleOverrides.ZeroHandling);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.SuppressFirstDimensionLine);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.SuppressSecondDimensionLine);
        this.interface29_0.imethod_11((byte) this.dxfHeader_0.DimensionStyleOverrides.ToleranceAlignment);
        this.interface29_0.imethod_11((byte) this.dxfHeader_0.DimensionStyleOverrides.TextHorizontalAlignment);
        this.interface29_0.imethod_11((byte) 3);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.CursorUpdate != CursorUpdate.ControlsLinePosition);
        this.interface29_0.imethod_11((byte) this.dxfHeader_0.DimensionStyleOverrides.ToleranceZeroHandling);
        this.interface29_0.imethod_11((byte) this.dxfHeader_0.DimensionStyleOverrides.AlternateUnitZeroHandling);
        this.interface29_0.imethod_11((byte) this.dxfHeader_0.DimensionStyleOverrides.AlternateUnitToleranceZeroHandling);
        this.interface29_0.imethod_11((byte) this.dxfHeader_0.DimensionStyleOverrides.TextVerticalAlignment);
        this.interface29_0.imethod_32((short) 0);
        this.interface29_0.imethod_32(this.dxfHeader_0.DimensionStyleOverrides.AngularDimensionDecimalPlaces);
        this.interface29_0.imethod_32(this.dxfHeader_0.DimensionStyleOverrides.DecimalPlaces);
        this.interface29_0.imethod_32(this.dxfHeader_0.DimensionStyleOverrides.ToleranceDecimalPlaces);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.DimensionStyleOverrides.AlternateUnitFormat);
        this.interface29_0.imethod_32(this.dxfHeader_0.DimensionStyleOverrides.AlternateUnitToleranceDecimalPlaces);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.DimensionStyleOverrides.TextStyle);
      }
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.ScaleFactor);
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.ArrowSize);
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.ExtensionLineOffset);
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.DimensionLineIncrement);
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.ExtensionLineExtension);
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.Rounding);
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.DimensionLineExtension);
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.PlusTolerance);
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.MinusTolerance);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.FixedExtensionLineLength);
        this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.JoggedRadiusDimensionTransverseSegmentAngle);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.DimensionStyleOverrides.TextBackgroundFillMode);
        this.interface29_0.imethod_6(this.dxfHeader_0.DimensionStyleOverrides.TextBackgroundColor);
      }
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.GenerateTolerances);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.LimitsGeneration);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.TextInsideHorizontal);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.TextOutsideHorizontal);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.SuppressFirstExtensionLine);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.SuppressSecondExtensionLine);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.DimensionStyleOverrides.TextVerticalAlignment);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.DimensionStyleOverrides.ZeroHandling);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.DimensionStyleOverrides.AngularZeroHandling);
      }
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf21)
        this.interface29_0.imethod_32((short) this.dxfHeader_0.DimensionStyleOverrides.ArcLengthSymbolPosition);
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.TextHeight);
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.CenterMarkSize);
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.TickSize);
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.AlternateUnitScaleFactor);
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.LinearScaleFactor);
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.TextVerticalPosition);
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.ToleranceScaleFactor);
      this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.DimensionLineGap);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf13 && this.dxfHeader_0.AcadVersion <= DxfVersion.Dxf14)
      {
        this.interface29_0.imethod_4(this.dxfHeader_0.DimensionStyleOverrides.PostFix);
        this.interface29_0.imethod_4(this.dxfHeader_0.DimensionStyleOverrides.AlternateDimensioningSuffix);
        this.interface29_0.imethod_4(this.dxfHeader_0.DimensionStyleOverrides.ArrowBlock != null ? this.dxfHeader_0.DimensionStyleOverrides.ArrowBlock.Name : string.Empty);
        this.interface29_0.imethod_4(this.dxfHeader_0.DimensionStyleOverrides.FirstArrowBlock != null ? this.dxfHeader_0.DimensionStyleOverrides.FirstArrowBlock.Name : string.Empty);
        this.interface29_0.imethod_4(this.dxfHeader_0.DimensionStyleOverrides.SecondArrowBlock != null ? this.dxfHeader_0.DimensionStyleOverrides.SecondArrowBlock.Name : string.Empty);
      }
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.AlternateUnitRounding);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.AlternateUnitDimensioning);
        this.interface29_0.imethod_32(this.dxfHeader_0.DimensionStyleOverrides.AlternateUnitDecimalPlaces);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.TextOutsideExtensions);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.SeparateArrowBlocks);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.TextInsideExtensions);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.SuppressOutsideExtensions);
      }
      this.interface29_0.imethod_6(this.dxfHeader_0.DimensionStyleOverrides.DimensionLineColor);
      this.interface29_0.imethod_6(this.dxfHeader_0.DimensionStyleOverrides.ExtensionLineColor);
      this.interface29_0.imethod_6(this.dxfHeader_0.DimensionStyleOverrides.TextColor);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_32(this.dxfHeader_0.DimensionStyleOverrides.AngularDimensionDecimalPlaces);
        this.interface29_0.imethod_32(this.dxfHeader_0.DimensionStyleOverrides.DecimalPlaces);
        this.interface29_0.imethod_32(this.dxfHeader_0.DimensionStyleOverrides.ToleranceDecimalPlaces);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.DimensionStyleOverrides.AlternateUnitFormat);
        this.interface29_0.imethod_32(this.dxfHeader_0.DimensionStyleOverrides.AlternateUnitToleranceDecimalPlaces);
        this.interface29_0.imethod_32(this.dxfHeader_0.DimensionStyleOverrides.AngularDimensionDecimalPlaces);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.DimensionStyleOverrides.FractionFormat);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.DimensionStyleOverrides.LinearUnitFormat);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.DimensionStyleOverrides.DecimalSeparator);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.DimensionStyleOverrides.TextMovement);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.DimensionStyleOverrides.TextHorizontalAlignment);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.SuppressFirstDimensionLine);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.SuppressSecondDimensionLine);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.DimensionStyleOverrides.ToleranceAlignment);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.DimensionStyleOverrides.ToleranceZeroHandling);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.DimensionStyleOverrides.AlternateUnitZeroHandling);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.DimensionStyleOverrides.AlternateUnitToleranceZeroHandling);
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.CursorUpdate != CursorUpdate.ControlsLinePosition);
        this.interface29_0.imethod_32((short) 3);
      }
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf21)
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.IsExtensionLineLengthFixed);
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf24)
      {
        this.interface29_0.imethod_14(this.dxfHeader_0.DimensionStyleOverrides.TextDirection == TextDirection.RightToLeft);
        this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.AltMzf);
        this.interface29_0.imethod_16(this.dxfHeader_0.DimensionStyleOverrides.Mzf);
      }
      if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
      {
        if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf15)
        {
          this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.DimensionStyleOverrides.TextStyle);
          this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.DimensionStyleOverrides.LeaderArrowBlock);
          this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.DimensionStyleOverrides.ArrowBlock);
          this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.DimensionStyleOverrides.FirstArrowBlock);
          this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.DimensionStyleOverrides.SecondArrowBlock);
        }
        if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf21)
        {
          this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.DimensionStyleOverrides.DimensionLineLineType);
          this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.DimensionStyleOverrides.FirstExtensionLineLineType);
          this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.DimensionStyleOverrides.SecondExtensionLineLineType);
        }
      }
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_32(this.dxfHeader_0.DimensionStyleOverrides.DimensionLineWeight);
        this.interface29_0.imethod_32(this.dxfHeader_0.DimensionStyleOverrides.ExtensionLineWeight);
      }
      if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_39(this.dxfModel_0.BlockRecordTable);
        this.interface29_0.imethod_39(this.dxfModel_0.LayerTable);
        this.interface29_0.imethod_39(this.dxfModel_0.TextStyleTable);
        this.interface29_0.imethod_39(this.dxfModel_0.LineTypeTable);
        this.interface29_0.imethod_39(this.dxfModel_0.ViewTable);
        this.interface29_0.imethod_39(this.dxfModel_0.UcsTable);
        this.interface29_0.imethod_39(this.dxfModel_0.VPortTable);
        this.interface29_0.imethod_39(this.dxfModel_0.AppIdTable);
        this.interface29_0.imethod_39(this.dxfModel_0.DimStyleTable);
        if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf13 && this.dxfHeader_0.AcadVersion <= DxfVersion.Dxf15)
          this.interface29_0.imethod_39(this.dxfModel_0.ViewportEntityHeaderTable);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DictionaryAcadGroup);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DictionaryAcadMLineStyle);
        this.interface29_0.imethod_39((DxfHandledObject) this.dxfModel_0.DictionaryRoot);
      }
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_32((short) ((short) 2 - this.dxfHeader_0.StackedTextAlignment));
        this.interface29_0.imethod_32(this.dxfHeader_0.StackedTextSizePercentage);
        if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
        {
          this.interface29_0.imethod_4(this.dxfModel_0.SummaryInfo.HyperLinkBase);
          this.interface29_0.imethod_4(string.Empty);
          this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DictionaryAcadLayout);
          this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DictionaryAcadPlotSettings);
          this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DictionaryAcadPlotStyleName);
        }
      }
      if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
      {
        if (this.dxfHeader_0.AcadVersion > DxfVersion.Dxf15)
        {
          this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DictionaryAcadMaterial);
          this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DictionaryAcadColor);
        }
        if (this.dxfHeader_0.AcadVersion > DxfVersion.Dxf18)
          this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DictionaryAcadVisualStyle);
      }
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf15)
      {
        int num = (int) this.dxfHeader_0.CurrentEntityLineWeight & 31 | (int) this.dxfHeader_0.EndCaps << 5 | (int) this.dxfHeader_0.JoinStyle << 7;
        if (!this.dxfHeader_0.DisplayLineWeight)
          num |= 512;
        if (!this.dxfHeader_0.XEdit)
          num |= 1024;
        if (this.dxfHeader_0.ExtendedNames)
          num |= 2048;
        if (this.dxfHeader_0.PlotStyleMode == PlotStyleMode.ColorDependent)
          num |= 8192;
        this.interface29_0.imethod_33(num);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.InsUnits);
        this.interface29_0.imethod_32((short) this.dxfHeader_0.CurrentEntityPlotStyleType);
        if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
        {
          if (this.dxfHeader_0.CurrentEntityPlotStyleType == PlotStyleType.ByObjectId)
            this.interface29_0.imethod_41((DxfHandledObject) null);
          this.interface29_0.imethod_4(this.dxfHeader_0.FingerPrintGuid);
          this.interface29_0.imethod_4(this.dxfHeader_0.VersionGuid);
        }
      }
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf18)
      {
        this.interface29_0.imethod_11((byte) this.dxfHeader_0.EntitySortingFlags);
        this.interface29_0.imethod_11((byte) this.dxfHeader_0.IndexCreationFlags);
        this.interface29_0.imethod_11((byte) 1);
        byte clippingBoundaryType = (byte) this.dxfHeader_0.ExternalReferenceClippingBoundaryType;
        if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf24)
          clippingBoundaryType &= (byte) 1;
        this.interface29_0.imethod_11(clippingBoundaryType);
        this.interface29_0.imethod_11((byte) this.dxfHeader_0.DimensionAssociativity);
        this.interface29_0.imethod_11(this.dxfHeader_0.HaloGapPercentage);
        this.interface29_0.imethod_32(DxfIndexedColorSet.smethod_14(this.dxfHeader_0.ObscuredColor));
        this.interface29_0.imethod_32(DxfIndexedColorSet.smethod_14(this.dxfHeader_0.IntersectionColor));
        this.interface29_0.imethod_11((byte) 0);
        this.interface29_0.imethod_11(this.dxfHeader_0.IntersectionDisplay ? (byte) 1 : (byte) 0);
        if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
          this.interface29_0.imethod_4(this.dxfHeader_0.ProjectName);
      }
      if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
      {
        DxfBlock dxfBlock;
        if (this.dxfModel_0.AnonymousBlocks.TryGetValue("*Paper_Space", out dxfBlock))
          this.interface29_0.imethod_41((DxfHandledObject) dxfBlock);
        else
          this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.ModelLayout.OwnerBlock);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.ByLayerLineType);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.ByBlockLineType);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.ContinuousLineType);
      }
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_14(false);
        this.interface29_0.imethod_33(0);
        this.interface29_0.imethod_33(10);
        this.interface29_0.imethod_16(1.0);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_11((byte) 0);
        this.interface29_0.imethod_11((byte) 0);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_32((short) 0);
        this.interface29_0.imethod_11((byte) 0);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_33(0);
        this.interface29_0.imethod_11((byte) 0);
        this.interface29_0.imethod_11((byte) 0);
        this.interface29_0.imethod_11((byte) 0);
        this.interface29_0.imethod_11((byte) 0);
        this.interface29_0.imethod_14(true);
        this.interface29_0.imethod_6(this.dxfHeader_0.InterfereColor);
        if (this.dxfHeader_0.AcadVersion < DxfVersion.Dxf21)
        {
          this.interface29_0.imethod_41((DxfHandledObject) null);
          this.interface29_0.imethod_41((DxfHandledObject) null);
          this.interface29_0.imethod_41((DxfHandledObject) null);
        }
        this.interface29_0.imethod_11((byte) this.dxfHeader_0.ShadowMode);
        this.interface29_0.imethod_16(this.dxfHeader_0.ShadowPlaneLocation);
      }
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_4(this.dxfHeader_0.MenuFileName);
        this.interface29_0.imethod_4(this.dxfHeader_0.DimensionStyleOverrides.PostFix);
        this.interface29_0.imethod_4(this.dxfHeader_0.DimensionStyleOverrides.AlternateDimensioningSuffix);
        if (this.dxfHeader_0.AcadVersion > DxfVersion.Dxf21)
        {
          this.interface29_0.imethod_4(this.dxfHeader_0.DimensionStyleOverrides.AltMzs);
          this.interface29_0.imethod_4(this.dxfHeader_0.DimensionStyleOverrides.Mzs);
        }
        this.interface29_0.imethod_4(this.dxfModel_0.SummaryInfo.HyperLinkBase);
        this.interface29_0.imethod_4(string.Empty);
        this.interface29_0.imethod_4(this.dxfHeader_0.FingerPrintGuid);
        this.interface29_0.imethod_4(this.dxfHeader_0.VersionGuid);
        this.interface29_0.imethod_4(string.Empty);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.CurrentLayer);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.CurrentTextStyle);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.CurrentEntityLineType);
        this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.DimensionStyle);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.CurrentMultilineStyle);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.PaperSpaceUcs);
        this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.Ucs);
        this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.DimensionStyleOverrides.TextStyle);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.DimensionStyleOverrides.LeaderArrowBlock);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.DimensionStyleOverrides.ArrowBlock);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.DimensionStyleOverrides.FirstArrowBlock);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfHeader_0.DimensionStyleOverrides.SecondArrowBlock);
        this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_39(this.dxfModel_0.BlockRecordTable);
        this.interface29_0.imethod_39(this.dxfModel_0.LayerTable);
        this.interface29_0.imethod_39(this.dxfModel_0.TextStyleTable);
        this.interface29_0.imethod_39(this.dxfModel_0.LineTypeTable);
        this.interface29_0.imethod_39(this.dxfModel_0.ViewTable);
        this.interface29_0.imethod_39(this.dxfModel_0.UcsTable);
        this.interface29_0.imethod_39(this.dxfModel_0.VPortTable);
        this.interface29_0.imethod_39(this.dxfModel_0.AppIdTable);
        this.interface29_0.imethod_39(this.dxfModel_0.DimStyleTable);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DictionaryAcadGroup);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DictionaryAcadMLineStyle);
        this.interface29_0.imethod_39((DxfHandledObject) this.dxfModel_0.DictionaryRoot);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DictionaryAcadLayout);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DictionaryAcadPlotSettings);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DictionaryAcadPlotStyleName);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DictionaryAcadMaterial);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DictionaryAcadColor);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DictionaryAcadVisualStyle);
        if (this.dxfHeader_0.AcadVersion > DxfVersion.Dxf24)
          this.interface29_0.imethod_41((DxfHandledObject) null);
        if (this.dxfHeader_0.CurrentEntityPlotStyleType == PlotStyleType.ByObjectId)
          this.interface29_0.imethod_41((DxfHandledObject) null);
        DxfBlock dxfBlock;
        if (this.dxfModel_0.AnonymousBlocks.TryGetValue("*Paper_Space", out dxfBlock))
          this.interface29_0.imethod_41((DxfHandledObject) dxfBlock);
        else
          this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.ModelLayout.OwnerBlock);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.ByLayerLineType);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.ByBlockLineType);
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.ContinuousLineType);
        this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) null);
      }
      if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf14)
      {
        Interface29 handleBitStreamWriter = (Interface29) this.interface29_0.HandleBitStreamWriter;
        handleBitStreamWriter.imethod_32((short) -1);
        handleBitStreamWriter.imethod_32((short) -1);
        handleBitStreamWriter.imethod_32((short) -1);
        handleBitStreamWriter.imethod_32((short) -1);
        if (this.dxfHeader_0.AcadVersion >= DxfVersion.Dxf18)
        {
          handleBitStreamWriter.imethod_33(0);
          handleBitStreamWriter.imethod_33(0);
          handleBitStreamWriter.imethod_14(false);
        }
      }
      this.interface29_0.Flush();
    }
  }
}
