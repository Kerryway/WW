// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.ValueDataType
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model
{
  public enum ValueDataType
  {
    None = 0,
    Int = 1,
    Double = 2,
    String = 4,
    Date = 8,
    Point2D = 16, // 0x00000010
    Point3D = 32, // 0x00000020
    ObjectHandle = 64, // 0x00000040
    Buffer = 128, // 0x00000080
    ResultBuffer = 256, // 0x00000100
    General = 512, // 0x00000200
  }
}
