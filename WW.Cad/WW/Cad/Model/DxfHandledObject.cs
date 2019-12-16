// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfHandledObject
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using ns3;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model
{
  public class DxfHandledObject : IDxfHandledObject, IGraphCloneable, IDisposable
  {
    private DxfObjectReference dxfObjectReference_1 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_2 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_0;
    private DxfExtendedDataCollection dxfExtendedDataCollection_0;
    private DxfHandledObjectCollection<DxfHandledObject> dxfHandledObjectCollection_0;

    public DxfHandledObject()
    {
      this.dxfObjectReference_0 = new DxfObjectReference((IDxfHandledObject) this);
    }

    public DxfHandledObject(DxfHandledObject ownerObjectSoftReference)
      : this()
    {
      this.dxfObjectReference_1 = ownerObjectSoftReference == null ? DxfObjectReference.Null : ownerObjectSoftReference.Reference;
    }

    public ulong Handle
    {
      get
      {
        return this.dxfObjectReference_0.Handle;
      }
    }

    [Browsable(false)]
    public IDxfHandledObject OwnerObjectSoftReference
    {
      get
      {
        return this.dxfObjectReference_1.Value;
      }
    }

    public DxfDictionary ExtensionDictionary
    {
      get
      {
        return (DxfDictionary) this.dxfObjectReference_2.Value;
      }
      set
      {
        if (this.dxfObjectReference_2 != DxfObjectReference.Null)
          ((DxfHandledObject) this.dxfObjectReference_2.Value).vmethod_2((IDxfHandledObject) null);
        this.dxfObjectReference_2 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        if (this.dxfObjectReference_2 == DxfObjectReference.Null)
          return;
        ((DxfHandledObject) this.dxfObjectReference_2.Value).vmethod_2((IDxfHandledObject) this);
      }
    }

    [Browsable(false)]
    public DxfModel Model
    {
      get
      {
        IDxfHandledObject dxfHandledObject1 = (IDxfHandledObject) this;
        IDxfHandledObject dxfHandledObject2;
        do
        {
          dxfHandledObject2 = dxfHandledObject1;
          dxfHandledObject1 = dxfHandledObject2.OwnerObjectSoftReference;
        }
        while (dxfHandledObject1 != null);
        return dxfHandledObject2 as DxfModel;
      }
    }

    public DxfExtendedDataCollection ExtendedDataCollection
    {
      get
      {
        if (this.dxfExtendedDataCollection_0 == null)
          this.dxfExtendedDataCollection_0 = new DxfExtendedDataCollection();
        return this.dxfExtendedDataCollection_0;
      }
    }

    public DxfHandledObjectCollection<DxfHandledObject> PersistentReactors
    {
      get
      {
        if (this.dxfHandledObjectCollection_0 == null)
          this.dxfHandledObjectCollection_0 = new DxfHandledObjectCollection<DxfHandledObject>(1);
        return this.dxfHandledObjectCollection_0;
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

    internal bool HasExtendedData
    {
      get
      {
        if (this.dxfExtendedDataCollection_0 != null)
          return this.dxfExtendedDataCollection_0.Count > 0;
        return false;
      }
    }

    internal bool HasPersistentReactors
    {
      get
      {
        if (this.dxfHandledObjectCollection_0 != null)
          return this.dxfHandledObjectCollection_0.Count > 0;
        return false;
      }
    }

    internal int PersistentReactorCount
    {
      get
      {
        int num = 0;
        if (this.dxfHandledObjectCollection_0 != null)
          num = this.dxfHandledObjectCollection_0.Count;
        return num;
      }
    }

    internal virtual bool HasDataStoreData
    {
      get
      {
        return false;
      }
    }

    internal virtual void Repair(DxfModelRepairer repairer)
    {
    }

    internal virtual void vmethod_0(Action action, Stack<DxfHandledObject> callerStack)
    {
      if (DxfHandledObject.smethod_0(callerStack, this))
        return;
      callerStack.Push(this);
      this.ExecuteDeepHelper(action, callerStack);
      callerStack.Pop();
    }

    private static bool smethod_0(Stack<DxfHandledObject> callerStack, DxfHandledObject caller)
    {
      foreach (object caller1 in callerStack)
      {
        if (object.ReferenceEquals(caller1, (object) caller))
          return true;
      }
      return false;
    }

    protected internal virtual void ExecuteDeepHelper(
      Action action,
      Stack<DxfHandledObject> callerStack)
    {
      action(this);
      if (this.ExtensionDictionary == null)
        return;
      this.ExtensionDictionary.vmethod_0(action, callerStack);
    }

    internal virtual void vmethod_1(Class1070 context)
    {
      if (this.ExtensionDictionary == null)
        return;
      this.ExtensionDictionary.vmethod_1(context);
    }

    internal string HandleString
    {
      get
      {
        return DxfHandledObject.Class9.smethod_0(this.dxfObjectReference_0.Handle);
      }
    }

    internal void method_0(string handleString)
    {
      this.SetHandle(DxfHandledObject.Parse(handleString));
    }

    internal void SetHandle(ulong handle)
    {
      this.dxfObjectReference_0.Handle = handle;
    }

    internal virtual void vmethod_2(IDxfHandledObject ownerObjectSoftReference)
    {
      this.dxfObjectReference_1 = DxfObjectReference.GetReference(ownerObjectSoftReference);
    }

    internal virtual void vmethod_3(DxfModel modelContext)
    {
    }

    internal virtual void vmethod_4(DxfModel modelContext)
    {
    }

    internal virtual bool vmethod_5(DxfModel model)
    {
      return true;
    }

    internal void method_1(DxfExtendedDataCollection extendedDataCollection)
    {
      this.dxfExtendedDataCollection_0 = extendedDataCollection;
    }

    public static ulong Parse(string handleString)
    {
      return ulong.Parse(handleString, NumberStyles.HexNumber, (IFormatProvider) CultureInfo.InvariantCulture);
    }

    public virtual bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      messages = (IList<DxfMessage>) null;
      return true;
    }

    public virtual IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfHandledObject dxfHandledObject = (DxfHandledObject) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfHandledObject == null)
      {
        dxfHandledObject = new DxfHandledObject();
        this.RegisterClone(cloneContext, (IGraphCloneable) dxfHandledObject);
        dxfHandledObject.CopyFrom(this, cloneContext);
      }
      return (IGraphCloneable) dxfHandledObject;
    }

    public virtual void RegisterClone(CloneContext cloneContext, IGraphCloneable clone)
    {
      cloneContext.RegisterClone((IGraphCloneable) this, clone);
    }

    public virtual void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      this.ExtensionDictionary = from.ExtensionDictionary != null ? (DxfDictionary) from.ExtensionDictionary.Clone(cloneContext) : (DxfDictionary) null;
      this.dxfExtendedDataCollection_0 = from.dxfExtendedDataCollection_0 != null ? from.dxfExtendedDataCollection_0.Clone(cloneContext) : (DxfExtendedDataCollection) null;
      if (!cloneContext.CloneExact)
        return;
      this.dxfObjectReference_0.Handle = from.Reference.Handle;
    }

    public void AddPersistentReactor(DxfHandledObject reactor)
    {
      if (this.dxfHandledObjectCollection_0 == null)
        this.dxfHandledObjectCollection_0 = new DxfHandledObjectCollection<DxfHandledObject>();
      this.dxfHandledObjectCollection_0.Add(reactor);
    }

    public void RemovePersistentReactor(DxfHandledObject reactor)
    {
      if (this.dxfHandledObjectCollection_0 == null)
        return;
      this.dxfHandledObjectCollection_0.Remove(reactor);
      if (this.dxfHandledObjectCollection_0.Count != 0)
        return;
      this.dxfHandledObjectCollection_0 = (DxfHandledObjectCollection<DxfHandledObject>) null;
    }

    public T GetOrCreateXDicObject<T>(string name) where T : DxfObject, new()
    {
      T obj = default (T);
      if (this.ExtensionDictionary == null)
        this.ExtensionDictionary = new DxfDictionary();
      else
        obj = this.ExtensionDictionary.GetValueByName(name) as T;
      if ((object) obj == null)
      {
        obj = new T();
        this.ExtensionDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry(name, (DxfObject) obj));
      }
      return obj;
    }

    public T GetXDicObject<T>(string name) where T : DxfObject
    {
      T obj = default (T);
      if (this.ExtensionDictionary != null)
        obj = this.ExtensionDictionary.GetValueByName(name) as T;
      return obj;
    }

    public virtual void Dispose()
    {
    }

    internal virtual short vmethod_6(Class432 w)
    {
      throw new NotImplementedException();
    }

    internal virtual void vmethod_7(Class432 ow)
    {
      this.Write(ow, this.vmethod_6(ow));
      this.Write(ow);
    }

    internal virtual void Write(Class432 ow)
    {
      this.method_2(ow);
    }

    internal void Write(Class432 ow, short objectType)
    {
      ow.ObjectWriter.Clear();
      ow.ObjectWriter.imethod_46(objectType);
      if (ow.Version > DxfVersion.Dxf14 && ow.Version < DxfVersion.Dxf24)
        ow.method_81();
      ow.ObjectWriter.imethod_35(new ReferenceType?(), this.Handle);
      this.method_3(ow);
      if (ow.Version < DxfVersion.Dxf13 || ow.Version > DxfVersion.Dxf14)
        return;
      ow.method_81();
    }

    internal void method_2(Class432 w)
    {
      w.ObjectWriter.imethod_33(this.PersistentReactorCount);
      if (w.Version >= DxfVersion.Dxf18)
        w.ObjectWriter.imethod_14(this.ExtensionDictionary == null);
      if (w.Version <= DxfVersion.Dxf24)
        return;
      w.ObjectWriter.imethod_14(this.HasDataStoreData);
    }

    internal void method_3(Class432 w)
    {
      foreach (DxfExtendedData extendedData in (Collection<DxfExtendedData>) this.ExtendedDataCollection)
        w.method_84(extendedData);
      w.ObjectWriter.imethod_32((short) 0);
    }

    internal virtual void vmethod_8(Class434 or, Class259 objectBuilder)
    {
      or.method_93(objectBuilder);
    }

    internal void method_4(Class434 or, Class259 objectBuilder)
    {
      this.vmethod_8(or, objectBuilder);
      this.Read(or, objectBuilder);
    }

    internal virtual void Read(Class434 or, Class259 objectBuilder)
    {
      or.method_97(objectBuilder);
      if (this.Handle == 0UL)
        return;
      or.method_96(objectBuilder);
    }

    internal virtual Class259 vmethod_9(FileFormat fileFormat)
    {
      return new Class259(this);
    }

    internal virtual void Write(DxfWriter w)
    {
      w.method_201(this);
    }

    internal void method_5(DxfReader r, Class259 objectBuilder)
    {
      r.method_85();
      while (r.CurrentGroup.Code != 0 && r.CurrentGroup.Code != 100)
      {
        if (!this.method_6(r, objectBuilder))
          r.method_85();
      }
    }

    internal virtual void Read(DxfReader r, Class259 objectBuilder)
    {
    }

    internal bool method_6(DxfReader r, Class259 objectBuilder)
    {
      DxfHandledObject handledObject = objectBuilder.HandledObject;
      switch (r.CurrentGroup.Code)
      {
        case 5:
          if (r.ModelBuilder.Version > DxfVersion.Dxf12)
          {
            handledObject.method_0((string) r.CurrentGroup.Value);
          }
          else
          {
            ulong result;
            if (ulong.TryParse((string) r.CurrentGroup.Value, NumberStyles.HexNumber, (IFormatProvider) CultureInfo.InvariantCulture, out result))
              handledObject.SetHandle(result);
          }
          r.method_89(objectBuilder);
          break;
        case 102:
          DxfHandledObject.smethod_1(r, objectBuilder);
          break;
        case 330:
          objectBuilder.OwnerHandle = (ulong) r.CurrentGroup.Value;
          break;
        case 1001:
          this.method_7(r, objectBuilder);
          return true;
        default:
          return false;
      }
      r.method_85();
      return true;
    }

    internal static void smethod_1(DxfReader r, Class259 objectBuilder)
    {
      string str = (string) r.CurrentGroup.Value;
      if (str == "{ACAD_REACTORS")
      {
        r.method_85();
        while (r.CurrentGroup != Class824.struct18_30)
        {
          if (r.CurrentGroup.Code == 330)
            objectBuilder.method_0((ulong) r.CurrentGroup.Value);
          r.method_85();
        }
      }
      else if (str == "{ACAD_XDICTIONARY")
      {
        r.method_85();
        while (r.CurrentGroup != Class824.struct18_30)
        {
          if (r.CurrentGroup.Code == 360)
            objectBuilder.ExtensionDictionaryHandle = (ulong) r.CurrentGroup.Value;
          r.method_85();
        }
      }
      else
      {
        while (r.CurrentGroup != Class824.struct18_30)
          r.method_85();
      }
    }

    private void method_7(DxfReader r, Class259 objectBuilder)
    {
      string key = (string) r.CurrentGroup.Value;
      DxfExtendedData dxfExtendedData;
      if (objectBuilder.AppIdToExtendedData.TryGetValue(key, out dxfExtendedData))
      {
        dxfExtendedData.Values.AddRange((IEnumerable<IExtendedDataValue>) DxfExtendedData.ValueCollection.Read(objectBuilder, r));
      }
      else
      {
        DxfAppId appId;
        bool flag = r.Model.AppIds.TryGetValue(key, out appId);
        DxfExtendedData extendedData = new DxfExtendedData(appId, DxfExtendedData.ValueCollection.Read(objectBuilder, r));
        objectBuilder.AppIdToExtendedData.Add(key, extendedData);
        if (!flag)
          objectBuilder.ChildBuilders.Add((Interface10) new Class333(this.ExtendedDataCollection, extendedData)
          {
            AppIdName = key
          });
        this.ExtendedDataCollection.Add(extendedData);
      }
    }

    internal virtual void vmethod_10(DxfModel model)
    {
    }

    internal static class Class9
    {
      internal static string smethod_0(ulong handle)
      {
        return handle.ToString("X", (IFormatProvider) CultureInfo.InvariantCulture);
      }
    }

    protected class LateComposer : ICloneBuilder
    {
      private readonly DxfHandledObject dxfHandledObject_0;

      public LateComposer(DxfHandledObject obj)
      {
        this.dxfHandledObject_0 = obj;
      }

      public void ResolveReferences(CloneContext context)
      {
        this.dxfHandledObject_0.vmethod_10(context.TargetModel);
      }
    }
  }
}
