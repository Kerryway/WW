// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfWipeoutVariables
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns3;
using WW.Cad.Base;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects
{
  public class DxfWipeoutVariables : DxfObject
  {
    private short short_0 = 1;

    public bool DisplayFrame
    {
      get
      {
        return ((int) this.short_0 & 1) != 0;
      }
      set
      {
        if (value)
          this.short_0 |= (short) 1;
        else
          this.short_0 &= (short) -2;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "WIPEOUTVARIABLES";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbWipeoutVariables";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfWipeoutVariables wipeoutVariables = (DxfWipeoutVariables) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (wipeoutVariables == null)
      {
        wipeoutVariables = new DxfWipeoutVariables();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) wipeoutVariables);
        wipeoutVariables.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) wipeoutVariables;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      this.short_0 = ((DxfWipeoutVariables) from).short_0;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_23.ClassNumber;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      ow.ObjectWriter.imethod_32(this.short_0);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      this.short_0 = or.ObjectBitStream.imethod_14();
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_234("AcDbWipeoutVariables");
      w.method_219(70, this.short_0);
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      if (r.CurrentGroup.Code != 100)
        throw new DxfException("Expected subclass marker.");
      switch ((string) r.CurrentGroup.Value)
      {
        case "AcDbWipeoutVariables":
          this.method_8(r, objectBuilder);
          break;
        default:
          r.method_85();
          break;
      }
    }

    private void method_8(DxfReader r, Class259 objectBuilder)
    {
      r.method_91("AcDbWipeoutVariables");
      r.method_85();
      while (!r.method_92("AcDbWipeoutVariables"))
      {
        if (!this.method_9(r, objectBuilder))
          r.method_85();
      }
    }

    private bool method_9(DxfReader r, Class259 objectBuilder)
    {
      if (r.CurrentGroup.Code != 70)
        return this.method_6(r, objectBuilder);
      this.short_0 = (short) r.CurrentGroup.Value;
      r.method_85();
      return true;
    }

    internal static DxfClass smethod_2(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "WIPEOUTVARIABLES");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ISM";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1015;
        dxfClass.MaintenanceVersion = (short) 0;
        dxfClass.ProxyFlags = ProxyFlags.R13FormatProxy;
        dxfClass.CPlusPlusClassName = "AcDbWipeoutVariables";
        dxfClass.DxfName = "WIPEOUTVARIABLES";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }
  }
}
