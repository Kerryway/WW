// Decompiled with JetBrains decompiler
// Type: ns4.Class666
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Math;

namespace ns4
{
  internal static class Class666
  {
    internal static IList<Class908> smethod_0(
      string text,
      double height,
      DxfTextStyle style,
      double widthFactor,
      Color color,
      short lineWeight,
      Matrix4D insertionTransformation,
      Class985 resultLayoutInfo,
      Enum24 whiteSpaceHandlingFlags)
    {
      return Class666.smethod_1(text, 0.0, height, AttachmentPoint.MiddleLeft, 1.0, LineSpacingStyle.Exact, style, widthFactor, color, DrawingDirection.LeftToRight, lineWeight, insertionTransformation, resultLayoutInfo, whiteSpaceHandlingFlags);
    }

    internal static IList<Class908> smethod_1(
      string text,
      double width,
      double height,
      AttachmentPoint attachmentPoint,
      double lineSpacingFactor,
      LineSpacingStyle lineSpacingStyle,
      DxfTextStyle style,
      double widthFactor,
      Color color,
      DrawingDirection drawingDirection,
      short lineWeight,
      Matrix4D insertionTransformation,
      Class985 resultLayoutInfo,
      Enum24 whiteSpaceHandlingFlags)
    {
      Class1023[] class1023Array = Class594.smethod_12(text, width, height, attachmentPoint, lineSpacingFactor, lineSpacingStyle, style, widthFactor, color, drawingDirection);
      Vector2D zero = Vector2D.Zero;
      IList<Class908> class908List = (IList<Class908>) new List<Class908>();
      Bounds2D bounds = new Bounds2D();
      foreach (Class1023 class1023 in class1023Array)
      {
        class1023.imethod_0(ref zero, class1023.Settings.Height, whiteSpaceHandlingFlags);
        bounds.Update(class1023.GetBounds(whiteSpaceHandlingFlags, resultLayoutInfo));
      }
      double num1 = 0.0;
      double num2 = 0.0;
      if (bounds.Initialized)
      {
        switch (attachmentPoint)
        {
          case AttachmentPoint.TopLeft:
            num1 = -bounds.Corner1.X;
            num2 = -bounds.Corner2.Y;
            break;
          case AttachmentPoint.TopCenter:
            num1 = -bounds.Center.X;
            num2 = -bounds.Corner2.Y;
            break;
          case AttachmentPoint.TopRight:
            num1 = -bounds.Corner2.X;
            num2 = -bounds.Corner2.Y;
            break;
          case AttachmentPoint.MiddleLeft:
            num1 = -bounds.Corner1.X;
            num2 = -bounds.Center.Y;
            break;
          case AttachmentPoint.MiddleCenter:
            num1 = -bounds.Center.X;
            num2 = -bounds.Center.Y;
            break;
          case AttachmentPoint.MiddleRight:
            num1 = -bounds.Corner2.X;
            num2 = -bounds.Center.Y;
            break;
          case AttachmentPoint.BottomLeft:
            num1 = -bounds.Corner1.X;
            num2 = -bounds.Corner1.Y;
            break;
          case AttachmentPoint.BottomCenter:
            num1 = -bounds.Center.X;
            num2 = -bounds.Corner1.Y;
            break;
          case AttachmentPoint.BottomRight:
            num1 = -bounds.Corner2.X;
            num2 = -bounds.Corner1.Y;
            break;
        }
      }
      if (width == 0.0)
        num1 = 0.0;
      Vector2D vector2D = new Vector2D(num1, num2);
      foreach (Class1023 class1023 in class1023Array)
      {
        class1023.Offset += vector2D;
        class1023.imethod_3((ICollection<Class908>) class908List, insertionTransformation, lineWeight);
      }
      if (resultLayoutInfo != null)
      {
        bounds.Move(num1, num2);
        resultLayoutInfo.Bounds.Update(bounds);
        if (resultLayoutInfo.FirstLineBounds != null)
          resultLayoutInfo.FirstLineBounds.Move(num1, num2);
        if (resultLayoutInfo.LastLineBounds != null && resultLayoutInfo.LastLineBounds != resultLayoutInfo.FirstLineBounds)
          resultLayoutInfo.LastLineBounds.Move(num1, num2);
      }
      return class908List;
    }

    internal static IList<Class908> smethod_2(
      DxfMText mtext,
      Color color,
      short lineWeight)
    {
      return Class666.smethod_3(mtext, color, lineWeight, Matrix4D.Identity, (Class985) null);
    }

    internal static IList<Class908> smethod_3(
      DxfMText mtext,
      Color color,
      short lineWeight,
      Matrix4D insertionTransformation,
      Class985 mtextLayoutInfo)
    {
      return Class666.smethod_1(mtext.Text, mtext.ReferenceRectangleWidth, mtext.Height, mtext.AttachmentPoint, mtext.LineSpacingFactor, mtext.LineSpacingStyle, mtext.Style, mtext.Style.WidthFactor, color, mtext.DrawingDirection, lineWeight, insertionTransformation * mtext.Transform, mtextLayoutInfo, Enum24.flag_3);
    }

