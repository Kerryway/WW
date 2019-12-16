// Decompiled with JetBrains decompiler
// Type: ns28.Class501
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;

namespace ns28
{
  internal class Class501
  {
    public static void Write(Class889 stream, DxfModel model)
    {
      stream.vmethod_5((short) 0);
      stream.vmethod_7((ushort) model.Header.MeasurementUnits);
    }
  }
}
