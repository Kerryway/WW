// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfShape
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns28;
using System;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;

namespace WW.Cad.Model.Entities
{
  public class DxfShape : DxfEntity
  {
    private DxfObjectReference dxfObjectReference_6 = DxfObjectReference.Null;
    private double double_2 = 1.0;
    private double double_4 = 1.0;
    private Vector3D vector3D_0 = Vector3D.ZAxis;
    private ushort ushort_0;
    private double double_1;
    private WW.Math.Point3D point3D_0;
    private double double_3;
    private double double_5;
    private string string_0;

    internal DxfShape()
    {
    }

    public DxfShape(DxfTextStyle textStyle, ushort shapeIndex, WW.Math.Point2D insertionPoint)
    {
      if (textStyle == null)
        throw new ArgumentNullException(nameof (textStyle));
      this.TextStyle = textStyle;
      this.ushort_0 = shapeIndex;
      this.point3D_0 = (WW.Math.Point3D) insertionPoint;
      ShxFile shxFile = textStyle.GetShxFile();
      if (shxFile == null)
        throw new ArgumentException("Shx file with name " + textStyle.FontFilename + " not found.");
      this.method_13(shxFile);
    }

    public DxfShape(DxfTextStyle textStyle, ushort shapeIndex, WW.Math.Point3D insertionPoint)
    {
      if (textStyle == null)
        throw new ArgumentNullException(nameof (textStyle));
      this.TextStyle = textStyle;
      this.ushort_0 = shapeIndex;
      this.point3D_0 = insertionPoint;
      ShxFile shxFile = textStyle.GetShxFile();
      if (shxFile == null)
        throw new ArgumentException("Shx file with name " + textStyle.FontFilename + " not found.");
      this.method_13(shxFile);
    }

