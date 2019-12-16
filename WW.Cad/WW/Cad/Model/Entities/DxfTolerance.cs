// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTolerance
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns2;
using ns28;
using ns4;
using ns49;
using System.Collections.Generic;
using System.Text;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfTolerance : DxfEntity, IAnnotative
  {
    private string string_0 = string.Empty;
    private Vector3D vector3D_0 = Vector3D.ZAxis;
    private Vector3D vector3D_1 = Vector3D.XAxis;
    internal const double double_1 = 2.0;
    private DxfDimensionStyleOverrides dxfDimensionStyleOverrides_0;
    private WW.Math.Point3D point3D_0;
    private bool bool_2;

    public DxfTolerance(DxfModel model)
    {
      this.dxfDimensionStyleOverrides_0 = new DxfDimensionStyleOverrides(model.CurrentDimensionStyle, model);
    }

    public DxfTolerance(DxfDimensionStyle dimensionStyle)
    {
      this.dxfDimensionStyleOverrides_0 = new DxfDimensionStyleOverrides(dimensionStyle, dimensionStyle.Model);
    }

    public DxfDimensionStyleOverrides DimensionStyleOverrides
    {
      get
      {
        return this.dxfDimensionStyleOverrides_0;
      }
    }

    public DxfDimensionStyle DimensionStyle
    {
      get
      {
        return this.dxfDimensionStyleOverrides_0.BaseDimensionStyle;
      }
      set
      {
        this.dxfDimensionStyleOverrides_0.BaseDimensionStyle = value;
      }
    }

    public WW.Math.Point3D InsertionPoint
    {
      get
      {
        if (!this.IsAnnotative)
          return this.point3D_0;
        DxfToleranceObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfToleranceObjectContextData;
        if (objectContextData != null)
          return objectContextData.InsertionPoint;
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
          DxfToleranceObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfToleranceObjectContextData;
          if (objectContextData != null)
            objectContextData.InsertionPoint = value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.point3D_0 = value;
        }
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
        this.string_0 = value;
      }
    }

    public Vector3D XAxis
    {
      get
      {
        if (!this.IsAnnotative)
          return this.vector3D_1;
        DxfToleranceObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfToleranceObjectContextData;
        if (objectContextData != null)
          return objectContextData.XAxis;
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
          DxfToleranceObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfToleranceObjectContextData;
          if (objectContextData != null)
            objectContextData.XAxis = value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.vector3D_1 = value;
        }
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
      DxfTolerance.Class398 class398 = new DxfTolerance.Class398();
      // ISSUE: reference to a compiler-generated field
      class398.dxfTolerance_0 = this;
      // ISSUE: reference to a compiler-generated field
      class398.point3D_0 = this.point3D_0;
      // ISSUE: reference to a compiler-generated field
      class398.vector3D_0 = this.vector3D_0;
      // ISSUE: reference to a compiler-generated field
      class398.vector3D_1 = this.vector3D_1;
      // ISSUE: reference to a compiler-generated field
      class398.double_0 = this.dxfDimensionStyleOverrides_0.ScaleFactor;
      this.vector3D_0 = matrix.Transform(this.vector3D_0);
      this.vector3D_0.Normalize();
      this.vector3D_1 = matrix.Transform(this.vector3D_1);
      this.vector3D_1.Normalize();
      this.point3D_0 = matrix.Transform(this.point3D_0);
      this.dxfDimensionStyleOverrides_0.ScaleFactor *= matrix.Transform(new Vector2D(1.0, 0.0)).GetLength();
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfTolerance.Class399()
      {
        class398_0 = class398,
        point3D_0 = this.point3D_0,
        vector3D_0 = this.vector3D_0,
        vector3D_1 = this.vector3D_1,
        double_0 = this.dxfDimensionStyleOverrides_0.ScaleFactor
      }.method_0), new System.Action(class398.method_0)));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      this.DrawInternal((IPathDrawer) new ns0.Class0((DxfEntity) this, context, graphicsFactory), this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      this.DrawInternal((IPathDrawer) new Class396((DxfEntity) this, context, graphicsFactory), this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      this.DrawInternal((IPathDrawer) new Class473((DxfEntity) this, context, graphicsFactory), this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      if (!graphics.AddExistingGraphicElement1(parentGraphicElementBlock, (DxfEntity) this, plotColor))
        return;
      this.DrawInternal((IPathDrawer) new Class355((DxfEntity) this, context, graphics, parentGraphicElementBlock), this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    public override string EntityType
    {
      get
      {
        return "TOLERANCE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbFcf";
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfTolerance dxfTolerance = (DxfTolerance) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfTolerance == null)
      {
        dxfTolerance = new DxfTolerance(cloneContext.TargetModel);
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfTolerance);
        dxfTolerance.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfTolerance;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfTolerance dxfTolerance = (DxfTolerance) from;
      this.dxfDimensionStyleOverrides_0 = dxfTolerance.dxfDimensionStyleOverrides_0 != null ? dxfTolerance.dxfDimensionStyleOverrides_0.Clone(cloneContext) : (DxfDimensionStyleOverrides) null;
      this.point3D_0 = dxfTolerance.point3D_0;
      this.string_0 = dxfTolerance.string_0;
      this.vector3D_0 = dxfTolerance.vector3D_0;
      this.vector3D_1 = dxfTolerance.vector3D_1;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      if (this.dxfDimensionStyleOverrides_0 == null)
        return;
      this.dxfDimensionStyleOverrides_0.method_0((DxfEntity) this);
    }

    internal override void vmethod_10(DxfModel model)
    {
      base.vmethod_10(model);
      DxfAnnotationScaleObjectContextData.smethod_8((DxfEntity) this);
      this.bool_2 = Class1064.smethod_0((DxfHandledObject) this, model);
    }

    internal override short vmethod_6(Class432 w)
    {
      return 46;
    }

    private new Matrix4D Transform
    {
      get
      {
        return Transformation4D.Translation((Vector3D) this.InsertionPoint) * DxfUtil.GetToWCSTransform(this.XAxis, this.vector3D_0);
      }
    }

    private void DrawInternal(IPathDrawer pathDrawer, Color color, short lineWeight)
    {
      DxfTolerance.Class397[] class397Array = this.method_13();
      Matrix4D transform = this.Transform;
      Vector3D zero = Vector3D.Zero;
      double num1 = this.dxfDimensionStyleOverrides_0.TextHeight * 2.0;
      double scale = this.dxfDimensionStyleOverrides_0.ScaleFactor;
      if (System.Math.Abs(scale) < 1E-10)
        scale = 1.0;
      if (this.IsAnnotative)
        scale /= DxfAnnotationScaleObjectContextData.smethod_9((DxfEntity) this, this.Model.Header.CurrentAnnotationScale);
      double num2 = num1 * scale;
      foreach (DxfTolerance.Class397 class397 in class397Array)
      {
        double num3 = class397.Draw(this, pathDrawer, transform * Transformation4D.Translation(zero), color, lineWeight, scale);
        if (class397.NewLineAfterField)
        {
          zero.X = 0.0;
          zero.Y -= num2;
        }
        else
          zero.X += num3;
      }
    }

    private DxfTolerance.Class397[] method_13()
    {
      string string0 = this.string_0;
      List<DxfTolerance.Class397> class397List = new List<DxfTolerance.Class397>();
      if (!string.IsNullOrEmpty(string0))
      {
        int index = 0;
        StringBuilder stringBuilder = new StringBuilder();
        while (index < string0.Length)
        {
          char ch = string0[index];
          if (ch == '%' && index + 2 < string0.Length && (string0[index + 1] == '%' && string0[index + 2] == 'v'))
          {
            if (stringBuilder.Length > 0)
            {
              class397List.Add(new DxfTolerance.Class397(stringBuilder.ToString()));
              stringBuilder.Length = 0;
            }
            index += 3;
          }
          else if (ch == '^' && index + 1 < string0.Length && string0[index + 1] == 'J')
          {
            if (stringBuilder.Length > 0)
            {
              class397List.Add(new DxfTolerance.Class397(stringBuilder.ToString()));
              stringBuilder.Length = 0;
            }
            if (class397List.Count > 0)
              class397List[class397List.Count - 1].NewLineAfterField = true;
            index += 2;
          }
          else if (ch == '\n')
          {
            if (stringBuilder.Length > 0)
            {
              class397List.Add(new DxfTolerance.Class397(stringBuilder.ToString()));
              stringBuilder.Length = 0;
            }
            if (class397List.Count > 0)
              class397List[class397List.Count - 1].NewLineAfterField = true;
            ++index;
          }
          else
          {
            stringBuilder.Append(ch);
            ++index;
          }
        }
        if (stringBuilder.Length > 0)
          class397List.Add(new DxfTolerance.Class397(stringBuilder.ToString()));
      }
      return class397List.ToArray();
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
      return (DxfAnnotationScaleObjectContextData) new DxfToleranceObjectContextData(this, scale);
    }

    private class Class397
    {
      private readonly string string_0;
      private bool bool_0;

      internal Class397(string text)
      {
        this.string_0 = text;
      }

      internal string Text
      {
        get
        {
          return this.string_0;
        }
      }

      internal bool NewLineAfterField
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

      internal double Draw(
        DxfTolerance tolerance,
        IPathDrawer pathDrawer,
        Matrix4D preTransform,
        Color color,
        short lineWeight,
        double scale)
      {
        double effectiveTextHeight = DxfDimensionStyle.GetEffectiveTextHeight((IDimensionStyle) tolerance.DimensionStyleOverrides, scale);
        double num1 = tolerance.dxfDimensionStyleOverrides_0.TextHeight * scale;
        float num2 = (float) (num1 * 0.5);
        Class985 resultLayoutInfo = new Class985();
        IList<Class908> class908List = Class666.smethod_0(this.string_0, effectiveTextHeight, tolerance.DimensionStyleOverrides.TextStyle, tolerance.DimensionStyleOverrides.TextStyle.WidthFactor, color, lineWeight, preTransform * Transformation4D.Translation((double) num2, 0.0, 0.0), resultLayoutInfo, Enum24.flag_3);
        float x = (float) resultLayoutInfo.Bounds.Corner2.X;
        float num3 = (float) (num1 * 2.0 * 0.5);
        Rectangle2D rectangle2D = new Rectangle2D(0.0, -(double) num3, (double) x + (double) num2 * 2.0, 2.0 * (double) num3 - (double) num3);
        pathDrawer.DrawPath((IShape2D) rectangle2D, preTransform, color, lineWeight, false, false, 0.0);
        foreach (Class908 class908 in (IEnumerable<Class908>) class908List)
          class908.Draw(pathDrawer, Matrix4D.Identity, 0.0);
        return (double) x + (double) num2 * 2.0;
      }
    }
  }
}
