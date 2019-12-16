// Decompiled with JetBrains decompiler
// Type: ns7.Interface26
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace ns7
{
  internal interface Interface26
  {
    Point2D imethod_0(Point3D point);

    Point3D imethod_1(double u, double v);

    bool IsRightHandedParametric { get; }
  }
}
