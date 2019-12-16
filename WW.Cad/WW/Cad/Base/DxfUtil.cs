// Decompiled with JetBrains decompiler
// Type: WW.Cad.Base.DxfUtil
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns30;
using ns33;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using WW.Cad.Drawing;
using WW.Cad.Model;
using WW.Cad.Model.Tables;
using WW.Compression;
using WW.IO;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Base
{
  public static class DxfUtil
  {
    private const double double_0 = 0.015625;
    private const double double_1 = 1E-06;
    private const double double_2 = 1E-06;

    public static Stream OpenFileRead(string filename)
    {
      string extension = Path.GetExtension(filename);
      Stream stream = StreamUtil.OpenReadOnlyStream(filename);
      if (extension == null)
        return stream;
      switch (extension.ToLower())
      {
        case ".gz":
          return CompressionUtil.GetGZipStream(stream, true);
        default:
          return stream;
      }
    }

    public static Matrix4D GetScaleTransform(
      WW.Math.Point3D fromPoint1,
      WW.Math.Point3D fromPoint2,
      WW.Math.Point3D toPoint1,
      WW.Math.Point3D toPoint2)
    {
      WW.Math.Point3D fromReferencePoint = new WW.Math.Point3D(0.5 * (fromPoint1.X + fromPoint2.X), 0.5 * (fromPoint1.Y + fromPoint2.Y), 0.5 * (fromPoint1.Z + fromPoint2.Z));
      WW.Math.Point3D toReferencePoint = new WW.Math.Point3D(0.5 * (toPoint1.X + toPoint2.X), 0.5 * (toPoint1.Y + toPoint2.Y), 0.5 * (toPoint1.Z + toPoint2.Z));
      return DxfUtil.GetScaleTransform(fromPoint1, fromPoint2, fromReferencePoint, toPoint1, toPoint2, toReferencePoint);
    }

    public static Matrix4D GetScaleTransform(
      WW.Math.Point3D fromPoint1,
      WW.Math.Point3D fromPoint2,
      WW.Math.Point3D toPoint1,
      WW.Math.Point3D toPoint2,
      out double scaling)
    {
      WW.Math.Point3D fromReferencePoint = new WW.Math.Point3D(0.5 * (fromPoint1.X + fromPoint2.X), 0.5 * (fromPoint1.Y + fromPoint2.Y), 0.5 * (fromPoint1.Z + fromPoint2.Z));
      WW.Math.Point3D toReferencePoint = new WW.Math.Point3D(0.5 * (toPoint1.X + toPoint2.X), 0.5 * (toPoint1.Y + toPoint2.Y), 0.5 * (toPoint1.Z + toPoint2.Z));
      return DxfUtil.GetScaleTransform(fromPoint1, fromPoint2, fromReferencePoint, toPoint1, toPoint2, toReferencePoint, out scaling);
    }

    public static Matrix4D GetScaleTransform(
      WW.Math.Point3D fromPoint1,
      WW.Math.Point3D fromPoint2,
      WW.Math.Point3D fromReferencePoint,
      WW.Math.Point3D toPoint1,
      WW.Math.Point3D toPoint2,
      WW.Math.Point3D toReferencePoint)
    {
      return Transformation4D.GetScaleTransform(fromPoint1, fromPoint2, fromReferencePoint, toPoint1, toPoint2, toReferencePoint);
    }

    public static Matrix4D GetScaleTransform(
      WW.Math.Point3D fromPoint1,
      WW.Math.Point3D fromPoint2,
      WW.Math.Point3D fromReferencePoint,
      WW.Math.Point3D toPoint1,
      WW.Math.Point3D toPoint2,
      WW.Math.Point3D toReferencePoint,
      out double scaling)
    {
      return Transformation4D.GetScaleTransform(fromPoint1, fromPoint2, fromReferencePoint, toPoint1, toPoint2, toReferencePoint, out scaling);
    }

    public static MatrixTransform GetScaleWMMatrixTransform(
      WW.Math.Point2D fromPoint1,
      WW.Math.Point2D fromPoint2,
      WW.Math.Point2D fromReferencePoint,
      WW.Math.Point2D toPoint1,
      WW.Math.Point2D toPoint2,
      WW.Math.Point2D toReferencePoint)
    {
      double scaling;
      return DxfUtil.GetScaleWMMatrixTransform(fromPoint1, fromPoint2, fromReferencePoint, toPoint1, toPoint2, toReferencePoint, out scaling);
    }

    public static MatrixTransform GetScaleWMMatrixTransform(
      WW.Math.Point2D fromPoint1,
      WW.Math.Point2D fromPoint2,
      WW.Math.Point2D fromReferencePoint,
      WW.Math.Point2D toPoint1,
      WW.Math.Point2D toPoint2,
      WW.Math.Point2D toReferencePoint,
      out double scaling)
    {
      Vector2D vector2D1 = toPoint2 - toPoint1;
      Vector2D vector2D2 = fromPoint2 - fromPoint1;
      double num1 = vector2D1.X / vector2D2.X;
      double num2 = vector2D1.Y / vector2D2.Y;
      scaling = System.Math.Abs(num1) <= System.Math.Abs(num2) ? num1 : num2;
      scaling = System.Math.Abs(scaling);
      Matrix4D matrix4D1 = Transformation4D.Scaling(scaling * (double) System.Math.Sign(num1), scaling * (double) System.Math.Sign(num2), scaling);
      WW.Math.Point2D point2D = matrix4D1.TransformTo2D(fromReferencePoint);
      Matrix4D matrix4D2 = Transformation4D.Translation((Vector3D) (toReferencePoint - point2D)) * matrix4D1;
      return new MatrixTransform(matrix4D2.M00, matrix4D2.M01, matrix4D2.M10, matrix4D2.M11, matrix4D2.M03, matrix4D2.M13);
    }

    public static Matrix4D ToMatrix4D(Matrix matrix)
    {
      return new Matrix4D(matrix.M11, matrix.M12, 0.0, matrix.OffsetX, matrix.M21, matrix.M22, 0.0, matrix.OffsetY, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix4D GetToWCSTransform(Vector3D zaxis)
    {
      if (zaxis == Vector3D.ZAxis)
        return Matrix4D.Identity;
      zaxis.Normalize();
      Vector3D xaxis = System.Math.Abs(zaxis.X) >= 1.0 / 64.0 || System.Math.Abs(zaxis.Y) >= 1.0 / 64.0 ? Vector3D.CrossProduct(Vector3D.ZAxis, zaxis) : Vector3D.CrossProduct(Vector3D.YAxis, zaxis);
      xaxis.Normalize();
      return DxfUtil.GetToWCSTransform2(xaxis, zaxis);
    }

    public static Vector3D GetToWcsTransformXAxis(Vector3D zaxis)
    {
      if (zaxis == Vector3D.ZAxis)
        return Vector3D.XAxis;
      zaxis.Normalize();
      Vector3D vector3D = System.Math.Abs(zaxis.X) >= 1.0 / 64.0 || System.Math.Abs(zaxis.Y) >= 1.0 / 64.0 ? Vector3D.CrossProduct(Vector3D.ZAxis, zaxis) : Vector3D.CrossProduct(Vector3D.YAxis, zaxis);
      vector3D.Normalize();
      return vector3D;
    }

    public static Matrix4D GetToWCSTransform(Vector3D xaxis, Vector3D zaxis)
    {
      xaxis.Normalize();
      zaxis.Normalize();
      Vector3D vector3D = Vector3D.CrossProduct(zaxis, xaxis);
      return new Matrix4D(xaxis.X, vector3D.X, zaxis.X, 0.0, xaxis.Y, vector3D.Y, zaxis.Y, 0.0, xaxis.Z, vector3D.Z, zaxis.Z, 0.0, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix4D GetToWCSTransform2(Vector3D xaxis, Vector3D zaxis)
    {
      Vector3D vector3D = Vector3D.CrossProduct(zaxis, xaxis);
      return new Matrix4D(xaxis.X, vector3D.X, zaxis.X, 0.0, xaxis.Y, vector3D.Y, zaxis.Y, 0.0, xaxis.Z, vector3D.Z, zaxis.Z, 0.0, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix3D GetToWCSTransform3D(Vector3D zaxis)
    {
      if (zaxis == Vector3D.ZAxis)
        return Matrix3D.Identity;
      zaxis.Normalize();
      Vector3D xaxis = System.Math.Abs(zaxis.X) >= 1.0 / 64.0 || System.Math.Abs(zaxis.Y) >= 1.0 / 64.0 ? Vector3D.CrossProduct(Vector3D.ZAxis, zaxis) : Vector3D.CrossProduct(Vector3D.YAxis, zaxis);
      xaxis.Normalize();
      return DxfUtil.GetToWCSTransform2_3D(xaxis, zaxis);
    }

    public static Matrix3D GetToWCSTransform3D(Vector3D xaxis, Vector3D zaxis)
    {
      xaxis.Normalize();
      zaxis.Normalize();
      Vector3D vector3D = Vector3D.CrossProduct(zaxis, xaxis);
      return new Matrix3D(xaxis.X, vector3D.X, zaxis.X, xaxis.Y, vector3D.Y, zaxis.Y, xaxis.Z, vector3D.Z, zaxis.Z);
    }

    public static Matrix3D GetToWCSTransform2_3D(Vector3D xaxis, Vector3D zaxis)
    {
      Vector3D vector3D = Vector3D.CrossProduct(zaxis, xaxis);
      return new Matrix3D(xaxis.X, vector3D.X, zaxis.X, xaxis.Y, vector3D.Y, zaxis.Y, xaxis.Z, vector3D.Z, zaxis.Z);
    }

    public static bool GetArbitraryAxisAndZRotation(
      Matrix3D rotation,
      out Vector3D arbitraryAxis,
      out double zAngle)
    {
      if (System.Math.Abs(rotation.GetDeterminant() - 1.0) >= 0.0001)
      {
        arbitraryAxis = Vector3D.Zero;
        zAngle = 0.0;
        return false;
      }
      arbitraryAxis = new Vector3D(rotation.M02, rotation.M12, rotation.M22);
      Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(arbitraryAxis);
      Matrix3D matrix3D = new Matrix3D(toWcsTransform.M00, toWcsTransform.M01, toWcsTransform.M02, toWcsTransform.M10, toWcsTransform.M11, toWcsTransform.M12, toWcsTransform.M20, toWcsTransform.M21, toWcsTransform.M22).GetInverse() * rotation;
      zAngle = System.Math.Atan2(matrix3D.M10, matrix3D.M00);
      return true;
    }

    public static void Extrude(IList<Polyline3D> polylines, double thickness, Vector3D zaxis)
    {
      Vector3D vector3D = thickness * zaxis;
      List<Polyline3D> polyline3DList = new List<Polyline3D>();
      foreach (Polyline3D polyline in (IEnumerable<Polyline3D>) polylines)
      {
        if (polyline.Count == 1)
        {
          WW.Math.Point3D point3D = polyline[0] + vector3D;
          polyline.Add(point3D);
        }
        else
        {
          Polyline3D polyline3D = new Polyline3D(polyline.Count, polyline.Closed);
          polyline3DList.Add(polyline3D);
          foreach (WW.Math.Point3D point3D1 in (List<WW.Math.Point3D>) polyline)
          {
            WW.Math.Point3D point3D2 = point3D1 + vector3D;
            polyline3D.Add(point3D2);
            polyline3DList.Add(new Polyline3D(new WW.Math.Point3D[2]
            {
              point3D1,
              point3D2
            }));
          }
        }
      }
      foreach (Polyline3D polyline3D in polyline3DList)
        polylines.Add(polyline3D);
    }

    public static IList<Polyline3D> Offset(
      IList<Polyline3D> polylines,
      double thickness,
      Vector3D zaxis)
    {
      IList<Polyline3D> polyline3DList = (IList<Polyline3D>) new List<Polyline3D>(polylines.Count);
      Vector3D vector3D = thickness * zaxis;
      foreach (Polyline3D polyline in (IEnumerable<Polyline3D>) polylines)
      {
        Polyline3D polyline3D = new Polyline3D(polyline.Count, polyline.Closed);
        polyline3DList.Add(polyline3D);
        foreach (WW.Math.Point3D point3D1 in (List<WW.Math.Point3D>) polyline)
        {
          WW.Math.Point3D point3D2 = point3D1 + vector3D;
          polyline3D.Add(point3D2);
        }
      }
      return polyline3DList;
    }

    public static bool Equal(double a, double b)
    {
      return System.Math.Abs(a - b) < 4.94065645841247E-321;
    }

    public static void DisposeThreadStaticObjects()
    {
      Class940.DisposeThreadStaticObjects();
      Class735.DisposeThreadStaticObjects();
    }

    public static bool IsSaneNotZero(double value)
    {
      if (value != 0.0 && !double.IsInfinity(value))
        return !double.IsNaN(value);
      return false;
    }

    internal static void smethod_0(
      GraphicsConfig graphicsConfig,
      IList<Polyline2D> resultLines,
      IList<FlatShape4D> resultShapes,
      Polyline2D polyline,
      DxfLineType lineType,
      double lineTypeScale,
      ILineTypeScaler lineTypeScaler)
    {
      if (lineType != null && lineType.Elements.Count > 1 && lineTypeScale != 0.0)
      {
        double length1 = Class624.GetLength(polyline, lineTypeScaler);
        double num1 = lineType.GetLength() * lineTypeScale;
        if (num1 != 0.0 && length1 != 0.0 && length1 >= num1 - 8.88178419700125E-16)
        {
          int num2 = (int) System.Math.Floor(length1 / num1);
          if (num2 > graphicsConfig.MaxLineTypeRepeatCount)
          {
            resultLines.Add(polyline);
          }
          else
          {
            double length2 = 0.5 * (lineTypeScale * lineType.Elements[0].Length + (length1 - (double) num2 * num1));
            double start1 = 0.0;
            int startVertexIndex = 0;
            int count = lineType.Elements.Count;
            double localStart = 0.0;
            double start2 = DxfUtil.smethod_1(resultLines, resultShapes, polyline, start1, length2, lineTypeScaler, ref startVertexIndex, ref localStart);
            DxfUtil.smethod_6(graphicsConfig, resultShapes, polyline, startVertexIndex, localStart, lineType.Elements[0], lineTypeScale, lineTypeScaler);
            int num3 = num2 * lineType.Elements.Count;
            for (int index = 1; index < num3; ++index)
            {
              DxfLineType.Element element = lineType.Elements[index % count];
              start2 = DxfUtil.smethod_1(resultLines, resultShapes, polyline, start2, lineTypeScale * element.Length, lineTypeScaler, ref startVertexIndex, ref localStart);
              DxfUtil.smethod_6(graphicsConfig, resultShapes, polyline, startVertexIndex, localStart, element, lineTypeScale, lineTypeScaler);
            }
            DxfUtil.smethod_1(resultLines, resultShapes, polyline, start2, length1, lineTypeScaler, ref startVertexIndex, ref localStart);
          }
        }
        else
          resultLines.Add(polyline);
      }
      else
        resultLines.Add(polyline);
    }

    private static double smethod_1(
      IList<Polyline2D> resultLines,
      IList<FlatShape4D> resultShapes,
      Polyline2D polyline,
      double start,
      double length,
      ILineTypeScaler lineTypeScaler,
      ref int startVertexIndex,
      ref double localStart)
    {
      if (length > 0.0)
      {
        double num1 = length;
        start += num1;
        double num2 = num1;
        WW.Math.Point2D point2D1 = polyline[startVertexIndex];
        Polyline2D polyline2D = new Polyline2D();
        resultLines.Add(polyline2D);
        bool flag = true;
        int count = polyline.Count;
        int num3 = polyline.Closed ? count + 1 : count;
        for (int index = startVertexIndex + 1; index < num3; ++index)
        {
          WW.Math.Point2D point2D2 = polyline[index % count];
          Vector2D v = point2D2 - point2D1;
          double scaledLength = lineTypeScaler.GetScaledLength(v);
          if (flag)
          {
            polyline2D.Add(point2D1 + localStart / scaledLength * v);
            flag = false;
          }
          double num4 = scaledLength - localStart;
          if (num4 < num2)
          {
            polyline2D.Add(point2D2);
            num2 -= num4;
            localStart = 0.0;
            point2D1 = point2D2;
          }
          else
          {
            localStart += num2;
            polyline2D.Add(point2D1 + localStart / scaledLength * v);
            startVertexIndex = index - 1;
            return start;
          }
        }
        startVertexIndex = polyline.Count - 1;
      }
      else if (length < 0.0)
      {
        double num1 = -length;
        start += num1;
        double num2 = num1;
        WW.Math.Point2D point2D1 = polyline[startVertexIndex];
        int count = polyline.Count;
        int num3 = polyline.Closed ? count + 1 : count;
        for (int index = startVertexIndex + 1; index < num3; ++index)
        {
          WW.Math.Point2D point2D2 = polyline[index % count];
          Vector2D v = point2D2 - point2D1;
          double num4 = lineTypeScaler.GetScaledLength(v) - localStart;
          if (num4 < num2)
          {
            num2 -= num4;
            localStart = 0.0;
            point2D1 = point2D2;
          }
          else
          {
            localStart += num2;
            startVertexIndex = index - 1;
            return start;
          }
        }
        startVertexIndex = polyline.Count - 1;
      }
      else
      {
        WW.Math.Point2D point2D = polyline[startVertexIndex];
        Vector2D v = polyline[(startVertexIndex + 1) % polyline.Count] - point2D;
        double scaledLength = lineTypeScaler.GetScaledLength(v);
        Polyline2D polyline2D = new Polyline2D(new WW.Math.Point2D[1]{ point2D + localStart / scaledLength * v });
        resultLines.Add(polyline2D);
      }
      return start;
    }

    internal static void smethod_2(
      GraphicsConfig graphicsConfig,
      IList<Polyline3D> resultLines,
      IList<FlatShape4D> resultShapes,
      IList<Polyline3D> polylines,
      DxfLineType lineType,
      Vector3D upward,
      double lineTypeScale,
      ILineTypeScaler lineTypeScaler)
    {
      foreach (Polyline3D polyline in (IEnumerable<Polyline3D>) polylines)
        DxfUtil.smethod_4(graphicsConfig, resultLines, resultShapes, polyline, lineType, upward, lineTypeScale, lineTypeScaler);
    }

    internal static void smethod_3(
      GraphicsConfig graphicsConfig,
      IList<Polyline3D> resultLines,
      IList<FlatShape4D> resultShapes,
      Polyline3D polyline,
      DxfLineType lineType,
      Vector3D upward,
      double lineTypeScale,
      ILineTypeScaler lineTypeScaler,
      bool plinegen)
    {
      if (lineType != null && lineType.Elements.Count != 0 && !plinegen)
      {
        int count = polyline.Count;
        WW.Math.Point3D point3D1 = polyline[polyline.Closed ? count - 1 : 0];
        for (int index = polyline.Closed ? 0 : 1; index < count; ++index)
        {
          WW.Math.Point3D point3D2 = polyline[index];
          DxfUtil.smethod_4(graphicsConfig, resultLines, resultShapes, new Polyline3D(new WW.Math.Point3D[2]
          {
            point3D1,
            point3D2
          }), lineType, upward, lineTypeScale, lineTypeScaler);
          point3D1 = point3D2;
        }
      }
      else
        DxfUtil.smethod_4(graphicsConfig, resultLines, resultShapes, polyline, lineType, upward, lineTypeScale, lineTypeScaler);
    }

    internal static void smethod_4(
      GraphicsConfig graphicsConfig,
      IList<Polyline3D> resultLines,
      IList<FlatShape4D> resultShapes,
      Polyline3D polyline,
      DxfLineType lineType,
      Vector3D upward,
      double lineTypeScale,
      ILineTypeScaler lineTypeScaler)
    {
      if (lineType != null && lineType.Elements.Count > 1 && lineTypeScale != 0.0)
      {
        double length1 = Class624.GetLength(polyline, lineTypeScaler);
        double num1 = lineType.GetLength() * lineTypeScale;
        if (num1 != 0.0 && length1 != 0.0 && length1 >= num1 - 8.88178419700125E-16)
        {
          int num2 = (int) System.Math.Floor(length1 / num1);
          if (num2 > graphicsConfig.MaxLineTypeRepeatCount)
          {
            resultLines.Add(polyline);
          }
          else
          {
            double start1 = 0.0;
            int startVertexIndex = 0;
            int count = lineType.Elements.Count;
            double localStart = 0.0;
            bool flag = false;
            int index1 = 0;
            if (lineType.Elements[0].Length == 0.0)
            {
              flag = true;
              DxfUtil.smethod_8(resultLines, polyline, start1, 0.0, lineTypeScaler, ref startVertexIndex, ref localStart);
              index1 = 1;
            }
            double length2 = 0.0;
            for (; index1 < count; ++index1)
            {
              DxfLineType.Element element = lineType.Elements[index1];
              if (element.Length != 0.0)
              {
                double num3 = length1 - (double) num2 * num1;
                length2 = element.Length <= 0.0 ? lineTypeScale * element.Length - 0.5 * num3 : 0.5 * (lineTypeScale * element.Length + num3);
                ++index1;
                break;
              }
            }
            double start2 = DxfUtil.smethod_8(resultLines, polyline, start1, length2, lineTypeScaler, ref startVertexIndex, ref localStart);
            DxfUtil.smethod_5(graphicsConfig, resultShapes, polyline, startVertexIndex, localStart, upward, lineType.Elements[0], lineTypeScale, lineTypeScaler);
            for (int index2 = num2 * lineType.Elements.Count; index1 < index2; ++index1)
            {
              DxfLineType.Element element = lineType.Elements[index1 % count];
              start2 = DxfUtil.smethod_8(resultLines, polyline, start2, lineTypeScale * element.Length, lineTypeScaler, ref startVertexIndex, ref localStart);
              DxfUtil.smethod_5(graphicsConfig, resultShapes, polyline, startVertexIndex, localStart, upward, element, lineTypeScale, lineTypeScaler);
            }
            if (length2 > 0.0 || length2 < 0.0 && flag)
              start2 = DxfUtil.smethod_8(resultLines, polyline, start2, length2 > 0.0 ? length1 : -length1, lineTypeScaler, ref startVertexIndex, ref localStart);
            if (!flag || polyline.Closed || !(polyline[0] != polyline[polyline.Count - 1]))
              return;
            DxfUtil.smethod_8(resultLines, polyline, start2, 0.0, lineTypeScaler, ref startVertexIndex, ref localStart);
          }
        }
        else if (num1 > 0.0 && lineType.Elements[0].Length == 0.0 && !lineType.ContainsElementWithPositiveLength)
        {
          int startVertexIndex = 0;
          double localStart = 0.0;
          DxfUtil.smethod_8(resultLines, polyline, 0.0, 0.0, lineTypeScaler, ref startVertexIndex, ref localStart);
          if (polyline.Closed || !(polyline[0] != polyline[polyline.Count - 1]))
            return;
          startVertexIndex = polyline.Count - 1;
          DxfUtil.smethod_8(resultLines, polyline, length1, 0.0, lineTypeScaler, ref startVertexIndex, ref localStart);
        }
        else
          resultLines.Add(polyline);
      }
      else
        resultLines.Add(polyline);
    }

    private static void smethod_5(
      GraphicsConfig graphicsConfig,
      IList<FlatShape4D> resultShapes,
      Polyline3D polyline,
      int segment,
      double localStart,
      Vector3D upward,
      DxfLineType.Element element,
      double ltScale,
      ILineTypeScaler lineTypeScaler)
    {
      if (!graphicsConfig.DisplayLineTypeElementShapes)
        return;
      FillableShape2D extendedShape = element.ExtendedShape;
      if (extendedShape == null)
        return;
      WW.Math.Point3D b = polyline[segment];
      Vector3D v1 = WW.Math.Point3D.Subtract(polyline[(segment + 1) % polyline.Count], b);
      Vector3D unit = v1.GetUnit();
      Vector3D vector3D1 = Vector3D.CrossProduct(upward, unit);
      double lengthSquared = vector3D1.GetLengthSquared();
      if (lengthSquared == 0.0)
      {
        vector3D1 = Vector3D.CrossProduct(Vector3D.ZAxis, unit);
        lengthSquared = vector3D1.GetLengthSquared();
        if (lengthSquared == 0.0)
        {
          vector3D1 = Vector3D.CrossProduct(Vector3D.YAxis, unit);
          lengthSquared = vector3D1.GetLengthSquared();
        }
      }
      Vector3D v2 = vector3D1 / System.Math.Sqrt(lengthSquared);
      Vector3D vector3D2 = Vector3D.CrossProduct(unit, v2);
      Matrix3D m = new Matrix3D(unit.X, v2.X, vector3D2.X, unit.Y, v2.Y, vector3D2.Y, unit.Z, v2.Z, vector3D2.Z);
      Matrix3D ocsCorrection = lineTypeScaler.ApplyWcsToOcsCorrection(m);
      WW.Math.Point3D point3D = b + localStart * v1 / lineTypeScaler.GetScaledLength(v1);
      Matrix3D insertionTransformation = element.GetShapeInsertionTransformation(ltScale);
      Matrix4D transform = Transformation4D.Translation(point3D.X, point3D.Y, point3D.Z) * new Matrix4D(ocsCorrection) * new Matrix4D(insertionTransformation.M00, insertionTransformation.M01, 0.0, insertionTransformation.M02, insertionTransformation.M10, insertionTransformation.M11, 0.0, insertionTransformation.M12, 0.0, 0.0, 1.0, 0.0, insertionTransformation.M20, insertionTransformation.M21, 0.0, insertionTransformation.M22);
      resultShapes.Add(new FlatShape4D(extendedShape.Shape, transform, extendedShape.Filled));
    }

    private static void smethod_6(
      GraphicsConfig graphicsConfig,
      IList<FlatShape4D> resultShapes,
      Polyline2D polyline,
      int segment,
      double localStart,
      DxfLineType.Element element,
      double ltScale,
      ILineTypeScaler lineTypeScaler)
    {
      if (!graphicsConfig.DisplayLineTypeElementShapes)
        return;
      FillableShape2D extendedShape = element.ExtendedShape;
      if (extendedShape == null)
        return;
      WW.Math.Point2D b = polyline[segment];
      Vector2D v = WW.Math.Point2D.Subtract(polyline[(segment + 1) % polyline.Count], b);
      Matrix3D m = Transformation3D.RotateZ(System.Math.Atan2(v.Y, v.X));
      Matrix3D ocsCorrection = lineTypeScaler.ApplyWcsToOcsCorrection(m);
      WW.Math.Point2D point2D = b + localStart * v / lineTypeScaler.GetScaledLength(v);
      Matrix3D insertionTransformation = element.GetShapeInsertionTransformation(ltScale);
      Matrix4D transform = Transformation4D.Translation(point2D.X, point2D.Y, 0.0) * new Matrix4D(ocsCorrection) * new Matrix4D(insertionTransformation.M00, insertionTransformation.M01, 0.0, insertionTransformation.M02, insertionTransformation.M10, insertionTransformation.M11, 0.0, insertionTransformation.M12, 0.0, 0.0, 1.0, 0.0, insertionTransformation.M20, insertionTransformation.M21, 0.0, insertionTransformation.M22);
      resultShapes.Add(new FlatShape4D(extendedShape.Shape, transform, extendedShape.Filled));
    }

    private static void smethod_7<T>(
      GraphicsConfig graphicsConfig,
      IList<FlatShape4D> resultShapes,
      Polyline<T> polyline,
      int segment,
      double localStart,
      DxfLineType.Element element,
      double ltScale,
      ILineTypeScaler lineTypeScaler)
      where T : IExtendedPoint2D
    {
      if (!graphicsConfig.DisplayLineTypeElementShapes)
        return;
      FillableShape2D extendedShape = element.ExtendedShape;
      if (extendedShape == null)
        return;
      WW.Math.Point2D position = polyline[segment].Position;
      Vector2D v = WW.Math.Point2D.Subtract(polyline[(segment + 1) % polyline.Count].Position, position);
      Matrix3D m = Transformation3D.RotateZ(System.Math.Atan2(v.Y, v.X));
      Matrix3D ocsCorrection = lineTypeScaler.ApplyWcsToOcsCorrection(m);
      WW.Math.Point2D point2D = position + localStart * v / lineTypeScaler.GetScaledLength(v);
      Matrix3D insertionTransformation = element.GetShapeInsertionTransformation(ltScale);
      Matrix4D transform = Transformation4D.Translation(point2D.X, point2D.Y, 0.0) * new Matrix4D(ocsCorrection) * new Matrix4D(insertionTransformation.M00, insertionTransformation.M01, 0.0, insertionTransformation.M02, insertionTransformation.M10, insertionTransformation.M11, 0.0, insertionTransformation.M12, 0.0, 0.0, 1.0, 0.0, insertionTransformation.M20, insertionTransformation.M21, 0.0, insertionTransformation.M22);
      resultShapes.Add(new FlatShape4D(extendedShape.Shape, transform, extendedShape.Filled));
    }

    private static double smethod_8(
      IList<Polyline3D> result,
      Polyline3D polyline,
      double start,
      double length,
      ILineTypeScaler lineTypeScaler,
      ref int startVertexIndex,
      ref double localStart)
    {
      if (length > 0.0)
      {
        start += length;
        double num1 = length;
        WW.Math.Point3D point3D = polyline[startVertexIndex];
        Polyline3D polyline3D = new Polyline3D();
        result.Add(polyline3D);
        bool flag = true;
        int count = polyline.Count;
        int num2 = polyline.Closed ? count + 1 : count;
        for (int index = startVertexIndex + 1; index < num2; ++index)
        {
          WW.Math.Point3D a = polyline[index % count];
          Vector3D vector3D = WW.Math.Point3D.Subtract(a, point3D);
          double scaledLength = lineTypeScaler.GetScaledLength(vector3D);
          if (flag)
          {
            polyline3D.Add(WW.Math.Point3D.Add(point3D, Vector3D.Multiply(vector3D, localStart / scaledLength)));
            flag = false;
          }
          double num3 = scaledLength - localStart;
          if (num3 < num1)
          {
            polyline3D.Add(a);
            num1 -= num3;
            localStart = 0.0;
            point3D = a;
          }
          else
          {
            localStart += num1;
            polyline3D.Add(WW.Math.Point3D.Add(point3D, Vector3D.Multiply(vector3D, localStart / scaledLength)));
            startVertexIndex = index - 1;
            return start;
          }
        }
        startVertexIndex = polyline.Count - 1;
      }
      else if (length < 0.0)
      {
        double num1 = -length;
        start += num1;
        double num2 = num1;
        WW.Math.Point3D b = polyline[startVertexIndex];
        int count = polyline.Count;
        int num3 = polyline.Closed ? count + 1 : count;
        for (int index = startVertexIndex + 1; index < num3; ++index)
        {
          WW.Math.Point3D a = polyline[index % count];
          Vector3D v = WW.Math.Point3D.Subtract(a, b);
          double num4 = lineTypeScaler.GetScaledLength(v) - localStart;
          if (num4 < num2)
          {
            num2 -= num4;
            localStart = 0.0;
            b = a;
          }
          else
          {
            localStart += num2;
            startVertexIndex = index - 1;
            return start;
          }
        }
        startVertexIndex = polyline.Count - 1;
      }
      else
      {
        WW.Math.Point3D point3D = polyline[startVertexIndex];
        Vector3D vector3D = WW.Math.Point3D.Subtract(polyline[(startVertexIndex + 1) % polyline.Count], point3D);
        double scaledLength = lineTypeScaler.GetScaledLength(vector3D);
        Polyline3D polyline3D = new Polyline3D(new WW.Math.Point3D[1]{ WW.Math.Point3D.Add(point3D, Vector3D.Multiply(vector3D, localStart / scaledLength)) });
        result.Add(polyline3D);
      }
      return start;
    }

    internal static void smethod_9(
      GraphicsConfig graphicsConfig,
      IList<Polyline3D> resultLines,
      IList<FlatShape4D> resultShapes,
      IList<Polyline3DT> polylines,
      DxfLineType lineType,
      Vector3D upward,
      double lineTypeScale,
      ILineTypeScaler lineTypeScaler)
    {
      foreach (Polyline3DT polyline in (IEnumerable<Polyline3DT>) polylines)
        DxfUtil.smethod_11(graphicsConfig, resultLines, resultShapes, polyline, lineType, upward, lineTypeScale, lineTypeScaler);
    }

    internal static void smethod_10(
      GraphicsConfig graphicsConfig,
      IList<Polyline3D> resultLines,
      IList<FlatShape4D> resultShapes,
      Polyline3DT polyline,
      DxfLineType lineType,
      Vector3D upward,
      double lineTypeScale,
      ILineTypeScaler lineTypeScaler,
      bool plinegen)
    {
      if (lineType != null && lineType.Elements.Count != 0 && !plinegen)
      {
        int count = polyline.Count;
        Point3DT point3Dt1 = polyline[polyline.Closed ? count - 1 : 0];
        Polyline3D polyline1 = (Polyline3D) null;
        for (int index = polyline.Closed ? 0 : 1; index < count; ++index)
        {
          Point3DT point3Dt2 = polyline[index];
          if (polyline1 == null)
          {
            polyline1 = new Polyline3D(false);
            polyline1.Add(point3Dt1.Position);
          }
          polyline1.Add(point3Dt2.Position);
          if (point3Dt2.Type == 0U || index == count - 1)
          {
            DxfUtil.smethod_4(graphicsConfig, resultLines, resultShapes, polyline1, lineType, upward, lineTypeScale, lineTypeScaler);
            polyline1 = (Polyline3D) null;
          }
          point3Dt1 = point3Dt2;
        }
      }
      else
        DxfUtil.smethod_11(graphicsConfig, resultLines, resultShapes, polyline, lineType, upward, lineTypeScale, lineTypeScaler);
    }

    internal static void smethod_11(
      GraphicsConfig graphicsConfig,
      IList<Polyline3D> resultLines,
      IList<FlatShape4D> resultShapes,
      Polyline3DT polyline,
      DxfLineType lineType,
      Vector3D upward,
      double lineTypeScale,
      ILineTypeScaler lineTypeScaler)
    {
      if (lineType != null && lineType.Elements.Count > 1 && lineTypeScale != 0.0)
      {
        double length1 = Class624.GetLength(polyline, lineTypeScaler);
        double num1 = lineType.GetLength() * lineTypeScale;
        if (num1 != 0.0 && length1 != 0.0 && length1 >= num1 - 8.88178419700125E-16)
        {
          int num2 = (int) System.Math.Floor(length1 / num1);
          if (num2 > graphicsConfig.MaxLineTypeRepeatCount)
          {
            resultLines.Add(polyline.ToPolyline3D());
          }
          else
          {
            double start1 = 0.0;
            int startVertexIndex = 0;
            int count = lineType.Elements.Count;
            double localStart = 0.0;
            bool addDotAtEveryVertex = false;
            int index1 = 0;
            if (lineType.Elements[0].Length == 0.0)
            {
              addDotAtEveryVertex = true;
              DxfUtil.smethod_13(resultLines, polyline, start1, 0.0, lineTypeScaler, true, ref startVertexIndex, ref localStart);
              index1 = 1;
            }
            double length2 = 0.0;
            for (; index1 < count; ++index1)
            {
              DxfLineType.Element element = lineType.Elements[index1];
              if (element.Length != 0.0)
              {
                double num3 = length1 - (double) num2 * num1;
                length2 = element.Length <= 0.0 ? lineTypeScale * element.Length - 0.5 * num3 : 0.5 * (lineTypeScale * element.Length + num3);
                ++index1;
                break;
              }
            }
            double start2 = DxfUtil.smethod_13(resultLines, polyline, start1, length2, lineTypeScaler, addDotAtEveryVertex, ref startVertexIndex, ref localStart);
            DxfUtil.smethod_12(graphicsConfig, resultShapes, polyline, startVertexIndex, localStart, upward, lineType.Elements[0], lineTypeScale, lineTypeScaler);
            for (int index2 = num2 * lineType.Elements.Count; index1 < index2; ++index1)
            {
              DxfLineType.Element element = lineType.Elements[index1 % count];
              start2 = DxfUtil.smethod_13(resultLines, polyline, start2, lineTypeScale * element.Length, lineTypeScaler, addDotAtEveryVertex, ref startVertexIndex, ref localStart);
              DxfUtil.smethod_12(graphicsConfig, resultShapes, polyline, startVertexIndex, localStart, upward, element, lineTypeScale, lineTypeScaler);
            }
            if (length2 > 0.0 || length2 < 0.0 && addDotAtEveryVertex)
              start2 = DxfUtil.smethod_13(resultLines, polyline, start2, length2 > 0.0 ? length1 : -length1, lineTypeScaler, addDotAtEveryVertex, ref startVertexIndex, ref localStart);
            if (!addDotAtEveryVertex || polyline.Closed || !(polyline[0].Position != polyline[polyline.Count - 1].Position))
              return;
            DxfUtil.smethod_13(resultLines, polyline, start2, 0.0, lineTypeScaler, addDotAtEveryVertex, ref startVertexIndex, ref localStart);
          }
        }
        else if (num1 > 0.0 && lineType.Elements[0].Length == 0.0 && !lineType.ContainsElementWithPositiveLength)
        {
          for (int index = 0; index < polyline.Count; ++index)
          {
            if (polyline[index].Type == 0U)
            {
              int startVertexIndex = index;
              double localStart = 0.0;
              DxfUtil.smethod_13(resultLines, polyline, 0.0, 0.0, lineTypeScaler, false, ref startVertexIndex, ref localStart);
            }
          }
        }
        else
          resultLines.Add(polyline.ToPolyline3D());
      }
      else
        resultLines.Add(polyline.ToPolyline3D());
    }

    private static void smethod_12(
      GraphicsConfig graphicsConfig,
      IList<FlatShape4D> resultShapes,
      Polyline3DT polyline,
      int segment,
      double localStart,
      Vector3D upward,
      DxfLineType.Element element,
      double ltScale,
      ILineTypeScaler lineTypeScaler)
    {
      if (!graphicsConfig.DisplayLineTypeElementShapes)
        return;
      FillableShape2D extendedShape = element.ExtendedShape;
      if (extendedShape == null)
        return;
      WW.Math.Point3D position = polyline[segment].Position;
      Vector3D v1 = WW.Math.Point3D.Subtract(polyline[(segment + 1) % polyline.Count].Position, position);
      Vector3D unit = v1.GetUnit();
      Vector3D vector3D1 = Vector3D.CrossProduct(upward, unit);
      double lengthSquared = vector3D1.GetLengthSquared();
      if (lengthSquared == 0.0)
      {
        vector3D1 = Vector3D.CrossProduct(Vector3D.ZAxis, unit);
        lengthSquared = vector3D1.GetLengthSquared();
        if (lengthSquared == 0.0)
        {
          vector3D1 = Vector3D.CrossProduct(Vector3D.YAxis, unit);
          lengthSquared = vector3D1.GetLengthSquared();
        }
      }
      Vector3D v2 = vector3D1 / System.Math.Sqrt(lengthSquared);
      Vector3D vector3D2 = Vector3D.CrossProduct(unit, v2);
      Matrix3D m = new Matrix3D(unit.X, v2.X, vector3D2.X, unit.Y, v2.Y, vector3D2.Y, unit.Z, v2.Z, vector3D2.Z);
      Matrix3D ocsCorrection = lineTypeScaler.ApplyWcsToOcsCorrection(m);
      WW.Math.Point3D point3D = position + localStart * v1 / lineTypeScaler.GetScaledLength(v1);
      Matrix3D insertionTransformation = element.GetShapeInsertionTransformation(ltScale);
      Matrix4D transform = Transformation4D.Translation(point3D.X, point3D.Y, point3D.Z) * new Matrix4D(ocsCorrection) * new Matrix4D(insertionTransformation.M00, insertionTransformation.M01, 0.0, insertionTransformation.M02, insertionTransformation.M10, insertionTransformation.M11, 0.0, insertionTransformation.M12, 0.0, 0.0, 1.0, 0.0, insertionTransformation.M20, insertionTransformation.M21, 0.0, insertionTransformation.M22);
      resultShapes.Add(new FlatShape4D(extendedShape.Shape, transform, extendedShape.Filled));
    }

    private static double smethod_13(
      IList<Polyline3D> result,
      Polyline3DT polyline,
      double start,
      double length,
      ILineTypeScaler lineTypeScaler,
      bool addDotAtEveryVertex,
      ref int startVertexIndex,
      ref double localStart)
    {
      if (length > 0.0)
      {
        start += length;
        double num1 = length;
        WW.Math.Point3D point3D = polyline[startVertexIndex].Position;
        Polyline3D polyline3D = new Polyline3D();
        result.Add(polyline3D);
        bool flag = true;
        int count = polyline.Count;
        int num2 = polyline.Closed ? count + 1 : count;
        for (int index = startVertexIndex + 1; index < num2; ++index)
        {
          WW.Math.Point3D position = polyline[index % count].Position;
          Vector3D vector3D = WW.Math.Point3D.Subtract(position, point3D);
          double scaledLength = lineTypeScaler.GetScaledLength(vector3D);
          if (flag)
          {
            polyline3D.Add(WW.Math.Point3D.Add(point3D, Vector3D.Multiply(vector3D, localStart / scaledLength)));
            flag = false;
          }
          double num3 = scaledLength - localStart;
          if (num3 < num1)
          {
            polyline3D.Add(position);
            num1 -= num3;
            localStart = 0.0;
            point3D = position;
          }
          else
          {
            localStart += num1;
            polyline3D.Add(WW.Math.Point3D.Add(point3D, Vector3D.Multiply(vector3D, localStart / scaledLength)));
            startVertexIndex = index - 1;
            return start;
          }
        }
        startVertexIndex = polyline.Count - 1;
      }
      else if (length < 0.0)
      {
        double num1 = -length;
        start += num1;
        double num2 = num1;
        WW.Math.Point3D position = polyline[startVertexIndex].Position;
        int count = polyline.Count;
        int num3 = polyline.Closed ? count + 1 : count;
        for (int index = startVertexIndex + 1; index < num3; ++index)
        {
          Point3DT point3Dt = polyline[index % count];
          Vector3D v = WW.Math.Point3D.Subtract(point3Dt.Position, position);
          double num4 = lineTypeScaler.GetScaledLength(v) - localStart;
          if (num4 < num2)
          {
            num2 -= num4;
            localStart = 0.0;
            if (addDotAtEveryVertex && point3Dt.Type == 0U)
            {
              Polyline3D polyline3D = new Polyline3D(new WW.Math.Point3D[1]{ point3Dt.Position });
              result.Add(polyline3D);
            }
            position = point3Dt.Position;
          }
          else
          {
            localStart += num2;
            startVertexIndex = index - 1;
            return start;
          }
        }
        startVertexIndex = polyline.Count - 1;
      }
      else
      {
        WW.Math.Point3D position = polyline[startVertexIndex].Position;
        Vector3D vector3D = WW.Math.Point3D.Subtract(polyline[(startVertexIndex + 1) % polyline.Count].Position, position);
        double scaledLength = lineTypeScaler.GetScaledLength(vector3D);
        Polyline3D polyline3D = new Polyline3D(new WW.Math.Point3D[1]{ WW.Math.Point3D.Add(position, Vector3D.Multiply(vector3D, localStart / scaledLength)) });
        result.Add(polyline3D);
      }
      return start;
    }

    internal static void smethod_14(
      IList<Polyline2D> polylines1,
      IList<Polyline2D> polylines2,
      Matrix4D transform,
      IList<Polyline3D> result,
      bool mergeClosedPolylineSides)
    {
      if (polylines1 == null)
        return;
      int count1 = polylines1.Count;
      if (polylines2 == null)
      {
        for (int index1 = 0; index1 < count1; ++index1)
        {
          Polyline2D polyline2D = polylines1[index1];
          int count2 = polyline2D.Count;
          Polyline3D polyline3D = new Polyline3D(count2, polyline2D.Closed);
          for (int index2 = 0; index2 < count2; ++index2)
          {
            WW.Math.Point3D point3D = transform.TransformTo3D(polyline2D[index2]);
            polyline3D.Add(point3D);
          }
          result.Add(polyline3D);
        }
      }
      else
      {
        for (int index1 = 0; index1 < count1; ++index1)
        {
          Polyline2D polyline2D1 = polylines1[index1];
          Polyline2D polyline2D2 = polylines2[index1];
          if (polyline2D1.Closed && polyline2D2.Closed)
          {
            if (mergeClosedPolylineSides)
            {
              Polyline3D polyline3D = new Polyline3D(polyline2D1.Count + polyline2D2.Count + 2, true);
              if (polyline2D1.Count > 1)
              {
                int count2 = polyline2D1.Count;
                for (int index2 = 0; index2 < count2; ++index2)
                {
                  WW.Math.Point3D point3D = transform.TransformTo3D(polyline2D1[index2]);
                  polyline3D.Add(point3D);
                }
                polyline3D.Add(polyline3D[0]);
              }
              if (polyline2D2.Count > 1)
              {
                int count2 = polyline2D2.Count;
                int count3 = polyline3D.Count;
                for (int index2 = count2 - 1; index2 >= 0; --index2)
                {
                  WW.Math.Point3D point3D = transform.TransformTo3D(polyline2D2[index2]);
                  polyline3D.Add(point3D);
                }
                polyline3D.Add(polyline3D[count3]);
              }
              result.Add(polyline3D);
            }
            else
            {
              int count2 = polyline2D1.Count;
              Polyline3D polyline3D1 = new Polyline3D(count2, true);
              for (int index2 = 0; index2 < count2; ++index2)
              {
                WW.Math.Point3D point3D = transform.TransformTo3D(polyline2D1[index2]);
                polyline3D1.Add(point3D);
              }
              result.Add(polyline3D1);
              int count3 = polyline2D2.Count;
              Polyline3D polyline3D2 = new Polyline3D(count3, true);
              for (int index2 = count3 - 1; index2 >= 0; --index2)
              {
                WW.Math.Point3D point3D = transform.TransformTo3D(polyline2D2[index2]);
                polyline3D2.Add(point3D);
              }
              result.Add(polyline3D2);
            }
          }
          else if (polyline2D2 == null)
          {
            Polyline3D polyline3D = new Polyline3D(polyline2D1.Count, polyline2D1.Closed);
            int count2 = polyline2D1.Count;
            for (int index2 = 0; index2 < count2; ++index2)
            {
              WW.Math.Point3D point3D = transform.TransformTo3D(polyline2D1[index2]);
              polyline3D.Add(point3D);
            }
            result.Add(polyline3D);
          }
          else
          {
            Polyline3D polyline3D = new Polyline3D(polyline2D1.Count + polyline2D2.Count, true);
            int count2 = polyline2D1.Count;
            for (int index2 = 0; index2 < count2; ++index2)
            {
              WW.Math.Point3D point3D = transform.TransformTo3D(polyline2D1[index2]);
              polyline3D.Add(point3D);
            }
            for (int index2 = polyline2D2.Count - 1; index2 >= 0; --index2)
            {
              WW.Math.Point3D point3D = transform.TransformTo3D(polyline2D2[index2]);
              polyline3D.Add(point3D);
            }
            result.Add(polyline3D);
          }
        }
      }
    }

    internal static void smethod_15(
      IList<Polyline2D2N> polylines1,
      IList<Polyline2D2N> polylines2,
      Matrix4D transform,
      IList<Polyline3D> result,
      bool mergeClosedPolylineSides)
    {
      if (polylines1 == null)
        return;
      int count1 = polylines1.Count;
      if (polylines2 == null)
      {
        for (int index1 = 0; index1 < count1; ++index1)
        {
          Polyline2D2N polyline2D2N = polylines1[index1];
          int count2 = polyline2D2N.Count;
          Polyline3D polyline3D = new Polyline3D(count2, polyline2D2N.Closed);
          for (int index2 = 0; index2 < count2; ++index2)
          {
            WW.Math.Point3D point3D = transform.TransformTo3D(polyline2D2N[index2].Position);
            polyline3D.Add(point3D);
          }
          result.Add(polyline3D);
        }
      }
      else
      {
        for (int index1 = 0; index1 < count1; ++index1)
        {
          Polyline2D2N polyline2D2N1 = polylines1[index1];
          Polyline2D2N polyline2D2N2 = polylines2[index1];
          if (polyline2D2N1.Closed)
          {
            if (mergeClosedPolylineSides)
            {
              int count2 = polyline2D2N1.Count;
              Polyline3D polyline3D = new Polyline3D((count2 << 1) + 2, true);
              for (int index2 = 0; index2 < count2; ++index2)
              {
                WW.Math.Point3D point3D = transform.TransformTo3D(polyline2D2N1[index2].Position);
                polyline3D.Add(point3D);
              }
              polyline3D.Add(polyline3D[0]);
              for (int index2 = count2 - 1; index2 >= 0; --index2)
              {
                WW.Math.Point3D point3D = transform.TransformTo3D(polyline2D2N2[index2].Position);
                polyline3D.Add(point3D);
              }
              polyline3D.Add(polyline3D[count2 + 1]);
              result.Add(polyline3D);
            }
            else
            {
              int count2 = polyline2D2N1.Count;
              Polyline3D polyline3D1 = new Polyline3D(count2 << 1, true);
              for (int index2 = 0; index2 < count2; ++index2)
              {
                WW.Math.Point3D point3D = transform.TransformTo3D(polyline2D2N1[index2].Position);
                polyline3D1.Add(point3D);
              }
              result.Add(polyline3D1);
              Polyline3D polyline3D2 = new Polyline3D(count2 << 1, true);
              for (int index2 = count2 - 1; index2 >= 0; --index2)
              {
                WW.Math.Point3D point3D = transform.TransformTo3D(polyline2D2N2[index2].Position);
                polyline3D2.Add(point3D);
              }
              result.Add(polyline3D2);
            }
          }
          else
          {
            int count2 = polyline2D2N1.Count;
            Polyline3D polyline3D = new Polyline3D(count2 << 1, true);
            for (int index2 = 0; index2 < count2; ++index2)
            {
              WW.Math.Point3D point3D = transform.TransformTo3D(polyline2D2N1[index2].Position);
              polyline3D.Add(point3D);
            }
            for (int index2 = count2 - 1; index2 >= 0; --index2)
            {
              WW.Math.Point3D point3D = transform.TransformTo3D(polyline2D2N2[index2].Position);
              polyline3D.Add(point3D);
            }
            result.Add(polyline3D);
          }
        }
      }
    }

    internal static void smethod_16(
      GraphicsConfig graphicsConfig,
      IList<Polyline2D2N> resultLines,
      IList<FlatShape4D> resultShapes,
      IList<Polyline2D2N> polylines,
      DxfLineType lineType,
      double lineTypeScale,
      ILineTypeScaler lineTypeScaler)
    {
      foreach (Polyline2D2N polyline in (IEnumerable<Polyline2D2N>) polylines)
        DxfUtil.smethod_17(graphicsConfig, resultLines, resultShapes, polyline, lineType, lineTypeScale, lineTypeScaler);
    }

    internal static void smethod_17(
      GraphicsConfig graphicsConfig,
      IList<Polyline2D2N> resultLines,
      IList<FlatShape4D> resultShapes,
      Polyline2D2N polyline,
      DxfLineType lineType,
      double lineTypeScale,
      ILineTypeScaler lineTypeScaler)
    {
      if (lineType != null && lineType.Elements.Count > 1 && lineTypeScale != 0.0)
      {
        double length1 = Class624.GetLength(polyline, lineTypeScaler);
        double num1 = lineType.GetLength() * lineTypeScale;
        if (num1 != 0.0 && length1 != 0.0 && length1 >= num1 - 8.88178419700125E-16)
        {
          int num2 = (int) System.Math.Floor(length1 / num1);
          if (num2 > graphicsConfig.MaxLineTypeRepeatCount)
          {
            resultLines.Add(polyline);
          }
          else
          {
            double length2 = 0.5 * (lineTypeScale * lineType.Elements[0].Length + (length1 - (double) num2 * num1));
            double start1 = 0.0;
            int startVertexIndex = 0;
            int count = lineType.Elements.Count;
            double localStart = 0.0;
            double start2 = DxfUtil.smethod_18(resultLines, polyline, start1, length2, lineTypeScaler, ref startVertexIndex, ref localStart);
            DxfUtil.smethod_7<Point2D2N>(graphicsConfig, resultShapes, (Polyline<Point2D2N>) polyline, startVertexIndex, localStart, lineType.Elements[0], lineTypeScale, lineTypeScaler);
            int num3 = num2 * lineType.Elements.Count;
            for (int index = 1; index < num3; ++index)
            {
              DxfLineType.Element element = lineType.Elements[index % count];
              start2 = DxfUtil.smethod_18(resultLines, polyline, start2, lineTypeScale * element.Length, lineTypeScaler, ref startVertexIndex, ref localStart);
              DxfUtil.smethod_7<Point2D2N>(graphicsConfig, resultShapes, (Polyline<Point2D2N>) polyline, startVertexIndex, localStart, element, lineTypeScale, lineTypeScaler);
            }
            DxfUtil.smethod_18(resultLines, polyline, start2, length1, lineTypeScaler, ref startVertexIndex, ref localStart);
          }
        }
        else
          resultLines.Add(polyline);
      }
      else
        resultLines.Add(polyline);
    }

    private static double smethod_18(
      IList<Polyline2D2N> result,
      Polyline2D2N polyline,
      double start,
      double length,
      ILineTypeScaler lineTypeScaler,
      ref int startVertexIndex,
      ref double localStart)
    {
      if (length > 0.0)
      {
        start += length;
        double num1 = length;
        Point2D2N point2D2N1 = polyline[startVertexIndex];
        Polyline2D2N polyline2D2N = new Polyline2D2N();
        result.Add(polyline2D2N);
        bool flag = true;
        Point2D2N point2D2N2 = (Point2D2N) null;
        int count = polyline.Count;
        int num2 = polyline.Closed ? count + 1 : count;
        for (int index = startVertexIndex + 1; index < num2; ++index)
        {
          Point2D2N point2D2N3 = polyline[index % count];
          Vector2D v = point2D2N3.Position - point2D2N1.Position;
          double scaledLength = lineTypeScaler.GetScaledLength(v);
          double num3 = 1.0 / scaledLength;
          if (flag)
          {
            Vector2D startNormal = (localStart * point2D2N1.StartNormal + (scaledLength - localStart) * point2D2N1.EndNormal) * num3;
            point2D2N2 = new Point2D2N(point2D2N1.Position + localStart * num3 * v, startNormal, point2D2N1.EndNormal);
            polyline2D2N.Add(point2D2N2);
            flag = false;
          }
          double num4 = scaledLength - localStart;
          if (num4 < num1)
          {
            polyline2D2N.Add(point2D2N3);
            num1 -= num4;
            localStart = 0.0;
            point2D2N1 = point2D2N3;
          }
          else
          {
            double num5 = localStart + num1;
            Vector2D startNormal = (num5 * point2D2N1.StartNormal + (scaledLength - num5) * point2D2N1.EndNormal) * num3;
            point2D2N2.EndNormal = startNormal;
            Point2D2N point2D2N4 = new Point2D2N(point2D2N1.Position + num5 * num3 * v, startNormal, point2D2N1.EndNormal);
            polyline2D2N.Add(point2D2N4);
            localStart += num1;
            startVertexIndex = index - 1;
            return start;
          }
        }
        startVertexIndex = polyline.Count - 1;
      }
      else if (length < 0.0)
      {
        double num1 = -length;
        start += num1;
        double num2 = num1;
        Point2D2N point2D2N1 = polyline[startVertexIndex];
        int count = polyline.Count;
        int num3 = polyline.Closed ? count + 1 : count;
        for (int index = startVertexIndex + 1; index < num3; ++index)
        {
          Point2D2N point2D2N2 = polyline[index % count];
          Vector2D v = point2D2N2.Position - point2D2N1.Position;
          double num4 = lineTypeScaler.GetScaledLength(v) - localStart;
          if (num4 < num2)
          {
            num2 -= num4;
            localStart = 0.0;
            point2D2N1 = point2D2N2;
          }
          else
          {
            startVertexIndex = index - 1;
            localStart += num2;
            return start;
          }
        }
        startVertexIndex = polyline.Count - 1;
      }
      else
      {
        Point2D2N point2D2N = polyline[startVertexIndex];
        Vector2D v = polyline[(startVertexIndex + 1) % polyline.Count].Position - point2D2N.Position;
        double scaledLength = lineTypeScaler.GetScaledLength(v);
        Polyline2D2N polyline2D2N = new Polyline2D2N(new Point2D2N[1]{ new Point2D2N(point2D2N.Position + localStart / scaledLength * v) });
        result.Add(polyline2D2N);
      }
      return start;
    }

    internal static void smethod_19<T, U>(
      GraphicsConfig graphicsConfig,
      IPolylineFactory<T, U> polylineFactory,
      IList<U> result,
      U polyline,
      Matrix4D transform,
      DxfLineType lineType,
      double lineTypeScale,
      bool plinegen)
      where T : IExtendedPoint2D<T>, new()
      where U : Polyline<T>, new()
    {
      if (lineType != null && lineType.Elements.Count != 0 && !plinegen)
      {
        int count = polyline.Count;
        U polyline1 = polylineFactory.Create();
        for (int index = 0; index < count; ++index)
        {
          T obj = polyline[index];
          polyline1.Add(obj);
          if (!obj.IsInterpolatedPoint || index == count - 1 && !polyline.Closed)
          {
            DxfUtil.smethod_20<T, U>(graphicsConfig, polylineFactory, result, polyline1, transform, lineType, lineTypeScale);
            polyline1.Clear();
            polyline1.Add(obj);
          }
        }
        if (!polyline.Closed)
          return;
        T obj1 = polyline[0];
        polyline1.Add(obj1);
        DxfUtil.smethod_20<T, U>(graphicsConfig, polylineFactory, result, polyline1, transform, lineType, lineTypeScale);
      }
      else
        DxfUtil.smethod_20<T, U>(graphicsConfig, polylineFactory, result, polyline, transform, lineType, lineTypeScale);
    }

    internal static void smethod_20<T, U>(
      GraphicsConfig graphicsConfig,
      IPolylineFactory<T, U> polylineFactory,
      IList<U> result,
      U polyline,
      Matrix4D transform,
      DxfLineType lineType,
      double lineTypeScale)
      where T : IExtendedPoint2D<T>, new()
      where U : Polyline<T>, new()
    {
      if (lineType != null && lineType.Elements.Count > 1 && lineTypeScale != 0.0)
      {
        int length1 = polyline.Count + (polyline.Closed ? 1 : 0);
        double[] transformedLengths = new double[length1];
        double length2 = 0.0;
        WW.Math.Point2D point2D = polyline[polyline.Closed ? 0 : polyline.Count - 1].Position;
        for (int index = length1 - 2; index >= 0; --index)
        {
          WW.Math.Point2D position = polyline[index].Position;
          Vector2D vector = point2D - position;
          double length3 = transform.Transform(vector).GetLength();
          transformedLengths[index] = length3;
          length2 += length3;
          point2D = position;
        }
        double num1 = lineType.GetLength() * lineTypeScale;
        if (num1 != 0.0 && length2 != 0.0 && length2 >= num1 - 8.88178419700125E-16)
        {
          int num2 = (int) System.Math.Floor(length2 / num1);
          if (num2 > graphicsConfig.MaxLineTypeRepeatCount)
          {
            result.Add(polyline);
          }
          else
          {
            double length3 = 0.5 * (lineTypeScale * lineType.Elements[0].Length + (length2 - (double) num2 * num1));
            int startVertexIndex = 0;
            int count = lineType.Elements.Count;
            double localStart = 0.0;
            DxfUtil.smethod_21<T, U>(result, polylineFactory, polyline, transformedLengths, length3, ref startVertexIndex, ref localStart);
            int num3 = num2 * lineType.Elements.Count;
            for (int index = 1; index < num3; ++index)
              DxfUtil.smethod_21<T, U>(result, polylineFactory, polyline, transformedLengths, lineTypeScale * lineType.Elements[index % count].Length, ref startVertexIndex, ref localStart);
            DxfUtil.smethod_21<T, U>(result, polylineFactory, polyline, transformedLengths, length2, ref startVertexIndex, ref localStart);
          }
        }
        else
          result.Add(polyline);
      }
      else
        result.Add(polyline);
    }

    private static void smethod_21<T, U>(
      IList<U> result,
      IPolylineFactory<T, U> polylineFactory,
      U polyline,
      double[] transformedLengths,
      double length,
      ref int startVertexIndex,
      ref double localStart)
      where T : IExtendedPoint2D<T>, new()
      where U : Polyline<T>, new()
    {
      if (length > 0.0)
      {
        double num1 = length;
        T previousVertex = polyline[startVertexIndex];
        U u = new U();
        result.Add(u);
        bool flag = true;
        int count = polyline.Count;
        int num2 = polyline.Closed ? count + 1 : count;
        int index1 = startVertexIndex;
        T obj = default (T);
        for (int index2 = startVertexIndex + 1; index2 < num2; ++index2)
        {
          T nextVertex = polyline[index2 % count];
          double transformedLength = transformedLengths[index1];
          if (transformedLength < 8.88178419700125E-16)
          {
            if (flag)
              u.Add(previousVertex);
            obj = nextVertex.Clone();
            u.Add(obj);
            num1 -= transformedLength;
            localStart = 0.0;
          }
          else
          {
            double num3 = 1.0 / transformedLength;
            if (flag)
            {
              obj = previousVertex.GetPoint(nextVertex, localStart * num3);
              u.Add(obj);
              flag = false;
            }
            double num4 = transformedLength - localStart;
            if (num4 < num1)
            {
              obj = nextVertex.Clone();
              u.Add(obj);
              num1 -= num4;
              localStart = 0.0;
            }
            else
            {
              double fraction = (localStart + num1) * num3;
              obj?.SetEndProperties(previousVertex, fraction);
              T endPoint = previousVertex.GetEndPoint(nextVertex, fraction);
              u.Add(endPoint);
              localStart += num1;
              startVertexIndex = index2 - 1;
              return;
            }
          }
          previousVertex = nextVertex;
          index1 = index2;
        }
        startVertexIndex = polyline.Count - 1;
      }
      else if (length < 0.0)
      {
        double num1 = -length;
        int count = polyline.Count;
        int num2 = polyline.Closed ? count + 1 : count;
        int index1 = startVertexIndex;
        for (int index2 = startVertexIndex + 1; index2 < num2; ++index2)
        {
          double num3 = transformedLengths[index1] - localStart;
          if (num3 < num1)
          {
            num1 -= num3;
            localStart = 0.0;
            index1 = index2;
          }
          else
          {
            startVertexIndex = index2 - 1;
            localStart += num1;
            return;
          }
        }
        startVertexIndex = polyline.Count - 1;
      }
      else
      {
        T obj = polyline[startVertexIndex];
        double transformedLength = transformedLengths[startVertexIndex];
        U u = polylineFactory.Create(1);
        if (MathUtil.AreApproxEqual(transformedLength, 0.0))
        {
          u.Add(obj);
        }
        else
        {
          T nextVertex = polyline[(startVertexIndex + 1) % polyline.Count];
          u.Add(obj.GetEndPoint(nextVertex, localStart / transformedLength));
        }
        result.Add(u);
      }
    }

    internal static void smethod_22(
      GraphicsConfig graphicsConfig,
      IList<Polyline3D> result,
      Polyline3D polyline,
      Matrix4D transform,
      DxfLineType lineType,
      double lineTypeScale,
      bool plinegen)
    {
      if (lineType != null && lineType.Elements.Count != 0 && !plinegen)
      {
        int count = polyline.Count;
        WW.Math.Point3D point3D1 = polyline[polyline.Closed ? count - 1 : 0];
        for (int index = polyline.Closed ? 0 : 1; index < count; ++index)
        {
          WW.Math.Point3D point3D2 = polyline[index];
          DxfUtil.smethod_23(graphicsConfig, result, new Polyline3D(new WW.Math.Point3D[2]
          {
            point3D1,
            point3D2
          }), transform, lineType, lineTypeScale);
          point3D1 = point3D2;
        }
      }
      else
        DxfUtil.smethod_23(graphicsConfig, result, polyline, transform, lineType, lineTypeScale);
    }

    internal static void smethod_23(
      GraphicsConfig graphicsConfig,
      IList<Polyline3D> result,
      Polyline3D polyline,
      Matrix4D transform,
      DxfLineType lineType,
      double lineTypeScale)
    {
      if (lineType != null && lineType.Elements.Count > 1 && lineTypeScale != 0.0)
      {
        double[] transformedLengths = new double[polyline.Count];
        double length1 = 0.0;
        Vector3D[] deltas = new Vector3D[polyline.Count + (polyline.Closed ? 1 : 0)];
        WW.Math.Point3D point3D1 = polyline[polyline.Closed ? 0 : polyline.Count - 1];
        for (int index = polyline.Count - (polyline.Closed ? 1 : 2); index >= 0; --index)
        {
          WW.Math.Point3D point3D2 = polyline[index];
          Vector3D vector = point3D1 - point3D2;
          deltas[index] = vector;
          double length2 = transform.Transform(vector).GetLength();
          transformedLengths[index] = length2;
          length1 += length2;
          point3D1 = point3D2;
        }
        double num1 = lineType.GetLength() * lineTypeScale;
        if (num1 != 0.0 && length1 != 0.0 && length1 >= num1 - 8.88178419700125E-16)
        {
          int num2 = (int) System.Math.Floor(length1 / num1);
          if (num2 > graphicsConfig.MaxLineTypeRepeatCount)
          {
            result.Add(polyline);
          }
          else
          {
            double length2 = 0.5 * (lineTypeScale * lineType.Elements[0].Length + (length1 - (double) num2 * num1));
            int startVertexIndex = 0;
            int count = lineType.Elements.Count;
            double localStart = 0.0;
            DxfUtil.smethod_24(result, polyline, deltas, transformedLengths, length2, ref startVertexIndex, ref localStart);
            int num3 = num2 * lineType.Elements.Count;
            for (int index = 1; index < num3; ++index)
              DxfUtil.smethod_24(result, polyline, deltas, transformedLengths, lineTypeScale * lineType.Elements[index % count].Length, ref startVertexIndex, ref localStart);
            DxfUtil.smethod_24(result, polyline, deltas, transformedLengths, length1, ref startVertexIndex, ref localStart);
          }
        }
        else
          result.Add(polyline);
      }
      else
        result.Add(polyline);
    }

    private static void smethod_24(
      IList<Polyline3D> result,
      Polyline3D polyline,
      Vector3D[] deltas,
      double[] transformedLengths,
      double length,
      ref int startVertexIndex,
      ref double localStart)
    {
      if (length > 0.0)
      {
        double num1 = length;
        WW.Math.Point3D point3D1 = polyline[startVertexIndex];
        Polyline3D polyline3D = new Polyline3D();
        result.Add(polyline3D);
        bool flag = true;
        int count = polyline.Count;
        int num2 = polyline.Closed ? count + 1 : count;
        int index1 = startVertexIndex;
        for (int index2 = startVertexIndex + 1; index2 < num2; ++index2)
        {
          WW.Math.Point3D point3D2 = polyline[index2 % count];
          double transformedLength = transformedLengths[index1];
          if (transformedLength < 8.88178419700125E-16)
          {
            if (flag)
              polyline3D.Add(point3D1);
            polyline3D.Add(point3D2);
            num1 -= transformedLength;
            localStart = 0.0;
          }
          else
          {
            double num3 = 1.0 / transformedLength;
            if (flag)
            {
              polyline3D.Add(point3D1 + localStart * num3 * deltas[index1]);
              flag = false;
            }
            double num4 = transformedLength - localStart;
            if (num4 < num1)
            {
              polyline3D.Add(point3D2);
              num1 -= num4;
              localStart = 0.0;
            }
            else
            {
              double num5 = (localStart + num1) * num3;
              polyline3D.Add(point3D1 + num5 * deltas[index1]);
              localStart += num1;
              startVertexIndex = index2 - 1;
              return;
            }
          }
          point3D1 = point3D2;
          index1 = index2;
        }
        startVertexIndex = polyline.Count - 1;
      }
      else if (length < 0.0)
      {
        double num1 = -length;
        int count = polyline.Count;
        int num2 = polyline.Closed ? count + 1 : count;
        int index1 = startVertexIndex;
        for (int index2 = startVertexIndex + 1; index2 < num2; ++index2)
        {
          double num3 = transformedLengths[index1] - localStart;
          if (num3 < num1)
          {
            num1 -= num3;
            localStart = 0.0;
            index1 = index2;
          }
          else
          {
            startVertexIndex = index2 - 1;
            localStart += num1;
            return;
          }
        }
        startVertexIndex = polyline.Count - 1;
      }
      else
      {
        WW.Math.Point3D point3D = polyline[startVertexIndex];
        double transformedLength = transformedLengths[startVertexIndex];
        Polyline3D polyline3D = new Polyline3D(1);
        if (MathUtil.AreApproxEqual(transformedLength, 0.0))
          polyline3D.Add(point3D);
        else
          polyline3D.Add(point3D + localStart / transformedLength * deltas[startVertexIndex]);
        result.Add(polyline3D);
      }
    }

    internal static void smethod_25(
      GraphicsConfig graphicsConfig,
      Polyline2D2WN polyline,
      DxfLineType lineType,
      double lineTypeScale,
      ILineTypeScaler lineTypeScaler,
      bool plinegen,
      out IList<Polyline2D> resultPolylines1,
      out IList<Polyline2D> resultPolylines2,
      out IList<FlatShape4D> resultShapes,
      out bool lineNeedsFill)
    {
      if (polyline != null && polyline.Count != 0)
      {
        bool allWidthsZero = true;
        for (int index = 0; index < polyline.Count; ++index)
        {
          Point2D2WN point2D2Wn = polyline[index];
          if (point2D2Wn.StartWidth != 0.0 || point2D2Wn.EndWidth != 0.0)
          {
            allWidthsZero = false;
            break;
          }
        }
        lineNeedsFill = !allWidthsZero;
        resultPolylines1 = (IList<Polyline2D>) new List<Polyline2D>();
        resultPolylines2 = !allWidthsZero ? (IList<Polyline2D>) new List<Polyline2D>() : (IList<Polyline2D>) null;
        resultShapes = (IList<FlatShape4D>) new List<FlatShape4D>();
        if (lineType != null && lineType.Elements.Count != 0 && !plinegen)
        {
          int count = polyline.Count;
          Point2D2WN point2D2Wn1 = polyline[polyline.Closed ? count - 1 : 0];
          for (int index = polyline.Closed ? 0 : 1; index < count; ++index)
          {
            Point2D2WN point2D2Wn2 = polyline[index];
            DxfUtil.smethod_26(graphicsConfig, new Polyline2D2WN(new Point2D2WN[2]
            {
              point2D2Wn1,
              point2D2Wn2
            }), lineType, lineTypeScale, lineTypeScaler, (allWidthsZero ? 1 : 0) != 0, resultPolylines1, resultPolylines2, resultShapes);
            point2D2Wn1 = point2D2Wn2;
          }
        }
        else
          DxfUtil.smethod_26(graphicsConfig, polyline, lineType, lineTypeScale, lineTypeScaler, allWidthsZero, resultPolylines1, resultPolylines2, resultShapes);
      }
      else
      {
        lineNeedsFill = false;
        resultPolylines1 = (IList<Polyline2D>) null;
        resultPolylines2 = (IList<Polyline2D>) null;
        resultShapes = (IList<FlatShape4D>) null;
      }
    }

    internal static void smethod_26(
      GraphicsConfig graphicsConfig,
      Polyline2D2WN polyline,
      DxfLineType lineType,
      double lineTypeScale,
      ILineTypeScaler lineTypeScaler,
      bool allWidthsZero,
      IList<Polyline2D> resultPolylines1,
      IList<Polyline2D> resultPolylines2,
      IList<FlatShape4D> resultShapes)
    {
      if (polyline.Count == 0)
        return;
      if (allWidthsZero)
      {
        Polyline2D polyline1 = new Polyline2D(polyline.Count, polyline.Closed);
        for (int index = 0; index < polyline.Count; ++index)
          polyline1.Add(polyline[index].Position);
        DxfUtil.smethod_0(graphicsConfig, resultPolylines1, resultShapes, polyline1, lineType, lineTypeScale, lineTypeScaler);
      }
      else if (lineType != null && lineType.Elements.Count > 1 && lineTypeScale != 0.0)
      {
        double length1 = Class624.GetLength(polyline, lineTypeScaler);
        double num1 = lineType.GetLength() * lineTypeScale;
        if (num1 != 0.0 && length1 != 0.0 && length1 >= num1 - 8.88178419700125E-16)
        {
          int num2 = (int) System.Math.Floor(length1 / num1);
          if (num2 > graphicsConfig.MaxLineTypeRepeatCount)
          {
            DxfUtil.smethod_29(polyline, resultPolylines1, resultPolylines2);
          }
          else
          {
            double length2 = 0.5 * (lineTypeScale * lineType.Elements[0].Length + (length1 - (double) num2 * num1));
            double start = 0.0;
            int startVertexIndex = 0;
            int count = lineType.Elements.Count;
            double localStart = 0.0;
            double num3 = DxfUtil.smethod_30(resultPolylines1, resultPolylines2, polyline, start, length2, lineTypeScaler, ref startVertexIndex, ref localStart);
            DxfUtil.smethod_7<Point2D2WN>(graphicsConfig, resultShapes, (Polyline<Point2D2WN>) polyline, 0, num3, lineType.Elements[0], lineTypeScale, lineTypeScaler);
            int num4 = num2 * lineType.Elements.Count;
            for (int index = 1; index < num4; ++index)
            {
              DxfLineType.Element element = lineType.Elements[index % count];
              num3 = DxfUtil.smethod_30(resultPolylines1, resultPolylines2, polyline, num3, lineTypeScale * element.Length, lineTypeScaler, ref startVertexIndex, ref localStart);
              DxfUtil.smethod_7<Point2D2WN>(graphicsConfig, resultShapes, (Polyline<Point2D2WN>) polyline, startVertexIndex, num3, element, lineTypeScale, lineTypeScaler);
            }
            DxfUtil.smethod_30(resultPolylines1, resultPolylines2, polyline, num3, length1, lineTypeScaler, ref startVertexIndex, ref localStart);
          }
        }
        else
          DxfUtil.smethod_29(polyline, resultPolylines1, resultPolylines2);
      }
      else
        DxfUtil.smethod_29(polyline, resultPolylines1, resultPolylines2);
    }

    internal static bool smethod_27(
      GraphicsConfig graphicsConfig,
      Polyline2D2WN polyline,
      DxfLineType lineType,
      double lineTypeScale,
      ILineTypeScaler lineTypeScaler,
      bool plinegen,
      out IList<Polyline2D2N> resultPolylines1,
      out IList<Polyline2D2N> resultPolylines2,
      out IList<FlatShape4D> shapes,
      out bool lineNeedsFill)
    {
      if (polyline != null && polyline.Count != 0)
      {
        bool allWidthsZero = true;
        for (int index = 0; index < polyline.Count; ++index)
        {
          Point2D2WN point2D2Wn = polyline[index];
          if (point2D2Wn.StartWidth != 0.0 || point2D2Wn.EndWidth != 0.0)
          {
            allWidthsZero = false;
            break;
          }
        }
        lineNeedsFill = !allWidthsZero;
        resultPolylines1 = (IList<Polyline2D2N>) new List<Polyline2D2N>();
        resultPolylines2 = !allWidthsZero ? (IList<Polyline2D2N>) new List<Polyline2D2N>() : (IList<Polyline2D2N>) null;
        shapes = (IList<FlatShape4D>) new List<FlatShape4D>();
        if (lineType != null && lineType.Elements.Count != 0 && !plinegen)
        {
          int count = polyline.Count;
          Point2D2WN point2D2Wn1 = polyline[polyline.Closed ? count - 1 : 0];
          for (int index = polyline.Closed ? 0 : 1; index < count; ++index)
          {
            Point2D2WN point2D2Wn2 = polyline[index];
            DxfUtil.smethod_28(graphicsConfig, new Polyline2D2WN(new Point2D2WN[2]
            {
              point2D2Wn1,
              point2D2Wn2
            }), lineType, lineTypeScale, lineTypeScaler, (allWidthsZero ? 1 : 0) != 0, resultPolylines1, resultPolylines2, shapes);
            point2D2Wn1 = point2D2Wn2;
          }
        }
        else
          DxfUtil.smethod_28(graphicsConfig, polyline, lineType, lineTypeScale, lineTypeScaler, allWidthsZero, resultPolylines1, resultPolylines2, shapes);
        return true;
      }
      lineNeedsFill = false;
      resultPolylines1 = (IList<Polyline2D2N>) null;
      resultPolylines2 = (IList<Polyline2D2N>) null;
      shapes = (IList<FlatShape4D>) null;
      return false;
    }

    internal static void smethod_28(
      GraphicsConfig graphicsConfig,
      Polyline2D2WN polyline,
      DxfLineType lineType,
      double lineTypeScale,
      ILineTypeScaler lineTypeScaler,
      bool allWidthsZero,
      IList<Polyline2D2N> resultPolylines1,
      IList<Polyline2D2N> resultPolylines2,
      IList<FlatShape4D> resultShapes)
    {
      if (polyline.Count == 0)
        return;
      if (allWidthsZero)
      {
        Polyline2D2N polyline1 = new Polyline2D2N(polyline.Count, polyline.Closed);
        for (int index = 0; index < polyline.Count; ++index)
        {
          Point2D2WN point2D2Wn = polyline[index];
          polyline1.Add(new Point2D2N(point2D2Wn.Position, point2D2Wn.StartNormal, point2D2Wn.EndNormal));
        }
        DxfUtil.smethod_17(graphicsConfig, resultPolylines1, resultShapes, polyline1, lineType, lineTypeScale, lineTypeScaler);
      }
      else if (lineType != null && lineType.Elements.Count > 1 && lineTypeScale != 0.0)
      {
        double length1 = Class624.GetLength(polyline, lineTypeScaler);
        double num1 = lineType.GetLength() * lineTypeScale;
        if (num1 != 0.0 && length1 != 0.0 && length1 >= num1 - 8.88178419700125E-16)
        {
          int num2 = (int) System.Math.Floor(length1 / num1);
          if (num2 > graphicsConfig.MaxLineTypeRepeatCount)
          {
            DxfUtil.smethod_34(polyline, resultPolylines1, resultPolylines2);
          }
          else
          {
            double length2 = 0.5 * (lineTypeScale * lineType.Elements[0].Length + (length1 - (double) num2 * num1));
            double start1 = 0.0;
            int startVertexIndex = 0;
            int count = lineType.Elements.Count;
            double localStart = 0.0;
            double start2 = DxfUtil.smethod_32(resultPolylines1, resultPolylines2, polyline, start1, length2, lineTypeScaler, ref startVertexIndex, ref localStart);
            int num3 = num2 * lineType.Elements.Count;
            for (int index = 1; index < num3; ++index)
              start2 = DxfUtil.smethod_32(resultPolylines1, resultPolylines2, polyline, start2, lineTypeScale * lineType.Elements[index % count].Length, lineTypeScaler, ref startVertexIndex, ref localStart);
            DxfUtil.smethod_32(resultPolylines1, resultPolylines2, polyline, start2, length1, lineTypeScaler, ref startVertexIndex, ref localStart);
          }
        }
        else
          DxfUtil.smethod_34(polyline, resultPolylines1, resultPolylines2);
      }
      else
        DxfUtil.smethod_34(polyline, resultPolylines1, resultPolylines2);
    }

    internal static void smethod_29(
      Polyline2D2WN v,
      IList<Polyline2D> resultPolylines1,
      IList<Polyline2D> resultPolylines2)
    {
      List<Polyline2D2WN> polyline2D2WnList = new List<Polyline2D2WN>();
      Point2D2WN point2D2Wn1 = v[0];
      Polyline2D2WN polyline2D2Wn1 = new Polyline2D2WN();
      polyline2D2WnList.Add(polyline2D2Wn1);
      polyline2D2Wn1.Add(point2D2Wn1);
      bool flag1 = point2D2Wn1.HasZeroWidth;
      for (int index = 1; index < v.Count - 1; ++index)
      {
        Point2D2WN point2D2Wn2 = v[index];
        bool hasZeroWidth = point2D2Wn2.HasZeroWidth;
        if (flag1 != hasZeroWidth || !MathUtil.AreApproxEqual(point2D2Wn1.EndWidth, point2D2Wn2.StartWidth))
        {
          polyline2D2Wn1.Add(point2D2Wn2);
          polyline2D2Wn1 = new Polyline2D2WN();
          polyline2D2WnList.Add(polyline2D2Wn1);
        }
        polyline2D2Wn1.Add(point2D2Wn2);
        flag1 = hasZeroWidth;
        point2D2Wn1 = point2D2Wn2;
      }
      if (v.Count > 1)
        polyline2D2Wn1.Add(v[v.Count - 1]);
      foreach (Polyline2D2WN polyline2D2Wn2 in polyline2D2WnList)
      {
        int count = polyline2D2Wn2.Count;
        bool flag2 = v.Closed && count > 2 && polyline2D2WnList.Count == 1;
        Polyline2D polyline2D1 = new Polyline2D();
        resultPolylines1.Add(polyline2D1);
        if (polyline2D2Wn2[0].HasZeroWidth)
        {
          resultPolylines2.Add((Polyline2D) null);
          foreach (Point2D2WN point2D2Wn2 in (List<Point2D2WN>) polyline2D2Wn2)
            polyline2D1.Add(point2D2Wn2.Position);
          if (flag2 && resultPolylines1.Count == 1)
            resultPolylines1[0].Closed = true;
        }
        else
        {
          int num1 = flag2 ? 1 : 2;
          int num2 = flag2 ? count + 1 : count;
          Point2D2WN v1 = polyline2D2Wn2[(num1 + count - 2) % count];
          Point2D2WN point2D2Wn2 = polyline2D2Wn2[(num1 + count - 1) % count];
          DxfUtil.Struct5 struct5_1 = new DxfUtil.Struct5(v1, point2D2Wn2);
          Polyline2D polyline2D2 = new Polyline2D();
          resultPolylines2.Add(polyline2D2);
          if (!flag2)
          {
            polyline2D1.Add(struct5_1.PN1a.Position);
            polyline2D2.Add(struct5_1.PN1b.Position);
          }
          for (int index = num1; index < num2; ++index)
          {
            Point2D2WN v2 = polyline2D2Wn2[index % count];
            DxfUtil.Struct5 struct5_2 = new DxfUtil.Struct5(point2D2Wn2, v2);
            bool flag3 = true;
            WW.Math.Point2D? nullable1 = new WW.Math.Point2D?();
            WW.Math.Point2D? nullable2 = new WW.Math.Point2D?();
            nullable1 = DxfUtil.smethod_53(struct5_1.RayA1, struct5_2.RayA2, struct5_2.P1a);
            if (!nullable1.HasValue)
            {
              flag3 = false;
            }
            else
            {
              nullable2 = DxfUtil.smethod_53(struct5_1.RayB1, struct5_2.RayB2, struct5_2.P1b);
              if (!nullable2.HasValue)
                flag3 = false;
            }
            if (flag3)
            {
              if (polyline2D1.Count == 0 || !WW.Math.Point2D.AreApproxEqual(polyline2D1[polyline2D1.Count - 1], nullable1.Value) || !WW.Math.Point2D.AreApproxEqual(polyline2D2[polyline2D2.Count - 1], nullable2.Value))
              {
                polyline2D1.Add(nullable1.Value);
                polyline2D2.Add(nullable2.Value);
              }
            }
            else
            {
              polyline2D1.Add(struct5_1.PN2a.Position);
              polyline2D2.Add(struct5_1.PN2b.Position);
              polyline2D1 = new Polyline2D();
              resultPolylines1.Add(polyline2D1);
              polyline2D2 = new Polyline2D();
              resultPolylines2.Add(polyline2D2);
              polyline2D1.Add(struct5_2.PN1a.Position);
              polyline2D2.Add(struct5_2.PN1b.Position);
            }
            struct5_1 = struct5_2;
            point2D2Wn2 = v2;
          }
          if (!flag2 || resultPolylines1.Count > 1)
          {
            polyline2D1.Add(struct5_1.PN2a.Position);
            polyline2D2.Add(struct5_1.PN2b.Position);
          }
          if (flag2 && resultPolylines1.Count == 1)
          {
            resultPolylines1[0].Closed = true;
            resultPolylines2[0].Closed = true;
          }
        }
      }
    }

    private static double smethod_30(
      IList<Polyline2D> resultPolylines1,
      IList<Polyline2D> resultPolylines2,
      Polyline2D2WN polyline,
      double start,
      double length,
      ILineTypeScaler lineTypeScaler,
      ref int startVertexIndex,
      ref double localStart)
    {
      if (length > 0.0)
      {
        double num1 = System.Math.Abs(length);
        start += num1;
        double num2 = num1;
        Point2D2WN p1 = polyline[startVertexIndex];
        int count = polyline.Count;
        int num3 = polyline.Closed ? count + 1 : count;
        for (int index = startVertexIndex + 1; index < num3; ++index)
        {
          Point2D2WN point2D2Wn = polyline[index % count];
          Vector2D v = point2D2Wn.Position - p1.Position;
          double length1;
          double scaledLength;
          lineTypeScaler.GetLengths(v, out length1, out scaledLength);
          if (scaledLength != 0.0)
          {
            Vector2D directionNormal = new Vector2D(-v.Y, v.X) / length1;
            double num4 = 1.0 / scaledLength;
            Vector2D vector2D = v * num4;
            WW.Math.Point2D segmentStart = localStart * vector2D + p1.Position;
            double num5 = scaledLength - localStart;
            if (num5 < num2)
            {
              WW.Math.Point2D position = point2D2Wn.Position;
              DxfUtil.smethod_31(resultPolylines1, resultPolylines2, p1, directionNormal, segmentStart, position);
              num2 -= num5;
              localStart = 0.0;
              p1 = point2D2Wn;
            }
            else
            {
              WW.Math.Point2D segmentEnd = (localStart + num2) * vector2D + p1.Position;
              DxfUtil.smethod_31(resultPolylines1, resultPolylines2, p1, directionNormal, segmentStart, segmentEnd);
              startVertexIndex = index - 1;
              localStart += num2;
              return start;
            }
          }
        }
        startVertexIndex = polyline.Count - 1;
      }
      else if (length < 0.0)
      {
        double num1 = System.Math.Abs(length);
        start += num1;
        double num2 = num1;
        Point2D2WN point2D2Wn1 = polyline[startVertexIndex];
        int count = polyline.Count;
        int num3 = polyline.Closed ? count + 1 : count;
        for (int index = startVertexIndex + 1; index < num3; ++index)
        {
          Point2D2WN point2D2Wn2 = polyline[index % count];
          Vector2D v = point2D2Wn2.Position - point2D2Wn1.Position;
          double num4 = lineTypeScaler.GetScaledLength(v) - localStart;
          if (num4 < num2)
          {
            num2 -= num4;
            localStart = 0.0;
            point2D2Wn1 = point2D2Wn2;
          }
          else
          {
            startVertexIndex = index - 1;
            localStart += num2;
            return start;
          }
        }
        startVertexIndex = polyline.Count - 1;
      }
      else
      {
        Point2D2WN point2D2Wn = polyline[startVertexIndex];
        Vector2D v = polyline[(startVertexIndex + 1) % polyline.Count].Position - point2D2Wn.Position;
        double length1;
        double scaledLength;
        lineTypeScaler.GetLengths(v, out length1, out scaledLength);
        Vector2D vector2D1 = new Vector2D(-v.Y, v.X) / length1;
        double num = 1.0 / scaledLength;
        Vector2D vector2D2 = v * num;
        WW.Math.Point2D point2D1 = start * vector2D2 + point2D2Wn.Position;
        if (point2D2Wn.StartWidth > 0.0)
        {
          Vector2D vector2D3 = vector2D1 * point2D2Wn.StartWidth * 0.5;
          WW.Math.Point2D point2D2 = point2D1 - vector2D3;
          WW.Math.Point2D point2D3 = point2D1 + vector2D3;
          resultPolylines1.Add(new Polyline2D(new WW.Math.Point2D[1]
          {
            point2D2
          }));
          resultPolylines2.Add(new Polyline2D(new WW.Math.Point2D[1]
          {
            point2D3
          }));
        }
        else
        {
          resultPolylines1.Add(new Polyline2D(new WW.Math.Point2D[1]
          {
            point2D1
          }));
          resultPolylines2.Add(new Polyline2D(new WW.Math.Point2D[1]
          {
            point2D1
          }));
        }
      }
      return start;
    }

    private static void smethod_31(
      IList<Polyline2D> resultPolylines1,
      IList<Polyline2D> resultPolylines2,
      Point2D2WN p1,
      Vector2D directionNormal,
      WW.Math.Point2D segmentStart,
      WW.Math.Point2D segmentEnd)
    {
      if (p1.StartWidth <= 0.0 && p1.EndWidth <= 0.0)
      {
        resultPolylines1.Add(new Polyline2D(new WW.Math.Point2D[2]
        {
          segmentStart,
          segmentEnd
        }));
        resultPolylines2.Add(new Polyline2D(new WW.Math.Point2D[2]
        {
          segmentStart,
          segmentEnd
        }));
      }
      else
      {
        Vector2D vector2D1 = directionNormal * p1.StartWidth * 0.5;
        WW.Math.Point2D point2D1 = segmentStart - vector2D1;
        WW.Math.Point2D point2D2 = segmentStart + vector2D1;
        Vector2D vector2D2 = directionNormal * p1.EndWidth * 0.5;
        WW.Math.Point2D point2D3 = segmentEnd - vector2D2;
        WW.Math.Point2D point2D4 = segmentEnd + vector2D2;
        resultPolylines1.Add(new Polyline2D(new WW.Math.Point2D[2]
        {
          point2D1,
          point2D3
        }));
        resultPolylines2.Add(new Polyline2D(new WW.Math.Point2D[2]
        {
          point2D2,
          point2D4
        }));
      }
    }

    private static double smethod_32(
      IList<Polyline2D2N> resultPolylines1,
      IList<Polyline2D2N> resultPolylines2,
      Polyline2D2WN polyline,
      double start,
      double length,
      ILineTypeScaler lineTypeScaler,
      ref int startVertexIndex,
      ref double localStart)
    {
      if (length > 0.0)
      {
        double num1 = System.Math.Abs(length);
        start += num1;
        double num2 = num1;
        Point2D2WN p1 = polyline[startVertexIndex];
        int count = polyline.Count;
        int num3 = polyline.Closed ? count + 1 : count;
        for (int index = startVertexIndex + 1; index < num3; ++index)
        {
          Point2D2WN p2 = polyline[index % count];
          Vector2D v = p2.Position - p1.Position;
          double length1;
          double scaledLength;
          lineTypeScaler.GetLengths(v, out length1, out scaledLength);
          if (scaledLength != 0.0)
          {
            Vector2D directionNormal = new Vector2D(-v.Y, v.X) / length1;
            double num4 = 1.0 / scaledLength;
            Vector2D vector2D = v * num4;
            WW.Math.Point2D segmentStart = localStart * vector2D + p1.Position;
            double num5 = scaledLength - localStart;
            if (num5 < num2)
            {
              WW.Math.Point2D position = p2.Position;
              DxfUtil.smethod_33(resultPolylines1, resultPolylines2, p1, p2, directionNormal, segmentStart, position);
              num2 -= num5;
              localStart = 0.0;
              p1 = p2;
            }
            else
            {
              WW.Math.Point2D segmentEnd = (localStart + num2) * vector2D + p1.Position;
              DxfUtil.smethod_33(resultPolylines1, resultPolylines2, p1, p2, directionNormal, segmentStart, segmentEnd);
              startVertexIndex = index - 1;
              localStart += num2;
              return start;
            }
          }
        }
        startVertexIndex = polyline.Count - 1;
      }
      else if (length < 0.0)
      {
        double num1 = System.Math.Abs(length);
        start += num1;
        double num2 = num1;
        Point2D2WN point2D2Wn1 = polyline[startVertexIndex];
        int count = polyline.Count;
        int num3 = polyline.Closed ? count + 1 : count;
        for (int index = startVertexIndex + 1; index < num3; ++index)
        {
          Point2D2WN point2D2Wn2 = polyline[index % count];
          Vector2D v = point2D2Wn2.Position - point2D2Wn1.Position;
          double num4 = lineTypeScaler.GetScaledLength(v) - localStart;
          if (num4 < num2)
          {
            num2 -= num4;
            localStart = 0.0;
            point2D2Wn1 = point2D2Wn2;
          }
          else
          {
            startVertexIndex = index - 1;
            localStart += num2;
            return start;
          }
        }
        startVertexIndex = polyline.Count - 1;
      }
      else
      {
        Point2D2WN point2D2Wn = polyline[startVertexIndex];
        Vector2D v = polyline[(startVertexIndex + 1) % polyline.Count].Position - point2D2Wn.Position;
        double length1;
        double scaledLength;
        lineTypeScaler.GetLengths(v, out length1, out scaledLength);
        Vector2D vector2D1 = new Vector2D(-v.Y, v.X) / length1;
        double num = 1.0 / scaledLength;
        Vector2D vector2D2 = v * num;
        WW.Math.Point2D position1 = start * vector2D2 + point2D2Wn.Position;
        if (point2D2Wn.StartWidth > 0.0)
        {
          Vector2D vector2D3 = vector2D1 * point2D2Wn.StartWidth * 0.5;
          WW.Math.Point2D position2 = position1 - vector2D3;
          WW.Math.Point2D position3 = position1 + vector2D3;
          resultPolylines1.Add(new Polyline2D2N(new Point2D2N[1]
          {
            new Point2D2N(position2)
          }));
          resultPolylines2.Add(new Polyline2D2N(new Point2D2N[1]
          {
            new Point2D2N(position3)
          }));
        }
        else
        {
          resultPolylines1.Add(new Polyline2D2N(new Point2D2N[1]
          {
            new Point2D2N(position1)
          }));
          resultPolylines2.Add(new Polyline2D2N(new Point2D2N[1]
          {
            new Point2D2N(position1)
          }));
        }
      }
      return start;
    }

    private static void smethod_33(
      IList<Polyline2D2N> resultPolylines1,
      IList<Polyline2D2N> resultPolylines2,
      Point2D2WN p1,
      Point2D2WN p2,
      Vector2D directionNormal,
      WW.Math.Point2D segmentStart,
      WW.Math.Point2D segmentEnd)
    {
      if (p1.StartWidth <= 0.0 && p2.EndWidth <= 0.0)
      {
        resultPolylines1.Add(new Polyline2D2N(new Point2D2N[2]
        {
          new Point2D2N(segmentStart, directionNormal, directionNormal),
          new Point2D2N(segmentEnd, -directionNormal, -directionNormal)
        }));
        resultPolylines2.Add(new Polyline2D2N(new Point2D2N[2]
        {
          new Point2D2N(segmentStart, directionNormal, directionNormal),
          new Point2D2N(segmentEnd, -directionNormal, -directionNormal)
        }));
      }
      else
      {
        Vector2D vector2D1 = directionNormal * p1.StartWidth * 0.5;
        WW.Math.Point2D position1 = segmentStart - vector2D1;
        WW.Math.Point2D position2 = segmentStart + vector2D1;
        Vector2D vector2D2 = directionNormal * p2.EndWidth * 0.5;
        WW.Math.Point2D position3 = segmentEnd - vector2D2;
        WW.Math.Point2D position4 = segmentEnd + vector2D2;
        Vector2D unit1 = (position3 - position1).GetUnit();
        Vector2D vector2D3 = new Vector2D(-unit1.Y, unit1.X);
        Vector2D unit2 = (position4 - position2).GetUnit();
        Vector2D vector2D4 = new Vector2D(unit2.Y, -unit2.X);
        resultPolylines1.Add(new Polyline2D2N(new Point2D2N[2]
        {
          new Point2D2N(position1, vector2D3, vector2D3),
          new Point2D2N(position3)
        }));
        resultPolylines2.Add(new Polyline2D2N(new Point2D2N[2]
        {
          new Point2D2N(position2, vector2D4, vector2D4),
          new Point2D2N(position4)
        }));
      }
    }

    internal static void smethod_34(
      Polyline2D2WN v,
      IList<Polyline2D2N> resultPolylines1,
      IList<Polyline2D2N> resultPolylines2)
    {
      int count = v.Count;
      bool flag1;
      int num1 = (flag1 = v.Closed && count > 2) ? 1 : 2;
      int num2 = flag1 ? count + 1 : count;
      Point2D2WN v1 = v[(num1 + count - 2) % count];
      Point2D2WN point2D2Wn = v[(num1 + count - 1) % count];
      DxfUtil.Struct5 struct5_1 = new DxfUtil.Struct5(v1, point2D2Wn);
      Polyline2D2N polyline2D2N1 = new Polyline2D2N();
      resultPolylines1.Add(polyline2D2N1);
      Polyline2D2N polyline2D2N2 = new Polyline2D2N();
      resultPolylines2.Add(polyline2D2N2);
      if (!flag1)
      {
        polyline2D2N1.Add(new Point2D2N(struct5_1.PN1a.Position, struct5_1.PN1a.Normal, struct5_1.PN2a.Normal));
        polyline2D2N2.Add(new Point2D2N(struct5_1.PN1b.Position, struct5_1.PN1b.Normal, struct5_1.PN2b.Normal));
      }
      for (int index = num1; index < num2; ++index)
      {
        Point2D2WN v2 = v[index % count];
        DxfUtil.Struct5 struct5_2 = new DxfUtil.Struct5(point2D2Wn, v2);
        bool flag2 = MathUtil.AreApproxEqual(v1.EndWidth, point2D2Wn.StartWidth);
        WW.Math.Point2D? nullable1 = new WW.Math.Point2D?();
        WW.Math.Point2D? nullable2 = new WW.Math.Point2D?();
        if (flag2)
        {
          nullable1 = DxfUtil.smethod_53(struct5_1.RayA1, struct5_2.RayA2, struct5_2.P1a);
          if (!nullable1.HasValue)
          {
            flag2 = false;
          }
          else
          {
            nullable2 = DxfUtil.smethod_53(struct5_1.RayB1, struct5_2.RayB2, struct5_2.P1b);
            if (!nullable2.HasValue)
              flag2 = false;
          }
        }
        if (flag2)
        {
          if (polyline2D2N1.Count == 0 || !WW.Math.Point2D.AreApproxEqual(polyline2D2N1[polyline2D2N1.Count - 1].Position, nullable1.Value))
            polyline2D2N1.Add(new Point2D2N(nullable1.Value, struct5_2.PN1a.Normal, struct5_2.PN2a.Normal));
          if (polyline2D2N2.Count == 0 || !WW.Math.Point2D.AreApproxEqual(polyline2D2N2[polyline2D2N2.Count - 1].Position, nullable2.Value))
            polyline2D2N2.Add(new Point2D2N(nullable2.Value, struct5_2.PN1b.Normal, struct5_2.PN2b.Normal));
        }
        else
        {
          polyline2D2N1.Add(new Point2D2N(struct5_1.PN2a.Position));
          polyline2D2N2.Add(new Point2D2N(struct5_1.PN2b.Position));
          polyline2D2N1 = new Polyline2D2N();
          resultPolylines1.Add(polyline2D2N1);
          polyline2D2N2 = new Polyline2D2N();
          resultPolylines2.Add(polyline2D2N2);
          polyline2D2N1.Add(new Point2D2N(struct5_2.PN1a.Position, struct5_2.PN1a.Normal, struct5_2.PN2a.Normal));
          polyline2D2N2.Add(new Point2D2N(struct5_2.PN1b.Position, struct5_2.PN1b.Normal, struct5_2.PN2b.Normal));
        }
        struct5_1 = struct5_2;
        v1 = point2D2Wn;
        point2D2Wn = v2;
      }
      if (!flag1 || resultPolylines1.Count > 1)
      {
        polyline2D2N1.Add(new Point2D2N(struct5_1.PN2a.Position));
        polyline2D2N2.Add(new Point2D2N(struct5_1.PN2b.Position));
      }
      if (!flag1 || resultPolylines1.Count != 1)
        return;
      resultPolylines1[0].Closed = true;
      resultPolylines2[0].Closed = true;
    }

    internal static void Transform(IList<Polyline3D> polylines, Matrix4D transform)
    {
      foreach (Polyline3D polyline in (IEnumerable<Polyline3D>) polylines)
      {
        for (int index = 0; index < polyline.Count; ++index)
          polyline[index] = transform.Transform(polyline[index]);
      }
    }

    internal static void Transform(IList<Polyline2D> polylines, Matrix3D transform)
    {
      foreach (Polyline2D polyline in (IEnumerable<Polyline2D>) polylines)
      {
        for (int index = 0; index < polyline.Count; ++index)
          polyline[index] = transform.Transform(polyline[index]);
      }
    }

    internal static Bounds3D Transform(Bounds3D bounds, Matrix4D matrix)
    {
      Bounds3D bounds3D = new Bounds3D();
      foreach (WW.Math.Point3D point in (IEnumerable<WW.Math.Point3D>) DxfUtil.smethod_35(bounds))
        bounds3D.Update(matrix.Transform(point));
      return bounds3D;
    }

    internal static IList<WW.Math.Point3D> smethod_35(Bounds3D bounds)
    {
      WW.Math.Point3D min = bounds.Min;
      WW.Math.Point3D max = bounds.Max;
      Vector3D vector3D = max - min;
      IList<WW.Math.Point3D> point3DList = (IList<WW.Math.Point3D>) new List<WW.Math.Point3D>(8);
      if (vector3D.X > 0.0)
      {
        if (vector3D.Y > 0.0)
        {
          if (vector3D.Z > 0.0)
          {
            point3DList.Add(new WW.Math.Point3D(min.X, min.Y, min.Z));
            point3DList.Add(new WW.Math.Point3D(min.X, min.Y, max.Z));
            point3DList.Add(new WW.Math.Point3D(min.X, max.Y, min.Z));
            point3DList.Add(new WW.Math.Point3D(min.X, max.Y, max.Z));
            point3DList.Add(new WW.Math.Point3D(max.X, min.Y, min.Z));
            point3DList.Add(new WW.Math.Point3D(max.X, min.Y, max.Z));
            point3DList.Add(new WW.Math.Point3D(max.X, max.Y, min.Z));
            point3DList.Add(new WW.Math.Point3D(max.X, max.Y, max.Z));
          }
          else
          {
            point3DList.Add(new WW.Math.Point3D(min.X, min.Y, min.Z));
            point3DList.Add(new WW.Math.Point3D(min.X, max.Y, min.Z));
            point3DList.Add(new WW.Math.Point3D(max.X, min.Y, min.Z));
            point3DList.Add(new WW.Math.Point3D(max.X, max.Y, min.Z));
          }
        }
        else if (vector3D.Z > 0.0)
        {
          point3DList.Add(new WW.Math.Point3D(min.X, min.Y, min.Z));
          point3DList.Add(new WW.Math.Point3D(min.X, min.Y, max.Z));
          point3DList.Add(new WW.Math.Point3D(max.X, min.Y, min.Z));
          point3DList.Add(new WW.Math.Point3D(max.X, min.Y, max.Z));
        }
        else
        {
          point3DList.Add(new WW.Math.Point3D(min.X, min.Y, min.Z));
          point3DList.Add(new WW.Math.Point3D(max.X, min.Y, min.Z));
        }
      }
      else if (vector3D.Y > 0.0)
      {
        if (vector3D.Z > 0.0)
        {
          point3DList.Add(new WW.Math.Point3D(min.X, min.Y, min.Z));
          point3DList.Add(new WW.Math.Point3D(min.X, min.Y, max.Z));
          point3DList.Add(new WW.Math.Point3D(min.X, max.Y, min.Z));
          point3DList.Add(new WW.Math.Point3D(min.X, max.Y, max.Z));
        }
        else
        {
          point3DList.Add(new WW.Math.Point3D(min.X, min.Y, min.Z));
          point3DList.Add(new WW.Math.Point3D(min.X, max.Y, min.Z));
        }
      }
      else if (vector3D.Z > 0.0)
      {
        point3DList.Add(new WW.Math.Point3D(min.X, min.Y, min.Z));
        point3DList.Add(new WW.Math.Point3D(min.X, min.Y, max.Z));
      }
      else
        point3DList.Add(new WW.Math.Point3D(min.X, min.Y, min.Z));
      return point3DList;
    }

    internal static IList<Polyline4D> GetTransformed(
      IEnumerable<Polyline4D> polylines,
      Matrix4D transform)
    {
      List<Polyline4D> polyline4DList = new List<Polyline4D>();
      foreach (Polyline4D polyline in polylines)
      {
        Polyline4D polyline4D = new Polyline4D(polyline.Count, polyline.Closed);
        foreach (Vector4D vector in (List<Vector4D>) polyline)
          polyline4D.Add(transform.Transform(vector));
        polyline4DList.Add(polyline4D);
      }
      return (IList<Polyline4D>) polyline4DList;
    }

    internal static IList<Polyline4D> smethod_36(
      IList<Polyline3D> polylines,
      bool filled,
      IClippingTransformer transformer)
    {
      List<Polyline4D> polyline4DList = new List<Polyline4D>(polylines.Count);
      foreach (Polyline3D polyline in (IEnumerable<Polyline3D>) polylines)
        polyline4DList.AddRange((IEnumerable<Polyline4D>) transformer.Transform(polyline, filled));
      return (IList<Polyline4D>) polyline4DList;
    }

    internal static IList<IShape4D> smethod_37(
      ICollection<FlatShape4D> flatShapes,
      IClippingTransformer transformer)
    {
      if (flatShapes != null)
      {
        int count = flatShapes.Count;
        if (count > 0)
        {
          IList<IShape4D> shape4DList = (IList<IShape4D>) new List<IShape4D>(count);
          foreach (FlatShape4D flatShape in (IEnumerable<FlatShape4D>) flatShapes)
            shape4DList.Add(transformer.Transform((IShape4D) flatShape));
          return shape4DList;
        }
      }
      return (IList<IShape4D>) null;
    }

    internal static IList<Polyline4D> smethod_38(
      Polyline3D polyline,
      bool filled,
      IClippingTransformer transformer)
    {
      return (IList<Polyline4D>) new List<Polyline4D>((IEnumerable<Polyline4D>) transformer.Transform(polyline, filled));
    }

    internal static IList<Polyline4D> smethod_39(
      IList<Polyline2D> polylines,
      bool filled,
      IClippingTransformer transformer)
    {
      List<Polyline4D> polyline4DList = new List<Polyline4D>();
      foreach (Polyline2D polyline1 in (IEnumerable<Polyline2D>) polylines)
      {
        Polyline3D polyline2 = new Polyline3D(polyline1.Count, polyline1.Closed);
        foreach (WW.Math.Point2D point2D in (List<WW.Math.Point2D>) polyline1)
          polyline2.Add((WW.Math.Point3D) point2D);
        polyline4DList.AddRange((IEnumerable<Polyline4D>) transformer.Transform(polyline2, filled));
      }
      return (IList<Polyline4D>) polyline4DList;
    }

    internal static Polyline4D smethod_40(Polyline3D polyline, Matrix4D transform)
    {
      Polyline4D polyline4D = new Polyline4D(polyline.Count, polyline.Closed);
      for (int index = 0; index < polyline.Count; ++index)
        polyline4D.Add(transform.TransformTo4D(polyline[index]));
      return polyline4D;
    }

    internal static IList<Polyline3D> smethod_41(
      IList<Polyline2D> polylines,
      Matrix4D transform)
    {
      IList<Polyline3D> polyline3DList = (IList<Polyline3D>) new Polyline3D[polylines.Count];
      for (int index = 0; index < polylines.Count; ++index)
        polyline3DList[index] = DxfUtil.smethod_42(polylines[index], transform);
      return polyline3DList;
    }

    internal static Polyline3D smethod_42(Polyline2D polyline, Matrix4D transform)
    {
      Polyline3D polyline3D = new Polyline3D(polyline.Count, polyline.Closed);
      for (int index = 0; index < polyline.Count; ++index)
        polyline3D.Add(transform.TransformTo3D(polyline[index]));
      return polyline3D;
    }

    internal static IList<Polyline3D> smethod_43(
      IList<Polyline2D> polylines,
      Interface41 transformer)
    {
      IList<Polyline3D> polyline3DList = (IList<Polyline3D>) new List<Polyline3D>();
      for (int index = 0; index < polylines.Count; ++index)
      {
        Polyline3D polyline3D = DxfUtil.smethod_44(polylines[index], transformer);
        if (polyline3D.Count > 0)
          polyline3DList.Add(polyline3D);
      }
      return polyline3DList;
    }

    internal static Polyline3D smethod_44(Polyline2D polyline, Interface41 transformer)
    {
      int count = polyline.Count;
      Polyline3D polyline3D = new Polyline3D(count, polyline.Closed);
      for (int index = 0; index < count; ++index)
        polyline3D.Add(transformer.imethod_0(polyline[index]));
      return polyline3D;
    }

    internal static Segment3D smethod_45(Segment3D segment, Interface41 transformer)
    {
      return new Segment3D(transformer.imethod_1(segment.Start), transformer.imethod_1(segment.End));
    }

    internal static Polyline3D Transform(Polyline2D polyline, Matrix4D transform)
    {
      Polyline3D polyline3D = new Polyline3D(polyline.Count, polyline.Closed);
      for (int index = 0; index < polyline.Count; ++index)
        polyline3D.Add(transform.TransformTo3D(polyline[index]));
      return polyline3D;
    }

    internal static Polyline3D Transform(Polyline3D polyline, Matrix4D transform)
    {
      Polyline3D polyline3D = new Polyline3D(polyline.Count, polyline.Closed);
      for (int index = 0; index < polyline.Count; ++index)
        polyline3D.Add(transform.Transform(polyline[index]));
      return polyline3D;
    }

    internal static Polyline4D Transform(Polyline4D polyline, Matrix4D transform)
    {
      Polyline4D polyline4D = new Polyline4D(polyline.Count, polyline.Closed);
      for (int index = 0; index < polyline.Count; ++index)
        polyline4D.Add(transform.Transform(polyline[index]));
      return polyline4D;
    }

    internal static Polyline4D smethod_46(Polyline3D polyline, Interface41 transformer)
    {
      Polyline4D polyline4D = new Polyline4D(polyline.Count, polyline.Closed);
      for (int index = 0; index < polyline.Count; ++index)
        polyline4D.Add(transformer.Transform(polyline[index]));
      return polyline4D;
    }

    internal static Polyline4D smethod_47(Polyline2D2N polyline, Interface41 transformer)
    {
      int count = polyline.Count;
      Polyline4D polyline4D = new Polyline4D(count, polyline.Closed);
      for (int index = 0; index < count; ++index)
      {
        Point2D2N point2D2N = polyline[index];
        polyline4D.Add(transformer.Transform((WW.Math.Point3D) point2D2N.Position));
      }
      return polyline4D;
    }

    internal static IList<Polyline4D> smethod_48(
      IList<Polyline2D> polylines,
      Interface41 transformer)
    {
      IList<Polyline4D> polyline4DList = (IList<Polyline4D>) new List<Polyline4D>();
      for (int index = 0; index < polylines.Count; ++index)
      {
        Polyline4D polyline4D = DxfUtil.smethod_49(polylines[index], transformer);
        if (polyline4D.Count > 0)
          polyline4DList.Add(polyline4D);
      }
      return polyline4DList;
    }

    internal static Polyline4D smethod_49(Polyline2D polyline, Interface41 transformer)
    {
      int count = polyline.Count;
      Polyline4D polyline4D = new Polyline4D(count, polyline.Closed);
      for (int index = 0; index < count; ++index)
        polyline4D.Add(transformer.Transform(polyline[index]));
      return polyline4D;
    }

    internal static Segment4D smethod_50(Segment3D segment, Interface41 transformer)
    {
      return new Segment4D(transformer.Transform(segment.Start), transformer.Transform(segment.End));
    }

    internal static IList<Polyline4D> smethod_51(
      IList<Polyline3D> polylines,
      Interface41 transformer)
    {
      IList<Polyline4D> polyline4DList = (IList<Polyline4D>) new List<Polyline4D>();
      for (int index = 0; index < polylines.Count; ++index)
      {
        Polyline4D polyline4D = DxfUtil.smethod_46(polylines[index], transformer);
        if (polyline4D.Count > 0)
          polyline4DList.Add(polyline4D);
      }
      return polyline4DList;
    }

    internal static void smethod_52(Polyline4D polyline, Interface41 transformer)
    {
      for (int index = polyline.Count - 1; index >= 0; --index)
        polyline[index] = transformer.Transform(polyline[index].ToPoint3D());
    }

    private static WW.Math.Point2D? smethod_53(
      Ray2D ray1,
      Ray2D ray2,
      WW.Math.Point2D intersectionIfParallel)
    {
      if (Vector2D.AreApproxEqual(ray1.Direction, Vector2D.Zero))
      {
        if (Vector2D.AreApproxEqual(ray2.Direction, Vector2D.Zero))
        {
          if (WW.Math.Point2D.AreApproxEqual(ray1.Origin, ray2.Origin))
            return new WW.Math.Point2D?(ray2.Origin);
          return new WW.Math.Point2D?();
        }
        if (ray2.Contains(ray1.Origin))
          return new WW.Math.Point2D?(ray2.Origin);
        return new WW.Math.Point2D?();
      }
      if (Vector2D.AreApproxEqual(ray2.Direction, Vector2D.Zero))
      {
        if (ray1.Contains(ray2.Origin))
          return new WW.Math.Point2D?(ray2.Origin);
        return new WW.Math.Point2D?();
      }
      bool parallel;
      WW.Math.Point2D? nullable = Ray2D.GetIntersection(ray1, ray2, 1E-06, out parallel);
      if (nullable.HasValue && parallel)
        nullable = new WW.Math.Point2D?(intersectionIfParallel);
      return nullable;
    }

    private static Stream smethod_54(Stream input)
    {
      MemoryStream memoryStream = new MemoryStream();
      int count1 = 10240;
      byte[] buffer = new byte[10240];
      while (true)
      {
        int count2 = input.Read(buffer, 0, count1);
        if (count2 > 0)
          memoryStream.Write(buffer, 0, count2);
        else
          break;
      }
      input.Close();
      memoryStream.Position = 0L;
      return (Stream) memoryStream;
    }

    internal static double smethod_55(double y, double x)
    {
      double num = System.Math.Atan2(y, x);
      if (num < 0.0)
        num += 2.0 * System.Math.PI;
      return num;
    }

    internal static double smethod_56(double angle)
    {
      while (angle < 0.0)
        angle += 2.0 * System.Math.PI;
      while (angle > 2.0 * System.Math.PI)
        angle -= 2.0 * System.Math.PI;
      return angle;
    }

    internal static DxfVersion smethod_57(string dxfVersion)
    {
      switch (dxfVersion)
      {
        case "AC1006":
          return DxfVersion.Dxf10;
        case "AC1008":
          return DxfVersion.Dxf10PlusUnofficial;
        case "AC1009":
          return DxfVersion.Dxf12;
        case "AC1012":
          return DxfVersion.Dxf13;
        case "AC1013":
          return DxfVersion.Dxf14Preview;
        case "AC1014":
          return DxfVersion.Dxf14;
        case "AC1015":
          return DxfVersion.Dxf15;
        case "AC1018":
          return DxfVersion.Dxf18;
        case "AC1021":
          return DxfVersion.Dxf21;
        case "AC1024":
          return DxfVersion.Dxf24;
        case "AC1027":
          return DxfVersion.Dxf27;
        default:
          return DxfVersion.Unknown;
      }
    }

    internal static void smethod_58(
      DxfVersion dxfVersion,
      out string versionString,
      out int maintenanceVersion)
    {
      versionString = "?";
      maintenanceVersion = 0;
      switch (dxfVersion)
      {
        case DxfVersion.Dxf10:
          versionString = "AC1006";
          break;
        case DxfVersion.Dxf10PlusUnofficial:
          versionString = "AC1008";
          break;
        case DxfVersion.Dxf12:
          versionString = "AC1009";
          break;
        case DxfVersion.Dxf13:
          versionString = "AC1012";
          break;
        case DxfVersion.Dxf14Preview:
          versionString = "AC1013";
          break;
        case DxfVersion.Dxf14:
          versionString = "AC1014";
          break;
        case DxfVersion.Dxf15:
          versionString = "AC1015";
          break;
        case DxfVersion.Dxf18:
          versionString = "AC1018";
          break;
        case DxfVersion.Dxf21:
          versionString = "AC1021";
          maintenanceVersion = 25;
          break;
        case DxfVersion.Dxf24:
          versionString = "AC1024";
          maintenanceVersion = 6;
          break;
        case DxfVersion.Dxf27:
          versionString = "AC1027";
          break;
      }
    }

    internal static double smethod_59(
      WW.Math.Point3D p1,
      Vector3D direction1,
      WW.Math.Point3D p2,
      Vector3D direction2)
    {
      Vector3D v = Vector3D.CrossProduct(direction1, direction2);
      if (v.GetLength() < 8.88178419700125E-16)
      {
        v = Vector3D.CrossProduct(direction1, Vector3D.CrossProduct(p2 - p1, direction1));
        if (v.GetLength() < 8.88178419700125E-16)
          return 0.0;
        v.Normalize();
      }
      return Vector3D.DotProduct(p2 - p1, v);
    }

    internal static WW.Math.Point3D[] smethod_60(
      WW.Math.Point3D p1,
      Vector3D direction1,
      WW.Math.Point3D p2,
      Vector3D direction2,
      out bool parallel)
    {
      Vector3D u1 = Vector3D.CrossProduct(direction1, direction2);
      if (u1.GetLength() < 8.88178419700125E-16)
      {
        parallel = true;
        return (WW.Math.Point3D[]) null;
      }
      u1.Normalize();
      parallel = false;
      Vector3D vector3D = direction1;
      vector3D.Normalize();
      Vector3D u2 = Vector3D.CrossProduct(u1, vector3D);
      Vector3D v1 = (Vector3D) p1;
      Line2D a = new Line2D(new WW.Math.Point2D(Vector3D.DotProduct(vector3D, v1), Vector3D.DotProduct(u2, v1)), new Vector2D(Vector3D.DotProduct(vector3D, direction1), Vector3D.DotProduct(u2, direction1)));
      Vector3D v2 = (Vector3D) p2;
      Line2D b = new Line2D(new WW.Math.Point2D(Vector3D.DotProduct(vector3D, v2), Vector3D.DotProduct(u2, v2)), new Vector2D(Vector3D.DotProduct(vector3D, direction2), Vector3D.DotProduct(u2, direction2)));
      double p;
      double q;
      if (!Line2D.GetIntersectionCoefficients(a, b, out p, out q))
        return (WW.Math.Point3D[]) null;
      if (p < 0.0 || q < 0.0)
        return (WW.Math.Point3D[]) null;
      return new WW.Math.Point3D[2]{ p1 + p * direction1, p2 + q * direction2 };
    }

    internal static Matrix4D smethod_61(Matrix3D m)
    {
      return new Matrix4D(m.M00, m.M01, 0.0, m.M02, m.M10, m.M11, 0.0, m.M12, m.M20, m.M21, 1.0, 0.0, 0.0, 0.0, 0.0, m.M22);
    }

    internal static DateTime DateTimeNow
    {
      get
      {
        return DateTime.Now;
      }
    }

    internal static DateTime DateTimeUtcNow
    {
      get
      {
        return DateTime.UtcNow;
      }
    }

    private struct Struct5
    {
      private Point2DN point2DN_0;
      private Point2DN point2DN_1;
      private Point2DN point2DN_2;
      private Point2DN point2DN_3;

      public Struct5(Point2D2WN v1, Point2D2WN v2)
      {
        if (v1.Position != v2.Position)
        {
          Vector2D vector2D1 = v1.StartWidth * v1.StartNormal * 0.5;
          this.point2DN_0 = new Point2DN(v1.Position + vector2D1, v1.StartNormal);
          this.point2DN_1 = new Point2DN(v1.Position - vector2D1, -v1.StartNormal);
          Vector2D vector2D2 = v1.EndWidth * v1.EndNormal * 0.5;
          this.point2DN_2 = new Point2DN(v2.Position + vector2D2, v1.EndNormal);
          this.point2DN_3 = new Point2DN(v2.Position - vector2D2, -v1.EndNormal);
        }
        else
        {
          this.point2DN_0 = new Point2DN(v1.Position, v1.StartNormal);
          this.point2DN_1 = new Point2DN(v1.Position, -v1.StartNormal);
          this.point2DN_2 = new Point2DN(v2.Position, v1.EndNormal);
          this.point2DN_3 = new Point2DN(v2.Position, -v1.EndNormal);
        }
      }

      public WW.Math.Point2D P1a
      {
        get
        {
          return this.point2DN_0.Position;
        }
      }

      public Point2DN PN1a
      {
        get
        {
          return this.point2DN_0;
        }
      }

      public WW.Math.Point2D P1b
      {
        get
        {
          return this.point2DN_1.Position;
        }
      }

      public Point2DN PN1b
      {
        get
        {
          return this.point2DN_1;
        }
      }

      public WW.Math.Point2D P2a
      {
        get
        {
          return this.point2DN_2.Position;
        }
        set
        {
          this.point2DN_2.Position = value;
        }
      }

      public Point2DN PN2a
      {
        get
        {
          return this.point2DN_2;
        }
      }

      public WW.Math.Point2D P2b
      {
        get
        {
          return this.point2DN_3.Position;
        }
        set
        {
          this.point2DN_3.Position = value;
        }
      }

      public Point2DN PN2b
      {
        get
        {
          return this.point2DN_3;
        }
        set
        {
          this.point2DN_3 = value;
        }
      }

      public Ray2D RayA1
      {
        get
        {
          return new Ray2D(this.point2DN_0.Position, this.point2DN_2.Position - this.point2DN_0.Position);
        }
      }

      public Ray2D RayA2
      {
        get
        {
          return new Ray2D(this.point2DN_2.Position, this.point2DN_0.Position - this.point2DN_2.Position);
        }
      }

      public Ray2D RayB1
      {
        get
        {
          return new Ray2D(this.point2DN_1.Position, this.point2DN_3.Position - this.point2DN_1.Position);
        }
      }

      public Ray2D RayB2
      {
        get
        {
          return new Ray2D(this.point2DN_3.Position, this.point2DN_1.Position - this.point2DN_3.Position);
        }
      }
    }
  }
}
