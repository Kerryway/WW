// Decompiled with JetBrains decompiler
// Type: ns2.Class374
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns3;
using ns6;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Tables;
using WW.Collections.Generic;

namespace ns2
{
  internal abstract class Class374
  {
    private readonly Dictionary<ulong, Class450> dictionary_0 = new Dictionary<ulong, Class450>();
    private readonly Dictionary<DxfHandledObject, Class450> dictionary_1 = new Dictionary<DxfHandledObject, Class450>();
    private readonly LinkedList<Class450> linkedList_0 = new LinkedList<Class450>();
    private readonly Class619 class619_0 = new Class619();
    private readonly LinkedList<Delegate11> linkedList_1 = new LinkedList<Delegate11>();
    private List<Interface10> list_0 = new List<Interface10>();
    private readonly List<Class318> list_1 = new List<Class318>();
    private readonly List<Class288> list_2 = new List<Class288>();
    private readonly List<Class262> list_3 = new List<Class262>();
    private readonly List<Class332> list_4 = new List<Class332>();
    private readonly Dictionary<DxfCellStyleMap, Class264> dictionary_2 = new Dictionary<DxfCellStyleMap, Class264>();
    private readonly List<DxfLayout> list_5 = new List<DxfLayout>();
    private readonly List<Class308> list_6 = new List<Class308>();
    private List<Class316> list_7 = new List<Class316>();
    private string string_17 = string.Empty;
    private string string_18 = string.Empty;
    private readonly DxfModel dxfModel_0;
    private bool bool_0;
    private readonly DxfMessageCollection dxfMessageCollection_0;
    private Class319<DxfAppId> class319_0;
    private Class322 class322_0;
    private Class321 class321_0;
    private int int_0;
    private readonly Class739 class739_0;
    private ulong ulong_0;
    private ulong ulong_1;
    private ulong ulong_2;
    private ulong ulong_3;
    private ulong ulong_4;
    private ulong ulong_5;
    private ulong ulong_6;
    private string string_0;
    private ulong ulong_7;
    private string string_1;
    private ulong ulong_8;
    private string string_2;
    private ulong ulong_9;
    private string string_3;
    private ulong ulong_10;
    private string string_4;
    private ulong ulong_11;
    private string string_5;
    private ulong ulong_12;
    private string string_6;
    private ulong ulong_13;
    private string string_7;
    private ulong ulong_14;
    private string string_8;
    private ulong ulong_15;
    private string string_9;
    private ulong ulong_16;
    private string string_10;
    private ulong ulong_17;
    private string string_11;
    private ulong ulong_18;
    private string string_12;
    private ulong ulong_19;
    private string string_13;
    private ulong ulong_20;
    private string string_14;
    private ulong ulong_21;
    private string string_15;
    private ulong ulong_22;
    private string string_16;
    private ulong ulong_23;
    private ulong ulong_24;
    private ulong ulong_25;
    private ulong ulong_26;
    private ulong ulong_27;
    private DxfVersion dxfVersion_0;
    private bool bool_1;
    private bool bool_2;
    private bool bool_3;
    private bool bool_4;
    private bool bool_5;
    private bool bool_6;
    private Class741 class741_0;

    protected Class374(DxfModel model, DxfMessageCollection messages)
    {
      this.dxfModel_0 = model;
      this.dxfMessageCollection_0 = messages;
      this.class739_0 = new Class739(model);
    }

    public DxfModel Model
    {
      get
      {
        return this.dxfModel_0;
      }
    }

    public bool LoadUnknownObjects
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

    public abstract FileFormat FileFormat { get; }

    public DxfMessageCollection Messages
    {
      get
      {
        return this.dxfMessageCollection_0;
      }
    }

    public Class741 DataStore
    {
      get
      {
        return this.class741_0;
      }
      set
      {
        this.class741_0 = value;
      }
    }

    public Dictionary<ulong, Class450> HandleToObjectInfo
    {
      get
      {
        return this.dictionary_0;
      }
    }

    public ICollection<Class450> HandledObjects
    {
      get
      {
        return (ICollection<Class450>) this.linkedList_0;
      }
    }

    public Class619 ObjectBuilders
    {
      get
      {
        return this.class619_0;
      }
    }

    public LinkedList<Delegate11> ObjectBuilders2
    {
      get
      {
        return this.linkedList_1;
      }
    }

    public List<Class318> BlockBuilders
    {
      get
      {
        return this.list_1;
      }
    }

    public Class319<DxfAppId> AppIdTableBuilder
    {
      get
      {
        return this.class319_0;
      }
      set
      {
        this.class319_0 = value;
      }
    }

    public Class322 BlockRecordTableBuilder
    {
      get
      {
        return this.class322_0;
      }
      set
      {
        this.class322_0 = value;
      }
    }

    public List<Class288> BlockBeginBuilders
    {
      get
      {
        return this.list_2;
      }
    }

    public List<Class262> DictionaryBuilders
    {
      get
      {
        return this.list_3;
      }
    }

    public List<Class332> DictionaryEntryBuilders
    {
      get
      {
        return this.list_4;
      }
    }

    public Dictionary<DxfCellStyleMap, Class264> CellStyleMapBuilders
    {
      get
      {
        return this.dictionary_2;
      }
    }

    public List<DxfLayout> Layouts
    {
      get
      {
        return this.list_5;
      }
    }

    public List<Class308> ViewportBuilders
    {
      get
      {
        return this.list_6;
      }
    }

    public Class321 ViewportEntityHeaderControlBuilder
    {
      get
      {
        return this.class321_0;
      }
      set
      {
        this.class321_0 = value;
      }
    }

    public List<Class316> ViewportEntityHeaderBuilders
    {
      get
      {
        return this.list_7;
      }
    }

    public Class739 ObjectCollectionResolver
    {
      get
      {
        return this.class739_0;
      }
    }

    public ulong CurrentViewportHandle
    {
      get
      {
        return this.ulong_1;
      }
      set
      {
        this.ulong_1 = value;
      }
    }

    public ulong PaperSpaceBlockRecordHandle
    {
      get
      {
        return this.ulong_2;
      }
      set
      {
        this.ulong_2 = value;
      }
    }

