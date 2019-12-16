// Decompiled with JetBrains decompiler
// Type: ns3.Class329
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model;

namespace ns3
{
  internal class Class329 : Interface10
  {
    private ulong ulong_0;
    private System.Action<DxfObjectReference> action_0;

    public Class329(ulong handle, System.Action<DxfObjectReference> setObjectReference)
    {
      this.ulong_0 = handle;
      this.action_0 = setObjectReference;
    }

    public void ResolveReferences(Class374 modelBuilder)
    {
      if (this.ulong_0 == 0UL)
        this.action_0(DxfObjectReference.Null);
      else
        this.action_0(DxfObjectReference.GetReference((IDxfHandledObject) modelBuilder.method_3(this.ulong_0)));
    }
  }
}
