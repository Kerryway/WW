// Decompiled with JetBrains decompiler
// Type: ns3.Class8
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using System;
using WW.Cad.Drawing;
using WW.Cad.Model.Entities;

namespace ns3
{
  internal class Class8 : DxfPolylineBase
  {
    public bool Plinegen
    {
      get
      {
        return (this.Flags & Enum21.flag_8) != Enum21.flag_0;
      }
    }

    public bool ClosedInNDirection
    {
      get
      {
        return (this.Flags & Enum21.flag_6) != Enum21.flag_0;
      }
    }

    public bool Is3DPolyline
    {
      get
      {
        return (this.Flags & Enum21.flag_4) != Enum21.flag_0;
      }
    }

    public bool Is3DPolygonMesh
    {
      get
      {
        return (this.Flags & Enum21.flag_5) != Enum21.flag_0;
      }
    }

    public bool IsPolyfaceMesh
    {
      get
      {
        return (this.Flags & Enum21.flag_7) != Enum21.flag_0;
      }
    }

    public bool Is3D
    {
      get
      {
        return (this.Flags & (Enum21.flag_4 | Enum21.flag_5 | Enum21.flag_7)) != Enum21.flag_0;
      }
    }

    public bool IsSpline
    {
      get
      {
        return (this.Flags & Enum21.flag_3) != Enum21.flag_0;
      }
    }

    public override string EntityType
    {
      get
      {
        return "POLYLINE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDb3dPolyline";
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      throw new NotImplementedException();
    }

    public override void Accept(IEntityVisitor visitor)
    {
      throw new Exception("The method or operation is not implemented.");
    }
  }
}
