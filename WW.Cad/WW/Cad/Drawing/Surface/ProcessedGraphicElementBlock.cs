// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.ProcessedGraphicElementBlock
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class ProcessedGraphicElementBlock
  {
    private List<GraphicElement1> list_0 = new List<GraphicElement1>();
    private List<ProcessedGraphicElementInsert> list_1 = new List<ProcessedGraphicElementInsert>();
    private Matrix4D matrix4D_0;

    public ProcessedGraphicElementBlock(Matrix4D transform)
    {
      this.matrix4D_0 = transform;
    }

    public List<GraphicElement1> GraphicElements
    {
      get
      {
        return this.list_0;
      }
    }

    public List<ProcessedGraphicElementInsert> Inserts
    {
      get
      {
        return this.list_1;
      }
    }

    public Matrix4D Transform
    {
      get
      {
        return this.matrix4D_0;
      }
      set
      {
        this.matrix4D_0 = value;
      }
    }
  }
}
