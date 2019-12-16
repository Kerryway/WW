// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Segment3D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Math.Geometry
{
  [Serializable]
  public struct Segment3D
  {
    private Point3D start;
    private Point3D end;

    public Segment3D(Point3D start, Point3D end)
    {
      this.start = start;
      this.end = end;
    }

    public Segment3D(
      double startx,
      double starty,
      double startz,
      double endx,
      double endy,
      double endz)
    {
      this.start = new Point3D(startx, starty, startz);
      this.end = new Point3D(endx, endy, endz);
    }

    public Point3D Start
    {
      get
      {
        return this.start;
      }
      set
      {
        this.start = value;
      }
    }

    public Point3D End
    {
      get
      {
        return this.end;
      }
      set
      {
        this.end = value;
      }
    }

    public Point3D GetCenter()
    {
      return new Point3D(0.5 * (this.start.X + this.end.X), 0.5 * (this.start.Y + this.end.Y), 0.5 * (this.start.Z + this.end.Z));
    }

    public Vector3D GetDelta()
    {
      return this.end - this.start;
    }

    public double GetLength()
    {
      return (this.end - this.start).GetLength();
    }

    public override string ToString()
    {
      return string.Format("start: {0}, end: {1}", (object) this.start.ToString(), (object) this.end.ToString());
    }

    public override int GetHashCode()
    {
      return this.start.GetHashCode() ^ this.end.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      if (obj is Segment3D)
        return this == (Segment3D) obj;
      return false;
    }

    public static bool operator ==(Segment3D a, Segment3D b)
    {
      if (a.Start == b.Start)
        return a.End == b.End;
      return false;
    }

    public static bool operator !=(Segment3D a, Segment3D b)
    {
      if (a.Start == b.End)
        return !(a.Start == b.End);
      return true;
    }
  }
}
