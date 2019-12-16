// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfArc
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using ns28;
using ns43;
using System;
using System.Drawing;
using System.Windows.Forms;
using WW.Actions;
using WW.Cad.Actions;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;
using WW.Windows.Forms;

namespace WW.Cad.Model.Entities
{
  public class DxfArc : DxfCircle, IControlPointCollection
  {
    private static readonly IControlPoint[] icontrolPoint_1 = new IControlPoint[3]{ DxfCircle.CenterControlPoint.Instance, DxfArc.Class540.icontrolPoint_0, DxfArc.Class541.icontrolPoint_0 };
    private static readonly IControlPoint[] icontrolPoint_2 = new IControlPoint[3]{ DxfCircle.CenterControlPoint.Instance, DxfArc.Class541.icontrolPoint_0, DxfArc.Class540.icontrolPoint_0 };
    private double double_3;
    private double double_4;

    public DxfArc()
    {
    }

    public DxfArc(
      WW.Math.Point3D center,
      double radius,
      double startAngle,
      double endAngle,
      Vector3D zaxis)
    {
      this.Center = center;
      this.Radius = radius;
      this.double_3 = startAngle;
      this.double_4 = endAngle;
      this.ZAxis = zaxis;
    }

    public DxfArc(WW.Math.Point3D center, double radius, double startAngle, double endAngle)
    {
      this.Center = center;
      this.Radius = radius;
      this.double_3 = startAngle;
      this.double_4 = endAngle;
    }

    public double StartAngle
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

    public double EndAngle
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

    public override string EntityType
    {
      get
      {
        return "ARC";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbArc";
      }
    }

    internal Vector3D StartVector
    {
      get
      {
        return new Vector3D(System.Math.Cos(this.double_3), System.Math.Sin(this.double_3), 0.0);
      }
    }

    internal Vector3D EndVector
    {
      get
      {
        return new Vector3D(System.Math.Cos(this.double_4), System.Math.Sin(this.double_4), 0.0);
      }
    }

    public bool InitializeFromThreePoints(
      WW.Math.Point3D startPoint,
      WW.Math.Point3D midPoint,
      WW.Math.Point3D endPoint,
      bool ocs)
    {
      Vector3D vector3D = Vector3D.CrossProduct(endPoint - startPoint, midPoint - startPoint);
      if (!(vector3D != Vector3D.Zero))
        return false;
      Vector3D zaxis = this.ZAxis;
      this.ZAxis = vector3D.GetUnit();
      if (this.ZAxis.Z < 0.0)
        this.ZAxis = -this.ZAxis;
      Matrix4D matrix4D1 = ocs ? Matrix4D.Identity : this.Transform;
      Matrix4D matrix4D2 = ocs ? Matrix4D.Identity : matrix4D1.GetInverse();
      WW.Math.Point3D point3D1 = matrix4D2.Transform(startPoint);
      WW.Math.Point2D a1 = new WW.Math.Point2D(point3D1.X, point3D1.Y);
      WW.Math.Point3D point3D2 = matrix4D2.Transform(midPoint);
      WW.Math.Point2D point2D = new WW.Math.Point2D(point3D2.X, point3D2.Y);
      WW.Math.Point3D point3D3 = matrix4D2.Transform(endPoint);
      WW.Math.Point2D b1 = new WW.Math.Point2D(point3D3.X, point3D3.Y);
      Vector2D vector2D1 = point2D - a1;
      Line2D a2 = new Line2D(WW.Math.Point2D.GetMidPoint(a1, point2D), new Vector2D(-vector2D1.Y, vector2D1.X));
      Vector2D vector2D2 = b1 - point2D;
      Line2D b2 = new Line2D(WW.Math.Point2D.GetMidPoint(point2D, b1), new Vector2D(-vector2D2.Y, vector2D2.X));
      WW.Math.Point2D? intersection = Line2D.GetIntersection(a2, b2);
      if (!intersection.HasValue)
      {
        this.ZAxis = zaxis;
        return false;
      }
      this.Center = new WW.Math.Point3D(intersection.Value.X, intersection.Value.Y, point3D1.Z);
      Vector2D vector2D3 = a1 - intersection.Value;
      this.double_3 = System.Math.Atan2(vector2D3.Y, vector2D3.X);
      this.Radius = vector2D3.GetLength();
      Vector2D vector2D4 = b1 - intersection.Value;
      this.double_4 = System.Math.Atan2(vector2D4.Y, vector2D4.X);
      Arc2D arc2D = new Arc2D(intersection.Value, this.Radius, this.double_3, this.double_4);
      Vector2D vector2D5 = point2D - intersection.Value;
      double angle = System.Math.Atan2(vector2D5.Y, vector2D5.X);
      if (!arc2D.ContainsAngle(angle))
      {
        double double3 = this.double_3;
        this.double_3 = this.double_4;
        this.double_4 = double3;
      }
      return true;
    }

