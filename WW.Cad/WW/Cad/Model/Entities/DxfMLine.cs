// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfMLine
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns28;
using ns33;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfMLine : DxfEntity
  {
    private DxfObjectReference dxfObjectReference_6 = DxfObjectReference.Null;
    private double double_1 = 1.0;
    private WW.Math.Vector3D vector3D_0 = WW.Math.Vector3D.ZAxis;
    private List<DxfMLine.Segment> list_0 = new List<DxfMLine.Segment>();
    private MLineAlignment mlineAlignment_0;
    private MLineFlags mlineFlags_0;
    private WW.Math.Point3D point3D_0;

    internal DxfMLine()
    {
    }

    public DxfMLine(DxfModel model)
    {
      this.Style = model.DefaultMLineStyle;
    }

    public MLineAlignment Alignment
    {
      get
      {
        return this.mlineAlignment_0;
      }
      set
      {
        this.mlineAlignment_0 = value;
      }
    }

    public MLineFlags Flags
    {
      get
      {
        return this.mlineFlags_0;
      }
      set
      {
        this.mlineFlags_0 = value;
      }
    }

    public bool Closed
    {
      get
      {
        return (this.mlineFlags_0 & MLineFlags.Closed) != MLineFlags.None;
      }
      set
      {
        if (value)
          this.mlineFlags_0 |= MLineFlags.Closed;
        else
          this.mlineFlags_0 &= ~MLineFlags.Closed;
      }
    }

    public bool SuppressStartCaps
    {
      get
      {
        return (this.mlineFlags_0 & MLineFlags.SuppressStartCaps) != MLineFlags.None;
      }
      set
      {
        if (value)
          this.mlineFlags_0 |= MLineFlags.SuppressStartCaps;
        else
          this.mlineFlags_0 &= ~MLineFlags.SuppressStartCaps;
      }
    }

    public bool SuppressEndCaps
    {
      get
      {
        return (this.mlineFlags_0 & MLineFlags.SuppressEndCaps) != MLineFlags.None;
      }
      set
      {
        if (value)
          this.mlineFlags_0 |= MLineFlags.SuppressEndCaps;
        else
          this.mlineFlags_0 &= ~MLineFlags.SuppressEndCaps;
      }
    }

    public double ScaleFactor
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

    public WW.Math.Point3D StartPoint
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

    public DxfMLineStyle Style
    {
      get
      {
        return (DxfMLineStyle) this.dxfObjectReference_6.Value;
      }
      set
      {
        this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) value);
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

    public List<DxfMLine.Segment> Segments
    {
      get
      {
        return this.list_0;
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfMLine dxfMline = (DxfMLine) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfMline == null)
      {
        dxfMline = new DxfMLine();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfMline);
        dxfMline.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfMline;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfMLine dxfMline = (DxfMLine) from;
      if (dxfMline.Style != null)
      {
        if (cloneContext.SourceModel == cloneContext.TargetModel)
          this.Style = dxfMline.Style;
        else if ((this.Style = cloneContext.TargetModel.MLineStyles.Find(dxfMline.Style.Name)) == null)
        {
          switch (cloneContext.ReferenceResolutionType)
          {
            case ReferenceResolutionType.IgnoreMissing:
              this.Style = cloneContext.TargetModel.DefaultMLineStyle;
              break;
            case ReferenceResolutionType.CloneMissing:
              DxfMLineStyle dxfMlineStyle = (DxfMLineStyle) dxfMline.Style.Clone(cloneContext);
              if (!cloneContext.CloneExact)
                cloneContext.TargetModel.MLineStyles.Add(dxfMlineStyle);
              this.Style = dxfMlineStyle;
              break;
            case ReferenceResolutionType.FailOnMissing:
              throw new DxfException(string.Format("Could not resolve reference to mline style with name {0}.", (object) dxfMline.Style.Name));
          }
        }
      }
      this.double_1 = dxfMline.double_1;
      this.mlineAlignment_0 = dxfMline.mlineAlignment_0;
      this.mlineFlags_0 = dxfMline.mlineFlags_0;
      this.point3D_0 = dxfMline.point3D_0;
      this.vector3D_0 = dxfMline.vector3D_0;
      foreach (DxfMLine.Segment segment in dxfMline.list_0)
        this.list_0.Add(segment.Clone(cloneContext));
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
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
      DxfMLine.Class1015 class1015 = new DxfMLine.Class1015();
      // ISSUE: reference to a compiler-generated field
      class1015.dxfMLine_0 = this;
      // ISSUE: reference to a compiler-generated field
      class1015.point3D_0 = this.point3D_0;
      // ISSUE: reference to a compiler-generated field
      class1015.vector3D_0 = this.vector3D_0;
      CommandGroup undoGroup1 = (CommandGroup) null;
      if (undoGroup != null)
      {
        undoGroup1 = new CommandGroup((object) this);
        undoGroup.UndoStack.Push((ICommand) undoGroup1);
      }
      this.vector3D_0 = matrix.Transform(this.vector3D_0);
      this.vector3D_0.Normalize();
      this.point3D_0 = matrix.Transform(this.point3D_0);
      if (undoGroup != null)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup1.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfMLine.Class1016()
        {
          class1015_0 = class1015,
          point3D_0 = this.point3D_0,
          vector3D_0 = this.vector3D_0
        }.method_0), new System.Action(class1015.method_0)));
      }
      foreach (DxfMLine.Segment segment in this.list_0)
        segment.TransformMe(matrix, undoGroup1);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      if (this.list_0.Count == 0)
        return;
      DxfLayer layer = this.GetLayer((DrawContext) context);
      int minElementCount = this.method_15();
      DxfMLineStyle style = this.Style;
      if (style == null)
        return;
      for (int elementIndex = 0; elementIndex < style.Elements.Count; ++elementIndex)
      {
        DxfMLineStyle.Element element = style.Elements[elementIndex];
        IList<Polyline4D> polylines4D;
        IList<IShape4D> shapes;
        this.GetPolylines4D((DrawContext) context, elementIndex, minElementCount, element, context.GetTransformer(), out polylines4D, out shapes);
        ArgbColor color = DxfEntity.GetColor(context.Config.IndexedColors, element.Color, context.ByBlockColor, context.ByBlockDxfColor, layer);
        if (polylines4D.Count > 0)
        {
          foreach (Polyline4D polyline4D in (IEnumerable<Polyline4D>) polylines4D)
          {
            if (polyline4D.Count <= 2)
              polyline4D.Closed = false;
          }
          graphicsFactory.CreatePath((DxfEntity) this, context, color, false, polylines4D, false, true);
        }
        if (shapes != null)
          Class940.smethod_23((IPathDrawer) new ns0.Class0((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, element.Color, context.GetLineWeight((DxfEntity) this));
      }
      IList<Polyline4D> polylines1 = this.method_14((DrawContext) context, context.GetTransformer());
      if (polylines1.Count > 0)
      {
        foreach (Polyline4D polyline4D in (IEnumerable<Polyline4D>) polylines1)
        {
          if (polyline4D.Count <= 2)
            polyline4D.Closed = false;
        }
        ArgbColor color = this.method_13((DrawContext) context, layer);
        graphicsFactory.CreatePath((DxfEntity) this, context, color, false, polylines1, false, true);
      }
      if (!style.IsFillOn)
        return;
      IList<Polyline4D> polylines2 = this.method_16(context.GetTransformer());
      if (polylines2 == null || polylines2.Count <= 0)
        return;
      graphicsFactory.CreatePath((DxfEntity) this, context, DxfEntity.GetColor(context.Config.IndexedColors, style.FillColor, context.ByBlockColor, context.ByBlockDxfColor, this.GetLayer((DrawContext) context)), false, polylines2, true, true);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      if (this.list_0.Count == 0)
        return;
      DxfLayer layer = this.GetLayer((DrawContext) context);
      int minElementCount = this.method_15();
      DxfMLineStyle style = this.Style;
      for (int elementIndex = 0; elementIndex < style.Elements.Count; ++elementIndex)
      {
        DxfMLineStyle.Element element = style.Elements[elementIndex];
        IList<Polyline4D> polylines4D;
        IList<IShape4D> shapes;
        this.GetPolylines4D((DrawContext) context, elementIndex, minElementCount, element, context.GetTransformer(), out polylines4D, out shapes);
        ArgbColor color = DxfEntity.GetColor(context.Config.IndexedColors, element.Color, context.ByBlockColor, context.ByBlockDxfColor, layer);
        if (polylines4D.Count > 0)
        {
          foreach (Polyline4D polyline4D in (IEnumerable<Polyline4D>) polylines4D)
          {
            if (polyline4D.Count <= 2)
              polyline4D.Closed = false;
          }
          Class940.smethod_3((DxfEntity) this, context, graphicsFactory, color, false, false, true, polylines4D);
        }
        if (shapes != null)
          Class940.smethod_23((IPathDrawer) new Class396((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, element.Color, context.GetLineWeight((DxfEntity) this));
      }
      IList<Polyline4D> polylines1 = this.method_14((DrawContext) context, context.GetTransformer());
      if (polylines1.Count > 0)
      {
        foreach (Polyline4D polyline4D in (IEnumerable<Polyline4D>) polylines1)
        {
          if (polyline4D.Count <= 2)
            polyline4D.Closed = false;
        }
        ArgbColor color = this.method_13((DrawContext) context, layer);
        Class940.smethod_3((DxfEntity) this, context, graphicsFactory, color, false, false, true, polylines1);
      }
      if (!style.IsFillOn)
        return;
      IList<Polyline4D> polylines2 = this.method_16(context.GetTransformer());
      if (polylines2 == null || polylines2.Count <= 0)
        return;
      Class940.smethod_2((DxfEntity) this, context, graphicsFactory, DxfEntity.GetColor(context.Config.IndexedColors, style.FillColor, context.ByBlockColor, context.ByBlockDxfColor, this.GetLayer((DrawContext) context)), false, true, false, polylines2);
    }

    public override string EntityType
    {
      get
      {
        return "MLINE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbMline";
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return 47;
    }

    private ArgbColor method_13(DrawContext context, DxfLayer layer)
    {
      int index = this.list_0[0].Elements.Count - 1;
      DxfMLineStyle style = this.Style;
      return index < 0 || index >= style.Elements.Count ? context.GetPlotColor((DxfEntity) this) : DxfEntity.GetColor(context.Config.IndexedColors, style.Elements[index].Color, context.ByBlockColor, context.ByBlockDxfColor, layer);
    }

    private IList<Polyline4D> method_14(
      DrawContext context,
      IClippingTransformer transformer)
    {
      bool closed = this.Closed;
      List<Polyline3D> polyline3DList = new List<Polyline3D>();
      if (this.Style.DisplayMiters)
      {
        int num1 = closed ? 0 : 1;
        int num2 = closed ? this.list_0.Count : this.list_0.Count - 1;
        for (int index = num1; index < num2; ++index)
        {
          DxfMLine.Segment segment = this.list_0[index];
          if (segment.Elements.Count >= 2)
          {
            DxfMLine.Segment.Element element1 = segment.Elements[0];
            DxfMLine.Segment.Element element2 = segment.Elements[segment.Elements.Count - 1];
            if (element1.Parameters.Count > 0 && element2.Parameters.Count > 0)
            {
              Polyline3D polyline3D = new Polyline3D(2, false);
              polyline3D.Add(segment.Position + element1.Parameters[0] * segment.MiterDirection);
              polyline3D.Add(segment.Position + element2.Parameters[0] * segment.MiterDirection);
              polyline3DList.Add(polyline3D);
            }
          }
        }
      }
      return DxfUtil.smethod_36((IList<Polyline3D>) polyline3DList, false, transformer);
    }

    private int method_15()
    {
      int num = int.MaxValue;
      foreach (DxfMLine.Segment segment in this.list_0)
      {
        if (segment.Elements.Count < num)
          num = segment.Elements.Count;
      }
      return num;
    }

    private void GetPolylines4D(
      DrawContext context,
      int elementIndex,
      int minElementCount,
      DxfMLineStyle.Element styleElement,
      IClippingTransformer transformer,
      out IList<Polyline4D> polylines4D,
      out IList<IShape4D> shapes)
    {
      WW.Math.Point3D point3D0 = this.point3D_0;
      bool closed = this.Closed;
      IList<Polyline3D> polyline3DList = (IList<Polyline3D>) new List<Polyline3D>();
      IList<FlatShape4D> resultShapes = (IList<FlatShape4D>) new List<FlatShape4D>();
      if (minElementCount == 0)
      {
        Polyline3D polyline3D = new Polyline3D(closed);
        foreach (DxfMLine.Segment segment in this.list_0)
          polyline3D.Add(segment.Position);
        if (polyline3D.Count > 0)
          DxfUtil.smethod_2(context.Config, polyline3DList, resultShapes, (IList<Polyline3D>) new Polyline3D[1]
          {
            polyline3D
          }, styleElement.LineType, this.vector3D_0, 1.0, transformer.LineTypeScaler);
      }
      else
      {
        IList<Polyline3D> polylines = (IList<Polyline3D>) new List<Polyline3D>();
        Polyline3D polyline3D = new Polyline3D();
        bool flag = false;
        foreach (DxfMLine.Segment segment in this.list_0)
        {
          WW.Math.Vector3D miterDirection = segment.MiterDirection;
          WW.Math.Point3D position = segment.Position;
          if (elementIndex < segment.Elements.Count)
          {
            DxfMLine.Segment.Element element = segment.Elements[elementIndex];
            WW.Math.Point3D point3D1 = position;
            if (element.Parameters.Count > 0)
            {
              WW.Math.Point3D point3D2 = point3D1 + miterDirection * element.Parameters[0];
              if (element.Parameters.Count > 1)
              {
                for (int index = 1; index < element.Parameters.Count; index += 2)
                {
                  WW.Math.Point3D point3D3 = point3D2 + segment.Direction * element.Parameters[index];
                  polyline3D.Add(point3D3);
                  if (index + 1 < element.Parameters.Count)
                  {
                    WW.Math.Point3D point3D4 = point3D2 + segment.Direction * element.Parameters[index + 1];
                    polyline3D.Add(point3D4);
                    polylines.Add(polyline3D);
                    polyline3D = new Polyline3D();
                  }
                }
              }
              else if (polyline3D.Count > 0)
              {
                polyline3D.Add(point3D2);
                polylines.Add(polyline3D);
                polyline3D = new Polyline3D();
              }
            }
            else if (element.AreaFillParameters.Count > 0)
              flag = true;
          }
        }
        DxfMLine.Segment segment1 = this.list_0[this.list_0.Count - 1];
        if (closed && polyline3D.Count > 0)
        {
          DxfMLine.Segment segment2 = this.list_0[0];
          if (elementIndex < segment2.Elements.Count)
          {
            DxfMLine.Segment.Element element = segment2.Elements[elementIndex];
            WW.Math.Point3D position = segment2.Position;
            if (element.Parameters.Count > 0)
            {
              WW.Math.Vector3D miterDirection = segment2.MiterDirection;
              WW.Math.Point3D point3D = position + miterDirection * element.Parameters[0];
              polyline3D.Add(point3D);
            }
          }
        }
        if (polyline3D.Count > 0)
          polylines.Add(polyline3D);
        if (flag)
          polyline3DList.Add(polyline3D);
        else if (polylines.Count > 0)
          DxfUtil.smethod_2(context.Config, polyline3DList, resultShapes, polylines, styleElement.LineType, this.vector3D_0, 1.0, transformer.LineTypeScaler);
      }
      polylines4D = DxfUtil.smethod_36(polyline3DList, false, transformer);
      shapes = DxfUtil.smethod_37((ICollection<FlatShape4D>) resultShapes, transformer);
    }

    private IList<Polyline4D> method_16(IClippingTransformer transformer)
    {
      WW.Math.Point3D point3D0 = this.point3D_0;
      bool closed = this.Closed;
      DxfMLine.Segment segment1 = this.list_0[0];
      int num1 = int.MaxValue;
      foreach (DxfMLine.Segment segment2 in this.list_0)
      {
        if (segment2.Elements.Count < num1)
          num1 = segment2.Elements.Count;
      }
      IList<Polyline4D> polyline4DList;
      if (num1 >= 2)
      {
        Polyline3D[] polyline3DArray = new Polyline3D[2];
        for (int index = 0; index < polyline3DArray.Length; ++index)
          polyline3DArray[index] = new Polyline3D(closed);
        foreach (DxfMLine.Segment segment2 in this.list_0)
        {
          WW.Math.Vector3D miterDirection = segment2.MiterDirection;
          WW.Math.Point3D position = segment2.Position;
          if (segment2.Elements.Count == 0)
          {
            polyline3DArray[0].Add(position);
          }
          else
          {
            DxfMLine.Segment.Element element1 = (DxfMLine.Segment.Element) null;
            DxfMLine.Segment.Element element2 = (DxfMLine.Segment.Element) null;
            double num2 = double.MaxValue;
            double num3 = double.MinValue;
            for (int index = 0; index < num1; ++index)
            {
              DxfMLine.Segment.Element element3 = segment2.Elements[index];
              if (element3.Parameters.Count != 0)
              {
                if (element1 == null)
                {
                  element1 = element3;
                  num2 = element1.Parameters[0];
                }
                else if (element3.Parameters[0] < num2)
                {
                  element1 = element3;
                  num2 = element1.Parameters[0];
                }
                if (element2 == null)
                {
                  element2 = element3;
                  num3 = element2.Parameters[0];
                }
                else if (element3.Parameters[0] > num3)
                {
                  element2 = element3;
                  num3 = element2.Parameters[0];
                }
              }
            }
            if (num2 == double.MaxValue)
              num2 = 0.0;
            if (num3 == double.MinValue)
              num3 = 0.0;
            if (element1 != null && element2 != null)
            {
              polyline3DArray[0].Add(position + miterDirection * num2);
              polyline3DArray[1].Add(position + miterDirection * num3);
            }
          }
        }
        List<Polyline3D> polyline3DList;
        if (closed)
        {
          polyline3DList = new List<Polyline3D>(2);
          polyline3DList.AddRange((IEnumerable<Polyline3D>) polyline3DArray);
        }
        else
        {
          polyline3DList = new List<Polyline3D>(1);
          Polyline3D polyline3D = new Polyline3D(polyline3DArray[0].Count + polyline3DArray[1].Count, true);
          polyline3D.AddRange((IEnumerable<WW.Math.Point3D>) polyline3DArray[0]);
          polyline3D.AddRange((IEnumerable<WW.Math.Point3D>) polyline3DArray[1].GetReverse());
          polyline3DList.Add(polyline3D);
        }
        IClippingTransformer transformer1 = (IClippingTransformer) transformer.Clone();
        transformer1.SetPreTransform(DxfUtil.GetToWCSTransform(this.vector3D_0));
        polyline4DList = DxfUtil.smethod_36((IList<Polyline3D>) polyline3DList, false, transformer1);
      }
      else
        polyline4DList = (IList<Polyline4D>) null;
      return polyline4DList;
    }

    private WW.Math.Vector3D method_17(DxfMLine.Segment segment)
    {
      WW.Math.Vector3D vector3D = WW.Math.Vector3D.CrossProduct(segment.Direction, WW.Math.Vector3D.CrossProduct(segment.Direction, segment.MiterDirection));
      vector3D.Normalize();
      return vector3D;
    }

    public class Segment
    {
      private List<DxfMLine.Segment.Element> list_0 = new List<DxfMLine.Segment.Element>();
      private WW.Math.Point3D point3D_0;
      private WW.Math.Vector3D vector3D_0;
      private WW.Math.Vector3D vector3D_1;

      public Segment()
      {
      }

      public Segment(WW.Math.Point3D position, WW.Math.Vector3D direction, WW.Math.Vector3D miterDirection)
      {
        this.point3D_0 = position;
        this.vector3D_0 = direction;
        this.vector3D_1 = miterDirection;
      }

      public Segment(
        WW.Math.Point3D position,
        WW.Math.Vector3D direction,
        WW.Math.Vector3D miterDirection,
        DxfMLine.Segment.Element[] elements)
      {
        this.point3D_0 = position;
        this.vector3D_0 = direction;
        this.vector3D_1 = miterDirection;
        this.list_0.AddRange((IEnumerable<DxfMLine.Segment.Element>) elements);
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

      public WW.Math.Vector3D MiterDirection
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

      public List<DxfMLine.Segment.Element> Elements
      {
        get
        {
          return this.list_0;
        }
      }

      public void TransformMe(Matrix4D matrix, CommandGroup undoGroup)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        DxfMLine.Segment.Class1013 class1013 = new DxfMLine.Segment.Class1013();
        // ISSUE: reference to a compiler-generated field
        class1013.segment_0 = this;
        // ISSUE: reference to a compiler-generated field
        class1013.point3D_0 = this.point3D_0;
        // ISSUE: reference to a compiler-generated field
        class1013.vector3D_0 = this.vector3D_0;
        // ISSUE: reference to a compiler-generated field
        class1013.vector3D_1 = this.vector3D_1;
        this.point3D_0 = matrix.Transform(this.point3D_0);
        this.vector3D_0 = matrix.Transform(this.vector3D_0);
        this.vector3D_0.Normalize();
        this.vector3D_1 = matrix.Transform(this.vector3D_1);
        double length = this.vector3D_1.GetLength();
        this.vector3D_1.Normalize();
        if (undoGroup != null)
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfMLine.Segment.Class1014()
          {
            class1013_0 = class1013,
            point3D_0 = this.point3D_0,
            vector3D_0 = this.vector3D_0,
            vector3D_1 = this.vector3D_1
          }.method_0), new System.Action(class1013.method_0)));
        }
        foreach (DxfMLine.Segment.Element element in this.list_0)
          element.TransformMe(length, undoGroup);
      }

      public DxfMLine.Segment Clone(CloneContext cloneContext)
      {
        DxfMLine.Segment segment = new DxfMLine.Segment();
        segment.CopyFrom(this, cloneContext);
        return segment;
      }

      public void CopyFrom(DxfMLine.Segment from, CloneContext cloneContext)
      {
        this.point3D_0 = from.point3D_0;
        this.vector3D_0 = from.vector3D_0;
        this.vector3D_1 = from.vector3D_1;
        foreach (DxfMLine.Segment.Element element in from.list_0)
          this.list_0.Add(element.Clone(cloneContext));
      }

      public class Element
      {
        private List<double> list_0 = new List<double>();
        private List<double> list_1 = new List<double>();

        public Element()
        {
        }

        public Element(double[] parameters, double[] areaFillParameters)
        {
          if (parameters != null)
            this.list_0.AddRange((IEnumerable<double>) parameters);
          if (areaFillParameters == null)
            return;
          this.list_1.AddRange((IEnumerable<double>) areaFillParameters);
        }

        public List<double> Parameters
        {
          get
          {
            return this.list_0;
          }
        }

        public List<double> AreaFillParameters
        {
          get
          {
            return this.list_1;
          }
        }

        public void TransformMe(double scaleFactor, CommandGroup undoGroup)
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          DxfMLine.Segment.Element.Class1011 class1011 = new DxfMLine.Segment.Element.Class1011();
          // ISSUE: reference to a compiler-generated field
          class1011.element_0 = this;
          // ISSUE: reference to a compiler-generated field
          class1011.double_0 = this.list_0.ToArray();
          // ISSUE: reference to a compiler-generated field
          class1011.double_1 = this.list_1.ToArray();
          for (int index = this.list_0.Count - 1; index >= 0; --index)
            this.list_0[index] *= scaleFactor;
          for (int index = this.list_1.Count - 1; index >= 0; --index)
            this.list_1[index] *= scaleFactor;
          if (undoGroup == null)
            return;
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfMLine.Segment.Element.Class1012()
          {
            class1011_0 = class1011,
            double_0 = this.list_0.ToArray(),
            double_1 = this.list_1.ToArray()
          }.method_0), new System.Action(class1011.method_0)));
        }

        public DxfMLine.Segment.Element Clone(CloneContext cloneContext)
        {
          DxfMLine.Segment.Element element = new DxfMLine.Segment.Element();
          element.CopyFrom(this, cloneContext);
          return element;
        }

        public void CopyFrom(DxfMLine.Segment.Element from, CloneContext cloneContext)
        {
          this.list_0.AddRange((IEnumerable<double>) from.list_0);
          this.list_1.AddRange((IEnumerable<double>) from.list_1);
        }
      }
    }
  }
}
