// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.MLeader
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns28;
using ns4;
using System;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.IO;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Tables;
using WW.Math;

namespace WW.Cad.Model.Objects
{
  public static class MLeader
  {
    internal static Color smethod_0(int data)
    {
      Color color = Color.smethod_0((uint) data);
      switch (color.ColorType)
      {
        case ColorType.ByLayer:
        case ColorType.ByBlock:
        case ColorType.ByColor:
        case ColorType.ByColorIndex:
        case ColorType.Foreground:
        case ColorType.None:
          return color;
        default:
          color = Color.ByLayer;
          goto case ColorType.ByLayer;
      }
    }

    public class BreakInfo
    {
      private List<WW.Math.Point3D> list_0 = new List<WW.Math.Point3D>();
      private List<WW.Math.Point3D> list_1 = new List<WW.Math.Point3D>();
      private int int_0;

      public int SegmentIndex
      {
        get
        {
          return this.int_0;
        }
        set
        {
          this.int_0 = value;
        }
      }

      public List<WW.Math.Point3D> StartPoints
      {
        get
        {
          return this.list_0;
        }
      }

      public List<WW.Math.Point3D> EndPoints
      {
        get
        {
          return this.list_1;
        }
      }

      public MLeader.BreakInfo Clone(CloneContext cloneContext)
      {
        MLeader.BreakInfo breakInfo = new MLeader.BreakInfo();
        breakInfo.CopyFrom(this, cloneContext);
        return breakInfo;
      }

      public void CopyFrom(MLeader.BreakInfo from, CloneContext cloneContext)
      {
        this.int_0 = from.int_0;
        this.list_0.Clear();
        this.list_0.AddRange((IEnumerable<WW.Math.Point3D>) from.list_0);
        this.list_1.Clear();
        this.list_1.AddRange((IEnumerable<WW.Math.Point3D>) from.list_1);
      }