    public ulong ModelSpaceBlockRecordHandle
    {
      get
      {
        return this.ulong_3;
      }
      set
      {
        this.ulong_3 = value;
      }
    }

    public ulong ByLayerLineTypeHandle
    {
      get
      {
        return this.ulong_4;
      }
      set
      {
        this.ulong_4 = value;
      }
    }

    public ulong ByBlockLineTypeHandle
    {
      get
      {
        return this.ulong_5;
      }
      set
      {
        this.ulong_5 = value;
      }
    }

    public ulong ContinuousLineTypeHandle
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

    public string DimensionStyleArrowBlockName
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public ulong DimensionStyleArrowBlockHandle
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

    public string DimensionStyleFirstArrowBlockName
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

    public ulong DimensionStyleFirstArrowBlockHandle
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

    public string DimensionStyleSecondArrowBlockName
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

    public ulong DimensionStyleSecondArrowBlockHandle
    {
      get
      {
        return this.ulong_9;
      }
      set
      {
        this.ulong_9 = value;
      }
    }

    public string DimStyleDimensionLineLineTypeName
    {
      get
      {
        return this.string_3;
      }
      set
      {
        this.string_3 = value;
      }
    }

    public ulong DimStyleDimensionLineLineTypeHandle
    {
      get
      {
        return this.ulong_10;
      }
      set
      {
        this.ulong_10 = value;
      }
    }

    public string DimStyleFirstExtensionLineLineTypeName
    {
      get
      {
        return this.string_4;
      }
      set
      {
        this.string_4 = value;
      }
    }

    public ulong DimStyleFirstExtensionLineLineTypeHandle
    {
      get
      {
        return this.ulong_11;
      }
      set
      {
        this.ulong_11 = value;
      }
    }

    public string DimStyleSecondExtensionLineLineTypeName
    {
      get
      {
        return this.string_5;
      }
      set
      {
        this.string_5 = value;
      }
    }

    public ulong DimStyleSecondExtensionLineLineTypeHandle
    {
      get
      {
        return this.ulong_12;
      }
      set
      {
        this.ulong_12 = value;
      }
    }

    public string DimensionStyleLeaderArrowBlockName
    {
      get
      {
        return this.string_6;
      }
      set
      {
        this.string_6 = value;
      }
    }

    public ulong DimensionStyleLeaderArrowBlockHandle
    {
      get
      {
        return this.ulong_13;
      }
      set
      {
        this.ulong_13 = value;
      }
    }

    public string DimensionStyleTextStyleName
    {
      get
      {
        return this.string_7;
      }
      set
      {
        this.string_7 = value;
      }
    }

    public ulong DimensionStyleTextStyleHandle
    {
      get
      {
        return this.ulong_14;
      }
      set
      {
        this.ulong_14 = value;
      }
    }

    public string CurrentLayerName
    {
      get
      {
        return this.string_8;
      }
      set
      {
        this.string_8 = value;
      }
    }

    public ulong CurrentLayerHandle
    {
      get
      {
        return this.ulong_15;
      }
      set
      {
        this.ulong_15 = value;
      }
    }

    public string TextStyleName
    {
      get
      {
        return this.string_9;
      }
      set
      {
        this.string_9 = value;
      }
    }

    public ulong TextStyleHandle
    {
      get
      {
        return this.ulong_16;
      }
      set
      {
        this.ulong_16 = value;
      }
    }

    public string CurrentEntityLineTypeName
    {
      get
      {
        return this.string_10;
      }
      set
      {
        this.string_10 = value;
      }
    }

    public ulong CurrentEntityLineTypeHandle
    {
      get
      {
        return this.ulong_17;
      }
      set
      {
        this.ulong_17 = value;
      }
    }

    public string CurrentDimensionStyleName
    {
      get
      {
        return this.string_11;
      }
      set
      {
        this.string_11 = value;
      }
    }

    public ulong CurrentDimensionStyleHandle
    {
      get
      {
        return this.ulong_18;
      }
      set
      {
        this.ulong_18 = value;
      }
    }

    public string CurrentMultilineStyleName
    {
      get
      {
        return this.string_12;
      }
      set
      {
        this.string_12 = value;
      }
    }

    public ulong CurrentMultilineStyleHandle
    {
      get
      {
        return this.ulong_19;
      }
      set
      {
        this.ulong_19 = value;
      }
    }

    public string UcsName
    {
      get
      {
        return this.string_13;
      }
      set
      {
        this.string_13 = value;
      }
    }

    public ulong UcsHandle
    {
      get
      {
        return this.ulong_20;
      }
      set
      {
        this.ulong_20 = value;
      }
    }

    public string PaperSpaceUcsName
    {
      get
      {
        return this.string_14;
      }
      set
      {
        this.string_14 = value;
      }
    }

    public ulong PaperSpaceUcsHandle
    {
      get
      {
        return this.ulong_21;
      }
      set
      {
        this.ulong_21 = value;
      }
    }

    public string UcsBaseName
    {
      get
      {
        return this.string_15;
      }
      set
      {
        this.string_15 = value;
      }
    }

    public ulong UcsBaseHandle
    {
      get
      {
        return this.ulong_22;
      }
      set
      {
        this.ulong_22 = value;
      }
    }

    public string PaperSpaceUcsBaseName
    {
      get
      {
        return this.string_16;
      }
      set
      {
        this.string_16 = value;
      }
    }

    public ulong PaperSpaceUcsBaseHandle
    {
      get
      {
        return this.ulong_23;
      }
      set
      {
        this.ulong_23 = value;
      }
    }

    public ulong LayoutsDictionaryHandle
    {
      get
      {
        return this.ulong_24;
      }
      set
      {
        this.ulong_24 = value;
      }
    }

    public ulong DragVSHandle
    {
      get
      {
        return this.ulong_25;
      }
      set
      {
        this.ulong_25 = value;
      }
    }

    public ulong InterfereObjectStyleHandle
    {
      get
      {
        return this.ulong_26;
      }
      set
      {
        this.ulong_26 = value;
      }
    }

    public ulong InterfereViewportStyleHandle
    {
      get
      {
        return this.ulong_26;
      }
      set
      {
        this.ulong_26 = value;
      }
    }

