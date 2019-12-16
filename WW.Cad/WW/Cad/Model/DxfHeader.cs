// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfHeader
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using WW.Cad.Base;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Tables;
using WW.ComponentModel;
using WW.Math;

namespace WW.Cad.Model
{
  [System.ComponentModel.TypeConverter(typeof (SortedPropertiesTypeConverter))]
  public class DxfHeader
  {
    private static readonly object[,] object_0 = new object[67, 2]{ { (object) DrawingCodePage.Dos437, (object) "dos437" }, { (object) DrawingCodePage.Dos850, (object) "dos850" }, { (object) DrawingCodePage.Dos852, (object) "dos852" }, { (object) DrawingCodePage.Dos737, (object) "dos737" }, { (object) DrawingCodePage.Dos866, (object) "dos866" }, { (object) DrawingCodePage.Dos855, (object) "dos855" }, { (object) DrawingCodePage.Dos857, (object) "dos857" }, { (object) DrawingCodePage.Dos860, (object) "dos860" }, { (object) DrawingCodePage.Dos861, (object) "dos861" }, { (object) DrawingCodePage.Dos863, (object) "dos863" }, { (object) DrawingCodePage.Dos864, (object) "dos864" }, { (object) DrawingCodePage.Dos865, (object) "dos865" }, { (object) DrawingCodePage.Dos869, (object) "dos869" }, { (object) DrawingCodePage.Dos720, (object) "dos720" }, { (object) DrawingCodePage.Dos775, (object) "dos775" }, { (object) DrawingCodePage.Windows874, (object) "ansi_874" }, { (object) DrawingCodePage.Dos932, (object) "dos932" }, { (object) DrawingCodePage.Gb2312, (object) "gb2312" }, { (object) DrawingCodePage.Ksc5601, (object) "kcs5601" }, { (object) DrawingCodePage.Ascii, (object) "ascii" }, { (object) DrawingCodePage.Dos932, (object) "ansi_932" }, { (object) DrawingCodePage.Gb2312, (object) "ansi_936" }, { (object) DrawingCodePage.Ansi950, (object) "ansi_950" }, { (object) DrawingCodePage.Ansi950, (object) "big5" }, { (object) DrawingCodePage.Ansi950, (object) "dos950" }, { (object) DrawingCodePage.Ansi1250, (object) "ansi_1250" }, { (object) DrawingCodePage.Ansi1250, (object) "ansi1250" }, { (object) DrawingCodePage.Ansi1251, (object) "ansi_1251" }, { (object) DrawingCodePage.Ansi1251, (object) "ansi1251" }, { (object) DrawingCodePage.Ansi1252, (object) "ansi_1252" }, { (object) DrawingCodePage.Ansi1252, (object) "ansi1252" }, { (object) DrawingCodePage.Ansi1253, (object) "ansi_1253" }, { (object) DrawingCodePage.Ansi1253, (object) "ansi1253" }, { (object) DrawingCodePage.Ansi1254, (object) "ansi_1254" }, { (object) DrawingCodePage.Ansi1254, (object) "ansi1254" }, { (object) DrawingCodePage.Ansi1255, (object) "ansi_1255" }, { (object) DrawingCodePage.Ansi1255, (object) "ansi1255" }, { (object) DrawingCodePage.Ansi1256, (object) "ansi_1256" }, { (object) DrawingCodePage.Ansi1256, (object) "ansi1256" }, { (object) DrawingCodePage.Ansi1257, (object) "ansi_1257" }, { (object) DrawingCodePage.Ansi1257, (object) "ansi1257" }, { (object) DrawingCodePage.Johab, (object) "johab" }, { (object) DrawingCodePage.Iso8859_1, (object) "iso8859-1" }, { (object) DrawingCodePage.Iso8859_1, (object) "iso88591" }, { (object) DrawingCodePage.Iso8859_2, (object) "iso8859-2" }, { (object) DrawingCodePage.Iso8859_2, (object) "iso88592" }, { (object) DrawingCodePage.Iso8859_3, (object) "iso8859-3" }, { (object) DrawingCodePage.Iso8859_3, (object) "iso88593" }, { (object) DrawingCodePage.Iso8859_4, (object) "iso8859-4" }, { (object) DrawingCodePage.Iso8859_4, (object) "iso88594" }, { (object) DrawingCodePage.Iso8859_5, (object) "iso8859-5" }, { (object) DrawingCodePage.Iso8859_5, (object) "iso88595" }, { (object) DrawingCodePage.Iso8859_6, (object) "iso8859-6" }, { (object) DrawingCodePage.Iso8859_6, (object) "iso88596" }, { (object) DrawingCodePage.Iso8859_7, (object) "iso8859-7" }, { (object) DrawingCodePage.Iso8859_7, (object) "iso88597" }, { (object) DrawingCodePage.Iso8859_8, (object) "iso8859-8" }, { (object) DrawingCodePage.Iso8859_8, (object) "iso88598" }, { (object) DrawingCodePage.Iso8859_9, (object) "iso8859-9" }, { (object) DrawingCodePage.Iso8859_9, (object) "iso88599" }, { (object) DrawingCodePage.Iso8859_10, (object) "iso8859-10" }, { (object) DrawingCodePage.Iso8859_10, (object) "iso885910" }, { (object) DrawingCodePage.Iso8859_13, (object) "iso8859-13" }, { (object) DrawingCodePage.Iso8859_13, (object) "iso885913" }, { (object) DrawingCodePage.Iso8859_15, (object) "iso885915" }, { (object) DrawingCodePage.Iso8859_15, (object) "iso8859-15" }, { (object) DrawingCodePage.MacRoman, (object) "mac-roman" } };
    internal static readonly Color color_4 = Color.ByLayer;
    internal static readonly WW.Math.Point3D point3D_6 = new WW.Math.Point3D(1E+20, 1E+20, 1E+20);
    internal static readonly WW.Math.Point3D point3D_7 = new WW.Math.Point3D(-1E+20, -1E+20, -1E+20);
    internal static readonly WW.Math.Point3D point3D_8 = WW.Math.Point3D.Zero;
    internal static readonly Color color_5 = Colors.Red;
    internal static readonly Color color_6 = Color.None;
    internal static readonly Color color_7 = Color.None;
    internal static readonly string string_6 = string.Empty;
    internal static readonly WW.Math.Point2D point2D_5 = WW.Math.Point2D.Zero;
    internal static readonly Vector2D vector2D_1 = new Vector2D(1.0, 1.0);
    private Dictionary<string, List<Struct18>> dictionary_0 = new Dictionary<string, List<Struct18>>(1001);
    private AngularDirection angularDirection_1 = AngularDirection.ClockWise;
    private double double_19 = 0.5;
    private double double_20 = 0.5;
    private DateTime dateTime_0 = DxfUtil.DateTimeNow;
    private DateTime dateTime_1 = DxfUtil.DateTimeUtcNow;
    private Color color_0 = DxfHeader.color_4;
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private double double_23 = 1.0;
    private short short_13 = -1;
    private double double_24 = 1.0;
    private DxfObjectReference dxfObjectReference_1 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_2 = DxfObjectReference.Null;
    private DimensionAssociativity dimensionAssociativity_1 = DimensionAssociativity.NonAssociative;
    private DxfObjectReference dxfObjectReference_3 = DxfObjectReference.Null;
    private bool bool_22 = true;
    private double double_26 = 0.5;
    private string string_2 = string.Empty;
    private DrawingUnits drawingUnits_1 = DrawingUnits.Inches;
    private LinearUnitFormat linearUnitFormat_1 = LinearUnitFormat.Decimal;
    private short short_14 = 4;
    private double double_28 = 1.0;
    private DrawingCodePage drawingCodePage_0 = DrawingCodePage.Ansi1252;
    private short short_15 = 8;
    private ulong ulong_0 = 39;
    private Color color_1 = DxfHeader.color_5;
    private DxfObjectReference dxfObjectReference_4 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_5 = DxfObjectReference.Null;
    private Color color_2 = DxfHeader.color_6;
    private AttributeVisibility attributeVisibility_1 = AttributeVisibility.Normal;
    private bool bool_26 = true;
    private PaperSpaceLineTypeScaling paperSpaceLineTypeScaling_1 = PaperSpaceLineTypeScaling.Normal;
    private bool bool_29 = true;
    private ObjectSortingFlags objectSortingFlags_1 = ObjectSortingFlags.AllSortingMethods;
    private WW.Math.Point3D point3D_0 = DxfHeader.point3D_6;
    private WW.Math.Point3D point3D_1 = DxfHeader.point3D_7;
    private WW.Math.Point3D point3D_2 = DxfHeader.point3D_8;
    private bool bool_30 = true;
    private bool bool_31 = true;
    private DxfObjectReference dxfObjectReference_6 = DxfObjectReference.Null;
    private WW.Math.Point2D point2D_0 = new WW.Math.Point2D(12.0, 9.0);
    private WW.Math.Point2D point2D_1 = WW.Math.Point2D.Zero;
    private short short_16 = 48;
    private string string_3 = ".";
    private bool bool_33 = true;
    private Color color_3 = DxfHeader.color_7;
    private WW.Math.Point3D point3D_3 = DxfHeader.point3D_7;
    private WW.Math.Point3D point3D_4 = DxfHeader.point3D_6;
    private WW.Math.Point3D point3D_5 = WW.Math.Point3D.Zero;
    private WW.Math.Point2D point2D_2 = WW.Math.Point2D.Zero;
    private WW.Math.Point2D point2D_3 = WW.Math.Point2D.Zero;
    private DxfObjectReference dxfObjectReference_7 = new DxfUcs().Reference;
    private DxfObjectReference dxfObjectReference_8 = DxfObjectReference.Null;
    private PolylineLineTypeGeneration polylineLineTypeGeneration_0 = PolylineLineTypeGeneration.Continuous;
    private string string_4 = DxfHeader.string_6;
    private bool bool_35 = true;
    private bool bool_36 = true;
    private bool bool_37 = true;
    private short short_17 = 70;
    private ShadeEdge shadeEdge_1 = ShadeEdge.FacesInEntityColorEdgesInBlack;
    private bool bool_38 = true;
    private double double_33 = 0.1;
    private short short_18 = 3020;
    private SplineType splineType_1 = SplineType.CubicBSpline;
    private VerticalAlignment verticalAlignment_2 = VerticalAlignment.Middle;
    private short short_19 = 70;
    private short short_20 = 6;
    private short short_21 = 6;
    private short short_22 = 4;
    private short short_23 = 6;
    private short short_24 = 6;
    private short short_25 = 6;
    private short short_26 = 50;
    private double double_34 = 0.2;
    private double double_36 = 0.05;
    private DxfObjectReference dxfObjectReference_9 = new DxfUcs().Reference;
    private DxfObjectReference dxfObjectReference_10 = DxfObjectReference.Null;
    private DateTime dateTime_2 = DxfUtil.DateTimeNow;
    private DateTime dateTime_3 = DxfUtil.DateTimeUtcNow;
    private DxfTimeSpan dxfTimeSpan_0 = new DxfTimeSpan(0, 1);
    private bool bool_40 = true;
    private string string_5 = string.Empty;
    private bool bool_41 = true;
    private SimpleLineType simpleLineType_3 = SimpleLineType.Solid;
    private WW.Math.Point2D point2D_4 = DxfHeader.point2D_5;
    private Vector2D vector2D_0 = DxfHeader.vector2D_1;
    private bool bool_44 = true;
    private bool bool_46 = true;
    private bool bool_47 = true;
    internal const double double_0 = 0.0;
    internal const AngularDirection angularDirection_0 = AngularDirection.ClockWise;
    internal const bool bool_0 = true;
    internal const AttributeVisibility attributeVisibility_0 = AttributeVisibility.Normal;
    internal const double double_1 = 0.5;
    internal const double double_2 = 0.5;
    internal const double double_3 = 0.0;
    internal const double double_4 = 0.0;
    internal const short short_0 = -1;
    internal const PlotStyleType plotStyleType_0 = PlotStyleType.ByLayer;
    internal const double double_5 = 1.0;
    internal const double double_6 = 1.0;
    internal const VerticalAlignment verticalAlignment_0 = VerticalAlignment.Top;
    internal const DimensionAssociativity dimensionAssociativity_0 = DimensionAssociativity.NonAssociative;
    internal const ObjectSortingFlags objectSortingFlags_0 = ObjectSortingFlags.AllSortingMethods;
    internal const double double_7 = 0.5;
    internal const double double_8 = 0.0;
    internal const bool bool_1 = true;
    internal const int int_0 = 0;
    internal const IndexCreationFlags indexCreationFlags_0 = IndexCreationFlags.NoIndex;
    internal const DrawingUnits drawingUnits_0 = DrawingUnits.Inches;
    internal const bool bool_2 = false;
    internal const LinearUnitFormat linearUnitFormat_0 = LinearUnitFormat.Decimal;
    internal const short short_1 = 4;
    internal const double double_9 = 1.0;
    internal const short short_2 = 48;
    internal const string string_0 = ".";
    internal const bool bool_3 = true;
    internal const short short_3 = 8;
    internal const SimpleLineType simpleLineType_0 = SimpleLineType.Off;
    internal const PaperSpaceLineTypeScaling paperSpaceLineTypeScaling_0 = PaperSpaceLineTypeScaling.Normal;
    internal const PlotStyleMode plotStyleMode_0 = PlotStyleMode.Named;
    internal const double double_10 = 0.0;
    internal const double double_11 = 0.0;
    internal const bool bool_4 = true;
    internal const bool bool_5 = true;
    internal const bool bool_6 = true;
    internal const ShadeEdge shadeEdge_0 = ShadeEdge.FacesInEntityColorEdgesInBlack;
    internal const ShadowMode shadowMode_0 = ShadowMode.CastsAndReceives;
    internal const double double_12 = 0.0;
    internal const bool bool_7 = true;
    internal const double double_13 = 0.1;
    internal const short short_4 = 3020;
    internal const SplineType splineType_0 = SplineType.CubicBSpline;
    internal const short short_5 = 6;
    internal const short short_6 = 6;
    internal const short short_7 = 4;
    internal const short short_8 = 6;
    internal const short short_9 = 6;
    internal const short short_10 = 6;
    internal const double double_14 = 0.2;
    internal const short short_11 = 50;
    internal const double double_15 = 0.0;
    internal const double double_16 = 0.05;
    internal const bool bool_8 = true;
    internal const bool bool_9 = true;
    internal const bool bool_10 = true;
    internal const bool bool_11 = false;
    internal const SnapType snapType_0 = SnapType.Grid;
    internal const SnapStyle snapStyle_0 = SnapStyle.Standard;
    internal const double double_17 = 0.0;
    internal const ObjectSnapMode objectSnapMode_0 = ObjectSnapMode.None;
    internal const SimpleLineType simpleLineType_1 = SimpleLineType.Solid;
    private string string_1;
    private int int_1;
    private double double_18;
    private AngularUnit angularUnit_0;
    private short short_12;
    private double double_21;
    private double double_22;
    private bool bool_12;
    private PlotStyleType plotStyleType_1;
    private VerticalAlignment verticalAlignment_1;
    private bool bool_13;
    private bool bool_14;
    private bool bool_15;
    private bool bool_16;
    private bool bool_17;
    private bool bool_18;
    private bool bool_19;
    private bool bool_20;
    private bool bool_21;
    private EndCaps endCaps_0;
    private double double_25;
    private double double_27;
    private byte byte_0;
    private bool bool_23;
    private bool bool_24;
    private IndexCreationFlags indexCreationFlags_1;
    private bool bool_25;
    private bool bool_27;
    private bool bool_28;
    private readonly DxfDimensionStyleOverrides dxfDimensionStyleOverrides_0;
    private MeasurementUnits measurementUnits_0;
    private JoinStyle joinStyle_0;
    private bool bool_32;
    private SimpleLineType simpleLineType_2;
    private bool bool_34;
    private double double_29;
    private PlotStyleMode plotStyleMode_1;
    private PointDisplayMode pointDisplayMode_0;
    private double double_30;
    private double double_31;
    private ShadowMode shadowMode_1;
    private double double_32;
    private bool bool_39;
    private double double_35;
    private short short_27;
    private short short_28;
    private short short_29;
    private short short_30;
    private short short_31;
    private short short_32;
    private double double_37;
    private double double_38;
    private double double_39;
    private double double_40;
    private double double_41;
    private double double_42;
    private bool bool_42;
    private bool bool_43;
    private SnapType snapType_1;
    private SnapStyle snapStyle_1;
    private ObjectSnapMode objectSnapMode_1;
    private double double_43;
    private bool bool_45;
    private DxfScale dxfScale_0;
    private long long_0;
    private bool bool_48;

