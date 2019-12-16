// Decompiled with JetBrains decompiler
// Type: WW.Cad.IO.DxfWriter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns1;
using ns2;
using ns28;
using ns36;
using ns38;
using ns43;
using ns46;
using ns6;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.InventorDrawing;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Objects.DynamicBlock;
using WW.Cad.Model.Tables;
using WW.Collections.Generic;
using WW.Drawing;
using WW.Math;
using WW.Text;

namespace WW.Cad.IO
{
  public class DxfWriter
  {
    private bool bool_0 = true;
    private readonly Queue<DxfObject> queue_0 = new Queue<DxfObject>();
    private readonly Dictionary<string, UnsupportedObject> dictionary_0 = new Dictionary<string, UnsupportedObject>();
    private readonly DxfMessageCollection dxfMessageCollection_0 = new DxfMessageCollection();
    internal const double double_0 = 57.2957795130823;
    private readonly Interface13 interface13_0;
    private readonly DxfModel dxfModel_0;
    private readonly DxfVersion dxfVersion_0;
    private readonly DxfWriter.Class39 class39_0;
    private DxfBlock dxfBlock_0;
    private bool bool_1;

    private void method_0(DxfEvalGraph evalGraph)
    {
      this.method_21(evalGraph);
    }

    private void method_1(DxfBlockAlignmentParameter dxfObject)
    {
      this.method_48(dxfObject);
    }

    private void method_2(DxfBlockFlipParameter dxfObject)
    {
      this.method_43(dxfObject);
    }

    private void method_3(DxfBlockLinearParameter dxfObject)
    {
      this.method_42(dxfObject);
    }

    private void method_4(DxfBlockPolarParameter dxfObject)
    {
      this.method_37(dxfObject);
    }

    private void method_5(DxfBlockRotationParameter dxfObject)
    {
      this.method_34(dxfObject);
    }

    private void method_6(DxfBlockXYParameter dxfObject)
    {
      this.method_70(dxfObject);
    }

    private void method_7(DxfBlockBasePointParameter dxfObject)
    {
      this.method_46(dxfObject);
    }

    private void method_8(DxfBlockLookUpParameter dxfObject)
    {
      this.method_40(dxfObject);
    }

    private void method_9(DxfBlockVisibilityParameter dxfObject)
    {
      this.method_24(dxfObject);
    }

    private void method_10(DxfBlockPropertiesTable dxfObject)
    {
      this.method_26(dxfObject);
    }

    private void method_11(DxfBlockArrayAction dxfObject)
    {
      this.method_47(dxfObject);
    }

    private void method_12(DxfBlockFlipAction dxfObject)
    {
      this.method_44(dxfObject);
    }

    private void method_13(DxfBlockLookupAction dxfObject)
    {
      this.method_41(dxfObject);
    }

    private void method_14(DxfBlockMoveAction dxfObject)
    {
      this.method_39(dxfObject);
    }

    private void method_15(DxfBlockPolarStretchAction dxfObject)
    {
      this.method_36(dxfObject);
    }

    private void method_16(DxfBlockStretchAction dxfObject)
    {
      this.method_31(dxfObject);
    }

    private void method_17(DxfBlockRotateAction dxfObject)
    {
      this.method_35(dxfObject);
    }

    private void method_18(DxfBlockScaleAction dxfObject)
    {
      this.method_32(dxfObject);
    }

    private void method_19(DxfBlockPointParameter dxfObject)
    {
      this.method_22(dxfObject);
    }

    private void method_20(DxfBlockUserParameter dxfObject)
    {
      this.method_23(dxfObject);
    }

    private void method_21(DxfEvalGraph evalGraph)
    {
      this.method_203((DxfObject) evalGraph);
      this.Write(100, (object) "AcDbEvalGraph");
      this.Write(96, (object) evalGraph.LastNodeId.Id);
      this.Write(97, (object) evalGraph.LastNodeId.Id);
      int num1 = Class740.smethod_12(evalGraph.Nodes);
      for (int index = 0; index < num1; ++index)
      {
        this.Write(91, (object) index);
        this.Write(93, (object) 32);
        this.Write(95, (object) evalGraph.Nodes[index].Id.Id);
        this.Write(360, (object) evalGraph.Nodes[index].Expression.Handle);
        this.Write(92, (object) evalGraph.Nodes[index].FirstIncomingEdge);
        this.Write(92, (object) evalGraph.Nodes[index].LastIncomingEdge);
        this.Write(92, (object) evalGraph.Nodes[index].FirstOutgoingEdge);
        this.Write(92, (object) evalGraph.Nodes[index].LastOutgoingEdge);
      }
      int num2 = Class740.smethod_13(evalGraph.Edges);
      for (int index = 0; index < num2; ++index)
      {
        this.Write(92, (object) index);
        this.Write(93, (object) evalGraph.Edges[index].Flags);
        this.Write(94, (object) evalGraph.Edges[index].ReferenceCount);
        this.Write(91, (object) evalGraph.Edges[index].StartNode);
        this.Write(91, (object) evalGraph.Edges[index].EndNode);
        this.Write(92, (object) evalGraph.Edges[index].PreviousIncoming);
        this.Write(92, (object) evalGraph.Edges[index].NextIncoming);
        this.Write(92, (object) evalGraph.Edges[index].PreviousOutgoing);
        this.Write(92, (object) evalGraph.Edges[index].NextOutgoing);
        this.Write(92, (object) evalGraph.Edges[index].ReverseEdgeIndex);
      }
    }

    private void method_22(DxfBlockPointParameter blockPointParameter)
    {
      this.method_55((DxfBlockSinglePointParameter) blockPointParameter);
      this.Write(100, (object) "AcDbBlockPointParameter");
      this.Write(303, (object) blockPointParameter.LabelText);
      this.Write(304, (object) blockPointParameter.Description);
      this.Write(1011, blockPointParameter.LabelPosition);
    }

    private void method_23(DxfBlockUserParameter blockUserParameter)
    {
      this.method_55((DxfBlockSinglePointParameter) blockUserParameter);
      this.Write(100, (object) "AcDbBlockUserParameter");
      this.Write(90, (object) blockUserParameter.UnknownInt16);
      this.Write(330, (object) blockUserParameter.Variable);
      this.Write(301, (object) blockUserParameter.UnknownString);
      this.Write(309, (object) "AcDbEvalVariant NULL = -9999");
      this.Write(170, (object) blockUserParameter.ValueType);
    }

    private void method_24(DxfBlockVisibilityParameter dxfObject)
    {
      this.method_55((DxfBlockSinglePointParameter) dxfObject);
      this.Write(100, (object) "AcDbBlockVisibilityParameter");
      this.Write(281, (object) (byte) (dxfObject.UnknownFlag ? 1 : 0));
      this.Write(301, (object) dxfObject.LabelText);
      this.Write(302, (object) dxfObject.Description);
      this.Write(91, (object) (dxfObject.UnknownFlag2 ? 1 : 0));
      int num1 = Class740.smethod_3((IList<DxfHandledObject>) dxfObject.HandleSet);
      this.Write(93, (object) num1);
      for (int index = 0; index < num1; ++index)
        this.Write(331, (object) dxfObject.HandleSet[index].Handle);
      int num2 = Class740.smethod_11(dxfObject.VisibilityStates);
      this.Write(92, (object) num2);
      for (int index1 = 0; index1 < num2; ++index1)
      {
        this.Write(303, (object) dxfObject.VisibilityStates[index1].Name);
        int num3 = Class740.smethod_3((IList<DxfHandledObject>) dxfObject.VisibilityStates[index1].SelectionSet1);
        this.Write(94, (object) num3);
        for (int index2 = 0; index2 < num3; ++index2)
          this.Write(332, (object) dxfObject.VisibilityStates[index1].SelectionSet1[index2].Handle);
        int num4 = Class740.smethod_3((IList<DxfHandledObject>) dxfObject.VisibilityStates[index1].SelectionSet2);
        this.Write(95, (object) num4);
        for (int index2 = 0; index2 < num4; ++index2)
          this.Write(333, (object) dxfObject.VisibilityStates[index1].SelectionSet2[index2].Handle);
      }
    }

    private void method_25(DxfBlockPropertiesTableColumnDefinition columnInfo)
    {
      this.method_218(340, (DxfHandledObject) columnInfo.Parameter);
      this.Write(170, (object) columnInfo.UnknownInt1);
      this.Write(171, (object) columnInfo.UnknownInt2);
      this.Write(300, (object) columnInfo.UnknownString1);
      this.Write(301, (object) columnInfo.ConnectionPoint.ConnectionString);
      this.Write(90, (object) columnInfo.ConnectionPoint.ConnectionPointId.Id);
      this.method_53(columnInfo.UnknownValue1, true);
      this.method_53(columnInfo.DefaultDoNotMatchValue, true);
      this.Write(290, (object) columnInfo.UnknownFlag1);
      this.Write(291, (object) columnInfo.UnknownFlag2);
      this.Write(292, (object) columnInfo.UnknownFlag3);
      this.Write(293, (object) columnInfo.UnknownFlag4);
      this.Write(294, (object) columnInfo.UnknownFlag5);
      this.Write(302, (object) columnInfo.UnknownString2);
      this.method_218(340, (DxfHandledObject) columnInfo.UnknownObject1);
    }

    private void method_26(DxfBlockPropertiesTable dxfObject)
    {
      this.method_55((DxfBlockSinglePointParameter) dxfObject);
      this.Write(100, (object) "AcDbBlockPropertiesTable");
      this.Write(90, (object) dxfObject.NodeId.Id);
      this.Write(300, (object) dxfObject.TableName);
      this.Write(301, (object) dxfObject.DescriptionString);
      int length = dxfObject.ColumnInformation.Length;
      this.Write(91, (object) length);
      foreach (DxfBlockPropertiesTableColumnDefinition columnInfo in dxfObject.ColumnInformation)
        this.method_25(columnInfo);
      int num = dxfObject.DataNodeId == null ? 0 : dxfObject.DataNodeId.Length;
      this.Write(92, (object) num);
      for (int index1 = 0; index1 < num; ++index1)
      {
        this.Write(90, (object) dxfObject.DataNodeId[index1]);
        for (int index2 = 0; index2 < length; ++index2)
          this.method_53(dxfObject.Data[index2][index1], true);
      }
      this.Write(93, (object) dxfObject.Unknown1);
      this.Write(290, (object) dxfObject.PropertiesCanBeModifiedIndividually);
      this.Write(291, (object) dxfObject.UnknownFlag2);
      this.Write(292, (object) dxfObject.UnknownFlag3);
    }

    private void method_27(DxfConnectionPoint[] connections, int idGroupCode, int stringGroupCode)
    {
      this.method_28(connections, idGroupCode, stringGroupCode, false);
    }

    private void method_28(
      DxfConnectionPoint[] connections,
      int idGroupCode,
      int stringGroupCode,
      bool sequential)
    {
      int num = Class740.smethod_0(connections);
      if (sequential)
      {
        for (int index = 0; index < num; ++index)
        {
          this.Write(idGroupCode + index, (object) connections[index].ConnectionPointId.Id);
          this.Write(stringGroupCode + index, (object) connections[index].ConnectionString);
        }
      }
      else
      {
        for (int index = 0; index < num; ++index)
          this.Write(idGroupCode + index, (object) connections[index].ConnectionPointId.Id);
        for (int index = 0; index < num; ++index)
          this.Write(stringGroupCode + index, (object) connections[index].ConnectionString);
      }
    }

    private void method_29(DxfConnectionPoint connections, int idGroupCode, int stringGroupCode)
    {
      this.Write(idGroupCode, (object) connections.ConnectionPointId.Id);
      this.Write(stringGroupCode, (object) connections.ConnectionString);
    }

    private void method_30(DxfBlockAngleOffsetAction dxfObject)
    {
      this.Write(140, (object) dxfObject.DistanceCoefficient);
      this.Write(141, (object) dxfObject.AngleOffset);
      this.Write(280, (object) (byte) dxfObject.ScaleType);
    }

    private void method_31(DxfBlockStretchAction dxfObject)
    {
      this.method_50((DxfBlockAction) dxfObject);
      this.Write(100, (object) "AcDbBlockStretchAction");
      this.method_28(dxfObject.ActionConnections, 92, 301, true);
      int num1 = Class740.smethod_8(dxfObject.Frame);
      this.Write(72, (object) (short) num1);
      for (int index = 0; index < num1; ++index)
        this.Write(1011, dxfObject.Frame[index]);
      int num2 = Class740.smethod_7(dxfObject.StretchEntities);
      this.Write(73, (object) (short) num2);
      for (int index1 = 0; index1 < num2; ++index1)
      {
        this.Write(331, (object) dxfObject.StretchEntities[index1].Entity.Handle);
        int num3 = Class740.smethod_6(dxfObject.StretchEntities[index1].PointIndexes);
        this.Write(74, (object) (short) num3);
        for (int index2 = 0; index2 < num3; ++index2)
          this.Write(94, (object) dxfObject.StretchEntities[index1].PointIndexes[index2]);
      }
      int num4 = Class740.smethod_10(dxfObject.StretchNodes);
      this.Write(75, (object) (short) num4);
      for (int index1 = 0; index1 < num4; ++index1)
      {
        this.Write(95, (object) dxfObject.StretchNodes[index1].Node.Id);
        int num3 = Class740.smethod_6(dxfObject.StretchNodes[index1].PointIndexes);
        this.Write(76, (object) (short) num3);
        for (int index2 = 0; index2 < num3; ++index2)
          this.Write(94, (object) dxfObject.StretchNodes[index1].PointIndexes[index2]);
      }
      this.method_30((DxfBlockAngleOffsetAction) dxfObject);
    }

    private void method_32(DxfBlockScaleAction dxfObject)
    {
      this.method_49((DxfBlockBasePointAction) dxfObject);
      this.Write(100, (object) "AcDbBlockScaleAction");
      this.method_27(dxfObject.ActionConnections, 94, 303);
    }

    internal void method_33(
      DxfBlockParametersValueSet dxfObject,
      short n1,
      short n2,
      short n3,
      short n4)
    {
      this.Write((int) n4, (object) string.Empty);
      this.Write((int) n1, (object) (int) dxfObject.ValueSetFlags);
      this.Write((int) n2, (object) dxfObject.BoundedBelow);
      this.Write((int) n2 + 1, (object) dxfObject.BoundedAbove);
      this.Write((int) n2 + 2, (object) dxfObject.Increment);
      int num = Class740.smethod_1(dxfObject.List);
      this.Write((int) n3, (object) (short) num);
      for (int index = 0; index < num; ++index)
        this.Write((int) n2 + 3, (object) dxfObject.List[index]);
    }

    private void method_34(DxfBlockRotationParameter dxfObject)
    {
      this.method_52((DxfBlockTwoPointsParameter) dxfObject, true);
      this.Write(100, (object) "AcDbBlockRotationParameter");
      this.Write(305, (object) dxfObject.LabelText);
      this.Write(306, (object) dxfObject.Description);
      this.Write(1011, dxfObject.StartPoint);
      this.Write(140, (object) dxfObject.LabelOffset);
      this.method_33(dxfObject.Angle, (short) 96, (short) 141, (short) 175, (short) 307);
    }

    private void method_35(DxfBlockRotateAction dxfObject)
    {
      this.method_49((DxfBlockBasePointAction) dxfObject);
      this.Write(100, (object) "AcDbBlockRotationAction");
      this.method_29(dxfObject.ActionConnection, 94, 303);
    }

    private void method_36(DxfBlockPolarStretchAction dxfObject)
    {
      this.method_50((DxfBlockAction) dxfObject);
      this.Write(100, (object) "AcDbBlockPolarStretchAction");
      this.method_28(dxfObject.ActionConnections, 92, 301, true);
      int num1 = Class740.smethod_8(dxfObject.Frame);
      this.Write(73, (object) (short) num1);
      for (int index = 0; index < num1; ++index)
        this.Write(1011, dxfObject.Frame[index]);
      int num2 = Class740.smethod_3((IList<DxfHandledObject>) dxfObject.RotateSelection);
      this.Write(72, (object) (short) num2);
      for (int index = 0; index < num2; ++index)
        this.Write(331, (object) dxfObject.RotateSelection[index].Handle);
      int num3 = Class740.smethod_7(dxfObject.StretchEntities);
      this.Write(74, (object) (short) num3);
      for (int index1 = 0; index1 < num3; ++index1)
      {
        this.Write(332, (object) dxfObject.StretchEntities[index1].Entity.Handle);
        int num4 = Class740.smethod_6(dxfObject.StretchEntities[index1].PointIndexes);
        this.Write(75, (object) (short) num4);
        for (int index2 = 0; index2 < num4; ++index2)
          this.Write(76, (object) (short) dxfObject.StretchEntities[index1].PointIndexes[index2]);
      }
      int num5 = Class740.smethod_10(dxfObject.StretchNodes);
      this.Write(78, (object) (short) num5);
      for (int index1 = 0; index1 < num5; ++index1)
      {
        this.Write(98, (object) dxfObject.StretchNodes[index1].Node.Id);
        int num4 = Class740.smethod_6(dxfObject.StretchNodes[index1].PointIndexes);
        this.Write(79, (object) (short) num4);
        for (int index2 = 0; index2 < num4; ++index2)
          this.Write(76, (object) (short) dxfObject.StretchNodes[index1].PointIndexes[index2]);
      }
      this.Write(141, (object) dxfObject.DistanceCoefficient);
      this.Write(140, (object) dxfObject.AngleOffset);
      if (dxfObject.SelectionSet2 != null)
      {
        this.Write(77, (object) (short) dxfObject.SelectionSet2.Length);
        foreach (DxfEvalGraph.GraphNodeId graphNodeId in dxfObject.SelectionSet2)
          this.Write(91, (object) graphNodeId.Id);
      }
      else
        this.Write(77, (object) (short) 0);
    }

    private void method_37(DxfBlockPolarParameter dxfObject)
    {
      this.method_52((DxfBlockTwoPointsParameter) dxfObject, true);
      this.Write(100, (object) "AcDbBlockPolarParameter");
      this.Write(305, (object) dxfObject.LabelText);
      this.Write(306, (object) dxfObject.Description);
      this.Write(307, (object) dxfObject.AngleLabelText);
      this.Write(308, (object) dxfObject.AngleDescription);
      this.Write(140, (object) dxfObject.LabelOffset);
      this.method_33(dxfObject.Distance, (short) 96, (short) 141, (short) 175, (short) 309);
      this.method_33(dxfObject.Angle, (short) 97, (short) 145, (short) 176, (short) 410);
    }

    private void method_38(DxfBlockParameter dxfObject, bool writeObjectType)
    {
      this.method_45((DxfBlockElement) dxfObject, writeObjectType);
      this.Write(100, (object) "AcDbBlockParameter");
      this.Write(280, (object) (byte) (dxfObject.ShowProperties ? 1 : 0));
      this.Write(281, (object) (byte) (dxfObject.ChainActions ? 1 : 0));
    }

    private void method_39(DxfBlockMoveAction dxfObject)
    {
      this.method_50((DxfBlockAction) dxfObject);
      this.Write(100, (object) "AcDbBlockMoveAction");
      this.method_28(dxfObject.ActionConnections, 92, 301, true);
      this.method_30((DxfBlockAngleOffsetAction) dxfObject);
    }

    private void method_40(DxfBlockLookUpParameter dxfObject)
    {
      this.method_55((DxfBlockSinglePointParameter) dxfObject);
      this.Write(100, (object) "AcDbBlockLookUpParameter");
      this.Write(303, (object) dxfObject.LabelText);
      this.Write(304, (object) dxfObject.Description);
      this.Write(94, (object) dxfObject.ActionId.Id);
    }

    private void method_41(DxfBlockLookupAction dxfObject)
    {
      this.method_50((DxfBlockAction) dxfObject);
      this.Write(100, (object) "AcDbBlockLookupAction");
      this.Write(92, (object) dxfObject.NumberOfRows);
      this.Write(93, (object) dxfObject.NumberOfColumns);
      this.Write(301, (object) string.Empty);
      for (uint index = 0; (long) index < (long) (dxfObject.NumberOfRows * dxfObject.NumberOfColumns); ++index)
        this.Write(302, (object) dxfObject.Text[(IntPtr) index]);
      for (uint index = 0; (long) index < (long) dxfObject.NumberOfColumns; ++index)
      {
        this.Write(303, (object) string.Empty);
        this.Write(94, (object) dxfObject.Information[(IntPtr) index].Id.Id);
        this.Write(95, (object) dxfObject.Information[(IntPtr) index].ResourceType);
        this.Write(96, (object) dxfObject.Information[(IntPtr) index].Type);
        this.Write(282, (object) (byte) (dxfObject.Information[(IntPtr) index].PropertyType ? 1 : 0));
        this.Write(305, (object) dxfObject.Information[(IntPtr) index].Unmatched);
        this.Write(281, (object) (byte) (dxfObject.Information[(IntPtr) index].AllowEditing ? 1 : 0));
        this.Write(304, (object) dxfObject.Information[(IntPtr) index].ConnectionText);
      }
      this.Write(280, (object) (byte) (dxfObject.UnknownFlag ? 1 : 0));
    }

    private void method_42(DxfBlockLinearParameter dxfObject)
    {
      this.method_52((DxfBlockTwoPointsParameter) dxfObject, true);
      this.Write(100, (object) "AcDbBlockLinearParameter");
      this.Write(305, (object) dxfObject.LabelText);
      this.Write(306, (object) dxfObject.Description);
      this.Write(140, (object) dxfObject.LabelOffset);
      this.method_33(dxfObject.Distance, (short) 96, (short) 141, (short) 175, (short) 307);
    }

    private void method_43(DxfBlockFlipParameter dxfObject)
    {
      this.method_52((DxfBlockTwoPointsParameter) dxfObject, true);
      this.Write(100, (object) "AcDbBlockFlipParameter");
      this.Write(305, (object) dxfObject.LabelText);
      this.Write(306, (object) dxfObject.Description);
      this.Write(307, (object) dxfObject.NotFlippedState);
      this.Write(308, (object) dxfObject.FlippedState);
      this.Write(1012, dxfObject.LabelPosition);
      this.Write(309, (object) dxfObject.Connection.ConnectionString);
      this.Write(96, (object) dxfObject.Connection.ConnectionPointId.Id);
    }

    private void method_44(DxfBlockFlipAction dxfObject)
    {
      this.method_50((DxfBlockAction) dxfObject);
      this.Write(100, (object) "AcDbBlockFlipAction");
      this.method_27(dxfObject.ActionConnections, 92, 301);
    }

    private void method_45(DxfBlockElement dxfObject, bool writeObjectType)
    {
      this.method_54((DxfEvalGraphExpression) dxfObject, writeObjectType);
      this.Write(100, (object) "AcDbBlockElement");
      this.Write(300, (object) dxfObject.Name);
      if (this.dxfVersion_0 <= DxfVersion.Dxf18)
      {
        this.Write(98, (object) 25);
        this.Write(99, (object) 104);
      }
      else
      {
        this.Write(98, (object) 27);
        this.Write(99, (object) 1);
      }
      this.Write(1071, (object) dxfObject.UnknownField);
    }

    private void method_46(DxfBlockBasePointParameter dxfObject)
    {
      this.method_55((DxfBlockSinglePointParameter) dxfObject);
      this.Write(100, (object) "AcDbBlockBasepointParameter");
      this.Write(1011, dxfObject.BasePoint1);
      this.Write(1012, dxfObject.BasePoint2);
    }

    private void method_47(DxfBlockArrayAction dxfObject)
    {
      this.method_50((DxfBlockAction) dxfObject);
      this.Write(100, (object) "AcDbBlockArrayAction");
      this.method_27(dxfObject.ActionConnections, 92, 301);
      this.Write(140, (object) dxfObject.RowOffset);
      this.Write(141, (object) dxfObject.ColumnOffset);
    }

    private void method_48(DxfBlockAlignmentParameter dxfObject)
    {
      this.method_52((DxfBlockTwoPointsParameter) dxfObject, true);
      this.Write(100, (object) "AcDbBlockAlignmentParameter");
      this.Write(280, (object) (byte) (dxfObject.IsPerpendicular ? 1 : 0));
    }

    private void method_49(DxfBlockBasePointAction dxfObject)
    {
      this.method_50((DxfBlockAction) dxfObject);
      this.Write(100, (object) "AcDbBlockActionWithBasePt");
      this.method_27(dxfObject.Connections, 92, 301);
      this.Write(1011, dxfObject.BasePoint);
      this.Write(280, (object) (byte) (dxfObject.IndependentFlag ? 0 : 1));
      this.Write(1012, dxfObject.Offset);
    }

    private void method_50(DxfBlockAction dxfObject)
    {
      this.method_45((DxfBlockElement) dxfObject, true);
      this.Write(100, (object) "AcDbBlockAction");
      int num1 = Class740.smethod_4(dxfObject.AttachedElements);
      this.Write(70, (object) (short) num1);
      for (int index = 0; index < num1; ++index)
        this.Write(91, (object) dxfObject.AttachedElements[index].Id);
      int num2 = Class740.smethod_3((IList<DxfHandledObject>) dxfObject.AttachedEntities);
      this.Write(71, (object) (short) num2);
      for (int index = 0; index < num2; ++index)
        this.Write(330, (object) dxfObject.AttachedEntities[index].Handle);
      this.Write(1010, dxfObject.Position);
    }

    private void method_51(DxfBlockParameterPropertyInfo dxfObject, int n1, int n2, int n3)
    {
      int num = Class740.smethod_0(dxfObject.ConnectionPoints);
      this.Write(n1, (object) (short) num);
      for (int index = 0; index < num; ++index)
      {
        this.Write(n2, (object) dxfObject.ConnectionPoints[index].ConnectionPointId.Id);
        this.Write(n3, (object) dxfObject.ConnectionPoints[index].ConnectionString);
      }
    }

    internal void method_52(DxfBlockTwoPointsParameter dxfObject, bool writeObjectType = true)
    {
      this.method_38((DxfBlockParameter) dxfObject, writeObjectType);
      this.Write(100, (object) "AcDbBlock2PtParameter");
      this.Write(1010, dxfObject.FirstPoint);
      this.Write(1011, dxfObject.SecondPoint);
      this.Write(170, (object) (short) 4);
      for (int index = 0; index < 4; ++index)
        this.Write(91, (object) dxfObject.GripIds[index].Id);
      for (int index = 0; index < 4; ++index)
        this.method_51(dxfObject.Properties[index], 171 + index, 92 + index, 301 + index);
      this.Write(177, (object) (short) dxfObject.BasePoint);
    }

    private void method_53(DxfXRecordValue currentGroup, bool silence)
    {
      if (currentGroup == null)
      {
        this.Write(170, (object) (short) -9999);
      }
      else
      {
        short code = currentGroup.Code;
        if (code == (short) -9999)
        {
          if (!silence)
            throw new Exception("WriteXRecordValueBit not implemented");
        }
        else
        {
          Enum5 enum5 = Class820.smethod_2((int) code);
          switch (enum5)
          {
            case Enum5.const_1:
              this.Write((int) code, (object) (byte) ((byte) currentGroup.Value != (byte) 0 ? 1 : 0));
              break;
            case Enum5.const_2:
              this.Write((int) code, (object) (byte) currentGroup.Value);
              break;
            case Enum5.const_3:
              int num = (int) (byte) currentGroup.Value;
              throw new Exception("Byte array not implemented");
            case Enum5.const_4:
              this.Write((int) code, (object) (double) currentGroup.Value);
              break;
            case Enum5.const_5:
              this.Write((int) code, (object) DxfHandledObject.Class9.smethod_0((ulong) currentGroup.Value));
              break;
            case Enum5.const_6:
              this.Write((int) code, (object) (string) currentGroup.Value);
              break;
            case Enum5.const_7:
            case Enum5.const_8:
            case Enum5.const_9:
            case Enum5.const_14:
            case Enum5.const_15:
              this.Write((int) code, (object) (ulong) (currentGroup.Value == null ? 0L : (long) ((DxfHandledObject) currentGroup.Value).Handle));
              break;
            case Enum5.const_10:
            case Enum5.const_17:
              this.Write((int) code, (object) (short) currentGroup.Value);
              break;
            case Enum5.const_11:
              this.Write((int) code, (object) (int) currentGroup.Value);
              break;
            case Enum5.const_12:
              this.Write((int) code, (object) (long) currentGroup.Value);
              break;
            case Enum5.const_13:
              this.Write((int) code, (WW.Math.Point3D) currentGroup.Value);
              break;
            case Enum5.const_16:
              this.Write((int) code, (object) (string) currentGroup.Value);
              break;
            default:
              throw new Exception("Unknown group value type " + (object) enum5 + " for group " + (object) code + ".");
          }
        }
      }
    }

