// Decompiled with JetBrains decompiler
// Type: WW.Actions.SimpleTransformationProvider3D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Actions
{
  public class SimpleTransformationProvider3D : SimpleTransformationProviderBase
  {
    private bool bool_1;
    private double double_2;
    private double double_3;
    private double double_4;

    public virtual bool IsPerspective
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        if (value == this.bool_1)
          return;
        this.bool_1 = value;
        this.OnTransformsChanged((EventArgs) null);
      }
    }

    public override Matrix4D CanonicalProjectionTransform
    {
      get
      {
        if (this.double_3 >= this.double_4)
          return Matrix4D.Identity;
        Rectangle2D effectiveViewWindow = this.EffectiveViewWindow;
        double width = effectiveViewWindow.Width;
        double height = effectiveViewWindow.Height;
        if (this.bool_1)
        {
          double num1 = this.double_3 / this.double_2;
          double viewScalingSize = this.ViewScalingSize;
          double num2;
          double num3;
          if (height > width)
          {
            num2 = num1 * viewScalingSize;
            num3 = num1 * viewScalingSize * height / width;
          }
          else
          {
            num2 = num1 * viewScalingSize * width / height;
            num3 = num1 * viewScalingSize;
          }
          double right = num2 * this.viewScaling;
          double top = num3 * this.viewScaling;
          return Transformation4D.GetPerspectiveProjectionTransform(-right, right, -top, top, this.double_3, this.double_4);
        }
        double viewScalingSize1 = this.ViewScalingSize;
        double num4 = 2.0 * viewScalingSize1 * this.viewScaling;
        double num5 = 2.0 * viewScalingSize1 * this.viewScaling;
        if (width > height)
          num4 *= width / height;
        else
          num5 *= height / width;
        return Transformation4D.GetOrthographicProjectionTransform(-0.5 * num4, 0.5 * num4, -0.5 * num5, 0.5 * num5, this.double_3, this.double_4);
      }
    }

    public virtual double CameraDistance
    {
      get
      {
        return this.double_2;
      }
      set
      {
        if (value == this.double_2)
          return;
        this.double_2 = value;
        this.OnTransformsChanged((EventArgs) null);
      }
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
              num = effectiveViewWindow.Height * this.modelBounds.Delta.X <= effectiveViewWindow.Width * this.modelBounds.Delta.Y ? 0.5 * this.modelBounds.Delta.Y * System.Math.Min(1.0, effectiveViewWindow.Width / effectiveViewWindow.Height) * this.viewWindow.Height / effectiveViewWindow.Height : 0.5 * this.modelBounds.Delta.X * System.Math.Min(1.0, effectiveViewWindow.Height / effectiveViewWindow.Width) * this.viewWindow.Width / effectiveViewWindow.Width;
              break;
          }
        }
        return num;
      }
    }

    public virtual Matrix4D CameraDistanceTransform
    {
      get
      {
        return Transformation4D.Translation(0.0, 0.0, -this.CameraDistance);
      }
    }

    public virtual double FrontClipDistance
    {
      get
      {
        return this.double_3;
      }
      set
      {
        if (value == this.double_3)
          return;
        this.double_3 = value;
        this.OnTransformsChanged((EventArgs) null);
      }
    }

    public virtual double BackClipDistance
    {
      get
      {
        return this.double_4;
      }
      set
      {
        if (value == this.double_4)
          return;
        this.double_4 = value;
        this.OnTransformsChanged((EventArgs) null);
      }
    }

    public override Matrix4D WorldTransform
    {
      get
      {
        return this.CameraDistanceTransform * this.ModelOrientationTransform * this.ModelScalingTransform * this.ModelTranslationTransform;
      }
    }

    public override void ResetTransforms()
    {
      this.ModelScaling = 1.0;
      this.ModelOrientation = QuaternionD.Identity;
      if (this.modelBounds.Initialized)
      {
        this.CameraDistance = 2.0 * this.modelBounds.Delta.GetLength();
        this.double_3 = 0.4 * this.double_2;
        this.double_4 = 1.6 * this.double_2;
        this.ModelTranslation = -(Vector3D) this.modelBounds.Center;
      }
      else
      {
        this.ModelTranslation = Vector3D.Zero;
        double num = 0.0;
        this.double_4 = 0.0;
        this.double_3 = num;
      }
      this.OnTransformsChanged(EventArgs.Empty);
    }

    public override void StoreStateTo(IDictionary<string, object> mapping)
    {
      base.StoreStateTo(mapping);
      mapping["cameraDistance"] = (object) this.double_2;
      mapping["frontClipDistance"] = (object) this.double_3;
      mapping["backClipDistance"] = (object) this.double_4;
    }

    public override void RestoreStateFrom(IDictionary<string, object> mapping)
    {
      this.CameraDistance = (double) mapping["cameraDistance"];
      this.FrontClipDistance = (double) mapping["frontClipDistance"];
      this.BackClipDistance = (double) mapping["backClipDistance"];
      base.RestoreStateFrom(mapping);
    }

    public override object Clone()
    {
      SimpleTransformationProvider3D transformationProvider3D = new SimpleTransformationProvider3D();
      transformationProvider3D.CopyFrom(this);
      return (object) transformationProvider3D;
    }

    public void CopyFrom(SimpleTransformationProvider3D from)
    {
      this.CopyFrom((SimpleTransformationProviderBase) from);
      this.bool_1 = from.bool_1;
      this.double_2 = from.double_2;
      this.double_3 = from.double_3;
      this.double_4 = from.double_4;
    }
  }
}
