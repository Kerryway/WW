// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.EntityCounter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Cad.Model.Entities;
using WW.Cad.Model.InventorDrawing;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model
{
  public class EntityCounter : IEntityVisitor
  {
    private static readonly EntityCounter.Class598 class598_0 = new EntityCounter.Class598();
    private EntityCounter.Class599 class599_0 = new EntityCounter.Class599();
    private readonly IDictionary<DxfBlock, EntityCounter.Class599> idictionary_0 = (IDictionary<DxfBlock, EntityCounter.Class599>) new Dictionary<DxfBlock, EntityCounter.Class599>();
    private readonly EntityCounter.HandlingFlags handlingFlags_0;
    private EntityCounter.SpaceFlags spaceFlags_0;

    public EntityCounter()
      : this(EntityCounter.HandlingFlags.FollowAll, EntityCounter.SpaceFlags.AllSpaces)
    {
    }

    public EntityCounter(
      EntityCounter.HandlingFlags handlingFlags,
      EntityCounter.SpaceFlags spaceFilter)
    {
      this.handlingFlags_0 = handlingFlags;
      this.spaceFlags_0 = spaceFilter;
    }

    public static IList<Pair<string, uint>> GetFileEntityCounts(
      DxfModel model,
      string totalEntryLabel)
    {
      EntityCounter entityCounter = new EntityCounter(EntityCounter.HandlingFlags.IncludeDimensionBlocks | EntityCounter.HandlingFlags.IncludeTableBlocks | EntityCounter.HandlingFlags.IncludeVertices, EntityCounter.SpaceFlags.AllSpaces);
      BasicEntityVisitor.Visit(model, (IEntityVisitor) entityCounter);
      foreach (DxfBlock block in (KeyedDxfHandledObjectCollection<string, DxfBlock>) model.Blocks)
        BasicEntityVisitor.Visit((IEnumerable<DxfEntity>) block.Entities, (IEntityVisitor) entityCounter);
      if (totalEntryLabel == null)
        return entityCounter.GetStatistics();
      return entityCounter.GetStatisticsWithTotal(totalEntryLabel);
    }

    public void Reset()
    {
      this.class599_0 = new EntityCounter.Class599();
    }

    private bool method_0(DxfEntity entity)
    {
      if ((this.spaceFlags_0 & EntityCounter.SpaceFlags.AllSpaces) == EntityCounter.SpaceFlags.AllSpaces)
      {
        this.class599_0.method_0(entity.EntityType, 1U);
        return true;
      }
      if ((this.spaceFlags_0 & EntityCounter.SpaceFlags.ModelSpace) != (EntityCounter.SpaceFlags) 0)
      {
        if (entity.PaperSpace)
          return false;
        this.class599_0.method_0(entity.EntityType, 1U);
        return true;
      }
      if ((this.spaceFlags_0 & EntityCounter.SpaceFlags.PaperSpace) == (EntityCounter.SpaceFlags) 0 || !entity.PaperSpace)
        return false;
      this.class599_0.method_0(entity.EntityType, 1U);
      return true;
    }

    public IList<Pair<string, uint>> GetStatistics()
    {
      return this.class599_0.Counts;
    }

    public IList<Pair<string, uint>> GetStatisticsWithTotal(string totalEntryLabel)
    {
      IList<Pair<string, uint>> counts = this.class599_0.Counts;
      uint second = 0;
      foreach (Pair<string, uint> pair in (IEnumerable<Pair<string, uint>>) counts)
        second += pair.Second;
      counts.Add(new Pair<string, uint>(totalEntryLabel, second));
      return counts;
    }

    private void method_1(DxfDimension dimension)
    {
      this.class599_0.method_0(dimension.EntityType, 1U);
      if ((this.handlingFlags_0 & EntityCounter.HandlingFlags.IncludeDimensionBlocks) == (EntityCounter.HandlingFlags) 0)
        return;
      DxfBlock block = dimension.Block;
      if (block == null)
        return;
      foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) block.Entities)
        entity.Accept((IEntityVisitor) this);
    }

    private void method_2(int count)
    {
      this.class599_0.method_0("VERTEX", (uint) count);
    }

    public void Visit(Dxf3DFace face)
    {
      this.method_0((DxfEntity) face);
    }

    public void Visit(Dxf3DSolid solid)
    {
      this.method_0((DxfEntity) solid);
    }

    public void Visit(DxfArc arc)
    {
      this.method_0((DxfEntity) arc);
    }

    public void Visit(DxfAttribute attribute)
    {
      this.method_0((DxfEntity) attribute);
    }

    public void Visit(DxfAttributeDefinition attributeDefinition)
    {
      this.method_0((DxfEntity) attributeDefinition);
    }

    public void Visit(DxfCircle circle)
    {
      this.method_0((DxfEntity) circle);
    }

    public void Visit(DxfDimension.Aligned dimension)
    {
      this.method_1((DxfDimension) dimension);
    }

    public void Visit(DxfDimension.Angular3Point dimension)
    {
      this.method_1((DxfDimension) dimension);
    }

    public void Visit(DxfDimension.Angular4Point dimension)
    {
      this.method_1((DxfDimension) dimension);
    }

    public void Visit(DxfDimension.Diametric dimension)
    {
      this.method_1((DxfDimension) dimension);
    }

    public void Visit(DxfDimension.Linear dimension)
    {
      this.method_1((DxfDimension) dimension);
    }

    public void Visit(DxfDimension.Ordinate dimension)
    {
      this.method_1((DxfDimension) dimension);
    }

    public void Visit(DxfDimension.Radial dimension)
    {
      this.method_1((DxfDimension) dimension);
    }

    public void Visit(DxfEllipse ellipse)
    {
      this.method_0((DxfEntity) ellipse);
    }

    public void Visit(DxfHatch hatch)
    {
      this.method_0((DxfEntity) hatch);
    }

    public void Visit(DxfImage image)
    {
      this.method_0((DxfEntity) image);
    }

    public void Visit(DxfWipeout image)
    {
      this.method_0((DxfEntity) image);
    }

    public void Visit(DxfInsert insert)
    {
      if (!this.method_0((DxfEntity) insert))
        return;
      this.class599_0.method_0("ATTRIB", (uint) insert.Attributes.Count);
      if ((this.handlingFlags_0 & EntityCounter.HandlingFlags.FollowInserts) == (EntityCounter.HandlingFlags) 0)
        return;
      DxfBlock block = insert.Block;
      if (block == null)
        return;
      int multiplicator = (int) insert.ColumnCount * (int) insert.RowCount;
      EntityCounter.Class599 class5990_1;
      if (!this.idictionary_0.TryGetValue(block, out class5990_1))
      {
        EntityCounter.Class599 class5990_2 = this.class599_0;
        EntityCounter.SpaceFlags spaceFlags0 = this.spaceFlags_0;
        try
        {
          this.class599_0 = new EntityCounter.Class599();
          this.spaceFlags_0 = EntityCounter.SpaceFlags.AllSpaces;
          foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) block.Entities)
            entity.Accept((IEntityVisitor) this);
        }
        finally
        {
          class5990_1 = this.class599_0;
          this.class599_0 = class5990_2;
          this.spaceFlags_0 = spaceFlags0;
          this.idictionary_0[block] = class5990_1;
        }
      }
      this.class599_0.method_1(class5990_1, multiplicator);
    }

    public void Visit(DxfIDBlockReference insert)
    {
      this.Visit((DxfInsert) insert);
    }

    public void Visit(DxfLeader leader)
    {
      this.method_0((DxfEntity) leader);
    }

    public void Visit(DxfLine line)
    {
      this.method_0((DxfEntity) line);
    }

    public void Visit(DxfLwPolyline polyline)
    {
      this.method_0((DxfEntity) polyline);
    }

    public void Visit(DxfMeshFace meshFace)
    {
      this.method_0((DxfEntity) meshFace);
    }

    public void Visit(DxfMLeader mleader)
    {
      this.method_0((DxfEntity) mleader);
    }

    public void Visit(DxfMLine mline)
    {
      this.method_0((DxfEntity) mline);
    }

    public void Visit(DxfMText mtext)
    {
      this.method_0((DxfEntity) mtext);
    }

    public void Visit(DxfPoint point)
    {
      this.method_0((DxfEntity) point);
    }

    public void Visit(DxfPolyfaceMesh mesh)
    {
      this.method_0((DxfEntity) mesh);
      this.method_2(mesh.Faces.Count + mesh.Vertices.Count);
    }

    public void Visit(DxfPolygonMesh mesh)
    {
      this.method_0((DxfEntity) mesh);
      this.method_2((int) mesh.MVertexCount * (int) mesh.NVertexCount);
    }

    public void Visit(DxfPolygonSplineMesh mesh)
    {
      this.method_0((DxfEntity) mesh);
      this.method_2(mesh.ApproximationPoints.Count + mesh.ControlPoints.Count);
    }

    public void Visit(DxfPolyline2D polyline)
    {
      this.method_0((DxfEntity) polyline);
      this.method_2(polyline.Vertices.Count);
    }

    public void Visit(DxfPolyline2DSpline polyline)
    {
      this.method_0((DxfEntity) polyline);
      this.method_2(polyline.ApproximationPoints.Count + polyline.ControlPoints.Count);
    }

    public void Visit(DxfPolyline3D polyline)
    {
      this.method_0((DxfEntity) polyline);
      this.method_2(polyline.Vertices.Count);
    }

    public void Visit(DxfPolyline3DSpline polyline)
    {
      this.method_0((DxfEntity) polyline);
      this.method_2(polyline.ApproximationPoints.Count + polyline.ControlPoints.Count);
    }

    public void Visit(DxfProxyEntity proxyEntity)
    {
      this.method_0((DxfEntity) proxyEntity);
    }

    public void Visit(DxfRay ray)
    {
      this.method_0((DxfEntity) ray);
    }

    public void Visit(DxfShape shape)
    {
      this.method_0((DxfEntity) shape);
    }

    public void Visit(DxfRegion region)
    {
      this.method_0((DxfEntity) region);
    }

    public void Visit(DxfBody body)
    {
      this.method_0((DxfEntity) body);
    }

    public void Visit(DxfSequenceEnd sequenceEnd)
    {
    }

    public void Visit(DxfSolid solid)
    {
      this.method_0((DxfEntity) solid);
    }

    public void Visit(DxfSpline spline)
    {
      this.method_0((DxfEntity) spline);
    }

    public void Visit(DxfTable table)
    {
      this.method_0((DxfEntity) table);
      if ((this.handlingFlags_0 & EntityCounter.HandlingFlags.IncludeTableBlocks) == (EntityCounter.HandlingFlags) 0)
        return;
      DxfBlock block = table.Block;
      if (block == null)
        return;
      foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) block.Entities)
        entity.Accept((IEntityVisitor) this);
    }

    public void Visit(DxfText text)
    {
      this.method_0((DxfEntity) text);
    }

    public void Visit(DxfTolerance tolerance)
    {
      this.method_0((DxfEntity) tolerance);
    }

    public void Visit(DxfVertex2D vertex)
    {
      this.method_0((DxfEntity) vertex);
    }

    public void Visit(DxfVertex3D vertex)
    {
      this.method_0((DxfEntity) vertex);
    }

    public void Visit(DxfViewport viewport)
    {
      this.method_0((DxfEntity) viewport);
    }

    public void Visit(DxfXLine xline)
    {
      this.method_0((DxfEntity) xline);
    }

    public void Visit(DxfOle ole)
    {
      this.method_0((DxfEntity) ole);
    }

    private class Class598 : IComparer<Pair<string, uint>>
    {
      public int Compare(Pair<string, uint> x, Pair<string, uint> y)
      {
        return string.Compare(x.First, y.First, StringComparison.InvariantCultureIgnoreCase);
      }
    }

    internal class Class599
    {
      private readonly IDictionary<string, EntityCounter.Class599.Class600> idictionary_0 = (IDictionary<string, EntityCounter.Class599.Class600>) new Dictionary<string, EntityCounter.Class599.Class600>();

      public void method_0(string type, uint multiplicator)
      {
        if (multiplicator == 0U)
          return;
        EntityCounter.Class599.Class600 class600;
        if (this.idictionary_0.TryGetValue(type, out class600))
          class600.uint_0 += multiplicator;
        else
          this.idictionary_0[type] = new EntityCounter.Class599.Class600(multiplicator);
      }

      public void method_1(EntityCounter.Class599 statistics, int multiplicator)
      {
        if (multiplicator == 0)
          return;
        foreach (KeyValuePair<string, EntityCounter.Class599.Class600> keyValuePair in (IEnumerable<KeyValuePair<string, EntityCounter.Class599.Class600>>) statistics.idictionary_0)
          this.method_0(keyValuePair.Key, (uint) ((ulong) keyValuePair.Value.uint_0 * (ulong) multiplicator));
      }

      public IList<Pair<string, uint>> Counts
      {
        get
        {
          List<Pair<string, uint>> pairList = new List<Pair<string, uint>>(this.idictionary_0.Count);
          foreach (KeyValuePair<string, EntityCounter.Class599.Class600> keyValuePair in (IEnumerable<KeyValuePair<string, EntityCounter.Class599.Class600>>) this.idictionary_0)
            pairList.Add(new Pair<string, uint>(keyValuePair.Key, keyValuePair.Value.uint_0));
          pairList.Sort((IComparer<Pair<string, uint>>) EntityCounter.class598_0);
          return (IList<Pair<string, uint>>) pairList;
        }
      }

      private class Class600
      {
        internal uint uint_0;

        internal Class600(uint value)
        {
          this.uint_0 = value;
        }
      }
    }

    [Flags]
    public enum SpaceFlags
    {
      ModelSpace = 1,
      PaperSpace = 2,
      AllSpaces = PaperSpace | ModelSpace, // 0x00000003
    }

    [Flags]
    public enum HandlingFlags
    {
      FollowInserts = 1,
      IncludeDimensionBlocks = 2,
      IncludeTableBlocks = 4,
      IncludeVertices = 8,
      FollowAll = IncludeVertices | IncludeTableBlocks | IncludeDimensionBlocks | FollowInserts, // 0x0000000F
    }
  }
}