    private static DxfWriter.ResourceTypes smethod_0(short groupCode)
    {
      if (groupCode >= (short) -6 && groupCode <= (short) 479)
      {
        if (groupCode <= (short) -6 || groupCode <= (short) -5)
          return DxfWriter.ResourceTypes.Unknown;
        if (groupCode <= (short) -4)
          return DxfWriter.ResourceTypes.String;
        if (groupCode <= (short) -3)
          return DxfWriter.ResourceTypes.Unknown;
        if (groupCode <= (short) -2)
          return DxfWriter.ResourceTypes.HardPointerId;
        if (groupCode <= (short) -1)
          return DxfWriter.ResourceTypes.SoftPointerId;
        if (groupCode <= (short) 4)
          return DxfWriter.ResourceTypes.String;
        if (groupCode <= (short) 5)
          return DxfWriter.ResourceTypes.Handle;
        if (groupCode <= (short) 8)
          return DxfWriter.ResourceTypes.Name;
        if (groupCode <= (short) 9)
          return DxfWriter.ResourceTypes.String;
        if (groupCode <= (short) 19)
          return DxfWriter.ResourceTypes.Point;
        if (groupCode <= (short) 49)
          return DxfWriter.ResourceTypes.Double;
        if (groupCode <= (short) 59)
          return DxfWriter.ResourceTypes.Angle;
        if (groupCode <= (short) 79)
          return DxfWriter.ResourceTypes.Integer16;
        if (groupCode <= (short) 89)
          return DxfWriter.ResourceTypes.Unknown;
        if (groupCode <= (short) 99)
          return DxfWriter.ResourceTypes.Integer32;
        if (groupCode <= (short) 102)
          return DxfWriter.ResourceTypes.String;
        if (groupCode <= (short) 104)
          return DxfWriter.ResourceTypes.Unknown;
        if (groupCode <= (short) 105)
          return DxfWriter.ResourceTypes.Handle;
        if (groupCode <= (short) 109)
          return DxfWriter.ResourceTypes.Unknown;
        if (groupCode <= (short) 119)
          return DxfWriter.ResourceTypes.Point;
        if (groupCode <= (short) 149)
          return DxfWriter.ResourceTypes.Double;
        if (groupCode <= (short) 159)
          return DxfWriter.ResourceTypes.Unknown;
        if (groupCode <= (short) 169)
          return DxfWriter.ResourceTypes.Integer64;
        if (groupCode <= (short) 179)
          return DxfWriter.ResourceTypes.Integer16;
        if (groupCode <= (short) 209)
          return DxfWriter.ResourceTypes.Unknown;
        if (groupCode <= (short) 219)
          return DxfWriter.ResourceTypes.Point;
        if (groupCode <= (short) 220)
          return DxfWriter.ResourceTypes.Double;
        if (groupCode <= (short) 223)
          return DxfWriter.ResourceTypes.Point;
        if (groupCode <= (short) 229)
          return DxfWriter.ResourceTypes.Unknown;
        if (groupCode <= (short) 230)
          return DxfWriter.ResourceTypes.Double;
        if (groupCode <= (short) 233)
          return DxfWriter.ResourceTypes.Point;
        if (groupCode <= (short) 269)
          return DxfWriter.ResourceTypes.Unknown;
        if (groupCode <= (short) 279)
          return DxfWriter.ResourceTypes.Integer16;
        if (groupCode <= (short) 289)
          return DxfWriter.ResourceTypes.Integer8;
        if (groupCode <= (short) 299)
          return DxfWriter.ResourceTypes.Bool;
        if (groupCode <= (short) 309)
          return DxfWriter.ResourceTypes.String;
        if (groupCode <= (short) 319)
          return DxfWriter.ResourceTypes.BinaryChunk;
        if (groupCode <= (short) 329)
          return DxfWriter.ResourceTypes.ObjectId;
        if (groupCode <= (short) 349)
          return DxfWriter.ResourceTypes.HardPointerId;
        if (groupCode <= (short) 359)
          return DxfWriter.ResourceTypes.SoftOwnershipId;
        if (groupCode <= (short) 369)
          return DxfWriter.ResourceTypes.HardOwnershipId;
        if (groupCode <= (short) 389)
          return DxfWriter.ResourceTypes.Integer16;
        if (groupCode <= (short) 399)
          return DxfWriter.ResourceTypes.ObjectId;
        if (groupCode <= (short) 409)
          return DxfWriter.ResourceTypes.Integer16;
        if (groupCode <= (short) 419)
          return DxfWriter.ResourceTypes.String;
        if (groupCode <= (short) 429)
          return DxfWriter.ResourceTypes.Integer32;
        if (groupCode <= (short) 439)
          return DxfWriter.ResourceTypes.String;
        if (groupCode <= (short) 459)
          return DxfWriter.ResourceTypes.Integer32;
        if (groupCode <= (short) 469)
          return DxfWriter.ResourceTypes.Double;
        if (groupCode <= (short) 479)
          return DxfWriter.ResourceTypes.String;
      }
      if (groupCode >= (short) 1000)
      {
        if (groupCode <= (short) 1002)
          return DxfWriter.ResourceTypes.String;
        if (groupCode <= (short) 1003)
          return DxfWriter.ResourceTypes.LayerName;
        if (groupCode <= (short) 1004)
          return DxfWriter.ResourceTypes.BinaryChunk;
        if (groupCode <= (short) 1005)
          return DxfWriter.ResourceTypes.Handle;
        if (groupCode <= (short) 1009)
          return DxfWriter.ResourceTypes.Unknown;
        if (groupCode <= (short) 1013)
          return DxfWriter.ResourceTypes.Point;
        if (groupCode <= (short) 1019)
          return DxfWriter.ResourceTypes.Unknown;
        if (groupCode <= (short) 1059)
          return DxfWriter.ResourceTypes.Double;
        if (groupCode <= (short) 1070)
          return DxfWriter.ResourceTypes.Integer16;
        if (groupCode <= (short) 1071)
          return DxfWriter.ResourceTypes.Integer32;
      }
      if (groupCode >= (short) 5000)
      {
        if (groupCode <= (short) 5000)
          return DxfWriter.ResourceTypes.Unknown;
        if (groupCode <= (short) 5001)
          return DxfWriter.ResourceTypes.Double;
        if (groupCode <= (short) 5002)
          return DxfWriter.ResourceTypes.Point;
        if (groupCode <= (short) 5003)
          return DxfWriter.ResourceTypes.Integer16;
        if (groupCode <= (short) 5004)
          return DxfWriter.ResourceTypes.Angle;
        if (groupCode <= (short) 5005)
          return DxfWriter.ResourceTypes.String;
        if (groupCode <= (short) 5006)
          return DxfWriter.ResourceTypes.HardPointerId;
        if (groupCode <= (short) 5007)
          return DxfWriter.ResourceTypes.Unknown;
        if (groupCode <= (short) 5008)
          return DxfWriter.ResourceTypes.Angle;
        if (groupCode <= (short) 5009)
          return DxfWriter.ResourceTypes.Point;
        if (groupCode <= (short) 5010)
          return DxfWriter.ResourceTypes.Integer32;
        if (groupCode <= (short) 5019)
          return DxfWriter.ResourceTypes.Unknown;
        if (groupCode <= (short) 5020)
          return DxfWriter.ResourceTypes.String;
      }
      throw new Exception("ConvertGroupCodeToResourceType failed : type " + (object) groupCode);
    }

    public static short ConvertResourceTypeForEvalGraphExpression(short valueCode)
    {
      switch (DxfWriter.smethod_0(valueCode))
      {
        case DxfWriter.ResourceTypes.Name:
        case DxfWriter.ResourceTypes.String:
        case DxfWriter.ResourceTypes.LayerName:
          return 1;
        case DxfWriter.ResourceTypes.Bool:
        case DxfWriter.ResourceTypes.Integer8:
        case DxfWriter.ResourceTypes.Integer16:
          return 70;
        case DxfWriter.ResourceTypes.Integer32:
          return 90;
        case DxfWriter.ResourceTypes.Double:
        case DxfWriter.ResourceTypes.Angle:
          return 40;
        case DxfWriter.ResourceTypes.Point:
          return 11;
        case DxfWriter.ResourceTypes.Handle:
        case DxfWriter.ResourceTypes.ObjectId:
        case DxfWriter.ResourceTypes.SoftPointerId:
        case DxfWriter.ResourceTypes.HardPointerId:
        case DxfWriter.ResourceTypes.SoftOwnershipId:
        case DxfWriter.ResourceTypes.HardOwnershipId:
          return 91;
        default:
          throw new Exception("ConvertResourceTypeForEvalGraphExpression failed : type " + (object) valueCode);
      }
    }

    private void method_54(DxfEvalGraphExpression dxfObject, bool writeObjectType)
    {
      if (writeObjectType)
        this.method_203((DxfObject) dxfObject);
      else
        this.method_201((DxfHandledObject) dxfObject);
      this.Write(100, (object) "AcDbEvalExpr");
      this.Write(90, (object) dxfObject.NodeId.Id);
      this.Write(98, (object) dxfObject.VersionMajor);
      this.Write(99, (object) dxfObject.VersionMinor);
      if (dxfObject.DataValue == null)
        return;
      this.Write(1, (object) string.Empty);
      this.Write(70, (object) DxfWriter.ConvertResourceTypeForEvalGraphExpression(dxfObject.DataValue.Code));
      this.method_53(dxfObject.DataValue, true);
    }

    private void method_55(DxfBlockSinglePointParameter dxfObject)
    {
      this.method_38((DxfBlockParameter) dxfObject, true);
      this.Write(100, (object) "AcDbBlock1PtParameter");
      this.Write(1010, dxfObject.BasePoint);
      this.Write(93, (object) dxfObject.GripId.Id);
      this.method_51(dxfObject.FirstProperty, 170, 91, 301);
      this.method_51(dxfObject.SecondProperty, 171, 92, 302);
    }

    private void method_56(DxfBlockXYGrip dxfObject)
    {
      this.method_63((DxfBlockGrip) dxfObject);
      this.Write(100, (object) "AcDbBlockXYGrip");
    }

    private void method_57(DxfBlockVisibilityGrip dxfObject)
    {
      this.method_63((DxfBlockGrip) dxfObject);
      this.Write(100, (object) "AcDbBlockVisibilityGrip");
    }

    private void method_58(DxfBlockRotationGrip dxfObject)
    {
      this.method_63((DxfBlockGrip) dxfObject);
      this.Write(100, (object) "AcDbBlockRotationGrip");
    }

    private void method_59(DxfBlockPolarGrip dxfObject)
    {
      this.method_63((DxfBlockGrip) dxfObject);
      this.Write(100, (object) "AcDbBlockPolarGrip");
    }

    private void method_60(DxfBlockPropertiesTableGrip dxfObject)
    {
      this.method_63((DxfBlockGrip) dxfObject);
    }

    private void method_61(DxfBlockLookupGrip dxfObject)
    {
      this.method_63((DxfBlockGrip) dxfObject);
      this.Write(100, (object) "AcDbBlockLookUpGrip");
    }

    private void method_62(DxfBlockLinearGrip dxfObject)
    {
      this.method_63((DxfBlockGrip) dxfObject);
      this.Write(100, (object) "AcDbBlockLinearGrip");
      this.Write(140, (object) dxfObject.Distance.X);
      this.Write(141, (object) dxfObject.Distance.Y);
      this.Write(142, (object) dxfObject.Distance.Z);
    }

    private void method_63(DxfBlockGrip dxfObject)
    {
      this.method_45((DxfBlockElement) dxfObject, true);
      this.Write(100, (object) "AcDbBlockGrip");
      this.Write(91, (object) dxfObject.GripExpression1.Id);
      this.Write(92, (object) dxfObject.GripExpression2.Id);
      this.Write(1010, dxfObject.Position);
      this.Write(280, (object) (byte) (dxfObject.CyclingFlag ? 1 : 0));
      this.Write(93, (object) dxfObject.CyclingWeight);
    }

    private void method_64(DxfBlockFlipGrip dxfObject)
    {
      this.method_63((DxfBlockGrip) dxfObject);
      this.Write(100, (object) "AcDbBlockFlipGrip");
      this.Write(140, (object) dxfObject.Orientation.X);
      this.Write(141, (object) dxfObject.Orientation.Y);
      this.Write(142, (object) dxfObject.Orientation.Z);
      this.Write(93, (object) dxfObject.FlipExpression.Id);
    }

    private void method_65(DxfBlockRepresentationData dxfObject)
    {
      this.method_203((DxfObject) dxfObject);
      this.Write(100, (object) "AcDbBlockRepresentationData");
      this.Write(70, (object) dxfObject.Version);
      this.Write(340, (object) dxfObject.DynamicBlock.Handle);
    }

    private void method_66(DxfBlockPurgePreventer dxfObject)
    {
      this.method_203((DxfObject) dxfObject);
      this.Write(100, (object) "AcDbDynamicBlockPurgePreventer");
      this.Write(70, (object) dxfObject.Version);
    }

    private void method_67(DxfBlockAlignmentGrip dxfObject)
    {
      this.method_63((DxfBlockGrip) dxfObject);
      this.Write(100, (object) "AcDbBlockAlignmentGrip");
      this.Write(140, (object) dxfObject.Alignment.X);
      this.Write(141, (object) dxfObject.Alignment.Y);
      this.Write(142, (object) dxfObject.Alignment.Z);
    }

    private void method_68(DxfBlockGripExpression dxfObject)
    {
      this.method_54((DxfEvalGraphExpression) dxfObject, true);
      this.Write(100, (object) "AcDbBlockGripExpr");
      this.method_29(dxfObject.ActionConnection, 91, 300);
    }

    private void method_69(DxfDynamicBlockProxyNode dxfObject)
    {
      this.method_54((DxfEvalGraphExpression) dxfObject, true);
    }

    private void method_70(DxfBlockXYParameter dxfObject)
    {
      this.method_52((DxfBlockTwoPointsParameter) dxfObject, true);
      this.Write(100, (object) "AcDbBlockXYParameter");
      this.Write(305, (object) dxfObject.LabelTextY);
      this.Write(306, (object) dxfObject.LabelTextX);
      this.Write(307, (object) dxfObject.DescriptionY);
      this.Write(308, (object) dxfObject.DescriptionX);
      this.Write(140, (object) dxfObject.LabelOffsetY);
      this.Write(141, (object) dxfObject.LabelOffsetX);
      this.method_33(dxfObject.ParameterValueSetY, (short) 97, (short) 146, (short) 176, (short) 309);
      this.method_33(dxfObject.ParameterValueSetX, (short) 96, (short) 142, (short) 175, (short) 410);
    }

    public DxfWriter(Stream stream, DxfModel model, bool binary)
    {
      Encoding encoding = !model.Header.Dxf21OrHigher ? Encodings.GetEncoding((int) model.Header.DrawingCodePage) : (Encoding) new UTF8Encoding(false);
      if (binary)
      {
        stream.Write(Class1018.byte_1, 0, Class1018.byte_1.Length);
        BinaryWriter binaryWriter = new BinaryWriter(stream, encoding);
        this.interface13_0 = !model.Header.Dxf14OrHigher ? (Interface13) new Class347(binaryWriter, encoding) : (Interface13) new Class348(binaryWriter, encoding);
      }
      else
        this.interface13_0 = (Interface13) new Class633((TextWriter) new StreamWriter(stream, encoding));
      this.dxfModel_0 = model;
      this.dxfVersion_0 = model.Header.AcadVersion;
      this.class39_0 = new DxfWriter.Class39(this);
    }

    public bool AutoCloseStream
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public DxfMessageCollection Messages
    {
      get
      {
        return this.dxfMessageCollection_0;
      }
    }

    public DxfVersion Version
    {
      get
      {
        return this.dxfVersion_0;
      }
    }

    public static void Write(string filename, DxfModel model, bool binary)
    {
      DxfMessage[] messages;
      if (!model.Validate(out messages))
        throw new DxfException("Cannot write invalid model, see Messages property for more information. ", messages);
      Stream stream = (Stream) File.Create(filename);
      try
      {
        new DxfWriter(stream, model, binary).Write(false);
      }
      finally
      {
        stream.Close();
      }
      model.Filename = filename;
    }

    public static void Write(Stream stream, DxfModel model)
    {
      DxfWriter.Write(stream, model, false);
    }

    public static void Write(Stream stream, DxfModel model, bool binary)
    {
      DxfMessage[] messages;
      if (!model.Validate(out messages))
        throw new DxfException("Cannot write invalid model, see Messages property for more information. ", messages);
      try
      {
        new DxfWriter(stream, model, binary).Write(false);
      }
      finally
      {
        stream.Close();
      }
    }

    public static void Write(string filename, DxfModel model)
    {
      DxfWriter.Write(filename, model, false);
    }

    public void Write()
    {
      this.Write(true);
    }

