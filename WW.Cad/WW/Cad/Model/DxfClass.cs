// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfClass
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;

namespace WW.Cad.Model
{
  public class DxfClass : IGraphCloneable, ICloneable
  {
    public const short EntityItemClassId = 498;
    public const short ObjectItemClassId = 499;
    internal const string string_0 = "AutoCAD 2000";
    internal const string string_1 = "ISM";
    internal const string string_2 = "WipeOut|AutoCAD Express Tool|expresstools@autodesk.com";
    internal const string string_3 = "ObjectDBX Classes";
    internal const string string_4 = "ACDB_MLEADERSTYLE_CLASS";
    internal const string string_5 = "AcIdViewObj|Product: Inventor Drawing Enabler|Company: Autodesk|Website: www.autodesk.com";
    internal const short short_0 = 500;
    private short short_1;
    private DwgVersion dwgVersion_0;
    private short short_2;
    private ProxyFlags proxyFlags_0;
    private string string_6;
    private string string_7;
    private string string_8;
    private bool bool_0;
    private short short_3;

    public DxfClass()
    {
    }

    public DxfClass(DxfClass fromClass)
    {
      this.short_1 = fromClass.short_1;
      this.dwgVersion_0 = fromClass.dwgVersion_0;
      this.short_2 = fromClass.short_2;
      this.proxyFlags_0 = fromClass.proxyFlags_0;
      this.string_6 = fromClass.string_6;
      this.string_7 = fromClass.string_7;
      this.string_8 = fromClass.string_8;
      this.bool_0 = fromClass.bool_0;
      this.short_3 = fromClass.short_3;
    }

    public short ClassNumber
    {
      get
      {
        return this.short_1;
      }
      set
      {
        this.short_1 = value;
      }
    }

    public DwgVersion DwgVersion
    {
      get
      {
        return this.dwgVersion_0;
      }
      set
      {
        this.dwgVersion_0 = value;
      }
    }

    public short MaintenanceVersion
    {
      get
      {
        return this.short_2;
      }
      set
      {
        this.short_2 = value;
      }
    }

    public ProxyFlags ProxyFlags
    {
      get
      {
        return this.proxyFlags_0;
      }
      set
      {
        this.proxyFlags_0 = value;
      }
    }

    public string ApplicationName
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

    public string CPlusPlusClassName
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

    public string DxfName
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

    public bool WasAZombie
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

    public short ItemClassId
    {
      get
      {
        return this.short_3;
      }
      set
      {
        this.short_3 = value;
      }
    }

    public ProxyFlags GetEffectiveProxyFlags(DxfVersion version)
    {
      ProxyFlags proxyFlags0 = this.proxyFlags_0;
      if (version > DxfVersion.Dxf13)
        proxyFlags0 &= ~ProxyFlags.R13FormatProxy;
      return proxyFlags0;
    }

    public override string ToString()
    {
      return this.string_7 + ", " + this.short_1.ToString();
    }

    internal void method_0(int classIndex)
    {
      this.short_1 = (short) (500 + classIndex);
    }

