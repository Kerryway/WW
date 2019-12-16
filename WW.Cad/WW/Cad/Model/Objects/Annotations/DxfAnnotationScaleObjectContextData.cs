// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.Annotations.DxfAnnotationScaleObjectContextData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using ns3;
using ns49;
using System;
using System.Collections.Generic;
using System.Linq;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model.Objects.Annotations
{
  public abstract class DxfAnnotationScaleObjectContextData : DxfObjectContextData
  {
    private DxfObjectReference dxfObjectReference_3 = DxfObjectReference.Null;

    protected DxfAnnotationScaleObjectContextData()
    {
    }

    protected DxfAnnotationScaleObjectContextData(DxfScale scale)
    {
      this.dxfObjectReference_3 = DxfObjectReference.GetReference((IDxfHandledObject) scale);
    }

    public DxfScale Scale
    {
      get
      {
        return (DxfScale) this.dxfObjectReference_3.Value;
      }
      set
      {
        this.dxfObjectReference_3 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbAnnotScaleObjectContextData";
      }
    }

    public override string ObjectType
    {
      get
      {
        return "ACDB_ANNOTSCALEOBJECTCONTEXTDATA_CLASS";
      }
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfAnnotationScaleObjectContextData objectContextData = (DxfAnnotationScaleObjectContextData) from;
      if (objectContextData.Scale == null)
        this.Scale = (DxfScale) null;
      else if (cloneContext.SourceModel == cloneContext.TargetModel)
        this.Scale = objectContextData.Scale;
      else
        this.Scale = (DxfScale) objectContextData.Scale.Clone(cloneContext);
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf18OrHigher;
    }

    protected internal override void ExecuteDeepHelper(
      WW.Cad.Model.Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      if (this.Scale == null)
        return;
      this.Scale.vmethod_0(action, callerStack);
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      ow.ObjectWriter.imethod_41((DxfHandledObject) this.Scale);
    }

    internal override Class259 vmethod_9(FileFormat fileFormat)
    {
      return (Class259) new DxfAnnotationScaleObjectContextData.Class310((DxfHandledObject) this);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      ((DxfAnnotationScaleObjectContextData.Class310) ob).ScaleHandle = or.method_100();
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_234("AcDbAnnotScaleObjectContextData");
      w.method_218(340, (DxfHandledObject) this.Scale);
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      if (r.CurrentGroup.Code != 100 || (string) r.CurrentGroup.Value != "AcDbAnnotScaleObjectContextData")
        throw new DxfException("Expected subclass marker.");
      r.method_85();
      if (r.CurrentGroup.Code != 340)
        throw new DxfException("Expected GC 340 here.");
      ((DxfAnnotationScaleObjectContextData.Class310) objectBuilder).ScaleHandle = (ulong) r.CurrentGroup.Value;
      r.method_85();
    }

    internal static void smethod_2(DxfHandledObject o)
    {
      DxfAnnotationScaleObjectContextData.smethod_3(o, true, true);
    }

    internal static void smethod_3(
      DxfHandledObject o,
      bool annotative,
      bool annotationAlwaysVisible)
    {
      Class1064.Set(o, new Class1064()
      {
        Annotative = annotative,
        AnnotationAlwaysVisible = annotationAlwaysVisible
      });
    }

    internal static DxfAnnotationScaleObjectContextData smethod_4(
      DxfHandledObject obj,
      DxfScale scale,
      bool ignoreDefault)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfAnnotationScaleObjectContextData.Class356 class356 = new DxfAnnotationScaleObjectContextData.Class356();
      // ISSUE: reference to a compiler-generated field
      class356.dxfScale_0 = scale;
      // ISSUE: reference to a compiler-generated field
      if (obj.ExtensionDictionary == null || class356.dxfScale_0 == null)
        return (DxfAnnotationScaleObjectContextData) null;
      DxfDictionary valueByName1 = obj.ExtensionDictionary.GetValueByName("AcDbContextDataManager") as DxfDictionary;
      if (valueByName1 == null)
        return (DxfAnnotationScaleObjectContextData) null;
      DxfDictionary valueByName2 = valueByName1.GetValueByName("ACDB_ANNOTATIONSCALES") as DxfDictionary;
      if (valueByName2 == null)
        return (DxfAnnotationScaleObjectContextData) null;
      // ISSUE: reference to a compiler-generated method
      DxfAnnotationScaleObjectContextData objectContextData = valueByName2.Entries.Select<IDictionaryEntry, DxfAnnotationScaleObjectContextData>((Func<IDictionaryEntry, DxfAnnotationScaleObjectContextData>) (ctxDataEntry => (DxfAnnotationScaleObjectContextData) ctxDataEntry.Value)).FirstOrDefault<DxfAnnotationScaleObjectContextData>(new Func<DxfAnnotationScaleObjectContextData, bool>(class356.method_0));
      if (ignoreDefault && objectContextData != null && objectContextData.IsDefault)
        return (DxfAnnotationScaleObjectContextData) null;
      return objectContextData;
    }

    internal static DxfAnnotationScaleObjectContextData smethod_5(
      DxfHandledObject obj,
      bool returnAny = false)
    {
      if (obj.ExtensionDictionary == null)
        return (DxfAnnotationScaleObjectContextData) null;
      DxfDictionary valueByName1 = obj.ExtensionDictionary.GetValueByName("AcDbContextDataManager") as DxfDictionary;
      if (valueByName1 == null)
        return (DxfAnnotationScaleObjectContextData) null;
      DxfDictionary valueByName2 = valueByName1.GetValueByName("ACDB_ANNOTATIONSCALES") as DxfDictionary;
      if (valueByName2 == null)
        return (DxfAnnotationScaleObjectContextData) null;
      DxfAnnotationScaleObjectContextData objectContextData = valueByName2.Entries.Select<IDictionaryEntry, DxfAnnotationScaleObjectContextData>((Func<IDictionaryEntry, DxfAnnotationScaleObjectContextData>) (ctxDataEntry => (DxfAnnotationScaleObjectContextData) ctxDataEntry.Value)).FirstOrDefault<DxfAnnotationScaleObjectContextData>((Func<DxfAnnotationScaleObjectContextData, bool>) (ctx => ctx.IsDefault));
      if (objectContextData == null && returnAny && valueByName2.Entries.Count != 0)
        return (DxfAnnotationScaleObjectContextData) valueByName2.Entries[0].Value;
      return objectContextData;
    }

    internal static DxfDictionary smethod_6(DxfHandledObject obj)
    {
      return DxfAnnotationScaleObjectContextData.smethod_7(obj, true);
    }

    internal static DxfDictionary smethod_7(
      DxfHandledObject obj,
      bool createIfNotFound)
    {
      if (obj.ExtensionDictionary == null)
      {
        if (!createIfNotFound)
          return (DxfDictionary) null;
        obj.ExtensionDictionary = new DxfDictionary();
      }
      DxfDictionary dxfDictionary1 = obj.ExtensionDictionary.GetValueByName("AcDbContextDataManager") as DxfDictionary;
      if (dxfDictionary1 == null)
      {
        if (!createIfNotFound)
          return (DxfDictionary) null;
        dxfDictionary1 = new DxfDictionary();
        obj.ExtensionDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("AcDbContextDataManager", (DxfObject) dxfDictionary1));
      }
      DxfDictionary dxfDictionary2 = dxfDictionary1.GetValueByName("ACDB_ANNOTATIONSCALES") as DxfDictionary;
      if (dxfDictionary2 == null)
      {
        if (!createIfNotFound)
          return (DxfDictionary) null;
        dxfDictionary2 = new DxfDictionary();
        dxfDictionary1.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("ACDB_ANNOTATIONSCALES", (DxfObject) dxfDictionary2));
      }
      return dxfDictionary2;
    }

    internal static void smethod_8(DxfEntity obj)
    {
      if (DxfScale.smethod_2(obj.Layer) == null)
        return;
      DxfLayer oldLayer;
      DxfScale scale = DxfScale.smethod_4(obj.Layer, out oldLayer);
      if (scale == null)
        return;
      DxfAnnotationScaleObjectContextData contextData = ((IAnnotative) obj).CreateContextData(scale);
      obj.Layer = oldLayer;
      DxfDictionary dxfDictionary = DxfAnnotationScaleObjectContextData.smethod_6((DxfHandledObject) obj);
      dxfDictionary.Entries.Clear();
      dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("*A", (DxfObject) contextData));
    }

    internal static double smethod_9(DxfEntity obj, DxfScale scale)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfAnnotationScaleObjectContextData.Class357 class357 = new DxfAnnotationScaleObjectContextData.Class357();
      // ISSUE: reference to a compiler-generated field
      class357.dxfScale_0 = scale;
      if (obj.ExtensionDictionary == null)
        return 1.0;
      DxfDictionary valueByName1 = obj.ExtensionDictionary.GetValueByName("AcDbContextDataManager") as DxfDictionary;
      if (valueByName1 == null)
        return 1.0;
      DxfDictionary valueByName2 = valueByName1.GetValueByName("ACDB_ANNOTATIONSCALES") as DxfDictionary;
      if (valueByName2 == null)
        return 1.0;
      // ISSUE: reference to a compiler-generated method
      DxfAnnotationScaleObjectContextData objectContextData1 = valueByName2.Entries.Select<IDictionaryEntry, DxfAnnotationScaleObjectContextData>((Func<IDictionaryEntry, DxfAnnotationScaleObjectContextData>) (ctxDataEntry => (DxfAnnotationScaleObjectContextData) ctxDataEntry.Value)).FirstOrDefault<DxfAnnotationScaleObjectContextData>(new Func<DxfAnnotationScaleObjectContextData, bool>(class357.method_0));
      if (objectContextData1 == null || objectContextData1.IsDefault)
        return 1.0;
      DxfAnnotationScaleObjectContextData objectContextData2 = valueByName2.Entries.Select<IDictionaryEntry, DxfAnnotationScaleObjectContextData>((Func<IDictionaryEntry, DxfAnnotationScaleObjectContextData>) (ctxDataEntry => (DxfAnnotationScaleObjectContextData) ctxDataEntry.Value)).FirstOrDefault<DxfAnnotationScaleObjectContextData>((Func<DxfAnnotationScaleObjectContextData, bool>) (ctx => ctx.IsDefault));
      if (objectContextData2 == null)
        return 1.0;
      return objectContextData1.Scale.ScaleFactor / objectContextData2.Scale.ScaleFactor;
    }

    internal class Class310 : Class259
    {
      public Class310(DxfHandledObject handledObject)
        : base(handledObject)
      {
      }

      public ulong ScaleHandle { private get; set; }

      public override void ResolveReferences(Class374 modelBuilder)
      {
        base.ResolveReferences(modelBuilder);
        ((DxfAnnotationScaleObjectContextData) this.HandledObject).Scale = modelBuilder.method_4<DxfScale>(this.ScaleHandle);
      }
    }
  }
}
