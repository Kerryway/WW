// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.BlinnClipper4D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;

namespace WW.Math.Geometry
{
  public class BlinnClipper4D : AbstractClipperBase4D
  {
    private static readonly BlinnClipper4D.IInsideTester[] iinsideTester_0 = new BlinnClipper4D.IInsideTester[4]{ BlinnClipper4D.Class163.Class166.iinsideTester_0, BlinnClipper4D.Class163.Class167.iinsideTester_0, BlinnClipper4D.Class163.Class165.iinsideTester_0, BlinnClipper4D.Class163.Class164.iinsideTester_0 };
    private readonly BlinnClipper4D.IInsideTester[] iinsideTester_1;

    public BlinnClipper4D(bool clipFront, bool clipBack)
    {
      this.iinsideTester_1 = new BlinnClipper4D.IInsideTester[this.method_0(clipFront, clipBack)];
      int num = 0;
      if (clipFront)
        this.iinsideTester_1[num++] = BlinnClipper4D.Class163.Class169.iinsideTester_0;
      if (clipBack)
        this.iinsideTester_1[num++] = BlinnClipper4D.Class163.Class168.iinsideTester_0;
      for (int index = 0; index < BlinnClipper4D.iinsideTester_0.Length; ++index)
        this.iinsideTester_1[num++] = BlinnClipper4D.iinsideTester_0[index];
    }

    private int method_0(bool clipFront, bool clipBack)
    {
      int num = 4;
      if (clipFront)
        ++num;
      if (clipBack)
        ++num;
      return num;
    }

    public BlinnClipper4D(
      double left,
      double right,
      double bottom,
      double top,
      double back,
      double front,
      bool clipBack,
      bool clipFront)
    {
      this.iinsideTester_1 = new BlinnClipper4D.IInsideTester[this.method_0(clipFront, clipBack)];
      int num1 = 0;
      if (clipFront)
        this.iinsideTester_1[num1++] = (BlinnClipper4D.IInsideTester) new BlinnClipper4D.Class170.Class176(front);
      if (clipBack)
        this.iinsideTester_1[num1++] = (BlinnClipper4D.IInsideTester) new BlinnClipper4D.Class170.Class175(back);
      BlinnClipper4D.IInsideTester[] iinsideTester1_1 = this.iinsideTester_1;
      int index1 = num1;
      int num2 = index1 + 1;
      BlinnClipper4D.Class170.Class173 class173 = new BlinnClipper4D.Class170.Class173(right);
      iinsideTester1_1[index1] = (BlinnClipper4D.IInsideTester) class173;
      BlinnClipper4D.IInsideTester[] iinsideTester1_2 = this.iinsideTester_1;
      int index2 = num2;
      int num3 = index2 + 1;
      BlinnClipper4D.Class170.Class174 class174 = new BlinnClipper4D.Class170.Class174(left);
      iinsideTester1_2[index2] = (BlinnClipper4D.IInsideTester) class174;
      BlinnClipper4D.IInsideTester[] iinsideTester1_3 = this.iinsideTester_1;
      int index3 = num3;
      int num4 = index3 + 1;
      BlinnClipper4D.Class170.Class172 class172 = new BlinnClipper4D.Class170.Class172(bottom);
      iinsideTester1_3[index3] = (BlinnClipper4D.IInsideTester) class172;
      BlinnClipper4D.IInsideTester[] iinsideTester1_4 = this.iinsideTester_1;
      int index4 = num4;
      int num5 = index4 + 1;
      BlinnClipper4D.Class170.Class171 class171 = new BlinnClipper4D.Class170.Class171(top);
      iinsideTester1_4[index4] = (BlinnClipper4D.IInsideTester) class171;
    }

    public BlinnClipper4D(
      ICollection<BlinnClipper4D.IInsideTester> insideTesters)
    {
      this.iinsideTester_1 = new BlinnClipper4D.IInsideTester[insideTesters.Count];
      int num = 0;
      foreach (BlinnClipper4D.IInsideTester insideTester in (IEnumerable<BlinnClipper4D.IInsideTester>) insideTesters)
        this.iinsideTester_1[num++] = insideTester;
    }

    public BlinnClipper4D(ICollection<BlinnClipper4D.ClipPlane> clipPlanes)
    {
      this.iinsideTester_1 = new BlinnClipper4D.IInsideTester[clipPlanes.Count];
      int num = 0;
      foreach (BlinnClipper4D.IInsideTester clipPlane in (IEnumerable<BlinnClipper4D.ClipPlane>) clipPlanes)
        this.iinsideTester_1[num++] = clipPlane;
    }

    public override bool IsInside(Vector4D point)
    {
      for (int index = 0; index < this.iinsideTester_1.Length; ++index)
      {
        if (!this.iinsideTester_1[index].IsInside(point))
          return false;
      }
      return true;
    }

    public override InsideTestResult TryIsInside(Bounds3D bounds)
    {
      if (!bounds.Initialized)
        return InsideTestResult.None;
      return this.Check((IList<Vector4D>) BlinnClipper4D.smethod_3(bounds));
    }

    public BlinnClipper4D.IInsideTester[] InsideTesters
    {
      get
      {
        return this.iinsideTester_1;
      }
    }

    public Segment4D? ClipConvex(Segment4D segment)
    {
      Segment4D? nullable = new Segment4D?(segment);
      for (int index = 0; index < this.iinsideTester_1.Length; ++index)
      {
        nullable = BlinnClipper4D.smethod_4(nullable.Value, this.iinsideTester_1[index]);
        if (!nullable.HasValue)
          break;
      }
      return nullable;
    }

    public Segment4D? ClipConvex(Segment4D segment, out bool clipped)
    {
      Segment4D? nullable = new Segment4D?(segment);
      clipped = false;
      for (int index = 0; index < this.iinsideTester_1.Length; ++index)
      {
        bool clipped1;
        nullable = BlinnClipper4D.smethod_5(nullable.Value, this.iinsideTester_1[index], out clipped1);
        if (clipped1)
        {
          clipped = true;
          if (!nullable.HasValue)
            break;
        }
      }
      return nullable;
    }

    public override IList<Segment4D> Clip(Segment4D segment)
    {
      Segment4D? nullable = new Segment4D?(segment);
      for (int index = 0; index < this.iinsideTester_1.Length; ++index)
      {
        nullable = BlinnClipper4D.smethod_4(nullable.Value, this.iinsideTester_1[index]);
        if (!nullable.HasValue)
          break;
      }
      if (!nullable.HasValue)
        return AbstractClipperBase4D.SegmentClippedAway;
      return (IList<Segment4D>) new Segment4D[1]{ nullable.Value };
    }