    public DxfHeader(DxfModel model)
    {
      this.dxfDimensionStyleOverrides_0 = new DxfDimensionStyleOverrides((DxfModel) null);
    }

    public static DrawingCodePage GetDrawingCodePage(string dwgCodePage)
    {
      int length = DxfHeader.object_0.GetLength(0);
      dwgCodePage = dwgCodePage.ToLower();
      for (int index = 0; index < length; ++index)
      {
        if (((string) DxfHeader.object_0[index, 1]).ToLower() == dwgCodePage)
          return (DrawingCodePage) DxfHeader.object_0[index, 0];
      }
      return DrawingCodePage.Unknown;
    }

    public static string GetDrawingCodePageString(DrawingCodePage drawingCodePage)
    {
      int length = DxfHeader.object_0.GetLength(0);
      for (int index = 0; index < length; ++index)
      {
        if ((DrawingCodePage) DxfHeader.object_0[index, 0] == drawingCodePage)
          return (string) DxfHeader.object_0[index, 1];
      }
      return (string) null;
    }

    public void CopyFrom(DxfHeader templateHeader, CloneContext cloneContext)
    {
      this.dictionary_0 = new Dictionary<string, List<Struct18>>((IDictionary<string, List<Struct18>>) templateHeader.dictionary_0);
      this.string_1 = templateHeader.string_1;
      this.int_1 = templateHeader.int_1;
      this.double_18 = templateHeader.double_18;
      this.angularDirection_1 = templateHeader.angularDirection_1;
      this.angularUnit_0 = templateHeader.angularUnit_0;
      this.short_12 = templateHeader.short_12;
      this.double_19 = templateHeader.double_19;
      this.double_20 = templateHeader.double_20;
      this.double_21 = templateHeader.double_21;
      this.double_22 = templateHeader.double_22;
      this.dateTime_0 = templateHeader.dateTime_0;
      this.bool_12 = templateHeader.bool_12;
      this.dateTime_1 = templateHeader.dateTime_1;
      this.color_0 = templateHeader.color_0;
      if (templateHeader.CurrentEntityLineType != null)
      {
        this.CurrentEntityLineType = cloneContext.TargetModel.GetLineTypeWithName(templateHeader.CurrentEntityLineType.Name);
        if (this.CurrentEntityLineType == null)
        {
          switch (cloneContext.ReferenceResolutionType)
          {
            case ReferenceResolutionType.CloneMissing:
              this.CurrentEntityLineType = (DxfLineType) templateHeader.CurrentEntityLineType.Clone(cloneContext);
              if (!cloneContext.CloneExact)
              {
                cloneContext.TargetModel.LineTypes.Add(this.CurrentEntityLineType);
                break;
              }
              break;
            case ReferenceResolutionType.FailOnMissing:
              throw new DxfException(string.Format("Could not resolve reference to line type with name {0}.", (object) templateHeader.CurrentEntityLineType.Name));
          }
        }
      }
      else
        this.CurrentEntityLineType = (DxfLineType) null;
      this.double_23 = templateHeader.double_23;
      this.short_13 = templateHeader.short_13;
      this.plotStyleType_1 = templateHeader.plotStyleType_1;
      this.double_24 = templateHeader.double_24;
      this.verticalAlignment_1 = templateHeader.verticalAlignment_1;
      if (templateHeader.CurrentMultilineStyle != null)
      {
        DxfMLineStyle currentMultilineStyle = templateHeader.CurrentMultilineStyle;
        List<DxfMLineStyle> all = cloneContext.TargetModel.MLineStyles.FindAll(currentMultilineStyle.Name);
        if (all.Count > 1)
          throw new Exception("Multiple MLINESTYLE objects found with name " + currentMultilineStyle.Name + " in target model.");
        this.CurrentMultilineStyle = all.Count == 1 ? all[0] : (DxfMLineStyle) null;
        if (this.CurrentMultilineStyle == null)
        {
          switch (cloneContext.ReferenceResolutionType)
          {
            case ReferenceResolutionType.CloneMissing:
              this.CurrentMultilineStyle = (DxfMLineStyle) templateHeader.CurrentMultilineStyle.Clone(cloneContext);
              if (!cloneContext.CloneExact)
              {
                cloneContext.TargetModel.MLineStyles.Add(this.CurrentMultilineStyle);
                break;
              }
              break;
            case ReferenceResolutionType.FailOnMissing:
              throw new DxfException(string.Format("Could not resolve reference to multiline style with name {0}.", (object) templateHeader.CurrentMultilineStyle.Name));
          }
        }
      }
      else
        this.CurrentMultilineStyle = (DxfMLineStyle) null;
      if (templateHeader.CurrentTextStyle != null)
      {
        DxfTextStyle currentTextStyle = templateHeader.CurrentTextStyle;
        this.CurrentTextStyle = cloneContext.TargetModel.GetTextStyleWithName(currentTextStyle.Name);
        if (this.CurrentTextStyle == null)
        {
          switch (cloneContext.ReferenceResolutionType)
          {
            case ReferenceResolutionType.CloneMissing:
              this.CurrentTextStyle = (DxfTextStyle) templateHeader.CurrentTextStyle.Clone(cloneContext);
              if (!cloneContext.CloneExact)
              {
                cloneContext.TargetModel.TextStyles.Add(this.CurrentTextStyle);
                break;
              }
              break;
            case ReferenceResolutionType.FailOnMissing:
              throw new DxfException(string.Format("Could not resolve reference to text style with name {0}.", (object) templateHeader.CurrentTextStyle.Name));
          }
        }
      }
      else
        this.CurrentTextStyle = (DxfTextStyle) null;
      this.dimensionAssociativity_1 = templateHeader.dimensionAssociativity_1;
      this.bool_13 = templateHeader.bool_13;
      if (templateHeader.DragVisualStyle != null)
      {
        this.DragVisualStyle = (DxfHandledObject) cloneContext.GetExistingClone((IGraphCloneable) templateHeader.DragVisualStyle);
        if (this.DragVisualStyle != null)
          ;
      }
      else
        this.DragVisualStyle = (DxfHandledObject) null;
      this.bool_14 = templateHeader.bool_14;
      this.bool_15 = templateHeader.bool_15;
      this.bool_16 = templateHeader.bool_16;
      this.bool_17 = templateHeader.bool_17;
      this.bool_18 = templateHeader.bool_18;
      this.bool_19 = templateHeader.bool_19;
      this.bool_20 = templateHeader.bool_20;
      this.bool_21 = templateHeader.bool_21;
      this.endCaps_0 = templateHeader.endCaps_0;
      this.double_25 = templateHeader.double_25;
      this.bool_22 = templateHeader.bool_22;
      this.double_26 = templateHeader.double_26;
      this.double_27 = templateHeader.double_27;
      this.string_2 = templateHeader.string_2;
      this.byte_0 = templateHeader.byte_0;
      this.drawingUnits_1 = templateHeader.drawingUnits_1;
      this.linearUnitFormat_1 = templateHeader.linearUnitFormat_1;
      this.short_14 = templateHeader.short_14;
      this.double_28 = templateHeader.double_28;
      this.drawingCodePage_0 = templateHeader.drawingCodePage_0;
      this.bool_23 = templateHeader.bool_23;
      this.short_15 = templateHeader.short_15;
      this.bool_24 = templateHeader.bool_24;
      this.ulong_0 = templateHeader.ulong_0;
      this.indexCreationFlags_1 = templateHeader.indexCreationFlags_1;
      this.color_1 = templateHeader.color_1;
      if (templateHeader.InterfereObjectStyle != null)
      {
        this.InterfereObjectStyle = (DxfHandledObject) cloneContext.GetExistingClone((IGraphCloneable) templateHeader.InterfereObjectStyle);
        if (this.InterfereObjectStyle != null)
          ;
      }
      else
        this.InterfereObjectStyle = (DxfHandledObject) null;
      if (templateHeader.InterfereViewportStyle != null)
      {
        this.InterfereViewportStyle = (DxfHandledObject) cloneContext.GetExistingClone((IGraphCloneable) templateHeader.InterfereViewportStyle);
        if (this.InterfereViewportStyle != null)
          ;
      }
      else
        this.InterfereViewportStyle = (DxfHandledObject) null;
      this.color_2 = templateHeader.color_2;
      this.bool_25 = templateHeader.bool_25;
      this.attributeVisibility_1 = templateHeader.attributeVisibility_1;
      this.bool_26 = templateHeader.bool_26;
      this.bool_27 = templateHeader.bool_27;
      this.paperSpaceLineTypeScaling_1 = templateHeader.paperSpaceLineTypeScaling_1;
      this.bool_28 = templateHeader.bool_28;
      this.bool_29 = templateHeader.bool_29;
      this.dxfDimensionStyleOverrides_0.CopyFrom(templateHeader.dxfDimensionStyleOverrides_0, cloneContext);
      this.measurementUnits_0 = templateHeader.measurementUnits_0;
      this.objectSortingFlags_1 = templateHeader.objectSortingFlags_1;
      this.point3D_0 = templateHeader.point3D_0;
      this.point3D_1 = templateHeader.point3D_1;
      this.point3D_2 = templateHeader.point3D_2;
      this.bool_30 = templateHeader.bool_30;
      this.bool_31 = templateHeader.bool_31;
      if (templateHeader.CurrentLayer != null)
      {
        this.CurrentLayer = cloneContext.TargetModel.GetLayerWithName(templateHeader.CurrentLayer.Name);
        if (this.CurrentLayer == null)
        {
          switch (cloneContext.ReferenceResolutionType)
          {
            case ReferenceResolutionType.CloneMissing:
              this.CurrentLayer = (DxfLayer) templateHeader.CurrentLayer.Clone(cloneContext);
              if (!cloneContext.CloneExact)
              {
                cloneContext.TargetModel.Layers.Add(this.CurrentLayer);
                break;
              }
              break;
            case ReferenceResolutionType.FailOnMissing:
              throw new DxfException(string.Format("Could not resolve reference to current layer with name {0}.", (object) templateHeader.CurrentLayer.Name));
          }
        }
      }
      else
        this.CurrentLayer = (DxfLayer) null;
      this.joinStyle_0 = templateHeader.joinStyle_0;
      this.bool_32 = templateHeader.bool_32;
      this.point2D_0 = templateHeader.point2D_0;
      this.point2D_1 = templateHeader.point2D_1;
      this.short_16 = templateHeader.short_16;
      this.string_3 = templateHeader.string_3;
      this.bool_33 = templateHeader.bool_33;
      this.color_3 = templateHeader.color_3;
      this.simpleLineType_2 = templateHeader.simpleLineType_2;
      this.bool_34 = templateHeader.bool_34;
      this.double_29 = templateHeader.double_29;
      this.point3D_3 = templateHeader.point3D_3;
      this.point3D_4 = templateHeader.point3D_4;
      this.point3D_5 = templateHeader.point3D_5;
      this.point2D_2 = templateHeader.point2D_2;
      this.point2D_3 = templateHeader.point2D_3;
      this.PaperSpaceUcs = Class906.smethod_2(cloneContext, templateHeader.PaperSpaceUcs);
      this.PaperSpaceUcsBase = Class906.smethod_2(cloneContext, templateHeader.PaperSpaceUcsBase);
      this.plotStyleMode_1 = templateHeader.plotStyleMode_1;
      this.pointDisplayMode_0 = templateHeader.pointDisplayMode_0;
      this.double_30 = templateHeader.double_30;
      this.polylineLineTypeGeneration_0 = templateHeader.polylineLineTypeGeneration_0;
      this.double_31 = templateHeader.double_31;
      this.string_4 = templateHeader.string_4;
      this.bool_35 = templateHeader.bool_35;
      this.bool_36 = templateHeader.bool_36;
      this.bool_37 = templateHeader.bool_37;
      this.short_17 = templateHeader.short_17;
      this.shadeEdge_1 = templateHeader.shadeEdge_1;
      this.shadowMode_1 = templateHeader.shadowMode_1;
      this.double_32 = templateHeader.double_32;
      this.bool_38 = templateHeader.bool_38;
      this.double_33 = templateHeader.double_33;
      this.bool_39 = templateHeader.bool_39;
      this.short_18 = templateHeader.short_18;
      this.splineType_1 = templateHeader.splineType_1;
      this.verticalAlignment_2 = templateHeader.verticalAlignment_2;
      this.short_19 = templateHeader.short_19;
      this.short_20 = templateHeader.short_20;
      this.short_21 = templateHeader.short_21;
      this.short_22 = templateHeader.short_22;
      this.short_23 = templateHeader.short_23;
      this.short_24 = templateHeader.short_24;
      this.short_25 = templateHeader.short_25;
      this.short_26 = templateHeader.short_26;
      this.double_34 = templateHeader.double_34;
      this.double_35 = templateHeader.double_35;
      this.double_36 = templateHeader.double_36;
      this.Ucs = Class906.smethod_2(cloneContext, templateHeader.Ucs);
      this.UcsBase = Class906.smethod_2(cloneContext, templateHeader.UcsBase);
      this.short_27 = templateHeader.short_27;
      this.dateTime_2 = templateHeader.dateTime_2;
      this.dateTime_3 = templateHeader.dateTime_3;
      this.dxfTimeSpan_0 = templateHeader.dxfTimeSpan_0;
      this.short_28 = templateHeader.short_28;
      this.short_29 = templateHeader.short_29;
      this.short_30 = templateHeader.short_30;
      this.short_31 = templateHeader.short_31;
      this.short_32 = templateHeader.short_32;
      this.double_37 = templateHeader.double_37;
      this.double_38 = templateHeader.double_38;
      this.double_39 = templateHeader.double_39;
      this.double_40 = templateHeader.double_40;
      this.double_41 = templateHeader.double_41;
      this.bool_40 = templateHeader.bool_40;
      this.string_5 = templateHeader.string_5;
      this.double_42 = templateHeader.double_42;
      this.bool_41 = templateHeader.bool_41;
      this.simpleLineType_3 = templateHeader.simpleLineType_3;
      this.bool_42 = templateHeader.bool_42;
      this.long_0 = templateHeader.long_0;
      this.bool_43 = templateHeader.bool_43;
      this.point2D_4 = templateHeader.point2D_4;
      this.vector2D_0 = templateHeader.vector2D_0;
      this.snapType_1 = templateHeader.snapType_1;
      this.snapStyle_1 = templateHeader.snapStyle_1;
      this.objectSnapMode_1 = templateHeader.objectSnapMode_1;
      this.double_43 = templateHeader.double_43;
      this.bool_44 = templateHeader.bool_44;
      this.bool_45 = templateHeader.bool_45;
      this.dxfScale_0 = templateHeader.dxfScale_0 != null ? (DxfScale) templateHeader.dxfScale_0.Clone(cloneContext) : (DxfScale) null;
      this.bool_46 = templateHeader.bool_46;
      this.bool_47 = templateHeader.bool_47;
      this.bool_48 = templateHeader.bool_48;
    }