    public DxfTextStyle TextStyle
    {
      get
      {
        return (DxfTextStyle) this.dxfObjectReference_6.Value;
      }
      private set
      {
        this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public ushort ShapeIndex
    {
      get
      {
        return this.ushort_0;
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

    public WW.Math.Point3D InsertionPoint
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

    public double ScaleFactor
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

    public double Rotation
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

    public double RelativeXScaleFactor
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

    public double ObliqueAngle
    {
      get
      {
        return this.double_5;
      }
      set
      {
        this.double_5 = value;
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

    public override Matrix4D Transform
    {
      get
      {
        double m00 = this.double_2 * this.double_4;
        double m01 = this.double_2 * System.Math.Tan(-this.double_5);
        return DxfUtil.GetToWCSTransform(this.vector3D_0) * Transformation4D.Translation(this.point3D_0 - WW.Math.Point3D.Zero) * Transformation4D.RotateZ(this.double_3) * new Matrix4D(m00, m01, 0.0, 0.0, 0.0, this.double_2, 0.0, 0.0, 0.0, 0.0, this.double_2, 0.0, 0.0, 0.0, 0.0, 1.0);
      }
    }

    public void SetShape(DxfTextStyle textStyle, ushort shapeIndex)
    {
      this.SetShape(this.Model, textStyle, shapeIndex, true);
    }

    public override string EntityType
    {
      get
      {
        return "SHAPE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbShape";
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
      DxfShape.Class676 class676 = new DxfShape.Class676();
      // ISSUE: reference to a compiler-generated field
      class676.dxfShape_0 = this;
      // ISSUE: reference to a compiler-generated field
      class676.double_0 = this.double_1;
      // ISSUE: reference to a compiler-generated field
      class676.point3D_0 = this.point3D_0;
      // ISSUE: reference to a compiler-generated field
      class676.double_1 = this.double_2;
      // ISSUE: reference to a compiler-generated field
      class676.double_2 = this.double_3;
      // ISSUE: reference to a compiler-generated field
      class676.vector3D_0 = this.vector3D_0;
      this.vector3D_0 = matrix.Transform(this.vector3D_0);
      this.double_1 *= this.vector3D_0.GetLength();
      this.vector3D_0.Normalize();
      Matrix4D inverse = DxfUtil.GetToWCSTransform(this.vector3D_0).GetInverse();
      // ISSUE: reference to a compiler-generated field
      Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(class676.vector3D_0);
      Matrix4D matrix4D = inverse * matrix * toWcsTransform;
      this.point3D_0 = matrix4D.Transform(this.point3D_0);
      this.double_2 *= matrix.Transform(new Vector2D(1.0, 0.0)).GetLength();
      this.double_3 = matrix4D.TransformAngle(this.double_3);
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfShape.Class677()
      {
        class676_0 = class676,
        double_0 = this.double_1,
        point3D_0 = this.point3D_0,
        double_1 = this.double_2,
        double_2 = this.double_3,
        vector3D_0 = this.vector3D_0
      }.method_0), new System.Action(class676.method_0)));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      DxfTextStyle textStyle = this.TextStyle;
      if (textStyle == null)
        return;
      ShxFile shxFile = textStyle.GetShxFile();
      if (shxFile == null)
        return;
      ShxShape shapeByIndex = shxFile.GetShapeByIndex(this.ushort_0);
      if (shapeByIndex == null)
        return;
      WW.Math.Point2D endPoint;
      new ns0.Class0((DxfEntity) this, context, graphicsFactory).DrawPath(shapeByIndex.GetGlyphShape(false, out endPoint), this.Transform, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this), false, false, this.double_1);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      DxfTextStyle textStyle = this.TextStyle;
      if (textStyle == null)
        return;
      ShxFile shxFile = textStyle.GetShxFile();
      if (shxFile == null)
        return;
      ShxShape shapeByIndex = shxFile.GetShapeByIndex(this.ushort_0);
      if (shapeByIndex == null)
        return;
      WW.Math.Point2D endPoint;
      new Class396((DxfEntity) this, context, graphicsFactory).DrawPath(shapeByIndex.GetGlyphShape(false, out endPoint), this.Transform, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this), false, false, this.double_1);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      DxfTextStyle textStyle = this.TextStyle;
      if (textStyle == null)
        return;
      ShxFile shxFile = textStyle.GetShxFile();
      if (shxFile == null)
        return;
      ShxShape shapeByIndex = shxFile.GetShapeByIndex(this.ushort_0);
      if (shapeByIndex == null)
        return;
      WW.Math.Point2D endPoint;
      new Class473((DxfEntity) this, context, graphicsFactory).DrawPath(shapeByIndex.GetGlyphShape(false, out endPoint), this.Transform, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this), false, false, this.double_1);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      DxfTextStyle textStyle = this.TextStyle;
      if (textStyle == null)
        return;
      ShxFile shxFile = textStyle.GetShxFile();
      if (shxFile == null)
        return;
      ShxShape shapeByIndex = shxFile.GetShapeByIndex(this.ushort_0);
      if (shapeByIndex == null)
        return;
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      if (!graphics.AddExistingGraphicElement1(parentGraphicElementBlock, (DxfEntity) this, plotColor))
        return;
      WW.Math.Point2D endPoint;
      new Class355((DxfEntity) this, context, graphics, parentGraphicElementBlock).DrawPath(shapeByIndex.GetGlyphShape(false, out endPoint), this.Transform, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this), false, false, this.double_1);
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfShape dxfShape = (DxfShape) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfShape == null)
      {
        dxfShape = new DxfShape();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfShape);
        dxfShape.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfShape;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfShape dxfShape = (DxfShape) from;
      this.TextStyle = Class906.GetTextStyle(cloneContext, dxfShape.TextStyle);
      this.ushort_0 = dxfShape.ushort_0;
      this.double_1 = dxfShape.double_1;
      this.point3D_0 = dxfShape.point3D_0;
      this.double_2 = dxfShape.double_2;
      this.double_3 = dxfShape.double_3;
      this.double_4 = dxfShape.double_4;
      this.double_5 = dxfShape.double_5;
      this.vector3D_0 = dxfShape.vector3D_0;
      this.string_0 = dxfShape.string_0;
    }

    internal void SetShape(
      DxfModel model,
      DxfTextStyle textStyle,
      ushort shapeIndex,
      bool updateName)
    {
      this.TextStyle = textStyle;
      this.ushort_0 = shapeIndex;
      if (!updateName)
        return;
      this.method_13(model.GetShxFile(textStyle.FontFilename));
    }

    private void method_13(ShxFile shxFile)
    {
      if (shxFile != null)
      {
        ShxShape shapeByIndex = shxFile.GetShapeByIndex(this.ushort_0);
        if (shapeByIndex != null)
          this.string_0 = shapeByIndex.Description;
        else
          this.string_0 = string.Empty;
      }
      else
        this.string_0 = string.Empty;
    }

    internal void method_14(ushort shapeIndex)
    {
      this.ushort_0 = shapeIndex;
    }

    internal string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return 33;
    }
  }
}
