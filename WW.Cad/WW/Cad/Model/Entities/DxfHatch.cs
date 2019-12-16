// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfHatch
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns33;
using ns36;
using ns49;
using System;
using System.Collections.Generic;
using System.Linq;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.IO;
using WW.Cad.Model.Objects.Annotations;
using WW.Drawing;
using WW.Math;
using WW.Math.Exact;
using WW.Math.Exact.Geometry;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfHatch : DxfEntity, IAnnotative
  {
    private Vector3D vector3D_0 = Vector3D.ZAxis;
    private string string_1 = "SOLID";
    private readonly List<DxfHatch.BoundaryPath> list_0 = new List<DxfHatch.BoundaryPath>();
    private double double_4 = 1.0;
    private readonly List<WW.Math.Point2D> list_1 = new List<WW.Math.Point2D>();
    private const string string_0 = "SOLID";
    private const double double_1 = 1E-08;
    private const double double_2 = 1E-08;
    private WW.Math.Point3D point3D_0;
    private ArgbColor argbColor_0;
    private bool bool_2;
    private HatchStyle hatchStyle_0;
    private HatchPatternType hatchPatternType_0;
    private double double_3;
    private bool bool_3;
    private DxfPattern dxfPattern_0;
    private DxfColorGradient dxfColorGradient_0;
    private double double_5;
    private bool bool_4;

    public bool Associative
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

    public List<DxfHatch.BoundaryPath> BoundaryPaths
    {
      get
      {
        return this.list_0;
      }
    }

    public WW.Math.Point3D ElevationPoint
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

    public ArgbColor FillColor
    {
      get
      {
        return this.argbColor_0;
      }
      set
      {
        this.argbColor_0 = value;
      }
    }

    public double HatchPatternAngle
    {
      get
      {
        return this.double_3;
      }
      set
      {
        if (this.dxfPattern_0 != null)
          this.dxfPattern_0.TransformMe(value - this.double_3, 1.0);
        this.double_3 = value;
      }
    }

    public WW.Math.Point2D PatternOffset
    {
      get
      {
        if (this.list_1.Count <= 0)
          return WW.Math.Point2D.Zero;
        return this.list_1[0];
      }
      set
      {
        Vector2D vector2D = value - this.PatternOffset;
        if (this.dxfPattern_0 != null)
          this.dxfPattern_0.TransformMe(0.0, 1.0, value - this.PatternOffset);
        if (this.list_1.Count == 0)
        {
          this.list_1.Add(value);
        }
        else
        {
          for (int index = 0; index < this.list_1.Count; ++index)
            this.list_1[index] += vector2D;
        }
      }
    }

    public HatchPatternType HatchPatternType
    {
      get
      {
        return this.hatchPatternType_0;
      }
      set
      {
        this.hatchPatternType_0 = value;
      }
    }

    public HatchStyle HatchStyle
    {
      get
      {
        return this.hatchStyle_0;
      }
      set
      {
        this.hatchStyle_0 = value;
      }
    }

    public bool IsDouble
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

    public string Name
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

    public DxfPattern Pattern
    {
      get
      {
        return this.dxfPattern_0;
      }
      set
      {
        if (value == null)
        {
          this.string_1 = "SOLID";
          this.dxfPattern_0 = (DxfPattern) null;
        }
        else
        {
          this.dxfPattern_0 = value.CreateTransformed(this.double_3, this.double_4, (Vector2D) this.PatternOffset);
          if (value.Name == null)
            return;
          this.string_1 = this.dxfPattern_0.Name;
        }
      }
    }

    public DxfColorGradient ColorGradient
    {
      get
      {
        return this.dxfColorGradient_0;
      }
      set
      {
        this.dxfColorGradient_0 = value;
      }
    }

    public double PixelSize
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

    public double Scale
    {
      get
      {
        return this.double_4;
      }
      set
      {
        if (this.dxfPattern_0 != null)
          this.dxfPattern_0.TransformMe(0.0, value / this.double_4);
        this.double_4 = value;
      }
    }

    public List<WW.Math.Point2D> SeedPoints
    {
      get
      {
        return this.list_1;
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
        this.vector3D_0 = value;
      }
    }

    public override Matrix4D Transform
    {
      get
      {
        return DxfUtil.GetToWCSTransform(this.vector3D_0) * Transformation4D.Translation(0.0, 0.0, this.point3D_0.Z);
      }
    }

    public override string EntityType
    {
      get
      {
        return "HATCH";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbHatch";
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      if (!context.Model.Header.FillMode)
        return;
      if (this.dxfPattern_0 == null)
      {
        this.method_14(context, graphicsFactory);
      }
      else
      {
        bool hatchRepeatCountTooLarge;
        this.method_15(context, graphicsFactory, out hatchRepeatCountTooLarge);
        if (context.Config.DrawHatchPatterns && !hatchRepeatCountTooLarge)
          return;
        switch (context.Config.HatchOverflowHandling)
        {
          case HatchOverflowHandling.SolidFill:
            this.method_14(context, graphicsFactory);
            break;
        }
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      if (!context.Model.Header.FillMode)
        return;
      if (this.dxfPattern_0 == null)
      {
        this.method_16(context, graphicsFactory);
      }
      else
      {
        bool hatchRepeatCountTooLarge;
        this.method_17(context, graphicsFactory, out hatchRepeatCountTooLarge);
        if (context.Config.DrawHatchPatterns && !hatchRepeatCountTooLarge)
          return;
        switch (context.Config.HatchOverflowHandling)
        {
          case HatchOverflowHandling.SolidFill:
            this.method_16(context, graphicsFactory);
            break;
        }
      }
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      if (!context.Model.Header.FillMode)
        return;
      graphicsFactory.SetColor(context.GetPlotColor((DxfEntity) this));
      if (this.dxfPattern_0 == null)
      {
        this.method_18(context, graphicsFactory);
      }
      else
      {
        bool hatchRepeatCountTooLarge;
        this.method_19(context, graphicsFactory, out hatchRepeatCountTooLarge);
        if (context.Config.DrawHatchPatterns && !hatchRepeatCountTooLarge)
          return;
        switch (context.Config.HatchOverflowHandling)
        {
          case HatchOverflowHandling.SolidFill:
            this.method_18(context, graphicsFactory);
            break;
        }
      }
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      if (!context.Model.Header.FillMode)
        return;
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      if (!graphics.AddExistingGraphicElement1(parentGraphicElementBlock, (DxfEntity) this, plotColor))
        return;
      GraphicElement1 graphicElement = new GraphicElement1(plotColor);
      graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, graphicElement);
      if (this.dxfPattern_0 == null)
      {
        this.method_20(context, graphicElement.Geometry);
      }
      else
      {
        bool hatchRepeatCountTooLarge;
        this.method_21(context, graphicElement.Geometry, out hatchRepeatCountTooLarge);
        if (context.Config.DrawHatchPatterns && !hatchRepeatCountTooLarge)
          return;
        switch (context.Config.HatchOverflowHandling)
        {
          case HatchOverflowHandling.SolidFill:
            this.method_20(context, graphicElement.Geometry);
            break;
        }
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
      DxfHatch.Class413 class413 = new DxfHatch.Class413();
      // ISSUE: reference to a compiler-generated field
      class413.dxfHatch_0 = this;
      Matrix4D transform1 = this.Transform;
      // ISSUE: reference to a compiler-generated field
      class413.point3D_0 = this.point3D_0;
      // ISSUE: reference to a compiler-generated field
      class413.vector3D_0 = this.vector3D_0;
      CommandGroup undoGroup1 = (CommandGroup) null;
      if (undoGroup != null)
      {
        undoGroup1 = new CommandGroup((object) this);
        undoGroup.UndoStack.Push((ICommand) undoGroup1);
      }
      this.vector3D_0 = matrix.Transform(this.vector3D_0);
      this.vector3D_0.Normalize();
      Matrix4D inverse1 = DxfUtil.GetToWCSTransform(this.vector3D_0).GetInverse();
      // ISSUE: reference to a compiler-generated field
      Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(class413.vector3D_0);
      this.point3D_0 = (inverse1 * matrix * toWcsTransform).Transform(this.point3D_0);
      this.point3D_0.X = 0.0;
      this.point3D_0.Y = 0.0;
      Matrix4D inverse2 = this.Transform.GetInverse();
      if (undoGroup != null)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup1.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfHatch.Class414()
        {
          class413_0 = class413,
          point3D_0 = this.point3D_0,
          vector3D_0 = this.vector3D_0
        }.method_0), new System.Action(class413.method_0)));
      }
      Matrix4D transform2 = inverse2 * matrix * transform1;
      foreach (DxfHatch.BoundaryPath boundaryPath in this.list_0)
        boundaryPath.TransformMe(transform2, undoGroup1);
      if (this.list_1.Count == 0)
        this.list_1.Add(WW.Math.Point2D.Zero);
      // ISSUE: reference to a compiler-generated field
      class413.point2D_0 = new WW.Math.Point2D[this.list_1.Count];
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      class413.point2D_1 = new WW.Math.Point2D[class413.point2D_0.Length];
      for (int index = 0; index < this.list_1.Count; ++index)
      {
        // ISSUE: reference to a compiler-generated field
        class413.point2D_0[index] = this.list_1[index];
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.list_1[index] = class413.point2D_1[index] = transform2.Transform(class413.point2D_0[index]);
      }
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup?.UndoStack.Push((ICommand) new Command((object) this, new System.Action(class413.method_1), new System.Action(class413.method_2)));
      if (config.HatchPatternHandling == TransformConfig.HatchPatternTransform.CompleteTransform)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfHatch.Class415 class415 = new DxfHatch.Class415();
        // ISSUE: reference to a compiler-generated field
        class415.class413_0 = class413;
        // ISSUE: reference to a compiler-generated field
        class415.double_0 = this.double_3;
        // ISSUE: reference to a compiler-generated field
        class415.double_1 = this.double_4;
        Vector2D vector = new Vector2D(System.Math.Cos(this.double_3), System.Math.Sin(this.double_3));
        vector = transform2.Transform(vector);
        // ISSUE: reference to a compiler-generated field
        class415.double_2 = this.double_4 * vector.GetLength();
        // ISSUE: reference to a compiler-generated field
        class415.double_3 = System.Math.Atan2(vector.Y, vector.X);
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup?.UndoStack.Push((ICommand) new Command((object) this, new System.Action(class415.method_0), new System.Action(class415.method_1)));
        // ISSUE: reference to a compiler-generated field
        this.double_3 = class415.double_3;
        // ISSUE: reference to a compiler-generated field
        this.double_4 = class415.double_2;
      }
      if (this.dxfPattern_0 == null)
        return;
      this.dxfPattern_0.TransformMe(config, transform2, undoGroup);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfHatch dxfHatch = (DxfHatch) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfHatch == null)
      {
        dxfHatch = new DxfHatch();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfHatch);
        dxfHatch.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfHatch;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfHatch dxfHatch = (DxfHatch) from;
      this.point3D_0 = dxfHatch.point3D_0;
      this.vector3D_0 = dxfHatch.vector3D_0;
      this.string_1 = dxfHatch.string_1;
      this.argbColor_0 = dxfHatch.argbColor_0;
      foreach (DxfHatch.BoundaryPath boundaryPath in dxfHatch.list_0)
        this.list_0.Add(boundaryPath.Clone(cloneContext));
      this.hatchStyle_0 = dxfHatch.hatchStyle_0;
      this.hatchPatternType_0 = dxfHatch.hatchPatternType_0;
      this.double_3 = dxfHatch.double_3;
      this.double_4 = dxfHatch.double_4;
      this.bool_3 = dxfHatch.bool_3;
      this.dxfPattern_0 = dxfHatch.dxfPattern_0 == null ? (DxfPattern) null : dxfHatch.dxfPattern_0.Clone();
      this.dxfColorGradient_0 = dxfHatch.dxfColorGradient_0 == null ? (DxfColorGradient) null : dxfHatch.dxfColorGradient_0.Clone();
      this.double_5 = dxfHatch.double_5;
      this.list_1.AddRange((IEnumerable<WW.Math.Point2D>) dxfHatch.list_1);
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      bool flag = true;
      foreach (DxfHatch.BoundaryPath boundaryPath in this.list_0)
      {
        if (!boundaryPath.Validate(model, (DxfEntity) this, messages))
          flag = false;
      }
      return flag;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal void method_13()
    {
      this.dxfPattern_0 = new DxfPattern();
    }

    internal override void Repair(DxfModelRepairer repairer)
    {
      base.Repair(repairer);
      foreach (DxfHatch.BoundaryPath boundaryPath in this.list_0)
        boundaryPath.Repair();
    }

    internal override void vmethod_10(DxfModel model)
    {
      base.vmethod_10(model);
      DxfAnnotationScaleObjectContextData.smethod_8((DxfEntity) this);
      this.bool_4 = Class1064.smethod_0((DxfHandledObject) this, model);
    }

    internal static DxfClass smethod_2(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "HATCH");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass()
        {
          ApplicationName = "ObjectDBX Classes",
          ClassNumber = (short) (500 + classes.Count),
          DwgVersion = DwgVersion.Dwg0,
          MaintenanceVersion = (short) 0,
          ProxyFlags = ProxyFlags.None,
          CPlusPlusClassName = "AcDbHatch",
          DxfName = "HATCH",
          ItemClassId = (short) 498
        };
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.short_4;
    }

    private void method_14(DrawContext.Wireframe context, IWireframeGraphicsFactory graphicsFactory)
    {
      Polyline2D[] polyline2DArray = this.method_31(context.Config, false);
      Bounds2D[] bounds2DArray = new Bounds2D[polyline2DArray.Length];
      for (int index = 0; index < polyline2DArray.Length; ++index)
      {
        bounds2DArray[index] = new Bounds2D();
        polyline2DArray[index].AddToBounds(bounds2DArray[index]);
      }
      IClippingTransformer transformer = (IClippingTransformer) context.GetTransformer().Clone();
      transformer.SetPreTransform(this.Transform);
      IList<Polyline4D> polylines = DxfUtil.smethod_39((IList<Polyline2D>) polyline2DArray, true, transformer);
      if (polylines.Count <= 0)
        return;
      graphicsFactory.CreatePathAsOne((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, polylines, true, true);
    }

    private void method_15(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory,
      out bool hatchRepeatCountTooLarge)
    {
      Polyline2D[] polyline2DArray = this.method_25((DrawContext) context, out hatchRepeatCountTooLarge);
      if (polyline2DArray == null)
        return;
      IClippingTransformer transformer = (IClippingTransformer) context.GetTransformer().Clone();
      transformer.SetPreTransform(this.Transform);
      IList<Polyline4D> polylines = DxfUtil.smethod_39((IList<Polyline2D>) polyline2DArray, false, transformer);
      if (polylines.Count <= 0)
        return;
      graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, polylines, false, true);
    }

    private void method_16(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      Polyline2D[] polyline2DArray = this.method_31(context.Config, false);
      IClippingTransformer transformer = (IClippingTransformer) context.GetTransformer().Clone();
      transformer.SetPreTransform(this.Transform);
      IList<Polyline4D> polylines = DxfUtil.smethod_39((IList<Polyline2D>) polyline2DArray, true, transformer);
      if (polylines.Count <= 0)
        return;
      if (this.hatchStyle_0 == HatchStyle.Ignore)
        Class940.smethod_2((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, true, false, polylines);
      else
        Class940.smethod_3((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, true, false, polylines);
    }

    private void method_17(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory,
      out bool hatchRepeatCountTooLarge)
    {
      Polyline2D[] polyline2DArray = this.method_25((DrawContext) context, out hatchRepeatCountTooLarge);
      if (polyline2DArray == null)
        return;
      IClippingTransformer transformer = (IClippingTransformer) context.GetTransformer().Clone();
      transformer.SetPreTransform(this.Transform);
      IList<Polyline4D> polylines = DxfUtil.smethod_39((IList<Polyline2D>) polyline2DArray, false, transformer);
      if (polylines.Count <= 0)
        return;
      Class940.smethod_3((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, false, true, polylines);
    }

    private void method_18(DrawContext.Surface context, ISurfaceGraphicsFactory graphicsFactory)
    {
      List<WW.Math.Point2D> points;
      List<Triangulator2D.Triangle> triangles;
      Polyline2D[] polyline2DArray = this.method_22(context, out points, out triangles);
      if (points.Count < 3)
        return;
      points.RemoveRange(points.Count - 3, 3);
      Interface41 nterface41 = (Interface41) context.GetTransformer().Clone();
      nterface41.SetPreTransform(this.Transform);
      if (triangles.Count > 0)
      {
        foreach (Triangulator2D.Triangle triangle in triangles)
        {
          Vector4D v0 = nterface41.Transform(points[triangle.I0]);
          Vector4D v1 = nterface41.Transform(points[triangle.I1]);
          Vector4D v2 = nterface41.Transform(points[triangle.I2]);
          graphicsFactory.CreateTriangle(v0, v1, v2, (IList<bool>) null);
        }
      }
      else
      {
        Matrix4D transform = this.Transform;
        for (int index = 0; index < polyline2DArray.Length; ++index)
        {
          WW.Math.Geometry.Polyline3D polyline = DxfUtil.smethod_42(polyline2DArray[index], transform);
          Class940.smethod_17((DxfEntity) this, context, graphicsFactory, polyline, false);
        }
      }
    }

    private void method_19(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      out bool hatchRepeatCountTooLarge)
    {
      Polyline2D[] polyline2DArray = this.method_25((DrawContext) context, out hatchRepeatCountTooLarge);
      if (polyline2DArray == null)
        return;
      IList<WW.Math.Geometry.Polyline3D> polylines = DxfUtil.smethod_41((IList<Polyline2D>) polyline2DArray, this.Transform);
      if (polylines.Count <= 0)
        return;
      Class940.smethod_16((DxfEntity) this, context, graphicsFactory, polylines, false);
    }

    private void method_20(DrawContext.Surface context, WW.Cad.Drawing.Surface.Geometry geometry)
    {
      List<WW.Math.Point2D> points;
      List<Triangulator2D.Triangle> triangles;
      Polyline2D[] polyline2DArray = this.method_22(context, out points, out triangles);
      if (triangles.Count > 0)
      {
        Matrix4D transform = this.Transform;
        for (int index = 0; index < points.Count; ++index)
          points[index] = transform.Transform(points[index]);
        foreach (Triangulator2D.Triangle triangle in triangles)
          geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Triangle((WW.Math.Point3D) points[triangle.I0], (WW.Math.Point3D) points[triangle.I1], (WW.Math.Point3D) points[triangle.I2]));
      }
      else
      {
        Matrix4D transform = this.Transform;
        for (int index = 0; index < polyline2DArray.Length; ++index)
        {
          WW.Math.Geometry.Polyline3D polyline = DxfUtil.smethod_42(polyline2DArray[index], transform);
          geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive(polyline));
        }
      }
    }

    private void method_21(
      DrawContext.Surface context,
      WW.Cad.Drawing.Surface.Geometry geometry,
      out bool hatchRepeatCountTooLarge)
    {
      Polyline2D[] polyline2DArray = this.method_25((DrawContext) context, out hatchRepeatCountTooLarge);
      if (polyline2DArray == null || polyline2DArray.Length == 0 || DxfUtil.smethod_41((IList<Polyline2D>) polyline2DArray, this.Transform).Count <= 0)
        return;
      foreach (Polyline2D polyline2D in polyline2DArray)
      {
        WW.Math.Geometry.Polyline3D polyline = new WW.Math.Geometry.Polyline3D(polyline2D.Count, polyline2D.Closed);
        foreach (WW.Math.Point2D point2D in (List<WW.Math.Point2D>) polyline2D)
          polyline.Add((WW.Math.Point3D) point2D);
        geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive(polyline));
      }
    }

    private Polyline2D[] method_22(
      DrawContext.Surface context,
      out List<WW.Math.Point2D> points,
      out List<Triangulator2D.Triangle> triangles)
    {
      Polyline2D[] polyline2DArray = this.method_31(context.Config, false);
      Bounds2D bounds = new Bounds2D();
      foreach (Polyline2D polyline2D in polyline2DArray)
        polyline2D.AddToBounds(bounds);
      Matrix4D scaleTransform;
      Matrix4D inverseScaleTransform;
      Transformation4D.GetScaleToIntegralTransforms(bounds, 741455L, out scaleTransform, out inverseScaleTransform);
      List<Polygon2I> polygon2IList = new List<Polygon2I>();
      foreach (Polyline2D polyline2D in polyline2DArray)
      {
        if (polyline2D.Closed)
        {
          Polygon2I polygon2I = new Polygon2I(scaleTransform, (ICollection<WW.Math.Point2D>) polyline2D);
          polygon2IList.Add(polygon2I);
        }
      }
      Polygon2I.BooleanOperations20Bits.Context context1 = new Polygon2I.BooleanOperations20Bits.Context();
      Polygon2I.BooleanOperations20Bits.Region region1 = Polygon2I.BooleanOperations20Bits.GetRegion((IList<Polygon2I>) polygon2IList, context1);
      Polygon2I.BooleanOperations20Bits.Region region2 = Polygon2I.BooleanOperations20Bits.Subdivide(context1, region1);
      List<Triangulator2I.Triangle> triangleList = new List<Triangulator2I.Triangle>();
      List<Point2I> point2IList = new List<Point2I>();
      Triangulator2I.Triangulate((IList<IList<Point2I>>) region2.ToPoint2IListList(), (IList<Triangulator2I.Triangle>) triangleList, (IList<Point2I>) point2IList);
      points = new List<WW.Math.Point2D>(point2IList.Count);
      for (int index = 0; index < point2IList.Count; ++index)
      {
        Point2I point2I = point2IList[index];
        points.Add(inverseScaleTransform.Transform(new WW.Math.Point2D((double) point2I.X, (double) point2I.Y)));
      }
      triangles = new List<Triangulator2D.Triangle>(triangleList.Count);
      for (int index = 0; index < triangleList.Count; ++index)
      {
        Triangulator2I.Triangle triangle = triangleList[index];
        triangles.Add(new Triangulator2D.Triangle(triangle.I0, triangle.I1, triangle.I2, (IList<WW.Math.Point2D>) points));
      }
      return polyline2DArray;
    }

    private List<Triangulator2D.Triangle> method_23(
      List<WW.Math.Point2D> points,
      List<Triangulator2D.Triangle> tmpTriangles)
    {
      List<Triangulator2D.Triangle> triangleList = new List<Triangulator2D.Triangle>(tmpTriangles.Count);
      switch (this.hatchStyle_0)
      {
        case HatchStyle.Normal:
          Triangulator2D.FilterNormal((IList<WW.Math.Point2D>) points, (ICollection<Triangulator2D.Triangle>) tmpTriangles, (IList<Triangulator2D.Triangle>) triangleList);
          break;
        case HatchStyle.Outer:
          Triangulator2D.FilterOuter(points, (ICollection<Triangulator2D.Triangle>) tmpTriangles, (IList<Triangulator2D.Triangle>) triangleList);
          break;
        default:
          Triangulator2D.FilterIgnore((IList<WW.Math.Point2D>) points, (ICollection<Triangulator2D.Triangle>) tmpTriangles, (IList<Triangulator2D.Triangle>) triangleList);
          break;
      }
      return triangleList;
    }

    private static bool smethod_3(DxfHatch.BoundaryPath path)
    {
      return true;
    }

    private static bool smethod_4(DxfHatch.BoundaryPath path)
    {
      return path.IsOutermostOrExternal;
    }

    private static bool smethod_5(DxfHatch.BoundaryPath path)
    {
      return path.IsOutermostOrExternal;
    }

    private static bool smethod_6(DxfHatch.BoundaryPath path)
    {
      return path.IsExternal;
    }

    private Polyline2D[] method_24(
      GraphicsConfig config,
      Predicate<DxfHatch.BoundaryPath> filter,
      bool includeUnclosed)
    {
      List<Polyline2D> polyline2DList1 = new List<Polyline2D>();
      List<Polygon2D> polygon2DList1 = (List<Polygon2D>) null;
      foreach (DxfHatch.BoundaryPath boundaryPath in this.list_0)
      {
        if ((includeUnclosed || !boundaryPath.IsNotClosed) && filter(boundaryPath))
        {
          if ((boundaryPath.Type & BoundaryPathType.Textbox) != BoundaryPathType.None && (boundaryPath.Type & BoundaryPathType.TextIsland) == BoundaryPathType.None)
          {
            if (polygon2DList1 == null)
              polygon2DList1 = new List<Polygon2D>();
            foreach (Polyline2D polyline in boundaryPath.GetPolylines(config))
              polygon2DList1.Add(new Polygon2D((IEnumerable<WW.Math.Point2D>) polyline));
          }
          else
            polyline2DList1.AddRange((IEnumerable<Polyline2D>) boundaryPath.GetPolylines(config));
        }
      }
      if (polygon2DList1 == null)
        return polyline2DList1.ToArray();
      Bounds2D bounds = new Bounds2D();
      List<Polygon2D> polygon2DList2 = new List<Polygon2D>(polyline2DList1.Count);
      List<Polyline2D> polyline2DList2 = new List<Polyline2D>(polyline2DList1.Count);
      foreach (Polyline2D polyline2D in polyline2DList1)
      {
        if (polyline2D.Closed)
          polygon2DList2.Add(new Polygon2D((IEnumerable<WW.Math.Point2D>) polyline2D));
        else
          polyline2DList2.Add(polyline2D);
        polyline2D.AddToBounds(bounds);
      }
      foreach (Polygon2D polygon2D in polygon2DList1)
        polygon2D.AddToBounds(bounds);
      if (bounds.Initialized)
        bounds.Delta.GetLength();
      polyline2DList1.Clear();
      polyline2DList1.AddRange((IEnumerable<Polyline2D>) polyline2DList2);
      Matrix4D scaleTransform;
      Matrix4D inverseScaleTransform;
      Transformation4D.GetScaleToIntegralTransforms(bounds, 741455L, out scaleTransform, out inverseScaleTransform);
      List<Polygon2I> polygon2IList1 = new List<Polygon2I>(polygon2DList2.Count);
      foreach (Polygon2D polygon2D in polygon2DList2)
        polygon2IList1.Add(new Polygon2I(scaleTransform, (ICollection<WW.Math.Point2D>) polygon2D));
      List<Polygon2I> polygon2IList2 = new List<Polygon2I>(polygon2DList1.Count);
      foreach (Polygon2D polygon2D in polygon2DList1)
        polygon2IList2.Add(new Polygon2I(scaleTransform, (ICollection<WW.Math.Point2D>) polygon2D));
      Polygon2I.BooleanOperations20Bits.Context context = new Polygon2I.BooleanOperations20Bits.Context();
      Polygon2I.BooleanOperations20Bits.Region region1 = Polygon2I.BooleanOperations20Bits.GetRegion((IList<Polygon2I>) polygon2IList1, context);
      Polygon2I.BooleanOperations20Bits.Region region2 = Polygon2I.BooleanOperations20Bits.GetRegion((IList<Polygon2I>) polygon2IList2, context);
      foreach (Polygon2I polygon2I in Polygon2I.BooleanOperations20Bits.GetDifference(context, DxfHatch.smethod_7(context, region1), DxfHatch.smethod_7(context, region2)).ToPolygon2IList())
      {
        Polyline2D polyline2D = new Polyline2D(polygon2I.Count, true);
        foreach (Point2I point2I in (List<Point2I>) polygon2I)
          polyline2D.Add(inverseScaleTransform.Transform(new WW.Math.Point2D((double) point2I.X, (double) point2I.Y)));
        polyline2DList1.Add(polyline2D);
      }
      return polyline2DList1.ToArray();
    }

    private static Polygon2I.BooleanOperations20Bits.Region smethod_7(
      Polygon2I.BooleanOperations20Bits.Context context,
      Polygon2I.BooleanOperations20Bits.Region region)
    {
      region = region.Subdivide(context);
      List<Triangulator2I.Triangle> triangleList = new List<Triangulator2I.Triangle>();
      List<Point2I> points = new List<Point2I>();
      Triangulator2I.Triangulate((IList<IList<Point2I>>) region.ToPoint2IListList(), (IList<Triangulator2I.Triangle>) triangleList, (IList<Point2I>) points);
      return Polygon2I.BooleanOperations20Bits.GetRegion((IList<Polygon2I>) Triangulator2I.GetPolygons((ICollection<Triangulator2I.Triangle>) triangleList, points), context);
    }

    private static Polygon2LR.BooleanOperations.Region smethod_8(
      Polygon2LR.BooleanOperations.Context context,
      Polygon2LR.BooleanOperations.Region region)
    {
      region = region.Subdivide(context);
      List<Triangulator2LR.Triangle> triangleList = new List<Triangulator2LR.Triangle>();
      List<Point2LR> points = new List<Point2LR>();
      Triangulator2LR.Triangulate((IList<IList<Point2LR>>) region.ToPoint2LRListList(), (IList<Triangulator2LR.Triangle>) triangleList, (IList<Point2LR>) points);
      return Polygon2LR.BooleanOperations.GetRegion((IList<Polygon2LR>) Triangulator2LR.GetPolygons((ICollection<Triangulator2LR.Triangle>) triangleList, points), context);
    }

    private Polyline2D[] method_25(DrawContext context, out bool hatchRepeatCountTooLarge)
    {
      hatchRepeatCountTooLarge = false;
      if (this.dxfPattern_0.Lines.Count == 0 || this.list_0.Count == 0)
        return (Polyline2D[]) null;
      List<Polyline2D> polylines = new List<Polyline2D>();
      Polyline2D[] boundaries = this.method_31(context.Config, true);
      if (boundaries == null)
        return (Polyline2D[]) null;
      if (!context.Config.DrawHatchPatterns)
      {
        if (context.Config.HatchOverflowHandling != HatchOverflowHandling.DrawBoundary)
          return (Polyline2D[]) null;
        polylines.AddRange((IEnumerable<Polyline2D>) this.method_31(context.Config, true));
        return polylines.ToArray();
      }
      foreach (Pair<WW.Math.Point2D, Polyline2D[]> pair in this.method_26(boundaries))
      {
        hatchRepeatCountTooLarge = this.method_27(context.Config, pair.Second);
        if (!hatchRepeatCountTooLarge)
        {
          this.dxfPattern_0.method_0(polylines, pair.Second, pair.First, this.hatchStyle_0 == HatchStyle.Ignore);
          if (context.Config.ShowHatchBoundaries)
            polylines.AddRange((IEnumerable<Polyline2D>) pair.Second);
        }
        else
        {
          if (context.Config.HatchOverflowHandling != HatchOverflowHandling.DrawBoundary)
            return (Polyline2D[]) null;
          polylines.Clear();
          polylines.AddRange((IEnumerable<Polyline2D>) this.method_31(context.Config, true));
          return polylines.ToArray();
        }
      }
      return polylines.ToArray();
    }

    private List<Pair<WW.Math.Point2D, Polyline2D[]>> method_26(
      Polyline2D[] boundaries)
    {
      List<Pair<WW.Math.Point2D, Polyline2D[]>> pairList = new List<Pair<WW.Math.Point2D, Polyline2D[]>>();
      if (this.list_1.Count != 0 && this.hatchStyle_0 != HatchStyle.Outer)
      {
        if (this.list_1.Count == 1)
        {
          pairList.Add(new Pair<WW.Math.Point2D, Polyline2D[]>(this.list_1[0], boundaries));
        }
        else
        {
          List<WW.Math.Point2D> point2DList = new List<WW.Math.Point2D>();
          foreach (WW.Math.Point2D point2D in this.list_1)
          {
            int num = 0;
            foreach (Polyline2D boundary in boundaries)
              num += boundary.GetWindingNumber(point2D.X, point2D.Y);
            if (num % 2 != 0)
              point2DList.Add(point2D);
          }
          if (point2DList.Count == 0)
            pairList.Add(new Pair<WW.Math.Point2D, Polyline2D[]>(this.list_1[0], boundaries));
          else if (point2DList.Count == 1)
          {
            pairList.Add(new Pair<WW.Math.Point2D, Polyline2D[]>(point2DList[0], boundaries));
          }
          else
          {
            List<Polyline2D> polyline2DList = new List<Polyline2D>();
            foreach (Polyline2D[] polyline2DArray in DxfHatch.smethod_9(boundaries))
            {
              bool flag = false;
              foreach (WW.Math.Point2D p in this.list_1)
                Polygon2D.GetWindingNumber(p, (IEnumerable<IList<WW.Math.Point2D>>) polyline2DArray);
              if (!flag)
                polyline2DList.AddRange((IEnumerable<Polyline2D>) polyline2DArray);
            }
            if (polyline2DList.Count > 0)
              pairList.Add(new Pair<WW.Math.Point2D, Polyline2D[]>(this.list_1[0], polyline2DList.ToArray()));
          }
        }
      }
      else
        pairList.Add(new Pair<WW.Math.Point2D, Polyline2D[]>(WW.Math.Point2D.Zero, boundaries));
      return pairList;
    }

    private static IEnumerable<Polyline2D[]> smethod_9(Polyline2D[] polylines)
    {
      List<Polyline2D[]> polyline2DArrayList = new List<Polyline2D[]>();
      bool[][] overlapMatrix = new bool[polylines.Length][];
      for (int index = 0; index < overlapMatrix.Length; ++index)
        overlapMatrix[index] = new bool[polylines.Length];
      for (int index1 = 0; index1 < polylines.Length - 1; ++index1)
      {
        Polyline2D polyline = polylines[index1];
        for (int index2 = index1 + 1; index2 < polylines.Length; ++index2)
        {
          bool[] flagArray1 = overlapMatrix[index1];
          int index3 = index2;
          bool[] flagArray2 = overlapMatrix[index2];
          int index4 = index1;
          Polyline2D[] polyline2DArray = new Polyline2D[2]{ polyline, polylines[index2] };
          int num1;
          bool flag = (num1 = Polygon2D.Overlap((ICollection<IList<WW.Math.Point2D>>) polyline2DArray, 1E-08) ? 1 : 0) != 0;
          flagArray2[index4] = num1 != 0;
          int num2 = flag ? 1 : 0;
          flagArray1[index3] = num2 != 0;
        }
      }
      List<Polyline2D> polyline2DList = new List<Polyline2D>();
      for (int index = 0; index < polylines.Length; ++index)
      {
        DxfHatch.smethod_10(index, (ICollection<Polyline2D>) polyline2DList, polylines, overlapMatrix);
        if (polyline2DList.Count > 0)
        {
          polyline2DArrayList.Add(polyline2DList.ToArray());
          polyline2DList.Clear();
        }
      }
      return (IEnumerable<Polyline2D[]>) polyline2DArrayList;
    }

    private static void smethod_10(
      int index,
      ICollection<Polyline2D> result,
      Polyline2D[] polylines,
      bool[][] overlapMatrix)
    {
      if (overlapMatrix[index][index])
        return;
      overlapMatrix[index][index] = true;
      result.Add(polylines[index]);
      for (int index1 = 0; index1 < overlapMatrix[index].Length; ++index1)
      {
        if (index1 != index && overlapMatrix[index][index1])
          DxfHatch.smethod_10(index1, result, polylines, overlapMatrix);
      }
    }

    private bool method_27(GraphicsConfig graphicsConfig, Polyline2D[] boundaryPolylines)
    {
      double totalArea = 0.0;
      foreach (Polyline2D boundaryPolyline in boundaryPolylines)
        totalArea += System.Math.Abs(Polygon2D.GetArea((IList<WW.Math.Point2D>) boundaryPolyline));
      return this.dxfPattern_0.method_1(totalArea) > (double) graphicsConfig.MaxHatchPatternRepeatCount;
    }

    private Polyline2D[] method_28(GraphicsConfig config, bool includeUnclosed)
    {
      return this.method_24(config, new Predicate<DxfHatch.BoundaryPath>(DxfHatch.smethod_4), includeUnclosed);
    }

    private Polyline2D[] method_29(GraphicsConfig config, bool includeUnclosed)
    {
      return this.method_24(config, new Predicate<DxfHatch.BoundaryPath>(DxfHatch.smethod_6), includeUnclosed);
    }

    private Polyline2D[] method_30(GraphicsConfig config, bool includeUnclosed)
    {
      return this.method_24(config, new Predicate<DxfHatch.BoundaryPath>(DxfHatch.smethod_3), includeUnclosed);
    }

    private Polyline2D[] method_31(GraphicsConfig config, bool includeUnclosed)
    {
      switch (this.hatchStyle_0)
      {
        case HatchStyle.Outer:
          return this.method_28(config, includeUnclosed);
        case HatchStyle.Ignore:
          return this.method_29(config, includeUnclosed);
        default:
          return this.method_30(config, includeUnclosed);
      }
    }

    public bool IsAnnotative
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

    public DxfAnnotationScaleObjectContextData CreateContextData(
      DxfScale s)
    {
      return (DxfAnnotationScaleObjectContextData) new DxfHatchScaleContextData(this, s);
    }

    public class BoundaryPath
    {
      private readonly List<DxfHatch.BoundaryPath.Edge> list_0 = new List<DxfHatch.BoundaryPath.Edge>();
      private readonly DxfEntityCollection dxfEntityCollection_0 = new DxfEntityCollection();
      private BoundaryPathType boundaryPathType_0;
      private DxfHatch.BoundaryPath.Polyline polyline_0;

      public BoundaryPath()
      {
      }

      public BoundaryPath(BoundaryPathType type)
      {
        this.boundaryPathType_0 = type;
      }

      public DxfHatch.BoundaryPath.Polyline PolylineData
      {
        get
        {
          return this.polyline_0;
        }
        set
        {
          this.polyline_0 = value;
          this.IsPolyline = this.polyline_0 != null;
        }
      }

      public List<DxfHatch.BoundaryPath.Edge> Edges
      {
        get
        {
          return this.list_0;
        }
      }

      public BoundaryPathType Type
      {
        get
        {
          return this.boundaryPathType_0;
        }
        set
        {
          this.boundaryPathType_0 = value;
        }
      }

      public bool IsPolyline
      {
        get
        {
          return (this.boundaryPathType_0 & BoundaryPathType.Polyline) != BoundaryPathType.None;
        }
        set
        {
          if (value)
            this.boundaryPathType_0 |= BoundaryPathType.Polyline;
          else
            this.boundaryPathType_0 &= ~BoundaryPathType.Polyline;
        }
      }

      public bool IsOutermost
      {
        get
        {
          return (this.boundaryPathType_0 & BoundaryPathType.Outermost) != BoundaryPathType.None;
        }
        set
        {
          if (value)
            this.boundaryPathType_0 |= BoundaryPathType.Outermost;
          else
            this.boundaryPathType_0 &= ~BoundaryPathType.Outermost;
        }
      }

      public bool IsExternal
      {
        get
        {
          return (this.boundaryPathType_0 & BoundaryPathType.External) != BoundaryPathType.None;
        }
        set
        {
          if (value)
            this.boundaryPathType_0 |= BoundaryPathType.External;
          else
            this.boundaryPathType_0 &= ~BoundaryPathType.External;
        }
      }

      public bool IsNotClosed
      {
        get
        {
          return (this.boundaryPathType_0 & BoundaryPathType.NotClosed) != BoundaryPathType.None;
        }
        set
        {
          if (value)
            this.boundaryPathType_0 |= BoundaryPathType.NotClosed;
          else
            this.boundaryPathType_0 &= ~BoundaryPathType.NotClosed;
        }
      }

      public bool IsOutermostOrExternal
      {
        get
        {
          return (this.boundaryPathType_0 & (BoundaryPathType.External | BoundaryPathType.Outermost)) != BoundaryPathType.None;
        }
      }

      public DxfEntityCollection BoundaryObjects
      {
        get
        {
          return this.dxfEntityCollection_0;
        }
      }

      private static void smethod_0(Polyline2D polyline, IList<Polyline2D> polylines)
      {
        Bounds2D bounds2D = new Bounds2D();
        foreach (List<WW.Math.Point2D> polyline1 in (IEnumerable<Polyline2D>) polylines)
        {
          foreach (WW.Math.Point2D p in polyline1)
            bounds2D.Update(p);
        }
        if (!bounds2D.Initialized)
          return;
        double num1 = 0.01 * System.Math.Max(bounds2D.Delta.X, bounds2D.Delta.Y);
        double num2 = num1 * num1;
        for (int index1 = 0; index1 < polylines.Count - 1; ++index1)
        {
          Polyline2D polyline1 = polylines[index1];
          WW.Math.Point2D point2D = polyline1[polyline1.Count - 1];
          int index2 = -1;
          double num3 = num2;
          bool flag = false;
          for (int index3 = index1 + 1; index3 < polylines.Count; ++index3)
          {
            Polyline2D polyline2 = polylines[index3];
            double lengthSquared1 = (polyline2[0] - point2D).GetLengthSquared();
            if (lengthSquared1 < num3)
            {
              index2 = index3;
              num3 = lengthSquared1;
              flag = false;
            }
            double lengthSquared2 = (polyline2[polyline2.Count - 1] - point2D).GetLengthSquared();
            if (lengthSquared2 < num3)
            {
              index2 = index3;
              num3 = lengthSquared2;
              flag = true;
            }
          }
          if (index2 < 0)
            return;
          if (index2 != index1 + 1)
          {
            Polyline2D polyline2 = polylines[index1 + 1];
            polylines[index1 + 1] = polylines[index2];
            polylines[index2] = polyline2;
          }
          if (flag)
            polylines[index1 + 1].Reverse();
        }
        foreach (Polyline2D polyline1 in (IEnumerable<Polyline2D>) polylines)
        {
          if (polyline.Count > 0 && polyline[polyline.Count - 1] == polyline1[0])
            polyline.AddRange((IEnumerable<WW.Math.Point2D>) polyline1.GetSubPolyline(1, polyline1.Count - 1));
          else
            polyline.AddRange((IEnumerable<WW.Math.Point2D>) polyline1);
        }
      }

      public void TransformMe(Matrix4D transform, CommandGroup undoGroup)
      {
        if (this.polyline_0 != null)
          this.polyline_0.TransformMe(transform, undoGroup);
        foreach (DxfHatch.BoundaryPath.Edge edge in this.list_0)
          edge.TransformMe(transform, undoGroup);
      }

      public DxfHatch.BoundaryPath Clone(CloneContext cloneContext)
      {
        DxfHatch.BoundaryPath boundaryPath = new DxfHatch.BoundaryPath();
        boundaryPath.CopyFrom(this, cloneContext);
        return boundaryPath;
      }

      public bool Validate(DxfModel model, DxfEntity entity, IList<DxfMessage> messages)
      {
        bool flag = true;
        if (this.polyline_0 != null && !this.polyline_0.Validate(model, messages))
          flag = false;
        foreach (DxfHatch.BoundaryPath.Edge edge in this.list_0)
        {
          if (!edge.Validate(model, entity, messages))
            flag = false;
        }
        return flag;
      }

      public void Repair()
      {
        if (this.polyline_0 != null)
          this.polyline_0.Repair();
        for (int index = this.dxfEntityCollection_0.Count - 1; index >= 0; --index)
        {
          if (this.dxfEntityCollection_0[index] == null)
            this.dxfEntityCollection_0.RemoveAt(index);
        }
      }

      public void CopyFrom(DxfHatch.BoundaryPath from, CloneContext cloneContext)
      {
        this.boundaryPathType_0 = from.boundaryPathType_0;
        if (from.polyline_0 != null)
          this.polyline_0 = from.polyline_0.Clone(cloneContext);
        foreach (DxfHatch.BoundaryPath.Edge edge in from.list_0)
          this.list_0.Add(edge.Clone(cloneContext));
        if (from.dxfEntityCollection_0.Count <= 0)
          return;
        if (cloneContext.SourceModel == cloneContext.TargetModel)
        {
          this.dxfEntityCollection_0.AddRange((IEnumerable<DxfEntity>) from.dxfEntityCollection_0);
        }
        else
        {
          DxfHatch.BoundaryPath.CloneBuilder cloneBuilder = new DxfHatch.BoundaryPath.CloneBuilder();
          cloneBuilder.ClonedBoundaryPath = this;
          foreach (DxfEntity dxfEntity in (DxfHandledObjectCollection<DxfEntity>) from.dxfEntityCollection_0)
            cloneBuilder.OriginalBoundaryObjects.Add(dxfEntity);
          cloneContext.CloneBuilders.Add((ICloneBuilder) cloneBuilder);
        }
      }

      internal List<Polyline2D> GetPolylines(GraphicsConfig config)
      {
        List<Polyline2D> polyline2DList = new List<Polyline2D>();
        if ((this.boundaryPathType_0 & BoundaryPathType.Polyline) == BoundaryPathType.Polyline)
        {
          Polyline2D polyline2D = this.polyline_0.method_0(config);
          if (polyline2D != null)
          {
            if (polyline2D.Count > 1 && WW.Math.Point2D.AreApproxEqual(polyline2D[0], polyline2D[polyline2D.Count - 1], 1E-08))
              polyline2D.RemoveAt(polyline2D.Count - 1);
            polyline2DList.Add(polyline2D);
          }
        }
        else if ((this.boundaryPathType_0 & BoundaryPathType.NotClosed) != BoundaryPathType.None)
        {
          foreach (DxfHatch.BoundaryPath.Edge edge in this.list_0)
          {
            Polyline2D polyline = new Polyline2D(false);
            edge.vmethod_0(polyline, config);
            if (polyline.Count > 1)
              polyline2DList.Add(polyline);
          }
        }
        else
        {
          Polyline2D polyline = new Polyline2D(true);
          foreach (DxfHatch.BoundaryPath.Edge edge in this.list_0)
            edge.vmethod_0(polyline, config);
          if (polyline.Count > 3 || polyline.Count == 3 && !WW.Math.Point2D.AreApproxEqual(polyline[0], polyline[2], 1E-08))
          {
            polyline.Closed = true;
            if (polyline.Count > 1 && WW.Math.Point2D.AreApproxEqual(polyline[0], polyline[polyline.Count - 1], 1E-08))
              polyline.RemoveAt(polyline.Count - 1);
            polyline2DList.Add(polyline);
          }
        }
        return polyline2DList;
      }

      internal void Write(Class432 w)
      {
        this.Write(w, true);
      }

      internal void Write(Class432 w, bool writePolylines)
      {
        Interface29 objectWriter = w.ObjectWriter;
        objectWriter.imethod_33((int) this.boundaryPathType_0);
        if (!writePolylines)
        {
          bool flag = this.IsPolyline ? this.polyline_0 == null : this.list_0.Count == 0;
          objectWriter.imethod_14(flag);
          if (flag)
            return;
        }
        if (this.IsPolyline && (writePolylines || (this.boundaryPathType_0 & BoundaryPathType.IsAnnotative) != BoundaryPathType.None))
        {
          bool flag = this.polyline_0.Vertices.Any<DxfHatch.BoundaryPath.Polyline.Vertex>((Func<DxfHatch.BoundaryPath.Polyline.Vertex, bool>) (t => t.Bulge != 0.0));
          objectWriter.imethod_14(flag);
          objectWriter.imethod_14(this.polyline_0.Closed);
          objectWriter.imethod_33(this.polyline_0.Vertices.Count);
          foreach (DxfHatch.BoundaryPath.Polyline.Vertex vertex in this.polyline_0.Vertices)
          {
            objectWriter.imethod_25(vertex.Position);
            if (flag)
              objectWriter.imethod_16(vertex.Bulge);
          }
        }
        else
        {
          objectWriter.imethod_33(this.Edges.Count);
          foreach (DxfHatch.BoundaryPath.Edge edge in this.Edges)
            edge.Accept((DxfHatch.BoundaryPath.IEdgeVisitor) w);
        }
      }

      internal void Read(Class434 or)
      {
        this.Read(or, true);
      }

      internal void Read(Class434 or, bool readPolylines)
      {
        Interface30 objectBitStream = or.ObjectBitStream;
        this.boundaryPathType_0 = (BoundaryPathType) objectBitStream.imethod_11();
        if (!readPolylines && objectBitStream.imethod_6())
          return;
        if (this.IsPolyline && (readPolylines || (this.boundaryPathType_0 & BoundaryPathType.IsAnnotative) != BoundaryPathType.None))
        {
          this.polyline_0 = new DxfHatch.BoundaryPath.Polyline();
          bool flag = objectBitStream.imethod_6();
          this.polyline_0.Closed = objectBitStream.imethod_6();
          int num = objectBitStream.imethod_11();
          for (int index = 0; index < num; ++index)
          {
            DxfHatch.BoundaryPath.Polyline.Vertex vertex = new DxfHatch.BoundaryPath.Polyline.Vertex(objectBitStream.imethod_38());
            if (flag)
              vertex.Bulge = objectBitStream.imethod_8();
            this.polyline_0.Vertices.Add(vertex);
          }
        }
        else
        {
          int num1 = objectBitStream.imethod_11();
          for (int index1 = 0; index1 < num1; ++index1)
          {
            switch (objectBitStream.imethod_18())
            {
              case 1:
                this.list_0.Add((DxfHatch.BoundaryPath.Edge) new DxfHatch.BoundaryPath.LineEdge()
                {
                  Start = objectBitStream.imethod_38(),
                  End = objectBitStream.imethod_38()
                });
                break;
              case 2:
                this.list_0.Add((DxfHatch.BoundaryPath.Edge) new DxfHatch.BoundaryPath.ArcEdge()
                {
                  Center = objectBitStream.imethod_38(),
                  Radius = objectBitStream.imethod_8(),
                  StartAngle = objectBitStream.imethod_8(),
                  EndAngle = objectBitStream.imethod_8(),
                  CounterClockWise = objectBitStream.imethod_6()
                });
                break;
              case 3:
                this.list_0.Add((DxfHatch.BoundaryPath.Edge) new DxfHatch.BoundaryPath.EllipseEdge()
                {
                  Center = objectBitStream.imethod_38(),
                  MajorAxisEndPoint = objectBitStream.imethod_50(),
                  MinorToMajorRatio = objectBitStream.imethod_8(),
                  StartAngle = objectBitStream.imethod_8(),
                  EndAngle = objectBitStream.imethod_8(),
                  CounterClockWise = objectBitStream.imethod_6()
                });
                break;
              case 4:
                DxfHatch.BoundaryPath.SplineEdge splineEdge = new DxfHatch.BoundaryPath.SplineEdge();
                splineEdge.Degree = objectBitStream.imethod_11();
                splineEdge.Rational = objectBitStream.imethod_6();
                splineEdge.Periodic = objectBitStream.imethod_6();
                int num2 = objectBitStream.imethod_11();
                int num3 = objectBitStream.imethod_11();
                for (int index2 = 0; index2 < num2; ++index2)
                  splineEdge.Knots.Add(objectBitStream.imethod_8());
                for (int index2 = 0; index2 < num3; ++index2)
                {
                  splineEdge.ControlPoints.Add(objectBitStream.imethod_38());
                  if (splineEdge.Rational)
                    splineEdge.Weights.Add(objectBitStream.imethod_8());
                }
                if (or.Builder.Version > DxfVersion.Dxf21)
                {
                  int num4 = objectBitStream.imethod_11();
                  if (num4 > 0)
                  {
                    splineEdge.FitPointData = new DxfHatch.FitPointData();
                    for (int index2 = 0; index2 < num4; ++index2)
                      splineEdge.FitPointData.FitPoints.Add(objectBitStream.imethod_38());
                    splineEdge.FitPointData.StartTangent = objectBitStream.imethod_50();
                    splineEdge.FitPointData.EndTangent = objectBitStream.imethod_50();
                  }
                }
                this.list_0.Add((DxfHatch.BoundaryPath.Edge) splineEdge);
                break;
            }
          }
        }
      }

      internal void method_0(int nrOfEdges, DxfReader dxfReader)
      {
        for (int index = 0; index < nrOfEdges; ++index)
        {
          if (dxfReader.CurrentGroup.Code != 72)
            throw new Exception("Expected group 72 in boundary path model, but got group " + dxfReader.CurrentGroup.Code.ToString());
          EdgeType edgeType = (EdgeType) (short) dxfReader.CurrentGroup.Value;
          dxfReader.method_85();
          switch (edgeType)
          {
            case EdgeType.Line:
              DxfHatch.BoundaryPath.LineEdge lineEdge = new DxfHatch.BoundaryPath.LineEdge();
              lineEdge.Read(dxfReader);
              this.list_0.Add((DxfHatch.BoundaryPath.Edge) lineEdge);
              break;
            case EdgeType.CircularArc:
              DxfHatch.BoundaryPath.ArcEdge arcEdge = new DxfHatch.BoundaryPath.ArcEdge();
              arcEdge.Read(dxfReader);
              this.list_0.Add((DxfHatch.BoundaryPath.Edge) arcEdge);
              break;
            case EdgeType.EllipticArc:
              DxfHatch.BoundaryPath.EllipseEdge ellipseEdge = new DxfHatch.BoundaryPath.EllipseEdge();
              ellipseEdge.Read(dxfReader);
              this.list_0.Add((DxfHatch.BoundaryPath.Edge) ellipseEdge);
              break;
            case EdgeType.Spline:
              DxfHatch.BoundaryPath.SplineEdge splineEdge = new DxfHatch.BoundaryPath.SplineEdge();
              splineEdge.Read(dxfReader);
              this.list_0.Add((DxfHatch.BoundaryPath.Edge) splineEdge);
              break;
          }
        }
      }

      internal void method_1(DxfWriter w)
      {
        w.Write(93, (object) this.list_0.Count);
        foreach (DxfHatch.BoundaryPath.Edge edge in this.list_0)
        {
          if (edge is DxfHatch.BoundaryPath.LineEdge)
          {
            DxfHatch.BoundaryPath.LineEdge lineEdge = edge as DxfHatch.BoundaryPath.LineEdge;
            w.Write(72, (object) (short) 1);
            w.Write(10, lineEdge.Start);
            w.Write(11, lineEdge.End);
          }
          else if (edge is DxfHatch.BoundaryPath.ArcEdge)
          {
            DxfHatch.BoundaryPath.ArcEdge arcEdge = edge as DxfHatch.BoundaryPath.ArcEdge;
            w.Write(72, (object) (short) 2);
            w.Write(10, arcEdge.Center);
            w.Write(40, (object) arcEdge.Radius);
            w.Write(50, (object) (arcEdge.StartAngle * (180.0 / System.Math.PI)));
            w.Write(51, (object) (arcEdge.EndAngle * (180.0 / System.Math.PI)));
            w.Write(73, (object) (short) (arcEdge.CounterClockWise ? 1 : 0));
          }
          else if (edge is DxfHatch.BoundaryPath.EllipseEdge)
          {
            DxfHatch.BoundaryPath.EllipseEdge ellipseEdge = edge as DxfHatch.BoundaryPath.EllipseEdge;
            w.Write(72, (object) (short) 3);
            w.Write(10, ellipseEdge.Center);
            w.Write(11, ellipseEdge.MajorAxisEndPoint);
            w.Write(40, (object) ellipseEdge.MinorToMajorRatio);
            w.Write(50, (object) (ellipseEdge.StartAngle * (180.0 / System.Math.PI)));
            w.Write(51, (object) (ellipseEdge.EndAngle * (180.0 / System.Math.PI)));
            w.Write(73, (object) (short) (ellipseEdge.CounterClockWise ? 1 : 0));
          }
          else if (edge is DxfHatch.BoundaryPath.SplineEdge)
          {
            DxfHatch.BoundaryPath.SplineEdge splineEdge = edge as DxfHatch.BoundaryPath.SplineEdge;
            w.Write(72, (object) (short) 4);
            w.Write(94, (object) splineEdge.Degree);
            w.Write(73, (object) (short) (splineEdge.Rational ? 1 : 0));
            w.Write(74, (object) (short) (splineEdge.Periodic ? 1 : 0));
            w.Write(95, (object) splineEdge.Knots.Count);
            w.Write(96, (object) splineEdge.ControlPoints.Count);
            foreach (double knot in splineEdge.Knots)
              w.Write(40, (object) knot);
            for (int index = 0; index < splineEdge.ControlPoints.Count; ++index)
            {
              w.Write(10, splineEdge.ControlPoints[index]);
              if (splineEdge.Weights.Count > 0)
                w.Write(42, (object) splineEdge.Weights[index]);
            }
            if (w.Version > DxfVersion.Dxf21)
            {
              if (splineEdge.FitPointData != null && splineEdge.FitPointData.FitPoints.Count != 0)
              {
                w.Write(97, (object) splineEdge.FitPointData.FitPoints.Count);
                foreach (WW.Math.Point2D fitPoint in splineEdge.FitPointData.FitPoints)
                  w.Write(11, fitPoint);
                w.Write(12, splineEdge.FitPointData.StartTangent);
                w.Write(13, splineEdge.FitPointData.EndTangent);
              }
              else
                w.Write(97, (object) 0);
            }
          }
        }
      }

      public class Polyline
      {
        private bool bool_0;
        private List<DxfHatch.BoundaryPath.Polyline.Vertex> list_0;

        public Polyline()
        {
          this.list_0 = new List<DxfHatch.BoundaryPath.Polyline.Vertex>();
        }

        public Polyline(
          params DxfHatch.BoundaryPath.Polyline.Vertex[] vertices)
        {
          this.list_0 = new List<DxfHatch.BoundaryPath.Polyline.Vertex>((IEnumerable<DxfHatch.BoundaryPath.Polyline.Vertex>) vertices);
        }

        public Polyline(
          bool closed,
          params DxfHatch.BoundaryPath.Polyline.Vertex[] vertices)
        {
          this.list_0 = new List<DxfHatch.BoundaryPath.Polyline.Vertex>((IEnumerable<DxfHatch.BoundaryPath.Polyline.Vertex>) vertices);
          this.bool_0 = closed;
        }

        public Polyline(params WW.Math.Point2D[] vertices)
        {
          this.list_0 = new List<DxfHatch.BoundaryPath.Polyline.Vertex>(vertices.Length);
          foreach (WW.Math.Point2D vertex in vertices)
            this.list_0.Add(new DxfHatch.BoundaryPath.Polyline.Vertex(vertex));
        }

        public Polyline(bool closed, params WW.Math.Point2D[] vertices)
          : this(vertices)
        {
          this.bool_0 = closed;
        }

        public Polyline(ICollection<WW.Math.Point2D> vertices)
        {
          this.list_0 = new List<DxfHatch.BoundaryPath.Polyline.Vertex>(vertices.Count);
          foreach (WW.Math.Point2D vertex in (IEnumerable<WW.Math.Point2D>) vertices)
            this.list_0.Add(new DxfHatch.BoundaryPath.Polyline.Vertex(vertex));
        }

        public Polyline(bool closed, ICollection<WW.Math.Point2D> vertices)
          : this(vertices)
        {
          this.bool_0 = closed;
        }

        public bool Closed
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

        public List<DxfHatch.BoundaryPath.Polyline.Vertex> Vertices
        {
          get
          {
            return this.list_0;
          }
        }

        internal Polyline2D method_0(GraphicsConfig config)
        {
          if (this.list_0.Count == 0)
            return (Polyline2D) null;
          int count = this.list_0.Count;
          int capacity = count + (this.Closed ? 1 : 0);
          Polyline2D polyline2D = new Polyline2D(capacity, this.Closed);
          DxfHatch.BoundaryPath.Polyline.Vertex vertex1 = this.list_0[0];
          for (int index1 = 0; index1 < capacity; ++index1)
          {
            DxfHatch.BoundaryPath.Polyline.Vertex vertex2 = this.list_0[(index1 + 1) % count];
            bool flag;
            if (!(flag = index1 == capacity - 1) && vertex1.Bulge != 0.0)
            {
              Vector2D vector2D1 = vertex2.Position - vertex1.Position;
              double length = vector2D1.GetLength();
              if (length != 0.0)
              {
                double num1 = 4.0 * System.Math.Atan(vertex1.Bulge);
                double num2 = length / (2.0 * System.Math.Abs(System.Math.Sin(num1 * 0.5)));
                Vector2D vector2D2 = vector2D1;
                vector2D2.Normalize();
                double num3 = (double) System.Math.Sign(vertex1.Bulge);
                Vector2D vector2D3 = new Vector2D(-vector2D2.Y, vector2D2.X) * num3;
                WW.Math.Point2D point2D1 = (WW.Math.Point2D) (((Vector2D) vertex2.Position + (Vector2D) vertex1.Position) * 0.5) + vector2D3 * System.Math.Cos(num1 * 0.5) * num2;
                Vector2D vector2D4 = vertex1.Position - point2D1;
                double num4 = System.Math.Atan2(vector2D4.Y, vector2D4.X);
                Vector2D vector2D5 = vertex2.Position - point2D1;
                double num5 = System.Math.Atan2(vector2D5.Y, vector2D5.X);
                double num6 = num4;
                double num7 = num3 * 2.0 * System.Math.PI / (double) config.NoOfArcLineSegments;
                while (num5 < num4)
                  num5 += 2.0 * System.Math.PI;
                int num8 = (int) System.Math.Ceiling(vertex1.Bulge >= 0.0 ? System.Math.Abs(num5 - num4) / num7 : System.Math.Abs((2.0 * System.Math.PI - (num5 - num4)) / num7));
                for (int index2 = 0; index2 < num8; ++index2)
                {
                  double num9 = System.Math.Cos(num6);
                  double num10 = System.Math.Sin(num6);
                  WW.Math.Point2D point2D2 = point2D1 + new Vector2D(num9 * num2, num10 * num2);
                  polyline2D.Add(point2D2);
                  num6 += num7;
                }
              }
            }
            else if (!flag || !this.Closed)
              polyline2D.Add(vertex1.Position);
            vertex1 = vertex2;
          }
          return polyline2D;
        }

        public void TransformMe(Matrix4D transform, CommandGroup undoGroup)
        {
          bool flipOrientation = Class749.smethod_5(transform);
          for (int index = this.list_0.Count - 1; index >= 0; --index)
            this.list_0[index].TransformMe(transform, undoGroup, flipOrientation);
        }

        public DxfHatch.BoundaryPath.Polyline Clone(CloneContext cloneContext)
        {
          DxfHatch.BoundaryPath.Polyline polyline = new DxfHatch.BoundaryPath.Polyline();
          polyline.CopyFrom(this, cloneContext);
          return polyline;
        }

        public bool Validate(DxfModel model, IList<DxfMessage> messages)
        {
          return true;
        }

        public void Repair()
        {
          if (!this.bool_0 || this.list_0.Count <= 1)
            return;
          DxfHatch.BoundaryPath.Polyline.Vertex other = this.list_0[0];
          for (int index = this.list_0.Count - 1; index >= 0; --index)
          {
            DxfHatch.BoundaryPath.Polyline.Vertex vertex = this.list_0[index];
            if (vertex.Equals(other))
              this.list_0.RemoveAt(index);
            other = vertex;
          }
        }

        public void CopyFrom(DxfHatch.BoundaryPath.Polyline from, CloneContext cloneContext)
        {
          this.bool_0 = from.bool_0;
          foreach (DxfHatch.BoundaryPath.Polyline.Vertex vertex in from.list_0)
            this.list_0.Add(vertex.Clone(cloneContext));
        }

        internal void Write(DxfWriter w)
        {
          bool flag = this.Vertices.All<DxfHatch.BoundaryPath.Polyline.Vertex>((Func<DxfHatch.BoundaryPath.Polyline.Vertex, bool>) (v => v.Bulge == 0.0));
          w.method_221(72, !flag);
          w.method_221(73, this.Closed);
          w.Write(93, (object) this.Vertices.Count);
          foreach (DxfHatch.BoundaryPath.Polyline.Vertex vertex in this.Vertices)
          {
            w.Write(10, (object) vertex.X);
            w.Write(20, (object) vertex.Y);
            if (!flag)
              w.Write(42, (object) vertex.Bulge);
          }
        }

        internal void Read(DxfReader dxfReader)
        {
          bool flag = true;
          DxfHatch.BoundaryPath.Polyline.Vertex vertex = (DxfHatch.BoundaryPath.Polyline.Vertex) null;
          do
          {
            switch (dxfReader.CurrentGroup.Code)
            {
              case 10:
                if (vertex != null)
                  this.Vertices.Add(vertex);
                vertex = new DxfHatch.BoundaryPath.Polyline.Vertex();
                vertex.X = (double) dxfReader.CurrentGroup.Value;
                goto case 72;
              case 20:
                if (vertex == null)
                  vertex = new DxfHatch.BoundaryPath.Polyline.Vertex();
                vertex.Y = (double) dxfReader.CurrentGroup.Value;
                goto case 72;
              case 42:
                if (vertex == null)
                  vertex = new DxfHatch.BoundaryPath.Polyline.Vertex();
                vertex.Bulge = (double) dxfReader.CurrentGroup.Value;
                goto case 72;
              case 72:
              case 93:
                if (flag)
                  dxfReader.method_85();
                continue;
              case 73:
                this.Closed = (short) dxfReader.CurrentGroup.Value != (short) 0;
                goto case 72;
              default:
                flag = false;
                goto case 72;
            }
          }
          while (flag);
          if (vertex == null)
            return;
          this.Vertices.Add(vertex);
        }

        public class Vertex
        {
          private WW.Math.Point2D point2D_0;
          private double double_0;

          public Vertex()
          {
          }

          public Vertex(double x, double y)
          {
            this.point2D_0 = new WW.Math.Point2D(x, y);
          }

          public Vertex(WW.Math.Point2D position)
          {
            this.point2D_0 = position;
          }

          public Vertex(double x, double y, double bulge)
          {
            this.point2D_0 = new WW.Math.Point2D(x, y);
            this.double_0 = bulge;
          }

          public WW.Math.Point2D Position
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

          public double X
          {
            get
            {
              return this.point2D_0.X;
            }
            set
            {
              this.point2D_0.X = value;
            }
          }

          public double Y
          {
            get
            {
              return this.point2D_0.Y;
            }
            set
            {
              this.point2D_0.Y = value;
            }
          }

          public double Bulge
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

          public void TransformMe(Matrix4D transform, CommandGroup undoGroup)
          {
            this.TransformMe(transform, undoGroup, Class749.smethod_5(transform));
          }

          internal void TransformMe(
            Matrix4D transform,
            CommandGroup undoGroup,
            bool flipOrientation)
          {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            DxfHatch.BoundaryPath.Polyline.Vertex.Class401 class401 = new DxfHatch.BoundaryPath.Polyline.Vertex.Class401();
            // ISSUE: reference to a compiler-generated field
            class401.vertex_0 = this;
            // ISSUE: reference to a compiler-generated field
            class401.point2D_0 = this.point2D_0;
            // ISSUE: reference to a compiler-generated field
            class401.double_0 = this.double_0;
            this.point2D_0 = transform.Transform(this.point2D_0);
            if (flipOrientation)
              this.double_0 = -this.double_0;
            if (undoGroup == null)
              return;
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfHatch.BoundaryPath.Polyline.Vertex.Class402()
            {
              class401_0 = class401,
              point2D_0 = this.point2D_0,
              double_0 = this.double_0
            }.method_0), new System.Action(class401.method_0)));
          }

          public bool Equals(DxfHatch.BoundaryPath.Polyline.Vertex other)
          {
            if (this.point2D_0 == other.point2D_0)
              return this.double_0 == other.double_0;
            return false;
          }

          public DxfHatch.BoundaryPath.Polyline.Vertex Clone(CloneContext cloneContext)
          {
            DxfHatch.BoundaryPath.Polyline.Vertex vertex = new DxfHatch.BoundaryPath.Polyline.Vertex();
            vertex.CopyFrom(this, cloneContext);
            return vertex;
          }

          public override string ToString()
          {
            if (this.double_0 == 0.0)
              return this.point2D_0.ToString();
            return string.Format("{0}, bulge={1}", (object) this.point2D_0, (object) this.double_0);
          }

          public void CopyFrom(
            DxfHatch.BoundaryPath.Polyline.Vertex from,
            CloneContext cloneContext)
          {
            this.point2D_0 = from.point2D_0;
            this.double_0 = from.double_0;
          }
        }
      }

      public abstract class Edge
      {
        public abstract void TransformMe(Matrix4D transform, CommandGroup undoGroup);

        public abstract void Accept(DxfHatch.BoundaryPath.IEdgeVisitor visitor);

        public virtual DxfHatch.BoundaryPath.Edge Clone(CloneContext cloneContext)
        {
          throw new DxfException("Edge.Clone not implemented.");
        }

        public virtual bool Validate(DxfModel model, DxfEntity entity, IList<DxfMessage> messages)
        {
          return true;
        }

        internal abstract void vmethod_0(Polyline2D polyline, GraphicsConfig config);
      }

      public class LineEdge : DxfHatch.BoundaryPath.Edge
      {
        private WW.Math.Point2D point2D_0 = WW.Math.Point2D.Zero;
        private WW.Math.Point2D point2D_1 = WW.Math.Point2D.Zero;

        public LineEdge()
        {
        }

        public LineEdge(WW.Math.Point2D start, WW.Math.Point2D end)
        {
          this.point2D_0 = start;
          this.point2D_1 = end;
        }

        public WW.Math.Point2D End
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

        public WW.Math.Point2D Start
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

        public override void TransformMe(Matrix4D transform, CommandGroup undoGroup)
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          DxfHatch.BoundaryPath.LineEdge.Class403 class403 = new DxfHatch.BoundaryPath.LineEdge.Class403();
          // ISSUE: reference to a compiler-generated field
          class403.lineEdge_0 = this;
          // ISSUE: reference to a compiler-generated field
          class403.point2D_0 = this.point2D_0;
          // ISSUE: reference to a compiler-generated field
          class403.point2D_1 = this.point2D_1;
          this.point2D_0 = transform.Transform(this.point2D_0);
          this.point2D_1 = transform.Transform(this.point2D_1);
          if (undoGroup == null)
            return;
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfHatch.BoundaryPath.LineEdge.Class404()
          {
            class403_0 = class403,
            point2D_0 = this.point2D_0,
            point2D_1 = this.point2D_1
          }.method_0), new System.Action(class403.method_0)));
        }

        internal override void vmethod_0(Polyline2D polyline, GraphicsConfig config)
        {
          if (polyline.Count == 0 || !WW.Math.Point2D.AreApproxEqual(polyline[polyline.Count - 1], this.point2D_0, 1E-08))
            polyline.Add(this.point2D_0);
          polyline.Add(this.point2D_1);
        }

        public override DxfHatch.BoundaryPath.Edge Clone(CloneContext cloneContext)
        {
          DxfHatch.BoundaryPath.LineEdge lineEdge = new DxfHatch.BoundaryPath.LineEdge();
          lineEdge.CopyFrom(this, cloneContext);
          return (DxfHatch.BoundaryPath.Edge) lineEdge;
        }

        public override void Accept(DxfHatch.BoundaryPath.IEdgeVisitor visitor)
        {
          visitor.Visit(this);
        }

        public void CopyFrom(DxfHatch.BoundaryPath.LineEdge from, CloneContext cloneContext)
        {
          this.point2D_0 = from.point2D_0;
          this.point2D_1 = from.point2D_1;
        }

        internal void Read(DxfReader r)
        {
          while (true)
          {
            switch (r.CurrentGroup.Code)
            {
              case 10:
                this.point2D_0.X = (double) r.CurrentGroup.Value;
                break;
              case 11:
                this.point2D_1.X = (double) r.CurrentGroup.Value;
                break;
              case 20:
                this.point2D_0.Y = (double) r.CurrentGroup.Value;
                break;
              case 21:
                this.point2D_1.Y = (double) r.CurrentGroup.Value;
                break;
              default:
                goto label_4;
            }
            r.method_85();
          }
label_4:;
        }
      }

      public class ArcEdge : DxfHatch.BoundaryPath.Edge
      {
        private WW.Math.Point2D point2D_0 = WW.Math.Point2D.Zero;
        private double double_0;
        private double double_1;
        private double double_2;
        private bool bool_0;

        public ArcEdge()
        {
        }

        public ArcEdge(
          WW.Math.Point2D center,
          double radius,
          double startAngle,
          double endAngle,
          bool counterClockWise)
        {
          this.point2D_0 = center;
          this.double_0 = radius;
          this.double_1 = startAngle;
          this.double_2 = endAngle;
          this.bool_0 = counterClockWise;
        }

        public WW.Math.Point2D Center
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

        public double EndAngle
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

        public double Radius
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

        public double StartAngle
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

        public bool CounterClockWise
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

        public static DxfHatch.BoundaryPath.ArcEdge CreateCircle(
          WW.Math.Point2D center,
          double radius)
        {
          return new DxfHatch.BoundaryPath.ArcEdge(center, radius, 0.0, 2.0 * System.Math.PI, true);
        }

        public override void TransformMe(Matrix4D transform, CommandGroup undoGroup)
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          DxfHatch.BoundaryPath.ArcEdge.Class405 class405 = new DxfHatch.BoundaryPath.ArcEdge.Class405();
          // ISSUE: reference to a compiler-generated field
          class405.arcEdge_0 = this;
          // ISSUE: reference to a compiler-generated field
          class405.point2D_0 = this.point2D_0;
          // ISSUE: reference to a compiler-generated field
          class405.double_0 = this.double_0;
          // ISSUE: reference to a compiler-generated field
          class405.double_1 = this.double_1;
          // ISSUE: reference to a compiler-generated field
          class405.double_2 = this.double_2;
          // ISSUE: reference to a compiler-generated field
          class405.bool_0 = this.bool_0;
          this.point2D_0 = transform.Transform(this.point2D_0);
          this.double_0 = transform.Transform(new Vector2D(this.double_0, 0.0)).GetLength();
          if (!this.bool_0)
          {
            this.double_1 = -this.double_1;
            this.double_2 = -this.double_2;
          }
          this.double_1 = transform.TransformAngle(this.double_1);
          this.double_2 = transform.TransformAngle(this.double_2);
          this.bool_0 ^= Class749.smethod_5(transform);
          if (!this.bool_0)
          {
            this.double_1 = -this.double_1;
            this.double_2 = -this.double_2;
          }
          if (undoGroup == null)
            return;
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfHatch.BoundaryPath.ArcEdge.Class406()
          {
            class405_0 = class405,
            point2D_0 = this.point2D_0,
            double_0 = this.double_0,
            double_1 = this.double_1,
            double_2 = this.double_2,
            bool_0 = this.bool_0
          }.method_0), new System.Action(class405.method_0)));
        }

        internal override void vmethod_0(Polyline2D polyline, GraphicsConfig config)
        {
          double num1 = 2.0 * System.Math.PI / (double) config.NoOfArcLineSegments * (this.bool_0 ? 1.0 : -1.0);
          double num2 = this.double_1;
          double num3 = this.double_2;
          if (!this.bool_0)
          {
            num2 = -num2;
            num3 = -num3;
          }
          double num4 = num3;
          if (this.bool_0)
          {
            while (num4 <= num2)
              num4 += 2.0 * System.Math.PI;
          }
          else
          {
            while (num4 >= num2)
              num4 -= 2.0 * System.Math.PI;
          }
          double num5 = num2;
          for (int index = System.Math.Sign(num2 - num4); index == System.Math.Sign(num5 - num4); num5 += num1)
          {
            WW.Math.Point2D b = this.point2D_0 + this.double_0 * new Vector2D(System.Math.Cos(num5), System.Math.Sin(num5));
            if (polyline.Count == 0 || !WW.Math.Point2D.AreApproxEqual(polyline[polyline.Count - 1], b, 1E-08))
              polyline.Add(b);
          }
          WW.Math.Point2D b1 = this.point2D_0 + this.double_0 * new Vector2D(System.Math.Cos(num3), System.Math.Sin(num3));
          if (polyline.Count != 0 && WW.Math.Point2D.AreApproxEqual(polyline[polyline.Count - 1], b1, 1E-08))
            return;
          polyline.Add(b1);
        }

        public override DxfHatch.BoundaryPath.Edge Clone(CloneContext cloneContext)
        {
          DxfHatch.BoundaryPath.ArcEdge arcEdge = new DxfHatch.BoundaryPath.ArcEdge();
          arcEdge.CopyFrom(this, cloneContext);
          return (DxfHatch.BoundaryPath.Edge) arcEdge;
        }

        public override void Accept(DxfHatch.BoundaryPath.IEdgeVisitor visitor)
        {
          visitor.Visit(this);
        }

        public void CopyFrom(DxfHatch.BoundaryPath.ArcEdge from, CloneContext cloneContext)
        {
          this.point2D_0 = from.point2D_0;
          this.double_0 = from.double_0;
          this.double_1 = from.double_1;
          this.double_2 = from.double_2;
          this.bool_0 = from.bool_0;
        }

        public void Read(DxfReader r)
        {
          while (true)
          {
            int code = r.CurrentGroup.Code;
            if (code > 20)
            {
              switch (code)
              {
                case 40:
                  this.double_0 = (double) r.CurrentGroup.Value;
                  break;
                case 50:
                  this.double_1 = (double) r.CurrentGroup.Value * (System.Math.PI / 180.0);
                  break;
                case 51:
                  this.double_2 = (double) r.CurrentGroup.Value * (System.Math.PI / 180.0);
                  break;
                case 73:
                  this.bool_0 = (short) r.CurrentGroup.Value != (short) 0;
                  break;
                default:
                  goto label_11;
              }
            }
            else
              goto label_7;
label_6:
            r.method_85();
            continue;
label_7:
            switch (code)
            {
              case 10:
                this.point2D_0.X = (double) r.CurrentGroup.Value;
                goto label_6;
              case 20:
                this.point2D_0.Y = (double) r.CurrentGroup.Value;
                goto label_6;
              default:
                goto label_8;
            }
          }
label_11:
          return;
label_8:;
        }
      }

      public class EllipseEdge : DxfHatch.BoundaryPath.Edge
      {
        private WW.Math.Point2D point2D_0 = WW.Math.Point2D.Zero;
        private Vector2D vector2D_0 = Vector2D.Zero;
        private double double_0 = 1.0;
        private double double_1;
        private double double_2;
        private bool bool_0;

        public WW.Math.Point2D Center
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

        public Vector2D MajorAxisEndPoint
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

        public double EndAngle
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

        public double EndParameter
        {
          get
          {
            return DxfEllipse.AngleToParameter(this.double_2, this.double_0);
          }
          set
          {
            this.double_2 = DxfEllipse.ParameterToAngle(value, this.double_0);
          }
        }

        public WW.Math.Point2D EndPoint
        {
          get
          {
            return this.GetPointAtAngle(this.double_2);
          }
        }

        public double MinorToMajorRatio
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

        public Vector2D MinorAxisEndPoint
        {
          get
          {
            return new Vector2D(-this.vector2D_0.Y, this.vector2D_0.X) * this.double_0;
          }
        }

        public double StartAngle
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

        public double StartParameter
        {
          get
          {
            return DxfEllipse.AngleToParameter(this.double_1, this.double_0);
          }
          set
          {
            this.double_1 = DxfEllipse.ParameterToAngle(value, this.double_0);
          }
        }

        public WW.Math.Point2D StartPoint
        {
          get
          {
            return this.GetPointAtAngle(this.double_1);
          }
        }

        public bool CounterClockWise
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

        public WW.Math.Point2D GetPointAtAngle(double angle)
        {
          double parameter = DxfEllipse.AngleToParameter(angle, this.double_0);
          return this.point2D_0 + System.Math.Cos(parameter) * this.vector2D_0 + System.Math.Sin(parameter) * this.MinorAxisEndPoint;
        }

        public WW.Math.Point2D GetPointAtParameter(double parameter)
        {
          return this.point2D_0 + System.Math.Cos(parameter) * this.vector2D_0 + System.Math.Sin(parameter) * this.MinorAxisEndPoint;
        }

        public override void TransformMe(Matrix4D transform, CommandGroup undoGroup)
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          DxfHatch.BoundaryPath.EllipseEdge.Class407 class407 = new DxfHatch.BoundaryPath.EllipseEdge.Class407();
          // ISSUE: reference to a compiler-generated field
          class407.ellipseEdge_0 = this;
          // ISSUE: reference to a compiler-generated field
          class407.point2D_0 = this.point2D_0;
          // ISSUE: reference to a compiler-generated field
          class407.vector2D_0 = this.vector2D_0;
          // ISSUE: reference to a compiler-generated field
          class407.bool_0 = this.bool_0;
          this.point2D_0 = transform.Transform(this.point2D_0);
          this.vector2D_0 = transform.Transform(this.vector2D_0);
          this.bool_0 ^= Vector3D.CrossProduct(new Vector3D(transform.M00, transform.M01, transform.M02), new Vector3D(transform.M10, transform.M11, transform.M12)).Z < 0.0;
          if (undoGroup == null)
            return;
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfHatch.BoundaryPath.EllipseEdge.Class408()
          {
            class407_0 = class407,
            point2D_0 = this.point2D_0,
            vector2D_0 = this.vector2D_0,
            bool_0 = this.bool_0
          }.method_0), new System.Action(class407.method_0)));
        }

        internal override void vmethod_0(Polyline2D polyline, GraphicsConfig config)
        {
          double num1 = 2.0 * System.Math.PI / (double) config.NoOfArcLineSegments * (this.bool_0 ? 1.0 : -1.0);
          double angle1 = this.double_1;
          double angle2 = this.EndAngle;
          if (!this.bool_0)
          {
            angle1 = -angle1;
            angle2 = -angle2;
          }
          double parameter1 = DxfEllipse.AngleToParameter(angle1, this.double_0);
          double parameter2 = DxfEllipse.AngleToParameter(angle2, this.double_0);
          double num2 = parameter2;
          if (this.bool_0)
          {
            while (num2 <= parameter1)
              num2 += 2.0 * System.Math.PI;
          }
          else
          {
            while (num2 >= parameter1)
              num2 -= 2.0 * System.Math.PI;
          }
          Vector2D vector2D0 = this.vector2D_0;
          vector2D0.Normalize();
          Vector2D vector2D1 = new Vector2D(-vector2D0.Y, vector2D0.X);
          double length = this.vector2D_0.GetLength();
          double num3 = this.double_0 * length;
          Vector2D vector2D2 = vector2D0 * length;
          Vector2D vector2D3 = vector2D1 * num3;
          double num4 = parameter1;
          for (int index = System.Math.Sign(parameter1 - num2); index == System.Math.Sign(num4 - num2); num4 += num1)
          {
            WW.Math.Point2D b = this.point2D_0 + System.Math.Cos(num4) * vector2D2 + System.Math.Sin(num4) * vector2D3;
            if (polyline.Count == 0 || !WW.Math.Point2D.AreApproxEqual(polyline[polyline.Count - 1], b, 1E-08))
              polyline.Add(b);
          }
          WW.Math.Point2D b1 = this.point2D_0 + System.Math.Cos(parameter2) * vector2D2 + System.Math.Sin(parameter2) * vector2D3;
          if (polyline.Count != 0 && WW.Math.Point2D.AreApproxEqual(polyline[polyline.Count - 1], b1, 1E-08))
            return;
          polyline.Add(b1);
        }

        public override DxfHatch.BoundaryPath.Edge Clone(CloneContext cloneContext)
        {
          DxfHatch.BoundaryPath.EllipseEdge ellipseEdge = new DxfHatch.BoundaryPath.EllipseEdge();
          ellipseEdge.CopyFrom(this, cloneContext);
          return (DxfHatch.BoundaryPath.Edge) ellipseEdge;
        }

        public override void Accept(DxfHatch.BoundaryPath.IEdgeVisitor visitor)
        {
          visitor.Visit(this);
        }

        public void CopyFrom(DxfHatch.BoundaryPath.EllipseEdge from, CloneContext cloneContext)
        {
          this.point2D_0 = from.point2D_0;
          this.vector2D_0 = from.vector2D_0;
          this.double_0 = from.double_0;
          this.double_1 = from.double_1;
          this.double_2 = from.double_2;
          this.bool_0 = from.bool_0;
        }

        internal void Read(DxfReader r)
        {
          while (true)
          {
            int code = r.CurrentGroup.Code;
            if (code > 21)
            {
              switch (code)
              {
                case 40:
                  this.double_0 = (double) r.CurrentGroup.Value;
                  break;
                case 50:
                  this.double_1 = (double) r.CurrentGroup.Value * (System.Math.PI / 180.0);
                  break;
                case 51:
                  this.double_2 = (double) r.CurrentGroup.Value * (System.Math.PI / 180.0);
                  break;
                case 73:
                  this.bool_0 = (short) r.CurrentGroup.Value != (short) 0;
                  break;
                default:
                  goto label_13;
              }
            }
            else
              goto label_7;
label_6:
            r.method_85();
            continue;
label_7:
            switch (code)
            {
              case 10:
                this.point2D_0.X = (double) r.CurrentGroup.Value;
                goto label_6;
              case 11:
                this.vector2D_0.X = (double) r.CurrentGroup.Value;
                goto label_6;
              case 20:
                this.point2D_0.Y = (double) r.CurrentGroup.Value;
                goto label_6;
              case 21:
                this.vector2D_0.Y = (double) r.CurrentGroup.Value;
                goto label_6;
              default:
                goto label_8;
            }
          }
label_13:
          return;
label_8:;
        }
      }

      public class SplineEdge : DxfHatch.BoundaryPath.Edge
      {
        private readonly List<WW.Math.Point2D> list_0 = new List<WW.Math.Point2D>();
        private readonly List<double> list_1 = new List<double>();
        private readonly List<double> list_2 = new List<double>();
        private int int_0;
        private bool bool_0;
        private bool bool_1;
        private DxfHatch.FitPointData fitPointData_0;

        public List<WW.Math.Point2D> ControlPoints
        {
          get
          {
            return this.list_0;
          }
        }

        public int Degree
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

        public List<double> Knots
        {
          get
          {
            return this.list_1;
          }
        }

        public bool Periodic
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

        public bool Rational
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

        public List<double> Weights
        {
          get
          {
            return this.list_2;
          }
        }

        public DxfHatch.FitPointData FitPointData
        {
          get
          {
            return this.fitPointData_0;
          }
          set
          {
            this.fitPointData_0 = value;
          }
        }

        public int ExpectedKnotCount
        {
          get
          {
            return BSplineD.GetExpectedKnotCount(this.list_0.Count, this.int_0);
          }
        }

        public bool KnotsValid
        {
          get
          {
            return this.list_1.Count == this.ExpectedKnotCount;
          }
        }

        public bool WeightsValid
        {
          get
          {
            if (this.Rational)
              return this.list_2.Count == this.list_0.Count;
            if (this.list_2.Count != this.list_0.Count)
              return this.list_2.Count == 0;
            return true;
          }
        }

        public override void TransformMe(Matrix4D transform, CommandGroup undoGroup)
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          DxfHatch.BoundaryPath.SplineEdge.Class409 class409 = new DxfHatch.BoundaryPath.SplineEdge.Class409();
          // ISSUE: reference to a compiler-generated field
          class409.splineEdge_0 = this;
          // ISSUE: reference to a compiler-generated field
          class409.point2D_0 = new WW.Math.Point2D[this.list_0.Count];
          for (int index = this.list_0.Count - 1; index >= 0; --index)
          {
            WW.Math.Point2D point = this.list_0[index];
            // ISSUE: reference to a compiler-generated field
            class409.point2D_0[index] = point;
            this.list_0[index] = transform.Transform(point);
          }
          if (undoGroup != null)
          {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            DxfHatch.BoundaryPath.SplineEdge.Class410 class410 = new DxfHatch.BoundaryPath.SplineEdge.Class410();
            // ISSUE: reference to a compiler-generated field
            class410.class409_0 = class409;
            // ISSUE: reference to a compiler-generated field
            class410.point2D_0 = new WW.Math.Point2D[this.list_0.Count];
            for (int index = this.list_0.Count - 1; index >= 0; --index)
            {
              WW.Math.Point2D point2D = this.list_0[index];
              // ISSUE: reference to a compiler-generated field
              class410.point2D_0[index] = point2D;
            }
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(class410.method_0), new System.Action(class409.method_0)));
          }
          if (this.fitPointData_0 == null)
            return;
          this.fitPointData_0.TransformMe(transform, undoGroup);
        }

        internal override void vmethod_0(Polyline2D polyline, GraphicsConfig config)
        {
          if (this.list_1.Count > 0 && this.list_1.Count < this.int_0 + 1 << 1)
            return;
          bool bool1 = this.bool_1;
          BSplineD bsplineD = this.list_1.Count != 0 ? new BSplineD(this.int_0, (IList<double>) this.list_1) : new BSplineD(this.int_0, this.list_0.Count, bool1);
          double[] result = new double[this.int_0 + 1];
          double[] weights;
          if (this.list_2.Count == 0)
          {
            weights = new double[this.list_0.Count];
            for (int index = 0; index < this.list_0.Count; ++index)
              weights[index] = 1.0;
          }
          else
            weights = this.list_2.ToArray();
          double minU = bsplineD.MinU;
          double maxU = bsplineD.MaxU;
          int num1 = this.list_0.Count * (int) config.NoOfSplineLineSegments + 1;
          double num2 = (maxU - minU) / (double) (num1 - 1);
          int num3 = 0;
          double u = minU;
          while (num3 < num1)
          {
            int knotSpanIndex = bsplineD.GetKnotSpanIndex(u);
            if (this.bool_0)
              bsplineD.EvaluateRationalBasisFunctions(knotSpanIndex, u, weights, result);
            else
              bsplineD.EvaluateBasisFunctions(knotSpanIndex, u, result);
            WW.Math.Point2D zero = WW.Math.Point2D.Zero;
            for (int index = 0; index < this.int_0 + 1; ++index)
            {
              Vector2D vector2D = (Vector2D) this.list_0[(knotSpanIndex - this.int_0 + index) % this.list_0.Count];
              zero += result[index] * vector2D;
            }
            if (polyline.Count == 0 || !WW.Math.Point2D.AreApproxEqual(polyline[polyline.Count - 1], zero, 1E-08))
              polyline.Add(zero);
            ++num3;
            u += num2;
          }
        }

        public override DxfHatch.BoundaryPath.Edge Clone(CloneContext cloneContext)
        {
          DxfHatch.BoundaryPath.SplineEdge splineEdge = new DxfHatch.BoundaryPath.SplineEdge();
          splineEdge.CopyFrom(this, cloneContext);
          return (DxfHatch.BoundaryPath.Edge) splineEdge;
        }

        public override void Accept(DxfHatch.BoundaryPath.IEdgeVisitor visitor)
        {
          visitor.Visit(this);
        }

        public override bool Validate(DxfModel model, DxfEntity entity, IList<DxfMessage> messages)
        {
          bool flag = true;
          if (!this.KnotsValid)
            messages.Add(new DxfMessage(DxfStatus.InvalidSplineKnots, Severity.Warning)
            {
              Parameters = {
                {
                  "Entity",
                  (object) entity
                },
                {
                  "Target",
                  (object) this
                },
                {
                  "Knots",
                  (object) this.list_1
                }
              }
            });
          if (!this.WeightsValid)
          {
            messages.Add(new DxfMessage(DxfStatus.InvalidSplineWeights, Severity.Error)
            {
              Parameters = {
                {
                  "Entity",
                  (object) entity
                },
                {
                  "Target",
                  (object) this
                },
                {
                  "Weights",
                  (object) this.list_2
                }
              }
            });
            flag = false;
          }
          return flag;
        }

        public void CopyFrom(DxfHatch.BoundaryPath.SplineEdge from, CloneContext cloneContext)
        {
          this.int_0 = from.int_0;
          this.bool_0 = from.bool_0;
          this.bool_1 = from.bool_1;
          this.list_0.AddRange((IEnumerable<WW.Math.Point2D>) from.list_0);
          this.list_1.AddRange((IEnumerable<double>) from.list_1);
          this.list_2.AddRange((IEnumerable<double>) from.list_2);
          if (from.fitPointData_0 == null)
            this.fitPointData_0 = (DxfHatch.FitPointData) null;
          else if (this.fitPointData_0 == null)
            this.fitPointData_0 = from.fitPointData_0.Clone();
          else
            this.fitPointData_0.CopyFrom(from.fitPointData_0);
        }

        public void Read(DxfReader r)
        {
          WW.Math.Point2D point2D1 = WW.Math.Point2D.Zero;
          WW.Math.Point2D? nullable = new WW.Math.Point2D?();
          WW.Math.Point2D point2D2;
          while (true)
          {
            switch (r.CurrentGroup.Code)
            {
              case 10:
                point2D2 = nullable ?? WW.Math.Point2D.Zero;
                point2D2.X = (double) r.CurrentGroup.Value;
                nullable = new WW.Math.Point2D?(point2D2);
                goto case 95;
              case 11:
                point2D1 = new WW.Math.Point2D((double) r.CurrentGroup.Value, 0.0);
                goto case 95;
              case 12:
                if (this.fitPointData_0 == null)
                  this.fitPointData_0 = new DxfHatch.FitPointData();
                this.fitPointData_0.StartTangent = new Vector2D((double) r.CurrentGroup.Value, this.fitPointData_0.StartTangent.Y);
                goto case 95;
              case 13:
                if (this.fitPointData_0 == null)
                  this.fitPointData_0 = new DxfHatch.FitPointData();
                this.fitPointData_0.EndTangent = new Vector2D((double) r.CurrentGroup.Value, this.fitPointData_0.StartTangent.Y);
                goto case 95;
              case 14:
                goto label_31;
              case 15:
                goto label_8;
              case 16:
                goto label_1;
              case 17:
                goto label_32;
              case 18:
                goto label_33;
              case 19:
                goto label_34;
              case 20:
                point2D2 = nullable ?? WW.Math.Point2D.Zero;
                point2D2.Y = (double) r.CurrentGroup.Value;
                this.list_0.Add(point2D2);
                nullable = new WW.Math.Point2D?();
                goto case 95;
              case 21:
                if (this.fitPointData_0 == null)
                  this.fitPointData_0 = new DxfHatch.FitPointData();
                point2D1.Y = (double) r.CurrentGroup.Value;
                this.fitPointData_0.FitPoints.Add(point2D1);
                goto case 95;
              case 22:
                if (this.fitPointData_0 == null)
                  this.fitPointData_0 = new DxfHatch.FitPointData();
                this.fitPointData_0.StartTangent = new Vector2D(this.fitPointData_0.StartTangent.X, (double) r.CurrentGroup.Value);
                goto case 95;
              case 23:
                if (this.fitPointData_0 == null)
                  this.fitPointData_0 = new DxfHatch.FitPointData();
                this.fitPointData_0.EndTangent = new Vector2D(this.fitPointData_0.StartTangent.X, (double) r.CurrentGroup.Value);
                goto case 95;
              case 40:
                this.list_1.Add((double) r.CurrentGroup.Value);
                goto case 95;
              case 41:
                goto label_35;
              case 42:
                this.list_2.Add((double) r.CurrentGroup.Value);
                goto case 95;
              case 73:
                this.bool_0 = (short) r.CurrentGroup.Value != (short) 0;
                goto case 95;
              case 74:
                this.bool_1 = (short) r.CurrentGroup.Value != (short) 0;
                goto case 95;
              case 94:
                this.int_0 = (int) r.CurrentGroup.Value;
                goto case 95;
              case 95:
              case 96:
                r.method_85();
                continue;
              case 97:
                if ((int) r.CurrentGroup.Value > 0 && this.fitPointData_0 == null)
                {
                  this.fitPointData_0 = new DxfHatch.FitPointData();
                  goto case 95;
                }
                else
                  goto case 95;
              default:
                goto label_30;
            }
          }
label_31:
          return;
label_8:
          return;
label_1:
          return;
label_32:
          return;
label_33:
          return;
label_34:
          return;
label_35:
          return;
label_30:;
        }
      }

      public interface IEdgeVisitor
      {
        void Visit(DxfHatch.BoundaryPath.LineEdge edge);

        void Visit(DxfHatch.BoundaryPath.ArcEdge edge);

        void Visit(DxfHatch.BoundaryPath.EllipseEdge edge);

        void Visit(DxfHatch.BoundaryPath.SplineEdge edge);
      }

      public class CloneBuilder : ICloneBuilder
      {
        private readonly DxfEntityCollection dxfEntityCollection_0 = new DxfEntityCollection();
        private DxfHatch.BoundaryPath boundaryPath_0;

        public DxfHatch.BoundaryPath ClonedBoundaryPath
        {
          get
          {
            return this.boundaryPath_0;
          }
          set
          {
            this.boundaryPath_0 = value;
          }
        }

        public DxfEntityCollection OriginalBoundaryObjects
        {
          get
          {
            return this.dxfEntityCollection_0;
          }
        }

        public void ResolveReferences(CloneContext context)
        {
          foreach (DxfEntity dxfEntity1 in (DxfHandledObjectCollection<DxfEntity>) this.dxfEntityCollection_0)
          {
            IGraphCloneable graphCloneable;
            if (dxfEntity1 != null && context.SourceToClonedObject.TryGetValue((IGraphCloneable) dxfEntity1, out graphCloneable))
            {
              DxfEntity dxfEntity2 = graphCloneable as DxfEntity;
              if (dxfEntity2 != null)
                this.boundaryPath_0.BoundaryObjects.Add(dxfEntity2);
            }
          }
        }
      }
    }

    public class FitPointData
    {
      private List<WW.Math.Point2D> list_0 = new List<WW.Math.Point2D>();
      private Vector2D vector2D_0;
      private Vector2D vector2D_1;

      public List<WW.Math.Point2D> FitPoints
      {
        get
        {
          return this.list_0;
        }
      }

      public Vector2D StartTangent
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

      public Vector2D EndTangent
      {
        get
        {
          return this.vector2D_1;
        }
        set
        {
          this.vector2D_1 = value;
        }
      }

      public void TransformMe(Matrix4D transform, CommandGroup undoGroup)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfHatch.FitPointData.Class411 class411 = new DxfHatch.FitPointData.Class411();
        // ISSUE: reference to a compiler-generated field
        class411.fitPointData_0 = this;
        // ISSUE: reference to a compiler-generated field
        class411.point2D_0 = new WW.Math.Point2D[this.list_0.Count];
        // ISSUE: reference to a compiler-generated field
        class411.vector2D_0 = this.vector2D_0;
        // ISSUE: reference to a compiler-generated field
        class411.vector2D_1 = this.vector2D_1;
        for (int index = this.list_0.Count - 1; index >= 0; --index)
        {
          WW.Math.Point2D point = this.list_0[index];
          // ISSUE: reference to a compiler-generated field
          class411.point2D_0[index] = point;
          this.list_0[index] = transform.Transform(point);
        }
        this.vector2D_0 = transform.Transform(this.vector2D_0);
        this.vector2D_1 = transform.Transform(this.vector2D_1);
        if (undoGroup == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfHatch.FitPointData.Class412 class412 = new DxfHatch.FitPointData.Class412();
        // ISSUE: reference to a compiler-generated field
        class412.class411_0 = class411;
        // ISSUE: reference to a compiler-generated field
        class412.point2D_0 = new WW.Math.Point2D[this.list_0.Count];
        for (int index = this.list_0.Count - 1; index >= 0; --index)
        {
          WW.Math.Point2D point2D = this.list_0[index];
          // ISSUE: reference to a compiler-generated field
          class412.point2D_0[index] = point2D;
        }
        // ISSUE: reference to a compiler-generated field
        class412.vector2D_0 = this.vector2D_0;
        // ISSUE: reference to a compiler-generated field
        class412.vector2D_1 = this.vector2D_1;
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(class412.method_0), new System.Action(class411.method_0)));
      }

      public DxfHatch.FitPointData Clone()
      {
        DxfHatch.FitPointData fitPointData = new DxfHatch.FitPointData();
        fitPointData.CopyFrom(this);
        return fitPointData;
      }

      public void CopyFrom(DxfHatch.FitPointData from)
      {
        this.list_0.AddRange((IEnumerable<WW.Math.Point2D>) from.list_0);
        this.vector2D_0 = from.vector2D_0;
        this.vector2D_1 = from.vector2D_1;
      }
    }
  }
}