    public override IList<Polyline4D> Clip(Polyline4D polyline, bool filled)
    {
      if (polyline.Closed && filled)
      {
        Polyline4D polyline1 = polyline;
        for (int index = 0; index < this.iinsideTester_1.Length; ++index)
        {
          polyline1 = BlinnClipper4D.smethod_0(polyline1, this.iinsideTester_1[index]);
          if (polyline1.Count == 0)
            break;
        }
        if (polyline1.Count == 0)
          return AbstractClipperBase4D.PolylinesClippedAway;
        return (IList<Polyline4D>) new Polyline4D[1]{ polyline1 };
      }
      IList<Polyline4D> polyline4DList1 = (IList<Polyline4D>) new Polyline4D[1]{ polyline };
      for (int index1 = 0; index1 < this.iinsideTester_1.Length; ++index1)
      {
        if (polyline4DList1.Count == 1)
        {
          polyline4DList1 = BlinnClipper4D.smethod_1(polyline4DList1[0], filled, this.iinsideTester_1[index1]);
        }
        else
        {
          List<Polyline4D> polyline4DList2 = (List<Polyline4D>) null;
          for (int index2 = 0; index2 < polyline4DList1.Count; ++index2)
          {
            IList<Polyline4D> polyline4DList3 = BlinnClipper4D.smethod_1(polyline4DList1[index2], filled, this.iinsideTester_1[index1]);
            if (polyline4DList3.Count > 0)
            {
              if (polyline4DList2 == null)
                polyline4DList2 = new List<Polyline4D>();
              polyline4DList2.AddRange((IEnumerable<Polyline4D>) polyline4DList3);
            }
          }
          polyline4DList1 = (IList<Polyline4D>) polyline4DList2;
        }
        if (polyline4DList1 == null)
        {
          polyline4DList1 = AbstractClipperBase4D.PolylinesClippedAway;
          break;
        }
      }
      return polyline4DList1;
    }

        public void Clip(Polyline4D polyline, bool filled, Action<Polyline4D> addClippedPolyline)
        {
            if ((int)this.iinsideTester_1.Length == 4)
            {
                BlinnClipper4D.smethod_2(polyline, filled, this.iinsideTester_1[0], (Polyline4D o1) => BlinnClipper4D.smethod_2(o1, filled, this.iinsideTester_1[1], (Polyline4D o2) => BlinnClipper4D.smethod_2(o2, filled, this.iinsideTester_1[2], (Polyline4D o3) => BlinnClipper4D.smethod_2(o3, filled, this.iinsideTester_1[3], addClippedPolyline))));
                return;
            }
            if ((int)this.iinsideTester_1.Length == 5)
            {
                BlinnClipper4D.smethod_2(polyline, filled, this.iinsideTester_1[0], (Polyline4D o1) => BlinnClipper4D.smethod_2(o1, filled, this.iinsideTester_1[1], (Polyline4D o2) => BlinnClipper4D.smethod_2(o2, filled, this.iinsideTester_1[2], (Polyline4D o3) => BlinnClipper4D.smethod_2(o3, filled, this.iinsideTester_1[3], (Polyline4D o4) => BlinnClipper4D.smethod_2(o4, filled, this.iinsideTester_1[4], addClippedPolyline)))));
                return;
            }
            BlinnClipper4D.smethod_2(polyline, filled, this.iinsideTester_1[0], (Polyline4D o1) => BlinnClipper4D.smethod_2(o1, filled, this.iinsideTester_1[1], (Polyline4D o2) => BlinnClipper4D.smethod_2(o2, filled, this.iinsideTester_1[2], (Polyline4D o3) => BlinnClipper4D.smethod_2(o3, filled, this.iinsideTester_1[3], (Polyline4D o4) => BlinnClipper4D.smethod_2(o4, filled, this.iinsideTester_1[4], (Polyline4D o5) => BlinnClipper4D.smethod_2(o5, filled, this.iinsideTester_1[5], addClippedPolyline))))));
        }

        internal InsideTestResult method_1(Matrix4D transform, Bounds3D bounds)
    {
      if (!bounds.Initialized)
        return InsideTestResult.None;
      Vector4D[] vector4DArray = BlinnClipper4D.smethod_3(bounds);
      for (int index = 0; index < vector4DArray.Length; ++index)
        vector4DArray[index] = transform.Transform(vector4DArray[index]);
      return this.Check((IList<Vector4D>) vector4DArray);
    }

    public InsideTestResult Check(IList<Vector4D> points)
    {
      InsideTestResult insideTestResult1 = InsideTestResult.None;
      for (int index1 = 0; index1 < this.iinsideTester_1.Length; ++index1)
      {
        InsideTestResult insideTestResult2 = InsideTestResult.None;
        BlinnClipper4D.IInsideTester insideTester = this.iinsideTester_1[index1];
        for (int index2 = 0; index2 < points.Count; ++index2)
        {
          if (insideTester.IsInside(points[index2]))
            insideTestResult2 |= InsideTestResult.Inside;
          else
            insideTestResult2 |= InsideTestResult.Outside;
          if (insideTestResult2 == InsideTestResult.BothSides)
            break;
        }
        if (insideTestResult2 == InsideTestResult.Outside)
          return insideTestResult2;
        insideTestResult1 |= insideTestResult2;
      }
      return insideTestResult1;
    }

    private static unsafe Polyline4D smethod_0(
      Polyline4D polyline,
      BlinnClipper4D.IInsideTester insideTester)
    {
      Polyline4D polyline4D;
      if (polyline.Count < 2)
      {
        if (polyline.Count == 1)
        {
          Vector4D p = polyline[0];
          polyline4D = !insideTester.IsInside(p) ? new Polyline4D(0) : polyline;
        }
        else
          polyline4D = polyline;
      }
      else
      {
        int count = polyline.Count;
        bool* flagPtr1 = stackalloc bool[count];
        int num = 0;
        bool* flagPtr2 = flagPtr1;
        for (int index = 0; index < count; ++index)
        {
          bool flag = insideTester.IsInside(polyline[index]);
          *flagPtr2++ = flag;
          if (flag)
            ++num;
        }
        if (num == 0)
          return new Polyline4D(0);
        if (num == count)
        {
          polyline4D = polyline;
        }
        else
        {
          polyline4D = new Polyline4D(count, polyline.Closed);
          bool* flagPtr3 = flagPtr1;
          Vector4D vector4D1 = polyline[0];
          bool* flagPtr4 = flagPtr3;
          bool* flagPtr5 = flagPtr4 + 1;
          bool flag1;
          if (flag1 = *flagPtr4)
            polyline4D.Add(vector4D1);
          for (int index = 1; index < count; ++index)
          {
            Vector4D vector4D2 = polyline[index];
            bool flag2 = *flagPtr5++;
            if (flag1)
            {
              if (flag2)
                polyline4D.Add(vector4D2);
              else
                polyline4D.Add(insideTester.GetIntersection(vector4D1, vector4D2));
            }
            else if (flag2)
            {
              polyline4D.Add(insideTester.GetIntersection(vector4D2, vector4D1));
              polyline4D.Add(vector4D2);
            }
            flag1 = flag2;
            vector4D1 = vector4D2;
          }
          if (polyline.Closed)
          {
            Vector4D vector4D2 = polyline[0];
            bool flag2 = flagPtr1[0];
            if (flag1)
            {
              if (!flag2)
                polyline4D.Add(insideTester.GetIntersection(vector4D1, vector4D2));
            }
            else if (flag2)
              polyline4D.Add(insideTester.GetIntersection(vector4D2, vector4D1));
          }
        }
      }
      return polyline4D;
    }

