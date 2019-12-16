// Decompiled with JetBrains decompiler
// Type: ns2.Class739
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Objects.DynamicBlock;

namespace ns2
{
  internal class Class739 : IObjectVisitor
  {
    private readonly DxfModel dxfModel_0;

    public Class739(DxfModel model)
    {
      this.dxfModel_0 = model;
    }

    public void Visit(DxfBlockPolarParameter blockPolarParameter)
    {
    }

    public void Visit(DxfBlockFlipAction blockFlipAction)
    {
    }

    public void Visit(DxfBlockLookupAction blockLookupAction)
    {
    }

    public void Visit(DxfBlockMoveAction blockMoveAction)
    {
    }

    public void Visit(DxfBlockStretchAction blockStretchAction)
    {
    }

    public void Visit(DxfBlockPolarStretchAction blockPolarStretchAction)
    {
    }

    public void Visit(DxfBlockArrayAction blockArrayAction)
    {
    }

    public void Visit(DxfBlockScaleAction blockScaleAction)
    {
    }

    public void Visit(DxfBlockRotateAction blockRotateAction)
    {
    }

    public void Visit(DxfBlockRotationParameter blockRotationParameter)
    {
    }

    public void Visit(DxfBlockXYParameter blockXYParameter)
    {
    }

    public void Visit(DxfBlockLinearParameter blockLinearParameter)
    {
    }

    public void Visit(DxfBlockFlipParameter blockFlipParameter)
    {
    }

    public void Visit(DxfBlockAlignmentGrip blockAlignmentGrip)
    {
    }

    public void Visit(DxfBlockFlipGrip blockFlipGrip)
    {
    }

    public void Visit(DxfBlockRepresentationData blockRepresentationData)
    {
    }

    public void Visit(DxfBlockPurgePreventer blockPurgePreventer)
    {
    }

    public void Visit(DxfBlockLinearGrip blockLinearGrip)
    {
    }

    public void Visit(DxfBlockLookupGrip blockLookupGrip)
    {
    }

    public void Visit(DxfBlockPolarGrip blockPolarGrip)
    {
    }

    public void Visit(
      DxfBlockPropertiesTableGrip blockPropertiesTableGrip)
    {
    }

    public void Visit(DxfBlockRotationGrip blockRotationGrip)
    {
    }

    public void Visit(DxfBlockVisibilityGrip blockVisibilityGrip)
    {
    }

    public void Visit(DxfBlockXYGrip blockXYGrip)
    {
    }

    public void Visit(DxfBlockGripExpression blockGripExpression)
    {
    }

    public void Visit(DxfDynamicBlockProxyNode DynamicBlockProxyNode)
    {
    }

    public void Visit(DxfBlockAlignmentParameter blockAlignmentParameter)
    {
    }

    public void Visit(DxfBlockBasePointParameter blockBasePointParameter)
    {
    }

    public void Visit(DxfBlockLookUpParameter blockLookUpParameter)
    {
    }

    public void Visit(
      DxfBlockVisibilityParameter blockVisibilityParameter)
    {
    }

    public void Visit(DxfBlockPropertiesTable blockPropertiesTable)
    {
    }

    public void Visit(DxfEvalGraph evalGraph)
    {
    }

    public void Visit(DxfBlockPointParameter blockPointParameter)
    {
    }

    public void Visit(DxfBlockUserParameter blockUserParameter)
    {
    }

    public void Visit(DxfDataTable dataTable)
    {
    }

    public void Visit(DxfDictionary dictionary)
    {
    }

    public void Visit(DxfDictionaryWithDefault dictionaryWithDefault)
    {
    }

    public void Visit(DxfXRecord xrecord)
    {
    }

    public void Visit(DxfDictionaryVariable dictionaryVariable)
    {
    }

    public void Visit(DxfIdBuffer idBuffer)
    {
    }

    public void Visit(DxfPlaceHolder placeHolder)
    {
    }

    public void Visit(DxfCellStyleMap cellStyleMap)
    {
    }

    public void Visit(DxfTableGeometry tableGeometry)
    {
    }

    public void Visit(DxfTableStyle tableStyle)
    {
      this.dxfModel_0.TableStyles.Add(tableStyle);
    }

    public void Visit(DxfMLeaderStyle mleaderStyle)
    {
    }

    public void Visit(DxfMLineStyle mlineStyle)
    {
    }

    public void Visit(DxfColor color)
    {
    }

    public void Visit(DxfImageDef imageDefinition)
    {
    }

    public void Visit(DxfPlotSettings plotSettings)
    {
    }

    public void Visit(DxfLayout layout)
    {
    }

    public void Visit(DxfField field)
    {
    }

    public void Visit(DxfFieldList fieldList)
    {
    }

    public void Visit(DxfGeoData geoData)
    {
    }

    public void Visit(DxfGroup group)
    {
    }

    public void Visit(DxfFormattedTableData formattedTableData)
    {
    }

    public void Visit(DxfLinkedData linkedData)
    {
    }

    public void Visit(DxfLinkedTableData linkedTableData)
    {
    }

    public void Visit(DxfRasterVariables o)
    {
    }

    public void Visit(DxfTableContent tableContent)
    {
    }

    public void Visit(DxfScale scale)
    {
    }

    public void Visit(DxfSortEntsTable sortEntsTable)
    {
    }

    public void Visit(DxfSpatialFilter spatialFilter)
    {
    }

    public void Visit(DxfMTextObjectContextData contextData)
    {
    }

    public void Visit(DxfBlockReferenceObjectContextData contextData)
    {
    }

    public void Visit(DxfToleranceObjectContextData contextData)
    {
    }

    public void Visit(DxfHatchScaleContextData contextData)
    {
    }

    public void Visit(DxfHatchViewContextData contextData)
    {
    }

    public void Visit(DxfTextObjectContextData contextData)
    {
    }

    public void Visit(DxfDimensionObjectContextData.Aligned contextData)
    {
    }

    public void Visit(DxfDimensionObjectContextData.Angular contextData)
    {
    }

    public void Visit(
      DxfDimensionObjectContextData.Diametric contextData)
    {
    }

    public void Visit(DxfDimensionObjectContextData.Ordinate contextData)
    {
    }

    public void Visit(DxfDimensionObjectContextData.Radial contextData)
    {
    }

    public void Visit(DxfAttributeObjectContextData contextData)
    {
    }

    public void Visit(DxfLeaderObjectContextData contextData)
    {
    }

    public void Visit(DxfMLeaderAnnotationContext o)
    {
    }

    public void Visit(DxfMLeaderObjectContextData o)
    {
    }

    public void Visit(DxfVisualStyle visualStyle)
    {
    }

    public void Visit(DxfWipeoutVariables wipeoutVariables)
    {
    }

    public void Visit(DxfBlockLinearConstraintParameter param)
    {
    }

    public void Visit(DxfBlockHorizontalConstraintParameter param)
    {
    }

    public void Visit(DxfBlockVerticalConstraintParameter param)
    {
    }

    public void Visit(DxfBlockAlignedConstraintParameter param)
    {
    }

    public void Visit(DxfBlockAngularConstraintParameter param)
    {
    }

    public void Visit(DxfBlockDiametricConstraintParameter param)
    {
    }

    public void Visit(DxfBlockRadialConstraintParameter param)
    {
    }
  }
}
