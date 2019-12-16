// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.IPrimitiveVisitor
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Drawing.Surface
{
  public interface IPrimitiveVisitor
  {
    void Visit(Point visitee);

    void Visit(PolygonMesh visitee);

    void Visit(Polyline2DE visitee);

    void Visit(Polyline2D2N visitee);

    void Visit(Polyline2D2WN visitee);

    void Visit(Polyline3D visitee);

    void Visit(Quad visitee);

    void Visit(QuadStrip1 visitee);

    void Visit(QuadStrip2 visitee);

    void Visit(QuadWithEdges visitee);

    void Visit(Segment visitee);

    void Visit(TexturedTriangleList visitee);

    void Visit(Triangle visitee);

    void Visit(TriangleWithEdges visitee);
  }
}
