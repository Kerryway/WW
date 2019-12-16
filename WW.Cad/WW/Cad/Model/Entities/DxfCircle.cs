// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfCircle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns1;
using ns28;
using ns33;
using ns43;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WW.Actions;
using WW.Cad.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;
using WW.Windows.Forms;

namespace WW.Cad.Model.Entities
{
  public class DxfCircle : DxfEntity, IClipBoundaryProvider, IControlPointCollection
  {
    private static readonly IControlPoint[] icontrolPoint_0 = new IControlPoint[5]{ DxfCircle.CenterControlPoint.Instance, DxfCircle.ControlPoint1.Instance, DxfCircle.ControlPoint2.Instance, DxfCircle.ControlPoint3.Instance, DxfCircle.ControlPoint4.Instance };
    private Vector3D vector3D_0 = Vector3D.ZAxis;
    private WW.Math.Point3D point3D_0;
    private double double_1;
    private double double_2;

    public DxfCircle()
    {
    }

    public DxfCircle(WW.Math.Point3D center, double radius)
    {
      this.point3D_0 = center;
      this.double_1 = radius;
    }

    public DxfCircle(EntityColor color, WW.Math.Point3D center, double radius)
    {
      this.Color = color;
      this.point3D_0 = center;
      this.double_1 = radius;
    }

    public DxfCircle(WW.Math.Point2D center, double radius)
    {
      this.point3D_0 = (WW.Math.Point3D) center;
      this.double_1 = radius;
    }

    public DxfCircle(EntityColor color, WW.Math.Point2D center, double radius)
    {
      this.Color = color;
      this.point3D_0 = (WW.Math.Point3D) center;
      this.double_1 = radius;
    }

    public WW.Math.Point3D Center
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

    public double Radius
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

    public double Thickness
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

