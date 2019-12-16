// Decompiled with JetBrains decompiler
// Type: WW.Actions.SimpleRectZoomInteractor
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
  public class SimpleRectZoomInteractor : SimpleInteractor
  {
    public static readonly ArgbColor RectangleColor = ArgbColors.Red;
    private const int int_0 = 4;
    private Point2D point2D_0;
    private Point2D point2D_1;

    public event EventHandler RectangleChanged;

    public SimpleRectZoomInteractor(
      SimpleTransformationProviderBase transformationProvider)
      : base(transformationProvider)
    {
    }

    public Rectangle2D ZoomRectangle
    {
      get
      {
        return new Rectangle2D(System.Math.Min(this.point2D_0.X, this.point2D_1.X), System.Math.Min(this.point2D_0.Y, this.point2D_1.Y), System.Math.Max(this.point2D_0.X, this.point2D_1.X), System.Math.Max(this.point2D_0.Y, this.point2D_1.Y));
      }
    }

    public Rectangle2D NormalizedZoomRectangle
    {
      get
      {
        Point2D point2D1 = this.method_0(this.point2D_0);
        Point2D point2D2 = this.method_0(this.point2D_1);
        return new Rectangle2D(System.Math.Min(point2D1.X, point2D2.X), System.Math.Min(point2D1.Y, point2D2.Y), System.Math.Max(point2D1.X, point2D2.X), System.Math.Max(point2D1.Y, point2D2.Y));
      }
    }

    public bool ValidForZoom
    {
      get
      {
        Vector2D vector2D = this.point2D_1 - this.point2D_0;
        return System.Math.Max(System.Math.Abs(vector2D.X), System.Math.Abs(vector2D.Y)) >= 4.0;
      }
    }

    public override string UserHint
    {
      get
      {
        return Strings.GetString("WW_Actions_SimpleRectZoomInteractor_UserHint");
      }
    }

    public override bool ProcessMouseButtonDown(
      CanonicalMouseEventArgs e,
      InteractionContext context)
    {
      if (this.IsActive)
        this.point2D_1 = this.point2D_0 = e.Position;
      return this.IsActive;
    }

    public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (this.IsActive)
      {
        this.point2D_1 = e.Position;
        this.OnRectangleChanged((EventArgs) e);
      }
      return this.IsActive;
    }

    public override bool ProcessMouseButtonUp(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (this.IsActive)
      {
        if (this.ValidForZoom)
        {
          Rectangle2D zoomRectangle = this.ZoomRectangle;
          Vector2D vector2D = this.TransformationProvider.ViewWindow.Center - zoomRectangle.Center;
          double num = System.Math.Min(this.TransformationProvider.ViewWindow.Width / zoomRectangle.Width, this.TransformationProvider.ViewWindow.Height / zoomRectangle.Height);
          this.TransformationProvider.PanView(vector2D.X, vector2D.Y);
          this.TransformationProvider.ViewScaling /= num;
        }
        this.Deactivate();
      }
      return this.IsActive;
    }

    protected virtual void OnRectangleChanged(EventArgs e)
    {
      if (this.RectangleChanged == null)
        return;
      this.RectangleChanged((object) this, e);
    }

    private Point2D method_0(Point2D screenCoord)
    {
      double num1 = 0.5 * this.TransformationProvider.ViewWindow.Width;
      double num2 = 0.5 * this.TransformationProvider.ViewWindow.Height;
      return new Point2D((screenCoord.X - num1) / num1, -(screenCoord.Y - num2) / num2);
    }

    public class WinFormsDrawable : Interactor.WinFormsDrawable
    {
      private readonly SimpleRectZoomInteractor simpleRectZoomInteractor_0;

      public WinFormsDrawable(SimpleRectZoomInteractor interactor)
      {
        this.simpleRectZoomInteractor_0 = interactor;
      }

      public override void Draw(
        PaintEventArgs e,
        GraphicsHelper graphicsHelper,
        InteractionContext context)
      {
        if (!this.simpleRectZoomInteractor_0.IsActive)
          return;
        Rectangle2D zoomRectangle = this.simpleRectZoomInteractor_0.ZoomRectangle;
        using (Pen pen = new Pen((Color) SimpleRectZoomInteractor.RectangleColor))
          e.Graphics.DrawRectangle(pen, (int) System.Math.Round(zoomRectangle.X1), (int) System.Math.Round(zoomRectangle.Y1), (int) System.Math.Round(zoomRectangle.Width), (int) System.Math.Round(zoomRectangle.Height));
      }
    }
  }
}
