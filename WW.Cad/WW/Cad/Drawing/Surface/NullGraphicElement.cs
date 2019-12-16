﻿// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.NullGraphicElement
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Drawing.Surface
{
  public class NullGraphicElement : IGraphicElement
  {
    public static readonly NullGraphicElement Instance = new NullGraphicElement();

    private NullGraphicElement()
    {
    }

    public void Accept(IGraphicElementVisitor visitor)
    {
      visitor.Visit(this);
    }
  }
}
