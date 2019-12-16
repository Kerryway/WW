// Decompiled with JetBrains decompiler
// Type: ns3.Class297
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Model.Entities;

namespace ns3
{
  internal class Class297 : Class285
  {
    private ulong ulong_6;
    private ulong ulong_7;
    private List<ulong> list_1;
    private ulong ulong_8;

    public Class297(DxfPolylineBase polyline)
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
      DxfPolyline2DBase entity = (DxfPolyline2DBase) this.Entity;
      DxfPolyline2DSpline spline = entity as DxfPolyline2DSpline;
      if (spline != null)
      {
        if (this.ulong_6 != 0UL)
        {
          for (Class285 class285 = modelBuilder.method_6(this.ulong_6); class285 != null; class285 = modelBuilder.method_7(class285))
          {
            Class297.smethod_1(spline, class285);
            if ((long) class285.HandledObject.Handle == (long) this.ulong_7)
              break;
          }
        }
        else if (this.list_1 != null)
        {
          for (int index = 0; index < this.list_1.Count; ++index)
          {
            ulong handle = this.list_1[index];
            Class297.smethod_1(spline, modelBuilder.method_6(handle));
          }
        }
      }
      else
      {
        DxfPolyline2D polyline = entity as DxfPolyline2D;
        if (polyline != null)
        {
          if (this.ulong_6 != 0UL)
          {
            for (Class285 class285 = modelBuilder.method_6(this.ulong_6); class285 != null; class285 = modelBuilder.method_7(class285))
            {
              Class297.smethod_0(modelBuilder, polyline, class285);
              if ((long) class285.HandledObject.Handle == (long) this.ulong_7)
                break;
            }
          }
          else if (this.list_1 != null)
          {
            for (int index = 0; index < this.list_1.Count; ++index)
            {
              ulong handle = this.list_1[index];
              Class297.smethod_0(modelBuilder, polyline, modelBuilder.method_6(handle));
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

    private static void smethod_0(
      Class374 modelBuilder,
      DxfPolyline2D polyline,
      Class285 vertexBuilder)
    {
      DxfVertex2D handledObject = vertexBuilder.HandledObject as DxfVertex2D;
      if (handledObject != null)
      {
        polyline.Vertices.Add(handledObject);
      }
      else
      {
        if (vertexBuilder.HandledObject == null)
          return;
        modelBuilder.Messages.Add(new DxfMessage(DxfStatus.WrongType, Severity.Warning)
        {
          Parameters = {
            {
              "Class",
              (object) "AcDb2dPolyline"
            },
            {
              "Handle",
              (object) polyline.HandleString
            },
            {
              "Bad vertex handle",
              (object) vertexBuilder.HandledObject.HandleString
            }
          }
        });
      }
    }

    private static void smethod_1(DxfPolyline2DSpline spline, Class285 vertexBuilder)
    {
      DxfVertex2D handledObject = (DxfVertex2D) vertexBuilder.HandledObject;
      if (handledObject.IsSplineControlPoint)
        spline.ControlPoints.Add(handledObject);
      else
        spline.ApproximationPoints.Add(handledObject);
    }
  }
}
