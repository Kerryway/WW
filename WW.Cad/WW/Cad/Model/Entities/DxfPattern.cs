// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfPattern
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns36;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Drawing;
using WW.Cad.IO;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfPattern
  {
    private string string_0 = string.Empty;
    private string string_1 = string.Empty;
    private readonly List<DxfPattern.Line> list_0 = new List<DxfPattern.Line>();

    public DxfPattern()
    {
    }

    public DxfPattern(string name)
    {
      this.string_0 = name ?? string.Empty;
    }

    public string Description
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value ?? string.Empty;
      }
    }

    public string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value ?? string.Empty;
      }
    }

    public List<DxfPattern.Line> Lines
    {
      get
      {
        return this.list_0;
      }
    }

    internal void method_0(
      List<Polyline2D> polylines,
      Polyline2D[] boundaries,
      WW.Math.Point2D seed,
      bool fillInterior)
    {
      foreach (DxfPattern.Line line in this.list_0)
        polylines.AddRange((IEnumerable<Polyline2D>) line.method_0(boundaries, seed, false));
    }

    internal double method_1(double totalArea)
    {
      double num1 = 0.0;
      foreach (DxfPattern.Line line in this.list_0)
      {
        double num2 = System.Math.Abs(Vector2D.DotProduct(new Vector2D(System.Math.Sin(line.Angle), -System.Math.Cos(line.Angle)), line.Offset));
        if (num2 != 0.0)
        {
          if (line.DashLengths.Count == 0)
          {
            double num3 = System.Math.Sqrt(totalArea) / num2;
            if (num3 > num1)
              num1 = num3;
          }
          else
          {
            double num3 = 0.0;
            foreach (double dashLength in line.DashLengths)
              num3 += System.Math.Abs(dashLength);
            double num4 = num2 * num3;
            if (num4 != 0.0)
            {
              double num5 = totalArea / num4;
              if (num5 > num1)
                num1 = num5;
            }
            else
            {
              num1 = double.MaxValue;
              break;
            }
          }
        }
        else
        {
          num1 = double.MaxValue;
          break;
        }
      }
      return num1;
    }

    internal void TransformMe(double rotationAngle, double scaling)
    {
      this.TransformMe(rotationAngle, scaling, Vector2D.Zero);
    }

    internal void TransformMe(double rotationAngle, double scaling, Vector2D offset)
    {
      Matrix3D matrix3D = Transformation3D.Translation(offset) * Transformation3D.Scaling2D(scaling) * Transformation3D.Rotate(rotationAngle);
      foreach (DxfPattern.Line line in this.list_0)
      {
        line.Angle += rotationAngle;
        line.BasePoint = matrix3D.Transform(line.BasePoint);
        line.Offset = matrix3D.Transform(line.Offset);
        for (int index1 = 0; index1 < line.DashLengths.Count; ++index1)
        {
          List<double> dashLengths;
          int index2;
          (dashLengths = line.DashLengths)[index2 = index1] = dashLengths[index2] * scaling;
        }
      }
    }

    internal void TransformMe(TransformConfig config, Matrix4D transform)
    {
      this.TransformMe(config, Transformation3D.From(transform));
    }

    internal void TransformMe(TransformConfig config, Matrix4D transform, CommandGroup undoGroup)
    {
      this.TransformMe(config, Transformation3D.From(transform), undoGroup);
    }

    internal void TransformMe(TransformConfig config, Matrix3D transform)
    {
      foreach (DxfPattern.Line line in this.list_0)
        line.TransformMe(config, transform);
    }

    internal void TransformMe(TransformConfig config, Matrix3D transform, CommandGroup undoGroup)
    {
      foreach (DxfPattern.Line line in this.list_0)
        line.TransformMe(config, transform, undoGroup);
    }

    public DxfPattern Clone()
    {
      DxfPattern dxfPattern = new DxfPattern();
      dxfPattern.CopyFrom(this);
      return dxfPattern;
    }

    public void CopyFrom(DxfPattern from)
    {
      this.string_0 = from.string_0;
      this.string_1 = from.string_1;
      foreach (DxfPattern.Line line in from.list_0)
        this.list_0.Add(line.Clone());
    }

    public override string ToString()
    {
      return this.string_0;
    }

    public DxfPattern CreateTransformed(double rotationAngle, double scaling)
    {
      return this.CreateTransformed(rotationAngle, scaling, Vector2D.Zero);
    }

    public DxfPattern CreateTransformed(
      double rotationAngle,
      double scaling,
      Vector2D offset)
    {
      DxfPattern dxfPattern = this.Clone();
      dxfPattern.TransformMe(rotationAngle, scaling, offset);
      return dxfPattern;
    }

    public DxfPattern CreateTransformed(Matrix4D transform)
    {
      return this.CreateTransformed(Transformation3D.From(transform));
    }

    public DxfPattern CreateTransformed(Matrix3D transform)
    {
      DxfPattern dxfPattern = this.Clone();
      dxfPattern.TransformMe(new TransformConfig(), transform);
      return dxfPattern;
    }

    internal void Write(DxfWriter w)
    {
      w.Write(78, (object) (short) this.Lines.Count);
      foreach (DxfPattern.Line line in this.Lines)
      {
        w.Write(53, (object) (line.Angle * (180.0 / System.Math.PI)));
        w.Write(43, (object) line.BasePoint.X);
        w.Write(44, (object) line.BasePoint.Y);
        w.Write(45, (object) line.Offset.X);
        w.Write(46, (object) line.Offset.Y);
        w.Write(79, (object) (short) line.DashLengths.Count);
        foreach (double dashLength in line.DashLengths)
          w.Write(49, (object) dashLength);
      }
    }

    internal void Read(DxfReader r, int lineCount)
    {
      for (uint index = 0; (long) index < (long) lineCount; ++index)
      {
        DxfPattern.Line line = new DxfPattern.Line();
        line.Read(r);
        this.Lines.Add(line);
      }
    }

    internal void Write(Interface29 objectWriter)
    {
      objectWriter.imethod_32((short) this.Lines.Count);
      for (int index1 = 0; index1 < this.Lines.Count; ++index1)
      {
        DxfPattern.Line line = this.Lines[index1];
        objectWriter.imethod_16(line.Angle);
        objectWriter.imethod_23(line.BasePoint);
        objectWriter.imethod_27(line.Offset);
        objectWriter.imethod_32((short) line.DashLengths.Count);
        for (int index2 = 0; index2 < line.DashLengths.Count; ++index2)
          objectWriter.imethod_16(line.DashLengths[index2]);
      }
    }

    internal void Read(Interface30 objectMainBitStream)
    {
      int num1 = (int) objectMainBitStream.imethod_14();
      for (int index1 = 0; index1 < num1; ++index1)
      {
        DxfPattern.Line line = new DxfPattern.Line();
        line.Angle = objectMainBitStream.imethod_8();
        line.BasePoint = objectMainBitStream.imethod_36();
        line.Offset = objectMainBitStream.imethod_49();
        int num2 = (int) objectMainBitStream.imethod_14();
        for (int index2 = 0; index2 < num2; ++index2)
        {
          double num3 = objectMainBitStream.imethod_8();
          line.DashLengths.Add(num3);
        }
        this.list_0.Add(line);
      }
    }

    public class Line
    {
      private readonly List<double> list_0 = new List<double>();
      private double double_0;
      private WW.Math.Point2D point2D_0;
      private Vector2D vector2D_0;

      public Line()
      {
      }

      public Line(double angle, WW.Math.Point2D basePoint, Vector2D offset)
      {
        this.double_0 = angle;
        this.point2D_0 = basePoint;
        this.vector2D_0 = offset;
      }

      public Line(
        double angle,
        WW.Math.Point2D basePoint,
        Vector2D offset,
        ICollection<double> dashLengths)
      {
        this.double_0 = angle;
        this.point2D_0 = basePoint;
        this.vector2D_0 = offset;
        this.list_0.AddRange((IEnumerable<double>) dashLengths);
      }

      public double Angle
      {
        get
        {
          return this.double_0;
        }
        set
        {
          this.double_0 = value;
        }
      }

      public WW.Math.Point2D BasePoint
      {
        get
        {
          return this.point2D_0;
        }
        set
        {
          this.point2D_0 = value;
        }
      }

      public List<double> DashLengths
      {
        get
        {
          return this.list_0;
        }
      }

      public Vector2D Offset
      {
        get
        {
          return this.vector2D_0;
        }
        set
        {
          this.vector2D_0 = value;
        }
      }

      public DxfPattern.Line Clone()
      {
        DxfPattern.Line line = new DxfPattern.Line();
        line.CopyFrom(this);
        return line;
      }

      public void CopyFrom(DxfPattern.Line from)
      {
        this.double_0 = from.double_0;
        this.point2D_0 = from.point2D_0;
        this.vector2D_0 = from.vector2D_0;
        this.list_0.AddRange((IEnumerable<double>) from.list_0);
      }

      public DxfPattern.Line GetTransformed(Matrix4D transform)
      {
        return this.GetTransformed(Transformation3D.From(transform));
      }

      public DxfPattern.Line GetTransformed(Matrix3D transform)
      {
        DxfPattern.Line line = this.Clone();
        line.TransformMe(new TransformConfig(), transform);
        return line;
      }

      internal void TransformMe(TransformConfig config, Matrix4D transform)
      {
        this.TransformMe(config, transform, (CommandGroup) null);
      }

      internal void TransformMe(TransformConfig config, Matrix4D transform, CommandGroup undoGroup)
      {
        this.TransformMe(config, Transformation3D.From(transform), undoGroup);
      }

      internal void TransformMe(TransformConfig config, Matrix3D transform)
      {
        this.TransformMe(config, transform, (CommandGroup) null);
      }

      internal void TransformMe(TransformConfig config, Matrix3D transform, CommandGroup undoGroup)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfPattern.Line.Class465 class465 = new DxfPattern.Line.Class465();
        // ISSUE: reference to a compiler-generated field
        class465.line_0 = this;
        TransformConfig.HatchPatternTransform hatchPatternHandling = config.HatchPatternHandling;
        if (hatchPatternHandling == TransformConfig.HatchPatternTransform.DontTransform)
          return;
        // ISSUE: reference to a compiler-generated field
        class465.double_0 = this.double_0;
        // ISSUE: reference to a compiler-generated field
        class465.point2D_0 = this.point2D_0;
        // ISSUE: reference to a compiler-generated field
        class465.vector2D_0 = this.vector2D_0;
        // ISSUE: reference to a compiler-generated field
        class465.list_0 = new List<double>((IEnumerable<double>) this.list_0);
        Vector2D vector = new Vector2D(System.Math.Cos(this.double_0), System.Math.Sin(this.double_0));
        if (hatchPatternHandling == TransformConfig.HatchPatternTransform.CompleteTransform)
        {
          Vector2D vector2D = transform.Transform(vector);
          // ISSUE: reference to a compiler-generated field
          class465.double_1 = System.Math.Atan2(vector2D.Y, vector2D.X);
          double length = vector2D.GetLength();
          // ISSUE: reference to a compiler-generated field
          class465.point2D_1 = transform.Transform(this.point2D_0);
          // ISSUE: reference to a compiler-generated field
          class465.vector2D_1 = transform.Transform(this.vector2D_0);
          // ISSUE: reference to a compiler-generated field
          class465.list_1 = new List<double>(this.list_0.Count);
          foreach (double num in this.list_0)
          {
            // ISSUE: reference to a compiler-generated field
            class465.list_1.Add(length * num);
          }
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          class465.double_1 = this.double_0;
          // ISSUE: reference to a compiler-generated field
          class465.point2D_1 = this.point2D_0 + (Vector2D) transform.Transform(WW.Math.Point2D.Zero);
          // ISSUE: reference to a compiler-generated field
          class465.vector2D_1 = this.vector2D_0;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          class465.list_1 = class465.list_0;
        }
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup?.UndoStack.Push((ICommand) new Command((object) this, new System.Action(class465.method_0), new System.Action(class465.method_1)));
        // ISSUE: reference to a compiler-generated field
        this.double_0 = class465.double_1;
        // ISSUE: reference to a compiler-generated field
        this.point2D_0 = class465.point2D_1;
        // ISSUE: reference to a compiler-generated field
        this.vector2D_0 = class465.vector2D_1;
        this.list_0.Clear();
        // ISSUE: reference to a compiler-generated field
        this.list_0.AddRange((IEnumerable<double>) class465.list_1);
      }

      internal List<Polyline2D> method_0(
        Polyline2D[] boundaries,
        WW.Math.Point2D seed,
        bool fillInterior)
      {
        if (this.list_0 == null)
        {
          Vector2D vector2D = new Vector2D(System.Math.Cos(this.double_0), System.Math.Sin(this.double_0));
          double distance = System.Math.Abs(this.vector2D_0.X * vector2D.Y - this.vector2D_0.Y * vector2D.X);
          return Class811.smethod_0(boundaries, seed + (Vector2D) this.point2D_0, this.double_0, distance, fillInterior);
        }
        double[] dashPattern = new double[this.list_0.Count];
        int num1 = 0;
        foreach (double num2 in this.list_0)
          dashPattern[num1++] = num2;
        return Class811.smethod_3(boundaries, seed + (Vector2D) this.point2D_0, this.vector2D_0, new Vector2D(System.Math.Cos(this.double_0), System.Math.Sin(this.double_0)), dashPattern, fillInterior);
      }

      internal void Read(DxfReader r)
      {
        bool flag1 = false;
        bool flag2 = true;
        do
        {
          switch (r.CurrentGroup.Code)
          {
            case 43:
              this.point2D_0.X = (double) r.CurrentGroup.Value;
              goto case 79;
            case 44:
              this.point2D_0.Y = (double) r.CurrentGroup.Value;
              goto case 79;
            case 45:
              this.vector2D_0.X = (double) r.CurrentGroup.Value;
              goto case 79;
            case 46:
              this.vector2D_0.Y = (double) r.CurrentGroup.Value;
              goto case 79;
            case 49:
              this.DashLengths.Add((double) r.CurrentGroup.Value);
              goto case 79;
            case 53:
              if (flag1)
              {
                flag2 = false;
                goto case 79;
              }
              else
              {
                this.double_0 = (double) r.CurrentGroup.Value * (System.Math.PI / 180.0);
                flag1 = true;
                goto case 79;
              }
            case 79:
              if (flag2)
                r.method_85();
              continue;
            default:
              flag2 = false;
              goto case 79;
          }
        }
        while (flag2);
      }
    }
  }
}
