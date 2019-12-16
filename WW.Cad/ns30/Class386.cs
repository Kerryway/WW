// Decompiled with JetBrains decompiler
// Type: ns30.Class386
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns33;
using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Cad.Drawing;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace ns30
{
  internal class Class386 : Class385
  {
    private Rasterizer2D rasterizer2D_0;

    public Class386(
      GraphicsConfig graphicsConfig,
      Graphics graphics,
      Rasterizer2D fastRasterizer,
      SmoothingMode? textSmoothingMode,
      BlinnClipper4D drawingBoundsClipper,
      Matrix4D transform,
      Interface38 textLineWeightScaler,
      Interface38 nonTextLineWeightScaler,
      float fixedTextPenWidth,
      float fixedNonTextPenWidth,
      Interface22 nonTextColorContext,
      Interface22 textColorContext)
      : base(graphicsConfig, graphics, textSmoothingMode, drawingBoundsClipper, transform, textLineWeightScaler, nonTextLineWeightScaler, fixedTextPenWidth, fixedNonTextPenWidth, nonTextColorContext, textColorContext)
    {
      this.rasterizer2D_0 = fastRasterizer;
    }

    public Rasterizer2D FastRasterizer
    {
      get
      {
        return this.rasterizer2D_0;
      }
    }
  }
}
