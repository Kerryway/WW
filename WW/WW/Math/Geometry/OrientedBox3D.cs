// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.OrientedBox3D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Math.Geometry
{
  [Serializable]
  public struct OrientedBox3D
  {
    public static readonly OrientedBox3D Empty = new OrientedBox3D(Point3D.Zero, Vector3D.Zero, Vector3D.Zero, Vector3D.Zero);
    public Point3D Origin;
    public Vector3D XAxis;
    public Vector3D YAxis;
    public Vector3D ZAxis;

    public OrientedBox3D(Point3D origin, Vector3D xaxis, Vector3D yaxis, Vector3D zaxis)
    {
      this.Origin = origin;
      this.XAxis = xaxis;
      this.YAxis = yaxis;
      this.ZAxis = zaxis;
    }
  }
}
