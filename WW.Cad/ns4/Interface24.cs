// Decompiled with JetBrains decompiler
// Type: ns4.Interface24
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math;

namespace ns4
{
  internal interface Interface24
  {
    Vector2D Offset { get; set; }

    Class596 Settings { get; }

    Bounds2D GetBounds(Enum24 whiteSpaceHandling, Class985 resultLayoutInfo);

    void imethod_0(ref Vector2D baselinePos, double height, Enum24 whiteSpaceHandlingFlags);

    bool Breakable { get; }

    Interface24[] imethod_1(double width, Interface25 breaker);

    Vector2D? imethod_2(char ch, Enum24 whiteSpaceHandlingFlags);

    void imethod_3(ICollection<Class908> collector, Matrix4D insertionTrafo, short lineWeight);
  }
}
