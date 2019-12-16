// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.ShxShape
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class ShxShape
  {
    private static readonly Vector2D[] vector2D_0 = new Vector2D[16]{ new Vector2D(1.0, 0.0), new Vector2D(1.0, 0.5), new Vector2D(1.0, 1.0), new Vector2D(0.5, 1.0), new Vector2D(0.0, 1.0), new Vector2D(-0.5, 1.0), new Vector2D(-1.0, 1.0), new Vector2D(-1.0, 0.5), new Vector2D(-1.0, 0.0), new Vector2D(-1.0, -0.5), new Vector2D(-1.0, -1.0), new Vector2D(-0.5, -1.0), new Vector2D(0.0, -1.0), new Vector2D(0.5, -1.0), new Vector2D(1.0, -1.0), new Vector2D(1.0, -0.5) };
    private static readonly ShxShape.Delegate9[] delegate9_0 = new ShxShape.Delegate9[16]{ new ShxShape.Delegate9(ShxShape.smethod_0), new ShxShape.Delegate9(ShxShape.smethod_1), new ShxShape.Delegate9(ShxShape.smethod_2), new ShxShape.Delegate9(ShxShape.smethod_3), new ShxShape.Delegate9(ShxShape.smethod_4), new ShxShape.Delegate9(ShxShape.smethod_5), new ShxShape.Delegate9(ShxShape.smethod_6), new ShxShape.Delegate9(ShxShape.smethod_7), new ShxShape.Delegate9(ShxShape.smethod_8), new ShxShape.Delegate9(ShxShape.smethod_9), new ShxShape.Delegate9(ShxShape.smethod_10), new ShxShape.Delegate9(ShxShape.smethod_11), new ShxShape.Delegate9(ShxShape.smethod_12), new ShxShape.Delegate9(ShxShape.smethod_13), new ShxShape.Delegate9(ShxShape.smethod_14), new ShxShape.Delegate9(ShxShape.smethod_15) };
    private const float float_0 = 0.7853982f;
    private const float float_1 = 127f;
    private readonly ushort ushort_0;
    private readonly char char_0;
    private readonly string string_0;
    private readonly byte[] byte_0;
    private readonly ShxFile shxFile_0;
    private GeneralShape2D generalShape2D_0;
    private GeneralShape2D generalShape2D_1;
    private WW.Math.Point2D point2D_0;
    private WW.Math.Point2D point2D_1;

    public ShxShape(
      ShxFile shxFile,
      ushort index,
      char unicodeCharIndex,
      string description,
      byte[] geometry)
    {
      this.shxFile_0 = shxFile;
      this.ushort_0 = index;
      this.char_0 = unicodeCharIndex;
      this.string_0 = description;
      this.byte_0 = geometry;
    }

    public ushort Index
    {
      get
      {
        return this.ushort_0;
      }
    }

    public char UnicodeCharIndex
    {
      get
      {
        return this.char_0;
      }
    }

    public string Description
    {
      get
      {
        return this.string_0;
      }
    }

    public WW.Math.Point2D HorizontalAdvance
    {
      get
      {
        if (this.generalShape2D_0 != null)
          return this.point2D_0;
        WW.Math.Point2D endPoint;
        this.GetGlyphShape(false, out endPoint);
        return endPoint;
      }
    }

    public WW.Math.Point2D VerticalAdvance
    {
      get
      {
        if (this.generalShape2D_1 != null)
          return this.point2D_1;
        WW.Math.Point2D endPoint;
        this.GetGlyphShape(true, out endPoint);
        return endPoint;
      }
    }

    public Bounds2D HorizontalBounds
    {
      get
      {
        if (this.generalShape2D_0 == null)
        {
          WW.Math.Point2D endPoint;
          this.GetGlyphShape(false, out endPoint);
        }
        return ShapeTool.GetBounds((IShape2D) this.generalShape2D_0);
      }
    }

    public Bounds2D VerticalBounds
    {
      get
      {
        if (this.generalShape2D_1 == null)
        {
          WW.Math.Point2D endPoint;
          this.GetGlyphShape(true, out endPoint);
        }
        return ShapeTool.GetBounds((IShape2D) this.generalShape2D_1);
      }
    }

    [Obsolete]
    public GraphicsPath GetGraphicsPath(
      bool vertical,
      out PointF endPoint,
      int noOfTextArcLineParts)
    {
      return this.GetGraphicsPath(vertical, out endPoint);
    }

    [Obsolete]
    public GraphicsPath GetGraphicsPath(bool vertical, out PointF endPoint)
    {
      GraphicsPath graphicsPath;
      if (vertical)
      {
        if (this.generalShape2D_1 == null)
        {
          ShxShape.Class466 class466 = this.method_0(vertical);
          this.generalShape2D_1 = class466.Shape;
          this.point2D_1 = class466.CurrentPosition;
        }
        graphicsPath = (GraphicsPath) this.generalShape2D_1;
        endPoint = (PointF) this.point2D_1;
      }
      else
      {
        if (this.generalShape2D_0 == null)
        {
          ShxShape.Class466 class466 = this.method_0(vertical);
          this.generalShape2D_0 = class466.Shape;
          this.point2D_0 = class466.CurrentPosition;
        }
        graphicsPath = (GraphicsPath) this.generalShape2D_0;
        endPoint = (PointF) this.point2D_0;
      }
      return graphicsPath;
    }

    public IShape2D GetGlyphShape(bool vertical, out WW.Math.Point2D endPoint)
    {
      IShape2D wrappedShape;
      if (vertical)
      {
        if (this.generalShape2D_1 == null)
        {
          ShxShape.Class466 class466 = this.method_0(vertical);
          this.generalShape2D_1 = class466.Shape;
          this.point2D_1 = class466.CurrentPosition;
        }
        wrappedShape = (IShape2D) this.generalShape2D_1;
        endPoint = this.point2D_1;
      }
      else
      {
        if (this.generalShape2D_0 == null)
        {
          ShxShape.Class466 class466 = this.method_0(vertical);
          this.generalShape2D_0 = class466.Shape;
          this.point2D_0 = class466.CurrentPosition;
        }
        wrappedShape = (IShape2D) this.generalShape2D_0;
        endPoint = this.point2D_0;
      }
      return (IShape2D) new CachedBoundsShape2D(wrappedShape);
    }

    public override string ToString()
    {
      string str = string.Format("index: {0}, charIndex: {1}", (object) this.ushort_0, (object) this.char_0);
      if (!string.IsNullOrEmpty(this.string_0))
        str = str + " description: " + this.string_0;
      return str;
    }

    private ShxShape.Class466 method_0(bool vertical)
    {
      ShxShape.Class466 plotter = new ShxShape.Class466(this.shxFile_0, vertical);
      this.method_1(plotter);
      return plotter;
    }

    private void method_1(ShxShape.Class466 plotter)
    {
      int offset = 0;
      while (offset < this.byte_0.Length)
      {
        byte num1 = this.byte_0[offset];
        if (num1 < (byte) 16)
        {
          ShxShape.Delegate9 delegate9 = ShxShape.delegate9_0[(int) num1];
          offset += delegate9(plotter, this.byte_0, offset);
        }
        else
        {
          float num2 = (float) ((int) num1 >> 4 & 15);
          Vector2D vector2D = ShxShape.vector2D_0[(int) num1 & 15];
          if (plotter.method_0())
            plotter.method_7((double) num2 * vector2D.X, (double) num2 * vector2D.Y);
          ++offset;
        }
      }
    }

    private static int smethod_0(ShxShape.Class466 plotter, byte[] geometry, int offset)
    {
      return 1;
    }

    private static int smethod_1(ShxShape.Class466 plotter, byte[] geometry, int offset)
    {
      if (plotter.method_0())
        plotter.PenDown = true;
      return 1;
    }

    private static int smethod_2(ShxShape.Class466 plotter, byte[] geometry, int offset)
    {
      if (plotter.method_0())
        plotter.PenDown = false;
      return 1;
    }

    private static int smethod_3(ShxShape.Class466 plotter, byte[] geometry, int offset)
    {
      if (plotter.method_0())
        plotter.method_6((double) (sbyte) geometry[offset + 1]);
      return 2;
    }

    private static int smethod_4(ShxShape.Class466 plotter, byte[] geometry, int offset)
    {
      if (plotter.method_0())
        plotter.method_5((double) (sbyte) geometry[offset + 1]);
      return 2;
    }

    private static int smethod_5(ShxShape.Class466 plotter, byte[] geometry, int offset)
    {
      if (plotter.method_0())
        plotter.method_3();
      return 1;
    }

    private static int smethod_6(ShxShape.Class466 plotter, byte[] geometry, int offset)
    {
      if (plotter.method_0())
        plotter.method_4();
      return 1;
    }

    private static int smethod_7(ShxShape.Class466 plotter, byte[] geometry, int offset)
    {
      plotter.method_1();
      ShxFile shxFile = plotter.ShxFile;
      int num1;
      if (shxFile.ShxFormat == ShxFormat.shxUnicode1_0)
      {
        char ch = Convert.ToChar(((int) geometry[offset + 1] << 8) + (int) geometry[offset + 2]);
        ShxShape shapeByIndex = shxFile.GetShapeByIndex((ushort) ch);
        if (shapeByIndex == null)
          throw new Exception("No shape found with id " + (object) ch + " in shx file " + shxFile.FileName + ".");
        if (plotter.method_0())
          shapeByIndex.method_1(plotter);
        num1 = 3;
      }
      else if (geometry[offset + 1] != (byte) 0)
      {
        char ch = Convert.ToChar(geometry[offset + 1]);
        ShxShape shapeByIndex = shxFile.GetShapeByIndex((ushort) ch);
        if (shapeByIndex == null)
          throw new Exception("No shape found with id " + (object) ch + " in shx file " + shxFile.FileName + ".");
        if (plotter.method_0())
          shapeByIndex.method_1(plotter);
        num1 = 2;
      }
      else
      {
        ushort index = (ushort) ((uint) geometry[offset + 2] << 8 | (uint) geometry[offset + 3]);
        ShxShape shapeByIndex = shxFile.GetShapeByIndex(index);
        if (shapeByIndex == null)
          throw new Exception("No shape found with id " + (object) index + " in shx file " + shxFile.FileName + ".");
        if (plotter.method_0())
        {
          ShxShape.Class466 class466 = shapeByIndex.method_0(false);
          float num2 = (float) geometry[offset + 4];
          float num3 = (float) geometry[offset + 5];
          float num4 = (float) geometry[offset + 6] / (float) shxFile.Width;
          float num5 = (float) geometry[offset + 7] / (float) shxFile.Height;
          Matrix3D transformation = new Matrix3D((double) num4, 0.0, (double) num2, 0.0, (double) num5, (double) num3, 0.0, 0.0, 1.0);
          class466.Shape.TransformBy(transformation);
          plotter.method_10((IShape2D) class466.Shape, false);
        }
        num1 = 8;
      }
      plotter.method_2();
      return num1;
    }

    private static int smethod_8(ShxShape.Class466 plotter, byte[] geometry, int offset)
    {
      if (plotter.method_0())
        plotter.method_7((double) (sbyte) geometry[offset + 1], (double) (sbyte) geometry[offset + 2]);
      return 3;
    }

    private static int smethod_9(ShxShape.Class466 plotter, byte[] geometry, int offset)
    {
      bool flag = plotter.method_0();
      int index;
      for (index = offset + 1; geometry[index] != (byte) 0 || geometry[index + 1] != (byte) 0; index += 2)
      {
        if (flag)
          plotter.method_7((double) (sbyte) geometry[index], (double) (sbyte) geometry[index + 1]);
      }
      return index - offset + 2;
    }

    private static int smethod_10(ShxShape.Class466 plotter, byte[] geometry, int offset)
    {
      if (plotter.method_0())
      {
        int num1 = (int) geometry[offset + 1];
        int num2 = (int) geometry[offset + 2] >> 4 & 7;
        sbyte num3 = (sbyte) geometry[offset + 2];
        int num4 = num3 < (sbyte) 0 ? -((int) num3 & 7) : (int) num3 & 7;
        if (num4 == 0)
          num4 = 8;
        plotter.method_8((double) num1, (double) num2 * 0.785398185253143, (double) num4 * 0.785398185253143);
      }
      return 3;
    }

    private static int smethod_11(ShxShape.Class466 plotter, byte[] geometry, int offset)
    {
      if (plotter.method_0())
      {
        float num1 = 0.003067962f * (float) geometry[offset + 1];
        float num2 = 0.003067962f * (float) geometry[offset + 2];
        int num3 = ((int) geometry[offset + 3] << 8) + (int) geometry[offset + 4];
        int num4 = (int) geometry[offset + 5] >> 4 & 7;
        sbyte num5 = (sbyte) geometry[offset + 5];
        int num6 = num5 < (sbyte) 0 ? -((int) num5 & 7) : (int) num5 & 7;
        float num7;
        float num8;
        if (num5 >= (sbyte) 0)
        {
          num7 = 0.7853982f * (float) num4 + num1;
          num8 = (double) num2 == 0.0 ? (float) num6 * 0.7853982f - num1 : (float) (num6 - 1) * 0.7853982f - num1 + num2;
          if ((double) num8 < 0.0)
            num8 += 6.283185f;
        }
        else
        {
          num7 = 0.7853982f * (float) num4 - num1;
          num8 = (double) num2 == 0.0 ? (float) num6 * 0.7853982f + num1 : (float) (num6 + 1) * 0.7853982f + num1 - num2;
          if ((double) num8 > 0.0)
            num8 -= 6.283185f;
        }
        if ((double) num8 != 0.0)
          plotter.method_8((double) num3, (double) num7, (double) num8);
      }
      return 6;
    }

    private static int smethod_12(ShxShape.Class466 plotter, byte[] geometry, int offset)
    {
      if (plotter.method_0())
      {
        float x = (float) (sbyte) geometry[offset + 1];
        float y = (float) (sbyte) geometry[offset + 2];
        float bulge = (float) (sbyte) geometry[offset + 3] / (float) sbyte.MaxValue;
        plotter.method_9(x, y, bulge);
      }
      return 4;
    }

    private static int smethod_13(ShxShape.Class466 plotter, byte[] geometry, int offset)
    {
      bool flag = plotter.method_0();
      int index;
      for (index = offset + 1; geometry[index] != (byte) 0 || geometry[index + 1] != (byte) 0; index += 3)
      {
        if (flag)
        {
          float x = (float) (sbyte) geometry[index];
          float y = (float) (sbyte) geometry[index + 1];
          float bulge = (float) (sbyte) geometry[index + 2] / (float) sbyte.MaxValue;
          plotter.method_9(x, y, bulge);
        }
      }
      return index - offset + 2;
    }

    private static int smethod_14(ShxShape.Class466 plotter, byte[] geometry, int offset)
    {
      if (!plotter.Vertical)
        plotter.IgnoreNextCommand = true;
      return 1;
    }

    private static int smethod_15(ShxShape.Class466 plotter, byte[] geometry, int offset)
    {
      throw new Exception("Unknown shx shape command.");
    }

    internal static char smethod_16(Encoding encoding, ushort id)
    {
      byte[] buffer = new byte[2]{ (byte) ((int) id >> 8 & (int) byte.MaxValue), (byte) ((uint) id & (uint) byte.MaxValue) };
      return ShxShape.smethod_17(encoding, buffer, 0, 2);
    }

    internal static char smethod_17(Encoding encoding, byte[] buffer, int index, int count)
    {
      char[] chars = encoding.GetChars(buffer, index, count);
      char ch = chars[0];
      if (ch == char.MinValue && chars.Length > 1)
        ch = chars[chars.Length - 1];
      return ch;
    }

    private class Class466
    {
      private readonly bool bool_0;
      private int int_0;
      private readonly Stack<WW.Math.Point2D> stack_0;
      private bool bool_1;
      private double double_0;
      private WW.Math.Point2D point2D_0;
      private bool bool_2;
      private readonly ShxFile shxFile_0;
      private readonly GeneralShape2D generalShape2D_0;
      private bool bool_3;

      internal Class466(ShxFile shxFile, bool vertical)
      {
        this.shxFile_0 = shxFile;
        this.bool_0 = vertical;
        this.stack_0 = new Stack<WW.Math.Point2D>();
        this.double_0 = 1.0;
        this.generalShape2D_0 = new GeneralShape2D();
        this.point2D_0 = WW.Math.Point2D.Zero;
        this.PenDown = true;
      }

      internal WW.Math.Point2D CurrentPosition
      {
        get
        {
          return this.point2D_0;
        }
      }

      internal bool PenDown
      {
        get
        {
          return this.bool_1;
        }
        set
        {
          this.bool_1 = value;
          this.bool_3 = false;
        }
      }

      internal bool Vertical
      {
        get
        {
          if (this.int_0 == 0)
            return this.bool_0;
          return false;
        }
      }

      internal bool IgnoreNextCommand
      {
        get
        {
          return this.bool_2;
        }
        set
        {
          this.bool_2 = value;
        }
      }

      internal GeneralShape2D Shape
      {
        get
        {
          return this.generalShape2D_0;
        }
      }

      internal ShxFile ShxFile
      {
        get
        {
          return this.shxFile_0;
        }
      }

      internal bool method_0()
      {
        bool flag = !this.bool_2;
        this.bool_2 = false;
        return flag;
      }

      internal void method_1()
      {
        ++this.int_0;
        this.bool_1 = true;
      }

      internal void method_2()
      {
        --this.int_0;
      }

      internal void method_3()
      {
        this.stack_0.Push(this.point2D_0);
      }

      internal void method_4()
      {
        this.point2D_0 = this.stack_0.Pop();
        this.bool_3 = false;
      }

      internal void method_5(double factor)
      {
        this.double_0 *= factor;
      }

      internal void method_6(double factor)
      {
        this.double_0 /= factor;
      }

      internal void method_7(double x, double y)
      {
        WW.Math.Point2D p = new WW.Math.Point2D(this.point2D_0.X + this.double_0 * x, this.point2D_0.Y + this.double_0 * y);
        if (this.bool_1)
        {
          this.method_11();
          this.generalShape2D_0.LineTo(p);
        }
        this.point2D_0 = p;
      }

      internal void method_8(double radius, double startAngle, double sweepAngle)
      {
        radius *= this.double_0;
        Vector2D vector2D1 = -radius * new Vector2D(System.Math.Cos(startAngle), System.Math.Sin(startAngle));
        WW.Math.Point2D point2D1 = this.point2D_0 + vector2D1;
        double num1 = startAngle + sweepAngle;
        Vector2D vector2D2 = vector2D1 + radius * new Vector2D(System.Math.Cos(num1), System.Math.Sin(num1));
        if (this.bool_1)
        {
          this.method_11();
          int num2 = (int) System.Math.Ceiling(2.0 * System.Math.Abs(sweepAngle) / System.Math.PI);
          if (num2 >= 5)
          {
            num2 = 4;
            sweepAngle = sweepAngle < 0.0 ? -2.0 * System.Math.PI : 2.0 * System.Math.PI;
          }
          sweepAngle /= (double) num2;
          double num3 = startAngle;
          Vector2D vector2D3 = radius * new Vector2D(System.Math.Cos(num3), System.Math.Sin(num3));
          WW.Math.Point2D p = point2D1 + vector2D3;
          if (this.generalShape2D_0.CurrentPoint != p)
            this.generalShape2D_0.LineTo(p);
          double num4 = 1.0 + System.Math.Cos(sweepAngle);
          double num5 = System.Math.Sin(sweepAngle);
          double num6 = 4.0 / 3.0 * (System.Math.Sqrt(2.0 * num4) - num4) / num5;
          for (int index = 0; index < num2; ++index)
          {
            num3 += sweepAngle;
            Vector2D vector2D4 = radius * new Vector2D(System.Math.Cos(num3), System.Math.Sin(num3));
            WW.Math.Point2D point2D2 = point2D1 + vector2D4;
            WW.Math.Point2D point2D3 = new WW.Math.Point2D(point2D1.X + vector2D3.X - num6 * vector2D3.Y, point2D1.Y + vector2D3.Y + num6 * vector2D3.X);
            WW.Math.Point2D point2D4 = new WW.Math.Point2D(point2D1.X + vector2D4.X + num6 * vector2D4.Y, point2D1.Y + vector2D4.Y - num6 * vector2D4.X);
            this.generalShape2D_0.CubicTo(point2D3.X, point2D3.Y, point2D4.X, point2D4.Y, point2D2.X, point2D2.Y);
            vector2D3 = vector2D4;
          }
        }
        this.point2D_0 += vector2D2;
      }

      internal void method_9(float x, float y, float bulge)
      {
        if (this.bool_1)
        {
          if ((double) bulge == 0.0)
          {
            this.method_7((double) x, (double) y);
          }
          else
          {
            double sweepAngle = 4.0 * System.Math.Atan((double) bulge);
            double num1 = System.Math.Sqrt((double) x * (double) x + (double) y * (double) y);
            double num2 = 1.0 / num1;
            double num3 = (double) x * num2;
            double num4 = (double) y * num2;
            double radius = num1 / (2.0 * System.Math.Sin(sweepAngle * 0.5));
            double num5 = (double) x * 0.5 - (radius - (double) bulge * num1 * 0.5) * num4;
            double startAngle = System.Math.Atan2(-((double) y * 0.5 + (radius - (double) bulge * num1 * 0.5) * num3), -num5);
            if (radius < 0.0)
              radius = -radius;
            this.method_8(radius, startAngle, sweepAngle);
          }
        }
        else
          this.point2D_0 = new WW.Math.Point2D(this.point2D_0.X + this.double_0 * (double) x, this.point2D_0.Y + this.double_0 * (double) y);
      }

      internal void method_10(IShape2D gpath, bool connect)
      {
        this.generalShape2D_0.Append(gpath, connect);
      }

      private void method_11()
      {
        if (this.bool_3)
          return;
        this.bool_3 = true;
        this.generalShape2D_0.MoveTo(this.point2D_0);
      }
    }

    private delegate int Delegate9(ShxShape.Class466 plotter, byte[] geometry, int offset);
  }
}
