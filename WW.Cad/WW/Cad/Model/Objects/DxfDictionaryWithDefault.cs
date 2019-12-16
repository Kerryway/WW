// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfDictionaryWithDefault
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using WW.Collections.Generic;

namespace WW.Cad.Model.Objects
{
  public class DxfDictionaryWithDefault : DxfDictionary
  {
    private DxfObjectReference dxfObjectReference_3 = DxfObjectReference.Null;

    public DxfDictionaryWithDefault()
    {
    }

    protected DxfDictionaryWithDefault(bool subscribeToEvents)
      : base(subscribeToEvents)
    {
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.short_1;
    }

    public override string ObjectType
    {
      get
      {
        return "ACDBDICTIONARYWDFLT";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbDictionaryWithDefault";
      }
    }

    public DxfObject DefaultEntry
    {
      get
      {
        return (DxfObject) this.dxfObjectReference_3.Value;
      }
      set
      {
        this.dxfObjectReference_3 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfDictionaryWithDefault dictionaryWithDefault = (DxfDictionaryWithDefault) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dictionaryWithDefault == null)
      {
        dictionaryWithDefault = new DxfDictionaryWithDefault(false);
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dictionaryWithDefault);
        dictionaryWithDefault.CopyFrom((DxfHandledObject) this, cloneContext);
        cloneContext.CloneBuilders.Add((ICloneBuilder) new DxfDictionary.Class753((DxfDictionary) dictionaryWithDefault));
      }
      return (IGraphCloneable) dictionaryWithDefault;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfDictionaryWithDefault dictionaryWithDefault = (DxfDictionaryWithDefault) from;
      if (dictionaryWithDefault.DefaultEntry == null)
        return;
      int index = 0;
      DxfObject defaultEntry = dictionaryWithDefault.DefaultEntry;
      foreach (DxfDictionaryEntry entry in (ActiveList<IDictionaryEntry>) dictionaryWithDefault.Entries)
      {
        if (entry.Value != defaultEntry)
        {
          ++index;
        }
        else
        {
          this.DefaultEntry = this.Entries[index].Value;
          break;
        }
      }
    }

    internal static DxfDictionaryWithDefault smethod_14(
      bool useFixedHandles,
      out string dictionaryName)
    {
      DxfDictionaryWithDefault dictionaryWithDefault = new DxfDictionaryWithDefault();
      if (useFixedHandles)
        dictionaryWithDefault.SetHandle(14UL);
      dictionaryName = "ACAD_PLOTSTYLENAME";
      return dictionaryWithDefault;
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf15OrHigher;
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }
  }
}
