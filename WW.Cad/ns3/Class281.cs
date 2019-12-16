// Decompiled with JetBrains decompiler
// Type: ns3.Class281
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class281 : Class260
  {
    private readonly List<ulong> list_1 = new List<ulong>();

    public Class281(DxfGroup group)
      : base((DxfObject) group)
    {
    }

    public List<ulong> MemberHandles
    {
      get
      {
        return this.list_1;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfGroup handledObject = (DxfGroup) this.HandledObject;
      foreach (ulong handle in this.list_1)
      {
        DxfHandledObject dxfHandledObject = modelBuilder.method_3(handle);
        if (dxfHandledObject != null && (modelBuilder.LoadUnknownObjects || !(dxfHandledObject is DxfUnknownEntity)))
          handledObject.Members.Add(dxfHandledObject);
      }
    }
  }
}
