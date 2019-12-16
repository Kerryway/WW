// Decompiled with JetBrains decompiler
// Type: ns3.Class331
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model.Entities;

namespace ns3
{
  internal class Class331
  {
    private DxfTableAttribute dxfTableAttribute_0;
    private ulong ulong_0;

    public Class331(DxfTableAttribute attribute)
    {
      this.dxfTableAttribute_0 = attribute;
    }

    public DxfTableAttribute Attribute
    {
      get
      {
        return this.dxfTableAttribute_0;
      }
    }

    public ulong AttributeDefinitionHandle
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
      this.dxfTableAttribute_0.AttributeDefinition = modelBuilder.method_4<DxfAttributeDefinition>(this.ulong_0);
    }
  }
}
