// Decompiled with JetBrains decompiler
// Type: ns36.Class808
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns33;
using System.Collections.Generic;
using WW;
using WW.Math;
using WW.Math.Geometry;

namespace ns36
{
  internal class Class808 : BlinnClipper4D, ICloneable<Interface32>, IClipper4D, IInsideTester4D, Interface31, Interface32
  {
    private readonly List<BlinnClipper4D.ClipPlane> list_0;

    internal Class808(ICollection<BlinnClipper4D.ClipPlane> clipPlanes)
      : base(clipPlanes)
    {
      this.list_0 = new List<BlinnClipper4D.ClipPlane>((IEnumerable<BlinnClipper4D.ClipPlane>) clipPlanes);
    }

    public void imethod_0(Matrix4D transform)
    {
      Matrix4D inverse = transform.GetInverse();
      inverse.Transpose();
      foreach (BlinnClipper4D.ClipPlane clipPlane in this.list_0)
        clipPlane.TransformBy(transform, inverse);
    }

    public Interface32 Clone()
    {
      List<BlinnClipper4D.ClipPlane> clipPlaneList = new List<BlinnClipper4D.ClipPlane>(this.list_0.Count);
      foreach (BlinnClipper4D.ClipPlane clipPlane in this.list_0)
        clipPlaneList.Add(clipPlane.Clone());
      return (Interface32) new Class808((ICollection<BlinnClipper4D.ClipPlane>) clipPlaneList);
    }
  }
}
