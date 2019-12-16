// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfLine
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
using WW.Windows;
using WW.Windows.Forms;

namespace WW.Cad.Model.Entities
{
  public class DxfLine : DxfEntity, IControlPointCollection
  {
    private static readonly IControlPoint[] icontrolPoint_0 = new IControlPoint[2]{ DxfLine.Class588.icontrolPoint_0, DxfLine.Class589.icontrolPoint_0 };
    private Vector3D vector3D_0 = Vector3D.ZAxis;
    private WW.Math.Point3D point3D_0;
    private WW.Math.Point3D point3D_1;
    private double double_1;

    public DxfLine()
    {
    }

    public DxfLine(WW.Math.Point3D start, WW.Math.Point3D end)
    {
      this.point3D_0 = start;
      this.point3D_1 = end;
    }

    public DxfLine(WW.Math.Point2D start, WW.Math.Point2D end)
    {
      this.point3D_0 = (WW.Math.Point3D) start;
      this.point3D_1 = (WW.Math.Point3D) end;
    }

    public DxfLine(EntityColor color, WW.Math.Point3D start, WW.Math.Point3D end)
    {
      this.Color = color;
      this.point3D_0 = start;
      this.point3D_1 = end;
    }

    public DxfLine(EntityColor color, WW.Math.Point2D start, WW.Math.Point2D end)
    {
      this.Color = color;
      this.point3D_0 = (WW.Math.Point3D) start;
      this.point3D_1 = (WW.Math.Point3D) end;
    }

    public WW.Math.Point3D Start
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

