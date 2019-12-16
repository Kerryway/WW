// Decompiled with JetBrains decompiler
// Type: ns9.Class107
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;
using System;
using System.Collections.Generic;
using WW.Math;

namespace ns9
{
  internal class Class107 : Class81
  {
    public const string string_0 = "coedge";
    private Class107 class107_0;
    private Class107 class107_1;
    private Class107 class107_2;
    private Class96 class96_0;
    private Class686.Class690 class690_0;
    private Class80 class80_1;
    private Class81 class81_0;
    private int int_2;

    public Class107 NextCoedge
    {
      get
      {
        return this.class107_0;
      }
    }

    public Class107 PreviousCoedge
    {
      get
      {
        return this.class107_1;
      }
    }

    public Class107 PartnerCoedge
    {
      get
      {
        return this.class107_2;
      }
    }

    public Class96 Edge
    {
      get
      {
        return this.class96_0;
      }
    }

    public bool DirectionReversed
    {
      get
      {
        return this.class690_0.Value;
      }
    }

    public Class80 LoopOrWire
    {
      get
      {
        return this.class80_1;
      }
    }

    public Class81 Pcurve
    {
      get
      {
        return this.class81_0;
      }
    }

    public Class102 StartVertex
    {
      get
      {
        if (!this.class690_0.Value)
          return this.class96_0.StartVertex;
        return this.class96_0.EndVertex;
      }
    }

    public Class102 EndVertex
    {
      get
      {
        if (!this.class690_0.Value)
          return this.class96_0.EndVertex;
        return this.class96_0.StartVertex;
      }
    }

    public Class105 StartPoint
    {
      get
      {
        return this.StartVertex.Point;
      }
    }

    public Class105 EndPoint
    {
      get
      {
        return this.EndVertex.Point;
      }
    }

    public Point3D StartLocation
    {
      get
      {
        return this.StartPoint.Location;
      }
    }

    public Point3D EndLocation
    {
      get
      {
        return this.EndPoint.Location;
      }
    }

    public override string imethod_2(int version)
    {
      return "coedge";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      int index1 = reader.imethod_7();
      if (index1 < 0)
        this.class107_0 = (Class107) null;
      else
        reader.imethod_0(index1, (Delegate10) (entity => this.class107_0 = (Class107) entity));
      int index2 = reader.imethod_7();
      if (index2 < 0)
      {
        this.class107_1 = (Class107) null;
      }
      else
      {
        this.class107_1 = (Class107) reader[index2];
        if (this.class107_1 == null)
          reader.imethod_0(index2, (Delegate10) (entity => this.class107_1 = (Class107) entity));
      }
      int index3 = reader.imethod_7();
      if (index3 < 0)
      {
        this.class107_2 = (Class107) null;
      }
      else
      {
        this.class107_2 = (Class107) reader[index3];
        if (this.class107_2 == null)
          reader.imethod_0(index3, (Delegate10) (entity => this.class107_2 = (Class107) entity));
      }
      int index4 = reader.imethod_7();
      if (index4 < 0)
      {
        this.class96_0 = (Class96) null;
      }
      else
      {
        this.class96_0 = (Class96) reader[index4];
        if (this.class96_0 == null)
          reader.imethod_0(index4, (Delegate10) (entity => this.class96_0 = (Class96) entity));
      }
      this.class690_0 = reader.FileFormatVersion >= Class250.int_31 ? new Class686.Class690(reader) : new Class686.Class690(reader.imethod_5() > 0);
      int index5 = reader.imethod_7();
      if (index5 < 0)
      {
        this.class80_1 = (Class80) null;
      }
      else
      {
        this.class80_1 = reader[index5];
        if (this.class80_1 == null)
          reader.imethod_0(index5, (Delegate10) (entity => this.class80_1 = entity));
      }
      this.int_2 = reader.FileFormatVersion < Class250.int_72 ? 0 : reader.imethod_5();
      int index6 = reader.imethod_7();
      if (index6 < 0)
      {
        this.class81_0 = (Class81) null;
      }
      else
      {
        this.class81_0 = (Class81) reader[index6];
        if (this.class81_0 != null)
          return;
        reader.imethod_0(index6, (Delegate10) (entity => this.class81_0 = (Class81) entity));
      }
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_6((Class80) this.class107_0);
      writer.imethod_6((Class80) this.class107_1);
      writer.imethod_6((Class80) this.class107_2);
      writer.imethod_6((Class80) this.class96_0);
      if (writer.FileFormatVersion < Class250.int_31)
        writer.imethod_4(this.class690_0.Value ? 1 : 0);
      else
        writer.imethod_12((Interface39) this.class690_0);
      writer.imethod_6(this.class80_1);
      if (writer.FileFormatVersion >= Class250.int_72)
        writer.imethod_4(this.int_2);
      writer.imethod_6((Class80) this.class81_0);
    }

    public override Class80 Next
    {
      get
      {
        return (Class80) this.NextCoedge;
      }
    }

    public override void vmethod_3(Class608 wires)
    {
      try
      {
        if (this.class96_0.Curve != null)
        {
          Class917 approximation = new Class917();
          ((Class88) this.class96_0.Curve).CurvePrimitive.imethod_3((Class95) this.class80_1, (Class88) this.class96_0.Curve, this, approximation, wires.Accuracy);
          wires.method_9((ICollection<Point3D>) approximation.Points, false);
          return;
        }
      }
      catch (InvalidCastException ex)
      {
      }
      this.class96_0.vmethod_3(wires);
    }
  }
}
