// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfPolyline3DBase
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using ns28;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public abstract class DxfPolyline3DBase : DxfPolylineBase, IClipBoundaryProvider
  {
    public bool Closed
    {
      get
      {
        return (this.Flags & Enum21.flag_1) != Enum21.flag_0;
      }
      set
      {
        if (value)
          this.Flags |= Enum21.flag_1;
        else
          this.Flags &= ~Enum21.flag_1;
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDb3dPolyline";
      }
    }

    public override Matrix4D Transform
    {
      get
      {
        return Matrix4D.Identity;
      }
    }

    public override void TransformMe(TransformConfig config, Matrix4D matrix)
    {
      this.TransformMe(config, matrix, (CommandGroup) null);
    }

    internal override short vmethod_6(Class432 w)
    {
      return 16;
    }

    internal override short vmethod_14(Class432 ow)
    {
      return 11;
    }

    public abstract IList<Polygon2D> GetClipBoundary(GraphicsConfig graphicsConfig);
  }
}
