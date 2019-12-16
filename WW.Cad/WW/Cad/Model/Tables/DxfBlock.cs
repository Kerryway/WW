// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.DxfBlock
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns49;
using ns5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.IO;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.Annotations;
using WW.Collections.Generic;
using WW.Math;

namespace WW.Cad.Model.Tables
{
  [System.ComponentModel.TypeConverter(typeof (ExpandableObjectConverter))]
  public class DxfBlock : DxfTableRecord
  {
    private DxfObjectReference dxfObjectReference_3 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_4 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_5 = DxfObjectReference.Null;
    private BlockFlags blockFlags_0 = BlockFlags.IsReferencedExternalRef;
    private WW.Math.Vector3D vector3D_0 = WW.Math.Vector3D.Zero;
    private DrawingUnits drawingUnits_0 = DrawingUnits.Inches;
    private bool bool_0 = true;
    public const string BlockNameModelSpace = "*Model_Space";
    public const string BlockNamePaperSpace = "*Paper_Space";
    public const string BlockNamePaperSpace0 = "*Paper_Space0";
    private BlockStatusFlags blockStatusFlags_0;
    private DxfEntityCollection dxfEntityCollection_0;
    private string string_0;
    private string string_1;
    private string string_2;
    private bool bool_1;

    internal DxfBlock()
    {
      this.method_10(new DxfEntityCollection());
      this.BlockBegin = new DxfBlockBegin();
      this.BlockEnd = new DxfBlockEnd();
    }

    public DxfBlock(string name)
      : this()
    {
      this.Name = name;
    }

    internal DxfBlock(bool createBlockBeginAndBlockEnd)
    {
      this.method_10(new DxfEntityCollection());
      if (!createBlockBeginAndBlockEnd)
        return;
      this.BlockBegin = new DxfBlockBegin();
      this.BlockEnd = new DxfBlockEnd();
    }

    public WW.Math.Vector3D BasePoint
    {
      get
      {
        DxfModel externalModel = this.ExternalModel;
        if (externalModel == null)
          return this.vector3D_0;
        return (WW.Math.Vector3D) externalModel.Header.InsertionBase;
      }
      set
      {
        if (!string.IsNullOrEmpty(this.string_2))
          throw new DxfException("Cannot set BasePoint for XREF block, set external file's InsertionBase instead!");
        this.vector3D_0 = value;
      }
    }

    internal void method_8(WW.Math.Vector3D point)
    {
      this.vector3D_0 = point;
    }

    public Matrix4D BaseTransformation
    {
      get
      {
        return Transformation4D.Translation(-this.BasePoint);
      }
    }

    public DxfEntityCollection Entities
    {
      get
      {
        return this.dxfEntityCollection_0;
      }
    }

