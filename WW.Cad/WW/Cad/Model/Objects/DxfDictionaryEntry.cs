// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfDictionaryEntry
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Objects
{
  public class DxfDictionaryEntry : IDictionaryEntry
  {
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private DxfDictionary dxfDictionary_0;
    private string string_0;
    private bool bool_0;

    public DxfDictionaryEntry()
    {
    }

    public DxfDictionaryEntry(string name, DxfObject value)
    {
      this.string_0 = name;
      this.Value = value;
    }

    public DxfDictionaryEntry(string name, DxfObject value, bool valueReferenceIsHard)
    {
      this.string_0 = name;
      this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      this.bool_0 = valueReferenceIsHard;
    }

    public DxfDictionaryEntry(DxfObject value)
    {
      this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
    }

    public DxfDictionary Dictionary
    {
      get
      {
        return this.dxfDictionary_0;
      }
      set
      {
        this.dxfDictionary_0 = value;
      }
    }

    public string Name
    {
      get
      {
        INamedObject namedObject = this.Value as INamedObject;
        if (namedObject == null)
          return this.string_0;
        return namedObject.Name;
      }
      set
      {
        INamedObject namedObject = this.Value as INamedObject;
        if (namedObject == null)
        {
          this.string_0 = value;
        }
        else
        {
          namedObject.Name = value;
          if (value == null)
            return;
          this.string_0 = (string) null;
        }
      }
    }

    public DxfObject Value
    {
      get
      {
        return (DxfObject) this.dxfObjectReference_0.Value;
      }
      set
      {
        this.SetValue(value, true);
      }
    }

    public bool ValueReferenceIsHard
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

    public IDictionaryEntry Clone(CloneContext cloneContext)
    {
      DxfDictionaryEntry dxfDictionaryEntry = new DxfDictionaryEntry();
      dxfDictionaryEntry.CopyFrom(this, cloneContext);
      return (IDictionaryEntry) dxfDictionaryEntry;
    }

    public void CopyFrom(DxfDictionaryEntry from, CloneContext cloneContext)
    {
      this.string_0 = from.string_0;
      this.bool_0 = from.bool_0;
      if (from.dxfObjectReference_0 == null)
        return;
      this.dxfObjectReference_0 = from.dxfObjectReference_0.Value != null ? ((DxfHandledObject) ((DxfHandledObject) from.dxfObjectReference_0.Value).Clone(cloneContext)).Reference : DxfObjectReference.Null;
    }

    public override string ToString()
    {
      return this.Name;
    }

    internal void SetValue(DxfObject value)
    {
      this.SetValue(value, false);
    }

    internal void SetValue(DxfObject value, bool addPersistentReactor)
    {
      this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      if (this.dxfObjectReference_0 == null)
        return;
      if (value is INamedObject)
        this.string_0 = (string) null;
      if (this.dxfDictionary_0 == null)
        return;
      this.dxfDictionary_0.method_10((IDictionaryEntry) this, addPersistentReactor);
    }

    public static class Names
    {
      public const string AcadColor = "ACAD_COLOR";
      public const string AcadFieldList = "ACAD_FIELDLIST";
      public const string AcadGeographicData = "ACAD_GEOGRAPHICDATA";
      public const string AcadGroup = "ACAD_GROUP";
      public const string AcadImage = "ACAD_IMAGE_DICT";
      public const string AcadImageVars = "ACAD_IMAGE_VARS";
      public const string AcadLayout = "ACAD_LAYOUT";
      public const string AcadMaterial = "ACAD_MATERIAL";
      public const string AcadSortEnts = "ACAD_SORTENTS";
      public const string AcadMLeaderStyle = "ACAD_MLEADERSTYLE";
      public const string AcadMLineStyle = "ACAD_MLINESTYLE";
      public const string AcadTableStyle = "ACAD_TABLESTYLE";
      public const string AcadPlotSettings = "ACAD_PLOTSETTINGS";
      public const string VariableDictionary = "AcDbVariableDictionary";
      public const string AcadPlotStyleName = "ACAD_PLOTSTYLENAME";
      public const string AcadScaleList = "ACAD_SCALELIST";
      public const string AcadVisualStyle = "ACAD_VISUALSTYLE";
      public const string DwgProps = "DWGPROPS";
    }
  }
}
