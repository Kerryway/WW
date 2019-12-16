// Decompiled with JetBrains decompiler
// Type: WW.Actions.ZoomWheelInteractor
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Actions
{
  public class ZoomWheelInteractor : Interactor, IScaler
  {
    private double double_0 = 1.0;

    public event EventHandler BeforeScaleFactorChanged;

    public event EventHandler ScaleFactorChanged;

    public double ScaleFactor
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

    public override bool ProcessMouseWheel(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (this.IsActive)
      {
        this.OnBeforeScaleFactorChanged((EventArgs) e);
        int num =System.Math.Sign(e.MouseWheelDelta);
        if (num > 0)
          this.double_0 *= 1.1;
        else if (num < 0)
          this.double_0 /= 1.1;
        this.OnScaleFactorChanged((EventArgs) e);
      }
      return this.IsActive;
    }

    public override object GetStateForStore()
    {
      return (object) this.ScaleFactor;
    }

    public override void SetStateFromStore(object state)
    {
      this.ScaleFactor = (double) state;
    }

    public override void ResetState()
    {
      this.ScaleFactor = 1.0;
    }

    protected virtual void OnBeforeScaleFactorChanged(EventArgs e)
    {
      if (this.BeforeScaleFactorChanged == null)
        return;
      this.BeforeScaleFactorChanged((object) this, e);
    }

    protected virtual void OnScaleFactorChanged(EventArgs e)
    {
      if (this.ScaleFactorChanged == null)
        return;
      this.ScaleFactorChanged((object) this, e);
    }
  }
}
