// Decompiled with JetBrains decompiler
// Type: ns3.Class295
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model.Entities;
using WW.Cad.Model.InventorDrawing;

namespace ns3
{
  internal class Class295 : Class294
  {
    private ulong ulong_10;

    public Class295(DxfIDBlockReference entity)
      : base((DxfInsertBase) entity)
    {
    }

    public ulong Viewport
    {
      get
      {
        return this.ulong_10;
      }
      set
      {
        this.ulong_10 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfIDBlockReference handledObject = this.HandledObject as DxfIDBlockReference;
      if (handledObject == null)
        return;
      handledObject.Viewport = modelBuilder.method_3(this.ulong_10);
    }
  }
}
