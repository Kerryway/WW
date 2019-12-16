// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.GraphicsConfig
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.ComponentModel;
using WW.Cad.Model;
using WW.ComponentModel;
using WW.Drawing;

namespace WW.Cad.Drawing
{
  [System.ComponentModel.TypeConverter(typeof (SortedPropertiesTypeConverter))]
  public class GraphicsConfig : TransformConfig, WW.ICloneable
  {
    public static readonly GraphicsConfig AcadLikeWithBlackBackground = new GraphicsConfig(true, ArgbColors.Black, IndexedColorHandling.BehaveLikeAutocad);
    public static readonly GraphicsConfig AcadLikeWithWhiteBackground = new GraphicsConfig(true, ArgbColors.White, IndexedColorHandling.BehaveLikeAutocad);
    [Obsolete]
    public static readonly GraphicsConfig BlackBackground = new GraphicsConfig(true, ArgbColors.Black);
    public static readonly GraphicsConfig BlackBackgroundCorrectForBackColor = new GraphicsConfig(true, ArgbColors.Black, true);
    public static readonly GraphicsConfig WhiteBackground = new GraphicsConfig(true, ArgbColors.White);
    public static readonly GraphicsConfig WhiteBackgroundCorrectForBackColor = new GraphicsConfig(true, ArgbColors.White, true);
    private short short_0 = 30;
    private short short_1 = 6;
    private short short_2 = 32;
    private bool bool_3 = true;
    private bool bool_4 = true;
    private bool bool_10 = true;
    private short short_3 = 25;
    private ArgbColor argbColor_0 = ArgbColors.Black;
    private bool bool_12 = true;
    private ArgbColor? nullable_0 = new ArgbColor?();
    private double double_2 = 6.0;
    private ArgbColor argbColor_1 = ArgbColors.Yellow;
    private bool bool_14 = true;
    private bool bool_15 = true;
    private int int_0 = 1000;
    private int int_1 = 100000;
    private bool bool_16 = true;
    private HatchOverflowHandling hatchOverflowHandling_0 = HatchOverflowHandling.SolidFill;
    private bool bool_17 = true;
    private double double_3 = -0.01;
    private double double_4 = -0.05;
    private bool bool_19 = true;
    private int int_2 = 200;
    private int int_3 = 2000;
    private bool bool_1;
    private bool bool_2;
    private bool bool_5;
    private bool bool_6;
    private bool bool_7;
    private bool bool_8;
    private bool bool_9;
    private bool bool_11;
    private double double_0;
    private double double_1;
    private IndexedColorHandling indexedColorHandling_0;
    private DxfIndexedColorSet dxfIndexedColorSet_0;
    private bool bool_13;
    private readonly bool bool_18;
    private bool bool_20;
    private PlotStyleProvider plotStyleProvider_0;
    private MultiLineAttributeHandling multiLineAttributeHandling_0;

    public GraphicsConfig()
      : this(ArgbColors.Black)
    {
    }

    public GraphicsConfig(ArgbColor backgroundColor)
      : this(false, backgroundColor)
    {
    }

    [Obsolete]
    public GraphicsConfig(ArgbColor backgroundColor, bool correctColorForBackgroundColor)
      : this(false, backgroundColor, correctColorForBackgroundColor)
    {
    }

    public GraphicsConfig(ArgbColor backgroundColor, IndexedColorHandling indexedColorHandling)
      : this(false, backgroundColor, indexedColorHandling)
    {
    }

    public GraphicsConfig(bool readOnly)
      : this(readOnly, ArgbColors.Black)
    {
    }

    public GraphicsConfig(bool readOnly, ArgbColor backgroundColor)
      : this(readOnly, backgroundColor, IndexedColorHandling.BehaveLikeAutocad)
    {
    }

    [Obsolete]
    public GraphicsConfig(
      bool readOnly,
      ArgbColor backgroundColor,
      bool correctColorForBackgroundColor)
      : this(readOnly, backgroundColor, correctColorForBackgroundColor ? IndexedColorHandling.BehaveLikeClassicCadlibWithBackgroundCorrection : IndexedColorHandling.BehaveLikeClassicCadlibWithoutBackgroundCorrection)
    {
    }

    public GraphicsConfig(
      bool readOnly,
      ArgbColor backgroundColor,
      IndexedColorHandling indexedColorHandling)
    {
      this.argbColor_0 = backgroundColor;
      this.DotsPerInch = 100.0;
      this.bool_18 = readOnly;
      this.indexedColorHandling_0 = indexedColorHandling;
      this.bool_12 = indexedColorHandling == IndexedColorHandling.BehaveLikeClassicCadlibWithBackgroundCorrection;
      this.method_1();
    }

