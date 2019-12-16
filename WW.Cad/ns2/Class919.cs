// Decompiled with JetBrains decompiler
// Type: ns2.Class919
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;
using WW.Cad.Model.Entities;

namespace ns2
{
  internal class Class919 : Class918
  {
    public Class919(DxfVersion outputVersion)
      : base(outputVersion)
    {
    }

    public new void Visit(DxfRegion region)
    {
      base.Visit(region);
      if (!this.bool_0 || !region.IsSab)
        return;
      this.bool_0 = true;
    }

    public new void Visit(DxfBody body)
    {
      base.Visit(body);
      if (!this.bool_0 || !body.IsSab)
        return;
      this.bool_0 = true;
    }

    public new void Visit(Dxf3DSolid solid)
    {
      base.Visit(solid);
      if (!this.bool_0 || !solid.IsSab)
        return;
      this.bool_0 = true;
    }
  }
}
