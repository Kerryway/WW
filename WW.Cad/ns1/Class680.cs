// Decompiled with JetBrains decompiler
// Type: ns1.Class680
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.InventorDrawing;
using WW.Cad.Model.Tables;

namespace ns1
{
  internal class Class680 : BasicEntityVisitor
  {
    internal void Visit(DxfModel model)
    {
      foreach (DxfBlock block in (KeyedDxfHandledObjectCollection<string, DxfBlock>) model.Blocks)
        this.Visit((IEnumerable<DxfEntity>) block.Entities);
      this.Visit((IEnumerable<DxfEntity>) model.Entities);
    }

    internal void Visit(IEnumerable<DxfEntity> entities)
    {
      BasicEntityVisitor.Visit(entities, (IEntityVisitor) this);
    }

    public override void Visit(DxfAttribute attribute)
    {
      attribute.method_19();
    }

    public override void Visit(DxfAttributeDefinition attributeDefinition)
    {
      attributeDefinition.method_19();
    }

    public override void Visit(DxfInsert insert)
    {
      this.Visit((IEnumerable<DxfEntity>) insert.Attributes);
    }

    public override void Visit(DxfIDBlockReference insert)
    {
      this.Visit((IEnumerable<DxfEntity>) insert.Attributes);
    }
  }
}