    [PropertyIndex(1)]
    [Description("Defines the background color of the view.")]
    [DisplayName("Background Color")]
    public ArgbColor BackColor
    {
      get
      {
        return this.argbColor_0;
      }
      set
      {
        this.method_0();
        this.argbColor_0 = value;
        this.method_1();
      }
    }

    [Description("Defines the number of line segments in which arcs, circles and ellipses are split.")]
    [DisplayName("No of arc line segments")]
    [PropertyIndex(2)]
    public short NoOfArcLineSegments
    {
      get
      {
        return this.short_0;
      }
      set
      {
        this.method_0();
        if (value < (short) 3)
          value = (short) 3;
        if (value > (short) 1000)
          value = (short) 1000;
        this.short_0 = value;
      }
    }

    [PropertyIndex(3)]
    [DisplayName("Minimum no of arc line segments")]
    [Description("Defines the minimum number of line segments in which arcs are split.")]
    public short NoOfArcLineSegmentsMinimum
    {
      get
      {
        return this.short_1;
      }
      set
      {
        this.method_0();
        if (value < (short) 1)
          value = (short) 1;
        if (value > (short) 1000)
          value = (short) 1000;
        this.short_1 = value;
      }
    }

    [PropertyIndex(3)]
    [DisplayName("No of spline line segments")]
    [Description("Defines the number of line segments in which splines, and beziers parts are split.")]
    public short NoOfSplineLineSegments
    {
      get
      {
        return this.short_2;
      }
      set
      {
        this.method_0();
        if (value < (short) 1)
          value = (short) 1;
        if (value > (short) 1000)
          value = (short) 1000;
        this.short_2 = value;
      }
    }

    [Description("Defines the maximum deviation allowed for flattening shapes.If greater than zero, the value is absolute, if less than zero, it's relative to the shape's size.")]
    [PropertyIndex(4)]
    [DisplayName("Accuracy for converting shapes into polylines")]
    public double ShapeFlattenEpsilon
    {
      get
      {
        return this.double_3;
      }
      set
      {
        this.method_0();
        if (value == 0.0)
          value = -0.01;
        this.double_3 = value;
      }
    }

    [PropertyIndex(5)]
    [DisplayName("Accuracy for converting shapes into polylines")]
    [Description("Defines the maximum deviation allowed for flattening shapes in the context of clipping.If greater zero, the value is absolute, if less than zero, it's relative to the shape's size.")]
    public double ShapeFlattenEpsilonForBoundsCalculation
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

