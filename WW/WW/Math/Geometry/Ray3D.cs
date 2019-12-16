// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Ray3D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Math.Geometry
{
  [Serializable]
  public struct Ray3D
  {
    private Point3D origin;
    private Vector3D direction;

    public Ray3D(Point3D origin, Vector3D direction)
    {
      this.origin = origin;
      this.direction = direction;
    }

    public Ray3D(
      double startX,
      double startY,
      double startZ,
      double directionX,
      double directionY,
      double directionZ)
    {
      this.origin = new Point3D(startX, startY, startZ);
      this.direction = new Vector3D(directionX, directionY, directionZ);
    }

    public Vector3D Direction
    {
      get
      {
        return this.direction;
      }
      set
      {
        this.direction = value;
      }
    }

    public Point3D Origin
    {
      get
      {
        return this.origin;
      }
      set
      {
        this.origin = value;
      }
    }

    public override string ToString()
    {
      return string.Format("origin: {0}, direction: {1}", (object) this.origin.ToString(), (object) this.direction.ToString());
    }
  }
}
