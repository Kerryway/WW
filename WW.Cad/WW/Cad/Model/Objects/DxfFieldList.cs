// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfFieldList
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System.Collections.Generic;

namespace WW.Cad.Model.Objects
{
  public class DxfFieldList : DxfObject
  {
    private DxfHandledObjectCollection<DxfField> dxfHandledObjectCollection_1 = new DxfHandledObjectCollection<DxfField>();
    private bool bool_0;

    public IList<DxfField> Fields
    {
      get
      {
        return (IList<DxfField>) this.dxfHandledObjectCollection_1;
      }
    }

    internal bool Unknown1
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

    public override string ObjectType
    {
      get
      {
        return "FIELDLIST";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbField";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf15OrHigher;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfFieldList dxfFieldList = (DxfFieldList) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfFieldList == null)
      {
        dxfFieldList = new DxfFieldList();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfFieldList);
        dxfFieldList.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfFieldList;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfFieldList dxfFieldList = (DxfFieldList) from;
      if (cloneContext.SourceModel == cloneContext.TargetModel)
      {
        this.dxfHandledObjectCollection_1.AddRange((IEnumerable<DxfField>) dxfFieldList.dxfHandledObjectCollection_1);
      }
      else
      {
        foreach (DxfHandledObject dxfHandledObject in dxfFieldList.dxfHandledObjectCollection_1)
          this.dxfHandledObjectCollection_1.Add((DxfField) dxfHandledObject.Clone(cloneContext));
      }
      this.bool_0 = dxfFieldList.bool_0;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_3.ClassNumber;
    }

    internal static DxfClass smethod_2(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "FIELDLIST");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        dxfClass.CPlusPlusClassName = "AcDbFieldList";
        dxfClass.DxfName = "FIELDLIST";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }
  }
}
