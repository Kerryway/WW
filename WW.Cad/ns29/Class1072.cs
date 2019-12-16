// Decompiled with JetBrains decompiler
// Type: ns29.Class1072
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using System.Windows.Media;
using WW.Drawing;

namespace ns29
{
  internal sealed class Class1072
  {
    private static readonly Dictionary<int, Brush> dictionary_0 = new Dictionary<int, Brush>(257);
    private static readonly Dictionary<PenInfo, Pen> dictionary_1 = new Dictionary<PenInfo, Pen>(257);

    internal static Pen smethod_0(PenInfo penInfo)
    {
      Pen pen;
      if (!Class1072.dictionary_1.TryGetValue(penInfo, out pen))
      {
        pen = new Pen(Class1072.smethod_1(penInfo.Color), penInfo.LineWidth);
        pen.MiterLimit = 2.0;
        pen.Freeze();
        Class1072.dictionary_1[penInfo] = pen;
      }
      return pen;
    }

    internal static Brush smethod_1(ArgbColor color)
    {
      int argb = color.Argb;
      Brush brush;
      if (!Class1072.dictionary_0.TryGetValue(argb, out brush))
      {
        brush = (Brush) new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
        brush.Freeze();
        Class1072.dictionary_0[argb] = brush;
      }
      return brush;
    }
  }
}
