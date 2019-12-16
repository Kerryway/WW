// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.ILeader
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Drawing;
using WW.Cad.Model.Tables;
using WW.Math;

namespace WW.Cad.Model.Entities
{
  internal interface ILeader
  {
    bool IsSpline { get; }

    Vector3D Direction { get; }

    bool ArrowHeadEnabled { get; }

    double ArrowSize { get; }

    double GetEffectiveArrowSize();

    DxfBlock LeaderArrowBlock { get; }

    bool HasHookLine { get; }

    HookLineDirection HookLineDirection { get; }

    void imethod_0(DrawContext context, IList<WW.Math.Point3D> points, IList<WW.Math.Point3D> flattenedPolyline);
  }
}
