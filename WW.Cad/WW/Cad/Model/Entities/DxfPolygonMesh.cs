// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfPolygonMesh
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
  public class DxfPolygonMesh : DxfPolygonMeshBase
  {
    private DxfHandledObjectCollection<DxfVertex3D> dxfHandledObjectCollection_1;
    private ushort ushort_0;
    private ushort ushort_1;

    public DxfPolygonMesh()
    {
      this.dxfHandledObjectCollection_1 = new DxfHandledObjectCollection<DxfVertex3D>();
    }

    public DxfPolygonMesh(ushort mVertexCount, ushort nVertexCount)
    {
      this.ushort_0 = mVertexCount;
      this.ushort_1 = nVertexCount;
      this.dxfHandledObjectCollection_1 = new DxfHandledObjectCollection<DxfVertex3D>((int) mVertexCount * (int) nVertexCount);
    }

    public IList<DxfVertex3D> Vertices
    {
      get
      {
        return (IList<DxfVertex3D>) this.dxfHandledObjectCollection_1;
      }
    }

    public ushort MVertexCount
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

    public ushort NVertexCount
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
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      IList<Polyline4D> polylines4D;
      bool fill;
      this.GetPolylines4D(context.GetTransformer(), out polylines4D, out fill);
      if (polylines4D.Count <= 0)
        return;
      graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, polylines4D, fill, true);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      IList<Polyline4D> polylines4D;
      bool fill;
      this.GetPolylines4D(context.GetTransformer(), out polylines4D, out fill);
      if (polylines4D.Count <= 0)
        return;
      Class940.smethod_3((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, fill, !fill, polylines4D);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      Vector4D[,] polygonMesh = new Vector4D[(int) this.ushort_0, (int) this.ushort_1];
      Interface41 transformer = context.GetTransformer();
      int index1 = 0;
      for (int index2 = 0; index2 < (int) this.ushort_0; ++index2)
      {
        int index3 = 0;
        while (index3 < (int) this.ushort_1)
        {
          polygonMesh[index2, index3] = transformer.Transform(this.dxfHandledObjectCollection_1[index1].Position);
          ++index3;
          ++index1;
        }
      }
      graphicsFactory.SetColor(context.GetPlotColor((DxfEntity) this));
      graphicsFactory.CreatePolygonMesh(polygonMesh, this.ClosedInMDirection, this.ClosedInNDirection);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      int ushort0 = (int) this.ushort_0;
      int ushort1 = (int) this.ushort_1;
      if (ushort0 <= 0 || ushort1 <= 0)
        return;
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      if (!graphics.AddExistingGraphicElement1(parentGraphicElementBlock, (DxfEntity) this, plotColor))
        return;
      GraphicElement1 graphicElement = new GraphicElement1(plotColor);
      graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, graphicElement);
      WW.Math.Point3D[,] mesh = new WW.Math.Point3D[ushort0, ushort1];
      int index1 = 0;
      for (int index2 = 0; index2 < ushort0; ++index2)
      {
        int index3 = 0;
        while (index3 < ushort1)
        {
          mesh[index2, index3] = this.dxfHandledObjectCollection_1[index1].Position;
          ++index3;
          ++index1;
        }
      }
      graphicElement.Geometry.Add((IPrimitive) new PolygonMesh(mesh, this.ClosedInMDirection, this.ClosedInNDirection));
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfPolygonMesh dxfPolygonMesh = (DxfPolygonMesh) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfPolygonMesh == null)
      {
        dxfPolygonMesh = new DxfPolygonMesh();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfPolygonMesh);
        dxfPolygonMesh.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfPolygonMesh;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfPolygonMesh dxfPolygonMesh = (DxfPolygonMesh) from;
      this.ushort_0 = dxfPolygonMesh.ushort_0;
      this.ushort_1 = dxfPolygonMesh.ushort_1;
      this.dxfHandledObjectCollection_1.Clear();
      this.dxfHandledObjectCollection_1.Capacity = dxfPolygonMesh.dxfHandledObjectCollection_1.Count;
      foreach (DxfHandledObject dxfHandledObject in dxfPolygonMesh.dxfHandledObjectCollection_1)
        this.dxfHandledObjectCollection_1.Add((DxfVertex3D) dxfHandledObject.Clone(cloneContext));
    }

    protected internal override void ExecuteDeepHelper(
      Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      foreach (DxfVertex3D dxfVertex3D in this.dxfHandledObjectCollection_1)
        dxfVertex3D?.vmethod_0(action, callerStack);
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    private void method_13(IList<WW.Math.Geometry.Polyline3D> polylines)
    {
      this.GetSurface(polylines, (IList<DxfVertex3D>) this.dxfHandledObjectCollection_1, (int) this.ushort_0, (int) this.ushort_1);
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
    }

    private void GetPolylines4D(
      IClippingTransformer transformer,
      out IList<Polyline4D> polylines4D,
      out bool fill)
    {
      IList<WW.Math.Geometry.Polyline3D> polylines = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>();
      fill = false;
      this.method_13(polylines);
      DxfUtil.Transform(polylines, this.Transform);
      polylines4D = DxfUtil.smethod_36(polylines, false, transformer);
    }
  }
}
