// Decompiled with JetBrains decompiler
// Type: ns28.Class502
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;

namespace ns28
{
  internal class Class502
  {
    public static void Read(Class889 stream, DxfModel model)
    {
      int num = (int) stream.vmethod_4();
      stream.vmethod_17(num << 1);
      model.Header.MeasurementUnits = (MeasurementUnits) stream.vmethod_6();
    }
  }
}
