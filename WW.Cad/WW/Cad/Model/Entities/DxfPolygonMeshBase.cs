// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfPolygonMeshBase
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using ns28;
using System.Collections.Generic;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public abstract class DxfPolygonMeshBase : DxfPolylineBase
  {
    public bool ClosedInMDirection
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

    public bool ClosedInNDirection
    {
      get
      {
        return (this.Flags & Enum21.flag_6) != Enum21.flag_0;
      }
      set
      {
        if (value)
          this.Flags |= Enum21.flag_6;
        else
          this.Flags &= ~Enum21.flag_6;
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
        return "AcDbPolygonMesh";
      }
    }

    protected new Matrix4D Transform
    {
      get
      {
        return Matrix4D.Identity;
      }
    }

    protected void GetSurface(
      IList<Polyline3D> polylines,
      DxfVertex3D[,] surfaceVertices,
      int mLength,
      int nLength)
    {
      if (mLength == 0 || nLength == 0)
        return;
      bool closedInNdirection = this.ClosedInNDirection;
      for (short index1 = 0; (int) index1 < mLength; ++index1)
      {
        Polyline3D polyline3D = new Polyline3D();
        polyline3D.Closed = closedInNdirection;
        polylines.Add(polyline3D);
        for (short index2 = 0; (int) index2 < nLength; ++index2)
          polyline3D.Add(surfaceVertices[(int) index1, (int) index2].Position);
      }
      bool closedInMdirection = this.ClosedInMDirection;
      for (short index1 = 0; (int) index1 < nLength; ++index1)
      {
        Polyline3D polyline3D = new Polyline3D(closedInMdirection);
        polylines.Add(polyline3D);
        for (short index2 = 0; (int) index2 < mLength; ++index2)
          polyline3D.Add(surfaceVertices[(int) index2, (int) index1].Position);
      }
    }

    protected void GetSurface(
      IList<Polyline3D> polylines,
      IList<DxfVertex3D> surfaceVertices,
      int mLength,
      int nLength)
    {
      if (mLength == 0 || nLength == 0)
        return;
      bool closedInNdirection = this.ClosedInNDirection;
      int index1 = 0;
      for (short index2 = 0; (int) index2 < mLength; ++index2)
      {
        Polyline3D polyline3D = new Polyline3D();
        polyline3D.Closed = closedInNdirection;
        polylines.Add(polyline3D);
        short num = 0;
        while ((int) num < nLength)
        {
          polyline3D.Add(surfaceVertices[index1].Position);
          ++num;
          ++index1;
        }
      }
      bool closedInMdirection = this.ClosedInMDirection;
      for (short index2 = 0; (int) index2 < nLength; ++index2)
      {
        int index3 = (int) index2;
        Polyline3D polyline3D = new Polyline3D(closedInMdirection);
        polylines.Add(polyline3D);
        short num = 0;
        while ((int) num < mLength)
        {
          polyline3D.Add(surfaceVertices[index3].Position);
          ++num;
          index3 += nLength;
        }
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return 30;
    }

    internal override short vmethod_14(Class432 ow)
    {
      return 12;
    }
  }
}
