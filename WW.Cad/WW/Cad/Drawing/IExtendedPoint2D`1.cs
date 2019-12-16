// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.IExtendedPoint2D`1
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Drawing
{
  public interface IExtendedPoint2D<T> : IExtendedPoint2D where T : IExtendedPoint2D<T>, new()
  {
    T GetPoint(T nextVertex, double fraction);

    T GetEndPoint(T nextVertex, double fraction);

    void SetEndProperties(T previousVertex, double fraction);

    T Clone();
  }
}
