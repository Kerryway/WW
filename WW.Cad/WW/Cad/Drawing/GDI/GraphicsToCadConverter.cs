// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.GDI.GraphicsToCadConverter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;

namespace WW.Cad.Drawing.GDI
{
  public class GraphicsToCadConverter : IDisposable
  {
    private List<DxfEntity> list_0 = new List<DxfEntity>();
    private Bitmap bitmap_0 = new Bitmap(1, 1);
    private DxfModel dxfModel_0;
    private Graphics graphics_0;

    public GraphicsToCadConverter(DxfModel model)
    {
      this.dxfModel_0 = model;
      this.graphics_0 = Graphics.FromImage((Image) this.bitmap_0);
      this.graphics_0.TextRenderingHint = TextRenderingHint.AntiAlias;
    }

    public DxfModel Model
    {
      get
      {
        return this.dxfModel_0;
      }
    }

    public List<DxfEntity> Entities
    {
      get
      {
        return this.list_0;
      }
    }

    public void DrawLine(Pen pen, Point pt1, Point pt2)
    {
      this.list_0.Add((DxfEntity) new DxfLine(EntityColor.CreateFrom((ArgbColor) pen.Color), new WW.Math.Point2D((double) pt1.X, (double) -pt1.Y), new WW.Math.Point2D((double) pt2.X, (double) -pt2.Y)));
    }

    public SizeF MeasureString(string text, Font font)
    {
      return this.graphics_0.MeasureString(text, font);
    }

    public void DrawString(string s, Font font, Brush brush, PointF point)
    {
      DxfText dxfText = new DxfText(s, new WW.Math.Point3D((double) point.X, -(double) point.Y, 0.0), (double) font.Size);
      dxfText.AlignmentPoint2 = new WW.Math.Point3D?(dxfText.AlignmentPoint1);
      dxfText.VerticalAlignment = TextVerticalAlignment.Top;
      DxfTextStyle dxfTextStyle = (DxfTextStyle) null;
      foreach (DxfTextStyle textStyle in (DxfHandledObjectCollection<DxfTextStyle>) this.dxfModel_0.TextStyles)
      {
        if (textStyle.FontFilename == font.Name)
        {
          dxfTextStyle = textStyle;
          break;
        }
      }
      if (dxfTextStyle == null)
      {
        dxfTextStyle = new DxfTextStyle(font.Name, font.Name);
        this.dxfModel_0.TextStyles.Add(dxfTextStyle);
      }
      dxfText.Style = dxfTextStyle;
      SolidBrush solidBrush = brush as SolidBrush;
      if (solidBrush != null)
        dxfText.Color = EntityColor.CreateFrom((ArgbColor) solidBrush.Color);
      this.list_0.Add((DxfEntity) dxfText);
    }

    public void DrawArc(
      Pen pen,
      float x,
      float y,
      float width,
      float height,
      float startAngle,
      float sweepAngle)
    {
      double a = -(double) startAngle * System.Math.PI / 180.0;
      double num1 = -(double) sweepAngle * System.Math.PI / 180.0;
      double b = a + num1;
      if (num1 < 0.0)
        MathUtil.Swap(ref a, ref b);
      double radius = 0.5 * (double) width;
      WW.Math.Point3D center = new WW.Math.Point3D((double) x + radius, -(double) y - 0.5 * (double) height, 0.0);
      if ((double) width == (double) height)
      {
        if (MathUtil.AreApproxEqual(System.Math.Abs(num1), 2.0 * System.Math.PI))
        {
          DxfCircle dxfCircle = new DxfCircle(center, radius);
          dxfCircle.Color = EntityColor.CreateFrom((ArgbColor) pen.Color);
          this.list_0.Add((DxfEntity) dxfCircle);
        }
        else
        {
          DxfArc dxfArc = new DxfArc(center, radius, a, b);
          dxfArc.Color = EntityColor.CreateFrom((ArgbColor) pen.Color);
          this.list_0.Add((DxfEntity) dxfArc);
        }
      }
      else
      {
        double num2 = (double) System.Math.Abs(width);
        double num3 = (double) System.Math.Abs(height);
        double minorToMajorRatio;
        Vector3D majorAxisEndPoint;
        double num4;
        double num5;
        if (num2 > num3)
        {
          minorToMajorRatio = num3 / num2;
          majorAxisEndPoint = new Vector3D(0.5 * num2, 0.0, 0.0);
          num4 = a;
          num5 = b;
        }
        else
        {
          minorToMajorRatio = num2 / num3;
          majorAxisEndPoint = new Vector3D(0.0, 0.5 * num3, 0.0);
          if (MathUtil.AreApproxEqual(System.Math.Abs(num1), 2.0 * System.Math.PI))
          {
            num4 = 0.0;
            num5 = 2.0 * System.Math.PI;
          }
          else
          {
            num4 = a - System.Math.PI / 2.0;
            num5 = b - System.Math.PI / 2.0;
          }
        }
        DxfEllipse dxfEllipse = new DxfEllipse(center, majorAxisEndPoint, minorToMajorRatio);
        dxfEllipse.Color = EntityColor.CreateFrom((ArgbColor) pen.Color);
        dxfEllipse.StartParameter = num4;
        dxfEllipse.EndParameter = num5;
        this.list_0.Add((DxfEntity) dxfEllipse);
      }
    }

    public void Dispose()
    {
      if (this.graphics_0 != null)
      {
        this.graphics_0.Dispose();
        this.graphics_0 = (Graphics) null;
      }
      if (this.bitmap_0 == null)
        return;
      this.bitmap_0.Dispose();
      this.bitmap_0 = (Bitmap) null;
    }
  }
}
