// Decompiled with JetBrains decompiler
// Type: ns9.Class95
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using System.Collections.Generic;

namespace ns9
{
  internal class Class95 : Class81
  {
    public const string string_0 = "loop";
    private Class95 class95_0;
    private Class107 class107_0;
    private Class101 class101_0;

    public override string imethod_2(int version)
    {
      return "loop";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      int index1 = reader.imethod_7();
      if (index1 < 0)
        this.class95_0 = (Class95) null;
      else
        reader.imethod_0(index1, (Delegate10) (entity => this.class95_0 = (Class95) entity));
      reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class107_0 = (Class107) entity));
      int index2 = reader.imethod_7();
      if (index2 < 0)
      {
        this.class101_0 = (Class101) null;
      }
      else
      {
        this.class101_0 = (Class101) reader[index2];
        if (this.class101_0 != null)
          return;
        reader.imethod_0(index2, (Delegate10) (entity => this.class101_0 = (Class101) entity));
      }
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_6((Class80) this.class95_0);
      writer.imethod_6((Class80) this.class107_0);
      writer.imethod_6((Class80) this.class101_0);
    }

    public override Class80 Next
    {
      get
      {
        return (Class80) this.NextLoop;
      }
    }

    public override void vmethod_3(Class608 wires)
    {
      Class80.smethod_2((Class80) this.FirstCoedge, wires);
    }

    public Class95 NextLoop
    {
      get
      {
        return this.class95_0;
      }
    }

    public Class107 FirstCoedge
    {
      get
      {
        return this.class107_0;
      }
    }

    public Class101 Face
    {
      get
      {
        return this.class101_0;
      }
    }

    public IList<Class107> Coedges
    {
      get
      {
        return Class80.smethod_0<Class107>(this.FirstCoedge);
      }
    }
  }
}
