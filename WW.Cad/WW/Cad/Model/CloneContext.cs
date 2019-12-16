// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.CloneContext
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using System;
using System.Collections.Generic;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model
{
  public class CloneContext
  {
    private readonly Dictionary<IGraphCloneable, IGraphCloneable> dictionary_0 = new Dictionary<IGraphCloneable, IGraphCloneable>();
    private readonly List<ICloneBuilder> list_0 = new List<ICloneBuilder>();
    private readonly List<DxfDictionaryEntry> list_1 = new List<DxfDictionaryEntry>();
    private readonly HashSet<DxfHandledObject> hashSet_0 = new HashSet<DxfHandledObject>();
    private readonly List<DxfHandledObject> list_2 = new List<DxfHandledObject>();
    private bool bool_2 = true;
    private readonly DxfModel dxfModel_0;
    private readonly DxfModel dxfModel_1;
    private readonly ReferenceResolutionType referenceResolutionType_0;
    private bool bool_0;
    private bool bool_1;
    private bool bool_3;
    private bool bool_4;
    private CloneContext.Class756 class756_0;

    public CloneContext(
      DxfModel sourceModel,
      DxfModel targetModel,
      ReferenceResolutionType referenceResolutionType)
    {
      if (targetModel == null)
        throw new ArgumentNullException();
      this.dxfModel_0 = sourceModel;
      this.dxfModel_1 = targetModel;
      this.referenceResolutionType_0 = referenceResolutionType;
      this.class756_0 = new CloneContext.Class756(this);
    }

    public Dictionary<IGraphCloneable, IGraphCloneable> SourceToClonedObject
    {
      get
      {
        return this.dictionary_0;
      }
    }

    public DxfModel SourceModel
    {
      get
      {
        return this.dxfModel_0;
      }
    }

    public DxfModel TargetModel
    {
      get
      {
        return this.dxfModel_1;
      }
    }

    public ReferenceResolutionType ReferenceResolutionType
    {
      get
      {
        return this.referenceResolutionType_0;
      }
    }

    public List<ICloneBuilder> CloneBuilders
    {
      get
      {
        return this.list_0;
      }
    }

    public bool AllowDuplicateNames
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

    public bool RenameClashingBlocks
    {
      get
      {
        return this.bool_3;
      }
      set
      {
        this.bool_3 = value;
      }
    }

    public bool CloneHeader
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public List<DxfHandledObject> IndirectlyClonedObjects
    {
      get
      {
        return this.list_2;
      }
    }

    public bool AddDefaultReactorToDictionaryEntries
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
      }
    }

    public bool CloneExact
    {
      get
      {
        return this.bool_4;
      }
      set
      {
        this.bool_4 = value;
      }
    }

    public IGraphCloneable GetExistingClone(IGraphCloneable sourceObject)
    {
      if (sourceObject == null)
        return (IGraphCloneable) null;
      IGraphCloneable graphCloneable;
      this.dictionary_0.TryGetValue(sourceObject, out graphCloneable);
      return graphCloneable;
    }

    public IGraphCloneable Clone(IGraphCloneable sourceObject)
    {
      return sourceObject?.Clone(this);
    }

    public DxfHandledObject CloneReference(DxfHandledObject sourceObject)
    {
      if (sourceObject == null)
        return (DxfHandledObject) null;
      ITableRecord tableRecord = sourceObject as ITableRecord;
      if (tableRecord != null)
      {
        if (this.dxfModel_0 == this.dxfModel_1)
          return sourceObject;
        tableRecord.Accept((ITableRecordVisitor) this.class756_0);
        return this.class756_0.ClonedTableRecord;
      }
      DxfHandledObject dxfHandledObject = (DxfHandledObject) sourceObject.Clone(this);
      if (this.dxfModel_0 != this.dxfModel_1)
        this.method_0(dxfHandledObject);
      return dxfHandledObject;
    }

    public DxfHandledObject CloneTableRecord(ITableRecord tableRecord)
    {
      if (tableRecord == null)
        return (DxfHandledObject) null;
      tableRecord.Accept((ITableRecordVisitor) this.class756_0);
      return this.class756_0.ClonedTableRecord;
    }

    public void RegisterClone(IGraphCloneable sourceObject, IGraphCloneable clonedObject)
    {
      this.dictionary_0.Add(sourceObject, clonedObject);
    }

    public CloneContext CreateNew()
    {
      return new CloneContext(this.dxfModel_0, this.dxfModel_1, this.referenceResolutionType_0);
    }

    public void ResolveReferences()
    {
      for (int index = 0; index < this.list_0.Count; ++index)
        this.list_0[index].ResolveReferences(this);
      this.list_0.Clear();
      if (!this.bool_2)
        return;
      foreach (DxfDictionaryEntry dxfDictionaryEntry in this.list_1)
      {
        if (dxfDictionaryEntry.Value != null)
          dxfDictionaryEntry.Value.AddPersistentReactor((DxfHandledObject) dxfDictionaryEntry.Dictionary);
      }
      this.list_1.Clear();
    }

    internal List<DxfDictionaryEntry> ClonedDictionaryEntries
    {
      get
      {
        return this.list_1;
      }
    }

    internal void method_0(DxfHandledObject obj)
    {
      if (this.hashSet_0.Contains(obj))
        return;
      this.hashSet_0.Add(obj);
      this.list_2.Add(obj);
    }

    private class Class756 : ITableRecordVisitor
    {
      private CloneContext cloneContext_0;
      private DxfHandledObject dxfHandledObject_0;

      public Class756(CloneContext cloneContext)
      {
        this.cloneContext_0 = cloneContext;
      }

      public DxfHandledObject ClonedTableRecord
      {
        get
        {
          return this.dxfHandledObject_0;
        }
      }

      public void Visit(DxfAppId value)
      {
        this.dxfHandledObject_0 = (DxfHandledObject) Class906.smethod_3(this.cloneContext_0, value);
      }

      public void Visit(DxfBlock value)
      {
        this.dxfHandledObject_0 = (DxfHandledObject) Class906.smethod_0(this.cloneContext_0, value, false);
      }

      public void Visit(DxfDimensionStyle value)
      {
        this.dxfHandledObject_0 = (DxfHandledObject) Class906.smethod_5(this.cloneContext_0, value);
      }

      public void Visit(DxfLayer value)
      {
        this.dxfHandledObject_0 = (DxfHandledObject) Class906.GetLayer(this.cloneContext_0, value);
      }

      public void Visit(DxfLineType value)
      {
        this.dxfHandledObject_0 = (DxfHandledObject) Class906.GetLineType(this.cloneContext_0, value);
      }

      public void Visit(DxfTextStyle value)
      {
        this.dxfHandledObject_0 = (DxfHandledObject) Class906.GetTextStyle(this.cloneContext_0, value);
      }

      public void Visit(DxfUcs value)
      {
        this.dxfHandledObject_0 = (DxfHandledObject) Class906.smethod_2(this.cloneContext_0, value);
      }

      public void Visit(DxfView value)
      {
        this.dxfHandledObject_0 = (DxfHandledObject) Class906.smethod_6(this.cloneContext_0, value);
      }

      public void Visit(DxfViewportEntityHeader value)
      {
        this.dxfHandledObject_0 = (DxfHandledObject) Class906.smethod_8(this.cloneContext_0, value);
      }

      public void Visit(DxfVPort value)
      {
        this.dxfHandledObject_0 = (DxfHandledObject) Class906.smethod_7(this.cloneContext_0, value);
      }
    }
  }
}
