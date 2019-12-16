// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfPolyfaceMesh
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
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
  public class DxfPolyfaceMesh : DxfPolylineBase
  {
    private DxfVertex3DCollection dxfVertex3DCollection_0 = new DxfVertex3DCollection();
    private List<DxfMeshFace> list_0 = new List<DxfMeshFace>();

    public DxfPolyfaceMesh()
    {
    }

    public DxfPolyfaceMesh(EntityColor color)
    {
      this.Color = color;
    }

    public List<DxfMeshFace> Faces
    {
      get
      {
        return this.list_0;
      }
    }

    public DxfVertex3DCollection Vertices
    {
      get
      {
        return this.dxfVertex3DCollection_0;
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbPolyFaceMesh";
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
      foreach (DxfEntity dxfEntity in (DxfHandledObjectCollection<DxfVertex3D>) this.dxfVertex3DCollection_0)
        dxfEntity.TransformMe(config, matrix, undoGroup);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      IList<Polyline4D> polylines4D;
      bool fill;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), out polylines4D, out fill);
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
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), out polylines4D, out fill);
      if (polylines4D.Count <= 0)
        return;
      Class940.smethod_3((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, fill, !fill, polylines4D);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      if (this.list_0.Count <= 0)
        return;
      graphicsFactory.SetColor(context.GetPlotColor((DxfEntity) this));
      foreach (DxfMeshFace dxfMeshFace in this.list_0)
      {
        WW.Math.Geometry.Polyline3D boundary = new WW.Math.Geometry.Polyline3D(4);
        List<bool> edgeVisibleList = new List<bool>(4);
        foreach (DxfMeshFace.Corner corner in dxfMeshFace.Corners)
        {
          if (corner.Vertex != null)
          {
            boundary.Add(corner.Vertex.Position);
            edgeVisibleList.Add(corner.EdgeVisible);
          }
        }
        Class940.smethod_18((DxfEntity) this, context, graphicsFactory, boundary, edgeVisibleList);
      }
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      if (this.list_0.Count <= 0)
        return;
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      if (!graphics.AddExistingGraphicElement1(parentGraphicElementBlock, (DxfEntity) this, plotColor))
        return;
      GraphicElement1 graphicElement = new GraphicElement1(plotColor);
      graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, graphicElement);
      List<WW.Math.Point3D> point3DList = new List<WW.Math.Point3D>(4);
      foreach (DxfMeshFace dxfMeshFace in this.list_0)
      {
        point3DList.Clear();
        foreach (DxfMeshFace.Corner corner in dxfMeshFace.Corners)
        {
          if (corner.Vertex != null)
            point3DList.Add(corner.Vertex.Position);
        }
        Class940.smethod_22(graphicElement.Geometry, (IList<WW.Math.Point3D>) point3DList);
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfPolyfaceMesh dxfPolyfaceMesh = (DxfPolyfaceMesh) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfPolyfaceMesh == null)
      {
        dxfPolyfaceMesh = new DxfPolyfaceMesh();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfPolyfaceMesh);
        dxfPolyfaceMesh.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfPolyfaceMesh;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfPolyfaceMesh dxfPolyfaceMesh = (DxfPolyfaceMesh) from;
      Dictionary<DxfVertex3D, int> fromVertexToIndex = new Dictionary<DxfVertex3D, int>();
      int num = 0;
      foreach (DxfVertex3D key in (DxfHandledObjectCollection<DxfVertex3D>) dxfPolyfaceMesh.dxfVertex3DCollection_0)
      {
        this.dxfVertex3DCollection_0.Add((DxfVertex3D) key.Clone(cloneContext));
        fromVertexToIndex.Add(key, num);
        ++num;
      }
      foreach (DxfMeshFace dxfMeshFace in dxfPolyfaceMesh.list_0)
        this.list_0.Add(dxfMeshFace.Clone(cloneContext, this, fromVertexToIndex));
    }

    protected internal override void ExecuteDeepHelper(
      Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfVertex3D>) this.dxfVertex3DCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in this.list_0)
        dxfHandledObject.vmethod_0(action, callerStack);
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override short vmethod_6(Class432 w)
    {
      return 29;
    }

    internal override short vmethod_14(Class432 ow)
    {
      return 13;
    }

    private void method_13(IList<WW.Math.Geometry.Polyline3D> polylines)
    {
      foreach (DxfMeshFace dxfMeshFace in this.list_0)
      {
        int count = dxfMeshFace.Corners.Count;
        if (count > 0)
        {
          DxfMeshFace.Corner corner1 = dxfMeshFace.Corners[0];
          int num;
          switch (count)
          {
            case 1:
              WW.Math.Geometry.Polyline3D polyline3D1 = new WW.Math.Geometry.Polyline3D(new WW.Math.Point3D[1]{ corner1.Vertex.Position });
              polylines.Add(polyline3D1);
              continue;
            case 2:
              num = 1;
              break;
            default:
              num = count;
              break;
          }
          for (int index = 0; index < num; ++index)
          {
            DxfMeshFace.Corner corner2 = dxfMeshFace.Corners[(index + 1) % count];
            if (corner1.EdgeVisible)
            {
              WW.Math.Geometry.Polyline3D polyline3D2 = new WW.Math.Geometry.Polyline3D();
              polylines.Add(polyline3D2);
              if (corner1.Vertex != null)
                polyline3D2.Add(corner1.Vertex.Position);
              if (corner2.Vertex != null)
                polyline3D2.Add(corner2.Vertex.Position);
            }
            corner1 = corner2;
          }
        }
      }
    }

    private new Matrix4D Transform
    {
      get
      {
        return Matrix4D.Identity;
      }
    }

    private void GetPolylines4D(
      DrawContext context,
      IClippingTransformer transformer,
      out IList<Polyline4D> polylines4D,
      out bool fill)
    {
      DxfHeader header = context.Model.Header;
      GraphicsConfig config = context.Config;
      IList<WW.Math.Geometry.Polyline3D> polylines = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>();
      fill = false;
      this.method_13(polylines);
      DxfUtil.Transform(polylines, this.Transform);
      polylines4D = DxfUtil.smethod_36(polylines, false, transformer);
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      foreach (DxfVertex3D dxfVertex3D in (DxfHandledObjectCollection<DxfVertex3D>) this.dxfVertex3DCollection_0)
      {
        dxfVertex3D.vmethod_2((IDxfHandledObject) this);
        dxfVertex3D.vmethod_1(context);
      }
      foreach (DxfMeshFace dxfMeshFace in this.list_0)
      {
        dxfMeshFace.vmethod_2((IDxfHandledObject) this);
        dxfMeshFace.vmethod_1(context);
      }
    }
  }
}
