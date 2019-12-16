// Decompiled with JetBrains decompiler
// Type: ns2.Class721
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;

namespace ns2
{
  internal static class Class721
  {
    private static readonly string string_0 = "*Model_Space".ToUpperInvariant();
    private static readonly string string_1 = "*Paper_Space".ToUpperInvariant();

    internal static string smethod_0(DxfVersion effectiveVersion, string name)
    {
      if (effectiveVersion < DxfVersion.Dxf15 && name != null)
      {
        string upperInvariant = name.ToUpperInvariant();
        if (upperInvariant == Class721.string_0 || upperInvariant.StartsWith(Class721.string_1))
          return upperInvariant;
      }
      return name;
    }
  }
}