    public override string EntityType
    {
      get
      {
        return "CIRCLE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbCircle";
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
      Matrix4D transformationWithOcs;
      this.method_13(matrix, undoGroup, out transformationWithOcs);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      this.DrawInternal(context, graphicsFactory, 0.0, 2.0 * System.Math.PI);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      this.DrawInternal(context, graphicsFactory, 0.0, 2.0 * System.Math.PI);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      this.DrawInternal(context, graphicsFactory, 0.0, 2.0 * System.Math.PI);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      WW.Cad.Drawing.Surface.Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      this.DrawInternal(context, graphics, parentGraphicElementBlock, 0.0, 2.0 * System.Math.PI);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfCircle dxfCircle = (DxfCircle) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfCircle == null)
      {
        dxfCircle = new DxfCircle();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfCircle);
        dxfCircle.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfCircle;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    protected void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory,
      double startAngle,
      double endAngle)
    {
      IList<Polyline4D> polylines4D;
      IList<FlatShape4D> shapes;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), startAngle, endAngle, out polylines4D, out shapes);
      if (polylines4D.Count > 0)
        graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, polylines4D, false, true);
      if (shapes == null)
        return;
      Class940.smethod_23((IPathDrawer) new ns0.Class0((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    protected void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory,
      double startAngle,
      double endAngle)
    {
      IList<Polyline4D> polylines4D;
      IList<FlatShape4D> shapes;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), startAngle, endAngle, out polylines4D, out shapes);
      if (polylines4D.Count > 0)
        Class940.smethod_3((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, false, true, polylines4D);
      if (shapes == null)
        return;
      Class940.smethod_23((IPathDrawer) new Class396((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    protected void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory,
      double startAngle,
      double endAngle)
    {
      graphicsFactory.SetColor(context.GetPlotColor((DxfEntity) this));
      IList<WW.Math.Geometry.Polyline3D> polylines;
      IList<FlatShape4D> shapes;
      this.GetPolylines((DrawContext) context, context.GetTransformer().LineTypeScaler, startAngle, endAngle, out polylines, out shapes);
      if (this.Thickness != 0.0)
        Class940.Extrude((DxfEntity) this, context, graphicsFactory, polylines, false, this.Thickness * this.ZAxis);
      else
        Class940.smethod_16((DxfEntity) this, context, graphicsFactory, polylines, false);
      if (shapes == null)
        return;
      Class940.smethod_24((IPathDrawer) new Class473((DxfEntity) this, context, graphicsFactory), (IEnumerable<FlatShape4D>) shapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this), this.Thickness);
    }

    protected void DrawInternal(
      DrawContext.Surface context,
      WW.Cad.Drawing.Surface.Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock,
      double startAngle,
      double endAngle)
    {
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      DxfLineType lineType = this.GetLineType((DrawContext) context);
      double lineTypeScale = context.TotalLineTypeScale * this.LineTypeScale;
      if (!graphics.AddExistingGraphicElement2(parentGraphicElementBlock, (DxfEntity) this, plotColor, lineType, lineTypeScale, false))
        return;
      GraphicElement2 graphicElement2 = new GraphicElement2(plotColor, lineType, lineTypeScale, true);
      graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, (GraphicElement1) graphicElement2);
      if (this.double_2 != 0.0)
        graphicElement2.Geometry.Extrusion = this.double_2 * this.vector3D_0;
      WW.Math.Geometry.Polyline3D polyline = this.method_14(context.Config, startAngle, endAngle);
      graphicElement2.Geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive(polyline));
    }

    public override Matrix4D Transform
    {
      get
      {
        return DxfUtil.GetToWCSTransform(this.ZAxis);
      }
    }

    protected Matrix4D DenormalizationTransform
    {
      get
      {
        return this.Transform * Transformation4D.Translation((Vector3D) this.Center) * Transformation4D.Scaling(this.Radius, this.Radius, this.Radius);
      }
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfCircle dxfCircle = (DxfCircle) from;
      this.point3D_0 = dxfCircle.point3D_0;
      this.double_1 = dxfCircle.double_1;
      this.vector3D_0 = dxfCircle.vector3D_0;
      this.double_2 = dxfCircle.double_2;
    }

    public override IControlPointCollection InteractionControlPoints
    {
      get
      {
        return (IControlPointCollection) this;
      }
    }

    public override DxfEntity.Interactor CreateCreateInteractor(Transaction transaction)
    {
      return (DxfEntity.Interactor) new DxfCircle.Class13((DxfEntity) this, (ITransaction) transaction);
    }

    public override DxfEntity.Interactor CreateEditInteractor()
    {
      return (DxfEntity.Interactor) new DxfCircle.Class10((DxfEntity) this);
    }

    internal void method_13(
      Matrix4D matrix,
      CommandGroup undoGroup,
      out Matrix4D transformationWithOcs)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfCircle.Class538 class538 = new DxfCircle.Class538();
      // ISSUE: reference to a compiler-generated field
      class538.dxfCircle_0 = this;
      // ISSUE: reference to a compiler-generated field
      class538.point3D_0 = this.point3D_0;
      // ISSUE: reference to a compiler-generated field
      class538.double_0 = this.double_1;
      // ISSUE: reference to a compiler-generated field
      class538.vector3D_0 = this.vector3D_0;
      // ISSUE: reference to a compiler-generated field
      class538.double_1 = this.double_2;
      this.vector3D_0 = matrix.Transform(this.vector3D_0);
      this.double_2 *= this.vector3D_0.GetLength();
      this.vector3D_0.Normalize();
      Matrix4D inverse = DxfUtil.GetToWCSTransform(this.vector3D_0).GetInverse();
      // ISSUE: reference to a compiler-generated field
      Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(class538.vector3D_0);
      transformationWithOcs = inverse * matrix * toWcsTransform;
      this.point3D_0 = transformationWithOcs.Transform(this.point3D_0);
      // ISSUE: reference to a compiler-generated field
      this.double_1 = (this.point3D_0 - transformationWithOcs.Transform(class538.point3D_0 + this.double_1 * Vector3D.XAxis)).GetLength();
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new WW.Actions.Command((object) this, new System.Action(new DxfCircle.Class539()
      {
        class538_0 = class538,
        point3D_0 = this.point3D_0,
        double_0 = this.double_1,
        vector3D_0 = this.vector3D_0,
        double_1 = this.double_2
      }.method_0), new System.Action(class538.method_0)));
    }

    internal override void Repair(DxfModelRepairer repairer)
    {
      base.Repair(repairer);
      repairer.method_1((DxfHandledObject) this, "Center", ref this.point3D_0);
      repairer.method_3((DxfHandledObject) this, "Radius", ref this.double_1);
      repairer.method_6((DxfHandledObject) this, "ZAxis", ref this.vector3D_0);
      repairer.method_3((DxfHandledObject) this, "Thickness", ref this.double_2);
    }

    internal override short vmethod_6(Class432 w)
    {
      return 18;
    }

    private void GetPolylines4D(
      DrawContext context,
      IClippingTransformer transformer,
      double startAngle,
      double endAngle,
      out IList<Polyline4D> polylines4D,
      out IList<FlatShape4D> shapes)
    {
      IList<WW.Math.Geometry.Polyline3D> polylines;
      this.GetPolylines(context, transformer.LineTypeScaler, startAngle, endAngle, out polylines, out shapes);
      if (this.Thickness != 0.0)
        DxfUtil.Extrude(polylines, this.Thickness, this.ZAxis);
      polylines4D = DxfUtil.smethod_36(polylines, false, transformer);
    }

    private void GetPolylines(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      double startAngle,
      double endAngle,
      out IList<WW.Math.Geometry.Polyline3D> polylines,
      out IList<FlatShape4D> shapes)
    {
      WW.Math.Geometry.Polyline3D polyline = this.method_14(context.Config, startAngle, endAngle);
      polylines = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>();
      if (context.Config.ApplyLineType)
      {
        shapes = (IList<FlatShape4D>) new List<FlatShape4D>();
        DxfUtil.smethod_4(context.Config, polylines, shapes, polyline, this.GetLineType(context), this.vector3D_0, context.TotalLineTypeScale * this.LineTypeScale, lineTypeScaler);
        if (shapes.Count != 0)
          return;
        shapes = (IList<FlatShape4D>) null;
      }
      else
      {
        polylines.Add(polyline);
        shapes = (IList<FlatShape4D>) null;
      }
    }

    private WW.Math.Geometry.Polyline3D method_14(
      GraphicsConfig graphicsConfig,
      double startAngle,
      double endAngle)
    {
      double num1 = 2.0 * System.Math.PI / (double) graphicsConfig.NoOfArcLineSegments;
      double num2 = startAngle;
      Matrix4D denormalizationTransform = this.DenormalizationTransform;
      WW.Math.Geometry.Polyline3D polyline3D = new WW.Math.Geometry.Polyline3D();
      if ((endAngle - num2) / num1 < (double) graphicsConfig.NoOfArcLineSegmentsMinimum)
      {
        double lineSegmentsMinimum = (double) graphicsConfig.NoOfArcLineSegmentsMinimum;
        double a = (endAngle - num2) / lineSegmentsMinimum;
        if (!MathUtil.AreApproxEqual(a, 0.0))
          num1 = a;
      }
      for (; num2 <= endAngle; num2 += num1)
      {
        WW.Math.Point2D point = new WW.Math.Point2D(System.Math.Cos(num2), System.Math.Sin(num2));
        polyline3D.Add(denormalizationTransform.TransformTo3D4x3(point));
      }
      polyline3D.Add(denormalizationTransform.TransformTo3D4x3(new WW.Math.Point2D(System.Math.Cos(endAngle), System.Math.Sin(endAngle))));
      return polyline3D;
    }

    void IControlPointCollection.Set(int index, WW.Math.Point3D value)
    {
      DxfCircle.icontrolPoint_0[index].SetValue((object) this, value);
    }

    WW.Math.Point3D IControlPointCollection.Get(int index)
    {
      return DxfCircle.icontrolPoint_0[index].GetValue((object) this);
    }

    string IControlPointCollection.GetDescription(int index)
    {
      return DxfCircle.icontrolPoint_0[index].Description;
    }

    PointDisplayType IControlPointCollection.GetDisplayType(
      int index)
    {
      return DxfCircle.icontrolPoint_0[index].DisplayType;
    }

    int IControlPointCollection.Count
    {
      get
      {
        return DxfCircle.icontrolPoint_0.Length;
      }
    }

    bool IControlPointCollection.IsCountFixed
    {
      get
      {
        return true;
      }
    }

    void IControlPointCollection.Insert(int index)
    {
      throw new NotSupportedException();
    }

    void IControlPointCollection.RemoveAt(int index)
    {
      throw new NotSupportedException();
    }

    public IList<Polygon2D> GetClipBoundary(GraphicsConfig graphicsConfig)
    {
      if (this.double_1 == 0.0)
        return (IList<Polygon2D>) new Polygon2D[0];
      WW.Math.Geometry.Polyline3D polyline3D = this.method_14(graphicsConfig, 0.0, 2.0 * System.Math.PI);
      Polygon2D polygon2D = new Polygon2D(polyline3D.Count);
      foreach (WW.Math.Point3D point3D in (List<WW.Math.Point3D>) polyline3D)
        polygon2D.Add((WW.Math.Point2D) point3D);
      return (IList<Polygon2D>) new Polygon2D[1]{ polygon2D };
    }

    protected class CenterControlPoint : IControlPoint
    {
      public static readonly IControlPoint Instance = (IControlPoint) new DxfCircle.CenterControlPoint();

      private CenterControlPoint()
      {
      }

      public void SetValue(object owner, WW.Math.Point3D value)
      {
        ((DxfCircle) owner).point3D_0 = value;
      }

      public WW.Math.Point3D GetValue(object owner)
      {
        return ((DxfCircle) owner).point3D_0;
      }

      public string Description
      {
        get
        {
          return Class881.DxfCircle_CenterControlPoint_Name;
        }
      }

      public PointDisplayType DisplayType
      {
        get
        {
          return PointDisplayType.Default;
        }
      }
    }

    protected class ControlPoint1 : IControlPoint
    {
      public static readonly IControlPoint Instance = (IControlPoint) new DxfCircle.ControlPoint1();

      private ControlPoint1()
      {
      }

      public void SetValue(object owner, WW.Math.Point3D value)
      {
        DxfCircle dxfCircle = (DxfCircle) owner;
        Vector3D vector3D = value - dxfCircle.point3D_0;
        vector3D.Z = 0.0;
        dxfCircle.double_1 = vector3D.GetLength();
      }

      public WW.Math.Point3D GetValue(object owner)
      {
        DxfCircle dxfCircle = (DxfCircle) owner;
        return dxfCircle.point3D_0 + new Vector3D(dxfCircle.double_1, 0.0, 0.0);
      }

      public string Description
      {
        get
        {
          return Class881.DxfCircle_ControlPoint1_Name;
        }
      }

      public PointDisplayType DisplayType
      {
        get
        {
          return PointDisplayType.Default;
        }
      }
    }

    protected class ControlPoint2 : IControlPoint
    {
      public static readonly IControlPoint Instance = (IControlPoint) new DxfCircle.ControlPoint2();

      private ControlPoint2()
      {
      }

      public void SetValue(object owner, WW.Math.Point3D value)
      {
        DxfCircle dxfCircle = (DxfCircle) owner;
        Vector3D vector3D = value - dxfCircle.point3D_0;
        vector3D.Z = 0.0;
        dxfCircle.double_1 = vector3D.GetLength();
      }

      public WW.Math.Point3D GetValue(object owner)
      {
        DxfCircle dxfCircle = (DxfCircle) owner;
        return dxfCircle.point3D_0 + new Vector3D(0.0, dxfCircle.double_1, 0.0);
      }

      public string Description
      {
        get
        {
          return Class881.DxfCircle_ControlPoint1_Name;
        }
      }

      public PointDisplayType DisplayType
      {
        get
        {
          return PointDisplayType.Default;
        }
      }
    }

    protected class ControlPoint3 : IControlPoint
    {
      public static readonly IControlPoint Instance = (IControlPoint) new DxfCircle.ControlPoint3();

      private ControlPoint3()
      {
      }

      public void SetValue(object owner, WW.Math.Point3D value)
      {
        DxfCircle dxfCircle = (DxfCircle) owner;
        Vector3D vector3D = value - dxfCircle.point3D_0;
        vector3D.Z = 0.0;
        dxfCircle.double_1 = vector3D.GetLength();
      }

      public WW.Math.Point3D GetValue(object owner)
      {
        DxfCircle dxfCircle = (DxfCircle) owner;
        return dxfCircle.point3D_0 + new Vector3D(-dxfCircle.double_1, 0.0, 0.0);
      }

      public string Description
      {
        get
        {
          return Class881.DxfCircle_ControlPoint1_Name;
        }
      }

      public PointDisplayType DisplayType
      {
        get
        {
          return PointDisplayType.Default;
        }
      }
    }

    protected class ControlPoint4 : IControlPoint
    {
      public static readonly IControlPoint Instance = (IControlPoint) new DxfCircle.ControlPoint4();

      private ControlPoint4()
      {
      }

      public void SetValue(object owner, WW.Math.Point3D value)
      {
        DxfCircle dxfCircle = (DxfCircle) owner;
        Vector3D vector3D = value - dxfCircle.point3D_0;
        vector3D.Z = 0.0;
        dxfCircle.double_1 = vector3D.GetLength();
      }

      public WW.Math.Point3D GetValue(object owner)
      {
        DxfCircle dxfCircle = (DxfCircle) owner;
        return dxfCircle.point3D_0 + new Vector3D(0.0, -dxfCircle.double_1, 0.0);
      }

      public string Description
      {
        get
        {
          return Class881.DxfCircle_ControlPoint1_Name;
        }
      }

      public PointDisplayType DisplayType
      {
        get
        {
          return PointDisplayType.Default;
        }
      }
    }

    internal class Class13 : DxfEntity.DefaultCreateInteractor
    {
      public event EventHandler<InteractorMouseEventArgs> MouseMoveProcessed;

      public Class13(DxfEntity entity, ITransaction transaction)
        : base(entity, transaction, (IControlPointCollection) new DxfCircle.Class13.Class537((DxfCircle) entity))
      {
      }

      public double? EnteredRadius
      {
        get
        {
          return ((DxfCircle.Class13.Class537) this.ControlPoints).EnteredRadius;
        }
        set
        {
          ((DxfCircle.Class13.Class537) this.ControlPoints).EnteredRadius = value;
        }
      }

      public override int ControlPointCommitIndex
      {
        get
        {
          return 1;
        }
      }

      public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
      {
        bool flag = base.ProcessMouseMove(e, context);
        this.OnMouseMoveProcessed(new InteractorMouseEventArgs(e, context));
        return flag;
      }

      protected virtual void OnMouseMoveProcessed(InteractorMouseEventArgs e)
      {
        if (this.eventHandler_1 == null)
          return;
        this.eventHandler_1((object) this, e);
      }

      private void method_2()
      {
        if (!this.EnteredRadius.HasValue)
          return;
        DxfCircle entity = (DxfCircle) this.Entity;
        ((DxfCircle.Class13.Class537) this.ControlPoints).method_0();
        this.OnEntityChanged(new EntityEventArgs(this.Entity));
      }

      public override IInteractorWinFormsDrawable CreateWinFormsDrawable(
        InteractionContext context,
        Control hostControl)
      {
        return (IInteractorWinFormsDrawable) new DxfCircle.Class13.Form2(this, hostControl);
      }

      private class Class537 : IControlPointCollection
      {
        private WW.Math.Point3D[] point3D_0 = new WW.Math.Point3D[2];
        private DxfCircle dxfCircle_0;
        private double? nullable_0;

        public Class537(DxfCircle circle)
        {
          this.dxfCircle_0 = circle;
        }

        public double? EnteredRadius
        {
          get
          {
            return this.nullable_0;
          }
          set
          {
            this.nullable_0 = value;
          }
        }

        public bool method_0()
        {
          WW.Math.Point3D point3D1 = (WW.Math.Point3D) (WW.Math.Point2D) this.point3D_0[0];
          WW.Math.Point3D point3D2 = (WW.Math.Point3D) (WW.Math.Point2D) this.point3D_0[1];
          this.dxfCircle_0.point3D_0 = point3D1;
          this.dxfCircle_0.double_1 = !this.nullable_0.HasValue ? (point3D2 - point3D1).GetLength() : this.nullable_0.Value;
          return true;
        }

        public void Set(int index, WW.Math.Point3D value)
        {
          this.point3D_0[index] = value;
          if (index < 0)
            return;
          this.method_0();
        }

        public WW.Math.Point3D Get(int index)
        {
          return this.point3D_0[index];
        }

        public string GetDescription(int index)
        {
          switch (index)
          {
            case 0:
              return Class881.DxfCircle_CenterControlPoint_Name;
            case 1:
              return Class881.DxfCircle_ControlPoint1_Name;
            default:
              return string.Empty;
          }
        }

        public PointDisplayType GetDisplayType(int index)
        {
          return PointDisplayType.Default;
        }

        public int Count
        {
          get
          {
            return 2;
          }
        }

        public bool IsCountFixed
        {
          get
          {
            return true;
          }
        }

        public void Insert(int index)
        {
          throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
          throw new NotSupportedException();
        }
      }

      internal class Form2 : DxfEntity.DefaultCreateInteractor.WinFormsDrawable
      {
        private DxfCircle.Class13 class13_0;
        private FieldEditControl fieldEditControl_0;
        private Control control_0;
        private bool bool_0;

        public Form2(DxfCircle.Class13 interactor, Control hostControl)
          : base((DxfEntity.Interactor) interactor)
        {
          this.class13_0 = interactor;
          this.control_0 = hostControl;
          this.fieldEditControl_0 = FieldEditControl.Create(Class675.Radius);
          this.fieldEditControl_0.TextBox.KeyPress += new KeyPressEventHandler(this.method_0);
          interactor.Activated += new EventHandler(this.method_1);
          interactor.Deactivated += new EventHandler(this.method_3);
          if (!interactor.IsActive)
            return;
          this.method_2();
        }

        public override void Draw(
          PaintEventArgs e,
          GraphicsHelper graphicsHelper,
          InteractionContext context)
        {
          base.Draw(e, graphicsHelper, context);
          DxfCircle.Class13.Form2.smethod_0((DxfEntity.Interactor.WinFormsDrawable) this, e, graphicsHelper, context, false);
          DxfCircle.Class13 interactor = (DxfCircle.Class13) this.Interactor;
          for (int index = 0; index < interactor.ControlPointIndex; ++index)
            graphicsHelper.DrawEditHandle(e.Graphics, graphicsHelper.DefaultPen, context.ProjectionTransform.TransformTo2D(interactor.ControlPoints.Get(index)));
        }

        internal static void smethod_0(
          DxfEntity.Interactor.WinFormsDrawable drawable,
          PaintEventArgs e,
          GraphicsHelper graphicsHelper,
          InteractionContext context,
          bool drawRadius)
        {
          DxfCircle entity = (DxfCircle) drawable.Interactor.Entity;
          Matrix4D matrix4D = context.ProjectionTransform * entity.Transform;
          PointF pointF1 = matrix4D.TransformToPointF(entity.Center);
          PointF pointF2 = matrix4D.TransformToPointF(entity.Center + entity.Radius * Vector3D.XAxis);
          if (entity.Radius == 0.0 || !drawRadius)
            return;
          e.Graphics.DrawLine(graphicsHelper.DottedPen, pointF1, pointF2);
          PointF point = new PointF((float) (0.5 * ((double) pointF1.X + (double) pointF2.X)), (float) (0.5 * ((double) pointF1.Y + (double) pointF2.Y)));
          e.Graphics.DrawString("R=" + entity.Radius.ToString(context.LengthFormatString), graphicsHelper.DefaultFont, graphicsHelper.DefaultBrush, point);
        }

        private void method_0(object sender, KeyPressEventArgs e)
        {
          if (e.KeyChar != '\r' && e.KeyChar != '\t')
          {
            if (e.KeyChar != '\x001B')
              return;
            this.class13_0.Transaction.Rollback();
            e.Handled = true;
          }
          else
          {
            DxfCircle.Class13.Class537 controlPoints = (DxfCircle.Class13.Class537) this.class13_0.ControlPoints;
            WW.Math.Point3D point3D1 = (WW.Math.Point3D) (WW.Math.Point2D) controlPoints.Get(0);
            WW.Math.Point3D point3D2 = (WW.Math.Point3D) (WW.Math.Point2D) controlPoints.Get(1);
            if (((DxfEntity.DefaultCreateInteractor) this.Interactor).ControlPointIndex < 1)
            {
              int num1 = (int) MessageBox.Show(Class881.DxfCircle_CreateInteractor_WinFormsDrawable_NoCenterPointMessage);
            }
            else if (!controlPoints.EnteredRadius.HasValue && (((DxfEntity.DefaultCreateInteractor) this.Interactor).ControlPointIndex < 2 || point3D1 == point3D2))
            {
              int num2 = (int) MessageBox.Show(Class881.DxfCircle_CreateInteractor_WinFormsDrawable_NoControlPoint1OrRadiusMessage);
            }
            else if (controlPoints.method_0())
              this.class13_0.Transaction.Commit();
            e.Handled = true;
          }
        }

        private void method_1(object sender, EventArgs e)
        {
          this.method_2();
        }

        private void method_2()
        {
          this.fieldEditControl_0.Visible = true;
          this.fieldEditControl_0.TextBox.Text = "0";
          this.fieldEditControl_0.TextBox.SelectAll();
          this.fieldEditControl_0.TextBox.TextChanged += new EventHandler(this.method_5);
          this.fieldEditControl_0.Show();
          this.fieldEditControl_0.TextBox.Focus();
          this.control_0.MouseMove += new MouseEventHandler(this.control_0_MouseMove);
          this.class13_0.MouseMoveProcessed += new EventHandler<InteractorMouseEventArgs>(this.method_4);
        }

        private void method_3(object sender, EventArgs e)
        {
          this.fieldEditControl_0.TextBox.TextChanged -= new EventHandler(this.method_5);
          this.fieldEditControl_0.Hide();
          this.control_0.MouseMove -= new MouseEventHandler(this.control_0_MouseMove);
          this.class13_0.MouseMoveProcessed -= new EventHandler<InteractorMouseEventArgs>(this.method_4);
        }

        private void control_0_MouseMove(object sender, MouseEventArgs e)
        {
          this.fieldEditControl_0.Location = this.control_0.PointToScreen(new System.Drawing.Point(e.Location.X + 5, e.Location.Y - 5 - this.fieldEditControl_0.Height));
        }

        private void method_4(object sender, InteractorMouseEventArgs e)
        {
          if (!this.class13_0.EnteredRadius.HasValue)
          {
            this.bool_0 = true;
            try
            {
              this.fieldEditControl_0.TextBox.Text = ((DxfCircle) this.class13_0.Entity).Radius.ToString(e.InteractionContext.LengthFormatString);
              this.fieldEditControl_0.TextBox.SelectAll();
            }
            finally
            {
              this.bool_0 = false;
            }
          }
          this.fieldEditControl_0.TextBox.Focus();
        }

        private void method_5(object sender, EventArgs e)
        {
          if (this.bool_0)
            return;
          if (string.IsNullOrEmpty(this.fieldEditControl_0.TextBox.Text))
          {
            this.class13_0.EnteredRadius = new double?();
          }
          else
          {
            double result;
            if (!double.TryParse(this.fieldEditControl_0.TextBox.Text, out result))
              return;
            this.class13_0.EnteredRadius = new double?(result);
            this.class13_0.method_2();
          }
        }
      }
    }

    private class Class10 : DxfEntity.DefaultEditInteractor
    {
      public Class10(DxfEntity entity)
        : base(entity)
      {
      }

      public override IInteractorWinFormsDrawable CreateWinFormsDrawable(
        InteractionContext context,
        Control hostControl)
      {
        return (IInteractorWinFormsDrawable) new DxfCircle.Class10.Form0(this);
      }

      private class Form0 : DxfEntity.EditInteractor.WinFormsDrawable
      {
        public Form0(DxfCircle.Class10 interactor)
          : base((DxfEntity.EditInteractor) interactor)
        {
        }

        public override void Draw(
          PaintEventArgs e,
          GraphicsHelper graphicsHelper,
          InteractionContext context)
        {
          base.Draw(e, graphicsHelper, context);
          DxfCircle.Class13.Form2.smethod_0((DxfEntity.Interactor.WinFormsDrawable) this, e, graphicsHelper, context, true);
        }
      }
    }
  }
}
