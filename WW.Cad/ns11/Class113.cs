// Decompiled with JetBrains decompiler
// Type: ns11.Class113
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using ns9;

namespace ns11
{
  internal class Class113 : Class80
  {
    public const string string_0 = "attrib";
    private Class113 class113_1;
    private Class113 class113_2;
    private Class80 class80_0;

    public Class80 OwnEntity
    {
      get
      {
        return this.class80_0;
      }
      set
      {
        this.class80_0 = value;
      }
    }

    public Class113 NextAttribute
    {
      get
      {
        return this.class113_1;
      }
      set
      {
        this.class113_1 = value;
      }
    }

    public Class113 PrevAttribute
    {
      get
      {
        return this.class113_2;
      }
      set
      {
        this.class113_2 = value;
      }
    }

    public override string imethod_2(int version)
    {
      return "attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      int index1 = reader.imethod_7();
      reader.imethod_0(index1, (Delegate10) (entity => this.class113_1 = entity as Class113));
      int index2 = reader.imethod_7();
      reader.imethod_0(index2, (Delegate10) (entity => this.class113_2 = entity as Class113));
      int index3 = reader.imethod_7();
      reader.imethod_0(index3, (Delegate10) (entity => this.class80_0 = entity));
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_6((Class80) this.class113_1);
      writer.imethod_6((Class80) this.class113_2);
      writer.imethod_6(this.class80_0);
    }

    public override void imethod_0(Interface8 reader)
    {
      this.vmethod_0(reader);
      bool flag = false;
      while (!flag)
        flag = reader.imethod_16(true);
    }
  }
}