    private static unsafe IList<Polyline4D> smethod_1(
      Polyline4D polyline,
      bool filled,
      BlinnClipper4D.IInsideTester insideTester)
    {
      if (polyline.Count < 2)
      {
        if (polyline.Count == 1)
        {
          Vector4D p = polyline[0];
          if (!insideTester.IsInside(p))
            return AbstractClipperBase4D.PolylinesClippedAway;
          return (IList<Polyline4D>) new Polyline4D[1]{ polyline };
        }
        return (IList<Polyline4D>) new Polyline4D[1]{ polyline };
      }
      int count = polyline.Count;
      bool* flagPtr1 = stackalloc bool[count];
      int num = 0;
      bool* flagPtr2 = flagPtr1;
      int index1 = -1;
      int index2;
      for (index2 = 0; index2 < count; ++index2)
      {
        bool flag = insideTester.IsInside(polyline[index2]);
        *flagPtr2++ = flag;
        if (flag)
        {
          ++num;
        }
        else
        {
          index1 = index2;
          ++index2;
          break;
        }
      }
      for (; index2 < count; ++index2)
      {
        bool flag = insideTester.IsInside(polyline[index2]);
        *flagPtr2++ = flag;
        if (flag)
          ++num;
      }
      if (num == 0)
        return AbstractClipperBase4D.PolylinesClippedAway;
      if (num == count)
        return (IList<Polyline4D>) new Polyline4D[1]{ polyline };
      List<Polyline4D> polyline4DList = (List<Polyline4D>) null;
      if (filled && polyline.Closed)
      {
        Polyline4D polyline4D = new Polyline4D(count, true);
        bool* flagPtr3 = flagPtr1;
        Vector4D vector4D1 = polyline[0];
        bool* flagPtr4 = flagPtr3;
        bool* flagPtr5 = flagPtr4 + 1;
        bool flag1;
        if (flag1 = *flagPtr4)
          polyline4D.Add(vector4D1);
        for (int index3 = 1; index3 < count; ++index3)
        {
          Vector4D vector4D2 = polyline[index3];
          bool flag2 = *flagPtr5++;
          if (flag1)
          {
            if (flag2)
              polyline4D.Add(vector4D2);
            else
              polyline4D.Add(insideTester.GetIntersection(vector4D1, vector4D2));
          }
          else if (flag2)
          {
            polyline4D.Add(insideTester.GetIntersection(vector4D2, vector4D1));
            polyline4D.Add(vector4D2);
          }
          flag1 = flag2;
          vector4D1 = vector4D2;
        }
        Vector4D vector4D3 = polyline[0];
        bool flag3 = flagPtr1[0];
        if (flag1)
        {
          if (!flag3)
            polyline4D.Add(insideTester.GetIntersection(vector4D1, vector4D3));
        }
        else if (flag3)
          polyline4D.Add(insideTester.GetIntersection(vector4D3, vector4D1));
        if (polyline4DList == null)
          polyline4DList = new List<Polyline4D>();
        polyline4DList.Add(polyline4D);
      }
      else if (polyline.Closed)
      {
        Polyline4D polyline4D = new Polyline4D(count, false);
        Vector4D vector4D1 = polyline[index1];
        bool flag1 = flagPtr1[index1];
        for (int index3 = 1; index3 < count; ++index3)
        {
          int index4 = (index3 + index1) % count;
          Vector4D vector4D2 = polyline[index4];
          bool flag2 = flagPtr1[index4];
          if (flag1)
          {
            if (flag2)
            {
              polyline4D.Add(vector4D2);
            }
            else
            {
              polyline4D.Add(insideTester.GetIntersection(vector4D1, vector4D2));
              if (polyline4DList == null)
                polyline4DList = new List<Polyline4D>();
              polyline4DList.Add(polyline4D);
              polyline4D = new Polyline4D(false);
            }
          }
          else if (flag2)
          {
            polyline4D.Add(insideTester.GetIntersection(vector4D2, vector4D1));
            polyline4D.Add(vector4D2);
          }
          flag1 = flag2;
          vector4D1 = vector4D2;
        }
        if (flag1)
        {
          Vector4D p2 = polyline[index1];
          polyline4D.Add(insideTester.GetIntersection(vector4D1, p2));
        }
        if (polyline4D.Count > 0)
        {
          if (polyline4DList == null)
            polyline4DList = new List<Polyline4D>();
          polyline4DList.Add(polyline4D);
        }
      }
      else
      {
        Polyline4D polyline4D = new Polyline4D(count, false);
        Vector4D vector4D1 = polyline[0];
        bool* flagPtr3 = flagPtr1;
        bool* flagPtr4 = flagPtr3 + 1;
        bool flag1;
        if (flag1 = *flagPtr3)
          polyline4D.Add(vector4D1);
        for (int index3 = 1; index3 < count; ++index3)
        {
          Vector4D vector4D2 = polyline[index3];
          bool flag2 = *flagPtr4++;
          if (flag1)
          {
            if (flag2)
            {
              polyline4D.Add(vector4D2);
            }
            else
            {
              polyline4D.Add(insideTester.GetIntersection(vector4D1, vector4D2));
              if (polyline4DList == null)
                polyline4DList = new List<Polyline4D>();
              polyline4DList.Add(polyline4D);
              polyline4D = new Polyline4D(false);
            }
          }
          else if (flag2)
          {
            polyline4D.Add(insideTester.GetIntersection(vector4D2, vector4D1));
            polyline4D.Add(vector4D2);
          }
          flag1 = flag2;
          vector4D1 = vector4D2;
        }
        if (polyline4D.Count > 0)
        {
          if (polyline4DList == null)
            polyline4DList = new List<Polyline4D>();
          polyline4DList.Add(polyline4D);
        }
      }
      return (IList<Polyline4D>) polyline4DList;
    }

