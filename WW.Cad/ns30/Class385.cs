// Decompiled with JetBrains decompiler
// Type: ns30.Class385
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns33;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Cad.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace ns30
{
  internal class Class385 : IDisposable
  {
    private Interface22 interface22_3 = (Interface22) new Class1002();
    public Pen pen_0 = new Pen(Color.Red) { MiterLimit = 2f, StartCap = LineCap.Round, EndCap = LineCap.Round };
    public SolidBrush solidBrush_0 = new SolidBrush(Color.Red);
    private GraphicsConfig graphicsConfig_0;
    private Graphics graphics_0;
    private SmoothingMode? nullable_0;
    private SmoothingMode smoothingMode_0;
    private BlinnClipper4D blinnClipper4D_0;
    private Matrix4D matrix4D_0;
    private Interface38 interface38_0;
    private Interface38 interface38_1;
    private Interface38 interface38_2;
    private float float_0;
    private float float_1;
    private float float_2;
    private Interface22 interface22_0;
    private Interface22 interface22_1;
    private Interface22 interface22_2;

    public Class385(
      GraphicsConfig graphicsConfig,
      Graphics graphics,
      SmoothingMode? textSmoothingMode,
      BlinnClipper4D drawingBoundsClipper,
      Matrix4D transform,
      Interface38 textLineWeightScaler,
      Interface38 nonTextLineWeightScaler,
      float fixedTextPenWidth,
      float fixedNonTextPenWidth,
      Interface22 nonTextColorContext,
      Interface22 textColorContext)
    {
      this.graphicsConfig_0 = graphicsConfig;
      this.graphics_0 = graphics;
      this.smoothingMode_0 = graphics.SmoothingMode;
      this.nullable_0 = textSmoothingMode;
      this.blinnClipper4D_0 = drawingBoundsClipper;
      this.matrix4D_0 = transform;
      this.interface38_1 = textLineWeightScaler;
      this.interface38_2 = nonTextLineWeightScaler;
      this.float_1 = fixedTextPenWidth;
      this.float_2 = fixedNonTextPenWidth;
      this.interface22_1 = nonTextColorContext;
      this.interface22_2 = textColorContext;
      this.interface22_0 = nonTextColorContext;
      this.interface38_0 = nonTextLineWeightScaler;
      this.float_0 = fixedNonTextPenWidth;
    }

    public GraphicsConfig GraphicsConfig
    {
      get
      {
        return this.graphicsConfig_0;
      }
    }

    public Graphics Graphics
    {
      get
      {
        return this.graphics_0;
      }
    }

    public SmoothingMode InitialSmoothingMode
    {
      get
      {
        return this.smoothingMode_0;
      }
    }

    public BlinnClipper4D DrawingBoundsClipper
    {
      get
      {
        return this.blinnClipper4D_0;
      }
    }

    public Matrix4D Transform
    {
      get
      {
        return this.matrix4D_0;
      }
    }

    public Interface22 ColorContext
    {
      get
      {
        return this.interface22_0;
      }
    }

    public Interface22 EraseColorContext
    {
      get
      {
        return this.interface22_3;
      }
    }

    public void method_0()
    {
      if (this.nullable_0.HasValue)
        this.graphics_0.SmoothingMode = this.nullable_0.Value;
      this.interface22_0 = this.interface22_2;
      this.interface38_0 = this.interface38_1;
      this.float_0 = this.float_1;
    }

    public void method_1()
    {
      if (this.nullable_0.HasValue)
        this.graphics_0.SmoothingMode = this.smoothingMode_0;
      this.interface22_0 = this.interface22_1;
      this.interface38_0 = this.interface38_2;
      this.float_0 = this.float_2;
    }

    public void method_2()
    {
      if (this.nullable_0.HasValue)
        this.graphics_0.SmoothingMode = this.smoothingMode_0;
      this.interface22_0 = this.interface22_3;
      this.interface38_0 = this.interface38_2;
      this.float_0 = this.float_2;
    }

    public void method_3(short lineWeight)
    {
      this.pen_0.Width = lineWeight == (short) 0 ? this.float_0 : (float) this.interface38_0.imethod_0(lineWeight);
    }

    public void Dispose()
    {
      if (this.pen_0 != null)
      {
        this.pen_0.Dispose();
        this.pen_0 = (Pen) null;
      }
      if (this.solidBrush_0 == null)
        return;
      this.solidBrush_0.Dispose();
      this.solidBrush_0 = (SolidBrush) null;
    }
  }
}
