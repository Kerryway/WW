// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfVertex
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System;
using WW.Cad.Drawing;

namespace WW.Cad.Model.Entities
{
  public abstract class DxfVertex : DxfEntity
  {
    public override string EntityType
    {
      get
      {
        return "VERTEX";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbVertex";
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      throw new Exception("Vertex is never drawn independently.");
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      throw new Exception("Vertex is never drawn independently.");
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      if (this.OwnerObjectSoftReference == null)
        return;
      DxfEntity objectSoftReference = (DxfEntity) this.OwnerObjectSoftReference;
      if (this.Color != objectSoftReference.Color)
        this.Color = objectSoftReference.Color;
      if (this.DxfColor != objectSoftReference.DxfColor)
        this.DxfColor = objectSoftReference.DxfColor;
      if (this.Layer == objectSoftReference.Layer)
        return;
      this.Layer = objectSoftReference.Layer;
    }
  }
}