    private static unsafe void smethod_2(
      Polyline4D polyline,
      bool filled,
      BlinnClipper4D.IInsideTester insideTester,
      Action<Polyline4D> addClippedPolyline)
    {
      if (polyline.Count < 2)
      {
        if (polyline.Count == 1)
        {
          Vector4D p = polyline[0];
          if (!insideTester.IsInside(p))
            return;
          addClippedPolyline(polyline);
        }
        else
          addClippedPolyline(polyline);
      }
      else
      {
        int count = polyline.Count;
        bool* flagPtr1 = stackalloc bool[count];
        int num = 0;
        bool* flagPtr2 = flagPtr1;
        int index1 = -1;
        int index2;
        for (index2 = 0; index2 < count; ++index2)
        {
          bool flag = insideTester.IsInside(polyline[index2]);
          *flagPtr2++ = flag;
          if (flag)
          {
            ++num;
          }
          else
          {
            index1 = index2;
            ++index2;
            break;
          }
        }
        for (; index2 < count; ++index2)
        {
          bool flag = insideTester.IsInside(polyline[index2]);
          *flagPtr2++ = flag;
          if (flag)
            ++num;
        }
        if (num == count)
          addClippedPolyline(polyline);
        else if (filled && polyline.Closed)
        {
          Polyline4D polyline4D = new Polyline4D(count, true);
          bool* flagPtr3 = flagPtr1;
          Vector4D vector4D1 = polyline[0];
          bool* flagPtr4 = flagPtr3;
          bool* flagPtr5 = flagPtr4 + 1;
          bool flag1;
          if (flag1 = *flagPtr4)
            polyline4D.Add(vector4D1);
          for (int index3 = 1; index3 < count; ++index3)
          {
            Vector4D vector4D2 = polyline[index3];
            bool flag2 = *flagPtr5++;
            if (flag1)
            {
              if (flag2)
                polyline4D.Add(vector4D2);
              else
                polyline4D.Add(insideTester.GetIntersection(vector4D1, vector4D2));
            }
            else if (flag2)
            {
              polyline4D.Add(insideTester.GetIntersection(vector4D2, vector4D1));
              polyline4D.Add(vector4D2);
            }
            flag1 = flag2;
            vector4D1 = vector4D2;
          }
          Vector4D vector4D3 = polyline[0];
          bool flag3 = flagPtr1[0];
          if (flag1)
          {
            if (!flag3)
              polyline4D.Add(insideTester.GetIntersection(vector4D1, vector4D3));
          }
          else if (flag3)
            polyline4D.Add(insideTester.GetIntersection(vector4D3, vector4D1));
          addClippedPolyline(polyline4D);
        }
        else if (polyline.Closed)
        {
          Polyline4D polyline4D = new Polyline4D(count, false);
          Vector4D vector4D1 = polyline[index1];
          bool flag1 = flagPtr1[index1];
          for (int index3 = 1; index3 < count; ++index3)
          {
            int index4 = (index3 + index1) % count;
            Vector4D vector4D2 = polyline[index4];
            bool flag2 = flagPtr1[index4];
            if (flag1)
            {
              if (flag2)
              {
                polyline4D.Add(vector4D2);
              }
              else
              {
                polyline4D.Add(insideTester.GetIntersection(vector4D1, vector4D2));
                addClippedPolyline(polyline4D);
                polyline4D = new Polyline4D(false);
              }
            }
            else if (flag2)
            {
              polyline4D.Add(insideTester.GetIntersection(vector4D2, vector4D1));
              polyline4D.Add(vector4D2);
            }
            flag1 = flag2;
            vector4D1 = vector4D2;
          }
          if (flag1)
          {
            Vector4D p2 = polyline[index1];
            polyline4D.Add(insideTester.GetIntersection(vector4D1, p2));
          }
          if (polyline4D.Count <= 0)
            return;
          addClippedPolyline(polyline4D);
        }
        else
        {
          Polyline4D polyline4D = new Polyline4D(count, false);
          Vector4D vector4D1 = polyline[0];
          bool* flagPtr3 = flagPtr1;
          bool* flagPtr4 = flagPtr3 + 1;
          bool flag1;
          if (flag1 = *flagPtr3)
            polyline4D.Add(vector4D1);
          for (int index3 = 1; index3 < count; ++index3)
          {
            Vector4D vector4D2 = polyline[index3];
            bool flag2 = *flagPtr4++;
            if (flag1)
            {
              if (flag2)
              {
                polyline4D.Add(vector4D2);
              }
              else
              {
                polyline4D.Add(insideTester.GetIntersection(vector4D1, vector4D2));
                addClippedPolyline(polyline4D);
                polyline4D = new Polyline4D(false);
              }
            }
            else if (flag2)
            {
              polyline4D.Add(insideTester.GetIntersection(vector4D2, vector4D1));
              polyline4D.Add(vector4D2);
            }
            flag1 = flag2;
            vector4D1 = vector4D2;
          }
          if (polyline4D.Count <= 0)
            return;
          addClippedPolyline(polyline4D);
        }
      }
    }

    internal static Vector4D[] smethod_3(Bounds3D bounds)
    {
      Point3D min = bounds.Min;
      Point3D max = bounds.Max;
      Vector3D vector3D = max - min;
      Vector4D[] vector4DArray;
      if (vector3D.X > 0.0)
      {
        if (vector3D.Y > 0.0)
        {
          if (vector3D.Z > 0.0)
            vector4DArray = new Vector4D[8]
            {
              new Vector4D(min.X, min.Y, min.Z, 1.0),
              new Vector4D(min.X, min.Y, max.Z, 1.0),
              new Vector4D(min.X, max.Y, min.Z, 1.0),
              new Vector4D(min.X, max.Y, max.Z, 1.0),
              new Vector4D(max.X, min.Y, min.Z, 1.0),
              new Vector4D(max.X, min.Y, max.Z, 1.0),
              new Vector4D(max.X, max.Y, min.Z, 1.0),
              new Vector4D(max.X, max.Y, max.Z, 1.0)
            };
          else
            vector4DArray = new Vector4D[4]
            {
              new Vector4D(min.X, min.Y, min.Z, 1.0),
              new Vector4D(min.X, max.Y, min.Z, 1.0),
              new Vector4D(max.X, min.Y, min.Z, 1.0),
              new Vector4D(max.X, max.Y, min.Z, 1.0)
            };
        }
        else if (vector3D.Z > 0.0)
          vector4DArray = new Vector4D[4]
          {
            new Vector4D(min.X, min.Y, min.Z, 1.0),
            new Vector4D(min.X, min.Y, max.Z, 1.0),
            new Vector4D(max.X, min.Y, min.Z, 1.0),
            new Vector4D(max.X, min.Y, max.Z, 1.0)
          };
        else
          vector4DArray = new Vector4D[2]
          {
            new Vector4D(min.X, min.Y, min.Z, 1.0),
            new Vector4D(max.X, min.Y, min.Z, 1.0)
          };
      }
      else if (vector3D.Y > 0.0)
      {
        if (vector3D.Z > 0.0)
          vector4DArray = new Vector4D[4]
          {
            new Vector4D(min.X, min.Y, min.Z, 1.0),
            new Vector4D(min.X, min.Y, max.Z, 1.0),
            new Vector4D(min.X, max.Y, min.Z, 1.0),
            new Vector4D(min.X, max.Y, max.Z, 1.0)
          };
        else
          vector4DArray = new Vector4D[2]
          {
            new Vector4D(min.X, min.Y, min.Z, 1.0),
            new Vector4D(min.X, max.Y, min.Z, 1.0)
          };
      }
      else if (vector3D.Z > 0.0)
        vector4DArray = new Vector4D[2]
        {
          new Vector4D(min.X, min.Y, min.Z, 1.0),
          new Vector4D(min.X, min.Y, max.Z, 1.0)
        };
      else
        vector4DArray = new Vector4D[1]
        {
          new Vector4D(min.X, min.Y, min.Z, 1.0)
        };
      return vector4DArray;
    }

