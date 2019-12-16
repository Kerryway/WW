// Decompiled with JetBrains decompiler
// Type: WW.Actions.InteractionContext
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Actions
{
  public class InteractionContext
  {
    private double double_0 = 6.0;
    private double double_1 = 6.0;
    private string string_0 = "#,##0.00";
    private string string_1 = "#,##0";
    private Rectangle2D rectangle2D_0;
    private Matrix4D matrix4D_0;
    private Matrix4D matrix4D_1;
    private bool bool_0;
    private ArgbColor argbColor_0;

    public InteractionContext(
      Rectangle2D canvasRectangle,
      Matrix4D projectionTransform,
      bool projectionFlipsOrientation,
      ArgbColor backgroundColor)
    {
      this.rectangle2D_0 = canvasRectangle;
      this.matrix4D_0 = projectionTransform;
      this.matrix4D_1 = projectionTransform.GetInverse();
      this.argbColor_0 = backgroundColor;
      this.bool_0 = projectionFlipsOrientation;
    }

    public Rectangle2D CanvasRectangle
    {
      get
      {
        return this.rectangle2D_0;
      }
      set
      {
        this.rectangle2D_0 = value;
      }
    }

    public Matrix4D ProjectionTransform
    {
      get
      {
        return this.matrix4D_0;
      }
      set
      {
        this.matrix4D_0 = value;
        this.matrix4D_1 = this.matrix4D_0.GetInverse();
      }
    }

    public Matrix4D InverseProjectionTransform
    {
      get
      {
        return this.matrix4D_1;
      }
    }

    public double EditHandleSize
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

    public double CrossHairSize
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

    public bool ProjectionFlipsOrientation
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public ArgbColor BackgroundColor
    {
      get
      {
        return this.argbColor_0;
      }
      set
      {
        this.argbColor_0 = value;
      }
    }

    public string LengthFormatString
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value ?? string.Empty;
      }
    }

    public string AngleFormatString
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }
  }
}
