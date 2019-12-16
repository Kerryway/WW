// Decompiled with JetBrains decompiler
// Type: ns3.Class263
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class263 : Class262
  {
    private ulong ulong_2;

    public Class263(DxfDictionaryWithDefault dictionary)
      : base((DxfDictionary) dictionary)
    {
    }

    public ulong DefaultEntryHandle
    {
      get
      {
        return this.ulong_2;
      }
      set
      {
        this.ulong_2 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      if (this.ulong_2 == 0UL)
        return;
      ((DxfDictionaryWithDefault) this.HandledObject).DefaultEntry = modelBuilder.method_4<DxfObject>(this.ulong_2);
    }
  }
}
