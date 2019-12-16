// Decompiled with JetBrains decompiler
// Type: WW.Windows.Forms.ColorComponentBar
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace WW.Windows.Forms
{
  public class ColorComponentBar : Control
  {
    private int int_1 = (int) byte.MaxValue;
    private Point point_0 = new Point(5, 3);
    private Size size_0 = new Size(256, 10);
    private int int_0;
    private Func<int, Color> func_0;
    private bool bool_0;

    public event EventHandler ColorComponentValueChanged;

    public ColorComponentBar()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.Size = new Size(this.point_0.X * 2 + (int) byte.MaxValue, this.point_0.Y * 2 + this.size_0.Height + 8);
    }

    public int ColorComponentValue
    {
      get
      {
        return this.int_0;
      }
      set
      {
        if (this.int_0 != value)
        {
          this.int_0 = value;
          this.OnColorComponentValueChanged(EventArgs.Empty);
        }
        this.Invalidate();
      }
    }

    public int ColorComponentMaxValue
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    public Func<int, Color> ColorComponentToColorMapper
    {
      get
      {
        return this.func_0;
      }
      set
      {
        this.func_0 = value;
        this.Invalidate();
      }
    }

    public Point BarPosition
    {
      get
      {
        return this.point_0;
      }
      set
      {
        this.point_0 = value;
      }
    }

    public Size BarSize
    {
      get
      {
        return this.size_0;
      }
      set
      {
        this.size_0 = value;
      }
    }

    public static Color RedComponentToColor(byte red)
    {
      return Color.FromArgb((int) byte.MaxValue, (int) red, 0, 0);
    }

    public static Color GreenComponentToColor(byte green)
    {
      return Color.FromArgb((int) byte.MaxValue, 0, (int) green, 0);
    }

    public static Color BlueComponentToColor(byte blue)
    {
      return Color.FromArgb((int) byte.MaxValue, 0, (int) blue, 0);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (this.func_0 == null)
        return;
      int num1 = this.size_0.Height - 1;
      for (int index = 0; index < this.size_0.Width; ++index)
      {
        using (Pen pen = new Pen(this.func_0((int) System.Math.Round((double) index * (double) this.int_1 / (double) (this.size_0.Width - 1)))))
        {
          int num2 = index + this.point_0.X;
          e.Graphics.DrawLine(pen, num2, this.point_0.Y, num2, this.point_0.Y + num1);
        }
      }
      int x = this.point_0.X + this.int_0 * this.size_0.Width / this.int_1;
      int y = this.point_0.Y + this.size_0.Height - 3;
      Point[] points = new Point[3]{ new Point(x, y), new Point(x + 4, y + 8), new Point(x - 4, y + 8) };
      e.Graphics.FillPolygon(this.bool_0 ? Brushes.DimGray : Brushes.Black, points);
      if (!this.bool_0)
        return;
      e.Graphics.DrawPolygon(Pens.White, points);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      if (e.Button == MouseButtons.Left)
        this.method_0(e);
      int num = e.X - this.point_0.X;
      this.bool_0 = num >= this.int_0 - 4 && num <= this.int_0 + 4;
      this.Invalidate();
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
      base.OnMouseClick(e);
      this.method_0(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);
      this.bool_0 = false;
      this.Invalidate();
    }

    private void method_0(MouseEventArgs e)
    {
      int num = e.X - this.point_0.X;
      if (num < 0)
        num = 0;
      if (num >= this.size_0.Width)
        num = this.size_0.Width - 1;
      this.ColorComponentValue = (int)System.Math.Round((double) (num * this.int_1) / (double) (this.size_0.Width - 1));
    }

    protected virtual void OnColorComponentValueChanged(EventArgs e)
    {
      if (this.ColorComponentValueChanged == null)
        return;
      this.ColorComponentValueChanged((object) this, e);
    }
  }
}