    private static Segment4D? smethod_4(
      Segment4D segment,
      BlinnClipper4D.IInsideTester insideTester)
    {
      bool flag1 = insideTester.IsInside(segment.Start);
      bool flag2 = insideTester.IsInside(segment.End);
      if (flag1)
      {
        if (flag2)
          return new Segment4D?(segment);
        return new Segment4D?(new Segment4D(segment.Start, insideTester.GetIntersection(segment.Start, segment.End)));
      }
      if (flag2)
        return new Segment4D?(new Segment4D(insideTester.GetIntersection(segment.End, segment.Start), segment.End));
      return new Segment4D?();
    }

    private static Segment4D? smethod_5(
      Segment4D segment,
      BlinnClipper4D.IInsideTester insideTester,
      out bool clipped)
    {
      bool flag1 = insideTester.IsInside(segment.Start);
      bool flag2 = insideTester.IsInside(segment.End);
      if (flag1)
      {
        if (flag2)
        {
          clipped = false;
          return new Segment4D?(segment);
        }
        clipped = true;
        return new Segment4D?(new Segment4D(segment.Start, insideTester.GetIntersection(segment.Start, segment.End)));
      }
      if (flag2)
      {
        clipped = true;
        return new Segment4D?(new Segment4D(insideTester.GetIntersection(segment.End, segment.Start), segment.End));
      }
      clipped = true;
      return new Segment4D?();
    }

    public interface IInsideTester
    {
      bool IsInside(Vector4D p);

      Vector4D GetIntersection(Vector4D p1, Vector4D p2);

      Vector3D Normal { get; }

      double Distance { get; }
    }

    public class ClipPlane : WW.ICloneable<BlinnClipper4D.ClipPlane>, BlinnClipper4D.IInsideTester
    {
      private Vector4D vector4D_0;

      public ClipPlane(Vector3D normal, double dist)
      {
        normal.Normalize();
        this.vector4D_0 = new Vector4D(normal.X, normal.Y, normal.Z, -dist);
      }

      public ClipPlane(Vector3D normal, Point3D planePoint)
      {
        normal.Normalize();
        double num = Vector3D.DotProduct(normal, (Vector3D) planePoint);
        this.vector4D_0 = new Vector4D(normal.X, normal.Y, normal.Z, -num);
      }

      private ClipPlane(Vector4D planeDefinition)
      {
        this.vector4D_0 = planeDefinition;
      }

      public BlinnClipper4D.ClipPlane Clone()
      {
        return new BlinnClipper4D.ClipPlane(this.vector4D_0);
      }

      public bool IsInside(Vector4D p)
      {
        return Vector4D.DotProduct(this.vector4D_0, p) < 0.0;
      }

      public Vector4D GetIntersection(Vector4D p1, Vector4D p2)
      {
        double num1 = Vector4D.DotProduct(this.vector4D_0, p1);
        double num2 = Vector4D.DotProduct(this.vector4D_0, p2);
        double num3 = num1 - num2;
        double num4 = System.Math.Abs(num3) >= 8.88178419700125E-16 ? num1 / num3 : 0.5;
        return (1.0 - num4) * p1 + num4 * p2;
      }

      public Vector3D Normal
      {
        get
        {
          return new Vector3D(this.vector4D_0.X, this.vector4D_0.Y, this.vector4D_0.Z);
        }
      }

      public double Distance
      {
        get
        {
          return -this.vector4D_0.W;
        }
      }

      public void TransformBy(Matrix4D transform, Matrix4D inverseTransposedTransform)
      {
        Vector3D vector = new Vector3D(this.vector4D_0.X, this.vector4D_0.Y, this.vector4D_0.Z);
        Point3D point = (Point3D) (vector * -this.vector4D_0.W);
        Vector3D u = inverseTransposedTransform.Transform(vector);
        Point3D point3D = transform.Transform(point);
        u.Normalize();
        double num = Vector3D.DotProduct(u, (Vector3D) point3D);
        this.vector4D_0 = new Vector4D(u.X, u.Y, u.Z, -num);
      }

      public override string ToString()
      {
        return string.Format("Plane: {0}", (object) this.vector4D_0);
      }
    }

    internal sealed class Class163
    {
      internal sealed class Class164 : BlinnClipper4D.IInsideTester
      {
        public static readonly BlinnClipper4D.IInsideTester iinsideTester_0 = (BlinnClipper4D.IInsideTester) new BlinnClipper4D.Class163.Class164();

        private Class164()
        {
        }

        public bool IsInside(Vector4D p)
        {
          if (p.W > 0.0)
            return p.Y <= p.W;
          return p.Y >= p.W;
        }

        public Vector4D GetIntersection(Vector4D p1, Vector4D p2)
        {
          double num1 = p1.W - p1.Y;
          double num2 = p2.W - p2.Y;
          double num3 = num1 - num2;
          double num4 = System.Math.Abs(num3) >= 8.88178419700125E-16 ? num1 / num3 : 0.5;
          return (1.0 - num4) * p1 + num4 * p2;
        }

        public Vector3D Normal
        {
          get
          {
            return Vector3D.YAxis;
          }
        }

        public double Distance
        {
          get
          {
            return 1.0;
          }
        }
      }

      internal sealed class Class165 : BlinnClipper4D.IInsideTester
      {
        public static readonly BlinnClipper4D.IInsideTester iinsideTester_0 = (BlinnClipper4D.IInsideTester) new BlinnClipper4D.Class163.Class165();

        private Class165()
        {
        }

        public bool IsInside(Vector4D p)
        {
          if (p.W > 0.0)
            return p.Y >= 0.0;
          return p.Y <= 0.0;
        }

        public Vector4D GetIntersection(Vector4D p1, Vector4D p2)
        {
          double y1 = p1.Y;
          double y2 = p2.Y;
          double num1 = y1 - y2;
          double num2 = System.Math.Abs(num1) >= 8.88178419700125E-16 ? y1 / num1 : 0.5;
          return (1.0 - num2) * p1 + num2 * p2;
        }

        public Vector3D Normal
        {
          get
          {
            return -Vector3D.YAxis;
          }
        }

        public double Distance
        {
          get
          {
            return 0.0;
          }
        }
      }

      internal sealed class Class166 : BlinnClipper4D.IInsideTester
      {
        public static BlinnClipper4D.IInsideTester iinsideTester_0 = (BlinnClipper4D.IInsideTester) new BlinnClipper4D.Class163.Class166();

        private Class166()
        {
        }

        public bool IsInside(Vector4D p)
        {
          if (p.W > 0.0)
            return p.X <= p.W;
          return p.X >= p.W;
        }

        public Vector4D GetIntersection(Vector4D p1, Vector4D p2)
        {
          double num1 = p1.W - p1.X;
          double num2 = p2.W - p2.X;
          double num3 = num1 - num2;
          double num4 = System.Math.Abs(num3) >= 8.88178419700125E-16 ? num1 / num3 : 0.5;
          return (1.0 - num4) * p1 + num4 * p2;
        }

        public Vector3D Normal
        {
          get
          {
            return Vector3D.XAxis;
          }
        }

        public double Distance
        {
          get
          {
            return 1.0;
          }
        }
      }

