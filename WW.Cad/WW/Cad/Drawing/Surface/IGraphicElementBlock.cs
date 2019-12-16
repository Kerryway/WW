// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.IGraphicElementBlock
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public interface IGraphicElementBlock
  {
    LinkedList<IGraphicElement> GraphicElements { get; }

    void Add(IGraphicElement graphicElement);

    Matrix4D Transform { get; set; }
  }
}
