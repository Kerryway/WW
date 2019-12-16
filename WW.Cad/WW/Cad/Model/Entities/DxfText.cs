// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfText
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns1;
using ns2;
using ns28;
using ns33;
using ns36;
using ns4;
using ns43;
using ns49;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using WW.Actions;
using WW.Cad.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;
using WW.Windows.Forms;

namespace WW.Cad.Model.Entities
{
  public class DxfText : DxfEntity, IControlPointCollection, IAnnotative
  {
    private static readonly IControlPoint[] icontrolPoint_0 = new IControlPoint[1]{ DxfText.Class524.icontrolPoint_0 };
    private string string_0 = string.Empty;
    private DxfObjectReference dxfObjectReference_6 = DxfObjectReference.Null;
    private double double_1 = 1.0;
    private double double_2 = 1.0;
    private Vector3D vector3D_0 = Vector3D.ZAxis;
    private WW.Math.Point3D point3D_0;
    private WW.Math.Point3D? nullable_0;
    private double double_3;
    private double double_4;
    private double double_5;
    private TextGenerationFlags textGenerationFlags_0;
    private TextHorizontalAlignment textHorizontalAlignment_0;
    private TextVerticalAlignment textVerticalAlignment_0;
    private bool bool_2;
    private Bounds2D bounds2D_0;

    public DxfText()
    {
    }

    public DxfText(string text, WW.Math.Point3D alignmentPoint1)
    {
      this.Text = text;
      this.point3D_0 = alignmentPoint1;
    }

    public DxfText(string text, WW.Math.Point3D alignmentPoint1, double height)
    {
      this.Text = text;
      this.point3D_0 = alignmentPoint1;
      this.double_1 = height;
    }

    public DxfText(DxfText templateText)
      : base((DxfEntity) templateText)
    {
      this.string_0 = templateText.string_0;
      DxfTextStyle style = templateText.Style;
      if (style != null)
        this.Style = style;
      this.point3D_0 = templateText.point3D_0;
      if (templateText.nullable_0.HasValue)
        this.nullable_0 = templateText.nullable_0;
      this.double_1 = templateText.double_1;
      this.double_3 = templateText.double_3;
      this.double_4 = templateText.double_4;
      this.vector3D_0 = templateText.vector3D_0;
      this.double_5 = templateText.double_5;
      this.textGenerationFlags_0 = templateText.textGenerationFlags_0;
      this.textHorizontalAlignment_0 = templateText.textHorizontalAlignment_0;
      this.textVerticalAlignment_0 = templateText.textVerticalAlignment_0;
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
        this.bounds2D_0 = (Bounds2D) null;
      }
    }

    public string SimplifiedText
    {
      get
      {
        return Class594.smethod_5(this);
      }
    }

