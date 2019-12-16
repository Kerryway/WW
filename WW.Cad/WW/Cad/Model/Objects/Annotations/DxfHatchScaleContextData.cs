// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.Annotations.DxfHatchScaleContextData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns3;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model.Entities;

namespace WW.Cad.Model.Objects.Annotations
{
  public class DxfHatchScaleContextData : DxfAnnotationScaleObjectContextData
  {
    private WW.Math.Vector3D vector3D_0 = WW.Math.Vector3D.XAxis;
    private readonly List<DxfHatch.BoundaryPath> list_0 = new List<DxfHatch.BoundaryPath>();
    private DxfPattern dxfPattern_0;
    private double double_0;

    public DxfHatchScaleContextData()
    {
    }

    public DxfHatchScaleContextData(DxfHatch hatch, DxfScale scale)
      : base(scale)
    {
      this.dxfPattern_0 = hatch.Pattern == null ? (DxfPattern) null : hatch.Pattern.Clone();
      this.double_0 = scale.ScaleFactor;
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override string AcClass
    {
      get
      {
        return "AcDbHatchScaleContextData";
      }
    }

    public override string ObjectType
    {
      get
      {
        return "ACDB_HATCHSCALECONTEXTDATA_CLASS";
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfHatchScaleContextData scaleContextData = (DxfHatchScaleContextData) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (scaleContextData == null)
      {
        scaleContextData = new DxfHatchScaleContextData();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) scaleContextData);
        scaleContextData.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) scaleContextData;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfHatchScaleContextData scaleContextData = (DxfHatchScaleContextData) from;
      foreach (DxfHatch.BoundaryPath boundaryPath in scaleContextData.list_0)
        this.list_0.Add(boundaryPath.Clone(cloneContext));
      this.dxfPattern_0 = scaleContextData.dxfPattern_0 == null ? (DxfPattern) null : scaleContextData.dxfPattern_0.Clone();
      this.double_0 = scaleContextData.double_0;
      this.vector3D_0 = scaleContextData.vector3D_0;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1031_0.dxfClass_4.ClassNumber;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      Interface29 objectWriter = ow.ObjectWriter;
      this.dxfPattern_0.Write(objectWriter);
      objectWriter.imethod_16(this.double_0);
      objectWriter.imethod_29(this.vector3D_0);
      objectWriter.imethod_33(this.list_0.Count);
      foreach (DxfHatch.BoundaryPath boundaryPath in this.list_0)
        boundaryPath.Write(ow, false);
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      Interface30 objectBitStream = or.ObjectBitStream;
      this.dxfPattern_0 = new DxfPattern();
      this.dxfPattern_0.Read(objectBitStream);
      this.double_0 = objectBitStream.imethod_8();
      this.vector3D_0 = objectBitStream.imethod_51();
      int num = objectBitStream.imethod_11();
      for (int index = 0; index < num; ++index)
      {
        DxfHatch.BoundaryPath boundaryPath = new DxfHatch.BoundaryPath();
        boundaryPath.Read(or, false);
        this.list_0.Add(boundaryPath);
      }
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_234("AcDbHatchObjectContextData");
      this.dxfPattern_0.Write(w);
      w.Write(40, (object) this.double_0);
      w.Write(10, this.vector3D_0);
      w.Write(90, (object) this.list_0.Count);
      foreach (DxfHatch.BoundaryPath boundaryPath in this.list_0)
      {
        w.Write(90, (object) boundaryPath.Type);
        bool flag = boundaryPath.IsPolyline ? boundaryPath.PolylineData == null : boundaryPath.Edges.Count == 0;
        w.Write(290, (object) flag);
        if (!flag)
        {
          if ((boundaryPath.Type & BoundaryPathType.IsAnnotative) != BoundaryPathType.None && boundaryPath.IsPolyline)
          {
            if (boundaryPath.PolylineData != null)
              boundaryPath.PolylineData.Write(w);
          }
          else if (!boundaryPath.IsPolyline)
            boundaryPath.method_1(w);
        }
      }
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      if (r.CurrentGroup.Code != 100 || (string) r.CurrentGroup.Value != "AcDbHatchObjectContextData")
        throw new DxfException("Expected subclass marker.");
      r.method_85();
      bool flag1 = true;
      BoundaryPathType type = BoundaryPathType.None;
      bool flag2 = true;
      while (!r.method_92("AcDbHatchScaleContextData"))
      {
        switch (r.CurrentGroup.Code)
        {
          case 10:
            this.vector3D_0.X = (double) r.CurrentGroup.Value;
            break;
          case 20:
            this.vector3D_0.Y = (double) r.CurrentGroup.Value;
            break;
          case 30:
            this.vector3D_0.Z = (double) r.CurrentGroup.Value;
            break;
          case 40:
            this.double_0 = (double) r.CurrentGroup.Value;
            break;
          case 78:
            short num = (short) r.CurrentGroup.Value;
            if (num > (short) 0)
            {
              r.method_85();
              this.dxfPattern_0 = new DxfPattern();
              this.dxfPattern_0.Read(r, (int) num);
              flag2 = false;
              break;
            }
            break;
          case 90:
            if (flag1)
            {
              flag1 = false;
              break;
            }
            type = (BoundaryPathType) r.CurrentGroup.Value;
            break;
          case 290:
            if (!(bool) r.CurrentGroup.Value)
            {
              DxfHatch.BoundaryPath boundaryPath = new DxfHatch.BoundaryPath(type);
              if ((boundaryPath.Type & BoundaryPathType.IsAnnotative) != BoundaryPathType.None && boundaryPath.IsPolyline)
              {
                boundaryPath.PolylineData = new DxfHatch.BoundaryPath.Polyline();
                r.method_85();
                boundaryPath.PolylineData.Read(r);
              }
              else if (!boundaryPath.IsPolyline)
              {
                r.method_85();
                int nrOfEdges = (int) r.CurrentGroup.Value;
                r.method_85();
                boundaryPath.method_0(nrOfEdges, r);
              }
              this.list_0.Add(boundaryPath);
              flag2 = false;
              break;
            }
            break;
        }
        if (flag2)
          r.method_85();
        else
          flag2 = true;
      }
    }
  }
}
