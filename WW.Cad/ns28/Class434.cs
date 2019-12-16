// Decompiled with JetBrains decompiler
// Type: ns28.Class434
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns1;
using ns2;
using ns27;
using ns3;
using ns37;
using ns42;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using WW;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.InventorDrawing;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Objects.DynamicBlock;
using WW.Cad.Model.Tables;
using WW.IO;
using WW.Math;
using WW.Math.Geometry;

namespace ns28
{
  internal class Class434
  {
    private Dictionary<short, Delegate24> dictionary_1 = new Dictionary<short, Delegate24>();
    private Dictionary<short, Delegate24> dictionary_2 = new Dictionary<short, Delegate24>();
    private Dictionary<short, UnsupportedObject> dictionary_3 = new Dictionary<short, UnsupportedObject>();
    private DwgReader dwgReader_0;
    private Class374 class374_0;
    private DxfModel dxfModel_0;
    private Interface30 interface30_0;
    private PagedMemoryStream pagedMemoryStream_0;
    private Interface30 interface30_1;
    private Interface30 interface30_2;
    private Interface30 interface30_3;
    private Interface30 interface30_4;
    private Interface30 interface30_5;
    private Interface30 interface30_6;
    private Interface30 interface30_7;
    private Dictionary<ulong, Class799> dictionary_0;
    private Class799 class799_0;
    private long long_0;
    private short short_0;
    private uint uint_0;
    private uint uint_1;
    private uint uint_2;
    private uint uint_3;

    private void method_0(Class260 objectBuilder, bool readCommonData)
    {
      if (readCommonData)
      {
        this.method_94((Class259) objectBuilder);
      }
      else
      {
        this.method_97((Class259) objectBuilder);
        if (objectBuilder.Object.Handle != 0UL)
          this.method_96((Class259) objectBuilder);
      }
      DxfEvalGraphExpression evalGraphExpression = (DxfEvalGraphExpression) objectBuilder.Object;
      evalGraphExpression.UnknownField = this.interface30_1.imethod_11();
      evalGraphExpression.VersionMajor = this.interface30_1.imethod_11();
      evalGraphExpression.VersionMinor = this.interface30_1.imethod_11();
      evalGraphExpression.DataValue = this.method_223(true);
      evalGraphExpression.NodeId = new DxfEvalGraph.GraphNodeId(this.interface30_1.imethod_11());
    }

    private void method_1(Class260 objectBuilder, bool readCommonData)
    {
      this.method_0(objectBuilder, readCommonData);
      DxfBlockElement dxfBlockElement = (DxfBlockElement) objectBuilder.Object;
      dxfBlockElement.Name = this.interface30_1.ReadString();
      dxfBlockElement.VersionMajor = this.interface30_1.imethod_11();
      dxfBlockElement.VersionMinor = this.interface30_1.imethod_11();
      dxfBlockElement.UnknownField = this.interface30_1.imethod_11();
    }

    private void method_2(Class260 objectBuilder, bool readCommonData)
    {
      this.method_1(objectBuilder, readCommonData);
      DxfBlockParameter dxfBlockParameter = (DxfBlockParameter) objectBuilder.Object;
      dxfBlockParameter.ShowProperties = this.interface30_1.imethod_6();
      dxfBlockParameter.ChainActions = this.interface30_1.imethod_6();
    }

    private void method_3(Class268 objectBuilder)
    {
      this.method_1((Class260) objectBuilder, true);
      DxfBlockAction dxfBlockAction = (DxfBlockAction) objectBuilder.Object;
      dxfBlockAction.Position = this.interface30_1.imethod_39();
      int length1 = this.interface30_1.imethod_11();
      ulong[] numArray = new ulong[length1];
      for (int index = 0; index < length1; ++index)
        numArray[index] = this.interface30_1.imethod_32(false);
      objectBuilder.AttachedEntities = numArray;
      int length2 = this.interface30_1.imethod_11();
      DxfEvalGraph.GraphNodeId[] graphNodeIdArray = new DxfEvalGraph.GraphNodeId[length2];
      for (int index = 0; index < length2; ++index)
        graphNodeIdArray[index] = new DxfEvalGraph.GraphNodeId(this.interface30_1.imethod_11());
      dxfBlockAction.AttachedElements = graphNodeIdArray;
    }

    private void method_4(Class268 objectBuilder)
    {
      this.method_3(objectBuilder);
      DxfBlockBasePointAction blockBasePointAction = (DxfBlockBasePointAction) objectBuilder.Object;
      blockBasePointAction.BasePoint = this.interface30_1.imethod_39();
      blockBasePointAction.Connections[0] = this.method_6();
      blockBasePointAction.Connections[1] = this.method_6();
      blockBasePointAction.IndependentFlag = !this.interface30_1.imethod_6();
      blockBasePointAction.Offset = this.interface30_1.imethod_39();
    }

    internal DxfBlockParametersValueSet method_5()
    {
      DxfBlockParametersValueSet parametersValueSet = new DxfBlockParametersValueSet();
      parametersValueSet.ValueSetFlags = (byte) this.interface30_1.imethod_11();
      parametersValueSet.BoundedBelow = this.interface30_1.imethod_8();
      parametersValueSet.BoundedAbove = this.interface30_1.imethod_8();
      parametersValueSet.Increment = this.interface30_1.imethod_8();
      int length = this.interface30_1.imethod_11();
      if (length != 0)
      {
        double[] numArray = new double[length];
        for (int index = 0; index < length; ++index)
          numArray[index] = this.interface30_1.imethod_8();
        parametersValueSet.List = numArray;
      }
      else
        parametersValueSet.List = (double[]) null;
      return parametersValueSet;
    }

    private DxfConnectionPoint method_6()
    {
      return new DxfConnectionPoint() { ConnectionPointId = new DxfEvalGraph.GraphNodeId(this.interface30_1.imethod_11()), ConnectionString = this.interface30_1.ReadString() };
    }

    private DxfBlockParameterPropertyInfo method_7()
    {
      DxfBlockParameterPropertyInfo parameterPropertyInfo = new DxfBlockParameterPropertyInfo();
      short num = this.interface30_1.imethod_14();
      parameterPropertyInfo.ConnectionPoints = new DxfConnectionPoint[(int) num];
      for (short index = 0; (int) index < (int) num; ++index)
        parameterPropertyInfo.ConnectionPoints[(int) index] = this.method_6();
      return parameterPropertyInfo;
    }

    internal void method_8(Class260 objectBuilder, bool readCommonData = true)
    {
      this.method_2(objectBuilder, readCommonData);
      DxfBlockTwoPointsParameter twoPointsParameter = (DxfBlockTwoPointsParameter) objectBuilder.Object;
      twoPointsParameter.FirstPoint = this.interface30_1.imethod_39();
      twoPointsParameter.SecondPoint = this.interface30_1.imethod_39();
      DxfBlockParameterPropertyInfo[] parameterPropertyInfoArray = new DxfBlockParameterPropertyInfo[4];
      for (int index = 0; index < 4; ++index)
        parameterPropertyInfoArray[index] = this.method_7();
      twoPointsParameter.Properties = parameterPropertyInfoArray;
      DxfEvalGraph.GraphNodeId[] graphNodeIdArray = new DxfEvalGraph.GraphNodeId[4];
      for (int index = 0; index < 4; ++index)
        graphNodeIdArray[index] = new DxfEvalGraph.GraphNodeId(this.interface30_1.imethod_11());
      twoPointsParameter.GripIds = graphNodeIdArray;
      twoPointsParameter.BasePoint = (DxfBlockTwoPointsParameter.PointType) this.interface30_1.imethod_14();
    }

    private void method_9(Class260 objectBuilder)
    {
      this.method_2(objectBuilder, true);
      DxfBlockSinglePointParameter singlePointParameter = (DxfBlockSinglePointParameter) objectBuilder.Object;
      singlePointParameter.BasePoint = this.interface30_1.imethod_39();
      singlePointParameter.FirstProperty = this.method_7();
      singlePointParameter.SecondProperty = this.method_7();
      singlePointParameter.GripId = new DxfEvalGraph.GraphNodeId(this.interface30_1.imethod_11());
    }

    private void method_10(Class272 objectBuilder)
    {
      this.method_9((Class260) objectBuilder);
      DxfBlockUserParameter blockUserParameter = (DxfBlockUserParameter) objectBuilder.Object;
      blockUserParameter.UnknownInt16 = this.interface30_1.imethod_14();
      objectBuilder.Variable = this.interface30_1.imethod_32(false);
      blockUserParameter.UnknownString = this.interface30_1.ReadString();
      blockUserParameter.Unknown = this.method_223(true);
      blockUserParameter.ValueType = this.interface30_1.imethod_14();
    }

    private void method_11(Class260 objectBuilder)
    {
      this.method_9(objectBuilder);
      DxfBlockBasePointParameter basePointParameter = (DxfBlockBasePointParameter) objectBuilder.Object;
      basePointParameter.BasePoint1 = this.interface30_1.imethod_39();
      basePointParameter.BasePoint2 = this.interface30_1.imethod_39();
    }

    private void method_12(Class260 objectBuilder)
    {
      this.method_8(objectBuilder, true);
      DxfBlockPolarParameter blockPolarParameter = (DxfBlockPolarParameter) objectBuilder.Object;
      blockPolarParameter.LabelText = this.interface30_1.ReadString();
      blockPolarParameter.Description = this.interface30_1.ReadString();
      blockPolarParameter.AngleLabelText = this.interface30_1.ReadString();
      blockPolarParameter.AngleDescription = this.interface30_1.ReadString();
      blockPolarParameter.LabelOffset = this.interface30_1.imethod_8();
      blockPolarParameter.Distance = this.method_5();
      blockPolarParameter.Angle = this.method_5();
    }

    private void method_13(Class268 objectBuilder)
    {
      this.method_4(objectBuilder);
      DxfBlockScaleAction blockScaleAction = (DxfBlockScaleAction) objectBuilder.Object;
      DxfConnectionPoint[] dxfConnectionPointArray = new DxfConnectionPoint[3]{ this.method_6(), this.method_6(), this.method_6() };
      blockScaleAction.ActionConnections = dxfConnectionPointArray;
      blockScaleAction.ScaleType = (DxfBlockAction.ScaleTypeXY) this.interface30_1.imethod_18();
    }

    private void method_14(Class268 objectBuilder)
    {
      this.method_3(objectBuilder);
      DxfBlockArrayAction blockArrayAction = (DxfBlockArrayAction) objectBuilder.Object;
      DxfConnectionPoint[] dxfConnectionPointArray = new DxfConnectionPoint[4]{ this.method_6(), this.method_6(), this.method_6(), this.method_6() };
      blockArrayAction.ActionConnections = dxfConnectionPointArray;
      blockArrayAction.RowOffset = this.interface30_1.imethod_8();
      blockArrayAction.ColumnOffset = this.interface30_1.imethod_8();
    }

    private void method_15(Class270 objectBuilder)
    {
      this.method_3((Class268) objectBuilder);
      DxfBlockPolarStretchAction polarStretchAction = (DxfBlockPolarStretchAction) objectBuilder.Object;
      DxfConnectionPoint[] dxfConnectionPointArray = new DxfConnectionPoint[6]{ this.method_6(), this.method_6(), this.method_6(), this.method_6(), this.method_6(), this.method_6() };
      polarStretchAction.ActionConnections = dxfConnectionPointArray;
      int length1 = this.interface30_1.imethod_11();
      WW.Math.Point2D[] point2DArray = new WW.Math.Point2D[length1];
      for (int index = 0; index < length1; ++index)
        point2DArray[index] = this.interface30_1.imethod_38();
      polarStretchAction.Frame = point2DArray;
      int length2 = this.interface30_1.imethod_11();
      ulong[] numArray1 = new ulong[length2];
      for (int index = 0; index < length2; ++index)
        numArray1[index] = this.interface30_1.imethod_32(false);
      objectBuilder.RotateSelection = numArray1;
      polarStretchAction.RotateSelection = (DxfHandledObjectCollection<DxfHandledObject>) null;
      int length3 = this.interface30_1.imethod_11();
      DxfBlockPolarStretchAction.StretchEntity[] stretchEntityArray = new DxfBlockPolarStretchAction.StretchEntity[length3];
      ulong[] numArray2 = new ulong[length3];
      for (int index1 = 0; index1 < length3; ++index1)
      {
        numArray2[index1] = this.interface30_1.imethod_32(false);
        stretchEntityArray[index1].Entity = (DxfHandledObject) null;
        int length4 = this.interface30_1.imethod_11();
        stretchEntityArray[index1].PointIndexes = new int[length4];
        for (int index2 = 0; index2 < length4; ++index2)
          stretchEntityArray[index1].PointIndexes[index2] = this.interface30_1.imethod_11();
      }
      polarStretchAction.StretchEntities = stretchEntityArray;
      objectBuilder.RotateSelection = numArray1;
      objectBuilder.StretchEntities = numArray2;
      int length5 = this.interface30_1.imethod_11();
      DxfBlockPolarStretchAction.StretchNode[] stretchNodeArray = new DxfBlockPolarStretchAction.StretchNode[length5];
      for (int index1 = 0; index1 < length5; ++index1)
      {
        stretchNodeArray[index1].Node = new DxfEvalGraph.GraphNodeId(this.interface30_1.imethod_11());
        int length4 = this.interface30_1.imethod_11();
        stretchNodeArray[index1].PointIndexes = new int[length4];
        for (int index2 = 0; index2 < length4; ++index2)
          stretchNodeArray[index1].PointIndexes[index2] = this.interface30_1.imethod_11();
      }
      polarStretchAction.StretchNodes = stretchNodeArray;
      this.method_18((DxfBlockAngleOffsetAction) polarStretchAction, true);
    }

    private void method_16(Class269 objectBuilder)
    {
      this.method_3((Class268) objectBuilder);
      DxfBlockStretchAction blockStretchAction = (DxfBlockStretchAction) objectBuilder.Object;
      DxfConnectionPoint[] dxfConnectionPointArray = new DxfConnectionPoint[2]{ this.method_6(), this.method_6() };
      blockStretchAction.ActionConnections = dxfConnectionPointArray;
      int length1 = this.interface30_1.imethod_11();
      WW.Math.Point2D[] point2DArray = new WW.Math.Point2D[length1];
      for (int index = 0; index < length1; ++index)
        point2DArray[index] = this.interface30_1.imethod_38();
      blockStretchAction.Frame = point2DArray;
      int length2 = this.interface30_1.imethod_11();
      DxfBlockPolarStretchAction.StretchEntity[] stretchEntityArray = new DxfBlockPolarStretchAction.StretchEntity[length2];
      ulong[] numArray = new ulong[length2];
      for (int index1 = 0; index1 < length2; ++index1)
      {
        numArray[index1] = this.interface30_1.imethod_32(false);
        int length3 = this.interface30_1.imethod_11();
        stretchEntityArray[index1].PointIndexes = new int[length3];
        for (int index2 = 0; index2 < length3; ++index2)
          stretchEntityArray[index1].PointIndexes[index2] = this.interface30_1.imethod_11();
      }
      objectBuilder.StretchEntities = numArray;
      blockStretchAction.StretchEntities = stretchEntityArray;
      int length4 = this.interface30_1.imethod_11();
      DxfBlockPolarStretchAction.StretchNode[] stretchNodeArray = new DxfBlockPolarStretchAction.StretchNode[length4];
      for (int index1 = 0; index1 < length4; ++index1)
      {
        stretchNodeArray[index1].Node = new DxfEvalGraph.GraphNodeId(this.interface30_1.imethod_11());
        int length3 = this.interface30_1.imethod_11();
        stretchNodeArray[index1].PointIndexes = new int[length3];
        for (int index2 = 0; index2 < length3; ++index2)
          stretchNodeArray[index1].PointIndexes[index2] = this.interface30_1.imethod_11();
      }
      blockStretchAction.StretchNodes = stretchNodeArray;
      this.method_18((DxfBlockAngleOffsetAction) blockStretchAction, false);
    }

    private void method_17(Class268 objectBuilder)
    {
      this.method_3(objectBuilder);
      DxfBlockMoveAction dxfBlockMoveAction = (DxfBlockMoveAction) objectBuilder.Object;
      DxfConnectionPoint[] dxfConnectionPointArray = new DxfConnectionPoint[2]{ this.method_6(), this.method_6() };
      dxfBlockMoveAction.ActionConnections = dxfConnectionPointArray;
      this.method_18((DxfBlockAngleOffsetAction) dxfBlockMoveAction, false);
    }

    private void method_18(DxfBlockAngleOffsetAction o, bool extendedVariant)
    {
      o.DistanceCoefficient = this.interface30_1.imethod_8();
      o.AngleOffset = this.interface30_1.imethod_8();
      DxfBlockAngleOffsetAction angleOffsetAction = o;
      o.Unknown2 = 0;
      angleOffsetAction.Unknown1 = 0;
      if (extendedVariant)
      {
        o.ScaleType = (DxfBlockAction.ScaleTypeXY) this.interface30_1.imethod_11();
        if (o.ScaleType == DxfBlockAction.ScaleTypeXY.X)
        {
          o.Unknown1 = this.interface30_1.imethod_11();
        }
        else
        {
          if (o.ScaleType != DxfBlockAction.ScaleTypeXY.Y)
            return;
          o.Unknown1 = this.interface30_1.imethod_11();
          o.Unknown2 = this.interface30_1.imethod_11();
        }
      }
      else
        o.ScaleType = (DxfBlockAction.ScaleTypeXY) this.interface30_1.imethod_18();
    }

    private void method_19(Class268 objectBuilder)
    {
      this.method_3(objectBuilder);
      DxfBlockLookupAction blockLookupAction = (DxfBlockLookupAction) objectBuilder.Object;
      blockLookupAction.NumberOfRows = this.interface30_1.imethod_11();
      blockLookupAction.NumberOfColumns = this.interface30_1.imethod_11();
      string[] strArray = new string[blockLookupAction.NumberOfRows * blockLookupAction.NumberOfColumns];
      for (int index = 0; index < strArray.Length; ++index)
        strArray[index] = this.interface30_1.ReadString();
      blockLookupAction.Text = strArray;
      DxfLookupActionInformation[] actionInformationArray = new DxfLookupActionInformation[blockLookupAction.NumberOfColumns];
      for (int index = 0; index < actionInformationArray.Length; ++index)
        actionInformationArray[index] = this.method_20();
      blockLookupAction.Information = actionInformationArray;
      blockLookupAction.UnknownFlag = this.interface30_1.imethod_6();
    }

    private DxfLookupActionInformation method_20()
    {
      return new DxfLookupActionInformation() { Id = new DxfEvalGraph.GraphNodeId(this.interface30_1.imethod_11()), ResourceType = this.interface30_1.imethod_11(), Type = this.interface30_1.imethod_11(), PropertyType = this.interface30_1.imethod_6(), Unmatched = this.interface30_1.ReadString(), AllowEditing = this.interface30_1.imethod_6(), ConnectionText = this.interface30_1.ReadString() };
    }

    private void method_21(Class268 objectBuilder)
    {
      this.method_3(objectBuilder);
      ((DxfBlockFlipAction) objectBuilder.Object).ActionConnections = new DxfConnectionPoint[4]
      {
        this.method_6(),
        this.method_6(),
        this.method_6(),
        this.method_6()
      };
    }

    private void method_22(Class268 objectBuilder)
    {
      this.method_4(objectBuilder);
      ((DxfBlockRotateAction) objectBuilder.Object).ActionConnection = this.method_6();
    }

    private void method_23(Class260 objectBuilder)
    {
      this.method_8(objectBuilder, true);
      DxfBlockRotationParameter rotationParameter = (DxfBlockRotationParameter) objectBuilder.Object;
      rotationParameter.StartPoint = this.interface30_1.imethod_39();
      rotationParameter.LabelText = this.interface30_1.ReadString();
      rotationParameter.Description = this.interface30_1.ReadString();
      rotationParameter.LabelOffset = this.interface30_1.imethod_8();
      rotationParameter.Angle = this.method_5();
    }

    private void method_24(Class260 objectBuilder)
    {
      this.method_8(objectBuilder, true);
      DxfBlockXYParameter blockXyParameter = (DxfBlockXYParameter) objectBuilder.Object;
      blockXyParameter.LabelTextY = this.interface30_1.ReadString();
      blockXyParameter.LabelTextX = this.interface30_1.ReadString();
      blockXyParameter.DescriptionY = this.interface30_1.ReadString();
      blockXyParameter.DescriptionX = this.interface30_1.ReadString();
      blockXyParameter.LabelOffsetX = this.interface30_1.imethod_8();
      blockXyParameter.LabelOffsetY = this.interface30_1.imethod_8();
      blockXyParameter.ParameterValueSetX = this.method_5();
      blockXyParameter.ParameterValueSetY = this.method_5();
    }

    private void method_25(Class260 objectBuilder)
    {
      this.method_8(objectBuilder, true);
      DxfBlockLinearParameter blockLinearParameter = (DxfBlockLinearParameter) objectBuilder.Object;
      blockLinearParameter.LabelText = this.interface30_1.ReadString();
      blockLinearParameter.Description = this.interface30_1.ReadString();
      blockLinearParameter.LabelOffset = this.interface30_1.imethod_8();
      blockLinearParameter.Distance = this.method_5();
    }

    private void method_26(Class260 objectBuilder)
    {
      this.method_8(objectBuilder, true);
      DxfBlockFlipParameter blockFlipParameter = (DxfBlockFlipParameter) objectBuilder.Object;
      blockFlipParameter.LabelText = this.interface30_1.ReadString();
      blockFlipParameter.Description = this.interface30_1.ReadString();
      blockFlipParameter.NotFlippedState = this.interface30_1.ReadString();
      blockFlipParameter.FlippedState = this.interface30_1.ReadString();
      blockFlipParameter.LabelPosition = this.interface30_1.imethod_39();
      blockFlipParameter.Connection = this.method_6();
    }

    private void method_27(Class260 objectBuilder)
    {
      this.method_1(objectBuilder, true);
      DxfBlockGrip dxfBlockGrip = (DxfBlockGrip) objectBuilder.Object;
      dxfBlockGrip.GripExpression1 = new DxfEvalGraph.GraphNodeId(this.interface30_1.imethod_11());
      dxfBlockGrip.GripExpression2 = new DxfEvalGraph.GraphNodeId(this.interface30_1.imethod_11());
      dxfBlockGrip.Position = this.interface30_1.imethod_39();
      dxfBlockGrip.CyclingFlag = this.interface30_1.imethod_6();
      dxfBlockGrip.CyclingWeight = this.interface30_1.imethod_11();
    }

    private void method_28(Class260 objectBuilder)
    {
      this.method_27(objectBuilder);
      DxfBlockAlignmentGrip blockAlignmentGrip = (DxfBlockAlignmentGrip) objectBuilder.Object;
      WW.Math.Vector3D vector3D;
      vector3D.X = this.interface30_1.imethod_8();
      vector3D.Y = this.interface30_1.imethod_8();
      vector3D.Z = this.interface30_1.imethod_8();
      blockAlignmentGrip.Alignment = vector3D;
    }

    private void method_29(Class260 objectBuilder)
    {
      this.method_0(objectBuilder, true);
      ((DxfBlockGripExpression) objectBuilder.Object).ActionConnection = this.method_6();
    }

    private void method_30(Class260 objectBuilder)
    {
      this.method_0(objectBuilder, true);
    }

    private void method_31(Class260 objectBuilder)
    {
      this.method_27(objectBuilder);
      DxfBlockLinearGrip dxfBlockLinearGrip = (DxfBlockLinearGrip) objectBuilder.Object;
      WW.Math.Vector3D vector3D;
      vector3D.X = this.interface30_1.imethod_8();
      vector3D.Y = this.interface30_1.imethod_8();
      vector3D.Z = this.interface30_1.imethod_8();
      dxfBlockLinearGrip.Distance = vector3D;
    }

    private void method_32(Class260 objectBuilder)
    {
      this.method_27(objectBuilder);
      DxfBlockFlipGrip dxfBlockFlipGrip = (DxfBlockFlipGrip) objectBuilder.Object;
      dxfBlockFlipGrip.FlipExpression = new DxfEvalGraph.GraphNodeId(this.interface30_1.imethod_11());
      WW.Math.Vector3D vector3D;
      vector3D.X = this.interface30_1.imethod_8();
      vector3D.Y = this.interface30_1.imethod_8();
      vector3D.Z = this.interface30_1.imethod_8();
      dxfBlockFlipGrip.Orientation = vector3D;
    }

    private void method_33(Class260 objectBuilder)
    {
      this.method_94((Class259) objectBuilder);
      ((DxfBlockRepresentationData) objectBuilder.Object).Version = this.interface30_1.imethod_14();
      Class277 class277 = objectBuilder as Class277;
      if (class277 != null)
      {
        class277.DynamicBlockHandle = this.interface30_1.imethod_32(false);
      }
      else
      {
        long num = (long) this.interface30_1.imethod_32(false);
      }
    }

    private void method_34(Class260 objectBuilder)
    {
      this.method_33(objectBuilder);
    }

    private void method_35(Class260 objectBuilder)
    {
      this.method_8(objectBuilder, true);
      ((DxfBlockAlignmentParameter) objectBuilder.Object).IsPerpendicular = this.interface30_1.imethod_6();
    }

    private void method_36(Class260 objectBuilder)
    {
      this.method_9(objectBuilder);
      DxfBlockLookUpParameter blockLookUpParameter = (DxfBlockLookUpParameter) objectBuilder.Object;
      blockLookUpParameter.ActionId = new DxfEvalGraph.GraphNodeId(this.interface30_1.imethod_11());
      blockLookUpParameter.LabelText = this.interface30_1.ReadString();
      blockLookUpParameter.Description = this.interface30_1.ReadString();
    }

    private void method_37(Class260 objectBuilder)
    {
      this.method_9(objectBuilder);
      DxfBlockPointParameter blockPointParameter = (DxfBlockPointParameter) objectBuilder.Object;
      blockPointParameter.LabelText = this.interface30_1.ReadString();
      blockPointParameter.Description = this.interface30_1.ReadString();
      blockPointParameter.LabelPosition = this.interface30_1.imethod_39();
    }

    private DxfVisibilityState method_38(
      ref ulong[] selectionSet1,
      ref ulong[] selectionSet2)
    {
      DxfVisibilityState dxfVisibilityState = new DxfVisibilityState();
      dxfVisibilityState.Name = this.interface30_1.ReadString();
      int length1 = this.interface30_1.imethod_11();
      selectionSet1 = new ulong[length1];
      for (int index = 0; index < length1; ++index)
        selectionSet1[index] = this.interface30_1.imethod_32(false);
      int length2 = this.interface30_1.imethod_11();
      selectionSet2 = new ulong[length2];
      for (int index = 0; index < length2; ++index)
        selectionSet2[index] = this.interface30_1.imethod_32(false);
      return dxfVisibilityState;
    }

    private void method_39(Class267 objectBuilder)
    {
      this.method_9((Class260) objectBuilder);
      DxfBlockVisibilityParameter visibilityParameter = (DxfBlockVisibilityParameter) objectBuilder.Object;
      visibilityParameter.UnknownFlag = this.interface30_1.imethod_6();
      visibilityParameter.LabelText = this.interface30_1.ReadString();
      visibilityParameter.Description = this.interface30_1.ReadString();
      visibilityParameter.UnknownFlag2 = this.interface30_1.imethod_6();
      int length1 = this.interface30_1.imethod_11();
      ulong[] numArray1 = new ulong[length1];
      for (int index = 0; index < length1; ++index)
        numArray1[index] = this.interface30_1.imethod_32(false);
      int length2 = this.interface30_1.imethod_11();
      ulong[][] numArray2 = new ulong[length2][];
      ulong[][] numArray3 = new ulong[length2][];
      DxfVisibilityState[] dxfVisibilityStateArray = new DxfVisibilityState[length2];
      for (int index = 0; index < length2; ++index)
        dxfVisibilityStateArray[index] = this.method_38(ref numArray2[index], ref numArray3[index]);
      visibilityParameter.VisibilityStates = dxfVisibilityStateArray;
      objectBuilder.HandleSet = numArray1;
      objectBuilder.SelectionSet1 = numArray2;
      objectBuilder.SelectionSet2 = numArray3;
    }

    private DxfBlockPropertiesTableColumnDefinition method_40(
      ref ulong parameterHandle,
      ref ulong unknownHandle)
    {
      DxfBlockPropertiesTableColumnDefinition columnDefinition = new DxfBlockPropertiesTableColumnDefinition();
      parameterHandle = this.method_100();
      columnDefinition.Parameter = (DxfObject) null;
      columnDefinition.UnknownInt1 = this.interface30_1.imethod_14();
      columnDefinition.UnknownInt2 = this.interface30_1.imethod_14();
      columnDefinition.UnknownString1 = this.interface30_1.ReadString();
      columnDefinition.ConnectionPoint.ConnectionString = this.interface30_1.ReadString();
      columnDefinition.ConnectionPoint.ConnectionPointId = new DxfEvalGraph.GraphNodeId(this.interface30_1.imethod_11());
      columnDefinition.UnknownValue1 = this.method_223(true);
      columnDefinition.DefaultDoNotMatchValue = this.method_223(true);
      columnDefinition.UnknownFlag1 = this.interface30_1.imethod_6();
      columnDefinition.UnknownFlag2 = this.interface30_1.imethod_6();
      columnDefinition.UnknownFlag3 = this.interface30_1.imethod_6();
      columnDefinition.UnknownFlag4 = this.interface30_1.imethod_6();
      columnDefinition.UnknownFlag5 = this.interface30_1.imethod_6();
      columnDefinition.UnknownString2 = this.interface30_1.ReadString();
      unknownHandle = this.method_100();
      columnDefinition.UnknownObject1 = (DxfObject) null;
      return columnDefinition;
    }

