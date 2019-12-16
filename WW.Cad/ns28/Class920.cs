// Decompiled with JetBrains decompiler
// Type: ns28.Class920
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model;
using WW.Cad.Model.Entities;

namespace ns28
{
  internal class Class920 : Class918
  {
    public Class920(DxfVersion outputVersion)
      : base(outputVersion)
    {
    }

    public new void Visit(DxfRegion region)
    {
      base.Visit(region);
      if (!this.bool_0 || !region.IsSab || this.dxfVersion_0 > DxfVersion.Dxf15)
        return;
      this.bool_0 = false;
    }

    public new void Visit(DxfBody body)
    {
      base.Visit(body);
      if (!this.bool_0 || !body.IsSab || this.dxfVersion_0 > DxfVersion.Dxf15)
        return;
      this.bool_0 = false;
    }

    public new void Visit(Dxf3DSolid solid)
    {
      base.Visit(solid);
      if (!this.bool_0 || !solid.IsSab || this.dxfVersion_0 > DxfVersion.Dxf15)
        return;
      this.bool_0 = false;
    }
  }
}
