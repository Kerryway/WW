// Decompiled with JetBrains decompiler
// Type: ns28.Class432
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using ns2;
using ns37;
using ns46;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text;
using WW;
using WW.Cad.IO;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.InventorDrawing;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Objects.DynamicBlock;
using WW.Cad.Model.Tables;
using WW.Collections.Generic;
using WW.Math;
using WW.Text;

namespace ns28
{
  internal class Class432 : IEntityVisitor, DxfHatch.BoundaryPath.IEdgeVisitor, IObjectVisitor
  {
    private Queue<DxfObject> queue_0 = new Queue<DxfObject>();
    private List<Class991> list_0 = new List<Class991>();
    private Dictionary<DxfBlock, List<DxfEntity>> dictionary_0 = new Dictionary<DxfBlock, List<DxfEntity>>();
    private Stream stream_0;
    private Encoding encoding_0;
    private DxfModel dxfModel_0;
    private DxfHeader dxfHeader_0;
    private MemoryStream memoryStream_0;
    private Interface29 interface29_0;
    private MemoryStream memoryStream_1;
    private Class432.Class433 class433_0;
    private DxfVersion dxfVersion_0;
    private int int_0;
    private bool bool_0;
    private ulong ulong_0;
    private DxfBlock dxfBlock_0;
    private IDxfHandledObject idxfHandledObject_0;
    private DxfEntity dxfEntity_0;
    private DxfEntity dxfEntity_1;
    private Class920 class920_0;
    private Class1030 class1030_0;

    private void method_0(
      DxfBlockSinglePointParameter blockSinglePointParameter)
    {
      this.method_5((DxfBlockParameter) blockSinglePointParameter);
      this.interface29_0.imethod_24(blockSinglePointParameter.BasePoint);
      this.method_2(blockSinglePointParameter.FirstProperty);
      this.method_2(blockSinglePointParameter.SecondProperty);
      this.interface29_0.imethod_33(blockSinglePointParameter.GripId.Id);
    }

    internal void method_1(DxfBlockTwoPointsParameter blockTwoPointsParameter)
    {
      this.method_5((DxfBlockParameter) blockTwoPointsParameter);
      DxfBlockTwoPointsParameter twoPointsParameter = blockTwoPointsParameter;
      this.interface29_0.imethod_24(twoPointsParameter.FirstPoint);
      this.interface29_0.imethod_24(twoPointsParameter.SecondPoint);
      for (int index = 0; index < 4; ++index)
        this.method_2(twoPointsParameter.Properties[index]);
      for (int index = 0; index < 4; ++index)
        this.interface29_0.imethod_33(twoPointsParameter.GripIds[index].Id);
      this.interface29_0.imethod_32((short) twoPointsParameter.BasePoint);
    }

    private void method_2(
      DxfBlockParameterPropertyInfo blockParameterPropertyInfo)
    {
      int num = Class740.smethod_0(blockParameterPropertyInfo.ConnectionPoints);
      this.interface29_0.imethod_32((short) num);
      for (int index = 0; index < num; ++index)
        this.method_3(blockParameterPropertyInfo.ConnectionPoints[index]);
    }

    private void method_3(DxfConnectionPoint connectionPoint)
    {
      this.interface29_0.imethod_33(connectionPoint.ConnectionPointId.Id);
      this.interface29_0.imethod_4(connectionPoint.ConnectionString);
    }

    private void method_4(DxfBlockElement blockElement)
    {
      this.method_8((DxfEvalGraphExpression) blockElement);
      this.interface29_0.imethod_4(blockElement.Name);
      this.interface29_0.imethod_33(blockElement.VersionMajor);
      this.interface29_0.imethod_33(blockElement.VersionMinor);
      this.interface29_0.imethod_33(blockElement.UnknownField);
    }

    private void method_5(DxfBlockParameter blockParameter)
    {
      this.method_4((DxfBlockElement) blockParameter);
      this.interface29_0.imethod_14(blockParameter.ShowProperties);
      this.interface29_0.imethod_14(blockParameter.ChainActions);
    }

    private void method_6(DxfBlockAction blockAction)
    {
      this.method_4((DxfBlockElement) blockAction);
      this.interface29_0.imethod_24(blockAction.Position);
      int num1 = Class740.smethod_3((IList<DxfHandledObject>) blockAction.AttachedEntities);
      this.interface29_0.imethod_33(num1);
      for (int index = 0; index < num1; ++index)
        this.interface29_0.imethod_42(ReferenceType.SoftPointerReference, blockAction.AttachedEntities[index]);
      int num2 = Class740.smethod_4(blockAction.AttachedElements);
      this.interface29_0.imethod_33(num2);
      for (int index = 0; index < num2; ++index)
        this.interface29_0.imethod_33(blockAction.AttachedElements[index].Id);
    }

    private void method_7(DxfBlockBasePointAction blockBasePointAction)
    {
      this.method_6((DxfBlockAction) blockBasePointAction);
      this.interface29_0.imethod_24(blockBasePointAction.BasePoint);
      this.method_3(blockBasePointAction.Connections[0]);
      this.method_3(blockBasePointAction.Connections[1]);
      this.interface29_0.imethod_14(!blockBasePointAction.IndependentFlag);
      this.interface29_0.imethod_24(blockBasePointAction.Offset);
    }

    private void method_8(DxfEvalGraphExpression evalGraphExpression)
    {
      this.interface29_0.imethod_33(evalGraphExpression.UnknownField);
      this.interface29_0.imethod_33(evalGraphExpression.VersionMajor);
      this.interface29_0.imethod_33(evalGraphExpression.VersionMinor);
      this.method_37(evalGraphExpression.DataValue, true);
      this.interface29_0.imethod_33(evalGraphExpression.NodeId.Id);
    }

    private void method_9(DxfBlockBasePointParameter blockBasePointParameter)
    {
      this.method_0((DxfBlockSinglePointParameter) blockBasePointParameter);
      this.interface29_0.imethod_24(blockBasePointParameter.BasePoint1);
      this.interface29_0.imethod_24(blockBasePointParameter.BasePoint2);
    }

    private void method_10(DxfBlockPolarParameter blockPolarParameter)
    {
      this.method_1((DxfBlockTwoPointsParameter) blockPolarParameter);
      this.interface29_0.imethod_4(blockPolarParameter.LabelText);
      this.interface29_0.imethod_4(blockPolarParameter.Description);
      this.interface29_0.imethod_4(blockPolarParameter.AngleLabelText);
      this.interface29_0.imethod_4(blockPolarParameter.AngleDescription);
      this.interface29_0.imethod_16(blockPolarParameter.LabelOffset);
      blockPolarParameter.Distance.Write(this.interface29_0);
      blockPolarParameter.Angle.Write(this.interface29_0);
    }

    private void method_11(DxfBlockScaleAction blockScaleAction)
    {
      this.method_7((DxfBlockBasePointAction) blockScaleAction);
      this.method_3(blockScaleAction.ActionConnections[0]);
      this.method_3(blockScaleAction.ActionConnections[1]);
      this.method_3(blockScaleAction.ActionConnections[2]);
      this.interface29_0.imethod_11((byte) blockScaleAction.ScaleType);
    }

    private void method_12(DxfBlockFlipAction blockFlipAction)
    {
      this.method_6((DxfBlockAction) blockFlipAction);
      this.method_3(blockFlipAction.ActionConnections[0]);
      this.method_3(blockFlipAction.ActionConnections[1]);
      this.method_3(blockFlipAction.ActionConnections[2]);
      this.method_3(blockFlipAction.ActionConnections[3]);
    }

    private void method_13(DxfBlockLookupAction blockLookupAction)
    {
      this.method_6((DxfBlockAction) blockLookupAction);
      this.interface29_0.imethod_33(blockLookupAction.NumberOfRows);
      this.interface29_0.imethod_33(blockLookupAction.NumberOfColumns);
      int num1 = Class740.smethod_5(blockLookupAction.Text);
      for (int index = 0; index < num1; ++index)
        this.interface29_0.imethod_4(blockLookupAction.Text[index]);
      int num2 = Class740.smethod_9(blockLookupAction.Information);
      for (int index = 0; index < num2; ++index)
        this.method_14(blockLookupAction.Information[index]);
      this.interface29_0.imethod_14(blockLookupAction.UnknownFlag);
    }

    private void method_14(DxfLookupActionInformation information)
    {
      this.interface29_0.imethod_33(information.Id.Id);
      this.interface29_0.imethod_33(information.ResourceType);
      this.interface29_0.imethod_33(information.Type);
      this.interface29_0.imethod_14(information.PropertyType);
      this.interface29_0.imethod_4(information.Unmatched);
      this.interface29_0.imethod_14(information.AllowEditing);
      this.interface29_0.imethod_4(information.ConnectionText);
    }

    private void method_15(DxfBlockMoveAction blockMoveAction)
    {
      this.method_6((DxfBlockAction) blockMoveAction);
      this.method_3(blockMoveAction.ActionConnections[0]);
      this.method_3(blockMoveAction.ActionConnections[1]);
      this.method_16((DxfBlockAngleOffsetAction) blockMoveAction, false);
    }

    private void method_16(DxfBlockAngleOffsetAction dxfObject, bool extendedVariant)
    {
      this.interface29_0.imethod_16(dxfObject.DistanceCoefficient);
      this.interface29_0.imethod_16(dxfObject.AngleOffset);
      if (extendedVariant)
      {
        this.interface29_0.imethod_33((int) dxfObject.ScaleType);
        if (dxfObject.ScaleType == DxfBlockAction.ScaleTypeXY.X)
        {
          this.interface29_0.imethod_33(dxfObject.Unknown1);
        }
        else
        {
          if (dxfObject.ScaleType != DxfBlockAction.ScaleTypeXY.Y)
            return;
          this.interface29_0.imethod_33(dxfObject.Unknown1);
          this.interface29_0.imethod_33(dxfObject.Unknown2);
        }
      }
      else
        this.interface29_0.imethod_11((byte) dxfObject.ScaleType);
    }

    private void method_17(DxfBlockPolarStretchAction blockPolarStretchAction)
    {
      this.method_6((DxfBlockAction) blockPolarStretchAction);
      this.method_3(blockPolarStretchAction.ActionConnections[0]);
      this.method_3(blockPolarStretchAction.ActionConnections[1]);
      this.method_3(blockPolarStretchAction.ActionConnections[2]);
      this.method_3(blockPolarStretchAction.ActionConnections[3]);
      this.method_3(blockPolarStretchAction.ActionConnections[4]);
      this.method_3(blockPolarStretchAction.ActionConnections[5]);
      int num1 = Class740.smethod_8(blockPolarStretchAction.Frame);
      this.interface29_0.imethod_33(num1);
      for (int index = 0; index < num1; ++index)
        this.interface29_0.imethod_25(blockPolarStretchAction.Frame[index]);
      int num2 = Class740.smethod_3((IList<DxfHandledObject>) blockPolarStretchAction.RotateSelection);
      this.interface29_0.imethod_33(num2);
      for (int index = 0; index < num2; ++index)
        this.interface29_0.imethod_42(ReferenceType.SoftPointerReference, blockPolarStretchAction.RotateSelection[index]);
      int num3 = Class740.smethod_7(blockPolarStretchAction.StretchEntities);
      this.interface29_0.imethod_33(num3);
      for (int index1 = 0; index1 < num3; ++index1)
      {
        this.interface29_0.imethod_42(ReferenceType.SoftPointerReference, blockPolarStretchAction.StretchEntities[index1].Entity);
        int num4 = Class740.smethod_6(blockPolarStretchAction.StretchEntities[index1].PointIndexes);
        this.interface29_0.imethod_33(num4);
        for (int index2 = 0; index2 < num4; ++index2)
          this.interface29_0.imethod_33(blockPolarStretchAction.StretchEntities[index1].PointIndexes[index2]);
      }
      int num5 = Class740.smethod_10(blockPolarStretchAction.StretchNodes);
      this.interface29_0.imethod_33(num5);
      for (int index1 = 0; index1 < num5; ++index1)
      {
        this.interface29_0.imethod_33(blockPolarStretchAction.StretchNodes[index1].Node.Id);
        int num4 = Class740.smethod_6(blockPolarStretchAction.StretchNodes[index1].PointIndexes);
        this.interface29_0.imethod_33(num4);
        for (int index2 = 0; index2 < num4; ++index2)
          this.interface29_0.imethod_33(blockPolarStretchAction.StretchNodes[index1].PointIndexes[index2]);
      }
      this.method_16((DxfBlockAngleOffsetAction) blockPolarStretchAction, true);
    }

    private void method_18(DxfBlockStretchAction blockStretchAction)
    {
      this.method_6((DxfBlockAction) blockStretchAction);
      this.method_3(blockStretchAction.ActionConnections[0]);
      this.method_3(blockStretchAction.ActionConnections[1]);
      int num1 = Class740.smethod_8(blockStretchAction.Frame);
      this.interface29_0.imethod_33(num1);
      for (int index = 0; index < num1; ++index)
        this.interface29_0.imethod_25(blockStretchAction.Frame[index]);
      int num2 = Class740.smethod_7(blockStretchAction.StretchEntities);
      this.interface29_0.imethod_33(num2);
      for (int index1 = 0; index1 < num2; ++index1)
      {
        this.interface29_0.imethod_42(ReferenceType.SoftPointerReference, blockStretchAction.StretchEntities[index1].Entity);
        int num3 = Class740.smethod_6(blockStretchAction.StretchEntities[index1].PointIndexes);
        this.interface29_0.imethod_33(num3);
        for (int index2 = 0; index2 < num3; ++index2)
          this.interface29_0.imethod_33(blockStretchAction.StretchEntities[index1].PointIndexes[index2]);
      }
      int num4 = Class740.smethod_10(blockStretchAction.StretchNodes);
      this.interface29_0.imethod_33(num4);
      for (int index1 = 0; index1 < num4; ++index1)
      {
        this.interface29_0.imethod_33(blockStretchAction.StretchNodes[index1].Node.Id);
        int num3 = Class740.smethod_6(blockStretchAction.StretchNodes[index1].PointIndexes);
        this.interface29_0.imethod_33(num3);
        for (int index2 = 0; index2 < num3; ++index2)
          this.interface29_0.imethod_33(blockStretchAction.StretchNodes[index1].PointIndexes[index2]);
      }
      this.method_16((DxfBlockAngleOffsetAction) blockStretchAction, false);
    }

    private void method_19(DxfBlockArrayAction blockArrayAction)
    {
      this.method_6((DxfBlockAction) blockArrayAction);
      this.method_3(blockArrayAction.ActionConnections[0]);
      this.method_3(blockArrayAction.ActionConnections[1]);
      this.method_3(blockArrayAction.ActionConnections[2]);
      this.method_3(blockArrayAction.ActionConnections[3]);
      this.interface29_0.imethod_16(blockArrayAction.RowOffset);
      this.interface29_0.imethod_16(blockArrayAction.ColumnOffset);
    }

    private void method_20(DxfBlockRotateAction blockRotateAction)
    {
      this.method_7((DxfBlockBasePointAction) blockRotateAction);
      this.method_3(blockRotateAction.ActionConnection);
    }

    private void method_21(DxfBlockRotationParameter blockRotationParameter)
    {
      this.method_1((DxfBlockTwoPointsParameter) blockRotationParameter);
      this.interface29_0.imethod_24(blockRotationParameter.StartPoint);
      this.interface29_0.imethod_4(blockRotationParameter.LabelText);
      this.interface29_0.imethod_4(blockRotationParameter.Description);
      this.interface29_0.imethod_16(blockRotationParameter.LabelOffset);
      blockRotationParameter.Angle.Write(this.interface29_0);
    }

    private void method_22(DxfBlockLinearParameter blockLinearParameter)
    {
      this.method_1((DxfBlockTwoPointsParameter) blockLinearParameter);
      this.interface29_0.imethod_4(blockLinearParameter.LabelText);
      this.interface29_0.imethod_4(blockLinearParameter.Description);
      this.interface29_0.imethod_16(blockLinearParameter.LabelOffset);
      blockLinearParameter.Distance.Write(this.interface29_0);
    }

    private void method_23(DxfBlockXYParameter blockLinearParameter)
    {
      this.method_1((DxfBlockTwoPointsParameter) blockLinearParameter);
      this.interface29_0.imethod_4(blockLinearParameter.LabelTextY);
      this.interface29_0.imethod_4(blockLinearParameter.LabelTextX);
      this.interface29_0.imethod_4(blockLinearParameter.DescriptionY);
      this.interface29_0.imethod_4(blockLinearParameter.DescriptionX);
      this.interface29_0.imethod_16(blockLinearParameter.LabelOffsetX);
      this.interface29_0.imethod_16(blockLinearParameter.LabelOffsetY);
      blockLinearParameter.ParameterValueSetX.Write(this.interface29_0);
      blockLinearParameter.ParameterValueSetY.Write(this.interface29_0);
    }

    private void method_24(DxfBlockFlipParameter blockFlipParameter)
    {
      this.method_1((DxfBlockTwoPointsParameter) blockFlipParameter);
      this.interface29_0.imethod_4(blockFlipParameter.LabelText);
      this.interface29_0.imethod_4(blockFlipParameter.Description);
      this.interface29_0.imethod_4(blockFlipParameter.NotFlippedState);
      this.interface29_0.imethod_4(blockFlipParameter.FlippedState);
      this.interface29_0.imethod_24(blockFlipParameter.LabelPosition);
      this.method_3(blockFlipParameter.Connection);
    }

    private void method_25(DxfBlockGrip blockGrip)
    {
      this.method_4((DxfBlockElement) blockGrip);
      this.interface29_0.imethod_33(blockGrip.GripExpression1.Id);
      this.interface29_0.imethod_33(blockGrip.GripExpression2.Id);
      this.interface29_0.imethod_24(blockGrip.Position);
      this.interface29_0.imethod_14(blockGrip.CyclingFlag);
      this.interface29_0.imethod_33(blockGrip.CyclingWeight);
    }

    private void method_26(DxfBlockAlignmentGrip blockAlignmentGrip)
    {
      this.method_25((DxfBlockGrip) blockAlignmentGrip);
      this.interface29_0.imethod_16(blockAlignmentGrip.Alignment.X);
      this.interface29_0.imethod_16(blockAlignmentGrip.Alignment.Y);
      this.interface29_0.imethod_16(blockAlignmentGrip.Alignment.Z);
    }

    private void method_27(DxfBlockGripExpression blockGripExpression)
    {
      this.method_8((DxfEvalGraphExpression) blockGripExpression);
      this.method_3(blockGripExpression.ActionConnection);
    }

    private void method_28(DxfDynamicBlockProxyNode dynamicBlockProxyNode)
    {
      this.method_8((DxfEvalGraphExpression) dynamicBlockProxyNode);
    }

    private void method_29(DxfBlockLinearGrip blockLinearGrip)
    {
      this.method_25((DxfBlockGrip) blockLinearGrip);
      this.interface29_0.imethod_16(blockLinearGrip.Distance.X);
      this.interface29_0.imethod_16(blockLinearGrip.Distance.Y);
      this.interface29_0.imethod_16(blockLinearGrip.Distance.Z);
    }

    private void method_30(DxfBlockFlipGrip blockFlipGrip)
    {
      this.method_25((DxfBlockGrip) blockFlipGrip);
      this.interface29_0.imethod_33(blockFlipGrip.FlipExpression.Id);
      this.interface29_0.imethod_16(blockFlipGrip.Orientation.X);
      this.interface29_0.imethod_16(blockFlipGrip.Orientation.Y);
      this.interface29_0.imethod_16(blockFlipGrip.Orientation.Z);
    }

    private void method_31(DxfBlockRepresentationData blockRepresentationData)
    {
      this.interface29_0.imethod_32(blockRepresentationData.Version);
      this.interface29_0.imethod_42(ReferenceType.HardPointerReference, (DxfHandledObject) blockRepresentationData.DynamicBlock);
    }

    private void method_32(DxfBlockPurgePreventer blockPurgePreventer)
    {
      this.method_31((DxfBlockRepresentationData) blockPurgePreventer);
    }

    private void method_33(DxfBlockAlignmentParameter blockAlignmentParameter)
    {
      this.method_1((DxfBlockTwoPointsParameter) blockAlignmentParameter);
      this.interface29_0.imethod_14(blockAlignmentParameter.IsPerpendicular);
    }

    private void method_34(DxfBlockLookUpParameter blockLookUpParameter)
    {
      this.method_0((DxfBlockSinglePointParameter) blockLookUpParameter);
      this.interface29_0.imethod_33(blockLookUpParameter.ActionId.Id);
      this.interface29_0.imethod_4(blockLookUpParameter.LabelText);
      this.interface29_0.imethod_4(blockLookUpParameter.Description);
    }

    private void method_35(
      DxfBlockVisibilityParameter blockVisibilityParameter)
    {
      this.method_0((DxfBlockSinglePointParameter) blockVisibilityParameter);
      this.interface29_0.imethod_14(blockVisibilityParameter.UnknownFlag);
      this.interface29_0.imethod_4(blockVisibilityParameter.LabelText);
      this.interface29_0.imethod_4(blockVisibilityParameter.Description);
      this.interface29_0.imethod_14(blockVisibilityParameter.UnknownFlag2);
      int num1 = Class740.smethod_3((IList<DxfHandledObject>) blockVisibilityParameter.HandleSet);
      this.interface29_0.imethod_33(num1);
      for (int index = 0; index < num1; ++index)
        this.interface29_0.imethod_42(ReferenceType.SoftPointerReference, blockVisibilityParameter.HandleSet[index]);
      int num2 = Class740.smethod_11(blockVisibilityParameter.VisibilityStates);
      this.interface29_0.imethod_33(num2);
      for (int index = 0; index < num2; ++index)
        this.method_39(blockVisibilityParameter.VisibilityStates[index]);
    }

    private void method_36(DxfBlockPropertiesTableColumnDefinition columnInfo)
    {
      this.interface29_0.imethod_42(ReferenceType.HardPointerReference, (DxfHandledObject) columnInfo.Parameter);
      this.interface29_0.imethod_32(columnInfo.UnknownInt1);
      this.interface29_0.imethod_32(columnInfo.UnknownInt2);
      this.interface29_0.imethod_4(columnInfo.UnknownString1);
      this.interface29_0.imethod_4(columnInfo.ConnectionPoint.ConnectionString);
      this.interface29_0.imethod_33(columnInfo.ConnectionPoint.ConnectionPointId.Id);
      this.method_37(columnInfo.UnknownValue1, true);
      this.method_37(columnInfo.DefaultDoNotMatchValue, true);
      this.interface29_0.imethod_14(columnInfo.UnknownFlag1);
      this.interface29_0.imethod_14(columnInfo.UnknownFlag2);
      this.interface29_0.imethod_14(columnInfo.UnknownFlag3);
      this.interface29_0.imethod_14(columnInfo.UnknownFlag4);
      this.interface29_0.imethod_14(columnInfo.UnknownFlag5);
      this.interface29_0.imethod_4(columnInfo.UnknownString2);
      this.interface29_0.imethod_42(ReferenceType.HardOwnershipReference, (DxfHandledObject) columnInfo.UnknownObject1);
    }

    private void method_37(DxfXRecordValue value, bool write9999)
    {
      if (value == null)
      {
        if (!write9999)
          throw new InternalException("Illegal XRecord, no value.");
        this.interface29_0.imethod_32((short) -9999);
      }
      else
      {
        short num = DxfWriter.ConvertResourceTypeForEvalGraphExpression(value.Code);
        this.interface29_0.imethod_32(num);
        Enum5 enum5 = Class820.smethod_2((int) num);
        switch (enum5)
        {
          case Enum5.const_1:
            this.method_135(value);
            this.interface29_0.imethod_11(Convert.ToBoolean(value.Value, (IFormatProvider) CultureInfo.InvariantCulture) ? (byte) 1 : (byte) 0);
            break;
          case Enum5.const_2:
            this.method_135(value);
            this.interface29_0.imethod_11(Convert.ToByte(value.Value, (IFormatProvider) CultureInfo.InvariantCulture));
            break;
          case Enum5.const_3:
            this.method_135(value);
            byte[] bytes = (byte[]) value.Value;
            if (bytes.Length > (int) byte.MaxValue)
              throw new Exception("XRECORD byte array data may not contain more than 255 bytes.");
            this.interface29_0.imethod_11((byte) bytes.Length);
            this.interface29_0.imethod_13(bytes, 0, bytes.Length);
            break;
          case Enum5.const_4:
            this.method_135(value);
            this.interface29_0.imethod_16(Convert.ToDouble(value.Value, (IFormatProvider) CultureInfo.InvariantCulture));
            break;
          case Enum5.const_5:
            DxfHandledObject dxfHandledObject = (DxfHandledObject) value.Value;
            this.interface29_0.imethod_5(dxfHandledObject == null ? string.Empty : dxfHandledObject.HandleString);
            break;
          case Enum5.const_6:
            this.method_135(value);
            this.interface29_0.imethod_5(Convert.ToString(value.Value, (IFormatProvider) CultureInfo.InvariantCulture));
            break;
          case Enum5.const_7:
          case Enum5.const_8:
          case Enum5.const_15:
            this.interface29_0.imethod_34(value.Value == null ? 0L : (long) ((DxfHandledObject) value.Value).Handle);
            break;
          case Enum5.const_9:
          case Enum5.const_14:
            this.interface29_0.imethod_34(value.Value == null ? 0L : (long) ((DxfHandledObject) value.Value).Handle);
            DxfObject dxfObject = value.Value as DxfObject;
            if (dxfObject == null)
              break;
            this.queue_0.Enqueue(dxfObject);
            break;
          case Enum5.const_10:
          case Enum5.const_17:
            this.method_135(value);
            this.interface29_0.imethod_32(Convert.ToInt16(value.Value, (IFormatProvider) CultureInfo.InvariantCulture));
            break;
          case Enum5.const_11:
            this.method_135(value);
            this.interface29_0.imethod_33(Convert.ToInt32(value.Value, (IFormatProvider) CultureInfo.InvariantCulture));
            break;
          case Enum5.const_12:
            this.method_135(value);
            this.interface29_0.imethod_34(Convert.ToInt64(value.Value, (IFormatProvider) CultureInfo.InvariantCulture));
            break;
          case Enum5.const_13:
            this.method_135(value);
            this.interface29_0.imethod_24((WW.Math.Point3D) value.Value);
            break;
          case Enum5.const_16:
            this.method_135(value);
            this.interface29_0.imethod_4((string) value.Value);
            break;
          default:
            throw new Exception("Unknown group value type " + (object) enum5 + " for group " + (object) num + ".");
        }
      }
    }

    private void method_38(DxfBlockPropertiesTable dxfObject)
    {
      this.method_0((DxfBlockSinglePointParameter) dxfObject);
      this.interface29_0.imethod_33(dxfObject.NodeId.Id);
      this.interface29_0.imethod_4(dxfObject.TableName);
      this.interface29_0.imethod_4(dxfObject.DescriptionString);
      int length = dxfObject.ColumnInformation.Length;
      this.interface29_0.imethod_33(length);
      for (int index = 0; index < length; ++index)
        this.method_36(dxfObject.ColumnInformation[index]);
      int num = dxfObject.DataNodeId == null ? 0 : dxfObject.DataNodeId.Length;
      this.interface29_0.imethod_33(num);
      for (int index1 = 0; index1 < num; ++index1)
      {
        this.interface29_0.imethod_33(dxfObject.DataNodeId[index1]);
        for (int index2 = 0; index2 < length; ++index2)
          this.method_37(dxfObject.Data[index2][index1], true);
      }
      this.interface29_0.imethod_33(dxfObject.Unknown1);
      this.interface29_0.imethod_14(dxfObject.PropertiesCanBeModifiedIndividually);
      this.interface29_0.imethod_14(dxfObject.UnknownFlag2);
      this.interface29_0.imethod_14(dxfObject.UnknownFlag3);
    }

    private void method_39(DxfVisibilityState visibilityState)
    {
      this.interface29_0.imethod_4(visibilityState.Name);
      int num1 = Class740.smethod_3((IList<DxfHandledObject>) visibilityState.SelectionSet1);
      this.interface29_0.imethod_33(num1);
      for (int index = 0; index < num1; ++index)
        this.interface29_0.imethod_42(ReferenceType.SoftPointerReference, visibilityState.SelectionSet1[index]);
      int num2 = Class740.smethod_3((IList<DxfHandledObject>) visibilityState.SelectionSet2);
      this.interface29_0.imethod_33(num2);
      for (int index = 0; index < num2; ++index)
        this.interface29_0.imethod_42(ReferenceType.SoftPointerReference, visibilityState.SelectionSet2[index]);
    }

    private void method_40(DxfBlockPointParameter blockPointParameter)
    {
      this.method_0((DxfBlockSinglePointParameter) blockPointParameter);
      this.interface29_0.imethod_4(blockPointParameter.LabelText);
      this.interface29_0.imethod_4(blockPointParameter.Description);
      this.interface29_0.imethod_24(blockPointParameter.LabelPosition);
    }

    private void method_41(DxfBlockUserParameter blockUserParameter)
    {
      this.method_0((DxfBlockSinglePointParameter) blockUserParameter);
    }

    public void Visit(DxfEvalGraph evalGraph)
    {
      evalGraph.vmethod_7(this);
      this.interface29_0.imethod_33(evalGraph.LastNodeId.Id);
      this.interface29_0.imethod_33(evalGraph.LastNodeId.Id);
      int num1 = Class740.smethod_12(evalGraph.Nodes);
      this.interface29_0.imethod_33(num1);
      for (int index = 0; index < num1; ++index)
      {
        this.interface29_0.imethod_33(index);
        this.interface29_0.imethod_33(32);
        this.interface29_0.imethod_33(evalGraph.Nodes[index].Id.Id);
        this.interface29_0.imethod_42(ReferenceType.HardOwnershipReference, (DxfHandledObject) evalGraph.Nodes[index].Expression);
        this.interface29_0.imethod_33(evalGraph.Nodes[index].FirstIncomingEdge);
        this.interface29_0.imethod_33(evalGraph.Nodes[index].LastIncomingEdge);
        this.interface29_0.imethod_33(evalGraph.Nodes[index].FirstOutgoingEdge);
        this.interface29_0.imethod_33(evalGraph.Nodes[index].LastOutgoingEdge);
      }
      int num2 = Class740.smethod_13(evalGraph.Edges);
      this.interface29_0.imethod_33(num2);
      for (int index = 0; index < num2; ++index)
      {
        this.interface29_0.imethod_33(index);
        this.interface29_0.imethod_33(evalGraph.Edges[index].Flags);
        this.interface29_0.imethod_33(evalGraph.Edges[index].ReferenceCount);
        this.interface29_0.imethod_33(evalGraph.Edges[index].StartNode);
        this.interface29_0.imethod_33(evalGraph.Edges[index].EndNode);
        this.interface29_0.imethod_33(evalGraph.Edges[index].PreviousIncoming);
        this.interface29_0.imethod_33(evalGraph.Edges[index].NextIncoming);
        this.interface29_0.imethod_33(evalGraph.Edges[index].PreviousOutgoing);
        this.interface29_0.imethod_33(evalGraph.Edges[index].NextOutgoing);
        this.interface29_0.imethod_33(evalGraph.Edges[index].ReverseEdgeIndex);
      }
      this.method_82((DxfHandledObject) evalGraph);
    }

    public void Visit(DxfBlockLookUpParameter blockLookUpParameter)
    {
      blockLookUpParameter.vmethod_7(this);
      this.method_34(blockLookUpParameter);
      this.method_82((DxfHandledObject) blockLookUpParameter);
    }

