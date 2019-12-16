// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfPlotSettings
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Objects
{
  public class DxfPlotSettings : DxfObject
  {
    private string string_0 = string.Empty;
    private string string_1 = "C:\\Program Files\\AutoCAD 2002\\plotters\\DWF ePlot (optimized for plotting).pc3";
    private string string_2 = string.Empty;
    private string string_3 = string.Empty;
    private double double_4 = 1.0;
    private double double_5 = 1.0;
    private PlotLayoutFlags plotLayoutFlags_0 = PlotLayoutFlags.UseStandardScale | PlotLayoutFlags.PlotPlotStyles | PlotLayoutFlags.PrintLineweights | PlotLayoutFlags.DrawViewportsFirst;
    private PlotPaperUnits plotPaperUnits_0 = PlotPaperUnits.Millimeters;
    private PlotRotation plotRotation_0 = PlotRotation.QuarterCounterClockwise;
    private PlotArea plotArea_0 = PlotArea.DrawingExtents;
    private string string_4 = "acad.stb";
    private double double_6 = 1.0;
    private double double_0;
    private double double_1;
    private double double_2;
    private double double_3;
    private Size2D size2D_0;
    private WW.Math.Point2D point2D_0;
    private Rectangle2D rectangle2D_0;
    private short short_0;
    private ShadePlotMode shadePlotMode_0;
    private ShadePlotResolution shadePlotResolution_0;
    private short short_1;
    private WW.Math.Point2D point2D_1;

    public string PageSetupName
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

    public string PlotConfigurationFile
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public string PaperSizeName
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

    public string PlotViewName
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

    public double UnprintableMarginLeft
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

    public double UnprintableMarginRight
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

    public double UnprintableMarginBottom
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

    public double UnprintableMarginTop
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

    public Size2D PlotPaperSize
    {
      get
      {
        return this.size2D_0;
      }
      set
      {
        this.size2D_0 = value;
      }
    }

    public WW.Math.Point2D PlotOrigin
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

    public Rectangle2D PlotWindowArea
    {
      get
      {
        return this.rectangle2D_0;
      }
      set
      {
        this.rectangle2D_0 = value;
      }
    }

    public double CustomPrintScaleNumerator
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

    public double CustomPrintScaleDenominator
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

    public PlotLayoutFlags PlotLayoutFlags
    {
      get
      {
        return this.plotLayoutFlags_0;
      }
      set
      {
        this.plotLayoutFlags_0 = value;
      }
    }

    public PlotPaperUnits PlotPaperUnits
    {
      get
      {
        return this.plotPaperUnits_0;
      }
      set
      {
        this.plotPaperUnits_0 = value;
      }
    }

    public PlotRotation PlotRotation
    {
      get
      {
        return this.plotRotation_0;
      }
      set
      {
        this.plotRotation_0 = value;
      }
    }

    public PlotArea PlotArea
    {
      get
      {
        return this.plotArea_0;
      }
      set
      {
        this.plotArea_0 = value;
      }
    }

    public string CurrentStyleSheet
    {
      get
      {
        return this.string_4;
      }
      set
      {
        this.string_4 = value ?? string.Empty;
      }
    }

    public short StandardScaleType
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

    public ShadePlotMode ShadePlotMode
    {
      get
      {
        return this.shadePlotMode_0;
      }
      set
      {
        this.shadePlotMode_0 = value;
      }
    }

    public ShadePlotResolution ShadePlotResolution
    {
      get
      {
        return this.shadePlotResolution_0;
      }
      set
      {
        this.shadePlotResolution_0 = value;
      }
    }

    public short ShadePlotCustomDpi
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

    public double StandardScaleFactor
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

    public WW.Math.Point2D PaperImageOrigin
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

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_13.ClassNumber;
    }

    public override string ObjectType
    {
      get
      {
        return "PLOTSETTINGS";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbPlotSettings";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfPlotSettings dxfPlotSettings = (DxfPlotSettings) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfPlotSettings == null)
      {
        dxfPlotSettings = new DxfPlotSettings();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfPlotSettings);
        dxfPlotSettings.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfPlotSettings;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfPlotSettings dxfPlotSettings = (DxfPlotSettings) from;
      this.string_0 = dxfPlotSettings.string_0;
      this.string_1 = dxfPlotSettings.string_1;
      this.string_2 = dxfPlotSettings.string_2;
      this.string_3 = dxfPlotSettings.string_3;
      this.double_0 = dxfPlotSettings.double_0;
      this.double_1 = dxfPlotSettings.double_1;
      this.double_2 = dxfPlotSettings.double_2;
      this.double_3 = dxfPlotSettings.double_3;
      this.size2D_0 = dxfPlotSettings.size2D_0;
      this.point2D_0 = dxfPlotSettings.point2D_0;
      this.rectangle2D_0 = dxfPlotSettings.rectangle2D_0;
      this.double_4 = dxfPlotSettings.double_4;
      this.double_5 = dxfPlotSettings.double_5;
      this.plotLayoutFlags_0 = dxfPlotSettings.plotLayoutFlags_0;
      this.plotPaperUnits_0 = dxfPlotSettings.plotPaperUnits_0;
      this.plotRotation_0 = dxfPlotSettings.plotRotation_0;
      this.plotArea_0 = dxfPlotSettings.plotArea_0;
      this.string_4 = dxfPlotSettings.string_4;
      this.short_0 = dxfPlotSettings.short_0;
      this.shadePlotMode_0 = dxfPlotSettings.shadePlotMode_0;
      this.shadePlotResolution_0 = dxfPlotSettings.shadePlotResolution_0;
      this.short_1 = dxfPlotSettings.short_1;
      this.double_6 = dxfPlotSettings.double_6;
      this.point2D_1 = dxfPlotSettings.point2D_1;
    }

    public override string ToString()
    {
      return this.PageSetupName;
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf15OrHigher;
    }

    internal static DxfClass smethod_2(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "PLOTSETTINGS");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1015;
        dxfClass.MaintenanceVersion = (short) 42;
        dxfClass.ProxyFlags = ProxyFlags.None;
        dxfClass.CPlusPlusClassName = "AcDbPlotSettings";
        dxfClass.DxfName = "PLOTSETTINGS";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }
  }
}
