// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.BasicEntityVisitor
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model.InventorDrawing;

namespace WW.Cad.Model.Entities
{
  public abstract class BasicEntityVisitor : IEntityVisitor
  {
    public static void Visit(DxfModel model, IEntityVisitor visitor)
    {
      BasicEntityVisitor.Visit((IEnumerable<DxfEntity>) model.Entities, visitor);
    }

    public static void Visit(IEnumerable<DxfEntity> entities, IEntityVisitor visitor)
    {
      foreach (DxfEntity entity in entities)
        entity.Accept(visitor);
    }

    public virtual void Visit(Dxf3DFace face)
    {
    }

    public virtual void Visit(Dxf3DSolid solid)
    {
    }

    public virtual void Visit(DxfArc arc)
    {
    }

    public virtual void Visit(DxfAttribute attribute)
    {
    }

    public virtual void Visit(DxfAttributeDefinition attributeDefinition)
    {
    }

    public virtual void Visit(DxfCircle circle)
    {
    }

    public virtual void Visit(DxfDimension.Aligned dimension)
    {
    }

    public virtual void Visit(DxfDimension.Angular3Point dimension)
    {
    }

    public virtual void Visit(DxfDimension.Angular4Point dimension)
    {
    }

    public virtual void Visit(DxfDimension.Diametric dimension)
    {
    }

    public virtual void Visit(DxfDimension.Linear dimension)
    {
    }

    public virtual void Visit(DxfDimension.Ordinate dimension)
    {
    }

    public virtual void Visit(DxfDimension.Radial dimension)
    {
    }

    public virtual void Visit(DxfEllipse ellipse)
    {
    }

    public virtual void Visit(DxfHatch hatch)
    {
    }

    public virtual void Visit(DxfImage image)
    {
    }

    public virtual void Visit(DxfWipeout image)
    {
    }

    public virtual void Visit(DxfInsert insert)
    {
    }

    public virtual void Visit(DxfIDBlockReference insert)
    {
    }

    public virtual void Visit(DxfLeader leader)
    {
    }

    public virtual void Visit(DxfLine line)
    {
    }

    public virtual void Visit(DxfLwPolyline polyline)
    {
    }

    public virtual void Visit(DxfMeshFace meshFace)
    {
    }

    public void Visit(DxfMLeader mleader)
    {
    }

    public virtual void Visit(DxfMLine mline)
    {
    }

    public virtual void Visit(DxfMText mtext)
    {
    }

    public virtual void Visit(DxfPoint point)
    {
    }

    public virtual void Visit(DxfPolyfaceMesh mesh)
    {
    }

    public virtual void Visit(DxfPolygonMesh mesh)
    {
    }

    public virtual void Visit(DxfPolygonSplineMesh mesh)
    {
    }

    public virtual void Visit(DxfPolyline2D polyline)
    {
    }

    public virtual void Visit(DxfPolyline2DSpline polyline)
    {
    }

    public virtual void Visit(DxfPolyline3D polyline)
    {
    }

    public virtual void Visit(DxfPolyline3DSpline polyline)
    {
    }

    public void Visit(DxfProxyEntity proxyEntity)
    {
    }

    public virtual void Visit(DxfRay ray)
    {
    }

    public virtual void Visit(DxfRegion region)
    {
    }

    public virtual void Visit(DxfBody body)
    {
    }

    public virtual void Visit(DxfSequenceEnd sequenceEnd)
    {
    }

    public virtual void Visit(DxfShape shape)
    {
    }

    public virtual void Visit(DxfSolid solid)
    {
    }

    public virtual void Visit(DxfSpline spline)
    {
    }

    public virtual void Visit(DxfTable table)
    {
    }

    public virtual void Visit(DxfText text)
    {
    }

    public virtual void Visit(DxfTolerance tolerance)
    {
    }

    public virtual void Visit(DxfVertex2D vertex)
    {
    }

    public virtual void Visit(DxfVertex3D vertex)
    {
    }

    public virtual void Visit(DxfViewport viewport)
    {
    }

    public virtual void Visit(DxfXLine xline)
    {
    }

    public virtual void Visit(DxfOle ole)
    {
    }
  }
}
