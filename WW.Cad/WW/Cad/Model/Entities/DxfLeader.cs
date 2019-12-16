// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfLeader
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns2;
using ns28;
using ns33;
using ns49;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Tables;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfLeader : DxfEntity, IAnnotative, ILeader
  {
    private bool bool_2 = true;
    private LeaderCreationType leaderCreationType_0 = LeaderCreationType.CreatedWithoutAnnotation;
    private HookLineDirection hookLineDirection_0 = HookLineDirection.Same;
    private List<WW.Math.Point3D> list_0 = new List<WW.Math.Point3D>();
    private Color color_0 = Colors.ByBlock;
    private DxfObjectReference dxfObjectReference_6 = DxfObjectReference.Null;
    private Vector3D vector3D_0 = Vector3D.ZAxis;
    private Vector3D vector3D_1 = Vector3D.XAxis;
    private const double double_1 = 0.333333333333333;
    private DxfDimensionStyleOverrides dxfDimensionStyleOverrides_0;
    private LeaderPathType leaderPathType_0;
    private bool bool_3;
    private double double_2;
    private double double_3;
    private Vector3D vector3D_2;
    private Vector3D vector3D_3;
    private bool bool_4;
    private WW.Math.Point3D point3D_0;

    public DxfLeader(DxfModel model)
    {
      this.dxfDimensionStyleOverrides_0 = new DxfDimensionStyleOverrides(model.CurrentDimensionStyle, model);
    }

    public DxfLeader(DxfDimensionStyle dimensionStyle)
    {
      this.dxfDimensionStyleOverrides_0 = new DxfDimensionStyleOverrides(dimensionStyle, dimensionStyle.Model);
    }

    public bool ArrowHeadEnabled
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

    public DxfEntity AssociatedAnnotation
    {
      get
      {
        return (DxfEntity) this.dxfObjectReference_6.Value;
      }
      set
      {
        this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public Color ByBlockColor
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

    public LeaderCreationType CreationType
    {
      get
      {
        return this.leaderCreationType_0;
      }
      set
      {
        this.leaderCreationType_0 = value;
      }
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

    public bool HasHookLine
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

    public HookLineDirection HookLineDirection
    {
      get
      {
        if (!this.bool_4)
          return this.hookLineDirection_0;
        DxfLeaderObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfLeaderObjectContextData;
        if (objectContextData != null)
          return objectContextData.HookLineDirection;
        return this.hookLineDirection_0;
      }
      set
      {
        if (!this.IsAnnotative)
        {
          this.hookLineDirection_0 = value;
        }
        else
        {
          DxfLeaderObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfLeaderObjectContextData;
          if (objectContextData != null)
            objectContextData.HookLineDirection = value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.hookLineDirection_0 = value;
        }
      }
    }

    public Vector3D HorizontalDirection
    {
      get
      {
        if (!this.bool_4)
          return this.vector3D_1;
        DxfLeaderObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfLeaderObjectContextData;
        if (objectContextData != null)
          return objectContextData.HorizontalDirection;
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
          DxfLeaderObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfLeaderObjectContextData;
          if (objectContextData != null)
            objectContextData.HorizontalDirection = value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.vector3D_1 = value;
        }
      }
    }

    public Vector3D LastVertexOffsetFromAnnotation
    {
      get
      {
        if (!this.bool_4)
          return this.vector3D_3;
        DxfLeaderObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfLeaderObjectContextData;
        if (objectContextData != null)
          return objectContextData.LastVertexOffsetFromAnnotation;
        return this.vector3D_3;
      }
      set
      {
        if (!this.IsAnnotative)
        {
          this.vector3D_3 = value;
        }
        else
        {
          DxfLeaderObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfLeaderObjectContextData;
          if (objectContextData != null)
            objectContextData.LastVertexOffsetFromAnnotation = value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.vector3D_3 = value;
        }
      }
    }

    public Vector3D LastVertexOffsetFromBlock
    {
      get
      {
        if (!this.bool_4)
          return this.vector3D_2;
        DxfLeaderObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfLeaderObjectContextData;
        if (objectContextData != null)
          return objectContextData.LastVertexOffsetFromBlock;
        return this.vector3D_2;
      }
      set
      {
        if (!this.IsAnnotative)
        {
          this.vector3D_2 = value;
        }
        else
        {
          DxfLeaderObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfLeaderObjectContextData;
          if (objectContextData != null)
            objectContextData.LastVertexOffsetFromBlock = value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.vector3D_2 = value;
        }
      }
    }

    public LeaderPathType PathType
    {
      get
      {
        return this.leaderPathType_0;
      }
      set
      {
        this.leaderPathType_0 = value;
      }
    }

    public double TextAnnotationHeight
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

    public double TextAnnotationWidth
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

    public List<WW.Math.Point3D> Vertices
    {
      get
      {
        if (!this.bool_4)
          return this.list_0;
        DxfLeaderObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, true) as DxfLeaderObjectContextData;
        if (objectContextData != null)
          return objectContextData.Vertices;
        return this.list_0;
      }
      set
      {
        if (!this.IsAnnotative)
        {
          this.list_0 = value;
        }
        else
        {
          DxfLeaderObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false) as DxfLeaderObjectContextData;
          if (objectContextData != null)
            objectContextData.Vertices = value;
          if (objectContextData != null && !objectContextData.IsDefault)
            return;
          this.list_0 = value;
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

    public WW.Math.Point3D Origin
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
      DxfLeader.Class897 class897 = new DxfLeader.Class897();
      // ISSUE: reference to a compiler-generated field
      class897.dxfLeader_0 = this;
      // ISSUE: reference to a compiler-generated field
      class897.double_0 = this.double_2;
      // ISSUE: reference to a compiler-generated field
      class897.double_1 = this.double_3;
      // ISSUE: reference to a compiler-generated field
      class897.point3D_0 = new WW.Math.Point3D[this.list_0.Count];
      // ISSUE: reference to a compiler-generated field
      class897.vector3D_0 = this.vector3D_0;
      // ISSUE: reference to a compiler-generated field
      class897.vector3D_1 = this.vector3D_1;
      // ISSUE: reference to a compiler-generated field
      class897.vector3D_2 = this.vector3D_2;
      // ISSUE: reference to a compiler-generated field
      class897.vector3D_3 = this.vector3D_3;
      this.vector3D_0 = matrix.Transform(this.vector3D_0);
      this.vector3D_0.Normalize();
      Matrix4D inverse = DxfUtil.GetToWCSTransform(this.vector3D_0).GetInverse();
      // ISSUE: reference to a compiler-generated field
      Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(class897.vector3D_0);
      Matrix4D matrix4D = inverse * matrix * toWcsTransform;
      this.double_3 = matrix.Transform(new Vector2D(this.double_3, 0.0)).GetLength();
      this.double_2 = matrix.Transform(new Vector2D(0.0, this.double_2)).GetLength();
      for (int index = this.list_0.Count - 1; index >= 0; --index)
      {
        WW.Math.Point3D point = this.list_0[index];
        // ISSUE: reference to a compiler-generated field
        class897.point3D_0[index] = point;
        this.list_0[index] = matrix.Transform(point);
      }
      this.vector3D_1 = matrix.Transform(this.vector3D_1).GetUnit();
      this.vector3D_2 = matrix.Transform(this.vector3D_2);
      this.vector3D_3 = matrix.Transform(this.vector3D_3);
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfLeader.Class898 class898 = new DxfLeader.Class898();
      // ISSUE: reference to a compiler-generated field
      class898.class897_0 = class897;
      // ISSUE: reference to a compiler-generated field
      class898.double_0 = this.double_2;
      // ISSUE: reference to a compiler-generated field
      class898.double_1 = this.double_3;
      // ISSUE: reference to a compiler-generated field
      class898.point3D_0 = new WW.Math.Point3D[this.list_0.Count];
      for (int index = this.list_0.Count - 1; index >= 0; --index)
      {
        // ISSUE: reference to a compiler-generated field
        class898.point3D_0[index] = this.list_0[index];
      }
      // ISSUE: reference to a compiler-generated field
      class898.vector3D_0 = this.vector3D_0;
      // ISSUE: reference to a compiler-generated field
      class898.vector3D_1 = this.vector3D_1;
      // ISSUE: reference to a compiler-generated field
      class898.vector3D_2 = this.vector3D_2;
      // ISSUE: reference to a compiler-generated field
      class898.vector3D_3 = this.vector3D_3;
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(class898.method_0), new System.Action(class897.method_0)));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      IList<Polyline3D> polylines1;
      IList<FlatShape4D> shapes;
      this.method_14((DrawContext) context, context.GetTransformer().LineTypeScaler, out polylines1, out shapes);
      IList<Polyline4D> polylines2 = DxfUtil.smethod_36(polylines1, false, context.GetTransformer());
      if (polylines2.Count > 0)
        graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this, this.dxfDimensionStyleOverrides_0.DimensionLineColor), false, polylines2, false, true);
      if (shapes != null)
        Class940.smethod_23((IPathDrawer) new ns0.Class0((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, this.dxfDimensionStyleOverrides_0.DimensionLineColor, context.GetLineWeight((DxfEntity) this));
      if (!DxfLeader.smethod_7((ILeader) this, (IList<WW.Math.Point3D>) this.list_0))
        return;
      if (this.dxfDimensionStyleOverrides_0.LeaderArrowBlock == null)
      {
        Polyline3D polyline = this.method_15();
        if (polyline == null)
          return;
        IClippingTransformer clippingTransformer = (IClippingTransformer) context.GetTransformer().Clone();
        clippingTransformer.SetPreTransform(this.method_16());
        List<Polyline4D> polyline4DList = new List<Polyline4D>((IEnumerable<Polyline4D>) clippingTransformer.Transform(polyline, polyline.Closed));
        if (polyline4DList.Count <= 0)
          return;
        graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this, this.dxfDimensionStyleOverrides_0.DimensionLineColor), false, (IList<Polyline4D>) polyline4DList, true, true);
      }
      else
      {
        DxfInsert.Interface46 nterface46 = (DxfInsert.Interface46) new DxfInsert.Class1019((DxfEntity) this, context, graphicsFactory);
        nterface46.imethod_0(0, 0, this.method_16());
        nterface46.Draw(this.dxfDimensionStyleOverrides_0.LeaderArrowBlock, true);
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      IList<Polyline3D> polylines1;
      IList<FlatShape4D> shapes;
      this.method_14((DrawContext) context, context.GetTransformer().LineTypeScaler, out polylines1, out shapes);
      IList<Polyline4D> polylines2 = DxfUtil.smethod_36(polylines1, false, context.GetTransformer());
      if (polylines2.Count > 0)
        Class940.smethod_3((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this, this.dxfDimensionStyleOverrides_0.DimensionLineColor), false, false, true, polylines2);
      if (shapes != null)
        Class940.smethod_23((IPathDrawer) new Class396((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, this.dxfDimensionStyleOverrides_0.DimensionLineColor, context.GetLineWeight((DxfEntity) this));
      if (!DxfLeader.smethod_7((ILeader) this, (IList<WW.Math.Point3D>) this.list_0))
        return;
      if (this.dxfDimensionStyleOverrides_0.LeaderArrowBlock == null)
      {
        Polyline3D polyline1 = this.method_15();
        if (polyline1 == null)
          return;
        IClippingTransformer clippingTransformer = (IClippingTransformer) context.GetTransformer().Clone();
        clippingTransformer.SetPreTransform(this.method_16());
        foreach (Polyline4D polyline2 in new List<Polyline4D>((IEnumerable<Polyline4D>) clippingTransformer.Transform(polyline1, polyline1.Closed)))
          Class940.smethod_1((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this, this.dxfDimensionStyleOverrides_0.DimensionLineColor), false, true, false, polyline2);
      }
      else
      {
        DxfInsert.Interface46 nterface46 = (DxfInsert.Interface46) new DxfInsert.Class1020((DxfEntity) this, context, graphicsFactory);
        nterface46.imethod_0(0, 0, this.method_16());
        nterface46.Draw(this.dxfDimensionStyleOverrides_0.LeaderArrowBlock, true);
      }
    }

    public override string EntityType
    {
      get
      {
        return "LEADER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbLeader";
      }
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public double GetEffectiveArrowSize()
    {
      return ((ILeader) this).GetEffectiveArrowSize();
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfLeader dxfLeader = (DxfLeader) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfLeader == null)
      {
        dxfLeader = new DxfLeader(cloneContext.TargetModel);
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfLeader);
        dxfLeader.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfLeader;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfLeader dxfLeader = (DxfLeader) from;
      if (dxfLeader.dxfDimensionStyleOverrides_0 != null)
        this.dxfDimensionStyleOverrides_0 = dxfLeader.dxfDimensionStyleOverrides_0.Clone(cloneContext);
      this.bool_2 = dxfLeader.bool_2;
      this.leaderPathType_0 = dxfLeader.leaderPathType_0;
      this.leaderCreationType_0 = dxfLeader.leaderCreationType_0;
      this.hookLineDirection_0 = dxfLeader.hookLineDirection_0;
      this.bool_3 = dxfLeader.bool_3;
      this.double_2 = dxfLeader.double_2;
      this.double_3 = dxfLeader.double_3;
      this.list_0.AddRange((IEnumerable<WW.Math.Point3D>) dxfLeader.list_0);
      this.color_0 = dxfLeader.color_0;
      if (dxfLeader.AssociatedAnnotation == null)
        this.AssociatedAnnotation = (DxfEntity) null;
      else if (cloneContext.SourceModel == cloneContext.TargetModel)
      {
        this.AssociatedAnnotation = dxfLeader.AssociatedAnnotation;
      }
      else
      {
        this.AssociatedAnnotation = (DxfEntity) dxfLeader.AssociatedAnnotation.Clone(cloneContext);
        cloneContext.method_0((DxfHandledObject) this.AssociatedAnnotation);
      }
      this.vector3D_0 = dxfLeader.vector3D_0;
      this.vector3D_1 = dxfLeader.vector3D_1;
      this.vector3D_2 = dxfLeader.vector3D_2;
      this.vector3D_3 = dxfLeader.vector3D_3;
    }

    bool ILeader.IsSpline
    {
      get
      {
        return this.leaderPathType_0 == LeaderPathType.Spline;
      }
    }

    Vector3D ILeader.Direction
    {
      get
      {
        return this.vector3D_1;
      }
    }

    DxfBlock ILeader.LeaderArrowBlock
    {
      get
      {
        return this.dxfDimensionStyleOverrides_0.LeaderArrowBlock;
      }
    }

    void ILeader.imethod_0(
      DrawContext context,
      IList<WW.Math.Point3D> points,
      IList<WW.Math.Point3D> polyline)
    {
      DxfEntity entity = this.dxfObjectReference_6.Value as DxfEntity;
      if (entity == null)
        return;
      WW.Math.Point3D point = points[points.Count - 1];
      Vector3D zaxis = this.HorizontalDirection;
      zaxis.Normalize();
      if (this.hookLineDirection_0 == HookLineDirection.Same)
        zaxis = -zaxis;
      BoundsCalculator boundsCalculator = new BoundsCalculator(context.Config);
      Matrix4D transpose = DxfUtil.GetToWCSTransform(zaxis).GetTranspose();
      Matrix4D matrix4D = Transformation4D.Translation(-(Vector3D) point);
      boundsCalculator.GetBounds(context.Model, entity, transpose * matrix4D);
      Bounds3D bounds = boundsCalculator.Bounds;
      if (!bounds.Initialized)
        return;
      double z1 = bounds.Min.Z;
      double z2 = bounds.Max.Z;
      double num1 = 0.5 * (z1 + z2);
      bool flag = this.dxfDimensionStyleOverrides_0.TextVerticalAlignment != DimensionTextVerticalAlignment.Above && this.dxfDimensionStyleOverrides_0.TextVerticalPosition >= -0.7 && this.dxfDimensionStyleOverrides_0.TextVerticalPosition <= 0.7;
      double num2 = this.dxfDimensionStyleOverrides_0.ScaleFactor;
      if (num2 == 0.0)
        num2 = 1.0;
      double num3 = this.dxfDimensionStyleOverrides_0.DimensionLineGap * num2;
      double num4 = !flag ? (num1 < 0.0 ? z1 : z2) : System.Math.Max(z1 - num3, 0.0);
      polyline.Add(point + zaxis * num4);
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
      this.bool_4 = Class1064.smethod_0((DxfHandledObject) this, model);
    }

    internal void method_13()
    {
      this.bool_3 = false;
      if (this.leaderCreationType_0 != LeaderCreationType.CreatedWithTextAnnotation && this.leaderCreationType_0 != LeaderCreationType.CreatedWithToleranceAnnotation || (this.leaderPathType_0 != LeaderPathType.StraightLineSegments || this.list_0.Count <= 1))
        return;
      double angle = Vector3D.GetAngle(this.list_0[this.list_0.Count - 2] - this.list_0[this.list_0.Count - 1], this.vector3D_1);
      this.bool_3 = angle > System.Math.PI / 12.0 && angle < 11.0 * System.Math.PI / 12.0;
    }

    internal override short vmethod_6(Class432 w)
    {
      return 45;
    }

    internal static IList<WW.Math.Point3D> smethod_2(
      IList<WW.Math.Point3D> vertices,
      ILeader leader,
      out Vector3D startDerivative,
      out Vector3D endDerivative)
    {
      if (vertices != null && vertices.Count >= 2)
      {
        List<WW.Math.Point3D> point3DList = new List<WW.Math.Point3D>((IEnumerable<WW.Math.Point3D>) vertices);
        double effectiveArrowSize = leader.GetEffectiveArrowSize();
        Vector3D vector3D = point3DList[1] - point3DList[0];
        double length = vector3D.GetLength();
        startDerivative = vector3D / length;
        endDerivative = leader.Direction;
        if (leader.HookLineDirection == HookLineDirection.Same)
          endDerivative = -endDerivative;
        endDerivative.Normalize();
        if (DxfLeader.smethod_7(leader, vertices) && leader.LeaderArrowBlock == null && length >= effectiveArrowSize)
          point3DList[0] += vector3D * (effectiveArrowSize / length);
        return (IList<WW.Math.Point3D>) point3DList;
      }
      startDerivative = endDerivative = Vector3D.Zero;
      return (IList<WW.Math.Point3D>) null;
    }

    internal static Polyline3D smethod_3(
      DrawContext context,
      ILeader leader,
      IList<WW.Math.Point3D> vertices)
    {
      Vector3D startDerivative;
      Vector3D endDerivative;
      IList<WW.Math.Point3D> points = DxfLeader.smethod_2(vertices, leader, out startDerivative, out endDerivative);
      if (points == null)
        return (Polyline3D) null;
      int num = leader.HasHookLine ? 1 : 0;
      Polyline3D polyline3D = (Polyline3D) null;
      if (leader.IsSpline && points.Count >= 2)
      {
        DxfSpline dxfSpline = new DxfSpline();
        dxfSpline.Degree = 3;
        dxfSpline.StartTangent = startDerivative;
        dxfSpline.EndTangent = endDerivative;
        dxfSpline.FitPoints.AddRange((IEnumerable<WW.Math.Point3D>) points);
        if (dxfSpline.UpdateSplineFromFitPoints())
          polyline3D = dxfSpline.method_15((int) context.Config.NoOfSplineLineSegments);
      }
      if (polyline3D == null)
      {
        polyline3D = new Polyline3D(points.Count + num);
        polyline3D.AddRange((IEnumerable<WW.Math.Point3D>) points);
      }
      if (leader.HasHookLine)
        leader.imethod_0(context, points, (IList<WW.Math.Point3D>) polyline3D);
      return polyline3D;
    }

    private void method_14(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<Polyline3D> polylines,
      out IList<FlatShape4D> shapes)
    {
      DxfLeader.smethod_4(context, lineTypeScaler, (ILeader) this, (IList<WW.Math.Point3D>) this.list_0, this.GetLineType(context), this.ZAxis, this.LineTypeScale, out polylines, out shapes);
    }

    internal static void smethod_4(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      ILeader leader,
      IList<WW.Math.Point3D> vertices,
      DxfLineType lineType,
      Vector3D zAxis,
      double lineTypeScale,
      out IList<Polyline3D> polylines,
      out IList<FlatShape4D> shapes)
    {
      Polyline3D polyline = DxfLeader.smethod_3(context, leader, vertices);
      if (context.Config.ApplyLineType)
      {
        polylines = (IList<Polyline3D>) new List<Polyline3D>();
        if (polyline != null)
        {
          shapes = (IList<FlatShape4D>) new List<FlatShape4D>();
          DxfUtil.smethod_4(context.Config, polylines, shapes, polyline, lineType, zAxis, context.TotalLineTypeScale * lineTypeScale, lineTypeScaler);
          if (shapes.Count != 0)
            return;
          shapes = (IList<FlatShape4D>) null;
        }
        else
          shapes = (IList<FlatShape4D>) null;
      }
      else
      {
        ref IList<Polyline3D> local = ref polylines;
        List<Polyline3D> polyline3DList;
        if (polyline == null)
          polyline3DList = new List<Polyline3D>();
        else
          polyline3DList = new List<Polyline3D>()
          {
            polyline
          };
        local = (IList<Polyline3D>) polyline3DList;
        shapes = (IList<FlatShape4D>) null;
      }
    }

    private Polyline3D method_15()
    {
      return DxfLeader.smethod_5((ILeader) this);
    }

    internal static Polyline3D smethod_5(ILeader leader)
    {
      if (!leader.ArrowHeadEnabled || leader.ArrowSize <= 0.0)
        return (Polyline3D) null;
      Polyline3D polyline3D = new Polyline3D(3);
      double y = 1.0 / 6.0;
      polyline3D.Add(WW.Math.Point3D.Zero);
      polyline3D.Add(new WW.Math.Point3D(-1.0, y, 0.0));
      polyline3D.Add(new WW.Math.Point3D(-1.0, -1.0 / 6.0, 0.0));
      polyline3D.Closed = true;
      return polyline3D;
    }

    private Matrix4D method_16()
    {
      return DxfLeader.smethod_6((ILeader) this, (IList<WW.Math.Point3D>) this.list_0, this.vector3D_0);
    }

    internal static Matrix4D smethod_6(
      ILeader leader,
      IList<WW.Math.Point3D> vertices,
      Vector3D zaxis)
    {
      WW.Math.Point3D vertex1 = vertices[0];
      WW.Math.Point3D vertex2 = vertices[1];
      Matrix4D toWcsTransform = DxfUtil.GetToWCSTransform(zaxis);
      Vector3D v1 = new Vector3D(toWcsTransform.M00, toWcsTransform.M10, toWcsTransform.M20);
      Vector3D v2 = new Vector3D(toWcsTransform.M01, toWcsTransform.M11, toWcsTransform.M21);
      Vector3D u = vertex1 - vertex2;
      double angle = System.Math.Atan2(Vector3D.DotProduct(u, v2), Vector3D.DotProduct(u, v1));
      double effectiveArrowSize = leader.GetEffectiveArrowSize();
      return Transformation4D.Translation((Vector3D) vertex1) * toWcsTransform * Transformation4D.RotateZ(angle) * Transformation4D.Scaling(effectiveArrowSize, effectiveArrowSize, effectiveArrowSize);
    }

    double ILeader.ArrowSize
    {
      get
      {
        return this.dxfDimensionStyleOverrides_0.ArrowSize;
      }
    }

    double ILeader.GetEffectiveArrowSize()
    {
      if (!this.bool_4)
        return this.dxfDimensionStyleOverrides_0.ScaleFactor * this.dxfDimensionStyleOverrides_0.ArrowSize;
      DxfAnnotationScaleObjectContextData objectContextData = DxfAnnotationScaleObjectContextData.smethod_4((DxfHandledObject) this, this.Model.Header.CurrentAnnotationScale, false);
      if (objectContextData != null)
        return this.dxfDimensionStyleOverrides_0.ArrowSize / objectContextData.Scale.ScaleFactor;
      return this.dxfDimensionStyleOverrides_0.ArrowSize;
    }

    internal static bool smethod_7(ILeader leader, IList<WW.Math.Point3D> vertices)
    {
      if (!leader.ArrowHeadEnabled || leader.ArrowSize <= 0.0)
        return false;
      bool flag = false;
      if (vertices.Count >= 2)
      {
        WW.Math.Point3D vertex = vertices[0];
        double lengthSquared = (vertices[1] - vertex).GetLengthSquared();
        double effectiveArrowSize = leader.GetEffectiveArrowSize();
        flag = effectiveArrowSize * effectiveArrowSize <= 0.25 * lengthSquared + 8.88178419700125E-16;
      }
      return flag;
    }

    public bool IsAnnotative
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

    public DxfAnnotationScaleObjectContextData CreateContextData(
      DxfScale scale)
    {
      return (DxfAnnotationScaleObjectContextData) new DxfLeaderObjectContextData(this, scale);
    }
  }
}
