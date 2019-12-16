// Decompiled with JetBrains decompiler
// Type: ns1.Class430
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;
using WW.Collections.Generic;

namespace ns1
{
  internal class Class430
  {
    private double double_0 = 0.36;
    private Class1025 class1025_0 = new Class1025();
    private Class551 class551_0;

    public Class430()
    {
      this.class1025_0.Added += new ItemEventHandler<Class1026>(this.method_3);
      this.class1025_0.Removed += new ItemEventHandler<Class1026>(this.method_2);
      this.class1025_0.Set += new ItemSetEventHandler<Class1026>(this.method_1);
    }

    public double Height
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
      }
    }

    public Class1025 Cells
    {
      get
      {
        return this.class1025_0;
      }
    }

    public Class551 Table
    {
      get
      {
        return this.class551_0;
      }
    }

    public int Index
    {
      get
      {
        return this.class551_0.Rows.IndexOf(this);
      }
    }

    internal void method_0(Class551 table)
    {
      this.class551_0 = table;
      foreach (Class1026 class1026 in (ActiveList<Class1026>) this.class1025_0)
        class1026.method_3(this);
    }

    internal Class430 Clone(CloneContext cloneContext)
    {
      Class430 class430 = new Class430();
      class430.CopyFrom(this, cloneContext);
      return class430;
    }

    private void CopyFrom(Class430 from, CloneContext cloneContext)
    {
      this.double_0 = from.double_0;
      foreach (Class1026 class1026 in (ActiveList<Class1026>) from.class1025_0)
        this.class1025_0.Add(class1026.Clone(cloneContext));
    }

    private void method_1(object sender, int index, Class1026 oldItem, Class1026 newItem)
    {
      oldItem.method_3((Class430) null);
      newItem.method_3(this);
    }

    private void method_2(object sender, int index, Class1026 item)
    {
      item.method_3((Class430) null);
    }

    private void method_3(object sender, int index, Class1026 item)
    {
      item.method_3(this);
    }
  }
}
