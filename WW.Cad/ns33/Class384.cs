// Decompiled with JetBrains decompiler
// Type: ns33.Class384
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;
using WW.Math.Geometry;

namespace ns33
{
  internal static class Class384
  {
    private static readonly IShape2D ishape2D_0 = (IShape2D) new Segment2D(0.0, 0.0, 0.0, 0.0);

    public static IShape2D CreateShape(PointDisplayMode pointDisplayMode, double size)
    {
      double num = 0.5 * size;
      switch (pointDisplayMode)
      {
        case PointDisplayMode.Point:
          return Class384.ishape2D_0;
        case PointDisplayMode.None:
          return (IShape2D) NullShape2D.Instance;
        case PointDisplayMode.PlusSign:
          GeneralShape2D result1 = new GeneralShape2D(4, 4);
          Class384.smethod_2(result1, size);
          result1.Fixate();
          return (IShape2D) result1;
        case PointDisplayMode.XSign:
          GeneralShape2D result2 = new GeneralShape2D(4, 4);
          Class384.smethod_3(result2, size);
          result2.Fixate();
          return (IShape2D) result2;
        case (PointDisplayMode) 4:
          GeneralShape2D result3 = new GeneralShape2D(4, 4);
          Class384.smethod_0(result3, num);
          result3.Fixate();
          return (IShape2D) result3;
        case (PointDisplayMode) 32:
          GeneralShape2D generalShape2D1 = new GeneralShape2D(7, 15);
          generalShape2D1.AddPoint(WW.Math.Point2D.Zero);
          generalShape2D1.AddCircleApproximation(WW.Math.Point2D.Zero, num);
          generalShape2D1.Fixate();
          return (IShape2D) generalShape2D1;
        case (PointDisplayMode) 33:
          GeneralShape2D generalShape2D2 = new GeneralShape2D(5, 13);
          generalShape2D2.AddCircleApproximation(WW.Math.Point2D.Zero, num);
          generalShape2D2.Fixate();
          return (IShape2D) generalShape2D2;
        case (PointDisplayMode) 34:
          GeneralShape2D result4 = new GeneralShape2D(9, 17);
          Class384.smethod_2(result4, size);
          result4.AddCircleApproximation(WW.Math.Point2D.Zero, num);
          result4.Fixate();
          return (IShape2D) result4;
        case (PointDisplayMode) 35:
          GeneralShape2D result5 = new GeneralShape2D(9, 17);
          Class384.smethod_3(result5, size);
          result5.AddCircleApproximation(WW.Math.Point2D.Zero, num);
          result5.Fixate();
          return (IShape2D) result5;
        case (PointDisplayMode) 36:
          GeneralShape2D result6 = new GeneralShape2D(7, 15);
          Class384.smethod_0(result6, num);
          result6.AddCircleApproximation(WW.Math.Point2D.Zero, num);
          result6.Fixate();
          return (IShape2D) result6;
        case (PointDisplayMode) 64:
          GeneralShape2D generalShape2D3 = new GeneralShape2D(6, 6);
          generalShape2D3.AddPoint(WW.Math.Point2D.Zero);
          generalShape2D3.AddSquare(WW.Math.Point2D.Zero, num);
          generalShape2D3.Fixate();
          return (IShape2D) generalShape2D3;
        case (PointDisplayMode) 65:
          GeneralShape2D generalShape2D4 = new GeneralShape2D(4, 4);
          generalShape2D4.AddSquare(WW.Math.Point2D.Zero, num);
          generalShape2D4.Fixate();
          return (IShape2D) generalShape2D4;
        case (PointDisplayMode) 66:
          GeneralShape2D result7 = new GeneralShape2D(8, 8);
          Class384.smethod_2(result7, size);
          result7.AddSquare(WW.Math.Point2D.Zero, num);
          result7.Fixate();
          return (IShape2D) result7;
        case (PointDisplayMode) 67:
          GeneralShape2D result8 = new GeneralShape2D(8, 8);
          Class384.smethod_3(result8, size);
          result8.AddSquare(WW.Math.Point2D.Zero, num);
          result8.Fixate();
          return (IShape2D) result8;
        case (PointDisplayMode) 68:
          GeneralShape2D result9 = new GeneralShape2D(7, 6);
          Class384.smethod_0(result9, num);
          result9.AddSquare(WW.Math.Point2D.Zero, num);
          result9.Fixate();
          return (IShape2D) result9;
        case (PointDisplayMode) 96:
          GeneralShape2D result10 = new GeneralShape2D(11, 19);
          result10.AddPoint(WW.Math.Point2D.Zero);
          Class384.smethod_1(result10, num);
          result10.Fixate();
          return (IShape2D) result10;
        case (PointDisplayMode) 97:
          GeneralShape2D result11 = new GeneralShape2D(9, 17);
          Class384.smethod_1(result11, num);
          result11.Fixate();
          return (IShape2D) result11;
        case (PointDisplayMode) 98:
          GeneralShape2D result12 = new GeneralShape2D(13, 21);
          Class384.smethod_2(result12, size);
          Class384.smethod_1(result12, num);
          result12.Fixate();
          return (IShape2D) result12;
        case (PointDisplayMode) 99:
          GeneralShape2D result13 = new GeneralShape2D(13, 21);
          Class384.smethod_3(result13, size);
          Class384.smethod_1(result13, num);
          result13.Fixate();
          return (IShape2D) result13;
        case (PointDisplayMode) 100:
          GeneralShape2D result14 = new GeneralShape2D(11, 19);
          Class384.smethod_0(result14, num);
          Class384.smethod_1(result14, num);
          result14.Fixate();
          return (IShape2D) result14;
        default:
          return Class384.ishape2D_0;
      }
    }

    private static void smethod_0(GeneralShape2D result, double halfSize)
    {
      result.MoveTo(0.0, 0.0);
      result.LineTo(0.0, halfSize);
    }

    private static void smethod_1(GeneralShape2D result, double halfSize)
    {
      result.AddSquare(WW.Math.Point2D.Zero, halfSize);
      result.AddCircleApproximation(WW.Math.Point2D.Zero, halfSize);
    }

    private static void smethod_2(GeneralShape2D result, double halfSize)
    {
      result.MoveTo(-halfSize, 0.0);
      result.LineTo(halfSize, 0.0);
      result.MoveTo(0.0, -halfSize);
      result.LineTo(0.0, halfSize);
    }

    private static void smethod_3(GeneralShape2D result, double halfSize)
    {
      double num = 0.5 * System.Math.Sqrt(2.0) * halfSize;
      result.MoveTo(-num, -num);
      result.LineTo(num, num);
      result.MoveTo(num, -num);
      result.LineTo(-num, num);
    }
  }
}
