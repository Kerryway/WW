// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.ClipUtil
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;

namespace WW.Math.Geometry
{
  public static class ClipUtil
  {
    public static InsideTestResult IsInside(
      IClipper4D clipper,
      IShape4D shape,
      double shapeFlattenEpsilonForBoundsCalculation)
    {
      InsideTestResult insideTestResult = InsideTestResult.None;
      foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) shape.ToPolylines4D(shapeFlattenEpsilonForBoundsCalculation))
      {
        IList<Polyline4D> polyline4DList = clipper.Clip(polyline, shape.IsFilled);
        switch (polyline4DList.Count)
        {
          case 0:
            insideTestResult |= InsideTestResult.Outside;
            break;
          case 1:
            if (polyline == polyline4DList[0])
            {
              insideTestResult |= InsideTestResult.Inside;
              break;
            }
            insideTestResult = InsideTestResult.BothSides;
            break;
          default:
            insideTestResult = InsideTestResult.BothSides;
            break;
        }
        if (insideTestResult == InsideTestResult.BothSides)
          break;
      }
      return insideTestResult;
    }
  }
}
