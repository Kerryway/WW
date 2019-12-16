// Decompiled with JetBrains decompiler
// Type: ns3.Class330
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using ns2;
using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class330 : Interface10
  {
    private Class1026 class1026_0;
    private short short_0;
    private int int_0;
    private short short_1;
    private ulong ulong_0;
    private string string_0;
    private ulong ulong_1;
    private short short_2;
    private Class331 class331_0;
    private List<Class331> list_0;

    public Class330(Class1026 cell)
    {
      this.class1026_0 = cell;
    }

    public Class1026 Cell
    {
      get
      {
        return this.class1026_0;
      }
    }

    public short EdgeFlags
    {
      get
      {
        return this.short_0;
      }
      set
      {
        this.short_0 = value;
      }
    }

    public int OverrideFlags
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

    public short VirtualEdgeFlags
    {
      get
      {
        return this.short_1;
      }
      set
      {
        this.short_1 = value;
      }
    }

    public ulong BlockOrFieldHandle
    {
      get
      {
        return this.ulong_0;
      }
      set
      {
        this.ulong_0 = value;
      }
    }

    public string TextStyleName
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public ulong TextStyleHandle
    {
      get
      {
        return this.ulong_1;
      }
      set
      {
        this.ulong_1 = value;
      }
    }

    public short NumberOfAttributeDefinitions
    {
      get
      {
        return this.short_2;
      }
      set
      {
        this.short_2 = value;
      }
    }

    public Class331 CurrentAttributeBuilder
    {
      get
      {
        return this.class331_0;
      }
    }

    public Class331 AddAttribute()
    {
      DxfTableAttribute attribute = new DxfTableAttribute();
      this.class1026_0.Attributes.Add(attribute);
      this.class331_0 = new Class331(attribute);
      if (this.list_0 == null)
        this.list_0 = new List<Class331>();
      this.list_0.Add(this.class331_0);
      return this.class331_0;
    }

    public void method_0(Class331 attributeBuilder)
    {
      if (this.list_0 == null)
        this.list_0 = new List<Class331>();
      this.list_0.Add(attributeBuilder);
    }

    public void ResolveReferences(Class374 modelBuilder)
    {
      DxfHandledObject dxfHandledObject = modelBuilder.method_3(this.ulong_0);
      if (dxfHandledObject != null)
        this.class1026_0.BlockOrField = dxfHandledObject;
      if (this.ulong_1 != 0UL)
        this.class1026_0.TextStyle = modelBuilder.method_4<DxfTextStyle>(this.ulong_1);
      else if (!string.IsNullOrEmpty(this.string_0))
        this.class1026_0.TextStyle = modelBuilder.Model.TextStyles[this.string_0];
      if (this.list_0 == null)
        return;
      foreach (Class331 class331 in this.list_0)
        class331.ResolveReferences(modelBuilder);
    }
  }
}
