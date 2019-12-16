// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.IViewDescription
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Math;

namespace WW.Cad.Model
{
  public interface IViewDescription
  {
    ViewportStatusFlags ViewModeFlags { get; }

    WW.Math.Point3D ViewportCenter { get; }

    double ViewportWidth { get; }

    double ViewportHeight { get; }

    WW.Math.Point2D ViewCenter { get; }

    Vector3D ViewDirection { get; }

    WW.Math.Point3D ViewTarget { get; }

    double FocalLength { get; }

    double FrontClipDistance { get; }

    double BackClipDistance { get; }

    double ViewWidth { get; }

    double ViewHeight { get; }

    double ViewTwistAngle { get; }

    DxfEntity ClippingBoundaryEntity { get; }

    RenderMode RenderMode { get; }

    bool IsTargetPaper { get; }

    IList<DxfLayer> FrozenLayers { get; }
  }
}
