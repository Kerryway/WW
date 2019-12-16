// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfMText
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns28;
using ns33;
using ns4;
using ns49;
using System;
using System.Collections.Generic;
using System.Text;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfMText : DxfEntity, IAnnotative
  {
    private string string_1 = string.Empty;
    private DxfObjectReference dxfObjectReference_6 = DxfObjectReference.Null;
    private double double_1 = 0.2;
    private AttachmentPoint attachmentPoint_0 = AttachmentPoint.TopLeft;
    private DrawingDirection drawingDirection_0 = DrawingDirection.ByStyle;
    private WW.Math.Vector3D vector3D_0 = WW.Math.Vector3D.ZAxis;
    private WW.Math.Vector3D vector3D_1 = WW.Math.Vector3D.XAxis;
    private LineSpacingStyle lineSpacingStyle_0 = LineSpacingStyle.AtLeast;
    private double double_4 = 1.0;
    internal const string string_0 = "ACAD_MTEXT_2008_RT";
    private WW.Math.Point3D point3D_0;
    private double double_2;
    private double double_3;
    private BackgroundFillFlags backgroundFillFlags_0;
    private BackgroundFillInfo backgroundFillInfo_0;
    private Bounds2D bounds2D_0;
    private bool bool_2;

    public DxfMText()
    {
    }

    public DxfMText(string text, WW.Math.Point3D insertionPoint)
    {
      this.string_1 = text;
      this.point3D_0 = insertionPoint;
    }

    public DxfMText(string text, WW.Math.Point3D insertionPoint, double height)
    {
      this.string_1 = text;
      this.point3D_0 = insertionPoint;
      this.double_1 = height;
    }

    public AttachmentPoint AttachmentPoint
    {
      get
      {
        if (!this.IsAnnotative)
          return this.attachmentPoint_0;
        DxfMTextObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfMTextObjectContextData;
        if (objectContextData != null)
          return objectContextData.AttachmentPoint;
        return this.attachmentPoint_0;
      }
      set
      {
        if (!this.IsAnnotative)
        {
          this.attachmentPoint_0 = value;
        }
        else
        {
          DxfMTextObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfMTextObjectContextData;
          if (objectContextData != null)
            objectContextData.AttachmentPoint = value;
          if (objectContextData == null || objectContextData.IsDefault)
            this.attachmentPoint_0 = value;
        }
        this.method_15();
      }
    }

    public DrawingDirection DrawingDirection
    {
      get
      {
        return this.drawingDirection_0;
      }
      set
      {
        this.drawingDirection_0 = value;
        this.method_15();
      }
    }

    public double BoxWidth
    {
      get
      {
        return this.TextBounds.Delta.X;
      }
    }

    public double BoxHeight
    {
      get
      {
        return this.TextBounds.Delta.Y;
      }
    }

    public double Height
    {
      get
      {
        if (this.double_1 == 0.0)
          this.double_1 = this.Style.FixedHeight;
        if (!this.bool_2)
          return this.double_1;
        DxfAnnotationScaleObjectContextData objectContextData1 = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true);
        DxfAnnotationScaleObjectContextData objectContextData2 = DxfAnnotationScaleObjectContextData.smethod_5((DxfHandledObject) this, false);
        if (objectContextData1 != null && !objectContextData1.IsDefault && objectContextData2 != null)
          return this.double_1 / objectContextData1.Scale.ScaleFactor * objectContextData2.Scale.ScaleFactor;
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
        this.method_15();
      }
    }

    public double LineSpacingFactor
    {
      get
      {
        return this.double_4;
      }
      set
      {
        this.double_4 = value;
        this.method_15();
      }
    }

    public BackgroundFillFlags BackgroundFillFlags
    {
      get
      {
        return this.backgroundFillFlags_0;
      }
      set
      {
        this.backgroundFillFlags_0 = value;
      }
    }

    public BackgroundFillInfo BackgroundFillInfo
    {
      get
      {
        return this.backgroundFillInfo_0;
      }
      set
      {
        this.backgroundFillInfo_0 = value;
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
        this.method_15();
      }
    }

    public DxfTextStyle Style
    {
      get
      {
        if (this.dxfObjectReference_6 == DxfObjectReference.Null)
          this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) this.Model.DefaultTextStyle);
        return (DxfTextStyle) this.dxfObjectReference_6.Value;
      }
      set
      {
        this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        this.method_15();
      }
    }

    internal DxfTextStyle StyleInternal
    {
      get
      {
        return (DxfTextStyle) this.dxfObjectReference_6.Value;
      }
      set
      {
        this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public string Text
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
        this.method_15();
      }
    }

    public string SimplifiedText
    {
      get
      {
        return Class594.smethod_4(this);
      }
    }

    [Obsolete("Use ReferenceRectangleWidth instead.")]
    public double Width
    {
      get
      {
        return this.ReferenceRectangleWidth;
      }
      set
      {
        this.ReferenceRectangleWidth = value;
      }
    }

    public double ReferenceRectangleWidth
    {
      get
      {
        return this.double_2;
      }
      set
      {
        this.double_2 = value;
        this.method_15();
      }
    }

    public double ReferenceRectangleHeight
    {
      get
      {
        return this.double_3;
      }
      set
      {
        this.double_3 = value;
        this.method_15();
      }
    }

    [Obsolete]
    public double Thickness
    {
      get
      {
        return 0.0;
      }
    }

    public WW.Math.Point3D InsertionPoint
    {
      get
      {
        if (!this.IsAnnotative)
          return this.point3D_0;
        DxfMTextObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfMTextObjectContextData;
        if (objectContextData != null)
          return objectContextData.Location;
        return this.point3D_0;
      }
      set
      {
        if (!this.IsAnnotative)
        {
          this.point3D_0 = value;
        }
        else
        {
          DxfMTextObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfMTextObjectContextData;
          if (objectContextData != null)
            objectContextData.Location = value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.point3D_0 = value;
        }
      }
    }

    public Bounds2D TextBounds
    {
      get
      {
        if (this.bounds2D_0 == null)
        {
          this.bounds2D_0 = new Bounds2D();
          Class666.smethod_4(this, Colors.Pink, (short) 0, Matrix4D.Identity, this.bounds2D_0);
        }
        return this.bounds2D_0;
      }
    }

    public WW.Math.Vector3D XAxis
    {
      get
      {
        if (!this.IsAnnotative)
          return this.vector3D_1;
        DxfMTextObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfMTextObjectContextData;
        if (objectContextData != null)
          return objectContextData.XDirection;
        return this.vector3D_1;
      }
      set
      {
        if (!this.IsAnnotative)
        {
          this.vector3D_1 = value;
        }
        else
        {
          DxfMTextObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfMTextObjectContextData;
          if (objectContextData != null)
            objectContextData.XDirection = value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.vector3D_1 = value;
        }
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

    public override string EntityType
    {
      get
      {
        return "MTEXT";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbMText";
      }
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
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfMText.Class416 class416 = new DxfMText.Class416();
      // ISSUE: reference to a compiler-generated field
      class416.dxfMText_0 = this;
      // ISSUE: reference to a compiler-generated field
      class416.point3D_0 = this.point3D_0;
      // ISSUE: reference to a compiler-generated field
      class416.double_0 = this.double_1;
      // ISSUE: reference to a compiler-generated field
      class416.double_1 = this.double_2;
      // ISSUE: reference to a compiler-generated field
      class416.vector3D_0 = this.vector3D_0;
      // ISSUE: reference to a compiler-generated field
      class416.vector3D_1 = this.vector3D_1;
      // ISSUE: reference to a compiler-generated field
      class416.attachmentPoint_0 = this.attachmentPoint_0;
      this.vector3D_1 = matrix.Transform(this.vector3D_1);
      this.vector3D_1.Normalize();
      this.vector3D_0 = matrix.Transform(this.vector3D_0);
      this.vector3D_0.Normalize();
      Matrix4D inverse = DxfUtil.GetToWCSTransform(this.vector3D_1, this.vector3D_0).GetInverse();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(class416.vector3D_1, class416.vector3D_0);
      Matrix4D matrix4D = inverse * matrix * toWcsTransform;
      this.point3D_0 = matrix.Transform(this.point3D_0);
      this.double_1 = matrix4D.Transform(new WW.Math.Vector3D(0.0, this.double_1, 0.0)).GetLength();
      this.double_2 = matrix4D.Transform(new WW.Math.Vector3D(this.double_2, 0.0, 0.0)).GetLength();
      if (matrix.GetDeterminant() < 0.0)
      {
        // ISSUE: reference to a compiler-generated field
        bool flag = WW.Math.Vector3D.DotProduct(this.vector3D_1, class416.vector3D_1) < 0.0;
        Bounds2D textBounds = this.TextBounds;
        if (flag)
        {
          this.vector3D_1 = -this.vector3D_1;
          switch (this.attachmentPoint_0)
          {
            case AttachmentPoint.TopLeft:
              this.attachmentPoint_0 = AttachmentPoint.TopRight;
              break;
            case AttachmentPoint.TopRight:
              this.attachmentPoint_0 = AttachmentPoint.TopLeft;
              break;
            case AttachmentPoint.MiddleLeft:
              this.attachmentPoint_0 = AttachmentPoint.MiddleRight;
              break;
            case AttachmentPoint.MiddleRight:
              this.attachmentPoint_0 = AttachmentPoint.MiddleLeft;
              break;
            case AttachmentPoint.BottomLeft:
              this.attachmentPoint_0 = AttachmentPoint.BottomRight;
              break;
            case AttachmentPoint.BottomRight:
              this.attachmentPoint_0 = AttachmentPoint.BottomLeft;
              break;
          }
        }
        else
        {
          WW.Math.Vector3D.CrossProduct(this.vector3D_0, this.vector3D_1).GetUnit();
          switch (this.attachmentPoint_0)
          {
            case AttachmentPoint.TopLeft:
              this.attachmentPoint_0 = AttachmentPoint.BottomLeft;
              break;
            case AttachmentPoint.TopCenter:
              this.attachmentPoint_0 = AttachmentPoint.BottomCenter;
              break;
            case AttachmentPoint.TopRight:
              this.attachmentPoint_0 = AttachmentPoint.BottomRight;
              break;
            case AttachmentPoint.BottomLeft:
              this.attachmentPoint_0 = AttachmentPoint.TopLeft;
              break;
            case AttachmentPoint.BottomCenter:
              this.attachmentPoint_0 = AttachmentPoint.TopCenter;
              break;
            case AttachmentPoint.BottomRight:
              this.attachmentPoint_0 = AttachmentPoint.TopRight;
              break;
          }
        }
      }
      this.method_15();
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfMText.Class417()
      {
        class416_0 = class416,
        point3D_0 = this.point3D_0,
        double_0 = this.double_1,
        double_1 = this.double_2,
        vector3D_0 = this.vector3D_0,
        vector3D_1 = this.vector3D_1,
        attachmentPoint_0 = this.attachmentPoint_0
      }.method_0), new System.Action(class416.method_0)));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      if (context.Config.TryDrawingTextAsText && graphicsFactory.SupportsText)
      {
        graphicsFactory.CreateMText(this, context);
      }
      else
      {
        this.method_16((DrawContext) context, (IPathDrawer) new ns0.Class0((DxfEntity) this, context, graphicsFactory));
        if (!context.Config.ShowTextAlignmentPoints)
          return;
        IList<Polyline4D> polylines = DxfUtil.smethod_36(this.method_18(), false, context.GetTransformer());
        if (polylines.Count <= 0)
          return;
        graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), true, polylines, false, true);
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      if (context.Config.TryDrawingTextAsText && graphicsFactory.SupportsText)
      {
        graphicsFactory.BeginGeometry((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), true, true, false, true);
        graphicsFactory.CreateMText(this);
        graphicsFactory.EndGeometry();
      }
      else
      {
        this.method_16((DrawContext) context, (IPathDrawer) new Class396((DxfEntity) this, context, graphicsFactory));
        if (!context.Config.ShowTextAlignmentPoints)
          return;
        IList<Polyline4D> polylines = DxfUtil.smethod_36(this.method_18(), false, context.GetTransformer());
        if (polylines.Count <= 0)
          return;
        Class940.smethod_3((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), true, false, true, polylines);
      }
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      this.method_16((DrawContext) context, (IPathDrawer) new Class473((DxfEntity) this, context, graphicsFactory));
      if (!context.Config.ShowTextAlignmentPoints)
        return;
      graphicsFactory.SetColor(ArgbColors.White);
      IList<WW.Math.Geometry.Polyline3D> polylines = this.method_18();
      if (polylines.Count <= 0)
        return;
      Class940.smethod_15((DxfEntity) this, context, graphicsFactory, polylines);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      if (!graphics.AddExistingGraphicElement1(parentGraphicElementBlock, (DxfEntity) this, plotColor))
        return;
      this.method_16((DrawContext) context, (IPathDrawer) new Class355((DxfEntity) this, context, graphics, parentGraphicElementBlock));
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfMText dxfMtext = (DxfMText) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfMtext == null)
      {
        dxfMtext = new DxfMText();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfMtext);
        dxfMtext.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfMtext;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfMText dxfMtext = (DxfMText) from;
      this.string_1 = dxfMtext.string_1;
      this.Style = Class906.GetTextStyle(cloneContext, dxfMtext.Style);
      this.point3D_0 = dxfMtext.point3D_0;
      this.double_1 = dxfMtext.double_1;
      this.double_2 = dxfMtext.double_2;
      this.double_3 = dxfMtext.double_3;
      this.attachmentPoint_0 = dxfMtext.attachmentPoint_0;
      this.drawingDirection_0 = dxfMtext.drawingDirection_0;
      this.vector3D_0 = dxfMtext.vector3D_0;
      this.vector3D_1 = dxfMtext.vector3D_1;
      this.lineSpacingStyle_0 = dxfMtext.lineSpacingStyle_0;
      this.double_4 = dxfMtext.double_4;
      this.backgroundFillFlags_0 = dxfMtext.backgroundFillFlags_0;
      if (dxfMtext.backgroundFillInfo_0 == null)
        this.backgroundFillInfo_0 = (BackgroundFillInfo) null;
      else
        this.backgroundFillInfo_0 = dxfMtext.backgroundFillInfo_0.Clone(cloneContext);
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      bool flag = base.Validate(model, messages);
      if (this.backgroundFillFlags_0 == BackgroundFillFlags.UseBackgroundFillColor && this.backgroundFillInfo_0 == null)
      {
        messages.Add(new DxfMessage(DxfStatus.MTextMustHaveBackgroundFillInfo, Severity.Error));
        flag = false;
      }
      return flag;
    }

    public override string ToString()
    {
      return this.SimplifiedText;
    }

    public override Matrix4D Transform
    {
      get
      {
        return Transformation4D.Translation((WW.Math.Vector3D) this.InsertionPoint) * DxfUtil.GetToWCSTransform(this.vector3D_1, this.vector3D_0);
      }
    }

    internal override void vmethod_10(DxfModel model)
    {
      base.vmethod_10(model);
      DxfAnnotationScaleObjectContextData.smethod_8((DxfEntity) this);
      this.bool_2 = Class1064.smethod_0((DxfHandledObject) this, model);
      if (this.ExtensionDictionary == null)
        return;
      DxfXRecord valueByName = this.ExtensionDictionary.GetValueByName("ACAD_MTEXT_2008_RT") as DxfXRecord;
      if (valueByName == null)
        return;
      string empty = string.Empty;
      double? nullable = new double?();
      foreach (DxfXRecordValue dxfXrecordValue in (List<DxfXRecordValue>) valueByName.Values)
      {
        switch (dxfXrecordValue.Code)
        {
          case 1:
            empty += (string) dxfXrecordValue.Value;
            continue;
          case 40:
            nullable = new double?((double) dxfXrecordValue.Value);
            continue;
          default:
            continue;
        }
      }
      if (model.Header.AcadVersion < DxfVersion.Dxf21)
      {
        if (!nullable.HasValue)
          return;
        if (MathUtil.AreApproxEqual(this.method_14(empty, model.Header.DrawingCodePage), nullable.Value, 1E-10))
        {
          this.string_1 = empty;
        }
        else
        {
          if (!MathUtil.AreApproxEqual(this.method_13(this.string_1), nullable.Value, 1E-10))
            return;
          this.string_1 = empty;
        }
      }
      else
      {
        if (!nullable.HasValue || !MathUtil.AreApproxEqual(this.method_13(this.string_1), nullable.Value, 1E-10))
          return;
        this.string_1 = empty;
      }
    }

    private double method_13(string s)
    {
      byte[] bytes = Encoding.Unicode.GetBytes(s);
      double num1 = 0.0;
      for (int index = 0; index < bytes.Length; index += 2)
      {
        int num2 = (int) bytes[index] + ((int) bytes[index + 1] << 8);
        num1 += (double) (num2 * ((index >> 1) + 1));
      }
      return num1;
    }

    private double method_14(string s, DrawingCodePage drawingCodePage)
    {
      byte[] bytes = Encoding.GetEncoding((int) drawingCodePage).GetBytes(s);
      double num = 0.0;
      for (int index = 0; index < bytes.Length; ++index)
        num += (double) ((int) bytes[index] * (index + 1));
      return num;
    }

    internal override short vmethod_6(Class432 w)
    {
      return 44;
    }

    private void method_15()
    {
      this.bounds2D_0 = (Bounds2D) null;
    }

    private void method_16(DrawContext context, IPathDrawer pathDrawer)
    {
      Bounds2D collectBounds = new Bounds2D();
      IList<Class908> class908List = Class666.smethod_4(this, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this), Matrix4D.Identity, collectBounds);
      if (this.backgroundFillFlags_0 == BackgroundFillFlags.UseBackgroundFillColor && this.backgroundFillInfo_0 != null)
      {
        double num1 = this.double_1 * (this.backgroundFillInfo_0.BorderOffsetFactor - 1.0);
        double num2 = this.double_2 == 0.0 ? collectBounds.Delta.X : this.double_2;
        double y = collectBounds.Delta.Y;
        double num3;
        double num4;
        switch (this.AttachmentPoint)
        {
          case AttachmentPoint.TopLeft:
            num3 = collectBounds.Corner1.X + 0.5 * num2;
            num4 = collectBounds.Corner2.Y - 0.5 * y;
            break;
          case AttachmentPoint.TopCenter:
            num3 = collectBounds.Center.X;
            num4 = collectBounds.Corner2.Y - 0.5 * y;
            break;
          case AttachmentPoint.TopRight:
            num3 = collectBounds.Corner2.X - 0.5 * num2;
            num4 = collectBounds.Corner2.Y - 0.5 * y;
            break;
          case AttachmentPoint.MiddleLeft:
            num3 = collectBounds.Corner1.X + 0.5 * num2;
            num4 = collectBounds.Center.Y;
            break;
          case AttachmentPoint.MiddleCenter:
            num3 = collectBounds.Center.X;
            num4 = collectBounds.Center.Y;
            break;
          case AttachmentPoint.MiddleRight:
            num3 = collectBounds.Corner2.X - 0.5 * num2;
            num4 = collectBounds.Center.Y;
            break;
          case AttachmentPoint.BottomLeft:
            num3 = collectBounds.Corner1.X + 0.5 * num2;
            num4 = collectBounds.Corner1.Y + 0.5 * y;
            break;
          case AttachmentPoint.BottomCenter:
            num3 = collectBounds.Center.X;
            num4 = collectBounds.Corner1.Y + 0.5 * y;
            break;
          case AttachmentPoint.BottomRight:
            num3 = collectBounds.Corner2.X - 0.5 * num2;
            num4 = collectBounds.Corner1.Y + 0.5 * y;
            break;
          default:
            num3 = collectBounds.Center.X;
            num4 = collectBounds.Center.Y;
            break;
        }
        pathDrawer.DrawPath((IShape2D) new Rectangle2D(num3 - 0.5 * num2 - num1, num4 - 0.5 * y - num1, num3 + 0.5 * num2 + num1, num4 + 0.5 * y + num1), this.Transform, this.backgroundFillInfo_0.Color, context.GetLineWeight((DxfEntity) this), true, false, 0.0);
      }
      foreach (Class908 class908 in (IEnumerable<Class908>) class908List)
        class908.Draw(pathDrawer, Matrix4D.Identity, 0.0);
    }

    private IList<Polyline4D> method_17(
      IClippingTransformer transformer,
      Bounds2D textBounds)
    {
      Matrix4D transform = this.Transform;
      IClippingTransformer transformer1 = (IClippingTransformer) transformer.Clone();
      transformer1.SetPreTransform(transform);
      double num = this.double_1 * (this.backgroundFillInfo_0.BorderOffsetFactor - 1.0);
      double x1 = textBounds.Corner1.X - num;
      double x2 = this.double_2 + num;
      double y1 = textBounds.Corner1.Y - num;
      double y2 = textBounds.Corner2.Y + num;
      return DxfUtil.smethod_38(new WW.Math.Geometry.Polyline3D(true, new WW.Math.Point3D[4]{ new WW.Math.Point3D(x1, y1, 0.0), new WW.Math.Point3D(x2, y1, 0.0), new WW.Math.Point3D(x2, y2, 0.0), new WW.Math.Point3D(x1, y2, 0.0) }), true, transformer1);
    }

    private IList<WW.Math.Geometry.Polyline3D> method_18()
    {
      IList<WW.Math.Geometry.Polyline3D> polyline3DList = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>();
      double double1 = this.double_1;
      polyline3DList.Add(new WW.Math.Geometry.Polyline3D(new WW.Math.Point3D[2]
      {
        this.point3D_0 - double1 * WW.Math.Vector3D.XAxis,
        this.point3D_0 + double1 * WW.Math.Vector3D.XAxis
      }));
      polyline3DList.Add(new WW.Math.Geometry.Polyline3D(new WW.Math.Point3D[2]
      {
        this.point3D_0 - double1 * WW.Math.Vector3D.YAxis,
        this.point3D_0 + double1 * WW.Math.Vector3D.YAxis
      }));
      polyline3DList.Add(new WW.Math.Geometry.Polyline3D(new WW.Math.Point3D[2]
      {
        this.point3D_0 - double1 * WW.Math.Vector3D.ZAxis,
        this.point3D_0 + double1 * WW.Math.Vector3D.ZAxis
      }));
      return polyline3DList;
    }

    public bool IsAnnotative
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

    public DxfAnnotationScaleObjectContextData CreateContextData(
      DxfScale scale)
    {
      return (DxfAnnotationScaleObjectContextData) new DxfMTextObjectContextData(this, scale);
    }
  }
}