    public string PaperUcsOrthographicReferenceName
    {
      get
      {
        return this.string_17;
      }
      set
      {
        this.string_17 = value;
      }
    }

    public string UcsOrthographicReferenceName
    {
      get
      {
        return this.string_18;
      }
      set
      {
        this.string_18 = value;
      }
    }

    public DxfVersion Version
    {
      get
      {
        return this.dxfVersion_0;
      }
    }

    public bool IsVersion13Or14
    {
      get
      {
        return this.bool_1;
      }
    }

    public bool IsVersion15
    {
      get
      {
        return this.bool_3;
      }
    }

    public bool IsVersion15OrLater
    {
      get
      {
        return this.bool_4;
      }
    }

    public bool IsVersion18OrLater
    {
      get
      {
        return this.bool_5;
      }
    }

    public bool IsVersion21OrLater
    {
      get
      {
        return this.bool_6;
      }
    }

    public bool IsVersion13c3OrLater
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

    public void method_0(DxfVersion version)
    {
      this.dxfVersion_0 = version;
      this.bool_1 = version >= DxfVersion.Dxf13 && version <= DxfVersion.Dxf14;
      this.bool_3 = version == DxfVersion.Dxf15;
      this.bool_4 = version >= DxfVersion.Dxf15;
      this.bool_5 = version >= DxfVersion.Dxf18;
      this.bool_6 = version >= DxfVersion.Dxf21;
    }

    public void method_1(Class259 builder)
    {
      this.method_2(new Class450(builder.HandledObject, builder));
    }

    public void method_2(Class450 handledObjectInfo)
    {
      ulong handle = handledObjectInfo.HandledObject.Handle;
      if (handle != 0UL)
      {
        this.dictionary_0[handle] = handledObjectInfo;
        if (handle > this.ulong_0)
          this.ulong_0 = handle;
      }
      this.dictionary_1[handledObjectInfo.HandledObject] = handledObjectInfo;
      this.linkedList_0.AddLast(handledObjectInfo);
    }

    public void Remove(DxfHandledObject handledObject)
    {
      Class450 class450;
      if (!this.dictionary_1.TryGetValue(handledObject, out class450))
        return;
      if (class450.ObjectBuilder != null && class450.ObjectBuilder.ListNode != null)
      {
        class450.ObjectBuilder.ListNode.List.Remove(class450.ObjectBuilder.ListNode);
        class450.ObjectBuilder.ListNode = (LinkedListNode<Class259>) null;
      }
      this.dictionary_1.Remove(handledObject);
      if (handledObject.Handle == 0UL)
        return;
      this.dictionary_0.Remove(handledObject.Handle);
    }

    public DxfHandledObject method_3(ulong handle)
    {
      DxfHandledObject dxfHandledObject = (DxfHandledObject) null;
      Class450 class450;
      if (this.dictionary_0.TryGetValue(handle, out class450))
        dxfHandledObject = class450.HandledObject;
      return dxfHandledObject;
    }

