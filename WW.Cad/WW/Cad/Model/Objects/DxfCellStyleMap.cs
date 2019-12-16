// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfCellStyleMap
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System.Collections.ObjectModel;
using WW.Cad.Model.Entities;

namespace WW.Cad.Model.Objects
{
  public class DxfCellStyleMap : DxfObject, INamedObject
  {
    private DxfTableCellStyleCollection dxfTableCellStyleCollection_0 = new DxfTableCellStyleCollection();

    public DxfTableCellStyleCollection CellStyles
    {
      get
      {
        return this.dxfTableCellStyleCollection_0;
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_18.ClassNumber;
    }

    public override string ObjectType
    {
      get
      {
        return "CELLSTYLEMAP";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbCellStyleMap";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfObject dxfObject = (DxfObject) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfObject == null)
      {
        dxfObject = (DxfObject) new DxfCellStyleMap();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfObject);
        dxfObject.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfObject;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      foreach (DxfContentFormat dxfContentFormat in (Collection<DxfTableCellStyle>) ((DxfCellStyleMap) from).dxfTableCellStyleCollection_0)
        this.dxfTableCellStyleCollection_0.Add((DxfTableCellStyle) dxfContentFormat.Clone(cloneContext));
    }

    public string Name
    {
      get
      {
        return "ACAD_ROUNDTRIP_2008_TABLESTYLE_CELLSTYLEMAP";
      }
      set
      {
      }
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return DxfTable.smethod_2(model);
    }
  }
}
