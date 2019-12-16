// Decompiled with JetBrains decompiler
// Type: ns3.Class283
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class283 : Class260
  {
    private readonly List<ulong> list_1 = new List<ulong>();
    private readonly List<ulong> list_2 = new List<ulong>();

    public Class283(DxfField field)
      : base((DxfObject) field)
    {
    }

    public void method_1(ulong handle)
    {
      this.list_1.Add(handle);
    }

    public void method_2(ulong handle)
    {
      this.list_2.Add(handle);
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfField dxfField1 = this.Object as DxfField;
      if (dxfField1 == null)
        return;
      foreach (ulong handle in this.list_1)
      {
        DxfField dxfField2 = modelBuilder.method_4<DxfField>(handle);
        if (dxfField2 != null)
          dxfField1.ChildFields.Add(dxfField2);
      }
      foreach (ulong handle in this.list_2)
      {
        DxfHandledObject dxfHandledObject = modelBuilder.method_3(handle);
        if (dxfHandledObject != null)
          dxfField1.FieldObjects.Add(dxfHandledObject);
      }
    }
  }
}
