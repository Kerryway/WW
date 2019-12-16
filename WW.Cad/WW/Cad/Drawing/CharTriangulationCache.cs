// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.CharTriangulationCache
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns33;
using System.Collections.Generic;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public class CharTriangulationCache
  {
    private Dictionary<Struct13, Class454> dictionary_0 = new Dictionary<Struct13, Class454>();

    internal Class454 method_0(IShape2D shape, GraphicsConfig config)
    {
      Struct13 key = new Struct13(shape, config.ShapeFlattenEpsilon);
      Class454 class454_1;
      if (this.dictionary_0.TryGetValue(key, out class454_1))
        return class454_1;
      Class454 class454_2 = new Class454(shape, config);
      this.dictionary_0.Add(key, class454_2);
      return class454_2;
    }
  }
}
