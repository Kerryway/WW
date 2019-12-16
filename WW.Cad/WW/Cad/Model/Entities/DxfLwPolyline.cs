// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfLwPolyline
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns1;
using ns2;
using ns28;
using ns3;
using ns33;
using ns36;
using ns43;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WW.Actions;
using WW.Cad.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;
using WW.Windows;
using WW.Windows.Forms;

namespace WW.Cad.Model.Entities
{
  public class DxfLwPolyline : DxfEntity, IClipBoundaryProvider
  {
    private DxfLwPolyline.VertexCollection vertexCollection_0 = new DxfLwPolyline.VertexCollection();
    private Vector3D vector3D_0 = Vector3D.ZAxis;
    private double double_1;
    private double double_2;
    private double double_3;
    private Enum21 enum21_0;

    public DxfLwPolyline()
    {
    }

    public DxfLwPolyline(EntityColor color)
    {
      this.Color = color;
    }

    public DxfLwPolyline(IEnumerable<WW.Math.Point2D> vertices)
    {
      this.vertexCollection_0.AddRange(vertices);
    }

    public DxfLwPolyline(EntityColor color, IEnumerable<WW.Math.Point2D> vertices)
      : this(color)
    {
      this.vertexCollection_0.AddRange(vertices);
    }

    public DxfLwPolyline(params WW.Math.Point2D[] vertices)
    {
      this.vertexCollection_0.AddRange(vertices);
    }

    public DxfLwPolyline(EntityColor color, params WW.Math.Point2D[] vertices)
      : this(color)
    {
      this.vertexCollection_0.AddRange(vertices);
    }

    public DxfLwPolyline.VertexCollection Vertices
    {
      get
      {
        return this.vertexCollection_0;
      }
    }

    public bool Closed
    {
      get
      {
        return (this.enum21_0 & Enum21.flag_1) != Enum21.flag_0;
      }
      set
      {
        if (value)
          this.enum21_0 |= Enum21.flag_1;
        else
          this.enum21_0 &= ~Enum21.flag_1;
      }
    }

    public bool Plinegen
    {
      get
      {
        return (this.enum21_0 & Enum21.flag_8) != Enum21.flag_0;
      }
      set
      {
        if (value)
          this.enum21_0 |= Enum21.flag_8;
        else
          this.enum21_0 &= ~Enum21.flag_8;
      }
    }

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

    public double Thickness
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

