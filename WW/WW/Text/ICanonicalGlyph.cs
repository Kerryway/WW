// Decompiled with JetBrains decompiler
// Type: WW.Text.ICanonicalGlyph
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using WW.Math;
using WW.Math.Geometry;

namespace WW.Text
{
  public interface ICanonicalGlyph
  {
    char Letter { get; }

    IShape2D Path { get; }

    bool Filled { get; }

    Vector2D Advance { get; }
  }
}
