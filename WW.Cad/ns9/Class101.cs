// Decompiled with JetBrains decompiler
// Type: ns9.Class101
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using System.Collections.Generic;

namespace ns9
{
  internal class Class101 : Class81
  {
    public const string string_0 = "face";
    private Class101 class101_0;
    private Class95 class95_0;
    private Class93 class93_0;
    private Class104 class104_0;
    private Class81 class81_0;
    private Class686.Class690 class690_0;
    private Class686.Class696 class696_0;
    private Class686.Class691 class691_0;

    public override string imethod_2(int version)
    {
      return "face";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      int index1 = reader.imethod_7();
      if (index1 < 0)
        this.class101_0 = (Class101) null;
      else
        reader.imethod_0(index1, (Delegate10) (entity => this.class101_0 = (Class101) entity));
      reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class95_0 = (Class95) entity));
      int index2 = reader.imethod_7();
      if (index2 < 0)
      {
        this.class93_0 = (Class93) null;
      }
      else
      {
        this.class93_0 = (Class93) reader[index2];
        if (this.class93_0 == null)
          reader.imethod_0(index2, (Delegate10) (entity => this.class93_0 = (Class93) entity));
      }
      int index3 = reader.imethod_7();
      if (index3 < 0)
      {
        this.class104_0 = (Class104) null;
      }
      else
      {
        this.class104_0 = (Class104) reader[index3];
        if (this.class104_0 == null)
          reader.imethod_0(index3, (Delegate10) (entity => this.class104_0 = (Class104) entity));
      }
      int index4 = reader.imethod_7();
      if (index4 < 0)
      {
        this.class81_0 = (Class81) null;
      }
      else
      {
        this.class81_0 = (Class81) reader[index4];
        if (this.class81_0 == null)
          reader.imethod_0(index4, (Delegate10) (entity => this.class81_0 = (Class81) entity));
      }
      this.class690_0 = new Class686.Class690(reader);
      if (reader.FileFormatVersion >= Class250.int_12)
      {
        this.class696_0 = new Class686.Class696(reader);
        if (this.class696_0.Value)
          this.class691_0 = new Class686.Class691(reader);
        else
          this.class691_0 = new Class686.Class691(false);
      }
      else
      {
        this.class696_0 = new Class686.Class696(false);
        this.class691_0 = new Class686.Class691(false);
      }
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_6((Class80) this.class101_0);
      writer.imethod_6((Class80) this.class95_0);
      writer.imethod_6((Class80) this.class93_0);
      writer.imethod_6((Class80) this.class104_0);
      writer.imethod_6((Class80) this.class81_0);
      writer.imethod_12((Interface39) this.class690_0);
      if (writer.FileFormatVersion < Class250.int_12)
        return;
      writer.imethod_12((Interface39) this.class696_0);
      if (!this.class696_0.Value)
        return;
      writer.imethod_12((Interface39) this.class691_0);
    }

    public override Class80 Next
    {
      get
      {
        return (Class80) this.NextFace;
      }
    }

    public override void vmethod_3(Class608 wires)
    {
      if (this.class81_0 != null && this.class81_0 is Class82)
        ((Class82) this.class81_0).SurfacePrimitive.vmethod_2(this.FirstLoop, wires);
      else
        Class80.smethod_2((Class80) this.FirstLoop, wires);
    }

    public Class101 NextFace
    {
      get
      {
        return this.class101_0;
      }
    }

    public Class95 FirstLoop
    {
      get
      {
        return this.class95_0;
      }
    }

    public Class93 Shell
    {
      get
      {
        return this.class93_0;
      }
    }

    public Class104 Subshell
    {
      get
      {
        return this.class104_0;
      }
    }

    public Class81 Surface
    {
      get
      {
        return this.class81_0;
      }
    }

    public bool FaceNormalReversed
    {
      get
      {
        return this.class690_0.Value;
      }
    }

    public bool DoubleSided
    {
      get
      {
        return this.class696_0.Value;
      }
    }

    public bool DoubleSidedIn
    {
      get
      {
        return this.class691_0.Value;
      }
    }

    public IList<Class95> Loops
    {
      get
      {
        return Class80.smethod_0<Class95>(this.FirstLoop);
      }
    }
  }
}
