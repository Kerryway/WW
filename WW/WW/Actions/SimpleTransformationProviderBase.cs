// Decompiled with JetBrains decompiler
// Type: WW.Actions.SimpleTransformationProviderBase
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Actions
{
  public abstract class SimpleTransformationProviderBase : ITransformationProvider, WW.ICloneable
  {
    private Vector3D vector3D_0 = Vector3D.Zero;
    private double double_0 = 1.0;
    private QuaternionD quaternionD_0 = QuaternionD.Identity;
    protected double viewScaling = 1.0;
    protected Bounds3D modelBounds = new Bounds3D();
    private bool bool_0 = true;
    private double double_1 = 5.0;
    protected Rectangle2D viewWindow;
    private ModelBoundsFitType modelBoundsFitType_0;

    public event EventHandler TransformsChanged;

    public virtual Vector3D ModelTranslation
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        if (!(this.vector3D_0 != value))
          return;
        this.vector3D_0 = value;
        this.OnTransformsChanged((EventArgs) null);
      }
    }

    public virtual Matrix4D ModelTranslationTransform
    {
      get
      {
        return Transformation4D.Translation(this.vector3D_0);
      }
    }

    public virtual double ModelScaling
    {
      get
      {
        return this.double_0;
      }
      set
      {
        if (value == this.double_0)
          return;
        this.double_0 = value;
        this.OnTransformsChanged((EventArgs) null);
      }
    }

    public virtual Matrix4D ModelScalingTransform
    {
      get
      {
        return Transformation4D.Scaling(this.double_0);
      }
    }

    public virtual QuaternionD ModelOrientation
    {
      get
      {
        return this.quaternionD_0;
      }
      set
      {
        if (!(value != this.quaternionD_0))
          return;
        this.quaternionD_0 = value;
        this.OnTransformsChanged((EventArgs) null);
      }
    }

    public virtual Matrix4D ModelOrientationTransform
    {
      get
      {
        return QuaternionD.QuaternionToMatrix(this.quaternionD_0);
      }
    }

    public virtual double ViewScaling
    {
      get
      {
        return this.viewScaling;
      }
      set
      {
        if (value == this.viewScaling)
          return;
        this.viewScaling = value;
        this.OnTransformsChanged((EventArgs) null);
      }
    }

    public abstract double ViewScalingSize { get; }

    public virtual Rectangle2D ViewWindow
    {
      get
      {
        return this.viewWindow;
      }
      set
      {
        if (!(value != this.viewWindow))
          return;
        bool flag = this.viewWindow.Width == 0.0 || this.viewWindow.Height == 0.0;
        this.viewWindow = value;
        if (flag)
          this.ResetTransforms();
        this.OnTransformsChanged((EventArgs) null);
      }
    }

    public virtual Rectangle2D EffectiveViewWindow
    {
      get
      {
        Rectangle2D viewWindow = this.viewWindow;
        if (viewWindow.Width > this.double_1 + this.double_1)
        {
          viewWindow.X1 += this.double_1;
          viewWindow.X2 -= this.double_1;
        }
        if (viewWindow.Height > this.double_1 + this.double_1)
        {
          viewWindow.Y1 += this.double_1;
          viewWindow.Y2 -= this.double_1;
        }
        return viewWindow;
      }
    }

    public virtual bool IsInvertY
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        if (value == this.bool_0)
          return;
        this.bool_0 = value;
        this.OnTransformsChanged((EventArgs) null);
      }
    }

    public abstract Matrix4D WorldTransform { get; }

    public abstract Matrix4D CanonicalProjectionTransform { get; }

    public virtual Matrix4D ProjectionTransform
    {
      get
      {
        Rectangle2D effectiveViewWindow = this.EffectiveViewWindow;
        return Transformation4D.GetScaleAndTranslateTransform(new Point2D(-1.0, -1.0), new Point2D(1.0, 1.0), new Point2D(effectiveViewWindow.X1, this.bool_0 ? effectiveViewWindow.Y2 : effectiveViewWindow.Y1), new Point2D(effectiveViewWindow.X2, this.bool_0 ? effectiveViewWindow.Y1 : effectiveViewWindow.Y2)) * this.CanonicalProjectionTransform;
      }
    }

    public virtual Matrix4D CompleteTransform
    {
      get
      {
        return this.ProjectionTransform * this.WorldTransform;
      }
    }

    public ModelBoundsFitType ModelBoundsFitType
    {
      get
      {
        return this.modelBoundsFitType_0;
      }
      set
      {
        this.modelBoundsFitType_0 = value;
      }
    }

    public double Margin
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

    public abstract void ResetTransforms();

    public void ResetTransforms(Bounds3D bounds)
    {
      this.modelBounds = bounds;
      this.ResetTransforms();
    }

    protected virtual void OnTransformsChanged(EventArgs e)
    {
      if (this.TransformsChanged == null)
        return;
      this.TransformsChanged((object) this, e);
    }

    public virtual void PanView(double dx, double dy)
    {
      Vector3D vector3D = new Vector3D(dx, this.bool_0 ? -dy : dy, 0.0);
      double num = this.ViewScaling * this.ViewScalingSize;
      Rectangle2D effectiveViewWindow = this.EffectiveViewWindow;
      this.ModelTranslation += (this.ModelScalingTransform * this.ModelOrientationTransform).GetInverse().Transform(vector3D / (0.5 * System.Math.Min(effectiveViewWindow.Width, effectiveViewWindow.Height) / num));
    }

    public virtual void RectangleZoom(Rectangle2D zoomRectangle)
    {
      if (System.Math.Abs(zoomRectangle.Width) <= 1.0 || System.Math.Abs(zoomRectangle.Height) <= 1.0)
        return;
      Vector2D vector2D = this.ViewWindow.Center - zoomRectangle.Center;
      double num = System.Math.Min(this.ViewWindow.Width / zoomRectangle.Width, this.ViewWindow.Height / zoomRectangle.Height);
      this.PanView(vector2D.X, vector2D.Y);
      this.ViewScaling /= num;
      this.OnTransformsChanged((EventArgs) null);
    }

    public virtual void StoreStateTo(IDictionary<string, object> mapping)
    {
      mapping["modelTranslation"] = (object) this.vector3D_0;
      mapping["modelScaling"] = (object) this.double_0;
      mapping["modelOrientation"] = (object) this.quaternionD_0;
      mapping["viewScaling"] = (object) this.viewScaling;
      mapping["modelBoundsFitType"] = (object) this.modelBoundsFitType_0;
      mapping["margin"] = (object) this.double_1;
    }

    public virtual void RestoreStateFrom(IDictionary<string, object> mapping)
    {
      this.ModelTranslation = (Vector3D) mapping["modelTranslation"];
      this.ModelScaling = (double) mapping["modelScaling"];
      this.ModelOrientation = (QuaternionD) mapping["modelOrientation"];
      this.ViewScaling = (double) mapping["viewScaling"];
      this.modelBoundsFitType_0 = (ModelBoundsFitType) mapping["modelBoundsFitType"];
      this.double_1 = (double) mapping["margin"];
    }

    public abstract object Clone();

    public void CopyFrom(SimpleTransformationProviderBase from)
    {
      this.vector3D_0 = from.vector3D_0;
      this.double_0 = from.double_0;
      this.quaternionD_0 = from.quaternionD_0;
      this.viewScaling = from.viewScaling;
      this.viewWindow = from.viewWindow;
      this.modelBounds.CopyFrom(from.modelBounds);
      this.bool_0 = from.bool_0;
      this.modelBoundsFitType_0 = from.modelBoundsFitType_0;
      this.double_1 = from.double_1;
    }
  }
}
