// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfPolygonSplineMesh
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns33;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfPolygonSplineMesh : DxfPolygonMeshBase
  {
    private readonly DxfHandledObjectCollection<DxfVertex3D> dxfHandledObjectCollection_2 = new DxfHandledObjectCollection<DxfVertex3D>();
    private readonly DxfHandledObjectCollection<DxfVertex3D> dxfHandledObjectCollection_1;
    private ushort ushort_0;
    private ushort ushort_1;
    private ushort ushort_2;
    private ushort ushort_3;
    private SplineType splineType_0;

    public DxfPolygonSplineMesh()
      : this(SplineType.CubicBSpline)
    {
    }

    public DxfPolygonSplineMesh(SplineType splineType)
    {
      this.splineType_0 = splineType;
      this.dxfHandledObjectCollection_1 = new DxfHandledObjectCollection<DxfVertex3D>();
    }

    public DxfPolygonSplineMesh(ushort mControlPointCount, ushort nControlPointCount)
      : this(SplineType.CubicBSpline, mControlPointCount, nControlPointCount)
    {
    }

    public DxfPolygonSplineMesh(
      SplineType splineType,
      ushort mControlPointCount,
      ushort nControlPointCount)
    {
      this.splineType_0 = splineType;
      this.dxfHandledObjectCollection_1 = new DxfHandledObjectCollection<DxfVertex3D>((int) mControlPointCount * (int) nControlPointCount);
    }

    public IList<DxfVertex3D> ControlPoints
    {
      get
      {
        return (IList<DxfVertex3D>) this.dxfHandledObjectCollection_1;
      }
    }

    public IList<DxfVertex3D> ApproximationPoints
    {
      get
      {
        return (IList<DxfVertex3D>) this.dxfHandledObjectCollection_2;
      }
    }

    public ushort MControlPointCount
    {
      get
      {
        return this.ushort_0;
      }
      set
      {
        this.ushort_0 = value;
      }
    }

    public ushort NControlPointCount
    {
      get
      {
        return this.ushort_1;
      }
      set
      {
        this.ushort_1 = value;
      }
    }

    public SplineType SplineType
    {
      get
      {
        return this.splineType_0;
      }
      set
      {
        this.splineType_0 = value;
      }
    }

    public ushort SmoothSurfaceMDensity
    {
      get
      {
        return this.ushort_2;
      }
      set
      {
        this.ushort_2 = value;
      }
    }

    public ushort SmoothSurfaceNDensity
    {
      get
      {
        return this.ushort_3;
      }
      set
      {
        this.ushort_3 = value;
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
      foreach (DxfEntity dxfEntity in this.dxfHandledObjectCollection_1)
        dxfEntity.TransformMe(config, matrix, undoGroup);
      foreach (DxfEntity dxfEntity in this.dxfHandledObjectCollection_2)
        dxfEntity.TransformMe(config, matrix, undoGroup);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      bool fill;
      IList<Polyline4D> polylines4D;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), out fill, out polylines4D);
      if (polylines4D.Count <= 0)
        return;
      graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, polylines4D, fill, true);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      bool fill;
      IList<Polyline4D> polylines4D;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), out fill, out polylines4D);
      if (polylines4D.Count <= 0)
        return;
      Class940.smethod_3((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, fill, !fill, polylines4D);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      ushort mApproximationPointCount;
      ushort nApproximationPointCount;
      this.method_13(out mApproximationPointCount, out nApproximationPointCount);
      WW.Math.Point3D[,] point3DArray = this.method_19((int) mApproximationPointCount - 1, (int) nApproximationPointCount - 1);
      int length1 = point3DArray.GetLength(0);
      int length2 = point3DArray.GetLength(1);
      Vector4D[,] polygonMesh = new Vector4D[length1, length2];
      Interface41 transformer = context.GetTransformer();
      for (int index1 = 0; index1 < length1; ++index1)
      {
        for (int index2 = 0; index2 < length2; ++index2)
          polygonMesh[index1, index2] = transformer.Transform(point3DArray[index1, index2]);
      }
      graphicsFactory.SetColor(context.GetPlotColor((DxfEntity) this));
      graphicsFactory.CreatePolygonMesh(polygonMesh, this.ClosedInMDirection, this.ClosedInNDirection);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      ushort mApproximationPointCount;
      ushort nApproximationPointCount;
      this.method_13(out mApproximationPointCount, out nApproximationPointCount);
      if (mApproximationPointCount <= (ushort) 0 || nApproximationPointCount <= (ushort) 0)
        return;
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      if (!graphics.AddExistingGraphicElement1(parentGraphicElementBlock, (DxfEntity) this, plotColor))
        return;
      GraphicElement1 graphicElement = new GraphicElement1(plotColor);
      graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, graphicElement);
      WW.Math.Point3D[,] mesh = this.method_19((int) mApproximationPointCount - 1, (int) nApproximationPointCount - 1);
      graphicElement.Geometry.Add((IPrimitive) new PolygonMesh(mesh, this.ClosedInMDirection, this.ClosedInNDirection));
    }

    public void RecalculateApproximationPoints(
      ushort mApproximationPointCount,
      ushort nApproximationPointCount)
    {
      if (this.method_17())
        return;
      WW.Math.Point3D[,] point3DArray = this.method_19((int) mApproximationPointCount - 1, (int) nApproximationPointCount - 1);
      this.ushort_2 = (ushort) point3DArray.GetLength(0);
      this.ushort_3 = (ushort) point3DArray.GetLength(1);
      this.dxfHandledObjectCollection_2.Clear();
      for (int index1 = 0; index1 < (int) mApproximationPointCount; ++index1)
      {
        for (int index2 = 0; index2 < (int) nApproximationPointCount; ++index2)
          this.dxfHandledObjectCollection_2.Add(new DxfVertex3D(point3DArray[index1, index2]));
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfPolygonSplineMesh polygonSplineMesh = (DxfPolygonSplineMesh) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (polygonSplineMesh == null)
      {
        polygonSplineMesh = new DxfPolygonSplineMesh();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) polygonSplineMesh);
        polygonSplineMesh.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) polygonSplineMesh;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfPolygonSplineMesh polygonSplineMesh = (DxfPolygonSplineMesh) from;
      this.ushort_0 = polygonSplineMesh.ushort_0;
      this.ushort_1 = polygonSplineMesh.ushort_1;
      this.ushort_2 = polygonSplineMesh.ushort_2;
      this.ushort_3 = polygonSplineMesh.ushort_3;
      DxfPolygonSplineMesh.Clone((IList<DxfVertex3D>) polygonSplineMesh.dxfHandledObjectCollection_1, (IList<DxfVertex3D>) this.dxfHandledObjectCollection_1, cloneContext);
      DxfPolygonSplineMesh.Clone((IList<DxfVertex3D>) polygonSplineMesh.dxfHandledObjectCollection_2, (IList<DxfVertex3D>) this.dxfHandledObjectCollection_2, cloneContext);
      this.splineType_0 = polygonSplineMesh.splineType_0;
    }

    protected internal override void ExecuteDeepHelper(
      Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in this.dxfHandledObjectCollection_1)
        dxfHandledObject.vmethod_0(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in this.dxfHandledObjectCollection_2)
        dxfHandledObject.vmethod_0(action, callerStack);
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    private void method_13(out ushort mApproximationPointCount, out ushort nApproximationPointCount)
    {
      mApproximationPointCount = this.SmoothSurfaceMDensity;
      if (mApproximationPointCount == (ushort) 0)
        mApproximationPointCount = (ushort) ((uint) this.Model.Header.NumberOfSplineSegments + 1U);
      nApproximationPointCount = this.SmoothSurfaceNDensity;
      if (nApproximationPointCount != (ushort) 0)
        return;
      nApproximationPointCount = (ushort) ((uint) this.Model.Header.NumberOfSplineSegments + 1U);
    }

    private void GetPolylines4D(
      DrawContext context,
      IClippingTransformer transformer,
      out bool fill,
      out IList<Polyline4D> polylines4D)
    {
      DxfHeader header = context.Model.Header;
      GraphicsConfig config = context.Config;
      IList<WW.Math.Geometry.Polyline3D> polylines = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>();
      fill = false;
      if (header.ShowSplineControlPoints || config.ShowSplineControlPoints)
        this.method_14(polylines);
      if (config.ShowSplineApproximationPoints)
        this.method_15(polylines);
      if (!header.ShowSplineControlPoints || config.ShowSplineInterpolatedPoints)
      {
        int splineLineSegments = (int) context.Config.NoOfSplineLineSegments;
        this.method_18(polylines, splineLineSegments, splineLineSegments);
      }
      IClippingTransformer transformer1 = (IClippingTransformer) transformer.Clone();
      transformer1.SetPreTransform(this.Transform);
      polylines4D = DxfUtil.smethod_36(polylines, false, transformer1);
    }

    private static void Clone(
      IList<DxfVertex3D> from,
      IList<DxfVertex3D> to,
      CloneContext cloneContext)
    {
      to.Clear();
      foreach (DxfVertex3D dxfVertex3D1 in (IEnumerable<DxfVertex3D>) from)
      {
        if (dxfVertex3D1 == null)
        {
          to.Add((DxfVertex3D) null);
        }
        else
        {
          DxfVertex3D dxfVertex3D2 = (DxfVertex3D) dxfVertex3D1.Clone(cloneContext);
          to.Add(dxfVertex3D2);
        }
      }
    }

    private void method_14(IList<WW.Math.Geometry.Polyline3D> polylines)
    {
      this.GetSurface(polylines, (IList<DxfVertex3D>) this.dxfHandledObjectCollection_1, (int) this.ushort_0, (int) this.ushort_1);
    }

    private void method_15(IList<WW.Math.Geometry.Polyline3D> polylines)
    {
      this.GetSurface(polylines, (IList<DxfVertex3D>) this.dxfHandledObjectCollection_2, (int) this.ushort_2, (int) this.ushort_3);
    }

    private WW.Math.Point3D[,] method_16()
    {
      if (this.dxfHandledObjectCollection_2 == null)
        return new WW.Math.Point3D[0, 0];
      int ushort2 = (int) this.ushort_2;
      int ushort3 = (int) this.ushort_3;
      WW.Math.Point3D[,] point3DArray = new WW.Math.Point3D[ushort2, ushort3];
      int index1 = 0;
      for (int index2 = 0; index2 < ushort2; ++index2)
      {
        int index3 = 0;
        while (index3 < ushort3)
        {
          point3DArray[index2, index3] = this.dxfHandledObjectCollection_2[index1].Position;
          ++index3;
          ++index1;
        }
      }
      return point3DArray;
    }

    private bool method_17()
    {
      if (this.MControlPointCount != (ushort) 0 && this.NControlPointCount != (ushort) 0)
        return this.dxfHandledObjectCollection_1.Count == 0;
      return true;
    }

    private void method_18(
      IList<WW.Math.Geometry.Polyline3D> polylines,
      int mNoOfSplineLineParts,
      int nNoOfSplineLineParts)
    {
      if (this.method_17())
      {
        this.method_15(polylines);
      }
      else
      {
        switch (this.splineType_0)
        {
          case SplineType.QuadraticBSpline:
            this.method_20(polylines, 2, mNoOfSplineLineParts, nNoOfSplineLineParts);
            break;
          case SplineType.CubicBSpline:
            this.method_20(polylines, 3, mNoOfSplineLineParts, nNoOfSplineLineParts);
            break;
          case SplineType.Bezier:
            this.method_22(polylines, mNoOfSplineLineParts, nNoOfSplineLineParts);
            break;
        }
      }
    }

    private WW.Math.Point3D[,] method_19(int mNoOfSplineLineParts, int nNoOfSplineLineParts)
    {
      if (this.method_17())
        return this.method_16();
      switch (this.splineType_0)
      {
        case SplineType.QuadraticBSpline:
          return this.method_21(2, mNoOfSplineLineParts, nNoOfSplineLineParts);
        case SplineType.CubicBSpline:
          return this.method_21(3, mNoOfSplineLineParts, nNoOfSplineLineParts);
        case SplineType.Bezier:
          return this.method_23(mNoOfSplineLineParts, nNoOfSplineLineParts);
        default:
          return (WW.Math.Point3D[,]) null;
      }
    }

    private void method_20(
      IList<WW.Math.Geometry.Polyline3D> polylines,
      int power,
      int mNoOfSplineLineParts,
      int nNoOfSplineLineParts)
    {
      bool closedInMdirection = this.ClosedInMDirection;
      bool closedInNdirection = this.ClosedInNDirection;
      WW.Math.Point3D[,] point3DArray = this.method_21(power, mNoOfSplineLineParts, nNoOfSplineLineParts);
      int length1 = point3DArray.GetLength(0);
      int length2 = point3DArray.GetLength(1);
      for (int index1 = 0; index1 < length1; ++index1)
      {
        WW.Math.Geometry.Polyline3D polyline3D = new WW.Math.Geometry.Polyline3D(closedInNdirection);
        polylines.Add(polyline3D);
        for (int index2 = 0; index2 < length2; ++index2)
          polyline3D.Add(point3DArray[index1, index2]);
      }
      for (int index1 = 0; index1 < length2; ++index1)
      {
        WW.Math.Geometry.Polyline3D polyline3D = new WW.Math.Geometry.Polyline3D(closedInMdirection);
        polylines.Add(polyline3D);
        for (int index2 = 0; index2 < length1; ++index2)
          polyline3D.Add(point3DArray[index2, index1]);
      }
    }

    private WW.Math.Point3D[,] method_21(
      int power,
      int mNoOfSplineLineParts,
      int nNoOfSplineLineParts)
    {
      int mcontrolPointCount = (int) this.MControlPointCount;
      int ncontrolPointCount = (int) this.NControlPointCount;
      bool closedInMdirection = this.ClosedInMDirection;
      BSplineD bsplineD1 = new BSplineD(power, mcontrolPointCount, closedInMdirection);
      double maxU1 = bsplineD1.MaxU;
      int length1 = mNoOfSplineLineParts + 1;
      double num1 = maxU1 / (double) (length1 - 1);
      BSplineD bsplineD2 = new BSplineD(power, ncontrolPointCount, this.ClosedInNDirection);
      double maxU2 = bsplineD2.MaxU;
      int length2 = nNoOfSplineLineParts + 1;
      double num2 = maxU2 / (double) (length2 - 1);
      double[] result1 = new double[power + 1];
      double[] result2 = new double[power + 1];
      WW.Math.Point3D[,] point3DArray = new WW.Math.Point3D[length1, length2];
      int index1 = 0;
      double u1 = 0.0;
      while (index1 < length1)
      {
        int knotSpanIndex1 = bsplineD1.GetKnotSpanIndex(u1);
        bsplineD1.EvaluateBasisFunctions(knotSpanIndex1, u1, result1);
        int index2 = 0;
        double u2 = 0.0;
        while (index2 < length2)
        {
          int knotSpanIndex2 = bsplineD2.GetKnotSpanIndex(u2);
          bsplineD2.EvaluateBasisFunctions(knotSpanIndex2, u2, result2);
          WW.Math.Point3D zero1 = WW.Math.Point3D.Zero;
          for (int index3 = 0; index3 < power + 1; ++index3)
          {
            int num3 = (knotSpanIndex1 - power + index3) % mcontrolPointCount * ncontrolPointCount;
            Vector3D zero2 = Vector3D.Zero;
            for (int index4 = 0; index4 < power + 1; ++index4)
            {
              int num4 = (knotSpanIndex2 - power + index4) % ncontrolPointCount;
              DxfVertex3D dxfVertex3D = this.dxfHandledObjectCollection_1[num3 + num4];
              zero2 += result2[index4] * (Vector3D) dxfVertex3D.Position;
            }
            zero1 += result1[index3] * zero2;
          }
          point3DArray[index1, index2] = zero1;
          ++index2;
          u2 += num2;
        }
        ++index1;
        u1 += num1;
      }
      return point3DArray;
    }

    private void method_22(
      IList<WW.Math.Geometry.Polyline3D> polylines,
      int mNoOfSplineLineParts,
      int nNoOfSplineLineParts)
    {
      WW.Math.Point3D[,] point3DArray = this.method_23(mNoOfSplineLineParts, nNoOfSplineLineParts);
      int length1 = point3DArray.GetLength(0);
      int length2 = point3DArray.GetLength(1);
      bool closedInNdirection = this.ClosedInNDirection;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        WW.Math.Geometry.Polyline3D polyline3D = new WW.Math.Geometry.Polyline3D(closedInNdirection);
        polylines.Add(polyline3D);
        for (int index2 = 0; index2 < length2; ++index2)
          polyline3D.Add(point3DArray[index1, index2]);
      }
      bool closedInMdirection = this.ClosedInMDirection;
      for (int index1 = 0; index1 < length2; ++index1)
      {
        WW.Math.Geometry.Polyline3D polyline3D = new WW.Math.Geometry.Polyline3D(closedInMdirection);
        polylines.Add(polyline3D);
        for (int index2 = 0; index2 < length1; ++index2)
          polyline3D.Add(point3DArray[index2, index1]);
      }
    }

    private WW.Math.Point3D[,] method_23(int mNoOfSplineLineParts, int nNoOfSplineLineParts)
    {
      int mcontrolPointCount = (int) this.MControlPointCount;
      int ncontrolPointCount = (int) this.NControlPointCount;
      int power1 = mcontrolPointCount - 1;
      BSplineD bsplineD1 = new BSplineD(power1, mcontrolPointCount, false);
      int length1 = mNoOfSplineLineParts + 1;
      double num1 = 1.0 / (double) (length1 - 1);
      int power2 = ncontrolPointCount - 1;
      BSplineD bsplineD2 = new BSplineD(power2, ncontrolPointCount, false);
      int length2 = nNoOfSplineLineParts + 1;
      double num2 = 1.0 / (double) (length2 - 1);
      double[] result1 = new double[power1 + 1];
      double[] result2 = new double[power2 + 1];
      WW.Math.Point3D[,] point3DArray = new WW.Math.Point3D[length1, length2];
      int index1 = 0;
      double u1 = 0.0;
      while (index1 < length1)
      {
        int knotSpanIndex1 = bsplineD1.GetKnotSpanIndex(u1);
        bsplineD1.EvaluateBasisFunctions(knotSpanIndex1, u1, result1);
        int index2 = 0;
        double u2 = 0.0;
        while (index2 < length2)
        {
          int knotSpanIndex2 = bsplineD2.GetKnotSpanIndex(u2);
          bsplineD2.EvaluateBasisFunctions(knotSpanIndex2, u2, result2);
          WW.Math.Point3D zero1 = WW.Math.Point3D.Zero;
          for (int index3 = 0; index3 < power1 + 1; ++index3)
          {
            int num3 = (knotSpanIndex1 - power1 + index3) % mcontrolPointCount * ncontrolPointCount;
            Vector3D zero2 = Vector3D.Zero;
            for (int index4 = 0; index4 < power2 + 1; ++index4)
            {
              int num4 = (knotSpanIndex2 - power2 + index4) % ncontrolPointCount;
              DxfVertex3D dxfVertex3D = this.dxfHandledObjectCollection_1[num3 + num4];
              zero2 += result2[index4] * (Vector3D) dxfVertex3D.Position;
            }
            zero1 += result1[index3] * zero2;
          }
          point3DArray[index1, index2] = zero1;
          ++index2;
          u2 += num2;
        }
        ++index1;
        u1 += num1;
      }
      return point3DArray;
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      foreach (DxfVertex3D dxfVertex3D in this.dxfHandledObjectCollection_1)
      {
        if (dxfVertex3D != null)
        {
          dxfVertex3D.vmethod_2((IDxfHandledObject) this);
          dxfVertex3D.vmethod_1(context);
        }
      }
      ushort mApproximationPointCount;
      ushort nApproximationPointCount;
      this.method_13(out mApproximationPointCount, out nApproximationPointCount);
      this.ushort_2 = mApproximationPointCount;
      this.ushort_3 = nApproximationPointCount;
      this.RecalculateApproximationPoints(mApproximationPointCount, nApproximationPointCount);
      foreach (DxfVertex3D dxfVertex3D in this.dxfHandledObjectCollection_2)
      {
        if (dxfVertex3D != null)
        {
          dxfVertex3D.vmethod_2((IDxfHandledObject) this);
          dxfVertex3D.vmethod_1(context);
        }
      }
    }
  }
}
