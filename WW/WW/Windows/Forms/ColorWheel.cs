// Decompiled with JetBrains decompiler
// Type: WW.Windows.Forms.ColorWheel
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Drawing;
using System.Windows.Forms;
using WW.Math;

namespace WW.Windows.Forms
{
  public class ColorWheel : Control
  {
    private int int_0 = 100;
    private const double double_0 = 2.0943951023932;
    private const double double_1 = 4.18879020478639;
    private System.Drawing.Color? nullable_0;

    public event EventHandler ColorChanged;

    public ColorWheel()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.Size = new Size(this.int_0 * 2 + 20, this.int_0 * 2 + 20);
      this.Padding = new Padding(6);
    }

    public System.Drawing.Color? Color
    {
      get
      {
        return this.nullable_0;
      }
      set
      {
        System.Drawing.Color? nullable0 = this.nullable_0;
        System.Drawing.Color? nullable = value;
        if ((nullable0.HasValue != nullable.HasValue ? 0 : (!nullable0.HasValue ? 1 : (nullable0.GetValueOrDefault() == nullable.GetValueOrDefault() ? 1 : 0))) != 0)
          return;
        this.nullable_0 = value;
        this.Invalidate();
        this.OnColorChanged(EventArgs.Empty);
      }
    }

    public Vector2D GetNormalizedColorLocation(System.Drawing.Color color)
    {
      if ((int) color.R == (int) color.G && (int) color.R == (int) color.B)
        return Vector2D.Zero;
      int num1 = (int) System.Math.Min(color.B, System.Math.Min(color.R, color.G));
      double num2 = (double) System.Math.Max(color.B, System.Math.Max(color.R, color.G));
      double num3;
      double num4;
      if ((int) color.R == num1)
      {
        double num5 = (double) color.R / num2;
        num3 = 1.0 - num5;
        double num6 = ((double) color.G / num2 - num5) / num3;
        double num7 = ((double) color.B / num2 - num5) / num3;
        num4 = num7 >= num6 ? 2.0 * System.Math.PI / 3.0 * (2.0 - 0.5 * num6) : 2.0 * System.Math.PI / 3.0 * (1.0 + 0.5 * num7);
      }
      else if ((int) color.G == num1)
      {
        double num5 = (double) color.G / num2;
        num3 = 1.0 - num5;
        double num6 = ((double) color.R / num2 - num5) / num3;
        double num7 = ((double) color.B / num2 - num5) / num3;
        num4 = num6 >= num7 ? 2.0 * System.Math.PI / 3.0 * (3.0 - 0.5 * num7) : 2.0 * System.Math.PI / 3.0 * (2.0 + 0.5 * num6);
      }
      else
      {
        double num5 = (double) color.B / num2;
        num3 = 1.0 - num5;
        double num6 = ((double) color.R / num2 - num5) / num3;
        double num7 = ((double) color.G / num2 - num5) / num3;
        num4 = num7 >= num6 ? 2.0 * System.Math.PI / 3.0 * (1.0 - 0.5 * num6) : 2.0 * System.Math.PI / 3.0 * (0.0 + 0.5 * num7);
      }
      return num3 * new Vector2D(System.Math.Cos(num4), System.Math.Sin(num4));
    }

