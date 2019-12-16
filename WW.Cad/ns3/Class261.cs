// Decompiled with JetBrains decompiler
// Type: ns3.Class261
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class261 : Class260
  {
    private List<ulong> list_1 = new List<ulong>();

    public Class261(DxfIdBuffer obj)
      : base((DxfObject) obj)
    {
    }

    public List<ulong> Handles
    {
      get
      {
        return this.list_1;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfIdBuffer handledObject = (DxfIdBuffer) this.HandledObject;
      foreach (ulong handle in this.list_1)
      {
        if (handle != 0UL)
        {
          DxfHandledObject dxfHandledObject = modelBuilder.method_3(handle);
          if (dxfHandledObject != null)
            handledObject.HandledObjects.Add(dxfHandledObject);
        }
      }
    }
  }
}