      internal sealed class Class167 : BlinnClipper4D.IInsideTester
      {
        public static readonly BlinnClipper4D.IInsideTester iinsideTester_0 = (BlinnClipper4D.IInsideTester) new BlinnClipper4D.Class163.Class167();

        private Class167()
        {
        }

        public bool IsInside(Vector4D p)
        {
          if (p.W > 0.0)
            return p.X >= 0.0;
          return p.X <= 0.0;
        }

        public Vector4D GetIntersection(Vector4D p1, Vector4D p2)
        {
          double x1 = p1.X;
          double x2 = p2.X;
          double num1 = x1 - x2;
          double num2 = System.Math.Abs(num1) >= 8.88178419700125E-16 ? x1 / num1 : 0.5;
          return (1.0 - num2) * p1 + num2 * p2;
        }

        public Vector3D Normal
        {
          get
          {
            return -Vector3D.XAxis;
          }
        }

        public double Distance
        {
          get
          {
            return 1.0;
          }
        }
      }

      internal sealed class Class168 : BlinnClipper4D.IInsideTester
      {
        public static readonly BlinnClipper4D.IInsideTester iinsideTester_0 = (BlinnClipper4D.IInsideTester) new BlinnClipper4D.Class163.Class168();

        private Class168()
        {
        }

        public bool IsInside(Vector4D p)
        {
          if (p.W > 0.0)
            return p.Z >= 0.0;
          return p.Z <= 0.0;
        }

        public Vector4D GetIntersection(Vector4D p1, Vector4D p2)
        {
          double z1 = p1.Z;
          double z2 = p2.Z;
          double num1 = z1 - z2;
          double num2 = System.Math.Abs(num1) >= 8.88178419700125E-16 ? z1 / num1 : 0.5;
          return (1.0 - num2) * p1 + num2 * p2;
        }

        public Vector3D Normal
        {
          get
          {
            return -Vector3D.ZAxis;
          }
        }

        public double Distance
        {
          get
          {
            return 0.0;
          }
        }
      }

      internal sealed class Class169 : BlinnClipper4D.IInsideTester
      {
        public static readonly BlinnClipper4D.IInsideTester iinsideTester_0 = (BlinnClipper4D.IInsideTester) new BlinnClipper4D.Class163.Class169();

        private Class169()
        {
        }

        public bool IsInside(Vector4D p)
        {
          if (p.W > 0.0)
            return p.Z <= p.W;
          return false;
        }

        public Vector4D GetIntersection(Vector4D p1, Vector4D p2)
        {
          double num1;
          if (p2.W >= 0.0)
          {
            double num2 = p1.W - p1.Z;
            double num3 = p2.W - p2.Z;
            double num4 = num2 - num3;
            num1 = System.Math.Abs(num4) >= 8.88178419700125E-16 ? num2 / num4 : 0.5;
          }
          else
            num1 = (0.0001 - p1.W) / (p2.W - p1.W);
          return (1.0 - num1) * p1 + num1 * p2;
        }

        public Vector3D Normal
        {
          get
          {
            return Vector3D.ZAxis;
          }
        }

        public double Distance
        {
          get
          {
            return 1.0;
          }
        }
      }
    }

    internal sealed class Class170
    {
      internal sealed class Class171 : BlinnClipper4D.IInsideTester
      {
        private readonly double double_0;

        public Class171(double top)
        {
          this.double_0 = top;
        }

        public bool IsInside(Vector4D p)
        {
          if (p.W > 0.0)
            return p.Y <= this.double_0 * p.W;
          return p.Y >= this.double_0 * p.W;
        }

        public Vector4D GetIntersection(Vector4D p1, Vector4D p2)
        {
          double num1 = this.double_0 * p1.W - p1.Y;
          double num2 = this.double_0 * p2.W - p2.Y;
          double num3 = num1 - num2;
          double num4 = System.Math.Abs(num3) >= 8.88178419700125E-16 ? num1 / num3 : 0.5;
          return (1.0 - num4) * p1 + num4 * p2;
        }

        public Vector3D Normal
        {
          get
          {
            return Vector3D.YAxis;
          }
        }

        public double Distance
        {
          get
          {
            return this.double_0;
          }
        }
      }

      internal sealed class Class172 : BlinnClipper4D.IInsideTester
      {
        private readonly double double_0;

        public Class172(double bottom)
        {
          this.double_0 = bottom;
        }

        public bool IsInside(Vector4D p)
        {
          if (p.W > 0.0)
            return p.Y >= this.double_0 * p.W;
          return p.Y <= this.double_0 * p.W;
        }

        public Vector4D GetIntersection(Vector4D p1, Vector4D p2)
        {
          double num1 = this.double_0 * p1.W - p1.Y;
          double num2 = this.double_0 * p2.W - p2.Y;
          double num3 = num1 - num2;
          double num4 = System.Math.Abs(num3) >= 8.88178419700125E-16 ? num1 / num3 : 0.5;
          return (1.0 - num4) * p1 + num4 * p2;
        }

        public Vector3D Normal
        {
          get
          {
            return -Vector3D.YAxis;
          }
        }

        public double Distance
        {
          get
          {
            return -this.double_0;
          }
        }
      }

      internal sealed class Class173 : BlinnClipper4D.IInsideTester
      {
        private readonly double double_0;

        public Class173(double right)
        {
          this.double_0 = right;
        }

        public bool IsInside(Vector4D p)
        {
          if (p.W > 0.0)
            return p.X <= this.double_0 * p.W;
          return p.X >= this.double_0 * p.W;
        }

        public Vector4D GetIntersection(Vector4D p1, Vector4D p2)
        {
          double num1 = this.double_0 * p1.W - p1.X;
          double num2 = this.double_0 * p2.W - p2.X;
          double num3 = num1 - num2;
          double num4 = System.Math.Abs(num3) >= 8.88178419700125E-16 ? num1 / num3 : 0.5;
          return (1.0 - num4) * p1 + num4 * p2;
        }

        public Vector3D Normal
        {
          get
          {
            return Vector3D.XAxis;
          }
        }

        public double Distance
        {
          get
          {
            return this.double_0;
          }
        }
      }

      internal sealed class Class174 : BlinnClipper4D.IInsideTester
      {
        private readonly double double_0;

        public Class174(double left)
        {
          this.double_0 = left;
        }

        public bool IsInside(Vector4D p)
        {
          if (p.W > 0.0)
            return p.X >= this.double_0 * p.W;
          return p.X <= this.double_0 * p.W;
        }

        public Vector4D GetIntersection(Vector4D p1, Vector4D p2)
        {
          double num1 = this.double_0 * p1.W - p1.X;
          double num2 = this.double_0 * p2.W - p2.X;
          double num3 = num1 - num2;
          double num4 = System.Math.Abs(num3) >= 8.88178419700125E-16 ? num1 / num3 : 0.5;
          return (1.0 - num4) * p1 + num4 * p2;
        }

        public Vector3D Normal
        {
          get
          {
            return -Vector3D.XAxis;
          }
        }

        public double Distance
        {
          get
          {
            return -this.double_0;
          }
        }
      }

