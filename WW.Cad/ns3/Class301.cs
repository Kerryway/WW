// Decompiled with JetBrains decompiler
// Type: ns3.Class301
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using WW.Cad.Model.Entities;

namespace ns3
{
  internal class Class301 : Class285
  {
    private Enum51 enum51_0;

    public Class301(DxfVertex3D vertex)
      : base((DxfEntity) vertex)
    {
    }

    public Enum51 Flags
    {
      get
      {
        return this.enum51_0;
      }
      set
      {
        this.enum51_0 = value;
      }
    }

    public bool IsSplineControlPoint
    {
      get
      {
        return (this.enum51_0 & Enum51.flag_5) != Enum51.flag_0;
      }
    }

    public override string ToString()
    {
      return string.Format("{0}", (object) this.enum51_0);
    }
  }
}
