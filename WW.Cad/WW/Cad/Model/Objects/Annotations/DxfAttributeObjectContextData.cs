// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.Annotations.DxfAttributeObjectContextData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using ns3;
using WW.Cad.IO;
using WW.Cad.Model.Entities;

namespace WW.Cad.Model.Objects.Annotations
{
  public class DxfAttributeObjectContextData : DxfTextObjectContextData
  {
    private DxfMTextObjectContextData dxfMTextObjectContextData_0;

    public DxfMTextObjectContextData Mtext
    {
      get
      {
        return this.dxfMTextObjectContextData_0;
      }
      set
      {
        this.dxfMTextObjectContextData_0 = value;
      }
    }

    public DxfAttributeObjectContextData()
    {
    }

    public DxfAttributeObjectContextData(DxfAttribute attribute, DxfScale scale)
      : base((DxfText) attribute, scale)
    {
      DxfMText mtext = attribute.method_21();
      this.dxfMTextObjectContextData_0 = mtext != null ? new DxfMTextObjectContextData(mtext, scale) : (DxfMTextObjectContextData) null;
    }

    public DxfAttributeObjectContextData(DxfAttributeDefinition attribute, DxfScale scale)
      : base((DxfText) attribute, scale)
    {
      DxfMText mtext = attribute.method_21();
      this.dxfMTextObjectContextData_0 = mtext != null ? new DxfMTextObjectContextData(mtext, scale) : (DxfMTextObjectContextData) null;
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override string AcClass
    {
      get
      {
        return "AcDbMTextAttributeObjectContextData";
      }
    }

    public override string ObjectType
    {
      get
      {
        return "ACDB_MTEXTATTRIBUTEOBJECTCONTEXTDATA_CLASS";
      }
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfAttributeObjectContextData objectContextData = (DxfAttributeObjectContextData) from;
      this.dxfMTextObjectContextData_0 = objectContextData.dxfMTextObjectContextData_0 == null ? (DxfMTextObjectContextData) null : (DxfMTextObjectContextData) objectContextData.dxfMTextObjectContextData_0.Clone(cloneContext);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfAttributeObjectContextData objectContextData = (DxfAttributeObjectContextData) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (objectContextData == null)
      {
        objectContextData = new DxfAttributeObjectContextData();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) objectContextData);
        objectContextData.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) objectContextData;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1031_0.dxfClass_16.ClassNumber;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      ow.ObjectWriter.imethod_14(this.dxfMTextObjectContextData_0 != null);
      if (this.dxfMTextObjectContextData_0 == null)
        return;
      this.dxfMTextObjectContextData_0.Write(ow);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      if (or.ObjectBitStream.imethod_6())
      {
        if (this.dxfMTextObjectContextData_0 == null)
          this.dxfMTextObjectContextData_0 = new DxfMTextObjectContextData();
        this.dxfMTextObjectContextData_0.Read(or, ob);
      }
      else
        this.dxfMTextObjectContextData_0 = (DxfMTextObjectContextData) null;
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.Write(290, (object) (this.dxfMTextObjectContextData_0 != null));
      if (this.dxfMTextObjectContextData_0 == null)
        return;
      w.Write(101, (object) "Embedded Object");
      this.dxfMTextObjectContextData_0.Write(w);
    }

    internal override void vmethod_11(DxfReader r, Class259 objectBuilder)
    {
      while (!r.method_92("AcDbMTextAttributeObjectContextData"))
      {
        if (this.method_8(r.CurrentGroup) || r.CurrentGroup.Code != 101)
        {
          r.method_85();
        }
        else
        {
          r.method_85();
          this.dxfMTextObjectContextData_0 = new DxfMTextObjectContextData();
          this.dxfMTextObjectContextData_0.Read(r, objectBuilder);
          break;
        }
      }
    }

    internal override Class259 vmethod_9(FileFormat fileFormat)
    {
      return (Class259) new DxfAttributeObjectContextData.Class311((DxfHandledObject) this);
    }

    internal class Class311 : DxfAnnotationScaleObjectContextData.Class310
    {
      public Class311(DxfHandledObject handledObject)
        : base(handledObject)
      {
      }

      public override void ResolveReferences(Class374 modelBuilder)
      {
        base.ResolveReferences(modelBuilder);
        DxfAttributeObjectContextData handledObject = (DxfAttributeObjectContextData) this.HandledObject;
        if (handledObject.Mtext == null)
          return;
        handledObject.Mtext.Scale = handledObject.Scale;
      }
    }
  }
}
