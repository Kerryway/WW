// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.IEntityVisitor
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model.InventorDrawing;

namespace WW.Cad.Model.Entities
{
  public interface IEntityVisitor
  {
    void Visit(Dxf3DFace face);

    void Visit(Dxf3DSolid solid);

    void Visit(DxfArc arc);

    void Visit(DxfAttribute attribute);

    void Visit(DxfAttributeDefinition attributeDefinition);

    void Visit(DxfCircle circle);

    void Visit(DxfDimension.Aligned dimension);

    void Visit(DxfDimension.Angular3Point dimension);

    void Visit(DxfDimension.Angular4Point dimension);

    void Visit(DxfDimension.Diametric dimension);

    void Visit(DxfDimension.Linear dimension);

    void Visit(DxfDimension.Ordinate dimension);

    void Visit(DxfDimension.Radial dimension);

    void Visit(DxfEllipse ellipse);

    void Visit(DxfHatch hatch);

    void Visit(DxfImage image);

    void Visit(DxfProxyEntity proxyEntity);

    void Visit(DxfWipeout image);

    void Visit(DxfInsert insert);

    void Visit(DxfIDBlockReference insert);

    void Visit(DxfLeader leader);

    void Visit(DxfLine line);

    void Visit(DxfLwPolyline polyline);

    void Visit(DxfMeshFace meshFace);

    void Visit(DxfMLeader mleader);

    void Visit(DxfMLine mline);

    void Visit(DxfMText mtext);

    void Visit(DxfPoint point);

    void Visit(DxfPolyfaceMesh mesh);

    void Visit(DxfPolygonMesh mesh);

    void Visit(DxfPolygonSplineMesh mesh);

    void Visit(DxfPolyline2D polyline);

    void Visit(DxfPolyline2DSpline polyline);

    void Visit(DxfPolyline3D polyline);

    void Visit(DxfPolyline3DSpline polyline);

    void Visit(DxfRay ray);

    void Visit(DxfShape shape);

    void Visit(DxfRegion region);

    void Visit(DxfBody body);

    void Visit(DxfSequenceEnd sequenceEnd);

    void Visit(DxfSolid solid);

    void Visit(DxfSpline spline);

    void Visit(DxfTable table);

    void Visit(DxfText text);

    void Visit(DxfTolerance tolerance);

    void Visit(DxfVertex2D vertex);

    void Visit(DxfVertex3D vertex);

    void Visit(DxfViewport viewport);

    void Visit(DxfXLine xline);

    void Visit(DxfOle ole);
  }
}
