// Decompiled with JetBrains decompiler
// Type: WW.Actions.CanonicalMouseEventArgs
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using WW.Math;

namespace WW.Actions
{
  public class CanonicalMouseEventArgs : EventArgs
  {
    private readonly Point2D point2D_0;
    private Point3D? nullable_0;
    private bool bool_0;
    private readonly int int_0;
    private readonly bool bool_1;
    private readonly bool bool_2;
    private readonly bool bool_3;
    private readonly bool bool_4;
    private readonly bool bool_5;
    private readonly int int_1;

    public CanonicalMouseEventArgs(System.Windows.Forms.MouseEventArgs e)
    {
      this.point2D_0 = new Point2D((double) e.Location.X, (double) e.Location.Y);
      this.int_0 = e.Clicks;
      this.bool_1 = (e.Button & MouseButtons.Left) != MouseButtons.None;
      this.bool_2 = (e.Button & MouseButtons.Middle) != MouseButtons.None;
      this.bool_3 = (e.Button & MouseButtons.Right) != MouseButtons.None;
      this.bool_4 = (e.Button & MouseButtons.XButton1) != MouseButtons.None;
      this.bool_5 = (e.Button & MouseButtons.XButton2) != MouseButtons.None;
      this.int_1 = e.Delta;
    }

    public CanonicalMouseEventArgs(System.Windows.Input.MouseEventArgs e, IInputElement inputElement)
    {
      Point position = e.GetPosition(inputElement);
      this.point2D_0 = new Point2D(position.X, position.Y);
      this.bool_1 = e.LeftButton == MouseButtonState.Pressed;
      this.bool_2 = e.MiddleButton == MouseButtonState.Pressed;
      this.bool_3 = e.RightButton == MouseButtonState.Pressed;
      this.bool_4 = e.XButton1 == MouseButtonState.Pressed;
      this.bool_5 = e.XButton2 == MouseButtonState.Pressed;
    }

    public CanonicalMouseEventArgs(MouseButtonEventArgs e, IInputElement inputElement)
      : this((System.Windows.Input.MouseEventArgs) e, inputElement)
    {
      this.int_0 = e.ClickCount;
    }

    public CanonicalMouseEventArgs(MouseWheelEventArgs e, IInputElement inputElement)
      : this((System.Windows.Input.MouseEventArgs) e, inputElement)
    {
      this.int_1 = e.Delta;
    }

    public Point2D Position
    {
      get
      {
        return this.point2D_0;
      }
    }

    public Point3D? WcsPosition
    {
      get
      {
        return this.nullable_0;
      }
    }

    public bool WcsPositionIsSnapped
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

    public int ClickCount
    {
      get
      {
        return this.int_0;
      }
    }

    public bool LeftButtonDown
    {
      get
      {
        return this.bool_1;
      }
    }

    public bool MiddleButtonDown
    {
      get
      {
        return this.bool_2;
      }
    }

    public bool RightButtonDown
    {
      get
      {
        return this.bool_3;
      }
    }

    public bool XButton1Down
    {
      get
      {
        return this.bool_4;
      }
    }

    public bool XButton2Down
    {
      get
      {
        return this.bool_5;
      }
    }

    public int MouseWheelDelta
    {
      get
      {
        return this.int_1;
      }
    }

    public MouseButtonFlags MouseButtonFlags
    {
      get
      {
        MouseButtonFlags mouseButtonFlags = MouseButtonFlags.None;
        if (this.bool_1)
          mouseButtonFlags |= MouseButtonFlags.Left;
        if (this.bool_2)
          mouseButtonFlags |= MouseButtonFlags.Middle;
        if (this.bool_3)
          mouseButtonFlags |= MouseButtonFlags.Right;
        if (this.bool_4)
          mouseButtonFlags |= MouseButtonFlags.XButton1;
        if (this.bool_5)
          mouseButtonFlags |= MouseButtonFlags.XButton2;
        return mouseButtonFlags;
      }
    }

    public Point3D GetWcsPosition(InteractionContext context)
    {
      if (this.nullable_0.HasValue)
        return this.nullable_0.Value;
      Point3D point3D = context.InverseProjectionTransform.TransformTo3D(this.point2D_0);
      point3D.Z = 0.0;
      return point3D;
    }

    public void SetWcsPosition(Point3D p, bool isSnapped)
    {
      this.nullable_0 = new Point3D?(p);
      this.bool_0 = isSnapped;
    }
  }
}
