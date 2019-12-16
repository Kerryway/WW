// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfXLine
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
  public class DxfXLine : DxfEntity
  {
    private WW.Math.Point3D point3D_0;
    private Vector3D vector3D_0;

    public DxfXLine()
    {
    }

    public DxfXLine(WW.Math.Point3D startPoint, Vector3D direction)
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
      DxfXLine.Class977 class977 = new DxfXLine.Class977();
      // ISSUE: reference to a compiler-generated field
      class977.dxfXLine_0 = this;
      // ISSUE: reference to a compiler-generated field
      class977.point3D_0 = this.point3D_0;
      // ISSUE: reference to a compiler-generated field
      class977.vector3D_0 = this.vector3D_0;
      this.point3D_0 = matrix.Transform(this.point3D_0);
      this.vector3D_0 = matrix.Transform(this.vector3D_0).GetUnit();
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfXLine.Class978()
      {
        class977_0 = class977,
        point3D_0 = this.point3D_0,
        vector3D_0 = this.vector3D_0
      }.method_0), new System.Action(class977.method_0)));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      IClippingTransformer transformer = context.GetTransformer();
      Vector3D vector3D = 10000000.0 * this.vector3D_0;
      WW.Math.Point3D start = this.point3D_0 - vector3D;
      WW.Math.Point3D end = this.point3D_0 + vector3D;
      foreach (Segment4D segment in (IEnumerable<Segment4D>) transformer.Transform(new Segment3D(start, end)))
      {
        Vector4D? startPoint = transformer.Transform(this.point3D_0);
        graphicsFactory.CreateXLine((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), startPoint, segment);
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      IClippingTransformer transformer = context.GetTransformer();
      Vector3D vector3D = 10000000.0 * this.vector3D_0;
      WW.Math.Point3D start = this.point3D_0 - vector3D;
      WW.Math.Point3D end = this.point3D_0 + vector3D;
      foreach (Segment4D segment in (IEnumerable<Segment4D>) transformer.Transform(new Segment3D(start, end)))
      {
        Vector4D? startPoint = transformer.Transform(this.point3D_0);
        graphicsFactory.BeginGeometry((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, false, true, true);
        graphicsFactory.CreateXLine((DxfEntity) this, startPoint, segment);
        graphicsFactory.EndGeometry();
      }
    }

    public override string EntityType
    {
      get
      {
        return "XLINE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbXline";
      }
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfXLine dxfXline = (DxfXLine) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfXline == null)
      {
        dxfXline = new DxfXLine();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfXline);
        dxfXline.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfXline;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfXLine dxfXline = (DxfXLine) from;
      this.point3D_0 = dxfXline.point3D_0;
      this.vector3D_0 = dxfXline.vector3D_0;
    }

    internal override short vmethod_6(Class432 w)
    {
      return 41;
    }
  }
}
