// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.ICadDrawer
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Math;

namespace WW.Cad.Drawing
{
  public interface ICadDrawer
  {
    void AddDrawables(DxfModel model, IList<DxfEntity> entities, Matrix4D modelTransform);

    void AddDrawables(
      DxfModel model,
      IList<DxfEntity> modelSpaceEntities,
      IList<DxfEntity> paperSpaceEntities,
      DxfLayout layout,
      ICollection<DxfViewport> viewports);

    void UpdateDrawables(DxfEntity entity);

    void EraseDrawables(DxfEntity entity);

    void RemoveDrawables(DxfEntity entity);
  }
}
