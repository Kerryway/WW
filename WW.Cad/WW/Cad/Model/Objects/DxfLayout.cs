// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfLayout
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns2;
using ns28;
using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Collections.Generic;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Objects
{
  public class DxfLayout : DxfPlotSettings, INamedObject
  {
    private bool bool_0 = true;
    private string string_8 = string.Empty;
    private DxfObjectReference dxfObjectReference_3 = new DxfUcs().Reference;
    private DxfObjectReference dxfObjectReference_4 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_5 = DxfObjectReference.Null;
    private readonly DxfViewportCollection dxfViewportCollection_0 = new DxfViewportCollection();
    internal const string string_5 = "Model";
    internal const string string_6 = "Layout1";
    internal const string string_7 = "Layout2";
    private DxfEntityCollection dxfEntityCollection_0;
    private LayoutOptions layoutOptions_0;
    private int int_0;
    private Rectangle2D rectangle2D_1;
    private WW.Math.Point3D point3D_0;
    private WW.Math.Point3D point3D_1;
    private WW.Math.Point3D point3D_2;
    private double double_7;
    private OrthographicType orthographicType_0;

    public DxfLayout()
    {
      this.dxfViewportCollection_0.Added += new ItemEventHandler<DxfViewport>(this.method_17);
      this.dxfViewportCollection_0.Set += new ItemSetEventHandler<DxfViewport>(this.method_18);
      this.dxfViewportCollection_0.Removed += new ItemEventHandler<DxfViewport>(this.method_19);
    }

    public DxfLayout(string name)
      : this()
    {
      this.string_8 = name;
    }

    internal DxfLayout(DxfBlock ownerBlockRecord)
      : this()
    {
      this.OwnerBlock = ownerBlockRecord;
    }

    public bool PaperSpace
    {
      get
      {
        return this.bool_0;
      }
    }

    public DxfEntityCollection Entities
    {
      get
      {
        return this.dxfEntityCollection_0;
      }
    }

    public string Name
    {
      get
      {
        return this.string_8;
      }
      set
      {
        this.string_8 = value;
      }
    }

    public LayoutOptions Options
    {
      get
      {
        return this.layoutOptions_0;
      }
      set
      {
        this.layoutOptions_0 = value;
      }
    }

    public int TabOrder
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

    public Rectangle2D Limits
    {
      get
      {
        return this.rectangle2D_1;
      }
      set
      {
        this.rectangle2D_1 = value;
      }
    }

    public WW.Math.Point3D InsertionBasePoint
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

    public WW.Math.Point3D MinExtents
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

    public WW.Math.Point3D MaxExtents
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

    public Polyline3D FramePolygon
    {
      get
      {
        Polyline3D polyline3D = new Polyline3D(4);
        Bounds2D layoutViewport = this.method_8().LayoutViewport;
        if (layoutViewport.Initialized)
        {
          polyline3D.Add(new WW.Math.Point3D(layoutViewport.Min, this.double_7));
          polyline3D.Add(new WW.Math.Point3D(layoutViewport.Max.X, layoutViewport.Min.Y, this.double_7));
          polyline3D.Add(new WW.Math.Point3D(layoutViewport.Max, this.double_7));
          polyline3D.Add(new WW.Math.Point3D(layoutViewport.Min.X, layoutViewport.Max.Y, this.double_7));
          polyline3D.Closed = true;
        }
        return polyline3D;
      }
    }

    public double Elevation
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

    public DxfUcs Ucs
    {
      get
      {
        return (DxfUcs) this.dxfObjectReference_3.Value;
      }
      set
      {
        this.dxfObjectReference_3 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public OrthographicType UcsOrthographicType
    {
      get
      {
        return this.orthographicType_0;
      }
      set
      {
        this.orthographicType_0 = value;
      }
    }

    public DxfHandledObject LastActiveViewport
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_4.Value;
      }
      set
      {
        if (value != null && !(value is DxfVPort) && !(value is DxfViewport))
          throw new ArgumentException("Value must be either a DxfVPort or a DxfViewport object.");
        this.dxfObjectReference_4 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfViewportCollection Viewports
    {
      get
      {
        return this.dxfViewportCollection_0;
      }
    }

    public DxfBlock OwnerBlock
    {
      get
      {
        return (DxfBlock) this.dxfObjectReference_5.Value;
      }
      internal set
      {
        DxfBlock ownerBlock = this.OwnerBlock;
        this.dxfObjectReference_5 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        if (value == null || value == ownerBlock)
          return;
        this.bool_0 = string.Compare("*Model_Space", this.OwnerBlock.Name, StringComparison.InvariantCultureIgnoreCase) != 0;
        DxfEntityCollection entityCollection0 = this.dxfEntityCollection_0;
        this.method_9(value.Entities, true);
        if (entityCollection0 != null && entityCollection0 != this.dxfEntityCollection_0)
          value.Entities.AddRange((IEnumerable<DxfEntity>) entityCollection0);
        value.Layout = this;
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.short_7;
    }

    public override string ObjectType
    {
      get
      {
        return "LAYOUT";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbLayout";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override void vmethod_3(DxfModel modelContext)
    {
      base.vmethod_3(modelContext);
      if (this.OwnerBlock == null)
        this.OwnerBlock = DxfBlock.smethod_3(modelContext);
      DxfDictionary dictionaryAcadLayout = modelContext.DictionaryAcadLayout;
      if (dictionaryAcadLayout == null)
        return;
      bool flag = false;
      foreach (IDictionaryEntry entry in (ActiveList<IDictionaryEntry>) dictionaryAcadLayout.Entries)
      {
        if (object.ReferenceEquals((object) this, (object) entry.Value))
        {
          flag = true;
          break;
        }
      }
      if (!flag)
        dictionaryAcadLayout.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry((DxfObject) this));
      if (this.OwnerObjectSoftReference == dictionaryAcadLayout)
        return;
      this.vmethod_2((IDxfHandledObject) dictionaryAcadLayout);
    }

    internal override void vmethod_4(DxfModel modelContext)
    {
      base.vmethod_4(modelContext);
      DxfDictionary dictionaryAcadLayout = modelContext.DictionaryAcadLayout;
      if (dictionaryAcadLayout != null)
      {
        dictionaryAcadLayout.Entries.RemoveAll(this.Name);
        this.vmethod_2((IDxfHandledObject) null);
      }
      if (this.OwnerBlock != null)
      {
        this.OwnerBlock.Layout = (DxfLayout) null;
        modelContext.AnonymousBlocks.Remove(this.OwnerBlock);
      }
      if (modelContext.ActiveLayout != this)
        return;
      modelContext.ActiveLayout = (DxfLayout) null;
    }

    public override void Dispose()
    {
      base.Dispose();
      if (this.dxfEntityCollection_0 == null)
        return;
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfEntity>) this.dxfEntityCollection_0)
        dxfHandledObject.Dispose();
      this.method_9((DxfEntityCollection) null, false);
    }

    internal override void Repair(DxfModelRepairer repairer)
    {
      base.Repair(repairer);
      if (this.OwnerBlock != null)
        return;
      DxfMessage dxfMessage = new DxfMessage(DxfStatus.RemovedInvalidLayout, Severity.Error, "Layout", (object) this);
      if (repairer.LayoutsToBeRemoved.Contains(this))
        return;
      repairer.LayoutsToBeRemoved.Add(this);
    }

    internal static DxfLayout smethod_3(
      DxfModel model,
      DxfBlock paperSpaceBlockRecord,
      bool useFixedHandles)
    {
      if (paperSpaceBlockRecord.Layout != null)
        return paperSpaceBlockRecord.Layout;
      DxfLayout dxfLayout = new DxfLayout(paperSpaceBlockRecord);
      if (useFixedHandles)
        dxfLayout.SetHandle(30UL);
      dxfLayout.Name = "Layout1";
      dxfLayout.StandardScaleType = (short) 16;
      dxfLayout.Options = LayoutOptions.PaperSpaceLinetypeScaling;
      dxfLayout.TabOrder = 1;
      dxfLayout.Limits = new Rectangle2D(0.0, 0.0, 420.0, 297.0);
      paperSpaceBlockRecord.Layout = dxfLayout;
      model.Layouts.Add(dxfLayout);
      return dxfLayout;
    }

    internal static DxfLayout smethod_4(
      DxfModel model,
      DxfBlock paperSpaceBlockRecord,
      bool useFixedHandles)
    {
      if (paperSpaceBlockRecord.Layout != null)
        return paperSpaceBlockRecord.Layout;
      DxfLayout dxfLayout = new DxfLayout(paperSpaceBlockRecord);
      if (useFixedHandles)
        dxfLayout.SetHandle(38UL);
      dxfLayout.Name = "Layout2";
      dxfLayout.StandardScaleType = (short) 16;
      dxfLayout.Options = LayoutOptions.PaperSpaceLinetypeScaling;
      dxfLayout.TabOrder = 2;
      dxfLayout.Limits = new Rectangle2D(0.0, 0.0, 12.0, 9.0);
      paperSpaceBlockRecord.Layout = dxfLayout;
      model.Layouts.Add(dxfLayout);
      return dxfLayout;
    }

    internal static DxfLayout smethod_5(
      DxfModel model,
      DxfBlock modelSpaceBlockRecord,
      bool useFixedHandles)
    {
      DxfLayout layout;
      if (modelSpaceBlockRecord.Layout == null)
      {
        layout = new DxfLayout(modelSpaceBlockRecord);
        if (useFixedHandles)
          layout.SetHandle(34UL);
        layout.Name = "Model";
        layout.PlotLayoutFlags = PlotLayoutFlags.UseStandardScale | PlotLayoutFlags.PlotPlotStyles | PlotLayoutFlags.PrintLineweights | PlotLayoutFlags.DrawViewportsFirst | PlotLayoutFlags.ModelType;
        layout.PlotArea = PlotArea.LastScreenDisplay;
        layout.StandardScaleType = (short) 0;
        layout.Options = LayoutOptions.PaperSpaceLinetypeScaling;
        layout.TabOrder = 0;
        layout.Limits = new Rectangle2D(0.0, 0.0, 12.0, 9.0);
        layout.LastActiveViewport = (DxfHandledObject) model.VPorts.GetActiveVPort();
        modelSpaceBlockRecord.Layout = layout;
        model.Layouts.Add(layout);
      }
      else
        layout = modelSpaceBlockRecord.Layout;
      DxfLayout.smethod_6(model, layout);
      return layout;
    }

    internal static void smethod_6(DxfModel model, DxfLayout layout)
    {
      layout.bool_0 = false;
      layout.method_9(model.Entities, false);
      if (layout.OwnerBlock == null)
        return;
      layout.OwnerBlock.method_10(model.Entities);
    }

    public void SetupDefaultIfNoViewportsPresent()
    {
      this.method_14();
    }

    public void SetupPaperSettingsIfNoPaperSize()
    {
      if (!this.PaperSpace || !(this.PlotPaperSize == Size2D.Zero))
        return;
      this.method_12();
    }

    public void CreateInitialModelViewport()
    {
      BoundsCalculator boundsCalculator = new BoundsCalculator();
      boundsCalculator.GetBounds(this.Model);
      Bounds3D bounds = boundsCalculator.Bounds;
      if (!bounds.Initialized)
        return;
      DxfViewport dxfViewport = new DxfViewport();
      this.dxfViewportCollection_0.Add(dxfViewport);
      Vector2D vector2D = this.Model.Header.PaperSpaceLimitsMax - this.Model.Header.PaperSpaceLimitsMin;
      if (this.PlotRotation != PlotRotation.None && this.PlotRotation != PlotRotation.Half)
      {
        vector2D.X -= this.UnprintableMarginTop;
        vector2D.X -= this.UnprintableMarginBottom;
        vector2D.Y -= this.UnprintableMarginRight;
        vector2D.Y -= this.UnprintableMarginLeft;
      }
      else
      {
        vector2D.X -= this.UnprintableMarginRight;
        vector2D.X -= this.UnprintableMarginLeft;
        vector2D.Y -= this.UnprintableMarginTop;
        vector2D.Y -= this.UnprintableMarginBottom;
      }
      dxfViewport.Size = new Size2D(vector2D.X, vector2D.Y);
      WW.Math.Point2D point = this.Model.Header.PaperSpaceLimitsMin + vector2D / 2.0;
      switch (this.PlotRotation)
      {
        case PlotRotation.None:
          point.X += this.UnprintableMarginLeft;
          point.Y += this.UnprintableMarginBottom;
          break;
        case PlotRotation.QuarterCounterClockwise:
          point.X += this.UnprintableMarginTop;
          point.Y += this.UnprintableMarginRight;
          break;
        case PlotRotation.Half:
          point.X += this.UnprintableMarginRight;
          point.Y += this.UnprintableMarginTop;
          break;
        case PlotRotation.QuarterClockwise:
          point.X += this.UnprintableMarginBottom;
          point.Y += this.UnprintableMarginRight;
          break;
      }
      dxfViewport.Center = new WW.Math.Point3D(point, 0.0);
      WW.Math.Point3D center = bounds.Center;
      WW.Math.Vector3D vector3D = bounds.Delta * 1.02;
      dxfViewport.Direction = WW.Math.Vector3D.ZAxis;
      dxfViewport.ViewCenter = (WW.Math.Point2D) bounds.Center;
      double num = vector3D.Y;
      double x = vector3D.X;
      if (num > 1E-10)
      {
        if (vector2D.X / vector2D.Y < x / num)
          num *= x / (vector2D.X / vector2D.Y * num);
      }
      else
        num = vector2D.Y / vector2D.X * x;
      dxfViewport.ViewHeight = num;
    }

    public void Draw(DrawContext.Wireframe context, IWireframeGraphicsFactory graphicsFactory)
    {
      foreach (DxfEntity dxfEntity in this.GetEntitiesInDrawingOrder(context.Config))
        dxfEntity.Draw(context, graphicsFactory);
      this.DrawFrame(context, graphicsFactory);
    }

    public void DrawFrame(DrawContext.Wireframe context, IWireframeGraphicsFactory graphicsFactory)
    {
      foreach (DxfEntity dxfEntity in (DxfHandledObjectCollection<DxfViewport>) this.dxfViewportCollection_0)
        dxfEntity.Draw(context, graphicsFactory);
    }

    public void Draw(DrawContext.Wireframe context, IWireframeGraphicsFactory2 graphicsFactory)
    {
      foreach (DxfEntity dxfEntity in this.GetEntitiesInDrawingOrder(context.Config))
        dxfEntity.Draw(context, graphicsFactory);
      this.DrawFrame(context, graphicsFactory);
    }

    public void DrawFrame(DrawContext.Wireframe context, IWireframeGraphicsFactory2 graphicsFactory)
    {
      foreach (DxfEntity dxfEntity in (DxfHandledObjectCollection<DxfViewport>) this.dxfViewportCollection_0)
        dxfEntity.Draw(context, graphicsFactory);
    }

    public void Draw(DrawContext.Surface context, ISurfaceGraphicsFactory graphicsFactory)
    {
      foreach (DxfEntity dxfEntity in this.GetEntitiesInDrawingOrder(context.Config))
        dxfEntity.Draw(context, graphicsFactory);
    }

    public void DrawFrame(DrawContext.Surface context, ISurfaceGraphicsFactory graphicsFactory)
    {
      foreach (DxfEntity dxfEntity in (DxfHandledObjectCollection<DxfViewport>) this.dxfViewportCollection_0)
        dxfEntity.Draw(context, graphicsFactory);
    }

    public double GetLineWeightUnitsToPaperUnits()
    {
      double num1 = 1.0;
      double num2;
      switch (this.PlotPaperUnits)
      {
        case PlotPaperUnits.Inches:
          num2 = num1 * 0.000393700787401575;
          break;
        case PlotPaperUnits.Millimeters:
          num2 = num1 * 0.01;
          break;
        case PlotPaperUnits.Pixels:
          num2 = num1 * ((double) this.ShadePlotCustomDpi / 2540.0);
          break;
        default:
          throw new Exception("Unsupported PlotPaperUnits " + this.PlotPaperUnits.ToString());
      }
      double num3 = (this.PlotLayoutFlags & PlotLayoutFlags.ScaleLineweights) == PlotLayoutFlags.None ? this.CustomPrintScaleDenominator / this.CustomPrintScaleNumerator : 1.0;
      return num2 * num3;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfLayout dxfLayout = (DxfLayout) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfLayout == null)
      {
        dxfLayout = new DxfLayout();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfLayout);
        dxfLayout.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfLayout;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfLayout dxfLayout = (DxfLayout) from;
      this.bool_0 = dxfLayout.bool_0;
      this.string_8 = dxfLayout.string_8;
      this.layoutOptions_0 = dxfLayout.layoutOptions_0;
      this.int_0 = dxfLayout.int_0;
      this.rectangle2D_1 = dxfLayout.rectangle2D_1;
      this.point3D_0 = dxfLayout.point3D_0;
      this.point3D_1 = dxfLayout.point3D_1;
      this.point3D_2 = dxfLayout.point3D_2;
      this.double_7 = dxfLayout.double_7;
      this.Ucs = Class906.smethod_2(cloneContext, dxfLayout.Ucs);
      this.orthographicType_0 = dxfLayout.orthographicType_0;
      DxfBlock ownerBlock = dxfLayout.OwnerBlock;
      if (ownerBlock != null && ownerBlock.BlockBegin != null)
        this.OwnerBlock = Class906.smethod_0(cloneContext, ownerBlock, true);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfViewport>) dxfLayout.dxfViewportCollection_0)
        this.dxfViewportCollection_0.Add((DxfViewport) dxfHandledObject.Clone(cloneContext));
      this.LastActiveViewport = (DxfHandledObject) cloneContext.GetExistingClone((IGraphCloneable) dxfLayout.LastActiveViewport);
      switch (dxfLayout.Handle)
      {
        case 30:
        case 34:
          this.SetHandle(dxfLayout.Handle);
          break;
      }
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      bool flag = true;
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfViewport>) this.dxfViewportCollection_0)
      {
        if (!dxfHandledObject.Validate(model, messages))
          flag = false;
      }
      return flag;
    }

    public IList<DxfEntity> GetSortedEntities()
    {
      return this.OwnerBlock.GetEntitiesInDrawingOrder(true);
    }

    public IEnumerable<DxfEntity> GetUnsortedEntities()
    {
      return (IEnumerable<DxfEntity>) this.OwnerBlock.Entities;
    }

    protected internal override void ExecuteDeepHelper(
      WW.Cad.Model.Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      if (this.dxfEntityCollection_0 != null)
      {
        foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfEntity>) this.dxfEntityCollection_0)
          dxfHandledObject.vmethod_0(action, callerStack);
      }
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfViewport>) this.dxfViewportCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
    }

    public Bounds2D GetPlotAreaBounds()
    {
      Bounds2D bounds2D = new Bounds2D();
      switch (this.PlotArea)
      {
        case PlotArea.LastScreenDisplay:
          if (this.LastActiveViewport is DxfVPort)
            bounds2D = DxfLayout.smethod_7(((DxfVPort) this.LastActiveViewport).ViewDescription);
          if (this.LastActiveViewport is DxfViewport)
          {
            bounds2D = DxfLayout.smethod_7(((DxfViewport) this.LastActiveViewport).ViewDescription);
            break;
          }
          break;
        case PlotArea.DrawingExtents:
          bounds2D.Update(this.MinExtents.X, this.MinExtents.Y);
          bounds2D.Update(this.MaxExtents.X, this.MaxExtents.Y);
          break;
        case PlotArea.DrawingLimits:
          bounds2D.Update(this.Limits.Corner1);
          bounds2D.Update(this.Limits.Corner2);
          break;
        case PlotArea.SpecifiedByViewName:
          bounds2D = DxfLayout.smethod_7(this.Model.Views[this.PlotViewName].ViewDescription);
          break;
        case PlotArea.SpecifiedByPlotWindowArea:
          bounds2D.Update(this.PlotWindowArea.Corner1);
          bounds2D.Update(this.PlotWindowArea.Corner2);
          break;
        case PlotArea.LayoutInformation:
          if (this.PlotPaperSize == Size2D.Zero)
            return bounds2D;
          switch (this.PlotRotation)
          {
            case PlotRotation.None:
              Vector2D vector2D1 = -new Vector2D(this.UnprintableMarginLeft, this.UnprintableMarginBottom) - (Vector2D) this.PaperImageOrigin;
              bounds2D.Update(new WW.Math.Point2D(0.0, 0.0) + vector2D1);
              bounds2D.Update(new WW.Math.Point2D(this.PlotPaperSize.X, this.PlotPaperSize.Y) + vector2D1);
              break;
            case PlotRotation.QuarterCounterClockwise:
              Vector2D vector2D2 = -new Vector2D(this.UnprintableMarginTop, this.UnprintableMarginLeft) - (Vector2D) this.PaperImageOrigin;
              bounds2D.Update(new WW.Math.Point2D(0.0, 0.0) + vector2D2);
              bounds2D.Update(new WW.Math.Point2D(this.PlotPaperSize.Y, this.PlotPaperSize.X) + vector2D2);
              break;
            case PlotRotation.Half:
              Vector2D vector2D3 = -new Vector2D(this.UnprintableMarginRight, this.UnprintableMarginTop) - (Vector2D) this.PaperImageOrigin;
              bounds2D.Update(new WW.Math.Point2D(0.0, 0.0) + vector2D3);
              bounds2D.Update(new WW.Math.Point2D(this.PlotPaperSize.X, this.PlotPaperSize.Y) + vector2D3);
              break;
            case PlotRotation.QuarterClockwise:
              Vector2D vector2D4 = -new Vector2D(this.UnprintableMarginBottom, this.UnprintableMarginRight) - (Vector2D) this.PaperImageOrigin;
              bounds2D.Update(new WW.Math.Point2D(0.0, 0.0) + vector2D4);
              bounds2D.Update(new WW.Math.Point2D(this.PlotPaperSize.Y, this.PlotPaperSize.X) + vector2D4);
              break;
          }
          if (this.PlotPaperUnits == PlotPaperUnits.Inches)
          {
            double num = 5.0 / (double) sbyte.MaxValue;
            bounds2D = new Bounds2D((WW.Math.Point2D) (num * (Vector2D) bounds2D.Min), (WW.Math.Point2D) (num * (Vector2D) bounds2D.Max));
            break;
          }
          break;
      }
      return bounds2D;
    }

    private DxfLayout.BasicLayoutRenderInfo method_8()
    {
      Bounds2D bounds2D = new Bounds2D();
      switch (this.PlotArea)
      {
        case PlotArea.LastScreenDisplay:
          if (this.LastActiveViewport is DxfVPort)
            return new DxfLayout.BasicLayoutRenderInfo(((DxfVPort) this.LastActiveViewport).ViewDescription);
          if (this.LastActiveViewport is DxfViewport)
            return new DxfLayout.BasicLayoutRenderInfo(((DxfViewport) this.LastActiveViewport).ViewDescription);
          return new DxfLayout.BasicLayoutRenderInfo();
        case PlotArea.SpecifiedByViewName:
          return new DxfLayout.BasicLayoutRenderInfo(this.Model.Views[this.PlotViewName].ViewDescription);
        default:
          return new DxfLayout.BasicLayoutRenderInfo(this.GetPlotAreaBounds());
      }
    }

    private static Bounds2D smethod_7(IViewDescription view)
    {
      Vector2D vector2D = 0.5 * new Vector2D(view.ViewportWidth, view.ViewportHeight);
      WW.Math.Point2D viewportCenter = (WW.Math.Point2D) view.ViewportCenter;
      return new Bounds2D(viewportCenter - vector2D, viewportCenter + vector2D);
    }

    public DxfLayout.PlotInfo GetPlotInfo(bool invertY)
    {
      DxfLayout.BasicLayoutRenderInfo layoutRenderInfo = this.method_8();
      if (!layoutRenderInfo.LayoutViewport.Initialized)
        return (DxfLayout.PlotInfo) null;
      return this.GetPlotInfo(invertY, layoutRenderInfo);
    }

    private DxfLayout.PlotInfo GetPlotInfo(
      bool invertY,
      DxfLayout.BasicLayoutRenderInfo layoutRenderInfo)
    {
      Size2D plotPaperSize = this.PlotPaperSize;
      if (plotPaperSize.X == 0.0 || plotPaperSize.Y == 0.0)
        return (DxfLayout.PlotInfo) null;
      double y = invertY ? this.UnprintableMarginBottom : plotPaperSize.Y - this.UnprintableMarginTop;
      WW.Math.Point3D toPoint1 = new WW.Math.Point3D(this.UnprintableMarginLeft, invertY ? plotPaperSize.Y - this.UnprintableMarginTop : this.UnprintableMarginBottom, 0.0);
      WW.Math.Point3D toPoint2 = new WW.Math.Point3D(plotPaperSize.X - this.UnprintableMarginRight, y, 0.0);
      WW.Math.Point3D toReferencePoint = new WW.Math.Point3D(0.5 * (toPoint1.X + toPoint2.X), 0.5 * (toPoint1.Y + toPoint2.Y), 0.0);
      Matrix4D matrix4D1 = Matrix4D.Identity;
      switch (this.PlotRotation)
      {
        case PlotRotation.QuarterCounterClockwise:
          matrix4D1 = Transformation4D.RotateZ(System.Math.PI / 2.0);
          break;
        case PlotRotation.Half:
          matrix4D1 = Transformation4D.RotateZ(System.Math.PI);
          break;
        case PlotRotation.QuarterClockwise:
          matrix4D1 = Transformation4D.RotateZ(-1.0 * System.Math.PI / 2.0);
          break;
      }
      if (invertY)
        matrix4D1 *= Transformation4D.Scaling(1.0, -1.0, 1.0);
      WW.Math.Point3D point3D1 = new WW.Math.Point3D(layoutRenderInfo.LayoutViewport.Min, 0.0);
      WW.Math.Point3D point3D2 = new WW.Math.Point3D(layoutRenderInfo.LayoutViewport.Max, 0.0);
      WW.Math.Point3D fromReferencePoint = new WW.Math.Point3D(layoutRenderInfo.LayoutViewport.Center, 0.0);
      Matrix4D matrix4D2 = Transformation4D.Translation((WW.Math.Vector3D) fromReferencePoint) * matrix4D1 * Transformation4D.Translation(-(WW.Math.Vector3D) fromReferencePoint);
      WW.Math.Point3D point3D3 = matrix4D2 * point3D1;
      point3D2 = matrix4D2 * point3D2;
      double scaling;
      Matrix4D toPaperTransform = DxfUtil.GetScaleTransform(new WW.Math.Point3D(System.Math.Min(point3D3.X, point3D2.X), System.Math.Min(point3D3.Y, point3D2.Y), 0.0), new WW.Math.Point3D(System.Math.Max(point3D3.X, point3D2.X), System.Math.Max(point3D3.Y, point3D2.Y), 0.0), fromReferencePoint, toPoint1, toPoint2, toReferencePoint, out scaling) * matrix4D2;
      return new DxfLayout.PlotInfo(this, plotPaperSize, new Rectangle2D(toPoint1.X, System.Math.Min(toPoint1.Y, toPoint2.Y), toPoint2.X, System.Math.Max(toPoint1.Y, toPoint2.Y)), toPaperTransform, scaling);
    }

    public DxfLayout.PlotInfo GetPlotInfo(
      double paperWidth,
      double paperHeight,
      Rectangle2D printArea,
      bool autoRotate,
      bool invertY)
    {
      DxfLayout.BasicLayoutRenderInfo layoutRenderInfo = this.method_8();
      if (!layoutRenderInfo.LayoutViewport.Initialized)
        return (DxfLayout.PlotInfo) null;
      Bounds2D layoutViewport = layoutRenderInfo.LayoutViewport;
      Matrix4D matrix4D1 = Matrix4D.Identity;
      double num1 = layoutViewport.Delta.X;
      double num2 = layoutViewport.Delta.Y;
      if (autoRotate && (printArea.Width > printArea.Height && num1 < num2 || printArea.Width < printArea.Height && num1 > num2))
      {
        PlotRotation plotRotation1 = PlotRotation.None;
        PlotRotation plotRotation2;
        PlotRotation plotRotation3;
        switch (this.PlotRotation)
        {
          case PlotRotation.None:
            plotRotation2 = PlotRotation.QuarterCounterClockwise;
            plotRotation3 = PlotRotation.QuarterCounterClockwise;
            goto label_10;
          case PlotRotation.QuarterCounterClockwise:
            plotRotation2 = PlotRotation.QuarterClockwise;
            plotRotation3 = PlotRotation.QuarterClockwise;
            break;
          case PlotRotation.Half:
            plotRotation2 = PlotRotation.QuarterClockwise;
            plotRotation3 = PlotRotation.QuarterClockwise;
            break;
          case PlotRotation.QuarterClockwise:
            plotRotation2 = PlotRotation.QuarterCounterClockwise;
            plotRotation3 = PlotRotation.QuarterCounterClockwise;
            goto label_10;
          default:
            switch (plotRotation1)
            {
              case PlotRotation.QuarterCounterClockwise:
                goto label_10;
              case PlotRotation.QuarterClockwise:
                break;
              default:
                goto label_11;
            }
        }
        matrix4D1 = Transformation4D.RotateZ(invertY ? System.Math.PI / 2.0 : -1.0 * System.Math.PI / 2.0);
        goto label_11;
label_10:
        matrix4D1 = Transformation4D.RotateZ(invertY ? -1.0 * System.Math.PI / 2.0 : System.Math.PI / 2.0);
label_11:
        num1 = layoutViewport.Delta.Y;
        num2 = layoutViewport.Delta.X;
      }
      double s = System.Math.Min(printArea.Width / num1, printArea.Height / num2);
      if (!DxfUtil.IsSaneNotZero(s))
        return (DxfLayout.PlotInfo) null;
      Matrix4D matrix4D2 = Transformation4D.Translation(printArea.Center.X, printArea.Center.Y, 0.0) * Transformation4D.Scaling(s) * matrix4D1 * Transformation4D.Translation(-layoutViewport.Center.X, -layoutViewport.Center.Y, 0.0);
      WW.Math.Point3D point3D1 = matrix4D2.Transform(new WW.Math.Point3D(layoutViewport.Corner1, 0.0));
      WW.Math.Point3D point3D2 = matrix4D2.Transform(new WW.Math.Point3D(layoutViewport.Corner2, 0.0));
      return new DxfLayout.PlotInfo(this, new Size2D(paperWidth, paperHeight), new Rectangle2D(System.Math.Min(point3D1.X, point3D2.X), System.Math.Min(point3D1.Y, point3D2.Y), System.Math.Max(point3D1.X, point3D2.X), System.Math.Max(point3D1.Y, point3D2.Y)), matrix4D2 * layoutRenderInfo.ModelToLayoutTransform, s * layoutRenderInfo.ModelToLayoutScaling);
    }

    public override string ToString()
    {
      return this.string_8;
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf15OrHigher;
    }

    internal void method_9(DxfEntityCollection value, bool updateEntitiesPaperSpaceProperty)
    {
      if (value == this.dxfEntityCollection_0)
        return;
      if (this.dxfEntityCollection_0 != null)
      {
        this.dxfEntityCollection_0.Added -= new ItemEventHandler<DxfEntity>(this.method_21);
        this.dxfEntityCollection_0.Set -= new ItemSetEventHandler<DxfEntity>(this.method_20);
      }
      this.dxfEntityCollection_0 = value;
      if (this.dxfEntityCollection_0 == null)
        return;
      this.dxfEntityCollection_0.Added += new ItemEventHandler<DxfEntity>(this.method_21);
      this.dxfEntityCollection_0.Set += new ItemSetEventHandler<DxfEntity>(this.method_20);
      if (!updateEntitiesPaperSpaceProperty)
        return;
      foreach (DxfEntity dxfEntity in (DxfHandledObjectCollection<DxfEntity>) this.dxfEntityCollection_0)
        dxfEntity.method_10(this.bool_0);
    }

    internal void method_10(DxfEntity entity)
    {
      entity.vmethod_2((IDxfHandledObject) this.OwnerBlock);
    }

    internal void method_11()
    {
      if (this.dxfEntityCollection_0 != null)
      {
        foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) this.dxfEntityCollection_0)
          this.method_10(entity);
      }
      foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfViewport>) this.dxfViewportCollection_0)
        this.method_10(entity);
    }

    private void method_12()
    {
      if (this.Model.Header.MeasurementUnits == MeasurementUnits.English)
      {
        this.PlotRotation = PlotRotation.QuarterCounterClockwise;
        this.PlotPaperSize = new Size2D(215.9, 279.4);
        this.PlotPaperUnits = PlotPaperUnits.Millimeters;
        this.UnprintableMarginTop = 6.35001;
        this.UnprintableMarginRight = 6.35001;
        this.UnprintableMarginBottom = 6.35;
        this.UnprintableMarginLeft = 6.35;
        this.PaperSizeName = "Letter_(8.50_x_11.00_Inches)";
        this.Model.Header.PaperSpaceLimitsMin = new WW.Math.Point2D(-0.25, -0.25);
        this.Model.Header.PaperSpaceLimitsMax = new WW.Math.Point2D(10.75, 8.25);
      }
      else
      {
        this.PlotRotation = PlotRotation.QuarterCounterClockwise;
        this.PlotPaperSize = new Size2D(210.0, 297.0);
        this.PlotPaperUnits = PlotPaperUnits.Millimeters;
        this.UnprintableMarginTop = 20.0;
        this.UnprintableMarginRight = 7.5;
        this.UnprintableMarginBottom = 20.0;
        this.UnprintableMarginLeft = 7.5;
        this.PaperSizeName = "ISO_A4_(210.00_x_297.00_MM)";
        this.Model.Header.PaperSpaceLimitsMin = new WW.Math.Point2D(-20.0, -7.5);
        this.Model.Header.PaperSpaceLimitsMax = new WW.Math.Point2D(277.0, 202.5);
      }
    }

    private void method_13()
    {
      DxfViewport dxfViewport = new DxfViewport();
      this.dxfViewportCollection_0.Add(dxfViewport);
      Vector2D vector2D1 = this.Model.Header.PaperSpaceLimitsMax - this.Model.Header.PaperSpaceLimitsMin;
      if (System.Math.Abs(vector2D1.Y) < 1E-10 || System.Math.Abs(vector2D1.Y) < 1E-10)
        vector2D1 = new Vector2D(this.PlotPaperSize.X, this.PlotPaperSize.Y);
      WW.Math.Point2D point = this.Model.Header.PaperSpaceLimitsMin + vector2D1 / 2.0;
      dxfViewport.Center = new WW.Math.Point3D(point, 0.0);
      dxfViewport.ViewCenter = point;
      Vector2D vector2D2 = vector2D1 * 1.058;
      dxfViewport.ViewHeight = vector2D2.Y;
      dxfViewport.Size = new Size2D(vector2D2.X, vector2D2.Y);
    }

    internal void method_14()
    {
      if (this.dxfViewportCollection_0.Count != 0 || !this.PaperSpace)
        return;
      this.method_12();
      this.method_13();
      this.CreateInitialModelViewport();
    }

    internal void method_15()
    {
      if (this.Model.Header.AcadVersion > DxfVersion.Dxf15 || this.OwnerBlock != this.Model.PaperSpaceBlock)
        return;
      foreach (DxfViewport dxfViewport in (DxfHandledObjectCollection<DxfViewport>) this.dxfViewportCollection_0)
        dxfViewport.method_19();
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfViewport>) this.dxfViewportCollection_0)
        dxfHandledObject.vmethod_1(context);
    }

    private DxfViewport method_16()
    {
      foreach (DxfViewport dxfViewport in (DxfHandledObjectCollection<DxfViewport>) this.dxfViewportCollection_0)
      {
        if (dxfViewport.ModelSpaceVisible)
          return dxfViewport;
      }
      if (this.dxfViewportCollection_0.Count > 0)
        return this.dxfViewportCollection_0[0];
      return (DxfViewport) null;
    }

    private void method_17(object sender, int index, DxfViewport item)
    {
      DxfModel model = this.Model;
      if (model == null)
        return;
      item.vmethod_3(this.Model);
      item.vmethod_2((IDxfHandledObject) this.OwnerBlock);
      if (item.ViewportEntityHeader == null || model.ViewportEntityHeaders.Contains(item.ViewportEntityHeader))
        return;
      model.ViewportEntityHeaders.Add(item.ViewportEntityHeader);
    }

    private void method_18(object sender, int index, DxfViewport oldItem, DxfViewport newItem)
    {
      DxfModel model = this.Model;
      if (model == null)
        return;
      newItem.vmethod_3(this.Model);
      newItem.vmethod_2((IDxfHandledObject) this.OwnerBlock);
      if (newItem.ViewportEntityHeader != null && !model.ViewportEntityHeaders.Contains(newItem.ViewportEntityHeader))
        model.ViewportEntityHeaders.Add(newItem.ViewportEntityHeader);
      oldItem.vmethod_4(this.Model);
      oldItem.vmethod_2((IDxfHandledObject) null);
      if (oldItem.ViewportEntityHeader == null || !model.ViewportEntityHeaders.Contains(oldItem.ViewportEntityHeader))
        return;
      model.ViewportEntityHeaders.Remove(oldItem.ViewportEntityHeader);
    }

    private void method_19(object sender, int index, DxfViewport item)
    {
      DxfModel model = this.Model;
      if (model == null)
        return;
      item.vmethod_4(this.Model);
      item.vmethod_2((IDxfHandledObject) null);
      if (item.ViewportEntityHeader == null || !model.ViewportEntityHeaders.Contains(item.ViewportEntityHeader))
        return;
      model.ViewportEntityHeaders.Remove(item.ViewportEntityHeader);
    }

    private void method_20(object sender, int index, DxfEntity oldItem, DxfEntity newItem)
    {
      newItem.method_10(this.bool_0);
    }

    private void method_21(object sender, int index, DxfEntity item)
    {
      item.method_10(this.bool_0);
    }

    private IEnumerable<DxfEntity> GetEntitiesInDrawingOrder(
      GraphicsConfig config)
    {
      return (IEnumerable<DxfEntity>) this.OwnerBlock.GetEntitiesInDrawingOrder(config.UseSortEntsTables);
    }

    public class PlotInfo
    {
      public readonly DxfLayout Layout;
      public readonly Size2D PaperSize;
      public readonly Rectangle2D PrintableArea;
      public readonly Matrix4D ToPaperTransform;
      public readonly double Scaling;

      public PlotInfo(
        DxfLayout layout,
        Size2D paperSize,
        Rectangle2D printableArea,
        Matrix4D toPaperTransform,
        double scaling)
      {
        this.Layout = layout;
        this.PaperSize = paperSize;
        this.PrintableArea = printableArea;
        this.ToPaperTransform = toPaperTransform;
        this.Scaling = scaling;
      }
    }

    public class BasicLayoutRenderInfo
    {
      public readonly Bounds2D LayoutViewport;
      public readonly Matrix4D ModelToLayoutTransform;
      public readonly double ModelToLayoutScaling;

      public BasicLayoutRenderInfo(
        Bounds2D layoutViewport,
        Matrix4D modelToLayoutTransform,
        double modelToLayoutScaling)
      {
        this.LayoutViewport = layoutViewport;
        this.ModelToLayoutTransform = modelToLayoutTransform;
        this.ModelToLayoutScaling = modelToLayoutScaling;
      }

      public BasicLayoutRenderInfo(Bounds2D layoutViewport)
        : this(layoutViewport, Matrix4D.Identity, 1.0)
      {
      }

      public BasicLayoutRenderInfo(IViewDescription viewDescription)
      {
        double val1 = viewDescription.ViewportWidth / viewDescription.ViewWidth;
        double val2 = viewDescription.ViewportHeight / viewDescription.ViewHeight;
        if (DxfUtil.IsSaneNotZero(val1) && DxfUtil.IsSaneNotZero(val2))
        {
          this.ModelToLayoutScaling = System.Math.Min(val1, val2);
          Vector2D vector2D = val1 > val2 ? new Vector2D(0.5 * val2 / val1 * viewDescription.ViewportWidth, 0.5 * viewDescription.ViewportHeight) : new Vector2D(0.5 * viewDescription.ViewportWidth, 0.5 * val1 / val2 * viewDescription.ViewportHeight);
          WW.Math.Point2D viewportCenter = (WW.Math.Point2D) viewDescription.ViewportCenter;
          this.LayoutViewport = new Bounds2D(viewportCenter - vector2D, viewportCenter + vector2D);
          this.ModelToLayoutTransform = Transformation4D.Translation((WW.Math.Vector3D) viewDescription.ViewportCenter) * Transformation4D.Scaling(this.ModelToLayoutScaling) * ViewUtil.GetBasicModelToViewportTransform(viewDescription) * Transformation4D.Translation(-(WW.Math.Vector3D) viewDescription.ViewportCenter);
        }
        else
        {
          this.LayoutViewport = new Bounds2D();
          this.ModelToLayoutTransform = Matrix4D.Identity;
          this.ModelToLayoutScaling = 0.0;
        }
      }

      public BasicLayoutRenderInfo()
        : this(new Bounds2D(), Matrix4D.Identity, 0.0)
      {
      }
    }
  }
}
