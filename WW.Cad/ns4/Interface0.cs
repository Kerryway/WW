// Decompiled with JetBrains decompiler
// Type: ns4.Interface0
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math;

namespace ns4
{
  internal interface Interface0
  {
    double FontHeight { get; }

    double Ascent { get; }

    double Descent { get; }

    Bounds2D GetBounds(string text, Enum24 whiteSpaceHandling);

    Vector2D imethod_0(string text, IList<Vector2D> characterAdvances);

    Vector2D LineFeedAdvance { get; }

    Matrix2D CharTransformation { get; }

    double CharSpacingFactor { get; }

    double SystemFontHeight { get; }

    bool IsVertical { get; }
  }
}