    public void Visit(
      DxfBlockVisibilityParameter blockVisibilityParameter)
    {
      blockVisibilityParameter.vmethod_7(this);
      this.method_35(blockVisibilityParameter);
      this.method_82((DxfHandledObject) blockVisibilityParameter);
    }

    public void Visit(DxfBlockPropertiesTable blockPropertiesTable)
    {
      blockPropertiesTable.vmethod_7(this);
      this.method_38(blockPropertiesTable);
      this.method_82((DxfHandledObject) blockPropertiesTable);
    }

    public void Visit(DxfBlockBasePointParameter blockBasePointParameter)
    {
      blockBasePointParameter.vmethod_7(this);
      this.method_9(blockBasePointParameter);
      this.method_82((DxfHandledObject) blockBasePointParameter);
    }

    public void Visit(DxfBlockPolarParameter blockPolarParameter)
    {
      blockPolarParameter.vmethod_7(this);
      this.method_10(blockPolarParameter);
      this.method_82((DxfHandledObject) blockPolarParameter);
    }

    public void Visit(DxfBlockFlipAction blockFlipAction)
    {
      blockFlipAction.vmethod_7(this);
      this.method_12(blockFlipAction);
      this.method_82((DxfHandledObject) blockFlipAction);
    }

    public void Visit(DxfBlockLookupAction blockLookupAction)
    {
      blockLookupAction.vmethod_7(this);
      this.method_13(blockLookupAction);
      this.method_82((DxfHandledObject) blockLookupAction);
    }

    public void Visit(DxfBlockMoveAction blockMoveAction)
    {
      blockMoveAction.vmethod_7(this);
      this.method_15(blockMoveAction);
      this.method_82((DxfHandledObject) blockMoveAction);
    }

    public void Visit(DxfBlockStretchAction blockStretchAction)
    {
      blockStretchAction.vmethod_7(this);
      this.method_18(blockStretchAction);
      this.method_82((DxfHandledObject) blockStretchAction);
    }

    public void Visit(DxfBlockPolarStretchAction blockPolarStretchAction)
    {
      blockPolarStretchAction.vmethod_7(this);
      this.method_17(blockPolarStretchAction);
      this.method_82((DxfHandledObject) blockPolarStretchAction);
    }

    public void Visit(DxfBlockArrayAction blockArrayAction)
    {
      blockArrayAction.vmethod_7(this);
      this.method_19(blockArrayAction);
      this.method_82((DxfHandledObject) blockArrayAction);
    }

    public void Visit(DxfBlockScaleAction blockScaleAction)
    {
      blockScaleAction.vmethod_7(this);
      this.method_11(blockScaleAction);
      this.method_82((DxfHandledObject) blockScaleAction);
    }

    public void Visit(DxfBlockRotateAction blockRotateAction)
    {
      blockRotateAction.vmethod_7(this);
      this.method_20(blockRotateAction);
      this.method_82((DxfHandledObject) blockRotateAction);
    }

    public void Visit(DxfBlockRotationParameter blockRotationParameter)
    {
      blockRotationParameter.vmethod_7(this);
      this.method_21(blockRotationParameter);
      this.method_82((DxfHandledObject) blockRotationParameter);
    }

    public void Visit(DxfBlockXYParameter blockXYParameter)
    {
      blockXYParameter.vmethod_7(this);
      this.method_23(blockXYParameter);
      this.method_82((DxfHandledObject) blockXYParameter);
    }

    public void Visit(DxfBlockLinearParameter blockLinearParameter)
    {
      blockLinearParameter.vmethod_7(this);
      this.method_22(blockLinearParameter);
      this.method_82((DxfHandledObject) blockLinearParameter);
    }

    public void Visit(DxfBlockFlipParameter blockFlipParameter)
    {
      blockFlipParameter.vmethod_7(this);
      this.method_24(blockFlipParameter);
      this.method_82((DxfHandledObject) blockFlipParameter);
    }

    public void Visit(DxfBlockAlignmentParameter blockAlignmentParameter)
    {
      blockAlignmentParameter.vmethod_7(this);
      this.method_33(blockAlignmentParameter);
      this.method_82((DxfHandledObject) blockAlignmentParameter);
    }

    public void Visit(DxfBlockPointParameter blockPointParameter)
    {
      blockPointParameter.vmethod_7(this);
      this.method_40(blockPointParameter);
      this.method_82((DxfHandledObject) blockPointParameter);
    }

    public void Visit(DxfBlockUserParameter blockUserParameter)
    {
      blockUserParameter.vmethod_7(this);
      this.method_41(blockUserParameter);
      this.method_82((DxfHandledObject) blockUserParameter);
    }

    public void Visit(DxfBlockAlignmentGrip blockAlignmentGrip)
    {
      blockAlignmentGrip.vmethod_7(this);
      this.method_26(blockAlignmentGrip);
      this.method_82((DxfHandledObject) blockAlignmentGrip);
    }

    public void Visit(DxfBlockFlipGrip blockFlipGrip)
    {
      blockFlipGrip.vmethod_7(this);
      this.method_30(blockFlipGrip);
      this.method_82((DxfHandledObject) blockFlipGrip);
    }

    public void Visit(DxfBlockRepresentationData blockRepresentationData)
    {
      blockRepresentationData.vmethod_7(this);
      this.method_31(blockRepresentationData);
      this.method_82((DxfHandledObject) blockRepresentationData);
    }

    public void Visit(DxfBlockPurgePreventer blockPurgePreventer)
    {
      blockPurgePreventer.vmethod_7(this);
      this.method_32(blockPurgePreventer);
      this.method_82((DxfHandledObject) blockPurgePreventer);
    }

    public void Visit(DxfBlockLinearGrip blockLinearGrip)
    {
      blockLinearGrip.vmethod_7(this);
      this.method_29(blockLinearGrip);
      this.method_82((DxfHandledObject) blockLinearGrip);
    }

    public void Visit(DxfBlockLookupGrip blockLookupGrip)
    {
      blockLookupGrip.vmethod_7(this);
      this.method_25((DxfBlockGrip) blockLookupGrip);
      this.method_82((DxfHandledObject) blockLookupGrip);
    }

    public void Visit(DxfBlockPolarGrip blockPolarGrip)
    {
      blockPolarGrip.vmethod_7(this);
      this.method_25((DxfBlockGrip) blockPolarGrip);
      this.method_82((DxfHandledObject) blockPolarGrip);
    }

    public void Visit(
      DxfBlockPropertiesTableGrip blockPropertiesTableGrip)
    {
      blockPropertiesTableGrip.vmethod_7(this);
      this.method_25((DxfBlockGrip) blockPropertiesTableGrip);
      this.method_82((DxfHandledObject) blockPropertiesTableGrip);
    }

    public void Visit(DxfBlockRotationGrip blockRotationGrip)
    {
      blockRotationGrip.vmethod_7(this);
      this.method_25((DxfBlockGrip) blockRotationGrip);
      this.method_82((DxfHandledObject) blockRotationGrip);
    }

    public void Visit(DxfBlockVisibilityGrip blockVisibilityGrip)
    {
      blockVisibilityGrip.vmethod_7(this);
      this.method_25((DxfBlockGrip) blockVisibilityGrip);
      this.method_82((DxfHandledObject) blockVisibilityGrip);
    }

    public void Visit(DxfBlockXYGrip blockXYGrip)
    {
      blockXYGrip.vmethod_7(this);
      this.method_25((DxfBlockGrip) blockXYGrip);
      this.method_82((DxfHandledObject) blockXYGrip);
    }

    public void Visit(DxfBlockGripExpression blockGripExpression)
    {
      blockGripExpression.vmethod_7(this);
      this.method_27(blockGripExpression);
      this.method_82((DxfHandledObject) blockGripExpression);
    }

    public void Visit(DxfDynamicBlockProxyNode dynamicBlockProxyNode)
    {
      dynamicBlockProxyNode.vmethod_7(this);
      this.method_28(dynamicBlockProxyNode);
      this.method_82((DxfHandledObject) dynamicBlockProxyNode);
    }

    public Class432(Stream stream, DxfModel model, Class1030 knownClasses)
    {
      this.stream_0 = stream;
      this.dxfModel_0 = model;
      this.class1030_0 = knownClasses;
      this.dxfVersion_0 = model.Header.AcadVersion;
      this.dxfHeader_0 = model.Header;
      this.memoryStream_0 = new MemoryStream(1000);
      this.encoding_0 = Encodings.GetEncoding((int) model.Header.DrawingCodePage);
      this.interface29_0 = Class724.smethod_1(this.dxfVersion_0, (Stream) this.memoryStream_0, this.encoding_0);
      this.memoryStream_1 = new MemoryStream(1000);
      this.class433_0 = new Class432.Class433(this.memoryStream_1, model.Header.AcadVersion, this.encoding_0, model.Header.DrawingCodePage);
      this.class920_0 = new Class920(model.Header.AcadVersion);
      this.int_0 = (int) Class952.smethod_1(model.Header.DrawingCodePage);
      DxfBlock dxfBlock;
      if (model.AnonymousBlocks.TryGetValue("*Model_Space", out dxfBlock))
        this.ulong_0 = dxfBlock.Handle;
      else
        this.ulong_0 = 31UL;
    }

    public DxfModel Model
    {
      get
      {
        return this.dxfModel_0;
      }
    }

    public DxfBlock BlockContext
    {
      get
      {
        return this.dxfBlock_0;
      }
    }

    public ulong ModelSpaceBlockHandle
    {
      get
      {
        return this.ulong_0;
      }
    }

    public List<Class991> HandleAndStreamPositionList
    {
      get
      {
        return this.list_0;
      }
    }

    public Interface29 ObjectWriter
    {
      get
      {
        return this.interface29_0;
      }
    }

    public Class1030 KnownClasses
    {
      get
      {
        return this.class1030_0;
      }
    }

    public DxfVersion Version
    {
      get
      {
        return this.dxfVersion_0;
      }
    }

    public void Write()
    {
      if (this.dxfVersion_0 > DxfVersion.Dxf15)
        Class889.Create(this.stream_0, this.dxfVersion_0, this.encoding_0).vmethod_9(3530);
      this.method_45();
      this.method_69();
      this.method_72();
    }

    internal void method_42(DxfObject o)
    {
      if (o == null)
        return;
      this.queue_0.Enqueue(o);
    }

    private void method_43(string satText)
    {
      int length1 = satText.Length;
      int startIndex = 0;
      do
      {
        int length2 = startIndex + 4096 >= length1 ? length1 - startIndex : 4096;
        byte[] bytes = Encodings.Ascii.GetBytes(satText.Substring(startIndex, length2));
        DxfModelerGeometry.smethod_3(bytes, 0, length2);
        this.interface29_0.imethod_33(length2);
        this.interface29_0.imethod_12(bytes);
        startIndex += 4096;
      }
      while (startIndex < length1);
      this.interface29_0.imethod_33(0);
    }

    private Enum27 method_44()
    {
      return this.idxfHandledObject_0 == null ? ((long) this.dxfBlock_0.Handle != (long) this.ulong_0 ? (this.dxfBlock_0 != this.dxfModel_0.PaperSpaceBlock ? Enum27.const_0 : Enum27.const_1) : Enum27.const_2) : Enum27.const_0;
    }

    private void method_45()
    {
      this.method_46();
      foreach (DxfBlock block in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfModel_0.Blocks)
        this.method_47(block);
      foreach (DxfBlock anonymousBlock in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfModel_0.AnonymousBlocks)
        this.method_47(anonymousBlock);
      this.method_48();
      foreach (DxfLayer layer in (KeyedDxfHandledObjectCollection<string, DxfLayer>) this.dxfModel_0.Layers)
        this.method_49(layer);
      this.method_50();
      foreach (DxfTextStyle textStyle in (DxfHandledObjectCollection<DxfTextStyle>) this.dxfModel_0.TextStyles)
        this.method_51(textStyle);
      this.method_52();
      foreach (DxfLineType lineType in (KeyedDxfHandledObjectCollection<string, DxfLineType>) this.dxfModel_0.LineTypes)
        this.method_53(lineType);
      this.method_54();
      foreach (DxfView view in (KeyedDxfHandledObjectCollection<string, DxfView>) this.dxfModel_0.Views)
        this.method_55(view);
      this.method_56();
      foreach (DxfUcs ucs in (KeyedDxfHandledObjectCollection<string, DxfUcs>) this.dxfModel_0.UcsCollection)
        this.method_57(ucs);
      this.method_59();
      foreach (DxfVPort vport in (DxfHandledObjectCollection<DxfVPort>) this.dxfModel_0.VPorts)
        this.method_60(vport);
      this.method_61();
      foreach (DxfAppId appId in (KeyedDxfHandledObjectCollection<string, DxfAppId>) this.dxfModel_0.AppIds)
        this.method_62(appId);
      this.method_63();
      foreach (DxfDimensionStyle dimensionStyle in (KeyedDxfHandledObjectCollection<string, DxfDimensionStyle>) this.dxfModel_0.DimensionStyles)
        this.method_64(dimensionStyle);
      if (this.dxfVersion_0 < DxfVersion.Dxf13 || this.dxfVersion_0 > DxfVersion.Dxf15)
        return;
      this.method_65();
      DxfViewportEntityHeader viewportHeader1 = (DxfViewportEntityHeader) null;
      DxfViewportEntityHeader viewportHeader2 = (DxfViewportEntityHeader) null;
      for (int index = 0; index < this.dxfModel_0.ViewportEntityHeaders.Count; ++index)
      {
        viewportHeader2 = this.dxfModel_0.ViewportEntityHeaders[index];
        if (viewportHeader1 != null)
          this.method_66(viewportHeader1, viewportHeader1.Viewport != null ? viewportHeader2 : (DxfViewportEntityHeader) null);
        viewportHeader1 = viewportHeader2;
      }
      if (viewportHeader2 == null)
        return;
      this.method_66(viewportHeader2, (DxfViewportEntityHeader) null);
    }

    private void method_46()
    {
      this.method_79((short) 48, this.dxfModel_0.BlockRecordTable);
      bool flag = this.dxfVersion_0 > DxfVersion.Dxf27;
      this.interface29_0.imethod_33(this.dxfModel_0.Blocks.Count + this.dxfModel_0.AnonymousBlocks.Count - (flag ? 1 : 2));
      this.interface29_0.imethod_40((DxfHandledObject) null);
      this.method_78(this.dxfModel_0.BlockRecordTable.ExtensionDictionary);
      foreach (DxfBlock block in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfModel_0.Blocks)
      {
        if (string.Compare(block.Name, "*Model_Space", StringComparison.InvariantCultureIgnoreCase) != 0 && string.Compare(block.Name, "*Paper_Space", StringComparison.InvariantCultureIgnoreCase) != 0)
          this.interface29_0.imethod_38((DxfHandledObject) block);
      }
      foreach (DxfBlock anonymousBlock in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfModel_0.AnonymousBlocks)
      {
        if (string.Compare(anonymousBlock.Name, "*Model_Space", StringComparison.InvariantCultureIgnoreCase) != 0 && string.Compare(anonymousBlock.Name, "*Paper_Space", StringComparison.InvariantCultureIgnoreCase) != 0)
          this.interface29_0.imethod_38((DxfHandledObject) anonymousBlock);
      }
      if (flag)
        this.interface29_0.imethod_38((DxfHandledObject) null);
      this.interface29_0.imethod_39((DxfHandledObject) this.dxfModel_0.AnonymousBlocks["*Model_Space"]);
      this.interface29_0.imethod_39((DxfHandledObject) this.dxfModel_0.AnonymousBlocks["*Paper_Space"]);
      this.method_82(this.dxfModel_0.BlockRecordTable);
    }