    private void method_41(Class260 objectBuilder)
    {
      this.method_9(objectBuilder);
      Class271 class271 = objectBuilder as Class271;
      DxfBlockPropertiesTable blockPropertiesTable = (DxfBlockPropertiesTable) objectBuilder.Object;
      blockPropertiesTable.NodeId = new DxfEvalGraph.GraphNodeId(this.interface30_1.imethod_11());
      blockPropertiesTable.TableName = this.interface30_1.ReadString();
      blockPropertiesTable.DescriptionString = this.interface30_1.ReadString();
      int length1 = this.interface30_1.imethod_11();
      blockPropertiesTable.ColumnInformation = new DxfBlockPropertiesTableColumnDefinition[length1];
      ulong[] numArray1 = new ulong[length1];
      ulong[] numArray2 = new ulong[length1];
      for (int index = 0; index < length1; ++index)
        blockPropertiesTable.ColumnInformation[index] = this.method_40(ref numArray1[index], ref numArray2[index]);
      class271.Parameters = numArray1;
      class271.DxfObjects2 = numArray2;
      int length2 = this.interface30_1.imethod_11();
      blockPropertiesTable.Data = new DxfXRecordValue[length1][];
      for (int index = 0; index < length1; ++index)
        blockPropertiesTable.Data[index] = new DxfXRecordValue[length2];
      blockPropertiesTable.DataNodeId = new int[length2];
      for (int index1 = 0; index1 < length2; ++index1)
      {
        blockPropertiesTable.DataNodeId[index1] = this.interface30_1.imethod_11();
        for (int index2 = 0; index2 < length1; ++index2)
          blockPropertiesTable.Data[index2][index1] = this.method_223(true);
      }
      blockPropertiesTable.Unknown1 = this.interface30_1.imethod_11();
      blockPropertiesTable.PropertiesCanBeModifiedIndividually = this.interface30_1.imethod_6();
      blockPropertiesTable.UnknownFlag2 = this.interface30_1.imethod_6();
      blockPropertiesTable.UnknownFlag3 = this.interface30_1.imethod_6();
    }

