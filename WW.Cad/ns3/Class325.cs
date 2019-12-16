// Decompiled with JetBrains decompiler
// Type: ns3.Class325
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class325 : Class259
  {
    private ulong ulong_2;
    private ulong ulong_3;
    private string string_0;

    public Class325(DxfVPort vport)
      : base((DxfHandledObject) vport)
    {
    }

    public ulong BaseUcsHandle
    {
      get
      {
        return this.ulong_2;
      }
      set
      {
        this.ulong_2 = value;
      }
    }

    public ulong NamedUcsHandle
    {
      get
      {
        return this.ulong_3;
      }
      set
      {
        this.ulong_3 = value;
      }
    }

    public string AmbientDxfColorConcatenatedName
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

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfVPort handledObject = (DxfVPort) this.HandledObject;
      if (this.ulong_2 != 0UL)
      {
        DxfUcs dxfUcs = modelBuilder.method_4<DxfUcs>(this.ulong_2);
        if (dxfUcs != null)
          handledObject.Ucs = dxfUcs;
      }
      if (this.ulong_3 != 0UL)
      {
        DxfUcs dxfUcs = modelBuilder.method_4<DxfUcs>(this.ulong_3);
        if (dxfUcs != null)
          handledObject.Ucs = dxfUcs;
      }
      if (string.IsNullOrEmpty(this.string_0))
        return;
      string[] strArray = this.string_0.Split('$');
      if (strArray == null || strArray.Length != 2)
        return;
      string colorBookName = strArray[0];
      string name = strArray[1];
      handledObject.AmbientColor = Color.smethod_1(handledObject.AmbientColor.Data, colorBookName, name);
    }
  }
}
