// Decompiled with JetBrains decompiler
// Type: ns3.Class293
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model.Entities;

namespace ns3
{
  internal class Class293 : Class285
  {
    private ushort ushort_0;
    private ushort ushort_1;
    private ushort ushort_2;
    private ushort ushort_3;
    private ulong ulong_6;
    private ulong ulong_7;
    private List<ulong> list_1;
    private ulong ulong_8;

    public Class293(DxfPolygonMeshBase mesh)
      : base((DxfEntity) mesh)
    {
    }

    public ushort MVertexCount
    {
      get
      {
        return this.ushort_0;
      }
      set
      {
        this.ushort_0 = value;
      }
    }

    public ushort NVertexCount
    {
      get
      {
        return this.ushort_1;
      }
      set
      {
        this.ushort_1 = value;
      }
    }

    public ushort SmoothSurfaceMDensity
    {
      get
      {
        return this.ushort_2;
      }
      set
      {
        this.ushort_2 = value;
      }
    }

    public ushort SmoothSurfaceNDensity
    {
      get
      {
        return this.ushort_3;
      }
      set
      {
        this.ushort_3 = value;
      }
    }

    public ulong FirstVertexHandle
    {
      get
      {
        return this.ulong_6;
      }
      set
      {
        this.ulong_6 = value;
      }
    }

    public ulong LastVertexHandle
    {
      get
      {
        return this.ulong_7;
      }
      set
      {
        this.ulong_7 = value;
      }
    }

    public List<ulong> VertexHandles
    {
      get
      {
        if (this.list_1 == null)
          this.list_1 = new List<ulong>();
        return this.list_1;
      }
    }

    public ulong SequenceEndHandle
    {
      get
      {
        return this.ulong_8;
      }
      set
      {
        this.ulong_8 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfPolygonMeshBase entity = (DxfPolygonMeshBase) this.Entity;
      DxfPolygonSplineMesh splineMesh = entity as DxfPolygonSplineMesh;
      if (splineMesh != null)
      {
        splineMesh.MControlPointCount = this.ushort_0;
        splineMesh.NControlPointCount = this.ushort_1;
        splineMesh.SmoothSurfaceMDensity = this.ushort_2;
        splineMesh.SmoothSurfaceNDensity = this.ushort_3;
        int controlPointIndex = 0;
        int approximationPointIndex = 0;
        if (this.ulong_6 != 0UL)
        {
          for (Class285 entityBuilder = modelBuilder.method_6(this.ulong_6); entityBuilder != null; entityBuilder = modelBuilder.method_7(entityBuilder))
          {
            this.method_3(splineMesh, entityBuilder, ref controlPointIndex, ref approximationPointIndex);
            if ((long) entityBuilder.HandledObject.Handle == (long) this.ulong_7)
              break;
          }
        }
        else
        {
          if (this.list_1 == null)
            return;
          for (int index = 0; index < this.list_1.Count; ++index)
          {
            ulong handle = this.list_1[index];
            this.method_3(splineMesh, modelBuilder.method_6(handle), ref controlPointIndex, ref approximationPointIndex);
          }
        }
      }
      else
      {
        DxfPolygonMesh polygonMesh = (DxfPolygonMesh) entity;
        polygonMesh.MVertexCount = this.ushort_0;
        polygonMesh.NVertexCount = this.ushort_1;
        int vertexIndex = 0;
        if (this.ulong_6 != 0UL)
        {
          for (Class285 entityBuilder = modelBuilder.method_6(this.ulong_6); entityBuilder != null; entityBuilder = modelBuilder.method_7(entityBuilder))
          {
            this.method_2(polygonMesh, entityBuilder, ref vertexIndex);
            if ((long) entityBuilder.HandledObject.Handle == (long) this.ulong_7)
              break;
          }
        }
        else
        {
          if (this.list_1 == null)
            return;
          for (int index = 0; index < this.list_1.Count; ++index)
          {
            ulong handle = this.list_1[index];
            Class285 entityBuilder = modelBuilder.method_6(handle);
            this.method_2(polygonMesh, entityBuilder, ref vertexIndex);
          }
        }
      }
    }

    private int method_2(DxfPolygonMesh polygonMesh, Class285 entityBuilder, ref int vertexIndex)
    {
      if (entityBuilder != null)
      {
        Class301 class301 = (Class301) entityBuilder;
        polygonMesh.Vertices.Add((DxfVertex3D) class301.Entity);
        ++vertexIndex;
      }
      return vertexIndex;
    }

    private void method_3(
      DxfPolygonSplineMesh splineMesh,
      Class285 entityBuilder,
      ref int controlPointIndex,
      ref int approximationPointIndex)
    {
      if (entityBuilder == null)
        return;
      Class301 class301 = (Class301) entityBuilder;
      if (class301.IsSplineControlPoint)
      {
        splineMesh.ControlPoints.Add((DxfVertex3D) class301.Entity);
        ++controlPointIndex;
      }
      else
      {
        splineMesh.ApproximationPoints.Add((DxfVertex3D) class301.Entity);
        ++approximationPointIndex;
      }
    }
  }
}