    public System.Drawing.Color GetColor(Vector2D normalizedColorLocation)
    {
      Vector2D vector2D = normalizedColorLocation;
      return ColorWheel.smethod_0(vector2D.X, vector2D.Y, vector2D.GetLength());
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (this.int_0 <= 0)
        return;
      int num1 = this.int_0 * this.int_0;
      double num2 = 1.0 / (double) this.int_0;
      int num3 = this.Width / 2;
      int num4 = this.Height / 2;
      int num5 = this.int_0 * 2 + 1;
      using (Bitmap bitmap = new Bitmap(num5, num5))
      {
        for (int index1 = -this.int_0; index1 <= this.int_0; ++index1)
        {
          int num6 = index1 * index1;
          for (int index2 = -this.int_0; index2 <= this.int_0; ++index2)
          {
            int num7 = num6 + index2 * index2;
            if (num7 <= num1)
            {
              double d = System.Math.Sqrt((double) num7) * num2;
              System.Drawing.Color color = ColorWheel.smethod_0((double) index1, (double) index2, d);
              bitmap.SetPixel(index1 + this.int_0, index2 + this.int_0, color);
            }
          }
        }
        e.Graphics.DrawImageUnscaled((Image) bitmap, num3 + -this.int_0, num4 - this.int_0);
      }
      if (!this.nullable_0.HasValue)
        return;
      Vector2D vector2D = (double) this.int_0 * this.GetNormalizedColorLocation(this.nullable_0.Value);
      Point2D point2D = new Point2D((double) (int) System.Math.Round(vector2D.X), (double) (int) System.Math.Round(vector2D.Y));
      int x = (int) System.Math.Round((double) num3 + point2D.X);
      int y = (int) System.Math.Round((double) num4 + point2D.Y);
      e.Graphics.FillPolygon(Brushes.Black, new Point[3]
      {
        new Point(x - 3, y - 2 - 10),
        new Point(x, y - 2),
        new Point(x + 3, y - 2 - 10)
      });
      e.Graphics.FillPolygon(Brushes.Black, new Point[3]
      {
        new Point(x - 3, y + 2 + 10),
        new Point(x, y + 2),
        new Point(x + 3, y + 2 + 10)
      });
      e.Graphics.FillPolygon(Brushes.Black, new Point[3]
      {
        new Point(x - 2 - 10, y - 3),
        new Point(x - 2, y),
        new Point(x - 2 - 10, y + 3)
      });
      e.Graphics.FillPolygon(Brushes.Black, new Point[3]
      {
        new Point(x + 2 + 10, y - 3),
        new Point(x + 2, y),
        new Point(x + 2 + 10, y + 3)
      });
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      if (e.Button != MouseButtons.Left)
        return;
      this.method_0(e);
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
      base.OnMouseClick(e);
      this.method_0(e);
    }

    protected virtual void OnColorChanged(EventArgs e)
    {
      if (this.ColorChanged == null)
        return;
      this.ColorChanged((object) this, e);
    }

    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);
      this.int_0 = System.Math.Min(this.Width - this.Padding.Left - this.Padding.Right, this.Height - this.Padding.Top - this.Padding.Bottom) / 2;
      if (this.int_0 < 20)
        this.int_0 = 20;
      this.Invalidate();
    }

    private void method_0(MouseEventArgs e)
    {
      Vector2D normalizedColorLocation = (new Vector2D((double) e.Location.X, (double) e.Location.Y) - new Vector2D((double) this.Width / 2.0, (double) this.Height / 2.0)) / (double) this.int_0;
      if (normalizedColorLocation.GetLength() > 1.0)
        normalizedColorLocation.Normalize();
      this.Color = new System.Drawing.Color?(this.GetColor(normalizedColorLocation));
    }

    private static System.Drawing.Color smethod_0(double x, double y, double d)
    {
      double num1 = System.Math.Atan2(y, x);
      if (num1 < 0.0)
        num1 += 2.0 * System.Math.PI;
      double num2;
      double num3;
      double num4;
      if (num1 <= 2.0 * System.Math.PI / 3.0)
      {
        num2 = 1.0 - num1 / (2.0 * System.Math.PI / 3.0);
        num3 = num1 / (2.0 * System.Math.PI / 3.0);
        num4 = 0.0;
      }
      else if (num1 <= 4.0 * System.Math.PI / 3.0)
      {
        double num5 = num1 - 2.0 * System.Math.PI / 3.0;
        num2 = 0.0;
        num3 = 1.0 - num5 / (2.0 * System.Math.PI / 3.0);
        num4 = num5 / (2.0 * System.Math.PI / 3.0);
      }
      else
      {
        double num5 = num1 - 4.0 * System.Math.PI / 3.0;
        num2 = num5 / (2.0 * System.Math.PI / 3.0);
        num3 = 0.0;
        num4 = 1.0 - num5 / (2.0 * System.Math.PI / 3.0);
      }
      double num6 = num2 * 2.0;
      if (num6 > 1.0)
        num6 = 1.0;
      double num7 = num3 * 2.0;
      if (num7 > 1.0)
        num7 = 1.0;
      double num8 = num4 * 2.0;
      if (num8 > 1.0)
        num8 = 1.0;
      double num9 = 1.0 - d;
      if (num9 < 0.0)
        num9 = 0.0;
      return System.Drawing.Color.FromArgb((int) byte.MaxValue, (int) System.Math.Round((double) byte.MaxValue * (num6 + (1.0 - num6) * num9)), (int) System.Math.Round((double) byte.MaxValue * (num7 + (1.0 - num7) * num9)), (int) System.Math.Round((double) byte.MaxValue * (num8 + (1.0 - num8) * num9)));
    }
  }
}
