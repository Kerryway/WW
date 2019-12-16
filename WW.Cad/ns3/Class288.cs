// Decompiled with JetBrains decompiler
// Type: ns3.Class288
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class288 : Class285
  {
    private string string_2;

    public Class288(DxfBlockBegin entity)
      : base((DxfEntity) entity)
    {
    }

    public string Name
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfBlockBegin handledObject = this.HandledObject as DxfBlockBegin;
      if (handledObject == null)
        return;
      DxfBlock block = handledObject.Block;
      if (block == null || this.string_2 == null)
        return;
      block.method_9(this.string_2);
    }

    public override string ToString()
    {
      return this.string_2;
    }
  }
}
