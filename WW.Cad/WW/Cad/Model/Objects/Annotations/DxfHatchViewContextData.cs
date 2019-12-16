// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.Annotations.DxfHatchViewContextData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using ns3;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model.Entities;

namespace WW.Cad.Model.Objects.Annotations
{
  public class DxfHatchViewContextData : DxfHatchScaleContextData
  {
    private DxfObjectReference dxfObjectReference_4;
    private WW.Math.Vector3D vector3D_1;
    private double double_1;
    private bool bool_1;

    public DxfHatchViewContextData()
    {
    }

    public DxfHatchViewContextData(DxfHatch hatch, DxfScale scale)
      : base(hatch, scale)
    {
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override string AcClass
    {
      get
      {
        return "AcDbHatchViewContextData";
      }
    }

    public override string ObjectType
    {
      get
      {
        return "ACDB_HATCHVIEWCONTEXTDATA_CLASS";
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfHatchViewContextData hatchViewContextData = (DxfHatchViewContextData) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (hatchViewContextData == null)
      {
        hatchViewContextData = new DxfHatchViewContextData();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) hatchViewContextData);
        hatchViewContextData.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) hatchViewContextData;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfHatchViewContextData hatchViewContextData = (DxfHatchViewContextData) from;
      this.dxfObjectReference_4 = hatchViewContextData.dxfObjectReference_4;
      this.vector3D_1 = hatchViewContextData.vector3D_1;
      this.double_1 = hatchViewContextData.double_1;
      this.bool_1 = hatchViewContextData.bool_1;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1031_0.dxfClass_4.ClassNumber;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      Interface29 objectWriter = ow.ObjectWriter;
      objectWriter.imethod_40(this.dxfObjectReference_4 == null ? (DxfHandledObject) null : (DxfHandledObject) this.dxfObjectReference_4.Value);
      objectWriter.imethod_29(this.vector3D_1);
      objectWriter.imethod_16(this.double_1);
      objectWriter.imethod_14(this.bool_1);
    }

    internal override Class259 vmethod_9(FileFormat fileFormat)
    {
      return (Class259) new DxfHatchViewContextData.Class312((DxfHandledObject) this);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      Interface30 objectBitStream = or.ObjectBitStream;
      ((DxfHatchViewContextData.Class312) ob).ViewportHandle = or.method_100();
      this.vector3D_1 = objectBitStream.imethod_51();
      this.double_1 = objectBitStream.imethod_8();
      this.bool_1 = objectBitStream.imethod_6();
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_234("AcDbHatchViewContextData");
      w.method_218(330, this.dxfObjectReference_4 == null ? (DxfHandledObject) null : (DxfHandledObject) this.dxfObjectReference_4.Value);
      w.Write(10, this.vector3D_1);
      w.Write(51, (object) this.double_1);
      w.Write(290, (object) this.bool_1);
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      if (r.CurrentGroup.Code != 100 || (string) r.CurrentGroup.Value != "AcDbHatchViewContextData")
        throw new DxfException("Expected subclass marker.");
      r.method_85();
      while (!r.method_92("AcDbHatchViewContextData"))
      {
        switch (r.CurrentGroup.Code)
        {
          case 10:
            this.vector3D_1.X = (double) r.CurrentGroup.Value;
            break;
          case 20:
            this.vector3D_1.Y = (double) r.CurrentGroup.Value;
            break;
          case 30:
            this.vector3D_1.Z = (double) r.CurrentGroup.Value;
            break;
          case 51:
            this.double_1 = (double) r.CurrentGroup.Value;
            break;
          case 290:
            this.bool_1 = (bool) r.CurrentGroup.Value;
            break;
          case 330:
            ((DxfHatchViewContextData.Class312) objectBuilder).ViewportHandle = (ulong) r.CurrentGroup.Value;
            break;
        }
        r.method_85();
      }
    }

    private class Class312 : DxfAnnotationScaleObjectContextData.Class310
    {
      public Class312(DxfHandledObject handledObject)
        : base(handledObject)
      {
      }

      public ulong ViewportHandle { private get; set; }

      public override void ResolveReferences(Class374 modelBuilder)
      {
        base.ResolveReferences(modelBuilder);
        DxfViewport dxfViewport = modelBuilder.method_4<DxfViewport>(this.ViewportHandle);
        if (dxfViewport == null)
          return;
        ((DxfHatchViewContextData) this.HandledObject).dxfObjectReference_4 = DxfObjectReference.GetReference((IDxfHandledObject) dxfViewport);
      }
    }
  }
}
