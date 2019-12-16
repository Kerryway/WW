// Decompiled with JetBrains decompiler
// Type: ns3.Class308
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class308 : Class285
  {
    private List<ulong> list_1;
    private ulong ulong_6;
    private ulong ulong_7;
    private ulong ulong_8;
    private ulong ulong_9;
    private int? nullable_3;
    private int? nullable_4;

    public Class308(DxfViewport viewport)
      : base((DxfEntity) viewport)
    {
    }

    public List<ulong> FrozenLayerHandles
    {
      get
      {
        if (this.list_1 == null)
          this.list_1 = new List<ulong>();
        return this.list_1;
      }
    }

    public ulong ClippingBoundaryEntityHandle
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

    public ulong NamedUcsHandle
    {
      get
      {
        return this.ulong_7;
      }
      set
      {
        this.ulong_7 = value;
      }
    }

    public ulong BaseUcsHandle
    {
      get
      {
        return this.ulong_8;
      }
      set
      {
        this.ulong_8 = value;
      }
    }

    public ulong ViewportEntityHeaderHandle
    {
      get
      {
        return this.ulong_9;
      }
      set
      {
        this.ulong_9 = value;
      }
    }

    public int? Id
    {
      get
      {
        return this.nullable_3;
      }
      set
      {
        this.nullable_3 = value;
      }
    }

    public int? Status
    {
      get
      {
        return this.nullable_4;
      }
      set
      {
        this.nullable_4 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfViewport entity = (DxfViewport) this.Entity;
      if (modelBuilder.Version >= DxfVersion.Dxf12 && modelBuilder.Version <= DxfVersion.Dxf14)
        entity.method_18(modelBuilder.Model);
      if (this.list_1 != null)
      {
        foreach (ulong handle in this.list_1)
        {
          DxfLayer dxfLayer = modelBuilder.method_4<DxfLayer>(handle);
          if (dxfLayer != null)
            entity.FrozenLayers.Add(dxfLayer);
        }
      }
      if (this.ulong_6 != 0UL)
        entity.ClippingBoundaryEntity = modelBuilder.method_4<DxfEntity>(this.ulong_6);
      if (this.ulong_7 != 0UL)
        entity.Ucs = modelBuilder.method_4<DxfUcs>(this.ulong_7);
      if (this.ulong_8 != 0UL)
        entity.Ucs = modelBuilder.method_4<DxfUcs>(this.ulong_8);
      if (this.ulong_9 == 0UL)
        return;
      entity.ViewportEntityHeader = modelBuilder.method_4<DxfViewportEntityHeader>(this.ulong_9);
    }
  }
}
