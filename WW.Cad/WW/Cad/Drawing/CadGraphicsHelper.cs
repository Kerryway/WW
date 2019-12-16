// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.CadGraphicsHelper
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model.Entities;

namespace WW.Cad.Drawing
{
  public static class CadGraphicsHelper
  {
    public static object NullObjectTagger(DxfEntity entity, DrawContext context)
    {
      return (object) null;
    }

    public static object EntityObjectTagger(DxfEntity entity, DrawContext context)
    {
      return (object) entity;
    }

    public static object LayerObjectTagger(DxfEntity entity, DrawContext context)
    {
      return (object) context.GetEffectiveLayer(entity.Layer);
    }

    public delegate object ObjectTaggerDelegate(DxfEntity entity, DrawContext context);
  }
}
