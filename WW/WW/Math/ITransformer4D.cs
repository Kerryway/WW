// Decompiled with JetBrains decompiler
// Type: WW.Math.ITransformer4D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math
{
  public interface ITransformer4D
  {
    Vector4D Transform(Vector4D p);

    Point2D TransformToPoint2D(Vector4D p);

    Point3D TransformToPoint3D(Vector4D p);

    Vector4D TransformTo4D(Point2D p);
  }
}
