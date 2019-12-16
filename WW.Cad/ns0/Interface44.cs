// Decompiled with JetBrains decompiler
// Type: ns0.Interface44
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;

namespace ns0
{
  internal interface Interface44
  {
    Font Font { get; }

    FontFamily Family { get; }

    FontStyle Style { get; }

    double Height { get; }

    double Ascent { get; }

    double CadAscent { get; }

    double Descent { get; }

    double InternalLeading { get; }

    double ExternalLeading { get; }

    double AverageCharacterWidth { get; }

    double MaximumCharacterWidth { get; }

    double Weight { get; }

    double Overhang { get; }

    double DigitizedAspectX { get; }

    double DigitizedAspectY { get; }
  }
}
