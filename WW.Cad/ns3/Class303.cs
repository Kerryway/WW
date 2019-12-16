// Decompiled with JetBrains decompiler
// Type: ns3.Class303
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class303 : Class285
  {
    private ulong ulong_6;
    private ulong ulong_7;
    private List<ulong> list_1;
    private ulong ulong_8;

    public Class303(DxfPolylineBase polyline)
      : base((DxfEntity) polyline)
    {
    }

    public ulong FirstVertexHandle
    {
      get
      {
        return this.ulong_6;
      }
      set
      {
        this.ulong_6 = value;
      }
    }

    public ulong LastVertexHandle
    {
      get
      {
        return this.ulong_7;
      }
      set
      {
        this.ulong_7 = value;
      }
    }

    public List<ulong> VertexHandles
    {
      get
      {
        if (this.list_1 == null)
          this.list_1 = new List<ulong>();
        return this.list_1;
      }
    }

    public ulong SequenceEndHandle
    {
      get
      {
        return this.ulong_8;
      }
      set
      {
        this.ulong_8 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfPolyline3DBase entity = (DxfPolyline3DBase) this.Entity;
      DxfPolyline3DSpline spline = entity as DxfPolyline3DSpline;
      if (spline != null)
      {
        if (this.ulong_6 != 0UL)
        {
          for (Class285 entityBuilder = modelBuilder.method_6(this.ulong_6); entityBuilder != null; entityBuilder = modelBuilder.method_7(entityBuilder))
          {
            this.method_3(modelBuilder, spline, entityBuilder);
            if ((long) entityBuilder.HandledObject.Handle == (long) this.ulong_7)
              break;
          }
        }
        else if (this.list_1 != null)
        {
          for (int index = 0; index < this.list_1.Count; ++index)
          {
            ulong handle = this.list_1[index];
            this.method_3(modelBuilder, spline, modelBuilder.method_6(handle));
          }
        }
      }
      else
      {
        DxfPolyline3D polyline = entity as DxfPolyline3D;
        if (polyline != null)
        {
          if (this.ulong_6 != 0UL)
          {
            for (Class285 entityBuilder = modelBuilder.method_6(this.ulong_6); entityBuilder != null; entityBuilder = modelBuilder.method_7(entityBuilder))
            {
              this.method_2(modelBuilder, polyline, entityBuilder);
              if ((long) entityBuilder.HandledObject.Handle == (long) this.ulong_7)
                break;
            }
          }
          else if (this.list_1 != null)
          {
            for (int index = 0; index < this.list_1.Count; ++index)
            {
              ulong handle = this.list_1[index];
              this.method_2(modelBuilder, polyline, modelBuilder.method_6(handle));
            }
          }
        }
      }
      if (this.ulong_8 == 0UL)
        return;
      DxfSequenceEnd dxfSequenceEnd = modelBuilder.method_4<DxfSequenceEnd>(this.ulong_8);
      if (dxfSequenceEnd == null)
        return;
      entity.SeqEnd = dxfSequenceEnd;
    }

    private void method_2(Class374 modelBuilder, DxfPolyline3D polyline, Class285 entityBuilder)
    {
      if (entityBuilder == null)
        return;
      Class301 class301 = entityBuilder as Class301;
      if (class301 == null)
      {
        this.method_4(modelBuilder, (DxfPolyline3DBase) polyline, entityBuilder);
      }
      else
      {
        DxfVertex3D handledObject = (DxfVertex3D) class301.HandledObject;
        polyline.Vertices.Add(handledObject);
      }
    }

    private void method_3(
      Class374 modelBuilder,
      DxfPolyline3DSpline spline,
      Class285 entityBuilder)
    {
      if (entityBuilder == null)
        return;
      Class301 class301 = entityBuilder as Class301;
      if (class301 == null)
      {
        this.method_4(modelBuilder, (DxfPolyline3DBase) spline, entityBuilder);
      }
      else
      {
        DxfVertex3D handledObject = (DxfVertex3D) class301.HandledObject;
        if (class301.IsSplineControlPoint)
          spline.ControlPoints.Add(handledObject);
        else
          spline.ApproximationPoints.Add(handledObject);
      }
    }

    private void method_4(
      Class374 modelBuilder,
      DxfPolyline3DBase polyline,
      Class285 entityBuilder)
    {
      modelBuilder.Messages.Add(new DxfMessage(DxfStatus.InvalidPolylineVertexEntityType, Severity.Error, "EntityType", entityBuilder.Entity == null ? (object) "null" : (object) entityBuilder.Entity.GetType().Name)
      {
        Parameters = {
          {
            "ExpectedEntityType",
            (object) typeof (DxfVertex3D).Name
          },
          {
            "target",
            (object) polyline
          },
          {
            "VertexObject",
            (object) entityBuilder.Entity
          }
        }
      });
      DxfBlock objectSoftReference = polyline.OwnerObjectSoftReference as DxfBlock;
      this.IsValid = false;
      if (objectSoftReference == null)
        return;
      ((Class318) modelBuilder.method_5(objectSoftReference.Handle)).method_1((DxfEntity) polyline);
    }
  }
}
