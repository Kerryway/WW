// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfVertex2D
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using ns28;
using ns36;
using WW.Actions;
using WW.Math;

namespace WW.Cad.Model.Entities
{
  public class DxfVertex2D : DxfVertex, IVertex2D
  {
    private WW.Math.Point2D point2D_0;
    private double double_1;
    private double double_2;
    private double double_3;
    private double double_4;
    private Enum51 enum51_0;
    private int int_0;

    public DxfVertex2D()
    {
    }

    public DxfVertex2D(double x, double y)
    {
      this.point2D_0 = new WW.Math.Point2D(x, y);
    }

    public DxfVertex2D(WW.Math.Point2D position)
    {
      this.point2D_0 = position;
    }

    public double Bulge
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
      }
    }

    public double EndWidth
    {
      get
      {
        return this.double_4;
      }
      set
      {
        this.double_4 = value;
      }
    }

    public WW.Math.Point2D Position
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

    public double StartWidth
    {
      get
      {
        return this.double_3;
      }
      set
      {
        this.double_3 = value;
      }
    }

    public bool HasTangent
    {
      get
      {
        return (this.enum51_0 & Enum51.flag_2) != Enum51.flag_0;
      }
      set
      {
        if (value)
          this.enum51_0 |= Enum51.flag_2;
        else
          this.enum51_0 &= ~Enum51.flag_2;
      }
    }

    public bool IsCurveFitVertex
    {
      get
      {
        return (this.enum51_0 & Enum51.flag_1) != Enum51.flag_0;
      }
      set
      {
        if (value)
          this.enum51_0 |= Enum51.flag_1;
        else
          this.enum51_0 &= ~Enum51.flag_1;
      }
    }

    public bool IsSplineControlPoint
    {
      get
      {
        return (this.enum51_0 & Enum51.flag_5) != Enum51.flag_0;
      }
      set
      {
        if (value)
          this.enum51_0 |= Enum51.flag_5;
        else
          this.enum51_0 &= ~Enum51.flag_5;
      }
    }

    public bool Is3DPolygonMeshVertex
    {
      get
      {
        return (this.enum51_0 & Enum51.flag_7) != Enum51.flag_0;
      }
      set
      {
        if (value)
          this.enum51_0 |= Enum51.flag_7;
        else
          this.enum51_0 &= ~Enum51.flag_7;
      }
    }

    public bool IsPolyfaceMeshVertex
    {
      get
      {
        return (this.enum51_0 & Enum51.flag_8) != Enum51.flag_0;
      }
      set
      {
        if (value)
          this.enum51_0 |= Enum51.flag_8;
        else
          this.enum51_0 &= ~Enum51.flag_8;
      }
    }

    public bool IsFace
    {
      get
      {
        if (this.IsPolyfaceMeshVertex)
          return !this.Is3DPolygonMeshVertex;
        return false;
      }
      set
      {
        if (value)
          this.enum51_0 |= Enum51.flag_7;
        else
          this.enum51_0 &= ~Enum51.flag_7;
      }
    }

    public double TangentDirection
    {
      get
      {
        return this.double_2;
      }
      set
      {
        this.double_2 = value;
      }
    }

    public double X
    {
      get
      {
        return this.point2D_0.X;
      }
      set
      {
        this.point2D_0.X = value;
      }
    }

    public double Y
    {
      get
      {
        return this.point2D_0.Y;
      }
      set
      {
        this.point2D_0.Y = value;
      }
    }

    public int VertexId
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public void TransformMeInOcs(Matrix4D transformationWithOcs, CommandGroup undoGroup)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfVertex2D.Class945 class945 = new DxfVertex2D.Class945();
      // ISSUE: reference to a compiler-generated field
      class945.dxfVertex2D_0 = this;
      // ISSUE: reference to a compiler-generated field
      class945.point2D_0 = this.point2D_0;
      // ISSUE: reference to a compiler-generated field
      class945.double_0 = this.double_2;
      // ISSUE: reference to a compiler-generated field
      class945.double_1 = this.double_3;
      // ISSUE: reference to a compiler-generated field
      class945.double_2 = this.double_4;
      // ISSUE: reference to a compiler-generated field
      class945.double_3 = this.double_1;
      this.point2D_0 = transformationWithOcs.Transform(this.point2D_0);
      Vector2D vector2D = transformationWithOcs.Transform(new Vector2D(System.Math.Cos(this.double_2), System.Math.Sin(this.double_2)));
      this.double_2 = System.Math.Atan2(vector2D.Y, vector2D.X);
      this.double_3 = transformationWithOcs.Transform(new Vector2D(this.double_3, 0.0)).GetLength();
      this.double_4 = transformationWithOcs.Transform(new Vector2D(this.double_4, 0.0)).GetLength();
      if (Class749.smethod_5(transformationWithOcs))
        this.double_1 = -this.double_1;
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfVertex2D.Class946()
      {
        class945_0 = class945,
        point2D_0 = this.point2D_0,
        double_0 = this.double_2,
        double_1 = this.double_3,
        double_2 = this.double_4,
        double_3 = this.double_1
      }.method_0), new System.Action(class945.method_0)));
    }

    public static double GetBulgeFromIncludedAngle(double angle)
    {
      return System.Math.Tan(angle / 4.0);
    }

    public static double GetBulgeFromEndPoints(
      WW.Math.Point2D center,
      WW.Math.Point2D arcStart,
      WW.Math.Point2D arcEnd,
      bool clockWise)
    {
      Vector2D u1 = arcStart - center;
      Vector2D u2 = new Vector2D(-u1.Y, u1.X);
      Vector2D v = arcEnd - center;
      double x = Vector2D.DotProduct(u1, v);
      double num = System.Math.Atan2(Vector2D.DotProduct(u2, v), x);
      if (clockWise)
      {
        if (num > 0.0)
          num -= 2.0 * System.Math.PI;
      }
      else if (num < 0.0)
        num += 2.0 * System.Math.PI;
      return System.Math.Tan(num / 4.0);
    }

    public static WW.Math.Point2D GetArcCenterFromEndPointsAndBulge(
      WW.Math.Point2D arcStart,
      WW.Math.Point2D arcEnd,
      double bulge)
    {
      Vector2D vector2D1 = arcEnd - arcStart;
      double length = vector2D1.GetLength();
      double num1 = 4.0 * System.Math.Atan(bulge);
      double num2 = length / (2.0 * System.Math.Abs(System.Math.Sin(num1 * 0.5)));
      Vector2D vector2D2 = vector2D1;
      vector2D2.Normalize();
      double num3 = (double) System.Math.Sign(bulge);
      Vector2D vector2D3 = new Vector2D(-vector2D2.Y, vector2D2.X) * num3;
      return (WW.Math.Point2D) (((Vector2D) arcEnd + (Vector2D) arcStart) * 0.5) + vector2D3 * System.Math.Cos(num1 * 0.5) * num2;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfVertex2D dxfVertex2D = (DxfVertex2D) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfVertex2D == null)
      {
        dxfVertex2D = new DxfVertex2D();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfVertex2D);
        dxfVertex2D.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfVertex2D;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfVertex2D dxfVertex2D = (DxfVertex2D) from;
      this.point2D_0 = dxfVertex2D.point2D_0;
      this.double_1 = dxfVertex2D.double_1;
      this.double_2 = dxfVertex2D.double_2;
      this.double_3 = dxfVertex2D.double_3;
      this.double_4 = dxfVertex2D.double_4;
      this.enum51_0 = dxfVertex2D.enum51_0;
    }

    public override string ToString()
    {
      return this.point2D_0.ToString();
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override short vmethod_6(Class432 w)
    {
      return 10;
    }

    internal Enum51 Flags
    {
      get
      {
        return this.enum51_0;
      }
      set
      {
        this.enum51_0 = value;
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDb2dVertex";
      }
    }
  }
}
