// Decompiled with JetBrains decompiler
// Type: ns9.Class106
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns9
{
  internal class Class106 : Class81
  {
    public const string string_0 = "wire";
    private Class106 class106_0;
    private Class107 class107_0;
    private Class80 class80_1;
    private Class104 class104_0;
    private Class686.Class691 class691_0;

    public override string imethod_2(int version)
    {
      return "wire";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      int index1 = reader.imethod_7();
      if (index1 < 0)
        this.class106_0 = (Class106) null;
      else
        reader.imethod_0(index1, (Delegate10) (entity => this.class106_0 = (Class106) entity));
      int index2 = reader.imethod_7();
      if (index2 < 0)
        this.class107_0 = (Class107) null;
      else
        reader.imethod_0(index2, (Delegate10) (entity => this.class107_0 = (Class107) entity));
      int index3 = reader.imethod_7();
      if (index3 < 0)
      {
        this.class80_1 = (Class80) null;
      }
      else
      {
        this.class80_1 = reader[index3];
        if (this.class80_1 == null)
          reader.imethod_0(index3, (Delegate10) (entity => this.class80_1 = entity));
      }
      if (reader.FileFormatVersion >= Class250.int_20)
      {
        reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class104_0 = (Class104) entity));
        this.class691_0 = new Class686.Class691(reader);
      }
      else
      {
        this.class104_0 = (Class104) null;
        this.class691_0 = new Class686.Class691(false);
      }
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_6((Class80) this.class106_0);
      writer.imethod_6((Class80) this.class107_0);
      writer.imethod_6(this.class80_1);
      if (writer.FileFormatVersion < Class250.int_20)
        return;
      writer.imethod_6((Class80) this.class104_0);
      writer.imethod_12((Interface39) this.class691_0);
    }

    public override Class80 Next
    {
      get
      {
        return (Class80) this.NextWire;
      }
    }

    public override void vmethod_3(Class608 wires)
    {
      Class80.smethod_2((Class80) this.FirstCoedge, wires);
    }

    public Class106 NextWire
    {
      get
      {
        return this.class106_0;
      }
    }

    public Class107 FirstCoedge
    {
      get
      {
        return this.class107_0;
      }
    }

    public Class80 BodyOrShell
    {
      get
      {
        return this.class80_1;
      }
    }

    public Class104 Subshell
    {
      get
      {
        return this.class104_0;
      }
    }

    public bool ContainmentOuter
    {
      get
      {
        return this.class691_0.Value;
      }
    }
  }
}
