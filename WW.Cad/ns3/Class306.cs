// Decompiled with JetBrains decompiler
// Type: ns3.Class306
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class306 : Class285
  {
    private ulong ulong_6;

    public Class306(DxfMLine mline)
      : base((DxfEntity) mline)
    {
    }

    public ulong MLineStyleHandle
    {
      get
      {
        return this.ulong_6;
      }
      set
      {
        this.ulong_6 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfMLine entity = (DxfMLine) this.Entity;
      if (this.ulong_6 == 0UL)
        return;
      DxfMLineStyle dxfMlineStyle = modelBuilder.method_4<DxfMLineStyle>(this.ulong_6);
      if (dxfMlineStyle == null)
        return;
      entity.Style = dxfMlineStyle;
    }
  }
}
