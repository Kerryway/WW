// Decompiled with JetBrains decompiler
// Type: ns3.Class999
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model;

namespace ns3
{
  internal class Class999 : Interface10
  {
    private readonly DxfValue dxfValue_0;
    private ulong ulong_0;

    public Class999(DxfValue value)
    {
      this.dxfValue_0 = value;
    }

    public DxfValue Value
    {
      get
      {
        return this.dxfValue_0;
      }
    }

    public ulong ObjectHandle
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

    public void ResolveReferences(Class374 modelBuilder)
    {
      if (this.ulong_0 == 0UL)
        return;
      this.dxfValue_0.SetValue(modelBuilder.method_3(this.ulong_0));
    }
  }
}
