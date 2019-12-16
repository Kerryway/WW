// Decompiled with JetBrains decompiler
// Type: WW.Drawing.Rasterizer2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Drawing
{
  public class Rasterizer2D : IDisposable
  {
    private const double double_0 = 0.5;
    private const double double_1 = 0.333333333333333;
    private const double double_2 = 0.25;
    private const double double_3 = 0.125;
    private const double double_4 = 0.0625;
    private int int_0;
    private int int_1;
    private GCHandle gchandle_0;
    private unsafe uint* pUint_0;
    private byte[] byte_0;
    private Bitmap bitmap_0;
    private BlinnClipper2D blinnClipper2D_0;

    public unsafe Rasterizer2D(int width, int height)
    {
      this.int_0 = width;
      this.int_1 = height;
      this.byte_0 = new byte[width * height * 4];
      this.gchandle_0 = GCHandle.Alloc((object) this.byte_0, GCHandleType.Pinned);
      IntPtr scan0 = Marshal.UnsafeAddrOfPinnedArrayElement((Array) this.byte_0, 0);
      this.pUint_0 = (uint*) scan0.ToPointer();
      this.bitmap_0 = new Bitmap(width, height, width * 4, PixelFormat.Format32bppArgb, scan0);
      this.blinnClipper2D_0 = new BlinnClipper2D(new BlinnClipper2D.IInsideTester[4]
      {
        BlinnClipper2D.Fixed.RightOf.Instance,
        (BlinnClipper2D.IInsideTester) new BlinnClipper2D.Generic.LeftOf((double) (this.bitmap_0.Width - 1)),
        BlinnClipper2D.Fixed.Above.Instance,
        (BlinnClipper2D.IInsideTester) new BlinnClipper2D.Generic.Under((double) (this.bitmap_0.Height - 1))
      });
    }

    public Bitmap Bitmap
    {
      get
      {
        return this.bitmap_0;
      }
    }

    public int Width
    {
      get
      {
        return this.int_0;
      }
    }

    public int Height
    {
      get
      {
        return this.int_1;
      }
    }

    public BlinnClipper2D Clipper
    {
      get
      {
        return this.blinnClipper2D_0;
      }
    }

    public void Dispose()
    {
      if (this.bitmap_0 == null)
        return;
      this.bitmap_0.Dispose();
      this.bitmap_0 = (Bitmap) null;
      this.gchandle_0.Free();
    }

    public unsafe void Clear(uint argb)
    {
      int num = this.int_0 * this.int_1;
      uint* pUint0 = this.pUint_0;
      while (--num >= 0)
        *pUint0++ = argb;
    }

    public void DrawLineSegment(Point2D p1, Point2D p2, uint argb)
    {
      Segment2D? nullable = this.blinnClipper2D_0.Clip(new Segment2D(p1, p2));
      if (!nullable.HasValue)
        return;
      p1 = nullable.Value.Start;
      p2 = nullable.Value.End;
      this.method_0(Rasterizer2D.smethod_0(p1), Rasterizer2D.smethod_0(p2), argb);
    }

    private void method_0(System.Drawing.Point p1, System.Drawing.Point p2, uint argb)
    {
      int dx = p2.X - p1.X;
      if (dx < 0)
      {
        System.Drawing.Point point = p1;
        p1 = p2;
        p2 = point;
        dx = -dx;
      }
      int dy = p2.Y - p1.Y;
      if (dy < 0)
      {
        if (-dy > dx)
          this.method_2(p2, p1, dx, -dy, this.int_0 - 1, argb);
        else
          this.method_1(p1, p2, dx, -dy, -this.int_0 + 1, argb);
      }
      else if (dy > dx)
        this.method_2(p1, p2, dx, dy, this.int_0 + 1, argb);
      else
        this.method_1(p1, p2, dx, dy, this.int_0 + 1, argb);
    }

    private unsafe void method_1(System.Drawing.Point p1, System.Drawing.Point p2, int dx, int dy, int dpy, uint argb)
    {
      int num1 = dx << 1;
      int num2 = dy << 1;
      int num3 = num2 - dx;
      int x = p2.X;
      uint* numPtr = this.pUint_0 + p1.Y * this.int_0 + p1.X;
      *numPtr = argb;
      for (int index = p1.X + 1; index < x; ++index)
      {
        if (num3 > 0)
        {
          numPtr += dpy;
          num3 += num2 - num1;
        }
        else
        {
          ++numPtr;
          num3 += num2;
        }
        *numPtr = argb;
      }
    }

    private unsafe void method_2(System.Drawing.Point p1, System.Drawing.Point p2, int dx, int dy, int dpx, uint argb)
    {
      int num1 = dx << 1;
      int num2 = dy << 1;
      int num3 = num1 - dy;
      int y = p2.Y;
      uint* numPtr = this.pUint_0 + p1.Y * this.int_0 + p1.X;
      *numPtr = argb;
      int width = this.bitmap_0.Width;
      for (int index = p1.Y + 1; index < y; ++index)
      {
        if (num3 > 0)
        {
          numPtr += dpx;
          num3 += num1 - num2;
        }
        else
        {
          numPtr += width;
          num3 += num1;
        }
        *numPtr = argb;
      }
    }

    public unsafe void DrawQuadraticBezier(Point2D p0, Point2D p1, Point2D p2, uint argb)
    {
      if (p0.X < 0.0 && p1.X < 0.0 && p2.X < 0.0 || p0.Y < 0.0 && p1.Y < 0.0 && p2.Y < 0.0 || (p0.X >= (double) this.int_0 && p1.X >= (double) this.int_0 && p2.X >= (double) this.int_0 || p0.Y >= (double) this.int_1 && p1.Y >= (double) this.int_1 && p2.Y >= (double) this.int_1))
        return;
      p0.X += 0.5;
      p0.Y += 0.5;
      p1.X += 0.5;
      p1.Y += 0.5;
      p2.X += 0.5;
      p2.Y += 0.5;
      double x1 = p0.X;
      double y1 = p0.Y;
      double num1 = p2.X - p0.X;
      double num2 = p2.Y - p0.Y;
      double num3 = 2.0 * (p0.X - 2.0 * p1.X + p2.X);
      double num4 = 2.0 * (p0.Y - 2.0 * p1.Y + p2.Y);
      for (int index = 0; index < 6; ++index)
      {
        double num5 = 0.25 * num3;
        double num6 = 0.5 * num1 - 0.125 * num3;
        num3 = num5;
        num1 = num6;
        double num7 = 0.25 * num4;
        double num8 = 0.5 * num2 - 0.125 * num4;
        num4 = num7;
        num2 = num8;
      }
      int index1 = (int) x1;
      int num9 = (int) y1;
      if (index1 >= 0 && index1 < this.int_0 && (num9 >= 0 && num9 < this.int_1))
        (this.pUint_0 + num9 * this.int_0)[index1] = argb;
      double num10 = num3;
      double num11 = num4;
      double num12 = num1;
      double num13 = num2;
      double num14 = x1;
      double num15 = y1;
      int num16 = 16777216;
      int num17;
      for (num17 = 1073741824; num17 >= 0; num17 -= num16)
      {
        double num5 = num10;
        double num6 = num12 + num10;
        double num7 = num14 + num12;
        double num8 = num11;
        double num18 = num13 + num11;
        double num19 = num15 + num13;
        double num20 = System.Math.Abs(num12);
        double num21 = System.Math.Abs(num13);
        while (num21 < 0.5 && num20 < 0.5)
        {
          double num22 = 4.0 * num10;
          double num23 = 2.0 * num12 + num10;
          num10 = num22;
          num12 = num23;
          double num24 = 4.0 * num11;
          double num25 = 2.0 * num13 + num11;
          num11 = num24;
          num13 = num25;
          num5 = num10;
          num6 = num12 + num10;
          num7 = num14 + num12;
          num8 = num11;
          num18 = num13 + num11;
          num19 = num15 + num13;
          num20 = System.Math.Abs(num12);
          num21 = System.Math.Abs(num13);
          num16 <<= 1;
        }
        for (; (num20 > 1.0 || num21 > 1.0) && num16 > 1; num16 >>= 1)
        {
          double num22 = 0.25 * num10;
          double num23 = 0.5 * num12 - 0.125 * num10;
          num10 = num22;
          num12 = num23;
          double num24 = 0.25 * num11;
          double num25 = 0.5 * num13 - 0.125 * num11;
          num11 = num24;
          num13 = num25;
          num5 = num10;
          num6 = num12 + num10;
          num7 = num14 + num12;
          num8 = num11;
          num18 = num13 + num11;
          num19 = num15 + num13;
          num20 = System.Math.Abs(num12);
          num21 = System.Math.Abs(num13);
        }
        int index2 = (int) num7;
        int num26 = (int) num19;
        if ((index2 != index1 || num26 != num9) && (index2 >= 0 && index2 < this.int_0) && (num26 >= 0 && num26 < this.int_1))
          (this.pUint_0 + num26 * this.int_0)[index2] = argb;
        num10 = num5;
        num11 = num8;
        num12 = num6;
        num13 = num18;
        num14 = num7;
        num15 = num19;
        index1 = index2;
        num9 = num26;
      }
      if (num17 >= 0)
        return;
      int x2 = (int) p2.X;
      int y2 = (int) p2.Y;
      if (x2 >= 0 && x2 < this.int_0 && (y2 >= 0 && y2 < this.int_1))
        (this.pUint_0 + y2 * this.int_0)[x2] = argb;
      int num27 = System.Math.Abs(x2 - index1);
      int num28 = System.Math.Abs(y2 - num9);
      if (num27 <= 1 && num28 <= 1 || num16 <= 1)
        return;
      int num29 = num17 + num16;
      while (num29 > 0)
      {
        int num5;
        double num6;
        double num7;
        double num8;
        double num18;
        double num19;
        double num20;
        int num21;
        do
        {
          double num22 = 0.25 * num10;
          double num23 = 0.5 * num12 - 0.125 * num10;
          num10 = num22;
          num12 = num23;
          double num24 = 0.25 * num11;
          double num25 = 0.5 * num13 - 0.125 * num11;
          num11 = num24;
          num13 = num25;
          num6 = num10;
          num7 = num12 + num10;
          num8 = num14 + num12;
          num18 = num11;
          num19 = num13 + num11;
          num20 = num15 + num13;
          num21 = System.Math.Abs((int) num8 - index1);
          num5 = System.Math.Abs((int) num20 - num9);
          num16 >>= 1;
        }
        while ((num21 > 1 || num5 > 1) && num16 > 1);
        int index2 = (int) num8;
        int num26 = (int) num20;
        if ((index2 != index1 || num26 != num9) && (index2 >= 0 && index2 < this.int_0) && (num26 >= 0 && num26 < this.int_1))
          (this.pUint_0 + num26 * this.int_0)[index2] = argb;
        num29 -= num16;
        num10 = num6;
        num11 = num18;
        num12 = num7;
        num13 = num19;
        num14 = num8;
        num15 = num20;
        index1 = index2;
        num9 = num26;
      }
    }

    public unsafe void DrawCubicBezier(Point2D p0, Point2D p1, Point2D p2, Point2D p3, uint argb)
    {
      if (p0.X < 0.0 && p1.X < 0.0 && (p2.X < 0.0 && p3.X < 0.0) || p0.Y < 0.0 && p1.Y < 0.0 && (p2.Y < 0.0 && p3.Y < 0.0) || (p0.X >= (double) this.int_0 && p1.X >= (double) this.int_0 && (p2.X >= (double) this.int_0 && p3.X >= (double) this.int_0) || p0.Y >= (double) this.int_1 && p1.Y >= (double) this.int_1 && (p2.Y >= (double) this.int_1 && p3.Y >= (double) this.int_1)))
        return;
      p0.X += 0.5;
      p0.Y += 0.5;
      p1.X += 0.5;
      p1.Y += 0.5;
      p2.X += 0.5;
      p2.Y += 0.5;
      p3.X += 0.5;
      p3.Y += 0.5;
      double x1 = p0.X;
      double y1 = p0.Y;
      double num1 = p3.X - p0.X;
      double num2 = p3.Y - p0.Y;
      double num3 = 6.0 * (p1.X - 2.0 * p2.X + p3.X);
      double num4 = 6.0 * (p1.Y - 2.0 * p2.Y + p3.Y);
      double num5 = 6.0 * (num1 + 3.0 * (p1.X - p2.X));
      double num6 = 6.0 * (num2 + 3.0 * (p1.Y - p2.Y));
      for (int index = 0; index < 6; ++index)
      {
        double num7 = 0.125 * num5;
        double num8 = 0.25 * num3 - 0.125 * num5;
        double num9 = 0.5 * num1 - 0.125 * num3 + 1.0 / 16.0 * num5;
        num5 = num7;
        num3 = num8;
        num1 = num9;
        double num10 = 0.125 * num6;
        double num11 = 0.25 * num4 - 0.125 * num6;
        double num12 = 0.5 * num2 - 0.125 * num4 + 1.0 / 16.0 * num6;
        num6 = num10;
        num4 = num11;
        num2 = num12;
      }
      int index1 = (int) x1;
      int num13 = (int) y1;
      if (index1 >= 0 && index1 < this.int_0 && (num13 >= 0 && num13 < this.int_1))
        (this.pUint_0 + num13 * this.int_0)[index1] = argb;
      double num14 = num5;
      double num15 = num6;
      double num16 = num3;
      double num17 = num4;
      double num18 = num1;
      double num19 = num2;
      double num20 = x1;
      double num21 = y1;
      int num22 = 16777216;
      int num23;
      for (num23 = 1073741824; num23 >= 0; num23 -= num22)
      {
        double num7 = num16 + num14;
        double num8 = num18 + num16;
        double num9 = num20 + num18;
        double num10 = num17 + num15;
        double num11 = num19 + num17;
        double num12 = num21 + num19;
        double num24 = System.Math.Abs(num18);
        double num25 = System.Math.Abs(num19);
        while (num25 < 0.5 && num24 < 0.5)
        {
          double num26 = 8.0 * num14;
          double num27 = 4.0 * (num16 + num14);
          double num28 = 2.0 * num18 + num16;
          num14 = num26;
          num16 = num27;
          num18 = num28;
          double num29 = 8.0 * num15;
          double num30 = 4.0 * (num17 + num15);
          double num31 = 2.0 * num19 + num17;
          num15 = num29;
          num17 = num30;
          num19 = num31;
          num5 = num14;
          num7 = num16 + num14;
          num8 = num18 + num16;
          num9 = num20 + num18;
          num6 = num15;
          num10 = num17 + num15;
          num11 = num19 + num17;
          num12 = num21 + num19;
          num24 = System.Math.Abs(num18);
          num25 = System.Math.Abs(num19);
          num22 <<= 1;
        }
        for (; (num24 > 1.0 || num25 > 1.0) && num22 > 1; num22 >>= 1)
        {
          double num26 = 0.125 * num14;
          double num27 = 0.25 * num16 - 0.125 * num14;
          double num28 = 0.5 * num18 - 0.125 * num16 + 1.0 / 16.0 * num14;
          num14 = num26;
          num16 = num27;
          num18 = num28;
          double num29 = 0.125 * num15;
          double num30 = 0.25 * num17 - 0.125 * num15;
          double num31 = 0.5 * num19 - 0.125 * num17 + 1.0 / 16.0 * num15;
          num15 = num29;
          num17 = num30;
          num19 = num31;
          num5 = num14;
          num7 = num16 + num14;
          num8 = num18 + num16;
          num9 = num20 + num18;
          num6 = num15;
          num10 = num17 + num15;
          num11 = num19 + num17;
          num12 = num21 + num19;
          num24 = System.Math.Abs(num18);
          num25 = System.Math.Abs(num19);
        }
        int index2 = (int) num9;
        int num32 = (int) num12;
        if ((index2 != index1 || num32 != num13) && (index2 >= 0 && index2 < this.int_0) && (num32 >= 0 && num32 < this.int_1))
          (this.pUint_0 + num32 * this.int_0)[index2] = argb;
        num14 = num5;
        num15 = num6;
        num16 = num7;
        num17 = num10;
        num18 = num8;
        num19 = num11;
        num20 = num9;
        num21 = num12;
        index1 = index2;
        num13 = num32;
      }
      if (num23 >= 0)
        return;
      int x2 = (int) p3.X;
      int y2 = (int) p3.Y;
      if (x2 >= 0 && x2 < this.int_0 && (y2 >= 0 && y2 < this.int_1))
        (this.pUint_0 + y2 * this.int_0)[x2] = argb;
      int num33 = System.Math.Abs(x2 - index1);
      int num34 = System.Math.Abs(y2 - num13);
      if (num33 <= 1 && num34 <= 1 || num22 <= 1)
        return;
      int num35 = num23 + num22;
      while (num35 > 0)
      {
        int num7;
        double num8;
        double num9;
        double num10;
        double num11;
        double num12;
        double num24;
        double num25;
        double num26;
        int num27;
        do
        {
          double num28 = 0.125 * num14;
          double num29 = 0.25 * num16 - 0.125 * num14;
          double num30 = 0.5 * num18 - 0.125 * num16 + 1.0 / 16.0 * num14;
          num14 = num28;
          num16 = num29;
          num18 = num30;
          double num31 = 0.125 * num15;
          double num32 = 0.25 * num17 - 0.125 * num15;
          double num36 = 0.5 * num19 - 0.125 * num17 + 1.0 / 16.0 * num15;
          num15 = num31;
          num17 = num32;
          num19 = num36;
          num8 = num14;
          num9 = num16 + num14;
          num10 = num18 + num16;
          num11 = num20 + num18;
          num12 = num15;
          num24 = num17 + num15;
          num25 = num19 + num17;
          num26 = num21 + num19;
          num27 = System.Math.Abs((int) num11 - index1);
          num7 = System.Math.Abs((int) num26 - num13);
          num22 >>= 1;
        }
        while ((num27 > 1 || num7 > 1) && num22 > 1);
        int index2 = (int) num11;
        int num37 = (int) num26;
        if ((index2 != index1 || num37 != num13) && (index2 >= 0 && index2 < this.int_0) && (num37 >= 0 && num37 < this.int_1))
          (this.pUint_0 + num37 * this.int_0)[index2] = argb;
        num35 -= num22;
        num14 = num8;
        num15 = num12;
        num16 = num9;
        num17 = num24;
        num18 = num10;
        num19 = num25;
        num20 = num11;
        num21 = num26;
        index1 = index2;
        num13 = num37;
      }
    }

    public void DrawShape(GeneralShape2D shape, uint argb)
    {
      int segmentCount = shape.SegmentCount;
      SegmentType[] segmentTypes = shape.SegmentTypes;
      Point2D[] coordinates = shape.Coordinates;
      int index1 = 0;
      Point2D point2D = Point2D.Zero;
      for (int index2 = 0; index2 < segmentCount; ++index2)
      {
        switch (segmentTypes[index2])
        {
          case SegmentType.MoveTo:
            point2D = coordinates[index1];
            ++index1;
            break;
          case SegmentType.LineTo:
            Point2D p2_1 = coordinates[index1];
            this.DrawLineSegment(point2D, p2_1, argb);
            point2D = p2_1;
            ++index1;
            break;
          case SegmentType.QuadTo:
            Point2D[] point2DArray1 = coordinates;
            int index3 = index1;
            int num1 = index3 + 1;
            Point2D p1_1 = point2DArray1[index3];
            Point2D[] point2DArray2 = coordinates;
            int index4 = num1;
            index1 = index4 + 1;
            Point2D p2_2 = point2DArray2[index4];
            this.DrawQuadraticBezier(point2D, p1_1, p2_2, argb);
            point2D = p2_2;
            break;
          case SegmentType.CubicTo:
            Point2D[] point2DArray3 = coordinates;
            int index5 = index1;
            int num2 = index5 + 1;
            Point2D p1_2 = point2DArray3[index5];
            Point2D[] point2DArray4 = coordinates;
            int index6 = num2;
            int num3 = index6 + 1;
            Point2D p2_3 = point2DArray4[index6];
            Point2D[] point2DArray5 = coordinates;
            int index7 = num3;
            index1 = index7 + 1;
            Point2D p3 = point2DArray5[index7];
            this.DrawCubicBezier(point2D, p1_2, p2_3, p3, argb);
            point2D = p3;
            break;
          case SegmentType.Close:
            Point2D p2_4 = coordinates[0];
            this.DrawLineSegment(point2D, p2_4, argb);
            point2D = p2_4;
            break;
        }
      }
    }

    public unsafe void DrawPoint(int x, int y, uint argb)
    {
      if (x < 0 || x >= this.int_0 || (y < 0 || y >= this.int_1))
        return;
      (this.pUint_0 + y * this.int_0)[x] = argb;
    }

    public unsafe void DrawPoint(double x, double y, uint argb)
    {
      int index = (int) System.Math.Round(x);
      int num = (int) System.Math.Round(y);
      if (index < 0 || index >= this.int_0 || (num < 0 || num >= this.int_1))
        return;
      (this.pUint_0 + num * this.int_0)[index] = argb;
    }

    public unsafe void DrawPointAtOrigin(uint argb)
    {
      *this.pUint_0 = argb;
    }

    private static System.Drawing.Point smethod_0(Point2D p)
    {
      return new System.Drawing.Point((int) System.Math.Round(p.X), (int) System.Math.Round(p.Y));
    }
  }
}
