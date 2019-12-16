// Decompiled with JetBrains decompiler
// Type: ns4.Interface14
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;
using WW.Text;

namespace ns4
{
  internal interface Interface14
  {
    Interface34 GetText(string text, WW.Cad.Model.Color color, short lineWeight, bool vertical);

    bool Filled { get; }

    Interface0 Metrics { get; }

    Font SystemFont { get; }

    bool imethod_0(char ch);

    ICanonicalGlyph imethod_1(char c, bool vertical);
  }
}
