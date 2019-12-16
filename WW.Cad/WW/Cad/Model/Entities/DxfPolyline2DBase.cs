// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfPolyline2DBase
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns1;
using ns28;
using ns33;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public abstract class DxfPolyline2DBase : DxfPolylineBase, IClipBoundaryProvider
  {
    private Vector3D vector3D_0 = Vector3D.ZAxis;
    private double double_1;
    private double double_2;
    private double double_3;
    private double double_4;

    public double Elevation
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

    public double DefaultEndWidth
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

    public double DefaultStartWidth
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

    public double Thickness
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

    public bool Closed
    {
      get
      {
        return (this.Flags & Enum21.flag_1) != Enum21.flag_0;
      }
      set
      {
        if (value)
          this.Flags |= Enum21.flag_1;
        else
          this.Flags &= ~Enum21.flag_1;
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDb2dPolyline";
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
      Matrix4D transformationWithOcs;
      this.method_13(matrix, undoGroup, out transformationWithOcs);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      IList<Polyline4D> polylines4D;
      IList<FlatShape4D> shapes;
      bool fill;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), out polylines4D, out shapes, out fill);
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      if (polylines4D.Count > 0)
        graphicsFactory.CreatePath((DxfEntity) this, context, plotColor, false, polylines4D, fill, true);
      if (shapes == null)
        return;
      IPathDrawer pathDrawer = (IPathDrawer) new ns0.Class0((DxfEntity) this, context, graphicsFactory);
      foreach (FlatShape4D flatShape4D in (IEnumerable<FlatShape4D>) shapes)
        pathDrawer.DrawPath(flatShape4D.FlatShape, flatShape4D.Transformation, this.Color.ToColor(), (short) 0, flatShape4D.IsFilled, false, this.Thickness);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      IList<Polyline4D> polylines4D;
      IList<FlatShape4D> shapes;
      bool fill;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), out polylines4D, out shapes, out fill);
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      if (polylines4D.Count > 0)
        Class940.smethod_3((DxfEntity) this, context, graphicsFactory, plotColor, false, fill, !fill, polylines4D);
      if (shapes == null)
        return;
      IPathDrawer pathDrawer = (IPathDrawer) new Class396((DxfEntity) this, context, graphicsFactory);
      foreach (FlatShape4D flatShape4D in (IEnumerable<FlatShape4D>) shapes)
        pathDrawer.DrawPath(flatShape4D.FlatShape, flatShape4D.Transformation, this.Color.ToColor(), (short) 0, flatShape4D.IsFilled, false, this.Thickness);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      IList<IList<Polyline2D2N>> polylines1;
      IList<IList<Polyline2D2N>> polylines2;
      IList<FlatShape4D> shapes;
      bool fill;
      this.GetPolylines((DrawContext) context, context.GetTransformer().LineTypeScaler, out polylines1, out polylines2, out shapes, out fill);
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      graphicsFactory.SetColor(plotColor);
      int count = polylines1.Count;
      for (int index = 0; index < count; ++index)
      {
        IList<Polyline2D2N> polyline2D2NList = polylines1[index];
        IList<Polyline2D2N> polylinesB = polylines2[index];
        bool flag = this.Thickness != 0.0;
        if (polylinesB == null)
        {
          if (flag)
          {
            Class940.smethod_5((DxfEntity) this, context, graphicsFactory, polyline2D2NList, fill, this.Transform, this.ZAxis, this.Thickness);
          }
          else
          {
            IList<Polyline3D> polyline3DList = (IList<Polyline3D>) new List<Polyline3D>();
            DxfUtil.smethod_15(polyline2D2NList, (IList<Polyline2D2N>) null, this.Transform, polyline3DList, false);
            Class940.smethod_15((DxfEntity) this, context, graphicsFactory, polyline3DList);
          }
        }
        else if (flag)
          Class940.smethod_7((DxfEntity) this, context, graphicsFactory, polyline2D2NList, polylinesB, fill, this.Transform, this.ZAxis, this.Thickness);
        else
          Class940.smethod_10((DxfEntity) this, context, graphicsFactory, polyline2D2NList, polylinesB, this.Transform, this.ZAxis, fill);
        if (shapes != null)
        {
          Class473 class473 = new Class473((DxfEntity) this, context, graphicsFactory);
          foreach (FlatShape4D flatShape4D in (IEnumerable<FlatShape4D>) shapes)
            class473.DrawPath(flatShape4D.FlatShape, flatShape4D.Transformation, this.Color.ToColor(), (short) 0, flatShape4D.IsFilled, false, this.Thickness);
        }
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      throw new DxfException("Not implemented.");
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfPolyline2DBase dxfPolyline2Dbase = (DxfPolyline2DBase) from;
      this.double_1 = dxfPolyline2Dbase.double_1;
      this.vector3D_0 = dxfPolyline2Dbase.vector3D_0;
      this.double_2 = dxfPolyline2Dbase.double_2;
      this.double_3 = dxfPolyline2Dbase.double_3;
      this.double_4 = dxfPolyline2Dbase.double_4;
    }

    public override Matrix4D Transform
    {
      get
      {
        return DxfUtil.GetToWCSTransform(this.vector3D_0) * Transformation4D.Translation(0.0, 0.0, this.double_1);
      }
    }

    internal abstract void GetPolylines(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<IList<Polyline2D>> polylines1,
      out IList<IList<Polyline2D>> polylines2,
      out IList<FlatShape4D> shapes,
      out bool fill);

    internal abstract void GetPolylines(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<IList<Polyline2D2N>> polylines1,
      out IList<IList<Polyline2D2N>> polylines2,
      out IList<FlatShape4D> shapes,
      out bool fill);

    internal void method_13(
      Matrix4D matrix,
      CommandGroup undoGroup,
      out Matrix4D transformationWithOcs)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfPolyline2DBase.Class349 class349 = new DxfPolyline2DBase.Class349();
      // ISSUE: reference to a compiler-generated field
      class349.dxfPolyline2DBase_0 = this;
      Matrix4D transform = this.Transform;
      // ISSUE: reference to a compiler-generated field
      class349.double_0 = this.double_1;
      // ISSUE: reference to a compiler-generated field
      class349.vector3D_0 = this.vector3D_0;
      // ISSUE: reference to a compiler-generated field
      class349.double_1 = this.double_2;
      // ISSUE: reference to a compiler-generated field
      class349.double_2 = this.double_3;
      // ISSUE: reference to a compiler-generated field
      class349.double_3 = this.double_4;
      this.vector3D_0 = matrix.Transform(this.vector3D_0);
      this.double_4 *= this.vector3D_0.GetLength();
      this.vector3D_0.Normalize();
      this.double_1 = (DxfUtil.GetToWCSTransform(this.vector3D_0).GetInverse() * matrix * transform).Transform(WW.Math.Point3D.Zero).Z;
      Matrix4D inverse = this.Transform.GetInverse();
      transformationWithOcs = inverse * matrix * transform;
      this.double_2 = transformationWithOcs.Transform(new Vector2D(this.double_2, 0.0)).GetLength();
      this.double_3 = transformationWithOcs.Transform(new Vector2D(this.double_3, 0.0)).GetLength();
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfPolyline2DBase.Class350()
      {
        class349_0 = class349,
        double_0 = this.double_1,
        vector3D_0 = this.vector3D_0,
        double_1 = this.double_2,
        double_2 = this.double_3,
        double_3 = this.double_4
      }.method_0), new System.Action(class349.method_0)));
    }

    internal override short vmethod_6(Class432 w)
    {
      return 15;
    }

    public abstract IList<Polygon2D> GetClipBoundary(GraphicsConfig graphicsConfig);

    private void GetPolylines4D(
      DrawContext context,
      IClippingTransformer transformer,
      out IList<Polyline4D> polylines4D,
      out IList<FlatShape4D> shapes,
      out bool fill)
    {
      IList<Polyline3D> polylines;
      this.GetPolylines(context, transformer.LineTypeScaler, out polylines, out shapes, out fill);
      fill = fill && this.ZAxis.X == 0.0 && this.ZAxis.Y == 0.0;
      if (this.Thickness != 0.0)
        DxfUtil.Extrude(polylines, this.Thickness, this.ZAxis);
      polylines4D = DxfUtil.smethod_36(polylines, fill, transformer);
    }

    private void GetPolylines(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<Polyline3D> polylines,
      out IList<FlatShape4D> shapes,
      out bool fill)
    {
      IList<IList<Polyline2D>> polylines1;
      IList<IList<Polyline2D>> polylines2;
      this.GetPolylines(context, lineTypeScaler, out polylines1, out polylines2, out shapes, out fill);
      polylines = (IList<Polyline3D>) new List<Polyline3D>();
      int count = polylines1.Count;
      Matrix4D transform = this.Transform;
      if (polylines2 != null && polylines2.Count != 0)
      {
        for (int index = 0; index < count; ++index)
          DxfUtil.smethod_14(polylines1[index], polylines2[index], transform, polylines, true);
      }
      else
      {
        for (int index1 = 0; index1 < count; ++index1)
        {
          IList<Polyline2D> polyline2DList = polylines1[index1];
          for (int index2 = 0; index2 < polylines1.Count; ++index2)
            polylines.Add(DxfUtil.smethod_42(polyline2DList[index2], transform));
        }
      }
    }
  }
}