    internal static IList<Class908> smethod_4(
      DxfMText mtext,
      Color color,
      short lineWeight,
      Matrix4D insertionTransformation,
      Bounds2D collectBounds)
    {
      Class985 resultLayoutInfo = collectBounds == null ? (Class985) null : new Class985();
      IList<Class908> class908List = Class666.smethod_1(mtext.Text, mtext.ReferenceRectangleWidth, mtext.Height, mtext.AttachmentPoint, mtext.LineSpacingFactor, mtext.LineSpacingStyle, mtext.Style, mtext.Style.WidthFactor, color, mtext.DrawingDirection, lineWeight, insertionTransformation * mtext.Transform, resultLayoutInfo, Enum24.flag_3);
      collectBounds?.Update(resultLayoutInfo.Bounds);
      return class908List;
    }

    internal static IList<Class908> smethod_5(
      DxfText text,
      Color color,
      short lineWeight,
      Matrix4D insertionTransformation,
      Bounds2D collectBounds)
    {
      Vector2D alignmentTranslation;
      Vector2D alignmentScaling;
      return Class666.smethod_6(text, color, lineWeight, insertionTransformation, collectBounds, out alignmentTranslation, out alignmentScaling);
    }

    internal static IList<Class908> smethod_6(
      DxfText text,
      Color color,
      short lineWeight,
      Matrix4D insertionTransformation,
      Bounds2D collectBounds,
      out Vector2D alignmentTranslation,
      out Vector2D alignmentScaling)
    {
      Class425 class425 = Class594.smethod_10(text.DisplayString, text.Height, text.ObliqueAngle, text.WidthFactor, text.Style, color);
      Vector2D zero = Vector2D.Zero;
      class425.imethod_0(ref zero, text.Height, Enum24.flag_3);
      alignmentTranslation = Vector2D.Zero;
      Bounds2D bounds = class425.GetBounds(Enum24.flag_0, (Class985) null);
      if (zero != Vector2D.Zero)
      {
        bounds.Update(0.0, 0.0);
        bounds.Update(zero.X, zero.Y);
      }
      double x = 1.0;
      double y = 1.0;
      if (bounds.Initialized && text.AlignmentPoint2.HasValue)
      {
        if (text.VerticalAlignment != TextVerticalAlignment.Baseline)
        {
          switch (text.VerticalAlignment)
          {
            case TextVerticalAlignment.Bottom:
              alignmentTranslation.Y = class425.Blocks.Count > 0 ? class425.Blocks.First.Value.Settings.Font.Metrics.Descent : -bounds.Min.Y;
              break;
            case TextVerticalAlignment.Middle:
              alignmentTranslation.Y = -0.5 * text.Height;
              break;
            case TextVerticalAlignment.Top:
              alignmentTranslation.Y = -text.Height;
              break;
          }
        }
        switch (text.HorizontalAlignment)
        {
          case TextHorizontalAlignment.Left:
            alignmentTranslation.X = -bounds.Corner1.X;
            break;
          case TextHorizontalAlignment.Center:
            alignmentTranslation.X = -bounds.Center.X;
            break;
          case TextHorizontalAlignment.Right:
            alignmentTranslation.X = -bounds.Corner2.X;
            break;
          case TextHorizontalAlignment.Aligned:
            x = (text.AlignmentPoint2.Value - text.AlignmentPoint1).GetLength() / bounds.Delta.X;
            y = x;
            bounds = new Bounds2D(new WW.Math.Point2D(bounds.Corner1.X, y * bounds.Corner1.Y), new WW.Math.Point2D(bounds.Corner1.X + x * bounds.Delta.X, y * bounds.Corner2.Y));
            alignmentTranslation.X = -bounds.Corner2.X;
            break;
          case TextHorizontalAlignment.Middle:
            alignmentTranslation.Y = -bounds.Center.Y;
            alignmentTranslation.X = -bounds.Center.X;
            break;
          case TextHorizontalAlignment.Fit:
            x = (text.AlignmentPoint2.Value - text.AlignmentPoint1).GetLength() / bounds.Delta.X;
            bounds = new Bounds2D(bounds.Corner1, new WW.Math.Point2D(bounds.Corner1.X + x * bounds.Delta.X, bounds.Corner2.Y));
            alignmentTranslation.X = -bounds.Corner2.X;
            break;
        }
      }
      IList<Class908> class908List = (IList<Class908>) new List<Class908>();
      class425.imethod_3((ICollection<Class908>) class908List, insertionTransformation * Transformation4D.Translation(alignmentTranslation.X, alignmentTranslation.Y, 0.0) * Transformation4D.Scaling(x, y, 1.0), lineWeight);
      if (collectBounds != null)
      {
        bounds.Move(alignmentTranslation.X, alignmentTranslation.Y);
        collectBounds.Update(bounds);
      }
      alignmentScaling = new Vector2D(x, y);
      return class908List;
    }
  }
}
