// Decompiled with JetBrains decompiler
// Type: ns5.Class679
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model.Entities;

namespace ns5
{
  internal class Class679 : BasicEntityVisitor
  {
    private readonly string string_0;
    private DxfAttributeDefinition dxfAttributeDefinition_0;

    public Class679(string tag)
    {
      this.string_0 = tag;
    }

    public DxfAttributeDefinition AttributeDefinition
    {
      get
      {
        return this.dxfAttributeDefinition_0;
      }
    }

    public override void Visit(DxfAttributeDefinition attributeDefinition)
    {
      if (!(this.string_0 == attributeDefinition.TagString))
        return;
      this.dxfAttributeDefinition_0 = attributeDefinition;
    }

    public static DxfAttributeDefinition GetAttributeDefinition(
      string tag,
      IEnumerable<DxfEntity> entities)
    {
      Class679 class679 = new Class679(tag);
      foreach (DxfEntity entity in entities)
      {
        entity.Accept((IEntityVisitor) class679);
        if (class679.AttributeDefinition != null)
          break;
      }
      return class679.AttributeDefinition;
    }
  }
}
