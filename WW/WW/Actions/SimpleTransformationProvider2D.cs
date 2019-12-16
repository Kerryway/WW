// Decompiled with JetBrains decompiler
// Type: WW.Actions.SimpleTransformationProvider2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Actions
{
  public class SimpleTransformationProvider2D : SimpleTransformationProviderBase
  {
    public SimpleTransformationProvider2D()
    {
      this.ModelBoundsFitType = ModelBoundsFitType.BoundsXY;
    }

    public override double ViewScalingSize
    {
      get
      {
        double num = 1.0;
        if (this.modelBounds != null && this.modelBounds.Initialized)
        {
          Vector3D delta = this.modelBounds.Delta;
          switch (this.ModelBoundsFitType)
          {
            case ModelBoundsFitType.BoundsDiagonal3D:
              num = 0.5 * delta.GetLength();
              break;
            case ModelBoundsFitType.BoundsDiagonalXY:
              num = 0.5 * new Vector2D(delta.X, delta.Y).GetLength();
              break;
            case ModelBoundsFitType.BoundsXY:
              Rectangle2D effectiveViewWindow = this.EffectiveViewWindow;
              num = effectiveViewWindow.Height * this.modelBounds.Delta.X <= effectiveViewWindow.Width * this.modelBounds.Delta.Y ? 0.5 * this.modelBounds.Delta.Y * System.Math.Min(1.0, effectiveViewWindow.Width / effectiveViewWindow.Height) : 0.5 * this.modelBounds.Delta.X * System.Math.Min(1.0, effectiveViewWindow.Height / effectiveViewWindow.Width);
              break;
          }
        }
        return num;
      }
    }

    public override Matrix4D CanonicalProjectionTransform
    {
      get
      {
        if (this.viewWindow.Width == 0.0 || this.viewWindow.Height == 0.0)
          return Matrix4D.Identity;
        Rectangle2D effectiveViewWindow = this.EffectiveViewWindow;
        double x = 1.0;
        double y = 1.0;
        if (effectiveViewWindow.Width > effectiveViewWindow.Height)
          x *= effectiveViewWindow.Height / effectiveViewWindow.Width;
        else
          y *= effectiveViewWindow.Width / effectiveViewWindow.Height;
        double num = this.viewScaling * this.ViewScalingSize;
        return Transformation4D.GetScaleAndTranslateTransform(Point2D.Zero - new Vector2D(num, num), Point2D.Zero + new Vector2D(num, num), new Point2D(-x, -y), new Point2D(x, y));
      }
    }

    public override Matrix4D WorldTransform
    {
      get
      {
        return this.ModelOrientationTransform * this.ModelScalingTransform * this.ModelTranslationTransform;
      }
    }

    public override void ResetTransforms()
    {
      this.ModelScaling = 1.0;
      this.ModelOrientation = QuaternionD.Identity;
      if (this.modelBounds.Initialized && this.ViewWindow.Height != 0.0 && this.ViewWindow.Width != 0.0)
        this.ModelTranslation = -(Vector3D) this.modelBounds.Center;
      else
        this.ModelTranslation = Vector3D.Zero;
      this.viewScaling = 1.0;
      this.OnTransformsChanged(EventArgs.Empty);
    }

    public override object Clone()
    {
      SimpleTransformationProvider2D transformationProvider2D = new SimpleTransformationProvider2D();
      transformationProvider2D.CopyFrom(this);
      return (object) transformationProvider2D;
    }

    public void CopyFrom(SimpleTransformationProvider2D from)
    {
      this.CopyFrom((SimpleTransformationProviderBase) from);
    }
  }
}