    public override string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        if (value == string.Empty)
          throw new ArgumentException("Block name may not be empty");
        this.string_0 = value;
      }
    }

    public string Description
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public string ExternalReference
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value;
      }
    }

    public DxfModel ExternalModel
    {
      get
      {
        if (string.IsNullOrEmpty(this.string_2))
          return (DxfModel) null;
        DxfModel dxfModel;
        this.Model.ExternalReferences.TryGetValue(this.string_2, out dxfModel);
        return dxfModel;
      }
    }

    public DxfBlockBegin BlockBegin
    {
      get
      {
        return (DxfBlockBegin) this.dxfObjectReference_3.Value;
      }
      set
      {
        DxfBlockBegin blockBegin = this.BlockBegin;
        if (blockBegin == value)
          return;
        blockBegin?.vmethod_2((IDxfHandledObject) null);
        this.dxfObjectReference_3 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        value?.vmethod_2((IDxfHandledObject) this);
      }
    }

    public DxfLayout Layout
    {
      get
      {
        return (DxfLayout) this.dxfObjectReference_5.Value;
      }
      set
      {
        this.dxfObjectReference_5 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public BlockFlags Flags
    {
      get
      {
        return this.blockFlags_0;
      }
      set
      {
        this.blockFlags_0 = value;
      }
    }

    public BlockStatusFlags StatusFlags
    {
      get
      {
        return this.blockStatusFlags_0;
      }
      set
      {
        this.blockStatusFlags_0 = value;
      }
    }

    public bool IsAnonymous
    {
      get
      {
        return (this.blockFlags_0 & BlockFlags.Anonymous) != BlockFlags.None;
      }
      set
      {
        if (value)
          this.blockFlags_0 |= BlockFlags.Anonymous;
        else
          this.blockFlags_0 &= ~BlockFlags.Anonymous;
      }
    }

    public bool IsExternalReference
    {
      get
      {
        return (this.blockFlags_0 & BlockFlags.IsExternalReference) != BlockFlags.None;
      }
      set
      {
        if (value)
          this.blockFlags_0 |= BlockFlags.IsExternalReference;
        else
          this.blockFlags_0 &= ~BlockFlags.IsExternalReference;
      }
    }

    public bool IsXRefOverlay
    {
      get
      {
        return (this.blockFlags_0 & BlockFlags.IsXRefOverlay) != BlockFlags.None;
      }
      set
      {
        if (value)
          this.blockFlags_0 |= BlockFlags.IsXRefOverlay;
        else
          this.blockFlags_0 &= ~BlockFlags.IsXRefOverlay;
      }
    }

    public override bool IsExternallyDependent
    {
      get
      {
        return (this.blockFlags_0 & BlockFlags.IsExternallyDependent) != BlockFlags.None;
      }
      set
      {
        if (value)
          this.blockFlags_0 |= BlockFlags.IsExternallyDependent;
        else
          this.blockFlags_0 &= ~BlockFlags.IsExternallyDependent;
      }
    }

    public override bool IsResolvedExternalRef
    {
      get
      {
        return (this.blockFlags_0 & BlockFlags.IsResolvedExternalRef) != BlockFlags.None;
      }
      set
      {
        if (value)
          this.blockFlags_0 |= BlockFlags.IsResolvedExternalRef;
        else
          this.blockFlags_0 &= ~BlockFlags.IsResolvedExternalRef;
      }
    }

    public override bool IsReferenced
    {
      get
      {
        return (this.blockFlags_0 & BlockFlags.IsReferencedExternalRef) != BlockFlags.None;
      }
      set
      {
        if (value)
          this.blockFlags_0 |= BlockFlags.IsReferencedExternalRef;
        else
          this.blockFlags_0 &= ~BlockFlags.IsReferencedExternalRef;
      }
    }

    public bool IsExternalReferenceUnresolved
    {
      get
      {
        return (this.blockStatusFlags_0 & BlockStatusFlags.ExternalReferenceUnresolved) != BlockStatusFlags.None;
      }
      set
      {
        if (value)
          this.blockStatusFlags_0 |= BlockStatusFlags.ExternalReferenceUnresolved;
        else
          this.blockStatusFlags_0 &= ~BlockStatusFlags.ExternalReferenceUnresolved;
      }
    }

    public bool IsExternalReferenceUnloaded
    {
      get
      {
        return (this.blockStatusFlags_0 & BlockStatusFlags.ExternalReferenceUnloaded) != BlockStatusFlags.None;
      }
      set
      {
        if (value)
          this.blockStatusFlags_0 |= BlockStatusFlags.ExternalReferenceUnloaded;
        else
          this.blockStatusFlags_0 &= ~BlockStatusFlags.ExternalReferenceUnloaded;
      }
    }

    public bool IsExternalReferenceFileNotFound
    {
      get
      {
        return (this.blockStatusFlags_0 & BlockStatusFlags.ExternalReferenceFileNotFound) != BlockStatusFlags.None;
      }
      set
      {
        if (value)
          this.blockStatusFlags_0 |= BlockStatusFlags.ExternalReferenceFileNotFound;
        else
          this.blockStatusFlags_0 &= ~BlockStatusFlags.ExternalReferenceFileNotFound;
      }
    }

    internal DxfSortEntsTable SortEntsTable
    {
      get
      {
        if (this.ExtensionDictionary != null)
        {
          IDictionaryEntry first = this.ExtensionDictionary.Entries.GetFirst("ACAD_SORTENTS");
          if (first != null)
            return first.Value as DxfSortEntsTable;
        }
        return (DxfSortEntsTable) null;
      }
      set
      {
        if (this.ExtensionDictionary == null)
        {
          if (value == null)
            return;
          this.ExtensionDictionary = new DxfDictionary();
        }
        else
          this.ExtensionDictionary.Entries.RemoveAll("ACAD_SORTENTS");
        if (value == null)
          return;
        this.ExtensionDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("ACAD_SORTENTS", (DxfObject) value));
      }
    }

    public DrawingUnits BlockUnits
    {
      get
      {
        return this.drawingUnits_0;
      }
      set
      {
        this.drawingUnits_0 = value;
      }
    }

    public bool Explodable
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

    public bool ScaleUniformly
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

    public override void Accept(ITableRecordVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlock dxfBlock = (DxfBlock) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfBlock == null)
      {
        dxfBlock = new DxfBlock(false);
        this.RegisterClone(cloneContext, (IGraphCloneable) dxfBlock);
        dxfBlock.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfBlock;
    }

    public override void RegisterClone(CloneContext cloneContext, IGraphCloneable clone)
    {
      base.RegisterClone(cloneContext, clone);
      cloneContext.CloneBuilders.Add((ICloneBuilder) new DxfBlock.Class751(this, (DxfBlock) clone));
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlock dxfBlock = (DxfBlock) from;
      this.blockFlags_0 = dxfBlock.blockFlags_0;
      this.blockStatusFlags_0 = dxfBlock.blockStatusFlags_0;
      this.vector3D_0 = dxfBlock.vector3D_0;
      this.string_0 = dxfBlock.string_0;
      this.string_1 = dxfBlock.string_1;
      this.string_2 = dxfBlock.string_2;
      this.BlockBegin = (DxfBlockBegin) dxfBlock.BlockBegin.Clone(cloneContext);
      this.BlockEnd = (DxfBlockEnd) dxfBlock.BlockEnd.Clone(cloneContext);
      if (object.ReferenceEquals((object) dxfBlock.dxfEntityCollection_0, (object) cloneContext.SourceModel.Entities))
        this.method_10(cloneContext.TargetModel.Entities);
      this.drawingUnits_0 = dxfBlock.drawingUnits_0;
      this.bool_0 = dxfBlock.bool_0;
      this.bool_1 = dxfBlock.bool_1;
    }

    public bool LoadExternalReference(
      DxfBlock.GetExternalReferenceDelegate resolveExternalReference)
    {
      bool wasAlreadyLoaded;
      return this.LoadExternalReference(this.Model.ExternalReferences, resolveExternalReference, out wasAlreadyLoaded) != null;
    }

    public bool LoadExternalReference(string searchDirectory)
    {
      Dictionary<string, DxfModel> externalReferences = this.Model.ExternalReferences;
      bool wasAlreadyLoaded;
      return this.LoadExternalReference(externalReferences, new DxfBlock.GetExternalReferenceDelegate(new DxfBlock.Class752(searchDirectory, externalReferences).method_0), out wasAlreadyLoaded) != null;
    }

    internal DxfModel LoadExternalReference(
      Dictionary<string, DxfModel> loadedExternalReferences,
      DxfBlock.GetExternalReferenceDelegate resolveExternalReference,
      out bool wasAlreadyLoaded)
    {
      DxfModel dxfModel = (DxfModel) null;
      wasAlreadyLoaded = false;
      if (this.IsExternalReference && !string.IsNullOrEmpty(this.ExternalReference) && !this.IsExternalReferenceUnloaded)
      {
        wasAlreadyLoaded = loadedExternalReferences.TryGetValue(this.ExternalReference, out dxfModel);
        if (wasAlreadyLoaded)
        {
          if (!this.Model.ExternalReferences.ContainsKey(this.ExternalReference))
            this.Model.ExternalReferences.Add(this.ExternalReference, dxfModel);
        }
        else
        {
          dxfModel = resolveExternalReference(this);
          if (dxfModel != null)
          {
            loadedExternalReferences.Add(this.ExternalReference, dxfModel);
            if (!this.Model.ExternalReferences.ContainsKey(this.ExternalReference))
              this.Model.ExternalReferences.Add(this.ExternalReference, dxfModel);
          }
        }
      }
      return dxfModel;
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      bool flag = true;
      if (!ValidateUtil.ValidateName((object) this, this.string_0, model, messages))
        flag = false;
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfEntity>) this.dxfEntityCollection_0)
      {
        if (!dxfHandledObject.Validate(model, messages))
          flag = false;
      }
      return flag;
    }

    public override string ToString()
    {
      return this.string_0;
    }

    public IEnumerable<DxfAttributeDefinition> GetAttributeDefinitions()
    {
      Class678 class678 = new Class678();
      BasicEntityVisitor.Visit((IEnumerable<DxfEntity>) this.Entities, (IEntityVisitor) class678);
      return (IEnumerable<DxfAttributeDefinition>) class678.AttributeDefinitions;
    }

    public DxfAttributeDefinition GetAttributeDefinition(string tag)
    {
      return Class679.GetAttributeDefinition(tag, (IEnumerable<DxfEntity>) this.Entities);
    }

    public IList<DxfEntity> GetEntitiesInDrawingOrder(bool useSortEntsTable)
    {
      IList<DxfEntity> entities = (IList<DxfEntity>) this.Entities;
      if (useSortEntsTable)
      {
        DxfSortEntsTable sortEntsTable = this.SortEntsTable;
        if (sortEntsTable != null)
          entities = sortEntsTable.GetSortedEntities(entities);
      }
      return entities;
    }

    internal event EventHandler EntitiesChanged;

    internal void method_9(string value)
    {
      this.string_0 = value ?? string.Empty;
    }

    internal bool IsReallyAnonymous
    {
      get
      {
        if (!this.IsAnonymous)
          return this.string_0.StartsWith("*");
        return true;
      }
    }

    protected virtual void OnEntitiesChanged(EventArgs e)
    {
      if (this.eventHandler_0 == null)
        return;
      this.eventHandler_0((object) this, e);
    }

    protected internal override void ExecuteDeepHelper(
      WW.Cad.Model.Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      this.BlockBegin.vmethod_0(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfEntity>) this.dxfEntityCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
      this.BlockEnd.vmethod_0(action, callerStack);
    }

    internal static DxfBlock smethod_2(
      DxfModel model,
      bool useFixedHandles,
      bool createIfNotPresent)
    {
      return DxfBlock.smethod_4(model, useFixedHandles, "*Model_Space", 31UL, 32UL, 33UL, false, createIfNotPresent);
    }

    internal static DxfBlock smethod_3(DxfModel model)
    {
      string str = "*Paper_Space";
      int num = 0;
      while (model.AnonymousBlocks.Contains(str))
      {
        str = "*Paper_Space" + num.ToString();
        ++num;
      }
      return DxfBlock.smethod_4(model, false, str, 0UL, 0UL, 0UL, true, true);
    }

    internal static DxfBlock smethod_4(
      DxfModel model,
      bool useFixedHandles,
      string blockName,
      ulong blockRecordHandle,
      ulong blockBeginHandle,
      ulong endBlockHandle,
      bool paperSpace,
      bool createIfNotPresent)
    {
      DxfBlock dxfBlock;
      if (!model.AnonymousBlocks.TryGetValue(blockName, out dxfBlock) && createIfNotPresent)
      {
        dxfBlock = new DxfBlock(blockName);
        if (useFixedHandles)
        {
          dxfBlock.BlockBegin.SetHandle(blockBeginHandle);
          dxfBlock.BlockEnd.SetHandle(endBlockHandle);
          dxfBlock.SetHandle(blockRecordHandle);
        }
        model.AnonymousBlocks.Add(dxfBlock);
      }
      if (dxfBlock != null && dxfBlock.BlockBegin != null)
        dxfBlock.BlockBegin.PaperSpace = paperSpace;
      return dxfBlock;
    }

    internal bool IsAnnotationBlock
    {
      get
      {
        if (!this.IsAnonymous)
          return false;
        return DxfScale.smethod_3((DxfHandledObject) this) != null;
      }
    }

    public bool MatchOrientationToLayout
    {
      get
      {
        if (!this.HasExtendedData)
          return false;
        DxfModel model = this.Model;
        DxfExtendedData extendedData;
        if (!Class1064.smethod_2((DxfHandledObject) this, model) || !this.ExtendedDataCollection.TryGetValue(model, "AcadAnnoPO", out extendedData) || extendedData.Values.Count <= 0)
          return false;
        return (short) extendedData.Values[0].ValueObject == (short) 1;
      }
    }

    internal override void Repair(DxfModelRepairer repairer)
    {
      base.Repair(repairer);
      if (this.BlockBegin == null)
      {
        this.BlockBegin = new DxfBlockBegin();
        if (this.Layout != null)
          this.BlockBegin.PaperSpace = this.Layout.PaperSpace;
      }
      if (this.BlockEnd != null)
        return;
      this.BlockEnd = new DxfBlockEnd();
    }

    internal DxfBlockEnd BlockEnd
    {
      get
      {
        return (DxfBlockEnd) this.dxfObjectReference_4.Value;
      }
      set
      {
        this.BlockEnd?.vmethod_2((IDxfHandledObject) null);
        this.dxfObjectReference_4 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        value?.vmethod_2((IDxfHandledObject) this);
      }
    }

    internal void method_10(DxfEntityCollection value)
    {
      if (this.dxfEntityCollection_0 == value)
        return;
      if (this.dxfEntityCollection_0 != null)
        this.Deactivate();
      this.dxfEntityCollection_0 = value;
      if (this.dxfEntityCollection_0 != null)
      {
        this.method_11();
        foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) this.dxfEntityCollection_0)
          this.method_16(entity);
      }
      this.OnEntitiesChanged((EventArgs) null);
    }

    internal void method_11()
    {
      this.dxfEntityCollection_0.Added += new ItemEventHandler<DxfEntity>(this.method_14);
      this.dxfEntityCollection_0.Set += new ItemSetEventHandler<DxfEntity>(this.method_13);
      this.dxfEntityCollection_0.Removed += new ItemEventHandler<DxfEntity>(this.method_15);
    }

    internal void Deactivate()
    {
      this.dxfEntityCollection_0.Added -= new ItemEventHandler<DxfEntity>(this.method_14);
      this.dxfEntityCollection_0.Set -= new ItemSetEventHandler<DxfEntity>(this.method_13);
      this.dxfEntityCollection_0.Removed -= new ItemEventHandler<DxfEntity>(this.method_15);
    }

    internal override void vmethod_1(Class1070 context)
    {
      if (this.IsExternalReference && this.Model.Header.AcadVersion < DxfVersion.Dxf15)
      {
        if (this.IsExternalReferenceUnloaded)
        {
          if (this.ExtensionDictionary == null)
            this.ExtensionDictionary = new DxfDictionary();
          if (!this.ExtensionDictionary.Entries.Contains("ACAD_UNLOAD"))
            this.ExtensionDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("ACAD_UNLOAD", (DxfObject) new DxfIdBuffer()));
        }
        else if (this.ExtensionDictionary != null && this.ExtensionDictionary.Entries.Contains("ACAD_UNLOAD"))
          this.ExtensionDictionary.Entries.Remove(this.ExtensionDictionary.Entries.GetFirst("ACAD_UNLOAD"));
      }
      base.vmethod_1(context);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfEntity>) this.dxfEntityCollection_0)
        dxfHandledObject.vmethod_1(context);
    }

    internal bool method_12()
    {
      bool flag = false;
      foreach (DxfEntity dxfEntity in (DxfHandledObjectCollection<DxfEntity>) this.dxfEntityCollection_0)
      {
        DxfAttributeDefinition attributeDefinition = dxfEntity as DxfAttributeDefinition;
        if (attributeDefinition != null && (attributeDefinition.Flags & AttributeFlags.Constant) == AttributeFlags.None)
        {
          flag = true;
          break;
        }
      }
      return flag;
    }

    private void method_13(object sender, int index, DxfEntity oldItem, DxfEntity newItem)
    {
      this.method_17(oldItem);
      this.method_16(newItem);
      this.OnEntitiesChanged((EventArgs) null);
    }

    private void method_14(object sender, int index, DxfEntity item)
    {
      this.method_16(item);
      this.OnEntitiesChanged((EventArgs) null);
    }

    private void method_15(object sender, int index, DxfEntity item)
    {
      this.method_17(item);
      this.OnEntitiesChanged((EventArgs) null);
    }

    private void method_16(DxfEntity entity)
    {
      if (this.Layout != null)
        this.Layout.method_10(entity);
      else
        entity.vmethod_2((IDxfHandledObject) this);
    }

    private void method_17(DxfEntity item)
    {
      item.vmethod_2((IDxfHandledObject) null);
    }

    internal void DrawInternal(DxfInsert.Interface46 drawHandler, bool applyBlockBaseTransformation)
    {
      bool flag1 = true;
      DxfModel model;
      if (this.IsExternalReference && !string.IsNullOrEmpty(this.string_2) && drawHandler.InsertCellDrawContext.Model.ExternalReferences.TryGetValue(this.string_2, out model))
      {
        DrawContext drawContext = drawHandler.InsertCellDrawContext;
        bool flag2 = false;
        while (drawContext.Model != model)
        {
          drawContext = drawContext.ParentContext;
          if (drawContext == null)
            goto label_5;
        }
        flag2 = true;
label_5:
        flag1 = false;
        if (!flag2)
          drawHandler.Draw(this, model);
      }
      if (!flag1 || this.dxfEntityCollection_0.Count < 1)
        return;
      drawHandler.imethod_2(applyBlockBaseTransformation ? this.BaseTransformation : Matrix4D.Identity);
      foreach (DxfEntity entity in (IEnumerable<DxfEntity>) this.GetEntitiesInDrawingOrder(drawHandler.InsertCellDrawContext.Config.UseSortEntsTables))
        drawHandler.imethod_3(entity);
    }

    internal class Class751 : ICloneBuilder
    {
      private DxfBlock dxfBlock_0;
      private DxfBlock dxfBlock_1;

      public Class751(DxfBlock from, DxfBlock to)
      {
        this.dxfBlock_0 = from;
        this.dxfBlock_1 = to;
      }

      public void ResolveReferences(CloneContext cloneContext)
      {
        if (this.dxfBlock_0.Layout != null)
        {
          DxfLayout dxfLayout1;
          if (!cloneContext.TargetModel.Layouts.TryGetValue(this.dxfBlock_0.Layout.Name, out dxfLayout1))
          {
            switch (cloneContext.ReferenceResolutionType)
            {
              case ReferenceResolutionType.IgnoreMissing:
                dxfLayout1 = (DxfLayout) null;
                break;
              case ReferenceResolutionType.CloneMissing:
                DxfLayout dxfLayout2 = (DxfLayout) this.dxfBlock_0.Layout.Clone(cloneContext);
                if (!cloneContext.CloneExact)
                  cloneContext.TargetModel.Layouts.Add(dxfLayout2);
                dxfLayout1 = dxfLayout2;
                break;
              case ReferenceResolutionType.FailOnMissing:
                throw new DxfException(string.Format("Could not copy block record, did not find layout with name {0}", (object) this.dxfBlock_0.Layout.Name));
            }
          }
          this.dxfBlock_1.Layout = dxfLayout1;
        }
        foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfEntity>) this.dxfBlock_0.dxfEntityCollection_0)
          this.dxfBlock_1.dxfEntityCollection_0.Add((DxfEntity) dxfHandledObject.Clone(cloneContext));
      }
    }

    internal class Class752
    {
      private string string_0;
      private Dictionary<string, DxfModel> dictionary_0;

      public Class752(
        string searchDirectory,
        Dictionary<string, DxfModel> loadedExternalReferences)
      {
        this.string_0 = searchDirectory;
        this.dictionary_0 = loadedExternalReferences;
      }

      public DxfModel method_0(DxfBlock block)
      {
        DxfModel dxfModel1 = (DxfModel) null;
        if (File.Exists(block.ExternalReference))
        {
          dxfModel1 = CadReader.Read(block.ExternalReference);
        }
        else
        {
          string str;
          if (Path.IsPathRooted(block.ExternalReference))
          {
            str = Path.Combine(this.string_0, Path.GetFileName(block.ExternalReference));
          }
          else
          {
            str = Path.Combine(this.string_0, block.ExternalReference);
            if (!File.Exists(str))
              str = Path.Combine(this.string_0, Path.GetFileName(block.ExternalReference));
          }
          foreach (DxfModel dxfModel2 in this.dictionary_0.Values)
          {
            if (dxfModel2.Filename == str)
            {
              dxfModel1 = dxfModel2;
              break;
            }
          }
          if (dxfModel1 == null && File.Exists(str))
            dxfModel1 = CadReader.Read(str);
        }
        return dxfModel1;
      }
    }

    public delegate DxfModel GetExternalReferenceDelegate(DxfBlock block);
  }
}
