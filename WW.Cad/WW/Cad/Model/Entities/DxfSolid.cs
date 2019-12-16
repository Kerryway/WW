// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfSolid
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

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
  public class DxfSolid : DxfEntity
  {
    private readonly List<WW.Math.Point3D> list_0 = new List<WW.Math.Point3D>();
    private Vector3D vector3D_0 = Vector3D.ZAxis;
    private double double_1;

    public List<WW.Math.Point3D> Points
    {
      get
      {
        return this.list_0;
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

    public override string EntityType
    {
      get
      {
        return "SOLID";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbTrace";
      }
    }

    private new Matrix4D Transform
    {
      get
      {
        return DxfUtil.GetToWCSTransform(this.vector3D_0);
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
      DxfSolid.Class902 class902 = new DxfSolid.Class902();
      // ISSUE: reference to a compiler-generated field
      class902.dxfSolid_0 = this;
      // ISSUE: reference to a compiler-generated field
      class902.double_0 = this.double_1;
      // ISSUE: reference to a compiler-generated field
      class902.point3D_0 = this.list_0.ToArray();
      // ISSUE: reference to a compiler-generated field
      class902.vector3D_0 = this.vector3D_0;
      this.vector3D_0 = matrix.Transform(this.vector3D_0);
      this.double_1 *= this.vector3D_0.GetLength();
      this.vector3D_0.Normalize();
      Matrix4D inverse = DxfUtil.GetToWCSTransform(this.vector3D_0).GetInverse();
      // ISSUE: reference to a compiler-generated field
      Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(class902.vector3D_0);
      Matrix4D matrix4D = inverse * matrix * toWcsTransform;
      for (int index = this.list_0.Count - 1; index >= 0; --index)
        this.list_0[index] = matrix4D.Transform(this.list_0[index]);
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfSolid.Class903()
      {
        class902_0 = class902,
        double_0 = this.double_1,
        point3D_0 = this.list_0.ToArray(),
        vector3D_0 = this.vector3D_0
      }.method_0), new System.Action(class902.method_0)));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      IList<Polyline4D> polylines4D = this.GetPolylines4D(context.GetTransformer());
      if (polylines4D.Count <= 0)
        return;
      graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, polylines4D, context.Model.Header.FillMode && this.vector3D_0.X == 0.0 && this.vector3D_0.Y == 0.0, true);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      IList<Polyline4D> polylines4D = this.GetPolylines4D(context.GetTransformer());
      if (polylines4D.Count <= 0)
        return;
      bool fill = context.Model.Header.FillMode && this.vector3D_0.X == 0.0 && this.vector3D_0.Y == 0.0;
      Class940.smethod_3((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, fill, !fill, polylines4D);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      graphicsFactory.SetColor(context.GetPlotColor((DxfEntity) this));
      WW.Math.Geometry.Polyline3D polyline = this.method_13();
      if (this.Thickness != 0.0)
        Class940.Extrude((DxfEntity) this, context, graphicsFactory, polyline, this.Model.Header.FillMode, this.Thickness * this.ZAxis);
      else
        Class940.smethod_17((DxfEntity) this, context, graphicsFactory, polyline, this.Model.Header.FillMode);
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
      WW.Math.Geometry.Polyline3D polyline = this.method_13();
      if (this.double_1 != 0.0)
        Class940.Extrude(graphicElement.Geometry, polyline, this.Model.Header.FillMode, this.Thickness * this.ZAxis);
      else
        Class940.smethod_21((DxfEntity) this, context, graphicElement.Geometry, polyline, this.Model.Header.FillMode);
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      bool flag = true;
      if (this.list_0.Count != 4)
      {
        messages.Add(new DxfMessage(DxfStatus.InvalidNoOfPointsForSolid, Severity.Error, "target", (object) this));
        flag = false;
      }
      return flag;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfSolid dxfSolid = (DxfSolid) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfSolid == null)
      {
        dxfSolid = new DxfSolid();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfSolid);
        dxfSolid.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfSolid;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfSolid dxfSolid = (DxfSolid) from;
      this.list_0.AddRange((IEnumerable<WW.Math.Point3D>) dxfSolid.list_0);
      this.vector3D_0 = dxfSolid.vector3D_0;
      this.double_1 = dxfSolid.double_1;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override short vmethod_6(Class432 w)
    {
      return 31;
    }

    private WW.Math.Geometry.Polyline3D method_13()
    {
      WW.Math.Geometry.Polyline3D polyline3D = new WW.Math.Geometry.Polyline3D(true);
      Matrix4D transform = this.Transform;
      polyline3D.Add(transform.Transform(this.list_0[0]));
      polyline3D.Add(transform.Transform(this.list_0[1]));
      if (this.list_0.Count == 3)
      {
        polyline3D.Add(transform.Transform(this.list_0[2]));
      }
      else
      {
        if (this.list_0[3] != this.list_0[0] && this.list_0[3] != this.list_0[2])
          polyline3D.Add(transform.Transform(this.list_0[3]));
        polyline3D.Add(transform.Transform(this.list_0[2]));
      }
      return polyline3D;
    }

    private IList<Polyline4D> GetPolylines4D(IClippingTransformer transformer)
    {
      WW.Math.Geometry.Polyline3D polyline3D = this.method_13();
      List<WW.Math.Geometry.Polyline3D> polyline3DList = new List<WW.Math.Geometry.Polyline3D>(1);
      polyline3DList.Add(polyline3D);
      if (this.Thickness != 0.0)
        DxfUtil.Extrude((IList<WW.Math.Geometry.Polyline3D>) polyline3DList, this.Thickness, this.ZAxis);
      return DxfUtil.smethod_36((IList<WW.Math.Geometry.Polyline3D>) polyline3DList, polyline3D.Closed, transformer);
    }
  }
}
