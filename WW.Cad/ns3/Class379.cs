// Decompiled with JetBrains decompiler
// Type: ns3.Class379
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class379 : Interface10
  {
    private DxfExtendedData.LayerReference layerReference_0;
    private ulong ulong_0;

    public Class379(DxfExtendedData.LayerReference layerReference, ulong layerHandle)
    {
      this.layerReference_0 = layerReference;
      this.ulong_0 = layerHandle;
    }

    public void ResolveReferences(Class374 modelBuilder)
    {
      if (this.ulong_0 == 0UL)
        return;
      this.layerReference_0.Value = modelBuilder.method_4<DxfLayer>(this.ulong_0);
    }
  }
}
