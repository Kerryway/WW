// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.Annotations.DxfMLeaderObjectContextData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects.Annotations
{
  public class DxfMLeaderObjectContextData : DxfMLeaderAnnotationContext
  {
    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfMLeaderObjectContextData objectContextData = (DxfMLeaderObjectContextData) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (objectContextData == null)
      {
        objectContextData = new DxfMLeaderObjectContextData();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) objectContextData);
        objectContextData.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) objectContextData;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_9.ClassNumber;
    }

    internal static DxfClass smethod_16(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "ACDB_MLEADEROBJECTCONTEXTDATA_CLASS");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1021;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        dxfClass.CPlusPlusClassName = "AcDbMLeaderObjectContextData";
        dxfClass.DxfName = "ACDB_MLEADEROBJECTCONTEXTDATA_CLASS";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal override void Write(DxfWriter w)
    {
      this.WriteMyFields(w, w.Version <= DxfVersion.Dxf21);
    }
  }
}
