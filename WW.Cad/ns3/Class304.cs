// Decompiled with JetBrains decompiler
// Type: ns3.Class304
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class304 : Class285
  {
    private ulong ulong_6;
    private ulong ulong_7;
    private List<ulong> list_1;
    private ulong ulong_8;

    public Class304(DxfPolyfaceMesh polyline)
      : base((DxfEntity) polyline)
    {
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
      DxfPolyfaceMesh entity = (DxfPolyfaceMesh) this.Entity;
      if (entity != null)
      {
        if (this.ulong_6 != 0UL)
        {
          for (Class285 entityBuilder = modelBuilder.method_6(this.ulong_6); entityBuilder != null; entityBuilder = modelBuilder.method_7(entityBuilder))
          {
            Class304.smethod_0(entity, entityBuilder);
            if ((long) entityBuilder.HandledObject.Handle == (long) this.ulong_7)
              break;
          }
          for (Class285 entityBuilder = modelBuilder.method_6(this.ulong_6); entityBuilder != null; entityBuilder = modelBuilder.method_7(entityBuilder))
          {
            this.method_2(modelBuilder, entity, entityBuilder);
            if ((long) entityBuilder.HandledObject.Handle == (long) this.ulong_7)
              break;
          }
        }
        else if (this.list_1 != null)
        {
          for (int index = 0; index < this.list_1.Count; ++index)
          {
            ulong handle = this.list_1[index];
            Class304.smethod_0(entity, modelBuilder.method_6(handle));
          }
          for (int index = 0; index < this.list_1.Count; ++index)
          {
            ulong handle = this.list_1[index];
            this.method_2(modelBuilder, entity, modelBuilder.method_6(handle));
          }
        }
      }
      if (this.ulong_8 == 0UL)
        return;
      DxfSequenceEnd dxfSequenceEnd = modelBuilder.method_4<DxfSequenceEnd>(this.ulong_8);
      if (dxfSequenceEnd == null)
        return;
      entity.SeqEnd = dxfSequenceEnd;
    }

    private static void smethod_0(DxfPolyfaceMesh mesh, Class285 entityBuilder)
    {
      Class301 class301 = entityBuilder as Class301;
      if (class301 == null)
        return;
      mesh.Vertices.Add((DxfVertex3D) class301.Entity);
    }

    private void method_2(Class374 modelBuilder, DxfPolyfaceMesh mesh, Class285 entityBuilder)
    {
      Class286 class286 = entityBuilder as Class286;
      if (class286 == null)
        return;
      DxfMeshFace entity = (DxfMeshFace) class286.Entity;
      if (class286.Vertex0Index != (short) 0)
      {
        int index = Math.Abs((int) class286.Vertex0Index) - 1;
        if (index >= mesh.Vertices.Count)
        {
          this.method_3(modelBuilder, mesh, (int) class286.Vertex0Index);
          return;
        }
        entity.Corners.Add(new DxfMeshFace.Corner(mesh.Vertices[index], class286.Vertex0Index > (short) 0));
      }
      if (class286.Vertex1Index != (short) 0)
      {
        int index = Math.Abs((int) class286.Vertex1Index) - 1;
        if (index >= mesh.Vertices.Count)
        {
          this.method_3(modelBuilder, mesh, (int) class286.Vertex1Index);
          return;
        }
        entity.Corners.Add(new DxfMeshFace.Corner(mesh.Vertices[index], class286.Vertex1Index > (short) 0));
      }
      if (class286.Vertex2Index != (short) 0)
      {
        int index = Math.Abs((int) class286.Vertex2Index) - 1;
        if (index >= mesh.Vertices.Count)
        {
          this.method_3(modelBuilder, mesh, (int) class286.Vertex2Index);
          return;
        }
        entity.Corners.Add(new DxfMeshFace.Corner(mesh.Vertices[index], class286.Vertex2Index > (short) 0));
      }
      if (class286.Vertex3Index != (short) 0)
      {
        int index = Math.Abs((int) class286.Vertex3Index) - 1;
        if (index >= mesh.Vertices.Count)
        {
          this.method_3(modelBuilder, mesh, (int) class286.Vertex3Index);
          return;
        }
        entity.Corners.Add(new DxfMeshFace.Corner(mesh.Vertices[index], class286.Vertex3Index > (short) 0));
      }
      mesh.Faces.Add(entity);
    }

    private void method_3(Class374 modelBuilder, DxfPolyfaceMesh mesh, int vertexIndex)
    {
      DxfBlock objectSoftReference = mesh.OwnerObjectSoftReference as DxfBlock;
      if (objectSoftReference != null)
        ((Class318) modelBuilder.method_5(objectSoftReference.Handle)).method_1((DxfEntity) mesh);
      this.IsValid = false;
      modelBuilder.Messages.Add(new DxfMessage(DxfStatus.InvalidMeshFaceVertexIndex, Severity.Error, "target", (object) mesh)
      {
        Parameters = {
          {
            "VertexIndex",
            (object) vertexIndex
          }
        }
      });
    }
  }
}
