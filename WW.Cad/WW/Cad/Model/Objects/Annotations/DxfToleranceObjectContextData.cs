// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.Annotations.DxfToleranceObjectContextData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns3;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model.Entities;

namespace WW.Cad.Model.Objects.Annotations
{
  public class DxfToleranceObjectContextData : DxfAnnotationScaleObjectContextData
  {
    private WW.Math.Vector3D vector3D_0 = WW.Math.Vector3D.XAxis;
    private WW.Math.Point3D point3D_0;

    public WW.Math.Point3D InsertionPoint
    {
      get
      {
        return this.point3D_0;
      }
      set
      {
        this.point3D_0 = value;
      }
    }

    public WW.Math.Vector3D XAxis
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        this.vector3D_0 = value;
      }
    }

    public DxfToleranceObjectContextData()
    {
    }

    public DxfToleranceObjectContextData(DxfTolerance tolerance, DxfScale scale)
      : base(scale)
    {
      this.point3D_0 = tolerance.InsertionPoint;
      this.vector3D_0 = tolerance.XAxis;
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override string AcClass
    {
      get
      {
        return "AcDbFcfObjectContextData";
      }
    }

    public override string ObjectType
    {
      get
      {
        return "ACDB_FCFOBJECTCONTEXTDATA_CLASS";
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1031_0.dxfClass_3.ClassNumber;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfToleranceObjectContextData objectContextData = (DxfToleranceObjectContextData) from;
      this.point3D_0 = objectContextData.InsertionPoint;
      this.vector3D_0 = objectContextData.XAxis;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfToleranceObjectContextData objectContextData = (DxfToleranceObjectContextData) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (objectContextData == null)
      {
        objectContextData = new DxfToleranceObjectContextData();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) objectContextData);
        objectContextData.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) objectContextData;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      Interface29 objectWriter = ow.ObjectWriter;
      objectWriter.imethod_24(this.point3D_0);
      objectWriter.imethod_29(this.vector3D_0);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      Interface30 objectBitStream = or.ObjectBitStream;
      this.point3D_0 = objectBitStream.imethod_39();
      this.vector3D_0 = objectBitStream.imethod_51();
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.Write(10, this.point3D_0);
      w.Write(11, this.vector3D_0);
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      while (!r.method_92(this.AcClass))
      {
        switch (r.CurrentGroup.Code)
        {
          case 10:
            this.point3D_0.X = (double) r.CurrentGroup.Value;
            break;
          case 11:
            this.vector3D_0.X = (double) r.CurrentGroup.Value;
            break;
          case 20:
            this.point3D_0.Y = (double) r.CurrentGroup.Value;
            break;
          case 21:
            this.vector3D_0.Y = (double) r.CurrentGroup.Value;
            break;
          case 30:
            this.point3D_0.Z = (double) r.CurrentGroup.Value;
            break;
          case 31:
            this.vector3D_0.Y = (double) r.CurrentGroup.Value;
            break;
          default:
            throw new DxfException("Unexpected group code.");
        }
        r.method_85();
      }
    }
  }
}
