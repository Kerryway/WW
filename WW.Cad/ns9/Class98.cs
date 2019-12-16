// Decompiled with JetBrains decompiler
// Type: ns9.Class98
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using System.Collections.Generic;
using WW.Math;

namespace ns9
{
  internal class Class98 : Class81
  {
    public const string string_0 = "body";
    private Class100 class100_0;
    private Class93 class93_0;
    private Class106 class106_0;
    private Class185 class185_0;

    public Class100 FirstLump
    {
      get
      {
        return this.class100_0 ?? new Class100(this, this.class93_0);
      }
    }

    public Class93 FirstShell
    {
      get
      {
        return this.class93_0;
      }
    }

    public Class106 FirstWire
    {
      get
      {
        return this.class106_0;
      }
    }

    public Class185 Transform
    {
      get
      {
        return this.class185_0;
      }
      set
      {
        this.class185_0 = value;
      }
    }

    public IList<Class100> Lumps
    {
      get
      {
        return Class80.smethod_0<Class100>(this.FirstLump);
      }
    }

    public override string imethod_2(int version)
    {
      return "body";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      if (reader.FileFormatVersion < Class250.int_2)
      {
        int index = reader.imethod_7();
        if (index > 0)
        {
          reader.imethod_0(index, (Delegate10) (entity =>
          {
            this.class93_0 = (Class93) entity;
            this.class100_0 = new Class100(this, this.class93_0);
          }));
        }
        else
        {
          this.class93_0 = (Class93) null;
          this.class100_0 = (Class100) null;
        }
      }
      else
        reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class100_0 = (Class100) entity));
      reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class106_0 = (Class106) entity));
      reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class185_0 = (Class185) entity));
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      if (writer.FileFormatVersion < Class250.int_2)
        writer.imethod_6((Class80) this.class93_0);
      else
        writer.imethod_6((Class80) this.class100_0);
      writer.imethod_6((Class80) this.class106_0);
      writer.imethod_6((Class80) this.class185_0);
    }

    public override void vmethod_2(Class795 satFile)
    {
      satFile.method_7(this);
    }

    public override void vmethod_3(Class608 wires)
    {
      try
      {
        wires.method_3(this.class185_0 != null ? this.class185_0.Transformation : Matrix4D.Identity);
        Class80.smethod_2((Class80) this.class100_0, wires);
        Class80.smethod_2((Class80) this.FirstShell, wires);
        Class80.smethod_2((Class80) this.FirstWire, wires);
      }
      finally
      {
        wires.method_4();
      }
    }
  }
}