    internal static DxfClass smethod_0(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "DBCOLOR");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1015;
        dxfClass.MaintenanceVersion = (short) 14;
        dxfClass.ProxyFlags = ProxyFlags.None;
        dxfClass.CPlusPlusClassName = "AcDbColor";
        dxfClass.DxfName = "DBCOLOR";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_1(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "IDBUFFER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1014;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = ProxyFlags.R13FormatProxy;
        dxfClass.CPlusPlusClassName = "AcDbIdBuffer";
        dxfClass.DxfName = "IDBUFFER";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_2(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "RASTERVARIABLES");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ISM";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1014;
        dxfClass.short_2 = (short) 0;
        dxfClass.ProxyFlags = ProxyFlags.R13FormatProxy;
        dxfClass.CPlusPlusClassName = "AcDbRasterVariables";
        dxfClass.DxfName = "RASTERVARIABLES";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_3(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "IMAGEDEF");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ISM";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1014;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = ProxyFlags.R13FormatProxy;
        dxfClass.CPlusPlusClassName = "AcDbRasterImageDef";
        dxfClass.DxfName = "IMAGEDEF";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_4(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "IMAGEDEF_REACTOR");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ISM";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1014;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.R13FormatProxy;
        dxfClass.CPlusPlusClassName = "AcDbRasterImageDefReactor";
        dxfClass.DxfName = "IMAGEDEF_REACTOR";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_5(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "IMAGE");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ISM";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1014;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.TransformAllowed | ProxyFlags.ColorChangeAllowed | ProxyFlags.LayerChangeAllowed | ProxyFlags.LinetypeChangeAllowed | ProxyFlags.LinetypeScaleChangeAllowed | ProxyFlags.VisibilityChangeAllowed | ProxyFlags.R13FormatProxy;
        dxfClass.CPlusPlusClassName = "AcDbRasterImage";
        dxfClass.DxfName = "IMAGE";
        dxfClass.ItemClassId = (short) 498;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_6(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "WIPEOUT");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "WipeOut|AutoCAD Express Tool|expresstools@autodesk.com";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1015;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.TransformAllowed | ProxyFlags.ColorChangeAllowed | ProxyFlags.LayerChangeAllowed | ProxyFlags.LinetypeChangeAllowed | ProxyFlags.LinetypeScaleChangeAllowed | ProxyFlags.VisibilityChangeAllowed | ProxyFlags.R13FormatProxy;
        dxfClass.CPlusPlusClassName = "AcDbWipeout";
        dxfClass.DxfName = "WIPEOUT";
        dxfClass.ItemClassId = (short) 498;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_7(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "ACIDBLOCKREFERENCE");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "AcIdViewObj|Product: Inventor Drawing Enabler|Company: Autodesk|Website: www.autodesk.com";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1021;
        dxfClass.MaintenanceVersion = (short) 1;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed;
        dxfClass.CPlusPlusClassName = "AcIdBlockReference";
        dxfClass.DxfName = "ACIDBLOCKREFERENCE";
        dxfClass.ItemClassId = (short) 498;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_8(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "MATERIAL");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1015;
        dxfClass.MaintenanceVersion = (short) 14;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        dxfClass.CPlusPlusClassName = "AcDbMaterial";
        dxfClass.DxfName = "MATERIAL";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_9(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "VISUALSTYLE");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1021Beta;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.proxyFlags_0 = (ProxyFlags) 4095;
        dxfClass.CPlusPlusClassName = "AcDbVisualStyle";
        dxfClass.DxfName = "VISUALSTYLE";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_10(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "ACAD_TABLE");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.DisablesProxyWarningDialog;
        dxfClass.CPlusPlusClassName = "AcDbTable";
        dxfClass.DxfName = "ACAD_TABLE";
        dxfClass.ItemClassId = (short) 498;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_11(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "TABLESTYLE");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = (ProxyFlags) 4095;
        dxfClass.CPlusPlusClassName = "AcDbTableStyle";
        dxfClass.DxfName = "TABLESTYLE";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_12(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "SCALE");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1021;
        dxfClass.MaintenanceVersion = (short) 1;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        dxfClass.CPlusPlusClassName = "AcDbScale";
        dxfClass.DxfName = "SCALE";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_13(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "MLEADERSTYLE");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ACDB_MLEADERSTYLE_CLASS";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1021;
        dxfClass.MaintenanceVersion = (short) 25;
        dxfClass.ProxyFlags = (ProxyFlags) 4095;
        dxfClass.CPlusPlusClassName = "AcDbMLeaderStyle";
        dxfClass.DxfName = "MLEADERSTYLE";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_14(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "CELLSTYLEMAP");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1021;
        dxfClass.MaintenanceVersion = (short) 25;
        dxfClass.ProxyFlags = ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        dxfClass.CPlusPlusClassName = "AcDbCellStyleMap";
        dxfClass.DxfName = "CELLSTYLEMAP";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_15(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "ACDBPLACEHOLDER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1015;
        dxfClass.MaintenanceVersion = (short) 42;
        dxfClass.ProxyFlags = ProxyFlags.None;
        dxfClass.CPlusPlusClassName = "AcDbPlaceHolder";
        dxfClass.DxfName = "ACDBPLACEHOLDER";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_16(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "LAYOUT");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1015;
        dxfClass.MaintenanceVersion = (short) 42;
        dxfClass.ProxyFlags = ProxyFlags.None;
        dxfClass.CPlusPlusClassName = "AcDbLayout";
        dxfClass.DxfName = "LAYOUT";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_17(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "SORTENTSTABLE");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbSortentsTable";
        dxfClass.DxfName = "SORTENTSTABLE";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1014;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = ProxyFlags.None;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_18(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "XRECORD");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbSpatialFilter";
        dxfClass.DxfName = "SPATIAL_FILTER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1014;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = ProxyFlags.None;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_19(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "XRECORD");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "AutoCAD 2000";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbXrecord";
        dxfClass.DxfName = "XRECORD";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1014;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = ProxyFlags.None;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_20(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "DICTIONARYVAR");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbDictionaryVar";
        dxfClass.DxfName = "DICTIONARYVAR";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1013;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = ProxyFlags.None;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_21(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "ACDBDICTIONARYWDFLT");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbDictionaryWithDefault";
        dxfClass.DxfName = "ACDBDICTIONARYWDFLT";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1015Beta;
        dxfClass.MaintenanceVersion = (short) 42;
        dxfClass.ProxyFlags = ProxyFlags.R13FormatProxy;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_22(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKPOINTPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockPointParameter";
        dxfClass.DxfName = "BLOCKPOINTPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_23(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKALIGNMENTGRIP");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockAlignmentGrip";
        dxfClass.DxfName = "BLOCKALIGNMENTGRIP";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_24(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKFLIPGRIP");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockFlipGrip";
        dxfClass.DxfName = "BLOCKFLIPGRIP";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_25(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "ACDB_BLOCKREPRESENTATION_DATA");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockRepresentationData";
        dxfClass.DxfName = "ACDB_BLOCKREPRESENTATION_DATA";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_26(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "ACDB_DYNAMICBLOCKPURGEPREVENTER_VERSION");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbDynamicBlockPurgePreventer";
        dxfClass.DxfName = "ACDB_DYNAMICBLOCKPURGEPREVENTER_VERSION";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 61;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_27(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKLINEARGRIP");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockLinearGrip";
        dxfClass.DxfName = "BLOCKLINEARGRIP";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_28(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKLOOKUPGRIP");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockLookupGrip";
        dxfClass.DxfName = "BLOCKLOOKUPGRIP";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_29(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKPOLARGRIP");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockPolarGrip";
        dxfClass.DxfName = "BLOCKPOLARGRIP";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_30(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKPROPERTIESTABLEGRIP");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockPropertiesTableGrip";
        dxfClass.DxfName = "BLOCKPROPERTIESTABLEGRIP";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_31(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKROTATIONGRIP");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockRotationGrip";
        dxfClass.DxfName = "BLOCKROTATIONGRIP";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_32(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKVISIBILITYGRIP");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockVisibilityGrip";
        dxfClass.DxfName = "BLOCKVISIBILITYGRIP";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_33(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKXYGRIP");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockXYGrip";
        dxfClass.DxfName = "BLOCKXYGRIP";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_34(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKGRIPLOCATIONCOMPONENT");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockGripExpr";
        dxfClass.DxfName = "BLOCKGRIPLOCATIONCOMPONENT";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_35(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "ACDB_DYNAMICBLOCKPROXYNODE");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbDynamicBlockProxyNode";
        dxfClass.DxfName = "ACDB_DYNAMICBLOCKPROXYNODE";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_36(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKPOLARPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockPolarParameter";
        dxfClass.DxfName = "BLOCKPOLARPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_37(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKROTATIONPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockRotationParameter";
        dxfClass.DxfName = "BLOCKROTATIONPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_38(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKSCALEACTION");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockScaleAction";
        dxfClass.DxfName = "BLOCKSCALEACTION";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_39(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKLOOKUPACTION");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockLookupAction";
        dxfClass.DxfName = "BLOCKLOOKUPACTION";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_40(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKARRAYACTION");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockArrayAction";
        dxfClass.DxfName = "BLOCKARRAYACTION";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_41(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKPOLARSTRETCHACTION");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockPolarStretchAction";
        dxfClass.DxfName = "BLOCKPOLARSTRETCHACTION";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_42(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKSTRETCHACTION");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockStretchAction";
        dxfClass.DxfName = "BLOCKSTRETCHACTION";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_43(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKMOVEACTION");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockMoveAction";
        dxfClass.DxfName = "BLOCKMOVEACTION";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_44(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKFLIPACTION");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockFlipAction";
        dxfClass.DxfName = "BLOCKFLIPACTION";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_45(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKROTATEACTION");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockRotateAction";
        dxfClass.DxfName = "BLOCKROTATEACTION";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_46(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKXYPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockXYParameter";
        dxfClass.DxfName = "BLOCKXYPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_47(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKLINEARPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockLinearParameter";
        dxfClass.DxfName = "BLOCKLINEARPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_48(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKFLIPPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockFlipParameter";
        dxfClass.DxfName = "BLOCKFLIPPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_49(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKALIGNMENTPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockAlignmentParameter";
        dxfClass.DxfName = "BLOCKALIGNMENTPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_50(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKBASEPOINTPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockBasepointParameter";
        dxfClass.DxfName = "BLOCKBASEPOINTPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_51(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKLOOKUPPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockLookupParameter";
        dxfClass.DxfName = "BLOCKLOOKUPPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_52(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKVISIBILITYPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockVisibilityParameter";
        dxfClass.DxfName = "BLOCKVISIBILITYPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_53(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKLINEARCONSTRAINTPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockLinearConstraintParameter";
        dxfClass.DxfName = "BLOCKLINEARCONSTRAINTPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1024Beta;
        dxfClass.MaintenanceVersion = (short) 1;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_54(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKHORIZONTALCONSTRAINTPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockHorizontalConstraintParameter";
        dxfClass.DxfName = "BLOCKHORIZONTALCONSTRAINTPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1024Beta;
        dxfClass.MaintenanceVersion = (short) 1;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_55(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKVERTICALCONSTRAINTPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockVerticalConstraintParameter";
        dxfClass.DxfName = "BLOCKVERTICALCONSTRAINTPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1024Beta;
        dxfClass.MaintenanceVersion = (short) 1;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_56(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKALIGNEDCONSTRAINTPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockAlignedConstraintParameter";
        dxfClass.DxfName = "BLOCKALIGNEDCONSTRAINTPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1024Beta;
        dxfClass.MaintenanceVersion = (short) 1;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_57(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKANGULARCONSTRAINTPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockAngularConstraintParameter";
        dxfClass.DxfName = "BLOCKANGULARCONSTRAINTPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1024Beta;
        dxfClass.MaintenanceVersion = (short) 1;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_58(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKDIAMETRICCONSTRAINTPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockDiametricConstraintParameter";
        dxfClass.DxfName = "BLOCKDIAMETRICCONSTRAINTPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1024Beta;
        dxfClass.MaintenanceVersion = (short) 1;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_59(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKRADIALCONSTRAINTPARAMETER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockRadialConstraintParameter";
        dxfClass.DxfName = "BLOCKRADIALCONSTRAINTPARAMETER";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1024Beta;
        dxfClass.MaintenanceVersion = (short) 1;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_60(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "BLOCKPROPERTIESTABLE");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbBlockPropertiesTable";
        dxfClass.DxfName = "BLOCKPROPERTIESTABLE";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_61(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "ACAD_EVALUATION_GRAPH");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.CPlusPlusClassName = "AcDbEvalGraph";
        dxfClass.DxfName = "ACAD_EVALUATION_GRAPH";
        dxfClass.ItemClassId = (short) 499;
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 55;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_62(
      DxfClassCollection classes,
      string name,
      string dxfname)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, dxfname);
      if (dxfClass == null)
      {
        dxfClass = new DxfClass()
        {
          ApplicationName = "ObjectDBX Classes",
          ClassNumber = (short) (500 + classes.Count),
          CPlusPlusClassName = name,
          DxfName = dxfname,
          ItemClassId = (short) 499,
          DwgVersion = DwgVersion.Dwg1021,
          MaintenanceVersion = (short) 0,
          ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog
        };
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal static DxfClass smethod_63(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbAnnotScaleObjectContextData", "ACDB_ANNOTSCALEOBJECTCONTEXTDATA_CLASS");
    }

    internal static DxfClass smethod_64(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbMTextObjectContextData", "ACDB_MTEXTOBJECTCONTEXTDATA_CLASS");
    }

    internal static DxfClass smethod_65(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbBlkRefObjectContextData", "ACDB_BLKREFOBJECTCONTEXTDATA_CLASS");
    }

    internal static DxfClass smethod_66(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbFcfObjectContextData", "ACDB_FCFOBJECTCONTEXTDATA_CLASS");
    }

    internal static DxfClass smethod_67(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbHatchScaleContextData", "ACDB_HATCHSCALECONTEXTDATA_CLASS");
    }

    internal static DxfClass smethod_68(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbDimensionObjectContextData", "ACDB_DIMENSIONOBJECTCONTEXTDATA_CLASS");
    }

    internal static DxfClass smethod_69(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbAlignedDimensionObjectContextData", "ACDB_ALDIMOBJECTCONTEXTDATA_CLASS");
    }

    internal static DxfClass smethod_70(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbAngularDimensionObjectContextData", "ACDB_ANGDIMOBJECTCONTEXTDATA_CLASS");
    }

    internal static DxfClass smethod_71(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbDiametricDimensionObjectContextData", "ACDB_DMDIMOBJECTCONTEXTDATA_CLASS");
    }

    internal static DxfClass smethod_72(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbOrdinateDimensionObjectContextData", "ACDB_ORDDIMOBJECTCONTEXTDATA_CLASS");
    }

    internal static DxfClass smethod_73(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbRadialDimensionObjectContextData", "ACDB_RADIMOBJECTCONTEXTDATA_CLASS");
    }

    internal static DxfClass smethod_74(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbRadialDimensionLargeObjectContextData", "ACDB_RADIMLGOBJECTCONTEXTDATA_CLASS");
    }

    internal static DxfClass smethod_75(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbHatchViewContextData", "ACDB_HATCHVIEWCONTEXTDATA_CLASS");
    }

    internal static DxfClass smethod_76(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbTextObjectContextData", "ACDB_TEXTOBJECTCONTEXTDATA_CLASS");
    }

    internal static DxfClass smethod_77(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbMLeaderObjectContextData", "ACDB_MLEADEROBJECTCONTEXTDATA_CLASS");
    }

    internal static DxfClass smethod_78(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbLeaderObjectContextData", "ACDB_LEADEROBJECTCONTEXTDATA_CLASS");
    }

    internal static DxfClass smethod_79(DxfClassCollection classes)
    {
      return DxfClass.smethod_62(classes, "AcDbMTextAttributeObjectContextData", "ACDB_MTEXTATTRIBUTEOBJECTCONTEXTDATA_CLASS");
    }

    internal static DxfClass GetClassWithDxfName(DxfClassCollection classes, string dxfName)
    {
      DxfClass dxfClass1 = (DxfClass) null;
      foreach (DxfClass dxfClass2 in (List<DxfClass>) classes)
      {
        if (dxfClass2.DxfName == dxfName)
        {
          dxfClass1 = dxfClass2;
          break;
        }
      }
      return dxfClass1;
    }

    public object Clone()
    {
      DxfClass dxfClass = new DxfClass();
      dxfClass.CopyFrom(this);
      return (object) dxfClass;
    }

    public void CopyFrom(DxfClass from)
    {
      this.short_1 = from.short_1;
      this.dwgVersion_0 = from.dwgVersion_0;
      this.short_2 = from.short_2;
      this.proxyFlags_0 = from.proxyFlags_0;
      this.string_6 = from.string_6;
      this.string_7 = from.string_7;
      this.string_8 = from.string_8;
      this.bool_0 = from.bool_0;
      this.short_3 = from.short_3;
    }

    public IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfClass dxfClass = (DxfClass) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfClass);
        dxfClass.CopyFrom(this);
      }
      return (IGraphCloneable) dxfClass;
    }
  }
}
