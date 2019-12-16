// Decompiled with JetBrains decompiler
// Type: ns3.Class333
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class333 : Interface10
  {
    private readonly DxfExtendedDataCollection dxfExtendedDataCollection_0;
    private readonly DxfExtendedData dxfExtendedData_0;
    private string string_0;

    public Class333(DxfExtendedDataCollection extendedDataCollection, DxfExtendedData extendedData)
    {
      this.dxfExtendedDataCollection_0 = extendedDataCollection;
      this.dxfExtendedData_0 = extendedData;
    }

    public DxfExtendedData ExtendedData
    {
      get
      {
        return this.dxfExtendedData_0;
      }
    }

    public string AppIdName
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public void ResolveReferences(Class374 modelBuilder)
    {
      DxfAppId appId;
      if (string.IsNullOrEmpty(this.string_0) || !modelBuilder.Model.AppIds.TryGetValue(this.string_0, out appId))
        return;
      this.dxfExtendedDataCollection_0.method_0(this.dxfExtendedData_0, appId);
    }
  }
}
