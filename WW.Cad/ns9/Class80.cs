// Decompiled with JetBrains decompiler
// Type: ns9.Class80
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns11;
using ns7;
using System.Collections.Generic;

namespace ns9
{
  internal class Class80 : Interface3, Interface4
  {
    private int int_0 = -1;
    private Class113 class113_0;
    private int int_1;
    private bool bool_0;

    public virtual string imethod_2(int version)
    {
      return "";
    }

    public virtual void imethod_0(Interface8 reader)
    {
      this.vmethod_0(reader);
      reader.imethod_16(false);
    }

    public virtual void imethod_1(Interface9 writer)
    {
      this.vmethod_1(writer);
      writer.imethod_14();
    }

    internal virtual void vmethod_0(Interface8 reader)
    {
      int index = reader.imethod_7();
      if (index < 0)
      {
        this.class113_0 = (Class113) null;
      }
      else
      {
        this.class113_0 = reader[index] as Class113;
        if (this.class113_0 == null)
          reader.imethod_0(index, (Delegate10) (entity => this.class113_0 = entity as Class113));
      }
      if (reader.FileFormatVersion >= Class250.int_66)
        this.int_1 = reader.imethod_5();
      else
        this.int_1 = -1;
    }

    internal virtual void vmethod_1(Interface9 writer)
    {
      writer.imethod_6((Class80) this.class113_0);
      if (writer.FileFormatVersion < Class250.int_66)
        return;
      writer.imethod_4(this.int_1);
    }

    public bool method_0()
    {
      if (this.Attribute == null)
        return true;
      if (this.Attribute.NextAttribute != null)
      {
        Class113 class113_1 = this.Attribute;
        while (class113_1.OwnEntity == this)
        {
          Class113 class113_2 = class113_1;
          class113_1 = class113_1.NextAttribute;
          if (class113_1 != null && class113_1.PrevAttribute != class113_2)
            return false;
          if (class113_1 == null)
            goto label_9;
        }
        return false;
      }
label_9:
      return this.Attribute.PrevAttribute == null;
    }

    public virtual int Index
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public virtual Class113 Attribute
    {
      get
      {
        return this.class113_0;
      }
      set
      {
        this.class113_0 = value;
      }
    }

    public virtual int SomeValue
    {
      get
      {
        return this.int_1;
      }
    }

    public virtual Class80 Next
    {
      get
      {
        return (Class80) null;
      }
    }

    public virtual void vmethod_2(Class795 satFile)
    {
    }

    public virtual void vmethod_3(Class608 wires)
    {
    }

    internal void method_1()
    {
      this.bool_0 = true;
    }

    internal bool UsedAsBase
    {
      get
      {
        return this.bool_0;
      }
    }

    public static IList<T> smethod_0<T>(T startEntity) where T : Class80
    {
      List<T> objList = new List<T>();
      T obj = startEntity;
      while ((object) obj != null)
      {
        objList.Add(obj);
        obj = (T) obj.Next;
        if ((object) obj == (object) startEntity)
          break;
      }
      return (IList<T>) objList;
    }

    public static IList<T> smethod_1<T>(T startEntity, Class80.Delegate2 filter) where T : Class80
    {
      List<T> objList = new List<T>();
      T obj = startEntity;
      while ((object) obj != null)
      {
        if (filter((Class80) obj))
          objList.Add(obj);
        obj = (T) obj.Next;
        if ((object) obj == (object) startEntity)
          break;
      }
      return (IList<T>) objList;
    }

    public static void smethod_2(Class80 startEntity, Class608 wires)
    {
      Class80 class80 = startEntity;
      while (class80 != null)
      {
        class80.vmethod_3(wires);
        class80 = class80.Next;
        if (class80 == startEntity)
          break;
      }
    }

    internal delegate bool Delegate2(Class80 entity);
  }
}
