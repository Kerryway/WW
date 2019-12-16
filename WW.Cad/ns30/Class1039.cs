// Decompiled with JetBrains decompiler
// Type: ns30.Class1039
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Math;
using WW.Math.Geometry;

namespace ns30
{
  internal class Class1039 : Class1038
  {
    private ITransformer4D itransformer4D_0;

    public Class1039(
      Graphics graphics,
      SmoothingMode? textSmoothingMode,
      BlinnClipper4D drawingBoundsClipper,
      ITransformer4D transformer,
      Interface22 nonTextColorContext,
      Interface22 textColorContext)
    {
      this.graphics_0 = graphics;
      this.smoothingMode_0 = graphics.SmoothingMode;
      this.nullable_0 = textSmoothingMode;
      this.blinnClipper4D_0 = drawingBoundsClipper;
      this.itransformer4D_0 = transformer;
      this.interface22_1 = nonTextColorContext;
      this.interface22_2 = textColorContext;
      this.interface22_0 = nonTextColorContext;
    }

    public ITransformer4D Transformer
    {
      get
      {
        return this.itransformer4D_0;
      }
    }
  }
}
