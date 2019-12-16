// Decompiled with JetBrains decompiler
// Type: ns9.Class100
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using System.Collections.Generic;

namespace ns9
{
  internal class Class100 : Class81
  {
    public const string string_0 = "lump";
    private Class100 class100_0;
    private Class93 class93_0;
    private Class98 class98_0;

    public Class100()
    {
    }

    public Class100(Class98 body, Class93 shell)
    {
      this.class98_0 = body;
      this.class93_0 = shell;
    }

    public override string imethod_2(int version)
    {
      return "lump";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      int index1 = reader.imethod_7();
      if (index1 < 0)
        this.class100_0 = (Class100) null;
      else
        reader.imethod_0(index1, (Delegate10) (entity => this.class100_0 = (Class100) entity));
      reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class93_0 = (Class93) entity));
      int index2 = reader.imethod_7();
      if (index2 < 0)
      {
        this.class98_0 = (Class98) null;
      }
      else
      {
        this.class98_0 = (Class98) reader[index2];
        if (this.class98_0 != null)
          return;
        reader.imethod_0(index2, (Delegate10) (entity => this.class98_0 = (Class98) entity));
      }
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_6((Class80) this.class100_0);
      writer.imethod_6((Class80) this.class93_0);
      writer.imethod_6((Class80) this.class98_0);
    }

    public override Class80 Next
    {
      get
      {
        return (Class80) this.NextLump;
      }
    }

    public override void vmethod_3(Class608 wires)
    {
      Class80.smethod_2((Class80) this.FirstShell, wires);
    }

    public Class100 NextLump
    {
      get
      {
        return this.class100_0;
      }
    }

    public Class93 FirstShell
    {
      get
      {
        return this.class93_0;
      }
    }

    public Class98 Body
    {
      get
      {
        return this.class98_0;
      }
    }

    public IList<Class93> Shells
    {
      get
      {
        return Class80.smethod_0<Class93>(this.FirstShell);
      }
    }
  }
}