    public void Write(bool validate)
    {
      Class809.smethod_0(Enum15.const_1);
      DxfMessage[] messages;
      if (validate && !this.dxfModel_0.Validate(out messages))
        throw new DxfException("Cannot write invalid model", messages);
      this.method_215();
      DxfScale currentAnnotationScale = this.dxfModel_0.Header.CurrentAnnotationScale;
      this.dxfModel_0.Header.CurrentAnnotationScale = (DxfScale) null;
      CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
      try
      {
        this.method_72();
        if (this.dxfModel_0.Header.Dxf13OrHigher)
          this.method_88();
        this.method_91();
        this.method_110();
        this.method_112();
        if (this.dxfModel_0.Header.Dxf13OrHigher)
          this.method_178();
        if (this.dxfModel_0.Header.AcadVersion > DxfVersion.Dxf24)
          this.method_214();
        this.Write(999, (object) "Created By CadLib version 4.0.37.140");
        this.Write(999, (object) "CadLib website: www.woutware.com");
        this.Write(Class824.struct18_27);
      }
      finally
      {
        Thread.CurrentThread.CurrentCulture = currentCulture;
        if (this.interface13_0 != null)
        {
          this.interface13_0.Flush();
          if (this.bool_0)
            this.interface13_0.imethod_5();
        }
      }
      List<UnsupportedObject> unsupportedObjectList = new List<UnsupportedObject>((IEnumerable<UnsupportedObject>) this.dictionary_0.Values);
      unsupportedObjectList.Sort();
      foreach (UnsupportedObject unsupportedObject in unsupportedObjectList)
        this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.UnknownEntity, Severity.Warning)
        {
          Parameters = {
            {
              "EntityName",
              (object) unsupportedObject.Name
            },
            {
              "Count",
              (object) unsupportedObject.Count
            }
          }
        });
      this.dxfModel_0.Header.CurrentAnnotationScale = currentAnnotationScale;
    }

    internal DxfModel Model
    {
      get
      {
        return this.dxfModel_0;
      }
    }

    internal void method_71(DxfObject o)
    {
      if (o == null)
        return;
      this.queue_0.Enqueue(o);
    }

    private void method_72()
    {
      this.Write(Class824.struct18_0);
      this.Write(Class824.struct18_2);
      DxfHeader header = this.dxfModel_0.Header;
      DxfDimensionStyleOverrides dimensionStyleOverrides = header.DimensionStyleOverrides;
      this.method_74("$ACADVER", 1, header.AcadVersionString);
      if (header.Dxf14OrHigher && header.AcadMaintenanceVersion != 0)
      {
        if (header.AcadVersion > DxfVersion.Dxf27)
          this.method_84("$ACADMAINTVER", 90, header.AcadMaintenanceVersion);
        else
          this.method_81("$ACADMAINTVER", 70, (short) header.AcadMaintenanceVersion);
      }
      this.method_74("$DWGCODEPAGE", 3, header.DrawingCodePageString);
      if (this.dxfVersion_0 > DxfVersion.Dxf15)
      {
        this.method_74("$TITLE", 1, this.dxfModel_0.SummaryInfo.Title);
        this.method_74("$SUBJECT", 1, this.dxfModel_0.SummaryInfo.Subject);
        this.method_74("$AUTHOR", 1, this.dxfModel_0.SummaryInfo.Author);
        if (this.dxfVersion_0 > DxfVersion.Dxf24)
          this.method_85("$REQUIREDVERSIONS", 160, this.dxfModel_0.Header.RequiredVersions);
        this.method_74("$KEYWORDS", 1, this.dxfModel_0.SummaryInfo.Keywords);
        this.method_74("$COMMENTS", 1, this.dxfModel_0.SummaryInfo.Comments);
        this.method_74("$LASTSAVEDBY", 1, this.dxfModel_0.SummaryInfo.LastSavedBy);
        this.method_74("$REVISIONNUMBER", 1, this.dxfModel_0.SummaryInfo.RevisionNumber);
        foreach (SummaryInfo.Property property in this.dxfModel_0.SummaryInfo.Properties)
        {
          if (!string.IsNullOrEmpty(property.Name))
          {
            this.method_74("$CUSTOMPROPERTYTAG", 1, property.Name);
            this.method_74("$CUSTOMPROPERTY", 1, property.Value);
          }
        }
      }
      this.method_77("$INSBASE", header.InsertionBase);
      this.method_77("$EXTMIN", header.ExtMin);
      this.method_77("$EXTMAX", header.ExtMax);
      this.method_75("$LIMMIN", header.LimitsMin);
      this.method_75("$LIMMAX", header.LimitsMax);
      this.method_82("$SNAPMODE", 70, header.SnapMode);
      this.method_76("$SNAPUNIT", header.SnapSpacing);
      this.method_75("$SNAPBASE", header.SnapBase);
      this.method_79("$SNAPANG", 50, header.SnapAngle * (180.0 / System.Math.PI));
      this.method_81("$SNAPSTYLE", 70, (short) header.SnapStyle);
      this.method_81("$SNAPISOPAIR", 70, (short) header.SnapType);
      this.method_82("$ORTHOMODE", 70, header.OrthoMode);
      this.method_82("$REGENMODE", 70, header.RegenerationMode);
      this.method_82("$FILLMODE", 70, header.FillMode);
      this.method_82("$QTEXTMODE", 70, header.QuickTextMode);
      this.method_82("$MIRRTEXT", 70, header.MirrorText);
      this.method_79("$LTSCALE", 40, header.LineTypeScale);
      this.method_81("$OSMODE", 70, (short) header.ObjectSnapMode);
      this.method_81("$ATTMODE", 70, (short) header.AttributeVisibility);
      this.method_79("$TEXTSIZE", 40, header.TextHeightDefault);
      this.method_79("$TRACEWID", 40, header.TraceWidthDefault);
      if (header.CurrentTextStyle != null)
        this.method_74("$TEXTSTYLE", 7, header.CurrentTextStyle.Name);
      if (header.CurrentLayer != null)
        this.method_74("$CLAYER", 8, header.CurrentLayer.Name);
      if (header.CurrentEntityLineType != null)
        this.method_74("$CELTYPE", 6, header.CurrentEntityLineType.Name);
      this.method_81("$CECOLOR", 62, DxfIndexedColorSet.smethod_14(header.CurrentEntityColor));
      if (header.Dxf13OrHigher)
      {
        this.method_79("$CELTSCALE", 40, header.CurrentEntityLinetypeScale);
        this.method_82("$DISPSILH", 70, header.DisplaySilhouetteCurves);
      }
      this.method_79("$DIMSCALE", 40, dimensionStyleOverrides.ScaleFactor);
      this.method_79("$DIMASZ", 40, dimensionStyleOverrides.ArrowSize);
      this.method_79("$DIMEXO", 40, dimensionStyleOverrides.ExtensionLineOffset);
      this.method_79("$DIMDLI", 40, dimensionStyleOverrides.DimensionLineIncrement);
      this.method_79("$DIMRND", 40, dimensionStyleOverrides.Rounding);
      this.method_79("$DIMDLE", 40, dimensionStyleOverrides.DimensionLineExtension);
      this.method_79("$DIMEXE", 40, dimensionStyleOverrides.ExtensionLineExtension);
      this.method_79("$DIMTP", 40, dimensionStyleOverrides.PlusTolerance);
      this.method_79("$DIMTM", 40, dimensionStyleOverrides.MinusTolerance);
      this.method_79("$DIMTXT", 40, dimensionStyleOverrides.TextHeight);
      this.method_79("$DIMCEN", 40, dimensionStyleOverrides.CenterMarkSize);
      this.method_79("$DIMTSZ", 40, dimensionStyleOverrides.TickSize);
      this.method_82("$DIMTOL", 70, dimensionStyleOverrides.GenerateTolerances);
      this.method_82("$DIMLIM", 70, dimensionStyleOverrides.LimitsGeneration);
      this.method_82("$DIMTIH", 70, dimensionStyleOverrides.TextInsideHorizontal);
      this.method_82("$DIMTOH", 70, dimensionStyleOverrides.TextOutsideHorizontal);
      this.method_82("$DIMSE1", 70, dimensionStyleOverrides.SuppressFirstExtensionLine);
      this.method_82("$DIMSE2", 70, dimensionStyleOverrides.SuppressSecondExtensionLine);
      this.method_81("$DIMTAD", 70, (short) dimensionStyleOverrides.TextVerticalAlignment);
      this.method_81("$DIMZIN", 70, (short) dimensionStyleOverrides.ZeroHandling);
      this.method_74("$DIMBLK", 1, DxfHeader.smethod_0(dimensionStyleOverrides.ArrowBlock));
      this.method_82("$DIMASO", 70, header.AssociatedDimensions);
      this.method_82("$DIMSHO", 70, header.UpdateDimensionsWhileDragging);
      this.method_74("$DIMPOST", 1, dimensionStyleOverrides.PostFix);
      this.method_74("$DIMAPOST", 1, dimensionStyleOverrides.AlternateDimensioningSuffix);
      this.method_82("$DIMALT", 70, dimensionStyleOverrides.AlternateUnitDimensioning);
      this.method_81("$DIMALTD", 70, dimensionStyleOverrides.AlternateUnitDecimalPlaces);
      this.method_79("$DIMALTF", 40, dimensionStyleOverrides.AlternateUnitScaleFactor);
      this.method_79("$DIMLFAC", 40, dimensionStyleOverrides.LinearScaleFactor);
      this.method_82("$DIMTOFL", 70, dimensionStyleOverrides.TextOutsideExtensions);
      this.method_79("$DIMTVP", 40, dimensionStyleOverrides.TextVerticalPosition);
      this.method_82("$DIMTIX", 70, dimensionStyleOverrides.TextInsideExtensions);
      this.method_82("$DIMSOXD", 70, dimensionStyleOverrides.SuppressOutsideExtensions);
      this.method_82("$DIMSAH", 70, dimensionStyleOverrides.SeparateArrowBlocks);
      this.method_74("$DIMBLK1", 1, DxfHeader.smethod_0(dimensionStyleOverrides.FirstArrowBlock));
      this.method_74("$DIMBLK2", 1, DxfHeader.smethod_0(dimensionStyleOverrides.SecondArrowBlock));
      if (header.AcadVersion >= DxfVersion.Dxf12)
      {
        if (this.dxfModel_0.Header.DimensionStyleOverrides != null && this.dxfModel_0.Header.DimensionStyle != null && !string.IsNullOrEmpty(this.dxfModel_0.Header.DimensionStyle.Name))
          this.method_74("$DIMSTYLE", 2, this.dxfModel_0.Header.DimensionStyle.Name);
        this.method_81("$DIMCLRD", 70, DxfIndexedColorSet.smethod_14(dimensionStyleOverrides.DimensionLineColor));
        this.method_81("$DIMCLRE", 70, DxfIndexedColorSet.smethod_14(dimensionStyleOverrides.ExtensionLineColor));
        this.method_81("$DIMCLRT", 70, DxfIndexedColorSet.smethod_14(dimensionStyleOverrides.TextColor));
        this.method_79("$DIMTFAC", 40, dimensionStyleOverrides.ToleranceScaleFactor);
        this.method_79("$DIMGAP", 40, dimensionStyleOverrides.DimensionLineGap);
      }
      if (header.Dxf13OrHigher)
      {
        this.method_81("$DIMJUST", 70, (short) dimensionStyleOverrides.TextHorizontalAlignment);
        this.method_82("$DIMSD1", 70, dimensionStyleOverrides.SuppressFirstDimensionLine);
        this.method_82("$DIMSD2", 70, dimensionStyleOverrides.SuppressSecondDimensionLine);
        this.method_81("$DIMTOLJ", 70, (short) dimensionStyleOverrides.ToleranceAlignment);
        this.method_81("$DIMTZIN", 70, (short) dimensionStyleOverrides.ToleranceZeroHandling);
        this.method_81("$DIMALTZ", 70, (short) dimensionStyleOverrides.AlternateUnitZeroHandling);
        this.method_81("$DIMALTTZ", 70, (short) dimensionStyleOverrides.AlternateUnitToleranceZeroHandling);
        this.method_81("$DIMUPT", 70, (short) dimensionStyleOverrides.CursorUpdate);
        this.method_81("$DIMDEC", 70, dimensionStyleOverrides.DecimalPlaces);
        this.method_81("$DIMTDEC", 70, dimensionStyleOverrides.ToleranceDecimalPlaces);
        this.method_81("$DIMALTU", 70, (short) dimensionStyleOverrides.AlternateUnitFormat);
        this.method_81("$DIMALTTD", 70, dimensionStyleOverrides.AlternateUnitToleranceDecimalPlaces);
        this.method_74("$DIMTXSTY", 7, dimensionStyleOverrides.TextStyle == null ? (string) null : dimensionStyleOverrides.TextStyle.Name);
        this.method_81("$DIMAUNIT", 70, (short) dimensionStyleOverrides.AngularUnit);
      }
      if (header.AcadVersion >= DxfVersion.Dxf15)
      {
        this.method_81("$DIMADEC", 70, dimensionStyleOverrides.AngularDimensionDecimalPlaces);
        this.method_79("$DIMALTRND", 40, dimensionStyleOverrides.AlternateUnitRounding);
        this.method_81("$DIMAZIN", 70, (short) dimensionStyleOverrides.AngularZeroHandling);
        this.method_81("$DIMDSEP", 70, (short) dimensionStyleOverrides.DecimalSeparator);
        this.method_81("$DIMATFIT", 70, (short) dimensionStyleOverrides.ArrowsTextFit);
        this.method_81("$DIMFRAC", 70, (short) dimensionStyleOverrides.FractionFormat);
        this.method_74("$DIMLDRBLK", 1, dimensionStyleOverrides.LeaderArrowBlock == null ? (string) null : this.method_243(dimensionStyleOverrides.LeaderArrowBlock.Name));
        this.method_81("$DIMLUNIT", 70, (short) dimensionStyleOverrides.LinearUnitFormat);
        this.method_81("$DIMLWD", 70, dimensionStyleOverrides.DimensionLineWeight);
        this.method_81("$DIMLWE", 70, dimensionStyleOverrides.ExtensionLineWeight);
      }
      if (header.Dxf21OrHigher)
      {
        this.method_79("$DIMFXL", 40, dimensionStyleOverrides.FixedExtensionLineLength);
        this.method_81("$DIMFXLON", 70, this.method_73(dimensionStyleOverrides.IsExtensionLineLengthFixed));
        this.method_79("$DIMJOGANG", 40, dimensionStyleOverrides.JoggedRadiusDimensionTransverseSegmentAngle);
        this.method_81("$DIMTFILL", 70, (short) dimensionStyleOverrides.TextBackgroundFillMode);
        this.method_81("$DIMTFILLCLR", 70, DxfIndexedColorSet.smethod_14(dimensionStyleOverrides.TextBackgroundColor));
        this.method_81("$DIMARCSYM", 70, (short) dimensionStyleOverrides.ArcLengthSymbolPosition);
        this.method_74("$DIMLTYPE", 6, dimensionStyleOverrides.DimensionLineLineType == null ? string.Empty : dimensionStyleOverrides.DimensionLineLineType.Name);
        this.method_74("$DIMLTEX1", 6, dimensionStyleOverrides.FirstExtensionLineLineType == null ? string.Empty : dimensionStyleOverrides.FirstExtensionLineLineType.Name);
        this.method_74("$DIMLTEX2", 6, dimensionStyleOverrides.SecondExtensionLineLineType == null ? string.Empty : dimensionStyleOverrides.SecondExtensionLineLineType.Name);
      }
      if (header.AcadVersion >= DxfVersion.Dxf13 && header.AcadVersion < DxfVersion.Dxf15)
        this.method_81("$DIMFIT", 70, (short) dimensionStyleOverrides.ArrowsTextFit);
      this.method_81("$LUNITS", 70, (short) header.LinearUnitFormat);
      this.method_81("$LUPREC", 70, header.LinearUnitPrecision);
      this.method_79("$SKETCHINC", 40, header.SketchIncrement);
      this.method_79("$FILLETRAD", 40, header.FilletRadius);
      this.method_81("$AUNITS", 70, (short) header.AngularUnit);
      this.method_81("$AUPREC", 70, header.AngularUnitPrecision);
      this.method_74("$MENU", 1, header.MenuFileName);
      this.method_79("$ELEVATION", 40, header.Elevation);
      if (header.AcadVersion >= DxfVersion.Dxf12)
        this.method_79("$PELEVATION", 40, header.PaperSpaceElevation);
      this.method_79("$THICKNESS", 40, header.ThicknessDefault);
      this.method_82("$LIMCHECK", 70, header.LimitCheckingOn);
      this.method_79("$CHAMFERA", 40, header.ChamferDistance1);
      this.method_79("$CHAMFERB", 40, header.ChamferDistance2);
      if (header.Dxf13OrHigher)
      {
        this.method_79("$CHAMFERC", 40, header.ChamferLength);
        this.method_79("$CHAMFERD", 40, header.ChamferAngle * (180.0 / System.Math.PI));
      }
      this.method_82("$SKPOLY", 70, header.SketchPolylines);
      this.method_79("$TDCREATE", 40, Class644.smethod_0(header.CreateDateTime));
      if (header.AcadVersion >= DxfVersion.Dxf15)
        this.method_79("$TDUCREATE", 40, Class644.smethod_0(header.CreateUtcDateTime));
      this.method_79("$TDUPDATE", 40, Class644.smethod_0(header.UpdateDateTime));
      if (header.AcadVersion >= DxfVersion.Dxf15)
        this.method_79("$TDUUPDATE", 40, Class644.smethod_0(header.UpdateUtcDateTime));
      this.method_79("$TDINDWG", 40, Class644.smethod_3(this.dxfModel_0.SummaryInfo.TotalEditingTime));
      this.method_79("$TDUSRTIMER", 40, Class644.smethod_3(header.UserElapsedTimeSpan));
      this.method_82("$USRTIMER", 70, header.UserTimer);
      this.method_79("$ANGBASE", 50, header.AngleBase * (180.0 / System.Math.PI));
      this.method_81("$ANGDIR", 70, (short) header.AngularDirection);
      this.method_81("$PDMODE", 70, (short) header.PointDisplayMode);
      this.method_79("$PDSIZE", 40, header.PointDisplaySize);
      this.method_79("$PLINEWID", 40, header.PolylineWidthDefault);
      this.method_82("$SPLFRAME", 70, header.ShowSplineControlPoints);
      this.method_81("$SPLINETYPE", 70, (short) header.SplineType);
      this.method_81("$SPLINESEGS", 70, header.NumberOfSplineSegments);
      if (header.AcadVersion >= DxfVersion.Dxf10)
      {
        if (!header.Dxf15OrHigher)
          this.method_82("$HANDLING", 70, header.Handling);
        this.method_86("$HANDSEED", 5, header.HandleSeed);
      }
      this.method_81("$SURFTAB1", 70, header.SurfaceMeshTabulationCount1);
      this.method_81("$SURFTAB2", 70, header.SurfaceMeshTabulationCount2);
      this.method_81("$SURFTYPE", 70, header.SurfaceType);
      this.method_81("$SURFU", 70, header.SurfaceDensityU);
      this.method_81("$SURFV", 70, header.SurfaceDensityV);
      if (header.Ucs != null)
      {
        if (header.Dxf15OrHigher && header.UcsBase != null)
          this.method_74("$UCSBASE", 2, header.UcsBase.Name);
        if (!string.IsNullOrEmpty(header.Ucs.Name))
          this.method_74("$UCSNAME", 2, header.Ucs.Name);
        this.method_77("$UCSORG", header.Ucs.Origin);
        this.method_78("$UCSXDIR", header.Ucs.XAxis);
        this.method_78("$UCSYDIR", header.Ucs.YAxis);
        if (header.AcadVersion >= DxfVersion.Dxf15)
        {
          this.method_74("$UCSORTHOREF", 2, header.UcsBase != null ? header.UcsBase.Name : string.Empty);
          this.method_81("$UCSORTHOVIEW", 70, (short) header.Ucs.OrthographicViewType);
          this.method_78("$UCSORGTOP", header.Ucs.OrthographicTopDOrigin);
          this.method_78("$UCSORGBOTTOM", header.Ucs.OrthographicBottomDOrigin);
          this.method_78("$UCSORGLEFT", header.Ucs.OrthographicLeftDOrigin);
          this.method_78("$UCSORGRIGHT", header.Ucs.OrthographicRightDOrigin);
          this.method_78("$UCSORGFRONT", header.Ucs.OrthographicFrontDOrigin);
          this.method_78("$UCSORGBACK", header.Ucs.OrthographicBackDOrigin);
        }
      }
      if (header.PaperSpaceUcs != null)
      {
        if (header.Dxf15OrHigher && header.PaperSpaceUcsBase != null)
          this.method_74("$PUCSBASE", 2, header.PaperSpaceUcsBase.Name);
        if (!string.IsNullOrEmpty(header.PaperSpaceUcs.Name))
          this.method_74("$PUCSNAME", 2, header.PaperSpaceUcs.Name);
        this.method_77("$PUCSORG", header.PaperSpaceUcs.Origin);
        this.method_78("$PUCSXDIR", header.PaperSpaceUcs.XAxis);
        this.method_78("$PUCSYDIR", header.PaperSpaceUcs.YAxis);
        if (header.AcadVersion >= DxfVersion.Dxf15)
        {
          this.method_74("$PUCSORTHOREF", 2, header.PaperSpaceUcsBase != null ? header.PaperSpaceUcsBase.Name : string.Empty);
          this.method_81("$PUCSORTHOVIEW", 70, (short) header.PaperSpaceUcs.OrthographicViewType);
          this.method_78("$PUCSORGTOP", header.PaperSpaceUcs.OrthographicTopDOrigin);
          this.method_78("$PUCSORGBOTTOM", header.PaperSpaceUcs.OrthographicBottomDOrigin);
          this.method_78("$PUCSORGLEFT", header.PaperSpaceUcs.OrthographicLeftDOrigin);
          this.method_78("$PUCSORGRIGHT", header.PaperSpaceUcs.OrthographicRightDOrigin);
          this.method_78("$PUCSORGFRONT", header.PaperSpaceUcs.OrthographicFrontDOrigin);
          this.method_78("$PUCSORGBACK", header.PaperSpaceUcs.OrthographicBackDOrigin);
        }
      }
      this.method_81("$USERI1", 70, header.UserShort1);
      this.method_81("$USERI2", 70, header.UserShort2);
      this.method_81("$USERI3", 70, header.UserShort3);
      this.method_81("$USERI4", 70, header.UserShort4);
      this.method_81("$USERI5", 70, header.UserShort5);
      this.method_79("$USERR1", 40, header.UserDouble1);
      this.method_79("$USERR2", 40, header.UserDouble2);
      this.method_79("$USERR3", 40, header.UserDouble3);
      this.method_79("$USERR4", 40, header.UserDouble4);
      this.method_79("$USERR5", 40, header.UserDouble5);
      this.method_82("$WORLDVIEW", 70, header.WorldView);
      if (header.AcadVersion >= DxfVersion.Dxf12)
      {
        this.method_81("$SHADEDGE", 70, (short) header.ShadeEdge);
        this.method_81("$SHADEDIF", 70, header.ShadeDiffuseToAmbientPercentage);
        this.method_82("$TILEMODE", 70, header.ShowModelSpace);
        this.method_81("$MAXACTVP", 70, header.MaxViewportCount);
        this.method_77("$PINSBASE", header.PaperSpaceInsertionBase);
        this.method_82("$PLIMCHECK", 70, header.PaperSpaceLimitsChecking);
        this.method_77("$PEXTMIN", header.PaperSpaceExtMin);
        this.method_77("$PEXTMAX", header.PaperSpaceExtMax);
        this.method_75("$PLIMMAX", header.PaperSpaceLimitsMax);
        this.method_75("$PLIMMIN", header.PaperSpaceLimitsMin);
        this.method_81("$UNITMODE", 70, header.UnitMode);
        this.method_82("$VISRETAIN", 70, header.RetainXRefDependentVisibilitySettings);
        this.method_81("$PLINEGEN", 70, (short) header.PolylineLineTypeGeneration);
        this.method_81("$PSLTSCALE", 70, (short) header.PaperSpaceLineTypeScaling);
        this.method_81("$TREEDEPTH", 70, header.SpatialIndexMaxTreeDepth);
      }
      if (header.Dxf13OrHigher)
      {
        if (header.CurrentMultilineStyle != null)
          this.method_74("$CMLSTYLE", 2, header.CurrentMultilineStyle.Name);
        this.method_81("$CMLJUST", 70, (short) header.CurrentMultilineJustification);
        this.method_79("$CMLSCALE", 40, header.CurrentMultilineScale);
      }
      if (header.Dxf14OrHigher)
      {
        this.method_82("$PROXYGRAPHICS", 70, header.ProxyGraphics);
        this.method_81("$MEASUREMENT", 70, (short) header.MeasurementUnits);
      }
      if (header.AcadVersion >= DxfVersion.Dxf15)
      {
        this.method_81("$CELWEIGHT", 370, header.CurrentEntityLineWeight);
        this.method_80("$ENDCAPS", 280, (byte) header.EndCaps);
        this.method_80("$JOINSTYLE", 280, (byte) header.JoinStyle);
        this.method_83("$LWDISPLAY", 290, header.DisplayLineWeight);
        this.method_81("$INSUNITS", 70, (short) header.InsUnits);
        this.method_74("$HYPERLINKBASE", 1, this.dxfModel_0.SummaryInfo.HyperLinkBase);
        this.method_83("$XEDIT", 290, header.WorldView);
        this.method_81("$CEPSNTYPE", 380, (short) header.CurrentEntityPlotStyleType);
        this.method_83("$PSTYLEMODE", 290, header.PlotStyleMode == PlotStyleMode.ColorDependent);
        this.method_74("$FINGERPRINTGUID", 2, header.FingerPrintGuid);
        this.method_74("$VERSIONGUID", 2, header.VersionGuid);
        this.method_83("$EXTNAMES", 290, header.ExtendedNames);
        this.method_79("$PSVPSCALE", 40, header.ViewportDefaultViewScaleFactor);
        this.method_80("$CSHADOW", 280, (byte) header.ShadowMode);
        this.method_79("$SHADOWPLANELOCATION", 40, header.ShadowPlaneLocation);
      }
      if (header.Dxf18OrHigher)
      {
        this.method_80("$SORTENTS", 280, (byte) header.EntitySortingFlags);
        this.method_80("$INDEXCTL", 280, (byte) header.IndexCreationFlags);
        if (header.Dxf24OrHigher)
          this.method_80("$XCLIPFRAME", 280, (byte) header.ExternalReferenceClippingBoundaryType);
        else
          this.method_83("$XCLIPFRAME", 290, header.ExternalReferenceClippingBoundaryType != SimpleLineType.Off);
        this.method_80("$HALOGAP", 280, header.HaloGapPercentage);
        this.method_81("$OBSCOLOR", 70, DxfIndexedColorSet.smethod_14(header.ObscuredColor));
        this.method_80("$OBSLTYPE", 280, (byte) header.ObscuredLineType);
        this.method_80("$INTERSECTIONDISPLAY", 280, header.IntersectionDisplay ? (byte) 1 : (byte) 0);
        this.method_81("$INTERSECTIONCOLOR", 70, DxfIndexedColorSet.smethod_14(header.IntersectionColor));
        this.method_80("$DIMASSOC", 280, (byte) header.DimensionAssociativity);
        this.method_74("$PROJECTNAME", 1, header.ProjectName);
      }
      if (header.Dxf21OrHigher)
      {
        this.method_81("$INTERFERECOLOR", 62, DxfIndexedColorSet.smethod_14(header.InterfereColor));
        this.method_87("$INTERFEREOBJVS", 345, header.InterfereObjectStyle);
        this.method_87("$INTERFEREVPVS", 346, header.InterfereViewportStyle);
      }
      foreach (Class980 class980 in (IEnumerable<Class980>) this.dxfModel_0.Header.method_3())
      {
        this.Write(9, (object) class980.Name);
        IList<Struct18> valueGroups = (IList<Struct18>) class980.ValueGroups;
        for (int index = 0; index < valueGroups.Count; ++index)
          this.Write(valueGroups[index]);
      }
      this.Write(Class824.struct18_1);
    }

    private short method_73(bool value)
    {
      return !value ? (short) 0 : (short) 1;
    }

    private void method_74(string variableName, int groupCode, string value)
    {
      this.Write(9, (object) variableName);
      this.Write(groupCode, (object) value);
    }

    private void method_75(string variableName, WW.Math.Point2D value)
    {
      this.Write(9, (object) variableName);
      this.Write(10, (object) value.X);
      this.Write(20, (object) value.Y);
    }

    private void method_76(string variableName, Vector2D value)
    {
      this.Write(9, (object) variableName);
      this.Write(10, (object) value.X);
      this.Write(20, (object) value.Y);
    }

    private void method_77(string variableName, WW.Math.Point3D value)
    {
      this.Write(9, (object) variableName);
      this.Write(10, (object) value.X);
      this.Write(20, (object) value.Y);
      this.Write(30, (object) value.Z);
    }

    private void method_78(string variableName, WW.Math.Vector3D value)
    {
      this.Write(9, (object) variableName);
      this.Write(10, (object) value.X);
      this.Write(20, (object) value.Y);
      this.Write(30, (object) value.Z);
    }

    private void method_79(string variableName, int groupCode, double value)
    {
      this.Write(9, (object) variableName);
      this.Write(groupCode, (object) value);
    }

    private void method_80(string variableName, int groupCode, byte value)
    {
      this.Write(9, (object) variableName);
      this.Write(groupCode, (object) value);
    }

    private void method_81(string variableName, int groupCode, short value)
    {
      this.Write(9, (object) variableName);
      this.Write(groupCode, (object) value);
    }

    private void method_82(string variableName, int groupCode, bool value)
    {
      this.Write(9, (object) variableName);
      this.Write(groupCode, (object) (short) (value ? 1 : 0));
    }

    private void method_83(string variableName, int groupCode, bool value)
    {
      this.Write(9, (object) variableName);
      this.Write(groupCode, (object) value);
    }

    private void method_84(string variableName, int groupCode, int value)
    {
      this.Write(9, (object) variableName);
      this.Write(groupCode, (object) value);
    }

    private void method_85(string variableName, int groupCode, long value)
    {
      this.Write(9, (object) variableName);
      this.Write(groupCode, (object) value);
    }

    private void method_86(string variableName, int groupCode, ulong value)
    {
      this.Write(9, (object) variableName);
      this.Write(groupCode, (object) value);
    }

    private void method_87(string variableName, int groupCode, DxfHandledObject obj)
    {
      if (obj == null)
        return;
      this.Write(9, (object) variableName);
      this.Write(groupCode, (object) obj.Handle);
    }

    private void method_88()
    {
      this.method_89();
      this.Write(Class824.struct18_0);
      this.Write(Class824.struct18_3);
      foreach (DxfClass classObject in (List<DxfClass>) this.dxfModel_0.Classes)
        this.method_90(classObject);
      this.Write(Class824.struct18_1);
    }

    private void method_89()
    {
      if (this.dxfModel_0.Header.Dxf21OrHigher)
      {
        DxfClass.smethod_11(this.dxfModel_0.Classes);
        DxfClass.smethod_14(this.dxfModel_0.Classes);
        DxfClass.smethod_7(this.dxfModel_0.Classes);
      }
      if (!this.dxfModel_0.Header.Dxf14OrHigher)
        return;
      DxfClass.smethod_2(this.dxfModel_0.Classes);
      DxfClass.smethod_3(this.dxfModel_0.Classes);
      DxfClass.smethod_4(this.dxfModel_0.Classes);
      DxfClass.smethod_5(this.dxfModel_0.Classes);
      Class1030.Class1032 class1032 = new Class1030.Class1032(this.dxfModel_0);
    }

    private void method_90(DxfClass classObject)
    {
      this.Write(0, (object) "CLASS");
      this.Write(1, (object) classObject.DxfName);
      this.Write(2, (object) classObject.CPlusPlusClassName);
      if (this.dxfModel_0.Header.Dxf13OrHigher)
        this.Write(3, (object) classObject.ApplicationName);
      this.Write(90, (object) (int) classObject.GetEffectiveProxyFlags(this.dxfVersion_0));
      if (this.dxfModel_0.Header.Dxf18OrHigher)
        this.Write(91, (object) 1);
      this.method_222(280, classObject.WasAZombie);
      this.method_222(281, classObject.ItemClassId == (short) 498);
    }

    private void method_91()
    {
      this.Write(Class824.struct18_0);
      this.Write(Class824.struct18_5);
      this.method_102();
      this.method_92();
      this.method_94();
      this.method_96();
      this.method_100();
      this.method_98();
      this.method_104();
      this.method_106();
      if (this.dxfModel_0.Header.Dxf13OrHigher)
        this.method_108();
      this.Write(Class824.struct18_1);
    }

    private void method_92()
    {
      this.Write(Class824.struct18_6);
      this.Write(2, (object) "LTYPE");
      if (this.WriteHandles)
        this.method_216(this.dxfModel_0.LineTypeTable);
      this.method_234("AcDbSymbolTable");
      this.Write(70, (object) (short) this.dxfModel_0.LineTypes.Count);
      foreach (DxfLineType lineType in (KeyedDxfHandledObjectCollection<string, DxfLineType>) this.dxfModel_0.LineTypes)
        this.method_93(lineType);
      this.Write(Class824.struct18_10);
    }

    private void method_93(DxfLineType lineType)
    {
      this.Write(Class824.struct18_8);
      this.method_201((DxfHandledObject) lineType);
      this.method_234("AcDbSymbolTableRecord");
      this.method_234("AcDbLinetypeTableRecord");
      this.Write(2, (object) lineType.Name);
      this.Write(3, (object) lineType.Description);
      this.Write(70, (object) (short) lineType.Flags);
      this.Write(72, (object) (short) 65);
      if (this.dxfModel_0.Header.Dxf13OrHigher)
      {
        int count = lineType.Elements.Count;
        this.Write(73, (object) (short) count);
        this.Write(40, (object) lineType.TotalLength);
        for (int index = 0; index < count; ++index)
        {
          DxfLineType.Element element = lineType.Elements[index];
          this.Write(49, (object) element.Length);
          this.Write(74, (object) (short) element.ElementType);
          if (element.ElementType != DxfLineType.ElementType.None)
          {
            if (element.IsShape)
              this.Write(75, (object) element.ShapeNumber);
            else if (element.IsText)
              this.Write(75, (object) (short) 0);
            if (element.TextStyle == null)
              this.Write(340, (object) 0UL);
            else
              this.method_218(340, (DxfHandledObject) element.TextStyle);
            this.Write(46, (object) element.Scale);
            this.Write(50, (object) (element.Rotation * (180.0 / System.Math.PI)));
            this.Write(44, (object) element.Offset.X);
            this.Write(45, (object) element.Offset.Y);
            if (!string.IsNullOrEmpty(element.Text))
              this.Write(9, (object) element.Text);
          }
        }
      }
      else
      {
        this.Write(73, (object) (short) lineType.Elements.Count);
        this.Write(40, (object) lineType.TotalLength);
        foreach (DxfLineType.Element element in (List<DxfLineType.Element>) lineType.Elements)
          this.Write(49, (object) element.Length);
      }
      this.method_115((DxfHandledObject) lineType);
    }

    private void method_94()
    {
      if (this.dxfModel_0.Layers.Count <= 0)
        return;
      this.Write(Class824.struct18_6);
      this.Write(2, (object) "LAYER");
      if (this.WriteHandles)
        this.method_216(this.dxfModel_0.LayerTable);
      this.method_234("AcDbSymbolTable");
      this.Write(70, (object) (short) this.dxfModel_0.Layers.Count);
      foreach (DxfLayer layer in (KeyedDxfHandledObjectCollection<string, DxfLayer>) this.dxfModel_0.Layers)
        this.method_95(layer);
      this.Write(Class824.struct18_10);
    }

    private void method_95(DxfLayer layer)
    {
      this.Write(Class824.struct18_7);
      this.method_201((DxfHandledObject) layer);
      this.method_234("AcDbSymbolTableRecord");
      this.method_234("AcDbLayerTableRecord");
      this.Write(70, (object) (short) layer.Flags);
      this.Write(2, (object) layer.Name);
      if (layer.Color.ColorType == ColorType.ByColorIndex)
      {
        short num = layer.Color.ColorIndex;
        if (!layer.Enabled)
          num = -num;
        this.method_219(62, num);
      }
      else
      {
        DxfIndexedColorSet backgroundIndexedColors = DxfIndexedColorSet.AcadBlackBackgroundIndexedColors;
        ArgbColor argbColor = layer.Color.ToArgbColor(backgroundIndexedColors);
        int colorDifference;
        short num1 = DxfIndexedColorSet.GetColorIndex(backgroundIndexedColors, argbColor, out colorDifference);
        if (!layer.Enabled)
          num1 = -num1;
        this.method_219(62, num1);
        if (this.dxfVersion_0 > DxfVersion.Dxf15 && colorDifference != 0)
        {
          int num2 = argbColor.Argb & 16777215;
          if (num2 != 0)
            this.Write(420, (object) num2);
        }
      }
      if (this.dxfVersion_0 > DxfVersion.Dxf15)
      {
        if (!string.IsNullOrEmpty(layer.Color.ColorBookName) || !string.IsNullOrEmpty(layer.Color.Name))
          this.Write(430, (object) layer.Color.method_0());
        if (layer.Transparency != Transparency.Opaque)
          this.Write(440, (object) (int) layer.Transparency.Data);
      }
      if (layer.LineType != null)
        this.Write(6, (object) layer.LineType.Name);
      else
        this.Write(6, (object) "Continuous");
      if (this.dxfModel_0.Header.Dxf15OrHigher)
      {
        if (!layer.PlotEnabled)
          this.Write(290, (object) false);
        this.Write(370, (object) layer.LineWeight);
        this.method_218(390, (DxfHandledObject) this.dxfModel_0.PlotStyle);
        if (this.dxfModel_0.Header.AcadVersion > DxfVersion.Dxf24)
          this.method_218(348, (DxfHandledObject) null);
      }
      this.method_115((DxfHandledObject) layer);
    }

    private void method_96()
    {
      if (this.dxfModel_0.TextStyles.Count <= 0)
        return;
      this.Write(Class824.struct18_6);
      this.Write(2, (object) "STYLE");
      if (this.WriteHandles)
        this.method_216(this.dxfModel_0.TextStyleTable);
      this.method_234("AcDbSymbolTable");
      this.Write(70, (object) (short) this.dxfModel_0.TextStyles.Count);
      foreach (DxfTextStyle textStyle in (DxfHandledObjectCollection<DxfTextStyle>) this.dxfModel_0.TextStyles)
        this.method_97(textStyle);
      this.Write(Class824.struct18_10);
    }

    private void method_97(DxfTextStyle textStyle)
    {
      this.Write(Class824.struct18_9);
      this.method_201((DxfHandledObject) textStyle);
      this.method_234("AcDbSymbolTableRecord");
      this.method_234("AcDbTextStyleTableRecord");
      this.Write(2, (object) textStyle.Name);
      this.Write(70, (object) (short) textStyle.Flags);
      this.Write(40, (object) textStyle.FixedHeight);
      this.Write(41, (object) textStyle.WidthFactor);
      this.Write(50, (object) (textStyle.ObliqueAngle * (180.0 / System.Math.PI)));
      this.Write(71, (object) textStyle.TextGenerationFlags);
      this.Write(42, (object) textStyle.LastHeightUsed);
      if (!string.IsNullOrEmpty(textStyle.FontFilename))
        this.Write(3, (object) textStyle.FontFilename);
      if (!string.IsNullOrEmpty(textStyle.BigFontFilename))
        this.Write(4, (object) textStyle.BigFontFilename);
      this.method_115((DxfHandledObject) textStyle);
    }

    private void method_98()
    {
      if (this.dxfModel_0.UcsCollection.Count <= 0 && !this.dxfModel_0.Header.Dxf13OrHigher)
        return;
      this.Write(Class824.struct18_6);
      this.Write(2, (object) "UCS");
      if (this.WriteHandles)
        this.method_216(this.dxfModel_0.UcsTable);
      this.method_234("AcDbSymbolTable");
      this.Write(70, (object) (short) this.dxfModel_0.UcsCollection.Count);
      foreach (DxfUcs ucs in (KeyedDxfHandledObjectCollection<string, DxfUcs>) this.dxfModel_0.UcsCollection)
        this.method_99(ucs);
      this.Write(Class824.struct18_10);
    }

    private void method_99(DxfUcs ucs)
    {
      this.Write(Class824.struct18_11);
      this.method_201((DxfHandledObject) ucs);
      this.method_234("AcDbSymbolTableRecord");
      this.method_234("AcDbUCSTableRecord");
      this.Write(2, (object) ucs.Name);
      this.Write(70, (object) (short) ucs.Flags);
      this.Write(10, ucs.Origin);
      this.Write(11, ucs.XAxis);
      this.Write(12, ucs.YAxis);
      if (this.dxfModel_0.Header.Dxf15OrHigher)
      {
        this.Write(79, (object) (short) 0);
        this.Write(146, (object) ucs.Elevation);
        foreach (OrthographicType orthographic in Class1018.orthographicType_0)
        {
          WW.Math.Vector3D relativeOrigin = ucs.GetRelativeOrigin(orthographic);
          if (relativeOrigin != WW.Math.Vector3D.Zero)
          {
            this.Write(71, (object) (short) orthographic);
            this.Write(13, relativeOrigin);
          }
        }
      }
      this.method_115((DxfHandledObject) ucs);
    }

    private void method_100()
    {
      if (this.dxfModel_0.Views.Count <= 0 && !this.dxfModel_0.Header.Dxf13OrHigher)
        return;
      this.Write(Class824.struct18_6);
      this.Write(2, (object) "VIEW");
      if (this.WriteHandles)
        this.method_216(this.dxfModel_0.ViewTable);
      this.method_234("AcDbSymbolTable");
      this.Write(70, (object) (short) this.dxfModel_0.Views.Count);
      foreach (DxfView view in (KeyedDxfHandledObjectCollection<string, DxfView>) this.dxfModel_0.Views)
        this.method_101(view);
      this.Write(Class824.struct18_10);
    }

    private void method_101(DxfView view)
    {
      this.Write(Class824.struct18_12);
      this.method_201((DxfHandledObject) view);
      this.method_234("AcDbSymbolTableRecord");
      this.method_234("AcDbViewTableRecord");
      this.Write(2, (object) view.Name);
      this.Write(70, (object) (short) view.Flags);
      this.Write(40, (object) view.Size.Y);
      this.Write(41, (object) view.Size.X);
      this.Write(10, view.Center);
      this.Write(11, view.Direction);
      this.Write(12, view.Target);
      this.Write(42, (object) view.LensLength);
      this.Write(43, (object) view.FrontClippingPlane);
      this.Write(44, (object) view.BackClippingPlane);
      this.Write(50, (object) (view.TwistAngle * (180.0 / System.Math.PI)));
      this.Write(71, (object) (short) view.ViewMode);
      if (this.dxfModel_0.Header.Dxf15OrHigher)
      {
        this.Write(281, (object) (byte) view.RenderMode);
        this.Write(72, (object) (short) (view.UcsPerView ? 1 : 0));
        this.Write(110, view.Ucs.Origin);
        this.Write(111, view.Ucs.XAxis);
        this.Write(112, view.Ucs.YAxis);
        this.Write(79, (object) (short) view.UcsOrthographicType);
        this.Write(146, (object) view.Ucs.Elevation);
        if (view.Ucs.Handle != 0UL)
        {
          if (view.UcsOrthographicType == OrthographicType.None)
            this.method_218(345, (DxfHandledObject) view.Ucs);
          else
            this.method_218(346, (DxfHandledObject) view.Ucs);
        }
      }
      this.method_115((DxfHandledObject) view);
    }

    private void method_102()
    {
      if (this.dxfModel_0.VPorts.Count <= 0 && !this.dxfModel_0.Header.Dxf13OrHigher)
        return;
      this.Write(Class824.struct18_6);
      this.Write(2, (object) "VPORT");
      this.method_201(this.dxfModel_0.VPortTable);
      this.method_234("AcDbSymbolTable");
      this.Write(70, (object) (short) this.dxfModel_0.VPorts.Count);
      foreach (DxfVPort vport in (DxfHandledObjectCollection<DxfVPort>) this.dxfModel_0.VPorts)
        this.method_103(vport);
      this.Write(Class824.struct18_10);
    }

    private void method_103(DxfVPort vport)
    {
      this.Write(Class824.struct18_13);
      this.method_201((DxfHandledObject) vport);
      this.method_234("AcDbSymbolTableRecord");
      this.method_234("AcDbViewportTableRecord");
      this.Write(2, (object) vport.Name);
      this.Write(70, (object) (short) vport.Flags);
      this.Write(10, vport.BottomLeft);
      this.Write(11, vport.TopRight);
      this.Write(12, vport.Center);
      this.Write(13, vport.SnapBasePoint);
      this.Write(14, vport.SnapSpacing);
      this.Write(15, vport.GridSpacing);
      this.Write(16, vport.Direction);
      this.Write(17, vport.Target);
      if (vport.Height != 0.0)
        this.Write(40, (object) vport.Height);
      this.Write(41, (object) vport.AspectRatio);
      this.Write(42, (object) vport.LensLength);
      this.Write(43, (object) vport.FrontClippingPlane);
      this.Write(44, (object) vport.BackClippingPlane);
      this.Write(50, (object) (vport.SnapRotationAngle * (180.0 / System.Math.PI)));
      this.Write(51, (object) (vport.TwistAngle * (180.0 / System.Math.PI)));
      this.Write(71, (object) (short) vport.ViewMode);
      this.Write(72, (object) vport.CircleZoomPercent);
      this.Write(73, (object) vport.FastZoomPercent);
      this.Write(74, (object) (short) (vport.DisplayUcs ? 1 : 0));
      this.Write(75, (object) (short) (vport.Snap ? 1 : 0));
      this.Write(76, (object) (short) (vport.ShowGrid ? 1 : 0));
      this.Write(77, (object) vport.SnapStyle);
      this.Write(78, (object) vport.SnapIsoPair);
      if (this.dxfModel_0.Header.Dxf15OrHigher)
      {
        this.Write(281, (object) (byte) vport.RenderMode);
        this.Write(65, (object) (short) (vport.UcsPerViewport ? 1 : 0));
        if (vport.Ucs != null)
        {
          this.Write(110, vport.Ucs.Origin);
          this.Write(111, vport.Ucs.XAxis);
          this.Write(112, vport.Ucs.YAxis);
        }
        this.Write(79, (object) (short) vport.UcsOrthographicType);
        if (vport.Ucs != null)
        {
          this.Write(146, (object) vport.Ucs.Elevation);
          if (vport.Ucs.Handle != 0UL)
          {
            if (vport.UcsOrthographicType == OrthographicType.None)
              this.method_218(345, (DxfHandledObject) vport.Ucs);
            else
              this.method_218(346, (DxfHandledObject) vport.Ucs);
          }
        }
      }
      if (this.dxfModel_0.Header.Dxf21OrHigher)
      {
        if (vport.VisualStyle != null)
          this.method_218(348, (DxfHandledObject) vport.VisualStyle);
        this.Write(60, (object) (short) vport.GridFlags);
        this.Write(61, (object) vport.MinorGridLinesPerMajorGridLine);
        this.Write(292, (object) vport.UseDefaultLighting);
        this.Write(282, (object) (byte) vport.DefaultLightingType);
        this.Write(141, (object) vport.Brightness);
        this.Write(142, (object) vport.Contrast);
        this.method_230(63, vport.AmbientColor);
      }
      this.method_115((DxfHandledObject) vport);
    }

    private void method_104()
    {
      this.Write(Class824.struct18_6);
      this.Write(2, (object) "APPID");
      this.method_201(this.dxfModel_0.AppIdTable);
      this.method_234("AcDbSymbolTable");
      this.Write(70, (object) (short) this.dxfModel_0.AppIds.Count);
      foreach (DxfAppId appId in (KeyedDxfHandledObjectCollection<string, DxfAppId>) this.dxfModel_0.AppIds)
        this.method_105(appId);
      this.Write(Class824.struct18_10);
    }

    private void method_105(DxfAppId appId)
    {
      this.Write(0, (object) "APPID");
      this.method_201((DxfHandledObject) appId);
      this.method_234("AcDbSymbolTableRecord");
      this.method_234("AcDbRegAppTableRecord");
      this.Write(2, (object) appId.Name);
      this.Write(70, (object) (short) appId.Flags);
      this.method_115((DxfHandledObject) appId);
    }

    private void method_106()
    {
      this.Write(Class824.struct18_6);
      this.Write(2, (object) "DIMSTYLE");
      this.method_201(this.dxfModel_0.DimStyleTable);
      this.method_234("AcDbSymbolTable");
      this.Write(70, (object) (short) this.dxfModel_0.DimensionStyles.Count);
      if (this.dxfModel_0.Header.Dxf15OrHigher)
      {
        this.method_234("AcDbDimStyleTable");
        this.Write(71, (object) (short) 0);
      }
      foreach (DxfDimensionStyle dimensionStyle in (KeyedDxfHandledObjectCollection<string, DxfDimensionStyle>) this.dxfModel_0.DimensionStyles)
        this.method_107(dimensionStyle);
      this.Write(Class824.struct18_10);
    }

    private void method_107(DxfDimensionStyle dimStyle)
    {
      this.Write(0, (object) "DIMSTYLE");
      this.method_202((DxfHandledObject) dimStyle, 105);
      this.method_234("AcDbSymbolTableRecord");
      this.method_234("AcDbDimStyleTableRecord");
      this.Write(2, (object) dimStyle.Name);
      this.Write(70, (object) (short) dimStyle.Flags);
      this.Write(3, (object) dimStyle.PostFix);
      this.Write(4, (object) dimStyle.AlternateDimensioningSuffix);
      if (!this.dxfModel_0.Header.Dxf15OrHigher)
      {
        if (dimStyle.ArrowBlock != null)
          this.method_223(5, this.method_243(dimStyle.ArrowBlock.Name));
        else
          this.method_223(5, string.Empty);
        if (dimStyle.FirstArrowBlock != null)
          this.method_223(6, this.method_243(dimStyle.FirstArrowBlock.Name));
        else
          this.method_223(6, string.Empty);
        if (dimStyle.SecondArrowBlock != null)
          this.method_223(7, this.method_243(dimStyle.SecondArrowBlock.Name));
        else
          this.method_223(7, string.Empty);
      }
      this.Write(40, (object) dimStyle.ScaleFactor);
      this.Write(41, (object) dimStyle.ArrowSize);
      this.Write(42, (object) dimStyle.ExtensionLineOffset);
      this.Write(43, (object) dimStyle.DimensionLineIncrement);
      this.Write(44, (object) dimStyle.ExtensionLineExtension);
      this.Write(45, (object) dimStyle.Rounding);
      this.Write(46, (object) dimStyle.DimensionLineExtension);
      this.Write(47, (object) dimStyle.PlusTolerance);
      this.Write(48, (object) dimStyle.MinusTolerance);
      if (this.dxfModel_0.Header.Dxf21OrHigher)
      {
        if (dimStyle.FixedExtensionLineLength != 1.0)
          this.Write(49, (object) dimStyle.FixedExtensionLineLength);
        if (dimStyle.JoggedRadiusDimensionTransverseSegmentAngle != System.Math.PI / 4.0)
          this.Write(50, (object) dimStyle.JoggedRadiusDimensionTransverseSegmentAngle);
        if (dimStyle.TextBackgroundFillMode != DimensionTextBackgroundFillMode.NoBackground)
          this.Write(69, (object) (short) dimStyle.TextBackgroundFillMode);
        if (dimStyle.TextBackgroundFillMode == DimensionTextBackgroundFillMode.DimensionTextBackgroundColor)
          this.method_230(70, dimStyle.TextBackgroundColor);
        if (dimStyle.ArcLengthSymbolPosition != ArcLengthSymbolPosition.AboveDimensionText)
          this.Write(90, (object) (int) dimStyle.ArcLengthSymbolPosition);
      }
      this.Write(140, (object) dimStyle.TextHeight);
      this.Write(141, (object) dimStyle.CenterMarkSize);
      this.Write(142, (object) dimStyle.TickSize);
      this.Write(143, (object) dimStyle.AlternateUnitScaleFactor);
      this.Write(144, (object) dimStyle.LinearScaleFactor);
      this.Write(145, (object) dimStyle.TextVerticalPosition);
      this.Write(146, (object) dimStyle.ToleranceScaleFactor);
      this.Write(147, (object) dimStyle.DimensionLineGap);
      if (this.dxfModel_0.Header.Dxf15OrHigher)
        this.Write(148, (object) dimStyle.AlternateUnitRounding);
      this.Write(71, (object) (short) (dimStyle.GenerateTolerances ? 1 : 0));
      this.Write(72, (object) (short) (dimStyle.LimitsGeneration ? 1 : 0));
      this.Write(73, (object) (short) (dimStyle.TextInsideHorizontal ? 1 : 0));
      this.Write(74, (object) (short) (dimStyle.TextOutsideHorizontal ? 1 : 0));
      this.Write(75, (object) (short) (dimStyle.SuppressFirstExtensionLine ? 1 : 0));
      this.Write(76, (object) (short) (dimStyle.SuppressSecondExtensionLine ? 1 : 0));
      this.Write(77, (object) (short) dimStyle.TextVerticalAlignment);
      this.Write(78, (object) (short) dimStyle.ZeroHandling);
      if (this.dxfModel_0.Header.Dxf15OrHigher)
        this.Write(79, (object) (short) dimStyle.AngularZeroHandling);
      this.Write(170, (object) (short) (dimStyle.AlternateUnitDimensioning ? 1 : 0));
      this.Write(171, (object) dimStyle.AlternateUnitDecimalPlaces);
      this.Write(172, (object) (short) (dimStyle.TextOutsideExtensions ? 1 : 0));
      this.Write(173, (object) (short) (dimStyle.SeparateArrowBlocks ? 1 : 0));
      this.Write(174, (object) (short) (dimStyle.TextInsideExtensions ? 1 : 0));
      this.Write(175, (object) (short) (dimStyle.SuppressOutsideExtensions ? 1 : 0));
      this.method_233(176, dimStyle.DimensionLineColor, Color.ByBlock, this.dxfVersion_0 <= DxfVersion.Dxf12, false);
      this.method_233(177, dimStyle.ExtensionLineColor, Color.ByBlock, this.dxfVersion_0 <= DxfVersion.Dxf12, false);
      this.method_233(178, dimStyle.TextColor, Color.ByBlock, this.dxfVersion_0 <= DxfVersion.Dxf12, false);
      if (this.dxfModel_0.Header.Dxf15OrHigher)
        this.Write(179, (object) dimStyle.AngularDimensionDecimalPlaces);
      if (this.dxfModel_0.Header.Dxf13OrHigher)
      {
        if (!this.dxfModel_0.Header.Dxf15OrHigher)
          this.Write(270, (object) (short) dimStyle.LinearUnitFormat);
        this.Write(271, (object) dimStyle.DecimalPlaces);
        this.Write(272, (object) dimStyle.ToleranceDecimalPlaces);
        this.Write(273, (object) (short) dimStyle.AlternateUnitFormat);
        this.Write(274, (object) dimStyle.AlternateUnitToleranceDecimalPlaces);
        this.Write(275, (object) (short) dimStyle.AngularUnit);
      }
      if (this.dxfModel_0.Header.Dxf15OrHigher)
      {
        this.Write(276, (object) (short) dimStyle.FractionFormat);
        this.Write(277, (object) (short) dimStyle.LinearUnitFormat);
        this.Write(278, (object) (short) dimStyle.DecimalSeparator);
        this.Write(279, (object) (short) dimStyle.TextMovement);
      }
      if (this.dxfModel_0.Header.Dxf13OrHigher)
      {
        this.Write(280, (object) (byte) dimStyle.TextHorizontalAlignment);
        this.method_222(281, dimStyle.SuppressFirstDimensionLine);
        this.method_222(282, dimStyle.SuppressSecondDimensionLine);
        this.Write(283, (object) (byte) dimStyle.ToleranceAlignment);
        this.Write(284, (object) (byte) dimStyle.ToleranceZeroHandling);
        this.Write(285, (object) (byte) dimStyle.AlternateUnitZeroHandling);
        this.Write(286, (object) (byte) dimStyle.AlternateUnitToleranceZeroHandling);
        if (!this.dxfModel_0.Header.Dxf15OrHigher)
          this.Write(287, (object) (byte) dimStyle.ArrowsTextFit);
        this.Write(288, (object) (byte) dimStyle.CursorUpdate);
      }
      if (this.dxfModel_0.Header.Dxf15OrHigher)
        this.Write(289, (object) (byte) dimStyle.ArrowsTextFit);
      if (this.dxfModel_0.Header.Dxf21OrHigher && dimStyle.IsExtensionLineLengthFixed)
        this.Write(290, (object) dimStyle.IsExtensionLineLengthFixed);
      if (this.dxfModel_0.Header.Dxf13OrHigher && dimStyle.TextStyle != null)
        this.method_218(340, (DxfHandledObject) dimStyle.TextStyle);
      if (this.dxfModel_0.Header.Dxf15OrHigher)
      {
        if (dimStyle.LeaderArrowBlock != null)
          this.method_218(341, (DxfHandledObject) dimStyle.LeaderArrowBlock);
        if (dimStyle.ArrowBlock != null)
          this.method_218(342, (DxfHandledObject) dimStyle.ArrowBlock);
        if (dimStyle.FirstArrowBlock != null)
          this.method_218(343, (DxfHandledObject) dimStyle.FirstArrowBlock);
        if (dimStyle.SecondArrowBlock != null)
          this.method_218(344, (DxfHandledObject) dimStyle.SecondArrowBlock);
        if (this.dxfModel_0.Header.Dxf21OrHigher)
        {
          if (dimStyle.DimensionLineLineType != null && dimStyle.DimensionLineLineType != this.dxfModel_0.ByBlockLineType)
            this.method_218(345, (DxfHandledObject) dimStyle.DimensionLineLineType);
          if (dimStyle.FirstExtensionLineLineType != null && dimStyle.FirstExtensionLineLineType != this.dxfModel_0.ByBlockLineType)
            this.method_218(346, (DxfHandledObject) dimStyle.FirstExtensionLineLineType);
          if (dimStyle.SecondExtensionLineLineType != null && dimStyle.SecondExtensionLineLineType != this.dxfModel_0.ByBlockLineType)
            this.method_218(347, (DxfHandledObject) dimStyle.SecondExtensionLineLineType);
        }
        this.Write(371, (object) dimStyle.DimensionLineWeight);
        this.Write(372, (object) dimStyle.ExtensionLineWeight);
      }
      this.method_115((DxfHandledObject) dimStyle);
    }

    private void method_108()
    {
      this.Write(Class824.struct18_6);
      this.Write(2, (object) "BLOCK_RECORD");
      this.method_201(this.dxfModel_0.BlockRecordTable);
      this.method_234("AcDbSymbolTable");
      this.Write(70, (object) (short) 3);
      foreach (DxfBlock block in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfModel_0.Blocks)
        this.method_109(block);
      foreach (DxfBlock anonymousBlock in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfModel_0.AnonymousBlocks)
        this.method_109(anonymousBlock);
      this.Write(Class824.struct18_10);
    }

    private void method_109(DxfBlock block)
    {
      this.Write(0, (object) "BLOCK_RECORD");
      this.method_201((DxfHandledObject) block);
      this.method_234("AcDbSymbolTableRecord");
      this.method_234("AcDbBlockTableRecord");
      this.Write(2, (object) this.method_243(block.Name));
      if (this.WriteHandles && this.dxfModel_0.Header.Dxf15OrHigher && block.Layout != null)
        this.method_218(340, (DxfHandledObject) block.Layout);
      if (this.dxfVersion_0 >= DxfVersion.Dxf21)
      {
        this.Write(70, (object) (short) block.BlockUnits);
        this.Write(280, (object) (byte) (block.Explodable ? 1 : 0));
        this.Write(281, (object) (byte) (block.ScaleUniformly ? 1 : 0));
      }
      this.method_115((DxfHandledObject) block);
    }

    private void method_110()
    {
      this.Write(Class824.struct18_0);
      this.Write(Class824.struct18_16);
      foreach (DxfBlock block in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfModel_0.Blocks)
        this.method_111(block);
      foreach (DxfBlock anonymousBlock in (KeyedDxfHandledObjectCollection<string, DxfBlock>) this.dxfModel_0.AnonymousBlocks)
        this.method_111(anonymousBlock);
      this.Write(Class824.struct18_1);
    }

    private void method_111(DxfBlock block)
    {
      DxfBlockBegin blockBegin = block.BlockBegin;
      this.method_114((DxfEntity) blockBegin);
      this.method_234("AcDbBlockBegin");
      this.Write(2, (object) this.method_243(block.Name));
      BlockFlags flags = block.Flags;
      this.Write(70, (object) (short) (!block.method_12() ? (int) (flags & ~BlockFlags.HasNonConstantAttributeDefinitions) : (int) (flags | BlockFlags.HasNonConstantAttributeDefinitions)));
      if (block.IsExternalReferenceUnloaded && this.dxfVersion_0 > DxfVersion.Dxf12)
        this.Write(71, (object) (short) 1);
      this.Write(10, block.BasePoint);
      this.Write(3, (object) this.method_243(block.Name));
      if (block.ExternalReference != null)
        this.Write(1, (object) block.ExternalReference);
      if (block.Description != null)
        this.Write(4, (object) block.Description);
      this.method_115((DxfHandledObject) blockBegin);
      DxfLayout layout = block.Layout;
      Class919 class919 = new Class919(this.dxfVersion_0);
      if (layout == null)
      {
        this.method_113(block, false);
        DxfWriter.Class38 class38 = new DxfWriter.Class38(this);
        foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) block.Entities)
        {
          entity.Accept((IEntityVisitor) class919);
          if (class919.Supported)
            entity.Accept((IEntityVisitor) class38);
        }
      }
      else if (layout != this.dxfModel_0.ModelLayout && string.Compare(block.Name, "*Paper_Space", StringComparison.InvariantCultureIgnoreCase) != 0)
      {
        this.method_113(block, true);
        DxfWriter.Class38 class38 = new DxfWriter.Class38(this);
        foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) layout.Entities)
        {
          entity.Accept((IEntityVisitor) class919);
          if (class919.Supported)
            entity.Accept((IEntityVisitor) class38);
        }
        bool dxf15OrHigher = this.dxfModel_0.Header.Dxf15OrHigher;
        foreach (DxfViewport viewport in (DxfHandledObjectCollection<DxfViewport>) layout.Viewports)
        {
          if (dxf15OrHigher)
            this.method_176(viewport);
          else
            this.method_175(viewport);
        }
      }
      this.Write(0, (object) "ENDBLK");
      this.method_201((DxfHandledObject) block.BlockEnd);
      this.method_234("AcDbEntity");
      this.Write(8, (object) this.dxfModel_0.ZeroLayer.Name);
      this.method_234("AcDbBlockEnd");
      this.method_113((DxfBlock) null, false);
    }

    private void method_112()
    {
      this.Write(Class824.struct18_0);
      this.Write(Class824.struct18_20);
      this.method_113(this.dxfModel_0.ModelSpaceBlock, false);
      DxfWriter.Class38 class38_1 = new DxfWriter.Class38(this);
      Class919 class919 = new Class919(this.dxfVersion_0);
      foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) this.dxfModel_0.Entities)
      {
        entity.Accept((IEntityVisitor) class919);
        if (class919.Supported)
          entity.Accept((IEntityVisitor) class38_1);
      }
      DxfBlock block = (DxfBlock) null;
      if (this.dxfModel_0.AnonymousBlocks.TryGetValue("*Paper_Space", out block))
      {
        this.method_113(block, true);
        DxfLayout layout = block.Layout;
        if (layout != null)
        {
          DxfWriter.Class38 class38_2 = new DxfWriter.Class38(this);
          foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) layout.Entities)
          {
            entity.Accept((IEntityVisitor) class919);
            if (class919.Supported)
              entity.Accept((IEntityVisitor) class38_2);
          }
          foreach (DxfViewport viewport in (DxfHandledObjectCollection<DxfViewport>) layout.Viewports)
          {
            if (viewport.Model.Header.Dxf15OrHigher)
              this.method_176(viewport);
            else
              this.method_175(viewport);
          }
        }
      }
      this.Write(Class824.struct18_1);
      this.method_113((DxfBlock) null, false);
    }

    private void method_113(DxfBlock block, bool paperSpace)
    {
      this.dxfBlock_0 = block;
      this.bool_1 = paperSpace;
    }

    internal void method_114(DxfEntity entity)
    {
      this.Write(0, (object) entity.EntityType);
      this.method_201((DxfHandledObject) entity);
      this.method_234("AcDbEntity");
      this.Write(8, (object) this.dxfModel_0.GetLayer(entity).Name);
      if (entity.LineType != null && entity.LineType != this.dxfModel_0.ByLayerLineType)
        this.Write(6, (object) entity.LineType.Name);
      this.method_228(62, entity.Color);
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
      {
        if (entity.DxfColor != null)
          this.Write(430, (object) entity.DxfColor.Color.method_0());
        if (entity.Transparency != Transparency.ByLayer)
          this.Write(440, (object) (int) entity.Transparency.Data);
      }
      if (entity.LineTypeScale != 1.0)
        this.Write(48, (object) entity.LineTypeScale);
      if (!entity.Visible)
        this.Write(60, (object) (short) 1);
      if (entity.vmethod_13(this.bool_1))
        this.Write(67, (object) (short) 1);
      if (this.dxfVersion_0 < DxfVersion.Dxf15 || entity.LineWeight == (short) -1)
        return;
      this.Write(370, (object) entity.LineWeight);
    }

    private void method_115(DxfHandledObject value)
    {
      if (this.dxfVersion_0 <= DxfVersion.Dxf12)
        return;
      this.method_116(value);
    }

    private void method_116(DxfHandledObject obj)
    {
      if (!obj.HasExtendedData)
        return;
      foreach (DxfExtendedData extendedData in (Collection<DxfExtendedData>) obj.ExtendedDataCollection)
        this.method_117(extendedData);
    }

    private void method_117(DxfExtendedData data)
    {
      this.Write(1001, (object) data.AppId.Name);
      foreach (IExtendedDataValue extendedDataValue in (List<IExtendedDataValue>) data.Values)
        extendedDataValue.Accept((IExtendedDataValueVisitor) this.class39_0);
    }

    private void method_118(DxfArc arc)
    {
      this.method_119((DxfCircle) arc);
      this.method_234("AcDbArc");
      this.Write(50, (object) (arc.StartAngle * (180.0 / System.Math.PI)));
      this.Write(51, (object) (arc.EndAngle * (180.0 / System.Math.PI)));
    }

    private void method_119(DxfCircle circle)
    {
      this.method_114((DxfEntity) circle);
      this.method_234("AcDbCircle");
      this.Write(10, circle.Center);
      if (circle.Thickness != 0.0)
        this.Write(39, (object) circle.Thickness);
      this.Write(40, (object) circle.Radius);
      this.method_225(circle.ZAxis);
    }

    private void method_120(DxfDimension dim, short dimType, WW.Math.Point3D definitionPoint)
    {
      this.method_114((DxfEntity) dim);
      this.method_234("AcDbDimension");
      if (dim.Block != null)
        this.Write(2, (object) this.method_243(dim.Block.Name));
      this.Write(10, definitionPoint);
      this.Write(11, dim.TextMiddlePoint);
      this.Write(12, DxfUtil.GetToWCSTransform(dim.ZAxis).Transform(dim.InsertionPoint));
      if (dim.UseTextMiddlePoint)
        dimType = (short) ((int) (ushort) dimType | 128);
      this.Write(70, (object) dimType);
      if (this.dxfModel_0.Header.Dxf15OrHigher)
      {
        this.Write(71, (object) (short) dim.AttachmentPoint);
        this.Write(72, (object) (short) dim.LineSpacingStyle);
        if (dim.LineSpacingFactor != 1.0)
          this.Write(41, (object) dim.LineSpacingFactor);
        if (dim.Measurement != 0.0)
          this.Write(42, (object) dim.Measurement);
      }
      if (dim.Text != null)
        this.Write(1, (object) dim.Text);
      if (dim.HasTextRotation)
        this.Write(53, (object) (dim.TextRotation * (180.0 / System.Math.PI)));
      if (dim.HasHorizontalDirection)
        this.Write(51, (object) (dim.HorizontalDirection * (180.0 / System.Math.PI)));
      if (dim.InsertionRotation != 0.0)
        this.Write(54, (object) (dim.InsertionRotation * (180.0 / System.Math.PI)));
      this.method_225(dim.ZAxis);
      if (dim.DimensionStyleOverrides == null || dim.DimensionStyle == null)
        return;
      this.Write(3, (object) dim.DimensionStyle.Name);
    }

    private void method_121(DxfDimension.Aligned dim, Enum25 dimensionType)
    {
      this.method_120((DxfDimension) dim, (short) dimensionType, dim.DimensionLineLocation);
      this.method_234("AcDbAlignedDimension");
      this.Write(13, dim.ExtensionLine1StartPoint);
      this.Write(14, dim.ExtensionLine2StartPoint);
    }

    private void method_122(DxfDimension.Linear dim)
    {
      this.method_121((DxfDimension.Aligned) dim, Enum25.const_0);
      this.Write(50, (object) (dim.Rotation * (180.0 / System.Math.PI)));
      this.method_234("AcDbRotatedDimension");
    }

    private void method_123(DxfDimension.Diametric dim)
    {
      this.method_120((DxfDimension) dim, (short) 3, dim.ArcLineIntersectionPoint2);
      this.method_234("AcDbDiametricDimension");
      this.Write(15, dim.ArcLineIntersectionPoint1);
      this.Write(40, (object) dim.LeaderLength);
    }

    private void method_124(DxfDimension.Radial dim)
    {
      this.method_120((DxfDimension) dim, (short) 4, dim.Center);
      this.method_234("AcDbRadialDimension");
      this.Write(15, dim.ArcLineIntersectionPoint);
      this.Write(40, (object) dim.LeaderLength);
    }

    private void method_125(DxfDimension.Angular3Point dim)
    {
      this.method_120((DxfDimension) dim, (short) 5, dim.DimensionLineArcPoint);
      this.method_234("AcDb3PointAngularDimension");
      this.Write(13, dim.ExtensionLine1StartPoint);
      this.Write(14, dim.ExtensionLine2StartPoint);
      this.Write(15, dim.AngleVertex);
    }

    private void method_126(DxfDimension.Angular4Point dim)
    {
      this.method_120((DxfDimension) dim, (short) 2, dim.ExtensionLine2EndPoint);
      this.method_234("AcDb2LineAngularDimension");
      this.Write(13, dim.ExtensionLine1StartPoint);
      this.Write(14, dim.ExtensionLine1EndPoint);
      this.Write(15, dim.ExtensionLine2StartPoint);
      this.Write(16, dim.DimensionLineArcPoint);
    }

    private void method_127(DxfDimension.Ordinate dim)
    {
      this.method_120((DxfDimension) dim, (short) (6 | (dim.ShowX ? 100 : 0)), dim.UcsOrigin);
      this.method_234("AcDbOrdinateDimension");
      this.Write(13, dim.FeaturePosition);
      this.Write(14, dim.LeaderEndPoint);
    }

    private void method_128(DxfEllipse ellipse)
    {
      if (!this.dxfModel_0.Header.Dxf13OrHigher)
      {
        this.method_242(ellipse.EntityType);
      }
      else
      {
        this.method_114((DxfEntity) ellipse);
        this.method_234("AcDbEllipse");
        this.Write(10, ellipse.Center);
        this.Write(11, ellipse.MajorAxisEndPoint);
        this.method_225(ellipse.ZAxis);
        this.Write(40, (object) ellipse.MinorToMajorRatio);
        this.Write(41, (object) ellipse.StartParameter);
        this.Write(42, (object) ellipse.EndParameter);
      }
    }

    private void method_129(Dxf3DFace face)
    {
      this.method_114((DxfEntity) face);
      this.method_234("AcDbFace");
      IList<WW.Math.Point3D> points = (IList<WW.Math.Point3D>) face.Points;
      for (int index = 0; index < points.Count; ++index)
        this.Write(10 + index, points[index]);
      if (points.Count == 3)
        this.Write(13, points[0]);
      this.Write(70, (object) (short) face.method_13());
    }

    private void method_130(DxfImage image)
    {
      if (!this.dxfModel_0.Header.Dxf14OrHigher)
        return;
      this.method_114((DxfEntity) image);
      this.method_234(image.AcClass);
      this.Write(90, (object) image.ClassVersion);
      this.Write(10, image.InsertionPoint);
      this.Write(11, image.XAxis);
      this.Write(12, image.YAxis);
      this.Write(13, image.Size);
      this.method_218(340, (DxfHandledObject) image.ImageDef);
      this.Write(70, (object) (short) image.ImageDisplayFlags);
      this.method_222(280, image.ClippingEnabled);
      this.Write(281, (object) image.Brightness);
      this.Write(282, (object) image.Contrast);
      this.Write(283, (object) image.Fade);
      if (this.dxfModel_0.Header.AcadVersion > DxfVersion.Dxf21)
        this.Write(290, (object) (image.ClipMode != ClipMode.Outside));
      this.Write(71, (object) (short) (image.BoundaryVertices.Count > 2 ? 2 : 1));
      this.Write(91, (object) image.BoundaryVertices.Count);
      foreach (WW.Math.Point2D boundaryVertex in image.BoundaryVertices)
        this.Write(14, boundaryVertex);
    }

    private void method_131(DxfWipeout image)
    {
      if (!this.dxfModel_0.Header.Dxf15OrHigher)
        return;
      this.method_114((DxfEntity) image);
      this.method_234(image.AcClass);
      this.Write(90, (object) image.ClassVersion);
      this.Write(10, image.InsertionPoint);
      this.Write(11, image.XAxis);
      this.Write(12, image.YAxis);
      this.Write(13, image.Size);
      this.method_218(340, (DxfHandledObject) image.ImageDef);
      this.Write(70, (object) (short) image.ImageDisplayFlags);
      this.method_222(280, image.ClippingEnabled);
      this.Write(281, (object) image.Brightness);
      this.Write(282, (object) image.Contrast);
      this.Write(283, (object) image.Fade);
      if (this.dxfModel_0.Header.AcadVersion > DxfVersion.Dxf21)
        this.Write(290, (object) (image.ClipMode != ClipMode.Outside));
      this.Write(71, (object) (short) (image.BoundaryVertices.Count > 2 ? 2 : 1));
      int count = image.BoundaryVertices.Count;
      bool flag = false;
      if (count > 1 && image.BoundaryVertices[0] != image.BoundaryVertices[image.BoundaryVertices.Count - 1])
      {
        flag = true;
        ++count;
      }
      this.Write(91, (object) count);
      foreach (WW.Math.Point2D boundaryVertex in image.BoundaryVertices)
        this.Write(14, boundaryVertex);
      if (!flag)
        return;
      this.Write(14, image.BoundaryVertices[0]);
    }

    private void method_132(DxfInsert insert)
    {
      this.method_114((DxfEntity) insert);
      if (this.dxfModel_0.Header.Dxf13OrHigher)
      {
        if (insert.RowCount <= (ushort) 1 && insert.ColumnCount <= (ushort) 1)
          this.method_234("AcDbBlockReference");
        else
          this.method_234("AcDbMInsertBlock");
      }
      if (insert.Attributes.Count > 0)
        this.Write(66, (object) (short) 1);
      if (insert.Block != null)
        this.Write(2, (object) this.method_243(insert.Block.Name));
      else
        this.Write(2, (object) string.Empty);
      this.Write(10, insert.InsertionPoint);
      this.Write(41, (object) insert.ScaleFactor.X);
      this.Write(42, (object) insert.ScaleFactor.Y);
      this.Write(43, (object) insert.ScaleFactor.Z);
      this.Write(50, (object) (insert.Rotation * (180.0 / System.Math.PI)));
      if (insert.ColumnCount != (ushort) 1)
        this.Write(70, (object) (short) insert.ColumnCount);
      if (insert.RowCount != (ushort) 1)
        this.Write(71, (object) (short) insert.RowCount);
      if (insert.ColumnSpacing != 0.0)
        this.Write(44, (object) insert.ColumnSpacing);
      if (insert.RowSpacing != 0.0)
        this.Write(45, (object) insert.RowSpacing);
      this.method_225(insert.ZAxis);
      this.method_116((DxfHandledObject) insert);
      if (insert.Attributes.Count <= 0)
        return;
      foreach (DxfAttribute attribute in (IEnumerable<DxfAttribute>) insert.Attributes)
        this.method_173(attribute);
      this.method_166((DxfHandledObject) insert.AttributesSeqEnd);
    }

    private void method_133(DxfLeader leader)
    {
      if (!this.dxfModel_0.Header.Dxf13OrHigher)
      {
        this.method_242(leader.EntityType);
      }
      else
      {
        this.method_114((DxfEntity) leader);
        this.method_234("AcDbLeader");
        if (leader.DimensionStyleOverrides != null && leader.DimensionStyle != null)
          this.Write(3, (object) leader.DimensionStyle.Name);
        this.Write(71, (object) (short) (leader.ArrowHeadEnabled ? 1 : 0));
        this.Write(72, (object) (short) leader.PathType);
        this.Write(73, (object) (short) leader.CreationType);
        this.Write(74, (object) (short) leader.HookLineDirection);
        this.Write(75, (object) (short) (leader.HasHookLine ? 1 : 0));
        this.Write(40, (object) leader.TextAnnotationHeight);
        this.Write(41, (object) leader.TextAnnotationWidth);
        int count = leader.Vertices.Count;
        if (leader.HasHookLine)
          ++count;
        this.Write(76, (object) (short) count);
        foreach (WW.Math.Point3D vertex in leader.Vertices)
          this.Write(10, (WW.Math.Vector3D) vertex);
        this.method_230(77, leader.ByBlockColor);
        if (leader.AssociatedAnnotation != null)
          this.method_218(340, (DxfHandledObject) leader.AssociatedAnnotation);
        this.method_225(leader.ZAxis);
        this.Write(211, leader.HorizontalDirection);
        this.Write(212, leader.LastVertexOffsetFromBlock);
        if (!this.dxfModel_0.Header.Dxf14OrHigher)
          return;
        this.Write(213, leader.LastVertexOffsetFromAnnotation);
      }
    }

    private void method_134(DxfLine line)
    {
      this.method_114((DxfEntity) line);
      this.method_234("AcDbLine");
      this.Write(10, line.Start);
      this.Write(11, line.End);
      if (line.Thickness != 0.0)
        this.Write(39, (object) line.Thickness);
      this.method_225(line.ZAxis);
    }

    private void method_135(DxfRay ray)
    {
      if (!this.dxfModel_0.Header.Dxf13OrHigher)
      {
        this.method_242(ray.EntityType);
      }
      else
      {
        this.method_114((DxfEntity) ray);
        this.method_234("AcDbRay");
        this.Write(10, ray.StartPoint);
        this.Write(11, ray.Direction);
      }
    }

    private void method_136(Dxf3DSolid solid)
    {
      if (!this.dxfModel_0.Header.Dxf13OrHigher)
      {
        this.method_242(solid.EntityType);
      }
      else
      {
        this.method_114((DxfEntity) solid);
        this.method_137((DxfModelerGeometry) solid);
        if (this.dxfVersion_0 <= DxfVersion.Dxf18)
          return;
        this.method_234("AcDb3dSolid");
        this.Write(350, (object) solid.HistoryId);
      }
    }

    private void method_137(DxfModelerGeometry modelerGeometry)
    {
      this.method_234("AcDbModelerGeometry");
      if (this.dxfVersion_0 > DxfVersion.Dxf24)
      {
        this.Write(290, (object) (modelerGeometry.Guid != Guid.Empty));
        this.Write(2, (object) modelerGeometry.Guid.ToString("B"));
      }
      else
      {
        this.Write(70, (object) (short) modelerGeometry.AcisFormatIntegrationVersion);
        if (modelerGeometry.IsSab)
        {
          foreach (string streamFromSabTextLine in modelerGeometry.EncriptedSatStreamFromSabTextLines)
            this.method_140(streamFromSabTextLine);
        }
        else
        {
          foreach (string encryptedSatTextLine in modelerGeometry.EncryptedSatTextLines)
            this.method_140(encryptedSatTextLine);
        }
      }
    }

    private void method_138(DxfRegion region)
    {
      if (!this.dxfModel_0.Header.Dxf13OrHigher)
      {
        this.method_242(region.EntityType);
      }
      else
      {
        this.method_114((DxfEntity) region);
        this.method_137((DxfModelerGeometry) region);
      }
    }

    private void method_139(DxfBody body)
    {
      if (!this.dxfModel_0.Header.Dxf13OrHigher)
      {
        this.method_242(body.EntityType);
      }
      else
      {
        this.method_114((DxfEntity) body);
        this.method_234("AcDbModelerGeometry");
        this.Write(70, (object) (short) body.AcisFormatIntegrationVersion);
        if (body.IsSab)
        {
          foreach (string streamFromSabTextLine in body.EncriptedSatStreamFromSabTextLines)
            this.method_140(streamFromSabTextLine);
        }
        else
        {
          foreach (string encryptedSatTextLine in body.EncryptedSatTextLines)
            this.method_140(encryptedSatTextLine);
        }
      }
    }

    internal void method_140(string text)
    {
      this.method_141(1, 3, text);
    }

    internal void method_141(int baseGroup, int extGroup, string text)
    {
      this.method_143(baseGroup, extGroup, 250, text);
    }

    internal void method_142(int baseGroup, int extGroup, string text, bool allowWordBreaks)
    {
      this.method_144(baseGroup, extGroup, 250, text, allowWordBreaks);
    }

    internal void method_143(int baseGroup, int extGroup, int maxChunkSize, string text)
    {
      this.method_144(baseGroup, extGroup, maxChunkSize, text, false);
    }

    internal void method_144(
      int baseGroup,
      int extGroup,
      int maxChunkSize,
      string text,
      bool allowWordBreaks)
    {
      if (string.IsNullOrEmpty(text))
      {
        this.Write(baseGroup, (object) string.Empty);
      }
      else
      {
        int startIndex = 0;
        int length1;
        for (int length2 = text.Length; length2 - startIndex > maxChunkSize; startIndex += length1)
        {
          length1 = maxChunkSize;
          string str = text.Substring(startIndex, length1);
          while (startIndex + length1 < length2 && text[startIndex + length1] == ' ')
          {
            ++length1;
            str = text.Substring(startIndex, length1);
          }
          if (!allowWordBreaks && startIndex + length1 < length2 && (text[startIndex + length1] != ' ' && text[startIndex + length1 - 1] != ' '))
          {
            for (int index = length1 - 1; index > 0; --index)
            {
              if (text[startIndex + index] == ' ')
              {
                length1 = index + 1;
                str = text.Substring(startIndex, length1);
                break;
              }
            }
          }
          this.Write(extGroup, (object) str);
        }
        this.Write(baseGroup, (object) text.Substring(startIndex));
      }
    }

    internal void method_145(int groupCode, Stream stream, int size)
    {
      int num = size / 64;
      long position = stream.Position;
      byte[] buffer1 = new byte[64];
      for (int index = 0; index < num; ++index)
      {
        stream.Read(buffer1, 0, 64);
        this.Write(groupCode, (object) buffer1);
      }
      int count = size % 64;
      if (count != 0)
      {
        byte[] buffer2 = new byte[count];
        stream.Read(buffer2, 0, count);
        this.Write(groupCode, (object) buffer2);
      }
      stream.Position = position;
    }

    private void method_146(DxfXLine xline)
    {
      if (!this.dxfModel_0.Header.Dxf13OrHigher)
      {
        this.method_242(xline.EntityType);
      }
      else
      {
        this.method_114((DxfEntity) xline);
        this.method_234("AcDbXline");
        this.Write(10, xline.StartPoint);
        this.Write(11, xline.Direction);
      }
    }

    private void method_147(DxfOle ole)
    {
      if (!this.dxfModel_0.Header.Dxf14OrHigher)
      {
        this.method_242(ole.EntityType);
      }
      else
      {
        this.method_114((DxfEntity) ole);
        this.method_234("AcDbOle2Frame");
        this.Write(70, (object) (short) ole.OleDataVersion);
        this.Write(3, (object) ole.UserType);
        this.Write(10, ole.UpperLeft);
        this.Write(11, ole.LowerRight);
        this.Write(71, (object) (short) ole.OleObjectType);
        bool flag = false;
        if (ole.OwnerObjectSoftReference != null)
          flag = (long) ole.OwnerObjectSoftReference.Handle == (long) ole.Model.ModelSpaceBlock.Handle;
        this.Write(72, (object) (short) (flag ? 0 : 1));
        if (this.dxfModel_0.Header.AcadVersion > DxfVersion.Dxf14)
          this.Write(73, (object) (short) ole.Quality);
        MemoryStream memoryStream = new MemoryStream();
        Encoding encoding = Encodings.GetEncoding((int) this.dxfModel_0.Header.DrawingCodePage);
        Class432.smethod_0(Class724.Create(this.dxfModel_0.Header.AcadVersion, (Stream) memoryStream, encoding), ole);
        this.Write(90, (object) (int) memoryStream.Length);
        memoryStream.Position = 0L;
        this.method_145(310, (Stream) memoryStream, (int) memoryStream.Length);
        this.Write(1, (object) "OLE");
      }
    }

    private void method_148(DxfMLine mline)
    {
      if (!this.dxfModel_0.Header.Dxf13OrHigher)
      {
        this.method_242(mline.EntityType);
      }
      else
      {
        this.method_114((DxfEntity) mline);
        this.method_234("AcDbMline");
        this.Write(2, (object) mline.Style.Name);
        this.method_218(340, (DxfHandledObject) mline.Style);
        this.Write(40, (object) mline.ScaleFactor);
        this.Write(70, (object) (short) mline.Alignment);
        this.Write(71, (object) (short) mline.Flags);
        this.Write(72, (object) (short) mline.Segments.Count);
        this.Write(73, (object) (short) mline.Style.Elements.Count);
        this.Write(10, mline.StartPoint);
        this.method_225(mline.ZAxis);
        foreach (DxfMLine.Segment segment in mline.Segments)
        {
          this.Write(11, segment.Position);
          this.Write(12, segment.Direction);
          this.Write(13, segment.MiterDirection);
          for (int index = 0; index < mline.Style.Elements.Count; ++index)
          {
            if (index >= segment.Elements.Count)
            {
              this.Write(74, (object) (short) 0);
              this.Write(75, (object) (short) 0);
            }
            else
            {
              DxfMLine.Segment.Element element = segment.Elements[index];
              this.Write(74, (object) (short) element.Parameters.Count);
              foreach (double parameter in element.Parameters)
                this.Write(41, (object) parameter);
              this.Write(75, (object) (short) element.AreaFillParameters.Count);
              foreach (double areaFillParameter in element.AreaFillParameters)
                this.Write(42, (object) areaFillParameter);
            }
          }
        }
      }
    }

    private void method_149(DxfTable table)
    {
      Class551 table2005 = table.Table2005;
      if (!DxfTable.smethod_2(this.dxfModel_0))
        return;
      this.method_114((DxfEntity) table);
      this.method_234("AcDbBlockReference");
      if (table.Block != null)
        this.Write(2, (object) this.method_243(table.Block.Name));
      this.Write(10, table.InsertionPoint);
      this.method_234("AcDbTable");
      this.method_218(342, (DxfHandledObject) table.TableStyle);
      if (table.Block != null)
        this.method_218(343, (DxfHandledObject) table.Block);
      this.Write(11, table2005.HorizontalDirection);
      this.Write(90, (object) table2005.TableFlags);
      this.Write(91, (object) table2005.RowCount);
      this.Write(92, (object) table2005.ColumnCount);
      this.Write(93, (object) 0);
      this.Write(94, (object) 0);
      this.Write(95, (object) 0);
      this.Write(96, (object) 0);
      if (table2005.FlowDirection.HasValue)
        this.Write(70, (object) (short) table2005.FlowDirection.Value);
      if (table2005.HorizontalCellMargin.HasValue)
        this.Write(40, (object) table2005.HorizontalCellMargin.Value);
      if (table2005.VerticalCellMargin.HasValue)
        this.Write(41, (object) table2005.VerticalCellMargin.Value);
      if (table2005.SuppressTitle.HasValue)
        this.method_222(280, table2005.SuppressTitle.Value);
      if (table2005.SuppressHeaderRow.HasValue)
        this.method_222(281, table2005.SuppressHeaderRow.Value);
      foreach (Class430 row in (ActiveList<Class430>) table2005.Rows)
        this.Write(141, (object) row.Height);
      foreach (Class736 column in (ActiveList<Class736>) table2005.Columns)
        this.Write(142, (object) column.Width);
      int rowIndex = 0;
      foreach (Class430 row in (ActiveList<Class430>) table2005.Rows)
      {
        int columnIndex = 0;
        foreach (Class1026 cell in (ActiveList<Class1026>) row.Cells)
        {
          this.method_150(table2005, rowIndex, columnIndex, cell);
          ++columnIndex;
        }
        ++rowIndex;
      }
    }

    private void method_150(Class551 table, int rowIndex, int columnIndex, Class1026 cell)
    {
      this.Write(171, (object) (short) cell.CellType);
      this.Write(172, (object) (short) 0);
      bool isCellMerged = cell.MergedCellCountHorizontal == 1 && cell.MergedCellCountVertical == 1 && table.method_2(rowIndex, columnIndex);
      this.method_221(173, isCellMerged);
      this.method_221(174, cell.AutoFit);
      this.Write(175, (object) (short) cell.MergedCellCountHorizontal);
      this.Write(176, (object) (short) cell.MergedCellCountVertical);
      uint num = DxfWriter.smethod_1(cell);
      if (this.dxfVersion_0 > DxfVersion.Dxf18)
        this.Write(91, (object) (int) num);
      else
        this.Write(177, (object) (short) (ushort) (num & (uint) ushort.MaxValue));
      this.method_219(178, (short) 0);
      this.Write(145, (object) cell.Rotation);
      DxfValue dxfValue = cell.Value;
      DxfTableCellStyle cellStyle = table.GetCellStyle(rowIndex, columnIndex);
      string valueString = dxfValue.GetValueString(cellStyle.ValueFormat);
      if (cell.CellType == Enum47.const_1)
      {
        if (cell.BlockOrField != null)
          this.method_218(344, cell.BlockOrField);
        if (this.dxfVersion_0 <= DxfVersion.Dxf18)
          this.method_141(1, 2, valueString);
      }
      else if (cell.CellType == Enum47.const_2)
      {
        if (cell.BlockOrField != null)
        {
          this.method_218(340, cell.BlockOrField);
          this.Write(144, (object) cell.BlockScale);
        }
        if (cell.HasAttributes)
          this.Write(179, (object) (short) cell.Attributes.Count);
        else
          this.Write(179, (object) (short) 0);
        foreach (DxfTableAttribute attribute in (List<DxfTableAttribute>) cell.Attributes)
        {
          this.method_218(331, (DxfHandledObject) attribute.AttributeDefinition);
          this.Write(300, (object) attribute.Value);
        }
      }
      if (cell.TextStyle != null)
        this.Write(7, (object) cell.TextStyle.Name);
      if (cell.TextHeight.HasValue)
        this.Write(140, (object) cell.TextHeight.Value);
      if (cell.CellAlignment.HasValue)
        this.Write(170, (object) (short) cell.CellAlignment.Value);
      if (cell.ContentColor.HasValue)
        this.method_230(64, cell.ContentColor.Value);
      if (cell.BackColor.HasValue)
        this.method_230(63, cell.BackColor.Value);
      if (cell.BorderTop.Color.HasValue)
        this.method_230(69, cell.BorderTop.Color.Value);
      if (cell.BorderRight.Color.HasValue)
        this.method_230(65, cell.BorderRight.Color.Value);
      if (cell.BorderBottom.Color.HasValue)
        this.method_230(66, cell.BorderBottom.Color.Value);
      if (cell.BorderLeft.Color.HasValue)
        this.method_230(68, cell.BorderLeft.Color.Value);
      if (cell.BorderTop.LineWeight.HasValue)
        this.Write(279, (object) cell.BorderTop.LineWeight.Value);
      if (cell.BorderRight.LineWeight.HasValue)
        this.Write(275, (object) cell.BorderRight.LineWeight.Value);
      if (cell.BorderBottom.LineWeight.HasValue)
        this.Write(276, (object) cell.BorderBottom.LineWeight.Value);
      if (cell.BorderLeft.LineWeight.HasValue)
        this.Write(278, (object) cell.BorderLeft.LineWeight.Value);
      if (cell.IsBackColorEnabled.HasValue)
        this.method_222(283, !cell.IsBackColorEnabled.Value);
      if (cell.BorderTop.Visible.HasValue)
        this.method_222(289, cell.BorderTop.Visible.Value);
      if (cell.BorderRight.Visible.HasValue)
        this.method_222(285, cell.BorderRight.Visible.Value);
      if (cell.BorderBottom.Visible.HasValue)
        this.method_222(286, cell.BorderBottom.Visible.Value);
      if (cell.BorderLeft.Visible.HasValue)
        this.method_222(288, cell.BorderLeft.Visible.Value);
      if (this.dxfVersion_0 <= DxfVersion.Dxf18)
        return;
      this.Write(92, (object) 0);
      this.Write(301, (object) "CELL_VALUE");
      bool cellHasValue = cell.method_4(isCellMerged);
      this.Write(93, (object) cell.method_5(cellHasValue));
      if (!cellHasValue)
      {
        this.Write(90, (object) 0);
      }
      else
      {
        this.Write(90, (object) (int) dxfValue.Format.DataType);
        switch (dxfValue.Format.DataType)
        {
          case ValueDataType.Int:
            this.Write(91, (object) Convert.ToInt32(dxfValue.Value));
            break;
          case ValueDataType.Double:
            this.Write(140, (object) Convert.ToDouble(dxfValue.Value));
            break;
          case ValueDataType.String:
            this.method_142(1, 2, (string) dxfValue.Value, true);
            break;
          case ValueDataType.Date:
            this.Write(92, (object) 16);
            DateTime dateTime = (DateTime) dxfValue.Value;
            if (this.dxfModel_0.Header.Dxf19OrHigher)
            {
              byte[] bytes = new byte[16];
              DxfValue.smethod_4(bytes, 0, dateTime.Year);
              DxfValue.smethod_4(bytes, 2, dateTime.Month);
              DxfValue.smethod_4(bytes, 4, (int) dateTime.DayOfWeek);
              DxfValue.smethod_4(bytes, 6, dateTime.Day);
              DxfValue.smethod_4(bytes, 8, dateTime.Hour);
              DxfValue.smethod_4(bytes, 10, dateTime.Minute);
              DxfValue.smethod_4(bytes, 12, dateTime.Second);
              DxfValue.smethod_4(bytes, 14, dateTime.Millisecond);
              this.Write(310, (object) bytes);
              break;
            }
            ulong uint64 = Convert.ToUInt64((dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            byte[] numArray = new byte[8];
            for (int index = 7; index >= 0; --index)
            {
              numArray[index] = (byte) (uint64 & (ulong) byte.MaxValue);
              uint64 >>= 8;
            }
            this.Write(310, (object) numArray);
            break;
          case ValueDataType.Point3D:
            this.Write(11, (WW.Math.Point3D) dxfValue.Value);
            break;
          case ValueDataType.General:
            this.method_142(1, 2, (string) dxfValue.Value, true);
            break;
        }
      }
      this.Write(94, (object) (dxfValue != null ? (int) dxfValue.Format.UnitType : 0));
      this.Write(300, dxfValue != null ? (object) dxfValue.Format._FormatString : (object) string.Empty);
      if (cellHasValue)
        this.method_142(302, 303, valueString, true);
      this.Write(304, (object) "ACVALUE_END");
    }

    private static uint smethod_1(Class1026 cell)
    {
      uint num = 0;
      if (cell.CellAlignment.HasValue)
        num |= 1U;
      if (cell.IsBackColorEnabled.HasValue)
        num |= 2U;
      if (cell.BackColor.HasValue)
        num |= 4U;
      if (cell.ContentColor.HasValue)
        num |= 8U;
      if (cell.TextHeight.HasValue)
        num |= 32U;
      if (cell.BorderTop.Color.HasValue)
        num |= 64U;
      if (cell.BorderTop.LineWeight.HasValue)
        num |= 1024U;
      if (cell.BorderTop.Visible.HasValue)
        num |= 16384U;
      if (cell.BorderRight.Color.HasValue)
        num |= 128U;
      if (cell.BorderRight.LineWeight.HasValue)
        num |= 2048U;
      if (cell.BorderRight.Visible.HasValue)
        num |= 32768U;
      if (cell.BorderBottom.Color.HasValue)
        num |= 256U;
      if (cell.BorderBottom.LineWeight.HasValue)
        num |= 4096U;
      if (cell.BorderBottom.Visible.HasValue)
        num |= 65536U;
      if (cell.BorderLeft.Color.HasValue)
        num |= 512U;
      if (cell.BorderLeft.LineWeight.HasValue)
        num |= 8192U;
      if (cell.BorderLeft.Visible.HasValue)
        num |= 131072U;
      return num;
    }

    private void method_151(DxfPoint p)
    {
      this.method_114((DxfEntity) p);
      this.method_234("AcDbPoint");
      this.Write(10, p.Position);
      if (p.Thickness != 0.0)
        this.Write(39, (object) p.Thickness);
      this.method_225(p.ZAxis);
      if (this.dxfVersion_0 < DxfVersion.Dxf13)
        return;
      this.Write(50, (object) (p.XAxisAngle * (180.0 / System.Math.PI)));
    }

    private void method_152(DxfLwPolyline polyline)
    {
      if (!this.dxfModel_0.Header.Dxf13OrHigher)
      {
        this.method_242(polyline.EntityType);
      }
      else
      {
        this.method_114((DxfEntity) polyline);
        this.method_234("AcDbPolyline");
        if (polyline.Thickness != 0.0)
          this.Write(39, (object) polyline.Thickness);
        if (polyline.ConstantWidth != 0.0)
          this.Write(43, (object) polyline.ConstantWidth);
        this.Write(90, (object) polyline.Vertices.Count);
        this.Write(70, (object) (short) polyline.Flags);
        if (polyline.Elevation != 0.0)
          this.Write(38, (object) polyline.Elevation);
        bool writeWidths = false;
        foreach (DxfLwPolyline.Vertex vertex in (List<DxfLwPolyline.Vertex>) polyline.Vertices)
        {
          if (vertex.StartWidth != 0.0 || vertex.EndWidth != 0.0)
            writeWidths = true;
        }
        foreach (DxfLwPolyline.Vertex vertex in (List<DxfLwPolyline.Vertex>) polyline.Vertices)
          this.method_153(vertex, writeWidths);
        this.method_225(polyline.ZAxis);
      }
    }

    private void method_153(DxfLwPolyline.Vertex v, bool writeWidths)
    {
      this.Write(10, v.Position);
      if (writeWidths)
      {
        this.Write(40, (object) v.StartWidth);
        this.Write(41, (object) v.EndWidth);
      }
      if (v.Bulge == 0.0)
        return;
      this.Write(42, (object) v.Bulge);
    }

    private void method_154(DxfPolyline3D polyline)
    {
      this.method_114((DxfEntity) polyline);
      this.method_234("AcDb3dPolyline");
      this.Write(66, (object) (short) 1);
      this.Write(70, (object) (short) (Enum21.flag_4 | polyline.Flags));
      this.method_116((DxfHandledObject) polyline);
      foreach (DxfVertex3D vertex in (DxfHandledObjectCollection<DxfVertex3D>) polyline.Vertices)
        this.method_162(vertex, Enum51.flag_6);
      this.method_166((DxfHandledObject) polyline.SeqEnd);
    }

    private void method_155(DxfPolyline3DSpline polyline)
    {
      this.method_114((DxfEntity) polyline);
      this.method_234("AcDb3dPolyline");
      this.Write(66, (object) (short) 1);
      this.Write(70, (object) (short) (Enum21.flag_3 | Enum21.flag_4 | polyline.Flags));
      if (polyline.SplineType != SplineType.None)
        this.Write(75, (object) (short) polyline.SplineType);
      this.method_116((DxfHandledObject) polyline);
      if (polyline.ControlPoints.Count > 0)
        this.method_162(polyline.ControlPoints[0], Enum51.flag_5 | Enum51.flag_6);
      foreach (DxfVertex3D approximationPoint in (DxfHandledObjectCollection<DxfVertex3D>) polyline.ApproximationPoints)
        this.method_162(approximationPoint, Enum51.flag_4 | Enum51.flag_6);
      for (int index = 1; index < polyline.ControlPoints.Count; ++index)
        this.method_162(polyline.ControlPoints[index], Enum51.flag_5 | Enum51.flag_6);
      this.method_166((DxfHandledObject) polyline.SeqEnd);
    }

    private void method_156(DxfPolyline2D polyline)
    {
      this.method_114((DxfEntity) polyline);
      this.method_234("AcDb2dPolyline");
      this.Write(66, (object) (short) 1);
      this.Write(70, (object) (short) polyline.Flags);
      if (polyline.Thickness != 0.0)
        this.Write(39, (object) polyline.Thickness);
      this.Write(10, new WW.Math.Vector3D(0.0, 0.0, polyline.Elevation));
      if (polyline.DefaultStartWidth != 0.0)
        this.Write(40, (object) polyline.DefaultStartWidth);
      if (polyline.DefaultEndWidth != 0.0)
        this.Write(41, (object) polyline.DefaultEndWidth);
      this.method_225(polyline.ZAxis);
      this.method_116((DxfHandledObject) polyline);
      foreach (DxfVertex2D vertex in (DxfHandledObjectCollection<DxfVertex2D>) polyline.Vertices)
        this.method_161(vertex, vertex.Flags);
      this.method_166((DxfHandledObject) polyline.SeqEnd);
    }

    private void method_157(DxfPolyline2DSpline polyline)
    {
      this.method_114((DxfEntity) polyline);
      this.method_234("AcDb2dPolyline");
      this.Write(66, (object) (short) 1);
      this.Write(70, (object) (short) (Enum21.flag_3 | polyline.Flags));
      if (polyline.SplineType != SplineType.None)
        this.Write(75, (object) (short) polyline.SplineType);
      if (polyline.Thickness != 0.0)
        this.Write(39, (object) polyline.Thickness);
      this.Write(10, new WW.Math.Vector3D(0.0, 0.0, polyline.Elevation));
      if (polyline.DefaultStartWidth != 0.0)
        this.Write(40, (object) polyline.DefaultStartWidth);
      if (polyline.DefaultEndWidth != 0.0)
        this.Write(41, (object) polyline.DefaultEndWidth);
      this.method_225(polyline.ZAxis);
      this.method_116((DxfHandledObject) polyline);
      if (polyline.ControlPoints.Count > 0)
      {
        DxfVertex2D controlPoint = polyline.ControlPoints[0];
        this.method_161(controlPoint, controlPoint.Flags | Enum51.flag_5);
      }
      foreach (DxfVertex2D approximationPoint in (DxfHandledObjectCollection<DxfVertex2D>) polyline.ApproximationPoints)
        this.method_161(approximationPoint, approximationPoint.Flags | Enum51.flag_4);
      for (int index = 1; index < polyline.ControlPoints.Count; ++index)
      {
        DxfVertex2D controlPoint = polyline.ControlPoints[index];
        this.method_161(controlPoint, controlPoint.Flags | Enum51.flag_5);
      }
      this.method_166((DxfHandledObject) polyline.SeqEnd);
    }

    private void method_158(DxfPolygonMesh polyline)
    {
      this.method_114((DxfEntity) polyline);
      this.method_234("AcDbPolygonMesh");
      this.Write(66, (object) (short) 1);
      this.Write(70, (object) (short) (Enum21.flag_5 | polyline.Flags));
      if (polyline.MVertexCount != (ushort) 0)
        this.Write(71, (object) (short) polyline.MVertexCount);
      if (polyline.NVertexCount != (ushort) 0)
        this.Write(72, (object) (short) polyline.NVertexCount);
      this.method_116((DxfHandledObject) polyline);
      foreach (DxfVertex3D vertex in (IEnumerable<DxfVertex3D>) polyline.Vertices)
        this.method_163(vertex, Enum51.flag_7);
      this.method_166((DxfHandledObject) polyline.SeqEnd);
    }

    private void method_159(DxfPolygonSplineMesh polyline)
    {
      this.method_114((DxfEntity) polyline);
      this.method_234("AcDbPolygonMesh");
      this.Write(66, (object) (short) 1);
      this.Write(70, (object) (short) (Enum21.flag_3 | Enum21.flag_5 | polyline.Flags));
      if (polyline.MControlPointCount != (ushort) 0)
        this.Write(71, (object) (short) polyline.MControlPointCount);
      if (polyline.NControlPointCount != (ushort) 0)
        this.Write(72, (object) (short) polyline.NControlPointCount);
      if (polyline.SmoothSurfaceMDensity != (ushort) 0)
        this.Write(73, (object) (short) polyline.SmoothSurfaceMDensity);
      if (polyline.SmoothSurfaceNDensity != (ushort) 0)
        this.Write(74, (object) (short) polyline.SmoothSurfaceNDensity);
      if (polyline.SplineType != SplineType.None)
        this.Write(75, (object) (short) polyline.SplineType);
      this.method_116((DxfHandledObject) polyline);
      bool flag1;
      if (flag1 = polyline.ControlPoints.Count > 0)
        this.method_163(polyline.ControlPoints[0], Enum51.flag_5 | Enum51.flag_7);
      foreach (DxfVertex3D approximationPoint in (IEnumerable<DxfVertex3D>) polyline.ApproximationPoints)
        this.method_163(approximationPoint, Enum51.flag_4 | Enum51.flag_7);
      if (flag1)
      {
        bool flag2 = true;
        foreach (DxfVertex3D controlPoint in (IEnumerable<DxfVertex3D>) polyline.ControlPoints)
        {
          if (flag2)
            flag2 = false;
          else
            this.method_163(controlPoint, Enum51.flag_5 | Enum51.flag_7);
        }
      }
      this.method_166((DxfHandledObject) polyline.SeqEnd);
    }

    private void method_160(DxfPolyfaceMesh polyline)
    {
      this.method_114((DxfEntity) polyline);
      this.method_234("AcDbPolyFaceMesh");
      this.Write(66, (object) (short) 1);
      this.Write(70, (object) (short) 64);
      if (polyline.Vertices.Count != 0)
        this.Write(71, (object) (short) polyline.Vertices.Count);
      if (polyline.Faces.Count != 0)
        this.Write(72, (object) (short) polyline.Faces.Count);
      this.method_116((DxfHandledObject) polyline);
      IList<DxfVertex3D> vertices = (IList<DxfVertex3D>) polyline.Vertices;
      for (int index = 0; index < vertices.Count; ++index)
        this.method_164(vertices[index]);
      List<DxfMeshFace> faces = polyline.Faces;
      for (int index = 0; index < faces.Count; ++index)
        this.method_165(faces[index], vertices);
      this.method_166((DxfHandledObject) polyline.SeqEnd);
    }

    private void method_161(DxfVertex2D v, Enum51 flags)
    {
      this.method_114((DxfEntity) v);
      this.method_234("AcDbVertex");
      this.method_234("AcDb2dVertex");
      this.Write(10, v.Position);
      if (v.StartWidth != 0.0)
        this.Write(40, (object) v.StartWidth);
      if (v.EndWidth != 0.0)
        this.Write(41, (object) v.EndWidth);
      if (v.Bulge != 0.0)
        this.Write(42, (object) v.Bulge);
      if (v.HasTangent)
        this.Write(50, (object) (v.TangentDirection * (180.0 / System.Math.PI)));
      this.Write(70, (object) (short) flags);
    }

    private void method_162(DxfVertex3D v, Enum51 flags)
    {
      this.method_114((DxfEntity) v);
      this.method_234("AcDbVertex");
      this.method_234("AcDb3dPolylineVertex");
      this.Write(10, v.Position);
      this.Write(70, (object) (short) flags);
    }

    private void method_163(DxfVertex3D v, Enum51 flags)
    {
      this.method_114((DxfEntity) v);
      this.method_234("AcDbVertex");
      this.method_234("AcDbPolygonMeshVertex");
      this.Write(10, v.Position);
      this.Write(70, (object) (short) flags);
    }

    private void method_164(DxfVertex3D v)
    {
      this.method_114((DxfEntity) v);
      this.method_234("AcDbVertex");
      this.method_234("AcDbPolyFaceMeshVertex");
      this.Write(10, v.Position);
      this.Write(70, (object) (short) 192);
    }

    private void method_165(DxfMeshFace face, IList<DxfVertex3D> vertices)
    {
      this.method_114((DxfEntity) face);
      this.method_234("AcDbFaceRecord");
      this.Write(10, WW.Math.Vector3D.Zero);
      this.Write(70, (object) (short) 128);
      int count = face.Corners.Count;
      for (int index = 0; index < count; ++index)
      {
        DxfMeshFace.Corner corner = face.Corners[index];
        this.method_219(71 + index, (short) ((vertices.IndexOf(corner.Vertex) + 1) * (corner.EdgeVisible ? 1 : -1)));
      }
    }

    private void method_166(DxfHandledObject seqEnd)
    {
      this.Write(0, (object) "SEQEND");
      if (this.WriteHandles)
        this.method_216(seqEnd);
      this.method_234("AcDbEntity");
      this.Write(8, (object) this.dxfModel_0.ZeroLayer.Name);
    }

    private void method_167(DxfShape shape)
    {
      this.method_114((DxfEntity) shape);
      this.method_234("AcDbShape");
      if (shape.Thickness != 0.0)
        this.Write(39, (object) shape.Thickness);
      this.Write(10, shape.InsertionPoint);
      this.Write(40, (object) shape.ScaleFactor);
      this.Write(2, (object) shape.Name);
      if (shape.Rotation != 0.0)
        this.Write(50, (object) (shape.Rotation * (180.0 / System.Math.PI)));
      if (shape.RelativeXScaleFactor != 1.0)
        this.Write(41, (object) shape.RelativeXScaleFactor);
      if (shape.ObliqueAngle != 0.0)
        this.Write(51, (object) (shape.ObliqueAngle * (180.0 / System.Math.PI)));
      this.method_225(shape.ZAxis);
    }

    private void method_168(DxfSolid solid)
    {
      this.method_114((DxfEntity) solid);
      this.method_234("AcDbTrace");
      for (int index = 0; index < solid.Points.Count; ++index)
        this.Write(10 + index, solid.Points[index]);
      if (solid.Thickness != 0.0)
        this.Write(39, (object) solid.Thickness);
      this.method_225(solid.ZAxis);
    }

    private void method_169(DxfSpline spline)
    {
      if (!this.dxfModel_0.Header.Dxf13OrHigher)
      {
        this.method_242(spline.EntityType);
      }
      else
      {
        this.method_114((DxfEntity) spline);
        this.method_234("AcDbSpline");
        if (spline.IsPlanar || spline.IsLinear)
          this.method_225(spline.ZAxis);
        this.Write(70, (object) (short) spline.Flags);
        this.Write(71, (object) (short) spline.Degree);
        this.Write(72, (object) (short) spline.Knots.Count);
        this.Write(73, (object) (short) spline.ControlPoints.Count);
        if (spline.FitPoints.Count > 0)
          this.Write(74, (object) (short) spline.FitPoints.Count);
        if (spline.KnotTolerance != 1E-07)
          this.Write(42, (object) spline.KnotTolerance);
        if (spline.ControlPointTolerance != 1E-07)
          this.Write(43, (object) spline.ControlPointTolerance);
        if (spline.FitTolerance != 1E-10)
          this.Write(44, (object) spline.FitTolerance);
        if (spline.StartTangent != WW.Math.Vector3D.Zero)
          this.Write(12, spline.StartTangent);
        if (spline.EndTangent != WW.Math.Vector3D.Zero)
          this.Write(13, spline.EndTangent);
        foreach (double knot in spline.Knots)
          this.Write(40, (object) knot);
        foreach (double weight in spline.Weights)
          this.Write(41, (object) weight);
        foreach (WW.Math.Point3D controlPoint in spline.ControlPoints)
          this.Write(10, (WW.Math.Vector3D) controlPoint);
        foreach (WW.Math.Point3D fitPoint in spline.FitPoints)
          this.Write(11, (WW.Math.Vector3D) fitPoint);
      }
    }

    private void method_170(DxfText text, bool writeVerticalAlignment)
    {
      this.method_114((DxfEntity) text);
      this.method_234("AcDbText");
      if (text.Thickness != 0.0)
        this.Write(39, (object) text.Thickness);
      this.Write(10, text.AlignmentPoint1);
      this.Write(40, (object) text.Height);
      this.Write(1, (object) text.Text);
      if (text.WidthFactor != 1.0)
        this.Write(41, (object) text.WidthFactor);
      if (text.ObliqueAngle != 0.0)
        this.Write(51, (object) (text.ObliqueAngle * (180.0 / System.Math.PI)));
      if (text.Rotation != 0.0)
        this.Write(50, (object) (text.Rotation * (180.0 / System.Math.PI)));
      if (text.TextGenerationFlags != TextGenerationFlags.None)
        this.Write(71, (object) (short) text.TextGenerationFlags);
      if (text.HorizontalAlignment != TextHorizontalAlignment.Left)
        this.Write(72, (object) (short) text.HorizontalAlignment);
      if ((text.HorizontalAlignment != TextHorizontalAlignment.Left || text.VerticalAlignment != TextVerticalAlignment.Baseline) && text.AlignmentPoint2.HasValue)
        this.Write(11, text.AlignmentPoint2.Value);
      if (text.Style != null)
        this.Write(7, (object) text.Style.Name);
      if (text.ZAxis != WW.Math.Vector3D.ZAxis)
        this.method_225(text.ZAxis);
      if (text.GetType() == typeof (DxfText))
        this.method_234("AcDbText");
      if (!writeVerticalAlignment || text.VerticalAlignment == TextVerticalAlignment.Baseline)
        return;
      this.Write(73, (object) (short) text.VerticalAlignment);
    }

    private void method_171(DxfMText text)
    {
      if (!this.dxfModel_0.Header.Dxf13OrHigher)
      {
        this.method_242(text.EntityType);
      }
      else
      {
        this.method_114((DxfEntity) text);
        this.method_234("AcDbMText");
        this.Write(10, text.InsertionPoint);
        this.Write(11, text.XAxis);
        this.Write(40, (object) text.Height);
        this.Write(41, (object) text.ReferenceRectangleWidth);
        if (this.dxfVersion_0 >= DxfVersion.Dxf21)
          this.Write(46, (object) text.ReferenceRectangleHeight);
        this.Write(71, (object) (short) text.AttachmentPoint);
        this.Write(72, (object) (short) text.DrawingDirection);
        this.method_140(text.Text);
        if (text.Style != null)
          this.Write(7, (object) text.Style.Name);
        if (this.dxfVersion_0 > DxfVersion.Dxf14 && text.LineSpacingStyle != LineSpacingStyle.None)
          this.Write(73, (object) (short) text.LineSpacingStyle);
        if (text.LineSpacingFactor != 1.0)
          this.Write(44, (object) text.LineSpacingFactor);
        if (this.dxfVersion_0 >= DxfVersion.Dxf18)
        {
          this.Write(90, (object) (int) text.BackgroundFillFlags);
          if ((text.BackgroundFillFlags & BackgroundFillFlags.UseBackgroundFillColor) != BackgroundFillFlags.None && text.BackgroundFillInfo != null)
          {
            this.method_230(63, text.BackgroundFillInfo.Color);
            this.Write(45, (object) text.BackgroundFillInfo.BorderOffsetFactor);
            this.Write(441, (object) (int) text.BackgroundFillInfo.Transparency.Data);
          }
          else
          {
            int num = (int) (text.BackgroundFillFlags & BackgroundFillFlags.UseDrawingWindowColor);
          }
        }
        this.method_225(text.ZAxis);
      }
    }

    private void method_172(DxfAttributeDefinition attributeDefinition)
    {
      this.method_170((DxfText) attributeDefinition, false);
      this.method_234("AcDbAttributeDefinition");
      this.Write(3, (object) attributeDefinition.PromptString);
      this.Write(2, (object) attributeDefinition.TagString);
      this.Write(70, (object) (short) attributeDefinition.Flags);
      this.Write(73, (object) (short) 0);
      if (attributeDefinition.VerticalAlignment != TextVerticalAlignment.Baseline)
        this.Write(74, (object) (short) attributeDefinition.VerticalAlignment);
      if (!this.dxfModel_0.Header.Dxf21OrHigher)
        return;
      this.method_222(280, attributeDefinition.LockPosition);
    }

    private void method_173(DxfAttribute attribute)
    {
      this.method_170((DxfText) attribute, false);
      this.method_234("AcDbAttribute");
      this.Write(2, (object) attribute.TagString);
      this.Write(70, (object) (short) attribute.Flags);
      this.Write(73, (object) (short) 0);
      if (attribute.VerticalAlignment != TextVerticalAlignment.Baseline)
        this.Write(74, (object) (short) attribute.VerticalAlignment);
      if (!this.dxfModel_0.Header.Dxf21OrHigher)
        return;
      this.method_222(280, attribute.LockPosition);
    }

    private void method_174(DxfHatch hatch)
    {
      if (!this.dxfModel_0.Header.Dxf14OrHigher)
      {
        this.method_242(hatch.EntityType);
      }
      else
      {
        this.method_114((DxfEntity) hatch);
        this.method_234("AcDbHatch");
        this.Write(10, (object) 0.0);
        this.Write(20, (object) 0.0);
        this.Write(30, (object) hatch.ElevationPoint.Z);
        this.method_226(hatch.ZAxis);
        this.Write(2, (object) hatch.Name);
        bool flag1 = hatch.Pattern != null && hatch.Pattern.Lines.Count > 0;
        this.Write(70, (object) (short) (!flag1 ? 1 : 0));
        this.Write(71, (object) (short) (hatch.Associative ? 1 : 0));
        this.Write(91, (object) hatch.BoundaryPaths.Count);
        bool flag2 = false;
        foreach (DxfHatch.BoundaryPath boundaryPath in hatch.BoundaryPaths)
        {
          if ((boundaryPath.Type & BoundaryPathType.Derived) == BoundaryPathType.Derived)
            flag2 = true;
          this.Write(92, (object) (int) boundaryPath.Type);
          if ((boundaryPath.Type & BoundaryPathType.Polyline) == BoundaryPathType.Polyline)
          {
            if (boundaryPath.PolylineData != null)
              boundaryPath.PolylineData.Write(this);
          }
          else
            boundaryPath.method_1(this);
          this.Write(97, (object) boundaryPath.BoundaryObjects.Count);
          foreach (DxfHandledObject boundaryObject in (DxfHandledObjectCollection<DxfEntity>) boundaryPath.BoundaryObjects)
            this.method_218(330, boundaryObject);
        }
        this.Write(75, (object) (short) hatch.HatchStyle);
        this.Write(76, (object) (short) hatch.HatchPatternType);
        if (hatch.Pattern != null)
        {
          this.Write(52, (object) (hatch.HatchPatternAngle * (180.0 / System.Math.PI)));
          this.Write(41, (object) hatch.Scale);
          this.Write(77, (object) (short) (hatch.IsDouble ? 1 : 0));
        }
        if (flag1)
          hatch.Pattern.Write(this);
        if (flag2 || hatch.PixelSize != 0.0)
          this.Write(47, (object) hatch.PixelSize);
        this.Write(98, (object) hatch.SeedPoints.Count);
        foreach (WW.Math.Point2D seedPoint in hatch.SeedPoints)
          this.Write(10, (Vector2D) seedPoint);
        if (this.dxfVersion_0 <= DxfVersion.Dxf15 || flag1)
          return;
        DxfColorGradient dxfColorGradient = hatch.ColorGradient ?? DxfColorGradient.dxfColorGradient_0;
        this.Write(450, (object) (dxfColorGradient.Enabled ? 1 : 0));
        this.Write(451, (object) dxfColorGradient.Reserved1);
        this.Write(460, (object) dxfColorGradient.Angle);
        this.Write(461, (object) dxfColorGradient.Shift);
        this.Write(452, (object) (dxfColorGradient.IsSingleColorGradient ? 1 : 0));
        this.Write(462, (object) dxfColorGradient.ColorTint);
        this.Write(453, (object) dxfColorGradient.GradientColors.Count);
        foreach (DxfGradientColor gradientColor in dxfColorGradient.GradientColors)
        {
          this.Write(463, (object) gradientColor.Value);
          this.method_230(63, gradientColor.Color);
        }
        this.Write(470, (object) dxfColorGradient.Name);
      }
    }

    private void method_175(DxfViewport viewport)
    {
      this.method_114((DxfEntity) viewport);
      this.method_234("AcDbViewport");
      this.Write(10, viewport.Center);
      this.Write(40, (object) viewport.Size.X);
      this.Write(41, (object) viewport.Size.Y);
      this.method_219(68, viewport.Status);
      this.Write(69, (object) viewport.Id);
    }

    private void method_176(DxfViewport viewport)
    {
      this.method_114((DxfEntity) viewport);
      this.method_234("AcDbViewport");
      this.Write(10, viewport.Center);
      this.Write(40, (object) viewport.Size.X);
      this.Write(41, (object) viewport.Size.Y);
      this.method_219(68, viewport.Status);
      this.Write(69, (object) viewport.Id);
      this.Write(12, viewport.ViewCenter);
      this.Write(13, viewport.SnapBasePoint);
      this.Write(14, viewport.SnapSpacing);
      this.Write(15, viewport.GridSpacing);
      this.Write(16, viewport.Direction);
      this.Write(17, viewport.Target);
      this.Write(42, (object) viewport.LensLength);
      this.Write(43, (object) viewport.FrontClipPlaneZValue);
      this.Write(44, (object) viewport.BackClipPlaneZValue);
      this.Write(45, (object) viewport.ViewHeight);
      this.Write(50, (object) (viewport.SnapAngle * (180.0 / System.Math.PI)));
      this.Write(51, (object) (viewport.TwistAngle * (180.0 / System.Math.PI)));
      this.Write(72, (object) (short) viewport.CircleZoomPercentage);
      int code = this.dxfModel_0.Header.AcadVersionString == "AC1015" || this.dxfModel_0.Header.AcadVersionString == "AC1016" ? 341 : 331;
      foreach (DxfLayer frozenLayer in (IEnumerable<DxfLayer>) viewport.FrozenLayers)
        this.method_218(code, (DxfHandledObject) frozenLayer);
      this.Write(90, (object) (int) (viewport.StatusFlags | ViewportStatusFlags.Reserved));
      if (viewport.ClippingBoundaryEntity != null)
        this.method_218(340, (DxfHandledObject) viewport.ClippingBoundaryEntity);
      this.Write(1, (object) viewport.PlotStyleSheetName);
      this.Write(281, (object) (byte) viewport.RenderMode);
      this.Write(71, (object) (short) (viewport.UcsPerViewport ? 1 : 0));
      this.Write(74, (object) (short) (viewport.DisplayUcsIcon ? 1 : 0));
      this.Write(110, viewport.Ucs.Origin);
      this.Write(111, viewport.Ucs.XAxis);
      this.Write(112, viewport.Ucs.YAxis);
      if (viewport.Ucs.Handle != 0UL)
      {
        if (viewport.UcsOrthographicType == OrthographicType.None)
          this.method_218(345, (DxfHandledObject) viewport.Ucs);
        else
          this.method_218(346, (DxfHandledObject) viewport.Ucs);
      }
      this.Write(79, (object) (short) viewport.UcsOrthographicType);
      this.Write(146, (object) viewport.Ucs.Elevation);
      if (this.dxfVersion_0 >= DxfVersion.Dxf18)
        this.Write(170, (object) (short) viewport.ShadePlotMode);
      if (this.dxfVersion_0 < DxfVersion.Dxf21)
        return;
      this.method_220(61, viewport.MajorGridLineFrequency);
      this.Write(292, (object) viewport.UseDefaultLighting);
      this.Write(282, (object) (byte) viewport.DefaultLightingType);
      this.Write(141, (object) viewport.Brightness);
      this.Write(142, (object) viewport.Constrast);
      this.method_230(63, viewport.AmbientLightColor);
    }

    private void method_177(DxfTolerance tolerance)
    {
      if (!this.dxfModel_0.Header.Dxf13OrHigher)
      {
        this.method_242(tolerance.EntityType);
      }
      else
      {
        this.method_114((DxfEntity) tolerance);
        this.method_234("AcDbFcf");
        if (tolerance.DimensionStyleOverrides != null && tolerance.DimensionStyle != null)
          this.Write(3, (object) tolerance.DimensionStyle.Name);
        this.Write(10, tolerance.InsertionPoint);
        this.Write(1, (object) tolerance.Text);
        this.method_225(tolerance.ZAxis);
        this.Write(11, tolerance.XAxis);
      }
    }

    private void method_178()
    {
      this.Write(Class824.struct18_0);
      this.Write(2, (object) "OBJECTS");
      this.method_179(this.dxfModel_0.DictionaryRoot);
      this.method_116((DxfHandledObject) this.dxfModel_0.DictionaryRoot);
      foreach (DxfDictionary dictionary in this.dxfModel_0.method_16())
      {
        this.method_179(dictionary);
        this.method_116((DxfHandledObject) dictionary);
      }
      while (this.queue_0.Count > 0)
        this.method_181(this.queue_0.Dequeue());
      this.Write(Class824.struct18_1);
    }

    private void method_179(DxfDictionary dictionary)
    {
      this.method_203((DxfObject) dictionary);
      this.method_180(dictionary);
      foreach (IDictionaryEntry entry in (ActiveList<IDictionaryEntry>) dictionary.Entries)
      {
        if (entry.Value != null && entry.Value.vmethod_5(this.dxfModel_0))
          this.queue_0.Enqueue(entry.Value);
      }
    }

    private void method_180(DxfDictionary dictionary)
    {
      this.method_234("AcDbDictionary");
      if (this.dxfModel_0.Header.Dxf15OrHigher)
      {
        this.method_222(280, dictionary.HardOwner);
        this.Write(281, (object) (byte) dictionary.DuplicateRecordCloning);
      }
      foreach (IDictionaryEntry entry in (ActiveList<IDictionaryEntry>) dictionary.Entries)
      {
        if (entry.Value != null && entry.Value.vmethod_5(this.dxfModel_0))
        {
          this.Write(3, (object) entry.Name);
          if (entry.ValueReferenceIsHard)
            this.method_218(360, (DxfHandledObject) entry.Value);
          else
            this.method_218(350, (DxfHandledObject) entry.Value);
        }
      }
    }

    private void method_181(DxfObject obj)
    {
      if (!obj.vmethod_5(this.dxfModel_0))
        return;
      string objectType = obj.ObjectType;
      switch (objectType)
      {
        case "ACDB_ALDIMOBJECTCONTEXTDATA_CLASS":
        case "ACDB_ANGDIMOBJECTCONTEXTDATA_CLASS":
        case "ACDB_BLKREFOBJECTCONTEXTDATA_CLASS":
        case "DATATABLE":
        case "ACDB_DMDIMOBJECTCONTEXTDATA_CLASS":
        case "GEODATA":
        case "ACDB_HATCHSCALECONTEXTDATA_CLASS":
        case "ACDB_HATCHVIEWCONTEXTDATA_CLASS":
        case "ACDB_FCFOBJECTCONTEXTDATA_CLASS":
        case "ACDB_LEADEROBJECTCONTEXTDATA_CLASS":
        case "MLEADERSTYLE":
        case "ACDB_MLEADEROBJECTCONTEXTDATA_CLASS":
        case "ACDB_MTEXTATTRIBUTEOBJECTCONTEXTDATA_CLASS":
        case "ACDB_MTEXTOBJECTCONTEXTDATA_CLASS":
        case "ACDB_ORDDIMOBJECTCONTEXTDATA_CLASS":
        case "ACDB_RADIMOBJECTCONTEXTDATA_CLASS":
        case "RASTERVARIABLES":
        case "SCALE":
        case "TABLECONTENT":
        case "ACDB_TEXTOBJECTCONTEXTDATA_CLASS":
        case "VISUALSTYLE":
        case "WIPEOUTVARIABLES":
        case "BLOCKLINEARCONSTRAINTPARAMETER":
        case "BLOCKHORIZONTALCONSTRAINTPARAMETER":
        case "BLOCKVERTICALCONSTRAINTPARAMETER":
        case "BLOCKALIGNEDCONSTRAINTPARAMETER":
        case "BLOCKANGULARCONSTRAINTPARAMETER":
        case "BLOCKDIAMETRICCONSTRAINTPARAMETER":
        case "BLOCKRADIALCONSTRAINTPARAMETER":
          this.Write(0, (object) obj.ObjectType);
          obj.Write(this);
          break;
        case "DICTIONARY":
          this.method_179((DxfDictionary) obj);
          break;
        case "ACDBDICTIONARYWDFLT":
          this.method_182((DxfDictionaryWithDefault) obj);
          break;
        case "DICTIONARYVAR":
          this.method_184((DxfDictionaryVariable) obj);
          break;
        case "FIELD":
          this.method_205((DxfField) obj);
          break;
        case "FIELDLIST":
          this.method_207((DxfFieldList) obj);
          break;
        case "GROUP":
          this.method_208((DxfGroup) obj);
          break;
        case "IDBUFFER":
          this.method_186((DxfIdBuffer) obj);
          break;
        case "IMAGEDEF":
          this.method_210((DxfImageDef) obj);
          break;
        case "LAYOUT":
          this.method_212((DxfLayout) obj);
          break;
        case "MLINESTYLE":
          this.method_185((DxfMLineStyle) obj);
          break;
        case "PLOTSETTINGS":
          this.method_195((DxfPlotSettings) obj);
          break;
        case "SORTENTSTABLE":
          this.method_196((DxfSortEntsTable) obj);
          break;
        case "SPATIAL_FILTER":
          this.method_198((DxfSpatialFilter) obj);
          break;
        case "ACDBPLACEHOLDER":
          this.method_187((DxfPlaceHolder) obj);
          break;
        case "TABLESTYLE":
          this.method_188((DxfTableStyle) obj);
          break;
        case "CELLSTYLEMAP":
          this.method_190((DxfCellStyleMap) obj);
          break;
        case "XRECORD":
          this.method_191((DxfXRecord) obj);
          break;
        case "DBCOLOR":
          this.method_193((DxfColor) obj);
          break;
        case "ACAD_EVALUATION_GRAPH":
          DxfEvalGraph evalGraph = (DxfEvalGraph) obj;
          this.method_0(evalGraph);
          this.method_116((DxfHandledObject) obj);
          foreach (DxfEvalGraph.GraphNode node in evalGraph.Nodes)
          {
            if (node.Expression != null)
              this.method_181(node.Expression);
          }
          return;
        case "BLOCKPOINTPARAMETER":
          this.method_19((DxfBlockPointParameter) obj);
          break;
        case "BLOCKUSERPARAMETER":
          this.method_20((DxfBlockUserParameter) obj);
          break;
        case "BLOCKBASEPOINTPARAMETER":
          this.method_7((DxfBlockBasePointParameter) obj);
          break;
        case "BLOCKLOOKUPPARAMETER":
          this.method_8((DxfBlockLookUpParameter) obj);
          break;
        case "BLOCKVISIBILITYPARAMETER":
          this.method_9((DxfBlockVisibilityParameter) obj);
          break;
        case "BLOCKPROPERTIESTABLE":
          this.method_10((DxfBlockPropertiesTable) obj);
          break;
        case "BLOCKALIGNMENTPARAMETER":
          this.method_1((DxfBlockAlignmentParameter) obj);
          break;
        case "BLOCKFLIPPARAMETER":
          this.method_2((DxfBlockFlipParameter) obj);
          break;
        case "BLOCKLINEARPARAMETER":
          this.method_3((DxfBlockLinearParameter) obj);
          break;
        case "BLOCKPOLARPARAMETER":
          this.method_4((DxfBlockPolarParameter) obj);
          break;
        case "BLOCKROTATIONPARAMETER":
          this.method_5((DxfBlockRotationParameter) obj);
          break;
        case "BLOCKXYPARAMETER":
          this.method_6((DxfBlockXYParameter) obj);
          break;
        case "BLOCKROTATEACTION":
          this.method_17((DxfBlockRotateAction) obj);
          break;
        case "BLOCKLOOKUPACTION":
          this.method_13((DxfBlockLookupAction) obj);
          break;
        case "BLOCKSCALEACTION":
          this.method_18((DxfBlockScaleAction) obj);
          break;
        case "BLOCKARRAYACTION":
          this.method_11((DxfBlockArrayAction) obj);
          break;
        case "BLOCKFLIPACTION":
          this.method_12((DxfBlockFlipAction) obj);
          break;
        case "BLOCKMOVEACTION":
          this.method_14((DxfBlockMoveAction) obj);
          break;
        case "BLOCKPOLARSTRETCHACTION":
          this.method_15((DxfBlockPolarStretchAction) obj);
          break;
        case "BLOCKSTRETCHACTION":
          this.method_16((DxfBlockStretchAction) obj);
          break;
        case "BLOCKALIGNMENTGRIP":
          this.method_67((DxfBlockAlignmentGrip) obj);
          break;
        case "BLOCKFLIPGRIP":
          this.method_64((DxfBlockFlipGrip) obj);
          break;
        case "ACDB_BLOCKREPRESENTATION_DATA":
          this.method_65((DxfBlockRepresentationData) obj);
          break;
        case "ACDB_DYNAMICBLOCKPURGEPREVENTER_VERSION":
          this.method_66((DxfBlockPurgePreventer) obj);
          break;
        case "BLOCKLINEARGRIP":
          this.method_62((DxfBlockLinearGrip) obj);
          break;
        case "BLOCKLOOKUPGRIP":
          this.method_61((DxfBlockLookupGrip) obj);
          break;
        case "BLOCKPOLARGRIP":
          this.method_59((DxfBlockPolarGrip) obj);
          break;
        case "BLOCKPROPERTIESTABLEGRIP":
          this.method_60((DxfBlockPropertiesTableGrip) obj);
          break;
        case "BLOCKROTATIONGRIP":
          this.method_58((DxfBlockRotationGrip) obj);
          break;
        case "BLOCKVISIBILITYGRIP":
          this.method_57((DxfBlockVisibilityGrip) obj);
          break;
        case "BLOCKXYGRIP":
          this.method_56((DxfBlockXYGrip) obj);
          break;
        case "BLOCKGRIPLOCATIONCOMPONENT":
          this.method_68((DxfBlockGripExpression) obj);
          break;
        case "ACDB_DYNAMICBLOCKPROXYNODE":
          this.method_69((DxfDynamicBlockProxyNode) obj);
          break;
        default:
          throw new DxfException("Unknown object type " + objectType);
      }
      this.method_116((DxfHandledObject) obj);
    }

    private void method_182(DxfDictionaryWithDefault dictionary)
    {
      this.method_203((DxfObject) dictionary);
      this.method_180((DxfDictionary) dictionary);
      this.method_183(dictionary);
      bool flag = false;
      foreach (DxfDictionaryEntry entry in (ActiveList<IDictionaryEntry>) dictionary.Entries)
      {
        this.method_181(entry.Value);
        if (entry.Value == dictionary.DefaultEntry)
          flag = true;
      }
      if (flag || dictionary.DefaultEntry == null)
        return;
      this.method_181(dictionary.DefaultEntry);
    }

    private void method_183(DxfDictionaryWithDefault dictionary)
    {
      this.method_234("AcDbDictionaryWithDefault");
      if (dictionary.DefaultEntry == null)
        return;
      this.method_218(340, (DxfHandledObject) dictionary.DefaultEntry);
    }

    private void method_184(DxfDictionaryVariable dictionaryVariable)
    {
      this.method_203((DxfObject) dictionaryVariable);
      this.method_234("DictionaryVariables");
      this.Write(280, (object) (byte) 0);
      this.Write(1, (object) dictionaryVariable.Value);
    }

    private void method_185(DxfMLineStyle mlineStyle)
    {
      this.method_203((DxfObject) mlineStyle);
      this.method_234("AcDbMlineStyle");
      this.Write(2, (object) mlineStyle.Name);
      this.Write(70, (object) (short) mlineStyle.Flags);
      this.Write(3, (object) mlineStyle.Description);
      this.method_230(62, mlineStyle.FillColor);
      this.Write(51, (object) (mlineStyle.StartAngle * (180.0 / System.Math.PI)));
      this.Write(52, (object) (mlineStyle.EndAngle * (180.0 / System.Math.PI)));
      this.Write(71, (object) (short) mlineStyle.Elements.Count);
      foreach (DxfMLineStyle.Element element in mlineStyle.Elements)
      {
        this.Write(49, (object) element.Offset);
        this.method_230(62, element.Color);
        if (element.LineType != null)
          this.Write(6, (object) element.LineType.Name);
      }
    }

    private void method_186(DxfIdBuffer idBuffer)
    {
      this.method_203((DxfObject) idBuffer);
      this.method_234("AcDbIdBuffer");
      foreach (DxfHandledObject handledObject in idBuffer.HandledObjects)
        this.method_218(330, handledObject);
    }

    private void method_187(DxfPlaceHolder placeHolder)
    {
      this.method_203((DxfObject) placeHolder);
    }

    private void method_188(DxfTableStyle tableStyle)
    {
      this.method_203((DxfObject) tableStyle);
      this.method_234("AcDbTableStyle");
      this.Write(3, (object) tableStyle.Description);
      this.Write(70, (object) (short) tableStyle.FlowDirection);
      this.Write(71, (object) (short) tableStyle.Flags);
      this.Write(40, (object) tableStyle.HorizontalCellMargin);
      this.Write(41, (object) tableStyle.VerticalCellMargin);
      this.method_222(280, tableStyle.SuppressTitle);
      this.method_222(281, tableStyle.SuppressHeaderRow);
      this.method_189(tableStyle.DataCellStyle);
      this.method_189(tableStyle.TitleCellStyle);
      this.method_189(tableStyle.HeaderCellStyle);
    }

    private void method_189(DxfTableCellStyle cellStyle)
    {
      if (cellStyle == null)
        return;
      if (cellStyle.TextStyle != null)
        this.Write(7, (object) cellStyle.TextStyle.Name);
      else
        this.Write(7, (object) this.dxfModel_0.DefaultTextStyle.Name);
      this.Write(140, (object) cellStyle.TextHeight);
      this.Write(170, (object) (short) cellStyle.CellAlignment);
      this.method_230(62, cellStyle.ContentColor);
      if (cellStyle.IsBackColorEnabled)
        this.method_230(63, cellStyle.BackColor);
      this.method_222(283, cellStyle.IsBackColorEnabled);
      this.Write(90, (object) (cellStyle.ValueFormat == null ? 0 : (int) cellStyle.ValueFormat.DataType));
      this.Write(91, (object) (cellStyle.ValueFormat == null ? 0 : (int) cellStyle.ValueFormat.UnitType));
      this.Write(274, (object) cellStyle.BorderTop.LineWeight);
      this.method_222(284, cellStyle.BorderTop.Visible);
      this.method_230(64, cellStyle.BorderTop.Color);
      this.Write(275, (object) cellStyle.BorderInsideHorizontal.LineWeight);
      this.method_222(285, cellStyle.BorderInsideHorizontal.Visible);
      this.method_230(65, cellStyle.BorderInsideHorizontal.Color);
      this.Write(276, (object) cellStyle.BorderBottom.LineWeight);
      this.method_222(286, cellStyle.BorderBottom.Visible);
      this.method_230(66, cellStyle.BorderBottom.Color);
      this.Write(277, (object) cellStyle.BorderLeft.LineWeight);
      this.method_222(287, cellStyle.BorderLeft.Visible);
      this.method_230(67, cellStyle.BorderLeft.Color);
      this.Write(278, (object) cellStyle.BorderInsideVertical.LineWeight);
      this.method_222(288, cellStyle.BorderInsideVertical.Visible);
      this.method_230(68, cellStyle.BorderInsideVertical.Color);
      this.Write(279, (object) cellStyle.BorderRight.LineWeight);
      this.method_222(289, cellStyle.BorderRight.Visible);
      this.method_230(69, cellStyle.BorderRight.Color);
    }

    private void method_190(DxfCellStyleMap cellStyleMap)
    {
      DxfDictionary objectSoftReference1 = (DxfDictionary) cellStyleMap.OwnerObjectSoftReference;
      if (objectSoftReference1 == null)
        return;
      DxfTableStyle objectSoftReference2 = (DxfTableStyle) objectSoftReference1.OwnerObjectSoftReference;
      if (objectSoftReference2 == null)
        return;
      this.method_203((DxfObject) cellStyleMap);
      this.method_234("AcDbCellStyleMap");
      this.Write(90, (object) objectSoftReference2.CellStyles.Count);
      foreach (DxfTableCellStyle cellStyle in (Collection<DxfTableCellStyle>) objectSoftReference2.CellStyles)
        cellStyle.Write(this);
    }

    private void method_191(DxfXRecord xrecord)
    {
      if (!this.dxfModel_0.Header.Dxf13OrHigher)
        return;
      this.method_203((DxfObject) xrecord);
      this.method_192(xrecord);
    }

    private void method_192(DxfXRecord xrecord)
    {
      this.method_234("AcDbXrecord");
      this.Write(280, (object) (byte) xrecord.DuplicateRecordCloningFlag);
      foreach (DxfXRecordValue dxfXrecordValue in (List<DxfXRecordValue>) xrecord.Values)
      {
        switch (Class820.smethod_2((int) dxfXrecordValue.Code))
        {
          case Enum5.const_5:
          case Enum5.const_7:
          case Enum5.const_8:
          case Enum5.const_15:
            this.method_218((int) dxfXrecordValue.Code, (DxfHandledObject) dxfXrecordValue.Value);
            continue;
          case Enum5.const_6:
            this.method_223((int) dxfXrecordValue.Code, dxfXrecordValue.Value.ToString());
            continue;
          case Enum5.const_9:
          case Enum5.const_14:
            this.method_218((int) dxfXrecordValue.Code, (DxfHandledObject) dxfXrecordValue.Value);
            DxfObject dxfObject = dxfXrecordValue.Value as DxfObject;
            if (dxfObject != null)
            {
              this.queue_0.Enqueue(dxfObject);
              continue;
            }
            continue;
          case Enum5.const_13:
            WW.Math.Point3D p = (WW.Math.Point3D) dxfXrecordValue.Value;
            this.Write((int) dxfXrecordValue.Code, p);
            continue;
          case Enum5.const_18:
            continue;
          default:
            this.Write((int) dxfXrecordValue.Code, dxfXrecordValue.Value);
            continue;
        }
      }
    }

    private void method_193(DxfColor dxfColor)
    {
      if (!this.dxfModel_0.Header.Dxf18OrHigher)
        return;
      this.method_203((DxfObject) dxfColor);
      this.method_194(dxfColor);
    }

    private void method_194(DxfColor dxfColor)
    {
      this.method_234("AcDbColor");
      this.method_230(62, dxfColor.Color);
    }

    private void method_195(DxfPlotSettings plotSettings)
    {
      this.method_203((DxfObject) plotSettings);
      this.method_204(plotSettings);
    }

    private void method_196(DxfSortEntsTable sortEntsTable)
    {
      this.method_203((DxfObject) sortEntsTable);
      this.method_197(sortEntsTable);
    }

    private void method_197(DxfSortEntsTable sortEntsTable)
    {
      this.method_234("AcDbSortentsTable");
      this.method_218(330, (DxfHandledObject) sortEntsTable.OwnerBlock);
      foreach (DxfEntitySortWrapper entitySortWrapper in sortEntsTable.EntitySortWrappers)
      {
        if (entitySortWrapper.Entity != null)
        {
          this.method_218(331, (DxfHandledObject) entitySortWrapper.Entity);
          this.Write(5, (object) entitySortWrapper.SortHandle);
        }
      }
    }

    private void method_198(DxfSpatialFilter filter)
    {
      this.method_203((DxfObject) filter);
      this.method_199();
      this.method_200(filter);
    }

    private void method_199()
    {
      this.method_234("AcDbFilter");
    }

    private void method_200(DxfSpatialFilter filter)
    {
      this.method_234("AcDbSpatialFilter");
      this.Write(70, (object) (short) filter.ClipBoundaryPoints.Count);
      foreach (WW.Math.Point2D clipBoundaryPoint in (IEnumerable<WW.Math.Point2D>) filter.ClipBoundaryPoints)
        this.Write(10, clipBoundaryPoint);
      this.Write(210, filter.ClipBoundaryPlaneNormal);
      this.Write(11, filter.ClipBoundaryPlaneOrigin);
      this.Write(71, (object) (short) (filter.ClipBoundaryDisplayEnabled ? 1 : 0));
      double? clippingPlaneDistance = filter.FrontClippingPlaneDistance;
      if (clippingPlaneDistance.HasValue)
      {
        this.Write(72, (object) (short) 1);
        this.Write(40, (object) clippingPlaneDistance.Value);
      }
      else
        this.Write(72, (object) (short) 0);
      clippingPlaneDistance = filter.BackClippingPlaneDistance;
      if (clippingPlaneDistance.HasValue)
      {
        this.Write(73, (object) (short) 1);
        this.Write(41, (object) clippingPlaneDistance.Value);
      }
      else
        this.Write(73, (object) (short) 0);
      Matrix4D insertionTransform = filter.InverseInsertionTransform;
      Matrix4D boundaryTransform = filter.ClipBoundaryTransform;
      double[] numArray = new double[24]{ insertionTransform.M00, insertionTransform.M01, insertionTransform.M02, insertionTransform.M03, insertionTransform.M10, insertionTransform.M11, insertionTransform.M12, insertionTransform.M13, insertionTransform.M20, insertionTransform.M21, insertionTransform.M22, insertionTransform.M23, boundaryTransform.M00, boundaryTransform.M01, boundaryTransform.M02, boundaryTransform.M03, boundaryTransform.M10, boundaryTransform.M11, boundaryTransform.M12, boundaryTransform.M13, boundaryTransform.M20, boundaryTransform.M21, boundaryTransform.M22, boundaryTransform.M23 };
      foreach (double num in numArray)
        this.Write(40, (object) num);
    }

    internal void method_201(DxfHandledObject obj)
    {
      this.method_202(obj, 5);
    }

    internal void method_202(DxfHandledObject obj, int handleGroupCode)
    {
      if (!this.WriteHandles || obj.Handle == 0UL)
        return;
      this.method_218(handleGroupCode, obj);
      if (!this.dxfModel_0.Header.Dxf13OrHigher)
        return;
      if (obj.ExtensionDictionary != null)
      {
        this.Write(102, (object) "{ACAD_XDICTIONARY");
        this.Write(360, (object) obj.ExtensionDictionary.Handle);
        this.Write(102, (object) "}");
      }
      if (obj.HasPersistentReactors)
      {
        this.Write(102, (object) "{ACAD_REACTORS");
        foreach (DxfHandledObject persistentReactor in obj.PersistentReactors)
          this.Write(330, (object) persistentReactor.Handle);
        this.Write(102, (object) "}");
      }
      if (obj.OwnerObjectSoftReference == null)
        return;
      this.Write(330, (object) obj.OwnerObjectSoftReference.Handle);
    }

    private void method_203(DxfObject obj)
    {
      this.Write(0, (object) obj.ObjectType);
      this.method_201((DxfHandledObject) obj);
    }

    private void method_204(DxfPlotSettings plotSettings)
    {
      this.method_234("AcDbPlotSettings");
      this.Write(1, (object) plotSettings.PageSetupName);
      this.Write(2, (object) plotSettings.PlotConfigurationFile);
      this.Write(4, (object) plotSettings.PaperSizeName);
      this.Write(6, (object) plotSettings.PlotViewName);
      this.Write(40, (object) plotSettings.UnprintableMarginLeft);
      this.Write(41, (object) plotSettings.UnprintableMarginBottom);
      this.Write(42, (object) plotSettings.UnprintableMarginRight);
      this.Write(43, (object) plotSettings.UnprintableMarginTop);
      this.Write(44, (object) plotSettings.PlotPaperSize.X);
      this.Write(45, (object) plotSettings.PlotPaperSize.Y);
      this.Write(46, (object) plotSettings.PlotOrigin.X);
      this.Write(47, (object) plotSettings.PlotOrigin.Y);
      this.Write(48, (object) plotSettings.PlotWindowArea.X1);
      this.Write(49, (object) plotSettings.PlotWindowArea.Y1);
      this.Write(140, (object) plotSettings.PlotWindowArea.X2);
      this.Write(141, (object) plotSettings.PlotWindowArea.Y2);
      this.Write(142, (object) plotSettings.CustomPrintScaleNumerator);
      this.Write(143, (object) plotSettings.CustomPrintScaleDenominator);
      this.method_219(70, (short) plotSettings.PlotLayoutFlags);
      this.method_220(72, (short) plotSettings.PlotPaperUnits);
      this.method_220(73, (short) plotSettings.PlotRotation);
      this.method_220(74, (short) plotSettings.PlotArea);
      this.Write(7, (object) plotSettings.CurrentStyleSheet);
      this.method_220(75, plotSettings.StandardScaleType);
      this.method_220(76, (short) plotSettings.ShadePlotMode);
      this.method_220(77, (short) plotSettings.ShadePlotResolution);
      this.method_220(78, plotSettings.ShadePlotCustomDpi);
      this.Write(147, (object) plotSettings.StandardScaleFactor);
      this.Write(148, (object) plotSettings.PaperImageOrigin.X);
      this.Write(149, (object) plotSettings.PaperImageOrigin.Y);
    }

    private void method_205(DxfField field)
    {
      this.method_203((DxfObject) field);
      this.method_206(field);
      foreach (DxfField childField in (IEnumerable<DxfField>) field.ChildFields)
        this.method_205(childField);
    }

    private void method_206(DxfField field)
    {
      this.method_234("AcDbField");
      this.Write(1, (object) field.EvaluatorId);
      this.method_141(2, 3, field.FieldCode);
      this.Write(90, (object) field.ChildFields.Count);
      foreach (DxfHandledObject childField in (IEnumerable<DxfField>) field.ChildFields)
        this.method_218(360, childField);
      this.Write(97, (object) field.FieldObjects.Count);
      foreach (DxfHandledObject fieldObject in (IEnumerable<DxfHandledObject>) field.FieldObjects)
        this.method_218(331, fieldObject);
      if (!this.dxfModel_0.Header.Dxf19OrHigher)
        this.Write(4, (object) field.FormatString);
      this.Write(91, (object) (int) field.EvalutationOptionFlags);
      this.Write(92, (object) (int) field.FilingOptionFlags);
      this.Write(94, (object) (int) field.FieldStateFlags);
      this.Write(95, (object) (int) field.EvaluationStatusFlags);
      this.Write(96, (object) field.EvaluationErrorCode);
      this.Write(300, (object) field.EvaluationErrorMessage);
      this.Write(93, (object) field.Values.Count);
      foreach (KeyValuePair<string, DxfValue> keyValuePair in (IEnumerable<KeyValuePair<string, DxfValue>>) field.Values)
      {
        this.Write(6, (object) keyValuePair.Key);
        keyValuePair.Value.Write(this);
      }
      this.Write(7, (object) field.Key);
      field.Value.Write(this);
      this.method_141(301, 9, field.ValueString);
      this.Write(98, (object) field.ValueString.Length);
    }

    private void method_207(DxfFieldList fieldList)
    {
      this.method_203((DxfObject) fieldList);
      this.method_234("AcDbIdSet");
      foreach (DxfHandledObject field in (IEnumerable<DxfField>) fieldList.Fields)
        this.method_218(330, field);
      this.method_234("AcDbFieldList");
    }

    private void method_208(DxfGroup group)
    {
      this.method_203((DxfObject) group);
      this.method_209(group);
    }

    private void method_209(DxfGroup group)
    {
      this.method_234("AcDbGroup");
      this.Write(300, (object) group.Description);
      this.Write(70, (object) (short) (group.IsAnonymous ? 1 : 0));
      this.Write(71, (object) (short) (group.Selectable ? 1 : 0));
      foreach (DxfHandledObject member in (IEnumerable<DxfHandledObject>) group.Members)
        this.method_218(340, member);
    }

    private void method_210(DxfImageDef imageDef)
    {
      this.method_203((DxfObject) imageDef);
      this.method_211(imageDef);
    }

    private void method_211(DxfImageDef imageDef)
    {
      this.method_234("AcDbRasterImageDef");
      this.Write(90, (object) imageDef.ClassVersion);
      this.Write(1, (object) imageDef.Filename);
      this.Write(10, imageDef.Size);
      this.Write(11, imageDef.DefaultPixelSize);
      this.method_222(280, imageDef.ImageIsLoaded);
      this.Write(281, (object) (byte) imageDef.ResolutionUnits);
    }

    private void method_212(DxfLayout layout)
    {
      this.method_203((DxfObject) layout);
      this.method_204((DxfPlotSettings) layout);
      this.method_213(layout);
    }

    private void method_213(DxfLayout layout)
    {
      this.method_234("AcDbLayout");
      this.Write(1, (object) layout.Name);
      this.method_219(70, (short) layout.Options);
      this.method_220(71, (short) layout.TabOrder);
      this.Write(10, layout.Limits.Corner1);
      this.Write(11, layout.Limits.Corner2);
      this.Write(12, layout.InsertionBasePoint);
      this.Write(14, layout.MinExtents);
      this.Write(15, layout.MaxExtents);
      DxfUcs ucs = layout.Ucs;
      if (ucs != null)
      {
        this.Write(146, (object) ucs.Elevation);
        this.Write(13, ucs.Origin);
        this.Write(16, ucs.XAxis);
        this.Write(17, ucs.YAxis);
        this.Write(76, (object) (short) layout.UcsOrthographicType);
      }
      if (layout.OwnerBlock != null)
        this.method_218(330, (DxfHandledObject) layout.OwnerBlock);
      if (layout.LastActiveViewport != null)
        this.method_218(331, layout.LastActiveViewport);
      if (ucs == null || ucs.Handle == 0UL)
        return;
      if (layout.UcsOrthographicType == OrthographicType.None)
        this.method_218(345, (DxfHandledObject) ucs);
      else
        this.method_218(346, (DxfHandledObject) ucs);
    }

    private void method_214()
    {
      Class741 dataStore = this.dxfModel_0.method_13();
      if (dataStore.RecordTypeTohandleToDataRecord.Count <= 0)
        return;
      int num = 0;
      foreach (KeyValuePair<Enum53, Class560> keyValuePair in dataStore.RecordTypeTohandleToDataRecord)
        num += keyValuePair.Value.Count;
      if (num <= 0)
        return;
      new Class741.Class742().Write(dataStore, this);
    }

    private void method_215()
    {
      this.dxfModel_0.method_28(new Class1070(this.dxfModel_0, FileFormat.Dxf, this.dxfVersion_0));
    }

    internal bool WriteHandles
    {
      get
      {
        if (!this.dxfModel_0.Header.Dxf13OrHigher)
          return this.dxfModel_0.Header.Handling;
        return true;
      }
    }

    internal void method_216(DxfHandledObject obj)
    {
      if (obj.Handle == 0UL)
        throw new DxfException(string.Format("Error writing handle for object of type {0} with zero handle.", (object) obj.GetType().FullName));
      this.Write(5, (object) obj.Handle);
    }

    internal void method_217(DxfHandledObject obj)
    {
      if (obj.OwnerObjectSoftReference == null || !this.dxfModel_0.Header.Dxf14OrHigher)
        return;
      this.Write(330, (object) DxfHandledObject.Class9.smethod_0(obj.OwnerObjectSoftReference.Handle));
    }

    internal void method_218(int code, DxfHandledObject obj)
    {
      if (obj == null)
      {
        this.Write(code, (object) 0UL);
      }
      else
      {
        if (obj.Handle == 0UL)
          throw new DxfException(string.Format("Error writing handle for object of type {0} with zero handle.", (object) obj.GetType().FullName));
        this.Write(code, (object) obj.Handle);
      }
    }

    internal void Write(Struct18 group)
    {
      this.interface13_0.imethod_0(group);
    }

    internal void Write(int baseCode, Struct18 group)
    {
      this.interface13_0.imethod_1(baseCode, group);
    }

    internal void Write(int code, object value)
    {
      this.Write(new Struct18(code, value));
    }

    internal void Write(int baseCode, int code, object value)
    {
      Struct18 group = new Struct18(code, value);
      this.Write(baseCode, group);
    }

    internal void method_219(int code, short value)
    {
      if (Class820.smethod_2(code) == Enum5.const_11)
        this.interface13_0.imethod_0(new Struct18(code, (object) (int) value));
      else
        this.interface13_0.imethod_2(new Struct18(code, (object) value));
    }

    internal void method_220(int code, short value)
    {
      if (Class820.smethod_2(code) == Enum5.const_11)
        this.interface13_0.imethod_0(new Struct18(code, (object) (int) value));
      else
        this.interface13_0.imethod_3(new Struct18(code, (object) value));
    }

    internal void method_221(int code, bool value)
    {
      this.method_219(code, value ? (short) 1 : (short) 0);
    }

    internal void method_222(int code, bool value)
    {
      this.interface13_0.imethod_0(new Struct18(code, (object) (byte) (value ? 1 : 0)));
    }

    internal void method_223(int code, string value)
    {
      this.interface13_0.imethod_4(new Struct18(code, (object) value));
    }

    internal void Write(int code, WW.Math.Point3D p)
    {
      this.Write(code, (object) p.X);
      this.Write(code, code + 10, (object) p.Y);
      this.Write(code, code + 20, (object) p.Z);
    }

    internal void Write(int code, Size2D size)
    {
      this.Write(code, (object) size.X);
      this.Write(code + 10, (object) size.Y);
    }

    internal void Write(int code, WW.Math.Point2D p)
    {
      this.Write(code, (object) p.X);
      this.Write(code + 10, (object) p.Y);
    }

    internal void Write(int code, WW.Math.Vector3D v)
    {
      this.Write(code, (object) v.X);
      this.Write(code + 10, (object) v.Y);
      this.Write(code + 20, (object) v.Z);
    }

    internal void Write(int code, Vector2D v)
    {
      this.Write(code, (object) v.X);
      this.Write(code + 10, (object) v.Y);
    }

    internal void method_224(int code, double radians)
    {
      this.Write(code, (object) (180.0 / System.Math.PI * radians));
    }

    internal void method_225(WW.Math.Vector3D v)
    {
      if (!(v != WW.Math.Vector3D.ZAxis))
        return;
      this.Write(210, v);
    }

    internal void method_226(WW.Math.Vector3D v)
    {
      this.Write(210, v);
    }

    private void method_227(int groupCode, ArgbColor color)
    {
      int num = color.Argb & 16777215;
      if (num == 0)
        return;
      this.Write(groupCode, (object) num);
    }

    internal void method_228(int code, EntityColor color)
    {
      this.method_229(code, color, false);
    }

    internal void method_229(int code, EntityColor color, bool alwaysWriteGroup)
    {
      if (color == EntityColor.ByLayer)
      {
        if (!alwaysWriteGroup)
          return;
        this.method_219(code, (short) 256);
      }
      else if (color == EntityColor.ByBlock)
        this.method_219(code, (short) 0);
      else if (color.ColorType == ColorType.ByColorIndex)
      {
        this.method_219(code, color.ColorIndex);
      }
      else
      {
        this.method_219(code, DxfIndexedColorSet.GetColorIndex(color.ToArgbColor()));
        if (this.dxfVersion_0 <= DxfVersion.Dxf15 || color.ColorType != ColorType.ByColor)
          return;
        this.Write(358 + code, (object) color.Rgb);
      }
    }

    internal void method_230(int code, Color color)
    {
      this.method_231(code, color, false);
    }

    internal void method_231(int code, Color color, bool alwaysWriteGroup)
    {
      this.method_232(code, color, Color.ByLayer, alwaysWriteGroup);
    }

    internal void method_232(int code, Color color, Color defaultColor, bool alwaysWriteGroup)
    {
      this.method_233(code, color, defaultColor, alwaysWriteGroup, true);
    }

    internal void method_233(
      int code,
      Color color,
      Color defaultColor,
      bool alwaysWriteGroup,
      bool writeTrueColor)
    {
      if (!(color != defaultColor) && !alwaysWriteGroup)
        return;
      if (color == Color.ByLayer)
        this.method_219(code, (short) 256);
      else if (color == Color.ByBlock)
        this.method_219(code, (short) 0);
      else if (color.ColorType == ColorType.ByColorIndex)
      {
        this.method_219(code, color.ColorIndex);
      }
      else
      {
        this.method_219(code, DxfIndexedColorSet.GetColorIndex(color.ToArgbColor(DxfIndexedColorSet.AcadClassicIndexedColors)));
        if (this.dxfVersion_0 <= DxfVersion.Dxf15 || !writeTrueColor)
          return;
        if (color.ColorType == ColorType.ByColor)
          this.Write(358 + code, (object) color.Rgb);
        if (string.IsNullOrEmpty(color.Name) && string.IsNullOrEmpty(color.ColorBookName))
          return;
        this.Write(368 + code, (object) color.method_0());
      }
    }

    internal void method_234(string acClassName)
    {
      if (!this.dxfModel_0.Header.Dxf13OrHigher)
        return;
      this.Write(100, (object) acClassName);
    }

    private void method_235(int code, DxfHandledObject o)
    {
      this.Write(1070, (object) (short) code);
      this.Write(1005, o == null ? (object) string.Empty : (object) o.HandleString);
    }

    private void method_236(int code, string s)
    {
      this.Write(1070, (object) (short) code);
      this.Write(1000, (object) s);
    }

    private void method_237(int code, short i)
    {
      this.Write(1070, (object) (short) code);
      this.Write(1070, (object) i);
    }

    private void method_238(int code, ushort i)
    {
      this.Write(1070, (object) (short) code);
      this.Write(1070, (object) (short) i);
    }

    private void method_239(int code, int i)
    {
      this.Write(1070, (object) (short) code);
      this.Write(1071, (object) i);
    }

    private void method_240(int code, bool b)
    {
      this.method_237(code, b ? (short) 1 : (short) 0);
    }

    private void method_241(int code, double d)
    {
      this.Write(1070, (object) (short) code);
      this.Write(1040, (object) d);
    }

    private void method_242(string entityName)
    {
      UnsupportedObject unsupportedObject;
      if (!this.dictionary_0.TryGetValue(entityName, out unsupportedObject))
      {
        unsupportedObject = new UnsupportedObject(entityName);
        this.dictionary_0[entityName] = unsupportedObject;
      }
      ++unsupportedObject.Count;
    }

    private string method_243(string name)
    {
      return Class721.smethod_0(this.dxfVersion_0, name);
    }

    public enum ResourceTypes : short
    {
      Unknown,
      Name,
      String,
      Bool,
      Integer8,
      Integer16,
      Integer32,
      Double,
      Angle,
      Point,
      BinaryChunk,
      LayerName,
      Handle,
      ObjectId,
      SoftPointerId,
      HardPointerId,
      SoftOwnershipId,
      HardOwnershipId,
      Integer64,
    }

    private class Class38 : IEntityVisitor
    {
      private readonly DxfWriter dxfWriter_0;

      public Class38(DxfWriter writer)
      {
        this.dxfWriter_0 = writer;
      }

      public void Visit(Dxf3DFace face)
      {
        this.dxfWriter_0.method_129(face);
        this.dxfWriter_0.method_116((DxfHandledObject) face);
      }

      public void Visit(DxfArc arc)
      {
        this.dxfWriter_0.method_118(arc);
        this.dxfWriter_0.method_116((DxfHandledObject) arc);
      }

      public void Visit(DxfAttribute attribute)
      {
        this.dxfWriter_0.method_173(attribute);
        this.dxfWriter_0.method_116((DxfHandledObject) attribute);
      }

      public void Visit(DxfAttributeDefinition attributeDefinition)
      {
        this.dxfWriter_0.method_172(attributeDefinition);
        this.dxfWriter_0.method_116((DxfHandledObject) attributeDefinition);
      }

      public void Visit(DxfCircle circle)
      {
        this.dxfWriter_0.method_119(circle);
        this.dxfWriter_0.method_116((DxfHandledObject) circle);
      }

      public void Visit(DxfDimension.Aligned dimension)
      {
        this.dxfWriter_0.method_121(dimension, Enum25.const_1);
        this.dxfWriter_0.method_116((DxfHandledObject) dimension);
      }

      public void Visit(DxfDimension.Angular3Point dimension)
      {
        this.dxfWriter_0.method_125(dimension);
        this.dxfWriter_0.method_116((DxfHandledObject) dimension);
      }

      public void Visit(DxfDimension.Angular4Point dimension)
      {
        this.dxfWriter_0.method_126(dimension);
        this.dxfWriter_0.method_116((DxfHandledObject) dimension);
      }

      public void Visit(DxfDimension.Diametric dimension)
      {
        this.dxfWriter_0.method_123(dimension);
        this.dxfWriter_0.method_116((DxfHandledObject) dimension);
      }

      public void Visit(DxfDimension.Linear dimension)
      {
        this.dxfWriter_0.method_122(dimension);
        this.dxfWriter_0.method_116((DxfHandledObject) dimension);
      }

      public void Visit(DxfDimension.Ordinate dimension)
      {
        this.dxfWriter_0.method_127(dimension);
        this.dxfWriter_0.method_116((DxfHandledObject) dimension);
      }

      public void Visit(DxfDimension.Radial dimension)
      {
        this.dxfWriter_0.method_124(dimension);
        this.dxfWriter_0.method_116((DxfHandledObject) dimension);
      }

      public void Visit(DxfEllipse ellipse)
      {
        this.dxfWriter_0.method_128(ellipse);
        this.dxfWriter_0.method_116((DxfHandledObject) ellipse);
      }

      public void Visit(DxfHatch hatch)
      {
        this.dxfWriter_0.method_174(hatch);
        this.dxfWriter_0.method_116((DxfHandledObject) hatch);
      }

      public void Visit(DxfImage image)
      {
        this.dxfWriter_0.method_130(image);
        this.dxfWriter_0.method_116((DxfHandledObject) image);
      }

      public void Visit(DxfWipeout image)
      {
        this.dxfWriter_0.method_131(image);
        this.dxfWriter_0.method_116((DxfHandledObject) image);
      }

      public void Visit(DxfInsert insert)
      {
        this.dxfWriter_0.method_132(insert);
      }

      public void Visit(DxfIDBlockReference insert)
      {
        this.dxfWriter_0.method_132((DxfInsert) insert);
      }

      public void Visit(DxfLeader leader)
      {
        this.dxfWriter_0.method_133(leader);
        this.dxfWriter_0.method_116((DxfHandledObject) leader);
      }

      public void Visit(DxfLine line)
      {
        this.dxfWriter_0.method_134(line);
        this.dxfWriter_0.method_116((DxfHandledObject) line);
      }

      public void Visit(DxfLwPolyline polyline)
      {
        this.dxfWriter_0.method_152(polyline);
        this.dxfWriter_0.method_116((DxfHandledObject) polyline);
      }

      public void Visit(DxfMeshFace meshFace)
      {
      }

      public void Visit(DxfMLeader mleader)
      {
        mleader.Write(this.dxfWriter_0);
        this.dxfWriter_0.method_116((DxfHandledObject) mleader);
      }

      public void Visit(DxfMLine mline)
      {
        this.dxfWriter_0.method_148(mline);
        this.dxfWriter_0.method_116((DxfHandledObject) mline);
      }

      public void Visit(DxfMText mtext)
      {
        this.dxfWriter_0.method_171(mtext);
        this.dxfWriter_0.method_116((DxfHandledObject) mtext);
      }

      public void Visit(DxfPoint point)
      {
        this.dxfWriter_0.method_151(point);
        this.dxfWriter_0.method_116((DxfHandledObject) point);
      }

      public void Visit(DxfPolyfaceMesh mesh)
      {
        this.dxfWriter_0.method_160(mesh);
      }

      public void Visit(DxfPolygonMesh mesh)
      {
        this.dxfWriter_0.method_158(mesh);
      }

      public void Visit(DxfPolygonSplineMesh mesh)
      {
        this.dxfWriter_0.method_159(mesh);
      }

      public void Visit(DxfPolyline2D polyline)
      {
        this.dxfWriter_0.method_156(polyline);
      }

      public void Visit(DxfPolyline2DSpline polyline)
      {
        this.dxfWriter_0.method_157(polyline);
      }

      public void Visit(DxfPolyline3D polyline)
      {
        this.dxfWriter_0.method_154(polyline);
      }

      public void Visit(DxfPolyline3DSpline polyline)
      {
        this.dxfWriter_0.method_155(polyline);
      }

      public void Visit(DxfProxyEntity proxyEntity)
      {
        proxyEntity.Write(this.dxfWriter_0);
        this.dxfWriter_0.method_116((DxfHandledObject) proxyEntity);
      }

      public void Visit(DxfRay ray)
      {
        this.dxfWriter_0.method_135(ray);
        this.dxfWriter_0.method_116((DxfHandledObject) ray);
      }

      public void Visit(DxfRegion region)
      {
        this.dxfWriter_0.method_138(region);
        this.dxfWriter_0.method_116((DxfHandledObject) region);
      }

      public void Visit(DxfBody body)
      {
        this.dxfWriter_0.method_139(body);
        this.dxfWriter_0.method_116((DxfHandledObject) body);
      }

      public void Visit(Dxf3DSolid solid)
      {
        this.dxfWriter_0.method_136(solid);
        this.dxfWriter_0.method_116((DxfHandledObject) solid);
      }

      public void Visit(DxfSequenceEnd sequenceEnd)
      {
      }

      public void Visit(DxfShape shape)
      {
        this.dxfWriter_0.method_167(shape);
        this.dxfWriter_0.method_116((DxfHandledObject) shape);
      }

      public void Visit(DxfSolid solid)
      {
        this.dxfWriter_0.method_168(solid);
        this.dxfWriter_0.method_116((DxfHandledObject) solid);
      }

      public void Visit(DxfSpline spline)
      {
        bool flag = false;
        if (!spline.Rational && spline.ControlPoints.Count == 0 && (spline.Knots.Count == 0 && spline.FitPoints.Count >= 4) && spline.KnotParameterization != KnotParameterization.Custom)
          flag = spline.UpdateSplineFromFitPoints();
        this.dxfWriter_0.method_169(spline);
        if (flag)
        {
          spline.ControlPoints.Clear();
          spline.FitPoints.Clear();
        }
        this.dxfWriter_0.method_116((DxfHandledObject) spline);
      }

      public void Visit(DxfTable table)
      {
        this.dxfWriter_0.method_149(table);
        this.dxfWriter_0.method_116((DxfHandledObject) table);
      }

      public void Visit(DxfText text)
      {
        this.dxfWriter_0.method_170(text, true);
        this.dxfWriter_0.method_116((DxfHandledObject) text);
      }

      public void Visit(DxfTolerance tolerance)
      {
        this.dxfWriter_0.method_177(tolerance);
        this.dxfWriter_0.method_116((DxfHandledObject) tolerance);
      }

      public void Visit(DxfVertex2D vertex)
      {
      }

      public void Visit(DxfVertex3D vertex)
      {
      }

      public void Visit(DxfViewport viewport)
      {
        if (viewport.Model.Header.Dxf15OrHigher)
          this.dxfWriter_0.method_176(viewport);
        else
          this.dxfWriter_0.method_175(viewport);
        this.dxfWriter_0.method_116((DxfHandledObject) viewport);
      }

      public void Visit(DxfXLine xline)
      {
        this.dxfWriter_0.method_146(xline);
        this.dxfWriter_0.method_116((DxfHandledObject) xline);
      }

      public void Visit(DxfOle ole)
      {
        this.dxfWriter_0.method_147(ole);
        this.dxfWriter_0.method_116((DxfHandledObject) ole);
      }
    }

    internal class Class39 : IExtendedDataValueVisitor
    {
      private DxfWriter dxfWriter_0;

      public Class39(DxfWriter writer)
      {
        this.dxfWriter_0 = writer;
      }

      public void Visit(DxfExtendedData.ValueCollection collection)
      {
        this.dxfWriter_0.Write(1002, (object) "{");
        foreach (IExtendedDataValue extendedDataValue in (List<IExtendedDataValue>) collection)
          extendedDataValue.Accept((IExtendedDataValueVisitor) this);
        this.dxfWriter_0.Write(1002, (object) "}");
      }

      public void Visit(DxfExtendedData.BinaryData value)
      {
        int num1 = value.Value.Length / (int) sbyte.MaxValue;
        int num2 = 0;
        for (int index1 = 0; index1 < num1; ++index1)
        {
          int num3 = num2 + (int) sbyte.MaxValue;
          byte[] numArray = new byte[num3 - num2];
          int index2 = num2;
          int index3 = 0;
          while (index2 < num3)
          {
            numArray[index3] = value.Value[index2];
            ++index2;
            ++index3;
          }
          this.dxfWriter_0.Write(1004, (object) numArray);
          num2 += (int) sbyte.MaxValue;
        }
        int length = value.Value.Length - num2;
        if (length <= 0)
          return;
        byte[] numArray1 = new byte[length];
        int index4 = num2;
        int index5 = 0;
        while (index4 < value.Value.Length)
        {
          numArray1[index5] = value.Value[index4];
          ++index4;
          ++index5;
        }
        this.dxfWriter_0.Write(1004, (object) numArray1);
      }

      public void Visit(DxfExtendedData.DatabaseHandle value)
      {
        if (value.Value == null)
          this.dxfWriter_0.Write(1005, (object) 0UL);
        else
          this.dxfWriter_0.Write(1005, (object) value.Value.Handle);
      }

      public void Visit(DxfExtendedData.Distance value)
      {
        this.dxfWriter_0.Write(1041, (object) value.Value);
      }

      public void Visit(DxfExtendedData.Double value)
      {
        this.dxfWriter_0.Write(1040, (object) value.Value);
      }

      public void Visit(DxfExtendedData.LayerReference value)
      {
        if (value.Value == null)
          this.dxfWriter_0.Write(1003, (object) string.Empty);
        else
          this.dxfWriter_0.Write(1003, (object) value.Value.Name);
      }

      public void Visit(DxfExtendedData.PointOrVector value)
      {
        this.dxfWriter_0.Write(1010, (object) value.X);
        this.dxfWriter_0.Write(1020, (object) value.Y);
        this.dxfWriter_0.Write(1030, (object) value.Z);
      }

      public void Visit(DxfExtendedData.ScaleFactor value)
      {
        this.dxfWriter_0.Write(1042, (object) value.Value);
      }

      public void Visit(DxfExtendedData.Int16 value)
      {
        this.dxfWriter_0.Write(1070, (object) value.Value);
      }

      public void Visit(DxfExtendedData.Int32 value)
      {
        this.dxfWriter_0.Write(1071, (object) value.Value);
      }

      public void Visit(DxfExtendedData.String value)
      {
        this.dxfWriter_0.Write(1000, (object) value.Value);
      }

      public void Visit(DxfExtendedData.Bracket value)
      {
        this.dxfWriter_0.Write(1002, value.IsClosingBracket ? (object) "}" : (object) "{");
      }

      public void Visit(DxfExtendedData.WorldDirection value)
      {
        this.dxfWriter_0.Write(1010, (object) value.X);
        this.dxfWriter_0.Write(1020, (object) value.Y);
        this.dxfWriter_0.Write(1030, (object) value.Z);
      }

      public void Visit(DxfExtendedData.WorldSpaceDisplacement value)
      {
        this.dxfWriter_0.Write(1010, (object) value.X);
        this.dxfWriter_0.Write(1020, (object) value.Y);
        this.dxfWriter_0.Write(1030, (object) value.Z);
      }

      public void Visit(DxfExtendedData.WorldSpacePosition value)
      {
        this.dxfWriter_0.Write(1010, (object) value.X);
        this.dxfWriter_0.Write(1020, (object) value.Y);
        this.dxfWriter_0.Write(1030, (object) value.Z);
      }
    }
  }
}
