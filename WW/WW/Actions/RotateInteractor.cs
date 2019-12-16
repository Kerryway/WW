// Decompiled with JetBrains decompiler
// Type: WW.Actions.RotateInteractor
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Drawing;
using System.Windows.Forms;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Actions
{
  public class RotateInteractor : Interactor
  {
    public static readonly ArgbColor RotationCircleColor = ArgbColors.Red;
    private QuaternionD quaternionD_0 = QuaternionD.Identity;
    private QuaternionD quaternionD_1 = QuaternionD.Identity;
    private const double double_0 = 100.0;
    private Point2D point2D_0;
    private bool bool_2;

    public event EventHandler OrientationChanged;

    public QuaternionD Orientation
    {
      get
      {
        return this.quaternionD_0;
      }
      set
      {
        this.quaternionD_0 = value;
      }
    }

    public override string UserHint
    {
      get
      {
        return Strings.GetString("WW_Actions_RotateInteractor_UserHint");
      }
    }

    public override bool ProcessMouseButtonDown(
      CanonicalMouseEventArgs e,
      InteractionContext context)
    {
      if (this.IsActive)
      {
        this.quaternionD_1 = this.quaternionD_0;
        Point2D point2D = this.method_0(context.CanvasRectangle.Size);
        this.point2D_0 = e.Position;
        Vector2D vector2D = this.point2D_0 - point2D;
        this.bool_2 = System.Math.Sqrt(vector2D.X * vector2D.X + vector2D.Y * vector2D.Y) <= (double) this.GetRotationCircleRadius(context.CanvasRectangle.Size);
      }
      return true;
    }

    public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (this.IsActive)
      {
        Point2D position = e.Position;
        QuaternionD quaternionD = this.quaternionD_1;
        if (this.bool_2)
        {
          Vector2D vector2D = position - this.point2D_0;
          if (vector2D != Vector2D.Zero)
          {
            double num = System.Math.Sqrt(vector2D.X * vector2D.X + vector2D.Y * vector2D.Y);
            Vector3D axis = new Vector3D(vector2D.Y, vector2D.X, 0.0);
            axis.Normalize();
            quaternionD = QuaternionD.FromAxisAngle(axis, num / 100.0) * quaternionD;
          }
        }
        else
        {
          Point2D point2D = this.method_0(context.CanvasRectangle.Size);
          Vector2D vector2D1 = this.point2D_0 - point2D;
          double num1 = System.Math.Atan2(vector2D1.Y, vector2D1.X);
          Vector2D vector2D2 = position - point2D;
          double num2 = System.Math.Atan2(vector2D2.Y, vector2D2.X) - num1;
          quaternionD = QuaternionD.FromAxisAngle(Vector3D.ZAxis, -num2) * quaternionD;
        }
        quaternionD.Normalize();
        this.quaternionD_0 = quaternionD;
        this.OnOrientationChanged((EventArgs) e);
      }
      return true;
    }

    public override bool ProcessMouseButtonUp(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (this.IsActive)
        this.Deactivate();
      return true;
    }

    public float GetRotationCircleRadius(Size2D uiElementSize)
    {
      return (float) System.Math.Min(uiElementSize.X, uiElementSize.Y) * 0.4f;
    }

    public override object GetStateForStore()
    {
      return (object) this.Orientation;
    }

    public override void SetStateFromStore(object state)
    {
      this.Orientation = (QuaternionD) state;
    }

    public override void ResetState()
    {
      this.Orientation = QuaternionD.Identity;
    }

    protected virtual void OnOrientationChanged(EventArgs e)
    {
      if (this.OrientationChanged == null)
        return;
      this.OrientationChanged((object) this, e);
    }

    private Point2D method_0(Size2D uiElementSize)
    {
      return new Point2D(0.5 * uiElementSize.X, 0.5 * uiElementSize.Y);
    }

    public class WinFormsDrawable : Interactor.WinFormsDrawable
    {
      private readonly RotateInteractor rotateInteractor_0;

      public WinFormsDrawable(RotateInteractor interactor)
      {
        this.rotateInteractor_0 = interactor;
      }

      public override void Draw(
        PaintEventArgs e,
        GraphicsHelper graphicsHelper,
        InteractionContext context)
      {
        if (!this.rotateInteractor_0.IsActive || !(context.CanvasRectangle != Rectangle2D.Empty))
          return;
        float rotationCircleRadius = this.rotateInteractor_0.GetRotationCircleRadius(context.CanvasRectangle.Size);
        using (Pen pen = new Pen((Color) RotateInteractor.RotationCircleColor))
        {
          Point2D center = context.CanvasRectangle.Center;
          RectangleF rect = new RectangleF((float) center.X - rotationCircleRadius, (float) center.Y - rotationCircleRadius, 2f * rotationCircleRadius, 2f * rotationCircleRadius);
          e.Graphics.DrawArc(pen, rect, 0.0f, 6.283185f);
        }
      }
    }
  }
}
