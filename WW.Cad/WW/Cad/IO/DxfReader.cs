// Decompiled with JetBrains decompiler
// Type: WW.Cad.IO.DxfReader
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns1;
using ns2;
using ns27;
using ns28;
using ns3;
using ns36;
using ns38;
using ns42;
using ns43;
using ns6;
using System;
using System.Collections.Generic;
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
using WW.Math;
using WW.Math.Geometry;
using WW.Text;

namespace WW.Cad.IO
{
  public class DxfReader : IDisposable
  {
    private static readonly Dictionary<string, DxfReader.Delegate0> dictionary_1 = new Dictionary<string, DxfReader.Delegate0>();
    private bool bool_1 = true;
    private readonly DxfMessageCollection dxfMessageCollection_0 = new DxfMessageCollection();
    private readonly List<string> list_0 = new List<string>();
    private readonly List<DxfEntity> list_1 = new List<DxfEntity>();
    private readonly List<Pair<DxfEntity, string>> list_2 = new List<Pair<DxfEntity, string>>();
    private readonly List<Pair<DxfLayer, string>> list_3 = new List<Pair<DxfLayer, string>>();
    private readonly List<Pair<DxfEntity, string>> list_4 = new List<Pair<DxfEntity, string>>();
    private readonly List<Pair<DxfRasterImage, ulong>> list_5 = new List<Pair<DxfRasterImage, ulong>>();
    private readonly List<Pair<DxfMLineStyle.Element, string>> list_6 = new List<Pair<DxfMLineStyle.Element, string>>();
    private readonly List<Pair<DxfView, ulong>> list_7 = new List<Pair<DxfView, ulong>>();
    private readonly List<Pair<DxfVPort, ulong>> list_8 = new List<Pair<DxfVPort, ulong>>();
    private readonly Dictionary<string, UnsupportedObject> dictionary_0 = new Dictionary<string, UnsupportedObject>();
    private readonly List<Pair<DxfDimension, string>> list_9 = new List<Pair<DxfDimension, string>>();
    private readonly List<Pair<DxfMLine, ulong>> list_10 = new List<Pair<DxfMLine, ulong>>();
    private readonly List<Pair<DxfLeader, ulong>> list_11 = new List<Pair<DxfLeader, ulong>>();
    private readonly List<Pair<DxfViewport, ulong>> list_12 = new List<Pair<DxfViewport, ulong>>();
    private readonly int int_3 = 2000;
    private bool bool_4 = true;
    internal const double double_0 = 0.0174532925199433;
    private Interface33 interface33_0;
    private Class375 class375_0;
    private bool bool_0;
    private Stream stream_0;
    private string string_0;
    private int int_0;
    private readonly long long_0;
    private int int_1;
    private bool bool_2;
    private bool bool_3;
    private Struct18 struct18_0;
    private DxfModel dxfModel_0;
    private readonly int int_2;

    private void method_0(Class260 objectBuilder)
    {
      objectBuilder.HandledObject.method_5(this, (Class259) objectBuilder);
      Class276 class276 = objectBuilder as Class276;
      DxfEvalGraph dxfEvalGraph = (DxfEvalGraph) objectBuilder.Object;
      this.method_91("AcDbEvalGraph");
      DxfEvalGraph.GraphNode[] array1 = new DxfEvalGraph.GraphNode[0];
      ulong[] array2 = new ulong[0];
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 91:
            int index1 = 0;
            while (this.struct18_0.Code == 91)
            {
              this.method_85();
              this.method_135(93);
              Array.Resize<DxfEvalGraph.GraphNode>(ref array1, index1 + 1);
              array1[index1] = new DxfEvalGraph.GraphNode();
              this.method_85();
              array1[index1].Id = new DxfEvalGraph.GraphNodeId(this.method_141(95));
              this.method_85();
              ulong num = this.method_143(360);
              Array.Resize<ulong>(ref array2, index1 + 1);
              array2[index1] = num;
              if (class276.ListNode == null)
                this.class375_0.ObjectBuilders.Add((Class259) class276);
              this.method_85();
              array1[index1].FirstIncomingEdge = this.method_141(92);
              this.method_85();
              array1[index1].LastIncomingEdge = this.method_141(92);
              this.method_85();
              array1[index1].FirstOutgoingEdge = this.method_141(92);
              this.method_85();
              array1[index1].LastOutgoingEdge = this.method_141(92);
              ++index1;
              this.method_85();
            }
            dxfEvalGraph.Nodes = array1;
            continue;
          case 92:
            int index2 = 0;
            DxfEvalGraph.GraphEdge[] array3 = new DxfEvalGraph.GraphEdge[0];
            while (this.struct18_0.Code == 92)
            {
              this.method_141(92);
              Array.Resize<DxfEvalGraph.GraphEdge>(ref array3, index2 + 1);
              array3[index2] = new DxfEvalGraph.GraphEdge();
              this.method_85();
              array3[index2].Flags = this.method_141(93);
              this.method_85();
              array3[index2].ReferenceCount = this.method_141(94);
              this.method_85();
              array3[index2].StartNode = this.method_141(91);
              this.method_85();
              array3[index2].EndNode = this.method_141(91);
              this.method_85();
              array3[index2].PreviousIncoming = this.method_141(92);
              this.method_85();
              array3[index2].NextIncoming = this.method_141(92);
              this.method_85();
              array3[index2].PreviousOutgoing = this.method_141(92);
              this.method_85();
              array3[index2].NextOutgoing = this.method_141(92);
              this.method_85();
              array3[index2].ReverseEdgeIndex = this.method_141(92);
              this.method_85();
              ++index2;
            }
            dxfEvalGraph.Edges = array3;
            continue;
          case 96:
            dxfEvalGraph.LastNodeId = new DxfEvalGraph.GraphNodeId(this.method_141(96));
            break;
          case 97:
            this.method_135(97);
            break;
          default:
            if (dxfEvalGraph.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
      class276.ExpressionHandles = array2;
      if (dxfEvalGraph.Nodes == null)
        dxfEvalGraph.Nodes = new DxfEvalGraph.GraphNode[0];
      if (dxfEvalGraph.Edges != null)
        return;
      dxfEvalGraph.Edges = new DxfEvalGraph.GraphEdge[0];
    }

    private void method_1(DxfEvalGraph evalGraph)
    {
      Class276 class276 = new Class276(evalGraph);
      this.class375_0.ObjectBuilders.Add((Class259) class276);
      this.method_0((Class260) class276);
    }

    private void method_2(DxfBlockSinglePointParameter o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_68(objectBuilder);
    }

    private void method_3(DxfBlockTwoPointsParameter o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_67(objectBuilder, true);
    }

    private void method_4(DxfBlockBasePointParameter o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_59(objectBuilder);
    }

    private void method_5(DxfBlockUserParameter o)
    {
      Class272 objectBuilder = new Class272(o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_60(objectBuilder);
    }

    private void method_6(DxfBlockPolarParameter o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_50(objectBuilder);
    }

    private void method_7(DxfBlockFlipAction o)
    {
      Class268 objectBuilder = new Class268((DxfBlockAction) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_57(objectBuilder);
    }

    private void method_8(DxfBlockLookupAction o)
    {
      Class268 objectBuilder = new Class268((DxfBlockAction) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_54(objectBuilder);
    }

    private void method_9(DxfBlockMoveAction o)
    {
      Class268 objectBuilder = new Class268((DxfBlockAction) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_52(objectBuilder);
    }

    private void method_10(DxfBlockStretchAction o)
    {
      Class269 objectBuilder = new Class269(o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_45(objectBuilder);
    }

    private void method_11(DxfBlockPolarStretchAction o)
    {
      Class270 objectBuilder = new Class270(o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_49(objectBuilder);
    }

    private void method_12(DxfBlockArrayAction o)
    {
      Class268 objectBuilder = new Class268((DxfBlockAction) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_61(objectBuilder);
    }

    private void method_13(DxfBlockScaleAction o)
    {
      Class268 objectBuilder = new Class268((DxfBlockAction) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_46(objectBuilder);
    }

    private void method_14(DxfBlockRotateAction o)
    {
      Class268 objectBuilder = new Class268((DxfBlockAction) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_48(objectBuilder);
    }

    private void method_15(DxfBlockRotationParameter o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_47(objectBuilder);
    }

    private void method_16(DxfBlockXYParameter o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_38(objectBuilder);
    }

    private void method_17(DxfBlockLinearParameter o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_55(objectBuilder);
    }

    private void method_18(DxfBlockFlipParameter o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_56(objectBuilder);
    }

    private void method_19(DxfBlockAlignmentGrip o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_81(objectBuilder);
    }

    private void method_20(DxfBlockFlipGrip o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_78(objectBuilder);
    }

    private void method_21(DxfBlockRepresentationData o)
    {
      Class277 objectBuilder = new Class277(o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_80(objectBuilder);
    }

    private void method_22(DxfBlockPurgePreventer o)
    {
      Class260 objectBuilder = new Class260((DxfObject) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_79(objectBuilder);
    }

    private void method_23(DxfBlockGripExpression o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_83(objectBuilder);
    }

    private void method_24(DxfDynamicBlockProxyNode o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_84(objectBuilder);
    }

    private void method_25(DxfBlockLinearGrip o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_77(objectBuilder);
    }

    private void method_26(DxfBlockLookupGrip o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_76(objectBuilder);
    }

    private void method_27(DxfBlockPolarGrip o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_74(objectBuilder);
    }

    private void method_28(DxfBlockPropertiesTableGrip o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_75(objectBuilder);
    }

    private void method_29(DxfBlockRotationGrip o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_73(objectBuilder);
    }

    private void method_30(DxfBlockVisibilityGrip o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_72(objectBuilder);
    }

    private void method_31(DxfBlockXYGrip o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_82(objectBuilder);
    }

    private void method_32(DxfBlockAlignmentParameter o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_62(objectBuilder);
    }

    private void method_33(DxfBlockLookUpParameter o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_53(objectBuilder);
    }

    private void method_34(DxfBlockVisibilityParameter o)
    {
      Class267 objectBuilder = new Class267(o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_39(objectBuilder);
    }

    private void method_35(DxfBlockPropertiesTable o)
    {
      Class271 class271 = new Class271((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) class271);
      this.method_41((Class260) class271);
    }

    private void method_36(DxfBlockPointParameter o)
    {
      Class265 objectBuilder = new Class265((DxfEvalGraphExpression) o);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_68(objectBuilder);
      this.method_91("AcDbBlockPointParameter");
      this.method_85();
      this.method_135(303);
      o.LabelText = (string) this.struct18_0.Value;
      this.method_85();
      this.method_135(304);
      o.Description = (string) this.struct18_0.Value;
      this.method_85();
      this.method_135(1011);
      o.LabelPosition = this.method_154();
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        if (!o.method_6(this, (Class259) objectBuilder))
          this.method_85();
      }
    }

    internal DxfBlockParametersValueSet method_37(
      short n1,
      short n2,
      short n3,
      short n4)
    {
      DxfBlockParametersValueSet parametersValueSet = new DxfBlockParametersValueSet();
      this.method_138((int) n4);
      this.method_85();
      parametersValueSet.ValueSetFlags = (byte) this.method_141((int) n1);
      this.method_85();
      parametersValueSet.BoundedBelow = this.method_140((int) n2);
      this.method_85();
      parametersValueSet.BoundedAbove = this.method_140((int) n2 + 1);
      this.method_85();
      parametersValueSet.Increment = this.method_140((int) n2 + 2);
      this.method_85();
      int length = (int) this.method_139((int) n3);
      if (length != 0)
      {
        parametersValueSet.List = new double[length];
        for (int index = 0; index < parametersValueSet.List.Length; ++index)
        {
          this.method_85();
          parametersValueSet.List[index] = this.method_140((int) n2 + 3);
        }
      }
      else
        parametersValueSet.List = (double[]) null;
      return parametersValueSet;
    }

    private void method_38(Class265 objectBuilder)
    {
      DxfBlockXYParameter blockXyParameter = (DxfBlockXYParameter) objectBuilder.Object;
      this.method_67(objectBuilder, true);
      this.method_91("AcDbBlockXYParameter");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 140:
            blockXyParameter.LabelOffsetY = (double) this.struct18_0.Value;
            break;
          case 141:
            blockXyParameter.LabelOffsetX = (double) this.struct18_0.Value;
            break;
          case 305:
            blockXyParameter.LabelTextY = (string) this.struct18_0.Value;
            break;
          case 306:
            blockXyParameter.LabelTextX = (string) this.struct18_0.Value;
            break;
          case 307:
            blockXyParameter.DescriptionY = (string) this.struct18_0.Value;
            break;
          case 308:
            blockXyParameter.DescriptionX = (string) this.struct18_0.Value;
            break;
          case 309:
            blockXyParameter.ParameterValueSetY = this.method_37((short) 97, (short) 146, (short) 176, (short) 309);
            break;
          case 410:
            blockXyParameter.ParameterValueSetX = this.method_37((short) 96, (short) 142, (short) 175, (short) 410);
            break;
          default:
            if (blockXyParameter.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_39(Class267 objectBuilder)
    {
      DxfBlockVisibilityParameter visibilityParameter = (DxfBlockVisibilityParameter) objectBuilder.Object;
      this.method_68((Class265) objectBuilder);
      this.method_91("AcDbBlockVisibilityParameter");
      ulong[] numArray1 = (ulong[]) null;
      ulong[][] numArray2 = (ulong[][]) null;
      ulong[][] numArray3 = (ulong[][]) null;
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 91:
            visibilityParameter.UnknownFlag2 = (int) this.struct18_0.Value != 0;
            break;
          case 92:
            int length1 = (int) this.struct18_0.Value;
            visibilityParameter.VisibilityStates = new DxfVisibilityState[length1];
            numArray2 = new ulong[length1][];
            numArray3 = new ulong[length1][];
            for (int index1 = 0; index1 < length1; ++index1)
            {
              this.method_85();
              this.method_135(303);
              visibilityParameter.VisibilityStates[index1] = new DxfVisibilityState();
              visibilityParameter.VisibilityStates[index1].Name = (string) this.struct18_0.Value;
              this.method_85();
              this.method_135(94);
              int length2 = (int) this.struct18_0.Value;
              numArray2[index1] = new ulong[length2];
              for (int index2 = 0; index2 < length2; ++index2)
              {
                this.method_85();
                this.method_135(332);
                numArray2[index1][index2] = (ulong) this.struct18_0.Value;
              }
              this.method_85();
              this.method_135(95);
              int length3 = (int) this.struct18_0.Value;
              numArray3[index1] = new ulong[length3];
              for (int index2 = 0; index2 < length3; ++index2)
              {
                this.method_85();
                this.method_135(333);
                numArray3[index1][index2] = (ulong) this.struct18_0.Value;
              }
            }
            break;
          case 93:
            int length4 = (int) this.struct18_0.Value;
            numArray1 = new ulong[length4];
            for (int index = 0; index < length4; ++index)
            {
              this.method_85();
              numArray1[index] = this.method_143(331);
            }
            break;
          case 281:
            visibilityParameter.UnknownFlag = (byte) this.struct18_0.Value != (byte) 0;
            break;
          case 301:
            visibilityParameter.LabelText = (string) this.struct18_0.Value;
            break;
          case 302:
            visibilityParameter.Description = (string) this.struct18_0.Value;
            break;
          default:
            if (visibilityParameter.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
      objectBuilder.HandleSet = numArray1;
      objectBuilder.SelectionSet1 = numArray2;
      objectBuilder.SelectionSet2 = numArray3;
    }

    private DxfBlockPropertiesTableColumnDefinition method_40(
      Class271 ob,
      ref ulong parameterHandle,
      ref ulong unknownHandle)
    {
      DxfBlockPropertiesTableColumnDefinition columnDefinition = new DxfBlockPropertiesTableColumnDefinition();
      parameterHandle = this.method_142(340);
      columnDefinition.Parameter = (DxfObject) null;
      this.method_85();
      columnDefinition.UnknownInt1 = this.method_139(170);
      this.method_85();
      columnDefinition.UnknownInt2 = this.method_139(171);
      this.method_85();
      columnDefinition.UnknownString1 = this.method_138(300);
      this.method_85();
      columnDefinition.ConnectionPoint.ConnectionString = this.method_138(301);
      this.method_85();
      columnDefinition.ConnectionPoint.ConnectionPointId = new DxfEvalGraph.GraphNodeId(this.method_141(90));
      this.method_85();
      Class485 objectBuilder1 = (Class485) null;
      Class485 objectBuilder2 = (Class485) null;
      columnDefinition.UnknownValue1 = this.method_69(170, ref objectBuilder1);
      if (objectBuilder1 != null)
        ob.XRecordHandles.Add(objectBuilder1);
      this.method_85();
      columnDefinition.DefaultDoNotMatchValue = this.method_69(170, ref objectBuilder2);
      if (objectBuilder2 != null)
        ob.XRecordHandles.Add(objectBuilder2);
      this.method_85();
      columnDefinition.UnknownFlag1 = this.method_137(290);
      this.method_85();
      columnDefinition.UnknownFlag2 = this.method_137(291);
      this.method_85();
      columnDefinition.UnknownFlag3 = this.method_137(292);
      this.method_85();
      columnDefinition.UnknownFlag4 = this.method_137(293);
      this.method_85();
      columnDefinition.UnknownFlag5 = this.method_137(294);
      this.method_85();
      columnDefinition.UnknownString2 = this.method_138(302);
      this.method_85();
      unknownHandle = this.method_142(340);
      columnDefinition.UnknownObject1 = (DxfObject) null;
      this.method_85();
      return columnDefinition;
    }

    private void method_41(Class260 objectBuilder)
    {
      Class271 ob = objectBuilder as Class271;
      DxfBlockPropertiesTable blockPropertiesTable = ob.Object as DxfBlockPropertiesTable;
      this.method_68((Class265) ob);
      this.method_91("AcDbBlockPropertiesTable");
      int length1 = 0;
      ulong[] numArray1 = (ulong[]) null;
      ulong[] numArray2 = (ulong[]) null;
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 90:
            blockPropertiesTable.NodeId = new DxfEvalGraph.GraphNodeId(this.method_141(90));
            break;
          case 91:
            length1 = this.method_141(91);
            blockPropertiesTable.ColumnInformation = new DxfBlockPropertiesTableColumnDefinition[length1];
            numArray1 = new ulong[length1];
            numArray2 = new ulong[length1];
            this.method_85();
            for (int index = 0; index < length1; ++index)
              blockPropertiesTable.ColumnInformation[index] = this.method_40(ob, ref numArray1[index], ref numArray2[index]);
            break;
          case 92:
            int length2 = this.method_141(92);
            DxfXRecordValue[][] dxfXrecordValueArray = new DxfXRecordValue[length1][];
            for (int index = 0; index < length1; ++index)
              dxfXrecordValueArray[index] = new DxfXRecordValue[length2];
            blockPropertiesTable.DataNodeId = new int[length2];
            this.method_85();
            for (int index1 = 0; index1 < length2; ++index1)
            {
              blockPropertiesTable.DataNodeId[index1] = this.method_141(90);
              this.method_85();
              dxfXrecordValueArray[index1] = new DxfXRecordValue[length2];
              for (int index2 = 0; index2 < length1; ++index2)
              {
                Class485 objectBuilder1 = (Class485) null;
                dxfXrecordValueArray[index2][index1] = this.method_69(170, ref objectBuilder1);
                if (objectBuilder1 != null)
                  ob.XRecordHandles.Add(objectBuilder1);
                this.method_85();
              }
            }
            blockPropertiesTable.Data = dxfXrecordValueArray;
            break;
          case 93:
            blockPropertiesTable.Unknown1 = this.method_141(93);
            break;
          case 290:
            blockPropertiesTable.PropertiesCanBeModifiedIndividually = (bool) this.struct18_0.Value;
            break;
          case 291:
            blockPropertiesTable.UnknownFlag2 = (bool) this.struct18_0.Value;
            break;
          case 292:
            blockPropertiesTable.UnknownFlag3 = (bool) this.struct18_0.Value;
            break;
          case 300:
            blockPropertiesTable.TableName = (string) this.struct18_0.Value;
            break;
          case 301:
            blockPropertiesTable.DescriptionString = (string) this.struct18_0.Value;
            break;
          default:
            if (blockPropertiesTable.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
      ob.Parameters = numArray1;
      ob.DxfObjects2 = numArray2;
    }

    private DxfConnectionPoint[] method_42(
      int size,
      int idGroupCode,
      int stringGroupCode)
    {
      DxfConnectionPoint[] dxfConnectionPointArray = new DxfConnectionPoint[size];
      for (int index = 0; index < size; ++index)
        dxfConnectionPointArray[index] = new DxfConnectionPoint();
      int num = size + size;
      this.method_85();
      while (true)
      {
        int index1 = this.struct18_0.Code - idGroupCode;
        if (this.struct18_0.Code < idGroupCode || index1 >= size)
        {
          int index2 = this.struct18_0.Code - stringGroupCode;
          if (this.struct18_0.Code >= stringGroupCode && index2 < size)
          {
            dxfConnectionPointArray[index2].ConnectionString = this.method_138(stringGroupCode + index2);
            --num;
          }
          else
            break;
        }
        else
          goto label_8;
label_6:
        if (num > 0)
        {
          this.method_85();
          continue;
        }
        goto label_11;
label_8:
        dxfConnectionPointArray[index1].ConnectionPointId = new DxfEvalGraph.GraphNodeId(this.method_141(idGroupCode + index1));
        --num;
        goto label_6;
      }
      throw new Exception("ReadActionConnections DXF sequence broken");
label_11:
      return dxfConnectionPointArray;
    }

    private DxfConnectionPoint method_43(int idGroupCode, int stringGroupCode)
    {
      DxfConnectionPoint dxfConnectionPoint = new DxfConnectionPoint();
      this.method_85();
      dxfConnectionPoint.ConnectionPointId = new DxfEvalGraph.GraphNodeId(this.method_141(idGroupCode));
      this.method_85();
      dxfConnectionPoint.ConnectionString = this.method_138(stringGroupCode);
      return dxfConnectionPoint;
    }

    private void method_44(ref DxfBlockAngleOffsetAction o)
    {
      o.DistanceCoefficient = this.method_140(140);
      this.method_85();
      o.AngleOffset = this.method_140(141);
      this.method_85();
      o.ScaleType = (DxfBlockAction.ScaleTypeXY) this.method_136(280);
    }

    private void method_45(Class269 objectBuilder)
    {
      DxfBlockStretchAction blockStretchAction = (DxfBlockStretchAction) objectBuilder.Object;
      this.method_65((Class268) objectBuilder);
      this.method_91("AcDbBlockStretchAction");
      blockStretchAction.ActionConnections = this.method_42(blockStretchAction.ActionConnections.Length, 92, 301);
      blockStretchAction.StretchNodes = (DxfBlockPolarStretchAction.StretchNode[]) null;
      blockStretchAction.Frame = (WW.Math.Point2D[]) null;
      blockStretchAction.StretchEntities = (DxfBlockPolarStretchAction.StretchEntity[]) null;
      ulong[] numArray = (ulong[]) null;
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 72:
            int length1 = (int) (short) this.struct18_0.Value;
            if (length1 != 0)
            {
              blockStretchAction.Frame = new WW.Math.Point2D[length1];
              for (int index = 0; index < length1; ++index)
              {
                this.method_85();
                this.method_135(1011);
                blockStretchAction.Frame[index] = this.method_155();
              }
              break;
            }
            break;
          case 73:
            int length2 = (int) (short) this.struct18_0.Value;
            if (length2 != 0)
            {
              blockStretchAction.StretchEntities = new DxfBlockPolarStretchAction.StretchEntity[length2];
              numArray = new ulong[length2];
              for (int index1 = 0; index1 < length2; ++index1)
              {
                this.method_85();
                this.method_135(331);
                blockStretchAction.StretchEntities[index1].Entity = (DxfHandledObject) null;
                numArray[index1] = (ulong) this.struct18_0.Value;
                this.method_85();
                int length3 = (int) this.method_139(74);
                blockStretchAction.StretchEntities[index1].PointIndexes = new int[length3];
                for (int index2 = 0; index2 < length3; ++index2)
                {
                  this.method_85();
                  this.method_135(94);
                  blockStretchAction.StretchEntities[index1].PointIndexes[index2] = (int) this.struct18_0.Value;
                }
              }
              break;
            }
            break;
          case 75:
            int length4 = (int) (short) this.struct18_0.Value;
            if (length4 != 0)
            {
              blockStretchAction.StretchNodes = new DxfBlockPolarStretchAction.StretchNode[length4];
              for (int index1 = 0; index1 < length4; ++index1)
              {
                this.method_85();
                this.method_135(95);
                blockStretchAction.StretchNodes[index1].Node = new DxfEvalGraph.GraphNodeId((int) this.struct18_0.Value);
                this.method_85();
                short num = this.method_139(76);
                blockStretchAction.StretchNodes[index1].PointIndexes = new int[(int) num];
                for (int index2 = 0; index2 < (int) num; ++index2)
                {
                  this.method_85();
                  this.method_135(94);
                  blockStretchAction.StretchNodes[index1].PointIndexes[index2] = (int) this.struct18_0.Value;
                }
              }
              break;
            }
            break;
          case 140:
            DxfBlockAngleOffsetAction o = (DxfBlockAngleOffsetAction) blockStretchAction;
            this.method_44(ref o);
            break;
          default:
            if (blockStretchAction.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
      objectBuilder.StretchEntities = numArray;
    }

    private void method_46(Class268 objectBuilder)
    {
      DxfBlockScaleAction blockScaleAction = (DxfBlockScaleAction) objectBuilder.Object;
      this.method_63(objectBuilder);
      this.method_91("AcDbBlockScaleAction");
      blockScaleAction.ActionConnections = this.method_42(blockScaleAction.ActionConnections.Length, 94, 303);
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        if (!blockScaleAction.method_6(this, (Class259) objectBuilder))
          this.method_85();
      }
    }

    private void method_47(Class265 objectBuilder)
    {
      DxfBlockRotationParameter rotationParameter = (DxfBlockRotationParameter) objectBuilder.Object;
      this.method_67(objectBuilder, true);
      this.method_91("AcDbBlockRotationParameter");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 140:
            rotationParameter.LabelOffset = (double) this.struct18_0.Value;
            break;
          case 305:
            rotationParameter.LabelText = (string) this.struct18_0.Value;
            break;
          case 306:
            rotationParameter.Description = (string) this.struct18_0.Value;
            break;
          case 307:
            rotationParameter.Angle = this.method_37((short) 96, (short) 141, (short) 175, (short) 307);
            break;
          case 1011:
            rotationParameter.StartPoint = this.method_154();
            break;
          default:
            if (rotationParameter.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_48(Class268 objectBuilder)
    {
      DxfBlockRotateAction blockRotateAction = (DxfBlockRotateAction) objectBuilder.Object;
      this.method_63(objectBuilder);
      this.method_91("AcDbBlockRotationAction");
      blockRotateAction.ActionConnection = this.method_43(94, 303);
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        if (!blockRotateAction.method_6(this, (Class259) objectBuilder))
          this.method_85();
      }
    }

    private void method_49(Class270 objectBuilder)
    {
      DxfBlockPolarStretchAction polarStretchAction = (DxfBlockPolarStretchAction) objectBuilder.Object;
      this.method_65((Class268) objectBuilder);
      this.method_91("AcDbBlockPolarStretchAction");
      polarStretchAction.ActionConnections = this.method_42(polarStretchAction.ActionConnections.Length, 92, 301);
      polarStretchAction.StretchNodes = (DxfBlockPolarStretchAction.StretchNode[]) null;
      polarStretchAction.Frame = (WW.Math.Point2D[]) null;
      polarStretchAction.StretchEntities = (DxfBlockPolarStretchAction.StretchEntity[]) null;
      polarStretchAction.RotateSelection = (DxfHandledObjectCollection<DxfHandledObject>) null;
      ulong[] numArray1 = (ulong[]) null;
      ulong[] numArray2 = (ulong[]) null;
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 72:
            int length1 = (int) (short) this.struct18_0.Value;
            if (length1 != 0)
            {
              numArray1 = new ulong[length1];
              for (int index = 0; index < length1; ++index)
              {
                this.method_85();
                this.method_135(331);
                numArray1[index] = (ulong) this.struct18_0.Value;
              }
              break;
            }
            break;
          case 73:
            int length2 = (int) (short) this.struct18_0.Value;
            if (length2 != 0)
            {
              polarStretchAction.Frame = new WW.Math.Point2D[length2];
              for (int index = 0; index < length2; ++index)
              {
                this.method_85();
                this.method_135(1011);
                polarStretchAction.Frame[index] = this.method_155();
              }
              break;
            }
            break;
          case 74:
            int length3 = (int) (short) this.struct18_0.Value;
            if (length3 != 0)
            {
              numArray2 = new ulong[length3];
              polarStretchAction.StretchEntities = new DxfBlockPolarStretchAction.StretchEntity[length3];
              for (int index1 = 0; index1 < length3; ++index1)
              {
                this.method_85();
                this.method_135(332);
                numArray2[index1] = (ulong) this.struct18_0.Value;
                this.method_85();
                this.method_135(75);
                int length4 = (int) (short) this.struct18_0.Value;
                polarStretchAction.StretchEntities[index1].PointIndexes = new int[length4];
                for (int index2 = 0; index2 < length4; ++index2)
                {
                  this.method_85();
                  polarStretchAction.StretchEntities[index1].PointIndexes[index2] = (int) this.method_139(76);
                }
              }
              break;
            }
            break;
          case 77:
            int length5 = (int) (short) this.struct18_0.Value;
            if (length5 > 0)
            {
              polarStretchAction.SelectionSet2 = new DxfEvalGraph.GraphNodeId[length5];
              for (int index = 0; index < length5; ++index)
              {
                this.method_85();
                this.method_135(91);
                polarStretchAction.SelectionSet2[index] = new DxfEvalGraph.GraphNodeId((int) this.struct18_0.Value);
              }
              break;
            }
            break;
          case 78:
            int length6 = (int) (short) this.struct18_0.Value;
            if (length6 != 0)
            {
              polarStretchAction.StretchNodes = new DxfBlockPolarStretchAction.StretchNode[length6];
              for (int index1 = 0; index1 < length6; ++index1)
              {
                this.method_85();
                this.method_135(98);
                polarStretchAction.StretchNodes[index1].Node = new DxfEvalGraph.GraphNodeId((int) this.struct18_0.Value);
                this.method_85();
                this.method_135(79);
                short num = (short) this.struct18_0.Value;
                polarStretchAction.StretchNodes[index1].PointIndexes = new int[(int) num];
                for (int index2 = 0; index2 < (int) num; ++index2)
                {
                  this.method_85();
                  polarStretchAction.StretchNodes[index1].PointIndexes[index2] = (int) this.method_139(76);
                }
              }
              break;
            }
            break;
          case 140:
            polarStretchAction.AngleOffset = (double) this.struct18_0.Value;
            break;
          case 141:
            polarStretchAction.DistanceCoefficient = (double) this.struct18_0.Value;
            break;
          default:
            if (polarStretchAction.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
      objectBuilder.RotateSelection = numArray1;
      objectBuilder.StretchEntities = numArray2;
    }

    private void method_50(Class265 objectBuilder)
    {
      DxfBlockPolarParameter blockPolarParameter = (DxfBlockPolarParameter) objectBuilder.Object;
      this.method_67(objectBuilder, true);
      this.method_91("AcDbBlockPolarParameter");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 140:
            blockPolarParameter.LabelOffset = (double) this.struct18_0.Value;
            break;
          case 305:
            blockPolarParameter.LabelText = (string) this.struct18_0.Value;
            break;
          case 306:
            blockPolarParameter.Description = (string) this.struct18_0.Value;
            break;
          case 307:
            blockPolarParameter.AngleLabelText = (string) this.struct18_0.Value;
            break;
          case 308:
            blockPolarParameter.AngleDescription = (string) this.struct18_0.Value;
            break;
          case 309:
            blockPolarParameter.Distance = this.method_37((short) 96, (short) 141, (short) 175, (short) 309);
            break;
          case 410:
            blockPolarParameter.Angle = this.method_37((short) 97, (short) 145, (short) 176, (short) 410);
            break;
          default:
            if (blockPolarParameter.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_51(Class265 objectBuilder, bool readCommon)
    {
      DxfBlockParameter dxfBlockParameter = (DxfBlockParameter) objectBuilder.Object;
      this.method_58(objectBuilder, readCommon);
      this.method_91("AcDbBlockParameter");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 280:
            dxfBlockParameter.ShowProperties = (byte) this.struct18_0.Value != (byte) 0;
            break;
          case 281:
            dxfBlockParameter.ChainActions = (byte) this.struct18_0.Value != (byte) 0;
            break;
          default:
            if (dxfBlockParameter.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_52(Class268 objectBuilder)
    {
      DxfBlockMoveAction dxfBlockMoveAction = (DxfBlockMoveAction) objectBuilder.Object;
      this.method_65(objectBuilder);
      this.method_91("AcDbBlockMoveAction");
      dxfBlockMoveAction.ActionConnections = this.method_42(dxfBlockMoveAction.ActionConnections.Length, 92, 301);
      DxfBlockAngleOffsetAction o = (DxfBlockAngleOffsetAction) dxfBlockMoveAction;
      this.method_85();
      this.method_44(ref o);
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        if (!dxfBlockMoveAction.method_6(this, (Class259) objectBuilder))
          this.method_85();
      }
    }

    private void method_53(Class265 objectBuilder)
    {
      DxfBlockLookUpParameter blockLookUpParameter = (DxfBlockLookUpParameter) objectBuilder.Object;
      this.method_68(objectBuilder);
      this.method_91("AcDbBlockLookUpParameter");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 94:
            blockLookUpParameter.ActionId = new DxfEvalGraph.GraphNodeId((int) this.struct18_0.Value);
            break;
          case 303:
            blockLookUpParameter.LabelText = (string) this.struct18_0.Value;
            break;
          case 304:
            blockLookUpParameter.Description = (string) this.struct18_0.Value;
            break;
          default:
            if (blockLookUpParameter.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_54(Class268 objectBuilder)
    {
      DxfBlockLookupAction blockLookupAction = (DxfBlockLookupAction) objectBuilder.Object;
      this.method_65(objectBuilder);
      this.method_91("AcDbBlockLookupAction");
      blockLookupAction.Text = (string[]) null;
      blockLookupAction.Information = (DxfLookupActionInformation[]) null;
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 92:
            blockLookupAction.NumberOfRows = (int) this.struct18_0.Value;
            break;
          case 93:
            blockLookupAction.NumberOfColumns = (int) this.struct18_0.Value;
            break;
          case 280:
            blockLookupAction.UnknownFlag = (byte) this.struct18_0.Value != (byte) 0;
            break;
          case 301:
            blockLookupAction.Text = new string[blockLookupAction.NumberOfRows * blockLookupAction.NumberOfColumns];
            for (int index = 0; index < blockLookupAction.NumberOfRows * blockLookupAction.NumberOfColumns; ++index)
            {
              this.method_85();
              this.method_135(302);
              blockLookupAction.Text[index] = (string) this.struct18_0.Value;
            }
            blockLookupAction.Information = new DxfLookupActionInformation[blockLookupAction.NumberOfColumns];
            for (int index = 0; index < blockLookupAction.NumberOfColumns; ++index)
            {
              blockLookupAction.Information[index] = new DxfLookupActionInformation();
              this.method_85();
              this.method_135(303);
              this.method_85();
              this.method_135(94);
              blockLookupAction.Information[index].Id = new DxfEvalGraph.GraphNodeId((int) this.struct18_0.Value);
              this.method_85();
              this.method_135(95);
              blockLookupAction.Information[index].ResourceType = (int) this.struct18_0.Value;
              this.method_85();
              this.method_135(96);
              blockLookupAction.Information[index].Type = (int) this.struct18_0.Value;
              this.method_85();
              this.method_135(282);
              blockLookupAction.Information[index].PropertyType = (byte) this.struct18_0.Value != (byte) 0;
              this.method_85();
              this.method_135(305);
              blockLookupAction.Information[index].Unmatched = (string) this.struct18_0.Value;
              this.method_85();
              this.method_135(281);
              blockLookupAction.Information[index].AllowEditing = (byte) this.struct18_0.Value != (byte) 0;
              this.method_85();
              this.method_135(304);
              blockLookupAction.Information[index].ConnectionText = (string) this.struct18_0.Value;
            }
            break;
          default:
            if (blockLookupAction.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_55(Class265 objectBuilder)
    {
      DxfBlockLinearParameter blockLinearParameter = (DxfBlockLinearParameter) objectBuilder.Object;
      this.method_67(objectBuilder, true);
      this.method_91("AcDbBlockLinearParameter");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 140:
            blockLinearParameter.LabelOffset = (double) this.struct18_0.Value;
            break;
          case 305:
            blockLinearParameter.LabelText = (string) this.struct18_0.Value;
            break;
          case 306:
            blockLinearParameter.Description = (string) this.struct18_0.Value;
            break;
          case 307:
            blockLinearParameter.Distance = this.method_37((short) 96, (short) 141, (short) 175, (short) 307);
            break;
          default:
            if (blockLinearParameter.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_56(Class265 objectBuilder)
    {
      DxfBlockFlipParameter blockFlipParameter = (DxfBlockFlipParameter) objectBuilder.Object;
      this.method_67(objectBuilder, true);
      this.method_91("AcDbBlockFlipParameter");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 96:
            if (blockFlipParameter.Connection == null)
              blockFlipParameter.Connection = new DxfConnectionPoint();
            blockFlipParameter.Connection.ConnectionPointId = new DxfEvalGraph.GraphNodeId((int) this.struct18_0.Value);
            break;
          case 305:
            blockFlipParameter.LabelText = (string) this.struct18_0.Value;
            break;
          case 306:
            blockFlipParameter.Description = (string) this.struct18_0.Value;
            break;
          case 307:
            blockFlipParameter.NotFlippedState = (string) this.struct18_0.Value;
            break;
          case 308:
            blockFlipParameter.FlippedState = (string) this.struct18_0.Value;
            break;
          case 309:
            if (blockFlipParameter.Connection == null)
              blockFlipParameter.Connection = new DxfConnectionPoint();
            blockFlipParameter.Connection.ConnectionString = (string) this.struct18_0.Value;
            break;
          case 1012:
            blockFlipParameter.LabelPosition = this.method_154();
            break;
          default:
            if (blockFlipParameter.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_57(Class268 objectBuilder)
    {
      DxfBlockFlipAction dxfBlockFlipAction = (DxfBlockFlipAction) objectBuilder.Object;
      this.method_65(objectBuilder);
      this.method_91("AcDbBlockFlipAction");
      dxfBlockFlipAction.ActionConnections = this.method_42(dxfBlockFlipAction.ActionConnections.Length, 92, 301);
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        if (!dxfBlockFlipAction.method_6(this, (Class259) objectBuilder))
          this.method_85();
      }
    }

    private void method_58(Class265 objectBuilder, bool readCommon)
    {
      DxfBlockElement dxfBlockElement = (DxfBlockElement) objectBuilder.Object;
      this.method_71(objectBuilder, readCommon);
      this.method_91("AcDbBlockElement");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 98:
            dxfBlockElement.VersionMajor = (int) this.struct18_0.Value;
            break;
          case 99:
            dxfBlockElement.VersionMinor = (int) this.struct18_0.Value;
            break;
          case 300:
            dxfBlockElement.Name = (string) this.struct18_0.Value;
            break;
          case 1071:
            dxfBlockElement.UnknownField = (int) this.struct18_0.Value;
            break;
          default:
            if (dxfBlockElement.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_59(Class265 objectBuilder)
    {
      DxfBlockBasePointParameter basePointParameter = (DxfBlockBasePointParameter) objectBuilder.Object;
      this.method_68(objectBuilder);
      this.method_91("AcDbBlockBasepointParameter");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 1011:
            basePointParameter.BasePoint1 = this.method_154();
            break;
          case 1012:
            basePointParameter.BasePoint2 = this.method_154();
            break;
          default:
            if (basePointParameter.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_60(Class272 objectBuilder)
    {
      DxfBlockUserParameter blockUserParameter = (DxfBlockUserParameter) objectBuilder.Object;
      this.method_68((Class265) objectBuilder);
      blockUserParameter.UnknownInt16 = (short) 0;
      objectBuilder.Variable = 0UL;
      blockUserParameter.UnknownString = "";
      blockUserParameter.ValueType = (short) 0;
      blockUserParameter.Unknown = (DxfXRecordValue) null;
      this.method_91("AcDbBlockUserParameter");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 90:
            blockUserParameter.UnknownInt16 = (short) (int) this.struct18_0.Value;
            break;
          case 170:
            blockUserParameter.ValueType = (short) this.struct18_0.Value;
            break;
          case 301:
            blockUserParameter.UnknownString = (string) this.struct18_0.Value;
            break;
          case 309:
            if ((string) this.struct18_0.Value != "AcDbEvalVariant NULL = -9999")
              throw new Exception("AcDbEvalVariant NULL = -9999.");
            break;
          case 330:
            objectBuilder.Variable = (ulong) this.struct18_0.Value;
            break;
          default:
            if (blockUserParameter.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_61(Class268 objectBuilder)
    {
      DxfBlockArrayAction blockArrayAction = (DxfBlockArrayAction) objectBuilder.Object;
      this.method_65(objectBuilder);
      this.method_91("AcDbBlockArrayAction");
      blockArrayAction.ActionConnections = this.method_42(blockArrayAction.ActionConnections.Length, 92, 301);
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 140:
            blockArrayAction.RowOffset = (double) this.struct18_0.Value;
            break;
          case 141:
            blockArrayAction.ColumnOffset = (double) this.struct18_0.Value;
            break;
          default:
            if (blockArrayAction.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_62(Class265 objectBuilder)
    {
      DxfBlockAlignmentParameter alignmentParameter = (DxfBlockAlignmentParameter) objectBuilder.Object;
      this.method_67(objectBuilder, true);
      this.method_91("AcDbBlockAlignmentParameter");
      this.method_85();
      if (this.struct18_0.Code != 280)
        throw new Exception("Investigate it.");
      alignmentParameter.IsPerpendicular = (byte) this.struct18_0.Value != (byte) 0;
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        if (!alignmentParameter.method_6(this, (Class259) objectBuilder))
          this.method_85();
      }
    }

    private void method_63(Class268 objectBuilder)
    {
      DxfBlockBasePointAction blockBasePointAction = (DxfBlockBasePointAction) objectBuilder.Object;
      this.method_65(objectBuilder);
      this.method_91("AcDbBlockActionWithBasePt");
      blockBasePointAction.Connections = this.method_42(blockBasePointAction.Connections.Length, 92, 301);
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 280:
            blockBasePointAction.IndependentFlag = (byte) this.struct18_0.Value == (byte) 0;
            break;
          case 1011:
            blockBasePointAction.BasePoint = this.method_154();
            break;
          case 1012:
            blockBasePointAction.Offset = this.method_154();
            break;
          default:
            if (blockBasePointAction.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_64(Class265 objectBuilder)
    {
      DxfBlockGrip dxfBlockGrip = (DxfBlockGrip) objectBuilder.Object;
      this.method_58(objectBuilder, true);
      this.method_91("AcDbBlockGrip");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 91:
            dxfBlockGrip.GripExpression1 = new DxfEvalGraph.GraphNodeId((int) this.struct18_0.Value);
            break;
          case 92:
            dxfBlockGrip.GripExpression2 = new DxfEvalGraph.GraphNodeId((int) this.struct18_0.Value);
            break;
          case 93:
            dxfBlockGrip.CyclingWeight = (int) this.struct18_0.Value;
            break;
          case 280:
            dxfBlockGrip.CyclingFlag = (byte) this.struct18_0.Value != (byte) 0;
            break;
          case 1010:
            dxfBlockGrip.Position = this.method_154();
            break;
          default:
            return;
        }
        this.method_85();
      }
    }

    private void method_65(Class268 objectBuilder)
    {
      DxfBlockAction dxfBlockAction = (DxfBlockAction) objectBuilder.Object;
      this.method_58((Class265) objectBuilder, true);
      this.method_91("AcDbBlockAction");
      dxfBlockAction.AttachedElements = (DxfEvalGraph.GraphNodeId[]) null;
      dxfBlockAction.AttachedEntities = (DxfHandledObjectCollection<DxfHandledObject>) null;
      ulong[] numArray = (ulong[]) null;
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 70:
            int length1 = (int) (short) this.struct18_0.Value;
            dxfBlockAction.AttachedElements = new DxfEvalGraph.GraphNodeId[length1];
            for (int index = 0; index < length1; ++index)
            {
              this.method_85();
              this.method_135(91);
              dxfBlockAction.AttachedElements[index] = new DxfEvalGraph.GraphNodeId((int) this.struct18_0.Value);
            }
            break;
          case 71:
            int length2 = (int) (short) this.struct18_0.Value;
            numArray = new ulong[length2];
            for (int index = 0; index < length2; ++index)
            {
              this.method_85();
              this.method_135(330);
              numArray[index] = (ulong) this.struct18_0.Value;
            }
            break;
          case 1010:
            dxfBlockAction.Position = this.method_154();
            break;
          default:
            if (dxfBlockAction.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
      objectBuilder.AttachedEntities = numArray;
    }

    private DxfBlockParameterPropertyInfo method_66(
      int n1,
      int n2,
      int n3)
    {
      DxfBlockParameterPropertyInfo parameterPropertyInfo = new DxfBlockParameterPropertyInfo();
      this.method_135(n1);
      int length = (int) (short) this.struct18_0.Value;
      parameterPropertyInfo.ConnectionPoints = new DxfConnectionPoint[length];
      for (int index = 0; index < length; ++index)
      {
        this.method_85();
        this.method_135(n2);
        parameterPropertyInfo.ConnectionPoints[index] = new DxfConnectionPoint();
        parameterPropertyInfo.ConnectionPoints[index].ConnectionPointId = new DxfEvalGraph.GraphNodeId((int) this.struct18_0.Value);
        this.method_85();
        this.method_135(n3);
        parameterPropertyInfo.ConnectionPoints[index].ConnectionString = (string) this.struct18_0.Value;
      }
      return parameterPropertyInfo;
    }

    internal void method_67(Class265 objectBuilder, bool readCommon = true)
    {
      DxfBlockTwoPointsParameter twoPointsParameter = (DxfBlockTwoPointsParameter) objectBuilder.Object;
      this.method_51(objectBuilder, readCommon);
      this.method_91("AcDbBlock2PtParameter");
      twoPointsParameter.GripIds = (DxfEvalGraph.GraphNodeId[]) null;
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 170:
            int length = (int) (short) this.struct18_0.Value;
            twoPointsParameter.GripIds = new DxfEvalGraph.GraphNodeId[length];
            for (int index = 0; index < length; ++index)
            {
              this.method_85();
              this.method_135(91);
              twoPointsParameter.GripIds[index] = new DxfEvalGraph.GraphNodeId((int) this.struct18_0.Value);
            }
            break;
          case 171:
            twoPointsParameter.Properties = new DxfBlockParameterPropertyInfo[4];
            for (int index = 0; index < 4; ++index)
            {
              twoPointsParameter.Properties[index] = this.method_66(171 + index, 92 + index, 301 + index);
              if (index != 3)
                this.method_85();
            }
            break;
          case 177:
            twoPointsParameter.BasePoint = (DxfBlockTwoPointsParameter.PointType) (short) this.struct18_0.Value;
            break;
          case 1010:
            twoPointsParameter.FirstPoint = this.method_154();
            break;
          case 1011:
            twoPointsParameter.SecondPoint = this.method_154();
            break;
          default:
            if (twoPointsParameter.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_68(Class265 objectBuilder)
    {
      DxfBlockSinglePointParameter singlePointParameter = (DxfBlockSinglePointParameter) objectBuilder.Object;
      this.method_51(objectBuilder, true);
      this.method_91("AcDbBlock1PtParameter");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 93:
            singlePointParameter.GripId = new DxfEvalGraph.GraphNodeId((int) this.struct18_0.Value);
            break;
          case 170:
            singlePointParameter.FirstProperty = this.method_66(170, 91, 301);
            break;
          case 171:
            singlePointParameter.SecondProperty = this.method_66(171, 92, 302);
            break;
          case 1010:
            singlePointParameter.BasePoint = this.method_154();
            break;
          default:
            if (singlePointParameter.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private DxfXRecordValue method_69(int codeToSkip, ref Class485 objectBuilder)
    {
      this.method_135(codeToSkip);
      if ((short) this.struct18_0.Value == (short) -9999)
        return (DxfXRecordValue) null;
      this.method_85();
      return this.method_70(ref objectBuilder);
    }

    private DxfXRecordValue method_70(ref Class485 objectBuilder)
    {
      short code = (short) this.struct18_0.Code;
      if (code == (short) -9999)
        throw new Exception("ReadXRecordValueBit not implemented");
      Enum5 enum5 = Class820.smethod_2((int) code);
      object obj;
      switch (enum5)
      {
        case Enum5.const_1:
          obj = (object) ((byte) this.struct18_0.Value != (byte) 0);
          break;
        case Enum5.const_2:
          obj = (object) (byte) this.struct18_0.Value;
          break;
        case Enum5.const_3:
          int num = (int) (byte) this.struct18_0.Value;
          throw new Exception("Byte array not implemented");
        case Enum5.const_4:
          obj = (object) (double) this.struct18_0.Value;
          break;
        case Enum5.const_5:
          string handleString = (string) this.struct18_0.Value;
          DxfXRecordValue xrecord1 = new DxfXRecordValue(code, (object) null);
          objectBuilder = new Class485(xrecord1);
          objectBuilder.DataValueHandle = DxfHandledObject.Parse(handleString);
          return xrecord1;
        case Enum5.const_6:
          obj = (object) (string) this.struct18_0.Value;
          break;
        case Enum5.const_7:
        case Enum5.const_8:
        case Enum5.const_9:
        case Enum5.const_14:
        case Enum5.const_15:
          DxfXRecordValue xrecord2 = new DxfXRecordValue(code, (object) null);
          objectBuilder = new Class485(xrecord2);
          objectBuilder.DataValueHandle = (ulong) this.struct18_0.Value;
          return xrecord2;
        case Enum5.const_10:
        case Enum5.const_17:
          obj = (object) (short) this.struct18_0.Value;
          break;
        case Enum5.const_11:
          obj = (object) (int) this.struct18_0.Value;
          break;
        case Enum5.const_12:
          obj = (object) (long) this.struct18_0.Value;
          break;
        case Enum5.const_13:
          obj = (object) this.method_154();
          break;
        case Enum5.const_16:
          obj = (object) (string) this.struct18_0.Value;
          break;
        default:
          throw new Exception("Unknown group value type " + (object) enum5 + " for group " + (object) code + ".");
      }
      return new DxfXRecordValue(code, obj);
    }

    private void method_71(Class265 objectBuilder, bool readCommon)
    {
      DxfEvalGraphExpression evalGraphExpression = (DxfEvalGraphExpression) objectBuilder.Object;
      if (readCommon)
        evalGraphExpression.method_5(this, (Class259) objectBuilder);
      this.method_91("AcDbEvalExpr");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 1:
            this.method_85();
            Class485 objectBuilder1 = (Class485) null;
            evalGraphExpression.DataValue = this.method_69(70, ref objectBuilder1);
            objectBuilder.XRecordBuilder = objectBuilder1;
            break;
          case 90:
            evalGraphExpression.NodeId = new DxfEvalGraph.GraphNodeId((int) this.struct18_0.Value);
            break;
          case 98:
            evalGraphExpression.VersionMajor = (int) this.struct18_0.Value;
            break;
          case 99:
            evalGraphExpression.VersionMinor = (int) this.struct18_0.Value;
            break;
          default:
            if (evalGraphExpression.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_72(Class265 objectBuilder)
    {
      DxfBlockVisibilityGrip blockVisibilityGrip = (DxfBlockVisibilityGrip) objectBuilder.Object;
      this.method_64(objectBuilder);
      this.method_91("AcDbBlockVisibilityGrip");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        if (!blockVisibilityGrip.method_6(this, (Class259) objectBuilder))
          this.method_85();
      }
    }

    private void method_73(Class265 objectBuilder)
    {
      DxfBlockRotationGrip blockRotationGrip = (DxfBlockRotationGrip) objectBuilder.Object;
      this.method_64(objectBuilder);
      this.method_91("AcDbBlockRotationGrip");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        if (!blockRotationGrip.method_6(this, (Class259) objectBuilder))
          this.method_85();
      }
    }

    private void method_74(Class265 objectBuilder)
    {
      DxfBlockPolarGrip dxfBlockPolarGrip = (DxfBlockPolarGrip) objectBuilder.Object;
      this.method_64(objectBuilder);
      this.method_91("AcDbBlockPolarGrip");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        if (!dxfBlockPolarGrip.method_6(this, (Class259) objectBuilder))
          this.method_85();
      }
    }

    private void method_75(Class265 objectBuilder)
    {
      DxfBlockPropertiesTableGrip propertiesTableGrip = (DxfBlockPropertiesTableGrip) objectBuilder.Object;
      this.method_64(objectBuilder);
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        if (!propertiesTableGrip.method_6(this, (Class259) objectBuilder))
          this.method_85();
      }
    }

    private void method_76(Class265 objectBuilder)
    {
      DxfBlockLookupGrip dxfBlockLookupGrip = (DxfBlockLookupGrip) objectBuilder.Object;
      this.method_64(objectBuilder);
      this.method_91("AcDbBlockLookUpGrip");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        if (!dxfBlockLookupGrip.method_6(this, (Class259) objectBuilder))
          this.method_85();
      }
    }

    private void method_77(Class265 objectBuilder)
    {
      DxfBlockLinearGrip dxfBlockLinearGrip = (DxfBlockLinearGrip) objectBuilder.Object;
      this.method_64(objectBuilder);
      this.method_91("AcDbBlockLinearGrip");
      this.method_85();
      WW.Math.Vector3D vector3D = new WW.Math.Vector3D();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 140:
            vector3D.X = (double) this.struct18_0.Value;
            break;
          case 141:
            vector3D.Y = (double) this.struct18_0.Value;
            break;
          case 142:
            vector3D.Z = (double) this.struct18_0.Value;
            break;
          default:
            if (dxfBlockLinearGrip.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
      dxfBlockLinearGrip.Distance = vector3D;
    }

    private void method_78(Class265 objectBuilder)
    {
      DxfBlockFlipGrip dxfBlockFlipGrip = (DxfBlockFlipGrip) objectBuilder.Object;
      this.method_64(objectBuilder);
      this.method_91("AcDbBlockFlipGrip");
      this.method_85();
      WW.Math.Vector3D vector3D = new WW.Math.Vector3D();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 93:
            dxfBlockFlipGrip.FlipExpression = new DxfEvalGraph.GraphNodeId((int) this.struct18_0.Value);
            break;
          case 140:
            vector3D.X = (double) this.struct18_0.Value;
            break;
          case 141:
            vector3D.Y = (double) this.struct18_0.Value;
            break;
          case 142:
            vector3D.Z = (double) this.struct18_0.Value;
            break;
          default:
            if (dxfBlockFlipGrip.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
      dxfBlockFlipGrip.Orientation = vector3D;
    }

    private void method_79(Class260 objectBuilder)
    {
      DxfBlockPurgePreventer blockPurgePreventer = (DxfBlockPurgePreventer) objectBuilder.Object;
      blockPurgePreventer.method_5(this, (Class259) objectBuilder);
      this.method_91("AcDbDynamicBlockPurgePreventer");
      this.method_85();
      blockPurgePreventer.DynamicBlock = (DxfBlock) null;
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        if (this.struct18_0.Code == 70)
          blockPurgePreventer.Version = (short) this.struct18_0.Value;
        else if (blockPurgePreventer.method_6(this, (Class259) objectBuilder))
          continue;
        this.method_85();
      }
    }

    private void method_80(Class277 objectBuilder)
    {
      DxfBlockRepresentationData representationData = (DxfBlockRepresentationData) objectBuilder.Object;
      representationData.method_5(this, (Class259) objectBuilder);
      this.method_91("AcDbBlockRepresentationData");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 70:
            representationData.Version = (short) this.struct18_0.Value;
            break;
          case 340:
            objectBuilder.DynamicBlockHandle = (ulong) this.struct18_0.Value;
            break;
          default:
            if (representationData.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_81(Class265 objectBuilder)
    {
      DxfBlockAlignmentGrip blockAlignmentGrip = (DxfBlockAlignmentGrip) objectBuilder.Object;
      this.method_64(objectBuilder);
      this.method_91("AcDbBlockAlignmentGrip");
      this.method_85();
      WW.Math.Vector3D vector3D = new WW.Math.Vector3D();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        switch (this.struct18_0.Code)
        {
          case 140:
            vector3D.X = (double) this.struct18_0.Value;
            break;
          case 141:
            vector3D.Y = (double) this.struct18_0.Value;
            break;
          case 142:
            vector3D.Z = (double) this.struct18_0.Value;
            break;
          default:
            if (blockAlignmentGrip.method_6(this, (Class259) objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
      blockAlignmentGrip.Alignment = vector3D;
    }

    private void method_82(Class265 objectBuilder)
    {
      DxfBlockXYGrip dxfBlockXyGrip = (DxfBlockXYGrip) objectBuilder.Object;
      this.method_64(objectBuilder);
      this.method_91("AcDbBlockXYGrip");
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        if (!dxfBlockXyGrip.method_6(this, (Class259) objectBuilder))
          this.method_85();
      }
    }

    private void method_83(Class265 objectBuilder)
    {
      DxfBlockGripExpression blockGripExpression = (DxfBlockGripExpression) objectBuilder.Object;
      this.method_71(objectBuilder, true);
      this.method_91("AcDbBlockGripExpr");
      blockGripExpression.ActionConnection = this.method_43(91, 300);
      this.method_85();
      while (this.struct18_0.Code != 0 && this.struct18_0.Code != 100)
      {
        if (!blockGripExpression.method_6(this, (Class259) objectBuilder))
          this.method_85();
      }
    }

    private void method_84(Class265 objectBuilder)
    {
      DxfDynamicBlockProxyNode dynamicBlockProxyNode = (DxfDynamicBlockProxyNode) objectBuilder.Object;
      this.method_71(objectBuilder, true);
    }

    public event EventHandler<ReadEventArgs> BeforeRead;

    public event ProgressEventHandler Progress;

    public DxfReader(Stream stream)
      : this(stream, Encodings.GetCodePage(Encodings.Default))
    {
    }

    public DxfReader(Stream stream, int defaultCodePage)
    {
      this.stream_0 = stream;
      this.long_0 = stream.Length;
      this.int_2 = defaultCodePage;
      this.method_358(stream);
    }

    public DxfReader(string filename)
      : this(filename, Encodings.GetCodePage(Encodings.Default))
    {
    }

    public DxfReader(string filename, int defaultCodePage)
    {
      this.string_0 = filename;
      this.stream_0 = DxfUtil.OpenFileRead(filename);
      this.long_0 = this.stream_0.Length;
      this.int_2 = defaultCodePage;
      this.method_358(this.stream_0);
    }

    private DxfReader(DxfModel model, Interface33 groupReader)
    {
      this.int_3 = -1;
      this.dxfModel_0 = model;
      this.interface33_0 = groupReader;
      Class375 class375 = new Class375(model, this.dxfMessageCollection_0);
      class375.LoadUnknownObjects = this.bool_0;
      this.class375_0 = class375;
    }

    static DxfReader()
    {
      DxfReader.dictionary_1.Add("$ACADMAINTVER", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.AcadMaintenanceVersion = Convert.ToInt32(value)));
      DxfReader.dictionary_1.Add("$ACADVER", (DxfReader.Delegate0) ((header, modelBuilder, value) =>
      {
        header.method_4((string) value, false);
        modelBuilder.method_0(header.AcadVersion);
      }));
      DxfReader.dictionary_1.Add("$ANGBASE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.AngleBase = (double) value * (System.Math.PI / 180.0)));
      DxfReader.dictionary_1.Add("$ANGDIR", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.AngularDirection = (AngularDirection) value));
      DxfReader.dictionary_1.Add("$DIMARCSYM", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.ArcLengthSymbolPosition = (ArcLengthSymbolPosition) value));
      DxfReader.dictionary_1.Add("$ATTMODE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.AttributeVisibility = (AttributeVisibility) value));
      DxfReader.dictionary_1.Add("$AUNITS", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.AngularUnit = (AngularUnit) value));
      DxfReader.dictionary_1.Add("$AUPREC", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.AngularUnitPrecision = (short) value));
      DxfReader.dictionary_1.Add("$AUTHOR", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.Model.SummaryInfo.Author = (string) value));
      DxfReader.dictionary_1.Add("$CECOLOR", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.CurrentEntityColor = Color.CreateFromColorIndex((short) value)));
      DxfReader.dictionary_1.Add("$CELTSCALE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.CurrentEntityLinetypeScale = (double) value));
      DxfReader.dictionary_1.Add("$CELTYPE", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.CurrentEntityLineTypeName = (string) value));
      DxfReader.dictionary_1.Add("$CELWEIGHT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.CurrentEntityLineWeight = (short) value));
      DxfReader.dictionary_1.Add("$CEPSNTYPE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.CurrentEntityPlotStyleType = (PlotStyleType) value));
      DxfReader.dictionary_1.Add("$CHAMFERA", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ChamferDistance1 = (double) value));
      DxfReader.dictionary_1.Add("$CHAMFERB", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ChamferDistance2 = (double) value));
      DxfReader.dictionary_1.Add("$CHAMFERC", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ChamferLength = (double) value));
      DxfReader.dictionary_1.Add("$CHAMFERD", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ChamferAngle = (double) value * (System.Math.PI / 180.0)));
      DxfReader.dictionary_1.Add("$CLAYER", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.CurrentLayerName = (string) value));
      DxfReader.dictionary_1.Add("$CMLJUST", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.CurrentMultilineJustification = (VerticalAlignment) value));
      DxfReader.dictionary_1.Add("$CMLSCALE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.CurrentMultilineScale = (double) value));
      DxfReader.dictionary_1.Add("$CMLSTYLE", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.CurrentMultilineStyleName = (string) value));
      DxfReader.dictionary_1.Add("$COMMENTS", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.Model.SummaryInfo.Comments = (string) value));
      DxfReader.dictionary_1.Add("$CUSTOMPROPERTYTAG", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.Model.SummaryInfo.Properties.Add(new SummaryInfo.Property((string) value, (string) null))));
      DxfReader.dictionary_1.Add("$CUSTOMPROPERTY", (DxfReader.Delegate0) ((header, modelBuilder, value) =>
      {
        Class375 class375 = (Class375) modelBuilder;
        if (!(class375.PreviousHeaderVariableName == "$CUSTOMPROPERTYTAG") || modelBuilder.Model.SummaryInfo.Properties.Count <= 0)
          return;
        SummaryInfo.Property property = modelBuilder.Model.SummaryInfo.Properties[modelBuilder.Model.SummaryInfo.Properties.Count - 1];
        if ((object) property.Name != class375.PreviousHeaderVariableValue)
          return;
        property.Value = (string) value;
      }));
      DxfReader.dictionary_1.Add("$CSHADOW", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ShadowMode = (ShadowMode) value));
      DxfReader.dictionary_1.Add("$DIMADEC", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.AngularDimensionDecimalPlaces = (short) value));
      DxfReader.dictionary_1.Add("$DIMALT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.AlternateUnitDimensioning = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DIMALTD", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.AlternateUnitDecimalPlaces = (short) value));
      DxfReader.dictionary_1.Add("$DIMALTF", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.AlternateUnitScaleFactor = (double) value));
      DxfReader.dictionary_1.Add("$DIMALTRND", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.AlternateUnitRounding = (double) value));
      DxfReader.dictionary_1.Add("$DIMALTTD", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.AlternateUnitToleranceDecimalPlaces = (short) value));
      DxfReader.dictionary_1.Add("$DIMALTTZ", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.AlternateUnitToleranceZeroHandling = (ZeroHandling) (short) value));
      DxfReader.dictionary_1.Add("$DIMALTU", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.AlternateUnitFormat = (AlternateUnitFormat) value));
      DxfReader.dictionary_1.Add("$DIMALTZ", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.AlternateUnitZeroHandling = (ZeroHandling) (short) value));
      DxfReader.dictionary_1.Add("$DIMAPOST", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.AlternateDimensioningSuffix = (string) value));
      DxfReader.dictionary_1.Add("$DIMASO", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.AssociatedDimensions = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DIMASSOC", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionAssociativity = (DimensionAssociativity) (byte) value));
      DxfReader.dictionary_1.Add("$DIMASZ", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.ArrowSize = (double) value));
      DxfReader.dictionary_1.Add("$DIMATFIT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.ArrowsTextFit = (ArrowsTextFitType) (short) value));
      DxfReader.dictionary_1.Add("$DIMAUNIT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.AngularUnit = (AngularUnit) value));
      DxfReader.dictionary_1.Add("$DIMAZIN", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.AngularZeroHandling = (ZeroHandling) (short) value));
      DxfReader.dictionary_1.Add("$DIMBLK", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.DimensionStyleArrowBlockName = (string) value));
      DxfReader.dictionary_1.Add("$DIMBLK1", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.DimensionStyleFirstArrowBlockName = (string) value));
      DxfReader.dictionary_1.Add("$DIMBLK2", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.DimensionStyleSecondArrowBlockName = (string) value));
      DxfReader.dictionary_1.Add("$DIMCEN", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.CenterMarkSize = (double) value));
      DxfReader.dictionary_1.Add("$DIMCLRD", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.DimensionLineColor = Color.CreateFromColorIndex((short) value)));
      DxfReader.dictionary_1.Add("$DIMCLRE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.ExtensionLineColor = Color.CreateFromColorIndex((short) value)));
      DxfReader.dictionary_1.Add("$DIMCLRT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.TextColor = Color.CreateFromColorIndex((short) value)));
      DxfReader.dictionary_1.Add("$DIMDEC", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.DecimalPlaces = (short) value));
      DxfReader.dictionary_1.Add("$DIMDLE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.DimensionLineExtension = (double) value));
      DxfReader.dictionary_1.Add("$DIMDLI", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.DimensionLineIncrement = (double) value));
      DxfReader.dictionary_1.Add("$DIMDSEP", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.DecimalSeparator = (char) (short) value));
      DxfReader.dictionary_1.Add("$DIMEXE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.ExtensionLineExtension = (double) value));
      DxfReader.dictionary_1.Add("$DIMEXO", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.ExtensionLineOffset = (double) value));
      DxfReader.dictionary_1.Add("$DIMFIT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.ArrowsTextFit = (ArrowsTextFitType) (short) value));
      DxfReader.dictionary_1.Add("$DIMFRAC", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.FractionFormat = (FractionFormat) value));
      DxfReader.dictionary_1.Add("$DIMFXL", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.FixedExtensionLineLength = (double) value));
      DxfReader.dictionary_1.Add("$DIMFXLON", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.IsExtensionLineLengthFixed = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DIMGAP", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.DimensionLineGap = (double) value));
      DxfReader.dictionary_1.Add("$DIMJOGANG", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.JoggedRadiusDimensionTransverseSegmentAngle = (double) value));
      DxfReader.dictionary_1.Add("$DIMJUST", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.TextHorizontalAlignment = (DimensionTextHorizontalAlignment) (short) value));
      DxfReader.dictionary_1.Add("$DIMLDRBLK", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.DimensionStyleLeaderArrowBlockName = (string) value));
      DxfReader.dictionary_1.Add("$DIMLFAC", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.LinearScaleFactor = (double) value));
      DxfReader.dictionary_1.Add("$DIMLIM", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.LimitsGeneration = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DIMLTYPE", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.DimStyleDimensionLineLineTypeName = (string) value));
      DxfReader.dictionary_1.Add("$DIMLTEX1", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.DimStyleFirstExtensionLineLineTypeName = (string) value));
      DxfReader.dictionary_1.Add("$DIMLTEX2", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.DimStyleSecondExtensionLineLineTypeName = (string) value));
      DxfReader.dictionary_1.Add("$DIMLUNIT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.LinearUnitFormat = (LinearUnitFormat) value));
      DxfReader.dictionary_1.Add("$DIMLWD", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.DimensionLineWeight = (short) value));
      DxfReader.dictionary_1.Add("$DIMLWE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.ExtensionLineWeight = (short) value));
      DxfReader.dictionary_1.Add("$DIMPOST", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.PostFix = (string) value));
      DxfReader.dictionary_1.Add("$DIMRND", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.Rounding = (double) value));
      DxfReader.dictionary_1.Add("$DIMSAH", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.SeparateArrowBlocks = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DIMSCALE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.ScaleFactor = (double) value));
      DxfReader.dictionary_1.Add("$DIMSD1", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.SuppressFirstDimensionLine = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DIMSD2", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.SuppressSecondDimensionLine = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DIMSE1", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.SuppressFirstExtensionLine = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DIMSE2", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.SuppressSecondExtensionLine = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DIMSHO", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.UpdateDimensionsWhileDragging = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DIMSOXD", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.SuppressOutsideExtensions = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DIMSTYLE", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.CurrentDimensionStyleName = (string) value));
      DxfReader.dictionary_1.Add("$DIMTAD", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.TextVerticalAlignment = (DimensionTextVerticalAlignment) (short) value));
      DxfReader.dictionary_1.Add("$DIMTDEC", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.ToleranceDecimalPlaces = (short) value));
      DxfReader.dictionary_1.Add("$DIMTFAC", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.ToleranceScaleFactor = (double) value));
      DxfReader.dictionary_1.Add("$DIMTFILL", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.TextBackgroundFillMode = (DimensionTextBackgroundFillMode) value));
      DxfReader.dictionary_1.Add("$DIMTFILLCLR", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.TextBackgroundColor = Color.CreateFromColorIndex((short) value)));
      DxfReader.dictionary_1.Add("$DIMTIH", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.TextInsideHorizontal = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DIMTIX", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.TextInsideExtensions = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DIMTM", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.MinusTolerance = (double) value));
      DxfReader.dictionary_1.Add("$DIMTMOVE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.TextMovement = (TextMovement) value));
      DxfReader.dictionary_1.Add("$DIMTOFL", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.TextOutsideExtensions = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DIMTOH", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.TextOutsideHorizontal = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DIMTOL", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.GenerateTolerances = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DIMTOLJ", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.ToleranceAlignment = (ToleranceAlignment) (short) value));
      DxfReader.dictionary_1.Add("$DIMTP", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.PlusTolerance = (double) value));
      DxfReader.dictionary_1.Add("$DIMTSZ", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.TickSize = (double) value));
      DxfReader.dictionary_1.Add("$DIMTVP", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.TextVerticalPosition = (double) value));
      DxfReader.dictionary_1.Add("$DIMTXSTY", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.DimensionStyleTextStyleName = (string) value));
      DxfReader.dictionary_1.Add("$DIMTXT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.TextHeight = (double) value));
      DxfReader.dictionary_1.Add("$DIMTZIN", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.ToleranceZeroHandling = (ZeroHandling) (short) value));
      DxfReader.dictionary_1.Add("$DIMUNIT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.LinearUnitFormat = (LinearUnitFormat) value));
      DxfReader.dictionary_1.Add("$DIMUPT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.CursorUpdate = (CursorUpdate) (short) value));
      DxfReader.dictionary_1.Add("$DIMZIN", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DimensionStyleOverrides.ZeroHandling = (ZeroHandling) (short) value));
      DxfReader.dictionary_1.Add("$DISPSILH", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DisplaySilhouetteCurves = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$DWGCODEPAGE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DrawingCodePageString = (string) value));
      DxfReader.dictionary_1.Add("$ELEVATION", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.Elevation = (double) value));
      DxfReader.dictionary_1.Add("$ENDCAPS", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.EndCaps = (EndCaps) value));
      DxfReader.dictionary_1.Add("$EXTMAX", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ExtMax = DxfReader.smethod_5((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$EXTMIN", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ExtMin = DxfReader.smethod_5((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$EXTNAMES", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ExtendedNames = (bool) value));
      DxfReader.dictionary_1.Add("$FACETRES", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.FacetResolution = (double) value));
      DxfReader.dictionary_1.Add("$FILLETRAD", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.FilletRadius = (double) value));
      DxfReader.dictionary_1.Add("$FILLMODE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.FillMode = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$FINGERPRINTGUID", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.FingerPrintGuid = (string) value));
      DxfReader.dictionary_1.Add("$HALOGAP", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.HaloGapPercentage = (byte) value));
      DxfReader.dictionary_1.Add("$HANDLING", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.Handling = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$HANDSEED", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.HandleSeedString = (string) value));
      DxfReader.dictionary_1.Add("$HYPERLINKBASE", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.Model.SummaryInfo.HyperLinkBase = (string) value));
      DxfReader.dictionary_1.Add("$INDEXCTL", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.IndexCreationFlags = (IndexCreationFlags) value));
      DxfReader.dictionary_1.Add("$INSBASE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.InsertionBase = DxfReader.smethod_5((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$INSUNITS", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.InsUnits = (DrawingUnits) value));
      DxfReader.dictionary_1.Add("$INTERFERECOLOR", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.InterfereColor = Color.CreateFromColorIndex((short) value)));
      DxfReader.dictionary_1.Add("$INTERFEREOBJVS", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.InterfereObjectStyleHandle = (ulong) value));
      DxfReader.dictionary_1.Add("$INTERFEREVPVS", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.InterfereViewportStyleHandle = (ulong) value));
      DxfReader.dictionary_1.Add("$INTERSECTIONCOLOR", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.IntersectionColor = Color.CreateFromColorIndex((short) value)));
      DxfReader.dictionary_1.Add("$INTERSECTIONDISPLAY", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.IntersectionDisplay = DxfReader.smethod_7((byte) value)));
      DxfReader.dictionary_1.Add("$ISOLINES", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.SurfaceIsolineCount = (short) value));
      DxfReader.dictionary_1.Add("$JOINSTYLE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.JoinStyle = (JoinStyle) value));
      DxfReader.dictionary_1.Add("$KEYWORDS", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.Model.SummaryInfo.Keywords = (string) value));
      DxfReader.dictionary_1.Add("$LASTSAVEDBY", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.Model.SummaryInfo.LastSavedBy = (string) value));
      DxfReader.dictionary_1.Add("$LIMCHECK", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.LimitCheckingOn = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$LIMMAX", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.LimitsMax = DxfReader.smethod_3((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$LIMMIN", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.LimitsMin = DxfReader.smethod_3((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$LTSCALE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.LineTypeScale = (double) value));
      DxfReader.dictionary_1.Add("$LUNITS", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.LinearUnitFormat = (LinearUnitFormat) value));
      DxfReader.dictionary_1.Add("$LUPREC", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.LinearUnitPrecision = (short) value));
      DxfReader.dictionary_1.Add("$LWDISPLAY", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.DisplayLineWeight = (bool) value));
      DxfReader.dictionary_1.Add("$MAXACTVP", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.MaxViewportCount = (short) value));
      DxfReader.dictionary_1.Add("$MEASUREMENT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.MeasurementUnits = (MeasurementUnits) value));
      DxfReader.dictionary_1.Add("$MENU", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.MenuFileName = (string) value));
      DxfReader.dictionary_1.Add("$MIRRTEXT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.MirrorText = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$OBSCOLOR", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ObscuredColor = Color.CreateFromColorIndex((short) value)));
      DxfReader.dictionary_1.Add("$OBSLTYPE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ObscuredLineType = (SimpleLineType) value));
      DxfReader.dictionary_1.Add("$ORTHOMODE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.OrthoMode = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$OSMODE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ObjectSnapMode = (ObjectSnapMode) (short) value));
      DxfReader.dictionary_1.Add("$PDMODE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PointDisplayMode = (PointDisplayMode) value));
      DxfReader.dictionary_1.Add("$PDSIZE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PointDisplaySize = (double) value));
      DxfReader.dictionary_1.Add("$PELEVATION", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceElevation = (double) value));
      DxfReader.dictionary_1.Add("$PEXTMAX", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceExtMax = DxfReader.smethod_5((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$PEXTMIN", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceExtMin = DxfReader.smethod_5((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$PINSBASE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceInsertionBase = DxfReader.smethod_5((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$PLIMCHECK", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceLimitsChecking = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$PLIMMAX", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceLimitsMax = DxfReader.smethod_3((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$PLIMMIN", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceLimitsMin = DxfReader.smethod_3((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$PLINEGEN", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PolylineLineTypeGeneration = (PolylineLineTypeGeneration) value));
      DxfReader.dictionary_1.Add("$PLINEWID", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PolylineWidthDefault = (double) value));
      DxfReader.dictionary_1.Add("$PROJECTNAME", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ProjectName = (string) value));
      DxfReader.dictionary_1.Add("$PROXYGRAPHICS", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ProxyGraphics = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$PSLTSCALE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceLineTypeScaling = (PaperSpaceLineTypeScaling) value));
      DxfReader.dictionary_1.Add("$PSTYLEMODE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PlotStyleMode = (bool) value ? PlotStyleMode.ColorDependent : PlotStyleMode.Named));
      DxfReader.dictionary_1.Add("$PSVPSCALE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ViewportDefaultViewScaleFactor = (double) value));
      DxfReader.dictionary_1.Add("$PUCSBASE", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.PaperSpaceUcsBaseName = (string) value));
      DxfReader.dictionary_1.Add("$PUCSNAME", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.PaperSpaceUcsName = (string) value));
      DxfReader.dictionary_1.Add("$PUCSORG", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceUcs.Origin = DxfReader.smethod_5((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$PUCSORGBACK", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceUcs.OrthographicBackDOrigin = DxfReader.smethod_6((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$PUCSORGBOTTOM", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceUcs.OrthographicBottomDOrigin = DxfReader.smethod_6((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$PUCSORGFRONT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceUcs.OrthographicFrontDOrigin = DxfReader.smethod_6((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$PUCSORGLEFT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceUcs.OrthographicLeftDOrigin = DxfReader.smethod_6((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$PUCSORGRIGHT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceUcs.OrthographicRightDOrigin = DxfReader.smethod_6((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$PUCSORGTOP", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceUcs.OrthographicTopDOrigin = DxfReader.smethod_6((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$PUCSORTHOREF", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.PaperUcsOrthographicReferenceName = (string) value));
      DxfReader.dictionary_1.Add("$PUCSORTHOVIEW", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceUcs.OrthographicViewType = (OrthographicType) (short) value));
      DxfReader.dictionary_1.Add("$PUCSXDIR", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceUcs.XAxis = DxfReader.smethod_6((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$PUCSYDIR", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.PaperSpaceUcs.YAxis = DxfReader.smethod_6((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$QTEXTMODE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.QuickTextMode = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$REGENMODE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.RegenerationMode = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$REQUIREDVERSIONS", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.RequiredVersions = (long) value));
      DxfReader.dictionary_1.Add("$REVISIONNUMBER", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.Model.SummaryInfo.RevisionNumber = (string) value));
      DxfReader.dictionary_1.Add("$SHADEDGE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ShadeEdge = (ShadeEdge) value));
      DxfReader.dictionary_1.Add("$SHADEDIF", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ShadeDiffuseToAmbientPercentage = (short) value));
      DxfReader.dictionary_1.Add("$SHADOWPLANELOCATION", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ShadowPlaneLocation = (double) value));
      DxfReader.dictionary_1.Add("$SKETCHINC", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.SketchIncrement = (double) value));
      DxfReader.dictionary_1.Add("$SKPOLY", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.SketchPolylines = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$SORTENTS", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.EntitySortingFlags = (ObjectSortingFlags) value));
      DxfReader.dictionary_1.Add("$SPLFRAME", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ShowSplineControlPoints = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$SPLINESEGS", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.NumberOfSplineSegments = (short) value));
      DxfReader.dictionary_1.Add("$SPLINETYPE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.SplineType = (SplineType) value));
      DxfReader.dictionary_1.Add("$SNAPANG", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.SnapAngle = System.Math.PI / 180.0 * (double) value));
      DxfReader.dictionary_1.Add("$SNAPBASE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.SnapBase = DxfReader.smethod_3((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$SNAPISOPAIR", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.SnapType = (SnapType) value));
      DxfReader.dictionary_1.Add("$SNAPMODE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.SnapMode = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$SNAPSTYLE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.SnapStyle = (SnapStyle) value));
      DxfReader.dictionary_1.Add("$SNAPUNIT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.SnapSpacing = DxfReader.smethod_4((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$SUBJECT", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.Model.SummaryInfo.Subject = (string) value));
      DxfReader.dictionary_1.Add("$SURFTAB1", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.SurfaceMeshTabulationCount1 = (short) value));
      DxfReader.dictionary_1.Add("$SURFTAB2", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.SurfaceMeshTabulationCount2 = (short) value));
      DxfReader.dictionary_1.Add("$SURFTYPE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.SurfaceType = (short) value));
      DxfReader.dictionary_1.Add("$SURFU", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.SurfaceDensityU = (short) value));
      DxfReader.dictionary_1.Add("$SURFV", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.SurfaceDensityV = (short) value));
      DxfReader.dictionary_1.Add("$TDCREATE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.CreateDateTime = Class644.smethod_4((double) value)));
      DxfReader.dictionary_1.Add("$TDINDWG", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.Model.SummaryInfo.TotalEditingTime = Class644.smethod_7((double) value)));
      DxfReader.dictionary_1.Add("$TDUCREATE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.CreateUtcDateTime = Class644.smethod_4((double) value)));
      DxfReader.dictionary_1.Add("$TDUPDATE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.UpdateDateTime = Class644.smethod_4((double) value)));
      DxfReader.dictionary_1.Add("$TDUSRTIMER", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.UserElapsedTimeSpan = Class644.smethod_7((double) value)));
      DxfReader.dictionary_1.Add("$TDUUPDATE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.UpdateUtcDateTime = DateTime.SpecifyKind(Class644.smethod_4((double) value), DateTimeKind.Utc)));
      DxfReader.dictionary_1.Add("$TEXTQLTY", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.TextQuality = (short) value));
      DxfReader.dictionary_1.Add("$TEXTSIZE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.TextHeightDefault = (double) value));
      DxfReader.dictionary_1.Add("$TEXTSTYLE", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.TextStyleName = (string) value));
      DxfReader.dictionary_1.Add("$THICKNESS", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ThicknessDefault = (double) value));
      DxfReader.dictionary_1.Add("$TILEMODE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.ShowModelSpace = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$TITLE", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.Model.SummaryInfo.Title = (string) value));
      DxfReader.dictionary_1.Add("$TRACEWID", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.TraceWidthDefault = (double) value));
      DxfReader.dictionary_1.Add("$TREEDEPTH", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.SpatialIndexMaxTreeDepth = (short) value));
      DxfReader.dictionary_1.Add("$UCSBASE", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.UcsBaseName = (string) value));
      DxfReader.dictionary_1.Add("$UCSNAME", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.UcsName = (string) value));
      DxfReader.dictionary_1.Add("$UCSORG", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.Ucs.Origin = DxfReader.smethod_5((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$UCSORGBACK", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.Ucs.OrthographicBackDOrigin = DxfReader.smethod_6((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$UCSORGBOTTOM", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.Ucs.OrthographicBottomDOrigin = DxfReader.smethod_6((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$UCSORGFRONT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.Ucs.OrthographicFrontDOrigin = DxfReader.smethod_6((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$UCSORGLEFT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.Ucs.OrthographicLeftDOrigin = DxfReader.smethod_6((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$UCSORGRIGHT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.Ucs.OrthographicRightDOrigin = DxfReader.smethod_6((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$UCSORGTOP", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.Ucs.OrthographicTopDOrigin = DxfReader.smethod_6((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$UCSORTHOREF", (DxfReader.Delegate0) ((header, modelBuilder, value) => modelBuilder.UcsOrthographicReferenceName = (string) value));
      DxfReader.dictionary_1.Add("$UCSORTHOVIEW", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.Ucs.OrthographicViewType = (OrthographicType) (short) value));
      DxfReader.dictionary_1.Add("$UCSXDIR", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.Ucs.XAxis = DxfReader.smethod_6((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$UCSYDIR", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.Ucs.YAxis = DxfReader.smethod_6((List<Struct18>) value)));
      DxfReader.dictionary_1.Add("$UNITMODE", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.UnitMode = (short) value));
      DxfReader.dictionary_1.Add("$USERI1", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.UserShort1 = (short) value));
      DxfReader.dictionary_1.Add("$USERI2", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.UserShort2 = (short) value));
      DxfReader.dictionary_1.Add("$USERI3", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.UserShort3 = (short) value));
      DxfReader.dictionary_1.Add("$USERI4", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.UserShort4 = (short) value));
      DxfReader.dictionary_1.Add("$USERI5", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.UserShort5 = (short) value));
      DxfReader.dictionary_1.Add("$USERR1", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.UserDouble1 = (double) value));
      DxfReader.dictionary_1.Add("$USERR2", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.UserDouble2 = (double) value));
      DxfReader.dictionary_1.Add("$USERR3", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.UserDouble3 = (double) value));
      DxfReader.dictionary_1.Add("$USERR4", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.UserDouble4 = (double) value));
      DxfReader.dictionary_1.Add("$USERR5", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.UserDouble5 = (double) value));
      DxfReader.dictionary_1.Add("$USRTIMER", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.UserTimer = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$VERSIONGUID", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.VersionGuid = (string) value));
      DxfReader.dictionary_1.Add("$VISRETAIN", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.RetainXRefDependentVisibilitySettings = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$WORLDVIEW", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.WorldView = DxfReader.smethod_8((short) value)));
      DxfReader.dictionary_1.Add("$XCLIPFRAME", (DxfReader.Delegate0) ((header, modelBuilder, value) =>
      {
        if (header.Dxf24OrHigher)
          header.ExternalReferenceClippingBoundaryType = (SimpleLineType) value;
        else if (value is byte)
          header.ExternalReferenceClippingBoundaryType = (SimpleLineType) value;
        else
          header.ExternalReferenceClippingBoundaryType = (bool) value ? SimpleLineType.Solid : SimpleLineType.Off;
      }));
      DxfReader.dictionary_1.Add("$XEDIT", (DxfReader.Delegate0) ((header, modelBuilder, value) => header.XEdit = (bool) value));
    }

    public bool CloseStreamAfterReading
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public bool LoadUnknownObjects
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

    public bool ThrowExceptionOnInvalidGroupCode
    {
      get
      {
        return this.bool_4;
      }
      set
      {
        this.bool_4 = value;
      }
    }

    public int DefaultCodePage
    {
      get
      {
        return this.int_2;
      }
    }

    public static DxfModel Read(string filename)
    {
      return DxfReader.Read(filename, (ProgressEventHandler) null);
    }

    public static DxfModel Read(string filename, ProgressEventHandler progressEventHandler)
    {
      using (DxfReader dxfReader = new DxfReader(filename))
      {
        if (progressEventHandler != null)
          dxfReader.Progress += progressEventHandler;
        dxfReader.Read();
        return dxfReader.Model;
      }
    }

    public static DxfModel Read(string filename, int defaultCodePage)
    {
      return DxfReader.Read(filename, defaultCodePage, (ProgressEventHandler) null);
    }

    public static DxfModel Read(
      string filename,
      int defaultCodePage,
      ProgressEventHandler progressEventHandler)
    {
      using (DxfReader dxfReader = new DxfReader(filename, defaultCodePage))
      {
        if (progressEventHandler != null)
          dxfReader.Progress += progressEventHandler;
        dxfReader.Read();
        return dxfReader.Model;
      }
    }

    public static DxfModel Read(
      string filename,
      int defaultCodePage,
      ProgressEventHandler progressEventHandler,
      out DxfMessageCollection messageReturn)
    {
      DxfModel dxfModel = (DxfModel) null;
      using (DxfReader dxfReader = new DxfReader(filename, defaultCodePage))
      {
        if (progressEventHandler != null)
          dxfReader.Progress += progressEventHandler;
        dxfReader.Read();
        dxfModel = dxfReader.Model;
        messageReturn = dxfReader.Messages;
      }
      return dxfModel;
    }

    public static DxfModel Read(
      string filename,
      ProgressEventHandler progressEventHandler,
      out DxfMessageCollection messageReturn)
    {
      DxfModel dxfModel = (DxfModel) null;
      using (DxfReader dxfReader = new DxfReader(filename))
      {
        if (progressEventHandler != null)
          dxfReader.Progress += progressEventHandler;
        dxfReader.Read();
        dxfModel = dxfReader.Model;
        messageReturn = dxfReader.Messages;
      }
      return dxfModel;
    }

    public static DxfModel Read(Stream stream)
    {
      return DxfReader.Read(stream, (ProgressEventHandler) null);
    }

    public static DxfModel Read(Stream stream, ProgressEventHandler progressEventHandler)
    {
      using (DxfReader dxfReader = new DxfReader(stream))
      {
        if (progressEventHandler != null)
          dxfReader.Progress += progressEventHandler;
        dxfReader.Read();
        return dxfReader.Model;
      }
    }

    public static DxfModel Read(Stream stream, int defaultCodePage)
    {
      return DxfReader.Read(stream, defaultCodePage, (ProgressEventHandler) null);
    }

    public static DxfModel Read(
      Stream stream,
      int defaultCodePage,
      ProgressEventHandler progressEventHandler)
    {
      using (DxfReader dxfReader = new DxfReader(stream, defaultCodePage))
      {
        if (progressEventHandler != null)
          dxfReader.Progress += progressEventHandler;
        dxfReader.Read();
        return dxfReader.Model;
      }
    }

    public static DxfModel Read(
      Stream stream,
      int defaultCodePage,
      ProgressEventHandler progressEventHandler,
      out DxfMessageCollection messageReturn)
    {
      DxfModel dxfModel = (DxfModel) null;
      using (DxfReader dxfReader = new DxfReader(stream, defaultCodePage))
      {
        if (progressEventHandler != null)
          dxfReader.Progress += progressEventHandler;
        dxfReader.Read();
        dxfModel = dxfReader.Model;
        messageReturn = dxfReader.Messages;
      }
      return dxfModel;
    }

    public static DxfModel Read(
      Stream stream,
      ProgressEventHandler progressEventHandler,
      out DxfMessageCollection messageReturn)
    {
      DxfModel dxfModel = (DxfModel) null;
      using (DxfReader dxfReader = new DxfReader(stream))
      {
        if (progressEventHandler != null)
          dxfReader.Progress += progressEventHandler;
        dxfReader.Read();
        dxfModel = dxfReader.Model;
        messageReturn = dxfReader.Messages;
      }
      return dxfModel;
    }

    public void Read(DxfModel dxfModel)
    {
      Class809.smethod_0(Enum15.const_1);
      this.dxfModel_0 = dxfModel;
      this.OnBeforeRead(new ReadEventArgs(this.dxfModel_0));
      Class375 class375 = new Class375(dxfModel, this.dxfMessageCollection_0);
      class375.LoadUnknownObjects = this.bool_0;
      this.class375_0 = class375;
      CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
      this.method_359(this.method_354());
      bool flag = false;
      this.method_85();
      try
      {
        dxfModel.Deactivate();
        while (this.method_357(Class824.struct18_0))
        {
          this.method_85();
          if (this.struct18_0 == Class824.struct18_2)
            this.method_93();
          else if (this.struct18_0 == Class824.struct18_3)
            this.method_94();
          else if (this.struct18_0 == Class824.struct18_5)
            this.method_96();
          else if (this.struct18_0 == Class824.struct18_16)
          {
            if (!flag)
            {
              DxfReader.smethod_0(dxfModel);
              flag = true;
            }
            this.method_118();
          }
          else if (this.struct18_0 == Class824.struct18_20)
          {
            if (!flag)
            {
              DxfReader.smethod_0(dxfModel);
              flag = true;
            }
            this.method_127();
          }
          else if (this.struct18_0 == Class824.struct18_24)
            this.method_252();
          else if (this.struct18_0 == Class824.struct18_25)
            this.method_347();
        }
        this.ResolveReferences();
      }
      catch (Exception ex)
      {
        DxfMessage dxfMessage = new DxfMessage(DxfStatus.DxfReadError, Severity.Error);
        dxfMessage.Parameters.Add("Position", (object) this.interface33_0.Position);
        this.dxfMessageCollection_0.Add(dxfMessage);
        throw new Exception(dxfMessage.ToString(), ex);
      }
      finally
      {
        dxfModel.method_33();
        Thread.CurrentThread.CurrentCulture = currentCulture;
        this.interface33_0.imethod_3(this.bool_1);
        this.OnProgress(1f);
      }
    }

    private static void smethod_0(DxfModel dxfModel)
    {
      dxfModel.method_9(!dxfModel.Header.Handling);
      dxfModel.method_10(!dxfModel.Header.Handling);
    }

    public DxfModel Read()
    {
      this.dxfModel_0 = new DxfModel(DxfVersion.Dxf12, false);
      this.dxfModel_0.Filename = this.string_0;
      this.Read(this.dxfModel_0);
      return this.dxfModel_0;
    }

    public DxfModel Model
    {
      get
      {
        return this.dxfModel_0;
      }
    }

    internal Class375 ModelBuilder
    {
      get
      {
        return this.class375_0;
      }
    }

    internal Interface33 GroupReader
    {
      get
      {
        return this.interface33_0;
      }
    }

    internal Struct18 CurrentGroup
    {
      get
      {
        return this.struct18_0;
      }
    }

    internal void method_85()
    {
      do
      {
        this.struct18_0 = this.interface33_0.imethod_0(this);
      }
      while (this.struct18_0.Code == 999);
      this.method_88();
    }

    internal void method_86()
    {
      do
      {
        this.struct18_0 = this.interface33_0.imethod_2(this);
      }
      while (this.struct18_0.Code == 999);
      this.method_88();
    }

    internal void method_87(int baseGroupCode)
    {
      do
      {
        this.struct18_0 = this.interface33_0.imethod_1(this, baseGroupCode);
      }
      while (this.struct18_0.Code == 999);
      this.method_88();
    }

    private void method_88()
    {
      if (this.struct18_0 == Struct18.struct18_0)
        throw new DxfException("Unexpected end of file.");
      ++this.int_1;
      if (this.int_1 != this.int_3)
        return;
      this.int_1 = 0;
      this.OnProgress((float) this.stream_0.Position / (float) this.long_0);
    }

    internal void Add(Class259 objectBuilder)
    {
      this.class375_0.ObjectBuilders.Add(objectBuilder);
    }

    internal void method_89(Class259 objectBuilder)
    {
      this.class375_0.method_1(objectBuilder);
    }

    internal void method_90(System.Action<DxfObjectReference> setObjectReference)
    {
      this.class375_0.method_10((ulong) this.struct18_0.Value, setObjectReference);
    }

    internal void method_91(string subclass)
    {
      if (this.struct18_0.Code != 100 || (string) this.struct18_0.Value != subclass)
        throw new Exception("Expected " + subclass + " subclass marker but got " + (object) this.struct18_0 + ".");
    }

    internal bool method_92(string subclass)
    {
      if (this.struct18_0.Code != 0 && (this.struct18_0.Code != 100 || !((string) this.struct18_0.Value != subclass)))
        return this.struct18_0 == Struct18.struct18_0;
      return true;
    }

    internal static DxfEntity smethod_1(
      DxfModel model,
      Interface33 groupReader,
      Struct18 endGroup)
    {
      DxfReader dxfReader = new DxfReader(model, groupReader);
      dxfReader.method_85();
      List<DxfEntity> dxfEntityList = new List<DxfEntity>();
      dxfReader.method_128((IList<DxfEntity>) dxfEntityList, endGroup);
      if (dxfEntityList.Count > 0)
        return dxfEntityList[0];
      return (DxfEntity) null;
    }

    private void method_93()
    {
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        string str = (string) this.struct18_0.Value;
        List<Struct18> struct18List = new List<Struct18>();
        this.method_85();
        do
        {
          struct18List.Add(this.struct18_0);
          this.method_85();
        }
        while (this.struct18_0.Code != 9 && this.struct18_0.Code != 0);
        object obj;
        if (struct18List.Count == 1)
        {
          DxfReader.Delegate0 delegate0;
          if (DxfReader.dictionary_1.TryGetValue(str, out delegate0))
          {
            obj = struct18List[0].Value;
            delegate0(this.dxfModel_0.Header, (Class374) this.class375_0, obj);
          }
          else
          {
            obj = (object) struct18List;
            this.dxfModel_0.Header.method_0(str, struct18List);
          }
        }
        else
        {
          obj = (object) struct18List;
          DxfReader.Delegate0 delegate0;
          if (DxfReader.dictionary_1.TryGetValue(str, out delegate0))
            delegate0(this.dxfModel_0.Header, (Class374) this.class375_0, obj);
          else
            this.dxfModel_0.Header.method_0(str, struct18List);
        }
        this.class375_0.method_25(str, obj);
      }
    }

    private void method_94()
    {
      while (this.struct18_0 != Struct18.struct18_0 && this.struct18_0 != Class824.struct18_1)
      {
        if (this.struct18_0 == Class824.struct18_4)
          this.method_95();
        else
          this.method_85();
      }
    }

    private void method_95()
    {
      DxfClass dxfClass = new DxfClass();
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 1:
            dxfClass.DxfName = (string) this.struct18_0.Value;
            break;
          case 2:
            dxfClass.CPlusPlusClassName = (string) this.struct18_0.Value;
            break;
          case 3:
            dxfClass.ApplicationName = (string) this.struct18_0.Value;
            break;
          case 90:
            dxfClass.ProxyFlags = (ProxyFlags) (int) this.struct18_0.Value;
            break;
          case 280:
            dxfClass.WasAZombie = DxfReader.smethod_7((byte) this.struct18_0.Value);
            break;
          case 281:
            bool flag = DxfReader.smethod_7((byte) this.struct18_0.Value);
            dxfClass.ItemClassId = flag ? (short) 498 : (short) 499;
            break;
        }
        this.method_85();
      }
      this.dxfModel_0.Classes.Add(dxfClass);
    }

    private void method_96()
    {
      while (this.struct18_0 != Struct18.struct18_0 && this.struct18_0 != Class824.struct18_1)
      {
        if (this.struct18_0 == Class824.struct18_6)
        {
          this.method_85();
          if (this.struct18_0.Code == 2)
          {
            switch ((string) this.struct18_0.Value)
            {
              case "LAYER":
                this.method_97();
                break;
              case "LTYPE":
                this.method_101();
                break;
              case "STYLE":
                this.method_99();
                break;
              case "UCS":
                this.method_104();
                break;
              case "VIEW":
                this.method_106();
                break;
              case "VPORT":
                this.method_108();
                break;
              case "DIMSTYLE":
                this.method_110();
                break;
              case "BLOCK_RECORD":
                this.method_113();
                break;
              case "APPID":
                this.method_115();
                break;
            }
          }
        }
        this.method_85();
      }
      foreach (Pair<DxfView, ulong> pair in this.list_7)
      {
        DxfUcs dxfUcs = this.method_125<DxfUcs>(pair.Second);
        pair.First.Ucs = dxfUcs;
      }
      foreach (Pair<DxfVPort, ulong> pair in this.list_8)
      {
        DxfUcs dxfUcs = this.method_125<DxfUcs>(pair.Second);
        pair.First.Ucs = dxfUcs;
      }
    }

    private void method_97()
    {
      this.dxfModel_0.LayerTable = this.method_117();
      while (this.struct18_0 == Class824.struct18_7)
      {
        DxfLayer layer = new DxfLayer();
        this.method_98(layer);
        DxfLayer dxfLayer;
        if (this.dxfModel_0.Layers.TryGetValue(layer.Name, out dxfLayer))
          this.dxfModel_0.Layers.Remove(dxfLayer);
        this.dxfModel_0.Layers.Add(layer);
      }
    }

    private void method_98(DxfLayer layer)
    {
      Class320 class320 = new Class320(layer);
      this.class375_0.ObjectBuilders.Add((Class259) class320);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 2:
            layer.Name = (string) this.struct18_0.Value;
            break;
          case 6:
            string second = (string) this.struct18_0.Value;
            this.list_3.Add(new Pair<DxfLayer, string>(layer, second));
            break;
          case 62:
            short colorIndex = (short) this.struct18_0.Value;
            if (colorIndex < (short) 0)
            {
              layer.Enabled = false;
              layer.Color = Color.CreateFromColorIndex(-colorIndex);
              break;
            }
            layer.Enabled = true;
            layer.Color = Color.CreateFromColorIndex(colorIndex);
            break;
          case 70:
            layer.Flags = (LayerFlags) this.struct18_0.Value;
            break;
          case 290:
            layer.PlotEnabled = (bool) this.struct18_0.Value;
            break;
          case 348:
            long num = (long) (ulong) this.struct18_0.Value;
            break;
          case 370:
            layer.LineWeight = (short) this.struct18_0.Value;
            break;
          case 420:
            int rgb = (int) this.struct18_0.Value;
            layer.Color = Color.CreateFromRgb(rgb);
            break;
          case 430:
            class320.DxfColorConcatenatedName = (string) this.struct18_0.Value;
            break;
          case 440:
            layer.Transparency = new Transparency((uint) (int) this.struct18_0.Value);
            break;
          default:
            if (layer.method_6(this, (Class259) class320))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_99()
    {
      this.dxfModel_0.TextStyleTable = this.method_117();
      while (this.struct18_0 == Class824.struct18_9)
      {
        DxfTextStyle textStyle = new DxfTextStyle();
        this.method_100(textStyle);
        bool flag = false;
        if (!string.IsNullOrEmpty(textStyle.Name))
        {
          DxfTextStyle textStyleWithName = this.dxfModel_0.GetTextStyleWithName(textStyle.Name);
          if (textStyleWithName != null)
          {
            flag = true;
            this.class375_0.Remove((DxfHandledObject) textStyle);
            if (textStyle.Handle != 0UL && textStyleWithName.Handle != 0UL)
              this.class375_0.HandleToObjectInfo.Add(textStyle.Handle, this.class375_0.method_8(textStyleWithName.Handle));
            this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.SkippedDuplicateTableRecord, Severity.Warning, "RecordName", (object) textStyle.Name)
            {
              Parameters = {
                {
                  "TableName",
                  (object) "TextStyle"
                }
              }
            });
          }
        }
        if (!flag)
          this.dxfModel_0.TextStyles.Add(textStyle);
      }
    }

    private void method_100(DxfTextStyle textStyle)
    {
      Class259 objectBuilder = new Class259((DxfHandledObject) textStyle);
      this.class375_0.ObjectBuilders.Add(objectBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 2:
            textStyle.method_9((string) this.struct18_0.Value);
            break;
          case 3:
            string str = (string) this.struct18_0.Value;
            textStyle.FontFilename = str;
            if (str.ToLower().EndsWith(".shx") && !this.dxfModel_0.method_34(textStyle.FontFilename))
            {
              this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.ShxFontNotFound, Severity.Warning)
              {
                Parameters = {
                  {
                    "FontFilename",
                    (object) str
                  }
                }
              });
              break;
            }
            break;
          case 4:
            textStyle.BigFontFilename = (string) this.struct18_0.Value;
            break;
          case 40:
            textStyle.FixedHeight = (double) this.struct18_0.Value;
            break;
          case 41:
            textStyle.WidthFactor = (double) this.struct18_0.Value;
            break;
          case 42:
            textStyle.LastHeightUsed = (double) this.struct18_0.Value;
            break;
          case 50:
            textStyle.ObliqueAngle = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
            break;
          case 70:
            textStyle.Flags = (TextStyleFlags) (short) this.struct18_0.Value;
            break;
          case 71:
            textStyle.TextGenerationFlags = (TextGenerationFlags) this.struct18_0.Value;
            break;
          default:
            if (textStyle.method_6(this, objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_101()
    {
      this.dxfModel_0.LineTypeTable = this.method_117();
      while (this.struct18_0 == Class824.struct18_8)
      {
        DxfLineType lineType = new DxfLineType();
        this.method_102(lineType);
        DxfLineType lineTypeWithName = this.dxfModel_0.GetLineTypeWithName(lineType.Name);
        if (lineTypeWithName != null)
          this.dxfModel_0.LineTypes.Remove(lineTypeWithName);
        this.dxfModel_0.LineTypes.Add(lineType);
      }
    }

    private void method_102(DxfLineType lineType)
    {
      Class315 lineTypeBuilder = new Class315(lineType);
      this.class375_0.ObjectBuilders.Add((Class259) lineTypeBuilder);
      this.method_85();
      DxfLineType.Element complexElement = (DxfLineType.Element) null;
      Class891 complexElementBuilder = (Class891) null;
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 2:
            lineType.method_8((string) this.struct18_0.Value);
            break;
          case 3:
            lineType.Description = (string) this.struct18_0.Value;
            break;
          case 9:
            if (complexElement == null)
              this.method_103(lineType, lineTypeBuilder, ref complexElement, ref complexElementBuilder);
            complexElement.Text = (string) this.struct18_0.Value;
            break;
          case 44:
            complexElement.Offset = new Vector2D((double) this.struct18_0.Value, complexElement.Offset.Y);
            break;
          case 45:
            complexElement.Offset = new Vector2D(complexElement.Offset.X, (double) this.struct18_0.Value);
            break;
          case 46:
            complexElement.Scale = (double) this.struct18_0.Value;
            break;
          case 49:
            this.method_103(lineType, lineTypeBuilder, ref complexElement, ref complexElementBuilder);
            complexElement.Length = (double) this.struct18_0.Value;
            break;
          case 50:
            complexElement.Rotation = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
            break;
          case 70:
            lineType.Flags = (StandardFlags) this.struct18_0.Value;
            break;
          case 74:
            if (complexElement != null)
            {
              DxfLineType.ElementType elementType = (DxfLineType.ElementType) this.struct18_0.Value;
              complexElement.ElementType = elementType;
              break;
            }
            break;
          case 75:
            complexElement.ShapeNumber = (short) this.struct18_0.Value;
            break;
          case 340:
            complexElementBuilder.TextStyleHandle = (ulong) this.struct18_0.Value;
            break;
          default:
            if (lineType.method_6(this, (Class259) lineTypeBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_103(
      DxfLineType lineType,
      Class315 lineTypeBuilder,
      ref DxfLineType.Element complexElement,
      ref Class891 complexElementBuilder)
    {
      complexElement = new DxfLineType.Element();
      lineType.Elements.Add(complexElement);
      complexElementBuilder = new Class891(lineType, complexElement);
      lineTypeBuilder.Add((Interface10) complexElementBuilder);
    }

    private void method_104()
    {
      this.dxfModel_0.UcsTable = this.method_117();
      while (this.struct18_0 == Class824.struct18_11)
      {
        DxfUcs ucs = new DxfUcs();
        this.method_105(ucs);
        DxfUcs ucsWithName = this.dxfModel_0.GetUcsWithName(ucs.Name);
        if (ucsWithName != null)
          this.dxfModel_0.UcsCollection.Remove(ucsWithName);
        this.dxfModel_0.UcsCollection.Add(ucs);
      }
    }

    private void method_105(DxfUcs ucs)
    {
      Class259 objectBuilder = new Class259((DxfHandledObject) ucs);
      this.class375_0.ObjectBuilders.Add(objectBuilder);
      this.method_85();
      OrthographicType orthographic = OrthographicType.None;
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 2:
            ucs.Name = (string) this.struct18_0.Value;
            goto case 79;
          case 10:
            WW.Math.Point3D origin1 = ucs.Origin;
            origin1.X = (double) this.struct18_0.Value;
            ucs.Origin = origin1;
            goto case 79;
          case 11:
            WW.Math.Vector3D xaxis1 = ucs.XAxis;
            xaxis1.X = (double) this.struct18_0.Value;
            ucs.XAxis = xaxis1;
            goto case 79;
          case 12:
            WW.Math.Vector3D yaxis1 = ucs.YAxis;
            yaxis1.X = (double) this.struct18_0.Value;
            ucs.YAxis = yaxis1;
            goto case 79;
          case 13:
            WW.Math.Vector3D relativeOrigin1 = ucs.GetRelativeOrigin(orthographic);
            relativeOrigin1.X = (double) this.struct18_0.Value;
            ucs.SetRelativeOrigin(orthographic, relativeOrigin1);
            goto case 79;
          case 20:
            WW.Math.Point3D origin2 = ucs.Origin;
            origin2.Y = (double) this.struct18_0.Value;
            ucs.Origin = origin2;
            goto case 79;
          case 21:
            WW.Math.Vector3D xaxis2 = ucs.XAxis;
            xaxis2.Y = (double) this.struct18_0.Value;
            ucs.XAxis = xaxis2;
            goto case 79;
          case 22:
            WW.Math.Vector3D yaxis2 = ucs.YAxis;
            yaxis2.Y = (double) this.struct18_0.Value;
            ucs.YAxis = yaxis2;
            goto case 79;
          case 23:
            WW.Math.Vector3D relativeOrigin2 = ucs.GetRelativeOrigin(orthographic);
            relativeOrigin2.Y = (double) this.struct18_0.Value;
            ucs.SetRelativeOrigin(orthographic, relativeOrigin2);
            goto case 79;
          case 30:
            WW.Math.Point3D origin3 = ucs.Origin;
            origin3.Z = (double) this.struct18_0.Value;
            ucs.Origin = origin3;
            goto case 79;
          case 31:
            WW.Math.Vector3D xaxis3 = ucs.XAxis;
            xaxis3.Z = (double) this.struct18_0.Value;
            ucs.XAxis = xaxis3;
            goto case 79;
          case 32:
            WW.Math.Vector3D yaxis3 = ucs.YAxis;
            yaxis3.Z = (double) this.struct18_0.Value;
            ucs.YAxis = yaxis3;
            goto case 79;
          case 33:
            WW.Math.Vector3D relativeOrigin3 = ucs.GetRelativeOrigin(orthographic);
            relativeOrigin3.Z = (double) this.struct18_0.Value;
            ucs.SetRelativeOrigin(orthographic, relativeOrigin3);
            goto case 79;
          case 70:
            ucs.Flags = (StandardFlags) this.struct18_0.Value;
            goto case 79;
          case 71:
            orthographic = (OrthographicType) (short) this.struct18_0.Value;
            goto case 79;
          case 79:
            this.method_85();
            continue;
          case 146:
            ucs.Elevation = (double) this.struct18_0.Value;
            goto case 79;
          default:
            if (ucs.method_6(this, objectBuilder))
              continue;
            goto case 79;
        }
      }
    }

    private void method_106()
    {
      this.dxfModel_0.ViewTable = this.method_117();
      while (this.struct18_0 == Class824.struct18_12)
      {
        DxfView view = new DxfView();
        this.method_107(view);
        DxfView viewWithName = this.dxfModel_0.GetViewWithName(view.Name);
        if (viewWithName != null)
          this.dxfModel_0.Views.Remove(viewWithName);
        this.dxfModel_0.Views.Add(view);
      }
    }

    private void method_107(DxfView view)
    {
      Class259 objectBuilder = new Class259((DxfHandledObject) view);
      this.class375_0.ObjectBuilders.Add(objectBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 2:
            view.method_8((string) this.struct18_0.Value);
            break;
          case 10:
            WW.Math.Point2D center1 = view.Center;
            center1.X = (double) this.struct18_0.Value;
            view.Center = center1;
            break;
          case 11:
            WW.Math.Vector3D direction1 = view.Direction;
            direction1.X = (double) this.struct18_0.Value;
            view.Direction = direction1;
            break;
          case 12:
            WW.Math.Point3D target1 = view.Target;
            target1.X = (double) this.struct18_0.Value;
            view.Target = target1;
            break;
          case 20:
            WW.Math.Point2D center2 = view.Center;
            center2.Y = (double) this.struct18_0.Value;
            view.Center = center2;
            break;
          case 21:
            WW.Math.Vector3D direction2 = view.Direction;
            direction2.Y = (double) this.struct18_0.Value;
            view.Direction = direction2;
            break;
          case 22:
            WW.Math.Point3D target2 = view.Target;
            target2.Y = (double) this.struct18_0.Value;
            view.Target = target2;
            break;
          case 31:
            WW.Math.Vector3D direction3 = view.Direction;
            direction3.Z = (double) this.struct18_0.Value;
            view.Direction = direction3;
            break;
          case 32:
            WW.Math.Point3D target3 = view.Target;
            target3.Z = (double) this.struct18_0.Value;
            view.Target = target3;
            break;
          case 40:
            Size2D size1 = view.Size;
            size1.Y = (double) this.struct18_0.Value;
            view.Size = size1;
            break;
          case 41:
            Size2D size2 = view.Size;
            size2.X = (double) this.struct18_0.Value;
            view.Size = size2;
            break;
          case 42:
            view.LensLength = (double) this.struct18_0.Value;
            break;
          case 43:
            view.FrontClippingPlane = (double) this.struct18_0.Value;
            break;
          case 44:
            view.BackClippingPlane = (double) this.struct18_0.Value;
            break;
          case 50:
            view.TwistAngle = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
            break;
          case 70:
            view.Flags = (ViewFlags) (ushort) (short) this.struct18_0.Value;
            break;
          case 71:
            view.ViewMode = (ViewMode) this.struct18_0.Value;
            break;
          case 72:
            view.UcsPerView = (short) this.struct18_0.Value == (short) 1;
            break;
          case 79:
            view.UcsOrthographicType = (OrthographicType) (short) this.struct18_0.Value;
            break;
          case 110:
            WW.Math.Point3D origin1 = view.Ucs.Origin;
            origin1.X = (double) this.struct18_0.Value;
            view.Ucs.Origin = origin1;
            break;
          case 111:
            WW.Math.Vector3D xaxis1 = view.Ucs.XAxis;
            xaxis1.X = (double) this.struct18_0.Value;
            view.Ucs.XAxis = xaxis1;
            break;
          case 112:
            WW.Math.Vector3D yaxis1 = view.Ucs.YAxis;
            yaxis1.X = (double) this.struct18_0.Value;
            view.Ucs.YAxis = yaxis1;
            break;
          case 120:
            WW.Math.Point3D origin2 = view.Ucs.Origin;
            origin2.Y = (double) this.struct18_0.Value;
            view.Ucs.Origin = origin2;
            break;
          case 121:
            WW.Math.Vector3D xaxis2 = view.Ucs.XAxis;
            xaxis2.Y = (double) this.struct18_0.Value;
            view.Ucs.XAxis = xaxis2;
            break;
          case 122:
            WW.Math.Vector3D yaxis2 = view.Ucs.YAxis;
            yaxis2.Y = (double) this.struct18_0.Value;
            view.Ucs.YAxis = yaxis2;
            break;
          case 130:
            WW.Math.Point3D origin3 = view.Ucs.Origin;
            origin3.Z = (double) this.struct18_0.Value;
            view.Ucs.Origin = origin3;
            break;
          case 131:
            WW.Math.Vector3D xaxis3 = view.Ucs.XAxis;
            xaxis3.Z = (double) this.struct18_0.Value;
            view.Ucs.XAxis = xaxis3;
            break;
          case 132:
            WW.Math.Vector3D yaxis3 = view.Ucs.YAxis;
            yaxis3.Z = (double) this.struct18_0.Value;
            view.Ucs.YAxis = yaxis3;
            break;
          case 146:
            view.Ucs.Elevation = (double) this.struct18_0.Value;
            break;
          case 281:
            view.RenderMode = (RenderMode) this.struct18_0.Value;
            break;
          case 345:
          case 346:
            ulong second = (ulong) this.struct18_0.Value;
            this.list_7.Add(new Pair<DxfView, ulong>(view, second));
            break;
          default:
            if (view.method_6(this, objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_108()
    {
      this.dxfModel_0.VPortTable = this.method_117();
      while (this.struct18_0 == Class824.struct18_13)
      {
        DxfVPort vport = new DxfVPort();
        this.method_109(vport);
        this.dxfModel_0.VPorts.Add(vport);
      }
    }

    private void method_109(DxfVPort vport)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfReader.Class45 class45 = new DxfReader.Class45();
      // ISSUE: reference to a compiler-generated field
      class45.dxfVPort_0 = vport;
      // ISSUE: reference to a compiler-generated field
      Class325 class325 = new Class325(class45.dxfVPort_0);
      this.class375_0.ObjectBuilders.Add((Class259) class325);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 2:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Name = (string) this.struct18_0.Value;
            break;
          case 10:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Point2D bottomLeft1 = class45.dxfVPort_0.BottomLeft;
            bottomLeft1.X = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.BottomLeft = bottomLeft1;
            break;
          case 11:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Point2D topRight1 = class45.dxfVPort_0.TopRight;
            topRight1.X = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.TopRight = topRight1;
            break;
          case 12:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Point2D center1 = class45.dxfVPort_0.Center;
            center1.X = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Center = center1;
            break;
          case 13:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Point2D snapBasePoint1 = class45.dxfVPort_0.SnapBasePoint;
            snapBasePoint1.X = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.SnapBasePoint = snapBasePoint1;
            break;
          case 14:
            // ISSUE: reference to a compiler-generated field
            Vector2D snapSpacing1 = class45.dxfVPort_0.SnapSpacing;
            snapSpacing1.X = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.SnapSpacing = snapSpacing1;
            break;
          case 15:
            // ISSUE: reference to a compiler-generated field
            Vector2D gridSpacing1 = class45.dxfVPort_0.GridSpacing;
            gridSpacing1.X = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.GridSpacing = gridSpacing1;
            break;
          case 16:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Vector3D direction1 = class45.dxfVPort_0.Direction;
            direction1.X = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Direction = direction1;
            break;
          case 17:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Point3D target1 = class45.dxfVPort_0.Target;
            target1.X = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Target = target1;
            break;
          case 20:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Point2D bottomLeft2 = class45.dxfVPort_0.BottomLeft;
            bottomLeft2.Y = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.BottomLeft = bottomLeft2;
            break;
          case 21:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Point2D topRight2 = class45.dxfVPort_0.TopRight;
            topRight2.Y = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.TopRight = topRight2;
            break;
          case 22:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Point2D center2 = class45.dxfVPort_0.Center;
            center2.Y = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Center = center2;
            break;
          case 23:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Point2D snapBasePoint2 = class45.dxfVPort_0.SnapBasePoint;
            snapBasePoint2.Y = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.SnapBasePoint = snapBasePoint2;
            break;
          case 24:
            // ISSUE: reference to a compiler-generated field
            Vector2D snapSpacing2 = class45.dxfVPort_0.SnapSpacing;
            snapSpacing2.Y = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.SnapSpacing = snapSpacing2;
            break;
          case 25:
            // ISSUE: reference to a compiler-generated field
            Vector2D gridSpacing2 = class45.dxfVPort_0.GridSpacing;
            gridSpacing2.Y = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.GridSpacing = gridSpacing2;
            break;
          case 26:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Vector3D direction2 = class45.dxfVPort_0.Direction;
            direction2.Y = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Direction = direction2;
            break;
          case 27:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Point3D target2 = class45.dxfVPort_0.Target;
            target2.Y = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Target = target2;
            break;
          case 36:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Vector3D direction3 = class45.dxfVPort_0.Direction;
            direction3.Z = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Direction = direction3;
            break;
          case 37:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Point3D target3 = class45.dxfVPort_0.Target;
            target3.Z = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Target = target3;
            break;
          case 40:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Height = (double) this.struct18_0.Value;
            break;
          case 41:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.AspectRatio = (double) this.struct18_0.Value;
            break;
          case 42:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.LensLength = (double) this.struct18_0.Value;
            break;
          case 43:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.FrontClippingPlane = (double) this.struct18_0.Value;
            break;
          case 44:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.BackClippingPlane = (double) this.struct18_0.Value;
            break;
          case 50:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.SnapRotationAngle = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
            break;
          case 51:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.TwistAngle = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
            break;
          case 60:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.GridFlags = (Enum17) this.struct18_0.Int16;
            break;
          case 61:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.MinorGridLinesPerMajorGridLine = this.struct18_0.Int16;
            break;
          case 63:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.AmbientColor = Color.CreateFromColorIndex((short) this.struct18_0.Value);
            break;
          case 65:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.UcsPerViewport = (short) this.struct18_0.Value == (short) 1;
            break;
          case 70:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Flags = (StandardFlags) this.struct18_0.Value;
            break;
          case 71:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.ViewMode = (ViewMode) this.struct18_0.Value;
            break;
          case 72:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.method_8((short) this.struct18_0.Value);
            break;
          case 73:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.FastZoomPercent = (short) this.struct18_0.Value;
            break;
          case 74:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.DisplayUcs = (short) this.struct18_0.Value == (short) 1;
            break;
          case 75:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Snap = (short) this.struct18_0.Value == (short) 1;
            break;
          case 76:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.ShowGrid = (short) this.struct18_0.Value == (short) 1;
            break;
          case 77:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.SnapStyle = (SnapStyle) this.struct18_0.Value;
            break;
          case 78:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.SnapIsoPair = (short) this.struct18_0.Value;
            break;
          case 79:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.UcsOrthographicType = (OrthographicType) (short) this.struct18_0.Value;
            break;
          case 110:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Point3D origin1 = class45.dxfVPort_0.Ucs.Origin;
            origin1.X = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Ucs.Origin = origin1;
            break;
          case 111:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Vector3D xaxis1 = class45.dxfVPort_0.Ucs.XAxis;
            xaxis1.X = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Ucs.XAxis = xaxis1;
            break;
          case 112:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Vector3D yaxis1 = class45.dxfVPort_0.Ucs.YAxis;
            yaxis1.X = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Ucs.YAxis = yaxis1;
            break;
          case 120:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Point3D origin2 = class45.dxfVPort_0.Ucs.Origin;
            origin2.Y = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Ucs.Origin = origin2;
            break;
          case 121:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Vector3D xaxis2 = class45.dxfVPort_0.Ucs.XAxis;
            xaxis2.Y = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Ucs.XAxis = xaxis2;
            break;
          case 122:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Vector3D yaxis2 = class45.dxfVPort_0.Ucs.YAxis;
            yaxis2.Y = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Ucs.YAxis = yaxis2;
            break;
          case 130:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Point3D origin3 = class45.dxfVPort_0.Ucs.Origin;
            origin3.Z = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Ucs.Origin = origin3;
            break;
          case 131:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Vector3D xaxis3 = class45.dxfVPort_0.Ucs.XAxis;
            xaxis3.Z = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Ucs.XAxis = xaxis3;
            break;
          case 132:
            // ISSUE: reference to a compiler-generated field
            WW.Math.Vector3D yaxis3 = class45.dxfVPort_0.Ucs.YAxis;
            yaxis3.Z = (double) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Ucs.YAxis = yaxis3;
            break;
          case 141:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Brightness = (double) this.struct18_0.Value;
            break;
          case 142:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Contrast = (double) this.struct18_0.Value;
            break;
          case 146:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.Ucs.Elevation = (double) this.struct18_0.Value;
            break;
          case 281:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.RenderMode = (RenderMode) this.struct18_0.Value;
            break;
          case 282:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.DefaultLightingType = (DefaultLightingType) (byte) this.struct18_0.Value;
            break;
          case 292:
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.UseDefaultLighting = (bool) this.struct18_0.Value;
            break;
          case 345:
          case 346:
            ulong second = (ulong) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            this.list_8.Add(new Pair<DxfVPort, ulong>(class45.dxfVPort_0, second));
            break;
          case 348:
            // ISSUE: reference to a compiler-generated method
            this.class375_0.method_10((ulong) this.struct18_0.Value, new System.Action<DxfObjectReference>(class45.method_0));
            break;
          case 421:
            int rgb = (int) this.struct18_0.Value;
            // ISSUE: reference to a compiler-generated field
            class45.dxfVPort_0.AmbientColor = Color.CreateFromRgb(rgb);
            break;
          case 431:
            class325.AmbientDxfColorConcatenatedName = (string) this.struct18_0.Value;
            break;
          default:
            // ISSUE: reference to a compiler-generated field
            if (class45.dxfVPort_0.method_6(this, (Class259) class325))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private void method_110()
    {
      this.dxfModel_0.DimStyleTable = this.method_117();
      while (this.struct18_0 == Class824.struct18_14)
      {
        DxfDimensionStyle dimStyle = new DxfDimensionStyle(this.dxfModel_0);
        this.method_111(dimStyle);
        if (!this.dxfModel_0.DimensionStyles.Contains(dimStyle.Name))
          this.dxfModel_0.DimensionStyles.Add(dimStyle);
      }
    }

    private void method_111(DxfDimensionStyle dimStyle)
    {
      Class309 objectBuilder = new Class309(dimStyle);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      this.method_85();
      int group70Index = 0;
      while (this.struct18_0.Code != 0)
      {
        if (!this.method_112(dimStyle, objectBuilder, this.struct18_0.Code, ref group70Index))
          this.method_85();
      }
    }

    private bool method_112(
      DxfDimensionStyle dimStyle,
      Class309 objectBuilder,
      int groupCode,
      ref int group70Index)
    {
      switch (groupCode)
      {
        case 2:
          dimStyle.Name = (string) this.struct18_0.Value;
          break;
        case 3:
          dimStyle.PostFix = (string) this.struct18_0.Value;
          break;
        case 4:
          dimStyle.AlternateDimensioningSuffix = (string) this.struct18_0.Value;
          break;
        case 5:
          objectBuilder.ArrowBlockName = (string) this.struct18_0.Value;
          break;
        case 6:
          objectBuilder.FirstArrowBlockName = (string) this.struct18_0.Value;
          break;
        case 7:
          objectBuilder.SecondArrowBlockName = (string) this.struct18_0.Value;
          break;
        case 40:
          dimStyle.ScaleFactor = (double) this.struct18_0.Value;
          break;
        case 41:
          dimStyle.ArrowSize = (double) this.struct18_0.Value;
          break;
        case 42:
          dimStyle.ExtensionLineOffset = (double) this.struct18_0.Value;
          break;
        case 43:
          dimStyle.DimensionLineIncrement = (double) this.struct18_0.Value;
          break;
        case 44:
          dimStyle.ExtensionLineExtension = (double) this.struct18_0.Value;
          break;
        case 45:
          dimStyle.Rounding = (double) this.struct18_0.Value;
          break;
        case 46:
          dimStyle.DimensionLineExtension = (double) this.struct18_0.Value;
          break;
        case 47:
          dimStyle.PlusTolerance = (double) this.struct18_0.Value;
          break;
        case 48:
          dimStyle.MinusTolerance = (double) this.struct18_0.Value;
          break;
        case 49:
          dimStyle.FixedExtensionLineLength = (double) this.struct18_0.Value;
          break;
        case 50:
          dimStyle.JoggedRadiusDimensionTransverseSegmentAngle = (double) this.struct18_0.Value;
          break;
        case 69:
          dimStyle.TextBackgroundFillMode = (DimensionTextBackgroundFillMode) this.struct18_0.Int16;
          break;
        case 70:
          switch (group70Index)
          {
            case 0:
              dimStyle.Flags = (StandardFlags) this.struct18_0.Int16;
              break;
            case 1:
              dimStyle.TextBackgroundColor = Color.CreateFromColorIndex(this.struct18_0.Int16);
              break;
          }
          ++group70Index;
          break;
        case 71:
          dimStyle.GenerateTolerances = this.struct18_0.UInt16 == (ushort) 1;
          break;
        case 72:
          dimStyle.LimitsGeneration = this.struct18_0.UInt16 == (ushort) 1;
          break;
        case 73:
          dimStyle.TextInsideHorizontal = this.struct18_0.UInt16 == (ushort) 1;
          break;
        case 74:
          dimStyle.TextOutsideHorizontal = this.struct18_0.UInt16 == (ushort) 1;
          break;
        case 75:
          dimStyle.SuppressFirstExtensionLine = this.struct18_0.UInt16 == (ushort) 1;
          break;
        case 76:
          dimStyle.SuppressSecondExtensionLine = this.struct18_0.UInt16 == (ushort) 1;
          break;
        case 77:
          dimStyle.TextVerticalAlignment = (DimensionTextVerticalAlignment) this.struct18_0.UInt16;
          break;
        case 78:
          dimStyle.ZeroHandling = (ZeroHandling) this.struct18_0.UInt16;
          break;
        case 79:
          dimStyle.AngularZeroHandling = (ZeroHandling) this.struct18_0.UInt16;
          break;
        case 90:
          dimStyle.ArcLengthSymbolPosition = (ArcLengthSymbolPosition) (int) this.struct18_0.Value;
          break;
        case 105:
          dimStyle.SetHandle((ulong) this.struct18_0.Value);
          this.method_89((Class259) objectBuilder);
          break;
        case 140:
          dimStyle.TextHeight = (double) this.struct18_0.Value;
          break;
        case 141:
          dimStyle.CenterMarkSize = (double) this.struct18_0.Value;
          break;
        case 142:
          dimStyle.TickSize = (double) this.struct18_0.Value;
          break;
        case 143:
          dimStyle.AlternateUnitScaleFactor = (double) this.struct18_0.Value;
          break;
        case 144:
          dimStyle.LinearScaleFactor = (double) this.struct18_0.Value;
          break;
        case 145:
          dimStyle.TextVerticalPosition = (double) this.struct18_0.Value;
          break;
        case 146:
          dimStyle.ToleranceScaleFactor = (double) this.struct18_0.Value;
          break;
        case 147:
          dimStyle.DimensionLineGap = (double) this.struct18_0.Value;
          break;
        case 148:
          dimStyle.AlternateUnitRounding = (double) this.struct18_0.Value;
          break;
        case 170:
          dimStyle.AlternateUnitDimensioning = this.struct18_0.Int16 == (short) 1;
          break;
        case 171:
          dimStyle.AlternateUnitDecimalPlaces = this.struct18_0.Int16;
          break;
        case 172:
          dimStyle.TextOutsideExtensions = this.struct18_0.Int16 == (short) 1;
          break;
        case 173:
          dimStyle.SeparateArrowBlocks = this.struct18_0.Int16 == (short) 1;
          break;
        case 174:
          dimStyle.TextInsideExtensions = this.struct18_0.Int16 == (short) 1;
          break;
        case 175:
          dimStyle.SuppressOutsideExtensions = this.struct18_0.Int16 == (short) 1;
          break;
        case 176:
          short int16_1 = this.struct18_0.Int16;
          dimStyle.DimensionLineColor = Color.CreateFromColorIndex(int16_1);
          break;
        case 177:
          short int16_2 = this.struct18_0.Int16;
          dimStyle.ExtensionLineColor = Color.CreateFromColorIndex(int16_2);
          break;
        case 178:
          short int16_3 = this.struct18_0.Int16;
          dimStyle.TextColor = Color.CreateFromColorIndex(int16_3);
          break;
        case 179:
          dimStyle.AngularDimensionDecimalPlaces = this.struct18_0.Int16;
          break;
        case 270:
          dimStyle.LinearUnitFormat = (LinearUnitFormat) this.struct18_0.Int16;
          break;
        case 271:
          dimStyle.DecimalPlaces = this.struct18_0.Int16;
          break;
        case 272:
          dimStyle.ToleranceDecimalPlaces = this.struct18_0.Int16;
          break;
        case 273:
          dimStyle.AlternateUnitFormat = (AlternateUnitFormat) this.struct18_0.Int16;
          break;
        case 274:
          dimStyle.AlternateUnitToleranceDecimalPlaces = this.struct18_0.Int16;
          break;
        case 275:
          dimStyle.AngularUnit = (AngularUnit) this.struct18_0.Int16;
          break;
        case 276:
          dimStyle.FractionFormat = (FractionFormat) this.struct18_0.Int16;
          break;
        case 277:
          dimStyle.LinearUnitFormat = (LinearUnitFormat) this.struct18_0.Int16;
          break;
        case 278:
          dimStyle.DecimalSeparator = (char) this.struct18_0.Int16;
          break;
        case 279:
          dimStyle.TextMovement = (TextMovement) this.struct18_0.Int16;
          break;
        case 280:
          dimStyle.TextHorizontalAlignment = (DimensionTextHorizontalAlignment) this.struct18_0.Value;
          break;
        case 281:
          dimStyle.SuppressFirstDimensionLine = DxfReader.smethod_7((byte) this.struct18_0.Value);
          break;
        case 282:
          dimStyle.SuppressSecondDimensionLine = DxfReader.smethod_7((byte) this.struct18_0.Value);
          break;
        case 283:
          dimStyle.ToleranceAlignment = (ToleranceAlignment) this.struct18_0.Value;
          break;
        case 284:
          dimStyle.ToleranceZeroHandling = (ZeroHandling) this.struct18_0.Value;
          break;
        case 285:
          dimStyle.AlternateUnitZeroHandling = (ZeroHandling) this.struct18_0.Value;
          break;
        case 286:
          dimStyle.AlternateUnitToleranceZeroHandling = (ZeroHandling) this.struct18_0.Value;
          break;
        case 287:
          dimStyle.ArrowsTextFit = (ArrowsTextFitType) this.struct18_0.Value;
          break;
        case 288:
          dimStyle.CursorUpdate = (CursorUpdate) this.struct18_0.Value;
          break;
        case 289:
          dimStyle.ArrowsTextFit = (ArrowsTextFitType) this.struct18_0.Value;
          break;
        case 290:
          dimStyle.IsExtensionLineLengthFixed = (bool) this.struct18_0.Value;
          break;
        case 340:
          if (this.struct18_0.Value == null)
          {
            objectBuilder.TextStyleName = this.struct18_0.ValueString;
            break;
          }
          objectBuilder.TextStyleHandle = (ulong) this.struct18_0.Value;
          break;
        case 341:
          if (this.struct18_0.Value == null)
          {
            objectBuilder.LeaderArrowBlockName = this.struct18_0.ValueString;
            break;
          }
          objectBuilder.LeaderArrowBlockHandle = (ulong) this.struct18_0.Value;
          break;
        case 342:
          if (this.struct18_0.Value == null)
          {
            objectBuilder.ArrowBlockName = this.struct18_0.ValueString;
            break;
          }
          objectBuilder.ArrowBlockHandle = (ulong) this.struct18_0.Value;
          break;
        case 343:
          if (this.struct18_0.Value == null)
          {
            objectBuilder.FirstArrowBlockName = this.struct18_0.ValueString;
            break;
          }
          objectBuilder.FirstArrowBlockHandle = (ulong) this.struct18_0.Value;
          break;
        case 344:
          if (this.struct18_0.Value == null)
          {
            objectBuilder.SecondArrowBlockName = this.struct18_0.ValueString;
            break;
          }
          objectBuilder.SecondArrowBlockHandle = (ulong) this.struct18_0.Value;
          break;
        case 345:
          if (this.struct18_0.Value == null)
          {
            objectBuilder.DimensionLineLineTypeName = this.struct18_0.ValueString;
            break;
          }
          objectBuilder.DimensionLineLineTypeHandle = (ulong) this.struct18_0.Value;
          break;
        case 346:
          if (this.struct18_0.Value == null)
          {
            objectBuilder.FirstExtensionLineLineTypeName = this.struct18_0.ValueString;
            break;
          }
          objectBuilder.FirstExtensionLineLineTypeHandle = (ulong) this.struct18_0.Value;
          break;
        case 347:
          if (this.struct18_0.Value == null)
          {
            objectBuilder.SecondExtensionLineLineTypeName = this.struct18_0.ValueString;
            break;
          }
          objectBuilder.SecondExtensionLineLineTypeHandle = (ulong) this.struct18_0.Value;
          break;
        case 371:
          dimStyle.DimensionLineWeight = this.struct18_0.Int16;
          break;
        case 372:
          dimStyle.ExtensionLineWeight = this.struct18_0.Int16;
          break;
        default:
          return dimStyle.method_6(this, (Class259) objectBuilder);
      }
      this.method_86();
      return true;
    }

    private void method_113()
    {
      this.dxfModel_0.BlockRecordTable = this.method_117();
      this.class375_0.BlockRecordTableBuilder = (Class322) new Class322.Class323(this.dxfModel_0.BlockRecordTable);
      while (this.struct18_0 == Class824.struct18_19)
      {
        DxfBlock dxfBlock = new DxfBlock(false);
        Class318 blockRecordBuilder = new Class318(dxfBlock);
        this.class375_0.BlockBuilders.Add(blockRecordBuilder);
        this.method_114(blockRecordBuilder, dxfBlock);
        this.class375_0.method_26(dxfBlock);
      }
    }

    private void method_114(Class318 blockRecordBuilder, DxfBlock blockRecord)
    {
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        bool flag = false;
        switch (this.struct18_0.Code)
        {
          case 2:
            blockRecord.method_9((string) this.struct18_0.Value);
            break;
          case 70:
            blockRecord.BlockUnits = (DrawingUnits) this.struct18_0.Value;
            break;
          case 280:
            blockRecord.Explodable = (byte) this.struct18_0.Value != (byte) 0;
            break;
          case 281:
            blockRecord.ScaleUniformly = (byte) this.struct18_0.Value != (byte) 0;
            break;
          case 340:
            blockRecordBuilder.LayoutHandle = (ulong) this.struct18_0.Value;
            break;
          default:
            flag = blockRecord.method_6(this, (Class259) blockRecordBuilder);
            break;
        }
        if (!flag)
          this.method_85();
      }
    }

    private void method_115()
    {
      this.dxfModel_0.AppIdTable = this.method_117();
      while (this.struct18_0 == Class824.struct18_15)
      {
        DxfAppId appId = new DxfAppId();
        this.method_116(appId);
        if (!this.dxfModel_0.AppIds.Contains(appId.Name))
          this.dxfModel_0.AppIds.Add(appId);
      }
    }

    private void method_116(DxfAppId appId)
    {
      Class259 objectBuilder = new Class259((DxfHandledObject) appId);
      this.class375_0.ObjectBuilders.Add(objectBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 2:
            appId.Name = (string) this.struct18_0.Value;
            break;
          case 70:
            appId.Flags = (StandardFlags) this.struct18_0.Value;
            break;
          default:
            if (appId.method_6(this, objectBuilder))
              continue;
            break;
        }
        this.method_85();
      }
    }

    private DxfHandledObject method_117()
    {
      this.method_85();
      DxfHandledObject handledObject = new DxfHandledObject();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 5)
        {
          handledObject.method_0((string) this.struct18_0.Value);
          this.method_89(new Class259(handledObject));
        }
        this.method_85();
      }
      return handledObject;
    }

    private void method_118()
    {
      this.method_85();
      while (this.struct18_0 != Class824.struct18_1 && this.struct18_0 != Struct18.struct18_0)
      {
        if (this.struct18_0 == Class824.struct18_17)
          this.method_119();
        else
          this.method_85();
      }
    }

    private void method_119()
    {
      DxfBlockBegin dxfBlockBegin = new DxfBlockBegin();
      Class289 class289 = new Class289(dxfBlockBegin);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbBlockBegin":
              this.method_120(class289, dxfBlockBegin);
              continue;
            case "AcDbEntity":
              this.method_132((Class285) class289);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else
        {
          bool flag;
          if (!(flag = this.method_121(class289, dxfBlockBegin)))
            flag = this.method_133((Class285) class289);
          if (!flag)
            this.method_85();
        }
      }
      this.class375_0.method_27(class289);
      class289.Entities = new DxfEntityCollection();
      this.method_128((IList<DxfEntity>) class289.Entities, Class824.struct18_18);
      if (this.struct18_0 == Class824.struct18_18)
      {
        class289.BlockEnd = new DxfBlockEnd();
        this.method_122(class289);
      }
      else
        this.method_356(0);
    }

    private void method_120(Class289 blockBuilder, DxfBlockBegin block)
    {
      this.method_91("AcDbBlockBegin");
      this.method_85();
      while (!this.method_92("AcDbBlockBegin"))
      {
        if (!this.method_121(blockBuilder, block))
          this.method_85();
      }
    }

    private bool method_121(Class289 blockBeginBuilder, DxfBlockBegin blockBegin)
    {
      switch (this.struct18_0.Code)
      {
        case 1:
          string str = (string) this.struct18_0.Value;
          if (!string.IsNullOrEmpty(str))
          {
            blockBeginBuilder.ExternalReference = str;
            if (!this.list_0.Contains(blockBeginBuilder.ExternalReference))
            {
              this.list_0.Add(blockBeginBuilder.ExternalReference);
              break;
            }
            break;
          }
          break;
        case 2:
          blockBeginBuilder.Name = (string) this.struct18_0.Value;
          break;
        case 4:
          blockBeginBuilder.Description = (string) this.struct18_0.Value;
          break;
        case 10:
          WW.Math.Vector3D basePoint1 = blockBeginBuilder.BasePoint;
          basePoint1.X = (double) this.struct18_0.Value;
          blockBeginBuilder.BasePoint = basePoint1;
          break;
        case 20:
          WW.Math.Vector3D basePoint2 = blockBeginBuilder.BasePoint;
          basePoint2.Y = (double) this.struct18_0.Value;
          blockBeginBuilder.BasePoint = basePoint2;
          break;
        case 30:
          WW.Math.Vector3D basePoint3 = blockBeginBuilder.BasePoint;
          basePoint3.Z = (double) this.struct18_0.Value;
          blockBeginBuilder.BasePoint = basePoint3;
          break;
        case 70:
          blockBeginBuilder.Flags = new BlockFlags?((BlockFlags) this.struct18_0.Value);
          break;
        default:
          return blockBegin.method_6(this, (Class259) blockBeginBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_122(Class289 blockBeginBuilder)
    {
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 5)
        {
          string handleString = (string) this.struct18_0.Value;
          blockBeginBuilder.BlockEnd.method_0(handleString);
          this.method_89(new Class259((DxfHandledObject) blockBeginBuilder.BlockEnd));
        }
        this.method_85();
      }
    }

    private void ResolveReferences()
    {
      this.class375_0.ResolveReferences();
      foreach (Pair<DxfEntity, string> pair in this.list_2)
      {
        string second = pair.Second;
        DxfLayer dxfLayer;
        if (!this.dxfModel_0.Layers.TryGetValue(second, out dxfLayer))
        {
          dxfLayer = new DxfLayer();
          dxfLayer.Name = second;
          this.dxfModel_0.Layers.Add(dxfLayer);
        }
        pair.First.Layer = dxfLayer;
      }
      foreach (Pair<DxfRasterImage, ulong> pair in this.list_5)
        pair.First.SetImageDef(this.method_125<DxfImageDef>(pair.Second), false);
      foreach (Pair<DxfLayer, string> pair in this.list_3)
        pair.First.LineType = this.dxfModel_0.GetLineTypeWithName(pair.Second);
      foreach (Pair<DxfEntity, string> pair in this.list_4)
      {
        DxfEntity first = pair.First;
        string second = pair.Second;
        first.LineType = string.Compare(second, "ByBlock", StringComparison.InvariantCultureIgnoreCase) != 0 ? this.dxfModel_0.GetLineTypeWithName(second) : this.dxfModel_0.ByBlockLineType;
      }
      foreach (Pair<DxfMLineStyle.Element, string> pair in this.list_6)
        pair.First.LineType = this.dxfModel_0.GetLineTypeWithName(pair.Second);
      foreach (Pair<DxfDimension, string> pair in this.list_9)
      {
        string second = pair.Second;
        if (second != null)
          pair.First.Block = this.dxfModel_0.GetBlockWithName(second);
      }
      foreach (Pair<DxfMLine, ulong> pair in this.list_10)
        pair.First.Style = this.method_125<DxfMLineStyle>(pair.Second);
      foreach (Pair<DxfLeader, ulong> pair in this.list_11)
        pair.First.AssociatedAnnotation = this.method_125<DxfEntity>(pair.Second);
      foreach (Pair<DxfViewport, ulong> pair in this.list_12)
        pair.First.ClippingBoundaryEntity = this.method_125<DxfEntity>(pair.Second);
      foreach (string str in this.list_0)
        ;
      this.method_123();
      this.class375_0.method_13();
      this.class375_0.method_9();
    }

    private void method_123()
    {
      foreach (DxfLayout layout in (KeyedDxfHandledObjectCollection<string, DxfLayout>) this.dxfModel_0.Layouts)
      {
        if (layout.PaperSpace)
          layout.method_9(layout.OwnerBlock.Entities, true);
      }
      DxfLayout dxfLayout = (DxfLayout) null;
      if (this.dxfModel_0.Layouts.Count > 0)
        dxfLayout = this.dxfModel_0.Layouts[0];
      foreach (DxfEntity dxfEntity in this.list_1)
      {
        if (dxfEntity.OwnerObjectSoftReference == null)
        {
          if (dxfLayout != null)
            dxfLayout.Entities.Add(dxfEntity);
          else
            this.dxfModel_0.ModelLayout.Entities.Add(dxfEntity);
        }
        else
        {
          DxfBlock objectSoftReference = (DxfBlock) dxfEntity.OwnerObjectSoftReference;
          if (objectSoftReference == null)
          {
            if (dxfLayout != null)
              dxfLayout.Entities.Add(dxfEntity);
            else
              this.dxfModel_0.ModelLayout.Entities.Add(dxfEntity);
          }
          else
            objectSoftReference.Entities.Add(dxfEntity);
        }
      }
    }

    private DxfHandledObject method_124(ulong handle)
    {
      return this.class375_0.method_3(handle);
    }

    private T method_125<T>(ulong handle) where T : DxfHandledObject
    {
      return this.class375_0.method_4<T>(handle);
    }

    private DxfBlock method_126(ulong handle)
    {
      DxfHandledObject dxfHandledObject = this.method_124(handle);
      DxfBlockBegin dxfBlockBegin = dxfHandledObject as DxfBlockBegin;
      if (dxfBlockBegin != null)
        return dxfBlockBegin.Block;
      return dxfHandledObject as DxfBlock ?? (DxfBlock) null;
    }

    private void method_127()
    {
      this.method_85();
      this.method_128((IList<DxfEntity>) this.dxfModel_0.Entities, Class824.struct18_1);
      List<UnsupportedObject> unsupportedObjectList = new List<UnsupportedObject>((IEnumerable<UnsupportedObject>) this.dictionary_0.Values);
      unsupportedObjectList.Sort();
      foreach (UnsupportedObject unsupportedObject in unsupportedObjectList)
      {
        this.dxfModel_0.UnsupportedObjects.Add(unsupportedObject);
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
      }
    }

    private void method_128(IList<DxfEntity> entities, Struct18 endOfEntitiesMarker)
    {
      while (this.struct18_0 != endOfEntitiesMarker && this.struct18_0 != Struct18.struct18_0)
      {
        if (this.struct18_0.Code == 0)
        {
          DxfEntity dxfEntity = (DxfEntity) null;
          switch (((string) this.struct18_0.Value).ToUpper(CultureInfo.InvariantCulture))
          {
            case "ARC":
              dxfEntity = (DxfEntity) new DxfArc();
              this.method_214((DxfArc) dxfEntity);
              break;
            case "ATTDEF":
              dxfEntity = (DxfEntity) new DxfAttributeDefinition();
              this.method_235((DxfAttributeDefinition) dxfEntity);
              break;
            case "CIRCLE":
              dxfEntity = (DxfEntity) new DxfCircle();
              this.method_211((DxfCircle) dxfEntity);
              break;
            case "DIMENSION":
              dxfEntity = (DxfEntity) this.method_200();
              break;
            case "ELLIPSE":
              dxfEntity = (DxfEntity) new DxfEllipse();
              this.method_218((DxfEllipse) dxfEntity);
              break;
            case "3DFACE":
              dxfEntity = (DxfEntity) new Dxf3DFace();
              this.method_244((Dxf3DFace) dxfEntity);
              break;
            case "HATCH":
              dxfEntity = (DxfEntity) new DxfHatch();
              this.method_247((DxfHatch) dxfEntity);
              break;
            case "POINT":
              dxfEntity = (DxfEntity) new DxfPoint();
              this.method_144((DxfPoint) dxfEntity);
              break;
            case "LEADER":
              dxfEntity = (DxfEntity) new DxfLeader(this.dxfModel_0);
              this.method_147((DxfLeader) dxfEntity);
              break;
            case "3DLINE":
            case "LINE":
              dxfEntity = (DxfEntity) new DxfLine();
              this.method_158((DxfLine) dxfEntity);
              break;
            case "LWPOLYLINE":
              dxfEntity = (DxfEntity) new DxfLwPolyline();
              this.method_175((DxfLwPolyline) dxfEntity);
              break;
            case "MULTILEADER":
              dxfEntity = this.method_129<DxfMLeader>();
              break;
            case "POLYLINE":
              dxfEntity = (DxfEntity) this.method_178();
              break;
            case "ACAD_PROXY_ENTITY":
              dxfEntity = this.method_129<DxfProxyEntity>();
              break;
            case "IMAGE":
              dxfEntity = (DxfEntity) new DxfImage();
              this.method_221((DxfRasterImage) dxfEntity);
              break;
            case "WIPEOUT":
              DxfWipeout dxfWipeout = new DxfWipeout();
              dxfEntity = (DxfEntity) dxfWipeout;
              this.method_221((DxfRasterImage) dxfEntity);
              while (dxfWipeout.BoundaryVertices.Count > 1 && dxfWipeout.BoundaryVertices[0] == dxfWipeout.BoundaryVertices[dxfWipeout.BoundaryVertices.Count - 1])
                dxfWipeout.BoundaryVertices.RemoveAt(dxfWipeout.BoundaryVertices.Count - 1);
              break;
            case "INSERT":
              dxfEntity = (DxfEntity) new DxfInsert();
              this.method_196((DxfInsert) dxfEntity);
              break;
            case "RAY":
              dxfEntity = (DxfEntity) new DxfRay();
              this.method_161((DxfRay) dxfEntity);
              break;
            case "REGION":
              dxfEntity = (DxfEntity) new DxfRegion();
              this.method_167((DxfRegion) dxfEntity);
              break;
            case "BODY":
              dxfEntity = (DxfEntity) new DxfBody();
              this.method_168((DxfBody) dxfEntity);
              break;
            case "MLINE":
              dxfEntity = (DxfEntity) new DxfMLine();
              this.method_173((DxfMLine) dxfEntity);
              break;
            case "XLINE":
              dxfEntity = (DxfEntity) new DxfXLine();
              this.method_171((DxfXLine) dxfEntity);
              break;
            case "SHAPE":
              dxfEntity = (DxfEntity) new DxfShape();
              this.method_223((DxfShape) dxfEntity);
              break;
            case "SOLID":
            case "TRACE":
              dxfEntity = (DxfEntity) new DxfSolid();
              this.method_226((DxfSolid) dxfEntity);
              break;
            case "SPLINE":
              dxfEntity = (DxfEntity) new DxfSpline();
              this.method_229((DxfSpline) dxfEntity);
              break;
            case "TEXT":
              dxfEntity = (DxfEntity) new DxfText();
              this.method_232((DxfText) dxfEntity);
              break;
            case "MTEXT":
              dxfEntity = (DxfEntity) new DxfMText();
              this.method_241((DxfMText) dxfEntity);
              break;
            case "ACAD_TABLE":
              DxfTable table = new DxfTable();
              table.Table2005 = new Class551();
              dxfEntity = (DxfEntity) table;
              this.method_149(table);
              break;
            case "TOLERANCE":
              dxfEntity = (DxfEntity) new DxfTolerance(this.dxfModel_0);
              this.method_156((DxfTolerance) dxfEntity);
              break;
            case "3DSOLID":
              Dxf3DSolid solid = new Dxf3DSolid();
              dxfEntity = (DxfEntity) solid;
              this.method_166(solid);
              break;
            case "OLE2FRAME":
              DxfOle ole = new DxfOle();
              dxfEntity = (DxfEntity) ole;
              this.method_164(ole);
              break;
            case "ACIDBLOCKREFERENCE":
              DxfIDBlockReference idRef = new DxfIDBlockReference();
              dxfEntity = (DxfEntity) idRef;
              this.method_165(idRef);
              break;
            case "VIEWPORT":
              DxfViewport viewport = new DxfViewport();
              if (this.dxfModel_0.Header.Dxf15OrHigher)
                this.method_351(viewport);
              else
                this.method_348(viewport);
              if (viewport.Layer == null)
              {
                viewport.Layer = this.dxfModel_0.ZeroLayer;
                break;
              }
              break;
            default:
              this.method_130((string) this.struct18_0.Value);
              this.method_131();
              break;
          }
          if (dxfEntity != null)
          {
            if (dxfEntity.Layer == null)
              dxfEntity.Layer = this.dxfModel_0.ZeroLayer;
            if (dxfEntity.PaperSpace)
              this.list_1.Add(dxfEntity);
            else
              entities.Add(dxfEntity);
          }
        }
        else
          this.method_85();
      }
    }

    private DxfEntity method_129<T>() where T : DxfEntity, new()
    {
      DxfEntity dxfEntity = (DxfEntity) new T();
      Class285 class285 = (Class285) dxfEntity.vmethod_9(FileFormat.Dxf);
      this.class375_0.ObjectBuilders.Add((Class259) class285);
      dxfEntity.Read(this, (Class259) class285);
      return dxfEntity;
    }

    private void method_130(string entityName)
    {
      UnsupportedObject unsupportedObject;
      if (!this.dictionary_0.TryGetValue(entityName, out unsupportedObject))
      {
        unsupportedObject = new UnsupportedObject(entityName);
        this.dictionary_0[entityName] = unsupportedObject;
      }
      ++unsupportedObject.Count;
    }

    private void method_131()
    {
      Class285 entityBuilder = new Class285((DxfEntity) new DxfUnknownEntity());
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_133(entityBuilder))
          this.method_85();
      }
      this.method_89((Class259) entityBuilder);
    }

    internal void method_132(Class285 entityBuilder)
    {
      this.method_91("AcDbEntity");
      this.method_85();
      while (!this.method_92("AcDbEntity"))
      {
        if (!this.method_133(entityBuilder))
          this.method_85();
      }
    }

    internal bool method_133(Class285 entityBuilder)
    {
      DxfEntity entity = entityBuilder.Entity;
      switch (this.struct18_0.Code)
      {
        case 5:
          string handleString = (string) this.struct18_0.Value;
          entity.method_0(handleString);
          this.class375_0.method_1((Class259) entityBuilder);
          goto case 92;
        case 6:
          entityBuilder.LineTypeName = (string) this.struct18_0.Value;
          goto case 92;
        case 8:
          string str = (string) this.struct18_0.Value;
          DxfLayer dxfLayer;
          if (this.dxfModel_0.Layers.TryGetValue(str, out dxfLayer))
          {
            entity.Layer = dxfLayer;
            goto case 92;
          }
          else
          {
            this.list_2.Add(new Pair<DxfEntity, string>(entity, str));
            goto case 92;
          }
        case 48:
          entity.LineTypeScale = (double) this.struct18_0.Value;
          goto case 92;
        case 60:
          entity.Visible = (short) this.struct18_0.Value != (short) 1;
          goto case 92;
        case 62:
          short colorIndex = (short) this.struct18_0.Value;
          entity.Color = EntityColor.CreateFromColorIndex(colorIndex);
          goto case 92;
        case 67:
          if ((short) this.struct18_0.Value == (short) 1)
          {
            entity.method_10(true);
            goto case 92;
          }
          else
            goto case 92;
        case 92:
        case 310:
          this.method_85();
          return true;
        case 370:
          entity.LineWeight = this.struct18_0.Int16;
          goto case 92;
        case 420:
          int rgb = (int) this.struct18_0.Value;
          entity.Color = EntityColor.CreateFromRgb(rgb);
          goto case 92;
        case 430:
          entityBuilder.DxfColorConcatenatedName = (string) this.struct18_0.Value;
          goto case 92;
        case 440:
          entity.Transparency = new Transparency((uint) (int) this.struct18_0.Value);
          goto case 92;
        default:
          return entity.method_6(this, (Class259) entityBuilder);
      }
    }

    private bool method_134(Class285 entityBuilder, DxfReader.Class40 entity)
    {
      bool flag = true;
      switch (this.struct18_0.Code)
      {
        case 5:
          ulong num = DxfHandledObject.Parse((string) this.struct18_0.Value);
          entity.Handle = num;
          goto case 92;
        case 6:
          entity.LineTypeName = (string) this.struct18_0.Value;
          goto case 92;
        case 8:
          entity.LayerName = (string) this.struct18_0.Value;
          goto case 92;
        case 48:
          entity.LineTypeScale = (double) this.struct18_0.Value;
          goto case 92;
        case 60:
          entity.Visible = (short) this.struct18_0.Value != (short) 1;
          goto case 92;
        case 62:
          short colorIndex = (short) this.struct18_0.Value;
          entity.Color = EntityColor.CreateFromColorIndex(colorIndex);
          goto case 92;
        case 67:
          if ((short) this.struct18_0.Value == (short) 1)
          {
            entity.PaperSpace = true;
            goto case 92;
          }
          else
            goto case 92;
        case 92:
        case 310:
          if (flag)
            this.method_85();
          return true;
        case 102:
          DxfHandledObject.smethod_1(this, (Class259) entityBuilder);
          goto case 92;
        case 330:
          entityBuilder.OwnerHandle = (ulong) this.struct18_0.Value;
          goto case 92;
        case 370:
          entity.LineWeight = this.struct18_0.Int16;
          goto case 92;
        case 420:
          int rgb = (int) this.struct18_0.Value;
          entity.Color = EntityColor.CreateFromRgb(rgb);
          goto case 92;
        case 430:
          entityBuilder.DxfColorConcatenatedName = (string) this.struct18_0.Value;
          goto case 92;
        case 440:
          entity.Transparency = new Transparency((uint) (int) this.struct18_0.Value);
          goto case 92;
        case 1001:
          string key = (string) this.struct18_0.Value;
          DxfAppId appId = (DxfAppId) null;
          this.dxfModel_0.AppIds.TryGetValue(key, out appId);
          DxfExtendedData dxfExtendedData = new DxfExtendedData(appId, DxfExtendedData.ValueCollection.Read((Class259) entityBuilder, this));
          entity.ExtendedDataCollection.Add(dxfExtendedData);
          flag = false;
          goto case 92;
        default:
          return false;
      }
    }

    private void method_135(int code)
    {
      if (this.struct18_0.Code != code)
        throw new Exception("Expected " + (object) code + " group code but got " + (object) this.struct18_0.Code + ".");
    }

    private byte method_136(int code)
    {
      this.method_135(code);
      return (byte) this.struct18_0.Value;
    }

    private bool method_137(int code)
    {
      this.method_135(code);
      return (bool) this.struct18_0.Value;
    }

    private string method_138(int code)
    {
      this.method_135(code);
      return (string) this.struct18_0.Value;
    }

    private short method_139(int code)
    {
      this.method_135(code);
      return (short) this.struct18_0.Value;
    }

    private double method_140(int code)
    {
      this.method_135(code);
      return (double) this.struct18_0.Value;
    }

    private int method_141(int code)
    {
      this.method_135(code);
      return (int) this.struct18_0.Value;
    }

    private ulong method_142(int code)
    {
      this.method_135(code);
      return (ulong) this.struct18_0.Value;
    }

    private ulong method_143(int code)
    {
      this.method_135(code);
      return (ulong) this.struct18_0.Value;
    }

    private void method_144(DxfPoint point)
    {
      Class285 entityBuilder = new Class285((DxfEntity) point);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbPoint":
              this.method_145(entityBuilder, point);
              continue;
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_146(entityBuilder, point))
          this.method_85();
      }
    }

    private void method_145(Class285 entityBuilder, DxfPoint point)
    {
      this.method_91("AcDbPoint");
      this.method_85();
      while (!this.method_92("AcDbPoint"))
      {
        if (!this.method_146(entityBuilder, point))
          this.method_85();
      }
    }

    private bool method_146(Class285 entityBuilder, DxfPoint point)
    {
      switch (this.struct18_0.Code)
      {
        case 10:
          WW.Math.Point3D position1 = point.Position;
          position1.X = (double) this.struct18_0.Value;
          point.Position = position1;
          break;
        case 20:
          WW.Math.Point3D position2 = point.Position;
          position2.Y = (double) this.struct18_0.Value;
          point.Position = position2;
          break;
        case 30:
          WW.Math.Point3D position3 = point.Position;
          position3.Z = (double) this.struct18_0.Value;
          point.Position = position3;
          break;
        case 39:
          point.Thickness = (double) this.struct18_0.Value;
          break;
        case 50:
          point.XAxisAngle = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 210:
          WW.Math.Vector3D zaxis1 = point.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          point.ZAxis = zaxis1;
          break;
        case 220:
          WW.Math.Vector3D zaxis2 = point.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          point.ZAxis = zaxis2;
          break;
        case 230:
          WW.Math.Vector3D zaxis3 = point.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          point.ZAxis = zaxis3;
          break;
        default:
          return this.method_133(entityBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_147(DxfLeader leader)
    {
      Class291 class291 = new Class291(leader);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (!this.method_148((Class285) class291, leader))
          this.method_85();
      }
      leader.Origin = leader.Vertices[0];
      this.class375_0.ObjectBuilders.Add((Class259) class291);
    }

    private bool method_148(Class285 entityBuilder, DxfLeader leader)
    {
      bool flag = true;
      switch (this.struct18_0.Code)
      {
        case 3:
          string name = (string) this.struct18_0.Value;
          DxfDimensionStyle dimensionStyleWithName = this.dxfModel_0.GetDimensionStyleWithName(name);
          if (dimensionStyleWithName == null)
          {
            this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.UnresolvedReference, Severity.Warning)
            {
              Parameters = {
                {
                  "Type",
                  (object) "DIMSTYLE"
                },
                {
                  "Name",
                  (object) name
                }
              }
            });
            goto case 76;
          }
          else
          {
            leader.DimensionStyle = dimensionStyleWithName;
            goto case 76;
          }
        case 10:
          leader.Vertices.Add(new WW.Math.Point3D((double) this.struct18_0.Value, 0.0, 0.0));
          goto case 76;
        case 20:
          WW.Math.Point3D vertex1 = leader.Vertices[leader.Vertices.Count - 1];
          vertex1.Y = (double) this.struct18_0.Value;
          leader.Vertices[leader.Vertices.Count - 1] = vertex1;
          goto case 76;
        case 30:
          WW.Math.Point3D vertex2 = leader.Vertices[leader.Vertices.Count - 1];
          vertex2.Z = (double) this.struct18_0.Value;
          leader.Vertices[leader.Vertices.Count - 1] = vertex2;
          goto case 76;
        case 40:
          leader.TextAnnotationHeight = (double) this.struct18_0.Value;
          goto case 76;
        case 41:
          leader.TextAnnotationWidth = (double) this.struct18_0.Value;
          goto case 76;
        case 71:
          leader.ArrowHeadEnabled = (short) this.struct18_0.Value == (short) 1;
          goto case 76;
        case 72:
          leader.PathType = (LeaderPathType) this.struct18_0.Value;
          goto case 76;
        case 73:
          leader.CreationType = (LeaderCreationType) this.struct18_0.Value;
          goto case 76;
        case 74:
          leader.HookLineDirection = (HookLineDirection) this.struct18_0.Value;
          goto case 76;
        case 75:
          leader.HasHookLine = (short) this.struct18_0.Value == (short) 1;
          goto case 76;
        case 76:
          if (flag)
            this.method_85();
          return true;
        case 77:
          short int16 = this.struct18_0.Int16;
          leader.ByBlockColor = Color.CreateFromColorIndex(int16);
          goto case 76;
        case 210:
          WW.Math.Vector3D zaxis1 = leader.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          leader.ZAxis = zaxis1;
          goto case 76;
        case 211:
          WW.Math.Vector3D horizontalDirection1 = leader.HorizontalDirection;
          horizontalDirection1.X = (double) this.struct18_0.Value;
          leader.HorizontalDirection = horizontalDirection1;
          goto case 76;
        case 212:
          WW.Math.Vector3D vertexOffsetFromBlock1 = leader.LastVertexOffsetFromBlock;
          vertexOffsetFromBlock1.X = (double) this.struct18_0.Value;
          leader.LastVertexOffsetFromBlock = vertexOffsetFromBlock1;
          goto case 76;
        case 213:
          WW.Math.Vector3D offsetFromAnnotation1 = leader.LastVertexOffsetFromAnnotation;
          offsetFromAnnotation1.X = (double) this.struct18_0.Value;
          leader.LastVertexOffsetFromAnnotation = offsetFromAnnotation1;
          goto case 76;
        case 220:
          WW.Math.Vector3D zaxis2 = leader.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          leader.ZAxis = zaxis2;
          goto case 76;
        case 221:
          WW.Math.Vector3D horizontalDirection2 = leader.HorizontalDirection;
          horizontalDirection2.Y = (double) this.struct18_0.Value;
          leader.HorizontalDirection = horizontalDirection2;
          goto case 76;
        case 222:
          WW.Math.Vector3D vertexOffsetFromBlock2 = leader.LastVertexOffsetFromBlock;
          vertexOffsetFromBlock2.Y = (double) this.struct18_0.Value;
          leader.LastVertexOffsetFromBlock = vertexOffsetFromBlock2;
          goto case 76;
        case 223:
          WW.Math.Vector3D offsetFromAnnotation2 = leader.LastVertexOffsetFromAnnotation;
          offsetFromAnnotation2.Y = (double) this.struct18_0.Value;
          leader.LastVertexOffsetFromAnnotation = offsetFromAnnotation2;
          goto case 76;
        case 230:
          WW.Math.Vector3D zaxis3 = leader.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          leader.ZAxis = zaxis3;
          goto case 76;
        case 231:
          WW.Math.Vector3D horizontalDirection3 = leader.HorizontalDirection;
          horizontalDirection3.Z = (double) this.struct18_0.Value;
          leader.HorizontalDirection = horizontalDirection3;
          goto case 76;
        case 232:
          WW.Math.Vector3D vertexOffsetFromBlock3 = leader.LastVertexOffsetFromBlock;
          vertexOffsetFromBlock3.Z = (double) this.struct18_0.Value;
          leader.LastVertexOffsetFromBlock = vertexOffsetFromBlock3;
          goto case 76;
        case 233:
          WW.Math.Vector3D offsetFromAnnotation3 = leader.LastVertexOffsetFromAnnotation;
          offsetFromAnnotation3.Z = (double) this.struct18_0.Value;
          leader.LastVertexOffsetFromAnnotation = offsetFromAnnotation3;
          goto case 76;
        case 340:
          ulong second = (ulong) this.struct18_0.Value;
          this.list_11.Add(new Pair<DxfLeader, ulong>(leader, second));
          goto case 76;
        default:
          return this.method_133(entityBuilder);
      }
    }

    private void method_149(DxfTable table)
    {
      Class296 class296 = new Class296(table);
      this.class375_0.ObjectBuilders.Add((Class259) class296);
      Class1049 tableBuilder = new Class1049(table.Table2005);
      class296.PrerequisiteBuilders.Add((Interface10) tableBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbTable":
              this.method_152(tableBuilder);
              continue;
            case "AcDbBlockReference":
              this.method_150((Class294) class296);
              continue;
            case "AcDbEntity":
              this.method_132((Class285) class296);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!table.method_6(this, (Class259) class296))
          this.method_85();
      }
    }

    private void method_150(Class294 blockReferenceBuilder)
    {
      this.method_91("AcDbBlockReference");
      this.method_85();
      while (!this.method_92("AcDbBlockReference"))
      {
        if (!this.method_151(blockReferenceBuilder))
          this.method_85();
      }
    }

    private bool method_151(Class294 blockReferenceBuilder)
    {
      DxfInsertBase handledObject = (DxfInsertBase) blockReferenceBuilder.HandledObject;
      switch (this.struct18_0.Code)
      {
        case 2:
          blockReferenceBuilder.BlockName = (string) this.struct18_0.Value;
          break;
        case 10:
          WW.Math.Point3D insertionPoint1 = handledObject.InsertionPoint;
          insertionPoint1.X = (double) this.struct18_0.Value;
          handledObject.InsertionPoint = insertionPoint1;
          break;
        case 20:
          WW.Math.Point3D insertionPoint2 = handledObject.InsertionPoint;
          insertionPoint2.Y = (double) this.struct18_0.Value;
          handledObject.InsertionPoint = insertionPoint2;
          break;
        case 30:
          WW.Math.Point3D insertionPoint3 = handledObject.InsertionPoint;
          insertionPoint3.Z = (double) this.struct18_0.Value;
          handledObject.InsertionPoint = insertionPoint3;
          break;
        default:
          return false;
      }
      this.method_85();
      return true;
    }

    private void method_152(Class1049 tableBuilder)
    {
      this.method_91("AcDbTable");
      Class551 table = tableBuilder.Table;
      ValueDataType? dataType = new ValueDataType?();
      ValueUnitType? unitType = new ValueUnitType?();
      Enum35 enum35 = Enum35.flag_0;
      this.method_85();
      while (!this.method_92("AcDbTable"))
      {
        switch (this.struct18_0.Code)
        {
          case 1:
          case 2:
            if (this.dxfModel_0.Header.AcadVersion <= DxfVersion.Dxf18)
            {
              string str1 = (string) tableBuilder.CurrentCell.Value.Value;
              string str2 = str1 != null ? str1 + (string) this.struct18_0.Value : (string) this.struct18_0.Value;
              tableBuilder.CurrentCell.Value.SetValue(str2);
              break;
            }
            break;
          case 4:
            string formatString = (string) this.struct18_0.Value;
            if ((enum35 & Enum35.flag_24) != Enum35.flag_0)
            {
              table.TitleRowCellStyle.CellFormat = DxfValueFormat.Create(dataType, unitType, formatString);
              enum35 &= ~Enum35.flag_24;
              break;
            }
            if ((enum35 & Enum35.flag_25) != Enum35.flag_0)
            {
              table.TitleRowCellStyle.CellFormat = DxfValueFormat.Create(dataType, unitType, formatString);
              enum35 &= ~Enum35.flag_25;
              break;
            }
            if ((enum35 & Enum35.flag_26) != Enum35.flag_0)
            {
              table.TitleRowCellStyle.CellFormat = DxfValueFormat.Create(dataType, unitType, formatString);
              enum35 &= ~Enum35.flag_26;
              break;
            }
            break;
          case 7:
            tableBuilder.CurrentCellBuilder.TextStyleName = (string) this.struct18_0.Value;
            break;
          case 11:
            WW.Math.Vector3D horizontalDirection1 = table.HorizontalDirection;
            horizontalDirection1.X = (double) this.struct18_0.Value;
            table.HorizontalDirection = horizontalDirection1;
            break;
          case 12:
            WW.Math.Vector3D horizontalDirection2 = table.HorizontalDirection;
            horizontalDirection2.Y = (double) this.struct18_0.Value;
            table.HorizontalDirection = horizontalDirection2;
            break;
          case 13:
            WW.Math.Vector3D horizontalDirection3 = table.HorizontalDirection;
            horizontalDirection3.Z = (double) this.struct18_0.Value;
            table.HorizontalDirection = horizontalDirection3;
            break;
          case 40:
            table.HorizontalCellMargin = new double?((double) this.struct18_0.Value);
            break;
          case 41:
            table.VerticalCellMargin = new double?((double) this.struct18_0.Value);
            break;
          case 63:
            tableBuilder.CurrentCell.BackColor = new Color?(DxfIndexedColorSet.smethod_15(this.struct18_0.Int16));
            break;
          case 64:
            tableBuilder.CurrentCell.ContentColor = new Color?(DxfIndexedColorSet.smethod_15(this.struct18_0.Int16));
            break;
          case 65:
            tableBuilder.CurrentCell.BorderRight.Color = new Color?(DxfIndexedColorSet.smethod_15(this.struct18_0.Int16));
            break;
          case 66:
            tableBuilder.CurrentCell.BorderBottom.Color = new Color?(DxfIndexedColorSet.smethod_15(this.struct18_0.Int16));
            break;
          case 68:
            tableBuilder.CurrentCell.BorderLeft.Color = new Color?(DxfIndexedColorSet.smethod_15(this.struct18_0.Int16));
            break;
          case 69:
            tableBuilder.CurrentCell.BorderTop.Color = new Color?(DxfIndexedColorSet.smethod_15(this.struct18_0.Int16));
            break;
          case 70:
            table.FlowDirection = new TableFlowDirection?((TableFlowDirection) this.struct18_0.Value);
            break;
          case 90:
            if (!tableBuilder.StartedReadingCells)
            {
              tableBuilder.Table.TableFlags = (int) this.struct18_0.Value;
              break;
            }
            break;
          case 91:
            if (tableBuilder.StartedReadingCells)
            {
              tableBuilder.CurrentCellBuilder.OverrideFlags = (int) this.struct18_0.Value;
              enum35 = (Enum35) tableBuilder.CurrentCellBuilder.OverrideFlags;
              break;
            }
            table.method_7((int) this.struct18_0.Value, false);
            break;
          case 92:
            if (!tableBuilder.StartedReadingCells)
            {
              table.method_8((int) this.struct18_0.Value, false);
              break;
            }
            break;
          case 93:
            if (!tableBuilder.StartedReadingCells)
            {
              tableBuilder.OverrideFlags = (int) this.struct18_0.Value;
              break;
            }
            break;
          case 94:
            if (!tableBuilder.StartedReadingCells)
            {
              tableBuilder.BorderColorOverrideFlags = (int) this.struct18_0.Value;
              break;
            }
            break;
          case 95:
            tableBuilder.BorderLineWeightOverrideFlags = (int) this.struct18_0.Value;
            break;
          case 96:
            tableBuilder.BorderVisibilityOverrideFlags = (int) this.struct18_0.Value;
            break;
          case 97:
            dataType = new ValueDataType?((ValueDataType) this.struct18_0.Value);
            break;
          case 98:
            unitType = new ValueUnitType?((ValueUnitType) this.struct18_0.Value);
            break;
          case 140:
            if (tableBuilder.StartedReadingCells)
            {
              tableBuilder.CurrentCell.TextHeight = new double?((double) this.struct18_0.Value);
              break;
            }
            break;
          case 141:
            tableBuilder.method_0((double) this.struct18_0.Value);
            break;
          case 142:
            tableBuilder.method_1((double) this.struct18_0.Value);
            break;
          case 144:
            tableBuilder.CurrentCell.BlockScale = (double) this.struct18_0.Value;
            break;
          case 145:
            tableBuilder.CurrentCell.Rotation = (double) this.struct18_0.Value;
            break;
          case 170:
            tableBuilder.CurrentCell.CellAlignment = new CellAlignment?((CellAlignment) this.struct18_0.Value);
            break;
          case 171:
            tableBuilder.method_2((Enum47) this.struct18_0.Value);
            break;
          case 172:
            tableBuilder.CurrentCellBuilder.EdgeFlags = (short) this.struct18_0.Value;
            break;
          case 174:
            tableBuilder.CurrentCell.AutoFit = DxfReader.smethod_8((short) this.struct18_0.Value);
            break;
          case 175:
            tableBuilder.CurrentCell.MergedCellCountHorizontal = (int) (short) this.struct18_0.Value;
            break;
          case 176:
            tableBuilder.CurrentCell.MergedCellCountVertical = (int) (short) this.struct18_0.Value;
            break;
          case 177:
            if (tableBuilder.StartedReadingCells)
            {
              tableBuilder.CurrentCellBuilder.OverrideFlags = (int) (short) this.struct18_0.Value;
              break;
            }
            break;
          case 178:
            tableBuilder.CurrentCellBuilder.VirtualEdgeFlags = (short) this.struct18_0.Value;
            break;
          case 179:
            tableBuilder.CurrentCellBuilder.NumberOfAttributeDefinitions = (short) this.struct18_0.Value;
            break;
          case 275:
            tableBuilder.CurrentCell.BorderRight.LineWeight = new short?((short) this.struct18_0.Value);
            break;
          case 276:
            tableBuilder.CurrentCell.BorderBottom.LineWeight = new short?((short) this.struct18_0.Value);
            break;
          case 278:
            tableBuilder.CurrentCell.BorderLeft.LineWeight = new short?((short) this.struct18_0.Value);
            break;
          case 279:
            tableBuilder.CurrentCell.BorderTop.LineWeight = new short?((short) this.struct18_0.Value);
            break;
          case 280:
            table.SuppressTitle = new bool?(DxfReader.smethod_7((byte) this.struct18_0.Value));
            break;
          case 281:
            table.SuppressHeaderRow = new bool?(DxfReader.smethod_7((byte) this.struct18_0.Value));
            break;
          case 283:
            tableBuilder.CurrentCell.IsBackColorEnabled = new bool?(!DxfReader.smethod_7((byte) this.struct18_0.Value));
            break;
          case 285:
            tableBuilder.CurrentCell.BorderRight.Visible = new bool?(DxfReader.smethod_7((byte) this.struct18_0.Value));
            break;
          case 286:
            tableBuilder.CurrentCell.BorderBottom.Visible = new bool?(DxfReader.smethod_7((byte) this.struct18_0.Value));
            break;
          case 288:
            tableBuilder.CurrentCell.BorderLeft.Visible = new bool?(DxfReader.smethod_7((byte) this.struct18_0.Value));
            break;
          case 289:
            tableBuilder.CurrentCell.BorderTop.Visible = new bool?(DxfReader.smethod_7((byte) this.struct18_0.Value));
            break;
          case 300:
            tableBuilder.CurrentCellBuilder.CurrentAttributeBuilder.Attribute.Value = (string) this.struct18_0.Value;
            break;
          case 301:
            if ((string) this.struct18_0.Value == "CELL_VALUE")
            {
              Class999 valueBuilder = new Class999(tableBuilder.CurrentCellBuilder.Cell.Value);
              this.method_153(valueBuilder);
              tableBuilder.PrerequisiteBuilders.Add((Interface10) valueBuilder);
              break;
            }
            break;
          case 331:
            tableBuilder.CurrentCellBuilder.AddAttribute().AttributeDefinitionHandle = (ulong) this.struct18_0.Value;
            break;
          case 340:
            tableBuilder.CurrentCellBuilder.BlockOrFieldHandle = (ulong) this.struct18_0.Value;
            break;
          case 342:
            tableBuilder.TableStyleHandle = (ulong) this.struct18_0.Value;
            break;
          case 343:
            tableBuilder.OwningBlockRecordHandle = (ulong) this.struct18_0.Value;
            break;
          case 344:
            tableBuilder.CurrentCellBuilder.BlockOrFieldHandle = (ulong) this.struct18_0.Value;
            break;
        }
        this.method_85();
      }
    }

    private void method_153(Class999 valueBuilder)
    {
      DxfValue dxfValue = valueBuilder.Value;
      ValueDataType? dataType = new ValueDataType?();
      ValueUnitType? unitType = new ValueUnitType?();
      string formatString = (string) null;
      StringBuilder stringBuilder1 = (StringBuilder) null;
      this.method_85();
      StringBuilder stringBuilder2 = (StringBuilder) null;
      while (this.struct18_0.Code != 304 || !((string) this.struct18_0.Value == "ACVALUE_END"))
      {
        switch (this.struct18_0.Code)
        {
          case 1:
            if (stringBuilder2 == null)
            {
              dxfValue.method_1((object) (string) this.struct18_0.Value);
              break;
            }
            stringBuilder2.Append((string) this.struct18_0.Value);
            dxfValue.method_1((object) stringBuilder2.ToString());
            break;
          case 2:
            if (stringBuilder2 == null)
            {
              stringBuilder2 = new StringBuilder();
              stringBuilder2.Append((string) this.struct18_0.Value);
              break;
            }
            break;
          case 11:
            WW.Math.Point3D point3D = this.method_154();
            dxfValue.method_1((object) point3D);
            break;
          case 90:
            dataType = new ValueDataType?((ValueDataType) this.struct18_0.Value);
            break;
          case 91:
            dxfValue.method_1((object) (int) this.struct18_0.Value);
            break;
          case 93:
            dxfValue.Flags = (int) this.struct18_0.Value;
            break;
          case 94:
            unitType = new ValueUnitType?((ValueUnitType) this.struct18_0.Value);
            break;
          case 140:
            dxfValue.method_1((object) (double) this.struct18_0.Value);
            break;
          case 300:
            formatString = (string) this.struct18_0.Value;
            break;
          case 302:
            if (stringBuilder1 == null)
              stringBuilder1 = new StringBuilder();
            stringBuilder1.Append((string) this.struct18_0.Value);
            break;
          case 303:
            if (stringBuilder1 == null)
              stringBuilder1 = new StringBuilder();
            stringBuilder1.Append((string) this.struct18_0.Value);
            break;
          case 310:
            DateTime? nullable = DxfValue.smethod_1(this.dxfModel_0.Header.AcadVersion, (byte[]) this.struct18_0.Value);
            if (nullable.HasValue)
            {
              dxfValue.method_1((object) nullable.Value);
              break;
            }
            break;
          case 330:
            valueBuilder.ObjectHandle = (ulong) this.struct18_0.Value;
            break;
        }
        if (this.dxfModel_0.Header.AcadVersion > DxfVersion.Dxf18 || dxfValue.Value == null && valueBuilder.ObjectHandle == 0UL)
          this.method_85();
        else
          break;
      }
      if (dxfValue.Value == null && stringBuilder2 != null)
        dxfValue.method_1((object) stringBuilder2.ToString());
      dxfValue.Format = DxfValueFormat.Create(dataType, unitType, formatString);
      if (stringBuilder1 != null)
        dxfValue.method_2(stringBuilder1.ToString());
      ValueDataType? nullable1 = dataType;
      if ((nullable1.GetValueOrDefault() != ValueDataType.String ? 0 : (nullable1.HasValue ? 1 : 0)) == 0 || dxfValue.Value != null)
        return;
      dxfValue.SetValue(string.Empty);
    }

    private WW.Math.Point3D method_154()
    {
      int code = this.struct18_0.Code;
      double x = (double) this.struct18_0.Value;
      this.method_85();
      double y = 0.0;
      double z = 0.0;
      if (this.struct18_0.Code == code + 10)
      {
        y = (double) this.struct18_0.Value;
        this.method_85();
        if (this.struct18_0.Code == code + 20)
          z = (double) this.struct18_0.Value;
      }
      return new WW.Math.Point3D(x, y, z);
    }

    private WW.Math.Point2D method_155()
    {
      int code = this.struct18_0.Code;
      double x = (double) this.struct18_0.Value;
      this.method_85();
      double y = 0.0;
      if (this.struct18_0.Code == code + 10)
        y = (double) this.struct18_0.Value;
      return new WW.Math.Point2D(x, y);
    }

    private void method_156(DxfTolerance tolerance)
    {
      Class302 class302 = new Class302(tolerance);
      this.class375_0.ObjectBuilders.Add((Class259) class302);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (!this.method_157((Class285) class302, tolerance))
          this.method_85();
      }
    }

    private bool method_157(Class285 entityBuilder, DxfTolerance tolerance)
    {
      bool flag = true;
      switch (this.struct18_0.Code)
      {
        case 1:
          tolerance.Text = (string) this.struct18_0.Value;
          break;
        case 3:
          string name = (string) this.struct18_0.Value;
          DxfDimensionStyle dimensionStyleWithName = this.dxfModel_0.GetDimensionStyleWithName(name);
          if (dimensionStyleWithName == null)
          {
            this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.UnresolvedReference, Severity.Warning)
            {
              Parameters = {
                {
                  "Type",
                  (object) "DIMSTYLE"
                },
                {
                  "Name",
                  (object) name
                }
              }
            });
            break;
          }
          tolerance.DimensionStyle = dimensionStyleWithName;
          break;
        case 10:
          WW.Math.Point3D insertionPoint1 = tolerance.InsertionPoint;
          insertionPoint1.X = (double) this.struct18_0.Value;
          tolerance.InsertionPoint = insertionPoint1;
          break;
        case 11:
          WW.Math.Vector3D xaxis1 = tolerance.XAxis;
          xaxis1.X = (double) this.struct18_0.Value;
          tolerance.XAxis = xaxis1;
          break;
        case 20:
          WW.Math.Point3D insertionPoint2 = tolerance.InsertionPoint;
          insertionPoint2.Y = (double) this.struct18_0.Value;
          tolerance.InsertionPoint = insertionPoint2;
          break;
        case 21:
          WW.Math.Vector3D xaxis2 = tolerance.XAxis;
          xaxis2.Y = (double) this.struct18_0.Value;
          tolerance.XAxis = xaxis2;
          break;
        case 30:
          WW.Math.Point3D insertionPoint3 = tolerance.InsertionPoint;
          insertionPoint3.Z = (double) this.struct18_0.Value;
          tolerance.InsertionPoint = insertionPoint3;
          break;
        case 31:
          WW.Math.Vector3D xaxis3 = tolerance.XAxis;
          xaxis3.Z = (double) this.struct18_0.Value;
          tolerance.XAxis = xaxis3;
          break;
        case 210:
          WW.Math.Vector3D zaxis1 = tolerance.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          tolerance.ZAxis = zaxis1;
          break;
        case 220:
          WW.Math.Vector3D zaxis2 = tolerance.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          tolerance.ZAxis = zaxis2;
          break;
        case 230:
          WW.Math.Vector3D zaxis3 = tolerance.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          tolerance.ZAxis = zaxis3;
          break;
        default:
          return this.method_133(entityBuilder);
      }
      if (flag)
        this.method_85();
      return true;
    }

    private void method_158(DxfLine line)
    {
      Class285 entityBuilder = new Class285((DxfEntity) line);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbLine":
              this.method_159(entityBuilder, line);
              continue;
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_160(entityBuilder, line))
          this.method_85();
      }
    }

    private void method_159(Class285 entityBuilder, DxfLine line)
    {
      this.method_91("AcDbLine");
      this.method_85();
      while (!this.method_92("AcDbLine"))
      {
        if (!this.method_160(entityBuilder, line))
          this.method_85();
      }
    }

    private bool method_160(Class285 entityBuilder, DxfLine line)
    {
      switch (this.struct18_0.Code)
      {
        case 10:
          WW.Math.Point3D start1 = line.Start;
          start1.X = (double) this.struct18_0.Value;
          line.Start = start1;
          break;
        case 11:
          WW.Math.Point3D end1 = line.End;
          end1.X = (double) this.struct18_0.Value;
          line.End = end1;
          break;
        case 20:
          WW.Math.Point3D start2 = line.Start;
          start2.Y = (double) this.struct18_0.Value;
          line.Start = start2;
          break;
        case 21:
          WW.Math.Point3D end2 = line.End;
          end2.Y = (double) this.struct18_0.Value;
          line.End = end2;
          break;
        case 30:
          WW.Math.Point3D start3 = line.Start;
          start3.Z = (double) this.struct18_0.Value;
          line.Start = start3;
          break;
        case 31:
          WW.Math.Point3D end3 = line.End;
          end3.Z = (double) this.struct18_0.Value;
          line.End = end3;
          break;
        case 39:
          line.Thickness = (double) this.struct18_0.Value;
          break;
        case 210:
          WW.Math.Vector3D zaxis1 = line.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          line.ZAxis = zaxis1;
          break;
        case 220:
          WW.Math.Vector3D zaxis2 = line.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          line.ZAxis = zaxis2;
          break;
        case 230:
          WW.Math.Vector3D zaxis3 = line.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          line.ZAxis = zaxis3;
          break;
        default:
          return this.method_133(entityBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_161(DxfRay ray)
    {
      Class285 entityBuilder = new Class285((DxfEntity) ray);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (!this.method_162(entityBuilder, ray))
          this.method_85();
      }
    }

    private bool method_162(Class285 entityBuilder, DxfRay ray)
    {
      switch (this.struct18_0.Code)
      {
        case 10:
          WW.Math.Point3D startPoint1 = ray.StartPoint;
          startPoint1.X = (double) this.struct18_0.Value;
          ray.StartPoint = startPoint1;
          break;
        case 11:
          WW.Math.Vector3D direction1 = ray.Direction;
          direction1.X = (double) this.struct18_0.Value;
          ray.Direction = direction1;
          break;
        case 20:
          WW.Math.Point3D startPoint2 = ray.StartPoint;
          startPoint2.Y = (double) this.struct18_0.Value;
          ray.StartPoint = startPoint2;
          break;
        case 21:
          WW.Math.Vector3D direction2 = ray.Direction;
          direction2.Y = (double) this.struct18_0.Value;
          ray.Direction = direction2;
          break;
        case 30:
          WW.Math.Point3D startPoint3 = ray.StartPoint;
          startPoint3.Z = (double) this.struct18_0.Value;
          ray.StartPoint = startPoint3;
          break;
        case 31:
          WW.Math.Vector3D direction3 = ray.Direction;
          direction3.Z = (double) this.struct18_0.Value;
          ray.Direction = direction3;
          break;
        default:
          return this.method_133(entityBuilder);
      }
      this.method_85();
      return true;
    }

    private bool method_163(Class285 entityBuilder)
    {
      this.method_91("AcDbOle2Frame");
      DxfOle entity = entityBuilder.Entity as DxfOle;
      List<byte[]> numArrayList = new List<byte[]>();
      bool flag = true;
      this.method_85();
      while (!this.method_92("AcDbEntity") && flag)
      {
        switch (this.struct18_0.Code)
        {
          case 1:
          case 10:
          case 11:
          case 20:
          case 21:
          case 30:
          case 31:
          case 72:
          case 90:
            if (flag)
            {
              this.method_85();
              continue;
            }
            continue;
          case 3:
            entity.UserType = (string) this.struct18_0.Value;
            goto case 1;
          case 70:
            entity.OleDataVersion = (int) (short) this.struct18_0.Value;
            goto case 1;
          case 71:
            entity.OleObjectType = (DxfOle.Type) (short) this.struct18_0.Value;
            goto case 1;
          case 73:
            entity.Quality = (DxfOle.QualityType) (short) this.struct18_0.Value;
            goto case 1;
          case 310:
            byte[] numArray1 = (byte[]) this.struct18_0.Value;
            numArrayList.Add(numArray1);
            goto case 1;
          default:
            flag = false;
            goto case 1;
        }
      }
      long length = 0;
      foreach (byte[] numArray2 in numArrayList)
        length += (long) numArray2.Length;
      long index = 0;
      byte[] buffer = new byte[length];
      foreach (byte[] numArray2 in numArrayList)
      {
        numArray2.CopyTo((Array) buffer, index);
        index += (long) numArray2.Length;
      }
      if (buffer.Length != 0)
      {
        if (!Class434.smethod_0(Class444.Create(this.class375_0.Version, new DwgReader((Stream) new MemoryStream(buffer)), (Stream) new MemoryStream(buffer), false), entity))
          throw new Exception("Ole data is broken.");
        this.dxfModel_0.UpdateOleItemCounter((uint) entity.ItemId);
      }
      return flag;
    }

    private void method_164(DxfOle ole)
    {
      Class285 entityBuilder = new Class285((DxfEntity) ole);
      try
      {
        this.method_85();
        while (this.struct18_0.Code != 0)
        {
          if (this.struct18_0.Code == 100)
          {
            switch ((string) this.struct18_0.Value)
            {
              case "AcDbOle2Frame":
                this.method_163(entityBuilder);
                continue;
              case "AcDbEntity":
                this.method_132(entityBuilder);
                continue;
              default:
                this.method_85();
                continue;
            }
          }
          else
            this.method_133(entityBuilder);
        }
      }
      catch (Exception ex)
      {
        return;
      }
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
    }

    private void method_165(DxfIDBlockReference idRef)
    {
      Class295 class295 = new Class295(idRef);
      this.class375_0.ObjectBuilders.Add((Class259) class295);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbBlockReference":
              this.method_197((Class294) class295, (DxfInsert) idRef);
              continue;
            case "AcDbEntity":
              this.method_132((Class285) class295);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else
          this.method_133((Class285) class295);
      }
    }

    private void method_166(Dxf3DSolid solid)
    {
      Class285 entityBuilder = new Class285((DxfEntity) solid);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      StringBuilder satTextCollector = new StringBuilder(65536);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDb3dSolid":
              this.method_85();
              if (this.struct18_0.Code == 350)
              {
                solid.HistoryId = (ulong) this.struct18_0.Value;
                solid.HistoryId = 0UL;
                this.method_85();
                continue;
              }
              continue;
            case "AcDbModelerGeometry":
              this.method_169(entityBuilder, (DxfModelerGeometry) solid, satTextCollector);
              continue;
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_170(entityBuilder, (DxfModelerGeometry) solid, satTextCollector))
          this.method_85();
      }
      solid.SatText = satTextCollector.ToString();
    }

    private void method_167(DxfRegion region)
    {
      Class285 entityBuilder = new Class285((DxfEntity) region);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      StringBuilder satTextCollector = new StringBuilder(65536);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbModelerGeometry":
              this.method_169(entityBuilder, (DxfModelerGeometry) region, satTextCollector);
              continue;
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_170(entityBuilder, (DxfModelerGeometry) region, satTextCollector))
          this.method_85();
      }
      region.SatText = satTextCollector.ToString();
    }

    private void method_168(DxfBody body)
    {
      Class285 entityBuilder = new Class285((DxfEntity) body);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      StringBuilder satTextCollector = new StringBuilder(65536);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbModelerGeometry":
              this.method_169(entityBuilder, (DxfModelerGeometry) body, satTextCollector);
              continue;
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_170(entityBuilder, (DxfModelerGeometry) body, satTextCollector))
          this.method_85();
      }
      body.SatText = satTextCollector.ToString();
    }

    private void method_169(
      Class285 entityBuilder,
      DxfModelerGeometry entity,
      StringBuilder satTextCollector)
    {
      this.method_91("AcDbModelerGeometry");
      this.method_85();
      while (!this.method_92("AcDbModelerGeometry"))
      {
        if (!this.method_170(entityBuilder, entity, satTextCollector))
          this.method_85();
      }
    }

    private bool method_170(
      Class285 entityBuilder,
      DxfModelerGeometry entity,
      StringBuilder satTextCollector)
    {
      switch (this.struct18_0.Code)
      {
        case 1:
          if (this.class375_0.Version < DxfVersion.Dxf27)
          {
            satTextCollector.Append(DxfModelerGeometry.Decrypt((string) this.struct18_0.Value)).Append("\r\n");
            goto case 290;
          }
          else
            goto case 290;
        case 2:
          if (this.class375_0.Version > DxfVersion.Dxf24)
          {
            entity.Guid = new Guid((string) this.struct18_0.Value);
            goto case 290;
          }
          else
            goto case 290;
        case 3:
          if (this.class375_0.Version < DxfVersion.Dxf27)
          {
            satTextCollector.Append(DxfModelerGeometry.Decrypt((string) this.struct18_0.Value));
            goto case 290;
          }
          else
            goto case 290;
        case 70:
          if (this.class375_0.Version < DxfVersion.Dxf27)
          {
            entity.AcisFormatIntegrationVersion = (int) this.struct18_0.Int16;
            goto case 290;
          }
          else
            goto case 290;
        case 290:
          this.method_85();
          return true;
        default:
          return this.method_133(entityBuilder);
      }
    }

    private void method_171(DxfXLine xline)
    {
      Class285 entityBuilder = new Class285((DxfEntity) xline);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (!this.method_172(entityBuilder, xline))
          this.method_85();
      }
    }

    private bool method_172(Class285 entityBuilder, DxfXLine xline)
    {
      switch (this.struct18_0.Code)
      {
        case 10:
          WW.Math.Point3D startPoint1 = xline.StartPoint;
          startPoint1.X = (double) this.struct18_0.Value;
          xline.StartPoint = startPoint1;
          break;
        case 11:
          WW.Math.Vector3D direction1 = xline.Direction;
          direction1.X = (double) this.struct18_0.Value;
          xline.Direction = direction1;
          break;
        case 20:
          WW.Math.Point3D startPoint2 = xline.StartPoint;
          startPoint2.Y = (double) this.struct18_0.Value;
          xline.StartPoint = startPoint2;
          break;
        case 21:
          WW.Math.Vector3D direction2 = xline.Direction;
          direction2.Y = (double) this.struct18_0.Value;
          xline.Direction = direction2;
          break;
        case 30:
          WW.Math.Point3D startPoint3 = xline.StartPoint;
          startPoint3.Z = (double) this.struct18_0.Value;
          xline.StartPoint = startPoint3;
          break;
        case 31:
          WW.Math.Vector3D direction3 = xline.Direction;
          direction3.Z = (double) this.struct18_0.Value;
          xline.Direction = direction3;
          break;
        default:
          return this.method_133(entityBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_173(DxfMLine mline)
    {
      Class285 entityBuilder = new Class285((DxfEntity) mline);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      DxfMLine.Segment currentSegment = (DxfMLine.Segment) null;
      DxfMLine.Segment.Element currentElement = (DxfMLine.Segment.Element) null;
      while (this.struct18_0.Code != 0)
      {
        if (!this.method_174(entityBuilder, mline, ref currentSegment, ref currentElement))
          this.method_85();
      }
    }

    private bool method_174(
      Class285 entityBuilder,
      DxfMLine mline,
      ref DxfMLine.Segment currentSegment,
      ref DxfMLine.Segment.Element currentElement)
    {
      switch (this.struct18_0.Code)
      {
        case 2:
        case 72:
        case 73:
        case 75:
          this.method_85();
          return true;
        case 10:
          WW.Math.Point3D startPoint1 = mline.StartPoint;
          startPoint1.X = (double) this.struct18_0.Value;
          mline.StartPoint = startPoint1;
          goto case 2;
        case 11:
          currentSegment = new DxfMLine.Segment();
          currentElement = (DxfMLine.Segment.Element) null;
          mline.Segments.Add(currentSegment);
          WW.Math.Point3D position1 = currentSegment.Position;
          position1.X = (double) this.struct18_0.Value;
          currentSegment.Position = position1;
          goto case 2;
        case 12:
          WW.Math.Vector3D direction1 = currentSegment.Direction;
          direction1.X = (double) this.struct18_0.Value;
          currentSegment.Direction = direction1;
          goto case 2;
        case 13:
          WW.Math.Vector3D miterDirection1 = currentSegment.MiterDirection;
          miterDirection1.X = (double) this.struct18_0.Value;
          currentSegment.MiterDirection = miterDirection1;
          goto case 2;
        case 20:
          WW.Math.Point3D startPoint2 = mline.StartPoint;
          startPoint2.Y = (double) this.struct18_0.Value;
          mline.StartPoint = startPoint2;
          goto case 2;
        case 21:
          WW.Math.Point3D position2 = currentSegment.Position;
          position2.Y = (double) this.struct18_0.Value;
          currentSegment.Position = position2;
          goto case 2;
        case 22:
          WW.Math.Vector3D direction2 = currentSegment.Direction;
          direction2.Y = (double) this.struct18_0.Value;
          currentSegment.Direction = direction2;
          goto case 2;
        case 23:
          WW.Math.Vector3D miterDirection2 = currentSegment.MiterDirection;
          miterDirection2.Y = (double) this.struct18_0.Value;
          currentSegment.MiterDirection = miterDirection2;
          goto case 2;
        case 30:
          WW.Math.Point3D startPoint3 = mline.StartPoint;
          startPoint3.Z = (double) this.struct18_0.Value;
          mline.StartPoint = startPoint3;
          goto case 2;
        case 31:
          WW.Math.Point3D position3 = currentSegment.Position;
          position3.Z = (double) this.struct18_0.Value;
          currentSegment.Position = position3;
          goto case 2;
        case 32:
          WW.Math.Vector3D direction3 = currentSegment.Direction;
          direction3.Z = (double) this.struct18_0.Value;
          currentSegment.Direction = direction3;
          goto case 2;
        case 33:
          WW.Math.Vector3D miterDirection3 = currentSegment.MiterDirection;
          miterDirection3.Z = (double) this.struct18_0.Value;
          currentSegment.MiterDirection = miterDirection3;
          goto case 2;
        case 40:
          mline.ScaleFactor = (double) this.struct18_0.Value;
          goto case 2;
        case 41:
          currentElement.Parameters.Add((double) this.struct18_0.Value);
          goto case 2;
        case 42:
          currentElement.AreaFillParameters.Add((double) this.struct18_0.Value);
          goto case 2;
        case 70:
          mline.Alignment = (MLineAlignment) this.struct18_0.Int16;
          goto case 2;
        case 71:
          mline.Flags = (MLineFlags) this.struct18_0.UInt16;
          goto case 2;
        case 74:
          currentElement = new DxfMLine.Segment.Element();
          currentSegment.Elements.Add(currentElement);
          goto case 2;
        case 210:
          WW.Math.Vector3D zaxis1 = mline.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          mline.ZAxis = zaxis1;
          goto case 2;
        case 220:
          WW.Math.Vector3D zaxis2 = mline.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          mline.ZAxis = zaxis2;
          goto case 2;
        case 230:
          WW.Math.Vector3D zaxis3 = mline.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          mline.ZAxis = zaxis3;
          goto case 2;
        case 340:
          ulong second = (ulong) this.struct18_0.Value;
          this.list_10.Add(new Pair<DxfMLine, ulong>(mline, second));
          goto case 2;
        default:
          return this.method_133(entityBuilder);
      }
    }

    private void method_175(DxfLwPolyline polyline)
    {
      Class285 entityBuilder = new Class285((DxfEntity) polyline);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbPolyline":
              this.method_176(entityBuilder, polyline);
              continue;
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_177(entityBuilder, polyline))
          this.method_85();
      }
    }

    private void method_176(Class285 entityBuilder, DxfLwPolyline polyline)
    {
      this.method_91("AcDbPolyline");
      this.method_85();
      while (!this.method_92("AcDbPolyline"))
      {
        if (!this.method_177(entityBuilder, polyline))
          this.method_85();
      }
    }

    private bool method_177(Class285 entityBuilder, DxfLwPolyline polyline)
    {
      switch (this.struct18_0.Code)
      {
        case 10:
          polyline.Vertices.Add(new DxfLwPolyline.Vertex((double) this.struct18_0.Value, 0.0));
          break;
        case 20:
          polyline.Vertices[polyline.Vertices.Count - 1].Y = (double) this.struct18_0.Value;
          break;
        case 38:
          polyline.Elevation = (double) this.struct18_0.Value;
          break;
        case 39:
          polyline.Thickness = (double) this.struct18_0.Value;
          break;
        case 40:
          polyline.Vertices[polyline.Vertices.Count - 1].StartWidth = (double) this.struct18_0.Value;
          break;
        case 41:
          polyline.Vertices[polyline.Vertices.Count - 1].EndWidth = (double) this.struct18_0.Value;
          break;
        case 42:
          polyline.Vertices[polyline.Vertices.Count - 1].Bulge = (double) this.struct18_0.Value;
          break;
        case 43:
          polyline.ConstantWidth = (double) this.struct18_0.Value;
          break;
        case 70:
          polyline.Flags = (Enum21) this.struct18_0.Value;
          break;
        case 210:
          WW.Math.Vector3D zaxis1 = polyline.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          polyline.ZAxis = zaxis1;
          break;
        case 220:
          WW.Math.Vector3D zaxis2 = polyline.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          polyline.ZAxis = zaxis2;
          break;
        case 230:
          WW.Math.Vector3D zaxis3 = polyline.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          polyline.ZAxis = zaxis3;
          break;
        default:
          return this.method_133(entityBuilder);
      }
      this.method_85();
      return true;
    }

    private DxfPolylineBase method_178()
    {
      DxfReader.Class43 class43 = new DxfReader.Class43();
      Class285 entityBuilder = new Class285((DxfEntity) null);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (!this.method_179(entityBuilder, class43))
          this.method_85();
      }
      DxfPolylineBase dxfPolylineBase = !class43.Is3DPolyline ? (!class43.Is3DPolygonMesh ? (!class43.IsPolyfaceMesh ? (!class43.IsSpline ? (DxfPolylineBase) this.method_182(class43) : (DxfPolylineBase) this.method_183(class43)) : (DxfPolylineBase) this.method_188(class43)) : (!class43.IsSpline ? (DxfPolylineBase) this.method_186(class43) : (DxfPolylineBase) this.method_185(class43))) : (!class43.IsSpline ? (DxfPolylineBase) this.method_181(class43) : (DxfPolylineBase) this.method_180(class43));
      if (this.struct18_0 == Class824.struct18_23)
        this.method_193((DxfHandledObject) dxfPolylineBase.SeqEnd);
      entityBuilder.Entity = (DxfEntity) dxfPolylineBase;
      this.method_89((Class259) entityBuilder);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      return dxfPolylineBase;
    }

    private bool method_179(Class285 entityBuilder, DxfReader.Class43 polyline)
    {
      switch (this.struct18_0.Code)
      {
        case 30:
          polyline.Elevation = (double) this.struct18_0.Value;
          break;
        case 39:
          polyline.Thickness = (double) this.struct18_0.Value;
          break;
        case 40:
          polyline.DefaultStartWidth = (double) this.struct18_0.Value;
          break;
        case 41:
          polyline.DefaultEndWidth = (double) this.struct18_0.Value;
          break;
        case 70:
          polyline.Flags = (Enum21) this.struct18_0.Value;
          break;
        case 71:
          polyline.MVertexCount = (ushort) (short) this.struct18_0.Value;
          break;
        case 72:
          polyline.NVertexCount = (ushort) (short) this.struct18_0.Value;
          break;
        case 73:
          polyline.SmoothSurfaceMDensity = (ushort) (short) this.struct18_0.Value;
          break;
        case 74:
          polyline.SmoothSurfaceNDensity = (ushort) (short) this.struct18_0.Value;
          break;
        case 75:
          polyline.SplineType = (SplineType) this.struct18_0.Value;
          break;
        case 210:
          WW.Math.Vector3D zaxis1 = polyline.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          polyline.ZAxis = zaxis1;
          break;
        case 220:
          WW.Math.Vector3D zaxis2 = polyline.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          polyline.ZAxis = zaxis2;
          break;
        case 230:
          WW.Math.Vector3D zaxis3 = polyline.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          polyline.ZAxis = zaxis3;
          break;
        default:
          return this.method_134(entityBuilder, (DxfReader.Class40) polyline);
      }
      this.method_85();
      return true;
    }

    private DxfPolyline3DSpline method_180(DxfReader.Class43 polylineInfo)
    {
      DxfPolyline3DSpline polyline3Dspline = new DxfPolyline3DSpline();
      this.method_189((DxfReader.Class40) polylineInfo, (DxfEntity) polyline3Dspline);
      polyline3Dspline.Closed = polylineInfo.Closed;
      polyline3Dspline.SplineType = polylineInfo.SplineType;
      while (this.struct18_0 == Class824.struct18_21)
      {
        Class285 entityBuilder = new Class285((DxfEntity) null);
        DxfReader.Class42 vertexInfo = this.method_194(entityBuilder);
        DxfVertex3D dxfVertex3D = this.method_190(vertexInfo);
        entityBuilder.Entity = (DxfEntity) dxfVertex3D;
        this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
        if (vertexInfo.IsSplineControlPoint)
          polyline3Dspline.ControlPoints.Add(dxfVertex3D);
        else
          polyline3Dspline.ApproximationPoints.Add(dxfVertex3D);
      }
      return polyline3Dspline;
    }

    private DxfPolyline3D method_181(DxfReader.Class43 polylineInfo)
    {
      DxfPolyline3D dxfPolyline3D = new DxfPolyline3D();
      this.method_189((DxfReader.Class40) polylineInfo, (DxfEntity) dxfPolyline3D);
      dxfPolyline3D.Closed = polylineInfo.Closed;
      dxfPolyline3D.Plinegen = polylineInfo.Plinegen;
      while (this.struct18_0 == Class824.struct18_21)
      {
        Class285 entityBuilder = new Class285((DxfEntity) null);
        DxfVertex3D dxfVertex3D = this.method_190(this.method_194(entityBuilder));
        entityBuilder.Entity = (DxfEntity) dxfVertex3D;
        this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
        dxfPolyline3D.Vertices.Add(dxfVertex3D);
      }
      return dxfPolyline3D;
    }

    private DxfPolyline2D method_182(DxfReader.Class43 polylineInfo)
    {
      DxfPolyline2D dxfPolyline2D = new DxfPolyline2D();
      this.method_189((DxfReader.Class40) polylineInfo, (DxfEntity) dxfPolyline2D);
      this.method_184(polylineInfo, (DxfPolyline2DBase) dxfPolyline2D);
      dxfPolyline2D.Plinegen = polylineInfo.Plinegen;
      while (this.struct18_0 == Class824.struct18_21)
      {
        Class285 entityBuilder = new Class285((DxfEntity) null);
        DxfVertex2D dxfVertex2D = this.method_191(this.method_194(entityBuilder));
        entityBuilder.Entity = (DxfEntity) dxfVertex2D;
        this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
        dxfPolyline2D.Vertices.Add(dxfVertex2D);
      }
      return dxfPolyline2D;
    }

    private DxfPolyline2DSpline method_183(DxfReader.Class43 polylineInfo)
    {
      DxfPolyline2DSpline polyline2Dspline = new DxfPolyline2DSpline();
      this.method_189((DxfReader.Class40) polylineInfo, (DxfEntity) polyline2Dspline);
      this.method_184(polylineInfo, (DxfPolyline2DBase) polyline2Dspline);
      polyline2Dspline.SplineType = polylineInfo.SplineType;
      while (this.struct18_0 == Class824.struct18_21)
      {
        Class285 entityBuilder = new Class285((DxfEntity) null);
        DxfReader.Class42 vertexInfo = this.method_194(entityBuilder);
        DxfVertex2D dxfVertex2D = this.method_191(vertexInfo);
        entityBuilder.Entity = (DxfEntity) dxfVertex2D;
        this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
        if (vertexInfo.IsSplineControlPoint)
          polyline2Dspline.ControlPoints.Add(dxfVertex2D);
        else
          polyline2Dspline.ApproximationPoints.Add(dxfVertex2D);
      }
      return polyline2Dspline;
    }

    private void method_184(DxfReader.Class43 polylineInfo, DxfPolyline2DBase polyline)
    {
      polyline.Closed = polylineInfo.Closed;
      polyline.Thickness = polylineInfo.Thickness;
      polyline.ZAxis = polylineInfo.ZAxis;
      polyline.Elevation = polylineInfo.Elevation;
      polyline.DefaultStartWidth = polylineInfo.DefaultStartWidth;
      polyline.DefaultEndWidth = polylineInfo.DefaultEndWidth;
    }

    private DxfPolygonSplineMesh method_185(DxfReader.Class43 polylineInfo)
    {
      DxfPolygonSplineMesh polygonSplineMesh = new DxfPolygonSplineMesh();
      this.method_189((DxfReader.Class40) polylineInfo, (DxfEntity) polygonSplineMesh);
      this.method_187(polylineInfo, (DxfPolygonMeshBase) polygonSplineMesh);
      polygonSplineMesh.SplineType = polylineInfo.SplineType;
      polygonSplineMesh.MControlPointCount = polylineInfo.MVertexCount;
      polygonSplineMesh.NControlPointCount = polylineInfo.NVertexCount;
      polygonSplineMesh.SmoothSurfaceMDensity = polylineInfo.SmoothSurfaceMDensity;
      polygonSplineMesh.SmoothSurfaceNDensity = polylineInfo.SmoothSurfaceNDensity;
      while (this.struct18_0 == Class824.struct18_21)
      {
        Class285 entityBuilder = new Class285((DxfEntity) null);
        DxfReader.Class42 vertexInfo = this.method_194(entityBuilder);
        DxfVertex3D dxfVertex3D = this.method_190(vertexInfo);
        entityBuilder.Entity = (DxfEntity) dxfVertex3D;
        this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
        if (vertexInfo.IsSplineControlPoint)
          polygonSplineMesh.ControlPoints.Add(dxfVertex3D);
        else
          polygonSplineMesh.ApproximationPoints.Add(dxfVertex3D);
      }
      return polygonSplineMesh;
    }

    private DxfPolygonMesh method_186(DxfReader.Class43 polylineInfo)
    {
      DxfPolygonMesh dxfPolygonMesh = new DxfPolygonMesh();
      this.method_189((DxfReader.Class40) polylineInfo, (DxfEntity) dxfPolygonMesh);
      this.method_187(polylineInfo, (DxfPolygonMeshBase) dxfPolygonMesh);
      dxfPolygonMesh.MVertexCount = polylineInfo.MVertexCount;
      dxfPolygonMesh.NVertexCount = polylineInfo.NVertexCount;
      int num = 0;
      while (this.struct18_0 == Class824.struct18_21)
      {
        Class285 entityBuilder = new Class285((DxfEntity) null);
        DxfVertex3D dxfVertex3D = this.method_190(this.method_194(entityBuilder));
        entityBuilder.Entity = (DxfEntity) dxfVertex3D;
        this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
        dxfPolygonMesh.Vertices.Add(dxfVertex3D);
        ++num;
      }
      return dxfPolygonMesh;
    }

    private void method_187(DxfReader.Class43 polylineInfo, DxfPolygonMeshBase polyline)
    {
      polyline.ClosedInMDirection = polylineInfo.Closed;
      polyline.ClosedInNDirection = polylineInfo.ClosedInNDirection;
    }

    private DxfPolyfaceMesh method_188(DxfReader.Class43 polylineInfo)
    {
      DxfPolyfaceMesh polyline = new DxfPolyfaceMesh();
      this.method_189((DxfReader.Class40) polylineInfo, (DxfEntity) polyline);
      while (this.struct18_0 == Class824.struct18_21)
      {
        Class285 entityBuilder = new Class285((DxfEntity) null);
        DxfReader.Class42 vertexInfo = this.method_194(entityBuilder);
        if (vertexInfo.IsFace)
        {
          DxfMeshFace dxfMeshFace = this.method_192(vertexInfo);
          if (vertexInfo.Vertex1Index != (short) 0)
          {
            DxfVertex3D vertex = DxfReader.Class42.smethod_0(polyline, (int) vertexInfo.Vertex1Index);
            dxfMeshFace.Corners.Add(new DxfMeshFace.Corner(vertex, vertexInfo.Vertex1Index > (short) 0));
          }
          if (vertexInfo.Vertex2Index != (short) 0)
          {
            DxfVertex3D vertex = DxfReader.Class42.smethod_0(polyline, (int) vertexInfo.Vertex2Index);
            dxfMeshFace.Corners.Add(new DxfMeshFace.Corner(vertex, vertexInfo.Vertex2Index > (short) 0));
          }
          if (vertexInfo.Vertex3Index != (short) 0)
          {
            DxfVertex3D vertex = DxfReader.Class42.smethod_0(polyline, (int) vertexInfo.Vertex3Index);
            dxfMeshFace.Corners.Add(new DxfMeshFace.Corner(vertex, vertexInfo.Vertex3Index > (short) 0));
          }
          if (vertexInfo.Vertex4Index != (short) 0)
          {
            DxfVertex3D vertex = DxfReader.Class42.smethod_0(polyline, (int) vertexInfo.Vertex4Index);
            dxfMeshFace.Corners.Add(new DxfMeshFace.Corner(vertex, vertexInfo.Vertex4Index > (short) 0));
          }
          entityBuilder.Entity = (DxfEntity) dxfMeshFace;
          polyline.Faces.Add(dxfMeshFace);
        }
        else
        {
          DxfVertex3D dxfVertex3D = this.method_190(vertexInfo);
          entityBuilder.Entity = (DxfEntity) dxfVertex3D;
          polyline.Vertices.Add(dxfVertex3D);
        }
        this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      }
      return polyline;
    }

    private void method_189(DxfReader.Class40 from, DxfEntity to)
    {
      to.Color = from.Color;
      to.Transparency = from.Transparency;
      to.SetHandle(from.Handle);
      if (from.LayerName != null)
        this.list_2.Add(new Pair<DxfEntity, string>(to, from.LayerName));
      if (from.LineTypeName != null)
        this.list_4.Add(new Pair<DxfEntity, string>(to, from.LineTypeName));
      to.LineTypeScale = from.LineTypeScale;
      to.method_10(from.PaperSpace);
      to.Visible = from.Visible;
      to.LineWeight = from.LineWeight;
      from.method_0(to);
    }

    private DxfVertex3D method_190(DxfReader.Class42 vertexInfo)
    {
      DxfVertex3D dxfVertex3D = new DxfVertex3D(vertexInfo.Position);
      this.method_189((DxfReader.Class40) vertexInfo, (DxfEntity) dxfVertex3D);
      return dxfVertex3D;
    }

    private DxfVertex2D method_191(DxfReader.Class42 vertexInfo)
    {
      DxfVertex2D dxfVertex2D = new DxfVertex2D(vertexInfo.Position.X, vertexInfo.Position.Y);
      this.method_189((DxfReader.Class40) vertexInfo, (DxfEntity) dxfVertex2D);
      dxfVertex2D.Bulge = vertexInfo.Bulge;
      dxfVertex2D.StartWidth = vertexInfo.StartWidth;
      dxfVertex2D.EndWidth = vertexInfo.EndWidth;
      dxfVertex2D.Flags = vertexInfo.Flags;
      dxfVertex2D.TangentDirection = vertexInfo.TangentDirection;
      return dxfVertex2D;
    }

    private DxfMeshFace method_192(DxfReader.Class42 vertexInfo)
    {
      DxfMeshFace dxfMeshFace = new DxfMeshFace();
      this.method_189((DxfReader.Class40) vertexInfo, (DxfEntity) dxfMeshFace);
      return dxfMeshFace;
    }

    private void method_193(DxfHandledObject seqEnd)
    {
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 5)
        {
          string handleString = (string) this.struct18_0.Value;
          seqEnd.method_0(handleString);
          this.method_89(new Class259(seqEnd));
        }
        this.method_85();
      }
    }

    private DxfReader.Class42 method_194(Class285 entityBuilder)
    {
      DxfReader.Class42 vertex = new DxfReader.Class42();
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (!this.method_195(entityBuilder, vertex))
          this.method_85();
      }
      return vertex;
    }

    private bool method_195(Class285 entityBuilder, DxfReader.Class42 vertex)
    {
      switch (this.struct18_0.Code)
      {
        case 10:
          WW.Math.Point3D position1 = vertex.Position;
          position1.X = (double) this.struct18_0.Value;
          vertex.Position = position1;
          break;
        case 20:
          WW.Math.Point3D position2 = vertex.Position;
          position2.Y = (double) this.struct18_0.Value;
          vertex.Position = position2;
          break;
        case 30:
          WW.Math.Point3D position3 = vertex.Position;
          position3.Z = (double) this.struct18_0.Value;
          vertex.Position = position3;
          break;
        case 40:
          vertex.StartWidth = (double) this.struct18_0.Value;
          break;
        case 41:
          vertex.EndWidth = (double) this.struct18_0.Value;
          break;
        case 42:
          vertex.Bulge = (double) this.struct18_0.Value;
          break;
        case 50:
          vertex.TangentDirection = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 70:
          vertex.Flags = (Enum51) this.struct18_0.Value;
          break;
        case 71:
          vertex.Vertex1Index = this.struct18_0.Int16;
          break;
        case 72:
          vertex.Vertex2Index = this.struct18_0.Int16;
          break;
        case 73:
          vertex.Vertex3Index = this.struct18_0.Int16;
          break;
        case 74:
          vertex.Vertex4Index = this.struct18_0.Int16;
          break;
        default:
          return this.method_134(entityBuilder, (DxfReader.Class40) vertex);
      }
      this.method_85();
      return true;
    }

    private void method_196(DxfInsert insert)
    {
      Class294 entityBuilder = new Class294((DxfInsertBase) insert);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbBlockReference":
              this.method_197(entityBuilder, insert);
              continue;
            case "AcDbMInsertBlock":
              this.method_198(entityBuilder, insert);
              continue;
            case "AcDbEntity":
              this.method_132((Class285) entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_199(entityBuilder, insert))
          this.method_85();
      }
      if (!entityBuilder.HasAttributes)
        return;
      while (this.struct18_0 == Class824.struct18_22)
      {
        DxfAttribute attribute = new DxfAttribute();
        this.method_238(attribute);
        insert.Attributes.Add(attribute);
      }
      if (!(this.struct18_0 == Class824.struct18_23))
        return;
      this.method_193((DxfHandledObject) insert.AttributesSeqEnd);
    }

    private void method_197(Class294 entityBuilder, DxfInsert insert)
    {
      this.method_91("AcDbBlockReference");
      this.method_85();
      while (!this.method_92("AcDbBlockReference"))
      {
        if (!this.method_199(entityBuilder, insert))
          this.method_85();
      }
    }

    private void method_198(Class294 entityBuilder, DxfInsert insert)
    {
      this.method_91("AcDbMInsertBlock");
      this.method_85();
      while (!this.method_92("AcDbMInsertBlock"))
      {
        if (!this.method_199(entityBuilder, insert))
          this.method_85();
      }
    }

    private bool method_199(Class294 entityBuilder, DxfInsert insert)
    {
      switch (this.struct18_0.Code)
      {
        case 2:
          entityBuilder.BlockName = (string) this.struct18_0.Value;
          break;
        case 10:
          WW.Math.Point3D insertionPoint1 = insert.InsertionPoint;
          insertionPoint1.X = (double) this.struct18_0.Value;
          insert.InsertionPoint = insertionPoint1;
          break;
        case 20:
          WW.Math.Point3D insertionPoint2 = insert.InsertionPoint;
          insertionPoint2.Y = (double) this.struct18_0.Value;
          insert.InsertionPoint = insertionPoint2;
          break;
        case 30:
          WW.Math.Point3D insertionPoint3 = insert.InsertionPoint;
          insertionPoint3.Z = (double) this.struct18_0.Value;
          insert.InsertionPoint = insertionPoint3;
          break;
        case 41:
          WW.Math.Vector3D scaleFactor1 = insert.ScaleFactor;
          scaleFactor1.X = (double) this.struct18_0.Value;
          if (scaleFactor1.X == 0.0)
            scaleFactor1.X = 1.0;
          insert.ScaleFactor = scaleFactor1;
          break;
        case 42:
          WW.Math.Vector3D scaleFactor2 = insert.ScaleFactor;
          scaleFactor2.Y = (double) this.struct18_0.Value;
          if (scaleFactor2.Y == 0.0)
            scaleFactor2.Y = 1.0;
          insert.ScaleFactor = scaleFactor2;
          break;
        case 43:
          WW.Math.Vector3D scaleFactor3 = insert.ScaleFactor;
          scaleFactor3.Z = (double) this.struct18_0.Value;
          if (scaleFactor3.Z == 0.0)
            scaleFactor3.Z = 1.0;
          insert.ScaleFactor = scaleFactor3;
          break;
        case 44:
          insert.ColumnSpacing = (double) this.struct18_0.Value;
          break;
        case 45:
          insert.RowSpacing = (double) this.struct18_0.Value;
          break;
        case 50:
          insert.Rotation = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 66:
          entityBuilder.HasAttributes = (short) this.struct18_0.Value == (short) 1;
          break;
        case 70:
          insert.ColumnCount = (ushort) (short) this.struct18_0.Value;
          break;
        case 71:
          insert.RowCount = (ushort) (short) this.struct18_0.Value;
          break;
        case 210:
          WW.Math.Vector3D zaxis1 = insert.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          insert.ZAxis = zaxis1;
          break;
        case 220:
          WW.Math.Vector3D zaxis2 = insert.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          insert.ZAxis = zaxis2;
          break;
        case 230:
          WW.Math.Vector3D zaxis3 = insert.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          insert.ZAxis = zaxis3;
          break;
        default:
          return this.method_133((Class285) entityBuilder);
      }
      this.method_85();
      return true;
    }

    private DxfDimension method_200()
    {
      DxfReader.Class41 class41 = new DxfReader.Class41();
      Class299 class299 = new Class299((DxfDimension) null);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (!this.method_201((Class285) class299, class41))
          this.method_85();
      }
      DxfDimension first = (DxfDimension) null;
      switch ((short) ((int) class41.DimensionType & 7))
      {
        case 0:
          first = this.method_203(class41);
          break;
        case 1:
          first = this.method_202(class41);
          break;
        case 2:
          first = this.method_207(class41);
          break;
        case 3:
          first = this.method_204(class41);
          break;
        case 4:
          first = this.method_205(class41);
          break;
        case 5:
          first = this.method_206(class41);
          break;
        case 6:
          first = this.method_208(class41);
          break;
      }
      this.list_9.Add(new Pair<DxfDimension, string>(first, class41.BlockName));
      class299.Entity = (DxfEntity) first;
      this.method_89((Class259) class299);
      this.class375_0.ObjectBuilders.Add((Class259) class299);
      return first;
    }

    private bool method_201(Class285 entityBuilder, DxfReader.Class41 dimension)
    {
      bool flag = true;
      switch (this.struct18_0.Code)
      {
        case 1:
          dimension.Text = (string) this.struct18_0.Value;
          break;
        case 2:
          dimension.BlockName = (string) this.struct18_0.Value;
          break;
        case 3:
          string name = (string) this.struct18_0.Value;
          DxfDimensionStyle dimensionStyleWithName = this.dxfModel_0.GetDimensionStyleWithName(name);
          if (dimensionStyleWithName == null)
          {
            this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.UnresolvedReference, Severity.Warning)
            {
              Parameters = {
                {
                  "Type",
                  (object) "DIMSTYLE"
                },
                {
                  "Name",
                  (object) name
                }
              }
            });
            break;
          }
          if (dimension.DimensionStyle == null)
          {
            dimension.DimensionStyle = dimensionStyleWithName;
            break;
          }
          this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.DimStyleAlreadySet, Severity.Error)
          {
            Parameters = {
              {
                "Handle",
                (object) dimensionStyleWithName.Handle
              },
              {
                "Position",
                (object) this.interface33_0.Position
              },
              {
                "DimStyleName",
                (object) name
              }
            }
          });
          break;
        case 10:
          WW.Math.Point3D definitionPoint1_1 = dimension.DefinitionPoint1;
          definitionPoint1_1.X = (double) this.struct18_0.Value;
          dimension.DefinitionPoint1 = definitionPoint1_1;
          break;
        case 11:
          WW.Math.Point3D textMiddlePoint1 = dimension.TextMiddlePoint;
          textMiddlePoint1.X = (double) this.struct18_0.Value;
          dimension.TextMiddlePoint = textMiddlePoint1;
          break;
        case 12:
          WW.Math.Point3D insertionPointWcs1 = dimension.InsertionPointWcs;
          insertionPointWcs1.X = (double) this.struct18_0.Value;
          dimension.InsertionPointWcs = insertionPointWcs1;
          break;
        case 13:
          WW.Math.Point3D definitionPoint4_1 = dimension.DefinitionPoint4;
          definitionPoint4_1.X = (double) this.struct18_0.Value;
          dimension.DefinitionPoint4 = definitionPoint4_1;
          break;
        case 14:
          WW.Math.Point3D definitionPoint5_1 = dimension.DefinitionPoint5;
          definitionPoint5_1.X = (double) this.struct18_0.Value;
          dimension.DefinitionPoint5 = definitionPoint5_1;
          break;
        case 15:
          WW.Math.Point3D definitionPoint6_1 = dimension.DefinitionPoint6;
          definitionPoint6_1.X = (double) this.struct18_0.Value;
          dimension.DefinitionPoint6 = definitionPoint6_1;
          break;
        case 16:
          WW.Math.Point3D definitionPoint7_1 = dimension.DefinitionPoint7;
          definitionPoint7_1.X = (double) this.struct18_0.Value;
          dimension.DefinitionPoint7 = definitionPoint7_1;
          break;
        case 20:
          WW.Math.Point3D definitionPoint1_2 = dimension.DefinitionPoint1;
          definitionPoint1_2.Y = (double) this.struct18_0.Value;
          dimension.DefinitionPoint1 = definitionPoint1_2;
          break;
        case 21:
          WW.Math.Point3D textMiddlePoint2 = dimension.TextMiddlePoint;
          textMiddlePoint2.Y = (double) this.struct18_0.Value;
          dimension.TextMiddlePoint = textMiddlePoint2;
          break;
        case 22:
          WW.Math.Point3D insertionPointWcs2 = dimension.InsertionPointWcs;
          insertionPointWcs2.Y = (double) this.struct18_0.Value;
          dimension.InsertionPointWcs = insertionPointWcs2;
          break;
        case 23:
          WW.Math.Point3D definitionPoint4_2 = dimension.DefinitionPoint4;
          definitionPoint4_2.Y = (double) this.struct18_0.Value;
          dimension.DefinitionPoint4 = definitionPoint4_2;
          break;
        case 24:
          WW.Math.Point3D definitionPoint5_2 = dimension.DefinitionPoint5;
          definitionPoint5_2.Y = (double) this.struct18_0.Value;
          dimension.DefinitionPoint5 = definitionPoint5_2;
          break;
        case 25:
          WW.Math.Point3D definitionPoint6_2 = dimension.DefinitionPoint6;
          definitionPoint6_2.Y = (double) this.struct18_0.Value;
          dimension.DefinitionPoint6 = definitionPoint6_2;
          break;
        case 26:
          WW.Math.Point3D definitionPoint7_2 = dimension.DefinitionPoint7;
          definitionPoint7_2.Y = (double) this.struct18_0.Value;
          dimension.DefinitionPoint7 = definitionPoint7_2;
          break;
        case 30:
          WW.Math.Point3D definitionPoint1_3 = dimension.DefinitionPoint1;
          definitionPoint1_3.Z = (double) this.struct18_0.Value;
          dimension.DefinitionPoint1 = definitionPoint1_3;
          break;
        case 31:
          WW.Math.Point3D textMiddlePoint3 = dimension.TextMiddlePoint;
          textMiddlePoint3.Z = (double) this.struct18_0.Value;
          dimension.TextMiddlePoint = textMiddlePoint3;
          break;
        case 32:
          WW.Math.Point3D insertionPointWcs3 = dimension.InsertionPointWcs;
          insertionPointWcs3.Z = (double) this.struct18_0.Value;
          dimension.InsertionPointWcs = insertionPointWcs3;
          break;
        case 33:
          WW.Math.Point3D definitionPoint4_3 = dimension.DefinitionPoint4;
          definitionPoint4_3.Z = (double) this.struct18_0.Value;
          dimension.DefinitionPoint4 = definitionPoint4_3;
          break;
        case 34:
          WW.Math.Point3D definitionPoint5_3 = dimension.DefinitionPoint5;
          definitionPoint5_3.Z = (double) this.struct18_0.Value;
          dimension.DefinitionPoint5 = definitionPoint5_3;
          break;
        case 35:
          WW.Math.Point3D definitionPoint6_3 = dimension.DefinitionPoint6;
          definitionPoint6_3.Z = (double) this.struct18_0.Value;
          dimension.DefinitionPoint6 = definitionPoint6_3;
          break;
        case 36:
          WW.Math.Point3D definitionPoint7_3 = dimension.DefinitionPoint7;
          definitionPoint7_3.Z = (double) this.struct18_0.Value;
          dimension.DefinitionPoint7 = definitionPoint7_3;
          break;
        case 41:
          dimension.LineSpacingFactor = (double) this.struct18_0.Value;
          break;
        case 42:
          dimension.Measurement = (double) this.struct18_0.Value;
          break;
        case 50:
          dimension.Rotation = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 51:
          dimension.HorizontalDirection = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 52:
          dimension.ObliqueAngle = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 53:
          dimension.TextRotation = new double?((double) this.struct18_0.Value * (System.Math.PI / 180.0));
          break;
        case 54:
          dimension.InsertionRotation = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 70:
          dimension.DimensionType = (short) this.struct18_0.Value;
          break;
        case 71:
          dimension.AttachmentPoint = (AttachmentPoint) this.struct18_0.Value;
          break;
        case 72:
          dimension.LineSpacingStyle = (LineSpacingStyle) this.struct18_0.Value;
          break;
        case 210:
          WW.Math.Vector3D zaxis1 = dimension.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          dimension.ZAxis = zaxis1;
          break;
        case 220:
          WW.Math.Vector3D zaxis2 = dimension.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          dimension.ZAxis = zaxis2;
          break;
        case 230:
          WW.Math.Vector3D zaxis3 = dimension.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          dimension.ZAxis = zaxis3;
          break;
        default:
          return this.method_134(entityBuilder, (DxfReader.Class40) dimension);
      }
      if (flag)
        this.method_85();
      return true;
    }

    private DxfDimension method_202(DxfReader.Class41 dimensionInfo)
    {
      DxfDimension.Aligned dimension = new DxfDimension.Aligned(this.dxfModel_0);
      this.method_210(dimensionInfo, dimension);
      return (DxfDimension) dimension;
    }

    private DxfDimension method_203(DxfReader.Class41 dimensionInfo)
    {
      DxfDimension.Linear linear = new DxfDimension.Linear(this.dxfModel_0);
      this.method_210(dimensionInfo, (DxfDimension.Aligned) linear);
      linear.Rotation = dimensionInfo.Rotation;
      linear.ObliqueAngle = dimensionInfo.ObliqueAngle;
      return (DxfDimension) linear;
    }

    private DxfDimension method_204(DxfReader.Class41 dimensionInfo)
    {
      DxfDimension.Diametric diametric = new DxfDimension.Diametric(this.dxfModel_0);
      this.method_209(dimensionInfo, (DxfDimension) diametric);
      diametric.ArcLineIntersectionPoint1 = dimensionInfo.DefinitionPoint6;
      diametric.ArcLineIntersectionPoint2 = dimensionInfo.DefinitionPoint1;
      diametric.LeaderLength = dimensionInfo.LeaderLength;
      return (DxfDimension) diametric;
    }

    private DxfDimension method_205(DxfReader.Class41 dimensionInfo)
    {
      DxfDimension.Radial radial = new DxfDimension.Radial(this.dxfModel_0);
      this.method_209(dimensionInfo, (DxfDimension) radial);
      radial.ArcLineIntersectionPoint = dimensionInfo.DefinitionPoint6;
      radial.Center = dimensionInfo.DefinitionPoint1;
      radial.LeaderLength = dimensionInfo.LeaderLength;
      return (DxfDimension) radial;
    }

    private DxfDimension method_206(DxfReader.Class41 dimensionInfo)
    {
      DxfDimension.Angular3Point angular3Point = new DxfDimension.Angular3Point(this.dxfModel_0);
      this.method_209(dimensionInfo, (DxfDimension) angular3Point);
      angular3Point.AngleVertex = dimensionInfo.DefinitionPoint6;
      angular3Point.ExtensionLine1StartPoint = dimensionInfo.DefinitionPoint4;
      angular3Point.ExtensionLine2StartPoint = dimensionInfo.DefinitionPoint5;
      angular3Point.DimensionLineArcPoint = dimensionInfo.DefinitionPoint1;
      return (DxfDimension) angular3Point;
    }

    private DxfDimension method_207(DxfReader.Class41 dimensionInfo)
    {
      DxfDimension.Angular4Point angular4Point = new DxfDimension.Angular4Point(this.dxfModel_0);
      this.method_209(dimensionInfo, (DxfDimension) angular4Point);
      angular4Point.ExtensionLine1StartPoint = dimensionInfo.DefinitionPoint4;
      angular4Point.ExtensionLine1EndPoint = dimensionInfo.DefinitionPoint5;
      angular4Point.ExtensionLine2StartPoint = dimensionInfo.DefinitionPoint6;
      angular4Point.ExtensionLine2EndPoint = dimensionInfo.DefinitionPoint1;
      angular4Point.DimensionLineArcPoint = dimensionInfo.DefinitionPoint7;
      return (DxfDimension) angular4Point;
    }

    private DxfDimension method_208(DxfReader.Class41 dimensionInfo)
    {
      DxfDimension.Ordinate ordinate = new DxfDimension.Ordinate(this.dxfModel_0);
      this.method_209(dimensionInfo, (DxfDimension) ordinate);
      ordinate.FeaturePosition = dimensionInfo.DefinitionPoint4;
      ordinate.LeaderEndPoint = dimensionInfo.DefinitionPoint5;
      ordinate.UcsOrigin = dimensionInfo.DefinitionPoint1;
      ordinate.ShowX = ((int) dimensionInfo.DimensionType & 100) != 0;
      return (DxfDimension) ordinate;
    }

    private void method_209(DxfReader.Class41 dimensionInfo, DxfDimension dimension)
    {
      this.method_189((DxfReader.Class40) dimensionInfo, (DxfEntity) dimension);
      dimension.AttachmentPoint = dimensionInfo.AttachmentPoint;
      if (dimension.HasHorizontalDirection)
        dimension.HorizontalDirection = dimensionInfo.HorizontalDirection;
      Matrix4D inverse = DxfUtil.GetToWCSTransform(dimensionInfo.ZAxis).GetInverse();
      dimension.InsertionPoint = inverse.Transform(dimensionInfo.InsertionPointWcs);
      dimension.LineSpacingFactor = dimensionInfo.LineSpacingFactor;
      dimension.LineSpacingStyle = dimensionInfo.LineSpacingStyle;
      dimension.Measurement = dimensionInfo.Measurement;
      dimension.Text = dimensionInfo.Text;
      dimension.TextMiddlePoint = dimensionInfo.TextMiddlePoint;
      dimension.UseTextMiddlePoint = ((int) dimensionInfo.DimensionType & 128) != 0;
      if (dimensionInfo.TextRotation.HasValue)
        dimension.TextRotation = dimensionInfo.TextRotation.Value;
      dimension.ZAxis = dimensionInfo.ZAxis;
      dimension.InsertionScaleFactor = dimensionInfo.InsertionScaleFactor;
      dimension.InsertionRotation = dimensionInfo.InsertionRotation;
      dimension.DimensionStyle = dimensionInfo.DimensionStyle;
    }

    private void method_210(DxfReader.Class41 dimensionInfo, DxfDimension.Aligned dimension)
    {
      this.method_209(dimensionInfo, (DxfDimension) dimension);
      dimension.DimensionLineLocation = dimensionInfo.DefinitionPoint1;
      dimension.ExtensionLine1StartPoint = dimensionInfo.DefinitionPoint4;
      dimension.ExtensionLine2StartPoint = dimensionInfo.DefinitionPoint5;
    }

    private void method_211(DxfCircle circle)
    {
      Class285 entityBuilder = new Class285((DxfEntity) circle);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbCircle":
              this.method_212(entityBuilder, circle);
              continue;
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_213(entityBuilder, circle))
          this.method_85();
      }
    }

    private void method_212(Class285 entityBuilder, DxfCircle circle)
    {
      this.method_91("AcDbCircle");
      this.method_85();
      while (!this.method_92("AcDbCircle"))
      {
        if (!this.method_213(entityBuilder, circle))
          this.method_85();
      }
    }

    private bool method_213(Class285 entityBuilder, DxfCircle circle)
    {
      switch (this.struct18_0.Code)
      {
        case 10:
          WW.Math.Point3D center1 = circle.Center;
          center1.X = (double) this.struct18_0.Value;
          circle.Center = center1;
          break;
        case 20:
          WW.Math.Point3D center2 = circle.Center;
          center2.Y = (double) this.struct18_0.Value;
          circle.Center = center2;
          break;
        case 30:
          WW.Math.Point3D center3 = circle.Center;
          center3.Z = (double) this.struct18_0.Value;
          circle.Center = center3;
          break;
        case 39:
          circle.Thickness = (double) this.struct18_0.Value;
          break;
        case 40:
          circle.Radius = (double) this.struct18_0.Value;
          break;
        case 210:
          WW.Math.Vector3D zaxis1 = circle.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          circle.ZAxis = zaxis1;
          break;
        case 220:
          WW.Math.Vector3D zaxis2 = circle.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          circle.ZAxis = zaxis2;
          break;
        case 230:
          WW.Math.Vector3D zaxis3 = circle.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          circle.ZAxis = zaxis3;
          break;
        default:
          return this.method_133(entityBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_214(DxfArc arc)
    {
      Class285 entityBuilder = new Class285((DxfEntity) arc);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbArc":
              this.method_215(entityBuilder, arc);
              continue;
            case "AcDbCircle":
              this.method_216(entityBuilder, arc);
              continue;
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_217(entityBuilder, arc))
          this.method_85();
      }
    }

    private void method_215(Class285 entityBuilder, DxfArc arc)
    {
      this.method_91("AcDbArc");
      this.method_85();
      while (!this.method_92("AcDbArc"))
      {
        if (!this.method_217(entityBuilder, arc))
          this.method_85();
      }
    }

    private void method_216(Class285 entityBuilder, DxfArc arc)
    {
      this.method_91("AcDbCircle");
      this.method_85();
      while (!this.method_92("AcDbCircle"))
      {
        if (!this.method_217(entityBuilder, arc))
          this.method_85();
      }
    }

    private bool method_217(Class285 entityBuilder, DxfArc arc)
    {
      switch (this.struct18_0.Code)
      {
        case 50:
          arc.StartAngle = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 51:
          arc.EndAngle = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 210:
          WW.Math.Vector3D zaxis1 = arc.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          arc.ZAxis = zaxis1;
          break;
        case 220:
          WW.Math.Vector3D zaxis2 = arc.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          arc.ZAxis = zaxis2;
          break;
        case 230:
          WW.Math.Vector3D zaxis3 = arc.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          arc.ZAxis = zaxis3;
          break;
        default:
          return this.method_213(entityBuilder, (DxfCircle) arc);
      }
      this.method_85();
      return true;
    }

    private void method_218(DxfEllipse ellipse)
    {
      Class285 entityBuilder = new Class285((DxfEntity) ellipse);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbEllipse":
              this.method_219(entityBuilder, ellipse);
              continue;
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_220(entityBuilder, ellipse))
          this.method_85();
      }
    }

    private void method_219(Class285 entityBuilder, DxfEllipse ellipse)
    {
      this.method_91("AcDbEllipse");
      this.method_85();
      while (!this.method_92("AcDbEllipse"))
      {
        if (!this.method_220(entityBuilder, ellipse))
          this.method_85();
      }
    }

    private bool method_220(Class285 entityBuilder, DxfEllipse ellipse)
    {
      switch (this.struct18_0.Code)
      {
        case 10:
          WW.Math.Point3D center1 = ellipse.Center;
          center1.X = (double) this.struct18_0.Value;
          ellipse.Center = center1;
          break;
        case 11:
          WW.Math.Vector3D majorAxisEndPoint1 = ellipse.MajorAxisEndPoint;
          majorAxisEndPoint1.X = (double) this.struct18_0.Value;
          ellipse.MajorAxisEndPoint = majorAxisEndPoint1;
          break;
        case 20:
          WW.Math.Point3D center2 = ellipse.Center;
          center2.Y = (double) this.struct18_0.Value;
          ellipse.Center = center2;
          break;
        case 21:
          WW.Math.Vector3D majorAxisEndPoint2 = ellipse.MajorAxisEndPoint;
          majorAxisEndPoint2.Y = (double) this.struct18_0.Value;
          ellipse.MajorAxisEndPoint = majorAxisEndPoint2;
          break;
        case 30:
          WW.Math.Point3D center3 = ellipse.Center;
          center3.Z = (double) this.struct18_0.Value;
          ellipse.Center = center3;
          break;
        case 31:
          WW.Math.Vector3D majorAxisEndPoint3 = ellipse.MajorAxisEndPoint;
          majorAxisEndPoint3.Z = (double) this.struct18_0.Value;
          ellipse.MajorAxisEndPoint = majorAxisEndPoint3;
          break;
        case 40:
          ellipse.method_13((double) this.struct18_0.Value);
          break;
        case 41:
          ellipse.StartParameter = (double) this.struct18_0.Value;
          break;
        case 42:
          ellipse.EndParameter = (double) this.struct18_0.Value;
          break;
        case 210:
          WW.Math.Vector3D zaxis1 = ellipse.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          ellipse.ZAxis = zaxis1;
          break;
        case 220:
          WW.Math.Vector3D zaxis2 = ellipse.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          ellipse.ZAxis = zaxis2;
          break;
        case 230:
          WW.Math.Vector3D zaxis3 = ellipse.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          ellipse.ZAxis = zaxis3;
          break;
        default:
          return this.method_133(entityBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_221(DxfRasterImage rasterImage)
    {
      Class285 entityBuilder = new Class285((DxfEntity) rasterImage);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (!this.method_222(entityBuilder, rasterImage))
          this.method_85();
      }
    }

    private bool method_222(Class285 entityBuilder, DxfRasterImage image)
    {
      switch (this.struct18_0.Code)
      {
        case 10:
          WW.Math.Point3D insertionPoint1 = image.InsertionPoint;
          insertionPoint1.X = (double) this.struct18_0.Value;
          image.InsertionPoint = insertionPoint1;
          goto case 71;
        case 11:
          WW.Math.Vector3D xaxis1 = image.XAxis;
          xaxis1.X = (double) this.struct18_0.Value;
          image.XAxis = xaxis1;
          goto case 71;
        case 12:
          WW.Math.Vector3D yaxis1 = image.YAxis;
          yaxis1.X = (double) this.struct18_0.Value;
          image.YAxis = yaxis1;
          goto case 71;
        case 13:
          Size2D size1 = image.Size;
          size1.X = (double) this.struct18_0.Value;
          image.Size = size1;
          goto case 71;
        case 14:
          WW.Math.Point2D point2D = new WW.Math.Point2D((double) this.struct18_0.Value, 0.0);
          image.BoundaryVertices.Add(point2D);
          goto case 71;
        case 20:
          WW.Math.Point3D insertionPoint2 = image.InsertionPoint;
          insertionPoint2.Y = (double) this.struct18_0.Value;
          image.InsertionPoint = insertionPoint2;
          goto case 71;
        case 21:
          WW.Math.Vector3D xaxis2 = image.XAxis;
          xaxis2.Y = (double) this.struct18_0.Value;
          image.XAxis = xaxis2;
          goto case 71;
        case 22:
          WW.Math.Vector3D yaxis2 = image.YAxis;
          yaxis2.Y = (double) this.struct18_0.Value;
          image.YAxis = yaxis2;
          goto case 71;
        case 23:
          Size2D size2 = image.Size;
          size2.Y = (double) this.struct18_0.Value;
          image.Size = size2;
          goto case 71;
        case 24:
          int index = image.BoundaryVertices.Count - 1;
          WW.Math.Point2D boundaryVertex = image.BoundaryVertices[index];
          boundaryVertex.Y = (double) this.struct18_0.Value;
          image.BoundaryVertices[index] = boundaryVertex;
          goto case 71;
        case 30:
          WW.Math.Point3D insertionPoint3 = image.InsertionPoint;
          insertionPoint3.Z = (double) this.struct18_0.Value;
          image.InsertionPoint = insertionPoint3;
          goto case 71;
        case 31:
          WW.Math.Vector3D xaxis3 = image.XAxis;
          xaxis3.Z = (double) this.struct18_0.Value;
          image.XAxis = xaxis3;
          goto case 71;
        case 32:
          WW.Math.Vector3D yaxis3 = image.YAxis;
          yaxis3.Z = (double) this.struct18_0.Value;
          image.YAxis = yaxis3;
          goto case 71;
        case 70:
          image.ImageDisplayFlags = (ImageDisplayFlags) this.struct18_0.Int16;
          goto case 71;
        case 71:
        case 360:
          this.method_85();
          return true;
        case 90:
          image.ClassVersion = (int) this.struct18_0.Value;
          goto case 71;
        case 280:
          image.ClippingEnabled = DxfReader.smethod_7((byte) this.struct18_0.Value);
          goto case 71;
        case 281:
          image.Brightness = (byte) this.struct18_0.Value;
          goto case 71;
        case 282:
          image.Contrast = (byte) this.struct18_0.Value;
          goto case 71;
        case 283:
          image.Fade = (byte) this.struct18_0.Value;
          goto case 71;
        case 290:
          bool flag = (bool) this.struct18_0.Value;
          image.ClipMode = flag ? ClipMode.Inside : ClipMode.Outside;
          goto case 71;
        case 340:
          ulong second = (ulong) this.struct18_0.Value;
          this.list_5.Add(new Pair<DxfRasterImage, ulong>(image, second));
          goto case 71;
        default:
          return this.method_133(entityBuilder);
      }
    }

    private void method_223(DxfShape shape)
    {
      Class300 entityBuilder = new Class300(shape);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbShape":
              this.method_224(entityBuilder, shape);
              continue;
            case "AcDbEntity":
              this.method_132((Class285) entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_225(entityBuilder, shape))
          this.method_85();
      }
    }

    private void method_224(Class300 entityBuilder, DxfShape shape)
    {
      this.method_91("AcDbShape");
      this.method_85();
      while (!this.method_92("AcDbShape"))
      {
        if (!this.method_225(entityBuilder, shape))
          this.method_85();
      }
    }

    private bool method_225(Class300 entityBuilder, DxfShape shape)
    {
      switch (this.struct18_0.Code)
      {
        case 2:
          shape.Name = (string) this.struct18_0.Value;
          break;
        case 10:
          WW.Math.Point3D insertionPoint1 = shape.InsertionPoint;
          insertionPoint1.X = (double) this.struct18_0.Value;
          shape.InsertionPoint = insertionPoint1;
          break;
        case 20:
          WW.Math.Point3D insertionPoint2 = shape.InsertionPoint;
          insertionPoint2.Y = (double) this.struct18_0.Value;
          shape.InsertionPoint = insertionPoint2;
          break;
        case 30:
          WW.Math.Point3D insertionPoint3 = shape.InsertionPoint;
          insertionPoint3.Z = (double) this.struct18_0.Value;
          shape.InsertionPoint = insertionPoint3;
          break;
        case 40:
          shape.ScaleFactor = (double) this.struct18_0.Value;
          break;
        case 41:
          shape.RelativeXScaleFactor = (double) this.struct18_0.Value;
          break;
        case 50:
          shape.Rotation = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 51:
          shape.ObliqueAngle = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 90:
          shape.Thickness = (double) this.struct18_0.Value;
          break;
        case 210:
          WW.Math.Vector3D zaxis1 = shape.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          shape.ZAxis = zaxis1;
          break;
        case 220:
          WW.Math.Vector3D zaxis2 = shape.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          shape.ZAxis = zaxis2;
          break;
        case 230:
          WW.Math.Vector3D zaxis3 = shape.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          shape.ZAxis = zaxis3;
          break;
        default:
          return this.method_133((Class285) entityBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_226(DxfSolid solid)
    {
      Class285 entityBuilder = new Class285((DxfEntity) solid);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      WW.Math.Point3D?[] points = new WW.Math.Point3D?[4];
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbTrace":
              this.method_227(entityBuilder, solid, points);
              continue;
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_228(entityBuilder, solid, points))
          this.method_85();
      }
      for (int index = 0; index < points.Length; ++index)
      {
        WW.Math.Point3D? nullable = points[index];
        if (nullable.HasValue)
          solid.Points.Add(nullable.Value);
      }
    }

    private void method_227(Class285 entityBuilder, DxfSolid solid, WW.Math.Point3D?[] points)
    {
      this.method_91("AcDbTrace");
      this.method_85();
      while (!this.method_92("AcDbTrace"))
      {
        if (!this.method_228(entityBuilder, solid, points))
          this.method_85();
      }
    }

    private bool method_228(Class285 entityBuilder, DxfSolid solid, WW.Math.Point3D?[] points)
    {
      switch (this.struct18_0.Code)
      {
        case 10:
          WW.Math.Point3D point3D1 = points[0] ?? WW.Math.Point3D.Zero;
          point3D1.X = (double) this.struct18_0.Value;
          points[0] = new WW.Math.Point3D?(point3D1);
          break;
        case 11:
          WW.Math.Point3D point3D2 = points[1] ?? WW.Math.Point3D.Zero;
          point3D2.X = (double) this.struct18_0.Value;
          points[1] = new WW.Math.Point3D?(point3D2);
          break;
        case 12:
          WW.Math.Point3D point3D3 = points[2] ?? WW.Math.Point3D.Zero;
          point3D3.X = (double) this.struct18_0.Value;
          points[2] = new WW.Math.Point3D?(point3D3);
          break;
        case 13:
          WW.Math.Point3D point3D4 = points[3] ?? WW.Math.Point3D.Zero;
          point3D4.X = (double) this.struct18_0.Value;
          points[3] = new WW.Math.Point3D?(point3D4);
          break;
        case 20:
          WW.Math.Point3D point3D5 = points[0] ?? WW.Math.Point3D.Zero;
          point3D5.Y = (double) this.struct18_0.Value;
          points[0] = new WW.Math.Point3D?(point3D5);
          break;
        case 21:
          WW.Math.Point3D point3D6 = points[1] ?? WW.Math.Point3D.Zero;
          point3D6.Y = (double) this.struct18_0.Value;
          points[1] = new WW.Math.Point3D?(point3D6);
          break;
        case 22:
          WW.Math.Point3D point3D7 = points[2] ?? WW.Math.Point3D.Zero;
          point3D7.Y = (double) this.struct18_0.Value;
          points[2] = new WW.Math.Point3D?(point3D7);
          break;
        case 23:
          WW.Math.Point3D point3D8 = points[3] ?? WW.Math.Point3D.Zero;
          point3D8.Y = (double) this.struct18_0.Value;
          points[3] = new WW.Math.Point3D?(point3D8);
          break;
        case 30:
          WW.Math.Point3D point3D9 = points[0] ?? WW.Math.Point3D.Zero;
          point3D9.Z = (double) this.struct18_0.Value;
          points[0] = new WW.Math.Point3D?(point3D9);
          break;
        case 31:
          WW.Math.Point3D point3D10 = points[1] ?? WW.Math.Point3D.Zero;
          point3D10.Z = (double) this.struct18_0.Value;
          points[1] = new WW.Math.Point3D?(point3D10);
          break;
        case 32:
          WW.Math.Point3D point3D11 = points[2] ?? WW.Math.Point3D.Zero;
          point3D11.Z = (double) this.struct18_0.Value;
          points[2] = new WW.Math.Point3D?(point3D11);
          break;
        case 33:
          WW.Math.Point3D point3D12 = points[3] ?? WW.Math.Point3D.Zero;
          point3D12.Z = (double) this.struct18_0.Value;
          points[3] = new WW.Math.Point3D?(point3D12);
          break;
        case 39:
          solid.Thickness = (double) this.struct18_0.Value;
          break;
        case 210:
          WW.Math.Vector3D zaxis1 = solid.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          solid.ZAxis = zaxis1;
          break;
        case 220:
          WW.Math.Vector3D zaxis2 = solid.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          solid.ZAxis = zaxis2;
          break;
        case 230:
          WW.Math.Vector3D zaxis3 = solid.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          solid.ZAxis = zaxis3;
          break;
        default:
          return this.method_133(entityBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_229(DxfSpline spline)
    {
      Class285 entityBuilder = new Class285((DxfEntity) spline);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbSpline":
              this.method_230(entityBuilder, spline);
              continue;
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_231(entityBuilder, spline))
          this.method_85();
      }
    }

    private void method_230(Class285 entityBuilder, DxfSpline spline)
    {
      this.method_91("AcDbSpline");
      this.method_85();
      while (!this.method_92("AcDbSpline"))
      {
        if (!this.method_231(entityBuilder, spline))
          this.method_85();
      }
    }

    private bool method_231(Class285 entityBuilder, DxfSpline spline)
    {
      switch (this.struct18_0.Code)
      {
        case 10:
          WW.Math.Point3D point3D1 = new WW.Math.Point3D((double) this.struct18_0.Value, 0.0, 0.0);
          spline.ControlPoints.Add(point3D1);
          goto case 72;
        case 11:
          WW.Math.Point3D point3D2 = new WW.Math.Point3D((double) this.struct18_0.Value, 0.0, 0.0);
          spline.FitPoints.Add(point3D2);
          goto case 72;
        case 12:
          WW.Math.Vector3D startTangent1 = spline.StartTangent;
          startTangent1.X = (double) this.struct18_0.Value;
          spline.StartTangent = startTangent1;
          goto case 72;
        case 13:
          WW.Math.Vector3D endTangent1 = spline.EndTangent;
          endTangent1.X = (double) this.struct18_0.Value;
          spline.EndTangent = endTangent1;
          goto case 72;
        case 20:
          WW.Math.Point3D controlPoint1 = spline.ControlPoints[spline.ControlPoints.Count - 1];
          controlPoint1.Y = (double) this.struct18_0.Value;
          spline.ControlPoints[spline.ControlPoints.Count - 1] = controlPoint1;
          goto case 72;
        case 21:
          WW.Math.Point3D fitPoint1 = spline.FitPoints[spline.FitPoints.Count - 1];
          fitPoint1.Y = (double) this.struct18_0.Value;
          spline.FitPoints[spline.FitPoints.Count - 1] = fitPoint1;
          goto case 72;
        case 22:
          WW.Math.Vector3D startTangent2 = spline.StartTangent;
          startTangent2.Y = (double) this.struct18_0.Value;
          spline.StartTangent = startTangent2;
          goto case 72;
        case 23:
          WW.Math.Vector3D endTangent2 = spline.EndTangent;
          endTangent2.Y = (double) this.struct18_0.Value;
          spline.EndTangent = endTangent2;
          goto case 72;
        case 30:
          WW.Math.Point3D controlPoint2 = spline.ControlPoints[spline.ControlPoints.Count - 1];
          controlPoint2.Z = (double) this.struct18_0.Value;
          spline.ControlPoints[spline.ControlPoints.Count - 1] = controlPoint2;
          goto case 72;
        case 31:
          WW.Math.Point3D fitPoint2 = spline.FitPoints[spline.FitPoints.Count - 1];
          fitPoint2.Z = (double) this.struct18_0.Value;
          spline.FitPoints[spline.FitPoints.Count - 1] = fitPoint2;
          goto case 72;
        case 32:
          WW.Math.Vector3D startTangent3 = spline.StartTangent;
          startTangent3.Z = (double) this.struct18_0.Value;
          spline.StartTangent = startTangent3;
          goto case 72;
        case 33:
          WW.Math.Vector3D endTangent3 = spline.EndTangent;
          endTangent3.Z = (double) this.struct18_0.Value;
          spline.EndTangent = endTangent3;
          goto case 72;
        case 40:
          double num1 = (double) this.struct18_0.Value;
          spline.Knots.Add(num1);
          goto case 72;
        case 41:
          double num2 = (double) this.struct18_0.Value;
          spline.Weights.Add(num2);
          goto case 72;
        case 42:
          double num3 = (double) this.struct18_0.Value;
          spline.KnotTolerance = num3;
          goto case 72;
        case 43:
          double num4 = (double) this.struct18_0.Value;
          spline.ControlPointTolerance = num4;
          goto case 72;
        case 44:
          double num5 = (double) this.struct18_0.Value;
          spline.FitTolerance = num5;
          goto case 72;
        case 70:
          spline.Flags = (SplineFlags) (short) this.struct18_0.Value;
          goto case 72;
        case 71:
          spline.Degree = (int) (short) this.struct18_0.Value;
          goto case 72;
        case 72:
        case 73:
        case 74:
          this.method_85();
          return true;
        case 210:
          WW.Math.Vector3D zaxis1 = spline.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          spline.ZAxis = zaxis1;
          goto case 72;
        case 220:
          WW.Math.Vector3D zaxis2 = spline.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          spline.ZAxis = zaxis2;
          goto case 72;
        case 230:
          WW.Math.Vector3D zaxis3 = spline.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          spline.ZAxis = zaxis3;
          goto case 72;
        default:
          return this.method_133(entityBuilder);
      }
    }

    private void method_232(DxfText text)
    {
      Class285 entityBuilder = new Class285((DxfEntity) text);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbText":
              this.method_233(entityBuilder, text, 73);
              continue;
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_234(entityBuilder, text, 73))
          this.method_85();
      }
    }

    private void method_233(Class285 entityBuilder, DxfText text, int verticalAlignmentGroup)
    {
      this.method_91("AcDbText");
      this.method_85();
      while (!this.method_92("AcDbText"))
      {
        if (!this.method_234(entityBuilder, text, verticalAlignmentGroup))
          this.method_85();
      }
    }

    private bool method_234(Class285 entityBuilder, DxfText text, int verticalAlignmentGroup)
    {
      if (this.struct18_0.Code == verticalAlignmentGroup)
      {
        text.VerticalAlignment = (TextVerticalAlignment) this.struct18_0.Value;
        this.method_85();
        return true;
      }
      switch (this.struct18_0.Code)
      {
        case 1:
          text.Text = (string) this.struct18_0.Value;
          break;
        case 7:
          string name = (string) this.struct18_0.Value;
          text.Style = this.GetTextStyleWithName(name);
          break;
        case 10:
          WW.Math.Point3D alignmentPoint1_1 = text.AlignmentPoint1;
          alignmentPoint1_1.X = (double) this.struct18_0.Value;
          text.AlignmentPoint1 = alignmentPoint1_1;
          break;
        case 11:
          WW.Math.Point3D point3D1 = text.AlignmentPoint2 ?? WW.Math.Point3D.Zero;
          point3D1.X = (double) this.struct18_0.Value;
          text.AlignmentPoint2 = new WW.Math.Point3D?(point3D1);
          break;
        case 20:
          WW.Math.Point3D alignmentPoint1_2 = text.AlignmentPoint1;
          alignmentPoint1_2.Y = (double) this.struct18_0.Value;
          text.AlignmentPoint1 = alignmentPoint1_2;
          break;
        case 21:
          WW.Math.Point3D point3D2 = text.AlignmentPoint2 ?? WW.Math.Point3D.Zero;
          point3D2.Y = (double) this.struct18_0.Value;
          text.AlignmentPoint2 = new WW.Math.Point3D?(point3D2);
          break;
        case 30:
          WW.Math.Point3D alignmentPoint1_3 = text.AlignmentPoint1;
          alignmentPoint1_3.Z = (double) this.struct18_0.Value;
          text.AlignmentPoint1 = alignmentPoint1_3;
          break;
        case 31:
          WW.Math.Point3D point3D3 = text.AlignmentPoint2 ?? WW.Math.Point3D.Zero;
          point3D3.Z = (double) this.struct18_0.Value;
          text.AlignmentPoint2 = new WW.Math.Point3D?(point3D3);
          break;
        case 39:
          text.Thickness = (double) this.struct18_0.Value;
          break;
        case 40:
          text.Height = (double) this.struct18_0.Value;
          break;
        case 41:
          text.WidthFactor = (double) this.struct18_0.Value;
          break;
        case 50:
          text.Rotation = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 51:
          text.ObliqueAngle = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 71:
          text.TextGenerationFlags = (TextGenerationFlags) this.struct18_0.Value;
          break;
        case 72:
          text.HorizontalAlignment = (TextHorizontalAlignment) this.struct18_0.Value;
          break;
        case 210:
          WW.Math.Vector3D zaxis1 = text.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          text.ZAxis = zaxis1;
          break;
        case 220:
          WW.Math.Vector3D zaxis2 = text.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          text.ZAxis = zaxis2;
          break;
        case 230:
          WW.Math.Vector3D zaxis3 = text.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          text.ZAxis = zaxis3;
          break;
        default:
          return this.method_133(entityBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_235(DxfAttributeDefinition attributeDefinition)
    {
      Class285 entityBuilder = new Class285((DxfEntity) attributeDefinition);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbAttributeDefinition":
              this.method_236(entityBuilder, attributeDefinition);
              continue;
            case "AcDbText":
              this.method_233(entityBuilder, (DxfText) attributeDefinition, 74);
              continue;
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_237(entityBuilder, attributeDefinition))
          this.method_85();
      }
    }

    private void method_236(Class285 entityBuilder, DxfAttributeDefinition attributeDefinition)
    {
      this.method_91("AcDbAttributeDefinition");
      this.method_85();
      while (!this.method_92("AcDbAttributeDefinition"))
      {
        if (!this.method_237(entityBuilder, attributeDefinition))
          this.method_85();
      }
    }

    private bool method_237(Class285 entityBuilder, DxfAttributeDefinition attributeDefinition)
    {
      switch (this.struct18_0.Code)
      {
        case 2:
          attributeDefinition.method_17((string) this.struct18_0.Value);
          goto case 73;
        case 3:
          attributeDefinition.PromptString = (string) this.struct18_0.Value;
          goto case 73;
        case 70:
          attributeDefinition.Flags = (AttributeFlags) this.struct18_0.Value;
          goto case 73;
        case 73:
          this.method_85();
          return true;
        case 74:
          attributeDefinition.VerticalAlignment = (TextVerticalAlignment) this.struct18_0.Value;
          goto case 73;
        case 280:
          attributeDefinition.LockPosition = DxfReader.smethod_7((byte) this.struct18_0.Value);
          goto case 73;
        default:
          return this.method_234(entityBuilder, (DxfText) attributeDefinition, 74);
      }
    }

    private void method_238(DxfAttribute attribute)
    {
      Class285 entityBuilder = new Class285((DxfEntity) attribute);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbAttribute":
              this.method_239(entityBuilder, attribute);
              continue;
            case "AcDbText":
              this.method_233(entityBuilder, (DxfText) attribute, 74);
              continue;
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_240(entityBuilder, attribute))
          this.method_85();
      }
    }

    private void method_239(Class285 entityBuilder, DxfAttribute attribute)
    {
      this.method_91("AcDbAttribute");
      this.method_85();
      while (!this.method_92("AcDbAttribute"))
      {
        if (!this.method_240(entityBuilder, attribute))
          this.method_85();
      }
    }

    private bool method_240(Class285 entityBuilder, DxfAttribute attribute)
    {
      switch (this.struct18_0.Code)
      {
        case 2:
          attribute.method_17((string) this.struct18_0.Value);
          goto case 73;
        case 70:
          attribute.Flags = (AttributeFlags) this.struct18_0.Value;
          goto case 73;
        case 73:
          this.method_85();
          return true;
        case 74:
          attribute.VerticalAlignment = (TextVerticalAlignment) this.struct18_0.Value;
          goto case 73;
        case 280:
          attribute.LockPosition = DxfReader.smethod_7((byte) this.struct18_0.Value);
          goto case 73;
        default:
          return this.method_234(entityBuilder, (DxfText) attribute, 74);
      }
    }

    private void method_241(DxfMText text)
    {
      Class285 entityBuilder = new Class285((DxfEntity) text);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbMText":
              this.method_242(entityBuilder, text);
              continue;
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_243(entityBuilder, text))
          this.method_85();
      }
    }

    private void method_242(Class285 entityBuilder, DxfMText text)
    {
      this.method_91("AcDbMText");
      this.method_85();
      while (!this.method_92("AcDbMText"))
      {
        if (!this.method_243(entityBuilder, text))
          this.method_85();
      }
    }

    private bool method_243(Class285 entityBuilder, DxfMText text)
    {
      switch (this.struct18_0.Code)
      {
        case 1:
        case 3:
          text.Text += (string) this.struct18_0.Value;
          break;
        case 7:
          string name = (string) this.struct18_0.Value;
          text.Style = this.GetTextStyleWithName(name);
          break;
        case 10:
          WW.Math.Point3D insertionPoint1 = text.InsertionPoint;
          insertionPoint1.X = (double) this.struct18_0.Value;
          text.InsertionPoint = insertionPoint1;
          break;
        case 11:
          WW.Math.Vector3D xaxis1 = text.XAxis;
          xaxis1.X = (double) this.struct18_0.Value;
          text.XAxis = xaxis1;
          break;
        case 20:
          WW.Math.Point3D insertionPoint2 = text.InsertionPoint;
          insertionPoint2.Y = (double) this.struct18_0.Value;
          text.InsertionPoint = insertionPoint2;
          break;
        case 21:
          WW.Math.Vector3D xaxis2 = text.XAxis;
          xaxis2.Y = (double) this.struct18_0.Value;
          text.XAxis = xaxis2;
          break;
        case 30:
          WW.Math.Point3D insertionPoint3 = text.InsertionPoint;
          insertionPoint3.Z = (double) this.struct18_0.Value;
          text.InsertionPoint = insertionPoint3;
          break;
        case 31:
          WW.Math.Vector3D xaxis3 = text.XAxis;
          xaxis3.Z = (double) this.struct18_0.Value;
          text.XAxis = xaxis3;
          break;
        case 40:
          text.Height = (double) this.struct18_0.Value;
          break;
        case 41:
          text.ReferenceRectangleWidth = (double) this.struct18_0.Value;
          break;
        case 44:
          text.LineSpacingFactor = (double) this.struct18_0.Value;
          break;
        case 45:
          if (text.BackgroundFillInfo == null)
            text.BackgroundFillInfo = new BackgroundFillInfo();
          text.BackgroundFillInfo.BorderOffsetFactor = (double) this.struct18_0.Value;
          break;
        case 46:
          text.ReferenceRectangleHeight = (double) this.struct18_0.Value;
          break;
        case 50:
          double num = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          text.XAxis = new WW.Math.Vector3D(System.Math.Cos(num), System.Math.Sin(num), 0.0);
          break;
        case 63:
          if (text.BackgroundFillInfo == null)
            text.BackgroundFillInfo = new BackgroundFillInfo();
          text.BackgroundFillInfo.Color = Color.CreateFromColorIndex((short) this.struct18_0.Value);
          break;
        case 71:
          text.AttachmentPoint = (AttachmentPoint) this.struct18_0.Value;
          break;
        case 72:
          text.DrawingDirection = (DrawingDirection) this.struct18_0.Value;
          break;
        case 73:
          text.LineSpacingStyle = (LineSpacingStyle) this.struct18_0.Value;
          break;
        case 90:
          text.BackgroundFillFlags = (BackgroundFillFlags) (int) this.struct18_0.Value;
          break;
        case 210:
          WW.Math.Vector3D zaxis1 = text.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          text.ZAxis = zaxis1;
          break;
        case 220:
          WW.Math.Vector3D zaxis2 = text.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          text.ZAxis = zaxis2;
          break;
        case 230:
          WW.Math.Vector3D zaxis3 = text.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          text.ZAxis = zaxis3;
          break;
        case 421:
          if (text.BackgroundFillInfo == null)
            text.BackgroundFillInfo = new BackgroundFillInfo();
          text.BackgroundFillInfo.Color = Color.CreateFromRgb((int) this.struct18_0.Value);
          break;
        case 431:
          if (text.BackgroundFillInfo == null)
            text.BackgroundFillInfo = new BackgroundFillInfo();
          string[] strArray = ((string) this.struct18_0.Value).Split('$');
          if (strArray != null && strArray.Length == 2)
          {
            text.BackgroundFillInfo.Color = Color.smethod_1(text.BackgroundFillInfo.Color.Data, strArray[0], strArray[1]);
            break;
          }
          break;
        case 441:
          if (text.BackgroundFillInfo == null)
            text.BackgroundFillInfo = new BackgroundFillInfo();
          text.BackgroundFillInfo.Transparency = new Transparency((uint) (int) this.struct18_0.Value);
          break;
        default:
          return this.method_133(entityBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_244(Dxf3DFace face)
    {
      Class285 entityBuilder = new Class285((DxfEntity) face);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      WW.Math.Point3D?[] points = new WW.Math.Point3D?[4];
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbFace":
              this.method_245(entityBuilder, face, points);
              continue;
            case "AcDbEntity":
              this.method_132(entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_246(entityBuilder, face, points))
          this.method_85();
      }
      for (int index = 0; index < points.Length; ++index)
      {
        WW.Math.Point3D? nullable = points[index];
        if (nullable.HasValue)
          face.Points.Add(nullable.Value);
      }
    }

    private void method_245(Class285 entityBuilder, Dxf3DFace face, WW.Math.Point3D?[] points)
    {
      this.method_91("AcDbFace");
      this.method_85();
      while (!this.method_92("AcDbFace"))
      {
        if (!this.method_246(entityBuilder, face, points))
          this.method_85();
      }
    }

    private bool method_246(Class285 entityBuilder, Dxf3DFace face, WW.Math.Point3D?[] points)
    {
      switch (this.struct18_0.Code)
      {
        case 10:
          WW.Math.Point3D point3D1 = points[0] ?? WW.Math.Point3D.Zero;
          point3D1.X = (double) this.struct18_0.Value;
          points[0] = new WW.Math.Point3D?(point3D1);
          break;
        case 11:
          WW.Math.Point3D point3D2 = points[1] ?? WW.Math.Point3D.Zero;
          point3D2.X = (double) this.struct18_0.Value;
          points[1] = new WW.Math.Point3D?(point3D2);
          break;
        case 12:
          WW.Math.Point3D point3D3 = points[2] ?? WW.Math.Point3D.Zero;
          point3D3.X = (double) this.struct18_0.Value;
          points[2] = new WW.Math.Point3D?(point3D3);
          break;
        case 13:
          WW.Math.Point3D point3D4 = points[3] ?? WW.Math.Point3D.Zero;
          point3D4.X = (double) this.struct18_0.Value;
          points[3] = new WW.Math.Point3D?(point3D4);
          break;
        case 20:
          WW.Math.Point3D point3D5 = points[0] ?? WW.Math.Point3D.Zero;
          point3D5.Y = (double) this.struct18_0.Value;
          points[0] = new WW.Math.Point3D?(point3D5);
          break;
        case 21:
          WW.Math.Point3D point3D6 = points[1] ?? WW.Math.Point3D.Zero;
          point3D6.Y = (double) this.struct18_0.Value;
          points[1] = new WW.Math.Point3D?(point3D6);
          break;
        case 22:
          WW.Math.Point3D point3D7 = points[2] ?? WW.Math.Point3D.Zero;
          point3D7.Y = (double) this.struct18_0.Value;
          points[2] = new WW.Math.Point3D?(point3D7);
          break;
        case 23:
          WW.Math.Point3D point3D8 = points[3] ?? WW.Math.Point3D.Zero;
          point3D8.Y = (double) this.struct18_0.Value;
          points[3] = new WW.Math.Point3D?(point3D8);
          break;
        case 30:
          WW.Math.Point3D point3D9 = points[0] ?? WW.Math.Point3D.Zero;
          point3D9.Z = (double) this.struct18_0.Value;
          points[0] = new WW.Math.Point3D?(point3D9);
          break;
        case 31:
          WW.Math.Point3D point3D10 = points[1] ?? WW.Math.Point3D.Zero;
          point3D10.Z = (double) this.struct18_0.Value;
          points[1] = new WW.Math.Point3D?(point3D10);
          break;
        case 32:
          WW.Math.Point3D point3D11 = points[2] ?? WW.Math.Point3D.Zero;
          point3D11.Z = (double) this.struct18_0.Value;
          points[2] = new WW.Math.Point3D?(point3D11);
          break;
        case 33:
          WW.Math.Point3D point3D12 = points[3] ?? WW.Math.Point3D.Zero;
          point3D12.Z = (double) this.struct18_0.Value;
          points[3] = new WW.Math.Point3D?(point3D12);
          break;
        case 70:
          face.method_14((InvisibleEdgeFlags) this.struct18_0.Value);
          break;
        default:
          return this.method_133(entityBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_247(DxfHatch hatch)
    {
      Class298 entityBuilder = new Class298(hatch);
      this.class375_0.ObjectBuilders.Add((Class259) entityBuilder);
      WW.Math.Point3D? currentSeedPoint = new WW.Math.Point3D?();
      bool firstSeedPoint = true;
      DxfGradientColor gradientColor = (DxfGradientColor) null;
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbHatch":
              this.method_248(entityBuilder, hatch, ref currentSeedPoint, ref firstSeedPoint, ref gradientColor);
              continue;
            case "AcDbEntity":
              this.method_132((Class285) entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_249(entityBuilder, hatch, ref currentSeedPoint, ref firstSeedPoint, ref gradientColor))
          this.method_85();
      }
    }

    private void method_248(
      Class298 entityBuilder,
      DxfHatch hatch,
      ref WW.Math.Point3D? currentSeedPoint,
      ref bool firstSeedPoint,
      ref DxfGradientColor gradientColor)
    {
      this.method_91("AcDbHatch");
      this.method_85();
      while (!this.method_92("AcDbHatch"))
      {
        if (!this.method_249(entityBuilder, hatch, ref currentSeedPoint, ref firstSeedPoint, ref gradientColor))
          this.method_85();
      }
    }

    private bool method_249(
      Class298 entityBuilder,
      DxfHatch hatch,
      ref WW.Math.Point3D? currentSeedPoint,
      ref bool firstSeedPoint,
      ref DxfGradientColor gradientColor)
    {
      bool flag = true;
      switch (this.struct18_0.Code)
      {
        case 2:
          hatch.Name = (string) this.struct18_0.Value;
          goto case 70;
        case 10:
          WW.Math.Point3D point3D1 = currentSeedPoint ?? WW.Math.Point3D.Zero;
          point3D1.X = (double) this.struct18_0.Value;
          currentSeedPoint = new WW.Math.Point3D?(point3D1);
          goto case 70;
        case 20:
          WW.Math.Point3D point3D2 = currentSeedPoint ?? WW.Math.Point3D.Zero;
          point3D2.Y = (double) this.struct18_0.Value;
          currentSeedPoint = new WW.Math.Point3D?(point3D2);
          if (!firstSeedPoint)
          {
            hatch.SeedPoints.Add(new WW.Math.Point2D(currentSeedPoint.Value.X, currentSeedPoint.Value.Y));
            currentSeedPoint = new WW.Math.Point3D?();
            goto case 70;
          }
          else
            goto case 70;
        case 30:
          WW.Math.Point3D point3D3 = currentSeedPoint ?? WW.Math.Point3D.Zero;
          point3D3.Z = (double) this.struct18_0.Value;
          currentSeedPoint = new WW.Math.Point3D?(point3D3);
          if (firstSeedPoint)
          {
            firstSeedPoint = false;
            hatch.ElevationPoint = point3D3;
          }
          currentSeedPoint = new WW.Math.Point3D?();
          goto case 70;
        case 41:
          hatch.Scale = (double) this.struct18_0.Value;
          goto case 70;
        case 47:
          hatch.PixelSize = (double) this.struct18_0.Value;
          goto case 70;
        case 52:
          hatch.HatchPatternAngle = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          goto case 70;
        case 63:
          if (gradientColor == null)
            return this.method_133((Class285) entityBuilder);
          short colorIndex = (short) this.struct18_0.Value;
          gradientColor.Color = Color.CreateFromColorIndex(colorIndex);
          goto case 70;
        case 70:
          if (flag)
            this.method_85();
          return true;
        case 71:
          short num1 = (short) this.struct18_0.Value;
          hatch.Associative = num1 == (short) 1;
          goto case 70;
        case 75:
          hatch.HatchStyle = (HatchStyle) this.struct18_0.Value;
          goto case 70;
        case 76:
          hatch.HatchPatternType = (HatchPatternType) (short) this.struct18_0.Value;
          goto case 70;
        case 77:
          short num2 = (short) this.struct18_0.Value;
          hatch.IsDouble = num2 == (short) 1;
          goto case 70;
        case 78:
          ushort num3 = (ushort) (short) this.struct18_0.Value;
          this.method_85();
          hatch.method_13();
          hatch.Pattern.Read(this, (int) num3);
          flag = false;
          goto case 70;
        case 91:
          int n = (int) this.struct18_0.Value;
          this.method_85();
          this.method_250(entityBuilder, hatch, n);
          flag = false;
          goto case 70;
        case 210:
          WW.Math.Vector3D zaxis1 = hatch.ZAxis;
          zaxis1.X = (double) this.struct18_0.Value;
          hatch.ZAxis = zaxis1;
          goto case 70;
        case 220:
          WW.Math.Vector3D zaxis2 = hatch.ZAxis;
          zaxis2.Y = (double) this.struct18_0.Value;
          hatch.ZAxis = zaxis2;
          goto case 70;
        case 230:
          WW.Math.Vector3D zaxis3 = hatch.ZAxis;
          zaxis3.Z = (double) this.struct18_0.Value;
          hatch.ZAxis = zaxis3;
          goto case 70;
        case 421:
          if (gradientColor == null)
            return this.method_133((Class285) entityBuilder);
          int rgb = (int) this.struct18_0.Value;
          gradientColor.Color = Color.CreateFromRgb(rgb);
          goto case 70;
        case 450:
          DxfReader.smethod_2(hatch);
          hatch.ColorGradient.Enabled = (int) this.struct18_0.Value != 0;
          goto case 70;
        case 451:
          DxfReader.smethod_2(hatch);
          hatch.ColorGradient.Reserved1 = (int) this.struct18_0.Value;
          goto case 70;
        case 452:
          DxfReader.smethod_2(hatch);
          hatch.ColorGradient.IsSingleColorGradient = (int) this.struct18_0.Value != 0;
          goto case 70;
        case 453:
          DxfReader.smethod_2(hatch);
          int num4 = (int) this.struct18_0.Value;
          goto case 70;
        case 460:
          DxfReader.smethod_2(hatch);
          hatch.ColorGradient.Angle = (double) this.struct18_0.Value;
          goto case 70;
        case 461:
          DxfReader.smethod_2(hatch);
          hatch.ColorGradient.Shift = (double) this.struct18_0.Value;
          goto case 70;
        case 462:
          DxfReader.smethod_2(hatch);
          hatch.ColorGradient.ColorTint = (double) this.struct18_0.Value;
          goto case 70;
        case 463:
          DxfReader.smethod_2(hatch);
          gradientColor = new DxfGradientColor()
          {
            Value = (double) this.struct18_0.Value
          };
          hatch.ColorGradient.GradientColors.Add(gradientColor);
          goto case 70;
        case 470:
          DxfReader.smethod_2(hatch);
          hatch.ColorGradient.Name = (string) this.struct18_0.Value;
          goto case 70;
        default:
          return this.method_133((Class285) entityBuilder);
      }
    }

    private static void smethod_2(DxfHatch hatch)
    {
      if (hatch.ColorGradient != null)
        return;
      hatch.ColorGradient = new DxfColorGradient();
    }

    private void method_250(Class298 entityBuilder, DxfHatch hatch, int n)
    {
      for (int index = 0; index < n; ++index)
      {
        if (this.struct18_0.Code != 92)
          throw new Exception("Expected group 92 in boundary path model, but got group " + (object) this.struct18_0.Code);
        DxfHatch.BoundaryPath boundaryPath = new DxfHatch.BoundaryPath();
        Class659 boundaryPathBuilder = new Class659(boundaryPath);
        entityBuilder.BoundaryPathBuilders.Add(boundaryPathBuilder);
        boundaryPath.Type = (BoundaryPathType) this.struct18_0.Value;
        this.method_251(boundaryPathBuilder, boundaryPath);
        hatch.BoundaryPaths.Add(boundaryPath);
      }
    }

    private void method_251(Class659 boundaryPathBuilder, DxfHatch.BoundaryPath boundaryPath)
    {
      if ((boundaryPath.Type & BoundaryPathType.Polyline) == BoundaryPathType.Polyline)
      {
        boundaryPath.PolylineData = new DxfHatch.BoundaryPath.Polyline();
        this.method_85();
        boundaryPath.PolylineData.Read(this);
      }
      else
        this.method_85();
      bool flag = true;
      do
      {
        switch (this.struct18_0.Code)
        {
          case 93:
            int nrOfEdges = (int) this.struct18_0.Value;
            this.method_85();
            boundaryPath.method_0(nrOfEdges, this);
            break;
          case 97:
            this.method_85();
            break;
          case 330:
            boundaryPathBuilder.method_0((ulong) this.struct18_0.Value);
            this.method_85();
            break;
          default:
            flag = false;
            break;
        }
      }
      while (flag);
    }

    private void method_252()
    {
      this.method_85();
      while (this.struct18_0 != Class824.struct18_1 && this.struct18_0 != Struct18.struct18_0)
      {
        if (this.struct18_0.Code == 0)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "ACDBPLACEHOLDER":
              DxfPlaceHolder placeHolder = new DxfPlaceHolder();
              this.method_273(placeHolder);
              if (this.dxfModel_0.PlotStyle == null)
              {
                this.dxfModel_0.PlotStyle = placeHolder;
                continue;
              }
              continue;
            case "DICTIONARY":
              DxfDictionary dictionary = new DxfDictionary();
              this.method_253(dictionary);
              if (this.dxfModel_0.DictionaryRoot == null)
              {
                this.dxfModel_0.DictionaryRoot = dictionary;
                continue;
              }
              continue;
            case "ACDBDICTIONARYWDFLT":
              this.method_256(new DxfDictionaryWithDefault());
              continue;
            case "DICTIONARYVAR":
              this.method_259(new DxfDictionaryVariable());
              continue;
            case "FIELD":
              this.method_262(new DxfField());
              continue;
            case "FIELDLIST":
              this.method_265(new DxfFieldList());
              continue;
            case "GROUP":
              this.method_309(new DxfGroup());
              continue;
            case "ACAD_EVALUATION_GRAPH":
              this.method_1(new DxfEvalGraph());
              continue;
            case "BLOCKBASEPOINTPARAMETER":
              this.method_4(new DxfBlockBasePointParameter());
              continue;
            case "BLOCKUSERPARAMETER":
              this.method_5(new DxfBlockUserParameter());
              continue;
            case "BLOCKLOOKUPPARAMETER":
              this.method_33(new DxfBlockLookUpParameter());
              continue;
            case "BLOCKVISIBILITYPARAMETER":
              this.method_34(new DxfBlockVisibilityParameter());
              continue;
            case "BLOCKPROPERTIESTABLE":
              this.method_35(new DxfBlockPropertiesTable());
              continue;
            case "BLOCKALIGNMENTPARAMETER":
              this.method_32(new DxfBlockAlignmentParameter());
              continue;
            case "BLOCKFLIPPARAMETER":
              this.method_18(new DxfBlockFlipParameter());
              continue;
            case "BLOCKALIGNMENTGRIP":
              this.method_19(new DxfBlockAlignmentGrip());
              continue;
            case "BLOCKFLIPGRIP":
              this.method_20(new DxfBlockFlipGrip());
              continue;
            case "ACDB_BLOCKREPRESENTATION_DATA":
              this.method_21(new DxfBlockRepresentationData());
              continue;
            case "ACDB_DYNAMICBLOCKPURGEPREVENTER_VERSION":
              this.method_22(new DxfBlockPurgePreventer());
              continue;
            case "BLOCKLINEARGRIP":
              this.method_25(new DxfBlockLinearGrip());
              continue;
            case "BLOCKLOOKUPGRIP":
              this.method_26(new DxfBlockLookupGrip());
              continue;
            case "BLOCKPOLARGRIP":
              this.method_27(new DxfBlockPolarGrip());
              continue;
            case "BLOCKPROPERTIESTABLEGRIP":
              this.method_28(new DxfBlockPropertiesTableGrip());
              continue;
            case "BLOCKROTATIONGRIP":
              this.method_29(new DxfBlockRotationGrip());
              continue;
            case "BLOCKVISIBILITYGRIP":
              this.method_30(new DxfBlockVisibilityGrip());
              continue;
            case "BLOCKXYGRIP":
              this.method_31(new DxfBlockXYGrip());
              continue;
            case "BLOCKGRIPLOCATIONCOMPONENT":
              this.method_23(new DxfBlockGripExpression());
              continue;
            case "ACDB_DYNAMICBLOCKPROXYNODE":
              this.method_24(new DxfDynamicBlockProxyNode());
              continue;
            case "BLOCKLINEARPARAMETER":
              this.method_17(new DxfBlockLinearParameter());
              continue;
            case "BLOCKPOLARPARAMETER":
              this.method_6(new DxfBlockPolarParameter());
              continue;
            case "BLOCKROTATIONPARAMETER":
              this.method_15(new DxfBlockRotationParameter());
              continue;
            case "BLOCKXYPARAMETER":
              this.method_16(new DxfBlockXYParameter());
              continue;
            case "BLOCKROTATEACTION":
              this.method_14(new DxfBlockRotateAction());
              continue;
            case "BLOCKSCALEACTION":
              this.method_13(new DxfBlockScaleAction());
              continue;
            case "BLOCKARRAYACTION":
              this.method_12(new DxfBlockArrayAction());
              continue;
            case "BLOCKFLIPACTION":
              this.method_7(new DxfBlockFlipAction());
              continue;
            case "BLOCKLOOKUPACTION":
              this.method_8(new DxfBlockLookupAction());
              continue;
            case "BLOCKMOVEACTION":
              this.method_9(new DxfBlockMoveAction());
              continue;
            case "BLOCKPOLARSTRETCHACTION":
              this.method_11(new DxfBlockPolarStretchAction());
              continue;
            case "BLOCKSTRETCHACTION":
              this.method_10(new DxfBlockStretchAction());
              continue;
            case "BLOCKPOINTPARAMETER":
              this.method_36(new DxfBlockPointParameter());
              continue;
            case "GEODATA":
              this.method_318<DxfGeoData>();
              continue;
            case "IDBUFFER":
              this.method_271(new DxfIdBuffer());
              continue;
            case "IMAGEDEF":
              DxfImageDef imageDef = new DxfImageDef(this.dxfModel_0);
              this.method_312(imageDef);
              this.dxfModel_0.Images.Add(imageDef);
              continue;
            case "LAYOUT":
              DxfLayout layout = new DxfLayout();
              this.method_315(layout);
              this.class375_0.Layouts.Add(layout);
              continue;
            case "MLEADERSTYLE":
              this.method_318<DxfMLeaderStyle>();
              continue;
            case "MLINESTYLE":
              this.method_268(new DxfMLineStyle());
              continue;
            case "PLOTSETTINGS":
              this.method_274(new DxfPlotSettings());
              continue;
            case "TABLESTYLE":
              this.method_277(new DxfTableStyle((string) null, false));
              continue;
            case "CELLSTYLEMAP":
              this.method_281(new DxfCellStyleMap());
              continue;
            case "XRECORD":
              this.method_302(new DxfXRecord());
              continue;
            case "DBCOLOR":
              DxfColor color = new DxfColor();
              this.method_306(color);
              this.dxfModel_0.Colors.Add(color);
              continue;
            case "RASTERVARIABLES":
              this.method_318<DxfRasterVariables>();
              continue;
            case "TABLECONTENT":
              this.method_344(new DxfTableContent());
              continue;
            case "SORTENTSTABLE":
              this.method_296(new DxfSortEntsTable());
              continue;
            case "SPATIAL_FILTER":
              this.method_299(new DxfSpatialFilter());
              continue;
            case "SCALE":
              this.method_318<DxfScale>();
              continue;
            case "ACDB_MTEXTOBJECTCONTEXTDATA_CLASS":
              this.method_318<DxfMTextObjectContextData>();
              continue;
            case "ACDB_BLKREFOBJECTCONTEXTDATA_CLASS":
              this.method_318<DxfBlockReferenceObjectContextData>();
              continue;
            case "ACDB_FCFOBJECTCONTEXTDATA_CLASS":
              this.method_318<DxfToleranceObjectContextData>();
              continue;
            case "ACDB_HATCHSCALECONTEXTDATA_CLASS":
              this.method_318<DxfHatchScaleContextData>();
              continue;
            case "ACDB_HATCHVIEWCONTEXTDATA_CLASS":
              this.method_318<DxfHatchViewContextData>();
              continue;
            case "ACDB_TEXTOBJECTCONTEXTDATA_CLASS":
              this.method_318<DxfTextObjectContextData>();
              continue;
            case "ACDB_MTEXTATTRIBUTEOBJECTCONTEXTDATA_CLASS":
              this.method_318<DxfAttributeObjectContextData>();
              continue;
            case "ACDB_ALDIMOBJECTCONTEXTDATA_CLASS":
              this.method_318<DxfDimensionObjectContextData.Aligned>();
              continue;
            case "ACDB_ANGDIMOBJECTCONTEXTDATA_CLASS":
              this.method_318<DxfDimensionObjectContextData.Angular>();
              continue;
            case "ACDB_DMDIMOBJECTCONTEXTDATA_CLASS":
              this.method_318<DxfDimensionObjectContextData.Diametric>();
              continue;
            case "ACDB_ORDDIMOBJECTCONTEXTDATA_CLASS":
              this.method_318<DxfDimensionObjectContextData.Ordinate>();
              continue;
            case "ACDB_RADIMOBJECTCONTEXTDATA_CLASS":
              this.method_318<DxfDimensionObjectContextData.Radial>();
              continue;
            case "ACDB_LEADEROBJECTCONTEXTDATA_CLASS":
              this.method_318<DxfLeaderObjectContextData>();
              continue;
            case "VISUALSTYLE":
              this.method_318<DxfVisualStyle>();
              continue;
            case "WIPEOUTVARIABLES":
              this.method_318<DxfWipeoutVariables>();
              continue;
            case "BLOCKLINEARCONSTRAINTPARAMETER":
              this.method_318<DxfBlockLinearConstraintParameter>();
              continue;
            case "BLOCKHORIZONTALCONSTRAINTPARAMETER":
              this.method_318<DxfBlockHorizontalConstraintParameter>();
              continue;
            case "BLOCKVERTICALCONSTRAINTPARAMETER":
              this.method_318<DxfBlockVerticalConstraintParameter>();
              continue;
            case "BLOCKALIGNEDCONSTRAINTPARAMETER":
              this.method_318<DxfBlockAlignedConstraintParameter>();
              continue;
            case "BLOCKANGULARCONSTRAINTPARAMETER":
              this.method_318<DxfBlockAngularConstraintParameter>();
              continue;
            case "BLOCKDIAMETRICCONSTRAINTPARAMETER":
              this.method_318<DxfBlockDiametricConstraintParameter>();
              continue;
            case "BLOCKRADIALCONSTRAINTPARAMETER":
              this.method_318<DxfBlockRadialConstraintParameter>();
              continue;
            default:
              this.method_85();
              this.method_356(0);
              continue;
          }
        }
        else
          this.method_85();
      }
    }

    private void method_253(DxfDictionary dictionary)
    {
      Class262 objectBuilder = new Class262(dictionary);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      dictionary.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbDictionary":
            this.method_254(objectBuilder, dictionary);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_254(Class262 objectBuilder, DxfDictionary dictionary)
    {
      this.method_91("AcDbDictionary");
      this.method_85();
      DxfDictionaryEntry entry = (DxfDictionaryEntry) null;
      while (!this.method_92("AcDbDictionary"))
      {
        if (!this.method_255(objectBuilder, dictionary, ref entry))
          this.method_85();
      }
    }

    private bool method_255(
      Class262 objectBuilder,
      DxfDictionary dictionary,
      ref DxfDictionaryEntry entry)
    {
      switch (this.struct18_0.Code)
      {
        case 3:
          entry = new DxfDictionaryEntry();
          entry.Name = (string) this.struct18_0.Value;
          dictionary.Entries.Add((IDictionaryEntry) entry);
          break;
        case 280:
          dictionary.HardOwner = DxfReader.smethod_7((byte) this.struct18_0.Value);
          break;
        case 281:
          dictionary.DuplicateRecordCloning = (DuplicateRecordCloning) this.struct18_0.Value;
          break;
        case 350:
          ulong itemHandle1 = (ulong) this.struct18_0.Value;
          this.class375_0.DictionaryEntryBuilders.Add(new Class332(dictionary, entry, itemHandle1));
          break;
        case 360:
          entry.ValueReferenceIsHard = true;
          ulong itemHandle2 = (ulong) this.struct18_0.Value;
          this.class375_0.DictionaryEntryBuilders.Add(new Class332(dictionary, entry, itemHandle2));
          break;
        default:
          return dictionary.method_6(this, (Class259) objectBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_256(DxfDictionaryWithDefault dictionary)
    {
      Class263 objectBuilder = new Class263(dictionary);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      dictionary.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbDictionary":
            this.method_254((Class262) objectBuilder, (DxfDictionary) dictionary);
            continue;
          case "AcDbDictionaryWithDefault":
            this.method_257(objectBuilder, dictionary);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_257(Class263 objectBuilder, DxfDictionaryWithDefault dictionary)
    {
      this.method_91("AcDbDictionaryWithDefault");
      this.method_85();
      while (!this.method_92("AcDbDictionaryWithDefault"))
      {
        if (!this.method_258(objectBuilder, dictionary))
          this.method_85();
      }
    }

    private bool method_258(Class263 objectBuilder, DxfDictionaryWithDefault dictionary)
    {
      if (this.struct18_0.Code != 340)
        return dictionary.method_6(this, (Class259) objectBuilder);
      ulong num = (ulong) this.struct18_0.Value;
      objectBuilder.DefaultEntryHandle = num;
      this.method_85();
      return true;
    }

    private void method_259(DxfDictionaryVariable dictionaryVariable)
    {
      Class260 objectBuilder = new Class260((DxfObject) dictionaryVariable);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      dictionaryVariable.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "DictionaryVariables":
            this.method_260(objectBuilder, dictionaryVariable);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_260(Class260 objectBuilder, DxfDictionaryVariable dictionaryVariable)
    {
      this.method_91("DictionaryVariables");
      this.method_85();
      while (!this.method_92("DictionaryVariables"))
      {
        if (!this.method_261(objectBuilder, dictionaryVariable))
          this.method_85();
      }
    }

    private bool method_261(Class260 objectBuilder, DxfDictionaryVariable dictionaryVariable)
    {
      switch (this.struct18_0.Code)
      {
        case 1:
          dictionaryVariable.Value = (string) this.struct18_0.Value;
          goto case 280;
        case 280:
          this.method_85();
          return true;
        default:
          return dictionaryVariable.method_6(this, (Class259) objectBuilder);
      }
    }

    private void method_262(DxfField field)
    {
      Class283 objectBuilder = new Class283(field);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      field.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbField":
            this.method_263(objectBuilder, field);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_263(Class283 objectBuilder, DxfField field)
    {
      this.method_91("AcDbField");
      this.method_85();
      while (!this.method_92("AcDbField"))
      {
        if (!this.method_264(objectBuilder, field))
          this.method_85();
      }
    }

    private bool method_264(Class283 objectBuilder, DxfField field)
    {
      switch (this.struct18_0.Code)
      {
        case 1:
          field.EvaluatorId = (string) this.struct18_0.Value;
          goto case 90;
        case 2:
        case 3:
          field.FieldCode += (string) this.struct18_0.Value;
          goto case 90;
        case 4:
          field.FormatString = (string) this.struct18_0.Value;
          goto case 90;
        case 6:
        case 7:
          string key = (string) this.struct18_0.Value;
          DxfValue dxfValue;
          if (this.struct18_0.Code == 7)
          {
            field.Key = key;
            dxfValue = field.Value;
          }
          else
          {
            dxfValue = new DxfValue();
            field.Values.Add(key, dxfValue);
          }
          Class999 valueBuilder = new Class999(dxfValue);
          objectBuilder.ChildBuilders.Add((Interface10) valueBuilder);
          this.method_153(valueBuilder);
          goto case 90;
        case 9:
        case 301:
          field.ValueString += (string) this.struct18_0.Value;
          goto case 90;
        case 90:
        case 93:
        case 97:
        case 98:
          this.method_85();
          return true;
        case 91:
          field.EvalutationOptionFlags = (FieldEvaluationOptionFlags) this.struct18_0.Value;
          goto case 90;
        case 92:
          field.FilingOptionFlags = (FilingOptionFlags) this.struct18_0.Value;
          goto case 90;
        case 94:
          field.FieldStateFlags = (FieldStateFlags) this.struct18_0.Value;
          goto case 90;
        case 95:
          field.EvaluationStatusFlags = (EvaluationStatusFlags) this.struct18_0.Value;
          goto case 90;
        case 96:
          field.EvaluationErrorCode = (int) this.struct18_0.Value;
          goto case 90;
        case 300:
          field.EvaluationErrorMessage = (string) this.struct18_0.Value;
          goto case 90;
        case 331:
          objectBuilder.method_2((ulong) this.struct18_0.Value);
          goto case 90;
        case 360:
          objectBuilder.method_1((ulong) this.struct18_0.Value);
          goto case 90;
        default:
          return field.method_6(this, (Class259) objectBuilder);
      }
    }

    private void method_265(DxfFieldList fieldList)
    {
      Class282 objectBuilder = new Class282(fieldList);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      fieldList.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbIdSet":
            this.method_266(objectBuilder, fieldList);
            continue;
          case "AcDbFieldList":
            this.method_267(objectBuilder, fieldList);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_266(Class282 objectBuilder, DxfFieldList fieldList)
    {
      this.method_91("AcDbIdSet");
      this.method_85();
      while (!this.method_92("AcDbIdSet"))
      {
        if (this.struct18_0.Code == 330)
          objectBuilder.FieldHandles.Add((ulong) this.struct18_0.Value);
        this.method_85();
      }
    }

    private void method_267(Class282 objectBuilder, DxfFieldList fieldList)
    {
      this.method_91("AcDbFieldList");
      this.method_85();
      while (!this.method_92("AcDbFieldList"))
        this.method_85();
    }

    private void method_268(DxfMLineStyle mlineStyle)
    {
      Class260 objectBuilder = new Class260((DxfObject) mlineStyle);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      mlineStyle.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbMlineStyle":
            this.method_269(objectBuilder, mlineStyle);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_269(Class260 objectBuilder, DxfMLineStyle mlineStyle)
    {
      this.method_91("AcDbMlineStyle");
      this.method_85();
      DxfMLineStyle.Element currentElement = (DxfMLineStyle.Element) null;
      while (!this.method_92("AcDbMlineStyle"))
      {
        if (!this.method_270(objectBuilder, mlineStyle, ref currentElement))
          this.method_85();
      }
    }

    private bool method_270(
      Class260 objectBuilder,
      DxfMLineStyle mlineStyle,
      ref DxfMLineStyle.Element currentElement)
    {
      switch (this.struct18_0.Code)
      {
        case 2:
          mlineStyle.Name = (string) this.struct18_0.Value;
          break;
        case 3:
          mlineStyle.Description = (string) this.struct18_0.Value;
          break;
        case 6:
          string second = (string) this.struct18_0.Value;
          this.list_6.Add(new Pair<DxfMLineStyle.Element, string>(currentElement, second));
          break;
        case 49:
          currentElement = new DxfMLineStyle.Element(this.dxfModel_0);
          mlineStyle.Elements.Add(currentElement);
          currentElement.Offset = (double) this.struct18_0.Value;
          break;
        case 51:
          mlineStyle.StartAngle = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 52:
          mlineStyle.EndAngle = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 62:
          short colorIndex = (short) this.struct18_0.Value;
          if (currentElement == null)
          {
            mlineStyle.FillColor = Color.CreateFromColorIndex(colorIndex);
            break;
          }
          currentElement.Color = Color.CreateFromColorIndex(colorIndex);
          break;
        case 70:
          mlineStyle.Flags = (MLineStyleFlags) this.struct18_0.Int16;
          break;
        default:
          return mlineStyle.method_6(this, (Class259) objectBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_271(DxfIdBuffer idBuffer)
    {
      Class261 objectBuilder = new Class261(idBuffer);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      idBuffer.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbIdBuffer":
            this.method_272(objectBuilder, idBuffer);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_272(Class261 objectBuilder, DxfIdBuffer idBuffer)
    {
      this.method_91("AcDbIdBuffer");
      this.method_85();
      while (!this.method_92("AcDbIdBuffer"))
      {
        if (this.struct18_0.Code == 330)
          objectBuilder.Handles.Add((ulong) this.struct18_0.Value);
        this.method_85();
      }
    }

    private void method_273(DxfPlaceHolder placeHolder)
    {
      Class260 class260 = new Class260((DxfObject) placeHolder);
      this.class375_0.ObjectBuilders.Add((Class259) class260);
      placeHolder.method_5(this, (Class259) class260);
    }

    private void method_274(DxfPlotSettings plotSettings)
    {
      Class260 objectBuilder = new Class260((DxfObject) plotSettings);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      plotSettings.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbPlotSettings":
            this.method_275(objectBuilder, plotSettings);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_275(Class260 objectBuilder, DxfPlotSettings plotSettings)
    {
      this.method_91("AcDbPlotSettings");
      this.method_85();
      while (!this.method_92("AcDbPlotSettings"))
      {
        if (!this.method_276(objectBuilder, plotSettings))
          this.method_85();
      }
    }

    private bool method_276(Class260 objectBuilder, DxfPlotSettings plotSettings)
    {
      switch (this.struct18_0.Code)
      {
        case 1:
          plotSettings.PageSetupName = (string) this.struct18_0.Value;
          break;
        case 2:
          plotSettings.PlotConfigurationFile = (string) this.struct18_0.Value;
          break;
        case 4:
          plotSettings.PaperSizeName = (string) this.struct18_0.Value;
          break;
        case 6:
          plotSettings.PlotViewName = (string) this.struct18_0.Value;
          break;
        case 7:
          plotSettings.CurrentStyleSheet = (string) this.struct18_0.Value;
          break;
        case 40:
          plotSettings.UnprintableMarginLeft = (double) this.struct18_0.Value;
          break;
        case 41:
          plotSettings.UnprintableMarginBottom = (double) this.struct18_0.Value;
          break;
        case 42:
          plotSettings.UnprintableMarginRight = (double) this.struct18_0.Value;
          break;
        case 43:
          plotSettings.UnprintableMarginTop = (double) this.struct18_0.Value;
          break;
        case 44:
          Size2D plotPaperSize1 = plotSettings.PlotPaperSize;
          plotPaperSize1.X = (double) this.struct18_0.Value;
          plotSettings.PlotPaperSize = plotPaperSize1;
          break;
        case 45:
          Size2D plotPaperSize2 = plotSettings.PlotPaperSize;
          plotPaperSize2.Y = (double) this.struct18_0.Value;
          plotSettings.PlotPaperSize = plotPaperSize2;
          break;
        case 46:
          WW.Math.Point2D plotOrigin1 = plotSettings.PlotOrigin;
          plotOrigin1.X = (double) this.struct18_0.Value;
          plotSettings.PlotOrigin = plotOrigin1;
          break;
        case 47:
          WW.Math.Point2D plotOrigin2 = plotSettings.PlotOrigin;
          plotOrigin2.Y = (double) this.struct18_0.Value;
          plotSettings.PlotOrigin = plotOrigin2;
          break;
        case 48:
          Rectangle2D plotWindowArea1 = plotSettings.PlotWindowArea;
          plotWindowArea1.X1 = (double) this.struct18_0.Value;
          plotSettings.PlotWindowArea = plotWindowArea1;
          break;
        case 49:
          Rectangle2D plotWindowArea2 = plotSettings.PlotWindowArea;
          plotWindowArea2.Y1 = (double) this.struct18_0.Value;
          plotSettings.PlotWindowArea = plotWindowArea2;
          break;
        case 70:
          plotSettings.PlotLayoutFlags = (PlotLayoutFlags) this.struct18_0.Value;
          break;
        case 72:
          plotSettings.PlotPaperUnits = (PlotPaperUnits) (short) this.struct18_0.Value;
          break;
        case 73:
          plotSettings.PlotRotation = (PlotRotation) (short) this.struct18_0.Value;
          break;
        case 74:
          plotSettings.PlotArea = (PlotArea) (short) this.struct18_0.Value;
          break;
        case 75:
          plotSettings.StandardScaleType = (short) this.struct18_0.Value;
          break;
        case 76:
          plotSettings.ShadePlotMode = (ShadePlotMode) this.struct18_0.Value;
          break;
        case 77:
          plotSettings.ShadePlotResolution = (ShadePlotResolution) (short) this.struct18_0.Value;
          break;
        case 78:
          plotSettings.ShadePlotCustomDpi = (short) this.struct18_0.Value;
          break;
        case 140:
          Rectangle2D plotWindowArea3 = plotSettings.PlotWindowArea;
          plotWindowArea3.X2 = (double) this.struct18_0.Value;
          plotSettings.PlotWindowArea = plotWindowArea3;
          break;
        case 141:
          Rectangle2D plotWindowArea4 = plotSettings.PlotWindowArea;
          plotWindowArea4.Y2 = (double) this.struct18_0.Value;
          plotSettings.PlotWindowArea = plotWindowArea4;
          break;
        case 142:
          plotSettings.CustomPrintScaleNumerator = (double) this.struct18_0.Value;
          break;
        case 143:
          plotSettings.CustomPrintScaleDenominator = (double) this.struct18_0.Value;
          break;
        case 147:
          plotSettings.StandardScaleFactor = (double) this.struct18_0.Value;
          break;
        case 148:
          WW.Math.Point2D paperImageOrigin1 = plotSettings.PaperImageOrigin;
          paperImageOrigin1.X = (double) this.struct18_0.Value;
          plotSettings.PaperImageOrigin = paperImageOrigin1;
          break;
        case 149:
          WW.Math.Point2D paperImageOrigin2 = plotSettings.PaperImageOrigin;
          paperImageOrigin2.Y = (double) this.struct18_0.Value;
          plotSettings.PaperImageOrigin = paperImageOrigin2;
          break;
        default:
          return plotSettings.method_6(this, (Class259) objectBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_277(DxfTableStyle tableStyle)
    {
      Class280 tableStyleBuilder = new Class280(tableStyle);
      this.class375_0.ObjectBuilders.Add((Class259) tableStyleBuilder);
      tableStyle.method_5(this, (Class259) tableStyleBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbTableStyle":
            this.method_278(tableStyleBuilder);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_278(Class280 tableStyleBuilder)
    {
      this.method_91("AcDbTableStyle");
      this.method_85();
      List<int> currentCellStyleGroupCodes = new List<int>();
      while (!this.method_92("AcDbTableStyle"))
      {
        if (!this.method_279(tableStyleBuilder, currentCellStyleGroupCodes))
          this.method_85();
      }
    }

    private bool method_279(Class280 tableStyleBuilder, List<int> currentCellStyleGroupCodes)
    {
      DxfTableStyle tableStyle = tableStyleBuilder.TableStyle;
      switch (this.struct18_0.Code)
      {
        case 3:
          tableStyle.Description = (string) this.struct18_0.Value;
          break;
        case 7:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          string index = (string) this.struct18_0.Value;
          tableStyleBuilder.CurrentCellStyle.method_0(this.dxfModel_0.TextStyles[index]);
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 40:
          tableStyle.HorizontalCellMargin = (double) this.struct18_0.Value;
          break;
        case 41:
          tableStyle.VerticalCellMargin = (double) this.struct18_0.Value;
          break;
        case 62:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.method_3(DxfIndexedColorSet.smethod_15((short) this.struct18_0.Value));
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 63:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.method_10(DxfIndexedColorSet.smethod_15((short) this.struct18_0.Value));
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 64:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderTop.SetColor(DxfIndexedColorSet.smethod_15((short) this.struct18_0.Value));
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 65:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderInsideHorizontal.SetColor(DxfIndexedColorSet.smethod_15((short) this.struct18_0.Value));
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 66:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderBottom.SetColor(DxfIndexedColorSet.smethod_15((short) this.struct18_0.Value));
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 67:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderLeft.SetColor(DxfIndexedColorSet.smethod_15((short) this.struct18_0.Value));
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 68:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderInsideVertical.SetColor(DxfIndexedColorSet.smethod_15((short) this.struct18_0.Value));
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 69:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderRight.SetColor(DxfIndexedColorSet.smethod_15((short) this.struct18_0.Value));
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 70:
          tableStyle.FlowDirection = (TableFlowDirection) this.struct18_0.Value;
          break;
        case 71:
          tableStyle.Flags = (ushort) (short) this.struct18_0.Value;
          break;
        case 90:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyleBuilder.DataType = (ValueDataType) this.struct18_0.Value;
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 91:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyleBuilder.DataUnitType = (ValueUnitType) this.struct18_0.Value;
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 140:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.method_1((double) this.struct18_0.Value);
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 170:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.method_2((CellAlignment) this.struct18_0.Value);
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 274:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderTop.SetLineWeight((short) this.struct18_0.Value);
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 275:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderInsideHorizontal.SetLineWeight((short) this.struct18_0.Value);
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 276:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderBottom.SetLineWeight((short) this.struct18_0.Value);
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 277:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderLeft.SetLineWeight((short) this.struct18_0.Value);
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 278:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderInsideVertical.SetLineWeight((short) this.struct18_0.Value);
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 279:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderRight.SetLineWeight((short) this.struct18_0.Value);
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 280:
          tableStyle.SuppressTitle = DxfReader.smethod_7((byte) this.struct18_0.Value);
          break;
        case 281:
          tableStyle.SuppressHeaderRow = DxfReader.smethod_7((byte) this.struct18_0.Value);
          break;
        case 283:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.IsBackColorEnabled = DxfReader.smethod_7((byte) this.struct18_0.Value);
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 284:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderTop.method_2(DxfReader.smethod_7((byte) this.struct18_0.Value));
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 285:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderInsideHorizontal.method_2(DxfReader.smethod_7((byte) this.struct18_0.Value));
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 286:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderBottom.method_2(DxfReader.smethod_7((byte) this.struct18_0.Value));
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 287:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderLeft.method_2(DxfReader.smethod_7((byte) this.struct18_0.Value));
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 288:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderInsideVertical.method_2(DxfReader.smethod_7((byte) this.struct18_0.Value));
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        case 289:
          this.method_280(tableStyleBuilder, currentCellStyleGroupCodes);
          tableStyleBuilder.CurrentCellStyle.BorderRight.method_2(DxfReader.smethod_7((byte) this.struct18_0.Value));
          currentCellStyleGroupCodes.Add(this.struct18_0.Code);
          break;
        default:
          return tableStyle.method_6(this, (Class259) tableStyleBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_280(Class280 tableStyleBuilder, List<int> currentCellStyleGroupCodes)
    {
      if (tableStyleBuilder.CurrentCellStyle != null && !currentCellStyleGroupCodes.Contains(this.struct18_0.Code))
        return;
      currentCellStyleGroupCodes.Clear();
      tableStyleBuilder.method_1();
    }

    private void method_281(DxfCellStyleMap cellStyleMap)
    {
      Class264 cellStyleMapBuilder = new Class264(cellStyleMap);
      this.class375_0.ObjectBuilders.Add((Class259) cellStyleMapBuilder);
      this.class375_0.CellStyleMapBuilders.Add(cellStyleMap, cellStyleMapBuilder);
      cellStyleMap.method_5(this, (Class259) cellStyleMapBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbCellStyleMap":
            this.method_282(cellStyleMapBuilder);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_282(Class264 cellStyleMapBuilder)
    {
      this.method_91("AcDbCellStyleMap");
      this.method_85();
      while (!this.method_92("AcDbCellStyleMap"))
      {
        if (!this.method_283(cellStyleMapBuilder))
          this.method_85();
      }
    }

    private bool method_283(Class264 cellStyleMapBuilder)
    {
      switch (this.struct18_0.Code)
      {
        case 90:
          cellStyleMapBuilder.CellStyleCount = (int) this.struct18_0.Value;
          this.method_85();
          return true;
        case 300:
          Class567 cellStyleBuilder = cellStyleMapBuilder.method_1();
          cellStyleBuilder.CellStyle.HasData = true;
          this.method_284(cellStyleBuilder);
          return true;
        default:
          return cellStyleMapBuilder.HandledObject.method_6(this, (Class259) cellStyleMapBuilder);
      }
    }

    private void method_284(Class567 cellStyleBuilder)
    {
      this.method_85();
      while (this.struct18_0.Code == 1)
        this.method_285(cellStyleBuilder);
    }

    private bool method_285(Class567 cellStyleBuilder)
    {
      if (this.struct18_0.Code != 1)
        return false;
      switch ((string) this.struct18_0.Value)
      {
        case "TABLEFORMAT_BEGIN":
          this.method_286(cellStyleBuilder);
          break;
        case "CELLSTYLE_BEGIN":
          this.method_294(cellStyleBuilder);
          break;
      }
      this.method_85();
      return true;
    }

    private void method_286(Class567 cellStyleBuilder)
    {
      this.method_85();
      while (this.struct18_0.Code != 309 || !((string) this.struct18_0.Value == "TABLEFORMAT_END"))
      {
        if (!this.method_287(cellStyleBuilder))
          this.method_85();
      }
    }

    private bool method_287(Class567 cellStyleBuilder)
    {
      switch (this.struct18_0.Code)
      {
        case 62:
          cellStyleBuilder.CellStyle.method_3(DxfIndexedColorSet.smethod_15((short) this.struct18_0.Value));
          goto case 94;
        case 90:
          cellStyleBuilder.CellStyle.TableCellStyleType = (Enum22) this.struct18_0.Value;
          goto case 94;
        case 91:
          cellStyleBuilder.CellStyle.CellStylePropertyOverrideFlags = (TableCellStylePropertyFlags) this.struct18_0.Value;
          goto case 94;
        case 92:
          cellStyleBuilder.CellStyle.MergeFlags = (TableCellStylePropertyFlags) this.struct18_0.Value;
          goto case 94;
        case 93:
          cellStyleBuilder.CellStyle.method_20((TableCellContentLayoutFlags) this.struct18_0.Value);
          goto case 94;
        case 94:
          this.method_85();
          return true;
        case 95:
          cellStyleBuilder.CurrentBorderId = (int) this.struct18_0.Value;
          goto case 94;
        case 170:
          cellStyleBuilder.CellStyle.DataFlags = (short) this.struct18_0.Value;
          goto case 94;
        case 171:
          cellStyleBuilder.CellStyle.MarginOverrideFlags = (short) this.struct18_0.Value;
          goto case 94;
        case 300:
          if ((string) this.struct18_0.Value == "CONTENTFORMAT")
          {
            this.method_85();
            if (this.struct18_0.Code != 1 || !((string) this.struct18_0.Value == "CONTENTFORMAT_BEGIN"))
              return false;
            this.method_288((Class566) cellStyleBuilder);
            goto case 94;
          }
          else
            goto case 94;
        case 301:
          if ((string) this.struct18_0.Value == "MARGIN")
          {
            this.method_85();
            if (this.struct18_0.Code != 1 || !((string) this.struct18_0.Value == "CELLMARGIN_BEGIN"))
              return false;
            this.method_290(cellStyleBuilder);
            goto case 94;
          }
          else
            goto case 94;
        case 302:
          if ((string) this.struct18_0.Value == "GRIDFORMAT")
          {
            this.method_85();
            if (this.struct18_0.Code != 1 || !((string) this.struct18_0.Value == "GRIDFORMAT_BEGIN"))
              return false;
            this.method_292(cellStyleBuilder);
            goto case 94;
          }
          else
            goto case 94;
        default:
          return false;
      }
    }

    private void method_288(Class566 contentFormatBuilder)
    {
      this.method_85();
      while (this.struct18_0.Code != 309 || !((string) this.struct18_0.Value == "CONTENTFORMAT_END"))
      {
        if (!this.method_289(contentFormatBuilder))
          this.method_85();
      }
    }

    private bool method_289(Class566 contentFormatBuilder)
    {
      switch (this.struct18_0.Code)
      {
        case 40:
          contentFormatBuilder.ContentFormat.method_5((double) this.struct18_0.Value);
          break;
        case 62:
          contentFormatBuilder.ContentFormat.method_3(DxfIndexedColorSet.smethod_15((short) this.struct18_0.Value));
          break;
        case 90:
          contentFormatBuilder.ContentFormat.ContentFormatPropertyOverrideFlags = (TableCellStylePropertyFlags) this.struct18_0.Value;
          break;
        case 91:
          contentFormatBuilder.ContentFormat.PropertyFlags = (TableCellStylePropertyFlags) this.struct18_0.Value;
          break;
        case 92:
          contentFormatBuilder.DataType = (ValueDataType) this.struct18_0.Value;
          break;
        case 93:
          contentFormatBuilder.DataUnitType = (ValueUnitType) this.struct18_0.Value;
          break;
        case 94:
          contentFormatBuilder.ContentFormat.method_2((CellAlignment) (int) this.struct18_0.Value);
          break;
        case 140:
          contentFormatBuilder.ContentFormat.method_6((double) this.struct18_0.Value);
          break;
        case 144:
          contentFormatBuilder.ContentFormat.method_1((double) this.struct18_0.Value);
          break;
        case 300:
          contentFormatBuilder.FormatString = (string) this.struct18_0.Value;
          break;
        case 340:
          DxfTextStyle textStyle = this.class375_0.method_4<DxfTextStyle>((ulong) this.struct18_0.Value);
          contentFormatBuilder.ContentFormat.method_0(textStyle);
          break;
        default:
          return false;
      }
      this.method_85();
      return true;
    }

    private void method_290(Class567 cellStyleBuilder)
    {
      cellStyleBuilder.CellStyle.HasMarginOverrides = true;
      this.method_85();
      while (this.struct18_0.Code != 309 || !((string) this.struct18_0.Value == "CELLMARGIN_END"))
      {
        if (!this.method_291(cellStyleBuilder))
          this.method_85();
      }
    }

    private bool method_291(Class567 cellStyleBuilder)
    {
      if (this.struct18_0.Code != 40)
        return false;
      cellStyleBuilder.method_1((double) this.struct18_0.Value);
      this.method_85();
      return true;
    }

    private void method_292(Class567 cellStyleBuilder)
    {
      DxfTableBorder border = cellStyleBuilder.method_0();
      border.HasData = true;
      this.method_85();
      while (this.struct18_0.Code != 309 || !((string) this.struct18_0.Value == "GRIDFORMAT_END"))
      {
        if (!this.method_293(border))
          this.method_85();
      }
    }

    private bool method_293(DxfTableBorder border)
    {
      switch (this.struct18_0.Code)
      {
        case 40:
          border.method_3((double) this.struct18_0.Value);
          break;
        case 62:
          border.SetColor(DxfIndexedColorSet.smethod_15((short) this.struct18_0.Value));
          break;
        case 90:
          border.PropertyOverrideFlags = (TableBorderPropertyFlags) this.struct18_0.Value;
          break;
        case 91:
          border.method_1((BorderType) (int) this.struct18_0.Value);
          break;
        case 92:
          border.SetLineWeight((short) (int) this.struct18_0.Value);
          break;
        case 93:
          border.method_2((int) this.struct18_0.Value == 0);
          break;
        case 340:
          DxfLineType lineType = this.class375_0.method_4<DxfLineType>((ulong) this.struct18_0.Value);
          border.method_0(lineType);
          break;
        default:
          return false;
      }
      this.method_85();
      return true;
    }

    private void method_294(Class567 cellStyleBuilder)
    {
      this.method_85();
      while (this.struct18_0.Code != 309 || !((string) this.struct18_0.Value == "CELLSTYLE_END"))
      {
        if (!this.method_295(cellStyleBuilder))
          this.method_85();
      }
    }

    private bool method_295(Class567 cellStyleBuilder)
    {
      switch (this.struct18_0.Code)
      {
        case 90:
          cellStyleBuilder.CellStyle.Id = (int) this.struct18_0.Value;
          break;
        case 91:
          cellStyleBuilder.CellStyle.CellType = (CellType) this.struct18_0.Value;
          break;
        case 300:
          cellStyleBuilder.CellStyle.Name = (string) this.struct18_0.Value;
          break;
        default:
          return false;
      }
      this.method_85();
      return true;
    }

    private void method_296(DxfSortEntsTable sortEntsTable)
    {
      Class260 objectBuilder = new Class260((DxfObject) sortEntsTable);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      sortEntsTable.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Unexpected group code " + (object) this.struct18_0.Code + ". Expecting subclass marker!");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbSortentsTable":
            this.method_297(objectBuilder, sortEntsTable);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_297(Class260 objectBuilder, DxfSortEntsTable sortEntsTable)
    {
      this.method_91("AcDbSortentsTable");
      this.method_85();
      DxfEntitySortWrapper entitySortWrapper = (DxfEntitySortWrapper) null;
      while (this.struct18_0.Code != 0)
      {
        this.method_298(sortEntsTable, ref entitySortWrapper);
        this.method_85();
      }
    }

    private void method_298(
      DxfSortEntsTable sortEntsTable,
      ref DxfEntitySortWrapper entitySortWrapper)
    {
      switch (this.struct18_0.Code)
      {
        case 5:
          if (entitySortWrapper == null)
            break;
          entitySortWrapper.SortHandle = DxfHandledObject.Parse((string) this.struct18_0.Value);
          entitySortWrapper = (DxfEntitySortWrapper) null;
          break;
        case 330:
          DxfHandledObject dxfHandledObject = this.class375_0.method_3((ulong) this.struct18_0.Value);
          DxfBlock dxfBlock = dxfHandledObject as DxfBlock;
          if (dxfBlock != null)
          {
            sortEntsTable.OwnerBlock = dxfBlock;
            break;
          }
          if (dxfHandledObject != null)
          {
            this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.WrongType, Severity.Warning, "ExpectedType", (object) typeof (DxfBlock))
            {
              Parameters = {
                {
                  "ObjectType",
                  (object) dxfHandledObject.GetType()
                },
                {
                  "Object",
                  (object) dxfHandledObject
                }
              }
            });
            break;
          }
          this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.UnresolvedReference, Severity.Warning, "Handle", this.struct18_0.Value));
          break;
        case 331:
          Class285 class285 = this.class375_0.method_6((ulong) this.struct18_0.Value);
          if (class285 != null)
          {
            entitySortWrapper = sortEntsTable.method_8(class285.Entity);
            break;
          }
          entitySortWrapper = (DxfEntitySortWrapper) null;
          break;
      }
    }

    private void method_299(DxfSpatialFilter spatialFilter)
    {
      Class260 objectBuilder = new Class260((DxfObject) spatialFilter);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      spatialFilter.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Unexpected group code " + (object) this.struct18_0.Code + ". Expecting subclass marker!");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbFilter":
            this.method_85();
            continue;
          case "AcDbSpatialFilter":
            this.method_300(objectBuilder, spatialFilter);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_300(Class260 objectBuilder, DxfSpatialFilter spatialFilter)
    {
      this.method_91("AcDbSpatialFilter");
      this.method_85();
      int mElemCounter = -1;
      WW.Math.Point2D pendingPoint = new WW.Math.Point2D();
      double[] mElem = new double[16];
      mElem[12] = 0.0;
      mElem[13] = 0.0;
      mElem[14] = 0.0;
      mElem[15] = 1.0;
      while (this.struct18_0.Code != 0)
      {
        this.method_301(spatialFilter, mElem, ref mElemCounter, ref pendingPoint);
        this.method_85();
      }
    }

    private void method_301(
      DxfSpatialFilter spatialFilter,
      double[] mElem,
      ref int mElemCounter,
      ref WW.Math.Point2D pendingPoint)
    {
      switch (this.struct18_0.Code)
      {
        case 10:
          pendingPoint.X = (double) this.struct18_0.Value;
          break;
        case 11:
          WW.Math.Point3D boundaryPlaneOrigin1 = spatialFilter.ClipBoundaryPlaneOrigin;
          boundaryPlaneOrigin1.X = (double) this.struct18_0.Value;
          spatialFilter.ClipBoundaryPlaneOrigin = boundaryPlaneOrigin1;
          break;
        case 20:
          pendingPoint.Y = (double) this.struct18_0.Value;
          spatialFilter.ClipBoundaryPoints.Add(pendingPoint);
          break;
        case 21:
          WW.Math.Point3D boundaryPlaneOrigin2 = spatialFilter.ClipBoundaryPlaneOrigin;
          boundaryPlaneOrigin2.Y = (double) this.struct18_0.Value;
          spatialFilter.ClipBoundaryPlaneOrigin = boundaryPlaneOrigin2;
          break;
        case 31:
          WW.Math.Point3D boundaryPlaneOrigin3 = spatialFilter.ClipBoundaryPlaneOrigin;
          boundaryPlaneOrigin3.Z = (double) this.struct18_0.Value;
          spatialFilter.ClipBoundaryPlaneOrigin = boundaryPlaneOrigin3;
          break;
        case 40:
          if (mElemCounter >= 0)
          {
            int index = mElemCounter % 12;
            mElem[index] = (double) this.struct18_0.Value;
            if (index == 11)
            {
              switch (mElemCounter / 12)
              {
                case 0:
                  spatialFilter.InverseInsertionTransform = new Matrix4D(mElem);
                  break;
                case 1:
                  spatialFilter.ClipBoundaryTransform = new Matrix4D(mElem);
                  break;
              }
            }
            ++mElemCounter;
            break;
          }
          if (!spatialFilter.FrontClippingPlaneDistance.HasValue)
            break;
          spatialFilter.FrontClippingPlaneDistance = new double?((double) this.struct18_0.Value);
          break;
        case 41:
          if (!spatialFilter.BackClippingPlaneDistance.HasValue)
            break;
          spatialFilter.BackClippingPlaneDistance = new double?((double) this.struct18_0.Value);
          break;
        case 71:
          spatialFilter.ClipBoundaryDisplayEnabled = (short) this.struct18_0.Value != (short) 0;
          break;
        case 72:
          if ((short) this.struct18_0.Value == (short) 0)
            break;
          spatialFilter.FrontClippingPlaneDistance = new double?(0.0);
          break;
        case 73:
          if ((short) this.struct18_0.Value != (short) 0)
            spatialFilter.BackClippingPlaneDistance = new double?(0.0);
          mElemCounter = 0;
          break;
        case 210:
          WW.Math.Vector3D boundaryPlaneNormal1 = spatialFilter.ClipBoundaryPlaneNormal;
          boundaryPlaneNormal1.X = (double) this.struct18_0.Value;
          spatialFilter.ClipBoundaryPlaneNormal = boundaryPlaneNormal1;
          break;
        case 220:
          WW.Math.Vector3D boundaryPlaneNormal2 = spatialFilter.ClipBoundaryPlaneNormal;
          boundaryPlaneNormal2.Y = (double) this.struct18_0.Value;
          spatialFilter.ClipBoundaryPlaneNormal = boundaryPlaneNormal2;
          break;
        case 230:
          WW.Math.Vector3D boundaryPlaneNormal3 = spatialFilter.ClipBoundaryPlaneNormal;
          boundaryPlaneNormal3.Z = (double) this.struct18_0.Value;
          spatialFilter.ClipBoundaryPlaneNormal = boundaryPlaneNormal3;
          break;
      }
    }

    private void method_302(DxfXRecord xrecord)
    {
      Class278 objectBuilder = new Class278(xrecord);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      xrecord.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Unexpected group code " + (object) this.struct18_0.Code + ". Expecting subclass marker!");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbXrecord":
            this.method_303(objectBuilder, xrecord);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_303(Class278 objectBuilder, DxfXRecord xrecord)
    {
      this.method_91("AcDbXrecord");
      this.method_85();
      bool parsedDuplicateRecordCloningFlag = false;
      while (!this.method_92("AcDbXrecord"))
      {
        if (this.struct18_0.Code != 1001)
        {
          if (!this.method_304(objectBuilder, xrecord, ref parsedDuplicateRecordCloningFlag))
            this.method_85();
        }
        else
        {
          while (!this.method_92("AcDbXrecord"))
          {
            if (!xrecord.method_6(this, (Class259) objectBuilder))
              this.method_85();
          }
          break;
        }
      }
    }

    private bool method_304(
      Class278 objectBuilder,
      DxfXRecord xrecord,
      ref bool parsedDuplicateRecordCloningFlag)
    {
      if (this.struct18_0.Code == 280 && !parsedDuplicateRecordCloningFlag)
      {
        parsedDuplicateRecordCloningFlag = true;
        xrecord.DuplicateRecordCloningFlag = (DuplicateRecordCloningFlag) this.struct18_0.Value;
        this.method_85();
        return true;
      }
      int code = this.struct18_0.Code;
      bool flag;
      if (this.struct18_0.Code >= 1 && this.struct18_0.Code <= 369 || this.struct18_0.Code >= 1000 && this.struct18_0.Code <= 1071 || this.struct18_0.Code >= 5000 && this.struct18_0.Code <= 5020)
      {
        flag = false;
        this.method_305(objectBuilder, xrecord);
      }
      else if (!(flag = xrecord.method_6(this, (Class259) objectBuilder)))
        this.method_305(objectBuilder, xrecord);
      return flag;
    }

    private void method_305(Class278 objectBuilder, DxfXRecord xrecord)
    {
      switch (Class820.smethod_2(this.struct18_0.Code))
      {
        case Enum5.const_5:
        case Enum5.const_7:
        case Enum5.const_8:
        case Enum5.const_9:
        case Enum5.const_14:
        case Enum5.const_15:
          int count = xrecord.Values.Count;
          xrecord.Values.Add(new DxfXRecordValue((short) this.struct18_0.Code, (object) null));
          ulong handle = (ulong) this.struct18_0.Value;
          objectBuilder.method_1(count, handle);
          break;
        case Enum5.const_13:
          short code = (short) this.struct18_0.Code;
          WW.Math.Point3D point3D = new WW.Math.Point3D();
          point3D.X = (double) this.struct18_0.Value;
          this.method_87((int) code);
          point3D.Y = (double) this.struct18_0.Value;
          this.method_87((int) code);
          point3D.Z = (double) this.struct18_0.Value;
          DxfXRecordValue dxfXrecordValue1 = new DxfXRecordValue(code, (object) point3D);
          xrecord.Values.Add(dxfXrecordValue1);
          break;
        default:
          DxfXRecordValue dxfXrecordValue2 = new DxfXRecordValue((short) this.struct18_0.Code, this.struct18_0.Value);
          xrecord.Values.Add(dxfXrecordValue2);
          break;
      }
    }

    private void method_306(DxfColor color)
    {
      Class260 objectBuilder = new Class260((DxfObject) color);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      color.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbColor":
            this.method_307(objectBuilder, color);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_307(Class260 objectBuilder, DxfColor color)
    {
      this.method_91("AcDbColor");
      this.method_85();
      while (!this.method_92("AcDbColor"))
      {
        if (!this.method_308(objectBuilder, color))
          this.method_85();
      }
    }

    private bool method_308(Class260 objectBuilder, DxfColor color)
    {
      switch (this.struct18_0.Code)
      {
        case 62:
          this.method_85();
          return true;
        case 420:
          int rgb = (int) this.struct18_0.Value;
          color.Color = Color.CreateFromRgb(rgb);
          goto case 62;
        case 430:
          string[] strArray = ((string) this.struct18_0.Value).Split('$');
          if (strArray != null && strArray.Length == 2)
          {
            color.Color = Color.smethod_1(color.Color.Data, strArray[0], strArray[1]);
            goto case 62;
          }
          else
            goto case 62;
        default:
          return color.method_6(this, (Class259) objectBuilder);
      }
    }

    private void method_309(DxfGroup group)
    {
      Class281 objectBuilder = new Class281(group);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      group.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbGroup":
            this.method_310(objectBuilder, group);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_310(Class281 objectBuilder, DxfGroup group)
    {
      this.method_91("AcDbGroup");
      this.method_85();
      while (!this.method_92("AcDbRasterImageDef"))
      {
        if (!this.method_311(objectBuilder, group))
          this.method_85();
      }
    }

    private bool method_311(Class281 objectBuilder, DxfGroup group)
    {
      switch (this.struct18_0.Code)
      {
        case 70:
          int num1 = (int) (short) this.struct18_0.Value;
          break;
        case 71:
          group.Selectable = (short) this.struct18_0.Value > (short) 0;
          break;
        case 300:
          group.Description = (string) this.struct18_0.Value;
          break;
        case 340:
          ulong num2 = (ulong) this.struct18_0.Value;
          objectBuilder.MemberHandles.Add(num2);
          break;
        default:
          return group.method_6(this, (Class259) objectBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_312(DxfImageDef imageDef)
    {
      Class260 objectBuilder = new Class260((DxfObject) imageDef);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      imageDef.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbRasterImageDef":
            this.method_313(objectBuilder, imageDef);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_313(Class260 objectBuilder, DxfImageDef imageDef)
    {
      this.method_91("AcDbRasterImageDef");
      this.method_85();
      while (!this.method_92("AcDbRasterImageDef"))
      {
        if (!this.method_314(objectBuilder, imageDef))
          this.method_85();
      }
    }

    private bool method_314(Class260 objectBuilder, DxfImageDef imageDef)
    {
      switch (this.struct18_0.Code)
      {
        case 1:
          imageDef.Filename = (string) this.struct18_0.Value;
          break;
        case 10:
          Size2D size1 = imageDef.Size;
          size1.X = (double) this.struct18_0.Value;
          imageDef.Size = size1;
          break;
        case 11:
          Size2D defaultPixelSize1 = imageDef.DefaultPixelSize;
          defaultPixelSize1.X = (double) this.struct18_0.Value;
          imageDef.DefaultPixelSize = defaultPixelSize1;
          break;
        case 20:
          Size2D size2 = imageDef.Size;
          size2.Y = (double) this.struct18_0.Value;
          imageDef.Size = size2;
          break;
        case 21:
          Size2D defaultPixelSize2 = imageDef.DefaultPixelSize;
          defaultPixelSize2.Y = (double) this.struct18_0.Value;
          imageDef.DefaultPixelSize = defaultPixelSize2;
          break;
        case 90:
          imageDef.ClassVersion = (int) this.struct18_0.Value;
          break;
        case 280:
          imageDef.ImageIsLoaded = DxfReader.smethod_7((byte) this.struct18_0.Value);
          break;
        case 281:
          imageDef.ResolutionUnits = (ResolutionUnits) this.struct18_0.Value;
          break;
        default:
          return imageDef.method_6(this, (Class259) objectBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_315(DxfLayout layout)
    {
      Class284 objectBuilder = new Class284(layout);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      layout.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbLayout":
            this.method_316(objectBuilder, layout);
            continue;
          case "AcDbPlotSettings":
            this.method_275((Class260) objectBuilder, (DxfPlotSettings) layout);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_316(Class284 objectBuilder, DxfLayout layout)
    {
      this.method_91("AcDbLayout");
      this.method_85();
      while (!this.method_92("AcDbLayout"))
      {
        if (!this.method_317(objectBuilder, layout))
          this.method_85();
      }
    }

    private bool method_317(Class284 objectBuilder, DxfLayout layout)
    {
      switch (this.struct18_0.Code)
      {
        case 1:
          layout.Name = (string) this.struct18_0.Value;
          break;
        case 10:
          Rectangle2D limits1 = layout.Limits;
          limits1.X1 = (double) this.struct18_0.Value;
          layout.Limits = limits1;
          break;
        case 11:
          Rectangle2D limits2 = layout.Limits;
          limits2.X2 = (double) this.struct18_0.Value;
          layout.Limits = limits2;
          break;
        case 12:
          WW.Math.Point3D insertionBasePoint1 = layout.InsertionBasePoint;
          insertionBasePoint1.X = (double) this.struct18_0.Value;
          layout.InsertionBasePoint = insertionBasePoint1;
          break;
        case 13:
          WW.Math.Point3D origin1 = layout.Ucs.Origin;
          origin1.X = (double) this.struct18_0.Value;
          layout.Ucs.Origin = origin1;
          break;
        case 14:
          WW.Math.Point3D minExtents1 = layout.MinExtents;
          minExtents1.X = (double) this.struct18_0.Value;
          layout.MinExtents = minExtents1;
          break;
        case 15:
          WW.Math.Point3D maxExtents1 = layout.MaxExtents;
          maxExtents1.X = (double) this.struct18_0.Value;
          layout.MaxExtents = maxExtents1;
          break;
        case 16:
          WW.Math.Vector3D xaxis1 = layout.Ucs.XAxis;
          xaxis1.X = (double) this.struct18_0.Value;
          layout.Ucs.XAxis = xaxis1;
          break;
        case 17:
          WW.Math.Vector3D yaxis1 = layout.Ucs.YAxis;
          yaxis1.X = (double) this.struct18_0.Value;
          layout.Ucs.YAxis = yaxis1;
          break;
        case 20:
          Rectangle2D limits3 = layout.Limits;
          limits3.Y1 = (double) this.struct18_0.Value;
          layout.Limits = limits3;
          break;
        case 21:
          Rectangle2D limits4 = layout.Limits;
          limits4.Y2 = (double) this.struct18_0.Value;
          layout.Limits = limits4;
          break;
        case 22:
          WW.Math.Point3D insertionBasePoint2 = layout.InsertionBasePoint;
          insertionBasePoint2.Y = (double) this.struct18_0.Value;
          layout.InsertionBasePoint = insertionBasePoint2;
          break;
        case 23:
          WW.Math.Point3D origin2 = layout.Ucs.Origin;
          origin2.Y = (double) this.struct18_0.Value;
          layout.Ucs.Origin = origin2;
          break;
        case 24:
          WW.Math.Point3D minExtents2 = layout.MinExtents;
          minExtents2.Y = (double) this.struct18_0.Value;
          layout.MinExtents = minExtents2;
          break;
        case 25:
          WW.Math.Point3D maxExtents2 = layout.MaxExtents;
          maxExtents2.Y = (double) this.struct18_0.Value;
          layout.MaxExtents = maxExtents2;
          break;
        case 26:
          WW.Math.Vector3D xaxis2 = layout.Ucs.XAxis;
          xaxis2.Y = (double) this.struct18_0.Value;
          layout.Ucs.XAxis = xaxis2;
          break;
        case 27:
          WW.Math.Vector3D yaxis2 = layout.Ucs.YAxis;
          yaxis2.Y = (double) this.struct18_0.Value;
          layout.Ucs.YAxis = yaxis2;
          break;
        case 32:
          WW.Math.Point3D insertionBasePoint3 = layout.InsertionBasePoint;
          insertionBasePoint3.Z = (double) this.struct18_0.Value;
          layout.InsertionBasePoint = insertionBasePoint3;
          break;
        case 33:
          WW.Math.Point3D origin3 = layout.Ucs.Origin;
          origin3.Z = (double) this.struct18_0.Value;
          layout.Ucs.Origin = origin3;
          break;
        case 34:
          WW.Math.Point3D minExtents3 = layout.MinExtents;
          minExtents3.Z = (double) this.struct18_0.Value;
          layout.MinExtents = minExtents3;
          break;
        case 35:
          WW.Math.Point3D maxExtents3 = layout.MaxExtents;
          maxExtents3.Z = (double) this.struct18_0.Value;
          layout.MaxExtents = maxExtents3;
          break;
        case 36:
          WW.Math.Vector3D xaxis3 = layout.Ucs.XAxis;
          xaxis3.Z = (double) this.struct18_0.Value;
          layout.Ucs.XAxis = xaxis3;
          break;
        case 37:
          WW.Math.Vector3D yaxis3 = layout.Ucs.YAxis;
          yaxis3.Z = (double) this.struct18_0.Value;
          layout.Ucs.YAxis = yaxis3;
          break;
        case 70:
          layout.Options = (LayoutOptions) this.struct18_0.Value;
          break;
        case 71:
          layout.TabOrder = (int) (short) this.struct18_0.Value;
          break;
        case 76:
          layout.UcsOrthographicType = (OrthographicType) (short) this.struct18_0.Value;
          break;
        case 146:
          layout.Ucs.Elevation = (double) this.struct18_0.Value;
          break;
        case 330:
          ulong handle1 = (ulong) this.struct18_0.Value;
          layout.OwnerBlock = this.method_125<DxfBlock>(handle1);
          objectBuilder.AssociatedBockRecordHandle = handle1;
          break;
        case 331:
          ulong handle2 = (ulong) this.struct18_0.Value;
          layout.LastActiveViewport = this.method_124(handle2);
          break;
        case 345:
        case 346:
          DxfUcs dxfUcs = this.method_125<DxfUcs>((ulong) this.struct18_0.Value);
          layout.Ucs = dxfUcs;
          break;
        default:
          return layout.method_6(this, (Class259) objectBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_318<T>() where T : DxfHandledObject, new()
    {
      T obj = new T();
      Class259 objectBuilder = obj.vmethod_9(FileFormat.Dxf);
      this.class375_0.ObjectBuilders.Add(objectBuilder);
      try
      {
        obj.method_5(this, objectBuilder);
        obj.Read(this, objectBuilder);
      }
      catch (DxfException ex)
      {
        this.class375_0.Messages.Add(new DxfMessage(DxfStatus.DxfReadError, Severity.Warning)
        {
          Parameters = {
            {
              "Class",
              (object) obj.GetType().FullName
            }
          }
        });
        this.class375_0.ObjectBuilders.Remove(objectBuilder);
        obj.Reference.Value = (IDxfHandledObject) null;
        this.method_356(0);
      }
    }

    private void method_319(DxfLinkedData linkedData)
    {
      Class260 objectBuilder = new Class260((DxfObject) linkedData);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      linkedData.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbLinkedData":
            this.method_320(objectBuilder, linkedData);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_320(Class260 objectBuilder, DxfLinkedData linkedData)
    {
      this.method_91("AcDbLinkedData");
      this.method_85();
      while (!this.method_92("AcDbLinkedData"))
      {
        if (!this.method_321(objectBuilder, linkedData))
          this.method_85();
      }
    }

    private bool method_321(Class260 objectBuilder, DxfLinkedData linkedData)
    {
      switch (this.struct18_0.Code)
      {
        case 1:
          linkedData.Name = (string) this.struct18_0.Value;
          break;
        case 300:
          linkedData.Description = (string) this.struct18_0.Value;
          break;
        default:
          return linkedData.method_6(this, (Class259) objectBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_322(DxfLinkedTableData linkedTableData)
    {
      Class274 objectBuilder = new Class274(linkedTableData);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      linkedTableData.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbLinkedTableData":
            this.method_323(objectBuilder, linkedTableData);
            continue;
          case "AcDbLinkedData":
            this.method_320((Class260) objectBuilder, (DxfLinkedData) linkedTableData);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_323(Class274 objectBuilder, DxfLinkedTableData linkedTableData)
    {
      this.method_91("AcDbLinkedTableData");
      this.method_85();
      int rowIndex = 0;
      int columnIndex = 0;
      while (!this.method_92("AcDbLinkedTableData"))
      {
        if (!this.method_324(objectBuilder, linkedTableData, ref rowIndex, ref columnIndex))
          this.method_85();
      }
    }

    private bool method_324(
      Class274 objectBuilder,
      DxfLinkedTableData linkedTableData,
      ref int rowIndex,
      ref int columnIndex)
    {
      switch (this.struct18_0.Code)
      {
        case 90:
          linkedTableData.ColumnCount = (int) this.struct18_0.Value;
          break;
        case 91:
          linkedTableData.RowCount = (int) this.struct18_0.Value;
          break;
        case 92:
          int num1 = (int) this.struct18_0.Value;
          break;
        case 300:
          if ((string) this.struct18_0.Value == "COLUMN")
          {
            this.method_325(objectBuilder, linkedTableData, columnIndex);
            ++columnIndex;
            break;
          }
          break;
        case 301:
          if ((string) this.struct18_0.Value == "ROW")
          {
            this.method_330(objectBuilder, linkedTableData, rowIndex);
            ++rowIndex;
            break;
          }
          break;
        case 360:
          long num2 = (long) (ulong) this.struct18_0.Value;
          break;
        default:
          return linkedTableData.method_6(this, (Class259) objectBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_325(
      Class274 objectBuilder,
      DxfLinkedTableData linkedTableData,
      int columnIndex)
    {
      this.method_85();
      DxfTableColumn column = linkedTableData.Columns[columnIndex];
      Class505 columnBuilder = new Class505(column);
      objectBuilder.ColumnBuilders.Add(columnBuilder);
      bool flag = false;
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 1)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "LINKEDTABLEDATACOLUMN_BEGIN":
              this.method_326(objectBuilder, columnBuilder, column);
              break;
            case "FORMATTEDTABLEDATACOLUMN_BEGIN":
              this.method_328(columnBuilder, column);
              break;
            case "TABLECOLUMN_BEGIN":
              this.method_329(columnBuilder, column);
              flag = true;
              break;
          }
        }
        if (flag)
          break;
        this.method_85();
      }
    }

    private void method_326(
      Class274 linkedTableDataBuilder,
      Class505 columnBuilder,
      DxfTableColumn column)
    {
      this.method_85();
      bool flag = false;
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 91:
            column.CustomData = (int) this.struct18_0.Value;
            break;
          case 300:
            column.Name = (string) this.struct18_0.Value;
            break;
          case 301:
            if ((string) this.struct18_0.Value == "CUSTOMDATA")
            {
              this.method_327(linkedTableDataBuilder, column.CustomDataCollection);
              break;
            }
            break;
          case 309:
            flag = (string) this.struct18_0.Value == "LINKEDTABLEDATACOLUMN_END";
            break;
        }
        if (flag)
          break;
        this.method_85();
      }
    }

    private void method_327(
      Class274 linkedTableDataBuilder,
      DxfTableCustomDataCollection customDataCollection)
    {
      this.method_85();
      string position = this.interface33_0.Position;
      if (this.struct18_0.Code != 1 || !((string) this.struct18_0.Value == "DATAMAP_BEGIN"))
        return;
      this.method_85();
      bool flag = false;
      int num = 0;
      int index1 = 0;
      DxfTableCustomData dxfTableCustomData = (DxfTableCustomData) null;
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 90:
            num = (int) this.struct18_0.Value;
            if (num > 0)
            {
              for (int index2 = 0; index2 < num; ++index2)
                customDataCollection.Add(new DxfTableCustomData());
              dxfTableCustomData = customDataCollection[0];
              break;
            }
            break;
          case 300:
            if (dxfTableCustomData != null)
            {
              dxfTableCustomData.Name = (string) this.struct18_0.Value;
              break;
            }
            break;
          case 301:
            if ((string) this.struct18_0.Value == "DATAMAP_VALUE")
            {
              Class999 valueBuilder = new Class999(dxfTableCustomData == null ? new DxfValue() : dxfTableCustomData.Value);
              this.method_153(valueBuilder);
              linkedTableDataBuilder.PrerequisiteBuilders.Add((Interface10) valueBuilder);
            }
            ++index1;
            dxfTableCustomData = index1 >= num ? (DxfTableCustomData) null : customDataCollection[index1];
            break;
          case 309:
            flag = (string) this.struct18_0.Value == "DATAMAP_END";
            break;
        }
        if (flag)
          break;
        this.method_85();
      }
    }

    private void method_328(Class505 columnBuilder, DxfTableColumn column)
    {
      this.method_85();
      if (this.struct18_0.Code != 300 || !((string) this.struct18_0.Value == "COLUMNTABLEFORMAT"))
        return;
      this.method_85();
      bool flag = false;
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 1:
            if ((string) this.struct18_0.Value == "TABLEFORMAT_BEGIN")
            {
              this.method_286(new Class567(column.CellStyleOverrides));
              break;
            }
            break;
          case 309:
            flag = (string) this.struct18_0.Value == "FORMATTEDTABLEDATACOLUMN_END";
            break;
        }
        if (flag)
          break;
        this.method_85();
      }
    }

    private void method_329(Class505 columnBuilder, DxfTableColumn column)
    {
      this.method_85();
      bool flag = false;
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 40:
            column.Width = (double) this.struct18_0.Value;
            break;
          case 90:
            columnBuilder.CellStyleId = (int) this.struct18_0.Value;
            break;
          case 309:
            flag = (string) this.struct18_0.Value == "TABLECOLUMN_END";
            break;
        }
        if (flag)
          break;
        this.method_85();
      }
    }

    private void method_330(
      Class274 objectBuilder,
      DxfLinkedTableData linkedTableData,
      int rowIndex)
    {
      this.method_85();
      if (this.struct18_0.Code != 1)
        return;
      DxfTableRow row = linkedTableData.Rows[rowIndex];
      Class1050 rowBuilder = new Class1050(row);
      objectBuilder.RowBuilders.Add(rowBuilder);
      bool flag = false;
      while (this.struct18_0.Code == 1)
      {
        switch ((string) this.struct18_0.Value)
        {
          case "LINKEDTABLEDATAROW_BEGIN":
            this.method_331(objectBuilder, rowBuilder, row);
            break;
          case "FORMATTEDTABLEDATAROW_BEGIN":
            this.method_332(rowBuilder, row);
            break;
          case "TABLEROW_BEGIN":
            this.method_333(rowBuilder, row);
            flag = true;
            break;
        }
        if (flag)
          break;
        this.method_85();
      }
    }

    private void method_331(Class274 objectBuilder, Class1050 rowBuilder, DxfTableRow row)
    {
      this.method_85();
      bool flag = false;
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 90:
            int num = (int) this.struct18_0.Value;
            break;
          case 91:
            row.CustomData = (int) this.struct18_0.Value;
            break;
          case 300:
            if ((string) this.struct18_0.Value == "CELL")
            {
              DxfTableCell cell = rowBuilder.method_0();
              Class506 cellBuilder = new Class506(cell);
              objectBuilder.CellBuilders.Add(cellBuilder);
              this.method_334(objectBuilder, cellBuilder, cell);
              break;
            }
            break;
          case 301:
            if ((string) this.struct18_0.Value == "CUSTOMDATA")
            {
              this.method_327(objectBuilder, row.CustomDataCollection);
              break;
            }
            break;
          case 309:
            flag = (string) this.struct18_0.Value == "LINKEDTABLEDATAROW_END";
            break;
        }
        if (flag)
          break;
        this.method_85();
      }
    }

    private void method_332(Class1050 rowBuilder, DxfTableRow row)
    {
      this.method_85();
      bool flag = false;
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 300:
            if ((string) this.struct18_0.Value == "ROWTABLEFORMAT")
            {
              this.method_286(new Class567(row.CellStyleOverrides));
              break;
            }
            break;
          case 309:
            flag = (string) this.struct18_0.Value == "TABLEFORMAT_END" || (string) this.struct18_0.Value == "FORMATTEDTABLEDATAROW_END";
            break;
        }
        if (flag)
          break;
        this.method_85();
      }
    }

    private void method_333(Class1050 rowBuilder, DxfTableRow row)
    {
      this.method_85();
      bool flag = false;
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 40:
            row.Height = (double) this.struct18_0.Value;
            break;
          case 90:
            rowBuilder.CellStyleId = (int) this.struct18_0.Value;
            break;
          case 309:
            flag = (string) this.struct18_0.Value == "TABLEROW_END";
            break;
        }
        if (flag)
          break;
        this.method_85();
      }
    }

    private void method_334(
      Class274 linkedTableDataBuilder,
      Class506 cellBuilder,
      DxfTableCell cell)
    {
      this.method_85();
      bool flag = false;
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 1)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "LINKEDTABLEDATACELL_BEGIN":
              this.method_335(linkedTableDataBuilder, cellBuilder, cell);
              break;
            case "FORMATTEDTABLEDATACELL_BEGIN":
              this.method_339(linkedTableDataBuilder, cellBuilder, cell);
              break;
            case "TABLECELL_BEGIN":
              this.method_340(cellBuilder, cell);
              flag = true;
              break;
          }
        }
        if (flag)
          break;
        this.method_85();
      }
    }

    private void method_335(
      Class274 linkedTableDataBuilder,
      Class506 cellBuilder,
      DxfTableCell cell)
    {
      this.method_85();
      bool flag = false;
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 90:
            cell.StateFlags = (TableCellStateFlags) this.struct18_0.Value;
            break;
          case 91:
            cell.CustomData = (int) this.struct18_0.Value;
            break;
          case 93:
            int num1 = (int) this.struct18_0.Value;
            break;
          case 94:
            int num2 = (int) this.struct18_0.Value;
            break;
          case 95:
            int num3 = (int) this.struct18_0.Value;
            break;
          case 96:
            int num4 = (int) this.struct18_0.Value;
            break;
          case 300:
            cell.ToolTip = (string) this.struct18_0.Value;
            break;
          case 301:
            if ((string) this.struct18_0.Value == "CUSTOMDATA")
            {
              this.method_327(linkedTableDataBuilder, cell.CustomDataCollection);
              break;
            }
            break;
          case 302:
            if ((string) this.struct18_0.Value == "CONTENT")
            {
              DxfTableCellContent tableCellContent = new DxfTableCellContent();
              Class568 cellContentBuilder = new Class568(tableCellContent);
              cellBuilder.ChildBuilders.Add((Interface10) cellContentBuilder);
              this.method_336(linkedTableDataBuilder, cellContentBuilder, tableCellContent);
              cell.Contents.Add(tableCellContent);
              break;
            }
            break;
          case 309:
            flag = (string) this.struct18_0.Value == "LINKEDTABLEDATACELL_END";
            break;
          case 340:
            long num5 = (long) (ulong) this.struct18_0.Value;
            break;
        }
        if (flag)
          break;
        this.method_85();
      }
    }

    private void method_336(
      Class274 linkedTableDataBuilder,
      Class568 cellContentBuilder,
      DxfTableCellContent cellContent)
    {
      this.method_85();
      bool flag = false;
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 1:
            switch ((string) this.struct18_0.Value)
            {
              case "CELLCONTENT_BEGIN":
                this.method_337(linkedTableDataBuilder, cellContentBuilder, cellContent);
                break;
              case "FORMATTEDCELLCONTENT_BEGIN":
                this.method_338(linkedTableDataBuilder, cellContentBuilder, cellContent);
                flag = true;
                break;
            }
          case 300:
            if ((string) this.struct18_0.Value == "VALUE")
            {
              Class999 valueBuilder = new Class999(cellContent.Value);
              this.method_153(valueBuilder);
              linkedTableDataBuilder.PrerequisiteBuilders.Add((Interface10) valueBuilder);
              break;
            }
            break;
        }
        if (flag)
          break;
        this.method_85();
      }
    }

    private void method_337(
      Class274 linkedTableDataBuilder,
      Class568 cellContentBuilder,
      DxfTableCellContent cellContent)
    {
      this.method_85();
      bool flag = false;
      DxfTableAttribute attribute = (DxfTableAttribute) null;
      Class331 attributeBuilder = (Class331) null;
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 90:
            cellContent.ContentType = (TableCellContentType) this.struct18_0.Value;
            break;
          case 91:
            int num1 = (int) this.struct18_0.Value;
            break;
          case 92:
            int num2 = (int) this.struct18_0.Value;
            attribute = (DxfTableAttribute) null;
            attributeBuilder = (Class331) null;
            break;
          case 300:
            if ((string) this.struct18_0.Value == "VALUE")
            {
              Class999 valueBuilder = new Class999(cellContent.Value);
              this.method_153(valueBuilder);
              linkedTableDataBuilder.PrerequisiteBuilders.Add((Interface10) valueBuilder);
              break;
            }
            break;
          case 301:
            if (attribute == null)
            {
              attribute = new DxfTableAttribute();
              cellContent.Attributes.Add(attribute);
              attributeBuilder = new Class331(attribute);
              cellContentBuilder.method_0(attributeBuilder);
            }
            attribute.Value = (string) this.struct18_0.Value;
            break;
          case 309:
            flag = (string) this.struct18_0.Value == "CELLCONTENT_END";
            break;
          case 330:
            if (attribute == null)
            {
              attribute = new DxfTableAttribute();
              cellContent.Attributes.Add(attribute);
              attributeBuilder = new Class331(attribute);
              cellContentBuilder.method_0(attributeBuilder);
            }
            attributeBuilder.AttributeDefinitionHandle = (ulong) this.struct18_0.Value;
            break;
          case 340:
            cellContentBuilder.ValueObjectHandle = (ulong) this.struct18_0.Value;
            break;
        }
        if (flag)
          break;
        this.method_85();
      }
    }

    private void method_338(
      Class274 linkedTableDataBuilder,
      Class568 cellContentBuilder,
      DxfTableCellContent cellContent)
    {
      this.method_85();
      bool flag = false;
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 170:
            cellContent.Format.DataFlags = (short) this.struct18_0.Value;
            break;
          case 300:
            if ((string) this.struct18_0.Value == "CONTENTFORMAT")
            {
              this.method_85();
              if (this.struct18_0.Code == 1 && (string) this.struct18_0.Value == "CONTENTFORMAT_BEGIN")
              {
                Class566 contentFormatBuilder = new Class566(cellContent.Format);
                this.method_288(contentFormatBuilder);
                linkedTableDataBuilder.PrerequisiteBuilders.Add((Interface10) contentFormatBuilder);
                break;
              }
              break;
            }
            break;
          case 309:
            flag = (string) this.struct18_0.Value == "FORMATTEDCELLCONTENT_END";
            break;
        }
        if (flag)
          break;
        this.method_85();
      }
    }

    private void method_339(
      Class274 linkedTableDataBuilder,
      Class506 cellBuilder,
      DxfTableCell cell)
    {
      this.method_85();
      bool flag = false;
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 300:
            if ((string) this.struct18_0.Value == "CELLTABLEFORMAT")
            {
              Class567 cellStyleBuilder = new Class567(cell.CellStyleOverrides);
              this.method_284(cellStyleBuilder);
              linkedTableDataBuilder.PrerequisiteBuilders.Add((Interface10) cellStyleBuilder);
              continue;
            }
            break;
          case 309:
            flag = (string) this.struct18_0.Value == "FORMATTEDTABLEDATACELL_END";
            break;
        }
        if (flag)
          break;
        this.method_85();
      }
    }

    private void method_340(Class506 cellBuilder, DxfTableCell cell)
    {
      this.method_85();
      bool flag1 = false;
      bool flag2 = true;
      while (this.struct18_0.Code != 0)
      {
        switch (this.struct18_0.Code)
        {
          case 40:
            cell.UnknownDxfGroup40 = (double) this.struct18_0.Value;
            break;
          case 41:
            cell.UnknownDxfGroup41 = (double) this.struct18_0.Value;
            break;
          case 90:
            cellBuilder.CellStyleId = (int) this.struct18_0.Value;
            break;
          case 91:
            if (flag2)
              cell.UnknownDxfGroup91A = (int) this.struct18_0.Value;
            else
              cell.UnknownDxfGroup91B = (int) this.struct18_0.Value;
            flag2 = !flag2;
            break;
          case 92:
            cell.GeometryDataFlags = (int) this.struct18_0.Value;
            break;
          case 309:
            flag1 = (string) this.struct18_0.Value == "TABLECELL_END";
            break;
          case 330:
            cellBuilder.UnknownObjectHandle = (ulong) this.struct18_0.Value;
            break;
        }
        if (flag1)
          break;
        this.method_85();
      }
    }

    private void method_341(DxfFormattedTableData formattedTableData)
    {
      Class274 objectBuilder = new Class274((DxfLinkedTableData) formattedTableData);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      formattedTableData.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbFormattedTableData":
            this.method_342((Class260) objectBuilder, formattedTableData);
            continue;
          case "AcDbLinkedTableData":
            this.method_323(objectBuilder, (DxfLinkedTableData) formattedTableData);
            continue;
          case "AcDbLinkedData":
            this.method_320((Class260) objectBuilder, (DxfLinkedData) formattedTableData);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_342(Class260 objectBuilder, DxfFormattedTableData formattedTableData)
    {
      DxfTableCellRange mergedCellRange = (DxfTableCellRange) null;
      this.method_91("AcDbFormattedTableData");
      this.method_85();
      while (!this.method_92("AcDbFormattedTableData"))
      {
        if (!this.method_343(objectBuilder, formattedTableData, ref mergedCellRange))
          this.method_85();
      }
    }

    private bool method_343(
      Class260 objectBuilder,
      DxfFormattedTableData formattedTableData,
      ref DxfTableCellRange mergedCellRange)
    {
      switch (this.struct18_0.Code)
      {
        case 90:
          int num = (int) this.struct18_0.Value;
          break;
        case 91:
          if (mergedCellRange == null)
          {
            mergedCellRange = new DxfTableCellRange();
            formattedTableData.MergedCellRanges.Add(mergedCellRange);
          }
          mergedCellRange.TopRowIndex = (int) this.struct18_0.Value;
          break;
        case 92:
          if (mergedCellRange == null)
          {
            mergedCellRange = new DxfTableCellRange();
            formattedTableData.MergedCellRanges.Add(mergedCellRange);
          }
          mergedCellRange.LeftColumnIndex = (int) this.struct18_0.Value;
          break;
        case 93:
          if (mergedCellRange == null)
          {
            mergedCellRange = new DxfTableCellRange();
            formattedTableData.MergedCellRanges.Add(mergedCellRange);
          }
          mergedCellRange.BottomRowIndex = (int) this.struct18_0.Value;
          break;
        case 94:
          if (mergedCellRange == null)
          {
            mergedCellRange = new DxfTableCellRange();
            formattedTableData.MergedCellRanges.Add(mergedCellRange);
          }
          mergedCellRange.RightColumnIndex = (int) this.struct18_0.Value;
          mergedCellRange = (DxfTableCellRange) null;
          break;
        case 300:
          if ((string) this.struct18_0.Value == "TABLEFORMAT")
          {
            this.method_284(new Class567(formattedTableData.CellStyleOverrides));
            return true;
          }
          break;
        default:
          return formattedTableData.method_6(this, (Class259) objectBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_344(DxfTableContent tableContent)
    {
      Class275 objectBuilder = new Class275(tableContent);
      this.class375_0.ObjectBuilders.Add((Class259) objectBuilder);
      tableContent.method_5(this, (Class259) objectBuilder);
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) this.struct18_0.Value)
        {
          case "AcDbTableContent":
            this.method_345(objectBuilder, tableContent);
            continue;
          case "AcDbFormattedTableData":
            this.method_342((Class260) objectBuilder, (DxfFormattedTableData) tableContent);
            continue;
          case "AcDbLinkedTableData":
            this.method_323((Class274) objectBuilder, (DxfLinkedTableData) tableContent);
            continue;
          case "AcDbLinkedData":
            this.method_320((Class260) objectBuilder, (DxfLinkedData) tableContent);
            continue;
          default:
            this.method_85();
            continue;
        }
      }
    }

    private void method_345(Class275 objectBuilder, DxfTableContent tableContent)
    {
      this.method_91("AcDbTableContent");
      this.method_85();
      while (!this.method_92("AcDbTableContent"))
      {
        if (!this.method_346(objectBuilder, tableContent))
          this.method_85();
      }
    }

    private bool method_346(Class275 objectBuilder, DxfTableContent tableContent)
    {
      if (this.struct18_0.Code != 340)
        return tableContent.method_6(this, (Class259) objectBuilder);
      objectBuilder.TableStyleHandle = (ulong) this.struct18_0.Value;
      this.method_85();
      return true;
    }

    private void method_347()
    {
      this.method_85();
      Class741 dataStore;
      new Class741.Class742().Read(out dataStore, this);
      this.class375_0.DataStore = dataStore;
    }

    private void method_348(DxfViewport viewport)
    {
      Class308 entityBuilder = new Class308(viewport);
      this.class375_0.ViewportBuilders.Add(entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbViewport":
              this.method_349(entityBuilder, viewport);
              continue;
            case "AcDbEntity":
              this.method_132((Class285) entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_350(entityBuilder, viewport))
          this.method_85();
      }
    }

    private void method_349(Class308 entityBuilder, DxfViewport viewport)
    {
      this.method_91("AcDbViewport");
      this.method_85();
      while (!this.method_92("AcDbViewport"))
      {
        if (!this.method_350(entityBuilder, viewport))
          this.method_85();
      }
    }

    private bool method_350(Class308 entityBuilder, DxfViewport viewport)
    {
      switch (this.struct18_0.Code)
      {
        case 10:
          WW.Math.Point3D center1 = viewport.Center;
          center1.X = (double) this.struct18_0.Value;
          viewport.Center = center1;
          break;
        case 20:
          WW.Math.Point3D center2 = viewport.Center;
          center2.Y = (double) this.struct18_0.Value;
          viewport.Center = center2;
          break;
        case 30:
          WW.Math.Point3D center3 = viewport.Center;
          center3.Z = (double) this.struct18_0.Value;
          viewport.Center = center3;
          break;
        case 40:
          Size2D size1 = viewport.Size;
          size1.X = (double) this.struct18_0.Value;
          viewport.Size = size1;
          break;
        case 41:
          Size2D size2 = viewport.Size;
          size2.Y = (double) this.struct18_0.Value;
          viewport.Size = size2;
          break;
        case 68:
          entityBuilder.Status = new int?((int) short.Parse(this.struct18_0.ValueString, (IFormatProvider) CultureInfo.InvariantCulture));
          break;
        case 69:
          entityBuilder.Id = new int?((int) (short) this.struct18_0.Value);
          break;
        default:
          return this.method_133((Class285) entityBuilder);
      }
      this.method_85();
      return true;
    }

    private void method_351(DxfViewport viewport)
    {
      Class308 entityBuilder = new Class308(viewport);
      this.class375_0.ViewportBuilders.Add(entityBuilder);
      this.method_85();
      while (this.struct18_0.Code != 0)
      {
        if (this.struct18_0.Code == 100)
        {
          switch ((string) this.struct18_0.Value)
          {
            case "AcDbViewport":
              this.method_352(entityBuilder, viewport);
              continue;
            case "AcDbEntity":
              this.method_132((Class285) entityBuilder);
              continue;
            default:
              this.method_85();
              continue;
          }
        }
        else if (!this.method_353(entityBuilder, viewport))
          this.method_85();
      }
    }

    private void method_352(Class308 entityBuilder, DxfViewport viewport)
    {
      this.method_91("AcDbViewport");
      this.method_85();
      while (!this.method_92("AcDbViewport"))
      {
        if (!this.method_353(entityBuilder, viewport))
          this.method_85();
      }
    }

    private bool method_353(Class308 entityBuilder, DxfViewport viewport)
    {
      switch (this.struct18_0.Code)
      {
        case 1:
          viewport.PlotStyleSheetName = (string) this.struct18_0.Value;
          break;
        case 10:
          WW.Math.Point3D center1 = viewport.Center;
          center1.X = (double) this.struct18_0.Value;
          viewport.Center = center1;
          break;
        case 12:
          WW.Math.Point2D viewCenter1 = viewport.ViewCenter;
          viewCenter1.X = (double) this.struct18_0.Value;
          viewport.ViewCenter = viewCenter1;
          break;
        case 13:
          WW.Math.Point2D snapBasePoint1 = viewport.SnapBasePoint;
          snapBasePoint1.X = (double) this.struct18_0.Value;
          viewport.SnapBasePoint = snapBasePoint1;
          break;
        case 14:
          Vector2D snapSpacing1 = viewport.SnapSpacing;
          snapSpacing1.X = (double) this.struct18_0.Value;
          viewport.SnapSpacing = snapSpacing1;
          break;
        case 15:
          Vector2D gridSpacing1 = viewport.GridSpacing;
          gridSpacing1.X = (double) this.struct18_0.Value;
          viewport.GridSpacing = gridSpacing1;
          break;
        case 16:
          WW.Math.Vector3D direction1 = viewport.Direction;
          direction1.X = (double) this.struct18_0.Value;
          viewport.Direction = direction1;
          break;
        case 17:
          WW.Math.Point3D target1 = viewport.Target;
          target1.X = (double) this.struct18_0.Value;
          viewport.Target = target1;
          break;
        case 20:
          WW.Math.Point3D center2 = viewport.Center;
          center2.Y = (double) this.struct18_0.Value;
          viewport.Center = center2;
          break;
        case 22:
          WW.Math.Point2D viewCenter2 = viewport.ViewCenter;
          viewCenter2.Y = (double) this.struct18_0.Value;
          viewport.ViewCenter = viewCenter2;
          break;
        case 23:
          WW.Math.Point2D snapBasePoint2 = viewport.SnapBasePoint;
          snapBasePoint2.Y = (double) this.struct18_0.Value;
          viewport.SnapBasePoint = snapBasePoint2;
          break;
        case 24:
          Vector2D snapSpacing2 = viewport.SnapSpacing;
          snapSpacing2.Y = (double) this.struct18_0.Value;
          viewport.SnapSpacing = snapSpacing2;
          break;
        case 25:
          Vector2D gridSpacing2 = viewport.GridSpacing;
          gridSpacing2.Y = (double) this.struct18_0.Value;
          viewport.GridSpacing = gridSpacing2;
          break;
        case 26:
          WW.Math.Vector3D direction2 = viewport.Direction;
          direction2.Y = (double) this.struct18_0.Value;
          viewport.Direction = direction2;
          break;
        case 27:
          WW.Math.Point3D target2 = viewport.Target;
          target2.Y = (double) this.struct18_0.Value;
          viewport.Target = target2;
          break;
        case 30:
          WW.Math.Point3D center3 = viewport.Center;
          center3.Z = (double) this.struct18_0.Value;
          viewport.Center = center3;
          break;
        case 36:
          WW.Math.Vector3D direction3 = viewport.Direction;
          direction3.Z = (double) this.struct18_0.Value;
          viewport.Direction = direction3;
          break;
        case 37:
          WW.Math.Point3D target3 = viewport.Target;
          target3.Z = (double) this.struct18_0.Value;
          viewport.Target = target3;
          break;
        case 40:
          Size2D size1 = viewport.Size;
          size1.X = (double) this.struct18_0.Value;
          viewport.Size = size1;
          break;
        case 41:
          Size2D size2 = viewport.Size;
          size2.Y = (double) this.struct18_0.Value;
          viewport.Size = size2;
          break;
        case 42:
          viewport.LensLength = (double) this.struct18_0.Value;
          break;
        case 43:
          viewport.FrontClipPlaneZValue = (double) this.struct18_0.Value;
          break;
        case 44:
          viewport.BackClipPlaneZValue = (double) this.struct18_0.Value;
          break;
        case 45:
          viewport.ViewHeight = (double) this.struct18_0.Value;
          break;
        case 50:
          viewport.SnapAngle = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 51:
          viewport.TwistAngle = (double) this.struct18_0.Value * (System.Math.PI / 180.0);
          break;
        case 61:
          viewport.MajorGridLineFrequency = (short) this.struct18_0.Value;
          break;
        case 63:
          viewport.AmbientLightColor = Color.CreateFromColorIndex((short) this.struct18_0.Value);
          break;
        case 68:
          entityBuilder.Status = new int?((int) short.Parse(this.struct18_0.ValueString, (IFormatProvider) CultureInfo.InvariantCulture));
          break;
        case 69:
          entityBuilder.Id = new int?((int) (short) this.struct18_0.Value);
          break;
        case 71:
          short num1 = (short) this.struct18_0.Value;
          viewport.UcsPerViewport = num1 == (short) 1;
          break;
        case 72:
          viewport.CircleZoomPercentage = (double) (short) this.struct18_0.Value;
          break;
        case 74:
          short num2 = (short) this.struct18_0.Value;
          viewport.DisplayUcsIcon = num2 == (short) 1;
          break;
        case 79:
          viewport.UcsOrthographicType = (OrthographicType) (short) this.struct18_0.Value;
          break;
        case 90:
          viewport.StatusFlags = (ViewportStatusFlags) this.struct18_0.Value;
          break;
        case 110:
          WW.Math.Point3D origin1 = viewport.Ucs.Origin;
          origin1.X = (double) this.struct18_0.Value;
          viewport.Ucs.Origin = origin1;
          break;
        case 111:
          WW.Math.Vector3D xaxis1 = viewport.Ucs.XAxis;
          xaxis1.X = (double) this.struct18_0.Value;
          viewport.Ucs.XAxis = xaxis1;
          break;
        case 112:
          WW.Math.Vector3D yaxis1 = viewport.Ucs.YAxis;
          yaxis1.X = (double) this.struct18_0.Value;
          viewport.Ucs.YAxis = yaxis1;
          break;
        case 120:
          WW.Math.Point3D origin2 = viewport.Ucs.Origin;
          origin2.Y = (double) this.struct18_0.Value;
          viewport.Ucs.Origin = origin2;
          break;
        case 121:
          WW.Math.Vector3D xaxis2 = viewport.Ucs.XAxis;
          xaxis2.Y = (double) this.struct18_0.Value;
          viewport.Ucs.XAxis = xaxis2;
          break;
        case 122:
          WW.Math.Vector3D yaxis2 = viewport.Ucs.YAxis;
          yaxis2.Y = (double) this.struct18_0.Value;
          viewport.Ucs.YAxis = yaxis2;
          break;
        case 130:
          WW.Math.Point3D origin3 = viewport.Ucs.Origin;
          origin3.Z = (double) this.struct18_0.Value;
          viewport.Ucs.Origin = origin3;
          break;
        case 131:
          WW.Math.Vector3D xaxis3 = viewport.Ucs.XAxis;
          xaxis3.Z = (double) this.struct18_0.Value;
          viewport.Ucs.XAxis = xaxis3;
          break;
        case 132:
          WW.Math.Vector3D yaxis3 = viewport.Ucs.YAxis;
          yaxis3.Z = (double) this.struct18_0.Value;
          viewport.Ucs.YAxis = yaxis3;
          break;
        case 141:
          viewport.Brightness = (double) this.struct18_0.Value;
          break;
        case 142:
          viewport.Constrast = (double) this.struct18_0.Value;
          break;
        case 146:
          viewport.Ucs.Elevation = (double) this.struct18_0.Value;
          break;
        case 170:
          viewport.ShadePlotMode = (ShadePlotMode) this.struct18_0.Value;
          break;
        case 281:
          viewport.RenderMode = (RenderMode) this.struct18_0.Value;
          break;
        case 282:
          viewport.DefaultLightingType = (LightingType) this.struct18_0.Value;
          break;
        case 292:
          viewport.UseDefaultLighting = (bool) this.struct18_0.Value;
          break;
        case 331:
        case 341:
          ulong handle1 = (ulong) this.struct18_0.Value;
          DxfHandledObject dxfHandledObject = this.method_124(handle1);
          if (dxfHandledObject == null)
          {
            this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.UnresolvedReference, Severity.Warning)
            {
              Parameters = {
                {
                  "Type",
                  (object) "VIEWPORT"
                },
                {
                  "Handle",
                  (object) handle1
                }
              }
            });
            break;
          }
          if (dxfHandledObject is DxfLayer)
          {
            DxfLayer dxfLayer = (DxfLayer) dxfHandledObject;
            viewport.FrozenLayers.Add(dxfLayer);
            break;
          }
          this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.WrongType, Severity.Error)
          {
            Parameters = {
              {
                "Handle",
                (object) handle1
              },
              {
                "Type",
                (object) dxfHandledObject.GetType()
              },
              {
                "ExpectedType",
                (object) typeof (DxfLayer)
              }
            }
          });
          break;
        case 340:
          ulong second = (ulong) this.struct18_0.Value;
          this.list_12.Add(new Pair<DxfViewport, ulong>(viewport, second));
          break;
        case 345:
        case 346:
          ulong handle2 = (ulong) this.struct18_0.Value;
          if (handle2 != 0UL)
          {
            DxfUcs dxfUcs = this.method_125<DxfUcs>(handle2);
            if (dxfUcs != null)
            {
              viewport.Ucs = dxfUcs;
              break;
            }
            break;
          }
          break;
        default:
          return this.method_133((Class285) entityBuilder);
      }
      this.method_85();
      return true;
    }

    private Encoding method_354()
    {
      this.method_359(Encodings.GetEncoding(this.int_2));
      this.method_355(Class824.struct18_0);
      this.method_85();
      Struct18 struct18_1 = new Struct18(9, (object) "$DWGCODEPAGE");
      Struct18 struct18_2 = new Struct18(9, (object) "$ACADVER");
      Encoding encoding = (Encoding) null;
      if (this.struct18_0 == Class824.struct18_2)
      {
        this.method_85();
        while (this.struct18_0 != Class824.struct18_1)
        {
          if (!(this.struct18_0 == struct18_1))
          {
            if (this.struct18_0 == struct18_2)
            {
              this.method_85();
              if (DxfUtil.smethod_57((string) this.struct18_0.Value) >= DxfVersion.Dxf21)
              {
                encoding = (Encoding) new UTF8Encoding(false);
                break;
              }
            }
            this.method_85();
          }
          else
          {
            this.method_85();
            int codePage = (int) DxfHeader.GetDrawingCodePage((string) this.struct18_0.Value);
            if (codePage == 0)
              codePage = this.int_2;
            encoding = Encodings.GetEncoding(codePage);
            break;
          }
        }
      }
      this.interface33_0 = (Interface33) null;
      if (encoding == null)
        encoding = Encodings.GetEncoding(this.int_2);
      return encoding;
    }

    private bool method_355(Struct18 group)
    {
      bool flag;
      for (flag = this.struct18_0 == group; !flag && this.struct18_0 != Struct18.struct18_0; flag = this.struct18_0 == group)
        this.method_85();
      return flag;
    }

    private bool method_356(int groupCode)
    {
      bool flag;
      for (flag = this.struct18_0.Code == groupCode; !flag && this.struct18_0 != Struct18.struct18_0; flag = this.struct18_0.Code == groupCode)
        this.method_85();
      return flag;
    }

    private bool method_357(Struct18 group)
    {
      bool flag;
      for (flag = this.struct18_0 == group; !flag && (this.struct18_0 != Struct18.struct18_0 && this.struct18_0 != Class824.struct18_27); flag = this.struct18_0 == group)
        this.method_85();
      return flag;
    }

    private void method_358(Stream stream)
    {
      this.bool_2 = false;
      this.bool_3 = false;
      int length = Class1018.byte_1.Length;
      byte[] buffer = new byte[length];
      if (stream.Read(buffer, 0, length) == length)
      {
        this.bool_2 = true;
        for (int index = 0; index < length; ++index)
        {
          if ((int) buffer[index] != (int) Class1018.byte_1[index])
          {
            this.bool_2 = false;
            break;
          }
        }
        if (this.bool_2 && stream.ReadByte() != -1)
        {
          switch (stream.ReadByte())
          {
            case -1:
            case 0:
              break;
            default:
              this.bool_3 = true;
              break;
          }
        }
      }
      if (this.bool_2)
        this.int_0 = 22;
      else
        this.int_0 = 0;
    }

    private void method_359(Encoding encoding)
    {
      this.stream_0.Position = (long) this.int_0;
      if (this.bool_2)
      {
        if (this.bool_3)
          this.interface33_0 = (Interface33) new Class822(new BinaryReader(this.stream_0), encoding);
        else
          this.interface33_0 = (Interface33) new Class823(new BinaryReader(this.stream_0), encoding);
      }
      else
        this.interface33_0 = (Interface33) new Class634((TextReader) new StreamReader(this.stream_0, encoding));
    }

    private DxfTextStyle GetTextStyleWithName(string name)
    {
      DxfTextStyle dxfTextStyle = this.dxfModel_0.GetTextStyleWithName(name);
      if (dxfTextStyle == null)
      {
        this.dxfMessageCollection_0.Add(new DxfMessage(DxfStatus.UnresolvedReference, Severity.Warning)
        {
          Parameters = {
            {
              "Type",
              (object) "STYLE"
            },
            {
              "Name",
              (object) name
            }
          }
        });
        dxfTextStyle = new DxfTextStyle(name, "txt.shx");
        this.dxfModel_0.TextStyles.Add(dxfTextStyle);
      }
      return dxfTextStyle;
    }

    private static WW.Math.Point2D smethod_3(List<Struct18> groups)
    {
      WW.Math.Point2D zero = WW.Math.Point2D.Zero;
      for (int index = 0; index < groups.Count; ++index)
      {
        Struct18 group = groups[index];
        switch (group.Code)
        {
          case 10:
            zero.X = (double) group.Value;
            break;
          case 20:
            zero.Y = (double) group.Value;
            break;
        }
      }
      return zero;
    }

    private static Vector2D smethod_4(List<Struct18> groups)
    {
      Vector2D zero = Vector2D.Zero;
      for (int index = 0; index < groups.Count; ++index)
      {
        Struct18 group = groups[index];
        switch (group.Code)
        {
          case 10:
            zero.X = (double) group.Value;
            break;
          case 20:
            zero.Y = (double) group.Value;
            break;
        }
      }
      return zero;
    }

    private static WW.Math.Point3D smethod_5(List<Struct18> groups)
    {
      WW.Math.Point3D zero = WW.Math.Point3D.Zero;
      for (int index = 0; index < groups.Count; ++index)
      {
        Struct18 group = groups[index];
        switch (group.Code)
        {
          case 10:
            zero.X = (double) group.Value;
            break;
          case 20:
            zero.Y = (double) group.Value;
            break;
          case 30:
            zero.Z = (double) group.Value;
            break;
        }
      }
      return zero;
    }

    private static WW.Math.Vector3D smethod_6(List<Struct18> groups)
    {
      WW.Math.Vector3D zero = WW.Math.Vector3D.Zero;
      for (int index = 0; index < groups.Count; ++index)
      {
        Struct18 group = groups[index];
        switch (group.Code)
        {
          case 10:
            zero.X = (double) group.Value;
            break;
          case 20:
            zero.Y = (double) group.Value;
            break;
          case 30:
            zero.Z = (double) group.Value;
            break;
        }
      }
      return zero;
    }

    private static bool smethod_7(byte value)
    {
      return value != (byte) 0;
    }

    private static bool smethod_8(short value)
    {
      return value != (short) 0;
    }

    private static int smethod_9(string s, int index)
    {
      return s.Length < index + 4 ? 0 : (int) (ushort) ((uint) ushort.Parse(s.Substring(index, 2), NumberStyles.HexNumber) + ((uint) ushort.Parse(s.Substring(index + 2, 2), NumberStyles.HexNumber) << 16));
    }

    protected virtual void OnBeforeRead(ReadEventArgs e)
    {
      if (this.eventHandler_0 == null)
        return;
      this.eventHandler_0((object) this, e);
    }

    protected virtual void OnProgress(float progress)
    {
      if (this.progressEventHandler_0 == null)
        return;
      this.progressEventHandler_0((object) this, new ProgressEventArgs(progress));
    }

    public void Dispose()
    {
      if (this.stream_0 != null)
      {
        this.stream_0.Close();
        this.stream_0 = (Stream) null;
      }
      this.string_0 = (string) null;
      this.dxfModel_0 = (DxfModel) null;
      this.interface33_0 = (Interface33) null;
    }

    private class Class40
    {
      private double double_0 = 1.0;
      private bool bool_0 = true;
      private EntityColor entityColor_0 = EntityColor.ByLayer;
      private Transparency transparency_0 = Transparency.ByLayer;
      private short short_0 = -1;
      private ulong ulong_0;
      private string string_0;
      private string string_1;
      private bool bool_1;
      private DxfExtendedDataCollection dxfExtendedDataCollection_0;

      internal ulong Handle
      {
        get
        {
          return this.ulong_0;
        }
        set
        {
          this.ulong_0 = value;
        }
      }

      internal string LayerName
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

      internal string LineTypeName
      {
        get
        {
          return this.string_1;
        }
        set
        {
          this.string_1 = value;
        }
      }

      internal double LineTypeScale
      {
        get
        {
          return this.double_0;
        }
        set
        {
          this.double_0 = value;
        }
      }

      internal bool Visible
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

      internal EntityColor Color
      {
        get
        {
          return this.entityColor_0;
        }
        set
        {
          this.entityColor_0 = value;
        }
      }

      internal Transparency Transparency
      {
        get
        {
          return this.transparency_0;
        }
        set
        {
          this.transparency_0 = value;
        }
      }

      internal bool PaperSpace
      {
        get
        {
          return this.bool_1;
        }
        set
        {
          this.bool_1 = value;
        }
      }

      internal short LineWeight
      {
        get
        {
          return this.short_0;
        }
        set
        {
          this.short_0 = value;
        }
      }

      internal DxfExtendedDataCollection ExtendedDataCollection
      {
        get
        {
          if (this.dxfExtendedDataCollection_0 == null)
            this.dxfExtendedDataCollection_0 = new DxfExtendedDataCollection();
          return this.dxfExtendedDataCollection_0;
        }
      }

      internal void method_0(DxfEntity to)
      {
        if (this.dxfExtendedDataCollection_0 == null)
          return;
        to.method_1(this.dxfExtendedDataCollection_0);
      }
    }

    private class Class44
    {
      private DxfDictionary dxfDictionary_0;
      private DxfDictionaryEntry dxfDictionaryEntry_0;
      private string string_0;

      public Class44(
        DxfDictionary dictionary,
        DxfDictionaryEntry dictionaryEntry,
        string entryName)
      {
        this.dxfDictionary_0 = dictionary;
        this.dxfDictionaryEntry_0 = dictionaryEntry;
        this.string_0 = entryName;
      }

      public DxfDictionary Dictionary
      {
        get
        {
          return this.dxfDictionary_0;
        }
      }

      public DxfDictionaryEntry DictionaryEntry
      {
        get
        {
          return this.dxfDictionaryEntry_0;
        }
      }

      public string EntryName
      {
        get
        {
          return this.string_0;
        }
      }
    }

    private class Class41 : DxfReader.Class40
    {
      private double double_1 = 1.0;
      private WW.Math.Vector3D vector3D_0 = WW.Math.Vector3D.ZAxis;
      private WW.Math.Vector3D vector3D_1 = new WW.Math.Vector3D(1.0, 1.0, 1.0);
      private WW.Math.Point3D point3D_0;
      private WW.Math.Point3D point3D_1;
      private AttachmentPoint attachmentPoint_0;
      private LineSpacingStyle lineSpacingStyle_0;
      private double double_2;
      private string string_2;
      private double double_3;
      private double? nullable_0;
      private double double_4;
      private DxfDimensionStyle dxfDimensionStyle_0;
      private short short_1;
      private string string_3;
      private WW.Math.Point3D point3D_2;
      private WW.Math.Point3D point3D_3;
      private WW.Math.Point3D point3D_4;
      private WW.Math.Point3D point3D_5;
      private WW.Math.Point3D point3D_6;
      private double double_5;
      private double double_6;
      private double double_7;

      public WW.Math.Point3D TextMiddlePoint
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

      public WW.Math.Point3D InsertionPointWcs
      {
        get
        {
          return this.point3D_1;
        }
        set
        {
          this.point3D_1 = value;
        }
      }

      public AttachmentPoint AttachmentPoint
      {
        get
        {
          return this.attachmentPoint_0;
        }
        set
        {
          this.attachmentPoint_0 = value;
        }
      }

      public LineSpacingStyle LineSpacingStyle
      {
        get
        {
          return this.lineSpacingStyle_0;
        }
        set
        {
          this.lineSpacingStyle_0 = value;
        }
      }

      public double LineSpacingFactor
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

      public double Measurement
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

      public string Text
      {
        get
        {
          return this.string_2;
        }
        set
        {
          this.string_2 = value;
        }
      }

      public double HorizontalDirection
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

      public double? TextRotation
      {
        get
        {
          return this.nullable_0;
        }
        set
        {
          this.nullable_0 = value;
        }
      }

      public WW.Math.Vector3D ZAxis
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

      public WW.Math.Vector3D InsertionScaleFactor
      {
        get
        {
          return this.vector3D_1;
        }
        set
        {
          this.vector3D_1 = value;
        }
      }

      public double InsertionRotation
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

      public DxfDimensionStyle DimensionStyle
      {
        get
        {
          return this.dxfDimensionStyle_0;
        }
        set
        {
          this.dxfDimensionStyle_0 = value;
        }
      }

      public short DimensionType
      {
        get
        {
          return this.short_1;
        }
        set
        {
          this.short_1 = value;
        }
      }

      public string BlockName
      {
        get
        {
          return this.string_3;
        }
        set
        {
          this.string_3 = value;
        }
      }

      public WW.Math.Point3D DefinitionPoint1
      {
        get
        {
          return this.point3D_2;
        }
        set
        {
          this.point3D_2 = value;
        }
      }

      public WW.Math.Point3D DefinitionPoint4
      {
        get
        {
          return this.point3D_3;
        }
        set
        {
          this.point3D_3 = value;
        }
      }

      public WW.Math.Point3D DefinitionPoint5
      {
        get
        {
          return this.point3D_4;
        }
        set
        {
          this.point3D_4 = value;
        }
      }

      public WW.Math.Point3D DefinitionPoint6
      {
        get
        {
          return this.point3D_5;
        }
        set
        {
          this.point3D_5 = value;
        }
      }

      public WW.Math.Point3D DefinitionPoint7
      {
        get
        {
          return this.point3D_6;
        }
        set
        {
          this.point3D_6 = value;
        }
      }

      public double Rotation
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

      public double ObliqueAngle
      {
        get
        {
          return this.double_6;
        }
        set
        {
          this.double_6 = value;
        }
      }

      public double LeaderLength
      {
        get
        {
          return this.double_7;
        }
        set
        {
          this.double_7 = value;
        }
      }
    }

    private delegate void Delegate0(DxfHeader header, Class374 modelBuilder, object value);

    private class Class42 : DxfReader.Class40
    {
      private WW.Math.Point3D point3D_0;
      private Enum51 enum51_0;
      private double double_1;
      private double double_2;
      private double double_3;
      private double double_4;
      private short short_1;
      private short short_2;
      private short short_3;
      private short short_4;

      public WW.Math.Point3D Position
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

      public Enum51 Flags
      {
        get
        {
          return this.enum51_0;
        }
        set
        {
          this.enum51_0 = value;
        }
      }

      public bool IsSplineControlPoint
      {
        get
        {
          return (this.enum51_0 & Enum51.flag_5) != Enum51.flag_0;
        }
      }

      public bool Is3DPolygonMeshVertex
      {
        get
        {
          return (this.enum51_0 & Enum51.flag_7) != Enum51.flag_0;
        }
      }

      public bool IsPolyfaceMeshVertex
      {
        get
        {
          return (this.enum51_0 & Enum51.flag_8) != Enum51.flag_0;
        }
      }

      public bool IsFace
      {
        get
        {
          if (this.IsPolyfaceMeshVertex)
            return !this.Is3DPolygonMeshVertex;
          return false;
        }
      }

      public double Bulge
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

      public double EndWidth
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

      public double StartWidth
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

      public double TangentDirection
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

      public short Vertex1Index
      {
        get
        {
          return this.short_1;
        }
        set
        {
          this.short_1 = value;
        }
      }

      public short Vertex2Index
      {
        get
        {
          return this.short_2;
        }
        set
        {
          this.short_2 = value;
        }
      }

      public short Vertex3Index
      {
        get
        {
          return this.short_3;
        }
        set
        {
          this.short_3 = value;
        }
      }

      public short Vertex4Index
      {
        get
        {
          return this.short_4;
        }
        set
        {
          this.short_4 = value;
        }
      }

      public static DxfVertex3D smethod_0(DxfPolyfaceMesh polyline, int vertexIndex)
      {
        int index = System.Math.Abs(vertexIndex) - 1;
        DxfVertex3D dxfVertex3D = (DxfVertex3D) null;
        if (index < polyline.Vertices.Count)
          dxfVertex3D = polyline.Vertices[index];
        return dxfVertex3D;
      }
    }

    private class Class43 : DxfReader.Class40
    {
      private WW.Math.Vector3D vector3D_0 = WW.Math.Vector3D.ZAxis;
      private double double_1;
      private double double_2;
      private double double_3;
      private double double_4;
      private Enum21 enum21_0;
      private SplineType splineType_0;
      private ushort ushort_0;
      private ushort ushort_1;
      private ushort ushort_2;
      private ushort ushort_3;

      public double DefaultEndWidth
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

      public double DefaultStartWidth
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

      public double Elevation
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

      public Enum21 Flags
      {
        get
        {
          return this.enum21_0;
        }
        set
        {
          this.enum21_0 = value;
        }
      }

      public bool Closed
      {
        get
        {
          return (this.enum21_0 & Enum21.flag_1) != Enum21.flag_0;
        }
      }

      public bool Plinegen
      {
        get
        {
          return (this.enum21_0 & Enum21.flag_8) != Enum21.flag_0;
        }
      }

      public bool ClosedInNDirection
      {
        get
        {
          return (this.enum21_0 & Enum21.flag_6) != Enum21.flag_0;
        }
      }

      public bool Is3DPolyline
      {
        get
        {
          return (this.enum21_0 & Enum21.flag_4) != Enum21.flag_0;
        }
      }

      public bool Is3DPolygonMesh
      {
        get
        {
          return (this.enum21_0 & Enum21.flag_5) != Enum21.flag_0;
        }
      }

      public bool IsPolyfaceMesh
      {
        get
        {
          return (this.enum21_0 & Enum21.flag_7) != Enum21.flag_0;
        }
      }

      public bool Is3D
      {
        get
        {
          return (this.enum21_0 & (Enum21.flag_4 | Enum21.flag_5 | Enum21.flag_7)) != Enum21.flag_0;
        }
      }

      public bool IsSpline
      {
        get
        {
          return (this.enum21_0 & Enum21.flag_3) != Enum21.flag_0;
        }
      }

      public ushort MVertexCount
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

      public ushort NVertexCount
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

      public ushort SmoothSurfaceMDensity
      {
        get
        {
          return this.ushort_2;
        }
        set
        {
          this.ushort_2 = value;
        }
      }

      public ushort SmoothSurfaceNDensity
      {
        get
        {
          return this.ushort_3;
        }
        set
        {
          this.ushort_3 = value;
        }
      }

      public SplineType SplineType
      {
        get
        {
          return this.splineType_0;
        }
        set
        {
          this.splineType_0 = value;
        }
      }

      public double Thickness
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

      public WW.Math.Vector3D ZAxis
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
    }
  }
}
