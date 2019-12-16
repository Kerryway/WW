// Decompiled with JetBrains decompiler
// Type: WW.Actions.SimplePanInteractor
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using WW.Math;

namespace WW.Actions
{
  public class SimplePanInteractor : SimpleInteractor
  {
    private Point2D point2D_0;

    public SimplePanInteractor(
      SimpleTransformationProviderBase transformationProvider)
      : base(transformationProvider)
    {
    }

    public override bool ProcessMouseButtonDown(
      CanonicalMouseEventArgs e,
      InteractionContext context)
    {
      if (this.IsActive)
        this.point2D_0 = e.Position;
      return this.IsActive;
    }

    public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (this.IsActive)
      {
        Point2D position = e.Position;
        Vector2D vector2D = position - this.point2D_0;
        this.TransformationProvider.PanView(vector2D.X, vector2D.Y);
        this.point2D_0 = position;
      }
      return this.IsActive;
    }

    public override bool ProcessMouseButtonUp(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (this.IsActive)
        this.Deactivate();
      return this.IsActive;
    }
  }
}