    [DisplayName("AutoCAD version")]
    public string AcadVersionString
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.method_4(value, true);
      }
    }

    public int AcadMaintenanceVersion
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    public double AngleBase
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

    public AngularDirection AngularDirection
    {
      get
      {
        return this.angularDirection_1;
      }
      set
      {
        this.angularDirection_1 = value;
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

    public short AngularUnitPrecision
    {
      get
      {
        return this.short_12;
      }
      set
      {
        this.short_12 = value;
      }
    }

    public double ChamferDistance1
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

    public double ChamferDistance2
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

    public double ChamferLength
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

    public double ChamferAngle
    {
      get
      {
        return this.double_22;
      }
      set
      {
        this.double_22 = value;
      }
    }

    public DateTime CreateDateTime
    {
      get
      {
        return this.dateTime_0;
      }
      set
      {
        this.dateTime_0 = value;
      }
    }

    public bool CreateEllipseAsPolyline
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

    public DateTime CreateUtcDateTime
    {
      get
      {
        return this.dateTime_1;
      }
      set
      {
        this.dateTime_1 = value;
      }
    }

    public Color CurrentEntityColor
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

    public DxfLineType CurrentEntityLineType
    {
      get
      {
        return (DxfLineType) this.dxfObjectReference_0.Value;
      }
      set
      {
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public VerticalAlignment CurrentMultilineJustification
    {
      get
      {
        return this.verticalAlignment_1;
      }
      set
      {
        this.verticalAlignment_1 = value;
      }
    }

    public DxfMLineStyle CurrentMultilineStyle
    {
      get
      {
        return (DxfMLineStyle) this.dxfObjectReference_1.Value;
      }
      set
      {
        this.dxfObjectReference_1 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfTextStyle CurrentTextStyle
    {
      get
      {
        return (DxfTextStyle) this.dxfObjectReference_2.Value;
      }
      set
      {
        this.dxfObjectReference_2 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public double CurrentEntityLinetypeScale
    {
      get
      {
        return this.double_23;
      }
      set
      {
        this.double_23 = value;
      }
    }

    public short CurrentEntityLineWeight
    {
      get
      {
        return this.short_13;
      }
      set
      {
        this.short_13 = value;
      }
    }

    public PlotStyleType CurrentEntityPlotStyleType
    {
      get
      {
        return this.plotStyleType_1;
      }
      set
      {
        this.plotStyleType_1 = value;
      }
    }

    public double CurrentMultilineScale
    {
      get
      {
        return this.double_24;
      }
      set
      {
        this.double_24 = value;
      }
    }

    public DimensionAssociativity DimensionAssociativity
    {
      get
      {
        return this.dimensionAssociativity_1;
      }
      set
      {
        this.dimensionAssociativity_1 = value;
      }
    }

    public bool DisplaySilhouetteCurves
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

    private DxfHandledObject DragVisualStyle
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_3.Value;
      }
      set
      {
        this.dxfObjectReference_3 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfVersion AcadVersion
    {
      get
      {
        return DxfUtil.smethod_57(this.string_1);
      }
      set
      {
        string versionString;
        DxfUtil.smethod_58(value, out versionString, out this.int_1);
        this.AcadVersionString = versionString;
      }
    }

    public double Elevation
    {
      get
      {
        return this.double_25;
      }
      set
      {
        this.double_25 = value;
      }
    }

    public EndCaps EndCaps
    {
      get
      {
        return this.endCaps_0;
      }
      set
      {
        this.endCaps_0 = value;
      }
    }

    public ObjectSortingFlags EntitySortingFlags
    {
      get
      {
        return this.objectSortingFlags_1;
      }
      set
      {
        this.objectSortingFlags_1 = value;
      }
    }

    public bool ExtendedNames
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

    public double FacetResolution
    {
      get
      {
        return this.double_26;
      }
      set
      {
        this.double_26 = value;
      }
    }

    public double FilletRadius
    {
      get
      {
        return this.double_27;
      }
      set
      {
        this.double_27 = value;
      }
    }

    public string FingerPrintGuid
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value;
      }
    }

    public byte HaloGapPercentage
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

    public IndexCreationFlags IndexCreationFlags
    {
      get
      {
        return this.indexCreationFlags_1;
      }
      set
      {
        this.indexCreationFlags_1 = value;
      }
    }

    public Color InterfereColor
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

    public DxfHandledObject InterfereObjectStyle
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_4.Value;
      }
      set
      {
        this.dxfObjectReference_4 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfHandledObject InterfereViewportStyle
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_5.Value;
      }
      set
      {
        this.dxfObjectReference_5 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public Color IntersectionColor
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

    public bool IntersectionDisplay
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

    public Color ObscuredColor
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

    public SimpleLineType ObscuredLineType
    {
      get
      {
        return this.simpleLineType_2;
      }
      set
      {
        this.simpleLineType_2 = value;
      }
    }

    public string ProjectName
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

    public bool ProxyGraphics
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

    public DrawingUnits InsUnits
    {
      get
      {
        return this.drawingUnits_1;
      }
      set
      {
        this.drawingUnits_1 = value;
      }
    }

    public LinearUnitFormat LinearUnitFormat
    {
      get
      {
        return this.linearUnitFormat_1;
      }
      set
      {
        this.linearUnitFormat_1 = value;
      }
    }

    public short LinearUnitPrecision
    {
      get
      {
        return this.short_14;
      }
      set
      {
        this.short_14 = value;
      }
    }

    [DisplayName("Line type scale")]
    public double LineTypeScale
    {
      get
      {
        return this.double_28;
      }
      set
      {
        this.double_28 = value;
      }
    }

    [DisplayName("Show spline control points")]
    public bool ShowSplineControlPoints
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

    [Description("The number of spline segments for spline approximation")]
    [DisplayName("Nr of spline segments")]
    public short NumberOfSplineSegments
    {
      get
      {
        return this.short_15;
      }
      set
      {
        this.short_15 = value;
      }
    }

    internal string DrawingCodePageString
    {
      get
      {
        return DxfHeader.GetDrawingCodePageString(this.drawingCodePage_0);
      }
      set
      {
        this.drawingCodePage_0 = DxfHeader.GetDrawingCodePage(value);
      }
    }

    [DisplayName("Drawing code page")]
    public DrawingCodePage DrawingCodePage
    {
      get
      {
        return this.drawingCodePage_0;
      }
      set
      {
        this.drawingCodePage_0 = value;
      }
    }

    [Description("Determines whether objects have a handle or not.")]
    public bool Handling
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

    [Description("The next available handle.")]
    [DisplayName("Handle seed")]
    public ulong HandleSeed
    {
      get
      {
        return this.ulong_0;
      }
      set
      {
        this.ulong_0 = value;
      }
    }

    internal string HandleSeedString
    {
      get
      {
        return this.ulong_0.ToString("X", (IFormatProvider) CultureInfo.InvariantCulture);
      }
      set
      {
        this.ulong_0 = ulong.Parse(value, NumberStyles.HexNumber, (IFormatProvider) CultureInfo.InvariantCulture);
      }
    }

    [DisplayName("Attribute visibility")]
    [Description("Option for showing/hiding all attributes and attribute definitions.")]
    public AttributeVisibility AttributeVisibility
    {
      get
      {
        return this.attributeVisibility_1;
      }
      set
      {
        this.attributeVisibility_1 = value;
      }
    }

    [DisplayName("Show model space")]
    public bool ShowModelSpace
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

    [DisplayName("Fill mode")]
    [Description("Specifies whether to fill wide polylines etc. when viewing at right angle.")]
    public bool FillMode
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

    public PaperSpaceLineTypeScaling PaperSpaceLineTypeScaling
    {
      get
      {
        return this.paperSpaceLineTypeScaling_1;
      }
      set
      {
        this.paperSpaceLineTypeScaling_1 = value;
      }
    }

    public bool PaperSpaceLimitsChecking
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

    [Description("Specifies whether to display line weight.")]
    [DisplayName("Display line weight")]
    public bool DisplayLineWeight
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

    [DisplayName("Dimension style properties")]
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

    [DisplayName("Measurement units")]
    public MeasurementUnits MeasurementUnits
    {
      get
      {
        return this.measurementUnits_0;
      }
      set
      {
        this.measurementUnits_0 = value;
      }
    }

    [DisplayName("Ext min")]
    public WW.Math.Point3D ExtMin
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

    [DisplayName("Ext max")]
    public WW.Math.Point3D ExtMax
    {
      get
      {
        return this.point3D_1;
      }
      set
      {
        this.point3D_1 = value;
      }
    }

    public WW.Math.Point3D InsertionBase
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

    public bool AssociatedDimensions
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

    public bool UpdateDimensionsWhileDragging
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

    public DxfLayer CurrentLayer
    {
      get
      {
        return (DxfLayer) this.dxfObjectReference_6.Value;
      }
      set
      {
        this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public JoinStyle JoinStyle
    {
      get
      {
        return this.joinStyle_0;
      }
      set
      {
        this.joinStyle_0 = value;
      }
    }

    public bool LimitCheckingOn
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

    public WW.Math.Point2D LimitsMax
    {
      get
      {
        return this.point2D_0;
      }
      set
      {
        this.point2D_0 = value;
      }
    }

    public WW.Math.Point2D LimitsMin
    {
      get
      {
        return this.point2D_1;
      }
      set
      {
        this.point2D_1 = value;
      }
    }

    public short MaxViewportCount
    {
      get
      {
        return this.short_16;
      }
      set
      {
        this.short_16 = value;
      }
    }

    public string MenuFileName
    {
      get
      {
        return this.string_3;
      }
      set
      {
        this.string_3 = value;
      }
    }

    public bool MirrorText
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

    public bool OrthoMode
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

    public double PaperSpaceElevation
    {
      get
      {
        return this.double_29;
      }
      set
      {
        this.double_29 = value;
      }
    }

    public WW.Math.Point3D PaperSpaceExtMax
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

    public WW.Math.Point3D PaperSpaceExtMin
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

    public WW.Math.Point3D PaperSpaceInsertionBase
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

    public WW.Math.Point2D PaperSpaceLimitsMax
    {
      get
      {
        return this.point2D_2;
      }
      set
      {
        this.point2D_2 = value;
      }
    }

    public WW.Math.Point2D PaperSpaceLimitsMin
    {
      get
      {
        return this.point2D_3;
      }
      set
      {
        this.point2D_3 = value;
      }
    }

    public DxfUcs PaperSpaceUcs
    {
      get
      {
        return (DxfUcs) this.dxfObjectReference_7.Value;
      }
      set
      {
        this.dxfObjectReference_7 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfUcs PaperSpaceUcsBase
    {
      get
      {
        return (DxfUcs) this.dxfObjectReference_8.Value;
      }
      set
      {
        this.dxfObjectReference_8 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public PlotStyleMode PlotStyleMode
    {
      get
      {
        return this.plotStyleMode_1;
      }
      set
      {
        this.plotStyleMode_1 = value;
      }
    }

    public PointDisplayMode PointDisplayMode
    {
      get
      {
        return this.pointDisplayMode_0;
      }
      set
      {
        this.pointDisplayMode_0 = value;
      }
    }

    public double PointDisplaySize
    {
      get
      {
        return this.double_30;
      }
      set
      {
        this.double_30 = value;
      }
    }

    public PolylineLineTypeGeneration PolylineLineTypeGeneration
    {
      get
      {
        return this.polylineLineTypeGeneration_0;
      }
      set
      {
        this.polylineLineTypeGeneration_0 = value;
      }
    }

    public double PolylineWidthDefault
    {
      get
      {
        return this.double_31;
      }
      set
      {
        this.double_31 = value;
      }
    }

    public bool QuickTextMode
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

    public bool RegenerationMode
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

    public bool RetainXRefDependentVisibilitySettings
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

    public short ShadeDiffuseToAmbientPercentage
    {
      get
      {
        return this.short_17;
      }
      set
      {
        this.short_17 = value;
      }
    }

    public ShadeEdge ShadeEdge
    {
      get
      {
        return this.shadeEdge_1;
      }
      set
      {
        this.shadeEdge_1 = value;
      }
    }

    public ShadowMode ShadowMode
    {
      get
      {
        return this.shadowMode_1;
      }
      set
      {
        this.shadowMode_1 = value;
      }
    }

    public double ShadowPlaneLocation
    {
      get
      {
        return this.double_32;
      }
      set
      {
        this.double_32 = value;
      }
    }

    public double SketchIncrement
    {
      get
      {
        return this.double_33;
      }
      set
      {
        this.double_33 = value;
      }
    }

    public bool SketchPolylines
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

    public short SpatialIndexMaxTreeDepth
    {
      get
      {
        return this.short_18;
      }
      set
      {
        this.short_18 = value;
      }
    }

    public SplineType SplineType
    {
      get
      {
        return this.splineType_1;
      }
      set
      {
        this.splineType_1 = value;
      }
    }

    public VerticalAlignment StackedTextAlignment
    {
      get
      {
        return this.verticalAlignment_2;
      }
      set
      {
        this.verticalAlignment_2 = value;
      }
    }

    public short StackedTextSizePercentage
    {
      get
      {
        return this.short_19;
      }
      set
      {
        this.short_19 = value;
      }
    }

    public short SurfaceDensityU
    {
      get
      {
        return this.short_20;
      }
      set
      {
        this.short_20 = value;
      }
    }

    public short SurfaceDensityV
    {
      get
      {
        return this.short_21;
      }
      set
      {
        this.short_21 = value;
      }
    }

    public short SurfaceIsolineCount
    {
      get
      {
        return this.short_22;
      }
      set
      {
        this.short_22 = value;
      }
    }

    public short SurfaceMeshTabulationCount1
    {
      get
      {
        return this.short_23;
      }
      set
      {
        this.short_23 = value;
      }
    }

    public short SurfaceMeshTabulationCount2
    {
      get
      {
        return this.short_24;
      }
      set
      {
        this.short_24 = value;
      }
    }

    public short SurfaceType
    {
      get
      {
        return this.short_25;
      }
      set
      {
        this.short_25 = value;
      }
    }

    public short TextQuality
    {
      get
      {
        return this.short_26;
      }
      set
      {
        this.short_26 = value;
      }
    }

    public double TextHeightDefault
    {
      get
      {
        return this.double_34;
      }
      set
      {
        this.double_34 = value;
      }
    }

    public double ThicknessDefault
    {
      get
      {
        return this.double_35;
      }
      set
      {
        this.double_35 = value;
      }
    }

    public double TraceWidthDefault
    {
      get
      {
        return this.double_36;
      }
      set
      {
        this.double_36 = value;
      }
    }

    public DxfUcs Ucs
    {
      get
      {
        return (DxfUcs) this.dxfObjectReference_9.Value;
      }
      set
      {
        this.dxfObjectReference_9 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfUcs UcsBase
    {
      get
      {
        return (DxfUcs) this.dxfObjectReference_10.Value;
      }
      set
      {
        this.dxfObjectReference_10 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public short UnitMode
    {
      get
      {
        return this.short_27;
      }
      set
      {
        this.short_27 = value;
      }
    }

    public DateTime UpdateDateTime
    {
      get
      {
        return this.dateTime_2;
      }
      set
      {
        this.dateTime_2 = value;
      }
    }

    public DateTime UpdateUtcDateTime
    {
      get
      {
        return this.dateTime_3;
      }
      set
      {
        this.dateTime_3 = value;
      }
    }

    public DxfTimeSpan UserElapsedTimeSpan
    {
      get
      {
        return this.dxfTimeSpan_0;
      }
      set
      {
        this.dxfTimeSpan_0 = value;
      }
    }

    public short UserShort1
    {
      get
      {
        return this.short_28;
      }
      set
      {
        this.short_28 = value;
      }
    }

    public short UserShort2
    {
      get
      {
        return this.short_29;
      }
      set
      {
        this.short_29 = value;
      }
    }

    public short UserShort3
    {
      get
      {
        return this.short_30;
      }
      set
      {
        this.short_30 = value;
      }
    }

    public short UserShort4
    {
      get
      {
        return this.short_31;
      }
      set
      {
        this.short_31 = value;
      }
    }

    public short UserShort5
    {
      get
      {
        return this.short_32;
      }
      set
      {
        this.short_32 = value;
      }
    }

    public double UserDouble1
    {
      get
      {
        return this.double_37;
      }
      set
      {
        this.double_37 = value;
      }
    }

    public double UserDouble2
    {
      get
      {
        return this.double_38;
      }
      set
      {
        this.double_38 = value;
      }
    }

    public double UserDouble3
    {
      get
      {
        return this.double_39;
      }
      set
      {
        this.double_39 = value;
      }
    }

    public double UserDouble4
    {
      get
      {
        return this.double_40;
      }
      set
      {
        this.double_40 = value;
      }
    }

    public double UserDouble5
    {
      get
      {
        return this.double_41;
      }
      set
      {
        this.double_41 = value;
      }
    }

    public bool UserTimer
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

    public string VersionGuid
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

    public double ViewportDefaultViewScaleFactor
    {
      get
      {
        return this.double_42;
      }
      set
      {
        this.double_42 = value;
      }
    }

    public bool WorldView
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

    public bool XEdit
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

    public long RequiredVersions
    {
      get
      {
        return this.long_0;
      }
      set
      {
        this.long_0 = value;
      }
    }

    public SimpleLineType ExternalReferenceClippingBoundaryType
    {
      get
      {
        return this.simpleLineType_3;
      }
      set
      {
        this.simpleLineType_3 = value;
      }
    }

    public ObjectSnapMode ObjectSnapMode
    {
      get
      {
        return this.objectSnapMode_1;
      }
      set
      {
        this.objectSnapMode_1 = value;
      }
    }

    public double SnapAngle
    {
      get
      {
        return this.double_43;
      }
      set
      {
        this.double_43 = value;
      }
    }

    public SnapStyle SnapStyle
    {
      get
      {
        return this.snapStyle_1;
      }
      set
      {
        this.snapStyle_1 = value;
      }
    }

    public SnapType SnapType
    {
      get
      {
        return this.snapType_1;
      }
      set
      {
        this.snapType_1 = value;
      }
    }

    public Vector2D SnapSpacing
    {
      get
      {
        return this.vector2D_0;
      }
      set
      {
        this.vector2D_0 = value;
      }
    }

    public WW.Math.Point2D SnapBase
    {
      get
      {
        return this.point2D_4;
      }
      set
      {
        this.point2D_4 = value;
      }
    }

    public bool SnapMode
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

    public DxfScale CurrentAnnotationScale
    {
      get
      {
        return this.dxfScale_0;
      }
      set
      {
        this.dxfScale_0 = value;
      }
    }

    public bool ModelSpaceAnnotationScalingEnabled
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

    public bool PaperSpaceAnnotationScalingEnabled
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

    public bool AnnotationsAlwaysVisible
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

    public bool AnnotativeDrawing
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

    internal bool Dxf13OrHigher
    {
      get
      {
        return this.bool_14;
      }
    }

    internal bool Dxf14OrHigher
    {
      get
      {
        return this.bool_15;
      }
    }

    internal bool Dxf15OrHigher
    {
      get
      {
        return this.bool_16;
      }
    }

    internal bool Dxf16OrHigher
    {
      get
      {
        return this.bool_17;
      }
    }

    internal bool Dxf18OrHigher
    {
      get
      {
        return this.bool_18;
      }
    }

    internal bool Dxf19OrHigher
    {
      get
      {
        return this.bool_19;
      }
    }

    internal bool Dxf21OrHigher
    {
      get
      {
        return this.bool_20;
      }
    }

    internal bool Dxf24OrHigher
    {
      get
      {
        return this.bool_21;
      }
    }

    internal bool DimSav
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

    internal void method_0(string variableName, List<Struct18> value)
    {
      this.dictionary_0[variableName] = value;
    }

    internal void method_1(string variableName, Struct18 value)
    {
      this.dictionary_0[variableName] = new List<Struct18>(1)
      {
        value
      };
    }

    internal object method_2(string variableName)
    {
      return (object) this.dictionary_0[variableName];
    }

    internal IList<Class980> method_3()
    {
      List<Class980> class980List = new List<Class980>();
      foreach (string key in this.dictionary_0.Keys)
      {
        List<Struct18> valueGroups = this.dictionary_0[key];
        if (valueGroups != null)
        {
          Class980 class980 = new Class980(key, valueGroups);
          class980List.Add(class980);
        }
      }
      return (IList<Class980>) class980List;
    }

    internal void method_4(string value, bool active)
    {
      this.string_1 = value;
      if (value == null)
      {
        this.bool_14 = false;
      }
      else
      {
        string upper = this.string_1.ToUpper();
        this.bool_14 = string.CompareOrdinal("AC1012", upper) <= 0;
        this.bool_15 = string.CompareOrdinal("AC1014", upper) <= 0;
        this.bool_16 = string.CompareOrdinal("AC1015", upper) <= 0;
        this.bool_17 = string.CompareOrdinal("AC1016", upper) <= 0;
        this.bool_18 = string.CompareOrdinal("AC1018", upper) <= 0;
        this.bool_19 = string.CompareOrdinal("AC1019", upper) <= 0;
        this.bool_20 = string.CompareOrdinal("AC1021", upper) <= 0;
        this.bool_21 = string.CompareOrdinal("AC1024", upper) <= 0;
      }
      if (this.bool_14)
        this.bool_24 = true;
      if (!active)
        return;
      this.bool_22 = this.bool_16;
    }

    internal void method_5(DxfModel model)
    {
      this.CurrentLayer = model.ZeroLayer;
      this.CurrentTextStyle = model.DefaultTextStyle;
      this.CurrentEntityLineType = model.ByLayerLineType;
      this.DimensionStyle = model.CurrentDimensionStyle;
      this.CurrentMultilineStyle = model.DefaultMLineStyle;
    }

    internal void method_6(DxfModel model)
    {
      if (this.CurrentLayer == null)
        this.CurrentLayer = model.ZeroLayer;
      if (this.CurrentTextStyle == null)
        this.CurrentTextStyle = model.DefaultTextStyle;
      if (this.CurrentEntityLineType == null)
        this.CurrentEntityLineType = model.ContinuousLineType;
      if (this.DimensionStyle == null)
        this.DimensionStyle = model.CurrentDimensionStyle;
      if (this.CurrentMultilineStyle == null)
        this.CurrentMultilineStyle = model.DefaultMLineStyle;
      if (this.AcadVersion != DxfVersion.Dxf27 || this.AcadMaintenanceVersion >= 9 || (this.AcadMaintenanceVersion == 6 || this.AcadMaintenanceVersion == 8))
        return;
      this.AcadMaintenanceVersion = 8;
    }

    private void method_7(List<Struct18> groups, ref WW.Math.Vector3D v)
    {
      for (int index = 0; index < groups.Count; ++index)
      {
        Struct18 group = groups[index];
        switch (group.Code)
        {
          case 10:
            v.X = (double) group.Value;
            break;
          case 20:
            v.Y = (double) group.Value;
            break;
          case 30:
            v.Z = (double) group.Value;
            break;
        }
      }
    }

    private void method_8(List<Struct18> groups, ref WW.Math.Point3D p)
    {
      for (int index = 0; index < groups.Count; ++index)
      {
        Struct18 group = groups[index];
        switch (group.Code)
        {
          case 10:
            p.X = (double) group.Value;
            break;
          case 20:
            p.Y = (double) group.Value;
            break;
          case 30:
            p.Z = (double) group.Value;
            break;
        }
      }
    }

    internal static string smethod_0(DxfBlock block)
    {
      if (block == null)
        return (string) null;
      string str = block.Name;
      if (str != null && str.StartsWith("_"))
        str = str.Substring(1);
      return str;
    }

    internal static short smethod_1(bool value)
    {
      return value ? (short) 1 : (short) 0;
    }

    internal static bool smethod_2(short value)
    {
      return value != (short) 0;
    }

    static DxfHeader()
    {
      typeof (DxfHeader).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    }

    private static Attribute1 smethod_3(PropertyInfo propertyInfo)
    {
      object[] customAttributes = propertyInfo.GetCustomAttributes(typeof (Attribute1), false);
      return customAttributes == null || customAttributes.Length <= 0 ? (Attribute1) null : (Attribute1) customAttributes[0];
    }

    private class Class944 : IComparable
    {
      private readonly Attribute1 attribute1_0;
      private readonly PropertyInfo propertyInfo_0;

      internal Class944(Attribute1 variableAttribute, PropertyInfo property)
      {
        this.attribute1_0 = variableAttribute;
        this.propertyInfo_0 = property;
      }

      internal Attribute1 VariableAttribute
      {
        get
        {
          return this.attribute1_0;
        }
      }

      internal PropertyInfo PropertyInfo
      {
        get
        {
          return this.propertyInfo_0;
        }
      }

      internal object GetValue(DxfHeader target)
      {
        return this.propertyInfo_0.GetValue((object) target, (object[]) null);
      }

      internal void SetValue(DxfHeader target, object value)
      {
        this.propertyInfo_0.SetValue((object) target, value, (object[]) null);
      }

      public int CompareTo(object other)
      {
        return string.CompareOrdinal(this.attribute1_0.Name, ((DxfHeader.Class944) other).attribute1_0.Name);
      }
    }
  }
}
