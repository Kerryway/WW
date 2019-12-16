// Decompiled with JetBrains decompiler
// Type: ns2.Interface33
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.IO;

namespace ns2
{
  internal interface Interface33
  {
    Struct18 imethod_0(DxfReader dxfReader);

    Struct18 imethod_1(DxfReader dxfReader, int baseGroupCode);

    Struct18 imethod_2(DxfReader dxfReader);

    void imethod_3(bool close);

    string Position { get; }
  }
}
