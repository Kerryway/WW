// Decompiled with JetBrains decompiler
// Type: ns3.Class314
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class314 : Class259
  {
    private List<Class730> list_1;

    public Class314(DxfMLineStyle mlineStyle)
      : base((DxfHandledObject) mlineStyle)
    {
    }

    public List<Class730> ElementBuilders
    {
      get
      {
        if (this.list_1 == null)
          this.list_1 = new List<Class730>();
        return this.list_1;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfMLineStyle handledObject = (DxfMLineStyle) this.HandledObject;
      if (this.list_1 == null)
        return;
      foreach (Class730 class730 in this.list_1)
        class730.ResolveReferences(modelBuilder, handledObject);
    }
  }
}
