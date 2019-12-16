// Decompiled with JetBrains decompiler
// Type: ns9.Class94
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns11;
using ns7;
using System.Collections.Generic;

namespace ns9
{
  internal class Class94 : Class81
  {
    private List<bool> list_1 = new List<bool>();
    private List<Class561> list_0;
    private bool bool_1;
    private readonly string string_0;
    private readonly Class80 class80_1;

    public Class94(string entityType, Class80 basicEntity)
    {
      this.string_0 = entityType;
      this.class80_1 = basicEntity;
      basicEntity.method_1();
    }

    public override string imethod_2(int version)
    {
      return this.string_0;
    }

    internal override void vmethod_0(Interface8 reader)
    {
      this.class80_1.vmethod_0(reader);
      this.list_0 = new List<Class561>();
      this.bool_1 = reader.imethod_15(ref this.list_0);
      foreach (Class561 class561 in this.list_0)
      {
        if (class561.enum41_0 == Class951.Enum41.const_12)
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          Class94.Class563 class563 = new Class94.Class563();
          // ISSUE: reference to a compiler-generated field
          class563.class94_0 = this;
          // ISSUE: reference to a compiler-generated field
          class563.int_0 = ((Class562<int>) class561).gparam_0;
          // ISSUE: reference to a compiler-generated field
          if (class563.int_0 != -1)
          {
            // ISSUE: reference to a compiler-generated field
            Class80 class80 = reader[class563.int_0];
            if (class80 == null)
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated method
              reader.imethod_0(class563.int_0, new Delegate10(class563.method_0));
              this.list_1.Add(false);
            }
            else
            {
              ((Class562<int>) class561).gparam_0 = class80.Index;
              this.list_1.Add(true);
            }
          }
          else
            this.list_1.Add(true);
        }
      }
    }

    internal override void vmethod_1(Interface9 writer)
    {
      this.class80_1.vmethod_1(writer);
      int index = 0;
      foreach (Class561 class561 in this.list_0)
      {
        if (class561.enum41_0 == Class951.Enum41.const_12)
        {
          if (!this.list_1[index])
            ;
          ++index;
        }
      }
      writer.imethod_19(this.list_0, this.bool_1);
    }

    public override int Index
    {
      get
      {
        return this.class80_1.Index;
      }
      set
      {
        this.class80_1.Index = value;
      }
    }

    public override Class113 Attribute
    {
      get
      {
        return this.class80_1.Attribute;
      }
      set
      {
        this.class80_1.Attribute = value;
      }
    }

    public override int SomeValue
    {
      get
      {
        return this.class80_1.SomeValue;
      }
    }

    public string EntityType
    {
      get
      {
        return this.string_0;
      }
    }

    public Class80 BasicEntity
    {
      get
      {
        return this.class80_1;
      }
    }
  }
}
