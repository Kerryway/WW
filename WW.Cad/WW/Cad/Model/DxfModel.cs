// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfModel
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns2;
using ns36;
using ns38;
using ns5;
using ns6;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Tables;
using WW.Collections.Generic;
using WW.Math;

namespace WW.Cad.Model
{
  public class DxfModel : IDxfHandledObject, IGraphCloneable, IDisposable, WW.ICloneable
  {
    private static readonly List<string> list_0 = new List<string>();
    private static string string_1 = "simplex.shx";
    private static string string_2 = "Arial";
    private SummaryInfo summaryInfo_0 = new SummaryInfo();
    private int int_0 = 1;
    private readonly DxfClassCollection dxfClassCollection_0 = new DxfClassCollection();
    private DxfEntityCollection dxfEntityCollection_0 = new DxfEntityCollection();
    private readonly FileDependencyCollection fileDependencyCollection_0 = new FileDependencyCollection();
    private readonly Dictionary<string, ShxFile> dictionary_1 = new Dictionary<string, ShxFile>();
    private DxfObjectReference dxfObjectReference_1 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_2 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_3 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_4 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_5 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_6 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_7 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_8 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_9 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_10 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_11 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_12 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_13 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_14 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_15 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_16 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_17 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_18 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_19 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_20 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_21 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_22 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_23 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_24 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_25 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_26 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_27 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_28 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_29 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_30 = DxfObjectReference.Null;
    private readonly DxfHandledObjectCollection<DxfObject> dxfHandledObjectCollection_0 = new DxfHandledObjectCollection<DxfObject>();
    private readonly DxfHandledObjectCollection<DxfEntity> dxfHandledObjectCollection_1 = new DxfHandledObjectCollection<DxfEntity>();
    private DxfObjectReference dxfObjectReference_31 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_32 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_33 = DxfObjectReference.Null;
    private readonly List<UnsupportedObject> list_1 = new List<UnsupportedObject>();
    private readonly DxfAppIdCollection dxfAppIdCollection_0 = new DxfAppIdCollection();
    private readonly DxfLayerCollection dxfLayerCollection_0 = new DxfLayerCollection();
    private readonly DxfBlockCollection dxfBlockCollection_0 = new DxfBlockCollection();
    private readonly DxfBlockCollection dxfBlockCollection_1 = new DxfBlockCollection();
    private readonly DxfTextStyleCollection dxfTextStyleCollection_0 = new DxfTextStyleCollection();
    private readonly DxfLineTypeCollection dxfLineTypeCollection_0 = new DxfLineTypeCollection();
    private readonly DxfUcsCollection dxfUcsCollection_0 = new DxfUcsCollection();
    private readonly DxfViewCollection dxfViewCollection_0 = new DxfViewCollection();
    private readonly DxfDimensionStyleCollection dxfDimensionStyleCollection_0 = new DxfDimensionStyleCollection();
    private readonly DxfVPortCollection dxfVPortCollection_0 = new DxfVPortCollection();
    private readonly Class28 class28_0 = new Class28();
    private DxfObjectReference dxfObjectReference_34 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_35 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_36 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_37 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_38 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_39 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_40 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_41 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_42 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_43 = DxfObjectReference.Null;
    private readonly DxfColorCollection dxfColorCollection_0 = new DxfColorCollection();
    private readonly DxfGroupCollection dxfGroupCollection_0 = new DxfGroupCollection();
    private readonly DxfScaleCollection dxfScaleCollection_0 = new DxfScaleCollection();
    private readonly DxfMLeaderStyleCollection dxfMLeaderStyleCollection_0 = new DxfMLeaderStyleCollection();
    private readonly DxfMLineStyleCollection dxfMLineStyleCollection_0 = new DxfMLineStyleCollection();
    private DxfLayoutCollection dxfLayoutCollection_0 = new DxfLayoutCollection();
    private DxfObjectReference dxfObjectReference_44 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_45 = DxfObjectReference.Null;
    private DxfImageDefCollection dxfImageDefCollection_0 = new DxfImageDefCollection();
    private readonly DxfTableStyleCollection dxfTableStyleCollection_0 = new DxfTableStyleCollection();
    private const string string_0 = "ACDB_RECOMPOSE_DATA";
    private DxfObjectReference dxfObjectReference_0;
    private string string_3;
    private readonly DxfHeader dxfHeader_0;
    private SecurityFlags securityFlags_0;
    private Dictionary<string, DxfModel> dictionary_0;
    private string[] string_4;
    private uint uint_0;
    private DxfFieldList dxfFieldList_0;
    private DxfPlotSettingsCollection dxfPlotSettingsCollection_0;
    private uint uint_1;
    private uint uint_2;
    private uint uint_3;
    private uint uint_4;
    private uint uint_5;
    private uint uint_6;
    private uint uint_7;
    private bool bool_0;

    public DxfModel()
      : this(DxfVersion.Dxf27)
    {
    }

    public DxfModel(DxfVersion dxfVersion)
      : this(dxfVersion, true)
    {
    }

    internal DxfModel(DxfVersion dxfVersion, bool createDefaultObjects)
    {
      Class809.smethod_0(Enum15.const_1);
      this.dxfObjectReference_0 = new DxfObjectReference((IDxfHandledObject) this);
      this.method_117();
      this.dxfHeader_0 = new DxfHeader(this);
      this.dxfHeader_0.AcadVersion = dxfVersion;
      this.method_35();
      this.method_33();
      if (createDefaultObjects)
        this.CreateDefaultObjects(true);
      this.dxfHeader_0.method_5(this);
    }

    public DxfModel(DxfModel templateModel)
    {
      this.dxfObjectReference_0 = new DxfObjectReference((IDxfHandledObject) this);
      DxfModel from = templateModel;
      this.string_3 = from.string_3;
      this.string_4 = from.string_4;
      this.dxfHeader_0 = new DxfHeader(this);
      this.dxfHeader_0.AcadVersion = templateModel.Header.AcadVersion;
      this.method_35();
      this.method_33();
      CloneContext cloneContext = new CloneContext(templateModel, this, ReferenceResolutionType.CloneMissing);
      cloneContext.CloneHeader = true;
      cloneContext.CloneExact = true;
      cloneContext.AllowDuplicateNames = true;
      cloneContext.AddDefaultReactorToDictionaryEntries = false;
      cloneContext.RegisterClone((IGraphCloneable) templateModel, (IGraphCloneable) this);
      this.method_9(true);
      this.method_103(from);
      this.method_104(from, cloneContext);
      this.method_106(from, cloneContext);
      this.method_105(from, cloneContext);
      this.method_108(from, cloneContext);
      this.dxfHeader_0.CopyFrom(from.dxfHeader_0, cloneContext);
      this.method_109(cloneContext);
      foreach (IGraphCloneable key in cloneContext.SourceToClonedObject.Keys)
      {
        DxfHandledObject dxfHandledObject1 = key as DxfHandledObject;
        if (dxfHandledObject1 != null)
        {
          DxfHandledObject dxfHandledObject2 = (DxfHandledObject) cloneContext.SourceToClonedObject[key];
          if (dxfHandledObject1.HasPersistentReactors)
          {
            foreach (DxfHandledObject persistentReactor in dxfHandledObject1.PersistentReactors)
            {
              if (cloneContext.SourceToClonedObject.ContainsKey((IGraphCloneable) persistentReactor))
              {
                DxfHandledObject reactor = (DxfHandledObject) persistentReactor.Clone(cloneContext);
                dxfHandledObject2.AddPersistentReactor(reactor);
              }
            }
          }
        }
      }
      DxfAttributeBase.class680_0.Visit(this);
    }

    public ulong Handle
    {
      get
      {
        return 0;
      }
    }

    public DxfObjectReference Reference
    {
      get
      {
        return this.dxfObjectReference_0;
      }
      set
      {
        this.dxfObjectReference_0 = value;
      }
    }

    public IDxfHandledObject OwnerObjectSoftReference
    {
      get
      {
        return (IDxfHandledObject) null;
      }
    }

    public string Filename
    {
      get
      {
        return this.string_3;
      }
      set
      {
        this.string_3 = value;
        this.method_117();
      }
    }

    public DxfHeader Header
    {
      get
      {
        return this.dxfHeader_0;
      }
    }

    public SummaryInfo SummaryInfo
    {
      get
      {
        return this.summaryInfo_0;
      }
    }

    public SecurityFlags SecurityFlags
    {
      get
      {
        return this.securityFlags_0;
      }
      set
      {
        this.securityFlags_0 = value;
      }
    }

    public int NumberOfSaves
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public DxfAppIdCollection AppIds
    {
      get
      {
        return this.dxfAppIdCollection_0;
      }
    }

    public DxfLayerCollection Layers
    {
      get
      {
        return this.dxfLayerCollection_0;
      }
    }

    public DxfLineTypeCollection LineTypes
    {
      get
      {
        return this.dxfLineTypeCollection_0;
      }
    }

    public DxfUcsCollection UcsCollection
    {
      get
      {
        return this.dxfUcsCollection_0;
      }
    }

    public DxfViewCollection Views
    {
      get
      {
        return this.dxfViewCollection_0;
      }
    }

    public DxfVPortCollection VPorts
    {
      get
      {
        return this.dxfVPortCollection_0;
      }
    }

    internal Class28 ViewportEntityHeaders
    {
      get
      {
        return this.class28_0;
      }
    }

    public DxfColorCollection Colors
    {
      get
      {
        return this.dxfColorCollection_0;
      }
    }

    public DxfFieldList FieldList
    {
      get
      {
        return this.dxfFieldList_0;
      }
      internal set
      {
        this.dxfFieldList_0 = value;
      }
    }

    public DxfGeoData GeoData
    {
      get
      {
        DxfGeoData dxfGeoData = (DxfGeoData) null;
        DxfBlock ownerBlock = this.ModelLayout.OwnerBlock;
        if (ownerBlock.ExtensionDictionary != null)
          dxfGeoData = ownerBlock.ExtensionDictionary.GetValueByName("ACAD_GEOGRAPHICDATA") as DxfGeoData;
        return dxfGeoData;
      }
      set
      {
        DxfBlock ownerBlock = this.ModelLayout.OwnerBlock;
        if (value == null)
        {
          if (ownerBlock.ExtensionDictionary == null)
            return;
          ownerBlock.ExtensionDictionary.Entries.RemoveAll("ACAD_GEOGRAPHICDATA");
          if (ownerBlock.ExtensionDictionary.Entries.Count != 0)
            return;
          ownerBlock.ExtensionDictionary = (DxfDictionary) null;
        }
        else
        {
          if (ownerBlock.ExtensionDictionary == null)
            ownerBlock.ExtensionDictionary = new DxfDictionary();
          else
            ownerBlock.ExtensionDictionary.Entries.RemoveAll("ACAD_GEOGRAPHICDATA");
          ownerBlock.ExtensionDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("ACAD_GEOGRAPHICDATA", (DxfObject) value));
        }
      }
    }

    public DxfGroupCollection Groups
    {
      get
      {
        return this.dxfGroupCollection_0;
      }
    }

    public DxfScaleCollection Scales
    {
      get
      {
        return this.dxfScaleCollection_0;
      }
    }

    public DxfMLeaderStyleCollection MLeaderStyles
    {
      get
      {
        return this.dxfMLeaderStyleCollection_0;
      }
    }

    public DxfMLineStyleCollection MLineStyles
    {
      get
      {
        return this.dxfMLineStyleCollection_0;
      }
    }

    public DxfPlotSettingsCollection PlotSettingsCollection
    {
      get
      {
        return this.dxfPlotSettingsCollection_0;
      }
    }

    public DxfLayoutCollection Layouts
    {
      get
      {
        return this.dxfLayoutCollection_0;
      }
    }

    public IList<DxfLayout> OrderedLayouts
    {
      get
      {
        List<DxfLayout> dxfLayoutList = new List<DxfLayout>((IEnumerable<DxfLayout>) this.dxfLayoutCollection_0);
        dxfLayoutList.Sort((Comparison<DxfLayout>) ((a, b) => MathUtil.Compare(a.TabOrder, b.TabOrder)));
        return (IList<DxfLayout>) dxfLayoutList.AsReadOnly();
      }
    }

