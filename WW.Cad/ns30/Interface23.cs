// Decompiled with JetBrains decompiler
// Type: ns30.Interface23
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Drawing;
using WW.Math;

namespace ns30
{
  internal interface Interface23
  {
    void Draw(
      Graphics graphics,
      Class335 coloredPath,
      bool fill,
      Matrix4D transform,
      Class385 context);

    void Draw(
      Graphics graphics,
      Rasterizer2D fastRasterizer,
      Class335 coloredPath,
      bool fill,
      Matrix4D transform,
      Class385 context);

    void Draw(GraphicsPath graphicsPath, bool fill, Matrix4D transform);

    void BoundingBox(Bounds3D bounds, Matrix4D transform);

    void Transform(ITransformer4D transformer);
  }
}
