// Decompiled with JetBrains decompiler
// Type: WW.Drawing.GraphicsHelper
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Math;

namespace WW.Drawing
{
  public class GraphicsHelper : IDisposable
  {
    private Pen pen_0 = Pens.Blue;
    private Pen pen_1 = Pens.Green;
    private Pen pen_2 = new Pen(Color.White) { DashStyle = DashStyle.Dot };
    private Brush brush_0 = Brushes.White;
    private Brush brush_1 = (Brush) new SolidBrush(Color.LightSteelBlue);
    private double double_0 = 6.0;
    private double double_1 = 3.0;
    private Font font_0 = new Font(FontFamily.GenericSansSerif, 12f, FontStyle.Regular);

    public GraphicsHelper()
      : this(Color.White)
    {
    }

    public GraphicsHelper(Color color)
    {
      this.pen_0 = new Pen(color);
      this.pen_2 = new Pen(color)
      {
        DashStyle = DashStyle.Dot
      };
      this.brush_0 = (Brush) new SolidBrush(color);
    }

    public Pen DefaultPen
    {
      get
      {
        return this.pen_0;
      }
      set
      {
        this.pen_0 = value;
      }
    }

    public Pen HighlightPen
    {
      get
      {
        return this.pen_1;
      }
      set
      {
        this.pen_1 = value;
      }
    }

    public Pen DottedPen
    {
      get
      {
        return this.pen_2;
      }
      set
      {
        this.pen_2 = value;
      }
    }

    public Brush DefaultBrush
    {
      get
      {
        return this.brush_0;
      }
      set
      {
        this.brush_0 = value;
      }
    }

    public Brush SelectionBrush
    {
      get
      {
        return this.brush_1;
      }
      set
      {
        this.brush_1 = value;
      }
    }

    public Font DefaultFont
    {
      get
      {
        return this.font_0;
      }
      set
      {
        this.font_0 = value;
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
        this.double_1 = 0.5 * this.double_0;
      }
    }

    public double HalfEditHandleSize
    {
      get
      {
        return this.double_1;
      }
    }

    public void DrawEditHandle(Graphics graphics, Pen pen, Point2D position)
    {
      int x = (int) System.Math.Round(position.X - this.double_1);
      int y = (int) System.Math.Round(position.Y - this.double_1);
      int num1 = x + (int) System.Math.Round(this.double_0);
      int num2 = y + (int) System.Math.Round(this.double_0);
      graphics.DrawRectangle(pen, x, y, num1 - x, num2 - y);
    }

    public void Dispose()
    {
      if (this.pen_0 != null)
      {
        this.pen_0.Dispose();
        this.pen_0 = (Pen) null;
      }
      if (this.pen_1 != null)
      {
        this.pen_1.Dispose();
        this.pen_1 = (Pen) null;
      }
      if (this.pen_2 != null)
      {
        this.pen_2.Dispose();
        this.pen_2 = (Pen) null;
      }
      if (this.brush_0 != null)
      {
        this.brush_0.Dispose();
        this.brush_0 = (Brush) null;
      }
      if (this.brush_1 != null)
      {
        this.brush_1.Dispose();
        this.brush_1 = (Brush) null;
      }
      if (this.font_0 == null)
        return;
      this.font_0.Dispose();
      this.font_0 = (Font) null;
    }
  }
}