    public DxfTextStyle Style
    {
      get
      {
        if (this.dxfObjectReference_6 == DxfObjectReference.Null && this.Model != null)
          this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) this.Model.DefaultTextStyle);
        return (DxfTextStyle) this.dxfObjectReference_6.Value;
      }
      set
      {
        if (value == null)
          throw new DxfException("Text style may not be null.");
        this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        this.bounds2D_0 = (Bounds2D) null;
      }
    }

    public double Height
    {
      get
      {
        if (this.double_1 == 0.0)
          this.double_1 = this.Style.FixedHeight;
        if (!this.IsAnnotativeForRendering)
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
        this.bounds2D_0 = (Bounds2D) null;
      }
    }

    public double WidthFactor
    {
      get
      {
        return this.double_2;
      }
      set
      {
        this.double_2 = value;
        this.bounds2D_0 = (Bounds2D) null;
      }
    }

    public double Rotation
    {
      get
      {
        if (!this.IsAnnotativeForRendering)
          return this.double_3;
        DxfTextObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfTextObjectContextData;
        if (objectContextData != null)
          return objectContextData.Rotation;
        return this.double_3;
      }
      set
      {
        if (!this.IsAnnotativeForRendering)
        {
          this.double_3 = value;
        }
        else
        {
          DxfTextObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfTextObjectContextData;
          if (objectContextData != null)
            objectContextData.Rotation = value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.double_3 = value;
        }
      }
    }

    public double ObliqueAngle
    {
      get
      {
        return this.double_4;
      }
      set
      {
        this.double_4 = value;
        this.bounds2D_0 = (Bounds2D) null;
      }
    }

    public WW.Math.Point3D AlignmentPoint1
    {
      get
      {
        if (!this.IsAnnotativeForRendering)
          return this.point3D_0;
        DxfTextObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfTextObjectContextData;
        if (objectContextData != null)
          return new WW.Math.Point3D(objectContextData.Position.X, objectContextData.Position.Y, this.point3D_0.Z);
        return this.point3D_0;
      }
      set
      {
        if (!this.IsAnnotativeForRendering)
        {
          this.point3D_0 = value;
        }
        else
        {
          DxfTextObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfTextObjectContextData;
          if (objectContextData != null)
          {
            this.point3D_0.Z = value.Z;
            objectContextData.Position = new WW.Math.Point2D(value.X, value.Y);
          }
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.point3D_0 = value;
        }
      }
    }

    public WW.Math.Point3D? AlignmentPoint2
    {
      get
      {
        if (!this.IsAnnotativeForRendering)
          return this.nullable_0;
        DxfTextObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfTextObjectContextData;
        if (objectContextData != null)
          return new WW.Math.Point3D?(new WW.Math.Point3D(objectContextData.AlignmentPoint.X, objectContextData.AlignmentPoint.Y, this.point3D_0.Z));
        return this.nullable_0;
      }
      set
      {
        if (this.IsAnnotativeForRendering && value.HasValue)
        {
          DxfTextObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfTextObjectContextData;
          if (objectContextData != null)
          {
            this.point3D_0.Z = value.Value.Z;
            objectContextData.AlignmentPoint = new WW.Math.Point2D(value.Value.X, value.Value.Y);
          }
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.nullable_0 = value;
        }
        else
          this.nullable_0 = value;
      }
    }

    public Vector3D ZAxis
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

    public double Thickness
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

    [Obsolete("Replaced by property TextGenerationFlags.")]
    public TextGenerationFlags GenerationFlags
    {
      get
      {
        return this.textGenerationFlags_0;
      }
      set
      {
        this.textGenerationFlags_0 = value;
      }
    }

    public TextGenerationFlags TextGenerationFlags
    {
      get
      {
        return this.textGenerationFlags_0;
      }
      set
      {
        this.textGenerationFlags_0 = value;
      }
    }

    public bool IsBackwards
    {
      get
      {
        return (this.textGenerationFlags_0 & TextGenerationFlags.Backwards) != TextGenerationFlags.None;
      }
      set
      {
        if (value)
          this.textGenerationFlags_0 |= TextGenerationFlags.Backwards;
        else
          this.textGenerationFlags_0 &= ~TextGenerationFlags.Backwards;
      }
    }

    private bool IsThisOrStyleBackwards
    {
      get
      {
        if (this.IsBackwards)
          return true;
        if (this.Style != null)
          return this.Style.IsBackwards;
        return false;
      }
    }

    public bool IsUpsideDown
    {
      get
      {
        return (this.textGenerationFlags_0 & TextGenerationFlags.UpsideDown) != TextGenerationFlags.None;
      }
      set
      {
        if (value)
          this.textGenerationFlags_0 |= TextGenerationFlags.UpsideDown;
        else
          this.textGenerationFlags_0 &= ~TextGenerationFlags.UpsideDown;
      }
    }

    private bool IsThisOrStyleUpsideDown
    {
      get
      {
        if (this.IsUpsideDown)
          return true;
        if (this.Style != null)
          return this.Style.IsUpsideDown;
        return false;
      }
    }

    public TextHorizontalAlignment HorizontalAlignment
    {
      get
      {
        if (!this.IsAnnotativeForRendering)
          return this.textHorizontalAlignment_0;
        DxfTextObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfTextObjectContextData;
        if (objectContextData != null)
          return objectContextData.HorizontalAlignment;
        return this.textHorizontalAlignment_0;
      }
      set
      {
        if (!this.IsAnnotativeForRendering)
        {
          this.textHorizontalAlignment_0 = value;
        }
        else
        {
          DxfTextObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfTextObjectContextData;
          if (objectContextData != null)
            objectContextData.HorizontalAlignment = value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.textHorizontalAlignment_0 = value;
        }
      }
    }

    public TextVerticalAlignment VerticalAlignment
    {
      get
      {
        return this.textVerticalAlignment_0;
      }
      set
      {
        this.textVerticalAlignment_0 = value;
      }
    }

    public override string EntityType
    {
      get
      {
        return "TEXT";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbText";
      }
    }

    public override Matrix4D Transform
    {
      get
      {
        Matrix4D inUcsTransform = this.InUcsTransform;
        Vector3D alignmentPoint1 = (Vector3D) this.AlignmentPoint1;
        if (this.AlignmentPoint2.HasValue && (this.HorizontalAlignment != TextHorizontalAlignment.Left || this.VerticalAlignment != TextVerticalAlignment.Baseline))
          alignmentPoint1 = (Vector3D) this.AlignmentPoint2.Value;
        return DxfUtil.GetToWCSTransform(this.ZAxis) * (Transformation4D.Translation(alignmentPoint1) * inUcsTransform);
      }
    }

    private Matrix4D InUcsTransform
    {
      get
      {
        Matrix4D matrix4D = new Matrix4D(this.IsThisOrStyleBackwards ? -1.0 : 1.0, 0.0, 0.0, 0.0, 0.0, this.IsThisOrStyleUpsideDown ? -1.0 : 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
        matrix4D = Transformation4D.RotateZ(this.Rotation) * matrix4D;
        return matrix4D;
      }
    }

    public Bounds2D TextBounds
    {
      get
      {
        if (this.bounds2D_0 == null)
        {
          this.bounds2D_0 = new Bounds2D();
          Class666.smethod_5(this, Colors.Pink, (short) 0, Matrix4D.Identity, this.bounds2D_0);
        }
        return this.bounds2D_0;
      }
    }

    public double BoxWidth
    {
      get
      {
        if (!this.TextBounds.Initialized)
          return 0.0;
        return this.TextBounds.Delta.X;
      }
    }

    public double BoxHeight
    {
      get
      {
        if (!this.TextBounds.Initialized)
          return 0.0;
        return this.TextBounds.Delta.Y;
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
      DxfText.Class533 class533 = new DxfText.Class533();
      // ISSUE: reference to a compiler-generated field
      class533.dxfText_0 = this;
      // ISSUE: reference to a compiler-generated field
      class533.vector3D_0 = this.vector3D_0;
      // ISSUE: reference to a compiler-generated field
      class533.double_0 = this.double_5;
      // ISSUE: reference to a compiler-generated field
      class533.point3D_0 = this.point3D_0;
      // ISSUE: reference to a compiler-generated field
      class533.nullable_0 = this.nullable_0;
      // ISSUE: reference to a compiler-generated field
      class533.double_1 = this.double_3;
      // ISSUE: reference to a compiler-generated field
      class533.double_2 = this.double_1;
      // ISSUE: reference to a compiler-generated field
      class533.double_3 = this.double_2;
      // ISSUE: reference to a compiler-generated field
      class533.double_4 = this.double_4;
      // ISSUE: reference to a compiler-generated field
      class533.textHorizontalAlignment_0 = this.textHorizontalAlignment_0;
      // ISSUE: reference to a compiler-generated field
      class533.textVerticalAlignment_0 = this.textVerticalAlignment_0;
      this.vector3D_0 = matrix.Transform(this.vector3D_0);
      this.double_5 *= this.vector3D_0.GetLength();
      this.vector3D_0.Normalize();
      Matrix4D inverse = DxfUtil.GetToWCSTransform(this.vector3D_0).GetInverse();
      // ISSUE: reference to a compiler-generated field
      Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(class533.vector3D_0);
      Matrix4D matrix4D1 = inverse * matrix * toWcsTransform;
      this.point3D_0 = matrix4D1.Transform(this.point3D_0);
      if (this.nullable_0.HasValue)
        this.nullable_0 = new WW.Math.Point3D?(matrix4D1.Transform(this.nullable_0.Value));
      Vector3D xaxis = Vector3D.XAxis;
      Vector3D vector1 = Vector3D.YAxis * this.double_1;
      Matrix4D matrix4D2 = Transformation4D.RotateZ(this.double_3);
      Vector3D vector2 = matrix4D2.Transform(xaxis);
      Vector3D vector3 = matrix4D2.Transform(vector1);
      Vector3D v = vector2;
      if (this.double_1 > 0.0)
      {
        if (System.Math.Abs(this.WidthFactor) < 1E-10)
          vector2 *= this.Height;
        else
          vector2 *= this.WidthFactor * this.Height;
      }
      Vector3D vector4 = vector3;
      if (System.Math.Abs(this.ObliqueAngle) >= 1E-10)
        vector4 = Transformation4D.RotateZ(-this.double_4).Transform(vector4);
      Vector3D vector3D1 = matrix4D1.Transform(vector2);
      Vector3D a = matrix4D1.Transform(vector4);
      Vector3D vector3D2 = matrix4D1.Transform(vector3);
      this.double_3 = Vector3D.GetAngle(Vector3D.XAxis, vector3D1, Vector3D.ZAxis);
      if (this.Height > 0.0)
      {
        Vector3D b = a;
        if (vector3D1.GetLengthSquared() > 1E-10)
          b = Vector3D.OrthogonalProjection(a, vector3D1);
        this.double_1 = b.GetLength();
        if (!Vector3D.AreVectorsPerpendicular(a, vector3D1, 1E-10))
          this.double_4 = Vector3D.GetAngle(a, b);
        this.double_2 = vector3D1.GetLength() / this.double_1;
      }
      if (matrix.GetDeterminant() < 0.0)
      {
        Vector3D vector3D3 = vector3D1.GetUnit();
        Vector3D vector3D4 = vector3D2.GetUnit();
        bool flag = Vector3D.DotProduct(vector3D1, v) < 0.0;
        Bounds2D bounds2D = this.bounds2D_0 = new Bounds2D();
        Vector2D alignmentTranslation;
        Vector2D alignmentScaling;
        Class666.smethod_6(this, Colors.Pink, (short) 0, Matrix4D.Identity, this.bounds2D_0, out alignmentTranslation, out alignmentScaling);
        if (flag)
        {
          switch (this.textHorizontalAlignment_0)
          {
            case TextHorizontalAlignment.Left:
              this.textHorizontalAlignment_0 = TextHorizontalAlignment.Right;
              break;
            case TextHorizontalAlignment.Right:
              this.textHorizontalAlignment_0 = TextHorizontalAlignment.Left;
              break;
          }
          vector3D3 = -vector3D3;
          this.point3D_0 -= vector3D3 * bounds2D.Delta.X;
          this.double_3 += System.Math.PI;
          if (this.double_3 >= 2.0 * System.Math.PI)
            this.double_3 -= 2.0 * System.Math.PI;
        }
        else
        {
          double num = 1.0;
          switch (this.textVerticalAlignment_0)
          {
            case TextVerticalAlignment.Bottom:
              this.textVerticalAlignment_0 = TextVerticalAlignment.Top;
              num = 0.0;
              break;
            case TextVerticalAlignment.Middle:
              num = 0.0;
              break;
            case TextVerticalAlignment.Top:
              this.textVerticalAlignment_0 = TextVerticalAlignment.Bottom;
              num = 0.0;
              break;
          }
          this.point3D_0 += num * vector3D4 * bounds2D.Delta.Y;
          vector3D4 = -vector3D4;
        }
        if (this.nullable_0.HasValue)
        {
          if (flag)
          {
            double num = 1.0;
            if (this.textHorizontalAlignment_0 == TextHorizontalAlignment.Left || this.textHorizontalAlignment_0 == TextHorizontalAlignment.Center || (this.textHorizontalAlignment_0 == TextHorizontalAlignment.Right || this.textHorizontalAlignment_0 == TextHorizontalAlignment.Middle))
              num = 0.0;
            this.nullable_0 = new WW.Math.Point3D?(this.nullable_0.Value + num * vector3D3 * bounds2D.Delta.X);
          }
          else
          {
            double num = 1.0;
            if (this.textVerticalAlignment_0 == TextVerticalAlignment.Baseline)
              num = -1.0;
            else if (this.textVerticalAlignment_0 == TextVerticalAlignment.Bottom || this.textVerticalAlignment_0 == TextVerticalAlignment.Top || this.textVerticalAlignment_0 == TextVerticalAlignment.Middle)
              num = 0.0;
            this.nullable_0 = new WW.Math.Point3D?(this.nullable_0.Value + num * vector3D4 * bounds2D.Delta.Y);
          }
        }
        else if (this.textHorizontalAlignment_0 != TextHorizontalAlignment.Left || this.textVerticalAlignment_0 != TextVerticalAlignment.Baseline)
          this.nullable_0 = new WW.Math.Point3D?(this.point3D_0 + vector3D3 * (this.bounds2D_0.Delta.X + alignmentTranslation.X) + (this.textVerticalAlignment_0 != TextVerticalAlignment.Baseline ? vector3D4 * (this.bounds2D_0.Delta.Y + alignmentTranslation.Y) : Vector3D.Zero));
      }
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((WW.Actions.ICommand) new WW.Actions.Command((object) this, new System.Action(new DxfText.Class534()
      {
        class533_0 = class533,
        vector3D_0 = this.vector3D_0,
        double_0 = this.double_5,
        point3D_0 = this.point3D_0,
        nullable_0 = this.nullable_0,
        double_1 = this.double_3,
        double_2 = this.double_1,
        double_3 = this.double_2,
        double_4 = this.double_4,
        textHorizontalAlignment_0 = this.textHorizontalAlignment_0,
        textVerticalAlignment_0 = this.textVerticalAlignment_0
      }.method_0), new System.Action(class533.method_0)));
    }

    private void method_13(DrawContext context)
    {
      Matrix4D transform = this.Transform;
      double angleAroundAxis = Vector3D.GetAngleAroundAxis((context.vmethod_2() * transform).Transform(Vector3D.XAxis), Vector3D.XAxis, Vector3D.ZAxis);
      Vector3D v = new Vector3D(transform.M03, transform.M13, transform.M23);
      context.vmethod_0((IClippingTransformer) new Class383(Transformation4D.Translation(v) * Transformation4D.RotateZ(angleAroundAxis) * Transformation4D.Translation(-v)));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      bool orientationToLayout;
      if (orientationToLayout = this.MatchOrientationToLayout)
        this.method_13((DrawContext) context);
      if (context.Config.TryDrawingTextAsText && graphicsFactory.SupportsText && !this.method_14())
        graphicsFactory.CreateText(this, context, context.GetPlotColor((DxfEntity) this));
      else
        this.method_15((IPathDrawer) new ns0.Class0((DxfEntity) this, context, graphicsFactory), this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
      if (!orientationToLayout)
        return;
      context.vmethod_1();
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      bool orientationToLayout;
      if (orientationToLayout = this.MatchOrientationToLayout)
        this.method_13((DrawContext) context);
      if (context.Config.TryDrawingTextAsText && graphicsFactory.SupportsText && !this.method_14())
      {
        graphicsFactory.BeginGeometry((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), true, true, false, true);
        graphicsFactory.CreateText(this);
        graphicsFactory.EndGeometry();
      }
      else
        this.method_15((IPathDrawer) new Class396((DxfEntity) this, context, graphicsFactory), this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
      if (!orientationToLayout)
        return;
      context.vmethod_1();
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      bool orientationToLayout;
      if (orientationToLayout = this.MatchOrientationToLayout)
        this.method_13((DrawContext) context);
      this.method_15((IPathDrawer) new Class473((DxfEntity) this, context, graphicsFactory), this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
      if (!orientationToLayout)
        return;
      context.vmethod_1();
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      WW.Cad.Drawing.Surface.Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      bool orientationToLayout;
      if (orientationToLayout = this.MatchOrientationToLayout)
        this.method_13((DrawContext) context);
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      if (graphics.AddExistingGraphicElement1(parentGraphicElementBlock, (DxfEntity) this, plotColor))
        this.method_15((IPathDrawer) new Class355((DxfEntity) this, context, graphics, parentGraphicElementBlock), this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
      if (!orientationToLayout)
        return;
      context.vmethod_1();
    }

    public override DxfEntity.Interactor CreateCreateInteractor(Transaction transaction)
    {
      return (DxfEntity.Interactor) new DxfText.CreateInteractor(this, transaction);
    }

    public override IList<InteractorDescriptor> GetEditInteractorDescriptors()
    {
      return (IList<InteractorDescriptor>) new InteractorDescriptor[2]{ new InteractorDescriptor() { Description = "Default editor", HasTransaction = false, DisplayName = "Edit", ResourceManager = Class675.ResourceManager }, new InteractorDescriptor() { Description = "Text editor", HasTransaction = true, DisplayName = "Edit", ResourceManager = Class675.ResourceManager } };
    }

    public override DxfEntity.Interactor CreateEditInteractor(
      int index,
      CommandInvoker commandInvoker)
    {
      switch (index)
      {
        case 0:
          return (DxfEntity.Interactor) new DxfEntity.DefaultEditInteractor((DxfEntity) this);
        case 1:
          return (DxfEntity.Interactor) new DxfText.EditInteractor(this, commandInvoker);
        default:
          return (DxfEntity.Interactor) null;
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfText dxfText = (DxfText) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfText == null)
      {
        dxfText = new DxfText();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfText);
        dxfText.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfText;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfText dxfText = (DxfText) from;
      this.string_0 = dxfText.string_0;
      this.Style = Class906.GetTextStyle(cloneContext, dxfText.Style);
      this.point3D_0 = dxfText.point3D_0;
      this.nullable_0 = dxfText.nullable_0;
      this.double_1 = dxfText.double_1;
      this.double_2 = dxfText.double_2;
      this.double_3 = dxfText.double_3;
      this.double_4 = dxfText.double_4;
      this.vector3D_0 = dxfText.vector3D_0;
      this.double_5 = dxfText.double_5;
      this.textGenerationFlags_0 = dxfText.textGenerationFlags_0;
      this.textHorizontalAlignment_0 = dxfText.textHorizontalAlignment_0;
      this.textVerticalAlignment_0 = dxfText.textVerticalAlignment_0;
      cloneContext.CloneBuilders.Add((ICloneBuilder) new DxfHandledObject.LateComposer((DxfHandledObject) this));
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override string ToString()
    {
      return this.string_0;
    }

    internal virtual string DisplayString
    {
      get
      {
        return this.string_0;
      }
    }

    internal Class976 AlignedBoundingBox
    {
      get
      {
        IList<Class908> class908List = Class666.smethod_5(this, Colors.Pink, (short) 0, Matrix4D.Identity, this.bounds2D_0);
        Matrix4D transform = this.Transform;
        Bounds2D bounds2D = new Bounds2D(this.TextBounds);
        WW.Math.Point3D point3D1 = transform * new WW.Math.Point3D(bounds2D.Corner1, 0.0);
        WW.Math.Point3D point3D2 = transform * new WW.Math.Point3D(bounds2D.Corner2.X, bounds2D.Corner1.Y, 0.0);
        WW.Math.Point3D point3D3 = transform * new WW.Math.Point3D(bounds2D.Corner1.X, bounds2D.Corner2.Y, 0.0);
        return new Class976(class908List.Count <= 0 ? transform * WW.Math.Point3D.Zero : transform * class908List[0].Position, point3D2 - point3D1, point3D3 - point3D1);
      }
    }

    internal bool method_14()
    {
      if (this.Style.method_8())
        return this.Style.GetShxFile() != null;
      return false;
    }

    public void FixAlignmentPoints()
    {
      if (!this.nullable_0.HasValue || this.textHorizontalAlignment_0 == TextHorizontalAlignment.Left && this.textVerticalAlignment_0 == TextVerticalAlignment.Baseline)
        return;
      Vector2D alignmentTranslation;
      Vector2D alignmentScaling;
      Class666.smethod_6(this, Colors.Pink, (short) 0, Matrix4D.Identity, this.bounds2D_0, out alignmentTranslation, out alignmentScaling);
      this.point3D_0 = this.nullable_0.Value + this.InUcsTransform * new Vector3D(alignmentTranslation.X, alignmentTranslation.Y, 0.0);
      switch (this.textHorizontalAlignment_0)
      {
        case TextHorizontalAlignment.Aligned:
          this.Height *= alignmentScaling.Y;
          this.double_2 *= alignmentScaling.X / alignmentScaling.Y;
          break;
        case TextHorizontalAlignment.Fit:
          this.double_2 *= alignmentScaling.X;
          break;
      }
    }

    internal override void vmethod_10(DxfModel model)
    {
      base.vmethod_10(model);
      DxfAnnotationScaleObjectContextData.smethod_8((DxfEntity) this);
      this.bool_2 = Class1064.smethod_0((DxfHandledObject) this, model);
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      this.FixAlignmentPoints();
    }

    internal override short vmethod_6(Class432 w)
    {
      return 1;
    }

    private void method_15(IPathDrawer pathDrawer, WW.Cad.Model.Color color, short lineWeight)
    {
      foreach (Class908 class908 in (IEnumerable<Class908>) Class666.smethod_5(this, color, lineWeight, this.Transform, (Bounds2D) null))
        class908.Draw(pathDrawer, Matrix4D.Identity, this.Thickness);
    }

    private void method_16(List<Vector2D> characterAdvances)
    {
      characterAdvances.Clear();
      characterAdvances.Add(Vector2D.Zero);
      if (string.IsNullOrEmpty(this.string_0))
        return;
      Bounds2D collectBounds = new Bounds2D();
      Class908 class908 = Class666.smethod_5(this, Colors.Pink, (short) 0, Matrix4D.Identity, collectBounds)[0];
      class908.Font.Metrics.imethod_0(class908.Text.Text, (IList<Vector2D>) characterAdvances);
    }

    private bool TryCreateCaretBitmap(
      List<Vector2D> characterAdvances,
      int caretIndex,
      InteractionContext context,
      out Bitmap caretBitmap,
      out WW.Math.Point2D dcsPosition)
    {
      WW.Math.Point2D characterAdvance = (WW.Math.Point2D) characterAdvances[caretIndex];
      Matrix4D matrix4D = context.ProjectionTransform * this.Transform;
      Segment2D segment = new Segment2D(matrix4D.Transform(characterAdvance), matrix4D.Transform(characterAdvance + this.double_1 * new Vector2D(System.Math.Sin(this.Style.ObliqueAngle), 1.0)));
      Segment2D? nullable = new BlinnClipper2D(context.CanvasRectangle).Clip(segment);
      caretBitmap = (Bitmap) null;
      dcsPosition = WW.Math.Point2D.Zero;
      if (nullable.HasValue)
      {
        Segment2D segment2D = nullable.Value;
        Vector2D delta = segment2D.GetDelta();
        int width = (int) System.Math.Ceiling(System.Math.Abs(delta.X)) + 1;
        int height = (int) System.Math.Ceiling(System.Math.Abs(delta.Y)) + 1;
        caretBitmap = new Bitmap(width, height);
        Vector2D vector2D = new Vector2D(System.Math.Min(segment2D.Start.X, segment2D.End.X), System.Math.Min(segment2D.Start.Y, segment2D.End.Y));
        using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage((Image) caretBitmap))
        {
          graphics.Clear(System.Drawing.Color.Black);
          WW.Math.Point2D point2D1 = segment.Start - vector2D;
          WW.Math.Point2D point2D2 = segment.End - vector2D;
          graphics.DrawLine(Pens.White, (float) point2D1.X, (float) point2D1.Y, (float) point2D2.X, (float) point2D2.Y);
        }
        dcsPosition = (WW.Math.Point2D) vector2D;
      }
      return true;
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

    private bool IsAnnotativeForRendering
    {
      get
      {
        if (this.bool_2)
          return true;
        if (this.OwnerObjectSoftReference is DxfInsert)
          return ((DxfInsert) this.OwnerObjectSoftReference).IsAnnotative;
        return false;
      }
    }

    private bool MatchOrientationToLayout
    {
      get
      {
        if (this.OwnerObjectSoftReference is DxfInsert)
          return ((DxfInsertBase) this.OwnerObjectSoftReference).Block.MatchOrientationToLayout;
        return false;
      }
    }

    public DxfAnnotationScaleObjectContextData CreateContextData(
      DxfScale scale)
    {
      return (DxfAnnotationScaleObjectContextData) new DxfTextObjectContextData(this, scale);
    }

    void IControlPointCollection.Set(int index, WW.Math.Point3D value)
    {
      DxfText.icontrolPoint_0[index].SetValue((object) this, value);
    }

    WW.Math.Point3D IControlPointCollection.Get(int index)
    {
      return DxfText.icontrolPoint_0[index].GetValue((object) this);
    }

    string IControlPointCollection.GetDescription(int index)
    {
      return DxfText.icontrolPoint_0[index].Description;
    }

    PointDisplayType IControlPointCollection.GetDisplayType(
      int index)
    {
      return DxfText.icontrolPoint_0[index].DisplayType;
    }

    int IControlPointCollection.Count
    {
      get
      {
        return DxfText.icontrolPoint_0.Length;
      }
    }

    bool IControlPointCollection.IsCountFixed
    {
      get
      {
        return true;
      }
    }

    void IControlPointCollection.Insert(int index)
    {
      throw new NotSupportedException();
    }

    void IControlPointCollection.RemoveAt(int index)
    {
      throw new NotSupportedException();
    }

    private class Class524 : IControlPoint
    {
      public static readonly IControlPoint icontrolPoint_0 = (IControlPoint) new DxfText.Class524();

      private Class524()
      {
      }

      public void SetValue(object owner, WW.Math.Point3D value)
      {
        ((DxfText) owner).point3D_0 = value;
      }

      public WW.Math.Point3D GetValue(object owner)
      {
        return ((DxfText) owner).point3D_0;
      }

      public string Description
      {
        get
        {
          return Class881.DxfText_AlignmentPoint1_Name;
        }
      }

      public PointDisplayType DisplayType
      {
        get
        {
          return PointDisplayType.Default;
        }
      }
    }

    public abstract class InteractorBase : DxfEntity.Interactor
    {
      protected readonly List<Vector2D> characterAdvances = new List<Vector2D>();
      internal const double double_0 = 1.1;
      internal const double double_1 = -0.3;
      protected Transaction transaction;
      protected int caretIndex;
      protected readonly DxfText text;
      protected int selectionStartIndex;
      protected int selectionEndIndex;
      private int int_0;
      private bool bool_1;

      public InteractorBase(DxfText entity, Transaction transaction)
        : base((DxfEntity) entity)
      {
        this.transaction = transaction;
        this.text = entity;
        this.caretIndex = entity.string_0.Length;
        this.method_1();
        transaction.Completed += new EventHandler(this.method_3);
        this.method_4();
      }

      public InteractorBase(DxfText entity, CommandInvoker commandInvoker)
        : this(entity, new Transaction(commandInvoker))
      {
      }

      public int SelectionStartIndex
      {
        get
        {
          return this.selectionStartIndex;
        }
        set
        {
          this.selectionStartIndex = value;
        }
      }

      public int SelectionEndIndex
      {
        get
        {
          return this.selectionEndIndex;
        }
        set
        {
          this.selectionEndIndex = value;
        }
      }

      public override Transaction Transaction
      {
        get
        {
          return this.transaction;
        }
      }

      public override bool ProcessMouseButtonDown(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        this.bool_1 = true;
        Matrix4D matrix4D = context.ProjectionTransform * this.text.Transform;
        Vector2D vector2D1 = 1.1 * this.text.double_1 * new Vector2D(System.Math.Sin(this.text.Style.ObliqueAngle), 1.0);
        Vector2D vector2D2 = -0.3 * this.text.double_1 * new Vector2D(System.Math.Sin(this.text.Style.ObliqueAngle), 1.0);
        bool flag = false;
        for (int index = 0; index < this.characterAdvances.Count - 1; ++index)
        {
          WW.Math.Point2D characterAdvance1 = (WW.Math.Point2D) this.characterAdvances[index];
          WW.Math.Point2D point1 = characterAdvance1 + vector2D1;
          WW.Math.Point2D characterAdvance2 = (WW.Math.Point2D) this.characterAdvances[index + 1];
          WW.Math.Point2D point2 = characterAdvance2 + vector2D1;
          WW.Math.Point2D point3 = characterAdvance1 + vector2D2;
          WW.Math.Point2D point4 = characterAdvance2 + vector2D2;
          if (new Polygon2D(new WW.Math.Point2D[4]{ matrix4D.Transform(point3), matrix4D.Transform(point4), matrix4D.Transform(point2), matrix4D.Transform(point1) }).IsInside(e.Position))
          {
            flag = true;
            this.caretIndex = index;
            this.int_0 = index;
            this.selectionStartIndex = index;
            this.selectionEndIndex = index;
            break;
          }
        }
        if (!flag && this.characterAdvances.Count > 1)
        {
          WW.Math.Point2D characterAdvance1 = (WW.Math.Point2D) this.characterAdvances[0];
          WW.Math.Point2D characterAdvance2 = (WW.Math.Point2D) this.characterAdvances[this.characterAdvances.Count - 1];
          Vector2D v = matrix4D.Transform(characterAdvance2 - characterAdvance1);
          if (Vector2D.DotProduct(e.Position - matrix4D.Transform(characterAdvance2), v) >= 0.0)
          {
            int length = this.text.string_0.Length;
            this.caretIndex = length;
            this.int_0 = length;
            this.selectionStartIndex = length;
            this.selectionEndIndex = length;
          }
        }
        return true;
      }

      public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
      {
        if (!this.bool_1)
          return base.ProcessMouseMove(e, context);
        Matrix4D matrix4D = context.ProjectionTransform * this.text.Transform;
        Vector2D vector2D1 = 1.1 * this.text.double_1 * new Vector2D(System.Math.Sin(this.text.Style.ObliqueAngle), 1.0);
        Vector2D vector2D2 = -0.3 * this.text.double_1 * new Vector2D(System.Math.Sin(this.text.Style.ObliqueAngle), 1.0);
        bool flag = false;
        for (int index = 0; index < this.characterAdvances.Count - 1; ++index)
        {
          WW.Math.Point2D characterAdvance1 = (WW.Math.Point2D) this.characterAdvances[index];
          WW.Math.Point2D point1 = characterAdvance1 + vector2D1;
          WW.Math.Point2D characterAdvance2 = (WW.Math.Point2D) this.characterAdvances[index + 1];
          WW.Math.Point2D point2 = characterAdvance2 + vector2D1;
          WW.Math.Point2D point3 = characterAdvance1 + vector2D2;
          WW.Math.Point2D point4 = characterAdvance2 + vector2D2;
          if (new Polygon2D(new WW.Math.Point2D[4]{ matrix4D.Transform(point3), matrix4D.Transform(point4), matrix4D.Transform(point2), matrix4D.Transform(point1) }).IsInside(e.Position))
          {
            flag = true;
            this.caretIndex = index;
            if (index >= this.int_0)
            {
              this.selectionEndIndex = index;
              this.selectionStartIndex = this.int_0;
              break;
            }
            this.selectionEndIndex = this.int_0;
            this.selectionStartIndex = index;
            break;
          }
        }
        if (!flag && this.characterAdvances.Count > 1)
        {
          WW.Math.Point2D characterAdvance1 = (WW.Math.Point2D) this.characterAdvances[0];
          WW.Math.Point2D characterAdvance2 = (WW.Math.Point2D) this.characterAdvances[this.characterAdvances.Count - 1];
          Vector2D v = matrix4D.Transform(characterAdvance2 - characterAdvance1);
          if (Vector2D.DotProduct(e.Position - matrix4D.Transform(characterAdvance2), v) >= 0.0)
          {
            int length = this.text.string_0.Length;
            this.caretIndex = length;
            if (length >= this.int_0)
            {
              this.selectionEndIndex = length;
              this.selectionStartIndex = this.int_0;
            }
            else
            {
              this.selectionEndIndex = this.int_0;
              this.selectionStartIndex = length;
            }
          }
        }
        return true;
      }

      public override bool ProcessMouseButtonUp(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        if (!this.bool_1)
          return base.ProcessMouseButtonUp(e, context);
        this.bool_1 = false;
        return true;
      }

      private Polygon2D method_0(InteractionContext context)
      {
        Matrix4D matrix4D = context.ProjectionTransform * this.text.Transform;
        Vector2D vector2D1 = 1.1 * this.text.double_1 * new Vector2D(System.Math.Sin(this.text.Style.ObliqueAngle), 1.0);
        Vector2D vector2D2 = -0.3 * this.text.double_1 * new Vector2D(System.Math.Sin(this.text.Style.ObliqueAngle), 1.0);
        WW.Math.Point2D characterAdvance1 = (WW.Math.Point2D) this.characterAdvances[0];
        WW.Math.Point2D point1 = characterAdvance1 + vector2D1;
        WW.Math.Point2D characterAdvance2 = (WW.Math.Point2D) this.characterAdvances[this.characterAdvances.Count - 1];
        WW.Math.Point2D point2 = characterAdvance2 + vector2D1;
        WW.Math.Point2D point3 = characterAdvance1 + vector2D2;
        WW.Math.Point2D point4 = characterAdvance2 + vector2D2;
        return new Polygon2D(new WW.Math.Point2D[4]{ matrix4D.Transform(point3), matrix4D.Transform(point4), matrix4D.Transform(point2), matrix4D.Transform(point1) });
      }

      public override bool ProcessKeyDown(
        CanonicalMouseEventArgs e,
        System.Windows.Input.Key key,
        ModifierKeys modifierKeys,
        InteractionContext context)
      {
        int caretIndex = this.caretIndex;
        switch (key)
        {
          case System.Windows.Input.Key.Back:
            if (this.caretIndex > 0 && this.text.string_0.Length > 0 || this.selectionStartIndex < this.selectionEndIndex)
            {
              // ISSUE: object of a compiler-generated type is created
              // ISSUE: variable of a compiler-generated type
              DxfText.InteractorBase.Class525 class525 = new DxfText.InteractorBase.Class525();
              // ISSUE: reference to a compiler-generated field
              class525.interactorBase_0 = this;
              // ISSUE: reference to a compiler-generated field
              class525.int_0 = this.caretIndex - 1;
              // ISSUE: reference to a compiler-generated field
              class525.int_1 = this.caretIndex;
              int length = 1;
              if (this.selectionStartIndex < this.selectionEndIndex)
              {
                // ISSUE: reference to a compiler-generated field
                class525.int_0 = this.selectionStartIndex;
                // ISSUE: reference to a compiler-generated field
                class525.int_1 = this.selectionEndIndex;
                length = this.selectionEndIndex - this.selectionStartIndex;
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              class525.string_0 = this.text.string_0.Substring(class525.int_0, length);
              // ISSUE: reference to a compiler-generated field
              class525.int_2 = this.caretIndex;
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              this.transaction.Add((WW.Actions.ICommand) new WW.Actions.Command((object) this.Entity, new System.Action(class525.method_0), new System.Action(class525.method_1)));
              this.method_1();
              break;
            }
            break;
          case System.Windows.Input.Key.Return:
            this.Commit();
            break;
          case System.Windows.Input.Key.Escape:
            this.Rollback();
            break;
          case System.Windows.Input.Key.End:
            this.caretIndex = this.text.string_0.Length;
            this.method_2(modifierKeys, caretIndex);
            break;
          case System.Windows.Input.Key.Home:
            this.caretIndex = 0;
            this.method_2(modifierKeys, caretIndex);
            break;
          case System.Windows.Input.Key.Left:
            if (this.caretIndex > 0)
            {
              --this.caretIndex;
              if ((modifierKeys & ModifierKeys.Control) != ModifierKeys.None)
              {
                while (this.caretIndex > 0 && " ,()[].{};:".Contains(this.text.string_0[this.caretIndex - 1].ToString()))
                  --this.caretIndex;
                while (this.caretIndex > 0 && !" ,()[].{};:".Contains(this.text.string_0[this.caretIndex - 1].ToString()))
                  --this.caretIndex;
              }
              this.method_2(modifierKeys, caretIndex);
              break;
            }
            if ((modifierKeys & ModifierKeys.Shift) == ModifierKeys.None)
            {
              this.method_1();
              break;
            }
            break;
          case System.Windows.Input.Key.Right:
            if (this.caretIndex < this.text.string_0.Length)
            {
              ++this.caretIndex;
              if ((modifierKeys & ModifierKeys.Control) != ModifierKeys.None)
              {
                while (this.caretIndex < this.text.string_0.Length && !" ,()[].{};:".Contains(this.text.string_0[this.caretIndex - 1].ToString()))
                  ++this.caretIndex;
                while (this.caretIndex < this.text.string_0.Length && " ,()[].{};:".Contains(this.text.string_0[this.caretIndex].ToString()))
                  ++this.caretIndex;
              }
              this.method_2(modifierKeys, caretIndex);
              break;
            }
            if ((modifierKeys & ModifierKeys.Shift) == ModifierKeys.None)
            {
              this.method_1();
              break;
            }
            break;
          case System.Windows.Input.Key.Delete:
            if (this.caretIndex < this.text.string_0.Length || this.selectionStartIndex < this.selectionEndIndex)
            {
              // ISSUE: object of a compiler-generated type is created
              // ISSUE: variable of a compiler-generated type
              DxfText.InteractorBase.Class526 class526 = new DxfText.InteractorBase.Class526();
              // ISSUE: reference to a compiler-generated field
              class526.interactorBase_0 = this;
              // ISSUE: reference to a compiler-generated field
              class526.int_0 = this.caretIndex;
              // ISSUE: reference to a compiler-generated field
              class526.int_1 = this.caretIndex + 1;
              int length = 1;
              if (this.selectionStartIndex < this.selectionEndIndex)
              {
                // ISSUE: reference to a compiler-generated field
                class526.int_0 = this.selectionStartIndex;
                // ISSUE: reference to a compiler-generated field
                class526.int_1 = this.selectionEndIndex;
                length = this.selectionEndIndex - this.selectionStartIndex;
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              class526.string_0 = this.text.string_0.Substring(class526.int_0, length);
              // ISSUE: reference to a compiler-generated field
              class526.int_2 = this.caretIndex;
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              this.transaction.Add((WW.Actions.ICommand) new WW.Actions.Command((object) this.Entity, new System.Action(class526.method_0), new System.Action(class526.method_1)));
              this.method_1();
              break;
            }
            break;
          default:
            return base.ProcessKeyDown(e, key, modifierKeys, context);
        }
        return true;
      }

      private void method_1()
      {
        this.selectionStartIndex = this.caretIndex;
        this.selectionEndIndex = this.caretIndex;
      }

      private void method_2(ModifierKeys modifierKeys, int oldCaretIndex)
      {
        if ((modifierKeys & ModifierKeys.Shift) != ModifierKeys.None)
        {
          if (this.selectionStartIndex == this.selectionEndIndex)
          {
            if (this.caretIndex > oldCaretIndex)
            {
              this.selectionStartIndex = oldCaretIndex;
              this.selectionEndIndex = this.caretIndex;
            }
            else
            {
              this.selectionStartIndex = this.caretIndex;
              this.selectionEndIndex = oldCaretIndex;
            }
          }
          else if (oldCaretIndex == this.selectionEndIndex)
            this.selectionEndIndex = this.caretIndex;
          else
            this.selectionStartIndex = this.caretIndex;
        }
        else
          this.method_1();
      }

      protected virtual void Commit()
      {
        this.transaction.Commit();
      }

      public override bool ProcessTextInput(string text, InteractionContext context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfText.InteractorBase.Class527 class527 = new DxfText.InteractorBase.Class527();
        // ISSUE: reference to a compiler-generated field
        class527.string_0 = text;
        // ISSUE: reference to a compiler-generated field
        class527.interactorBase_0 = this;
        // ISSUE: reference to a compiler-generated field
        if (string.IsNullOrEmpty(class527.string_0))
        {
          // ISSUE: reference to a compiler-generated field
          return base.ProcessTextInput(class527.string_0, context);
        }
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfText.InteractorBase.Class528 class528 = new DxfText.InteractorBase.Class528();
        // ISSUE: reference to a compiler-generated field
        class528.class527_0 = class527;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        class528.int_0 = class527.string_0.Length;
        // ISSUE: reference to a compiler-generated field
        class528.int_1 = this.caretIndex;
        // ISSUE: reference to a compiler-generated field
        class528.bool_0 = this.selectionStartIndex < this.selectionEndIndex;
        // ISSUE: reference to a compiler-generated field
        class528.int_2 = this.selectionStartIndex;
        // ISSUE: reference to a compiler-generated field
        class528.int_3 = this.selectionEndIndex;
        // ISSUE: reference to a compiler-generated field
        class528.string_0 = string.Empty;
        // ISSUE: reference to a compiler-generated field
        if (class528.bool_0)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          class528.string_0 = this.text.string_0.Substring(class528.int_2, class528.int_3 - class528.int_2);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          class528.int_1 = class528.int_2;
        }
        // ISSUE: reference to a compiler-generated field
        class528.int_4 = this.caretIndex;
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        this.transaction.Add((WW.Actions.ICommand) new WW.Actions.Command((object) this.Entity, new System.Action(class528.method_0), new System.Action(class528.method_1)));
        return true;
      }

      public override void Cancel()
      {
      }

      protected internal virtual void Rollback()
      {
        this.transaction.Rollback();
      }

      private void method_3(object sender, EventArgs e)
      {
        if (this.IsActive)
          this.Deactivate();
        this.transaction.Completed -= new EventHandler(this.method_3);
      }

      private void method_4()
      {
        this.text.method_16(this.characterAdvances);
      }

      public override IInteractorWinFormsDrawable CreateWinFormsDrawable(
        InteractionContext context,
        Control hostControl)
      {
        return (IInteractorWinFormsDrawable) new DxfText.InteractorBase.Form8(this, hostControl);
      }

      internal class Form8 : DxfEntity.Interactor.WinFormsDrawable
      {
        private Control control_0;
        private bool bool_0;

        public Form8(DxfText.InteractorBase interactor, Control hostControl)
          : base((DxfEntity.Interactor) interactor)
        {
          this.control_0 = hostControl;
        }

        public override bool TryCreateCaretBitmap(
          GraphicsHelper graphicsHelper,
          InteractionContext context,
          out Bitmap caretBitmap,
          out WW.Math.Point2D dcsPosition)
        {
          DxfText.InteractorBase interactor = (DxfText.InteractorBase) this.Interactor;
          return interactor.text.TryCreateCaretBitmap(interactor.characterAdvances, interactor.caretIndex, context, out caretBitmap, out dcsPosition);
        }

        protected internal Control HostControl
        {
          get
          {
            return this.control_0;
          }
        }

        public override void DrawBackground(
          PaintEventArgs e,
          GraphicsHelper graphicsHelper,
          InteractionContext context)
        {
          this.Draw(e, graphicsHelper, context);
          DxfText.InteractorBase interactor = (DxfText.InteractorBase) this.Interactor;
          if (interactor.SelectionStartIndex == interactor.SelectionEndIndex)
            return;
          Matrix4D matrix4D = context.ProjectionTransform * interactor.text.Transform;
          DxfText text = interactor.text;
          Vector2D vector2D1 = 1.1 * text.double_1 * new Vector2D(System.Math.Sin(text.Style.ObliqueAngle), 1.0);
          Vector2D vector2D2 = -0.3 * text.double_1 * new Vector2D(System.Math.Sin(text.Style.ObliqueAngle), 1.0);
          WW.Math.Point2D characterAdvance1 = (WW.Math.Point2D) interactor.characterAdvances[interactor.selectionStartIndex];
          WW.Math.Point2D point1 = characterAdvance1 + vector2D1;
          WW.Math.Point2D characterAdvance2 = (WW.Math.Point2D) interactor.characterAdvances[interactor.selectionEndIndex];
          WW.Math.Point2D point2 = characterAdvance2 + vector2D1;
          WW.Math.Point2D point3 = characterAdvance1 + vector2D2;
          WW.Math.Point2D point4 = characterAdvance2 + vector2D2;
          e.Graphics.FillPolygon(graphicsHelper.SelectionBrush, new PointF[4]
          {
            matrix4D.TransformToPointF(point3),
            matrix4D.TransformToPointF(point4),
            matrix4D.TransformToPointF(point2),
            matrix4D.TransformToPointF(point1)
          });
        }
      }
    }

    public class CreateInteractor : DxfText.InteractorBase
    {
      private DxfText.CreateInteractor.Enum16 enum16_0;
      private double? nullable_1;
      private bool bool_2;

      internal event EventHandler StepChanged;

      public CreateInteractor(DxfText entity, Transaction transaction)
        : base(entity, transaction)
      {
        this.nullable_1 = new double?(this.text.double_1);
      }

      internal DxfText.CreateInteractor.Enum16 Step
      {
        get
        {
          return this.enum16_0;
        }
        set
        {
          this.enum16_0 = value;
          this.method_5(EventArgs.Empty);
        }
      }

      internal double? EnteredHeight
      {
        get
        {
          return this.nullable_1;
        }
        set
        {
          this.nullable_1 = value;
        }
      }

      public override string UserHint
      {
        get
        {
          string str = string.Empty;
          switch (this.enum16_0)
          {
            case DxfText.CreateInteractor.Enum16.const_0:
              str = Class881.DxfText_CreateInteractor_UserHint_Step_SetPosition;
              break;
            case DxfText.CreateInteractor.Enum16.const_1:
              str = Class881.DxfText_CreateInteractor_UserHint_Step_SetHeight;
              break;
            case DxfText.CreateInteractor.Enum16.const_2:
              str = Class881.DxfText_CreateInteractor_UserHint_Step_SetText;
              break;
          }
          return str;
        }
      }

      public override bool ProcessMouseButtonDown(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        if (this.enum16_0 != DxfText.CreateInteractor.Enum16.const_0)
          return base.ProcessMouseButtonDown(e, context);
        return true;
      }

      public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
      {
        if (this.enum16_0 != DxfText.CreateInteractor.Enum16.const_0)
          return base.ProcessMouseMove(e, context);
        return true;
      }

      public override bool ProcessMouseButtonUp(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfText.CreateInteractor.Class529 class529 = new DxfText.CreateInteractor.Class529();
        // ISSUE: reference to a compiler-generated field
        class529.canonicalMouseEventArgs_0 = e;
        // ISSUE: reference to a compiler-generated field
        class529.interactionContext_0 = context;
        // ISSUE: reference to a compiler-generated field
        class529.createInteractor_0 = this;
        if (this.enum16_0 != DxfText.CreateInteractor.Enum16.const_0)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          return base.ProcessMouseButtonUp(class529.canonicalMouseEventArgs_0, class529.interactionContext_0);
        }
        // ISSUE: reference to a compiler-generated method
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        this.Transaction.Add((WW.Actions.ICommand) new WW.Actions.Command((object) this.Entity, new System.Action(class529.method_0), new System.Action(new DxfText.CreateInteractor.Class530()
        {
          class529_0 = class529,
          point3D_0 = this.text.point3D_0
        }.method_0)));
        return true;
      }

      public override bool ProcessKeyDown(
        CanonicalMouseEventArgs e,
        System.Windows.Input.Key key,
        ModifierKeys modifierKeys,
        InteractionContext context)
      {
        if (this.enum16_0 != DxfText.CreateInteractor.Enum16.const_2)
          return false;
        return base.ProcessKeyDown(e, key, modifierKeys, context);
      }

      protected internal override void Rollback()
      {
        this.bool_2 = true;
        base.Rollback();
      }

      public override bool ProcessTextInput(string text, InteractionContext context)
      {
        if (this.enum16_0 == DxfText.CreateInteractor.Enum16.const_2 && !string.IsNullOrEmpty(text))
          return base.ProcessTextInput(text, context);
        return false;
      }

      private void method_5(EventArgs e)
      {
        if (this.bool_2 || this.eventHandler_1 == null)
          return;
        this.eventHandler_1((object) this, e);
      }

      public override void Cancel()
      {
      }

      internal void method_6()
      {
        if (!this.nullable_1.HasValue)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        this.Transaction.Add((WW.Actions.ICommand) new WW.Actions.Command((object) this.Entity, (System.Action) (() =>
        {
          this.text.double_1 = this.nullable_1.Value;
          this.UpdateEntityPostAction();
          this.method_7();
        }), new System.Action(new DxfText.CreateInteractor.Class531()
        {
          createInteractor_0 = this,
          double_0 = this.text.double_1
        }.method_0)));
        if (this.enum16_0 != DxfText.CreateInteractor.Enum16.const_1)
          return;
        ++this.Step;
      }

      private void method_7()
      {
        this.text.method_16(this.characterAdvances);
      }

      public override IInteractorWinFormsDrawable CreateWinFormsDrawable(
        InteractionContext context,
        Control hostControl)
      {
        return (IInteractorWinFormsDrawable) new DxfText.CreateInteractor.Form9(this, hostControl);
      }

      internal enum Enum16
      {
        const_0,
        const_1,
        const_2,
      }

      internal class Form9 : DxfText.InteractorBase.Form8
      {
        private FieldEditControl fieldEditControl_0;
        private bool bool_1;

        public Form9(DxfText.CreateInteractor interactor, Control hostControl)
          : base((DxfText.InteractorBase) interactor, hostControl)
        {
          this.fieldEditControl_0 = FieldEditControl.Create(Class675.Height);
          this.fieldEditControl_0.TextBox.KeyPress += new KeyPressEventHandler(this.method_1);
          interactor.StepChanged += new EventHandler(this.method_0);
        }

        private void method_0(object sender, EventArgs e)
        {
          if (((DxfText.CreateInteractor) sender).Step == DxfText.CreateInteractor.Enum16.const_1)
          {
            this.fieldEditControl_0.TextBox.Text = ((DxfText.CreateInteractor) sender).nullable_1.ToString();
            this.fieldEditControl_0.TextBox.SelectAll();
            this.fieldEditControl_0.TextBox.TextChanged += new EventHandler(this.method_2);
            this.fieldEditControl_0.Show();
            this.fieldEditControl_0.TextBox.Focus();
          }
          else
          {
            this.fieldEditControl_0.TextBox.TextChanged -= new EventHandler(this.method_2);
            this.fieldEditControl_0.Hide();
          }
        }

        private void method_1(object sender, KeyPressEventArgs e)
        {
          if (((DxfText.CreateInteractor) this.Interactor).EnteredHeight.HasValue && (e.KeyChar == '\r' || e.KeyChar == '\t'))
          {
            ((DxfText.CreateInteractor) this.Interactor).method_6();
          }
          else
          {
            if (e.KeyChar != '\x001B')
              return;
            this.Interactor.Cancel();
          }
        }

        private void method_2(object sender, EventArgs e)
        {
          if (this.bool_1)
            return;
          this.bool_1 = true;
          try
          {
            if (string.IsNullOrEmpty(this.fieldEditControl_0.TextBox.Text))
            {
              ((DxfText.CreateInteractor) this.Interactor).EnteredHeight = new double?();
            }
            else
            {
              double result;
              if (!double.TryParse(this.fieldEditControl_0.TextBox.Text, out result))
                return;
              ((DxfText.CreateInteractor) this.Interactor).EnteredHeight = new double?(result);
              ((DxfText.InteractorBase) this.Interactor).text.double_1 = result;
            }
          }
          finally
          {
            this.bool_1 = false;
          }
        }

        public override bool TryCreateCaretBitmap(
          GraphicsHelper graphicsHelper,
          InteractionContext context,
          out Bitmap caretBitmap,
          out WW.Math.Point2D dcsPosition)
        {
          DxfText.CreateInteractor interactor = (DxfText.CreateInteractor) this.Interactor;
          if (interactor.enum16_0 == DxfText.CreateInteractor.Enum16.const_2)
            return interactor.text.TryCreateCaretBitmap(interactor.characterAdvances, interactor.caretIndex, context, out caretBitmap, out dcsPosition);
          caretBitmap = (Bitmap) null;
          dcsPosition = WW.Math.Point2D.Zero;
          return false;
        }

        public override void Draw(
          PaintEventArgs e,
          GraphicsHelper graphicsHelper,
          InteractionContext context)
        {
          base.Draw(e, graphicsHelper, context);
          if (!this.fieldEditControl_0.Visible)
            return;
          WW.Math.Point2D point2D = context.ProjectionTransform.TransformTo2D(((DxfText.InteractorBase) this.Interactor).text.point3D_0);
          this.fieldEditControl_0.Location = this.HostControl.PointToScreen(new System.Drawing.Point((int) System.Math.Round(point2D.X), (int) System.Math.Round(point2D.Y)));
        }

        public override System.Windows.Forms.Cursor GetCursor()
        {
          System.Windows.Forms.Cursor cross = System.Windows.Forms.Cursors.Default;
          if (((DxfText.CreateInteractor) this.Interactor).enum16_0 == DxfText.CreateInteractor.Enum16.const_0)
            cross = System.Windows.Forms.Cursors.Cross;
          return cross;
        }
      }
    }

    public class EditInteractor : DxfText.InteractorBase
    {
      private string string_0;

      public EditInteractor(DxfText entity, CommandInvoker commandInvoker)
        : base(entity, commandInvoker)
      {
        this.string_0 = entity.string_0;
      }

      protected override void Commit()
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfText.EditInteractor.Class532 class532 = new DxfText.EditInteractor.Class532();
        // ISSUE: reference to a compiler-generated field
        class532.editInteractor_0 = this;
        base.Commit();
        // ISSUE: reference to a compiler-generated field
        class532.string_0 = this.text.string_0;
        // ISSUE: reference to a compiler-generated method
        this.OnCommandCreated(new CommandEventArgs((WW.Actions.ICommand) new WW.Actions.Command((object) this.Entity, new System.Action(class532.method_0), (System.Action) (() => this.text.string_0 = this.string_0))));
      }
    }
  }
}
