// Decompiled with JetBrains decompiler
// Type: ns3.Class278
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW;
using WW.Cad.Model;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class278 : Class260
  {
    private List<Pair<int, ulong>> list_1 = new List<Pair<int, ulong>>();

    public Class278(DxfXRecord obj)
      : base((DxfObject) obj)
    {
    }

    public void method_1(int index, ulong handle)
    {
      this.list_1.Add(new Pair<int, ulong>(index, handle));
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfXRecord handledObject = (DxfXRecord) this.HandledObject;
      foreach (Pair<int, ulong> pair in this.list_1)
      {
        DxfHandledObject dxfHandledObject = modelBuilder.method_3(pair.Second);
        if (dxfHandledObject != null)
          handledObject.Values[pair.First].Value = (object) dxfHandledObject;
      }
    }
  }
}