    private void method_47(DxfBlock block)
    {
      this.method_79((short) 49, (DxfHandledObject) block);
      string str;
      if (block.IsAnonymous)
        str = this.method_86(block.Name.Substring(0, 2));
      else if (block.Layout != null)
      {
        int length = block.Name.IndexOfAny(new char[10]{ '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
        str = length < 0 ? this.method_86(block.Name) : this.method_86(block.Name.Substring(0, length));
      }
      else
        str = this.method_86(block.Name);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(str);
      this.method_58((DxfTableRecord) block);
      this.interface29_0.imethod_14(block.IsAnonymous);
      this.interface29_0.imethod_14(block.method_12());
      this.interface29_0.imethod_14(block.IsExternalReference);
      this.interface29_0.imethod_14(block.IsXRefOverlay);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
        this.interface29_0.imethod_14(block.IsExternalReferenceUnloaded);
      List<DxfEntity> dxfEntityList = this.method_71(block);
      if (this.dxfVersion_0 >= DxfVersion.Dxf18 && !block.IsExternalReference && !block.IsXRefOverlay)
        this.interface29_0.imethod_33(dxfEntityList.Count);
      this.interface29_0.imethod_29(block.BasePoint);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(block.ExternalReference);
      List<DxfInsert> dxfInsertList = (List<DxfInsert>) null;
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        List<DxfBlock> dxfBlockList = new List<DxfBlock>();
        foreach (DxfBlock block1 in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfModel_0.Blocks)
          dxfBlockList.Add(block1);
        foreach (DxfBlock anonymousBlock in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfModel_0.AnonymousBlocks)
          dxfBlockList.Add(anonymousBlock);
        foreach (DxfBlock dxfBlock in dxfBlockList)
        {
          foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) dxfBlock.Entities)
          {
            DxfInsert dxfInsert = entity as DxfInsert;
            if (dxfInsert != null && dxfInsert.Block == block)
            {
              if (dxfInsertList == null)
                dxfInsertList = new List<DxfInsert>();
              if (!dxfInsertList.Contains(dxfInsert))
              {
                dxfInsertList.Add(dxfInsert);
                this.interface29_0.imethod_11((byte) 1);
              }
            }
          }
        }
        this.interface29_0.imethod_11((byte) 0);
        if (this.dxfVersion_0 < DxfVersion.Dxf21)
          this.interface29_0.imethod_4(block.Description);
        this.interface29_0.imethod_33(0);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_32((short) block.BlockUnits);
        this.interface29_0.imethod_14(block.Explodable);
        this.interface29_0.imethod_11(block.ScaleUniformly ? (byte) 1 : (byte) 0);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_4(str);
        this.interface29_0.imethod_4(block.ExternalReference);
        this.interface29_0.imethod_4(block.Description);
      }
      this.method_77((IDxfHandledObject) block, (IDxfHandledObject) this.dxfModel_0.BlockRecordTable);
      this.method_76((DxfHandledObject) block);
      this.method_78(block.ExtensionDictionary);
      this.interface29_0.imethod_41((DxfHandledObject) null);
      this.interface29_0.imethod_39((DxfHandledObject) block.BlockBegin);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf15 && (!block.IsExternalReference && !block.IsXRefOverlay))
      {
        if (dxfEntityList.Count > 0)
        {
          this.interface29_0.imethod_40((DxfHandledObject) dxfEntityList[0]);
          this.interface29_0.imethod_40((DxfHandledObject) dxfEntityList[dxfEntityList.Count - 1]);
        }
        else
        {
          this.interface29_0.imethod_40((DxfHandledObject) null);
          this.interface29_0.imethod_40((DxfHandledObject) null);
        }
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf18 && !block.IsExternalReference && !block.IsXRefOverlay)
      {
        foreach (DxfHandledObject handledObject in dxfEntityList)
          this.interface29_0.imethod_39(handledObject);
      }
      this.interface29_0.imethod_39((DxfHandledObject) block.BlockEnd);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        if (dxfInsertList != null)
        {
          foreach (DxfHandledObject handledObject in dxfInsertList)
            this.interface29_0.imethod_40(handledObject);
        }
        this.interface29_0.imethod_41((DxfHandledObject) block.Layout);
      }
      this.method_82((DxfHandledObject) block);
    }

    private void method_48()
    {
      this.method_79((short) 50, this.dxfModel_0.LayerTable);
      this.interface29_0.imethod_33(this.dxfModel_0.Layers.Count);
      this.interface29_0.imethod_40((DxfHandledObject) null);
      this.method_78(this.dxfModel_0.LayerTable.ExtensionDictionary);
      foreach (DxfHandledObject layer in (KeyedDxfHandledObjectCollection<string, DxfLayer>) this.dxfModel_0.Layers)
        this.interface29_0.imethod_42(ReferenceType.SoftOwnershipReference, layer);
      this.method_82(this.dxfModel_0.LayerTable);
    }

    private void method_49(DxfLayer layer)
    {
      this.method_79((short) 51, (DxfHandledObject) layer);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(this.method_86(layer.Name));
      this.method_58((DxfTableRecord) layer);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf14)
      {
        this.interface29_0.imethod_14(layer.Frozen);
        this.interface29_0.imethod_14(!layer.Enabled);
        this.interface29_0.imethod_14(layer.FrozenInNewViewport);
        this.interface29_0.imethod_14(layer.Locked);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        short num = (short) ((int) Class885.smethod_5(layer.LineWeight) << 5);
        if (layer.Frozen)
          num |= (short) 1;
        if (!layer.Enabled)
          num |= (short) 2;
        if (layer.FrozenInNewViewport)
          num |= (short) 4;
        if (layer.Locked)
          num |= (short) 8;
        if (layer.PlotEnabled)
          num |= (short) 16;
        this.interface29_0.imethod_32(num);
      }
      this.interface29_0.imethod_6(layer.Color);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_4(layer.Name);
      this.interface29_0.imethod_40(this.dxfModel_0.LayerTable);
      this.method_76((DxfHandledObject) layer);
      this.method_78(layer.ExtensionDictionary);
      this.interface29_0.imethod_41((DxfHandledObject) null);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.PlotStyle);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_41((DxfHandledObject) null);
      this.interface29_0.imethod_41((DxfHandledObject) layer.LineType);
      if (this.dxfVersion_0 > DxfVersion.Dxf24)
        this.interface29_0.imethod_41((DxfHandledObject) null);
      this.method_82((DxfHandledObject) layer);
    }

    private void method_50()
    {
      this.method_79((short) 52, this.dxfModel_0.TextStyleTable);
      this.interface29_0.imethod_33(this.dxfModel_0.TextStyles.Count);
      this.interface29_0.imethod_40((DxfHandledObject) null);
      this.method_78(this.dxfModel_0.TextStyleTable.ExtensionDictionary);
      foreach (DxfHandledObject textStyle in (DxfHandledObjectCollection<DxfTextStyle>) this.dxfModel_0.TextStyles)
        this.interface29_0.imethod_42(ReferenceType.SoftOwnershipReference, textStyle);
      this.method_82(this.dxfModel_0.TextStyleTable);
    }

    private void method_51(DxfTextStyle textStyle)
    {
      this.method_79((short) 53, (DxfHandledObject) textStyle);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(this.method_86(textStyle.Name));
      this.method_58((DxfTableRecord) textStyle);
      this.interface29_0.imethod_14(textStyle.IsShape);
      this.interface29_0.imethod_14(textStyle.IsVertical);
      this.interface29_0.imethod_16(textStyle.FixedHeight);
      this.interface29_0.imethod_16(textStyle.WidthFactor);
      this.interface29_0.imethod_16(textStyle.ObliqueAngle);
      this.interface29_0.imethod_11((byte) textStyle.TextGenerationFlags);
      this.interface29_0.imethod_16(textStyle.LastHeightUsed);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_4(textStyle.Name);
      this.interface29_0.imethod_4(textStyle.FontFilename);
      this.interface29_0.imethod_4(textStyle.BigFontFilename);
      this.interface29_0.imethod_40(this.dxfModel_0.TextStyleTable);
      this.method_76((DxfHandledObject) textStyle);
      this.method_78(textStyle.ExtensionDictionary);
      this.interface29_0.imethod_41((DxfHandledObject) null);
      this.method_82((DxfHandledObject) textStyle);
    }

    private void method_52()
    {
      this.method_79((short) 56, this.dxfModel_0.LineTypeTable);
      this.interface29_0.imethod_33(this.dxfModel_0.LineTypes.Count - 2);
      this.interface29_0.imethod_40((DxfHandledObject) null);
      this.method_78(this.dxfModel_0.LineTypeTable.ExtensionDictionary);
      foreach (DxfLineType lineType in (KeyedDxfHandledObjectCollection<string, DxfLineType>) this.dxfModel_0.LineTypes)
      {
        if (lineType != this.dxfModel_0.ByBlockLineType && lineType != this.dxfModel_0.ByLayerLineType)
          this.interface29_0.imethod_42(ReferenceType.SoftOwnershipReference, (DxfHandledObject) lineType);
      }
      this.interface29_0.imethod_39((DxfHandledObject) this.dxfModel_0.ByBlockLineType);
      this.interface29_0.imethod_39((DxfHandledObject) this.dxfModel_0.ByLayerLineType);
      this.method_82(this.dxfModel_0.LineTypeTable);
    }

    private void method_53(DxfLineType lineType)
    {
      this.method_79((short) 57, (DxfHandledObject) lineType);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(this.method_86(lineType.Name));
      this.method_58((DxfTableRecord) lineType);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(lineType.Description);
      this.interface29_0.imethod_16(lineType.TotalLength);
      this.interface29_0.imethod_11((byte) 65);
      int count = lineType.Elements.Count;
      this.interface29_0.imethod_11((byte) count);
      bool flag = false;
      short num1 = 0;
      if (this.dxfVersion_0 == DxfVersion.Dxf13)
        num1 = (short) 1;
      for (int index = 0; index < count; ++index)
      {
        DxfLineType.Element element = lineType.Elements[index];
        this.interface29_0.imethod_16(element.Length);
        if (element.IsText)
        {
          flag = true;
          this.interface29_0.imethod_32(num1);
          num1 = (short) ((int) (short) ((int) num1 + (int) (short) this.interface29_0.EffectiveEncoding.GetBytes(element.Text).Length) + (int) (short) this.interface29_0.EffectiveEncoding.GetBytes("\0").Length);
        }
        else if (element.IsShape)
          this.interface29_0.imethod_32(element.ShapeNumber);
        else
          this.interface29_0.imethod_32((short) 0);
        this.interface29_0.imethod_20(element.Offset.X);
        this.interface29_0.imethod_20(element.Offset.Y);
        this.interface29_0.imethod_16(element.Scale);
        this.interface29_0.imethod_16(element.Rotation);
        this.interface29_0.imethod_32((short) element.ElementType);
      }
      if (this.dxfVersion_0 <= DxfVersion.Dxf18)
      {
        int num2 = 0;
        if (this.dxfVersion_0 == DxfVersion.Dxf13)
        {
          this.interface29_0.imethod_11((byte) 0);
          ++num2;
        }
        foreach (DxfLineType.Element element in (List<DxfLineType.Element>) lineType.Elements)
        {
          if (element.IsText && !string.IsNullOrEmpty(element.Text))
          {
            byte[] bytes1 = this.interface29_0.EffectiveEncoding.GetBytes(element.Text);
            this.interface29_0.imethod_12(bytes1);
            byte[] bytes2 = this.interface29_0.EffectiveEncoding.GetBytes("\0");
            this.interface29_0.imethod_12(bytes2);
            num2 += bytes1.Length + bytes2.Length;
          }
        }
        for (; num2 < 256; ++num2)
          this.interface29_0.imethod_11((byte) 0);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21 && flag)
      {
        int num2 = 0;
        foreach (DxfLineType.Element element in (List<DxfLineType.Element>) lineType.Elements)
        {
          if (element.IsText && !string.IsNullOrEmpty(element.Text))
          {
            byte[] bytes1 = this.interface29_0.EffectiveEncoding.GetBytes(element.Text);
            this.interface29_0.imethod_12(bytes1);
            byte[] bytes2 = this.interface29_0.EffectiveEncoding.GetBytes("\0");
            this.interface29_0.imethod_12(bytes2);
            num2 += bytes1.Length + bytes2.Length;
          }
        }
        for (; num2 < 512; ++num2)
          this.interface29_0.imethod_11((byte) 0);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_4(lineType.Name);
        this.interface29_0.imethod_4(lineType.Description);
      }
      this.interface29_0.imethod_40(this.dxfModel_0.LineTypeTable);
      this.method_76((DxfHandledObject) lineType);
      this.method_78(lineType.ExtensionDictionary);
      this.interface29_0.imethod_41((DxfHandledObject) null);
      for (int index = 0; index < count; ++index)
        this.interface29_0.imethod_41((DxfHandledObject) lineType.Elements[index].TextStyle);
      this.method_82((DxfHandledObject) lineType);
    }

    private void method_54()
    {
      this.method_79((short) 60, this.dxfModel_0.ViewTable);
      this.interface29_0.imethod_33(this.dxfModel_0.Views.Count);
      this.interface29_0.imethod_40((DxfHandledObject) null);
      this.method_78(this.dxfModel_0.ViewTable.ExtensionDictionary);
      foreach (DxfHandledObject view in (KeyedDxfHandledObjectCollection<string, DxfView>) this.dxfModel_0.Views)
        this.interface29_0.imethod_42(ReferenceType.SoftOwnershipReference, view);
      this.method_82(this.dxfModel_0.ViewTable);
    }

    private void method_55(DxfView view)
    {
      this.method_79((short) 61, (DxfHandledObject) view);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(this.method_86(view.Name));
      this.method_58((DxfTableRecord) view);
      this.interface29_0.imethod_40(this.dxfModel_0.ViewTable);
      this.method_76((DxfHandledObject) view);
      this.method_78(view.ExtensionDictionary);
      this.interface29_0.imethod_41((DxfHandledObject) null);
      this.interface29_0.imethod_16(view.Size.Y);
      this.interface29_0.imethod_16(view.Size.X);
      this.interface29_0.imethod_25(view.Center);
      this.interface29_0.imethod_24(view.Target);
      this.interface29_0.imethod_29(view.Direction);
      this.interface29_0.imethod_16(view.TwistAngle);
      this.interface29_0.imethod_16(view.LensLength);
      this.interface29_0.imethod_16(view.FrontClippingPlane);
      this.interface29_0.imethod_16(view.BackClippingPlane);
      this.interface29_0.imethod_14(view.PerspectiveMode);
      this.interface29_0.imethod_14(view.FrontClippingActive);
      this.interface29_0.imethod_14(view.BackClippingActive);
      this.interface29_0.imethod_14(view.ClipFrontNotAtEye);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
        this.interface29_0.imethod_11((byte) view.RenderMode);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_40((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_14(true);
        this.interface29_0.imethod_11((byte) 1);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_6(Color.CreateFromColorIndex((short) 250));
        this.interface29_0.imethod_39((DxfHandledObject) null);
      }
      this.interface29_0.imethod_14(view.Paperspace);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_14(view.Ucs != null);
        if (view.Ucs != null)
        {
          this.interface29_0.imethod_24(view.Ucs.Origin);
          this.interface29_0.imethod_29(view.Ucs.XAxis);
          this.interface29_0.imethod_29(view.Ucs.YAxis);
          this.interface29_0.imethod_16(view.Ucs.Elevation);
          this.interface29_0.imethod_32((short) view.UcsOrthographicType);
        }
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_14(false);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_4(view.Name);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15 && view.Ucs != null)
      {
        if (view.UcsOrthographicType == OrthographicType.None)
        {
          this.interface29_0.imethod_41((DxfHandledObject) null);
          this.interface29_0.imethod_41((DxfHandledObject) view.Ucs);
        }
        else
        {
          this.interface29_0.imethod_41((DxfHandledObject) view.Ucs);
          this.interface29_0.imethod_41((DxfHandledObject) null);
        }
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_40((DxfHandledObject) null);
      this.method_82((DxfHandledObject) view);
    }

    private void method_56()
    {
      this.method_79((short) 62, this.dxfModel_0.UcsTable);
      this.interface29_0.imethod_33(this.dxfModel_0.UcsCollection.Count);
      this.interface29_0.imethod_40((DxfHandledObject) null);
      this.method_78(this.dxfModel_0.UcsTable.ExtensionDictionary);
      foreach (DxfHandledObject ucs in (KeyedDxfHandledObjectCollection<string, DxfUcs>) this.dxfModel_0.UcsCollection)
        this.interface29_0.imethod_42(ReferenceType.SoftOwnershipReference, ucs);
      this.method_82(this.dxfModel_0.UcsTable);
    }

    private void method_57(DxfUcs ucs)
    {
      this.method_79((short) 63, (DxfHandledObject) ucs);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(this.method_86(ucs.Name));
      this.method_58((DxfTableRecord) ucs);
      this.interface29_0.imethod_24(ucs.Origin);
      this.interface29_0.imethod_29(ucs.XAxis);
      this.interface29_0.imethod_29(ucs.YAxis);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_16(ucs.Elevation);
        this.interface29_0.imethod_32((short) 0);
        this.interface29_0.imethod_32((short) 0);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_4(ucs.Name);
      this.interface29_0.imethod_40(this.dxfModel_0.UcsTable);
      this.method_76((DxfHandledObject) ucs);
      this.method_78(ucs.ExtensionDictionary);
      this.interface29_0.imethod_41((DxfHandledObject) null);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) null);
      }
      this.method_82((DxfHandledObject) ucs);
    }

    private void method_58(DxfTableRecord tableRecord)
    {
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_14(tableRecord.IsReferenced);
        this.method_85();
        this.interface29_0.imethod_14(tableRecord.IsExternallyDependent);
      }
      else
        this.interface29_0.imethod_32(tableRecord.IsExternallyDependent ? (short) 256 : (short) 0);
    }

    private void method_59()
    {
      this.method_79((short) 64, this.dxfModel_0.VPortTable);
      this.interface29_0.imethod_33(this.dxfModel_0.VPorts.Count);
      this.interface29_0.imethod_40((DxfHandledObject) null);
      this.method_78(this.dxfModel_0.VPortTable.ExtensionDictionary);
      foreach (DxfHandledObject vport in (DxfHandledObjectCollection<DxfVPort>) this.dxfModel_0.VPorts)
        this.interface29_0.imethod_42(ReferenceType.SoftOwnershipReference, vport);
      this.method_82(this.dxfModel_0.VPortTable);
    }

    private void method_60(DxfVPort vport)
    {
      this.method_79((short) 65, (DxfHandledObject) vport);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(this.method_86(vport.Name));
      this.method_58((DxfTableRecord) vport);
      this.interface29_0.imethod_16(vport.Height);
      this.interface29_0.imethod_16(vport.AspectRatio * vport.Height);
      this.interface29_0.imethod_25(vport.Center);
      this.interface29_0.imethod_24(vport.Target);
      this.interface29_0.imethod_29(vport.Direction);
      this.interface29_0.imethod_16(vport.TwistAngle);
      this.interface29_0.imethod_16(vport.LensLength);
      this.interface29_0.imethod_16(vport.FrontClippingPlane);
      this.interface29_0.imethod_16(vport.BackClippingPlane);
      this.interface29_0.imethod_14(vport.PerspectiveMode);
      this.interface29_0.imethod_14(vport.FrontClippingActive);
      this.interface29_0.imethod_14(vport.BackClippingActive);
      this.interface29_0.imethod_14(!vport.ClipFrontNotAtEye);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
        this.interface29_0.imethod_11((byte) vport.RenderMode);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_14(vport.UseDefaultLighting);
        this.interface29_0.imethod_11((byte) vport.DefaultLightingType);
        this.interface29_0.imethod_16(vport.Brightness);
        this.interface29_0.imethod_16(vport.Contrast);
        this.interface29_0.imethod_6(vport.AmbientColor);
      }
      this.interface29_0.imethod_25(vport.BottomLeft);
      this.interface29_0.imethod_25(vport.TopRight);
      this.interface29_0.imethod_14(vport.FollowUCS);
      this.interface29_0.imethod_32(vport.CircleZoomPercent);
      this.interface29_0.imethod_14(true);
      this.interface29_0.imethod_14(vport.DisplayUcs);
      this.interface29_0.imethod_14(true);
      this.interface29_0.imethod_14(vport.ShowGrid);
      this.interface29_0.imethod_28(vport.GridSpacing);
      this.interface29_0.imethod_14(vport.Snap);
      this.interface29_0.imethod_14(vport.SnapStyle == SnapStyle.Isometric);
      this.interface29_0.imethod_32(vport.SnapIsoPair);
      this.interface29_0.imethod_16(vport.SnapRotationAngle);
      this.interface29_0.imethod_25(vport.SnapBasePoint);
      this.interface29_0.imethod_28(vport.SnapSpacing);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_14(false);
        this.interface29_0.imethod_14(vport.UcsPerViewport);
        this.interface29_0.imethod_24(vport.Ucs.Origin);
        this.interface29_0.imethod_29(vport.Ucs.XAxis);
        this.interface29_0.imethod_29(vport.Ucs.YAxis);
        this.interface29_0.imethod_16(vport.Ucs.Elevation);
        this.interface29_0.imethod_32((short) vport.UcsOrthographicType);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_32((short) vport.GridFlags);
        this.interface29_0.imethod_32(vport.MinorGridLinesPerMajorGridLine);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_4(vport.Name);
      this.interface29_0.imethod_40(this.dxfModel_0.VPortTable);
      this.method_76((DxfHandledObject) vport);
      this.method_78(vport.ExtensionDictionary);
      this.interface29_0.imethod_41((DxfHandledObject) null);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_40((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) vport.VisualStyle);
        this.interface29_0.imethod_39((DxfHandledObject) null);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        if (vport.UcsOrthographicType == OrthographicType.None)
        {
          this.interface29_0.imethod_41((DxfHandledObject) vport.Ucs);
          this.interface29_0.imethod_41((DxfHandledObject) null);
        }
        else
        {
          this.interface29_0.imethod_41((DxfHandledObject) null);
          this.interface29_0.imethod_41((DxfHandledObject) vport.Ucs);
        }
      }
      this.method_82((DxfHandledObject) vport);
    }

    private void method_61()
    {
      this.method_79((short) 66, this.dxfModel_0.AppIdTable);
      this.interface29_0.imethod_33(this.dxfModel_0.AppIds.Count);
      this.interface29_0.imethod_40((DxfHandledObject) null);
      this.method_78(this.dxfModel_0.AppIdTable.ExtensionDictionary);
      foreach (DxfHandledObject appId in (KeyedDxfHandledObjectCollection<string, DxfAppId>) this.dxfModel_0.AppIds)
        this.interface29_0.imethod_42(ReferenceType.SoftOwnershipReference, appId);
      this.method_82(this.dxfModel_0.AppIdTable);
    }

    private void method_62(DxfAppId appId)
    {
      this.method_79((short) 67, (DxfHandledObject) appId);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(this.method_86(appId.Name));
      this.method_58((DxfTableRecord) appId);
      this.interface29_0.imethod_11((byte) 0);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_4(appId.Name);
      this.interface29_0.imethod_40(this.dxfModel_0.AppIdTable);
      this.method_76((DxfHandledObject) appId);
      this.method_78(appId.ExtensionDictionary);
      this.interface29_0.imethod_41((DxfHandledObject) null);
      this.method_82((DxfHandledObject) appId);
    }

    private void method_63()
    {
      this.method_79((short) 68, this.dxfModel_0.DimStyleTable);
      this.interface29_0.imethod_33(this.dxfModel_0.DimensionStyles.Count);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
        this.interface29_0.imethod_11((byte) 0);
      this.interface29_0.imethod_40((DxfHandledObject) null);
      this.method_78(this.dxfModel_0.DimStyleTable.ExtensionDictionary);
      foreach (DxfHandledObject dimensionStyle in (KeyedDxfHandledObjectCollection<string, DxfDimensionStyle>) this.dxfModel_0.DimensionStyles)
        this.interface29_0.imethod_42(ReferenceType.SoftOwnershipReference, dimensionStyle);
      this.method_82(this.dxfModel_0.DimStyleTable);
    }

    private void method_64(DxfDimensionStyle dimStyle)
    {
      this.method_79((short) 69, (DxfHandledObject) dimStyle);
      this.interface29_0.imethod_4(this.method_86(dimStyle.Name));
      this.method_58((DxfTableRecord) dimStyle);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf14)
      {
        this.interface29_0.imethod_14(dimStyle.GenerateTolerances);
        this.interface29_0.imethod_14(dimStyle.LimitsGeneration);
        this.interface29_0.imethod_14(dimStyle.TextInsideHorizontal);
        this.interface29_0.imethod_14(dimStyle.TextOutsideHorizontal);
        this.interface29_0.imethod_14(dimStyle.SuppressFirstExtensionLine);
        this.interface29_0.imethod_14(dimStyle.SuppressSecondExtensionLine);
        this.interface29_0.imethod_14(dimStyle.AlternateUnitDimensioning);
        this.interface29_0.imethod_14(dimStyle.TextOutsideExtensions);
        this.interface29_0.imethod_14(dimStyle.SeparateArrowBlocks);
        this.interface29_0.imethod_14(dimStyle.TextInsideExtensions);
        this.interface29_0.imethod_14(dimStyle.SuppressOutsideExtensions);
        this.interface29_0.imethod_11((byte) dimStyle.AlternateUnitDecimalPlaces);
        this.interface29_0.imethod_11((byte) dimStyle.ZeroHandling);
        this.interface29_0.imethod_14(dimStyle.SuppressFirstDimensionLine);
        this.interface29_0.imethod_14(dimStyle.SuppressSecondDimensionLine);
        this.interface29_0.imethod_11((byte) dimStyle.ToleranceAlignment);
        this.interface29_0.imethod_11((byte) dimStyle.TextHorizontalAlignment);
        this.interface29_0.imethod_11((byte) 3);
        this.interface29_0.imethod_14(dimStyle.CursorUpdate == CursorUpdate.ControlsTextAndLinePosition);
        this.interface29_0.imethod_11((byte) dimStyle.ToleranceZeroHandling);
        this.interface29_0.imethod_11((byte) dimStyle.AlternateUnitZeroHandling);
        this.interface29_0.imethod_11((byte) dimStyle.AlternateUnitToleranceZeroHandling);
        this.interface29_0.imethod_11((byte) dimStyle.TextVerticalAlignment);
        this.interface29_0.imethod_32((short) 0);
        this.interface29_0.imethod_32((short) (byte) dimStyle.AngularUnit);
        this.interface29_0.imethod_32(dimStyle.DecimalPlaces);
        this.interface29_0.imethod_32(dimStyle.ToleranceDecimalPlaces);
        this.interface29_0.imethod_32((short) (byte) dimStyle.AlternateUnitFormat);
        this.interface29_0.imethod_32(dimStyle.AlternateUnitToleranceDecimalPlaces);
        this.interface29_0.imethod_16(dimStyle.ScaleFactor);
        this.interface29_0.imethod_16(dimStyle.ArrowSize);
        this.interface29_0.imethod_16(dimStyle.ExtensionLineOffset);
        this.interface29_0.imethod_16(dimStyle.DimensionLineIncrement);
        this.interface29_0.imethod_16(dimStyle.ExtensionLineExtension);
        this.interface29_0.imethod_16(dimStyle.Rounding);
        this.interface29_0.imethod_16(dimStyle.DimensionLineExtension);
        this.interface29_0.imethod_16(dimStyle.PlusTolerance);
        this.interface29_0.imethod_16(dimStyle.MinusTolerance);
        this.interface29_0.imethod_16(dimStyle.TextHeight);
        this.interface29_0.imethod_16(dimStyle.CenterMarkSize);
        this.interface29_0.imethod_16(dimStyle.TickSize);
        this.interface29_0.imethod_16(dimStyle.AlternateUnitScaleFactor);
        this.interface29_0.imethod_16(dimStyle.LinearScaleFactor);
        this.interface29_0.imethod_16(dimStyle.TextVerticalPosition);
        this.interface29_0.imethod_16(dimStyle.ToleranceScaleFactor);
        this.interface29_0.imethod_16(dimStyle.DimensionLineGap);
        this.interface29_0.imethod_4(dimStyle.PostFix);
        this.interface29_0.imethod_4(dimStyle.AlternateDimensioningSuffix);
        this.interface29_0.imethod_4(dimStyle.ArrowBlock == null ? string.Empty : dimStyle.ArrowBlock.Name);
        this.interface29_0.imethod_4(dimStyle.FirstArrowBlock == null ? string.Empty : dimStyle.FirstArrowBlock.Name);
        this.interface29_0.imethod_4(dimStyle.SecondArrowBlock == null ? string.Empty : dimStyle.SecondArrowBlock.Name);
        this.interface29_0.imethod_6(dimStyle.DimensionLineColor);
        this.interface29_0.imethod_6(dimStyle.ExtensionLineColor);
        this.interface29_0.imethod_6(dimStyle.TextColor);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_4(dimStyle.PostFix);
        this.interface29_0.imethod_4(dimStyle.AlternateDimensioningSuffix);
        this.interface29_0.imethod_16(dimStyle.ScaleFactor);
        this.interface29_0.imethod_16(dimStyle.ArrowSize);
        this.interface29_0.imethod_16(dimStyle.ExtensionLineOffset);
        this.interface29_0.imethod_16(dimStyle.DimensionLineIncrement);
        this.interface29_0.imethod_16(dimStyle.ExtensionLineExtension);
        this.interface29_0.imethod_16(dimStyle.Rounding);
        this.interface29_0.imethod_16(dimStyle.DimensionLineExtension);
        this.interface29_0.imethod_16(dimStyle.PlusTolerance);
        this.interface29_0.imethod_16(dimStyle.MinusTolerance);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_16(dimStyle.FixedExtensionLineLength);
        this.interface29_0.imethod_16(dimStyle.JoggedRadiusDimensionTransverseSegmentAngle);
        this.interface29_0.imethod_32((short) dimStyle.TextBackgroundFillMode);
        this.interface29_0.imethod_6(dimStyle.TextBackgroundColor);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_14(dimStyle.GenerateTolerances);
        this.interface29_0.imethod_14(dimStyle.LimitsGeneration);
        this.interface29_0.imethod_14(dimStyle.TextInsideHorizontal);
        this.interface29_0.imethod_14(dimStyle.TextOutsideHorizontal);
        this.interface29_0.imethod_14(dimStyle.SuppressFirstExtensionLine);
        this.interface29_0.imethod_14(dimStyle.SuppressSecondExtensionLine);
        this.interface29_0.imethod_32((short) dimStyle.TextVerticalAlignment);
        this.interface29_0.imethod_32((short) dimStyle.ZeroHandling);
        this.interface29_0.imethod_32((short) dimStyle.AngularZeroHandling);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_32((short) dimStyle.ArcLengthSymbolPosition);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_16(dimStyle.TextHeight);
        this.interface29_0.imethod_16(dimStyle.CenterMarkSize);
        this.interface29_0.imethod_16(dimStyle.TickSize);
        this.interface29_0.imethod_16(dimStyle.AlternateUnitScaleFactor);
        this.interface29_0.imethod_16(dimStyle.LinearScaleFactor);
        this.interface29_0.imethod_16(dimStyle.TextVerticalPosition);
        this.interface29_0.imethod_16(dimStyle.ToleranceScaleFactor);
        this.interface29_0.imethod_16(dimStyle.DimensionLineGap);
        this.interface29_0.imethod_16(dimStyle.AlternateUnitRounding);
        this.interface29_0.imethod_14(dimStyle.AlternateUnitDimensioning);
        this.interface29_0.imethod_32(dimStyle.AlternateUnitDecimalPlaces);
        this.interface29_0.imethod_14(dimStyle.TextOutsideExtensions);
        this.interface29_0.imethod_14(dimStyle.SeparateArrowBlocks);
        this.interface29_0.imethod_14(dimStyle.TextInsideExtensions);
        this.interface29_0.imethod_14(dimStyle.SuppressOutsideExtensions);
        this.interface29_0.imethod_6(dimStyle.DimensionLineColor);
        this.interface29_0.imethod_6(dimStyle.ExtensionLineColor);
        this.interface29_0.imethod_6(dimStyle.TextColor);
        this.interface29_0.imethod_32(dimStyle.AngularDimensionDecimalPlaces);
        this.interface29_0.imethod_32(dimStyle.DecimalPlaces);
        this.interface29_0.imethod_32(dimStyle.ToleranceDecimalPlaces);
        this.interface29_0.imethod_32((short) dimStyle.AlternateUnitFormat);
        this.interface29_0.imethod_32(dimStyle.AlternateUnitToleranceDecimalPlaces);
        this.interface29_0.imethod_32((short) dimStyle.AngularUnit);
        this.interface29_0.imethod_32((short) dimStyle.FractionFormat);
        this.interface29_0.imethod_32((short) dimStyle.LinearUnitFormat);
        this.interface29_0.imethod_32((short) dimStyle.DecimalSeparator);
        this.interface29_0.imethod_32((short) dimStyle.TextMovement);
        this.interface29_0.imethod_32((short) dimStyle.TextHorizontalAlignment);
        this.interface29_0.imethod_14(dimStyle.SuppressFirstDimensionLine);
        this.interface29_0.imethod_14(dimStyle.SuppressSecondDimensionLine);
        this.interface29_0.imethod_32((short) dimStyle.ToleranceAlignment);
        this.interface29_0.imethod_32((short) dimStyle.ToleranceZeroHandling);
        this.interface29_0.imethod_32((short) dimStyle.AlternateUnitZeroHandling);
        this.interface29_0.imethod_32((short) dimStyle.AlternateUnitToleranceZeroHandling);
        this.interface29_0.imethod_14(dimStyle.CursorUpdate == CursorUpdate.ControlsTextAndLinePosition);
        this.interface29_0.imethod_32((short) 3);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_14(dimStyle.IsExtensionLineLengthFixed);
      if (this.dxfVersion_0 > DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_14(dimStyle.TextDirection == TextDirection.RightToLeft);
        this.interface29_0.imethod_16(dimStyle.AltMzf);
        this.interface29_0.imethod_4(dimStyle.AltMzs);
        this.interface29_0.imethod_16(dimStyle.Mzf);
        this.interface29_0.imethod_4(dimStyle.Mzs);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_32(dimStyle.DimensionLineWeight);
        this.interface29_0.imethod_32(dimStyle.ExtensionLineWeight);
      }
      this.interface29_0.imethod_14(false);
      this.interface29_0.imethod_40(this.dxfModel_0.DimStyleTable);
      this.method_76((DxfHandledObject) dimStyle);
      this.method_78(dimStyle.ExtensionDictionary);
      this.interface29_0.imethod_41((DxfHandledObject) null);
      this.interface29_0.imethod_41((DxfHandledObject) dimStyle.TextStyle);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_41((DxfHandledObject) dimStyle.LeaderArrowBlock);
        this.interface29_0.imethod_41((DxfHandledObject) dimStyle.ArrowBlock);
        this.interface29_0.imethod_41((DxfHandledObject) dimStyle.FirstArrowBlock);
        this.interface29_0.imethod_41((DxfHandledObject) dimStyle.SecondArrowBlock);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_41((DxfHandledObject) dimStyle.DimensionLineLineType);
        this.interface29_0.imethod_41((DxfHandledObject) dimStyle.FirstExtensionLineLineType);
        this.interface29_0.imethod_41((DxfHandledObject) dimStyle.SecondExtensionLineLineType);
      }
      this.method_82((DxfHandledObject) dimStyle);
    }

    private void method_65()
    {
      this.method_79((short) 70, this.dxfModel_0.ViewportEntityHeaderTable);
      this.interface29_0.imethod_33(this.dxfModel_0.ViewportEntityHeaders.Count);
      this.interface29_0.imethod_40((DxfHandledObject) null);
      this.method_78(this.dxfModel_0.ViewportEntityHeaderTable.ExtensionDictionary);
      foreach (DxfHandledObject viewportEntityHeader in (DxfHandledObjectCollection<DxfViewportEntityHeader>) this.dxfModel_0.ViewportEntityHeaders)
        this.interface29_0.imethod_42(ReferenceType.SoftOwnershipReference, viewportEntityHeader);
      this.method_82(this.dxfModel_0.ViewportEntityHeaderTable);
    }

    private void method_66(DxfViewportEntityHeader viewportHeader, DxfViewportEntityHeader next)
    {
      this.method_79((short) 71, (DxfHandledObject) viewportHeader);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(viewportHeader.Name);
      this.method_58((DxfTableRecord) viewportHeader);
      this.interface29_0.imethod_14(viewportHeader.IsViewportOn);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_4(viewportHeader.Name);
      this.method_77((IDxfHandledObject) viewportHeader, (IDxfHandledObject) this.dxfModel_0.ViewportEntityHeaderTable);
      this.method_76((DxfHandledObject) viewportHeader);
      this.method_78(viewportHeader.ExtensionDictionary);
      this.interface29_0.imethod_41((DxfHandledObject) null);
      this.interface29_0.imethod_40((DxfHandledObject) viewportHeader.Viewport);
      this.interface29_0.imethod_41((DxfHandledObject) next);
      this.method_82((DxfHandledObject) viewportHeader);
    }

    private void method_67(DxfBlockBegin blockBegin)
    {
      this.method_73((DxfEntity) blockBegin);
      this.interface29_0.imethod_4(this.method_86(blockBegin.Block.Name));
      this.method_82((DxfHandledObject) blockBegin);
    }

    private void method_68(DxfBlockEnd endBlock)
    {
      this.method_73((DxfEntity) endBlock);
      this.method_82((DxfHandledObject) endBlock);
    }

    private void method_69()
    {
      foreach (DxfBlock block in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfModel_0.Blocks)
        this.method_70(block);
      foreach (DxfBlock anonymousBlock in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfModel_0.AnonymousBlocks)
        this.method_70(anonymousBlock);
    }

    private void method_70(DxfBlock block)
    {
      List<DxfEntity> dxfEntityList = this.method_71(block);
      this.dxfBlock_0 = block;
      this.dxfEntity_0 = (DxfEntity) null;
      this.dxfEntity_1 = (DxfEntity) null;
      this.method_67(block.BlockBegin);
      if (dxfEntityList.Count > 0)
      {
        int count = dxfEntityList.Count;
        this.dxfEntity_0 = (DxfEntity) null;
        DxfEntity dxfEntity1 = dxfEntityList[0];
        for (int index = 1; index < count; ++index)
        {
          this.dxfEntity_1 = dxfEntityList[index];
          dxfEntity1.Accept((IEntityVisitor) this);
          this.dxfEntity_0 = dxfEntity1;
          dxfEntity1 = this.dxfEntity_1;
        }
        this.dxfEntity_1 = (DxfEntity) null;
        dxfEntity1.Accept((IEntityVisitor) this);
      }
      this.dxfEntity_0 = (DxfEntity) null;
      this.dxfEntity_1 = (DxfEntity) null;
      this.method_68(block.BlockEnd);
    }

    private List<DxfEntity> method_71(DxfBlock block)
    {
      List<DxfEntity> dxfEntityList;
      if (!this.dictionary_0.TryGetValue(block, out dxfEntityList))
      {
        dxfEntityList = new List<DxfEntity>();
        foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) block.Entities)
        {
          entity.Accept((IEntityVisitor) this.class920_0);
          if (this.class920_0.Supported)
            dxfEntityList.Add(entity);
        }
        if (block != null && block.Layout != null)
        {
          foreach (DxfViewport viewport in (DxfHandledObjectCollection<DxfViewport>) block.Layout.Viewports)
            dxfEntityList.Add((DxfEntity) viewport);
        }
        this.dictionary_0.Add(block, dxfEntityList);
      }
      return dxfEntityList;
    }

    private void method_72()
    {
      this.queue_0.Enqueue((DxfObject) this.dxfModel_0.DictionaryRoot);
      foreach (DxfObject dxfObject in this.dxfModel_0.method_16())
        this.queue_0.Enqueue(dxfObject);
      while (this.queue_0.Count > 0)
        this.queue_0.Dequeue().Accept((IObjectVisitor) this);
    }

    public void method_73(DxfEntity entity)
    {
      this.method_80();
      this.interface29_0.imethod_46(entity.vmethod_6(this));
      if (this.dxfVersion_0 > DxfVersion.Dxf14 && this.dxfVersion_0 < DxfVersion.Dxf24)
        this.method_81();
      this.interface29_0.imethod_35(new ReferenceType?(), entity.Handle);
      entity.method_3(this);
      entity.vmethod_12(this);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf14)
        this.method_81();
      Enum27 entityType = this.method_44();
      this.interface29_0.imethod_15((byte) entityType);
      entity.method_2(this);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf14)
        this.interface29_0.imethod_14(this.method_74(entity));
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
      {
        this.bool_0 = true;
      }
      else
      {
        this.bool_0 = this.dxfEntity_0 != null && (long) this.dxfEntity_0.Handle == (long) entity.Handle - 1L && this.dxfEntity_1 != null && (long) this.dxfEntity_1.Handle == (long) entity.Handle + 1L;
        this.interface29_0.imethod_14(this.bool_0);
      }
      this.interface29_0.imethod_10(entity.Color, entity.Transparency, entity.DxfColor != null);
      this.interface29_0.imethod_16(entity.LineTypeScale);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        if (this.method_74(entity))
          this.interface29_0.imethod_15((byte) 0);
        else if (entity.LineType == this.dxfModel_0.ByBlockLineType)
          this.interface29_0.imethod_15((byte) 1);
        else if (entity.LineType == this.dxfModel_0.ContinuousLineType)
          this.interface29_0.imethod_15((byte) 2);
        else
          this.interface29_0.imethod_15((byte) 3);
        this.interface29_0.imethod_15((byte) 0);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_15((byte) 0);
        this.interface29_0.imethod_11((byte) 0);
      }
      if (this.dxfVersion_0 > DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_14(false);
        this.interface29_0.imethod_14(false);
        this.interface29_0.imethod_14(false);
      }
      this.interface29_0.imethod_32(entity.Visible ? (short) 0 : (short) 1);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
        this.interface29_0.imethod_11(Class885.smethod_5(entity.LineWeight));
      this.method_75(entity, this.dxfEntity_0, this.dxfEntity_1, entityType);
    }

    private bool method_74(DxfEntity entity)
    {
      if (entity.LineType != null)
        return entity.LineType == this.dxfModel_0.ByLayerLineType;
      return true;
    }

    private void method_75(
      DxfEntity entity,
      DxfEntity previousEntity,
      DxfEntity nextEntity,
      Enum27 entityType)
    {
      if (entityType == Enum27.const_0)
      {
        IDxfHandledObject referencedHandledObject = this.idxfHandledObject_0 ?? (IDxfHandledObject) this.dxfBlock_0;
        if (referencedHandledObject == null)
          throw new InternalException("Owner may not be null.");
        this.method_77((IDxfHandledObject) entity, referencedHandledObject);
      }
      this.method_76((DxfHandledObject) entity);
      this.method_78(entity.ExtensionDictionary);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf14)
      {
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.GetLayer(entity));
        if (!this.method_74(entity))
          this.interface29_0.imethod_41((DxfHandledObject) entity.LineType);
      }
      if (this.dxfVersion_0 <= DxfVersion.Dxf15 && !this.bool_0)
      {
        this.method_77((IDxfHandledObject) entity, (IDxfHandledObject) previousEntity);
        this.method_77((IDxfHandledObject) entity, (IDxfHandledObject) nextEntity);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf18 && entity.DxfColor != null)
        this.interface29_0.imethod_41((DxfHandledObject) entity.DxfColor);
      if (this.dxfVersion_0 < DxfVersion.Dxf15)
        return;
      this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.GetLayer(entity));
      if (this.method_74(entity) || entity.LineType == this.dxfModel_0.ByBlockLineType || entity.LineType == this.dxfModel_0.ContinuousLineType)
        return;
      this.interface29_0.imethod_41((DxfHandledObject) entity.LineType);
    }

    public void method_76(DxfHandledObject handledObject)
    {
      if (!handledObject.HasPersistentReactors)
        return;
      foreach (DxfHandledObject persistentReactor in handledObject.PersistentReactors)
        this.interface29_0.imethod_40(persistentReactor);
    }

    public void method_77(
      IDxfHandledObject referenceObject,
      IDxfHandledObject referencedHandledObject)
    {
      if (referencedHandledObject == null)
        this.interface29_0.imethod_43(new ReferenceType?(ReferenceType.SoftPointerReference), 0UL);
      else
        this.interface29_0.imethod_43(new ReferenceType?(ReferenceType.SoftPointerReference), referencedHandledObject.Handle);
    }

    public void method_78(DxfDictionary extensionDictionary)
    {
      if (this.dxfVersion_0 >= DxfVersion.Dxf18 && extensionDictionary == null)
        return;
      this.interface29_0.imethod_39((DxfHandledObject) extensionDictionary);
    }

    private void method_79(short objectType, DxfHandledObject value)
    {
      value.Write(this, objectType);
      value.method_2(this);
    }

    private void method_80()
    {
      this.interface29_0.Clear();
    }

    public void method_81()
    {
      this.interface29_0.imethod_0();
    }

    public void method_82(DxfHandledObject handledObject)
    {
      this.method_83();
      long position = this.stream_0.Position;
      Stream1 stream1 = new Stream1(this.stream_0, (ushort) 49345);
      long num = 0;
      uint length = (uint) this.memoryStream_0.Length;
      if (this.dxfVersion_0 > DxfVersion.Dxf21)
        num = (this.memoryStream_0.Length << 3) - this.interface29_0.HandleStreamBitPosition;
      Class992.smethod_2((Stream) stream1, length);
      if (this.dxfVersion_0 > DxfVersion.Dxf21)
        Class992.smethod_3((Stream) stream1, (ulong) num);
      stream1.Write(this.memoryStream_0.GetBuffer(), 0, (int) this.memoryStream_0.Length);
      Class1045.smethod_6(this.stream_0, stream1.Crc);
      this.list_0.Add(new Class991(handledObject.Handle, position));
    }

    private void method_83()
    {
      this.interface29_0.Flush();
    }

    public void method_84(DxfExtendedData extendedData)
    {
      this.class433_0.Reset();
      foreach (IExtendedDataValue extendedDataValue in (List<IExtendedDataValue>) extendedData.Values)
        extendedDataValue.Accept((IExtendedDataValueVisitor) this.class433_0);
      if (this.class433_0.Stream.Length > (long) ushort.MaxValue)
        throw new ArgumentOutOfRangeException("Extended data size too large.");
      this.interface29_0.imethod_32((short) this.class433_0.Stream.Length);
      this.interface29_0.imethod_35(new ReferenceType?(ReferenceType.HardPointerReference), extendedData.AppId.Handle);
      this.interface29_0.imethod_13(this.class433_0.Stream.GetBuffer(), 0, (int) this.class433_0.Stream.Length);
      this.class433_0.Reset();
    }

    private void method_85()
    {
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        return;
      this.interface29_0.imethod_32((short) 0);
    }

    private string method_86(string name)
    {
      return Class721.smethod_0(this.dxfVersion_0, name);
    }

    public void Visit(Dxf3DFace face)
    {
      this.method_73((DxfEntity) face);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf14)
      {
        this.interface29_0.imethod_24(face.Points[0]);
        this.interface29_0.imethod_24(face.Points[1]);
        this.interface29_0.imethod_24(face.Points[2]);
        if (face.Points.Count >= 4)
          this.interface29_0.imethod_24(face.Points[3]);
        else
          this.interface29_0.imethod_24(face.Points[0]);
        this.interface29_0.imethod_32((short) face.method_13());
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        InvisibleEdgeFlags invisibleEdgeFlags = face.method_13();
        bool flag1 = invisibleEdgeFlags == InvisibleEdgeFlags.None;
        this.interface29_0.imethod_14(flag1);
        WW.Math.Point3D point1 = face.Points[0];
        bool flag2 = point1.Z == 0.0;
        this.interface29_0.imethod_14(flag2);
        this.interface29_0.imethod_20(point1.X);
        this.interface29_0.imethod_20(point1.Y);
        if (!flag2)
          this.interface29_0.imethod_20(point1.Z);
        WW.Math.Point3D point2 = face.Points[1];
        this.interface29_0.imethod_31(point2, point1);
        WW.Math.Point3D point3 = face.Points[2];
        this.interface29_0.imethod_31(point3, point2);
        if (face.Points.Count >= 4)
          this.interface29_0.imethod_31(face.Points[3], point3);
        else
          this.interface29_0.imethod_31(point1, point3);
        if (!flag1)
          this.interface29_0.imethod_32((short) invisibleEdgeFlags);
      }
      this.method_82((DxfHandledObject) face);
    }

    public void Visit(DxfArc arc)
    {
      this.method_73((DxfEntity) arc);
      this.interface29_0.imethod_24(arc.Center);
      this.interface29_0.imethod_16(arc.Radius);
      this.interface29_0.imethod_1(arc.Thickness);
      this.interface29_0.imethod_3(arc.ZAxis);
      this.interface29_0.imethod_16(arc.StartAngle);
      this.interface29_0.imethod_16(arc.EndAngle);
      this.method_82((DxfHandledObject) arc);
    }

    public void Visit(DxfAttribute attribute)
    {
      this.Write(attribute);
    }

    private void Write(DxfAttribute attribute)
    {
      this.method_73((DxfEntity) attribute);
      this.method_126((DxfText) attribute);
      if (this.dxfVersion_0 > DxfVersion.Dxf21)
        this.interface29_0.imethod_11(attribute.Unknown0);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(attribute.TagString);
      this.interface29_0.imethod_32((short) 0);
      this.interface29_0.imethod_11((byte) attribute.Flags);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_14(attribute.LockPosition);
      this.method_127((DxfText) attribute);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_4(attribute.TagString);
      this.method_128((DxfText) attribute);
      this.method_82((DxfHandledObject) attribute);
    }

    public void Visit(DxfAttributeDefinition attributeDefinition)
    {
      this.method_73((DxfEntity) attributeDefinition);
      this.method_126((DxfText) attributeDefinition);
      this.method_127((DxfText) attributeDefinition);
      if (this.dxfVersion_0 > DxfVersion.Dxf21)
        this.interface29_0.imethod_11(attributeDefinition.Unknown0);
      this.interface29_0.imethod_4(attributeDefinition.TagString);
      this.interface29_0.imethod_32((short) 0);
      this.interface29_0.imethod_11((byte) attributeDefinition.Flags);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_14(attributeDefinition.LockPosition);
      if (this.dxfVersion_0 > DxfVersion.Dxf21)
        this.interface29_0.imethod_11(attributeDefinition.Unknown1);
      this.interface29_0.imethod_4(attributeDefinition.PromptString);
      this.method_128((DxfText) attributeDefinition);
      this.method_82((DxfHandledObject) attributeDefinition);
    }

    public void Visit(DxfCircle circle)
    {
      this.method_73((DxfEntity) circle);
      this.interface29_0.imethod_24(circle.Center);
      this.interface29_0.imethod_16(circle.Radius);
      this.interface29_0.imethod_1(circle.Thickness);
      this.interface29_0.imethod_3(circle.ZAxis);
      this.method_82((DxfHandledObject) circle);
    }

    public void Visit(DxfDimension.Aligned dimension)
    {
      this.method_87(dimension);
      this.method_89((DxfDimension) dimension);
      this.method_90((DxfDimension) dimension);
      this.method_82((DxfHandledObject) dimension);
    }

    public void Visit(DxfDimension.Angular3Point dimension)
    {
      this.method_88((DxfDimension) dimension);
      this.interface29_0.imethod_24(dimension.DimensionLineArcPoint);
      this.interface29_0.imethod_24(dimension.ExtensionLine1StartPoint);
      this.interface29_0.imethod_24(dimension.ExtensionLine2StartPoint);
      this.interface29_0.imethod_24(dimension.AngleVertex);
      this.method_89((DxfDimension) dimension);
      this.method_90((DxfDimension) dimension);
      this.method_82((DxfHandledObject) dimension);
    }

    public void Visit(DxfDimension.Angular4Point dimension)
    {
      this.method_88((DxfDimension) dimension);
      this.interface29_0.imethod_20(dimension.DimensionLineArcPoint.X);
      this.interface29_0.imethod_20(dimension.DimensionLineArcPoint.Y);
      this.interface29_0.imethod_24(dimension.ExtensionLine1StartPoint);
      this.interface29_0.imethod_24(dimension.ExtensionLine1EndPoint);
      this.interface29_0.imethod_24(dimension.ExtensionLine2StartPoint);
      this.interface29_0.imethod_24(dimension.ExtensionLine2EndPoint);
      this.method_89((DxfDimension) dimension);
      this.method_90((DxfDimension) dimension);
      this.method_82((DxfHandledObject) dimension);
    }

    public void Visit(DxfDimension.Diametric dimension)
    {
      this.method_88((DxfDimension) dimension);
      this.interface29_0.imethod_24(dimension.ArcLineIntersectionPoint1);
      this.interface29_0.imethod_24(dimension.ArcLineIntersectionPoint2);
      this.interface29_0.imethod_16(dimension.LeaderLength);
      this.method_89((DxfDimension) dimension);
      this.method_90((DxfDimension) dimension);
      this.method_82((DxfHandledObject) dimension);
    }

    public void Visit(DxfDimension.Linear dimension)
    {
      this.method_87((DxfDimension.Aligned) dimension);
      this.interface29_0.imethod_16(dimension.Rotation);
      this.method_89((DxfDimension) dimension);
      this.method_90((DxfDimension) dimension);
      this.method_82((DxfHandledObject) dimension);
    }

    public void Visit(DxfDimension.Ordinate dimension)
    {
      this.method_88((DxfDimension) dimension);
      this.interface29_0.imethod_24(dimension.UcsOrigin);
      this.interface29_0.imethod_24(dimension.FeaturePosition);
      this.interface29_0.imethod_24(dimension.LeaderEndPoint);
      this.interface29_0.imethod_11(dimension.ShowX ? (byte) 1 : (byte) 0);
      this.method_89((DxfDimension) dimension);
      this.method_90((DxfDimension) dimension);
      this.method_82((DxfHandledObject) dimension);
    }

    public void Visit(DxfDimension.Radial dimension)
    {
      this.method_88((DxfDimension) dimension);
      this.interface29_0.imethod_24(dimension.Center);
      this.interface29_0.imethod_24(dimension.ArcLineIntersectionPoint);
      this.interface29_0.imethod_16(dimension.LeaderLength);
      this.method_89((DxfDimension) dimension);
      this.method_90((DxfDimension) dimension);
      this.method_82((DxfHandledObject) dimension);
    }

    private void method_87(DxfDimension.Aligned dimension)
    {
      this.method_88((DxfDimension) dimension);
      this.interface29_0.imethod_24(dimension.ExtensionLine1StartPoint);
      this.interface29_0.imethod_24(dimension.ExtensionLine2StartPoint);
      this.interface29_0.imethod_24(dimension.DimensionLineLocation);
      this.interface29_0.imethod_16(dimension.ObliqueAngle);
    }

    private void method_88(DxfDimension dimension)
    {
      this.method_73((DxfEntity) dimension);
      if (this.dxfVersion_0 > DxfVersion.Dxf21)
        this.interface29_0.imethod_11(dimension.Version);
      this.interface29_0.imethod_29(dimension.ZAxis);
      this.interface29_0.imethod_20(dimension.TextMiddlePoint.X);
      this.interface29_0.imethod_20(dimension.TextMiddlePoint.Y);
      this.interface29_0.imethod_16(dimension.InsertionPoint.Z);
      byte num = 0;
      if (!dimension.UseTextMiddlePoint)
        num |= (byte) 1;
      if (dimension.DimensionStyleOverrides.HasOverrides)
        num |= (byte) 8;
      this.interface29_0.imethod_11(num);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(dimension.Text);
      this.interface29_0.imethod_16(dimension.TextRotation);
      this.interface29_0.imethod_16(dimension.HorizontalDirection);
      this.interface29_0.imethod_16(dimension.InsertionScaleFactor.X);
      this.interface29_0.imethod_16(dimension.InsertionScaleFactor.Y);
      this.interface29_0.imethod_16(dimension.InsertionScaleFactor.Z);
      this.interface29_0.imethod_16(dimension.InsertionRotation);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_32((short) dimension.AttachmentPoint);
        this.interface29_0.imethod_32((short) dimension.LineSpacingStyle);
        this.interface29_0.imethod_16(dimension.LineSpacingFactor);
        this.interface29_0.imethod_16(dimension.Measurement);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_14(false);
        this.interface29_0.imethod_14(false);
        this.interface29_0.imethod_14(false);
      }
      this.interface29_0.imethod_20(dimension.InsertionPoint.X);
      this.interface29_0.imethod_20(dimension.InsertionPoint.Y);
    }

    private void method_89(DxfDimension dimension)
    {
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        return;
      this.interface29_0.imethod_4(dimension.Text);
    }

    private void method_90(DxfDimension dimension)
    {
      this.interface29_0.imethod_41((DxfHandledObject) dimension.DimensionStyle);
      this.interface29_0.imethod_41(dimension.Block == null ? (DxfHandledObject) null : (DxfHandledObject) dimension.Block);
    }

    public void Visit(DxfEllipse ellipse)
    {
      this.method_73((DxfEntity) ellipse);
      this.interface29_0.imethod_24(ellipse.Center);
      this.interface29_0.imethod_29(ellipse.MajorAxisEndPoint);
      this.interface29_0.imethod_29(ellipse.ZAxis);
      this.interface29_0.imethod_16(ellipse.MinorToMajorRatio);
      this.interface29_0.imethod_16(ellipse.StartParameter);
      this.interface29_0.imethod_16(ellipse.EndParameter);
      this.method_82((DxfHandledObject) ellipse);
    }

    public void Visit(DxfHatch hatch)
    {
      this.method_73((DxfEntity) hatch);
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
      {
        DxfColorGradient dxfColorGradient = hatch.ColorGradient ?? DxfColorGradient.dxfColorGradient_0;
        this.interface29_0.imethod_33(dxfColorGradient.Enabled ? 1 : 0);
        this.interface29_0.imethod_33(dxfColorGradient.Reserved1);
        this.interface29_0.imethod_16(dxfColorGradient.Angle);
        this.interface29_0.imethod_16(dxfColorGradient.Shift);
        this.interface29_0.imethod_33(dxfColorGradient.IsSingleColorGradient ? 1 : 0);
        this.interface29_0.imethod_16(dxfColorGradient.ColorTint);
        this.interface29_0.imethod_33(dxfColorGradient.GradientColors.Count);
        foreach (DxfGradientColor gradientColor in dxfColorGradient.GradientColors)
        {
          this.interface29_0.imethod_16(gradientColor.Value);
          this.interface29_0.imethod_6(gradientColor.Color);
        }
        this.interface29_0.imethod_4(dxfColorGradient.Name);
      }
      this.interface29_0.imethod_16(hatch.ElevationPoint.Z);
      this.interface29_0.imethod_29(hatch.ZAxis);
      this.interface29_0.imethod_4(hatch.Name);
      this.interface29_0.imethod_14(hatch.Pattern == null);
      this.interface29_0.imethod_14(hatch.Associative);
      this.interface29_0.imethod_33(hatch.BoundaryPaths.Count);
      bool flag = false;
      for (int index = 0; index < hatch.BoundaryPaths.Count; ++index)
      {
        DxfHatch.BoundaryPath boundaryPath = hatch.BoundaryPaths[index];
        if ((boundaryPath.Type & BoundaryPathType.Derived) != BoundaryPathType.None)
          flag = true;
        boundaryPath.Write(this);
        this.interface29_0.imethod_33(boundaryPath.BoundaryObjects.Count);
      }
      this.interface29_0.imethod_32((short) hatch.HatchStyle);
      this.interface29_0.imethod_32((short) hatch.HatchPatternType);
      if (hatch.Pattern != null)
      {
        DxfPattern pattern = hatch.Pattern;
        this.interface29_0.imethod_16(hatch.HatchPatternAngle);
        this.interface29_0.imethod_16(hatch.Scale);
        this.interface29_0.imethod_14(hatch.IsDouble);
        hatch.Pattern.Write(this.interface29_0);
      }
      if (flag)
        this.interface29_0.imethod_16(hatch.PixelSize);
      this.interface29_0.imethod_33(hatch.SeedPoints.Count);
      for (int index = 0; index < hatch.SeedPoints.Count; ++index)
        this.interface29_0.imethod_25(hatch.SeedPoints[index]);
      foreach (DxfHatch.BoundaryPath boundaryPath in hatch.BoundaryPaths)
      {
        foreach (DxfHandledObject boundaryObject in (DxfHandledObjectCollection<DxfEntity>) boundaryPath.BoundaryObjects)
          this.interface29_0.imethod_40(boundaryObject);
      }
      this.method_82((DxfHandledObject) hatch);
    }

    public void Visit(DxfInsert insert)
    {
      this.method_92((DxfInsertBase) insert);
      if (insert.RowCount > (ushort) 1 || insert.ColumnCount > (ushort) 1)
      {
        this.interface29_0.imethod_32((short) insert.ColumnCount);
        this.interface29_0.imethod_32((short) insert.RowCount);
        this.interface29_0.imethod_16(insert.ColumnSpacing);
        this.interface29_0.imethod_16(insert.RowSpacing);
      }
      this.method_93((DxfInsertBase) insert);
      this.method_82((DxfHandledObject) insert);
      if (insert.Attributes.Count <= 0)
        return;
      this.method_91(insert);
    }

    public void Visit(DxfIDBlockReference insert)
    {
      if (insert.RowCount <= (ushort) 1 && insert.ColumnCount <= (ushort) 1)
      {
        this.method_92((DxfInsertBase) insert);
        this.method_93((DxfInsertBase) insert);
      }
      else
      {
        this.method_92((DxfInsertBase) insert);
        this.interface29_0.imethod_32((short) insert.ColumnCount);
        this.interface29_0.imethod_32((short) insert.RowCount);
        this.interface29_0.imethod_16(insert.ColumnSpacing);
        this.interface29_0.imethod_16(insert.RowSpacing);
        this.method_93((DxfInsertBase) insert);
      }
      this.interface29_0.imethod_42(ReferenceType.SoftPointerReference, insert.Viewport);
      this.method_82((DxfHandledObject) insert);
      if (insert.Attributes.Count <= 0)
        return;
      this.method_91((DxfInsert) insert);
    }

    private void method_91(DxfInsert insert)
    {
      this.method_94((DxfEntity) insert);
      DxfEntity dxfEntity0 = this.dxfEntity_0;
      DxfEntity dxfEntity1 = this.dxfEntity_1;
      int count = insert.Attributes.Count;
      this.dxfEntity_0 = (DxfEntity) null;
      DxfEntity dxfEntity = (DxfEntity) insert.Attributes[0];
      for (int index = 1; index < count; ++index)
      {
        this.dxfEntity_1 = (DxfEntity) insert.Attributes[index];
        this.Write((DxfAttribute) dxfEntity);
        this.dxfEntity_0 = dxfEntity;
        dxfEntity = this.dxfEntity_1;
      }
      this.dxfEntity_1 = (DxfEntity) null;
      this.Write((DxfAttribute) dxfEntity);
      this.Write(insert.AttributesSeqEnd);
      this.dxfEntity_0 = dxfEntity0;
      this.dxfEntity_1 = dxfEntity1;
      this.method_94((DxfEntity) null);
    }

    private void method_92(DxfInsertBase insert)
    {
      this.method_73((DxfEntity) insert);
      this.interface29_0.imethod_24(insert.InsertionPoint);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf14)
        this.interface29_0.imethod_29(insert.ScaleFactor);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        if (insert.ScaleFactor.X == 1.0 && insert.ScaleFactor.Y == 1.0 && insert.ScaleFactor.Z == 1.0)
          this.interface29_0.imethod_15((byte) 3);
        else if (insert.ScaleFactor.X == insert.ScaleFactor.Y && insert.ScaleFactor.X == insert.ScaleFactor.Z)
        {
          this.interface29_0.imethod_15((byte) 2);
          this.interface29_0.imethod_20(insert.ScaleFactor.X);
        }
        else if (insert.ScaleFactor.X == 1.0)
        {
          this.interface29_0.imethod_15((byte) 1);
          this.interface29_0.imethod_17(insert.ScaleFactor.Y, 1.0);
          this.interface29_0.imethod_17(insert.ScaleFactor.Z, 1.0);
        }
        else
        {
          this.interface29_0.imethod_15((byte) 0);
          this.interface29_0.imethod_20(insert.ScaleFactor.X);
          this.interface29_0.imethod_17(insert.ScaleFactor.Y, insert.ScaleFactor.X);
          this.interface29_0.imethod_17(insert.ScaleFactor.Z, insert.ScaleFactor.X);
        }
      }
      this.interface29_0.imethod_16(insert.Rotation);
      this.interface29_0.imethod_29(insert.ZAxis);
      bool flag = insert.Attributes.Count > 0;
      this.interface29_0.imethod_14(flag);
      if (this.dxfVersion_0 < DxfVersion.Dxf18 || !flag)
        return;
      this.interface29_0.imethod_33(insert.Attributes.Count);
    }

    private void method_93(DxfInsertBase insert)
    {
      this.interface29_0.imethod_41((DxfHandledObject) insert.Block);
      if (insert.Attributes.Count <= 0)
        return;
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_40((DxfHandledObject) insert.Attributes[0]);
        this.interface29_0.imethod_40((DxfHandledObject) insert.Attributes[insert.Attributes.Count - 1]);
      }
      else if (this.dxfVersion_0 > DxfVersion.Dxf15)
      {
        for (int index = 0; index < insert.Attributes.Count; ++index)
          this.interface29_0.imethod_39((DxfHandledObject) insert.Attributes[index]);
      }
      this.interface29_0.imethod_39((DxfHandledObject) insert.AttributesSeqEnd);
    }

    public void Visit(DxfLeader leader)
    {
      this.method_73((DxfEntity) leader);
      this.interface29_0.imethod_14(false);
      this.interface29_0.imethod_32((short) leader.CreationType);
      this.interface29_0.imethod_32((short) leader.PathType);
      this.interface29_0.imethod_33(leader.HasHookLine ? leader.Vertices.Count - 1 : leader.Vertices.Count);
      for (int index = 0; index < leader.Vertices.Count; ++index)
      {
        if (!leader.HasHookLine || index != leader.Vertices.Count - 2)
          this.interface29_0.imethod_24(leader.Vertices[index]);
      }
      this.interface29_0.imethod_24(leader.Origin);
      this.interface29_0.imethod_29(leader.ZAxis);
      this.interface29_0.imethod_29(leader.HorizontalDirection);
      this.interface29_0.imethod_29(leader.LastVertexOffsetFromBlock);
      if (this.dxfVersion_0 >= DxfVersion.Dxf14)
        this.interface29_0.imethod_29(leader.LastVertexOffsetFromAnnotation);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf14)
        this.interface29_0.imethod_16(leader.DimensionStyleOverrides.DimensionLineGap);
      if (this.dxfVersion_0 <= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_16(leader.TextAnnotationHeight);
        this.interface29_0.imethod_16(leader.TextAnnotationWidth);
      }
      this.interface29_0.imethod_14(leader.HookLineDirection == HookLineDirection.Same);
      this.interface29_0.imethod_14(leader.ArrowHeadEnabled);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf14)
      {
        this.interface29_0.imethod_32((short) 0);
        this.interface29_0.imethod_16(leader.DimensionStyleOverrides.ArrowSize * leader.DimensionStyleOverrides.ScaleFactor);
        this.interface29_0.imethod_14(false);
        this.interface29_0.imethod_14(false);
        this.interface29_0.imethod_32((short) 0);
        this.interface29_0.imethod_32((short) 0);
        this.interface29_0.imethod_14(false);
        this.interface29_0.imethod_14(false);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_32((short) 0);
        this.interface29_0.imethod_14(false);
        this.interface29_0.imethod_14(false);
      }
      this.interface29_0.imethod_41((DxfHandledObject) leader.AssociatedAnnotation);
      this.interface29_0.imethod_41((DxfHandledObject) leader.DimensionStyle);
      this.method_82((DxfHandledObject) leader);
    }

    public void Visit(DxfLine line)
    {
      this.method_73((DxfEntity) line);
      if (this.dxfVersion_0 == DxfVersion.Dxf13 || this.dxfVersion_0 == DxfVersion.Dxf14)
      {
        this.interface29_0.imethod_24(line.Start);
        this.interface29_0.imethod_24(line.End);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        bool flag = line.Start.Z == 0.0 && line.End.Z == 0.0;
        this.interface29_0.imethod_14(flag);
        this.interface29_0.imethod_20(line.Start.X);
        this.interface29_0.imethod_17(line.End.X, line.Start.X);
        this.interface29_0.imethod_20(line.Start.Y);
        this.interface29_0.imethod_17(line.End.Y, line.Start.Y);
        if (!flag)
        {
          this.interface29_0.imethod_20(line.Start.Z);
          this.interface29_0.imethod_17(line.End.Z, line.Start.Z);
        }
      }
      this.interface29_0.imethod_1(line.Thickness);
      this.interface29_0.imethod_3(line.ZAxis);
      this.method_82((DxfHandledObject) line);
    }

    public void Visit(DxfLwPolyline polyline)
    {
      this.method_73((DxfEntity) polyline);
      polyline.method_15(this.interface29_0);
      this.method_82((DxfHandledObject) polyline);
    }

    public void Visit(DxfMeshFace meshFace)
    {
      throw new NotSupportedException("A mesh face can only exist in context of a polyface mesh.");
    }

    private void Write(DxfPolyfaceMesh polyfaceMesh, DxfMeshFace meshFace)
    {
      this.method_94((DxfEntity) polyfaceMesh);
      this.method_73((DxfEntity) meshFace);
      this.interface29_0.imethod_32(meshFace.Corners.Count > 0 ? this.method_95(polyfaceMesh, meshFace.Corners[0]) : (short) 0);
      this.interface29_0.imethod_32(meshFace.Corners.Count > 1 ? this.method_95(polyfaceMesh, meshFace.Corners[1]) : (short) 0);
      this.interface29_0.imethod_32(meshFace.Corners.Count > 2 ? this.method_95(polyfaceMesh, meshFace.Corners[2]) : (short) 0);
      this.interface29_0.imethod_32(meshFace.Corners.Count > 3 ? this.method_95(polyfaceMesh, meshFace.Corners[3]) : (short) 0);
      this.method_82((DxfHandledObject) meshFace);
      this.method_94((DxfEntity) null);
    }

    private void method_94(DxfEntity newOwner)
    {
      if (newOwner == null)
      {
        if (this.idxfHandledObject_0 == null)
          throw new Exception("entityOwner expected to be not null.");
      }
      else if (this.idxfHandledObject_0 != null)
        throw new Exception("entityOwner expected to be null.");
      this.idxfHandledObject_0 = (IDxfHandledObject) newOwner;
    }

    private short method_95(DxfPolyfaceMesh polyfaceMesh, DxfMeshFace.Corner corner)
    {
      short num = (short) (polyfaceMesh.Vertices.IndexOf(corner.Vertex) + 1);
      if (!corner.EdgeVisible)
        num = -num;
      return num;
    }

    private void Write(DxfPolyline2DBase parentEntity, DxfVertex2D vertex, Enum51 flags)
    {
      this.method_94((DxfEntity) parentEntity);
      this.method_73((DxfEntity) vertex);
      this.interface29_0.imethod_11((byte) (vertex.Flags | flags));
      this.interface29_0.imethod_16(vertex.Position.X);
      this.interface29_0.imethod_16(vertex.Position.Y);
      this.interface29_0.imethod_16(0.0);
      double num1 = vertex.StartWidth == 0.0 ? parentEntity.DefaultStartWidth : vertex.StartWidth;
      double num2 = vertex.EndWidth == 0.0 ? parentEntity.DefaultEndWidth : vertex.EndWidth;
      if (num1 != 0.0 && num2 == num1)
      {
        this.interface29_0.imethod_16(-num1);
      }
      else
      {
        this.interface29_0.imethod_16(num1);
        this.interface29_0.imethod_16(num2);
      }
      this.interface29_0.imethod_16(vertex.Bulge);
      if (this.dxfVersion_0 > DxfVersion.Dxf21)
        this.interface29_0.imethod_33(vertex.VertexId);
      this.interface29_0.imethod_16(vertex.TangentDirection);
      this.method_82((DxfHandledObject) vertex);
      this.method_94((DxfEntity) null);
    }

    private void Write(DxfEntity parentEntity, DxfVertex3D vertex, Enum51 flags)
    {
      this.method_94(parentEntity);
      this.method_73((DxfEntity) vertex);
      this.interface29_0.imethod_11((byte) flags);
      this.interface29_0.imethod_24(vertex.Position);
      this.method_82((DxfHandledObject) vertex);
      this.method_94((DxfEntity) null);
    }

    public void Visit(DxfMLeader mleader)
    {
      mleader.vmethod_7(this);
      this.method_82((DxfHandledObject) mleader);
    }

    public void Visit(DxfMLine mline)
    {
      this.method_73((DxfEntity) mline);
      this.interface29_0.imethod_16(mline.ScaleFactor);
      this.interface29_0.imethod_11((byte) mline.Alignment);
      this.interface29_0.imethod_24(mline.StartPoint);
      this.interface29_0.imethod_29(mline.ZAxis);
      this.interface29_0.imethod_32(mline.Closed ? (short) 3 : (short) 1);
      int num = 0;
      if (mline.Segments.Count > 0)
        num = mline.Segments[0].Elements.Count;
      this.interface29_0.imethod_11((byte) num);
      int count1 = mline.Segments.Count;
      this.interface29_0.imethod_32((short) count1);
      for (int index1 = 0; index1 < count1; ++index1)
      {
        DxfMLine.Segment segment = mline.Segments[index1];
        this.interface29_0.imethod_24(segment.Position);
        this.interface29_0.imethod_29(segment.Direction);
        this.interface29_0.imethod_29(segment.MiterDirection);
        for (int index2 = 0; index2 < num; ++index2)
        {
          DxfMLine.Segment.Element element = segment.Elements[index2];
          int count2 = element.Parameters.Count;
          this.interface29_0.imethod_32((short) count2);
          for (int index3 = 0; index3 < count2; ++index3)
            this.interface29_0.imethod_16(element.Parameters[index3]);
          int count3 = element.AreaFillParameters.Count;
          this.interface29_0.imethod_32((short) count3);
          for (int index3 = 0; index3 < count3; ++index3)
            this.interface29_0.imethod_16(element.AreaFillParameters[index3]);
        }
      }
      this.interface29_0.imethod_41((DxfHandledObject) mline.Style);
      this.method_82((DxfHandledObject) mline);
    }

    public void Visit(DxfMText mtext)
    {
      this.method_73((DxfEntity) mtext);
      this.interface29_0.imethod_24(mtext.InsertionPoint);
      this.interface29_0.imethod_29(mtext.ZAxis);
      this.interface29_0.imethod_29(mtext.XAxis);
      this.interface29_0.imethod_16(mtext.ReferenceRectangleWidth);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_16(mtext.ReferenceRectangleHeight);
      this.interface29_0.imethod_16(mtext.Height);
      this.interface29_0.imethod_32((short) mtext.AttachmentPoint);
      this.interface29_0.imethod_32((short) mtext.DrawingDirection);
      this.interface29_0.imethod_16(mtext.BoxHeight);
      this.interface29_0.imethod_16(mtext.BoxWidth);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(mtext.Text);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_32((short) mtext.LineSpacingStyle);
        this.interface29_0.imethod_16(mtext.LineSpacingFactor);
        this.interface29_0.imethod_14(false);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
      {
        this.interface29_0.imethod_33((int) mtext.BackgroundFillFlags);
        if ((mtext.BackgroundFillFlags & BackgroundFillFlags.UseBackgroundFillColor) != BackgroundFillFlags.None)
        {
          this.interface29_0.imethod_16(mtext.BackgroundFillInfo.BorderOffsetFactor);
          this.interface29_0.imethod_6(mtext.BackgroundFillInfo.Color);
          this.interface29_0.imethod_33((int) mtext.BackgroundFillInfo.Transparency.Data);
        }
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_4(mtext.Text);
      this.interface29_0.imethod_41((DxfHandledObject) mtext.Style);
      this.method_82((DxfHandledObject) mtext);
    }

    public void Visit(DxfPoint point)
    {
      this.method_73((DxfEntity) point);
      this.interface29_0.imethod_24(point.Position);
      this.interface29_0.imethod_1(point.Thickness);
      this.interface29_0.imethod_3(point.ZAxis);
      this.interface29_0.imethod_16(point.XAxisAngle);
      this.method_82((DxfHandledObject) point);
    }

    public void Visit(DxfPolyfaceMesh mesh)
    {
      this.method_73((DxfEntity) mesh);
      this.interface29_0.imethod_32((short) mesh.Vertices.Count);
      this.interface29_0.imethod_32((short) mesh.Faces.Count);
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
        this.interface29_0.imethod_33(mesh.Vertices.Count + mesh.Faces.Count);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf15)
      {
        DxfHandledObject handledObject1 = (DxfHandledObject) null;
        DxfHandledObject handledObject2 = (DxfHandledObject) null;
        if (mesh.Vertices.Count > 0)
        {
          handledObject1 = (DxfHandledObject) mesh.Vertices[0];
          handledObject2 = (DxfHandledObject) mesh.Vertices[mesh.Vertices.Count - 1];
        }
        if (mesh.Faces.Count > 0)
        {
          if (handledObject1 == null)
            handledObject1 = (DxfHandledObject) mesh.Faces[0];
          handledObject2 = (DxfHandledObject) mesh.Faces[mesh.Faces.Count - 1];
        }
        this.interface29_0.imethod_40(handledObject1);
        this.interface29_0.imethod_40(handledObject2);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
      {
        for (int index = 0; index < mesh.Vertices.Count; ++index)
          this.interface29_0.imethod_39((DxfHandledObject) mesh.Vertices[index]);
        for (int index = 0; index < mesh.Faces.Count; ++index)
          this.interface29_0.imethod_39((DxfHandledObject) mesh.Faces[index]);
      }
      this.interface29_0.imethod_39((DxfHandledObject) mesh.SeqEnd);
      this.method_82((DxfHandledObject) mesh);
      this.method_96(mesh);
    }

    private void method_96(DxfPolyfaceMesh mesh)
    {
      DxfEntity dxfEntity0 = this.dxfEntity_0;
      DxfEntity dxfEntity1 = this.dxfEntity_1;
      this.dxfEntity_0 = (DxfEntity) null;
      if (mesh.Vertices.Count > 0)
      {
        int count = mesh.Vertices.Count;
        DxfVertex3D vertex1 = mesh.Vertices[0];
        for (int index = 1; index < count; ++index)
        {
          DxfVertex3D vertex2 = mesh.Vertices[index];
          this.dxfEntity_1 = (DxfEntity) vertex2;
          this.Write((DxfEntity) mesh, vertex1, Enum51.flag_7 | Enum51.flag_8);
          this.dxfEntity_0 = (DxfEntity) vertex1;
          vertex1 = vertex2;
        }
        this.dxfEntity_1 = mesh.Faces.Count <= 0 ? (DxfEntity) null : (DxfEntity) mesh.Faces[0];
        this.Write((DxfEntity) mesh, vertex1, Enum51.flag_7 | Enum51.flag_8);
        this.dxfEntity_0 = (DxfEntity) vertex1;
      }
      if (mesh.Faces.Count > 0)
      {
        int count = mesh.Faces.Count;
        DxfMeshFace meshFace = mesh.Faces[0];
        for (int index = 1; index < count; ++index)
        {
          DxfMeshFace face = mesh.Faces[index];
          this.dxfEntity_1 = (DxfEntity) face;
          this.Write(mesh, meshFace);
          this.dxfEntity_0 = (DxfEntity) meshFace;
          meshFace = face;
        }
        this.dxfEntity_1 = (DxfEntity) null;
        this.Write(mesh, meshFace);
      }
      this.Write(mesh.SeqEnd);
      this.dxfEntity_0 = dxfEntity0;
      this.dxfEntity_1 = dxfEntity1;
    }

    public void Visit(DxfPolygonMesh mesh)
    {
      this.method_73((DxfEntity) mesh);
      this.interface29_0.imethod_32((short) (Enum21.flag_5 | mesh.Flags));
      this.interface29_0.imethod_32((short) 0);
      this.interface29_0.imethod_32((short) mesh.MVertexCount);
      this.interface29_0.imethod_32((short) mesh.NVertexCount);
      this.interface29_0.imethod_32((short) 0);
      this.interface29_0.imethod_32((short) 0);
      int count = mesh.Vertices.Count;
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
        this.interface29_0.imethod_33(count);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf15)
      {
        DxfVertex3D dxfVertex3D1 = (DxfVertex3D) null;
        DxfVertex3D dxfVertex3D2 = (DxfVertex3D) null;
        if (mesh.Vertices.Count > 0)
        {
          dxfVertex3D1 = mesh.Vertices[0];
          dxfVertex3D2 = mesh.Vertices[mesh.Vertices.Count - 1];
        }
        this.interface29_0.imethod_40((DxfHandledObject) dxfVertex3D1);
        this.interface29_0.imethod_40((DxfHandledObject) dxfVertex3D2);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
      {
        foreach (DxfHandledObject vertex in (IEnumerable<DxfVertex3D>) mesh.Vertices)
          this.interface29_0.imethod_39(vertex);
      }
      this.interface29_0.imethod_39((DxfHandledObject) mesh.SeqEnd);
      this.method_82((DxfHandledObject) mesh);
      this.method_97(mesh);
    }

    private void method_97(DxfPolygonMesh mesh)
    {
      DxfEntity dxfEntity0 = this.dxfEntity_0;
      DxfEntity dxfEntity1 = this.dxfEntity_1;
      this.dxfEntity_0 = (DxfEntity) null;
      this.dxfEntity_1 = (DxfEntity) null;
      DxfEntity dxfEntity = (DxfEntity) null;
      Enum51 flags = Enum51.flag_7;
      foreach (DxfEntity vertex in (IEnumerable<DxfVertex3D>) mesh.Vertices)
      {
        this.dxfEntity_1 = vertex;
        if (dxfEntity != null)
          this.Write((DxfEntity) mesh, (DxfVertex3D) dxfEntity, flags);
        this.dxfEntity_0 = dxfEntity;
        dxfEntity = this.dxfEntity_1;
      }
      if (dxfEntity != null)
      {
        this.dxfEntity_1 = (DxfEntity) null;
        this.Write((DxfEntity) mesh, (DxfVertex3D) dxfEntity, flags);
      }
      this.Write(mesh.SeqEnd);
      this.dxfEntity_0 = dxfEntity0;
      this.dxfEntity_1 = dxfEntity1;
    }

    public void Visit(DxfPolygonSplineMesh mesh)
    {
      this.method_73((DxfEntity) mesh);
      this.interface29_0.imethod_32((short) (Enum21.flag_3 | Enum21.flag_5 | mesh.Flags));
      this.interface29_0.imethod_32((short) mesh.SplineType);
      this.interface29_0.imethod_32((short) mesh.MControlPointCount);
      this.interface29_0.imethod_32((short) mesh.NControlPointCount);
      this.interface29_0.imethod_32((short) mesh.SmoothSurfaceMDensity);
      this.interface29_0.imethod_32((short) mesh.SmoothSurfaceNDensity);
      int num = mesh.ControlPoints.Count + mesh.ApproximationPoints.Count;
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
        this.interface29_0.imethod_33(num);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf15)
      {
        DxfVertex3D dxfVertex3D1 = (DxfVertex3D) null;
        DxfVertex3D dxfVertex3D2 = (DxfVertex3D) null;
        if (mesh.ControlPoints.Count > 0)
        {
          dxfVertex3D1 = mesh.ControlPoints[0];
          dxfVertex3D2 = mesh.ControlPoints[mesh.ControlPoints.Count - 1];
        }
        if (mesh.ApproximationPoints.Count > 0)
        {
          if (dxfVertex3D1 == null)
            dxfVertex3D1 = mesh.ApproximationPoints[0];
          if (dxfVertex3D2 == null)
            dxfVertex3D2 = mesh.ApproximationPoints[mesh.ApproximationPoints.Count - 1];
        }
        this.interface29_0.imethod_40((DxfHandledObject) dxfVertex3D1);
        this.interface29_0.imethod_40((DxfHandledObject) dxfVertex3D2);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
      {
        foreach (DxfHandledObject controlPoint in (IEnumerable<DxfVertex3D>) mesh.ControlPoints)
          this.interface29_0.imethod_39(controlPoint);
        foreach (DxfHandledObject approximationPoint in (IEnumerable<DxfVertex3D>) mesh.ApproximationPoints)
          this.interface29_0.imethod_39(approximationPoint);
      }
      this.interface29_0.imethod_39((DxfHandledObject) mesh.SeqEnd);
      this.method_82((DxfHandledObject) mesh);
      this.method_98(mesh);
    }

    private void method_98(DxfPolygonSplineMesh mesh)
    {
      DxfEntity dxfEntity0 = this.dxfEntity_0;
      DxfEntity dxfEntity1 = this.dxfEntity_1;
      this.dxfEntity_0 = (DxfEntity) null;
      this.dxfEntity_1 = (DxfEntity) null;
      if (mesh.ControlPoints.Count > 0)
      {
        DxfEntity controlPoint = (DxfEntity) mesh.ControlPoints[0];
        if (mesh.ApproximationPoints.Count > 0)
          this.dxfEntity_1 = (DxfEntity) mesh.ApproximationPoints[0];
        else if (mesh.ControlPoints.Count > 1)
          this.dxfEntity_1 = (DxfEntity) mesh.ControlPoints[1];
        this.Write((DxfEntity) mesh, (DxfVertex3D) controlPoint, Enum51.flag_5 | Enum51.flag_7);
        this.dxfEntity_0 = controlPoint;
      }
      DxfEntity dxfEntity2 = (DxfEntity) null;
      Enum51 flags1 = Enum51.flag_4 | Enum51.flag_7;
      bool flag = true;
      foreach (DxfEntity approximationPoint in (IEnumerable<DxfVertex3D>) mesh.ApproximationPoints)
      {
        this.dxfEntity_1 = approximationPoint;
        if (flag)
        {
          flag = false;
        }
        else
        {
          this.Write((DxfEntity) mesh, (DxfVertex3D) dxfEntity2, flags1);
          this.dxfEntity_0 = dxfEntity2;
        }
        dxfEntity2 = this.dxfEntity_1;
      }
      if (dxfEntity2 != null)
      {
        this.dxfEntity_1 = mesh.ControlPoints.Count <= 1 ? (DxfEntity) null : (DxfEntity) mesh.ControlPoints[1];
        this.Write((DxfEntity) mesh, (DxfVertex3D) dxfEntity2, flags1);
        this.dxfEntity_0 = dxfEntity2;
      }
      DxfEntity dxfEntity3 = (DxfEntity) null;
      Enum51 flags2 = Enum51.flag_5 | Enum51.flag_7;
      int num = 0;
      foreach (DxfVertex3D controlPoint in (IEnumerable<DxfVertex3D>) mesh.ControlPoints)
      {
        if (num > 0)
        {
          this.dxfEntity_1 = (DxfEntity) controlPoint;
          if (num > 1)
          {
            this.Write((DxfEntity) mesh, (DxfVertex3D) dxfEntity3, flags2);
            this.dxfEntity_0 = dxfEntity3;
          }
          dxfEntity3 = this.dxfEntity_1;
        }
        ++num;
      }
      if (dxfEntity3 != null)
      {
        this.dxfEntity_1 = (DxfEntity) null;
        this.Write((DxfEntity) mesh, (DxfVertex3D) dxfEntity3, flags2);
      }
      this.Write(mesh.SeqEnd);
      this.dxfEntity_0 = dxfEntity0;
      this.dxfEntity_1 = dxfEntity1;
    }

    public void Visit(DxfPolyline2D polyline)
    {
      this.method_73((DxfEntity) polyline);
      this.interface29_0.imethod_32((short) polyline.Flags);
      this.interface29_0.imethod_32((short) 0);
      this.interface29_0.imethod_16(polyline.DefaultStartWidth);
      this.interface29_0.imethod_16(polyline.DefaultEndWidth);
      this.interface29_0.imethod_1(polyline.Thickness);
      this.interface29_0.imethod_16(polyline.Elevation);
      this.interface29_0.imethod_3(polyline.ZAxis);
      int count = polyline.Vertices.Count;
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
        this.interface29_0.imethod_33(count);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf15)
      {
        DxfVertex2D dxfVertex2D1 = (DxfVertex2D) null;
        DxfVertex2D dxfVertex2D2 = (DxfVertex2D) null;
        if (polyline.Vertices.Count > 0)
        {
          dxfVertex2D1 = polyline.Vertices[0];
          dxfVertex2D2 = polyline.Vertices[polyline.Vertices.Count - 1];
        }
        this.interface29_0.imethod_40((DxfHandledObject) dxfVertex2D1);
        this.interface29_0.imethod_40((DxfHandledObject) dxfVertex2D2);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
      {
        for (int index = 0; index < count; ++index)
          this.interface29_0.imethod_39((DxfHandledObject) polyline.Vertices[index]);
      }
      this.interface29_0.imethod_39((DxfHandledObject) polyline.SeqEnd);
      this.method_82((DxfHandledObject) polyline);
      this.method_99(polyline);
    }

    private void method_99(DxfPolyline2D polyline)
    {
      int count = polyline.Vertices.Count;
      if (count > 0)
      {
        DxfEntity dxfEntity0 = this.dxfEntity_0;
        DxfEntity dxfEntity1 = this.dxfEntity_1;
        this.dxfEntity_0 = (DxfEntity) null;
        this.dxfEntity_1 = (DxfEntity) null;
        DxfEntity dxfEntity = (DxfEntity) polyline.Vertices[0];
        for (int index = 1; index < count; ++index)
        {
          this.dxfEntity_1 = (DxfEntity) polyline.Vertices[index];
          this.Write((DxfPolyline2DBase) polyline, (DxfVertex2D) dxfEntity, Enum51.flag_0);
          this.dxfEntity_0 = dxfEntity;
          dxfEntity = this.dxfEntity_1;
        }
        if (dxfEntity != null)
        {
          this.dxfEntity_1 = (DxfEntity) null;
          this.Write((DxfPolyline2DBase) polyline, (DxfVertex2D) dxfEntity, Enum51.flag_0);
        }
        this.dxfEntity_0 = dxfEntity0;
        this.dxfEntity_1 = dxfEntity1;
      }
      this.Write(polyline.SeqEnd);
    }

    public void Visit(DxfPolyline2DSpline polyline)
    {
      this.method_73((DxfEntity) polyline);
      this.interface29_0.imethod_32((short) polyline.Flags);
      this.interface29_0.imethod_32((short) polyline.SplineType);
      this.interface29_0.imethod_16(polyline.DefaultStartWidth);
      this.interface29_0.imethod_16(polyline.DefaultEndWidth);
      this.interface29_0.imethod_1(polyline.Thickness);
      this.interface29_0.imethod_16(polyline.Elevation);
      this.interface29_0.imethod_3(polyline.ZAxis);
      int num = polyline.ControlPoints.Count + polyline.ApproximationPoints.Count;
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
        this.interface29_0.imethod_33(num);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf15)
      {
        DxfVertex2D dxfVertex2D1 = (DxfVertex2D) null;
        DxfVertex2D dxfVertex2D2 = (DxfVertex2D) null;
        if (polyline.ControlPoints.Count > 0)
        {
          dxfVertex2D1 = polyline.ControlPoints[0];
          dxfVertex2D2 = polyline.ControlPoints[polyline.ControlPoints.Count - 1];
        }
        if (polyline.ApproximationPoints.Count > 0)
        {
          if (dxfVertex2D1 == null)
            dxfVertex2D1 = polyline.ApproximationPoints[0];
          if (dxfVertex2D2 == null)
            dxfVertex2D2 = polyline.ApproximationPoints[polyline.ApproximationPoints.Count - 1];
        }
        this.interface29_0.imethod_40((DxfHandledObject) dxfVertex2D1);
        this.interface29_0.imethod_40((DxfHandledObject) dxfVertex2D2);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
      {
        foreach (DxfHandledObject controlPoint in (DxfHandledObjectCollection<DxfVertex2D>) polyline.ControlPoints)
          this.interface29_0.imethod_39(controlPoint);
        foreach (DxfHandledObject approximationPoint in (DxfHandledObjectCollection<DxfVertex2D>) polyline.ApproximationPoints)
          this.interface29_0.imethod_39(approximationPoint);
      }
      this.interface29_0.imethod_39((DxfHandledObject) polyline.SeqEnd);
      this.method_82((DxfHandledObject) polyline);
      this.method_100(polyline);
    }

    private void method_100(DxfPolyline2DSpline polyline)
    {
      DxfEntity dxfEntity0 = this.dxfEntity_0;
      DxfEntity dxfEntity1_1 = this.dxfEntity_1;
      this.dxfEntity_0 = (DxfEntity) null;
      this.dxfEntity_1 = (DxfEntity) null;
      if (polyline.ControlPoints.Count > 0)
      {
        DxfEntity controlPoint = (DxfEntity) polyline.ControlPoints[0];
        this.dxfEntity_1 = polyline.ApproximationPoints.Count <= 0 ? (polyline.ControlPoints.Count <= 1 ? (DxfEntity) null : (DxfEntity) polyline.ControlPoints[1]) : (DxfEntity) polyline.ApproximationPoints[0];
        this.Write((DxfPolyline2DBase) polyline, (DxfVertex2D) controlPoint, Enum51.flag_5);
        this.dxfEntity_0 = controlPoint;
      }
      else if (polyline.ApproximationPoints.Count > 0)
        this.dxfEntity_1 = (DxfEntity) polyline.ApproximationPoints[0];
      int count1 = polyline.ApproximationPoints.Count;
      if (count1 > 0)
      {
        DxfEntity dxfEntity1_2 = this.dxfEntity_1;
        for (int index = 1; index < count1; ++index)
        {
          this.dxfEntity_1 = (DxfEntity) polyline.ApproximationPoints[index];
          this.Write((DxfPolyline2DBase) polyline, (DxfVertex2D) dxfEntity1_2, Enum51.flag_4);
          this.dxfEntity_0 = dxfEntity1_2;
          dxfEntity1_2 = this.dxfEntity_1;
        }
        if (dxfEntity1_2 != null)
        {
          this.dxfEntity_1 = polyline.ControlPoints.Count <= 1 ? (DxfEntity) null : (DxfEntity) polyline.ControlPoints[1];
          this.Write((DxfPolyline2DBase) polyline, (DxfVertex2D) dxfEntity1_2, Enum51.flag_4);
        }
        this.dxfEntity_0 = dxfEntity1_2;
      }
      int count2 = polyline.ControlPoints.Count;
      if (count2 > 1)
      {
        DxfEntity dxfEntity1_2 = this.dxfEntity_1;
        for (int index = 2; index < count2; ++index)
        {
          this.dxfEntity_1 = (DxfEntity) polyline.ControlPoints[index];
          this.Write((DxfPolyline2DBase) polyline, (DxfVertex2D) dxfEntity1_2, Enum51.flag_5);
          this.dxfEntity_0 = dxfEntity1_2;
          dxfEntity1_2 = this.dxfEntity_1;
        }
        if (dxfEntity1_2 != null)
        {
          this.dxfEntity_1 = (DxfEntity) null;
          this.Write((DxfPolyline2DBase) polyline, (DxfVertex2D) dxfEntity1_2, Enum51.flag_5);
        }
      }
      this.Write(polyline.SeqEnd);
      this.dxfEntity_0 = dxfEntity0;
      this.dxfEntity_1 = dxfEntity1_1;
    }

    public void Visit(DxfPolyline3D polyline)
    {
      this.method_73((DxfEntity) polyline);
      this.interface29_0.imethod_11((byte) 0);
      this.interface29_0.imethod_11(polyline.Closed ? (byte) 1 : (byte) 0);
      int count = polyline.Vertices.Count;
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
        this.interface29_0.imethod_33(count);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf15)
      {
        DxfVertex3D dxfVertex3D1 = (DxfVertex3D) null;
        DxfVertex3D dxfVertex3D2 = (DxfVertex3D) null;
        if (polyline.Vertices.Count > 0)
        {
          dxfVertex3D1 = polyline.Vertices[0];
          dxfVertex3D2 = polyline.Vertices[polyline.Vertices.Count - 1];
        }
        this.interface29_0.imethod_40((DxfHandledObject) dxfVertex3D1);
        this.interface29_0.imethod_40((DxfHandledObject) dxfVertex3D2);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
      {
        foreach (DxfHandledObject vertex in (DxfHandledObjectCollection<DxfVertex3D>) polyline.Vertices)
          this.interface29_0.imethod_39(vertex);
      }
      this.interface29_0.imethod_39((DxfHandledObject) polyline.SeqEnd);
      this.method_82((DxfHandledObject) polyline);
      this.method_101(polyline);
    }

    private void method_101(DxfPolyline3D polyline)
    {
      int count = polyline.Vertices.Count;
      if (count > 0)
      {
        DxfEntity dxfEntity0 = this.dxfEntity_0;
        DxfEntity dxfEntity1 = this.dxfEntity_1;
        this.dxfEntity_0 = (DxfEntity) null;
        this.dxfEntity_1 = (DxfEntity) null;
        DxfEntity dxfEntity = (DxfEntity) polyline.Vertices[0];
        for (int index = 1; index < count; ++index)
        {
          this.dxfEntity_1 = (DxfEntity) polyline.Vertices[index];
          this.Write((DxfEntity) polyline, (DxfVertex3D) dxfEntity, Enum51.flag_0);
          this.dxfEntity_0 = dxfEntity;
          dxfEntity = this.dxfEntity_1;
        }
        if (dxfEntity != null)
        {
          this.dxfEntity_1 = (DxfEntity) null;
          this.Write((DxfEntity) polyline, (DxfVertex3D) dxfEntity, Enum51.flag_0);
        }
        this.dxfEntity_0 = dxfEntity0;
        this.dxfEntity_1 = dxfEntity1;
      }
      this.Write(polyline.SeqEnd);
    }

    public void Visit(DxfPolyline3DSpline polyline)
    {
      this.method_73((DxfEntity) polyline);
      this.interface29_0.imethod_11((byte) polyline.SplineType);
      this.interface29_0.imethod_11(polyline.Closed ? (byte) 1 : (byte) 0);
      int num = polyline.ControlPoints.Count + polyline.ApproximationPoints.Count;
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
        this.interface29_0.imethod_33(num);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf15)
      {
        DxfVertex3D dxfVertex3D1 = (DxfVertex3D) null;
        DxfVertex3D dxfVertex3D2 = (DxfVertex3D) null;
        if (polyline.ControlPoints.Count > 0)
        {
          dxfVertex3D1 = polyline.ControlPoints[0];
          dxfVertex3D2 = polyline.ControlPoints[polyline.ControlPoints.Count - 1];
        }
        if (polyline.ApproximationPoints.Count > 0)
        {
          if (dxfVertex3D1 == null)
            dxfVertex3D1 = polyline.ApproximationPoints[0];
          if (dxfVertex3D2 == null)
            dxfVertex3D2 = polyline.ApproximationPoints[polyline.ApproximationPoints.Count - 1];
        }
        this.interface29_0.imethod_40((DxfHandledObject) dxfVertex3D1);
        this.interface29_0.imethod_40((DxfHandledObject) dxfVertex3D2);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
      {
        foreach (DxfHandledObject controlPoint in (DxfHandledObjectCollection<DxfVertex3D>) polyline.ControlPoints)
          this.interface29_0.imethod_39(controlPoint);
        foreach (DxfHandledObject approximationPoint in (DxfHandledObjectCollection<DxfVertex3D>) polyline.ApproximationPoints)
          this.interface29_0.imethod_39(approximationPoint);
      }
      this.interface29_0.imethod_39((DxfHandledObject) polyline.SeqEnd);
      this.method_82((DxfHandledObject) polyline);
      this.method_102(polyline);
    }

    private void method_102(DxfPolyline3DSpline polyline)
    {
      DxfEntity dxfEntity0 = this.dxfEntity_0;
      DxfEntity dxfEntity1_1 = this.dxfEntity_1;
      this.dxfEntity_0 = (DxfEntity) null;
      this.dxfEntity_1 = (DxfEntity) null;
      if (polyline.ControlPoints.Count > 0)
      {
        DxfEntity controlPoint = (DxfEntity) polyline.ControlPoints[0];
        this.dxfEntity_1 = polyline.ApproximationPoints.Count <= 0 ? (polyline.ControlPoints.Count <= 1 ? (DxfEntity) null : (DxfEntity) polyline.ControlPoints[1]) : (DxfEntity) polyline.ApproximationPoints[0];
        this.Write((DxfEntity) polyline, (DxfVertex3D) controlPoint, Enum51.flag_5);
        this.dxfEntity_0 = controlPoint;
      }
      int count1 = polyline.ApproximationPoints.Count;
      if (count1 > 0)
      {
        DxfEntity dxfEntity1_2 = this.dxfEntity_1;
        for (int index = 1; index < count1; ++index)
        {
          this.dxfEntity_1 = (DxfEntity) polyline.ApproximationPoints[index];
          this.Write((DxfEntity) polyline, (DxfVertex3D) dxfEntity1_2, Enum51.flag_4);
          this.dxfEntity_0 = dxfEntity1_2;
          dxfEntity1_2 = this.dxfEntity_1;
        }
        if (dxfEntity1_2 != null)
        {
          this.dxfEntity_1 = polyline.ControlPoints.Count <= 1 ? (DxfEntity) null : (DxfEntity) polyline.ControlPoints[1];
          this.Write((DxfEntity) polyline, (DxfVertex3D) dxfEntity1_2, Enum51.flag_4);
        }
        this.dxfEntity_0 = dxfEntity1_2;
      }
      int count2 = polyline.ControlPoints.Count;
      if (count2 > 1)
      {
        DxfEntity dxfEntity1_2 = this.dxfEntity_1;
        for (int index = 2; index < count2; ++index)
        {
          this.dxfEntity_1 = (DxfEntity) polyline.ControlPoints[index];
          this.Write((DxfEntity) polyline, (DxfVertex3D) dxfEntity1_2, Enum51.flag_5);
          this.dxfEntity_0 = dxfEntity1_2;
          dxfEntity1_2 = this.dxfEntity_1;
        }
        if (dxfEntity1_2 != null)
        {
          this.dxfEntity_1 = (DxfEntity) null;
          this.Write((DxfEntity) polyline, (DxfVertex3D) dxfEntity1_2, Enum51.flag_5);
        }
      }
      this.Write(polyline.SeqEnd);
      this.dxfEntity_0 = dxfEntity0;
      this.dxfEntity_1 = dxfEntity1_1;
    }

    public void Visit(DxfImage image)
    {
      this.method_73((DxfEntity) image);
      this.interface29_0.imethod_33(image.ClassVersion);
      this.interface29_0.imethod_24(image.InsertionPoint);
      this.interface29_0.imethod_29(image.XAxis);
      this.interface29_0.imethod_29(image.YAxis);
      this.interface29_0.imethod_20(image.Size.X);
      this.interface29_0.imethod_20(image.Size.Y);
      this.interface29_0.imethod_32((short) image.ImageDisplayFlags);
      this.interface29_0.imethod_14(image.ClippingEnabled);
      this.interface29_0.imethod_11(image.Brightness);
      this.interface29_0.imethod_11(image.Contrast);
      this.interface29_0.imethod_11(image.Fade);
      if (this.dxfVersion_0 > DxfVersion.Dxf21)
        this.interface29_0.imethod_14(image.ClipMode == ClipMode.Inside);
      short num = 1;
      if (image.BoundaryVertices.Count > 2)
        num = (short) 2;
      this.interface29_0.imethod_32(num);
      if (num == (short) 1)
      {
        this.interface29_0.imethod_25(image.BoundaryVertices[0]);
        this.interface29_0.imethod_25(image.BoundaryVertices[1]);
      }
      else
      {
        this.interface29_0.imethod_33(image.BoundaryVertices.Count);
        for (int index = 0; index < image.BoundaryVertices.Count; ++index)
          this.interface29_0.imethod_25(image.BoundaryVertices[index]);
      }
      this.interface29_0.imethod_41((DxfHandledObject) image.ImageDef);
      this.interface29_0.imethod_39((DxfHandledObject) null);
      this.method_82((DxfHandledObject) image);
    }

    public void Visit(DxfWipeout image)
    {
      this.method_73((DxfEntity) image);
      this.interface29_0.imethod_33(image.ClassVersion);
      this.interface29_0.imethod_24(image.InsertionPoint);
      this.interface29_0.imethod_29(image.XAxis);
      this.interface29_0.imethod_29(image.YAxis);
      this.interface29_0.imethod_20(image.Size.X);
      this.interface29_0.imethod_20(image.Size.Y);
      this.interface29_0.imethod_32((short) image.ImageDisplayFlags);
      this.interface29_0.imethod_14(image.ClippingEnabled);
      this.interface29_0.imethod_11(image.Brightness);
      this.interface29_0.imethod_11(image.Contrast);
      this.interface29_0.imethod_11(image.Fade);
      if (this.dxfVersion_0 > DxfVersion.Dxf21)
        this.interface29_0.imethod_14(image.ClipMode == ClipMode.Inside);
      short num = 1;
      if (image.BoundaryVertices.Count > 2)
        num = (short) 2;
      this.interface29_0.imethod_32(num);
      if (num == (short) 1)
      {
        this.interface29_0.imethod_25(image.BoundaryVertices[0]);
        this.interface29_0.imethod_25(image.BoundaryVertices[1]);
      }
      else
      {
        this.interface29_0.imethod_33(image.BoundaryVertices.Count);
        for (int index = 0; index < image.BoundaryVertices.Count; ++index)
          this.interface29_0.imethod_25(image.BoundaryVertices[index]);
      }
      this.interface29_0.imethod_41((DxfHandledObject) image.ImageDef);
      this.interface29_0.imethod_39((DxfHandledObject) null);
      this.method_82((DxfHandledObject) image);
    }

    public void Visit(DxfRay ray)
    {
      this.method_73((DxfEntity) ray);
      this.interface29_0.imethod_24(ray.StartPoint);
      this.interface29_0.imethod_29(ray.Direction);
      this.method_82((DxfHandledObject) ray);
    }

    private void method_103(DxfModelerGeometry.DxfModelerGuid guid)
    {
      byte[] byteArray = guid.Guid.ToByteArray();
      this.interface29_0.imethod_33(BitConverter.ToInt32(byteArray, 0));
      this.interface29_0.imethod_32(BitConverter.ToInt16(byteArray, 4));
      this.interface29_0.imethod_32(BitConverter.ToInt16(byteArray, 6));
      this.interface29_0.imethod_11(byteArray[8]);
      this.interface29_0.imethod_11(byteArray[9]);
      this.interface29_0.imethod_11(byteArray[10]);
      this.interface29_0.imethod_11(byteArray[11]);
      this.interface29_0.imethod_11(byteArray[12]);
      this.interface29_0.imethod_11(byteArray[13]);
      this.interface29_0.imethod_11(byteArray[14]);
      this.interface29_0.imethod_11(byteArray[15]);
    }

    private void method_104(DxfModelerGeometry common)
    {
      bool flag1;
      if (!(flag1 = this.dxfVersion_0 >= DxfVersion.Dxf27))
      {
        this.interface29_0.imethod_14(false);
        short num = this.dxfVersion_0 <= DxfVersion.Dxf15 ? (short) 1 : (short) 2;
        bool flag2;
        if (!(flag2 = num == (short) 1) && common.SatText.Length != 0)
        {
          flag2 = true;
          num = (short) 1;
        }
        if (flag2 && common.SatText.Length == 0 || !flag2 && common.SabStream == null)
          throw new Exception("Region : converstion between SAB and SAT is not implemented.");
        this.interface29_0.imethod_14(flag2);
        this.interface29_0.imethod_32(num);
        switch (num)
        {
          case 1:
            this.method_43(common.SatText);
            break;
          case 2:
            this.interface29_0.imethod_12(DxfModelerGeometry.BinaryFilePrefix);
            this.interface29_0.imethod_12(common.SabStream.ToArray());
            break;
        }
      }
      this.interface29_0.imethod_14(false);
      if (this.dxfVersion_0 > DxfVersion.Dxf18)
      {
        int count = common.Materials.Count;
        this.interface29_0.imethod_33(count);
        for (int index = 0; index < count; ++index)
        {
          this.interface29_0.imethod_33(common.Materials[index].MaterialIdLow);
          this.interface29_0.imethod_33(common.Materials[index].MaterialIdHigh);
        }
      }
      if (!flag1)
        return;
      this.interface29_0.imethod_14(false);
      this.method_103(DxfModelerGeometry.DxfModelerGuid.Empty);
      this.interface29_0.imethod_33(0);
    }

    public void Visit(Dxf3DSolid solid)
    {
      this.method_73((DxfEntity) solid);
      this.method_104((DxfModelerGeometry) solid);
      if (this.dxfVersion_0 > DxfVersion.Dxf18)
        this.interface29_0.imethod_43(new ReferenceType?(ReferenceType.HardOwnershipReference), solid.HistoryId);
      this.method_82((DxfHandledObject) solid);
    }

    public void Visit(DxfRegion region)
    {
      this.method_73((DxfEntity) region);
      this.method_104((DxfModelerGeometry) region);
      this.method_82((DxfHandledObject) region);
    }

    public void Visit(DxfBody body)
    {
      this.method_73((DxfEntity) body);
      this.method_104((DxfModelerGeometry) body);
      this.method_82((DxfHandledObject) body);
    }

    public void Visit(DxfSequenceEnd sequenceEnd)
    {
      throw new InternalException("The sequence end entity may only exist in context of a parent entity.");
    }

    private void Write(DxfSequenceEnd sequenceEnd)
    {
      DxfEntity dxfEntity0 = this.dxfEntity_0;
      DxfEntity dxfEntity1 = this.dxfEntity_1;
      this.dxfEntity_0 = (DxfEntity) null;
      this.dxfEntity_1 = (DxfEntity) null;
      this.method_73((DxfEntity) sequenceEnd);
      this.method_82((DxfHandledObject) sequenceEnd);
      this.dxfEntity_0 = dxfEntity0;
      this.dxfEntity_1 = dxfEntity1;
    }

    public void Visit(DxfShape shape)
    {
      this.method_73((DxfEntity) shape);
      this.interface29_0.imethod_24(shape.InsertionPoint);
      this.interface29_0.imethod_16(shape.ScaleFactor);
      this.interface29_0.imethod_16(shape.Rotation);
      this.interface29_0.imethod_16(shape.RelativeXScaleFactor);
      this.interface29_0.imethod_16(shape.ObliqueAngle);
      this.interface29_0.imethod_16(shape.Thickness);
      this.interface29_0.imethod_32((short) shape.ShapeIndex);
      this.interface29_0.imethod_2(shape.ZAxis);
      this.interface29_0.imethod_41((DxfHandledObject) shape.TextStyle);
      this.method_82((DxfHandledObject) shape);
    }

    public void Visit(DxfSolid solid)
    {
      this.method_73((DxfEntity) solid);
      this.interface29_0.imethod_1(solid.Thickness);
      this.interface29_0.imethod_16(solid.Points[0].Z);
      WW.Math.Point3D point1 = solid.Points[0];
      this.interface29_0.imethod_20(point1.X);
      this.interface29_0.imethod_20(point1.Y);
      WW.Math.Point3D point2 = solid.Points[1];
      this.interface29_0.imethod_20(point2.X);
      this.interface29_0.imethod_20(point2.Y);
      WW.Math.Point3D point3 = solid.Points[2];
      this.interface29_0.imethod_20(point3.X);
      this.interface29_0.imethod_20(point3.Y);
      WW.Math.Point3D point4 = solid.Points[3];
      this.interface29_0.imethod_20(point4.X);
      this.interface29_0.imethod_20(point4.Y);
      this.interface29_0.imethod_3(solid.ZAxis);
      this.method_82((DxfHandledObject) solid);
    }

    public void Visit(DxfSpline spline)
    {
      this.method_73((DxfEntity) spline);
      int num = spline.ControlPoints.Count != 0 ? 1 : 2;
      if (this.dxfVersion_0 > DxfVersion.Dxf24)
      {
        if (spline.KnotParameterization != KnotParameterization.Custom && spline.FitPoints.Count != 0)
        {
          num = 2;
          spline.Flags1 |= SplineFlags1.MethodFitPoints | SplineFlags1.UseKnotParameter;
        }
        else
        {
          num = 1;
          spline.KnotParameterization = KnotParameterization.Custom;
          spline.Flags1 &= ~SplineFlags1.UseKnotParameter;
        }
        this.interface29_0.imethod_33(num);
        this.interface29_0.imethod_33((int) spline.Flags1);
        this.interface29_0.imethod_33((int) spline.KnotParameterization);
      }
      else
        this.interface29_0.imethod_33(num);
      this.interface29_0.imethod_33(spline.Degree);
      bool flag = spline.Weights.Count > 0;
      switch (num)
      {
        case 1:
          this.interface29_0.imethod_14(spline.Rational);
          this.interface29_0.imethod_14(spline.Closed);
          this.interface29_0.imethod_14(spline.IsPeriodic);
          this.interface29_0.imethod_16(spline.KnotTolerance);
          this.interface29_0.imethod_16(spline.ControlPointTolerance);
          this.interface29_0.imethod_33(spline.Knots.Count);
          this.interface29_0.imethod_33(spline.ControlPoints.Count);
          this.interface29_0.imethod_14(flag);
          int count1 = spline.Knots.Count;
          for (int index = 0; index < count1; ++index)
            this.interface29_0.imethod_16(spline.Knots[index]);
          int count2 = spline.ControlPoints.Count;
          for (int index = 0; index < count2; ++index)
          {
            this.interface29_0.imethod_24(spline.ControlPoints[index]);
            if (flag)
              this.interface29_0.imethod_16(spline.Weights[index]);
          }
          break;
        case 2:
          this.interface29_0.imethod_16(spline.FitTolerance);
          this.interface29_0.imethod_29(spline.StartTangent);
          this.interface29_0.imethod_29(spline.EndTangent);
          this.interface29_0.imethod_33(spline.FitPoints.Count);
          int count3 = spline.FitPoints.Count;
          for (int index = 0; index < count3; ++index)
            this.interface29_0.imethod_24(spline.FitPoints[index]);
          break;
      }
      this.method_82((DxfHandledObject) spline);
    }

    public void Visit(DxfTable table)
    {
      this.method_92((DxfInsertBase) table);
      this.method_93((DxfInsertBase) table);
      if (this.dxfVersion_0 > DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_11(table.Unknown0);
        this.interface29_0.imethod_40((DxfHandledObject) null);
        this.interface29_0.imethod_33(table.Unknown2);
        if (this.dxfVersion_0 > DxfVersion.Dxf24)
          this.interface29_0.imethod_33(table.Unknown5);
        else
          this.interface29_0.imethod_14(table.Unknown3);
        this.method_105(table.Content);
        this.interface29_0.imethod_32(table.Unknown4);
        this.interface29_0.imethod_29(table.HorizontalDirection);
        this.interface29_0.imethod_33(table.BreakData.Flags);
        if (table.BreakData.Flags != 0)
        {
          this.interface29_0.imethod_33((int) table.BreakData.OptionFlags);
          this.interface29_0.imethod_33((int) table.BreakData.FlowDirection);
          this.interface29_0.imethod_16(table.BreakData.BreakSpacing);
          this.interface29_0.imethod_33(table.BreakData.UnknownFlags1);
          this.interface29_0.imethod_33(table.BreakData.UnknownFlags2);
          this.interface29_0.imethod_33(table.BreakData.BreakHeights.Count);
          foreach (DxfTableBreakHeight breakHeight in (IEnumerable<DxfTableBreakHeight>) table.BreakData.BreakHeights)
          {
            this.interface29_0.imethod_24(breakHeight.Position);
            this.interface29_0.imethod_16(breakHeight.Height);
            this.interface29_0.imethod_33(breakHeight.Flags);
          }
        }
        this.interface29_0.imethod_33(table.BreakData.RowRanges.Count);
        foreach (DxfTableBreakRowRange rowRange in (IEnumerable<DxfTableBreakRowRange>) table.BreakData.RowRanges)
        {
          this.interface29_0.imethod_24(rowRange.Position);
          this.interface29_0.imethod_33(rowRange.StartRowIndex);
          this.interface29_0.imethod_33(rowRange.EndRowIndex);
        }
      }
      else
      {
        Class551 table2005 = table.Table2005;
        this.interface29_0.imethod_32((short) table2005.TableFlags);
        this.interface29_0.imethod_41((DxfHandledObject) table2005.TableStyle);
        this.interface29_0.imethod_29(table2005.HorizontalDirection);
        this.interface29_0.imethod_33(table2005.ColumnCount);
        this.interface29_0.imethod_33(table2005.RowCount);
        for (int index = 0; index < table2005.ColumnCount; ++index)
          this.interface29_0.imethod_16(table2005.Columns[index].Width);
        for (int index = 0; index < table2005.RowCount; ++index)
          this.interface29_0.imethod_16(table2005.Rows[index].Height);
        for (int rowIndex = 0; rowIndex < table2005.RowCount; ++rowIndex)
        {
          for (int columnIndex = 0; columnIndex < table.ColumnCount; ++columnIndex)
            this.method_123(table2005, table2005.Rows[rowIndex].Cells[columnIndex], rowIndex, columnIndex);
        }
        this.method_118(table2005);
        this.method_120(table2005);
        this.method_121(table2005);
        this.method_122(table2005);
      }
      this.method_82((DxfHandledObject) table);
    }

    private void method_105(DxfTableContent tableContent)
    {
      this.method_106((DxfFormattedTableData) tableContent);
      this.interface29_0.imethod_41((DxfHandledObject) tableContent.TableStyle);
    }

    private void method_106(DxfFormattedTableData formattedTableData)
    {
      this.method_107((DxfLinkedTableData) formattedTableData);
      this.method_141(formattedTableData.CellStyleOverrides, false);
      this.interface29_0.imethod_33(formattedTableData.MergedCellRanges.Count);
      foreach (DxfTableCellRange mergedCellRange in (List<DxfTableCellRange>) formattedTableData.MergedCellRanges)
      {
        this.interface29_0.imethod_33(mergedCellRange.TopRowIndex);
        this.interface29_0.imethod_33(mergedCellRange.LeftColumnIndex);
        this.interface29_0.imethod_33(mergedCellRange.BottomRowIndex);
        this.interface29_0.imethod_33(mergedCellRange.RightColumnIndex);
      }
    }

    private void method_107(DxfLinkedTableData linkedTableData)
    {
      this.method_117((DxfLinkedData) linkedTableData);
      this.interface29_0.imethod_33(linkedTableData.Columns.Count);
      foreach (DxfTableColumn column in (ActiveList<DxfTableColumn>) linkedTableData.Columns)
      {
        this.interface29_0.imethod_4(column.Name);
        this.interface29_0.imethod_33(column.CustomData);
        this.interface29_0.imethod_33(column.CustomDataCollection.Count);
        foreach (DxfTableCustomData customData in (List<DxfTableCustomData>) column.CustomDataCollection)
          this.method_111(customData);
        this.method_141(column.CellStyleOverrides, false);
        this.interface29_0.imethod_33(column.CellStyle == null ? 0 : column.CellStyle.Id);
        this.interface29_0.imethod_16(column.Width);
      }
      this.interface29_0.imethod_33(linkedTableData.Rows.Count);
      foreach (DxfTableRow row in (ActiveList<DxfTableRow>) linkedTableData.Rows)
      {
        this.interface29_0.imethod_33(row.Cells.Count);
        foreach (DxfTableCell cell in (List<DxfTableCell>) row.Cells)
          this.method_108(cell);
        this.interface29_0.imethod_33(row.CustomData);
        this.interface29_0.imethod_33(row.CustomDataCollection.Count);
        foreach (DxfTableCustomData customData in (List<DxfTableCustomData>) row.CustomDataCollection)
          this.method_111(customData);
        this.method_141(row.CellStyleOverrides, false);
        this.interface29_0.imethod_33(row.CellStyle == null ? 0 : row.CellStyle.Id);
        this.interface29_0.imethod_16(row.Height);
      }
      this.interface29_0.imethod_33(0);
    }

    private void method_108(DxfTableCell cell)
    {
      this.interface29_0.imethod_33((int) cell.StateFlags);
      this.interface29_0.imethod_4(cell.ToolTip);
      this.interface29_0.imethod_33(cell.CustomData);
      this.interface29_0.imethod_33(cell.CustomDataCollection.Count);
      foreach (DxfTableCustomData customData in (List<DxfTableCustomData>) cell.CustomDataCollection)
        this.method_111(customData);
      this.interface29_0.imethod_33(0);
      this.interface29_0.imethod_33(cell.Contents.Count);
      foreach (DxfTableCellContent content in (List<DxfTableCellContent>) cell.Contents)
        this.method_110(content);
      this.method_141(cell.CellStyleOverrides, false);
      this.interface29_0.imethod_33(cell.CellStyle == null ? 0 : cell.CellStyle.Id);
      this.interface29_0.imethod_33(0);
    }

    private void method_109(Class550 o)
    {
      this.interface29_0.imethod_29(o.DistanceToTopLeft);
      this.interface29_0.imethod_29(o.DistanceToCenter);
      this.interface29_0.imethod_16(o.ContentWidth);
      this.interface29_0.imethod_16(o.ContentHeight);
      this.interface29_0.imethod_16(o.Width);
      this.interface29_0.imethod_16(o.Height);
      this.interface29_0.imethod_33(o.UnknownFlags);
    }

    private void method_110(DxfTableCellContent content)
    {
      this.interface29_0.imethod_33((int) content.ContentType);
      switch (content.ContentType)
      {
        case TableCellContentType.Value:
          this.method_112(content.Value);
          break;
        case TableCellContentType.Field:
          this.interface29_0.imethod_41((DxfHandledObject) null);
          break;
        case TableCellContentType.Block:
          this.interface29_0.imethod_41(content.ValueObject);
          break;
      }
      this.interface29_0.imethod_33(content.Attributes.Count);
      int num = 0;
      foreach (DxfTableAttribute attribute in (List<DxfTableAttribute>) content.Attributes)
      {
        this.interface29_0.imethod_40((DxfHandledObject) attribute.AttributeDefinition);
        this.interface29_0.imethod_4(attribute.Value);
        this.interface29_0.imethod_33(num);
        ++num;
      }
      this.interface29_0.imethod_32(content.Format.DataFlags);
      if (!content.Format.HasData)
        return;
      this.method_143(content.Format);
    }

    private void method_111(DxfTableCustomData customData)
    {
      this.interface29_0.imethod_4(customData.Name);
      this.method_112(customData.Value);
    }

    private void method_112(DxfValue value)
    {
      ValueDataType valueDataType;
      if (this.dxfVersion_0 > DxfVersion.Dxf18)
      {
        this.interface29_0.imethod_33(value.Flags);
        valueDataType = value.Format.DataType;
      }
      else
        valueDataType = value.Format.DataType == ValueDataType.General ? ValueDataType.None : value.Format.DataType;
      this.interface29_0.imethod_33((int) valueDataType);
      if (this.dxfVersion_0 < DxfVersion.Dxf21 || !value.IsEmpty)
      {
        switch (valueDataType)
        {
          case ValueDataType.None:
            this.interface29_0.imethod_33(0);
            break;
          case ValueDataType.Int:
            this.interface29_0.imethod_33((int) value.Value);
            break;
          case ValueDataType.Double:
            this.interface29_0.imethod_16((double) value.Value);
            break;
          case ValueDataType.String:
          case ValueDataType.General:
            this.method_113((string) value.Value);
            break;
          case ValueDataType.Date:
            this.method_114((DateTime?) value.Value);
            break;
          case ValueDataType.Point2D:
            this.method_115((WW.Math.Point2D?) value.Value);
            break;
          case ValueDataType.Point3D:
            this.method_116((WW.Math.Point3D?) value.Value);
            break;
          case ValueDataType.ObjectHandle:
            this.interface29_0.imethod_40((DxfHandledObject) value.Value);
            break;
        }
      }
      if (this.dxfVersion_0 <= DxfVersion.Dxf18)
        return;
      this.interface29_0.imethod_33((int) value.Format.UnitType);
      this.interface29_0.imethod_4(value.Format._FormatString);
      this.interface29_0.imethod_4(value.GetValueString((DxfValueFormat) null));
    }

    private void method_113(string s)
    {
      if (string.IsNullOrEmpty(s))
        this.interface29_0.imethod_33(0);
      else if (this.dxfVersion_0 > DxfVersion.Dxf18)
      {
        byte[] bytes = Encoding.Unicode.GetBytes(s);
        this.interface29_0.imethod_33(bytes.Length + 2);
        this.interface29_0.imethod_12(bytes);
        this.interface29_0.imethod_11((byte) 0);
        this.interface29_0.imethod_11((byte) 0);
      }
      else
      {
        byte[] bytes = this.interface29_0.Encoding.GetBytes(s);
        this.interface29_0.imethod_33(bytes.Length + 1);
        this.interface29_0.imethod_12(bytes);
        this.interface29_0.imethod_11((byte) 0);
      }
    }

    private void method_114(DateTime? dateTime)
    {
      if (dateTime.HasValue)
      {
        byte[] bytes;
        if (this.dxfVersion_0 > DxfVersion.Dxf18)
        {
          uint num = (uint) dateTime.Value.DayOfYear / 7U;
          bytes = new byte[16]
          {
            (byte) (dateTime.Value.Year & (int) byte.MaxValue),
            (byte) ((uint) dateTime.Value.Year >> 8),
            (byte) (dateTime.Value.Month & (int) byte.MaxValue),
            (byte) ((uint) dateTime.Value.Month >> 8),
            (byte) (num & (uint) byte.MaxValue),
            (byte) (num >> 8),
            (byte) (dateTime.Value.Day & (int) byte.MaxValue),
            (byte) ((uint) dateTime.Value.Day >> 8),
            (byte) (dateTime.Value.Hour & (int) byte.MaxValue),
            (byte) ((uint) dateTime.Value.Hour >> 8),
            (byte) (dateTime.Value.Minute & (int) byte.MaxValue),
            (byte) ((uint) dateTime.Value.Minute >> 8),
            (byte) (dateTime.Value.Second & (int) byte.MaxValue),
            (byte) ((uint) dateTime.Value.Second >> 8),
            (byte) (dateTime.Value.Millisecond & (int) byte.MaxValue),
            (byte) ((uint) dateTime.Value.Millisecond >> 8)
          };
        }
        else
        {
          long totalSeconds = (long) (dateTime.Value - new DateTime(1970, 1, 1)).TotalSeconds;
          bytes = new byte[8];
          for (int index = 0; index < 8; ++index)
            bytes[index] = (byte) (totalSeconds >> 56 - (index << 3) & (long) byte.MaxValue);
        }
        this.interface29_0.imethod_33(bytes.Length);
        this.interface29_0.imethod_12(bytes);
      }
      else
        this.interface29_0.imethod_33(0);
    }

    private void method_115(WW.Math.Point2D? value)
    {
      if (value.HasValue)
      {
        this.interface29_0.imethod_33(16);
        this.interface29_0.imethod_25(value.Value);
      }
      else
        this.interface29_0.imethod_33(0);
    }

    private void method_116(WW.Math.Point3D? value)
    {
      if (value.HasValue)
      {
        this.interface29_0.imethod_33(24);
        this.interface29_0.imethod_26(value.Value);
      }
      else
        this.interface29_0.imethod_33(0);
    }

    private void method_117(DxfLinkedData linkedData)
    {
      this.interface29_0.imethod_4(linkedData.Name);
      this.interface29_0.imethod_4(linkedData.Description);
    }

    private void method_118(Class551 table)
    {
      int num = 0;
      if (table.SuppressTitle.HasValue)
        num |= 1;
      if (table.SuppressHeaderRow.HasValue && table.SuppressHeaderRow.Value)
        num |= 2;
      if (table.FlowDirection.HasValue)
        num |= 4;
      if (table.HorizontalCellMargin.HasValue)
        num |= 8;
      if (table.VerticalCellMargin.HasValue)
        num |= 16;
      if (table.TitleRowCellStyle.ContentColor.HasValue)
        num |= 32;
      if (table.HeaderRowCellStyle.ContentColor.HasValue)
        num |= 64;
      if (table.DataRowCellStyle.ContentColor.HasValue)
        num |= 128;
      if (table.TitleRowCellStyle.IsBackColorEnabled.HasValue)
        num |= 256;
      if (table.HeaderRowCellStyle.IsBackColorEnabled.HasValue)
        num |= 512;
      if (table.DataRowCellStyle.IsBackColorEnabled.HasValue)
        num |= 1024;
      if (table.TitleRowCellStyle.BackColor.HasValue)
        num |= 2048;
      if (table.HeaderRowCellStyle.BackColor.HasValue)
        num |= 4096;
      if (table.DataRowCellStyle.BackColor.HasValue)
        num |= 8192;
      if (table.TitleRowCellStyle.CellAlignment.HasValue)
        num |= 16384;
      if (table.HeaderRowCellStyle.CellAlignment.HasValue)
        num |= 32768;
      if (table.DataRowCellStyle.CellAlignment.HasValue)
        num |= 65536;
      if (table.TitleRowCellStyle.TextStyle != null)
        num |= 131072;
      if (table.HeaderRowCellStyle.TextStyle != null)
        num |= 262144;
      if (table.DataRowCellStyle.TextStyle != null)
        num |= 524288;
      if (table.TitleRowCellStyle.TextHeight.HasValue)
        num |= 1048576;
      if (table.HeaderRowCellStyle.TextHeight.HasValue)
        num |= 2097152;
      if (table.DataRowCellStyle.TextHeight.HasValue)
        num |= 4194304;
      if (this.dxfVersion_0 > DxfVersion.Dxf18)
      {
        if (table.TitleRowCellStyle.CellFormat != null)
          num |= 8388608;
        if (table.HeaderRowCellStyle.CellFormat != null)
          num |= 16777216;
        if (table.DataRowCellStyle.CellFormat != null)
          num |= 33554432;
      }
      this.interface29_0.imethod_14(num != 0);
      if (num != 0)
        this.interface29_0.imethod_33(num);
      if (table.SuppressTitle.HasValue)
        this.interface29_0.imethod_14(table.SuppressTitle.HasValue);
      if (table.FlowDirection.HasValue)
        this.interface29_0.imethod_32((short) table.FlowDirection.Value);
      if (table.HorizontalCellMargin.HasValue)
        this.interface29_0.imethod_16(table.HorizontalCellMargin.Value);
      if (table.VerticalCellMargin.HasValue)
        this.interface29_0.imethod_16(table.VerticalCellMargin.Value);
      if (table.TitleRowCellStyle.ContentColor.HasValue)
        this.interface29_0.imethod_8(table.TitleRowCellStyle.ContentColor.Value);
      if (table.HeaderRowCellStyle.ContentColor.HasValue)
        this.interface29_0.imethod_8(table.HeaderRowCellStyle.ContentColor.Value);
      if (table.DataRowCellStyle.ContentColor.HasValue)
        this.interface29_0.imethod_8(table.DataRowCellStyle.ContentColor.Value);
      if (table.TitleRowCellStyle.IsBackColorEnabled.HasValue)
        this.interface29_0.imethod_14(table.TitleRowCellStyle.IsBackColorEnabled.Value);
      if (table.HeaderRowCellStyle.IsBackColorEnabled.HasValue)
        this.interface29_0.imethod_14(table.HeaderRowCellStyle.IsBackColorEnabled.Value);
      if (table.DataRowCellStyle.IsBackColorEnabled.HasValue)
        this.interface29_0.imethod_14(table.DataRowCellStyle.IsBackColorEnabled.Value);
      if (table.TitleRowCellStyle.BackColor.HasValue)
        this.interface29_0.imethod_8(table.TitleRowCellStyle.BackColor.Value);
      if (table.HeaderRowCellStyle.BackColor.HasValue)
        this.interface29_0.imethod_8(table.HeaderRowCellStyle.BackColor.Value);
      if (table.DataRowCellStyle.BackColor.HasValue)
        this.interface29_0.imethod_8(table.DataRowCellStyle.BackColor.Value);
      if (table.TitleRowCellStyle.CellAlignment.HasValue)
        this.interface29_0.imethod_32((short) table.TitleRowCellStyle.CellAlignment.Value);
      if (table.HeaderRowCellStyle.CellAlignment.HasValue)
        this.interface29_0.imethod_32((short) table.HeaderRowCellStyle.CellAlignment.Value);
      if (table.DataRowCellStyle.CellAlignment.HasValue)
        this.interface29_0.imethod_32((short) table.DataRowCellStyle.CellAlignment.Value);
      if (table.TitleRowCellStyle.TextStyle != null)
        this.interface29_0.imethod_41((DxfHandledObject) table.TitleRowCellStyle.TextStyle);
      if (table.HeaderRowCellStyle.TextStyle != null)
        this.interface29_0.imethod_41((DxfHandledObject) table.HeaderRowCellStyle.TextStyle);
      if (table.DataRowCellStyle.TextStyle != null)
        this.interface29_0.imethod_41((DxfHandledObject) table.DataRowCellStyle.TextStyle);
      if (table.TitleRowCellStyle.TextHeight.HasValue)
        this.interface29_0.imethod_16(table.TitleRowCellStyle.TextHeight.Value);
      if (table.HeaderRowCellStyle.TextHeight.HasValue)
        this.interface29_0.imethod_16(table.HeaderRowCellStyle.TextHeight.Value);
      if (table.DataRowCellStyle.TextHeight.HasValue)
        this.interface29_0.imethod_16(table.DataRowCellStyle.TextHeight.Value);
      if (this.dxfVersion_0 <= DxfVersion.Dxf18)
        return;
      if (table.TitleRowCellStyle.CellFormat != null)
        this.method_119(table.TitleRowCellStyle.CellFormat);
      if (table.HeaderRowCellStyle.CellFormat != null)
        this.method_119(table.HeaderRowCellStyle.CellFormat);
      if (table.DataRowCellStyle.CellFormat == null)
        return;
      this.method_119(table.DataRowCellStyle.CellFormat);
    }

    private void method_119(DxfValueFormat cellFormat)
    {
      this.interface29_0.imethod_33((int) cellFormat.DataType);
      this.interface29_0.imethod_33((int) cellFormat.UnitType);
      this.interface29_0.imethod_4(cellFormat._FormatString);
    }

    private void method_120(Class551 table)
    {
      int num = 0;
      if (table.BorderTop.Color.HasValue)
        num |= 1;
      if (table.BorderInsideHorizontal.Color.HasValue)
        num |= 2;
      if (table.BorderBottom.Color.HasValue)
        num |= 4;
      if (table.BorderLeft.Color.HasValue)
        num |= 8;
      if (table.BorderInsideVertical.Color.HasValue)
        num |= 16;
      if (table.BorderRight.Color.HasValue)
        num |= 32;
      this.interface29_0.imethod_14(num != 0);
      if (num != 0)
        this.interface29_0.imethod_33(num);
      if (table.BorderTop.Color.HasValue)
        this.interface29_0.imethod_8(table.BorderTop.Color.Value);
      if (table.BorderInsideHorizontal.Color.HasValue)
        this.interface29_0.imethod_8(table.BorderInsideHorizontal.Color.Value);
      if (table.BorderBottom.Color.HasValue)
        this.interface29_0.imethod_8(table.BorderBottom.Color.Value);
      if (table.BorderLeft.Color.HasValue)
        this.interface29_0.imethod_8(table.BorderLeft.Color.Value);
      if (table.BorderInsideVertical.Color.HasValue)
        this.interface29_0.imethod_8(table.BorderInsideVertical.Color.Value);
      if (!table.BorderRight.Color.HasValue)
        return;
      this.interface29_0.imethod_8(table.BorderRight.Color.Value);
    }

    private void method_121(Class551 table)
    {
      int num = 0;
      if (table.BorderTop.LineWeight.HasValue)
        num |= 1;
      if (table.BorderInsideHorizontal.LineWeight.HasValue)
        num |= 2;
      if (table.BorderBottom.LineWeight.HasValue)
        num |= 4;
      if (table.BorderLeft.LineWeight.HasValue)
        num |= 8;
      if (table.BorderInsideVertical.LineWeight.HasValue)
        num |= 16;
      if (table.BorderRight.LineWeight.HasValue)
        num |= 32;
      this.interface29_0.imethod_14(num != 0);
      if (num != 0)
        this.interface29_0.imethod_33(num);
      if (table.BorderTop.LineWeight.HasValue)
        this.interface29_0.imethod_32(table.BorderTop.LineWeight.Value);
      if (table.BorderInsideHorizontal.LineWeight.HasValue)
        this.interface29_0.imethod_32(table.BorderInsideHorizontal.LineWeight.Value);
      if (table.BorderBottom.LineWeight.HasValue)
        this.interface29_0.imethod_32(table.BorderBottom.LineWeight.Value);
      if (table.BorderLeft.LineWeight.HasValue)
        this.interface29_0.imethod_32(table.BorderLeft.LineWeight.Value);
      if (table.BorderInsideVertical.LineWeight.HasValue)
        this.interface29_0.imethod_32(table.BorderInsideVertical.LineWeight.Value);
      if (!table.BorderRight.LineWeight.HasValue)
        return;
      this.interface29_0.imethod_32(table.BorderRight.LineWeight.Value);
    }

    private void method_122(Class551 table)
    {
      int num = 0;
      if (table.BorderTop.Visible.HasValue)
        num |= 1;
      if (table.BorderInsideHorizontal.Visible.HasValue)
        num |= 2;
      if (table.BorderBottom.Visible.HasValue)
        num |= 4;
      if (table.BorderLeft.Visible.HasValue)
        num |= 8;
      if (table.BorderInsideVertical.Visible.HasValue)
        num |= 16;
      if (table.BorderRight.Visible.HasValue)
        num |= 32;
      this.interface29_0.imethod_14(num != 0);
      if (num != 0)
        this.interface29_0.imethod_33(num);
      if (table.BorderTop.Visible.HasValue)
        this.interface29_0.imethod_32(table.BorderTop.Visible.Value ? (short) 1 : (short) 0);
      if (table.BorderInsideHorizontal.Visible.HasValue)
        this.interface29_0.imethod_32(table.BorderInsideHorizontal.Visible.Value ? (short) 1 : (short) 0);
      if (table.BorderBottom.Visible.HasValue)
        this.interface29_0.imethod_32(table.BorderBottom.Visible.Value ? (short) 1 : (short) 0);
      if (table.BorderLeft.Visible.HasValue)
        this.interface29_0.imethod_32(table.BorderLeft.Visible.Value ? (short) 1 : (short) 0);
      if (table.BorderInsideVertical.Visible.HasValue)
        this.interface29_0.imethod_32(table.BorderInsideVertical.Visible.Value ? (short) 1 : (short) 0);
      if (!table.BorderRight.Visible.HasValue)
        return;
      this.interface29_0.imethod_32(table.BorderRight.Visible.Value ? (short) 1 : (short) 0);
    }

    private void method_123(Class551 table, Class1026 cell, int rowIndex, int columnIndex)
    {
      this.interface29_0.imethod_32((short) cell.CellType);
      byte edgeFlags;
      byte virtualEdgeFlags;
      int overrideFlags;
      int borderTopFlags;
      int borderRightFlags;
      int borderBottomFlags;
      int borderLeftFlags;
      table.method_11(this.dxfVersion_0, cell, rowIndex, columnIndex, out edgeFlags, out virtualEdgeFlags, out overrideFlags, out borderTopFlags, out borderRightFlags, out borderBottomFlags, out borderLeftFlags);
      this.interface29_0.imethod_11(edgeFlags);
      bool isMerged = table.method_2(rowIndex, columnIndex);
      this.interface29_0.imethod_14(isMerged);
      this.interface29_0.imethod_14(cell.AutoFit);
      this.interface29_0.imethod_33(cell.MergedCellCountHorizontal);
      this.interface29_0.imethod_33(cell.MergedCellCountVertical);
      this.interface29_0.imethod_16(cell.Rotation);
      if (cell.CellType == Enum47.const_1)
      {
        this.interface29_0.imethod_41(cell.BlockOrField);
        if (this.dxfVersion_0 < DxfVersion.Dxf21)
        {
          DxfTableCellStyle cellStyle = table.GetCellStyle(rowIndex, columnIndex);
          this.interface29_0.imethod_4(cell.Value.GetValueString(cellStyle.ValueFormat));
        }
      }
      else
      {
        this.interface29_0.imethod_41(cell.BlockOrField);
        this.interface29_0.imethod_16(cell.BlockScale);
        this.interface29_0.imethod_14(cell.HasAttributes);
        if (cell.HasAttributes)
        {
          this.interface29_0.imethod_32((short) cell.Attributes.Count);
          short num = 0;
          foreach (DxfTableAttribute attribute in (List<DxfTableAttribute>) cell.Attributes)
          {
            this.interface29_0.imethod_40((DxfHandledObject) attribute.AttributeDefinition);
            this.interface29_0.imethod_32(num);
            this.interface29_0.imethod_4(attribute.Value);
            ++num;
          }
        }
      }
      bool flag = overrideFlags != 0;
      this.interface29_0.imethod_14(flag);
      if (flag)
      {
        this.interface29_0.imethod_33(overrideFlags);
        this.interface29_0.imethod_11(virtualEdgeFlags);
        if (cell.CellAlignment.HasValue)
          this.interface29_0.imethod_32((short) cell.CellAlignment.Value);
        if (cell.IsBackColorEnabled.HasValue)
          this.interface29_0.imethod_14(cell.IsBackColorEnabled.Value);
        if (cell.BackColor.HasValue)
          this.interface29_0.imethod_8(cell.BackColor.Value);
        if (cell.ContentColor.HasValue)
          this.interface29_0.imethod_8(cell.ContentColor.Value);
        if (cell.TextStyle != null)
          this.interface29_0.imethod_41((DxfHandledObject) cell.TextStyle);
        if (cell.TextHeight.HasValue)
          this.interface29_0.imethod_16(cell.TextHeight.Value);
        if (borderTopFlags != 0)
          this.method_125(cell.BorderTop);
        if (borderRightFlags != 0)
          this.method_125(cell.BorderRight);
        if (borderBottomFlags != 0)
          this.method_125(cell.BorderBottom);
        if (borderLeftFlags != 0)
          this.method_125(cell.BorderLeft);
      }
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        return;
      this.interface29_0.imethod_33(cell.ExtendedFlags);
      this.method_124(table, cell, rowIndex, columnIndex, isMerged);
    }

    private void method_124(
      Class551 table,
      Class1026 cell,
      int rowIndex,
      int columnIndex,
      bool isMerged)
    {
      bool cellHasValue = cell.method_4(isMerged);
      int num1 = cell.method_5(cellHasValue);
      if (this.dxfVersion_0 > DxfVersion.Dxf18)
        this.interface29_0.imethod_33(num1);
      this.interface29_0.imethod_33((int) cell.Value.Format.DataType);
      if ((num1 & 1) == 0 || this.dxfVersion_0 <= DxfVersion.Dxf18)
      {
        switch (cell.Value.Format.DataType)
        {
          case ValueDataType.None:
            this.interface29_0.imethod_33(Convert.ToInt32(cell.Value.Value));
            break;
          case ValueDataType.Int:
            this.interface29_0.imethod_33(Convert.ToInt32(cell.Value.Value));
            break;
          case ValueDataType.Double:
            this.interface29_0.imethod_16(Convert.ToDouble(cell.Value.Value));
            break;
          case ValueDataType.String:
          case ValueDataType.General:
            byte[] bytes = (byte[]) null;
            string s = Convert.ToString(cell.Value.Value);
            if (this.dxfVersion_0 > DxfVersion.Dxf18)
            {
              if (!string.IsNullOrEmpty(s))
                bytes = Encoding.Unicode.GetBytes(s);
            }
            else if (!string.IsNullOrEmpty(s))
              bytes = this.interface29_0.Encoding.GetBytes(s);
            if (bytes == null)
            {
              this.interface29_0.imethod_33(0);
              break;
            }
            this.interface29_0.imethod_33(bytes.Length);
            this.interface29_0.imethod_12(bytes);
            break;
          case ValueDataType.Date:
            DateTime dateTime = Convert.ToDateTime(cell.Value.Value);
            int num2 = dateTime.DayOfYear / 7 + 1;
            if (this.dxfVersion_0 > DxfVersion.Dxf18)
            {
              this.interface29_0.imethod_33(16);
              this.interface29_0.imethod_18((short) dateTime.Year);
              this.interface29_0.imethod_18((short) dateTime.Month);
              this.interface29_0.imethod_18((short) num2);
              this.interface29_0.imethod_18((short) dateTime.Day);
              this.interface29_0.imethod_18((short) dateTime.Hour);
              this.interface29_0.imethod_18((short) dateTime.Minute);
              this.interface29_0.imethod_18((short) dateTime.Second);
              this.interface29_0.imethod_18((short) dateTime.Millisecond);
              break;
            }
            this.interface29_0.imethod_33(8);
            long totalSeconds = (long) (dateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, dateTime.Kind)).TotalSeconds;
            byte num3 = 56;
            for (int index = 0; index < 8; ++index)
            {
              this.interface29_0.imethod_11((byte) (totalSeconds >> (int) num3 & (long) byte.MaxValue));
              num3 -= (byte) 8;
            }
            break;
          case ValueDataType.Point2D:
            this.interface29_0.imethod_33(16);
            this.interface29_0.imethod_25((WW.Math.Point2D) cell.Value.Value);
            break;
          case ValueDataType.Point3D:
            this.interface29_0.imethod_33(24);
            this.interface29_0.imethod_26((WW.Math.Point3D) cell.Value.Value);
            break;
          case ValueDataType.ObjectHandle:
            this.interface29_0.imethod_40((DxfHandledObject) cell.Value.Value);
            break;
        }
      }
      if (this.dxfVersion_0 <= DxfVersion.Dxf18)
        return;
      this.interface29_0.imethod_33((int) cell.Value.Format.UnitType);
      this.interface29_0.imethod_4(cell.Value.Format._FormatString);
      DxfTableCellStyle cellStyle = table.GetCellStyle(rowIndex, columnIndex);
      this.interface29_0.imethod_4(cell.Value.GetValueString(cellStyle.ValueFormat));
    }

    private void method_125(DxfTableBorderOverrides overrides)
    {
      if (overrides.Color.HasValue)
        this.interface29_0.imethod_8(overrides.Color.Value);
      if (overrides.LineWeight.HasValue)
        this.interface29_0.imethod_32(overrides.LineWeight.Value);
      if (!overrides.Visible.HasValue)
        return;
      this.interface29_0.imethod_32(overrides.Visible.Value ? (short) 1 : (short) 0);
    }

    public void Visit(DxfTableGeometry tableGeometry)
    {
    }

    public void Visit(DxfText text)
    {
      this.method_73((DxfEntity) text);
      this.method_126(text);
      this.method_127(text);
      this.method_128(text);
      this.method_82((DxfHandledObject) text);
    }

    private void method_126(DxfText text)
    {
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf14)
      {
        this.interface29_0.imethod_16(text.AlignmentPoint1.Z);
        this.interface29_0.imethod_20(text.AlignmentPoint1.X);
        this.interface29_0.imethod_20(text.AlignmentPoint1.Y);
        if (text.AlignmentPoint2.HasValue)
        {
          this.interface29_0.imethod_20(text.AlignmentPoint2.Value.X);
          this.interface29_0.imethod_20(text.AlignmentPoint2.Value.Y);
        }
        else
        {
          this.interface29_0.imethod_20(text.AlignmentPoint1.X);
          this.interface29_0.imethod_20(text.AlignmentPoint1.Y);
        }
        this.interface29_0.imethod_29(text.ZAxis);
        this.interface29_0.imethod_16(text.Thickness);
        this.interface29_0.imethod_16(text.ObliqueAngle);
        this.interface29_0.imethod_16(text.Rotation);
        this.interface29_0.imethod_16(text.Height);
        this.interface29_0.imethod_16(text.WidthFactor);
        this.interface29_0.imethod_4(text.Text);
        this.interface29_0.imethod_32((short) text.TextGenerationFlags);
        this.interface29_0.imethod_32((short) text.HorizontalAlignment);
        this.interface29_0.imethod_32((short) text.VerticalAlignment);
      }
      if (this.dxfVersion_0 < DxfVersion.Dxf15)
        return;
      byte num = 0;
      if (text.AlignmentPoint1.Z == 0.0)
        num |= (byte) 1;
      if (!text.AlignmentPoint2.HasValue || text.AlignmentPoint2.Value == WW.Math.Point3D.Zero)
        num |= (byte) 2;
      if (text.ObliqueAngle == 0.0)
        num |= (byte) 4;
      if (text.Rotation == 0.0)
        num |= (byte) 8;
      if (text.WidthFactor == 1.0)
        num |= (byte) 16;
      if (text.TextGenerationFlags == TextGenerationFlags.None)
        num |= (byte) 32;
      if (text.HorizontalAlignment == TextHorizontalAlignment.Left)
        num |= (byte) 64;
      if (text.VerticalAlignment == TextVerticalAlignment.Baseline)
        num |= (byte) 128;
      this.interface29_0.imethod_11(num);
      if (text.AlignmentPoint1.Z != 0.0)
        this.interface29_0.imethod_20(text.AlignmentPoint1.Z);
      this.interface29_0.imethod_20(text.AlignmentPoint1.X);
      this.interface29_0.imethod_20(text.AlignmentPoint1.Y);
      if (text.AlignmentPoint2.HasValue && text.AlignmentPoint2.Value != WW.Math.Point3D.Zero)
      {
        this.interface29_0.imethod_17(text.AlignmentPoint2.Value.X, text.AlignmentPoint1.X);
        this.interface29_0.imethod_17(text.AlignmentPoint2.Value.Y, text.AlignmentPoint1.Y);
      }
      this.interface29_0.imethod_3(text.ZAxis);
      this.interface29_0.imethod_1(text.Thickness);
      if (text.ObliqueAngle != 0.0)
        this.interface29_0.imethod_20(text.ObliqueAngle);
      if (text.Rotation != 0.0)
        this.interface29_0.imethod_20(text.Rotation);
      this.interface29_0.imethod_20(text.Height);
      if (text.WidthFactor != 1.0)
        this.interface29_0.imethod_20(text.WidthFactor);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(text.Text);
      if (text.TextGenerationFlags != TextGenerationFlags.None)
        this.interface29_0.imethod_32((short) text.TextGenerationFlags);
      if (text.HorizontalAlignment != TextHorizontalAlignment.Left)
        this.interface29_0.imethod_32((short) text.HorizontalAlignment);
      if (text.VerticalAlignment == TextVerticalAlignment.Baseline)
        return;
      this.interface29_0.imethod_32((short) text.VerticalAlignment);
    }

    private void method_127(DxfText text)
    {
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        return;
      this.interface29_0.imethod_4(text.Text);
    }

    private void method_128(DxfText text)
    {
      this.interface29_0.imethod_41((DxfHandledObject) text.Style);
    }

    public void Visit(DxfTolerance tolerance)
    {
      this.method_73((DxfEntity) tolerance);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf14)
      {
        this.interface29_0.imethod_32((short) 0);
        this.interface29_0.imethod_16(0.0);
        this.interface29_0.imethod_16(0.0);
      }
      this.interface29_0.imethod_24(tolerance.InsertionPoint);
      this.interface29_0.imethod_29(tolerance.XAxis);
      this.interface29_0.imethod_29(tolerance.ZAxis);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(tolerance.Text);
      else
        this.interface29_0.imethod_4(tolerance.Text);
      this.interface29_0.imethod_41((DxfHandledObject) tolerance.DimensionStyle);
      this.method_82((DxfHandledObject) tolerance);
    }

    public void Visit(DxfVertex2D vertex)
    {
      throw new InternalException("A vertex can only exist in the context of a polyline.");
    }

    public void Visit(DxfVertex3D vertex)
    {
      throw new InternalException("A vertex can only exist in the context of a polyline.");
    }

    public void Visit(DxfViewport viewport)
    {
      this.method_73((DxfEntity) viewport);
      this.interface29_0.imethod_24(viewport.Center);
      this.interface29_0.imethod_16(viewport.Size.X);
      this.interface29_0.imethod_16(viewport.Size.Y);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_24(viewport.Target);
        this.interface29_0.imethod_29(viewport.Direction);
        this.interface29_0.imethod_16(viewport.TwistAngle);
        this.interface29_0.imethod_16(viewport.ViewHeight);
        this.interface29_0.imethod_16(viewport.LensLength);
        this.interface29_0.imethod_16(viewport.FrontClipPlaneZValue);
        this.interface29_0.imethod_16(viewport.BackClipPlaneZValue);
        this.interface29_0.imethod_16(viewport.SnapAngle);
        this.interface29_0.imethod_25(viewport.ViewCenter);
        this.interface29_0.imethod_25(viewport.SnapBasePoint);
        this.interface29_0.imethod_28(viewport.SnapSpacing);
        this.interface29_0.imethod_28(viewport.GridSpacing);
        this.interface29_0.imethod_32((short) viewport.CircleZoomPercentage);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_32(viewport.MajorGridLineFrequency);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_33(viewport.FrozenLayers.Count);
        this.interface29_0.imethod_33((int) viewport.StatusFlags);
        if (this.dxfVersion_0 < DxfVersion.Dxf21)
          this.interface29_0.imethod_4(string.Empty);
        this.interface29_0.imethod_11((byte) viewport.RenderMode);
        this.interface29_0.imethod_14(viewport.DisplayUcsIcon);
        this.interface29_0.imethod_14(viewport.UcsPerViewport);
        this.interface29_0.imethod_24(viewport.Ucs.Origin);
        this.interface29_0.imethod_29(viewport.Ucs.XAxis);
        this.interface29_0.imethod_29(viewport.Ucs.YAxis);
        this.interface29_0.imethod_16(viewport.Ucs.Elevation);
        this.interface29_0.imethod_32((short) viewport.UcsOrthographicType);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
        this.interface29_0.imethod_32((short) viewport.ShadePlotMode);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_14(viewport.UseDefaultLighting);
        this.interface29_0.imethod_11((byte) viewport.DefaultLightingType);
        this.interface29_0.imethod_16(viewport.Brightness);
        this.interface29_0.imethod_16(viewport.Constrast);
        this.interface29_0.imethod_6(viewport.AmbientLightColor);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_4(string.Empty);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf14)
      {
        if (viewport.OwnerObjectSoftReference == this.dxfModel_0.PaperSpaceBlock)
          this.interface29_0.imethod_41((DxfHandledObject) viewport.ViewportEntityHeader);
        else
          this.interface29_0.imethod_41((DxfHandledObject) null);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        foreach (DxfLayer frozenLayer in (IEnumerable<DxfLayer>) viewport.FrozenLayers)
        {
          if (this.dxfVersion_0 >= DxfVersion.Dxf18)
            this.interface29_0.imethod_40((DxfHandledObject) frozenLayer);
          else
            this.interface29_0.imethod_41((DxfHandledObject) frozenLayer);
        }
        this.interface29_0.imethod_41((DxfHandledObject) viewport.ClippingBoundaryEntity);
      }
      if (this.dxfVersion_0 <= DxfVersion.Dxf15)
      {
        if (viewport.OwnerObjectSoftReference == this.dxfModel_0.PaperSpaceBlock)
          this.interface29_0.imethod_41((DxfHandledObject) viewport.ViewportEntityHeader);
        else
          this.interface29_0.imethod_41((DxfHandledObject) null);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
      {
        if (viewport.UcsOrthographicType == OrthographicType.None)
        {
          this.interface29_0.imethod_41((DxfHandledObject) viewport.Ucs);
          this.interface29_0.imethod_41((DxfHandledObject) null);
        }
        else
        {
          this.interface29_0.imethod_41((DxfHandledObject) null);
          this.interface29_0.imethod_41((DxfHandledObject) viewport.Ucs);
        }
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_40((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_40((DxfHandledObject) null);
        this.interface29_0.imethod_39((DxfHandledObject) null);
      }
      this.method_82((DxfHandledObject) viewport);
    }

    public void Visit(DxfProxyEntity proxyEntity)
    {
      proxyEntity.Write(this);
      this.method_82((DxfHandledObject) proxyEntity);
    }

    public void Visit(DxfXLine xline)
    {
      this.method_73((DxfEntity) xline);
      this.interface29_0.imethod_24(xline.StartPoint);
      this.interface29_0.imethod_29(xline.Direction);
      this.method_82((DxfHandledObject) xline);
    }

    public static void smethod_0(Interface29 objectWriter, DxfOle ole)
    {
      objectWriter.imethod_11(ole.UnknownByte1);
      objectWriter.imethod_11(ole.UnknownByte2);
      objectWriter.imethod_26(ole.UpperLeft);
      objectWriter.imethod_26(ole.UpperRight);
      objectWriter.imethod_26(ole.LowerRight);
      objectWriter.imethod_26(ole.LowerLeft);
      objectWriter.imethod_18(ole.HimetricWidth);
      objectWriter.imethod_18(ole.HimetricHeight);
      objectWriter.imethod_19(0);
      objectWriter.imethod_19(ole.OleItemVersion);
      objectWriter.imethod_19(ole.ItemId);
      objectWriter.imethod_19((int) ole.AdviseType);
      objectWriter.imethod_18(ole.Moniker ? (short) 1 : (short) 0);
      objectWriter.imethod_19((int) ole.DrawAspect);
      int num = ole.OleData == null ? 0 : ole.OleData.Length;
      objectWriter.imethod_19(num);
      if (num == 0)
        return;
      objectWriter.imethod_12(ole.OleData);
    }

    public void Visit(DxfOle ole)
    {
      this.method_73((DxfEntity) ole);
      this.interface29_0.imethod_33(ole.OleDataVersion);
      if (this.dxfVersion_0 > DxfVersion.Dxf14)
        this.interface29_0.imethod_33(ole.UnknownLong);
      MemoryStream memoryStream = new MemoryStream();
      DwgWriter dwgWriter = new DwgWriter((Stream) memoryStream, this.dxfModel_0);
      Encoding encoding = Encodings.GetEncoding((int) this.dxfModel_0.Header.DrawingCodePage);
      Class432.smethod_0(Class724.Create(this.dxfModel_0.Header.AcadVersion, (Stream) memoryStream, encoding), ole);
      this.interface29_0.imethod_33((int) memoryStream.Length);
      this.interface29_0.imethod_13(memoryStream.GetBuffer(), 0, (int) memoryStream.Length);
      if (this.dxfVersion_0 > DxfVersion.Dxf14)
        this.interface29_0.imethod_11((byte) ole.Quality);
      this.method_82((DxfHandledObject) ole);
    }

    public void Visit(DxfDataTable dataTable)
    {
      dataTable.vmethod_7(this);
    }

    public virtual void Visit(DxfDictionary dictionary)
    {
      DxfDictionaryEntryCollection filteredEntries = this.method_129(dictionary, this.dxfVersion_0);
      this.method_130(dictionary, this.dxfVersion_0, filteredEntries);
      this.method_131(dictionary, this.dxfVersion_0, filteredEntries);
      this.method_82((DxfHandledObject) dictionary);
      this.method_132(filteredEntries);
    }

    private DxfDictionaryEntryCollection method_129(
      DxfDictionary dictionary,
      DxfVersion effectiveVersion)
    {
      DxfDictionaryEntryCollection dictionaryEntryCollection = new DxfDictionaryEntryCollection();
      foreach (DxfDictionaryEntry entry in (ActiveList<IDictionaryEntry>) dictionary.Entries)
      {
        if (entry.Value != null)
        {
          entry.Value.Accept((IObjectVisitor) this.class920_0);
          if (this.class920_0.Supported)
            dictionaryEntryCollection.Add((IDictionaryEntry) entry);
        }
      }
      return dictionaryEntryCollection;
    }

    private void method_130(
      DxfDictionary dictionary,
      DxfVersion effectiveVersion,
      DxfDictionaryEntryCollection filteredEntries)
    {
      dictionary.vmethod_7(this);
      this.interface29_0.imethod_33(filteredEntries.Count);
      if (effectiveVersion == DxfVersion.Dxf14)
        this.interface29_0.imethod_11((byte) 0);
      if (effectiveVersion >= DxfVersion.Dxf15)
      {
        this.interface29_0.imethod_32((short) dictionary.DuplicateRecordCloning);
        this.interface29_0.imethod_11(dictionary.HardOwner ? (byte) 1 : (byte) 0);
      }
      foreach (DxfDictionaryEntry filteredEntry in (ActiveList<IDictionaryEntry>) filteredEntries)
        this.interface29_0.imethod_4(Class721.smethod_0(effectiveVersion, filteredEntry.Name));
    }

    private void method_131(
      DxfDictionary dictionary,
      DxfVersion effectiveVersion,
      DxfDictionaryEntryCollection filteredEntries)
    {
      foreach (DxfDictionaryEntry filteredEntry in (ActiveList<IDictionaryEntry>) filteredEntries)
        this.interface29_0.imethod_38((DxfHandledObject) filteredEntry.Value);
    }

    private void method_132(DxfDictionaryEntryCollection filteredEntries)
    {
      foreach (DxfDictionaryEntry filteredEntry in (ActiveList<IDictionaryEntry>) filteredEntries)
      {
        if (filteredEntry.Value != null)
          this.queue_0.Enqueue(filteredEntry.Value);
      }
    }

    public virtual void Visit(DxfDictionaryWithDefault dictionary)
    {
      DxfDictionaryEntryCollection filteredEntries = this.method_129((DxfDictionary) dictionary, this.dxfVersion_0);
      DxfVersion effectiveVersion = this.dxfVersion_0 >= DxfVersion.Dxf15 ? this.dxfVersion_0 : DxfVersion.Dxf15;
      this.method_130((DxfDictionary) dictionary, effectiveVersion, filteredEntries);
      this.method_131((DxfDictionary) dictionary, effectiveVersion, filteredEntries);
      this.interface29_0.imethod_41(dictionary.DefaultEntry != null ? (DxfHandledObject) dictionary.DefaultEntry : (DxfHandledObject) null);
      this.method_82((DxfHandledObject) dictionary);
      this.method_132(filteredEntries);
    }

    private void method_133(DxfXRecordValue value, MemoryStream dataStream)
    {
      short code = value.Code;
      this.method_138(dataStream, code);
      Enum5 enum5 = Class820.smethod_2((int) code);
      switch (enum5)
      {
        case Enum5.const_1:
          this.method_135(value);
          dataStream.WriteByte(Convert.ToByte(value.Value, (IFormatProvider) CultureInfo.InvariantCulture));
          break;
        case Enum5.const_2:
          this.method_135(value);
          dataStream.WriteByte(Convert.ToByte(value.Value, (IFormatProvider) CultureInfo.InvariantCulture));
          break;
        case Enum5.const_3:
          this.method_135(value);
          byte[] buffer = (byte[]) value.Value;
          if (buffer.Length > (int) byte.MaxValue)
            throw new Exception("XRECORD byte array data may not contain more than 255 bytes.");
          dataStream.WriteByte((byte) buffer.Length);
          dataStream.Write(buffer, 0, buffer.Length);
          break;
        case Enum5.const_4:
          this.method_135(value);
          this.method_137(dataStream, Convert.ToDouble(value.Value, (IFormatProvider) CultureInfo.InvariantCulture));
          break;
        case Enum5.const_5:
          string str = value.Value == null ? string.Empty : ((DxfHandledObject) value.Value).HandleString;
          this.method_136(dataStream, str);
          break;
        case Enum5.const_6:
          this.method_135(value);
          this.method_136(dataStream, (string) value.Value);
          break;
        case Enum5.const_7:
        case Enum5.const_8:
        case Enum5.const_15:
          ulong num1 = value.Value == null ? 0UL : ((DxfHandledObject) value.Value).Handle;
          this.method_140(dataStream, num1);
          break;
        case Enum5.const_9:
        case Enum5.const_14:
          ulong num2 = value.Value == null ? 0UL : ((DxfHandledObject) value.Value).Handle;
          this.method_140(dataStream, num2);
          DxfObject dxfObject = value.Value as DxfObject;
          if (dxfObject == null)
            break;
          this.queue_0.Enqueue(dxfObject);
          break;
        case Enum5.const_10:
        case Enum5.const_17:
          this.method_135(value);
          this.method_138(dataStream, Convert.ToInt16(value.Value, (IFormatProvider) CultureInfo.InvariantCulture));
          break;
        case Enum5.const_11:
          this.method_135(value);
          this.method_139(dataStream, Convert.ToInt32(value.Value, (IFormatProvider) CultureInfo.InvariantCulture));
          break;
        case Enum5.const_12:
          this.method_135(value);
          this.method_140(dataStream, (ulong) Convert.ToInt64(value.Value, (IFormatProvider) CultureInfo.InvariantCulture));
          break;
        case Enum5.const_13:
          this.method_135(value);
          WW.Math.Point3D point3D = (WW.Math.Point3D) value.Value;
          this.method_137(dataStream, point3D.X);
          this.method_137(dataStream, point3D.Y);
          this.method_137(dataStream, point3D.Z);
          break;
        case Enum5.const_16:
          this.method_135(value);
          this.method_136(dataStream, Convert.ToString(value.Value, (IFormatProvider) CultureInfo.InvariantCulture));
          break;
        case Enum5.const_18:
          this.method_134(value);
          break;
        default:
          throw new Exception("Unknown group value type " + (object) enum5 + " for group " + (object) code + ".");
      }
    }

    private void method_134(DxfXRecordValue value)
    {
      if (value.Value != null)
        throw new InternalException("Illegal XRecord, null value expected.");
    }

    private void method_135(DxfXRecordValue value)
    {
      if (value.Value == null)
        throw new InternalException("Illegal XRecord, no value.");
    }

    public virtual void Visit(DxfXRecord xrecord)
    {
      xrecord.vmethod_7(this);
      MemoryStream dataStream = new MemoryStream();
      foreach (DxfXRecordValue dxfXrecordValue in (List<DxfXRecordValue>) xrecord.Values)
        this.method_133(dxfXrecordValue, dataStream);
      this.interface29_0.imethod_33((int) dataStream.Length);
      this.interface29_0.imethod_13(dataStream.GetBuffer(), 0, (int) dataStream.Length);
      if (this.dxfVersion_0 >= DxfVersion.Dxf15)
        this.interface29_0.imethod_32((short) xrecord.DuplicateRecordCloningFlag);
      this.method_82((DxfHandledObject) xrecord);
    }

    private void method_136(MemoryStream stream, string value)
    {
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
      {
        if (string.IsNullOrEmpty(value))
        {
          stream.Write(LittleEndianBitConverter.GetBytes((short) 0), 0, 2);
        }
        else
        {
          stream.Write(LittleEndianBitConverter.GetBytes((short) value.Length), 0, 2);
          byte[] bytes = Encoding.Unicode.GetBytes(value);
          stream.Write(bytes, 0, bytes.Length);
        }
      }
      else if (string.IsNullOrEmpty(value))
      {
        stream.Write(LittleEndianBitConverter.GetBytes((short) 0), 0, 2);
        stream.WriteByte((byte) this.int_0);
      }
      else
      {
        byte[] bytes = this.encoding_0.GetBytes(value);
        stream.Write(LittleEndianBitConverter.GetBytes((short) bytes.Length), 0, 2);
        stream.WriteByte((byte) this.int_0);
        stream.Write(bytes, 0, bytes.Length);
      }
    }

    public void Visit(DxfGroup group)
    {
      group.vmethod_7(this);
      this.interface29_0.imethod_4(group.Description);
      this.interface29_0.imethod_32(group.IsAnonymous ? (short) 1 : (short) 0);
      this.interface29_0.imethod_32(group.Selectable ? (short) 1 : (short) 0);
      this.interface29_0.imethod_33(group.Members.Count);
      foreach (DxfHandledObject member in (IEnumerable<DxfHandledObject>) group.Members)
        this.interface29_0.imethod_41(member);
      this.method_82((DxfHandledObject) group);
    }

    private void method_137(MemoryStream stream, double value)
    {
      stream.Write(LittleEndianBitConverter.GetBytes(value), 0, 8);
    }

    private void method_138(MemoryStream stream, short value)
    {
      stream.Write(LittleEndianBitConverter.GetBytes(value), 0, 2);
    }

    private void method_139(MemoryStream stream, int value)
    {
      stream.Write(LittleEndianBitConverter.GetBytes(value), 0, 4);
    }

    private void method_140(MemoryStream stream, ulong value)
    {
      stream.Write(LittleEndianBitConverter.GetBytes(value), 0, 8);
    }

    public virtual void Visit(DxfDictionaryVariable dictionaryVariable)
    {
      dictionaryVariable.vmethod_7(this);
      this.interface29_0.imethod_11((byte) 0);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(dictionaryVariable.Value);
      else
        this.interface29_0.imethod_4(dictionaryVariable.Value);
      this.method_82((DxfHandledObject) dictionaryVariable);
    }

    public void Visit(DxfField field)
    {
      field.vmethod_7(this);
      this.interface29_0.imethod_4(field.EvaluatorId);
      this.interface29_0.imethod_4(field.FieldCode);
      this.interface29_0.imethod_33(field.ChildFields.Count);
      foreach (DxfHandledObject childField in (IEnumerable<DxfField>) field.ChildFields)
        this.interface29_0.imethod_39(childField);
      this.interface29_0.imethod_33(field.FieldObjects.Count);
      foreach (DxfHandledObject fieldObject in (IEnumerable<DxfHandledObject>) field.FieldObjects)
        this.interface29_0.imethod_40(fieldObject);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(field.FormatString);
      this.interface29_0.imethod_33((int) field.EvalutationOptionFlags);
      this.interface29_0.imethod_33((int) field.FilingOptionFlags);
      this.interface29_0.imethod_33((int) field.FieldStateFlags);
      this.interface29_0.imethod_33((int) field.EvaluationStatusFlags);
      this.interface29_0.imethod_33(field.EvaluationErrorCode);
      this.interface29_0.imethod_4(field.EvaluationErrorMessage);
      this.method_112(field.Value);
      this.interface29_0.imethod_4(field.ValueString);
      this.interface29_0.imethod_33(field.ValueString.Length);
      this.interface29_0.imethod_33(field.Values.Count);
      foreach (KeyValuePair<string, DxfValue> keyValuePair in (IEnumerable<KeyValuePair<string, DxfValue>>) field.Values)
      {
        this.interface29_0.imethod_4(keyValuePair.Key);
        this.method_112(keyValuePair.Value);
      }
      this.method_82((DxfHandledObject) field);
      foreach (DxfField childField in (IEnumerable<DxfField>) field.ChildFields)
        this.Visit(childField);
    }

    public virtual void Visit(DxfFieldList fieldList)
    {
      fieldList.vmethod_7(this);
      this.interface29_0.imethod_33(fieldList.Fields.Count);
      this.interface29_0.imethod_14(fieldList.Unknown1);
      foreach (DxfHandledObject field in (IEnumerable<DxfField>) fieldList.Fields)
        this.interface29_0.imethod_40(field);
      this.method_82((DxfHandledObject) fieldList);
    }

    public void Visit(DxfGeoData geoData)
    {
      geoData.vmethod_7(this);
      this.method_82((DxfHandledObject) geoData);
    }

    public virtual void Visit(DxfIdBuffer idBuffer)
    {
      idBuffer.vmethod_7(this);
      this.interface29_0.imethod_11(idBuffer.Unknown1);
      this.interface29_0.imethod_33(idBuffer.HandledObjects.Count);
      foreach (DxfHandledObject handledObject in idBuffer.HandledObjects)
        this.interface29_0.imethod_40(handledObject);
      this.method_82((DxfHandledObject) idBuffer);
    }

    public virtual void Visit(DxfPlaceHolder placeHolder)
    {
      placeHolder.vmethod_7(this);
      this.method_82((DxfHandledObject) placeHolder);
    }

    public virtual void Visit(DxfCellStyleMap cellStyleMap)
    {
      cellStyleMap.vmethod_7(this);
      this.interface29_0.imethod_33(cellStyleMap.CellStyles.Count);
      foreach (DxfTableCellStyle cellStyle in (Collection<DxfTableCellStyle>) cellStyleMap.CellStyles)
        this.method_141(cellStyle, true);
      this.method_82((DxfHandledObject) cellStyleMap);
    }

    public virtual void Visit(DxfTableStyle tableStyle)
    {
      tableStyle.vmethod_7(this);
      if (this.dxfVersion_0 < DxfVersion.Dxf24)
      {
        this.interface29_0.imethod_4(tableStyle.Description);
        this.interface29_0.imethod_32((short) tableStyle.FlowDirection);
        this.interface29_0.imethod_32((short) tableStyle.Flags);
        this.interface29_0.imethod_16(tableStyle.HorizontalCellMargin);
        this.interface29_0.imethod_16(tableStyle.VerticalCellMargin);
        this.interface29_0.imethod_14(tableStyle.SuppressTitle);
        this.interface29_0.imethod_14(tableStyle.SuppressHeaderRow);
        this.method_144(tableStyle.DataCellStyle);
        this.method_144(tableStyle.TitleCellStyle);
        this.method_144(tableStyle.HeaderCellStyle);
      }
      else
      {
        this.interface29_0.imethod_11(tableStyle.Unknown1);
        this.interface29_0.imethod_4(tableStyle.Description);
        this.interface29_0.imethod_33(tableStyle.Unknown2);
        this.interface29_0.imethod_33(tableStyle.Unknown3);
        this.interface29_0.imethod_39((DxfHandledObject) null);
        this.method_141(tableStyle.TableCellStyle, true);
        int count = tableStyle.CellStyles.Count;
        if (tableStyle.TitleCellStyle != null && !tableStyle.CellStyles.Contains(tableStyle.TitleCellStyle))
          ++count;
        if (tableStyle.HeaderCellStyle != null && !tableStyle.CellStyles.Contains(tableStyle.HeaderCellStyle))
          ++count;
        if (tableStyle.DataCellStyle != null && !tableStyle.CellStyles.Contains(tableStyle.DataCellStyle))
          ++count;
        this.interface29_0.imethod_33(count);
        int num1 = 1;
        if (tableStyle.TitleCellStyle != null)
        {
          this.interface29_0.imethod_33(num1++);
          this.method_141(tableStyle.TitleCellStyle, true);
        }
        if (tableStyle.HeaderCellStyle != null)
        {
          this.interface29_0.imethod_33(num1++);
          this.method_141(tableStyle.HeaderCellStyle, true);
        }
        if (tableStyle.DataCellStyle != null)
        {
          Interface29 interface290 = this.interface29_0;
          int num2 = num1;
          int num3 = num2 + 1;
          interface290.imethod_33(num2);
          this.method_141(tableStyle.DataCellStyle, true);
        }
        int num4 = 101;
        foreach (DxfTableCellStyle cellStyle in (Collection<DxfTableCellStyle>) tableStyle.CellStyles)
        {
          if (cellStyle != tableStyle.TitleCellStyle && cellStyle != tableStyle.HeaderCellStyle && cellStyle != tableStyle.DataCellStyle)
          {
            this.interface29_0.imethod_33(num4);
            this.method_141(cellStyle, true);
            ++num4;
          }
        }
      }
      this.method_82((DxfHandledObject) tableStyle);
    }

    private void method_141(DxfTableCellStyle cellStyle, bool writeId)
    {
      this.interface29_0.imethod_33((int) cellStyle.TableCellStyleType);
      short dataFlags = cellStyle.DataFlags;
      int num = cellStyle.method_9();
      if (num > 0)
        dataFlags |= (short) 1;
      this.interface29_0.imethod_32(dataFlags);
      if (((int) dataFlags & 1) != 0)
      {
        this.interface29_0.imethod_33((int) cellStyle.CellStylePropertyOverrideFlags);
        this.interface29_0.imethod_33((int) cellStyle.MergeFlags);
        this.interface29_0.imethod_8(cellStyle.BackColor);
        this.interface29_0.imethod_33((int) cellStyle.ContentLayoutFlags);
        this.method_143((DxfContentFormat) cellStyle);
        this.interface29_0.imethod_32(cellStyle.MarginOverrideFlags);
        if (cellStyle.HasMarginOverrides)
        {
          this.interface29_0.imethod_16(cellStyle.VerticalMargin);
          this.interface29_0.imethod_16(cellStyle.HorizontalMargin);
          this.interface29_0.imethod_16(cellStyle.MarginBottom);
          this.interface29_0.imethod_16(cellStyle.MarginRight);
          this.interface29_0.imethod_16(cellStyle.MarginHorizontalSpacing);
          this.interface29_0.imethod_16(cellStyle.MarginVerticalSpacing);
        }
        this.interface29_0.imethod_33(num);
        this.method_142(cellStyle.BorderTop, 1);
        this.method_142(cellStyle.BorderRight, 2);
        this.method_142(cellStyle.BorderBottom, 4);
        this.method_142(cellStyle.BorderLeft, 8);
        this.method_142(cellStyle.BorderInsideVertical, 16);
        this.method_142(cellStyle.BorderInsideHorizontal, 32);
      }
      if (!writeId)
        return;
      this.interface29_0.imethod_33(cellStyle.Id);
      this.interface29_0.imethod_33((int) cellStyle.CellType);
      this.interface29_0.imethod_4(cellStyle.Name);
    }

    private void method_142(DxfTableBorder border, int edgeFlags)
    {
      if (!border.HasData)
        return;
      this.interface29_0.imethod_33(edgeFlags);
      this.interface29_0.imethod_33((int) border.PropertyOverrideFlags);
      this.interface29_0.imethod_33((int) border.BorderType);
      this.interface29_0.imethod_8(border.Color);
      this.interface29_0.imethod_33((int) border.LineWeight);
      this.interface29_0.imethod_41((DxfHandledObject) border.LineType);
      this.interface29_0.imethod_33(border.Visible ? 0 : 1);
      this.interface29_0.imethod_16(border.DoubleLineSpacing);
    }

    private void method_143(DxfContentFormat contentFormat)
    {
      this.interface29_0.imethod_33((int) contentFormat.ContentFormatPropertyOverrideFlags);
      this.interface29_0.imethod_33((int) contentFormat.PropertyFlags);
      this.interface29_0.imethod_33((int) contentFormat.ValueFormat.DataType);
      this.interface29_0.imethod_33((int) contentFormat.ValueFormat.UnitType);
      this.interface29_0.imethod_4(contentFormat.ValueFormat._FormatString);
      this.interface29_0.imethod_16(contentFormat.Rotation);
      this.interface29_0.imethod_16(contentFormat.BlockScale);
      this.interface29_0.imethod_33((int) contentFormat.CellAlignment);
      this.interface29_0.imethod_8(contentFormat.ContentColor);
      this.interface29_0.imethod_41((DxfHandledObject) contentFormat.TextStyle);
      this.interface29_0.imethod_16(contentFormat.TextHeight);
    }

    private void method_144(DxfTableCellStyle cellStyle)
    {
      if (cellStyle.TextStyle == null)
        this.interface29_0.imethod_41((DxfHandledObject) this.dxfModel_0.DefaultTextStyle);
      else
        this.interface29_0.imethod_41((DxfHandledObject) cellStyle.TextStyle);
      this.interface29_0.imethod_16(cellStyle.TextHeight);
      this.interface29_0.imethod_32((short) cellStyle.CellAlignment);
      this.interface29_0.imethod_8(cellStyle.ContentColor);
      this.interface29_0.imethod_8(cellStyle.BackColor);
      this.interface29_0.imethod_14(cellStyle.IsBackColorEnabled);
      this.method_145(cellStyle.BorderTop);
      this.method_145(cellStyle.BorderInsideHorizontal);
      this.method_145(cellStyle.BorderBottom);
      this.method_145(cellStyle.BorderLeft);
      this.method_145(cellStyle.BorderInsideVertical);
      this.method_145(cellStyle.BorderRight);
      if (this.dxfVersion_0 <= DxfVersion.Dxf18)
        return;
      this.method_119(cellStyle.ValueFormat);
    }

    private void method_145(DxfTableBorder border)
    {
      this.interface29_0.imethod_32(border.LineWeight);
      this.interface29_0.imethod_14(border.Visible);
      this.interface29_0.imethod_8(border.Color);
    }

    public void Visit(DxfMLeaderStyle o)
    {
      o.vmethod_7(this);
      this.method_82((DxfHandledObject) o);
    }

    public virtual void Visit(DxfMLineStyle mlineStyle)
    {
      mlineStyle.vmethod_7(this);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_4(mlineStyle.Name);
        this.interface29_0.imethod_4(mlineStyle.Description);
      }
      short num1 = 0;
      if (mlineStyle.DisplayMiters)
        num1 |= (short) 1;
      if (mlineStyle.IsFillOn)
        num1 |= (short) 2;
      if (mlineStyle.StartHasSquareEndCap)
        num1 |= (short) 16;
      if (mlineStyle.StartHasRoundCap)
        num1 |= (short) 32;
      if (mlineStyle.StartHasInnerArcsCap)
        num1 |= (short) 64;
      if (mlineStyle.EndHasSquareCap)
        num1 |= (short) 256;
      if (mlineStyle.EndHasRoundCap)
        num1 |= (short) 512;
      if (mlineStyle.EndHasInnerArcs)
        num1 |= (short) 1024;
      this.interface29_0.imethod_32(num1);
      this.interface29_0.imethod_6(mlineStyle.FillColor);
      this.interface29_0.imethod_16(mlineStyle.StartAngle);
      this.interface29_0.imethod_16(mlineStyle.EndAngle);
      this.interface29_0.imethod_11((byte) mlineStyle.Elements.Count);
      foreach (DxfMLineStyle.Element element in mlineStyle.Elements)
      {
        this.interface29_0.imethod_16(element.Offset);
        this.interface29_0.imethod_6(element.Color);
        if (this.dxfVersion_0 > DxfVersion.Dxf27)
        {
          this.interface29_0.imethod_41((DxfHandledObject) element.LineType);
        }
        else
        {
          short num2 = short.MaxValue;
          if (element.LineType != null && element.LineType != this.dxfModel_0.ByLayerLineType)
          {
            if (element.LineType == this.dxfModel_0.ByBlockLineType)
            {
              num2 = (short) 32766;
            }
            else
            {
              short num3 = -1;
              foreach (DxfLineType lineType in (KeyedDxfHandledObjectCollection<string, DxfLineType>) this.dxfModel_0.LineTypes)
              {
                if (lineType != this.dxfModel_0.ByLayerLineType && lineType != this.dxfModel_0.ByBlockLineType)
                  ++num3;
                if (lineType == element.LineType)
                {
                  num2 = num3;
                  break;
                }
              }
            }
          }
          else
            num2 = short.MaxValue;
          this.interface29_0.imethod_32(num2);
        }
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
      {
        this.interface29_0.imethod_4(mlineStyle.Name);
        this.interface29_0.imethod_4(mlineStyle.Description);
      }
      this.method_82((DxfHandledObject) mlineStyle);
    }

    public virtual void Visit(DxfColor color)
    {
      color.vmethod_7(this);
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
      {
        this.interface29_0.imethod_14(true);
        this.interface29_0.imethod_14(false);
        this.interface29_0.imethod_14(false);
        this.interface29_0.imethod_14(false);
        this.interface29_0.imethod_21(color.Color.Data);
        this.interface29_0.imethod_11(color.Color.ColorType == ColorType.ByColor ? (byte) 3 : (byte) 0);
        if (color.Color.ColorType == ColorType.ByColor)
        {
          this.interface29_0.imethod_4(color.Color.Name);
          this.interface29_0.imethod_4(color.Color.ColorBookName);
        }
      }
      else
        this.interface29_0.imethod_32(DxfIndexedColorSet.GetColorIndex(color.Color.ToArgbColor(DxfIndexedColorSet.AcadClassicIndexedColors)));
      this.method_82((DxfHandledObject) color);
    }

    public virtual void Visit(DxfImageDef imageDefinition)
    {
      imageDefinition.vmethod_7(this);
      this.interface29_0.imethod_33(imageDefinition.ClassVersion);
      this.interface29_0.imethod_20(imageDefinition.Size.X);
      this.interface29_0.imethod_20(imageDefinition.Size.Y);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(imageDefinition.Filename);
      this.interface29_0.imethod_14(imageDefinition.ImageIsLoaded);
      this.interface29_0.imethod_11((byte) imageDefinition.ResolutionUnits);
      this.interface29_0.imethod_20(imageDefinition.DefaultPixelSize.X);
      this.interface29_0.imethod_20(imageDefinition.DefaultPixelSize.Y);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_4(imageDefinition.Filename);
      this.method_82((DxfHandledObject) imageDefinition);
    }

    public virtual void Visit(DxfPlotSettings plotSettings)
    {
      this.method_146(plotSettings);
      this.method_82((DxfHandledObject) plotSettings);
    }

    private void method_146(DxfPlotSettings plotSettings)
    {
      plotSettings.vmethod_7(this);
      this.interface29_0.imethod_4(plotSettings.PageSetupName);
      this.interface29_0.imethod_4(plotSettings.PlotConfigurationFile);
      this.interface29_0.imethod_32((short) plotSettings.PlotLayoutFlags);
      this.interface29_0.imethod_16(plotSettings.UnprintableMarginLeft);
      this.interface29_0.imethod_16(plotSettings.UnprintableMarginBottom);
      this.interface29_0.imethod_16(plotSettings.UnprintableMarginRight);
      this.interface29_0.imethod_16(plotSettings.UnprintableMarginTop);
      this.interface29_0.imethod_16(plotSettings.PlotPaperSize.X);
      this.interface29_0.imethod_16(plotSettings.PlotPaperSize.Y);
      this.interface29_0.imethod_4(plotSettings.PaperSizeName);
      this.interface29_0.imethod_23(plotSettings.PlotOrigin);
      this.interface29_0.imethod_32((short) plotSettings.PlotPaperUnits);
      this.interface29_0.imethod_32((short) plotSettings.PlotRotation);
      this.interface29_0.imethod_32((short) plotSettings.PlotArea);
      this.interface29_0.imethod_23(plotSettings.PlotWindowArea.Corner1);
      this.interface29_0.imethod_23(plotSettings.PlotWindowArea.Corner2);
      if (this.dxfVersion_0 >= DxfVersion.Dxf13 && this.dxfVersion_0 <= DxfVersion.Dxf15)
        this.interface29_0.imethod_4(plotSettings.PlotViewName);
      this.interface29_0.imethod_16(plotSettings.CustomPrintScaleNumerator);
      this.interface29_0.imethod_16(plotSettings.CustomPrintScaleDenominator);
      this.interface29_0.imethod_4(plotSettings.CurrentStyleSheet);
      this.interface29_0.imethod_32(plotSettings.StandardScaleType);
      this.interface29_0.imethod_16(plotSettings.StandardScaleFactor);
      this.interface29_0.imethod_23(plotSettings.PaperImageOrigin);
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
      {
        this.interface29_0.imethod_32((short) plotSettings.ShadePlotMode);
        this.interface29_0.imethod_32((short) plotSettings.ShadePlotResolution);
        this.interface29_0.imethod_32(plotSettings.ShadePlotCustomDpi);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
        this.interface29_0.imethod_41((DxfHandledObject) null);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        return;
      this.interface29_0.imethod_40((DxfHandledObject) null);
    }

    public virtual void Visit(DxfLayout layout)
    {
      this.method_146((DxfPlotSettings) layout);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        this.interface29_0.imethod_4(layout.Name);
      this.interface29_0.imethod_33(layout.TabOrder);
      this.interface29_0.imethod_32((short) layout.Options);
      this.interface29_0.imethod_24(layout.Ucs.Origin);
      this.interface29_0.imethod_25(layout.Limits.Corner1);
      this.interface29_0.imethod_25(layout.Limits.Corner2);
      this.interface29_0.imethod_24(layout.InsertionBasePoint);
      this.interface29_0.imethod_29(layout.Ucs.XAxis);
      this.interface29_0.imethod_29(layout.Ucs.YAxis);
      this.interface29_0.imethod_16(layout.Ucs.Elevation);
      this.interface29_0.imethod_32((short) layout.UcsOrthographicType);
      this.interface29_0.imethod_24(layout.MinExtents);
      this.interface29_0.imethod_24(layout.MaxExtents);
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
        this.interface29_0.imethod_33(layout.Viewports.Count);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
        this.interface29_0.imethod_4(layout.Name);
      this.interface29_0.imethod_40((DxfHandledObject) layout.OwnerBlock);
      this.interface29_0.imethod_40(layout.LastActiveViewport);
      if (layout.UcsOrthographicType == OrthographicType.None)
      {
        this.interface29_0.imethod_41((DxfHandledObject) null);
        this.interface29_0.imethod_41((DxfHandledObject) layout.Ucs);
      }
      else
      {
        this.interface29_0.imethod_41((DxfHandledObject) layout.Ucs);
        this.interface29_0.imethod_41((DxfHandledObject) null);
      }
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
      {
        foreach (DxfHandledObject viewport in (DxfHandledObjectCollection<DxfViewport>) layout.Viewports)
          this.interface29_0.imethod_40(viewport);
      }
      this.method_82((DxfHandledObject) layout);
    }

    public void Visit(DxfFormattedTableData formattedTableData)
    {
      throw new NotImplementedException();
    }

    public void Visit(DxfLinkedData linkedData)
    {
      throw new NotSupportedException();
    }

    public void Visit(DxfLinkedTableData linkedTableData)
    {
      throw new NotImplementedException();
    }

    public void Visit(DxfRasterVariables o)
    {
      o.vmethod_7(this);
      this.method_82((DxfHandledObject) o);
    }

    public void Visit(DxfTableContent tableContent)
    {
      tableContent.vmethod_7(this);
      this.method_105(tableContent);
      this.method_82((DxfHandledObject) tableContent);
    }

    public void Visit(DxfScale scale)
    {
      scale.vmethod_7(this);
      this.method_82((DxfHandledObject) scale);
    }

    public void Visit(DxfMLeaderAnnotationContext o)
    {
      o.vmethod_7(this);
      this.method_82((DxfHandledObject) o);
    }

    public void Visit(DxfMLeaderObjectContextData o)
    {
      o.vmethod_7(this);
      this.method_82((DxfHandledObject) o);
    }

    public void Visit(DxfMTextObjectContextData contextData)
    {
      contextData.vmethod_7(this);
      this.method_82((DxfHandledObject) contextData);
    }

    public void Visit(DxfBlockReferenceObjectContextData contextData)
    {
      contextData.vmethod_7(this);
      this.method_82((DxfHandledObject) contextData);
    }

    public void Visit(DxfToleranceObjectContextData contextData)
    {
      contextData.vmethod_7(this);
      this.method_82((DxfHandledObject) contextData);
    }

    public void Visit(DxfHatchScaleContextData contextData)
    {
      contextData.vmethod_7(this);
      this.method_82((DxfHandledObject) contextData);
    }

    public void Visit(DxfHatchViewContextData contextData)
    {
      contextData.vmethod_7(this);
      this.method_82((DxfHandledObject) contextData);
    }

    public void Visit(DxfTextObjectContextData contextData)
    {
      contextData.vmethod_7(this);
      this.method_82((DxfHandledObject) contextData);
    }

    public void Visit(DxfDimensionObjectContextData.Aligned contextData)
    {
      contextData.vmethod_7(this);
      this.method_82((DxfHandledObject) contextData);
    }

    public void Visit(DxfDimensionObjectContextData.Angular contextData)
    {
      contextData.vmethod_7(this);
      this.method_82((DxfHandledObject) contextData);
    }

    public void Visit(
      DxfDimensionObjectContextData.Diametric contextData)
    {
      contextData.vmethod_7(this);
      this.method_82((DxfHandledObject) contextData);
    }

    public void Visit(DxfDimensionObjectContextData.Ordinate contextData)
    {
      contextData.vmethod_7(this);
      this.method_82((DxfHandledObject) contextData);
    }

    public void Visit(DxfDimensionObjectContextData.Radial contextData)
    {
      contextData.vmethod_7(this);
      this.method_82((DxfHandledObject) contextData);
    }

    public void Visit(DxfAttributeObjectContextData contextData)
    {
      contextData.vmethod_7(this);
      this.method_82((DxfHandledObject) contextData);
    }

    public void Visit(DxfLeaderObjectContextData contextData)
    {
      contextData.vmethod_7(this);
      this.method_82((DxfHandledObject) contextData);
    }

    public void Visit(DxfSortEntsTable sortEntsTable)
    {
      sortEntsTable.vmethod_7(this);
      List<DxfEntitySortWrapper> entitySortWrapperList = new List<DxfEntitySortWrapper>(sortEntsTable.EntitySortWrappers.Count);
      foreach (DxfEntitySortWrapper entitySortWrapper in sortEntsTable.EntitySortWrappers)
      {
        if (entitySortWrapper.Entity != null)
          entitySortWrapperList.Add(entitySortWrapper);
      }
      this.interface29_0.imethod_33(entitySortWrapperList.Count);
      this.interface29_0.imethod_40((DxfHandledObject) sortEntsTable.OwnerBlock);
      foreach (DxfEntitySortWrapper entitySortWrapper in entitySortWrapperList)
      {
        this.interface29_0.imethod_35(new ReferenceType?(), entitySortWrapper.SortHandle);
        this.interface29_0.imethod_40((DxfHandledObject) entitySortWrapper.Entity);
      }
      this.method_82((DxfHandledObject) sortEntsTable);
    }

    public void Visit(DxfSpatialFilter filter)
    {
      filter.vmethod_7(this);
      this.interface29_0.imethod_32((short) filter.ClipBoundaryPoints.Count);
      for (int index = 0; index < filter.ClipBoundaryPoints.Count; ++index)
        this.interface29_0.imethod_25(filter.ClipBoundaryPoints[index]);
      this.interface29_0.imethod_29(filter.ClipBoundaryPlaneNormal);
      this.interface29_0.imethod_24(filter.ClipBoundaryPlaneOrigin);
      this.interface29_0.imethod_32(filter.ClipBoundaryDisplayEnabled ? (short) 1 : (short) 0);
      this.interface29_0.imethod_32(filter.FrontClippingPlaneDistance.HasValue ? (short) 1 : (short) 0);
      if (filter.FrontClippingPlaneDistance.HasValue)
        this.interface29_0.imethod_16(filter.FrontClippingPlaneDistance.Value);
      this.interface29_0.imethod_32(filter.BackClippingPlaneDistance.HasValue ? (short) 1 : (short) 0);
      if (filter.BackClippingPlaneDistance.HasValue)
        this.interface29_0.imethod_16(filter.BackClippingPlaneDistance.Value);
      this.method_147(filter.InverseInsertionTransform);
      this.method_147(filter.ClipBoundaryTransform);
      this.method_82((DxfHandledObject) filter);
    }

    private void method_147(Matrix4D m)
    {
      for (int index1 = 0; index1 < 3; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
          this.interface29_0.imethod_16(m[index1, index2]);
      }
    }

    public void Visit(DxfVisualStyle o)
    {
      o.vmethod_7(this);
      this.method_82((DxfHandledObject) o);
    }

    public void Visit(DxfWipeoutVariables o)
    {
      o.vmethod_7(this);
      this.method_82((DxfHandledObject) o);
    }

    public void Visit(DxfBlockLinearConstraintParameter o)
    {
      o.vmethod_7(this);
      this.method_82((DxfHandledObject) o);
    }

    public void Visit(DxfBlockHorizontalConstraintParameter o)
    {
      o.vmethod_7(this);
      this.method_82((DxfHandledObject) o);
    }

    public void Visit(DxfBlockVerticalConstraintParameter o)
    {
      o.vmethod_7(this);
      this.method_82((DxfHandledObject) o);
    }

    public void Visit(DxfBlockAlignedConstraintParameter o)
    {
      o.vmethod_7(this);
      this.method_82((DxfHandledObject) o);
    }

    public void Visit(DxfBlockAngularConstraintParameter o)
    {
      o.vmethod_7(this);
      this.method_82((DxfHandledObject) o);
    }

    public void Visit(DxfBlockDiametricConstraintParameter o)
    {
      o.vmethod_7(this);
      this.method_82((DxfHandledObject) o);
    }

    public void Visit(DxfBlockRadialConstraintParameter o)
    {
      o.vmethod_7(this);
      this.method_82((DxfHandledObject) o);
    }

    public void Visit(DxfHatch.BoundaryPath.LineEdge edge)
    {
      this.interface29_0.imethod_11((byte) 1);
      this.interface29_0.imethod_25(edge.Start);
      this.interface29_0.imethod_25(edge.End);
    }

    public void Visit(DxfHatch.BoundaryPath.ArcEdge edge)
    {
      this.interface29_0.imethod_11((byte) 2);
      this.interface29_0.imethod_25(edge.Center);
      this.interface29_0.imethod_16(edge.Radius);
      this.interface29_0.imethod_16(edge.StartAngle);
      this.interface29_0.imethod_16(edge.EndAngle);
      this.interface29_0.imethod_14(edge.CounterClockWise);
    }

    public void Visit(DxfHatch.BoundaryPath.EllipseEdge edge)
    {
      this.interface29_0.imethod_11((byte) 3);
      this.interface29_0.imethod_25(edge.Center);
      this.interface29_0.imethod_28(edge.MajorAxisEndPoint);
      this.interface29_0.imethod_16(edge.MinorToMajorRatio);
      this.interface29_0.imethod_16(edge.StartAngle);
      this.interface29_0.imethod_16(edge.EndAngle);
      this.interface29_0.imethod_14(edge.CounterClockWise);
    }

    public void Visit(DxfHatch.BoundaryPath.SplineEdge edge)
    {
      this.interface29_0.imethod_11((byte) 4);
      this.interface29_0.imethod_33(edge.Degree);
      this.interface29_0.imethod_14(edge.Rational);
      this.interface29_0.imethod_14(edge.Periodic);
      this.interface29_0.imethod_33(edge.Knots.Count);
      this.interface29_0.imethod_33(edge.ControlPoints.Count);
      for (int index = 0; index < edge.Knots.Count; ++index)
        this.interface29_0.imethod_16(edge.Knots[index]);
      for (int index = 0; index < edge.ControlPoints.Count; ++index)
      {
        this.interface29_0.imethod_25(edge.ControlPoints[index]);
        if (edge.Rational)
          this.interface29_0.imethod_16(edge.Weights[index]);
      }
      if (this.dxfVersion_0 <= DxfVersion.Dxf21)
        return;
      if (edge.FitPointData == null)
      {
        this.interface29_0.imethod_33(0);
      }
      else
      {
        this.interface29_0.imethod_33(edge.FitPointData.FitPoints.Count);
        if (edge.FitPointData == null || edge.FitPointData.FitPoints.Count <= 0)
          return;
        foreach (WW.Math.Point2D fitPoint in edge.FitPointData.FitPoints)
          this.interface29_0.imethod_25(fitPoint);
        this.interface29_0.imethod_28(edge.FitPointData.StartTangent);
        this.interface29_0.imethod_28(edge.FitPointData.EndTangent);
      }
    }

    private class Class433 : IExtendedDataValueVisitor
    {
      private MemoryStream memoryStream_0;
      private DxfVersion dxfVersion_0;
      private Encoding encoding_0;
      private int int_0;

      public Class433(
        MemoryStream stream,
        DxfVersion version,
        Encoding encoding,
        DrawingCodePage drawingCodePage)
      {
        this.memoryStream_0 = stream;
        this.dxfVersion_0 = version;
        this.encoding_0 = encoding;
        this.int_0 = (int) Class952.smethod_1(drawingCodePage);
      }

      public MemoryStream Stream
      {
        get
        {
          return this.memoryStream_0;
        }
      }

      public void Reset()
      {
        this.memoryStream_0.Position = 0L;
        this.memoryStream_0.SetLength(0L);
      }

      public void Visit(DxfExtendedData.BinaryData value)
      {
        this.memoryStream_0.WriteByte((byte) 4);
        if (value.Value.Length >= 256)
          throw new ArgumentOutOfRangeException("Extended data binary data length may not be longer than 255 bytes.");
        this.memoryStream_0.WriteByte((byte) value.Value.Length);
        this.memoryStream_0.Write(value.Value, 0, value.Value.Length);
      }

      public void Visit(DxfExtendedData.DatabaseHandle value)
      {
        this.memoryStream_0.WriteByte((byte) 5);
        ulong num = 0;
        if (value.Value != null)
          num = value.Value.Handle;
        this.memoryStream_0.Write(BigEndianBitConverter.GetBytes(num), 0, 8);
      }

      public void Visit(DxfExtendedData.Distance value)
      {
        this.memoryStream_0.WriteByte((byte) 41);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.Value), 0, 8);
      }

      public void Visit(DxfExtendedData.Double value)
      {
        this.memoryStream_0.WriteByte((byte) 40);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.Value), 0, 8);
      }

      public void Visit(DxfExtendedData.Int32 value)
      {
        this.memoryStream_0.WriteByte((byte) 71);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.Value), 0, 4);
      }

      public void Visit(DxfExtendedData.LayerReference value)
      {
        this.memoryStream_0.WriteByte((byte) 3);
        this.memoryStream_0.Write(BigEndianBitConverter.GetBytes(value.Value == null ? 0UL : value.Value.Handle), 0, 8);
      }

      public void Visit(DxfExtendedData.PointOrVector value)
      {
        this.memoryStream_0.WriteByte((byte) 10);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.X), 0, 8);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.Y), 0, 8);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.Z), 0, 8);
      }

      public void Visit(DxfExtendedData.ScaleFactor value)
      {
        this.memoryStream_0.WriteByte((byte) 42);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.Value), 0, 8);
      }

      public void Visit(DxfExtendedData.Int16 value)
      {
        this.memoryStream_0.WriteByte((byte) 70);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.Value), 0, 2);
      }

      public void Visit(DxfExtendedData.String value)
      {
        this.memoryStream_0.WriteByte((byte) 0);
        if (this.dxfVersion_0 < DxfVersion.Dxf21)
        {
          if (string.IsNullOrEmpty(value.Value))
          {
            this.memoryStream_0.WriteByte((byte) 0);
            this.memoryStream_0.WriteByte((byte) 0);
            this.memoryStream_0.WriteByte((byte) (this.int_0 & (int) byte.MaxValue));
          }
          else
          {
            if (value.Value.Length >= (int) short.MaxValue)
              throw new ArgumentOutOfRangeException("Extended data string length may not be longer than 32767 characters for version 18 and earlier.");
            this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes((short) value.Value.Length), 0, 2);
            this.memoryStream_0.WriteByte((byte) (this.int_0 & (int) byte.MaxValue));
            byte[] bytes = this.encoding_0.GetBytes(value.Value);
            this.memoryStream_0.Write(bytes, 0, bytes.Length);
          }
        }
        else if (string.IsNullOrEmpty(value.Value))
        {
          this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes((ushort) 0), 0, 2);
        }
        else
        {
          this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes((ushort) value.Value.Length), 0, 2);
          byte[] bytes = Encoding.Unicode.GetBytes(value.Value);
          this.memoryStream_0.Write(bytes, 0, bytes.Length);
        }
      }

      public void Visit(DxfExtendedData.Bracket value)
      {
        this.memoryStream_0.WriteByte((byte) 2);
        this.memoryStream_0.WriteByte(value.IsClosingBracket ? (byte) 1 : (byte) 0);
      }

      public void Visit(DxfExtendedData.WorldDirection value)
      {
        this.memoryStream_0.WriteByte((byte) 13);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.X), 0, 8);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.Y), 0, 8);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.Z), 0, 8);
      }

      public void Visit(DxfExtendedData.WorldSpaceDisplacement value)
      {
        this.memoryStream_0.WriteByte((byte) 12);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.X), 0, 8);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.Y), 0, 8);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.Z), 0, 8);
      }

      public void Visit(DxfExtendedData.WorldSpacePosition value)
      {
        this.memoryStream_0.WriteByte((byte) 11);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.X), 0, 8);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.Y), 0, 8);
        this.memoryStream_0.Write(LittleEndianBitConverter.GetBytes(value.Z), 0, 8);
      }

      public void Visit(DxfExtendedData.ValueCollection value)
      {
        this.memoryStream_0.WriteByte((byte) 2);
        this.memoryStream_0.WriteByte((byte) 0);
        foreach (IExtendedDataValue extendedDataValue in (List<IExtendedDataValue>) value)
          extendedDataValue.Accept((IExtendedDataValueVisitor) this);
        this.memoryStream_0.WriteByte((byte) 2);
        this.memoryStream_0.WriteByte((byte) 1);
      }
    }
  }
}
