// Decompiled with JetBrains decompiler
// Type: ns28.Class612
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;

namespace ns28
{
  internal class Class612
  {
    public static void Write(
      Class889 stream,
      DxfModel model,
      uint estimatedObjectCount,
      uint objectsSectionStreamOffset)
    {
      stream.vmethod_9(0);
      stream.vmethod_11(estimatedObjectCount);
      if (model.Header.AcadVersion >= DxfVersion.Dxf15)
        stream.vmethod_27(model.Header.UpdateUtcDateTime);
      else
        stream.vmethod_27(model.Header.UpdateDateTime);
      stream.vmethod_11(objectsSectionStreamOffset);
      stream.vmethod_1((byte) 4);
      stream.vmethod_11(50U);
      stream.vmethod_11(0U);
      stream.vmethod_11(100U);
      stream.vmethod_11(0U);
      stream.vmethod_11(512U);
      stream.vmethod_11(0U);
      stream.vmethod_11(uint.MaxValue);
      stream.vmethod_11(0U);
    }
  }
}
