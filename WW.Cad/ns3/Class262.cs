// Decompiled with JetBrains decompiler
// Type: ns3.Class262
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.IO;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class262 : Class260
  {
    public Class262(DxfDictionary dictionary)
      : base((DxfObject) dictionary)
    {
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      if (modelBuilder.FileFormat != FileFormat.Dwg || modelBuilder.Model.DictionaryRoot != null || this.OwnerHandle != 0UL)
        return;
      modelBuilder.Model.DictionaryRoot = (DxfDictionary) this.Object;
    }
  }
}
