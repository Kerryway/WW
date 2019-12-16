// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.RenderedEntityInfo
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Math;

namespace WW.Cad.Drawing
{
  public class RenderedEntityInfo
  {
    private readonly DxfEntity dxfEntity_0;
    private readonly Matrix4D matrix4D_0;
    private RenderedEntityInfo renderedEntityInfo_0;

    public RenderedEntityInfo(DxfEntity entity, Matrix4D transform)
    {
      this.dxfEntity_0 = entity;
      this.matrix4D_0 = transform;
    }

    public RenderedEntityInfo(DxfEntity entity, Matrix4D transform, RenderedEntityInfo parent)
    {
      this.dxfEntity_0 = entity;
      this.matrix4D_0 = transform;
      this.renderedEntityInfo_0 = parent;
    }

    public DxfEntity Entity
    {
      get
      {
        return this.dxfEntity_0;
      }
    }

    public DxfEntity ParentEntity
    {
      get
      {
        if (this.renderedEntityInfo_0 != null)
          return this.renderedEntityInfo_0.dxfEntity_0;
        return (DxfEntity) null;
      }
    }

    public Matrix4D Transform
    {
      get
      {
        return this.matrix4D_0;
      }
    }

    public Matrix4D CompleteTransform
    {
      get
      {
        if (this.renderedEntityInfo_0 != null)
          return this.renderedEntityInfo_0.Transform * this.matrix4D_0;
        return this.matrix4D_0;
      }
    }

    public RenderedEntityInfo Parent
    {
      get
      {
        return this.renderedEntityInfo_0;
      }
    }

    public RenderedEntityInfo GetRoot()
    {
      RenderedEntityInfo renderedEntityInfo = this;
      while (renderedEntityInfo.renderedEntityInfo_0 != null)
        renderedEntityInfo = renderedEntityInfo.renderedEntityInfo_0;
      return renderedEntityInfo;
    }

    public ICollection<RenderedEntityInfo> GetParents()
    {
      LinkedList<RenderedEntityInfo> linkedList = new LinkedList<RenderedEntityInfo>();
      for (RenderedEntityInfo renderedEntityInfo = this.renderedEntityInfo_0; renderedEntityInfo != null; renderedEntityInfo = renderedEntityInfo.Parent)
        linkedList.AddFirst(renderedEntityInfo);
      return (ICollection<RenderedEntityInfo>) linkedList;
    }

    public bool ThisOrParentsContainEntity(DxfEntity entity)
    {
      if (this.dxfEntity_0 == entity)
        return true;
      for (RenderedEntityInfo renderedEntityInfo0 = this.renderedEntityInfo_0; renderedEntityInfo0 != null; renderedEntityInfo0 = renderedEntityInfo0.renderedEntityInfo_0)
      {
        if (renderedEntityInfo0.dxfEntity_0 == entity)
          return true;
      }
      return false;
    }

    public DxfLayer GetEffectiveLayer(DxfLayer insertLayer)
    {
      if (this.dxfEntity_0.Layer.IsZeroLayer)
        return this.dxfEntity_0.Layer.GetEffectiveLayer(this.renderedEntityInfo_0 != null ? this.renderedEntityInfo_0.GetEffectiveLayer(insertLayer) : insertLayer);
      return this.dxfEntity_0.Layer;
    }

    internal void SetParent(RenderedEntityInfo parent)
    {
      this.renderedEntityInfo_0 = parent;
    }

    internal bool method_0(RenderedEntityInfo other)
    {
      if (this.dxfEntity_0 != other.dxfEntity_0)
        return false;
      RenderedEntityInfo renderedEntityInfo0_1 = this.renderedEntityInfo_0;
      for (RenderedEntityInfo renderedEntityInfo0_2 = other.renderedEntityInfo_0; renderedEntityInfo0_1 != null || renderedEntityInfo0_2 != null; renderedEntityInfo0_2 = renderedEntityInfo0_2.renderedEntityInfo_0)
      {
        if (renderedEntityInfo0_1 == null || renderedEntityInfo0_2 == null || renderedEntityInfo0_1.dxfEntity_0 != renderedEntityInfo0_2.dxfEntity_0)
          return false;
        renderedEntityInfo0_1 = renderedEntityInfo0_1.renderedEntityInfo_0;
      }
      return true;
    }

    public static bool IsMatch(RenderedEntityInfo renderedEntityInfo, DrawContext drawContext)
    {
      bool flag = true;
      RenderedEntityInfo renderedEntityInfo1;
      for (renderedEntityInfo1 = renderedEntityInfo; drawContext != null && renderedEntityInfo1 != null; renderedEntityInfo1 = renderedEntityInfo1.Parent)
      {
        if (drawContext.BlockContext == renderedEntityInfo1.ParentEntity)
        {
          DrawContext drawContext1 = drawContext;
          drawContext = drawContext.ParentContext;
          if (drawContext != null && drawContext.BlockContext != null && drawContext.BlockContext == drawContext1.BlockContext)
            drawContext = drawContext.ParentContext;
        }
        else
        {
          flag = false;
          break;
        }
      }
      if (renderedEntityInfo1 != null || drawContext != null)
        flag = false;
      return flag;
    }
  }
}
