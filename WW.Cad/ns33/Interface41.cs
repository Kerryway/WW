// Decompiled with JetBrains decompiler
// Type: ns33.Interface41
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW;
using WW.Cad.Drawing;
using WW.Math;

namespace ns33
{
  internal interface Interface41 : ICloneable
  {
    Matrix4D Matrix { get; set; }

    Matrix3D Matrix3D { get; set; }

    ILineTypeScaler LineTypeScaler { get; }

    Vector4D Transform(Point2D p);

    Point3D imethod_0(Point2D p);

    Vector4D Transform(Point3D p);

    Point3D imethod_1(Point3D p);

    Vector3D Transform(Vector3D v);

    void SetPreTransform(Matrix4D preTransform);
  }
}