      public void TransformMe(TransformConfig config, Matrix4D matrix, CommandGroup undoGroup)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        MLeader.BreakInfo.Class868 class868 = new MLeader.BreakInfo.Class868();
        // ISSUE: reference to a compiler-generated field
        class868.breakInfo_0 = this;
        // ISSUE: reference to a compiler-generated field
        class868.point3D_0 = this.list_0.ToArray();
        // ISSUE: reference to a compiler-generated field
        class868.point3D_1 = this.list_1.ToArray();
        for (int index = 0; index < this.list_0.Count; ++index)
          this.list_0[index] = matrix.Transform(this.list_0[index]);
        for (int index = 0; index < this.list_1.Count; ++index)
          this.list_1[index] = matrix.Transform(this.list_1[index]);
        if (undoGroup == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new MLeader.BreakInfo.Class869()
        {
          class868_0 = class868,
          point3D_0 = this.list_0.ToArray(),
          point3D_1 = this.list_1.ToArray()
        }.method_0), new System.Action(class868.method_0)));
      }

      internal void Read(Class434 or)
      {
        Interface30 objectBitStream = or.ObjectBitStream;
        this.int_0 = objectBitStream.imethod_11();
        int num = objectBitStream.imethod_11();
        for (int index = 0; index < num; ++index)
        {
          this.list_0.Add(objectBitStream.imethod_39());
          this.list_1.Add(objectBitStream.imethod_39());
        }
      }

      internal void Write(Class432 ow)
      {
        Interface29 objectWriter = ow.ObjectWriter;
        objectWriter.imethod_33(this.int_0);
        objectWriter.imethod_33(this.list_0.Count);
        for (int index = 0; index < this.list_0.Count; ++index)
        {
          objectWriter.imethod_24(this.list_0[index]);
          objectWriter.imethod_24(this.list_1[index]);
        }
      }

      internal void Write(DxfWriter w)
      {
        w.Write(90, (object) this.int_0);
        for (int index = 0; index < this.list_0.Count; ++index)
        {
          w.Write(11, this.list_0[index]);
          w.Write(12, this.list_1[index]);
        }
      }
    }

    public class LeaderLine
    {
      private List<WW.Math.Point3D> list_0 = new List<WW.Math.Point3D>();
      private List<MLeader.BreakInfo> list_1 = new List<MLeader.BreakInfo>();
      private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
      private int int_2 = -1;
      private double double_1 = 0.18;
      private DxfObjectReference dxfObjectReference_1 = DxfObjectReference.Null;
      private double double_0;
      private int int_0;
      private int int_1;
      private MLeader.LeaderType leaderType_0;
      private Color color_0;
      private MLeader.LeaderLineOverrideFlags leaderLineOverrideFlags_0;

      public LeaderLine()
      {
      }

      public LeaderLine(IList<WW.Math.Point3D> points)
      {
        this.list_0.AddRange((IEnumerable<WW.Math.Point3D>) points);
      }

      public LeaderLine(params WW.Math.Point3D[] points)
      {
        this.list_0.AddRange((IEnumerable<WW.Math.Point3D>) points);
      }

      public double LandingDistance
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

      public List<WW.Math.Point3D> Points
      {
        get
        {
          return this.list_0;
        }
      }

      public List<MLeader.BreakInfo> BreakInfoList
      {
        get
        {
          return this.list_1;
        }
      }

      public int LeaderLineIndex
      {
        get
        {
          return this.int_0;
        }
        set
        {
          this.int_0 = value;
        }
      }

      public int ParentLeaderIndex
      {
        get
        {
          return this.int_1;
        }
        set
        {
          this.int_1 = value;
        }
      }

      public MLeader.LeaderType LeaderType
      {
        get
        {
          return this.leaderType_0;
        }
        set
        {
          this.leaderType_0 = value;
        }
      }

      public Color LineColor
      {
        get
        {
          return this.color_0;
        }
        set
        {
          this.color_0 = value;
        }
      }

      public DxfLineType LineType
      {
        get
        {
          return (DxfLineType) this.dxfObjectReference_0.Value;
        }
        set
        {
          this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        }
      }

      public int LineWeight
      {
        get
        {
          return this.int_2;
        }
        set
        {
          this.int_2 = value;
        }
      }

      public double ArrowSize
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

      public DxfBlock ArrowSymbolBlock
      {
        get
        {
          return (DxfBlock) this.dxfObjectReference_1.Value;
        }
        set
        {
          this.dxfObjectReference_1 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        }
      }

      public MLeader.LeaderLineOverrideFlags OverrideFlags
      {
        get
        {
          return this.leaderLineOverrideFlags_0;
        }
        set
        {
          this.leaderLineOverrideFlags_0 = value;
        }
      }

      public MLeader.LeaderType GetLeaderType(DxfMLeader mleader)
      {
        if ((this.leaderLineOverrideFlags_0 & MLeader.LeaderLineOverrideFlags.LeaderType) != MLeader.LeaderLineOverrideFlags.None)
          return this.leaderType_0;
        return mleader.LeaderType;
      }

      public Color GetLineColor(DxfMLeader mleader)
      {
        if ((this.leaderLineOverrideFlags_0 & MLeader.LeaderLineOverrideFlags.LineColor) != MLeader.LeaderLineOverrideFlags.None)
          return this.color_0;
        return mleader.LeaderLineColor;
      }

      public DxfLineType GetLineType(DxfMLeader mleader)
      {
        if ((this.leaderLineOverrideFlags_0 & MLeader.LeaderLineOverrideFlags.LineType) != MLeader.LeaderLineOverrideFlags.None)
          return this.LineType;
        return mleader.LeaderLineType;
      }

      public int GetLineWeight(DxfMLeader mleader)
      {
        if ((this.leaderLineOverrideFlags_0 & MLeader.LeaderLineOverrideFlags.LineWeight) != MLeader.LeaderLineOverrideFlags.None)
          return this.int_2;
        return (int) mleader.LineWeight;
      }

      public double GetArrowSize(DxfMLeader mleader)
      {
        if ((this.leaderLineOverrideFlags_0 & MLeader.LeaderLineOverrideFlags.ArrowSize) != MLeader.LeaderLineOverrideFlags.None)
          return this.double_1;
        if (mleader.Content != null)
          return mleader.Content.ArrowHeadSize;
        return mleader.ArrowHeadSize;
      }

      public DxfBlock GetArrowSymbolBlock(DxfMLeader mleader)
      {
        if ((this.leaderLineOverrideFlags_0 & MLeader.LeaderLineOverrideFlags.ArrowSymbolBlock) != MLeader.LeaderLineOverrideFlags.None)
          return this.ArrowSymbolBlock;
        return mleader.ArrowHeadBlock;
      }

      public MLeader.LeaderLine Clone(CloneContext cloneContext)
      {
        MLeader.LeaderLine leaderLine = new MLeader.LeaderLine();
        leaderLine.CopyFrom(this, cloneContext);
        return leaderLine;
      }

      public void CopyFrom(MLeader.LeaderLine from, CloneContext cloneContext)
      {
        this.double_0 = from.double_0;
        this.list_0.Clear();
        this.list_0.AddRange((IEnumerable<WW.Math.Point3D>) from.list_0);
        this.list_1.Clear();
        foreach (MLeader.BreakInfo breakInfo in from.list_1)
          this.list_1.Add(breakInfo.Clone(cloneContext));
        this.int_0 = from.int_0;
        this.int_1 = from.int_1;
        this.leaderType_0 = from.leaderType_0;
        this.color_0 = from.color_0;
        this.LineType = Class906.GetLineType(cloneContext, from.LineType);
        this.int_2 = from.int_2;
        this.double_1 = from.double_1;
        this.ArrowSymbolBlock = Class906.smethod_0(cloneContext, from.ArrowSymbolBlock, false);
        this.leaderLineOverrideFlags_0 = from.leaderLineOverrideFlags_0;
      }

      public void TransformMe(TransformConfig config, Matrix4D matrix, CommandGroup undoGroup)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        MLeader.LeaderLine.Class870 class870 = new MLeader.LeaderLine.Class870();
        // ISSUE: reference to a compiler-generated field
        class870.leaderLine_0 = this;
        // ISSUE: reference to a compiler-generated field
        class870.point3D_0 = this.list_0.ToArray();
        for (int index = 0; index < this.list_0.Count; ++index)
          this.list_0[index] = matrix.Transform(this.list_0[index]);
        CommandGroup undoGroup1 = (CommandGroup) null;
        if (undoGroup != null)
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          MLeader.LeaderLine.Class871 class871 = new MLeader.LeaderLine.Class871();
          // ISSUE: reference to a compiler-generated field
          class871.class870_0 = class870;
          // ISSUE: reference to a compiler-generated field
          class871.point3D_0 = this.list_0.ToArray();
          undoGroup1 = new CommandGroup((object) this);
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          undoGroup1.UndoStack.Push((ICommand) new Command((object) this, new System.Action(class871.method_0), new System.Action(class870.method_0)));
          undoGroup.UndoStack.Push((ICommand) undoGroup1);
        }
        foreach (MLeader.BreakInfo breakInfo in this.list_1)
          breakInfo.TransformMe(config, matrix, undoGroup1);
      }

      internal void Read(Class434 or, MLeader.LeaderNode parentLeaderNode)
      {
        Interface30 objectBitStream = or.ObjectBitStream;
        int num1 = objectBitStream.imethod_11();
        for (int index = 0; index < num1; ++index)
          this.list_0.Add(objectBitStream.imethod_39());
        int num2 = objectBitStream.imethod_11();
        for (int index = 0; index < num2; ++index)
        {
          MLeader.BreakInfo breakInfo = new MLeader.BreakInfo();
          breakInfo.Read(or);
          this.list_1.Add(breakInfo);
        }
        this.int_0 = objectBitStream.imethod_11();
        this.int_1 = parentLeaderNode.LeaderIndex;
        if (or.Builder.Version <= DxfVersion.Dxf21)
          return;
        this.leaderType_0 = (MLeader.LeaderType) objectBitStream.imethod_14();
        this.color_0 = objectBitStream.imethod_22();
        or.method_78((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_0 = o));
        this.int_2 = objectBitStream.imethod_11();
        this.double_1 = objectBitStream.imethod_8();
        or.method_78((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_1 = o));
        this.leaderLineOverrideFlags_0 = (MLeader.LeaderLineOverrideFlags) objectBitStream.imethod_11();
      }

      internal void Write(Class432 ow)
      {
        Interface29 objectWriter = ow.ObjectWriter;
        objectWriter.imethod_33(this.list_0.Count);
        foreach (WW.Math.Point3D point3D in this.list_0)
          objectWriter.imethod_24(point3D);
        objectWriter.imethod_33(this.list_1.Count);
        foreach (MLeader.BreakInfo breakInfo in this.list_1)
          breakInfo.Write(ow);
        objectWriter.imethod_33(this.int_0);
        if (ow.Version <= DxfVersion.Dxf21)
          return;
        objectWriter.imethod_32((short) this.leaderType_0);
        objectWriter.imethod_6(this.color_0);
        objectWriter.imethod_41((DxfHandledObject) this.LineType);
        objectWriter.imethod_33(this.int_2);
        objectWriter.imethod_16(this.double_1);
        objectWriter.imethod_41((DxfHandledObject) this.ArrowSymbolBlock);
        objectWriter.imethod_33((int) this.leaderLineOverrideFlags_0);
      }

      internal void Read(DxfReader r)
      {
        MLeader.BreakInfo breakInfo = (MLeader.BreakInfo) null;
        while (r.CurrentGroup.Code != 305 || !((string) r.CurrentGroup.Value == "}"))
        {
          switch (r.CurrentGroup.Code)
          {
            case 10:
              this.list_0.Add(new WW.Math.Point3D((double) r.CurrentGroup.Value, 0.0, 0.0));
              break;
            case 11:
              WW.Math.Point3D point3D1 = new WW.Math.Point3D((double) r.CurrentGroup.Value, 0.0, 0.0);
              breakInfo.StartPoints.Add(point3D1);
              break;
            case 12:
              WW.Math.Point3D point3D2 = new WW.Math.Point3D((double) r.CurrentGroup.Value, 0.0, 0.0);
              breakInfo.EndPoints.Add(point3D2);
              break;
            case 20:
              WW.Math.Point3D point3D3 = this.list_0[this.list_0.Count - 1];
              point3D3.Y = (double) r.CurrentGroup.Value;
              this.list_0[this.list_0.Count - 1] = point3D3;
              break;
            case 21:
              WW.Math.Point3D startPoint1 = breakInfo.StartPoints[breakInfo.StartPoints.Count - 1];
              startPoint1.Y = (double) r.CurrentGroup.Value;
              breakInfo.StartPoints[breakInfo.StartPoints.Count - 1] = startPoint1;
              break;
            case 22:
              WW.Math.Point3D endPoint1 = breakInfo.EndPoints[breakInfo.EndPoints.Count - 1];
              endPoint1.Y = (double) r.CurrentGroup.Value;
              breakInfo.EndPoints[breakInfo.EndPoints.Count - 1] = endPoint1;
              break;
            case 30:
              WW.Math.Point3D point3D4 = this.list_0[this.list_0.Count - 1];
              point3D4.Z = (double) r.CurrentGroup.Value;
              this.list_0[this.list_0.Count - 1] = point3D4;
              break;
            case 31:
              WW.Math.Point3D startPoint2 = breakInfo.StartPoints[breakInfo.StartPoints.Count - 1];
              startPoint2.Z = (double) r.CurrentGroup.Value;
              breakInfo.StartPoints[breakInfo.StartPoints.Count - 1] = startPoint2;
              break;
            case 32:
              WW.Math.Point3D endPoint2 = breakInfo.EndPoints[breakInfo.EndPoints.Count - 1];
              endPoint2.Z = (double) r.CurrentGroup.Value;
              breakInfo.EndPoints[breakInfo.EndPoints.Count - 1] = endPoint2;
              break;
            case 40:
              this.double_1 = (double) r.CurrentGroup.Value;
              break;
            case 90:
              breakInfo = new MLeader.BreakInfo();
              breakInfo.SegmentIndex = (int) r.CurrentGroup.Value;
              this.list_1.Add(breakInfo);
              break;
            case 91:
              this.int_0 = (int) r.CurrentGroup.Value;
              break;
            case 92:
              this.color_0 = MLeader.smethod_0((int) r.CurrentGroup.Value);
              break;
            case 93:
              this.leaderLineOverrideFlags_0 = (MLeader.LeaderLineOverrideFlags) r.CurrentGroup.Value;
              break;
            case 170:
              this.leaderType_0 = (MLeader.LeaderType) r.CurrentGroup.Value;
              break;
            case 171:
              this.int_2 = (int) (short) r.CurrentGroup.Value;
              break;
            case 340:
              r.method_90((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_0 = o));
              break;
            case 341:
              r.method_90((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_1 = o));
              break;
          }
          r.method_85();
        }
      }

      internal void Write(DxfWriter w)
      {
        w.Write(304, (object) "LEADER_LINE{");
        foreach (WW.Math.Point3D p in this.list_0)
          w.Write(10, p);
        foreach (MLeader.BreakInfo breakInfo in this.list_1)
          breakInfo.Write(w);
        w.Write(91, (object) this.int_0);
        if (w.Version > DxfVersion.Dxf21)
        {
          if (this.leaderType_0 != MLeader.LeaderType.Straight)
            w.Write(170, (object) (short) this.leaderType_0);
          if (this.color_0 != Color.ByLayer)
            w.Write(92, (object) (int) this.color_0.Data);
          if (this.LineType != null)
            w.method_218(340, (DxfHandledObject) this.LineType);
          if (this.int_2 != -2)
            w.Write(171, (object) (short) this.int_2);
          w.Write(40, (object) this.double_1);
          if (this.ArrowSymbolBlock != null)
            w.method_218(341, (DxfHandledObject) this.ArrowSymbolBlock);
          if (this.leaderLineOverrideFlags_0 != MLeader.LeaderLineOverrideFlags.None)
            w.Write(93, (object) (int) this.leaderLineOverrideFlags_0);
        }
        w.Write(305, (object) "}");
      }
    }

    public class LeaderNode
    {
      private bool bool_0 = true;
      private bool bool_1 = true;
      private List<WW.Math.Point3D> list_0 = new List<WW.Math.Point3D>();
      private List<WW.Math.Point3D> list_1 = new List<WW.Math.Point3D>();
      private double double_0 = 0.36;
      private List<MLeader.LeaderLine> list_2 = new List<MLeader.LeaderLine>();
      private WW.Math.Point3D point3D_0;
      private WW.Math.Vector3D vector3D_0;
      private int int_0;
      private MLeader.TextAttachmentDirection textAttachmentDirection_0;

      public LeaderNode()
      {
      }

      public LeaderNode(WW.Math.Point3D connectionPoint, WW.Math.Vector3D direction)
      {
        this.point3D_0 = connectionPoint;
        this.vector3D_0 = direction;
      }

      public bool IsContentValid
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

      public WW.Math.Point3D ConnectionPoint
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

      public WW.Math.Vector3D Direction
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

      public List<WW.Math.Point3D> BreakStartPoints
      {
        get
        {
          return this.list_0;
        }
      }

      public List<WW.Math.Point3D> BreakEndPoints
      {
        get
        {
          return this.list_1;
        }
      }

      public int LeaderIndex
      {
        get
        {
          return this.int_0;
        }
        set
        {
          this.int_0 = value;
        }
      }

      public double LandingDistance
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

      public List<MLeader.LeaderLine> LeaderLines
      {
        get
        {
          return this.list_2;
        }
      }

      public MLeader.TextAttachmentDirection TextAttachmentDirection
      {
        get
        {
          return this.textAttachmentDirection_0;
        }
        set
        {
          this.textAttachmentDirection_0 = value;
        }
      }

      public MLeader.LeaderNode Clone(CloneContext cloneContext)
      {
        MLeader.LeaderNode leaderNode = new MLeader.LeaderNode();
        leaderNode.CopyFrom(this, cloneContext);
        return leaderNode;
      }

      public void CopyFrom(MLeader.LeaderNode from, CloneContext cloneContext)
      {
        this.bool_0 = from.bool_0;
        this.bool_1 = from.bool_1;
        this.point3D_0 = from.point3D_0;
        this.vector3D_0 = from.vector3D_0;
        this.list_0.Clear();
        this.list_0.AddRange((IEnumerable<WW.Math.Point3D>) from.list_0);
        this.list_1.Clear();
        this.list_1.AddRange((IEnumerable<WW.Math.Point3D>) from.list_1);
        this.int_0 = from.int_0;
        this.list_2.Clear();
        foreach (MLeader.LeaderLine leaderLine in from.list_2)
          this.list_2.Add(leaderLine.Clone(cloneContext));
        this.textAttachmentDirection_0 = from.textAttachmentDirection_0;
      }

      public void TransformMe(TransformConfig config, Matrix4D matrix, CommandGroup undoGroup)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        MLeader.LeaderNode.Class872 class872 = new MLeader.LeaderNode.Class872();
        // ISSUE: reference to a compiler-generated field
        class872.leaderNode_0 = this;
        // ISSUE: reference to a compiler-generated field
        class872.point3D_0 = this.point3D_0;
        // ISSUE: reference to a compiler-generated field
        class872.vector3D_0 = this.vector3D_0;
        // ISSUE: reference to a compiler-generated field
        class872.point3D_1 = this.list_0.ToArray();
        // ISSUE: reference to a compiler-generated field
        class872.point3D_2 = this.list_1.ToArray();
        this.point3D_0 = matrix.Transform(this.point3D_0);
        this.vector3D_0 = matrix.Transform(this.vector3D_0);
        for (int index = 0; index < this.list_0.Count; ++index)
          this.list_0[index] = matrix.Transform(this.list_0[index]);
        for (int index = 0; index < this.list_1.Count; ++index)
          this.list_1[index] = matrix.Transform(this.list_1[index]);
        CommandGroup undoGroup1 = (CommandGroup) null;
        if (undoGroup != null)
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          MLeader.LeaderNode.Class873 class873 = new MLeader.LeaderNode.Class873();
          // ISSUE: reference to a compiler-generated field
          class873.class872_0 = class872;
          // ISSUE: reference to a compiler-generated field
          class873.point3D_0 = this.point3D_0;
          // ISSUE: reference to a compiler-generated field
          class873.vector3D_0 = this.vector3D_0;
          // ISSUE: reference to a compiler-generated field
          class873.point3D_1 = this.list_0.ToArray();
          // ISSUE: reference to a compiler-generated field
          class873.point3D_2 = this.list_1.ToArray();
          undoGroup1 = new CommandGroup((object) this);
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          undoGroup1.UndoStack.Push((ICommand) new Command((object) this, new System.Action(class873.method_0), new System.Action(class872.method_0)));
          undoGroup.UndoStack.Push((ICommand) undoGroup1);
        }
        foreach (MLeader.LeaderLine leaderLine in this.list_2)
          leaderLine.TransformMe(config, matrix, undoGroup1);
      }

      internal WW.Math.Point3D LandingPoint
      {
        get
        {
          return this.point3D_0 + this.vector3D_0 * this.LandingDistance;
        }
      }

      internal bool Unknown1
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

      internal void Read(Class434 or)
      {
        Interface30 objectBitStream = or.ObjectBitStream;
        this.bool_0 = objectBitStream.imethod_6();
        this.bool_1 = objectBitStream.imethod_6();
        this.point3D_0 = objectBitStream.imethod_39();
        this.vector3D_0 = objectBitStream.imethod_51();
        int num1 = objectBitStream.imethod_11();
        for (int index = 0; index < num1; ++index)
        {
          this.list_0.Add(objectBitStream.imethod_39());
          this.list_1.Add(objectBitStream.imethod_39());
        }
        this.int_0 = objectBitStream.imethod_11();
        this.double_0 = objectBitStream.imethod_8();
        int num2 = objectBitStream.imethod_11();
        for (int index = 0; index < num2; ++index)
        {
          MLeader.LeaderLine leaderLine = new MLeader.LeaderLine();
          leaderLine.Read(or, this);
          this.list_2.Add(leaderLine);
        }
        if (or.Builder.Version <= DxfVersion.Dxf21)
          return;
        this.textAttachmentDirection_0 = (MLeader.TextAttachmentDirection) objectBitStream.imethod_14();
      }

      internal void Write(Class432 ow)
      {
        Interface29 objectWriter = ow.ObjectWriter;
        objectWriter.imethod_14(this.bool_0);
        objectWriter.imethod_14(this.bool_1);
        objectWriter.imethod_24(this.point3D_0);
        objectWriter.imethod_29(this.vector3D_0);
        objectWriter.imethod_33(this.list_0.Count);
        for (int index = 0; index < this.list_0.Count; ++index)
        {
          objectWriter.imethod_24(this.list_0[index]);
          objectWriter.imethod_24(this.list_1[index]);
        }
        objectWriter.imethod_33(this.int_0);
        objectWriter.imethod_16(this.double_0);
        objectWriter.imethod_33(this.list_2.Count);
        foreach (MLeader.LeaderLine leaderLine in this.list_2)
          leaderLine.Write(ow);
        if (ow.Version <= DxfVersion.Dxf21)
          return;
        objectWriter.imethod_32((short) this.textAttachmentDirection_0);
      }

      internal void Read(DxfReader r)
      {
        while (r.CurrentGroup.Code != 303 || !((string) r.CurrentGroup.Value == "}"))
        {
          switch (r.CurrentGroup.Code)
          {
            case 10:
              this.point3D_0.X = (double) r.CurrentGroup.Value;
              break;
            case 11:
              this.vector3D_0.X = (double) r.CurrentGroup.Value;
              break;
            case 12:
              this.list_0.Add(new WW.Math.Point3D((double) r.CurrentGroup.Value, 0.0, 0.0));
              break;
            case 13:
              this.list_1.Add(new WW.Math.Point3D((double) r.CurrentGroup.Value, 0.0, 0.0));
              break;
            case 20:
              this.point3D_0.Y = (double) r.CurrentGroup.Value;
              break;
            case 21:
              this.vector3D_0.Y = (double) r.CurrentGroup.Value;
              break;
            case 22:
              WW.Math.Point3D point3D1 = this.list_0[this.list_0.Count - 1];
              point3D1.Y = (double) r.CurrentGroup.Value;
              this.list_0[this.list_0.Count - 1] = point3D1;
              break;
            case 23:
              WW.Math.Point3D point3D2 = this.list_1[this.list_1.Count - 1];
              point3D2.Y = (double) r.CurrentGroup.Value;
              this.list_1[this.list_1.Count - 1] = point3D2;
              break;
            case 30:
              this.point3D_0.Z = (double) r.CurrentGroup.Value;
              break;
            case 31:
              this.vector3D_0.Z = (double) r.CurrentGroup.Value;
              break;
            case 32:
              WW.Math.Point3D point3D3 = this.list_0[this.list_0.Count - 1];
              point3D3.Z = (double) r.CurrentGroup.Value;
              this.list_0[this.list_0.Count - 1] = point3D3;
              break;
            case 33:
              WW.Math.Point3D point3D4 = this.list_1[this.list_1.Count - 1];
              point3D4.Z = (double) r.CurrentGroup.Value;
              this.list_1[this.list_1.Count - 1] = point3D4;
              break;
            case 40:
              this.double_0 = (double) r.CurrentGroup.Value;
              break;
            case 90:
              this.int_0 = (int) r.CurrentGroup.Value;
              break;
            case 271:
              this.textAttachmentDirection_0 = (MLeader.TextAttachmentDirection) r.CurrentGroup.Value;
              break;
            case 290:
              this.bool_0 = (bool) r.CurrentGroup.Value;
              break;
            case 291:
              this.bool_1 = (bool) r.CurrentGroup.Value;
              break;
            case 304:
              if ((string) r.CurrentGroup.Value == "LEADER_LINE{")
              {
                MLeader.LeaderLine leaderLine = new MLeader.LeaderLine();
                r.method_85();
                leaderLine.Read(r);
                this.list_2.Add(leaderLine);
                break;
              }
              break;
          }
          r.method_85();
        }
      }

      internal void Write(DxfWriter w)
      {
        w.Write(302, (object) "LEADER{");
        w.Write(290, (object) this.bool_0);
        w.Write(291, (object) this.bool_1);
        w.Write(10, this.point3D_0);
        w.Write(11, this.vector3D_0);
        for (int index = 0; index < this.list_0.Count; ++index)
        {
          w.Write(12, this.list_0[index]);
          w.Write(13, this.list_1[index]);
        }
        w.Write(90, (object) this.int_0);
        w.Write(40, (object) this.double_0);
        foreach (MLeader.LeaderLine leaderLine in this.list_2)
          leaderLine.Write(w);
        if (w.Version > DxfVersion.Dxf21)
          w.Write(271, (object) (short) this.textAttachmentDirection_0);
        w.Write(303, (object) "}");
      }
    }

    public abstract class Content
    {
      private WW.Math.Vector3D vector3D_0 = WW.Math.Vector3D.ZAxis;
      private MLeader.ContentType contentType_0;
      private WW.Math.Point3D point3D_0;
      private double double_0;

      public MLeader.ContentType ContentType
      {
        get
        {
          return this.contentType_0;
        }
        set
        {
          this.contentType_0 = value;
        }
      }

      public WW.Math.Point3D Location
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

      public WW.Math.Vector3D Normal
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

      public double Rotation
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

      public Matrix4D Transform
      {
        get
        {
          return Transformation4D.Translation(this.point3D_0.X, this.point3D_0.Y, this.point3D_0.Z) * Transformation4D.RotateZ(this.double_0) * DxfUtil.GetToWCSTransform(this.vector3D_0);
        }
      }

      public abstract MLeader.Content Clone(CloneContext cloneContext);

      public virtual void CopyFrom(MLeader.Content from, CloneContext cloneContext)
      {
        this.contentType_0 = from.contentType_0;
        this.point3D_0 = from.point3D_0;
        this.vector3D_0 = from.vector3D_0;
        this.double_0 = from.double_0;
      }

      public virtual void TransformMe(
        TransformConfig config,
        Matrix4D matrix,
        CommandGroup undoGroup)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        MLeader.Content.Class874 class874 = new MLeader.Content.Class874();
        // ISSUE: reference to a compiler-generated field
        class874.content_0 = this;
        // ISSUE: reference to a compiler-generated field
        class874.point3D_0 = this.point3D_0;
        // ISSUE: reference to a compiler-generated field
        class874.vector3D_0 = this.vector3D_0;
        this.point3D_0 = matrix.Transform(this.point3D_0);
        this.vector3D_0 = matrix.Transform(this.vector3D_0);
        if (undoGroup == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new MLeader.Content.Class875()
        {
          class874_0 = class874,
          point3D_0 = this.point3D_0,
          vector3D_0 = this.vector3D_0
        }.method_0), new System.Action(class874.method_0)));
      }

      internal abstract void Write(Class432 ow);

      internal abstract void Write(DxfWriter w);
    }

    public class ContentBlock : MLeader.Content
    {
      private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
      private WW.Math.Vector3D vector3D_1 = new WW.Math.Vector3D(1.0, 1.0, 1.0);
      private Color color_0 = Color.ByBlock;
      private Matrix4D matrix4D_0 = Matrix4D.Identity;

      public ContentBlock()
      {
        this.ContentType = MLeader.ContentType.Block;
      }

      public DxfBlock Block
      {
        get
        {
          return (DxfBlock) this.dxfObjectReference_0.Value;
        }
        set
        {
          this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        }
      }

      public WW.Math.Vector3D Scale
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

      public Color BlockColor
      {
        get
        {
          return this.color_0;
        }
        set
        {
          this.color_0 = value;
        }
      }

      public Matrix4D BlockTransform
      {
        get
        {
          return this.matrix4D_0;
        }
        set
        {
          this.matrix4D_0 = value;
        }
      }

      public Matrix4D CurrentBlockTransform
      {
        get
        {
          return Transformation4D.Translation(this.Location.X, this.Location.Y, this.Location.Z) * Transformation4D.Scaling(this.vector3D_1) * Transformation4D.RotateZ(this.Rotation) * DxfUtil.GetToWCSTransform(this.Normal);
        }
      }

      public override MLeader.Content Clone(CloneContext cloneContext)
      {
        MLeader.ContentBlock contentBlock = new MLeader.ContentBlock();
        contentBlock.CopyFrom((MLeader.Content) this, cloneContext);
        return (MLeader.Content) contentBlock;
      }

      public override void CopyFrom(MLeader.Content from, CloneContext cloneContext)
      {
        base.CopyFrom(from, cloneContext);
        MLeader.ContentBlock contentBlock = (MLeader.ContentBlock) from;
        this.Block = Class906.smethod_0(cloneContext, contentBlock.Block, false);
        this.vector3D_1 = contentBlock.vector3D_1;
        this.color_0 = contentBlock.color_0;
        this.matrix4D_0 = contentBlock.matrix4D_0;
      }

      public override void TransformMe(
        TransformConfig config,
        Matrix4D matrix,
        CommandGroup undoGroup)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        MLeader.ContentBlock.Class876 class876 = new MLeader.ContentBlock.Class876();
        // ISSUE: reference to a compiler-generated field
        class876.contentBlock_0 = this;
        CommandGroup undoGroup1 = (CommandGroup) null;
        if (undoGroup != null)
        {
          undoGroup1 = new CommandGroup((object) this);
          undoGroup.UndoStack.Push((ICommand) undoGroup1);
        }
        base.TransformMe(config, matrix, undoGroup1);
        // ISSUE: reference to a compiler-generated field
        class876.vector3D_0 = this.vector3D_1;
        this.vector3D_1 = new WW.Math.Vector3D(matrix.Transform(new WW.Math.Vector3D(this.vector3D_1.X, 0.0, 0.0)).GetLength(), matrix.Transform(new WW.Math.Vector3D(0.0, this.vector3D_1.Y, 0.0)).GetLength(), matrix.Transform(new WW.Math.Vector3D(0.0, 0.0, this.vector3D_1.Z)).GetLength());
        if (undoGroup1 == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup1.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new MLeader.ContentBlock.Class877()
        {
          class876_0 = class876,
          vector3D_0 = this.vector3D_1
        }.method_0), new System.Action(class876.method_0)));
      }

      internal void Read(Class434 or)
      {
        Interface30 objectBitStream = or.ObjectBitStream;
        or.method_78((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_0 = o));
        this.Normal = objectBitStream.imethod_51();
        this.Location = objectBitStream.imethod_39();
        this.vector3D_1 = objectBitStream.imethod_51();
        this.Rotation = objectBitStream.imethod_8();
        this.color_0 = objectBitStream.imethod_22();
        this.matrix4D_0.M00 = objectBitStream.imethod_8();
        this.matrix4D_0.M01 = objectBitStream.imethod_8();
        this.matrix4D_0.M02 = objectBitStream.imethod_8();
        this.matrix4D_0.M03 = objectBitStream.imethod_8();
        this.matrix4D_0.M10 = objectBitStream.imethod_8();
        this.matrix4D_0.M11 = objectBitStream.imethod_8();
        this.matrix4D_0.M12 = objectBitStream.imethod_8();
        this.matrix4D_0.M13 = objectBitStream.imethod_8();
        this.matrix4D_0.M20 = objectBitStream.imethod_8();
        this.matrix4D_0.M21 = objectBitStream.imethod_8();
        this.matrix4D_0.M22 = objectBitStream.imethod_8();
        this.matrix4D_0.M23 = objectBitStream.imethod_8();
        this.matrix4D_0.M30 = objectBitStream.imethod_8();
        this.matrix4D_0.M31 = objectBitStream.imethod_8();
        this.matrix4D_0.M32 = objectBitStream.imethod_8();
        this.matrix4D_0.M33 = objectBitStream.imethod_8();
      }

      internal override void Write(Class432 ow)
      {
        Interface29 objectWriter = ow.ObjectWriter;
        objectWriter.imethod_40((DxfHandledObject) this.Block);
        objectWriter.imethod_29(this.Normal);
        objectWriter.imethod_24(this.Location);
        objectWriter.imethod_29(this.vector3D_1);
        objectWriter.imethod_16(this.Rotation);
        objectWriter.imethod_6(this.color_0);
        objectWriter.imethod_16(this.matrix4D_0.M00);
        objectWriter.imethod_16(this.matrix4D_0.M01);
        objectWriter.imethod_16(this.matrix4D_0.M02);
        objectWriter.imethod_16(this.matrix4D_0.M03);
        objectWriter.imethod_16(this.matrix4D_0.M10);
        objectWriter.imethod_16(this.matrix4D_0.M11);
        objectWriter.imethod_16(this.matrix4D_0.M12);
        objectWriter.imethod_16(this.matrix4D_0.M13);
        objectWriter.imethod_16(this.matrix4D_0.M20);
        objectWriter.imethod_16(this.matrix4D_0.M21);
        objectWriter.imethod_16(this.matrix4D_0.M22);
        objectWriter.imethod_16(this.matrix4D_0.M23);
        objectWriter.imethod_16(this.matrix4D_0.M30);
        objectWriter.imethod_16(this.matrix4D_0.M31);
        objectWriter.imethod_16(this.matrix4D_0.M32);
        objectWriter.imethod_16(this.matrix4D_0.M33);
      }

      internal void Read(DxfReader r)
      {
        int num = 28;
        List<double> doubleList = new List<double>(16);
        for (; num > 0; --num)
        {
          switch (r.CurrentGroup.Code)
          {
            case 14:
              this.Normal = new WW.Math.Vector3D((double) r.CurrentGroup.Value, this.Normal.Y, this.Normal.Z);
              break;
            case 15:
              this.Location = new WW.Math.Point3D((double) r.CurrentGroup.Value, this.Location.Y, this.Location.Z);
              break;
            case 16:
              this.vector3D_1.X = (double) r.CurrentGroup.Value;
              break;
            case 24:
              this.Normal = new WW.Math.Vector3D(this.Normal.X, (double) r.CurrentGroup.Value, this.Normal.Z);
              break;
            case 25:
              this.Location = new WW.Math.Point3D(this.Location.X, (double) r.CurrentGroup.Value, this.Location.Z);
              break;
            case 26:
              this.vector3D_1.Y = (double) r.CurrentGroup.Value;
              break;
            case 34:
              this.Normal = new WW.Math.Vector3D(this.Normal.X, this.Normal.Y, (double) r.CurrentGroup.Value);
              break;
            case 35:
              this.Location = new WW.Math.Point3D(this.Location.X, this.Location.Y, (double) r.CurrentGroup.Value);
              break;
            case 36:
              this.vector3D_1.Z = (double) r.CurrentGroup.Value;
              break;
            case 46:
              this.Rotation = (double) r.CurrentGroup.Value * (System.Math.PI / 180.0);
              break;
            case 47:
              doubleList.Add((double) r.CurrentGroup.Value);
              break;
            case 93:
              this.color_0 = MLeader.smethod_0((int) r.CurrentGroup.Value);
              break;
            case 341:
              r.method_90((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_0 = o));
              break;
          }
          r.method_85();
        }
        if (doubleList.Count < 16)
          return;
        this.matrix4D_0 = new Matrix4D((IList<double>) doubleList);
      }

      internal override void Write(DxfWriter w)
      {
        w.method_218(341, (DxfHandledObject) this.Block);
        w.Write(14, this.Normal);
        w.Write(15, this.Location);
        w.Write(16, this.vector3D_1);
        w.Write(46, (object) (this.Rotation * (180.0 / System.Math.PI)));
        w.Write(93, (object) (int) this.color_0.Data);
        w.Write(47, (object) this.matrix4D_0.M00);
        w.Write(47, (object) this.matrix4D_0.M01);
        w.Write(47, (object) this.matrix4D_0.M02);
        w.Write(47, (object) this.matrix4D_0.M03);
        w.Write(47, (object) this.matrix4D_0.M10);
        w.Write(47, (object) this.matrix4D_0.M11);
        w.Write(47, (object) this.matrix4D_0.M12);
        w.Write(47, (object) this.matrix4D_0.M13);
        w.Write(47, (object) this.matrix4D_0.M20);
        w.Write(47, (object) this.matrix4D_0.M21);
        w.Write(47, (object) this.matrix4D_0.M22);
        w.Write(47, (object) this.matrix4D_0.M23);
        w.Write(47, (object) this.matrix4D_0.M30);
        w.Write(47, (object) this.matrix4D_0.M31);
        w.Write(47, (object) this.matrix4D_0.M32);
        w.Write(47, (object) this.matrix4D_0.M33);
      }
    }

    public class ContentText : MLeader.Content
    {
      private string string_0 = string.Empty;
      private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
      private WW.Math.Vector3D vector3D_1 = WW.Math.Vector3D.XAxis;
      private double double_3 = 1.0;
      private LineSpacingStyle lineSpacingStyle_0 = LineSpacingStyle.AtLeast;
      private MLeader.TextAngleType textAngleType_0 = MLeader.TextAngleType.Horizontal;
      private Color color_0 = Color.ByLayer;
      private MLeader.TextJustification textJustification_0 = MLeader.TextJustification.Center;
      private short short_0 = 5;
      private Color color_1 = Color.None;
      private Transparency transparency_0 = Transparency.ByLayer;
      private List<double> list_0 = new List<double>();
      private double double_1;
      private double double_2;
      private bool bool_0;
      private double double_4;
      private bool bool_1;
      private bool bool_2;
      private short short_1;
      private bool bool_3;
      private double double_5;
      private double double_6;
      private bool bool_4;
      private bool bool_5;
      private bool bool_6;

      public ContentText()
      {
        this.ContentType = MLeader.ContentType.MText;
      }

      public string TextLabel
      {
        get
        {
          return this.string_0;
        }
        set
        {
          this.string_0 = value ?? string.Empty;
        }
      }

      public DxfTextStyle TextStyle
      {
        get
        {
          return (DxfTextStyle) this.dxfObjectReference_0.Value;
        }
        set
        {
          this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        }
      }

      public WW.Math.Vector3D Direction
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

      public double BoundaryWidth
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

      public double BoundaryHeight
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

      public double LineSpacingFactor
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

      public MLeader.TextAngleType TextAngleType
      {
        get
        {
          return this.textAngleType_0;
        }
        set
        {
          this.textAngleType_0 = value;
        }
      }

      public Color TextColor
      {
        get
        {
          return this.color_0;
        }
        set
        {
          this.color_0 = value;
        }
      }

      public MLeader.TextJustification Justification
      {
        get
        {
          return this.textJustification_0;
        }
        set
        {
          this.textJustification_0 = value;
        }
      }

      public short FlowDirection
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

      public bool TextFrameEnabled
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

      public Color BackgroundFillColor
      {
        get
        {
          return this.color_1;
        }
        set
        {
          this.color_1 = value;
        }
      }

      public double BackgroundScaleFactor
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

      public Transparency BackgroundTransparency
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

      public bool BackgroundFillEnabled
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

      public bool BackgroundMaskFillOn
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

      public short ColumnType
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

      public bool TextAutoHeight
      {
        get
        {
          return this.bool_3;
        }
        set
        {
          this.bool_3 = value;
        }
      }

      public double ColumnWidth
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

      public double ColumnGutter
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

      public bool ColumnFlowReversed
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

      public List<double> ColumnSizes
      {
        get
        {
          return this.list_0;
        }
      }

      public bool WordBreakEnabled
      {
        get
        {
          return this.bool_5;
        }
        set
        {
          this.bool_5 = value;
        }
      }

      public override MLeader.Content Clone(CloneContext cloneContext)
      {
        MLeader.ContentText contentText = new MLeader.ContentText();
        contentText.CopyFrom((MLeader.Content) this, cloneContext);
        return (MLeader.Content) contentText;
      }

      public override void CopyFrom(MLeader.Content from, CloneContext cloneContext)
      {
        base.CopyFrom(from, cloneContext);
        MLeader.ContentText contentText = (MLeader.ContentText) from;
        this.string_0 = contentText.string_0;
        this.TextStyle = Class906.GetTextStyle(cloneContext, contentText.TextStyle);
        this.vector3D_1 = contentText.vector3D_1;
        this.double_1 = contentText.double_1;
        this.double_2 = contentText.double_2;
        this.double_3 = contentText.double_3;
        this.lineSpacingStyle_0 = contentText.lineSpacingStyle_0;
        this.textAngleType_0 = contentText.textAngleType_0;
        this.color_0 = contentText.color_0;
        this.textJustification_0 = contentText.textJustification_0;
        this.short_0 = contentText.short_0;
        this.bool_0 = contentText.bool_0;
        this.color_1 = contentText.color_1;
        this.double_4 = contentText.double_4;
        this.transparency_0 = contentText.transparency_0;
        this.bool_1 = contentText.bool_1;
        this.bool_2 = contentText.bool_2;
        this.short_1 = contentText.short_1;
        this.bool_3 = contentText.bool_3;
        this.double_5 = contentText.double_5;
        this.double_6 = contentText.double_6;
        this.bool_4 = contentText.bool_4;
        this.list_0.Clear();
        this.list_0.AddRange((IEnumerable<double>) contentText.list_0);
        this.bool_5 = contentText.bool_5;
        this.bool_6 = contentText.bool_6;
      }

      public override void TransformMe(
        TransformConfig config,
        Matrix4D matrix,
        CommandGroup undoGroup)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        MLeader.ContentText.Class878 class878 = new MLeader.ContentText.Class878();
        // ISSUE: reference to a compiler-generated field
        class878.contentText_0 = this;
        CommandGroup undoGroup1 = (CommandGroup) null;
        if (undoGroup != null)
        {
          undoGroup1 = new CommandGroup((object) this);
          undoGroup.UndoStack.Push((ICommand) undoGroup1);
        }
        base.TransformMe(config, matrix, undoGroup1);
        // ISSUE: reference to a compiler-generated field
        class878.vector3D_0 = this.vector3D_1;
        this.vector3D_1 = matrix.Transform(this.vector3D_1);
        if (undoGroup1 == null)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup1.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new MLeader.ContentText.Class879()
        {
          class878_0 = class878,
          vector3D_0 = this.vector3D_1
        }.method_0), new System.Action(class878.method_0)));
      }

      public override string ToString()
      {
        return this.string_0;
      }

      internal string method_0(DxfMLeader mleader)
      {
        string str = this.string_0;
        if (mleader.Content.LeaderNodes.Count > 0)
        {
          bool flag = false;
          if (mleader.TextAttachmentDirection == MLeader.TextAttachmentDirection.Horizontal)
          {
            foreach (MLeader.LeaderNode leaderNode in mleader.Content.LeaderNodes)
            {
              if (leaderNode.Direction.X >= 0.0)
              {
                if (mleader.Content.TextLeftAttachment == MLeader.TextAttachment.BottomOfTopTextLineAndUnderlineAllTextLines)
                {
                  flag = true;
                  break;
                }
              }
              else if (mleader.Content.TextRightAttachment == MLeader.TextAttachment.BottomOfTopTextLineAndUnderlineAllTextLines)
              {
                flag = true;
                break;
              }
            }
          }
          if (flag)
            str = "\\L{" + str + "}";
        }
        return str;
      }

      public void UpdateLocation(
        DxfModel model,
        DxfMLeader mleader,
        MLeader.LeaderNode relativeToLeaderNode)
      {
        DxfMLeaderAnnotationContext content = mleader.Content;
        Class985 resultLayoutInfo = new Class985() { BoundsCalculationFlags = Enum36.flag_1 };
        Class666.smethod_1(this.TextLabel, this.double_1, content.TextHeight, AttachmentPoint.TopLeft, this.LineSpacingFactor, this.LineSpacingStyle, this.TextStyle ?? model.DefaultTextStyle, 1.0, Colors.White, DrawingDirection.LeftToRight, mleader.LineWeight, Matrix4D.Identity, resultLayoutInfo, Enum24.flag_0);
        WW.Math.Vector3D direction = relativeToLeaderNode.Direction;
        double num1 = 0.0;
        double num2 = direction.X >= 0.0 ? content.LandingGap : -content.LandingGap;
        if (relativeToLeaderNode.TextAttachmentDirection == MLeader.TextAttachmentDirection.Horizontal)
        {
          switch (this.textJustification_0)
          {
            case MLeader.TextJustification.Left:
              if (direction.X < 0.0)
              {
                num1 -= resultLayoutInfo.Bounds.Max.X;
                break;
              }
              break;
            case MLeader.TextJustification.Center:
              if (direction.X < 0.0)
              {
                num1 -= resultLayoutInfo.Bounds.Center.X;
                break;
              }
              num1 += resultLayoutInfo.Bounds.Center.X;
              break;
            case MLeader.TextJustification.Right:
              if (direction.X > 0.0)
              {
                num1 += resultLayoutInfo.Bounds.Max.X;
                break;
              }
              break;
          }
        }
        else
          num1 -= resultLayoutInfo.Bounds.Center.X;
        double val1 = 0.2 * content.TextHeight;
        double y = 0.0;
        MLeader.TextAttachment textAttachment = mleader.TextAttachmentDirection != MLeader.TextAttachmentDirection.Horizontal ? (direction.Y >= 0.0 ? content.TextBottomAttachment : content.TextTopAttachment) : (direction.X >= 0.0 ? content.TextLeftAttachment : content.TextRightAttachment);
        switch (textAttachment)
        {
          case MLeader.TextAttachment.TopOfTopTextLine:
            if (mleader.Content == null)
              break;
            WW.Math.Vector3D vector3D = new WW.Math.Vector3D(num1 + num2, y, 0.0);
            this.Location = relativeToLeaderNode.ConnectionPoint + relativeToLeaderNode.Direction * relativeToLeaderNode.LandingDistance + vector3D;
            if (resultLayoutInfo.FirstLineBounds != null)
            {
              content.ContentBasePoint = this.Location - new WW.Math.Vector3D(content.LandingGap, resultLayoutInfo.FirstLineBounds.Max.Y - resultLayoutInfo.FirstLineBounds.Min.Y + val1, 0.0);
              if (this.textJustification_0 == MLeader.TextJustification.Left)
              {
                content.ContentBasePoint -= new WW.Math.Vector3D(0.0, 0.0, 0.0);
                break;
              }
              if (this.textJustification_0 == MLeader.TextJustification.Right)
              {
                content.ContentBasePoint -= new WW.Math.Vector3D(resultLayoutInfo.Bounds.Delta.X, 0.0, 0.0);
                break;
              }
              if (this.textJustification_0 != MLeader.TextJustification.Center)
                break;
              content.ContentBasePoint -= new WW.Math.Vector3D(0.5 * resultLayoutInfo.Bounds.Delta.X, 0.0, 0.0);
              break;
            }
            content.ContentBasePoint = this.Location;
            break;
          case MLeader.TextAttachment.MiddleOfTopTextLine:
            if (resultLayoutInfo.FirstLineBounds != null)
            {
              y -= resultLayoutInfo.FirstLineBounds.Center.Y;
              goto case MLeader.TextAttachment.TopOfTopTextLine;
            }
            else
              goto case MLeader.TextAttachment.TopOfTopTextLine;
          case MLeader.TextAttachment.Middle:
            y -= resultLayoutInfo.Bounds.Center.Y;
            goto case MLeader.TextAttachment.TopOfTopTextLine;
          case MLeader.TextAttachment.MiddleOfBottomTextLine:
            if (resultLayoutInfo.LastLineBounds != null)
            {
              y -= resultLayoutInfo.LastLineBounds.Center.Y;
              goto case MLeader.TextAttachment.TopOfTopTextLine;
            }
            else
              goto case MLeader.TextAttachment.TopOfTopTextLine;
          case MLeader.TextAttachment.BottomOfBottomTextLine:
            if (resultLayoutInfo.LastLineBounds != null)
            {
              val1 = System.Math.Max(val1, -resultLayoutInfo.LastLineDescent);
              y += -resultLayoutInfo.LastLineBounds.Min.Y + val1;
              goto case MLeader.TextAttachment.TopOfTopTextLine;
            }
            else
              goto case MLeader.TextAttachment.TopOfTopTextLine;
          case MLeader.TextAttachment.BottomOfBottomTextLineAndUnderline:
            if (resultLayoutInfo.LastLineBounds != null)
            {
              val1 = System.Math.Max(val1, -resultLayoutInfo.LastLineDescent);
              y += -resultLayoutInfo.LastLineBounds.Min.Y + val1;
              goto case MLeader.TextAttachment.TopOfTopTextLine;
            }
            else
              goto case MLeader.TextAttachment.TopOfTopTextLine;
          case MLeader.TextAttachment.BottomOfTopTextLineAndUnderline:
            if (resultLayoutInfo.FirstLineBounds != null)
            {
              val1 = System.Math.Max(val1, -resultLayoutInfo.FirstLineDescent);
              y += -resultLayoutInfo.FirstLineBounds.Min.Y + val1;
              goto case MLeader.TextAttachment.TopOfTopTextLine;
            }
            else
              goto case MLeader.TextAttachment.TopOfTopTextLine;
          case MLeader.TextAttachment.BottomOfTopTextLine:
            if (resultLayoutInfo.FirstLineBounds != null)
            {
              val1 = System.Math.Max(val1, -resultLayoutInfo.FirstLineDescent);
              y += -resultLayoutInfo.FirstLineBounds.Min.Y + val1;
              goto case MLeader.TextAttachment.TopOfTopTextLine;
            }
            else
              goto case MLeader.TextAttachment.TopOfTopTextLine;
          case MLeader.TextAttachment.BottomOfTopTextLineAndUnderlineAllTextLines:
            if (resultLayoutInfo.FirstLineBounds != null)
            {
              y += -resultLayoutInfo.FirstLineBounds.Min.Y + val1;
              goto case MLeader.TextAttachment.TopOfTopTextLine;
            }
            else
              goto case MLeader.TextAttachment.TopOfTopTextLine;
          case MLeader.TextAttachment.Center:
          case MLeader.TextAttachment.CenterAndOverlineTopOrUnderlineBottomTextLine:
            if (direction.Y < 0.0)
            {
              y -= resultLayoutInfo.Bounds.Min.Y;
              goto case MLeader.TextAttachment.TopOfTopTextLine;
            }
            else
              goto case MLeader.TextAttachment.TopOfTopTextLine;
          default:
            throw new Exception("Unsupported text attachment " + (object) textAttachment + ".");
        }
      }

      internal bool Unknown1
      {
        get
        {
          return this.bool_6;
        }
        set
        {
          this.bool_6 = value;
        }
      }

      internal void Read(Class434 or)
      {
        Interface30 objectBitStream = or.ObjectBitStream;
        this.string_0 = objectBitStream.ReadString();
        this.Normal = objectBitStream.imethod_51();
        or.method_78((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_0 = o));
        this.Location = objectBitStream.imethod_39();
        this.vector3D_1 = objectBitStream.imethod_51();
        this.Rotation = objectBitStream.imethod_8();
        this.double_1 = objectBitStream.imethod_8();
        this.double_2 = objectBitStream.imethod_8();
        this.double_3 = objectBitStream.imethod_8();
        this.lineSpacingStyle_0 = (LineSpacingStyle) objectBitStream.imethod_14();
        this.color_0 = objectBitStream.imethod_22();
        this.textJustification_0 = (MLeader.TextJustification) objectBitStream.imethod_14();
        this.short_0 = objectBitStream.imethod_14();
        this.color_1 = objectBitStream.imethod_22();
        this.double_4 = objectBitStream.imethod_8();
        this.transparency_0 = new Transparency((uint) objectBitStream.imethod_11());
        this.bool_1 = objectBitStream.imethod_6();
        this.bool_2 = objectBitStream.imethod_6();
        this.short_1 = objectBitStream.imethod_14();
        this.bool_3 = objectBitStream.imethod_6();
        this.double_5 = objectBitStream.imethod_8();
        this.double_6 = objectBitStream.imethod_8();
        this.bool_4 = objectBitStream.imethod_6();
        int num = objectBitStream.imethod_11();
        for (int index = 0; index < num; ++index)
          this.list_0.Add(objectBitStream.imethod_8());
        this.bool_5 = objectBitStream.imethod_6();
        this.bool_6 = objectBitStream.imethod_6();
      }

      internal override void Write(Class432 ow)
      {
        Interface29 objectWriter = ow.ObjectWriter;
        objectWriter.imethod_4(this.string_0);
        objectWriter.imethod_29(this.Normal);
        objectWriter.imethod_41((DxfHandledObject) this.TextStyle);
        objectWriter.imethod_24(this.Location);
        objectWriter.imethod_29(this.vector3D_1);
        objectWriter.imethod_16(this.Rotation);
        objectWriter.imethod_16(this.double_1);
        objectWriter.imethod_16(this.double_2);
        objectWriter.imethod_16(this.double_3);
        objectWriter.imethod_32((short) this.lineSpacingStyle_0);
        objectWriter.imethod_6(this.color_0);
        objectWriter.imethod_32((short) this.textJustification_0);
        objectWriter.imethod_32(this.short_0);
        objectWriter.imethod_6(this.color_1);
        objectWriter.imethod_16(this.double_4);
        objectWriter.imethod_33((int) this.transparency_0.Data);
        objectWriter.imethod_14(this.bool_1);
        objectWriter.imethod_14(this.bool_2);
        objectWriter.imethod_32(this.short_1);
        objectWriter.imethod_14(this.bool_3);
        objectWriter.imethod_16(this.double_5);
        objectWriter.imethod_16(this.double_6);
        objectWriter.imethod_14(this.bool_4);
        objectWriter.imethod_33(this.list_0.Count);
        foreach (double num in this.list_0)
          objectWriter.imethod_16(num);
        objectWriter.imethod_14(this.bool_5);
        objectWriter.imethod_14(this.bool_6);
      }

      internal void Read(DxfReader r, int endGroupCode)
      {
        while (r.CurrentGroup.Code != endGroupCode)
        {
          switch (r.CurrentGroup.Code)
          {
            case 11:
              this.Normal = new WW.Math.Vector3D((double) r.CurrentGroup.Value, this.Normal.Y, this.Normal.Z);
              break;
            case 12:
              this.Location = new WW.Math.Point3D((double) r.CurrentGroup.Value, this.Location.Y, this.Location.Z);
              break;
            case 13:
              this.vector3D_1.X = (double) r.CurrentGroup.Value;
              break;
            case 21:
              this.Normal = new WW.Math.Vector3D(this.Normal.X, (double) r.CurrentGroup.Value, this.Normal.Z);
              break;
            case 22:
              this.Location = new WW.Math.Point3D(this.Location.X, (double) r.CurrentGroup.Value, this.Location.Z);
              break;
            case 23:
              this.vector3D_1.Y = (double) r.CurrentGroup.Value;
              break;
            case 31:
              this.Normal = new WW.Math.Vector3D(this.Normal.X, this.Normal.Y, (double) r.CurrentGroup.Value);
              break;
            case 32:
              this.Location = new WW.Math.Point3D(this.Location.X, this.Location.Y, (double) r.CurrentGroup.Value);
              break;
            case 33:
              this.vector3D_1.Z = (double) r.CurrentGroup.Value;
              break;
            case 42:
              this.Rotation = (double) r.CurrentGroup.Value * (System.Math.PI / 180.0);
              break;
            case 43:
              this.double_1 = (double) r.CurrentGroup.Value;
              break;
            case 44:
              this.double_2 = (double) r.CurrentGroup.Value;
              break;
            case 45:
              this.double_3 = (double) r.CurrentGroup.Value;
              break;
            case 90:
              this.color_0 = MLeader.smethod_0((int) r.CurrentGroup.Value);
              break;
            case 91:
              this.color_1 = MLeader.smethod_0((int) r.CurrentGroup.Value);
              break;
            case 92:
              this.transparency_0 = new Transparency((uint) (int) r.CurrentGroup.Value);
              break;
            case 141:
              this.double_4 = (double) r.CurrentGroup.Value;
              break;
            case 142:
              this.double_5 = (double) r.CurrentGroup.Value;
              break;
            case 143:
              this.double_6 = (double) r.CurrentGroup.Value;
              break;
            case 144:
              this.list_0.Add((double) r.CurrentGroup.Value);
              break;
            case 170:
              this.lineSpacingStyle_0 = (LineSpacingStyle) r.CurrentGroup.Value;
              break;
            case 171:
              this.textJustification_0 = (MLeader.TextJustification) r.CurrentGroup.Value;
              break;
            case 172:
              this.short_0 = (short) r.CurrentGroup.Value;
              break;
            case 173:
              this.short_1 = (short) r.CurrentGroup.Value;
              break;
            case 291:
              this.bool_1 = (bool) r.CurrentGroup.Value;
              break;
            case 292:
              this.bool_2 = (bool) r.CurrentGroup.Value;
              break;
            case 293:
              this.bool_3 = (bool) r.CurrentGroup.Value;
              break;
            case 294:
              this.bool_4 = (bool) r.CurrentGroup.Value;
              break;
            case 295:
              this.bool_5 = (bool) r.CurrentGroup.Value;
              break;
            case 304:
              this.string_0 = (string) r.CurrentGroup.Value;
              break;
            case 340:
              r.method_90((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_0 = o));
              break;
          }
          r.method_85();
        }
      }

      internal override void Write(DxfWriter w)
      {
        w.Write(304, (object) this.string_0);
        w.Write(11, this.Normal);
        w.method_218(340, (DxfHandledObject) (this.TextStyle ?? w.Model.DefaultTextStyle));
        w.Write(12, this.Location);
        w.Write(13, this.vector3D_1);
        w.Write(42, (object) (this.Rotation * (180.0 / System.Math.PI)));
        w.Write(43, (object) this.double_1);
        w.Write(44, (object) this.double_2);
        w.Write(45, (object) this.double_3);
        w.Write(170, (object) (short) this.lineSpacingStyle_0);
        w.Write(90, (object) (int) this.color_0.Data);
        w.Write(171, (object) (short) this.textJustification_0);
        w.Write(172, (object) this.short_0);
        w.Write(91, (object) (int) this.color_1.Data);
        w.Write(141, (object) this.double_4);
        w.Write(92, (object) (int) this.transparency_0.Data);
        w.Write(291, (object) this.bool_1);
        w.Write(292, (object) this.bool_2);
        w.Write(173, (object) this.short_1);
        w.Write(293, (object) this.bool_3);
        w.Write(142, (object) this.double_5);
        w.Write(143, (object) this.double_6);
        w.Write(294, (object) this.bool_4);
        foreach (double num in this.list_0)
          w.Write(144, (object) num);
        w.Write(295, (object) this.bool_5);
      }
    }

    public class Label
    {
      private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
      private string string_0 = string.Empty;
      private short short_0;
      private double double_0;

      public DxfAttributeDefinition AttributeDefinition
      {
        get
        {
          return (DxfAttributeDefinition) this.dxfObjectReference_0.Value;
        }
        set
        {
          this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        }
      }

      public string Text
      {
        get
        {
          return this.string_0;
        }
        set
        {
          this.string_0 = value ?? string.Empty;
        }
      }

      public short UiIndex
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

      public double Width
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

      public MLeader.Label Clone(CloneContext cloneContext)
      {
        MLeader.Label label = new MLeader.Label();
        label.CopyFrom(this, cloneContext);
        return label;
      }

      public void CopyFrom(MLeader.Label from, CloneContext cloneContext)
      {
        this.AttributeDefinition = (DxfAttributeDefinition) cloneContext.Clone((IGraphCloneable) from.AttributeDefinition);
        this.string_0 = from.string_0;
        this.short_0 = from.short_0;
        this.double_0 = from.double_0;
      }

      public override string ToString()
      {
        return this.string_0;
      }

      internal void Read(Class434 or)
      {
        Interface30 objectBitStream = or.ObjectBitStream;
        or.method_78((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_0 = o));
        this.string_0 = objectBitStream.ReadString();
        this.short_0 = objectBitStream.imethod_14();
        this.double_0 = objectBitStream.imethod_8();
      }

      internal void Write(Class432 ow)
      {
        Interface29 objectWriter = ow.ObjectWriter;
        objectWriter.imethod_40((DxfHandledObject) this.AttributeDefinition);
        objectWriter.imethod_4(this.string_0);
        objectWriter.imethod_32(this.short_0);
        objectWriter.imethod_16(this.double_0);
      }

      internal void Read(DxfReader r)
      {
        int num = 4;
        do
        {
          switch (r.CurrentGroup.Code)
          {
            case 44:
              this.double_0 = (double) r.CurrentGroup.Value;
              break;
            case 177:
              this.short_0 = (short) r.CurrentGroup.Value;
              break;
            case 302:
              this.string_0 = (string) r.CurrentGroup.Value;
              break;
            case 330:
              r.method_90((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_0 = o));
              break;
          }
          r.method_85();
          --num;
        }
        while (num > 0);
      }

      internal void Write(DxfWriter w)
      {
        w.method_218(330, (DxfHandledObject) this.AttributeDefinition);
        w.Write(177, (object) this.short_0);
        w.Write(44, (object) this.double_0);
        w.Write(302, (object) this.string_0);
      }
    }

    public class ArrowHead
    {
      private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
      private bool bool_0;

      public bool IsDefault
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

      public DxfBlock ArrowHeadBlock
      {
        get
        {
          return (DxfBlock) this.dxfObjectReference_0.Value;
        }
        set
        {
          this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        }
      }

      public MLeader.ArrowHead Clone(CloneContext cloneContext)
      {
        MLeader.ArrowHead arrowHead = new MLeader.ArrowHead();
        arrowHead.CopyFrom(this, cloneContext);
        return arrowHead;
      }

      public void CopyFrom(MLeader.ArrowHead from, CloneContext cloneContext)
      {
        this.bool_0 = from.bool_0;
        this.ArrowHeadBlock = Class906.smethod_0(cloneContext, from.ArrowHeadBlock, false);
      }

      internal void Read(Class434 or)
      {
        this.bool_0 = or.ObjectBitStream.imethod_6();
        or.method_78((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_0 = o));
      }

      internal void Write(Class432 ow)
      {
        Interface29 objectWriter = ow.ObjectWriter;
        objectWriter.imethod_14(this.bool_0);
        objectWriter.imethod_41((DxfHandledObject) this.ArrowHeadBlock);
      }

      internal void Write(DxfWriter w)
      {
        w.Write(94, (object) (this.bool_0 ? 1 : 0));
        w.method_218(345, (DxfHandledObject) this.ArrowHeadBlock);
      }
    }

    internal class Class880 : ILeader
    {
      private readonly DxfMLeader dxfMLeader_0;
      private readonly MLeader.LeaderNode leaderNode_0;
      private readonly MLeader.LeaderLine leaderLine_0;
      private readonly List<WW.Math.Point3D> list_0;
      private readonly HookLineDirection hookLineDirection_0;

      public Class880(
        DxfMLeader mleader,
        MLeader.LeaderNode leaderNode,
        MLeader.LeaderLine leaderLine)
      {
        this.dxfMLeader_0 = mleader;
        this.leaderNode_0 = leaderNode;
        this.leaderLine_0 = leaderLine;
        this.list_0 = new List<WW.Math.Point3D>(1 + leaderLine.Points.Count);
        this.list_0.AddRange((IEnumerable<WW.Math.Point3D>) leaderLine.Points);
        if (mleader.LeaderType == MLeader.LeaderType.Straight)
          this.list_0.Add(leaderNode.ConnectionPoint);
        if (mleader.LeaderType == MLeader.LeaderType.Spline && leaderNode.LandingDistance != 0.0)
          this.list_0.Add(leaderNode.LandingPoint);
        if (this.list_0.Count > 1)
          this.hookLineDirection_0 = WW.Math.Vector3D.DotProduct(this.list_0[1] - this.list_0[0], leaderNode.Direction) >= 0.0 ? HookLineDirection.Same : HookLineDirection.Opposite;
        else
          this.hookLineDirection_0 = HookLineDirection.Same;
      }

      public List<WW.Math.Point3D> Vertices
      {
        get
        {
          return this.list_0;
        }
      }

      public bool IsSpline
      {
        get
        {
          return this.dxfMLeader_0.LeaderType == MLeader.LeaderType.Spline;
        }
      }

      public WW.Math.Vector3D Direction
      {
        get
        {
          return -this.leaderNode_0.Direction;
        }
      }

      public bool ArrowHeadEnabled
      {
        get
        {
          return this.dxfMLeader_0.ArrowHeadSize != 0.0;
        }
      }

      public double ArrowSize
      {
        get
        {
          return this.leaderLine_0.GetArrowSize(this.dxfMLeader_0);
        }
      }

      public double GetEffectiveArrowSize()
      {
        return this.ArrowSize;
      }

      public DxfBlock LeaderArrowBlock
      {
        get
        {
          return this.leaderLine_0.GetArrowSymbolBlock(this.dxfMLeader_0);
        }
      }

      public bool HasHookLine
      {
        get
        {
          return false;
        }
      }

      public HookLineDirection HookLineDirection
      {
        get
        {
          return this.hookLineDirection_0;
        }
      }

      public void imethod_0(
        DrawContext context,
        IList<WW.Math.Point3D> points,
        IList<WW.Math.Point3D> flattenedPolyline)
      {
      }
    }

    [Flags]
    public enum LeaderLineOverrideFlags
    {
      None = 0,
      LeaderType = 1,
      LineColor = 2,
      LineType = 4,
      LineWeight = 8,
      ArrowSize = 16, // 0x00000010
      ArrowSymbolBlock = 32, // 0x00000020
    }

    public enum LeaderType : short
    {
      None,
      Straight,
      Spline,
    }

    public enum DrawMLeaderOrder : short
    {
      DrawContentFirst,
      DrawLeaderFirst,
    }

    public enum DrawLeaderOrder : short
    {
      DrawLeaderHeadFirst,
      DrawLeaderTailFirst,
    }

    public enum ContentType : short
    {
      None,
      Block,
      MText,
      Tolerance,
    }

    public enum TextAttachment
    {
      TopOfTopTextLine,
      MiddleOfTopTextLine,
      Middle,
      MiddleOfBottomTextLine,
      BottomOfBottomTextLine,
      BottomOfBottomTextLineAndUnderline,
      BottomOfTopTextLineAndUnderline,
      BottomOfTopTextLine,
      BottomOfTopTextLineAndUnderlineAllTextLines,
      Center,
      CenterAndOverlineTopOrUnderlineBottomTextLine,
    }

    public enum TextAlignment : short
    {
      Left,
      Center,
      Right,
    }

    public enum TextJustification : short
    {
      Left = 1,
      Center = 2,
      Right = 3,
    }

    public enum TextAngleType : short
    {
      SameAsLastLeaderSegment,
      Horizontal,
      SameAsLastLeaderSegmentAlwaysReadable,
    }

    public enum BlockConnectionType : short
    {
      BlockExtents,
      BlockBasePoint,
    }

    public enum TextAttachmentDirection : short
    {
      Horizontal,
      Vertical,
    }

    [Flags]
    public enum PropertyOverrideFlags
    {
      None = 0,
      LeaderLineType = 1,
      LeaderLineColor = 2,
      LineType = 4,
      LeaderLineWeight = 8,
      LandingEnabled = 16, // 0x00000010
      LandingGap = 32, // 0x00000020
      DogLegEnabled = 64, // 0x00000040
      DogLegLength = 128, // 0x00000080
      ArrowHeadBlock = 256, // 0x00000100
      ArrowSize = 512, // 0x00000200
      ContentType = 1024, // 0x00000400
      TextStyle = 2048, // 0x00000800
      TextLeftAttachment = 4096, // 0x00001000
      TextAngleType = 8192, // 0x00002000
      TextAlignment = 16384, // 0x00004000
      TextColor = 32768, // 0x00008000
      TextHeight = 65536, // 0x00010000
      TextFrameEnabled = 131072, // 0x00020000
      DefaultMText = 262144, // 0x00040000
      Block = 524288, // 0x00080000
      BlockColor = 1048576, // 0x00100000
      BlockScale = 2097152, // 0x00200000
      BlockRotation = 4194304, // 0x00400000
      BlockConnectionType = 8388608, // 0x00800000
      Scale = 16777216, // 0x01000000
      TextRightAttachment = 33554432, // 0x02000000
      TextSwitchAlignment = 67108864, // 0x04000000
      TextAttachmentDirection = 134217728, // 0x08000000
      TextTopAttachment = 268435456, // 0x10000000
      TextBottomAttachment = 536870912, // 0x20000000
      ExtendLeaderToText = 1073741824, // 0x40000000
    }

    public enum BlockAttachment : short
    {
      CenterExtents,
      InsertionPoint,
    }
  }
}