    public DxfLayout ModelLayout
    {
      get
      {
        return (DxfLayout) this.dxfObjectReference_44.Value;
      }
      private set
      {
        this.dxfObjectReference_44 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfLayout ActiveLayout
    {
      get
      {
        return (DxfLayout) this.dxfObjectReference_45.Value;
      }
      set
      {
        this.dxfObjectReference_45 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        this.method_32();
        value?.method_14();
      }
    }

    public DxfImageDefCollection Images
    {
      get
      {
        return this.dxfImageDefCollection_0;
      }
    }

    public DxfTableStyleCollection TableStyles
    {
      get
      {
        return this.dxfTableStyleCollection_0;
      }
    }

    public DxfLineType ContinuousLineType
    {
      get
      {
        return (DxfLineType) this.dxfObjectReference_9.Value;
      }
      private set
      {
        this.dxfObjectReference_9 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfLineType ByBlockLineType
    {
      get
      {
        return (DxfLineType) this.dxfObjectReference_10.Value;
      }
      private set
      {
        this.dxfObjectReference_10 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfLineType ByLayerLineType
    {
      get
      {
        return (DxfLineType) this.dxfObjectReference_11.Value;
      }
      set
      {
        this.dxfObjectReference_11 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfMLeaderStyle DefaultMLeaderStyle
    {
      get
      {
        return (DxfMLeaderStyle) this.dxfObjectReference_12.Value;
      }
      set
      {
        this.dxfObjectReference_12 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfMLineStyle DefaultMLineStyle
    {
      get
      {
        return (DxfMLineStyle) this.dxfObjectReference_13.Value;
      }
      set
      {
        this.dxfObjectReference_13 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfLayer ZeroLayer
    {
      get
      {
        return (DxfLayer) this.dxfObjectReference_8.Value;
      }
      private set
      {
        this.dxfObjectReference_8 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfClassCollection Classes
    {
      get
      {
        return this.dxfClassCollection_0;
      }
    }

    public DxfEntityCollection Entities
    {
      get
      {
        return this.dxfEntityCollection_0;
      }
    }

    public DxfBlockCollection Blocks
    {
      get
      {
        return this.dxfBlockCollection_0;
      }
    }

    public DxfBlockCollection AnonymousBlocks
    {
      get
      {
        return this.dxfBlockCollection_1;
      }
    }

    public DxfTextStyleCollection TextStyles
    {
      get
      {
        return this.dxfTextStyleCollection_0;
      }
    }

    public DxfTextStyle DefaultTextStyle
    {
      get
      {
        return (DxfTextStyle) this.dxfObjectReference_14.Value;
      }
      private set
      {
        this.dxfObjectReference_14 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    [Obsolete("Property is renamed to CurrentDimensionStyle.")]
    public DxfDimensionStyle DefaultDimensionStyle
    {
      get
      {
        return this.CurrentDimensionStyle;
      }
    }

    public DxfDimensionStyle CurrentDimensionStyle
    {
      get
      {
        return this.dxfHeader_0.DimensionStyle;
      }
      set
      {
        this.dxfHeader_0.DimensionStyle = value;
      }
    }

    public DxfTableStyle DefaultTableStyle
    {
      get
      {
        return (DxfTableStyle) this.dxfObjectReference_15.Value;
      }
      private set
      {
        this.dxfObjectReference_15 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfDictionary DictionaryRoot
    {
      get
      {
        return (DxfDictionary) this.dxfObjectReference_16.Value;
      }
      internal set
      {
        this.dxfObjectReference_16 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        value?.vmethod_2((IDxfHandledObject) this);
      }
    }

    public DxfDictionary DictionaryVisualStyle
    {
      get
      {
        return (DxfDictionary) this.dxfObjectReference_29.Value;
      }
    }

    private DxfXRecord XRecordRecomposeData
    {
      get
      {
        return (DxfXRecord) this.dxfObjectReference_30.Value;
      }
      set
      {
        this.dxfObjectReference_30 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    private DxfDictionary DictionaryAcDbVariable
    {
      get
      {
        return (DxfDictionary) this.dxfObjectReference_31.Value;
      }
      set
      {
        this.dxfObjectReference_31 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfDimensionStyleCollection DimensionStyles
    {
      get
      {
        return this.dxfDimensionStyleCollection_0;
      }
    }

    public List<UnsupportedObject> UnsupportedObjects
    {
      get
      {
        return this.list_1;
      }
    }

    public Dictionary<string, DxfModel> ExternalReferences
    {
      get
      {
        if (this.dictionary_0 == null)
          this.dictionary_0 = new Dictionary<string, DxfModel>();
        return this.dictionary_0;
      }
    }

    public FileDependencyCollection FileDependencies
    {
      get
      {
        return this.fileDependencyCollection_0;
      }
    }

    public string[] ShxLookupDirectories
    {
      get
      {
        return (string[]) this.string_4.Clone();
      }
    }

    public void UpdateOleItemCounter(uint value)
    {
      if (this.uint_0 >= value)
        return;
      this.uint_0 = value;
    }

    public uint UniqueOleItemCounter()
    {
      return ++this.uint_0;
    }

    public DxfLayer GetLayerWithName(string name)
    {
      DxfLayer dxfLayer;
      this.dxfLayerCollection_0.TryGetValue(name, out dxfLayer);
      return dxfLayer;
    }

    public DxfLayer GetLayer(DxfEntity entity)
    {
      return entity.Layer ?? this.ZeroLayer;
    }

    public DxfBlock GetBlockWithName(string name)
    {
      DxfBlock dxfBlock1;
      if (!this.dxfBlockCollection_0.TryGetValue(name, out dxfBlock1))
      {
        foreach (DxfBlock dxfBlock2 in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfBlockCollection_1)
        {
          if (dxfBlock2.Name == name)
          {
            dxfBlock1 = dxfBlock2;
            return dxfBlock1;
          }
        }
      }
      return dxfBlock1;
    }

    public DxfTextStyle GetTextStyleWithName(string name)
    {
      DxfTextStyle textStyle;
      if (!this.dxfTextStyleCollection_0.TryGetValue(name, out textStyle))
        this.dxfTextStyleCollection_0.TryGetValue(name.ToUpperInvariant(), out textStyle);
      return textStyle;
    }

    public DxfUcs GetUcsWithName(string name)
    {
      DxfUcs dxfUcs;
      this.dxfUcsCollection_0.TryGetValue(name, out dxfUcs);
      return dxfUcs;
    }

    public DxfView GetViewWithName(string name)
    {
      DxfView dxfView;
      this.dxfViewCollection_0.TryGetValue(name, out dxfView);
      return dxfView;
    }

    public DxfLineType GetLineTypeWithName(string name)
    {
      DxfLineType dxfLineType;
      this.dxfLineTypeCollection_0.TryGetValue(name, out dxfLineType);
      return dxfLineType;
    }

    public DxfDimensionStyle GetDimensionStyleWithName(string name)
    {
      DxfDimensionStyle dxfDimensionStyle;
      this.dxfDimensionStyleCollection_0.TryGetValue(name, out dxfDimensionStyle);
      return dxfDimensionStyle;
    }

    public void CreateDefaultObjects(bool useFixedHandles)
    {
      this.method_33();
      this.method_9(useFixedHandles);
      this.method_10(useFixedHandles);
      this.dxfObjectReference_6 = DxfBlock.smethod_2(this, useFixedHandles, true).Reference;
      DxfBlock dxfBlock1;
      this.dxfBlockCollection_1.TryGetValue("*Paper_Space", out dxfBlock1);
      if (dxfBlock1 == null)
        dxfBlock1 = DxfBlock.smethod_4(this, false, "*Paper_Space", 0UL, 0UL, 0UL, true, true);
      this.dxfObjectReference_7 = dxfBlock1.Reference;
      DxfDictionary dxfDictionary = this.DictionaryRoot;
      if (dxfDictionary == null)
        this.DictionaryRoot = dxfDictionary = DxfDictionary.smethod_2(useFixedHandles);
      this.method_2();
      if (this.DictionaryAcadColor == null)
      {
        string dictionaryName;
        this.DictionaryAcadColor = DxfDictionary.smethod_3(out dictionaryName);
        dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dictionaryName, (DxfObject) this.DictionaryAcadColor));
        foreach (DxfColor dxfColor in (DxfHandledObjectCollection<DxfColor>) this.dxfColorCollection_0)
          this.DictionaryAcadColor.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dxfColor.Color.method_0(), (DxfObject) dxfColor));
      }
      if (this.dxfFieldList_0 == null)
      {
        this.dxfFieldList_0 = new DxfFieldList();
        dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("ACAD_FIELDLIST", (DxfObject) this.dxfFieldList_0));
      }
      if (this.DictionaryAcadGroup == null)
      {
        string dictionaryName;
        this.DictionaryAcadGroup = DxfDictionary.smethod_4(useFixedHandles, out dictionaryName);
        dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dictionaryName, (DxfObject) this.DictionaryAcadGroup));
        foreach (DxfGroup dxfGroup in (KeyedDxfHandledObjectCollection<string, DxfGroup>) this.dxfGroupCollection_0)
          this.DictionaryAcadGroup.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dxfGroup.Name, (DxfObject) dxfGroup));
      }
      if (this.DictionaryAcadImage == null)
      {
        string dictionaryName;
        this.DictionaryAcadImage = DxfDictionary.smethod_5(useFixedHandles, out dictionaryName);
        dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dictionaryName, (DxfObject) this.DictionaryAcadImage));
        foreach (DxfImageDef dxfImageDef in (DxfHandledObjectCollection<DxfImageDef>) this.dxfImageDefCollection_0)
          this.DictionaryAcadImage.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dxfImageDef.Filename, (DxfObject) dxfImageDef));
      }
      if (this.DictionaryAcadLayout == null)
      {
        string dictionaryName;
        this.DictionaryAcadLayout = DxfDictionary.smethod_6(useFixedHandles, out dictionaryName);
        dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dictionaryName, (DxfObject) this.DictionaryAcadLayout));
        foreach (DxfLayout dxfLayout in (KeyedDxfHandledObjectCollection<string, DxfLayout>) this.dxfLayoutCollection_0)
          this.DictionaryAcadLayout.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dxfLayout.Name, (DxfObject) dxfLayout));
      }
      if (this.DictionaryAcadMaterial == null)
      {
        string dictionaryName;
        this.DictionaryAcadMaterial = DxfDictionary.smethod_7(useFixedHandles, out dictionaryName);
        dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dictionaryName, (DxfObject) this.DictionaryAcadMaterial));
      }
      if (this.DictionaryAcadMLeaderStyle == null)
      {
        string dictionaryName;
        this.DictionaryAcadMLeaderStyle = DxfDictionary.smethod_8(useFixedHandles, out dictionaryName);
        dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dictionaryName, (DxfObject) this.DictionaryAcadMLeaderStyle));
        foreach (DxfMLeaderStyle dxfMleaderStyle in (DxfHandledObjectCollection<DxfMLeaderStyle>) this.dxfMLeaderStyleCollection_0)
          this.DictionaryAcadMLeaderStyle.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dxfMleaderStyle.Name, (DxfObject) dxfMleaderStyle));
      }
      if ((this.DefaultMLeaderStyle = this.dxfMLeaderStyleCollection_0.Find("Standard")) == null)
      {
        this.DefaultMLeaderStyle = DxfMLeaderStyle.smethod_2(this, useFixedHandles);
        this.dxfMLeaderStyleCollection_0.Add(this.DefaultMLeaderStyle);
      }
      if (this.DictionaryAcadMLineStyle == null)
      {
        string dictionaryName;
        this.DictionaryAcadMLineStyle = DxfDictionary.smethod_9(useFixedHandles, out dictionaryName);
        dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dictionaryName, (DxfObject) this.DictionaryAcadMLineStyle));
        foreach (DxfMLineStyle dxfMlineStyle in (DxfHandledObjectCollection<DxfMLineStyle>) this.dxfMLineStyleCollection_0)
          this.DictionaryAcadMLineStyle.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dxfMlineStyle.Name, (DxfObject) dxfMlineStyle));
      }
      if ((this.DefaultMLineStyle = this.dxfMLineStyleCollection_0.Find("STANDARD")) == null)
      {
        this.DefaultMLineStyle = DxfMLineStyle.smethod_2(this, useFixedHandles);
        this.dxfMLineStyleCollection_0.Add(this.DefaultMLineStyle);
      }
      if (this.DictionaryAcadPlotSettings == null)
      {
        string dictionaryName;
        this.DictionaryAcadPlotSettings = DxfDictionary.smethod_11(useFixedHandles, out dictionaryName);
        dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dictionaryName, (DxfObject) this.DictionaryAcadPlotSettings));
        this.dxfPlotSettingsCollection_0 = new DxfPlotSettingsCollection(this.DictionaryAcadPlotSettings.Entries);
      }
      if (this.DictionaryAcadPlotStyleName == null)
      {
        string dictionaryName;
        this.DictionaryAcadPlotStyleName = DxfDictionaryWithDefault.smethod_14(useFixedHandles, out dictionaryName);
        dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dictionaryName, (DxfObject) this.DictionaryAcadPlotStyleName));
        this.PlotStyle = DxfPlaceHolder.smethod_2(useFixedHandles);
        this.DictionaryAcadPlotStyleName.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("Normal", (DxfObject) this.PlotStyle));
        this.DictionaryAcadPlotStyleName.DefaultEntry = (DxfObject) this.PlotStyle;
      }
      if (this.DictionaryAcadTableStyle == null)
      {
        string dictionaryName;
        this.DictionaryAcadTableStyle = DxfDictionary.smethod_10(useFixedHandles, out dictionaryName);
        dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dictionaryName, (DxfObject) this.DictionaryAcadTableStyle));
        foreach (DxfTableStyle dxfTableStyle in (KeyedDxfHandledObjectCollection<string, DxfTableStyle>) this.dxfTableStyleCollection_0)
          this.DictionaryAcadTableStyle.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dxfTableStyle.Name, (DxfObject) dxfTableStyle));
      }
      if (this.XRecordRecomposeData == null)
      {
        this.XRecordRecomposeData = new DxfXRecord();
        this.XRecordRecomposeData.DuplicateRecordCloningFlag = DuplicateRecordCloningFlag.KeepExisting;
        this.XRecordRecomposeData.Values.Add(new DxfXRecordValue((short) 90, (object) 1));
        dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("ACDB_RECOMPOSE_DATA", (DxfObject) this.XRecordRecomposeData));
      }
      if (this.DictionaryAcDbVariable == null)
      {
        string dictionaryName;
        this.DictionaryAcDbVariable = DxfDictionary.smethod_12(useFixedHandles, out dictionaryName);
        dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dictionaryName, (DxfObject) this.DictionaryAcDbVariable));
        this.DictionaryAcDbVariable.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("DIMASSOC", (DxfObject) new DxfDictionaryVariable("1")));
        this.DictionaryAcDbVariable.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("HIDETEXT", (DxfObject) new DxfDictionaryVariable("2")));
      }
      if (this.DictionaryAcadVisualStyle == null)
      {
        string dictionaryName;
        this.DictionaryAcadVisualStyle = DxfDictionary.smethod_13(useFixedHandles, out dictionaryName);
        dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(dictionaryName, (DxfObject) this.DictionaryAcadVisualStyle));
      }
      dxfDictionary.vmethod_2((IDxfHandledObject) this);
      this.method_1(useFixedHandles);
      DxfBlock dxfBlock2 = (DxfBlock) null;
      if (this.dxfBlockCollection_1.TryGetValue("*Paper_Space", out dxfBlock2) && dxfBlock2 != null)
        this.method_0(dxfBlock2.Layout);
      DxfTableStyle dxfTableStyle1;
      if (!this.dxfTableStyleCollection_0.TryGetValue("Standard", out dxfTableStyle1))
      {
        dxfTableStyle1 = new DxfTableStyle("Standard");
        this.dxfTableStyleCollection_0.Add(dxfTableStyle1);
      }
      this.DefaultTableStyle = dxfTableStyle1;
    }

    private void method_0(DxfLayout layout)
    {
      this.dxfObjectReference_45 = DxfObjectReference.GetReference((IDxfHandledObject) layout);
    }

    private void method_1(bool useFixedHandles)
    {
      DxfLayout dxfLayout = (DxfLayout) null;
      DxfBlock paperSpaceBlock = this.PaperSpaceBlock;
      if (paperSpaceBlock != null && paperSpaceBlock.Layout != null)
        dxfLayout = paperSpaceBlock.Layout;
      if (dxfLayout == null)
        DxfLayout.smethod_3(this, this.dxfBlockCollection_1["*Paper_Space"], useFixedHandles);
      DxfBlock dxfBlock;
      if (this.dxfBlockCollection_1.TryGetValue("*Model_Space", out dxfBlock) && dxfBlock.Layout != null)
        this.ModelLayout = dxfBlock.Layout;
      if (this.ModelLayout != null)
        DxfLayout.smethod_6(this, this.ModelLayout);
      else
        this.ModelLayout = DxfLayout.smethod_5(this, this.dxfBlockCollection_1["*Model_Space"], useFixedHandles);
    }

    internal void method_2()
    {
      DxfDictionary dictionaryRoot = this.DictionaryRoot;
      if (dictionaryRoot == null)
        return;
      if (this.DictionaryAcadColor == null)
        this.DictionaryAcadColor = DxfModel.smethod_5(dictionaryRoot.Entries.GetFirst("ACAD_COLOR"));
      if (this.dxfFieldList_0 == null)
        this.dxfFieldList_0 = (DxfFieldList) DxfModel.GetValue(dictionaryRoot.Entries.GetFirst("ACAD_FIELDLIST"));
      if (this.DictionaryAcadGroup == null)
        this.DictionaryAcadGroup = DxfModel.smethod_5(dictionaryRoot.Entries.GetFirst("ACAD_GROUP"));
      if (this.DictionaryAcadLayout == null)
        this.DictionaryAcadLayout = DxfModel.smethod_5(dictionaryRoot.Entries.GetFirst("ACAD_LAYOUT"));
      if (this.DictionaryAcadMaterial == null)
        this.DictionaryAcadMaterial = DxfModel.smethod_5(dictionaryRoot.Entries.GetFirst("ACAD_MATERIAL"));
      if (this.DictionaryAcadMLeaderStyle == null)
        this.DictionaryAcadMLeaderStyle = DxfModel.smethod_5(dictionaryRoot.Entries.GetFirst("ACAD_MLEADERSTYLE"));
      if (this.DictionaryAcadMLineStyle == null)
        this.DictionaryAcadMLineStyle = DxfModel.smethod_5(dictionaryRoot.Entries.GetFirst("ACAD_MLINESTYLE"));
      if (this.DictionaryAcadImage == null)
        this.DictionaryAcadImage = DxfModel.smethod_5(dictionaryRoot.Entries.GetFirst("ACAD_IMAGE_DICT"));
      if (this.DictionaryAcadTableStyle == null)
        this.DictionaryAcadTableStyle = DxfModel.smethod_5(dictionaryRoot.Entries.GetFirst("ACAD_TABLESTYLE"));
      if (this.DictionaryAcadPlotSettings == null)
      {
        this.DictionaryAcadPlotSettings = DxfModel.smethod_5(dictionaryRoot.Entries.GetFirst("ACAD_PLOTSETTINGS"));
        if (this.DictionaryAcadPlotSettings != null)
          this.dxfPlotSettingsCollection_0 = new DxfPlotSettingsCollection(this.DictionaryAcadPlotSettings.Entries);
      }
      if (this.DictionaryAcadPlotStyleName == null)
        this.DictionaryAcadPlotStyleName = DxfModel.smethod_6(dictionaryRoot.Entries.GetFirst("ACAD_PLOTSTYLENAME"));
      if (this.DictionaryAcadPlotStyleName != null)
        this.PlotStyle = this.DictionaryAcadPlotStyleName.DefaultEntry as DxfPlaceHolder;
      if (this.XRecordRecomposeData == null)
        this.XRecordRecomposeData = DxfModel.smethod_7(dictionaryRoot.Entries.GetFirst("ACDB_RECOMPOSE_DATA"));
      if (this.DictionaryAcDbVariable == null)
        this.DictionaryAcDbVariable = DxfModel.smethod_5(dictionaryRoot.Entries.GetFirst("AcDbVariableDictionary"));
      if (this.DictionaryAcadScaleList == null)
      {
        this.DictionaryAcadScaleList = DxfModel.smethod_5(dictionaryRoot.Entries.GetFirst("ACAD_SCALELIST"));
        if (this.DictionaryAcadScaleList == null)
          this.method_4();
        this.method_3();
      }
      if (this.DictionaryAcadVisualStyle == null)
        this.DictionaryAcadVisualStyle = DxfModel.smethod_5(dictionaryRoot.Entries.GetFirst("ACAD_VISUALSTYLE"));
      if (this.XRecordDwgProps != null)
        return;
      this.XRecordDwgProps = DxfModel.smethod_7(dictionaryRoot.Entries.GetFirst("DWGPROPS"));
    }

    private void method_3()
    {
      this.dxfScaleCollection_0.Added -= new ItemEventHandler<DxfScale>(this.method_88);
      foreach (DxfScale dxfScale in this.DictionaryAcadScaleList.Entries.Select<IDictionaryEntry, DxfObject>((Func<IDictionaryEntry, DxfObject>) (e => e.Value)).OfType<DxfScale>())
        this.dxfScaleCollection_0.Add(dxfScale);
      this.dxfScaleCollection_0.Added += new ItemEventHandler<DxfScale>(this.method_88);
    }

    private void method_4()
    {
      this.DictionaryAcadScaleList = new DxfDictionary();
      if (this.DictionaryRoot == null)
        this.DictionaryRoot = DxfDictionary.smethod_2(false);
      this.DictionaryRoot.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("ACAD_SCALELIST", (DxfObject) this.DictionaryAcadScaleList));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("A0", (DxfObject) new DxfScale("1:1", 1.0, 1.0, false, true)));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("A1", (DxfObject) new DxfScale("1:2", 1.0, 2.0, false, false)));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("A2", (DxfObject) new DxfScale("1:4", 1.0, 4.0, false, false)));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("A3", (DxfObject) new DxfScale("1:5", 1.0, 5.0, false, false)));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("A4", (DxfObject) new DxfScale("1:8", 1.0, 8.0, false, false)));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("A5", (DxfObject) new DxfScale("1:10", 1.0, 10.0, false, false)));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("A6", (DxfObject) new DxfScale("1:16", 1.0, 16.0, false, false)));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("A7", (DxfObject) new DxfScale("1:20", 1.0, 20.0, false, false)));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("A8", (DxfObject) new DxfScale("1:30", 1.0, 30.0, false, false)));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("A9", (DxfObject) new DxfScale("1:40", 1.0, 40.0, false, false)));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("B0", (DxfObject) new DxfScale("1:50", 1.0, 50.0, false, false)));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("B1", (DxfObject) new DxfScale("1:100", 1.0, 100.0, false, false)));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("B2", (DxfObject) new DxfScale("2:1", 2.0, 1.0, false, false)));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("B3", (DxfObject) new DxfScale("4:1", 4.0, 1.0, false, false)));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("B4", (DxfObject) new DxfScale("8:1", 8.0, 1.0, false, false)));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("B5", (DxfObject) new DxfScale("10:1", 10.0, 1.0, false, false)));
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("B6", (DxfObject) new DxfScale("100:1", 100.0, 1.0, false, false)));
    }

    private string method_5(string name)
    {
      if (this.DictionaryAcDbVariable == null)
        return string.Empty;
      return ((DxfDictionaryVariable) this.DictionaryAcDbVariable.GetValueByName(name))?.Value;
    }

    private bool method_6(string name)
    {
      string str = this.method_5(name);
      if (!string.IsNullOrEmpty(str))
        return str != "0";
      return false;
    }

    private bool method_7(string name, bool defaultValue)
    {
      string str = this.method_5(name);
      if (str == null)
        return defaultValue;
      if (!string.IsNullOrEmpty(str))
        return str != "0";
      return false;
    }

    internal void method_8()
    {
      string name = this.method_5("CANNOSCALE");
      if (this.dxfScaleCollection_0.Count == 0)
      {
        this.method_4();
        this.method_3();
      }
      DxfScale scale = (DxfScale) null;
      if ((string.IsNullOrEmpty(name) || !this.dxfScaleCollection_0.TryGetValue(name, out scale)) && this.dxfScaleCollection_0.Count > 0)
        scale = this.dxfScaleCollection_0[0];
      this.dxfHeader_0.CurrentAnnotationScale = scale;
      this.dxfHeader_0.AnnotationsAlwaysVisible = this.method_7("ANNOALLVISIBLE", this.dxfHeader_0.AnnotationsAlwaysVisible);
      this.dxfHeader_0.AnnotativeDrawing = this.method_7("ANNOTATIVEDWG", this.dxfHeader_0.AnnotativeDrawing);
      this.dxfHeader_0.ModelSpaceAnnotationScalingEnabled = this.method_7("MSLTSCALE", this.dxfHeader_0.ModelSpaceAnnotationScalingEnabled);
      this.dxfHeader_0.PaperSpaceAnnotationScalingEnabled = this.method_7("PSLTSCALE", this.dxfHeader_0.PaperSpaceAnnotationScalingEnabled);
    }

    internal void method_9(bool useFixedHandles)
    {
      if (this.VPortTable == null)
      {
        this.VPortTable = new DxfHandledObject();
        if (useFixedHandles)
          this.VPortTable.SetHandle(8UL);
      }
      this.VPortTable.vmethod_2((IDxfHandledObject) this);
      if (this.LineTypeTable == null)
      {
        this.LineTypeTable = new DxfHandledObject();
        if (useFixedHandles)
          this.LineTypeTable.SetHandle(5UL);
      }
      this.LineTypeTable.vmethod_2((IDxfHandledObject) this);
      if (this.LayerTable == null)
      {
        this.LayerTable = new DxfHandledObject();
        if (useFixedHandles)
          this.LayerTable.SetHandle(2UL);
      }
      this.LayerTable.vmethod_2((IDxfHandledObject) this);
      if (this.TextStyleTable == null)
      {
        this.TextStyleTable = new DxfHandledObject();
        if (useFixedHandles)
          this.TextStyleTable.SetHandle(3UL);
      }
      this.TextStyleTable.vmethod_2((IDxfHandledObject) this);
      if (this.ViewTable == null)
      {
        this.ViewTable = new DxfHandledObject();
        if (useFixedHandles)
          this.ViewTable.SetHandle(6UL);
      }
      this.ViewTable.vmethod_2((IDxfHandledObject) this);
      if (this.UcsTable == null)
      {
        this.UcsTable = new DxfHandledObject();
        if (useFixedHandles)
          this.UcsTable.SetHandle(7UL);
      }
      this.UcsTable.vmethod_2((IDxfHandledObject) this);
      if (this.AppIdTable == null)
      {
        this.AppIdTable = new DxfHandledObject();
        if (useFixedHandles)
          this.AppIdTable.SetHandle(9UL);
      }
      this.AppIdTable.vmethod_2((IDxfHandledObject) this);
      if (this.DimStyleTable == null)
      {
        this.DimStyleTable = new DxfHandledObject();
        if (useFixedHandles)
          this.DimStyleTable.SetHandle(10UL);
      }
      this.DimStyleTable.vmethod_2((IDxfHandledObject) this);
      if (this.BlockRecordTable == null)
      {
        this.BlockRecordTable = new DxfHandledObject();
        if (useFixedHandles)
          this.BlockRecordTable.SetHandle(1UL);
      }
      this.BlockRecordTable.vmethod_2((IDxfHandledObject) this);
      if (this.ViewportEntityHeaderTable == null)
        this.ViewportEntityHeaderTable = new DxfHandledObject();
      this.ViewportEntityHeaderTable.vmethod_2((IDxfHandledObject) this);
    }

    internal void method_10(bool useFixedHandles)
    {
      DxfLineType dxfLineType1;
      if (!this.dxfLineTypeCollection_0.TryGetValue("Continuous", out dxfLineType1) && !this.dxfLineTypeCollection_0.TryGetValue("Continuous".ToUpperInvariant(), out dxfLineType1))
      {
        dxfLineType1 = DxfLineType.smethod_2(useFixedHandles);
        this.dxfLineTypeCollection_0.Add(dxfLineType1);
      }
      this.ContinuousLineType = dxfLineType1;
      DxfLineType dxfLineType2;
      if (!this.dxfLineTypeCollection_0.TryGetValue("ByBlock", out dxfLineType2) && !this.dxfLineTypeCollection_0.TryGetValue("ByBlock".ToUpperInvariant(), out dxfLineType2))
      {
        dxfLineType2 = DxfLineType.smethod_3(useFixedHandles);
        this.dxfLineTypeCollection_0.Add(dxfLineType2);
      }
      this.ByBlockLineType = dxfLineType2;
      DxfLineType dxfLineType3;
      if (!this.dxfLineTypeCollection_0.TryGetValue("ByLayer", out dxfLineType3) && !this.dxfLineTypeCollection_0.TryGetValue("ByLayer".ToUpperInvariant(), out dxfLineType3))
      {
        dxfLineType3 = DxfLineType.smethod_4(useFixedHandles);
        this.dxfLineTypeCollection_0.Add(dxfLineType3);
      }
      this.ByLayerLineType = dxfLineType3;
      DxfTextStyle textStyle;
      if (!this.dxfTextStyleCollection_0.TryGetValue("Standard", out textStyle) && !this.dxfTextStyleCollection_0.TryGetValue("Standard".ToUpperInvariant(), out textStyle))
      {
        textStyle = DxfTextStyle.smethod_3(useFixedHandles);
        this.dxfTextStyleCollection_0.Add(textStyle);
      }
      this.DefaultTextStyle = textStyle;
      if (this.CurrentDimensionStyle == null)
      {
        DxfDimensionStyle dxfDimensionStyle;
        if (!this.dxfDimensionStyleCollection_0.TryGetValue("Standard", out dxfDimensionStyle) && !this.dxfDimensionStyleCollection_0.TryGetValue("Standard".ToUpperInvariant(), out dxfDimensionStyle))
        {
          dxfDimensionStyle = new DxfDimensionStyle(this, "Standard");
          this.dxfDimensionStyleCollection_0.Add(dxfDimensionStyle);
        }
        this.CurrentDimensionStyle = dxfDimensionStyle;
      }
      DxfLayer dxfLayer;
      if (!this.dxfLayerCollection_0.TryGetValue("0", out dxfLayer))
      {
        dxfLayer = DxfLayer.smethod_2(this, useFixedHandles);
        this.dxfLayerCollection_0.Add(dxfLayer);
      }
      this.ZeroLayer = dxfLayer;
      this.method_22(useFixedHandles);
      this.method_23(useFixedHandles);
    }

    public void Draw(DrawContext.Wireframe context, IWireframeGraphicsFactory graphicsFactory)
    {
      foreach (DxfEntity sortedEntity in (IEnumerable<DxfEntity>) this.ModelLayout.GetSortedEntities())
        sortedEntity.Draw(context, graphicsFactory);
    }

    public void Draw(DrawContext.Wireframe context, IWireframeGraphicsFactory2 graphicsFactory)
    {
      foreach (DxfEntity sortedEntity in (IEnumerable<DxfEntity>) this.ModelLayout.GetSortedEntities())
        sortedEntity.Draw(context, graphicsFactory);
    }

    public void Draw(DrawContext.Surface context, ISurfaceGraphicsFactory graphicsFactory)
    {
      foreach (DxfEntity sortedEntity in (IEnumerable<DxfEntity>) this.ModelLayout.GetSortedEntities())
        sortedEntity.Draw(context, graphicsFactory);
    }

    public void Draw(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock graphicElementBlock)
    {
      foreach (DxfEntity sortedEntity in (IEnumerable<DxfEntity>) this.ModelLayout.GetSortedEntities())
        sortedEntity.Draw(context, graphics, graphicElementBlock);
    }

    public DxfEntity Import(
      DxfEntity entity,
      ReferenceResolutionType referenceResolutionType)
    {
      CloneContext cloneContext = new CloneContext(entity.Model, this, referenceResolutionType);
      return (DxfEntity) entity.Clone(cloneContext);
    }

    public bool Validate(out DxfMessage[] messages)
    {
      List<DxfMessage> dxfMessageList = new List<DxfMessage>();
      bool flag = true;
      if (!this.method_11((ICollection) this.dxfBlockCollection_0, (IList<DxfMessage>) dxfMessageList))
        flag = false;
      if (!this.method_11((ICollection) this.dxfBlockCollection_1, (IList<DxfMessage>) dxfMessageList))
        flag = false;
      if (!this.method_11((ICollection) this.dxfLayerCollection_0, (IList<DxfMessage>) dxfMessageList))
        flag = false;
      if (!this.method_11((ICollection) this.dxfLineTypeCollection_0, (IList<DxfMessage>) dxfMessageList))
        flag = false;
      if (!this.method_11((ICollection) this.dxfTextStyleCollection_0, (IList<DxfMessage>) dxfMessageList))
        flag = false;
      if (!this.method_11((ICollection) this.dxfDimensionStyleCollection_0, (IList<DxfMessage>) dxfMessageList))
        flag = false;
      if (!this.method_11((ICollection) this.dxfViewCollection_0, (IList<DxfMessage>) dxfMessageList))
        flag = false;
      if (!this.method_11((ICollection) this.dxfVPortCollection_0, (IList<DxfMessage>) dxfMessageList))
        flag = false;
      if (!this.method_11((ICollection) this.dxfUcsCollection_0, (IList<DxfMessage>) dxfMessageList))
        flag = false;
      if (!this.method_11((ICollection) this.dxfLayoutCollection_0, (IList<DxfMessage>) dxfMessageList))
        flag = false;
      if (!this.DictionaryRoot.Validate(this, (IList<DxfMessage>) dxfMessageList))
        flag = false;
      messages = dxfMessageList.ToArray();
      return flag;
    }

    private bool method_11(ICollection objects, IList<DxfMessage> messages)
    {
      bool flag = true;
      foreach (DxfHandledObject dxfHandledObject in (IEnumerable) objects)
      {
        if (!dxfHandledObject.Validate(this, messages))
          flag = false;
      }
      return flag;
    }

    public void SetHandles()
    {
      this.ExecuteForChildren(new Action(this.method_102));
    }

    public void CheckAndSetHandles()
    {
      DxfModel.Class981 class981 = new DxfModel.Class981();
      this.ExecuteForChildren(new Action(class981.method_0));
      this.dxfHeader_0.HandleSeed = System.Math.Max(this.dxfHeader_0.HandleSeed, class981.MaxHandle + 1UL);
      this.SetHandles();
    }

    public void ResetHandles()
    {
      this.ExecuteForChildren(new Action(this.ClearHandle));
      this.method_12();
      this.dxfHeader_0.HandleSeed = 39UL;
    }

    private void method_12()
    {
      this.SetHandle(this.BlockRecordTable, 1UL);
      this.SetHandle(this.LayerTable, 2UL);
      this.SetHandle(this.TextStyleTable, 3UL);
      this.SetHandle(this.LineTypeTable, 5UL);
      this.SetHandle(this.ViewTable, 6UL);
      this.SetHandle(this.UcsTable, 7UL);
      this.SetHandle(this.VPortTable, 8UL);
      this.SetHandle(this.AppIdTable, 9UL);
      this.SetHandle(this.DimStyleTable, 10UL);
      this.SetHandle((DxfHandledObject) this.DictionaryRoot, 12UL);
      this.SetHandle((DxfHandledObject) this.DictionaryAcadGroup, 13UL);
      this.SetHandle((DxfHandledObject) this.DictionaryAcadPlotStyleName, 14UL);
      this.SetHandle((DxfHandledObject) this.PlotStyle, 15UL);
      this.SetHandle((DxfHandledObject) this.ZeroLayer, 16UL);
      this.SetHandle((DxfHandledObject) this.DefaultTextStyle, 17UL);
      this.SetHandle((DxfHandledObject) this.AppIdAcad, 18UL);
      this.SetHandle((DxfHandledObject) this.ByBlockLineType, 20UL);
      this.SetHandle((DxfHandledObject) this.ByLayerLineType, 21UL);
      this.SetHandle((DxfHandledObject) this.ContinuousLineType, 22UL);
      this.SetHandle((DxfHandledObject) this.DictionaryAcadMLineStyle, 23UL);
      this.SetHandle((DxfHandledObject) this.DefaultMLineStyle, 24UL);
      this.SetHandle((DxfHandledObject) this.DictionaryAcadPlotSettings, 25UL);
      this.SetHandle((DxfHandledObject) this.DictionaryAcadLayout, 26UL);
      int num1 = 0;
      int num2 = 0;
      foreach (DxfLayout dxfLayout in (KeyedDxfHandledObjectCollection<string, DxfLayout>) this.dxfLayoutCollection_0)
      {
        if (dxfLayout.PaperSpace)
        {
          if (dxfLayout == this.ActiveLayout || this.ActiveLayout == null && num1 == 0)
          {
            this.SetHandle((DxfHandledObject) dxfLayout, 30UL);
            this.SetHandle((DxfHandledObject) dxfLayout.OwnerBlock, 27UL);
            this.SetHandle((DxfHandledObject) dxfLayout.OwnerBlock.BlockBegin, 28UL);
            this.SetHandle((DxfHandledObject) dxfLayout.OwnerBlock.BlockEnd, 29UL);
          }
          ++num1;
        }
        else
        {
          if (num2 == 0)
            this.SetHandle((DxfHandledObject) dxfLayout, 34UL);
          ++num2;
        }
      }
    }

    public void SetHandle(DxfHandledObject handledObject)
    {
      handledObject.vmethod_0(new Action(this.method_102), new Stack<DxfHandledObject>());
    }

    private void SetHandle(DxfHandledObject handledObject, ulong handle)
    {
      handledObject?.SetHandle(handle);
    }

    public void Repair(IList<DxfMessage> messages)
    {
      new DxfModelRepairer(this, messages).Repair();
    }

    public void ExecuteForChildren(Action action)
    {
      Stack<DxfHandledObject> callerStack = new Stack<DxfHandledObject>();
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfLayer>) this.dxfLayerCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfBlockCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfBlockCollection_1)
        dxfHandledObject.vmethod_0(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfBlockCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfTextStyle>) this.dxfTextStyleCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfLineType>) this.dxfLineTypeCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfUcs>) this.dxfUcsCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfView>) this.dxfViewCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfDimensionStyle>) this.dxfDimensionStyleCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfVPort>) this.dxfVPortCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
      DxfHandledObject[] dxfHandledObjectArray = new DxfHandledObject[11]{ (DxfHandledObject) this.DictionaryRoot, this.VPortTable, this.LineTypeTable, this.LayerTable, this.TextStyleTable, this.ViewTable, this.UcsTable, this.AppIdTable, (DxfHandledObject) this.AppIdAcad, this.DimStyleTable, this.BlockRecordTable };
      foreach (DxfHandledObject dxfHandledObject in dxfHandledObjectArray)
        dxfHandledObject.vmethod_0(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfAppId>) this.dxfAppIdCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
      this.ViewportEntityHeaderTable.vmethod_0(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfViewportEntityHeader>) this.class28_0)
        dxfHandledObject.vmethod_0(action, callerStack);
    }

    public void LoadExternalReferences()
    {
      IList<DxfBlock> missingReferences;
      this.LoadExternalReferences(out missingReferences);
    }

    public void LoadExternalReferences(out IList<DxfBlock> missingReferences)
    {
      if (this.string_3 == null)
        this.LoadExternalReferences((string) null, out missingReferences);
      else
        this.LoadExternalReferences((string) null, Path.GetDirectoryName(this.string_3), (DxfBlock.GetExternalReferenceDelegate) null, (Dictionary<string, DxfModel>) null, out missingReferences);
    }

    public void LoadExternalReferences(string searchDirectory)
    {
      IList<DxfBlock> missingReferences;
      this.LoadExternalReferences(searchDirectory, out missingReferences);
    }

    public void LoadExternalReferences(
      string searchDirectory,
      out IList<DxfBlock> missingReferences)
    {
      this.LoadExternalReferences(searchDirectory, searchDirectory, (DxfBlock.GetExternalReferenceDelegate) null, (Dictionary<string, DxfModel>) null, out missingReferences);
    }

    public void LoadExternalReferences(
      DxfBlock.GetExternalReferenceDelegate customResolveExternalReference,
      out IList<DxfBlock> missingReferences)
    {
      this.LoadExternalReferences((string) null, (string) null, customResolveExternalReference, (Dictionary<string, DxfModel>) null, out missingReferences);
    }

    private void LoadExternalReferences(
      string searchDirectory,
      string searchDirectoryForThisModelOnly,
      DxfBlock.GetExternalReferenceDelegate customResolveExternalReference,
      Dictionary<string, DxfModel> loadedExternalReferences,
      out IList<DxfBlock> missingReferences)
    {
      if (searchDirectoryForThisModelOnly == null)
        searchDirectoryForThisModelOnly = Directory.GetCurrentDirectory();
      if (loadedExternalReferences == null)
      {
        loadedExternalReferences = new Dictionary<string, DxfModel>((IDictionary<string, DxfModel>) this.ExternalReferences);
        if (!string.IsNullOrEmpty(this.string_3))
          loadedExternalReferences.Add(this.string_3, this);
      }
      missingReferences = (IList<DxfBlock>) new List<DxfBlock>();
      foreach (DxfBlock block in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfBlockCollection_0)
        DxfModel.LoadExternalReference(searchDirectory, searchDirectoryForThisModelOnly, customResolveExternalReference, block, loadedExternalReferences, missingReferences);
      foreach (DxfBlock block in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfBlockCollection_1)
        DxfModel.LoadExternalReference(searchDirectory, searchDirectoryForThisModelOnly, customResolveExternalReference, block, loadedExternalReferences, missingReferences);
    }

    private static void LoadExternalReference(
      string searchDirectory,
      string searchDirectoryForThisModelOnly,
      DxfBlock.GetExternalReferenceDelegate customResolveExternalReference,
      DxfBlock block,
      Dictionary<string, DxfModel> loadedExternalReferences,
      IList<DxfBlock> missingReferences)
    {
      if (block == null || !block.IsExternalReference)
        return;
      bool wasAlreadyLoaded;
      DxfModel dxfModel = block.LoadExternalReference(loadedExternalReferences, customResolveExternalReference ?? new DxfBlock.GetExternalReferenceDelegate(new DxfBlock.Class752(searchDirectoryForThisModelOnly, loadedExternalReferences).method_0), out wasAlreadyLoaded);
      if (dxfModel == null)
      {
        missingReferences.Add(block);
      }
      else
      {
        if (wasAlreadyLoaded)
          return;
        string searchDirectoryForThisModelOnly1 = searchDirectory;
        if (searchDirectoryForThisModelOnly1 == null && !string.IsNullOrEmpty(dxfModel.Filename))
          searchDirectoryForThisModelOnly1 = Path.GetDirectoryName(dxfModel.Filename);
        dxfModel.LoadExternalReferences(searchDirectory, searchDirectoryForThisModelOnly1, customResolveExternalReference, loadedExternalReferences, out missingReferences);
      }
    }

    public IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfHandledObject existingClone = (DxfHandledObject) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (existingClone == null)
        throw new NotSupportedException("Use method DxfModel Clone() to clone a whole model.");
      return (IGraphCloneable) existingClone;
    }

    public void CopyFrom(DxfModel from, CloneContext cloneContext)
    {
      this.method_103(from);
      this.method_104(from, cloneContext);
      this.method_106(from, cloneContext);
      foreach (DxfLayout dxfLayout1 in (KeyedDxfHandledObjectCollection<string, DxfLayout>) from.dxfLayoutCollection_0)
      {
        if (dxfLayout1 == from.ModelLayout)
        {
          if (this.ModelLayout == null)
            this.dxfLayoutCollection_0.Add((DxfLayout) dxfLayout1.Clone(cloneContext));
        }
        else
        {
          DxfLayout dxfLayout2 = (DxfLayout) dxfLayout1.Clone(cloneContext);
          int num = 1;
          while (this.dxfLayoutCollection_0.Contains(dxfLayout2.Name))
          {
            dxfLayout2.Name = "Layout" + (object) num;
            ++num;
          }
          this.dxfLayoutCollection_0.Add(dxfLayout2);
        }
      }
      if (!cloneContext.CloneHeader)
        return;
      this.dxfHeader_0.CopyFrom(from.dxfHeader_0, cloneContext);
    }

    public void Dispose()
    {
      if (this.dxfLayoutCollection_0 != null)
      {
        foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfLayout>) this.dxfLayoutCollection_0)
          dxfHandledObject.Dispose();
        this.dxfLayoutCollection_0 = (DxfLayoutCollection) null;
      }
      if (this.dxfEntityCollection_0 != null)
        this.method_24((DxfEntityCollection) null);
      if (this.dxfImageDefCollection_0 != null)
      {
        foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfImageDef>) this.dxfImageDefCollection_0)
          dxfHandledObject.Dispose();
        this.dxfImageDefCollection_0 = (DxfImageDefCollection) null;
      }
      if (this.DictionaryRoot == null)
        return;
      this.DictionaryRoot.Dispose();
      this.DictionaryRoot = (DxfDictionary) null;
    }

    public bool Active
    {
      get
      {
        return this.bool_0;
      }
    }

    internal DxfPlaceHolder PlotStyle
    {
      get
      {
        return (DxfPlaceHolder) this.dxfObjectReference_32.Value;
      }
      set
      {
        this.dxfObjectReference_32 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfAppId AppIdAcad
    {
      get
      {
        return (DxfAppId) this.dxfObjectReference_4.Value;
      }
      set
      {
        this.dxfObjectReference_4 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfDictionary DictionaryAcadColor
    {
      get
      {
        return (DxfDictionary) this.dxfObjectReference_17.Value;
      }
      private set
      {
        this.dxfObjectReference_17 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfDictionary DictionaryAcadFieldList
    {
      get
      {
        return (DxfDictionary) this.dxfObjectReference_18.Value;
      }
      set
      {
        this.dxfObjectReference_18 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfDictionary DictionaryAcadGroup
    {
      get
      {
        return (DxfDictionary) this.dxfObjectReference_19.Value;
      }
      set
      {
        this.dxfObjectReference_19 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfDictionary DictionaryAcadScaleList
    {
      get
      {
        return (DxfDictionary) this.dxfObjectReference_28.Value;
      }
      set
      {
        this.dxfObjectReference_28 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfDictionary DictionaryAcadVisualStyle
    {
      get
      {
        return (DxfDictionary) this.dxfObjectReference_29.Value;
      }
      set
      {
        this.dxfObjectReference_29 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfDictionary DictionaryAcadImage
    {
      get
      {
        return (DxfDictionary) this.dxfObjectReference_20.Value;
      }
      set
      {
        this.dxfObjectReference_20 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfDictionary DictionaryAcadLayout
    {
      get
      {
        return (DxfDictionary) this.dxfObjectReference_21.Value;
      }
      set
      {
        this.dxfObjectReference_21 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfDictionary DictionaryAcadMaterial
    {
      get
      {
        return (DxfDictionary) this.dxfObjectReference_22.Value;
      }
      set
      {
        this.dxfObjectReference_22 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfDictionary DictionaryAcadMLeaderStyle
    {
      get
      {
        return (DxfDictionary) this.dxfObjectReference_23.Value;
      }
      set
      {
        this.dxfObjectReference_23 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfDictionary DictionaryAcadMLineStyle
    {
      get
      {
        return (DxfDictionary) this.dxfObjectReference_24.Value;
      }
      set
      {
        this.dxfObjectReference_24 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfDictionary DictionaryAcadPlotSettings
    {
      get
      {
        return (DxfDictionary) this.dxfObjectReference_25.Value;
      }
      set
      {
        this.dxfObjectReference_25 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfDictionary DictionaryAcadTableStyle
    {
      get
      {
        return (DxfDictionary) this.dxfObjectReference_26.Value;
      }
      set
      {
        this.dxfObjectReference_26 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfDictionaryWithDefault DictionaryAcadPlotStyleName
    {
      get
      {
        return (DxfDictionaryWithDefault) this.dxfObjectReference_27.Value;
      }
      set
      {
        this.dxfObjectReference_27 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfXRecord XRecordDwgProps
    {
      get
      {
        return (DxfXRecord) this.dxfObjectReference_33.Value;
      }
      set
      {
        this.dxfObjectReference_33 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfBlock ModelSpaceBlock
    {
      get
      {
        return (DxfBlock) this.dxfObjectReference_6.Value;
      }
    }

    internal DxfBlock PaperSpaceBlock
    {
      get
      {
        return (DxfBlock) this.dxfObjectReference_7.Value;
      }
      set
      {
        this.dxfObjectReference_7 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal DxfHandledObject VPortTable
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_34.Value;
      }
      set
      {
        this.dxfObjectReference_34 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        value.vmethod_2((IDxfHandledObject) this);
      }
    }

    internal DxfHandledObject LineTypeTable
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_35.Value;
      }
      set
      {
        this.dxfObjectReference_35 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        value.vmethod_2((IDxfHandledObject) this);
      }
    }

    internal DxfHandledObject LayerTable
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_36.Value;
      }
      set
      {
        this.dxfObjectReference_36 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        value.vmethod_2((IDxfHandledObject) this);
      }
    }

    internal DxfHandledObject TextStyleTable
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_37.Value;
      }
      set
      {
        this.dxfObjectReference_37 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        value.vmethod_2((IDxfHandledObject) this);
      }
    }

    internal DxfHandledObject ViewTable
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_38.Value;
      }
      set
      {
        this.dxfObjectReference_38 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        value.vmethod_2((IDxfHandledObject) this);
      }
    }

    internal DxfHandledObject UcsTable
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_39.Value;
      }
      set
      {
        this.dxfObjectReference_39 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        value.vmethod_2((IDxfHandledObject) this);
      }
    }

    internal DxfHandledObject AppIdTable
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_40.Value;
      }
      set
      {
        this.dxfObjectReference_40 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        value.vmethod_2((IDxfHandledObject) this);
      }
    }

    internal DxfHandledObject DimStyleTable
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_41.Value;
      }
      set
      {
        this.dxfObjectReference_41 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        value.vmethod_2((IDxfHandledObject) this);
      }
    }

    internal DxfHandledObject BlockRecordTable
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_42.Value;
      }
      set
      {
        this.dxfObjectReference_42 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        value.vmethod_2((IDxfHandledObject) this);
      }
    }

    internal DxfHandledObject ViewportEntityHeaderTable
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_43.Value;
      }
      set
      {
        this.dxfObjectReference_43 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        value.vmethod_2((IDxfHandledObject) this);
      }
    }

    internal Class741 method_13()
    {
      Class741 dataStore = new Class741(true);
      ns6.Class46 schemaSearchData = new ns6.Class46();
      List<ns6.Class46.Class47> idEntries = new List<ns6.Class46.Class47>();
      foreach (DxfBlock dxfBlock in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfBlockCollection_1)
      {
        foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) dxfBlock.Entities)
          DxfModel.smethod_0(dataStore, schemaSearchData, idEntries, entity);
      }
      foreach (DxfBlock dxfBlock in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfBlockCollection_0)
      {
        foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) dxfBlock.Entities)
          DxfModel.smethod_0(dataStore, schemaSearchData, idEntries, entity);
      }
      schemaSearchData.IdIndexesSet = new ns6.Class46.Class47[1][]
      {
        idEntries.ToArray()
      };
      dataStore.SchemaSearchDataList.Add(schemaSearchData);
      return dataStore;
    }

    private static void smethod_0(
      Class741 dataStore,
      ns6.Class46 schemaSearchData,
      List<ns6.Class46.Class47> idEntries,
      DxfEntity entity)
    {
      DxfModelerGeometry dxfModelerGeometry = entity as DxfModelerGeometry;
      if (dxfModelerGeometry == null)
        return;
      ulong handle = dxfModelerGeometry.Handle;
      if (dxfModelerGeometry.IsSab)
      {
        MemoryStream memoryStream = new MemoryStream();
        memoryStream.Write(DxfModelerGeometry.BinaryFilePrefix, 0, DxfModelerGeometry.BinaryFilePrefix.Length);
        dxfModelerGeometry.SabStream.WriteTo((Stream) memoryStream);
        memoryStream.Seek(0L, SeekOrigin.Begin);
        dataStore.Add(Enum53.const_2, handle, (Stream) memoryStream);
      }
      else
      {
        MemoryStream memoryStream = new MemoryStream();
        memoryStream.Write(DxfModelerGeometry.BinaryFilePrefix, 0, DxfModelerGeometry.BinaryFilePrefix.Length);
        dxfModelerGeometry.SabStreamFromSAT.WriteTo((Stream) memoryStream);
        memoryStream.Seek(0L, SeekOrigin.Begin);
        dataStore.Add(Enum53.const_2, handle, (Stream) memoryStream);
      }
      ulong count = (ulong) schemaSearchData.SortedIndexes.Count;
      schemaSearchData.SortedIndexes.Add(count);
      ns6.Class46.Class47 class47 = new ns6.Class46.Class47() { Handle = entity.Handle };
      class47.Indexes.Add(count);
      idEntries.Add(class47);
    }

    internal DxfLayer method_14()
    {
      DxfLayer dxfLayer = this.GetLayerWithName("DEFPOINTS");
      if (dxfLayer == null)
      {
        dxfLayer = DxfLayer.smethod_3();
        this.dxfLayerCollection_0.Add(dxfLayer);
      }
      return dxfLayer;
    }

    internal DxfLayout method_15()
    {
      DxfLayout dxfLayout = (DxfLayout) null;
      DxfBlock paperSpaceBlock = this.PaperSpaceBlock;
      if (paperSpaceBlock != null)
        dxfLayout = paperSpaceBlock.Layout;
      return dxfLayout;
    }

    internal List<DxfDictionary> method_16()
    {
      List<DxfDictionary> result = new List<DxfDictionary>();
      foreach (DxfLineType dxfLineType in (KeyedDxfHandledObjectCollection<string, DxfLineType>) this.dxfLineTypeCollection_0)
        DxfModel.smethod_1(result, (DxfHandledObject) dxfLineType);
      foreach (DxfTextStyle dxfTextStyle in (DxfHandledObjectCollection<DxfTextStyle>) this.dxfTextStyleCollection_0)
        DxfModel.smethod_1(result, (DxfHandledObject) dxfTextStyle);
      foreach (DxfAppId dxfAppId in (KeyedDxfHandledObjectCollection<string, DxfAppId>) this.dxfAppIdCollection_0)
        DxfModel.smethod_1(result, (DxfHandledObject) dxfAppId);
      foreach (DxfUcs dxfUcs in (KeyedDxfHandledObjectCollection<string, DxfUcs>) this.dxfUcsCollection_0)
        DxfModel.smethod_1(result, (DxfHandledObject) dxfUcs);
      foreach (DxfView dxfView in (KeyedDxfHandledObjectCollection<string, DxfView>) this.dxfViewCollection_0)
        DxfModel.smethod_1(result, (DxfHandledObject) dxfView);
      foreach (DxfVPort dxfVport in (DxfHandledObjectCollection<DxfVPort>) this.dxfVPortCollection_0)
        DxfModel.smethod_1(result, (DxfHandledObject) dxfVport);
      foreach (DxfLayer dxfLayer in (KeyedDxfHandledObjectCollection<string, DxfLayer>) this.dxfLayerCollection_0)
        DxfModel.smethod_1(result, (DxfHandledObject) dxfLayer);
      foreach (DxfDimensionStyle dxfDimensionStyle in (KeyedDxfHandledObjectCollection<string, DxfDimensionStyle>) this.dxfDimensionStyleCollection_0)
        DxfModel.smethod_1(result, (DxfHandledObject) dxfDimensionStyle);
      foreach (DxfBlock block in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfBlockCollection_0)
        this.method_17(result, block);
      foreach (DxfBlock block in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfBlockCollection_1)
        this.method_17(result, block);
      DxfModel.smethod_2(result, this.DictionaryRoot);
      return result;
    }

    private void method_17(List<DxfDictionary> result, DxfBlock block)
    {
      DxfModel.smethod_1(result, (DxfHandledObject) block);
      foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) block.Entities)
      {
        DxfModel.smethod_1(result, (DxfHandledObject) entity);
        if (entity is DxfInsert)
        {
          foreach (DxfAttribute attribute in (IEnumerable<DxfAttribute>) ((DxfInsertBase) entity).Attributes)
            DxfModel.smethod_1(result, (DxfHandledObject) attribute);
        }
      }
      DxfModel.smethod_1(result, (DxfHandledObject) block.BlockBegin);
    }

    private static void smethod_1(List<DxfDictionary> result, DxfHandledObject o)
    {
      if (o.ExtensionDictionary == null)
        return;
      result.Add(o.ExtensionDictionary);
      DxfModel.smethod_2(result, o.ExtensionDictionary);
    }

    private static void smethod_2(List<DxfDictionary> result, DxfDictionary dictionary)
    {
      DxfModel.smethod_1(result, (DxfHandledObject) dictionary);
      foreach (IDictionaryEntry entry in (ActiveList<IDictionaryEntry>) dictionary.Entries)
      {
        DxfObject dxfObject = entry.Value;
        DxfDictionary dictionary1 = dxfObject as DxfDictionary;
        if (dictionary1 != null)
          DxfModel.smethod_2(result, dictionary1);
        else if (dxfObject != null)
          DxfModel.smethod_1(result, (DxfHandledObject) dxfObject);
      }
    }

    internal void method_18(DxfLineType lineType)
    {
      this.ByLayerLineType = lineType;
    }

    internal void method_19(DxfLineType lineType)
    {
      this.ByBlockLineType = lineType;
    }

    internal void method_20(DxfLineType lineType)
    {
      this.ContinuousLineType = lineType;
    }

    internal void method_21(DxfDictionary dictionary)
    {
      this.DictionaryAcadLayout = dictionary;
    }

    internal void method_22(bool useFixedHandles)
    {
      DxfAppId dxfAppId;
      if (!this.dxfAppIdCollection_0.TryGetValue("ACAD", out dxfAppId))
      {
        dxfAppId = DxfAppId.smethod_2(useFixedHandles);
        this.dxfAppIdCollection_0.Add(dxfAppId);
      }
      this.dxfObjectReference_4 = dxfAppId.Reference;
    }

    internal void method_23(bool useFixedHandles)
    {
      DxfAppId dxfAppId;
      if (!this.dxfAppIdCollection_0.TryGetValue("ACAD_MLEADERVER", out dxfAppId))
      {
        dxfAppId = DxfAppId.smethod_3(useFixedHandles);
        this.dxfAppIdCollection_0.Add(dxfAppId);
      }
      this.dxfObjectReference_5 = dxfAppId.Reference;
    }

    internal void method_24(DxfEntityCollection entities)
    {
      this.dxfEntityCollection_0 = entities;
    }

    internal void method_25(string name, string value)
    {
      DxfDictionaryVariable valueByName = this.DictionaryAcDbVariable.GetValueByName(name) as DxfDictionaryVariable;
      if (valueByName == null)
      {
        DxfDictionaryVariable dictionaryVariable = new DxfDictionaryVariable(value);
        this.DictionaryAcDbVariable.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(name, (DxfObject) dictionaryVariable));
      }
      else
        valueByName.Value = value;
    }

    internal void method_26(string name, string value, bool setDictionaryEntryOtherwiseRemove)
    {
      DxfDictionaryVariable valueByName = this.DictionaryAcDbVariable.GetValueByName(name) as DxfDictionaryVariable;
      if (valueByName == null)
      {
        if (!setDictionaryEntryOtherwiseRemove)
          return;
        DxfDictionaryVariable dictionaryVariable = new DxfDictionaryVariable(value);
        this.DictionaryAcDbVariable.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(name, (DxfObject) dictionaryVariable));
      }
      else if (setDictionaryEntryOtherwiseRemove)
        valueByName.Value = value;
      else
        this.DictionaryAcDbVariable.Entries.RemoveAll(name);
    }

    internal void method_27()
    {
      if (this.Header.CurrentAnnotationScale != null)
      {
        this.method_25("CANNOSCALE", this.Header.CurrentAnnotationScale.Name);
        this.method_25("ANNOALLVISIBLE", this.Header.AnnotationsAlwaysVisible ? "1" : "0");
        this.method_25("ANNOTATIVEDWG", this.Header.AnnotativeDrawing ? "1" : "0");
      }
      this.method_26("MSLTSCALE", this.Header.ModelSpaceAnnotationScalingEnabled ? "1" : "0", !this.Header.ModelSpaceAnnotationScalingEnabled);
      this.method_26("PSLTSCALE", this.Header.PaperSpaceAnnotationScalingEnabled ? "1" : "0", !this.Header.PaperSpaceAnnotationScalingEnabled);
      this.method_25("DIMASSOC", ((short) this.Header.DimensionAssociativity).ToString());
    }

    internal void method_28(Class1070 context)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfModel.Class982 class982 = new DxfModel.Class982();
      bool isTrial = Class809.smethod_1(Enum15.const_1).IsTrial;
      // ISSUE: reference to a compiler-generated field
      class982.dxfBlock_0 = (DxfBlock) this.dxfObjectReference_1.Value;
      DxfInsert dxfInsert = (DxfInsert) null;
      if (isTrial)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (class982.dxfBlock_0 != null || this.dxfBlockCollection_1.TryGetValue("*W188397", out class982.dxfBlock_0))
        {
          // ISSUE: reference to a compiler-generated field
          class982.dxfBlock_0.Entities.Clear();
          if (this.dxfObjectReference_1 == DxfObjectReference.Null)
          {
            // ISSUE: reference to a compiler-generated field
            this.dxfObjectReference_1 = class982.dxfBlock_0.Reference;
          }
        }
        // ISSUE: reference to a compiler-generated field
        if (class982.dxfBlock_0 != null)
        {
          // ISSUE: reference to a compiler-generated method
          int index = this.dxfEntityCollection_0.FindIndex(new Predicate<DxfEntity>(class982.method_0));
          if (index >= 0)
          {
            dxfInsert = (DxfInsert) this.dxfEntityCollection_0[index];
            this.dxfObjectReference_3 = dxfInsert.Reference;
            this.dxfEntityCollection_0.RemoveAt(index);
          }
        }
      }
      GraphicsConfig graphicsConfig = (GraphicsConfig) GraphicsConfig.AcadLikeWithBlackBackground.Clone();
      graphicsConfig.ApplyLineType = false;
      BoundsCalculator boundsCalculator = new BoundsCalculator(graphicsConfig);
      boundsCalculator.GetBounds(this);
      Bounds3D bounds = boundsCalculator.Bounds;
      if (bounds.Initialized)
      {
        this.dxfHeader_0.ExtMin = bounds.Corner1;
        this.dxfHeader_0.ExtMax = bounds.Corner2;
      }
      else
      {
        this.dxfHeader_0.ExtMin = DxfHeader.point3D_6;
        this.dxfHeader_0.ExtMax = DxfHeader.point3D_7;
      }
      if (isTrial)
      {
        // ISSUE: reference to a compiler-generated field
        if (class982.dxfBlock_0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          class982.dxfBlock_0 = new DxfBlock("*W188397");
          // ISSUE: reference to a compiler-generated field
          this.dxfObjectReference_1 = class982.dxfBlock_0.Reference;
          // ISSUE: reference to a compiler-generated field
          this.dxfBlockCollection_1.Add(class982.dxfBlock_0);
        }
        // ISSUE: reference to a compiler-generated field
        class982.dxfBlock_0.IsAnonymous = true;
        DxfText dxfText = new DxfText("CadLib evaluation version", WW.Math.Point3D.Zero, 1.0);
        this.dxfObjectReference_2 = dxfText.Reference;
        dxfText.Color = EntityColors.Gray;
        dxfText.Rotation = System.Math.PI / 5.0;
        dxfText.AlignmentPoint2 = new WW.Math.Point3D?(WW.Math.Point3D.Zero);
        dxfText.HorizontalAlignment = TextHorizontalAlignment.Center;
        dxfText.VerticalAlignment = TextVerticalAlignment.Middle;
        // ISSUE: reference to a compiler-generated field
        class982.dxfBlock_0.Entities.Add((DxfEntity) dxfText);
        if (dxfInsert == null)
        {
          // ISSUE: reference to a compiler-generated field
          dxfInsert = new DxfInsert(class982.dxfBlock_0);
          this.dxfObjectReference_3 = dxfInsert.Reference;
          // ISSUE: reference to a compiler-generated field
          dxfInsert.Block = class982.dxfBlock_0;
          this.dxfEntityCollection_0.Add((DxfEntity) dxfInsert);
        }
        dxfInsert.RowCount = (ushort) 4;
        dxfInsert.ColumnCount = (ushort) 4;
        if (bounds.Initialized)
        {
          dxfInsert.InsertionPoint = bounds.Corner1;
          WW.Math.Vector3D delta = bounds.Delta;
          dxfInsert.ScaleFactor = new WW.Math.Vector3D(0.015 * delta.X, 0.015 * delta.Y, 1.0);
          dxfInsert.RowSpacing = delta.X / (double) ((int) dxfInsert.RowCount - 1);
          dxfInsert.ColumnSpacing = delta.Y / (double) ((int) dxfInsert.ColumnCount - 1);
        }
        else
        {
          dxfInsert.InsertionPoint = WW.Math.Point3D.Zero;
          dxfInsert.RowSpacing = 20.0;
          dxfInsert.ColumnSpacing = 20.0;
        }
        dxfInsert.Visible = true;
        dxfInsert.Layer = this.ZeroLayer;
      }
      this.method_32();
      foreach (DxfLayout dxfLayout in (KeyedDxfHandledObjectCollection<string, DxfLayout>) this.dxfLayoutCollection_0)
        dxfLayout.method_15();
      this.class28_0.method_0(this);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfLineType>) this.dxfLineTypeCollection_0)
        dxfHandledObject.vmethod_1(context);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfLayer>) this.dxfLayerCollection_0)
        dxfHandledObject.vmethod_1(context);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfTextStyle>) this.dxfTextStyleCollection_0)
        dxfHandledObject.vmethod_1(context);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfView>) this.dxfViewCollection_0)
        dxfHandledObject.vmethod_1(context);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfVPort>) this.dxfVPortCollection_0)
        dxfHandledObject.vmethod_1(context);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfDimensionStyle>) this.dxfDimensionStyleCollection_0)
        dxfHandledObject.vmethod_1(context);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfAppId>) this.dxfAppIdCollection_0)
        dxfHandledObject.vmethod_1(context);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfUcs>) this.dxfUcsCollection_0)
        dxfHandledObject.vmethod_1(context);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfBlockCollection_0)
        dxfHandledObject.vmethod_1(context);
      foreach (DxfHandledObject dxfHandledObject in new List<DxfBlock>((IEnumerable<DxfBlock>) this.dxfBlockCollection_1))
        dxfHandledObject.vmethod_1(context);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfAppId>) this.dxfAppIdCollection_0)
        dxfHandledObject.vmethod_2((IDxfHandledObject) this);
      this.dxfHeader_0.method_6(this);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfEntity>) this.dxfEntityCollection_0)
        dxfHandledObject.vmethod_1(context);
      this.DictionaryRoot.vmethod_1(context);
      this.method_27();
      this.method_29(context);
      DxfXRecord xrecordRecomposeData = this.XRecordRecomposeData;
      xrecordRecomposeData.Values.Clear();
      xrecordRecomposeData.Values.Add((short) 90, (object) 1);
      foreach (DxfObject dxfObject in this.dxfHandledObjectCollection_0)
        xrecordRecomposeData.Values.Add((short) 330, (object) dxfObject);
      foreach (DxfEntity dxfEntity in this.dxfHandledObjectCollection_1)
        xrecordRecomposeData.Values.Add((short) 330, (object) dxfEntity);
      for (int classIndex = 0; classIndex < this.dxfClassCollection_0.Count; ++classIndex)
        this.dxfClassCollection_0[classIndex].method_0(classIndex);
      this.CheckAndSetHandles();
    }

    private void method_29(Class1070 context)
    {
      this.summaryInfo_0.method_0(context, this);
    }

    internal void method_30(DxfEntity objectToBeRecomposed)
    {
      this.dxfHandledObjectCollection_1.Add(objectToBeRecomposed);
    }

    internal void method_31(DxfObject objectToBeRecomposed)
    {
      this.dxfHandledObjectCollection_0.Add(objectToBeRecomposed);
    }

    internal void method_32()
    {
      if ((this.ActiveLayout == null || !this.ActiveLayout.PaperSpace) && this.dxfLayoutCollection_0.Count > 0)
      {
        foreach (DxfLayout layout in (KeyedDxfHandledObjectCollection<string, DxfLayout>) this.dxfLayoutCollection_0)
        {
          if (layout.PaperSpace && layout.Viewports.Count > 0)
          {
            this.method_0(layout);
            break;
          }
        }
      }
      if ((this.ActiveLayout == null || !this.ActiveLayout.PaperSpace) && this.dxfLayoutCollection_0.Count > 0)
      {
        foreach (DxfLayout layout in (KeyedDxfHandledObjectCollection<string, DxfLayout>) this.dxfLayoutCollection_0)
        {
          if (layout.PaperSpace)
          {
            this.method_0(layout);
            break;
          }
        }
      }
      if (this.ActiveLayout != null)
      {
        int num = 0;
        foreach (DxfLayout dxfLayout in (KeyedDxfHandledObjectCollection<string, DxfLayout>) this.dxfLayoutCollection_0)
        {
          if (dxfLayout.PaperSpace)
          {
            if (dxfLayout == this.ActiveLayout)
            {
              dxfLayout.OwnerBlock.Name = "*Paper_Space";
            }
            else
            {
              dxfLayout.OwnerBlock.Name = "*Paper_Space" + num.ToString();
              ++num;
            }
            int index = this.dxfBlockCollection_1.IndexOf(dxfLayout.OwnerBlock);
            if (index >= 0)
              this.dxfBlockCollection_1[index] = dxfLayout.OwnerBlock;
          }
        }
      }
      foreach (DxfLayout dxfLayout in (KeyedDxfHandledObjectCollection<string, DxfLayout>) this.dxfLayoutCollection_0)
        dxfLayout.method_11();
      DxfBlock dxfBlock;
      this.dxfBlockCollection_1.TryGetValue("*Paper_Space", out dxfBlock);
      this.PaperSpaceBlock = dxfBlock;
    }

    internal void method_33()
    {
      if (this.bool_0)
        return;
      DxfAttributeBase.class680_0.Visit(this);
      this.bool_0 = true;
    }

    internal bool method_34(string shxFileName)
    {
      return ShxFile.Exists(shxFileName, this.string_4);
    }

    internal ShxFile GetShxFile(string shxFileName)
    {
      if (shxFileName == null)
        return (ShxFile) null;
      ShxFile shxFile;
      lock (this.dictionary_1)
      {
        if (!this.dictionary_1.TryGetValue(shxFileName, out shxFile))
        {
          if (ShxFile.smethod_2(shxFileName, this.string_4))
          {
            try
            {
              shxFile = ShxFile.GetShxFile(shxFileName, this.string_4);
            }
            catch (IOException ex)
            {
            }
          }
          this.dictionary_1.Add(shxFileName, shxFile);
        }
      }
      return shxFile;
    }

    private void method_35()
    {
      this.dxfBlockCollection_0.Inserted += new ItemEventHandler<DxfBlock>(this.method_40);
      this.dxfBlockCollection_0.Set += new ItemSetEventHandler<DxfBlock>(this.method_39);
      this.dxfBlockCollection_0.Removed += new ItemEventHandler<DxfBlock>(this.method_41);
      this.dxfBlockCollection_1.Inserted += new ItemEventHandler<DxfBlock>(this.method_40);
      this.dxfBlockCollection_1.Set += new ItemSetEventHandler<DxfBlock>(this.method_39);
      this.dxfBlockCollection_1.Removed += new ItemEventHandler<DxfBlock>(this.method_41);
      this.dxfAppIdCollection_0.Inserted += new ItemEventHandler<DxfAppId>(this.method_43);
      this.dxfAppIdCollection_0.Removed += new ItemEventHandler<DxfAppId>(this.method_44);
      this.dxfAppIdCollection_0.Set += new ItemSetEventHandler<DxfAppId>(this.method_45);
      this.dxfLayerCollection_0.Inserted += new ItemEventHandler<DxfLayer>(this.method_46);
      this.dxfLayerCollection_0.Removed += new ItemEventHandler<DxfLayer>(this.method_47);
      this.dxfLayerCollection_0.Set += new ItemSetEventHandler<DxfLayer>(this.method_48);
      this.dxfLayoutCollection_0.Inserted += new ItemEventHandler<DxfLayout>(this.method_79);
      this.dxfLayoutCollection_0.Removed += new ItemEventHandler<DxfLayout>(this.method_80);
      this.dxfLayoutCollection_0.Set += new ItemSetEventHandler<DxfLayout>(this.method_81);
      this.dxfImageDefCollection_0.Added += new ItemEventHandler<DxfImageDef>(this.method_49);
      this.dxfImageDefCollection_0.Removed += new ItemEventHandler<DxfImageDef>(this.method_50);
      this.dxfImageDefCollection_0.Set += new ItemSetEventHandler<DxfImageDef>(this.method_51);
      this.dxfColorCollection_0.Added += new ItemEventHandler<DxfColor>(this.method_82);
      this.dxfColorCollection_0.Removed += new ItemEventHandler<DxfColor>(this.method_83);
      this.dxfColorCollection_0.Set += new ItemSetEventHandler<DxfColor>(this.method_84);
      this.dxfGroupCollection_0.Inserted += new ItemEventHandler<DxfGroup>(this.method_85);
      this.dxfGroupCollection_0.Removed += new ItemEventHandler<DxfGroup>(this.method_86);
      this.dxfGroupCollection_0.Set += new ItemSetEventHandler<DxfGroup>(this.method_87);
      this.dxfScaleCollection_0.Added += new ItemEventHandler<DxfScale>(this.method_88);
      this.dxfScaleCollection_0.Removed += new ItemEventHandler<DxfScale>(this.method_89);
      this.dxfScaleCollection_0.Set += new ItemSetEventHandler<DxfScale>(this.method_90);
      this.dxfMLeaderStyleCollection_0.Added += new ItemEventHandler<DxfMLeaderStyle>(this.method_91);
      this.dxfMLeaderStyleCollection_0.Removed += new ItemEventHandler<DxfMLeaderStyle>(this.method_92);
      this.dxfMLeaderStyleCollection_0.Set += new ItemSetEventHandler<DxfMLeaderStyle>(this.method_93);
      this.dxfMLineStyleCollection_0.Added += new ItemEventHandler<DxfMLineStyle>(this.method_94);
      this.dxfMLineStyleCollection_0.Removed += new ItemEventHandler<DxfMLineStyle>(this.method_95);
      this.dxfMLineStyleCollection_0.Set += new ItemSetEventHandler<DxfMLineStyle>(this.method_96);
      this.dxfTextStyleCollection_0.Added += new ItemEventHandler<DxfTextStyle>(this.method_55);
      this.dxfTextStyleCollection_0.Removed += new ItemEventHandler<DxfTextStyle>(this.method_56);
      this.dxfTextStyleCollection_0.Set += new ItemSetEventHandler<DxfTextStyle>(this.method_57);
      this.dxfLineTypeCollection_0.Inserted += new ItemEventHandler<DxfLineType>(this.method_58);
      this.dxfLineTypeCollection_0.Removed += new ItemEventHandler<DxfLineType>(this.method_59);
      this.dxfLineTypeCollection_0.Set += new ItemSetEventHandler<DxfLineType>(this.method_60);
      this.dxfUcsCollection_0.Inserted += new ItemEventHandler<DxfUcs>(this.method_61);
      this.dxfUcsCollection_0.Removed += new ItemEventHandler<DxfUcs>(this.method_62);
      this.dxfUcsCollection_0.Set += new ItemSetEventHandler<DxfUcs>(this.method_63);
      this.dxfViewCollection_0.Inserted += new ItemEventHandler<DxfView>(this.method_64);
      this.dxfViewCollection_0.Removed += new ItemEventHandler<DxfView>(this.method_65);
      this.dxfViewCollection_0.Set += new ItemSetEventHandler<DxfView>(this.method_66);
      this.dxfDimensionStyleCollection_0.Inserted += new ItemEventHandler<DxfDimensionStyle>(this.method_67);
      this.dxfDimensionStyleCollection_0.Removed += new ItemEventHandler<DxfDimensionStyle>(this.method_68);
      this.dxfDimensionStyleCollection_0.Set += new ItemSetEventHandler<DxfDimensionStyle>(this.method_69);
      this.dxfVPortCollection_0.Added += new ItemEventHandler<DxfVPort>(this.method_70);
      this.dxfVPortCollection_0.Removed += new ItemEventHandler<DxfVPort>(this.method_71);
      this.dxfVPortCollection_0.Set += new ItemSetEventHandler<DxfVPort>(this.method_72);
      this.dxfTableStyleCollection_0.Inserted += new ItemEventHandler<DxfTableStyle>(this.method_73);
      this.dxfTableStyleCollection_0.Removed += new ItemEventHandler<DxfTableStyle>(this.method_74);
      this.dxfTableStyleCollection_0.Set += new ItemSetEventHandler<DxfTableStyle>(this.method_75);
      this.class28_0.Added += new ItemEventHandler<DxfViewportEntityHeader>(this.method_76);
      this.class28_0.Removed += new ItemEventHandler<DxfViewportEntityHeader>(this.method_77);
      this.class28_0.Set += new ItemSetEventHandler<DxfViewportEntityHeader>(this.method_78);
    }

    private void method_36()
    {
      foreach (DxfBlock blockRecord in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfBlockCollection_0)
        this.method_42(blockRecord);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfLayer>) this.dxfLayerCollection_0)
        dxfHandledObject.vmethod_3(this);
      foreach (DxfHandledObject dxfHandledObject in (KeyedDxfHandledObjectCollection<string, DxfLayout>) this.dxfLayoutCollection_0)
        dxfHandledObject.vmethod_3(this);
    }

    internal void Deactivate()
    {
      if (!this.bool_0)
        return;
      this.bool_0 = false;
    }

    private void method_37()
    {
      this.dxfBlockCollection_0.Inserted -= new ItemEventHandler<DxfBlock>(this.method_40);
      this.dxfBlockCollection_0.Set -= new ItemSetEventHandler<DxfBlock>(this.method_39);
      this.dxfBlockCollection_0.Removed -= new ItemEventHandler<DxfBlock>(this.method_41);
      this.dxfBlockCollection_1.Inserted -= new ItemEventHandler<DxfBlock>(this.method_40);
      this.dxfBlockCollection_1.Set -= new ItemSetEventHandler<DxfBlock>(this.method_39);
      this.dxfBlockCollection_1.Removed -= new ItemEventHandler<DxfBlock>(this.method_41);
      this.dxfLayerCollection_0.Inserted -= new ItemEventHandler<DxfLayer>(this.method_46);
      this.dxfLayerCollection_0.Removed -= new ItemEventHandler<DxfLayer>(this.method_47);
      this.dxfLayerCollection_0.Set -= new ItemSetEventHandler<DxfLayer>(this.method_48);
      this.dxfLayoutCollection_0.Inserted -= new ItemEventHandler<DxfLayout>(this.method_79);
      this.dxfLayoutCollection_0.Removed -= new ItemEventHandler<DxfLayout>(this.method_80);
      this.dxfLayoutCollection_0.Set -= new ItemSetEventHandler<DxfLayout>(this.method_81);
      this.dxfImageDefCollection_0.Added -= new ItemEventHandler<DxfImageDef>(this.method_49);
      this.dxfImageDefCollection_0.Removed -= new ItemEventHandler<DxfImageDef>(this.method_50);
      this.dxfImageDefCollection_0.Set -= new ItemSetEventHandler<DxfImageDef>(this.method_51);
      this.dxfColorCollection_0.Added -= new ItemEventHandler<DxfColor>(this.method_82);
      this.dxfColorCollection_0.Removed -= new ItemEventHandler<DxfColor>(this.method_83);
      this.dxfColorCollection_0.Set -= new ItemSetEventHandler<DxfColor>(this.method_84);
      this.dxfGroupCollection_0.Inserted -= new ItemEventHandler<DxfGroup>(this.method_85);
      this.dxfGroupCollection_0.Removed -= new ItemEventHandler<DxfGroup>(this.method_86);
      this.dxfGroupCollection_0.Set -= new ItemSetEventHandler<DxfGroup>(this.method_87);
      this.dxfScaleCollection_0.Added -= new ItemEventHandler<DxfScale>(this.method_88);
      this.dxfScaleCollection_0.Removed -= new ItemEventHandler<DxfScale>(this.method_89);
      this.dxfScaleCollection_0.Set -= new ItemSetEventHandler<DxfScale>(this.method_90);
      this.dxfMLeaderStyleCollection_0.Added -= new ItemEventHandler<DxfMLeaderStyle>(this.method_91);
      this.dxfMLeaderStyleCollection_0.Removed -= new ItemEventHandler<DxfMLeaderStyle>(this.method_92);
      this.dxfMLeaderStyleCollection_0.Set -= new ItemSetEventHandler<DxfMLeaderStyle>(this.method_93);
      this.dxfMLineStyleCollection_0.Added -= new ItemEventHandler<DxfMLineStyle>(this.method_94);
      this.dxfMLineStyleCollection_0.Removed -= new ItemEventHandler<DxfMLineStyle>(this.method_95);
      this.dxfMLineStyleCollection_0.Set -= new ItemSetEventHandler<DxfMLineStyle>(this.method_96);
      this.dxfTextStyleCollection_0.Added -= new ItemEventHandler<DxfTextStyle>(this.method_55);
      this.dxfTextStyleCollection_0.Removed -= new ItemEventHandler<DxfTextStyle>(this.method_56);
      this.dxfTextStyleCollection_0.Set -= new ItemSetEventHandler<DxfTextStyle>(this.method_57);
      this.dxfLineTypeCollection_0.Inserted -= new ItemEventHandler<DxfLineType>(this.method_58);
      this.dxfLineTypeCollection_0.Removed -= new ItemEventHandler<DxfLineType>(this.method_59);
      this.dxfLineTypeCollection_0.Set -= new ItemSetEventHandler<DxfLineType>(this.method_60);
      this.dxfUcsCollection_0.Inserted -= new ItemEventHandler<DxfUcs>(this.method_61);
      this.dxfUcsCollection_0.Removed -= new ItemEventHandler<DxfUcs>(this.method_62);
      this.dxfUcsCollection_0.Set -= new ItemSetEventHandler<DxfUcs>(this.method_63);
      this.dxfViewCollection_0.Inserted -= new ItemEventHandler<DxfView>(this.method_64);
      this.dxfViewCollection_0.Removed -= new ItemEventHandler<DxfView>(this.method_65);
      this.dxfViewCollection_0.Set -= new ItemSetEventHandler<DxfView>(this.method_66);
      this.dxfDimensionStyleCollection_0.Inserted -= new ItemEventHandler<DxfDimensionStyle>(this.method_67);
      this.dxfDimensionStyleCollection_0.Removed -= new ItemEventHandler<DxfDimensionStyle>(this.method_68);
      this.dxfDimensionStyleCollection_0.Set -= new ItemSetEventHandler<DxfDimensionStyle>(this.method_69);
      this.dxfVPortCollection_0.Added -= new ItemEventHandler<DxfVPort>(this.method_70);
      this.dxfVPortCollection_0.Removed -= new ItemEventHandler<DxfVPort>(this.method_71);
      this.dxfVPortCollection_0.Set -= new ItemSetEventHandler<DxfVPort>(this.method_72);
      this.dxfTableStyleCollection_0.Inserted -= new ItemEventHandler<DxfTableStyle>(this.method_73);
      this.dxfTableStyleCollection_0.Removed -= new ItemEventHandler<DxfTableStyle>(this.method_74);
      this.dxfTableStyleCollection_0.Set -= new ItemSetEventHandler<DxfTableStyle>(this.method_75);
      this.class28_0.Added -= new ItemEventHandler<DxfViewportEntityHeader>(this.method_76);
      this.class28_0.Removed -= new ItemEventHandler<DxfViewportEntityHeader>(this.method_77);
      this.class28_0.Set -= new ItemSetEventHandler<DxfViewportEntityHeader>(this.method_78);
    }

    internal void method_38(
      DxfBlock block,
      IList<DxfMessage> messages,
      bool mergeIfNonAnonymousDuplicate)
    {
      if (block.IsReallyAnonymous)
      {
        this.method_98(block, messages);
        this.dxfBlockCollection_1.Add(block);
      }
      else if (mergeIfNonAnonymousDuplicate)
      {
        DxfBlock dxfBlock;
        if (this.dxfBlockCollection_0.TryGetValue(block.Name, out dxfBlock))
        {
          dxfBlock.Entities.AddRange((IEnumerable<DxfEntity>) block.Entities);
          if (messages == null)
            return;
          messages.Add(new DxfMessage(DxfStatus.MergedDuplicateBlock, Severity.Warning)
          {
            Parameters = {
              {
                "Class",
                (object) block.GetType().FullName
              },
              {
                "BlockName",
                (object) block.Name
              },
              {
                "Handle",
                (object) block.Handle
              },
              {
                "ExistingHandle",
                (object) dxfBlock.Handle
              }
            }
          });
        }
        else
          this.dxfBlockCollection_0.Add(block);
      }
      else
        this.dxfBlockCollection_0.Add(block);
    }

    private void method_39(object sender, int index, DxfBlock oldItem, DxfBlock newItem)
    {
      DxfModel.smethod_3(oldItem);
      this.method_42(newItem);
    }

    private void method_40(object sender, int index, DxfBlock item)
    {
      this.method_42(item);
    }

    private void method_41(object sender, int index, DxfBlock item)
    {
      DxfModel.smethod_3(item);
    }

    private void method_42(DxfBlock blockRecord)
    {
      blockRecord.vmethod_2((IDxfHandledObject) this.BlockRecordTable);
    }

    private static void smethod_3(DxfBlock blockRecord)
    {
      blockRecord.vmethod_2((IDxfHandledObject) null);
    }

    private void method_43(object sender, int index, DxfAppId item)
    {
      item.vmethod_3(this);
    }

    private void method_44(object sender, int index, DxfAppId item)
    {
      item.vmethod_4(this);
    }

    private void method_45(object sender, int index, DxfAppId oldItem, DxfAppId newItem)
    {
      oldItem.vmethod_3(this);
      newItem.vmethod_3(this);
    }

    private void method_46(object sender, int index, DxfLayer item)
    {
      item.vmethod_3(this);
    }

    private void method_47(object sender, int index, DxfLayer item)
    {
      item.vmethod_4(this);
    }

    private void method_48(object sender, int index, DxfLayer oldItem, DxfLayer newItem)
    {
      oldItem.vmethod_4(this);
      newItem.vmethod_3(this);
    }

    private void method_49(object sender, int index, DxfImageDef item)
    {
      if (this.DictionaryAcadImage == null || this.DictionaryAcadImage.Entries.Contains(item.Filename))
        return;
      this.DictionaryAcadImage.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(item.Filename, (DxfObject) item));
    }

    private void method_50(object sender, int index, DxfImageDef item)
    {
      if (this.DictionaryAcadImage == null)
        return;
      this.DictionaryAcadImage.Entries.RemoveAll(item.Filename);
    }

    private void method_51(object sender, int index, DxfImageDef oldItem, DxfImageDef newItem)
    {
      if (this.DictionaryAcadImage == null)
        return;
      this.DictionaryAcadImage.Entries.RemoveAll(oldItem.Filename);
      this.DictionaryAcadImage.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(newItem.Filename, (DxfObject) newItem));
    }

    private void method_52(object sender, int index, DxfPlotSettings item)
    {
      if (!this.bool_0 || this.DictionaryAcadPlotSettings == null || this.DictionaryAcadPlotSettings.Entries.Contains(item.PageSetupName))
        return;
      this.DictionaryAcadPlotSettings.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(item.PageSetupName, (DxfObject) item));
    }

    private void method_53(object sender, int index, DxfPlotSettings item)
    {
      if (!this.bool_0 || this.DictionaryAcadPlotSettings == null)
        return;
      this.DictionaryAcadPlotSettings.Entries.RemoveAll(item.PageSetupName);
    }

    private void method_54(
      object sender,
      int index,
      DxfPlotSettings oldItem,
      DxfPlotSettings newItem)
    {
      if (!this.bool_0 || this.DictionaryAcadPlotSettings == null)
        return;
      this.DictionaryAcadPlotSettings.Entries.RemoveAll(oldItem.PageSetupName);
      this.DictionaryAcadPlotSettings.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(newItem.PageSetupName, (DxfObject) newItem));
    }

    private void method_55(object sender, int index, DxfTextStyle item)
    {
      item.vmethod_3(this);
    }

    private void method_56(object sender, int index, DxfTextStyle item)
    {
      item.vmethod_4(this);
    }

    private void method_57(object sender, int index, DxfTextStyle oldItem, DxfTextStyle newItem)
    {
      oldItem.vmethod_4(this);
      newItem.vmethod_3(this);
    }

    private void method_58(object sender, int index, DxfLineType item)
    {
      item.vmethod_3(this);
    }

    private void method_59(object sender, int index, DxfLineType item)
    {
      item.vmethod_4(this);
    }

    private void method_60(object sender, int index, DxfLineType oldItem, DxfLineType newItem)
    {
      oldItem.vmethod_4(this);
      newItem.vmethod_3(this);
    }

    private void method_61(object sender, int index, DxfUcs item)
    {
      item.vmethod_3(this);
    }

    private void method_62(object sender, int index, DxfUcs item)
    {
      item.vmethod_4(this);
    }

    private void method_63(object sender, int index, DxfUcs oldItem, DxfUcs newItem)
    {
      oldItem.vmethod_4(this);
      newItem.vmethod_3(this);
    }

    private void method_64(object sender, int index, DxfView item)
    {
      item.vmethod_3(this);
    }

    private void method_65(object sender, int index, DxfView item)
    {
      item.vmethod_4(this);
    }

    private void method_66(object sender, int index, DxfView oldItem, DxfView newItem)
    {
      oldItem.vmethod_4(this);
      newItem.vmethod_3(this);
    }

    private void method_67(object sender, int index, DxfDimensionStyle item)
    {
      item.vmethod_3(this);
    }

    private void method_68(object sender, int index, DxfDimensionStyle item)
    {
      item.vmethod_4(this);
    }

    private void method_69(
      object sender,
      int index,
      DxfDimensionStyle oldItem,
      DxfDimensionStyle newItem)
    {
      oldItem.vmethod_4(this);
      newItem.vmethod_3(this);
    }

    private void method_70(object sender, int index, DxfVPort item)
    {
      item.vmethod_3(this);
    }

    private void method_71(object sender, int index, DxfVPort item)
    {
      item.vmethod_4(this);
    }

    private void method_72(object sender, int index, DxfVPort oldItem, DxfVPort newItem)
    {
      oldItem.vmethod_4(this);
      newItem.vmethod_3(this);
    }

    private void method_73(object sender, int index, DxfTableStyle item)
    {
      if (!this.bool_0 || this.DictionaryAcadTableStyle == null || item == null)
        return;
      if (!this.DictionaryAcadTableStyle.Entries.Contains(item.Name))
        this.DictionaryAcadTableStyle.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry((DxfObject) item));
      item.vmethod_3(this);
    }

    private void method_74(object sender, int index, DxfTableStyle item)
    {
      if (!this.bool_0 || this.DictionaryAcadTableStyle == null || item == null)
        return;
      item.vmethod_4(this);
      this.DictionaryAcadTableStyle.Entries.RemoveAll(item.Name);
    }

    private void method_75(object sender, int index, DxfTableStyle oldItem, DxfTableStyle newItem)
    {
      if (!this.bool_0 || this.DictionaryAcadTableStyle == null)
        return;
      if (oldItem != null)
      {
        oldItem.vmethod_4(this);
        this.DictionaryAcadTableStyle.Entries.RemoveAll(oldItem.Name);
      }
      if (newItem == null)
        return;
      if (!this.DictionaryAcadTableStyle.Entries.Contains(newItem.Name))
        this.DictionaryAcadTableStyle.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(newItem.Name, (DxfObject) newItem, true));
      newItem.vmethod_3(this);
    }

    private void method_76(object sender, int index, DxfViewportEntityHeader item)
    {
      item.vmethod_3(this);
    }

    private void method_77(object sender, int index, DxfViewportEntityHeader item)
    {
      item.vmethod_4(this);
    }

    private void method_78(
      object sender,
      int index,
      DxfViewportEntityHeader oldItem,
      DxfViewportEntityHeader newItem)
    {
      newItem.vmethod_3(this);
      oldItem.vmethod_4(this);
    }

    private void method_79(object sender, int index, DxfLayout item)
    {
      item.vmethod_3(this);
    }

    private void method_80(object sender, int index, DxfLayout item)
    {
      item.vmethod_4(this);
      if (item != this.ActiveLayout)
        return;
      this.method_0((DxfLayout) null);
    }

    private void method_81(object sender, int index, DxfLayout oldItem, DxfLayout newItem)
    {
      oldItem.vmethod_4(this);
      newItem.vmethod_3(this);
      if (oldItem != this.ActiveLayout)
        return;
      this.method_0((DxfLayout) null);
    }

    private void method_82(object sender, int index, DxfColor item)
    {
      string name = item.Color.method_0();
      if (this.DictionaryAcadColor == null || this.DictionaryAcadColor.Entries.Contains(item.Color.Name))
        return;
      this.DictionaryAcadColor.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(name, (DxfObject) item));
    }

    private void method_83(object sender, int index, DxfColor item)
    {
      string entryName = item.Color.method_0();
      if (this.DictionaryAcadColor == null)
        return;
      this.DictionaryAcadColor.Entries.RemoveAll(entryName);
    }

    private void method_84(object sender, int index, DxfColor oldItem, DxfColor newItem)
    {
      string entryName = oldItem.Color.method_0();
      string name = newItem.Color.method_0();
      if (this.DictionaryAcadColor == null)
        return;
      this.DictionaryAcadColor.Entries.RemoveAll(entryName);
      this.DictionaryAcadColor.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(name, (DxfObject) newItem));
    }

    private void method_85(object sender, int index, DxfGroup item)
    {
      if (this.DictionaryAcadGroup == null || this.DictionaryAcadGroup.Entries.Contains(item.Name))
        return;
      this.DictionaryAcadGroup.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(item.Name, (DxfObject) item));
    }

    private void method_86(object sender, int index, DxfGroup item)
    {
      if (this.DictionaryAcadGroup == null)
        return;
      this.DictionaryAcadGroup.Entries.RemoveAll(item.Name);
    }

    private void method_87(object sender, int index, DxfGroup oldItem, DxfGroup newItem)
    {
      if (this.DictionaryAcadGroup == null)
        return;
      this.DictionaryAcadGroup.Entries.RemoveAll(oldItem.Name);
      this.DictionaryAcadGroup.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(newItem.Name, (DxfObject) newItem));
    }

    private void method_88(object sender, int index, DxfScale item)
    {
      if (this.DictionaryAcadScaleList == null)
        return;
      this.DictionaryAcadScaleList.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("*A", (DxfObject) item));
    }

    private void method_89(object sender, int index, DxfScale item)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfModel.Class983 class983 = new DxfModel.Class983();
      // ISSUE: reference to a compiler-generated field
      class983.dxfScale_0 = item;
      if (this.DictionaryAcadScaleList == null)
        return;
      // ISSUE: reference to a compiler-generated method
      this.DictionaryAcadScaleList.Entries.Remove(this.DictionaryAcadScaleList.Entries.First<IDictionaryEntry>(new Func<IDictionaryEntry, bool>(class983.method_0)));
    }

    private void method_90(object sender, int index, DxfScale oldItem, DxfScale newItem)
    {
      if (this.DictionaryAcadScaleList != null)
        throw new NotImplementedException();
    }

    private void method_91(object sender, int index, DxfMLeaderStyle item)
    {
      if (this.DictionaryAcadMLeaderStyle == null || this.DictionaryAcadMLeaderStyle.Entries.Contains(item.Name))
        return;
      this.DictionaryAcadMLeaderStyle.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(item.Name, (DxfObject) item));
    }

    private void method_92(object sender, int index, DxfMLeaderStyle item)
    {
      if (this.DictionaryAcadMLeaderStyle == null)
        return;
      this.DictionaryAcadMLeaderStyle.Entries.RemoveAll(item.Name);
    }

    private void method_93(
      object sender,
      int index,
      DxfMLeaderStyle oldItem,
      DxfMLeaderStyle newItem)
    {
      if (this.DictionaryAcadMLeaderStyle == null)
        return;
      this.DictionaryAcadMLeaderStyle.Entries.RemoveAll(oldItem.Name);
      this.DictionaryAcadMLeaderStyle.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(newItem.Name, (DxfObject) newItem));
    }

    private void method_94(object sender, int index, DxfMLineStyle item)
    {
      if (this.DictionaryAcadMLineStyle == null || this.DictionaryAcadMLineStyle.Entries.Contains(item.Name))
        return;
      this.DictionaryAcadMLineStyle.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(item.Name, (DxfObject) item));
    }

    private void method_95(object sender, int index, DxfMLineStyle item)
    {
      if (this.DictionaryAcadMLineStyle == null)
        return;
      this.DictionaryAcadMLineStyle.Entries.RemoveAll(item.Name);
    }

    private void method_96(object sender, int index, DxfMLineStyle oldItem, DxfMLineStyle newItem)
    {
      if (this.DictionaryAcadMLineStyle == null)
        return;
      this.DictionaryAcadMLineStyle.Entries.RemoveAll(oldItem.Name);
      this.DictionaryAcadMLineStyle.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(newItem.Name, (DxfObject) newItem));
    }

    internal ulong method_97()
    {
      ulong num = this.dxfHeader_0.HandleSeed;
      if (num == 0UL)
        num = 1UL;
      this.dxfHeader_0.HandleSeed = num + 1UL;
      return num;
    }

    internal void method_98(DxfBlock blockToBeAdded, IList<DxfMessage> messages)
    {
      if (!blockToBeAdded.IsReallyAnonymous)
        return;
      if (blockToBeAdded.Name.StartsWith("*D"))
      {
        if (!this.dxfBlockCollection_1.Contains(blockToBeAdded.Name))
          return;
        this.method_99(blockToBeAdded, messages);
      }
      else if (blockToBeAdded.Name.StartsWith("*T"))
      {
        if (!this.dxfBlockCollection_1.Contains(blockToBeAdded.Name))
          return;
        this.method_100(blockToBeAdded, messages);
      }
      else if (blockToBeAdded.Name.StartsWith("*U"))
      {
        if (!this.dxfBlockCollection_1.Contains(blockToBeAdded.Name))
          return;
        this.method_101(blockToBeAdded, "*U{0}", new Func<uint>(this.method_112), messages);
      }
      else if (blockToBeAdded.Name.StartsWith("*E"))
      {
        if (!this.dxfBlockCollection_1.Contains(blockToBeAdded.Name))
          return;
        this.method_101(blockToBeAdded, "*E{0}", new Func<uint>(this.method_113), messages);
      }
      else if (blockToBeAdded.Name.StartsWith("*X"))
      {
        if (!this.dxfBlockCollection_1.Contains(blockToBeAdded.Name))
          return;
        this.method_101(blockToBeAdded, "*X{0}", new Func<uint>(this.method_114), messages);
      }
      else if (blockToBeAdded.Name.StartsWith("*A"))
      {
        if (!this.dxfBlockCollection_1.Contains(blockToBeAdded.Name))
          return;
        this.method_101(blockToBeAdded, "*A{0}", new Func<uint>(this.method_115), messages);
      }
      else if (blockToBeAdded.Name.StartsWith("*"))
      {
        if (!this.dxfBlockCollection_1.Contains(blockToBeAdded.Name))
          return;
        string name = blockToBeAdded.Name;
        int index = name.Length - 1;
        while (index >= 0 && char.IsDigit(name[index]))
          --index;
        string str1 = name.Substring(0, index + 1);
        int num = 1;
        string str2;
        for (str2 = str1 + num.ToString(); this.dxfBlockCollection_1.Contains(str2); str2 = str1 + num.ToString())
          ++num;
        DxfModel.smethod_4(messages, (object) blockToBeAdded, blockToBeAdded.Name, str2);
        blockToBeAdded.Name = str2;
      }
      else
      {
        if (!string.IsNullOrEmpty(blockToBeAdded.Name))
          return;
        this.method_101(blockToBeAdded, "NAMELESS_{0}", new Func<uint>(this.method_116), messages);
      }
    }

    private static void smethod_4(
      IList<DxfMessage> messages,
      object o,
      string oldName,
      string newName)
    {
      if (messages == null)
        return;
      messages.Add(new DxfMessage(DxfStatus.AuditRepairedDuplicateName, Severity.Warning)
      {
        Parameters = {
          {
            "Class",
            (object) o.GetType().FullName
          },
          {
            "OriginalName",
            (object) oldName
          },
          {
            "RepairedName",
            (object) newName
          }
        }
      });
    }

    internal void method_99(DxfBlock block, IList<DxfMessage> messages)
    {
      bool flag = false;
      string str = (string) null;
      for (; !flag; flag = !this.dxfBlockCollection_1.Contains(str))
        str = string.Format("*D{0}", (object) this.method_110());
      DxfModel.smethod_4(messages, (object) block, block.Name, str);
      block.Name = str;
    }

    internal void method_100(DxfBlock block, IList<DxfMessage> messages)
    {
      bool flag = false;
      string str = (string) null;
      for (; !flag; flag = !this.dxfBlockCollection_1.Contains(str))
        str = string.Format("*T{0}", (object) this.method_111());
      DxfModel.smethod_4(messages, (object) block, block.Name, str);
      block.Name = str;
    }

    internal void method_101(
      DxfBlock block,
      string format,
      Func<uint> getanonymousBlockNumber,
      IList<DxfMessage> messages)
    {
      bool flag = false;
      string str = (string) null;
      for (; !flag; flag = !this.dxfBlockCollection_1.Contains(str))
        str = string.Format(format, (object) getanonymousBlockNumber());
      DxfModel.smethod_4(messages, (object) block, block.Name, str);
      block.Name = str;
    }

    private void method_102(DxfHandledObject handledObject)
    {
      if (handledObject.Handle != 0UL)
        return;
      handledObject.SetHandle(this.method_97());
    }

    public void ClearHandle(DxfHandledObject handledObject)
    {
      handledObject.SetHandle(0UL);
    }

    private void method_103(DxfModel from)
    {
      this.summaryInfo_0 = new SummaryInfo(from.summaryInfo_0);
      this.securityFlags_0 = from.securityFlags_0;
      this.int_0 = from.int_0;
    }

    private void method_104(DxfModel from, CloneContext cloneContext)
    {
      this.VPortTable.CopyFrom(from.VPortTable, cloneContext);
      this.LineTypeTable.CopyFrom(from.LineTypeTable, cloneContext);
      this.LayerTable.CopyFrom(from.LayerTable, cloneContext);
      this.TextStyleTable.CopyFrom(from.TextStyleTable, cloneContext);
      this.ViewTable.CopyFrom(from.ViewTable, cloneContext);
      this.UcsTable.CopyFrom(from.UcsTable, cloneContext);
      this.AppIdTable.CopyFrom(from.AppIdTable, cloneContext);
      this.DimStyleTable.CopyFrom(from.DimStyleTable, cloneContext);
      this.BlockRecordTable.CopyFrom(from.BlockRecordTable, cloneContext);
      this.ViewportEntityHeaderTable.CopyFrom(from.ViewportEntityHeaderTable, cloneContext);
      this.dxfAppIdCollection_0.AddCopiesFrom((ActiveKeyedDxfHandledObjectCollection<string, DxfAppId>) from.dxfAppIdCollection_0, cloneContext);
      foreach (DxfTextStyle dxfTextStyle in (DxfHandledObjectCollection<DxfTextStyle>) from.dxfTextStyleCollection_0)
      {
        if (cloneContext.AllowDuplicateNames || !this.dxfTextStyleCollection_0.Contains(dxfTextStyle.Name))
          this.dxfTextStyleCollection_0.Add((DxfTextStyle) dxfTextStyle.Clone(cloneContext));
      }
      this.dxfLineTypeCollection_0.AddCopiesFrom((ActiveKeyedDxfHandledObjectCollection<string, DxfLineType>) from.dxfLineTypeCollection_0, cloneContext);
      this.dxfLayerCollection_0.AddCopiesFrom((ActiveKeyedDxfHandledObjectCollection<string, DxfLayer>) from.dxfLayerCollection_0, cloneContext);
      this.dxfDimensionStyleCollection_0.AddCopiesFrom((ActiveKeyedDxfHandledObjectCollection<string, DxfDimensionStyle>) from.dxfDimensionStyleCollection_0, cloneContext);
      this.dxfUcsCollection_0.AddCopiesFrom((ActiveKeyedDxfHandledObjectCollection<string, DxfUcs>) from.dxfUcsCollection_0, cloneContext);
      this.dxfViewCollection_0.AddCopiesFrom((ActiveKeyedDxfHandledObjectCollection<string, DxfView>) from.dxfViewCollection_0, cloneContext);
      foreach (DxfVPort dxfVport in (DxfHandledObjectCollection<DxfVPort>) from.dxfVPortCollection_0)
      {
        if (cloneContext.AllowDuplicateNames || !this.dxfVPortCollection_0.Contains(dxfVport.Name))
          this.dxfVPortCollection_0.Add((DxfVPort) dxfVport.Clone(cloneContext));
      }
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfViewportEntityHeader>) from.class28_0)
        this.class28_0.Add((DxfViewportEntityHeader) dxfHandledObject.Clone(cloneContext));
    }

    private void method_105(DxfModel from, CloneContext cloneContext)
    {
      foreach (DxfClass dxfClass in (List<DxfClass>) from.Classes)
        this.dxfClassCollection_0.Add((DxfClass) dxfClass.Clone(cloneContext));
    }

    private void method_106(DxfModel from, CloneContext cloneContext)
    {
      List<Pair<DxfBlock, DxfBlock>> blocksToBeCopied = new List<Pair<DxfBlock, DxfBlock>>();
      foreach (DxfBlock dxfBlock in (KeyedDxfHandledObjectCollection<string, DxfBlock>) from.dxfBlockCollection_1)
      {
        if (string.Compare("*Model_Space", dxfBlock.Name, StringComparison.InvariantCultureIgnoreCase) == 0)
        {
          DxfBlock second;
          if (this.dxfBlockCollection_1.TryGetValue("*Model_Space", out second))
          {
            dxfBlock.RegisterClone(cloneContext, (IGraphCloneable) second);
            Pair<DxfBlock, DxfBlock> pair = new Pair<DxfBlock, DxfBlock>(dxfBlock, second);
            blocksToBeCopied.Add(pair);
          }
          else
            this.dxfBlockCollection_1.Add(this.method_107(cloneContext, blocksToBeCopied, dxfBlock, dxfBlock.Name));
        }
        else
          this.dxfBlockCollection_1.Add(this.method_107(cloneContext, blocksToBeCopied, dxfBlock, dxfBlock.Name));
      }
      foreach (DxfBlock block in (KeyedDxfHandledObjectCollection<string, DxfBlock>) from.dxfBlockCollection_0)
      {
        string name = block.Name;
        bool flag = true;
        if (this.dxfBlockCollection_0.Contains(block.Name))
        {
          if (cloneContext.RenameClashingBlocks)
            name = Class906.smethod_1<DxfBlock>((KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfBlockCollection_0, name, cloneContext.TargetModel.Header.Dxf13OrHigher);
          else
            flag = false;
        }
        if (flag)
          this.dxfBlockCollection_0.Add(this.method_107(cloneContext, blocksToBeCopied, block, name));
      }
      foreach (Pair<DxfBlock, DxfBlock> pair in blocksToBeCopied)
      {
        string name = pair.Second.Name;
        pair.Second.CopyFrom((DxfHandledObject) pair.First, cloneContext);
        pair.Second.method_9(name);
      }
    }

    private DxfBlock method_107(
      CloneContext cloneContext,
      List<Pair<DxfBlock, DxfBlock>> blocksToBeCopied,
      DxfBlock block,
      string name)
    {
      DxfBlock dxfBlock = (DxfBlock) cloneContext.GetExistingClone((IGraphCloneable) block);
      if (dxfBlock == null)
      {
        dxfBlock = new DxfBlock(name);
        Pair<DxfBlock, DxfBlock> pair = new Pair<DxfBlock, DxfBlock>(block, dxfBlock);
        block.RegisterClone(cloneContext, (IGraphCloneable) dxfBlock);
        blocksToBeCopied.Add(pair);
        this.method_98(dxfBlock, (IList<DxfMessage>) null);
      }
      return dxfBlock;
    }

    private void method_108(DxfModel from, CloneContext cloneContext)
    {
      this.DictionaryRoot = (DxfDictionary) from.DictionaryRoot.Clone(cloneContext);
      this.method_37();
      this.method_2();
      if (this.DictionaryAcadColor != null)
      {
        foreach (IDictionaryEntry entry in (ActiveList<IDictionaryEntry>) this.DictionaryAcadColor.Entries)
        {
          DxfColor dxfColor = entry.Value as DxfColor;
          if (dxfColor != null)
            this.dxfColorCollection_0.Add(dxfColor);
        }
      }
      if (this.DictionaryAcadGroup != null)
      {
        foreach (IDictionaryEntry entry in (ActiveList<IDictionaryEntry>) this.DictionaryAcadGroup.Entries)
        {
          DxfGroup dxfGroup = entry.Value as DxfGroup;
          if (dxfGroup != null)
            this.dxfGroupCollection_0.Add(dxfGroup);
        }
      }
      if (this.DictionaryAcadMLeaderStyle != null)
      {
        foreach (IDictionaryEntry entry in (ActiveList<IDictionaryEntry>) this.DictionaryAcadMLeaderStyle.Entries)
        {
          DxfMLeaderStyle dxfMleaderStyle = entry.Value as DxfMLeaderStyle;
          if (dxfMleaderStyle != null)
            this.dxfMLeaderStyleCollection_0.Add(dxfMleaderStyle);
        }
      }
      if (this.DictionaryAcadMLineStyle != null)
      {
        foreach (IDictionaryEntry entry in (ActiveList<IDictionaryEntry>) this.DictionaryAcadMLineStyle.Entries)
        {
          DxfMLineStyle dxfMlineStyle = entry.Value as DxfMLineStyle;
          if (dxfMlineStyle != null)
            this.dxfMLineStyleCollection_0.Add(dxfMlineStyle);
        }
      }
      if (this.DictionaryAcadLayout != null)
      {
        foreach (IDictionaryEntry entry in (ActiveList<IDictionaryEntry>) this.DictionaryAcadLayout.Entries)
        {
          DxfLayout dxfLayout = entry.Value as DxfLayout;
          if (dxfLayout != null)
            this.dxfLayoutCollection_0.Add(dxfLayout);
        }
      }
      if (this.DictionaryAcadImage != null)
      {
        foreach (IDictionaryEntry entry in (ActiveList<IDictionaryEntry>) this.DictionaryAcadImage.Entries)
        {
          DxfImageDef dxfImageDef = entry.Value as DxfImageDef;
          if (dxfImageDef != null)
            this.dxfImageDefCollection_0.Add(dxfImageDef);
        }
      }
      if (this.DictionaryAcadTableStyle != null)
      {
        bool bool0 = this.bool_0;
        if (this.bool_0)
          this.Deactivate();
        this.dxfTableStyleCollection_0.Clear();
        foreach (IDictionaryEntry entry in (ActiveList<IDictionaryEntry>) this.DictionaryAcadTableStyle.Entries)
        {
          DxfTableStyle dxfTableStyle = entry.Value as DxfTableStyle;
          if (dxfTableStyle != null)
            this.dxfTableStyleCollection_0.Add(dxfTableStyle);
        }
        if (bool0)
          this.method_33();
      }
      this.method_35();
    }

    private void method_109(CloneContext cloneContext)
    {
      cloneContext.ResolveReferences();
      this.CreateDefaultObjects(true);
    }

    private uint method_110()
    {
      return this.uint_1++;
    }

    private uint method_111()
    {
      return this.uint_2++;
    }

    internal uint method_112()
    {
      return this.uint_3++;
    }

    internal uint method_113()
    {
      return this.uint_4++;
    }

    internal uint method_114()
    {
      return this.uint_5++;
    }

    internal uint method_115()
    {
      return this.uint_6++;
    }

    internal uint method_116()
    {
      return this.uint_7++;
    }

    private void method_117()
    {
      lock (this.dictionary_1)
        this.dictionary_1.Clear();
      string[] strArray = Class1043.smethod_2(this.string_3);
      int num = 0;
      lock (DxfModel.list_0)
      {
        this.string_4 = new string[DxfModel.list_0.Count + strArray.Length];
        foreach (string str in DxfModel.list_0)
          this.string_4[num++] = str;
      }
      foreach (string str in strArray)
        this.string_4[num++] = str;
    }

    private static DxfDictionary smethod_5(IDictionaryEntry dictionaryEntry)
    {
      if (dictionaryEntry == null)
        return (DxfDictionary) null;
      return (DxfDictionary) dictionaryEntry.Value;
    }

    private static DxfDictionaryWithDefault smethod_6(
      IDictionaryEntry dictionaryEntry)
    {
      if (dictionaryEntry == null)
        return (DxfDictionaryWithDefault) null;
      return (DxfDictionaryWithDefault) dictionaryEntry.Value;
    }

    private static DxfXRecord smethod_7(IDictionaryEntry dictionaryEntry)
    {
      if (dictionaryEntry == null)
        return (DxfXRecord) null;
      return (DxfXRecord) dictionaryEntry.Value;
    }

    private static DxfObject GetValue(IDictionaryEntry dictionaryEntry)
    {
      return dictionaryEntry?.Value;
    }

    public static void AddShxLookupDirectories(params string[] directories)
    {
      lock (DxfModel.list_0)
      {
        if (directories == null)
          return;
        foreach (string directory in directories)
        {
          if (!DxfModel.list_0.Contains(directory))
            DxfModel.list_0.Add(directory);
        }
      }
    }

    public static void ClearShxLookupDirectories()
    {
      lock (DxfModel.list_0)
        DxfModel.list_0.Clear();
    }

    public static IList<string> GlobalShxLookupDirectories
    {
      get
      {
        lock (DxfModel.list_0)
          return (IList<string>) new List<string>((IEnumerable<string>) DxfModel.list_0);
      }
    }

    public static string FallbackShxFont
    {
      get
      {
        lock (DxfModel.list_0)
          return DxfModel.string_1;
      }
      set
      {
        if (value == null)
        {
          lock (DxfModel.list_0)
            DxfModel.string_1 = (string) null;
        }
        else
        {
          if (!value.ToLowerInvariant().EndsWith(".shx"))
            value += ".shx";
          lock (DxfModel.list_0)
            DxfModel.string_1 = value;
        }
      }
    }

    public static string FallbackTrueTypeFont
    {
      get
      {
        lock (DxfModel.list_0)
          return DxfModel.string_2;
      }
      set
      {
        if (value == null)
        {
          lock (DxfModel.list_0)
            DxfModel.string_2 = (string) null;
        }
        else
        {
          lock (DxfModel.list_0)
            DxfModel.string_2 = value;
        }
      }
    }

    public object Clone()
    {
      return (object) new DxfModel(this);
    }

    private class Class981
    {
      private readonly Dictionary<ulong, DxfHandledObject> dictionary_0 = new Dictionary<ulong, DxfHandledObject>();
      private ulong ulong_0;

      internal Class981()
      {
      }

      internal ulong MaxHandle
      {
        get
        {
          return this.ulong_0;
        }
      }

      internal void method_0(DxfHandledObject handledObject)
      {
        ulong handle = handledObject.Handle;
        if (handle == 0UL)
          return;
        DxfHandledObject dxfHandledObject;
        if (this.dictionary_0.TryGetValue(handle, out dxfHandledObject))
        {
          if (!object.ReferenceEquals((object) dxfHandledObject, (object) handledObject))
            throw new DxfException("Duplicate handle " + DxfHandledObject.Class9.smethod_0(handle) + " encountered!\nThis is usually the result of combining models in an incorrect way.\nAs a workaround you can call ResetHandles() on the DxfModel,\nbefore the operation resulting in this exception,\nbut there may be more problems ahead.");
        }
        else
        {
          this.dictionary_0.Add(handle, handledObject);
          if (handle <= this.ulong_0)
            return;
          this.ulong_0 = handle;
        }
      }
    }
  }
}
