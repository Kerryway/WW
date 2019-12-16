// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.GraphicElementInsert
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class GraphicElementInsert : IGraphicElement
  {
    private GraphicElementBlock2 graphicElementBlock2_0;
    private GraphicElementBlock1 graphicElementBlock1_0;
    private GraphicElementInsert.InsertCell[,] insertCell_0;
    private Matrix4D[,] matrix4D_0;

    public GraphicElementBlock2 UnclippedBlock
    {
      get
      {
        return this.graphicElementBlock2_0;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        this.graphicElementBlock2_0 = value;
      }
    }

    public GraphicElementBlock1 AttributeBlock
    {
      get
      {
        return this.graphicElementBlock1_0;
      }
      set
      {
        this.graphicElementBlock1_0 = value;
      }
    }

    public GraphicElementInsert.InsertCell[,] InsertCells
    {
      get
      {
        return this.insertCell_0;
      }
      set
      {
        this.insertCell_0 = value;
      }
    }

    public Matrix4D[,] AttributeBlockCells
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

    public bool Matches(DxfLayer layer, EntityColor byBlockColor, DxfLineType byBlockLineType)
    {
      if (this.graphicElementBlock2_0 == null)
        return false;
      return this.graphicElementBlock2_0.Matches(layer, byBlockColor, byBlockLineType);
    }

    public void Accept(IGraphicElementVisitor visitor)
    {
      visitor.Visit(this);
    }

    public class InsertCell
    {
      private GraphicElementBlock2 graphicElementBlock2_0;
      private Matrix4D matrix4D_0;

      public InsertCell()
      {
      }

      public InsertCell(Matrix4D transform)
      {
        this.matrix4D_0 = transform;
      }

      public GraphicElementBlock2 ClippedBlock
      {
        get
        {
          return this.graphicElementBlock2_0;
        }
        set
        {
          this.graphicElementBlock2_0 = value;
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

    internal class Class1001
    {
      private DxfEntity dxfEntity_0;
      private Color color_0;
      private DxfLineType dxfLineType_0;
      private EntityColor entityColor_0;
      private DxfLineType dxfLineType_1;

      public Class1001(
        DxfEntity entity,
        Color byLayerColor,
        DxfLineType byLayerLineType,
        EntityColor byBlockColor,
        DxfLineType byBlockLineType)
      {
        this.dxfEntity_0 = entity;
        this.color_0 = byLayerColor;
        this.dxfLineType_0 = byLayerLineType;
        this.entityColor_0 = byBlockColor;
        this.dxfLineType_1 = byBlockLineType;
      }

      public Color ByLayerColor
      {
        get
        {
          return this.color_0;
        }
      }

      public DxfLineType ByLayerLineType
      {
        get
        {
          return this.dxfLineType_0;
        }
      }

      public EntityColor ByBlockColor
      {
        get
        {
          return this.entityColor_0;
        }
      }

      public DxfLineType ByBlockLineType
      {
        get
        {
          return this.dxfLineType_1;
        }
      }

      public override int GetHashCode()
      {
        return this.dxfEntity_0.GetHashCode() ^ this.color_0.GetHashCode() ^ this.dxfLineType_0.GetHashCode() ^ this.entityColor_0.GetHashCode() ^ this.dxfLineType_1.GetHashCode();
      }

      public override bool Equals(object obj)
      {
        GraphicElementInsert.Class1001 class1001 = obj as GraphicElementInsert.Class1001;
        if (class1001 == null || this.dxfEntity_0 != class1001.dxfEntity_0 || (!(this.color_0 == class1001.color_0) || this.dxfLineType_0 != class1001.dxfLineType_0) || !(this.entityColor_0 == class1001.entityColor_0))
          return false;
        return this.dxfLineType_1 == class1001.ByBlockLineType;
      }
    }
  }
}
