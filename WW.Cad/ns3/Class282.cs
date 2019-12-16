// Decompiled with JetBrains decompiler
// Type: ns3.Class282
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class282 : Class260
  {
    private List<ulong> list_1 = new List<ulong>();

    public List<ulong> FieldHandles
    {
      get
      {
        return this.list_1;
      }
    }

    public Class282(DxfFieldList obj)
      : base((DxfObject) obj)
    {
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfFieldList handledObject = (DxfFieldList) this.HandledObject;
      foreach (ulong handle in this.list_1)
      {
        DxfField dxfField = modelBuilder.method_4<DxfField>(handle);
        if (dxfField != null)
          handledObject.Fields.Add(dxfField);
      }
    }
  }
}
