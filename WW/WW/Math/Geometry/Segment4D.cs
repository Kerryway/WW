// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Segment4D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Math.Geometry
{
  [Serializable]
  public struct Segment4D
  {
    private Vector4D start;
    private Vector4D end;

    public Segment4D(Vector4D start, Vector4D end)
    {
      this.start = start;
      this.end = end;
    }

    public Segment4D(
      double startx,
      double starty,
      double startz,
      double startw,
      double endx,
      double endy,
      double endz,
      double endw)
    {
      this.start = new Vector4D(startx, starty, startz, startw);
      this.end = new Vector4D(endx, endy, endz, endw);
    }

    public Vector4D Start
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

    public Vector4D End
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

    public Vector4D GetCenter()
    {
      return new Vector4D(0.5 * (this.start.X + this.end.X), 0.5 * (this.start.Y + this.end.Y), 0.5 * (this.start.Z + this.end.Z), 0.5 * (this.start.W + this.end.W));
    }

    public Vector4D GetDelta()
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
      if (obj is Segment4D)
        return this == (Segment4D) obj;
      return false;
    }

    public static bool operator ==(Segment4D a, Segment4D b)
    {
      if (a.Start == b.Start)
        return a.End == b.End;
      return false;
    }

    public static bool operator !=(Segment4D a, Segment4D b)
    {
      if (a.Start == b.End)
        return !(a.Start == b.End);
      return true;
    }
  }
}
