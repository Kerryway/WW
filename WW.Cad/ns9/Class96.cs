// Decompiled with JetBrains decompiler
// Type: ns9.Class96
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns9
{
  internal class Class96 : Class81
  {
    public const string string_0 = "edge";
    private Class102 class102_0;
    private double double_0;
    private Class102 class102_1;
    private double double_1;
    private Class107 class107_0;
    private Class81 class81_0;
    private Class686.Class690 class690_0;
    private string string_1;

    public override string imethod_2(int version)
    {
      return "edge";
    }

    public Class102 StartVertex
    {
      get
      {
        return this.class102_0;
      }
    }

    public double StartParameter
    {
      get
      {
        return this.double_0;
      }
    }

    public Class102 EndVertex
    {
      get
      {
        return this.class102_1;
      }
    }

    public double EndParameter
    {
      get
      {
        return this.double_1;
      }
    }

    public Class107 Coedge
    {
      get
      {
        return this.class107_0;
      }
    }

    public Class81 Curve
    {
      get
      {
        return this.class81_0;
      }
    }

    public bool Reversed
    {
      get
      {
        return this.class690_0.Value;
      }
    }

    public string Convexity
    {
      get
      {
        return this.string_1;
      }
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class102_0 = (Class102) entity));
      this.double_0 = reader.FileFormatVersion < Class250.int_1 || reader.FileFormatVersion >= Class250.int_47 ? reader.imethod_8() : 0.0;
      reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class102_1 = (Class102) entity));
      this.double_1 = reader.FileFormatVersion < Class250.int_1 || reader.FileFormatVersion >= Class250.int_47 ? reader.imethod_8() : 1.0;
      int index1 = reader.imethod_7();
      if (index1 < 0)
      {
        this.class107_0 = (Class107) null;
      }
      else
      {
        this.class107_0 = (Class107) reader[index1];
        if (this.class107_0 == null)
          reader.imethod_0(index1, (Delegate10) (entity => this.class107_0 = (Class107) entity));
      }
      int index2 = reader.imethod_7();
      if (index2 < 0)
      {
        this.class81_0 = (Class81) null;
      }
      else
      {
        this.class81_0 = (Class81) reader[index2];
        if (this.class81_0 == null)
          reader.imethod_0(index2, (Delegate10) (entity => this.class81_0 = (Class81) entity));
      }
      this.class690_0 = new Class686.Class690(reader);
      if (reader.FileFormatVersion < Class250.int_47)
        return;
      this.string_1 = reader.ReadString();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_6((Class80) this.class102_0);
      if (writer.FileFormatVersion < Class250.int_1 || writer.FileFormatVersion >= Class250.int_47)
        writer.imethod_7(this.double_0);
      writer.imethod_6((Class80) this.class102_1);
      if (writer.FileFormatVersion < Class250.int_1 || writer.FileFormatVersion >= Class250.int_47)
        writer.imethod_7(this.double_1);
      writer.imethod_6((Class80) this.class107_0);
      writer.imethod_6((Class80) this.class81_0);
      writer.imethod_12((Interface39) this.class690_0);
      if (writer.FileFormatVersion < Class250.int_47)
        return;
      writer.WriteString(this.string_1);
    }

    public override void vmethod_3(Class608 wires)
    {
      wires.method_6(this.StartVertex.Point, this.EndVertex.Point);
    }
  }
}
