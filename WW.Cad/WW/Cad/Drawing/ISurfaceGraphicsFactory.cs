// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.ISurfaceGraphicsFactory
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model.Entities;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public interface ISurfaceGraphicsFactory
  {
    void BeginNode(DxfEntity entity, DrawContext.Surface drawContext);

    void EndNode();

    void SetColor(ArgbColor color);

    void CreatePoint(Vector4D point);

    void CreateSegment(Vector4D start, Vector4D end);

    void CreatePolyline(IList<Vector4D> polyline, bool closed);

    void CreateTriangle(Vector4D v0, Vector4D v1, Vector4D v2, IList<bool> edgeVisible);

    void CreateQuad(IList<Vector4D> polygon, IList<bool> edgeVisible);

    void CreateQuadStrip(
      IList<Vector4D> polyline1,
      IList<Vector4D> polyline2,
      Vector3D normal,
      bool close);

    void CreateQuadStrip(
      IList<Vector4D> polyline1,
      IList<Vector4D> polyline2,
      IList<Vector3D> normals,
      int startVertexIndex,
      int endVertexIndex);

    void CreatePolygonMesh(
      Vector4D[,] polygonMesh,
      bool closedInMDirection,
      bool closedInNDirection);

    void CreateTexturedTriangles(
      byte[] rgbaBytes,
      int width,
      int height,
      Vector3D normal,
      IList<Triangulator2D.Triangle> triangles,
      IList<Point2D> textureCoordinates,
      IList<Vector4D> points);
  }
}
