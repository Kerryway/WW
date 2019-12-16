// Decompiled with JetBrains decompiler
// Type: ns4.Interface35
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;
using WW.Math;
using WW.Text;

namespace ns4
{
  internal interface Interface35 : ICanonicalGlyph
  {
    bool IsValid { get; }

    void Draw(IPathDrawer drawer, Matrix4D trafo, Color color, short lineWeight, double extent);

    Bounds2D GetBounds();
  }
}
