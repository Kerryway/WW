// Decompiled with JetBrains decompiler
// Type: ns3.Class299
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace ns3
{
  internal class Class299 : Class285
  {
    private ulong ulong_6;
    private ulong ulong_7;

    public Class299(DxfDimension dimension)
      : base((DxfEntity) dimension)
    {
    }

    public ulong DimStyleHandle
    {
      get
      {
        return this.ulong_6;
      }
      set
      {
        this.ulong_6 = value;
      }
    }

    public ulong AnonymousBlockHandle
    {
      get
      {
        return this.ulong_7;
      }
      set
      {
        this.ulong_7 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfDimension entity = (DxfDimension) this.Entity;
      if (this.ulong_6 != 0UL)
      {
        DxfDimensionStyle dxfDimensionStyle = modelBuilder.method_4<DxfDimensionStyle>(this.ulong_6);
        if (dxfDimensionStyle != null)
          entity.DimensionStyle = dxfDimensionStyle;
      }
      DxfExtendedData extendedData;
      if (entity.DimensionStyleOverrides != null && entity.ExtendedDataCollection.TryGetValue(modelBuilder.Model.AppIdAcad, out extendedData))
        Class309.smethod_0(entity.DimensionStyleOverrides, extendedData, modelBuilder);
      if (this.ulong_7 == 0UL)
        return;
      DxfBlock dxfBlock = modelBuilder.method_4<DxfBlock>(this.ulong_7);
      entity.Block = dxfBlock;
    }
  }
}