    public WW.Math.Point3D End
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
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
      }
    }

    public override string EntityType
    {
      get
      {
        return "LINE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbLine";
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
      DxfLine.Class591 class591 = new DxfLine.Class591();
      // ISSUE: reference to a compiler-generated field
      class591.dxfLine_0 = this;
      // ISSUE: reference to a compiler-generated field
      class591.point3D_0 = this.point3D_0;
      // ISSUE: reference to a compiler-generated field
      class591.point3D_1 = this.point3D_1;
      // ISSUE: reference to a compiler-generated field
      class591.vector3D_0 = this.vector3D_0;
      // ISSUE: reference to a compiler-generated field
      class591.double_0 = this.double_1;
      this.point3D_0 = matrix.Transform(this.point3D_0);
      this.point3D_1 = matrix.Transform(this.point3D_1);
      this.vector3D_0 = matrix.Transform(this.vector3D_0);
      this.double_1 *= this.vector3D_0.GetLength();
      this.vector3D_0.Normalize();
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new WW.Actions.Command((object) this, new System.Action(new DxfLine.Class592()
      {
        class591_0 = class591,
        point3D_0 = this.point3D_0,
        point3D_1 = this.point3D_1,
        vector3D_0 = this.vector3D_0,
        double_0 = this.double_1
      }.method_0), new System.Action(class591.method_0)));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      IClippingTransformer transformer = context.GetTransformer();
      IList<WW.Math.Geometry.Polyline3D> polylines1;
      IList<FlatShape4D> flatShapes;
      this.method_13((DrawContext) context, transformer, out polylines1, out flatShapes);
      IList<Polyline4D> polylines2 = DxfUtil.smethod_36(polylines1, false, transformer);
      if (polylines2.Count > 0)
        graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, polylines2, false, true);
      if (flatShapes == null)
        return;
      Class940.smethod_23((IPathDrawer) new ns0.Class0((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) flatShapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      IClippingTransformer transformer = context.GetTransformer();
      IList<WW.Math.Geometry.Polyline3D> polylines1;
      IList<FlatShape4D> flatShapes;
      this.method_13((DrawContext) context, transformer, out polylines1, out flatShapes);
      IList<Polyline4D> polylines2 = DxfUtil.smethod_36(polylines1, false, transformer);
      if (polylines2.Count > 0)
        Class940.smethod_3((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, false, true, polylines2);
      if (flatShapes == null)
        return;
      Class940.smethod_23((IPathDrawer) new Class396((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) flatShapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      graphicsFactory.SetColor(context.GetPlotColor((DxfEntity) this));
      IList<WW.Math.Geometry.Polyline3D> polylines;
      IList<FlatShape4D> shapes;
      this.GetPolylines((DrawContext) context, context.GetTransformer().LineTypeScaler, out polylines, out shapes);
      if (this.double_1 != 0.0)
        Class940.Extrude((DxfEntity) this, context, graphicsFactory, polylines, false, this.double_1 * this.vector3D_0);
      else
        Class940.smethod_16((DxfEntity) this, context, graphicsFactory, polylines, false);
      if (shapes == null)
        return;
      IPathDrawer pathDrawer = (IPathDrawer) new Class473((DxfEntity) this, context, graphicsFactory);
      foreach (FlatShape4D flatShape4D in (IEnumerable<FlatShape4D>) shapes)
        pathDrawer.DrawPath(flatShape4D.FlatShape, flatShape4D.Transformation, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this), flatShape4D.IsFilled, false, this.double_1);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      WW.Cad.Drawing.Surface.Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      DxfLineType lineType = this.GetLineType((DrawContext) context);
      double lineTypeScale = context.TotalLineTypeScale * this.LineTypeScale;
      if (!graphics.AddExistingGraphicElement2(parentGraphicElementBlock, (DxfEntity) this, plotColor, lineType, lineTypeScale, false))
        return;
      GraphicElement2 graphicElement2 = new GraphicElement2(plotColor, lineType, lineTypeScale, false);
      graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, (GraphicElement1) graphicElement2);
      if (this.double_1 != 0.0)
        graphicElement2.Geometry.Extrusion = this.double_1 * this.vector3D_0;
      graphicElement2.Geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Segment(this.point3D_0, this.point3D_1));
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfLine dxfLine = (DxfLine) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfLine == null)
      {
        dxfLine = new DxfLine();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfLine);
        dxfLine.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfLine;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfLine dxfLine = (DxfLine) from;
      this.point3D_0 = dxfLine.point3D_0;
      this.point3D_1 = dxfLine.point3D_1;
      this.vector3D_0 = dxfLine.vector3D_0;
      this.double_1 = dxfLine.double_1;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
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
      return (DxfEntity.Interactor) new DxfLine.CreateInteractor((DxfEntity) this, (ITransaction) transaction);
    }

    public override DxfEntity.Interactor CreateEditInteractor()
    {
      return (DxfEntity.Interactor) new DxfLine.EditInteractor((DxfEntity) this);
    }

    internal override short vmethod_6(Class432 w)
    {
      return 19;
    }

    private void method_13(
      DrawContext context,
      IClippingTransformer transformer,
      out IList<WW.Math.Geometry.Polyline3D> polylines,
      out IList<FlatShape4D> flatShapes)
    {
      this.GetPolylines(context, transformer.LineTypeScaler, out polylines, out flatShapes);
      if (this.double_1 == 0.0)
        return;
      DxfUtil.Extrude(polylines, this.double_1, this.vector3D_0);
    }

    private void GetPolylines(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<WW.Math.Geometry.Polyline3D> polylines,
      out IList<FlatShape4D> shapes)
    {
      if (this.point3D_0 == this.point3D_1)
      {
        polylines = (IList<WW.Math.Geometry.Polyline3D>) new WW.Math.Geometry.Polyline3D[1]
        {
          new WW.Math.Geometry.Polyline3D(new WW.Math.Point3D[1]{ this.point3D_0 })
        };
        shapes = (IList<FlatShape4D>) null;
      }
      else
      {
        polylines = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>();
        WW.Math.Geometry.Polyline3D polyline = new WW.Math.Geometry.Polyline3D(new WW.Math.Point3D[2]{ this.point3D_0, this.point3D_1 });
        if (context.Config.ApplyLineType)
        {
          shapes = (IList<FlatShape4D>) new List<FlatShape4D>();
          DxfUtil.smethod_4(context.Config, polylines, shapes, polyline, this.GetLineType(context), this.ZAxis, context.TotalLineTypeScale * this.LineTypeScale, lineTypeScaler);
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
    }

    void IControlPointCollection.Set(int index, WW.Math.Point3D value)
    {
      DxfLine.icontrolPoint_0[index].SetValue((object) this, value);
    }

    WW.Math.Point3D IControlPointCollection.Get(int index)
    {
      return DxfLine.icontrolPoint_0[index].GetValue((object) this);
    }

    string IControlPointCollection.GetDescription(int index)
    {
      return DxfLine.icontrolPoint_0[index].Description;
    }

    PointDisplayType IControlPointCollection.GetDisplayType(
      int index)
    {
      return DxfLine.icontrolPoint_0[index].DisplayType;
    }

    int IControlPointCollection.Count
    {
      get
      {
        return DxfLine.icontrolPoint_0.Length;
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

    private class Class588 : IControlPoint
    {
      public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfLine.Class588();

      private Class588()
      {
      }

      public void SetValue(object owner, WW.Math.Point3D value)
      {
        ((DxfLine) owner).point3D_0 = value;
      }

      public WW.Math.Point3D GetValue(object owner)
      {
        return ((DxfLine) owner).point3D_0;
      }

      public string Description
      {
        get
        {
          return Class881.DxfLine_StartControlPoint_Name;
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

    private class Class589 : IControlPoint
    {
      public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfLine.Class589();

      private Class589()
      {
      }

      public void SetValue(object owner, WW.Math.Point3D value)
      {
        ((DxfLine) owner).point3D_1 = value;
      }

      public WW.Math.Point3D GetValue(object owner)
      {
        return ((DxfLine) owner).point3D_1;
      }

      public string Description
      {
        get
        {
          return Class881.DxfLine_EndControlPoint_Name;
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

    public class CreateInteractor : DxfEntity.DefaultCreateInteractor
    {
      public CreateInteractor(DxfEntity entity, ITransaction transaction)
        : base(entity, transaction)
      {
      }

      protected override WW.Math.Point3D ProcessWcsPosition(
        InteractionContext context,
        WW.Math.Point3D p)
      {
        p = base.ProcessWcsPosition(context, p);
        p = DxfLine.CreateInteractor.SnapHorizontalOrVertical((DxfEntity.Interactor) this, p, context, this.ControlPointIndex);
        return p;
      }

      public static WW.Math.Point3D SnapHorizontalOrVertical(
        DxfEntity.Interactor interactor,
        WW.Math.Point3D p,
        InteractionContext context,
        int controlPointIndex)
      {
        bool flag = InputUtil.IsShiftPressed();
        CadInteractionContext interactionContext = context as CadInteractionContext;
        if (interactionContext != null)
          flag ^= interactionContext.DefaultNonDiagonalLines;
        if (interactor.IsActive && flag)
        {
          DxfLine entity = (DxfLine) interactor.Entity;
          WW.Math.Point2D point2D1 = context.ProjectionTransform.TransformTo2D(controlPointIndex == 0 ? entity.point3D_1 : entity.point3D_0);
          WW.Math.Point3D point3D = p;
          WW.Math.Point2D point2D2 = context.ProjectionTransform.TransformTo2D((WW.Math.Point2D) point3D);
          Vector2D vector2D = point2D2 - point2D1;
          p = System.Math.Abs(vector2D.X) >= System.Math.Abs(vector2D.Y) ? context.InverseProjectionTransform.TransformTo3D(new WW.Math.Point2D(point2D2.X, point2D1.Y)) : context.InverseProjectionTransform.TransformTo3D(new WW.Math.Point2D(point2D1.X, point2D2.Y));
        }
        return p;
      }

      public override IInteractorWinFormsDrawable CreateWinFormsDrawable(
        InteractionContext context,
        Control hostControl)
      {
        return (IInteractorWinFormsDrawable) new DxfLine.CreateInteractor.Form10((DxfEntity.Interactor) this, base.CreateWinFormsDrawable(context, hostControl));
      }

      internal class Form10 : WW.Actions.Interactor.WinFormsDrawable
      {
        private DxfEntity.Interactor interactor_0;
        private IInteractorWinFormsDrawable iinteractorWinFormsDrawable_0;

        public Form10(DxfEntity.Interactor interactor, IInteractorWinFormsDrawable baseDrawable)
        {
          this.interactor_0 = interactor;
          this.iinteractorWinFormsDrawable_0 = baseDrawable;
        }

        public DxfEntity.Interactor Interactor
        {
          get
          {
            return this.interactor_0;
          }
        }

        public override void Draw(
          PaintEventArgs e,
          GraphicsHelper graphicsHelper,
          InteractionContext context)
        {
          this.iinteractorWinFormsDrawable_0.Draw(e, graphicsHelper, context);
          DxfLine.CreateInteractor.Form10.smethod_0((IInteractorWinFormsDrawable) this, this.interactor_0.Entity, e, graphicsHelper, context);
        }

        public override Cursor GetCursor()
        {
          return this.iinteractorWinFormsDrawable_0.GetCursor();
        }

        internal static void smethod_0(
          IInteractorWinFormsDrawable drawable,
          DxfEntity entity,
          PaintEventArgs e,
          GraphicsHelper graphicsHelper,
          InteractionContext context)
        {
          DxfLine dxfLine = (DxfLine) entity;
          Matrix4D projectionTransform = context.ProjectionTransform;
          PointF pointF1 = projectionTransform.TransformToPointF(dxfLine.point3D_0);
          PointF pointF2 = projectionTransform.TransformToPointF(dxfLine.End);
          if ((double) pointF1.Y == (double) pointF2.Y)
            return;
          PointF pointF3 = projectionTransform.TransformToPointF(WW.Math.Point3D.GetMidPoint(dxfLine.point3D_0, dxfLine.point3D_1));
          double num = System.Math.Atan2((double) pointF2.Y - (double) pointF1.Y, (double) pointF2.X - (double) pointF1.X);
          if (context.ProjectionFlipsOrientation)
            num = -num;
          e.Graphics.DrawString((num * (180.0 / System.Math.PI)).ToString(context.AngleFormatString) + "°", graphicsHelper.DefaultFont, graphicsHelper.DefaultBrush, pointF3);
        }
      }
    }

    public interface ILineInteractor
    {
      event EventHandler<InteractorMouseEventArgs> MouseMoveProcessed;

      double? EnteredLength { get; set; }

      void ApplyLength();
    }

    public class CreateWithLengthInteractor : DxfLine.CreateInteractor, DxfLine.ILineInteractor
    {
      private double? nullable_1;

      public event EventHandler<InteractorMouseEventArgs> MouseMoveProcessed;

      public CreateWithLengthInteractor(DxfEntity entity, ITransaction transaction)
        : base(entity, transaction)
      {
      }

      public double? EnteredLength
      {
        get
        {
          return this.nullable_1;
        }
        set
        {
          this.nullable_1 = value;
        }
      }

      public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
      {
        bool flag = base.ProcessMouseMove(e, context);
        this.OnMouseMoveProcessed(new InteractorMouseEventArgs(e, context));
        return flag;
      }

      protected override WW.Math.Point3D ProcessWcsPosition(
        InteractionContext context,
        WW.Math.Point3D p)
      {
        p = base.ProcessWcsPosition(context, p);
        if (this.ControlPointIndex == 1 && this.nullable_1.HasValue && this.nullable_1.Value > 0.0)
        {
          DxfLine entity = (DxfLine) this.Entity;
          if (p != entity.point3D_0)
          {
            Vector3D unit = (p - entity.point3D_0).GetUnit();
            p = entity.point3D_0 + unit * this.nullable_1.Value;
          }
        }
        return p;
      }

      protected override void OnDeactivated(EventArgs e)
      {
        this.nullable_1 = new double?();
        base.OnDeactivated(e);
      }

      protected virtual void OnMouseMoveProcessed(InteractorMouseEventArgs e)
      {
        if (this.eventHandler_1 == null)
          return;
        this.eventHandler_1((object) this, e);
      }

      public override IInteractorWinFormsDrawable CreateWinFormsDrawable(
        InteractionContext context,
        Control hostControl)
      {
        return (IInteractorWinFormsDrawable) new DxfLine.CreateWithLengthInteractor.Form11((DxfEntity.Interactor) this, hostControl, base.CreateWinFormsDrawable(context, hostControl));
      }

      public void ApplyLength()
      {
        if (!this.nullable_1.HasValue)
          return;
        DxfLine entity = (DxfLine) this.Entity;
        if (!(entity.point3D_0 != entity.point3D_1))
          return;
        Vector3D unit = (entity.point3D_1 - entity.point3D_0).GetUnit();
        entity.point3D_1 = entity.point3D_0 + this.nullable_1.Value * unit;
        this.OnEntityChanged(new EntityEventArgs(this.Entity));
      }

      internal class Form11 : DxfLine.CreateInteractor.Form10
      {
        private FieldEditControl fieldEditControl_0;
        private Control control_0;
        private bool bool_0;

        public Form11(
          DxfEntity.Interactor interactor,
          Control hostControl,
          IInteractorWinFormsDrawable baseDrawable)
          : base(interactor, baseDrawable)
        {
          this.control_0 = hostControl;
          this.fieldEditControl_0 = FieldEditControl.Create(Class675.Length);
          this.fieldEditControl_0.TextBox.KeyPress += new KeyPressEventHandler(this.method_0);
          interactor.Activated += new EventHandler(this.method_2);
          interactor.Deactivated += new EventHandler(this.method_4);
          if (!interactor.IsActive)
            return;
          this.method_3();
        }

        private void method_0(object sender, KeyPressEventArgs e)
        {
          if (((DxfLine.ILineInteractor) this.Interactor).EnteredLength.HasValue && (e.KeyChar == '\r' || e.KeyChar == '\t'))
          {
            this.Interactor.TryCommit();
          }
          else
          {
            if (e.KeyChar != '\x001B')
              return;
            this.Interactor.Cancel();
          }
        }

        private void method_1(object sender, InteractorMouseEventArgs e)
        {
          if (!((DxfLine.ILineInteractor) this.Interactor).EnteredLength.HasValue)
          {
            this.bool_0 = true;
            try
            {
              DxfLine entity = (DxfLine) this.Interactor.Entity;
              this.fieldEditControl_0.TextBox.Text = (entity.point3D_1 - entity.point3D_0).GetLength().ToString(e.InteractionContext.LengthFormatString);
              this.fieldEditControl_0.TextBox.SelectAll();
            }
            finally
            {
              this.bool_0 = false;
            }
          }
          this.fieldEditControl_0.TextBox.Focus();
        }

        private void method_2(object sender, EventArgs e)
        {
          this.method_3();
        }

        private void method_3()
        {
          ((DxfLine.ILineInteractor) this.Interactor).MouseMoveProcessed += new EventHandler<InteractorMouseEventArgs>(this.method_1);
          this.fieldEditControl_0.TextBox.Text = "0";
          this.fieldEditControl_0.TextBox.SelectAll();
          this.fieldEditControl_0.TextBox.TextChanged += new EventHandler(this.method_5);
          this.fieldEditControl_0.Show();
          this.fieldEditControl_0.TextBox.Focus();
          this.control_0.MouseMove += new MouseEventHandler(this.control_0_MouseMove);
        }

        private void method_4(object sender, EventArgs e)
        {
          this.fieldEditControl_0.TextBox.TextChanged -= new EventHandler(this.method_5);
          ((DxfLine.ILineInteractor) this.Interactor).MouseMoveProcessed -= new EventHandler<InteractorMouseEventArgs>(this.method_1);
          this.fieldEditControl_0.Hide();
          this.control_0.MouseMove -= new MouseEventHandler(this.control_0_MouseMove);
        }

        private void control_0_MouseMove(object sender, MouseEventArgs e)
        {
          this.fieldEditControl_0.Location = this.control_0.PointToScreen(new System.Drawing.Point(e.Location.X + 5, e.Location.Y - 5 - this.fieldEditControl_0.Height));
        }

        private void method_5(object sender, EventArgs e)
        {
          if (this.bool_0)
            return;
          this.bool_0 = true;
          try
          {
            if (string.IsNullOrEmpty(this.fieldEditControl_0.TextBox.Text))
            {
              ((DxfLine.ILineInteractor) this.Interactor).EnteredLength = new double?();
            }
            else
            {
              double result;
              if (!double.TryParse(this.fieldEditControl_0.TextBox.Text, out result))
                return;
              ((DxfLine.ILineInteractor) this.Interactor).EnteredLength = new double?(result);
              ((DxfLine.ILineInteractor) this.Interactor).ApplyLength();
            }
          }
          finally
          {
            this.bool_0 = false;
          }
        }
      }
    }

    public class EditInteractor : DxfEntity.DefaultEditInteractor, DxfLine.ILineInteractor
    {
      private double? nullable_1;

      public event EventHandler<InteractorMouseEventArgs> MouseMoveProcessed;

      public EditInteractor(DxfEntity entity)
        : base(entity)
      {
      }

      public double? EnteredLength
      {
        get
        {
          return this.nullable_1;
        }
        set
        {
          this.nullable_1 = value;
        }
      }

      public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
      {
        bool flag = base.ProcessMouseMove(e, context);
        this.OnMouseMoveProcessed(new InteractorMouseEventArgs(e, context));
        return flag;
      }

      protected override WW.Math.Point3D ProcessWcsPosition(
        InteractionContext context,
        WW.Math.Point3D p)
      {
        p = base.ProcessWcsPosition(context, p);
        p = DxfLine.CreateInteractor.SnapHorizontalOrVertical((DxfEntity.Interactor) this, p, context, this.ControlPointIndexAtFirstMouseDown);
        if (this.ClickCount > 0 && this.nullable_1.HasValue)
        {
          DxfLine entity = (DxfLine) this.Entity;
          if (this.ControlPointIndexAtFirstMouseDown == 0)
          {
            Vector3D u = entity.point3D_1 - p;
            if (Vector3D.AreApproxEqual(u, Vector3D.Zero))
              u = entity.point3D_1 - entity.point3D_0;
            if (!Vector3D.AreApproxEqual(u, Vector3D.Zero))
              p = entity.point3D_1 - this.nullable_1.Value * u.GetUnit();
          }
          else
          {
            Vector3D u = p - entity.point3D_0;
            if (Vector3D.AreApproxEqual(u, Vector3D.Zero))
              u = entity.point3D_1 - entity.point3D_0;
            if (!Vector3D.AreApproxEqual(u, Vector3D.Zero))
              p = entity.point3D_0 + this.nullable_1.Value * u.GetUnit();
          }
        }
        return p;
      }

      public override bool TryCommit()
      {
        if (this.ClickCount <= 0)
          return false;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfLine.EditInteractor.Class590 class590 = new DxfLine.EditInteractor.Class590();
        // ISSUE: reference to a compiler-generated field
        class590.editInteractor_0 = this;
        // ISSUE: reference to a compiler-generated field
        class590.int_0 = this.ControlPointIndexAtFirstMouseDown;
        // ISSUE: reference to a compiler-generated field
        class590.point3D_0 = this.ControlPointValueAtFirstMouseDown;
        DxfLine entity = (DxfLine) this.Entity;
        // ISSUE: reference to a compiler-generated field
        class590.point3D_1 = this.ControlPointIndexAtFirstMouseDown != 0 ? entity.point3D_1 : entity.point3D_0;
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        this.OnCommandCreated(new CommandEventArgs((ICommand) new WW.Actions.Command((object) this.Entity, new System.Action(class590.method_0), new System.Action(class590.method_1))));
        this.Deactivate();
        return true;
      }

      protected override void OnDeactivated(EventArgs e)
      {
        this.nullable_1 = new double?();
        base.OnDeactivated(e);
      }

      protected virtual void OnMouseMoveProcessed(InteractorMouseEventArgs e)
      {
        if (this.eventHandler_1 == null)
          return;
        this.eventHandler_1((object) this, e);
      }

      public override IInteractorWinFormsDrawable CreateWinFormsDrawable(
        InteractionContext context,
        Control hostControl)
      {
        return (IInteractorWinFormsDrawable) new DxfLine.CreateWithLengthInteractor.Form11((DxfEntity.Interactor) this, hostControl, base.CreateWinFormsDrawable(context, hostControl));
      }

      public void ApplyLength()
      {
        if (!this.nullable_1.HasValue || this.ClickCount <= 0)
          return;
        DxfLine entity = (DxfLine) this.Entity;
        if (!(entity.point3D_0 != entity.point3D_1))
          return;
        Vector3D unit = (entity.point3D_1 - entity.point3D_0).GetUnit();
        if (this.ControlPointIndexAtFirstMouseDown == 0)
          entity.point3D_0 = entity.point3D_1 - this.nullable_1.Value * unit;
        else
          entity.point3D_1 = entity.point3D_0 + this.nullable_1.Value * unit;
        this.OnEntityChanged(new EntityEventArgs(this.Entity));
      }
    }
  }
}