      internal sealed class Class175 : BlinnClipper4D.IInsideTester
      {
        private readonly double double_0;

        public Class175(double back)
        {
          this.double_0 = back;
        }

        public bool IsInside(Vector4D p)
        {
          if (p.W > 0.0)
            return p.Z >= this.double_0 * p.W;
          return p.Z <= this.double_0 * p.W;
        }

        public Vector4D GetIntersection(Vector4D p1, Vector4D p2)
        {
          double num1 = this.double_0 * p1.W - p1.Z;
          double num2 = this.double_0 * p2.W - p2.Z;
          double num3 = num1 - num2;
          double num4 = System.Math.Abs(num3) >= 8.88178419700125E-16 ? num1 / num3 : 0.5;
          return (1.0 - num4) * p1 + num4 * p2;
        }

        public Vector3D Normal
        {
          get
          {
            return -Vector3D.ZAxis;
          }
        }

        public double Distance
        {
          get
          {
            return -this.double_0;
          }
        }
      }

      internal sealed class Class176 : BlinnClipper4D.IInsideTester
      {
        private readonly double double_0;

        public Class176(double front)
        {
          this.double_0 = front;
        }

        public bool IsInside(Vector4D p)
        {
          if (p.W > 0.0)
            return p.Z <= this.double_0 * p.W;
          return false;
        }

        public Vector4D GetIntersection(Vector4D p1, Vector4D p2)
        {
          double num1;
          if (p2.W >= 0.0)
          {
            double num2 = this.double_0 * p1.W - p1.Z;
            double num3 = this.double_0 * p2.W - p2.Z;
            double num4 = num2 - num3;
            num1 = System.Math.Abs(num4) >= 8.88178419700125E-16 ? num2 / num4 : 0.5;
          }
          else
            num1 = (0.0001 - p1.W) / (p2.W - p1.W);
          return (1.0 - num1) * p1 + num1 * p2;
        }

        public Vector3D Normal
        {
          get
          {
            return Vector3D.ZAxis;
          }
        }

        public double Distance
        {
          get
          {
            return this.double_0;
          }
        }
      }
    }

    public class ClipPipeline
    {
      private BlinnClipper4D.IInsideTester[] iinsideTester_0;
      private BlinnClipper4D.ClipStepForFilledPolyline[] clipStepForFilledPolyline_0;
      private BlinnClipper4D.ClipStepForFilledPolyline clipStepForFilledPolyline_1;
      private BlinnClipper4D.ClipStepForFilledPolyline clipStepForFilledPolyline_2;
      private BlinnClipper4D.ClipStepForNotFilledPolyline[] clipStepForNotFilledPolyline_0;
      private BlinnClipper4D.ClipStepForNotFilledPolyline clipStepForNotFilledPolyline_1;
      private BlinnClipper4D.ClipStepForNotFilledPolyline clipStepForNotFilledPolyline_2;

      public ClipPipeline(bool clipFront, bool clipBack)
      {
        this.iinsideTester_0 = new BlinnClipper4D(clipFront, clipBack).iinsideTester_1;
        this.clipStepForFilledPolyline_0 = new BlinnClipper4D.ClipStepForFilledPolyline[this.iinsideTester_0.Length];
        this.clipStepForNotFilledPolyline_0 = new BlinnClipper4D.ClipStepForNotFilledPolyline[this.iinsideTester_0.Length];
        for (int index = 0; index < this.iinsideTester_0.Length; ++index)
        {
          this.clipStepForFilledPolyline_0[index] = new BlinnClipper4D.ClipStepForFilledPolyline(this.iinsideTester_0[index]);
          this.clipStepForNotFilledPolyline_0[index] = new BlinnClipper4D.ClipStepForNotFilledPolyline(this.iinsideTester_0[index]);
        }
        this.clipStepForFilledPolyline_1 = this.clipStepForFilledPolyline_0[0];
        this.clipStepForFilledPolyline_2 = this.clipStepForFilledPolyline_0[this.iinsideTester_0.Length - 1];
        this.clipStepForNotFilledPolyline_1 = this.clipStepForNotFilledPolyline_0[0];
        this.clipStepForNotFilledPolyline_2 = this.clipStepForNotFilledPolyline_0[this.iinsideTester_0.Length - 1];
        for (int index = 0; index < this.iinsideTester_0.Length - 1; ++index)
        {
          this.clipStepForFilledPolyline_0[index].AddClippedPolyline = new Action<Polyline4D>(this.clipStepForFilledPolyline_0[index + 1].Clip);
          this.clipStepForNotFilledPolyline_0[index].AddClippedPolyline = new Action<Polyline4D>(this.clipStepForNotFilledPolyline_0[index + 1].Clip);
        }
      }

      public void Clip(Polyline4D polyline, bool filled, Action<Polyline4D> addClippedPolyline)
      {
        if (filled)
        {
          this.clipStepForFilledPolyline_2.AddClippedPolyline = addClippedPolyline;
          this.clipStepForFilledPolyline_1.Clip(polyline);
        }
        else
        {
          this.clipStepForNotFilledPolyline_2.AddClippedPolyline = addClippedPolyline;
          this.clipStepForNotFilledPolyline_1.Clip(polyline);
        }
      }
    }

    public class ClipStepForNotFilledPolyline
    {
      private Polyline4D polyline4D_0 = new Polyline4D();
      private BlinnClipper4D.IInsideTester iinsideTester_0;
      private Action<Polyline4D> action_0;

      public ClipStepForNotFilledPolyline(BlinnClipper4D.IInsideTester insideTester)
      {
        this.iinsideTester_0 = insideTester;
      }

      public BlinnClipper4D.IInsideTester InsideTester
      {
        get
        {
          return this.iinsideTester_0;
        }
      }

      public Action<Polyline4D> AddClippedPolyline
      {
        get
        {
          return this.action_0;
        }
        set
        {
          this.action_0 = value;
        }
      }

