// Decompiled with JetBrains decompiler
// Type: ns3.Class260
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class260 : Class259
  {
    public Class260(DxfObject obj)
      : base((DxfHandledObject) obj)
    {
    }

    public DxfObject Object
    {
      get
      {
        return (DxfObject) this.HandledObject;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
    }
  }
}