    public bool InitializeFromThreePointsAndRadius(
      WW.Math.Point3D startPoint,
      WW.Math.Point3D midPointHint,
      WW.Math.Point3D endPoint,
      double radius,
      bool ocs)
    {
      Vector3D vector3D1 = Vector3D.CrossProduct(endPoint - startPoint, midPointHint - startPoint);
      if (!(vector3D1 != Vector3D.Zero))
        return false;
      Vector3D zaxis = this.ZAxis;
      this.ZAxis = vector3D1.GetUnit();
      if (this.ZAxis.Z < 0.0)
        this.ZAxis = -this.ZAxis;
      Matrix4D matrix4D1 = ocs ? Matrix4D.Identity : this.Transform;
      Matrix4D matrix4D2 = ocs ? Matrix4D.Identity : matrix4D1.GetInverse();
      WW.Math.Point3D a = matrix4D2.Transform(startPoint);
      WW.Math.Point2D point2D1 = new WW.Math.Point2D(a.X, a.Y);
      WW.Math.Point3D point3D1 = matrix4D2.Transform(midPointHint);
      WW.Math.Point2D point2D2 = new WW.Math.Point2D(point3D1.X, point3D1.Y);
      WW.Math.Point3D b = matrix4D2.Transform(endPoint);
      WW.Math.Point2D point2D3 = new WW.Math.Point2D(b.X, b.Y);
      Vector3D vector3D2 = b - a;
      Vector3D vector3D3 = Vector3D.CrossProduct(this.ZAxis, vector3D2.GetUnit());
      double num1 = 0.5 * vector3D2.GetLength();
      if (radius < num1 - 8.88178419700125E-16)
        return false;
      double num2 = System.Math.Sqrt(radius * radius - num1 * num1);
      WW.Math.Point3D midPoint = WW.Math.Point3D.GetMidPoint(a, b);
      WW.Math.Point3D point3D2 = midPoint + num2 * vector3D3;
      WW.Math.Point3D point3D3 = midPoint - num2 * vector3D3;
      WW.Math.Point2D center = (WW.Math.Point2D) (new Circle2D(point3D2.X, point3D2.Y, radius).GetDistance((WW.Math.Point2D) midPointHint) < new Circle2D(point3D3.X, point3D3.Y, radius).GetDistance((WW.Math.Point2D) midPointHint) ? point3D2 : point3D3);
      this.Center = new WW.Math.Point3D(center.X, center.Y, a.Z);
      Vector2D vector2D1 = point2D1 - center;
      this.double_3 = System.Math.Atan2(vector2D1.Y, vector2D1.X);
      this.Radius = vector2D1.GetLength();
      Vector2D vector2D2 = point2D3 - center;
      this.double_4 = System.Math.Atan2(vector2D2.Y, vector2D2.X);
      Arc2D arc2D = new Arc2D(center, this.Radius, this.double_3, this.double_4);
      Vector2D vector2D3 = point2D2 - center;
      double angle = System.Math.Atan2(vector2D3.Y, vector2D3.X);
      if (!arc2D.ContainsAngle(angle))
      {
        double double3 = this.double_3;
        this.double_3 = this.double_4;
        this.double_4 = double3;
      }
      return true;
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
      DxfArc.Class546 class546 = new DxfArc.Class546();
      // ISSUE: reference to a compiler-generated field
      class546.dxfArc_0 = this;
      CommandGroup undoGroup1 = (CommandGroup) null;
      if (undoGroup != null)
      {
        undoGroup1 = new CommandGroup((object) this);
        undoGroup.UndoStack.Push((ICommand) undoGroup1);
      }
      Matrix4D transformationWithOcs;
      this.method_13(matrix, undoGroup1, out transformationWithOcs);
      // ISSUE: reference to a compiler-generated field
      class546.double_0 = this.double_3;
      // ISSUE: reference to a compiler-generated field
      class546.double_1 = this.double_4;
      Vector2D vector2D1 = transformationWithOcs.Transform(new Vector2D(System.Math.Cos(this.double_3), System.Math.Sin(this.double_3)));
      this.double_3 = System.Math.Atan2(vector2D1.Y, vector2D1.X);
      Vector2D vector2D2 = transformationWithOcs.Transform(new Vector2D(System.Math.Cos(this.double_4), System.Math.Sin(this.double_4)));
      this.double_4 = System.Math.Atan2(vector2D2.Y, vector2D2.X);
      if (matrix.GetDeterminant() < 0.0)
        MathUtil.Swap(ref this.double_3, ref this.double_4);
      if (undoGroup1 == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new WW.Actions.Command((object) this, new System.Action(new DxfArc.Class547()
      {
        class546_0 = class546,
        double_0 = this.double_3,
        double_1 = this.double_4
      }.method_0), new System.Action(class546.method_0)));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      double double4 = this.double_4;
      while (double4 < this.double_3)
        double4 += 2.0 * System.Math.PI;
      this.DrawInternal(context, graphicsFactory, this.double_3, double4);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      double double4 = this.double_4;
      while (double4 < this.double_3)
        double4 += 2.0 * System.Math.PI;
      this.DrawInternal(context, graphicsFactory, this.double_3, double4);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      double double4 = this.double_4;
      while (double4 < this.double_3)
        double4 += 2.0 * System.Math.PI;
      this.DrawInternal(context, graphicsFactory, this.double_3, double4);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      WW.Cad.Drawing.Surface.Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      double double4 = this.double_4;
      while (double4 < this.double_3)
        double4 += 2.0 * System.Math.PI;
      this.DrawInternal(context, graphics, parentGraphicElementBlock, this.double_3, double4);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfArc dxfArc = (DxfArc) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfArc == null)
      {
        dxfArc = new DxfArc();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfArc);
        dxfArc.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfArc;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfArc dxfArc = (DxfArc) from;
      this.double_3 = dxfArc.double_3;
      this.double_4 = dxfArc.double_4;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override DxfEntity.Interactor CreateCreateInteractor(Transaction transaction)
    {
      return (DxfEntity.Interactor) new DxfArc.Class14((DxfEntity) this, (ITransaction) transaction);
    }

