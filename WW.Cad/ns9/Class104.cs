// Decompiled with JetBrains decompiler
// Type: ns9.Class104
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns9
{
  internal class Class104 : Class81
  {
    public const string string_0 = "subshell";
    private Class104 class104_0;
    private Class104 class104_1;
    private Class104 class104_2;
    private Class101 class101_0;
    private Class106 class106_0;

    public override string imethod_2(int version)
    {
      return "subshell";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      int index1 = reader.imethod_7();
      if (index1 < 0)
      {
        this.class104_0 = (Class104) null;
      }
      else
      {
        this.class104_0 = (Class104) reader[index1];
        if (this.class104_0 == null)
          reader.imethod_0(index1, (Delegate10) (entity => this.class104_0 = (Class104) entity));
      }
      int index2 = reader.imethod_7();
      if (index2 < 0)
      {
        this.class104_1 = (Class104) null;
      }
      else
      {
        this.class104_1 = (Class104) reader[index2];
        if (this.class104_1 == null)
          reader.imethod_0(index2, (Delegate10) (entity => this.class104_1 = (Class104) entity));
      }
      int index3 = reader.imethod_7();
      if (index3 < 0)
      {
        this.class104_2 = (Class104) null;
      }
      else
      {
        this.class104_2 = (Class104) reader[index3];
        if (this.class104_2 == null)
          reader.imethod_0(index3, (Delegate10) (entity => this.class104_2 = (Class104) entity));
      }
      int index4 = reader.imethod_7();
      if (index4 < 0)
      {
        this.class101_0 = (Class101) null;
      }
      else
      {
        this.class101_0 = (Class101) reader[index4];
        if (this.class101_0 == null)
          reader.imethod_0(index4, (Delegate10) (entity => this.class101_0 = (Class101) entity));
      }
      if (reader.FileFormatVersion >= Class250.int_20)
        reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class106_0 = (Class106) entity));
      else
        this.class106_0 = (Class106) null;
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_6((Class80) this.class104_0);
      writer.imethod_6((Class80) this.class104_1);
      writer.imethod_6((Class80) this.class104_2);
      writer.imethod_6((Class80) this.class101_0);
      if (writer.FileFormatVersion < Class250.int_20)
        return;
      writer.imethod_6((Class80) this.class106_0);
    }

    public override Class80 Next
    {
      get
      {
        return (Class80) this.NextSubshell;
      }
    }

    public override void vmethod_3(Class608 wires)
    {
      Class80.smethod_2((Class80) this.ChildSubshell, wires);
      Class80.smethod_2((Class80) this.FirstFace, wires);
      Class80.smethod_2((Class80) this.FirstWire, wires);
    }

    public Class104 ParentSubshell
    {
      get
      {
        return this.class104_0;
      }
    }

    public Class104 NextSubshell
    {
      get
      {
        return this.class104_1;
      }
    }

    public Class104 ChildSubshell
    {
      get
      {
        return this.class104_2;
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
  }
}
