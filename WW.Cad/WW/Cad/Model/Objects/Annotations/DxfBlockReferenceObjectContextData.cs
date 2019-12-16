// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.Annotations.DxfBlockReferenceObjectContextData
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
  public class DxfBlockReferenceObjectContextData : DxfAnnotationScaleObjectContextData
  {
    private WW.Math.Vector3D vector3D_0 = new WW.Math.Vector3D(1.0, 1.0, 1.0);
    private WW.Math.Point3D point3D_0 = WW.Math.Point3D.Zero;
    private double double_0;

    public double Rotation
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
      }
    }

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

    public WW.Math.Vector3D ScaleFactor
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

    public DxfBlockReferenceObjectContextData()
    {
    }

    public DxfBlockReferenceObjectContextData(DxfInsertBase insert, DxfScale scale)
      : base(scale)
    {
      this.vector3D_0 = insert.ScaleFactor;
      this.point3D_0 = insert.InsertionPoint;
      this.Rotation = insert.Rotation;
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlkRefObjectContextData";
      }
    }

    public override string ObjectType
    {
      get
      {
        return "ACDB_BLKREFOBJECTCONTEXTDATA_CLASS";
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1031_0.dxfClass_2.ClassNumber;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockReferenceObjectContextData objectContextData = (DxfBlockReferenceObjectContextData) from;
      this.ScaleFactor = objectContextData.ScaleFactor;
      this.Rotation = objectContextData.Rotation;
      this.InsertionPoint = objectContextData.InsertionPoint;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockReferenceObjectContextData objectContextData = (DxfBlockReferenceObjectContextData) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (objectContextData == null)
      {
        objectContextData = new DxfBlockReferenceObjectContextData();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) objectContextData);
        objectContextData.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) objectContextData;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      Interface29 objectWriter = ow.ObjectWriter;
      objectWriter.imethod_16(this.double_0);
      objectWriter.imethod_24(this.point3D_0);
      objectWriter.imethod_16(this.vector3D_0.X);
      objectWriter.imethod_16(this.vector3D_0.Y);
      objectWriter.imethod_16(this.vector3D_0.Z);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      Interface30 objectBitStream = or.ObjectBitStream;
      this.double_0 = objectBitStream.imethod_8();
      this.point3D_0 = objectBitStream.imethod_39();
      this.vector3D_0.X = objectBitStream.imethod_8();
      this.vector3D_0.Y = objectBitStream.imethod_8();
      this.vector3D_0.Z = objectBitStream.imethod_8();
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.Write(50, (object) (this.double_0 * (180.0 / System.Math.PI)));
      w.Write(10, this.point3D_0);
      w.Write(41, (object) this.vector3D_0.X);
      w.Write(42, (object) this.vector3D_0.Y);
      w.Write(43, (object) this.vector3D_0.Z);
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      while (!r.method_92("AcDbBlkRefObjectContextData"))
      {
        switch (r.CurrentGroup.Code)
        {
          case 10:
            this.point3D_0.X = (double) r.CurrentGroup.Value;
            break;
          case 20:
            this.point3D_0.Y = (double) r.CurrentGroup.Value;
            break;
          case 30:
            this.point3D_0.Z = (double) r.CurrentGroup.Value;
            break;
          case 41:
            this.vector3D_0.X = (double) r.CurrentGroup.Value;
            break;
          case 42:
            this.vector3D_0.Y = (double) r.CurrentGroup.Value;
            break;
          case 43:
            this.vector3D_0.Y = (double) r.CurrentGroup.Value;
            break;
          case 50:
            this.double_0 = (double) r.CurrentGroup.Value * (System.Math.PI / 180.0);
            break;
          default:
            throw new DxfException("Unexpected group code.");
        }
        r.method_85();
      }
    }
  }
}
