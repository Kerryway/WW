// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfDictionary
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Collections.Generic;

namespace WW.Cad.Model.Objects
{
  public class DxfDictionary : DxfObject
  {
    private DuplicateRecordCloning duplicateRecordCloning_0 = DuplicateRecordCloning.KeepExisting;
    private DxfDictionaryEntryCollection dxfDictionaryEntryCollection_0 = new DxfDictionaryEntryCollection();
    private bool bool_0;

    public DxfDictionary()
      : this(true)
    {
    }

    protected DxfDictionary(bool subscribeToEvents)
    {
      if (!subscribeToEvents)
        return;
      this.method_9();
    }

    public bool HardOwner
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

    public DuplicateRecordCloning DuplicateRecordCloning
    {
      get
      {
        return this.duplicateRecordCloning_0;
      }
      set
      {
        this.duplicateRecordCloning_0 = value;
      }
    }

    public DxfDictionaryEntryCollection Entries
    {
      get
      {
        return this.dxfDictionaryEntryCollection_0;
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return 42;
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf13OrHigher;
    }

    public override string ObjectType
    {
      get
      {
        return "DICTIONARY";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbDictionary";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      foreach (IDictionaryEntry dictionaryEntry in (ActiveList<IDictionaryEntry>) this.dxfDictionaryEntryCollection_0)
      {
        if (dictionaryEntry.Value != null)
          dictionaryEntry.Value.vmethod_1(context);
      }
    }

    protected internal override void ExecuteDeepHelper(
      Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      foreach (IDictionaryEntry dictionaryEntry in (ActiveList<IDictionaryEntry>) this.dxfDictionaryEntryCollection_0)
      {
        if (dictionaryEntry.Value != null)
          dictionaryEntry.Value.vmethod_0(action, callerStack);
      }
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      bool flag = true;
      foreach (IDictionaryEntry dictionaryEntry in (ActiveList<IDictionaryEntry>) this.dxfDictionaryEntryCollection_0)
      {
        if (dictionaryEntry != null && dictionaryEntry.Value != null && !dictionaryEntry.Value.Validate(model, messages))
          flag = false;
      }
      if (!base.Validate(model, messages))
        flag = false;
      return flag;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfDictionary dictionary = (DxfDictionary) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dictionary == null)
      {
        dictionary = new DxfDictionary(false);
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dictionary);
        dictionary.CopyFrom((DxfHandledObject) this, cloneContext);
        cloneContext.CloneBuilders.Add((ICloneBuilder) new DxfDictionary.Class753(dictionary));
      }
      return (IGraphCloneable) dictionary;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfDictionary dxfDictionary = (DxfDictionary) from;
      this.bool_0 = dxfDictionary.bool_0;
      this.duplicateRecordCloning_0 = dxfDictionary.duplicateRecordCloning_0;
      foreach (DxfDictionaryEntry dxfDictionaryEntry1 in (ActiveList<IDictionaryEntry>) dxfDictionary.dxfDictionaryEntryCollection_0)
      {
        DxfDictionaryEntry dxfDictionaryEntry2 = (DxfDictionaryEntry) dxfDictionaryEntry1.Clone(cloneContext);
        if (dxfDictionaryEntry2.Value != null)
        {
          dxfDictionaryEntry2.Dictionary = this;
          dxfDictionaryEntry2.Value.vmethod_2((IDxfHandledObject) this);
        }
        cloneContext.ClonedDictionaryEntries.Add(dxfDictionaryEntry2);
        this.dxfDictionaryEntryCollection_0.Add((IDictionaryEntry) dxfDictionaryEntry2);
      }
      switch (dxfDictionary.Handle)
      {
        case 12:
        case 13:
        case 14:
        case 23:
        case 25:
        case 26:
          this.SetHandle(dxfDictionary.Handle);
          break;
      }
    }

    public override void Dispose()
    {
      base.Dispose();
      if (this.dxfDictionaryEntryCollection_0 == null)
        return;
      foreach (DxfDictionaryEntry dxfDictionaryEntry in (ActiveList<IDictionaryEntry>) this.dxfDictionaryEntryCollection_0)
      {
        if (dxfDictionaryEntry != null && dxfDictionaryEntry.Value != null)
          dxfDictionaryEntry.Value.Dispose();
      }
      this.dxfDictionaryEntryCollection_0 = (DxfDictionaryEntryCollection) null;
    }

    public DxfObject GetValueByName(string name)
    {
      if (this.dxfDictionaryEntryCollection_0 != null)
      {
        foreach (DxfDictionaryEntry dxfDictionaryEntry in (ActiveList<IDictionaryEntry>) this.dxfDictionaryEntryCollection_0)
        {
          if (name == dxfDictionaryEntry.Name)
            return dxfDictionaryEntry.Value;
        }
      }
      return (DxfObject) null;
    }

    internal void method_8()
    {
      this.dxfDictionaryEntryCollection_0.method_0();
    }

    internal void method_9()
    {
      this.dxfDictionaryEntryCollection_0.Added += new ItemEventHandler<IDictionaryEntry>(this.method_12);
      this.dxfDictionaryEntryCollection_0.Removed += new ItemEventHandler<IDictionaryEntry>(this.method_13);
      this.dxfDictionaryEntryCollection_0.Set += new ItemSetEventHandler<IDictionaryEntry>(this.method_14);
    }

