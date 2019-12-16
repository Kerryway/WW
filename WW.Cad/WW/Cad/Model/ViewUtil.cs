// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.ViewUtil
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Base;
using WW.Cad.Model.Entities;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model
{
  public static class ViewUtil
  {
    public const double DefaultFocalLength = 50.0;
    public const double FilmImageWidth = 36.0;
    public const double FilmImageHeight = 24.0;

    public static Matrix4D GetTransform(
      IViewDescription view,
      Rectangle2D targetRectangle,
      bool invertY)
    {
      Matrix4D viewportTransform = ViewUtil.GetBasicModelToViewportTransform(view);
      double num = System.Math.Min(targetRectangle.Width * view.ViewportWidth / view.ViewWidth, targetRectangle.Height * view.ViewportHeight / view.ViewHeight);
      double x = targetRectangle.Center.X + (view.ViewportCenter.X - 0.5) * targetRectangle.Width;
      double y1 = targetRectangle.Center.Y;
      double y2 = !invertY ? y1 + (view.ViewportCenter.Y - 0.5) * targetRectangle.Height : y1 - (view.ViewportCenter.Y - 0.5) * targetRectangle.Height;
      return Transformation4D.Translation(x, y2, 0.0) * Transformation4D.Scaling(num, invertY ? -num : num, num) * viewportTransform;
    }

    public static Matrix4D GetTransform(
      IViewDescription view,
      Size2D targetSize,
      bool invertY)
    {
      return ViewUtil.GetTransform(view, new Rectangle2D(0.0, 0.0, targetSize.X, targetSize.Y), invertY);
    }

    public static Matrix4D GetTransform(
      IViewDescription view,
      double targetWidth,
      double targetHeight,
      bool invertY)
    {
      return ViewUtil.GetTransform(view, new Rectangle2D(0.0, 0.0, targetWidth, targetHeight), invertY);
    }

    public static Matrix4D GetBasicModelToViewportTransform(IViewDescription view)
    {
      Matrix4D matrix4D1 = view.IsTargetPaper ? Transformation4D.Translation(-view.ViewCenter.X, -view.ViewCenter.Y, 0.0) : Transformation4D.Translation(-view.ViewCenter.X, -view.ViewCenter.Y, -view.ViewDirection.GetLength()) * Transformation4D.RotateZ(view.ViewTwistAngle) * DxfUtil.GetToWCSTransform(view.ViewDirection).GetTranspose() * Transformation4D.Translation(-(Vector3D) view.ViewTarget);
      if ((view.ViewModeFlags & ViewportStatusFlags.PerspectiveMode) != ViewportStatusFlags.None)
      {
        double num1 = 1.0 / System.Math.Tan(0.5 * (2.0 * System.Math.Atan(18.0 / view.FocalLength)));
        double num2 = 0.5 * view.ViewWidth;
        Matrix4D matrix4D2 = new Matrix4D(num2, 0.0, 0.0, 0.0, 0.0, num2, 0.0, 0.0, 0.0, 0.0, -1.0, 0.0, 0.0, 0.0, -1.0, 0.0);
        matrix4D1 = Transformation4D.Scaling(num1, num1, 1.0) * matrix4D2 * matrix4D1;
      }
      return matrix4D1;
    }
  }
}
