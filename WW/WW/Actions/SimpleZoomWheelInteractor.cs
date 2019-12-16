// Decompiled with JetBrains decompiler
// Type: WW.Actions.SimpleZoomWheelInteractor
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using WW.Math;

namespace WW.Actions
{
  public class SimpleZoomWheelInteractor : SimpleInteractor
  {
    private double double_1 = 1.05;
    public const double DefaultScalingPerClick = 1.05;
    private const double double_0 = 120.0;

    public event EventHandler FinishedSetting;

    public SimpleZoomWheelInteractor(
      SimpleTransformationProviderBase transformationProvider)
      : base(transformationProvider)
    {
    }

    public double ScalingPerClick
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

    public override bool ProcessMouseWheel(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (this.IsActive)
      {
        Point2D center = this.TransformationProvider.ViewWindow.Center;
        double dx = center.X - e.Position.X;
        double dy = center.Y - e.Position.Y;
        this.TransformationProvider.PanView(dx, dy);
        this.TransformationProvider.ViewScaling *= System.Math.Pow(this.double_1, (double) -e.MouseWheelDelta / 120.0);
        this.TransformationProvider.PanView(-dx, -dy);
      }
      return this.IsActive;
    }

    protected void OnFinishedSetting(EventArgs e)
    {
      if (this.FinishedSetting == null)
        return;
      this.FinishedSetting((object) this, e);
    }
  }
}
