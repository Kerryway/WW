// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Shape2DCollectionIterator
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;

namespace WW.Math.Geometry
{
  public class Shape2DCollectionIterator : ISegment2DIterator
  {
    private LinkedList<ISegment2DIterator> linkedList_0;
    private int int_0;
    private int int_1;
    private readonly bool bool_0;
    private bool bool_1;

    protected Shape2DCollectionIterator(bool connect)
    {
      this.bool_0 = connect;
    }

    public Shape2DCollectionIterator(IEnumerable<IShape2D> coll, bool connect)
      : this(connect)
    {
      this.linkedList_0 = new LinkedList<ISegment2DIterator>();
      foreach (IShape2D shape2D in coll)
      {
        ISegment2DIterator iterator = shape2D.CreateIterator();
        this.linkedList_0.AddLast(iterator);
        if (this.int_0 >= 0)
        {
          int totalSegmentCount = iterator.TotalSegmentCount;
          if (totalSegmentCount < 0)
            this.int_0 = -1;
          else
            this.int_0 += totalSegmentCount;
        }
        if (this.int_1 >= 0)
        {
          int totalPointCount = iterator.TotalPointCount;
          if (totalPointCount < 0)
            this.int_1 = -1;
          else
            this.int_1 += totalPointCount;
        }
      }
    }

    public static Shape2DCollectionIterator Create<T>(
      IEnumerable<T> coll,
      bool connect)
      where T : IShape2D
    {
      Shape2DCollectionIterator dcollectionIterator = new Shape2DCollectionIterator(false);
      dcollectionIterator.linkedList_0 = new LinkedList<ISegment2DIterator>();
      int num1 = 0;
      int num2 = 0;
      foreach (T obj in coll)
      {
        ISegment2DIterator iterator = obj.CreateIterator();
        dcollectionIterator.linkedList_0.AddLast(iterator);
        if (num1 >= 0)
        {
          int totalSegmentCount = iterator.TotalSegmentCount;
          if (totalSegmentCount < 0)
            num1 = -1;
          else
            num1 += totalSegmentCount;
        }
        if (num2 >= 0)
        {
          int totalPointCount = iterator.TotalPointCount;
          if (totalPointCount < 0)
            num2 = -1;
          else
            num2 += totalPointCount;
        }
      }
      dcollectionIterator.int_0 = num1;
      return dcollectionIterator;
    }

    public bool MoveNext()
    {
      if (this.linkedList_0.Count > 0)
      {
        if (this.linkedList_0.First.Value.MoveNext())
        {
          this.bool_1 = false;
          return true;
        }
        this.linkedList_0.RemoveFirst();
        this.bool_1 = this.bool_0;
      }
      while (this.linkedList_0.Count > 0)
      {
        if (this.linkedList_0.First.Value.MoveNext())
          return true;
        this.linkedList_0.RemoveFirst();
      }
      return false;
    }

    public SegmentType CurrentType
    {
      get
      {
        SegmentType segmentType = this.linkedList_0.First.Value.CurrentType;
        if (this.bool_1 && segmentType == SegmentType.MoveTo)
          segmentType = SegmentType.LineTo;
        return segmentType;
      }
    }

    public SegmentType Current(Point2D[] points, int offset)
    {
      SegmentType segmentType = this.linkedList_0.First.Value.Current(points, offset);
      if (this.bool_1 && segmentType == SegmentType.MoveTo)
        segmentType = SegmentType.LineTo;
      return segmentType;
    }

    public int TotalSegmentCount
    {
      get
      {
        return this.int_0;
      }
    }

    public int TotalPointCount
    {
      get
      {
        return this.int_1;
      }
    }
  }
}
