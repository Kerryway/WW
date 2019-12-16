// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfRay
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfRay : DxfEntity
  {
    private WW.Math.Point3D point3D_0;
    private Vector3D vector3D_0;

    public DxfRay()
    {
    }

    public DxfRay(WW.Math.Point3D startPoint, Vector3D direction)
    {
      this.point3D_0 = startPoint;
      this.vector3D_0 = direction;
    }

    public Vector3D Direction
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

    public WW.Math.Point3D StartPoint
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
      DxfRay.Class1056 class1056 = new DxfRay.Class1056();
      // ISSUE: reference to a compiler-generated field
      class1056.dxfRay_0 = this;
      // ISSUE: reference to a compiler-generated field
      class1056.point3D_0 = this.point3D_0;
      // ISSUE: reference to a compiler-generated field
      class1056.vector3D_0 = this.vector3D_0;
      this.point3D_0 = matrix.Transform(this.point3D_0);
      this.vector3D_0 = matrix.Transform(this.vector3D_0).GetUnit();
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfRay.Class1057()
      {
        class1056_0 = class1056,
        point3D_0 = this.point3D_0,
        vector3D_0 = this.vector3D_0
      }.method_0), new System.Action(class1056.method_0)));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      foreach (Segment4D segment in (IEnumerable<Segment4D>) context.GetTransformer().Transform(new Segment3D(this.point3D_0, this.point3D_0 + 10000000.0 * this.vector3D_0)))
        graphicsFactory.CreateRay((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), segment);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      foreach (Segment4D segment in (IEnumerable<Segment4D>) context.GetTransformer().Transform(new Segment3D(this.point3D_0, this.point3D_0 + 10000000.0 * this.vector3D_0)))
      {
        graphicsFactory.BeginGeometry((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, false, true, true);
        graphicsFactory.CreateRay((DxfEntity) this, segment);
        graphicsFactory.EndGeometry();
      }
    }

    public override string EntityType
    {
      get
      {
        return "RAY";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbRay";
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfRay dxfRay = (DxfRay) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfRay == null)
      {
        dxfRay = new DxfRay();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfRay);
        dxfRay.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfRay;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfRay dxfRay = (DxfRay) from;
      this.point3D_0 = dxfRay.point3D_0;
      this.vector3D_0 = dxfRay.vector3D_0;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override short vmethod_6(Class432 w)
    {
      return 40;
    }
  }
}
