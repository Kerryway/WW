// Decompiled with JetBrains decompiler
// Type: ns27.Class277
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns3;
using System;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.DynamicBlock;
using WW.Cad.Model.Tables;

namespace ns27
{
  internal class Class277 : Class260
  {
    private ulong ulong_2;

    public Class277(DxfBlockRepresentationData obj)
      : base((DxfObject) obj)
    {
    }

    public ulong DynamicBlockHandle
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

    public DxfBlockRepresentationData BlockRepresentationData
    {
      get
      {
        return this.Object as DxfBlockRepresentationData;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      if (this.DynamicBlockHandle == 0UL)
        return;
      DxfBlock dxfBlock = modelBuilder.method_4<DxfBlock>(this.DynamicBlockHandle);
      if (dxfBlock == null)
        throw new Exception("Cannot resolve handle.");
      this.BlockRepresentationData.DynamicBlock = dxfBlock;
    }
  }
}
