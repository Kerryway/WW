// Decompiled with JetBrains decompiler
// Type: ns3.Class659
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model.Entities;

namespace ns3
{
  internal class Class659 : Interface10
  {
    private DxfHatch.BoundaryPath boundaryPath_0;
    private int int_0;
    private List<ulong> list_0;

    public Class659(DxfHatch.BoundaryPath boundaryPath)
    {
      this.boundaryPath_0 = boundaryPath;
    }

    public int BoundaryObjectHandleCount
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public int RemainingBoundaryObjectHandleCount
    {
      get
      {
        return this.int_0 - (this.list_0 == null ? 0 : this.list_0.Count);
      }
    }

    public void method_0(ulong handle)
    {
      if (this.list_0 == null)
        this.list_0 = new List<ulong>();
      this.list_0.Add(handle);
    }

    public void ResolveReferences(Class374 modelBuilder)
    {
      if (this.list_0 == null)
        return;
      foreach (ulong handle in this.list_0)
      {
        DxfEntity dxfEntity = modelBuilder.method_4<DxfEntity>(handle);
        if (modelBuilder.LoadUnknownObjects || !(dxfEntity is DxfUnknownEntity))
          this.boundaryPath_0.BoundaryObjects.Add(dxfEntity);
      }
    }
  }
}
