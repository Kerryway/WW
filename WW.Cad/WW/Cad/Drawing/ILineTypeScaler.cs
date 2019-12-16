// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.ILineTypeScaler
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace WW.Cad.Drawing
{
  public interface ILineTypeScaler
  {
    double GetScaledLength(Vector2D v);

    double GetScaledLength(Vector3D v);

    void GetLengths(Vector2D v, out double length, out double scaledLength);

    Matrix3D ApplyWcsToOcsCorrection(Matrix3D m);
  }
}
