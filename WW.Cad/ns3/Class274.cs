// Decompiled with JetBrains decompiler
// Type: ns3.Class274
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class274 : Class260
  {
    private List<Class1050> list_1 = new List<Class1050>();
    private List<Class505> list_2 = new List<Class505>();
    private List<Class506> list_3 = new List<Class506>();
    private List<Interface10> list_4 = new List<Interface10>();

    public Class274(DxfLinkedTableData linkedTableData)
      : base((DxfObject) linkedTableData)
    {
    }

    public List<Class1050> RowBuilders
    {
      get
      {
        return this.list_1;
      }
    }

    public List<Class505> ColumnBuilders
    {
      get
      {
        return this.list_2;
      }
    }

    public List<Class506> CellBuilders
    {
      get
      {
        return this.list_3;
      }
    }

    public List<Interface10> PrerequisiteBuilders
    {
      get
      {
        return this.list_4;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      modelBuilder.ResolveReferences((ICollection<Interface10>) this.list_4);
    }
  }
}
