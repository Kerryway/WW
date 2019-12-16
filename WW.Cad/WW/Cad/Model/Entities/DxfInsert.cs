// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfInsert
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using ns33;
using ns36;
using ns49;
using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Tables;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfInsert : DxfInsertBase, IAnnotative
  {
    private ushort ushort_0 = 1;
    private ushort ushort_1 = 1;
    private double double_1;
    private double double_2;
    private bool bool_2;

    public DxfInsert()
      : base((DxfBlock) null)
    {
    }

    public DxfInsert(DxfBlock block)
      : base(block, WW.Math.Point3D.Zero)
    {
    }

    public DxfInsert(DxfBlock block, WW.Math.Point3D insertionPoint)
      : base(block, insertionPoint)
    {
    }

    public override WW.Math.Point3D InsertionPoint
    {
      get
      {
        if (!this.IsAnnotative)
          return this.insertionPoint;
        DxfBlockReferenceObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfBlockReferenceObjectContextData;
        if (objectContextData != null)
          return objectContextData.InsertionPoint;
        return this.insertionPoint;
      }
      set
      {
        if (!this.IsAnnotative)
        {
          this.insertionPoint = value;
        }
        else
        {
          DxfBlockReferenceObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfBlockReferenceObjectContextData;
          if (objectContextData != null)
            objectContextData.InsertionPoint = value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.insertionPoint = value;
        }
      }
    }

    public override double Rotation
    {
      get
      {
        if (!this.IsAnnotative)
          return this.rotation;
        DxfBlockReferenceObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfBlockReferenceObjectContextData;
        if (objectContextData != null)
          return objectContextData.Rotation;
        return this.rotation;
      }
      set
      {
        if (!this.IsAnnotative)
        {
          this.rotation = value;
        }
        else
        {
          DxfBlockReferenceObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfBlockReferenceObjectContextData;
          if (objectContextData != null)
            objectContextData.Rotation = value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.rotation = value;
        }
      }
    }

    public override WW.Math.Vector3D ScaleFactor
    {
      get
      {
        if (!this.IsAnnotative)
          return this.scaleFactor;
        DxfBlockReferenceObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfBlockReferenceObjectContextData;
        if (objectContextData != null)
          return objectContextData.ScaleFactor;
        return this.scaleFactor;
      }
      set
      {
        if (!this.IsAnnotative)
        {
          this.scaleFactor = value;
        }
        else
        {
          DxfBlockReferenceObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfBlockReferenceObjectContextData;
          if (objectContextData != null)
            objectContextData.ScaleFactor = value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.scaleFactor = value;
        }
      }
    }

    public ushort ColumnCount
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

    public double ColumnSpacing
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

    public ushort RowCount
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

    public double RowSpacing
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
        return "INSERT";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbMInsertBlock";
      }
    }

    public Matrix4D BasicBlockInsertionTransformation
    {
      get
      {
        return DxfUtil.GetToWCSTransform(this.ZAxis) * Transformation4D.Translation((WW.Math.Vector3D) this.InsertionPoint) * Transformation4D.RotateZ(this.Rotation) * Transformation4D.Scaling(this.ScaleFactor);
      }
    }

    public Matrix4D[,] BlockInsertionTransformations
    {
      get
      {
        Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(this.ZAxis);
        Matrix4D matrix4D1 = Transformation4D.Translation((WW.Math.Vector3D) this.InsertionPoint);
        Matrix4D matrix4D2 = Transformation4D.RotateZ(this.Rotation);
        Matrix4D matrix4D3 = Transformation4D.Scaling(this.ScaleFactor);
        ushort num1 = this.RowCount;
        if (num1 < (ushort) 1)
          num1 = (ushort) 1;
        ushort num2 = this.ColumnCount;
        if (num2 < (ushort) 1)
          num2 = (ushort) 1;
        Matrix4D[,] matrix4DArray = new Matrix4D[(int) num1, (int) num2];
        for (int index1 = 0; index1 < (int) num1; ++index1)
        {
          for (int index2 = 0; index2 < (int) num2; ++index2)
          {
            Matrix4D matrix4D4 = toWcsTransform * matrix4D1 * matrix4D2 * Transformation4D.Translation((double) index2 * this.ColumnSpacing, (double) index1 * this.RowSpacing, 0.0) * matrix4D3;
            matrix4DArray[index1, index2] = matrix4D4;
          }
        }
        return matrix4DArray;
      }
    }

    public Matrix4D[,] AttributeInsertionTransformations
    {
      get
      {
        Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(this.ZAxis);
        Matrix4D matrix4D1 = Transformation4D.RotateZ(this.Rotation);
        ushort num1 = this.RowCount;
        if (num1 < (ushort) 1)
          num1 = (ushort) 1;
        ushort num2 = this.ColumnCount;
        if (num2 < (ushort) 1)
          num2 = (ushort) 1;
        Matrix4D[,] matrix4DArray = new Matrix4D[(int) num1, (int) num2];
        for (int index1 = 0; index1 < (int) num1; ++index1)
        {
          for (int index2 = 0; index2 < (int) num2; ++index2)
          {
            WW.Math.Vector3D vector = new WW.Math.Vector3D((double) index2 * this.ColumnSpacing, (double) index1 * this.RowSpacing, 0.0);
            vector = (toWcsTransform * matrix4D1).Transform(vector);
            Matrix4D matrix4D2 = Transformation4D.Translation(vector.X, vector.Y, vector.Z);
            matrix4DArray[index1, index2] = matrix4D2;
          }
        }
        return matrix4DArray;
      }
    }

    public bool IsMultipleInsertion
    {
      get
      {
        ushort num1 = this.RowCount;
        if (num1 < (ushort) 1)
          num1 = (ushort) 1;
        ushort num2 = this.ColumnCount;
        if (num2 < (ushort) 1)
          num2 = (ushort) 1;
        if (num1 <= (ushort) 1)
          return num2 > (ushort) 1;
        return true;
      }
    }

    public DxfSpatialFilter SpatialFilter
    {
      get
      {
        DxfSpatialFilter dxfSpatialFilter = (DxfSpatialFilter) null;
        DxfDictionary extensionDictionary = this.ExtensionDictionary;
        if (extensionDictionary != null)
        {
          DxfDictionary valueByName = extensionDictionary.GetValueByName("ACAD_FILTER") as DxfDictionary;
          if (valueByName != null)
            dxfSpatialFilter = valueByName.GetValueByName("SPATIAL") as DxfSpatialFilter;
        }
        return dxfSpatialFilter;
      }
      set
      {
        if (value == null && this.SpatialFilter != null)
        {
          DxfDictionary extensionDictionary = this.ExtensionDictionary;
          DxfDictionary valueByName = extensionDictionary.GetValueByName("ACAD_FILTER") as DxfDictionary;
          if (valueByName.Entries.Count == 1)
          {
            extensionDictionary.Entries.Remove(extensionDictionary.Entries.GetFirst("ACAD_FILTER"));
            if (extensionDictionary.Entries.Count != 0)
              return;
            this.ExtensionDictionary = (DxfDictionary) null;
          }
          else
            valueByName.Entries.Remove(valueByName.Entries.GetFirst("SPATIAL"));
        }
        else
        {
          DxfDictionary dxfDictionary1 = this.ExtensionDictionary;
          if (dxfDictionary1 == null)
            this.ExtensionDictionary = dxfDictionary1 = new DxfDictionary();
          DxfDictionary dxfDictionary2 = dxfDictionary1.GetValueByName("ACAD_FILTER") as DxfDictionary;
          if (dxfDictionary2 == null)
          {
            dxfDictionary2 = new DxfDictionary();
            dxfDictionary1.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("ACAD_FILTER", (DxfObject) dxfDictionary2, true));
          }
          dxfDictionary2.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("SPATIAL", (DxfObject) value, true));
        }
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      graphicsFactory.BeginInsert(this);
      this.DrawInternal((DxfInsert.Interface46) new DxfInsert.Class1019((DxfEntity) this, context, graphicsFactory), true);
      graphicsFactory.EndInsert();
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      graphicsFactory.BeginInsert(this);
      this.DrawInternal((DxfInsert.Interface46) new DxfInsert.Class1020((DxfEntity) this, context, graphicsFactory), true);
      graphicsFactory.EndInsert();
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      this.DrawInternal((DxfInsert.Interface46) new DxfInsert.Class1021((DxfEntity) this, context, graphicsFactory), true);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      DrawContext.Surface childContext = context.CreateChildContext((DxfEntity) this, Matrix4D.Identity);
      GraphicElementInsert graphicElement;
      if (!graphics.GetGraphicElementInsert(parentGraphicElementBlock, (DxfEntity) this, childContext.Layer, childContext.ByBlockColor, childContext.ByBlockLineType, out graphicElement))
        return;
      this.DrawInternal((DxfInsert.Interface46) new DxfInsert.Class1022(this, context, graphics, parentGraphicElementBlock, graphicElement), true);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfInsert dxfInsert = (DxfInsert) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfInsert == null)
      {
        dxfInsert = new DxfInsert();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfInsert);
        dxfInsert.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfInsert;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfInsert dxfInsert = (DxfInsert) from;
      this.ushort_0 = dxfInsert.ushort_0;
      this.double_1 = dxfInsert.double_1;
      this.ushort_1 = dxfInsert.ushort_1;
      this.double_2 = dxfInsert.double_2;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public DxfAttribute AddAttribute(DxfAttributeDefinition attdef, string text)
    {
      DxfAttribute dxfAttribute = new DxfAttribute(attdef, text);
      this.Attributes.Add(dxfAttribute);
      if (dxfAttribute.Model == null)
      {
        try
        {
          dxfAttribute.Style = attdef.Style;
        }
        catch (NullReferenceException ex)
        {
          throw new DxfException("Cannot create attribute from attribute definition which is not attached to a model!\nDid you already add the attribute definition to a block and the block to the model's Blocks?");
        }
      }
      WW.Math.Vector3D vector3D = this.Block != null ? this.Block.BasePoint : WW.Math.Vector3D.Zero;
      dxfAttribute.FixAlignmentPoints();
      dxfAttribute.TransformMe((TransformConfig) GraphicsConfig.WhiteBackground, this.BasicBlockInsertionTransformation * Transformation4D.Translation(-vector3D));
      return dxfAttribute;
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
    }

    internal override void vmethod_10(DxfModel model)
    {
      base.vmethod_10(model);
      DxfAnnotationScaleObjectContextData.smethod_8((DxfEntity) this);
      this.bool_2 = Class1064.smethod_0((DxfHandledObject) this.Block, model);
      if (!this.bool_2 || DxfAnnotationScaleObjectContextData.smethod_5((DxfHandledObject) this, true) != null)
        return;
      DxfScale currentAnnotationScale = model.Header.CurrentAnnotationScale;
      DxfInsert dxfInsert = this;
      dxfInsert.scaleFactor = dxfInsert.scaleFactor / currentAnnotationScale.ScaleFactor;
      DxfDictionary dxfDictionary = DxfAnnotationScaleObjectContextData.smethod_6((DxfHandledObject) this);
      DxfAnnotationScaleObjectContextData contextData = this.CreateContextData(currentAnnotationScale);
      contextData.IsDefault = true;
      dxfDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry("*A", (DxfObject) contextData));
    }

    internal override short vmethod_6(Class432 w)
    {
      return this.RowCount <= (ushort) 1 && this.ColumnCount <= (ushort) 1 ? (short) 7 : (short) 8;
    }

    private void DrawInternal(DxfInsert.Interface46 drawHandler, bool drawBlock)
    {
      Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(this.ZAxis);
      Matrix4D matrix4D1 = Transformation4D.Translation((WW.Math.Vector3D) this.InsertionPoint);
      Matrix4D matrix4D2 = Transformation4D.RotateZ(this.Rotation);
      Matrix4D matrix4D3 = Transformation4D.Scaling(this.ScaleFactor);
      ushort num1 = this.RowCount;
      if (num1 < (ushort) 1)
        num1 = (ushort) 1;
      ushort num2 = this.ColumnCount;
      if (num2 < (ushort) 1)
        num2 = (ushort) 1;
      for (int row = 0; row < (int) num1; ++row)
      {
        for (int column = 0; column < (int) num2; ++column)
        {
          if (drawBlock)
          {
            Matrix4D matrix4D4 = toWcsTransform * matrix4D1 * matrix4D2 * Transformation4D.Translation((double) column * this.ColumnSpacing, (double) row * this.RowSpacing, 0.0) * matrix4D3;
            drawHandler.imethod_0(row, column, matrix4D4);
            if (this.Block != null)
            {
              switch (this.method_16(matrix4D4, drawHandler))
              {
                case DxfInsert.Enum44.const_1:
                case DxfInsert.Enum44.const_2:
                  drawHandler.Draw(this.Block, true);
                  break;
                case DxfInsert.Enum44.const_3:
                  drawHandler.Draw(this.Block, true);
                  drawHandler.InsertCellDrawContext.vmethod_1();
                  break;
              }
            }
          }
          if (this.Attributes.Count > 0)
          {
            WW.Math.Vector3D vector = new WW.Math.Vector3D((double) column * this.ColumnSpacing, (double) row * this.RowSpacing, 0.0);
            vector = (toWcsTransform * matrix4D2).Transform(vector);
            Matrix4D instanceTransform = Transformation4D.Translation(vector.X, vector.Y, vector.Z);
            drawHandler.imethod_1(row, column, instanceTransform);
            foreach (DxfAttribute attribute in (IEnumerable<DxfAttribute>) this.Attributes)
              drawHandler.Draw(attribute);
          }
        }
      }
    }

    private DxfInsert.Enum44 method_16(
      Matrix4D insertionTransform,
      DxfInsert.Interface46 drawHandler)
    {
      if (drawHandler.InsertCellDrawContext.Config.UseSpatialFilters)
      {
        DxfSpatialFilter spatialFilter = this.SpatialFilter;
        if (spatialFilter != null && spatialFilter.ClipBoundaryDisplayEnabled)
        {
          Polygon2D clipPolygon = spatialFilter.GetClipBoundaryPolygon();
          if (clipPolygon.Count < 3)
            return DxfInsert.Enum44.const_1;
          if (clipPolygon.GetArea() < 0.0)
            clipPolygon = clipPolygon.GetReverse();
          Matrix4D boundaryTransform = spatialFilter.ClipBoundaryTransform;
          Matrix4D transform = insertionTransform * this.Block.BaseTransformation * spatialFilter.InverseInsertionTransform;
          Matrix4D inverse1 = boundaryTransform.GetInverse();
          Matrix4D clipBoundaryTransform = transform * inverse1;
          DxfInsert.Enum44 enum44;
          if (clipPolygon.IsConvex())
          {
            List<BlinnClipper4D.ClipPlane> clipPlaneList = new List<BlinnClipper4D.ClipPlane>();
            WW.Math.Point2D point2D = clipPolygon[clipPolygon.Count - 1];
            WW.Math.Vector3D boundaryPlaneNormal = spatialFilter.ClipBoundaryPlaneNormal;
            Matrix4D inverse2 = transform.GetInverse();
            inverse2.Transpose();
            foreach (WW.Math.Point2D point in (List<WW.Math.Point2D>) clipPolygon)
            {
              Vector2D v = point - point2D;
              BlinnClipper4D.ClipPlane clipPlane = new BlinnClipper4D.ClipPlane(WW.Math.Vector3D.CrossProduct(inverse1.TransformTo3D(v), boundaryPlaneNormal), inverse1.TransformTo3D(point));
              clipPlane.TransformBy(transform, inverse2);
              clipPlaneList.Add(clipPlane);
              point2D = point;
            }
            BoundsCalculator boundsCalculator = new BoundsCalculator();
            boundsCalculator.GetBounds(drawHandler.InsertCellDrawContext.Model, (IEnumerable<DxfEntity>) this.Block.Entities, insertionTransform * this.Block.BaseTransformation);
            switch (new BlinnClipper4D((ICollection<BlinnClipper4D.ClipPlane>) clipPlaneList).TryIsInside(boundsCalculator.Bounds))
            {
              case InsideTestResult.Inside:
                enum44 = DxfInsert.Enum44.const_2;
                break;
              case InsideTestResult.Outside:
                enum44 = DxfInsert.Enum44.const_0;
                break;
              default:
                enum44 = DxfInsert.Enum44.const_3;
                break;
            }
            if (enum44 == DxfInsert.Enum44.const_3)
            {
              Class808 class808 = new Class808((ICollection<BlinnClipper4D.ClipPlane>) clipPlaneList);
              class808.imethod_0(insertionTransform.GetInverse());
              GraphicsConfig config = drawHandler.InsertCellDrawContext.Config;
              ModelSpaceClippingTransformer clippingTransformer = new ModelSpaceClippingTransformer(Matrix4D.Identity, (Interface32) class808, config.ShapeFlattenEpsilon, config.ShapeFlattenEpsilonForBoundsCalculation);
              drawHandler.InsertCellDrawContext.vmethod_0((IClippingTransformer) clippingTransformer);
            }
          }
          else
          {
            Class455 class455 = new Class455(clipBoundaryTransform, clipPolygon, false);
            BoundsCalculator boundsCalculator = new BoundsCalculator();
            boundsCalculator.GetBounds(drawHandler.InsertCellDrawContext.Model, (IEnumerable<DxfEntity>) this.Block.Entities, insertionTransform * this.Block.BaseTransformation);
            switch (class455.TryIsInside(boundsCalculator.Bounds))
            {
              case InsideTestResult.Inside:
                enum44 = DxfInsert.Enum44.const_2;
                break;
              case InsideTestResult.Outside:
                enum44 = DxfInsert.Enum44.const_0;
                break;
              default:
                enum44 = DxfInsert.Enum44.const_3;
                break;
            }
            if (enum44 == DxfInsert.Enum44.const_3)
            {
              Matrix4D inverse2 = insertionTransform.GetInverse();
              class455.imethod_0(inverse2);
              GraphicsConfig config = drawHandler.InsertCellDrawContext.Config;
              ModelSpaceClippingTransformer clippingTransformer = new ModelSpaceClippingTransformer(Matrix4D.Identity, (Interface32) class455, config.ShapeFlattenEpsilon, config.ShapeFlattenEpsilonForBoundsCalculation);
              drawHandler.InsertCellDrawContext.vmethod_0((IClippingTransformer) clippingTransformer);
            }
          }
          if ((!spatialFilter.ClipBoundaryDisplayEnabled || drawHandler.InsertCellDrawContext.Model.Header.ExternalReferenceClippingBoundaryType == WW.Cad.Model.SimpleLineType.Off ? 0 : (this.IsEntityVisibleInContext(drawHandler.InsertCellDrawContext, true) ? 1 : 0)) != 0)
          {
            WW.Math.Geometry.Polyline3D polygon = new WW.Math.Geometry.Polyline3D(clipPolygon.Count);
            foreach (WW.Math.Point2D point in (List<WW.Math.Point2D>) clipPolygon)
              polygon.Add(clipBoundaryTransform.TransformTo3D(point));
            polygon.Closed = true;
            drawHandler.Draw(polygon);
          }
          return enum44;
        }
      }
      return DxfInsert.Enum44.const_1;
    }

    public bool IsAnnotative
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
      }
    }

    public DxfAnnotationScaleObjectContextData CreateContextData(
      DxfScale scale)
    {
      return (DxfAnnotationScaleObjectContextData) new DxfBlockReferenceObjectContextData((DxfInsertBase) this, scale);
    }

    private enum Enum44
    {
      const_0 = -1,
      const_1 = 0,
      const_2 = 1,
      const_3 = 2,
    }

    internal interface Interface46
    {
      DrawContext InsertCellDrawContext { get; }

      void imethod_0(int row, int column, Matrix4D instanceTransform);

      void Draw(DxfBlock block, bool applyBlockBaseTransformation);

      void Draw(WW.Math.Geometry.Polyline3D polygon);

      void imethod_1(int row, int column, Matrix4D instanceTransform);

      void Draw(DxfAttribute attribute);

      void imethod_2(Matrix4D blockTransform);

      void Draw(DxfBlock block, DxfModel model);

      void imethod_3(DxfEntity entity);
    }

    internal class Class1019 : DxfInsert.Interface46
    {
      private DrawContext.Wireframe wireframe_0;
      private DrawContext.Wireframe wireframe_1;
      private DrawContext.Wireframe wireframe_2;
      private DxfEntity dxfEntity_0;
      private IWireframeGraphicsFactory iwireframeGraphicsFactory_0;

      public Class1019(
        DxfEntity insert,
        DrawContext.Wireframe drawContext,
        IWireframeGraphicsFactory graphicsFactory)
      {
        this.dxfEntity_0 = insert;
        this.wireframe_0 = drawContext;
        this.iwireframeGraphicsFactory_0 = graphicsFactory;
      }

      public DrawContext InsertCellDrawContext
      {
        get
        {
          return (DrawContext) this.wireframe_1;
        }
      }

      public void imethod_0(int row, int column, Matrix4D instanceTransform)
      {
        this.wireframe_1 = this.wireframe_0.CreateChildContext(this.dxfEntity_0, instanceTransform);
      }

      public void Draw(DxfBlock block, bool applyBlockBaseTransformation)
      {
        block.DrawInternal((DxfInsert.Interface46) this, applyBlockBaseTransformation);
      }

      public void Draw(WW.Math.Geometry.Polyline3D polygon)
      {
        this.iwireframeGraphicsFactory_0.CreatePath(this.dxfEntity_0, this.wireframe_0, this.wireframe_0.GetPlotColor(this.dxfEntity_0), false, this.wireframe_0.GetTransformer().Transform(polygon, false), false, true);
      }

      public void imethod_1(int row, int column, Matrix4D instanceTransform)
      {
        this.wireframe_1 = this.wireframe_0.CreateChildContext(this.dxfEntity_0, instanceTransform);
        this.wireframe_1.Row = row;
        this.wireframe_1.Column = column;
      }

      public void Draw(DxfAttribute attribute)
      {
        attribute.Draw(this.wireframe_1, this.iwireframeGraphicsFactory_0);
      }

      public void imethod_2(Matrix4D blockTransform)
      {
        this.wireframe_2 = this.wireframe_1.CreateChildContext(this.wireframe_1.BlockContext, blockTransform);
      }

      public void Draw(DxfBlock block, DxfModel model)
      {
        DrawContext.Wireframe childContext = this.wireframe_1.CreateChildContext(this.wireframe_1.BlockContext, block.BaseTransformation, block, model);
        model.Draw(childContext, this.iwireframeGraphicsFactory_0);
      }

      public void imethod_3(DxfEntity entity)
      {
        entity.Draw(this.wireframe_2, this.iwireframeGraphicsFactory_0);
      }
    }

    internal class Class1020 : DxfInsert.Interface46
    {
      private DxfEntity dxfEntity_0;
      private DrawContext.Wireframe wireframe_0;
      private DrawContext.Wireframe wireframe_1;
      private DrawContext.Wireframe wireframe_2;
      private IWireframeGraphicsFactory2 iwireframeGraphicsFactory2_0;

      public Class1020(
        DxfEntity insert,
        DrawContext.Wireframe drawContext,
        IWireframeGraphicsFactory2 graphicsFactory)
      {
        this.dxfEntity_0 = insert;
        this.wireframe_0 = drawContext;
        this.iwireframeGraphicsFactory2_0 = graphicsFactory;
      }

      public DrawContext InsertCellDrawContext
      {
        get
        {
          return (DrawContext) this.wireframe_1;
        }
      }

      public void imethod_0(int row, int column, Matrix4D instanceTransform)
      {
        this.wireframe_1 = this.wireframe_0.CreateChildContext(this.dxfEntity_0, instanceTransform);
      }

      public void Draw(DxfBlock block, bool applyBlockBaseTransformation)
      {
        block.DrawInternal((DxfInsert.Interface46) this, applyBlockBaseTransformation);
      }

      public void Draw(WW.Math.Geometry.Polyline3D polygon)
      {
        IList<Polyline4D> polyline4DList = this.wireframe_0.GetTransformer().Transform(polygon, false);
        this.iwireframeGraphicsFactory2_0.BeginGeometry(this.dxfEntity_0, this.wireframe_0, this.wireframe_0.GetPlotColor(this.dxfEntity_0), false, false, false, true);
        foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) polyline4DList)
          this.iwireframeGraphicsFactory2_0.CreatePolyline(this.dxfEntity_0, polyline);
        this.iwireframeGraphicsFactory2_0.EndGeometry();
      }

      public void imethod_1(int row, int column, Matrix4D instanceTransform)
      {
        this.wireframe_1 = this.wireframe_0.CreateChildContext(this.dxfEntity_0, instanceTransform);
        this.wireframe_1.Row = row;
        this.wireframe_1.Column = column;
      }

      public void Draw(DxfAttribute attribute)
      {
        attribute.Draw(this.wireframe_1, this.iwireframeGraphicsFactory2_0);
      }

      public void imethod_2(Matrix4D blockTransform)
      {
        this.wireframe_2 = this.wireframe_1.CreateChildContext(this.wireframe_1.BlockContext, blockTransform);
      }

      public void Draw(DxfBlock block, DxfModel model)
      {
        DrawContext.Wireframe childContext = this.wireframe_1.CreateChildContext(this.wireframe_1.BlockContext, block.BaseTransformation, block, model);
        model.Draw(childContext, this.iwireframeGraphicsFactory2_0);
      }

      public void imethod_3(DxfEntity entity)
      {
        entity.Draw(this.wireframe_2, this.iwireframeGraphicsFactory2_0);
      }
    }

    internal class Class1021 : DxfInsert.Interface46
    {
      private DrawContext.Surface surface_0;
      private DrawContext.Surface surface_1;
      private DrawContext.Surface surface_2;
      private DxfEntity dxfEntity_0;
      private ISurfaceGraphicsFactory isurfaceGraphicsFactory_0;

      public Class1021(
        DxfEntity insert,
        DrawContext.Surface drawContext,
        ISurfaceGraphicsFactory graphicsFactory)
      {
        this.dxfEntity_0 = insert;
        this.surface_0 = drawContext;
        this.isurfaceGraphicsFactory_0 = graphicsFactory;
      }

      public DrawContext InsertCellDrawContext
      {
        get
        {
          return (DrawContext) this.surface_1;
        }
      }

      public void imethod_0(int row, int column, Matrix4D instanceTransform)
      {
        this.surface_1 = this.surface_0.CreateChildContext(this.dxfEntity_0, instanceTransform);
      }

      public void Draw(DxfBlock block, bool applyBlockBaseTransformation)
      {
        block.DrawInternal((DxfInsert.Interface46) this, applyBlockBaseTransformation);
      }

      public void Draw(WW.Math.Geometry.Polyline3D polygon)
      {
        this.isurfaceGraphicsFactory_0.SetColor(this.surface_0.GetPlotColor(this.dxfEntity_0));
        IList<WW.Math.Geometry.Polyline3D> polylines = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>(1);
        polylines.Add(polygon);
        Class940.smethod_16(this.dxfEntity_0, this.surface_0, this.isurfaceGraphicsFactory_0, polylines, false);
      }

      public void imethod_1(int row, int column, Matrix4D instanceTransform)
      {
        this.surface_1 = this.surface_0.CreateChildContext(this.dxfEntity_0, instanceTransform);
        this.surface_1.Row = row;
        this.surface_1.Column = column;
      }

      public void Draw(DxfAttribute attribute)
      {
        attribute.Draw(this.surface_1, this.isurfaceGraphicsFactory_0);
      }

      public void imethod_2(Matrix4D blockTransform)
      {
        this.surface_2 = this.surface_1.CreateChildContext(this.surface_1.BlockContext, blockTransform);
      }

      public void Draw(DxfBlock block, DxfModel model)
      {
        DrawContext.Surface childContext = this.surface_1.CreateChildContext(this.surface_1.BlockContext, block.BaseTransformation, block, model);
        model.Draw(childContext, this.isurfaceGraphicsFactory_0);
      }

      public void imethod_3(DxfEntity entity)
      {
        entity.Draw(this.surface_2, this.isurfaceGraphicsFactory_0);
      }
    }

    internal class Class1022 : DxfInsert.Interface46
    {
      private DxfEntity dxfEntity_0;
      private DrawContext.Surface surface_0;
      private DrawContext.Surface surface_1;
      private DrawContext.Surface surface_2;
      private Graphics graphics_0;
      private IGraphicElementBlock igraphicElementBlock_0;
      private GraphicElementInsert graphicElementInsert_0;
      private GraphicElementInsert.InsertCell insertCell_0;
      private bool bool_0;
      private bool bool_1;

      public Class1022(
        DxfEntity insert,
        DrawContext.Surface drawContext,
        Graphics graphics,
        IGraphicElementBlock parentGraphicElementBlock,
        GraphicElementInsert graphicElementInsert)
      {
        this.method_0(insert, drawContext, graphics, parentGraphicElementBlock, graphicElementInsert);
        graphicElementInsert.InsertCells = new GraphicElementInsert.InsertCell[1, 1];
      }

      public Class1022(
        DxfInsert insert,
        DrawContext.Surface drawContext,
        Graphics graphics,
        IGraphicElementBlock parentGraphicElementBlock,
        GraphicElementInsert graphicElementInsert)
      {
        this.method_0((DxfEntity) insert, drawContext, graphics, parentGraphicElementBlock, graphicElementInsert);
        graphicElementInsert.InsertCells = new GraphicElementInsert.InsertCell[(int) insert.RowCount, (int) insert.ColumnCount];
        graphicElementInsert.AttributeBlockCells = new Matrix4D[(int) insert.RowCount, (int) insert.ColumnCount];
      }

      private void method_0(
        DxfEntity insert,
        DrawContext.Surface drawContext,
        Graphics graphics,
        IGraphicElementBlock parentGraphicElementBlock,
        GraphicElementInsert graphicElementInsert)
      {
        this.dxfEntity_0 = insert;
        this.surface_0 = drawContext;
        this.graphics_0 = graphics;
        this.igraphicElementBlock_0 = parentGraphicElementBlock;
        this.graphicElementInsert_0 = graphicElementInsert;
      }

      public DrawContext InsertDrawContext
      {
        get
        {
          return (DrawContext) this.surface_0;
        }
      }

      public DrawContext InsertCellDrawContext
      {
        get
        {
          return (DrawContext) this.surface_1;
        }
      }

      public void imethod_0(int row, int column, Matrix4D instanceTransform)
      {
        this.surface_1 = this.surface_0.CreateChildContext(this.dxfEntity_0, Matrix4D.Identity);
        this.insertCell_0 = new GraphicElementInsert.InsertCell(instanceTransform);
        this.graphicElementInsert_0.InsertCells[row, column] = this.insertCell_0;
        this.bool_0 = row == 0 && column == 0;
        this.bool_1 = false;
      }

      public void Draw(DxfBlock block, bool applyBlockBaseTransformation)
      {
        if (this.bool_0)
        {
          GraphicElementBlock2 graphicElementBlock;
          if (this.graphics_0.GetGraphicElementBlock2(block, this.surface_1.Layer, this.surface_1.ByBlockColor, this.surface_1.ByBlockLineType, out graphicElementBlock))
          {
            this.graphicElementInsert_0.UnclippedBlock = graphicElementBlock;
            block.DrawInternal((DxfInsert.Interface46) this, applyBlockBaseTransformation);
          }
          else
            this.graphicElementInsert_0.UnclippedBlock = graphicElementBlock;
          graphicElementBlock.Transform = block.BaseTransformation;
        }
        this.insertCell_0.ClippedBlock = this.graphicElementInsert_0.UnclippedBlock;
      }

      public void Draw(WW.Math.Geometry.Polyline3D polygon)
      {
        this.igraphicElementBlock_0.Add((IGraphicElement) new GraphicElement1(new WW.Cad.Drawing.Surface.Geometry(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive(polygon)), this.surface_1.GetPlotColor(this.dxfEntity_0)));
      }

      public void imethod_1(int row, int column, Matrix4D instanceTransform)
      {
        this.surface_1 = this.surface_0.CreateChildContext(this.dxfEntity_0, Matrix4D.Identity);
        this.surface_1.Row = row;
        this.surface_1.Column = column;
        this.graphicElementInsert_0.AttributeBlockCells[row, column] = instanceTransform;
        this.bool_1 = row == 0 && column == 0;
        this.bool_0 = false;
      }

      public void Draw(DxfAttribute attribute)
      {
        if (!this.bool_1)
          return;
        if (this.graphicElementInsert_0.AttributeBlock == null)
          this.graphicElementInsert_0.AttributeBlock = new GraphicElementBlock1(this.surface_1.Layer.Color, this.surface_1.ByBlockColor)
          {
            Transform = Matrix4D.Identity
          };
        attribute.Draw(this.surface_1, this.graphics_0, (IGraphicElementBlock) this.graphicElementInsert_0.AttributeBlock);
      }

      public void imethod_2(Matrix4D blockTransform)
      {
        this.surface_2 = this.surface_1.CreateChildContext(this.surface_1.BlockContext, blockTransform);
      }

      public void Draw(DxfBlock block, DxfModel model)
      {
        DrawContext.Surface childContext = this.surface_1.CreateChildContext(this.surface_1.BlockContext, block.BaseTransformation, block, model);
        model.Draw(childContext, this.graphics_0, (IGraphicElementBlock) this.graphicElementInsert_0.UnclippedBlock);
      }

      public void imethod_3(DxfEntity entity)
      {
        entity.Draw(this.surface_2, this.graphics_0, (IGraphicElementBlock) this.graphicElementInsert_0.UnclippedBlock);
      }
    }
  }
}
