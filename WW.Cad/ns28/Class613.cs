// Decompiled with JetBrains decompiler
// Type: ns28.Class613
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;

namespace ns28
{
  internal class Class613
  {
    public static void Read(Class889 reader, DxfModel model)
    {
      reader.vmethod_8();
      int num1 = (int) reader.vmethod_10();
      if (model.Header.AcadVersion >= DxfVersion.Dxf15)
        reader.vmethod_26();
      else
        reader.vmethod_26();
      int num2 = (int) reader.vmethod_10();
      byte num3 = reader.vmethod_0();
      for (int index = 0; index < (int) num3; ++index)
      {
        int num4 = (int) reader.vmethod_10();
        int num5 = (int) reader.vmethod_10();
      }
    }
  }
}
