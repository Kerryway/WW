// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfSortEntsTable
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns28;
using System;
using System.Collections.Generic;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model.Objects
{
  public class DxfSortEntsTable : DxfObject
  {
    private DxfObjectReference dxfObjectReference_3 = DxfObjectReference.Null;
    private readonly List<DxfEntitySortWrapper> list_0 = new List<DxfEntitySortWrapper>();
    private readonly Dictionary<DxfObjectReference, DxfEntitySortWrapper> dictionary_0 = new Dictionary<DxfObjectReference, DxfEntitySortWrapper>();
    private DxfHandledObjectCollection<DxfEntity> dxfHandledObjectCollection_1;

    public DxfBlock OwnerBlock
    {
      get
      {
        return (DxfBlock) this.dxfObjectReference_3.Value;
      }
      set
      {
        if (this.OwnerBlock != null)
          this.OwnerBlock.EntitiesChanged -= new EventHandler(this.method_12);
        if (value == null)
        {
          this.dxfObjectReference_3 = DxfObjectReference.Null;
        }
        else
        {
          this.dxfObjectReference_3 = value.Reference;
          value.EntitiesChanged += new EventHandler(this.method_12);
        }
      }
    }

    public List<DxfEntitySortWrapper> EntitySortWrappers
    {
      get
      {
        return this.list_0;
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_19.ClassNumber;
    }

    public override string ObjectType
    {
      get
      {
        return "SORTENTSTABLE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbSortentsTable";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfSortEntsTable dxfSortEntsTable = (DxfSortEntsTable) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfSortEntsTable == null)
      {
        dxfSortEntsTable = new DxfSortEntsTable();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfSortEntsTable);
        dxfSortEntsTable.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfSortEntsTable;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfSortEntsTable dxfSortEntsTable = (DxfSortEntsTable) from;
      this.OwnerBlock = cloneContext.SourceModel != cloneContext.TargetModel ? Class906.smethod_0(cloneContext, dxfSortEntsTable.OwnerBlock, false) : (DxfBlock) cloneContext.GetExistingClone((IGraphCloneable) dxfSortEntsTable.OwnerBlock);
      foreach (DxfEntitySortWrapper from1 in dxfSortEntsTable.list_0)
      {
        DxfEntitySortWrapper entitySortWrapper = new DxfEntitySortWrapper();
        entitySortWrapper.CopyFrom(cloneContext, from1);
        this.list_0.Add(entitySortWrapper);
        this.dictionary_0[entitySortWrapper.Entity.Reference] = entitySortWrapper;
      }
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf14OrHigher;
    }

    internal DxfEntitySortWrapper method_8(DxfEntity entity)
    {
      DxfEntitySortWrapper entitySortWrapper = (DxfEntitySortWrapper) null;
      if (entity != null)
      {
        if (!this.dictionary_0.TryGetValue(entity.Reference, out entitySortWrapper))
        {
          entitySortWrapper = new DxfEntitySortWrapper();
          entitySortWrapper.Entity = entity;
          this.dictionary_0.Add(entitySortWrapper.Entity.Reference, entitySortWrapper);
        }
        this.list_0.Add(entitySortWrapper);
      }
      return entitySortWrapper;
    }

    internal DxfEntitySortWrapper method_9(DxfEntity entity, ulong sortHandle)
    {
      DxfEntitySortWrapper entitySortWrapper = (DxfEntitySortWrapper) null;
      if (entity != null)
      {
        if (this.dictionary_0.TryGetValue(entity.Reference, out entitySortWrapper))
        {
          entitySortWrapper.SortHandle = sortHandle;
        }
        else
        {
          entitySortWrapper = new DxfEntitySortWrapper(entity, sortHandle);
          entitySortWrapper.Entity = entity;
          this.dictionary_0.Add(entitySortWrapper.Entity.Reference, entitySortWrapper);
        }
        this.list_0.Add(entitySortWrapper);
      }
      return entitySortWrapper;
    }

    internal void method_10(DxfEntitySortWrapper entitySortWrapper)
    {
      this.list_0.Remove(entitySortWrapper);
      this.dictionary_0.Remove(entitySortWrapper.Entity.Reference);
    }

    internal IList<DxfEntity> GetSortedEntities(IList<DxfEntity> entities)
    {
      if (this.dxfHandledObjectCollection_1 == null)
        this.method_11(entities);
      return (IList<DxfEntity>) this.dxfHandledObjectCollection_1;
    }

    internal void method_11(IList<DxfEntity> entities)
    {
      if (this.dictionary_0.Count != this.list_0.Count)
      {
        this.dictionary_0.Clear();
        foreach (DxfEntitySortWrapper entitySortWrapper in this.list_0)
          this.dictionary_0[entitySortWrapper.Entity.Reference] = entitySortWrapper;
      }
      if (this.dxfHandledObjectCollection_1 != null && this.dxfHandledObjectCollection_1.Count == entities.Count)
        return;
      List<DxfEntitySortWrapper> entitySortWrapperList = new List<DxfEntitySortWrapper>();
      foreach (DxfEntity entity in (IEnumerable<DxfEntity>) entities)
      {
        DxfEntitySortWrapper entitySortWrapper;
        if (!this.dictionary_0.TryGetValue(entity.Reference, out entitySortWrapper))
          entitySortWrapper = new DxfEntitySortWrapper(entity, entity.Handle);
        entitySortWrapperList.Add(entitySortWrapper);
      }
      entitySortWrapperList.Sort();
      if (this.dxfHandledObjectCollection_1 == null)
        this.dxfHandledObjectCollection_1 = new DxfHandledObjectCollection<DxfEntity>(entitySortWrapperList.Count);
      else
        this.dxfHandledObjectCollection_1.Clear();
      foreach (DxfEntitySortWrapper entitySortWrapper in entitySortWrapperList)
        this.dxfHandledObjectCollection_1.Add(entitySortWrapper.Entity);
    }

    private void method_12(object sender, EventArgs e)
    {
      this.dxfHandledObjectCollection_1 = (DxfHandledObjectCollection<DxfEntity>) null;
    }
  }
}
