// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.Annotations.DxfObjectContextData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns3;
using WW.Cad.Base;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects.Annotations
{
  public abstract class DxfObjectContextData : DxfObject
  {
    private short short_0 = 4;
    private bool bool_0;

    public short Version
    {
      get
      {
        return this.short_0;
      }
      set
      {
        this.short_0 = value;
      }
    }

    public bool IsDefault
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

    public override string AcClass
    {
      get
      {
        return "AcDbObjectContextData";
      }
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfObjectContextData objectContextData = (DxfObjectContextData) from;
      this.IsDefault = objectContextData.IsDefault;
      this.Version = objectContextData.Version;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      ow.ObjectWriter.imethod_32(this.Version);
      ow.ObjectWriter.imethod_14(this.IsDefault);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      this.Version = or.ObjectBitStream.imethod_14();
      this.IsDefault = or.ObjectBitStream.imethod_6();
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_234("AcDbObjectContextData");
      w.method_219(70, this.Version);
      w.Write(290, (object) this.IsDefault);
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      if (r.CurrentGroup.Code != 100 || (string) r.CurrentGroup.Value != "AcDbObjectContextData")
        throw new DxfException("Expected subclass marker.");
      r.method_85();
      while (!r.method_92("AcDbObjectContextData"))
      {
        switch (r.CurrentGroup.Code)
        {
          case 70:
            this.Version = (short) r.CurrentGroup.Value;
            break;
          case 290:
            this.IsDefault = (bool) r.CurrentGroup.Value;
            break;
          default:
            throw new DxfException("Unexpected group code.");
        }
        r.method_85();
      }
    }
  }
}
