// Decompiled with JetBrains decompiler
// Type: ns5.Class678
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model.Entities;

namespace ns5
{
  internal class Class678 : BasicEntityVisitor
  {
    private readonly List<DxfAttributeDefinition> list_0 = new List<DxfAttributeDefinition>();

    public override void Visit(DxfAttributeDefinition attributeDefinition)
    {
      this.list_0.Add(attributeDefinition);
    }

    public List<DxfAttributeDefinition> AttributeDefinitions
    {
      get
      {
        return this.list_0;
      }
    }
  }
}
