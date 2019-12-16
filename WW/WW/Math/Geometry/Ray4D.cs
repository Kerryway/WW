// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Ray4D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Math.Geometry
{
  [Serializable]
  public struct Ray4D
  {
    private Vector4D origin;
    private Vector4D direction;

    public Ray4D(Vector4D origin, Vector4D direction)
    {
      this.origin = origin;
      this.direction = direction;
    }

    public Ray4D(
      double startX,
      double startY,
      double startZ,
      double startW,
      double directionX,
      double directionY,
      double directionZ,
      double directionW)
    {
      this.origin = new Vector4D(startX, startY, startZ, startW);
      this.direction = new Vector4D(directionX, directionY, directionZ, directionW);
    }

    public Vector4D Direction
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

    public Vector4D Origin
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
