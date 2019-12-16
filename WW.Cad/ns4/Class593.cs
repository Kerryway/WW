// Decompiled with JetBrains decompiler
// Type: ns4.Class593
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Math;
using WW.Math.Geometry;
using WW.Text;

namespace ns4
{
  internal class Class593 : Interface14
  {
    private readonly Class26 class26_0;

    public Class593(Class26 textMetrics)
    {
      this.class26_0 = textMetrics;
    }

    public Interface34 GetText(
      string text,
      WW.Cad.Model.Color color,
      short lineWeight,
      bool vertical)
    {
      GeneralShape2D generalShape2D;
      using (GraphicsPath graphicsPath = this.class26_0.method_1(text))
        generalShape2D = (GeneralShape2D) graphicsPath;
      generalShape2D.FillMode = WW.Math.Geometry.FillMode.Winding;
      IShape2D path = generalShape2D.HasSegments ? (IShape2D) new CachedBoundsShape2D((IShape2D) generalShape2D) : (IShape2D) NullShape2D.Instance;
      return (Interface34) new Class865(text, (Interface14) this, color, lineWeight, path, this.class26_0.CharTransformation, Transformation2D.Scaling(this.class26_0.CanonicalScaling), this.class26_0.imethod_0(text, (IList<Vector2D>) null));
    }

    public bool Filled
    {
      get
      {
        return true;
      }
    }

    public Interface0 Metrics
    {
      get
      {
        return (Interface0) this.class26_0;
      }
    }

    public Font SystemFont
    {
      get
      {
        return this.class26_0.Font;
      }
    }

    public bool imethod_0(char ch)
    {
      return this.class26_0.method_0(ch);
    }

    public bool IsFallback
    {
      get
      {
        return this.class26_0.IsFallback;
      }
    }

    public ICanonicalGlyph imethod_1(char c, bool vertical)
    {
      Interface35 wrappedGlyph = (Interface35) this.class26_0.method_2(c);
      if (!vertical)
        return (ICanonicalGlyph) wrappedGlyph;
      return (ICanonicalGlyph) new Class597(wrappedGlyph);
    }
  }
}
