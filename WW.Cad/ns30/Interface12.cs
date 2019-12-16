// Decompiled with JetBrains decompiler
// Type: ns30.Interface12
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Drawing;
using WW.Math;

namespace ns30
{
  internal interface Interface12
  {
    void Draw(Class385 context);

    void Draw(Class386 context);

    void BoundingBox(Bounds3D bounds, Matrix4D transform);

    void Transform(ITransformer4D transformer, GraphicsConfig graphicsConfig);
  }
}
