// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfMLeader
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns28;
using ns3;
using ns33;
using ns4;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.IO;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfMLeader : DxfEntity
  {
    private DxfMLeaderAnnotationContext dxfMLeaderAnnotationContext_0 = new DxfMLeaderAnnotationContext();
    private List<MLeader.Label> list_0 = new List<MLeader.Label>();
    private List<MLeader.ArrowHead> list_1 = new List<MLeader.ArrowHead>();
    private DxfObjectReference dxfObjectReference_6 = DxfObjectReference.Null;
    private MLeader.LeaderType leaderType_0 = MLeader.LeaderType.Straight;
    private Color color_0 = Color.ByBlock;
    private DxfObjectReference dxfObjectReference_7 = DxfObjectReference.Null;
    private int int_0 = -2;
    private bool bool_2 = true;
    private bool bool_3 = true;
    private bool bool_4 = true;
    private double double_1 = 0.36;
    private DxfObjectReference dxfObjectReference_8 = DxfObjectReference.Null;
    private double double_2 = 0.18;
    private DxfObjectReference dxfObjectReference_9 = DxfObjectReference.Null;
    private MLeader.TextAngleType textAngleType_0 = MLeader.TextAngleType.Horizontal;
    private Color color_1 = Color.ByBlock;
    private DxfObjectReference dxfObjectReference_10 = DxfObjectReference.Null;
    private Color color_2 = Color.ByBlock;
    private WW.Math.Vector3D vector3D_0 = new WW.Math.Vector3D(1.0, 1.0, 1.0);
    private DxfObjectReference dxfObjectReference_11 = DxfObjectReference.Null;
    private MLeader.TextJustification textJustification_0 = MLeader.TextJustification.Left;
    private double double_5 = 1.0;
    private bool bool_8 = true;
    private short short_3 = 2;
    private MLeader.ContentType contentType_0;
    private MLeader.PropertyOverrideFlags propertyOverrideFlags_0;
    private short short_1;
    private bool bool_5;
    private double double_3;
    private bool bool_6;
    private double double_4;
    private MLeader.BlockAttachment blockAttachment_0;
    private short short_2;
    private uint uint_0;
    private bool bool_7;
    private MLeader.TextAttachmentDirection textAttachmentDirection_0;

    public DxfMLeaderAnnotationContext Content
    {
      get
      {
        return this.dxfMLeaderAnnotationContext_0;
      }
    }

    public List<MLeader.Label> Labels
    {
      get
      {
        return this.list_0;
      }
    }

    public List<MLeader.ArrowHead> ArrowHeads
    {
      get
      {
        return this.list_1;
      }
    }

    public MLeader.ContentType StyleContentType
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

    public MLeader.PropertyOverrideFlags PropertyOverrideFlags
    {
      get
      {
        return this.propertyOverrideFlags_0;
      }
      set
      {
        this.propertyOverrideFlags_0 = value;
      }
    }

    public DxfMLeaderStyle LeaderStyle
    {
      get
      {
        return (DxfMLeaderStyle) this.dxfObjectReference_6.Value;
      }
      set
      {
        this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) value);
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

    public Color LeaderLineColor
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

    public DxfLineType LeaderLineType
    {
      get
      {
        return (DxfLineType) this.dxfObjectReference_7.Value;
      }
      set
      {
        this.dxfObjectReference_7 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public int LeaderLineWeight
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

    public bool DogLegEnabled
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

    public bool LandingHorizontal
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

    public bool LandingEnabled
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

    public double LandingDistance
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

    public DxfBlock ArrowHeadBlock
    {
      get
      {
        return (DxfBlock) this.dxfObjectReference_8.Value;
      }
      set
      {
        this.dxfObjectReference_8 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public double DefaultArrowHeadSize
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

    public DxfTextStyle TextStyle
    {
      get
      {
        return (DxfTextStyle) this.dxfObjectReference_9.Value;
      }
      set
      {
        this.dxfObjectReference_9 = DxfObjectReference.GetReference((IDxfHandledObject) value);
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
        return this.color_1;
      }
      set
      {
        this.color_1 = value;
      }
    }

    public bool TextFrameEnabled
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

    public DxfBlock Block
    {
      get
      {
        return (DxfBlock) this.dxfObjectReference_10.Value;
      }
      set
      {
        this.dxfObjectReference_10 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public Color BlockColor
    {
      get
      {
        return this.color_2;
      }
      set
      {
        this.color_2 = value;
      }
    }

    public WW.Math.Vector3D BlockScale
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

    public double BlockRotation
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

    public bool IsTextDirectionNegative
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

    public double StyleBlockRotation
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

    public short IpeAlign
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

    public DxfMLeaderStyle DefaultLeaderStyle
    {
      get
      {
        return (DxfMLeaderStyle) this.dxfObjectReference_11.Value;
      }
      set
      {
        this.dxfObjectReference_11 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public bool IsAnnotative
    {
      get
      {
        return this.bool_7;
      }
      set
      {
        this.bool_7 = value;
      }
    }

    public MLeader.TextJustification TextJustification
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

    public double Scale
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

    public MLeader.TextAttachmentDirection TextAttachmentDirection
    {
      get
      {
        return this.textAttachmentDirection_0;
      }
      set
      {
        this.textAttachmentDirection_0 = value;
        foreach (MLeader.LeaderNode leaderNode in this.dxfMLeaderAnnotationContext_0.LeaderNodes)
          leaderNode.TextAttachmentDirection = value;
      }
    }

    public bool LeaderExtendedToText
    {
      get
      {
        return this.bool_8;
      }
      set
      {
        this.bool_8 = value;
      }
    }

    public override string EntityType
    {
      get
      {
        return "MULTILEADER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbMLeader";
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      if (this.dxfMLeaderAnnotationContext_0.HasTextContent)
      {
        MLeader.ContentText content = this.dxfMLeaderAnnotationContext_0.Content as MLeader.ContentText;
        if (content != null)
        {
          Class985 mtextLayoutInfo;
          IList<Class908> chunks;
          this.method_14(context, content, out mtextLayoutInfo, out chunks);
          ns0.Class0 class0 = new ns0.Class0((DxfEntity) this, context, graphicsFactory);
          Matrix4D transform = content.Transform;
          Matrix4D inverse = transform.GetInverse();
          foreach (Class908 class908 in (IEnumerable<Class908>) chunks)
            class908.Draw((IPathDrawer) class0, transform, 0.0);
          this.method_13((DxfMLeader.Class65) new DxfMLeader.Class66(this, context, graphicsFactory), mtextLayoutInfo, transform, inverse);
        }
      }
      else if (this.dxfMLeaderAnnotationContext_0.HasBlockContent)
      {
        MLeader.ContentBlock content = this.dxfMLeaderAnnotationContext_0.Content as MLeader.ContentBlock;
        if (content != null)
        {
          Matrix4D currentBlockTransform = content.CurrentBlockTransform;
          if (content.Block != null)
          {
            DxfInsert.Interface46 nterface46 = (DxfInsert.Interface46) new DxfInsert.Class1019((DxfEntity) this, context, graphicsFactory);
            nterface46.imethod_0(0, 0, currentBlockTransform);
            nterface46.Draw(this.Block, false);
          }
          foreach (MLeader.Label label in this.list_0)
          {
            if (label.AttributeDefinition != null)
            {
              AttachmentPoint attachmentPoint = AttachmentPoint.MiddleCenter;
              switch (label.AttributeDefinition.HorizontalAlignment)
              {
                case TextHorizontalAlignment.Left:
                  attachmentPoint = AttachmentPoint.TopLeft;
                  break;
                case TextHorizontalAlignment.Center:
                case TextHorizontalAlignment.Aligned:
                case TextHorizontalAlignment.Middle:
                case TextHorizontalAlignment.Fit:
                  attachmentPoint = AttachmentPoint.TopCenter;
                  break;
                case TextHorizontalAlignment.Right:
                  attachmentPoint = AttachmentPoint.TopRight;
                  break;
              }
              switch (label.AttributeDefinition.VerticalAlignment)
              {
                case TextVerticalAlignment.Baseline:
                case TextVerticalAlignment.Bottom:
                  attachmentPoint += AttachmentPoint.MiddleRight;
                  break;
                case TextVerticalAlignment.Middle:
                  attachmentPoint += AttachmentPoint.TopRight;
                  break;
              }
              IList<Class908> class908List = Class666.smethod_1(label.Text, 0.0, label.AttributeDefinition.Height, attachmentPoint, 1.0, LineSpacingStyle.AtLeast, this.TextStyle ?? context.Model.DefaultTextStyle, 1.0, label.AttributeDefinition.Color.ToColor(), DrawingDirection.LeftToRight, this.LineWeight, Matrix4D.Identity, (Class985) null, Enum24.flag_0);
              ns0.Class0 class0 = new ns0.Class0((DxfEntity) this, context, graphicsFactory);
              Matrix4D insertionTransformation = currentBlockTransform;
              foreach (Class908 class908 in (IEnumerable<Class908>) class908List)
                class908.Draw((IPathDrawer) class0, insertionTransformation, 0.0);
            }
          }
        }
      }
      foreach (MLeader.LeaderNode leaderNode in this.dxfMLeaderAnnotationContext_0.LeaderNodes)
      {
        foreach (MLeader.LeaderLine leaderLine in leaderNode.LeaderLines)
        {
          MLeader.Class880 class880 = new MLeader.Class880(this, leaderNode, leaderLine);
          WW.Math.Vector3D vector3D = this.dxfMLeaderAnnotationContext_0.Content == null ? WW.Math.Vector3D.ZAxis : this.dxfMLeaderAnnotationContext_0.Content.Normal;
          IList<Polyline3D> polylines1;
          IList<FlatShape4D> shapes;
          DxfLeader.smethod_4((DrawContext) context, context.GetTransformer().LineTypeScaler, (ILeader) class880, (IList<WW.Math.Point3D>) class880.Vertices, leaderLine.GetLineType(this), vector3D, this.LineTypeScale, out polylines1, out shapes);
          IList<Polyline4D> polylines2 = DxfUtil.smethod_36(polylines1, false, context.GetTransformer());
          ArgbColor plotColor = context.GetPlotColor((DxfEntity) this, leaderLine.GetLineColor(this));
          if (polylines2.Count > 0)
            graphicsFactory.CreatePath((DxfEntity) this, context, plotColor, false, polylines2, false, true);
          if (shapes != null)
            Class940.smethod_23((IPathDrawer) new ns0.Class0((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, leaderLine.GetLineColor(this), context.GetLineWeight((DxfEntity) this));
          if (DxfLeader.smethod_7((ILeader) class880, (IList<WW.Math.Point3D>) class880.Vertices))
          {
            if (class880.LeaderArrowBlock == null)
            {
              Polyline3D polyline = DxfLeader.smethod_5((ILeader) class880);
              if (polyline != null)
              {
                IClippingTransformer clippingTransformer = (IClippingTransformer) context.GetTransformer().Clone();
                clippingTransformer.SetPreTransform(DxfLeader.smethod_6((ILeader) class880, (IList<WW.Math.Point3D>) class880.Vertices, vector3D));
                List<Polyline4D> polyline4DList = new List<Polyline4D>((IEnumerable<Polyline4D>) clippingTransformer.Transform(polyline, polyline.Closed));
                if (polyline4DList.Count > 0)
                  graphicsFactory.CreatePath((DxfEntity) this, context, plotColor, false, (IList<Polyline4D>) polyline4DList, true, true);
              }
            }
            else
            {
              DxfInsert.Interface46 nterface46 = (DxfInsert.Interface46) new DxfInsert.Class1019((DxfEntity) this, context, graphicsFactory);
              nterface46.imethod_0(0, 0, DxfLeader.smethod_6((ILeader) class880, (IList<WW.Math.Point3D>) class880.Vertices, vector3D));
              nterface46.Draw(class880.LeaderArrowBlock, true);
            }
          }
        }
        if (this.leaderType_0 == MLeader.LeaderType.Straight && this.textAttachmentDirection_0 == MLeader.TextAttachmentDirection.Horizontal && leaderNode.LandingDistance > 0.0)
        {
          Segment3D segment = new Segment3D(leaderNode.ConnectionPoint, leaderNode.LandingPoint);
          IList<Segment4D> segment4DList = context.GetTransformer().Transform(segment);
          ArgbColor color = leaderNode.LeaderLines.Count != 1 ? context.GetPlotColor((DxfEntity) this, this.color_0) : context.GetPlotColor((DxfEntity) this, leaderNode.LeaderLines[0].GetLineColor(this));
          foreach (Segment4D segment4D in (IEnumerable<Segment4D>) segment4DList)
            graphicsFactory.CreateLine((DxfEntity) this, context, color, false, segment4D.Start, segment4D.End);
        }
      }
    }

    private void method_13(
      DxfMLeader.Class65 drawHelper,
      Class985 mtextLayoutInfo,
      Matrix4D transform,
      Matrix4D inverseTransform)
    {
      double textHeight = this.dxfMLeaderAnnotationContext_0.TextHeight;
      double y = mtextLayoutInfo.Bounds.Min.Y;
      int num = (int) this.dxfMLeaderAnnotationContext_0.method_9(this);
      if (this.textAttachmentDirection_0 == MLeader.TextAttachmentDirection.Horizontal)
      {
        bool flag1 = false;
        bool flag2 = false;
        MLeader.LeaderNode leaderNode1 = (MLeader.LeaderNode) null;
        MLeader.LeaderNode leaderNode2 = (MLeader.LeaderNode) null;
        foreach (MLeader.LeaderNode leaderNode3 in this.dxfMLeaderAnnotationContext_0.LeaderNodes)
        {
          if (leaderNode3.Direction.X > 0.0)
          {
            if (leaderNode1 == null)
              leaderNode1 = leaderNode3;
            flag1 = true;
          }
          else if (leaderNode3.Direction.X < 0.0)
          {
            if (leaderNode2 == null)
              leaderNode2 = leaderNode3;
            flag2 = true;
          }
        }
        bool flag3;
        if (((flag3 = flag1 && this.dxfMLeaderAnnotationContext_0.TextLeftAttachment == MLeader.TextAttachment.BottomOfBottomTextLineAndUnderline) || flag2 && this.dxfMLeaderAnnotationContext_0.TextRightAttachment == MLeader.TextAttachment.BottomOfBottomTextLineAndUnderline) && mtextLayoutInfo.LastLineBounds != null)
        {
          WW.Math.Point3D point3D = inverseTransform.Transform(flag3 ? leaderNode1.LandingPoint : leaderNode2.LandingPoint);
          this.method_15(drawHelper, mtextLayoutInfo, transform, point3D.Y);
        }
        bool flag4;
        if (((flag4 = flag1 && this.dxfMLeaderAnnotationContext_0.TextLeftAttachment == MLeader.TextAttachment.BottomOfTopTextLineAndUnderline) || flag2 && this.dxfMLeaderAnnotationContext_0.TextRightAttachment == MLeader.TextAttachment.BottomOfTopTextLineAndUnderline) && mtextLayoutInfo.FirstLineBounds != null)
        {
          WW.Math.Point3D point3D = inverseTransform.Transform(flag4 ? leaderNode1.LandingPoint : leaderNode2.LandingPoint);
          this.method_15(drawHelper, mtextLayoutInfo, transform, point3D.Y);
        }
        bool flag5;
        if (!(flag5 = flag1 && this.dxfMLeaderAnnotationContext_0.TextLeftAttachment == MLeader.TextAttachment.BottomOfTopTextLineAndUnderlineAllTextLines) && (!flag2 || this.dxfMLeaderAnnotationContext_0.TextRightAttachment != MLeader.TextAttachment.BottomOfTopTextLineAndUnderlineAllTextLines) || mtextLayoutInfo.FirstLineBounds == null)
          return;
        WW.Math.Point3D point3D1 = inverseTransform.Transform(flag5 ? leaderNode1.LandingPoint : leaderNode2.LandingPoint);
        this.method_15(drawHelper, mtextLayoutInfo, transform, point3D1.Y);
      }
      else
      {
        bool flag1 = false;
        bool flag2 = false;
        foreach (MLeader.LeaderNode leaderNode in this.dxfMLeaderAnnotationContext_0.LeaderNodes)
        {
          if (leaderNode.Direction.X > 0.0)
            flag1 = true;
          else if (leaderNode.Direction.X < 0.0)
            flag2 = true;
        }
        if (flag1 && this.dxfMLeaderAnnotationContext_0.TextBottomAttachment == MLeader.TextAttachment.CenterAndOverlineTopOrUnderlineBottomTextLine && mtextLayoutInfo.FirstLineBounds != null)
        {
          foreach (MLeader.LeaderNode leaderNode in this.dxfMLeaderAnnotationContext_0.LeaderNodes)
          {
            if (leaderNode.Direction.X > 0.0)
            {
              WW.Math.Point3D point3D = inverseTransform.Transform(leaderNode.LandingPoint);
              this.method_15(drawHelper, mtextLayoutInfo, transform, point3D.Y);
              break;
            }
          }
        }
        if (!flag2 || this.dxfMLeaderAnnotationContext_0.TextTopAttachment != MLeader.TextAttachment.CenterAndOverlineTopOrUnderlineBottomTextLine || mtextLayoutInfo.FirstLineBounds == null)
          return;
        foreach (MLeader.LeaderNode leaderNode in this.dxfMLeaderAnnotationContext_0.LeaderNodes)
        {
          if (leaderNode.Direction.X < 0.0)
          {
            WW.Math.Point3D point3D = inverseTransform.Transform(leaderNode.LandingPoint);
            this.method_15(drawHelper, mtextLayoutInfo, transform, point3D.Y);
            break;
          }
        }
      }
    }

    private void method_14(
      DrawContext.Wireframe context,
      MLeader.ContentText contentText,
      out Class985 mtextLayoutInfo,
      out IList<Class908> chunks)
    {
      mtextLayoutInfo = new Class985()
      {
        BoundsCalculationFlags = Enum36.flag_1
      };
      chunks = Class666.smethod_1(contentText.method_0(this), contentText.BoundaryWidth, this.dxfMLeaderAnnotationContext_0.TextHeight, (AttachmentPoint) contentText.Justification, contentText.LineSpacingFactor, contentText.LineSpacingStyle, this.TextStyle ?? context.Model.DefaultTextStyle, 1.0, contentText.TextColor, DrawingDirection.LeftToRight, this.LineWeight, Matrix4D.Identity, mtextLayoutInfo, Enum24.flag_0);
    }

    private void method_15(
      DxfMLeader.Class65 drawHelper,
      Class985 mtextLayoutInfo,
      Matrix4D transform,
      double y)
    {
      double x1 = mtextLayoutInfo.Bounds.Min.X;
      double x2 = mtextLayoutInfo.Bounds.Max.X;
      this.method_16(ref x1, ref x2);
      drawHelper.DrawLine(drawHelper.DrawContext.GetPlotColor((DxfEntity) this, this.color_0), transform.TransformTo3D(new WW.Math.Point2D(x1, y)), transform.TransformTo3D(new WW.Math.Point2D(x2, y)));
    }

    private void method_16(ref double x1, ref double x2)
    {
      if (this.textAttachmentDirection_0 != MLeader.TextAttachmentDirection.Horizontal || this.dxfMLeaderAnnotationContext_0.LandingGap == 0.0)
        return;
      bool flag1 = false;
      bool flag2 = false;
      foreach (MLeader.LeaderNode leaderNode in this.dxfMLeaderAnnotationContext_0.LeaderNodes)
      {
        if (leaderNode.Direction.X >= 0.0)
          flag1 = true;
        if (leaderNode.Direction.X <= 0.0)
          flag2 = true;
      }
      if (flag1)
        x1 -= this.dxfMLeaderAnnotationContext_0.LandingGap;
      if (!flag2)
        return;
      x2 += this.dxfMLeaderAnnotationContext_0.LandingGap;
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      if (this.dxfMLeaderAnnotationContext_0.HasTextContent)
      {
        MLeader.ContentText content = this.dxfMLeaderAnnotationContext_0.Content as MLeader.ContentText;
        if (content != null)
        {
          Class985 mtextLayoutInfo;
          IList<Class908> chunks;
          this.method_14(context, content, out mtextLayoutInfo, out chunks);
          Class396 class396 = new Class396((DxfEntity) this, context, graphicsFactory);
          Matrix4D transform = content.Transform;
          Matrix4D inverse = transform.GetInverse();
          foreach (Class908 class908 in (IEnumerable<Class908>) chunks)
            class908.Draw((IPathDrawer) class396, transform, 0.0);
          this.method_13((DxfMLeader.Class65) new DxfMLeader.Class67(this, context, graphicsFactory), mtextLayoutInfo, transform, inverse);
        }
      }
      else if (this.dxfMLeaderAnnotationContext_0.HasBlockContent)
      {
        MLeader.ContentBlock content = this.dxfMLeaderAnnotationContext_0.Content as MLeader.ContentBlock;
        if (content != null)
        {
          Matrix4D currentBlockTransform = content.CurrentBlockTransform;
          if (content.Block != null)
          {
            DxfInsert.Interface46 nterface46 = (DxfInsert.Interface46) new DxfInsert.Class1020((DxfEntity) this, context, graphicsFactory);
            nterface46.imethod_0(0, 0, currentBlockTransform);
            nterface46.Draw(this.Block, false);
          }
          foreach (MLeader.Label label in this.list_0)
          {
            if (label.AttributeDefinition != null)
            {
              AttachmentPoint attachmentPoint = AttachmentPoint.MiddleCenter;
              switch (label.AttributeDefinition.HorizontalAlignment)
              {
                case TextHorizontalAlignment.Left:
                  attachmentPoint = AttachmentPoint.TopLeft;
                  break;
                case TextHorizontalAlignment.Center:
                case TextHorizontalAlignment.Aligned:
                case TextHorizontalAlignment.Middle:
                case TextHorizontalAlignment.Fit:
                  attachmentPoint = AttachmentPoint.TopCenter;
                  break;
                case TextHorizontalAlignment.Right:
                  attachmentPoint = AttachmentPoint.TopRight;
                  break;
              }
              switch (label.AttributeDefinition.VerticalAlignment)
              {
                case TextVerticalAlignment.Baseline:
                case TextVerticalAlignment.Bottom:
                  attachmentPoint += AttachmentPoint.MiddleRight;
                  break;
                case TextVerticalAlignment.Middle:
                  attachmentPoint += AttachmentPoint.TopRight;
                  break;
              }
              IList<Class908> class908List = Class666.smethod_1(label.Text, 0.0, label.AttributeDefinition.Height, attachmentPoint, 1.0, LineSpacingStyle.AtLeast, this.TextStyle ?? context.Model.DefaultTextStyle, 1.0, label.AttributeDefinition.Color.ToColor(), DrawingDirection.LeftToRight, this.LineWeight, Matrix4D.Identity, (Class985) null, Enum24.flag_0);
              Class396 class396 = new Class396((DxfEntity) this, context, graphicsFactory);
              Matrix4D insertionTransformation = currentBlockTransform;
              foreach (Class908 class908 in (IEnumerable<Class908>) class908List)
                class908.Draw((IPathDrawer) class396, insertionTransformation, 0.0);
            }
          }
        }
      }
      foreach (MLeader.LeaderNode leaderNode in this.dxfMLeaderAnnotationContext_0.LeaderNodes)
      {
        foreach (MLeader.LeaderLine leaderLine in leaderNode.LeaderLines)
        {
          MLeader.Class880 class880 = new MLeader.Class880(this, leaderNode, leaderLine);
          WW.Math.Vector3D vector3D = this.dxfMLeaderAnnotationContext_0.Content == null ? WW.Math.Vector3D.ZAxis : this.dxfMLeaderAnnotationContext_0.Content.Normal;
          IList<Polyline3D> polylines;
          IList<FlatShape4D> shapes;
          DxfLeader.smethod_4((DrawContext) context, context.GetTransformer().LineTypeScaler, (ILeader) class880, (IList<WW.Math.Point3D>) class880.Vertices, leaderLine.GetLineType(this), vector3D, this.LineTypeScale, out polylines, out shapes);
          IList<Polyline4D> polyline4DList1 = DxfUtil.smethod_36(polylines, false, context.GetTransformer());
          ArgbColor plotColor = context.GetPlotColor((DxfEntity) this, leaderLine.GetLineColor(this));
          if (polyline4DList1.Count > 0)
          {
            graphicsFactory.BeginGeometry((DxfEntity) this, context, plotColor, false, false, true, context.Config.CorrectColorForBackgroundColor);
            foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) polyline4DList1)
              graphicsFactory.CreatePolyline((DxfEntity) this, polyline);
            graphicsFactory.EndGeometry();
          }
          if (shapes != null)
            Class940.smethod_23((IPathDrawer) new Class396((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, leaderLine.GetLineColor(this), context.GetLineWeight((DxfEntity) this));
          if (DxfLeader.smethod_7((ILeader) class880, (IList<WW.Math.Point3D>) class880.Vertices))
          {
            if (class880.LeaderArrowBlock == null)
            {
              Polyline3D polyline1 = DxfLeader.smethod_5((ILeader) class880);
              if (polyline1 != null)
              {
                IClippingTransformer clippingTransformer = (IClippingTransformer) context.GetTransformer().Clone();
                clippingTransformer.SetPreTransform(DxfLeader.smethod_6((ILeader) class880, (IList<WW.Math.Point3D>) class880.Vertices, vector3D));
                List<Polyline4D> polyline4DList2 = new List<Polyline4D>((IEnumerable<Polyline4D>) clippingTransformer.Transform(polyline1, polyline1.Closed));
                if (polyline4DList2.Count > 0)
                {
                  graphicsFactory.BeginGeometry((DxfEntity) this, context, plotColor, false, true, true, context.Config.CorrectColorForBackgroundColor);
                  foreach (Polyline4D polyline2 in polyline4DList2)
                    graphicsFactory.CreatePolyline((DxfEntity) this, polyline2);
                  graphicsFactory.EndGeometry();
                }
              }
            }
            else
            {
              DxfInsert.Interface46 nterface46 = (DxfInsert.Interface46) new DxfInsert.Class1020((DxfEntity) this, context, graphicsFactory);
              nterface46.imethod_0(0, 0, DxfLeader.smethod_6((ILeader) class880, (IList<WW.Math.Point3D>) class880.Vertices, vector3D));
              nterface46.Draw(class880.LeaderArrowBlock, true);
            }
          }
        }
        if (this.leaderType_0 == MLeader.LeaderType.Straight && this.textAttachmentDirection_0 == MLeader.TextAttachmentDirection.Horizontal && leaderNode.LandingDistance > 0.0)
        {
          Segment3D segment = new Segment3D(leaderNode.ConnectionPoint, leaderNode.LandingPoint);
          IList<Segment4D> segment4DList = context.GetTransformer().Transform(segment);
          ArgbColor color = leaderNode.LeaderLines.Count != 1 ? context.GetPlotColor((DxfEntity) this, this.color_0) : context.GetPlotColor((DxfEntity) this, leaderNode.LeaderLines[0].GetLineColor(this));
          if (segment4DList.Count > 0)
          {
            graphicsFactory.BeginGeometry((DxfEntity) this, context, color, false, false, true, context.Config.CorrectColorForBackgroundColor);
            foreach (Segment4D segment4D in (IEnumerable<Segment4D>) segment4DList)
              graphicsFactory.CreateLine((DxfEntity) this, segment4D.Start, segment4D.End);
            graphicsFactory.EndGeometry();
          }
        }
      }
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfMLeader dxfMleader = (DxfMLeader) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfMleader == null)
      {
        dxfMleader = new DxfMLeader();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfMleader);
        dxfMleader.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfMleader;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfMLeader dxfMleader = (DxfMLeader) from;
      if (dxfMleader.dxfMLeaderAnnotationContext_0 == null)
        this.dxfMLeaderAnnotationContext_0 = (DxfMLeaderAnnotationContext) null;
      else if (this.dxfMLeaderAnnotationContext_0 != null && !(this.dxfMLeaderAnnotationContext_0.GetType() != dxfMleader.dxfMLeaderAnnotationContext_0.GetType()))
        this.dxfMLeaderAnnotationContext_0.CopyFrom((DxfHandledObject) dxfMleader.dxfMLeaderAnnotationContext_0, cloneContext);
      else
        this.dxfMLeaderAnnotationContext_0 = (DxfMLeaderAnnotationContext) dxfMleader.dxfMLeaderAnnotationContext_0.Clone(cloneContext);
      this.list_0.Clear();
      foreach (MLeader.Label label in dxfMleader.list_0)
        this.list_0.Add(label.Clone(cloneContext));
      this.list_1.Clear();
      foreach (MLeader.ArrowHead arrowHead in dxfMleader.list_1)
        this.list_1.Add(arrowHead.Clone(cloneContext));
      this.contentType_0 = dxfMleader.contentType_0;
      this.propertyOverrideFlags_0 = dxfMleader.propertyOverrideFlags_0;
      this.LeaderStyle = (DxfMLeaderStyle) cloneContext.Clone((IGraphCloneable) dxfMleader.LeaderStyle);
      this.leaderType_0 = dxfMleader.leaderType_0;
      this.color_0 = dxfMleader.color_0;
      this.LeaderLineType = Class906.GetLineType(cloneContext, dxfMleader.LeaderLineType);
      this.int_0 = dxfMleader.int_0;
      this.bool_2 = dxfMleader.bool_2;
      this.bool_3 = dxfMleader.bool_3;
      this.bool_4 = dxfMleader.bool_4;
      this.double_1 = dxfMleader.double_1;
      this.ArrowHeadBlock = Class906.smethod_0(cloneContext, dxfMleader.ArrowHeadBlock, false);
      this.double_2 = dxfMleader.double_2;
      this.TextStyle = Class906.GetTextStyle(cloneContext, dxfMleader.TextStyle);
      this.textAngleType_0 = dxfMleader.textAngleType_0;
      this.short_1 = dxfMleader.short_1;
      this.color_1 = dxfMleader.color_1;
      this.bool_5 = dxfMleader.bool_5;
      this.Block = Class906.smethod_0(cloneContext, this.Block, false);
      this.color_2 = dxfMleader.color_2;
      this.vector3D_0 = dxfMleader.vector3D_0;
      this.double_3 = dxfMleader.double_3;
      this.bool_6 = dxfMleader.bool_6;
      this.double_4 = dxfMleader.double_4;
      this.blockAttachment_0 = dxfMleader.blockAttachment_0;
      this.short_2 = dxfMleader.short_2;
      this.uint_0 = dxfMleader.uint_0;
      this.DefaultLeaderStyle = (DxfMLeaderStyle) cloneContext.Clone((IGraphCloneable) dxfMleader.DefaultLeaderStyle);
      this.bool_7 = dxfMleader.bool_7;
      this.textJustification_0 = dxfMleader.textJustification_0;
      this.double_5 = dxfMleader.double_5;
      this.textAttachmentDirection_0 = dxfMleader.textAttachmentDirection_0;
      this.bool_8 = dxfMleader.bool_8;
      this.short_3 = dxfMleader.short_3;
    }

    public override void TransformMe(TransformConfig config, Matrix4D matrix)
    {
      this.TransformMe(config, matrix, (CommandGroup) null);
    }

    public override void TransformMe(
      TransformConfig config,
      Matrix4D matrix,
      CommandGroup undoGroup)
    {
      if (this.dxfMLeaderAnnotationContext_0 == null)
        return;
      this.dxfMLeaderAnnotationContext_0.TransformMe(config, matrix, undoGroup);
    }

    internal static DxfClass smethod_2(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "MULTILEADER");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ACDB_MLEADER_CLASS";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1021;
        dxfClass.MaintenanceVersion = (short) 25;
        dxfClass.ProxyFlags = ProxyFlags.EraseAllowed | ProxyFlags.DisablesProxyWarningDialog;
        dxfClass.CPlusPlusClassName = "AcDbMLeader";
        dxfClass.DxfName = "MULTILEADER";
        dxfClass.ItemClassId = (short) 498;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_7.ClassNumber;
    }

    internal override void Read(DxfReader r, Class259 objectBuilder)
    {
      Class285 entityBuilder = (Class285) objectBuilder;
      r.method_85();
      while (r.CurrentGroup.Code != 0)
      {
        if (r.CurrentGroup.Code == 100)
        {
          switch ((string) r.CurrentGroup.Value)
          {
            case "AcDbMLeader":
              this.method_17(r, objectBuilder);
              continue;
            case "AcDbEntity":
              this.method_8(r, entityBuilder);
              continue;
            default:
              r.method_85();
              continue;
          }
        }
        else if (!this.method_9(r, entityBuilder))
          r.method_85();
      }
    }

    private void method_17(DxfReader r, Class259 objectBuilder)
    {
      r.method_91(this.AcClass);
      r.method_85();
      if (r.ModelBuilder.Version > DxfVersion.Dxf21 && r.CurrentGroup.Code == 270)
      {
        this.short_3 = (short) r.CurrentGroup.Value;
        r.method_85();
      }
      while (!r.method_92(this.AcClass))
      {
        bool flag = true;
        switch (r.CurrentGroup.Code)
        {
          case 10:
            this.vector3D_0.X = (double) r.CurrentGroup.Value;
            break;
          case 20:
            this.vector3D_0.Y = (double) r.CurrentGroup.Value;
            break;
          case 30:
            this.vector3D_0.Z = (double) r.CurrentGroup.Value;
            break;
          case 41:
            this.double_1 = (double) r.CurrentGroup.Value;
            break;
          case 42:
            this.double_2 = (double) r.CurrentGroup.Value;
            break;
          case 43:
            this.double_4 = (double) r.CurrentGroup.Value * (System.Math.PI / 180.0);
            break;
          case 45:
            this.double_5 = (double) r.CurrentGroup.Value;
            break;
          case 90:
            this.propertyOverrideFlags_0 = (MLeader.PropertyOverrideFlags) r.CurrentGroup.Value;
            break;
          case 91:
            this.color_0 = MLeader.smethod_0((int) r.CurrentGroup.Value);
            break;
          case 92:
            this.color_1 = MLeader.smethod_0((int) r.CurrentGroup.Value);
            break;
          case 93:
            this.color_2 = MLeader.smethod_0((int) r.CurrentGroup.Value);
            break;
          case 94:
            MLeader.ArrowHead arrowHead = new MLeader.ArrowHead();
            this.list_1.Add(arrowHead);
            arrowHead.IsDefault = (int) r.CurrentGroup.Value != 0;
            break;
          case 95:
            this.dxfMLeaderAnnotationContext_0.TextRightAttachment = (MLeader.TextAttachment) (short) (int) r.CurrentGroup.Value;
            break;
          case 170:
            this.leaderType_0 = (MLeader.LeaderType) r.CurrentGroup.Value;
            break;
          case 171:
            this.int_0 = (int) (short) r.CurrentGroup.Value;
            break;
          case 172:
            this.contentType_0 = (MLeader.ContentType) r.CurrentGroup.Value;
            break;
          case 173:
            this.dxfMLeaderAnnotationContext_0.TextLeftAttachment = (MLeader.TextAttachment) (short) r.CurrentGroup.Value;
            break;
          case 174:
            this.textAngleType_0 = (MLeader.TextAngleType) r.CurrentGroup.Value;
            break;
          case 175:
            this.short_1 = (short) r.CurrentGroup.Value;
            break;
          case 176:
            this.blockAttachment_0 = (MLeader.BlockAttachment) r.CurrentGroup.Value;
            break;
          case 178:
            this.short_2 = (short) r.CurrentGroup.Value;
            break;
          case 179:
            this.textJustification_0 = (MLeader.TextJustification) r.CurrentGroup.Value;
            break;
          case 271:
            this.textAttachmentDirection_0 = (MLeader.TextAttachmentDirection) r.CurrentGroup.Value;
            break;
          case 272:
            this.dxfMLeaderAnnotationContext_0.TextBottomAttachment = (MLeader.TextAttachment) (short) r.CurrentGroup.Value;
            break;
          case 273:
            this.dxfMLeaderAnnotationContext_0.TextTopAttachment = (MLeader.TextAttachment) (short) r.CurrentGroup.Value;
            break;
          case 290:
            this.bool_4 = (bool) r.CurrentGroup.Value;
            break;
          case 291:
            this.bool_2 = (bool) r.CurrentGroup.Value;
            break;
          case 292:
            this.bool_5 = (bool) r.CurrentGroup.Value;
            break;
          case 293:
            this.bool_7 = (bool) r.CurrentGroup.Value;
            break;
          case 294:
            this.bool_6 = (bool) r.CurrentGroup.Value;
            break;
          case 295:
            this.bool_8 = (bool) r.CurrentGroup.Value;
            break;
          case 300:
            this.dxfMLeaderAnnotationContext_0.method_11(r, objectBuilder, true);
            break;
          case 330:
            MLeader.Label label = new MLeader.Label();
            label.Read(r);
            this.list_0.Add(label);
            flag = false;
            break;
          case 340:
            r.method_90((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_6 = o));
            break;
          case 341:
            r.method_90((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_7 = o));
            break;
          case 342:
            r.method_90((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_8 = o));
            break;
          case 343:
            r.method_90((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_9 = o));
            break;
          case 344:
            r.method_90((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_10 = o));
            break;
          case 345:
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: reference to a compiler-generated method
            r.method_90(new System.Action<DxfObjectReference>(new DxfMLeader.Class68()
            {
              arrowHead_0 = this.list_1[this.list_1.Count - 1]
            }.method_0));
            break;
          default:
            flag = !this.method_6(r, objectBuilder);
            break;
        }
        if (flag)
          r.method_85();
      }
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.method_234(this.AcClass);
      if (w.Version > DxfVersion.Dxf21)
        w.Write(270, (object) this.short_3);
      this.dxfMLeaderAnnotationContext_0.WriteMyFields(w, true);
      if (this.LeaderStyle != null)
        w.method_218(340, (DxfHandledObject) this.LeaderStyle);
      w.Write(90, (object) (int) this.propertyOverrideFlags_0);
      w.Write(170, (object) (short) this.leaderType_0);
      w.method_230(91, this.color_0);
      w.method_218(341, (DxfHandledObject) (this.LeaderLineType ?? w.Model.ContinuousLineType));
      w.Write(171, (object) (short) this.int_0);
      w.Write(290, (object) this.bool_4);
      w.Write(291, (object) this.bool_2);
      w.Write(41, (object) this.double_1);
      if (this.ArrowHeadBlock != null)
        w.method_218(342, (DxfHandledObject) this.ArrowHeadBlock);
      w.Write(42, (object) this.double_2);
      w.Write(172, (object) (short) this.contentType_0);
      w.method_218(343, (DxfHandledObject) (this.TextStyle ?? w.Model.DefaultTextStyle));
      w.Write(173, (object) (short) this.dxfMLeaderAnnotationContext_0.TextLeftAttachment);
      w.Write(95, (object) (int) (short) this.dxfMLeaderAnnotationContext_0.TextRightAttachment);
      w.Write(174, (object) (short) this.textAngleType_0);
      w.Write(175, (object) this.short_1);
      w.method_230(92, this.color_1);
      w.Write(292, (object) this.bool_5);
      if (this.Block != null)
        w.method_218(344, (DxfHandledObject) this.Block);
      w.method_230(93, this.color_2);
      w.Write(10, this.vector3D_0);
      w.Write(43, (object) (this.double_4 * (180.0 / System.Math.PI)));
      w.Write(176, (object) (short) this.blockAttachment_0);
      w.Write(293, (object) this.bool_7);
      if (w.Version <= DxfVersion.Dxf21)
      {
        foreach (MLeader.ArrowHead arrowHead in this.list_1)
          arrowHead.Write(w);
      }
      foreach (MLeader.Label label in this.list_0)
        label.Write(w);
      w.Write(294, (object) this.bool_6);
      w.Write(178, (object) this.short_2);
      w.Write(179, (object) (short) this.textJustification_0);
      w.Write(45, (object) this.double_5);
      if (w.Version > DxfVersion.Dxf21)
      {
        w.Write(271, (object) (short) this.textAttachmentDirection_0);
        w.Write(272, (object) (short) this.dxfMLeaderAnnotationContext_0.TextBottomAttachment);
        w.Write(273, (object) (short) this.dxfMLeaderAnnotationContext_0.TextTopAttachment);
      }
      if (w.Version <= DxfVersion.Dxf24)
        return;
      w.Write(295, (object) this.bool_8);
    }

    internal override void Read(Class434 or, Class259 objectBuilder)
    {
      base.Read(or, objectBuilder);
      Interface30 objectBitStream = or.ObjectBitStream;
      if (or.Builder.Version > DxfVersion.Dxf21)
        this.short_3 = objectBitStream.imethod_14();
      this.dxfMLeaderAnnotationContext_0.method_10(or, objectBuilder);
      or.method_78((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_6 = o));
      this.propertyOverrideFlags_0 = (MLeader.PropertyOverrideFlags) objectBitStream.imethod_11();
      this.leaderType_0 = (MLeader.LeaderType) objectBitStream.imethod_14();
      this.color_0 = objectBitStream.imethod_22();
      or.method_78((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_7 = o));
      this.int_0 = objectBitStream.imethod_11();
      this.bool_4 = objectBitStream.imethod_6();
      this.bool_2 = objectBitStream.imethod_6();
      this.double_1 = objectBitStream.imethod_8();
      or.method_78((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_8 = o));
      this.double_2 = objectBitStream.imethod_8();
      this.contentType_0 = (MLeader.ContentType) objectBitStream.imethod_14();
      or.method_78((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_9 = o));
      this.dxfMLeaderAnnotationContext_0.TextLeftAttachment = (MLeader.TextAttachment) objectBitStream.imethod_14();
      this.dxfMLeaderAnnotationContext_0.TextRightAttachment = (MLeader.TextAttachment) objectBitStream.imethod_14();
      this.textAngleType_0 = (MLeader.TextAngleType) objectBitStream.imethod_14();
      this.short_1 = objectBitStream.imethod_14();
      this.color_1 = objectBitStream.imethod_22();
      this.bool_5 = objectBitStream.imethod_6();
      or.method_78((System.Action<DxfObjectReference>) (o => this.dxfObjectReference_10 = o));
      this.color_2 = objectBitStream.imethod_22();
      this.vector3D_0 = objectBitStream.imethod_51();
      this.double_4 = objectBitStream.imethod_8();
      this.blockAttachment_0 = (MLeader.BlockAttachment) objectBitStream.imethod_14();
      this.bool_7 = objectBitStream.imethod_6();
      if (or.Builder.Version <= DxfVersion.Dxf21)
      {
        int num = objectBitStream.imethod_11();
        for (int index = 0; index < num; ++index)
        {
          MLeader.ArrowHead arrowHead = new MLeader.ArrowHead();
          arrowHead.Read(or);
          this.list_1.Add(arrowHead);
        }
      }
      int num1 = objectBitStream.imethod_11();
      for (int index = 0; index < num1; ++index)
      {
        MLeader.Label label = new MLeader.Label();
        label.Read(or);
        this.list_0.Add(label);
      }
      this.bool_6 = objectBitStream.imethod_6();
      this.short_2 = objectBitStream.imethod_14();
      this.textJustification_0 = (MLeader.TextJustification) objectBitStream.imethod_14();
      this.double_5 = objectBitStream.imethod_8();
      if (or.Builder.Version > DxfVersion.Dxf21)
      {
        this.textAttachmentDirection_0 = (MLeader.TextAttachmentDirection) objectBitStream.imethod_14();
        this.dxfMLeaderAnnotationContext_0.TextTopAttachment = (MLeader.TextAttachment) objectBitStream.imethod_14();
        this.dxfMLeaderAnnotationContext_0.TextBottomAttachment = (MLeader.TextAttachment) objectBitStream.imethod_14();
      }
      if (or.Builder.Version <= DxfVersion.Dxf24)
        return;
      this.bool_8 = objectBitStream.imethod_6();
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      Interface29 objectWriter = ow.ObjectWriter;
      if (ow.Version > DxfVersion.Dxf21)
        objectWriter.imethod_32(this.short_3);
      this.dxfMLeaderAnnotationContext_0.WriteMyFields(ow);
      objectWriter.imethod_41((DxfHandledObject) this.LeaderStyle);
      objectWriter.imethod_33((int) this.propertyOverrideFlags_0);
      objectWriter.imethod_32((short) this.leaderType_0);
      objectWriter.imethod_6(this.color_0);
      objectWriter.imethod_41((DxfHandledObject) this.LeaderLineType);
      objectWriter.imethod_33(this.int_0);
      objectWriter.imethod_14(this.bool_4);
      objectWriter.imethod_14(this.bool_2);
      objectWriter.imethod_16(this.double_1);
      objectWriter.imethod_41((DxfHandledObject) this.ArrowHeadBlock);
      objectWriter.imethod_16(this.double_2);
      objectWriter.imethod_32((short) this.contentType_0);
      objectWriter.imethod_41((DxfHandledObject) this.TextStyle);
      objectWriter.imethod_32((short) this.dxfMLeaderAnnotationContext_0.TextLeftAttachment);
      objectWriter.imethod_32((short) this.dxfMLeaderAnnotationContext_0.TextRightAttachment);
      objectWriter.imethod_32((short) this.textAngleType_0);
      objectWriter.imethod_32(this.short_1);
      objectWriter.imethod_6(this.color_1);
      objectWriter.imethod_14(this.bool_5);
      objectWriter.imethod_41((DxfHandledObject) this.Block);
      objectWriter.imethod_6(this.color_2);
      objectWriter.imethod_29(this.vector3D_0);
      objectWriter.imethod_16(this.double_4);
      objectWriter.imethod_32((short) this.blockAttachment_0);
      objectWriter.imethod_14(this.bool_7);
      if (ow.Version <= DxfVersion.Dxf21)
      {
        objectWriter.imethod_33(this.list_1.Count);
        foreach (MLeader.ArrowHead arrowHead in this.list_1)
          arrowHead.Write(ow);
      }
      objectWriter.imethod_33(this.list_0.Count);
      foreach (MLeader.Label label in this.list_0)
        label.Write(ow);
      objectWriter.imethod_14(this.bool_6);
      objectWriter.imethod_32(this.short_2);
      objectWriter.imethod_32((short) this.textJustification_0);
      objectWriter.imethod_16(this.double_5);
      if (ow.Version > DxfVersion.Dxf21)
      {
        objectWriter.imethod_32((short) this.textAttachmentDirection_0);
        objectWriter.imethod_32((short) this.dxfMLeaderAnnotationContext_0.TextTopAttachment);
        objectWriter.imethod_32((short) this.dxfMLeaderAnnotationContext_0.TextBottomAttachment);
      }
      if (ow.Version <= DxfVersion.Dxf24)
        return;
      objectWriter.imethod_14(this.bool_8);
    }

    internal double ArrowHeadSize
    {
      get
      {
        if (this.dxfMLeaderAnnotationContext_0 != null)
          return this.dxfMLeaderAnnotationContext_0.ArrowHeadSize;
        return 0.18;
      }
    }

    private void method_18(
      DrawContext context,
      IPathDrawer pathDrawer,
      MLeader.ContentText contentText)
    {
      Class985 resultLayoutInfo = new Class985();
      IList<Class908> class908List = Class666.smethod_1(contentText.TextLabel, contentText.ColumnWidth, this.dxfMLeaderAnnotationContext_0.TextHeight, AttachmentPoint.TopLeft, contentText.LineSpacingFactor, contentText.LineSpacingStyle, contentText.TextStyle ?? context.Model.DefaultTextStyle, 1.0, this.Color.ToColor(), DrawingDirection.LeftToRight, context.GetLineWeight((DxfEntity) this), Matrix4D.Identity, resultLayoutInfo, Enum24.flag_3);
      Matrix4D identity = Matrix4D.Identity;
      foreach (Class908 class908 in (IEnumerable<Class908>) class908List)
        class908.Draw(pathDrawer, identity, 0.0);
    }

    private abstract class Class65
    {
      protected DxfMLeader dxfMLeader_0;

      protected Class65(DxfMLeader mleader)
      {
        this.dxfMLeader_0 = mleader;
      }

      public abstract DrawContext DrawContext { get; }

      public abstract void DrawLine(ArgbColor color, WW.Math.Point3D p0, WW.Math.Point3D p1);
    }

    private class Class66 : DxfMLeader.Class65
    {
      private DrawContext.Wireframe wireframe_0;
      private IWireframeGraphicsFactory iwireframeGraphicsFactory_0;

      public Class66(
        DxfMLeader mleader,
        DrawContext.Wireframe drawContext,
        IWireframeGraphicsFactory graphicsFactory)
        : base(mleader)
      {
        this.wireframe_0 = drawContext;
        this.iwireframeGraphicsFactory_0 = graphicsFactory;
      }

      public override DrawContext DrawContext
      {
        get
        {
          return (DrawContext) this.wireframe_0;
        }
      }

      public override void DrawLine(ArgbColor color, WW.Math.Point3D p0, WW.Math.Point3D p1)
      {
        IList<Polyline4D> polylines = DxfUtil.smethod_38(new Polyline3D(false, new WW.Math.Point3D[2]{ p0, p1 }), false, this.wireframe_0.GetTransformer());
        if (polylines.Count <= 0)
          return;
        this.iwireframeGraphicsFactory_0.CreatePath((DxfEntity) this.dxfMLeader_0, this.wireframe_0, color, false, polylines, false, true);
      }
    }

    private class Class67 : DxfMLeader.Class65
    {
      private DrawContext.Wireframe wireframe_0;
      private IWireframeGraphicsFactory2 iwireframeGraphicsFactory2_0;

      public Class67(
        DxfMLeader mleader,
        DrawContext.Wireframe drawContext,
        IWireframeGraphicsFactory2 graphicsFactory)
        : base(mleader)
      {
        this.wireframe_0 = drawContext;
        this.iwireframeGraphicsFactory2_0 = graphicsFactory;
      }

      public override DrawContext DrawContext
      {
        get
        {
          return (DrawContext) this.wireframe_0;
        }
      }

      public override void DrawLine(ArgbColor color, WW.Math.Point3D p0, WW.Math.Point3D p1)
      {
        IList<Polyline4D> polylines = DxfUtil.smethod_38(new Polyline3D(false, new WW.Math.Point3D[2]{ p0, p1 }), false, this.wireframe_0.GetTransformer());
        if (polylines.Count <= 0)
          return;
        Class940.smethod_3((DxfEntity) this.dxfMLeader_0, this.wireframe_0, this.iwireframeGraphicsFactory2_0, color, false, false, true, polylines);
      }
    }
  }
}
