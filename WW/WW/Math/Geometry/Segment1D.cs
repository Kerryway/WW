// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Segment1D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;

namespace WW.Math.Geometry
{
  [Serializable]
  public struct Segment1D
  {
    private double start;
    private double end;

    public Segment1D(double start, double end)
    {
      this.start = start;
      this.end = end;
    }

    public double Start
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

    public double End
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

    public double GetCenter()
    {
      return 0.5 * (this.start + this.end);
    }

    public bool OverlapsExclusive(Segment1D other)
    {
      if (this.end > other.start)
        return other.end > this.start;
      return false;
    }

    public bool OverlapsInclusive(Segment1D other)
    {
      if (this.end >= other.start)
        return other.end >= this.start;
      return false;
    }

    public bool ContainsInclusive(double d)
    {
      if (d >= this.start)
        return d <= this.end;
      return false;
    }

    public bool ContainsExclusive(double d)
    {
      if (d > this.start)
        return d < this.end;
      return false;
    }

    public static bool OverlapsExclusive(Segment1D segment1, Segment1D segment2)
    {
      if (segment1.end > segment2.start)
        return segment2.end > segment1.start;
      return false;
    }

    public static bool OverlapsInclusive(Segment1D segment1, Segment1D segment2)
    {
      if (segment1.end >= segment2.start)
        return segment2.end >= segment1.start;
      return false;
    }

    public static IList<Segment1D> GetDifference(
      IList<Segment1D> segments,
      IList<Segment1D> toBeSubtractedSegments)
    {
      List<Segment1D> segment1DList = new List<Segment1D>();
      foreach (Segment1D segment in (IEnumerable<Segment1D>) segments)
      {
        List<double> doubleList = new List<double>();
        doubleList.Add(segment.start);
        doubleList.Add(segment.end);
        foreach (Segment1D subtractedSegment in (IEnumerable<Segment1D>) toBeSubtractedSegments)
        {
          if (segment.ContainsExclusive(subtractedSegment.start) && !doubleList.Contains(subtractedSegment.start))
            doubleList.Add(subtractedSegment.start);
          if (segment.ContainsExclusive(subtractedSegment.end) && !doubleList.Contains(subtractedSegment.end))
            doubleList.Add(subtractedSegment.end);
        }
        doubleList.Sort();
        double start = doubleList[0];
        for (int index = 1; index < doubleList.Count; ++index)
        {
          double end = doubleList[index];
          Segment1D segment1D = new Segment1D(start, end);
          double center = segment1D.GetCenter();
          bool flag = false;
          foreach (Segment1D subtractedSegment in (IEnumerable<Segment1D>) toBeSubtractedSegments)
          {
            if (subtractedSegment.ContainsExclusive(center))
            {
              flag = true;
              break;
            }
          }
          if (!flag)
            segment1DList.Add(segment1D);
          start = end;
        }
      }
      return (IList<Segment1D>) segment1DList;
    }
  }
}