    public T method_4<T>(ulong handle) where T : DxfHandledObject
    {
      Class450 class450;
      if (this.dictionary_0.TryGetValue(handle, out class450))
      {
        DxfHandledObject handledObject = class450.HandledObject;
        if (handledObject is T)
          return (T) handledObject;
        this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.WrongType, Severity.Warning, "ExpectedType", (object) typeof (T))
        {
          Parameters = {
            {
              "ObjectType",
              (object) handledObject.GetType()
            },
            {
              "Object",
              (object) handledObject
            }
          }
        });
      }
      else
        this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.UnresolvedReference, Severity.Warning, "Handle", (object) handle));
      return default (T);
    }

    public Interface10 method_5(ulong handle)
    {
      Interface10 nterface10 = (Interface10) null;
      Class450 class450;
      if (this.dictionary_0.TryGetValue(handle, out class450))
        nterface10 = (Interface10) class450.ObjectBuilder;
      return nterface10;
    }

    public Class285 method_6(ulong handle)
    {
      Interface10 nterface10 = this.method_5(handle);
      Class285 class285 = nterface10 as Class285;
      if (class285 == null && nterface10 != null)
      {
        DxfMessage dxfMessage = new DxfMessage(DxfStatus.WrongType, Severity.Warning, "ExpectedType", (object) typeof (DxfEntity));
        Class259 class259 = nterface10 as Class259;
        if (class259 != null)
        {
          DxfHandledObject handledObject = class259.HandledObject;
          dxfMessage.Parameters.Add("ObjectType", (object) handledObject.GetType());
          dxfMessage.Parameters.Add("Object", (object) handledObject);
        }
        this.dxfMessageCollection_0.Add(dxfMessage);
      }
      return class285;
    }

    public Class285 method_7(Class285 entityBuilder)
    {
      Class285 class285 = (Class285) null;
      if (entityBuilder != null)
      {
        if (entityBuilder.NextHandle.HasValue)
        {
          if (entityBuilder.NextHandle.Value != 0UL)
            class285 = this.method_6(entityBuilder.NextHandle.Value);
        }
        else
          class285 = this.method_6(entityBuilder.HandledObject.Handle + 1UL);
      }
      return class285;
    }

    public Class450 method_8(ulong handle)
    {
      Class450 class450 = (Class450) null;
      this.dictionary_0.TryGetValue(handle, out class450);
      return class450;
    }

    private static void smethod_0(
      DxfInsert insert,
      List<List<DxfAnnotationScaleObjectContextData>> attributeData)
    {
      int index = 0;
      foreach (DxfHandledObject attribute in (IEnumerable<DxfAttribute>) insert.Attributes)
      {
        DxfDictionary dxfDictionary = DxfAnnotationScaleObjectContextData.smethod_7(attribute, false);
        if (attributeData.Count <= index)
          attributeData.Add(new List<DxfAnnotationScaleObjectContextData>());
        if (dxfDictionary != null)
        {
          using (IEnumerator<DxfAttributeObjectContextData> enumerator = dxfDictionary.Entries.Select<IDictionaryEntry, DxfAttributeObjectContextData>((Func<IDictionaryEntry, DxfAttributeObjectContextData>) (e => (DxfAttributeObjectContextData) e.Value)).GetEnumerator())
          {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            Class374.Class377 class377 = new Class374.Class377();
            while (enumerator.MoveNext())
            {
              // ISSUE: reference to a compiler-generated field
              class377.dxfAttributeObjectContextData_0 = enumerator.Current;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated method
              if (class377.dxfAttributeObjectContextData_0.Scale != null && !attributeData[index].Any<DxfAnnotationScaleObjectContextData>(new Func<DxfAnnotationScaleObjectContextData, bool>(class377.method_0)))
              {
                // ISSUE: reference to a compiler-generated field
                attributeData[index].Add((DxfAnnotationScaleObjectContextData) class377.dxfAttributeObjectContextData_0);
                // ISSUE: reference to a compiler-generated field
                class377.dxfAttributeObjectContextData_0.IsDefault = attributeData[index].Count == 1;
                // ISSUE: reference to a compiler-generated field
                if (class377.dxfAttributeObjectContextData_0.Mtext != null)
                {
                  // ISSUE: reference to a compiler-generated field
                  class377.dxfAttributeObjectContextData_0.Mtext.IsDefault = attributeData[index].Count == 1;
                }
              }
            }
          }
          ++index;
        }
      }
    }

    private static void smethod_1(
      DxfInsert insert,
      List<List<DxfAnnotationScaleObjectContextData>> attributeData)
    {
      int index = 0;
      foreach (DxfAttribute attribute in (IEnumerable<DxfAttribute>) insert.Attributes)
      {
        if (index >= attributeData.Count)
          break;
        if (attributeData[index].Count != 0)
        {
          attribute.IsAnnotative = true;
          DxfDictionary dxfDictionary = DxfAnnotationScaleObjectContextData.smethod_7((DxfHandledObject) attribute, true);
          dxfDictionary.Entries.Clear();
          foreach (DxfAnnotationScaleObjectContextData objectContextData in attributeData[index])
            dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("*A", (DxfObject) objectContextData));
          ++index;
        }
      }
    }

    public void method_9()
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Class374.Class378 class378 = new Class374.Class378();
      DxfXRecord dxfXrecord = this.Model.DictionaryRoot.Entries.GetFirst("ACDB_RECOMPOSE_DATA").Value as DxfXRecord;
      if (dxfXrecord == null)
        return;
      // ISSUE: reference to a compiler-generated field
      class378.cloneContext_0 = new CloneContext(this.dxfModel_0, this.dxfModel_0, ReferenceResolutionType.CloneMissing);
      foreach (DxfXRecordValue dxfXrecordValue in (List<DxfXRecordValue>) dxfXrecord.Values)
      {
        if (dxfXrecordValue.Code == (short) 330)
        {
          DxfHandledObject dxfHandledObject = (DxfHandledObject) dxfXrecordValue.Value;
          if (dxfHandledObject is DxfInsert)
          {
            DxfInsert dxfInsert = (DxfInsert) dxfHandledObject;
            if (DxfScale.smethod_3((DxfHandledObject) dxfInsert) != null)
            {
              DxfEntity dxfEntity = (DxfEntity) null;
              DxfDictionary dxfDictionary1 = (DxfDictionary) null;
              List<List<DxfAnnotationScaleObjectContextData>> attributeData = new List<List<DxfAnnotationScaleObjectContextData>>();
              DxfBlock block = dxfInsert.Block;
              foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) block.Entities)
              {
                if (dxfEntity == null)
                {
                  if (entity is IAnnotative)
                  {
                    DxfDictionary dxfDictionary2 = DxfAnnotationScaleObjectContextData.smethod_6((DxfHandledObject) entity);
                    if (dxfDictionary2 != null)
                    {
                      // ISSUE: reference to a compiler-generated method
                      foreach (DxfScale dxfScale in dxfDictionary2.Entries.Select<IDictionaryEntry, DxfScale>((Func<IDictionaryEntry, DxfScale>) (data => ((DxfAnnotationScaleObjectContextData) data.Value).Scale)).Where<DxfScale>(new Func<DxfScale, bool>(class378.method_0)))
                      {
                        // ISSUE: reference to a compiler-generated field
                        class378.cloneContext_0.RegisterClone((IGraphCloneable) dxfScale, (IGraphCloneable) dxfScale);
                      }
                    }
                    // ISSUE: reference to a compiler-generated field
                    dxfEntity = (DxfEntity) entity.Clone(class378.cloneContext_0);
                    dxfEntity.SetHandle(dxfHandledObject.Handle);
                    dxfEntity.vmethod_2(dxfHandledObject.OwnerObjectSoftReference);
                    dxfDictionary1 = DxfAnnotationScaleObjectContextData.smethod_6((DxfHandledObject) dxfEntity);
                    dxfDictionary1.Entries.Clear();
                    ((IAnnotative) dxfEntity).IsAnnotative = true;
                    DxfAnnotationScaleObjectContextData.smethod_2((DxfHandledObject) dxfEntity);
                  }
                  else
                    break;
                }
                else if (dxfEntity.GetType() != entity.GetType())
                  continue;
                DxfDictionary dxfDictionary3 = DxfAnnotationScaleObjectContextData.smethod_7((DxfHandledObject) entity, false);
                if (dxfDictionary3 != null && dxfDictionary3.Entries.Count != 0)
                {
                  DxfAnnotationScaleObjectContextData objectContextData = dxfDictionary3.Entries[0].Value as DxfAnnotationScaleObjectContextData;
                  if (objectContextData != null)
                  {
                    dxfDictionary1.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("*A", (DxfObject) objectContextData));
                    objectContextData.vmethod_2((IDxfHandledObject) dxfDictionary1);
                  }
                  if (entity is DxfInsert)
                    Class374.smethod_0((DxfInsert) entity, attributeData);
                }
              }
              if (dxfEntity != null)
              {
                DxfObjectReference.GetReference((IDxfHandledObject) dxfHandledObject).Value = (IDxfHandledObject) dxfEntity;
                if (dxfDictionary1.Entries.Count > 0)
                  ((DxfObjectContextData) dxfDictionary1.Entries[0].Value).IsDefault = true;
                if (dxfEntity is DxfInsert)
                {
                  foreach (DxfAttributeBase attribute in (IEnumerable<DxfAttribute>) ((DxfInsertBase) dxfEntity).Attributes)
                    attribute.method_19();
                  Class374.smethod_1((DxfInsert) dxfEntity, attributeData);
                }
                this.dxfModel_0.AnonymousBlocks.Remove(block);
              }
            }
            else
            {
              DxfExtendedData extendedData;
              if (dxfInsert.ExtendedDataCollection.TryGetValue(this.dxfModel_0, "AcadAnnotativeAttributeDecomposition", out extendedData))
              {
                DxfEntity dxfEntity = (DxfEntity) null;
                List<List<DxfAnnotationScaleObjectContextData>> attributeData = new List<List<DxfAnnotationScaleObjectContextData>>();
                DxfBlock block = dxfInsert.Block;
                foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) block.Entities)
                {
                  if (entity is DxfInsert)
                  {
                    if (dxfEntity == null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      dxfEntity = (DxfEntity) entity.Clone(class378.cloneContext_0);
                      dxfEntity.SetHandle(dxfHandledObject.Handle);
                      dxfEntity.vmethod_2(dxfHandledObject.OwnerObjectSoftReference);
                    }
                    Class374.smethod_0((DxfInsert) entity, attributeData);
                  }
                }
                if (dxfEntity != null)
                {
                  foreach (DxfAttributeBase attribute in (IEnumerable<DxfAttribute>) ((DxfInsertBase) dxfEntity).Attributes)
                    attribute.method_19();
                  Class374.smethod_1((DxfInsert) dxfEntity, attributeData);
                  this.dxfModel_0.AnonymousBlocks.Remove(block);
                }
              }
            }
          }
        }
      }
      // ISSUE: reference to a compiler-generated field
      class378.cloneContext_0.ResolveReferences();
      foreach (DxfLayer layer in this.dxfModel_0.Layers.Where<DxfLayer>((Func<DxfLayer, bool>) (l => DxfScale.smethod_2(l) != null)).ToArray<DxfLayer>())
      {
        DxfLayer oldLayer;
        if (DxfScale.smethod_4(layer, out oldLayer) != null)
          this.dxfModel_0.Layers.Remove(layer);
      }
    }

    public void method_10(ulong handle, System.Action<DxfObjectReference> setObjectReference)
    {
      this.list_0.Add((Interface10) new Class329(handle, setObjectReference));
    }

    public void ResolveReferences()
    {
      foreach (Interface10 nterface10 in this.list_0)
        nterface10.ResolveReferences(this);
      this.vmethod_1();
      foreach (Class259 class259 in this.list_2)
        class259.ResolveReferences(this);
      if (this.class322_0 != null)
        this.class322_0.ResolveReferences(this);
      if (this.class319_0 != null)
        this.class319_0.ResolveReferences(this);
      this.dxfModel_0.method_22(true);
      if (this.ulong_4 != 0UL)
        this.dxfModel_0.method_18(this.method_4<DxfLineType>(this.ulong_4));
      if (this.ulong_5 != 0UL)
        this.dxfModel_0.method_19(this.method_4<DxfLineType>(this.ulong_5));
      if (this.ulong_6 != 0UL)
        this.dxfModel_0.method_20(this.method_4<DxfLineType>(this.ulong_6));
      if (this.dxfModel_0.DictionaryRoot == null)
      {
        Class259 class259 = (Class259) this.method_5(12UL);
        if (class259 != null && class259.OwnerHandle == 0UL)
        {
          DxfDictionary handledObject = class259.HandledObject as DxfDictionary;
          if (handledObject != null)
            this.dxfModel_0.DictionaryRoot = handledObject;
        }
      }
      foreach (Interface10 nterface10 in this.list_3)
        nterface10.ResolveReferences(this);
      foreach (Interface10 nterface10 in this.list_4)
        nterface10.ResolveReferences(this);
      foreach (Class259 class259 in this.list_3)
        ((DxfDictionary) class259.HandledObject).method_8();
      this.dxfModel_0.method_2();
      foreach (Interface10 nterface10 in this.class619_0)
        nterface10.ResolveReferences(this);
      foreach (Class318 blockBuilder in this.BlockBuilders)
        blockBuilder.method_2();
      foreach (Class259 class259 in this.list_6)
        class259.ResolveReferences(this);
      if (this.class321_0 != null)
        this.class321_0.ResolveReferences(this);
      foreach (Class259 class259 in this.list_7)
        class259.ResolveReferences(this);
      if (this.dxfVersion_0 <= DxfVersion.Dxf15)
        this.method_15();
      DxfDictionary dictionaryAcadLayout = this.dxfModel_0.DictionaryAcadLayout;
      List<DxfBlock> unusedPaperSpaceBlocks = new List<DxfBlock>();
      DxfBlock modelSpaceBlock = (DxfBlock) null;
      foreach (DxfBlock anonymousBlock in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfModel_0.AnonymousBlocks)
      {
        if (anonymousBlock.Layout == null)
          string.IsNullOrEmpty(anonymousBlock.Name);
        if (anonymousBlock.Name.StartsWith("*Paper_Space", StringComparison.InvariantCultureIgnoreCase))
          unusedPaperSpaceBlocks.Add(anonymousBlock);
        else if (string.Compare(anonymousBlock.Name, "*Model_Space", StringComparison.InvariantCultureIgnoreCase) == 0)
          modelSpaceBlock = anonymousBlock;
      }
      unusedPaperSpaceBlocks.Sort((Comparison<DxfBlock>) ((a, b) => -string.Compare(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)));
      if (dictionaryAcadLayout != null)
      {
        foreach (IDictionaryEntry entry in (ActiveList<IDictionaryEntry>) dictionaryAcadLayout.Entries)
        {
          if (entry.Value != null)
          {
            DxfLayout layout = (DxfLayout) entry.Value;
            this.method_12(layout, modelSpaceBlock, unusedPaperSpaceBlocks);
            this.dxfModel_0.Layouts.Add(layout);
          }
        }
      }
      else
      {
        foreach (DxfLayout layout in this.list_5)
        {
          this.method_12(layout, modelSpaceBlock, unusedPaperSpaceBlocks);
          this.dxfModel_0.Layouts.Add(layout);
        }
      }
      this.vmethod_0();
      bool active;
      if (active = this.dxfModel_0.Active)
        this.dxfModel_0.Deactivate();
      if (active)
        this.dxfModel_0.method_33();
      this.dxfModel_0.Header.DimensionStyleOverrides.UpdateOverrideFlags();
      this.dxfModel_0.Header.HandleSeed = this.ulong_0 + 1UL;
      this.method_16();
      this.dxfModel_0.CreateDefaultObjects(false);
      DxfGroupCollection groups = this.dxfModel_0.Groups;
      foreach (DxfDictionaryEntry dxfDictionaryEntry in (IEnumerable<IDictionaryEntry>) new List<IDictionaryEntry>((IEnumerable<IDictionaryEntry>) this.dxfModel_0.DictionaryAcadGroup.Entries))
      {
        DxfGroup dxfGroup = dxfDictionaryEntry.Value as DxfGroup;
        if (dxfGroup != null)
        {
          if (!groups.Contains(dxfGroup.Name))
          {
            groups.Add(dxfGroup);
          }
          else
          {
            string name = dxfGroup.Name;
            string key;
            do
            {
              key = string.Format("AUDIT_{0}", (object) this.method_21());
            }
            while (groups.Contains(key));
            dxfGroup.Name = key;
            groups.Add(dxfGroup);
            this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.AuditRepairedDuplicateName, Severity.Warning)
            {
              Parameters = {
                {
                  "Class",
                  (object) "AcDbGroup"
                },
                {
                  "OriginalName",
                  (object) name
                },
                {
                  "RepairedName",
                  (object) dxfGroup.Name
                }
              }
            });
          }
        }
      }
      this.vmethod_2();
      this.method_14();
      this.method_20();
      this.method_11();
      this.dxfModel_0.SummaryInfo.method_1(this.dxfModel_0);
      this.dxfModel_0.Repair((IList<DxfMessage>) this.dxfMessageCollection_0);
    }

    private void method_11()
    {
      foreach (Delegate11 delegate11 in this.linkedList_1)
        delegate11(this);
    }

    private void method_12(
      DxfLayout layout,
      DxfBlock modelSpaceBlock,
      List<DxfBlock> unusedPaperSpaceBlocks)
    {
      if (layout.OwnerBlock != null)
        return;
      if (string.Compare(layout.Name, "Model", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        if (modelSpaceBlock == null)
          return;
        layout.OwnerBlock = modelSpaceBlock;
      }
      else
      {
        if (unusedPaperSpaceBlocks.Count <= 0)
          return;
        layout.OwnerBlock = unusedPaperSpaceBlocks[unusedPaperSpaceBlocks.Count - 1];
        unusedPaperSpaceBlocks.RemoveAt(unusedPaperSpaceBlocks.Count - 1);
      }
    }

    public void method_13()
    {
      foreach (Class259 class259 in this.class619_0.Where<Class259>((Func<Class259, bool>) (builder => builder != null)))
        class259.HandledObject.vmethod_10(this.dxfModel_0);
    }

    protected abstract void vmethod_0();

    protected virtual void vmethod_1()
    {
      foreach (Class259 blockBuilder in this.BlockBuilders)
        blockBuilder.ResolveReferences(this);
    }

    private void method_14()
    {
    }

    private void method_15()
    {
      if (this.class321_0 == null || this.class321_0.TableRecordHandles.Count <= 1)
        return;
      for (int index = this.list_7.Count - 1; index >= 0; --index)
      {
        if (!this.class321_0.TableRecordHandles.Contains(this.list_7[index].HandledObject.Handle))
          this.list_7.RemoveAt(index);
      }
      List<Class316> class316List = new List<Class316>();
      for (int index = this.list_7.Count - 1; index >= 0; --index)
      {
        Class316 class316 = this.list_7[index];
        if (((DxfViewportEntityHeader) class316.HandledObject).Viewport == null)
        {
          this.list_7.RemoveAt(index);
          class316List.Add(class316);
        }
      }
      if (this.ulong_1 != 0UL)
      {
        Class316 class316 = (Class316) this.method_5(this.ulong_1);
        if (class316 != null)
        {
          class316List.Add(class316);
          this.list_7.Remove(class316);
          while (class316.NextViewportHeaderHandle != 0UL && (long) class316.NextViewportHeaderHandle != (long) class316.HandledObject.Handle)
          {
            class316 = (Class316) this.method_5(class316.NextViewportHeaderHandle);
            if (class316 != null)
            {
              class316List.Add(class316);
              this.list_7.Remove(class316);
            }
            else
              break;
          }
        }
      }
      class316List.AddRange((IEnumerable<Class316>) this.list_7);
      this.list_7 = class316List;
    }

    protected abstract void vmethod_2();

    private void method_16()
    {
      DxfDimensionStyleOverrides dimensionStyleOverrides = this.dxfModel_0.Header.DimensionStyleOverrides;
      if (this.ulong_7 != 0UL)
      {
        DxfBlock dxfBlock = this.method_4<DxfBlock>(this.ulong_7);
        dimensionStyleOverrides.ArrowBlock = dxfBlock;
      }
      else if (!string.IsNullOrEmpty(this.string_0))
        dimensionStyleOverrides.ArrowBlock = this.dxfModel_0.GetBlockWithName("_" + this.string_0);
      if (this.ulong_8 != 0UL)
      {
        DxfBlock dxfBlock = this.method_4<DxfBlock>(this.ulong_8);
        dimensionStyleOverrides.FirstArrowBlock = dxfBlock;
      }
      else if (!string.IsNullOrEmpty(this.string_1))
        dimensionStyleOverrides.FirstArrowBlock = this.dxfModel_0.GetBlockWithName("_" + this.string_1);
      if (this.ulong_9 != 0UL)
      {
        DxfBlock dxfBlock = this.method_4<DxfBlock>(this.ulong_9);
        dimensionStyleOverrides.SecondArrowBlock = dxfBlock;
      }
      else if (!string.IsNullOrEmpty(this.string_2))
        dimensionStyleOverrides.SecondArrowBlock = this.dxfModel_0.GetBlockWithName("_" + this.string_2);
      if (this.ulong_10 != 0UL)
      {
        DxfLineType dxfLineType = this.method_4<DxfLineType>(this.ulong_10);
        dimensionStyleOverrides.DimensionLineLineType = dxfLineType;
      }
      else if (!string.IsNullOrEmpty(this.string_3))
        dimensionStyleOverrides.DimensionLineLineType = this.dxfModel_0.GetLineTypeWithName(this.string_3);
      if (this.ulong_11 != 0UL)
      {
        DxfLineType dxfLineType = this.method_4<DxfLineType>(this.ulong_11);
        dimensionStyleOverrides.FirstExtensionLineLineType = dxfLineType;
      }
      else if (!string.IsNullOrEmpty(this.string_4))
        dimensionStyleOverrides.FirstExtensionLineLineType = this.dxfModel_0.GetLineTypeWithName(this.string_4);
      if (this.ulong_12 != 0UL)
      {
        DxfLineType dxfLineType = this.method_4<DxfLineType>(this.ulong_12);
        dimensionStyleOverrides.SecondExtensionLineLineType = dxfLineType;
      }
      else if (!string.IsNullOrEmpty(this.string_5))
        dimensionStyleOverrides.SecondExtensionLineLineType = this.dxfModel_0.GetLineTypeWithName(this.string_5);
      if (this.ulong_13 != 0UL)
      {
        DxfBlock dxfBlock = this.method_4<DxfBlock>(this.ulong_13);
        dimensionStyleOverrides.LeaderArrowBlock = dxfBlock;
      }
      else if (this.string_6 != null)
        dimensionStyleOverrides.LeaderArrowBlock = this.dxfModel_0.GetBlockWithName("_" + this.string_6);
      if (this.ulong_14 != 0UL)
      {
        DxfTextStyle dxfTextStyle = this.method_4<DxfTextStyle>(this.ulong_14);
        if (dxfTextStyle != null)
          dimensionStyleOverrides.TextStyle = dxfTextStyle;
      }
      else if (!string.IsNullOrEmpty(this.string_7))
      {
        DxfTextStyle textStyleWithName = this.dxfModel_0.GetTextStyleWithName(this.string_7);
        if (textStyleWithName != null)
          dimensionStyleOverrides.TextStyle = textStyleWithName;
      }
      if (this.ulong_15 != 0UL)
        this.dxfModel_0.Header.CurrentLayer = this.method_4<DxfLayer>(this.ulong_15);
      else if (!string.IsNullOrEmpty(this.string_8))
      {
        DxfLayer dxfLayer;
        this.dxfModel_0.Layers.TryGetValue(this.string_8, out dxfLayer);
        this.dxfModel_0.Header.CurrentLayer = dxfLayer;
      }
      else
        this.dxfModel_0.Header.CurrentLayer = (DxfLayer) null;
      if (this.ulong_16 != 0UL)
        this.dxfModel_0.Header.CurrentTextStyle = this.method_4<DxfTextStyle>(this.ulong_16);
      else if (!string.IsNullOrEmpty(this.string_9))
      {
        DxfTextStyle textStyle;
        this.dxfModel_0.TextStyles.TryGetValue(this.string_9, out textStyle);
        this.dxfModel_0.Header.CurrentTextStyle = textStyle;
      }
      else
        this.dxfModel_0.Header.CurrentTextStyle = (DxfTextStyle) null;
      if (this.ulong_17 != 0UL)
        this.dxfModel_0.Header.CurrentEntityLineType = this.method_4<DxfLineType>(this.ulong_17);
      else if (!string.IsNullOrEmpty(this.string_10))
      {
        DxfLineType dxfLineType;
        this.dxfModel_0.LineTypes.TryGetValue(this.string_10, out dxfLineType);
        this.dxfModel_0.Header.CurrentEntityLineType = dxfLineType;
      }
      else
        this.dxfModel_0.Header.CurrentEntityLineType = (DxfLineType) null;
      if (this.ulong_18 != 0UL)
      {
        DxfDimensionStyle dxfDimensionStyle = this.method_4<DxfDimensionStyle>(this.ulong_18);
        if (dxfDimensionStyle != null)
          this.dxfModel_0.Header.DimensionStyle = dxfDimensionStyle;
      }
      else if (!string.IsNullOrEmpty(this.string_11))
      {
        DxfDimensionStyle dxfDimensionStyle;
        if (this.dxfModel_0.DimensionStyles.TryGetValue(this.string_11, out dxfDimensionStyle))
          this.dxfModel_0.Header.DimensionStyle = dxfDimensionStyle;
      }
      else
        this.dxfModel_0.Header.DimensionStyle = this.dxfModel_0.CurrentDimensionStyle;
      this.dxfModel_0.Header.CurrentMultilineStyle = this.ulong_19 == 0UL ? (string.IsNullOrEmpty(this.string_12) ? (DxfMLineStyle) null : this.dxfModel_0.MLineStyles.Find(this.string_12)) : this.method_4<DxfMLineStyle>(this.ulong_19);
      if (this.ulong_20 != 0UL)
      {
        DxfUcs dxfUcs = this.method_4<DxfUcs>(this.ulong_20);
        if (dxfUcs != null)
          this.dxfModel_0.Header.Ucs = dxfUcs;
      }
      else
      {
        DxfUcs dxfUcs;
        if (!string.IsNullOrEmpty(this.string_13) && this.dxfModel_0.UcsCollection.TryGetValue(this.string_13, out dxfUcs))
          this.dxfModel_0.Header.Ucs = dxfUcs;
      }
      if (this.ulong_21 != 0UL)
      {
        DxfUcs dxfUcs = this.method_4<DxfUcs>(this.ulong_21);
        if (dxfUcs != null)
          this.dxfModel_0.Header.PaperSpaceUcs = dxfUcs;
      }
      else
      {
        DxfUcs dxfUcs;
        if (!string.IsNullOrEmpty(this.string_14) && this.dxfModel_0.UcsCollection.TryGetValue(this.string_14, out dxfUcs))
          this.dxfModel_0.Header.PaperSpaceUcs = dxfUcs;
      }
      if (this.ulong_22 != 0UL)
      {
        DxfUcs dxfUcs = this.method_4<DxfUcs>(this.ulong_22);
        if (dxfUcs != null)
          this.dxfModel_0.Header.UcsBase = dxfUcs;
      }
      else
      {
        DxfUcs dxfUcs;
        if (!string.IsNullOrEmpty(this.string_15) && this.dxfModel_0.UcsCollection.TryGetValue(this.string_15, out dxfUcs))
          this.dxfModel_0.Header.UcsBase = dxfUcs;
      }
      if (this.ulong_23 != 0UL)
      {
        DxfUcs dxfUcs = this.method_4<DxfUcs>(this.ulong_23);
        if (dxfUcs != null)
          this.dxfModel_0.Header.PaperSpaceUcsBase = dxfUcs;
      }
      else
      {
        DxfUcs dxfUcs;
        if (!string.IsNullOrEmpty(this.string_16) && this.dxfModel_0.UcsCollection.TryGetValue(this.string_16, out dxfUcs))
          this.dxfModel_0.Header.PaperSpaceUcsBase = dxfUcs;
      }
      this.dxfModel_0.Header.InterfereObjectStyle = this.ulong_26 != 0UL ? this.method_3(this.ulong_26) : this.method_17("Conceptual");
      this.dxfModel_0.Header.InterfereViewportStyle = this.ulong_27 != 0UL ? this.method_3(this.ulong_27) : this.method_17("3dWireframe");
      if (!string.IsNullOrEmpty(this.string_17))
        this.dxfModel_0.Header.PaperSpaceUcs.OrthographicReference = this.dxfModel_0.GetUcsWithName(this.string_17);
      if (!string.IsNullOrEmpty(this.string_18))
        this.dxfModel_0.Header.Ucs.OrthographicReference = this.dxfModel_0.GetUcsWithName(this.string_18);
      this.dxfModel_0.method_8();
    }

    private DxfHandledObject method_17(string styleName)
    {
      DxfDictionary dictionaryRoot = this.dxfModel_0.DictionaryRoot;
      if (dictionaryRoot != null)
      {
        IDictionaryEntry first1 = dictionaryRoot.Entries.GetFirst("ACAD_VISUALSTYLE");
        if (first1 != null)
        {
          DxfDictionary dxfDictionary = (DxfDictionary) first1.Value;
          if (dxfDictionary != null)
          {
            IDictionaryEntry first2 = dxfDictionary.Entries.GetFirst(styleName);
            if (first2 != null)
              return (DxfHandledObject) first2.Value;
          }
        }
      }
      return (DxfHandledObject) null;
    }

    private void method_18()
    {
      foreach (Class450 class450 in this.linkedList_0)
      {
        if (class450 != null)
        {
          string str1 = string.Empty;
          if (class450.HandledObject != null)
            str1 = str1 + class450.HandledObject.HandleString + ", " + class450.HandledObject.GetType().Name;
          Class285 objectBuilder = class450.ObjectBuilder as Class285;
          string str2;
          if (objectBuilder != null)
            str2 = str1 + ", " + objectBuilder.HandledObject.HandleString + ", entmode = " + objectBuilder.EntityMode.ToString() + ", " + (objectBuilder.PreviousHandle.HasValue ? "previous = " + objectBuilder.PreviousHandle.Value.ToString("X") + ", " : string.Empty) + (objectBuilder.NextHandle.HasValue ? "next = " + objectBuilder.NextHandle.Value.ToString("X") + ", " : string.Empty) + objectBuilder.Entity.ToString();
          else if (class450.ObjectBuilder.ObjectType != (short) 0)
            str2 = str1 + ", Unknown: object type = " + class450.ObjectBuilder.ObjectType.ToString();
          if (class450.ObjectBuilder != null)
            class450.ObjectBuilder.ToString();
        }
      }
    }

    public void method_19()
    {
      foreach (DxfLayout dxfLayout in this.list_5)
        dxfLayout.method_11();
    }

    private void method_20()
    {
      if (this.class741_0 == null)
        return;
      foreach (KeyValuePair<ulong, List<Stream>> keyValuePair in (Dictionary<ulong, List<Stream>>) this.class741_0.method_0(Enum53.const_2))
      {
        ulong key = keyValuePair.Key;
        Stream stream = keyValuePair.Value[0];
        DxfModelerGeometry dxfModelerGeometry = this.method_4<DxfModelerGeometry>(key);
        if (dxfModelerGeometry == null)
          this.Messages.Add(new DxfMessage(DxfStatus.UnresolvedReference, Severity.Warning, "MissedEntity", (object) key)
          {
            Parameters = {
              {
                "EntityHandle",
                (object) key
              }
            }
          });
        else if (!dxfModelerGeometry.method_13(stream))
          throw new Exception("ResolveDataStorage unable to restore ACIS data for the entity with the handle " + (object) key);
      }
      this.class741_0 = (Class741) null;
    }

    public int method_21()
    {
      return this.int_0++;
    }

    public void ResolveReferences(ICollection<Interface10> builders)
    {
      if (builders == null)
        return;
      foreach (Interface10 builder in (IEnumerable<Interface10>) builders)
        builder.ResolveReferences(this);
    }

    public WW.Math.Point2D method_22(DxfEntity entity, WW.Math.Point2D p)
    {
      if (double.IsNaN(p.X))
      {
        this.method_24(entity, p.X);
        p.X = 0.0;
      }
      if (double.IsNaN(p.Y))
      {
        this.method_24(entity, p.Y);
        p.Y = 0.0;
      }
      return p;
    }

    public double method_23(DxfEntity entity, double value)
    {
      if (double.IsNaN(value))
      {
        this.method_24(entity, value);
        value = 0.0;
      }
      return value;
    }

    private void method_24(DxfEntity entity, double value)
    {
      this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.InvalidDoubleSubstitutedWithZero, Severity.Warning, "target", (object) entity)
      {
        Parameters = {
          {
            nameof (value),
            (object) value
          }
        }
      });
    }
  }
}
