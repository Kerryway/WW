// Decompiled with JetBrains decompiler
// Type: ns15.Class154
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns15
{
  internal class Class154 : Class152
  {
    public const string string_3 = "fmesh-eye-attrib";
    public const string string_4 = "fmesh-lwd-attrib";

    public override string imethod_2(int version)
    {
      return version >= Class250.int_21 ? "fmesh-eye-attrib" : "fmesh-lwd-attrib";
    }
  }
}
