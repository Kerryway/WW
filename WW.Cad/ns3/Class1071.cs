// Decompiled with JetBrains decompiler
// Type: ns3.Class1071
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class1071 : Interface10
  {
    private DxfTableBorder dxfTableBorder_0;
    private ulong ulong_0;

    public ulong LineTypeHandle
    {
      get
      {
        return this.ulong_0;
      }
      set
      {
        this.ulong_0 = value;
      }
    }

    public Class1071(DxfTableBorder border)
    {
      this.dxfTableBorder_0 = border;
    }

    public void ResolveReferences(Class374 modelBuilder)
    {
      if (this.ulong_0 == 0UL)
        return;
      this.dxfTableBorder_0.method_0(modelBuilder.method_4<DxfLineType>(this.ulong_0));
    }
  }
}
