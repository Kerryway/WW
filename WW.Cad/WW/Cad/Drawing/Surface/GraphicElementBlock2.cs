// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.GraphicElementBlock2
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class GraphicElementBlock2 : IGraphicElementBlock
  {
    private LinkedList<IGraphicElement> linkedList_0 = new LinkedList<IGraphicElement>();
    private Matrix4D matrix4D_0;
    private LinkedListNode<IGraphicElement> linkedListNode_0;
    private bool bool_0;
    private bool bool_1;
    private Color color_0;
    private DxfLineType dxfLineType_0;
    private EntityColor entityColor_0;
    private DxfLineType dxfLineType_1;

    public GraphicElementBlock2(
      Matrix4D transform,
      DxfLayer layer,
      EntityColor byBlockColor,
      DxfLineType byBlockLineType)
    {
      this.matrix4D_0 = transform;
      this.bool_0 = layer.Enabled;
      this.bool_1 = layer.Frozen;
      this.color_0 = layer.Color;
      this.dxfLineType_0 = layer.LineType;
      this.entityColor_0 = byBlockColor;
      this.dxfLineType_1 = byBlockLineType;
      this.linkedListNode_0 = this.linkedList_0.AddLast((IGraphicElement) NullGraphicElement.Instance);
      this.linkedList_0.AddLast((IGraphicElement) NullGraphicElement.Instance);
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

    public bool LayerEnabled
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public bool LayerFrozen
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
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

    public DxfLineType ByLayerLineType
    {
      get
      {
        return this.dxfLineType_0;
      }
      set
      {
        this.dxfLineType_0 = value;
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

    public DxfLineType ByBlockLineType
    {
      get
      {
        return this.dxfLineType_1;
      }
      set
      {
        this.dxfLineType_1 = value;
      }
    }

    public bool Matches(DxfLayer layer, EntityColor byBlockColor, DxfLineType byBlockLineType)
    {
      if (layer.Enabled == this.bool_0 && layer.Frozen == this.bool_1 && (layer.Color.ToArgb() == this.color_0.ToArgb() && layer.LineType == this.ByLayerLineType && byBlockColor.ToArgb() == this.entityColor_0.ToArgb()))
        return byBlockLineType == this.ByBlockLineType;
      return false;
    }

    public void Add(IGraphicElement graphicElement)
    {
      this.linkedListNode_0 = this.linkedList_0.AddAfter(this.linkedListNode_0, graphicElement);
    }
  }
}
