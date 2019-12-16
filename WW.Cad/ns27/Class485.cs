// Decompiled with JetBrains decompiler
// Type: ns27.Class485
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns3;
using WW.Cad.Model.Objects;

namespace ns27
{
  internal class Class485 : Interface10
  {
    private DxfXRecordValue dxfXRecordValue_0;
    private ulong ulong_0;

    public ulong DataValueHandle
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

    public Class485(DxfXRecordValue xrecord)
    {
      this.dxfXRecordValue_0 = xrecord;
    }

    public void ResolveReferences(Class374 modelBuilder)
    {
      if (this.ulong_0 != 0UL)
        this.dxfXRecordValue_0.Value = (object) modelBuilder.method_3(this.ulong_0);
      else
        this.dxfXRecordValue_0.Value = (object) 0;
    }
  }
}
