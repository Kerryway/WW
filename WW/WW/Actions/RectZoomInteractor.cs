// Decompiled with JetBrains decompiler
// Type: WW.Actions.RectZoomInteractor
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
  public class RectZoomInteractor : Interactor
  {
    public static readonly ArgbColor RectangleColor = ArgbColors.Red;
    private const int int_0 = 4;
    private Point2D point2D_0;
    private Point2D point2D_1;
    private Size2D size2D_0;

    public event EventHandler RectangleChanged;

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
        return Strings.GetString("WW_Actions_RectZoomInteractor_UserHint");
      }
    }

    public override bool ProcessMouseButtonDown(
      CanonicalMouseEventArgs e,
      InteractionContext context)
    {
      if (this.IsActive)
      {
        this.point2D_1 = this.point2D_0 = e.Position;
        this.size2D_0 = context.CanvasRectangle.Size;
      }
      return true;
    }

    public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (this.IsActive)
      {
        this.point2D_1 = e.Position;
        this.OnRectangleChanged((EventArgs) e);
      }
      return true;
    }

    public override bool ProcessMouseButtonUp(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (this.IsActive)
        this.Deactivate();
      return true;
    }

    public void PropagateTo(IScaler scaler, ITranslator translator)
    {
      if (!this.ValidForZoom)
        return;
      Rectangle2D normalizedZoomRectangle = this.NormalizedZoomRectangle;
      Point2D center = normalizedZoomRectangle.Center;
      Point2D point = (Transformation3D.Translation(translator.Translation) * Transformation3D.Scaling2D(scaler.ScaleFactor)).GetInverse().Transform(center);
      double num = 2.0 / System.Math.Max(System.Math.Abs(normalizedZoomRectangle.Width), System.Math.Abs(normalizedZoomRectangle.Height));
      scaler.ScaleFactor *= num;
      Point2D point2D = (Transformation3D.Translation(translator.Translation) * Transformation3D.Scaling2D(scaler.ScaleFactor)).Transform(point);
      translator.Translation += center - point2D;
    }

    protected virtual void OnRectangleChanged(EventArgs e)
    {
      if (this.RectangleChanged == null)
        return;
      this.RectangleChanged((object) this, e);
    }

    private Point2D method_0(Point2D screenCoord)
    {
      double num1 = 0.5 * this.size2D_0.X;
      double num2 = 0.5 * this.size2D_0.Y;
      return new Point2D((screenCoord.X - num1) / num1, -(screenCoord.Y - num2) / num2);
    }

    public class WinFormsDrawable : Interactor.WinFormsDrawable
    {
      private readonly RectZoomInteractor rectZoomInteractor_0;

      public WinFormsDrawable(RectZoomInteractor interactor)
      {
        this.rectZoomInteractor_0 = interactor;
      }

      public override void Draw(
        PaintEventArgs e,
        GraphicsHelper graphicsHelper,
        InteractionContext context)
      {
        if (!this.rectZoomInteractor_0.IsActive)
          return;
        Rectangle2D zoomRectangle = this.rectZoomInteractor_0.ZoomRectangle;
        using (Pen pen = new Pen((Color) RectZoomInteractor.RectangleColor))
          e.Graphics.DrawRectangle(pen, (int) System.Math.Round(zoomRectangle.X1), (int) System.Math.Round(zoomRectangle.Y1), (int) System.Math.Round(zoomRectangle.Width), (int) System.Math.Round(zoomRectangle.Height));
      }
    }
  }
}
