// Decompiled with JetBrains decompiler
// Type: ns3.Class292
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class292 : Class285
  {
    private ulong ulong_6;

    public Class292(DxfRasterImage image)
      : base((DxfEntity) image)
    {
    }

    public ulong ImageDefHandle
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

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfRasterImage handledObject = (DxfRasterImage) this.HandledObject;
      if (this.ulong_6 == 0UL)
        return;
      DxfImageDef imageDef = modelBuilder.method_4<DxfImageDef>(this.ulong_6);
      if (imageDef == null)
        return;
      handledObject.SetImageDef(imageDef, false);
    }
  }
}