    internal void method_10(IDictionaryEntry item, bool addPersistentReactor)
    {
      if (item.Value == null)
        return;
      item.Value.vmethod_2((IDxfHandledObject) this);
      if (!addPersistentReactor)
        return;
      item.Value.AddPersistentReactor((DxfHandledObject) this);
    }

    internal void method_11(IDictionaryEntry item)
    {
      if (item.Value == null)
        return;
      item.Value.vmethod_2((IDxfHandledObject) null);
      item.Value.RemovePersistentReactor((DxfHandledObject) this);
    }

    internal static DxfDictionary smethod_2(bool useFixedHandles)
    {
      DxfDictionary dxfDictionary = new DxfDictionary();
      if (useFixedHandles)
        dxfDictionary.SetHandle(12UL);
      return dxfDictionary;
    }

    internal static DxfDictionary smethod_3(out string dictionaryName)
    {
      DxfDictionary dxfDictionary = new DxfDictionary();
      dictionaryName = "ACAD_COLOR";
      return dxfDictionary;
    }

    internal static DxfDictionary smethod_4(
      bool useFixedHandles,
      out string dictionaryName)
    {
      DxfDictionary dxfDictionary = new DxfDictionary();
      if (useFixedHandles)
        dxfDictionary.SetHandle(13UL);
      dictionaryName = "ACAD_GROUP";
      return dxfDictionary;
    }

    internal static DxfDictionary smethod_5(
      bool useFixedHandles,
      out string dictionaryName)
    {
      DxfDictionary dxfDictionary = new DxfDictionary();
      dictionaryName = "ACAD_IMAGE_DICT";
      return dxfDictionary;
    }

    internal static DxfDictionary smethod_6(
      bool useFixedHandles,
      out string dictionaryName)
    {
      DxfDictionary dxfDictionary = new DxfDictionary();
      if (useFixedHandles)
        dxfDictionary.SetHandle(26UL);
      dictionaryName = "ACAD_LAYOUT";
      return dxfDictionary;
    }

    internal static DxfDictionary smethod_7(
      bool useFixedHandles,
      out string dictionaryName)
    {
      DxfDictionary dxfDictionary = new DxfDictionary();
      dictionaryName = "ACAD_MATERIAL";
      return dxfDictionary;
    }

    internal static DxfDictionary smethod_8(
      bool useFixedHandles,
      out string dictionaryName)
    {
      DxfDictionary dxfDictionary = new DxfDictionary();
      dictionaryName = "ACAD_MLEADERSTYLE";
      return dxfDictionary;
    }

    internal static DxfDictionary smethod_9(
      bool useFixedHandles,
      out string dictionaryName)
    {
      DxfDictionary dxfDictionary = new DxfDictionary();
      if (useFixedHandles)
        dxfDictionary.SetHandle(23UL);
      dictionaryName = "ACAD_MLINESTYLE";
      return dxfDictionary;
    }

    internal static DxfDictionary smethod_10(
      bool useFixedHandles,
      out string dictionaryName)
    {
      DxfDictionary dxfDictionary = new DxfDictionary();
      dictionaryName = "ACAD_TABLESTYLE";
      return dxfDictionary;
    }

    internal static DxfDictionary smethod_11(
      bool useFixedHandles,
      out string dictionaryName)
    {
      DxfDictionary dxfDictionary = new DxfDictionary();
      if (useFixedHandles)
        dxfDictionary.SetHandle(25UL);
      dictionaryName = "ACAD_PLOTSETTINGS";
      return dxfDictionary;
    }

    internal static DxfDictionary smethod_12(
      bool useFixedHandles,
      out string dictionaryName)
    {
      DxfDictionary dxfDictionary = new DxfDictionary();
      dictionaryName = "AcDbVariableDictionary";
      return dxfDictionary;
    }

    internal static DxfDictionary smethod_13(
      bool useFixedHandles,
      out string dictionaryName)
    {
      DxfDictionary dxfDictionary = new DxfDictionary();
      dictionaryName = "ACAD_VISUALSTYLE";
      return dxfDictionary;
    }

    private void method_12(object sender, int index, IDictionaryEntry item)
    {
      if (item == null)
        return;
      item.Dictionary = this;
      this.method_10(item, true);
    }

    private void method_13(object sender, int index, IDictionaryEntry item)
    {
      if (item == null)
        return;
      item.Dictionary = (DxfDictionary) null;
      this.method_11(item);
    }

    private void method_14(
      object sender,
      int index,
      IDictionaryEntry oldItem,
      IDictionaryEntry newItem)
    {
      if (oldItem != null)
      {
        oldItem.Dictionary = (DxfDictionary) null;
        this.method_11(oldItem);
      }
      if (newItem == null)
        return;
      newItem.Dictionary = this;
      this.method_10(newItem, true);
    }

    internal class Class753 : ICloneBuilder
    {
      private DxfDictionary dxfDictionary_0;

      public Class753(DxfDictionary dictionary)
      {
        this.dxfDictionary_0 = dictionary;
      }

      public void ResolveReferences(CloneContext context)
      {
        this.dxfDictionary_0.method_9();
      }
    }
  }
}
