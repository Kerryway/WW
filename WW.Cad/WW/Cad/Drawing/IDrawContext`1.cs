// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.IDrawContext`1
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;
using WW.Math;

namespace WW.Cad.Drawing
{
  public interface IDrawContext<TConcreteClass>
  {
    TConcreteClass CreateChildContext(DxfEntity blockContext, Matrix4D preTransform);

    TConcreteClass CreateChildContext(
      DxfEntity blockContext,
      Matrix4D preTransform,
      DxfBlock externalBlock,
      DxfModel externalModel);

    DxfModel Model { get; }

    DxfLayout Layout { get; }

    DxfEntity BlockContext { get; }

    DxfBlock ExternalBlock { get; set; }

    DxfLayer Layer { get; }
  }
}