    public override DxfEntity.Interactor CreateEditInteractor()
    {
      return (DxfEntity.Interactor) new DxfArc.Class11((DxfEntity) this);
    }

    internal override void Repair(DxfModelRepairer repairer)
    {
      base.Repair(repairer);
      repairer.method_3((DxfHandledObject) this, "StartAngle", ref this.double_3);
      repairer.method_3((DxfHandledObject) this, "EndAngle", ref this.double_4);
    }

    internal override short vmethod_6(Class432 w)
    {
      return 17;
    }

    void IControlPointCollection.Set(int index, WW.Math.Point3D value)
    {
      DxfArc.icontrolPoint_1[index].SetValue((object) this, value);
    }

    WW.Math.Point3D IControlPointCollection.Get(int index)
    {
      return DxfArc.icontrolPoint_1[index].GetValue((object) this);
    }

    string IControlPointCollection.GetDescription(int index)
    {
      return DxfArc.icontrolPoint_1[index].Description;
    }

    PointDisplayType IControlPointCollection.GetDisplayType(
      int index)
    {
      return DxfArc.icontrolPoint_1[index].DisplayType;
    }

    int IControlPointCollection.Count
    {
      get
      {
        return DxfArc.icontrolPoint_1.Length;
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

    private class Class540 : IControlPoint
    {
      public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfArc.Class540();

      private Class540()
      {
      }

      public void SetValue(object owner, WW.Math.Point3D value)
      {
        DxfArc dxfArc = (DxfArc) owner;
        Vector3D vector3D = value - dxfArc.Center;
        if (vector3D.X != 0.0 || vector3D.Y != 0.0)
          dxfArc.double_3 = System.Math.Atan2(vector3D.Y, vector3D.X);
        vector3D.Z = 0.0;
        dxfArc.Radius = vector3D.GetLength();
      }

      public WW.Math.Point3D GetValue(object owner)
      {
        DxfArc dxfArc = (DxfArc) owner;
        return dxfArc.Center + dxfArc.Radius * dxfArc.StartVector;
      }

      public string Description
      {
        get
        {
          return Class881.DxfArc_StartAngleControlPoint_Name;
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

    private class Class541 : IControlPoint
    {
      public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfArc.Class541();

      private Class541()
      {
      }

      public void SetValue(object owner, WW.Math.Point3D value)
      {
        DxfArc dxfArc = (DxfArc) owner;
        Vector3D vector3D = value - dxfArc.Center;
        if (vector3D.X == 0.0 && vector3D.Y == 0.0)
          return;
        dxfArc.double_4 = System.Math.Atan2(vector3D.Y, vector3D.X);
      }

      public WW.Math.Point3D GetValue(object owner)
      {
        DxfArc dxfArc = (DxfArc) owner;
        return dxfArc.Center + dxfArc.Radius * dxfArc.EndVector;
      }

      public string Description
      {
        get
        {
          return Class881.DxfArc_EndAngleControlPoint_Name;
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

    internal class Class14 : DxfEntity.DefaultCreateInteractor
    {
      public event EventHandler<InteractorMouseEventArgs> MouseMoveProcessed;

      public Class14(DxfEntity entity, ITransaction transaction)
        : base(entity, transaction, (IControlPointCollection) new DxfArc.Class14.Class543((DxfArc) entity))
      {
      }

      public double? EnteredRadius
      {
        get
        {
          return ((DxfArc.Class14.Class543) this.ControlPoints).EnteredRadius;
        }
        set
        {
          ((DxfArc.Class14.Class543) this.ControlPoints).EnteredRadius = value;
        }
      }

      public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
      {
        if (this.IsActive && this.ControlPointIndex == 2)
        {
          DxfArc.Class14.Class543 controlPoints = (DxfArc.Class14.Class543) this.ControlPoints;
          if (!controlPoints.DefiniteIsClockwise.HasValue)
          {
            DxfArc entity = (DxfArc) this.Entity;
            WW.Math.Point2D point2D1 = context.ProjectionTransform.TransformTo2D(entity.Center);
            WW.Math.Point2D point2D2 = context.ProjectionTransform.TransformTo2D(entity.Center + entity.StartVector);
            if (point2D2 != point2D1)
            {
              Vector2D vector2D1 = point2D2 - point2D1;
              double num1 = Vector2D.DotProduct(new Vector2D(-vector2D1.Y, vector2D1.X).GetUnit(), e.Position - point2D1);
              WW.Math.Point2D center = (WW.Math.Point2D) entity.Center;
              Vector2D vector2D2 = (WW.Math.Point2D) (entity.Center + entity.StartVector) - center;
              double num2 = Vector2D.DotProduct(new Vector2D(-vector2D2.Y, vector2D2.X), context.InverseProjectionTransform.TransformTo2D(e.Position) - center);
              if (!controlPoints.DefiniteIsClockwise.HasValue)
              {
                bool? isClockwise1 = controlPoints.IsClockwise;
                controlPoints.IsClockwise = new bool?(num2 < 0.0);
                if (System.Math.Abs(num1) > context.EditHandleSize)
                  controlPoints.DefiniteIsClockwise = controlPoints.IsClockwise;
                bool? isClockwise2 = controlPoints.IsClockwise;
                bool? nullable = isClockwise1;
                if ((isClockwise2.GetValueOrDefault() != nullable.GetValueOrDefault() ? 1 : (isClockwise2.HasValue != nullable.HasValue ? 1 : 0)) != 0)
                {
                  double double3 = entity.double_3;
                  entity.double_3 = entity.double_4;
                  entity.double_4 = double3;
                }
              }
            }
          }
        }
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
        ((DxfCircle) this.Entity).Radius = this.EnteredRadius.Value;
        this.OnEntityChanged(new EntityEventArgs(this.Entity));
      }

      public override IInteractorWinFormsDrawable CreateWinFormsDrawable(
        InteractionContext context,
        Control hostControl)
      {
        return (IInteractorWinFormsDrawable) new DxfArc.Class14.Form4(this, hostControl);
      }

      private class Class543 : DxfArc.Class542
      {
        private double? nullable_2;

        public Class543(DxfArc arc)
          : base(arc)
        {
        }

        public double? EnteredRadius
        {
          get
          {
            return this.nullable_2;
          }
          set
          {
            this.nullable_2 = value;
          }
        }

        public override void Set(int index, WW.Math.Point3D value)
        {
          this.method_0(index).SetValue((object) this.Owner, value);
          if (!this.nullable_2.HasValue)
            return;
          this.Owner.Radius = this.nullable_2.Value;
        }
      }

      internal class Form4 : DxfArc.Form3
      {
        private DxfArc.Class14 class14_0;
        private FieldEditControl fieldEditControl_0;
        private Control control_0;
        private bool bool_0;

        public Form4(DxfArc.Class14 interactor, Control hostControl)
          : base((DxfEntity.Interactor) interactor)
        {
          this.class14_0 = interactor;
          this.control_0 = hostControl;
          this.fieldEditControl_0 = FieldEditControl.Create(Class675.Radius);
          this.fieldEditControl_0.TextBox.KeyPress += new KeyPressEventHandler(this.method_0);
          interactor.Activated += new EventHandler(this.method_1);
          interactor.Deactivated += new EventHandler(this.method_3);
          if (!interactor.IsActive)
            return;
          this.method_2();
        }

        private void method_0(object sender, KeyPressEventArgs e)
        {
          if (e.KeyChar != '\r' && e.KeyChar != '\t')
          {
            if (e.KeyChar != '\x001B')
              return;
            this.class14_0.Transaction.Rollback();
            e.Handled = true;
          }
          else
          {
            DxfArc.Class14.Class543 controlPoints = (DxfArc.Class14.Class543) this.class14_0.ControlPoints;
            WW.Math.Point3D point3D1 = (WW.Math.Point3D) (WW.Math.Point2D) controlPoints.Get(0);
            WW.Math.Point3D point3D2 = (WW.Math.Point3D) (WW.Math.Point2D) controlPoints.Get(1);
            WW.Math.Point3D point3D3 = (WW.Math.Point3D) (WW.Math.Point2D) controlPoints.Get(2);
            if (((DxfEntity.DefaultCreateInteractor) this.Interactor).ControlPointIndex < 1)
            {
              int num1 = (int) MessageBox.Show(Class881.DxfArc_CreateInteractor_WinFormsDrawable_NoCenterMessage);
            }
            else if (((DxfEntity.DefaultCreateInteractor) this.Interactor).ControlPointIndex >= 2 && !(point3D1 == point3D2))
            {
              if (point3D2 == point3D3)
              {
                int num2 = (int) MessageBox.Show(Class881.DxfArc_CreateInteractor_WinFormsDrawable_NoStartAndEndPointIdenticalMessage);
              }
              else
                this.class14_0.Transaction.Commit();
            }
            else
            {
              int num3 = (int) MessageBox.Show(Class881.DxfArc_CreateInteractor_WinFormsDrawable_NoStartPointMessage);
            }
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
          this.class14_0.MouseMoveProcessed += new EventHandler<InteractorMouseEventArgs>(this.method_4);
        }

        private void method_3(object sender, EventArgs e)
        {
          this.fieldEditControl_0.TextBox.TextChanged -= new EventHandler(this.method_5);
          this.fieldEditControl_0.Hide();
          this.control_0.MouseMove -= new MouseEventHandler(this.control_0_MouseMove);
          this.class14_0.MouseMoveProcessed -= new EventHandler<InteractorMouseEventArgs>(this.method_4);
        }

        private void control_0_MouseMove(object sender, MouseEventArgs e)
        {
          this.fieldEditControl_0.Location = this.control_0.PointToScreen(new System.Drawing.Point(e.Location.X + 5, e.Location.Y - 5 - this.fieldEditControl_0.Height));
        }

        private void method_4(object sender, InteractorMouseEventArgs e)
        {
          if (!this.class14_0.EnteredRadius.HasValue)
          {
            this.bool_0 = true;
            try
            {
              this.fieldEditControl_0.TextBox.Text = ((DxfCircle) this.class14_0.Entity).Radius.ToString(e.InteractionContext.LengthFormatString);
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
            this.class14_0.EnteredRadius = new double?();
          }
          else
          {
            double result;
            if (!double.TryParse(this.fieldEditControl_0.TextBox.Text, out result))
              return;
            this.class14_0.EnteredRadius = new double?(result);
            this.class14_0.method_2();
          }
        }
      }
    }

    private class Class542 : IControlPointCollection
    {
      private DxfArc dxfArc_0;
      private bool? nullable_0;
      private bool? nullable_1;

      public Class542(DxfArc owner)
      {
        this.dxfArc_0 = owner;
      }

      public DxfArc Owner
      {
        get
        {
          return this.dxfArc_0;
        }
      }

      public bool? IsClockwise
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

      public bool? DefiniteIsClockwise
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

      public virtual void Set(int index, WW.Math.Point3D value)
      {
        this.method_0(index).SetValue((object) this.dxfArc_0, value);
      }

      public virtual WW.Math.Point3D Get(int index)
      {
        return this.method_0(index).GetValue((object) this.dxfArc_0);
      }

      public string GetDescription(int index)
      {
        return this.method_0(index).Description;
      }

      public PointDisplayType GetDisplayType(int index)
      {
        return this.method_0(index).DisplayType;
      }

      public int Count
      {
        get
        {
          return DxfArc.icontrolPoint_1.Length;
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

      protected IControlPoint method_0(int index)
      {
        bool flag = false;
        if (this.nullable_1.HasValue)
          flag = this.nullable_1.Value;
        else if (this.nullable_0.HasValue)
          flag = this.nullable_0.Value;
        if (!flag)
          return DxfArc.icontrolPoint_1[index];
        return DxfArc.icontrolPoint_2[index];
      }
    }

    internal class Form3 : DxfEntity.DefaultCreateInteractor.WinFormsDrawable
    {
      public Form3(DxfEntity.Interactor interactor)
        : base(interactor)
      {
      }

      public override void Draw(
        PaintEventArgs e,
        GraphicsHelper graphicsHelper,
        InteractionContext context)
      {
        base.Draw(e, graphicsHelper, context);
        DxfArc.Form3.smethod_0((DxfEntity.Interactor.WinFormsDrawable) this, e, graphicsHelper, context);
      }

      internal static void smethod_0(
        DxfEntity.Interactor.WinFormsDrawable drawable,
        PaintEventArgs e,
        GraphicsHelper graphicsHelper,
        InteractionContext context)
      {
        DxfArc entity = (DxfArc) drawable.Interactor.Entity;
        Matrix4D matrix4D = context.ProjectionTransform * entity.Transform;
        PointF pointF1 = matrix4D.TransformToPointF(entity.Center);
        PointF pointF2 = matrix4D.TransformToPointF(entity.Center + entity.Radius * entity.StartVector);
        PointF pointF3 = matrix4D.TransformToPointF(entity.Center + entity.Radius * entity.EndVector);
        if (pointF1 != pointF2)
        {
          e.Graphics.DrawLine(graphicsHelper.DottedPen, pointF1, pointF2);
          PointF point = new PointF((float) (0.5 * ((double) pointF1.X + (double) pointF2.X)), (float) (0.5 * ((double) pointF1.Y + (double) pointF2.Y)));
          e.Graphics.DrawString("R=" + entity.Radius.ToString(context.LengthFormatString) + ", " + (entity.double_3 * (180.0 / System.Math.PI)).ToString(context.AngleFormatString) + "°", graphicsHelper.DefaultFont, graphicsHelper.DefaultBrush, point);
        }
        if (!(pointF2 != pointF3))
          return;
        e.Graphics.DrawLine(graphicsHelper.DottedPen, pointF1, pointF3);
        PointF point1 = new PointF((float) (0.5 * ((double) pointF1.X + (double) pointF3.X)), (float) (0.5 * ((double) pointF1.Y + (double) pointF3.Y)));
        e.Graphics.DrawString((entity.double_4 * (180.0 / System.Math.PI)).ToString(context.AngleFormatString) + "°", graphicsHelper.DefaultFont, graphicsHelper.DefaultBrush, point1);
      }
    }

    public class ThreePointOnArcCreateInteractor : DxfEntity.DefaultCreateInteractor
    {
      public ThreePointOnArcCreateInteractor(DxfEntity entity, ITransaction transaction)
        : base(entity, transaction, (IControlPointCollection) new DxfArc.ThreePointOnArcCreateInteractor.Class544((DxfArc) entity))
      {
      }

      public override IInteractorWinFormsDrawable CreateWinFormsDrawable(
        InteractionContext context,
        Control hostControl)
      {
        return (IInteractorWinFormsDrawable) new DxfArc.ThreePointOnArcCreateInteractor.Form5(this);
      }

      private class Class544 : IControlPointCollection
      {
        private WW.Math.Point3D[] point3D_0 = new WW.Math.Point3D[3];
        private DxfArc dxfArc_0;

        public Class544(DxfArc arc)
        {
          this.dxfArc_0 = arc;
        }

        public void Set(int index, WW.Math.Point3D value)
        {
          this.point3D_0[index] = value;
          if (index != 2)
            return;
          this.dxfArc_0.InitializeFromThreePoints((WW.Math.Point3D) (WW.Math.Point2D) this.point3D_0[0], (WW.Math.Point3D) (WW.Math.Point2D) this.point3D_0[1], (WW.Math.Point3D) (WW.Math.Point2D) this.point3D_0[2], true);
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
              return Class881.DxfArc_StartPoint_Name;
            case 1:
              return Class881.DxfArc_MidPoint_Name;
            case 2:
              return Class881.DxfArc_EndPoint_Name;
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
            return 3;
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

      internal class Form5 : DxfArc.Form3
      {
        public Form5(DxfArc.ThreePointOnArcCreateInteractor interactor)
          : base((DxfEntity.Interactor) interactor)
        {
        }

        public override void Draw(
          PaintEventArgs e,
          GraphicsHelper graphicsHelper,
          InteractionContext context)
        {
          base.Draw(e, graphicsHelper, context);
          DxfArc.ThreePointOnArcCreateInteractor interactor = (DxfArc.ThreePointOnArcCreateInteractor) this.Interactor;
          for (int index = 0; index < interactor.ControlPointIndex; ++index)
            graphicsHelper.DrawEditHandle(e.Graphics, graphicsHelper.DefaultPen, context.ProjectionTransform.TransformTo2D(interactor.ControlPoints.Get(index)));
        }
      }
    }

    public class TwoPointWithRadiusCreateInteractor : DxfEntity.DefaultCreateInteractor
    {
      public event EventHandler<InteractorMouseEventArgs> MouseMoveProcessed;

      public TwoPointWithRadiusCreateInteractor(DxfEntity entity, ITransaction transaction)
        : base(entity, transaction, (IControlPointCollection) new DxfArc.TwoPointWithRadiusCreateInteractor.Class545((DxfArc) entity))
      {
      }

      public double? EnteredRadius
      {
        get
        {
          return ((DxfArc.TwoPointWithRadiusCreateInteractor.Class545) this.ControlPoints).EnteredRadius;
        }
        set
        {
          ((DxfArc.TwoPointWithRadiusCreateInteractor.Class545) this.ControlPoints).EnteredRadius = value;
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
        ((DxfCircle) this.Entity).Radius = this.EnteredRadius.Value;
        ((DxfArc.TwoPointWithRadiusCreateInteractor.Class545) this.ControlPoints).method_0();
        this.OnEntityChanged(new EntityEventArgs(this.Entity));
      }

      public override IInteractorWinFormsDrawable CreateWinFormsDrawable(
        InteractionContext context,
        Control hostControl)
      {
        return (IInteractorWinFormsDrawable) new DxfArc.TwoPointWithRadiusCreateInteractor.Form6(this, hostControl);
      }

      private class Class545 : IControlPointCollection
      {
        private WW.Math.Point3D[] point3D_0 = new WW.Math.Point3D[3];
        private DxfArc dxfArc_0;
        private double? nullable_0;

        public Class545(DxfArc arc)
        {
          this.dxfArc_0 = arc;
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
          bool flag = false;
          WW.Math.Point3D startPoint = (WW.Math.Point3D) (WW.Math.Point2D) this.point3D_0[0];
          WW.Math.Point3D endPoint = (WW.Math.Point3D) (WW.Math.Point2D) this.point3D_0[1];
          WW.Math.Point3D midPointHint = (WW.Math.Point3D) (WW.Math.Point2D) this.point3D_0[2];
          if (this.nullable_0.HasValue && startPoint != endPoint && (midPointHint != startPoint && endPoint != midPointHint))
            flag = this.dxfArc_0.InitializeFromThreePointsAndRadius(startPoint, midPointHint, endPoint, this.nullable_0.Value, true);
          return flag;
        }

        public void Set(int index, WW.Math.Point3D value)
        {
          this.point3D_0[index] = value;
          if (index != 2 || !this.nullable_0.HasValue)
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
              return Class881.DxfArc_StartPoint_Name;
            case 1:
              return Class881.DxfArc_EndPoint_Name;
            case 2:
              return Class675.Radius;
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
            return 3;
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

      internal class Form6 : DxfArc.Form3
      {
        private DxfArc.TwoPointWithRadiusCreateInteractor twoPointWithRadiusCreateInteractor_0;
        private FieldEditControl fieldEditControl_0;
        private Control control_0;
        private bool bool_0;

        public Form6(
          DxfArc.TwoPointWithRadiusCreateInteractor interactor,
          Control hostControl)
          : base((DxfEntity.Interactor) interactor)
        {
          this.twoPointWithRadiusCreateInteractor_0 = interactor;
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
          DxfArc.TwoPointWithRadiusCreateInteractor interactor = (DxfArc.TwoPointWithRadiusCreateInteractor) this.Interactor;
          for (int index = 0; index < interactor.ControlPointIndex; ++index)
            graphicsHelper.DrawEditHandle(e.Graphics, graphicsHelper.DefaultPen, context.ProjectionTransform.TransformTo2D(interactor.ControlPoints.Get(index)));
        }

        private void method_0(object sender, KeyPressEventArgs e)
        {
          if (e.KeyChar != '\r' && e.KeyChar != '\t')
          {
            if (e.KeyChar != '\x001B')
              return;
            this.twoPointWithRadiusCreateInteractor_0.Transaction.Rollback();
            e.Handled = true;
          }
          else
          {
            DxfArc.TwoPointWithRadiusCreateInteractor.Class545 controlPoints = (DxfArc.TwoPointWithRadiusCreateInteractor.Class545) this.twoPointWithRadiusCreateInteractor_0.ControlPoints;
            WW.Math.Point3D point3D1 = (WW.Math.Point3D) (WW.Math.Point2D) controlPoints.Get(0);
            WW.Math.Point3D point3D2 = (WW.Math.Point3D) (WW.Math.Point2D) controlPoints.Get(1);
            WW.Math.Point3D point3D3 = (WW.Math.Point3D) (WW.Math.Point2D) controlPoints.Get(2);
            if (((DxfEntity.DefaultCreateInteractor) this.Interactor).ControlPointIndex < 1)
            {
              int num1 = (int) MessageBox.Show(Class881.DxfArc_TwoPointWithRadiusCreateInteractor_WinFormsDrawable_NoStartPointMessage);
            }
            else if (((DxfEntity.DefaultCreateInteractor) this.Interactor).ControlPointIndex >= 2 && !(point3D1 == point3D2))
            {
              if (!(point3D2 == point3D3) && !(point3D1 == point3D3))
              {
                if (!controlPoints.EnteredRadius.HasValue)
                {
                  int num2 = (int) MessageBox.Show(Class881.DxfArc_TwoPointWithRadiusCreateInteractor_WinFormsDrawable_NoRadiusMessage);
                }
                else if (controlPoints.EnteredRadius.Value < 0.5 * (point3D2 - point3D1).GetLength())
                {
                  int num3 = (int) MessageBox.Show(Class881.DxfArc_TwoPointWithRadiusCreateInteractor_WinFormsDrawable_IllegalRadiusMessage);
                }
                else if (controlPoints.method_0())
                {
                  this.twoPointWithRadiusCreateInteractor_0.Transaction.Commit();
                }
                else
                {
                  int num4 = (int) MessageBox.Show(Class881.DxfArc_TwoPointWithRadiusCreateInteractor_WinFormsDrawable_ArcNotInitializedMessage);
                }
              }
              else
              {
                int num5 = (int) MessageBox.Show(Class881.DxfArc_TwoPointWithRadiusCreateInteractor_WinFormsDrawable_NoMidPointHintMessage);
              }
            }
            else
            {
              int num6 = (int) MessageBox.Show(Class881.DxfArc_TwoPointWithRadiusCreateInteractor_WinFormsDrawable_NoEndPointMessage);
            }
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
          this.twoPointWithRadiusCreateInteractor_0.MouseMoveProcessed += new EventHandler<InteractorMouseEventArgs>(this.method_4);
        }

        private void method_3(object sender, EventArgs e)
        {
          this.fieldEditControl_0.TextBox.TextChanged -= new EventHandler(this.method_5);
          this.fieldEditControl_0.Hide();
          this.control_0.MouseMove -= new MouseEventHandler(this.control_0_MouseMove);
          this.twoPointWithRadiusCreateInteractor_0.MouseMoveProcessed -= new EventHandler<InteractorMouseEventArgs>(this.method_4);
        }

        private void control_0_MouseMove(object sender, MouseEventArgs e)
        {
          this.fieldEditControl_0.Location = this.control_0.PointToScreen(new System.Drawing.Point(e.Location.X + 5, e.Location.Y - 5 - this.fieldEditControl_0.Height));
        }

        private void method_4(object sender, InteractorMouseEventArgs e)
        {
          if (!this.twoPointWithRadiusCreateInteractor_0.EnteredRadius.HasValue)
          {
            this.bool_0 = true;
            try
            {
              this.fieldEditControl_0.TextBox.Text = ((DxfCircle) this.twoPointWithRadiusCreateInteractor_0.Entity).Radius.ToString(e.InteractionContext.LengthFormatString);
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
            this.twoPointWithRadiusCreateInteractor_0.EnteredRadius = new double?();
          }
          else
          {
            double result;
            if (!double.TryParse(this.fieldEditControl_0.TextBox.Text, out result))
              return;
            this.twoPointWithRadiusCreateInteractor_0.EnteredRadius = new double?(result);
            this.twoPointWithRadiusCreateInteractor_0.method_2();
          }
        }
      }
    }

    private class Class11 : DxfEntity.DefaultEditInteractor
    {
      public Class11(DxfEntity entity)
        : base(entity)
      {
      }

      public override IInteractorWinFormsDrawable CreateWinFormsDrawable(
        InteractionContext context,
        Control hostControl)
      {
        return (IInteractorWinFormsDrawable) new DxfArc.Class11.Form1(this);
      }

      private class Form1 : DxfEntity.EditInteractor.WinFormsDrawable
      {
        public Form1(DxfArc.Class11 interactor)
          : base((DxfEntity.EditInteractor) interactor)
        {
        }

        public override void Draw(
          PaintEventArgs e,
          GraphicsHelper graphicsHelper,
          InteractionContext context)
        {
          base.Draw(e, graphicsHelper, context);
          DxfArc.Form3.smethod_0((DxfEntity.Interactor.WinFormsDrawable) this, e, graphicsHelper, context);
        }
      }
    }
  }
}
