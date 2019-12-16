// Decompiled with JetBrains decompiler
// Type: WW.Windows.Forms.ColorListPicker
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WW.Windows.Forms
{
  public class ColorListPicker : Control
  {
    private int int_0 = -1;
    private List<Color> list_0 = new List<Color>();
    private Size size_0 = new Size(20, 20);
    private Size size_1 = new Size(26, 26);
    private Size size_2 = new Size(5, 5);
    private Color color_0 = Color.Black;
    private int int_1;
    private Func<int, Color> func_0;
    private ColorListPicker.ColorBoxPaintDelegate colorBoxPaintDelegate_0;
    private int int_2;

    public event EventHandler SelectedColorIndexChanged;

    public ColorListPicker()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.UserPaint, true);
    }

    public int SelectedColorIndex
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
        this.Invalidate();
      }
    }

    public List<Color> Colors
    {
      get
      {
        return this.list_0;
      }
    }

    public int ColorProviderColorCount
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

    public Func<int, Color> ColorProvider
    {
      get
      {
        return this.func_0;
      }
      set
      {
        this.func_0 = value;
      }
    }

    public ColorListPicker.ColorBoxPaintDelegate ColorBoxPainter
    {
      get
      {
        return this.colorBoxPaintDelegate_0;
      }
      set
      {
        this.colorBoxPaintDelegate_0 = value;
      }
    }

    public Size ColorBoxSize
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

    public Size ColorBoxDistance
    {
      get
      {
        return this.size_1;
      }
      set
      {
        this.size_1 = value;
      }
    }

    public Size ColorBoxMargin
    {
      get
      {
        return this.size_2;
      }
      set
      {
        this.size_2 = value;
      }
    }

    public int RowMaxColorCount
    {
      get
      {
        return this.int_2;
      }
      set
      {
        this.int_2 = value;
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      int width = this.size_2.Width;
      int num1 = this.size_2.Width + this.size_0.Width / 2 + this.size_1.Width / 2;
      int x = width;
      int num2 = num1;
      int height = this.size_2.Height;
      int num3 = 0;
      int num4 = 0;
      using (Pen pen1 = new Pen(SystemColors.ControlDark))
      {
        using (Pen pen2 = new Pen(SystemColors.ControlLightLight))
        {
          int num5 = this.func_0 == null ? this.list_0.Count : this.int_1;
          for (int colorIndex = 0; colorIndex < num5; ++colorIndex)
          {
            if (this.colorBoxPaintDelegate_0 != null)
            {
              this.colorBoxPaintDelegate_0(e, this, new Rectangle(x, height, this.size_0.Width, this.size_0.Height), colorIndex);
            }
            else
            {
              using (Brush brush = (Brush) new SolidBrush(this.func_0 == null ? this.list_0[colorIndex] : this.func_0(colorIndex)))
                e.Graphics.FillRectangle(brush, x, height, this.size_0.Width, this.size_0.Height);
            }
            int num6 = x;
            int num7 = height;
            int num8 = height + this.size_0.Height;
            int num9 = x + this.size_0.Width;
            e.Graphics.DrawLine(pen1, num6, num7, num9, num7);
            e.Graphics.DrawLine(pen1, num6, num7, num6, num8);
            e.Graphics.DrawLine(pen2, num6, num8, num9, num8);
            e.Graphics.DrawLine(pen2, num9, num7, num9, num8);
            int num10 = num6 + 1;
            int num11 = num7 + 1;
            int num12 = num8 - 1;
            int num13 = num9 - 1;
            e.Graphics.DrawLine(pen1, num10, num11, num13, num11);
            e.Graphics.DrawLine(pen1, num10, num11, num10, num12);
            e.Graphics.DrawLine(pen2, num10, num12, num13, num12);
            e.Graphics.DrawLine(pen2, num13, num11, num13, num12);
            if (num4 == this.int_0)
            {
              using (Pen pen3 = new Pen(this.color_0))
              {
                pen3.DashStyle = DashStyle.Dot;
                e.Graphics.DrawRectangle(pen3, x - 2, height - 2, this.size_0.Width + 4, this.size_0.Height + 4);
              }
            }
            x += this.size_1.Width;
            num2 += this.size_1.Width;
            ++num3;
            if (num3 > 0 && (num2 > this.Right || this.int_2 != 0 && num3 >= this.int_2))
            {
              x = width;
              num2 = num1;
              num3 = 0;
              height += this.size_1.Height;
            }
            ++num4;
          }
        }
      }
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
      base.OnMouseClick(e);
      int width = this.size_2.Width;
      int num1 = this.size_2.Width + this.size_0.Width / 2 + this.size_1.Width / 2;
      int x = width;
      int num2 = num1;
      int height = this.size_2.Height;
      int num3 = 0;
      int num4 = 0;
      int num5 = this.func_0 == null ? this.list_0.Count : this.int_1;
      for (int index = 0; index < num5; ++index)
      {
        if (!new Rectangle(x, height, this.size_0.Width, this.size_0.Height).Contains(e.Location))
        {
          x += this.size_1.Width;
          num2 += this.size_1.Width;
          ++num3;
          if (num3 > 0 && (num2 > this.Right || this.int_2 != 0 && num3 >= this.int_2))
          {
            x = width;
            num2 = num1;
            num3 = 0;
            height += this.size_1.Height;
          }
          ++num4;
        }
        else
        {
          this.int_0 = num4;
          this.Invalidate();
          this.OnSelectedColorIndexChanged(EventArgs.Empty);
          break;
        }
      }
    }

    protected virtual void OnSelectedColorIndexChanged(EventArgs e)
    {
      if (this.SelectedColorIndexChanged == null)
        return;
      this.SelectedColorIndexChanged((object) this, e);
    }

    public delegate void ColorBoxPaintDelegate(
      PaintEventArgs e,
      ColorListPicker sender,
      Rectangle rectangle,
      int colorIndex);
  }
}
