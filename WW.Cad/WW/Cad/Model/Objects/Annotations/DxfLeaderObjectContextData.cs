// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.Annotations.DxfLeaderObjectContextData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns3;
using System.Collections.Generic;
using System.Linq;
using WW.Cad.IO;
using WW.Cad.Model.Entities;

namespace WW.Cad.Model.Objects.Annotations
{
  public class DxfLeaderObjectContextData : DxfAnnotationScaleObjectContextData
  {
    private List<WW.Math.Point3D> list_0 = new List<WW.Math.Point3D>();
    private WW.Math.Vector3D vector3D_2 = WW.Math.Vector3D.XAxis;
    private WW.Math.Vector3D vector3D_0;
    private WW.Math.Vector3D vector3D_1;
    private HookLineDirection hookLineDirection_0;

    public HookLineDirection HookLineDirection
    {
      get
      {
        return this.hookLineDirection_0;
      }
      set
      {
        this.hookLineDirection_0 = value;
      }
    }

    public WW.Math.Vector3D HorizontalDirection
    {
      get
      {
        return this.vector3D_2;
      }
      set
      {
        this.vector3D_2 = value;
      }
    }

    public WW.Math.Vector3D LastVertexOffsetFromAnnotation
    {
      get
      {
        return this.vector3D_1;
      }
      set
      {
        this.vector3D_1 = value;
      }
    }

    public WW.Math.Vector3D LastVertexOffsetFromBlock
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

    public List<WW.Math.Point3D> Vertices
    {
      get
      {
        return this.list_0;
      }
      set
      {
        this.list_0 = value;
      }
    }

    public DxfLeaderObjectContextData()
    {
    }

    public DxfLeaderObjectContextData(DxfLeader leader, DxfScale scale)
      : base(scale)
    {
      this.list_0 = new List<WW.Math.Point3D>((IEnumerable<WW.Math.Point3D>) leader.Vertices);
      this.vector3D_0 = leader.LastVertexOffsetFromBlock;
      this.vector3D_1 = leader.LastVertexOffsetFromAnnotation;
      this.vector3D_2 = leader.HorizontalDirection;
      this.hookLineDirection_0 = leader.HookLineDirection;
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override string AcClass
    {
      get
      {
        return "AcDbLeaderObjectContextData";
      }
    }

    public override string ObjectType
    {
      get
      {
        return "ACDB_LEADEROBJECTCONTEXTDATA_CLASS";
      }
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfLeaderObjectContextData objectContextData = (DxfLeaderObjectContextData) from;
      this.list_0 = new List<WW.Math.Point3D>((IEnumerable<WW.Math.Point3D>) objectContextData.Vertices);
      this.vector3D_0 = objectContextData.LastVertexOffsetFromBlock;
      this.vector3D_1 = objectContextData.LastVertexOffsetFromAnnotation;
      this.vector3D_2 = objectContextData.HorizontalDirection;
      this.hookLineDirection_0 = objectContextData.HookLineDirection;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfLeaderObjectContextData objectContextData = (DxfLeaderObjectContextData) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (objectContextData == null)
      {
        objectContextData = new DxfLeaderObjectContextData();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) objectContextData);
        objectContextData.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) objectContextData;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1031_0.dxfClass_15.ClassNumber;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      Interface29 objectWriter = ow.ObjectWriter;
      objectWriter.imethod_32((short) this.list_0.Count);
      foreach (WW.Math.Point3D point3D in this.list_0)
        objectWriter.imethod_24(point3D);
      objectWriter.imethod_29(this.vector3D_2);
      objectWriter.imethod_14(this.hookLineDirection_0 == HookLineDirection.Same);
      objectWriter.imethod_29(this.vector3D_0);
      objectWriter.imethod_29(this.vector3D_1);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      Interface30 objectBitStream = or.ObjectBitStream;
      int num = (int) objectBitStream.imethod_14();
      this.list_0.Clear();
      for (int index = 0; index < num; ++index)
        this.list_0.Add(objectBitStream.imethod_39());
      this.vector3D_2 = objectBitStream.imethod_51();
      this.hookLineDirection_0 = objectBitStream.imethod_6() ? HookLineDirection.Same : HookLineDirection.Opposite;
      this.vector3D_0 = objectBitStream.imethod_51();
      this.vector3D_1 = objectBitStream.imethod_51();
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_219(70, (short) this.list_0.Count);
      foreach (WW.Math.Point3D p in this.list_0)
        w.Write(10, p);
      w.Write(11, this.vector3D_2);
      w.Write(290, (object) (this.hookLineDirection_0 == HookLineDirection.Same));
      w.Write(12, this.vector3D_0);
      w.Write(13, this.vector3D_1);
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      while (!r.method_92(this.AcClass))
      {
        WW.Math.Point3D point3D;
        switch (r.CurrentGroup.Code)
        {
          case 10:
            this.list_0.Add(new WW.Math.Point3D((double) r.CurrentGroup.Value, 0.0, 0.0));
            break;
          case 11:
            this.vector3D_2.X = (double) r.CurrentGroup.Value;
            break;
          case 12:
            this.vector3D_0.X = (double) r.CurrentGroup.Value;
            break;
          case 13:
            this.vector3D_1.X = (double) r.CurrentGroup.Value;
            break;
          case 20:
            point3D = this.list_0.Last<WW.Math.Point3D>();
            point3D.Y = (double) r.CurrentGroup.Value;
            this.list_0[this.list_0.Count - 1] = point3D;
            break;
          case 21:
            this.vector3D_2.Y = (double) r.CurrentGroup.Value;
            break;
          case 22:
            this.vector3D_0.Y = (double) r.CurrentGroup.Value;
            break;
          case 23:
            this.vector3D_1.Y = (double) r.CurrentGroup.Value;
            break;
          case 30:
            point3D = this.list_0.Last<WW.Math.Point3D>();
            point3D.Z = (double) r.CurrentGroup.Value;
            this.list_0[this.list_0.Count - 1] = point3D;
            break;
          case 31:
            this.vector3D_2.Z = (double) r.CurrentGroup.Value;
            break;
          case 32:
            this.vector3D_0.Z = (double) r.CurrentGroup.Value;
            break;
          case 33:
            this.vector3D_1.Z = (double) r.CurrentGroup.Value;
            break;
          case 290:
            this.hookLineDirection_0 = (bool) r.CurrentGroup.Value ? HookLineDirection.Same : HookLineDirection.Opposite;
            break;
        }
        r.method_85();
      }
    }
  }
}
