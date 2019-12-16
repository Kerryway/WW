// Decompiled with JetBrains decompiler
// Type: ns3.Class315
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class315 : Class259
  {
    private LinkedList<Interface10> linkedList_1;

    public Class315(DxfLineType lineType)
      : base((DxfHandledObject) lineType)
    {
    }

    public void Add(Interface10 childBuilder)
    {
      if (this.linkedList_1 == null)
        this.linkedList_1 = new LinkedList<Interface10>();
      this.linkedList_1.AddLast(childBuilder);
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      modelBuilder.ResolveReferences((ICollection<Interface10>) this.linkedList_1);
    }
  }
}
