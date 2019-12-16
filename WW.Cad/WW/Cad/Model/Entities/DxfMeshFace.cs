// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfMeshFace
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Drawing;

namespace WW.Cad.Model.Entities
{
  public class DxfMeshFace : DxfEntity
  {
    private List<DxfMeshFace.Corner> list_0 = new List<DxfMeshFace.Corner>();

    public DxfMeshFace()
    {
    }

    public DxfMeshFace(params DxfMeshFace.Corner[] corners)
    {
      if (corners == null)
        throw new ArgumentException("corners may not be null.");
      if (corners.Length == 0)
        throw new ArgumentException("corners must contain more than 0 vertices.");
      if (corners.Length > 4)
        throw new ArgumentException("corners may not contain more than 4 vertices.");
      this.list_0.AddRange((IEnumerable<DxfMeshFace.Corner>) corners);
    }

    public DxfMeshFace(EntityColor color, params DxfMeshFace.Corner[] corners)
    {
      if (corners == null)
        throw new ArgumentException("corners may not be null.");
      if (corners.Length == 0)
        throw new ArgumentException("corners must contain more than 0 vertices.");
      if (corners.Length > 4)
        throw new ArgumentException("corners may not contain more than 4 vertices.");
      this.Color = color;
      this.list_0.AddRange((IEnumerable<DxfMeshFace.Corner>) corners);
    }

    public DxfMeshFace(params DxfVertex3D[] cornerVertices)
    {
      if (cornerVertices == null)
        throw new ArgumentException("cornerVertices may not be null.");
      if (cornerVertices.Length == 0)
        throw new ArgumentException("cornerVertices must contain more than 0 vertices.");
      if (cornerVertices.Length > 4)
        throw new ArgumentException("cornerVertices may not contain more than 4 vertices.");
      for (int index = 0; index < cornerVertices.Length; ++index)
        this.list_0.Add(new DxfMeshFace.Corner(cornerVertices[index]));
    }

    public DxfMeshFace(EntityColor color, params DxfVertex3D[] cornerVertices)
    {
      if (cornerVertices == null)
        throw new ArgumentException("cornerVertices may not be null.");
      if (cornerVertices.Length == 0)
        throw new ArgumentException("cornerVertices must contain more than 0 vertices.");
      if (cornerVertices.Length > 4)
        throw new ArgumentException("cornerVertices may not contain more than 4 vertices.");
      this.Color = color;
      for (int index = 0; index < cornerVertices.Length; ++index)
        this.list_0.Add(new DxfMeshFace.Corner(cornerVertices[index]));
    }

    public DxfMeshFace(DxfVertex3D v)
    {
      this.list_0.Add(new DxfMeshFace.Corner(v));
    }

    public DxfMeshFace(EntityColor color, DxfVertex3D v)
    {
      this.Color = color;
      this.list_0.Add(new DxfMeshFace.Corner(v));
    }

    public DxfMeshFace(DxfVertex3D v1, DxfVertex3D v2)
    {
      this.list_0.Add(new DxfMeshFace.Corner(v1));
      this.list_0.Add(new DxfMeshFace.Corner(v2));
    }

    public DxfMeshFace(EntityColor color, DxfVertex3D v1, DxfVertex3D v2)
    {
      this.Color = color;
      this.list_0.Add(new DxfMeshFace.Corner(v1));
      this.list_0.Add(new DxfMeshFace.Corner(v2));
    }

    public DxfMeshFace(DxfVertex3D v1, DxfVertex3D v2, DxfVertex3D v3)
    {
      this.list_0.Add(new DxfMeshFace.Corner(v1));
      this.list_0.Add(new DxfMeshFace.Corner(v2));
      this.list_0.Add(new DxfMeshFace.Corner(v3));
    }

    public DxfMeshFace(EntityColor color, DxfVertex3D v1, DxfVertex3D v2, DxfVertex3D v3)
    {
      this.Color = color;
      this.list_0.Add(new DxfMeshFace.Corner(v1));
      this.list_0.Add(new DxfMeshFace.Corner(v2));
      this.list_0.Add(new DxfMeshFace.Corner(v3));
    }

    public DxfMeshFace(DxfVertex3D v1, DxfVertex3D v2, DxfVertex3D v3, DxfVertex3D v4)
    {
      this.list_0.Add(new DxfMeshFace.Corner(v1));
      this.list_0.Add(new DxfMeshFace.Corner(v2));
      this.list_0.Add(new DxfMeshFace.Corner(v3));
      this.list_0.Add(new DxfMeshFace.Corner(v4));
    }

    public DxfMeshFace(
      EntityColor color,
      DxfVertex3D v1,
      DxfVertex3D v2,
      DxfVertex3D v3,
      DxfVertex3D v4)
    {
      this.Color = color;
      this.list_0.Add(new DxfMeshFace.Corner(v1));
      this.list_0.Add(new DxfMeshFace.Corner(v2));
      this.list_0.Add(new DxfMeshFace.Corner(v3));
      this.list_0.Add(new DxfMeshFace.Corner(v4));
    }

    public List<DxfMeshFace.Corner> Corners
    {
      get
      {
        return this.list_0;
      }
    }

    public override string EntityType
    {
      get
      {
        return "VERTEX";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbFaceRecord";
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      throw new Exception("MeshFace is never drawn independently.");
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      throw new Exception("MeshFace is never drawn independently.");
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      throw new DxfException("DxfMeshFace.Clone not implemented. Clone DxfPologyonMesh instead.");
    }

    internal DxfMeshFace Clone(
      CloneContext cloneContext,
      DxfPolyfaceMesh fromMesh,
      Dictionary<DxfVertex3D, int> fromVertexToIndex)
    {
      DxfMeshFace dxfMeshFace = new DxfMeshFace();
      dxfMeshFace.CopyFrom(this, cloneContext, fromMesh, fromVertexToIndex);
      return dxfMeshFace;
    }

    private void CopyFrom(
      DxfMeshFace from,
      CloneContext cloneContext,
      DxfPolyfaceMesh mesh,
      Dictionary<DxfVertex3D, int> fromVertexToIndex)
    {
      this.CopyFrom((DxfHandledObject) from, cloneContext);
      foreach (DxfMeshFace.Corner corner in from.list_0)
      {
        int index = fromVertexToIndex[corner.Vertex];
        this.list_0.Add(new DxfMeshFace.Corner(mesh.Vertices[index], corner.EdgeVisible));
      }
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override short vmethod_6(Class432 w)
    {
      return 14;
    }

    internal DxfMeshFace Clone(
      Dictionary<DxfVertex3D, int> fromVertexToIndex,
      DxfPolyfaceMesh dxfPolyfaceMesh,
      CloneContext cloneContext)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public struct Corner
    {
      private DxfObjectReference dxfObjectReference_0;
      private bool bool_0;

      public Corner(DxfVertex3D vertex)
      {
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) vertex);
        this.bool_0 = true;
      }

      public Corner(DxfVertex3D vertex, bool edgeVisible)
      {
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) vertex);
        this.bool_0 = edgeVisible;
      }

      public DxfVertex3D Vertex
      {
        get
        {
          return (DxfVertex3D) this.dxfObjectReference_0.Value;
        }
        set
        {
          this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        }
      }

      public bool EdgeVisible
      {
        get
        {
          return this.bool_0;
        }
        set
        {
          this.bool_0 = value;
        }
      }
    }
  }
}
