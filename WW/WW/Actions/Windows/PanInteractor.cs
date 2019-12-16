// Decompiled with JetBrains decompiler
// Type: WW.Actions.Windows.PanInteractor
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using WW.Math;

namespace WW.Actions.Windows
{
  public class PanInteractor : Interactor, ITranslator
  {
    private Vector2D vector2D_0 = Vector2D.Zero;
    private Vector2D vector2D_1 = Vector2D.Zero;
    private Point2D point2D_0;

    public event EventHandler TranslationChanged;

    public Vector2D Translation
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

    public override bool ProcessMouseButtonDown(
      CanonicalMouseEventArgs e,
      InteractionContext context)
    {
      if (this.IsActive)
      {
        this.vector2D_1 = this.vector2D_0;
        this.point2D_0 = e.Position;
      }
      return true;
    }

    public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (this.IsActive)
      {
        Vector2D vector2D = e.Position - this.point2D_0;
        this.vector2D_0 = this.vector2D_1 + new Vector2D(vector2D.X * 2.0 / context.CanvasRectangle.Size.X, -vector2D.Y * 2.0 / context.CanvasRectangle.Size.Y);
        this.OnTranslationChanged((EventArgs) e);
      }
      return true;
    }

    public override bool ProcessMouseButtonUp(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (this.IsActive)
        this.Deactivate();
      return true;
    }

    public override object GetStateForStore()
    {
      return (object) this.vector2D_0;
    }

    public override void SetStateFromStore(object state)
    {
      this.Translation = (Vector2D) state;
    }

    public override void ResetState()
    {
      this.Translation = Vector2D.Zero;
    }

    protected virtual void OnTranslationChanged(EventArgs e)
    {
      if (this.TranslationChanged == null)
        return;
      this.TranslationChanged((object) this, e);
    }
  }
}
