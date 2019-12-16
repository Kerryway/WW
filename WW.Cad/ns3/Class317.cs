// Decompiled with JetBrains decompiler
// Type: ns3.Class317
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class317 : Class259
  {
    private ulong ulong_2;
    private ulong ulong_3;

    public Class317(DxfView view)
      : base((DxfHandledObject) view)
    {
    }

    public ulong BaseUcsHandle
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

    public ulong NamedUcsHandle
    {
      get
      {
        return this.ulong_3;
      }
      set
      {
        this.ulong_3 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfView handledObject = (DxfView) this.HandledObject;
      if (this.ulong_2 != 0UL)
      {
        DxfUcs dxfUcs = modelBuilder.method_4<DxfUcs>(this.ulong_2);
        if (dxfUcs != null)
          handledObject.Ucs = dxfUcs;
      }
      if (this.ulong_3 == 0UL)
        return;
      DxfUcs dxfUcs1 = modelBuilder.method_4<DxfUcs>(this.ulong_3);
      if (dxfUcs1 == null)
        return;
      handledObject.Ucs = dxfUcs1;
    }
  }
}
