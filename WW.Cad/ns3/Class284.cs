// Decompiled with JetBrains decompiler
// Type: ns3.Class284
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class284 : Class260
  {
    private ulong ulong_2;
    private ulong ulong_3;
    private ulong ulong_4;
    private ulong ulong_5;
    private List<ulong> list_1;

    public Class284(DxfLayout layout)
      : base((DxfObject) layout)
    {
    }

    public ulong AssociatedBockRecordHandle
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

    public ulong LastActiveViewportHandle
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

    public ulong BaseUcsHandle
    {
      get
      {
        return this.ulong_4;
      }
      set
      {
        this.ulong_4 = value;
      }
    }

    public ulong NamedUcsHandle
    {
      get
      {
        return this.ulong_5;
      }
      set
      {
        this.ulong_5 = value;
      }
    }

    public List<ulong> ViewportHandles
    {
      get
      {
        return this.list_1;
      }
    }

    public List<ulong> ViewportHandlesNotNull
    {
      get
      {
        if (this.list_1 == null)
          this.list_1 = new List<ulong>();
        return this.list_1;
      }
    }

    public bool HasViewportHandles
    {
      get
      {
        if (this.list_1 != null)
          return this.list_1.Count > 0;
        return false;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfLayout handledObject = (DxfLayout) this.HandledObject;
      if (this.ulong_2 != 0UL && handledObject.OwnerBlock == null)
      {
        DxfBlock dxfBlock = modelBuilder.method_4<DxfBlock>(this.ulong_2);
        if (dxfBlock != null)
          handledObject.OwnerBlock = dxfBlock;
      }
      if (this.ulong_3 != 0UL)
      {
        DxfHandledObject dxfHandledObject = modelBuilder.method_3(this.ulong_3);
        if (dxfHandledObject != null)
          handledObject.LastActiveViewport = dxfHandledObject;
      }
      if (this.ulong_4 != 0UL)
      {
        DxfUcs dxfUcs = modelBuilder.method_4<DxfUcs>(this.ulong_4);
        if (dxfUcs != null)
          handledObject.Ucs = dxfUcs;
      }
      if (this.ulong_5 != 0UL)
      {
        DxfUcs dxfUcs = modelBuilder.method_4<DxfUcs>(this.ulong_5);
        if (dxfUcs != null)
          handledObject.Ucs = dxfUcs;
      }
      if (this.list_1 == null)
        return;
      short num = 1;
      foreach (ulong handle in this.list_1)
      {
        DxfViewport dxfViewport = modelBuilder.method_4<DxfViewport>(handle);
        if (dxfViewport != null)
        {
          handledObject.Viewports.Add(dxfViewport);
          ++num;
        }
      }
    }
  }
}
