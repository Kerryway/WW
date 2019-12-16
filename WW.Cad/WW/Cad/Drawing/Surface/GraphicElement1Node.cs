// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.GraphicElement1Node
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Drawing;

namespace WW.Cad.Drawing.Surface
{
  public class GraphicElement1Node : GraphicElement1
  {
    private GraphicElement1Node graphicElement1Node_0;

    public GraphicElement1Node()
    {
    }

    public GraphicElement1Node(ArgbColor color)
      : base(color)
    {
    }

    public GraphicElement1Node(Geometry geometry, ArgbColor color)
      : base(geometry, color)
    {
    }

    public GraphicElement1Node Next
    {
      get
      {
        return this.graphicElement1Node_0;
      }
      set
      {
        this.graphicElement1Node_0 = value;
      }
    }

    public override void Accept(IGraphicElementVisitor visitor)
    {
      visitor.Visit(this);
    }
  }
}
