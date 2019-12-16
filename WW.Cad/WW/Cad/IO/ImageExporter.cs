// Decompiled with JetBrains decompiler
// Type: WW.Cad.IO.ImageExporter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.GDI;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.IO
{
  public class ImageExporter
  {
    public const int Margin = 2;

    public static Bitmap CreateAutoSizedBitmap(
      GDIGraphics3D cadGraphics,
      SmoothingMode smoothingMode,
      Matrix4D transform)
    {
      return ImageExporter.CreateAutoSizedBitmap(cadGraphics, smoothingMode, transform, (System.Drawing.Color) cadGraphics.Config.BackColor);
    }

    public static Bitmap CreateAutoSizedBitmap(
      GDIGraphics3D cadGraphics,
      SmoothingMode smoothingMode,
      Matrix4D transform,
      System.Drawing.Color backColor)
    {
      transform = Transformation4D.Translation(2.0, 2.0, 0.0) * transform;
      Bounds3D bounds = new Bounds3D();
      cadGraphics.BoundingBox(bounds, transform);
      if (!bounds.Initialized)
        return ImageExporter.CreateEmptyBitmap(backColor, 1, 1);
      WW.Math.Vector3D delta = bounds.Delta;
      Matrix4D transform1 = DxfUtil.GetScaleTransform(bounds.Min, bounds.Max, new WW.Math.Point3D(2.0, delta.Y + 2.0, 0.0), new WW.Math.Point3D(delta.X + 2.0, 2.0, 0.0)) * transform;
      int width = (int) System.Math.Ceiling(delta.X) + 4;
      int height = (int) System.Math.Ceiling(delta.Y) + 4;
      return ImageExporter.CreateBitmap(cadGraphics, smoothingMode, transform1, backColor, width, height);
    }

    public static Bitmap CreateAutoSizedBitmap(GDIGraphics3D cadGraphics, Matrix4D transform)
    {
      return ImageExporter.CreateAutoSizedBitmap(cadGraphics, transform, (System.Drawing.Color) cadGraphics.Config.BackColor);
    }

    public static Bitmap CreateAutoSizedBitmap(
      GDIGraphics3D cadGraphics,
      Matrix4D transform,
      System.Drawing.Color backColor)
    {
      return ImageExporter.CreateAutoSizedBitmap(cadGraphics, SmoothingMode.AntiAlias, transform, backColor);
    }

    public static Bitmap CreateBitmap(
      GDIGraphics3D cadGraphics,
      SmoothingMode smoothingMode,
      Matrix4D transform,
      System.Drawing.Color backColor,
      int width,
      int height)
    {
      Bitmap bitmap = new Bitmap(width, height);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        graphics.SmoothingMode = smoothingMode;
        graphics.Clear(backColor);
        cadGraphics.Draw(graphics, new Rectangle(0, 0, width, height), transform, backColor);
      }
      return bitmap;
    }

    public static Bitmap CreateEmptyBitmap(System.Drawing.Color backColor, int width, int height)
    {
      Bitmap bitmap = new Bitmap(width, height);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
        graphics.Clear(backColor);
      return bitmap;
    }

    public static Bitmap CreateBitmap(
      GDIGraphics3D cadGraphics,
      Matrix4D transform,
      System.Drawing.Color backColor,
      int width,
      int height)
    {
      return ImageExporter.CreateBitmap(cadGraphics, SmoothingMode.AntiAlias, transform, backColor, width, height);
    }

    public static Bitmap CreateBitmap(
      GDIGraphics3D cadGraphics,
      SmoothingMode smoothingMode,
      Matrix4D transform,
      int width,
      int height)
    {
      Bitmap bitmap = new Bitmap(width, height);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        graphics.SmoothingMode = smoothingMode;
        graphics.Clear((System.Drawing.Color) cadGraphics.GraphicsConfig.BackColor);
        cadGraphics.Draw(graphics, new Rectangle(0, 0, width, height), transform);
      }
      return bitmap;
    }

    public static Bitmap CreateBitmap(
      GDIGraphics3D cadGraphics,
      Matrix4D transform,
      int width,
      int height)
    {
      return ImageExporter.CreateBitmap(cadGraphics, SmoothingMode.AntiAlias, transform, width, height);
    }

    public static Bitmap CreateBitmap(
      GDIGraphics3D cadGraphics,
      Matrix4D transform,
      System.Drawing.Color backColor,
      Size size)
    {
      return ImageExporter.CreateBitmap(cadGraphics, transform, backColor, size.Width, size.Height);
    }

    public static Bitmap CreateBitmap(
      GDIGraphics3D cadGraphics,
      Matrix4D transform,
      Size size)
    {
      return ImageExporter.CreateBitmap(cadGraphics, transform, size.Width, size.Height);
    }

    public static Bitmap CreateAutoSizedBitmap(
      DxfModel model,
      GDIGraphics3D cadGraphics,
      SmoothingMode smoothingMode,
      Matrix4D transform,
      Size maxSize)
    {
      return ImageExporter.CreateAutoSizedBitmap(model, cadGraphics, smoothingMode, transform, (System.Drawing.Color) cadGraphics.Config.BackColor, maxSize);
    }

    public static Bitmap CreateAutoSizedBitmap(
      DxfModel model,
      GDIGraphics3D cadGraphics,
      SmoothingMode smoothingMode,
      Matrix4D transform,
      System.Drawing.Color backColor,
      Size maxSize)
    {
      cadGraphics.CreateDrawables(model);
      Bounds3D bounds = new Bounds3D();
      cadGraphics.BoundingBox(bounds, transform);
      int num1 = maxSize.Width - 4;
      int num2 = maxSize.Height - 4;
      Matrix4D transform1 = DxfUtil.GetScaleTransform(bounds.Corner1, bounds.Corner2, new WW.Math.Point3D(bounds.Corner1.X, bounds.Corner2.Y, 0.0), new WW.Math.Point3D(0.0, (double) num2, 0.0), new WW.Math.Point3D((double) num1, 0.0, 0.0), new WW.Math.Point3D(2.0, 2.0, 0.0)) * transform;
      bounds.Reset();
      cadGraphics.BoundingBox(bounds, transform1);
      if (!bounds.Initialized)
        return ImageExporter.CreateEmptyBitmap(backColor, maxSize.Width, maxSize.Height);
      WW.Math.Vector3D delta = bounds.Delta;
      int width = System.Math.Min(maxSize.Width, (int) System.Math.Ceiling(delta.X) + 4);
      int height = System.Math.Min(maxSize.Height, (int) System.Math.Ceiling(delta.Y) + 4);
      return ImageExporter.CreateBitmap(cadGraphics, smoothingMode, transform1, backColor, width, height);
    }

    public static Bitmap CreateAutoSizedBitmap(
      DxfModel model,
      GDIGraphics3D cadGraphics,
      Matrix4D transform,
      Size maxSize)
    {
      return ImageExporter.CreateAutoSizedBitmap(model, cadGraphics, SmoothingMode.AntiAlias, transform, (System.Drawing.Color) cadGraphics.Config.BackColor, maxSize);
    }

    public static Bitmap CreateAutoSizedBitmap(
      DxfModel model,
      GDIGraphics3D cadGraphics,
      Matrix4D transform,
      System.Drawing.Color backColor,
      Size maxSize)
    {
      return ImageExporter.CreateAutoSizedBitmap(model, cadGraphics, SmoothingMode.AntiAlias, transform, backColor, maxSize);
    }

    public static Bitmap CreateAutoSizedBitmap(
      DxfModel model,
      Matrix4D transform,
      GraphicsConfig graphicsConfig,
      SmoothingMode smoothingMode)
    {
      BoundsCalculator boundsCalculator = new BoundsCalculator(graphicsConfig);
      boundsCalculator.GetBounds(model, transform);
      Bounds3D bounds = boundsCalculator.Bounds;
      if (!bounds.Initialized)
        return ImageExporter.CreateEmptyBitmap((System.Drawing.Color) graphicsConfig.BackColor, 1, 1);
      WW.Math.Vector3D delta = bounds.Delta;
      Matrix4D transform1 = DxfUtil.GetScaleTransform(bounds.Min, bounds.Max, new WW.Math.Point3D(2.0, delta.Y + 2.0, 0.0), new WW.Math.Point3D(delta.X + 2.0, 2.0, 0.0)) * transform;
      int width = (int) System.Math.Ceiling(delta.X) + 4;
      int height = (int) System.Math.Ceiling(delta.Y) + 4;
      return ImageExporter.CreateBitmap(model, transform1, graphicsConfig, smoothingMode, width, height);
    }

    public static Bitmap CreateAutoSizedBitmap(
      DxfModel model,
      Matrix4D transform,
      GraphicsConfig graphicsConfig)
    {
      return ImageExporter.CreateAutoSizedBitmap(model, transform, graphicsConfig, SmoothingMode.AntiAlias);
    }

    public static Bitmap CreateBitmap(
      DxfModel model,
      Matrix4D transform,
      GraphicsConfig graphicsConfig,
      SmoothingMode smoothingMode,
      int width,
      int height)
    {
      Bitmap bitmap = new Bitmap(width, height);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        graphics.SmoothingMode = smoothingMode;
        graphics.Clear((System.Drawing.Color) graphicsConfig.BackColor);
        GDIGraphics3D gdiGraphics3D = new GDIGraphics3D(graphicsConfig);
        gdiGraphics3D.CreateDrawables(model);
        gdiGraphics3D.Draw(graphics, new Rectangle(0, 0, width, height), transform);
      }
      return bitmap;
    }

    public static Bitmap CreateBitmap(
      DxfModel model,
      Matrix4D transform,
      GraphicsConfig graphicsConfig,
      int width,
      int height)
    {
      return ImageExporter.CreateBitmap(model, transform, graphicsConfig, SmoothingMode.AntiAlias, width, height);
    }

    public static Bitmap CreateBitmap(
      DxfModel model,
      Matrix4D transform,
      GraphicsConfig graphicsConfig,
      SmoothingMode smoothingMode,
      Size size)
    {
      return ImageExporter.CreateBitmap(model, transform, graphicsConfig, smoothingMode, size.Width, size.Height);
    }

    public static Bitmap CreateBitmap(
      DxfModel model,
      Matrix4D transform,
      GraphicsConfig graphicsConfig,
      Size size)
    {
      return ImageExporter.CreateBitmap(model, transform, graphicsConfig, SmoothingMode.AntiAlias, size);
    }

    public static Bitmap CreateViewportConfigurationBitmap(
      DxfModel model,
      string vportName,
      GraphicsConfig graphicsConfig,
      SmoothingMode smoothingMode,
      int width,
      int height)
    {
      Bitmap bitmap = new Bitmap(width, height);
      Rectangle2D targetRectangle = new Rectangle2D(0.0, 0.0, (double) width, (double) height);
      Rectangle drawingBounds = new Rectangle(0, 0, width, height);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        graphics.SmoothingMode = smoothingMode;
        graphics.Clear((System.Drawing.Color) graphicsConfig.BackColor);
        GDIGraphics3D gdiGraphics3D = new GDIGraphics3D(graphicsConfig);
        gdiGraphics3D.CreateDrawables(model);
        foreach (DxfVPort vport in (DxfHandledObjectCollection<DxfVPort>) model.VPorts)
        {
          if (vportName.Equals(vport.Name, StringComparison.InvariantCultureIgnoreCase))
          {
            IViewDescription viewDescription = vport.ViewDescription;
            Matrix4D transform = ViewUtil.GetTransform(viewDescription, targetRectangle, true);
            float num = 1f - (float) (viewDescription.ViewportCenter.Y + viewDescription.ViewportHeight / 2.0);
            RectangleF rect = new RectangleF((float) width * (float) (viewDescription.ViewportCenter.X - viewDescription.ViewportWidth / 2.0), (float) height * num, (float) width * (float) viewDescription.ViewportWidth, (float) height * (float) viewDescription.ViewportHeight);
            graphics.Clip = new System.Drawing.Region(rect);
            gdiGraphics3D.Draw(graphics, drawingBounds, transform);
          }
        }
      }
      return bitmap;
    }

    public static Bitmap CreateAutoSizedBitmap(
      DxfModel model,
      Matrix4D transform,
      GraphicsConfig graphicsConfig,
      SmoothingMode smoothingMode,
      Size maxSize)
    {
      BoundsCalculator boundsCalculator = new BoundsCalculator(graphicsConfig);
      boundsCalculator.GetBounds(model, transform);
      Bounds3D bounds = boundsCalculator.Bounds;
      if (!bounds.Initialized)
        return ImageExporter.CreateEmptyBitmap((System.Drawing.Color) graphicsConfig.BackColor, maxSize.Width, maxSize.Height);
      int num1 = maxSize.Width - 4;
      int num2 = maxSize.Height - 4;
      Matrix4D scaleTransform = DxfUtil.GetScaleTransform(bounds.Corner1, bounds.Corner2, new WW.Math.Point3D(bounds.Corner1.X, bounds.Corner2.Y, 0.0), new WW.Math.Point3D(0.0, (double) num2, 0.0), new WW.Math.Point3D((double) num1, 0.0, 0.0), new WW.Math.Point3D(2.0, 2.0, 0.0));
      Matrix4D transform1 = scaleTransform * transform;
      WW.Math.Vector3D vector3D = scaleTransform.Transform(bounds.Corner2) - scaleTransform.Transform(bounds.Corner1);
      int width = System.Math.Min(maxSize.Width, (int) System.Math.Ceiling(System.Math.Abs(vector3D.X)) + 4);
      int height = System.Math.Min(maxSize.Height, (int) System.Math.Ceiling(System.Math.Abs(vector3D.Y)) + 4);
      return ImageExporter.CreateBitmap(model, transform1, graphicsConfig, smoothingMode, width, height);
    }

    public static Bitmap CreateAutoSizedBitmap(
      DxfModel model,
      Matrix4D transform,
      GraphicsConfig graphicsConfig,
      Size maxSize)
    {
      return ImageExporter.CreateAutoSizedBitmap(model, transform, graphicsConfig, SmoothingMode.AntiAlias, maxSize);
    }

    public static Bitmap CreateAutoSizedBitmap(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      Matrix4D transform,
      GraphicsConfig graphicsConfig,
      SmoothingMode smoothingMode)
    {
      BoundsCalculator boundsCalculator = new BoundsCalculator(graphicsConfig);
      boundsCalculator.GetBounds(model, layout, viewports, transform);
      Bounds3D bounds = boundsCalculator.Bounds;
      if (!bounds.Initialized)
        return ImageExporter.CreateEmptyBitmap((System.Drawing.Color) graphicsConfig.BackColor, 1, 1);
      WW.Math.Vector3D delta = bounds.Delta;
      Matrix4D transform1 = DxfUtil.GetScaleTransform(bounds.Min, bounds.Max, new WW.Math.Point3D(2.0, delta.Y + 2.0, 0.0), new WW.Math.Point3D(delta.X + 2.0, 2.0, 0.0)) * transform;
      int width = (int) System.Math.Ceiling(delta.X) + 4;
      int height = (int) System.Math.Ceiling(delta.Y) + 4;
      return ImageExporter.CreateBitmap(model, layout, viewports, transform1, graphicsConfig, smoothingMode, width, height);
    }

    public static Bitmap CreateAutoSizedBitmap(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      Matrix4D transform,
      GraphicsConfig graphicsConfig)
    {
      return ImageExporter.CreateAutoSizedBitmap(model, layout, viewports, transform, graphicsConfig, SmoothingMode.AntiAlias);
    }

    public static Bitmap CreateBitmap(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      Matrix4D transform,
      GraphicsConfig graphicsConfig,
      SmoothingMode smoothingMode,
      int width,
      int height)
    {
      Bitmap bitmap = new Bitmap(width, height);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        graphics.SmoothingMode = smoothingMode;
        graphics.Clear((System.Drawing.Color) graphicsConfig.BackColor);
        GDIGraphics3D gdiGraphics3D = new GDIGraphics3D(graphicsConfig);
        gdiGraphics3D.CreateDrawables(model, layout, viewports);
        gdiGraphics3D.Draw(graphics, new Rectangle(0, 0, width, height), transform);
      }
      return bitmap;
    }

    public static Bitmap CreateBitmap(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      Matrix4D transform,
      GraphicsConfig graphicsConfig,
      int width,
      int height)
    {
      return ImageExporter.CreateBitmap(model, layout, viewports, transform, graphicsConfig, SmoothingMode.AntiAlias, width, height);
    }

    public static Bitmap CreateBitmap(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      Matrix4D transform,
      GraphicsConfig graphicsConfig,
      Size size)
    {
      return ImageExporter.CreateBitmap(model, layout, viewports, transform, graphicsConfig, size.Width, size.Height);
    }

    public static Bitmap CreateAutoSizedBitmap(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      Matrix4D transform,
      GraphicsConfig graphicsConfig,
      SmoothingMode smoothingMode,
      Size maxSize)
    {
      return ImageExporter.CreateAutoSizedBitmap(model, layout, viewports, transform, graphicsConfig, smoothingMode, (System.Drawing.Color) graphicsConfig.BackColor, maxSize);
    }

    public static Bitmap CreateAutoSizedBitmap(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      Matrix4D transform,
      GraphicsConfig graphicsConfig,
      SmoothingMode smoothingMode,
      System.Drawing.Color backColor,
      Size maxSize)
    {
      BoundsCalculator boundsCalculator = new BoundsCalculator(graphicsConfig);
      boundsCalculator.GetBounds(model, layout, viewports, transform);
      Bounds3D bounds = boundsCalculator.Bounds;
      if (!bounds.Initialized)
        return ImageExporter.CreateEmptyBitmap(backColor, maxSize.Width, maxSize.Height);
      int num1 = maxSize.Width - 4;
      int num2 = maxSize.Height - 4;
      Matrix4D scaleTransform = DxfUtil.GetScaleTransform(bounds.Corner1, bounds.Corner2, new WW.Math.Point3D(bounds.Corner1.X, bounds.Corner2.Y, 0.0), new WW.Math.Point3D(0.0, (double) num2, 0.0), new WW.Math.Point3D((double) num1, 0.0, 0.0), new WW.Math.Point3D(2.0, 2.0, 0.0));
      Matrix4D to2DTransform = scaleTransform * transform;
      WW.Math.Vector3D vector3D = scaleTransform.Transform(bounds.Corner2) - scaleTransform.Transform(bounds.Corner1);
      int width = System.Math.Min(maxSize.Width, (int) System.Math.Ceiling(System.Math.Abs(vector3D.X)) + 4);
      int height = System.Math.Min(maxSize.Height, (int) System.Math.Ceiling(System.Math.Abs(vector3D.Y)) + 4);
      return ImageExporter.CreateBitmap(model, layout, viewports, graphicsConfig, smoothingMode, backColor, to2DTransform, width, height);
    }

    public static Bitmap CreateAutoSizedBitmap(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      Matrix4D transform,
      GraphicsConfig graphicsConfig,
      Size maxSize)
    {
      return ImageExporter.CreateAutoSizedBitmap(model, layout, viewports, transform, graphicsConfig, (System.Drawing.Color) graphicsConfig.BackColor, maxSize);
    }

    public static Bitmap CreateAutoSizedBitmap(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      Matrix4D transform,
      GraphicsConfig graphicsConfig,
      System.Drawing.Color backColor,
      Size maxSize)
    {
      return ImageExporter.CreateAutoSizedBitmap(model, layout, viewports, transform, graphicsConfig, SmoothingMode.AntiAlias, backColor, maxSize);
    }

    public static Bitmap CreateBitmap(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig graphicsConfig,
      SmoothingMode smoothingMode,
      System.Drawing.Color backColor,
      Matrix4D to2DTransform,
      int width,
      int height)
    {
      Bitmap bitmap = new Bitmap(width, height);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        graphics.SmoothingMode = smoothingMode;
        graphics.Clear(backColor);
        if (layout.PaperSpace)
        {
          GraphicsConfig config = (GraphicsConfig) graphicsConfig.Clone();
          double length = to2DTransform.Transform(WW.Math.Vector3D.XAxis).GetLength();
          config.DotsPerInch = length * layout.GetLineWeightUnitsToPaperUnits() * 2540.0;
          GDIGraphics3D gdiGraphics3D = new GDIGraphics3D(config);
          gdiGraphics3D.CreateDrawables(model, layout, viewports);
          gdiGraphics3D.Draw(graphics, new Rectangle(0, 0, width, height), to2DTransform);
        }
        else
        {
          GDIGraphics3D gdiGraphics3D = new GDIGraphics3D(graphicsConfig);
          gdiGraphics3D.CreateDrawables(model);
          gdiGraphics3D.Draw(graphics, new Rectangle(0, 0, width, height), to2DTransform);
        }
      }
      return bitmap;
    }

    public static Bitmap CreateBitmap(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig graphicsConfig,
      System.Drawing.Color backColor,
      Matrix4D to2DTransform,
      int width,
      int height)
    {
      return ImageExporter.CreateBitmap(model, layout, viewports, graphicsConfig, SmoothingMode.AntiAlias, backColor, to2DTransform, width, height);
    }

    public static Bitmap CreateBitmap(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig graphicsConfig,
      System.Drawing.Color backColor,
      Matrix4D to2DTransform,
      Size size)
    {
      return ImageExporter.CreateBitmap(model, layout, viewports, graphicsConfig, backColor, to2DTransform, size.Width, size.Height);
    }

    public static Bitmap CreatePlotLayoutBitmap(
      Size maxSize,
      DxfModel model,
      DxfLayout layout,
      DxfViewportCollection viewports,
      GraphicsConfig config,
      SmoothingMode smoothingMode)
    {
      DxfLayout.PlotInfo plotInfo = layout.GetPlotInfo((double) maxSize.Width, (double) maxSize.Height, new Rectangle2D(0.0, 0.0, (double) (maxSize.Width - 1), (double) (maxSize.Height - 1)), false, true);
      Size size;
      Matrix4D to2DTransform;
      if (plotInfo != null)
      {
        Rectangle2D printableArea = plotInfo.PrintableArea;
        size = new Size((int) System.Math.Ceiling(printableArea.Width), (int) System.Math.Ceiling(printableArea.Height));
        WW.Math.Point2D center = printableArea.Center;
        to2DTransform = Transformation4D.Translation((WW.Math.Vector3D) (new WW.Math.Point2D(0.5 * (double) (size.Width - 1), 0.5 * (double) (size.Height - 1)) - center)) * plotInfo.ToPaperTransform;
      }
      else
      {
        BoundsCalculator boundsCalculator = new BoundsCalculator();
        boundsCalculator.GetBounds(model, layout);
        Bounds3D bounds = boundsCalculator.Bounds;
        if (!bounds.Initialized)
          return (Bitmap) null;
        WW.Math.Point3D min = bounds.Min;
        WW.Math.Point3D max = bounds.Max;
        WW.Math.Vector3D vector3D = max - min;
        WW.Math.Point3D point3D = new WW.Math.Point3D(min.X, min.Y, 0.0);
        double scaling;
        to2DTransform = DxfUtil.GetScaleTransform(point3D, new WW.Math.Point3D(max.X, min.Y, 0.0), point3D, WW.Math.Point3D.Zero, new WW.Math.Point3D((double) (maxSize.Width - 1), (double) (maxSize.Height - 1), 0.0), WW.Math.Point3D.Zero, out scaling);
        size = new Size((int) System.Math.Ceiling(vector3D.X * scaling), (int) System.Math.Ceiling(vector3D.Y * scaling));
      }
      return ImageExporter.CreateBitmap(model, layout, (ICollection<DxfViewport>) viewports, config, smoothingMode, (System.Drawing.Color) config.BackColor, to2DTransform, size.Width, size.Height);
    }

    public static void EncodeImageToJpeg(Image image, Stream output)
    {
      ImageExporter.EncodeImageToJpeg(image, output, 90L);
    }

    public static void EncodeImageToJpeg(Image image, Stream output, long quality)
    {
      EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, quality);
      EncoderParameters encoderParameters = new EncoderParameters(1);
      encoderParameters.Param[0] = encoderParameter;
      ImageExporter.EncodeImage(image, output, "image/jpeg", encoderParameters);
    }

    public static void EncodeImageToTiff(Image image, Stream output)
    {
      ImageExporter.EncodeImage(image, output, "image/tiff", (EncoderParameters) null);
    }

    public static void EncodeImageToGif(Image image, Stream output)
    {
      ImageExporter.EncodeImage(image, output, "image/gif", (EncoderParameters) null);
    }

    public static void EncodeImageToPng(Image image, Stream output)
    {
      ImageExporter.EncodeImage(image, output, "image/png", (EncoderParameters) null);
    }

    public static void EncodeImageToBmp(Image image, Stream output)
    {
      ImageExporter.EncodeImage(image, output, "image/bmp", (EncoderParameters) null);
    }

    public static void EncodeImage(
      Image image,
      Stream output,
      string encoderMimeType,
      EncoderParameters encoderParameters)
    {
      ImageCodecInfo encoderInfo = ImageExporter.GetEncoderInfo(encoderMimeType);
      image.Save(output, encoderInfo, encoderParameters);
    }

    public static ImageCodecInfo GetEncoderInfo(string encoderMimeType)
    {
      ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
      for (int index = 0; index < imageEncoders.Length; ++index)
      {
        if (imageEncoders[index].MimeType == encoderMimeType)
          return imageEncoders[index];
      }
      return (ImageCodecInfo) null;
    }
  }
}
