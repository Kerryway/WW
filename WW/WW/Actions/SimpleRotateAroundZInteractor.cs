// Decompiled with JetBrains decompiler
// Type: WW.Actions.SimpleRotateAroundZInteractor
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using WW.Math;

namespace WW.Actions
{
  public class SimpleRotateAroundZInteractor : SimpleInteractor
  {
    private Point2D? nullable_0;

    public SimpleRotateAroundZInteractor(
      SimpleTransformationProviderBase transformationProvider)
      : base(transformationProvider)
    {
    }

    public override bool ProcessMouseButtonDown(
      CanonicalMouseEventArgs e,
      InteractionContext context)
    {
      if (this.IsActive)
        this.method_0(e, context);
      return this.IsActive;
    }

    public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (this.IsActive)
        this.method_0(e, context);
      return this.IsActive;
    }

    public override bool ProcessMouseButtonUp(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (this.IsActive)
      {
        this.Deactivate();
        this.nullable_0 = new Point2D?();
      }
      return this.IsActive;
    }

    private void method_0(CanonicalMouseEventArgs e, InteractionContext context)
    {
      Point2D point2D = new Point2D(0.5 * context.CanvasRectangle.Size.X, 0.5 * context.CanvasRectangle.Size.Y);
      Point2D position = e.Position;
      Vector2D vector2D1 = position - point2D;
      if (!(vector2D1 != Vector2D.Zero))
        return;
      double num1 = System.Math.Atan2(-vector2D1.Y, vector2D1.X);
      if (this.nullable_0.HasValue)
      {
        Vector2D vector2D2 = this.nullable_0.Value - point2D;
        double num2 = System.Math.Atan2(-vector2D2.Y, vector2D2.X);
        if (num1 != num2)
          this.TransformationProvider.ModelOrientation *= QuaternionD.FromAxisAngle(Vector3D.ZAxis, num1 - num2);
      }
      this.nullable_0 = new Point2D?(position);
    }
  }
}
