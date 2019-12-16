// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.Graphics
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class Graphics : IGraphicElementBlock
  {
    private Matrix4D matrix4D_0 = Matrix4D.Identity;
    private readonly Dictionary<DxfEntity, Graphics.EntityInfo> dictionary_0 = new Dictionary<DxfEntity, Graphics.EntityInfo>();
    private readonly Dictionary<DxfBlock, Graphics.BlockInfo> dictionary_1 = new Dictionary<DxfBlock, Graphics.BlockInfo>();
    private readonly LinkedList<IGraphicElement> linkedList_0 = new LinkedList<IGraphicElement>();
    private LinkedListNode<IGraphicElement> linkedListNode_0;

    public Graphics()
    {
      this.linkedListNode_0 = this.linkedList_0.AddLast((IGraphicElement) NullGraphicElement.Instance);
      this.linkedList_0.AddLast((IGraphicElement) NullGraphicElement.Instance);
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

    public LinkedList<IGraphicElement> GraphicElements
    {
      get
      {
        return this.linkedList_0;
      }
    }

    public void Add(IGraphicElement graphicElement)
    {
      this.linkedListNode_0 = this.linkedList_0.AddAfter(this.linkedListNode_0, graphicElement);
    }

    public bool AddExistingGraphicElement1(
      IGraphicElementBlock graphicElementBlock,
      DxfEntity entity,
      ArgbColor color)
    {
      bool flag = true;
      Graphics.EntityInfo entityInfo;
      if (this.dictionary_0.TryGetValue(entity, out entityInfo))
      {
        GraphicElement1 graphicElement1 = entityInfo.GetGraphicElement1(color);
        if (graphicElement1 == null)
        {
          graphicElement1 = new GraphicElement1(entityInfo.Geometry, color);
          entityInfo.GraphicElements.Add((IGraphicElement) graphicElement1);
        }
        graphicElementBlock.Add((IGraphicElement) graphicElement1);
        flag = false;
      }
      return flag;
    }

    public bool AddExistingGraphicElement2(
      IGraphicElementBlock graphicElementBlock,
      DxfEntity entity,
      ArgbColor color,
      DxfLineType lineType,
      double lineTypeScale,
      bool plinegen)
    {
      bool flag = true;
      Graphics.EntityInfo entityInfo;
      if (this.dictionary_0.TryGetValue(entity, out entityInfo))
      {
        GraphicElement2 graphicElement2 = entityInfo.GetGraphicElement2(color, lineType, lineTypeScale, plinegen);
        if (graphicElement2 == null)
        {
          graphicElement2 = new GraphicElement2(entityInfo.Geometry, color, lineType, lineTypeScale, plinegen);
          entityInfo.GraphicElements.Add((IGraphicElement) graphicElement2);
        }
        graphicElementBlock.Add((IGraphicElement) graphicElement2);
        flag = false;
      }
      return flag;
    }

    public void AddNewGraphicElement(
      DxfEntity entity,
      IGraphicElementBlock graphicElementBlock,
      GraphicElement1 graphicElement)
    {
      if (graphicElement.Geometry == null)
        throw new Exception();
      Graphics.EntityInfo entityInfo = new Graphics.EntityInfo() { Geometry = graphicElement.Geometry };
      entityInfo.GraphicElements.Add((IGraphicElement) graphicElement);
      this.dictionary_0.Add(entity, entityInfo);
      graphicElementBlock.Add((IGraphicElement) graphicElement);
    }

    public bool GetGraphicElementInsert(
      IGraphicElementBlock graphicElementBlock,
      DxfEntity insert,
      DxfLayer layer,
      EntityColor byBlockColor,
      DxfLineType byBlockLineType,
      out GraphicElementInsert graphicElement)
    {
      Graphics.EntityInfo entityInfo;
      bool flag;
      if (this.dictionary_0.TryGetValue(insert, out entityInfo))
      {
        graphicElement = entityInfo.GetGraphicElementInsert(layer, byBlockColor, byBlockLineType);
        if (graphicElement == null)
        {
          flag = true;
          graphicElement = new GraphicElementInsert();
          entityInfo.GraphicElements.Add((IGraphicElement) graphicElement);
        }
        else
          flag = false;
      }
      else
      {
        graphicElement = new GraphicElementInsert();
        this.dictionary_0.Add(insert, new Graphics.EntityInfo()
        {
          GraphicElements = {
            (IGraphicElement) graphicElement
          }
        });
        flag = true;
      }
      graphicElementBlock.Add((IGraphicElement) graphicElement);
      return flag;
    }

    public bool GetGraphicElementBlock2(
      DxfBlock block,
      DxfLayer layer,
      EntityColor byBlockColor,
      DxfLineType byBlockLineType,
      out GraphicElementBlock2 graphicElementBlock)
    {
      Graphics.BlockInfo blockInfo;
      bool flag;
      if (this.dictionary_1.TryGetValue(block, out blockInfo))
      {
        graphicElementBlock = blockInfo.GetGraphicElementBlock(layer, byBlockColor, byBlockLineType);
        if (graphicElementBlock == null)
        {
          flag = true;
          graphicElementBlock = new GraphicElementBlock2(block.BaseTransformation, layer, byBlockColor, byBlockLineType);
          blockInfo.GraphicElementBlocks.Add(graphicElementBlock);
        }
        else
          flag = false;
      }
      else
      {
        graphicElementBlock = new GraphicElementBlock2(block.BaseTransformation, layer, byBlockColor, byBlockLineType);
        this.dictionary_1.Add(block, new Graphics.BlockInfo()
        {
          GraphicElementBlocks = {
            graphicElementBlock
          }
        });
        flag = true;
      }
      return flag;
    }

    public void RemoveGraphicElements(DxfEntity entity)
    {
      this.dictionary_0.Remove(entity);
    }

    public class EntityInfo
    {
      private List<IGraphicElement> list_0 = new List<IGraphicElement>();
      private Geometry geometry_0;

      public Geometry Geometry
      {
        get
        {
          return this.geometry_0;
        }
        set
        {
          this.geometry_0 = value;
        }
      }

      public List<IGraphicElement> GraphicElements
      {
        get
        {
          return this.list_0;
        }
        set
        {
          this.list_0 = value;
        }
      }

      public GraphicElement1 GetGraphicElement1(ArgbColor color)
      {
        foreach (IGraphicElement graphicElement in this.list_0)
        {
          GraphicElement1 graphicElement1 = graphicElement as GraphicElement1;
          if (graphicElement1 != null && graphicElement1.Matches(color))
            return graphicElement1;
        }
        return (GraphicElement1) null;
      }

      public GraphicElement2 GetGraphicElement2(
        ArgbColor color,
        DxfLineType lineType,
        double lineTypeScale,
        bool plinegen)
      {
        foreach (IGraphicElement graphicElement in this.list_0)
        {
          GraphicElement2 graphicElement2 = graphicElement as GraphicElement2;
          if (graphicElement2 != null && graphicElement2.Matches(color, lineType, lineTypeScale, plinegen))
            return graphicElement2;
        }
        return (GraphicElement2) null;
      }

      public GraphicElementInsert GetGraphicElementInsert(
        DxfLayer layer,
        EntityColor byBlockColor,
        DxfLineType byBlockLineType)
      {
        foreach (IGraphicElement graphicElement in this.list_0)
        {
          GraphicElementInsert graphicElementInsert = graphicElement as GraphicElementInsert;
          if (graphicElementInsert != null && graphicElementInsert.Matches(layer, byBlockColor, byBlockLineType))
            return graphicElementInsert;
        }
        return (GraphicElementInsert) null;
      }
    }

    public class BlockInfo
    {
      private List<GraphicElementBlock2> list_0 = new List<GraphicElementBlock2>();

      public List<GraphicElementBlock2> GraphicElementBlocks
      {
        get
        {
          return this.list_0;
        }
        set
        {
          this.list_0 = value;
        }
      }

      public GraphicElementBlock2 GetGraphicElementBlock(
        DxfLayer layer,
        EntityColor byBlockColor,
        DxfLineType byBlockLineType)
      {
        foreach (GraphicElementBlock2 graphicElementBlock2 in this.list_0)
        {
          if (graphicElementBlock2.Matches(layer, byBlockColor, byBlockLineType))
            return graphicElementBlock2;
        }
        return (GraphicElementBlock2) null;
      }
    }

    public class InsertInfo
    {
      private List<GraphicElementBlock1> list_0 = new List<GraphicElementBlock1>();

      public List<GraphicElementBlock1> GraphicElementBlocks
      {
        get
        {
          return this.list_0;
        }
        set
        {
          this.list_0 = value;
        }
      }

      public GraphicElementBlock1 GetGraphicElementBlock(
        Color byLayerColor,
        EntityColor byBlockColor)
      {
        foreach (GraphicElementBlock1 graphicElementBlock1 in this.list_0)
        {
          if (graphicElementBlock1.Matches(byLayerColor, byBlockColor))
            return graphicElementBlock1;
        }
        return (GraphicElementBlock1) null;
      }
    }
  }
}
