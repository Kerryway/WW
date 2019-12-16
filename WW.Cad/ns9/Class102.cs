// Decompiled with JetBrains decompiler
// Type: ns9.Class102
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns9
{
  internal class Class102 : Class81
  {
    public const string string_0 = "vertex";
    private Class96 class96_0;
    private Class105 class105_0;
    private Class102.Enum48 enum48_0;

    public override string imethod_2(int version)
    {
      return "vertex";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      int index1 = reader.imethod_7();
      if (index1 < 0)
      {
        this.class96_0 = (Class96) null;
      }
      else
      {
        this.class96_0 = (Class96) reader[index1];
        if (this.class96_0 == null)
          reader.imethod_0(index1, (Delegate10) (entity => this.class96_0 = (Class96) entity));
      }
      this.enum48_0 = reader.FileFormatVersion < Class250.int_67 ? Class102.Enum48.const_2 : (Class102.Enum48) reader.imethod_5();
      int index2 = reader.imethod_7();
      if (index2 < 0)
      {
        this.class105_0 = (Class105) null;
      }
      else
      {
        this.class105_0 = (Class105) reader[index2];
        if (this.class105_0 != null)
          return;
        reader.imethod_0(index2, (Delegate10) (entity => this.class105_0 = (Class105) entity));
      }
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_6((Class80) this.class96_0);
      if (writer.FileFormatVersion >= Class250.int_67)
        writer.imethod_4((int) this.enum48_0);
      writer.imethod_6((Class80) this.class105_0);
    }

    public override void vmethod_3(Class608 wires)
    {
      int num = wires.method_2(this.class105_0);
      wires.method_5(num, num);
    }

    public Class96 Edge
    {
      get
      {
        return this.class96_0;
      }
    }

    public Class105 Point
    {
      get
      {
        return this.class105_0;
      }
    }

    public Class102.Enum48 VertexType
    {
      get
      {
        return this.enum48_0;
      }
    }

    public enum Enum48
    {
      const_0,
      const_1,
      const_2,
    }
  }
}
