// Decompiled with JetBrains decompiler
// Type: ns2.Class918
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.InventorDrawing;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Objects.DynamicBlock;

namespace ns2
{
  internal class Class918 : IEntityVisitor, IObjectVisitor
  {
    protected DxfVersion dxfVersion_0;
    protected bool bool_0;

    protected Class918()
    {
    }

    public Class918(DxfVersion outputVersion)
    {
      this.dxfVersion_0 = outputVersion;
    }

    public bool Supported
    {
      get
      {
        return this.bool_0;
      }
    }

    public void Visit(Dxf3DFace face)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfArc arc)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfAttribute attribute)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockPolarParameter blockPolarParameter)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockFlipAction blockFlipAction)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockLookupAction blockLookupAction)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockMoveAction blockMoveAction)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockStretchAction blockStretchAction)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockPolarStretchAction blockPolarStretchAction)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockArrayAction blockArrayAction)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockScaleAction blockScaleAction)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockRotateAction blockRotateAction)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockRotationParameter blockRotationParameter)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockXYParameter blockXYParameter)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockLinearParameter blockLinearParameter)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockAlignmentGrip blockAlignmentGrip)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockFlipGrip blockFlipGrip)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockRepresentationData blockRepresentationData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockPurgePreventer blockPurgePreventer)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockLinearGrip blockLinearGrip)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockLookupGrip blockLookupGrip)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockPolarGrip blockPolarGrip)
    {
      this.bool_0 = true;
    }

    public void Visit(
      DxfBlockPropertiesTableGrip blockPropertiesTableGrip)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockRotationGrip blockRotationGrip)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockVisibilityGrip blockVisibilityGrip)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockXYGrip blockXYGrip)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockGripExpression blockGripExpression)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfDynamicBlockProxyNode DynamicBlockProxyNode)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockFlipParameter blockFlipParameter)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockAlignmentParameter blockAlignmentParameter)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockBasePointParameter blockBasePointParameter)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockLookUpParameter blockLookUpParameter)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockPropertiesTable blockPropertiesTable)
    {
      this.bool_0 = true;
    }

    public void Visit(
      DxfBlockVisibilityParameter blockVisibilityParameter)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfAttributeDefinition attributeDefinition)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfCircle circle)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfDimension.Aligned dimension)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfDimension.Angular3Point dimension)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfDimension.Angular4Point dimension)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfDimension.Diametric dimension)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfDimension.Linear dimension)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfDimension.Ordinate dimension)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfDimension.Radial dimension)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfEllipse ellipse)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfHatch hatch)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfImage image)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfWipeout image)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfInsert insert)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfIDBlockReference insert)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfLeader leader)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfLine line)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfLwPolyline polyline)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfMeshFace meshFace)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfMLeader mleader)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfMLine mline)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfMText mtext)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfPoint point)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfPolyfaceMesh mesh)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfPolygonMesh mesh)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfPolygonSplineMesh mesh)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfPolyline2D polyline)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfPolyline2DSpline polyline)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfPolyline3D polyline)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfPolyline3DSpline polyline)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfProxyEntity proxyEntity)
    {
      this.bool_0 = this.dxfVersion_0 > DxfVersion.Dxf14;
    }

    public void Visit(DxfRasterVariables o)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfRay ray)
    {
      this.bool_0 = true;
    }

    private void method_0(int version, DxfVersion outVersion)
    {
      switch (outVersion)
      {
        case DxfVersion.Dxf10:
        case DxfVersion.Dxf10PlusUnofficial:
        case DxfVersion.Dxf12:
        case DxfVersion.Dxf13:
        case DxfVersion.Dxf14:
          this.bool_0 = version <= 106;
          break;
        case DxfVersion.Dxf15:
          this.bool_0 = version <= 400;
          break;
        case DxfVersion.Dxf18:
          this.bool_0 = version <= 20800;
          break;
        case DxfVersion.Dxf21:
          this.bool_0 = version <= 21200;
          break;
        case DxfVersion.Dxf24:
          this.bool_0 = version <= 21500;
          break;
        case DxfVersion.Dxf27:
          this.bool_0 = version <= 21800;
          break;
        default:
          this.bool_0 = false;
          break;
      }
    }

    public void Visit(Dxf3DSolid solid)
    {
      if (solid.IsEmpty)
        this.bool_0 = false;
      else
        this.method_0(solid.SATVersion, this.dxfVersion_0);
    }

    public void Visit(DxfRegion region)
    {
      if (region.IsEmpty)
        this.bool_0 = false;
      else
        this.method_0(region.SATVersion, this.dxfVersion_0);
    }

    public void Visit(DxfBody body)
    {
      if (body.IsEmpty)
        this.bool_0 = false;
      else
        this.method_0(body.SATVersion, this.dxfVersion_0);
    }

    public void Visit(DxfSequenceEnd sequenceEnd)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfShape shape)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfSolid solid)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfSpline spline)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfTable table)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfText text)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfTolerance tolerance)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfVertex2D vertex)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfVertex3D vertex)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfViewport viewport)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfXLine xline)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfOle ole)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfDataTable dataTable)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfDictionary dictionary)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfDictionaryWithDefault dictionaryWithDefault)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfXRecord xrecord)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfDictionaryVariable dictionaryVariable)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfIdBuffer idBuffer)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfPlaceHolder placeHolder)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfCellStyleMap cellStyleMap)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfTableStyle tableStyle)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfMLeaderStyle mleaderStyle)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfMLineStyle mlineStyle)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfColor color)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfImageDef imageDefinition)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfPlotSettings plotSettings)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfLayout layout)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfField field)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfFieldList fieldList)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfGeoData geoData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfGroup group)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfEvalGraph evalGraph)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockPointParameter blockPointParameter)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockUserParameter blockUserParameter)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfScale scale)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfSortEntsTable sortEntsTable)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfSpatialFilter spatialFilter)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfFormattedTableData formattedTableData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfLinkedData linkedData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfLinkedTableData linkedTableData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfTableContent tableContent)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfTableGeometry tableGeometry)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfMTextObjectContextData contextData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockReferenceObjectContextData contextData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfMLeaderAnnotationContext o)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfMLeaderObjectContextData o)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfToleranceObjectContextData contextData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfHatchScaleContextData contextData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfHatchViewContextData contextData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfTextObjectContextData contextData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfDimensionObjectContextData.Aligned contextData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfDimensionObjectContextData.Angular contextData)
    {
      this.bool_0 = true;
    }

    public void Visit(
      DxfDimensionObjectContextData.Diametric contextData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfDimensionObjectContextData.Ordinate contextData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfDimensionObjectContextData.Radial contextData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfAttributeObjectContextData contextData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfLeaderObjectContextData contextData)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfVisualStyle visualStyle)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfWipeoutVariables wipeoutVariables)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockLinearConstraintParameter param)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockHorizontalConstraintParameter param)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockVerticalConstraintParameter param)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockAlignedConstraintParameter param)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockAngularConstraintParameter param)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockDiametricConstraintParameter param)
    {
      this.bool_0 = true;
    }

    public void Visit(DxfBlockRadialConstraintParameter param)
    {
      this.bool_0 = true;
    }
  }
}
