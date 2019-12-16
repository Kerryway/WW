// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.ConsolidatingEntityVisitor
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model.InventorDrawing;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model.Entities
{
  public abstract class ConsolidatingEntityVisitor : IEntityVisitor
  {
    protected abstract void VisitEntity(DxfEntity entity);

    protected virtual void VisitDimension(DxfDimension dimension)
    {
      this.VisitInsertingEntity((DxfEntity) dimension, dimension.Block);
    }

    protected virtual void VisitModelerGeometry(DxfModelerGeometry geometry)
    {
      this.VisitEntity((DxfEntity) geometry);
    }

    protected virtual void VisitInsertBase(DxfInsertBase insert)
    {
      this.VisitInsertingEntity((DxfEntity) insert, insert.Block);
      foreach (DxfEntity attribute in (IEnumerable<DxfAttribute>) insert.Attributes)
        attribute.Accept((IEntityVisitor) this);
    }

    protected virtual void VisitInsertingEntity(DxfEntity entity, DxfBlock insertedBlock)
    {
      this.VisitEntity(entity);
    }

    protected virtual void VisitVertex(DxfVertex vertex)
    {
    }

    public virtual void VisitEntities(IEnumerable<DxfEntity> entities)
    {
      foreach (DxfEntity entity in entities)
        entity.Accept((IEntityVisitor) this);
    }

    public virtual void Visit(Dxf3DFace face)
    {
      this.VisitEntity((DxfEntity) face);
    }

    public virtual void Visit(Dxf3DSolid solid)
    {
      this.VisitModelerGeometry((DxfModelerGeometry) solid);
    }

    public virtual void Visit(DxfArc arc)
    {
      this.VisitEntity((DxfEntity) arc);
    }

    public virtual void Visit(DxfAttribute attribute)
    {
      this.VisitEntity((DxfEntity) attribute);
    }

    public virtual void Visit(DxfAttributeDefinition attributeDefinition)
    {
      this.VisitEntity((DxfEntity) attributeDefinition);
    }

    public virtual void Visit(DxfCircle circle)
    {
      this.VisitEntity((DxfEntity) circle);
    }

    public virtual void Visit(DxfDimension.Aligned dimension)
    {
      this.VisitDimension((DxfDimension) dimension);
    }

    public virtual void Visit(DxfDimension.Angular3Point dimension)
    {
      this.VisitDimension((DxfDimension) dimension);
    }

    public virtual void Visit(DxfDimension.Angular4Point dimension)
    {
      this.VisitDimension((DxfDimension) dimension);
    }

    public virtual void Visit(DxfDimension.Diametric dimension)
    {
      this.VisitDimension((DxfDimension) dimension);
    }

    public virtual void Visit(DxfDimension.Linear dimension)
    {
      this.VisitDimension((DxfDimension) dimension);
    }

    public virtual void Visit(DxfDimension.Ordinate dimension)
    {
      this.VisitDimension((DxfDimension) dimension);
    }

    public virtual void Visit(DxfDimension.Radial dimension)
    {
      this.VisitDimension((DxfDimension) dimension);
    }

    public virtual void Visit(DxfEllipse ellipse)
    {
      this.VisitEntity((DxfEntity) ellipse);
    }

    public virtual void Visit(DxfHatch hatch)
    {
      this.VisitEntity((DxfEntity) hatch);
    }

    public virtual void Visit(DxfImage image)
    {
      this.VisitEntity((DxfEntity) image);
    }

    public virtual void Visit(DxfProxyEntity proxyEntity)
    {
      this.VisitEntity((DxfEntity) proxyEntity);
    }

    public virtual void Visit(DxfWipeout image)
    {
      this.VisitEntity((DxfEntity) image);
    }

    public virtual void Visit(DxfInsert insert)
    {
      this.VisitInsertBase((DxfInsertBase) insert);
    }

    public virtual void Visit(DxfIDBlockReference insert)
    {
      this.VisitInsertBase((DxfInsertBase) insert);
    }

    public virtual void Visit(DxfLeader leader)
    {
      this.VisitEntity((DxfEntity) leader);
    }

    public virtual void Visit(DxfLine line)
    {
      this.VisitEntity((DxfEntity) line);
    }

    public virtual void Visit(DxfLwPolyline polyline)
    {
      this.VisitEntity((DxfEntity) polyline);
    }

    public virtual void Visit(DxfMeshFace meshFace)
    {
      this.VisitEntity((DxfEntity) meshFace);
    }

    public virtual void Visit(DxfMLeader mleader)
    {
      this.VisitEntity((DxfEntity) mleader);
    }

    public virtual void Visit(DxfMLine mline)
    {
      this.VisitEntity((DxfEntity) mline);
    }

    public virtual void Visit(DxfMText mtext)
    {
      this.VisitEntity((DxfEntity) mtext);
    }

    public virtual void Visit(DxfPoint point)
    {
      this.VisitEntity((DxfEntity) point);
    }

    public virtual void Visit(DxfPolyfaceMesh mesh)
    {
      this.VisitEntity((DxfEntity) mesh);
    }

    public virtual void Visit(DxfPolygonMesh mesh)
    {
      this.VisitEntity((DxfEntity) mesh);
    }

    public virtual void Visit(DxfPolygonSplineMesh mesh)
    {
      this.VisitEntity((DxfEntity) mesh);
    }

    public virtual void Visit(DxfPolyline2D polyline)
    {
      this.VisitEntity((DxfEntity) polyline);
    }

    public virtual void Visit(DxfPolyline2DSpline polyline)
    {
      this.VisitEntity((DxfEntity) polyline);
    }

    public virtual void Visit(DxfPolyline3D polyline)
    {
      this.VisitEntity((DxfEntity) polyline);
    }

    public virtual void Visit(DxfPolyline3DSpline polyline)
    {
      this.VisitEntity((DxfEntity) polyline);
    }

    public virtual void Visit(DxfRay ray)
    {
      this.VisitEntity((DxfEntity) ray);
    }

    public virtual void Visit(DxfShape shape)
    {
      this.VisitEntity((DxfEntity) shape);
    }

    public virtual void Visit(DxfRegion region)
    {
      this.VisitModelerGeometry((DxfModelerGeometry) region);
    }

    public virtual void Visit(DxfBody body)
    {
      this.VisitModelerGeometry((DxfModelerGeometry) body);
    }

    public virtual void Visit(DxfSequenceEnd sequenceEnd)
    {
    }

    public virtual void Visit(DxfSolid solid)
    {
      this.VisitEntity((DxfEntity) solid);
    }

    public virtual void Visit(DxfSpline spline)
    {
      this.VisitEntity((DxfEntity) spline);
    }

    public virtual void Visit(DxfTable table)
    {
      this.VisitInsertingEntity((DxfEntity) table, table.Block);
    }

    public virtual void Visit(DxfText text)
    {
      this.VisitEntity((DxfEntity) text);
    }

    public virtual void Visit(DxfTolerance tolerance)
    {
      this.VisitEntity((DxfEntity) tolerance);
    }

    public virtual void Visit(DxfVertex2D vertex)
    {
      this.VisitVertex((DxfVertex) vertex);
    }

    public virtual void Visit(DxfVertex3D vertex)
    {
      this.VisitVertex((DxfVertex) vertex);
    }

    public virtual void Visit(DxfViewport viewport)
    {
      this.VisitEntity((DxfEntity) viewport);
    }

    public virtual void Visit(DxfXLine xline)
    {
      this.VisitEntity((DxfEntity) xline);
    }

    public virtual void Visit(DxfOle ole)
    {
      this.VisitEntity((DxfEntity) ole);
    }
  }
}
