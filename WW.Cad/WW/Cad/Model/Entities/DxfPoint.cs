// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfPoint
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using ns28;
using ns33;
using System;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Actions;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfPoint : DxfEntity, IControlPointCollection
  {
    private static readonly IControlPoint[] icontrolPoint_0 = new IControlPoint[1]{ DxfPoint.Class419.icontrolPoint_0 };
    private Vector3D vector3D_0 = Vector3D.ZAxis;
    private WW.Math.Point3D point3D_0;
    private double double_1;
    private double double_2;

    public DxfPoint()
    {
    }

    public DxfPoint(double x, double y)
    {
      this.point3D_0 = new WW.Math.Point3D(x, y, 0.0);
    }

    public DxfPoint(double x, double y, double z)
    {
      this.point3D_0 = new WW.Math.Point3D(x, y, z);
    }

    public DxfPoint(EntityColor color, double x, double y, double z)
    {
      this.point3D_0 = new WW.Math.Point3D(x, y, z);
      this.Color = color;
    }

    public DxfPoint(EntityColor color, double x, double y)
    {
      this.Color = color;
      this.point3D_0 = new WW.Math.Point3D(x, y, 0.0);
    }

    public DxfPoint(WW.Math.Point3D position)
    {
      this.point3D_0 = position;
    }

    public DxfPoint(WW.Math.Point2D position)
    {
      this.point3D_0 = (WW.Math.Point3D) position;
    }

    public DxfPoint(EntityColor color, WW.Math.Point3D position)
    {
      this.Color = color;
      this.point3D_0 = position;
    }

    public DxfPoint(EntityColor color, WW.Math.Point2D position)
    {
      this.point3D_0 = (WW.Math.Point3D) position;
      this.Color = color;
    }

    public WW.Math.Point3D Position
    {
      get
      {
        return this.point3D_0;
      }
      set
      {
        this.point3D_0 = value;
      }
    }

    public Vector3D ZAxis
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        this.vector3D_0 = value;
      }
    }

    public double Thickness
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

    public double XAxisAngle
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

    public override string EntityType
    {
      get
      {
        return "POINT";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbPoint";
      }
    }

    public override void TransformMe(TransformConfig config, Matrix4D matrix)
    {
      this.TransformMe(config, matrix, (CommandGroup) null);
    }

    public override void TransformMe(
      TransformConfig config,
      Matrix4D matrix,
      CommandGroup undoGroup)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfPoint.Class420 class420 = new DxfPoint.Class420();
      // ISSUE: reference to a compiler-generated field
      class420.dxfPoint_0 = this;
      // ISSUE: reference to a compiler-generated field
      class420.point3D_0 = this.point3D_0;
      // ISSUE: reference to a compiler-generated field
      class420.vector3D_0 = this.vector3D_0;
      // ISSUE: reference to a compiler-generated field
      class420.double_0 = this.double_1;
      this.point3D_0 = matrix.Transform(this.point3D_0);
      this.vector3D_0 = matrix.Transform(this.vector3D_0);
      this.double_1 *= this.vector3D_0.GetLength();
      this.vector3D_0.Normalize();
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfPoint.Class421()
      {
        class420_0 = class420,
        point3D_0 = this.point3D_0,
        vector3D_0 = this.vector3D_0,
        double_0 = this.double_1
      }.method_0), new System.Action(class420.method_0)));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      PointDisplayMode pointDisplayMode = context.Model.Header.PointDisplayMode;
      bool flag = this.Layer != null && this.Layer == context.DefPointsLayer;
      if (pointDisplayMode == PointDisplayMode.None && !flag)
        return;
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      IClippingTransformer transformer = context.GetTransformer();
      if (this.double_1 != 0.0)
      {
        foreach (Segment4D segment4D in (IEnumerable<Segment4D>) transformer.Transform(new Segment3D(this.point3D_0, this.point3D_0 + this.double_1 * this.vector3D_0)))
          graphicsFactory.CreateLine((DxfEntity) this, context, plotColor, false, segment4D.Start, segment4D.End);
      }
      else if (pointDisplayMode != PointDisplayMode.Point && context.Model.Header.PointDisplaySize > 0.0 && !flag)
      {
        IShape4D shape = transformer.Transform((IShape4D) new FlatShape4D(context.PointShape2D, Transformation4D.Translation(this.point3D_0.X, this.point3D_0.Y, this.point3D_0.Z), false));
        if (shape.IsEmpty)
          return;
        graphicsFactory.CreateShape((DxfEntity) this, context, plotColor, false, shape);
      }
      else
      {
        Vector4D? nullable = transformer.Transform(this.point3D_0);
        if (!nullable.HasValue)
          return;
        graphicsFactory.CreateDot((DxfEntity) this, context, plotColor, false, nullable.Value);
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      PointDisplayMode pointDisplayMode = context.Model.Header.PointDisplayMode;
      bool flag = this.Layer != null && this.Layer == context.DefPointsLayer;
      if (pointDisplayMode == PointDisplayMode.None && !flag)
        return;
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      IClippingTransformer transformer = context.GetTransformer();
      if (this.double_1 != 0.0)
      {
        foreach (Segment4D segment4D in (IEnumerable<Segment4D>) transformer.Transform(new Segment3D(this.point3D_0, this.point3D_0 + this.double_1 * this.vector3D_0)))
        {
          graphicsFactory.BeginGeometry((DxfEntity) this, context, plotColor, false, false, true, true);
          graphicsFactory.CreateLine((DxfEntity) this, segment4D.Start, segment4D.End);
          graphicsFactory.EndGeometry();
        }
      }
      else if (pointDisplayMode != PointDisplayMode.Point && context.Model.Header.PointDisplaySize > 0.0 && !flag)
      {
        IShape4D shape = transformer.Transform((IShape4D) new FlatShape4D(context.PointShape2D, Transformation4D.Translation(this.point3D_0.X, this.point3D_0.Y, this.point3D_0.Z), false));
        if (shape.IsEmpty)
          return;
        graphicsFactory.BeginGeometry((DxfEntity) this, context, plotColor, false, true, false, true);
        graphicsFactory.CreateShape((DxfEntity) this, shape);
        graphicsFactory.EndGeometry();
      }
      else
      {
        Vector4D? nullable = transformer.Transform(this.point3D_0);
        if (!nullable.HasValue)
          return;
        graphicsFactory.BeginGeometry((DxfEntity) this, context, plotColor, false, true, false, true);
        graphicsFactory.CreateDot((DxfEntity) this, nullable.Value);
        graphicsFactory.EndGeometry();
      }
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      PointDisplayMode pointDisplayMode = context.Model.Header.PointDisplayMode;
      bool flag = this.Layer != null && this.Layer == context.DefPointsLayer;
      if (pointDisplayMode == PointDisplayMode.None && !flag)
        return;
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      graphicsFactory.SetColor(plotColor);
      Interface41 transformer = context.GetTransformer();
      if (this.double_1 != 0.0)
        graphicsFactory.CreateSegment(transformer.Transform(this.point3D_0), transformer.Transform(this.point3D_0 + this.double_1 * this.vector3D_0));
      else
        graphicsFactory.CreatePoint(transformer.Transform(this.point3D_0));
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      if (!graphics.AddExistingGraphicElement1(parentGraphicElementBlock, (DxfEntity) this, plotColor))
        return;
      GraphicElement1 graphicElement = new GraphicElement1(plotColor);
      graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, graphicElement);
      if (this.double_1 != 0.0)
        graphicElement.Geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Segment(this.point3D_0, this.point3D_0 + this.double_1 * this.vector3D_0));
      else
        graphicElement.Geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Point(this.point3D_0));
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfPoint dxfPoint = (DxfPoint) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfPoint == null)
      {
        dxfPoint = new DxfPoint();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfPoint);
        dxfPoint.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfPoint;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfPoint dxfPoint = (DxfPoint) from;
      this.point3D_0 = dxfPoint.point3D_0;
      this.vector3D_0 = dxfPoint.vector3D_0;
      this.double_1 = dxfPoint.double_1;
      this.double_2 = dxfPoint.double_2;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IControlPointCollection InteractionControlPoints
    {
      get
      {
        return (IControlPointCollection) this;
      }
    }

    public override DxfEntity.Interactor CreateCreateInteractor(Transaction transaction)
    {
      return (DxfEntity.Interactor) new DxfEntity.DefaultCreateInteractor((DxfEntity) this, (ITransaction) transaction);
    }

    public override DxfEntity.Interactor CreateEditInteractor()
    {
      return (DxfEntity.Interactor) new DxfEntity.DefaultEditInteractor((DxfEntity) this);
    }

    internal override short vmethod_6(Class432 w)
    {
      return 27;
    }

    void IControlPointCollection.Set(int index, WW.Math.Point3D value)
    {
      DxfPoint.icontrolPoint_0[index].SetValue((object) this, value);
    }

    WW.Math.Point3D IControlPointCollection.Get(int index)
    {
      return DxfPoint.icontrolPoint_0[index].GetValue((object) this);
    }

    string IControlPointCollection.GetDescription(int index)
    {
      return DxfPoint.icontrolPoint_0[index].Description;
    }

    PointDisplayType IControlPointCollection.GetDisplayType(
      int index)
    {
      return DxfPoint.icontrolPoint_0[index].DisplayType;
    }

    int IControlPointCollection.Count
    {
      get
      {
        return DxfPoint.icontrolPoint_0.Length;
      }
    }

    bool IControlPointCollection.IsCountFixed
    {
      get
      {
        return true;
      }
    }

    void IControlPointCollection.Insert(int index)
    {
      throw new NotSupportedException();
    }

    void IControlPointCollection.RemoveAt(int index)
    {
      throw new NotSupportedException();
    }

    private class Class419 : IControlPoint
    {
      public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfPoint.Class419();

      private Class419()
      {
      }

      public void SetValue(object owner, WW.Math.Point3D value)
      {
        ((DxfPoint) owner).point3D_0 = value;
      }

      public WW.Math.Point3D GetValue(object owner)
      {
        return ((DxfPoint) owner).point3D_0;
      }

      public string Description
      {
        get
        {
          return Class881.DxfPoint_ControlPoint_Name;
        }
      }

      public PointDisplayType DisplayType
      {
        get
        {
          return PointDisplayType.Default;
        }
      }
    }
  }
}
