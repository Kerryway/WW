// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.Annotations.DxfMLeaderAnnotationContext
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using ns3;
using System;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Drawing;
using WW.Cad.IO;
using WW.Cad.Model.Entities;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Objects.Annotations
{
  public class DxfMLeaderAnnotationContext : DxfAnnotationScaleObjectContextData
  {
    private List<MLeader.LeaderNode> list_0 = new List<MLeader.LeaderNode>();
    private double double_0 = 1.0;
    private double double_1 = 0.18;
    private double double_2 = 0.18;
    private double double_3 = 0.09;
    private MLeader.TextAttachment textAttachment_0 = MLeader.TextAttachment.MiddleOfTopTextLine;
    private MLeader.TextAttachment textAttachment_1 = MLeader.TextAttachment.MiddleOfTopTextLine;
    private WW.Math.Vector3D vector3D_0 = WW.Math.Vector3D.XAxis;
    private WW.Math.Vector3D vector3D_1 = WW.Math.Vector3D.YAxis;
    private MLeader.TextAttachment textAttachment_2 = MLeader.TextAttachment.Center;
    private MLeader.TextAttachment textAttachment_3 = MLeader.TextAttachment.Center;
    private WW.Math.Point3D point3D_0;
    private MLeader.TextAlignment textAlignment_0;
    private MLeader.BlockAttachment blockAttachment_0;
    private bool bool_1;
    private bool bool_2;
    private Plane3D plane3D_0;
    private WW.Math.Point3D point3D_1;
    private bool bool_3;
    private MLeader.ContentType contentType_0;
    private MLeader.Content content_0;

    public List<MLeader.LeaderNode> LeaderNodes
    {
      get
      {
        return this.list_0;
      }
    }

    public double ScaleOverall
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

    public WW.Math.Point3D ContentBasePoint
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

    public double TextHeight
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

    public double ArrowHeadSize
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

    public double LandingGap
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

    public MLeader.TextAttachment TextLeftAttachment
    {
      get
      {
        return this.textAttachment_0;
      }
      set
      {
        this.textAttachment_0 = value;
      }
    }

    public MLeader.TextAttachment TextRightAttachment
    {
      get
      {
        return this.textAttachment_1;
      }
      set
      {
        this.textAttachment_1 = value;
      }
    }

    public MLeader.TextAlignment TextAlignment
    {
      get
      {
        return this.textAlignment_0;
      }
      set
      {
        this.textAlignment_0 = value;
      }
    }

    public MLeader.BlockAttachment BlockAttachment
    {
      get
      {
        return this.blockAttachment_0;
      }
      set
      {
        this.blockAttachment_0 = value;
      }
    }

    public bool HasTextContent
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

    public bool HasBlockContent
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

    public Plane3D Plane
    {
      get
      {
        return this.plane3D_0;
      }
      set
      {
        this.plane3D_0 = value;
      }
    }

    public WW.Math.Point3D BasePoint
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

    public WW.Math.Vector3D BaseDirection
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

    public WW.Math.Vector3D BaseVertical
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

    public bool IsNormalReversed
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

    public MLeader.TextAttachment TextTopAttachment
    {
      get
      {
        return this.textAttachment_2;
      }
      set
      {
        this.textAttachment_2 = value;
      }
    }

    public MLeader.TextAttachment TextBottomAttachment
    {
      get
      {
        return this.textAttachment_3;
      }
      set
      {
        this.textAttachment_3 = value;
      }
    }

    public MLeader.Content Content
    {
      get
      {
        return this.content_0;
      }
      set
      {
        this.content_0 = value;
        this.contentType_0 = value != null ? this.content_0.ContentType : MLeader.ContentType.None;
        if (this.contentType_0 == MLeader.ContentType.None)
        {
          this.bool_2 = false;
          this.bool_1 = false;
        }
        else
        {
          this.bool_2 = this.contentType_0 == MLeader.ContentType.Block;
          this.bool_1 = this.contentType_0 == MLeader.ContentType.MText;
        }
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfMLeaderAnnotationContext annotationContext = (DxfMLeaderAnnotationContext) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (annotationContext == null)
      {
        annotationContext = new DxfMLeaderAnnotationContext();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) annotationContext);
        annotationContext.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) annotationContext;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      this.method_8((DxfMLeaderAnnotationContext) from, cloneContext);
    }

    private void method_8(DxfMLeaderAnnotationContext from, CloneContext cloneContext)
    {
      this.list_0.Clear();
      foreach (MLeader.LeaderNode leaderNode in from.list_0)
        this.list_0.Add(leaderNode.Clone(cloneContext));
      this.double_0 = from.double_0;
      this.point3D_0 = from.point3D_0;
      this.double_1 = from.double_1;
      this.double_2 = from.double_2;
      this.double_3 = from.double_3;
      this.textAttachment_0 = from.textAttachment_0;
      this.textAttachment_1 = from.textAttachment_1;
      this.blockAttachment_0 = from.blockAttachment_0;
      this.bool_1 = from.bool_1;
      this.bool_2 = from.bool_2;
      this.plane3D_0 = from.plane3D_0;
      this.point3D_1 = from.point3D_1;
      this.vector3D_0 = from.vector3D_0;
      this.vector3D_1 = from.vector3D_1;
      this.bool_3 = from.bool_3;
      this.contentType_0 = from.contentType_0;
      this.textAttachment_2 = from.textAttachment_2;
      this.textAttachment_3 = from.textAttachment_3;
      if (from.content_0 == null)
        this.content_0 = (MLeader.Content) null;
      else if (this.content_0 != null && !(this.content_0.GetType() != from.content_0.GetType()))
        this.content_0.CopyFrom(from.content_0, cloneContext);
      else
        this.content_0 = from.content_0.Clone(cloneContext);
    }

    public void TransformMe(TransformConfig config, Matrix4D matrix, CommandGroup undoGroup)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfMLeaderAnnotationContext.Class358 class358 = new DxfMLeaderAnnotationContext.Class358();
      // ISSUE: reference to a compiler-generated field
      class358.dxfMLeaderAnnotationContext_0 = this;
      // ISSUE: reference to a compiler-generated field
      class358.point3D_0 = this.point3D_1;
      // ISSUE: reference to a compiler-generated field
      class358.vector3D_0 = this.vector3D_0;
      // ISSUE: reference to a compiler-generated field
      class358.vector3D_1 = this.vector3D_1;
      this.point3D_1 = matrix.Transform(this.point3D_1);
      this.vector3D_0 = matrix.Transform(this.vector3D_0);
      this.vector3D_1 = matrix.Transform(this.vector3D_1);
      CommandGroup undoGroup1 = (CommandGroup) null;
      if (undoGroup != null)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup1 = new CommandGroup((object) this, new ICommand[1]
        {
          (ICommand) new Command((object) this, new System.Action(new DxfMLeaderAnnotationContext.Class359()
          {
            class358_0 = class358,
            point3D_0 = this.point3D_1,
            vector3D_0 = this.vector3D_0,
            vector3D_1 = this.vector3D_1
          }.method_0), new System.Action(class358.method_0))
        });
        undoGroup.UndoStack.Push((ICommand) undoGroup1);
      }
      foreach (MLeader.LeaderNode leaderNode in this.list_0)
        leaderNode.TransformMe(config, matrix, undoGroup1);
      if (this.content_0 == null)
        return;
      this.content_0.TransformMe(config, matrix, undoGroup1);
    }

    [Obsolete]
    internal MLeader.TextAttachment method_9(DxfMLeader mleader)
    {
      bool flag;
      MLeader.TextAttachment textAttachment = (flag = mleader.TextAttachmentDirection == MLeader.TextAttachmentDirection.Horizontal) ? this.TextRightAttachment : this.TextTopAttachment;
      if (this.LeaderNodes.Count > 0)
      {
        WW.Math.Vector3D direction = this.LeaderNodes[0].Direction;
        textAttachment = !flag ? (direction.X >= 0.0 ? this.TextLeftAttachment : this.TextRightAttachment) : (direction.Y >= 0.0 ? this.TextBottomAttachment : this.TextTopAttachment);
      }
      return textAttachment;
    }

    internal override void Read(Class434 or, Class259 ob)
    {
      base.Read(or, ob);
      this.method_10(or, ob);
    }

    internal void method_10(Class434 or, Class259 ob)
    {
      Interface30 objectBitStream = or.ObjectBitStream;
      int num = objectBitStream.imethod_11();
      for (int index = 0; index < num; ++index)
      {
        MLeader.LeaderNode leaderNode = new MLeader.LeaderNode();
        leaderNode.Read(or);
        this.list_0.Add(leaderNode);
      }
      this.double_0 = objectBitStream.imethod_8();
      this.point3D_0 = objectBitStream.imethod_39();
      this.double_1 = objectBitStream.imethod_8();
      this.double_2 = objectBitStream.imethod_8();
      this.double_3 = objectBitStream.imethod_8();
      this.textAttachment_0 = (MLeader.TextAttachment) objectBitStream.imethod_14();
      this.textAttachment_1 = (MLeader.TextAttachment) objectBitStream.imethod_14();
      this.textAlignment_0 = (MLeader.TextAlignment) objectBitStream.imethod_14();
      this.blockAttachment_0 = (MLeader.BlockAttachment) objectBitStream.imethod_14();
      this.bool_1 = objectBitStream.imethod_6();
      if (this.bool_1)
      {
        MLeader.ContentText contentText = new MLeader.ContentText();
        contentText.Read(or);
        this.content_0 = (MLeader.Content) contentText;
      }
      else
      {
        this.bool_2 = objectBitStream.imethod_6();
        if (this.bool_2)
        {
          MLeader.ContentBlock contentBlock = new MLeader.ContentBlock();
          contentBlock.Read(or);
          this.content_0 = (MLeader.Content) contentBlock;
        }
      }
      this.point3D_1 = objectBitStream.imethod_39();
      this.vector3D_0 = objectBitStream.imethod_51();
      this.vector3D_1 = objectBitStream.imethod_51();
      this.bool_3 = objectBitStream.imethod_6();
      if (or.Builder.Version <= DxfVersion.Dxf21)
        return;
      this.textAttachment_3 = (MLeader.TextAttachment) objectBitStream.imethod_14();
      this.textAttachment_2 = (MLeader.TextAttachment) objectBitStream.imethod_14();
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      this.WriteMyFields(ow);
    }

    internal void WriteMyFields(Class432 ow)
    {
      Interface29 objectWriter = ow.ObjectWriter;
      objectWriter.imethod_33(this.list_0.Count);
      foreach (MLeader.LeaderNode leaderNode in this.list_0)
        leaderNode.Write(ow);
      objectWriter.imethod_16(this.double_0);
      objectWriter.imethod_24(this.point3D_0);
      objectWriter.imethod_16(this.double_1);
      objectWriter.imethod_16(this.double_2);
      objectWriter.imethod_16(this.double_3);
      objectWriter.imethod_32((short) this.textAttachment_0);
      objectWriter.imethod_32((short) this.textAttachment_1);
      objectWriter.imethod_32((short) this.textAlignment_0);
      objectWriter.imethod_32((short) this.blockAttachment_0);
      objectWriter.imethod_14(this.bool_1);
      if (this.bool_1)
      {
        if (!(this.content_0 is MLeader.ContentText))
          throw new Exception("Content is not of type ContentText.");
        this.content_0.Write(ow);
      }
      else
      {
        objectWriter.imethod_14(this.bool_2);
        if (this.bool_2)
        {
          if (!(this.content_0 is MLeader.ContentBlock))
            throw new Exception("Content is not of type ContentBlock.");
          this.content_0.Write(ow);
        }
      }
      objectWriter.imethod_24(this.point3D_1);
      objectWriter.imethod_29(this.vector3D_0);
      objectWriter.imethod_29(this.vector3D_1);
      objectWriter.imethod_14(this.bool_3);
      if (objectWriter.Version <= DxfVersion.Dxf21)
        return;
      objectWriter.imethod_32((short) this.textAttachment_2);
      objectWriter.imethod_32((short) this.textAttachment_3);
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      base.Read(r, objectBuilder);
      this.method_11(r, objectBuilder, true);
    }

    internal void method_11(DxfReader r, Class259 objectBuilder, bool readBrackets)
    {
      if (readBrackets)
      {
        if (r.CurrentGroup.Code == 300)
        {
          if ((string) r.CurrentGroup.Value != "CONTEXT_DATA{")
            throw new Exception("Expected CONTEXT_DATA{, but got " + r.CurrentGroup.Value + " instead.");
          r.method_85();
        }
        else
          readBrackets = false;
      }
      while (true)
      {
        bool flag;
        do
        {
          Struct18 currentGroup = r.CurrentGroup;
          if (r.CurrentGroup.Code != 301 || !((string) r.CurrentGroup.Value == "}"))
          {
            flag = true;
            switch (r.CurrentGroup.Code)
            {
              case 10:
                this.point3D_0.X = (double) r.CurrentGroup.Value;
                break;
              case 20:
                this.point3D_0.Y = (double) r.CurrentGroup.Value;
                break;
              case 30:
                this.point3D_0.Z = (double) r.CurrentGroup.Value;
                break;
              case 40:
                this.double_0 = (double) r.CurrentGroup.Value;
                break;
              case 41:
                this.double_1 = (double) r.CurrentGroup.Value;
                break;
              case 110:
                this.point3D_1.X = (double) r.CurrentGroup.Value;
                break;
              case 111:
                this.vector3D_0.X = (double) r.CurrentGroup.Value;
                break;
              case 112:
                this.vector3D_1.X = (double) r.CurrentGroup.Value;
                break;
              case 120:
                this.point3D_1.Y = (double) r.CurrentGroup.Value;
                break;
              case 121:
                this.vector3D_0.Y = (double) r.CurrentGroup.Value;
                break;
              case 122:
                this.vector3D_1.Y = (double) r.CurrentGroup.Value;
                break;
              case 130:
                this.point3D_1.Z = (double) r.CurrentGroup.Value;
                break;
              case 131:
                this.vector3D_0.Z = (double) r.CurrentGroup.Value;
                break;
              case 132:
                this.vector3D_1.Z = (double) r.CurrentGroup.Value;
                break;
              case 140:
                this.double_2 = (double) r.CurrentGroup.Value;
                break;
              case 145:
                this.double_3 = (double) r.CurrentGroup.Value;
                break;
              case 174:
                this.textAttachment_0 = (MLeader.TextAttachment) (short) r.CurrentGroup.Value;
                break;
              case 175:
                this.textAttachment_1 = (MLeader.TextAttachment) (short) r.CurrentGroup.Value;
                break;
              case 176:
                this.textAlignment_0 = (MLeader.TextAlignment) r.CurrentGroup.Value;
                break;
              case 177:
                this.blockAttachment_0 = (MLeader.BlockAttachment) r.CurrentGroup.Value;
                break;
              case 272:
                this.textAttachment_3 = (MLeader.TextAttachment) (short) r.CurrentGroup.Value;
                break;
              case 273:
                this.textAttachment_2 = (MLeader.TextAttachment) (short) r.CurrentGroup.Value;
                break;
              case 290:
                this.bool_1 = (bool) r.CurrentGroup.Value;
                if (this.bool_1)
                {
                  r.method_85();
                  MLeader.ContentText contentText = new MLeader.ContentText();
                  contentText.Read(r, 296);
                  flag = false;
                  this.content_0 = (MLeader.Content) contentText;
                  break;
                }
                break;
              case 296:
                this.bool_2 = (bool) r.CurrentGroup.Value;
                if (this.bool_2)
                {
                  r.method_85();
                  MLeader.ContentBlock contentBlock = new MLeader.ContentBlock();
                  contentBlock.Read(r);
                  flag = false;
                  this.content_0 = (MLeader.Content) contentBlock;
                  break;
                }
                break;
              case 297:
                this.bool_3 = (bool) r.CurrentGroup.Value;
                break;
              case 302:
                if ((string) r.CurrentGroup.Value == "LEADER{")
                {
                  MLeader.LeaderNode leaderNode = new MLeader.LeaderNode();
                  r.method_85();
                  leaderNode.Read(r);
                  this.list_0.Add(leaderNode);
                  break;
                }
                break;
            }
          }
          else
            goto label_39;
        }
        while (!flag);
        r.method_85();
      }
label_39:;
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      this.WriteMyFields(w, true);
    }

    protected internal void WriteMyFields(DxfWriter w, bool writeBrackets)
    {
      if (writeBrackets)
        w.Write(300, (object) "CONTEXT_DATA{");
      w.Write(40, (object) this.double_0);
      w.Write(10, this.point3D_0);
      w.Write(41, (object) this.double_1);
      w.Write(140, (object) this.double_2);
      w.Write(145, (object) this.double_3);
      w.Write(174, (object) (short) this.textAttachment_0);
      w.Write(175, (object) (short) this.textAttachment_1);
      w.Write(176, (object) (short) this.textAlignment_0);
      w.Write(177, (object) (short) this.blockAttachment_0);
      w.Write(290, (object) this.bool_1);
      if (this.bool_1)
      {
        if (!(this.content_0 is MLeader.ContentText))
          throw new Exception("Content is expected to be of type ContentText");
        this.content_0.Write(w);
      }
      w.Write(296, (object) this.bool_2);
      if (this.bool_2)
      {
        if (!(this.content_0 is MLeader.ContentBlock))
          throw new Exception("Content is expected to be of type ContentBlock");
        this.content_0.Write(w);
      }
      foreach (MLeader.LeaderNode leaderNode in this.list_0)
        leaderNode.Write(w);
      if (w.Version > DxfVersion.Dxf21)
      {
        w.Write(272, (object) (short) this.textAttachment_3);
        w.Write(273, (object) (short) this.textAttachment_2);
      }
      if (!writeBrackets)
        return;
      w.Write(301, (object) "}");
    }
  }
}