      public unsafe void Clip(Polyline4D polyline)
      {
        if (polyline.Count < 2)
        {
          if (polyline.Count == 1)
          {
            if (!this.iinsideTester_0.IsInside(polyline[0]))
              return;
            this.action_0(polyline);
          }
          else
            this.action_0(polyline);
        }
        else
        {
          int count = polyline.Count;
          bool* flagPtr1 = stackalloc bool[count];
          int num = 0;
          bool* flagPtr2 = flagPtr1;
          int index1 = -1;
          int index2;
          for (index2 = 0; index2 < count; ++index2)
          {
            bool flag = this.iinsideTester_0.IsInside(polyline[index2]);
            *flagPtr2++ = flag;
            if (flag)
            {
              ++num;
            }
            else
            {
              index1 = index2;
              ++index2;
              break;
            }
          }
          for (; index2 < count; ++index2)
          {
            bool flag = this.iinsideTester_0.IsInside(polyline[index2]);
            *flagPtr2++ = flag;
            if (flag)
              ++num;
          }
          if (num == count)
            this.action_0(polyline);
          else if (polyline.Closed)
          {
            Vector4D vector4D1 = polyline[index1];
            bool flag1 = flagPtr1[index1];
            for (int index3 = 1; index3 < count; ++index3)
            {
              int index4 = (index3 + index1) % count;
              Vector4D vector4D2 = polyline[index4];
              bool flag2 = flagPtr1[index4];
              if (flag1)
              {
                if (flag2)
                {
                  this.polyline4D_0.Add(vector4D2);
                }
                else
                {
                  this.polyline4D_0.Add(this.iinsideTester_0.GetIntersection(vector4D1, vector4D2));
                  this.action_0(this.polyline4D_0);
                  this.polyline4D_0.Clear();
                }
              }
              else if (flag2)
              {
                this.polyline4D_0.Add(this.iinsideTester_0.GetIntersection(vector4D2, vector4D1));
                this.polyline4D_0.Add(vector4D2);
              }
              flag1 = flag2;
              vector4D1 = vector4D2;
            }
            if (flag1)
            {
              Vector4D p2 = polyline[index1];
              this.polyline4D_0.Add(this.iinsideTester_0.GetIntersection(vector4D1, p2));
            }
            if (this.polyline4D_0.Count <= 0)
              return;
            this.action_0(this.polyline4D_0);
            this.polyline4D_0.Clear();
          }
          else
          {
            Vector4D vector4D1 = polyline[0];
            bool* flagPtr3 = flagPtr1;
            bool* flagPtr4 = flagPtr3 + 1;
            bool flag1;
            if (flag1 = *flagPtr3)
              this.polyline4D_0.Add(vector4D1);
            for (int index3 = 1; index3 < count; ++index3)
            {
              Vector4D vector4D2 = polyline[index3];
              bool flag2 = *flagPtr4++;
              if (flag1)
              {
                if (flag2)
                {
                  this.polyline4D_0.Add(vector4D2);
                }
                else
                {
                  this.polyline4D_0.Add(this.iinsideTester_0.GetIntersection(vector4D1, vector4D2));
                  this.action_0(this.polyline4D_0);
                  this.polyline4D_0.Clear();
                }
              }
              else if (flag2)
              {
                this.polyline4D_0.Add(this.iinsideTester_0.GetIntersection(vector4D2, vector4D1));
                this.polyline4D_0.Add(vector4D2);
              }
              flag1 = flag2;
              vector4D1 = vector4D2;
            }
            if (this.polyline4D_0.Count <= 0)
              return;
            this.action_0(this.polyline4D_0);
            this.polyline4D_0.Clear();
          }
        }
      }
    }

    public class ClipStepForFilledPolyline
    {
      private Polyline4D polyline4D_0 = new Polyline4D();
      private BlinnClipper4D.IInsideTester iinsideTester_0;
      private Action<Polyline4D> action_0;

      public ClipStepForFilledPolyline(BlinnClipper4D.IInsideTester insideTester)
      {
        this.iinsideTester_0 = insideTester;
      }

      public BlinnClipper4D.IInsideTester InsideTester
      {
        get
        {
          return this.iinsideTester_0;
        }
      }

      public Action<Polyline4D> AddClippedPolyline
      {
        get
        {
          return this.action_0;
        }
        set
        {
          this.action_0 = value;
        }
      }

      public unsafe void Clip(Polyline4D polyline)
      {
        if (polyline.Count < 2)
        {
          if (polyline.Count == 1)
          {
            if (!this.iinsideTester_0.IsInside(polyline[0]))
              return;
            this.action_0(polyline);
          }
          else
            this.action_0(polyline);
        }
        else
        {
          int count = polyline.Count;
          bool* flagPtr1 = stackalloc bool[count];
          int num = 0;
          bool* flagPtr2 = flagPtr1;
          int index1;
          for (index1 = 0; index1 < count; ++index1)
          {
            bool flag = this.iinsideTester_0.IsInside(polyline[index1]);
            *flagPtr2++ = flag;
            if (flag)
            {
              ++num;
            }
            else
            {
              ++index1;
              break;
            }
          }
          for (; index1 < count; ++index1)
          {
            bool flag = this.iinsideTester_0.IsInside(polyline[index1]);
            *flagPtr2++ = flag;
            if (flag)
              ++num;
          }
          if (num == count)
            this.action_0(polyline);
          else if (polyline.Closed)
          {
            this.polyline4D_0.Closed = true;
            bool* flagPtr3 = flagPtr1;
            Vector4D vector4D1 = polyline[0];
            bool* flagPtr4 = flagPtr3;
            bool* flagPtr5 = flagPtr4 + 1;
            bool flag1;
            if (flag1 = *flagPtr4)
              this.polyline4D_0.Add(vector4D1);
            for (int index2 = 1; index2 < count; ++index2)
            {
              Vector4D vector4D2 = polyline[index2];
              bool flag2 = *flagPtr5++;
              if (flag1)
              {
                if (flag2)
                  this.polyline4D_0.Add(vector4D2);
                else
                  this.polyline4D_0.Add(this.iinsideTester_0.GetIntersection(vector4D1, vector4D2));
              }
              else if (flag2)
              {
                this.polyline4D_0.Add(this.iinsideTester_0.GetIntersection(vector4D2, vector4D1));
                this.polyline4D_0.Add(vector4D2);
              }
              flag1 = flag2;
              vector4D1 = vector4D2;
            }
            Vector4D vector4D3 = polyline[0];
            bool flag3 = flagPtr1[0];
            if (flag1)
            {
              if (!flag3)
                this.polyline4D_0.Add(this.iinsideTester_0.GetIntersection(vector4D1, vector4D3));
            }
            else if (flag3)
              this.polyline4D_0.Add(this.iinsideTester_0.GetIntersection(vector4D3, vector4D1));
            this.action_0(this.polyline4D_0);
            this.polyline4D_0.Clear();
          }
          else
          {
            this.polyline4D_0.Closed = false;
            Vector4D vector4D1 = polyline[0];
            bool* flagPtr3 = flagPtr1;
            bool* flagPtr4 = flagPtr3 + 1;
            bool flag1;
            if (flag1 = *flagPtr3)
              this.polyline4D_0.Add(vector4D1);
            for (int index2 = 1; index2 < count; ++index2)
            {
              Vector4D vector4D2 = polyline[index2];
              bool flag2 = *flagPtr4++;
              if (flag1)
              {
                if (flag2)
                {
                  this.polyline4D_0.Add(vector4D2);
                }
                else
                {
                  this.polyline4D_0.Add(this.iinsideTester_0.GetIntersection(vector4D1, vector4D2));
                  this.action_0(this.polyline4D_0);
                  this.polyline4D_0.Clear();
                }
              }
              else if (flag2)
              {
                this.polyline4D_0.Add(this.iinsideTester_0.GetIntersection(vector4D2, vector4D1));
                this.polyline4D_0.Add(vector4D2);
              }
              flag1 = flag2;
              vector4D1 = vector4D2;
            }
            if (this.polyline4D_0.Count <= 0)
              return;
            this.action_0(this.polyline4D_0);
            this.polyline4D_0.Clear();
          }
        }
      }
    }
  }
}