    public double ConstantWidth
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
        return "LWPOLYLINE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbPolyline";
      }
    }

    public override Matrix4D Transform
    {
      get
      {
        return DxfUtil.GetToWCSTransform(this.vector3D_0) * Transformation4D.Translation(0.0, 0.0, this.double_1);
      }
    }

    public IList<DxfEntity> ExplodeIntoLinesAndArcs()
    {
      List<DxfEntity> result = new List<DxfEntity>();
      if (this.vertexCollection_0.Count > 1)
      {
        DxfLwPolyline.Vertex previousVertex = this.vertexCollection_0[0];
        for (int index = 1; index < this.vertexCollection_0.Count; ++index)
        {
          DxfLwPolyline.Vertex vertex = this.vertexCollection_0[index];
          this.method_13(previousVertex, vertex, result);
          previousVertex = vertex;
        }
        if (this.Closed)
          this.method_13(previousVertex, this.vertexCollection_0[0], result);
      }
      return (IList<DxfEntity>) result;
    }

    private void method_13(
      DxfLwPolyline.Vertex previousVertex,
      DxfLwPolyline.Vertex vertex,
      List<DxfEntity> result)
    {
      if (previousVertex.Bulge == 0.0)
      {
        DxfLine dxfLine = new DxfLine(previousVertex.Position, vertex.Position);
        dxfLine.method_12((DxfEntity) this);
        result.Add((DxfEntity) dxfLine);
      }
      else
      {
        WW.Math.Point2D endPointsAndBulge = DxfVertex2D.GetArcCenterFromEndPointsAndBulge(previousVertex.Position, vertex.Position, previousVertex.Bulge);
        Vector2D vector2D1 = previousVertex.Position - endPointsAndBulge;
        Vector2D vector2D2 = vertex.Position - endPointsAndBulge;
        DxfArc dxfArc = vertex.Bulge >= 0.0 ? new DxfArc((WW.Math.Point3D) endPointsAndBulge, vector2D1.GetLength(), vector2D2.GetAngle(), vector2D1.GetAngle()) : new DxfArc((WW.Math.Point3D) endPointsAndBulge, vector2D1.GetLength(), vector2D1.GetAngle(), vector2D2.GetAngle());
        dxfArc.method_12((DxfEntity) this);
        result.Add((DxfEntity) dxfArc);
      }
    }

    public override IControlPointCollection InteractionControlPoints
    {
      get
      {
        return (IControlPointCollection) this.vertexCollection_0;
      }
    }

    public override DxfEntity.Interactor CreateCreateInteractor(Transaction transaction)
    {
      return (DxfEntity.Interactor) new DxfLwPolyline.CreateInteractor((DxfEntity) this, (ITransaction) transaction);
    }

    public override DxfEntity.Interactor CreateEditInteractor()
    {
      return (DxfEntity.Interactor) new DxfEntity.DefaultEditInteractor((DxfEntity) this);
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
      DxfLwPolyline.Class910 class910 = new DxfLwPolyline.Class910();
      // ISSUE: reference to a compiler-generated field
      class910.dxfLwPolyline_0 = this;
      Matrix4D transform = this.Transform;
      // ISSUE: reference to a compiler-generated field
      class910.vertexCollection_0 = (DxfLwPolyline.VertexCollection) null;
      if (undoGroup != null)
      {
        // ISSUE: reference to a compiler-generated field
        class910.vertexCollection_0 = new DxfLwPolyline.VertexCollection(this.vertexCollection_0.Count);
        foreach (DxfLwPolyline.Vertex vertex in (List<DxfLwPolyline.Vertex>) this.vertexCollection_0)
        {
          // ISSUE: reference to a compiler-generated field
          class910.vertexCollection_0.Add(vertex.Clone());
        }
      }
      // ISSUE: reference to a compiler-generated field
      class910.double_0 = this.double_1;
      // ISSUE: reference to a compiler-generated field
      class910.vector3D_0 = this.vector3D_0;
      // ISSUE: reference to a compiler-generated field
      class910.double_1 = this.double_2;
      // ISSUE: reference to a compiler-generated field
      class910.double_2 = this.double_3;
      this.vector3D_0 = matrix.Transform(this.vector3D_0);
      this.double_3 *= this.vector3D_0.GetLength();
      this.vector3D_0.Normalize();
      this.double_1 = (DxfUtil.GetToWCSTransform(this.vector3D_0).GetInverse() * matrix * transform).Transform(WW.Math.Point3D.Zero).Z;
      Matrix4D matrix4D = this.Transform.GetInverse() * matrix * transform;
      this.double_2 = matrix4D.Transform(new Vector2D(this.double_2, 0.0)).GetLength();
      bool flipOrientation = Class749.smethod_5(matrix4D);
      foreach (DxfLwPolyline.Vertex vertex in (List<DxfLwPolyline.Vertex>) this.vertexCollection_0)
        vertex.Transform(matrix4D, flipOrientation);
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfLwPolyline.Class911 class911 = new DxfLwPolyline.Class911();
      // ISSUE: reference to a compiler-generated field
      class911.class910_0 = class910;
      // ISSUE: reference to a compiler-generated field
      class911.vertexCollection_0 = new DxfLwPolyline.VertexCollection(this.vertexCollection_0.Count);
      foreach (DxfLwPolyline.Vertex vertex in (List<DxfLwPolyline.Vertex>) this.vertexCollection_0)
      {
        // ISSUE: reference to a compiler-generated field
        class911.vertexCollection_0.Add(vertex.Clone());
      }
      // ISSUE: reference to a compiler-generated field
      class911.double_0 = this.double_1;
      // ISSUE: reference to a compiler-generated field
      class911.vector3D_0 = this.vector3D_0;
      // ISSUE: reference to a compiler-generated field
      class911.double_1 = this.double_2;
      // ISSUE: reference to a compiler-generated field
      class911.double_2 = this.double_3;
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new WW.Actions.Command((object) this, new System.Action(class911.method_0), new System.Action(class910.method_0)));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      IList<Polyline4D> polylines4D;
      IList<IShape4D> shapes;
      bool fill;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), out polylines4D, out shapes, out fill);
      if (polylines4D.Count > 0)
        graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, polylines4D, fill, true);
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
      bool fill;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), out polylines4D, out shapes, out fill);
      if (polylines4D.Count > 0)
        Class940.smethod_3((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, fill, !fill, polylines4D);
      if (shapes == null)
        return;
      Class940.smethod_23((IPathDrawer) new Class396((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    private void GetPolylines4D(
      DrawContext context,
      IClippingTransformer transformer,
      out IList<Polyline4D> polylines4D,
      out IList<IShape4D> shapes,
      out bool fill)
    {
      IList<WW.Math.Geometry.Polyline3D> polylines;
      IList<FlatShape4D> shapes1;
      this.GetPolylines(context, transformer.LineTypeScaler, out polylines, out shapes1, out fill);
      fill = fill && this.ZAxis.X == 0.0 && this.ZAxis.Y == 0.0;
      if (this.Thickness != 0.0)
        DxfUtil.Extrude(polylines, this.Thickness, this.ZAxis);
      polylines4D = DxfUtil.smethod_36(polylines, fill, transformer);
      if (shapes1 == null)
      {
        shapes = (IList<IShape4D>) null;
      }
      else
      {
        shapes = (IList<IShape4D>) new List<IShape4D>(shapes1.Count);
        foreach (IShape4D shape4D in (IEnumerable<FlatShape4D>) shapes1)
          shapes.Add(shape4D);
      }
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      IList<IList<WW.Cad.Drawing.Polyline2D2N>> polylinesList1;
      IList<IList<WW.Cad.Drawing.Polyline2D2N>> polylinesList2;
      IList<FlatShape4D> shapes;
      bool fill;
      this.GetPolylines((DrawContext) context, context.GetTransformer().LineTypeScaler, out polylinesList1, out polylinesList2, out shapes, out fill);
      graphicsFactory.SetColor(context.GetPlotColor((DxfEntity) this));
      int count = polylinesList1.Count;
      for (int index = 0; index < count; ++index)
      {
        IList<WW.Cad.Drawing.Polyline2D2N> polyline2D2NList = polylinesList1[index];
        IList<WW.Cad.Drawing.Polyline2D2N> polylinesB = polylinesList2[index];
        bool flag = this.Thickness != 0.0;
        if (polylinesB == null)
        {
          if (flag)
          {
            Class940.smethod_5((DxfEntity) this, context, graphicsFactory, polyline2D2NList, fill, this.Transform, this.ZAxis, this.Thickness);
          }
          else
          {
            IList<WW.Math.Geometry.Polyline3D> polyline3DList = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>();
            DxfUtil.smethod_15(polyline2D2NList, (IList<WW.Cad.Drawing.Polyline2D2N>) null, this.Transform, polyline3DList, false);
            Class940.smethod_15((DxfEntity) this, context, graphicsFactory, polyline3DList);
          }
        }
        else if (flag)
          Class940.smethod_7((DxfEntity) this, context, graphicsFactory, polyline2D2NList, polylinesB, fill, this.Transform, this.ZAxis, this.Thickness);
        else
          Class940.smethod_10((DxfEntity) this, context, graphicsFactory, polyline2D2NList, polylinesB, this.Transform, this.ZAxis, fill);
      }
      if (shapes == null)
        return;
      Class940.smethod_24((IPathDrawer) new Class473((DxfEntity) this, context, graphicsFactory), (IEnumerable<FlatShape4D>) shapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this), this.Thickness);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      WW.Cad.Drawing.Surface.Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      DxfLineType lineType = this.GetLineType((DrawContext) context);
      bool plinegen = this.Plinegen;
      double lineTypeScale = context.TotalLineTypeScale * this.LineTypeScale;
      if (!graphics.AddExistingGraphicElement2(parentGraphicElementBlock, (DxfEntity) this, plotColor, lineType, lineTypeScale, plinegen))
        return;
      GraphicElement2 graphicElement2 = new GraphicElement2(plotColor, lineType, lineTypeScale, plinegen);
      graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, (GraphicElement1) graphicElement2);
      if (this.double_3 != 0.0)
        graphicElement2.Geometry.Extrusion = this.double_3 * Vector3D.ZAxis;
      Class940.smethod_12((DrawContext) context, (IVertex2DCollection) this.vertexCollection_0, this.Closed, this.Transform, this.Thickness, this.double_2, this.double_2, graphicElement2.Geometry);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfLwPolyline dxfLwPolyline = (DxfLwPolyline) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfLwPolyline == null)
      {
        dxfLwPolyline = new DxfLwPolyline();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfLwPolyline);
        dxfLwPolyline.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfLwPolyline;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfLwPolyline dxfLwPolyline = (DxfLwPolyline) from;
      foreach (DxfLwPolyline.Vertex vertex in (List<DxfLwPolyline.Vertex>) dxfLwPolyline.vertexCollection_0)
        this.vertexCollection_0.Add(vertex.Clone(cloneContext));
      this.double_1 = dxfLwPolyline.double_1;
      this.vector3D_0 = dxfLwPolyline.vector3D_0;
      this.double_2 = dxfLwPolyline.double_2;
      this.double_3 = dxfLwPolyline.double_3;
      this.enum21_0 = dxfLwPolyline.enum21_0;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.short_3;
    }

    internal override void Read(Class434 or, Class259 objectBuilder)
    {
      base.Read(or, objectBuilder);
      this.method_14(or.ObjectBitStream, or.Builder);
    }

    internal void method_14(Interface30 r, Class374 builder)
    {
      short num1 = r.imethod_14();
      this.Plinegen = ((int) num1 & 256) != 0;
      this.Closed = ((int) num1 & 512) != 0;
      if (((int) num1 & 4) != 0)
        this.ConstantWidth = r.imethod_8();
      if (((int) num1 & 8) != 0)
        this.Elevation = r.imethod_8();
      if (((int) num1 & 2) != 0)
        this.Thickness = r.imethod_8();
      if (((int) num1 & 1) != 0)
        this.ZAxis = r.imethod_51();
      int num2 = r.imethod_11();
      int num3 = 0;
      if (((int) num1 & 16) != 0)
        num3 = r.imethod_11();
      int num4 = 0;
      if (((int) num1 & 1024) != 0)
        num4 = r.imethod_11();
      int num5 = 0;
      if (((int) num1 & 32) != 0)
        num5 = r.imethod_11();
      if (builder.IsVersion13Or14)
      {
        for (int index = 0; index < num2; ++index)
        {
          WW.Math.Point2D p = r.imethod_38();
          this.Vertices.Add(new DxfLwPolyline.Vertex(builder.method_22((DxfEntity) this, p)));
        }
      }
      if (builder.IsVersion15OrLater && num2 > 0)
      {
        WW.Math.Point2D p1 = r.imethod_38();
        WW.Math.Point2D point2D = builder.method_22((DxfEntity) this, p1);
        this.Vertices.Add(new DxfLwPolyline.Vertex(point2D));
        for (int index = 1; index < num2; ++index)
        {
          WW.Math.Point2D p2 = r.imethod_37(point2D);
          point2D = builder.method_22((DxfEntity) this, p2);
          this.Vertices.Add(new DxfLwPolyline.Vertex(point2D));
        }
      }
      for (int index = 0; index < num3; ++index)
        this.Vertices[index].Bulge = builder.method_23((DxfEntity) this, r.imethod_8());
      for (int index = 0; index < num4; ++index)
        this.Vertices[index].Id = r.imethod_11();
      for (int index = 0; index < num5; ++index)
      {
        DxfLwPolyline.Vertex vertex = this.Vertices[index];
        vertex.StartWidth = builder.method_23((DxfEntity) this, r.imethod_8());
        vertex.EndWidth = builder.method_23((DxfEntity) this, r.imethod_8());
      }
    }

    internal void method_15(Interface29 objectWriter)
    {
      DxfVersion version = objectWriter.Version;
      bool flag1 = false;
      bool flag2 = false;
      foreach (DxfLwPolyline.Vertex vertex in (List<DxfLwPolyline.Vertex>) this.vertexCollection_0)
      {
        if (!flag1 && vertex.Bulge != 0.0)
          flag1 = true;
        if (!flag2 && (vertex.StartWidth != 0.0 || vertex.EndWidth != 0.0))
          flag2 = true;
      }
      short num = 0;
      if (this.ZAxis != Vector3D.ZAxis)
        num |= (short) 1;
      if (this.Thickness != 0.0)
        num |= (short) 2;
      if (this.ConstantWidth != 0.0)
        num |= (short) 4;
      if (this.Elevation != 0.0)
        num |= (short) 8;
      if (flag1)
        num |= (short) 16;
      if (flag2)
        num |= (short) 32;
      if (this.Plinegen)
        num |= (short) 256;
      if (this.Closed)
        num |= (short) 512;
      objectWriter.imethod_32(num);
      if (this.ConstantWidth != 0.0)
        objectWriter.imethod_16(this.ConstantWidth);
      if (this.Elevation != 0.0)
        objectWriter.imethod_16(this.Elevation);
      if (this.Thickness != 0.0)
        objectWriter.imethod_16(this.Thickness);
      if (this.ZAxis != Vector3D.ZAxis)
        objectWriter.imethod_29(this.ZAxis);
      int count = this.Vertices.Count;
      objectWriter.imethod_33(count);
      if (flag1)
        objectWriter.imethod_33(count);
      if (flag2)
        objectWriter.imethod_33(count);
      if (version >= DxfVersion.Dxf13 && version <= DxfVersion.Dxf14)
      {
        for (int index = 0; index < count; ++index)
          objectWriter.imethod_25(this.Vertices[index].Position);
      }
      if (version >= DxfVersion.Dxf15 && count > 0)
      {
        DxfLwPolyline.Vertex vertex1 = this.Vertices[0];
        objectWriter.imethod_25(vertex1.Position);
        for (int index = 1; index < count; ++index)
        {
          DxfLwPolyline.Vertex vertex2 = this.Vertices[index];
          objectWriter.imethod_30(vertex2.Position, vertex1.Position);
          vertex1 = vertex2;
        }
      }
      if (flag1)
      {
        for (int index = 0; index < count; ++index)
          objectWriter.imethod_16(this.Vertices[index].Bulge);
      }
      if (!flag2)
        return;
      for (int index = 0; index < count; ++index)
      {
        DxfLwPolyline.Vertex vertex = this.Vertices[index];
        objectWriter.imethod_16(vertex.StartWidth);
        objectWriter.imethod_16(vertex.EndWidth);
      }
    }

    internal Enum21 Flags
    {
      get
      {
        return this.enum21_0;
      }
      set
      {
        this.enum21_0 = value;
      }
    }

    internal static DxfClass smethod_2(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "LWPOLYLINE");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass()
        {
          ApplicationName = "ObjectDBX Classes",
          ClassNumber = (short) (500 + classes.Count),
          DwgVersion = DwgVersion.Dwg0,
          MaintenanceVersion = (short) 0,
          ProxyFlags = ProxyFlags.None,
          CPlusPlusClassName = "AcDbPolyline",
          DxfName = "LWPOLYLINE",
          ItemClassId = (short) 498
        };
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    private void GetPolylines(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<WW.Math.Geometry.Polyline3D> polylines,
      out IList<FlatShape4D> shapes,
      out bool fill)
    {
      IList<IList<Polyline2D>> polylinesList1;
      IList<IList<Polyline2D>> polylinesList2;
      this.GetPolylines(context, lineTypeScaler, out polylinesList1, out polylinesList2, out shapes, out fill);
      polylines = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>();
      int count = polylinesList1.Count;
      for (int index = 0; index < count; ++index)
        DxfUtil.smethod_14(polylinesList1[index], polylinesList2[index], this.Transform, polylines, true);
    }

    private void GetPolylines(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<IList<Polyline2D>> polylinesList1,
      out IList<IList<Polyline2D>> polylinesList2,
      out IList<FlatShape4D> shapes,
      out bool fill)
    {
      DxfHeader header = context.Model.Header;
      WW.Cad.Drawing.Polyline2D2WN polyline = new Class639(this.double_2, this.double_2).method_0((IVertex2DCollection) this.vertexCollection_0, context.Config, this.Closed);
      polylinesList1 = (IList<IList<Polyline2D>>) new List<IList<Polyline2D>>();
      polylinesList2 = (IList<IList<Polyline2D>>) new List<IList<Polyline2D>>();
      fill = false;
      if (polyline != null)
      {
        IList<Polyline2D> resultPolylines1;
        IList<Polyline2D> resultPolylines2;
        DxfUtil.smethod_25(context.Config, polyline, context.Config.ApplyLineType ? this.GetLineType(context) : (DxfLineType) null, context.TotalLineTypeScale * this.LineTypeScale, lineTypeScaler, this.Plinegen, out resultPolylines1, out resultPolylines2, out shapes, out fill);
        polylinesList1.Add(resultPolylines1);
        polylinesList2.Add(resultPolylines2);
      }
      else
        shapes = (IList<FlatShape4D>) null;
      fill &= context.Model.Header.FillMode;
    }

    private void GetPolylines(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<IList<WW.Cad.Drawing.Polyline2D2N>> polylinesList1,
      out IList<IList<WW.Cad.Drawing.Polyline2D2N>> polylinesList2,
      out IList<FlatShape4D> shapes,
      out bool fill)
    {
      DxfHeader header = context.Model.Header;
      WW.Cad.Drawing.Polyline2D2WN polyline = new Class639(this.double_2, this.double_2).method_0((IVertex2DCollection) this.vertexCollection_0, context.Config, this.Closed);
      polylinesList1 = (IList<IList<WW.Cad.Drawing.Polyline2D2N>>) new List<IList<WW.Cad.Drawing.Polyline2D2N>>();
      polylinesList2 = (IList<IList<WW.Cad.Drawing.Polyline2D2N>>) new List<IList<WW.Cad.Drawing.Polyline2D2N>>();
      fill = false;
      if (polyline != null)
      {
        IList<WW.Cad.Drawing.Polyline2D2N> resultPolylines1;
        IList<WW.Cad.Drawing.Polyline2D2N> resultPolylines2;
        if (DxfUtil.smethod_27(context.Config, polyline, context.Config.ApplyLineType ? this.GetLineType(context) : (DxfLineType) null, context.TotalLineTypeScale * this.LineTypeScale, lineTypeScaler, this.Plinegen, out resultPolylines1, out resultPolylines2, out shapes, out fill))
        {
          polylinesList1.Add(resultPolylines1);
          polylinesList2.Add(resultPolylines2);
        }
      }
      else
        shapes = (IList<FlatShape4D>) null;
      fill &= context.Model.Header.FillMode;
    }

    public IList<Polygon2D> GetClipBoundary(GraphicsConfig graphicsConfig)
    {
      WW.Cad.Drawing.Polyline2DE polyline2De = Class639.Class640.smethod_0((IVertex2DCollection) this.vertexCollection_0, graphicsConfig, true);
      Polygon2D polygon2D = new Polygon2D(polyline2De.Count);
      foreach (Point2DE point2De in (List<Point2DE>) polyline2De)
        polygon2D.Add(point2De.Position);
      return (IList<Polygon2D>) new Polygon2D[1]{ polygon2D };
    }

    public class Vertex : IVertex2D
    {
      private WW.Math.Point2D point2D_0;
      private double double_0;
      private double double_1;
      private double double_2;
      private int int_0;
      private Vector2D? nullable_0;

      public Vertex()
      {
      }

      public Vertex(WW.Math.Point2D position)
      {
        this.point2D_0 = position;
      }

      public Vertex(WW.Math.Point2D position, double startWidth, double endWidth)
      {
        this.point2D_0 = position;
        this.double_0 = startWidth;
        this.double_1 = endWidth;
      }

      public Vertex(WW.Math.Point2D position, double bulge)
      {
        this.point2D_0 = position;
        this.double_2 = bulge;
      }

      public Vertex(WW.Math.Point2D position, double startWidth, double endWidth, double bulge)
      {
        this.point2D_0 = position;
        this.double_0 = startWidth;
        this.double_1 = endWidth;
        this.double_2 = bulge;
      }

      public Vertex(double x, double y)
      {
        this.point2D_0 = new WW.Math.Point2D(x, y);
      }

      public Vertex(double x, double y, double startWidth, double endWidth)
      {
        this.point2D_0 = new WW.Math.Point2D(x, y);
        this.double_0 = startWidth;
        this.double_1 = endWidth;
      }

      public Vertex(double x, double y, double startWidth, double endWidth, double bulge)
      {
        this.point2D_0 = new WW.Math.Point2D(x, y);
        this.double_0 = startWidth;
        this.double_1 = endWidth;
        this.double_2 = bulge;
      }

      public double EndWidth
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

      public double StartWidth
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

      public double Bulge
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

      public int Id
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

      public DxfLwPolyline.Vertex Clone(CloneContext cloneContext)
      {
        DxfLwPolyline.Vertex vertex = new DxfLwPolyline.Vertex();
        vertex.CopyFrom(this, cloneContext);
        return vertex;
      }

      public void CopyFrom(DxfLwPolyline.Vertex from, CloneContext cloneContext)
      {
        this.CopyFrom(from);
      }

      public DxfLwPolyline.Vertex Clone()
      {
        DxfLwPolyline.Vertex vertex = new DxfLwPolyline.Vertex();
        vertex.CopyFrom(this);
        return vertex;
      }

      public void CopyFrom(DxfLwPolyline.Vertex from)
      {
        this.point2D_0 = from.point2D_0;
        this.double_0 = from.double_0;
        this.double_1 = from.double_1;
        this.double_2 = from.double_2;
        this.int_0 = from.int_0;
        this.nullable_0 = from.nullable_0;
      }

      public override int GetHashCode()
      {
        return this.point2D_0.GetHashCode();
      }

      public override bool Equals(object other)
      {
        return this == (DxfLwPolyline.Vertex) other;
      }

      public static bool operator ==(DxfLwPolyline.Vertex a, DxfLwPolyline.Vertex b)
      {
        if (object.ReferenceEquals((object) a, (object) b))
          return true;
        if (!object.ReferenceEquals((object) a, (object) null) && !object.ReferenceEquals((object) b, (object) null) && (DxfUtil.Equal(a.point2D_0.X, b.point2D_0.X) && DxfUtil.Equal(a.point2D_0.Y, b.point2D_0.Y)) && (DxfUtil.Equal(a.double_0, b.double_0) && DxfUtil.Equal(a.double_1, b.double_1)))
          return DxfUtil.Equal(a.double_2, b.double_2);
        return false;
      }

      public override string ToString()
      {
        string str = this.point2D_0.ToString();
        if (this.double_0 != 0.0)
          str = str + ", startWidth = " + (object) this.double_0;
        if (this.double_1 != 0.0)
          str = str + ", endWidth = " + (object) this.double_1;
        if (this.double_2 != 0.0)
          str = str + ", bulge = " + (object) this.double_2;
        return str;
      }

      public static bool operator !=(DxfLwPolyline.Vertex a, DxfLwPolyline.Vertex b)
      {
        return !(a == b);
      }

      internal Vector2D? Normal
      {
        get
        {
          return this.nullable_0;
        }
        set
        {
          this.nullable_0 = value;
        }
      }

      internal void Transform(Matrix4D transformationWithOcs, bool flipOrientation)
      {
        this.point2D_0 = transformationWithOcs.Transform(this.point2D_0);
        this.double_0 = transformationWithOcs.Transform(new Vector2D(this.double_0, 0.0)).GetLength();
        this.double_1 = transformationWithOcs.Transform(new Vector2D(this.double_1, 0.0)).GetLength();
        if (flipOrientation)
          this.double_2 = -this.double_2;
        if (!this.nullable_0.HasValue)
          return;
        this.nullable_0 = new Vector2D?(transformationWithOcs.Transform(this.nullable_0.Value));
      }
    }

    public class VertexCollection : List<DxfLwPolyline.Vertex>, IControlPointCollection, IVertex2DCollection
    {
      public VertexCollection()
      {
      }

      public VertexCollection(IEnumerable<DxfLwPolyline.Vertex> vertices)
        : base(vertices)
      {
      }

      public VertexCollection(int capacity)
        : base(capacity)
      {
      }

      public VertexCollection(IEnumerable<WW.Math.Point2D> vertices)
      {
        foreach (WW.Math.Point2D vertex in vertices)
          this.Add(new DxfLwPolyline.Vertex(vertex));
      }

      public VertexCollection(IList<WW.Math.Point2D> vertices)
        : base(vertices.Count)
      {
        foreach (WW.Math.Point2D vertex in (IEnumerable<WW.Math.Point2D>) vertices)
          this.Add(new DxfLwPolyline.Vertex(vertex));
      }

      public VertexCollection(params WW.Math.Point2D[] vertices)
        : base(vertices.Length)
      {
        foreach (WW.Math.Point2D vertex in vertices)
          this.Add(new DxfLwPolyline.Vertex(vertex));
      }

      public void Add(WW.Math.Point2D vertex)
      {
        this.Add(new DxfLwPolyline.Vertex(vertex));
      }

      public void Add(double x, double y)
      {
        this.Add(new DxfLwPolyline.Vertex(x, y));
      }

      public void AddRange(IEnumerable<WW.Math.Point2D> vertices)
      {
        foreach (WW.Math.Point2D vertex in vertices)
          this.Add(new DxfLwPolyline.Vertex(vertex));
      }

      public void AddRange(params WW.Math.Point2D[] vertices)
      {
        foreach (WW.Math.Point2D vertex in vertices)
          this.Add(new DxfLwPolyline.Vertex(vertex));
      }

      public IVertex2D GetIVertex2D(int index)
      {
        return (IVertex2D) this[index];
      }

      void IControlPointCollection.Set(int index, WW.Math.Point3D value)
      {
        this[index].Position = (WW.Math.Point2D) value;
      }

      WW.Math.Point3D IControlPointCollection.Get(int index)
      {
        return (WW.Math.Point3D) this[index].Position;
      }

      string IControlPointCollection.GetDescription(int index)
      {
        return Class881.DxfLwPolyline_Vertex_ControlPoint_Name;
      }

      PointDisplayType IControlPointCollection.GetDisplayType(
        int index)
      {
        return PointDisplayType.Default;
      }

      int IControlPointCollection.Count
      {
        get
        {
          return this.Count;
        }
      }

      bool IControlPointCollection.IsCountFixed
      {
        get
        {
          return false;
        }
      }

      void IControlPointCollection.Insert(int index)
      {
        DxfLwPolyline.Vertex vertex = new DxfLwPolyline.Vertex();
        this.Insert(index, vertex);
      }
    }

    public class CreateInteractor : DxfEntity.DefaultCreateInteractor
    {
      public CreateInteractor(DxfEntity entity, ITransaction transaction)
        : base(entity, transaction)
      {
      }

      public override IControlPoint ControlPointTemplate
      {
        get
        {
          return (IControlPoint) DxfLwPolyline.CreateInteractor.Class909.class909_0;
        }
      }

      private class Class909 : IControlPoint
      {
        public static readonly DxfLwPolyline.CreateInteractor.Class909 class909_0 = new DxfLwPolyline.CreateInteractor.Class909();

        private Class909()
        {
        }

        public void SetValue(object owner, WW.Math.Point3D value)
        {
          throw new NotImplementedException();
        }

        public WW.Math.Point3D GetValue(object owner)
        {
          throw new NotImplementedException();
        }

        public string Description
        {
          get
          {
            return Class881.DxfLwPolyline_Vertex_ControlPoint_Name;
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

    public class CreateWithLengthInteractor : DxfLwPolyline.CreateInteractor
    {
      private double? nullable_1;

      public event EventHandler Changed;

      public event EventHandler<InteractorMouseEventArgs> MouseMoveProcessed;

      public CreateWithLengthInteractor(DxfEntity entity, ITransaction transaction)
        : base(entity, transaction)
      {
      }

      public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
      {
        this.method_2(e, context);
        bool flag = base.ProcessMouseMove(e, context);
        this.OnMouseMoveProcessed(new InteractorMouseEventArgs(e, context));
        return flag;
      }

      public override bool ProcessMouseButtonUp(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        this.method_2(e, context);
        bool flag = base.ProcessMouseButtonUp(e, context);
        this.nullable_1 = new double?();
        this.OnChanged(EventArgs.Empty);
        return flag;
      }

      protected override void OnDeactivated(EventArgs e)
      {
        this.nullable_1 = new double?();
        base.OnDeactivated(e);
      }

      protected virtual void OnChanged(EventArgs e)
      {
        if (this.eventHandler_1 == null)
          return;
        this.eventHandler_1((object) this, e);
      }

      protected virtual void OnMouseMoveProcessed(InteractorMouseEventArgs e)
      {
        if (this.eventHandler_2 == null)
          return;
        this.eventHandler_2((object) this, e);
      }

      public override IInteractorWinFormsDrawable CreateWinFormsDrawable(
        InteractionContext context,
        Control hostControl)
      {
        return (IInteractorWinFormsDrawable) new DxfLwPolyline.CreateWithLengthInteractor.Form7(this, hostControl);
      }

      public static void SnapHorizontalOrVertical(
        DxfEntity.Interactor interactor,
        CanonicalMouseEventArgs e,
        InteractionContext context,
        int controlPointIndex)
      {
        bool flag = InputUtil.IsShiftPressed();
        CadInteractionContext interactionContext = context as CadInteractionContext;
        if (interactionContext != null)
          flag ^= interactionContext.DefaultNonDiagonalLines;
        if (!interactor.IsActive || !flag || controlPointIndex <= 0)
          return;
        DxfLwPolyline entity = (DxfLwPolyline) interactor.Entity;
        WW.Math.Point2D point2D1 = context.ProjectionTransform.TransformTo2D(interactor.ControlPoints.Get(controlPointIndex - 1));
        WW.Math.Point3D wcsPosition = e.GetWcsPosition(context);
        WW.Math.Point2D point2D2 = context.ProjectionTransform.TransformTo2D(wcsPosition);
        Vector2D vector2D = point2D2 - point2D1;
        if (System.Math.Abs(vector2D.X) < System.Math.Abs(vector2D.Y))
          e.SetWcsPosition(context.InverseProjectionTransform.TransformTo3D(new WW.Math.Point2D(point2D1.X, point2D2.Y)), true);
        else
          e.SetWcsPosition(context.InverseProjectionTransform.TransformTo3D(new WW.Math.Point2D(point2D2.X, point2D1.Y)), true);
      }

      private void method_2(CanonicalMouseEventArgs e, InteractionContext context)
      {
        if (!this.IsActive)
          return;
        DxfLwPolyline.CreateWithLengthInteractor.SnapHorizontalOrVertical((DxfEntity.Interactor) this, e, context, this.ControlPointIndex);
        if (this.ControlPointIndex <= 0 || !this.nullable_1.HasValue || this.nullable_1.Value <= 0.0)
          return;
        DxfLwPolyline entity = (DxfLwPolyline) this.Entity;
        WW.Math.Point3D wcsPosition = e.GetWcsPosition(context);
        WW.Math.Point3D position = (WW.Math.Point3D) entity.Vertices[this.ControlPointIndex - 1].Position;
        if (!(wcsPosition != position))
          return;
        Vector3D unit = (wcsPosition - position).GetUnit();
        e.SetWcsPosition(position + unit * this.nullable_1.Value, true);
        this.OnChanged(EventArgs.Empty);
      }

      private void ApplyLength()
      {
        if (!this.nullable_1.HasValue)
          return;
        DxfLwPolyline entity = (DxfLwPolyline) this.Entity;
        if (this.ControlPointIndex <= 0)
          return;
        WW.Math.Point3D position1 = (WW.Math.Point3D) entity.Vertices[this.ControlPointIndex - 1].Position;
        WW.Math.Point3D position2 = (WW.Math.Point3D) entity.Vertices[this.ControlPointIndex].Position;
        if (WW.Math.Point3D.AreApproxEqual(position1, position2))
          return;
        Vector3D unit = (position2 - position1).GetUnit();
        entity.Vertices[this.ControlPointIndex].Position = (WW.Math.Point2D) (position1 + this.nullable_1.Value * unit);
        this.OnEntityChanged(new EntityEventArgs(this.Entity));
      }

      internal class Form7 : DxfEntity.DefaultCreateInteractor.WinFormsDrawable
      {
        private DxfLwPolyline.CreateWithLengthInteractor createWithLengthInteractor_0;
        private FieldEditControl fieldEditControl_0;
        private Control control_0;
        private bool bool_0;

        public Form7(
          DxfLwPolyline.CreateWithLengthInteractor interactor,
          Control hostControl)
          : base((DxfEntity.Interactor) interactor)
        {
          this.createWithLengthInteractor_0 = interactor;
          this.control_0 = hostControl;
          this.fieldEditControl_0 = FieldEditControl.Create(Class675.Length);
          this.fieldEditControl_0.TextBox.KeyPress += new KeyPressEventHandler(this.method_0);
          interactor.Activated += new EventHandler(this.method_2);
          interactor.Deactivated += new EventHandler(this.method_4);
          if (!interactor.IsActive)
            return;
          this.method_3();
        }

        private void method_0(object sender, KeyPressEventArgs e)
        {
          if (this.createWithLengthInteractor_0.nullable_1.HasValue && (e.KeyChar == '\r' || e.KeyChar == '\t'))
          {
            this.createWithLengthInteractor_0.Transaction.Commit();
          }
          else
          {
            if (e.KeyChar != '\x001B')
              return;
            this.createWithLengthInteractor_0.Transaction.Rollback();
          }
        }

        private void method_1(object sender, InteractorMouseEventArgs e)
        {
          if (!this.createWithLengthInteractor_0.nullable_1.HasValue)
          {
            this.bool_0 = true;
            try
            {
              DxfLwPolyline entity = (DxfLwPolyline) this.createWithLengthInteractor_0.Entity;
              if (this.createWithLengthInteractor_0.ControlPointIndex > 0)
              {
                WW.Math.Point3D position = (WW.Math.Point3D) entity.Vertices[this.createWithLengthInteractor_0.ControlPointIndex - 1].Position;
                this.fieldEditControl_0.TextBox.Text = ((WW.Math.Point3D) entity.Vertices[this.createWithLengthInteractor_0.ControlPointIndex].Position - position).GetLength().ToString(e.InteractionContext.LengthFormatString);
                this.fieldEditControl_0.TextBox.SelectAll();
              }
            }
            finally
            {
              this.bool_0 = false;
            }
          }
          this.fieldEditControl_0.TextBox.Focus();
        }

        private void method_2(object sender, EventArgs e)
        {
          this.method_3();
        }

        private void method_3()
        {
          this.createWithLengthInteractor_0.MouseMoveProcessed += new EventHandler<InteractorMouseEventArgs>(this.method_1);
          this.fieldEditControl_0.Visible = true;
          this.fieldEditControl_0.TextBox.Text = "0";
          this.fieldEditControl_0.TextBox.SelectAll();
          this.fieldEditControl_0.TextBox.TextChanged += new EventHandler(this.method_5);
          this.fieldEditControl_0.Show();
          this.fieldEditControl_0.TextBox.Focus();
          this.control_0.MouseMove += new MouseEventHandler(this.control_0_MouseMove);
        }

        private void method_4(object sender, EventArgs e)
        {
          this.fieldEditControl_0.TextBox.TextChanged -= new EventHandler(this.method_5);
          this.createWithLengthInteractor_0.MouseMoveProcessed -= new EventHandler<InteractorMouseEventArgs>(this.method_1);
          this.fieldEditControl_0.Hide();
          this.control_0.MouseMove -= new MouseEventHandler(this.control_0_MouseMove);
        }

        private void control_0_MouseMove(object sender, MouseEventArgs e)
        {
          this.fieldEditControl_0.Location = this.control_0.PointToScreen(new System.Drawing.Point(e.Location.X + 5, e.Location.Y - 5 - this.fieldEditControl_0.Height));
        }

        private void method_5(object sender, EventArgs e)
        {
          if (this.bool_0)
            return;
          if (string.IsNullOrEmpty(this.fieldEditControl_0.TextBox.Text))
          {
            this.createWithLengthInteractor_0.nullable_1 = new double?();
          }
          else
          {
            double result;
            if (!double.TryParse(this.fieldEditControl_0.TextBox.Text, out result))
              return;
            this.createWithLengthInteractor_0.nullable_1 = new double?(result);
            this.createWithLengthInteractor_0.ApplyLength();
          }
        }
      }
    }
  }
}
