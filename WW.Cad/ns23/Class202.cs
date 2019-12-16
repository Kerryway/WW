// Decompiled with JetBrains decompiler
// Type: ns23.Class202
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace ns23
{
  internal class Class202 : Class201
  {
    public const string string_5 = "srf_srf_v_bl_spl_sur";
    public const string string_6 = "srfsrfblndsur";

    public override string imethod_2(int version)
    {
      return version >= 21200 ? "srf_srf_v_bl_spl_sur" : "srfsrfblndsur";
    }
  }
}
