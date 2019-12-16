// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.IObjectVisitor
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Objects.DynamicBlock;

namespace WW.Cad.Model.Objects
{
  public interface IObjectVisitor
  {
    void Visit(DxfDataTable dataTable);

    void Visit(DxfDictionary dictionary);

    void Visit(DxfBlockPolarParameter blockPolarParameter);

    void Visit(DxfBlockLookupAction blockLookupAction);

    void Visit(DxfBlockMoveAction blockMoveAction);

    void Visit(DxfBlockStretchAction blockStretchAction);

    void Visit(DxfBlockPolarStretchAction blockPolarStretchAction);

    void Visit(DxfBlockArrayAction blockArrayAction);

    void Visit(DxfBlockFlipAction blockFlipAction);

    void Visit(DxfBlockScaleAction blockScaleAction);

    void Visit(DxfBlockRotateAction blockRotateAction);

    void Visit(DxfBlockRotationParameter blockRotationParameter);

    void Visit(DxfBlockXYParameter blockXYParameter);

    void Visit(DxfBlockLinearParameter blockLinearParameter);

    void Visit(DxfBlockAlignmentGrip blockAlignmentGrip);

    void Visit(DxfBlockRotationGrip blockRotationGrip);

    void Visit(DxfBlockFlipGrip blockFlipGrip);

    void Visit(DxfBlockPurgePreventer blockPurgePreventer);

    void Visit(DxfBlockRepresentationData blockRepresentationData);

    void Visit(DxfBlockLinearGrip blockLinearGrip);

    void Visit(DxfBlockLookupGrip blockLookupGrip);

    void Visit(DxfBlockPolarGrip blockPolarGrip);

    void Visit(
      DxfBlockPropertiesTableGrip blockPropertiesTableGrip);

    void Visit(DxfBlockGripExpression blockGripExpression);

    void Visit(DxfDynamicBlockProxyNode dynamicBlockProxyNode);

    void Visit(DxfBlockVisibilityGrip blockVisibilityGrip);

    void Visit(DxfBlockXYGrip blockXYGrip);

    void Visit(DxfBlockFlipParameter blockFlipParameter);

    void Visit(DxfBlockAlignmentParameter blockAlignmentParameter);

    void Visit(DxfBlockBasePointParameter blockBasePointParameter);

    void Visit(DxfBlockLookUpParameter blockLookUpParameter);

    void Visit(
      DxfBlockVisibilityParameter blockVisibilityParameter);

    void Visit(DxfBlockPropertiesTable blockPropertiesTable);

    void Visit(DxfDictionaryWithDefault dictionaryWithDefault);

    void Visit(DxfField field);

    void Visit(DxfFieldList fieldListList);

    void Visit(DxfGeoData geoData);

    void Visit(DxfXRecord xrecord);

    void Visit(DxfDictionaryVariable dictionaryVariable);

    void Visit(DxfIdBuffer idBuffer);

    void Visit(DxfPlaceHolder placeHolder);

    void Visit(DxfCellStyleMap cellStyleMap);

    void Visit(DxfTableStyle tableStyle);

    void Visit(DxfMLeaderStyle mleaderStyle);

    void Visit(DxfMLineStyle mlineStyle);

    void Visit(DxfColor color);

    void Visit(DxfImageDef imageDefinition);

    void Visit(DxfPlotSettings plotSettings);

    void Visit(DxfLayout layout);

    void Visit(DxfGroup group);

    void Visit(DxfEvalGraph evalGraph);

    void Visit(DxfBlockPointParameter blockPointParameter);

    void Visit(DxfBlockUserParameter blockUserParameter);

    void Visit(DxfFormattedTableData formattedTableData);

    void Visit(DxfLinkedData linkedData);

    void Visit(DxfLinkedTableData linkedTableData);

    void Visit(DxfRasterVariables o);

    void Visit(DxfTableContent tableContent);

    void Visit(DxfTableGeometry tableGeometry);

    void Visit(DxfScale scale);

    void Visit(DxfSortEntsTable sortEntsTable);

    void Visit(DxfSpatialFilter spatialFilter);

    void Visit(DxfMTextObjectContextData contextData);

    void Visit(DxfBlockReferenceObjectContextData contextData);

    void Visit(DxfToleranceObjectContextData contextData);

    void Visit(DxfHatchScaleContextData contextData);

    void Visit(DxfHatchViewContextData contextData);

    void Visit(DxfTextObjectContextData contextData);

    void Visit(DxfDimensionObjectContextData.Aligned contextData);

    void Visit(DxfDimensionObjectContextData.Angular contextData);

    void Visit(
      DxfDimensionObjectContextData.Diametric contextData);

    void Visit(DxfDimensionObjectContextData.Ordinate contextData);

    void Visit(DxfDimensionObjectContextData.Radial contextData);

    void Visit(DxfAttributeObjectContextData contextData);

    void Visit(DxfLeaderObjectContextData contextData);

    void Visit(DxfMLeaderAnnotationContext o);

    void Visit(DxfMLeaderObjectContextData o);

    void Visit(DxfVisualStyle visualStyle);

    void Visit(DxfWipeoutVariables wipeoutVariables);

    void Visit(DxfBlockLinearConstraintParameter param);

    void Visit(DxfBlockHorizontalConstraintParameter param);

    void Visit(DxfBlockVerticalConstraintParameter param);

    void Visit(DxfBlockAlignedConstraintParameter param);

    void Visit(DxfBlockAngularConstraintParameter param);

    void Visit(DxfBlockDiametricConstraintParameter param);

    void Visit(DxfBlockRadialConstraintParameter param);
  }
}
