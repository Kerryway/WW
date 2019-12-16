// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.Dxf3DFace
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns28;
using ns33;
using System;
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
  public class Dxf3DFace : DxfEntity, IClipBoundaryProvider
  {
    private static readonly InvisibleEdgeFlags[] invisibleEdgeFlags_1 = new InvisibleEdgeFlags[4]{ InvisibleEdgeFlags.First, InvisibleEdgeFlags.Second, InvisibleEdgeFlags.Third, InvisibleEdgeFlags.Fourth };
    private List<WW.Math.Point3D> list_0 = new List<WW.Math.Point3D>(4);
    private InvisibleEdgeFlags invisibleEdgeFlags_0;

    public Dxf3DFace()
    {
    }

    public Dxf3DFace(WW.Math.Point3D p1, WW.Math.Point3D p2, WW.Math.Point3D p3)
    {
      this.list_0.Add(p1);
      this.list_0.Add(p2);
      this.list_0.Add(p3);
    }

    public Dxf3DFace(EntityColor color, WW.Math.Point3D p1, WW.Math.Point3D p2, WW.Math.Point3D p3)
    {
      this.Color = color;
      this.list_0.Add(p1);
      this.list_0.Add(p2);
      this.list_0.Add(p3);
    }

    public Dxf3DFace(WW.Math.Point3D p1, WW.Math.Point3D p2, WW.Math.Point3D p3, WW.Math.Point3D p4)
    {
      this.list_0.Add(p1);
      this.list_0.Add(p2);
      this.list_0.Add(p3);
      this.list_0.Add(p4);
    }

    public Dxf3DFace(EntityColor color, WW.Math.Point3D p1, WW.Math.Point3D p2, WW.Math.Point3D p3, WW.Math.Point3D p4)
    {
      this.Color = color;
      this.list_0.Add(p1);
      this.list_0.Add(p2);
      this.list_0.Add(p3);
      this.list_0.Add(p4);
    }

    public Dxf3DFace(IList<WW.Math.Point3D> points)
    {
      if (points.Count < 3 || points.Count > 4)
        throw new ArgumentException("Points must contain 3 or 4 points, count is " + (object) points.Count);
      for (int index = 0; index < points.Count; ++index)
        this.list_0.Add(points[index]);
    }

    public Dxf3DFace(EntityColor color, IList<WW.Math.Point3D> points)
    {
      if (points.Count < 3 || points.Count > 4)
        throw new ArgumentException("Points must contain 3 or 4 points, count is " + (object) points.Count);
      this.Color = color;
      for (int index = 0; index < points.Count; ++index)
        this.list_0.Add(points[index]);
    }

    public List<WW.Math.Point3D> Points
    {
      get
      {
        return this.list_0;
      }
    }

    public bool FirstEdgeInvisible
    {
      get
      {
        return (this.invisibleEdgeFlags_0 & InvisibleEdgeFlags.First) != InvisibleEdgeFlags.None;
      }
      set
      {
        if (value)
          this.invisibleEdgeFlags_0 |= InvisibleEdgeFlags.First;
        else
          this.invisibleEdgeFlags_0 &= ~InvisibleEdgeFlags.First;
      }
    }

    public bool SecondEdgeInvisible
    {
      get
      {
        return (this.invisibleEdgeFlags_0 & InvisibleEdgeFlags.Second) != InvisibleEdgeFlags.None;
      }
      set
      {
        if (value)
          this.invisibleEdgeFlags_0 |= InvisibleEdgeFlags.Second;
        else
          this.invisibleEdgeFlags_0 &= ~InvisibleEdgeFlags.Second;
      }
    }

    public bool ThirdEdgeInvisible
    {
      get
      {
        return (this.invisibleEdgeFlags_0 & InvisibleEdgeFlags.Third) != InvisibleEdgeFlags.None;
      }
      set
      {
        if (value)
          this.invisibleEdgeFlags_0 |= InvisibleEdgeFlags.Third;
        else
          this.invisibleEdgeFlags_0 &= ~InvisibleEdgeFlags.Third;
      }
    }

    public bool FourthEdgeInvisible
    {
      get
      {
        return (this.invisibleEdgeFlags_0 & InvisibleEdgeFlags.Fourth) != InvisibleEdgeFlags.None;
      }
      set
      {
        if (value)
          this.invisibleEdgeFlags_0 |= InvisibleEdgeFlags.Fourth;
        else
          this.invisibleEdgeFlags_0 &= ~InvisibleEdgeFlags.Fourth;
      }
    }

    public override string EntityType
    {
      get
      {
        return "3DFACE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbFace";
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      IList<Polyline4D> polylines4D;
      IList<IShape4D> shapes;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), out polylines4D, out shapes);
      if (polylines4D.Count > 0)
        graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, polylines4D, false, true);
      if (shapes == null)
        return;
      Class940.smethod_23((IPathDrawer) new ns0.Class0((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      IList<Polyline4D> polylines4D;
      IList<IShape4D> shapes;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), out polylines4D, out shapes);
      if (polylines4D.Count > 0)
        Class940.smethod_3((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, false, true, polylines4D);
      if (shapes == null)
        return;
      Class940.smethod_23((IPathDrawer) new Class396((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      graphicsFactory.SetColor(context.GetPlotColor((DxfEntity) this));
      List<bool> edgeVisibleList = new List<bool>(this.list_0.Count);
      for (int index = 0; index < this.list_0.Count; ++index)
        edgeVisibleList.Add((this.invisibleEdgeFlags_0 & Dxf3DFace.invisibleEdgeFlags_1[index]) == InvisibleEdgeFlags.None);
      Class940.smethod_19((DxfEntity) this, context, graphicsFactory, this.list_0, edgeVisibleList);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      if (this.list_0.Count <= 1 || this.list_0.Count >= 5 || !graphics.AddExistingGraphicElement1(parentGraphicElementBlock, (DxfEntity) this, plotColor))
        return;
      switch (this.list_0.Count)
      {
        case 2:
          if (this.FirstEdgeInvisible)
            break;
          graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, new GraphicElement1(new WW.Cad.Drawing.Surface.Geometry((IPrimitive) new WW.Cad.Drawing.Surface.Segment(this.list_0[0], this.list_0[1])), plotColor));
          break;
        case 3:
          graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, new GraphicElement1(new WW.Cad.Drawing.Surface.Geometry((IPrimitive) new TriangleWithEdges(this.list_0[0], this.list_0[1], this.list_0[2], !this.FirstEdgeInvisible, !this.SecondEdgeInvisible, !this.ThirdEdgeInvisible)), plotColor));
          break;
        case 4:
          graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, new GraphicElement1(new WW.Cad.Drawing.Surface.Geometry((IPrimitive) new QuadWithEdges(this.list_0[0], this.list_0[1], this.list_0[2], this.list_0[3], !this.FirstEdgeInvisible, !this.SecondEdgeInvisible, !this.ThirdEdgeInvisible, !this.FourthEdgeInvisible)), plotColor));
          break;
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      Dxf3DFace dxf3Dface = (Dxf3DFace) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxf3Dface == null)
      {
        dxf3Dface = new Dxf3DFace();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxf3Dface);
        dxf3Dface.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxf3Dface;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      Dxf3DFace dxf3Dface = (Dxf3DFace) from;
      if (this.list_0.Count == dxf3Dface.list_0.Count)
      {
        for (int index = 0; index < this.list_0.Count; ++index)
          this.list_0[index] = dxf3Dface.list_0[index];
      }
      else
      {
        this.list_0.Clear();
        this.list_0.AddRange((IEnumerable<WW.Math.Point3D>) dxf3Dface.list_0);
      }
      this.invisibleEdgeFlags_0 = dxf3Dface.invisibleEdgeFlags_0;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      bool flag = base.Validate(model, messages);
      if (this.list_0.Count < 3 || this.list_0.Count > 4)
      {
        messages.Add(new DxfMessage(DxfStatus.FaceIllegalVertexCount, Severity.Error));
        flag = false;
      }
      return flag;
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
      Dxf3DFace.Class1061 class1061 = new Dxf3DFace.Class1061();
      // ISSUE: reference to a compiler-generated field
      class1061.dxf3DFace_0 = this;
      // ISSUE: reference to a compiler-generated field
      class1061.point3D_0 = this.list_0.ToArray();
      for (int index = 0; index < this.list_0.Count; ++index)
        this.list_0[index] = matrix.Transform(this.list_0[index]);
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new Dxf3DFace.Class1062()
      {
        class1061_0 = class1061,
        point3D_0 = this.list_0.ToArray()
      }.method_0), new System.Action(class1061.method_0)));
    }

    internal InvisibleEdgeFlags method_13()
    {
      return this.invisibleEdgeFlags_0;
    }

    internal void method_14(InvisibleEdgeFlags invisibleEdgeFlags)
    {
      this.invisibleEdgeFlags_0 = invisibleEdgeFlags;
    }

    internal override short vmethod_6(Class432 w)
    {
      return 28;
    }

    public IList<Polygon2D> GetClipBoundary(GraphicsConfig graphicsConfig)
    {
      if (this.list_0.Count < 3)
        return (IList<Polygon2D>) new Polygon2D[0];
      Polygon2D polygon2D = new Polygon2D(this.list_0.Count);
      for (int index = 0; index < this.list_0.Count - 1; ++index)
        polygon2D.Add((WW.Math.Point2D) this.list_0[index]);
      if (this.list_0.Count > 2 && this.list_0[this.list_0.Count - 1] != this.list_0[0])
        polygon2D.Add((WW.Math.Point2D) this.list_0[this.list_0.Count - 1]);
      return (IList<Polygon2D>) new Polygon2D[1]{ polygon2D };
    }

    private void GetPolylines4D(
      DrawContext context,
      IClippingTransformer transformer,
      out IList<Polyline4D> polylines4D,
      out IList<IShape4D> shapes)
    {
      IList<WW.Math.Geometry.Polyline3D> polyline3DList = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>(4);
      IList<FlatShape4D> resultShapes = (IList<FlatShape4D>) null;
      int count = this.list_0.Count;
      if (count > 1)
      {
        bool flag = true;
        if (this.FirstEdgeInvisible)
          flag = false;
        if (this.SecondEdgeInvisible)
          flag = false;
        if (count > 2)
        {
          if (this.ThirdEdgeInvisible)
            flag = false;
          if (count > 3 && this.FourthEdgeInvisible)
            flag = false;
        }
        if (flag)
        {
          WW.Math.Geometry.Polyline3D polyline3D = new WW.Math.Geometry.Polyline3D(count, count > 2);
          for (int index = 0; index < count; ++index)
            polyline3D.Add(this.list_0[index]);
          polyline3DList.Add(polyline3D);
        }
        else
        {
          if (!this.FirstEdgeInvisible)
            polyline3DList.Add(new WW.Math.Geometry.Polyline3D(new WW.Math.Point3D[2]
            {
              this.list_0[0],
              this.list_0[1]
            }));
          if (count > 2)
          {
            if (!this.SecondEdgeInvisible)
              polyline3DList.Add(new WW.Math.Geometry.Polyline3D(new WW.Math.Point3D[2]
              {
                this.list_0[1],
                this.list_0[2]
              }));
            if (this.Points.Count == 3)
            {
              if (!this.ThirdEdgeInvisible)
                polyline3DList.Add(new WW.Math.Geometry.Polyline3D(new WW.Math.Point3D[2]
                {
                  this.list_0[2],
                  this.list_0[0]
                }));
            }
            else if (this.Points.Count == 4)
            {
              if (!this.ThirdEdgeInvisible)
                polyline3DList.Add(new WW.Math.Geometry.Polyline3D(new WW.Math.Point3D[2]
                {
                  this.list_0[2],
                  this.list_0[3]
                }));
              if (!this.FourthEdgeInvisible)
                polyline3DList.Add(new WW.Math.Geometry.Polyline3D(new WW.Math.Point3D[2]
                {
                  this.list_0[3],
                  this.list_0[0]
                }));
            }
          }
        }
        IList<WW.Math.Geometry.Polyline3D> polylines = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>(4);
        resultShapes = (IList<FlatShape4D>) new List<FlatShape4D>();
        DxfUtil.smethod_2(context.Config, polyline3DList, resultShapes, polylines, this.GetLineType(context), Vector3D.ZAxis, context.TotalLineTypeScale * this.LineTypeScale, transformer.LineTypeScaler);
      }
      polylines4D = DxfUtil.smethod_36(polyline3DList, false, transformer);
      shapes = DxfUtil.smethod_37((ICollection<FlatShape4D>) resultShapes, transformer);
    }
  }
}
