// Decompiled with JetBrains decompiler
// Type: ns9.Class93
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using System.Collections.Generic;

namespace ns9
{
  internal class Class93 : Class81
  {
    public const string string_0 = "shell";
    private Class93 class93_0;
    private Class104 class104_0;
    private Class101 class101_0;
    private Class106 class106_0;
    private Class100 class100_0;

    public override string imethod_2(int version)
    {
      return "shell";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      int index1 = reader.imethod_7();
      if (index1 < 0)
        this.class93_0 = (Class93) null;
      else
        reader.imethod_0(index1, (Delegate10) (entity => this.class93_0 = (Class93) entity));
      reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class104_0 = (Class104) entity));
      reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class101_0 = (Class101) entity));
      if (reader.FileFormatVersion >= Class250.int_20)
        reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class106_0 = (Class106) entity));
      else
        this.class106_0 = (Class106) null;
      int index2 = reader.imethod_7();
      if (index2 < 0)
      {
        this.class100_0 = (Class100) null;
      }
      else
      {
        this.class100_0 = (Class100) reader[index2];
        if (this.class100_0 != null)
          return;
        reader.imethod_0(index2, (Delegate10) (entity => this.class100_0 = (Class100) entity));
      }
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_6((Class80) this.class93_0);
      writer.imethod_6((Class80) this.class104_0);
      writer.imethod_6((Class80) this.class101_0);
      if (writer.FileFormatVersion >= Class250.int_20)
        writer.imethod_6((Class80) this.class106_0);
      writer.imethod_6((Class80) this.class100_0);
    }

    public override void vmethod_3(Class608 wires)
    {
      Class80.smethod_2((Class80) this.FirstFace, wires);
      Class80.smethod_2((Class80) this.FirstSubshell, wires);
      Class80.smethod_2((Class80) this.FirstWire, wires);
    }

    public override Class80 Next
    {
      get
      {
        return (Class80) this.NextShell;
      }
    }

    public Class93 NextShell
    {
      get
      {
        return this.class93_0;
      }
    }

    public Class104 FirstSubshell
    {
      get
      {
        return this.class104_0;
      }
    }

    public Class101 FirstFace
    {
      get
      {
        return this.class101_0;
      }
    }

    public Class106 FirstWire
    {
      get
      {
        return this.class106_0;
      }
    }

    public Class100 Lump
    {
      get
      {
        return this.class100_0;
      }
    }

    public IList<Class104> TopLevelSubshells
    {
      get
      {
        return Class80.smethod_0<Class104>(this.FirstSubshell);
      }
    }

    public IList<Class101> Faces
    {
      get
      {
        return Class80.smethod_0<Class101>(this.FirstFace);
      }
    }

    public IList<Class106> Wires
    {
      get
      {
        return Class80.smethod_0<Class106>(this.FirstWire);
      }
    }
  }
}
