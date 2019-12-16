// Decompiled with JetBrains decompiler
// Type: ns33.Class804
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Math;

namespace ns33
{
  internal static class Class804
  {
    private static readonly Point2D point2D_0 = new Point2D(double.NaN, double.NaN);
    private static readonly Matrix matrix_0 = new Matrix();

    public static void smethod_0(GraphicsPath targetPath, GraphicsPath addPath, Matrix trafo)
    {
      if (addPath.PointCount == 0)
        return;
      GraphicsPath addingPath = (GraphicsPath) addPath.Clone();
      addingPath.Transform(trafo);
      targetPath.AddPath(addingPath, false);
    }

    public static GraphicsPath smethod_1(GraphicsPath path, Matrix4D transform)
    {
      GraphicsPath graphicsPath = (GraphicsPath) path.Clone();
      RectangleF bounds = path.GetBounds();
      PointF[] destPoints = new PointF[4]{ bounds.Location, new PointF(bounds.Right, bounds.Top), new PointF(bounds.Left, bounds.Bottom), new PointF(bounds.Right, bounds.Bottom) };
      Point2D point = new Point2D();
      for (int index = 0; index < destPoints.Length; ++index)
      {
        point.X = (double) destPoints[index].X;
        point.Y = (double) destPoints[index].Y;
        point = transform.TransformTo2D(point);
        destPoints[index] = new PointF((float) point.X, (float) point.Y);
      }
      graphicsPath.Warp(destPoints, bounds, Class804.matrix_0, WarpMode.Perspective);
      return graphicsPath;
    }

    public static GraphicsPath smethod_2(GraphicsPath path, Matrix4D transform)
    {
      Point2D point = new Point2D();
      PointF[] pathPoints = path.PathPoints;
      for (int index = 0; index < pathPoints.Length; ++index)
      {
        PointF pointF = pathPoints[index];
        point.X = (double) pointF.X;
        point.Y = (double) pointF.Y;
        point = transform.TransformTo2D(point);
        pathPoints[index] = new PointF((float) point.X, (float) point.Y);
      }
      return new GraphicsPath(pathPoints, path.PathTypes, path.FillMode);
    }

    public static void smethod_3(Bounds3D bounds, GraphicsPath path, Matrix4D transform)
    {
      if (path.PointCount == 0)
        return;
      RectangleF bounds1 = path.GetBounds();
      PointF[] pointFArray = new PointF[4]{ bounds1.Location, new PointF(bounds1.Right, bounds1.Top), new PointF(bounds1.Left, bounds1.Bottom), new PointF(bounds1.Right, bounds1.Bottom) };
      Point3D point3D = new Point3D();
      for (int index = 3; index >= 0; --index)
      {
        point3D.X = (double) pointFArray[index].X;
        point3D.Y = (double) pointFArray[index].Y;
        point3D.Z = 0.0;
        point3D = transform.Transform(point3D);
        bounds.Update(point3D);
      }
    }
  }
}