    [DisplayName("Show spline approximation points")]
    [PropertyIndex(10)]
    [Description("Defines whether to show the precalculated spline approximation points that are stored in the DXF model.")]
    public bool ShowSplineApproximationPoints
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.method_0();
        this.bool_2 = value;
      }
    }

    [DisplayName("Show spline control points")]
    [PropertyIndex(11)]
    [Description("Defines whether to show the spline control points.")]
    public bool ShowSplineControlPoints
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.method_0();
        this.bool_1 = value;
      }
    }

    [Description("Defines whether to show the spline interpolated points.")]
    [PropertyIndex(12)]
    [DisplayName("Show spline interpolated points")]
    public bool ShowSplineInterpolatedPoints
    {
      get
      {
        return this.bool_3;
      }
      set
      {
        this.method_0();
        this.bool_3 = value;
      }
    }

    [Description("Defines whether to  apply line type to lines.")]
    [DisplayName("Apply line type")]
    [PropertyIndex(30)]
    public bool ApplyLineType
    {
      get
      {
        return this.bool_4;
      }
      set
      {
        this.method_0();
        this.bool_4 = value;
      }
    }

    [PropertyIndex(52)]
    [Description("Defines whether to show the text alignment points (either one or two).")]
    [DisplayName("Show text alignment points")]
    public bool ShowTextAlignmentPoints
    {
      get
      {
        return this.bool_5;
      }
      set
      {
        this.method_0();
        this.bool_5 = value;
      }
    }

    [Description("Defines whether to show hatch boundary lines.")]
    [PropertyIndex(53)]
    [DisplayName("Show hatch boundaries")]
    public bool ShowHatchBoundaries
    {
      get
      {
        return this.bool_6;
      }
      set
      {
        this.method_0();
        this.bool_6 = value;
      }
    }

    public bool ShowDisabledLayers
    {
      get
      {
        return this.bool_7;
      }
      set
      {
        this.method_0();
        this.bool_7 = value;
      }
    }

    [DisplayName("Show frozen layers")]
    [Description("Defines whether to show frozen layers.")]
    [PropertyIndex(54)]
    public bool ShowFrozenLayers
    {
      get
      {
        return this.bool_8;
      }
      set
      {
        this.method_0();
        this.bool_8 = value;
      }
    }

    [PropertyIndex(55)]
    [Description("Defines whether to show the dimension definition points.")]
    [DisplayName("Show dimension definition points")]
    public bool ShowDimensionDefinitionPoints
    {
      get
      {
        return this.bool_9;
      }
      set
      {
        this.method_0();
        this.bool_9 = value;
      }
    }

    [PropertyIndex(60)]
    public bool DisplayLineWeight
    {
      get
      {
        return this.bool_10;
      }
      set
      {
        this.method_0();
        this.bool_10 = value;
      }
    }

    [PropertyIndex(67)]
    public short DefaultLineWeight
    {
      get
      {
        return this.short_3;
      }
      set
      {
        this.method_0();
        this.short_3 = value;
      }
    }

    [PropertyIndex(68)]
    public bool DisplayLineTypeElementShapes
    {
      get
      {
        return this.bool_11;
      }
      set
      {
        this.method_0();
        this.bool_11 = value;
      }
    }

    [PropertyIndex(70)]
    public double DotsPerInch
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.method_0();
        this.double_0 = value;
        this.double_1 = value / 2540.0;
      }
    }

    public bool CorrectColorForBackgroundColor
    {
      get
      {
        return this.bool_12;
      }
      set
      {
        this.method_0();
        this.bool_12 = value;
        switch (this.indexedColorHandling_0)
        {
          case IndexedColorHandling.BehaveLikeClassicCadlibWithoutBackgroundCorrection:
          case IndexedColorHandling.BehaveLikeClassicCadlibWithBackgroundCorrection:
            this.method_1();
            break;
        }
      }
    }

    [Browsable(false)]
    public DxfIndexedColorSet IndexedColors
    {
      get
      {
        return this.dxfIndexedColorSet_0;
      }
    }

    public ArgbColor? FixedForegroundColor
    {
      get
      {
        return this.nullable_0;
      }
      set
      {
        this.method_0();
        this.nullable_0 = value;
      }
    }

    public double NodeSize
    {
      get
      {
        return this.double_2;
      }
      set
      {
        this.method_0();
        this.double_2 = value;
      }
    }

    public ArgbColor NodeColor
    {
      get
      {
        return this.argbColor_1;
      }
      set
      {
        this.method_0();
        this.argbColor_1 = value;
      }
    }

    public bool TryDrawingTextAsText
    {
      get
      {
        return this.bool_13;
      }
      set
      {
        this.method_0();
        this.bool_13 = value;
      }
    }

    public bool DrawImages
    {
      get
      {
        return this.bool_14;
      }
      set
      {
        this.method_0();
        this.bool_14 = value;
      }
    }

    public bool DrawImageFrame
    {
      get
      {
        return this.bool_15;
      }
      set
      {
        this.method_0();
        this.bool_15 = value;
      }
    }

    public int MaxLineTypeRepeatCount
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.method_0();
        this.int_0 = value;
      }
    }

    public int MaxHatchPatternRepeatCount
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.method_0();
        this.int_1 = value;
      }
    }

    public bool DrawHatchPatterns
    {
      get
      {
        return this.bool_16;
      }
      set
      {
        this.method_0();
        this.bool_16 = value;
      }
    }

    public HatchOverflowHandling HatchOverflowHandling
    {
      get
      {
        return this.hatchOverflowHandling_0;
      }
      set
      {
        this.method_0();
        this.hatchOverflowHandling_0 = value;
      }
    }

    [Browsable(false)]
    public bool UseSpatialFilters
    {
      get
      {
        return this.bool_17;
      }
      set
      {
        this.method_0();
        this.bool_17 = value;
      }
    }

    [Browsable(false)]
    public bool UseSortEntsTables
    {
      get
      {
        return this.bool_19;
      }
      set
      {
        this.method_0();
        this.bool_19 = value;
      }
    }

    public bool Plot
    {
      get
      {
        return this.bool_20;
      }
      set
      {
        this.method_0();
        this.bool_20 = value;
      }
    }

    [PropertyIndex(100)]
    public bool ReadOnly
    {
      get
      {
        return this.bool_18;
      }
    }

    [Browsable(false)]
    public PlotStyleProvider PlotStyleManager
    {
      get
      {
        return this.plotStyleProvider_0;
      }
      set
      {
        this.method_0();
        this.plotStyleProvider_0 = value;
      }
    }

    public int OleImageSize
    {
      get
      {
        return this.int_2;
      }
      set
      {
        this.method_0();
        this.int_2 = value;
      }
    }

    public int MaxScalableImageSize
    {
      get
      {
        return this.int_3;
      }
      set
      {
        this.method_0();
        this.int_3 = value;
      }
    }

    public MultiLineAttributeHandling MultiLineAttributeHandling
    {
      get
      {
        return this.multiLineAttributeHandling_0;
      }
      set
      {
        this.method_0();
        this.multiLineAttributeHandling_0 = value;
      }
    }

    public override bool TreatAttributesAsPartOfInsert
    {
      get
      {
        return base.TreatAttributesAsPartOfInsert;
      }
      set
      {
        this.method_0();
        base.TreatAttributesAsPartOfInsert = value;
      }
    }

    internal double DotsPerHundredthMm
    {
      get
      {
        return this.double_1;
      }
    }

    private void method_0()
    {
      if (this.bool_18)
        throw new InternalException("This object is readonly, clone this object to make modifications.");
    }

    private void method_1()
    {
      switch (this.indexedColorHandling_0)
      {
        case IndexedColorHandling.BehaveLikeAutocad:
          this.dxfIndexedColorSet_0 = DxfIndexedColorSet.GetAcadIndexedColorSet(this.argbColor_0);
          break;
        case IndexedColorHandling.BehaveLikeClassicCadlibWithoutBackgroundCorrection:
          this.dxfIndexedColorSet_0 = DxfIndexedColorSet.CadlibClassicIndexedColors;
          break;
        case IndexedColorHandling.BehaveLikeClassicCadlibWithBackgroundCorrection:
          this.dxfIndexedColorSet_0 = DxfIndexedColorSet.smethod_13(this.argbColor_0);
          break;
      }
    }

    public object Clone()
    {
      GraphicsConfig graphicsConfig = new GraphicsConfig() { short_0 = this.short_0, short_1 = this.short_1, short_2 = this.short_2, bool_1 = this.bool_1, bool_2 = this.bool_2, bool_3 = this.bool_3, bool_4 = this.bool_4, bool_5 = this.bool_5, bool_6 = this.bool_6, bool_7 = this.bool_7, bool_8 = this.bool_8, bool_9 = this.bool_9, bool_10 = this.bool_10, short_3 = this.short_3, bool_11 = this.bool_11, double_0 = this.double_0, double_1 = this.double_1, argbColor_0 = this.argbColor_0, bool_12 = this.bool_12, indexedColorHandling_0 = this.indexedColorHandling_0, dxfIndexedColorSet_0 = this.dxfIndexedColorSet_0, nullable_0 = this.nullable_0, double_2 = this.double_2, argbColor_1 = this.argbColor_1, bool_13 = this.bool_13, bool_14 = this.bool_14 };
      graphicsConfig.bool_14 = this.bool_15;
      graphicsConfig.int_0 = this.int_0;
      graphicsConfig.int_1 = this.int_1;
      graphicsConfig.bool_16 = this.bool_16;
      graphicsConfig.PlotStyleManager = this.plotStyleProvider_0;
      graphicsConfig.bool_17 = this.bool_17;
      graphicsConfig.double_3 = this.double_3;
      graphicsConfig.double_4 = this.double_4;
      graphicsConfig.bool_19 = this.bool_19;
      graphicsConfig.bool_20 = this.bool_20;
      graphicsConfig.TreatAttributesAsPartOfInsert = this.TreatAttributesAsPartOfInsert;
      graphicsConfig.int_2 = this.int_2;
      graphicsConfig.int_3 = this.int_3;
      graphicsConfig.multiLineAttributeHandling_0 = this.multiLineAttributeHandling_0;
      return (object) graphicsConfig;
    }

    internal class Class536
    {
      private float float_0;
      private float float_1;
      private float float_2;

      public Class536(float t)
      {
        this.float_0 = t;
        this.float_1 = t * t;
        this.float_2 = this.float_1 * t;
      }

      public float T
      {
        get
        {
          return this.float_0;
        }
      }

      public float TT
      {
        get
        {
          return this.float_1;
        }
      }

      public float TTT
      {
        get
        {
          return this.float_2;
        }
      }
    }
  }
}
