// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.GraphicElementBlock1
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class GraphicElementBlock1 : IGraphicElementBlock
  {
    private LinkedList<IGraphicElement> linkedList_0 = new LinkedList<IGraphicElement>();
    private Matrix4D matrix4D_0;
    private LinkedListNode<IGraphicElement> linkedListNode_0;
    private Color color_0;
    private EntityColor entityColor_0;

    public GraphicElementBlock1()
    {
      this.linkedListNode_0 = this.linkedList_0.AddLast((IGraphicElement) NullGraphicElement.Instance);
      this.linkedList_0.AddLast((IGraphicElement) NullGraphicElement.Instance);
    }

    public GraphicElementBlock1(Color byLayerColor, EntityColor byBlockColor)
      : this()
    {
      this.color_0 = byLayerColor;
      this.entityColor_0 = byBlockColor;
    }

    public LinkedList<IGraphicElement> GraphicElements
    {
      get
      {
        return this.linkedList_0;
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

    public Color ByLayerColor
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
      }
    }

    public EntityColor ByBlockColor
    {
      get
      {
        return this.entityColor_0;
      }
      set
      {
        this.entityColor_0 = value;
      }
    }

    public bool Matches(Color byLayerColor, EntityColor byBlockColor)
    {
      if (byLayerColor.ToArgb() == this.color_0.ToArgb())
        return byBlockColor.ToArgb() == this.entityColor_0.ToArgb();
      return false;
    }

    public void Add(IGraphicElement graphicElement)
    {
      this.linkedListNode_0 = this.linkedList_0.AddAfter(this.linkedListNode_0, graphicElement);
    }
  }
}
