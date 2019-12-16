// Decompiled with JetBrains decompiler
// Type: ns4.Interface34
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;
using WW.Math;
using WW.Math.Geometry;

namespace ns4
{
  internal interface Interface34
  {
    string Text { get; }

    Interface14 Font { get; }

    Color Color { get; }

    short LineWeight { get; }

    Vector3D Draw(IPathDrawer drawer, Matrix4D transformation, double extrusion);

    IShape2D CanonicalPath { get; }

    IShape2D TransformedPath { get; }

    Matrix2D BasicTransformation { get; }

    bool Filled { get; }

    Vector2D CanonicalAdvance { get; }

    Vector2D Advance { get; }
  }
}