    private void method_42()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockPointParameter());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_37(objectBuilder);
    }

    private void method_43()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockLookUpParameter());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_36(objectBuilder);
    }

    private void method_44()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockBasePointParameter());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_11(objectBuilder);
    }

    private void method_45()
    {
      Class272 objectBuilder = new Class272(new DxfBlockUserParameter());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_10(objectBuilder);
    }

    private void method_46()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockPolarParameter());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_12(objectBuilder);
    }

    private void method_47()
    {
      Class268 objectBuilder = new Class268((DxfBlockAction) new DxfBlockFlipAction());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_21(objectBuilder);
    }

    private void method_48()
    {
      Class268 objectBuilder = new Class268((DxfBlockAction) new DxfBlockLookupAction());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_19(objectBuilder);
    }

    private void method_49()
    {
      Class268 objectBuilder = new Class268((DxfBlockAction) new DxfBlockMoveAction());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_17(objectBuilder);
    }

    private void method_50()
    {
      Class269 objectBuilder = new Class269(new DxfBlockStretchAction());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_16(objectBuilder);
    }

    private void method_51()
    {
      Class270 objectBuilder = new Class270(new DxfBlockPolarStretchAction());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_15(objectBuilder);
    }

    private void method_52()
    {
      Class268 objectBuilder = new Class268((DxfBlockAction) new DxfBlockArrayAction());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_14(objectBuilder);
    }

    private void method_53()
    {
      Class268 objectBuilder = new Class268((DxfBlockAction) new DxfBlockScaleAction());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_13(objectBuilder);
    }

    private void method_54()
    {
      Class268 objectBuilder = new Class268((DxfBlockAction) new DxfBlockRotateAction());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_22(objectBuilder);
    }

    private void method_55()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockRotationParameter());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_23(objectBuilder);
    }

    private void method_56()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockXYParameter());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_24(objectBuilder);
    }

    private void method_57()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockLinearParameter());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_25(objectBuilder);
    }

    private void method_58()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockFlipParameter());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_26(objectBuilder);
    }

    private void method_59()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockAlignmentGrip());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_28(objectBuilder);
    }

    private void method_60()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockFlipGrip());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_32(objectBuilder);
    }

    private void method_61()
    {
      Class260 objectBuilder = (Class260) new Class277(new DxfBlockRepresentationData());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_33(objectBuilder);
    }

    private void method_62()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockPurgePreventer());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_34(objectBuilder);
    }

    private void method_63()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockLinearGrip());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_31(objectBuilder);
    }

    private void method_64()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockLookupGrip());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_27(objectBuilder);
    }

    private void method_65()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockPolarGrip());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_27(objectBuilder);
    }

    private void method_66()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockPropertiesTableGrip());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_27(objectBuilder);
    }

    private void method_67()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockRotationGrip());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_27(objectBuilder);
    }

    private void method_68()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockVisibilityGrip());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_27(objectBuilder);
    }

    private void method_69()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockXYGrip());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_27(objectBuilder);
    }

    private void method_70()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockGripExpression());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_29(objectBuilder);
    }

    private void method_71()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfDynamicBlockProxyNode());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_30(objectBuilder);
    }

    private void method_72()
    {
      Class260 objectBuilder = new Class260((DxfObject) new DxfBlockAlignmentParameter());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_35(objectBuilder);
    }

    private void method_73()
    {
      Class267 objectBuilder = new Class267(new DxfBlockVisibilityParameter());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_39(objectBuilder);
    }

    private void method_74()
    {
      Class260 objectBuilder = (Class260) new Class271((DxfEvalGraphExpression) new DxfBlockPropertiesTable());
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_41(objectBuilder);
    }

    private void method_75()
    {
      DxfEvalGraph dxfEvalGraph = new DxfEvalGraph();
      Class276 class276 = new Class276(dxfEvalGraph);
      this.class374_0.ObjectBuilders.Add((Class259) class276);
      this.method_94((Class259) class276);
      dxfEvalGraph.LastNodeId = new DxfEvalGraph.GraphNodeId(this.interface30_1.imethod_11());
      this.interface30_1.imethod_11();
      int length1 = this.interface30_1.imethod_11();
      ulong[] numArray = new ulong[length1];
      DxfEvalGraph.GraphNode[] graphNodeArray = new DxfEvalGraph.GraphNode[length1];
      for (int index = 0; index < length1; ++index)
      {
        this.interface30_1.imethod_11();
        this.interface30_1.imethod_11();
        graphNodeArray[index] = new DxfEvalGraph.GraphNode();
        graphNodeArray[index].Id = new DxfEvalGraph.GraphNodeId(this.interface30_1.imethod_11());
        numArray[index] = this.method_100();
        graphNodeArray[index].FirstIncomingEdge = this.interface30_1.imethod_11();
        graphNodeArray[index].LastIncomingEdge = this.interface30_1.imethod_11();
        graphNodeArray[index].FirstOutgoingEdge = this.interface30_1.imethod_11();
        graphNodeArray[index].LastOutgoingEdge = this.interface30_1.imethod_11();
      }
      dxfEvalGraph.Nodes = graphNodeArray;
      int length2 = this.interface30_1.imethod_11();
      DxfEvalGraph.GraphEdge[] graphEdgeArray = new DxfEvalGraph.GraphEdge[length2];
      for (int index = 0; index < length2; ++index)
      {
        this.interface30_1.imethod_11();
        graphEdgeArray[index] = new DxfEvalGraph.GraphEdge();
        graphEdgeArray[index].Flags = this.interface30_1.imethod_11();
        graphEdgeArray[index].ReferenceCount = this.interface30_1.imethod_11();
        graphEdgeArray[index].StartNode = this.interface30_1.imethod_11();
        graphEdgeArray[index].EndNode = this.interface30_1.imethod_11();
        graphEdgeArray[index].PreviousIncoming = this.interface30_1.imethod_11();
        graphEdgeArray[index].NextIncoming = this.interface30_1.imethod_11();
        graphEdgeArray[index].PreviousOutgoing = this.interface30_1.imethod_11();
        graphEdgeArray[index].NextOutgoing = this.interface30_1.imethod_11();
        graphEdgeArray[index].ReverseEdgeIndex = this.interface30_1.imethod_11();
      }
      dxfEvalGraph.Edges = graphEdgeArray;
      class276.ExpressionHandles = numArray;
    }

    public Class434(
      DwgReader dwgReader,
      Class374 builder,
      Interface30 bitStream,
      Dictionary<ulong, Class799> handleToDwgObjectInfo)
    {
      this.dwgReader_0 = dwgReader;
      this.class374_0 = builder;
      this.dxfModel_0 = builder.Model;
      this.interface30_0 = bitStream;
      this.dictionary_0 = handleToDwgObjectInfo;
      this.method_84();
      this.interface30_5 = this.method_83((Stream) null, false);
      this.interface30_6 = this.method_83((Stream) null, false);
      this.interface30_7 = this.method_83((Stream) null, false);
    }

    public Interface30 ObjectBitStream
    {
      get
      {
        return this.interface30_1;
      }
    }

    public Class374 Builder
    {
      get
      {
        return this.class374_0;
      }
    }

    public DxfVersion Version
    {
      get
      {
        return this.class374_0.Version;
      }
    }

    public void method_76(ProgressEventHandler progress)
    {
      int num1 = 0;
      int num2 = 50;
      progress((object) this, new ProgressEventArgs(0.0f));
      while (this.dwgReader_0.OwnedObjectHandles.Count > 0)
      {
        Class799 class799;
        if (this.dictionary_0.TryGetValue(this.dwgReader_0.OwnedObjectHandles.Dequeue(), out class799) && class799.HandledObjectInfo == null)
        {
          this.class799_0 = class799;
          this.interface30_0.StreamPosition = class799.StreamPosition;
          this.method_79();
          short num3 = this.method_82();
          Delegate24 delegate24;
          if (num3 >= (short) 500)
            this.dictionary_2.TryGetValue(num3, out delegate24);
          else
            this.dictionary_1.TryGetValue(num3, out delegate24);
          if (delegate24 != null)
            delegate24();
          else
            this.method_80(num3);
          this.pagedMemoryStream_0.Dispose();
          ++num1;
          --num2;
          if (num2 == 0)
          {
            progress((object) this, new ProgressEventArgs((float) num1 / (float) this.dictionary_0.Count));
            num2 = 50;
          }
        }
      }
      this.method_85();
      this.method_81();
    }

    public void method_77(Class259 objectBuilder)
    {
      this.class374_0.ObjectBuilders.Add(objectBuilder);
    }

    public void method_78(System.Action<DxfObjectReference> setObjectReference)
    {
      this.class374_0.method_10(this.method_100(), setObjectReference);
    }

    private void method_79()
    {
      this.interface30_1 = (Interface30) null;
      this.interface30_2 = (Interface30) null;
      this.interface30_3 = (Interface30) null;
      this.interface30_4 = (Interface30) null;
    }

    private void method_80(short objectType)
    {
      UnsupportedObject unsupportedObject;
      if (!this.dictionary_3.TryGetValue(objectType, out unsupportedObject))
      {
        unsupportedObject = new UnsupportedObject();
        unsupportedObject.DwgObjectType = objectType;
        this.dictionary_3.Add(objectType, unsupportedObject);
      }
      ++unsupportedObject.Count;
    }

    private void method_81()
    {
      foreach (UnsupportedObject unsupportedObject in this.dictionary_3.Values)
      {
        DxfClass classWithClassNumber = this.dxfModel_0.Classes.GetClassWithClassNumber(unsupportedObject.DwgObjectType);
        if (classWithClassNumber != null)
        {
          unsupportedObject.Name = classWithClassNumber.DxfName;
        }
        else
        {
          switch (unsupportedObject.DwgObjectType)
          {
            case 33:
              unsupportedObject.Name = "SHAPE";
              break;
            case 39:
              unsupportedObject.Name = "BODY";
              break;
            case 74:
              unsupportedObject.Name = "OLE2FRAME";
              break;
          }
        }
        this.dxfModel_0.UnsupportedObjects.Add(unsupportedObject);
      }
    }

    private short method_82()
    {
      Stream1 stream1 = new Stream1(this.interface30_0.Stream, (ushort) 49345);
      this.uint_0 = (uint) Class992.smethod_4((Stream) stream1);
      if (this.uint_0 <= 0U)
        throw new Exception("Zero object size.");
      uint sizeInBits = this.uint_0 << 3;
      if (this.class374_0.Version > DxfVersion.Dxf21)
      {
        this.uint_3 = (uint) Class992.smethod_5((Stream) stream1);
        this.uint_2 = sizeInBits - this.uint_3;
        this.pagedMemoryStream_0 = Class1045.smethod_1((Stream) stream1, (long) this.uint_0, this.dwgReader_0.MemoryPageCache);
        this.interface30_2 = this.interface30_5;
        this.interface30_2.imethod_54((Stream) this.pagedMemoryStream_0, this.uint_2);
        this.interface30_4 = this.interface30_7;
        this.interface30_4.imethod_54((Stream) Class1045.smethod_0(this.pagedMemoryStream_0), this.uint_3);
        this.interface30_4.imethod_4((long) this.uint_2);
        this.interface30_3 = this.interface30_6;
        this.interface30_3.imethod_54((Stream) Class1045.smethod_0(this.pagedMemoryStream_0), this.uint_2);
        this.uint_1 = (uint) this.interface30_3.imethod_5((long) (this.uint_2 - 1U));
        this.interface30_2.SizeInBits = this.uint_1;
        this.interface30_1 = (Interface30) new Class1048(this.interface30_2, this.interface30_3, this.interface30_4);
      }
      else
      {
        this.pagedMemoryStream_0 = Class1045.smethod_1((Stream) stream1, (long) this.uint_0, this.dwgReader_0.MemoryPageCache);
        this.interface30_1 = this.interface30_5;
        this.interface30_5.imethod_54((Stream) this.pagedMemoryStream_0, sizeInBits);
        this.interface30_2 = this.interface30_1;
        this.interface30_3 = this.interface30_1;
        this.interface30_4 = (Interface30) null;
      }
      this.long_0 = this.interface30_2.imethod_3();
      short num1 = this.interface30_2.imethod_55();
      int crc = (int) stream1.Crc;
      long streamPosition = this.interface30_0.StreamPosition;
      this.interface30_0.StreamPosition += (long) this.uint_0;
      int num2 = (int) Class1045.smethod_5(this.interface30_0.Stream);
      this.interface30_0.StreamPosition = streamPosition;
      this.short_0 = num1;
      return num1;
    }

    private Interface30 method_83(Stream stream, bool enableLogging)
    {
      Interface30 nterface30 = Class444.Create(this.class374_0.Version, this.dwgReader_0, stream, enableLogging);
      nterface30.Encoding = this.interface30_0.Encoding;
      return nterface30;
    }

    private void method_84()
    {
      this.dictionary_1.Add((short) 1, new Delegate24(this.method_129));
      this.dictionary_1.Add((short) 2, new Delegate24(this.method_133));
      this.dictionary_1.Add((short) 3, new Delegate24(this.method_134));
      this.dictionary_1.Add((short) 4, new Delegate24(this.method_138));
      this.dictionary_1.Add((short) 5, new Delegate24(this.method_139));
      this.dictionary_1.Add((short) 6, new Delegate24(this.method_140));
      this.dictionary_1.Add((short) 7, new Delegate24(this.method_141));
      this.dictionary_1.Add((short) 8, new Delegate24(this.method_144));
      this.dictionary_1.Add((short) 10, new Delegate24(this.method_145));
      this.dictionary_1.Add((short) 11, new Delegate24(this.method_146));
      this.dictionary_1.Add((short) 12, new Delegate24(this.method_146));
      this.dictionary_1.Add((short) 13, new Delegate24(this.method_146));
      this.dictionary_1.Add((short) 14, new Delegate24(this.method_147));
      this.dictionary_1.Add((short) 15, new Delegate24(this.method_148));
      this.dictionary_1.Add((short) 16, new Delegate24(this.method_149));
      this.dictionary_1.Add((short) 17, new Delegate24(this.method_150));
      this.dictionary_1.Add((short) 18, new Delegate24(this.method_135));
      this.dictionary_1.Add((short) 19, new Delegate24(this.method_151));
      this.dictionary_1.Add((short) 20, new Delegate24(this.method_152));
      this.dictionary_1.Add((short) 21, new Delegate24(this.method_156));
      this.dictionary_1.Add((short) 22, new Delegate24(this.method_157));
      this.dictionary_1.Add((short) 23, new Delegate24(this.method_159));
      this.dictionary_1.Add((short) 24, new Delegate24(this.method_160));
      this.dictionary_1.Add((short) 25, new Delegate24(this.method_161));
      this.dictionary_1.Add((short) 26, new Delegate24(this.method_162));
      this.dictionary_1.Add((short) 27, new Delegate24(this.method_163));
      this.dictionary_1.Add((short) 28, new Delegate24(this.method_164));
      this.dictionary_1.Add((short) 29, new Delegate24(this.method_165));
      this.dictionary_1.Add((short) 30, new Delegate24(this.method_166));
      this.dictionary_1.Add((short) 31, new Delegate24(this.method_168));
      this.dictionary_1.Add((short) 32, new Delegate24(this.method_168));
      this.dictionary_1.Add((short) 33, new Delegate24(this.method_167));
      this.dictionary_1.Add((short) 34, new Delegate24(this.method_169));
      this.dictionary_1.Add((short) 35, new Delegate24(this.method_170));
      this.dictionary_1.Add((short) 36, new Delegate24(this.method_180));
      this.dictionary_1.Add((short) 37, new Delegate24(this.method_173));
      this.dictionary_1.Add((short) 38, new Delegate24(this.method_175));
      this.dictionary_1.Add((short) 39, new Delegate24(this.method_174));
      this.dictionary_1.Add((short) 40, new Delegate24(this.method_181));
      this.dictionary_1.Add((short) 41, new Delegate24(this.method_182));
      this.dictionary_1.Add((short) 42, new Delegate24(this.method_200));
      this.dictionary_1.Add((short) 44, new Delegate24(this.method_183));
      this.dictionary_1.Add((short) 45, new Delegate24(this.method_184));
      this.dictionary_1.Add((short) 46, new Delegate24(this.method_185));
      this.dictionary_1.Add((short) 47, new Delegate24(this.method_186));
      this.dictionary_1.Add((short) 48, new Delegate24(this.method_105));
      this.dictionary_1.Add((short) 49, new Delegate24(this.method_106));
      this.dictionary_1.Add((short) 50, new Delegate24(this.method_110));
      this.dictionary_1.Add((short) 51, new Delegate24(this.method_111));
      this.dictionary_1.Add((short) 52, new Delegate24(this.method_107));
      this.dictionary_1.Add((short) 53, new Delegate24(this.method_108));
      this.dictionary_1.Add((short) 56, new Delegate24(this.method_113));
      this.dictionary_1.Add((short) 57, new Delegate24(this.method_114));
      this.dictionary_1.Add((short) 60, new Delegate24(this.method_117));
      this.dictionary_1.Add((short) 61, new Delegate24(this.method_118));
      this.dictionary_1.Add((short) 62, new Delegate24(this.method_119));
      this.dictionary_1.Add((short) 63, new Delegate24(this.method_120));
      this.dictionary_1.Add((short) 64, new Delegate24(this.method_121));
      this.dictionary_1.Add((short) 65, new Delegate24(this.method_122));
      this.dictionary_1.Add((short) 66, new Delegate24(this.method_123));
      this.dictionary_1.Add((short) 67, new Delegate24(this.method_124));
      this.dictionary_1.Add((short) 68, new Delegate24(this.method_125));
      this.dictionary_1.Add((short) 69, new Delegate24(this.method_126));
      this.dictionary_1.Add((short) 70, new Delegate24(this.method_127));
      this.dictionary_1.Add((short) 71, new Delegate24(this.method_128));
      this.dictionary_1.Add((short) 72, new Delegate24(this.method_216));
      this.dictionary_1.Add((short) 73, new Delegate24(this.method_217));
      this.dictionary_1.Add((short) 74, new Delegate24(this.method_137));
      this.dictionary_1.Add((short) 77, new Delegate24(this.method_204<DxfLwPolyline>));
      this.dictionary_1.Add((short) 78, new Delegate24(this.method_197));
      if (this.class374_0.IsVersion15OrLater)
        this.dictionary_1.Add((short) 79, new Delegate24(this.method_225));
      if (this.class374_0.IsVersion18OrLater)
      {
        this.dictionary_1.Add((short) 80, new Delegate24(this.method_212));
        this.dictionary_1.Add((short) 82, new Delegate24(this.method_222));
      }
      this.dictionary_1.Add((short) 498, new Delegate24(this.method_204<DxfProxyEntity>));
      foreach (DxfClass dxfClass in (List<DxfClass>) this.class374_0.Model.Classes)
      {
        Delegate24 delegate24 = (Delegate24) null;
        switch (dxfClass.CPlusPlusClassName)
        {
          case "AcDbLeaderObjectContextData":
            delegate24 = new Delegate24(this.method_204<DxfLeaderObjectContextData>);
            break;
          case "AcDbMTextAttributeObjectContextData":
            delegate24 = new Delegate24(this.method_204<DxfAttributeObjectContextData>);
            break;
          case "AcDbTextObjectContextData":
            delegate24 = new Delegate24(this.method_204<DxfTextObjectContextData>);
            break;
          case "AcDbHatchViewContextData":
            delegate24 = new Delegate24(this.method_204<DxfHatchViewContextData>);
            break;
          case "AcDbHatchScaleContextData":
            delegate24 = new Delegate24(this.method_204<DxfHatchScaleContextData>);
            break;
          case "AcDbFcfObjectContextData":
            delegate24 = new Delegate24(this.method_204<DxfToleranceObjectContextData>);
            break;
          case "AcDbBlkRefObjectContextData":
            delegate24 = new Delegate24(this.method_204<DxfBlockReferenceObjectContextData>);
            break;
          case "AcDbAlignedDimensionObjectContextData":
            delegate24 = new Delegate24(this.method_204<DxfDimensionObjectContextData.Aligned>);
            break;
          case "AcDbAngularDimensionObjectContextData":
            delegate24 = new Delegate24(this.method_204<DxfDimensionObjectContextData.Angular>);
            break;
          case "AcDbDiametricDimensionObjectContextData":
            delegate24 = new Delegate24(this.method_204<DxfDimensionObjectContextData.Diametric>);
            break;
          case "AcDbOrdinateDimensionObjectContextData":
            delegate24 = new Delegate24(this.method_204<DxfDimensionObjectContextData.Ordinate>);
            break;
          case "AcDbRadialDimensionObjectContextData":
            delegate24 = new Delegate24(this.method_204<DxfDimensionObjectContextData.Radial>);
            break;
          case "AcDbMTextObjectContextData":
            delegate24 = new Delegate24(this.method_204<DxfMTextObjectContextData>);
            break;
          case "AcDbDataTable":
            delegate24 = new Delegate24(this.method_204<DxfDataTable>);
            break;
          case "AcDbDictionaryVar":
            delegate24 = new Delegate24(this.method_218);
            break;
          case "AcDbDictionaryWithDefault":
            delegate24 = new Delegate24(this.method_203);
            break;
          case "AcDbEvalGraph":
            delegate24 = new Delegate24(this.method_75);
            break;
          case "AcDbBlockRepresentationData":
            delegate24 = new Delegate24(this.method_61);
            break;
          case "AcDbDynamicBlockPurgePreventer":
            delegate24 = new Delegate24(this.method_62);
            break;
          case "AcDbBlockPointParameter":
            delegate24 = new Delegate24(this.method_42);
            break;
          case "AcDbBlockLookupParameter":
            delegate24 = new Delegate24(this.method_43);
            break;
          case "AcDbBlockVisibilityParameter":
            delegate24 = new Delegate24(this.method_73);
            break;
          case "AcDbBlockPropertiesTable":
            delegate24 = new Delegate24(this.method_74);
            break;
          case "AcDbBlockAlignmentParameter":
            delegate24 = new Delegate24(this.method_72);
            break;
          case "AcDbBlockRotationParameter":
            delegate24 = new Delegate24(this.method_55);
            break;
          case "AcDbBlockLinearParameter":
            delegate24 = new Delegate24(this.method_57);
            break;
          case "AcDbBlockXYParameter":
            delegate24 = new Delegate24(this.method_56);
            break;
          case "AcDbBlockPolarParameter":
            delegate24 = new Delegate24(this.method_46);
            break;
          case "AcDbBlockFlipParameter":
            delegate24 = new Delegate24(this.method_58);
            break;
          case "AcDbBlockBasepointParameter":
            delegate24 = new Delegate24(this.method_44);
            break;
          case "AcDbBlockUserParameter":
            delegate24 = new Delegate24(this.method_45);
            break;
          case "AcDbBlockRotateAction":
            delegate24 = new Delegate24(this.method_54);
            break;
          case "AcDbBlockLookupAction":
            delegate24 = new Delegate24(this.method_48);
            break;
          case "AcDbBlockArrayAction":
            delegate24 = new Delegate24(this.method_52);
            break;
          case "AcDbBlockStretchAction":
            delegate24 = new Delegate24(this.method_50);
            break;
          case "AcDbBlockPolarStretchAction":
            delegate24 = new Delegate24(this.method_51);
            break;
          case "AcDbBlockMoveAction":
            delegate24 = new Delegate24(this.method_49);
            break;
          case "AcDbBlockFlipAction":
            delegate24 = new Delegate24(this.method_47);
            break;
          case "AcDbBlockScaleAction":
            delegate24 = new Delegate24(this.method_53);
            break;
          case "AcDbBlockAlignmentGrip":
            delegate24 = new Delegate24(this.method_59);
            break;
          case "AcDbBlockFlipGrip":
            delegate24 = new Delegate24(this.method_60);
            break;
          case "AcDbBlockLinearGrip":
            delegate24 = new Delegate24(this.method_63);
            break;
          case "AcDbBlockLookupGrip":
            delegate24 = new Delegate24(this.method_64);
            break;
          case "AcDbBlockPolarGrip":
            delegate24 = new Delegate24(this.method_65);
            break;
          case "AcDbBlockPropertiesTableGrip":
            delegate24 = new Delegate24(this.method_66);
            break;
          case "AcDbBlockRotationGrip":
            delegate24 = new Delegate24(this.method_67);
            break;
          case "AcDbBlockVisibilityGrip":
            delegate24 = new Delegate24(this.method_68);
            break;
          case "AcDbBlockXYGrip":
            delegate24 = new Delegate24(this.method_69);
            break;
          case "AcDbBlockGripExpr":
            delegate24 = new Delegate24(this.method_70);
            break;
          case "AcDbDynamicBlockProxyNode":
            delegate24 = new Delegate24(this.method_71);
            break;
          case "AcDbField":
            delegate24 = new Delegate24(this.method_209);
            break;
          case "AcDbFieldList":
            delegate24 = new Delegate24(this.method_210);
            break;
          case "AcDbGeoData":
            delegate24 = new Delegate24(this.method_204<DxfGeoData>);
            break;
          case "AcDbHatch":
            delegate24 = new Delegate24(this.method_197);
            break;
          case "AcDbIdBuffer":
            delegate24 = new Delegate24(this.method_211);
            break;
          case "AcDbWipeout":
            delegate24 = new Delegate24(this.method_199);
            break;
          case "AcDbRasterImage":
            delegate24 = new Delegate24(this.method_198);
            break;
          case "AcDbRasterImageDef":
            delegate24 = new Delegate24(this.method_219);
            break;
          case "AcDbPlotSettings":
            delegate24 = new Delegate24(this.method_220);
            break;
          case "AcDbLayout":
            delegate24 = new Delegate24(this.method_222);
            break;
          case "AcDbPolyline":
            delegate24 = new Delegate24(this.method_204<DxfLwPolyline>);
            break;
          case "AcDbMLeader":
            delegate24 = new Delegate24(this.method_204<DxfMLeader>);
            break;
          case "AcDbMLeaderStyle":
            delegate24 = new Delegate24(this.method_204<DxfMLeaderStyle>);
            break;
          case "AcDbMLeaderObjectContextData":
            delegate24 = new Delegate24(this.method_204<DxfMLeaderObjectContextData>);
            break;
          case "AcDbPlaceHolder":
            delegate24 = new Delegate24(this.method_212);
            break;
          case "AcDbXrecord":
            delegate24 = new Delegate24(this.method_225);
            break;
          case "AcDbColor":
            delegate24 = new Delegate24(this.method_227);
            break;
          case "AcDbRasterVariables":
            delegate24 = new Delegate24(this.method_204<DxfRasterVariables>);
            break;
          case "AcDbScale":
            delegate24 = new Delegate24(this.method_204<DxfScale>);
            break;
          case "AcDbSortentsTable":
            delegate24 = new Delegate24(this.method_205);
            break;
          case "AcDbSpatialFilter":
            delegate24 = new Delegate24(this.method_206);
            break;
          case "AcDbTable":
            delegate24 = new Delegate24(this.method_187);
            break;
          case "AcDbTableStyle":
            delegate24 = new Delegate24(this.method_213);
            break;
          case "AcDbCellStyleMap":
            delegate24 = new Delegate24(this.method_246);
            break;
          case "AcDbLinkedData":
            delegate24 = new Delegate24(this.method_228);
            break;
          case "AcDbLinkedTableData":
            delegate24 = new Delegate24(this.method_230);
            break;
          case "AcDbFormattedTableData":
            delegate24 = new Delegate24(this.method_232);
            break;
          case "AcDbTableContent":
            delegate24 = new Delegate24(this.method_234);
            break;
          case "AcIdBlockReference":
            delegate24 = new Delegate24(this.method_136);
            break;
          case "AcDbVisualStyle":
            delegate24 = new Delegate24(this.method_204<DxfVisualStyle>);
            break;
          case "AcDbWipeoutVariables":
            delegate24 = new Delegate24(this.method_204<DxfWipeoutVariables>);
            break;
          case "AcDbBlockLinearConstraintParameter":
            delegate24 = new Delegate24(this.method_204<DxfBlockLinearConstraintParameter>);
            break;
          case "AcDbBlockHorizontalConstraintParameter":
            delegate24 = new Delegate24(this.method_204<DxfBlockHorizontalConstraintParameter>);
            break;
          case "AcDbBlockVerticalConstraintParameter":
            delegate24 = new Delegate24(this.method_204<DxfBlockVerticalConstraintParameter>);
            break;
          case "AcDbBlockAlignedConstraintParameter":
            delegate24 = new Delegate24(this.method_204<DxfBlockAlignedConstraintParameter>);
            break;
          case "AcDbBlockAngularConstraintParameter":
            delegate24 = new Delegate24(this.method_204<DxfBlockAngularConstraintParameter>);
            break;
          case "AcDbBlockDiametricConstraintParameter":
            delegate24 = new Delegate24(this.method_204<DxfBlockDiametricConstraintParameter>);
            break;
          case "AcDbBlockRadialConstraintParameter":
            delegate24 = new Delegate24(this.method_204<DxfBlockRadialConstraintParameter>);
            break;
          default:
            if (dxfClass.ItemClassId == (short) 498)
            {
              delegate24 = new Delegate24(this.method_89);
              break;
            }
            break;
        }
        if (delegate24 != null)
          this.dictionary_2.Add(dxfClass.ClassNumber, delegate24);
      }
    }

    private void method_85()
    {
      foreach (Class318 blockBuilder in this.class374_0.BlockBuilders)
      {
        if (blockBuilder.FirstEntityHandle != 0UL)
          this.method_86(blockBuilder.FirstEntityHandle, blockBuilder.LastEntityHandle);
      }
    }

    private void method_86(ulong firstHandle, ulong lastHandle)
    {
      Class285 objectBuilder = (Class285) this.method_87(firstHandle).HandledObjectInfo.ObjectBuilder;
      while ((long) objectBuilder.Entity.Handle != (long) lastHandle)
        objectBuilder = (Class285) this.method_87(objectBuilder.method_1()).HandledObjectInfo.ObjectBuilder;
    }

    private Class799 method_87(ulong handle)
    {
      if (this.dictionary_0.TryGetValue(handle, out this.class799_0))
      {
        if (this.class799_0.HandledObjectInfo == null || this.class799_0.HandledObjectInfo.ObjectBuilder == null)
        {
          this.method_79();
          this.interface30_0.StreamPosition = this.class799_0.StreamPosition;
          int num = (int) this.method_82();
          this.method_89();
          this.pagedMemoryStream_0.Dispose();
        }
      }
      else
        this.class799_0 = (Class799) null;
      return this.class799_0;
    }

    private void method_88(short objectType)
    {
      Class259 builder = new Class259(new DxfHandledObject());
      builder.ObjectType = objectType;
      this.class374_0.ObjectBuilders.Add(builder);
      if (this.class374_0.IsVersion15OrLater && this.class374_0.Version < DxfVersion.Dxf24)
        this.method_92();
      builder.HandledObject.SetHandle(this.interface30_4.imethod_32(false));
      long num1 = this.long_0 + (long) (this.uint_0 * 8U) - this.interface30_1.imethod_3();
      int length = (int) (num1 / 8L);
      int num2 = (int) (num1 % 8L);
      this.interface30_2.imethod_19(length);
      for (int index = 0; index < num2; ++index)
        this.interface30_2.imethod_6();
      this.class374_0.method_1(builder);
    }

    private void method_89()
    {
      this.method_80(this.short_0);
      Class285 entityBuilder = (Class285) new DxfUnknownEntity().vmethod_9(FileFormat.Dwg);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
    }

    public void method_90(Class285 entityBuilder)
    {
      this.method_91(entityBuilder, true);
    }

    public void method_91(Class285 entityBuilder, bool register)
    {
      DxfEntity entity = entityBuilder.Entity;
      if (this.class374_0.IsVersion15OrLater && this.class374_0.Version < DxfVersion.Dxf24)
        this.method_92();
      ulong handle = this.interface30_2.imethod_31();
      entityBuilder.HandledObject.SetHandle(handle);
      this.method_102((Class259) entityBuilder);
      if (this.interface30_2.imethod_6())
      {
        long imageSize = this.class374_0.Version >= DxfVersion.Dxf24 ? this.interface30_2.imethod_12() : (long) this.interface30_2.imethod_43();
        entity.vmethod_11(this, entityBuilder, imageSize);
      }
      if (this.class374_0.IsVersion13Or14)
        this.method_92();
      Class450 handledObjectInfo = new Class450(entityBuilder.HandledObject, (Class259) entityBuilder);
      if (register)
        this.class374_0.method_2(handledObjectInfo);
      this.class799_0.HandledObjectInfo = handledObjectInfo;
      entityBuilder.EntityMode = this.interface30_2.imethod_13();
      if (entityBuilder.EntityMode == (byte) 0)
        entityBuilder.ParentEntityRefHandle = this.method_101(entityBuilder.HandledObject.Handle);
      this.method_98((Class259) entityBuilder);
      if (this.class374_0.IsVersion13Or14)
      {
        entityBuilder.LayerHandle = this.method_100();
        if (!this.interface30_2.imethod_6())
          entityBuilder.LineTypeHandle = this.method_100();
      }
      if (!this.class374_0.IsVersion18OrLater && !this.interface30_2.imethod_6())
      {
        entityBuilder.PreviousHandle = new ulong?(this.method_101(entityBuilder.Entity.Handle));
        entityBuilder.NextHandle = new ulong?(this.method_101(entityBuilder.Entity.Handle));
      }
      else if (!this.class374_0.IsVersion18OrLater)
      {
        this.dwgReader_0.OwnedObjectHandles.Enqueue(entityBuilder.Entity.Handle - 1UL);
        this.dwgReader_0.OwnedObjectHandles.Enqueue(entityBuilder.Entity.Handle + 1UL);
      }
      EntityColor color;
      Transparency transparencySource;
      bool isColorBookColor;
      this.interface30_2.imethod_26(out color, out transparencySource, out isColorBookColor);
      entity.Color = color;
      entity.Transparency = transparencySource;
      if (this.class374_0.IsVersion18OrLater && isColorBookColor)
        entityBuilder.DxfColorHandle = this.method_100();
      entity.LineTypeScale = this.interface30_2.imethod_8();
      if (!this.class374_0.IsVersion15OrLater)
      {
        entity.Visible = ((int) this.interface30_2.imethod_14() & 1) == 0;
      }
      else
      {
        entityBuilder.LayerHandle = this.method_100();
        byte num1 = this.interface30_2.imethod_13();
        entityBuilder.LineTypeFlags = new byte?(num1);
        if (num1 == (byte) 3)
          entityBuilder.LineTypeHandle = this.method_100();
        if (this.class374_0.IsVersion21OrLater)
        {
          if (this.interface30_2.imethod_13() == (byte) 3)
          {
            long num2 = (long) this.method_100();
          }
          int num3 = (int) this.interface30_2.imethod_18();
        }
        if (this.interface30_2.imethod_13() == (byte) 3)
        {
          long num4 = (long) this.method_100();
        }
        if (this.class374_0.Version > DxfVersion.Dxf21)
        {
          if (this.interface30_2.imethod_6())
          {
            long num2 = (long) this.method_100();
          }
          if (this.interface30_2.imethod_6())
          {
            long num3 = (long) this.method_100();
          }
          if (this.interface30_2.imethod_6())
          {
            long num5 = (long) this.method_100();
          }
        }
        entity.Visible = ((int) this.interface30_2.imethod_14() & 1) == 0;
        byte num6 = this.interface30_2.imethod_18();
        entity.LineWeight = Class885.GetLineWeight((short) num6);
      }
    }

    private void method_92()
    {
      this.uint_2 = this.interface30_2.imethod_44();
      long uint2 = (long) this.uint_2;
      this.interface30_4 = this.interface30_7;
      this.interface30_4.imethod_54((Stream) Class1045.smethod_0(this.pagedMemoryStream_0), this.uint_2);
      this.interface30_4.imethod_4(uint2);
      if (this.class374_0.Version == DxfVersion.Dxf21)
      {
        this.interface30_3 = this.interface30_6;
        this.interface30_3.imethod_54((Stream) Class1045.smethod_0(this.pagedMemoryStream_0), this.uint_2);
        this.uint_1 = (uint) this.interface30_3.imethod_5(uint2 - 1L);
        this.interface30_2.SizeInBits = this.uint_1;
      }
      else
        this.uint_1 = this.uint_2;
      this.interface30_1 = (Interface30) new Class1048(this.interface30_2, this.interface30_3, this.interface30_4);
    }

    internal void method_93(Class259 objectBuilder)
    {
      if (this.class374_0.IsVersion15OrLater && this.class374_0.Version < DxfVersion.Dxf24)
        this.method_92();
      ulong handle = this.interface30_2.imethod_31();
      objectBuilder.HandledObject.SetHandle(handle);
      this.method_102(objectBuilder);
      if (!this.class374_0.IsVersion13Or14)
        return;
      this.method_92();
    }

    private void method_94(Class259 objectBuilder)
    {
      this.method_95(objectBuilder, true);
    }

    private void method_95(Class259 objectBuilder, bool register)
    {
      this.method_93(objectBuilder);
      this.method_97(objectBuilder);
      if (!register)
        return;
      this.method_96(objectBuilder);
    }

    internal void method_96(Class259 objectBuilder)
    {
      Class450 handledObjectInfo = new Class450(objectBuilder.HandledObject, objectBuilder);
      this.class374_0.method_2(handledObjectInfo);
      this.class799_0.HandledObjectInfo = handledObjectInfo;
    }

    internal void method_97(Class259 objectBuilder)
    {
      objectBuilder.OwnerHandle = this.method_101(objectBuilder.HandledObject.Handle);
      this.method_98(objectBuilder);
    }

    private void method_98(Class259 objectBuilder)
    {
      int num = this.interface30_2.imethod_11();
      for (int index = 0; index < num; ++index)
        objectBuilder.method_0(this.method_100());
      bool flag = false;
      if (this.class374_0.IsVersion18OrLater)
        flag = this.interface30_2.imethod_6();
      if (!flag)
        objectBuilder.ExtensionDictionaryHandle = this.method_100();
      if (this.class374_0.Version <= DxfVersion.Dxf24)
        return;
      this.interface30_2.imethod_6();
    }

    public void method_99(DxfEntity from, DxfEntity to)
    {
      to.SetHandle(from.Handle);
      to.Color = from.Color;
      to.LineTypeScale = from.LineTypeScale;
      to.Visible = from.Visible;
      to.LineWeight = from.LineWeight;
      foreach (DxfExtendedData extendedData in (Collection<DxfExtendedData>) from.ExtendedDataCollection)
        to.ExtendedDataCollection.Add(extendedData);
    }

    internal ulong method_100()
    {
      return this.interface30_4.imethod_32(true);
    }

    private ulong method_101(ulong referenceHandle)
    {
      return this.interface30_4.imethod_33(referenceHandle, true);
    }

    private void method_102(Class259 objectBuilder)
    {
      while (true)
      {
        short num = this.interface30_2.imethod_14();
        if (num != (short) 0)
        {
          Class660 applicationDataBuilder = new Class660(objectBuilder);
          applicationDataBuilder.ApplicationHandle = this.interface30_2.imethod_31();
          objectBuilder.ChildBuilders.Add((Interface10) applicationDataBuilder);
          long applicationDataEnd = this.interface30_2.StreamPosition + (long) num;
          applicationDataBuilder.ExtendedData = new DxfExtendedData((DxfAppId) null, this.method_103(objectBuilder, applicationDataBuilder, applicationDataEnd));
        }
        else
          break;
      }
    }

    private DxfExtendedData.ValueCollection method_103(
      Class259 objectBuilder,
      Class660 applicationDataBuilder,
      long applicationDataEnd)
    {
      DxfExtendedData.ValueCollection valueCollection = new DxfExtendedData.ValueCollection();
      bool flag1 = false;
      bool flag2 = true;
      int num1 = -1;
      bool flag3 = false;
      while (this.interface30_2.StreamPosition < applicationDataEnd && !flag1)
      {
        short num2 = (short) (1000 + (int) this.interface30_2.imethod_18());
        IExtendedDataValue extendedDataValue = (IExtendedDataValue) null;
        switch (num2)
        {
          case 1000:
          case 1001:
            extendedDataValue = (IExtendedDataValue) new DxfExtendedData.String(this.interface30_2.imethod_30());
            break;
          case 1002:
            if (this.interface30_2.imethod_18() == (byte) 0)
            {
              if (flag2)
              {
                flag3 = true;
                ++num1;
              }
              extendedDataValue = (IExtendedDataValue) new DxfExtendedData.Bracket(false);
              break;
            }
            if (flag2)
            {
              if (num1 < 0)
                flag2 = false;
              --num1;
            }
            extendedDataValue = (IExtendedDataValue) new DxfExtendedData.Bracket(true);
            break;
          case 1003:
            ulong layerHandle = this.interface30_2.imethod_47();
            DxfExtendedData.LayerReference layerReference = new DxfExtendedData.LayerReference();
            extendedDataValue = (IExtendedDataValue) layerReference;
            Class379 class379 = new Class379(layerReference, layerHandle);
            applicationDataBuilder.ExtendedDataBuilders.Add((Interface10) class379);
            break;
          case 1004:
            extendedDataValue = (IExtendedDataValue) new DxfExtendedData.BinaryData(this.interface30_2.imethod_19((int) this.interface30_2.imethod_18()));
            break;
          case 1005:
            DxfExtendedData.DatabaseHandle xdataDatabaseHandle = new DxfExtendedData.DatabaseHandle();
            extendedDataValue = (IExtendedDataValue) xdataDatabaseHandle;
            applicationDataBuilder.ExtendedDataBuilders.Add((Interface10) new Class618(xdataDatabaseHandle)
            {
              DatabaseHandle = this.interface30_2.imethod_47()
            });
            break;
          case 1010:
            extendedDataValue = (IExtendedDataValue) new DxfExtendedData.PointOrVector(this.interface30_2.imethod_42(), this.interface30_2.imethod_42(), this.interface30_2.imethod_42());
            break;
          case 1011:
            extendedDataValue = (IExtendedDataValue) new DxfExtendedData.WorldSpacePosition(this.interface30_2.imethod_42(), this.interface30_2.imethod_42(), this.interface30_2.imethod_42());
            break;
          case 1012:
            extendedDataValue = (IExtendedDataValue) new DxfExtendedData.WorldSpaceDisplacement(this.interface30_2.imethod_42(), this.interface30_2.imethod_42(), this.interface30_2.imethod_42());
            break;
          case 1013:
            extendedDataValue = (IExtendedDataValue) new DxfExtendedData.WorldDirection(this.interface30_2.imethod_42(), this.interface30_2.imethod_42(), this.interface30_2.imethod_42());
            break;
          case 1040:
            extendedDataValue = (IExtendedDataValue) new DxfExtendedData.Double(this.interface30_2.imethod_42());
            break;
          case 1041:
            extendedDataValue = (IExtendedDataValue) new DxfExtendedData.Distance(this.interface30_2.imethod_42());
            break;
          case 1042:
            extendedDataValue = (IExtendedDataValue) new DxfExtendedData.ScaleFactor(this.interface30_2.imethod_42());
            break;
          case 1070:
            extendedDataValue = (IExtendedDataValue) new DxfExtendedData.Int16(this.interface30_2.imethod_45());
            break;
          case 1071:
            extendedDataValue = (IExtendedDataValue) new DxfExtendedData.Int32(this.interface30_2.imethod_43());
            break;
          default:
            this.class374_0.Messages.Add(new DxfMessage(DxfStatus.InvalidXDataGroupCode, Severity.Error)
            {
              Parameters = {
                {
                  "Object",
                  (object) objectBuilder.HandledObject
                },
                {
                  "GroupCode",
                  (object) num2
                }
              }
            });
            this.interface30_2.imethod_19((int) (applicationDataEnd - this.interface30_2.StreamPosition));
            flag1 = true;
            break;
        }
        if (extendedDataValue != null)
          valueCollection.Add(extendedDataValue);
      }
      if (flag3 && num1 == -1)
      {
        DxfExtendedData.ValueCollection debracketized = new DxfExtendedData.ValueCollection();
        int i = 0;
        valueCollection.method_0(debracketized, ref i);
        valueCollection = debracketized;
      }
      return valueCollection;
    }

    private short method_104(bool value)
    {
      return value ? (short) 1 : (short) 0;
    }

    private void method_105()
    {
      DxfHandledObject blockRecordTable = new DxfHandledObject();
      this.dxfModel_0.BlockRecordTable = blockRecordTable;
      Class322.Class324 class324 = new Class322.Class324(blockRecordTable);
      this.class374_0.BlockRecordTableBuilder = (Class322) class324;
      this.method_94((Class259) class324);
      class324.EntryCount = this.interface30_2.imethod_11();
      for (int index = 0; index < class324.EntryCount; ++index)
        class324.BlockRecordHandles.Add(this.method_100());
      class324.ModelSpaceBlockRecordHandle = this.method_100();
      class324.PaperSpaceBlockRecordHandle = this.method_100();
    }

    private void method_106()
    {
      DxfBlock blockRecord = new DxfBlock(false);
      Class318 class318 = new Class318(blockRecord);
      this.class374_0.BlockBuilders.Add(class318);
      this.method_94((Class259) class318);
      blockRecord.method_9(this.interface30_3.ReadString());
      this.method_112((DxfTableRecord) blockRecord);
      blockRecord.IsAnonymous = this.interface30_2.imethod_6();
      class318.HasAttributes = this.interface30_2.imethod_6();
      blockRecord.IsExternalReference = this.interface30_2.imethod_6();
      blockRecord.IsXRefOverlay = this.interface30_2.imethod_6();
      if (this.class374_0.IsVersion15OrLater)
        blockRecord.IsExternalReferenceUnloaded = this.interface30_2.imethod_6();
      int num1 = 0;
      if (this.class374_0.IsVersion18OrLater && !blockRecord.IsExternalReference && !blockRecord.IsXRefOverlay)
        num1 = this.interface30_2.imethod_11();
      blockRecord.method_8((WW.Math.Vector3D) this.interface30_2.imethod_39());
      blockRecord.ExternalReference = this.interface30_3.ReadString();
      int num2 = 0;
      if (this.class374_0.IsVersion15OrLater)
      {
        for (byte index = this.interface30_2.imethod_18(); index != (byte) 0; index = this.interface30_2.imethod_18())
          ++num2;
        blockRecord.Description = this.interface30_3.ReadString();
        int num3 = this.interface30_2.imethod_11();
        for (int index = 0; index < num3; ++index)
        {
          int num4 = (int) this.interface30_2.imethod_18();
        }
      }
      if (this.class374_0.IsVersion21OrLater)
      {
        blockRecord.BlockUnits = (DrawingUnits) this.interface30_2.imethod_14();
        blockRecord.Explodable = this.interface30_2.imethod_6();
        blockRecord.ScaleUniformly = this.interface30_2.imethod_18() != (byte) 0;
      }
      long num5 = (long) this.method_100();
      class318.BlockBeginHandle = this.method_100();
      if (this.class374_0.Version >= DxfVersion.Dxf13 && this.class374_0.Version <= DxfVersion.Dxf15 && (!blockRecord.IsExternalReference && !blockRecord.IsXRefOverlay))
      {
        class318.FirstEntityHandle = this.method_100();
        class318.LastEntityHandle = this.method_100();
      }
      if (this.class374_0.IsVersion18OrLater)
      {
        for (int index = 0; index < num1; ++index)
          class318.OwnedEntityHandles.Add(this.method_100());
      }
      class318.BlockEndHandle = this.method_100();
      if (!this.class374_0.IsVersion15OrLater)
        return;
      for (int index = 0; index < num2; ++index)
      {
        long num3 = (long) this.method_100();
      }
      class318.LayoutHandle = this.method_100();
    }

    private void method_107()
    {
      DxfHandledObject tableControl = new DxfHandledObject();
      this.dxfModel_0.TextStyleTable = tableControl;
      Class326 class326 = new Class326(tableControl);
      this.class374_0.ObjectBuilders.Add((Class259) class326);
      this.method_94((Class259) class326);
      short num = this.interface30_2.imethod_14();
      for (int index = 0; index < (int) num; ++index)
        class326.TableRecordHandles.Add(this.method_100());
    }

    private void method_108()
    {
      DxfTextStyle dxfTextStyle = new DxfTextStyle();
      Class259 objectBuilder = new Class259((DxfHandledObject) dxfTextStyle);
      this.class374_0.ObjectBuilders.Add(objectBuilder);
      this.method_94(objectBuilder);
      dxfTextStyle.Name = this.interface30_3.ReadString();
      this.method_112((DxfTableRecord) dxfTextStyle);
      dxfTextStyle.IsShape = this.interface30_2.imethod_6();
      dxfTextStyle.IsVertical = this.interface30_2.imethod_6();
      dxfTextStyle.FixedHeight = this.interface30_2.imethod_8();
      dxfTextStyle.WidthFactor = this.interface30_2.imethod_8();
      dxfTextStyle.ObliqueAngle = this.interface30_2.imethod_8();
      dxfTextStyle.TextGenerationFlags = (TextGenerationFlags) this.interface30_2.imethod_18();
      dxfTextStyle.LastHeightUsed = this.interface30_2.imethod_8();
      dxfTextStyle.FontFilename = this.interface30_3.ReadString();
      dxfTextStyle.BigFontFilename = this.interface30_3.ReadString();
      long num = (long) this.method_100();
    }

    private void method_109()
    {
      if (this.class374_0.IsVersion21OrLater)
        return;
      int num = (int) this.interface30_2.imethod_14();
    }

    private void method_110()
    {
      DxfHandledObject tableControl = new DxfHandledObject();
      this.dxfModel_0.LayerTable = tableControl;
      Class319<DxfLayer> class319 = new Class319<DxfLayer>(tableControl, (KeyedDxfHandledObjectCollection<string, DxfLayer>) this.dxfModel_0.Layers);
      this.class374_0.ObjectBuilders.Add((Class259) class319);
      this.method_94((Class259) class319);
      int num = (int) this.interface30_2.imethod_14();
      for (int index = 0; index < num; ++index)
        class319.TableRecordHandles.Add(this.method_100());
    }

    private void method_111()
    {
      DxfLayer layer = new DxfLayer();
      Class320 class320 = new Class320(layer);
      this.class374_0.ObjectBuilders.Add((Class259) class320);
      this.method_94((Class259) class320);
      layer.Name = this.interface30_3.ReadString();
      this.method_112((DxfTableRecord) layer);
      if (this.class374_0.IsVersion13Or14)
      {
        layer.Frozen = this.interface30_2.imethod_6();
        layer.Enabled = !this.interface30_2.imethod_6();
        layer.FrozenInNewViewport = this.interface30_2.imethod_6();
        layer.Locked = this.interface30_2.imethod_6();
      }
      if (this.class374_0.IsVersion15OrLater)
      {
        short num1 = this.interface30_2.imethod_14();
        layer.Frozen = ((int) num1 & 1) != 0;
        layer.Enabled = ((int) num1 & 2) == 0;
        layer.FrozenInNewViewport = ((int) num1 & 4) != 0;
        layer.Locked = ((int) num1 & 8) != 0;
        layer.PlotEnabled = ((int) num1 & 16) != 0;
        byte num2 = (byte) (((int) num1 & 992) >> 5);
        layer.LineWeight = Class885.GetLineWeight((short) num2);
      }
      layer.Color = this.interface30_1.imethod_22();
      long num3 = (long) this.method_100();
      if (this.class374_0.IsVersion15OrLater)
        class320.PlotStyleHandle = this.method_100();
      if (this.class374_0.IsVersion21OrLater)
      {
        long num4 = (long) this.method_100();
      }
      class320.LineTypeHandle = this.method_100();
      if (this.class374_0.Version <= DxfVersion.Dxf24)
        return;
      long num5 = (long) this.method_100();
    }

    private void method_112(DxfTableRecord tableRecord)
    {
      if (this.class374_0.IsVersion21OrLater)
      {
        short num = this.interface30_2.imethod_14();
        tableRecord.IsExternallyDependent = ((int) num & 256) != 0;
      }
      else
      {
        this.interface30_2.imethod_6();
        this.method_109();
        tableRecord.IsExternallyDependent = this.interface30_2.imethod_6();
      }
    }

    private void method_113()
    {
      DxfHandledObject tableControl = new DxfHandledObject();
      this.dxfModel_0.LineTypeTable = tableControl;
      Class319<DxfLineType> class319 = new Class319<DxfLineType>(tableControl, (KeyedDxfHandledObjectCollection<string, DxfLineType>) this.dxfModel_0.LineTypes);
      this.class374_0.ObjectBuilders.Add((Class259) class319);
      this.method_94((Class259) class319);
      int num1 = (int) this.interface30_2.imethod_14();
      for (int index = 0; index < num1; ++index)
        class319.TableRecordHandles.Add(this.method_100());
      ulong num2 = this.method_100();
      class319.TableRecordHandles.Add(num2);
      ulong num3 = this.method_100();
      class319.TableRecordHandles.Add(num3);
    }

    private void method_114()
    {
      DxfLineType lineType = new DxfLineType();
      Class315 class315 = new Class315(lineType);
      this.class374_0.ObjectBuilders.Add((Class259) class315);
      this.method_94((Class259) class315);
      lineType.Name = this.interface30_3.ReadString();
      this.method_112((DxfTableRecord) lineType);
      lineType.Description = this.interface30_3.ReadString();
      this.interface30_2.imethod_8();
      int num1 = (int) this.interface30_2.imethod_18();
      int length = (int) this.interface30_2.imethod_18();
      bool flag = false;
      short[] textAreaIndexes = new short[length];
      for (int index = 0; index < length; ++index)
      {
        DxfLineType.Element element = new DxfLineType.Element();
        lineType.Elements.Add(element);
        element.Length = this.interface30_2.imethod_8();
        short num2 = this.interface30_2.imethod_14();
        textAreaIndexes[index] = num2;
        element.Offset = new Vector2D(this.interface30_2.imethod_42(), element.Offset.Y);
        element.Offset = new Vector2D(element.Offset.X, this.interface30_2.imethod_42());
        element.Scale = this.interface30_2.imethod_8();
        element.Rotation = this.interface30_2.imethod_8();
        element.ElementType = (DxfLineType.ElementType) this.interface30_2.imethod_14();
        if (element.IsText)
          flag = true;
        if (element.IsShape)
          element.ShapeNumber = num2;
      }
      if (this.class374_0.Version <= DxfVersion.Dxf18)
      {
        byte[] bytes = this.interface30_2.imethod_19(256);
        this.method_115(lineType, bytes, textAreaIndexes);
      }
      if (this.class374_0.IsVersion21OrLater && flag)
      {
        byte[] bytes = this.interface30_2.imethod_19(512);
        this.method_116(lineType, bytes, textAreaIndexes);
      }
      long num3 = (long) this.method_100();
      for (int index = 0; index < length; ++index)
        class315.Add((Interface10) new Class891(lineType, lineType.Elements[index])
        {
          TextStyleHandle = this.method_100()
        });
    }

    private void method_115(DxfLineType lineType, byte[] bytes, short[] textAreaIndexes)
    {
      int index1 = 0;
      foreach (DxfLineType.Element element in (List<DxfLineType.Element>) lineType.Elements)
      {
        int textAreaIndex = (int) textAreaIndexes[index1];
        if (element.IsText)
        {
          for (int index2 = textAreaIndex; index2 < bytes.Length; ++index2)
          {
            if (bytes[index2] == (byte) 0)
            {
              string str = this.interface30_1.Encoding.GetString(bytes, textAreaIndex, index2 - textAreaIndex);
              element.Text = str;
              break;
            }
          }
        }
        ++index1;
      }
    }

    private void method_116(DxfLineType lineType, byte[] bytes, short[] textAreaIndexes)
    {
      int index1 = 0;
      foreach (DxfLineType.Element element in (List<DxfLineType.Element>) lineType.Elements)
      {
        int index2 = 2 * (int) textAreaIndexes[index1];
        if (element.IsText)
        {
          for (int index3 = index2; index3 < bytes.Length; index3 += 2)
          {
            if (bytes[index3] == (byte) 0 && bytes[index3 + 1] == (byte) 0)
            {
              string str = Encoding.Unicode.GetString(bytes, index2, index3 - index2);
              element.Text = str;
              break;
            }
          }
        }
        ++index1;
      }
    }

    private void method_117()
    {
      DxfHandledObject tableControl = new DxfHandledObject();
      this.dxfModel_0.ViewTable = tableControl;
      Class319<DxfView> class319 = new Class319<DxfView>(tableControl, (KeyedDxfHandledObjectCollection<string, DxfView>) this.dxfModel_0.Views);
      this.class374_0.ObjectBuilders.Add((Class259) class319);
      this.method_94((Class259) class319);
      int num = (int) this.interface30_2.imethod_14();
      for (int index = 0; index < num; ++index)
        class319.TableRecordHandles.Add(this.method_100());
    }

    private void method_118()
    {
      DxfView view = new DxfView();
      Class317 class317 = new Class317(view);
      this.class374_0.ObjectBuilders.Add((Class259) class317);
      this.method_94((Class259) class317);
      long num1 = (long) this.method_100();
      view.Name = this.interface30_3.ReadString();
      this.method_112((DxfTableRecord) view);
      double height = this.interface30_2.imethod_8();
      double width = this.interface30_2.imethod_8();
      view.Size = new Size2D(width, height);
      view.Center = this.interface30_2.imethod_38();
      view.Target = this.interface30_2.imethod_39();
      view.Direction = this.interface30_2.imethod_51();
      view.TwistAngle = this.interface30_2.imethod_8();
      view.LensLength = this.interface30_2.imethod_8();
      view.FrontClippingPlane = this.interface30_2.imethod_8();
      view.BackClippingPlane = this.interface30_2.imethod_8();
      view.PerspectiveMode = this.interface30_2.imethod_6();
      view.FrontClippingActive = this.interface30_2.imethod_6();
      view.BackClippingActive = this.interface30_2.imethod_6();
      view.ClipFrontNotAtEye = !this.interface30_2.imethod_6();
      if (this.class374_0.IsVersion15OrLater)
        view.RenderMode = (RenderMode) this.interface30_2.imethod_18();
      if (this.class374_0.IsVersion21OrLater)
      {
        long num2 = (long) this.method_100();
        long num3 = (long) this.method_100();
        this.interface30_1.imethod_6();
        int num4 = (int) this.interface30_1.imethod_18();
        this.interface30_1.imethod_8();
        this.interface30_1.imethod_8();
        this.interface30_1.imethod_22();
        long num5 = (long) this.method_100();
      }
      view.Paperspace = this.interface30_2.imethod_6();
      bool flag = false;
      if (this.class374_0.IsVersion15OrLater && (flag = this.interface30_2.imethod_6()))
      {
        view.Ucs.Origin = this.interface30_2.imethod_39();
        view.Ucs.XAxis = this.interface30_2.imethod_51();
        view.Ucs.YAxis = this.interface30_2.imethod_51();
        view.Ucs.Elevation = this.interface30_2.imethod_8();
        view.UcsOrthographicType = (OrthographicType) this.interface30_2.imethod_14();
      }
      if (this.class374_0.IsVersion21OrLater)
        this.interface30_2.imethod_6();
      if (this.class374_0.IsVersion15OrLater && flag)
      {
        class317.BaseUcsHandle = this.method_100();
        class317.NamedUcsHandle = this.method_100();
      }
      if (!this.class374_0.IsVersion21OrLater)
        return;
      long num6 = (long) this.method_100();
    }

    private void method_119()
    {
      DxfHandledObject tableControl = new DxfHandledObject();
      this.dxfModel_0.UcsTable = tableControl;
      Class319<DxfUcs> class319 = new Class319<DxfUcs>(tableControl, (KeyedDxfHandledObjectCollection<string, DxfUcs>) this.dxfModel_0.UcsCollection);
      this.class374_0.ObjectBuilders.Add((Class259) class319);
      this.method_94((Class259) class319);
      int num = (int) this.interface30_2.imethod_14();
      for (int index = 0; index < num; ++index)
        class319.TableRecordHandles.Add(this.method_100());
    }

    private void method_120()
    {
      DxfUcs dxfUcs = new DxfUcs();
      Class259 objectBuilder = new Class259((DxfHandledObject) dxfUcs);
      this.class374_0.ObjectBuilders.Add(objectBuilder);
      this.method_94(objectBuilder);
      dxfUcs.Name = this.interface30_3.ReadString();
      this.method_112((DxfTableRecord) dxfUcs);
      dxfUcs.Origin = this.interface30_2.imethod_39();
      dxfUcs.XAxis = this.interface30_2.imethod_51();
      dxfUcs.YAxis = this.interface30_2.imethod_51();
      if (this.class374_0.IsVersion15OrLater)
      {
        dxfUcs.Elevation = this.interface30_2.imethod_8();
        int num1 = (int) this.interface30_2.imethod_14();
        int num2 = (int) this.interface30_2.imethod_14();
      }
      long num3 = (long) this.method_100();
      if (!this.class374_0.IsVersion15OrLater)
        return;
      long num4 = (long) this.method_100();
      long num5 = (long) this.method_100();
    }

    private void method_121()
    {
      DxfHandledObject tableControl = new DxfHandledObject();
      this.dxfModel_0.VPortTable = tableControl;
      Class327 class327 = new Class327(tableControl);
      this.class374_0.ObjectBuilders.Add((Class259) class327);
      this.method_94((Class259) class327);
      int num = (int) this.interface30_2.imethod_14();
      for (int index = 0; index < num; ++index)
        class327.TableRecordHandles.Add(this.method_100());
    }

    private void method_122()
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Class434.Class435 class435 = new Class434.Class435();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0 = new DxfVPort();
      // ISSUE: reference to a compiler-generated field
      Class325 class325 = new Class325(class435.dxfVPort_0);
      this.class374_0.ObjectBuilders.Add((Class259) class325);
      this.method_94((Class259) class325);
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.Name = this.interface30_3.ReadString();
      // ISSUE: reference to a compiler-generated field
      this.method_112((DxfTableRecord) class435.dxfVPort_0);
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.Height = this.interface30_2.imethod_8();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.AspectRatio = this.interface30_2.imethod_8() / class435.dxfVPort_0.Height;
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.Center = this.interface30_2.imethod_38();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.Target = this.interface30_2.imethod_39();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.Direction = this.interface30_2.imethod_51();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.TwistAngle = this.interface30_2.imethod_8();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.LensLength = this.interface30_2.imethod_8();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.FrontClippingPlane = this.interface30_2.imethod_8();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.BackClippingPlane = this.interface30_2.imethod_8();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.PerspectiveMode = this.interface30_2.imethod_6();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.FrontClippingActive = this.interface30_2.imethod_6();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.BackClippingActive = this.interface30_2.imethod_6();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.ClipFrontNotAtEye = !this.interface30_2.imethod_6();
      if (this.class374_0.IsVersion15OrLater)
      {
        // ISSUE: reference to a compiler-generated field
        class435.dxfVPort_0.RenderMode = (RenderMode) this.interface30_2.imethod_18();
      }
      if (this.class374_0.IsVersion21OrLater)
      {
        // ISSUE: reference to a compiler-generated field
        class435.dxfVPort_0.UseDefaultLighting = this.interface30_2.imethod_6();
        // ISSUE: reference to a compiler-generated field
        class435.dxfVPort_0.DefaultLightingType = (DefaultLightingType) this.interface30_2.imethod_18();
        // ISSUE: reference to a compiler-generated field
        class435.dxfVPort_0.Brightness = this.interface30_2.imethod_8();
        // ISSUE: reference to a compiler-generated field
        class435.dxfVPort_0.Contrast = this.interface30_2.imethod_8();
        // ISSUE: reference to a compiler-generated field
        class435.dxfVPort_0.AmbientColor = this.interface30_1.imethod_22();
      }
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.BottomLeft = this.interface30_2.imethod_38();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.TopRight = this.interface30_2.imethod_38();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.FollowUCS = this.interface30_2.imethod_6();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.method_8(this.interface30_2.imethod_14());
      this.interface30_2.imethod_6();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.DisplayUcs = this.interface30_2.imethod_6();
      this.interface30_2.imethod_6();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.ShowGrid = this.interface30_2.imethod_6();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.GridSpacing = this.interface30_2.imethod_50();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.Snap = this.interface30_2.imethod_6();
      bool flag = this.interface30_2.imethod_6();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.SnapStyle = flag ? SnapStyle.Isometric : SnapStyle.Standard;
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.SnapIsoPair = this.interface30_2.imethod_14();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.SnapRotationAngle = this.interface30_2.imethod_8();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.SnapBasePoint = this.interface30_2.imethod_38();
      // ISSUE: reference to a compiler-generated field
      class435.dxfVPort_0.SnapSpacing = this.interface30_2.imethod_50();
      if (this.class374_0.IsVersion15OrLater)
      {
        this.interface30_2.imethod_6();
        // ISSUE: reference to a compiler-generated field
        class435.dxfVPort_0.UcsPerViewport = this.interface30_2.imethod_6();
        // ISSUE: reference to a compiler-generated field
        class435.dxfVPort_0.Ucs.Origin = this.interface30_2.imethod_39();
        // ISSUE: reference to a compiler-generated field
        class435.dxfVPort_0.Ucs.XAxis = this.interface30_2.imethod_51();
        // ISSUE: reference to a compiler-generated field
        class435.dxfVPort_0.Ucs.YAxis = this.interface30_2.imethod_51();
        // ISSUE: reference to a compiler-generated field
        class435.dxfVPort_0.Ucs.Elevation = this.interface30_2.imethod_8();
        // ISSUE: reference to a compiler-generated field
        class435.dxfVPort_0.UcsOrthographicType = (OrthographicType) this.interface30_2.imethod_14();
      }
      if (this.class374_0.IsVersion21OrLater)
      {
        // ISSUE: reference to a compiler-generated field
        class435.dxfVPort_0.GridFlags = (Enum17) this.interface30_2.imethod_14();
        // ISSUE: reference to a compiler-generated field
        class435.dxfVPort_0.MinorGridLinesPerMajorGridLine = this.interface30_2.imethod_14();
      }
      long num1 = (long) this.method_100();
      if (this.class374_0.IsVersion21OrLater)
      {
        long num2 = (long) this.method_100();
        // ISSUE: reference to a compiler-generated method
        this.class374_0.method_10(this.method_100(), new System.Action<DxfObjectReference>(class435.method_0));
        long num3 = (long) this.method_100();
      }
      if (!this.class374_0.IsVersion15OrLater)
        return;
      class325.NamedUcsHandle = this.method_100();
      class325.BaseUcsHandle = this.method_100();
    }

    private void method_123()
    {
      DxfHandledObject tableControl = new DxfHandledObject();
      this.dxfModel_0.AppIdTable = tableControl;
      Class319<DxfAppId> class319 = new Class319<DxfAppId>(tableControl, (KeyedDxfHandledObjectCollection<string, DxfAppId>) this.dxfModel_0.AppIds);
      this.class374_0.AppIdTableBuilder = class319;
      this.method_94((Class259) class319);
      int num = (int) this.interface30_2.imethod_14();
      for (int index = 0; index < num; ++index)
        class319.TableRecordHandles.Add(this.method_100());
    }

    private void method_124()
    {
      DxfAppId dxfAppId = new DxfAppId();
      Class259 objectBuilder = new Class259((DxfHandledObject) dxfAppId);
      this.class374_0.ObjectBuilders.Add(objectBuilder);
      this.method_94(objectBuilder);
      dxfAppId.Name = this.interface30_3.ReadString();
      this.method_112((DxfTableRecord) dxfAppId);
      int num1 = (int) this.interface30_2.imethod_18();
      long num2 = (long) this.method_100();
    }

    private void method_125()
    {
      DxfHandledObject tableControl = new DxfHandledObject();
      this.dxfModel_0.DimStyleTable = tableControl;
      Class319<DxfDimensionStyle> class319 = new Class319<DxfDimensionStyle>(tableControl, (KeyedDxfHandledObjectCollection<string, DxfDimensionStyle>) this.dxfModel_0.DimensionStyles);
      this.class374_0.ObjectBuilders.Add((Class259) class319);
      this.method_94((Class259) class319);
      int num1 = (int) this.interface30_2.imethod_14();
      if (this.class374_0.IsVersion15OrLater)
      {
        int num2 = (int) this.interface30_2.imethod_18();
      }
      for (int index = 0; index < num1; ++index)
        class319.TableRecordHandles.Add(this.method_100());
    }

    private void method_126()
    {
      DxfDimensionStyle dimensionStyle = new DxfDimensionStyle(this.dxfModel_0);
      Class309 class309 = new Class309(dimensionStyle);
      this.class374_0.ObjectBuilders.Add((Class259) class309);
      this.method_94((Class259) class309);
      dimensionStyle.Name = this.interface30_3.ReadString();
      this.method_112((DxfTableRecord) dimensionStyle);
      if (this.class374_0.IsVersion13Or14)
      {
        dimensionStyle.GenerateTolerances = this.interface30_2.imethod_6();
        dimensionStyle.LimitsGeneration = this.interface30_2.imethod_6();
        dimensionStyle.TextInsideHorizontal = this.interface30_2.imethod_6();
        dimensionStyle.TextOutsideHorizontal = this.interface30_2.imethod_6();
        dimensionStyle.SuppressFirstExtensionLine = this.interface30_2.imethod_6();
        dimensionStyle.SuppressSecondExtensionLine = this.interface30_2.imethod_6();
        dimensionStyle.AlternateUnitDimensioning = this.interface30_2.imethod_6();
        dimensionStyle.TextOutsideExtensions = this.interface30_2.imethod_6();
        dimensionStyle.SeparateArrowBlocks = this.interface30_2.imethod_6();
        dimensionStyle.TextInsideExtensions = this.interface30_2.imethod_6();
        dimensionStyle.SuppressOutsideExtensions = this.interface30_2.imethod_6();
        dimensionStyle.AlternateUnitDecimalPlaces = (short) this.interface30_2.imethod_18();
        dimensionStyle.ZeroHandling = (ZeroHandling) this.interface30_2.imethod_18();
        dimensionStyle.SuppressFirstDimensionLine = this.interface30_2.imethod_6();
        dimensionStyle.SuppressSecondDimensionLine = this.interface30_2.imethod_6();
        dimensionStyle.ToleranceAlignment = (ToleranceAlignment) this.interface30_2.imethod_18();
        dimensionStyle.TextHorizontalAlignment = (DimensionTextHorizontalAlignment) this.interface30_2.imethod_18();
        int num1 = (int) this.interface30_2.imethod_18();
        dimensionStyle.CursorUpdate = (CursorUpdate) this.interface30_2.imethod_7();
        dimensionStyle.ToleranceZeroHandling = (ZeroHandling) this.interface30_2.imethod_18();
        dimensionStyle.AlternateUnitZeroHandling = (ZeroHandling) this.interface30_2.imethod_18();
        dimensionStyle.AlternateUnitToleranceZeroHandling = (ZeroHandling) this.interface30_2.imethod_18();
        dimensionStyle.TextVerticalAlignment = (DimensionTextVerticalAlignment) this.interface30_2.imethod_18();
        int num2 = (int) this.interface30_2.imethod_14();
        dimensionStyle.AngularUnit = (AngularUnit) this.interface30_2.imethod_14();
        dimensionStyle.DecimalPlaces = this.interface30_2.imethod_14();
        dimensionStyle.ToleranceDecimalPlaces = this.interface30_2.imethod_14();
        dimensionStyle.AlternateUnitFormat = (AlternateUnitFormat) this.interface30_2.imethod_14();
        dimensionStyle.AlternateUnitToleranceDecimalPlaces = this.interface30_2.imethod_14();
        dimensionStyle.ScaleFactor = this.interface30_2.imethod_8();
        dimensionStyle.ArrowSize = this.interface30_2.imethod_8();
        dimensionStyle.ExtensionLineOffset = this.interface30_2.imethod_8();
        dimensionStyle.DimensionLineIncrement = this.interface30_2.imethod_8();
        dimensionStyle.ExtensionLineExtension = this.interface30_2.imethod_8();
        dimensionStyle.Rounding = this.interface30_2.imethod_8();
        dimensionStyle.DimensionLineExtension = this.interface30_2.imethod_8();
        dimensionStyle.PlusTolerance = this.interface30_2.imethod_8();
        dimensionStyle.MinusTolerance = this.interface30_2.imethod_8();
        dimensionStyle.TextHeight = this.interface30_2.imethod_8();
        dimensionStyle.CenterMarkSize = this.interface30_2.imethod_8();
        dimensionStyle.TickSize = this.interface30_2.imethod_8();
        dimensionStyle.AlternateUnitScaleFactor = this.interface30_2.imethod_8();
        dimensionStyle.LinearScaleFactor = this.interface30_2.imethod_8();
        dimensionStyle.TextVerticalPosition = this.interface30_2.imethod_8();
        dimensionStyle.ToleranceScaleFactor = this.interface30_2.imethod_8();
        dimensionStyle.DimensionLineGap = this.interface30_2.imethod_8();
        dimensionStyle.PostFix = this.interface30_3.ReadString();
        dimensionStyle.AlternateDimensioningSuffix = this.interface30_3.ReadString();
        class309.ArrowBlockName = this.interface30_3.ReadString();
        class309.FirstArrowBlockName = this.interface30_3.ReadString();
        class309.SecondArrowBlockName = this.interface30_3.ReadString();
        dimensionStyle.DimensionLineColor = this.interface30_2.imethod_16();
        dimensionStyle.ExtensionLineColor = this.interface30_2.imethod_16();
        dimensionStyle.TextColor = this.interface30_2.imethod_16();
      }
      if (this.class374_0.IsVersion15OrLater)
      {
        dimensionStyle.PostFix = this.interface30_3.ReadString();
        dimensionStyle.AlternateDimensioningSuffix = this.interface30_3.ReadString();
        dimensionStyle.ScaleFactor = this.interface30_2.imethod_8();
        dimensionStyle.ArrowSize = this.interface30_2.imethod_8();
        dimensionStyle.ExtensionLineOffset = this.interface30_2.imethod_8();
        dimensionStyle.DimensionLineIncrement = this.interface30_2.imethod_8();
        dimensionStyle.ExtensionLineExtension = this.interface30_2.imethod_8();
        dimensionStyle.Rounding = this.interface30_2.imethod_8();
        dimensionStyle.DimensionLineExtension = this.interface30_2.imethod_8();
        dimensionStyle.PlusTolerance = this.interface30_2.imethod_8();
        dimensionStyle.MinusTolerance = this.interface30_2.imethod_8();
      }
      if (this.class374_0.IsVersion21OrLater)
      {
        dimensionStyle.FixedExtensionLineLength = this.interface30_2.imethod_8();
        dimensionStyle.JoggedRadiusDimensionTransverseSegmentAngle = this.interface30_2.imethod_8();
        dimensionStyle.TextBackgroundFillMode = (DimensionTextBackgroundFillMode) this.interface30_2.imethod_14();
        dimensionStyle.TextBackgroundColor = this.interface30_1.imethod_22();
      }
      if (this.class374_0.IsVersion15OrLater)
      {
        dimensionStyle.GenerateTolerances = this.interface30_2.imethod_6();
        dimensionStyle.LimitsGeneration = this.interface30_2.imethod_6();
        dimensionStyle.TextInsideHorizontal = this.interface30_2.imethod_6();
        dimensionStyle.TextOutsideHorizontal = this.interface30_2.imethod_6();
        dimensionStyle.SuppressFirstExtensionLine = this.interface30_2.imethod_6();
        dimensionStyle.SuppressSecondExtensionLine = this.interface30_2.imethod_6();
        dimensionStyle.TextVerticalAlignment = (DimensionTextVerticalAlignment) this.interface30_2.imethod_14();
        dimensionStyle.ZeroHandling = (ZeroHandling) this.interface30_2.imethod_14();
        dimensionStyle.AngularZeroHandling = (ZeroHandling) this.interface30_2.imethod_14();
      }
      if (this.class374_0.IsVersion21OrLater)
        dimensionStyle.ArcLengthSymbolPosition = (ArcLengthSymbolPosition) this.interface30_2.imethod_14();
      if (this.class374_0.IsVersion15OrLater)
      {
        dimensionStyle.TextHeight = this.interface30_2.imethod_8();
        dimensionStyle.CenterMarkSize = this.interface30_2.imethod_8();
        dimensionStyle.TickSize = this.interface30_2.imethod_8();
        dimensionStyle.AlternateUnitScaleFactor = this.interface30_2.imethod_8();
        dimensionStyle.LinearScaleFactor = this.interface30_2.imethod_8();
        dimensionStyle.TextVerticalPosition = this.interface30_2.imethod_8();
        dimensionStyle.ToleranceScaleFactor = this.interface30_2.imethod_8();
        dimensionStyle.DimensionLineGap = this.interface30_2.imethod_8();
        dimensionStyle.AlternateUnitRounding = this.interface30_2.imethod_8();
        dimensionStyle.AlternateUnitDimensioning = this.interface30_2.imethod_6();
        dimensionStyle.AlternateUnitDecimalPlaces = this.interface30_2.imethod_14();
        dimensionStyle.TextOutsideExtensions = this.interface30_2.imethod_6();
        dimensionStyle.SeparateArrowBlocks = this.interface30_2.imethod_6();
        dimensionStyle.TextInsideExtensions = this.interface30_2.imethod_6();
        dimensionStyle.SuppressOutsideExtensions = this.interface30_2.imethod_6();
        dimensionStyle.DimensionLineColor = this.interface30_1.imethod_22();
        dimensionStyle.ExtensionLineColor = this.interface30_1.imethod_22();
        dimensionStyle.TextColor = this.interface30_1.imethod_22();
        dimensionStyle.AngularDimensionDecimalPlaces = this.interface30_2.imethod_14();
        dimensionStyle.DecimalPlaces = this.interface30_2.imethod_14();
        dimensionStyle.ToleranceDecimalPlaces = this.interface30_2.imethod_14();
        dimensionStyle.AlternateUnitFormat = (AlternateUnitFormat) this.interface30_2.imethod_14();
        dimensionStyle.AlternateUnitToleranceDecimalPlaces = this.interface30_2.imethod_14();
        dimensionStyle.AngularUnit = (AngularUnit) this.interface30_2.imethod_14();
        dimensionStyle.FractionFormat = (FractionFormat) this.interface30_2.imethod_14();
        dimensionStyle.LinearUnitFormat = (LinearUnitFormat) this.interface30_2.imethod_14();
        dimensionStyle.DecimalSeparator = (char) this.interface30_2.imethod_14();
        dimensionStyle.TextMovement = (TextMovement) this.interface30_2.imethod_14();
        dimensionStyle.TextHorizontalAlignment = (DimensionTextHorizontalAlignment) this.interface30_2.imethod_14();
        dimensionStyle.SuppressFirstDimensionLine = this.interface30_2.imethod_6();
        dimensionStyle.SuppressSecondDimensionLine = this.interface30_2.imethod_6();
        dimensionStyle.ToleranceAlignment = (ToleranceAlignment) this.interface30_2.imethod_14();
        dimensionStyle.ToleranceZeroHandling = (ZeroHandling) this.interface30_2.imethod_14();
        dimensionStyle.AlternateUnitZeroHandling = (ZeroHandling) this.interface30_2.imethod_14();
        dimensionStyle.AlternateUnitToleranceZeroHandling = (ZeroHandling) this.interface30_2.imethod_14();
        dimensionStyle.CursorUpdate = (CursorUpdate) this.interface30_2.imethod_7();
        int num = (int) this.interface30_2.imethod_14();
      }
      if (this.class374_0.IsVersion21OrLater)
        dimensionStyle.IsExtensionLineLengthFixed = this.interface30_2.imethod_6();
      if (this.class374_0.Version > DxfVersion.Dxf21)
      {
        dimensionStyle.TextDirection = this.interface30_2.imethod_6() ? TextDirection.RightToLeft : TextDirection.LeftToRight;
        dimensionStyle.AltMzf = this.interface30_2.imethod_8();
        dimensionStyle.AltMzs = this.interface30_3.ReadString();
        dimensionStyle.Mzf = this.interface30_2.imethod_8();
        dimensionStyle.Mzs = this.interface30_3.ReadString();
      }
      if (this.class374_0.IsVersion15OrLater)
      {
        dimensionStyle.DimensionLineWeight = this.interface30_2.imethod_14();
        dimensionStyle.ExtensionLineWeight = this.interface30_2.imethod_14();
      }
      this.interface30_2.imethod_6();
      long num3 = (long) this.method_100();
      class309.TextStyleHandle = this.method_100();
      if (this.class374_0.IsVersion15OrLater)
      {
        class309.LeaderArrowBlockHandle = this.method_100();
        class309.ArrowBlockHandle = this.method_100();
        class309.FirstArrowBlockHandle = this.method_100();
        class309.SecondArrowBlockHandle = this.method_100();
      }
      if (!this.class374_0.IsVersion21OrLater)
        return;
      class309.DimensionLineLineTypeHandle = this.method_100();
      class309.FirstExtensionLineLineTypeHandle = this.method_100();
      class309.SecondExtensionLineLineTypeHandle = this.method_100();
    }

    private void method_127()
    {
      DxfHandledObject tableControl = new DxfHandledObject();
      this.dxfModel_0.ViewportEntityHeaderTable = tableControl;
      Class321 class321 = new Class321(tableControl);
      this.class374_0.ObjectBuilders.Add((Class259) class321);
      this.method_94((Class259) class321);
      int num = (int) this.interface30_2.imethod_14();
      for (int index = 0; index < num; ++index)
        class321.TableRecordHandles.Add(this.method_100());
    }

    private void method_128()
    {
      DxfViewportEntityHeader viewportEntityHeader = new DxfViewportEntityHeader();
      Class316 class316 = new Class316(viewportEntityHeader);
      this.class374_0.ViewportEntityHeaderBuilders.Add(class316);
      this.method_94((Class259) class316);
      viewportEntityHeader.Name = this.interface30_3.ReadString();
      this.method_112((DxfTableRecord) viewportEntityHeader);
      viewportEntityHeader.IsViewportOn = this.interface30_2.imethod_6();
      long num1 = (long) this.method_100();
      long num2 = (long) this.method_100();
      class316.NextViewportHeaderHandle = this.method_100();
    }

    private void method_129()
    {
      Class290 entityBuilder = new Class290(new DxfText());
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_130(entityBuilder);
      this.method_131(entityBuilder);
      this.method_132(entityBuilder);
    }

    private void method_130(Class290 entityBuilder)
    {
      this.method_90((Class285) entityBuilder);
      DxfText entity = (DxfText) entityBuilder.Entity;
      if (this.class374_0.IsVersion13Or14)
      {
        double z = this.interface30_2.imethod_8();
        entity.AlignmentPoint1 = (WW.Math.Point3D) this.interface30_2.imethod_38() + new WW.Math.Vector3D(0.0, 0.0, z);
        entity.AlignmentPoint2 = new WW.Math.Point3D?((WW.Math.Point3D) this.interface30_2.imethod_38() + new WW.Math.Vector3D(0.0, 0.0, z));
        entity.ZAxis = this.interface30_2.imethod_51();
        entity.Thickness = this.interface30_2.imethod_8();
        entity.ObliqueAngle = this.interface30_2.imethod_8();
        entity.Rotation = this.interface30_2.imethod_8();
        entity.Height = this.interface30_2.imethod_8();
        entity.WidthFactor = this.interface30_2.imethod_8();
        entity.Text = this.interface30_3.ReadString();
        entity.TextGenerationFlags = (TextGenerationFlags) this.interface30_2.imethod_14();
        entity.HorizontalAlignment = (TextHorizontalAlignment) this.interface30_2.imethod_14();
        entity.VerticalAlignment = (TextVerticalAlignment) this.interface30_2.imethod_14();
      }
      if (!this.class374_0.IsVersion15OrLater)
        return;
      byte num = this.interface30_2.imethod_18();
      double z1 = 0.0;
      if (((int) num & 1) == 0)
        z1 = this.interface30_2.imethod_42();
      entity.AlignmentPoint1 = (WW.Math.Point3D) this.interface30_2.imethod_38() + new WW.Math.Vector3D(0.0, 0.0, z1);
      if (((int) num & 2) == 0)
      {
        double x = this.interface30_2.imethod_29(entity.AlignmentPoint1.X);
        double y = this.interface30_2.imethod_29(entity.AlignmentPoint1.Y);
        entity.AlignmentPoint2 = new WW.Math.Point3D?(new WW.Math.Point3D(x, y, z1));
      }
      entity.ZAxis = this.interface30_2.imethod_10();
      entity.Thickness = this.interface30_2.imethod_17();
      if (((int) num & 4) == 0)
        entity.ObliqueAngle = this.interface30_2.imethod_42();
      if (((int) num & 8) == 0)
        entity.Rotation = this.interface30_2.imethod_42();
      entity.Height = this.interface30_2.imethod_42();
      if (((int) num & 16) == 0)
        entity.WidthFactor = this.interface30_2.imethod_42();
      if (!this.class374_0.IsVersion21OrLater)
        entity.Text = this.interface30_3.ReadString();
      if (((int) num & 32) == 0)
        entity.TextGenerationFlags = (TextGenerationFlags) this.interface30_2.imethod_14();
      if (((int) num & 64) == 0)
        entity.HorizontalAlignment = (TextHorizontalAlignment) this.interface30_2.imethod_14();
      if (((int) num & 128) == 0)
        entity.VerticalAlignment = (TextVerticalAlignment) this.interface30_2.imethod_14();
      if (entity.AlignmentPoint2.HasValue)
      {
        if (entity.AlignmentPoint2.Value.X != 0.0 || (entity.AlignmentPoint2.Value.Y != 0.0 || entity.HorizontalAlignment != TextHorizontalAlignment.Left || entity.VerticalAlignment != TextVerticalAlignment.Baseline))
          return;
        entity.AlignmentPoint2 = new WW.Math.Point3D?();
      }
      else
      {
        if (entity.HorizontalAlignment == TextHorizontalAlignment.Left && entity.VerticalAlignment == TextVerticalAlignment.Baseline)
          return;
        entity.AlignmentPoint2 = new WW.Math.Point3D?(WW.Math.Point3D.Zero);
      }
    }

    private void method_131(Class290 entityBuilder)
    {
      if (!this.class374_0.IsVersion21OrLater)
        return;
      ((DxfText) entityBuilder.Entity).Text = this.interface30_3.ReadString();
    }

    private void method_132(Class290 entityBuilder)
    {
      entityBuilder.TextStyleHandle = this.method_100();
    }

    private void method_133()
    {
      DxfAttribute dxfAttribute = new DxfAttribute();
      Class290 entityBuilder = new Class290((DxfText) dxfAttribute);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_130(entityBuilder);
      if (this.class374_0.Version > DxfVersion.Dxf21)
        dxfAttribute.Unknown0 = this.interface30_2.imethod_18();
      if (!this.class374_0.IsVersion21OrLater)
        dxfAttribute.TagString = this.interface30_3.ReadString();
      int num = (int) this.interface30_2.imethod_14();
      dxfAttribute.Flags = (AttributeFlags) this.interface30_2.imethod_18();
      if (this.class374_0.IsVersion21OrLater)
        dxfAttribute.LockPosition = this.interface30_2.imethod_6();
      this.method_131(entityBuilder);
      if (this.class374_0.IsVersion21OrLater)
        dxfAttribute.TagString = this.interface30_3.ReadString();
      this.method_132(entityBuilder);
    }

    private void method_134()
    {
      DxfAttributeDefinition attributeDefinition = new DxfAttributeDefinition();
      Class290 entityBuilder = new Class290((DxfText) attributeDefinition);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_130(entityBuilder);
      this.method_131(entityBuilder);
      if (this.class374_0.Version > DxfVersion.Dxf21)
        attributeDefinition.Unknown0 = this.interface30_2.imethod_18();
      attributeDefinition.TagString = this.interface30_3.ReadString();
      int num = (int) this.interface30_2.imethod_14();
      attributeDefinition.Flags = (AttributeFlags) this.interface30_2.imethod_18();
      if (this.class374_0.IsVersion21OrLater)
        attributeDefinition.LockPosition = this.interface30_2.imethod_6();
      if (this.class374_0.Version > DxfVersion.Dxf21)
        attributeDefinition.Unknown1 = this.interface30_2.imethod_18();
      attributeDefinition.PromptString = this.interface30_3.ReadString();
      this.method_132(entityBuilder);
    }

    private void method_135()
    {
      DxfCircle dxfCircle = new DxfCircle();
      Class285 entityBuilder = new Class285((DxfEntity) dxfCircle);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
      dxfCircle.Center = this.interface30_2.imethod_39();
      dxfCircle.Radius = this.interface30_2.imethod_8();
      dxfCircle.Thickness = this.interface30_2.imethod_17();
      dxfCircle.ZAxis = this.interface30_2.imethod_10();
    }

    public static bool smethod_0(Interface30 objectMainBitStream, DxfOle ole)
    {
      try
      {
        ole.UnknownByte1 = objectMainBitStream.imethod_18();
        ole.UnknownByte2 = objectMainBitStream.imethod_18();
        ole.UpperLeft = objectMainBitStream.imethod_41();
        ole.UpperRight = objectMainBitStream.imethod_41();
        ole.LowerRight = objectMainBitStream.imethod_41();
        ole.LowerLeft = objectMainBitStream.imethod_41();
        ole.HimetricWidth = objectMainBitStream.imethod_45();
        ole.HimetricHeight = objectMainBitStream.imethod_45();
        objectMainBitStream.imethod_43();
        ole.OleItemVersion = objectMainBitStream.imethod_43();
        ole.ItemId = objectMainBitStream.imethod_43();
        ole.AdviseType = (DxfOle.Aspect) objectMainBitStream.imethod_43();
        ole.Moniker = objectMainBitStream.imethod_45() != (short) 0;
        ole.DrawAspect = (DxfOle.Aspect) objectMainBitStream.imethod_43();
        int length = objectMainBitStream.imethod_43();
        ole.OleData = objectMainBitStream.imethod_19(length);
      }
      catch (Exception ex)
      {
        return false;
      }
      return true;
    }

    private void method_136()
    {
      Class295 class295 = new Class295(new DxfIDBlockReference());
      this.class374_0.ObjectBuilders.Add((Class259) class295);
      bool hasAttributes;
      int ownedObjectCount;
      this.method_142((Class294) class295, out hasAttributes, out ownedObjectCount);
      this.method_143((Class294) class295, hasAttributes, ownedObjectCount);
      class295.Viewport = this.method_100();
    }

    private void method_137()
    {
      DxfOle ole = new DxfOle();
      Class285 entityBuilder = new Class285((DxfEntity) ole);
      this.method_90(entityBuilder);
      ole.UserType = "";
      ole.OleDataVersion = this.interface30_2.imethod_11();
      if (this.class374_0.Version > DxfVersion.Dxf14)
        ole.UnknownLong = this.interface30_2.imethod_11();
      this.interface30_2.imethod_11();
      if (!Class434.smethod_0(this.interface30_2, ole))
        return;
      this.dxfModel_0.UpdateOleItemCounter((uint) ole.ItemId);
      if (this.class374_0.Version > DxfVersion.Dxf14)
        ole.Quality = (DxfOle.QualityType) this.interface30_2.imethod_18();
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
    }

    private void method_138()
    {
      Class288 class288 = new Class288(new DxfBlockBegin());
      this.class374_0.BlockBeginBuilders.Add(class288);
      this.method_90((Class285) class288);
      class288.Name = this.interface30_3.ReadString();
    }

    private void method_139()
    {
      Class285 entityBuilder = new Class285((DxfEntity) new DxfBlockEnd());
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
    }

    private void method_140()
    {
      Class285 entityBuilder = new Class285((DxfEntity) new DxfSequenceEnd());
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
    }

    private void method_141()
    {
      Class294 entityBuilder = new Class294((DxfInsertBase) new DxfInsert());
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      bool hasAttributes;
      int ownedObjectCount;
      this.method_142(entityBuilder, out hasAttributes, out ownedObjectCount);
      this.method_143(entityBuilder, hasAttributes, ownedObjectCount);
    }

    private void method_142(
      Class294 entityBuilder,
      out bool hasAttributes,
      out int ownedObjectCount)
    {
      DxfInsertBase entity = (DxfInsertBase) entityBuilder.Entity;
      this.method_90((Class285) entityBuilder);
      entity.InsertionPoint = this.interface30_2.imethod_39();
      if (this.class374_0.IsVersion13Or14)
        entity.ScaleFactor = this.interface30_2.imethod_51();
      if (this.class374_0.IsVersion15OrLater)
      {
        switch (this.interface30_2.imethod_13())
        {
          case 0:
            double num1 = this.interface30_2.imethod_42();
            double y1 = this.interface30_2.imethod_29(num1);
            double z1 = this.interface30_2.imethod_29(num1);
            entity.ScaleFactor = new WW.Math.Vector3D(num1, y1, z1);
            break;
          case 1:
            double num2 = 1.0;
            double y2 = this.interface30_2.imethod_29(num2);
            double z2 = this.interface30_2.imethod_29(num2);
            entity.ScaleFactor = new WW.Math.Vector3D(num2, y2, z2);
            break;
          case 2:
            double num3 = this.interface30_2.imethod_42();
            entity.ScaleFactor = new WW.Math.Vector3D(num3, num3, num3);
            break;
          case 3:
            entity.ScaleFactor = new WW.Math.Vector3D(1.0, 1.0, 1.0);
            break;
        }
      }
      entity.Rotation = this.interface30_2.imethod_8();
      entity.ZAxis = this.interface30_2.imethod_51();
      hasAttributes = this.interface30_2.imethod_6();
      ownedObjectCount = 0;
      if (!this.class374_0.IsVersion18OrLater || !hasAttributes)
        return;
      ownedObjectCount = this.interface30_2.imethod_11();
    }

    private void method_143(Class294 entityBuilder, bool hasAttributes, int ownedObjectCount)
    {
      entityBuilder.BlockHeaderHandle = this.method_100();
      if (!hasAttributes)
        return;
      if (this.class374_0.Version >= DxfVersion.Dxf13 && this.class374_0.Version <= DxfVersion.Dxf15)
      {
        entityBuilder.FirstAttributeHandle = this.method_100();
        entityBuilder.LastAttributeHandle = this.method_100();
      }
      else if (this.class374_0.IsVersion18OrLater)
      {
        for (int index = 0; index < ownedObjectCount; ++index)
          entityBuilder.AttributeHandles.Add(this.method_100());
      }
      entityBuilder.EndSequenceHandle = this.method_100();
    }

    private void method_144()
    {
      DxfInsert dxfInsert = new DxfInsert();
      Class294 entityBuilder = new Class294((DxfInsertBase) dxfInsert);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      bool hasAttributes;
      int ownedObjectCount;
      this.method_142(entityBuilder, out hasAttributes, out ownedObjectCount);
      dxfInsert.ColumnCount = (ushort) this.interface30_2.imethod_14();
      dxfInsert.RowCount = (ushort) this.interface30_2.imethod_14();
      dxfInsert.ColumnSpacing = this.interface30_2.imethod_8();
      dxfInsert.RowSpacing = this.interface30_2.imethod_8();
      this.method_143(entityBuilder, hasAttributes, ownedObjectCount);
    }

    private void method_145()
    {
      DxfVertex2D dxfVertex2D = new DxfVertex2D();
      Class285 entityBuilder = new Class285((DxfEntity) dxfVertex2D);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
      dxfVertex2D.Flags = (Enum51) this.interface30_2.imethod_18();
      WW.Math.Point3D point3D = this.interface30_2.imethod_39();
      dxfVertex2D.Position = new WW.Math.Point2D(point3D.X, point3D.Y);
      double num = this.interface30_2.imethod_8();
      if (num < 0.0)
      {
        dxfVertex2D.StartWidth = -num;
        dxfVertex2D.EndWidth = -num;
      }
      else
      {
        dxfVertex2D.StartWidth = num;
        dxfVertex2D.EndWidth = this.interface30_2.imethod_8();
      }
      dxfVertex2D.Bulge = this.interface30_2.imethod_8();
      if (this.class374_0.Version > DxfVersion.Dxf21)
        dxfVertex2D.VertexId = this.interface30_2.imethod_11();
      dxfVertex2D.TangentDirection = this.interface30_2.imethod_8();
    }

    private void method_146()
    {
      DxfVertex3D vertex = new DxfVertex3D();
      Class301 class301 = new Class301(vertex);
      this.class374_0.ObjectBuilders.Add((Class259) class301);
      this.method_90((Class285) class301);
      class301.Flags = (Enum51) this.interface30_2.imethod_18();
      vertex.Position = this.interface30_2.imethod_39();
    }

    private void method_147()
    {
      Class286 class286 = new Class286(new DxfMeshFace());
      this.class374_0.ObjectBuilders.Add((Class259) class286);
      this.method_90((Class285) class286);
      class286.Vertex0Index = this.interface30_2.imethod_14();
      class286.Vertex1Index = this.interface30_2.imethod_14();
      class286.Vertex2Index = this.interface30_2.imethod_14();
      class286.Vertex3Index = this.interface30_2.imethod_14();
    }

    private void method_148()
    {
      ns3.Class8 class8 = new ns3.Class8();
      Class297 class297 = new Class297((DxfPolylineBase) class8);
      this.class374_0.ObjectBuilders.Add((Class259) class297);
      this.method_91((Class285) class297, false);
      class8.Flags = (Enum21) this.interface30_2.imethod_14();
      DxfPolyline2DBase dxfPolyline2Dbase;
      if (class8.IsSpline)
      {
        DxfPolyline2DSpline polyline2Dspline = new DxfPolyline2DSpline();
        this.method_99((DxfEntity) class8, (DxfEntity) polyline2Dspline);
        polyline2Dspline.Flags = class8.Flags;
        polyline2Dspline.SplineType = (SplineType) this.interface30_2.imethod_14();
        class297.Entity = (DxfEntity) polyline2Dspline;
        dxfPolyline2Dbase = (DxfPolyline2DBase) polyline2Dspline;
      }
      else
      {
        DxfPolyline2D dxfPolyline2D = new DxfPolyline2D();
        this.method_99((DxfEntity) class8, (DxfEntity) dxfPolyline2D);
        dxfPolyline2D.Flags = class8.Flags;
        int num = (int) this.interface30_2.imethod_14();
        class297.Entity = (DxfEntity) dxfPolyline2D;
        dxfPolyline2Dbase = (DxfPolyline2DBase) dxfPolyline2D;
      }
      dxfPolyline2Dbase.DefaultStartWidth = this.interface30_2.imethod_8();
      dxfPolyline2Dbase.DefaultEndWidth = this.interface30_2.imethod_8();
      dxfPolyline2Dbase.Thickness = this.interface30_2.imethod_17();
      dxfPolyline2Dbase.Elevation = this.interface30_2.imethod_8();
      dxfPolyline2Dbase.ZAxis = this.interface30_2.imethod_10();
      int num1 = 0;
      if (this.class374_0.IsVersion18OrLater)
        num1 = this.interface30_2.imethod_11();
      if (this.class374_0.Version >= DxfVersion.Dxf13 && this.class374_0.Version <= DxfVersion.Dxf15)
      {
        class297.FirstVertexHandle = this.method_100();
        class297.LastVertexHandle = this.method_100();
      }
      if (this.class374_0.IsVersion18OrLater)
      {
        for (int index = 0; index < num1; ++index)
          class297.VertexHandles.Add(this.method_100());
      }
      class297.SequenceEndHandle = this.method_100();
      this.class374_0.method_1((Class259) class297);
    }

    private void method_149()
    {
      ns3.Class8 class8 = new ns3.Class8();
      Class303 class303 = new Class303((DxfPolylineBase) class8);
      this.class374_0.ObjectBuilders.Add((Class259) class303);
      this.method_91((Class285) class303, false);
      byte num1 = this.interface30_2.imethod_18();
      bool flag1 = ((int) num1 & 1) != 0;
      bool flag2 = ((int) num1 & 2) != 0;
      DxfPolyline3DBase dxfPolyline3Dbase;
      if (!flag1 && !flag2)
      {
        DxfPolyline3D dxfPolyline3D = new DxfPolyline3D();
        this.method_99((DxfEntity) class8, (DxfEntity) dxfPolyline3D);
        class303.Entity = (DxfEntity) dxfPolyline3D;
        dxfPolyline3Dbase = (DxfPolyline3DBase) dxfPolyline3D;
      }
      else
      {
        DxfPolyline3DSpline polyline3Dspline = new DxfPolyline3DSpline();
        this.method_99((DxfEntity) class8, (DxfEntity) polyline3Dspline);
        polyline3Dspline.Flags |= Enum21.flag_3;
        if (flag1)
          polyline3Dspline.SplineType = SplineType.QuadraticBSpline;
        else if (flag2)
          polyline3Dspline.SplineType = SplineType.CubicBSpline;
        class303.Entity = (DxfEntity) polyline3Dspline;
        dxfPolyline3Dbase = (DxfPolyline3DBase) polyline3Dspline;
      }
      if (((int) this.interface30_2.imethod_18() & 1) != 0)
        dxfPolyline3Dbase.Closed = true;
      int num2 = 0;
      if (this.class374_0.IsVersion18OrLater)
        num2 = this.interface30_2.imethod_11();
      if (this.class374_0.Version >= DxfVersion.Dxf13 && this.class374_0.Version <= DxfVersion.Dxf15)
      {
        class303.FirstVertexHandle = this.method_100();
        class303.LastVertexHandle = this.method_100();
      }
      if (this.class374_0.IsVersion18OrLater)
      {
        for (int index = 0; index < num2; ++index)
          class303.VertexHandles.Add(this.method_100());
      }
      class303.SequenceEndHandle = this.method_100();
      this.class374_0.method_1((Class259) class303);
    }

    private void method_150()
    {
      DxfArc dxfArc = new DxfArc();
      Class285 entityBuilder = new Class285((DxfEntity) dxfArc);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
      dxfArc.Center = this.interface30_2.imethod_39();
      dxfArc.Radius = this.interface30_2.imethod_8();
      dxfArc.Thickness = this.interface30_2.imethod_17();
      dxfArc.ZAxis = this.interface30_2.imethod_10();
      dxfArc.StartAngle = this.interface30_2.imethod_8();
      dxfArc.EndAngle = this.interface30_2.imethod_8();
    }

    private void method_151()
    {
      DxfLine dxfLine = new DxfLine();
      Class285 entityBuilder = new Class285((DxfEntity) dxfLine);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
      if (this.class374_0.IsVersion13Or14)
      {
        dxfLine.Start = this.interface30_2.imethod_39();
        dxfLine.End = this.interface30_2.imethod_39();
      }
      if (this.class374_0.IsVersion15OrLater)
      {
        bool flag = this.interface30_2.imethod_6();
        double num1 = this.interface30_2.imethod_42();
        double x = this.interface30_2.imethod_29(num1);
        double num2 = this.interface30_2.imethod_42();
        double y = this.interface30_2.imethod_29(num2);
        double num3 = 0.0;
        double z = 0.0;
        if (!flag)
        {
          num3 = this.interface30_2.imethod_42();
          z = this.interface30_2.imethod_29(num3);
        }
        dxfLine.Start = new WW.Math.Point3D(num1, num2, num3);
        dxfLine.End = new WW.Math.Point3D(x, y, z);
      }
      dxfLine.Thickness = this.interface30_2.imethod_17();
      dxfLine.ZAxis = this.interface30_2.imethod_10();
    }

    private void method_152()
    {
      DxfDimension.Ordinate ordinate = new DxfDimension.Ordinate(this.dxfModel_0);
      Class299 entityBuilder = new Class299((DxfDimension) ordinate);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_153(entityBuilder);
      ordinate.UcsOrigin = this.interface30_2.imethod_39();
      ordinate.FeaturePosition = this.interface30_2.imethod_39();
      ordinate.LeaderEndPoint = this.interface30_2.imethod_39();
      byte num = this.interface30_2.imethod_18();
      ordinate.ShowX = ((int) num & 1) != 0;
      this.method_154(entityBuilder);
      this.method_155(entityBuilder);
    }

    private void method_153(Class299 entityBuilder)
    {
      DxfDimension handledObject = (DxfDimension) entityBuilder.HandledObject;
      this.method_90((Class285) entityBuilder);
      if (this.class374_0.Version > DxfVersion.Dxf21)
        handledObject.Version = this.interface30_2.imethod_18();
      handledObject.ZAxis = this.interface30_2.imethod_51();
      WW.Math.Point2D point2D1 = this.interface30_2.imethod_38();
      double z = this.interface30_2.imethod_8();
      handledObject.TextMiddlePoint = new WW.Math.Point3D(point2D1.X, point2D1.Y, z);
      byte num = this.interface30_2.imethod_18();
      handledObject.UseTextMiddlePoint = ((int) num & 1) == 0;
      if (!this.class374_0.IsVersion21OrLater)
        handledObject.Text = this.interface30_3.ReadString();
      handledObject.method_14(this.interface30_2.imethod_8());
      handledObject.HorizontalDirection = this.interface30_2.imethod_8();
      handledObject.InsertionScaleFactor = new WW.Math.Vector3D(this.interface30_2.imethod_8(), this.interface30_2.imethod_8(), this.interface30_2.imethod_8());
      handledObject.InsertionRotation = this.interface30_2.imethod_8();
      if (this.class374_0.IsVersion15OrLater)
      {
        handledObject.AttachmentPoint = (AttachmentPoint) this.interface30_2.imethod_14();
        handledObject.LineSpacingStyle = (LineSpacingStyle) this.interface30_2.imethod_14();
        handledObject.LineSpacingFactor = this.interface30_2.imethod_8();
        handledObject.Measurement = this.interface30_2.imethod_8();
      }
      if (this.class374_0.IsVersion21OrLater)
      {
        this.interface30_2.imethod_6();
        this.interface30_2.imethod_6();
        this.interface30_2.imethod_6();
      }
      WW.Math.Point2D point2D2 = this.interface30_2.imethod_38();
      handledObject.InsertionPoint = new WW.Math.Point3D(point2D2.X, point2D2.Y, z);
    }

    private void method_154(Class299 entityBuilder)
    {
      if (!this.class374_0.IsVersion21OrLater)
        return;
      ((DxfDimension) entityBuilder.HandledObject).Text = this.interface30_3.ReadString();
    }

    private void method_155(Class299 entityBuilder)
    {
      entityBuilder.DimStyleHandle = this.method_100();
      entityBuilder.AnonymousBlockHandle = this.method_100();
    }

    private void method_156()
    {
      DxfDimension.Linear linear = new DxfDimension.Linear(this.dxfModel_0);
      Class299 entityBuilder = new Class299((DxfDimension) linear);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_158(entityBuilder);
      linear.Rotation = this.interface30_2.imethod_8();
      this.method_154(entityBuilder);
      this.method_155(entityBuilder);
    }

    private void method_157()
    {
      Class299 entityBuilder = new Class299((DxfDimension) new DxfDimension.Aligned(this.dxfModel_0));
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_158(entityBuilder);
      this.method_154(entityBuilder);
      this.method_155(entityBuilder);
    }

    private void method_158(Class299 entityBuilder)
    {
      DxfDimension.Aligned handledObject = (DxfDimension.Aligned) entityBuilder.HandledObject;
      this.method_153(entityBuilder);
      handledObject.ExtensionLine1StartPoint = this.interface30_2.imethod_39();
      handledObject.ExtensionLine2StartPoint = this.interface30_2.imethod_39();
      handledObject.DimensionLineLocation = this.interface30_2.imethod_39();
      handledObject.ObliqueAngle = this.interface30_2.imethod_8();
    }

    private void method_159()
    {
      DxfDimension.Angular3Point angular3Point = new DxfDimension.Angular3Point(this.dxfModel_0);
      Class299 entityBuilder = new Class299((DxfDimension) angular3Point);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_153(entityBuilder);
      angular3Point.DimensionLineArcPoint = this.interface30_2.imethod_39();
      angular3Point.ExtensionLine1StartPoint = this.interface30_2.imethod_39();
      angular3Point.ExtensionLine2StartPoint = this.interface30_2.imethod_39();
      angular3Point.AngleVertex = this.interface30_2.imethod_39();
      this.method_154(entityBuilder);
      this.method_155(entityBuilder);
    }

    private void method_160()
    {
      DxfDimension.Angular4Point angular4Point = new DxfDimension.Angular4Point(this.dxfModel_0);
      Class299 entityBuilder = new Class299((DxfDimension) angular4Point);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_153(entityBuilder);
      WW.Math.Point2D point2D = this.interface30_2.imethod_38();
      angular4Point.DimensionLineArcPoint = new WW.Math.Point3D(point2D.X, point2D.Y, angular4Point.TextMiddlePoint.Z);
      angular4Point.ExtensionLine1StartPoint = this.interface30_2.imethod_39();
      angular4Point.ExtensionLine1EndPoint = this.interface30_2.imethod_39();
      angular4Point.ExtensionLine2StartPoint = this.interface30_2.imethod_39();
      angular4Point.ExtensionLine2EndPoint = this.interface30_2.imethod_39();
      this.method_154(entityBuilder);
      this.method_155(entityBuilder);
    }

    private void method_161()
    {
      DxfDimension.Radial radial = new DxfDimension.Radial(this.dxfModel_0);
      Class299 entityBuilder = new Class299((DxfDimension) radial);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_153(entityBuilder);
      radial.Center = this.interface30_2.imethod_39();
      radial.ArcLineIntersectionPoint = this.interface30_2.imethod_39();
      radial.LeaderLength = this.interface30_2.imethod_8();
      this.method_154(entityBuilder);
      this.method_155(entityBuilder);
    }

    private void method_162()
    {
      DxfDimension.Diametric diametric = new DxfDimension.Diametric(this.dxfModel_0);
      Class299 entityBuilder = new Class299((DxfDimension) diametric);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_153(entityBuilder);
      diametric.ArcLineIntersectionPoint1 = this.interface30_2.imethod_39();
      diametric.ArcLineIntersectionPoint2 = this.interface30_2.imethod_39();
      diametric.LeaderLength = this.interface30_2.imethod_8();
      this.method_154(entityBuilder);
      this.method_155(entityBuilder);
    }

    private void method_163()
    {
      DxfPoint dxfPoint = new DxfPoint();
      Class285 entityBuilder = new Class285((DxfEntity) dxfPoint);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
      dxfPoint.Position = this.interface30_2.imethod_39();
      dxfPoint.Thickness = this.interface30_2.imethod_17();
      dxfPoint.ZAxis = this.interface30_2.imethod_10();
      dxfPoint.XAxisAngle = this.interface30_2.imethod_8();
    }

    private void method_164()
    {
      Dxf3DFace dxf3Dface = new Dxf3DFace();
      Class285 entityBuilder = new Class285((DxfEntity) dxf3Dface);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
      if (this.class374_0.IsVersion13Or14)
      {
        dxf3Dface.Points.Add(this.interface30_2.imethod_39());
        dxf3Dface.Points.Add(this.interface30_2.imethod_39());
        dxf3Dface.Points.Add(this.interface30_2.imethod_39());
        dxf3Dface.Points.Add(this.interface30_2.imethod_39());
        dxf3Dface.method_14((InvisibleEdgeFlags) this.interface30_2.imethod_14());
      }
      if (!this.class374_0.IsVersion15OrLater)
        return;
      bool flag1 = this.interface30_2.imethod_6();
      bool flag2 = this.interface30_2.imethod_6();
      double x = this.interface30_2.imethod_42();
      double y = this.interface30_2.imethod_42();
      double z = 0.0;
      if (!flag2)
        z = this.interface30_2.imethod_42();
      WW.Math.Point3D defaultPoint1 = new WW.Math.Point3D(x, y, z);
      dxf3Dface.Points.Add(defaultPoint1);
      WW.Math.Point3D defaultPoint2 = this.interface30_2.imethod_40(defaultPoint1);
      dxf3Dface.Points.Add(defaultPoint2);
      WW.Math.Point3D defaultPoint3 = this.interface30_2.imethod_40(defaultPoint2);
      dxf3Dface.Points.Add(defaultPoint3);
      WW.Math.Point3D point3D = this.interface30_2.imethod_40(defaultPoint3);
      if (point3D != defaultPoint1)
        dxf3Dface.Points.Add(point3D);
      if (flag1)
        return;
      dxf3Dface.method_14((InvisibleEdgeFlags) this.interface30_2.imethod_14());
    }

    private void method_165()
    {
      Class304 class304 = new Class304(new DxfPolyfaceMesh());
      this.class374_0.ObjectBuilders.Add((Class259) class304);
      this.method_90((Class285) class304);
      int num1 = (int) this.interface30_2.imethod_14();
      int num2 = (int) this.interface30_2.imethod_14();
      int num3 = 0;
      if (this.class374_0.IsVersion18OrLater)
        num3 = this.interface30_2.imethod_11();
      if (this.class374_0.Version >= DxfVersion.Dxf13 && this.class374_0.Version <= DxfVersion.Dxf15)
      {
        class304.FirstVertexHandle = this.method_100();
        class304.LastVertexHandle = this.method_100();
      }
      if (this.class374_0.IsVersion18OrLater)
      {
        for (int index = 0; index < num3; ++index)
          class304.VertexHandles.Add(this.method_100());
      }
      class304.SequenceEndHandle = this.method_100();
    }

    private void method_166()
    {
      ns3.Class7 class7 = new ns3.Class7();
      Class293 class293 = new Class293((DxfPolygonMeshBase) class7);
      this.class374_0.ObjectBuilders.Add((Class259) class293);
      this.method_91((Class285) class293, false);
      class7.Flags = (Enum21) this.interface30_2.imethod_14();
      if (class7.IsSpline)
      {
        DxfPolygonSplineMesh polygonSplineMesh = new DxfPolygonSplineMesh();
        this.method_99((DxfEntity) class7, (DxfEntity) polygonSplineMesh);
        polygonSplineMesh.Flags = class7.Flags;
        polygonSplineMesh.SplineType = (SplineType) this.interface30_2.imethod_14();
        class293.Entity = (DxfEntity) polygonSplineMesh;
      }
      else
      {
        DxfPolygonMesh dxfPolygonMesh = new DxfPolygonMesh();
        this.method_99((DxfEntity) class7, (DxfEntity) dxfPolygonMesh);
        dxfPolygonMesh.Flags = class7.Flags;
        int num = (int) this.interface30_2.imethod_14();
        class293.Entity = (DxfEntity) dxfPolygonMesh;
      }
      class293.MVertexCount = (ushort) this.interface30_2.imethod_14();
      class293.NVertexCount = (ushort) this.interface30_2.imethod_14();
      class293.SmoothSurfaceMDensity = (ushort) this.interface30_2.imethod_14();
      class293.SmoothSurfaceNDensity = (ushort) this.interface30_2.imethod_14();
      int num1 = 0;
      if (this.class374_0.IsVersion18OrLater)
        num1 = this.interface30_2.imethod_11();
      if (this.class374_0.Version >= DxfVersion.Dxf13 && this.class374_0.Version <= DxfVersion.Dxf15)
      {
        class293.FirstVertexHandle = this.method_100();
        class293.LastVertexHandle = this.method_100();
      }
      if (this.class374_0.IsVersion18OrLater)
      {
        for (int index = 0; index < num1; ++index)
          class293.VertexHandles.Add(this.method_100());
      }
      class293.SequenceEndHandle = this.method_100();
      this.class374_0.method_1((Class259) class293);
    }

    private void method_167()
    {
      DxfShape shape = new DxfShape();
      Class300 class300 = new Class300(shape);
      this.class374_0.ObjectBuilders.Add((Class259) class300);
      this.method_90((Class285) class300);
      shape.InsertionPoint = this.interface30_2.imethod_39();
      shape.ScaleFactor = this.interface30_2.imethod_8();
      shape.Rotation = this.interface30_2.imethod_8();
      shape.RelativeXScaleFactor = this.interface30_2.imethod_8();
      shape.ObliqueAngle = this.interface30_2.imethod_8();
      shape.Thickness = this.interface30_2.imethod_8();
      shape.method_14((ushort) this.interface30_2.imethod_14());
      shape.ZAxis = this.interface30_2.imethod_9();
      class300.TextStyleHandle = this.method_100();
    }

    private void method_168()
    {
      DxfSolid dxfSolid = new DxfSolid();
      Class285 entityBuilder = new Class285((DxfEntity) dxfSolid);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
      dxfSolid.Thickness = this.interface30_2.imethod_17();
      double z = this.interface30_2.imethod_8();
      WW.Math.Point2D point2D1 = this.interface30_2.imethod_38();
      dxfSolid.Points.Add(new WW.Math.Point3D(point2D1.X, point2D1.Y, z));
      WW.Math.Point2D point2D2 = this.interface30_2.imethod_38();
      dxfSolid.Points.Add(new WW.Math.Point3D(point2D2.X, point2D2.Y, z));
      WW.Math.Point2D point2D3 = this.interface30_2.imethod_38();
      dxfSolid.Points.Add(new WW.Math.Point3D(point2D3.X, point2D3.Y, z));
      WW.Math.Point2D point2D4 = this.interface30_2.imethod_38();
      dxfSolid.Points.Add(new WW.Math.Point3D(point2D4.X, point2D4.Y, z));
      dxfSolid.ZAxis = this.interface30_2.imethod_10();
    }

    private void method_169()
    {
      DxfViewport viewport = new DxfViewport();
      Class308 class308 = new Class308(viewport);
      this.class374_0.ViewportBuilders.Add(class308);
      this.method_90((Class285) class308);
      viewport.Center = this.interface30_2.imethod_39();
      double width = this.interface30_2.imethod_8();
      double height = this.interface30_2.imethod_8();
      viewport.Size = new Size2D(width, height);
      if (this.class374_0.IsVersion15OrLater)
      {
        viewport.Target = this.interface30_2.imethod_39();
        viewport.Direction = this.interface30_2.imethod_51();
        viewport.TwistAngle = this.interface30_2.imethod_8();
        viewport.ViewHeight = this.interface30_2.imethod_8();
        viewport.LensLength = this.interface30_2.imethod_8();
        viewport.FrontClipPlaneZValue = this.interface30_2.imethod_8();
        viewport.BackClipPlaneZValue = this.interface30_2.imethod_8();
        viewport.SnapAngle = this.interface30_2.imethod_8();
        viewport.ViewCenter = this.interface30_2.imethod_38();
        viewport.SnapBasePoint = this.interface30_2.imethod_38();
        viewport.SnapSpacing = this.interface30_2.imethod_50();
        viewport.GridSpacing = this.interface30_2.imethod_50();
        viewport.CircleZoomPercentage = (double) this.interface30_2.imethod_14();
      }
      if (this.class374_0.IsVersion21OrLater)
        viewport.MajorGridLineFrequency = this.interface30_2.imethod_14();
      int num1 = 0;
      if (this.class374_0.IsVersion15OrLater)
      {
        num1 = this.interface30_2.imethod_11();
        viewport.StatusFlags = (ViewportStatusFlags) this.interface30_2.imethod_11();
        this.interface30_3.ReadString();
        viewport.RenderMode = (RenderMode) this.interface30_2.imethod_18();
        viewport.DisplayUcsIcon = this.interface30_2.imethod_6();
        viewport.UcsPerViewport = this.interface30_2.imethod_6();
        viewport.Ucs.Origin = this.interface30_2.imethod_39();
        viewport.Ucs.XAxis = this.interface30_2.imethod_51();
        viewport.Ucs.YAxis = this.interface30_2.imethod_51();
        viewport.Ucs.Elevation = this.interface30_2.imethod_8();
        viewport.UcsOrthographicType = (OrthographicType) this.interface30_2.imethod_14();
      }
      if (this.class374_0.IsVersion18OrLater)
        viewport.ShadePlotMode = (ShadePlotMode) this.interface30_2.imethod_14();
      if (this.class374_0.IsVersion21OrLater)
      {
        viewport.UseDefaultLighting = this.interface30_2.imethod_6();
        viewport.DefaultLightingType = (LightingType) this.interface30_2.imethod_18();
        viewport.Brightness = this.interface30_2.imethod_8();
        viewport.Constrast = this.interface30_2.imethod_8();
        viewport.AmbientLightColor = this.interface30_2.imethod_22();
      }
      if (this.class374_0.IsVersion13Or14)
        class308.ViewportEntityHeaderHandle = this.method_100();
      if (this.class374_0.IsVersion15OrLater)
      {
        for (int index = 0; index < num1; ++index)
          class308.FrozenLayerHandles.Add(this.method_100());
        class308.ClippingBoundaryEntityHandle = this.method_100();
      }
      if (this.class374_0.Version == DxfVersion.Dxf15)
        class308.ViewportEntityHeaderHandle = this.method_100();
      if (this.class374_0.IsVersion15OrLater)
      {
        class308.NamedUcsHandle = this.method_100();
        class308.BaseUcsHandle = this.method_100();
      }
      if (!this.class374_0.IsVersion21OrLater)
        return;
      long num2 = (long) this.method_100();
      long num3 = (long) this.method_100();
      long num4 = (long) this.method_100();
      long num5 = (long) this.method_100();
    }

    private void method_170()
    {
      DxfEllipse dxfEllipse = new DxfEllipse();
      Class285 entityBuilder = new Class285((DxfEntity) dxfEllipse);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
      dxfEllipse.Center = this.interface30_2.imethod_39();
      dxfEllipse.MajorAxisEndPoint = this.interface30_2.imethod_51();
      dxfEllipse.ZAxis = this.interface30_2.imethod_51();
      dxfEllipse.method_13(this.interface30_2.imethod_8());
      dxfEllipse.StartParameter = this.interface30_2.imethod_8();
      dxfEllipse.EndParameter = this.interface30_2.imethod_8();
    }

    private bool method_171(DxfModelerGeometry common)
    {
      bool flag;
      if (!(flag = this.class374_0.Version >= DxfVersion.Dxf27))
      {
        if (!this.interface30_1.imethod_6())
          this.method_176(common);
      }
      try
      {
        if (this.interface30_1.imethod_6())
        {
          if (this.interface30_1.imethod_6())
            common.Center = new WW.Math.Point3D?(this.interface30_1.imethod_39());
          this.interface30_1.imethod_11();
          if (this.interface30_1.imethod_6())
          {
            int num = this.interface30_1.imethod_11();
            for (int index = 0; index < num; ++index)
            {
              Wire wire = new Wire();
              this.method_178(wire);
              common.Wires.Add(wire);
            }
          }
          uint num1 = (uint) this.interface30_1.imethod_11();
          if (num1 != 0U)
          {
            for (uint index = 0; index < num1; ++index)
            {
              Silhouette silhouette = new Silhouette();
              this.method_179(silhouette);
              common.Silhouettes.Add(silhouette);
            }
          }
          if (!this.interface30_1.imethod_6())
            this.method_176((DxfModelerGeometry) new DxfRegion());
        }
      }
      catch (Exception ex)
      {
        return false;
      }
      if (this.class374_0.Version > DxfVersion.Dxf18)
      {
        int num1 = this.interface30_1.imethod_11();
        while (num1-- != 0)
        {
          ModelerGeometryMaterial geometryMaterial = new ModelerGeometryMaterial() { MaterialIdLow = this.interface30_1.imethod_11(), MaterialIdHigh = this.interface30_1.imethod_11() };
          long num2 = (long) this.method_100();
        }
      }
      if (flag)
      {
        this.interface30_1.imethod_6();
        DxfModelerGeometry.DxfModelerGuid guid = new DxfModelerGeometry.DxfModelerGuid();
        this.method_172(ref guid);
        this.interface30_1.imethod_11();
      }
      return true;
    }

    private void method_172(ref DxfModelerGeometry.DxfModelerGuid guid)
    {
      int a = this.interface30_1.imethod_11();
      short b = this.interface30_1.imethod_14();
      short c = this.interface30_1.imethod_14();
      byte d = this.interface30_1.imethod_18();
      byte e = this.interface30_1.imethod_18();
      byte f = this.interface30_1.imethod_18();
      byte g = this.interface30_1.imethod_18();
      byte h = this.interface30_1.imethod_18();
      byte i = this.interface30_1.imethod_18();
      byte j = this.interface30_1.imethod_18();
      byte k = this.interface30_1.imethod_18();
      guid.Guid = new Guid(a, b, c, d, e, f, g, h, i, j, k);
    }

    private void method_173()
    {
      DxfRegion dxfRegion = new DxfRegion();
      Class285 entityBuilder = new Class285((DxfEntity) dxfRegion);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
      this.method_171((DxfModelerGeometry) dxfRegion);
    }

    private void method_174()
    {
      DxfBody dxfBody = new DxfBody();
      Class285 entityBuilder = new Class285((DxfEntity) dxfBody);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
      this.method_171((DxfModelerGeometry) dxfBody);
    }

    private void method_175()
    {
      Dxf3DSolid dxf3Dsolid = new Dxf3DSolid();
      Class285 entityBuilder = new Class285((DxfEntity) dxf3Dsolid);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
      this.method_171((DxfModelerGeometry) dxf3Dsolid);
      if (this.class374_0.Version <= DxfVersion.Dxf18)
        return;
      dxf3Dsolid.HistoryId = this.method_100();
      dxf3Dsolid.HistoryId = 0UL;
    }

    private void method_176(DxfModelerGeometry modelerGeometry)
    {
      this.interface30_1.imethod_6();
      short num = this.interface30_1.imethod_14();
      long bitPosition = this.interface30_1.imethod_3();
      Stream stream;
      switch (num)
      {
        case 1:
          stream = (Stream) this.method_177();
          break;
        case 2:
          stream = (Stream) new Stream0(this.interface30_1, (int) ((long) this.uint_1 - this.interface30_1.imethod_3() >> 3));
          break;
        default:
          throw new DxfException(new DxfMessage(DxfStatus.InvalidValue, Severity.Error, "formatVersion", (object) num));
      }
      if (modelerGeometry.method_13(stream))
        return;
      this.interface30_1.imethod_4(bitPosition);
    }

    private MemoryStream method_177()
    {
      MemoryStream memoryStream = new MemoryStream();
      for (int index = this.interface30_1.imethod_11(); index != 0; index = this.interface30_1.imethod_11())
      {
        byte[] numArray = this.interface30_1.imethod_19(index);
        DxfModelerGeometry.smethod_3(numArray, 0, index);
        memoryStream.Write(numArray, 0, index);
      }
      memoryStream.Position = 0L;
      return memoryStream;
    }

    private void method_178(Wire wire)
    {
      wire.Type = this.interface30_1.imethod_18();
      wire.SelectionMarker = this.interface30_1.imethod_11();
      short colorIndex = this.interface30_1.imethod_14();
      if (colorIndex > (short) 256)
        colorIndex = (short) 256;
      wire.Color = EntityColor.CreateFromColorIndex(colorIndex);
      wire.AcisIndex = this.interface30_1.imethod_11();
      uint num = (uint) this.interface30_1.imethod_11();
      while (num-- != 0U)
        wire.Points.Add(this.interface30_1.imethod_39());
      if (!this.interface30_1.imethod_6())
        return;
      wire.Transform = new WireTransform();
      wire.Transform.XAxis = this.interface30_1.imethod_51();
      wire.Transform.YAxis = this.interface30_1.imethod_51();
      wire.Transform.ZAxis = this.interface30_1.imethod_51();
      wire.Transform.Translation = this.interface30_1.imethod_51();
      wire.Transform.Scale = this.interface30_1.imethod_8();
      wire.Transform.HasRotation = this.interface30_1.imethod_6();
      wire.Transform.HasReflection = this.interface30_1.imethod_6();
      wire.Transform.HasShear = this.interface30_1.imethod_6();
    }

    private void method_179(Silhouette silhouette)
    {
      silhouette.ViewportId = this.class374_0.Version <= DxfVersion.Dxf21 ? (long) this.interface30_1.imethod_11() : this.interface30_1.imethod_12();
      silhouette.ViewportTarget = this.interface30_1.imethod_39();
      silhouette.ViewportDirectionFromTarget = this.interface30_1.imethod_51();
      silhouette.ViewportUpDirection = this.interface30_1.imethod_51();
      silhouette.ViewportPerspectiveMode = this.interface30_1.imethod_6();
      if (!this.interface30_1.imethod_6())
        return;
      uint num = (uint) this.interface30_1.imethod_11();
      while (num-- != 0U)
      {
        Wire wire = new Wire();
        this.method_178(wire);
        silhouette.Wires.Add(wire);
      }
    }

    private void method_180()
    {
      DxfSpline dxfSpline = new DxfSpline();
      Class285 entityBuilder = new Class285((DxfEntity) dxfSpline);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
      int num1 = this.interface30_2.imethod_11();
      if (this.class374_0.Version > DxfVersion.Dxf24)
      {
        dxfSpline.Flags1 = (SplineFlags1) this.interface30_1.imethod_11();
        dxfSpline.KnotParameterization = (KnotParameterization) this.interface30_1.imethod_11();
        dxfSpline.Closed = (dxfSpline.Flags1 & SplineFlags1.IsClosed) != SplineFlags1.None;
        num1 = dxfSpline.KnotParameterization == KnotParameterization.Custom ? 1 : 2;
      }
      dxfSpline.Degree = this.interface30_2.imethod_11();
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      bool flag = false;
      switch (num1)
      {
        case 1:
          dxfSpline.Rational = this.interface30_2.imethod_6();
          dxfSpline.Closed = this.interface30_2.imethod_6();
          dxfSpline.IsPeriodic = this.interface30_2.imethod_6();
          dxfSpline.KnotTolerance = this.interface30_2.imethod_8();
          dxfSpline.ControlPointTolerance = this.interface30_2.imethod_8();
          num3 = this.interface30_2.imethod_11();
          num4 = this.interface30_2.imethod_11();
          flag = this.interface30_2.imethod_6();
          break;
        case 2:
          dxfSpline.FitTolerance = this.interface30_2.imethod_8();
          dxfSpline.StartTangent = this.interface30_2.imethod_51();
          dxfSpline.EndTangent = this.interface30_2.imethod_51();
          num2 = this.interface30_2.imethod_11();
          break;
      }
      for (int index = 0; index < num3; ++index)
        dxfSpline.Knots.Add(this.interface30_2.imethod_8());
      for (int index = 0; index < num4; ++index)
      {
        dxfSpline.ControlPoints.Add(this.interface30_2.imethod_39());
        if (flag)
          dxfSpline.Weights.Add(this.interface30_2.imethod_8());
      }
      for (int index = 0; index < num2; ++index)
        dxfSpline.FitPoints.Add(this.interface30_2.imethod_39());
    }

    private void method_181()
    {
      DxfRay dxfRay = new DxfRay();
      Class285 entityBuilder = new Class285((DxfEntity) dxfRay);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
      dxfRay.StartPoint = this.interface30_2.imethod_39();
      dxfRay.Direction = this.interface30_2.imethod_51();
    }

    private void method_182()
    {
      DxfXLine dxfXline = new DxfXLine();
      Class285 entityBuilder = new Class285((DxfEntity) dxfXline);
      this.class374_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_90(entityBuilder);
      dxfXline.StartPoint = this.interface30_2.imethod_39();
      dxfXline.Direction = this.interface30_2.imethod_51();
    }

    private void method_183()
    {
      DxfMText text = new DxfMText();
      Class305 class305 = new Class305(text);
      this.class374_0.ObjectBuilders.Add((Class259) class305);
      this.method_90((Class285) class305);
      text.InsertionPoint = this.interface30_2.imethod_39();
      text.ZAxis = this.interface30_2.imethod_51();
      text.XAxis = this.interface30_2.imethod_51();
      text.ReferenceRectangleWidth = this.interface30_2.imethod_8();
      if (this.class374_0.IsVersion21OrLater)
        text.ReferenceRectangleHeight = this.interface30_2.imethod_8();
      text.Height = this.interface30_2.imethod_8();
      text.AttachmentPoint = (AttachmentPoint) this.interface30_2.imethod_14();
      text.DrawingDirection = (DrawingDirection) this.interface30_2.imethod_14();
      this.interface30_2.imethod_8();
      this.interface30_2.imethod_8();
      string str = this.interface30_3.ReadString();
      if (str != null)
        str = str.Replace("\r\n", "^J").Replace("\n", "^J");
      text.Text = str;
      if (this.class374_0.IsVersion15OrLater)
      {
        text.LineSpacingStyle = (LineSpacingStyle) this.interface30_2.imethod_14();
        text.LineSpacingFactor = this.interface30_2.imethod_8();
        this.interface30_2.imethod_6();
      }
      if (this.class374_0.IsVersion18OrLater)
      {
        text.BackgroundFillFlags = (BackgroundFillFlags) this.interface30_2.imethod_11();
        if ((text.BackgroundFillFlags & BackgroundFillFlags.UseBackgroundFillColor) != BackgroundFillFlags.None)
          text.BackgroundFillInfo = new BackgroundFillInfo()
          {
            BorderOffsetFactor = this.interface30_2.imethod_8(),
            Color = this.interface30_1.imethod_22(),
            Transparency = new Transparency((uint) this.interface30_2.imethod_11())
          };
      }
      class305.TextStyleHandle = this.method_100();
    }

    private void method_184()
    {
      DxfLeader leader = new DxfLeader(this.dxfModel_0);
      Class291 class291 = new Class291(leader);
      this.class374_0.ObjectBuilders.Add((Class259) class291);
      this.method_90((Class285) class291);
      this.interface30_2.imethod_6();
      leader.CreationType = (LeaderCreationType) this.interface30_2.imethod_14();
      leader.PathType = (LeaderPathType) this.interface30_2.imethod_14();
      int num1 = this.interface30_2.imethod_11();
      for (int index = 0; index < num1; ++index)
        leader.Vertices.Add(this.interface30_2.imethod_39());
      leader.Origin = this.interface30_2.imethod_39();
      leader.ZAxis = this.interface30_2.imethod_51();
      leader.HorizontalDirection = this.interface30_2.imethod_51();
      leader.LastVertexOffsetFromBlock = this.interface30_2.imethod_51();
      if (this.class374_0.Version >= DxfVersion.Dxf14)
        leader.LastVertexOffsetFromAnnotation = this.interface30_2.imethod_51();
      if (this.class374_0.IsVersion13Or14)
        leader.DimensionStyleOverrides.DimensionLineGap = this.interface30_2.imethod_8();
      if (this.class374_0.Version <= DxfVersion.Dxf21)
      {
        leader.TextAnnotationHeight = this.interface30_2.imethod_8();
        leader.TextAnnotationWidth = this.interface30_2.imethod_8();
      }
      bool flag = this.interface30_2.imethod_6();
      leader.HookLineDirection = flag ? HookLineDirection.Same : HookLineDirection.Opposite;
      leader.ArrowHeadEnabled = this.interface30_2.imethod_6();
      if (this.class374_0.IsVersion13Or14)
      {
        int num2 = (int) this.interface30_2.imethod_14();
        class291.ArrowSizeTimesScaleOverride = new double?(this.interface30_2.imethod_8());
        this.interface30_2.imethod_6();
        this.interface30_2.imethod_6();
        int num3 = (int) this.interface30_2.imethod_14();
        int num4 = (int) this.interface30_2.imethod_14();
        this.interface30_2.imethod_6();
        this.interface30_2.imethod_6();
      }
      if (this.class374_0.IsVersion15OrLater)
      {
        int num2 = (int) this.interface30_2.imethod_14();
        this.interface30_2.imethod_6();
        this.interface30_2.imethod_6();
      }
      class291.AssociatedAnnotationHandle = this.method_100();
      class291.DimensionStyleHandle = this.method_100();
      leader.method_13();
      class291.CalculateHookLinePoint = leader.HasHookLine;
    }

    private void method_185()
    {
      DxfTolerance tolerance = new DxfTolerance(this.dxfModel_0);
      Class302 class302 = new Class302(tolerance);
      this.class374_0.ObjectBuilders.Add((Class259) class302);
      this.method_90((Class285) class302);
      if (this.class374_0.IsVersion13Or14)
      {
        int num = (int) this.interface30_2.imethod_14();
        this.interface30_2.imethod_8();
        this.interface30_2.imethod_8();
      }
      tolerance.InsertionPoint = this.interface30_2.imethod_39();
      tolerance.XAxis = this.interface30_2.imethod_51();
      tolerance.ZAxis = this.interface30_2.imethod_51();
      tolerance.Text = this.interface30_3.ReadString();
      class302.DimensionStyleHandle = this.method_100();
    }

    private void method_186()
    {
      DxfMLine mline = new DxfMLine();
      Class306 class306 = new Class306(mline);
      this.class374_0.ObjectBuilders.Add((Class259) class306);
      this.method_90((Class285) class306);
      mline.ScaleFactor = this.interface30_2.imethod_8();
      mline.Alignment = (MLineAlignment) this.interface30_2.imethod_18();
      mline.StartPoint = this.interface30_2.imethod_39();
      mline.ZAxis = this.interface30_2.imethod_51();
      short num1 = this.interface30_2.imethod_14();
      mline.Closed = num1 == (short) 3;
      int num2 = (int) this.interface30_2.imethod_18();
      int num3 = (int) this.interface30_2.imethod_14();
      for (int index1 = 0; index1 < num3; ++index1)
      {
        DxfMLine.Segment segment = new DxfMLine.Segment(this.interface30_2.imethod_39(), this.interface30_2.imethod_51(), this.interface30_2.imethod_51());
        for (int index2 = 0; index2 < num2; ++index2)
        {
          DxfMLine.Segment.Element element = new DxfMLine.Segment.Element();
          int num4 = (int) this.interface30_2.imethod_14();
          for (int index3 = 0; index3 < num4; ++index3)
          {
            double num5 = this.interface30_2.imethod_8();
            element.Parameters.Add(num5);
          }
          int num6 = (int) this.interface30_2.imethod_14();
          for (int index3 = 0; index3 < num6; ++index3)
          {
            double num5 = this.interface30_2.imethod_8();
            element.AreaFillParameters.Add(num5);
          }
          segment.Elements.Add(element);
        }
        mline.Segments.Add(segment);
      }
      class306.MLineStyleHandle = this.method_100();
    }

    private void method_187()
    {
      DxfTable table1 = new DxfTable();
      Class296 class296 = new Class296(table1);
      this.class374_0.ObjectBuilders.Add((Class259) class296);
      this.method_188((DxfInsertBase) table1, (Class294) class296);
      if (this.class374_0.Version > DxfVersion.Dxf21)
      {
        table1.Unknown0 = this.interface30_1.imethod_18();
        class296.Unknown1Handle = this.method_100();
        table1.Unknown2 = this.interface30_1.imethod_11();
        if (this.class374_0.Version > DxfVersion.Dxf24)
          table1.Unknown5 = this.interface30_1.imethod_11();
        else
          table1.Unknown3 = this.interface30_1.imethod_6();
        DxfTableContent tableContent = new DxfTableContent();
        Class275 tableContentBuilder = new Class275(tableContent);
        class296.PrerequisiteBuilders.Add((Interface10) tableContentBuilder);
        this.method_235(tableContentBuilder, tableContent);
        table1.Content = tableContent;
        table1.Unknown4 = this.interface30_1.imethod_14();
        table1.HorizontalDirection = this.interface30_1.imethod_51();
        table1.BreakData.Flags = this.interface30_1.imethod_11();
        if (table1.BreakData.Flags != 0)
        {
          DxfTableBreakData breakData = table1.BreakData;
          breakData.OptionFlags = (TableBreakOptionFlags) this.interface30_1.imethod_11();
          breakData.FlowDirection = (TableBreakFlowDirection) this.interface30_1.imethod_11();
          breakData.BreakSpacing = this.interface30_1.imethod_8();
          breakData.UnknownFlags1 = this.interface30_1.imethod_11();
          breakData.UnknownFlags2 = this.interface30_1.imethod_11();
          int num = this.interface30_1.imethod_11();
          for (int index = 0; index < num; ++index)
            breakData.BreakHeights.Add(new DxfTableBreakHeight()
            {
              Position = this.interface30_1.imethod_39(),
              Height = this.interface30_1.imethod_8(),
              Flags = this.interface30_1.imethod_11()
            });
        }
        int num1 = this.interface30_1.imethod_11();
        for (int index = 0; index < num1; ++index)
          table1.BreakData.RowRanges.Add(new DxfTableBreakRowRange()
          {
            Position = this.interface30_1.imethod_39(),
            StartRowIndex = this.interface30_1.imethod_11(),
            EndRowIndex = this.interface30_1.imethod_11()
          });
      }
      else
      {
        Class551 table2 = new Class551();
        Class1049 tableBuilder = new Class1049(table2);
        class296.PrerequisiteBuilders.Add((Interface10) tableBuilder);
        table1.Table2005 = table2;
        table2.TableFlags = (int) this.interface30_1.imethod_14();
        tableBuilder.TableStyleHandle = this.method_100();
        table2.HorizontalDirection = this.interface30_1.imethod_51();
        table2.method_8(this.interface30_1.imethod_11(), false);
        table2.method_7(this.interface30_1.imethod_11(), false);
        for (int index = 0; index < table2.ColumnCount; ++index)
          table2.Columns[index].Width = this.interface30_1.imethod_8();
        for (int index = 0; index < table2.RowCount; ++index)
          table2.Rows[index].Height = this.interface30_1.imethod_8();
        for (int index1 = 0; index1 < table2.RowCount; ++index1)
        {
          for (int index2 = 0; index2 < table2.ColumnCount; ++index2)
            this.method_195(tableBuilder, table2.Rows[index1].Cells[index2]);
        }
        this.method_189(table2, tableBuilder);
        this.method_191(table2, tableBuilder);
        this.method_193(table2, tableBuilder);
        this.method_194(table2, tableBuilder);
      }
    }

    private void method_188(DxfInsertBase insertBase, Class294 entityBuilder)
    {
      bool hasAttributes;
      int ownedObjectCount;
      this.method_142(entityBuilder, out hasAttributes, out ownedObjectCount);
      this.method_143(entityBuilder, hasAttributes, ownedObjectCount);
    }

    private void method_189(Class551 table, Class1049 tableBuilder)
    {
      if (!this.interface30_1.imethod_6())
        return;
      int num = this.interface30_1.imethod_11();
      if ((num & 1) != 0)
        table.SuppressTitle = new bool?(this.interface30_1.imethod_6());
      if ((num & 2) != 0)
        table.SuppressHeaderRow = new bool?(true);
      if ((num & 4) != 0)
        table.FlowDirection = new TableFlowDirection?((TableFlowDirection) this.interface30_1.imethod_14());
      if ((num & 8) != 0)
        table.HorizontalCellMargin = new double?(this.interface30_1.imethod_8());
      if ((num & 16) != 0)
        table.VerticalCellMargin = new double?(this.interface30_1.imethod_8());
      if ((num & 32) != 0)
        table.TitleRowCellStyle.ContentColor = new Color?(this.interface30_1.imethod_24());
      if ((num & 64) != 0)
        table.HeaderRowCellStyle.ContentColor = new Color?(this.interface30_1.imethod_24());
      if ((num & 128) != 0)
        table.DataRowCellStyle.ContentColor = new Color?(this.interface30_1.imethod_24());
      if ((num & 256) != 0)
        table.TitleRowCellStyle.IsBackColorEnabled = new bool?(this.interface30_1.imethod_6());
      if ((num & 512) != 0)
        table.HeaderRowCellStyle.IsBackColorEnabled = new bool?(this.interface30_1.imethod_6());
      if ((num & 1024) != 0)
        table.DataRowCellStyle.IsBackColorEnabled = new bool?(this.interface30_1.imethod_6());
      if ((num & 2048) != 0)
        table.TitleRowCellStyle.BackColor = new Color?(this.interface30_1.imethod_24());
      if ((num & 4096) != 0)
        table.HeaderRowCellStyle.BackColor = new Color?(this.interface30_1.imethod_24());
      if ((num & 8192) != 0)
        table.DataRowCellStyle.BackColor = new Color?(this.interface30_1.imethod_24());
      if ((num & 16384) != 0)
        table.TitleRowCellStyle.CellAlignment = new CellAlignment?((CellAlignment) this.interface30_1.imethod_14());
      if ((num & 32768) != 0)
        table.HeaderRowCellStyle.CellAlignment = new CellAlignment?((CellAlignment) this.interface30_1.imethod_14());
      if ((num & 65536) != 0)
        table.DataRowCellStyle.CellAlignment = new CellAlignment?((CellAlignment) this.interface30_1.imethod_14());
      if ((num & 131072) != 0)
        tableBuilder.TitleRowBuilder.TextStyleHandle = this.method_100();
      if ((num & 262144) != 0)
        tableBuilder.HeaderRowBuilder.TextStyleHandle = this.method_100();
      if ((num & 524288) != 0)
        tableBuilder.DataRowBuilder.TextStyleHandle = this.method_100();
      if ((num & 1048576) != 0)
        table.TitleRowCellStyle.TextHeight = new double?(this.interface30_1.imethod_8());
      if ((num & 2097152) != 0)
        table.HeaderRowCellStyle.TextHeight = new double?(this.interface30_1.imethod_8());
      if ((num & 4194304) != 0)
        table.DataRowCellStyle.TextHeight = new double?(this.interface30_1.imethod_8());
      if (!this.class374_0.IsVersion21OrLater)
        return;
      if ((num & 8388608) != 0)
        this.method_190(tableBuilder.TitleRowBuilder);
      if ((num & 16777216) != 0)
        this.method_190(tableBuilder.HeaderRowBuilder);
      if ((num & 33554432) == 0)
        return;
      this.method_190(tableBuilder.DataRowBuilder);
    }

    private void method_190(Class1000 tableRowBuilder)
    {
      tableRowBuilder.DataType = new ValueDataType?((ValueDataType) this.interface30_1.imethod_11());
      tableRowBuilder.DataUnitType = new ValueUnitType?((ValueUnitType) this.interface30_1.imethod_11());
      tableRowBuilder.FormatString = this.interface30_1.ReadString();
    }

    private void method_191(Class551 table, Class1049 tableBuilder)
    {
      if (!this.interface30_1.imethod_6())
        return;
      int num = this.interface30_1.imethod_11();
      if ((num & 1) != 0)
        this.method_192(table.BorderTop);
      if ((num & 2) != 0)
        this.method_192(table.BorderInsideHorizontal);
      if ((num & 4) != 0)
        this.method_192(table.BorderBottom);
      if ((num & 8) != 0)
        this.method_192(table.BorderLeft);
      if ((num & 16) != 0)
        this.method_192(table.BorderInsideVertical);
      if ((num & 32) == 0)
        return;
      this.method_192(table.BorderRight);
    }

    private void method_192(DxfTableBorderOverrides borderOverrides)
    {
      borderOverrides.Color = new Color?(this.interface30_1.imethod_24());
    }

    private void method_193(Class551 table, Class1049 tableBuilder)
    {
      if (!this.interface30_1.imethod_6())
        return;
      int num = this.interface30_1.imethod_11();
      if ((num & 1) != 0)
        table.BorderTop.LineWeight = new short?(this.interface30_1.imethod_14());
      if ((num & 2) != 0)
        table.BorderInsideHorizontal.LineWeight = new short?(this.interface30_1.imethod_14());
      if ((num & 4) != 0)
        table.BorderBottom.LineWeight = new short?(this.interface30_1.imethod_14());
      if ((num & 8) != 0)
        table.BorderTop.LineWeight = new short?(this.interface30_1.imethod_14());
      if ((num & 16) != 0)
        table.BorderLeft.LineWeight = new short?(this.interface30_1.imethod_14());
      if ((num & 32) == 0)
        return;
      table.BorderRight.LineWeight = new short?(this.interface30_1.imethod_14());
    }

    private void method_194(Class551 table, Class1049 tableBuilder)
    {
      if (!this.interface30_1.imethod_6())
        return;
      int num = this.interface30_1.imethod_11();
      if ((num & 1) != 0)
        table.BorderTop.Visible = new bool?(this.interface30_1.imethod_14() == (short) 0);
      if ((num & 2) != 0)
        table.BorderInsideHorizontal.Visible = new bool?(this.interface30_1.imethod_14() == (short) 0);
      if ((num & 4) != 0)
        table.BorderBottom.Visible = new bool?(this.interface30_1.imethod_14() == (short) 0);
      if ((num & 8) != 0)
        table.BorderTop.Visible = new bool?(this.interface30_1.imethod_14() == (short) 0);
      if ((num & 16) != 0)
        table.BorderLeft.Visible = new bool?(this.interface30_1.imethod_14() == (short) 0);
      if ((num & 32) == 0)
        return;
      table.BorderRight.Visible = new bool?(this.interface30_1.imethod_14() == (short) 0);
    }

    private void method_195(Class1049 tableBuilder, Class1026 cell)
    {
      Class330 class330 = new Class330(cell);
      tableBuilder.method_3((Interface10) class330);
      cell.CellType = (Enum47) this.interface30_1.imethod_14();
      class330.EdgeFlags = (short) this.interface30_1.imethod_18();
      this.interface30_1.imethod_6();
      cell.AutoFit = this.interface30_1.imethod_6();
      cell.MergedCellCountHorizontal = this.interface30_1.imethod_11();
      cell.MergedCellCountVertical = this.interface30_1.imethod_11();
      cell.Rotation = this.interface30_1.imethod_8();
      if (cell.CellType == Enum47.const_1)
      {
        class330.BlockOrFieldHandle = this.method_100();
        if (class330.BlockOrFieldHandle == 0UL && this.class374_0.Version < DxfVersion.Dxf21)
        {
          cell.Value.method_0(DxfValueFormat.NoneInstance);
          cell.Value.method_2(this.interface30_1.ReadString());
        }
      }
      else if (cell.CellType == Enum47.const_2)
      {
        class330.BlockOrFieldHandle = this.method_100();
        cell.BlockScale = this.interface30_1.imethod_8();
        if (this.interface30_1.imethod_6())
        {
          int num1 = (int) this.interface30_1.imethod_14();
          for (int index = 0; index < num1; ++index)
          {
            DxfTableAttribute attribute = new DxfTableAttribute();
            Class331 attributeBuilder = new Class331(attribute);
            class330.method_0(attributeBuilder);
            attributeBuilder.AttributeDefinitionHandle = this.method_100();
            int num2 = (int) this.interface30_1.imethod_14();
            attribute.Value = this.interface30_1.ReadString();
            cell.Attributes.Add(attribute);
          }
        }
      }
      if (this.interface30_1.imethod_6())
      {
        int overrideFlags = this.interface30_1.imethod_11();
        class330.VirtualEdgeFlags = (short) this.interface30_1.imethod_18();
        if ((overrideFlags & 1) != 0)
          cell.CellAlignment = new CellAlignment?((CellAlignment) this.interface30_1.imethod_14());
        if ((overrideFlags & 2) != 0)
          cell.IsBackColorEnabled = new bool?(this.interface30_1.imethod_6());
        if ((overrideFlags & 4) != 0)
          cell.BackColor = new Color?(this.interface30_1.imethod_24());
        if ((overrideFlags & 8) != 0)
          cell.ContentColor = new Color?(this.interface30_1.imethod_24());
        if ((overrideFlags & 16) != 0)
          class330.TextStyleHandle = this.method_100();
        if ((overrideFlags & 32) != 0)
          cell.TextHeight = new double?(this.interface30_1.imethod_8());
        if (class330.VirtualEdgeFlags != (short) 0 || overrideFlags != 0)
        {
          int num = Class1026.smethod_0(overrideFlags, class330.EdgeFlags, class330.VirtualEdgeFlags);
          if ((num & 17472) != 0)
            this.method_196(overrideFlags >> 6, cell.BorderTop);
          if ((num & 34944) != 0)
            this.method_196(overrideFlags >> 7, cell.BorderRight);
          if ((num & 69888) != 0)
            this.method_196(overrideFlags >> 8, cell.BorderBottom);
          if ((num & 139776) != 0)
            this.method_196(overrideFlags >> 9, cell.BorderLeft);
        }
      }
      if (!this.class374_0.IsVersion21OrLater)
        return;
      cell.ExtendedFlags = this.interface30_1.imethod_11();
      tableBuilder.method_3((Interface10) this.method_241(cell.Value));
    }

    private void method_196(int overrideFlags, DxfTableBorderOverrides borderOverrides)
    {
      if ((overrideFlags & 1) != 0)
        borderOverrides.Color = new Color?(this.interface30_1.imethod_24());
      if ((overrideFlags & 16) != 0)
        borderOverrides.LineWeight = new short?(this.interface30_1.imethod_14());
      if ((overrideFlags & 256) == 0)
        return;
      borderOverrides.Visible = new bool?(this.interface30_1.imethod_14() != (short) 0);
    }

    private void method_197()
    {
      DxfHatch hatch = new DxfHatch();
      Class298 class298 = new Class298(hatch);
      this.class374_0.ObjectBuilders.Add((Class259) class298);
      this.method_90((Class285) class298);
      if (this.class374_0.IsVersion18OrLater)
      {
        DxfColorGradient dxfColorGradient = new DxfColorGradient();
        hatch.ColorGradient = dxfColorGradient;
        dxfColorGradient.Enabled = this.interface30_2.imethod_11() != 0;
        dxfColorGradient.Reserved1 = this.interface30_2.imethod_11();
        dxfColorGradient.Angle = this.interface30_2.imethod_8();
        dxfColorGradient.Shift = this.interface30_2.imethod_8();
        dxfColorGradient.IsSingleColorGradient = this.interface30_2.imethod_11() != 0;
        dxfColorGradient.ColorTint = this.interface30_2.imethod_8();
        int num = this.interface30_2.imethod_11();
        for (int index = 0; index < num; ++index)
          dxfColorGradient.GradientColors.Add(new DxfGradientColor()
          {
            Value = this.interface30_2.imethod_8(),
            Color = this.interface30_1.imethod_22()
          });
        dxfColorGradient.Name = this.interface30_3.ReadString();
      }
      double z = this.interface30_2.imethod_8();
      hatch.ElevationPoint = new WW.Math.Point3D(0.0, 0.0, z);
      hatch.ZAxis = this.interface30_2.imethod_51();
      hatch.Name = this.interface30_3.ReadString();
      bool flag1 = this.interface30_2.imethod_6();
      hatch.Associative = this.interface30_2.imethod_6();
      int num1 = this.interface30_2.imethod_11();
      bool flag2 = false;
      List<Class659> class659List = new List<Class659>();
      int num2 = 0;
      for (int index = 0; index < num1; ++index)
      {
        DxfHatch.BoundaryPath boundaryPath = new DxfHatch.BoundaryPath();
        hatch.BoundaryPaths.Add(boundaryPath);
        boundaryPath.Read(this);
        if ((boundaryPath.Type & BoundaryPathType.Derived) != BoundaryPathType.None)
          flag2 = true;
        Class659 class659 = new Class659(boundaryPath);
        class659.BoundaryObjectHandleCount = this.interface30_2.imethod_11();
        num2 += class659.BoundaryObjectHandleCount;
        class659List.Add(class659);
        class298.BoundaryPathBuilders.Add(class659);
      }
      hatch.HatchStyle = (HatchStyle) this.interface30_2.imethod_14();
      hatch.HatchPatternType = (HatchPatternType) this.interface30_2.imethod_14();
      if (!flag1)
      {
        hatch.HatchPatternAngle = this.interface30_2.imethod_8();
        hatch.Scale = this.interface30_2.imethod_8();
        hatch.IsDouble = this.interface30_2.imethod_6();
        hatch.method_13();
        hatch.Pattern.Read(this.interface30_2);
      }
      if (flag2)
        hatch.PixelSize = this.interface30_2.imethod_8();
      int num3 = this.interface30_2.imethod_11();
      for (int index = 0; index < num3; ++index)
      {
        WW.Math.Point2D point2D = this.interface30_2.imethod_38();
        hatch.SeedPoints.Add(point2D);
      }
      Class659 class659_1 = (Class659) null;
      int num4 = 0;
      for (int index1 = 0; index1 < num2; ++index1)
      {
        if (class659_1 == null || class659_1.RemainingBoundaryObjectHandleCount <= 0)
        {
          for (int index2 = num4; index2 < class659List.Count; ++index2)
          {
            class659_1 = class659List[index2];
            if (class659_1.BoundaryObjectHandleCount > 0)
            {
              num4 = index2 + 1;
              break;
            }
          }
        }
        class659_1.method_0(this.method_100());
      }
    }

    private void method_198()
    {
      DxfImage dxfImage = new DxfImage();
      Class292 class292 = new Class292((DxfRasterImage) dxfImage);
      this.class374_0.ObjectBuilders.Add((Class259) class292);
      this.method_90((Class285) class292);
      dxfImage.ClassVersion = this.interface30_2.imethod_11();
      dxfImage.InsertionPoint = this.interface30_2.imethod_39();
      dxfImage.XAxis = this.interface30_2.imethod_51();
      dxfImage.YAxis = this.interface30_2.imethod_51();
      dxfImage.Size = new Size2D(this.interface30_2.imethod_42(), this.interface30_2.imethod_42());
      dxfImage.ImageDisplayFlags = (ImageDisplayFlags) this.interface30_2.imethod_14();
      dxfImage.ClippingEnabled = this.interface30_2.imethod_6();
      dxfImage.Brightness = this.interface30_2.imethod_18();
      dxfImage.Contrast = this.interface30_2.imethod_18();
      dxfImage.Fade = this.interface30_2.imethod_18();
      if (this.class374_0.Version > DxfVersion.Dxf21)
        dxfImage.ClipMode = this.interface30_2.imethod_6() ? ClipMode.Inside : ClipMode.Outside;
      if (this.interface30_2.imethod_14() == (short) 1)
      {
        dxfImage.BoundaryVertices.Add(this.interface30_2.imethod_38());
        dxfImage.BoundaryVertices.Add(this.interface30_2.imethod_38());
      }
      else
      {
        int num = this.interface30_2.imethod_11();
        for (int index = 0; index < num; ++index)
          dxfImage.BoundaryVertices.Add(this.interface30_2.imethod_38());
      }
      class292.ImageDefHandle = this.method_100();
      long num1 = (long) this.method_100();
    }

    private void method_199()
    {
      DxfWipeout dxfWipeout = new DxfWipeout();
      Class292 class292 = new Class292((DxfRasterImage) dxfWipeout);
      this.class374_0.ObjectBuilders.Add((Class259) class292);
      this.method_90((Class285) class292);
      dxfWipeout.ClassVersion = this.interface30_2.imethod_11();
      dxfWipeout.InsertionPoint = this.interface30_2.imethod_39();
      dxfWipeout.XAxis = this.interface30_2.imethod_51();
      dxfWipeout.YAxis = this.interface30_2.imethod_51();
      dxfWipeout.Size = new Size2D(this.interface30_2.imethod_42(), this.interface30_2.imethod_42());
      dxfWipeout.ImageDisplayFlags = (ImageDisplayFlags) this.interface30_2.imethod_14();
      dxfWipeout.ClippingEnabled = this.interface30_2.imethod_6();
      dxfWipeout.Brightness = this.interface30_2.imethod_18();
      dxfWipeout.Contrast = this.interface30_2.imethod_18();
      dxfWipeout.Fade = this.interface30_2.imethod_18();
      if (this.class374_0.Version > DxfVersion.Dxf21)
        dxfWipeout.ClipMode = this.interface30_2.imethod_6() ? ClipMode.Inside : ClipMode.Outside;
      if (this.interface30_2.imethod_14() == (short) 1)
      {
        dxfWipeout.BoundaryVertices.Add(this.interface30_2.imethod_38());
        dxfWipeout.BoundaryVertices.Add(this.interface30_2.imethod_38());
      }
      else
      {
        int num = this.interface30_2.imethod_11();
        for (int index = 0; index < num; ++index)
          dxfWipeout.BoundaryVertices.Add(this.interface30_2.imethod_38());
      }
      class292.ImageDefHandle = this.method_100();
      long num1 = (long) this.method_100();
    }

    private void method_200()
    {
      DxfDictionary dictionary = new DxfDictionary();
      Class262 objectBuilder = new Class262(dictionary);
      this.class374_0.DictionaryBuilders.Add(objectBuilder);
      int itemCount;
      Class332[] entryBuilders;
      this.method_201(this.class374_0.Version, dictionary, objectBuilder, out itemCount, out entryBuilders);
      this.method_202(this.class374_0.Version, dictionary, objectBuilder, itemCount, entryBuilders);
    }

    private void method_201(
      DxfVersion effectiveVersion,
      DxfDictionary dictionary,
      Class262 objectBuilder,
      out int itemCount,
      out Class332[] entryBuilders)
    {
      this.method_94((Class259) objectBuilder);
      itemCount = this.interface30_2.imethod_11();
      if (effectiveVersion == DxfVersion.Dxf14)
      {
        int num1 = (int) this.interface30_2.imethod_18();
      }
      if (effectiveVersion >= DxfVersion.Dxf15)
      {
        dictionary.DuplicateRecordCloning = (DuplicateRecordCloning) this.interface30_2.imethod_14();
        byte num2 = this.interface30_2.imethod_18();
        dictionary.HardOwner = num2 != (byte) 0;
      }
      entryBuilders = new Class332[itemCount];
      for (int index = 0; index < itemCount; ++index)
      {
        DxfDictionaryEntry dictionaryEntry = new DxfDictionaryEntry();
        dictionaryEntry.Name = this.interface30_3.ReadString();
        Class332 class332 = new Class332(dictionary, dictionaryEntry);
        entryBuilders[index] = class332;
        dictionary.Entries.Add((IDictionaryEntry) dictionaryEntry);
      }
    }

    private void method_202(
      DxfVersion effectiveVersion,
      DxfDictionary dictionary,
      Class262 objectBuilder,
      int itemCount,
      Class332[] entryBuilders)
    {
      for (int index = 0; index < itemCount; ++index)
      {
        Class332 entryBuilder = entryBuilders[index];
        entryBuilder.ItemHandle = this.method_100();
        this.class374_0.DictionaryEntryBuilders.Add(entryBuilder);
      }
    }

    private void method_203()
    {
      DxfDictionaryWithDefault dictionary = new DxfDictionaryWithDefault();
      Class263 class263 = new Class263(dictionary);
      this.class374_0.DictionaryBuilders.Add((Class262) class263);
      DxfVersion effectiveVersion = this.class374_0.Version < DxfVersion.Dxf15 ? DxfVersion.Dxf15 : this.class374_0.Version;
      int itemCount;
      Class332[] entryBuilders;
      this.method_201(effectiveVersion, (DxfDictionary) dictionary, (Class262) class263, out itemCount, out entryBuilders);
      this.method_202(effectiveVersion, (DxfDictionary) dictionary, (Class262) class263, itemCount, entryBuilders);
      class263.DefaultEntryHandle = this.method_100();
    }

    private void method_204<T>() where T : DxfHandledObject, new()
    {
      DxfHandledObject dxfHandledObject = (DxfHandledObject) new T();
      Class259 objectBuilder = dxfHandledObject.vmethod_9(FileFormat.Dwg);
      try
      {
        dxfHandledObject.method_4(this, objectBuilder);
        this.class374_0.ObjectBuilders.Add(objectBuilder);
      }
      catch (DxfException ex)
      {
        this.class374_0.Messages.Add(new DxfMessage(DxfStatus.DxfReadError, Severity.Warning)
        {
          Parameters = {
            {
              "Class",
              (object) dxfHandledObject.GetType().FullName
            }
          }
        });
        if (dxfHandledObject.Reference == null)
          return;
        dxfHandledObject.Reference.Value = (IDxfHandledObject) null;
      }
    }

    private void method_205()
    {
      Class279 class279 = new Class279(new DxfSortEntsTable(), this.class374_0.Messages);
      this.class374_0.ObjectBuilders.Add((Class259) class279);
      this.method_94((Class259) class279);
      int num = this.interface30_1.imethod_11();
      class279.OwnerBlockHandle = this.method_100();
      for (int index = 0; index < num; ++index)
      {
        ulong second = this.interface30_2.imethod_31();
        ulong first = this.method_100();
        class279.EntityHandlePairs.Add(new Pair<ulong>(first, second));
      }
    }

    private void method_206()
    {
      DxfSpatialFilter dxfSpatialFilter = new DxfSpatialFilter();
      Class260 objectBuilder = new Class260((DxfObject) dxfSpatialFilter);
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_208((DxfFilter) dxfSpatialFilter, objectBuilder);
      int num = (int) this.interface30_1.imethod_14();
      for (int index = 0; index < num; ++index)
        dxfSpatialFilter.ClipBoundaryPoints.Add(this.interface30_1.imethod_38());
      dxfSpatialFilter.ClipBoundaryPlaneNormal = this.interface30_1.imethod_51();
      dxfSpatialFilter.ClipBoundaryPlaneOrigin = this.interface30_1.imethod_39();
      dxfSpatialFilter.ClipBoundaryDisplayEnabled = this.interface30_1.imethod_14() != (short) 0;
      if (this.interface30_1.imethod_14() != (short) 0)
        dxfSpatialFilter.FrontClippingPlaneDistance = new double?(this.interface30_1.imethod_8());
      if (this.interface30_1.imethod_14() != (short) 0)
        dxfSpatialFilter.BackClippingPlaneDistance = new double?(this.interface30_1.imethod_8());
      dxfSpatialFilter.InverseInsertionTransform = this.method_207();
      dxfSpatialFilter.ClipBoundaryTransform = this.method_207();
    }

    private Matrix4D method_207()
    {
      Matrix4D identity = Matrix4D.Identity;
      for (int index1 = 0; index1 < 3; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
          identity[index1, index2] = this.interface30_1.imethod_8();
      }
      return identity;
    }

    private void method_208(DxfFilter filter, Class260 objectBuilder)
    {
      this.method_94((Class259) objectBuilder);
    }

    private void method_209()
    {
      DxfField field = new DxfField();
      Class283 class283 = new Class283(field);
      this.class374_0.ObjectBuilders.Add((Class259) class283);
      this.method_94((Class259) class283);
      field.EvaluatorId = this.interface30_1.ReadString();
      field.FieldCode = this.interface30_1.ReadString();
      int num1 = this.interface30_1.imethod_11();
      for (int index = 0; index < num1; ++index)
      {
        ulong handle = this.method_100();
        class283.method_1(handle);
      }
      int num2 = this.interface30_1.imethod_11();
      for (int index = 0; index < num2; ++index)
      {
        ulong handle = this.method_100();
        class283.method_2(handle);
      }
      if (this.class374_0.Version < DxfVersion.Dxf21)
        field.FormatString = this.interface30_1.ReadString();
      field.EvalutationOptionFlags = (FieldEvaluationOptionFlags) this.interface30_1.imethod_11();
      field.FilingOptionFlags = (FilingOptionFlags) this.interface30_1.imethod_11();
      field.FieldStateFlags = (FieldStateFlags) this.interface30_1.imethod_11();
      field.EvaluationStatusFlags = (EvaluationStatusFlags) this.interface30_1.imethod_11();
      field.EvaluationErrorCode = this.interface30_1.imethod_11();
      field.EvaluationErrorMessage = this.interface30_1.ReadString();
      class283.ChildBuilders.Add((Interface10) this.method_241(field.Value));
      field.Key = "ACFD_FIELD_VALUE";
      field.ValueString = this.interface30_1.ReadString();
      this.interface30_1.imethod_11();
      int num3 = this.interface30_1.imethod_11();
      for (int index = 0; index < num3; ++index)
      {
        string key = this.interface30_1.ReadString();
        DxfValue dxfValue = new DxfValue();
        class283.ChildBuilders.Add((Interface10) this.method_241(dxfValue));
        field.Values.Add(key, dxfValue);
      }
    }

    private void method_210()
    {
      DxfFieldList dxfFieldList = new DxfFieldList();
      Class282 class282 = new Class282(dxfFieldList);
      this.class374_0.ObjectBuilders.Add((Class259) class282);
      this.method_94((Class259) class282);
      int num = this.interface30_1.imethod_11();
      dxfFieldList.Unknown1 = this.interface30_1.imethod_6();
      for (int index = 0; index < num; ++index)
        class282.FieldHandles.Add(this.method_100());
    }

    private void method_211()
    {
      DxfIdBuffer dxfIdBuffer = new DxfIdBuffer();
      Class261 class261 = new Class261(dxfIdBuffer);
      this.class374_0.ObjectBuilders.Add((Class259) class261);
      this.method_94((Class259) class261);
      dxfIdBuffer.Unknown1 = this.interface30_1.imethod_18();
      int num = this.interface30_1.imethod_11();
      for (int index = 0; index < num; ++index)
        class261.Handles.Add(this.method_100());
    }

    private void method_212()
    {
      Class260 class260 = new Class260((DxfObject) new DxfPlaceHolder());
      this.class374_0.ObjectBuilders.Add((Class259) class260);
      this.method_94((Class259) class260);
    }

    private void method_213()
    {
      DxfTableStyle tableStyle = new DxfTableStyle((string) null, this.class374_0.Version < DxfVersion.Dxf24);
      Class280 tableStyleBuilder = new Class280(tableStyle);
      this.class374_0.ObjectBuilders.Add((Class259) tableStyleBuilder);
      this.method_94((Class259) tableStyleBuilder);
      if (this.class374_0.Version < DxfVersion.Dxf24)
      {
        tableStyle.Description = this.interface30_1.ReadString();
        tableStyle.FlowDirection = (TableFlowDirection) this.interface30_1.imethod_14();
        tableStyle.Flags = (ushort) this.interface30_1.imethod_14();
        tableStyle.HorizontalCellMargin = this.interface30_1.imethod_8();
        tableStyle.VerticalCellMargin = this.interface30_1.imethod_8();
        tableStyle.SuppressTitle = this.interface30_1.imethod_6();
        tableStyle.SuppressHeaderRow = this.interface30_1.imethod_6();
        this.method_214(tableStyleBuilder, tableStyle.DataCellStyle);
        this.method_214(tableStyleBuilder, tableStyle.TitleCellStyle);
        this.method_214(tableStyleBuilder, tableStyle.HeaderCellStyle);
      }
      else
      {
        tableStyle.Unknown1 = this.interface30_1.imethod_18();
        tableStyle.Description = this.interface30_1.ReadString();
        tableStyle.Unknown2 = this.interface30_1.imethod_11();
        tableStyle.Unknown3 = this.interface30_1.imethod_11();
        long num1 = (long) this.method_100();
        Class567 cellStyleBuilder1 = new Class567(tableStyle.TableCellStyle);
        tableStyleBuilder.method_2(cellStyleBuilder1);
        this.method_247(cellStyleBuilder1, tableStyle.TableCellStyle);
        tableStyle.TableCellStyle.Id = this.interface30_1.imethod_11();
        tableStyle.TableCellStyle.CellType = (CellType) this.interface30_1.imethod_11();
        tableStyle.TableCellStyle.Name = this.interface30_1.ReadString();
        int num2 = this.interface30_1.imethod_11();
        for (int index = 0; index < num2; ++index)
        {
          this.interface30_1.imethod_11();
          DxfTableCellStyle cellStyle = new DxfTableCellStyle();
          Class567 cellStyleBuilder2 = new Class567(cellStyle);
          tableStyleBuilder.method_2(cellStyleBuilder2);
          this.method_247(cellStyleBuilder2, cellStyle);
          cellStyle.Id = this.interface30_1.imethod_11();
          cellStyle.CellType = (CellType) this.interface30_1.imethod_11();
          cellStyle.Name = this.interface30_1.ReadString();
          tableStyle.CellStyles.Add(cellStyle);
        }
      }
    }

    private void method_214(Class280 tableStyleBuilder, DxfTableCellStyle cellStyle)
    {
      Class567 cellStyleBuilder = new Class567(cellStyle);
      tableStyleBuilder.method_2(cellStyleBuilder);
      cellStyleBuilder.TextStyleHandle = this.method_100();
      cellStyle.method_1(this.interface30_1.imethod_8());
      cellStyle.method_2((CellAlignment) this.interface30_1.imethod_14());
      cellStyle.method_3(this.interface30_1.imethod_24());
      cellStyle.method_10(this.interface30_1.imethod_24());
      cellStyle.IsBackColorEnabled = this.interface30_1.imethod_6();
      this.method_215(cellStyle.BorderTop);
      this.method_215(cellStyle.BorderInsideHorizontal);
      this.method_215(cellStyle.BorderBottom);
      this.method_215(cellStyle.BorderLeft);
      this.method_215(cellStyle.BorderInsideVertical);
      this.method_215(cellStyle.BorderRight);
      if (this.class374_0.Version <= DxfVersion.Dxf18)
        return;
      cellStyleBuilder.DataType = (ValueDataType) this.interface30_1.imethod_11();
      cellStyleBuilder.DataUnitType = (ValueUnitType) this.interface30_1.imethod_11();
      cellStyleBuilder.FormatString = this.interface30_1.ReadString();
    }

    private void method_215(DxfTableBorder tableBorder)
    {
      tableBorder.SetLineWeight(this.interface30_1.imethod_14());
      tableBorder.method_2(this.interface30_1.imethod_6());
      tableBorder.SetColor(this.interface30_1.imethod_24());
    }

    private void method_216()
    {
      DxfGroup group = new DxfGroup();
      Class281 class281 = new Class281(group);
      this.class374_0.ObjectBuilders.Add((Class259) class281);
      this.method_94((Class259) class281);
      group.Description = this.interface30_3.ReadString();
      int num1 = (int) this.interface30_2.imethod_14();
      group.Selectable = this.interface30_2.imethod_14() > (short) 0;
      int num2 = this.interface30_2.imethod_11();
      for (int index = 0; index < num2; ++index)
        class281.MemberHandles.Add(this.method_100());
    }

    private void method_217()
    {
      DxfMLineStyle mlineStyle = new DxfMLineStyle();
      Class314 class314 = new Class314(mlineStyle);
      this.class374_0.ObjectBuilders.Add((Class259) class314);
      this.method_94((Class259) class314);
      mlineStyle.Name = this.interface30_3.ReadString();
      mlineStyle.Description = this.interface30_3.ReadString();
      short num1 = this.interface30_2.imethod_14();
      mlineStyle.DisplayMiters = ((int) num1 & 1) != 0;
      mlineStyle.IsFillOn = ((int) num1 & 2) != 0;
      mlineStyle.StartHasSquareEndCap = ((int) num1 & 16) != 0;
      mlineStyle.StartHasRoundCap = ((int) num1 & 32) != 0;
      mlineStyle.StartHasInnerArcsCap = ((int) num1 & 64) != 0;
      mlineStyle.EndHasSquareCap = ((int) num1 & 256) != 0;
      mlineStyle.EndHasRoundCap = ((int) num1 & 512) != 0;
      mlineStyle.EndHasInnerArcs = ((int) num1 & 1024) != 0;
      mlineStyle.FillColor = this.interface30_1.imethod_22();
      mlineStyle.StartAngle = this.interface30_2.imethod_8();
      mlineStyle.EndAngle = this.interface30_2.imethod_8();
      int num2 = (int) this.interface30_2.imethod_18();
      for (int index = 0; index < num2; ++index)
      {
        Class730 class730 = new Class730(this.interface30_2.imethod_8(), this.interface30_1.imethod_22());
        if (this.class374_0.Version > DxfVersion.Dxf27)
          class730.LineTypeHandle = new ulong?(this.method_100());
        else
          class730.LineTypeIndex = new int?((int) this.interface30_2.imethod_14());
        class314.ElementBuilders.Add(class730);
      }
      this.dxfModel_0.MLineStyles.Add(mlineStyle);
    }

    private void method_218()
    {
      DxfDictionaryVariable dictionaryVariable = new DxfDictionaryVariable();
      Class259 objectBuilder = new Class259((DxfHandledObject) dictionaryVariable);
      this.class374_0.ObjectBuilders.Add(objectBuilder);
      this.method_94(objectBuilder);
      int num = (int) this.interface30_2.imethod_18();
      dictionaryVariable.Value = this.interface30_3.ReadString();
    }

    private void method_219()
    {
      DxfImageDef dxfImageDef = new DxfImageDef(this.dxfModel_0);
      Class259 objectBuilder = new Class259((DxfHandledObject) dxfImageDef);
      this.class374_0.ObjectBuilders.Add(objectBuilder);
      this.method_94(objectBuilder);
      dxfImageDef.ClassVersion = this.interface30_2.imethod_11();
      dxfImageDef.Size = new Size2D(this.interface30_2.imethod_42(), this.interface30_2.imethod_42());
      dxfImageDef.Filename = this.interface30_3.ReadString();
      dxfImageDef.ImageIsLoaded = this.interface30_2.imethod_6();
      dxfImageDef.ResolutionUnits = (ResolutionUnits) this.interface30_2.imethod_18();
      dxfImageDef.DefaultPixelSize = new Size2D(this.interface30_2.imethod_42(), this.interface30_2.imethod_42());
      this.dxfModel_0.Images.Add(dxfImageDef);
    }

    private void method_220()
    {
      DxfPlotSettings plotSettings = new DxfPlotSettings();
      Class260 objectBuilder = new Class260((DxfObject) plotSettings);
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_221(objectBuilder, plotSettings);
    }

    private void method_221(Class260 objectBuilder, DxfPlotSettings plotSettings)
    {
      this.method_94((Class259) objectBuilder);
      plotSettings.PageSetupName = this.interface30_3.ReadString();
      plotSettings.PlotConfigurationFile = this.interface30_3.ReadString();
      plotSettings.PlotLayoutFlags = (PlotLayoutFlags) this.interface30_2.imethod_14();
      plotSettings.UnprintableMarginLeft = this.interface30_2.imethod_8();
      plotSettings.UnprintableMarginBottom = this.interface30_2.imethod_8();
      plotSettings.UnprintableMarginRight = this.interface30_2.imethod_8();
      plotSettings.UnprintableMarginTop = this.interface30_2.imethod_8();
      plotSettings.PlotPaperSize = new Size2D(this.interface30_2.imethod_8(), this.interface30_2.imethod_8());
      plotSettings.PaperSizeName = this.interface30_3.ReadString();
      plotSettings.PlotOrigin = this.interface30_2.imethod_36();
      plotSettings.PlotPaperUnits = (PlotPaperUnits) this.interface30_2.imethod_14();
      plotSettings.PlotRotation = (PlotRotation) this.interface30_2.imethod_14();
      plotSettings.PlotArea = (PlotArea) this.interface30_2.imethod_14();
      plotSettings.PlotWindowArea = new Rectangle2D(this.interface30_2.imethod_8(), this.interface30_2.imethod_8(), this.interface30_2.imethod_8(), this.interface30_2.imethod_8());
      if (this.class374_0.Version >= DxfVersion.Dxf13 && this.class374_0.Version <= DxfVersion.Dxf15)
        plotSettings.PlotViewName = this.interface30_3.ReadString();
      plotSettings.CustomPrintScaleNumerator = this.interface30_2.imethod_8();
      plotSettings.CustomPrintScaleDenominator = this.interface30_2.imethod_8();
      plotSettings.CurrentStyleSheet = this.interface30_3.ReadString();
      plotSettings.StandardScaleType = this.interface30_2.imethod_14();
      plotSettings.StandardScaleFactor = this.interface30_2.imethod_8();
      plotSettings.PaperImageOrigin = this.interface30_2.imethod_36();
      if (this.class374_0.IsVersion18OrLater)
      {
        plotSettings.ShadePlotMode = (ShadePlotMode) this.interface30_2.imethod_14();
        plotSettings.ShadePlotResolution = (ShadePlotResolution) this.interface30_2.imethod_14();
        plotSettings.ShadePlotCustomDpi = this.interface30_2.imethod_14();
      }
      if (this.class374_0.IsVersion18OrLater)
      {
        long num1 = (long) this.method_100();
      }
      if (!this.class374_0.IsVersion21OrLater)
        return;
      long num2 = (long) this.method_100();
    }

    private void method_222()
    {
      DxfLayout layout = new DxfLayout();
      Class284 class284 = new Class284(layout);
      this.class374_0.ObjectBuilders.Add((Class259) class284);
      this.method_221((Class260) class284, (DxfPlotSettings) layout);
      layout.Name = this.interface30_3.ReadString();
      layout.TabOrder = this.interface30_2.imethod_11();
      layout.Options = (LayoutOptions) this.interface30_2.imethod_14();
      layout.Ucs.Origin = this.interface30_2.imethod_39();
      layout.Limits = new Rectangle2D(this.interface30_2.imethod_38(), this.interface30_2.imethod_38());
      layout.InsertionBasePoint = this.interface30_2.imethod_39();
      layout.Ucs.XAxis = this.interface30_2.imethod_51();
      layout.Ucs.YAxis = this.interface30_2.imethod_51();
      layout.Ucs.Elevation = this.interface30_2.imethod_8();
      layout.UcsOrthographicType = (OrthographicType) this.interface30_2.imethod_14();
      layout.MinExtents = this.interface30_2.imethod_39();
      layout.MaxExtents = this.interface30_2.imethod_39();
      int num = 0;
      if (this.class374_0.IsVersion18OrLater)
        num = this.interface30_2.imethod_11();
      class284.AssociatedBockRecordHandle = this.method_100();
      class284.LastActiveViewportHandle = this.method_100();
      class284.BaseUcsHandle = this.method_100();
      class284.NamedUcsHandle = this.method_100();
      if (this.class374_0.IsVersion18OrLater)
      {
        for (int index = 0; index < num; ++index)
          class284.ViewportHandlesNotNull.Add(this.method_100());
      }
      this.class374_0.Layouts.Add(layout);
    }

    private DxfXRecordValue method_223(bool silence)
    {
      short code = this.interface30_1.imethod_14();
      if (code == (short) -9999)
      {
        if (silence)
          return (DxfXRecordValue) null;
        throw new Exception("ReadXRecordValueBit not implemented");
      }
      object obj;
      switch (code)
      {
        case 1:
          code = (short) 300;
          obj = (object) this.interface30_1.ReadString();
          break;
        case 11:
          obj = (object) this.interface30_1.imethod_39();
          break;
        case 40:
          code = (short) 140;
          obj = (object) this.interface30_1.imethod_8();
          break;
        case 70:
          obj = (object) this.interface30_1.imethod_14();
          break;
        case 90:
          obj = (object) this.interface30_1.imethod_11();
          break;
        case 91:
          throw new Exception("ReadXRecordValueBit reads the handle.");
        default:
          throw new Exception("ReadXRecordValueBit unknown code " + (object) code);
      }
      return new DxfXRecordValue(code, obj);
    }

    private bool method_224(Class278 objectBuilder, DxfXRecord xrecord)
    {
      short code = this.interface30_2.imethod_45();
      object obj = (object) null;
      Enum5 groupValueType;
      if (!Class820.smethod_1((int) code, out groupValueType))
      {
        this.class374_0.Messages.Add(new DxfMessage(DxfStatus.InvalidXRecordGroupCodeEncounteredXRecordDiscarded, Severity.Error, "target", (object) xrecord)
        {
          Parameters = {
            {
              "GroupCode",
              (object) code
            }
          }
        });
        return false;
      }
      switch (groupValueType)
      {
        case Enum5.const_1:
          obj = (object) (this.interface30_2.imethod_18() != (byte) 0);
          break;
        case Enum5.const_2:
          obj = (object) this.interface30_2.imethod_18();
          break;
        case Enum5.const_3:
          obj = (object) this.interface30_2.imethod_19((int) this.interface30_2.imethod_18());
          break;
        case Enum5.const_4:
          obj = (object) this.interface30_2.imethod_42();
          break;
        case Enum5.const_5:
          ulong handle1 = DxfHandledObject.Parse(this.method_226());
          objectBuilder.method_1(xrecord.Values.Count, handle1);
          break;
        case Enum5.const_6:
          obj = (object) this.method_226();
          break;
        case Enum5.const_7:
        case Enum5.const_8:
        case Enum5.const_9:
        case Enum5.const_14:
        case Enum5.const_15:
          ulong handle2 = this.interface30_2.imethod_46();
          objectBuilder.method_1(xrecord.Values.Count, handle2);
          break;
        case Enum5.const_10:
        case Enum5.const_17:
          obj = (object) this.interface30_2.imethod_45();
          break;
        case Enum5.const_11:
          obj = (object) this.interface30_2.imethod_43();
          break;
        case Enum5.const_12:
          obj = (object) (long) this.interface30_2.imethod_46();
          break;
        case Enum5.const_13:
          obj = (object) this.interface30_2.imethod_41();
          break;
        case Enum5.const_16:
          obj = (object) this.method_226();
          break;
        case Enum5.const_18:
          this.class374_0.Messages.Add(new DxfMessage(DxfStatus.InvalidXRecordGroupCodeEncounteredValueDiscarded, Severity.Warning, "target", (object) xrecord)
          {
            Parameters = {
              {
                "GroupCode",
                (object) code
              }
            }
          });
          break;
        default:
          throw new Exception("Unknown group value type " + (object) groupValueType + " for group " + (object) code + ".");
      }
      if (groupValueType != Enum5.const_18)
        xrecord.Values.Add(new DxfXRecordValue(code, obj));
      return true;
    }

    private void method_225()
    {
      DxfXRecord xrecord = new DxfXRecord();
      Class278 objectBuilder = new Class278(xrecord);
      this.method_95((Class259) objectBuilder, false);
      long num1 = this.interface30_2.StreamPosition + (long) this.interface30_2.imethod_11();
      bool flag = true;
      do
        ;
      while (this.interface30_2.StreamPosition < num1 && (flag = this.method_224(objectBuilder, xrecord)));
      if (!flag)
        return;
      this.method_96((Class259) objectBuilder);
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      if (this.class374_0.IsVersion15OrLater)
        xrecord.DuplicateRecordCloningFlag = (DuplicateRecordCloningFlag) this.interface30_2.imethod_14();
      long num2 = this.long_0 + (long) (this.uint_0 * 8U) - 7L;
      while (this.interface30_4.imethod_3() < num2)
      {
        long num3 = (long) this.method_100();
      }
    }

    private string method_226()
    {
      return this.interface30_2.imethod_30();
    }

    private void method_227()
    {
      DxfColor dxfColor = new DxfColor();
      Class260 class260 = new Class260((DxfObject) dxfColor);
      this.class374_0.ObjectBuilders.Add((Class259) class260);
      this.method_94((Class259) class260);
      if (this.class374_0.IsVersion18OrLater)
      {
        this.interface30_2.imethod_6();
        this.interface30_2.imethod_6();
        this.interface30_2.imethod_6();
        this.interface30_2.imethod_6();
        uint data = this.interface30_2.imethod_44();
        byte num = this.interface30_2.imethod_18();
        string name = (string) null;
        string colorBookName = (string) null;
        if (num != (byte) 0)
        {
          name = this.interface30_3.ReadString();
          colorBookName = this.interface30_3.ReadString();
        }
        dxfColor.Color = Color.smethod_1(data, colorBookName, name);
      }
      else
      {
        short colorIndex = this.interface30_2.imethod_14();
        dxfColor.Color = Color.CreateFromColorIndex(colorIndex);
      }
      this.dxfModel_0.Colors.Add(dxfColor);
    }

    private void method_228()
    {
      DxfLinkedData linkedData = new DxfLinkedData();
      Class260 objectBuilder = new Class260((DxfObject) linkedData);
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_94((Class259) objectBuilder);
      this.method_229(objectBuilder, linkedData);
    }

    private void method_229(Class260 objectBuilder, DxfLinkedData linkedData)
    {
      linkedData.Name = this.interface30_1.ReadString();
      linkedData.Description = this.interface30_1.ReadString();
    }

    private void method_230()
    {
      DxfLinkedTableData linkedTableData = new DxfLinkedTableData();
      Class274 objectBuilder = new Class274(linkedTableData);
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_94((Class259) objectBuilder);
      this.method_231(objectBuilder, linkedTableData);
    }

    private void method_231(Class274 objectBuilder, DxfLinkedTableData linkedTableData)
    {
      this.method_229((Class260) objectBuilder, (DxfLinkedData) linkedTableData);
      int num1 = this.interface30_1.imethod_11();
      for (int index1 = 0; index1 < num1; ++index1)
      {
        DxfTableColumn column = new DxfTableColumn();
        Class505 class505 = new Class505(column);
        objectBuilder.ColumnBuilders.Add(class505);
        linkedTableData.method_9(column);
        column.Name = this.interface30_1.ReadString();
        column.CustomData = this.interface30_1.imethod_11();
        int num2 = this.interface30_1.imethod_11();
        for (int index2 = 0; index2 < num2; ++index2)
        {
          DxfTableCustomData data = new DxfTableCustomData();
          this.method_238(objectBuilder, data);
          column.CustomDataCollection.Add(data);
        }
        Class567 cellStyleBuilder = new Class567(column.CellStyleOverrides);
        this.method_247(cellStyleBuilder, column.CellStyleOverrides);
        objectBuilder.PrerequisiteBuilders.Add((Interface10) cellStyleBuilder);
        class505.CellStyleId = this.interface30_1.imethod_11();
        column.Width = this.interface30_1.imethod_8();
      }
      int num3 = this.interface30_1.imethod_11();
      for (int index1 = 0; index1 < num3; ++index1)
      {
        int num2 = this.interface30_1.imethod_11();
        DxfTableRow row = new DxfTableRow();
        Class1050 class1050 = new Class1050(row);
        objectBuilder.RowBuilders.Add(class1050);
        linkedTableData.method_8(row);
        for (int index2 = 0; index2 < num2; ++index2)
        {
          DxfTableCell cell = new DxfTableCell();
          this.method_236(objectBuilder, cell);
          row.Cells.Add(cell);
        }
        row.CustomData = this.interface30_1.imethod_11();
        int num4 = this.interface30_1.imethod_11();
        for (int index2 = 0; index2 < num4; ++index2)
        {
          DxfTableCustomData data = new DxfTableCustomData();
          this.method_238(objectBuilder, data);
          row.CustomDataCollection.Add(data);
        }
        Class567 cellStyleBuilder = new Class567(row.CellStyleOverrides);
        this.method_247(cellStyleBuilder, row.CellStyleOverrides);
        objectBuilder.PrerequisiteBuilders.Add((Interface10) cellStyleBuilder);
        class1050.CellStyleId = this.interface30_1.imethod_11();
        row.Height = this.interface30_1.imethod_8();
      }
      int num5 = this.interface30_1.imethod_11();
      for (int index = 0; index < num5; ++index)
      {
        long num2 = (long) this.interface30_1.imethod_32(false);
      }
    }

    private void method_232()
    {
      DxfFormattedTableData formattedTableData = new DxfFormattedTableData();
      Class274 objectBuilder = new Class274((DxfLinkedTableData) formattedTableData);
      this.class374_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_94((Class259) objectBuilder);
      this.method_233(objectBuilder, formattedTableData);
    }

    private void method_233(Class274 objectBuilder, DxfFormattedTableData formattedTableData)
    {
      this.method_231(objectBuilder, (DxfLinkedTableData) formattedTableData);
      Class567 cellStyleBuilder = new Class567(formattedTableData.CellStyleOverrides);
      this.method_247(cellStyleBuilder, formattedTableData.CellStyleOverrides);
      objectBuilder.PrerequisiteBuilders.Add((Interface10) cellStyleBuilder);
      int num = this.interface30_1.imethod_11();
      for (int index = 0; index < num; ++index)
        formattedTableData.MergedCellRanges.Add(new DxfTableCellRange()
        {
          TopRowIndex = this.interface30_1.imethod_11(),
          LeftColumnIndex = this.interface30_1.imethod_11(),
          BottomRowIndex = this.interface30_1.imethod_11(),
          RightColumnIndex = this.interface30_1.imethod_11()
        });
    }

    private void method_234()
    {
      DxfTableContent tableContent = new DxfTableContent();
      Class275 tableContentBuilder = new Class275(tableContent);
      this.class374_0.ObjectBuilders.Add((Class259) tableContentBuilder);
      this.method_94((Class259) tableContentBuilder);
      this.method_235(tableContentBuilder, tableContent);
    }

    private void method_235(Class275 tableContentBuilder, DxfTableContent tableContent)
    {
      this.method_233((Class274) tableContentBuilder, (DxfFormattedTableData) tableContent);
      tableContentBuilder.TableStyleHandle = this.method_100();
    }

    private void method_236(Class274 tableBuilder, DxfTableCell cell)
    {
      Class506 cellBuilder = new Class506(cell);
      tableBuilder.CellBuilders.Add(cellBuilder);
      cell.StateFlags = (TableCellStateFlags) this.interface30_1.imethod_11();
      cell.ToolTip = this.interface30_1.ReadString();
      cell.CustomData = this.interface30_1.imethod_11();
      int num1 = this.interface30_1.imethod_11();
      for (int index = 0; index < num1; ++index)
      {
        DxfTableCustomData data = new DxfTableCustomData();
        this.method_238(tableBuilder, data);
        cell.CustomDataCollection.Add(data);
      }
      cell.HasLinkDataFlags = this.interface30_1.imethod_11();
      if (cell.HasLinkDataFlags != 0)
      {
        long num2 = (long) this.interface30_1.imethod_32(false);
        this.interface30_1.imethod_11();
        this.interface30_1.imethod_11();
        this.interface30_1.imethod_11();
      }
      int num3 = this.interface30_1.imethod_11();
      for (int index = 0; index < num3; ++index)
      {
        DxfTableCellContent content = new DxfTableCellContent();
        this.method_239(cellBuilder, content);
        cell.Contents.Add(content);
      }
      Class567 cellStyleBuilder = new Class567(cell.CellStyleOverrides);
      this.method_247(cellStyleBuilder, cell.CellStyleOverrides);
      tableBuilder.PrerequisiteBuilders.Add((Interface10) cellStyleBuilder);
      cellBuilder.CellStyleId = this.interface30_1.imethod_11();
      cell.UnknownDxfGroup91A = this.interface30_1.imethod_11();
      if (cell.UnknownDxfGroup91A == 0)
        return;
      cell.UnknownDxfGroup91B = this.interface30_1.imethod_11();
      cell.UnknownDxfGroup40 = this.interface30_1.imethod_8();
      cell.UnknownDxfGroup41 = this.interface30_1.imethod_8();
      cell.GeometryDataFlags = this.interface30_1.imethod_11();
      cellBuilder.UnknownObjectHandle = this.method_100();
      if (cell.GeometryDataFlags == 0)
        return;
      cell.Geometry = new Class550();
      this.method_237(cell.Geometry);
    }

    private void method_237(Class550 cellContentGeometry)
    {
      cellContentGeometry.DistanceToTopLeft = this.interface30_1.imethod_51();
      cellContentGeometry.DistanceToCenter = this.interface30_1.imethod_51();
      cellContentGeometry.ContentWidth = this.interface30_1.imethod_8();
      cellContentGeometry.ContentHeight = this.interface30_1.imethod_8();
      cellContentGeometry.Width = this.interface30_1.imethod_8();
      cellContentGeometry.Height = this.interface30_1.imethod_8();
      cellContentGeometry.UnknownFlags = this.interface30_1.imethod_11();
    }

    private void method_238(Class274 tableBuilder, DxfTableCustomData data)
    {
      data.Name = this.interface30_1.ReadString();
      tableBuilder.ChildBuilders.Add((Interface10) this.method_241(data.Value));
    }

    private void method_239(Class506 cellBuilder, DxfTableCellContent content)
    {
      Class568 class568 = new Class568(content);
      cellBuilder.ChildBuilders.Add((Interface10) class568);
      content.ContentType = (TableCellContentType) this.interface30_1.imethod_11();
      switch (content.ContentType)
      {
        case TableCellContentType.Value:
          cellBuilder.ChildBuilders.Add((Interface10) this.method_241(content.Value));
          break;
        case TableCellContentType.Field:
          long num1 = (long) this.method_100();
          break;
        case TableCellContentType.Block:
          class568.ValueObjectHandle = this.method_100();
          break;
      }
      int num2 = this.interface30_1.imethod_11();
      for (int index = 0; index < num2; ++index)
      {
        DxfTableAttribute attribute = new DxfTableAttribute();
        Class331 attributeBuilder = new Class331(attribute);
        class568.method_0(attributeBuilder);
        attributeBuilder.AttributeDefinitionHandle = this.method_100();
        attribute.Value = this.interface30_1.ReadString();
        this.interface30_1.imethod_11();
      }
      content.Format.DataFlags = this.interface30_1.imethod_14();
      if (!content.Format.HasData)
        return;
      Class566 contentFormatBuilder = new Class566(content.Format);
      cellBuilder.ChildBuilders.Add((Interface10) contentFormatBuilder);
      this.method_240(contentFormatBuilder, content.Format);
    }

    private void method_240(Class566 contentFormatBuilder, DxfContentFormat contentFormat)
    {
      contentFormat.ContentFormatPropertyOverrideFlags = (TableCellStylePropertyFlags) this.interface30_1.imethod_11();
      contentFormat.PropertyFlags = (TableCellStylePropertyFlags) this.interface30_1.imethod_11();
      contentFormatBuilder.DataType = (ValueDataType) this.interface30_1.imethod_11();
      contentFormatBuilder.DataUnitType = (ValueUnitType) this.interface30_1.imethod_11();
      contentFormatBuilder.FormatString = this.interface30_1.ReadString();
      contentFormat.method_5(this.interface30_1.imethod_8());
      contentFormat.method_6(this.interface30_1.imethod_8());
      contentFormat.method_2((CellAlignment) this.interface30_1.imethod_11());
      contentFormat.method_3(this.interface30_1.imethod_24());
      contentFormatBuilder.TextStyleHandle = this.method_100();
      contentFormat.method_1(this.interface30_1.imethod_8());
    }

    private Class999 method_241(DxfValue value)
    {
      Class999 class999 = new Class999(value);
      value.Flags = 0;
      if (this.class374_0.IsVersion21OrLater)
        value.Flags = this.interface30_1.imethod_11();
      ValueDataType dataType = (ValueDataType) this.interface30_1.imethod_11();
      if (!this.class374_0.IsVersion21OrLater || !value.IsEmpty)
      {
        switch (dataType)
        {
          case ValueDataType.None:
            value.SetValue(this.interface30_1.imethod_11());
            break;
          case ValueDataType.Int:
            value.SetValue(this.interface30_1.imethod_11());
            break;
          case ValueDataType.Double:
            value.SetValue(this.interface30_1.imethod_8());
            break;
          case ValueDataType.String:
            value.SetValue(this.method_242());
            break;
          case ValueDataType.Date:
            DateTime? nullable1 = this.method_243();
            if (nullable1.HasValue)
            {
              value.SetValue(nullable1.Value);
              break;
            }
            break;
          case ValueDataType.Point2D:
            WW.Math.Point2D? nullable2 = this.method_244();
            value.SetValue(nullable2.Value);
            break;
          case ValueDataType.Point3D:
            WW.Math.Point3D? nullable3 = this.method_245();
            value.SetValue(nullable3.Value);
            break;
          case ValueDataType.ObjectHandle:
            class999.ObjectHandle = this.method_100();
            break;
          case ValueDataType.General:
            dataType = ValueDataType.String;
            value.SetValue(this.method_242());
            break;
        }
      }
      if (this.class374_0.IsVersion21OrLater)
      {
        ValueUnitType unitType = (ValueUnitType) this.interface30_1.imethod_11();
        value.method_0(DxfValueFormat.Create(dataType, unitType));
        value.Format._FormatString = this.interface30_1.ReadString();
        value.method_2(this.interface30_1.ReadString());
      }
      else
        value.method_0(DxfValueFormat.Create(dataType, ValueUnitType.None));
      return class999;
    }

    private string method_242()
    {
      int num = this.interface30_1.imethod_11();
      byte[] bytes = this.interface30_1.imethod_19(num);
      return this.class374_0.Version <= DxfVersion.Dxf18 ? (num <= 0 ? string.Empty : (bytes[num - 1] != (byte) 0 ? this.interface30_1.Encoding.GetString(bytes, 0, num) : (num - 1 <= 0 ? string.Empty : this.interface30_1.Encoding.GetString(bytes, 0, num - 1)))) : (num / 2 <= 1 ? string.Empty : Encoding.Unicode.GetString(bytes, 0, num - 2));
    }

    private DateTime? method_243()
    {
      int length = this.interface30_1.imethod_11();
      DateTime? nullable;
      if (length > 0)
      {
        byte[] numArray = this.interface30_1.imethod_19(length);
        if (this.class374_0.Version > DxfVersion.Dxf18)
        {
          switch (length)
          {
            case 14:
              nullable = new DateTime?(new DateTime(((int) numArray[1] << 8) + (int) numArray[0], ((int) numArray[3] << 8) + (int) numArray[2], ((int) numArray[5] << 8) + (int) numArray[4], ((int) numArray[7] << 8) + (int) numArray[6], ((int) numArray[9] << 8) + (int) numArray[8], ((int) numArray[11] << 8) + (int) numArray[10], ((int) numArray[13] << 8) + (int) numArray[12]));
              break;
            case 16:
              nullable = new DateTime?(new DateTime(((int) numArray[1] << 8) + (int) numArray[0], ((int) numArray[3] << 8) + (int) numArray[2], ((int) numArray[7] << 8) + (int) numArray[6], ((int) numArray[9] << 8) + (int) numArray[8], ((int) numArray[11] << 8) + (int) numArray[10], ((int) numArray[13] << 8) + (int) numArray[12], ((int) numArray[15] << 8) + (int) numArray[14]));
              break;
            default:
              nullable = new DateTime?(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
              break;
          }
        }
        else
          nullable = new DateTime?(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds((double) (((int) numArray[0] << 24) + ((int) numArray[1] << 16) + ((int) numArray[2] << 8) + (int) numArray[3] + ((int) numArray[4] << 24) + ((int) numArray[5] << 16) + ((int) numArray[6] << 8) + (int) numArray[7])));
      }
      else
        nullable = new DateTime?();
      return nullable;
    }

    private WW.Math.Point2D? method_244()
    {
      WW.Math.Point2D? nullable = new WW.Math.Point2D?();
      int length = this.interface30_1.imethod_11();
      if (length > 0)
      {
        byte[] bytes = this.interface30_1.imethod_19(length);
        nullable = new WW.Math.Point2D?(new WW.Math.Point2D(LittleEndianBitConverter.ToDouble(bytes, 0), LittleEndianBitConverter.ToDouble(bytes, 8)));
      }
      return nullable;
    }

    private WW.Math.Point3D? method_245()
    {
      WW.Math.Point3D? nullable = new WW.Math.Point3D?();
      int length = this.interface30_1.imethod_11();
      if (length > 0)
      {
        byte[] bytes = this.interface30_1.imethod_19(length);
        nullable = new WW.Math.Point3D?(new WW.Math.Point3D(LittleEndianBitConverter.ToDouble(bytes, 0), LittleEndianBitConverter.ToDouble(bytes, 8), LittleEndianBitConverter.ToDouble(bytes, 16)));
      }
      return nullable;
    }

    private void method_246()
    {
      DxfCellStyleMap dxfCellStyleMap = new DxfCellStyleMap();
      Class264 class264 = new Class264(dxfCellStyleMap);
      this.class374_0.ObjectBuilders.Add((Class259) class264);
      this.class374_0.CellStyleMapBuilders.Add(dxfCellStyleMap, class264);
      this.method_94((Class259) class264);
      int num = this.interface30_1.imethod_11();
      for (int index1 = 0; index1 < num; ++index1)
      {
        Class567 cellStyleBuilder = class264.method_1();
        this.method_247(cellStyleBuilder, cellStyleBuilder.CellStyle);
        cellStyleBuilder.CellStyle.Id = this.interface30_1.imethod_11();
        cellStyleBuilder.CellStyle.CellType = (CellType) this.interface30_1.imethod_11();
        cellStyleBuilder.CellStyle.Name = this.interface30_1.ReadString();
        if (dxfCellStyleMap.CellStyles.Contains(cellStyleBuilder.CellStyle.Name))
        {
          for (int index2 = 0; index2 < dxfCellStyleMap.CellStyles.Count; ++index2)
          {
            if (dxfCellStyleMap.CellStyles[index2].Name == cellStyleBuilder.CellStyle.Name)
            {
              dxfCellStyleMap.CellStyles[index2] = cellStyleBuilder.CellStyle;
              break;
            }
          }
        }
        else
          dxfCellStyleMap.CellStyles.Add(cellStyleBuilder.CellStyle);
      }
    }

    private void method_247(Class567 cellStyleBuilder, DxfTableCellStyle cellStyle)
    {
      cellStyle.TableCellStyleType = (Enum22) this.interface30_1.imethod_11();
      cellStyle.DataFlags = this.interface30_1.imethod_14();
      if (!cellStyle.HasData)
        return;
      cellStyle.CellStylePropertyOverrideFlags = (TableCellStylePropertyFlags) this.interface30_1.imethod_11();
      cellStyle.MergeFlags = (TableCellStylePropertyFlags) this.interface30_1.imethod_11();
      cellStyle.method_10(this.interface30_1.imethod_24());
      if (cellStyle.BackColor != Color.None)
        cellStyle.IsBackColorEnabled = true;
      cellStyle.method_20((TableCellContentLayoutFlags) this.interface30_1.imethod_11());
      this.method_240((Class566) cellStyleBuilder, (DxfContentFormat) cellStyle);
      cellStyle.MarginOverrideFlags = this.interface30_1.imethod_14();
      if (cellStyle.HasMarginOverrides)
      {
        cellStyle.method_15(this.interface30_1.imethod_8());
        cellStyle.method_14(this.interface30_1.imethod_8());
        cellStyle.method_16(this.interface30_1.imethod_8());
        cellStyle.method_17(this.interface30_1.imethod_8());
        cellStyle.method_18(this.interface30_1.imethod_8());
        cellStyle.method_19(this.interface30_1.imethod_8());
      }
      int num = this.interface30_1.imethod_11();
      for (int index = 0; index < num; ++index)
      {
        switch (this.interface30_1.imethod_11())
        {
          case 1:
            this.method_248(cellStyleBuilder, cellStyle.BorderTop);
            break;
          case 2:
            this.method_248(cellStyleBuilder, cellStyle.BorderRight);
            break;
          case 4:
            this.method_248(cellStyleBuilder, cellStyle.BorderBottom);
            break;
          case 8:
            this.method_248(cellStyleBuilder, cellStyle.BorderLeft);
            break;
          case 16:
            this.method_248(cellStyleBuilder, cellStyle.BorderInsideVertical);
            break;
          case 32:
            this.method_248(cellStyleBuilder, cellStyle.BorderInsideHorizontal);
            break;
        }
      }
    }

    private void method_248(Class567 cellStyleBuilder, DxfTableBorder border)
    {
      Class1071 class1071 = new Class1071(border);
      cellStyleBuilder.ChildBuilders.Add((Interface10) class1071);
      border.HasData = true;
      border.PropertyOverrideFlags = (TableBorderPropertyFlags) this.interface30_1.imethod_11();
      border.method_1((BorderType) this.interface30_1.imethod_11());
      border.SetColor(this.interface30_1.imethod_24());
      border.SetLineWeight((short) this.interface30_1.imethod_11());
      class1071.LineTypeHandle = this.method_100();
      border.method_2(this.interface30_1.imethod_11() == 0);
      border.method_3(this.interface30_1.imethod_8());
    }
  }
}
